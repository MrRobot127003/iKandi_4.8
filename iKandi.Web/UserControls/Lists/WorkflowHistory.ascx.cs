using System;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Drawing;
using iKandi.BLL;
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class WorkflowHistory : BaseUserControl
    {
        #region Properties

        public int InstanceID
        {
            get;
            set;
        }

        public int OrderID
        {
            get;
            set;
        }

        public int OrderDetailID
        {
            get;
            set;
        }

        public int StyleID
        {
            get;
            set;
        }


        #endregion

        private WorkflowInstance instance;
        
        private OrderDetail orderDetail = null;

        protected void grdWorkflowHistory_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(grdWorkflowHistory);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControl();
        }


       


        private void BindControl()
        {
            hiddenOrderDetailId.Value = this.OrderDetailID.ToString();
            //Added By Ashish on 9/10/2014
            int UserID = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID);
            //END
            if (this.InstanceID > 0)
            {
                instance = this.WorkflowControllerInstance.GetInstanceHistory(this.InstanceID);
                grdWorkflowHistory.DataSource = instance.WorkflowInstanceHistory;
            }
            else
            {
                WorkflowInstance wfi = this.WorkflowControllerInstance.GetInstance(this.StyleID, this.OrderID, this.OrderDetailID);
                instance = this.WorkflowControllerInstance.GetInstanceHistory(wfi.WorkflowInstanceID);
                grdWorkflowHistory.DataSource = instance.WorkflowInstanceHistory;
            }

            lblBuyingHouse.Text = instance.Style.IsIkandiClient.ToString();

            if (instance.CurrentStatus.StatusModeID == (int)TaskMode.CANCELLED)
            {
                spanCancel.Visible = false;
                //spanOnHold.Visible = false;
                //spanUnhold.Visible = false;
            }
            if (instance.CurrentStatus.StatusModeID == (int)TaskMode.ONHOLD)
            {

                //spanOnHold.Visible = false;
                //spanUnhold.Visible = true;
                spanCancel.Visible = true;

            }
            //Added By Ashish on 9/10/2014. Permission Not for see to all users Accept these users who  Have UserId 3 and 8.
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.DesignationID ==21)
            {
                spanCancel.Visible = true;
                //spanOnHold.Visible = true;
                //spanUnhold.Visible = true;
            }

            if (OrderID <= 0)
            {
              spanCancel.Visible = false;
              //spanOnHold.Visible = false;
              //spanUnhold.Visible = false;
            }
            //END


            if (instance.Order.OrderID > 0)
            {
                iKandi.Common.Order order = this.OrderControllerInstance.GetOrder(instance.Order.OrderID);
                lblBuyingHouse.Text = order.IsIkandiClient.ToString();
                // orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == instance.Order.OrderBreakdown[0].OrderDetailID; });
                orderDetail = this.OrderControllerInstance.GetOrderDetailByOrderDetailId(instance.Order.OrderBreakdown[0].OrderDetailID);
                hiddenOrderDetailId.Value = orderDetail.OrderDetailID.ToString();
                orderDetail.ParentOrder = order;
            }

            grdWorkflowHistory.DataBind();
        }

        protected void grdWorkflowHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            WorkflowController wfcon = new WorkflowController();
            Label lblStatusMode = e.Row.FindControl("lblStatusMode") as Label;

            WorkflowInstanceDetail wfd = (e.Row.DataItem as WorkflowInstanceDetail);

            //if (((wfd.StatusModeID == (int)TaskMode.CANCELLED || wfd.StatusModeID == (int)TaskMode.ONHOLD || wfd.StatusModeID == (int)TaskMode.BIPL_AGREEMENT_BIPL) && wfd.ActionDate == DateTime.MinValue))
            //{
            //    e.Row.Visible = false;
            //    return;
            //}
            lblStatusMode.Text = Constants.GetStatusModeName(wfd.StatusModeID);

         


            //Label lblColor = e.Row.FindControl("lblColor") as Label;
            //Label lblAction = e.Row.FindControl("Label3") as Label;

            //if (  (lblStatusMode.Text == "Order Agreement") || (lblStatusMode.Text == "UNDER CLEARANCE - (FLAT)") || (lblStatusMode.Text == "UNDER CLEARENCE- (HANGING)") || (lblStatusMode.Text == "CANCELLED") || (lblStatusMode.Text == "ONHOLD") || (lblStatusMode.Text == "Acknowledgement Fabric") || (lblStatusMode.Text == "Acknowledgement Costing"))
            //{
            //    if (lblAction.Text == "")
            //    {
            //        e.Row.Visible = false;
            //    }
            //}

            (lblStatusMode.Parent as TableCell).BackColor = Color.White;


            Label lblETA = e.Row.FindControl("lblETA1") as Label;
            if (wfd.ETA == DateTime.MinValue)
            {
                if (e.Row.RowIndex > 1)
                {
                    if (wfd.StatusModeID < 10 || wfd.StatusModeID == 6)
                    {
                        WorkflowInstanceDetail prevWfd = instance.WorkflowInstanceHistory[e.Row.RowIndex - 1];
                        //wfd.ETA = prevWfd.ETA.AddDays(Constants.GetNextETADays(wfd.StatusModeID));
                        //wfd.ETA=prevWfd.ETA.AddDays(wfcon.GetNextTargetDays(wfd.StatusModeID,this.orderDetail));
                        if (this.orderDetail == null)
                        {
                            OrderDetail Od = new OrderDetail();
                            Od.OrderDetailID = prevWfd.WorkflowInstance.OrderDetailID;
                            Od.ModeName = prevWfd.ModeName;
                            //wfd.ETA = wfcon.GetNextTargetDate(wfd.StatusModeID, Od);
                            wfd.ETA = wfcon.GetNextTargetDateByWfId(wfd.StatusModeID, wfd.WorkflowInstance.WorkflowInstanceID, Od.ModeName);
                        }
                        else
                            wfd.ETA = wfcon.GetNextTargetDate(wfd.StatusModeID, this.orderDetail);
                    }
                    else
                    {
                        if (this.orderDetail == null)
                        {
                            OrderDetail Od = new OrderDetail();
                            WorkflowInstanceDetail prevWfd = instance.WorkflowInstanceHistory[e.Row.RowIndex - 1];
                            Od.OrderDetailID = prevWfd.WorkflowInstance.OrderDetailID;
                            Od.ModeName = prevWfd.ModeName;
                            wfd.ETA = wfcon.GetNextTargetDate(wfd.StatusModeID, Od);
                        }
                        else
                            wfd.ETA = wfcon.GetNextTargetDate(wfd.StatusModeID, this.orderDetail);
                    }
                    if (wfd.ETA != DateTime.MinValue)
                        if (wfd.ETA.ToString("dd MMM yy (ddd)") == "01 Jan 00 (Mon)")
                            lblETA.Text = "";
                        else
                            lblETA.Text = wfd.ETA.ToString("dd MMM yy (ddd)");
                    else
                        lblETA.Text = "";
                }

            }




            //if ((wfd.StatusModeID == 7 || wfd.StatusModeID == 9) && (lblBuyingHouse.Text == "0"))
            //{
            //    e.Row.Visible = false;
            //}


            //if ((instance.CurrentStatus.StatusModeID >= wfd.StatusModeID ) || (instance.CurrentStatus.StatusModeID >= (int)StatusMode.LIVE) && wfd.StatusModeID == (int)StatusMode.WORKINGSCREATED)

            //if ((instance.CurrentStatus.StatusModeSequence >= wfd.StatusModeSequence && wfd.ActionDate != DateTime.MinValue) || (instance.CurrentStatus.StatusModeSequence >= Convert.ToInt16(wfd.Permission_Sequence) && wfd.ActionDate != DateTime.MinValue))
            //{

            //    (lblColor.Parent as TableCell).BackColor = Color.Green;
            //    lblStatusMode.ForeColor = Color.White;
            //}


            if (wfd.ActionDate != DateTime.MinValue)
            {
                if (wfd.ActionDate < wfd.ETA)
                {
                    (lblStatusMode.Parent as TableCell).BackColor = Color.Green;
                    lblStatusMode.ForeColor = Color.White;
                }
            }

            else
            {
                if (wfd.ETA > DateTime.Now)
                {
                    (lblStatusMode.Parent as TableCell).BackColor = Color.Green;
                    lblStatusMode.ForeColor = Color.White;
                }
            }
            //if (DateTime.Compare(DateTime.Now, wfd.ETA) > 0)
            //{
            //     (lblColor.Parent as TableCell).BackColor = Color.Green;
            //    lblStatusMode.ForeColor = Color.White;
            //}


            if (wfd.ActionDate != DateTime.MinValue)
            {
                if (wfd.ActionDate > wfd.ETA)
                {
                    (lblStatusMode.Parent as TableCell).BackColor = Color.Red;
                    lblStatusMode.ForeColor = Color.White;
                }
            }

            else
            {
                if (wfd.ETA < DateTime.Now)
                {
                    (lblStatusMode.Parent as TableCell).BackColor = Color.Red;
                    lblStatusMode.ForeColor = Color.White;
                }
            }
            //if (DateTime.Compare(wfd.ActionDate, wfd.ETA) > 0 && DateTime.Compare(DateTime.Now, wfd.ETA) < 0)
            //{

            //    (lblStatusMode.Parent as TableCell).BackColor = Color.Red;
            //     lblStatusMode.ForeColor = Color.White;
            //}


            if (wfd.ActionDate != DateTime.MinValue)
            {
                if (wfd.ActionDate.Date == wfd.ETA.Date)
                {
                    (lblStatusMode.Parent as TableCell).BackColor = Color.Yellow;
                    lblStatusMode.ForeColor = Color.Black;
                }

            }
            else
            {
                if (wfd.ETA.Date == DateTime.Now.Date)
                {
                    (lblStatusMode.Parent as TableCell).BackColor = Color.Yellow;
                    lblStatusMode.ForeColor = Color.Black;
                }
            }
            //if (!isYellowApplied)
            //{
            //    if (DateTime.Now.Day == wfd.ETA.Day && DateTime.Now.Month == wfd.ETA.Month && DateTime.Now.Year == wfd.ETA.Year)
            //    {

            //        (lblStatusMode.Parent as TableCell).BackColor = Color.Yellow;
            //        isYellowApplied = true;
            //        lblStatusMode.ForeColor = Color.Black;
            //    }
            //    else if (e.Row.RowIndex + 1 < instance.WorkflowInstanceHistory.Count)
            //    {
            //        WorkflowInstanceDetail nextWfd = instance.WorkflowInstanceHistory[e.Row.RowIndex + 1];

            //        if (DateTime.Compare(DateTime.Now, wfd.ETA) > 0 && DateTime.Compare(DateTime.Now, wfd.ETA) < 0)
            //        {

            //            (lblStatusMode.Parent as TableCell).BackColor = Color.Yellow;
            //            isYellowApplied = true;
            //            lblStatusMode.ForeColor = Color.Black;
            //        }
            //    }
            //}
        }

        protected void grdWorkflowHistory_DataBound(object sender, EventArgs e)
        {
            for (int i = grdWorkflowHistory.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdWorkflowHistory.Rows[i];
                GridViewRow previousRow = grdWorkflowHistory.Rows[i - 1];

                Label lblETA = (Label)row.FindControl("lblETA1");
                Label lblPreviousETA = (Label)previousRow.FindControl("lblETA1");

                if (lblETA.Text == lblPreviousETA.Text)
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
       
    }



    public class GridDecorator
    {
        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                               previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                }
            }
        }
    }
}