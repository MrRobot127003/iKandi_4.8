using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Net;
using iKandi.BLL;
using iKandi.Common;
using System.Collections.Generic;
using System.IO.Compression;

namespace iKandi.Web
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Timer to run list processor
        /// </summary>
        static Timer timer = null;

        /// <summary>
        /// Site URI to use in background threads
        /// </summary>
        static public string siteUri = String.Empty;

        protected void Application_Start(object sender, EventArgs e)
        {
            // Cache site URI to use in background threads
            // siteUri = HttpContext.Current.Request.Url.AbsoluteUri; 

            // Start background processor
            //StartBackGroundProcessor();aa 
            Application["NoOfVisitors"] = 0;
        }



        protected void Session_Start(object sender, EventArgs e)
        {

            // Start background processor
            //StartBackGroundProcessor();
            Application.Lock();
            Application["NoOfVisitors"] = (int)Application["NoOfVisitors"] + 1;
            Application.UnLock();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            //HttpResponse Response = HttpContext.Current.Response;

            //if (IsCompressionAllowed()) // If client browser supports HTTP compression
            //{
            //    string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"]; //Browser supported encoding format

            //    // If client browser supports both "deflate" and "gzip" compression, Then we will consider "deflate" first , because it is
            //    // more efficient than "gzip"

            //    if (AcceptEncoding.Contains("deflate"))
            //    {
            //        Response.Filter = new DeflateStream(Response.Filter, CompressionMode.Compress);
            //        Response.AppendHeader("Content-Encoding", "deflate");
            //    }
            //    else
            //    {
            //        Response.Filter = new GZipStream(Response.Filter, CompressionMode.Compress);
            //        Response.AppendHeader("Content-Encoding", "gzip");
            //    }
            //}

            //// Allow proxy servers to cache encoded and unencoded versions separately
            //Response.AppendHeader("Vary", "Content-Encoding");

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);
            if (!isDebug)
            {
                try
                {
                    string ex = HttpContext.Current.Server.GetLastError().Message.ToString();
                    if ((ex != "File does not exist.") && (ex != "Illegal characters in path."))
                        Server.Transfer("~/Internal/CustomErrorPage.aspx");
                }
                catch
                {
                }
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {            
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Start background processor
        /// </summary>
        private void StartBackGroundProcessor()
        {

            // Already running
            if (timer != null)
                return;

            try
            {
                // Load timer settings from configuration file
                timer = new Timer(OnTimer, "Application iKandi", 3600000, 3600000);
            }
            catch (Exception ex)
            {
                // Send mail
                HandleException(ex);
            }
        }

        /// <summary>
        /// Timer delegate, process background activities
        /// </summary>
        /// <param name="state"></param>
        protected void OnTimer(object state)
        {
            NotificationController controller = new NotificationController();
            List<string> to = new List<string>();
            to.Add("itsupport@boutique.in");
            controller.SendDevelopermail("webadmin@boutique.in", to, null, null, "Timer Execute at " + DateTime.Now.ToLongTimeString(), "", null, false, true);

            // Ping self to keep application alive
            ping(siteUri);


            BackgroundProcessingController bgController = new BackgroundProcessingController();
            bgController.ExecuteProcess();
        }

        /// <summary>
        /// Generate email to admin listed. Keep the handler simple. 
        /// Avoid any extra activities which might cause further exceptions e.g loading email templates from xml files etc
        /// </summary>
        public void HandleException(Exception ex)
        {
            NotificationController controller = new NotificationController();
            //controller.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
        }

        private void ping(string uri)
        {
            // Create a request for the URL. Should look like
            WebRequest request = WebRequest.Create(uri);

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            try
            {
                // Get the response and discard it
                (request.GetResponse() as HttpWebResponse).Close();
            }
            catch (WebException ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private bool IsCompressionAllowed()
        {
            //Browser supported encoding format
            string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];

            if (!string.IsNullOrEmpty(AcceptEncoding))
            {
                if (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"))
                    return true; ////If browser supports encoding
            }

            return false;
        }
    }
}