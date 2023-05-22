using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Text;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoriesQualityIssuing : System.Web.UI.Page
    {
        Designation[] IssueRequestDesig = { Designation.BIPL_Production_PPC_Exec, Designation.BIPL_Fabrics_PPC_Fabric_Executive, Designation.BIPL_Fabrics_Manager_PPC, Designation.BIPL_Admin };
        Designation[] IssueRequestedDesig = { Designation.BIPL_Admin, Designation.BIPL_Fabrics_Manager, Designation.BIPL_Accessory_Accountant, Designation.BIPL_Accessory_Manager };
        int OrderID = -1;
        static int SelectedODID;
        static int AccessoryMasterId;
        static string Size;
        static string ColorPrint;
        static int SupplyType;
        bool IsRequestPending = false;
        bool IsIssueRequest = false;
        bool IsCompleteIssue = false;

        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        FabricController fabobj = new FabricController();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (Request.QueryString["OrderID"] != null)
            {
                OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
            }
            if (!Page.IsPostBack)
            {
                dt = objAccessoryWorking.GetChallanNumberForAccessoryInternalChallan(OrderID);
                BindGrid();
            }
           
            
        }

        protected void BindGrid()
        {
            dt = objAccessoryWorking.GetChallanNumberForAccessoryInternalChallan(OrderID);
            if (OrderID > 0)
            {
                dvSearch.Visible = false;
            }
            List<AccessoryQualityIssuing> objAccessoriesDetails = objAccessoryWorking.GetAccessoriesQualityIssuing(txtsearchkeyswords.Text.Trim(), IsRequestPending, IsIssueRequest, IsCompleteIssue, OrderID);

            if (objAccessoriesDetails.Count > 0)
            {
                ChdnIssueRequest.Value = objAccessoriesDetails[0].IsIssueRequest.ToString();

                grdAccessory.DataSource = objAccessoriesDetails;
                grdAccessory.DataBind();

            }
            else
            {
                grdAccessory.DataSource = null;
                grdAccessory.DataBind();
            }
        }

        protected void grdAccessory_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox chkRaiseReuestAll = (CheckBox)e.Row.FindControl("chkRaiseReuestAll");

                DropDownList ddlFactoryUnit = ((DropDownList)e.Row.FindControl("ddlFactoryUnit"));
                DataTable dtProd = new DataTable();
                dtProd = fabobj.GetSupplierChallanDetails("PRODUCTIONUNIT").Tables[0];
                ddlFactoryUnit.DataSource = dtProd;
                ddlFactoryUnit.DataBind();
                if (IssueRequestDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    chkRaiseReuestAll.Enabled = true;


                }

                if (ChdnIssueRequest.Value == "1")
                {
                    chkRaiseReuestAll.Checked = true;
                    chkRaiseReuestAll.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                Label lblEmptyMsg = (Label)e.Row.FindControl("lblEmptyMsg");
                if (txtsearchkeyswords.Text != "")
                {
                    btnSubmit.Visible = false;
                }
                else
                {
                    btnSubmit.Visible = false;
                }
            }





            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                PlaceHolder phChallan = (PlaceHolder)e.Row.FindControl("phChallan");
                CheckBox cbIssueRequest = (CheckBox)e.Row.FindControl("cbIssueRequest");
                CheckBox cbIssueComplete = (CheckBox)e.Row.FindControl("cbIssueComplete");
                HiddenField hdnOrderDetailId = (HiddenField)e.Row.FindControl("hdnOrderDetailId");
                HiddenField hdnAccessoryMasterId = (HiddenField)e.Row.FindControl("hdnAccessoryMasterId");
                HiddenField hdnIssueRequest = (HiddenField)e.Row.FindControl("hdnIssueRequest");
                HiddenField hdnIssueComplete = (HiddenField)e.Row.FindControl("hdnIssueComplete");
                Label lblRequestDate = (Label)e.Row.FindControl("lblRequestDate");
                Label lblIssueCompleteDate = (Label)e.Row.FindControl("lblIssueCompleteDate");
                Label lblColorPrint = (Label)e.Row.FindControl("lblColorPrint");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblQuantity = (Label)e.Row.FindControl("lblQuantity");
                Label lblAvailableQtyToIssue = (Label)e.Row.FindControl("lblAvailableQtyToIssue");
                Label lblTotalAccessoriesRequired = (Label)e.Row.FindControl("lblTotalAccessoriesRequired");
                Label lblRequiredQty = (Label)e.Row.FindControl("lblRequiredQty");
                //Label lblQtyLeft = (Label)e.Row.FindControl("lblQtyLeft");
                Label Unit1 = (Label)e.Row.FindControl("Unit1");
                Label Unit2 = (Label)e.Row.FindControl("Unit2");
                Label Unit3 = (Label)e.Row.FindControl("Unit3");
                Label lblTooltip = (Label)e.Row.FindControl("lblTooltip");
                Label lblStock_DebitQty = (Label)e.Row.FindControl("lblStock_DebitQty");
                Label lblTotalIssued = (Label)e.Row.FindControl("lblTotalIssued");
                Label lblReturnedQty = (Label)e.Row.FindControl("lblReturnedQty");

                Label lblUnitName = ((Label)e.Row.FindControl("lblUnitName"));

                Label imgEdit = e.Row.FindControl("imgEdit") as Label;
                Image imgView = e.Row.FindControl("imgView") as Image;

                decimal LeftQuantity = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "LeftQuantity"));
                int RequiredQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RequiredQty"));
                decimal ChallanQty = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalSendChallanQty"));
                int ContractQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ContractQty"));
                double Avg = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AccessoryAvg"));
                int Wastage = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Wastage"));
                string GarmentUnit = DataBinder.Eval(e.Row.DataItem, "GarmentUnitName").ToString();
                decimal StockQty = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "StockQty"));
                decimal DebitQty = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DebitQty"));
                DropDownList ddlFactoryUnit = ((DropDownList)this.grdAccessory.HeaderRow.FindControl("ddlFactoryUnit"));
                int Unitid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "unitid"));
                //  lblUnitName.Text = ddlFactoryUnit.SelectedItem.Text;
                string ToltipTxt = "";

                if (Wastage > 0)
                    ToltipTxt = "(" + ContractQty.ToString() + "<span style='position:relative;top:2px'> * </span>" + Avg.ToString() + ") / (100 - " + Wastage.ToString() + "%)";
                else
                    ToltipTxt = "(" + ContractQty.ToString() + "<span style='position:relative;top:2px'> * </span>" + Avg.ToString() + ")";

                if (lblQuantity.Text != "")
                    lblQuantity.Text = lblQuantity.Text + "<span style='color:gray;'>&nbsp;" + GarmentUnit + "</span>";

                string StockDebitQty = "";
                if (StockQty > 0)
                {
                    StockDebitQty = "Usable Stock Qty: <span style='color:black;'>" + StockQty.ToString() + "</span><span style='color:gray;'>&nbsp;" + GarmentUnit + "</span>";
                }
                if (DebitQty > 0)
                {
                    if (StockDebitQty != "")
                        StockDebitQty = StockDebitQty + "</br> Debit Qty: <span style='color:black;'>" + DebitQty.ToString() + "</span><span style='color:gray;'>&nbsp;" + GarmentUnit + "</span>";
                    else
                        StockDebitQty = "Debit Qty: <span style='color:black;'>" + DebitQty.ToString() + "</span><span style='color:gray;'>&nbsp;" + GarmentUnit + "</span>";
                }

                if (StockDebitQty != "")
                    lblStock_DebitQty.Text = StockDebitQty;

                if (lblTotalIssued.Text != "")
                    lblTotalIssued.Text = lblTotalIssued.Text + "<span style='color:gray;'>&nbsp;" + GarmentUnit + "</span>";

                if (lblReturnedQty.Text != "")
                    lblReturnedQty.Text = " (Returned: " + lblReturnedQty.Text + "<span style='color:gray;'>&nbsp;" + GarmentUnit + "</span>" + ")";


                if (lblTotalAccessoriesRequired.Text != "")
                {
                    lblTotalAccessoriesRequired.Text = lblTotalAccessoriesRequired.Text == "0" ? "" : Convert.ToInt32(lblTotalAccessoriesRequired.Text).ToString("N0");
                }
                if (lblAvailableQtyToIssue.Text != "")
                {
                    lblAvailableQtyToIssue.Text = lblAvailableQtyToIssue.Text == "0" ? "" : Convert.ToInt32(lblAvailableQtyToIssue.Text).ToString("N0");
                }
                if (lblRequiredQty.Text != "")
                {
                    lblRequiredQty.Text = lblRequiredQty.Text == "0" ? "" : Convert.ToDecimal(lblRequiredQty.Text).ToString("N0");
                    lblTooltip.Text = ToltipTxt;
                    lblTooltip.CssClass = "TooltipTxt";
                }

                if (lblTotalAccessoriesRequired.Text == "")
                {
                    Unit1.Text = "";
                }
                if (lblRequiredQty.Text == "")
                {
                    Unit3.Text = "";
                }
                if (Unitid > 0)
                {
                    //  ddlFactoryUnit.SelectedItem.Value = Unitid.ToString();

                    ddlFactoryUnit.Items.FindByValue(Unitid.ToString()).Selected = true;
                    lblUnitName.Text = ddlFactoryUnit.SelectedItem.Text;
                    ddlFactoryUnit.Enabled = false;
                }
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";

                string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                string ColorPrint = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();

                DateTime dtRequestDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "IssueRequestDate"));
                lblRequestDate.Text = dtRequestDate == DateTime.MinValue ? "" : dtRequestDate.ToString("dd MMM");

                DateTime dtIssueCompleteDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "IssueCompleteDate"));
                lblIssueCompleteDate.Text = dtIssueCompleteDate == DateTime.MinValue ? "" : dtIssueCompleteDate.ToString("dd MMM");

                if (hdnIssueRequest.Value == "1")
                    cbIssueRequest.Checked = true;
                if (hdnIssueComplete.Value == "1")
                    cbIssueComplete.Checked = true;
                
             
                string SerialNumber = ((Label)e.Row.FindControl("lblSerial")).Text;
                HiddenField hdnCanMakeNewChallan = (HiddenField)e.Row.FindControl("hdnCanMakeNewChallan");
                imgEdit.Attributes.Add("onclick", "CreateNewChallan('" + SerialNumber + "','" + hdnCanMakeNewChallan.Value + "')");

                Label lblSerial = ((Label)e.Row.FindControl("lblSerial"));
               
                if (dt !=null)
                 {
                    if (dt.Rows.Count > 0)
                    {
                        Repeater rpt = (Repeater)e.Row.FindControl("rpt1");
                        rpt.DataSource = dt;
                        rpt.DataBind();
                    }             
                 }
                if (IssueRequestedDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    if (hdnIssueRequest.Value == "1")
                    {
                        imgEdit.Visible = true;
                        cbIssueComplete.Enabled = true;
                        if (hdnIssueComplete.Value == "1")
                            cbIssueComplete.Enabled = false;

                        //if (RequiredQty > 0 && !cbIssueComplete.Checked)
                        //{
                        //    imgEdit.Style.Add("display", "");
                        //    imgEdit.Attributes.Add("onclick", "CreateNewChallan('" + hdnOrderDetailId.Value + "','" + hdnAccessoryMasterId.Value + "','" + ColorPrint + "','" + Size + "'," + LeftQuantity + ")");
                        //}
                    }
                }
                //if (ChallanQty > 0)
                //{
                //    imgView.Style.Add("display", "");
                //    imgView.Attributes.Add("onclick", "GetAllChallan('" + hdnOrderDetailId.Value + "','" + hdnAccessoryMasterId.Value + "','" + Size + "','" + ColorPrint + "'," + LeftQuantity + ")");
                //}
                if (lblAvailableQtyToIssue.Text == "")
                {
                    Unit2.Text = "";
                    cbIssueComplete.Enabled = false;
                }

              
            }
        }

        protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdnSerialNumber = (HiddenField)e.Item.FindControl("hdnSerialNumber");
            string SerialNumber = hdnSerialNumber.Value;

            HtmlGenericControl tdChallanNumber = (HtmlGenericControl)e.Item.FindControl("tdChallanNumber");
           string ChallanNumber= tdChallanNumber.InnerText;

           HiddenField hdnflagOption = (HiddenField)e.Item.FindControl("hdnflagOption");
           string flagoption = hdnflagOption.Value;

           HiddenField hdnColor = (HiddenField)e.Item.FindControl("hdnColor");

           tdChallanNumber.Attributes.Add("onclick", "OpenChallan('" + ChallanNumber + "','" + flagoption + "','" + SerialNumber + "')");
           tdChallanNumber.Attributes.Add("style", "cursor:pointer;color:" + hdnColor.Value + ";");


        }

        protected void grdAccessory_DataBound(object sender, EventArgs e)
        {
            for (int i = grdAccessory.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdAccessory.Rows[i];
                GridViewRow previousRow = grdAccessory.Rows[i - 1];

                Label lblStyleNumber = (Label)row.Cells[0].FindControl("lblStyleNumber");
                Label lblPreviousStyleNumber = (Label)previousRow.Cells[0].FindControl("lblStyleNumber");
                Label lblSerial = (Label)row.Cells[1].FindControl("lblSerial");
                Label lblPreviousSerial = (Label)previousRow.Cells[1].FindControl("lblSerial");

                if (lblStyleNumber.Text == lblPreviousStyleNumber.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                            previousRow.Cells[8].RowSpan += 2;

                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                            previousRow.Cells[8].RowSpan = row.Cells[0].RowSpan + 1;

                        }
                        row.Cells[0].Visible = false;
                        row.Cells[8].Visible = false;
                    }
                }
                if (lblSerial.Text == lblPreviousSerial.Text)
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
                        if (row.Cells[1].RowSpan == 0)
                        {
                            previousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                        }
                        row.Cells[1].Visible = false;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            int iSave = 0;
            if (grdAccessory.Rows.Count > 0)
            {
                GridViewRow gvrHdr = grdAccessory.HeaderRow;
                CheckBox chkRaiseReuestAll = (CheckBox)gvrHdr.FindControl("chkRaiseReuestAll");
                DropDownList ddlFactoryUnit = ((DropDownList)gvrHdr.FindControl("ddlFactoryUnit"));
                foreach (GridViewRow gvr in grdAccessory.Rows)
                {
                    AccessoryQualityIssuing accessoryIssuing = new AccessoryQualityIssuing();

                    HiddenField hdnOrderId = (HiddenField)gvr.FindControl("hdnOrderId");
                    HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnOrderDetailId");
                    HiddenField hdnAccessoryMasterId = (HiddenField)gvr.FindControl("hdnAccessoryMasterId");
                    CheckBox cbIssueRequest = (CheckBox)gvr.FindControl("cbIssueRequest");
                    CheckBox cbIssueComplete = (CheckBox)gvr.FindControl("cbIssueComplete");
                    Label lblColorPrint = (Label)gvr.FindControl("lblColorPrint");
                    HiddenField hdnAccessSize = (HiddenField)gvr.FindControl("hdnAccessSize");



                    accessoryIssuing.OrderId = Convert.ToInt32(hdnOrderId.Value);

                    accessoryIssuing.OrderDetailId = Convert.ToInt32(hdnOrderDetailId.Value);
                    accessoryIssuing.AccessoryMasterId = Convert.ToInt32(hdnAccessoryMasterId.Value);

                    if ((cbIssueRequest.Checked) && (chkRaiseReuestAll.Enabled))
                    {
                        accessoryIssuing.IsIssueRequest = 1;
                        accessoryIssuing.IssueRequestDate = DateTime.Now;
                    }

                    if ((cbIssueComplete.Checked) && (cbIssueComplete.Enabled))
                    {
                        accessoryIssuing.IsCompleteIssue = 1;
                        accessoryIssuing.IssueCompleteDate = DateTime.Now;
                    }


                    accessoryIssuing.Color_Print = lblColorPrint.Text;
                    accessoryIssuing.Size = hdnAccessSize.Value;
                    accessoryIssuing.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                    accessoryIssuing.Unitid = Convert.ToInt32(ddlFactoryUnit.SelectedItem.Value);

                    accessoryIssuing.IssueSheetId = objAccessoryWorking.GetIssueSheetId(Convert.ToInt32(hdnOrderDetailId.Value), Convert.ToInt32(hdnAccessoryMasterId.Value), lblColorPrint.Text, hdnAccessSize.Value);
                    iSave = objAccessoryWorking.SaveAccessoryInternalIssueSheet(accessoryIssuing);
                }
                if (iSave > 0)
                {
                    ShowAlert("Data has save successfully!");
                    //ddlFactoryUnit.Enabled = false;
                    //chkRaiseReuestAll.Checked = true;
                    //chkRaiseReuestAll.Enabled = false;
                }
                BindGrid();
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void MoveStockQty_Click(object sender, EventArgs e)
        {
            int iSave = 0;
            AccessoryQualityIssuing objQualityIssue = new AccessoryQualityIssuing();
            objQualityIssue.OrderDetailId = Convert.ToInt32(hdnBaseOrderDetailId.Value);
            objQualityIssue.AccessoryWorkingDetailId = Convert.ToInt32(hdnAccessoryWorkingDetailId.Value);
            objQualityIssue.AccessoryMasterId = Convert.ToInt32(hdnAccessoryMasterId.Value);
            objQualityIssue.Size = hdnSize.Value.Trim(new Char[] { '(', ')' });
            objQualityIssue.Color_Print = hdnColorPrint.Value;

            objQualityIssue.StockQty = txtStockqty.Text == "" ? 0 : Convert.ToDecimal(txtStockqty.Text);
            objQualityIssue.DebitQty = txtDebitqty.Text == "" ? 0 : Convert.ToDecimal(txtDebitqty.Text);
            objQualityIssue.DebitParticulars = txtParticular.Text;
            objQualityIssue.SupplyType = Convert.ToInt32(hdnSupplyType.Value);
            objQualityIssue.LeftQuantity = Convert.ToDecimal(hdnmoveqty.Value);
            objQualityIssue.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;

            iSave = objAccessoryWorking.SaveQtyLeftInStock(objQualityIssue);

            SelectedODID = 0;
            AccessoryMasterId = 0;
            Size = string.Empty;
            ColorPrint = string.Empty;
            SupplyType = 0;
            BindGrid();
            divmovestock.Style.Add("display", "none");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


    }
}