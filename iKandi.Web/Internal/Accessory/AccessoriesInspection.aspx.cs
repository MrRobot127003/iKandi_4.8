using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;


namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoriesInspection : System.Web.UI.Page
    {
        int SupplierPoId;
        int SrvId;
        int Status;
        int UnitId;
        static int TotalQuantitySRV;
        static string GarmentUnit;
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        AdminController adminController = new AdminController();
        static List<AccessoriesInspect> AccessoriesInspectionList = new List<AccessoriesInspect>();
        static List<int> DeletetedInspectionId = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SupplierPoId"] != null && Request.QueryString["SrvId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
                SrvId = Convert.ToInt32(Request.QueryString["SrvId"]);
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
                hdnSupplierPoId.Value = SupplierPoId.ToString();
            }
            if (Request.QueryString["Status"] != null)
            {
                Status = Convert.ToInt32(Request.QueryString["Status"]);
            }
            else
            {
                Status = 0;
            }

            if (!IsPostBack)
            {
                Bind();
                SetPermission();
            }
        }

        public void SetPermission()
        {
            //ChkAccessoryQA.Enabled = false;
            // ChkAccessoryGM.Enabled = false;

            //if (ApplicationHelper.LoggedInUser.UserData.UserID == 122)
            //{
            //    ChkAccessoryQA.Enabled = true;
            //    ChkAccessoryGM.Enabled = true;
            //}
        }

        private void Bind()
        {
            AccessoriesInspectionList.Clear();

            BindDDLUnit();

            DataSet ds = objAccessoryWorking.GetAccessoriesInspection(SupplierPoId, SrvId);
            DataTable dtAccessoriesInspection = ds.Tables[0];
            string AccessoryDetail = "";
            string Size = "";

            if (dtAccessoriesInspection.Rows.Count > 0)
            {                
                GarmentUnit = dtAccessoriesInspection.Rows[0]["UnitName"].ToString();
                AccessoryDetail = dtAccessoriesInspection.Rows[0]["AccessoryName"].ToString();
                Size = dtAccessoriesInspection.Rows[0]["Size"].ToString();
                lblAccessories.Text = "<span style='color:blue;'>" + AccessoryDetail + "</span><span style='color:gray;'> (" + Size + ")</span>";
                lblPrintCol.Text = dtAccessoriesInspection.Rows[0]["Color_Print"].ToString();
                lblSupplierName.Text = dtAccessoriesInspection.Rows[0]["SupplierName"].ToString();
                lblPO_No.Text = dtAccessoriesInspection.Rows[0]["PO_Number"].ToString();
                lblSrvNo.Text = "A-" + dtAccessoriesInspection.Rows[0]["SRV_Id"].ToString();
                txtCheckerName1.Text = dtAccessoriesInspection.Rows[0]["CheckerName1"].ToString();
                txtCheckerName2.Text = dtAccessoriesInspection.Rows[0]["CheckerName2"].ToString();

                if (dtAccessoriesInspection.Rows[0]["InspectionDate"].ToString() != string.Empty)
                {
                    txtDate.Text = Convert.ToDateTime(dtAccessoriesInspection.Rows[0]["InspectionDate"]).ToString("dd MMM yy");
                }
                else
                {
                    txtDate.Text = DateTime.Now.ToString("dd MMM yy");
                }

                Span1.InnerText = GarmentUnit;
                Span2.InnerText = GarmentUnit;
                Span3.InnerText = GarmentUnit;
                Span4.InnerText = GarmentUnit;
                Span5.InnerText = GarmentUnit; ;
                Span6.InnerText = Span6.InnerText + " (" + GarmentUnit + ")";
                txtTotalQuantity.Text = Convert.ToInt32(dtAccessoriesInspection.Rows[0]["TotalQuantity"]).ToString("N0");
                TotalQuantitySRV = Convert.ToInt32(dtAccessoriesInspection.Rows[0]["TotalQuantity"]);


                if (Convert.ToInt32(dtAccessoriesInspection.Rows[0]["UnitId"]) != 0)
                    ddlAllocatedUnit.SelectedValue = dtAccessoriesInspection.Rows[0]["UnitId"].ToString();
                else
                    ddlAllocatedUnit.SelectedValue = UnitId.ToString();

                hdnReceivedQty.Value = dtAccessoriesInspection.Rows[0]["Received"].ToString();
                txtReceived.Text = dtAccessoriesInspection.Rows[0]["Received"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["Received"]).ToString("N0");
                txtChecked.Text = dtAccessoriesInspection.Rows[0]["CheckedQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["CheckedQty"]).ToString("N0");
                txtPass.Text = dtAccessoriesInspection.Rows[0]["PassQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["PassQty"]).ToString("N0");
                txtHold.Text = dtAccessoriesInspection.Rows[0]["HoldQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["HoldQty"]).ToString("N0");
                txtFail.Text = dtAccessoriesInspection.Rows[0]["FailQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["FailQty"]).ToString("N0");                
                hdnpassqty.Value = dtAccessoriesInspection.Rows[0]["PassQty"].ToString() == string.Empty ? string.Empty : Convert.ToInt32(dtAccessoriesInspection.Rows[0]["PassQty"]).ToString();

                if (txtHold.Text != "")
                {
                    chkAccessoriesQA.Enabled=false;
                    chkAccessoriesGM.Enabled=false;
                }
                
                if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryQA"]) == true)
                {
                    divAccessoriesQA.Visible = false;
                    divSigAccessoriesQA.Visible = true;
                   
                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(dtAccessoriesInspection.Rows[0]["AccessoryQABy"]) == user.UserID)
                        {
                            lblAccessoriesQAName.Text = user.FirstName + " " + user.LastName;
                            imgAccessoriesQA.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblAccessoriesQADate.Text = Convert.ToDateTime(dtAccessoriesInspection.Rows[0]["AccessoryQADate"]).ToString("dd MMM yy (ddd)");
                        }
                    }
                }
                if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryQA"]) == true && Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryGM"]) == true) {
                    txtReceived.Attributes.Add("disabled", "disabled");
                    txtChecked.Attributes.Add("disabled", "disabled");
                    txtPass.Attributes.Add("disabled", "disabled");
                    txtHold.Attributes.Add("disabled", "disabled");
                    txtFail.Attributes.Add("disabled", "disabled");
                    txtComments.Attributes.Add("disabled", "disabled");
                    txtCheckerName1.Attributes.Add("disabled", "disabled");
                    txtCheckerName1.Attributes.Add("disabled", "disabled");
                   // btnSubmit.Visible = false;
                }

                if (Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryGM"]) == true)
                {
                    divAccessoriesGM.Visible = false;
                    divSigAccessoriesGM.Visible = true;
                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(dtAccessoriesInspection.Rows[0]["AccessoryGMBy"]) == user.UserID)
                        {
                            lblAccessoriesGMName.Text = user.FirstName + " " + user.LastName;
                            imgAccessoriesGM.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblAccessoriesGMDate.Text = dtAccessoriesInspection.Rows[0]["AccessoryGMDate"] != System.DBNull.Value ? Convert.ToDateTime(dtAccessoriesInspection.Rows[0]["AccessoryGMDate"]).ToString("dd MMM yy (ddd)") : string.Empty;
                        }
                    }
                }
                // ChkAccessoryQA.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryQA"]);
                // ChkAccessoryGM.Checked = Convert.ToBoolean(dtAccessoriesInspection.Rows[0]["IsAccessoryGM"]);
            }

            if (ds.Tables.Count > 1)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    AccessoriesInspect accessoriesInspect = new AccessoriesInspect();

                    accessoriesInspect.BoxNo = Convert.ToInt32(ds.Tables[1].Rows[i]["BoxNo"]);
                    if (ds.Tables[1].Rows[i]["DieLot"] != System.DBNull.Value)
                        accessoriesInspect.DieLot = Convert.ToInt32(ds.Tables[1].Rows[i]["DieLot"]);
                    //added on 07 Jan 2021 start
                    if (ds.Tables[1].Rows[i]["ClaimedQty"] != System.DBNull.Value)
                        accessoriesInspect.ClaimedLength = Convert.ToInt32(ds.Tables[1].Rows[i]["ClaimedQty"]);
                    //added on 07 Jan 2021 end
                    if (ds.Tables[1].Rows[i]["ActLength"] != System.DBNull.Value)
                        accessoriesInspect.ActLength = Convert.ToInt32(ds.Tables[1].Rows[i]["ActLength"]);
                    if (ds.Tables[1].Rows[i]["PassQty"] != System.DBNull.Value)
                        accessoriesInspect.PassQty = Convert.ToInt32(ds.Tables[1].Rows[i]["PassQty"]);
                    if (ds.Tables[1].Rows[i]["CheckedQty"] != System.DBNull.Value)
                        accessoriesInspect.CheckedQty = Convert.ToInt32(ds.Tables[1].Rows[i]["CheckedQty"]);
                    if (ds.Tables[1].Rows[i]["FailQty"] != System.DBNull.Value)
                        accessoriesInspect.FailQty = Convert.ToInt32(ds.Tables[1].Rows[i]["FailQty"]);
                    if (ds.Tables[1].Rows[i]["Decision"] != System.DBNull.Value)                    
                        accessoriesInspect.Decision = ds.Tables[1].Rows[i]["Decision"].ToString();                    
                    
                    accessoriesInspect.CreatedBy = Convert.ToInt32(ds.Tables[1].Rows[i]["CreatedBy"]);
                    accessoriesInspect.Inspection_Id = Convert.ToInt32(ds.Tables[1].Rows[i]["Inspection_Id"]);
                    accessoriesInspect.InspectionParticular_Id = Convert.ToInt32(ds.Tables[1].Rows[i]["InspectionParticular_Id"]);

                    AccessoriesInspectionList.Add(accessoriesInspect);
                }
                DataTable dtAccessoryInspecParticular = ds.Tables[1];
                grv_Accessories_Inspection.DataSource = dtAccessoryInspecParticular;
                grv_Accessories_Inspection.DataBind();
                int total = AccessoriesInspectionList.Sum(item => item.ActLength);
                int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

                lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
                if (total < TotalQuantitySRV)
                {
                    tdTotalPcs.Style.Add("background-color", "#FDFD96;");
                }
                else if (total > TotalQuantitySRV)
                {
                    tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
                }               

                if (ds.Tables.Count > 2)
                {
                    DataTable dtComment = ds.Tables[2];
                    for (int iComment = 0; iComment < dtComment.Rows.Count; iComment++)
                    {
                        dvHistory.InnerHtml = dvHistory.InnerHtml + "<li>" + dtComment.Rows[iComment]["DetailDescription"].ToString() + "</li>";
                    }
                }
            }
            else
            {
                grv_Accessories_Inspection.DataSource = null;
                grv_Accessories_Inspection.DataBind();
            }

            if ((Status == 1) || (Status == 2))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
                btnSubmit.Visible = false;
            }
        }

        private void BindDDLUnit()
        {
            DataSet ds = adminController.GetAllUnit();
            DataTable dt = ds.Tables[0];
            ddlAllocatedUnit.DataSource = dt;
            ddlAllocatedUnit.DataTextField = "UnitName";
            ddlAllocatedUnit.DataValueField = "Id";
            ddlAllocatedUnit.DataBind();
            ddlAllocatedUnit.Items.Insert(0, new ListItem("Select", "-1"));
        }

        protected void grv_Accessories_Inspection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblLengthHdr = (Label)e.Row.FindControl("lblLengthHdr");
                lblLengthHdr.Text = "Act Length/" + GarmentUnit;

                Label lblClaimedLengthHeader = (Label)e.Row.FindControl("lblClaimedLengthHeader");  //new line
                lblClaimedLengthHeader.Text = "Claimed Length";                                     //new line
                
            }
            if (e.Row.RowState == DataControlRowState.Edit && (e.Row.RowIndex < AccessoriesInspectionList.Count()))
            {
                AccessoriesInspect ss = AccessoriesInspectionList[e.Row.RowIndex];

                RadioButton rbtPassEdit = (RadioButton)e.Row.FindControl("rbtPass");
                RadioButton rbtFailEdit = (RadioButton)e.Row.FindControl("rbtFail");
                TextBox txtDeiLot = (TextBox)e.Row.FindControl("txtDeiLot");
                TextBox txtClaimedLength_Edit = (TextBox)e.Row.FindControl("txtClaimedLength_Edit");  //new line
                TextBox txtActLength = (TextBox)e.Row.FindControl("txtActLength");
                TextBox txtChecked = (TextBox)e.Row.FindControl("txtChecked");
                TextBox txtPass = (TextBox)e.Row.FindControl("txtPass");
                TextBox txtFail = (TextBox)e.Row.FindControl("txtFail");

                txtDeiLot.Text = ss.DieLot == 0 ? "" : ss.DieLot.ToString();
                txtClaimedLength_Edit.Text = ss.ClaimedLength == 0 ? "" : ss.ClaimedLength.ToString();   //new line
                txtActLength.Text = ss.ActLength == 0 ? "" : ss.ActLength.ToString();
                txtChecked.Text = ss.CheckedQty == 0 ? "" : ss.CheckedQty.ToString();
                txtPass.Text = ss.PassQty == 0 ? "" : ss.PassQty.ToString();
                txtFail.Text = ss.FailQty == 0 ? "" : ss.FailQty.ToString();

                if (ss.Decision == "1")
                {
                    rbtPassEdit.Checked = true;
                }
                if (ss.Decision == "0")
                {
                    rbtFailEdit.Checked = true;
                }
               
            }

            else if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) && (e.Row.RowIndex < AccessoriesInspectionList.Count()))
            {
                AccessoriesInspect ss = AccessoriesInspectionList[e.Row.RowIndex];

                RadioButton rbtPassEdit = (RadioButton)e.Row.FindControl("rbtPass");
                RadioButton rbtFailEdit = (RadioButton)e.Row.FindControl("rbtFail");
                TextBox txtDeiLot = (TextBox)e.Row.FindControl("txtDeiLot");
                TextBox txtClaimedLength_Edit = (TextBox)e.Row.FindControl("txtClaimedLength_Edit");  //new line
                TextBox txtActLength = (TextBox)e.Row.FindControl("txtActLength");
                TextBox txtChecked = (TextBox)e.Row.FindControl("txtChecked");
                TextBox txtPass = (TextBox)e.Row.FindControl("txtPass");
                TextBox txtFail = (TextBox)e.Row.FindControl("txtFail");

                txtDeiLot.Text = ss.DieLot == 0 ? "" : ss.DieLot.ToString();
                txtClaimedLength_Edit.Text = ss.ClaimedLength == 0 ? "" : ss.ClaimedLength.ToString();   //new line
                txtActLength.Text = ss.ActLength == 0 ? "" : ss.ActLength.ToString();
                txtChecked.Text = ss.CheckedQty == 0 ? "" : ss.CheckedQty.ToString();
                txtPass.Text = ss.PassQty == 0 ? "" : ss.PassQty.ToString();
                txtFail.Text = ss.FailQty == 0 ? "" : ss.FailQty.ToString();

                if (ss.Decision == "1")
                {
                    rbtPassEdit.Checked = true;
                }
                if (ss.Decision == "0")
                {
                    rbtFailEdit.Checked = true;
                }
                

            }

            else if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate))
            {
                if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowIndex < AccessoriesInspectionList.Count()))
                {
                    AccessoriesInspect ss = AccessoriesInspectionList[e.Row.RowIndex];

                    RadioButton rbtPass = (RadioButton)e.Row.FindControl("rbtPass");
                    RadioButton rbtFail = (RadioButton)e.Row.FindControl("rbtFail");
                    Label lblDeiLot = (Label)e.Row.FindControl("lblDeiLot");
                    Label lblClaimedLength = (Label)e.Row.FindControl("lblClaimedLength");  //new line
                    Label lblActLength = (Label)e.Row.FindControl("lblActLength");
                    Label lblChecked = (Label)e.Row.FindControl("lblChecked");
                    Label lblPass = (Label)e.Row.FindControl("lblPass");
                    Label lblFail = (Label)e.Row.FindControl("lblFail");

                    lblDeiLot.Text = ss.DieLot == 0 ? "" : ss.DieLot.ToString("N0");
                    lblClaimedLength.Text = ss.ClaimedLength == 0 ? "" : ss.ClaimedLength.ToString("N0");   //new line
                    lblActLength.Text = ss.ActLength == 0 ? "" : ss.ActLength.ToString("N0");
                    lblChecked.Text = ss.CheckedQty == 0 ? "" : ss.CheckedQty.ToString("N0");
                    lblPass.Text = ss.PassQty == 0 ? "" : ss.PassQty.ToString("N0");
                    lblFail.Text = ss.FailQty == 0 ? "" : ss.FailQty.ToString("N0");

                    decimal claimedValue = lblClaimedLength.Text != string.Empty ? Convert.ToDecimal(lblClaimedLength.Text) : 0;
                    decimal actualValue = lblActLength.Text != string.Empty ? Convert.ToDecimal(lblActLength.Text) : 0;
                    if (claimedValue < actualValue)
                    {
                        e.Row.Cells[3].Attributes.Add("style", "background-color:#FFB7B2");
                    }
                    else if (claimedValue > actualValue)
                    {
                        e.Row.Cells[3].Attributes.Add("style", "background-color:#FDFD96");
                    }
                    else
                    {
                        e.Row.Cells[3].Attributes.Add("style", "background-color:#fff");
                    }

                    if (ss.Decision == "1")
                    {
                        rbtPass.Checked = true;
                    }
                    if (ss.Decision == "0")
                    {
                        rbtFail.Checked = true;
                    }                   
                }
            }
        }
        
        protected void grv_Accessories_Inspection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEmpty")
            {
                Table tblgvDetail = (Table)grv_Accessories_Inspection.Controls[0];
                GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];

                ImageButton btnAdd_Empty = (ImageButton)rows.FindControl("btnAdd_Empty");
                btnAdd_Empty.Attributes.Add("display", "none");

                TextBox txtRollNo_Empty = (TextBox)rows.FindControl("txtRollNo_Empty");
                TextBox txtDeiLot_Empty = (TextBox)rows.FindControl("txtDeiLot_Empty");
                TextBox txtClaimedLength_Empty = (TextBox)rows.FindControl("txtClaimedLength_Empty");   //new line
                TextBox txtActLength_Empty = (TextBox)rows.FindControl("txtActLength_Empty");
                TextBox txtPass_Empty = (TextBox)rows.FindControl("txtPass_Empty");
                TextBox txtChecked_Empty = (TextBox)rows.FindControl("txtChecked_Empty");
                TextBox txtFail_Empty = (TextBox)rows.FindControl("txtFail_Empty");
                RadioButton rbtPass_Empty = (RadioButton)rows.FindControl("rbtPass_Empty");
                RadioButton rbtFail_Empty = (RadioButton)rows.FindControl("rbtFail_Empty");

                if (txtRollNo_Empty.Text == string.Empty)
                {
                    ShowAlert("Roll/Box No. cannot blank!");
                    return;
                }
                if (txtDeiLot_Empty.Text == string.Empty)
                {
                    ShowAlert("Dye Lot cannot blank!");
                    return;
                }
                //new code start
                if (txtClaimedLength_Empty.Text == string.Empty)
                {
                    ShowAlert("Claimed Length cannot blank!");
                    return;
                }
                //new code end
                if (txtActLength_Empty.Text == string.Empty)
                {
                    ShowAlert("Actual Length cannot blank!");
                    return;
                }
                if (txtChecked_Empty.Text == string.Empty)
                {
                    ShowAlert("Checked Quantity cannot blank!");
                    return;
                }
                if (Convert.ToInt32(txtChecked_Empty.Text) > Convert.ToInt32(txtActLength_Empty.Text))
                {
                    ShowAlert("Checked Quantity cannot greater than Actual Length!");
                    return;
                }
                int passQty = txtPass_Empty.Text == string.Empty ? 0 : Convert.ToInt32(txtPass_Empty.Text);
                int failQty = txtFail_Empty.Text == string.Empty ? 0 : Convert.ToInt32(txtFail_Empty.Text);
                int checkedQty = txtChecked_Empty.Text == string.Empty ? 0 : Convert.ToInt32(txtChecked_Empty.Text);
                if (passQty + failQty != checkedQty)
                {
                    ShowAlert("(Pass + Fail) Quantity should be equal Checked Quantity!");
                    return;
                }

                AccessoriesInspect accessoriesInspection = new AccessoriesInspect();

                accessoriesInspection.BoxNo = Convert.ToInt32(txtRollNo_Empty.Text);
                if (txtDeiLot_Empty.Text != string.Empty)
                    accessoriesInspection.DieLot = Convert.ToInt32(txtDeiLot_Empty.Text);
                //new code start
                if (txtClaimedLength_Empty.Text != string.Empty)
                    accessoriesInspection.ClaimedLength = Convert.ToInt32(txtClaimedLength_Empty.Text);
                //new code end
                if (txtActLength_Empty.Text != string.Empty)
                    accessoriesInspection.ActLength = Convert.ToInt32(txtActLength_Empty.Text);
                if (txtPass_Empty.Text != string.Empty)
                    accessoriesInspection.PassQty = Convert.ToInt32(txtPass_Empty.Text);
                if (txtChecked_Empty.Text != string.Empty)
                    accessoriesInspection.CheckedQty = Convert.ToInt32(txtChecked_Empty.Text);
                if (txtFail_Empty.Text != string.Empty)
                    accessoriesInspection.FailQty = Convert.ToInt32(txtFail_Empty.Text);
                if (rbtPass_Empty.Checked == true || rbtFail_Empty.Checked == true)
                    accessoriesInspection.Decision = rbtPass_Empty.Checked ? "1" : "0";
                accessoriesInspection.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                AccessoriesInspectionList.Add(accessoriesInspection);
                grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
                grv_Accessories_Inspection.DataBind();
            }
            if (e.CommandName == "AddFooter")
            {
                ImageButton btnAdd_Footer = (ImageButton)grv_Accessories_Inspection.FooterRow.FindControl("btnAdd_Footer");
                btnAdd_Footer.Attributes.Add("display", "none");

                AccessoriesInspectionList.Clear();                
                int TotalActualLength=0;
                for (int i = 0; i < grv_Accessories_Inspection.Rows.Count; i++)
                {
                    AccessoriesInspect accessoriesInspection = new AccessoriesInspect();

                    Label lblRollNo = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblRollNo");
                    Label lblDeiLot = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblDeiLot");
                    Label lblClaimedLength = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblClaimedLength"); //new line
                    Label lblActLength = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblActLength");
                    Label lblPass = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblPass");
                    Label lblChecked = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblChecked");
                    Label lblFail = (Label)grv_Accessories_Inspection.Rows[i].FindControl("lblFail");
                    RadioButton rbtPass = (RadioButton)grv_Accessories_Inspection.Rows[i].FindControl("rbtPass");
                    RadioButton rbtFail = (RadioButton)grv_Accessories_Inspection.Rows[i].FindControl("rbtFail");
                    HiddenField hdnId = (HiddenField)grv_Accessories_Inspection.Rows[i].FindControl("hdnId");                   
                   

                    if (lblRollNo.Text != string.Empty)
                        accessoriesInspection.BoxNo = Convert.ToInt32(lblRollNo.Text);
                    if (lblDeiLot.Text != string.Empty)
                        accessoriesInspection.DieLot = Convert.ToInt32(lblDeiLot.Text.Replace(",",""));
                    //new code start
                    if (lblClaimedLength.Text != string.Empty)
                        accessoriesInspection.ClaimedLength = Convert.ToInt32(lblClaimedLength.Text.Replace(",", ""));
                    //new code end
                    if (lblActLength.Text != string.Empty)
                        accessoriesInspection.ActLength = Convert.ToInt32(lblActLength.Text.Replace(",", ""));
                    if (lblPass.Text != string.Empty)
                        accessoriesInspection.PassQty = Convert.ToInt32(lblPass.Text.Replace(",", ""));
                    if (lblChecked.Text != string.Empty)
                        accessoriesInspection.CheckedQty = Convert.ToInt32(lblChecked.Text.Replace(",", ""));
                    if (lblFail.Text != string.Empty)
                        accessoriesInspection.FailQty = Convert.ToInt32(lblFail.Text.Replace(",", ""));
                    if (rbtPass.Checked == true || rbtFail.Checked == true)
                        accessoriesInspection.Decision = rbtPass.Checked ? "1" : "0";
                    accessoriesInspection.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                    accessoriesInspection.InspectionParticular_Id = Convert.ToInt32(hdnId.Value);
                    
                    if (txtTotalQuantity.Text != string.Empty)
                        TotalQuantitySRV = Convert.ToInt32(txtTotalQuantity.Text.Replace(",", ""));
                    TotalActualLength = accessoriesInspection.ActLength + TotalActualLength;
                    hdnTotalQuantity.Value = TotalActualLength.ToString();

                    AccessoriesInspectionList.Add(accessoriesInspection);

                    //if (TotalActualLength > TotalQuantitySRV)
                    //{                        
                    //    ShowAlert("Actual length cannot greater than Total Quantity");
                    //}
                    //else
                    //{
                    //    AccessoriesInspectionList.Add(accessoriesInspection);
                    //}                    
                }

                AccessoriesInspect accessoriesInspectionFooter = new AccessoriesInspect();

                TextBox txtRollNo_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtRollNo_Footer");
                TextBox txtDeiLot_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtDeiLot_Footer");
                TextBox txtClaimedLength_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtClaimedLength_Footer"); //new line
                TextBox txtActLength_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtActLength_Footer");
                TextBox txtPass_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtPass_Footer");
                TextBox txtChecked_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtChecked_Footer");
                TextBox txtFail_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtFail_Footer");
                RadioButton rbtPass_Footer = (RadioButton)grv_Accessories_Inspection.FooterRow.FindControl("rbtPass_Footer");
                RadioButton rbtFail_Footer = (RadioButton)grv_Accessories_Inspection.FooterRow.FindControl("rbtFail_Footer");

                if (txtRollNo_Footer.Text == string.Empty)
                {
                    ShowAlert("Roll/Box No. cannot blank!");
                    return;
                }
                if (txtDeiLot_Footer.Text == string.Empty)
                {
                    ShowAlert("Dyed Lot cannot blank!");
                    return;
                }
                //new code start
                if (txtClaimedLength_Footer.Text == string.Empty)
                {
                    ShowAlert("Claimed Length cannot blank!");
                    return;
                }
                //new code end
                if (txtActLength_Footer.Text == string.Empty)
                {
                    ShowAlert("Actual Length cannot blank!");
                    return;
                }
                if (txtChecked_Footer.Text == string.Empty)
                {
                    ShowAlert("Checked Quantity cannot blank!");
                    return;
                }
                if (Convert.ToInt32(txtChecked_Footer.Text) > Convert.ToInt32(txtActLength_Footer.Text))
                {
                    ShowAlert("Checked Quantity cannot greater than Actual Length!");
                    return;
                }
                int passQty = txtPass_Footer.Text == string.Empty ? 0 : Convert.ToInt32(txtPass_Footer.Text);
                int failQty = txtFail_Footer.Text == string.Empty ? 0 : Convert.ToInt32(txtFail_Footer.Text);
                int checkedQty = txtChecked_Footer.Text == string.Empty ? 0 : Convert.ToInt32(txtChecked_Footer.Text);
                if (passQty + failQty != checkedQty)
                {
                    ShowAlert("(Pass + Fail) Quantity should be equal to Checked Quantity!");
                    return;
                }

                accessoriesInspectionFooter.BoxNo = Convert.ToInt32(txtRollNo_Footer.Text);               

                if (txtDeiLot_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.DieLot = Convert.ToInt32(txtDeiLot_Footer.Text);
                //new code start
                if (txtClaimedLength_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.ClaimedLength = Convert.ToInt32(txtClaimedLength_Footer.Text);
                //new code end
                if (txtActLength_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.ActLength = Convert.ToInt32(txtActLength_Footer.Text);
                if (txtPass_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.PassQty = Convert.ToInt32(txtPass_Footer.Text);
                if (txtChecked_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.CheckedQty = Convert.ToInt32(txtChecked_Footer.Text);
                if (txtFail_Footer.Text != string.Empty)
                    accessoriesInspectionFooter.FailQty = Convert.ToInt32(txtFail_Footer.Text);
                if (rbtPass_Footer.Checked == true || rbtFail_Footer.Checked == true)
                    accessoriesInspectionFooter.Decision = rbtPass_Footer.Checked ? "1" : "0";
                accessoriesInspectionFooter.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                AccessoriesInspectionList.Add(accessoriesInspectionFooter);
                
                //if (TotalActualLength > TotalQuantitySRV)
                //{                
                //    ShowAlert("Actual length can not greater than Total Quantity, You need to revise SRV Quantity");
                //}
                //else
                //{
                //    AccessoriesInspectionList.Add(accessoriesInspectionFooter);
                //}
                
                grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
                grv_Accessories_Inspection.DataBind();

                btnAdd_Footer.Attributes.Add("display", "");

            }
            int total = AccessoriesInspectionList.Sum(item => item.ActLength);
            int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

            lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
            if (total < TotalQuantitySRV)
            {
                tdTotalPcs.Style.Add("background-color", "#FDFD96;");
            }
            else if (total > TotalQuantitySRV)
            {
                tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
            }
           
        }

        protected void grv_Accessories_Inspection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex < AccessoriesInspectionList.Count())
            {
                AccessoriesInspect ai = AccessoriesInspectionList[e.RowIndex];

                DeletetedInspectionId.Add(ai.InspectionParticular_Id);
                AccessoriesInspectionList.RemoveAt(e.RowIndex);
                grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
                grv_Accessories_Inspection.DataBind();
                int total = AccessoriesInspectionList.Sum(item => item.ActLength);
                int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

                lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
                if (total < TotalQuantitySRV)
                {
                    tdTotalPcs.Style.Add("background-color", "#FDFD96;");
                }
                else if (total > TotalQuantitySRV)
                {
                    tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
                }
     
            }
        }       

        protected void grv_Accessories_Inspection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grv_Accessories_Inspection.EditIndex = e.NewEditIndex;
            grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
            grv_Accessories_Inspection.DataBind();
            grv_Accessories_Inspection.FooterRow.Visible = false;
        }

        protected void grv_Accessories_Inspection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int TotalActualLength = 0;
            GridViewRow row = grv_Accessories_Inspection.Rows[e.RowIndex];

            AccessoriesInspect accessoriesInspection = new AccessoriesInspect();
            HiddenField hdnParticularId = (HiddenField)row.FindControl("hdnParticularId");
            TextBox txtRollNo = (TextBox)row.FindControl("txtRollNo");
            TextBox txtDeiLot = (TextBox)row.FindControl("txtDeiLot");
            TextBox txtClaimedLength_Edit = (TextBox)row.FindControl("txtClaimedLength_Edit");    //new line
            TextBox txtActLength = (TextBox)row.FindControl("txtActLength");
            TextBox txtPass = (TextBox)row.FindControl("txtPass");
            TextBox txtChecked = (TextBox)row.FindControl("txtChecked");
            TextBox txtFail = (TextBox)row.FindControl("txtFail");
            RadioButton rbtPassEdit = (RadioButton)row.FindControl("rbtPass");
            RadioButton rbtFailEdit = (RadioButton)row.FindControl("rbtFail");

            if (hdnParticularId != null)
                accessoriesInspection.InspectionParticular_Id = Convert.ToInt32(hdnParticularId.Value);

            if (txtRollNo.Text != string.Empty)
                accessoriesInspection.BoxNo = Convert.ToInt32(txtRollNo.Text);
            if (txtDeiLot.Text != string.Empty)
                accessoriesInspection.DieLot = Convert.ToInt32(txtDeiLot.Text.Replace(",", ""));
            //new code start
            if (txtClaimedLength_Edit.Text != string.Empty)
                accessoriesInspection.ClaimedLength = Convert.ToInt32(txtClaimedLength_Edit.Text.Replace(",", ""));
            //new code end
            if (txtActLength.Text != string.Empty)
                accessoriesInspection.ActLength = Convert.ToInt32(txtActLength.Text.Replace(",", ""));
            if (txtPass.Text != string.Empty)
                accessoriesInspection.PassQty = Convert.ToInt32(txtPass.Text.Replace(",", ""));
            if (txtChecked.Text != string.Empty)
                accessoriesInspection.CheckedQty = Convert.ToInt32(txtChecked.Text.Replace(",", ""));
            if (txtFail.Text != string.Empty)
                accessoriesInspection.FailQty = Convert.ToInt32(txtFail.Text.Replace(",", ""));
            if (rbtPassEdit.Checked == true || rbtFailEdit.Checked == true)
                accessoriesInspection.Decision = rbtPassEdit.Checked ? "1" : "0";
            accessoriesInspection.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            int passQty = txtPass.Text == string.Empty ? 0 : Convert.ToInt32(txtPass.Text.Replace(",", ""));
            int failQty = txtFail.Text == string.Empty ? 0 : Convert.ToInt32(txtFail.Text.Replace(",", ""));
            int checkedQty = txtChecked.Text == string.Empty ? 0 : Convert.ToInt32(txtChecked.Text.Replace(",", ""));

            if (txtRollNo.Text == string.Empty)
            {
                ShowAlert("Roll/Box No. cannot blank!");
                return;
            }
            if (txtDeiLot.Text == string.Empty)
            {
                ShowAlert("Dyed Lot cannot blank!");
                return;
            }

            //new code start
            if (txtClaimedLength_Edit.Text == string.Empty)
            {
                ShowAlert("Claimed Length cannot blank!");
                return;
            }
            //new code end

            if (txtActLength.Text == string.Empty)
            {
                ShowAlert("Actual Length cannot blank!");
                return;
            }
            if (txtChecked.Text == string.Empty)
            {
                ShowAlert("Checked Quantity cannot blank!");
                return;
            }
            if (Convert.ToInt32(txtChecked.Text.Replace(",", "")) > Convert.ToInt32(txtActLength.Text.Replace(",", "")))
            {
                ShowAlert("Checked Quantity cannot greater than Actual Length!");
                return;
            }
            if (passQty + failQty != checkedQty)
            {
                ShowAlert("(Pass + Fail) Quantity should be equal Checked Quantity!");
                return;
            }

            AccessoriesInspectionList.RemoveAt(e.RowIndex);
            AccessoriesInspectionList.Insert(e.RowIndex, accessoriesInspection);

            //if (txtTotalQuantity.Text != string.Empty)
            //    TotalQuantitySRV = Convert.ToInt32(txtTotalQuantity.Text.Replace(",", ""));

            //TotalActualLength = accessoriesInspection.ActLength + Convert.ToInt32(hdnTotalQuantity.Value);
                   
            //if (TotalActualLength > TotalQuantitySRV)
            //{                
            //    ShowAlert("Actual length can not greater than Total Quantity, You need to revise SRV Quantity");
            //}
            //else
            //{
            //    AccessoriesInspectionList.RemoveAt(e.RowIndex);
            //    AccessoriesInspectionList.Insert(e.RowIndex, accessoriesInspection);
            //}
            
            grv_Accessories_Inspection.EditIndex = -1;
            grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
            grv_Accessories_Inspection.DataBind();

            int total = AccessoriesInspectionList.Sum(item => item.ActLength);
            int box = AccessoriesInspectionList.Sum(item => item.BoxNo);

            lblTotalPcs.Text = "<span><b>" + total.ToString("N0") + "</b></span><span class='txtColorGray'> " + GarmentUnit + "</span> (<b>" + box.ToString() + "</b>)";
            if (total < TotalQuantitySRV)
            {
                tdTotalPcs.Style.Add("background-color", "#FDFD96;");
            }
            else if (total > TotalQuantitySRV)
            {
                tdTotalPcs.Style.Add("background-color", "#FFB7B2;");
            }
            

        }

        protected void grv_Accessories_Inspection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grv_Accessories_Inspection.EditIndex = -1;
            grv_Accessories_Inspection.DataSource = AccessoriesInspectionList;
            grv_Accessories_Inspection.DataBind();
        }

        protected void BindGridView()
        {
            DataSet ds = objAccessoryWorking.GetAccessoriesInspection(SupplierPoId, SrvId);
            DataTable dtAccessoryInspecParticular = ds.Tables[1];
            grv_Accessories_Inspection.DataSource = dtAccessoryInspecParticular;
            grv_Accessories_Inspection.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AccessoriesInspectSystem accessoriesInspectSystem = new AccessoriesInspectSystem();

            accessoriesInspectSystem.SupplierPO_Id = SupplierPoId;
            accessoriesInspectSystem.SRV_Id = SrvId;
            if (txtCheckerName1.Text != string.Empty)
                accessoriesInspectSystem.CheckerName1 = txtCheckerName1.Text;
            accessoriesInspectSystem.CheckerName2 = txtCheckerName2.Text;
            accessoriesInspectSystem.Comments = txtComments.Text;
            accessoriesInspectSystem.CreatedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            if (txtChecked.Text != string.Empty)
                accessoriesInspectSystem.CheckedQty = Convert.ToInt32(txtChecked.Text.Replace(",", ""));
            if (txtFail.Text != string.Empty)
                accessoriesInspectSystem.FailQty = Convert.ToInt32(txtFail.Text.Replace(",", ""));
            if (txtHold.Text != string.Empty)
                accessoriesInspectSystem.HoldQty = Convert.ToInt32(txtHold.Text.Replace(",", ""));
            if (txtPass.Text != string.Empty)
                accessoriesInspectSystem.PassQty = Convert.ToInt32(txtPass.Text.Replace(",", ""));
            if (txtTotalQuantity.Text != string.Empty)
                accessoriesInspectSystem.TotalQty = Convert.ToInt32(txtTotalQuantity.Text.Replace(",", ""));
            if (txtReceived.Text != string.Empty)
                accessoriesInspectSystem.RecievedQty = Convert.ToInt32(txtReceived.Text.Replace(",", ""));
            if (ddlAllocatedUnit.SelectedValue != "-1")
                accessoriesInspectSystem.UnitId = Convert.ToInt32(ddlAllocatedUnit.SelectedValue);
            accessoriesInspectSystem.InspectionDate = Convert.ToDateTime(txtDate.Text);

            // Added by yadvendra  on 18/11/2019
            if (chkAccessoriesQA.Checked == true)
            {
                accessoriesInspectSystem.IsAccessoryQA = chkAccessoriesQA.Checked == true ? true : false;
            }
            if (chkAccessoriesGM.Checked == true)
            {
                accessoriesInspectSystem.IsAccessoryGM = chkAccessoriesGM.Checked == true ? true : false;
            }
            if (txtCheckerName1.Text == string.Empty)
            {
                ShowAlert("Checker Name First cannot blank!");
                return;
            }
            if (ddlAllocatedUnit.SelectedValue == "-1")
            {
                ShowAlert("Select Allocated Unit!");
                return;
            }
            if (txtReceived.Text == string.Empty)
            {
                ShowAlert("Received cannot blank!");
                return;
            }
            if (accessoriesInspectSystem.RecievedQty > accessoriesInspectSystem.TotalQty)
            {
                ShowAlert("Received quantities cannot greater than total quantity!");
                return;
            }
            if (txtChecked.Text == string.Empty)
            {
                ShowAlert("Checked cannot blank!");
                return;
            }
            if (accessoriesInspectSystem.CheckedQty > accessoriesInspectSystem.RecievedQty)
            {
                ShowAlert("Checked quantities cannot greater than received quantity!");
                return;
            }
            if ((accessoriesInspectSystem.PassQty + accessoriesInspectSystem.HoldQty + accessoriesInspectSystem.FailQty) > accessoriesInspectSystem.CheckedQty)
            {
                ShowAlert("(Pass + Fail + Hold) quantities cannot greater than checked quantity!");
                return;
            }

            if (DeletetedInspectionId.Count > 0)
            {
                for (int i = 0; i < DeletetedInspectionId.Count; i++)
                {
                    int id = DeletetedInspectionId[i];
                    objAccessoryWorking.DeleteInspectionParticular(id);
                }
                DeletetedInspectionId.Clear();
            }
            //added by yadvendra
            Table tblgvDetail = (Table)grv_Accessories_Inspection.Controls[0];
            GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];
            if (grv_Accessories_Inspection.Rows.Count == 0)
            {
                ImageButton btnAdd_Empty = (ImageButton)rows.FindControl("btnAdd_Empty");
                if (AccessoriesInspectionList.Count == 0)
                {
                    btnAdd_Empty.Focus();
                    return;
                }
            }
            if (grv_Accessories_Inspection.Rows.Count > 0)
            {
                ImageButton btnAdd_Footer = grv_Accessories_Inspection.FooterRow.FindControl("btnAdd_Footer") as ImageButton;
                TextBox txtRollNo_Footer = (TextBox)grv_Accessories_Inspection.FooterRow.FindControl("txtRollNo_Footer");
                if (txtRollNo_Footer.Text != string.Empty)
                {
                    btnAdd_Footer.Focus();
                    return;
                }
            }
            //End
            AccessoriesInspect objAccessoriesInspect = objAccessoryWorking.SaveAccessoriesInspection(accessoriesInspectSystem);

            if (AccessoriesInspectionList.Count > 0)
            {
                for (int i = 0; i < AccessoriesInspectionList.Count; i++)
                {
                    AccessoriesInspect accessoriesInspect = AccessoriesInspectionList[i];
                    accessoriesInspect.Inspection_Id = objAccessoriesInspect.Inspection_Id;
                    int InspectionParticularId = objAccessoryWorking.SaveInspectionParticular(accessoriesInspect);
                }
            }
            //objAccessoriesInspect.StockQty = 20;
            if (objAccessoriesInspect.StockQty > 0)
            {
                hdnInspectionId.Value = objAccessoriesInspect.Inspection_Id.ToString();
                hdnStockQty.Value = objAccessoriesInspect.StockQty.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "ShowDiv(" + objAccessoriesInspect.StockQty + ");", true);
                return;
            }

            BindGridView();

            if (objAccessoriesInspect.Inspection_Id > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }
}