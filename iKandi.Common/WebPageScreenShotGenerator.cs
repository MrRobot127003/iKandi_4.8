using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.Diagnostics;
using System.IO;

namespace iKandi.Common
{
    public class WebPageScreenShotGenerator
    {
        #region Properties

        private string ScreenShotUrl
        {
            get;
            set;
        }

        private int ScreenShotWidth
        {
            get;
            set;
        }

        private int ScreenShotHeight
        {
            get;
            set;
        }

        private Bitmap WebPageScreenShot
        {
            get;
            set;
        }

        #endregion

        #region Ctor (s)

        public WebPageScreenShotGenerator(string url, int width, int height, string loginUrl, string userName, string password)
        {
            string screenShotUrl = HttpUtility.UrlEncode(url);
            this.ScreenShotUrl = loginUrl + "?un=" + userName + "&&pwd=" + password + "&ssu=" + screenShotUrl;

            this.ScreenShotWidth = width;
            this.ScreenShotHeight = height;
        }

        #endregion

        public Bitmap GenerateScreenshot()
        {
            Thread thread = new Thread(new ThreadStart(GetScreenshot));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return WebPageScreenShot;
        }

        private void GetScreenshot()
        {
            WebBrowser wb = new WebBrowser();

            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(ScreenShotUrl);

            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

            wb.Width = ScreenShotWidth;
            wb.Height = ScreenShotHeight;

            if (ScreenShotWidth == -1)
            {
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
            }

            if (ScreenShotHeight == -1)
            {
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }

            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();

            WebPageScreenShot = bitmap;
        }

        public static List<string> GetScreenShot(string[] screenShotUrlCollection, string loginUrl, string userName, string password, int width, int height, bool changeMasterPageForScreenShot)
        {
            if (!Directory.Exists(Constants.SCREEN_SHOT_FOLDER_PATH))
                Directory.CreateDirectory(Constants.SCREEN_SHOT_FOLDER_PATH);

            Process screenShot = null;

            string joinedScreenShotUrlsWithQueryString = string.Empty;
            string joinedSavedScreenShotPaths = string.Empty;

            List<string> savedScreenShotPathCollection = new List<string>();

            foreach (string screenShotUrl in screenShotUrlCollection)
            {
                //Uri url = new Uri(screenShotUrl);
                string screenShotUrlWithQueryString = string.Empty;
                
                if (changeMasterPageForScreenShot)
                {
                    if (screenShotUrl.IndexOf("?") == -1)
                        screenShotUrlWithQueryString = screenShotUrl + "?cmpfss=true";
                    else
                        screenShotUrlWithQueryString = screenShotUrl + "&cmpfss=true";
                }
                else
                {
                    if (screenShotUrl.IndexOf("?") == -1)
                        screenShotUrlWithQueryString = screenShotUrl + "?cmpfss=false";
                    else
                        screenShotUrlWithQueryString = screenShotUrl + "&cmpfss=false";
                }

                if (joinedScreenShotUrlsWithQueryString == string.Empty)
                    joinedScreenShotUrlsWithQueryString = screenShotUrlWithQueryString;
                else
                    joinedScreenShotUrlsWithQueryString = joinedScreenShotUrlsWithQueryString + "@#$" + screenShotUrlWithQueryString;

                string savedScreenShotPath = Constants.SCREEN_SHOT_FOLDER_PATH + screenShotUrl.Substring(screenShotUrl.LastIndexOf('/') + 1, screenShotUrl.LastIndexOf(".aspx") - screenShotUrl.LastIndexOf('/') - 1) + DateTime.Today.ToString("dd MMM yy (ddd)").Replace(" ", string.Empty) + ".jpg";

                if (joinedSavedScreenShotPaths == string.Empty)
                    joinedSavedScreenShotPaths = savedScreenShotPath;
                else
                    joinedSavedScreenShotPaths = joinedSavedScreenShotPaths + "@#$" + savedScreenShotPath;

                savedScreenShotPathCollection.Add(savedScreenShotPath);
            }

            screenShot = new Process();

            screenShot.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            screenShot.StartInfo.FileName = Constants.SCREENSHOT_EXE_PATH;
            screenShot.StartInfo.Arguments = HttpUtility.UrlEncode(joinedScreenShotUrlsWithQueryString) + " " + loginUrl + " " + userName + " " + password + " " + width + " " + height + " " + joinedSavedScreenShotPaths;

            screenShot.Start();
            screenShot.WaitForExit();

            if (screenShot.ExitCode == 1)
                return savedScreenShotPathCollection;
            else
                return new List<string>();
        }

    }
}
