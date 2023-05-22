using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.UI;
using iKandi.BLL;
using System.Drawing;
using System.Data;





namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricApproval_PopUp : BasePage
    {
        FabricWorking fabricWorking = new FabricWorking();
        FabricWorking fabricWorkingCheck = new FabricWorking();
       

        #region Properties
        private string OrderID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderID"]))
                {
                    return Request.QueryString["OrderID"];
                }
                return "-1";
            }
        }
        private string OrderDetailID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailID"]))
                {
                    return Request.QueryString["OrderDetailID"];
                }
                return "-1";
            }
        }
        public string FabricType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
                {
                    return Request.QueryString["Type"];
                }
                return "-1";
            }
        }
        private string FabricName
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["FabricName"]))
                {
                    return Request.QueryString["FabricName"];
                }
                return "";
            }
        }

        private string FabricDetails
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["FabricDetails"]))
                {
                    return Request.QueryString["FabricDetails"];
                }
                return "";
            }
        }

        private string ClientID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                {
                    return Request.QueryString["ClientID"];
                }
                return "";
            }
        }
        public string Flags;
       
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                PopulateFabricData();
        }
        private void PopulateFabricData()
        {
            ltrlfabricname.Text = FabricName;
            fabricWorking = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID, FabricType);

            if (Convert.ToBoolean(fabricWorking.ApprovedByAccountManager))
            {
                btnSubmit.Visible = true;
            }
            if (FabricType == "1")
            {
                if (fabricWorking.PrintColorRecdOnFabric != "")
                {
                    lblrefupdateddate_1.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric).ToString("dd MMM  (yy)") + ")";
                    if (fabricWorking.PrintColorRecdFabric == 1)
                        lblrefupdateddate_1.ForeColor = Color.Gray;
                    else
                        lblrefupdateddate_1.ForeColor = Color.Blue;
                }
                if (fabricWorking.FabricQualtityAprdOnFabric != "")
                {
                    lblQualityupdatedate_1.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.IntialAprdOnFabric != "")
                {
                    lblinitialupdatedate_1.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.BulkAprdOnFabric != "")
                {
                    lblBulkupdatedate_1.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                //===============================================1=======================================
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                {
                    ddlQtyApvd_1.ForeColor = Color.Red;
                    lblQualityupdatedate_1.ForeColor = Color.Red;
                }
                else if (fabricWorking.FabricQualtityAprdFabric == 2)
                {
                    ddlQtyApvd_1.ForeColor = Color.Gray;
                    lblQualityupdatedate_1.ForeColor = Color.Gray;
                }
                else
                    lblQualityupdatedate_1.ForeColor = Color.Blue;
                // ---------------------------------------------------------------------------------------
                if (fabricWorking.IntialAprdFabric == 3)
                {
                    ddlinitial_1.ForeColor = Color.Red;
                    lblinitialupdatedate_1.ForeColor = Color.Red;
                }
                else if (fabricWorking.IntialAprdFabric == 2)
                {
                    ddlinitial_1.ForeColor = Color.Gray;
                    lblinitialupdatedate_1.ForeColor = Color.Gray;
                }
                else
                    lblinitialupdatedate_1.ForeColor = Color.Blue;

                // ---------------------------------------------------------------------------------------
                if (fabricWorking.BulkAprdFabric == 3)
                {
                    ddlbulkApvd_1.ForeColor = Color.Red;
                    lblBulkupdatedate_1.ForeColor = Color.Red;
                }
                else if (fabricWorking.BulkAprdFabric == 2)
                {
                    ddlbulkApvd_1.ForeColor = Color.Gray;
                    lblBulkupdatedate_1.ForeColor = Color.Gray;
                }
                else
                    lblBulkupdatedate_1.ForeColor = Color.Blue;

                    chkREFReceived_1.Checked = fabricWorking.PrintColorRecdFabric == 1 ? true : false;
                    ddlQtyApvd_1.SelectedValue = fabricWorking.FabricQualtityAprdFabric == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric.ToString();
                      ddlinitial_1.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                     chkREFReceived_1.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                       txtprintqnty1.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                      ddlbulkApvd_1.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                      ddlQtyApvd_1.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtInitial1.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
                     TxtFabricqty1.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtbulk1.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                  if (fabricWorking.IntialAprdFabric == 2)
                            ddlinitial_1.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
           

                            else
                            ddlinitial_1.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? true : false;
                   if (fabricWorking.BulkAprdFabric == 2)
                            ddlbulkApvd_1.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                            else
                            ddlbulkApvd_1.Enabled = fabricWorking.IntialAprdFabric == 2 ? true : false;
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                            {
                                ddlQtyApvd_1.ForeColor = Color.Red;
                                lblQualityupdatedate_1.ForeColor = Color.Red;
                            }
                            else if (fabricWorking.FabricQualtityAprdFabric == 2)
                            {
                                ddlQtyApvd_1.ForeColor = Color.Gray;
                                lblQualityupdatedate_1.ForeColor = Color.Gray;
                            }
                            else
                                lblQualityupdatedate_1.ForeColor = Color.Blue;
                                // ---------------------------------------------------------------------------------------
                                if (fabricWorking.IntialAprdFabric == 3)
                                {
                                    ddlinitial_1.ForeColor = Color.Red;
                                    lblinitialupdatedate_1.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.IntialAprdFabric == 2)
                                {
                                    ddlinitial_1.ForeColor = Color.Gray;
                                    lblinitialupdatedate_1.ForeColor = Color.Gray;
                                }
                                else
                                    lblinitialupdatedate_1.ForeColor = Color.Blue;

                            // ---------------------------------------------------------------------------------------
                                if (fabricWorking.BulkAprdFabric == 3)
                                {
                                    ddlbulkApvd_1.ForeColor = Color.Red;
                                    lblBulkupdatedate_1.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.BulkAprdFabric == 2)
                                {
                                    ddlbulkApvd_1.ForeColor = Color.Gray;
                                    lblBulkupdatedate_1.ForeColor = Color.Gray;
                                }
                                else
                                    lblBulkupdatedate_1.ForeColor = Color.Blue;
                                    DivFabricSection_1.Visible = true;
                                    fabricWorking.FabricRemarks = fabricWorking.Fabric_ApprovalRemarks;
                        if (fabricWorking.FabricChanged != "")
                                    lblFabricDetails.Text = fabricWorking.FabricChanged;

                                if (fabricWorking.FabricDetailChanged != "")
                                {
                                    if (lblFabricDetails.Text != "")
                                        lblFabricDetails.Text = lblFabricDetails.Text + " And " + fabricWorking.FabricDetailChanged;
                                    else
                                        lblFabricDetails.Text = fabricWorking.FabricDetailChanged;
                                }
            }
            if (FabricType == "2")
            {
                if (fabricWorking.PrintColorRecdOnFabric != "")
                {
                    lblrefupdateddate_2.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric).ToString("dd MMM  (yy)") + ")";
                    if (fabricWorking.PrintColorRecdFabric == 1)
                        lblrefupdateddate_2.ForeColor = Color.Gray;
                    else
                        lblrefupdateddate_2.ForeColor = Color.Blue;
                }
                if (fabricWorking.FabricQualtityAprdOnFabric != "")
                {
                    lblQualityupdatedate_2.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.IntialAprdOnFabric != "")
                {
                    lblinitialupdatedate_2.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.BulkAprdOnFabric != "")
                {
                    lblBulkupdatedate_2.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                //===============================================1=======================================
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                {
                    ddlQtyApvd_2.ForeColor = Color.Red;
                    lblQualityupdatedate_2.ForeColor = Color.Red;
                }
                else if (fabricWorking.FabricQualtityAprdFabric == 2)
                {
                    ddlQtyApvd_2.ForeColor = Color.Gray;
                    lblQualityupdatedate_2.ForeColor = Color.Gray;
                }
                else
                    lblQualityupdatedate_2.ForeColor = Color.Blue;
                // ---------------------------------------------------------------------------------------
                if (fabricWorking.IntialAprdFabric == 3)
                {
                    ddlinitial_2.ForeColor = Color.Red;
                    lblinitialupdatedate_2.ForeColor = Color.Red;
                }
                else if (fabricWorking.IntialAprdFabric == 2)
                {
                    ddlinitial_2.ForeColor = Color.Gray;
                    lblinitialupdatedate_2.ForeColor = Color.Gray;
                }
                else
                    lblinitialupdatedate_2.ForeColor = Color.Blue;

                // ---------------------------------------------------------------------------------------
                if (fabricWorking.BulkAprdFabric == 3)
                {
                    ddlbulkApvd_2.ForeColor = Color.Red;
                    lblBulkupdatedate_2.ForeColor = Color.Red;
                }
                else if (fabricWorking.BulkAprdFabric == 2)
                {
                    ddlbulkApvd_2.ForeColor = Color.Gray;
                    lblBulkupdatedate_2.ForeColor = Color.Gray;
                }
                else
                    lblBulkupdatedate_2.ForeColor = Color.Blue;

                    chkREFReceived_2.Checked = fabricWorking.PrintColorRecdFabric == 1 ? true : false;
                    ddlQtyApvd_2.SelectedValue = fabricWorking.FabricQualtityAprdFabric == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric.ToString();
                      ddlinitial_2.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                     chkREFReceived_2.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                       txtprintqty2.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                      ddlbulkApvd_2.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                      ddlQtyApvd_2.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtInitial2.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
                     TxtFabricqty2.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtbulk2.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                  if (fabricWorking.IntialAprdFabric == 2)
                            ddlinitial_2.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
           

                            else
                            ddlinitial_2.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? true : false;
                   if (fabricWorking.BulkAprdFabric == 2)
                            ddlbulkApvd_2.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                            else
                            ddlbulkApvd_2.Enabled = fabricWorking.IntialAprdFabric == 2 ? true : false;
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                            {
                                ddlQtyApvd_2.ForeColor = Color.Red;
                                lblQualityupdatedate_2.ForeColor = Color.Red;
                            }
                            else if (fabricWorking.FabricQualtityAprdFabric == 2)
                            {
                                ddlQtyApvd_2.ForeColor = Color.Gray;
                                lblQualityupdatedate_2.ForeColor = Color.Gray;
                            }
                            else
                                lblQualityupdatedate_2.ForeColor = Color.Blue;
                                // ---------------------------------------------------------------------------------------
                                if (fabricWorking.IntialAprdFabric == 3)
                                {
                                    ddlinitial_2.ForeColor = Color.Red;
                                    lblinitialupdatedate_2.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.IntialAprdFabric == 2)
                                {
                                    ddlinitial_2.ForeColor = Color.Gray;
                                    lblinitialupdatedate_2.ForeColor = Color.Gray;
                                }
                                else
                                    lblinitialupdatedate_2.ForeColor = Color.Blue;

                            // ---------------------------------------------------------------------------------------
                                if (fabricWorking.BulkAprdFabric == 3)
                                {
                                    ddlbulkApvd_2.ForeColor = Color.Red;
                                    lblBulkupdatedate_2.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.BulkAprdFabric == 2)
                                {
                                    ddlbulkApvd_2.ForeColor = Color.Gray;
                                    lblBulkupdatedate_2.ForeColor = Color.Gray;
                                }
                                else
                                    lblBulkupdatedate_2.ForeColor = Color.Blue;
                                    DivFabricSection_2.Visible = true;
                                    fabricWorking.FabricRemarks = fabricWorking.Fabric_ApprovalRemarks;
                        if (fabricWorking.FabricChanged != "")
                                    lblFabricDetails.Text = fabricWorking.FabricChanged;

                                if (fabricWorking.FabricDetailChanged != "")
                                {
                                    if (lblFabricDetails.Text != "")
                                        lblFabricDetails.Text = lblFabricDetails.Text + " And " + fabricWorking.FabricDetailChanged;
                                    else
                                        lblFabricDetails.Text = fabricWorking.FabricDetailChanged;
                                }
            }
            if (FabricType == "3")
            {
                if (fabricWorking.PrintColorRecdOnFabric != "")
                {
                    lblrefupdateddate_3.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric).ToString("dd MMM  (yy)") + ")";
                    if (fabricWorking.PrintColorRecdFabric == 1)
                        lblrefupdateddate_3.ForeColor = Color.Gray;
                    else
                        lblrefupdateddate_3.ForeColor = Color.Blue;
                }
                if (fabricWorking.FabricQualtityAprdOnFabric != "")
                {
                    lblQualityupdatedate_3.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.IntialAprdOnFabric != "")
                {
                    lblinitialupdatedate_3.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.BulkAprdOnFabric != "")
                {
                    lblBulkupdatedate_3.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                //===============================================1=======================================
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                {
                    ddlQtyApvd_3.ForeColor = Color.Red;
                    lblQualityupdatedate_3.ForeColor = Color.Red;
                }
                else if (fabricWorking.FabricQualtityAprdFabric == 2)
                {
                    ddlQtyApvd_2.ForeColor = Color.Gray;
                    lblQualityupdatedate_3.ForeColor = Color.Gray;
                }
                else
                    lblQualityupdatedate_3.ForeColor = Color.Blue;
                // ---------------------------------------------------------------------------------------
                if (fabricWorking.IntialAprdFabric == 3)
                {
                    ddlinitial_3.ForeColor = Color.Red;
                    lblinitialupdatedate_3.ForeColor = Color.Red;
                }
                else if (fabricWorking.IntialAprdFabric == 2)
                {
                    ddlinitial_3.ForeColor = Color.Gray;
                    lblinitialupdatedate_3.ForeColor = Color.Gray;
                }
                else
                    lblinitialupdatedate_3.ForeColor = Color.Blue;

                // ---------------------------------------------------------------------------------------
                if (fabricWorking.BulkAprdFabric == 3)
                {
                    ddlbulkApvd_3.ForeColor = Color.Red;
                    lblBulkupdatedate_3.ForeColor = Color.Red;
                }
                else if (fabricWorking.BulkAprdFabric == 2)
                {
                    ddlbulkApvd_3.ForeColor = Color.Gray;
                    lblBulkupdatedate_3.ForeColor = Color.Gray;
                }
                else
                    lblBulkupdatedate_3.ForeColor = Color.Blue;

                    chkREFReceived_3.Checked = fabricWorking.PrintColorRecdFabric == 1 ? true : false;
                    ddlQtyApvd_3.SelectedValue = fabricWorking.FabricQualtityAprdFabric == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric.ToString();
                      ddlinitial_3.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                     chkREFReceived_3.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                       txtprintqty3.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                      ddlbulkApvd_3.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                      ddlQtyApvd_3.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtInitial3.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
                     TxtFabricqty3.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtbulk3.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                  if (fabricWorking.IntialAprdFabric == 2)
                            ddlinitial_3.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
           

                            else
                            ddlinitial_3.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? true : false;
                   if (fabricWorking.BulkAprdFabric == 2)
                            ddlbulkApvd_3.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                            else
                            ddlbulkApvd_3.Enabled = fabricWorking.IntialAprdFabric == 2 ? true : false;
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                            {
                                ddlQtyApvd_3.ForeColor = Color.Red;
                                lblQualityupdatedate_3.ForeColor = Color.Red;
                            }
                            else if (fabricWorking.FabricQualtityAprdFabric == 2)
                            {
                                ddlQtyApvd_3.ForeColor = Color.Gray;
                                lblQualityupdatedate_3.ForeColor = Color.Gray;
                            }
                            else
                                lblQualityupdatedate_3.ForeColor = Color.Blue;
                                // ---------------------------------------------------------------------------------------
                                if (fabricWorking.IntialAprdFabric == 3)
                                {
                                    ddlinitial_3.ForeColor = Color.Red;
                                    lblinitialupdatedate_3.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.IntialAprdFabric == 2)
                                {
                                    ddlinitial_3.ForeColor = Color.Gray;
                                    lblinitialupdatedate_3.ForeColor = Color.Gray;
                                }
                                else
                                    lblinitialupdatedate_3.ForeColor = Color.Blue;

                            // ---------------------------------------------------------------------------------------
                                if (fabricWorking.BulkAprdFabric == 3)
                                {
                                    ddlbulkApvd_3.ForeColor = Color.Red;
                                    lblBulkupdatedate_3.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.BulkAprdFabric == 2)
                                {
                                    ddlbulkApvd_3.ForeColor = Color.Gray;
                                    lblBulkupdatedate_3.ForeColor = Color.Gray;
                                }
                                else
                                    lblBulkupdatedate_3.ForeColor = Color.Blue;
                                    DivFabricSection_3.Visible = true;
                                    fabricWorking.FabricRemarks = fabricWorking.Fabric_ApprovalRemarks;
                        if (fabricWorking.FabricChanged != "")
                                    lblFabricDetails.Text = fabricWorking.FabricChanged;

                                if (fabricWorking.FabricDetailChanged != "")
                                {
                                    if (lblFabricDetails.Text != "")
                                        lblFabricDetails.Text = lblFabricDetails.Text + " And " + fabricWorking.FabricDetailChanged;
                                    else
                                        lblFabricDetails.Text = fabricWorking.FabricDetailChanged;
                                }
            }

            if (FabricType == "4")
            {
                if (fabricWorking.PrintColorRecdOnFabric != "")
                {
                    lblrefupdateddate_4.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric).ToString("dd MMM  (yy)") + ")";
                    if (fabricWorking.PrintColorRecdFabric == 1)
                        lblrefupdateddate_4.ForeColor = Color.Gray;
                    else
                        lblrefupdateddate_4.ForeColor = Color.Blue;
                }
                if (fabricWorking.FabricQualtityAprdOnFabric != "")
                {
                    lblQualityupdatedate_4.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.IntialAprdOnFabric != "")
                {
                    lblinitialupdatedate_4.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.BulkAprdOnFabric != "")
                {
                    lblBulkupdatedate_4.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                //===============================================1=======================================
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                {
                    ddlQtyApvd_4.ForeColor = Color.Red;
                    lblQualityupdatedate_4.ForeColor = Color.Red;
                }
                else if (fabricWorking.FabricQualtityAprdFabric == 2)
                {
                    ddlQtyApvd_2.ForeColor = Color.Gray;
                    lblQualityupdatedate_4.ForeColor = Color.Gray;
                }
                else
                    lblQualityupdatedate_4.ForeColor = Color.Blue;
                // ---------------------------------------------------------------------------------------
                if (fabricWorking.IntialAprdFabric == 3)
                {
                    ddlinitial_4.ForeColor = Color.Red;
                    lblinitialupdatedate_4.ForeColor = Color.Red;
                }
                else if (fabricWorking.IntialAprdFabric == 2)
                {
                    ddlinitial_4.ForeColor = Color.Gray;
                    lblinitialupdatedate_4.ForeColor = Color.Gray;
                }
                else
                    lblinitialupdatedate_4.ForeColor = Color.Blue;

                // ---------------------------------------------------------------------------------------
                if (fabricWorking.BulkAprdFabric == 3)
                {
                    ddlbulkApvd_4.ForeColor = Color.Red;
                    lblBulkupdatedate_4.ForeColor = Color.Red;
                }
                else if (fabricWorking.BulkAprdFabric == 2)
                {
                    ddlbulkApvd_4.ForeColor = Color.Gray;
                    lblBulkupdatedate_4.ForeColor = Color.Gray;
                }
                else
                    lblBulkupdatedate_4.ForeColor = Color.Blue;

                    chkREFReceived_4.Checked = fabricWorking.PrintColorRecdFabric == 1 ? true : false;
                    ddlQtyApvd_4.SelectedValue = fabricWorking.FabricQualtityAprdFabric == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric.ToString();
                      ddlinitial_4.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                     chkREFReceived_4.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                       txtprintqty4.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                      ddlbulkApvd_4.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                      ddlQtyApvd_4.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtInitial4.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
                     TxtFabricqty4.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtbulk4.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                  if (fabricWorking.IntialAprdFabric == 2)
                            ddlinitial_4.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
           

                            else
                            ddlinitial_4.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? true : false;
                   if (fabricWorking.BulkAprdFabric == 2)
                            ddlbulkApvd_4.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                            else
                            ddlbulkApvd_4.Enabled = fabricWorking.IntialAprdFabric == 2 ? true : false;
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                            {
                                ddlQtyApvd_4.ForeColor = Color.Red;
                                lblQualityupdatedate_4.ForeColor = Color.Red;
                            }
                            else if (fabricWorking.FabricQualtityAprdFabric == 2)
                            {
                                ddlQtyApvd_4.ForeColor = Color.Gray;
                                lblQualityupdatedate_4.ForeColor = Color.Gray;
                            }
                            else
                                lblQualityupdatedate_4.ForeColor = Color.Blue;
                                // ---------------------------------------------------------------------------------------
                                if (fabricWorking.IntialAprdFabric == 3)
                                {
                                    ddlinitial_4.ForeColor = Color.Red;
                                    lblinitialupdatedate_4.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.IntialAprdFabric == 2)
                                {
                                    ddlinitial_4.ForeColor = Color.Gray;
                                    lblinitialupdatedate_4.ForeColor = Color.Gray;
                                }
                                else
                                    lblinitialupdatedate_4.ForeColor = Color.Blue;

                            // ---------------------------------------------------------------------------------------
                                if (fabricWorking.BulkAprdFabric == 3)
                                {
                                    ddlbulkApvd_4.ForeColor = Color.Red;
                                    lblBulkupdatedate_4.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.BulkAprdFabric == 2)
                                {
                                    ddlbulkApvd_4.ForeColor = Color.Gray;
                                    lblBulkupdatedate_4.ForeColor = Color.Gray;
                                }
                                else
                                    lblBulkupdatedate_4.ForeColor = Color.Blue;
                                    DivFabricSection_4.Visible = true;
                                    fabricWorking.FabricRemarks = fabricWorking.Fabric_ApprovalRemarks;
                        if (fabricWorking.FabricChanged != "")
                                    lblFabricDetails.Text = fabricWorking.FabricChanged;

                                if (fabricWorking.FabricDetailChanged != "")
                                {
                                    if (lblFabricDetails.Text != "")
                                        lblFabricDetails.Text = lblFabricDetails.Text + " And " + fabricWorking.FabricDetailChanged;
                                    else
                                        lblFabricDetails.Text = fabricWorking.FabricDetailChanged;
                                }
            }
            if (FabricType == "5")
            {
                if (fabricWorking.PrintColorRecdOnFabric != "")
                {
                    lblrefupdateddate_5.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric).ToString("dd MMM  (yy)") + ")";
                    if (fabricWorking.PrintColorRecdFabric == 1)
                        lblrefupdateddate_5.ForeColor = Color.Gray;
                    else
                        lblrefupdateddate_5.ForeColor = Color.Blue;
                }
                if (fabricWorking.FabricQualtityAprdOnFabric != "")
                {
                    lblQualityupdatedate_5.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.IntialAprdOnFabric != "")
                {
                    lblinitialupdatedate_5.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.BulkAprdOnFabric != "")
                {
                    lblBulkupdatedate_5.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                //===============================================1=======================================
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                {
                    ddlQtyApvd_5.ForeColor = Color.Red;
                    lblQualityupdatedate_5.ForeColor = Color.Red;
                }
                else if (fabricWorking.FabricQualtityAprdFabric == 2)
                {
                    ddlQtyApvd_5.ForeColor = Color.Gray;
                    lblQualityupdatedate_5.ForeColor = Color.Gray;
                }
                else
                    lblQualityupdatedate_5.ForeColor = Color.Blue;
                // ---------------------------------------------------------------------------------------
                if (fabricWorking.IntialAprdFabric == 3)
                {
                    ddlinitial_5.ForeColor = Color.Red;
                    lblinitialupdatedate_5.ForeColor = Color.Red;
                }
                else if (fabricWorking.IntialAprdFabric == 2)
                {
                    ddlinitial_5.ForeColor = Color.Gray;
                    lblinitialupdatedate_5.ForeColor = Color.Gray;
                }
                else
                    lblinitialupdatedate_5.ForeColor = Color.Blue;

                // ---------------------------------------------------------------------------------------
                if (fabricWorking.BulkAprdFabric == 3)
                {
                    ddlbulkApvd_5.ForeColor = Color.Red;
                    lblBulkupdatedate_5.ForeColor = Color.Red;
                }
                else if (fabricWorking.BulkAprdFabric == 2)
                {
                    ddlbulkApvd_5.ForeColor = Color.Gray;
                    lblBulkupdatedate_5.ForeColor = Color.Gray;
                }
                else
                    lblBulkupdatedate_5.ForeColor = Color.Blue;

                    chkREFReceived_5.Checked = fabricWorking.PrintColorRecdFabric == 1 ? true : false;
                    ddlQtyApvd_5.SelectedValue = fabricWorking.FabricQualtityAprdFabric == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric.ToString();
                      ddlinitial_5.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                     chkREFReceived_5.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                       txtprintqty5.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                      ddlbulkApvd_5.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                      ddlQtyApvd_5.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtInitial5.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
                     TxtFabricqty5.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtbulk5.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                  if (fabricWorking.IntialAprdFabric == 2)
                            ddlinitial_5.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
           

                            else
                            ddlinitial_5.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? true : false;
                   if (fabricWorking.BulkAprdFabric == 2)
                            ddlbulkApvd_5.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                            else
                            ddlbulkApvd_5.Enabled = fabricWorking.IntialAprdFabric == 2 ? true : false;
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                            {
                                ddlQtyApvd_5.ForeColor = Color.Red;
                                lblQualityupdatedate_5.ForeColor = Color.Red;
                            }
                            else if (fabricWorking.FabricQualtityAprdFabric == 2)
                            {
                                ddlQtyApvd_5.ForeColor = Color.Gray;
                                lblQualityupdatedate_5.ForeColor = Color.Gray;
                            }
                            else
                                lblQualityupdatedate_5.ForeColor = Color.Blue;
                                // ---------------------------------------------------------------------------------------
                                if (fabricWorking.IntialAprdFabric == 3)
                                {
                                    ddlinitial_5.ForeColor = Color.Red;
                                    lblinitialupdatedate_5.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.IntialAprdFabric == 2)
                                {
                                    ddlinitial_5.ForeColor = Color.Gray;
                                    lblinitialupdatedate_5.ForeColor = Color.Gray;
                                }
                                else
                                    lblinitialupdatedate_5.ForeColor = Color.Blue;

                            // ---------------------------------------------------------------------------------------
                                if (fabricWorking.BulkAprdFabric == 3)
                                {
                                    ddlbulkApvd_5.ForeColor = Color.Red;
                                    lblBulkupdatedate_5.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.BulkAprdFabric == 2)
                                {
                                    ddlbulkApvd_5.ForeColor = Color.Gray;
                                    lblBulkupdatedate_5.ForeColor = Color.Gray;
                                }
                                else
                                    lblBulkupdatedate_5.ForeColor = Color.Blue;
                                    DivFabricSection_5.Visible = true;
                                    fabricWorking.FabricRemarks = fabricWorking.Fabric_ApprovalRemarks;
                        if (fabricWorking.FabricChanged != "")
                                    lblFabricDetails.Text = fabricWorking.FabricChanged;

                                if (fabricWorking.FabricDetailChanged != "")
                                {
                                    if (lblFabricDetails.Text != "")
                                        lblFabricDetails.Text = lblFabricDetails.Text + " And " + fabricWorking.FabricDetailChanged;
                                    else
                                        lblFabricDetails.Text = fabricWorking.FabricDetailChanged;
                                }
            }
            if (FabricType == "6")
            {
                if (fabricWorking.PrintColorRecdOnFabric != "")
                {
                    lblrefupdateddate_6.Text = "(" + Convert.ToDateTime(fabricWorking.PrintColorRecdOnFabric).ToString("dd MMM  (yy)") + ")";
                    if (fabricWorking.PrintColorRecdFabric == 1)
                        lblrefupdateddate_6.ForeColor = Color.Gray;
                    else
                        lblrefupdateddate_6.ForeColor = Color.Blue;
                }
                if (fabricWorking.FabricQualtityAprdOnFabric != "")
                {
                    lblQualityupdatedate_6.Text = "(" + Convert.ToDateTime(fabricWorking.FabricQualtityAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.IntialAprdOnFabric != "")
                {
                    lblinitialupdatedate_6.Text = "(" + Convert.ToDateTime(fabricWorking.IntialAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                if (fabricWorking.BulkAprdOnFabric != "")
                {
                    lblBulkupdatedate_6.Text = "(" + Convert.ToDateTime(fabricWorking.BulkAprdOnFabric).ToString("dd MMM  (yy)") + ")";
                }
                //===============================================1=======================================
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                {
                    ddlQtyApvd_6.ForeColor = Color.Red;
                    lblQualityupdatedate_6.ForeColor = Color.Red;
                }
                else if (fabricWorking.FabricQualtityAprdFabric == 2)
                {
                    ddlQtyApvd_2.ForeColor = Color.Gray;
                    lblQualityupdatedate_6.ForeColor = Color.Gray;
                }
                else
                    lblQualityupdatedate_6.ForeColor = Color.Blue;
                // ---------------------------------------------------------------------------------------
                if (fabricWorking.IntialAprdFabric == 3)
                {
                    ddlinitial_6.ForeColor = Color.Red;
                    lblinitialupdatedate_6.ForeColor = Color.Red;
                }
                else if (fabricWorking.IntialAprdFabric == 2)
                {
                    ddlinitial_6.ForeColor = Color.Gray;
                    lblinitialupdatedate_6.ForeColor = Color.Gray;
                }
                else
                    lblinitialupdatedate_6.ForeColor = Color.Blue;

                // ---------------------------------------------------------------------------------------
                if (fabricWorking.BulkAprdFabric == 3)
                {
                    ddlbulkApvd_6.ForeColor = Color.Red;
                    lblBulkupdatedate_6.ForeColor = Color.Red;
                }
                else if (fabricWorking.BulkAprdFabric == 2)
                {
                    ddlbulkApvd_6.ForeColor = Color.Gray;
                    lblBulkupdatedate_6.ForeColor = Color.Gray;
                }
                else
                    lblBulkupdatedate_6.ForeColor = Color.Blue;

                    chkREFReceived_6.Checked = fabricWorking.PrintColorRecdFabric == 1 ? true : false;
                    ddlQtyApvd_6.SelectedValue = fabricWorking.FabricQualtityAprdFabric == 0 ? "-1" : fabricWorking.FabricQualtityAprdFabric.ToString();
                      ddlinitial_6.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                     chkREFReceived_6.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                       txtprintqty6.Enabled = fabricWorking.PrintColorRecdFabric == 1 ? false : true;
                      ddlbulkApvd_6.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                      ddlQtyApvd_6.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtInitial6.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
                     TxtFabricqty6.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? false : true;
                     txtbulk6.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                  if (fabricWorking.IntialAprdFabric == 2)
                            ddlinitial_6.Enabled = fabricWorking.IntialAprdFabric == 2 ? false : true;
           

                            else
                            ddlinitial_6.Enabled = fabricWorking.FabricQualtityAprdFabric == 2 ? true : false;
                   if (fabricWorking.BulkAprdFabric == 2)
                            ddlbulkApvd_6.Enabled = fabricWorking.BulkAprdFabric == 2 ? false : true;
                            else
                            ddlbulkApvd_6.Enabled = fabricWorking.IntialAprdFabric == 2 ? true : false;
                if (fabricWorking.FabricQualtityAprdFabric == 3)
                            {
                                ddlQtyApvd_6.ForeColor = Color.Red;
                                lblQualityupdatedate_6.ForeColor = Color.Red;
                            }
                            else if (fabricWorking.FabricQualtityAprdFabric == 2)
                            {
                                ddlQtyApvd_6.ForeColor = Color.Gray;
                                lblQualityupdatedate_6.ForeColor = Color.Gray;
                            }
                            else
                                lblQualityupdatedate_6.ForeColor = Color.Blue;
                                // ---------------------------------------------------------------------------------------
                                if (fabricWorking.IntialAprdFabric == 3)
                                {
                                    ddlinitial_6.ForeColor = Color.Red;
                                    lblinitialupdatedate_6.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.IntialAprdFabric == 2)
                                {
                                    ddlinitial_6.ForeColor = Color.Gray;
                                    lblinitialupdatedate_6.ForeColor = Color.Gray;
                                }
                                else
                                    lblinitialupdatedate_6.ForeColor = Color.Blue;

                            // ---------------------------------------------------------------------------------------
                                if (fabricWorking.BulkAprdFabric == 3)
                                {
                                    ddlbulkApvd_6.ForeColor = Color.Red;
                                    lblBulkupdatedate_6.ForeColor = Color.Red;
                                }
                                else if (fabricWorking.BulkAprdFabric == 2)
                                {
                                    ddlbulkApvd_6.ForeColor = Color.Gray;
                                    lblBulkupdatedate_6.ForeColor = Color.Gray;
                                }
                                else
                                    lblBulkupdatedate_6.ForeColor = Color.Blue;
                                    DivFabricSection_6.Visible = true;
                                    fabricWorking.FabricRemarks = fabricWorking.Fabric_ApprovalRemarks;
                        if (fabricWorking.FabricChanged != "")
                                    lblFabricDetails.Text = fabricWorking.FabricChanged;

                                if (fabricWorking.FabricDetailChanged != "")
                                {
                                    if (lblFabricDetails.Text != "")
                                        lblFabricDetails.Text = lblFabricDetails.Text + " And " + fabricWorking.FabricDetailChanged;
                                    else
                                        lblFabricDetails.Text = fabricWorking.FabricDetailChanged;
                                }
            }
            var strRemarks = fabricWorking.FabricRemarks;
            if (strRemarks != "`")
            {
                divHistory.Visible = true;
                string[] separators = { "`", "$$" };
                string[] words = strRemarks.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    lblRemarks.Text = lblRemarks.Text + "</br>" + word;
                }
            }
            //=======================================End====================================================
           
            
        }
        public bool Validationref()
        {
            bool bcheck = false;
            if (FabricType == "1")
            {
                if (txtprintqnty1.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }
                if (txtRemarks.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }
            }
            if (FabricType == "2")
            {
                if (txtprintqty2.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }
                if (txtRemarks.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }

            }
            if (FabricType == "3")
            {
                if (txtprintqty3.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }
                if (txtRemarks.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }

            }
            if (FabricType == "4")
            {
                if (txtprintqty4.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }
                if (txtRemarks.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }

            }
            if (FabricType == "5")
            {
                if (txtprintqty5.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }
                if (txtRemarks.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }

            }
            if (FabricType == "6")
            {
                if (txtprintqty6.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }
                if (txtRemarks.Text != "")
                {
                    Flags = "TRUE";
                    bcheck = true;
                }

            }
            //if (FabricType == "6")
            //{
            //    if (txtprintqty6.Text != "")
            //    {
            //        Flags = "TRUE";
            //        bcheck = true;
            //    }
            //    if (txtRemarks.Text != "")
            //    {
            //        Flags = "TRUE";
            //        bcheck = true;
            //    }

            //}
            return bcheck;
        }
        private bool Validation()
        {
            bool bcheck = false;
            //var fabricWorkingCheck = new FabricWorking();
            //fabricWorkingCheck = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID);
           
            if (FabricType == "1")
            {
               
                if (ddlQtyApvd_1.Enabled == true)
                {
                    if ((TxtFabricqty1.Text != "") && (ddlQtyApvd_1.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlinitial_1.Enabled == true)
                {
                    if ((txtInitial1.Text != "") && (ddlinitial_1.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlbulkApvd_1.Enabled == true)
                {
                    if ((txtbulk1.Text != "") && (ddlbulkApvd_1.SelectedIndex != 0))
                        bcheck = true;
                }
            }
            
                

                //if ((ddlQtyApvd_1.Enabled == true) && (TxtFabricqty1.Text == "") && (ddlQtyApvd_1.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlinitial_1.Enabled == true) && (txtInitial1.Text == "") && (ddlinitial_1.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlbulkApvd_1.Enabled == true) && (txtbulk1.Text == "") && (ddlbulkApvd_1.SelectedIndex != 0))
                //    bcheck = false;

                //if ((TxtFabricqty1.Text != "") && (ddlQtyApvd_1.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtInitial1.Text != "") && (ddlinitial_1.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtbulk1.Text != "") && (ddlbulkApvd_1.SelectedIndex == 0))
                //    bcheck = false;

               

            
            if (FabricType == "2")
            {

                if (ddlQtyApvd_2.Enabled == true)
                {
                    if ((TxtFabricqty2.Text != "") && (ddlQtyApvd_2.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlinitial_2.Enabled == true)
                {
                    if ((txtInitial2.Text != "") && (ddlinitial_2.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlbulkApvd_2.Enabled == true)
                {
                    if ((txtbulk2.Text != "") && (ddlbulkApvd_2.SelectedIndex != 0))
                        bcheck = true;
                }    
            
                //if ((ddlQtyApvd_2.Enabled == true) && (TxtFabricqty2.Text == "") && (ddlQtyApvd_2.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlinitial_2.Enabled == true) && (txtInitial2.Text == "") && (ddlinitial_2.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlbulkApvd_2.Enabled == true) && (txtbulk2.Text == "") && (ddlbulkApvd_2.SelectedIndex != 0))
                //    bcheck = false;

                //if ((TxtFabricqty2.Text != "") && (ddlQtyApvd_2.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtInitial2.Text != "") && (ddlinitial_2.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtbulk2.Text != "") && (ddlbulkApvd_2.SelectedIndex == 0))

                //    bcheck = false;


                
               
            }
            if (FabricType == "3")
            {

                if (ddlQtyApvd_3.Enabled == true)
                {
                    if ((TxtFabricqty3.Text != "") && (ddlQtyApvd_3.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlinitial_3.Enabled == true)
                {
                    if ((txtInitial3.Text != "") && (ddlinitial_3.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlbulkApvd_3.Enabled == true)
                {
                    if ((txtbulk3.Text != "") && (ddlbulkApvd_3.SelectedIndex != 0))
                        bcheck = true;
                }
               
                //if ((ddlQtyApvd_3.Enabled == true) && (TxtFabricqty3.Text == "") && (ddlQtyApvd_3.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlinitial_3.Enabled == true) && (txtInitial3.Text == "") && (ddlinitial_3.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlbulkApvd_3.Enabled == true) && (txtbulk3.Text == "") && (ddlbulkApvd_3.SelectedIndex != 0))
                //    bcheck = false;

                //if ((TxtFabricqty3.Text != "") && (ddlQtyApvd_3.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtInitial3.Text != "") && (ddlinitial_3.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtbulk3.Text != "") && (ddlbulkApvd_3.SelectedIndex == 0))
                //    bcheck = false;
               
            }
            if (FabricType == "4")
            {
                if (ddlQtyApvd_4.Enabled == true)
                {
                    if ((TxtFabricqty4.Text != "") && (ddlQtyApvd_4.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlinitial_4.Enabled == true)
                {
                    if ((txtInitial4.Text != "") && (ddlinitial_4.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlbulkApvd_4.Enabled == true)
                {
                    if ((txtbulk4.Text != "") && (ddlbulkApvd_4.SelectedIndex != 0))
                        bcheck = true;
                }    

                //if ((ddlQtyApvd_4.Enabled == true) && (TxtFabricqty4.Text == "") && (ddlQtyApvd_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlinitial_4.Enabled == true) && (txtInitial4.Text == "") && (ddlinitial_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlbulkApvd_4.Enabled == true) && (txtbulk4.Text == "") && (ddlbulkApvd_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((TxtFabricqty4.Text != "") && (ddlQtyApvd_4.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtInitial4.Text != "") && (ddlinitial_4.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtbulk4.Text != "") && (ddlbulkApvd_4.SelectedIndex == 0))
                //    bcheck = false;
               
                
            }
            if (FabricType == "5")
            {
                if (ddlQtyApvd_5.Enabled == true)
                {
                    if ((TxtFabricqty5.Text != "") && (ddlQtyApvd_5.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlinitial_5.Enabled == true)
                {
                    if ((txtInitial5.Text != "") && (ddlinitial_5.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlbulkApvd_5.Enabled == true)
                {
                    if ((txtbulk5.Text != "") && (ddlbulkApvd_5.SelectedIndex != 0))
                        bcheck = true;
                }

                //if ((ddlQtyApvd_4.Enabled == true) && (TxtFabricqty4.Text == "") && (ddlQtyApvd_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlinitial_4.Enabled == true) && (txtInitial4.Text == "") && (ddlinitial_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlbulkApvd_4.Enabled == true) && (txtbulk4.Text == "") && (ddlbulkApvd_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((TxtFabricqty4.Text != "") && (ddlQtyApvd_4.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtInitial4.Text != "") && (ddlinitial_4.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtbulk4.Text != "") && (ddlbulkApvd_4.SelectedIndex == 0))
                //    bcheck = false;


            }
            if (FabricType == "6")
            {
                if (ddlQtyApvd_6.Enabled == true)
                {
                    if ((TxtFabricqty6.Text != "") && (ddlQtyApvd_6.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlinitial_6.Enabled == true)
                {
                    if ((txtInitial6.Text != "") && (ddlinitial_6.SelectedIndex != 0))
                        bcheck = true;
                }
                if (ddlbulkApvd_6.Enabled == true)
                {
                    if ((txtbulk6.Text != "") && (ddlbulkApvd_6.SelectedIndex != 0))
                        bcheck = true;
                }

                //if ((ddlQtyApvd_4.Enabled == true) && (TxtFabricqty4.Text == "") && (ddlQtyApvd_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlinitial_4.Enabled == true) && (txtInitial4.Text == "") && (ddlinitial_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((ddlbulkApvd_4.Enabled == true) && (txtbulk4.Text == "") && (ddlbulkApvd_4.SelectedIndex != 0))
                //    bcheck = false;

                //if ((TxtFabricqty4.Text != "") && (ddlQtyApvd_4.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtInitial4.Text != "") && (ddlinitial_4.SelectedIndex == 0))
                //    bcheck = false;

                //if ((txtbulk4.Text != "") && (ddlbulkApvd_4.SelectedIndex == 0))
                //    bcheck = false;


            }
            return bcheck;
        }
        private void SaveFabricWorkingData()
        {
            string differences = "";
            var fabricWorking = new FabricWorking();
            FabricWorking fabricWorking1 = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,FabricType);

            if (FabricType == "1")
            {
                fabricWorking1.FabricRemarks = fabricWorking1.Fabric_ApprovalRemarks;
                fabricWorking.FabricName = fabricWorking1.Fabric.Trim();
            }
            else if (FabricType == "2")
            {
                fabricWorking1.FabricRemarks = fabricWorking1.Fabric_ApprovalRemarks;
                fabricWorking.FabricName = fabricWorking1.Fabric.Trim();
            }
            else if (FabricType == "3")
            {
                fabricWorking1.FabricRemarks = fabricWorking1.Fabric_ApprovalRemarks;
                fabricWorking.FabricName = fabricWorking1.Fabric.Trim();
            }
            else if (FabricType == "4")
            {
                fabricWorking1.FabricRemarks = fabricWorking1.Fabric_ApprovalRemarks;
                fabricWorking.FabricName = fabricWorking1.Fabric.Trim();
            }
            else if (FabricType == "5")
            {
                fabricWorking1.FabricRemarks = fabricWorking1.Fabric_ApprovalRemarks;
                fabricWorking.FabricName = fabricWorking1.Fabric.Trim();
            }
            else if (FabricType == "6")
            {
                fabricWorking1.FabricRemarks = fabricWorking1.Fabric_ApprovalRemarks;
                fabricWorking.FabricName = fabricWorking1.Fabric.Trim();
            }

            fabricWorking.OrderDetailID = OrderDetailID;
            fabricWorking.Type = FabricType;
            fabricWorking.ApprovedByAccountManager = fabricWorking1.ApprovedByAccountManager;

            if (FabricType == "1")
            fabricWorking.PrintColorRecdFabric = chkREFReceived_1.Enabled == true ? (chkREFReceived_1.Checked == true ? 1 : 0) : -1;
            if (FabricType == "2")
            fabricWorking.PrintColorRecdFabric = chkREFReceived_2.Enabled == true ? (chkREFReceived_2.Checked == true ? 1 : 0) : -1;
            if (FabricType == "3")
            fabricWorking.PrintColorRecdFabric = chkREFReceived_3.Enabled == true ? (chkREFReceived_3.Checked == true ? 1 : 0) : -1;
            if (FabricType == "4")
            fabricWorking.PrintColorRecdFabric = chkREFReceived_4.Enabled == true ? (chkREFReceived_4.Checked == true ? 1 : 0) : -1;
            if (FabricType == "5")
            fabricWorking.PrintColorRecdFabric = chkREFReceived_5.Enabled == true ? (chkREFReceived_5.Checked == true ? 1 : 0) : -1;
            if (FabricType == "6")
            fabricWorking.PrintColorRecdFabric = chkREFReceived_6.Enabled == true ? (chkREFReceived_6.Checked == true ? 1 : 0) : -1;

            if (FabricType == "1")
            fabricWorking.FabricQualtityAprdFabric = ddlQtyApvd_1.Enabled == true ? (ddlQtyApvd_1.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_1.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_1.SelectedValue);
            if (FabricType == "2")
            fabricWorking.FabricQualtityAprdFabric = ddlQtyApvd_2.Enabled == true ? (ddlQtyApvd_2.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_2.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_2.SelectedValue);
            if (FabricType == "3")
            fabricWorking.FabricQualtityAprdFabric = ddlQtyApvd_3.Enabled == true ? (ddlQtyApvd_3.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_3.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_3.SelectedValue);
            if (FabricType == "4")
            fabricWorking.FabricQualtityAprdFabric = ddlQtyApvd_4.Enabled == true ? (ddlQtyApvd_4.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_4.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_4.SelectedValue);
            if (FabricType == "5")
            fabricWorking.FabricQualtityAprdFabric = ddlQtyApvd_5.Enabled == true ? (ddlQtyApvd_5.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_5.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_5.SelectedValue);
            if (FabricType == "6")
            fabricWorking.FabricQualtityAprdFabric = ddlQtyApvd_6.Enabled == true ? (ddlQtyApvd_6.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlQtyApvd_6.SelectedValue)) : Convert.ToInt32(ddlQtyApvd_6.SelectedValue);

            if (FabricType == "1")
            fabricWorking.IntialAprdFabric = ddlinitial_1.Enabled == true ? (ddlinitial_1.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_1.SelectedValue)) : Convert.ToInt32(ddlinitial_1.SelectedValue);
            if (FabricType == "2")
            fabricWorking.IntialAprdFabric = ddlinitial_2.Enabled == true ? (ddlinitial_2.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_2.SelectedValue)) : Convert.ToInt32(ddlinitial_2.SelectedValue);
            if (FabricType == "3")
            fabricWorking.IntialAprdFabric = ddlinitial_3.Enabled == true ? (ddlinitial_3.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_3.SelectedValue)) : Convert.ToInt32(ddlinitial_3.SelectedValue);
            if (FabricType == "4")
            fabricWorking.IntialAprdFabric = ddlinitial_4.Enabled == true ? (ddlinitial_4.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_4.SelectedValue)) : Convert.ToInt32(ddlinitial_4.SelectedValue);
            if (FabricType == "5")
            fabricWorking.IntialAprdFabric = ddlinitial_5.Enabled == true ? (ddlinitial_5.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_5.SelectedValue)) : Convert.ToInt32(ddlinitial_5.SelectedValue);
            if (FabricType == "6")
            fabricWorking.IntialAprdFabric = ddlinitial_6.Enabled == true ? (ddlinitial_6.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlinitial_6.SelectedValue)) : Convert.ToInt32(ddlinitial_6.SelectedValue);



            if (FabricType == "1")
            fabricWorking.BulkAprdFabric = ddlbulkApvd_1.Enabled == true ? (ddlbulkApvd_1.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_1.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_1.SelectedValue);
            if (FabricType == "2")
                fabricWorking.BulkAprdFabric = ddlbulkApvd_2.Enabled == true ? (ddlbulkApvd_2.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_2.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_2.SelectedValue);
            if (FabricType == "3")
                fabricWorking.BulkAprdFabric = ddlbulkApvd_3.Enabled == true ? (ddlbulkApvd_3.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_3.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_3.SelectedValue);
            if (FabricType == "4")
                fabricWorking.BulkAprdFabric = ddlbulkApvd_4.Enabled == true ? (ddlbulkApvd_4.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_4.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_4.SelectedValue);
            if (FabricType == "5")
                fabricWorking.BulkAprdFabric = ddlbulkApvd_5.Enabled == true ? (ddlbulkApvd_5.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_5.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_5.SelectedValue);
            if (FabricType == "6")
                fabricWorking.BulkAprdFabric = ddlbulkApvd_6.Enabled == true ? (ddlbulkApvd_6.SelectedValue == "-1" ? -1 : Convert.ToInt32(ddlbulkApvd_6.SelectedValue)) : Convert.ToInt32(ddlbulkApvd_6.SelectedValue);


            //-----------
            if (FabricType == "1")
            fabricWorking.PrintQly = txtprintqnty1.Enabled == true ? (txtprintqnty1.Text == "" ? "" : (DateHelper.ParseDate(txtprintqnty1.Text).Value.ToString())) : "";
            if (FabricType == "2")
            fabricWorking.PrintQly = txtprintqty2.Enabled == true ? (txtprintqty2.Text == "" ? "" : (DateHelper.ParseDate(txtprintqty2.Text).Value.ToString())) : "";
            if (FabricType == "3")
            fabricWorking.PrintQly = txtprintqty3.Enabled == true ? (txtprintqty3.Text == "" ? "" : (DateHelper.ParseDate(txtprintqty3.Text).Value.ToString())) : "";
            if (FabricType == "4")
            fabricWorking.PrintQly = txtprintqty4.Enabled == true ? (txtprintqty4.Text == "" ? "" : (DateHelper.ParseDate(txtprintqty4.Text).Value.ToString())) : "";
            if (FabricType == "5")
            fabricWorking.PrintQly = txtprintqty5.Enabled == true ? (txtprintqty5.Text == "" ? "" : (DateHelper.ParseDate(txtprintqty5.Text).Value.ToString())) : "";
            if (FabricType == "6")
            fabricWorking.PrintQly = txtprintqty6.Enabled == true ? (txtprintqty6.Text == "" ? "" : (DateHelper.ParseDate(txtprintqty6.Text).Value.ToString())) : "";

            if (FabricType == "1")
            fabricWorking.FabQtyIntial = TxtFabricqty1.Enabled == true ? (TxtFabricqty1.Text == "" ? "" : (DateHelper.ParseDate(TxtFabricqty1.Text).Value.ToString())) : "";
            if (FabricType == "2")
            fabricWorking.FabQtyIntial = TxtFabricqty2.Enabled == true ? (TxtFabricqty2.Text == "" ? "" : (DateHelper.ParseDate(TxtFabricqty2.Text).Value.ToString())) : "";
            if (FabricType == "3")
            fabricWorking.FabQtyIntial = TxtFabricqty3.Enabled == true ? (TxtFabricqty3.Text == "" ? "" : (DateHelper.ParseDate(TxtFabricqty3.Text).Value.ToString())) : "";
            if (FabricType == "4")
            fabricWorking.FabQtyIntial = TxtFabricqty4.Enabled == true ? (TxtFabricqty4.Text == "" ? "" : (DateHelper.ParseDate(TxtFabricqty4.Text).Value.ToString())) : "";
            if (FabricType == "5")
            fabricWorking.FabQtyIntial = TxtFabricqty5.Enabled == true ? (TxtFabricqty5.Text == "" ? "" : (DateHelper.ParseDate(TxtFabricqty5.Text).Value.ToString())) : "";
            if (FabricType == "6")
            fabricWorking.FabQtyIntial = TxtFabricqty6.Enabled == true ? (TxtFabricqty6.Text == "" ? "" : (DateHelper.ParseDate(TxtFabricqty6.Text).Value.ToString())) : "";

            if (FabricType == "1")
            fabricWorking.Intial = txtInitial1.Enabled == true ? (txtInitial1.Text == "" ? "" : (DateHelper.ParseDate(txtInitial1.Text).Value.ToString())) : "";
            if (FabricType == "2")
            fabricWorking.Intial = txtInitial2.Enabled == true ? (txtInitial2.Text == "" ? "" : (DateHelper.ParseDate(txtInitial2.Text).Value.ToString())) : "";
            if (FabricType == "3")
            fabricWorking.Intial = txtInitial3.Enabled == true ? (txtInitial3.Text == "" ? "" : (DateHelper.ParseDate(txtInitial3.Text).Value.ToString())) : "";
            if (FabricType == "4")
            fabricWorking.Intial = txtInitial4.Enabled == true ? (txtInitial4.Text == "" ? "" : (DateHelper.ParseDate(txtInitial4.Text).Value.ToString())) : "";
            if (FabricType == "5")
            fabricWorking.Intial = txtInitial5.Enabled == true ? (txtInitial5.Text == "" ? "" : (DateHelper.ParseDate(txtInitial5.Text).Value.ToString())) : "";
            if (FabricType == "6")
            fabricWorking.Intial = txtInitial6.Enabled == true ? (txtInitial6.Text == "" ? "" : (DateHelper.ParseDate(txtInitial6.Text).Value.ToString())) : "";

            if (FabricType == "1")
            fabricWorking.BulkIntial = txtbulk1.Enabled == true ? (txtbulk1.Text == "" ? "" : (DateHelper.ParseDate(txtbulk1.Text).Value.ToString())) : "";
            if (FabricType == "2")
            fabricWorking.BulkIntial = txtbulk2.Enabled == true ? (txtbulk2.Text == "" ? "" : (DateHelper.ParseDate(txtbulk2.Text).Value.ToString())) : "";
            if (FabricType == "3")
            fabricWorking.BulkIntial = txtbulk3.Enabled == true ? (txtbulk3.Text == "" ? "" : (DateHelper.ParseDate(txtbulk3.Text).Value.ToString())) : "";
            if (FabricType == "4")
            fabricWorking.BulkIntial = txtbulk4.Enabled == true ? (txtbulk4.Text == "" ? "" : (DateHelper.ParseDate(txtbulk4.Text).Value.ToString())) : "";
            if (FabricType == "5")
            fabricWorking.BulkIntial = txtbulk5.Enabled == true ? (txtbulk5.Text == "" ? "" : (DateHelper.ParseDate(txtbulk5.Text).Value.ToString())) : "";
            if (FabricType == "6")
            fabricWorking.BulkIntial = txtbulk6.Enabled == true ? (txtbulk6.Text == "" ? "" : (DateHelper.ParseDate(txtbulk6.Text).Value.ToString())) : "";
            //-----------
            
            fabricWorking.OrderID = OrderID;
            fabricWorking.ClientID = ClientID;
            fabricWorking.FabricDetails = FabricDetails.Trim();


            bool FabricSection1 = false, FabricSection2 = false, FabricSection3 = false, FabricSection4 = false, FabricSection5 = false, FabricSection6 = false; 
            //bool FabricSection5 = false, FabricSection6 = false;
            if (FabricType == "1")
            {
                if (!string.IsNullOrEmpty(fabricWorking1.Fabric))
                    FabricSection1 = true;
            }
            if (FabricType == "2")
            {
                if (!string.IsNullOrEmpty(fabricWorking1.Fabric))
                    FabricSection2 = true;
            }
            if (FabricType == "3")
            {
                if (!string.IsNullOrEmpty(fabricWorking1.Fabric))
                    FabricSection3 = true;
            }
            if (FabricType == "4")
            {
                if (!string.IsNullOrEmpty(fabricWorking1.Fabric))
                    FabricSection4 = true;
            }
            if (FabricType == "5")
            {
                if (!string.IsNullOrEmpty(fabricWorking1.Fabric))
                    FabricSection5 = true;
            }
            if (FabricType == "6")
            {
                if (!string.IsNullOrEmpty(fabricWorking1.Fabric))
                    FabricSection6 = true;
            }
            

            //fabricWorking.FabricRemarks = txtRemarks.Text.Trim();
            //if (!string.IsNullOrEmpty(fabricWorking.FabricRemarks))
            //{
            //    fabricWorking.FabricRemarks = "$$ Fabric Approval: " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + DateTime.Now.ToString("dd MMM yy (ddd)") + " -: " + fabricWorking.FabricRemarks;
            //}

            differences = ShowDifferences(fabricWorking, fabricWorking1,FabricType);
            if (!String.IsNullOrEmpty(fabricWorking1.FabricRemarks))
                fabricWorking.FabricRemarks = fabricWorking1.FabricRemarks + "$$" + differences + (!string.IsNullOrEmpty(txtRemarks.Text.Trim()) ? "$$<span style='color:Blue'>Remarks: </span>" + txtRemarks.Text.Trim():"");
            else
                fabricWorking.FabricRemarks = differences + (!string.IsNullOrEmpty(txtRemarks.Text.Trim()) ? "$$<span style='color:Blue'>Remarks: </span>" + txtRemarks.Text.Trim() : "");

            var issaved = FabricWorkingControllerInstance.Update_FabricApproval_PopUp(fabricWorking, FabricSection1, FabricSection2, FabricSection3, FabricSection4,Flags);
            if (issaved)
            {
                ShowAlert("Informations saved successfully!");
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "setTimeout(function(){ window.parent.Shadowbox.close();}, 100);", true);               
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool CheckValidation = Validation();
            if (CheckValidation == true)
            {
                Flags = "";
                SaveFabricWorkingData();
                
            }
            else if (Validationref() == true)
            {
                Flags = "TRUE";
                SaveFabricWorkingData();
            }
            else
            {
                lblErrormsg.Visible = true;
                lblErrormsg.Text = "Please select date and status!";
            }
        }
        protected void ddlQtyApvd_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"1");
            if (ddlQtyApvd_1.SelectedValue != "-1")
            {
                if (ddlQtyApvd_1.SelectedValue == "2")
                {
                    ddlinitial_1.Enabled = true;
                    ddlinitial_1.SelectedValue = fabricWorking_new.IntialAprdFabric == 0 ? "-1" : fabricWorking_new.IntialAprdFabric.ToString();
                }
                else
                {
                    ddlinitial_1.SelectedValue = fabricWorking_new.IntialAprdFabric == 0 ? "-1" : fabricWorking_new.IntialAprdFabric.ToString();
                    ddlinitial_1.Enabled = false;
                }
            }
            else
            {
                ddlinitial_1.Enabled = false;
            }

        }

        protected void ddlinitial_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"1");
            if (ddlinitial_1.SelectedValue != "-1")
            {
                if (ddlinitial_1.SelectedValue == "2")
                {
                    ddlbulkApvd_1.Enabled = true;
                    ddlbulkApvd_1.SelectedValue = fabricWorking_new.BulkAprdFabric == 0 ? "-1" : fabricWorking_new.BulkAprdFabric.ToString();
                }
                else
                {
                    ddlbulkApvd_1.SelectedValue = fabricWorking_new.BulkAprdFabric == 0 ? "-1" : fabricWorking_new.BulkAprdFabric.ToString();
                    ddlbulkApvd_1.Enabled = false;
                }
            }
            else
            {
                ddlbulkApvd_1.Enabled = false;
            }

        }

        protected void ddlQtyApvd_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"2");
            if (ddlQtyApvd_2.SelectedValue != "-1")
            {
                if (ddlQtyApvd_2.SelectedValue == "2")
                {
                    ddlinitial_2.Enabled = true;
                    ddlinitial_2.SelectedValue = fabricWorking_new.IntialAprdFabric == 0 ? "-1" : fabricWorking_new.IntialAprdFabric.ToString();
                }
                else
                {
                    ddlinitial_2.SelectedValue = fabricWorking_new.IntialAprdFabric == 0 ? "-1" : fabricWorking_new.IntialAprdFabric.ToString();
                    ddlinitial_2.Enabled = false;
                }
            }
            else
            {
                ddlinitial_2.Enabled = false;
            }


        }

        protected void ddlinitial_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"2");
            if (ddlinitial_2.SelectedValue != "-1")
            {
                if (ddlinitial_2.SelectedValue == "2")
                {
                    ddlbulkApvd_2.Enabled = true;
                    ddlbulkApvd_2.SelectedValue = fabricWorking_new.BulkAprdFabric == 0 ? "-1" : fabricWorking_new.BulkAprdFabric.ToString();
                }
                else
                {
                    ddlbulkApvd_2.SelectedValue = fabricWorking_new.BulkAprdFabric == 0 ? "-1" : fabricWorking_new.BulkAprdFabric.ToString();
                    ddlbulkApvd_2.Enabled = false;
                }
            }
            else
            {
                ddlbulkApvd_2.Enabled = false;
            }

        }

        protected void ddlQtyApvd_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"3");
            if (ddlQtyApvd_3.SelectedValue != "-1")
            {
                if (ddlQtyApvd_3.SelectedValue == "2")
                {
                    ddlinitial_3.Enabled = true;
                    ddlinitial_3.SelectedValue = fabricWorking_new.IntialAprdFabric == 0 ? "-1" : fabricWorking_new.IntialAprdFabric.ToString();
                }
                else
                {
                    ddlinitial_3.SelectedValue = fabricWorking_new.IntialAprdFabric == 0 ? "-1" : fabricWorking_new.IntialAprdFabric.ToString();
                    ddlinitial_3.Enabled = false;
                }
            }
            else
            {
                ddlinitial_3.Enabled = false;
            }
        }

        protected void ddlinitial_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"3");
            if (ddlinitial_3.SelectedValue != "-1")
            {
                if (ddlinitial_3.SelectedValue == "2")
                {
                    ddlbulkApvd_3.Enabled = true;
                    ddlbulkApvd_3.SelectedValue = fabricWorking_new.BulkAprdFabric == 0 ? "-1" : fabricWorking_new.BulkAprdFabric.ToString();
                }
                else
                {
                    ddlbulkApvd_3.SelectedValue = fabricWorking_new.BulkAprdFabric == 0 ? "-1" : fabricWorking_new.BulkAprdFabric.ToString();
                    ddlbulkApvd_3.Enabled = false;
                }
            }
            else
            {
                ddlbulkApvd_3.Enabled = false;
            }

        }

        protected void ddlQtyApvd_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"4");
            if (ddlQtyApvd_4.SelectedValue != "-1")
            {
                if (ddlQtyApvd_4.SelectedValue == "2")
                {
                    ddlinitial_4.Enabled = true;
                    ddlinitial_4.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                }
                else
                {
                    ddlinitial_4.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                    ddlinitial_4.Enabled = false;
                }
            }
            else
            {
                ddlinitial_4.Enabled = false;
            }
        }
        protected void ddlQtyApvd_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"5");
            if (ddlQtyApvd_5.SelectedValue != "-1")
            {
                if (ddlQtyApvd_5.SelectedValue == "2")
                {
                    ddlinitial_5.Enabled = true;
                    ddlinitial_5.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                }
                else
                {
                    ddlinitial_5.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                    ddlinitial_5.Enabled = false;
                }
            }
            else
            {
                ddlinitial_5.Enabled = false;
            }
        }
        protected void ddlQtyApvd_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"6");
            if (ddlQtyApvd_6.SelectedValue != "-1")
            {
                if (ddlQtyApvd_6.SelectedValue == "2")
                {
                    ddlinitial_6.Enabled = true;
                    ddlinitial_6.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                }
                else
                {
                    ddlinitial_6.SelectedValue = fabricWorking.IntialAprdFabric == 0 ? "-1" : fabricWorking.IntialAprdFabric.ToString();
                    ddlinitial_6.Enabled = false;
                }
            }
            else
            {
                ddlinitial_6.Enabled = false;
            }
        }

        protected void ddlinitial_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"4");
            if (ddlinitial_4.SelectedValue != "-1")
            {
                if (ddlinitial_4.SelectedValue == "2")
                {
                    ddlbulkApvd_4.Enabled = true;
                    ddlbulkApvd_4.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                }
                else
                {
                    ddlbulkApvd_4.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                    ddlbulkApvd_4.Enabled = false;
                }
            }
            else
            {
                ddlbulkApvd_4.Enabled = false;
            }
        }
        protected void ddlinitial_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"5");
            if (ddlinitial_5.SelectedValue != "-1")
            {
                if (ddlinitial_5.SelectedValue == "2")
                {
                    ddlbulkApvd_5.Enabled = true;
                    ddlbulkApvd_5.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                }
                else
                {
                    ddlbulkApvd_5.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                    ddlbulkApvd_5.Enabled = false;
                }
            }
            else
            {
                ddlbulkApvd_5.Enabled = false;
            }
        }
        protected void ddlinitial_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            FabricWorking fabricWorking_new = FabricWorkingControllerInstance.Get_FabricApprovalDetails(OrderDetailID,"6");
            if (ddlinitial_6.SelectedValue != "-1")
            {
                if (ddlinitial_6.SelectedValue == "2")
                {
                    ddlbulkApvd_6.Enabled = true;
                    ddlbulkApvd_6.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                }
                else
                {
                    ddlbulkApvd_6.SelectedValue = fabricWorking.BulkAprdFabric == 0 ? "-1" : fabricWorking.BulkAprdFabric.ToString();
                    ddlbulkApvd_6.Enabled = false;
                }
            }
            else
            {
                ddlbulkApvd_6.Enabled = false;
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #region 
        private string ShowDifferences(FabricWorking fabricWorking, FabricWorking fabricWorkingOld, string FabricType)
        {
            string differences = "";
            var FabricQualtityAprdFabricOldText = "N/A";
            var IntialAprdFabricOldText = "N/A";
            var QtyApvd="";
            var initial="";
            var BulkAprdFabricOldText = "N/A";
            var bulkApvd="";
            if (FabricType == "1")
            {
                
                fabricWorkingOld.FabricQualtityAprdFabric = fabricWorkingOld.FabricQualtityAprdFabric == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric;
                if (fabricWorkingOld.FabricQualtityAprdFabric == 1)
                 FabricQualtityAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 2)
                    FabricQualtityAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 3)
                    FabricQualtityAprdFabricOldText = "Rejected";
                QtyApvd = ddlQtyApvd_1.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_1.SelectedItem.Text;
                
                fabricWorkingOld.IntialAprdFabric = fabricWorkingOld.IntialAprdFabric == 0 ? -1 : fabricWorkingOld.IntialAprdFabric;
                if (fabricWorkingOld.IntialAprdFabric == 1)
                    IntialAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.IntialAprdFabric == 2)
                    IntialAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.IntialAprdFabric == 3)
                    IntialAprdFabricOldText = "Rejected";
                initial = ddlinitial_1.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_1.SelectedItem.Text;
               
                fabricWorkingOld.BulkAprdFabric = fabricWorkingOld.BulkAprdFabric == 0 ? -1 : fabricWorkingOld.BulkAprdFabric;
                if (fabricWorkingOld.BulkAprdFabric == 1)
                    BulkAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.BulkAprdFabric == 2)
                    BulkAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.BulkAprdFabric == 3)
                    BulkAprdFabricOldText = "Rejected";

                bulkApvd = ddlbulkApvd_1.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_1.SelectedItem.Text;
                if (fabricWorking.FabricQualtityAprdFabric != fabricWorkingOld.FabricQualtityAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric1 for Fabric Qlty Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  QtyApvd + " was " + FabricQualtityAprdFabricOldText;
                }
                if (fabricWorking.IntialAprdFabric != fabricWorkingOld.IntialAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric1 for Initial Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  initial + " was " + IntialAprdFabricOldText;
                }
                if (fabricWorking.BulkAprdFabric != fabricWorkingOld.BulkAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric1 for Bulk Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  bulkApvd + " was " + BulkAprdFabricOldText;
                }
            }
            if (FabricType == "2")
            {

                fabricWorkingOld.FabricQualtityAprdFabric = fabricWorkingOld.FabricQualtityAprdFabric == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric;
                if (fabricWorkingOld.FabricQualtityAprdFabric == 1)
                    FabricQualtityAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 2)
                    FabricQualtityAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 3)
                    FabricQualtityAprdFabricOldText = "Rejected";
                QtyApvd = ddlQtyApvd_2.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_2.SelectedItem.Text;

                fabricWorkingOld.IntialAprdFabric = fabricWorkingOld.IntialAprdFabric == 0 ? -1 : fabricWorkingOld.IntialAprdFabric;
                if (fabricWorkingOld.IntialAprdFabric == 1)
                    IntialAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.IntialAprdFabric == 2)
                    IntialAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.IntialAprdFabric == 3)
                    IntialAprdFabricOldText = "Rejected";
                initial = ddlinitial_2.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_2.SelectedItem.Text;

                fabricWorkingOld.BulkAprdFabric = fabricWorkingOld.BulkAprdFabric == 0 ? -1 : fabricWorkingOld.BulkAprdFabric;
                if (fabricWorkingOld.BulkAprdFabric == 1)
                    BulkAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.BulkAprdFabric == 2)
                    BulkAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.BulkAprdFabric == 3)
                    BulkAprdFabricOldText = "Rejected";

                bulkApvd = ddlbulkApvd_2.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_2.SelectedItem.Text;
                if (fabricWorking.FabricQualtityAprdFabric != fabricWorkingOld.FabricQualtityAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric2 for Fabric Qlty Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  QtyApvd + " was " + FabricQualtityAprdFabricOldText;
                }
                if (fabricWorking.IntialAprdFabric != fabricWorkingOld.IntialAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric2 for Initial Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  initial + " was " + IntialAprdFabricOldText;
                }
                if (fabricWorking.BulkAprdFabric != fabricWorkingOld.BulkAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric2 for Bulk Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  bulkApvd + " was " + BulkAprdFabricOldText;
                }
            }
            if (FabricType == "3")
            {

                fabricWorkingOld.FabricQualtityAprdFabric = fabricWorkingOld.FabricQualtityAprdFabric == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric;
                if (fabricWorkingOld.FabricQualtityAprdFabric == 1)
                    FabricQualtityAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 2)
                    FabricQualtityAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 3)
                    FabricQualtityAprdFabricOldText = "Rejected";
                QtyApvd = ddlQtyApvd_3.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_3.SelectedItem.Text;

                fabricWorkingOld.IntialAprdFabric = fabricWorkingOld.IntialAprdFabric == 0 ? -1 : fabricWorkingOld.IntialAprdFabric;
                if (fabricWorkingOld.IntialAprdFabric == 1)
                    IntialAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.IntialAprdFabric == 2)
                    IntialAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.IntialAprdFabric == 3)
                    IntialAprdFabricOldText = "Rejected";
                initial = ddlinitial_3.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_3.SelectedItem.Text;

                fabricWorkingOld.BulkAprdFabric = fabricWorkingOld.BulkAprdFabric == 0 ? -1 : fabricWorkingOld.BulkAprdFabric;
                if (fabricWorkingOld.BulkAprdFabric == 1)
                    BulkAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.BulkAprdFabric == 2)
                    BulkAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.BulkAprdFabric == 3)
                    BulkAprdFabricOldText = "Rejected";

                bulkApvd = ddlbulkApvd_3.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_3.SelectedItem.Text;
                if (fabricWorking.FabricQualtityAprdFabric != fabricWorkingOld.FabricQualtityAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric3 for Fabric Qlty Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  QtyApvd + " was " + FabricQualtityAprdFabricOldText;
                }
                if (fabricWorking.IntialAprdFabric != fabricWorkingOld.IntialAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric3 for Initial Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  initial + " was " + IntialAprdFabricOldText;
                }
                if (fabricWorking.BulkAprdFabric != fabricWorkingOld.BulkAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric3 for Bulk Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  bulkApvd + " was " + BulkAprdFabricOldText;
                }
            }
            if (FabricType == "4")
            {

                fabricWorkingOld.FabricQualtityAprdFabric = fabricWorkingOld.FabricQualtityAprdFabric == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric;
                if (fabricWorkingOld.FabricQualtityAprdFabric == 1)
                    FabricQualtityAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 2)
                    FabricQualtityAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 3)
                    FabricQualtityAprdFabricOldText = "Rejected";
                QtyApvd = ddlQtyApvd_4.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_4.SelectedItem.Text;

                fabricWorkingOld.IntialAprdFabric = fabricWorkingOld.IntialAprdFabric == 0 ? -1 : fabricWorkingOld.IntialAprdFabric;
                if (fabricWorkingOld.IntialAprdFabric == 1)
                    IntialAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.IntialAprdFabric == 2)
                    IntialAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.IntialAprdFabric == 3)
                    IntialAprdFabricOldText = "Rejected";
                initial = ddlinitial_4.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_4.SelectedItem.Text;

                fabricWorkingOld.BulkAprdFabric = fabricWorkingOld.BulkAprdFabric == 0 ? -1 : fabricWorkingOld.BulkAprdFabric;
                if (fabricWorkingOld.BulkAprdFabric == 1)
                    BulkAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.BulkAprdFabric == 2)
                    BulkAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.BulkAprdFabric == 3)
                    BulkAprdFabricOldText = "Rejected";

                bulkApvd = ddlbulkApvd_4.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_4.SelectedItem.Text;
                if (fabricWorking.FabricQualtityAprdFabric != fabricWorkingOld.FabricQualtityAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric4 for Fabric Qlty Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  QtyApvd + " was " + FabricQualtityAprdFabricOldText;
                }
                if (fabricWorking.IntialAprdFabric != fabricWorkingOld.IntialAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric4 for Initial Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  initial + " was " + IntialAprdFabricOldText;
                }
                if (fabricWorking.BulkAprdFabric != fabricWorkingOld.BulkAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric4 for Bulk Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  bulkApvd + " was " + BulkAprdFabricOldText;
                }
            }
            if (FabricType == "5")
            {

                fabricWorkingOld.FabricQualtityAprdFabric = fabricWorkingOld.FabricQualtityAprdFabric == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric;
                if (fabricWorkingOld.FabricQualtityAprdFabric == 1)
                    FabricQualtityAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 2)
                    FabricQualtityAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 3)
                    FabricQualtityAprdFabricOldText = "Rejected";
                QtyApvd = ddlQtyApvd_5.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_5.SelectedItem.Text;

                fabricWorkingOld.IntialAprdFabric = fabricWorkingOld.IntialAprdFabric == 0 ? -1 : fabricWorkingOld.IntialAprdFabric;
                if (fabricWorkingOld.IntialAprdFabric == 1)
                    IntialAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.IntialAprdFabric == 2)
                    IntialAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.IntialAprdFabric == 3)
                    IntialAprdFabricOldText = "Rejected";
                initial = ddlinitial_5.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_5.SelectedItem.Text;

                fabricWorkingOld.BulkAprdFabric = fabricWorkingOld.BulkAprdFabric == 0 ? -1 : fabricWorkingOld.BulkAprdFabric;
                if (fabricWorkingOld.BulkAprdFabric == 1)
                    BulkAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.BulkAprdFabric == 2)
                    BulkAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.BulkAprdFabric == 3)
                    BulkAprdFabricOldText = "Rejected";

                bulkApvd = ddlbulkApvd_5.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_5.SelectedItem.Text;
                if (fabricWorking.FabricQualtityAprdFabric != fabricWorkingOld.FabricQualtityAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric5 for Fabric Qlty Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  QtyApvd + " was " + FabricQualtityAprdFabricOldText;
                }
                if (fabricWorking.IntialAprdFabric != fabricWorkingOld.IntialAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric5 for Initial Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  initial + " was " + IntialAprdFabricOldText;
                }
                if (fabricWorking.BulkAprdFabric != fabricWorkingOld.BulkAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric5 for Bulk Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  bulkApvd + " was " + BulkAprdFabricOldText;
                }
            }
            if (FabricType == "6")
            {

                fabricWorkingOld.FabricQualtityAprdFabric = fabricWorkingOld.FabricQualtityAprdFabric == 0 ? -1 : fabricWorkingOld.FabricQualtityAprdFabric;
                if (fabricWorkingOld.FabricQualtityAprdFabric == 1)
                    FabricQualtityAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 2)
                    FabricQualtityAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.FabricQualtityAprdFabric == 3)
                    FabricQualtityAprdFabricOldText = "Rejected";
                QtyApvd = ddlQtyApvd_6.SelectedItem.Text == "Select" ? "N/A" : ddlQtyApvd_6.SelectedItem.Text;

                fabricWorkingOld.IntialAprdFabric = fabricWorkingOld.IntialAprdFabric == 0 ? -1 : fabricWorkingOld.IntialAprdFabric;
                if (fabricWorkingOld.IntialAprdFabric == 1)
                    IntialAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.IntialAprdFabric == 2)
                    IntialAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.IntialAprdFabric == 3)
                    IntialAprdFabricOldText = "Rejected";
                initial = ddlinitial_6.SelectedItem.Text == "Select" ? "N/A" : ddlinitial_6.SelectedItem.Text;

                fabricWorkingOld.BulkAprdFabric = fabricWorkingOld.BulkAprdFabric == 0 ? -1 : fabricWorkingOld.BulkAprdFabric;
                if (fabricWorkingOld.BulkAprdFabric == 1)
                    BulkAprdFabricOldText = "Sent for approval";
                else if (fabricWorkingOld.BulkAprdFabric == 2)
                    BulkAprdFabricOldText = "Approved";
                else if (fabricWorkingOld.BulkAprdFabric == 3)
                    BulkAprdFabricOldText = "Rejected";

                bulkApvd = ddlbulkApvd_6.SelectedItem.Text == "Select" ? "N/A" : ddlbulkApvd_6.SelectedItem.Text;
                if (fabricWorking.FabricQualtityAprdFabric != fabricWorkingOld.FabricQualtityAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric6 for Fabric Qlty Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  QtyApvd + " was " + FabricQualtityAprdFabricOldText;
                }
                if (fabricWorking.IntialAprdFabric != fabricWorkingOld.IntialAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric6 for Initial Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  initial + " was " + IntialAprdFabricOldText;
                }
                if (fabricWorking.BulkAprdFabric != fabricWorkingOld.BulkAprdFabric)
                {
                    differences += "$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " +
                                   "Fabric6 for Bulk Aprd changed by " +
                                   ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " +
                                  bulkApvd + " was " + BulkAprdFabricOldText;
                }
            }
            
             
            return differences;
        }
        #endregion
    }
}