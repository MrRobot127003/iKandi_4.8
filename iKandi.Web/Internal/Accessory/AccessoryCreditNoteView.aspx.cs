using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using iKandi.Common;
using iKandi.BLL;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryCreditNoteView : System.Web.UI.Page
    {
        public int DebitNoteId
        {
            get;
            set;
        }
        public int SupplierPoId
        {
            get;
            set;
        }
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        OrderProcessController obj_ProcessController = new BLL.OrderProcessController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                SupplierPoId = 0;
            }
            if (!IsPostBack)
            {
                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
                BindData();
            }
        }

        private void BindData()
        {
            List<AccessoryCreditNoteCls> objAccessoryCreditNote = objAccessoryWorking.GetAccessoryCreditNoteList(SupplierPoId, txtsearchkeyswords.Text.Trim());
            lblPoNumber.Text = objAccessoryCreditNote[0].PoNumber;
            lblSupplier.Text = objAccessoryCreditNote[0].SupplierName;

            if (objAccessoryCreditNote[0].DebitNoteId > 0)
            {
                grdCreditNote.DataSource = objAccessoryCreditNote;
                grdCreditNote.DataBind();
            }           

            List<Accessory_Srv_Bill> Accessory_Srv_BillList = objAccessoryWorking.GetAccessory_List_Against_Debit_Bill(SupplierPoId, 0, "CREATE");
            if (Accessory_Srv_BillList.Count > 0)
            {
                btnCreate.Visible = true;
            }
        }

        protected void btnGoProcess_Click(object sender, EventArgs e)
        {
            BindData();
        }

        //protected void grdCreditNote_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        HiddenField hdnCreditId = (HiddenField)e.Row.FindControl("hdnCreditId");

        //        //string ChallanNo = DataBinder.Eval(e.Row.DataItem, "ReturnChallanNumber").ToString();
        //        //int ChallanId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ReturnChallanId"));

        //        //System.Text.StringBuilder sb6 = new System.Text.StringBuilder();
        //        //sb6.Append("<table id='data' style='width:100%' >");
        //        //string challans = "";
        //        //if (ChallanNo == "")
        //        //{
        //        //    challans = "<img src='../../images/edit.png' />";
        //        //}
        //        //else
        //        //{
        //        //    challans = ChallanNo;
        //        //}
        //        //sb6.AppendFormat("<tr><td class='process' style='width: 100%;border: 0px solid #dbd8d8;text-align:center' onclick='ShowSupplierChallanScreen(" + hdnCreditId.Value + ',' + "&apos;" + DebitNoteId.ToString() + "&apos;" + ',' + ChallanId + ")'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' >" + challans + "</a>" + "</td></tr>");
        //        //sb6.Append("</table>");
        //        //e.Row.Cells[5].Text = sb6.ToString();
        //    }
        //}
    }
}