using System;
using System.Web.UI;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;




namespace iKandi.Web
{
    public partial class ChangePassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LinkButton_Click(Object sender, EventArgs e)
        {

            //DropDownList ddlDomain = Login1.FindControl("Domain") as DropDownList;
            //string PrifixDomain = string.Empty;

            //if (ddlDomain.SelectedValue == "1")
            //{
            //    PrifixDomain = "@ikandi.org.uk";

            //}
            //else if (ddlDomain.SelectedValue == "2")
            //{
            //    PrifixDomain = "@boutique.in";
            //}
            //string s = Login1.UserName;
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //ds = this.MembershipControllerInstance.GetFaildLoginCountEmilcheck(s + PrifixDomain);
            //dt = ds.Tables[0];
            //int Check_count = Convert.ToInt32(dt.Rows[0]["IsUserExist"]);


            //if (Check_count == 2)
            //{
            //    Alert(this.Page, "Please Enter valid Email ID..!");
            //    return;
            //}
            //if (string.IsNullOrEmpty(s))
            //{
            //    Alert(this.Page, "Please Enter EmailID first without password for change password");
            //    return;
            //}
            //else
            //{
                Response.Redirect("~/public/forgotpassword.aspx?flag=" + "");
           // }
        }
    }
}
