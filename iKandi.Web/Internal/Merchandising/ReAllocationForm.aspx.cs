using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using System.IO;
using System.Text;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class ReAllocationForm : System.Web.UI.Page
    {
        public int styleId
        {
            get;
            set;
        }

        public string remark
        {
            get;
            set;
        }
        public string exfactorydate
        {
            get;
            set;
        }
        public string stylenumber
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public int VA
        {
            get;
            set;
        }
        public int qtyallow
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public int PerdayProduction
        {
            get;
            set;
        }
        public double StatusFrom
        {
            get;
            set;
        }
        public double StatusTo
        {
            get;
            set;
        }
        public int DesignationId
        {
            get;
            set;
        }
        public string PO
        {
            get;
            set;
        }
        public string PONumber
        {
            get;
            set;
        }
        iKandi.BLL.OrderController OrderControllerInstance = new BLL.OrderController();
        iKandi.BLL.AdminController ObjAdminController = new BLL.AdminController();
        iKandi.BLL.PermissionController PermissionControllerInstance = new BLL.PermissionController();

        Boolean InHouseFact = false;
        int SupplierCount = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;


            string baseSiteUrl = Constants.BaseSiteUrl.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            string siteBaseUrl = Constants.SITE_BASE_URL.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            if (baseSiteUrl.Contains(siteBaseUrl))
            {
                Page.Title = "IKANDI FASHION";
            }
            else
            {
                Page.Title = "Boutique International Pvt. Ltd.";
            }

            if (null != Request.QueryString["styleId"])
            {
                styleId = Convert.ToInt32(Request.QueryString["styleId"]);
            }
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                Session["OrderDetailId_Reallocation"] = OrderDetailId;
            }
            if (null != Request.QueryString["exfactorydate"])
            {
                exfactorydate = Request.QueryString["exfactorydate"].ToString();
            }
            if (null != Request.QueryString["stylenumber"])
            {
                stylenumber = Request.QueryString["stylenumber"].ToString();
            }
            if (null != Request.QueryString["PO"])
            {
                PO = Request.QueryString["PO"].ToString();
            }
            if (null != Request.QueryString["StatusFrom"])
            {
                StatusFrom = Convert.ToDouble(Request.QueryString["StatusFrom"]);
            }
            if (null != Request.QueryString["StatusTo"])
            {
                StatusTo = Convert.ToDouble(Request.QueryString["StatusTo"]);
            }
            if (null != Request.QueryString["PONumber"])
            {
                PONumber = Request.QueryString["PONumber"];
            }

            if (null != Request.QueryString["OrderDetailId"])
            {
                hdnStyleId.Value = Convert.ToInt32(Request.QueryString["styleId"]).ToString();
                //hdnOrderDetailId.Value = "45004";
            }

            if (!IsPostBack)
            {
                BindControl();

                if (Session["IsSave"] != null)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Page save successfully.');$('#spinnL').css('display', 'none');", true);
                }
            }
            Session["IsSave"] = null;
            int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            // hdnDesignationId.Value = DesignationId.ToString();

            //if (DesignationId == 45)
            //{
            //    btnSubmitVa_Click.Visible = false;

            //}
            //else
            //{
            //    btnSubmitVa_Click.Visible = true;
            //}

            //added by raghvinder on 28-08-2020 starts

            DataTable dt = PermissionControllerInstance.GetUserPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, DesignationId, (int)iKandi.Common.AppModuleColumn.REALLOCATION_FORM_SUBMIT_BUTTON).Tables[0];
            bool readPermission = false;
            bool writePermission = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                readPermission = Convert.ToBoolean(dt.Rows[i]["PermisionRead"]);
                writePermission = Convert.ToBoolean(dt.Rows[i]["PermisionWrite"]);
            }


            if (writePermission == true)
            {
                btnSubmit.Enabled = true;
                btnVA_Details.Enabled = true;
                btnVA_Quantity_Allocation.Enabled = true;
                btnSubmitVa_Click.Enabled = true;
                btnCommiteddatesave.Enabled = true;


            }
            else
            {
                btnSubmit.Enabled = false;
                btnVA_Details.Enabled = false;
                btnVA_Quantity_Allocation.Enabled = false;
                btnSubmitVa_Click.Enabled = false;
                btnCommiteddatesave.Enabled = false;
            }
            //added by raghvinder on 28-08-2020 end

            if (PO == "Yes")
            {
                grdVA_Quantity_Allocation.Visible = false;
                lblMsg.Visible = false;
                btnVA_Quantity_Allocation.Visible = false;
                btnStitchRell.Visible = false;
                stitch.Visible = false;
                widthdiv.Visible = false;
                //btnVARell.Visible = false;
            }
            if (PO == "OutHouse")
            {
                grdVA_Quantity_Allocation.Visible = true;
                lblMsg.Visible = true;
                btnVA_Quantity_Allocation.Visible = true;
                btnStitchRell.Visible = true;
                stitch.Visible = true;
                widthdiv.Visible = true;
                //btnVARell.Visible = false;
            }

        }
        public void BindControlva(int orderdetailsID)
        {
            DataTable dt = OrderControllerInstance.Get_VA_Details(styleId);
            if (dt.Rows.Count > 0)
            {
                gvVA_Details.DataSource = dt;
                gvVA_Details.DataBind();


                List<MoShippingDetail> ds = OrderControllerInstance.GetQuantity_Allocation_Details(styleId, StatusFrom, StatusTo);
                grdVA_Quantity_Allocation.DataSource = ds;
                grdVA_Quantity_Allocation.DataBind();

            }
            else
            {
                btnVARell.Visible = false;
            }
            //int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;

            //if (DesignationId == 45)
            //{
            //    txt1QtyAllowOutHouse.Disabled = true;
            //    txt1allowsstartDate.Disabled = true;
            //    txt1Perdayprod.Disabled = true;
            //    txtIntialAgreementRate1.Enabled = false;
            //    txtva1.Enabled = false;
            //    txtv1rate.Enabled = false;
            //    txtv1supplier.Enabled = false;
            //    txtIntialAgreementRate2.Enabled = false;
            //    txtv2.Enabled = false;
            //    txtv2rate.Enabled = false;
            //    txtv2supplier.Enabled = false;
            //    txt2QtyAllowOutHouse.Disabled = true;
            //    txt2allowsstartDate.Disabled = true;
            //    txt2Perdayprod.Disabled = true;
            //}
        }
        public void BindControlStitchva(int orderDetailsID)
        {
            if (orderDetailsID == 0)
            {

                orderDetailsID = OrderDetailId;
            }
            grdStitchva.DataSource = OrderControllerInstance.GetReAllocationStyleContactDetails(styleId, 2, orderDetailsID, StatusTo);
            grdStitchva.DataBind();
        }
        public void BindControl()
        {
            DataTable dt = OrderControllerInstance.GetReAllocationStyleContactDetails(styleId, 0, 0, StatusTo);
            //added by abhishek on 29/8/2018
            DataTable dtCommited = OrderControllerInstance.GetReAllocationStyleContactDetails(styleId, 3, 0, StatusTo);
            if (dtCommited.Rows.Count > 0)
            {
                btnCommiteddatesave.Visible = true;
                grdReallCommitedEndDate.DataSource = dtCommited;
                grdReallCommitedEndDate.DataBind();
            }
            if (dt.Rows.Count > 0)
            {
                grdcontact.DataSource = dt;
                grdcontact.DataBind();

                GridViewRow head = grdcontact.HeaderRow;
                CheckBox CheckHeadercontact = head.FindControl("CheckHeadercontact") as CheckBox;
                int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
                if (DesignationId == 45)
                {
                    CheckHeadercontact.Enabled = false;
                }

                SetCheckBox();
            }
            grdStitchva.DataSource = OrderControllerInstance.GetReAllocationStyleContactDetails(styleId, 2, Convert.ToInt32(Session["OrderDetailId_Reallocation"]), StatusTo);
            grdStitchva.DataBind();
            //Add By Prabhaker 06-11-17
            DataTable dtValueRealloctionProduction = OrderControllerInstance.GetReAllocationStyle_PerDayQty(styleId);
            var RowCount = dtValueRealloctionProduction.Rows.Count;
            RowCount = RowCount - 1;
            if (dtValueRealloctionProduction.Rows.Count > 0)
            {
                for (int i = 0; i <= RowCount; i++)
                {
                    //if (txtva1.Text == dtValueRealloctionProduction.Rows[i]["VAName"].ToString())
                    //{
                    //    txt1QtyAllowOutHouse.Value = dtValueRealloctionProduction.Rows[i]["Quantity"].ToString();
                    //    if (dtValueRealloctionProduction.Rows[i]["StartDate"].ToString() != "")
                    //    {
                    //        txt1allowsstartDate.Value = Convert.ToDateTime(dtValueRealloctionProduction.Rows[i]["StartDate"]).ToString("dd MMM yy");
                    //    }
                    //    else
                    //    {
                    //        txt1allowsstartDate.Value = "";
                    //    }
                    //    txt1Perdayprod.Value = dtValueRealloctionProduction.Rows[i]["PerDayOutput"].ToString();
                    //    if (dtValueRealloctionProduction.Rows[i]["EndDate"].ToString() != "")
                    //        lblEndDate_1.Text = Convert.ToDateTime(dtValueRealloctionProduction.Rows[i]["EndDate"]).ToString("dd MMM yy");
                    //    else
                    //        lblEndDate_1.Text = "";
                    //}

                    //if (txtv2.Text == dtValueRealloctionProduction.Rows[i]["VAName"].ToString())
                    //{
                    //    txt2QtyAllowOutHouse.Value = dtValueRealloctionProduction.Rows[i]["Quantity"].ToString();
                    //    if (dtValueRealloctionProduction.Rows[i]["StartDate"].ToString() != "")
                    //    {
                    //        txt2allowsstartDate.Value = Convert.ToDateTime(dtValueRealloctionProduction.Rows[i]["StartDate"]).ToString("dd MMM yy");
                    //    }
                    //    else
                    //    {
                    //        txt2allowsstartDate.Value = "";
                    //    }
                    //    txt2Perdayprod.Value = dtValueRealloctionProduction.Rows[i]["PerDayOutput"].ToString();
                    //    if (dtValueRealloctionProduction.Rows[i]["EndDate"].ToString() != "")
                    //        lblEndDate2.Text = Convert.ToDateTime(dtValueRealloctionProduction.Rows[i]["EndDate"]).ToString("dd MMM yy");
                    //    else
                    //        lblEndDate2.Text = "";
                    //}
                }
            }


            //End Of COde
            List<MoShippingDetail> ds = OrderControllerInstance.GetReAllocationDetails(styleId, StatusFrom, StatusTo);
            lblStyleNumber.Text = ds.Count > 0 ? ds[0].StyleNumber.ToString() : "";
            gvReAllocation.DataSource = ds;
            gvReAllocation.DataBind();
        }
        protected void grdReallCommitedEndDate_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            TextBox txtCommitted_EndDate = (TextBox)e.Row.FindControl("txtCommitted_EndDate");
            if (txtCommitted_EndDate.Text != "")
            {
                txtCommitted_EndDate.Enabled = false;
                txtCommitted_EndDate.Style.Add("border", "0px solid #808080 !important");
            }
        }
        protected void gvReAllocation_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType != DataControlRowType.DataRow)
            //    return;
            //int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            //if (DesignationId == 45)
            //{



            //added by raghvinder on 09-09-2020 start
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                foreach (DataControlFieldCell cell in e.Row.Cells)
                {

                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;

                        if (button != null && button.CommandName == "AddNew")
                        {

                            DataTable dt = PermissionControllerInstance.GetUserPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, (int)iKandi.Common.AppModuleColumn.REALLOCATION_DELETE).Tables[0];

                            bool writePermission = false;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                writePermission = Convert.ToBoolean(dt.Rows[i]["PermisionWrite"]);
                            }


                            if (writePermission == true)
                            {
                                button.Enabled = true;
                            }
                            else
                            {
                                button.Enabled = false;
                            }
                            //added by raghvinder on 09-09-2020 end

                            gvReAllocation.HeaderRow.Cells[7].Text = "<table cellpadding='0' cellspacing='0' width='100%' style='height:100%;'>" +
                        "<tr><th style='width:80px;' height='100%' rowspan='2'>Factory</th><th style='width:65px;' height='100%' rowspan='2'>Not Loaded</th>" +
                        "<th style='width:65px; border-bottom:1px solid #c2b9b9 !important;' height='100%' >Cutting Allo.</th>" +
                        "<th style='width:65px; border-bottom:1px solid #c2b9b9 !important;' height='100%'>Tdy. cut issue</th>" +
                       "<th style='width:66px;' height='100%' rowspan='2'>Stitching allocation</th>" +
                        "<th style='width:61px;' height='100%' rowspan='2'>Finishing Allocation</th>" +
                        "" +
                          "<th style='width:75px;' height='100%' rowspan='2'>Commited End Date</th>" +
                       "</tr><tr>" +
                        "<th style='width:65px;' height='100%'> Total Cut Ready.</th>" +
                       "<th style='width:65px;' height='100%'>Total cut issue</th>" +
                       "" +
                         "</tr></table>";
                        }
                        else
                        {
                            gvReAllocation.HeaderRow.Cells[7].Text = "<table cellpadding='0' cellspacing='0' width='100%' style='height:100%;'>" +
                            "<tr><th style='width:80px;' height='100%' rowspan='2'>Factory</th><th style='width:65px;' height='100%' rowspan='2'>Not Loaded</th>" +
                            "<th style='width:65px; border-bottom:1px solid #c2b9b9 !important;' height='100%' >Cutting Allo.</th>" +
                            "<th style='width:65px; border-bottom:1px solid #c2b9b9 !important;' height='100%'>Tdy. cut issue</th>" +
                           "<th style='width:66px;' height='100%' rowspan='2'>Stitching allocation</th>" +
                            "<th style='width:61px;' height='100%' rowspan='2'>Finishing Allocation</th>" +
                            "" +
                              "<th style='width:75px;' height='100%' rowspan='2'>Committed End Date</th>" +
                                //"<th style='width:70px;' height='100%' rowspan='2'>Man power employed</th>" +
                                //"<th style='width:100px; border-bottom:1px solid #c2b9b9 !important;' height='100%'>QC </th>" +
                                //"<th style='width:70px;' height='100%' rowspan='2'>Stitching complete</th>" +
                           "<th style='width:20px;border-right:0!important' height='100%;' rowspan='2'></th></tr><tr>" +
                            "<th style='width:65px;' height='100%'> Total Cut Ready.</th>" +
                           "<th style='width:65px;' height='100%'>Total cut issue</th>" +
                           "" +
                                //"<th style='width:100px;' height='100%'>Checker </th></tr></table>";
                            "</tr></table>";
                        }

                        //added by raghvinder on 09-09-2020 start

                    }
                }
            }


            //added by raghvinder on 09-09-2020 end

            MoShippingDetail od = (e.Row.DataItem as MoShippingDetail);
            e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml(od.ExFactoryColor);
            GridView gvChildReallocation = (GridView)e.Row.FindControl("gvChildReallocation");
            ImageButton imgbtnAdd = (ImageButton)e.Row.FindControl("imgbtnAdd");
            RadioButtonList rbtnPartialFull = (RadioButtonList)e.Row.FindControl("rbtnPartialFull");
            HiddenField hdnOrderDetailsId = (HiddenField)e.Row.FindControl("hdnOrderDetailsId");
            CheckBox cb = (CheckBox)e.Row.FindControl("cb");

            HtmlAnchor txtQuantity = (HtmlAnchor)e.Row.FindControl("txtQuantity");

            int OrderDetailsId = 0;

            DataSet dsAllocation = new DataSet();
            OrderDetailsId = Convert.ToInt32(hdnOrderDetailsId.Value.Replace(",", ""));
            dsAllocation = OrderControllerInstance.GetReAllocationDetailsById(OrderDetailsId, 0);

            DataTable dtQcChecker = dsAllocation.Tables[8];
            ViewState["dtQcChecker"] = dtQcChecker;
            int TotalLineQty = 0;
            foreach (DataRow dr in dsAllocation.Tables[0].Rows)
            {
                if (dr["LineQty"].ToString().Replace(",", "") != "")
                {
                    //int lineqty = dr["LineQty"].ToString().Replace(",", "");
                    TotalLineQty = TotalLineQty + Convert.ToInt32(dr["LineQty"].ToString().Replace(",", ""));
                }
            }

            txtQuantity.HRef = "/Internal/Merchandising/AllocatedWithFactory.aspx?OrderDetailId=" + OrderDetailsId + "&StyleId=" + styleId;

            if (cb.Checked)
            {
                if (TotalLineQty > 0)
                {
                    txtQuantity.Attributes.Add("class", "enable");
                }
                else
                {
                    txtQuantity.Attributes.Add("class", "disable");
                }
            }
            else
            {
                txtQuantity.Attributes.Add("class", "disable");
            }

            dsAllocation.Tables[0].Columns.Add("UnAssignCuttingQty", typeof(System.Int32));
            dsAllocation.Tables[0].Columns.Add("UnAssignFinishingQty", typeof(System.Int32));
            foreach (DataRow row in dsAllocation.Tables[0].Rows)
            {
                row["UnAssignCuttingQty"] = 0;
                row["UnAssignFinishingQty"] = 0;
            }


            gvChildReallocation.DataSource = dsAllocation.Tables[0];
            gvChildReallocation.DataBind();
            if (dsAllocation.Tables[1].Rows.Count > 0)
            {
                bool IsPartialOrFull = Convert.ToBoolean(dsAllocation.Tables[1].Rows[0]["IsPartialOrFull"]);
                bool IsRealocationFull = Convert.ToBoolean(dsAllocation.Tables[1].Rows[0]["IsRealocationFull"]);
                if (IsPartialOrFull == true)
                {
                    rbtnPartialFull.SelectedValue = "1";
                    imgbtnAdd.Visible = true;
                }
                else
                {
                    rbtnPartialFull.SelectedValue = "0";
                    imgbtnAdd.Visible = false;
                }
                if (IsRealocationFull == true)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
            else
            {
                rbtnPartialFull.SelectedValue = "0";
                cb.Checked = false;
                imgbtnAdd.Visible = false;
            }

            if (cb.Checked == false)
            {
                imgbtnAdd.Enabled = false;
                rbtnPartialFull.Enabled = false;
                //gvChildReallocation.Enabled = false;
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                    txtStitching1.Attributes.Add("class", "disable");
                    HtmlAnchor txtCutting1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtCutting1");
                    txtCutting1.Attributes.Add("class", "disable");
                    HtmlAnchor txtFinishing1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtFinishing1");
                    txtFinishing1.Attributes.Add("class", "disable");
                }
            }
            else
            {
                imgbtnAdd.Enabled = true;
                rbtnPartialFull.Enabled = true;

                gvChildReallocation.Enabled = true;
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                    txtStitching1.Attributes.Add("class", "enable");
                    HtmlAnchor txtCutting1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtCutting1");
                    txtCutting1.Attributes.Add("class", "enable");
                    HtmlAnchor txtFinishing1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtFinishing1");
                    txtFinishing1.Attributes.Add("class", "enable");
                }
            }
            if (DesignationId == 45)
            {
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlFactory");
                    TextBox txtCutting = (TextBox)gvChildReallocation.Rows[i].FindControl("txtCutting");
                    TextBox txtStitching = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStitching");
                    TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[i].FindControl("txtFinishing");
                    TextBox txtStichingunallocated = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStichingunallocated");
                    TextBox txtTdyCutReady = (TextBox)gvChildReallocation.Rows[i].FindControl("txtTdyCutReady");
                    TextBox txtTdyCutIssueOutHouse = (TextBox)gvChildReallocation.Rows[i].FindControl("txtTdyCutReady");
                    // TextBox txtOutHouseQc = (TextBox)gvChildReallocation.Rows[i].FindControl("txtOutHouseQc");
                    //    TextBox txtOutHouseManpower = (TextBox)gvChildReallocation.Rows[i].FindControl("txtOutHouseManpower");
                    HiddenField hdnunitid = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnunitid");
                    gvChildReallocation.Rows[i].Cells[10].Visible = false;
                    imgbtnAdd.Visible = false;
                    ddlFactory.Enabled = false;
                    txtStichingunallocated.Enabled = false;
                    txtTdyCutReady.Enabled = false;
                    txtTdyCutIssueOutHouse.Enabled = false;
                    txtStitching.Enabled = false;
                    txtFinishing.Enabled = false;
                    //   txtOutHouseQc.Enabled = true;
                    ////   txtOutHouseManpower.Enabled = true;
                    //   if (hdnunitid.Value == "3" || hdnunitid.Value == "11")            
                    //   {
                    //       txtOutHouseQc.Enabled = false;
                    //  //     txtOutHouseManpower.Enabled = false;
                    //   }                 

                }

            }
        }

        protected void gvReAllocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {

                DataTable dtReAllocationUnit = OrderControllerInstance.GetReAllocationUnit(0, 0).Tables[0];
                int id = int.Parse(e.CommandArgument.ToString());
                GridView gvChildReallocation = (GridView)gvReAllocation.Rows[id].FindControl("gvChildReallocation");

                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlFactory");
                    TextBox txtCutting = (TextBox)gvChildReallocation.Rows[i].FindControl("txtCutting");
                    TextBox txtStitching = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStitching");
                    TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[i].FindControl("txtFinishing");
                    TextBox txtStichingunallocated = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStichingunallocated");
                    HiddenField hdnReAllocation = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnReAllocation");
                    HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnlineQty");
                    HiddenField hdnorderdetail = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnorderdetail");
                    HiddenField hdnunitid = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnunitid");
                    HiddenField hdnStitching = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnStitching");
                    HiddenField hdnIsOHStitchComplete = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnIsOHStitchComplete");

                    CheckBox chkIsOHStitchComplete = (CheckBox)gvChildReallocation.Rows[i].FindControl("chkIsOHStitchComplete");

                    Label lblStartDate = (Label)gvChildReallocation.Rows[i].FindControl("lblStartDate");

                    Label lblEndDate = (Label)gvChildReallocation.Rows[i].FindControl("lblEndDate");

                    Label lblStitchedQty = (Label)gvChildReallocation.Rows[i].FindControl("lblStitchedQty");

                    Label lblPerDayOutPut = (Label)gvChildReallocation.Rows[i].FindControl("lblPerDayOutPut");

                    if (txtCutting.Text == "" && txtStitching.Text == "" && txtFinishing.Text == "")
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Blank row need to be filled first.');$('#spinnL').css('display', 'none');", true);
                        return;
                    }
                }

                if ((dtReAllocationUnit.Rows.Count - 1) == gvChildReallocation.Rows.Count)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot add rows more than Factory count.');$('#spinnL').css('display', 'none');", true);
                    return;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    DataTable dtmerge = new DataTable();

                    dtnew = gridTable(gvChildReallocation);
                    DataRow newrow = dtnew.NewRow();
                    dtnew.Rows.Add(newrow);
                    dtnew.Rows[dtnew.Rows.Count - 1]["Committed_EndDate"] = "1900-01-01";
                    dtmerge = dtnew;

                    dtmerge.Columns.Add("UnAssignCuttingQty", typeof(System.Int32));
                    dtmerge.Columns.Add("UnAssignFinishingQty", typeof(System.Int32));
                    foreach (DataRow row in dtmerge.Rows)
                    {
                        row["UnAssignCuttingQty"] = 0;
                        row["UnAssignFinishingQty"] = 0;
                    }

                    gvChildReallocation.DataSource = dtmerge;
                    gvChildReallocation.DataBind();
                }
            }
        }

        private DataTable gridTable(GridView grdTable)
        {
            DataTable dtChildReallocation = new DataTable();

            dtChildReallocation.Columns.Add("Factory");
            dtChildReallocation.Columns.Add("UnAllocatedQty");
            dtChildReallocation.Columns.Add("Cutting");
            dtChildReallocation.Columns.Add("Stitching");
            dtChildReallocation.Columns.Add("Finishing");

            dtChildReallocation.Columns.Add("StartDate");
            dtChildReallocation.Columns.Add("EndDate");
            dtChildReallocation.Columns.Add("StitchedQty");
            dtChildReallocation.Columns.Add("PerDayOutPut");
            dtChildReallocation.Columns.Add("Committed_EndDate");

            dtChildReallocation.Columns.Add("ReallocationID");
            dtChildReallocation.Columns.Add("LineQty");
            dtChildReallocation.Columns.Add("OrderDetailID");
            dtChildReallocation.Columns.Add("UnitID");
            dtChildReallocation.Columns.Add("DoneStitching");
            dtChildReallocation.Columns.Add("DoneCutting");
            dtChildReallocation.Columns.Add("DoneFinishing");
            dtChildReallocation.Columns.Add("TodayCutReadyOutHouse");
            dtChildReallocation.Columns.Add("TodayCutIssueOutHouse");
            dtChildReallocation.Columns.Add("OutHouseManpower");
            dtChildReallocation.Columns.Add("OutHouseQC");
            dtChildReallocation.Columns.Add("TotalCutting");

            dtChildReallocation.Columns.Add("OutHouseChecker");
            dtChildReallocation.Columns.Add("QcCheckerID");
            dtChildReallocation.Columns.Add("OHStitchComplete");
            foreach (GridViewRow row in grdTable.Rows)
            {
                DataRow dr = dtChildReallocation.NewRow();

                DropDownList ddlFactory = (DropDownList)row.Cells[0].FindControl("ddlFactory");
                TextBox txtStichingunallocated = (TextBox)row.Cells[1].FindControl("txtStichingunallocated");
                TextBox txtCutting = (TextBox)row.Cells[2].FindControl("txtCutting");
                HtmlAnchor txtCutting1 = (HtmlAnchor)row.Cells[2].FindControl("txtCutting1");
                HiddenField hdnDoneCuttingQty = (HiddenField)row.Cells[2].FindControl("hdnDoneCuttingQty");
                TextBox txtStitching = (TextBox)row.Cells[5].FindControl("txtStitching");
                HtmlAnchor txtStitching1 = (HtmlAnchor)row.Cells[5].FindControl("txtStitching1");
                //TextBox txtStitching1 = (TextBox)row.Cells[3].FindControl("txtStitching1");
                TextBox txtFinishing = (TextBox)row.Cells[5].FindControl("txtFinishing");
                TextBox txtCommitted_EndDate = (TextBox)row.Cells[9].FindControl("txtCommitted_EndDate");
                HtmlAnchor txtFinishing1 = (HtmlAnchor)row.Cells[4].FindControl("txtFinishing1");
                HiddenField hdnDoneFinishingQty = (HiddenField)row.Cells[5].FindControl("hdnDoneFinishingQty");
                HiddenField hdnReAllocation = (HiddenField)row.Cells[5].FindControl("hdnReAllocation");
                HiddenField hdnlineQty = (HiddenField)row.Cells[5].FindControl("hdnlineQty");
                HiddenField hdnorderdetail = (HiddenField)row.Cells[5].FindControl("hdnorderdetail");
                HiddenField hdnunitid = (HiddenField)row.Cells[5].FindControl("hdnunitid");
                HiddenField hdnStitching = (HiddenField)row.Cells[5].FindControl("hdnStitching");

                //  HiddenField hdnQcCheckerID = (HiddenField)row.Cells[5].FindControl("hdnQcCheckerID");
                Label lblStartDate = (Label)row.Cells[6].FindControl("lblStartDate");

                Label lblEndDate = (Label)row.Cells[6].FindControl("lblEndDate");

                Label lblStitchedQty = (Label)row.Cells[7].FindControl("lblStitchedQty");

                Label lblPerDayOutPut = (Label)row.Cells[8].FindControl("lblPerDayOutPut");

                TextBox txtTdyCutReady = (TextBox)row.Cells[2].FindControl("txtTdyCutReady");
                TextBox txtTdyCutIssueOutHouse = (TextBox)row.Cells[3].FindControl("txtTdyCutIssueOutHouse");
                // TextBox txtOutHouseManpower = (TextBox)row.Cells[9].FindControl("txtOutHouseManpower");
                // TextBox txtOutHouseQc = (TextBox)row.Cells[10].FindControl("txtOutHouseQc");
                Label lblTotalCutting = (Label)row.Cells[3].FindControl("lblTotalCutting");
                //  TextBox txtOutHouseQcChecker = (TextBox)row.Cells[10].FindControl("txtOutHouseQcChecker");
                //Add By Prabhaker on 06-mar-18
                //DropDownList ddlchecker = (DropDownList)row.Cells[10].FindControl("ddlchecker");

                CheckBox chkIsOHStitchComplete = (CheckBox)row.Cells[9].FindControl("chkIsOHStitchComplete");
                HiddenField hdnIsOHStitchComplete = (HiddenField)row.Cells[5].FindControl("hdnIsOHStitchComplete");
                // End of Code
                string sStitching = StripTagsRegex(txtStitching1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtStitching1.InnerHtml).Trim();
                string sCutting = StripTagsRegex(txtCutting1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtCutting1.InnerHtml).Trim();
                string sFinishing = StripTagsRegex(txtFinishing1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtFinishing1.InnerHtml).Trim();
                string sCommitted_EndDate = StripTagsRegex(txtCommitted_EndDate.Text).Trim() == "" ? "" : StripTagsRegex(txtCommitted_EndDate.Text).Trim();

                dr["Factory"] = ddlFactory.Text;
                dr["UnAllocatedQty"] = txtStichingunallocated.Text;

                //dr["Cutting"] = txtCutting.Text;
                if (txtCutting.Visible)
                {
                    dr["Cutting"] = txtCutting.Text;
                }
                else
                {
                    dr["Cutting"] = sCutting;
                }

                if (txtStitching.Visible)
                {
                    dr["Stitching"] = txtStitching.Text;
                }
                else
                {
                    dr["Stitching"] = sStitching;
                }

                //dr["Finishing"] = txtFinishing.Text;
                if (txtFinishing.Visible)
                {
                    dr["Finishing"] = txtFinishing.Text;
                }
                else
                {
                    dr["Finishing"] = sFinishing;
                }

                if (txtCommitted_EndDate.Text.Trim() == "")
                {
                    sCommitted_EndDate = "1900-01-01";
                }
                else
                {
                    sCommitted_EndDate = txtCommitted_EndDate.Text.Trim().Substring(0, txtCommitted_EndDate.Text.Trim().Length - 6);
                }
                dr["ReallocationID"] = hdnReAllocation.Value;
                dr["LineQty"] = hdnlineQty.Value;
                dr["OrderDetailID"] = hdnorderdetail.Value;
                dr["UnitID"] = hdnunitid.Value;
                dr["DoneStitching"] = hdnStitching.Value;
                dr["DoneCutting"] = hdnDoneCuttingQty.Value;
                dr["DoneFinishing"] = hdnDoneFinishingQty.Value;
                dr["Committed_EndDate"] = sCommitted_EndDate;
                dr["OHStitchComplete"] = hdnIsOHStitchComplete.Value;

                dtChildReallocation.Rows.Add(dr);
            }
            return dtChildReallocation;
        }

        private DataTable gridTableVA(GridView grdTable)
        {
            DataTable dtChildVA = new DataTable();

            dtChildVA.Columns.Add("SupplierName");
            dtChildVA.Columns.Add("Rate");
            dtChildVA.Columns.Add("Finalize", typeof(bool));
            dtChildVA.Columns.Add("RiskSupplierID");    //new added


            foreach (GridViewRow row in grdTable.Rows)
            {
                DataRow dr = dtChildVA.NewRow();

                TextBox txtSupplier = (TextBox)row.Cells[0].FindControl("txtSupplier");
                TextBox txtInitial_Agreed_Rate = (TextBox)row.Cells[1].FindControl("txtInitial_Agreed_Rate");
                HiddenField hdnFianlize = (HiddenField)row.Cells[2].FindControl("hdnFianlize");
                CheckBox chkFinalize = (CheckBox)row.Cells[2].FindControl("chkFinalize");
                HiddenField hdnRiskSupplierID = (HiddenField)row.Cells[2].FindControl("hdnRiskSupplierID"); //new added


                if (chkFinalize.Checked == true)
                {
                    hdnFianlize.Value = "true";
                }
                else
                {
                    hdnFianlize.Value = "false";
                }


                dr["SupplierName"] = txtSupplier.Text;
                dr["Rate"] = txtInitial_Agreed_Rate.Text;
                dr["Finalize"] = hdnFianlize.Value;
                dr["RiskSupplierID"] = hdnRiskSupplierID.Value; //new added

                dtChildVA.Rows.Add(dr);
            }
            return dtChildVA;
        }

        private DataTable gridTableVARellocation(GridView grdTable)
        {
            DataTable dtChildVA = new DataTable();

            dtChildVA.Columns.Add("SupplierId");
            dtChildVA.Columns.Add("AllocationQty1");
            dtChildVA.Columns.Add("AllocationQty2");
            dtChildVA.Columns.Add("PerDayOutPut");
            dtChildVA.Columns.Add("StartDate");
            dtChildVA.Columns.Add("EndDate");
            dtChildVA.Columns.Add("Committed_EndDate");



            foreach (GridViewRow row in grdTable.Rows)
            {
                DataRow dr = dtChildVA.NewRow();

                DropDownList ddlSupplier = (DropDownList)row.Cells[1].FindControl("ddlSupplierAllocation");
                TextBox txtAllocationQuantity1 = (TextBox)row.Cells[0].FindControl("txtAllocationQuantity1");
                TextBox txtPerDayOutPut = (TextBox)row.Cells[3].FindControl("txtPerdayOutput");
                TextBox txtAllocationQuantity2 = (TextBox)row.Cells[0].FindControl("txtAllocationQuantity2");
                Label lblStartDate = (Label)row.Cells[2].FindControl("lblStartDate");
                Label lblEndDate = (Label)row.Cells[2].FindControl("lblEndDate");
                TextBox txtCommitted_EndDate = (TextBox)row.Cells[4].FindControl("txtCommitted_EndDate");

                string sCommitted_EndDate = StripTagsRegex(txtCommitted_EndDate.Text).Trim() == "" ? "" : StripTagsRegex(txtCommitted_EndDate.Text).Trim();
                if (txtCommitted_EndDate.Text.Trim() == "")
                {
                    sCommitted_EndDate = "1900-01-01";
                }
                else
                {
                    sCommitted_EndDate = txtCommitted_EndDate.Text.Trim().Substring(0, txtCommitted_EndDate.Text.Trim().Length - 6);
                }
                dr["SupplierId"] = ddlSupplier.Text;
                dr["AllocationQty1"] = txtAllocationQuantity1.Text;
                dr["AllocationQty2"] = txtAllocationQuantity2.Text;
                dr["PerDayOutPut"] = txtPerDayOutPut.Text;
                dr["Committed_EndDate"] = sCommitted_EndDate;

                dtChildVA.Rows.Add(dr);
            }
            return dtChildVA;
        }

        protected void rbtnPartialFull_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((RadioButtonList)sender).NamingContainer as GridViewRow;
            GridView gvChildReallocation = (GridView)row.FindControl("gvChildReallocation");


            RadioButtonList rbtnPartialFull = (RadioButtonList)row.FindControl("rbtnPartialFull");
            ImageButton imgbtnAdd = (ImageButton)row.FindControl("imgbtnAdd");
            int radiobuttonVal = Convert.ToInt32(rbtnPartialFull.SelectedValue);

            if (radiobuttonVal == 1)
            {
                foreach (GridViewRow ChildRow in gvChildReallocation.Rows)
                {
                    TextBox txtCutting = ChildRow.Cells[2].Controls[0].FindControl("txtCutting") as TextBox;
                    if (DesignationId != 45)
                    {
                        txtCutting.Enabled = true;
                    }
                    else
                    {
                        txtCutting.Enabled = false;
                    }
                }


                imgbtnAdd.Visible = true;
            }
            if (radiobuttonVal == 0)
            {
                if (gvChildReallocation.Rows.Count > 1)
                {
                    rbtnPartialFull.SelectedValue = "1";
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot select Full because it is already divided into two or more than factories.');$('#spinnL').css('display', 'none');", true);
                }
                else
                {
                    imgbtnAdd.Visible = false;
                }
            }
        }
        public void SetCheckBox()
        {
            int count = 0;
            foreach (GridViewRow gvrow in grdcontact.Rows)
            {
                CheckBox cbcontact = (CheckBox)gvrow.FindControl("cbcontact");
                HiddenField hdnOrderDetailsID = (HiddenField)gvrow.FindControl("hdnOrderDetailsID");

                if (cbcontact.Checked)
                {
                    count++;
                }
            }
            if (count == grdcontact.Rows.Count)
            {
                GridViewRow head = grdcontact.HeaderRow;
                CheckBox CheckHeadercontact = head.FindControl("CheckHeadercontact") as CheckBox;

                if (CheckHeadercontact != null)
                {
                    CheckHeadercontact.Checked = true;
                }
            }
        }



        protected void btnSubmitVaSection_Click(object sender, EventArgs e)
        {
            try
            {

                string Valueaddtion1 = string.Empty;
                string Valueaddtion2 = string.Empty;

                decimal Valueaddtion1_rate = 0;
                decimal Valueaddtion2_rate = 0;
                decimal IntialAgreementRate1 = 0;
                decimal IntialAgreementRate2 = 0;

                decimal stitchRate = 0;

                string VA_supplier1 = string.Empty;
                string VA_supplier2 = string.Empty;
                string VA_supplier3 = string.Empty;


                foreach (GridViewRow gvrow in grdStitchva.Rows)
                {

                    CheckBox cbcontact = (CheckBox)gvrow.FindControl("cbcontact");
                    HiddenField hdnOrderDetailsID = (HiddenField)gvrow.FindControl("hdnOrderDetailsID");
                    TextBox txtSupplierNameVa = (TextBox)gvrow.FindControl("txtSupplierNameVa");
                    TextBox txtStitchRateVa = (TextBox)gvrow.FindControl("txtStitchRateVa");
                    TextBox txtCuttingRate = (TextBox)gvrow.FindControl("txtCuttingRate");
                    TextBox txtFinishRate = (TextBox)gvrow.FindControl("txtFinishRate");
                    //RadioButton ChkisSelected = (RadioButton)gvrow.FindControl("ChkisSelected");
                    CheckBox chkSupplier = (CheckBox)gvrow.FindControl("chkSupplier");
                    CheckBox chkCuttingFinalise = (CheckBox)gvrow.FindControl("chkCuttingFinalise");
                    CheckBox chkFinishFinalise = (CheckBox)gvrow.FindControl("chkFinishFinalise");
                    //if (!string.IsNullOrEmpty(txtSupplierNameVa.Text.Trim()))
                    //{
                    //    if (string.IsNullOrEmpty(txtStitchRateVa.Text))
                    //    {
                    //        //spinnL.Attributes.Remove("style");
                    //        // pageLoad.Attributes.Remove("class");
                    //        Page page = HttpContext.Current.Handler as Page;
                    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter stitch rate.');$('#spinnL').css('display', 'none');", true);
                    //        gvrow.BackColor = System.Drawing.Color.Red;
                    //        return;

                    //    }


                    //}

                    //if (!string.IsNullOrEmpty(txtStitchRateVa.Text))
                    //{
                    //    if (string.IsNullOrEmpty(txtSupplierNameVa.Text.Trim()))
                    //    {
                    //        Page page = HttpContext.Current.Handler as Page;
                    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter supplier name.');$('#spinnL').css('display', 'none');", true);
                    //        gvrow.BackColor = System.Drawing.Color.Red;
                    //        return;
                    //        // Response.Redirect(Request.RawUrl);
                    //    }
                    //    // Response.Redirect(Request.RawUrl);
                    //}

                    //if (!string.IsNullOrEmpty(txtSupplierNameVa.Text.Trim()))
                    //{
                    //    if (string.IsNullOrEmpty(txtCuttingRate.Text))
                    //    {
                    //        //spinnL.Attributes.Remove("style");
                    //        // pageLoad.Attributes.Remove("class");
                    //        Page page = HttpContext.Current.Handler as Page;
                    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter Cutting rate.');$('#spinnL').css('display', 'none');", true);
                    //        gvrow.BackColor = System.Drawing.Color.Red;
                    //        return;

                    //    }


                    //}

                    //if (!string.IsNullOrEmpty(txtCuttingRate.Text))
                    //{
                    //    if (string.IsNullOrEmpty(txtSupplierNameVa.Text.Trim()))
                    //    {
                    //        Page page = HttpContext.Current.Handler as Page;
                    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter supplier name.');$('#spinnL').css('display', 'none');", true);
                    //        gvrow.BackColor = System.Drawing.Color.Red;
                    //        return;
                    //        // Response.Redirect(Request.RawUrl);
                    //    }
                    //    // Response.Redirect(Request.RawUrl);
                    //}

                    //if (!string.IsNullOrEmpty(txtSupplierNameVa.Text.Trim()))
                    //{
                    //    if (string.IsNullOrEmpty(txtFinishRate.Text))
                    //    {
                    //        //spinnL.Attributes.Remove("style");
                    //        // pageLoad.Attributes.Remove("class");
                    //        Page page = HttpContext.Current.Handler as Page;
                    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter Cutting rate.');$('#spinnL').css('display', 'none');", true);
                    //        gvrow.BackColor = System.Drawing.Color.Red;
                    //        return;

                    //    }


                    //}

                    //if (!string.IsNullOrEmpty(txtFinishRate.Text))
                    //{
                    //    if (string.IsNullOrEmpty(txtSupplierNameVa.Text.Trim()))
                    //    {
                    //        Page page = HttpContext.Current.Handler as Page;
                    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter supplier name.');$('#spinnL').css('display', 'none');", true);
                    //        gvrow.BackColor = System.Drawing.Color.Red;
                    //        return;
                    //        // Response.Redirect(Request.RawUrl);
                    //    }
                    //    // Response.Redirect(Request.RawUrl);
                    //}
                }


                foreach (GridViewRow gvrow in grdcontact.Rows)
                {
                    CheckBox cbcontact = (CheckBox)gvrow.FindControl("cbcontact");
                    HiddenField hdnOrderDetailsID = (HiddenField)gvrow.FindControl("hdnOrderDetailsID");

                    //if (cbcontact.Checked)
                    //{
                    int IsCheckboxchecked = (cbcontact.Checked == true ? 1 : 0);
                    int result = OrderControllerInstance.UpdateReAllocationStyleContactDetails(Valueaddtion1, Valueaddtion2, Valueaddtion1_rate, Valueaddtion2_rate, stitchRate, VA_supplier1, VA_supplier2, VA_supplier3, IntialAgreementRate1, IntialAgreementRate2, Convert.ToInt32(hdnOrderDetailsID.Value), IsCheckboxchecked, styleId);


                    //VA stitch update============================================================//

                    foreach (GridViewRow gvrowVA in grdStitchva.Rows)
                    {

                        string VA_Stch_Supplier = string.Empty;
                        decimal VA_Stch_Rate = 0;
                        decimal VA_Cut_Rate = 0;
                        decimal VA_Finished_Rate = 0;
                        int ID = 0;
                        int isFineLineCheck = 0;
                        int IsVaFinelCut = 0;
                        int IsVaFinelFinished = 0;


                        TextBox txtSupplierNameVa = (TextBox)gvrowVA.FindControl("txtSupplierNameVa");
                        TextBox txtStitchRateVa = (TextBox)gvrowVA.FindControl("txtStitchRateVa");
                        TextBox txtCuttingRate = (TextBox)gvrowVA.FindControl("txtCuttingRate");
                        TextBox txtFinishRate = (TextBox)gvrowVA.FindControl("txtFinishRate");
                        //RadioButton ChkisSelected = (RadioButton)gvrowVA.FindControl("ChkisSelected");
                        Label lblsequence = (Label)gvrowVA.FindControl("lblsequence");
                        CheckBox chkSupplier = (CheckBox)gvrowVA.FindControl("chkSupplier");
                        CheckBox chkCuttingFinalise = (CheckBox)gvrowVA.FindControl("chkCuttingFinalise");
                        CheckBox chkFinishFinalise = (CheckBox)gvrowVA.FindControl("chkFinishFinalise");

                        if (!string.IsNullOrEmpty(txtSupplierNameVa.Text.Trim()))
                            VA_Stch_Supplier = txtSupplierNameVa.Text.Trim();

                        if (!string.IsNullOrEmpty(txtStitchRateVa.Text))
                            VA_Stch_Rate = Convert.ToDecimal(txtStitchRateVa.Text.Trim());


                        if (!string.IsNullOrEmpty(txtCuttingRate.Text))
                            VA_Cut_Rate = Convert.ToDecimal(txtCuttingRate.Text.Trim());


                        if (!string.IsNullOrEmpty(txtFinishRate.Text))
                            VA_Finished_Rate = Convert.ToDecimal(txtFinishRate.Text.Trim());


                        ID = Convert.ToInt32(lblsequence.Text.Trim().Replace(",", ""));
                        if (chkSupplier.Checked)
                        //if (chkSupplier.Checked && CountCheckContract > 0)
                        {
                            isFineLineCheck = 1;
                        }
                        else
                        {
                            isFineLineCheck = 0;
                        }
                        if (chkCuttingFinalise.Checked)
                        //if (chkSupplier.Checked && CountCheckContract > 0)
                        {
                            IsVaFinelCut = 1;
                        }
                        else
                        {
                            IsVaFinelCut = 0;
                        }
                        if (chkFinishFinalise.Checked)
                        //if (chkSupplier.Checked && CountCheckContract > 0)
                        {
                            IsVaFinelFinished = 1;
                        }
                        else
                        {
                            IsVaFinelFinished = 0;
                        }

                        int res = OrderControllerInstance.UpdateReAllocationStyle_stch(VA_Stch_Supplier, VA_Stch_Rate, ID, isFineLineCheck, Convert.ToInt32(hdnOrderDetailsID.Value), styleId, VA_Cut_Rate, IsVaFinelCut, VA_Finished_Rate, IsVaFinelFinished);

                        int resNew = OrderControllerInstance.UpdateReAllocationStyle_stch_Check(ID, isFineLineCheck, Convert.ToInt32(hdnOrderDetailsID.Value), styleId, IsCheckboxchecked);

                    }




                }
                Page page1 = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page1, page1.GetType(), "err_msg", "alert('Data save successfully.');$('#spinnL').css('display', 'none');", true);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

        }


        protected void btnCommiteddatesave_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (GridViewRow grv in grdReallCommitedEndDate.Rows)
                {
                    TextBox txtCommitted_EndDate = (TextBox)grv.FindControl("txtCommitted_EndDate");
                    HiddenField hdnReallocationID = (HiddenField)grv.FindControl("hdnReallocationID");

                    if (txtCommitted_EndDate.Text.Trim() != "")
                    {
                        string comitDate = txtCommitted_EndDate.Text.Trim();
                        if (comitDate != "")
                            comitDate = comitDate.Substring(0, comitDate.Length - 6);
                        bool IsUpdated = OrderControllerInstance.UpdateReallocationCommitedDate(Convert.ToInt32(hdnReallocationID.Value), comitDate);
                    }

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Add By Prabhaker
                var Qtyallow1 = "";
                if (Qtyallow1 == "")
                    Qtyallow1 = "0";

                var Perdayprod1 = "";
                if (Perdayprod1 == "")
                    Perdayprod1 = "0";
                var QtyAllow2 = "";
                if (QtyAllow2 == "")
                    QtyAllow2 = "0";

                var Perdayprod2 = "";
                if (Perdayprod2 == "")
                    Perdayprod2 = "0";

                for (int i = 0; i < gvReAllocation.Rows.Count; i++)
                {
                    CheckBox CheckHeader = (CheckBox)gvReAllocation.HeaderRow.FindControl("CheckHeader");

                    RadioButtonList rbtnPartialFull = (RadioButtonList)gvReAllocation.Rows[i].FindControl("rbtnPartialFull");
                    HiddenField hdnOrderDetailsId = (HiddenField)gvReAllocation.Rows[i].FindControl("hdnOrderDetailsId");
                    GridView gvChildReallocation = (GridView)gvReAllocation.Rows[i].FindControl("gvChildReallocation");
                    CheckBox cb = (CheckBox)gvReAllocation.Rows[i].FindControl("cb");
                    ImageButton imgbtnAdd = (ImageButton)gvReAllocation.Rows[i].FindControl("imgbtnAdd");
                    HiddenField hdnOrderDate = (HiddenField)gvReAllocation.Rows[i].FindControl("hdnOrderDate");

                    //TextBox txtbconqty = (TextBox)gvReAllocation.Rows[i].Cells[3].FindControl("txtQuantity");
                    HtmlAnchor txtQuantity = (HtmlAnchor)gvReAllocation.Rows[i].Cells[3].FindControl("txtQuantity");

                    //string sQuantity = txtQuantity.InnerHtml.Replace("<div style=\"width:95%; height:100%;\">", "").Replace("</div>", "").Trim();
                    string sQuantity = StripTagsRegex(txtQuantity.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtQuantity.InnerHtml).Trim();

                    bool Validate = Validation(gvChildReallocation, Convert.ToInt32(sQuantity.Replace(",", "")), hdnOrderDate.Value);

                    int RedioListVal = Convert.ToInt32(rbtnPartialFull.SelectedValue);
                    bool RedioVal = false;

                    int OrderDetailsId = 0;
                    if (hdnOrderDetailsId != null)
                    {
                        OrderDetailsId = Convert.ToInt32(hdnOrderDetailsId.Value);
                    }

                    if (RedioListVal == 1)
                    {
                        RedioVal = true;
                    }
                    bool IsRealocationFull = false;
                    if (cb.Checked == true)
                    {
                        IsRealocationFull = true;
                    }

                    if (Validate)
                    {
                        int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                        OrderControllerInstance.SaveReAllocationPartialOrFull(OrderDetailsId, RedioVal, IsRealocationFull);
                        for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
                        {
                            DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlFactory");
                            TextBox txtCutting = (TextBox)gvChildReallocation.Rows[j].FindControl("txtCutting");
                            HtmlAnchor txtCutting1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtCutting1");
                            TextBox txtStitching = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching");
                            TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[j].FindControl("txtFinishing");
                            TextBox txtCommitted_EndDate = (TextBox)gvChildReallocation.Rows[j].FindControl("txtCommitted_EndDate");
                            HtmlAnchor txtFinishing1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtFinishing1");
                            HiddenField hdnReAllocation = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnReAllocation");
                            HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                            //TextBox txtStitching1 = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                            TextBox txtStichingUnallocated = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStichingunallocated");
                            //-----------Add By Prabhaker-----------------------//

                            TextBox txtTdyCutReady = (TextBox)gvChildReallocation.Rows[j].FindControl("txtTdyCutReady");
                            TextBox txtTdyCutIssueOutHouse = (TextBox)gvChildReallocation.Rows[j].FindControl("txtTdyCutIssueOutHouse");
                            //   TextBox txtOutHouseManpower = (TextBox)gvChildReallocation.Rows[j].FindControl("txtOutHouseManpower");
                            //  TextBox txtOutHouseQc = (TextBox)gvChildReallocation.Rows[j].FindControl("txtOutHouseQc");
                            // TextBox txtOutHouseQcChecker = (TextBox)gvChildReallocation.Rows[j].FindControl("txtOutHouseQcChecker");
                            //Add By Prabhaker On 06-mar-18
                            //  DropDownList ddlchecker = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlchecker");
                            CheckBox chkIsOHStitchComplete = (CheckBox)gvChildReallocation.Rows[j].FindControl("chkIsOHStitchComplete");
                            //End Of Code
                            int TdyCutReady = 0, TdyCutIssueOutHouse = 0;//, OutHouseManpower = 0;
                            // string OutHouseQc, OutHouseQcChecker;                           

                            if (txtTdyCutReady.Text != "")
                                TdyCutReady = Convert.ToInt32(txtTdyCutReady.Text.Replace(",", ""));
                            if (txtTdyCutIssueOutHouse.Text != "")
                                TdyCutIssueOutHouse = Convert.ToInt32(txtTdyCutIssueOutHouse.Text.Replace(",", ""));
                            //if (txtOutHouseManpower.Text != "")
                            //    OutHouseManpower = Convert.ToInt32(txtOutHouseManpower.Text);
                            // string OutHouseQcnew = txtOutHouseQc.Text;                          
                            //  string OutHouseQcCheckernew = txtOutHouseQcChecker.Text;
                            // int QCOutHouseQcChecker = Convert.ToInt32(ddlchecker.SelectedValue);

                            //------------End Of Code-----------------------//
                            int FactoryId = 0, Cutting = 0, Stitching = 0, Finishing = 0, ReAllocationId = 0;
                            bool IsOHStitchComplete = false;
                            string sStitching = StripTagsRegex(txtStitching1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtStitching1.InnerHtml).Trim();
                            string sCutting = StripTagsRegex(txtCutting1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtCutting1.InnerHtml).Trim();
                            string sFinishing = StripTagsRegex(txtFinishing1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtFinishing1.InnerHtml).Trim();



                            if (hdnReAllocation != null)
                            {
                                if (hdnReAllocation.Value != "")
                                {
                                    ReAllocationId = Convert.ToInt32(hdnReAllocation.Value);
                                }
                            }

                            if (ddlFactory.SelectedValue != "-1")
                            {
                                FactoryId = Convert.ToInt32(ddlFactory.SelectedValue);
                            }
                            if (txtCutting.Text != "" && txtCutting.Visible && !(txtCutting1.Visible))
                            {
                                Cutting = Cutting + Convert.ToInt32((txtCutting.Text).Replace(",", "").Trim());
                            }
                            else if (sCutting != "" && !(txtCutting.Visible) && txtCutting1.Visible)
                            {
                                Cutting = Cutting + Convert.ToInt32(sCutting.Replace(",", ""));
                            }

                            txtStichingUnallocated.Text = txtStichingUnallocated.Text == "" ? "0" : txtStichingUnallocated.Text;

                            if (txtStitching.Text != "" && txtStitching.Visible && !(txtStitching1.Visible))
                            {
                                Stitching = Stitching + Convert.ToInt32((txtStitching.Text).Replace(",", "").Trim());
                            }
                            else if (sStitching != "" && !(txtStitching.Visible) && txtStitching1.Visible)
                            {
                                Stitching = Stitching + Convert.ToInt32(sStitching.Replace(",", ""));
                            }
                            if (txtFinishing.Text != "" && txtFinishing.Visible && !(txtFinishing1.Visible))
                            {
                                Finishing = Finishing + Convert.ToInt32((txtFinishing.Text).Replace(",", "").Trim());
                            }
                            else if (sFinishing != "" && !(txtFinishing.Visible) && txtFinishing1.Visible)
                            {
                                Finishing = Finishing + Convert.ToInt32(sFinishing.Replace(",", ""));
                            }

                            if (chkIsOHStitchComplete.Checked == true)
                            {
                                IsOHStitchComplete = true;
                            }

                            string comitDate = txtCommitted_EndDate.Text.Trim();
                            if (comitDate != "")
                                comitDate = comitDate.Substring(0, comitDate.Length - 6);

                            if (ReAllocationId == 0)
                            {
                                OrderControllerInstance.CreateReallocationHistory(OrderDetailsId, FactoryId, Cutting, Stitching, Finishing, ReAllocationId, UserID);
                                OrderControllerInstance.InsertUpdatePartialOrFullAllocation(OrderDetailsId, FactoryId, Cutting, Stitching, Finishing, ReAllocationId, TdyCutReady, TdyCutIssueOutHouse, true, IsOHStitchComplete, comitDate, UserID);
                            }
                            else
                            {
                                DataTable dt_Reallocation_Prev_values = new DataTable();
                                int Factory_Id = 0, Cutting_1 = 0, Stitching_1 = 0, Finishing_1 = 0;
                                dt_Reallocation_Prev_values = OrderControllerInstance.GetReallocationPreviousValues(ReAllocationId);
                                if (dt_Reallocation_Prev_values.Rows.Count > 0)
                                {
                                    Factory_Id = Convert.ToInt32(dt_Reallocation_Prev_values.Rows[0]["UnitID"].ToString());
                                    Cutting_1 = Convert.ToInt32(dt_Reallocation_Prev_values.Rows[0]["CuttingShare"].ToString());
                                    Stitching_1 = Convert.ToInt32(dt_Reallocation_Prev_values.Rows[0]["StitchingShare"].ToString());
                                    Finishing_1 = Convert.ToInt32(dt_Reallocation_Prev_values.Rows[0]["FinishingShare"].ToString());
                                }

                                OrderControllerInstance.InsertUpdatePartialOrFullAllocation(OrderDetailsId, FactoryId, Cutting, Stitching, Finishing, ReAllocationId, TdyCutReady, TdyCutIssueOutHouse, true, IsOHStitchComplete, comitDate, UserID);
                                if (dt_Reallocation_Prev_values.Rows.Count > 0)
                                {
                                    OrderControllerInstance.UpdateReallocationHistory(OrderDetailsId, Factory_Id, Cutting_1, Stitching_1, Finishing_1, ReAllocationId, UserID);
                                }
                            }




                        }
                        //modified by raghvinder on 09-09-2020 start
                        OrderControllerInstance.UpdateCheckDelete(styleId, OrderDetailsId, UserID);
                    }
                    else
                    {
                        return;
                    }
                }
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Data save successfully.');$('#spinnL').css('display', 'none');", true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }
        public void ValidationCutIssue(int OrderDetailsId, int ReAllocationId, int TdyCutIssueOutHouse)
        {

        }
        private bool Validation(GridView gvChildReallocation, int Quantity, string Orderdate)
        {
            bool Validate = true;
            int FactoryId = 0;
            int Cutting = 0;
            int Stitching = 0;
            int Finishing = 0;

            for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
            {
                DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlFactory");
                TextBox txtCutting = (TextBox)gvChildReallocation.Rows[j].FindControl("txtCutting");
                HtmlAnchor txtCutting1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtCutting1");
                TextBox txtStitching = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching");
                HiddenField hdnStitching = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnStitching");
                TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[j].FindControl("txtFinishing");
                HtmlAnchor txtFinishing1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtFinishing1");
                HiddenField hdnReAllocation = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnReAllocation");
                HiddenField hdnUnAlloctedQty = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnUnAlloctedQty");
                HiddenField StitchingValueOriginal = (HiddenField)gvChildReallocation.Rows[j].FindControl("StitchingValueOriginal");
                HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                //TextBox txtStitching1 = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                TextBox txtStichingUnallocated = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStichingunallocated");
                HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnlineQty");
                TextBox txtCommitted_EndDate = (TextBox)gvChildReallocation.Rows[j].FindControl("txtCommitted_EndDate");
                string sStitching = StripTagsRegex(txtStitching1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex((txtStitching1.InnerHtml).Replace(",", "")).Trim();
                string sCutting = StripTagsRegex(txtCutting1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex((txtCutting1.InnerHtml).Replace(",", "")).Trim();
                string sFinishing = StripTagsRegex(txtFinishing1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex((txtFinishing1.InnerHtml).Replace(",", "")).Trim();

                if (txtCommitted_EndDate.Text != "")
                {
                    if (DateTime.ParseExact(txtCommitted_EndDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) < Convert.ToDateTime(Orderdate))
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Committed End Date Can not be less Order date');$('#spinnL').css('display', 'none');", true);
                        Validate = false;
                    }
                }

                if (ddlFactory.SelectedValue != "-1")
                {
                    txtCutting.Text = txtCutting.Text == "" ? "0" : (txtCutting.Text).Replace(",", "");
                    txtStichingUnallocated.Text = txtStichingUnallocated.Text == "" ? "0" : txtStichingUnallocated.Text;
                    txtStitching.Text = txtStitching.Text == "" ? "0" : (txtStitching.Text).Replace(",", "");
                    sStitching = sStitching == "" ? "0" : sStitching.Replace(",", "");
                    txtFinishing.Text = txtFinishing.Text == "" ? "0" : (txtFinishing.Text).Replace(",", "");
                    FactoryId = Convert.ToInt32(ddlFactory.SelectedValue);
                    if (txtCutting.Text != "" && txtCutting.Visible && !(txtCutting1.Visible))
                    {
                        Cutting = Cutting + Convert.ToInt32(txtCutting.Text.Trim().Replace(",", ""));
                    }
                    else if (sCutting != "" && !(txtCutting.Visible) && txtCutting1.Visible)
                    {
                        Cutting = Cutting + Convert.ToInt32(sCutting.Replace(",", ""));
                    }

                    if (txtStitching.Text != "" && txtStitching.Visible && !(txtStitching1.Visible))
                    {
                        Stitching = Stitching + Convert.ToInt32(txtStitching.Text.Trim().Replace(",", ""));
                    }
                    else if (sStitching != "" && !(txtStitching.Visible) && txtStitching1.Visible)
                    {
                        Stitching = Stitching + Convert.ToInt32(sStitching.Replace(",", ""));
                    }
                    if (txtFinishing.Text != "" && txtFinishing.Visible && !(txtFinishing1.Visible))
                    {
                        Finishing = Finishing + Convert.ToInt32(txtFinishing.Text.Trim().Replace(",", ""));
                    }
                    else if (sFinishing != "" && !(txtFinishing.Visible) && txtFinishing1.Visible)
                    {
                        Finishing = Finishing + Convert.ToInt32(sFinishing.Replace(",", ""));
                    }

                    if (Convert.ToInt32(txtCutting.Text.Replace(",", "")) == 0 && Convert.ToInt32(txtStitching.Text.Replace(",", "")) == 0 && Convert.ToInt32(txtFinishing.Text.Replace(",", "")) == 0)
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter some value atleast one of Cutting, Stitching and Finishing.');$('#spinnL').css('display', 'none');", true);
                        Validate = false;
                    }

                    if (hdnlineQty.Value != "")
                    {
                        if ((Convert.ToInt32(txtStitching.Text.Replace(",", "")) < Convert.ToInt32(hdnlineQty.Value.Replace(",", ""))))
                        {

                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter Stiching Quantity Cannot be less then Unallocated Quantity.');$('#spinnL').css('display', 'none');", true);
                            Validate = false;
                        }
                    }

                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please select a Factory.');$('#spinnL').css('display', 'none');", true);
                    Validate = false;
                }
            }

            if (Validate)
            {
                if (Quantity < Cutting || Quantity < Stitching || Quantity < Finishing)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Total Cutting, Stitching or Finishing cannot be greater then Quantity. Please Check.');$('#spinnL').css('display', 'none');", true);
                    Validate = false;
                }
                if (Quantity > Cutting || Quantity > Stitching || Quantity > Finishing)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Total Cutting, Stitching or Finishing cannot be less then Quantity. Please Check.');$('#spinnL').css('display', 'none');", true);
                    Validate = false;
                }
            }
            return Validate;
        }

        private bool ValidationVAAllocation(GridView gvChildVAReallocation)
        {
            bool Validate = true;


            for (int j = 0; j < gvChildVAReallocation.Rows.Count; j++)
            {
                DropDownList ddlSupplierAllocation = (DropDownList)gvChildVAReallocation.Rows[j].FindControl("ddlSupplierAllocation");

                if (ddlSupplierAllocation.SelectedValue != "-1")
                {

                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please select a Vender.');$('#spinnL').css('display', 'none');", true);
                    Validate = false;
                }

            }

            return Validate;
        }

        private bool ValidationVADetails(GridView gvChildVA_Details)
        {
            bool Validate = true;


            for (int j = 0; j < gvChildVA_Details.Rows.Count; j++)
            {
                TextBox txtSupplier = (TextBox)gvChildVA_Details.Rows[j].FindControl("txtSupplier");
                TextBox txtInitial_Agreed_Rate = (TextBox)gvChildVA_Details.Rows[j].FindControl("txtInitial_Agreed_Rate");
                if (txtInitial_Agreed_Rate.Text.Trim() != "")
                {
                    if (txtSupplier.Text.Trim() != "")
                    {

                    }
                    else
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please Enter a Vender.');$('#spinnL').css('display', 'none');", true);
                        Validate = false;
                    }
                }
            }

            return Validate;
        }

        protected void gvChildReallocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Add by Surendra 2 for put loop all data rows on 04-04-2018.
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // check all cells in one row
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;

                        if (button != null && button.CommandName == "Delete")
                        {
                            // Add delete confirmation
                            //added by raghvinder on 08-09-2020 start
                            DataTable dt = PermissionControllerInstance.GetUserPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, (int)iKandi.Common.AppModuleColumn.REALLOCATION_DELETE).Tables[0];

                            bool writePermission = false;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                writePermission = Convert.ToBoolean(dt.Rows[i]["PermisionWrite"]);
                            }


                            if (writePermission == true)
                            {
                                button.Enabled = true;
                            }
                            else
                            {
                                button.Enabled = false;
                            }

                            //added by raghvinder on 08-09-2020 end
                            button.OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
                        }
                    }
                }
            }

            HiddenField hdnOrderDetailsId = (HiddenField)e.Row.Parent.Parent.Parent.FindControl("hdnOrderDetailsId");


            DropDownList ddlFactory = (DropDownList)e.Row.FindControl("ddlFactory");
            HiddenField hdnReAllocation = (HiddenField)e.Row.FindControl("hdnReAllocation");
            TextBox txtCutting = (TextBox)e.Row.FindControl("txtCutting");
            HtmlAnchor txtCutting1 = (HtmlAnchor)e.Row.FindControl("txtCutting1");
            TextBox txtStitching = (TextBox)e.Row.FindControl("txtStitching");
            HtmlAnchor txtStitching1 = (HtmlAnchor)e.Row.FindControl("txtStitching1");
            //TextBox txtStitching1 = (TextBox)e.Row.FindControl("txtStitching1");
            TextBox txtStichingunallocated = (TextBox)e.Row.FindControl("txtStichingunallocated");
            HiddenField hdnUnAlloctedQty = (HiddenField)e.Row.FindControl("hdnUnAlloctedQty");
            HiddenField hdnDoneCuttingQty = (HiddenField)e.Row.FindControl("hdnDoneCuttingQty");

            TextBox txtFinishing = (TextBox)e.Row.FindControl("txtFinishing");
            TextBox txtCommitted_EndDate = (TextBox)e.Row.FindControl("txtCommitted_EndDate");
            HtmlAnchor txtFinishing1 = (HtmlAnchor)e.Row.FindControl("txtFinishing1");
            HiddenField hdnDoneFinishingQty = (HiddenField)e.Row.FindControl("hdnDoneFinishingQty");

            HiddenField hdnunitid = (HiddenField)e.Row.FindControl("hdnunitid");
            Label lblStartDate = (Label)e.Row.FindControl("lblStartDate");
            Label lblEndDate = (Label)e.Row.FindControl("lblEndDate");
            Label lblStitchedQty = (Label)e.Row.FindControl("lblStitchedQty");
            Label lblPerDayOutPut = (Label)e.Row.FindControl("lblPerDayOutPut");

            // TextBox txtOutHouseQc = (TextBox)e.Row.FindControl("txtOutHouseQc");
            //TextBox txtOutHouseQcChecker = (TextBox)e.Row.FindControl("txtOutHouseQcChecker");
            //Add By Prabhaker on 06-mar-18
            // HiddenField hdnQcCheckerID = (HiddenField)e.Row.FindControl("hdnQcCheckerID");
            //DropDownList ddlchecker = (DropDownList)e.Row.FindControl("ddlchecker");
            //ddlchecker.Enabled = false;
            //Add By Prabhaker on 19-mar-18
            CheckBox chkIsOHStitchComplete = (CheckBox)e.Row.FindControl("chkIsOHStitchComplete");
            HiddenField hdnIsOHStitchComplete = (HiddenField)e.Row.FindControl("hdnIsOHStitchComplete");
            //  chkIsOHStitchComplete.Checked = Convert.ToBoolean(hdnIsOHStitchComplete.Value);
            if (hdnIsOHStitchComplete.Value == "True")
            {
                chkIsOHStitchComplete.Checked = true;
                chkIsOHStitchComplete.Enabled = false;
            }
            else
            {
                chkIsOHStitchComplete.Checked = false;
            }
            //if (ViewState["dtQcChecker"] != null)
            //{
            //    DataTable dtQcChecker = (DataTable)ViewState["dtQcChecker"];
            //    if (dtQcChecker.Rows.Count > 0)
            //    {
            //        ddlchecker.DataSource = dtQcChecker;
            //        ddlchecker.DataTextField = "firstname";
            //        ddlchecker.DataValueField = "UserID";
            //        ddlchecker.DataBind();
            //        if (hdnQcCheckerID.Value != "")
            //        {
            //            ddlchecker.SelectedValue = hdnQcCheckerID.Value;
            //        }
            //    }
            //}

            //End of Code
            //if (txtCommitted_EndDate.Text != "")
            //{
            //    if (Convert.ToDateTime(txtCommitted_EndDate.Text) < DateTime.ParseExact(hdnExfactory.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture))
            //    {
            //        Page page = HttpContext.Current.Handler as Page;
            //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('abc.');$('#spinnL').css('display', 'none');", true);
            //        return;
            //    }
            //}
            TextBox txtTdyCutReady = (TextBox)e.Row.FindControl("txtTdyCutReady");
            TextBox txtTdyCutIssueOutHouse = (TextBox)e.Row.FindControl("txtTdyCutIssueOutHouse");
            // TextBox txtOutHouseManpower = (TextBox)e.Row.FindControl("txtOutHouseManpower");

            //txtOutHouseManpower.Enabled = false;


            Label lblTotalCutting = (Label)e.Row.FindControl("lblTotalCutting");
            if (lblTotalCutting.Text == "0")
            {
                lblTotalCutting.Visible = false;
            }
            InHouseFact = CheckUnitId(hdnunitid.Value);
            if (InHouseFact == true)
            {
                lblStartDate.Visible = false;
                lblEndDate.Visible = false;
                lblStitchedQty.Visible = false;
                lblPerDayOutPut.Visible = false;
                // txtOutHouseQc.Enabled = false;
                // txtOutHouseQcChecker.Enabled = false;
                txtTdyCutReady.Enabled = false;
                txtTdyCutIssueOutHouse.Enabled = false;
                lblTotalCutting.Visible = true;
                lblTotalCutting.Enabled = false;
                if (DesignationId != 45)
                {
                    txtCutting.Enabled = true;
                }
                else
                {
                    txtCutting.Enabled = false;
                }
                // ddlchecker.Visible = false;
                chkIsOHStitchComplete.Visible = false;
                //txtCutting.Text = txtTdyCutReady.Text;
            }
            else
            {
                lblStartDate.Visible = true;
                lblEndDate.Visible = true;
                lblStitchedQty.Visible = true;
                lblPerDayOutPut.Visible = true;
                //lblStartDate.Text = (lblStartDate.Text).ToString("dd MMM yy");
                // txtOutHouseQc.Enabled = true;
                // txtOutHouseQcChecker.Enabled = true;
                txtTdyCutReady.Enabled = false;
                txtTdyCutIssueOutHouse.Enabled = true;
                if (DesignationId != 45)
                {
                    txtCutting.Enabled = true;
                }
                else
                {
                    txtCutting.Enabled = false;
                }
                // txtCutting.Enabled = false;
                chkIsOHStitchComplete.Visible = true;
            }


            int OrderDetailsId = 0;
            int ReAllocationId = 0;
            if (hdnOrderDetailsId != null)
            {
                OrderDetailsId = Convert.ToInt32(hdnOrderDetailsId.Value);
            }
            if (hdnReAllocation != null)
            {
                if (hdnReAllocation.Value != "")
                {
                    ReAllocationId = Convert.ToInt32(hdnReAllocation.Value);
                }
                else
                {
                    ReAllocationId = 0;
                }
            }

            DataSet dtReAllocationUnit = new DataSet();
            dtReAllocationUnit = OrderControllerInstance.GetReAllocationUnit(OrderDetailsId, ReAllocationId);

            ddlFactory.DataSource = dtReAllocationUnit.Tables[0];
            ddlFactory.DataValueField = "UnitID";
            ddlFactory.DataTextField = "UnitName";
            ddlFactory.DataBind();



            if (dtReAllocationUnit.Tables[1].Rows.Count > 1)
            {
                int unitId = Convert.ToInt32(dtReAllocationUnit.Tables[1].Rows[1]["UnitID"].ToString());
                ddlFactory.SelectedValue = unitId.ToString();
                InHouseFact = CheckUnitId(ddlFactory.SelectedValue);
                if (InHouseFact == true || ddlFactory.SelectedValue == "-1")
                {
                    txtCommitted_EndDate.Enabled = false;
                }
                else
                {
                    txtCommitted_EndDate.Enabled = true;
                }

                if ((Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnAssignCuttingQty")) > 0) && (((DataRowView)e.Row.DataItem).Row.Table.Columns.Contains("UnAssignCuttingQty")))
                {
                    txtCutting1.HRef = "/Internal/Merchandising/RemainCuttingQty.aspx?OrderDetailId=" + OrderDetailsId + "&unitid=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&StyleId=" + styleId + "&UnAssignCuttingQty=" + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnAssignCuttingQty"));
                }
                else
                {
                    txtCutting1.HRef = "/Internal/Merchandising/RemainCuttingQty.aspx?OrderDetailId=" + OrderDetailsId + "&unitid=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&StyleId=" + styleId;
                }
                txtCutting1.Disabled = true;

                txtStitching1.HRef = "/Internal/Merchandising/LinewithFactory.aspx?OrderDetailId=" + OrderDetailsId + "&unitid=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&StyleId=" + styleId;
                txtStitching1.Disabled = true;

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnAssignFinishingQty")) > 0)
                {
                    txtFinishing1.HRef = "/Internal/Merchandising/RemainFinishingQty.aspx?OrderDetailId=" + OrderDetailsId + "&unitid=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&StyleId=" + styleId + "&UnAssignFinishingQty=" + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnAssignFinishingQty"));
                }
                else
                {
                    txtFinishing1.HRef = "/Internal/Merchandising/RemainFinishingQty.aspx?OrderDetailId=" + OrderDetailsId + "&unitid=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&StyleId=" + styleId;
                }
                txtFinishing1.Disabled = true;
                //abhishek
                string sCutting = StripTagsRegex(txtCutting1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtCutting1.InnerHtml).Trim();
                string sStitching = StripTagsRegex(txtStitching1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtStitching1.InnerHtml).Trim();
                string sFinishing = StripTagsRegex(txtFinishing1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtFinishing1.InnerHtml).Trim();
                //end
                if (Convert.ToInt32(ddlFactory.SelectedValue) > 0)
                {
                    DataTable dt = OrderControllerInstance.CheckCutting_FinishingActive(Convert.ToInt32(ddlFactory.SelectedValue));
                    DataSet slotpass = OrderControllerInstance.GetSumAltpluspasspcs(OrderDetailsId, Convert.ToInt32(ddlFactory.SelectedValue));
                    hdnUnAlloctedQty.Value = hdnUnAlloctedQty.Value == "" ? "0" : hdnUnAlloctedQty.Value;

                    if (Convert.ToInt32((hdnDoneCuttingQty.Value).Replace(",", "")) > 0)
                    {
                        txtCutting1.Visible = true;
                        txtCutting.Visible = false;
                    }
                    else
                    {
                        txtCutting1.Visible = false;
                        txtCutting.Visible = true;
                    }

                    if (Convert.ToInt32((hdnUnAlloctedQty.Value).Replace(",", "")) > 0)
                    {
                        txtStitching1.Visible = false;
                        txtStitching.Visible = true;
                    }
                    else
                    {

                        txtStitching1.Visible = true;
                        txtStitching.Visible = false;
                    }

                    if (slotpass.Tables[1].Rows.Count > 0)
                    {
                        txtStitching1.Visible = true;
                        txtStitching.Visible = false;
                    }
                    else
                    {
                        txtStitching1.Visible = false;
                        txtStitching.Visible = true;
                    }

                    if (Convert.ToInt32((hdnDoneFinishingQty.Value).Replace(",", "")) > 0)
                    {
                        txtFinishing1.Visible = true;
                        txtFinishing.Visible = false;
                    }
                    else
                    {
                        txtFinishing1.Visible = false;
                        txtFinishing.Visible = true;
                    }

                    if ((Convert.ToInt32(sCutting.Replace(",", "")) > 0 && txtCutting1.Visible) || (Convert.ToInt32(sStitching.Replace(",", "")) > 0 && txtStitching1.Visible) || (Convert.ToInt32(sFinishing.Replace(",", "")) > 0 && txtFinishing1.Visible))
                    {
                        ddlFactory.Enabled = false;
                        //e.Row.Cells[9].Enabled = false;
                    }
                    else
                    {
                        ddlFactory.Enabled = true;
                        e.Row.Cells[9].Enabled = true;
                    }

                    if (Convert.ToBoolean(dt.Rows[0]["Cutting_Active"]) == true)
                    {
                        //txtCutting.Enabled = true;
                        txtCutting1.Attributes.Add("class", "enable");
                    }
                    else
                    {
                        txtCutting.Enabled = false;
                        txtCutting1.Attributes.Add("class", "disable");
                    }

                    if (Convert.ToBoolean(dt.Rows[0]["Finishing_Active"]) == true)
                    {
                        txtFinishing.Enabled = true;
                        txtFinishing1.Attributes.Add("class", "enable");
                    }
                    else
                    {
                        txtFinishing.Enabled = false;
                        txtFinishing1.Attributes.Add("class", "disable");
                    }
                    txtStitching.Enabled = true;

                }
                else
                {
                    txtCutting.Enabled = false;
                    txtCutting1.Visible = false;
                    txtStitching.Enabled = false;
                    txtFinishing.Enabled = false;
                    txtFinishing1.Visible = false;
                    txtStitching1.Visible = false;
                }
                txtCutting.Text = txtCutting.Text == "0" ? "" : txtCutting.Text;
                sCutting = sCutting == "0" ? "" : sCutting;
                txtStitching.Text = txtStitching.Text == "0" ? "" : txtStitching.Text;
                sStitching = sStitching == "0" ? "" : sStitching;
                txtFinishing.Text = txtFinishing.Text == "0" ? "" : txtFinishing.Text;
                sFinishing = sFinishing == "0" ? "" : sFinishing;
            }
            else
            {
                ddlFactory.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Factory").ToString();// unitId.ToString();

                InHouseFact = CheckUnitId(ddlFactory.SelectedValue);
                if (InHouseFact == true || ddlFactory.SelectedValue == "-1")
                {
                    txtCommitted_EndDate.Enabled = false;
                }
                else
                {
                    txtCommitted_EndDate.Enabled = true;
                }

                txtCutting1.Visible = false;
                txtStitching1.Visible = false;
                txtFinishing1.Visible = false;
                if (Convert.ToInt32(ddlFactory.SelectedValue) > 0)
                {
                    DataTable dt = OrderControllerInstance.CheckCutting_FinishingActive(Convert.ToInt32(ddlFactory.SelectedValue));

                    if (Convert.ToBoolean(dt.Rows[0]["Finishing_Active"]) == true)
                    {
                        txtFinishing.Enabled = true;
                    }
                    else
                    {
                        txtFinishing.Enabled = false;
                    }
                    txtStitching.Enabled = true;
                }
                else
                {
                    txtCutting.Enabled = false;
                    txtFinishing.Enabled = false;
                    txtStitching.Enabled = false;
                }
            }

            if (txtCommitted_EndDate.Text.Trim() != "")
            {
                txtCommitted_EndDate.Enabled = false;
                txtCommitted_EndDate.ForeColor = System.Drawing.Color.Gray;
            }
        }


        int OrderDetailID_Delete, UnitID_Delete, Cutting_Delete, Stitching_Delete, Finishing_Delete, ReallocationID_Delete = 0;

        protected void gvChildReallocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow gvRow = gv.NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;

            GridView gvChildReallocation = (GridView)gvReAllocation.Rows[rowIndex].FindControl("gvChildReallocation");

            DataTable dtChildReallocation = new DataTable();

            dtChildReallocation.Columns.Add("Factory");
            dtChildReallocation.Columns.Add("UnAllocatedQty");
            dtChildReallocation.Columns.Add("Cutting");
            dtChildReallocation.Columns.Add("Stitching");
            dtChildReallocation.Columns.Add("Finishing");

            dtChildReallocation.Columns.Add("StartDate");
            dtChildReallocation.Columns.Add("EndDate");
            dtChildReallocation.Columns.Add("StitchedQty");
            dtChildReallocation.Columns.Add("PerDayOutPut");
            dtChildReallocation.Columns.Add("Committed_EndDate");

            dtChildReallocation.Columns.Add("ReallocationID");
            dtChildReallocation.Columns.Add("LineQty");
            dtChildReallocation.Columns.Add("OrderDetailID");
            dtChildReallocation.Columns.Add("UnitID");
            dtChildReallocation.Columns.Add("DoneStitching");
            dtChildReallocation.Columns.Add("DoneCutting");
            dtChildReallocation.Columns.Add("DoneFinishing");
            dtChildReallocation.Columns.Add("TodayCutReadyOutHouse");
            dtChildReallocation.Columns.Add("TodayCutIssueOutHouse");
            //dtChildReallocation.Columns.Add("OutHouseManpower");
            //dtChildReallocation.Columns.Add("OutHouseQC");
            dtChildReallocation.Columns.Add("TotalCutting");

            //dtChildReallocation.Columns.Add("OutHouseChecker");
            //dtChildReallocation.Columns.Add("QcCheckerID");

            dtChildReallocation.Columns.Add("OHStitchComplete");
            foreach (GridViewRow row in gvChildReallocation.Rows)
            {
                DataRow dr = dtChildReallocation.NewRow();

                DropDownList ddlFactory = (DropDownList)row.Cells[0].FindControl("ddlFactory");
                TextBox txtStichingunallocated = (TextBox)row.Cells[1].FindControl("txtStichingunallocated");
                TextBox txtCutting = (TextBox)row.Cells[2].FindControl("txtCutting");
                HtmlAnchor txtCutting1 = (HtmlAnchor)row.Cells[2].FindControl("txtCutting1");
                HiddenField hdnDoneCuttingQty = (HiddenField)row.Cells[2].FindControl("hdnDoneCuttingQty");
                TextBox txtStitching = (TextBox)row.Cells[5].FindControl("txtStitching");
                HtmlAnchor txtStitching1 = (HtmlAnchor)row.Cells[5].FindControl("txtStitching1");
                //TextBox txtStitching1 = (TextBox)row.Cells[3].FindControl("txtStitching1");
                TextBox txtFinishing = (TextBox)row.Cells[5].FindControl("txtFinishing");
                TextBox txtCommitted_EndDate = (TextBox)row.Cells[9].FindControl("txtCommitted_EndDate");
                HtmlAnchor txtFinishing1 = (HtmlAnchor)row.Cells[4].FindControl("txtFinishing1");
                HiddenField hdnDoneFinishingQty = (HiddenField)row.Cells[5].FindControl("hdnDoneFinishingQty");
                HiddenField hdnReAllocation = (HiddenField)row.Cells[5].FindControl("hdnReAllocation");
                HiddenField hdnlineQty = (HiddenField)row.Cells[5].FindControl("hdnlineQty");
                HiddenField hdnorderdetail = (HiddenField)row.Cells[5].FindControl("hdnorderdetail");
                HiddenField hdnunitid = (HiddenField)row.Cells[5].FindControl("hdnunitid");
                HiddenField hdnStitching = (HiddenField)row.Cells[5].FindControl("hdnStitching");

                //added by raghvinder on 11-09-2020 start                
                OrderDetailID_Delete = hdnorderdetail.Value != "" ? Convert.ToInt32(hdnorderdetail.Value) : 0;
                UnitID_Delete = hdnunitid.Value != "" ? Convert.ToInt32(hdnunitid.Value) : 0;
                ReallocationID_Delete = hdnReAllocation.Value != "" ? Convert.ToInt32(hdnReAllocation.Value) : 0;
                Cutting_Delete = txtCutting.Text != "" ? Convert.ToInt32(txtCutting.Text.Replace(",", "")) : 0;
                Stitching_Delete = txtStitching.Text != "" ? Convert.ToInt32(txtStitching.Text.Replace(",", "")) : 0;
                Finishing_Delete = txtFinishing.Text != "" ? Convert.ToInt32(txtFinishing.Text.Replace(",", "")) : 0;
                //added by raghvinder on 11-09-2020 end

                //added on 10-09-2020
                //HiddenField hdnDeletionStatus = (HiddenField)row.Cells[5].FindControl("hdnStitching");


                // HiddenField hdnQcCheckerID = (HiddenField)row.Cells[5].FindControl("hdnQcCheckerID");
                Label lblStartDate = (Label)row.Cells[6].FindControl("lblStartDate");

                Label lblEndDate = (Label)row.Cells[6].FindControl("lblEndDate");

                Label lblStitchedQty = (Label)row.Cells[7].FindControl("lblStitchedQty");

                Label lblPerDayOutPut = (Label)row.Cells[8].FindControl("lblPerDayOutPut");

                TextBox txtTdyCutReady = (TextBox)row.Cells[2].FindControl("txtTdyCutReady");
                TextBox txtTdyCutIssueOutHouse = (TextBox)row.Cells[3].FindControl("txtTdyCutIssueOutHouse");
                // TextBox txtOutHouseManpower = (TextBox)row.Cells[9].FindControl("txtOutHouseManpower");
                // TextBox txtOutHouseQc = (TextBox)row.Cells[10].FindControl("txtOutHouseQc");
                Label lblTotalCutting = (Label)row.Cells[3].FindControl("lblTotalCutting");
                //TextBox txtOutHouseQcChecker = (TextBox)row.Cells[10].FindControl("txtOutHouseQcChecker");

                //Add By Prabhaker 06/mar/18
                HiddenField hdnIsOHStitchComplete = (HiddenField)row.Cells[9].FindControl("hdnIsOHStitchComplete");
                // DropDownList ddlchecker = (DropDownList)row.Cells[10].FindControl("ddlchecker");          
                string sStitching = StripTagsRegex(txtStitching1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtStitching1.InnerHtml).Trim();
                string sCutting = StripTagsRegex(txtCutting1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtCutting1.InnerHtml).Trim();
                string sFinishing = StripTagsRegex(txtFinishing1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtFinishing1.InnerHtml).Trim();

                dr["Factory"] = ddlFactory.Text;
                dr["UnAllocatedQty"] = txtStichingunallocated.Text;

                //dr["Cutting"] = txtCutting.Text;
                if (txtCutting.Visible)
                {
                    dr["Cutting"] = txtCutting.Text;
                }
                else
                {
                    dr["Cutting"] = sCutting;
                }

                if (txtStitching.Visible)
                {
                    dr["Stitching"] = txtStitching.Text;
                }
                else
                {
                    dr["Stitching"] = sStitching;
                }
                //dr["Finishing"] = txtFinishing.Text;
                if (txtFinishing.Visible)
                {
                    dr["Finishing"] = txtFinishing.Text;
                }
                else
                {
                    dr["Finishing"] = sFinishing;
                }
                string CommitDate = "";
                if (txtCommitted_EndDate.Text.Trim() == "")
                {
                    CommitDate = "1900-01-01";
                }
                else
                {
                    CommitDate = txtCommitted_EndDate.Text.Trim().Substring(0, txtCommitted_EndDate.Text.Trim().Length - 6);
                }

                dr["ReallocationID"] = hdnReAllocation.Value;
                dr["LineQty"] = hdnlineQty.Value;
                dr["OrderDetailID"] = hdnorderdetail.Value;
                dr["UnitID"] = hdnunitid.Value;
                dr["DoneStitching"] = hdnStitching.Value;
                dr["DoneCutting"] = hdnDoneCuttingQty.Value;
                dr["DoneFinishing"] = hdnDoneFinishingQty.Value;
                dr["OHStitchComplete"] = hdnIsOHStitchComplete.Value;
                dr["Committed_EndDate"] = CommitDate;
                dtChildReallocation.Rows.Add(dr);
            }

            int index = Convert.ToInt32(e.RowIndex);
            DataTable dtCurrentChildReallocation = dtChildReallocation;
            int userID = ApplicationHelper.LoggedInUser.UserData.UserID;
            if (dtCurrentChildReallocation.Rows.Count > 1)
            {
                dtCurrentChildReallocation.Rows[index]["OrderDetailID"] = dtCurrentChildReallocation.Rows[index]["OrderDetailID"].ToString() == "" ? "0" : dtCurrentChildReallocation.Rows[index]["OrderDetailID"];
                if (Convert.ToInt32(dtCurrentChildReallocation.Rows[index]["OrderDetailID"]) > 0)
                {
                    //added by raghvinder on 11-09-2020 start
                    int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;

                    OrderControllerInstance.DeleteReallocationHistory(Convert.ToInt32(dtCurrentChildReallocation.Rows[index]["OrderDetailID"]), Convert.ToInt32(dtCurrentChildReallocation.Rows[index]["UnitID"]), userID);

                    //added by raghvinder on 11-09-2020 end

                    OrderControllerInstance.DeleteReallocationEntry(Convert.ToInt32(dtCurrentChildReallocation.Rows[index]["OrderDetailID"]), Convert.ToInt32(dtCurrentChildReallocation.Rows[index]["UnitID"]), userID);


                }
                dtCurrentChildReallocation.Rows.RemoveAt(index);

                int AssignCuttingQty = 0, AssignFinishingQty = 0;

                for (int i = 0; i < dtCurrentChildReallocation.Rows.Count; i++)
                {
                    DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlFactory");
                    HtmlAnchor txtCutting1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtCutting1");
                    HtmlAnchor txtFinishing1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtFinishing1");
                    int Cutting = StripTagsRegex(txtCutting1.InnerHtml).Trim() == "" ? 0 : Convert.ToInt32(StripTagsRegex(txtCutting1.InnerHtml).Trim().Replace(",", ""));
                    AssignCuttingQty = AssignCuttingQty + Cutting;

                    int Finishing = StripTagsRegex(txtFinishing1.InnerHtml).Trim() == "" ? 0 : Convert.ToInt32(StripTagsRegex(txtFinishing1.InnerHtml).Trim().Replace(",", ""));
                    AssignFinishingQty = AssignFinishingQty + Finishing;
                }

                DataSet dsAllocation = OrderControllerInstance.GetReAllocationDetailsById(Convert.ToInt32(dtCurrentChildReallocation.Rows[0]["OrderDetailID"]), 0);
                int Quantity = Convert.ToInt32(dsAllocation.Tables[1].Rows[0]["Quantity"]);


                dtCurrentChildReallocation.Columns.Add("UnAssignCuttingQty", typeof(System.Int32));
                dtCurrentChildReallocation.Columns.Add("UnAssignFinishingQty", typeof(System.Int32));

                if ((Quantity - AssignCuttingQty) > 0)
                {
                    for (int i = 0; i < dtCurrentChildReallocation.Rows.Count; i++)
                    {
                        dtCurrentChildReallocation.Rows[i]["UnAssignCuttingQty"] = (Quantity - AssignCuttingQty);
                    }
                }
                else
                {
                    foreach (DataRow row in dtCurrentChildReallocation.Rows)
                    {
                        row["UnAssignCuttingQty"] = 0;
                    }
                }

                if ((Quantity - AssignFinishingQty) > 0)
                {
                    for (int i = 0; i < dtCurrentChildReallocation.Rows.Count; i++)
                    {
                        dtCurrentChildReallocation.Rows[i]["UnAssignFinishingQty"] = (Quantity - AssignFinishingQty);
                    }
                }
                else
                {
                    foreach (DataRow row in dtCurrentChildReallocation.Rows)
                    {
                        row["UnAssignFinishingQty"] = 0;
                    }
                }
            }
            else
            {
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Atleast one Entry need to be added.');$('#spinnL').css('display', 'none');", true);
                return;
            }

            gvChildReallocation.DataSource = dtCurrentChildReallocation;
            gvChildReallocation.DataBind();

            Page page2 = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page2, page2.GetType(), "err_msg", "alert('Record delete successfully.');$('#spinnL').css('display', 'none');", true);
        }

        protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            GridViewRow parentRow = ddl.NamingContainer.Parent.Parent.Parent.Parent as GridViewRow;
            int rowIndex = row.RowIndex;
            int parentRowIndex = parentRow.RowIndex;

            GridView gvChildReallocation = (GridView)gvReAllocation.Rows[parentRowIndex].FindControl("gvChildReallocation");
            DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[rowIndex].FindControl("ddlFactory");
            TextBox txtCutting = (TextBox)gvChildReallocation.Rows[rowIndex].FindControl("txtCutting");
            TextBox txtStitching = (TextBox)gvChildReallocation.Rows[rowIndex].FindControl("txtStitching");
            TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[rowIndex].FindControl("txtFinishing");
            TextBox txtCommitted_EndDate = (TextBox)gvChildReallocation.Rows[rowIndex].FindControl("txtCommitted_EndDate");
            // DropDownList ddlchecker = (DropDownList)gvChildReallocation.Rows[rowIndex].FindControl("ddlchecker");
            CheckBox chkIsOHStitchComplete = (CheckBox)gvChildReallocation.Rows[rowIndex].FindControl("chkIsOHStitchComplete");
            if (Convert.ToInt32(ddlFactory.SelectedValue) > 0)
            {
                InHouseFact = CheckUnitId(ddlFactory.SelectedValue);
                if (InHouseFact == true || ddlFactory.SelectedValue == "-1")
                {
                    txtCommitted_EndDate.Enabled = false;
                    txtCommitted_EndDate.Text = "";
                }
                else
                {
                    txtCommitted_EndDate.Enabled = true;
                }

                DataTable dt = OrderControllerInstance.CheckCutting_FinishingActive(Convert.ToInt32(ddlFactory.SelectedValue));

                if (Convert.ToBoolean(dt.Rows[0]["Finishing_Active"]) == true)
                {
                    txtFinishing.Enabled = true;
                }
                else
                {
                    txtFinishing.Enabled = false;
                }
                txtStitching.Enabled = true;
                txtCutting.Enabled = true;
                InHouseFact = CheckUnitId(ddlFactory.SelectedValue);
                if (InHouseFact == true)
                {
                    // ddlchecker.Visible = false;
                    chkIsOHStitchComplete.Visible = false;
                }

            }
            else
            {
                txtCutting.Enabled = false;
                txtStitching.Enabled = false;
                txtFinishing.Enabled = false;
            }

            for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
            {
                DropDownList ddlCheckFactory = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlFactory");

                if (ddlCheckFactory.SelectedValue == ddlFactory.SelectedValue && j != rowIndex && ddlFactory.SelectedValue != "-1")
                {
                    ddlFactory.SelectedValue = "-1";
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You can not select this factory because it is already selected.');$('#spinnL').css('display', 'none');", true);
                    return;
                }
            }
        }

        protected void CheckHeader_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((CheckBox)sender).NamingContainer as GridViewRow;
            CheckBox CheckHeader = (CheckBox)row.FindControl("CheckHeader");

            for (int i = 0; i < gvReAllocation.Rows.Count; i++)
            {
                HtmlAnchor txtQuantity = (HtmlAnchor)gvReAllocation.Rows[i].FindControl("txtQuantity");
                CheckBox cb = (CheckBox)gvReAllocation.Rows[i].FindControl("cb");
                RadioButtonList rbtnPartialFull = (RadioButtonList)gvReAllocation.Rows[i].FindControl("rbtnPartialFull");
                GridView gvChildReallocation = (GridView)gvReAllocation.Rows[i].FindControl("gvChildReallocation");
                ImageButton imgbtnAdd = (ImageButton)gvReAllocation.Rows[i].FindControl("imgbtnAdd");

                if (CheckHeader.Checked == true)
                {
                    cb.Checked = true;
                    rbtnPartialFull.Enabled = true;
                    imgbtnAdd.Enabled = true;
                    txtQuantity.Attributes.Add("class", "enable");
                    //gvReAllocation.Rows[i].Cells[9].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                }
                else
                {
                    cb.Checked = false;
                    rbtnPartialFull.Enabled = false;
                    imgbtnAdd.Enabled = false;
                    txtQuantity.Attributes.Add("class", "disable");

                }

                int TotalLineQty = 0;
                if (cb.Checked == true)
                {
                    gvChildReallocation.Enabled = true;
                    for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
                    {
                        DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlFactory");
                        HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnlineQty");
                        TextBox txtStitching = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching");
                        HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtStitching1");

                        txtStitching1.Attributes.Add("class", "enable");
                        string sStitching = StripTagsRegex(txtStitching1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtStitching1.InnerHtml).Trim();

                        if (Convert.ToInt32(sStitching.Replace(",", "")) > 0 && txtStitching1.Visible)
                        {
                            ddlFactory.Enabled = false;
                        }
                        else
                        {
                            ddlFactory.Enabled = true;
                        }

                        TotalLineQty = TotalLineQty + Convert.ToInt32(hdnlineQty.Value.Replace(",", ""));
                    }
                    rbtnPartialFull.Enabled = true;
                    imgbtnAdd.Enabled = true;
                }
                else
                {
                    gvChildReallocation.Enabled = false;
                    for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
                    {
                        HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnlineQty");
                        HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                        txtStitching1.Attributes.Add("class", "disable");
                        //gvChildReallocation.Rows[j].Cells[3].BackColor = System.Drawing.Color.FromName("#E3E3E3");
                        TotalLineQty = TotalLineQty + Convert.ToInt32(hdnlineQty.Value.Replace(",", ""));
                    }
                    rbtnPartialFull.Enabled = false;
                    imgbtnAdd.Enabled = false;
                }

                if (CheckHeader.Checked == true)
                {
                    if (TotalLineQty > 0)
                    {
                        txtQuantity.Attributes.Add("class", "enable");
                        //gvReAllocation.Rows[i].Cells[9].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                    }
                    else
                    {
                        txtQuantity.Attributes.Add("class", "disable");
                        //gvReAllocation.Rows[i].Cells[9].BackColor = System.Drawing.Color.FromName("#E3E3E3");
                    }
                }
            }
        }

        protected void cb_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((CheckBox)sender).NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            GridView gvChildReallocation = (GridView)gvReAllocation.Rows[rowIndex].FindControl("gvChildReallocation");
            RadioButtonList rbtnPartialFull = (RadioButtonList)gvReAllocation.Rows[rowIndex].FindControl("rbtnPartialFull");
            HtmlAnchor txtQuantity = (HtmlAnchor)gvReAllocation.Rows[rowIndex].FindControl("txtQuantity");
            CheckBox cb = (CheckBox)gvReAllocation.Rows[rowIndex].FindControl("cb");
            ImageButton imgbtnAdd = (ImageButton)gvReAllocation.Rows[rowIndex].FindControl("imgbtnAdd");
            int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            int TotalLineQty = 0;
            if (cb.Checked == true)
            {
                if (DesignationId == 45)
                {
                    for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                    {
                        DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlFactory");
                        // DropDownList ddlchecker = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlchecker");
                        TextBox txtCutting = (TextBox)gvChildReallocation.Rows[i].FindControl("txtCutting");
                        TextBox txtStitching = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStitching");
                        TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[i].FindControl("txtFinishing");
                        TextBox txtStichingunallocated = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStichingunallocated");
                        TextBox txtTdyCutReady = (TextBox)gvChildReallocation.Rows[i].FindControl("txtTdyCutReady");
                        TextBox txtTdyCutIssueOutHouse = (TextBox)gvChildReallocation.Rows[i].FindControl("txtTdyCutReady");
                        //  TextBox txtOutHouseQc = (TextBox)gvChildReallocation.Rows[i].FindControl("txtOutHouseQc");
                        // TextBox txtOutHouseManpower = (TextBox)gvChildReallocation.Rows[i].FindControl("txtOutHouseManpower");
                        HiddenField hdnunitid = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnunitid");
                        gvChildReallocation.Rows[i].Cells[10].Visible = false;
                        ddlFactory.Enabled = false;
                        txtStichingunallocated.Enabled = false;
                        txtTdyCutReady.Enabled = false;
                        txtTdyCutIssueOutHouse.Enabled = false;
                        txtStitching.Enabled = false;
                        txtFinishing.Enabled = false;
                        // txtOutHouseQc.Enabled = true;
                        // txtOutHouseManpower.Enabled = true;
                        //ddlchecker.Enabled = true;
                        //if (hdnunitid.Value == "3" || hdnunitid.Value == "11")
                        //{
                        //    txtOutHouseQc.Enabled = false;
                        //   // txtOutHouseManpower.Enabled = false;
                        //}

                    }

                    rbtnPartialFull.Enabled = true;
                    imgbtnAdd.Enabled = true;
                }
                else
                {
                    gvChildReallocation.Enabled = true;
                    // gvChildReallocation.Enabled = true;
                    for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                    {
                        DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlFactory");
                        HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnlineQty");
                        HtmlAnchor txtCutting1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtCutting1");
                        HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                        HtmlAnchor txtFinishing1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtFinishing1");
                        // TextBox txtOutHouseManpower = (TextBox)gvChildReallocation.Rows[i].FindControl("txtOutHouseManpower");
                        // DropDownList ddlchecker = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlchecker");
                        txtStitching1.Attributes.Add("class", "enable");
                        txtCutting1.Attributes.Add("class", "enable");
                        txtFinishing1.Attributes.Add("class", "enable");

                        //ddlchecker.Enabled = true;
                        //if ((ddlFactory.SelectedValue == "3") || (ddlFactory.SelectedValue == "11"))
                        //    txtOutHouseManpower.Enabled = false;
                        //else
                        //    txtOutHouseManpower.Enabled = true;

                        string sStitching = StripTagsRegex(txtStitching1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtStitching1.InnerHtml).Trim();
                        string sCutting = StripTagsRegex(txtCutting1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtCutting1.InnerHtml).Trim();
                        string sFinishing = StripTagsRegex(txtFinishing1.InnerHtml).Trim() == "" ? "0" : StripTagsRegex(txtFinishing1.InnerHtml).Trim();

                        if ((Convert.ToInt32(sCutting.Replace(",", "")) > 0 && txtCutting1.Visible) || (Convert.ToInt32(sStitching.Replace(",", "")) > 0 && txtStitching1.Visible) || (Convert.ToInt32(sFinishing.Replace(",", "")) > 0 && txtFinishing1.Visible))
                        {
                            ddlFactory.Enabled = false;
                        }
                        else
                        {
                            ddlFactory.Enabled = true;
                        }

                        TotalLineQty = TotalLineQty + Convert.ToInt32(hdnlineQty.Value.Replace(",", ""));

                        if (TotalLineQty > 0 && Convert.ToInt32(hdnlineQty.Value.Replace(",", "")) > 0)
                        {
                            txtQuantity.Attributes.Add("class", "enable");
                        }

                    }
                    rbtnPartialFull.Enabled = true;
                    imgbtnAdd.Enabled = true;


                }
            }
            else
            {
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnlineQty");
                    HtmlAnchor txtCutting1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtCutting1");
                    HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                    HtmlAnchor txtFinishing1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtFinishing1");
                    // TextBox txtOutHouseManpower = (TextBox)gvChildReallocation.Rows[i].FindControl("txtOutHouseManpower");
                    // DropDownList ddlchecker = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlchecker");
                    txtStitching1.Attributes.Add("class", "disable");
                    txtCutting1.Attributes.Add("class", "disable");
                    txtFinishing1.Attributes.Add("class", "disable");
                    // txtOutHouseManpower.Enabled = false;
                    hdnlineQty.Value = hdnlineQty.Value == "" ? "0" : hdnlineQty.Value;
                    TotalLineQty = TotalLineQty + Convert.ToInt32(hdnlineQty.Value.Replace(",", ""));
                    // ddlchecker.Enabled = false;
                }
                rbtnPartialFull.Enabled = false;
                imgbtnAdd.Enabled = false;

                txtQuantity.Attributes.Add("class", "disable");
            }
        }

        protected void grdcontact_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnIsVaCheck = (HiddenField)e.Row.FindControl("hdnIsVaCheck");
                CheckBox cbcontact = (CheckBox)e.Row.FindControl("cbcontact");
                HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");

                if (hdnIsVaCheck.Value == "1")
                {
                    cbcontact.Checked = true;
                    BindControlva(Convert.ToInt32(hdnOrderDetailsID.Value));
                }
                else
                {
                    if (hdnOrderDetailsID.Value == OrderDetailId.ToString())
                    {
                        BindControlva(Convert.ToInt32(hdnOrderDetailsID.Value));
                    }
                }


                int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
                if (DesignationId == 45)
                {
                    cbcontact.Enabled = false;
                }

            }
        }
        protected void grdStitchva_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsOuthouse = new DataSet();

            //if(e.Row.RowType== DataControlRowType.Header){

            //    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //    headerRow1.Attributes.Add("class", "ReAllheader1");
            //    headerRow2.Attributes.Add("class", "ReAllheader1");
            //    TableCell HeaderCell = new TableCell();

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "S.No";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.RowSpan = 2;
            //    HeaderCell.Width = 20;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Supplier Name";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.RowSpan = 2;
            //    HeaderCell.Width = 160;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Cutting";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    //HeaderCell.Width = 120;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Stitch";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    //HeaderCell.Width = 120;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Finished";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    //HeaderCell.Width = 120;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow1.Cells.Add(HeaderCell);

            //    //add second row

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Cutting Rate";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 60;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Finalise";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 30;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Stitch Rate";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    //HeaderCell.ColumnSpan = 2;
            //    HeaderCell.Width = 60;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Finalise";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    //HeaderCell.ColumnSpan = 2;
            //    HeaderCell.Width = 30;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Finished Rate";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 60;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Finalise";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 30;
            //    HeaderCell.Attributes.Add("Class", "ReAllheader1");
            //    headerRow2.Cells.Add(HeaderCell);

            //    grdStitchva.Controls[0].Controls.AddAt(0, headerRow2);
            //    grdStitchva.Controls[0].Controls.AddAt(0, headerRow1);

            //}

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
                TextBox txtSupplierNameVa = (TextBox)e.Row.FindControl("txtSupplierNameVa");
                TextBox txtStitchRateVa = (TextBox)e.Row.FindControl("txtStitchRateVa");
                TextBox txtCuttingRate = (TextBox)e.Row.FindControl("txtCuttingRate");
                TextBox txtFinishRate = (TextBox)e.Row.FindControl("txtFinishRate");
                HiddenField IsVaFineLineCheck = (HiddenField)e.Row.FindControl("IsVaFineLineCheck");
                HiddenField IsVaFinelCut = (HiddenField)e.Row.FindControl("IsVaFinelCut");
                HiddenField IsVaFinelFinished = (HiddenField)e.Row.FindControl("IsVaFinelFinished");
                HiddenField hdnSerialNo = (HiddenField)e.Row.FindControl("hdnSerialNo");
                CheckBox chkSupplier = (CheckBox)e.Row.FindControl("chkSupplier");
                CheckBox chkCuttingFinalise = (CheckBox)e.Row.FindControl("chkCuttingFinalise");
                CheckBox chkFinishFinalise = (CheckBox)e.Row.FindControl("chkFinishFinalise");
                //LinkButton LinkOutHousePO = (LinkButton)e.Row.FindControl("LinkOutHousePO");
                HtmlAnchor LinkOutHousePO = (HtmlAnchor)e.Row.FindControl("LinkOutHousePO");
                // Updated By RSB on dated 5 Nov 2020 To resolve the crash when more than 5 suppliers which is not handled in DAtabase
                if (SupplierCount <= 5)
                {
                    dsOuthouse = OrderControllerInstance.USP_GetStitchOutHousePO(OrderDetailId, SupplierCount);
                }

                string PONo_OutHouse = "";
                string RegisteredSupplier = "";
                string PONo_StyleMNumber = "";

                if (dsOuthouse.Tables.Count > 0)
                {
                    PONo_OutHouse = dsOuthouse.Tables[0].Rows[0].ItemArray[0].ToString();
                    RegisteredSupplier = dsOuthouse.Tables[0].Rows[0].ItemArray[1].ToString();
                    PONo_StyleMNumber = dsOuthouse.Tables[0].Rows[0].ItemArray[2].ToString();
                }

                if (txtSupplierNameVa.Text == "0.00" || txtSupplierNameVa.Text == "0.0" || txtSupplierNameVa.Text == "0")
                    txtSupplierNameVa.Text = "";

                if (txtStitchRateVa.Text == "0.00" || txtStitchRateVa.Text == "0.0" || txtStitchRateVa.Text == "0")
                    txtStitchRateVa.Text = "";

                if (txtCuttingRate.Text == "0.00" || txtCuttingRate.Text == "0.0" || txtCuttingRate.Text == "0")
                    txtCuttingRate.Text = "";

                if (txtFinishRate.Text == "0.00" || txtFinishRate.Text == "0.0" || txtFinishRate.Text == "0")
                    txtFinishRate.Text = "";


                if (IsVaFineLineCheck.Value == "1")
                {
                    chkSupplier.Checked = true;
                    if (PONo_OutHouse != "")
                    {
                        //LinkOutHousePO.Visible = true;
                        //LinkOutHousePO.Text = PONo_OutHouse;
                        //LinkOutHousePO.PostBackUrl = "~/Internal/Production/POStitch.aspx?OrderDetailId=" + OrderDetailId + "&LocationType=" + SupplierCount;
                        string outhousePO = "OrderDetailId=" + OrderDetailId + "&LocationType=" + SupplierCount + "&StyleNumber=" + PONo_StyleMNumber;
                        LinkOutHousePO.Visible = true;
                        LinkOutHousePO.InnerText = PONo_OutHouse;
                        LinkOutHousePO.Attributes.Add("class", "positonTop");
                        LinkOutHousePO.Attributes.Add("onclick", "ViewOutHousePo('" + outhousePO + "')");
                        chkSupplier.Enabled = false;
                    }
                    else
                    {
                        //LinkOutHousePO.Visible = true;
                        //LinkOutHousePO.Text = "Create PO";
                        //LinkOutHousePO.PostBackUrl = "~/Internal/Production/POStitch.aspx?OrderDetailId=" + OrderDetailId + "&LocationType=" + SupplierCount;
                        string outhousePO = "OrderDetailId=" + OrderDetailId + "&LocationType=" + SupplierCount + "&StyleNumber=" + PONo_StyleMNumber;
                        if (RegisteredSupplier == "1")
                        {
                            LinkOutHousePO.Visible = true;
                            LinkOutHousePO.InnerText = "Create PO";
                            LinkOutHousePO.Attributes.Add("class", "positonTop");
                            LinkOutHousePO.Attributes.Add("onclick", "CrearteOutHousePo('" + outhousePO + "')");
                        }
                        else
                        {
                            LinkOutHousePO.Visible = true;
                            LinkOutHousePO.InnerText = "Create PO";
                            LinkOutHousePO.Attributes.Add("class", "positonTop");
                            LinkOutHousePO.Title = "Pending Registration Vendor";
                            LinkOutHousePO.Disabled = true;

                        }

                    }

                    if (LinkOutHousePO.InnerText == PONumber)
                    {
                        e.Row.Attributes.Add("class", "backgroundRed");
                    }
                }
                else
                {
                    chkSupplier.Checked = false;
                }
                SupplierCount = SupplierCount + 1;
                if (IsVaFinelCut.Value == "1")
                {
                    chkCuttingFinalise.Checked = true;
                }
                else
                {
                    chkCuttingFinalise.Checked = false;
                }
                if (IsVaFinelFinished.Value == "1")
                {
                    chkFinishFinalise.Checked = true;
                }
                else
                {
                    chkFinishFinalise.Checked = false;
                }
                // txtStitchRateVa.CssClass = "decimal";

                int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
                if (DesignationId == 45)
                {
                    txtSupplierNameVa.Enabled = false;
                    txtStitchRateVa.Enabled = false;
                    txtCuttingRate.Enabled = false;
                    txtFinishRate.Enabled = false;
                    chkSupplier.Enabled = false;
                    chkCuttingFinalise.Enabled = false;
                    chkFinishFinalise.Enabled = false;

                }

            }
        }
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }


        public bool ValidateSupplier(out string ErrorMsg)
        {
            bool IsCheck = true;
            ErrorMsg = string.Empty;
            int SupplierCount = 0;
            int SupplierCheckCount = 0;
            foreach (GridViewRow gvrowss in grdStitchva.Rows)
            {
                //RadioButton ChkisSelectedss = (RadioButton)gvrowss.FindControl("ChkisSelected");
                CheckBox chkSupplier = (CheckBox)gvrowss.FindControl("chkSupplier");
                CheckBox chkCuttingFinalise = (CheckBox)gvrowss.FindControl("chkCuttingFinalise");
                CheckBox chkFinishFinalise = (CheckBox)gvrowss.FindControl("chkFinishFinalise");
                TextBox txtSupplierNameVa = (TextBox)gvrowss.FindControl("txtSupplierNameVa");
                TextBox txtStitchRateVa = (TextBox)gvrowss.FindControl("txtStitchRateVa");
                TextBox txtCuttingRate = (TextBox)gvrowss.FindControl("txtCuttingRate");
                TextBox txtFinishRate = (TextBox)gvrowss.FindControl("txtFinishRate");
                if (!string.IsNullOrEmpty(txtSupplierNameVa.Text) && !string.IsNullOrEmpty(txtStitchRateVa.Text) && !string.IsNullOrEmpty(txtStitchRateVa.Text) && !string.IsNullOrEmpty(txtStitchRateVa.Text))
                {
                    SupplierCount++;
                }
                if (chkSupplier.Checked && chkCuttingFinalise.Checked && chkFinishFinalise.Checked)
                {
                    SupplierCheckCount++;
                }
            }
            if (SupplierCount > 0)
            {
                if (SupplierCheckCount <= 0)
                {
                    ErrorMsg = "Please select at least one supplier check box";
                    IsCheck = false;
                }
            }
            return IsCheck;
        }

        protected void gvChildVA_Details_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Add by Surendra 2 for put loop all data rows on 04-04-2018.
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // check all cells in one row
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;
                        if (button != null && button.CommandName == "Delete")
                        {
                            // Add delete confirmation
                            button.OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
                        }
                    }
                }
            }
            //DropDownList ddlSupplier = (DropDownList)e.Row.FindControl("ddlSupplier");
            TextBox txtSupplier = (TextBox)e.Row.FindControl("txtSupplier");
            TextBox txtInitial_Agreed_Rate = (TextBox)e.Row.FindControl("txtInitial_Agreed_Rate");
            HiddenField hdnStyleid = (HiddenField)e.Row.Parent.Parent.Parent.FindControl("hdnStyleid");
            HiddenField hdnVA_ID = (HiddenField)e.Row.Parent.Parent.Parent.FindControl("hdnVA_ID");
            //HiddenField hdnSupplierId = (HiddenField)e.Row.FindControl("hdnSupplierId");
            HiddenField hdnFianlize = (HiddenField)e.Row.FindControl("hdnFianlize");
            CheckBox chkFinalize = (CheckBox)e.Row.FindControl("chkFinalize");
            DataSet dtVA_Details = new DataSet();
            //LinkButton lnkPO = (LinkButton)e.Row.FindControl("lnkPO");
            HtmlAnchor lnkPO = (HtmlAnchor)e.Row.FindControl("lnkPO");
            HiddenField hdnRiskSupplierID = (HiddenField)e.Row.FindControl("hdnRiskSupplierID");
            HtmlControl VAtoltip = (HtmlControl)e.Row.FindControl("VAtoltip");
            string PONo = "";
            if (hdnRiskSupplierID.Value != "")
            {
                PONo = OrderControllerInstance.GetVAPOIdZByRiskVASupplierId(Convert.ToInt32(hdnRiskSupplierID.Value), "");
            }
            //string supplierid = hdnSupplierId.Value.ToString() == "" ? "0" : hdnSupplierId.Value.ToString();
            //dtVA_Details = OrderControllerInstance.GetVADetails(Convert.ToInt32(hdnStyleid.Value.ToString()), Convert.ToInt32(supplierid), Convert.ToInt32(hdnVA_ID.Value.ToString()));

            //ddlSupplier.DataSource = dtVA_Details.Tables[0];
            //ddlSupplier.DataValueField = "UnitID";
            //ddlSupplier.DataTextField = "UnitName";
            //ddlSupplier.DataBind();


            txtInitial_Agreed_Rate.Text = txtInitial_Agreed_Rate.Text == "0" ? "" : txtInitial_Agreed_Rate.Text;
            if (hdnFianlize.Value == "1")
            {
                chkFinalize.Checked = true;
            }
            else
            {
                chkFinalize.Checked = false;
            }


            string fanalize = hdnFianlize.Value.ToString() == "" ? "0" : hdnFianlize.Value.ToString();
            int final = 0;
            if (fanalize == "True")
            {
                final = 1;
            }
            bool Finalize = Convert.ToBoolean(final);
            if (Finalize == true)
            {
                chkFinalize.Checked = true;
            }
            else
            {
                chkFinalize.Checked = false;
            }
            if (chkFinalize.Checked == true)
            {
                if (PONo != "")
                {
                    lnkPO.Visible = true;
                    lnkPO.InnerText = PONo;
                    lnkPO.Attributes.Add("class", "positonTop");
                    string hdnval = hdnRiskSupplierID.Value;
                    string hdnvalVAID = hdnVA_ID.Value;
                    lnkPO.Attributes.Add("onclick", "ViewValueAPo('" + hdnval + "','" + hdnvalVAID + "')");
                    chkFinalize.Enabled = false;
                }
                else
                {
                    string ValueAdditionRegisteredSupplier = OrderControllerInstance.Get_Check_RegesteredSupplier(Convert.ToInt32(hdnRiskSupplierID.Value));
                    if (ValueAdditionRegisteredSupplier == "1")
                    {
                        lnkPO.Visible = true;
                        lnkPO.InnerText = "Create PO";
                        string hdnval = hdnRiskSupplierID.Value;
                        string hdnvalVAID = hdnVA_ID.Value;
                        lnkPO.Attributes.Add("class", "positonTop");
                        lnkPO.Attributes.Add("onclick", "CrearteValueAPo('" + hdnval + "','" + hdnvalVAID + "')");
                    }
                    else
                    {
                        lnkPO.Visible = true;
                        lnkPO.InnerText = "Create PO";
                        lnkPO.Attributes.Add("class", "positonTop");
                        lnkPO.Title = "Pending Registration Vendor";
                        lnkPO.Disabled = true;
                    }
                    chkFinalize.Enabled = true;
                }
                if (lnkPO.InnerText != "")
                {
                    if (lnkPO.InnerText == PONumber)
                    {
                        e.Row.Attributes.Add("class", "backgroundRed");
                    }
                }
            }

        }

        protected void gvChildVA_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow gvRow = gv.NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;

            GridView gvChildVA_Details = (GridView)gvVA_Details.Rows[rowIndex].FindControl("gvChildVA_Details");
            HiddenField hdnStyleid = (HiddenField)gvVA_Details.Rows[rowIndex].FindControl("hdnStyleid");
            HiddenField hdnVA_ID = (HiddenField)gvVA_Details.Rows[rowIndex].FindControl("hdnVA_ID");
            DataTable dtChildVA_Detail = new DataTable();
            dtChildVA_Detail.Columns.Add("SupplierName");
            dtChildVA_Detail.Columns.Add("Rate");
            dtChildVA_Detail.Columns.Add("Finalize");
            dtChildVA_Detail.Columns.Add("RiskSupplierID");


            foreach (GridViewRow row in gvChildVA_Details.Rows)
            {
                DataRow dr = dtChildVA_Detail.NewRow();

                TextBox txtSupplier = (TextBox)row.Cells[0].FindControl("txtSupplier");
                TextBox txtInitial_Agreed_Rate = (TextBox)row.Cells[1].FindControl("txtInitial_Agreed_Rate");
                HiddenField hdnFianlize = (HiddenField)row.Cells[2].FindControl("hdnFianlize");
                CheckBox chkFinalize = (CheckBox)row.Cells[2].FindControl("chkFinalize");
                HiddenField hdnRiskSupplierID = (HiddenField)row.Cells[2].FindControl("hdnRiskSupplierID");
                if (hdnFianlize.Value == "")
                {
                    if (chkFinalize.Checked == true)
                    {
                        hdnFianlize.Value = "1";
                    }
                }

                dr["SupplierName"] = txtSupplier.Text;
                dr["Rate"] = txtInitial_Agreed_Rate.Text;
                dr["Finalize"] = hdnFianlize.Value;
                dr["RiskSupplierID"] = hdnRiskSupplierID.Value;

                dtChildVA_Detail.Rows.Add(dr);
            }

            int index = Convert.ToInt32(e.RowIndex);
            DataTable dtCurrentChildVA = dtChildVA_Detail;

            if (dtCurrentChildVA.Rows.Count > 1)
            {
                dtCurrentChildVA.Rows[index]["SupplierName"] = dtCurrentChildVA.Rows[index]["SupplierName"].ToString() == "" ? "" : dtCurrentChildVA.Rows[index]["SupplierName"];
                if ((dtCurrentChildVA.Rows[index]["SupplierName"].ToString() != "") && (Convert.ToBoolean(dtCurrentChildVA.Rows[index]["Finalize"]) == false))
                {
                    OrderControllerInstance.DeleteVA_DetailsEntry(dtCurrentChildVA.Rows[index]["SupplierName"].ToString(), Convert.ToInt32(hdnStyleid.Value.ToString()), Convert.ToInt32(hdnVA_ID.Value.ToString()), Convert.ToInt32(dtCurrentChildVA.Rows[index]["RiskSupplierID"].ToString()));
                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Can not delete because contract is Finalize');$('#spinnL').css('display', 'none');", true);
                    return;
                }
                dtCurrentChildVA.Rows.RemoveAt(index);
            }
            else
            {
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Atleast one Entry need to be added.');$('#spinnL').css('display', 'none');", true);
                return;
            }

            gvChildVA_Details.DataSource = dtCurrentChildVA;
            gvChildVA_Details.DataBind();

            Page page2 = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page2, page2.GetType(), "err_msg", "alert('Record delete successfully.');$('#spinnL').css('display', 'none');", true);
        }

        protected void gvVA_Details_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            HiddenField hdnStyleid = (HiddenField)e.Row.FindControl("hdnStyleid");
            HiddenField hdnVA_ID = (HiddenField)e.Row.FindControl("hdnVA_ID");
            GridView gvChildVA_Details = (GridView)e.Row.FindControl("gvChildVA_Details");
            HiddenField hdnCheckAdminRate = (HiddenField)e.Row.FindControl("hdnCheckAdminRate");
            TextBox lblIntialAgreementRate = (TextBox)e.Row.FindControl("lblIntialAgreementRate");
            if (Convert.ToBoolean(hdnCheckAdminRate.Value) == true)
                lblIntialAgreementRate.Enabled = false;
            DataSet dtVaDetails = new DataSet();
            dtVaDetails = OrderControllerInstance.GetVADetails(Convert.ToInt32(hdnStyleid.Value.ToString()), Convert.ToInt32(hdnVA_ID.Value.ToString()));
            if (dtVaDetails.Tables[0].Rows.Count == 0)
            {
                dtVaDetails.Tables[0].Rows.Add();
            }

            gvChildVA_Details.DataSource = dtVaDetails.Tables[0];
            gvChildVA_Details.DataBind();
            HtmlAnchor lnkPO1 = null;
            GridViewRow rows = gvChildVA_Details.Rows[e.Row.TabIndex];
            if (rows != null)
            {
                lnkPO1 = (HtmlAnchor)rows.FindControl("lnkPO");
                if (lnkPO1.InnerText != "")
                {
                    if (lnkPO1.InnerText == PONumber)
                    {
                        e.Row.Attributes.Add("class", "backgroundRed");
                    }
                }
            }

            //Fetch value of Name.

        }

        protected void gvVA_Details_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {
                DataTable dtVADetailsUnit = OrderControllerInstance.GetVADetails(0, "0", 0).Tables[0];
                int id = int.Parse(e.CommandArgument.ToString());
                GridView gvChildVA_Details = (GridView)gvVA_Details.Rows[id].FindControl("gvChildVA_Details");
                for (int i = 0; i < gvChildVA_Details.Rows.Count; i++)
                {
                    TextBox txtSupplier = (TextBox)gvChildVA_Details.Rows[i].FindControl("txtSupplier");
                    TextBox txtInitial_Agreed_Rate = (TextBox)gvChildVA_Details.Rows[i].FindControl("txtInitial_Agreed_Rate");
                    CheckBox chkFinalize = (CheckBox)gvChildVA_Details.Rows[i].FindControl("chkFinalize");
                    if (txtSupplier.Text.Trim() == "" && txtInitial_Agreed_Rate.Text == "")
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Blank row need to be filled first.');$('#spinnL').css('display', 'none');", true);
                        return;
                    }
                }
                //if ((dtVADetailsUnit.Rows.Count - 1) == gvChildVA_Details.Rows.Count)
                //{
                //    Page page = HttpContext.Current.Handler as Page;
                //    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot add rows more than Vender count.');$('#spinnL').css('display', 'none');", true);
                //    return;
                //}
                //else
                //{
                DataTable dtnew = new DataTable();
                DataTable dtmerge = new DataTable();

                dtnew = gridTableVA(gvChildVA_Details);
                DataRow newrow = dtnew.NewRow();
                dtnew.Rows.Add(newrow);
                dtmerge = dtnew;

                gvChildVA_Details.DataSource = dtmerge;
                gvChildVA_Details.DataBind();
                //}
            }
        }

        protected void CheckHeaderQA_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((CheckBox)sender).NamingContainer as GridViewRow;
            CheckBox CheckHeaderQA = (CheckBox)row.FindControl("CheckHeaderQA");

            for (int i = 0; i < grdVA_Quantity_Allocation.Rows.Count; i++)
            {
                CheckBox cbQA = (CheckBox)grdVA_Quantity_Allocation.Rows[i].FindControl("cbQA");
                RadioButtonList rbtnPartialFull = (RadioButtonList)grdVA_Quantity_Allocation.Rows[i].FindControl("rbtnPartialFullQA");
                GridView grdChildVA_Quantity_Allocation = (GridView)grdVA_Quantity_Allocation.Rows[i].FindControl("grdChildVA_Quantity_Allocation");
                ImageButton imgbtnAdd = (ImageButton)grdVA_Quantity_Allocation.Rows[i].FindControl("img_btnAdd");

                if (CheckHeaderQA.Checked == true)
                {
                    cbQA.Checked = true;
                    rbtnPartialFull.Enabled = true;
                    imgbtnAdd.Enabled = true;
                    //gvReAllocation.Rows[i].Cells[9].BackColor = System.Drawing.Color.FromName("#FFFFFF");
                }
                else
                {
                    cbQA.Checked = false;
                    rbtnPartialFull.Enabled = false;
                    imgbtnAdd.Enabled = false;

                }

                if (cbQA.Checked == true)
                {
                    grdChildVA_Quantity_Allocation.Enabled = true;
                    for (int j = 0; j < grdChildVA_Quantity_Allocation.Rows.Count; j++)
                    {
                        DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[j].FindControl("ddlSupplierAllocation");
                        TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtPerdayOutput");
                        TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtAllocationQuantity1");
                        TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtAllocationQuantity2");

                        ddlSupplier.Enabled = true;
                        txtPerdayOutput.Enabled = true;
                        txtAllocationQuantity1.Enabled = true;
                        txtAllocationQuantity2.Enabled = true;
                    }
                    rbtnPartialFull.Enabled = true;
                    imgbtnAdd.Enabled = true;
                }
                else
                {
                    grdChildVA_Quantity_Allocation.Enabled = false;
                    for (int j = 0; j < grdChildVA_Quantity_Allocation.Rows.Count; j++)
                    {
                        DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[j].FindControl("ddlSupplierAllocation");
                        TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtPerdayOutput");
                        TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtAllocationQuantity1");
                        TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtAllocationQuantity2");

                        ddlSupplier.Enabled = false;
                        txtPerdayOutput.Enabled = false;
                        txtAllocationQuantity1.Enabled = false;
                        txtAllocationQuantity2.Enabled = false;

                    }
                    rbtnPartialFull.Enabled = false;
                    imgbtnAdd.Enabled = false;
                }
            }
        }

        protected void cbQA_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((CheckBox)sender).NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            GridView grdChildVA_Quantity_Allocation = (GridView)grdVA_Quantity_Allocation.Rows[rowIndex].FindControl("grdChildVA_Quantity_Allocation");
            RadioButtonList rbtnPartialFull = (RadioButtonList)grdVA_Quantity_Allocation.Rows[rowIndex].FindControl("rbtnPartialFullQA");
            CheckBox cbQA = (CheckBox)grdVA_Quantity_Allocation.Rows[rowIndex].FindControl("cbQA");
            ImageButton img_btnAdd = (ImageButton)grdVA_Quantity_Allocation.Rows[rowIndex].FindControl("img_btnAdd");
            int DesignationId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            if (cbQA.Checked == true)
            {
                if (DesignationId == 45)
                {
                    for (int i = 0; i < grdChildVA_Quantity_Allocation.Rows.Count; i++)
                    {
                        DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[i].FindControl("ddlSupplierAllocation");
                        TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtPerdayOutput");
                        TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity1");
                        TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity2");


                        ddlSupplier.Enabled = false;
                        txtPerdayOutput.Enabled = false;
                        txtAllocationQuantity1.Enabled = false;
                        txtAllocationQuantity2.Enabled = false;

                    }

                    rbtnPartialFull.Enabled = true;
                    img_btnAdd.Enabled = true;
                }
                else
                {
                    grdChildVA_Quantity_Allocation.Enabled = true;
                    // gvChildReallocation.Enabled = true;
                    for (int i = 0; i < grdChildVA_Quantity_Allocation.Rows.Count; i++)
                    {
                        DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[i].FindControl("ddlSupplierAllocation");
                        TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtPerdayOutput");
                        TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity1");
                        TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity2");

                        ddlSupplier.Enabled = true;
                        txtPerdayOutput.Enabled = true;
                        txtAllocationQuantity1.Enabled = true;
                        txtAllocationQuantity2.Enabled = true;

                    }
                    rbtnPartialFull.Enabled = true;
                    img_btnAdd.Enabled = true;


                }
            }
            else
            {
                for (int i = 0; i < grdChildVA_Quantity_Allocation.Rows.Count; i++)
                {
                    DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[i].FindControl("ddlSupplierAllocation");
                    TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtPerdayOutput");
                    TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity1");
                    TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity2");

                    ddlSupplier.Enabled = false;
                    txtPerdayOutput.Enabled = false;
                    txtAllocationQuantity1.Enabled = false;
                    txtAllocationQuantity2.Enabled = false;
                }
                rbtnPartialFull.Enabled = false;
                img_btnAdd.Enabled = false;
            }
        }

        protected void rbtnPartialFullQA_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((RadioButtonList)sender).NamingContainer as GridViewRow;
            GridView grdChildVA_Quantity_Allocation = (GridView)row.FindControl("grdChildVA_Quantity_Allocation");


            RadioButtonList rbtnPartialFull = (RadioButtonList)row.FindControl("rbtnPartialFullQA");
            ImageButton img_btnAdd = (ImageButton)row.FindControl("img_btnAdd");
            int radiobuttonVal = Convert.ToInt32(rbtnPartialFull.SelectedValue);

            if (radiobuttonVal == 1)
            {
                img_btnAdd.Visible = true;
            }
            if (radiobuttonVal == 0)
            {
                if (grdChildVA_Quantity_Allocation.Rows.Count > 1)
                {
                    rbtnPartialFull.SelectedValue = "1";
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot select Full because it is already divided into two or more than vender.');$('#spinnL').css('display', 'none');", true);
                }
                else
                {
                    img_btnAdd.Visible = false;
                }
            }
        }

        protected void grdVA_Quantity_Allocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            HiddenField hdnStyleid = (HiddenField)e.Row.FindControl("hdnStyleid");
            HiddenField HiddenField_OrderDetailID = (HiddenField)e.Row.FindControl("HiddenField_OrderDetailID");
            HiddenField hdnVAId = (HiddenField)e.Row.FindControl("hdnVAId");
            GridView grdChildVA_Quantity_Allocation = (GridView)e.Row.FindControl("grdChildVA_Quantity_Allocation");
            CheckBox cbQA = (CheckBox)e.Row.FindControl("cbQA");
            ImageButton img_btnAdd = (ImageButton)e.Row.FindControl("img_btnAdd");
            RadioButtonList rbtnPartialFullQA = (RadioButtonList)e.Row.FindControl("rbtnPartialFullQA");

            bool IsPartial = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsPartial").ToString());
            bool IsVARealocation = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsVARellocation").ToString());
            if (IsPartial == true)
            {
                rbtnPartialFullQA.SelectedValue = "1";
                img_btnAdd.Visible = true;
            }
            else
            {
                rbtnPartialFullQA.SelectedValue = "0";
                img_btnAdd.Visible = false;
            }
            if (IsVARealocation == true)
            {
                cbQA.Checked = false;
            }
            else
            {
                cbQA.Checked = false;
            }

            DataSet dtVaDetails = new DataSet();
            dtVaDetails = OrderControllerInstance.GetRell_VA_Details(Convert.ToInt32(hdnStyleid.Value.ToString()), Convert.ToInt32(hdnVAId.Value.ToString()), Convert.ToInt32(HiddenField_OrderDetailID.Value.ToString()));
            if (dtVaDetails.Tables[0].Rows.Count == 0)
            {
                dtVaDetails.Tables[0].Rows.Add();
                dtVaDetails.Tables[0].Rows[dtVaDetails.Tables[0].Rows.Count - 1]["Committed_EndDate"] = "1900-01-01";
            }

            grdChildVA_Quantity_Allocation.DataSource = dtVaDetails.Tables[0];
            grdChildVA_Quantity_Allocation.DataBind();

            if (cbQA.Checked == false)
            {
                img_btnAdd.Enabled = false;
                rbtnPartialFullQA.Enabled = false;
                //gvChildReallocation.Enabled = false;
                for (int i = 0; i < grdChildVA_Quantity_Allocation.Rows.Count; i++)
                {
                    TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity1");
                    txtAllocationQuantity1.Enabled = false;
                    TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity2");
                    txtAllocationQuantity2.Enabled = false;
                    DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[i].FindControl("ddlSupplierAllocation");
                    ddlSupplier.Enabled = false;
                    TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtPerdayOutput");
                    txtPerdayOutput.Enabled = false;
                }
            }
            else
            {
                img_btnAdd.Enabled = true;
                rbtnPartialFullQA.Enabled = true;

                grdChildVA_Quantity_Allocation.Enabled = true;
                for (int i = 0; i < grdChildVA_Quantity_Allocation.Rows.Count; i++)
                {
                    TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity1");
                    txtAllocationQuantity1.Enabled = true;
                    TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity2");
                    txtAllocationQuantity2.Enabled = true;
                    DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[i].FindControl("ddlSupplierAllocation");
                    ddlSupplier.Enabled = true;
                    TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtPerdayOutput");
                    txtPerdayOutput.Enabled = true;
                }
            }
        }

        protected void grdVA_Quantity_Allocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {
                DataTable dtVADetailsUnit = OrderControllerInstance.GetVADetails().Tables[0];
                int id = int.Parse(e.CommandArgument.ToString());
                GridView grdChildVA_Quantity_Allocation = (GridView)grdVA_Quantity_Allocation.Rows[id].FindControl("grdChildVA_Quantity_Allocation");
                for (int i = 0; i < grdChildVA_Quantity_Allocation.Rows.Count; i++)
                {
                    DropDownList ddlSupplier = (DropDownList)grdChildVA_Quantity_Allocation.Rows[i].FindControl("ddlSupplierAllocation");
                    TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtPerdayOutput");
                    TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity1");
                    TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[i].FindControl("txtAllocationQuantity2");
                    if (ddlSupplier.SelectedValue == "-1" && txtPerdayOutput.Text == "")
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Blank row need to be filled first.');$('#spinnL').css('display', 'none');", true);
                        return;
                    }
                }
                if ((dtVADetailsUnit.Rows.Count - 1) == grdChildVA_Quantity_Allocation.Rows.Count)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot add rows more than Vender count.');$('#spinnL').css('display', 'none');", true);
                    return;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    DataTable dtmerge = new DataTable();

                    dtnew = gridTableVARellocation(grdChildVA_Quantity_Allocation);
                    DataRow newrow = dtnew.NewRow();
                    dtnew.Rows.Add(newrow);
                    dtnew.Rows[dtnew.Rows.Count - 1]["Committed_EndDate"] = "1900-01-01";
                    dtmerge = dtnew;

                    grdChildVA_Quantity_Allocation.DataSource = dtmerge;
                    grdChildVA_Quantity_Allocation.DataBind();
                }
            }
        }

        protected void grdChildVA_Quantity_Allocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Add by Surendra 2 for put loop all data rows on 04-04-2018.
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // check all cells in one row
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;
                        if (button != null && button.CommandName == "Delete")
                        {
                            // Add delete confirmation
                            button.OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
                        }
                    }
                }
            }
            DropDownList ddlSupplier = (DropDownList)e.Row.FindControl("ddlSupplierAllocation");
            TextBox txtPerdayOutput = (TextBox)e.Row.FindControl("txtPerdayOutput");
            TextBox txtAllocationQuantity1 = (TextBox)e.Row.FindControl("txtAllocationQuantity1");
            TextBox txtCommitted_EndDate = (TextBox)e.Row.FindControl("txtCommitted_EndDate");
            TextBox txtAllocationQuantity2 = (TextBox)e.Row.FindControl("txtAllocationQuantity2");
            HiddenField hdnStyleid = (HiddenField)e.Row.Parent.Parent.Parent.FindControl("hdnStyleid");
            HiddenField hdnSupplierId = (HiddenField)e.Row.FindControl("hdnSupplierId");
            DataSet dtVA_Details = new DataSet();
            string supplierid = hdnSupplierId.Value.ToString() == "" ? "0" : hdnSupplierId.Value.ToString();
            dtVA_Details = OrderControllerInstance.GetVADetails();

            ddlSupplier.DataSource = dtVA_Details.Tables[0];
            ddlSupplier.DataValueField = "UnitID";
            ddlSupplier.DataTextField = "UnitName";
            ddlSupplier.DataBind();


            ddlSupplier.SelectedValue = DataBinder.Eval(e.Row.DataItem, "SupplierId").ToString();
            txtPerdayOutput.Text = txtPerdayOutput.Text == "0" ? "" : txtPerdayOutput.Text;
            txtAllocationQuantity1.Text = txtAllocationQuantity1.Text == "0" ? "" : txtAllocationQuantity1.Text;
            txtAllocationQuantity2.Text = txtAllocationQuantity2.Text == "0" ? "" : txtAllocationQuantity2.Text;
            InHouseFact = CheckUnitId(ddlSupplier.SelectedValue);
            if (InHouseFact == true || ddlSupplier.SelectedValue == "-1")
            {
                txtCommitted_EndDate.Enabled = false;
            }
            else
            {
                txtCommitted_EndDate.Enabled = true;
            }
            if (txtCommitted_EndDate.Text.Trim() != "")
            {
                txtCommitted_EndDate.Enabled = false;
                txtCommitted_EndDate.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void grdChildVA_Quantity_Allocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow gvRow = gv.NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;

            GridView grdChildVA_Quantity_Allocation = (GridView)grdVA_Quantity_Allocation.Rows[rowIndex].FindControl("grdChildVA_Quantity_Allocation");
            HiddenField hdnStyleid = (HiddenField)grdVA_Quantity_Allocation.Rows[rowIndex].FindControl("hdnStyleid");
            HiddenField hdnVAId = (HiddenField)grdVA_Quantity_Allocation.Rows[rowIndex].FindControl("hdnVAId");
            DataTable dtChildVA_Quantity_Allocation = new DataTable();
            dtChildVA_Quantity_Allocation.Columns.Add("SupplierId");
            dtChildVA_Quantity_Allocation.Columns.Add("AllocationQty1");
            dtChildVA_Quantity_Allocation.Columns.Add("AllocationQty2");
            dtChildVA_Quantity_Allocation.Columns.Add("PerDayOutPut");
            dtChildVA_Quantity_Allocation.Columns.Add("StartDate");
            dtChildVA_Quantity_Allocation.Columns.Add("EndDate");
            dtChildVA_Quantity_Allocation.Columns.Add("Committed_EndDate");


            foreach (GridViewRow row in grdChildVA_Quantity_Allocation.Rows)
            {
                DataRow dr = dtChildVA_Quantity_Allocation.NewRow();

                DropDownList ddlSupplier = (DropDownList)row.Cells[1].FindControl("ddlSupplierAllocation");
                TextBox txtPerdayOutput = (TextBox)row.Cells[3].FindControl("txtPerdayOutput");
                TextBox txtAllocationQuantity1 = (TextBox)row.Cells[0].FindControl("txtAllocationQuantity1");
                TextBox txtAllocationQuantity2 = (TextBox)row.Cells[0].FindControl("txtAllocationQuantity2");
                TextBox txtCommitted_EndDate = (TextBox)row.Cells[4].FindControl("txtCommitted_EndDate");
                string CommitDate = "";
                if (txtCommitted_EndDate.Text.Trim() == "")
                {
                    CommitDate = "1900-01-01";
                }
                else
                {
                    CommitDate = txtCommitted_EndDate.Text.Trim().Substring(0, txtCommitted_EndDate.Text.Trim().Length - 6);
                }

                dr["SupplierId"] = ddlSupplier.Text;
                dr["AllocationQty1"] = txtAllocationQuantity1.Text;
                dr["AllocationQty2"] = txtAllocationQuantity2.Text;
                dr["PerDayOutPut"] = txtPerdayOutput.Text;
                dr["Committed_EndDate"] = CommitDate;

                dtChildVA_Quantity_Allocation.Rows.Add(dr);
            }

            int index = Convert.ToInt32(e.RowIndex);
            DataTable dtCurrentChildVAQuantity_Allocation = dtChildVA_Quantity_Allocation;

            if (dtCurrentChildVAQuantity_Allocation.Rows.Count > 1)
            {
                dtCurrentChildVAQuantity_Allocation.Rows[index]["SupplierId"] = dtCurrentChildVAQuantity_Allocation.Rows[index]["SupplierId"].ToString() == "" ? "0" : dtCurrentChildVAQuantity_Allocation.Rows[index]["SupplierId"];
                if (Convert.ToInt32(dtCurrentChildVAQuantity_Allocation.Rows[index]["SupplierId"]) > 0)
                {
                    OrderControllerInstance.DeleteVA_Quantity_AllocationEntry(Convert.ToInt32(dtCurrentChildVAQuantity_Allocation.Rows[index]["SupplierId"]), Convert.ToInt32(hdnVAId.Value.ToString()));
                }
                dtCurrentChildVAQuantity_Allocation.Rows.RemoveAt(index);
            }
            else
            {
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Atleast one Entry need to be added.');$('#spinnL').css('display', 'none');", true);
                return;
            }

            grdChildVA_Quantity_Allocation.DataSource = dtCurrentChildVAQuantity_Allocation;
            grdChildVA_Quantity_Allocation.DataBind();

            Page page2 = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page2, page2.GetType(), "err_msg", "alert('Record delete successfully.');$('#spinnL').css('display', 'none');", true);
        }

        protected void ddlSupplierAllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            GridViewRow parentRow = ddl.NamingContainer.Parent.Parent.Parent.Parent as GridViewRow;
            int rowIndex = row.RowIndex;
            int parentRowIndex = parentRow.RowIndex;

            GridView grdChildVA_Quantity_Allocation = (GridView)grdVA_Quantity_Allocation.Rows[parentRowIndex].FindControl("grdChildVA_Quantity_Allocation");
            DropDownList ddlFactory = (DropDownList)grdChildVA_Quantity_Allocation.Rows[rowIndex].FindControl("ddlSupplierAllocation");
            TextBox txtCommitted_EndDate = (TextBox)grdChildVA_Quantity_Allocation.Rows[rowIndex].FindControl("txtCommitted_EndDate");

            if (Convert.ToInt32(ddlFactory.SelectedValue) > 0)
            {
                InHouseFact = CheckUnitId(ddlFactory.SelectedValue);
                if (InHouseFact == true || ddlFactory.SelectedValue == "-1")
                {
                    txtCommitted_EndDate.Enabled = false;
                }
                else
                {
                    txtCommitted_EndDate.Enabled = true;
                }
            }
            for (int j = 0; j < grdChildVA_Quantity_Allocation.Rows.Count; j++)
            {
                DropDownList ddlCheckFactory = (DropDownList)grdChildVA_Quantity_Allocation.Rows[j].FindControl("ddlSupplierAllocation");

                if (ddlCheckFactory.SelectedValue == ddlFactory.SelectedValue && j != rowIndex && ddlFactory.SelectedValue != "-1")
                {
                    ddlFactory.SelectedValue = "-1";
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You can not select this vender because it is already selected.');$('#spinnL').css('display', 'none');", true);
                    return;
                }
            }
        }
        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            GridViewRow row = txt.NamingContainer as GridViewRow;
            GridViewRow parentRow = txt.NamingContainer.Parent.Parent.Parent.Parent as GridViewRow;
            int rowIndex = row.RowIndex;
            int parentRowIndex = parentRow.RowIndex;

            GridView gvChildVA_Details = (GridView)gvVA_Details.Rows[parentRowIndex].FindControl("gvChildVA_Details");
            TextBox txtSupplier = (TextBox)gvChildVA_Details.Rows[rowIndex].FindControl("txtSupplier");
            for (int j = 0; j < gvChildVA_Details.Rows.Count; j++)
            {
                TextBox txtCheckSupplier = (TextBox)gvChildVA_Details.Rows[j].FindControl("txtSupplier");

                // below is comented by sanjeev 27/01/2022
                //if (txtCheckSupplier.Text.Trim() == txtSupplier.Text.Trim() && j != rowIndex)
                //{
                //    txtSupplier.Text = "";
                //    Page page = HttpContext.Current.Handler as Page;
                //    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You can not enter this vender because it is already entered.');$('#spinnL').css('display', 'none');", true);
                //    return;
                //}
            }

        }
        //protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList ddl = sender as DropDownList;
        //    GridViewRow row = ddl.NamingContainer as GridViewRow;
        //    GridViewRow parentRow = ddl.NamingContainer.Parent.Parent.Parent.Parent as GridViewRow;
        //    int rowIndex = row.RowIndex;
        //    int parentRowIndex = parentRow.RowIndex;

        //    GridView gvChildVA_Details = (GridView)gvVA_Details.Rows[parentRowIndex].FindControl("gvChildVA_Details");
        //    DropDownList ddlFactory = (DropDownList)gvChildVA_Details.Rows[rowIndex].FindControl("ddlSupplier");

        //    for (int j = 0; j < gvChildVA_Details.Rows.Count; j++)
        //    {
        //        DropDownList ddlCheckFactory = (DropDownList)gvChildVA_Details.Rows[j].FindControl("ddlSupplier");

        //        if (ddlCheckFactory.SelectedValue == ddlFactory.SelectedValue && j != rowIndex && ddlFactory.SelectedValue != "-1")
        //        {
        //            ddlFactory.SelectedValue = "-1";
        //            Page page = HttpContext.Current.Handler as Page;
        //            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You can not select this vender because it is already selected.');$('#spinnL').css('display', 'none');", true);
        //            return;
        //        }
        //    }
        //}

        protected void btnVA_Quantity_Allocation_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdVA_Quantity_Allocation.Rows.Count; i++)
                {
                    CheckBox CheckHeaderQA = (CheckBox)grdVA_Quantity_Allocation.HeaderRow.FindControl("CheckHeaderQA");

                    RadioButtonList rbtnPartialFullQA = (RadioButtonList)grdVA_Quantity_Allocation.Rows[i].FindControl("rbtnPartialFullQA");
                    HiddenField hdnVAId = (HiddenField)grdVA_Quantity_Allocation.Rows[i].FindControl("hdnVAId");
                    HiddenField hdnStyleid = (HiddenField)grdVA_Quantity_Allocation.Rows[i].FindControl("hdnStyleid");
                    HiddenField HiddenField_OrderDetailID = (HiddenField)grdVA_Quantity_Allocation.Rows[i].FindControl("HiddenField_OrderDetailID");
                    GridView grdChildVA_Quantity_Allocation = (GridView)grdVA_Quantity_Allocation.Rows[i].FindControl("grdChildVA_Quantity_Allocation");
                    CheckBox cbQA = (CheckBox)grdVA_Quantity_Allocation.Rows[i].FindControl("cbQA");
                    ImageButton img_btnAdd = (ImageButton)grdVA_Quantity_Allocation.Rows[i].FindControl("img_btnAdd");
                    bool Validate = false;
                    if (cbQA.Checked)
                    {
                        Validate = ValidationVAAllocation(grdChildVA_Quantity_Allocation);
                    }
                    int RedioListVal = Convert.ToInt32(rbtnPartialFullQA.SelectedValue);
                    bool RedioVal = false;

                    int VA_ID = 0;
                    if (hdnVAId != null)
                    {
                        VA_ID = Convert.ToInt32(hdnVAId.Value);
                    }
                    int styleid = 0;
                    if (hdnStyleid != null)
                    {
                        styleid = Convert.ToInt32(hdnStyleid.Value);
                    }
                    int orderdetailid = 0;
                    if (HiddenField_OrderDetailID != null)
                    {
                        orderdetailid = Convert.ToInt32(HiddenField_OrderDetailID.Value);
                    }
                    if (RedioListVal == 1)
                    {
                        RedioVal = true;
                    }
                    bool IsRealocationFull = false;
                    if (cbQA.Checked == true)
                    {
                        IsRealocationFull = true;
                    }
                    if (cbQA.Checked)
                    {
                        if (Validate)
                        {

                            for (int j = 0; j < grdChildVA_Quantity_Allocation.Rows.Count; j++)
                            {
                                DropDownList ddlSupplierAllocation = (DropDownList)grdChildVA_Quantity_Allocation.Rows[j].FindControl("ddlSupplierAllocation");
                                TextBox txtAllocationQuantity1 = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtAllocationQuantity1");
                                TextBox txtAllocationQuantity2 = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtAllocationQuantity2");
                                TextBox txtPerdayOutput = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtPerdayOutput");
                                TextBox txtCommitted_EndDate = (TextBox)grdChildVA_Quantity_Allocation.Rows[j].FindControl("txtCommitted_EndDate");

                                string AllocationQty1 = StripTagsRegex(txtAllocationQuantity1.Text).Trim() == "" ? "0" : StripTagsRegex(txtAllocationQuantity1.Text).Trim();
                                string AllocationQty2 = StripTagsRegex(txtAllocationQuantity2.Text).Trim() == "" ? "0" : StripTagsRegex(txtAllocationQuantity2.Text).Trim();
                                string PerdayOutPut = StripTagsRegex(txtPerdayOutput.Text).Trim() == "" ? "0" : StripTagsRegex(txtPerdayOutput.Text).Trim();
                                int SupplierId = -1;

                                if (ddlSupplierAllocation.SelectedValue != "-1")
                                {
                                    SupplierId = Convert.ToInt32(ddlSupplierAllocation.SelectedValue);
                                }

                                string comitDate = txtCommitted_EndDate.Text.Trim();
                                if (comitDate != "")
                                    comitDate = comitDate.Substring(0, comitDate.Length - 6);

                                OrderControllerInstance.SaveVAReAllocationPartialOrFull(styleid, VA_ID, RedioVal, IsRealocationFull);

                                OrderControllerInstance.InsertVA_AllocationDetails(styleid, VA_ID, SupplierId, Convert.ToInt32(AllocationQty1), Convert.ToInt32(AllocationQty2), Convert.ToInt32(PerdayOutPut), comitDate, orderdetailid);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Data save successfully.');$('#spinnL').css('display', 'none');", true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void btnVA_Details_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvVA_Details.Rows.Count; i++)
                {

                    HiddenField hdnVA_ID = (HiddenField)gvVA_Details.Rows[i].FindControl("hdnVA_ID");
                    HiddenField hdnStyleid = (HiddenField)gvVA_Details.Rows[i].FindControl("hdnStyleid");
                    TextBox lblIntialAgreementRate = (TextBox)gvVA_Details.Rows[i].FindControl("lblIntialAgreementRate");
                    GridView gvChildVA_Details = (GridView)gvVA_Details.Rows[i].FindControl("gvChildVA_Details");

                    bool Validate = ValidationVADetails(gvChildVA_Details);

                    int VA_ID = 0;
                    if (hdnVA_ID != null)
                    {
                        VA_ID = Convert.ToInt32(hdnVA_ID.Value);
                    }
                    int styleid = 0;
                    if (hdnStyleid != null)
                    {
                        styleid = Convert.ToInt32(hdnStyleid.Value);
                    }
                    string IntialAgreementRate = StripTagsRegex(lblIntialAgreementRate.Text).Trim() == "" ? "0" : StripTagsRegex(lblIntialAgreementRate.Text).Trim();
                    if (Validate)
                    {
                        for (int j = 0; j < gvChildVA_Details.Rows.Count; j++)
                        {
                            TextBox txtSupplier = (TextBox)gvChildVA_Details.Rows[j].FindControl("txtSupplier");
                            TextBox txtInitial_Agreed_Rate = (TextBox)gvChildVA_Details.Rows[j].FindControl("txtInitial_Agreed_Rate");
                            CheckBox chkFinalize = (CheckBox)gvChildVA_Details.Rows[j].FindControl("chkFinalize");
                            HiddenField hdnRiskSupplierID = (HiddenField)gvChildVA_Details.Rows[j].FindControl("hdnRiskSupplierID");

                            bool Finalize = false;
                            if (chkFinalize.Checked == true) { Finalize = true; }

                            string Initial_Agreed_Rate = StripTagsRegex(txtInitial_Agreed_Rate.Text).Trim() == "" ? "0" : StripTagsRegex(txtInitial_Agreed_Rate.Text).Trim();
                            string SupplierName = StripTagsRegex(txtSupplier.Text).Trim() == "" ? "" : StripTagsRegex(txtSupplier.Text).Trim();
                            int RiskSupplierID = hdnRiskSupplierID.Value.Trim() == "" ? 0 : Convert.ToInt32(hdnRiskSupplierID.Value.Trim());

                            OrderControllerInstance.InsertVA_Details(styleid, VA_ID, SupplierName, Finalize, Convert.ToDouble(Initial_Agreed_Rate.Replace(",", "")), Convert.ToDouble(IntialAgreementRate.Replace(",", "")), RiskSupplierID);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Data save successfully.');$('#spinnL').css('display', 'none');", true);
                BindControlva(styleId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }
        public Boolean CheckUnitId(string UnitId)
        {
            return ObjAdminController.getProdctionIDInhouse(UnitId);
        }
    }

}