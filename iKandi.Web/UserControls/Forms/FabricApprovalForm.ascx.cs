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
using System.Collections.Generic;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class FabricApprovalForm : BaseUserControl
    {
        List<iKandi.Common.OrderDetail> ds = new List<iKandi.Common.OrderDetail>();
        DateTime minOrderDate = DateTime.MaxValue;
        

        #region Properties

        public int ClientID
        {
            get
            {
                if (null != Request.QueryString["clientid"])
                {
                    int clientid;

                    if (int.TryParse(Request.QueryString["clientid"].ToString(), out clientid))
                        return clientid;
                }

                return -1;
            }
        }

        public string Fabric
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["fabric"]))
                {
                    return Convert.ToString(Request.QueryString["fabric"]).Replace("’", "'").Replace("&rsquo;", "'").Replace(@"&quot;", @""""); 
                }

                return "a";
            }
        }

        public int OrderID
        {
            get
            {
                if (null != Request.QueryString["orderid"])
                {
                    int orderid;

                    if (int.TryParse(Request.QueryString["orderid"].ToString(), out orderid))
                        return orderid;
                }

                return -1;
            }
        }
        public int StyleID
        {
            get
            {
                if (null != Request.QueryString["styleid"])
                {
                    int styleid;

                    if (int.TryParse(Request.QueryString["styleid"].ToString(), out styleid))
                        return styleid;
                }

                return -1;
            }
        }

        public string FabricDetails
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["fabricdetails"]))
                {
                    return Convert.ToString(Request.QueryString["fabricdetails"]).Replace("’", "'").Replace("&rsquo;", "'").Replace(@"&quot;", @""""); 
                }

                return "b";
            }
        }

        public string SId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["SId"]))
                {
                    return Convert.ToString(Request.QueryString["Sid"]).Replace("’", "'").Replace("&rsquo;", "'").Replace(@"&quot;", @"""");
                }

                return "b";
            }
        }

        public string CCGSM11
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CCGSM11"]))
                {
                    return Convert.ToString(Request.QueryString["CCGSM11"]).Replace("’", "'").Replace("&rsquo;", "'").Replace(@"&quot;", @"""");
                }

                return "";
            }
        }
       






        #endregion

        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                BindControls();
            }
          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveFabricApprovalData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            OrderDetail od = (e.Row.DataItem as OrderDetail);

            HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
            (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(od.ExFactory));
        }

        protected void repLabDip_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView fabricApprovalDetails = ((DataRowView)e.Item.DataItem);

                HtmlTableCell cell = e.Item.FindControl("cell") as HtmlTableCell;

                if (Convert.ToInt32(fabricApprovalDetails["Status"]) == 3)
                {
                    cell.Style.Add("background-color", "red");
                }
                else if (Convert.ToInt32(fabricApprovalDetails["Status"]) == 2)
                {
                    cell.Style.Add("background-color", "#009000");
                }
                else if (Convert.ToInt32(fabricApprovalDetails["Status"]) == 1)
                {
                    cell.Style.Add("background-color", "#fd9903");
                }
            }
        }

        protected void repBulk_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView fabricApprovalDetails = ((DataRowView)e.Item.DataItem);

                HtmlTableCell cell = e.Item.FindControl("cellBulk") as HtmlTableCell;

                if (Convert.ToInt32(fabricApprovalDetails["Status"]) == 3)
                {
                    cell.Style.Add("background-color", "red");
                }
                else if (Convert.ToInt32(fabricApprovalDetails["Status"]) == 2)
                {
                    cell.Style.Add("background-color", "#009000");
                }
                else if (Convert.ToInt32(fabricApprovalDetails["Status"]) == 1)
                {
                    cell.Style.Add("background-color", "#fd9903");
                }
            }
        }

        #endregion

        #region Private Methods

        private void BindControls()
        {
           // System.Diagnostics.Debugger.Break();
            int prdNumber = 0;
           
            if (int.TryParse(FabricDetails, out prdNumber))
            {
                lblApprovalHeading.Text = Fabric + " " + "FABRIC APPROVALS FORM";
                
            }
            else
            {
                lblApprovalHeading.Text = Fabric + " (" + FabricDetails + ") " + "FABRIC APPROVALS FORM";
                
            }
            lblApprovalHeadingCCGSM.Text = CCGSM11;
            if(CCGSM11 == "")
            {
                string CCGSM = FabricApprovalControllerInstance.GetCcGsm(Fabric);
                lblApprovalHeadingCCGSM.Text = CCGSM;
            }
            DropdownHelper.BindFabricApprovalStatus(ddlApprovalStatusLabDip as ListControl);
            DropdownHelper.BindFabricApprovalStatus(ddlApprovalStatusBulk as ListControl);

            ds = OrderControllerInstance.GetOrdersApprovalBasicInfo(ClientID, Fabric, OrderID, StyleID, FabricDetails);

            GridView1.DataSource = ds;
            GridView1.DataBind();
            txtSentDateBulk.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
            txtSentDateLabDip.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

            foreach (OrderDetail od in ds)
            {
                var minLabDipDate = od.LabDipTarget;
                var minBulkDate = od.BulkApprovalTarget;

                if ((od.LabDipTarget) < minLabDipDate)
                    minLabDipDate = od.LabDipTarget;
                lblLabDipApprovalTarget.Text = minLabDipDate.ToString("dd MMM yy (ddd)");
                           
                if ((od.BulkApprovalTarget) < minBulkDate)
                    minBulkDate = od.BulkApprovalTarget;
                lblBulkApprovalTarget.Text = minBulkDate.ToString("dd MMM yy (ddd)");

                if (od.ParentOrder.OrderDate < minOrderDate)
                    ViewState["minOrderDate"] = od.ParentOrder.OrderDate;
                

            }

            DataSet dsLabDip = FabricApprovalControllerInstance.GetLabDipHistory(ClientID, Fabric, OrderID,StyleID,FabricDetails);

            repeaterLabDipHistory.DataSource = dsLabDip;
            repeaterLabDipHistory.DataBind();

            int c1 = dsLabDip.Tables[0].Rows.Count;

            if (c1 > 1)
            {
                int c = c1 - 1;
                if ((Convert.ToInt32(dsLabDip.Tables[0].Rows[c]["Status"]) == 1))
                {
                    txtDhlNumberLabDip.Text = (dsLabDip.Tables[0].Rows[c]["DHLNumber"]).ToString();
                    //txtSentDateLabDip.Text = Convert.ToDateTime(dsLabDip.Tables[0].Rows[c]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksLabDip.Text = (dsLabDip.Tables[0].Rows[c]["Remarks"]).ToString();
                    ddlApprovalStatusLabDip.SelectedValue = (dsLabDip.Tables[0].Rows[c]["Status"]).ToString();
                    hidApprovalId.Value = (dsLabDip.Tables[0].Rows[c]["FabricApprovalId"]).ToString();

                    txtSentDateBulk.Enabled = false;
                    txtDhlNumberBulk.Enabled = false;
                    ddlApprovalStatusBulk.Enabled = false;
                    txtRemarksBulk.Enabled = false;

                }
                else if ((Convert.ToInt32(dsLabDip.Tables[0].Rows[c]["Status"]) == 3))
                {
                    txtDhlNumberLabDip.Text = (dsLabDip.Tables[0].Rows[c]["DHLNumber"]).ToString();
                    //txtSentDateLabDip.Text = Convert.ToDateTime(dsLabDip.Tables[0].Rows[c]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksLabDip.Text = (dsLabDip.Tables[0].Rows[c]["Remarks"]).ToString();
                    ddlApprovalStatusLabDip.SelectedValue = (dsLabDip.Tables[0].Rows[c]["Status"]).ToString();
                    hidApprovalId.Value = (dsLabDip.Tables[0].Rows[c]["FabricApprovalId"]).ToString();

                    txtSentDateBulk.Enabled = false;
                    txtDhlNumberBulk.Enabled = false;
                    ddlApprovalStatusBulk.Enabled = false;
                    txtRemarksBulk.Enabled = false;
                }
                else if ((Convert.ToInt32(dsLabDip.Tables[0].Rows[c]["Status"]) == 2))
                {
                    txtDhlNumberLabDip.Text = (dsLabDip.Tables[0].Rows[c]["DHLNumber"]).ToString();
                    txtSentDateLabDip.Text = Convert.ToDateTime(dsLabDip.Tables[0].Rows[c]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksLabDip.Text = (dsLabDip.Tables[0].Rows[c]["Remarks"]).ToString();
                    ddlApprovalStatusLabDip.SelectedValue = (dsLabDip.Tables[0].Rows[c]["Status"]).ToString();
                    hidApprovalId.Value = (dsLabDip.Tables[0].Rows[c]["FabricApprovalId"]).ToString();

                    txtSentDateLabDip.Enabled = false;
                    txtDhlNumberLabDip.Enabled = false;
                    ddlApprovalStatusLabDip.Enabled = false;
                    txtRemarksLabDip.Enabled = false;
                    chkBoxSameAsOriginalLabDip.Enabled = false;

                    txtSentDateBulk.Enabled = true;
                    txtDhlNumberBulk.Enabled = true;
                    ddlApprovalStatusBulk.Enabled = true;
                    txtRemarksBulk.Enabled = true;
                }
            }
            else if (c1 == 1)
            {
                if ((Convert.ToInt32(dsLabDip.Tables[0].Rows[0]["Status"]) == 1))
                {
                    txtDhlNumberLabDip.Text = (dsLabDip.Tables[0].Rows[0]["DHLNumber"]).ToString();
                    //txtSentDateLabDip.Text = Convert.ToDateTime(dsLabDip.Tables[0].Rows[0]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksLabDip.Text = (dsLabDip.Tables[0].Rows[0]["Remarks"]).ToString();
                    ddlApprovalStatusLabDip.SelectedValue = (dsLabDip.Tables[0].Rows[0]["Status"]).ToString();

                    hidApprovalId.Value = (dsLabDip.Tables[0].Rows[0]["FabricApprovalId"]).ToString();

                    txtSentDateBulk.Enabled = false;
                    txtDhlNumberBulk.Enabled = false;
                    ddlApprovalStatusBulk.Enabled = false;
                    txtRemarksBulk.Enabled = false;

                }
                else if ((Convert.ToInt32(dsLabDip.Tables[0].Rows[0]["Status"]) == 3))
                {
                    txtDhlNumberLabDip.Text = (dsLabDip.Tables[0].Rows[0]["DHLNumber"]).ToString();
                    //txtSentDateLabDip.Text = Convert.ToDateTime(dsLabDip.Tables[0].Rows[0]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksLabDip.Text = (dsLabDip.Tables[0].Rows[0]["Remarks"]).ToString();
                    ddlApprovalStatusLabDip.SelectedValue = (dsLabDip.Tables[0].Rows[0]["Status"]).ToString();

                    hidApprovalId.Value = (dsLabDip.Tables[0].Rows[0]["FabricApprovalId"]).ToString();

                    txtSentDateBulk.Enabled = false;
                    txtDhlNumberBulk.Enabled = false;
                    ddlApprovalStatusBulk.Enabled = false;
                    txtRemarksBulk.Enabled = false;
                }
                else if ((Convert.ToInt32(dsLabDip.Tables[0].Rows[0]["Status"]) == 2))
                {
                    txtDhlNumberLabDip.Text = (dsLabDip.Tables[0].Rows[0]["DHLNumber"]).ToString();
                    txtSentDateLabDip.Text = Convert.ToDateTime(dsLabDip.Tables[0].Rows[0]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksLabDip.Text = (dsLabDip.Tables[0].Rows[0]["Remarks"]).ToString();
                    ddlApprovalStatusLabDip.SelectedValue = (dsLabDip.Tables[0].Rows[0]["Status"]).ToString();

                    hidApprovalId.Value = (dsLabDip.Tables[0].Rows[0]["FabricApprovalId"]).ToString();

                    txtDhlNumberLabDip.Enabled = false;
                    txtDhlNumberLabDip.Enabled = false;
                    ddlApprovalStatusLabDip.Enabled = false;
                    txtRemarksLabDip.Enabled = false;
                    chkBoxSameAsOriginalLabDip.Enabled = false;
                    txtSentDateLabDip.Enabled = false;

                    txtSentDateBulk.Enabled = true;
                    txtDhlNumberBulk.Enabled = true;
                    ddlApprovalStatusBulk.Enabled = true;
                    txtRemarksBulk.Enabled = true;
                }
            }

            DataSet dsBulk = FabricApprovalControllerInstance.GetBulkHistory(ClientID, Fabric, OrderID, StyleID, FabricDetails);

            repeaterBulkHistory.DataSource = dsBulk;
            repeaterBulkHistory.DataBind();

            int c2 = dsBulk.Tables[0].Rows.Count;

            if (c2 > 1)
            {
                int c = c2 - 1;
                if ((Convert.ToInt32(dsBulk.Tables[0].Rows[c]["Status"]) == 1))
                {
                    txtDhlNumberBulk.Text = (dsBulk.Tables[0].Rows[c]["DHLNumber"]).ToString();
                    txtSentDateBulk.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                    txtRemarksBulk.Text = (dsBulk.Tables[0].Rows[c]["Remarks"]).ToString();
                    ddlApprovalStatusBulk.SelectedValue = (dsBulk.Tables[0].Rows[c]["Status"]).ToString();

                }
                else if ((Convert.ToInt32(dsBulk.Tables[0].Rows[c]["Status"]) == 3))
                {
                    txtDhlNumberBulk.Text = (dsBulk.Tables[0].Rows[c]["DHLNumber"]).ToString();
                    txtSentDateBulk.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                    txtRemarksBulk.Text = (dsBulk.Tables[0].Rows[c]["Remarks"]).ToString();
                    ddlApprovalStatusBulk.SelectedValue = (dsBulk.Tables[0].Rows[c]["Status"]).ToString();
                }
                else if ((Convert.ToInt32(dsBulk.Tables[0].Rows[c]["Status"]) == 2))
                {
                    txtDhlNumberBulk.Text = (dsBulk.Tables[0].Rows[c]["DHLNumber"]).ToString();
                    txtSentDateBulk.Text = Convert.ToDateTime(dsBulk.Tables[0].Rows[c]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksBulk.Text = (dsBulk.Tables[0].Rows[c]["Remarks"]).ToString();
                    ddlApprovalStatusBulk.SelectedValue = (dsBulk.Tables[0].Rows[c]["Status"]).ToString();

                    txtSentDateBulk.Enabled = false;
                    txtDhlNumberBulk.Enabled = false;
                    ddlApprovalStatusBulk.Enabled = false;
                    txtRemarksBulk.Enabled = false;
                    btnSubmit.Visible = false;
                }
            }
            else if (c2 == 1)
            {
                if ((Convert.ToInt32(dsBulk.Tables[0].Rows[0]["Status"]) == 1))
                {
                    txtDhlNumberBulk.Text = (dsBulk.Tables[0].Rows[0]["DHLNumber"]).ToString();
                    txtSentDateBulk.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                    txtRemarksBulk.Text = (dsBulk.Tables[0].Rows[0]["Remarks"]).ToString();
                    ddlApprovalStatusBulk.SelectedValue = (dsBulk.Tables[0].Rows[0]["Status"]).ToString();

                }
                else if ((Convert.ToInt32(dsBulk.Tables[0].Rows[0]["Status"]) == 3))
                {
                    txtDhlNumberBulk.Text = (dsBulk.Tables[0].Rows[0]["DHLNumber"]).ToString();
                    txtSentDateBulk.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                    txtRemarksBulk.Text = (dsBulk.Tables[0].Rows[0]["Remarks"]).ToString();
                    ddlApprovalStatusBulk.SelectedValue = (dsBulk.Tables[0].Rows[0]["Status"]).ToString();
                }
                else if ((Convert.ToInt32(dsBulk.Tables[0].Rows[0]["Status"]) == 2))
                {
                    txtDhlNumberBulk.Text = (dsBulk.Tables[0].Rows[0]["DHLNumber"]).ToString();
                    txtSentDateBulk.Text = Convert.ToDateTime(dsBulk.Tables[0].Rows[0]["SentDate"]).ToString("dd MMM yy (ddd) ");
                    txtRemarksBulk.Text = (dsBulk.Tables[0].Rows[0]["Remarks"]).ToString();
                    ddlApprovalStatusBulk.SelectedValue = (dsBulk.Tables[0].Rows[0]["Status"]).ToString();

                    txtSentDateBulk.Enabled = false;
                    txtDhlNumberBulk.Enabled = false;
                    ddlApprovalStatusBulk.Enabled = false;
                    txtRemarksBulk.Enabled = false;
                    btnSubmit.Visible = false;
                }
            }

            if (c1 <= 0 && c2 <= 0)
            {
                txtSentDateBulk.Enabled = false;
                txtDhlNumberBulk.Enabled = false;
                ddlApprovalStatusBulk.Enabled = false;
                txtRemarksBulk.Enabled = false;
            }

        }

        private void SaveFabricApprovalData()
        {
            FabricApproval fabricApproval = new FabricApproval();

            fabricApproval.FabricName = this.Fabric;

            fabricApproval.ClientID = this.ClientID;

            fabricApproval.OrderID = this.OrderID;

            fabricApproval.StyleID = this.StyleID;

            fabricApproval.FabricDetails = this.FabricDetails;

            fabricApproval.LabDipApproval = new List<FabricApprovalDetails>();

            fabricApproval.BulkApproval = new List<FabricApprovalDetails>();

            FabricApprovalDetails labDipApprovalDetails = new FabricApprovalDetails();

            FabricApprovalDetails bulkApprovalDetails = new FabricApprovalDetails();

            if ((Convert.ToInt32(hidApprovalId.Value)) != -1)
                fabricApproval.Id = Convert.ToInt32(hidApprovalId.Value);
            else
                fabricApproval.Id = -1;

            DataSet dsLabDip = FabricApprovalControllerInstance.GetLabDipHistory(ClientID, Fabric, OrderID, StyleID, FabricDetails);

            int c1 = dsLabDip.Tables[0].Rows.Count;



            if (!chkBoxSameAsOriginalLabDip.Checked)
            {

                if (c1 > 1)
                {
                    int c = c1 - 1;

                    if ((txtDhlNumberLabDip.Text != ((dsLabDip.Tables[0].Rows[c]["DHLNumber"]).ToString())) ||
                        (ddlApprovalStatusLabDip.SelectedValue != ((dsLabDip.Tables[0].Rows[c]["Status"]).ToString())) ||
                        (txtRemarksLabDip.Text != ((dsLabDip.Tables[0].Rows[c]["Remarks"]).ToString())))
                    {
                        if (Convert.ToInt32(dsLabDip.Tables[0].Rows[c]["Status"]) != 2)
                        {
                            if (!string.IsNullOrEmpty(txtDhlNumberLabDip.Text))
                                labDipApprovalDetails.DHLNumber = txtDhlNumberLabDip.Text;

                            labDipApprovalDetails.Status = ddlApprovalStatusLabDip.SelectedValue;

                            if (!string.IsNullOrEmpty(txtSentDateLabDip.Text) && (DateHelper.ParseDate(txtSentDateLabDip.Text).Value != DateTime.MinValue))
                            {
                                labDipApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateLabDip.Text).Value;
                                labDipApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateLabDip.Text).Value;
                            }
                            else
                            {
                                labDipApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                labDipApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                            }

                            labDipApprovalDetails.Id = -1;

                            if (!string.IsNullOrEmpty(txtRemarksLabDip.Text))
                                labDipApprovalDetails.Remarks = txtRemarksLabDip.Text;

                            labDipApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.LabDip);

                            fabricApproval.LabDipApproval.Add(labDipApprovalDetails);
                        }
                    }

                }

                else if (c1 == 1)
                {
                    if ((txtDhlNumberLabDip.Text != ((dsLabDip.Tables[0].Rows[0]["DHLNumber"]).ToString())) ||
                        (ddlApprovalStatusLabDip.SelectedValue != ((dsLabDip.Tables[0].Rows[0]["Status"]).ToString())) ||
                        (txtRemarksLabDip.Text != ((dsLabDip.Tables[0].Rows[0]["Remarks"]).ToString())))
                    {
                        if (Convert.ToInt32(dsLabDip.Tables[0].Rows[0]["Status"]) != 2)
                        {

                            if (!string.IsNullOrEmpty(txtDhlNumberLabDip.Text))
                                labDipApprovalDetails.DHLNumber = txtDhlNumberLabDip.Text;

                            labDipApprovalDetails.Status = ddlApprovalStatusLabDip.SelectedValue;

                            if (!string.IsNullOrEmpty(txtSentDateLabDip.Text) && (DateHelper.ParseDate(txtSentDateLabDip.Text).Value != DateTime.MinValue))
                            {
                                labDipApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateLabDip.Text).Value;
                                labDipApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateLabDip.Text).Value;
                            }
                            else
                            {
                                labDipApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                labDipApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                            }

                            labDipApprovalDetails.Id = -1;

                            if (!string.IsNullOrEmpty(txtRemarksLabDip.Text))
                                labDipApprovalDetails.Remarks = txtRemarksLabDip.Text;

                            labDipApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.LabDip);

                            fabricApproval.LabDipApproval.Add(labDipApprovalDetails);
                        }
                    }
                }
                else if (c1 == 0)
                {
                    if (!string.IsNullOrEmpty(txtDhlNumberLabDip.Text))
                        labDipApprovalDetails.DHLNumber = txtDhlNumberLabDip.Text;

                    labDipApprovalDetails.Status = ddlApprovalStatusLabDip.SelectedValue;

                    if (!string.IsNullOrEmpty(txtSentDateLabDip.Text) && (DateHelper.ParseDate(txtSentDateLabDip.Text).Value != DateTime.MinValue))
                    {
                        labDipApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateLabDip.Text).Value;
                        labDipApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateLabDip.Text).Value;
                    }
                    else
                    {
                        labDipApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                        labDipApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                    }

                    labDipApprovalDetails.Id = -1;

                    if (!string.IsNullOrEmpty(txtRemarksLabDip.Text))
                        labDipApprovalDetails.Remarks = txtRemarksLabDip.Text;

                    labDipApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.LabDip);

                    fabricApproval.LabDipApproval.Add(labDipApprovalDetails);

                }

            }




            if (chkBoxSameAsOriginalLabDip.Enabled == true)
            {
                if (chkBoxSameAsOriginalLabDip.Checked)
                {

                    labDipApprovalDetails.DHLNumber = string.Empty;

                    labDipApprovalDetails.Status = "2";
                   // System.Diagnostics.Debugger.Break();
                    if (ViewState["minOrderDate"] != null)
                    {
                        labDipApprovalDetails.ActionDate = Convert.ToDateTime(ViewState["minOrderDate"]);
                        labDipApprovalDetails.SentDate = Convert.ToDateTime(ViewState["minOrderDate"]);
                    }
                    else
                    {
                        labDipApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                        labDipApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                    }

                    labDipApprovalDetails.Id = -1;

                    labDipApprovalDetails.Remarks = string.Empty;

                    labDipApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.LabDip);

                    fabricApproval.LabDipApproval.Add(labDipApprovalDetails);



                    if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text) ||
                        !string.IsNullOrEmpty(txtRemarksBulk.Text))
                    {

                        bulkApprovalDetails.Id = -1;

                        if ((!string.IsNullOrEmpty(txtSentDateBulk.Text)) && (DateHelper.ParseDate(txtSentDateBulk.Text).Value != DateTime.MinValue))
                        {
                            bulkApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                            bulkApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                        }
                        else
                        {
                            bulkApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                            bulkApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                        }

                        if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text))
                            bulkApprovalDetails.DHLNumber = txtDhlNumberBulk.Text;

                        bulkApprovalDetails.Status = Convert.ToString(ddlApprovalStatusBulk.SelectedValue);

                        if (!string.IsNullOrEmpty(txtRemarksBulk.Text))
                            bulkApprovalDetails.Remarks = txtRemarksBulk.Text;



                        bulkApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.Bulk);

                        fabricApproval.BulkApproval.Add(bulkApprovalDetails);
                    }
                }

            }





            if (c1 > 1)
            {
                int c11 = c1 - 1;

                if (Convert.ToInt32(dsLabDip.Tables[0].Rows[c11]["Status"]) == 2 || (chkBoxSameAsOriginalLabDip.Checked))
                {

                    DataSet dsBulk = FabricApprovalControllerInstance.GetBulkHistory(ClientID, Fabric, OrderID, StyleID, FabricDetails);

                    int c2 = dsBulk.Tables[0].Rows.Count;

                    if (c2 > 1)
                    {
                        int c = c2 - 1;

                        if ((txtDhlNumberBulk.Text != ((dsBulk.Tables[0].Rows[c]["DHLNumber"]).ToString())) ||
                            (txtRemarksBulk.Text != ((dsBulk.Tables[0].Rows[c]["Remarks"]).ToString())) ||
                            (ddlApprovalStatusBulk.SelectedValue != ((dsBulk.Tables[0].Rows[c]["Status"]).ToString())))
                        {
                            if ((Convert.ToInt32(dsBulk.Tables[0].Rows[c]["Status"]) != 2))
                            {
                                bulkApprovalDetails.Id = -1;

                                if ((!string.IsNullOrEmpty(txtSentDateBulk.Text)) && (DateHelper.ParseDate(txtSentDateBulk.Text).Value != DateTime.MinValue))
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                }
                                else
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                }
                                if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text))
                                    bulkApprovalDetails.DHLNumber = txtDhlNumberBulk.Text;

                                bulkApprovalDetails.Status = Convert.ToString(ddlApprovalStatusBulk.SelectedValue);

                                if (!string.IsNullOrEmpty(txtRemarksBulk.Text))
                                    bulkApprovalDetails.Remarks = txtRemarksBulk.Text;

                                bulkApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.Bulk);

                                fabricApproval.BulkApproval.Add(bulkApprovalDetails);
                            }
                        }
                    }
                    else if (c2 == 1)
                    {
                        if ((txtDhlNumberBulk.Text != ((dsBulk.Tables[0].Rows[0]["DHLNumber"]).ToString())) ||
                            (txtRemarksBulk.Text != ((dsBulk.Tables[0].Rows[0]["Remarks"]).ToString())) ||
                            (ddlApprovalStatusBulk.SelectedValue != ((dsBulk.Tables[0].Rows[0]["Status"]).ToString())))
                        {
                            if ((Convert.ToInt32(dsBulk.Tables[0].Rows[0]["Status"]) != 2))
                            {
                                bulkApprovalDetails.Id = -1;

                                if ((!string.IsNullOrEmpty(txtSentDateBulk.Text)) && (DateHelper.ParseDate(txtSentDateBulk.Text).Value != DateTime.MinValue))
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                }
                                else
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                }

                                if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text))
                                    bulkApprovalDetails.DHLNumber = txtDhlNumberBulk.Text;

                                bulkApprovalDetails.Status = Convert.ToString(ddlApprovalStatusBulk.SelectedValue);

                                if (!string.IsNullOrEmpty(txtRemarksBulk.Text))
                                    bulkApprovalDetails.Remarks = txtRemarksBulk.Text;

                                bulkApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.Bulk);

                                fabricApproval.BulkApproval.Add(bulkApprovalDetails);
                            }
                        }
                    }
                    else if (c2 == 0)
                    {
                        bulkApprovalDetails.Id = -1;

                        if ((!string.IsNullOrEmpty(txtSentDateBulk.Text)) && (DateHelper.ParseDate(txtSentDateBulk.Text).Value != DateTime.MinValue))
                        {
                            bulkApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                            bulkApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                        }
                        else
                        {
                            bulkApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                            bulkApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                        }

                        if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text))
                            bulkApprovalDetails.DHLNumber = txtDhlNumberBulk.Text;

                        bulkApprovalDetails.Status = Convert.ToString(ddlApprovalStatusBulk.SelectedValue);

                        if (!string.IsNullOrEmpty(txtRemarksBulk.Text))
                            bulkApprovalDetails.Remarks = txtRemarksBulk.Text;

                        bulkApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.Bulk);

                        fabricApproval.BulkApproval.Add(bulkApprovalDetails);
                    }
                }
            }

            else if (c1 == 1)
            {
                if (Convert.ToInt32((dsLabDip.Tables[0].Rows[0]["Status"])) == 2 || (chkBoxSameAsOriginalLabDip.Checked))
                {

                    DataSet dsBulk = FabricApprovalControllerInstance.GetBulkHistory(ClientID, Fabric, OrderID, StyleID, FabricDetails);

                    int c2 = dsBulk.Tables[0].Rows.Count;

                    if (c2 > 1)
                    {
                        int c = c2 - 1;

                        if ((txtDhlNumberBulk.Text != ((dsBulk.Tables[0].Rows[c]["DHLNumber"]).ToString())) ||
                            (txtRemarksBulk.Text != ((dsBulk.Tables[0].Rows[c]["Remarks"]).ToString())) ||
                            (ddlApprovalStatusBulk.SelectedValue != ((dsBulk.Tables[0].Rows[c]["Status"]).ToString())))
                        {

                            if ((Convert.ToInt32(dsBulk.Tables[0].Rows[c]["Status"]) != 2))
                            {
                                bulkApprovalDetails.Id = -1;

                                if ((!string.IsNullOrEmpty(txtSentDateBulk.Text)) && (DateHelper.ParseDate(txtSentDateBulk.Text).Value != DateTime.MinValue))
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                }
                                else
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                }

                                if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text))
                                    bulkApprovalDetails.DHLNumber = txtDhlNumberBulk.Text;

                                bulkApprovalDetails.Status = Convert.ToString(ddlApprovalStatusBulk.SelectedValue);

                                if (!string.IsNullOrEmpty(txtRemarksBulk.Text))
                                    bulkApprovalDetails.Remarks = txtRemarksBulk.Text;

                                bulkApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.Bulk);

                                fabricApproval.BulkApproval.Add(bulkApprovalDetails);
                            }
                        }
                    }
                    else if (c2 == 1)
                    {
                        if ((txtDhlNumberBulk.Text != ((dsBulk.Tables[0].Rows[0]["DHLNumber"]).ToString())) ||
                            (txtRemarksBulk.Text != ((dsBulk.Tables[0].Rows[0]["Remarks"]).ToString())) ||
                            (ddlApprovalStatusBulk.SelectedValue != ((dsBulk.Tables[0].Rows[0]["Status"]).ToString())))
                        {
                            if ((Convert.ToInt32(dsBulk.Tables[0].Rows[0]["Status"]) != 2))
                            {
                                bulkApprovalDetails.Id = -1;

                                if ((!string.IsNullOrEmpty(txtSentDateBulk.Text)) && (DateHelper.ParseDate(txtSentDateBulk.Text).Value != DateTime.MinValue))
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                }
                                else
                                {
                                    bulkApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                    bulkApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                }
                                if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text))
                                    bulkApprovalDetails.DHLNumber = txtDhlNumberBulk.Text;

                                bulkApprovalDetails.Status = Convert.ToString(ddlApprovalStatusBulk.SelectedValue);

                                if (!string.IsNullOrEmpty(txtRemarksBulk.Text))
                                    bulkApprovalDetails.Remarks = txtRemarksBulk.Text;

                                bulkApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.Bulk);

                                fabricApproval.BulkApproval.Add(bulkApprovalDetails);
                            }
                        }
                    }
                    else if (c2 == 0)
                    {
                        if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text) ||
                        !string.IsNullOrEmpty(txtRemarksBulk.Text) ||
                        (!string.IsNullOrEmpty(txtSentDateBulk.Text)))
                        {
                            bulkApprovalDetails.Id = -1;

                            if ((!string.IsNullOrEmpty(txtSentDateBulk.Text)) && (DateHelper.ParseDate(txtSentDateBulk.Text).Value != DateTime.MinValue))
                            {
                                bulkApprovalDetails.SentDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                                bulkApprovalDetails.ActionDate = DateHelper.ParseDate(txtSentDateBulk.Text).Value;
                            }
                            else
                            {
                                bulkApprovalDetails.SentDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                                bulkApprovalDetails.ActionDate = DateHelper.ParseDate(DateTime.Now.ToString("dd MMM yy (ddd)")).Value;
                            }
                            if (!string.IsNullOrEmpty(txtDhlNumberBulk.Text))
                                bulkApprovalDetails.DHLNumber = txtDhlNumberBulk.Text;

                            bulkApprovalDetails.Status = Convert.ToString(ddlApprovalStatusBulk.SelectedValue);

                            if (!string.IsNullOrEmpty(txtRemarksBulk.Text))
                                bulkApprovalDetails.Remarks = txtRemarksBulk.Text;

                            bulkApprovalDetails.Stage = Convert.ToInt32(FabricApprovalStage.Bulk);

                            fabricApproval.BulkApproval.Add(bulkApprovalDetails);
                        }
                    }
                }
            }

            this.FabricApprovalControllerInstance.InsertFabricApproval(fabricApproval);

            pnlForm.Visible = false;
            pnlMessage.Visible = true;

        }

        #endregion

    }
}