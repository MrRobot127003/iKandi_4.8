using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Data;


namespace iKandi.Web.AccessoryPdfFile
{
    public partial class AccessoryInternalChallanPdf : System.Web.UI.Page
    {
        public string SerialNumber
        {
            get;
            set;
        }

        public string ChallanNumber
        {
            get;
            set;
        }

        public string flag
        {
            get;
            set;
        }

        public string flagOption
        {
            get;
            set;
        }

        public int SupplierPoId
        {
            get;
            set;
        }

        public int DebitNoteId
        {
            get;
            set;
        }
        public int ChallanId
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public int AccessoryMasterId
        {
            get;
            set;
        }
        public string Size
        {
            get;
            set;
        }
        public string ColorPrint
        {
            get;
            set;
        }
        public string ChallanType
        {
            get;
            set;
        }
        public int AvailableQty
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        string host = "";
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        AccessoryQualityController ObjAccessoryQlty = new AccessoryQualityController();
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            GetQueryString();
            BindProductionUnit();
            BindChallanProcess();
            BindData();
            DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress3");
            divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
        }

        private void GetQueryString()
        {
            if (Request.QueryString["flag"] != null)
                flag = Request.QueryString["flag"].ToString();
            else flag = "";

            if (Request.QueryString["flagOption"] != null)
                flagOption = Request.QueryString["flagOption"].ToString();
            else flagOption = "";

            if (Request.QueryString["SerialNumber"] != null)
                SerialNumber = Request.QueryString["SerialNumber"].ToString();
            else SerialNumber = "";

            if (Request.QueryString["ChallanNumber"] != null)
                ChallanNumber = Request.QueryString["ChallanNumber"].ToString();
            else ChallanNumber = "";


            if (Request.QueryString["SupplierPoId"] != null)            
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            
            else SupplierPoId = 165;
            
            if (Request.QueryString["DebitNoteId"] != null)            
                DebitNoteId = Convert.ToInt32(Request.QueryString["DebitNoteId"]);
            
            else DebitNoteId = 31;
            
            if (Request.QueryString["ChallanId"] != null)            
                ChallanId = Convert.ToInt32(Request.QueryString["ChallanId"]);
            
            else ChallanId = 1161;
            
            if (Request.QueryString["ChallanType"] != null)            
                ChallanType = Request.QueryString["ChallanType"].ToString();
            
            else ChallanType = "DEBITCHALLAN";
            
            if (Request.QueryString["OrderDetailId"] != null)            
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            
            else OrderDetailId = 0;
            
            if (Request.QueryString["AccessoryMasterId"] != null)            
                AccessoryMasterId = Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
            
            else AccessoryMasterId = 11;
            
            if (Request.QueryString["Size"] != null)            
                Size = Request.QueryString["Size"].ToString();
            
            else Size = "";
            
            if (Request.QueryString["ColorPrint"] != null)            
                ColorPrint = Request.QueryString["ColorPrint"].ToString();
            
            else ColorPrint = "";
            
            if (Request.QueryString["AvailableQty"] != null)            
                AvailableQty = Convert.ToInt32(Request.QueryString["AvailableQty"]);
            
            else AvailableQty = 0;
            
            if (Request.QueryString["UserId"] != null)            
                UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            
            else UserId = 0;

        }

        private void BindProductionUnit()
        {

            DataTable dt = ObjAccessoryQlty.Get_AccessoryProductionUnit();
            if (dt.Rows.Count > 0)
            {
                ddlProductionUnit.DataSource = dt;
                ddlProductionUnit.DataTextField = "UnitName";
                ddlProductionUnit.DataValueField = "Id";
                ddlProductionUnit.DataBind();
                ddlProductionUnit.Items.Insert(0, new ListItem("Select", "-1"));

            }
        }

        private void BindChallanProcess()
        {
            //List<ChallanProcess> ChallanProcessList = objAccessoryWorking.GetChallanProcessList(ChallanId);
            //chkProcess.DataSource = ChallanProcessList;
            //chkProcess.DataTextField = "ProcessName";
            //chkProcess.DataValueField = "ChallanProcessId";
            //chkProcess.DataBind();
            //for (int i = 0; i < chkProcess.Items.Count; i++)
            //{
            //    chkProcess.Items[i].Selected = ChallanProcessList[i].IsChecked;
            //}

            DataTable dt = objAccessoryWorking.GetChallanProcessListForPdf(ChallanId);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool ischecked = dt.Rows[i]["IsChecked"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[i]["IsChecked"]);
                if (ischecked)
                {
                    if (lblCheckedList.Text == "")
                    {
                        lblCheckedList.Text = dt.Rows[i]["ProcessName"] == DBNull.Value ? "" : dt.Rows[i]["ProcessName"].ToString();
                    }
                    else
                    {
                        lblCheckedList.Text = lblCheckedList.Text + ", " + (dt.Rows[i]["ProcessName"] == DBNull.Value ? "" : dt.Rows[i]["ProcessName"].ToString());
                    }

                }
            }


        }

        private void BindData()
        {
            boutiqueImg.ImageUrl = host + "/images/200x50 bipllog.png";

            if (ChallanType.ToLower() == "INTERNAL_CHALLAN".ToLower())
            {
                trPO.Visible = false;
                //gstt.Visible = false;
                //aaddress.Visible = false;
                //fabric_challan_rategst.Visible = false;

                DataTable dt = objAccessoryWorking.GetBasicDetailsForAccessoryInternalChallan(SerialNumber, ChallanNumber);

                lblChallan.Text = dt.Rows[0]["ChallanNumber"].ToString();
                lblChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"]).ToString("dd MMM yy (ddd)");               

                //foreach (ListItem item in chkProcess.Items)
                //{
                //    if (item.Text == "Cutting")
                //    {
                //        item.Selected = true;
                //        break;
                //    }
                //}

                ddlType.SelectedValue = "2";
                ddlType.Enabled = false;
                ddlProductionUnit.SelectedValue = dt.Rows[0]["UnitID"].ToString();
                lblStyleNo.Text = dt.Rows[0]["StyleNumber"].ToString();
                lblSerialNo.Text = dt.Rows[0]["SerialNumber"].ToString();

                if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]))
                {
                    chkAuthorised.Checked = true;
                    chkAuthorised.Enabled = false;
                    chkAuthorised.Visible = false;
                    divSigAuthorized.Visible = true;

                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["AuthorisedBy"]) == user.UserID)
                        {
                            //hdnAuthoriseIsChecked.Value = "1";
                            lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                            imgAuthorized.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblAuthorizedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["AuthorizedDate"]).ToString("dd MMM yy (ddd)");
                        }
                    }
                }
                if (Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                {
                    chkrecivegood.Checked = true;
                    chkrecivegood.Enabled = false;
                    chkrecivegood.Visible = false;
                    divSigReceive.Visible = true;

                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["ReceivedBy"]) == user.UserID)
                        {
                            //hdnReceiverIsChecked.Value = "1";
                            lblReceiverName.Text = user.FirstName + " " + user.LastName;
                            imgReceiver.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblReceivedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["ReceivedDate"]).ToString("dd MMM yy (ddd)");
                        }
                    }
                }

                if (Convert.ToBoolean(dt.Rows[0]["IsReceived"]) && Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]))
                {
                    //btnSubmit.Visible = false;
                    ddlProductionUnit.Enabled = false;
                    //chkProcess.Enabled = false;
                }

                DataTable dt1 = objAccessoryWorking.GetDataForAccessoryInternalChallanGrid(flag, flagOption, SerialNumber, ChallanNumber);
                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "trigger", "calculateTotal('txtNoOfItems');calculateTotal('txtQtyToIssue');", true);
                }
                div_TotalNoOfItems.Visible = true;
                div_TotalIssuedQty.Visible = true;

                span_TotalNoOfItems.InnerText = dt1.Rows[0]["TotalNoOfItems"].ToString();
                span_Total_Issued_Qty.InnerText = dt1.Rows[0]["TotalIssuedQty"].ToString();


            }
            else
            {
                old_table.Visible = true;

                AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
                if (OrderDetailId > 0)
                {
                    dvSupplier.Visible = false;
                    trPO.Visible = false;
                    objAccessoryChallan = objAccessoryWorking.Get_AccessoryChallan(ChallanId, OrderDetailId, AccessoryMasterId, Size, ColorPrint);
                    hdnAccessoryMasterId.Value = Convert.ToString(objAccessoryChallan.AccessoryMasterId);
                }
                else if (DebitNoteId > 0)
                {
                    dvStyle.Visible = false;
                    objAccessoryChallan = objAccessoryWorking.Get_AccessoryChallan(SupplierPoId, DebitNoteId, ChallanId);
                }
                // rajeevs 10022023            
                string HSNCode = objAccessoryChallan.HSNCode.ToString();
                if (HSNCode == "")
                {
                    spn_HSNCode.InnerHtml = "";
                    lblHSNCode.Visible = false;
                }
                else
                {
                    lblHSNCode.Visible = true;
                    lblHSNCode.Text = HSNCode;
                    spn_HSNCode.InnerHtml = "HSNCode";
                }
                // rajeevs 10022023	

                if (objAccessoryChallan.IsAuthorizedSignatory == true)
                {
                    divChkAuthorized.Visible = false;
                    divSigAuthorized.Visible = true;
                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(objAccessoryChallan.AuthoriseBy) == user.UserID)
                        {
                            lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                            imgAuthorized.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                            lblAuthorizedOnDate.Text = Convert.ToDateTime(objAccessoryChallan.AuthorizedDate).ToString("dd MMM yy (ddd)");
                        }
                    }
                }


                if (objAccessoryChallan.IsPartySignature == true)
                {
                    divChkReceive.Visible = false;
                    divSigReceive.Visible = true;
                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(objAccessoryChallan.RecievedBy) == user.UserID)
                        {
                            lblReceiverName.Text = user.FirstName + " " + user.LastName;
                            imgReceiver.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                            lblReceivedOnDate.Text = Convert.ToDateTime(objAccessoryChallan.ReceivedDate).ToString("dd MMM yy (ddd)");
                        }
                    }
                }

                hdnChallan.Value = objAccessoryChallan.ChallanId.ToString();

                if (DebitNoteId > 0)
                {
                    lblPoNo.Text = objAccessoryChallan.PoNumber.ToString();
                    lblSupplierName.Text = objAccessoryChallan.SupplierName;
                }
                lblChallan.Text = objAccessoryChallan.ChallanNumber;
                lblAccessoryQuality.Text = objAccessoryChallan.AccessoryName;
                if (OrderDetailId > 0)
                {
                    lblStyleNo.Text = objAccessoryChallan.StyleNumber;
                    lblSerialNo.Text = objAccessoryChallan.SerialNumber;
                }
                hdnSize.Value = objAccessoryChallan.Size;
                if (objAccessoryChallan.Size != "")
                    lblSize.Text = objAccessoryChallan.Size == "Default" ? "" : "(" + objAccessoryChallan.Size + ")";

                lblcolorprint.Text = objAccessoryChallan.Color_Print;
                lblDescription.Text = objAccessoryChallan.ChallanDesc.Replace("\r\n", "\n").Replace("\n", "<br>"); ;

                if (ChallanId > 0)
                {
                    lblChallanDate.Text = objAccessoryChallan.ChallanDate.ToString("dd MMM yy (ddd)");
                    ddlProductionUnit.SelectedValue = objAccessoryChallan.ProductionUnitId.ToString();
                }
                else
                {
                    lblChallanDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                    //for (int i = 0; i < chkProcess.Items.Count; i++)
                    //{
                    //    if (chkProcess.Items[i].Value == "7" && DebitNoteId > 0)// By default Rejection Retrurned checked
                    //    {
                    //        chkProcess.Items[i].Selected = true;
                    //    }
                    //    else if (chkProcess.Items[i].Value == "8" && OrderDetailId > 0)
                    //    {
                    //        chkProcess.Items[i].Selected = true;
                    //    }
                    //}
                }
                if (DebitNoteId > 0)
                {
                    //ddlType.SelectedValue = "1";
                    //ddlType.Attributes.Add("disabled", "disabled");
                    dvUnit.Visible = false;
                    hdnType.Value = "1";
                }
                if (OrderDetailId > 0)
                {
                    //ddlType.SelectedValue = "2";
                    //ddlType.Attributes.Add("disabled", "disabled");
                    hdnType.Value = "2";
                }

                lblTotalUnit.Text = objAccessoryChallan.UnitCount > 0 ? objAccessoryChallan.UnitCount.ToString() : "";
                lblChallanQty.Text = objAccessoryChallan.TotalRecChallanQty > 0 ? objAccessoryChallan.TotalRecChallanQty.ToString("N") : "";
                hdnTotalPcs.Value = objAccessoryChallan.TotalRecChallanQty.ToString();
                lblUnitName.Text = objAccessoryChallan.GarmentUnitName;


                if (AvailableQty > 0)
                {
                    lblAvailableQty.Text = AvailableQty.ToString("N");
                    hdnRemainingQty.Value = AvailableQty.ToString();
                    lblAvailableQtyUnit.Text = objAccessoryChallan.GarmentUnitName;
                }
                else
                {
                    lblAvailableQty.Text = objAccessoryChallan.BalanceQty > 0 ? objAccessoryChallan.BalanceQty.ToString("N") : "";
                    hdnRemainingQty.Value = objAccessoryChallan.BalanceQty.ToString();
                    lblAvailableQtyUnit.Text = objAccessoryChallan.BalanceQty > 0 ? objAccessoryChallan.GarmentUnitName : "";
                }
                if (lblAvailableQty.Text == "")
                {
                    tdAvailableQty.Attributes.Add("style", "display:none");
                }


                if ((objAccessoryChallan.IsPartySignature == true) && (objAccessoryChallan.IsAuthorizedSignatory == true))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
                    //btnSubmit.Visible = false;
                }
            }
        }

        //merging logic For InternalChallan Grid Start:Girish
        protected void GridView1_DataBoundEvent(Object sender, EventArgs e)
        {
            GridView gridview = (GridView)sender;

            for (int i = gridview.Rows.Count - 2; i >= 0; i--)
            {
                GridViewRow row = gridview.Rows[i];
                GridViewRow previousRow = gridview.Rows[i + 1];

                string currentRowAccessoryName = "", previousRowAccessoryName = "", currentRowColorPrint = "", previousRowColorPrint = "", currentRowContractQty = "", previousRowContractQty = "";


                currentRowAccessoryName = currentRowAccessoryName + ((HiddenField)row.FindControl("hdnAccessoryMasterId")).Value + ((HiddenField)row.FindControl("hdnSize")).Value;
                previousRowAccessoryName = previousRowAccessoryName + ((HiddenField)previousRow.FindControl("hdnAccessoryMasterId")).Value + ((HiddenField)previousRow.FindControl("hdnSize")).Value;

                currentRowColorPrint = currentRowColorPrint + ((HiddenField)row.FindControl("hdnColorPrint")).Value;
                previousRowColorPrint = previousRowColorPrint + ((HiddenField)previousRow.FindControl("hdnColorPrint")).Value;

                currentRowContractQty = currentRowContractQty + ((HiddenField)row.FindControl("hdnOrderDetailId")).Value;
                previousRowContractQty = previousRowContractQty + ((HiddenField)previousRow.FindControl("hdnOrderDetailId")).Value;

                if (currentRowAccessoryName.ToLower() == previousRowAccessoryName.ToLower())
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;

                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;
                }
                if (currentRowColorPrint.ToLower() == previousRowColorPrint.ToLower())
                {
                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;
                }

                if (currentRowContractQty.ToLower() == previousRowContractQty.ToLower())
                {
                    row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                    previousRow.Cells[3].Visible = false;
                    row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                    previousRow.Cells[4].Visible = false;
                }
            }            
                gridview.Columns[5].Visible = false;
        }
        //merging logic For InternalChallan Grid End:Girish      

    }
}