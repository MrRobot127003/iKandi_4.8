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
using iKandi.Common;
using iKandi.Web.Components;
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iKandi.BLL;
using System.Text;
using iKandi.BLL.Production;
using System.Collections.Generic;


namespace iKandi.Web
{
    public partial class testPoFor : System.Web.UI.Page
    {
        UserController objuser = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
          List<User> objusessr = objuser.GetUser(txtSearch.Text.Trim());
          if (objusessr.Count > 0)
          {
            grdinproduction.Visible = true;
            grdinproduction.DataSource = objusessr;
            grdinproduction.DataBind();
          }
          else
            grdinproduction.Visible = false;

        }
    }
}