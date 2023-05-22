using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Web.Components;
using iKandi.BLL;
namespace iKandi.Web
{
    public partial class SimpleSecure : System.Web.UI.MasterPage
    {
        #region Proerties

        private string Message
        {
            get
            {
                return Request["message"];
            }
        }

        private string ErrorMessage
        {
            get
            {
                return Request["errorMessage"];
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string script = string.Empty;

            if (null != ErrorMessage)
            {
                script = "ShowHideValidationBox(true, '" + ErrorMessage + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }
            else if (null != Message)
            {
                script = "ShowHideMessageBox(true, '" + Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }

            if (ApplicationHelper.IsPrintRequest)
            {
                litStyles.Text = "<style type='text/css'>.save, .saveAs, .submit, .add, .print, .add-more,.do-not-print,.go, .sentProposal, .summary, .agree, .disagree, input[type=file] { display:none;   } INPUT[type=text], .center_bodyCentering, textarea, SELECT, .form_box_border { font-size:12px ! important;}</style>";
            }







      /*      UserController uc = new UserController();
            string nowip = null;

            //  nowip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (nowip == null)
            {
                //nowip = Request.ServerVariables["REMOTE_ADDR"];
                nowip = "127.0.5.2";
            }
            string[] s = nowip.Split('.');
            string ip = null;
            //   foreach (string str in s)                        
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (i == 2)
                    ip = ip + s[i];
                if (i == 1 || i == 0)
                    ip = ip + s[i] + ".";
            }
            int intip = 0;
            intip = uc.GetIpStatus(ip);
            if (intip == 0)
            {
                Response.Redirect("~/Internal/Logout.aspx");
                (sender as System.Web.UI.WebControls.Login).FailureText = "you are not valid User";
            }



            //

         */   








        }
    }
}
