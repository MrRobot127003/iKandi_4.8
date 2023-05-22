using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace iKandi.Web
{
    public partial class ManageOrderSAMPopUp : BaseUserControl
    {
        //public int OrderID
        //{
        //    get;
        //    set;
        //}

        private int OrderID
        {
            get
            {
                if (null != Request.QueryString["OrderID"])
                {
                    int OrderID;

                    if (int.TryParse(Request.QueryString["OrderID"].ToString(), out OrderID))
                        return OrderID;
                }

                return -1;
            }
        }
        private int StatusID
        {
            get
            {
                if (null != Request.QueryString["StatusID"])
                {
                    int StatusID;

                    if (int.TryParse(Request.QueryString["StatusID"].ToString(), out StatusID))
                        return StatusID;
                }

                return -1;
            }
        }
        private int Styleid
        {
            get
            {
                if (null != Request.QueryString["Styleid"])
                {
                    int Styleid;

                    if (int.TryParse(Request.QueryString["Styleid"].ToString(), out Styleid))
                        return Styleid;
                }

                return -1;
            }
        }

        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!IsPostBack)
            {
                BindControls();
            }
        }
        private void BindControls()
        {
            
            if (StatusID < 11)
            {
                txtSTCSam.CssClass = "hide_me";
            }
            if (StatusID < 7)
            {
                txtOrderdSam.CssClass = "hide_me";
            }
            hdnOrderID.Value = Convert.ToString(OrderID);
            ds = this.OrderControllerInstance.GetManageOrderSTCPopupDetails(OrderID);
            if (ds.Tables.Count > 0)
            {
                hypOrderView.Visible = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["OrderSamFilePath"])) ? false : true;
                hypSTCView.Visible = String.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["STCSamFilePath"])) ? false : true;
                hypOrderView.NavigateUrl = "~/Uploads/Photo/" + ds.Tables[0].Rows[0]["OrderSamFilePath"];
                hypSTCView.NavigateUrl = "~/Uploads/Photo/" + ds.Tables[0].Rows[0]["STCSamFilePath"];

                txtOrderdSam.Text = Convert.ToString(ds.Tables[0].Rows[0]["OrderedSam"]);
                txtSTCSam.Text = Convert.ToString(ds.Tables[0].Rows[0]["STCSam"]);

            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string stcSamPath;
            string ordSamPath;
            DateTime dt = DateTime.Now;
            string s = String.Format("{0:G}", dt);
            s = s.Replace(" ", "_");
            s = s.Replace(':', '/');
            s = s.Replace('/', '-');
            string stringfleOrderedSam = fleOrderedSam.FileName;
            string stringflestcSam = flestcSam.FileName;

           
                if (stringfleOrderedSam != "")
                    fleOrderedSam.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + stringfleOrderedSam);
                if (stringflestcSam != "")
                    flestcSam.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + stringflestcSam);
                ordSamPath = stringfleOrderedSam == "" ? "NOT" : s + stringfleOrderedSam;
                stcSamPath = stringflestcSam == "" ? "NOT" : s + stringflestcSam;

                bool Continue = this.OrderControllerInstance.InsertManageOrderSam(OrderID, Convert.ToInt32(txtOrderdSam.Text), Convert.ToInt32(txtSTCSam.Text), ordSamPath, stcSamPath, Styleid);
          
               Page.ClientScript.RegisterStartupScript(this.GetType(), "close", "<script language=javascript>window.opener.location.reload(true); self.close();</script>");

        }

        protected void BTNADD_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}