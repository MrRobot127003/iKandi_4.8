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
using System.Collections.Generic;
using iKandi.BLL;
using iKandi.BLL.Production;
using iKandi.Web.Components;
using iKandi.Common;


namespace iKandi.Web
{
    public partial class UserTasksNew : BaseUserControl
    {

        int iUserId = 0;
        public int TaskId
        {
            get;
            set;
        }

        public int MyTask
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Server.Transfer("~/public/Login.aspx");

            trPendingTask.Visible = true;
            trProduction.Visible = false;
            BindControls();
        }

        private void BindControls()
        {
            List<UserTask> userAdditionalTasks = new List<UserTask>();

            if (MyTask == 3)
            {
                trNotiFication.Visible = true;

                if (ApplicationHelper.LoggedInUser.UserData != null)
                    iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                UserDetails usd = new UserDetails();
                SessionInfo sessionInfo = new SessionInfo();
                iKandi.Common.User user = null;

                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                ApplicationHelper objApplicationHelper = new ApplicationHelper();
                DataSet ds = objApplicationHelper.GetNotifactionRemarks(user.DesignationID, TaskId, "Group", iUserId);
                grdNotiFication.DataSource = ds.Tables[0];
                grdNotiFication.DataBind();
            }


            else if (MyTask == 4)
            {
                trtaskComplete.Visible = true;

                if (ApplicationHelper.LoggedInUser.UserData != null)
                    iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                UserDetails usd = new UserDetails();
                SessionInfo sessionInfo = new SessionInfo();
                iKandi.Common.User user = null;

                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                ApplicationHelper objApplicationHelper = new ApplicationHelper();
                DataSet ds = objApplicationHelper.GetTaskCompletebyTask(TaskId);
                Grdnotificatontask.DataSource = ds.Tables[0];
                Grdnotificatontask.DataBind();
            }

            else
            {

                if ((TaskId == 84) || (TaskId == 85) || (TaskId == 86) || (TaskId == 87) || (TaskId == 88))
                {
                    DataTable dtProductionTask = this.UserTaskControllerInstance.GetAllProductionTask(ApplicationHelper.LoggedInUser.UserData.UserID, TaskId);

                    gvProductionTask.DataSource = dtProductionTask;
                    gvProductionTask.DataBind();

                    trProduction.Visible = true;
                    trPendingTask.Visible = false;
                }
                else
                {
                    List<WorkflowInstanceDetail> objTasks = new List<WorkflowInstanceDetail>();
                    objTasks = this.WorkflowControllerInstance.GetUserTasksByDept(ApplicationHelper.LoggedInUser.UserData.UserID, TaskId, MyTask);

                    grdPendingTasks.DataSource = objTasks;
                    grdPendingTasks.DataBind();
                }
            }

        }



        protected void grdTasks_RowDataBound(object sender, GridViewRowEventArgs e)//this for task
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            GridViewRow row = e.Row;

            HiddenField hdnStyleID = row.FindControl("hdnStyleID") as HiddenField;
            HiddenField hdnCliID = row.FindControl("hdnCliID") as HiddenField;
            int flag_masterload = 1;
            int OrderID = 0;

            HiddenField hdnOrderID = row.FindControl("hdnOrderID") as HiddenField;
            HiddenField hdnStatusModeID = row.FindControl("hdnStatusModeID") as HiddenField;
            HiddenField hdnOrderDetailID = row.FindControl("hdnOrderDetailID") as HiddenField;
            HyperLink actionLink = row.FindControl("lnkAction") as HyperLink;
            HiddenField hdnUserTaskType = row.FindControl("hdnUserTaskType") as HiddenField;
            HiddenField hdnUserTaskName = row.FindControl("hdnUserTaskName") as HiddenField;
            Label lblTask = row.FindControl("lblTask") as Label;
            HiddenField hdnStyleCode = row.FindControl("hdnStyleCode") as HiddenField;
            HiddenField hdnFitStyleCodeVersion = row.FindControl("hdnFitStyleCodeVersion") as HiddenField;
            Label lblCourierSentOn = row.FindControl("lblCourierSentOn") as Label;
            Label lbltext = row.FindControl("lbltext") as Label;
            Label lblStyleNumber = row.FindControl("lblStyleNumber") as Label;
            HtmlAnchor lnk = e.Row.FindControl("lnk") as HtmlAnchor;
            Label lblBuyer = row.FindControl("lblBuyer") as Label;
            HiddenField hidept = row.FindControl("hidept") as HiddenField;
            HiddenField HandOverStatus = row.FindControl("HandOverStatus") as HiddenField;
            // added by rsb
            HiddenField hdnTaskDetail = row.FindControl("hdnTaskDetail") as HiddenField;
            HiddenField hdnPo_Number = row.FindControl("HdnPo_number") as HiddenField;
            HiddenField hdnSupplierName = row.FindControl("hdnSupplierName") as HiddenField;
            HiddenField hdnAgreeRate= row.FindControl("hdnAgreeRate") as HiddenField;
            HiddenField hdnSerialNumber = row.FindControl("hdnSerialNumber") as HiddenField;
            // end


            Label lblQty = row.FindControl("lblQty") as Label;
            Label Label3 = row.FindControl("Label3") as Label;
            Label lblFitsStatus = row.FindControl("lblFitsStatus") as Label;
            Label Contract = row.FindControl("Label21") as Label;
            Label LineItemNumber = row.FindControl("Label31") as Label;
            HiddenField Biplprice = row.FindControl("Biplprice") as HiddenField;
            //HiddenField ValueInR = row.FindControl("ValueInR") as HiddenField;

            HiddenField ValueInR = row.FindControl("ValueInR") as HiddenField;


            HiddenField hdnOrderDate = row.FindControl("hdnOrderDate") as HiddenField;
            HiddenField hdnExfactory = row.FindControl("hdnExfactory") as HiddenField;

            HiddenField hdnClinetCurrency = row.FindControl("hdnClinetCurrency") as HiddenField;


            WorkflowInstanceDetail wid = (e.Row.DataItem as WorkflowInstanceDetail);


            //if (wid.IsHidden && wid.StatusModeID == (int)TaskMode.PENDINGBIPLAGREEMENT)
            //{
            //    row.Visible = false;
            //    return;
            //}

            Label lblStatusMode = row.FindControl("lblStatus") as Label;
            (lblStatusMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(wid.StatusModeID));
            OrderID = wid.WorkflowInstance.Order.OrderID;
            Label lblETA = row.FindControl("lblEta") as Label;
            ////if ((TaskId == 11))
            ////{
            ////    lbltext.Text = "New Order for " + lblBuyer.Text + hidept.Value + "on " + lblStyleNumber.Text + " for " + lblQty.Text + "pcs @" + Biplprice.Value +  "for " + ValueInR.Value  + " By " + lblETA.Text;
            ////}
            //else if ((TaskId == 401) || (TaskId == 13) || (TaskId == 14) || (TaskId == 21) || (TaskId == 40) || (TaskId == 41) || (TaskId == 15) || (TaskId == 16) || (TaskId == 17) || (TaskId == 18) || (TaskId == 19) || (TaskId == 20) || (TaskId == 21) || (TaskId == 22) || (TaskId == 45))
            //{
            //    lbltext.Text = Label3.Text + " " + lblStyleNumber.Text + " for " + lblBuyer.Text + " " + hidept.Value + "for " + lblQty.Text + " pcs By " + lblETA.Text;

            //}
            //else if ((TaskId == 24) || (TaskId == 25) || (TaskId == 26))
            //{
            //    lbltext.Text = Label3.Text + " " + lblStyleNumber.Text + " for " + lblBuyer.Text + " " + hidept.Value + " Which was " + lblFitsStatus.Text + " " + lblQty.Text + " pcs By " + lblETA.Text;

            //}

            //else if ((TaskId >= 27) && (TaskId <= 39))
            //{
            //    lbltext.Text = Label3.Text + " " + lblStyleNumber.Text + " for " + lblBuyer.Text + " " + hidept.Value + " on " + Contract.Text + "</>" + LineItemNumber.Text + " for " + lblQty.Text + " pcs By " + lblETA.Text;

            //}

            //else
            //lbltext.Text = "<span style='font-weight:600 !important;color:black!important'>" + lblStyleNumber.Text + "</span>" + "<span style='color:black !important;' > for </span>" + "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  ";
            lbltext.Text = "<span style='font-weight:600 !important;color:black!important'>" + lblStyleNumber.Text +"</span>" +
                           "<span style='color:black !important;' > for </span>" + 
                           "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  " + hidept.Value + "</span>"+
                           "<span style='color:black !important;' >" + " By " + lblETA.Text + "</span>";

            if (!String.IsNullOrEmpty(lblETA.Text))
            {
                /* Pending */
                if (DateTime.Today.AddDays(2) < DateHelper.ParseDate(lblETA.Text).Value)
                    (lblETA.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");

                /* Urgent */
                if ((DateHelper.ParseDate(lblETA.Text).Value) >= DateTime.Today)
                {
                    long days = Math.Abs(Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, DateTime.Today, (DateHelper.ParseDate(lblETA.Text).Value), Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1));
                    if (days <= 2)
                        (lblETA.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                }

                /* Delayed */
                if (DateTime.Today > (DateHelper.ParseDate(lblETA.Text).Value))
                    (lblETA.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
            }

            actionLink.NavigateUrl = ResolveUrl("~" + wid.ApplicationModule.Path);
            actionLink.Text = wid.ApplicationModule.ApplicationModuleName;
            if (actionLink.Text == "Approved Value Added PO" || actionLink.Text == "Pending Value Added PO" || actionLink.Text == "Final Approved Value Added PO" || actionLink.Text == "Vendor Approved Pending Value Added PO")
            {
                //actionLink.Text = "<span style='color:#000'>" + actionLink.Text + " <b>" + lblBuyer.Text + "</b> " + "for " + hidept.Value + "</span>";

                actionLink.Text = "<span style='color:#000'>" + "Po <b> " + '(' + hdnPo_Number.Value + ')' + "</b> for" + " <b>" + hdnSerialNumber.Value + "</b> " + " " + " and " + "<b> " + lblStyleNumber.Text.Substring(14) + "</b> " + "and  <b>" + lblQty.Text + "</b> " + "with" + "<b> " + hdnSupplierName.Value + "</b> " + "for <b>" + hidept.Value + "</b> " + "pending for" + "<b> <span>₹</span>" + hdnAgreeRate.Value + "</b>" + "</span>";
                lbltext.Text = "";
            }

            if (actionLink.Text == "Approved Stich OutHouse PO" || actionLink.Text == "Pending Stich OutHouse PO" || actionLink.Text == "Final Approved Stich OutHouse PO" || actionLink.Text == "Vendor Approvel Pending Stich OutHouse PO")
            {
                string val = "";
               // actionLink.Text = "<span style='color:#000'>" + actionLink.Text + " <b>" + lblBuyer.Text + "</b> " + "for " + hidept.Value + "</span>";
                actionLink.Text = "<span style='color:#000'>" + "Po <b>" + '(' + hdnPo_Number.Value + ')' + "</b> for " + " <b>" + hdnSerialNumber.Value + "</b> and <b>" + lblStyleNumber.Text + "</b> and <b>" + lblQty.Text + "</b> with <b>" + hdnSupplierName.Value + "</b> for <b>" + (val = hdnSupplierName.Value == hidept.Value ? "" : hidept.Value) + "</b> pending for " + "<b> <span>₹</span>" + hdnAgreeRate.Value + "</b>" + "</span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "Acc Issue Request")
            {
                actionLink.Text = "Acc Issue Request " + " " + "<span style='font-weight:600 !important;color:black!important'>" + Label3.Text + "</span>" + "<span style='color:black !important;' > for </span>" + "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  " + hidept.Value + " Pcs </span><span style='color:black !important;' ></span>";
                lbltext.Text = "";
            }

            if (actionLink.Text == "Acc Issue Requested")
            {
                actionLink.Text = "Acc Issue Requested " + " " + "<span style='font-weight:600 !important;color:black!important'>" + Label3.Text + "</span>" + "<span style='color:black !important;' > for </span>" + "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  " + hidept.Value + "</span><span style='color:black !important;' ></span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "Accessories QA Inspection")
            {
                actionLink.Text = "Accessories Inspection " + "<span style='!important;color:gray !important'> for SRV(PO) </span> " + "<span style='color:black!important'>" + lblBuyer.Text + "</span>" + "<span style='!important;color:gray !important'> (" + Label3.Text + ")</span>";
                lbltext.Text = "";
            }

            if (actionLink.Text == "Internal Lab Pending Reports")
            {
                actionLink.Text = "Accessories Internal Lab Pending Reports " + "<span style='!important;color:gray !important'> for SRV(PO) </span> " + "<span style='color:black!important'>" + lblBuyer.Text + "</span>" + "<span style='!important;color:gray !important'> (" + Label3.Text + ")</span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "External Lab Pending Reports")
            {
                actionLink.Text = "Accessories External Lab Pending Reports " + "<span style='!important;color:gray !important'> for SRV(PO) </span> " + "<span style='color:black!important'>" + lblBuyer.Text + "</span>" + "<span style='!important;color:gray !important'> (" + Label3.Text + ")</span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "Internal Fabric Lab Pending Reports")
            {
                actionLink.Text = "Fabric Internal Lab Pending Reports " + "<span style='!important;color:gray !important'> for SRV(PO) </span> " + "<span style='color:black!important'>" + lblBuyer.Text + "</span>" + "<span style='!important;color:gray !important'> (" + Label3.Text + ")</span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "External Fabric Lab Pending Reports")
            {
                actionLink.Text = "Fabric External Lab Pending Reports " + "<span style='!important;color:gray !important'> for SRV(PO) </span> " + "<span style='color:black!important'>" + lblBuyer.Text + "</span>" + "<span style='!important;color:gray !important'> (" + Label3.Text + ")</span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "Fabric QA Inspection")
            {
                actionLink.Text = "Fabric Inspection " + "<span style='!important;color:gray !important'> for SRV(PO) </span> " + "<span style='color:black!important'>" + lblBuyer.Text + "</span>" + "<span style='!important;color:gray !important'> (" + Label3.Text + ")</span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "Fabric Issue Requested")
            {
                actionLink.Text = "Fabric Issue Requested " + " " + "<span style='font-weight:600 !important;color:black!important'>" + Label3.Text + "</span>" + "<span style='color:black !important;' > for </span>" + "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  " + hidept.Value + "</span><span style='color:black !important;' ></span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "Cutting Issue Requested")
            {
                actionLink.Text = "Fabric Issue Requested " + "" + "<span style='font-weight:600 !important;color:black!important'>" + lblStyleNumber.Text + "</span>" + "<span style='color:black !important;' > for </span>" + "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  ";
                lbltext.Text = "";
            }
            if (actionLink.Text == "CutIssue Settlement")
            {
                actionLink.Text = "CutIssue Settlement " + "" + "<span style='font-weight:600 !important;color:black!important'>" + lblStyleNumber.Text + "</span>" + "<span style='color:black !important;' > for </span>" + "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  ";
                lbltext.Text = "";
            }
            if (actionLink.Text == "ColorPrint Changed Revise PO")
            {
                actionLink.Text = "ColorPrint Changed Revise PO " + "" + "<span style='font-weight:600 !important;color:black!important'>" + lblStyleNumber.Text + "</span>" + "<span style='color:black !important;' > for </span>" + "<span style='font-weight:600 !important;color:black!important'>" + lblBuyer.Text + "  ";
                lbltext.Text = "";
            }
           
            if (actionLink.Text == "Fabric Working Form")
            {
                //lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>"
                lbltext.Text = "";
                actionLink.Text = "Fabric Working Form " + "<span style='color:black!important'><b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b></span>";
                lbltext.Text = "";
            }
            if (actionLink.Text == "Accessories Working Form")
            {
                //"Accessories Working Form " + "<span style='color:black!important'><b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b></span>";
                lbltext.Text = "";
                actionLink.Text = "Accessories Working Form " + "<span style='color:black!important'><b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b></span>";
                lbltext.Text = "";
            }

            if (actionLink.Text == "Price Quoted Bipl")
            {
                //actionLink.Text = " Price Quoted Bipl " + lbltext.Text;
                lbltext.Text = " Price Quoted Bipl " + lbltext.Text;
            }
            if (actionLink.Text == "Bipl Costing")
            {
                //actionLink.Text = " Bipl Costing " + lbltext.Text;
                lbltext.Text = " Bipl Costing " + lbltext.Text;
            }


            if (actionLink.Text == "Dispatch Entry File")
            {
                actionLink.Text = " Dispatch Entry File " + lbltext.Text;
                lbltext.Text = "";
            }
            //if (actionLink.Text == "Bipl Costing")
            //{
            //    actionLink.Text = " Bipl Costing " + lbltext.Text;
            //    lbltext.Text = "";
            //}
            //if (actionLink.Text == "Manage Orders")
            //{
            //    //lbltext.Text = "<span style='text-transform:capitalize !important'>C</span>utting Sheet " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " and for" + "<b>" + lblBuyer.Text + "</b>";
            //    actionLink.Text = "<span style='color:#000'>" + actionLink.Text + " " + "<span style='text-transform:capitalize !important'> C</span>utting Sheet " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " and for " + "<b>" + lblBuyer.Text + "</b></span>";
            //    lbltext.Text = "";
            //}
            if (actionLink.Text == "Final OB")
            {
                actionLink.ToolTip = "Note : Final OB done after inline cut";
            }
            if (actionLink.Text == "Tailor Master")
            {
                actionLink.Text = "<span style='text-transform:capitalize !important;'>T</span>ailor load";
                lbltext.Text = "";
                actionLink.Text = "<span style='text-transform:capitalize !important; color:black;'>" + actionLink.Text + " by " + lblETA.Text + "</span>";
                actionLink.NavigateUrl = ResolveUrl("~" + wid.ApplicationModule.Path);
                actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=1111" + "&flagvalue=1" + "&Status=" + lblETA.Text;

            }
            if (actionLink.Text == "Agreement Pending")
            {
                lbltext.Text = "";
                actionLink.Text = hdnTaskDetail.Value.ToString();
                // actionLink.Text = " Open Costing <span style='color:#000 !important'>" + lblStyleNumber.Text + "</b>" + " Action By " + "<b style='text-transform:lowercase;'>" + Label3.Text + "</b></span>";
                lbltext.Text = "";
            }

            if (actionLink.Text == "BIPL Compliance" || actionLink.Text == "QA Audit Compliance")
            {
                string text = actionLink.Text;
                lbltext.Text = "";
                actionLink.Text = "<span style='text-transform:capitalize !important; color:black;'><font color='#0088cc'>" + text + "</font> For <b>" + wid.DepartmentName + "</b></span>";
                actionLink.NavigateUrl = ResolveUrl("~" + wid.ApplicationModule.Path);
                //actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=1111" + "&flagvalue=1" + "&Status=Test";

            }
            if (Convert.ToInt32(hdnStatusModeID.Value) != 62)
            {
                if (actionLink.Text == "Costing Form")
                {
                    //lbltext.Text = lblStatusMode.Text + " " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + "  " + hidept.Value + "</b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                    //actionLink.Text = "<span style='color:#000'>" + actionLink.Text + " " + lblStatusMode.Text + " <b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + "  " + hidept.Value + "</b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b></span>";
                    actionLink.Text = "";
                    String BuyingHouse = wid.IsIkandiClient == "1" ? "Ikandi" : "BIPL";
                    actionLink.Text = "<span style='color:#000'>" + lblStatusMode.Text + " <b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + "  " + hidept.Value + "</b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b></span>";
                    lbltext.Text = "";
                }
            }
            string styleCode = string.Empty;
            if (hdnFitStyleCodeVersion.Value != string.Empty)
            {
                styleCode = hdnFitStyleCodeVersion.Value;
            }
            else
            {
                styleCode = hdnStyleCode.Value.PadLeft(5, '0');
            }

            if (wid.WorkflowInstance.AdditionalTask == null)
            {

                switch ((TaskMode)Convert.ToInt32(hdnStatusModeID.Value))
                {
                    case TaskMode.COSTING_BIPL:
                    case TaskMode.PRICE_QUOTED_BIPL:
                        // ************** Commented on 5 July 2021 ********************
                        //actionLink.Text = "";
                        // ************************* End ******************************
                        //lbltext.Text = "";
                        //lbltext.Text = lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + "  " + hidept.Value + "</b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + " " + wid.User_Narration + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumberDesc + "&SingleVersion=1";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Open_Costing:
                        // lbltext.Text = lblStatusMode.Text + " " + lblStyleNumber.Text + "</b>" + " Action By " + "<b style='text-transform:lowercase;'>" + Label3.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumberDesc + "&SingleVersion=1";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.COSTED_IKANDI:
                        if (actionLink.NavigateUrl.Contains('?'))
                        { actionLink.NavigateUrl = actionLink.NavigateUrl; }
                        else
                        {
                            lbltext.Text = "";
                            if (wid.WorkflowInstance.OrderDetailID == -1)
                                lbltext.Text = lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + "  " + hidept.Value + "</b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + " " + wid.User_Narration + "</b>";
                            else
                                lbltext.Text = "<span style='color:red;'>" + lblStatusMode.Text + " " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + "  " + hidept.Value + "</b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + wid.User_Narration + "</b>" + "</span>";
                            actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumberDesc + "&SingleVersion=1";
                            lnk.HRef = actionLink.NavigateUrl;
                        }

                        break;
                    case TaskMode.BIPL_AGREEMENT_BIPL:

                        lbltext.Text = "<span style='text-transform:capitalize !important'>A</span>greement pending for" + " <b>" + wid.WorkflowInstance.Style.StyleNumberDesc + "</b>" + " " + lblBuyer.Text + "  " + hidept.Value + " raised on " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumberDesc + "&SingleVersion=1";
                        lnk.HRef = actionLink.NavigateUrl;
                        actionLink.Visible = false;



                        break;

                    case TaskMode.NonAgreementTask:
                        lbltext.Text = "<span style='text-transform:capitalize !important;'>A</span>greement pending for" + " <b>" + wid.WorkflowInstance.Style.StyleNumberDesc + "</b>" + " " + lblBuyer.Text + "  " + hidept.Value + " raised on " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumberDesc + "&SingleVersion=1";
                        lnk.HRef = actionLink.NavigateUrl;
                        actionLink.Visible = false;
                        break;
                    case TaskMode.BIPL_AGREEMENT_Ikandi:
                        if (actionLink.NavigateUrl.Contains('?'))
                        { actionLink.NavigateUrl = actionLink.NavigateUrl; }
                        else
                        {

                            //lbltext.Text = "<span style='text-transform:capitalize !important'>A</span>greement pending for" + " " + wid.WorkflowInstance.Fit.StyleCode + "</b>" + " " + lblBuyer.Text + "  " + hidept.Value + "</b>" + " raised on " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            if (wid.WorkflowInstance.OrderDetailID != -1)
                                lbltext.Text = "<span style='text-transform:capitalize !important;'>A</span>greement pending for" + " <b>" + wid.WorkflowInstance.Style.StyleNumberDesc + "</b>" + " " + lblBuyer.Text + "  " + hidept.Value + " raised on " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            else

                                actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumberDesc + "&SingleVersion=1";
                            lnk.HRef = actionLink.NavigateUrl;
                            actionLink.Visible = false;

                        }

                        break;




                    case TaskMode.NEW_ORDER:
                    case TaskMode.ORDER_CONFIRMED_MERCHANT:
                    case TaskMode.ORDER_CONFIRMED_SALES:

                        lbltext.Text = "<span style='color:gray;'>" + " <span style='text-transform:capitalize !important'>P</span>laced on " +
                            hdnOrderDate.Value + "</span>"
                            + "<span style='color:black;'>" + "<b>" + " " + Label3.Text + " " + "</b>" + " " + "</span> " +
                            "<span style='color:gray;'>" + hidept.Value + "</span> " + "<span style='color:black;'>" + "<b>" + lblStyleNumber.Text + "</b>" + "</span> " + "<span style='color:gray;'>" + " for " + "</span> " + "<span style='color:black;'>" + "<b>" + lblQty.Text + " " + "pcs @" + "</b>" + " </span>" + " " + "<span style='color:black;'>" + "<b>" + hdnClinetCurrency.Value + " " + Math.Round(Convert.ToDouble(Biplprice.Value), 2).ToString() + "</b>" + "</span> " + "</span>" + "<span style='color:green; font-weight:bold'>" + " (" + "<span> &#x20b9;  </span>" + Convert.ToString(Math.Round(Convert.ToDouble(ValueInR.Value), 1)) + " Lac) </span> <span style='color:gray'>" + " for ex " + "<span style='color:black;'>" + "<b>" + hdnExfactory.Value + "</b>" + " </span>" + "</span> ";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString();
                        lnk.HRef = actionLink.NavigateUrl;
                        actionLink.Visible = false;
                        break;

                    case TaskMode.Reminder:

                    case TaskMode.Order_Agreement:
                    //case TaskMode.Photo_Shoots:
                    //case TaskMode.ORDER_CONFIRMED_MERCHANT:
                    case TaskMode.Create_Accessories:
                        // lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderID=" + wid.WorkflowInstance.Order.OrderID + "&TaskStatus=1"; //Gajendra 07-03-2016

                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Accessory_Approved:
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderID=" + wid.WorkflowInstance.Order.OrderID + "&TaskStatus=1"; //Gajendra 07-03-2016
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Fill_Accessories:
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString();
                        break;
                    case TaskMode.Limitation_Accessories:
                    case TaskMode.Limitation_Fabric:
                    case TaskMode.STC_UNALLOCATED_Fit_Merchant:
                    case TaskMode.STC_UNALLOCATED_Technol:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.PO_Upload:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Create_Fabric:
                        //    lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderID=" + wid.WorkflowInstance.Order.OrderID + "&TaskStatus=1"; //Gajendra 07-03-2016

                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Fabric_Approved:
                        // lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderID=" + wid.WorkflowInstance.Order.OrderID + "&TaskStatus=1"; //Gajendra 07-03-2016

                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Fill_Fabric:
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString();// + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID; Commented BY shub
                        break;
                    case TaskMode.Color_Print_REF_Received:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Fabric_Quality_Approved:
                        if (wid.CreateFabricTask == "16")
                        {
                            lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;color:red'>" + lblETA.Text + "</b>";

                        }
                        else
                        {
                            lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        }
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;

                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Acknowledgement_Fabric:

                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&IsUcknowledge=" + 1 + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;




                    case TaskMode.Acknowledgement_Costing:
                        actionLink.Text = "Costing Acknowledgement";
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumber + "&SingleVersion=1" + "&IsUcknowledge=" + 1;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;



                    case TaskMode.Create_OB:

                        if (OrderID == -1)
                            lbltext.Text = "<span style='text-transform:capitalize !important;'>P</span>re Order <b>" + lblStyleNumber.Text + "</b>," + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        else
                            lbltext.Text = "<span style='text-transform:capitalize !important;'>P</span>ost Order <b>" + lblStyleNumber.Text + "</b>," + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + hdnStyleID.Value + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&StyleCode=" + wid.WorkflowInstance.Style.StyleNumber + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&ShowOBForm=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.HO_PPM:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + hdnStyleID.Value + "&stylenumber=" + wid.WorkflowInstance.Fit.StyleCode + "&FitsStyle=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&showHOPPMFORM=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;


                    case TaskMode.FACTORY_PPM:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + " pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + hdnStyleID.Value + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&FitsStyle=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&showHOPPMFORM=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;




                    case TaskMode.Final_OB:
                        lbltext.Text = "<b>" + lblStyleNumber.Text + "</b>," + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + hdnStyleID.Value + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&StyleCode=" + wid.WorkflowInstance.Style.StyleNumber + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&ShowOBForm=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.TOP_Planned:
                        lbltext.Text = "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + hdnStyleID.Value + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&StyleCode=" + wid.WorkflowInstance.Style.StyleNumber + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&ShowFITSFORM=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;


                    case TaskMode.Buying_Sample:
                    case TaskMode.Sealed_To_Cut:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + hdnStyleID.Value + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&StyleCode=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&showFITSFORM=Yes";
                        actionLink.NavigateUrl = "/Admin/FitsSample/SamplingFitsCycleFlow.aspx" + "?styleid=" + hdnStyleID.Value;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Risk:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID + "&stylenumber=" + wid.WorkflowInstance.Fit.StyleCode + "&StyleCode=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&OrderId=" + wid.WorkflowInstance.Order.OrderID + "&showRiskFORM=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    //case TaskMode.Photo_Shoots:
                    //    lbltext.Text = "Photo shoots for " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " and For" + "<b>" + lblBuyer.Text + "</b>";
                    //    //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;//Gajendra 07-03-2016
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;
                    case TaskMode.Test_Report:

                        lbltext.Text = "<span style='text-transform:capitalize !important'>MANAGE ORDERS FILE T</span>est Report For " + "<b>" + lblBuyer.Text + "</b>" + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " OF order Qty " + "<b>" + lblQty.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;//Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Pattern_Sample_Received:
                        lbltext.Text = actionLink.Text = "<span style='color:#000'>" + actionLink.Text + " " + "<span style='text-transform:capitalize !important'>P</span>attern Sample Received " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " and For " + "<b>" + lblBuyer.Text + "</b></span>";
                        lbltext.Text = "";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;//Gajendra 07-03-2016
                        // actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Production_File:
                        actionLink.Text = "<span style='color:#000'>" + actionLink.Text + " " + "<span style='text-transform:capitalize !important'>P</span>roduction File  for " + "<b>" + lblBuyer.Text + "</b>" + " " + "(" + wid.WorkflowInstance.Order.SerialNumber + ")</span>";
                        lbltext.Text = "";
                        // lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>roduction File  for " + "<b>" + lblBuyer.Text + "</b>" + " " + "(" + wid.WorkflowInstance.Order.SerialNumber + ")";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;//Gajendra 07-03-2016
                        //  actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;


                    case TaskMode.SAMPLING_ACHIEVED:
                        if (OrderID == -1)
                            // lbltext.Text = "SAMPLING_ACHIEVED File  for " + wid.WorkflowInstance.Style.ClientID + " and For" + wid.WorkflowInstance.Style.StyleNumber;
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>re Order VeriFy Costing <b> " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        else
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order VeriFy Costing <b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?sn=" + wid.WorkflowInstance.Style.StyleNumberDesc;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;


                    case TaskMode.TOP_Sent:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + hdnStyleID.Value + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&StyleCode=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&showFITSFORM=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Fits_SampleSent:
                        if (OrderID == -1)
                        {
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>re Order " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            actionLink.NavigateUrl = "/admin/FitsSample/frmPreorder_SamplingCycle.aspx?styleid=" + wid.WorkflowInstance.Style.StyleID + "&RequestStatus=" + wid.StatusMode;
                            lnk.HRef = actionLink.NavigateUrl;
                            break;
                        }
                        else
                        {
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID + "&TaskStatus=" + "Fits_SampleSent";
                            lnk.HRef = actionLink.NavigateUrl;
                            break;
                        }
                    //actionLink.NavigateUrl = actionLink.NavigateUrl;

                    case TaskMode.SampleSentAfterSTC:

                        lbltext.Text = "<span style='text-transform:capitalize !important'>S</span>ample Sent After STC " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";

                        //actionLink.NavigateUrl = actionLink.NavigateUrl;
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Pattern_Ready:
                        if (OrderID == -1)
                        {
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>re Order Pattern Ready for " + wid.StatusMode + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            actionLink.NavigateUrl = "/admin/FitsSample/frmPreorder_SamplingCycle.aspx?styleid=" + wid.WorkflowInstance.Style.StyleID + "&RequestStatus=" + wid.StatusMode;
                            lnk.HRef = actionLink.NavigateUrl;
                            break;
                        }
                        else
                        {
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order Pattern Ready " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID + "&TaskStatus=" + "PatternReady";
                            lnk.HRef = actionLink.NavigateUrl;
                            break;
                        }

                    //actionLink.NavigateUrl = actionLink.NavigateUrl;


                    case TaskMode.PatternReadyAfterSTC:
                        lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>attern Ready After STC " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl;
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.HandOver:
                        if (OrderID != -1)
                        {
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order HandOver " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID + "&TaskStatus=" + "Handover";
                            lnk.HRef = actionLink.NavigateUrl;
                            break;
                        }
                        else
                        {
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>re Order HandOver For " + wid.StatusMode + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            actionLink.NavigateUrl = "/admin/FitsSample/frmPreorder_SamplingCycle.aspx?styleid=" + wid.WorkflowInstance.Style.StyleID + "&RequestStatus=" + wid.StatusMode;
                            lnk.HRef = actionLink.NavigateUrl;
                            break;
                        }
                    //case TaskMode.HandOver:
                    //    if (OrderID != -1)
                    //        lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order HandOver " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                    //    else
                    //        lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>re Order HandOver " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";  




                    case TaskMode.DIGITAL_UPLOADED:
                        lbltext.Text = "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.FitsCommentes_Upload:
                        if (OrderID != -1)
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order Fit Commentes Upload " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        else
                            lbltext.Text = "<span style='text-transform:capitalize !important'>P</span>re Order Fit Commentes Upload " + " " + "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " </b>" + " By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";




                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?styleid=" + wid.WorkflowInstance.Style.StyleID + "&TaskStatus=" + "FitsStatus";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    //case TaskMode.Fabric_BIH:
                    //    lbltext.Text = "Fabirc  BIH for " + "<b>" + lblBuyer.Text + "</b>" + " and For" + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;
                    case TaskMode.Cutting_Sheet:
                        //lbltext.Text = "<span style='text-transform:capitalize !important'>C</span>utting Sheet " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " and for" + "<b>" + lblBuyer.Text + "</b>";
                        actionLink.Text = "<span style='color:#000'>" + actionLink.Text + " " + "<span style='text-transform:capitalize !important'> C</span>utting Sheet " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " and for " + "<b>" + lblBuyer.Text + "</b></span>";
                        lbltext.Text = "";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.CD_Chart:
                        lbltext.Text = "<span style='text-transform:capitalize !important'>C</span>D Chart for " + "<b>" + lblBuyer.Text + "</b>" + " and for " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " " + "Of order Qty." + " with " + "<b>" + lblQty.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    //case TaskMode.Accessory_BIH:
                    //    lbltext.Text = " Accessory BIH for " + "<b>" + lblBuyer.Text + "</b>" + " and for" + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;
                    case TaskMode.EXFACTORY_PLANNED:

                        //lbltext.Text = "EXFACTORY PLANNED for " + wid.WorkflowInstance.Style.ClientID + " and For" + wid.WorkflowInstance.Style.StyleNumber;
                        lbltext.Text = "<b> " + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b>" + "<b> " + hidept.Value + "</b>" + " On " + "<b>" + Contract.Text + "/" + LineItemNumber.Text + " with " + lblQty.Text + "</b>" + " pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    //case TaskMode.EXFACTORIED:
                    //    lbltext.Text = "EXFACTORIED for " + "<b>" + lblBuyer.Text + "</b>" + " and For " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + " " + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;
                    //case TaskMode.UNDER_CLEARANCE_FLAT:
                    //    lbltext.Text = "UNDER CLEARANCE (FLAT) for " + "<b>" + lblBuyer.Text + "</b>" + " and For " + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;

                    //case TaskMode.UNDER_CLEARENCE_HANGING:
                    //    lbltext.Text = "UNDER CLEARANCE (HANGING) for " + "<b>" + lblBuyer.Text + "</b>" + " and For " + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;

                    //case TaskMode.UNDER_CLEARENCE:
                    //    lbltext.Text = "UNDER CLEARANCE for " + "<b>" + lblBuyer.Text + "</b>" + " and For " + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;

                    //case TaskMode.DELIVERED:
                    //lbltext.Text = "<b>" + lblBuyer.Text + "</b>" + " and For " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + " " + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                    //actionLink.NavigateUrl = actionLink.NavigateUrl ;
                    //lnk.HRef = actionLink.NavigateUrl;
                    //break;

                    //case TaskMode.HO_PPM:
                    case TaskMode.INLINE_CUT:
                    case TaskMode.Cutting:
                    case TaskMode.Stitching:
                    case TaskMode.Finishing:

                        if (wid.FactorySpecification != 1)
                        {
                            lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " <b>" + " Which Was " + "<b>" + lblFitsStatus.Text + "</b>" + "<b>" + lblQty.Text + "</b>" + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                            actionLink.NavigateUrl = "/Internal/OrderProcessing/frmMO.aspx" + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                            lnk.HRef = actionLink.NavigateUrl;
                        }
                        break;


                    //case TaskMode.Approved_To_EX_Fact_QA_Pending:
                    case TaskMode.Approved_To_EX_CLT_QA_Pending:
                    case TaskMode.Approved_To_EX_Approval_QA:
                    // case TaskMode.Approved_To_EX_Shipping:
                    case TaskMode.Approved_toEx:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " On " + "<b>" + Contract.Text + "/" + LineItemNumber.Text + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + "pcs By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&FitsStyle=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Final_Inspection:
                        lbltext.Text = "<b>: <span style='text-transform:capitalize !important'>F</span>inal inspection " + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " On " + "<b>" + Contract.Text + "/" + LineItemNumber.Text + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " pcs By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString() + "&InspectionQId=" + 3;
                        // actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString() + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&FitsStyle=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&InspectionQId=" + 3;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Line_Plan:
                    case TaskMode.Photo_Shoots:
                    case TaskMode.Accessory_BIH:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Fabric_BIH:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Bulk_Approval:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.DebitNote_Task:
                        lbltext.Text = "<span style='text-transform:capitalize !important'>PO No:</span> " + "<b>" + lblBuyer.Text + "</b>" + " of " + "<b>" + Label3.Text + "(" + hidept.Value + ")" + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        // actionLink.NavigateUrl = actionLink.NavigateUrl + "?SupplierPO=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.ACC_DebitNote_Task:
                        lbltext.Text = "<span style='text-transform:capitalize !important'>PO No:</span> " + "<b>" + lblBuyer.Text + "</b>" + " of " + "<b>" + Label3.Text + "(" + hidept.Value + ")" + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        // actionLink.NavigateUrl = actionLink.NavigateUrl + "?SupplierPO=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.CreditNote_Task:
                        lbltext.Text = "<span style='text-transform:capitalize !important'>PO No:</span> " + "<b>" + lblBuyer.Text + "</b>" + " of " + "<b>" + Label3.Text + "(" + hidept.Value + ")" + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        // actionLink.NavigateUrl = actionLink.NavigateUrl + "?SupplierPO=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.ACC_CreditNote_Task:
                        lbltext.Text = "<span style='text-transform:capitalize !important'>Credit Note Task for</span> " + "<b>" + lblBuyer.Text + "</b>" + " and ETA " + "<b>" + lblETA.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?SupplierPO=" + wid.WorkflowInstance.OrderDetailID + "&CreditNote=Yes";
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Cancel_Order_With_Liability_Task:
                        lbltext.Text = "<span style='text-transform:capitalize !important'></span> " + "<b>" + lblBuyer.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?SupplierPoId=" + hdnUserTaskName.Value + "&OrderDetailId=" + +wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.BIPL_Global_Daily_IE_Entry:
                        lbltext.Text = "<span style='text-transform:capitalize !important'></span> " + "<b>" + lblBuyer.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Order_Open:
                        string BuyingHouse = wid.IsIkandiClient == "1" ? "Ikandi" : "BIPL";
                        //lbltext.Text = "<span style='text-transform:capitalize !important'></span> " + "<b>" +lblBuyer.Text  + "</b>";
                        lbltext.Text = "<span style='text-transform:capitalize !important'></span> " + "<b>" + BuyingHouse + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Cancel_Order_ACC_With_Liability_Task:
                        lbltext.Text = "<span style='text-transform:capitalize !important'></span> " + "<b>" + lblBuyer.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?ClientID=" + wid.WorkflowInstance.Style.ClientID + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber; //Gajendra 07-03-2016
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?PoNumber=" + lblBuyer.Text + "&OrderDetails=" + +wid.WorkflowInstance.OrderDetailID + "&Qty=" + lblQty.Text;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.Initial_Approval:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + "</b> " + "<b>" + hidept.Value + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " " + "pcs  By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    //case TaskMode.BIPL_INVOICED:
                    //case TaskMode.iKandi_Invoiced:
                    case TaskMode.DELIVERED:
                    case TaskMode.Consolidated:
                        lbltext.Text = "<b>: <span style='text-transform:capitalize !important'></span>Consolidated " + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " On " + "<b>" + Contract.Text + "/" + LineItemNumber.Text + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + " pcs By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?Flag=CONSOLIDATION" + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString();
                        // actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString() + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&FitsStyle=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&InspectionQId=" + 3;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.UNDER_CLEARANCE_FLAT:
                    case TaskMode.UNDER_CLEARENCE_HANGING:
                    case TaskMode.UNDER_CLEARENCE:
                    case TaskMode.EXFACTORIED:
                    case TaskMode.Approved_To_EX_Shipping:
                        lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " On " + "<b>" + Contract.Text + "/" + LineItemNumber.Text + "</b>" + " with " + "<b>" + lblQty.Text + "</b>" + "pcs By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";
                        //actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString() + "&InspectionQId=" + 3;
                        actionLink.NavigateUrl = actionLink.NavigateUrl + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                        // actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString() + "&stylenumber=" + wid.WorkflowInstance.Style.StyleNumber + "&FitsStyle=" + wid.WorkflowInstance.Fit.StyleCode + "&ClientID=" + wid.WorkflowInstance.Style.ClientID + "&DeptId=" + wid.WorkflowInstance.Style.DepartmentID + "&InspectionQId=" + 3;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    //case TaskMode.Bulk_Approval:
                    ////case TaskMode.Initial_Approval:
                    //    lbltext.Text = "<b>" + lblStyleNumber.Text + "</b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + "</b>" + " By " + "<b>" + lblETA.Text + "</b>";
                    //    actionLink.NavigateUrl = actionLink.NavigateUrl + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID; ;
                    //    lnk.HRef = actionLink.NavigateUrl;
                    //    break;

                    case TaskMode.INVOICED:
                        if (wid.IsIkandiClient == "1")
                        {
                            //actionLink.NavigateUrl = "/Internal/OrderProcessing/ManageOrders.aspx" + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation == iKandi.Common.Designation.BIPL_Logistict_Accountant)
                            {
                                lbltext.Text = "BIPL INVOICE for " + "<b>" + lblBuyer.Text + "</b>" + " " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " " + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";


                                actionLink.NavigateUrl = "/Internal/Delivery/frmMainDeliveryScreen.aspx" + "?Flag=INVOICED" + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString();
                                lnk.HRef = actionLink.NavigateUrl;
                            }
                            else if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation == iKandi.Common.Designation.iKandi_FinanceLogistics_Accountant)
                            {
                                lbltext.Text = "IKANDI INVOICE for " + "<b>" + lblBuyer.Text + "</b>" + " " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " " + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                                actionLink.NavigateUrl = "/Internal/Delivery/frmMainDeliveryScreen.aspx" + "?Flag=INVOICED" + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString();
                                lnk.HRef = actionLink.NavigateUrl;
                            }
                        }
                        else if (wid.IsIkandiClient == "0")
                        {
                            lbltext.Text = "BIPL INVOICE for " + "<b>" + lblBuyer.Text + "</b>" + " " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b>" + " " + "<b>" + wid.WorkflowInstance.Style.StyleNumber + "</b>";
                            actionLink.NavigateUrl = "/Internal/Delivery/frmMainDeliveryScreen.aspx" + "?Flag=INVOICED" + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&orderid=" + hdnOrderID.Value.ToString();
                            lnk.HRef = actionLink.NavigateUrl;
                        }
                        break;
                    case TaskMode.Inline_Inspection:
                    case TaskMode.Mid_Inspection:
                    case TaskMode.Online_Inspection:
                        int InspectionId = -1;
                        if (wid.StatusModeID == 201)
                            InspectionId = 1;
                        if (wid.StatusModeID == 202)
                            InspectionId = 2;
                        if (wid.StatusModeID == 203)
                            InspectionId = 3;
                        if (wid.StatusModeID == 204)
                            InspectionId = 4;
                        //lbltext.Text = "<b>" + wid.StatusMode + "</b> " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b> " + "<b>" + lblStyleNumber.Text + " of " + wid.WorkflowInstance.Order.TotalQuantity + "</b> Pcs" + " By " + "<b>" + lblETA.Text + "</b>";
                        lbltext.Text = "<b>" + wid.StatusMode + "</b> " + "<b>" + wid.WorkflowInstance.Order.SerialNumber + "</b> " + "<b>" + lblStyleNumber.Text + "</b> " + " for " + "<b>" + lblBuyer.Text + "</b> " + " On " + "<b>" + Contract.Text + "/" + LineItemNumber.Text + "</b>" + " with " + "<b>" + wid.WorkflowInstance.Order.TotalQuantity + "</b>" + " pcs By " + "<b style='text-transform:lowercase;'>" + lblETA.Text + "</b>";

                        actionLink.NavigateUrl = "/Internal/Merchandising/QC.aspx" + "?orderid=" + hdnOrderID.Value.ToString() + "&OrderDetailID=" + wid.WorkflowInstance.OrderDetailID + "&InspectionQId=" + InspectionId;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;

                    case TaskMode.ProductionPlanning:
                        lbltext.Text = "<b>" + lblStyleNumber.Text + "</b> " + "<b> " + wid.WorkflowInstance.Order.SerialNumber + "</b> " + "<b>" + Contract.Text + "</b> Planned  End Date <b>" + wid.ETA.ToString("dd-MM-yy") + "</b> ExFactory <b>" + wid.ExFactory.ToString("dd-MM-yy") + "</b>";
                        actionLink.NavigateUrl = "/Internal/OrderProcessing/frmMO.aspx" + "?OrderDetailId=" + wid.WorkflowInstance.OrderDetailID;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Cut_Avg:
                        lbltext.Text = "<b>" + lblStyleNumber.Text + "</b> " + "<b> " + wid.WorkflowInstance.Order.SerialNumber + "</b> " + "<b>" + Contract.Text + "</b> ETA Date <b>" + wid.ETA.ToString("dd-MM-yy") + "</b> ExFactory <b>" + wid.ExFactory.ToString("dd-MM-yy") + "</b>";
                        actionLink.NavigateUrl = "/Internal/OrderProcessing/frmMO.aspx" + "?ClientID=" + hdnCliID.Value + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Value_Addition_Entry:
                        lbltext.Text = "<b>" + Label3.Text + "</b> " + "for Order Qty <b>" + lblQty.Text + "</b> ETA Date <b>" + wid.ETA.ToString("dd-MM-yy") + "</b> ExFactory <b>" + wid.ExFactory.ToString("dd-MM-yy") + "</b>";
                        //actionLink.NavigateUrl = "/Internal/OrderProcessing/ManageOrders.aspx" + "?ClientID=" + hdnCliID.Value + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Value_Addition_PO:
                        // lbltext.Text = "<b>" + lblBuyer.Text + "</b> " + "for " + hidept.Value;
                        //actionLink.NavigateUrl = "/Internal/OrderProcessing/ManageOrders.aspx" + "?ClientID=" + hdnCliID.Value + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Stitch_OutHouse_PO:
                        //lbltext.Text = "<b>" + lblBuyer.Text + "</b> " + "for " + hidept.Value;
                        //actionLink.NavigateUrl = "/Internal/OrderProcessing/ManageOrders.aspx" + "?ClientID=" + hdnCliID.Value + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Venor_Stitch_OutHouse_PO:
                        //lbltext.Text = "<b>" + lblBuyer.Text + "</b> " + "for " + hidept.Value;
                        //actionLink.NavigateUrl = "/Internal/OrderProcessing/ManageOrders.aspx" + "?ClientID=" + hdnCliID.Value + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    case TaskMode.Vendor_Value_Addition_PO:
                        // lbltext.Text = "<b>" + lblBuyer.Text + "</b> " + "for " + hidept.Value;
                        //actionLink.NavigateUrl = "/Internal/OrderProcessing/ManageOrders.aspx" + "?ClientID=" + hdnCliID.Value + "&SerialNumber=" + wid.WorkflowInstance.Order.SerialNumber;
                        lnk.HRef = actionLink.NavigateUrl;
                        break;
                    default:
                        break;
                }

                //if ((TaskMode)Convert.ToInt32(hdnStatusModeID.Value) == TaskMode.COSTEDBIPL)
                //    lblCourierSentOn.Visible = true;
                //else
                //    lblCourierSentOn.Visible = false;
            }
            flag_masterload = flag_masterload + 1;
        }


        protected void gvProductionTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int UnitId = -1;
            int SlotId = -1;
            int FactoryClassification = -1;
            string TaskDate = "";
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (TaskId == 87)
                {
                    e.Row.Cells[0].ColumnSpan = 4;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[0].Text = "List";
                    //e.Row.Visible = false;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnUnitId = e.Row.FindControl("hdnUnitId") as HiddenField;
                HiddenField hdnSlotId = e.Row.FindControl("hdnSlotId") as HiddenField;
                HyperLink actionLink = e.Row.FindControl("lnkAction") as HyperLink;
                Label lblTaskDate = e.Row.FindControl("lblTaskDate") as Label;
                HiddenField hdnFactoryClassification = e.Row.FindControl("hdnFactoryClassification") as HiddenField;

                if (hdnUnitId != null)
                    UnitId = Convert.ToInt32(hdnUnitId.Value);
                if (hdnSlotId != null)
                    SlotId = Convert.ToInt32(hdnSlotId.Value);
                if (hdnFactoryClassification != null)
                    FactoryClassification = Convert.ToInt16(hdnFactoryClassification.Value);
                if (lblTaskDate.Text != "")
                {
                    DateTime dtTaskDate = DateHelper.ParseDate(lblTaskDate.Text).Value;
                    TaskDate = dtTaskDate.ToString("dd/MM/yyyy");
                }

                ProductionController objProductionController = new ProductionController();

                if (TaskId == 84)
                {
                    actionLink.Text = "Cutting Daily Entry";
                    if (FactoryClassification == 1)
                    {
                        actionLink.NavigateUrl = "/Internal/Production/IECuttingSlotEntry.aspx?ProductionUnit=" + UnitId.ToString() + "&StartDate=" + TaskDate;
                    }

                }
                if (TaskId == 85)
                {
                    actionLink.Text = "Daily Line Plan";
                    actionLink.NavigateUrl = "/Admin/FactorySpecificLinePlanning.aspx?ProductionUnit=" + UnitId.ToString() + "&StartDate=" + TaskDate + "&Enabled=false";
                }
                if (TaskId == 86)
                {
                    actionLink.Text = "Slot wise Stitch/Finish";
                    if (FactoryClassification == 1)
                    {
                        actionLink.NavigateUrl = "/Internal/Production/frmIEStichedSlotEntry.aspx?ProductionUnit=" + UnitId.ToString() + "&SlotId=" + SlotId.ToString() + "&StartDate=" + TaskDate;
                    }
                }
                if (TaskId == 87)
                {
                    e.Row.Cells[0].ColumnSpan = 4;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    string SerialNumber = DataBinder.Eval(e.Row.DataItem, "SerialNumber").ToString();
                    int OrderDetailId = DataBinder.Eval(e.Row.DataItem, "OrderDetailID") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderDetailID"));
                    actionLink.Text = "<span style='text-transform:capitalize !important'>F</span>inishing Task from Out house to InHouse for <b>" + SerialNumber + "</b>";
                    actionLink.NavigateUrl = "/Internal/OrderProcessing/frmMO.aspx" + "?OrderDetailId=" + OrderDetailId;

                    //lbltext.Text = "<b>" + Label3.Text + " " + lblStyleNumber.Text + " </b>" + " for " + "<b>" + lblBuyer.Text + " " + hidept.Value + " <b>" + " Which Was " + "<b>" + lblFitsStatus.Text + "</b>" + "<b>" + lblQty.Text + "</b>" + "pcs  By " + "<b>" + lblETA.Text + "</b>";
                }
                if (TaskId == 88)
                {
                    actionLink.Text = "Slot wise Stitch Loss Share";
                    if (FactoryClassification == 1)
                    {
                        actionLink.NavigateUrl = "/Internal/Production/frmFactoryIEStitchedSlotEntry.aspx?ProductionUnit=" + UnitId.ToString() + "&SlotId=" + SlotId.ToString() + "&StartDate=" + TaskDate;
                    }
                }
            }
        }

        //protected void grdNotiFication_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblhour = (Label)e.Row.FindControl("lblhour");
        //        Label lblmsg = (Label)e.Row.FindControl("lblmsg");
        //        HiddenField hdnStyleid = (HiddenField)e.Row.FindControl("hdnStyleid");
        //        HiddenField hdnOrderID = (HiddenField)e.Row.FindControl("hdnOrderID");
        //        HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
        //        HtmlAnchor anch = (HtmlAnchor)e.Row.FindControl("hlProject");
        //        HiddenField hdnNotificationEmailHistoryID = (HiddenField)e.Row.FindControl("hdnNotificationEmailHistoryID");
        //        HiddenField hdnIsGrouped = (HiddenField)e.Row.FindControl("hdnIsGrouped");
        //        HiddenField hdnStylenumber = (HiddenField)e.Row.FindControl("hdnStylenumber");
        //        HiddenField hdnClientid = (HiddenField)e.Row.FindControl("Clientid");
        //        HiddenField hdnserialno = (HiddenField)e.Row.FindControl("hdnserialno");
        //        HiddenField hdnisread = (HiddenField)e.Row.FindControl("hdnisread");
        //        if (hdnisread.Value == "1")
        //        {
        //            anch.Attributes.Add("style", "color:Gray");
        //            lblmsg.ForeColor = System.Drawing.Color.Gray;
        //        }

        //        if (hdnIsGrouped.Value == "0")
        //        {
        //            anch.Visible = true;
        //            lblmsg.Visible = false;
        //        }


        //        if ((TaskId == 4))
        //        {


        //            anch.HRef = "/Internal/Sales/CostingSheet.aspx?sn=" + hdnStylenumber.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

        //            // anch.HRef = "/Internal/Sales/Order.aspx?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

        //        }


        //        if ((TaskId == 6) || (TaskId == 7) || (TaskId == 15) || (TaskId == 16))
        //        {




        //            anch.HRef = "/Internal/Sales/Order.aspx?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

        //        }

        //        if ((TaskId == 14))
        //        {




        //            anch.HRef = "/Internal/Fabric/FabricWorkingSheet.aspx?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

        //        }

        //        if ((TaskId == 13))
        //        {




        //            anch.HRef = "/Internal/Fabric/FabricAccessoriesWorkSheet.aspx?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

        //        }


        //        if (TaskId == 9)
        //        {
        //            anch.HRef = "/Internal/Delivery/OrderProductionPlanning.aspx?ClientID=" + hdnClientid.Value + "&SerialNumber=" + hdnserialno.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;
        //        }


        //    }
        //}


        protected void grdNotiFication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblhour = (Label)e.Row.FindControl("lblhour");
                Label lblmsg = (Label)e.Row.FindControl("lblmsg");
                HiddenField hdnStyleid = (HiddenField)e.Row.FindControl("hdnStyleid");
                HiddenField hdnOrderID = (HiddenField)e.Row.FindControl("hdnOrderID");
                HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
                HtmlAnchor anch = (HtmlAnchor)e.Row.FindControl("hlProject");
                HiddenField hdnNotificationEmailHistoryID = (HiddenField)e.Row.FindControl("hdnNotificationEmailHistoryID");
                HiddenField hdnIsGrouped = (HiddenField)e.Row.FindControl("hdnIsGrouped");
                HiddenField hdnStylenumber = (HiddenField)e.Row.FindControl("hdnStylenumber");
                HiddenField hdnClientid = (HiddenField)e.Row.FindControl("Clientid");
                HiddenField hdnserialno = (HiddenField)e.Row.FindControl("hdnserialno");
                HiddenField hdnisread = (HiddenField)e.Row.FindControl("hdnisread");
                HiddenField hdnurl = (HiddenField)e.Row.FindControl("hdnurl");
                HiddenField hdnSerialNumber = (HiddenField)e.Row.FindControl("hdnSerialNumber");
                HiddenField hdnclintid = (HiddenField)e.Row.FindControl("hdnclintid");
                HiddenField hdnDeptid = (HiddenField)e.Row.FindControl("hdnDeptid");

                if (hdnisread.Value == "1")
                {
                    anch.Attributes.Add("style", "color:Gray");
                    lblmsg.ForeColor = System.Drawing.Color.Gray;
                }

                if (hdnIsGrouped.Value == "0")
                {
                    anch.Visible = true;
                    lblmsg.Visible = false;
                }


                if ((TaskId == 4))
                {


                    anch.HRef = hdnurl.Value + "?sn=" + hdnStylenumber.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

                    // anch.HRef = "/Internal/Sales/Order.aspx?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

                }


                if ((TaskId == 6) || (TaskId == 7) || (TaskId == 15) || (TaskId == 16))
                {




                    anch.HRef = hdnurl.Value + "?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

                }

                if ((TaskId == 14))
                {




                    anch.HRef = hdnurl.Value + "?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

                }

                if ((TaskId == 12))
                {
                    anch.HRef = hdnurl.Value + "?orderDetailID=" + hdnOrderDetailsID.Value + "&styleid" + hdnStyleid.Value + "&stylenumber=" + hdnStylenumber.Value + "&FitsStyle=" + hdnStylenumber.Value + "&ClientID=" + hdnclintid + "&DeptId" + hdnDeptid.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value + "&showHOPPMFORM=Yes";
                }


                if ((TaskId == 17) || (TaskId == 18) || (TaskId == 19))
                {
                    string stylecode = "";
                    string[] Split = hdnStylenumber.Value.Split(' ');
                    if (Split.Length > 2)
                    {
                        stylecode = Split[1].ToString();
                    }
                    else
                    {
                        stylecode = Split[1].ToString();
                    }

                    anch.HRef = hdnurl.Value + "?styleid=" + hdnStyleid.Value + "&stylenumber=" + hdnStylenumber.Value + "&StyleCode=" + stylecode + "&ClientID=" + hdnclintid.Value + "&DeptId=" + hdnDeptid.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value + "&showFITSFORM=Yes";
                }


                if ((TaskId == 13))
                {

                    anch.HRef = hdnurl.Value + "?Orderid=" + hdnOrderID.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

                }


                if ((TaskId == 20))
                {

                    anch.HRef = hdnurl.Value + "?ClientID=" + hdnclintid.Value + "&SerialNumber=" + hdnSerialNumber.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;

                }

                if (TaskId == 9)
                {
                    anch.HRef = hdnurl.Value + "?ClientID=" + hdnClientid.Value + "&SerialNumber=" + hdnserialno.Value + "&Emailid=" + hdnNotificationEmailHistoryID.Value;
                }


            }
        }

        protected void Grdnotificatontask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField Stusname = (HiddenField)e.Row.FindControl("status_modename");
                HiddenField StatusModeID = (HiddenField)e.Row.FindControl("StatusModeID");
                HiddenField StyleNumber = (HiddenField)e.Row.FindControl("StyleNumber");
                HiddenField SerialNumber = (HiddenField)e.Row.FindControl("SerialNumber");
                HiddenField ClosedDate = (HiddenField)e.Row.FindControl("ClosedDate");
                string TaskClosed;


                HiddenField CompanyName = (HiddenField)e.Row.FindControl("CompanyName");

                HiddenField DepartmentName = (HiddenField)e.Row.FindControl("DepartmentName");
                HiddenField ContractNumber = (HiddenField)e.Row.FindControl("ContractNumber");
                HiddenField LineItemNumber = (HiddenField)e.Row.FindControl("LineItemNumber");
                Label lblhour = (Label)e.Row.FindControl("lblhour");


                HiddenField Quantity = (HiddenField)e.Row.FindControl("Quantity");
                HiddenField BIPLPrice = (HiddenField)e.Row.FindControl("BIPLPrice");
                HiddenField Url = (HiddenField)e.Row.FindControl("Url");
                HiddenField hdninr = (HiddenField)e.Row.FindControl("hdninr");

                TaskClosed = Convert.ToDateTime(ClosedDate.Value).ToString("dd MMM");
                //TaskClosed=(Convert.ToDateTime(ClosedDate.Value) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(ClosedDate.Value)).ToString("dd MMM");
                //TaskClosed = ClosedDate.Value != "" ? DateTime.ParseExact(ClosedDate.Value, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;


                Url = (HiddenField)e.Row.FindControl("Url");
                Label lblmsg = (Label)e.Row.FindControl("lblmsg");
                Image img = (Image)e.Row.FindControl("img");
                String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["style.folder"];
                ////img.ImageUrl = ProductionFolderPath + Url.Value;
                //img.ImageUrl = "~/" + System.Configuration.ConfigurationManager.AppSettings["style.folder"] + System.Configuration.ConfigurationManager.AppSettings["image.prefix"] + Url.Value;
                img.ImageUrl = "/uploads/style/thumb-" + Url.Value;
                switch ((TaskMode)Convert.ToInt32(StatusModeID.Value))
                {
                    case TaskMode.COSTING_BIPL:


                    case TaskMode.PRICE_QUOTED_BIPL:
                    case TaskMode.COSTED_IKANDI:
                    case TaskMode.BIPL_AGREEMENT_BIPL:
                    case TaskMode.BIPL_AGREEMENT_Ikandi:
                    case TaskMode.SAMPLE_SENT:
                    case TaskMode.DIGITAL_UPLOADED:

                        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        break;

                    case TaskMode.STYLE_CREATED:
                        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        break;

                    case TaskMode.HandOver:

                        if (SerialNumber.Value == null)
                            lblmsg.Text = "<span style='text-transform:capitalize !important'>P</span>re Order <b>" + Stusname.Value + " on </b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        else
                            lblmsg.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order <b>" + Stusname.Value + " on </b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        lblhour.Visible = true;
                        img.Visible = true;
                        break;

                    case TaskMode.Pattern_Ready:
                        if (SerialNumber.Value == null)
                            lblmsg.Text = "<span style='text-transform:capitalize !important'>P</span>re Order <b>" + Stusname.Value + " on </b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        else
                            lblmsg.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order <b>" + Stusname.Value + " on </b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        lblhour.Visible = true;
                        img.Visible = true;
                        break;

                    case TaskMode.Fits_SampleSent:
                        if (SerialNumber.Value == null)
                            lblmsg.Text = "Pre Order <b>" + Stusname.Value + " on </b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        else
                            lblmsg.Text = "Post Order <b>" + Stusname.Value + " on </b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        lblhour.Visible = true;
                        img.Visible = true;
                        break;

                    case TaskMode.SAMPLING_ACHIEVED:
                        if (SerialNumber.Value == null)
                            lblmsg.Text = "<span style='text-transform:capitalize !important'>P</span>re Order <b>" + Stusname.Value + " on </b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        else
                            lblmsg.Text = "<span style='text-transform:capitalize !important'>P</span>ost Order <b>" + Stusname.Value + " on</b>" + TaskClosed + "<b>" + " " + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>";
                        lblhour.Visible = true;
                        img.Visible = true;
                        break;

                    case TaskMode.NEW_ORDER:
                    case TaskMode.ORDER_CONFIRMED_SALES:
                    case TaskMode.Fabric_Approved:
                        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " " + "<b>" + CompanyName.Value + "</b>" + " for " + "<b>" + DepartmentName.Value + "</b>" + " on " + "<b>" + StyleNumber.Value + "</b>" + " with " + " " + "<b>" + Quantity.Value + "</b>" + " Pcs @" + " " + "<b>" + BIPLPrice.Value + "</b>" + "<span> &#x20b9;  </span>" + "<b>" + hdninr.Value + "</b>";
                        break;

                    case TaskMode.Create_OB:
                    case TaskMode.Final_OB:
                    case TaskMode.Risk:
                    case TaskMode.Create_Fabric:

                    case TaskMode.Create_Accessories:
                    case TaskMode.Accessory_Approved:
                    case TaskMode.Fill_Fabric:
                    case TaskMode.Fill_Accessories:
                    case TaskMode.Limitation_Fabric:


                    case TaskMode.Limitation_Accessories:
                    case TaskMode.STC_UNALLOCATED_Fit_Merchant:
                    case TaskMode.STC_UNALLOCATED_Technol:
                        // case TaskMode.ALLOCATED:
                        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + " with " + "<b>" + Quantity.Value + "</b>" + " " + "pcs";
                        break;

                    case TaskMode.INLINE_CUT:
                    case TaskMode.HO_PPM:
                    case TaskMode.Cutting:
                    case TaskMode.Stitching:
                    case TaskMode.Finishing:
                        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + " with " + "<b>" + Quantity.Value + "</b>" + " " + "pcs";
                        break;

                    case TaskMode.EXFACTORY_PLANNED:
                    case TaskMode.Approved_To_EX_Approval_QA:
                    case TaskMode.Approved_To_EX_CLT_QA_Pending:
                    case TaskMode.Approved_To_EX_Fact_QA_Pending:
                    case TaskMode.Approved_To_EX_Shipping:
                    case TaskMode.PART_EX_FACTORIED:
                    case TaskMode.UNDER_CLEARENCE_HANGING:
                    case TaskMode.UNDER_CLEARANCE_FLAT:
                    case TaskMode.Consolidated:
                    case TaskMode.DELIVERED:
                    case TaskMode.BIPL_INVOICED:
                    case TaskMode.iKandi_Invoiced:
                    case TaskMode.Buying_Sample:
                    case TaskMode.CANCELLED:
                    case TaskMode.ONHOLD:
                    case TaskMode.Test_Report:
                    case TaskMode.Photo_Shoots:
                    case TaskMode.Bulk_Approval:
                    case TaskMode.Initial_Approval:
                    case TaskMode.Fabric_Quality_Approved:
                    case TaskMode.Color_Print_REF_Received:
                    case TaskMode.Acknowledgement_Fabric:
                    case TaskMode.Acknowledgement_Costing:

                        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + "  on " + "<b>" + ContractNumber.Value + "/ " + LineItemNumber.Value + "</b>" + " with " + "<b>" + Quantity.Value + "</b>" + " " + "pcs";
                        break;

                    //Case.TaskMode.STYLE_CREATED:
                    //{


                    //break;
                    //}

                    default:
                        lblmsg.Text = "<b>" + Stusname.Value + "</b>" + " for " + "<b>" + SerialNumber.Value + "</b>" + " " + "<b>" + StyleNumber.Value + "</b>" + " for " + "<b>" + CompanyName.Value + "</b>" + " " + "<b>" + DepartmentName.Value + "</b>" + "  on " + "<b>" + ContractNumber.Value + "/ " + LineItemNumber.Value + "</b>" + " with " + "<b>" + Quantity.Value + "</b>" + " " + "pcs";
                        lblhour.Visible = true;
                        img.Visible = true;
                        break;


                }

            }

        }


    }
}