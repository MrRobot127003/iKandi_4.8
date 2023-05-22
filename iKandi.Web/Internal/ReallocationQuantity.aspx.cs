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

namespace iKandi.Web.Internal
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public string TradeName
        {
            get;
            set;
        }
        public int FabricQualityID
        {
            get;
            set;
        }

        public int PassQtyToMove
        {
            get;
            set;
        }
        public int ReqQtyToMove
        {
            get;
            set;
        }
        public int FromOrderDetailsId
        {
            get;
            set;
        }
        public int ToOrderDetailsId
        {
            get;
            set;
        }
        public string AccSize
        {

            get;
            set;
        }
        public string FrmFabricDetails
        {
            get;
            set;
        }
        public string ToFabricDetails
        {
            get;
            set;
        }
        public int stage1
        {
            get;
            set;
        }
        public int stage2
        {
            get;
            set;
        }
        public int stage3
        {
            get;
            set;
        }
        public int stage4
        {
            get;
            set;
        }
        public int SupplyType
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        FabricController objFabrciController = new FabricController();
        static DataTable Todt = new DataTable();
        static DataTable FromDt = new DataTable();
        static DataTable TodtAcc = new DataTable();
        static DataTable FromdtAcc = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ApplicationHelper.LoggedInUser == null)
                Response.Redirect("~/public/Login.aspx");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ACCESSORY_DETAIL_AVG))
                hdnIsReadOnly.Value = "1";

            hdnUserId.Value = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            //hdnUserId.Value = "122".ToString();

            if (!IsPostBack)
            {
                BindStages();
            }
            if (ddlType.SelectedItem.Value == "1")
            {
                grdToAccessory.Visible = false;
                grdfromAccessory.Visible = false;
                grdto.Visible = true;
                grdFrom.Visible = true;

            }
            else
            {
                grdFrom.Visible = false;
                grdto.Visible = false;
                grdToAccessory.Visible = true;
                grdfromAccessory.Visible = true;
            }
        }

        public void BindGrdFrom()
        {
            DataTable dt = new DataTable();

            string val = ddlType.SelectedItem.Value;
            if (val == "1")
            {
                try
                {
                    Type = "Fabric";
                    //TradeName = txtFabric.Text;
                    FabricQualityID = Convert.ToInt32(hdnFabric_Qualityid.Value);
                    FrmFabricDetails = txtColorPrint.Text;
                    stage1 = Convert.ToInt32(ddlstagetype1.SelectedItem.Value);
                    stage2 = Convert.ToInt32(ddlstagetype2.SelectedItem.Value);
                    stage3 = Convert.ToInt32(ddlstagetype3.SelectedItem.Value);
                    stage4 = Convert.ToInt32(ddlstage4.SelectedItem.Value);
                    SupplyType = Convert.ToInt32(ddlFabricType.SelectedItem.Value);
                    DataSet DS = objFabrciController.BindFromQuantityReallocation(FabricQualityID, FrmFabricDetails, stage1, stage2, stage3, stage4, SupplyType, "From", Type);
                    dt = DS.Tables[0];


                    if (dt.Rows.Count > 0)
                    {
                        FromDt = DS.Tables[0];
                        grdFrom.DataSource = dt;
                        grdFrom.DataBind();
                        Btnsubmit.Visible = true;
                        BtnsubmitAcc.Visible = false; ;

                    }
                    else
                    {
                        grdFrom.DataSource = null;
                        grdFrom.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    Server.Transfer("~/Internal/CustomErrorPage.aspx");
                }

            }
            else if (val == "2")
            {

                try
                {
                    Type = "Accessory";
                    TradeName = txtAccessory.Text;
                    //AccessoryWorkingDetailID = Convert.ToInt32(HdnAccSize.Value);
                    AccSize = HdnAccSize.Value;
                    FrmFabricDetails = txtAccessoryColor.Text;
                    stage1 = Convert.ToInt32(ddlAccessoryStage1.SelectedItem.Value);
                    stage2 = Convert.ToInt32(ddlAccessoryStage2.SelectedItem.Value);
                    SupplyType = Convert.ToInt32(ddlAccessoryType.SelectedItem.Value);
                    dt = objFabrciController.BindFromQuantityReallocationAcc(TradeName, AccSize, FrmFabricDetails, stage1, stage2, stage3, stage4, SupplyType, "From", Type).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        FromdtAcc = dt;

                        grdfromAccessory.DataSource = dt;
                        grdfromAccessory.DataBind();
                        BtnsubmitAcc.Visible = true;
                        Btnsubmit.Visible = false; ;

                    }
                    else
                    {
                        grdfromAccessory.DataSource = null;
                        grdfromAccessory.DataBind();
                    }
                }
                catch (Exception Ex)
                {
                    Server.Transfer("~/Internal/CustomErrorPage.aspx");
                }
            }
        }

        public void BindStages()
        {

            try
            {
                string Flag = "Fabric";
                DataSet DS = objFabrciController.GetStageForAccFabric(Flag);
                ddlstagetype1.DataTextField = "name";
                ddlstagetype1.DataValueField = "SupplierType_Id";
                ddlstagetype1.DataSource = DS.Tables[0];
                ddlstagetype1.DataBind();
                ddlstagetype2.DataTextField = "name";
                ddlstagetype2.DataValueField = "SupplierType_Id";
                ddlstagetype2.DataSource = DS.Tables[1];
                ddlstagetype2.DataBind();
                ddlstagetype3.DataTextField = "name";
                ddlstagetype3.DataValueField = "SupplierType_Id";
                ddlstagetype3.DataSource = DS.Tables[2];
                ddlstagetype3.DataBind();
                ddlstage4.DataTextField = "name";
                ddlstage4.DataValueField = "SupplierType_Id";
                ddlstage4.DataSource = DS.Tables[3];
                ddlstage4.DataBind();
                ddlFabricType.DataTextField = "name";
                ddlFabricType.DataValueField = "SupplierType_Id";
                ddlFabricType.DataSource = DS.Tables[4];
                ddlFabricType.DataBind();

                Flag = string.Empty;
                Flag = "Accessory";
                DS.Clear();
                DS = objFabrciController.GetStageForAccFabric(Flag);
                ddlAccessoryStage1.DataTextField = "name";
                ddlAccessoryStage1.DataValueField = "SupplierType_Id";
                ddlAccessoryStage1.DataSource = DS.Tables[0];
                ddlAccessoryStage1.DataBind();
                ddlAccessoryStage2.DataTextField = "name";
                ddlAccessoryStage2.DataValueField = "SupplierType_Id";
                ddlAccessoryStage2.DataSource = DS.Tables[1];
                ddlAccessoryStage2.DataBind();
                ddlAccessoryType.DataTextField = "name";
                ddlAccessoryType.DataValueField = "SupplierType_Id";
                ddlAccessoryType.DataSource = DS.Tables[2];
                ddlAccessoryType.DataBind();
            }
            catch (Exception ex)
            {
                Server.Transfer("~/Internal/CustomErrorPage.aspx");
            }
        }

        public void BindGrdTo()
        {
            DataTable dt = new DataTable();
            //TradeName = txtFabric.Text;
            ToFabricDetails = txtColorPrint.Text;
            //stage1 = Convert.ToInt32(ddlstagetype1.SelectedItem.Value);
            //stage2 = Convert.ToInt32(ddlstagetype2.SelectedItem.Value);
            //stage3 = Convert.ToInt32(ddlstagetype3.SelectedItem.Value);
            //stage4 = Convert.ToInt32(ddlstage4.SelectedItem.Value);
            //SupplyType = Convert.ToInt32(ddlFabricType.SelectedItem.Value);

            string val = ddlType.SelectedItem.Value;
            if (val == "1")
            {
                try
                {
                    Type = "Fabric";
                    //TradeName = txtFabric.Text;
                    //FabricQualityID = Convert.ToInt32(hdnFabric_Qualityid.Value);
                    //FabricDetails = txtColorPrint.Text;
                    //stage1 = Convert.ToInt32(ddlstagetype1.SelectedItem.Value);
                    //stage2 = Convert.ToInt32(ddlstagetype2.SelectedItem.Value);
                    //stage3 = Convert.ToInt32(ddlstagetype3.SelectedItem.Value);
                    //stage4 = Convert.ToInt32(ddlstage4.SelectedItem.Value);
                    //SupplyType = Convert.ToInt32(ddlFabricType.SelectedItem.Value);
                    BindParmFab();
                    dt = objFabrciController.BindFromQuantityReallocation(FabricQualityID, ToFabricDetails, stage1, stage2, stage3, stage4, SupplyType, "To", Type).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Todt = dt;
                        grdto.DataSource = dt;
                        grdto.DataBind();
                    }
                    else
                    {
                        grdto.DataSource = null;
                        grdto.DataBind();

                    }
                }
                catch (Exception EX)
                {
                    Server.Transfer("~/Internal/CustomErrorPage.aspx");
                }
            }
            else if (val == "2")
            {
                try
                {
                    Type = "Accessory";
                    //TradeName = txtAccessory.Text;
                    ToFabricDetails = txtAccessoryColor.Text;
                    stage1 = Convert.ToInt32(ddlAccessoryStage1.SelectedItem.Value);
                    stage2 = Convert.ToInt32(ddlAccessoryStage2.SelectedItem.Value);
                    AccSize = HdnAccSize.Value;

                    dt = objFabrciController.BindFromQuantityReallocationAcc(TradeName, AccSize, ToFabricDetails, stage1, stage2, stage3, stage4, SupplyType, "To", Type).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        TodtAcc = dt;

                        grdToAccessory.DataSource = dt;
                        grdToAccessory.DataBind();
                    }
                    else
                    {
                        grdToAccessory.DataSource = null;
                        grdToAccessory.DataBind();

                    }
                }
                catch (Exception Ex)
                {
                    Server.Transfer("~/Internal/CustomErrorPage.aspx");
                }

            }
        }

        public void BindParmFab()
        {
            if (ddlType.SelectedItem.Value == "1")
            {
                FabricQualityID = Convert.ToInt32(hdnFabric_Qualityid.Value);
                if (txtColorPrint.Text != string.Empty)
                {
                    ToFabricDetails = txtColorPrint.Text;
                    FrmFabricDetails = txtColorPrint.Text;
                }
                stage1 = Convert.ToInt32(ddlstagetype1.SelectedItem.Value);
                stage2 = Convert.ToInt32(ddlstagetype2.SelectedItem.Value);
                stage3 = Convert.ToInt32(ddlstagetype3.SelectedItem.Value);
                stage4 = Convert.ToInt32(ddlstage4.SelectedItem.Value);
                SupplyType = Convert.ToInt32(ddlFabricType.SelectedItem.Value);
            }

        }

        public void BindParmAcc()
        {
            //FabricQualityID = Convert.ToInt32(hdnFabric_Qualityid.Value);
            TradeName = txtAccessory.Text;
            if (!string.IsNullOrEmpty(txtAccessoryColor.Text))
            {
                ToFabricDetails = txtAccessoryColor.Text;
                FrmFabricDetails = txtAccessoryColor.Text;
            }
            stage1 = Convert.ToInt32(ddlAccessoryStage1.SelectedItem.Value);
            stage2 = Convert.ToInt32(ddlAccessoryStage2.SelectedItem.Value);
            //stage3 = Convert.ToInt32(ddlAccessoryStage3.SelectedItem.Value);
            //stage4 = Convert.ToInt32(ddlstage4.SelectedItem.Value);
            SupplyType = Convert.ToInt32(ddlAccessoryType.SelectedItem.Value);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrdFrom();
            BindGrdTo();
        }

        protected void grdFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btnsubmit_Click(object sender, EventArgs e)
        {
            BindParmFab();
            try
            {
                foreach (GridViewRow Gvr in grdFrom.Rows)
                {
                    TextBox txtSubtract = (TextBox)Gvr.FindControl("txtSubtract");
                    if (txtSubtract.Text != string.Empty)
                    {
                        if (Convert.ToInt32(txtSubtract.Text) > 0)
                        {
                            PassQtyToMove = Convert.ToInt32(txtSubtract.Text);
                            HiddenField hdnOrderDetailsidFrom = Gvr.FindControl("hdnOrderDetailsid") as HiddenField;
                            HiddenField hdnFabricDetails = Gvr.FindControl("hdnFabricDetailsfrm") as HiddenField;
                            FromOrderDetailsId = Convert.ToInt32(hdnOrderDetailsidFrom.Value);
                            if (string.IsNullOrEmpty(FrmFabricDetails))
                            {

                                if (!string.IsNullOrEmpty(hdnFabricDetails.Value))
                                {
                                    FrmFabricDetails = hdnFabricDetails.Value;

                                }

                            }

                        }
                    }
                }
                foreach (GridViewRow GVR in grdto.Rows)
                {
                    string Flag = "Fabric";
                    TextBox txtAdd = GVR.FindControl("txtAdd") as TextBox;
                    if (txtAdd.Text != string.Empty)
                    {
                        if (Convert.ToInt32(txtAdd.Text) > 0)
                        {
                            HiddenField hdnOrderDetailsidTo = GVR.FindControl("hdnOrderDetailsid") as HiddenField;
                            Label lblAllocated = GVR.FindControl("lblAllocated") as Label;
                            Label lblRequireQty = GVR.FindControl("lblRequireQty") as Label;
                            HiddenField hdnEditedReqQty = GVR.FindControl("hdnEditedReqQty") as HiddenField;
                            HiddenField hdnFabricDetailsTo = GVR.FindControl("hdnFabricDetailsTo") as HiddenField;                            

                            if (string.IsNullOrEmpty(ToFabricDetails))
                            {

                                if (string.IsNullOrEmpty(txtColorPrint.Text) && !string.IsNullOrEmpty(hdnFabricDetailsTo.Value))
                                {
                                    ToFabricDetails = hdnFabricDetailsTo.Value;

                                }

                            }

                            ReqQtyToMove = Convert.ToInt32(txtAdd.Text.Replace(",", "")) + Convert.ToInt32(lblAllocated.Text.Replace(",", "")) + Convert.ToInt32(hdnEditedReqQty.Value.Replace(",", ""));
                            ToOrderDetailsId = Convert.ToInt32(hdnOrderDetailsidTo.Value);
                            objFabrciController.QuantityReallocationFabric_Accessory_FinalSattlement(FromOrderDetailsId, ToOrderDetailsId, FabricQualityID, FrmFabricDetails, ToFabricDetails, SupplyType, 1, PassQtyToMove, ReqQtyToMove, Convert.ToInt32(hdnUserId.Value), Flag,0,String.Empty);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "SuccessMsg('Qty. Moved Successfully. Please refresh the MO for Changes.')", true);
                            
                        }
                    }

                }
                BindGrdFrom();
                BindGrdTo();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "FailedMsg('Some Error Occured, Please try Again.')", true);
            }
        }

        protected void searchContractFrom_Click(object sender, EventArgs e)
        {


            if (ddlType.SelectedItem.Value == "1" && txtsearchContractFrom.Text.Trim()!=string.Empty)
            {
                string filter = "SerialNumber Like '%" + txtsearchContractFrom.Text.Trim() + "%'";
                DataTable DT = FromDt.Select(filter).CopyToDataTable();
                if (DT.Rows.Count > 0)
                {
                    grdFrom.DataSource = DT;
                    grdFrom.DataBind();
                }
                else
                {
                    grdFrom.DataSource = null;
                    grdFrom.DataBind();

                }

            }
            else if (ddlType.SelectedItem.Value == "2" && txtsearchContractFrom.Text.Trim()!=string.Empty)
            {

                string filter = "SerialNumber LIKE '%" + txtsearchContractFrom.Text.Trim() + "%'";

                DataTable DT = FromdtAcc.Select(filter).CopyToDataTable();
                if (DT.Rows.Count > 0)
                {
                    grdfromAccessory.DataSource = DT;
                    grdfromAccessory.DataBind();
                }
                else
                {
                    grdfromAccessory.DataSource = null;
                    grdfromAccessory.DataBind();

                }

            }


        }

        protected void searchContractTo_Click(object sender, EventArgs e)
        {
            if (ddlType.SelectedItem.Value == "1"  && txtsearchContractTo.Text.Trim()!=string.Empty)
            {
                string filter = "SerialNumber Like '%" + txtsearchContractTo.Text.Trim() + "%'";
                DataTable DT = Todt.Select(filter).CopyToDataTable();
                if (DT.Rows.Count > 0)
                {
                    grdto.DataSource = DT;
                    grdto.DataBind();
                }
                else
                {

                    grdto.DataSource = null;
                    grdto.DataBind();

                }
            }
            else if (ddlType.SelectedItem.Value == "2" && txtsearchContractTo.Text.Trim()!=string.Empty)
            {

                string filter = "SerialNumber Like  '%" + txtsearchContractTo.Text.Trim() + "%'";
                DataTable DT = TodtAcc.Select(filter).CopyToDataTable();
                if (DT.Rows.Count > 0)
                {
                    grdToAccessory.DataSource = DT;
                    grdToAccessory.DataBind();
                }
                else
                {
                    grdToAccessory.DataSource = null;
                    grdToAccessory.DataBind();
                }

            }
        }

        protected void BtnsubmitAcc_Click(object sender, EventArgs e)
        {
            BindParmAcc();
            try
            {
                foreach (GridViewRow Gvr in grdfromAccessory.Rows)
                {
                    TextBox txtSubtract = (TextBox)Gvr.FindControl("txtSubtract");
                    if (txtSubtract.Text != string.Empty)
                    {
                        if (Convert.ToInt32(txtSubtract.Text) > 0)
                        {
                            PassQtyToMove = Convert.ToInt32(txtSubtract.Text);
                            HiddenField hdnOrderDetailsidFrom = Gvr.FindControl("hdnOrderDetailsid") as HiddenField;
                            HiddenField hdnFabricDetailsFrm = Gvr.FindControl("hdnFabricDetailsFrm") as HiddenField;
                            FromOrderDetailsId = Convert.ToInt32(hdnOrderDetailsidFrom.Value);
                            if (string.IsNullOrEmpty(txtAccessoryColor.Text) && !string.IsNullOrEmpty(hdnFabricDetailsFrm.Value))
                            {
                                FrmFabricDetails = hdnFabricDetailsFrm.Value;

                            }

                        }
                    }
                }
                foreach (GridViewRow GVR in grdToAccessory.Rows)
                {
                    string Flag = "Accessory";

                    TextBox txtAdd = GVR.FindControl("txtAdd") as TextBox;
                    if (txtAdd.Text != string.Empty)
                    {
                        if (Convert.ToInt32(txtAdd.Text) > 0)
                        {
                            HiddenField hdnOrderDetailsidTo = GVR.FindControl("hdnOrderDetailsid") as HiddenField;
                            HiddenField hdnFabricDetailsTo = GVR.FindControl("hdnFabricDetailsTo") as HiddenField;
                            Label lblAllocated = GVR.FindControl("lblAllocated") as Label;
                            Label lblRequireQty = GVR.FindControl("lblRequireQty") as Label;
                            HiddenField hdnEditedReqQty = GVR.FindControl("hdnEditedReqQty") as HiddenField;

                            HiddenField hdnAccessoryMasterId = GVR.FindControl("hdnAccessoryMasterId") as HiddenField;
                            HiddenField hdnSize = GVR.FindControl("hdnSize") as HiddenField;

                            if (hdnEditedReqQty.Value.IndexOf(',') > -1)
                            {
                                ReqQtyToMove = Convert.ToInt32(txtAdd.Text.Replace(",", "")) + Convert.ToInt32(lblAllocated.Text == "" ? "0" : lblAllocated.Text.Replace(",", "")) + Convert.ToInt32(hdnEditedReqQty.Value.Replace(",", ""));
                            }
                            else
                            {
                                ReqQtyToMove = Convert.ToInt32(txtAdd.Text.Replace(",", "")) + Convert.ToInt32(lblAllocated.Text == "" ? "0" : lblAllocated.Text.Replace(",", "")) + Convert.ToInt32(hdnEditedReqQty.Value);

                            }
                            ToOrderDetailsId = Convert.ToInt32(hdnOrderDetailsidTo.Value);
                            if (string.IsNullOrEmpty(txtAccessoryColor.Text) && !string.IsNullOrEmpty(hdnFabricDetailsTo.Value))
                            {

                                ToFabricDetails = hdnFabricDetailsTo.Value;

                            }
                            objFabrciController.QuantityReallocationFabric_Accessory_FinalSattlement(FromOrderDetailsId, ToOrderDetailsId, FabricQualityID, FrmFabricDetails, ToFabricDetails, SupplyType, 1, PassQtyToMove, ReqQtyToMove, Convert.ToInt32(hdnUserId.Value), Flag,Convert.ToInt32(hdnAccessoryMasterId.Value),hdnSize.Value.ToString());

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "SuccessMsg('Qty. Moved Successfully. Please refresh the MO for Changes.')", true);

                        }
                    }

                }
                BindGrdFrom();
                BindGrdTo();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "FailedMsg('Some Error Occured, Please try Again.')", true);
            }

        }
    }
}