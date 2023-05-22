using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Pechkin;
using Pechkin;
using System.IO;
using iKandi.BLL;
using System.Net;
using iKandi.Web.Components;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;

namespace iKandi.Web
{
    public partial class SanjeevTest : System.Web.UI.Page
    {
        string host = "";
        public int ParentOrderDetailID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["PODID"]))
                {
                    return Convert.ToInt32(Request.QueryString["PODID"]);
                }
                return -1;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;

            LoadHistory(ParentOrderDetailID);
        }

        protected void BtnGenRate_Click(object sender, EventArgs e)
        {
            AdminController objadmin = new AdminController();
            LogFileWrite("Code to gen Start");
            string strHTML = "";
            // string ss = host + "/../../FabricPurChasedFormPrint.aspx?" + Session["q"].ToString() + "&AuthName=" + "" + "&AuthPhoto=" + "" + "&ApproName=" + "" + "&ApproPhoto=" + "" + "&PoNumberPrint=" + hdnponumber.Value;
            string ss = "http://192.168.0.4:85/FabricPurChasedFormPrint.aspx?FabricQualityID=82&Fabtype=EMBELLISHMENT&Potype=RERAISE&ParentPageUrlWithQuerystring=http%3a%2f%2flocalhost%3a3220%2fInternal%2fFabric%2fFabricViewAll.aspx%3fPo_number%3dSJKPLF27&SupplierNasterID=8&IsMailSend=0&MasterPoID=64&colorprintdetail=6687+olive+green+spoprint-6687&gerige=0&residual=0&cutwastage=5&currentstage=4&previousstage=3&isStyleSpecific=1&styleid=97997&stage1=29&stage2=2&stage3=3&stage4=30";
            //FabricQualityID=17&Fabtype=GRIEGE&Potype=RERAISE&MasterPoID=55&colorprintdetail=&gerige=3&residual=2&cutwastage=7&currentstage=0&previousstage=0&isStyleSpecific=0&styleid=0&stage1=1&stage2=3&stage3=31&stage4=30";
            Uri requestUri = null;
            Uri.TryCreate((ss), UriKind.Absolute, out requestUri);
            NetworkCredential nc = new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password);
            CredentialCache cache = new CredentialCache();
            cache.Add(requestUri, "Basic", nc);
            cache.Add(new Uri(ss), "NTLM", new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password));

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            request.Credentials = cache;

            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader respStream = new StreamReader(response.GetResponseStream());
            strHTML = respStream.ReadToEnd();
            LogFileWrite("Html Recived ");
            //// commented temporarily
            genertaePdf(strHTML, "ss");

        }

        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            LogFileWrite("genertaePdf Start");

            string strFileName = "";
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);

            LogFileWrite("genertaePdf End");
        }
        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            LogFileWrite("getvartypeHTML Start");
            string filename = "POFabric_" + "SanjeevTest" + ".pdf";
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {
                LogFileWrite("pechkin GlobalConfig Assigned");
                //var pdf = pechkin.Convert(new ObjectConfig()
                //                        .SetLoadImages(true).SetZoomFactor(1.5)
                //                        .SetPrintBackground(true)
                //                        .SetScreenMediaType(true)
                //                        .SetCreateExternalLinks(true), (HTMLCode.Replace("flow-root;", "none;")));
                var pdf = pechkin.Convert(new ObjectConfig()
                                       .SetLoadImages(true).SetZoomFactor(1.5)
                                       .SetPrintBackground(true)
                                       .SetScreenMediaType(true)
                                       .SetCreateExternalLinks(true), ("<h1>Helo to test</h1>"));
                LogFileWrite("Var  pdf Convert");
                LogFileWrite("start Pdf save");
                using (FileStream file = System.IO.File.Create(strFileName))
                {
                    file.Write(pdf, 0, pdf.Length);
                }
                LogFileWrite("start Pdf save Done");

                LogFileWrite("getvartypeHTML End");
            }
        }

        public string getImage(string input)
        {
            LogFileWrite("getImage Start");
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);

                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
                        if (src == "../../signatured.jpg" || src == "../signatured.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/SignatureD.jpg");

                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {

                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);

                                //insert new url img tag in whole html code
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                            }
                        }
                    }
                }
            }
            LogFileWrite("getImage End");
            return tempInput;

        }



        public static void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilewithname = "POFabric_SanjeevTest" + ".txt";
                string logFilePath = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + logFilewithname);

                if (logFilePath.Equals("")) return;
                #region Create the Log file directory if it does not exists
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log file directory if it does not exists


                if (!logFileInfo.Exists) { fileStream = logFileInfo.Create(); }
                else { fileStream = new FileStream(logFilePath, FileMode.Append); }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine("Datetime of Log : " + DateTime.Now.ToString() + Environment.NewLine + " Message:- " + message + Environment.NewLine + Environment.NewLine);

            }
            catch
            {
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }
        }


        public void LoadHistory(int ParentOrderDetailID)
        {
            if (ParentOrderDetailID > 0)
            {
                lblsplitHistory.Text = "";
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = @"
                                        declare @OrderID int

		                                select @OrderID=orderid from order_detail where id=@ParentOrderDetailID	                               	

		                                select id,
                                                '<tr> 
	                                                <td>'+ cast(ParentOrderDetailID as nvarchar(20)) +'</td>
	                                                <td>'+ cast(isnull(orderdetailid,0) as nvarchar(20)) +'</td>
	                                                <td>'+ cast(isnull(LogOn,'') as nvarchar(20)) +'</td>
	                                                <td>'+ cast(isnull(ProcName,'') as nvarchar(200)) +'</td>
	                                                <td>'+ cast(isnull(Comment,'') as nvarchar(max)) +'</td>
                                                </tr>' as TrRow
                                        from Order_Spliting_Log
                                        where (
                                                (ParentOrderDetailID = @ParentOrderDetailID ) 
                                                or 
                                                (ParentOrderDetailID=  @OrderID  and orderdetailid =@OrderID )
                                               )
                                        order by id
                                    ";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@ParentOrderDetailID", SqlDbType.Int);
                    param.Value = ParentOrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsSpliting_Log = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsSpliting_Log);
                    DataTable Spliting_LogTable = dsSpliting_Log.Tables[0];
                    if (Spliting_LogTable.Rows.Count > 0)
                    {
                        lblsplitHistory.Text = "<table>";
                        foreach (DataRow rows in Spliting_LogTable.Rows)
                        {
                            lblsplitHistory.Text += Convert.ToString(rows["TrRow"]);
                        }
                        lblsplitHistory.Text += "</table>";
                    }
                }
            }
        }
    }
}