using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Web;

namespace iKandi.WebPageScreenShotApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 7) { Environment.Exit(0); }

            string[] screenShotUrlCollection = args[0].Split(new string[] { "@#$" }, StringSplitOptions.RemoveEmptyEntries);

            string loginUrl = args[1];
            string userName = args[2];
            string password = args[3];
            string width = args[4];
            string height = args[5];

            string[] savePathCollection = args[6].Split(new string[] { "@#$" }, StringSplitOptions.RemoveEmptyEntries);

            if (screenShotUrlCollection.Length != savePathCollection.Length) { Environment.Exit(0); }

            for (int i = 0; i < screenShotUrlCollection.Length; i++)
            {
                string url = loginUrl + "?un=" + userName + "&pwd=" + HttpUtility.UrlEncode(password) + "&ssu=" + HttpUtility.UrlEncode(screenShotUrlCollection[i]);
                GenerateScreenshot(url, Convert.ToInt32(width), Convert.ToInt32(height)).Save(savePathCollection[i]);
            }

            Environment.Exit(1);
        }

        public static Bitmap GenerateScreenshot(string url, int width, int height)
        {
            

            WebBrowser wb = new WebBrowser();

            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(url);

            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

            wb.Width = width;
            wb.Height = height;

            if (width == -1)
            {
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
            }

            if (height == -1)
            {
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }

            //System.Threading.Thread.Sleep(5000);

            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();

            return bitmap;
        }
    }
}
