using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace iKandi.Web
{
    public partial class MSG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Msg"] != null && Request.QueryString["Msg"].ToString() != "")
            {
                lblmsg.Text = Request.QueryString["Msg"];
                if (Request.QueryString["Type"] != null && Request.QueryString["Type"].ToString() != "")
                {
                    if (Request.QueryString["Type"] == "error")
                    {
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.ForeColor = Color.Green;
                    }
                }
            }
        }
    }
}