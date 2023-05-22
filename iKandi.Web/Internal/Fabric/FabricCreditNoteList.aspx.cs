using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Common.Entities;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricCreditNoteList : System.Web.UI.Page
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public int Created_Note_ID
        {
            get;
            set;
        }
        FabricController objfab = new FabricController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                SupplierPoId = 0;
            }
            if (Request.QueryString["Created_Note_ID"] != null)
            {
                Created_Note_ID = Convert.ToInt32(Request.QueryString["Created_Note_ID"]);
            }
            else
            {
                Created_Note_ID = 0;
            }
            if (!IsPostBack)
            {
                BindData();
                DataTable dt = objfab.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
        }

        private void BindData()
        {
            DataSet ds = objfab.GetFabricCreditNoteList(SupplierPoId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblPoNumber.Text = dt.Rows[0]["PO_Number"].ToString();
                lblSupplier.Text = dt.Rows[0]["SupplierName"].ToString();

                grdDebitNote.DataSource = ds.Tables[0];
                grdDebitNote.DataBind();
            }

            List<Fabric_Srv_Bill> Accessory_Srv_BillList = objfab.GetFabric_Srv_Bill_DropDownList_Creditnote(SupplierPoId, 0);
            if (Accessory_Srv_BillList.Count > 0)
            {
                btnCreate.Visible = true;
            }

        }
        protected void grdDebitNote_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBillDate = (Label)e.Row.FindControl("lblBillDate");
                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                Label lbldebtdate = (Label)e.Row.FindControl("lbldebtdate");

                HiddenField hdnsupplierpoid = (HiddenField)e.Row.FindControl("hdnsupplierpoid");
                HiddenField hdnDebitId = (HiddenField)e.Row.FindControl("hdnDebitId");
                HiddenField hdnfab = (HiddenField)e.Row.FindControl("hdnfab");
                HiddenField hdnchallno = (HiddenField)e.Row.FindControl("hdnchallno");
                HiddenField hdnchallanid = (HiddenField)e.Row.FindControl("hdnchallanid");
                Label lbldebitnos = (Label)e.Row.FindControl("lbldebitnos");
                Label lblDebitNo = (Label)e.Row.FindControl("lblDebitNo");
                Label lblBillNo = (Label)e.Row.FindControl("lblBillNo");
                string date = DataBinder.Eval(e.Row.DataItem, "PartyBillDate").ToString();
                string Amount = DataBinder.Eval(e.Row.DataItem, "Amount").ToString();
                if (lblDebitNo.Text == "")
                {
                    e.Row.Visible = false;
                }
                if (Convert.ToDouble(hdnDebitId.Value) > 0)
                {
                    lblBillNo.Text = (lblBillNo.Text == "" ? "N/A" : lblBillNo.Text);
                }
                if (date != "")
                {
                    lblBillDate.Text = Convert.ToDateTime(date).ToString("dd MMM yy (ddd)");
                }
                if (Amount != "")
                {
                    lblAmount.Text = decimal.Parse(Amount).ToString("#,#.##");
                }
                string debitnotedate = DataBinder.Eval(e.Row.DataItem, "DebitNoteDate").ToString();
                string debitnoteNumber = DataBinder.Eval(e.Row.DataItem, "DebitNoteNumber").ToString();
                lbldebitnos.Text = debitnoteNumber;
                if (debitnotedate != "")
                {
                    lbldebtdate.Text= Convert.ToDateTime(debitnotedate).ToString("dd MMM yy (ddd)");
                    if (lblBillDate.Text != "")
                    {
                        lbldebtdate.Text = lbldebtdate.Text + " /" + lblBillDate.Text;
                    }
                }
                


            }
        }
    }
}