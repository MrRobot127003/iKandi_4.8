using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using System.Text;
using iKandi.Common;
using System.Collections;

namespace iKandi.Web.Internal.Production
{
    public partial class ProductionDetails : System.Web.UI.Page
    {
        public string OrderDetailId
        {
            get;
            set;
        }
        public static int TableRowCount = 0;
        public static int RescanCycleCount = 0;
        public static int TotalPass = 0;
        public static int TotalFail = 0;
        int RowSpan = 1;
        DataTable dtva = null;
        DataTable DTDonline = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProductionDetails_History();
                BindDropDown();
                getRescanDetails(); 
            }
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }
        ProductionController objProductionController = new ProductionController();
        iKandi.BLL.OrderController OrderControllerInstance = new BLL.OrderController();


        private void BindProductionDetails_History()
        {
            DataTable DTSAMValue = null;
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Request.QueryString["OrderDetailId"].ToString();
                hdnOrderdetsilid.Value = OrderDetailId;
            }
            if (null != Request.QueryString["SerialNumber"])
            {
                ltrlSerialNumber.Text = Request.QueryString["SerialNumber"].ToString();               
            }
            if (null != Request.QueryString["StyleNumber"])
            {
                ltrlStyleNumber.Text = Request.QueryString["StyleNumber"].ToString();               
            }
            if (null != Request.QueryString["Quantity"])
            {
                ltrlQuantity.Text = String.Format("{0:#,##0}", Request.QueryString["Quantity"].ToString());
            }

            DataSet DS = objProductionController.Get_ProductionDetails_History(OrderDetailId);
           
            DataTable DTStitch = DS.Tables[0];
            DataTable DTRescan = DS.Tables[1];
            DataTable DTDate = DS.Tables[2];          
            DTDonline = DS.Tables[4];

            RescanCycleCount = Convert.ToInt16(DS.Tables[5].Rows[0]["RescanCycleCount"]);
            lblCycleNo.Text = RescanCycleCount.ToString();
            hdnRescanQty_C47.Value = DS.Tables[5].Rows[0]["RescanQty_C47"].ToString();
            hdnRescanQty_C45.Value = DS.Tables[5].Rows[0]["RescanQty_C45"].ToString();
            hdnRescanQty_D169.Value = DS.Tables[5].Rows[0]["RescanQty_D169"].ToString();

            if ((lblCycleNo.Text == "0") || (lblCycleNo.Text == "15"))
                btnAddCycle.Visible = false;
            else
                btnAddCycle.Visible = true;

            dtva = DS.Tables[0];

            if (DTDonline.Rows.Count > 0)
            {
                grddoonline.DataSource = DTDonline;
                grddoonline.DataBind();
            }

            if (DTDate.Rows.Count > 0 && DS.Tables[3] != null)
            {

                DTSAMValue = DS.Tables[3];
                int i = 1, j = 1;
                DTDate.Columns.Add("ID", typeof(System.Int32));
                foreach (DataRow row in DTDate.Rows)
                {
                    row["ID"] = i;
                    i = i + 1;
                }
                DTSAMValue.Columns.Add("ID", typeof(System.Int32));
                foreach (DataRow row in DTSAMValue.Rows)
                {
                    row["ID"] = j;
                    j = j + 1;
                }
                DataTable DTSAM = JoinTwoDataTablesOnOneColumn(DTDate, DTSAMValue, "ID");
                DTSAM.Columns.Remove("ID");
                DataTable DTSAMCut = JoinTwoDataTablesOnOneColumn(DTStitch, DTSAM, "Date");


                DTSAMCut.Columns.Remove("Date");
                DTSAMCut.Columns.Remove("CutQty");
                DTSAMCut.Columns.Remove("CutReadyQty");
                DTSAMCut.Columns.Remove("CutIssue");
                DTSAMCut.Columns.Remove("StitchQty");
                DTSAMCut.Columns.Remove("FinishQty");
                DTSAMCut.Columns.Remove("IsDoOnlie_Rescan");


                if (DTSAMCut.Columns.Contains("SamDate"))
                {

                }
                else
                {
                    grdSAM.DataSource = DTSAMCut;
                    grdSAM.DataBind();
                    td2.Visible = true;
                }
            }
            ViewState["DTRescan"] = DTRescan;
            TableRowCount = DTRescan.Rows.Count;
           
            grdProductionDetails.DataSource = DTStitch;
            grdProductionDetails.DataBind();

            grdFinish.DataSource = DTStitch;
            grdFinish.DataBind();

            grdfinshs.DataSource = DTStitch;
            grdfinshs.DataBind();

            grdRescan.DataSource = DTRescan;
            grdRescan.DataBind();
           
            BindVa();
            BindHalfSitchInOutQty();
            getFaultTypeRescan();

            int sum = Convert.ToInt32(DTStitch.Compute("SUM(CutIssue)", string.Empty));
            if (sum > 0)
            {
                grdoutcut.DataSource = DTStitch;
                grdoutcut.DataBind();
            }
            else
            {
                td10.Visible = false;
            }
        }
        public void BindVa()
        {
            grdva.DataSource = dtva;
            grdva.DataBind();
        }       

        public void getFaultTypeRescan()
        {
            getFaultTypeView();

            int CycleCount = lblCycleNo.Text == "" ? 0 : Convert.ToInt16(lblCycleNo.Text);
            if (CycleCount == 0)
                CycleCount = 1;

            DataSet dsGetFaultTypeRescan = OrderControllerInstance.GetFaultType_Rescan(Convert.ToInt32(hdnOrderdetsilid.Value.ToString()), CycleCount);
           
            DataTable dtFaultTypeRescan = dsGetFaultTypeRescan.Tables[0];
            DataTable dtFaultInPercent = dsGetFaultTypeRescan.Tables[1];

            ViewState["dtFaultTypeRescan"] = dtFaultTypeRescan;
            ViewState["dtFaultInPercent"] = dtFaultInPercent;


            if (dtFaultTypeRescan.Rows.Count > 0)
            {
                grdFaultTypeRescan.DataSource = dtFaultTypeRescan;
                grdFaultTypeRescan.DataBind();
                tableFaultTypeRescan.Visible = true;
            }
            else
            {
                tableFaultTypeRescan.Visible = false;
            }

            int desgId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            if (desgId == 54 || desgId == 19 || desgId == 13)
            {
                btnRescanCheckSubmit.Visible = true;
            }
            else
            {
                btnRescanCheckSubmit.Visible = false;
                tableFaultTypeRescan.Visible = false;
            }
        }

        public void getFaultTypeView()
        {
            DataTable dtGetFaultTypeRescan = OrderControllerInstance.GetSubFaultType_View(Convert.ToInt32(hdnOrderdetsilid.Value.ToString()));

            if (dtGetFaultTypeRescan.Rows.Count > 0)
            {
                grdFultView.DataSource = dtGetFaultTypeRescan;
                grdFultView.DataBind();

                int CycleCount = lblCycleNo.Text == "" ? 0 : Convert.ToInt16(lblCycleNo.Text);
                if (CycleCount == 0)
                    CycleCount = 1;                

                for (int icol = 1; icol <= CycleCount; icol++)
                {

                    DataRow[] foundIsCycl = dtGetFaultTypeRescan.Select("RescanCycle" + icol + " = 1");
                    if (foundIsCycl.Length > 0)
                    {
                        grdFultView.Columns[1 + icol].Visible = true;
                    }                   
                }
            }
            else
            {
                grdFultView.DataSource = dtGetFaultTypeRescan;
                grdFultView.DataBind();
            }
            int desgId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            if (desgId == 54 || desgId == 19 || desgId == 13)
            {
                trFaultType.Visible = false;
                trFaultTypeView.Visible = false;
            }

            if (desgId == 44 || desgId == 45)
            {
                trFaultType.Visible = true;
                trFaultTypeView.Visible = true;
            }
            else
            {
                trFaultType.Visible = false;
                trFaultTypeView.Visible = false;
            }
        }

        public void BindHalfSitchInOutQty()
        {
            DataSet DS = objProductionController.GetHalfStitchInOutQty(11, Convert.ToInt32(OrderDetailId));

            DataTable DTHalfStcInHouse = DS.Tables[0];
            DataTable DTHalfStcOutHouse = DS.Tables[1];

            DataTable DTV1 = DS.Tables[2];
            DataTable DTV2 = DS.Tables[3];
            DataTable DTV3 = DS.Tables[4];
            DataTable DTV4 = DS.Tables[5];
            DataTable DTV5 = DS.Tables[6];

            if (DTHalfStcInHouse.Rows.Count > 0)
            {
                grdhalfstitchInHouse.DataSource = DTHalfStcInHouse;
                grdhalfstitchInHouse.DataBind();
            }
            else
            {
                td5.Visible = false;
            }
            if (DTHalfStcOutHouse.Rows.Count > 0)
            {
                grdhalfstitchOuthouse.DataSource = DTHalfStcOutHouse;
                grdhalfstitchOuthouse.DataBind();
            }
            else
            {
                td6.Visible = false;
            }
            //===========v1=======================//

            if (DTV1.Rows.Count > 0)
            {
                grdv1.DataSource = DTV1;
                grdv1.Columns[0].HeaderText = DTV1.Rows[0]["V1Name"].ToString();
                grdv1.DataBind();
            }
            else
            {
                td7.Visible = false;
            }

            if (DTV2.Rows.Count > 0)
            {
                grdv2.DataSource = DTV2;
                grdv2.Columns[0].HeaderText = DTV2.Rows[0]["V2Name"].ToString();
                grdv2.DataBind();
            }
            else
            {
                td8.Visible = false;
            }

            if (DTV3.Rows.Count > 0)
            {
                grdv3.DataSource = DTV3;
                grdv3.Columns[0].HeaderText = DTV3.Rows[0]["V3Name"].ToString();
                grdv3.DataBind();
            }
            else
            {
                td11.Visible = false;
            }

            if (DTV4.Rows.Count > 0)
            {
                grdv4.DataSource = DTV4;
                grdv4.Columns[0].HeaderText = DTV4.Rows[0]["V4Name"].ToString();
                grdv4.DataBind();
            }
            else
            {
                td12.Visible = false;
            }

            if (DTV5.Rows.Count > 0)
            {
                grdv5.DataSource = DTV5;
                grdv5.Columns[0].HeaderText = DTV5.Rows[0]["V5Name"].ToString();
                grdv5.DataBind();
            }
            else
            {
                td13.Visible = false;
            }
        }

        public static DataTable JoinTwoDataTablesOnOneColumn(DataTable dtblLeft, DataTable dtblRight, string colToJoinOn)
        {
            //Change column name to a temp name so the LINQ for getting row data will work properly.
            string strTempColName = colToJoinOn + "_2";
            if (dtblRight.Columns.Contains(colToJoinOn))
                dtblRight.Columns[colToJoinOn].ColumnName = strTempColName;

            //Get columns from dtblLeft
            DataTable dtblResult = dtblLeft.Clone();

            //Get columns from dtblRight
            var dt2Columns = dtblRight.Columns.OfType<DataColumn>().Select(dc => new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));

            //Get columns from dtblRight that are not in dtblLeft
            var dt2FinalColumns = from dc in dt2Columns.AsEnumerable()
                                  where !dtblResult.Columns.Contains(dc.ColumnName)
                                  select dc;

            //Add the rest of the columns to dtblResult
            dtblResult.Columns.AddRange(dt2FinalColumns.ToArray());

            //No reason to continue if the colToJoinOn does not exist in both DataTables.
            if (!dtblLeft.Columns.Contains(colToJoinOn) || (!dtblRight.Columns.Contains(colToJoinOn) && !dtblRight.Columns.Contains(strTempColName)))
            {
                if (!dtblResult.Columns.Contains(colToJoinOn))
                    dtblResult.Columns.Add(colToJoinOn);
                return dtblResult;
            }
            var rowDataLeftOuter = from rowLeft in dtblLeft.AsEnumerable()
                                   join rowRight in dtblRight.AsEnumerable() on rowLeft[colToJoinOn] equals rowRight[strTempColName] into gj
                                   from subRight in gj.DefaultIfEmpty()
                                   select rowLeft.ItemArray.Concat((subRight == null) ? (dtblRight.NewRow().ItemArray) : subRight.ItemArray).ToArray();


            //Add row data to dtblResult
            foreach (object[] values in rowDataLeftOuter)
                dtblResult.Rows.Add(values);

            //Change column name back to original
            dtblRight.Columns[strTempColName].ColumnName = colToJoinOn;

            //Remove extra column from result
            dtblResult.Columns.Remove(strTempColName);

            return dtblResult;
        }

        protected void grdSAM_DataBound(object sender, EventArgs e)
        {
            this.grdSAM.HeaderRow.CssClass = "sam_heading";
        }

        protected void grdSAM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Controls.Count; i++)
                {
                    var headerCell = e.Row.Controls[i] as DataControlFieldHeaderCell;
                    if (headerCell != null)
                    {
                        headerCell.Text = "SAM (" + headerCell.Text + ")";

                    }
                }
            }
        }
        int VaQtyCount = 0;
        protected void grdva_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {                   
                    HiddenField txtName = (e.Row.FindControl("hdnDate") as HiddenField);
                    if (txtName.Value != "")
                    {
                        if (txtName.Value != "Grand Total")
                        {
                            DateTime d = Convert.ToDateTime(txtName.Value);
                            DataTable dtva = objProductionController.GetValueAddtionQty(Convert.ToInt32(OrderDetailId), d);
                            txtName.Value = dtva.Rows[0]["ValueAddQty"].ToString();
                            if (txtName.Value != "")
                            {
                                VaQtyCount += Convert.ToInt32(txtName.Value);
                            }
                        }
                    }
                    if (string.Equals("Grand Total", txtName.Value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        txtName.Value = VaQtyCount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                }
            }
        }

        private void BindDropDown()
        {
            int CycleCount = lblCycleNo.Text == "" ? 0 : Convert.ToInt16(lblCycleNo.Text);
            DataTable DTRescan = (DataTable)ViewState["DTRescan"];
            ddlRescanCycle.Items.Clear();

            if (CycleCount > 0)
            {
                for(int icell = CycleCount; icell >= 1; icell--)
                {
                    DataRow[] foundIsCycl = DTRescan.Select("IsCycl" + icell + " = 1");

                    if (foundIsCycl.Length > 0)
                    {
                        CycleCount = icell;
                        break;
                    }
                }

                for(int iItem = 1; iItem <= CycleCount; iItem++)
                {
                    ddlRescanCycle.Items.Add(new ListItem("Cycle " + iItem, iItem.ToString()));
                }
                ddlRescanCycle.SelectedValue = CycleCount.ToString();
            }
        }

        public void getRescanDetails()
        {
            int CycleNo = 0;

            if (ddlRescanCycle.Items.Count > 0)
            {
                CycleNo = Convert.ToInt32(ddlRescanCycle.SelectedValue);
                lblCycleEntryNo.Text = "(Cycle " + CycleNo.ToString() + ")";

                DataSet dsGetRescan = OrderControllerInstance.GetRescan_History(Convert.ToInt32(hdnOrderdetsilid.Value.ToString()), CycleNo);
                DataTable dtRescanDetail = dsGetRescan.Tables[2];
                tableRescandetails.Visible = true;

                int TotalPendingQty = Convert.ToInt32(dsGetRescan.Tables[1].Rows[0]["TotalPendingQty"].ToString());

                if((dsGetRescan.Tables[0].Rows.Count > 0) && (TotalPendingQty > 0))
                {
                    grdRescanFillData.DataSource = dsGetRescan.Tables[0];
                    grdRescanFillData.DataBind();                    
                    trRescanEntryHdr.Visible = true;
                    trRescanEntry.Visible = true;                  

                    for (int i = 0; i < grdRescanFillData.Rows.Count; i++)
                    {
                        TextBox txtDate = (TextBox)grdRescanFillData.Rows[i].FindControl("txtDate");
                        txtDate.Text = System.DateTime.Now.ToString("dd MMM yy (ddd)");

                        if (dsGetRescan.Tables.Count > 3)
                        {
                            DataTable dtRescnaFaults = dsGetRescan.Tables[3];
                            DataList dlstFaults = (DataList)grdRescanFillData.Rows[i].FindControl("dlstFaults");
                            dlstFaults.DataSource = dtRescnaFaults;
                            dlstFaults.DataBind();
                        }
                    }
                }
                else
                {
                    grdRescanFillData.DataSource = null;
                    grdRescanFillData.DataBind();
                    trRescanEntryHdr.Visible = false;
                    trRescanEntry.Visible = false;
                }

                int checkShiped = Convert.ToInt32(dsGetRescan.Tables[1].Rows[0]["IsShiped"].ToString());
                if (checkShiped == 1)
                {
                    btnRescanCheckSubmit.Visible = false;
                    btnAddCycle.Visible = false;
                }
                else
                {
                    int desgId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
                    if(desgId == 54 || desgId == 19 || desgId == 13)
                    {
                        btnRescanCheckSubmit.Visible = true;
                    }
                    else
                    {
                        btnRescanCheckSubmit.Visible = false;
                        //tableRescandetails.Visible = false;
                        btnAddCycle.Visible = false;
                    }
                    if(desgId == 44 || desgId == 45 || desgId == 13 || desgId==98)
                    {
                        btnRescanSubmit.Visible = true;
                        //if (dsGetRescan.Tables[0].Rows.Count > 0)
                        //{
                        //    tableRescandetails.Visible = true;
                        //}
                    }
                    else
                    {
                        btnRescanSubmit.Visible = false;
                        //tableRescandetails.Visible = false;
                    }
                }

                grdRescanDetails.DataSource = dtRescanDetail;
                grdRescanDetails.DataBind();

            }
        }
        
        public bool ValidationRescan(GridView grdRescan)
        {
            double value = 0;
            double pendingrescanqty = 0;
            int TotalRescannedqty = 0;
            string val = "";
            int uncheckFinishValue = 0;
            if (UncheckValue.Value != "" && UncheckValue.Value != "NaN")
                uncheckFinishValue = Convert.ToInt32(UncheckValue.Value);
            int checkFinishValue = 0;
            if (CheckValue.Value != "" && CheckValue.Value != "NaN")
                checkFinishValue = Convert.ToInt32(CheckValue.Value);
            if (ViewState["TotalRescanned"].ToString() != "")
                TotalRescannedqty = Convert.ToInt32(ViewState["TotalRescanned"].ToString());

            bool Validate = true;

            for (int i = 0; i < grdRescanFillData.Rows.Count; i++)
            {
                Label lblPendingRescannedQty = (Label)grdRescanFillData.Rows[i].FindControl("lblPendingRescannedQty");

                if (lblPendingRescannedQty != null)
                    pendingrescanqty = pendingrescanqty + Convert.ToDouble(lblPendingRescannedQty.Text.Trim() == "" ? "0" : lblPendingRescannedQty.Text.Trim());
            }

            for (int j = 0; j < grdRescan.Rows.Count; j++)
            {
                CheckBox chkRescan = (CheckBox)grdRescan.Rows[j].FindControl("chkRescan");
                if (chkRescan.Visible == true)
                {
                    if (chkRescan.Checked == true)
                    {
                        HiddenField hdnFinishqty = (HiddenField)grdRescan.Rows[j].FindControl("hdnFinishqty");
                        TextBox txtExactRescan = (TextBox)grdRescan.Rows[j].FindControl("txtExactRescan");
                        TextBox txtExactRescan1 = (TextBox)grdRescan.Rows[j].FindControl("txtExactRescan1");

                        if (txtExactRescan.Text.Trim() == "")
                            txtExactRescan.Text = "0";
                        if (txtExactRescan1.Text.Trim() == "")
                            txtExactRescan1.Text = "0";

                        value = value + Convert.ToDouble(txtExactRescan.Text.Trim()) + Convert.ToDouble(txtExactRescan1.Text.Trim());
                    }
                }
            }
            if (val != "")
            {
                if (uncheckFinishValue == 0 && checkFinishValue == 0)
                {
                    if (TotalRescannedqty > value)
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Total rescan qty. can not be less then checked finish qty.');", true);
                        Validate = false;
                    }
                }
                else
                {
                    if (uncheckFinishValue != 0)
                    {
                        if (pendingrescanqty == 0)
                        {
                            if (TotalRescannedqty != value)
                            {
                                Page page = HttpContext.Current.Handler as Page;
                                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Total rescan qty. can not be less then unchecked finish qty.');", true);
                                Validate = false;
                                UncheckValue.Value = "";
                            }
                        }
                        else
                        {
                            if (TotalRescannedqty > value)
                            {
                                Page page = HttpContext.Current.Handler as Page;
                                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Total rescan qty. can not be less then unchecked finish qty.');", true);
                                Validate = false;
                                UncheckValue.Value = "";
                            }
                            else
                            {
                                if (pendingrescanqty < uncheckFinishValue && pendingrescanqty > value)
                                {
                                    Page page = HttpContext.Current.Handler as Page;
                                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Pending rescan qty. can not be less then unchecked finish qty.');", true);
                                    Validate = false;
                                    UncheckValue.Value = "";
                                }
                            }
                        }
                    }
                    if (checkFinishValue != 0)
                    {
                        if (TotalRescannedqty > value)
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Total rescanned qty. can not be less then checked finish qty.');", true);
                            Validate = false;
                            CheckValue.Value = "";
                        }
                    }
                }
            }

            return Validate;
        }

        public bool ValidationRescanSubmit(GridView grdRescanFillData)
        {
            bool Validate = true;
            for (int j = 0; j < grdRescanFillData.Rows.Count; j++)
            {
                TextBox txtDate = (TextBox)grdRescanFillData.Rows[j].FindControl("txtDate");
                TextBox txtRescannedQty = (TextBox)grdRescanFillData.Rows[j].FindControl("txtRescannedQty");
                TextBox txtFailQty = (TextBox)grdRescanFillData.Rows[j].FindControl("txtFailQty");
                TextBox txtManPower = (TextBox)grdRescanFillData.Rows[j].FindControl("txtManPower");
                TextBox txtWorkingHrs = (TextBox)grdRescanFillData.Rows[j].FindControl("txtWorkingHrs");
                TextBox txtBreakDown = (TextBox)grdRescanFillData.Rows[j].FindControl("txtBreakDown");
                CheckBox chkIncludedRescan = (CheckBox)grdRescanFillData.Rows[j].FindControl("chkIncludedRescan");
                Label lblPendingRescannedQty = (Label)grdRescanFillData.Rows[j].FindControl("lblPendingRescannedQty");

                if (lblPendingRescannedQty.Text.Trim() != "")
                {
                    if (txtRescannedQty.Text.Trim() != "")
                    {
                        if (txtDate.Text.Trim() == "" || txtDate.Text.Trim() == "0")
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Please select date.');", true);
                            Validate = false;
                        }
                        else if (txtManPower.Text.Trim() == "" || txtManPower.Text.Trim() == "0")
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Please enter man power.');", true);
                            Validate = false;
                        }
                        else if (txtWorkingHrs.Text.Trim() == "" || txtWorkingHrs.Text.Trim() == "0")
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Please enter working hrs.');", true);
                            Validate = false;
                        }
                        else if (txtBreakDown.Text.Trim() == "" || txtBreakDown.Text.Trim() == "0")
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Please enter break down remarks.');", true);
                            Validate = false;
                        }
                        else if (chkIncludedRescan.Checked == false)
                        {
                            int totalqty = Convert.ToInt32(txtFailQty.Text.Trim()) + Convert.ToInt32(txtRescannedQty.Text.Trim());
                            if (totalqty > Convert.ToInt32(lblPendingRescannedQty.Text.Trim().Replace(",", "")))
                            {
                                Page page = HttpContext.Current.Handler as Page;
                                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Can not exceed fail qty and rescan qty from pending rescan qty.');", true);
                                Validate = false;
                            }
                        }
                    }
                    else
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "jQuery.facebox('Please enter Pass Qty.');", true);
                        Validate = false;
                    }
                }

            }

            return Validate;
        }

        protected void grdRescan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ColCount = grdRescan.Columns.Count;
            int irowidenx = e.Row.RowIndex;

            int CycleCount = lblCycleNo.Text == "" ? 0 : Convert.ToInt16(lblCycleNo.Text);
            if (CycleCount == 0)
                CycleCount = 1;
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {  
                int C45_FinishQty = DataBinder.Eval(e.Row.DataItem, "C45_FinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "C45_FinishQty"));
                int C47_FinishQty = DataBinder.Eval(e.Row.DataItem, "C47_FinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "C47_FinishQty"));
                int D169_FinishQty = DataBinder.Eval(e.Row.DataItem, "D169_FinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "D169_FinishQty"));
               // int C52_FinishQty = DataBinder.Eval(e.Row.DataItem, "C52_FinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "C52_FinishQty"));

                for (int iCol = 1; iCol <= CycleCount; iCol++)
                {
                    grdRescan.Columns[iCol - 1].Visible = true;

                    TextBox txtC45Cycle = (TextBox)e.Row.FindControl("txtC45Cycle" + iCol);
                    TextBox txtC47Cycle = (TextBox)e.Row.FindControl("txtC47Cycle" + iCol);
                    TextBox txtD169Cycle = (TextBox)e.Row.FindControl("txtD169Cycle" + iCol);
                    //TextBox txtC52Cycle = (TextBox)e.Row.FindControl("txtC52Cycle" + iCol);

                    txtC45Cycle.Visible = C45_FinishQty > 0 ? true : false;
                    txtC47Cycle.Visible = C47_FinishQty > 0 ? true : false;
                    txtD169Cycle.Visible = D169_FinishQty > 0 ? true : false;
                    //txtC52Cycle.Visible = C52_FinishQty > 0 ? true : false; 

                    CheckBox chkCycleHeader = (CheckBox)grdRescan.HeaderRow.FindControl("chkCycleHeader" + iCol);

                    if (iCol == CycleCount)
                    {
                        chkCycleHeader.Enabled = true;
                        txtC45Cycle.Enabled = C45_FinishQty > 0 ? true : false;
                        txtC47Cycle.Enabled = C47_FinishQty > 0 ? true : false;
                        txtD169Cycle.Enabled = D169_FinishQty > 0 ? true : false;
                        //txtC52Cycle.Enabled = C52_FinishQty > 0 ? true : false;
                    }

                    CheckBox chkCycle = (CheckBox)e.Row.FindControl("chkCycle" + iCol);
                    int IsCycle = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsCycl" + iCol));

                    chkCycle.Checked = IsCycle == 0 ? false : true;

                    if ((C45_FinishQty > 0) || (C47_FinishQty > 0) || (D169_FinishQty > 0))
                        chkCycle.Visible = true;

                    if ((iCol == CycleCount) && (!chkCycle.Checked))
                        chkCycle.Enabled = true;

                    int C45_Cycl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "C45_Cycl" + iCol));
                    int C47_Cycl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "C47_Cycl" + iCol));
                    int D169_Cycl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "D169_Cycl" + iCol));
                    //int C52_Cycl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "C52_Cycl" + iCol));


                    txtC45Cycle.Text = C45_Cycl > 0 ? C45_Cycl.ToString() : "";
                    txtC47Cycle.Text = C47_Cycl > 0 ? C47_Cycl.ToString() : "";
                    txtD169Cycle.Text = D169_Cycl > 0 ? D169_Cycl.ToString() : "";
                    //txtC52Cycle.Text = C52_Cycl > 0 ? C52_Cycl.ToString() : "";

                    txtC45Cycle.ForeColor = System.Drawing.Color.Black;
                    txtC47Cycle.ForeColor = System.Drawing.Color.Black;
                    txtD169Cycle.ForeColor = System.Drawing.Color.Black;
                    //txtC52Cycle.ForeColor = System.Drawing.Color.Black;

                    if (irowidenx == TableRowCount - 1)
                    {
                        chkCycle.Visible = false;

                        txtC45Cycle.BorderColor = System.Drawing.Color.White;
                        txtC47Cycle.BorderColor = System.Drawing.Color.White;
                        txtD169Cycle.BorderColor = System.Drawing.Color.White;
                        //txtC52Cycle.BorderColor = System.Drawing.Color.White;

                        txtC45Cycle.Attributes.Remove("placeholder");
                        txtC47Cycle.Attributes.Remove("placeholder");
                        txtD169Cycle.Attributes.Remove("placeholder");
                        //txtC52Cycle.Attributes.Remove("placeholder");

                        txtC45Cycle.Text = C45_Cycl == 0 ? "" : C45_Cycl.ToString("#,##0");
                        txtC47Cycle.Text = C47_Cycl == 0 ? "" : C47_Cycl.ToString("#,##0");
                        txtD169Cycle.Text = D169_Cycl == 0 ? "" : D169_Cycl.ToString("#,##0");
                        //txtC52Cycle.Text = C52_Cycl == 0 ? "" : C52_Cycl.ToString("#,##0");
                        
                        txtC45Cycle.ReadOnly = true;
                        txtC47Cycle.ReadOnly = true;
                        txtD169Cycle.ReadOnly = true;
                        //txtC52Cycle.ReadOnly = true;

                        txtC45Cycle.MaxLength = 7;
                        txtC47Cycle.MaxLength = 7;
                        txtD169Cycle.MaxLength = 7;
                        //txtC52Cycle.MaxLength = 7;

                        txtC45Cycle.Width = 35;
                        txtC47Cycle.Width = 35;
                        txtD169Cycle.Width = 35;
                        //txtC52Cycle.Width = 35;

                        HtmlGenericControl dvC45 = (HtmlGenericControl)e.Row.FindControl("dvC45_" + iCol);
                       
                        if(txtC45Cycle.Text != "")
                        {
                            dvC45.Attributes.Add("style", "float:left; padding-left:4px;");
                        }
                        if (txtC47Cycle.Text != "")
                        {                          
                            txtC47Cycle.Attributes.Add("style", "text-align:right;");
                        }
                        if (txtD169Cycle.Text != "")
                        {
                            txtD169Cycle.Attributes.Add("style", "text-align:right;");
                        }
                        //if (txtC52Cycle.Text != "")
                        //{
                        //    txtC52Cycle.Attributes.Add("style", "text-align:right;");
                        //} 
                        
                    }                    

                }

            }
        }

        protected void btnRescanCheckSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int UserID = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
                int Save = 0;
               
                    ProductionDetail objProduction = new ProductionDetail();
                    objProduction.OrderDetailId = Convert.ToInt32(hdnOrderdetsilid.Value);
                    int CycleCount = lblCycleNo.Text == "" ? 0 : Convert.ToInt16(lblCycleNo.Text);
                    if (CycleCount == 0)
                        CycleCount = 1;

                    for (int i = 0; i < grdRescan.Rows.Count; i++)
                    {                        
                        HiddenField hdnRescanDate = (HiddenField)grdRescan.Rows[i].FindControl("hdnRescanDate");
                        HiddenField hdnC45_FinishQty = (HiddenField)grdRescan.Rows[i].FindControl("hdnC45_FinishQty");
                        HiddenField hdnC47_FinishQty = (HiddenField)grdRescan.Rows[i].FindControl("hdnC47_FinishQty");
                        HiddenField hdnD169_FinishQty = (HiddenField)grdRescan.Rows[i].FindControl("hdnD169_FinishQty");
                        //HiddenField hdnC52_FinishQty = (HiddenField)grdRescan.Rows[i].FindControl("hdnC52_FinishQty");

                        CheckBox chkCycle = (CheckBox)grdRescan.Rows[i].FindControl("chkCycle" + CycleCount);
                        TextBox txtC45Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtC45Cycle" + CycleCount);
                        TextBox txtC47Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtC47Cycle" + CycleCount);
                        TextBox txtD169Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtD169Cycle" + CycleCount);
                        //TextBox txtC52Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtC52Cycle" + CycleCount);

                        if(chkCycle.Checked)
                        {
                            objProduction.RescanDate = hdnRescanDate.Value == ""? DateTime.MinValue : Convert.ToDateTime(hdnRescanDate.Value);

                            if(hdnC45_FinishQty != null)
                                if(Convert.ToInt32(hdnC45_FinishQty.Value) > 0)
                                    objProduction.C4546_ScanValue = txtC45Cycle.Text == "" ? 0 : Convert.ToInt32(txtC45Cycle.Text);

                            if (hdnC47_FinishQty != null)
                                if (Convert.ToInt32(hdnC47_FinishQty.Value) > 0)
                                    objProduction.C47_ScanValue = txtC47Cycle.Text == "" ? 0 : Convert.ToInt32(txtC47Cycle.Text);

                            if (hdnD169_FinishQty != null)
                                if (Convert.ToInt32(hdnD169_FinishQty.Value) > 0)
                                    objProduction.D169_ScanValue = txtD169Cycle.Text == "" ? 0 : Convert.ToInt32(txtD169Cycle.Text);

                            //if (hdnC52_FinishQty != null)
                            //    if (Convert.ToInt32(hdnC52_FinishQty.Value) > 0)
                            //        objProduction.C52_ScanValue = txtC52Cycle.Text == "" ? 0 : Convert.ToInt32(txtC52Cycle.Text);

                            objProduction.chkIsScan = true;
                            if ((objProduction.C4546_ScanValue > 0) || (objProduction.C47_ScanValue > 0) || (objProduction.D169_ScanValue > 0))
                            {
                                OrderControllerInstance.updateRescan(objProduction, CycleCount, UserID);
                                Save = 1;
                            }

                            objProduction.C4546_ScanValue = 0;
                            objProduction.C47_ScanValue = 0;
                            objProduction.D169_ScanValue = 0;
                            //objProduction.C52_ScanValue = 0;
                        }                        
                    }
                    if (Save == 1)
                    {
                        Page page2 = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page2, page2.GetType(), "err_msg", "jQuery.facebox('Data saved successfully.');", true);
                        BindProductionDetails_History();
                    }                    
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void grdProductionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //HiddenField hdnIsRescan = (HiddenField)e.Row.FindControl("hdnIsRescan");
                HiddenField hdndate = (HiddenField)e.Row.FindControl("hdndate");
                var res = from row in DTDonline.AsEnumerable()
                          where row.Field<string>("Date") == hdndate.Value
                          select row;
                DataTable dtcheck = res.CopyToDataTable();

                if (dtcheck.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtcheck.Rows[0]["IsDoOnlie_Rescan"]) >= 1)
                    {
                        e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F8E5A0");
                    }
                }
            }
        }

        protected void grddoonline_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnfsilcounts = (HiddenField)e.Row.FindControl("hdnfsilcounts");
                HiddenField hdndate = (HiddenField)e.Row.FindControl("hdndate");
                Label lbldoonlinefail = (Label)e.Row.FindControl("lbldoonlinefail");
                Label lbldoonlinefailss = (Label)e.Row.FindControl("lbldoonlinefailss");

                if (hdndate.Value == "Grand Total")
                    hdndate.Value = "2010-01-01";
                DataTable dt = objProductionController.GetTopFualtDetails(Convert.ToInt32(OrderDetailId), Convert.ToDateTime(hdndate.Value));
                if (dt.Rows.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        string FualtName = dtRow["FaultName"].ToString();
                        string FualtCount = dtRow["Faulttop3Count"].ToString();
                        string FualtPerCen = dtRow["FaultPerCentage"].ToString();
                        builder.Append(FualtName + " " + "(" + FualtCount + ") <span style='float:right;color:red'>" + FualtPerCen + "%</span>").Append("\n").Append("<br/>");
                    }

                    lbldoonlinefailss.Text = lbldoonlinefailss.Text + "<span class='tooltiptext'>" + builder.ToString() + "</span>";
                }
                if (lbldoonlinefail.Text != "")
                {
                    string sOnlineFail = lbldoonlinefail.Text;
                    string[] sOnlineArr = sOnlineFail.Split(',');

                    StringBuilder sOnlineReverse = new StringBuilder();
                    string[] sOnlineReverseArr = new string[sOnlineArr.Length];

                    int inext = 0;

                    for (int ival = sOnlineArr.Length - 1; ival >= 0; ival--)
                    {
                        sOnlineReverseArr[inext] = sOnlineArr[ival].ToString();

                        sOnlineReverse.Append("<div>" + sOnlineReverseArr[inext].ToString() + "</div>");

                        inext = inext + 1;
                    }

                    if (sOnlineReverseArr.Length == 1)
                    {
                        lbldoonlinefail.Text = sOnlineReverseArr[0].ToString();
                    }
                    else if (sOnlineReverseArr.Length == 2)
                    {
                        lbldoonlinefail.Text = "<span class='disp-block'>" + sOnlineReverseArr[0].ToString() + "</span><span class='disp-block'>" + sOnlineReverseArr[1].ToString() + "</span>";
                    }
                    else if (sOnlineArr.Length > 2)
                    {
                        lbldoonlinefail.Text = "<span class='disp-block'>" + sOnlineReverseArr[0].ToString() + "</span><span class='disp-block'>" + sOnlineReverseArr[1].ToString() + "..</span>";
                    }

                    lbldoonlinefail.Text = lbldoonlinefail.Text + "<span class='tooltiptext'>" + sOnlineReverse + "</span>";
                }
            }
        }
        protected void grddoonline_DataBound(object sender, EventArgs e)
        {
            for (int i = grddoonline.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grddoonline.Rows[i];
                GridViewRow previousRow = grddoonline.Rows[i - 1];

                //for (int j = 0; j < row.Cells.Count - 1; j++)
                // {
                HiddenField hdnfsilcounts = (HiddenField)row.Cells[0].FindControl("hdnfsilcounts");
                HiddenField hdnfsilcountsPrevious = (HiddenField)previousRow.Cells[0].FindControl("hdnfsilcounts");

                HiddenField lblStaffDept = (HiddenField)row.Cells[0].FindControl("hdnQualityID");
                HiddenField lblPreviousStaffDept = (HiddenField)previousRow.Cells[0].FindControl("hdnQualityID");
                Label lbldoonlinefail = (Label)previousRow.Cells[0].FindControl("lbldoonlinefail");

                //lbldoonlinefail.Text = "Online Failed on " + lbldoonlinefail.Text;
                if (Convert.ToInt32(hdnfsilcountsPrevious.Value) >= 1)
                {
                    lbldoonlinefail.Visible = true;
                }

                if (Convert.ToInt32(hdnfsilcounts.Value) >= 1 && Convert.ToInt32(hdnfsilcountsPrevious.Value) >= 1)
                {
                    if (lblStaffDept.Value == lblPreviousStaffDept.Value)
                    {
                        if (previousRow.Cells[0].RowSpan == 0)
                        {
                            if (row.Cells[0].RowSpan == 0)
                            {
                                previousRow.Cells[0].RowSpan += 2;
                                lbldoonlinefail.Visible = true;
                            }
                            else
                            {
                                previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                                lbldoonlinefail.Visible = true;
                            }
                            row.Cells[0].Visible = false;
                        }
                    }

                }
                else
                {

                }
            }

        }
      
        protected void grdFaultTypeRescan_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            int CycleCount = lblCycleNo.Text == "" ? 0 : Convert.ToInt16(lblCycleNo.Text);
            DataTable DTRescan = (DataTable)ViewState["DTRescan"];
            DataTable dtFaultTypeRescan = (DataTable)ViewState["dtFaultTypeRescan"];

            DataTable dtFaultInPercent = (DataTable)ViewState["dtFaultInPercent"];

            if(e.Row.RowType == DataControlRowType.Header) // If header created
            {
                Label lblCQDPercent = (Label)e.Row.FindControl("lblCQDPercent");
                lblCQDPercent.Text = dtFaultInPercent.Rows[0]["Total_CQD_Percent"].ToString();

                Label lblQCPercent = (Label)e.Row.FindControl("lblQCPercent");
                lblQCPercent.Text = dtFaultInPercent.Rows[0]["Total_QC_Percent"].ToString();

                Label lblTotalPercent = (Label)e.Row.FindControl("lblTotalPercent");
                lblTotalPercent.Text = dtFaultInPercent.Rows[0]["Total_Final_Percent"].ToString();

                for (int icell = 1; icell <= CycleCount; icell++)
                {                   
                    grdFaultTypeRescan.Columns[3 + icell].Visible = true;
                    Label lblHdr = (Label)e.Row.FindControl("lblHdr" + icell);
                    lblHdr.Text = "Cl " + icell.ToString();
                }      
     
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnFlag = (HiddenField)e.Row.FindControl("hdnFlag");
                HiddenField hdnFaultDone = (HiddenField)e.Row.FindControl("hdnFaultDone");
                if (hdnFlag.Value.ToString() == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#BDB76B");
                }

                int FaultDone = hdnFaultDone != null ? Convert.ToInt16(hdnFaultDone.Value) : 0;

                
                for (int icell = CycleCount; icell >= 1; icell--)
                {
                    CheckBox chkboxSelectAll = (CheckBox)grdFaultTypeRescan.HeaderRow.FindControl("chkboxSelectAll"+ icell);
                    CheckBox chkAction = (CheckBox)e.Row.FindControl("chkAction" + icell);

                    if (icell == CycleCount)
                    {
                        DataRow[] foundIsCycl = DTRescan.Select("IsCycl" + icell + " = 1");
                        if (foundIsCycl.Length > 0)
                        {
                            chkboxSelectAll.Enabled = true;
                            chkAction.Enabled = true;
                            if ((FaultDone > 0) &&(chkAction.Checked))
                                chkAction.Enabled = false;
                            break;
                        }
                    }
                    else
                    {
                        int iCellNew = icell + 1;
                        DataRow[] foundIsCycl = DTRescan.Select("IsCycl" + icell + " = 1");
                        DataRow[] foundFaultIsCycl = dtFaultTypeRescan.Select("RescanCycle" + iCellNew + " = 'True'");

                        if ((foundIsCycl.Length > 0)&& (foundFaultIsCycl.Length <= 0))
                        {
                            chkboxSelectAll.Enabled = true;
                            chkAction.Enabled = true;
                            if ((FaultDone > 0) && (chkAction.Checked))
                                chkAction.Enabled = false;
                        }
                    }                   
                }
            }
        }

        // Fixed the code here by RSB on dated 21 nov 2020
        protected void btnAddCycle_Click(object sender, EventArgs e)
        {
            btnAddCycle.Visible = false;

            ProductionDetail objProduction = new ProductionDetail();
            int Save = 0;
            int iOrderDetailId = Convert.ToInt32(hdnOrderdetsilid.Value);

            int CycleCount = lblCycleNo.Text == "" ? 0 : Convert.ToInt16(lblCycleNo.Text);
            if (CycleCount == 0)
                CycleCount = 1;

            for (int i = 0; i < grdRescan.Rows.Count; i++)
            {
                CheckBox chkCycle = (CheckBox)grdRescan.Rows[i].FindControl("chkCycle" + CycleCount);
                TextBox txtC45Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtC45Cycle" + CycleCount);
                TextBox txtC47Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtC47Cycle" + CycleCount);
                TextBox txtD169Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtD169Cycle" + CycleCount);
                //TextBox txtC52Cycle = (TextBox)grdRescan.Rows[i].FindControl("txtC52Cycle" + CycleCount);

                if (chkCycle.Checked)
                {

                    objProduction.C4546_ScanValue = txtC45Cycle.Text == "" ? 0 : Convert.ToInt32(txtC45Cycle.Text);
                    objProduction.C47_ScanValue = txtC47Cycle.Text == "" ? 0 : Convert.ToInt32(txtC47Cycle.Text);
                    objProduction.D169_ScanValue = txtD169Cycle.Text == "" ? 0 : Convert.ToInt32(txtD169Cycle.Text);
                    //objProduction.C52_ScanValue = txtC52Cycle.Text == "" ? 0 : Convert.ToInt32(txtC52Cycle.Text);

                    if ((objProduction.C4546_ScanValue > 0) || (objProduction.C47_ScanValue > 0) || (objProduction.D169_ScanValue > 0))
                    {
                        Save = 1;
                    }
                }
            }
            if (Save == 1)
            {
                int iAdd = objProductionController.AddRescanCycle(iOrderDetailId);
                BindProductionDetails_History();
            }

        }
        // End of fixing

        protected void btnFaultInsert_Click(object sender, ImageClickEventArgs e)
        {
            int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
            Page page2 = HttpContext.Current.Handler as Page;

            if (txtFaultDescription.Text != "")
            {
                try
                {
                    string sReturn = this.OrderControllerInstance.SubFaultType_Rescan_InstUpdt(Convert.ToInt32(hdnOrderdetsilid.Value.ToString()), txtFaultDescription.Text.Trim(), CreatedBy);
                    if (sReturn != "")
                    {
                        ScriptManager.RegisterStartupScript(page2, page2.GetType(), "err_msg", "jQuery.facebox('Record already exist.');", true);
                        txtFaultDescription.Text = "";
                        return;
                    }
                    else
                    {
                        txtFaultDescription.Text = "";
                        BindProductionDetails_History();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    ScriptManager.RegisterStartupScript(page2, page2.GetType(), "err_msg", "jQuery.facebox('Some error occured.');", true);
                    return;
                }
            }
        }

        protected void btnRescanSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int OrderDetailId = Convert.ToInt32(hdnOrderdetsilid.Value.ToString());                
                int iSave = 0;
                int CycleNo = ddlRescanCycle.Items.Count > 0 ? Convert.ToInt32(ddlRescanCycle.SelectedValue) : 0;

                for (int i = 0; i < grdRescanFillData.Rows.Count; i++)
                {
                    TextBox txtDate = (TextBox)grdRescanFillData.Rows[i].FindControl("txtDate");
                    TextBox txtRescannedQty = (TextBox)grdRescanFillData.Rows[i].FindControl("txtRescannedQty");
                    TextBox txtFailQty = (TextBox)grdRescanFillData.Rows[i].FindControl("txtFailQty");
                    TextBox txtManPower = (TextBox)grdRescanFillData.Rows[i].FindControl("txtManPower");
                    TextBox txtWorkingHrs = (TextBox)grdRescanFillData.Rows[i].FindControl("txtWorkingHrs");
                    TextBox txtBreakDown = (TextBox)grdRescanFillData.Rows[i].FindControl("txtBreakDown");
                    CheckBox chkIncludedRescan = (CheckBox)grdRescanFillData.Rows[i].FindControl("chkIncludedRescan");
                    HiddenField hdnUnitId = (HiddenField)grdRescanFillData.Rows[i].FindControl("hdnUnitId");
                    Label lblPendingRescannedQty = (Label)grdRescanFillData.Rows[i].FindControl("lblPendingRescannedQty");

                    int UnitId = Convert.ToInt32(hdnUnitId.Value.ToString());

                    if (lblPendingRescannedQty.Text.Trim() != "")
                    {
                        if (txtRescannedQty.Text.Trim() != "")
                        {
                            string Date = txtDate.Text.Trim();
                            if (Date != "")
                                Date = Date.Substring(0, Date.Length - 6);

                            if (txtFailQty.Text.Trim() == "")
                                txtFailQty.Text = "0";

                            OrderControllerInstance.SubmitRescan(OrderDetailId, Date, Convert.ToInt32(txtRescannedQty.Text.Trim()), Convert.ToInt32(txtFailQty.Text.Trim()), Convert.ToInt32(txtManPower.Text.Trim()), Convert.ToDouble(txtWorkingHrs.Text.Trim()), txtBreakDown.Text.Trim(), Convert.ToBoolean(chkIncludedRescan.Checked.ToString()), UnitId, CycleNo);
                            iSave = 1;

                            DataList dlstFaults = (DataList)grdRescanFillData.Rows[i].FindControl("dlstFaults");
                            int FaultId = 0;
                            int FaultFail = 0;

                            for (int iItem = 0; iItem < dlstFaults.Items.Count; iItem++)
                            {
                                HiddenField hdnFaultsId = (HiddenField)dlstFaults.Items[iItem].FindControl("hdnFaultsId");
                                FaultId = Convert.ToInt32(hdnFaultsId.Value);

                                HtmlInputText txtFaultsQty = (HtmlInputText)dlstFaults.Items[iItem].FindControl("txtFaultsQty");

                                FaultFail = txtFaultsQty.Value == "" ? 0 : Convert.ToInt32(txtFaultsQty.Value);

                                if (FaultFail > 0)
                                {
                                    iSave = OrderControllerInstance.SubmitRescan_FaultDetails(OrderDetailId, Date, UnitId, CycleNo, FaultId, FaultFail);
                                }
                            }
                        }
                    }                   
                }
                if (iSave == 1)             
                    getRescanDetails();            
                else
                    return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

            }
        }      
            
        protected void btnddlRescan_Click(object sender, EventArgs e)
        {            
            getRescanDetails();             
        }

        protected void grdRescanDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblFail = (Label)e.Row.FindControl("lblFail");

                int PassQty = DataBinder.Eval(e.Row.DataItem, "ReScanQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ReScanQty"));

                int FailQty = DataBinder.Eval(e.Row.DataItem, "FailQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FailQty"));

                if (FailQty > 0)
                    lblFail.Text = "<span style='color:Red;'>(" + FailQty.ToString("#,##0") + ")</span>";

                string sBreakDownRemarks = DataBinder.Eval(e.Row.DataItem, "BreakDownRemarks").ToString();

                sBreakDownRemarks = sBreakDownRemarks.Replace(",", "<br />");

                Label lblBreakdown = (Label)e.Row.FindControl("lblBreakdown");
                lblBreakdown.Text = sBreakDownRemarks;

                string sFaultDescription = DataBinder.Eval(e.Row.DataItem, "FaultDescription").ToString();               

                string sFaults = "";
                if (sFaultDescription != "")
                {
                    string[] sFaultsArr = sFaultDescription.Split(',');
                    for (int iItem = 0; iItem < sFaultsArr.Length; iItem++)
                    {
                        string FaultLine = sFaultsArr[iItem].Replace("(", "<span style='color:Red;'> (");
                        FaultLine = FaultLine.Replace(")", ")</span>");
                        sFaults = sFaults + FaultLine + "<br/>";
                    }
                }

                Label lblFaults = (Label)e.Row.FindControl("lblFaults");
                lblFaults.Text = sFaults;

                TotalPass = TotalPass + PassQty;
                TotalFail = TotalFail + FailQty;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblPassFooter = (Label)e.Row.FindControl("lblPassFooter");
                Label lblFailFooter = (Label)e.Row.FindControl("lblFailFooter");
                lblPassFooter.Text = TotalPass > 0 ? TotalPass.ToString() : "";

                if (TotalFail > 0)
                    lblFailFooter.Text = "<span style='color:Red;'>(" + TotalFail.ToString("#,##0") + ")</span>";

                TotalPass = 0;
                TotalFail = 0;
                
            }
        }

        protected void grdRescanDetails_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < grdRescanDetails.Rows.Count; i++)
            {
                GridViewRow row = grdRescanDetails.Rows[i];
                if (i > 0)
                {
                    GridViewRow previousRow = grdRescanDetails.Rows[i - 1];

                    Label lblUnit = (Label)row.Cells[0].FindControl("lblUnit");
                    Label lblUnitPrev = (Label)previousRow.Cells[0].FindControl("lblUnit");

                    if (lblUnit.Text == lblUnitPrev.Text)
                    {
                        RowSpan = RowSpan + 1;

                        if (RowSpan > 2)
                        {
                            GridViewRow firstRow = grdRescanDetails.Rows[i - (RowSpan - 1)];
                            firstRow.Cells[0].RowSpan = RowSpan;
                        }
                        else
                            previousRow.Cells[0].RowSpan = RowSpan;

                        row.Cells[0].Visible = false;

                    }
                    else
                    {
                        RowSpan = 1;
                    }

                }
            }
        }
        
    }
}

