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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
using System.Drawing;
using System.Web.Services;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricPurChaseLliabilityPopUp : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();
        public string PoNumber
        {
            get;
            set;

        }
        public int OrderDetails
        {
            get;
            set;

        }
        public int LibilityQty
        {
            get;
            set;

        }
        public string LogedInDesignation
        {
            get
            {
                if (!string.IsNullOrEmpty(ApplicationHelper.LoggedInUser.UserData.UserID.ToString()))
                {
                    return ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
                }

                return "";
            }
        }
        public int UserID
        {
            get
            {
                if (!string.IsNullOrEmpty(ApplicationHelper.LoggedInUser.UserData.UserID.ToString()))
                {
                    return ApplicationHelper.LoggedInUser.UserData.UserID;
                }

                return -1;
            }
        }
        public void getquerystring()
        {

            if (Request.QueryString["SupplierPoId"] != null)
            {
                PoNumber = Request.QueryString["SupplierPoId"].ToString();
            }
            else
            {
                PoNumber = "KPLF76";
            }
            if (Request.QueryString["Qty"] != null)
            {
                LibilityQty = Convert.ToInt32(Request.QueryString["Qty"].ToString());
            }
            else
            {
                LibilityQty = 0;
            }
            if (Request.QueryString["OrderDetails"] != null)
            {
                OrderDetails = Convert.ToInt32(Request.QueryString["OrderDetails"].ToString());
            }
            else
            {
                OrderDetails = 0;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getquerystring();
                BindData();
            }

        }
        public void BindData()
        {
            DataTable dt = new DataTable();
            dt = fabobj.Getfabricliability("LIABILITY", "", PoNumber);
            if (dt.Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                DataTable dts = new DataTable();
                string Fabtype = "";
                string colorprintdetail = "";
                int FabricQualityID = 0;
                int SupplierMasterID = 0;
                int MasterPoID = 0;
                if (dt.Rows[0]["SupplyType"].ToString() == "10")
                {
                    Fabtype = "FINISHING";
                    PoQtyhead.Visible = true;
                    PoQty.Visible = true;
                    SendQty.Visible = false;
                    PoSendQtyhead.Visible = false;
                }
                else if (dt.Rows[0]["SupplyType"].ToString() == "1")
                {
                    Fabtype = "GRIEGE";
                    PoQtyhead.Visible = true;
                    PoQty.Visible = true;
                    PoSendQtyhead.Visible = false;
                    SendQty.Visible = false;

                }
                else if (dt.Rows[0]["SupplyType"].ToString() == "2")
                {
                    Fabtype = "Dyed";

                }
                else if (dt.Rows[0]["SupplyType"].ToString() == "3")
                {
                    Fabtype = "PRINT";

                }
                else if (dt.Rows[0]["SupplyType"].ToString() == "31")
                {
                    Fabtype = "Embroidery";

                }
                else if (dt.Rows[0]["SupplyType"].ToString() == "30")
                {
                    Fabtype = "Embellishment";

                }
                else if (dt.Rows[0]["SupplyType"].ToString() == "29")
                {
                    Fabtype = "RFD";
                    PoQtyhead.Visible = true;
                    PoQty.Visible = true;
                    PoSendQtyhead.Visible = false;
                    SendQty.Visible = false;

                }
                lbltypes.Text = Fabtype;
                lblgerigeshrinkage.Text = Fabtype;
                lblponumber.Text = PoNumber;
                FabricQualityID = Convert.ToInt32(dt.Rows[0]["Fabric_QualityID"].ToString());
                SupplierMasterID = Convert.ToInt32(dt.Rows[0]["SupplierID"].ToString());
                MasterPoID = Convert.ToInt32(dt.Rows[0]["MasterPO_id"].ToString());
                colorprintdetail = dt.Rows[0]["FabricDetails"].ToString();
                lblsuppliername.Text = dt.Rows[0]["SupplierName"].ToString();
                lblcountcounstruction.Text = dt.Rows[0]["CountConstruction"].ToString();
                lblwidthgsm.Text = dt.Rows[0]["CutWidth"].ToString();
                lblgsm.Text = dt.Rows[0]["GSM"].ToString();
                lblgerigeshrinkage.Text = dt.Rows[0]["GerigeShrink"].ToString();
                lblsendqty.Text = (dt.Rows[0]["SendQty"].ToString() == "" ? "" : Convert.ToInt32(dt.Rows[0]["SendQty"].ToString()).ToString("N0"));
                lblsrvqty.Text = Convert.ToInt32(dt.Rows[0]["SrvReceivedQty"].ToString() == "" ? "0" : dt.Rows[0]["SrvReceivedQty"].ToString()).ToString("N0");
                decimal avgs = 0;
                if (dt.Rows[0]["Avgs"].ToString() != "")
                    avgs = Convert.ToDecimal(dt.Rows[0]["Avgs"].ToString());

                //decimal val = Convert.ToDecimal(LibilityQty) * Convert.ToDecimal(avgs);
                //txtlibilityqty.Text = Math.Round(val,0).ToString("N0");

                txtlibilityqty.Text = Math.Round(Convert.ToDecimal(lblsrvqty.Text.Replace(",", "")), 0).ToString("N0");
                hdnsrvqty.Value = Math.Round(Convert.ToDecimal(lblsrvqty.Text.Replace(",", "")), 0).ToString("N0");
                lblresidualshrinkage.Text = dt.Rows[0]["ResidualShrinkage"].ToString();
                lblcutwitdh.Text = dt.Rows[0]["Cutting_Wastage"].ToString();

                ds = fabobj.GetFabricpurchasedSupplier(Fabtype, "GET", FabricQualityID, 0, "RERAISE", SupplierMasterID, MasterPoID, colorprintdetail);
                dts = ds.Tables[0];

                if (dt.Rows[0]["PODate"].ToString() != "")
                {
                    lblpodate.Text = Convert.ToDateTime(dt.Rows[0]["PODate"]).ToString("dd MMM yy (ddd)");

                }
                if (dt.Rows[0]["ETA"].ToString() != "")
                {
                    lbletadate.Text = Convert.ToDateTime(dt.Rows[0]["ETA"]).ToString("dd MMM yy (ddd)");
                }
                lblfabricName.Text = dt.Rows[0]["FabricQualityName"].ToString();
                lblprintdeatil.Text = dt.Rows[0]["FabricDetails"].ToString();
                if (dts.Rows.Count > 0)
                {
                    if (dts.Rows[0]["QtyToOrder"].ToString() != "")
                    {
                        lblqty.Text = Convert.ToInt32(dts.Rows[0]["QtyToOrder"].ToString()).ToString("N0");
                    }
                }
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        public void UpdateLibility()
        {
            getquerystring();
            int IsUpdate = fabobj.UpdateFabricLibilityQty("LIABILITYUPDATE", "", PoNumber, UserID, Convert.ToInt32(txtlibilityqty.Text.Replace(",", "")), OrderDetails);
            if (IsUpdate > 0)
            {
                ShowAlert("Updated successfully");
                btnSubmit.Visible = false;
                Response.Redirect("../Dashboard_Task.aspx");
            }
        }
        protected void btn_btnSubmit(object sender, EventArgs e)
        {
            if (txtlibilityqty.Text == "")
            {
                ShowAlert("Enter value");
                return;
            }
            else if (Convert.ToInt32(txtlibilityqty.Text.Replace(",", "")) > Math.Abs(Convert.ToInt32(lblsrvqty.Text.Replace(",", ""))))
            {
                ShowAlert("Entred qty cannot be greater than srv qty");
                txtlibilityqty.Text = hdnsrvqty.Value;
                return;
            }
            else
            {

                UpdateLibility();
            }
        }
    }
}