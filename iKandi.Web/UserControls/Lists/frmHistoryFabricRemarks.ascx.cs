using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web.UserControls.Lists
{
    public partial class frmHistoryFabricRemarks : System.Web.UI.UserControl
    {
        public int FabricQualityID
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["FabricQualityID"])
            {
                FabricQualityID = Convert.ToInt32(Request.QueryString["FabricQualityID"]);
            }
            if (!IsPostBack)
            {
                bindRemarks();
            }
        }
        public void bindRemarks()
        {
            string strRemarks = "";
            iKandi.BLL.OrderController cs = new iKandi.BLL.OrderController();
          
            strRemarks = cs.GetFabricHistory(FabricQualityID);
           
        

            if (strRemarks != "")
            {
                string[] separators = { "`" };
                string[] words = strRemarks.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    litRemarks.Text = litRemarks.Text + "</br>" + word;
                }
            }
            

        }
    }
}