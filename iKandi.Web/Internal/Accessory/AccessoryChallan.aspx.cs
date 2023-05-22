using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryChallan : BasePage
    {
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
        private int UnitCount = 0;
        private int TotalPcs = 0;
      
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        AccessoryQualityController ObjAccessoryQlty = new AccessoryQualityController();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
            {                
                BindProductionUnit();
                BindChallanProcess();
                BindData();
                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress2");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
        }

        private void GetQueryString()
        {
            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                SupplierPoId = 0;
            }
            if (Request.QueryString["DebitNoteId"] != null)
            {
                DebitNoteId = Convert.ToInt32(Request.QueryString["DebitNoteId"]);
            }
            else
            {
                DebitNoteId = 0;
            }
            if (Request.QueryString["ChallanId"] != null)
            {
                ChallanId = Convert.ToInt32(Request.QueryString["ChallanId"]);
            }
            else
            {
                ChallanId = 0;
            }
            if (Request.QueryString["ChallanType"] != null)
            {
                ChallanType = Request.QueryString["ChallanType"].ToString();
            }
            else
            {
                ChallanType = "";
            }
            if (Request.QueryString["OrderDetailId"] != null)
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }
            else
            {
                OrderDetailId = 0;
            }
            if (Request.QueryString["AccessoryMasterId"] != null)
            {
                AccessoryMasterId = Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
            }
            else
            {
                AccessoryMasterId = 0;
            }
            if (Request.QueryString["Size"] != null)
            {
                Size = Request.QueryString["Size"].ToString();
            }
            else
            {
                Size = "";
            }
            if (Request.QueryString["ColorPrint"] != null)
            {
                ColorPrint = Request.QueryString["ColorPrint"].ToString();
            }
            else
            {
                ColorPrint = "";
            }
            if (Request.QueryString["AvailableQty"] != null)
            {
                AvailableQty = Convert.ToInt32(Request.QueryString["AvailableQty"]);
            }
            else
            {
                AvailableQty = 0;
            }

        }

        private void BindData()
        {
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

            if (objAccessoryChallan.IsAuthorizedSignatory == true)
            {
                divChkAuthorized.Visible = false;
                divSigAuthorized.Visible = true;
                foreach (var user in ApplicationHelper.Users)
                {
                    if (Convert.ToInt32(objAccessoryChallan.AuthoriseBy) == user.UserID)
                    {
                        lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                        imgAuthorized.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
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
                        imgReceiver.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                        lblReceivedOnDate.Text = Convert.ToDateTime(objAccessoryChallan.ReceivedDate).ToString("dd MMM yy (ddd)");
                    }
                }
            }

            hdnChallan.Value = objAccessoryChallan.ChallanId.ToString();
            lblGarmentUnit.Text = objAccessoryChallan.GarmentUnitName;

            if (DebitNoteId > 0)
            {
                txtPoNo.Text = objAccessoryChallan.PoNumber.ToString();
                lblSupplierName.Text = objAccessoryChallan.SupplierName;
            }
            lblChallan.Text = objAccessoryChallan.ChallanNumber;
            lblAccessoryQuality.Text = objAccessoryChallan.AccessoryName;
            if (OrderDetailId > 0)
            {
                lblStyleNo.Text = objAccessoryChallan.StyleNumber;
                lblSerialNo.Text = objAccessoryChallan.SerialNumber;
            }

            if (objAccessoryChallan.Size != "")
                lblSize.Text = objAccessoryChallan.Size == "Default" ? "" : "(" + objAccessoryChallan.Size + ")";

            lblcolorprint.Text = objAccessoryChallan.Color_Print;
            txtDescription.Text = objAccessoryChallan.ChallanDesc;

            if (ChallanId > 0)
            {
                txtChallanDate.Text = objAccessoryChallan.ChallanDate.ToString("dd MMM yy (ddd)");               
                ddlProductionUnit.SelectedValue = objAccessoryChallan.ProductionUnitId.ToString();
            }
            else
            {
                txtChallanDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                for (int i = 0; i < chkProcess.Items.Count; i++)
                {
                    if (chkProcess.Items[i].Value == "7" && DebitNoteId > 0)// By default Rejection Retrurned checked
                    {
                        chkProcess.Items[i].Selected = true;
                    }
                    else if (chkProcess.Items[i].Value == "8" && OrderDetailId > 0)
                    {
                        chkProcess.Items[i].Selected = true;
                    }
                }
            }
            if (DebitNoteId > 0)
            {
                ddlType.SelectedValue = "1";
                ddlType.Attributes.Add("disabled", "disabled");
                dvUnit.Style.Add("display", "none");
            }
            if (OrderDetailId > 0)
            {
                ddlType.SelectedValue = "2";
                ddlType.Attributes.Add("disabled", "disabled");
            }

            List<AccessoryChallanBreakDown> ChallanBreakDownList = objAccessoryChallan.ChallanBreakDownList;
            UnitCount = ChallanBreakDownList.Count;

            if (ChallanBreakDownList.Count > 0)
            {
                if (ChallanBreakDownList.Count <= 18)
                {
                    var List1 = ChallanBreakDownList.Where(s => s.RowNo < 19);

                    grdChallan1.DataSource = List1;
                    grdChallan1.DataBind();
                }
                else if (ChallanBreakDownList.Count > 18)
                {
                    var List1 = ChallanBreakDownList.Where(s => s.RowNo < 19);
                    grdChallan1.DataSource = List1;
                    grdChallan1.DataBind();

                    var List2 = ChallanBreakDownList.Where(s => s.RowNo > 18);

                    grdChallan2.DataSource = List2;
                    grdChallan2.DataBind();
                }
            }

            txtTotalUnit.Text = UnitCount > 0 ? UnitCount.ToString() : "";
            txtTotalPcs.Text = TotalPcs > 0 ? TotalPcs.ToString("N0") : "";
            hdnTotalPcsOnPageLoad.Value = TotalPcs.ToString();
            lblTotalPcs.Text = objAccessoryChallan.GarmentUnitName;
            

            if (AvailableQty > 0)
            {
                lblAvailableQty.Text = AvailableQty.ToString();
                hdnAvailableQty.Value = (AvailableQty + objAccessoryChallan.TotalPcs).ToString();
                lblAvailableQtyUnit.Text = objAccessoryChallan.GarmentUnitName;
            }
            else
            {
                lblAvailableQty.Text = objAccessoryChallan.BalanceQty > 0 ? objAccessoryChallan.BalanceQty.ToString() : "";
                hdnAvailableQty.Value = objAccessoryChallan.TotalPcs.ToString();
                lblAvailableQtyUnit.Text = objAccessoryChallan.BalanceQty > 0 ? objAccessoryChallan.GarmentUnitName: "";
            }

            if ((objAccessoryChallan.IsPartySignature == true) && (objAccessoryChallan.IsAuthorizedSignatory == true))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
                btnSubmit.Visible = false;
            }
        }       

        private void BindProductionUnit() {

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
            List<ChallanProcess> ChallanProcessList = objAccessoryWorking.GetChallanProcessList(ChallanId);
            chkProcess.DataSource = ChallanProcessList;
            chkProcess.DataTextField = "ProcessName";
            chkProcess.DataValueField = "ChallanProcessId";
            chkProcess.DataBind();

            for (int i = 0; i < chkProcess.Items.Count; i++)
            {
                chkProcess.Items[i].Selected = ChallanProcessList[i].IsChecked;
            }
        }

        protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            TotalPcs = 0;
            int RowNo = 0;
            if (txtPcs.Text == "0")
            {
                ShowAlert("Quantity cannot be zero!");
                txtPcs.Text = string.Empty;
                return;
            }

            List<AccessoryChallanBreakDown> ChallanBreakDownList = new List<AccessoryChallanBreakDown>();

            if (grdChallan1.Rows.Count > 0)
            {
                foreach (GridViewRow grv in grdChallan1.Rows)
                {
                    HiddenField hdnId = (HiddenField)grv.FindControl("hdnId");
                    HiddenField hdnBreakDownId = (HiddenField)grv.FindControl("hdnBreakDownId");
                    TextBox txtQty = (TextBox)grv.FindControl("txtQty");
                    Label lblGroupUnit = (Label)grv.FindControl("lblGroupUnit");
                   
                   
                    AccessoryChallanBreakDown objChallanBreakDown = new AccessoryChallanBreakDown();

                    objChallanBreakDown.RowNo = hdnId.Value == "" ? -1 : Convert.ToInt32(hdnId.Value);
                    objChallanBreakDown.Challan_BreakDown_Id = hdnBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnBreakDownId.Value);
                    objChallanBreakDown.Pcs = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
                    //objChallanBreakDown.GroupUnitId = hdnGroupUnit.Value == "" ? -1 : Convert.ToInt32(hdnGroupUnit.Value);
                    objChallanBreakDown.GroupUnitName = lblGroupUnit.Text;
                    ChallanBreakDownList.Add(objChallanBreakDown);

                    RowNo++;
                }
            }

            if (grdChallan2.Rows.Count > 0)
            {
                foreach (GridViewRow grv in grdChallan2.Rows)
                {
                    HiddenField hdnId = (HiddenField)grv.FindControl("hdnId");
                    HiddenField hdnBreakDownId = (HiddenField)grv.FindControl("hdnBreakDownId");
                    TextBox txtQty = (TextBox)grv.FindControl("txtQty");
                    Label lblGroupUnit = (Label)grv.FindControl("lblGroupUnit");
                    //HiddenField hdnGroupUnit = (HiddenField)grv.FindControl("hdnGroupUnit");

                    AccessoryChallanBreakDown objChallanBreakDown = new AccessoryChallanBreakDown();

                    objChallanBreakDown.RowNo = hdnId.Value == "" ? -1 : Convert.ToInt32(hdnId.Value);
                    objChallanBreakDown.Challan_BreakDown_Id = hdnBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnBreakDownId.Value);
                    objChallanBreakDown.Pcs = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
                    //objChallanBreakDown.GroupUnitId = hdnGroupUnit.Value == "" ? -1 : Convert.ToInt32(hdnGroupUnit.Value);
                    objChallanBreakDown.GroupUnitName = lblGroupUnit.Text;
                    ChallanBreakDownList.Add(objChallanBreakDown);

                    RowNo++;
                }
            }

            //if ((ChallanBreakDownList.Select(x => x.Pcs).Sum() + Convert.ToInt32(txtPcs.Text)) > QtyAvailable)
            //{
            //    ShowAlert("No. of Pcs. cannot greater than Available Quantity!");
            //    txtPcs.Text = string.Empty;
            //    return;
            //}
            AccessoryChallanBreakDown objChallanBreakDown1 = new AccessoryChallanBreakDown();
            objChallanBreakDown1.RowNo = RowNo + 1;
            objChallanBreakDown1.Challan_BreakDown_Id = -1;
            objChallanBreakDown1.Pcs = txtPcs.Text == "" ? 0 : Convert.ToInt32(txtPcs.Text);
            //objChallanBreakDown1.GroupUnitId = Convert.ToInt32(ddlGroupUnit.SelectedValue);
            objChallanBreakDown1.GroupUnitName = lblGarmentUnit.Text;
            ChallanBreakDownList.Add(objChallanBreakDown1);

            UnitCount = ChallanBreakDownList.Count;

            if (ChallanBreakDownList.Count <= 18)
            {
                var List1 = ChallanBreakDownList.Where(s => s.RowNo < 19);

                grdChallan1.DataSource = List1;
                grdChallan1.DataBind();
            }
            else if (ChallanBreakDownList.Count > 18)
            {
                var List1 = ChallanBreakDownList.Where(s => s.RowNo < 19);

                grdChallan1.DataSource = List1;
                grdChallan1.DataBind();

                var List2 = ChallanBreakDownList.Where(s => s.RowNo > 18);

                grdChallan2.DataSource = List2;
                grdChallan2.DataBind();
            }
     
            txtTotalUnit.Text = UnitCount > 0 ? UnitCount.ToString() : "";
            txtTotalPcs.Text = TotalPcs > 0 ? TotalPcs.ToString("N0") : "";
            int AvailableQty = hdnAvailableQty.Value == "" ? 0 : Convert.ToInt32(hdnAvailableQty.Value);
            lblAvailableQty.Text = (AvailableQty - TotalPcs) > 0 ? (AvailableQty - TotalPcs).ToString("N0") : "";

            lblTotalPcs.Text = lblGarmentUnit.Text;
            lblAvailableQtyUnit.Text = lblGarmentUnit.Text;
            //ddlGroupUnit.Attributes.Add("disabled", "disabled");
            txtPcs.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((DebitNoteId > 0) || (OrderDetailId > 0))
            {
                AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
                if (DebitNoteId > 0)
                {
                    objAccessoryChallan.SupplierPoId = SupplierPoId;
                    objAccessoryChallan.DebitNoteId = DebitNoteId;
                }
                objAccessoryChallan.ChallanId = hdnChallan.Value == "" ? -1 : Convert.ToInt32(hdnChallan.Value);
                objAccessoryChallan.ChallanNumber = lblChallan.Text;
                objAccessoryChallan.ChallanDate = txtChallanDate.Text != "" ? DateTime.ParseExact(txtChallanDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                objAccessoryChallan.ChallanType = Convert.ToInt32(ddlType.SelectedValue);
                objAccessoryChallan.ChallanDesc = txtDescription.Text;
               
                objAccessoryChallan.ProductionUnitId = Convert.ToInt32(ddlProductionUnit.SelectedValue);
                objAccessoryChallan.SendQty = -1;
                if (OrderDetailId > 0)
                {
                    objAccessoryChallan.AccessoryMasterId = Convert.ToInt32(hdnAccessoryMasterId.Value);
                    char[] charsToTrim = { '(', ')' };
                    objAccessoryChallan.Color_Print = lblcolorprint.Text;
                    objAccessoryChallan.Size = lblSize.Text.Trim(charsToTrim);
                    objAccessoryChallan.OrderDetailId = OrderDetailId;
                }               

                List<ChallanProcess> objChallanProcessList = new List<ChallanProcess>();
                for (int i = 0; i < chkProcess.Items.Count; i++)
                {
                    ChallanProcess objProcess = new ChallanProcess();
                    if (chkProcess.Items[i].Selected)
                    {
                        objProcess.ChallanProcessId = Convert.ToInt32(chkProcess.Items[i].Value);
                        objChallanProcessList.Add(objProcess);
                    }
                }
                objAccessoryChallan.ChallanProcessList = objChallanProcessList;
               
                List<AccessoryChallanBreakDown> objChallanBreakDownList = new List<AccessoryChallanBreakDown>();

                if (grdChallan1.Rows.Count > 0)
                {
                    foreach (GridViewRow grv in grdChallan1.Rows)
                    {                      
                        TextBox txtQty = (TextBox)grv.FindControl("txtQty");
                        Label lblGroupUnit = (Label)grv.FindControl("lblGroupUnit");
                        HiddenField hdnBreakDownId = (HiddenField)grv.FindControl("hdnBreakDownId");

                        AccessoryChallanBreakDown objChallanBreakDown = new AccessoryChallanBreakDown();

                        objChallanBreakDown.Challan_BreakDown_Id = hdnBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnBreakDownId.Value);
                        objChallanBreakDown.Pcs = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);                        

                        objChallanBreakDown.GroupUnitName = lblGroupUnit.Text;
                        objChallanBreakDownList.Add(objChallanBreakDown);
                    }
                }

                if (grdChallan2.Rows.Count > 0)
                {
                    foreach (GridViewRow grv in grdChallan2.Rows)
                    {                        
                        TextBox txtQty = (TextBox)grv.FindControl("txtQty");
                        Label lblGroupUnit = (Label)grv.FindControl("lblGroupUnit");
                        HiddenField hdnBreakDownId = (HiddenField)grv.FindControl("hdnBreakDownId");

                        AccessoryChallanBreakDown objChallanBreakDown = new AccessoryChallanBreakDown();

                        objChallanBreakDown.Challan_BreakDown_Id = hdnBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnBreakDownId.Value);
                        objChallanBreakDown.Pcs = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);                      

                        objChallanBreakDown.GroupUnitName = lblGroupUnit.Text;
                        objChallanBreakDownList.Add(objChallanBreakDown);

                    }
                }                

                objAccessoryChallan.ChallanBreakDownList = objChallanBreakDownList;

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                objAccessoryChallan.IsPartySignature = (chkrecivegood.Checked == true ? true : false);
                if (objAccessoryChallan.IsPartySignature == true)
                {
                    objAccessoryChallan.ReceivedDate = DateTime.Now;
                }
                objAccessoryChallan.IsAuthorizedSignatory = (chkAuthorised.Checked == true ? true : false);
                if (objAccessoryChallan.IsAuthorizedSignatory == true)
                {
                    objAccessoryChallan.AuthorizedDate = DateTime.Now;
                }
                
                int iSave = objAccessoryWorking.Save_Accessory_Challan(objAccessoryChallan, UserId);

                if (iSave > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
                    return;
                }
            }
        }

        protected void grdChallan1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                if (txtQty.Text != "")
                {
                    TotalPcs = TotalPcs + Convert.ToInt32(txtQty.Text);
                }
                Label lblGroupUnit = (Label)e.Row.FindControl("lblGroupUnit");
                lblGroupUnit.Text = lblGarmentUnit.Text;
            }
        }

        protected void grdChallan1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdChallan1.Rows[e.RowIndex];
            HiddenField hdnSelectedId = (HiddenField)row.FindControl("hdnId");
            HiddenField hdnSelectedBreakDownId = (HiddenField)row.FindControl("hdnBreakDownId");     
            TotalPcs = 0;
          
            int SelectedBreakDownId = hdnSelectedBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnSelectedBreakDownId.Value);
            if (SelectedBreakDownId > 0)
            {
                int iDelete = objAccessoryWorking.Delete_ChallanBreakDown(SelectedBreakDownId);
            }

            List<AccessoryChallanBreakDown> ChallanBreakDownList = new List<AccessoryChallanBreakDown>();

            for (int AccNo = 0; AccNo < grdChallan1.Rows.Count; AccNo++)
            {
                AccessoryChallanBreakDown objChallanBreakDown = new AccessoryChallanBreakDown();

                HiddenField hdnId = (HiddenField)grdChallan1.Rows[AccNo].FindControl("hdnId");
                HiddenField hdnBreakDownId = (HiddenField)grdChallan1.Rows[AccNo].FindControl("hdnBreakDownId");
                TextBox txtQty = (TextBox)grdChallan1.Rows[AccNo].FindControl("txtQty");
                Label lblGroupUnit = (Label)grdChallan1.Rows[AccNo].FindControl("lblGroupUnit");                

                if (hdnSelectedId.Value != hdnId.Value)
                {
                    objChallanBreakDown.Challan_BreakDown_Id = hdnBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnBreakDownId.Value);
                    objChallanBreakDown.Pcs = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);                    
                    objChallanBreakDown.GroupUnitName = lblGroupUnit.Text;
                    ChallanBreakDownList.Add(objChallanBreakDown);                    
                }
            }
            grdChallan1.DataSource = ChallanBreakDownList;
            grdChallan1.DataBind();

            UnitCount = ChallanBreakDownList.Count;

            txtTotalUnit.Text = UnitCount > 0 ? UnitCount.ToString() : "";
            txtTotalPcs.Text = TotalPcs > 0 ? TotalPcs.ToString("N0") : "";
            lblTotalPcs.Text = lblGarmentUnit.Text;
            lblAvailableQtyUnit.Text = lblGarmentUnit.Text;

            int AvailableQty = hdnAvailableQty.Value == "" ? 0 : Convert.ToInt32(hdnAvailableQty.Value);
            lblAvailableQty.Text = (AvailableQty - TotalPcs) > 0 ? (AvailableQty - TotalPcs).ToString() : "";
        }

        protected void grdChallan2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                if (txtQty.Text != "")
                {
                    TotalPcs = TotalPcs + Convert.ToInt32(txtQty.Text);
                }

                Label lblGroupUnit = (Label)e.Row.FindControl("lblGroupUnit");
                lblGroupUnit.Text = lblGarmentUnit.Text;
            }
        }

        protected void grdChallan2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdChallan2.Rows[e.RowIndex];
            HiddenField hdnSelectedId = (HiddenField)row.FindControl("hdnId");
            HiddenField hdnSelectedBreakDownId = (HiddenField)row.FindControl("hdnBreakDownId");
            TotalPcs = 0;
            int SelectedBreakDownId = hdnSelectedBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnSelectedBreakDownId.Value);
            if (SelectedBreakDownId > 0)
            {
                int iDelete = objAccessoryWorking.Delete_ChallanBreakDown(SelectedBreakDownId);
            }

            List<AccessoryChallanBreakDown> ChallanBreakDownList = new List<AccessoryChallanBreakDown>();

            for (int AccNo = 0; AccNo < grdChallan2.Rows.Count; AccNo++)
            {
                AccessoryChallanBreakDown objChallanBreakDown = new AccessoryChallanBreakDown();

                HiddenField hdnId = (HiddenField)grdChallan2.Rows[AccNo].FindControl("hdnId");
                HiddenField hdnBreakDownId = (HiddenField)grdChallan2.Rows[AccNo].FindControl("hdnBreakDownId");
                TextBox txtQty = (TextBox)grdChallan2.Rows[AccNo].FindControl("txtQty");
                Label lblGroupUnit = (Label)grdChallan2.Rows[AccNo].FindControl("lblGroupUnit");               

                if (hdnSelectedId.Value != hdnId.Value)
                {
                    objChallanBreakDown.Challan_BreakDown_Id = hdnBreakDownId.Value == "" ? -1 : Convert.ToInt32(hdnBreakDownId.Value);
                    objChallanBreakDown.Pcs = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);                   
                    objChallanBreakDown.GroupUnitName = lblGroupUnit.Text;
                    ChallanBreakDownList.Add(objChallanBreakDown);                    
                }

            }
            grdChallan2.DataSource = ChallanBreakDownList;
            grdChallan2.DataBind();

            UnitCount = ChallanBreakDownList.Count;

            txtTotalUnit.Text = UnitCount > 0 ? UnitCount.ToString() : "";
            txtTotalPcs.Text = TotalPcs > 0 ? TotalPcs.ToString("N0") : "";
            lblTotalPcs.Text = lblGarmentUnit.Text;
            lblAvailableQtyUnit.Text = lblGarmentUnit.Text;

            int AvailableQty = hdnAvailableQty.Value == "" ? 0 : Convert.ToInt32(hdnAvailableQty.Value);
            lblAvailableQty.Text = (AvailableQty - TotalPcs) > 0 ? (AvailableQty - TotalPcs).ToString() : "";
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

    }
}