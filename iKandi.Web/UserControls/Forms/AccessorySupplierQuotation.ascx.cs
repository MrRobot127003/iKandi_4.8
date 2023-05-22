using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.IO;
using System.Data;

namespace iKandi.Web.UserControls.Forms
{
    public partial class AccessorySupplierQuotation : BaseUserControl
    {
        public static DataTable PopupDatadt = new DataTable();
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();
        private int UserId;
        AdminController onjadminCon = new AdminController();
        string host = "";
        public string Accessorytype { get; set; }
        public void getquerystring()
        {
            if (Request.QueryString["Accessorytype"] != null)
            {
                Accessorytype = Request.QueryString["Accessorytype"].ToString();
            }
            else
            {
                Accessorytype = "";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Supplier)
                UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            else
                UserId = -1;

            getquerystring();
            if (!Page.IsPostBack)
            {
                BindAccessoryTabs();
                SetTab();
            }
        }

        protected void LinkSupplyTab_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Accessorytype = btn.CommandArgument;
            hdnTabAccessory.Value = btn.CommandArgument;
            BindAccessoryTabs();
            SetTab();
        }

        public void SetTab()
        {
            if (hdnTabAccessory.Value != null)
            {
                string SupplyTypeTab = hdnTabAccessory.Value;
                dvMypopupdata.Attributes["class"] = dvMypopupdata.Attributes["class"].Replace("Popupshow", "Popuphide");
                LnkGRIEGE.CssClass = "AccessoryGreigeTab";
                LnkPROCESS.CssClass = "AccessoryProcessTab";
                LnkFINISHING.CssClass = "AccessoryFinishTab";

                grdGriege.Visible = false;
                grdProcess.Visible = false;
                grdFinish.Visible = false;

                switch (SupplyTypeTab)
                {
                    case "GRIEGE":
                        grdGriege.Visible = true;
                        LnkGRIEGE.CssClass = "ActiveAccessory AccessoryGreigeTab";
                        break;
                    case "PROCESS":
                        grdProcess.Visible = true;
                        LnkPROCESS.CssClass = "ActiveAccessory AccessoryProcessTab";
                        break;
                    case "FINISHING":
                        grdFinish.Visible = true;
                        LnkFINISHING.CssClass = "ActiveAccessory AccessoryFinishTab";
                        break;
                    default:
                        goto case "GRIEGE";
                }
            }
        }

        private static void BindSerialAndStyle(GridView gridView, DataTable dtserialStyle, string Type)
        {
            foreach (GridViewRow row in gridView.Rows)
            {
                HiddenField hdAccessoryMasterId = (HiddenField)row.FindControl("hdAccessoryMasterId");
                HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
                HiddenField hdnColorprint = (HiddenField)row.FindControl("hdnColorprint");
                Repeater RptStyle = (Repeater)row.FindControl("RptStyle");
                Repeater RptStyle1 = (Repeater)row.FindControl("RptStyle1");
                string filter = "";
                filter = " AccessoryMaster_Id='" + hdAccessoryMasterId.Value + "' and Size='" + hdnAccessoryQualitySize.Value + "' ";
                if (Type == "F" || Type == "P")
                    filter = filter + " and Color_Print='" + hdnColorprint.Value + "'  ";

                DataRow[] dv = dtserialStyle.Select(filter);
                if (dv.Count() > 0)
                {
                    RptStyle.DataSource = dv.CopyToDataTable();
                    RptStyle.DataBind();
                    RptStyle1.DataSource = dv.CopyToDataTable();
                    RptStyle1.DataBind();
                }
            }


            for (int i = gridView.Rows.Count - 2; i >= 0; i--)
            {
                GridViewRow row = gridView.Rows[i];
                GridViewRow previousRow = gridView.Rows[i + 1];

                Repeater rpt1 = (Repeater)row.FindControl("RptStyle");
                Repeater rpt11 = (Repeater)row.FindControl("RptStyle1");

                Repeater rpt2 = (Repeater)previousRow.FindControl("RptStyle");
                Repeater rpt22 = (Repeater)previousRow.FindControl("RptStyle1");

                string s1 = "";
                string s2 = "";

                s1 = s1 + ((HiddenField)row.FindControl("hdnAccessoryName")).Value;
                s1 = s1 + ((HiddenField)row.FindControl("hdnSize")).Value;
                s1 = s1 + ((HiddenField)row.FindControl("hdnColor_Print")).Value;

                foreach (RepeaterItem rptitem in rpt1.Items)
                {
                    s1 = s1 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                }

                foreach (RepeaterItem rptitem in rpt11.Items)
                {
                    s1 = s1 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                }

                s1 = s1 + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;
                s1 = s1 + ((HiddenField)row.FindControl("hdnUnitName")).Value;
                s1 = s1 + ((HiddenField)row.FindControl("hdnShrinkage")).Value;
                s1 = s1 + ((HiddenField)row.FindControl("hdnWastage")).Value;



                s2 = s2 + ((HiddenField)previousRow.FindControl("hdnAccessoryName")).Value;
                s2 = s2 + ((HiddenField)previousRow.FindControl("hdnSize")).Value;
                s2 = s2 + ((HiddenField)previousRow.FindControl("hdnColor_Print")).Value;


                foreach (RepeaterItem rptitem in rpt2.Items)
                {
                    s2 = s2 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                }
                foreach (RepeaterItem rptitem in rpt22.Items)
                {
                    s2 = s2 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                }

                s2 = s2 + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;
                s2 = s2 + ((HiddenField)previousRow.FindControl("hdnUnitName")).Value;
                s2 = s2 + ((HiddenField)previousRow.FindControl("hdnShrinkage")).Value;
                s2 = s2 + ((HiddenField)previousRow.FindControl("hdnWastage")).Value;




                if (s1.ToLower() == s2.ToLower())
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;

                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;

                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;

                    row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                    previousRow.Cells[3].Visible = false;

                    row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                    previousRow.Cells[4].Visible = false;

                    row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
                    previousRow.Cells[5].Visible = false;

                    row.Cells[6].RowSpan = previousRow.Cells[6].RowSpan < 2 ? 2 : previousRow.Cells[6].RowSpan + 1;
                    previousRow.Cells[6].Visible = false;

                    row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
                    previousRow.Cells[7].Visible = false;


                }

            }
            //else
            //{
            //    for (int i = gridView.Rows.Count - 2; i >= 0; i--)
            //    {
            //        GridViewRow row = gridView.Rows[i];
            //        GridViewRow previousRow = gridView.Rows[i + 1];

            //        Repeater rpt1 = (Repeater)row.FindControl("RptStyle");
            //        Repeater rpt11 = (Repeater)row.FindControl("RptStyle1");

            //        Repeater rpt2 = (Repeater)previousRow.FindControl("RptStyle");
            //        Repeater rpt22 = (Repeater)previousRow.FindControl("RptStyle1");

            //        string s1 = "";
            //        string s2 = "";

            //        s1 = s1 + ((HiddenField)row.FindControl("hdnAccessoryName")).Value;
            //        s1 = s1 + ((HiddenField)row.FindControl("hdnSize")).Value;
            //        s1 = s1 + ((HiddenField)row.FindControl("hdnColor_Print")).Value;

            //        foreach (RepeaterItem rptitem in rpt1.Items)
            //        {
            //            s1 = s1 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
            //        }

            //        foreach (RepeaterItem rptitem in rpt11.Items)
            //        {
            //            s1 = s1 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
            //        }

            //        s1 = s1 + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;
            //        s1 = s1 + ((HiddenField)row.FindControl("hdnUnitName")).Value;
            //        s1 = s1 + ((HiddenField)row.FindControl("hdnShrinkage")).Value;
            //        s1 = s1 + ((HiddenField)row.FindControl("hdnWastage")).Value;



            //        s2 = s2 + ((HiddenField)previousRow.FindControl("hdnAccessoryName")).Value;
            //        s2 = s2 + ((HiddenField)previousRow.FindControl("hdnSize")).Value;
            //        s2 = s2 + ((HiddenField)previousRow.FindControl("hdnColor_Print")).Value;


            //        foreach (RepeaterItem rptitem in rpt2.Items)
            //        {
            //            s2 = s2 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
            //        }
            //        foreach (RepeaterItem rptitem in rpt22.Items)
            //        {
            //            s2 = s2 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
            //        }

            //        s2 = s2 + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;
            //        s2 = s2 + ((HiddenField)previousRow.FindControl("hdnUnitName")).Value;
            //        s2 = s2 + ((HiddenField)previousRow.FindControl("hdnShrinkage")).Value;
            //        s2 = s2 + ((HiddenField)previousRow.FindControl("hdnWastage")).Value;




            //        if (s1.ToLower() == s2.ToLower())
            //        {
            //            row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
            //            previousRow.Cells[0].Visible = false;

            //            row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
            //            previousRow.Cells[1].Visible = false;

            //            row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
            //            previousRow.Cells[2].Visible = false;

            //            row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
            //            previousRow.Cells[3].Visible = false;

            //            row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
            //            previousRow.Cells[4].Visible = false;

            //            row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
            //            previousRow.Cells[5].Visible = false;

            //            row.Cells[6].RowSpan = previousRow.Cells[6].RowSpan < 2 ? 2 : previousRow.Cells[6].RowSpan + 1;
            //            previousRow.Cells[6].Visible = false;

            //            row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
            //            previousRow.Cells[7].Visible = false;

            //            row.Cells[8].RowSpan = previousRow.Cells[8].RowSpan < 2 ? 2 : previousRow.Cells[8].RowSpan + 1;
            //            previousRow.Cells[8].Visible = false;
            //        }
            //    }
            //}



        }

        //private static void BindSupplierPo(GridView gridView, DataTable dtSupplierPo, string Type)
        //{
        //    foreach (GridViewRow row in gridView.Rows)
        //    {
        //        string filter = "";
        //        HiddenField hdAccessoryMasterId = (HiddenField)row.FindControl("hdAccessoryMasterId");
        //        HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
        //        HiddenField hdnColorprint = (HiddenField)row.FindControl("hdnColorprint");
        //        HiddenField hdnSupplierID = (HiddenField)row.FindControl("hdnSupplierID");
        //        Repeater rptPoDetail = (Repeater)row.FindControl("rptPoDetail");

        //        filter = " AccessoryMaster_Id='" + hdAccessoryMasterId.Value + "' and Size='" + hdnAccessoryQualitySize.Value + "' and SupplierID='" + hdnSupplierID.Value + "' ";
        //        if (Type == "F" || Type == "P")
        //            filter = filter + "  and Color_Print= '" + hdnColorprint.Value + "'  ";


        //        DataRow[] dv = dtSupplierPo.Select(filter);
        //        if (dv.Count() > 0)
        //        {
        //            rptPoDetail.DataSource = dv.CopyToDataTable();
        //            rptPoDetail.DataBind();
        //        }
        //    }
        //}


        protected void lnkOpenPopup_Click(object sender, EventArgs e)
        {

            LinkButton linkbutton = sender as LinkButton;
            GridViewRow gvrow = linkbutton.Parent.NamingContainer as GridViewRow;
            GridView gv = linkbutton.Parent.Parent.Parent.Parent as GridView;
            //Repeater  rptPoDetail=  gvrow.FindControl("rptPoDetail") as Repeater;
            HiddenField hdAccessoryMasterId = gvrow.FindControl("hdAccessoryMasterId") as HiddenField;
            HiddenField hdnAccessoryQualitySize = gvrow.FindControl("hdnAccessoryQualitySize") as HiddenField;
            HiddenField hdnColorprint = gvrow.FindControl("hdnColorprint") as HiddenField;
            HiddenField hdnSupplierID = (HiddenField)gvrow.FindControl("hdnSupplierID");

            string filter = "";
            filter = " AccessoryMaster_Id='" + hdAccessoryMasterId.Value + "' and Size='" + hdnAccessoryQualitySize.Value + "'";
            // + "' and SupplierID='" + hdnSupplierID.Value + "' ";
            if (gv.ID == "grdFinish" || gv.ID == "grdProcess")
            {
                filter = filter + "  and Color_Print= '" + hdnColorprint.Value + "'  ";
            }

            DataRow[] dr = PopupDatadt.Select(filter);
            if (dr.Count() > 0)
            {
                dr.CopyToDataTable().DefaultView.Sort = "PODate DESC";
                rptPoDetail.DataSource = dr.CopyToDataTable();
                rptPoDetail.DataBind();
                NoRecordMessage.Attributes["class"] = NoRecordMessage.Attributes["class"].Replace("dblock", "dnone");
            }
            else
            {
                rptPoDetail.DataSource = null;
                rptPoDetail.DataBind();
                NoRecordMessage.Attributes["class"] = NoRecordMessage.Attributes["class"].Replace("dnone", "dblock");

            }
            dvMypopupdata.Attributes["class"] = dvMypopupdata.Attributes["class"].Replace("Popuphide", "Popupshow");

        }
        protected void BindAccessoryTabs()
        {
            if (Accessorytype.ToLower() == "GRIEGE".ToLower() || Accessorytype.ToLower() == "" || Accessorytype == null)
            {
                DataSet DsGriege = objAccessory.GetAccessory_Supplier_QuotationDetails(UserId, txtsearchkeyswords.Text.Trim(), 1, DdlSearchType.SelectedValue);
                if (DsGriege.Tables[0].Rows.Count > 0)
                {
                    grdGriege.DataSource = DsGriege.Tables[0];
                    grdGriege.DataBind();
                    BindSerialAndStyle(grdGriege, DsGriege.Tables[1], "G");
                    //BindSupplierPo(grdGriege, DsGriege.Tables[2], "G");
                    PopupDatadt = DsGriege.Tables[2];
                }
                else
                {
                    grdGriege.DataSource = null;
                    grdGriege.DataBind();
                }
                grdGriege.Visible = true;
            }
            else if (Accessorytype.ToLower() == "PROCESS".ToLower())
            {
                DataSet DsProcess = objAccessory.GetAccessory_Supplier_QuotationDetails(UserId, txtsearchkeyswords.Text.Trim(), 2, DdlSearchType.SelectedValue);
                if (DsProcess.Tables[0].Rows.Count > 0)
                {
                    grdProcess.DataSource = DsProcess.Tables[0];
                    grdProcess.DataBind();
                    BindSerialAndStyle(grdProcess, DsProcess.Tables[1], "P");
                    //  BindSupplierPo(grdProcess, DsProcess.Tables[2], "P");
                    PopupDatadt = DsProcess.Tables[2];
                }
                else
                {
                    grdProcess.DataSource = null;
                    grdProcess.DataBind();
                }
                grdProcess.Visible = true;
            }
            else if (Accessorytype.ToLower() == "FINISHING".ToLower())
            {
                DataSet DsFinish = objAccessory.GetAccessory_Supplier_QuotationDetails(UserId, txtsearchkeyswords.Text.Trim(), 3, DdlSearchType.SelectedValue);
                if (DsFinish.Tables[0].Rows.Count > 0)
                {
                    grdFinish.DataSource = DsFinish.Tables[0];
                    grdFinish.DataBind();
                    BindSerialAndStyle(grdFinish, DsFinish.Tables[1], "F");
                    // BindSupplierPo(grdFinish, DsFinish.Tables[2], "F");
                    PopupDatadt = DsFinish.Tables[2];
                }
                else
                {
                    grdFinish.DataSource = null;
                    grdFinish.DataBind();
                }
                grdFinish.Visible = true;
            }
            if (UserId > 0)
            {
                grdGriege.Columns[3].Visible = false;
                grdProcess.Columns[3].Visible = false;
                grdFinish.Columns[3].Visible = false;
            }
        }

        protected void grdGriege_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //    Label lblBestQuotedRate = (Label)e.Row.FindControl("lblBestQuotedRate");
                //    Label lblBestQuotedLeadTime = (Label)e.Row.FindControl("lblBestQuotedLeadTime");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                //    lblBestQuotedRate.Text = lblBestQuotedRate.Text == "" ? "" : "<span style='color:green; font-size: 11px;'> ₹ </span>" + lblBestQuotedRate.Text;
                //    lblBestQuotedLeadTime.Text = lblBestQuotedLeadTime.Text == "" ? "" : lblBestQuotedLeadTime.Text + "<span style='color:gray'> days</span>";
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text.ToLower() == "Default".ToLower() ? "" : lblSize.Text ;
            }
        }

        protected void grdProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblBestQuotedRate = (Label)e.Row.FindControl("lblBestQuotedRate");
                //Label lblBestQuotedLeadTime = (Label)e.Row.FindControl("lblBestQuotedLeadTime");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                //lblBestQuotedRate.Text = lblBestQuotedRate.Text == "" ? "" : "<span style='color:green; font-size: 11px;'> ₹ </span>" + lblBestQuotedRate.Text;
                //lblBestQuotedLeadTime.Text = lblBestQuotedLeadTime.Text == "" ? "" : lblBestQuotedLeadTime.Text + " <span style='color:gray'> days</span>";
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text.ToLower() == "Default".ToLower() ? "" : lblSize.Text;
            }
        }

        protected void grdFinish_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblBestQuotedRate = (Label)e.Row.FindControl("lblBestQuotedRate");
                //Label lblBestQuotedLeadTime = (Label)e.Row.FindControl("lblBestQuotedLeadTime");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                //lblBestQuotedRate.Text = lblBestQuotedRate.Text == "" ? "" : "<span style='color:green; font-size: 11px;'> ₹ </span>" + lblBestQuotedRate.Text;
                //lblBestQuotedLeadTime.Text = lblBestQuotedLeadTime.Text == "" ? "" : lblBestQuotedLeadTime.Text + " <span style='color:gray'> days</span>";
                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text.ToLower() == "Default".ToLower() ? "" : lblSize.Text;
            }
        }

        protected void grdGriege_DataBound(object sender, EventArgs e)
        {
            //for (int i = grdGriege.Rows.Count - 1; i > 0; i--)
            //{
            //    GridViewRow row = grdGriege.Rows[i];
            //    GridViewRow previousRow = grdGriege.Rows[i - 1];
            //    string CurrentAccessory = "";
            //    string PreviousAccessory = "";





            //    HiddenField hdAccessoryMasterId = (HiddenField)row.FindControl("hdAccessoryMasterId");
            //    HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
            //    CurrentAccessory = hdAccessoryMasterId.Value + hdnAccessoryQualitySize.Value.Trim();

            //    HiddenField hdAccessoryMasterId_Previous = (HiddenField)previousRow.FindControl("hdAccessoryMasterId");
            //    HiddenField hdnAccessoryQualitySize_Previous = (HiddenField)previousRow.FindControl("hdnAccessoryQualitySize");
            //    PreviousAccessory = hdAccessoryMasterId_Previous.Value + hdnAccessoryQualitySize_Previous.Value.Trim();

            //    if (CurrentAccessory.ToLower() == PreviousAccessory.ToLower())
            //    {
            //        if (previousRow.Cells[0].RowSpan == 0)
            //        {
            //            if (row.Cells[0].RowSpan == 0)
            //            {
            //                previousRow.Cells[0].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
            //            }
            //            row.Cells[0].Visible = false;

            //            if (row.Cells[1].RowSpan == 0)
            //            {
            //                previousRow.Cells[1].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
            //            }
            //            row.Cells[1].Visible = false;
            //        }

            //        Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
            //        Label lblQuantityToOrderPrev = (Label)previousRow.FindControl("lblQuantityToOrder");

            //        if (lblQuantityToOrder.Text == lblQuantityToOrderPrev.Text)
            //        {
            //            if (previousRow.Cells[2].RowSpan == 0)
            //            {
            //                if (row.Cells[2].RowSpan == 0)
            //                {
            //                    previousRow.Cells[2].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
            //                }
            //                row.Cells[2].Visible = false;
            //            }

            //        }

            //        Label lblShrinkage = (Label)row.FindControl("lblShrinkage");
            //        Label lblShrinkagePrev = (Label)previousRow.FindControl("lblShrinkage");

            //        if (lblShrinkage.Text == lblShrinkagePrev.Text)
            //        {
            //            if (previousRow.Cells[3].RowSpan == 0)
            //            {
            //                if (row.Cells[3].RowSpan == 0)
            //                {
            //                    previousRow.Cells[3].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
            //                }
            //                row.Cells[3].Visible = false;
            //            }
            //        }
            //        Label lblWastage = (Label)row.FindControl("lblWastage");
            //        Label lblWastagePrev = (Label)previousRow.FindControl("lblWastage");

            //        if (lblWastage.Text == lblWastagePrev.Text)
            //        {
            //            if (previousRow.Cells[4].RowSpan == 0)
            //            {
            //                if (row.Cells[4].RowSpan == 0)
            //                {
            //                    previousRow.Cells[4].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[4].RowSpan = row.Cells[4].RowSpan + 1;
            //                }
            //                row.Cells[4].Visible = false;
            //            }
            //        }

            //        string CurrentRate_LeadTime = "";
            //        string PreviousRate_LeadTime = "";

            //        HiddenField hdnMinimumRate = (HiddenField)row.FindControl("hdnMinimumRate");
            //        HiddenField hdnMinimumLeadTime = (HiddenField)row.FindControl("hdnMinimumLeadTime");

            //        CurrentRate_LeadTime = hdnMinimumRate.Value.ToString() + hdnMinimumLeadTime.Value.ToString();

            //        HiddenField hdnMinimumRatePrev = (HiddenField)previousRow.FindControl("hdnMinimumRate");
            //        HiddenField hdnMinimumLeadTimePrev = (HiddenField)previousRow.FindControl("hdnMinimumLeadTime");

            //        PreviousRate_LeadTime = hdnMinimumRatePrev.Value.ToString() + hdnMinimumLeadTimePrev.Value.ToString();

            //        if (CurrentRate_LeadTime == PreviousRate_LeadTime)
            //        {
            //            if (previousRow.Cells[5].RowSpan == 0)
            //            {
            //                if (row.Cells[5].RowSpan == 0)
            //                {
            //                    previousRow.Cells[5].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
            //                }
            //                row.Cells[5].Visible = false;
            //            }
            //        }

            //        HiddenField hdnSupplierID = (HiddenField)row.FindControl("hdnSupplierID");
            //        HiddenField hdnSupplierIDPrev = (HiddenField)previousRow.FindControl("hdnSupplierID");

            //        if (hdnSupplierID.Value == hdnSupplierIDPrev.Value)
            //        {
            //            if (previousRow.Cells[6].RowSpan == 0)
            //            {
            //                if (row.Cells[6].RowSpan == 0)
            //                {
            //                    previousRow.Cells[6].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[6].RowSpan = row.Cells[6].RowSpan + 1;
            //                }
            //                row.Cells[6].Visible = false;
            //            }
            //        }

            //        string CurrentQuoted = "";
            //        string PrevQuoted = "";

            //        HiddenField hdnQuotedRate = (HiddenField)row.FindControl("hdnQuotedRate");
            //        HiddenField hdnQuotedLeadTime = (HiddenField)row.FindControl("hdnQuotedLeadTime");

            //        HiddenField hdnQuotedRatePrev = (HiddenField)previousRow.FindControl("hdnQuotedRate");
            //        HiddenField hdnQuotedLeadTimePrev = (HiddenField)previousRow.FindControl("hdnQuotedLeadTime");

            //        if ((Convert.ToDouble(hdnQuotedRate.Value) > 0) && (Convert.ToDouble(hdnQuotedRatePrev.Value) > 0))
            //        {
            //            CurrentQuoted = hdnQuotedRate.Value.ToString() + hdnQuotedLeadTime.Value.ToString();
            //            PrevQuoted = hdnQuotedRatePrev.Value.ToString() + hdnQuotedLeadTimePrev.Value.ToString();

            //            if (CurrentQuoted == PrevQuoted)
            //            {
            //                if (previousRow.Cells[7].RowSpan == 0)
            //                {
            //                    if (row.Cells[7].RowSpan == 0)
            //                    {
            //                        previousRow.Cells[7].RowSpan += 2;
            //                    }
            //                    else
            //                    {
            //                        previousRow.Cells[7].RowSpan = row.Cells[7].RowSpan + 1;
            //                    }
            //                    row.Cells[7].Visible = false;
            //                }
            //            }
            //        }

            //    }

            //}
        }

        protected void grdProcess_DataBound(object sender, EventArgs e)
        {
            //for (int i = grdProcess.Rows.Count - 1; i > 0; i--)
            //{
            //    GridViewRow row = grdProcess.Rows[i];
            //    GridViewRow previousRow = grdProcess.Rows[i - 1];
            //    string CurrentAccessory = "";
            //    string PreviousAccessory = "";

            //    HiddenField hdAccessoryMasterId = (HiddenField)row.FindControl("hdAccessoryMasterId");
            //    HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
            //    HiddenField hdnColorprint = (HiddenField)row.FindControl("hdnColorprint");
            //    CurrentAccessory = hdAccessoryMasterId.Value + hdnAccessoryQualitySize.Value.Trim() + hdnColorprint.Value.Trim();


            //    HiddenField hdAccessoryMasterId_Previous = (HiddenField)previousRow.FindControl("hdAccessoryMasterId");
            //    HiddenField hdnAccessoryQualitySize_Previous = (HiddenField)previousRow.FindControl("hdnAccessoryQualitySize");
            //    HiddenField hdnColorprint_Previous = (HiddenField)previousRow.FindControl("hdnColorprint");
            //    PreviousAccessory = hdAccessoryMasterId_Previous.Value + hdnAccessoryQualitySize_Previous.Value.Trim() + hdnColorprint_Previous.Value.Trim();

            //    if (CurrentAccessory == PreviousAccessory)
            //    {
            //        if (previousRow.Cells[0].RowSpan == 0)
            //        {
            //            if (row.Cells[0].RowSpan == 0)
            //            {
            //                previousRow.Cells[0].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
            //            }
            //            row.Cells[0].Visible = false;
            //        }
            //        if (previousRow.Cells[1].RowSpan == 0)
            //        {
            //            if (row.Cells[1].RowSpan == 0)
            //            {
            //                previousRow.Cells[1].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
            //            }
            //            row.Cells[1].Visible = false;
            //        }

            //        Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
            //        Label lblQuantityToOrderPrev = (Label)previousRow.FindControl("lblQuantityToOrder");

            //        if (lblQuantityToOrder.Text == lblQuantityToOrderPrev.Text)
            //        {
            //            if (previousRow.Cells[2].RowSpan == 0)
            //            {
            //                if (row.Cells[2].RowSpan == 0)
            //                {
            //                    previousRow.Cells[2].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
            //                }
            //                row.Cells[2].Visible = false;
            //            }
            //        }

            //        Label lblShrinkage = (Label)row.FindControl("lblShrinkage");
            //        Label lblShrinkagePrev = (Label)previousRow.FindControl("lblShrinkage");

            //        if (lblShrinkage.Text == lblShrinkagePrev.Text)
            //        {
            //            if (previousRow.Cells[3].RowSpan == 0)
            //            {
            //                if (row.Cells[3].RowSpan == 0)
            //                {
            //                    previousRow.Cells[3].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
            //                }
            //                row.Cells[3].Visible = false;
            //            }
            //        }
            //        Label lblWastage = (Label)row.FindControl("lblWastage");
            //        Label lblWastagePrev = (Label)previousRow.FindControl("lblWastage");

            //        if (lblWastage.Text == lblWastagePrev.Text)
            //        {
            //            if (previousRow.Cells[4].RowSpan == 0)
            //            {
            //                if (row.Cells[4].RowSpan == 0)
            //                {
            //                    previousRow.Cells[4].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[4].RowSpan = row.Cells[4].RowSpan + 1;
            //                }
            //                row.Cells[4].Visible = false;
            //            }
            //        }

            //        string CurrentRate_LeadTime = "";
            //        string PreviousRate_LeadTime = "";

            //        HiddenField hdnMinimumRate = (HiddenField)row.FindControl("hdnMinimumRate");
            //        HiddenField hdnMinimumLeadTime = (HiddenField)row.FindControl("hdnMinimumLeadTime");

            //        CurrentRate_LeadTime = hdnMinimumRate.Value.ToString() + hdnMinimumLeadTime.Value.ToString();

            //        HiddenField hdnMinimumRatePrev = (HiddenField)previousRow.FindControl("hdnMinimumRate");
            //        HiddenField hdnMinimumLeadTimePrev = (HiddenField)previousRow.FindControl("hdnMinimumLeadTime");

            //        PreviousRate_LeadTime = hdnMinimumRatePrev.Value.ToString() + hdnMinimumLeadTimePrev.Value.ToString();

            //        if (CurrentRate_LeadTime == PreviousRate_LeadTime)
            //        {
            //            if (previousRow.Cells[5].RowSpan == 0)
            //            {
            //                if (row.Cells[5].RowSpan == 0)
            //                {
            //                    previousRow.Cells[5].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
            //                }
            //                row.Cells[5].Visible = false;
            //            }
            //        }

            //        HiddenField hdnSupplierID = (HiddenField)row.FindControl("hdnSupplierID");
            //        HiddenField hdnSupplierIDPrev = (HiddenField)previousRow.FindControl("hdnSupplierID");

            //        if (hdnSupplierID.Value == hdnSupplierIDPrev.Value)
            //        {
            //            if (previousRow.Cells[6].RowSpan == 0)
            //            {
            //                if (row.Cells[6].RowSpan == 0)
            //                {
            //                    previousRow.Cells[6].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[6].RowSpan = row.Cells[6].RowSpan + 1;
            //                }
            //                row.Cells[6].Visible = false;
            //            }
            //        }

            //        string CurrentQuoted = "";
            //        string PrevQuoted = "";

            //        HiddenField hdnQuotedRate = (HiddenField)row.FindControl("hdnQuotedRate");
            //        HiddenField hdnQuotedLeadTime = (HiddenField)row.FindControl("hdnQuotedLeadTime");

            //        HiddenField hdnQuotedRatePrev = (HiddenField)previousRow.FindControl("hdnQuotedRate");
            //        HiddenField hdnQuotedLeadTimePrev = (HiddenField)previousRow.FindControl("hdnQuotedLeadTime");

            //        if ((Convert.ToDouble(hdnQuotedRate.Value) > 0) && (Convert.ToDouble(hdnQuotedRatePrev.Value) > 0))
            //        {
            //            CurrentQuoted = hdnQuotedRate.Value.ToString() + hdnQuotedLeadTime.Value.ToString();
            //            PrevQuoted = hdnQuotedRatePrev.Value.ToString() + hdnQuotedLeadTimePrev.Value.ToString();

            //            if (CurrentQuoted == PrevQuoted)
            //            {
            //                if (previousRow.Cells[7].RowSpan == 0)
            //                {
            //                    if (row.Cells[7].RowSpan == 0)
            //                    {
            //                        previousRow.Cells[7].RowSpan += 2;
            //                    }
            //                    else
            //                    {
            //                        previousRow.Cells[7].RowSpan = row.Cells[7].RowSpan + 1;
            //                    }
            //                    row.Cells[7].Visible = false;
            //                }
            //            }
            //        }

            //    }

            //}
        }

        protected void grdFinish_DataBound(object sender, EventArgs e)
        {
            //for (int i = grdFinish.Rows.Count - 1; i > 0; i--)
            //{
            //    GridViewRow row = grdFinish.Rows[i];
            //    GridViewRow previousRow = grdFinish.Rows[i - 1];
            //    string CurrentAccessory = "";
            //    string PreviousAccessory = "";

            //    HiddenField hdAccessoryMasterId = (HiddenField)row.FindControl("hdAccessoryMasterId");
            //    HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
            //    HiddenField hdnColorprint = (HiddenField)row.FindControl("hdnColorprint");
            //    CurrentAccessory = hdAccessoryMasterId.Value + hdnAccessoryQualitySize.Value.Trim() + hdnColorprint.Value.Trim();


            //    HiddenField hdAccessoryMasterId_Previous = (HiddenField)previousRow.FindControl("hdAccessoryMasterId");
            //    HiddenField hdnAccessoryQualitySize_Previous = (HiddenField)previousRow.FindControl("hdnAccessoryQualitySize");
            //    HiddenField hdnColorprint_Previous = (HiddenField)previousRow.FindControl("hdnColorprint");
            //    PreviousAccessory = hdAccessoryMasterId_Previous.Value + hdnAccessoryQualitySize_Previous.Value.Trim() + hdnColorprint_Previous.Value.Trim();

            //    if (CurrentAccessory == PreviousAccessory)
            //    {
            //        if (previousRow.Cells[0].RowSpan == 0)
            //        {
            //            if (row.Cells[0].RowSpan == 0)
            //            {
            //                previousRow.Cells[0].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
            //            }
            //            row.Cells[0].Visible = false;
            //        }
            //        if (previousRow.Cells[1].RowSpan == 0)
            //        {
            //            if (row.Cells[1].RowSpan == 0)
            //            {
            //                previousRow.Cells[1].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
            //            }
            //            row.Cells[1].Visible = false;
            //        }

            //        Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
            //        Label lblQuantityToOrderPrev = (Label)previousRow.FindControl("lblQuantityToOrder");

            //        if (lblQuantityToOrder.Text == lblQuantityToOrderPrev.Text)
            //        {
            //            if (previousRow.Cells[2].RowSpan == 0)
            //            {
            //                if (row.Cells[2].RowSpan == 0)
            //                {
            //                    previousRow.Cells[2].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
            //                }
            //                row.Cells[2].Visible = false;
            //            }
            //        }

            //        Label lblShrinkage = (Label)row.FindControl("lblShrinkage");
            //        Label lblShrinkagePrev = (Label)previousRow.FindControl("lblShrinkage");

            //        if (lblShrinkage.Text == lblShrinkagePrev.Text)
            //        {
            //            if (previousRow.Cells[3].RowSpan == 0)
            //            {
            //                if (row.Cells[3].RowSpan == 0)
            //                {
            //                    previousRow.Cells[3].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
            //                }
            //                row.Cells[3].Visible = false;
            //            }
            //        }
            //        Label lblWastage = (Label)row.FindControl("lblWastage");
            //        Label lblWastagePrev = (Label)previousRow.FindControl("lblWastage");

            //        if (lblWastage.Text == lblWastagePrev.Text)
            //        {
            //            if (previousRow.Cells[4].RowSpan == 0)
            //            {
            //                if (row.Cells[4].RowSpan == 0)
            //                {
            //                    previousRow.Cells[4].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[4].RowSpan = row.Cells[4].RowSpan + 1;
            //                }
            //                row.Cells[4].Visible = false;
            //            }
            //        }

            //        string CurrentRate_LeadTime = "";
            //        string PreviousRate_LeadTime = "";

            //        HiddenField hdnMinimumRate = (HiddenField)row.FindControl("hdnMinimumRate");
            //        HiddenField hdnMinimumLeadTime = (HiddenField)row.FindControl("hdnMinimumLeadTime");

            //        CurrentRate_LeadTime = hdnMinimumRate.Value.ToString() + hdnMinimumLeadTime.Value.ToString();

            //        HiddenField hdnMinimumRatePrev = (HiddenField)previousRow.FindControl("hdnMinimumRate");
            //        HiddenField hdnMinimumLeadTimePrev = (HiddenField)previousRow.FindControl("hdnMinimumLeadTime");

            //        PreviousRate_LeadTime = hdnMinimumRatePrev.Value.ToString() + hdnMinimumLeadTimePrev.Value.ToString();

            //        if (CurrentRate_LeadTime == PreviousRate_LeadTime)
            //        {
            //            if (previousRow.Cells[5].RowSpan == 0)
            //            {
            //                if (row.Cells[5].RowSpan == 0)
            //                {
            //                    previousRow.Cells[5].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
            //                }
            //                row.Cells[5].Visible = false;
            //            }
            //        }

            //        HiddenField hdnSupplierID = (HiddenField)row.FindControl("hdnSupplierID");
            //        HiddenField hdnSupplierIDPrev = (HiddenField)previousRow.FindControl("hdnSupplierID");

            //        if (hdnSupplierID.Value == hdnSupplierIDPrev.Value)
            //        {
            //            if (previousRow.Cells[6].RowSpan == 0)
            //            {
            //                if (row.Cells[6].RowSpan == 0)
            //                {
            //                    previousRow.Cells[6].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[6].RowSpan = row.Cells[6].RowSpan + 1;
            //                }
            //                row.Cells[6].Visible = false;
            //            }
            //        }

            //        string CurrentQuoted = "";
            //        string PrevQuoted = "";

            //        HiddenField hdnQuotedRate = (HiddenField)row.FindControl("hdnQuotedRate");
            //        HiddenField hdnQuotedLeadTime = (HiddenField)row.FindControl("hdnQuotedLeadTime");

            //        HiddenField hdnQuotedRatePrev = (HiddenField)previousRow.FindControl("hdnQuotedRate");
            //        HiddenField hdnQuotedLeadTimePrev = (HiddenField)previousRow.FindControl("hdnQuotedLeadTime");

            //        if ((Convert.ToDouble(hdnQuotedRate.Value) > 0) && (Convert.ToDouble(hdnQuotedRatePrev.Value) > 0))
            //        {
            //            CurrentQuoted = hdnQuotedRate.Value.ToString() + hdnQuotedLeadTime.Value.ToString();
            //            PrevQuoted = hdnQuotedRatePrev.Value.ToString() + hdnQuotedLeadTimePrev.Value.ToString();

            //            if (CurrentQuoted == PrevQuoted)
            //            {
            //                if (previousRow.Cells[7].RowSpan == 0)
            //                {
            //                    if (row.Cells[7].RowSpan == 0)
            //                    {
            //                        previousRow.Cells[7].RowSpan += 2;
            //                    }
            //                    else
            //                    {
            //                        previousRow.Cells[7].RowSpan = row.Cells[7].RowSpan + 1;
            //                    }
            //                    row.Cells[7].Visible = false;
            //                }
            //            }
            //        }

            //    }
            //}
        }

        protected void rptPoDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblPoNumber = (Label)e.Item.FindControl("lblPoNumber");

                if (lblPoNumber.Text != "")
                {
                    int SupplyType = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SupplyType"));
                    int SupplierPoId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SupplierPoId"));
                    int AccessoryMasterId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "AccessoryMaster_Id"));
                    string Size = DataBinder.Eval(e.Item.DataItem, "Size").ToString();
                    string Color_Print = DataBinder.Eval(e.Item.DataItem, "Color_Print").ToString();
                    string sLink = "ShowPurchaseOrder(" + AccessoryMasterId + ", '" + Size + "', '" + Color_Print + "', " + SupplierPoId + ", " + SupplyType + ")";
                    lblPoNumber.Attributes.Add("onclick", sLink);

                    Label lblQuanity = (Label)e.Item.FindControl("lblQuanity");
                    double ReceivedQty = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ReceivedQty"));
                    string UnitsName = DataBinder.Eval(e.Item.DataItem, "UnitsName").ToString();

                    if (ReceivedQty > 0)
                    {
                        string GarmentName = ReceivedQty >= 1000 ? "<span style='color:gray;font-weight:600'>k " + UnitsName.ToString() + "</span>" : "<span style='color:gray;font-weight:600'> " + UnitsName.ToString() + "</span>";
                        string strReceivedQty = ReceivedQty >= 1000 ? Math.Round(ReceivedQty / 1000, 0).ToString() : ReceivedQty.ToString();
                        lblQuanity.Text = strReceivedQty + GarmentName;
                        lblQuanity.ToolTip = ReceivedQty.ToString();
                    }
                    HtmlTableRow trPoNumber = e.Item.FindControl("trPoNumber") as HtmlTableRow;
                    int PoStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "PoStatus"));
                    if (PoStatus == 1) { trPoNumber.Style.Add("background-color", "#fbcba2;"); trPoNumber.Attributes.Add("title", "Cancel PO"); }
                    if (PoStatus == 2) { trPoNumber.Style.Add("background-color", "#ffc9c6;"); trPoNumber.Attributes.Add("title", "Closed PO"); }

                    Button btnAccept = (Button)e.Item.FindControl("btnAccept");
                    HiddenField hdnIsPartySignature = (HiddenField)e.Item.FindControl("hdnIsPartySignature");
                    if (hdnIsPartySignature.Value.ToLower() == "false" && PoStatus != 2 && PoStatus != 1) { btnAccept.Visible = true; }
                    else { btnAccept.Visible = false; }
                }
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string confirmValue = confirm_value.Value;
            if (confirmValue == "Yes")
            {
                Button btnAccept = sender as Button;
                RepeaterItem RiRow = btnAccept.NamingContainer as RepeaterItem;
                string hdnSupplierPoId = (RiRow.FindControl("hdnSupplierPoId") as HiddenField).Value;
                try
                {
                    int sign = onjadminCon.UpdatePartySignBySupplier(Convert.ToInt32(hdnSupplierPoId), iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID, "Accessory");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  btnAccept_Click function  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            confirm_value.Value = "No";
            btnSearch_Click(sender, e);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Accessorytype = hdnTabAccessory.Value;
            BindAccessoryTabs();
            SetTab();
        }
    }
}