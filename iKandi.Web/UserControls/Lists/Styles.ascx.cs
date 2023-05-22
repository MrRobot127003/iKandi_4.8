using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace iKandi.Web.UserControls.Lists
{
    public partial class Styles : BaseUserControl
    {
        # region Fields
        int TotalRowCount = 0;


        DateTime fromETADate = DateTime.MinValue;
        DateTime toETADate = DateTime.MinValue;
        public int UserID;
        # endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
            if (!IsPostBack)
            {
                if (ddlMerchandiser.SelectedValue != "-1")
                {
                    txtFRqd.Enabled = true;
                    txtTRqd.Enabled = true;
                }
                bindSeason();
                BindControls(false);
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 104 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 32 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 14)
                { Button1.Visible = true; }
                else { Button1.Visible = false; }


                List<Client> BindClientListAgainstMerchant = this.AdminControllerInstance.BindClientListAgainstMerchant(Convert.ToInt32(ddlMerchandiser.SelectedValue), 1);
                if (BindClientListAgainstMerchant.Count > 0)
                {
                    ddlClients.Items.Clear();
                    ddlDepts.Items.Clear();
                    ddlDepts.Items.Insert(0, "All");
                    ddlClients.DataSource = BindClientListAgainstMerchant;
                    ddlClients.DataTextField = "CompanyName";
                    ddlClients.DataValueField = "ClientID";
                    ddlClients.DataBind();
                    txtFRqd.Enabled = true;
                    txtTRqd.Enabled = true;
                }
            }
        }
        public void bindSeason()
        {
            DataTable dt = this.StyleControllerInstance.GetAllSeasonBAL();
            ddlSeason.DataSource = dt;
            ddlSeason.DataTextField = "SeasonName";
            ddlSeason.DataValueField = "SeasonName";
            //  ddlSeason.DataValueField = "SeasonName"; 
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ddlSeason.Items.Add(dr["SeasonName"].ToString());
            //}
            ddlSeason.DataBind();
            int GlobalType = 0;
            GlobalType = StyleControllerInstance.GetGlobalType(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), out GlobalType);
            DataTable dtMerchent = this.StyleControllerInstance.GetAllMerchentDAL(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID));
            ddlMerchandiser.DataSource = dtMerchent;
            ddlMerchandiser.DataTextField = "Name";
            ddlMerchandiser.DataValueField = "UserID";
            if ((GlobalType == 1) || (GlobalType == 3) || (GlobalType == 3))
                ddlMerchandiser.SelectedValue = "-1";
            ddlMerchandiser.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls(true);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;

            if (link == null) return;

            int styleID = Convert.ToInt32(link.CommandArgument);

            this.StyleControllerInstance.DeleteStyle(styleID);

            BindControls(true);
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView2.PageSize.ToString();
            hdnPageIndex.Value = GridView2.PageIndex.ToString();

            if (null != Session["Paging"])
            {
                GridView2.DataSource = Session["Paging"];
                GridView2.DataBind();
            }
            else BindControls(true);
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            Label priority = e.Row.FindControl("lblPriority") as Label;
            if (priority == null) return;
            // HtmlGenericControl tdPriority = (HtmlGenericControl)e.Row.FindControl("tdPriority");
            HtmlTableCell tdPriority = (HtmlTableCell)e.Row.FindControl("tdPriority");
            //tdPriority.Style.Add(HtmlTextWriterStyle.BackgroundColor, dt.Rows[0]["ClientColorCode"].ToString());
            // tdPriority.Style.Add(HtmlTextWriterStyle.BackgroundColor, Constants.GetStyleSamplingPriorityColor(priority.Text));



            //(priority.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStyleSamplingPriorityColor(priority.Text.ToUpper()));

            iKandi.Common.Style styles = (e.Row.DataItem as iKandi.Common.Style);

            HtmlAnchor hypstatusmode = e.Row.FindControl("hypstatusmode") as HtmlAnchor;
            (hypstatusmode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(styles.StatusModeID));

            CheckBox chkFabricSamplingProgramIssued = e.Row.FindControl("chkFabricSamplingProgramIssued") as CheckBox;
            CheckBox chkIssuedForPatternMaking = e.Row.FindControl("chkIssuedForPatternMaking") as CheckBox;
            CheckBox chkFabricIssuedForCutting = e.Row.FindControl("chkFabricIssuedForCutting") as CheckBox;
            CheckBox chkOnMachineOrFinishingOrReadyForDispatch = e.Row.FindControl("chkOnMachineOrFinishingOrReadyForDispatch") as CheckBox;

            Label lblFabricSamplingProgramIssue = e.Row.FindControl("lblFabricSamplingProgramIssue") as Label;
            Label lblIssuedForPatternMaking = e.Row.FindControl("lblIssuedForPatternMaking") as Label;
            Label lblFabricIssuedForCutting = e.Row.FindControl("lblFabricIssuedForCutting") as Label;
            Label lblOnMachineOrFinishingOrReadyForDispatch = e.Row.FindControl("lblOnMachineOrFinishingOrReadyForDispatch") as Label;
            HiddenField hdnFitsType = e.Row.FindControl("hdnFitsSample") as HiddenField;
            HiddenField HdnMasterName = e.Row.FindControl("HdnMasterName") as HiddenField;
            Label lblCadMasterName = e.Row.FindControl("lblCadMasterName") as Label;
            //var hiddenfoeld = hdnFitsType.Value;
            //--------------Add-By-Prabhaker-------------//
            string MasterName = Convert.ToString(HdnMasterName.Value);
            string[] MasterFirstName = MasterName.Split(' ');
            lblCadMasterName.Text = "(" + MasterFirstName[0].ToString() + ")";

            Label lblHandOverAct = e.Row.FindControl("lblHandOverAct") as Label;
            Label lblPatternReadyAct = e.Row.FindControl("lblPatternReadyAct") as Label;
            Label lblSampleSentAct = e.Row.FindControl("lblSampleSentAct") as Label;
            Label lblCostingBiplAct = e.Row.FindControl("lblCostingBiplAct") as Label;
            Label lblPriceQuotedBiplAct = e.Row.FindControl("lblPriceQuotedBiplAct") as Label;
            Label lblComment = e.Row.FindControl("lblComment") as Label;

            string[] ArrComment = lblComment.Text.Trim().Split('~');

            lblComment.Text = ArrComment[ArrComment.Length - 1];

            HtmlTableCell tdEdit_Delete = (HtmlTableCell)e.Row.FindControl("tdEdit_Delete");
            int id = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            if (id == 13 || id == 32 || id == 104 || id == 14 || id == 6 || id == 151)
            {
                tdEdit_Delete.Visible = true;
            }
            else
            {
                tdEdit_Delete.Visible = false;
            }

            HtmlTableRow trHandover = (HtmlTableRow)e.Row.FindControl("trHandover");
            HtmlTableRow trPatternReady = (HtmlTableRow)e.Row.FindControl("trPatternReady");
            HtmlTableRow trSampleSent = (HtmlTableRow)e.Row.FindControl("trSampleSent");
            HtmlTableRow trCostingBipl = (HtmlTableRow)e.Row.FindControl("trCostingBipl");
            HtmlTableRow trPriceQuotedBipl = (HtmlTableRow)e.Row.FindControl("trHandover");

            Repeater rptbuyer = e.Row.FindControl("rptbuyer") as Repeater;
            //  DataTable dt = this.StyleControllerInstance.GetBuyerDetail(styles.StyleID);
            List<StyleBuyerDetail> objStyleBuyerDetail = styles.BuyerDetail.Where(x => x.StyleId == styles.StyleID).ToList();
            if (objStyleBuyerDetail.Count > 0)
            {
                rptbuyer.DataSource = objStyleBuyerDetail;
                rptbuyer.DataBind();
            }

            if (lblHandOverAct.Text == "")
            {
                trHandover.Style.Add("background-color", "Yellow");
            }
            if (lblPatternReadyAct.Text == "" && lblHandOverAct.Text != "")
            {
                trPatternReady.Style.Add("background-color", "Yellow");
            }
            if (lblSampleSentAct.Text == "" && lblPatternReadyAct.Text != "")
            {
                trSampleSent.Style.Add("background-color", "Yellow");
            }
            if (lblCostingBiplAct.Text == "" && lblSampleSentAct.Text != "")
            {
                trCostingBipl.Style.Add("background-color", "Yellow");
            }
            if (lblCostingBiplAct.Text == "" && lblPriceQuotedBiplAct.Text != "")
            {
                trPriceQuotedBipl.Style.Add("background-color", "Yellow");
            }


            if (hdnFitsType.Value == "1")
            {
                trHandover.Visible = false;
                trPatternReady.Visible = false;
                trSampleSent.Visible = false;
            }
            if (hdnFitsType.Value == "2")
            {
                trSampleSent.Visible = false;
            }

            if (priority.Text == "Urgent")
            {
                priority.Style.Add("color", "#ff4500;");
            }


            if (priority.Text == "High")
            {
                priority.Style.Add("color", "red");
            }


            if (priority.Text == "Medium")
            {
                priority.Style.Add("color", "green");
            }

            if (priority.Text == "Low")
            {
                priority.Style.Add("color", "blue");
            }


            //---------------End-of -Prabhaker----------//


            if (styles.CurrentUpdate.Count > 0)
            {
                StyleCurrentUpdate objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Fabric_Sampling_Program_Issued && s.StyleId == styles.StyleID); });
                UpdateColumnDataBinding(chkFabricSamplingProgramIssued, lblFabricSamplingProgramIssue, objStyleCurrentUpdate);

                objStyleCurrentUpdate = null;
                objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Issued_For_Pattern_Making && s.StyleId == styles.StyleID); });
                UpdateColumnDataBinding(chkIssuedForPatternMaking, lblIssuedForPatternMaking, objStyleCurrentUpdate);

                objStyleCurrentUpdate = null;
                objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Fabric_Issued_For_Cutting && s.StyleId == styles.StyleID); });
                UpdateColumnDataBinding(chkFabricIssuedForCutting, lblFabricIssuedForCutting, objStyleCurrentUpdate);

                objStyleCurrentUpdate = null;
                objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.On_Machine_Or_Finishing_Or_Ready_For_Dispatch && s.StyleId == styles.StyleID); });
                UpdateColumnDataBinding(chkOnMachineOrFinishingOrReadyForDispatch, lblOnMachineOrFinishingOrReadyForDispatch, objStyleCurrentUpdate);

            }
            else
            {
                chkFabricSamplingProgramIssued.Checked = false;
                chkIssuedForPatternMaking.Checked = false;
                chkFabricIssuedForCutting.Checked = false;
                chkOnMachineOrFinishingOrReadyForDispatch.Checked = false;
            }
        }


        protected void rptbuyer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdndesignation = (HiddenField)e.Item.FindControl("hdndesignation");
            HiddenField hdnUserID = (HiddenField)e.Item.FindControl("hdnUserID");
            TextBox txtrecbuyer = (TextBox)e.Item.FindControl("txtrecbuyer");
            TextBox txtissueon = (TextBox)e.Item.FindControl("txtissueon");
            TextBox txtETA = (TextBox)e.Item.FindControl("txtETA");
            TextBox txtactual = (TextBox)e.Item.FindControl("txtactual");
            DropDownList ddlstatus = (DropDownList)e.Item.FindControl("ddlstatus");

            hdnUserID.Value = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            txtrecbuyer.Enabled = false;
            txtissueon.Enabled = false;
            txtETA.Enabled = false;
            txtactual.Enabled = false;
            ddlstatus.Enabled = false;

            Label lblSampleSentAct = (Label)e.Item.Parent.Parent.FindControl("lblSampleSentAct");
            string ss = lblSampleSentAct.Text;

            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_FITs_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_SamplingMerchant || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager || ApplicationHelper.LoggedInUser.UserData.DesignationID == 24 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 23 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 15)
            {
                //txtrecbuyer.Enabled = true;
                if (txtrecbuyer.Text == "")
                {
                    txtrecbuyer.Enabled = true;
                }
                else
                {
                    txtrecbuyer.Enabled = false;
                }
                //txtissueon.Enabled = true;
                //txtETA.Enabled = true;
                //txtactual.Enabled = true;
                //ddlstatus.Enabled = true;
                if (ddlstatus.SelectedValue == "2")
                {
                    if (txtETA.Text.Trim() == "")
                    {
                        ddlstatus.Enabled = false;
                        txtETA.Text = txtactual.Text.Trim();
                        txtETA.Enabled = false;
                    }
                    else
                    {
                        ddlstatus.Enabled = false;
                        txtETA.Enabled = false;
                    }
                }
                else
                {
                    ddlstatus.Enabled = true;
                }

                if (txtissueon.Text == "")
                {
                    txtissueon.Enabled = true;
                }
                else
                {
                    txtissueon.Enabled = false;
                }
            }
            if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 24 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 23 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 15)
            {
                txtETA.Enabled = true;
                txtrecbuyer.Enabled = false;
                txtissueon.Enabled = false;
                //txtactual.Enabled = true;
                //ddlstatus.Enabled = true;
            }
            if (ddlstatus.SelectedValue == "2")
            {
                if (txtETA.Text.Trim() == "")
                {
                    ddlstatus.Enabled = false;
                    txtETA.Text = txtactual.Text.Trim();
                    txtETA.Enabled = false;
                }
                else
                {
                    ddlstatus.Enabled = false;
                    txtETA.Enabled = false;
                }
            }



        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType != DataControlRowType.DataRow) return;

        //    iKandi.Common.Style styles = (e.Row.DataItem as iKandi.Common.Style);

        //    CheckBox chkFabricSamplingProgramIssued = e.Row.FindControl("chkFabricSamplingProgramIssued") as CheckBox;
        //    CheckBox chkIssuedForPatternMaking = e.Row.FindControl("chkIssuedForPatternMaking") as CheckBox;
        //    CheckBox chkFabricIssuedForCutting = e.Row.FindControl("chkFabricIssuedForCutting") as CheckBox;
        //    CheckBox chkOnMachineOrFinishingOrReadyForDispatch = e.Row.FindControl("chkOnMachineOrFinishingOrReadyForDispatch") as CheckBox;

        //    Label lblFabricSamplingProgramIssue = e.Row.FindControl("lblFabricSamplingProgramIssue") as Label;
        //    Label lblIssuedForPatternMaking = e.Row.FindControl("lblIssuedForPatternMaking") as Label;
        //    Label lblFabricIssuedForCutting = e.Row.FindControl("lblFabricIssuedForCutting") as Label;
        //    Label lblOnMachineOrFinishingOrReadyForDispatch = e.Row.FindControl("lblOnMachineOrFinishingOrReadyForDispatch") as Label;

        //    if (styles.CurrentUpdate.Count > 0)
        //    {
        //        StyleCurrentUpdate objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Fabric_Sampling_Program_Issued && s.StyleId == styles.StyleID); });
        //        UpdateColumnDataBinding(chkFabricSamplingProgramIssued, lblFabricSamplingProgramIssue, objStyleCurrentUpdate);

        //        objStyleCurrentUpdate = null;
        //        objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Issued_For_Pattern_Making && s.StyleId == styles.StyleID); });
        //        UpdateColumnDataBinding(chkIssuedForPatternMaking, lblIssuedForPatternMaking, objStyleCurrentUpdate);

        //        objStyleCurrentUpdate = null;
        //        objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.Fabric_Issued_For_Cutting && s.StyleId == styles.StyleID); });
        //        UpdateColumnDataBinding(chkFabricIssuedForCutting, lblFabricIssuedForCutting, objStyleCurrentUpdate);

        //        objStyleCurrentUpdate = null;
        //        objStyleCurrentUpdate = styles.CurrentUpdate.Find(delegate(StyleCurrentUpdate s) { return (s.Type == StyleCurrentUpdates.On_Machine_Or_Finishing_Or_Ready_For_Dispatch && s.StyleId == styles.StyleID); });
        //        UpdateColumnDataBinding(chkOnMachineOrFinishingOrReadyForDispatch, lblOnMachineOrFinishingOrReadyForDispatch, objStyleCurrentUpdate);

        //    }
        //    else
        //    {
        //        chkFabricSamplingProgramIssued.Checked = false;
        //        chkIssuedForPatternMaking.Checked = false;
        //        chkFabricIssuedForCutting.Checked = false;
        //        chkOnMachineOrFinishingOrReadyForDispatch.Checked = false;
        //    }

        //}


        private void BindControls(Boolean IsFirstPage)
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindDesignListAllClient(ddlClients, "Client", Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID));
                if (ddlClients.Items.Count > 1)
                    ddlClients.SelectedIndex = 0;

                DropdownHelper.BindDesignListAllClient(ddlDepts, "Dept", Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID));
                if (ddlDepts.Items.Count > 1)
                {
                    ddlDepts.SelectedIndex = 0;

                    ClientController objClientController = new ClientController();

                    if (ddlClients.SelectedValue != "-1")
                    {
                        List<Client> BindDeptListAgainstCliets = this.AdminControllerInstance.BindDeptListAgainstParentDept(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(ddlMerchandiser.SelectedValue), Convert.ToInt32(ddlDepts.SelectedValue));
                        if (BindDeptListAgainstCliets.Count > 0)
                        {
                            ddlChildDept.Items.Clear();
                            ddlChildDept.DataSource = BindDeptListAgainstCliets;
                            ddlChildDept.DataTextField = "CompanyName";
                            ddlChildDept.DataValueField = "ClientID";
                            ddlChildDept.DataBind();
                        }
                    }
                    else
                    {
                        ddlChildDept.Items.Clear();
                        ddlChildDept.Items.Insert(0, "All");
                    }
                }
                else
                {
                    ddlChildDept.Items.Clear();
                    ddlChildDept.Items.Insert(0, "All");
                }
                int CompanyId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.CompanyID);
                if (CompanyId == 1)
                {
                    ddlUptostatus.SelectedValue = "6";
                }


            }

            int ddlSelectvalue = -1;
            int Criteria = -1;
            hdnPagesize.Value = GridView2.PageSize.ToString();
            hdnPageIndex.Value = GridView2.PageIndex.ToString();
            //fromETADate = DateHelper.ParseDate(txtFRqd.Text).Value;
            //toETADate = DateHelper.ParseDate(txtTRqd.Text).Value;
            var obj = new BuyingHouseController();
            if (txtFRqd.Text.ToString() == "")
            {
                fromETADate = DateHelper.ParseDate(txtFRqd.Text).Value;
            }
            else
            {
                fromETADate = Convert.ToDateTime(txtFRqd.Text);
            }
            if (txtTRqd.Text.ToString() == "")
            {
                toETADate = DateHelper.ParseDate(txtTRqd.Text).Value;
            }
            else
            {
                toETADate = Convert.ToDateTime(txtTRqd.Text.ToString());
            }

            if (ddlDepts.SelectedValue == "All")
                ddlSelectvalue = -1;
            else
                ddlSelectvalue = Convert.ToInt32(ddlDepts.SelectedValue);
            Criteria = Convert.ToInt32(DdlCriteria.SelectedValue);

            int ChildDeptSelcted = 0;
            if (ddlChildDept.SelectedValue == "All")
                ChildDeptSelcted = -1;
            else
                ChildDeptSelcted = Convert.ToInt32(Convert.ToInt32(ddlChildDept.SelectedValue));


            //  List<iKandi.Common.SamplingStatus> objSamplingStyle = this.StyleControllerInstance.GetAllStylesPendingSamples(Convert.ToInt32(ddlSeason.SelectedValue),Convert.ToInt32(ddlClients.SelectedValue), txtSearchText.Text);

            List<iKandi.Common.SamplingStatus> objSamplingStyle =
                                                     this.StyleControllerInstance.GetAllStylesPendingSamples(Convert.ToString(ddlSeason.SelectedItem.Text)
                                                                                                             , Convert.ToInt32(ddlClients.SelectedValue)
                                                                                                             , txtSearchText.Text
                                                                                                             , Convert.ToInt32(ddlMerchandiser.SelectedValue)
                                                                                                             , fromETADate
                                                                                                             , toETADate
                                                                                                             , ddlSelectvalue
                                                                                                             , Convert.ToInt32(ddlFilter1.SelectedValue)
                                                                                                             , Convert.ToInt32(ddlFilter2.SelectedValue)
                                                                                                             , Convert.ToInt32(ddlFilter3.SelectedValue)
                                                                                                             , Convert.ToInt32(ddlFilter4.SelectedValue)
                                                                                                             , Convert.ToDecimal(ddlfromStatus.SelectedValue)
                                                                                                             , Convert.ToDecimal(ddlUptostatus.SelectedValue)
                                                                                                             , Convert.ToInt32(ddldelay.SelectedValue)
                                                                                                             , Convert.ToInt32(rdosortingorder.SelectedValue)
                                                                                                             , Criteria
                                                                                                             , ChildDeptSelcted);

            Session["Paging"] = objSamplingStyle;

            GridView2.DataSource = objSamplingStyle;
            GridView2.DataBind();

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            if (IsFirstPage)
            {
                this.HyperLinkPager1.PageIndex = 0;
            }
            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();
        }
        protected void btntoExcel_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GenerateExcel();
            }
        }
        public void GenerateExcel()
        {

            StringBuilder sb = new StringBuilder();
            DataTable dtexcel = this.StyleControllerInstance.GetExcelReport();
            //DataTable dtexcel = new DataTable();
            // DataTable dtexcel = (DataTable)Session["Dept"];

            if (dtexcel.Rows.Count > 0)
            {
                sb.Append("<TABLE width=100% cellpadding=0 cellspacing=0 border=1>");

                sb.Append("<TR>");

                sb.Append("<TH style='background-color : #39589c; color:white; color:white; width:150px;'>S.N</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Style No.</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Sketch</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Buyer Style No.</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Sketch Recv Date.</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>FABRIC</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>PICTURES</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>STATUS</TH>");



                sb.Append("</TR>");

                foreach (DataRow row in dtexcel.Rows)
                {


                    sb.Append("<TR>");
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["S.n"].ToString() + "</TD>");
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["StyleNumber"].ToString() + "</TD>");

                    //'"+http://localhost:3220/ + ResolveUrl("~/uploads/style/thumb-" + row["SampleImageURL1"].ToString())'
                    //'~/uploads/style/thumb-"+row["SampleImageURL1"].ToString()+"

                    //    '~/uploads/style/thumb-"+row["SampleImageURL1"].ToString()+"'
                    //string str="http://localhost:3220/ + ResolveUrl("~/uploads/style/thumb-" + row["SampleImageURL1"].ToString())"
                    if (row["SampleImageURL1"].ToString() != "")
                    {
                        string str = "http://ikandi.org.uk/uploads/style/thumb-" + row["SampleImageURL1"].ToString();
                        // basic //image
                        sb.Append("<TD style='width:150px; height:110px; valign:center;'>" + "<img  src='" + str + "' width='150' height='110' style='font-size:9px;' alt='Image not found'/>" + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD style='width:200px; height:100px;valign:center;'> </TD>");
                    }
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["BuyerStyleNumber"].ToString() + "</TD>");
                    // Ikandi style No
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["SketchRecDate"].ToString() + "</TD>");

                    // Dept.
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["Fabric"].ToString() + "</TD>");
                    if (row["Picture"].ToString() != "")
                    {
                        string str = "http://ikandi.org.uk/uploads/style/thumb-" + row["Picture"].ToString();
                        // basic //image
                        sb.Append("<TD style='width:150px; height:110px; valign:center;'>" + "<img  src='" + str + "' width='150' height='110' style='font-size:9px;' alt='Image not found'/>" + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD style='width:200px; height:100px;valign:center;'> </TD>");
                    }
                    // serialNo
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["Status"].ToString() + "</TD>");


                    sb.Append("</TR>");
                }

                sb.Append("</TABLE>");

                try
                {
                    this.StyleControllerInstance.DeleteSelectedCheckBox();
                    string fileName = "attachment;fileName=ExportToExcel.xls";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", fileName);
                    string[] font = new string[] { "Verdana", "Arial", "Sans-Serif" };

                    Response.Charset = "";

                    this.EnableViewState = false;



                    StringWriter strwiriter = new System.IO.StringWriter();

                    strwiriter.Write(sb.ToString());

                    HtmlTextWriter ohtmltextwriter = new HtmlTextWriter(strwiriter);

                    Repeater rt = new Repeater();

                    rt.RenderControl(ohtmltextwriter);

                    Response.Write(strwiriter.ToString());

                    Response.End();


                }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();
                }
            }
        }


        protected void ddlPDMerchantNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientController objClientController = new ClientController();



            //if (ddlMerchandiser.SelectedValue != "-1")
            //{
            List<Client> BindClientListAgainstMerchant = this.AdminControllerInstance.BindClientListAgainstMerchant(Convert.ToInt32(ddlMerchandiser.SelectedValue), 0);


            if (BindClientListAgainstMerchant.Count > 0)
            {
                ddlClients.Items.Clear();
                ddlDepts.Items.Clear();
                ddlChildDept.Items.Clear();
                ddlChildDept.Items.Insert(0, "All");
                ddlDepts.Items.Insert(0, "All");
                ddlClients.DataSource = BindClientListAgainstMerchant;
                ddlClients.DataTextField = "CompanyName";
                ddlClients.DataValueField = "ClientID";
                ddlClients.DataBind();
                txtFRqd.Enabled = true;
                txtTRqd.Enabled = true;
            }
            //}


            //else
            //{
            //    ddlClients.Items.Clear();
            //    ddlClients.Items.Insert(0, "All");
            //    ddlDepts.Items.Clear();
            //    ddlDepts.Items.Insert(0, "All");
            //    txtFRqd.Enabled = false;
            //    txtTRqd.Enabled = false;
            //}
        }
        protected void ddlClientNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientController objClientController = new ClientController();

            if (ddlClients.SelectedValue != "-1")
            {

                List<Client> BindDeptListAgainstCliets = this.AdminControllerInstance.BindDeptListAgainstCliets(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(ddlMerchandiser.SelectedValue));

                if (BindDeptListAgainstCliets.Count > 0)
                {
                    ddlChildDept.Items.Clear();
                    ddlChildDept.Items.Insert(0, "All");
                    ddlDepts.Items.Clear();
                    ddlDepts.DataSource = BindDeptListAgainstCliets;
                    ddlDepts.DataTextField = "CompanyName";
                    ddlDepts.DataValueField = "ClientID";
                    ddlDepts.DataBind();
                }
            }


            else
            {
                ddlDepts.Items.Clear();
                ddlDepts.Items.Insert(0, "All");
                ddlDepts.Items.Clear();
                ddlDepts.Items.Insert(0, "All");
            }
        }
        protected void ddlChildDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientController objClientController = new ClientController();

            if (ddlClients.SelectedValue != "-1")
            {

                List<Client> BindDeptListAgainstCliets = this.AdminControllerInstance.BindDeptListAgainstCliets(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(ddlMerchandiser.SelectedValue));

                if (BindDeptListAgainstCliets.Count > 0)
                {
                    ddlDepts.Items.Clear();
                    ddlDepts.DataSource = BindDeptListAgainstCliets;
                    ddlDepts.DataTextField = "CompanyName";
                    ddlDepts.DataValueField = "ClientID";
                    ddlDepts.DataBind();
                }
            }


            else
            {
                ddlDepts.Items.Clear();
                ddlDepts.Items.Insert(0, "All");
            }
        }

        private void UpdateColumnDataBinding(CheckBox chk, Label lbl, StyleCurrentUpdate objStyleCurrentUpdate)
        {
            if (objStyleCurrentUpdate == null)
            {
                chk.Checked = false;
            }
            else
            {
                if (objStyleCurrentUpdate.IsChecked == true)
                {
                    chk.Checked = true;
                    lbl.Text = objStyleCurrentUpdate.Date == DateTime.MinValue ? string.Empty : objStyleCurrentUpdate.Date.ToString("dd MMM yy (ddd)");
                }
                else
                {
                    chk.Checked = false;
                    lbl.Text = objStyleCurrentUpdate.Date == DateTime.MinValue ? string.Empty : objStyleCurrentUpdate.Date.ToString("dd MMM yy (ddd)");
                }
            }
        }

        public ListControl ddlDept { get; set; }

        protected void ddlDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClientController objClientController = new ClientController();
            //ddlDepts.DataBind();

            ClientController objClientController = new ClientController();

            if (ddlClients.SelectedValue != "-1")
            {
                List<Client> BindDeptListAgainstCliets = this.AdminControllerInstance.BindDeptListAgainstParentDept(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(ddlMerchandiser.SelectedValue), Convert.ToInt32(ddlDepts.SelectedValue));

                if (BindDeptListAgainstCliets.Count > 0)
                {
                    ddlChildDept.Items.Clear();
                    ddlChildDept.DataSource = BindDeptListAgainstCliets;
                    ddlChildDept.DataTextField = "CompanyName";
                    ddlChildDept.DataValueField = "ClientID";
                    ddlChildDept.DataBind();
                }
            }
            else
            {
                ddlChildDept.Items.Clear();
                ddlChildDept.Items.Insert(0, "All");
            }
        }
    }
}