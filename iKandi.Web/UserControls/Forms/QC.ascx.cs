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
using System.IO;
using System.Text;


namespace iKandi.Web.UserControls.Forms
{
    public partial class QC : BaseUserControl
    {
        public int OrderDetailID { get; set; }
        public string QualityControlID { get; set; }
        public string InspectionID { get; set; }
        public string Status { get; set; }
        public int OrderID { get; set; }
        public static String Flag
        {
            get;
            set;
        }

        iKandi.Common.QualityControl qualityControl;
        public Int32 EmptyCell = 0;
        public Int32 EmptyCell2 = 0;
        public Int32 EmptyCell3 = 0;
        List<QualityFaultsSubCategory> SubCategoryList = new List<QualityFaultsSubCategory>();
        List<User> users;
        private StringBuilder FaultXml = new StringBuilder();
        private StringBuilder ProcessXml = new StringBuilder();

        int CutQty = 0;
        int ShippedQty = 0;
        int QaFaultQty = 0;
        double QaFaultValue = 0;
        int MazorOccurance = 0;
        int MinorOccurance = 0;
        int CriticalOccurane = 0;
        int ProductivityRowCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            GEtQueryString();
            if (!IsPostBack)
            {
                BindControls();
            }
        }
        public void DiableChecks()
        {
            chkMainLabel1.Enabled = false;
            chkMainLabel2.Enabled = false;
            chkMainLabel3.Enabled = false;


            chkSizeLabel1.Enabled = false;
            chkSizeLabel2.Enabled = false;
            chkSizeLabel3.Enabled = false;


            chkWashCare1.Enabled = false;
            chkWashCare2.Enabled = false;
            chkWashCare3.Enabled = false;


            chkPriceTicket1.Enabled = false;
            chkPriceTicket2.Enabled = false;
            chkPriceTicket3.Enabled = false;


            chkPolybagSticker1.Enabled = false;
            chkPolybagSticker2.Enabled = false;
            chkPolybagSticker3.Enabled = false;


            chkCartonQuality1.Enabled = false;
            chkCartonQuality2.Enabled = false;
            chkCartonQuality3.Enabled = false;


            chkCartonStickers1.Enabled = false;
            chkCartonStickers2.Enabled = false;
            chkCartonStickers3.Enabled = false;


            chkPolybagQuality1.Enabled = false;
            chkPolybagQuality2.Enabled = false;
            chkPolybagQuality3.Enabled = false;


            chkHangers1.Enabled = false;
            chkHangers2.Enabled = false;
            chkHangers3.Enabled = false;

        }

        public void GEtQueryString()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailID"]))
            {
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"].ToString());
            }
            else OrderDetailID = -1;


            if (!string.IsNullOrEmpty(Request.QueryString["QualityControlID"]))
            {
                QualityControlID = Request.QueryString["QualityControlID"].ToString();
            }
            else QualityControlID = "0";

            if (!string.IsNullOrEmpty(Request.QueryString["InspectionID"]))
            {
                InspectionID = Request.QueryString["InspectionID"].ToString();
            }
            else InspectionID = "-10";

        }
        //added by abhishek on 9/6/2016
        public string BindUserComments(int styleid, string flag)
        {

            DataTable dtfabric = new DataTable();
            DataTable dtAccessory = new DataTable();
            DataTable dtFITTING = new DataTable();
            DataTable dtMAKING = new DataTable();
            DataTable dtIMBROIDERY = new DataTable();
            DataTable dtWASHING = new DataTable();
            DataTable dtFINISHING = new DataTable();

            DataSet ds = new DataSet();
            ds = this.QualityControllerInstance.GetQCUserComments(styleid, flag);
            string html = "<table>";
            //html += "<tr>";

            if (ds.Tables.Count > 0)
            {
                dtfabric = ds.Tables[0];
                dtAccessory = ds.Tables[1];
                dtFITTING = ds.Tables[2];
                dtMAKING = ds.Tables[3];
                dtIMBROIDERY = ds.Tables[4];
                dtWASHING = ds.Tables[5];
                dtFINISHING = ds.Tables[6];
                if (dtfabric.Rows.Count > 0)
                {
                    if (dtfabric.Rows[0][1].ToString() == "FABRIC")
                    {
                        html += "<tr>";
                        html += "<td colspan=" + 2 + ">" + "FABRIC" + "</td>";
                        html += "</tr>";
                        int x = 0;
                    Outer:
                        html += "<tr>";
                        html += "<td valign=" + "top" + ">";
                        html += dtfabric.Rows[x][2].ToString();
                        html += "</td>";
                        html += "<td>";
                        for (int j = x; j < dtfabric.Rows.Count; j++)
                        {
                            // RowFilter = Convert.ToInt32(dtfabric.Rows[j][7].ToString());
                            if (dtfabric.Rows[x][2].ToString() == dtfabric.Rows[j][2].ToString())
                            {
                                html += "<div>" + dtfabric.Rows[j][3].ToString() + "</div>";
                            }
                            else
                            {
                                x = j;
                                goto Outer;

                            }

                        }
                        html += "</td>";
                        html += "</tr>";





                    }
                }
                if (dtAccessory.Rows.Count > 0)
                {

                    if (dtAccessory.Rows[0][1].ToString() == "ACCESSORY")
                    {

                        html += "<tr>";

                        html += "<td colspan=" + 2 + ">" + "ACCESSORY" + "</td>";

                        html += "</tr>";

                        int x = 0;
                    Outer:
                        html += "<tr>";
                        html += "<td valign=" + "top" + ">";
                        html += dtAccessory.Rows[x][2].ToString();
                        html += "</td>";

                        html += "<td>";
                        for (int j = x; j < dtAccessory.Rows.Count; j++)
                        {
                            // RowFilter = Convert.ToInt32(dtfabric.Rows[j][7].ToString());
                            if (dtAccessory.Rows[x][2].ToString() == dtAccessory.Rows[j][2].ToString())
                            {
                                html += "<div>" + dtAccessory.Rows[j][3].ToString() + "</div>";

                            }
                            else
                            {
                                x = j;
                                // j = 0;
                                goto Outer;

                            }

                        }
                        html += "</td>";
                        html += "</tr>";

                        //}



                    }
                }
                if (dtFITTING.Rows.Count > 0)
                {

                    if (dtFITTING.Rows[0][1].ToString() == "FITTING")
                    {

                        html += "<tr>";

                        html += "<td colspan=" + 2 + ">" + "FITTING" + "</td>";

                        html += "</tr>";

                        int x = 0;
                    Outer:
                        html += "<tr>";
                        html += "<td valign=" + "top" + ">";
                        html += dtFITTING.Rows[x][2].ToString();
                        html += "</td>";

                        html += "<td>";
                        for (int j = x; j < dtFITTING.Rows.Count; j++)
                        {
                            // RowFilter = Convert.ToInt32(dtfabric.Rows[j][7].ToString());
                            if (dtFITTING.Rows[x][2].ToString() == dtFITTING.Rows[j][2].ToString())
                            {
                                html += "<div>" + dtFITTING.Rows[j][3].ToString() + "</div>";

                            }
                            else
                            {
                                x = j;
                                //j = 0;
                                goto Outer;

                            }

                        }
                        html += "</td>";
                        html += "</tr>";

                        //}



                    }
                }
                if (dtIMBROIDERY.Rows.Count > 0)
                {

                    if (dtIMBROIDERY.Rows[0][1].ToString() == "IMBROIDERY")
                    {

                        html += "<tr>";

                        html += "<td colspan=" + 2 + ">" + "IMBROIDERY" + "</td>";

                        html += "</tr>";

                        int x = 0;
                    Outer:
                        html += "<tr>";
                        html += "<td valign=" + "top" + ">";
                        html += dtIMBROIDERY.Rows[x][2].ToString();
                        html += "</td>";

                        html += "<td>";
                        for (int j = x; j < dtIMBROIDERY.Rows.Count; j++)
                        {
                            // RowFilter = Convert.ToInt32(dtfabric.Rows[j][7].ToString());
                            if (dtIMBROIDERY.Rows[x][2].ToString() == dtIMBROIDERY.Rows[j][2].ToString())
                            {
                                html += "<div>" + dtIMBROIDERY.Rows[j][3].ToString() + "</div>";

                            }
                            else
                            {
                                x = j;
                                // j = 0;
                                goto Outer;

                            }

                        }
                        html += "</td>";
                        html += "</tr>";

                        //}



                    }
                }
                if (dtWASHING.Rows.Count > 0)
                {

                    if (dtWASHING.Rows[0][1].ToString() == "WASHING")
                    {

                        html += "<tr>";

                        html += "<td colspan=" + 2 + ">" + "WASHING" + "</td>";

                        html += "</tr>";

                        int x = 0;
                    Outer:
                        html += "<tr>";
                        html += "<td valign=" + "top" + ">";
                        html += dtWASHING.Rows[x][2].ToString();
                        html += "</td>";

                        html += "<td>";
                        for (int j = x; j < dtWASHING.Rows.Count; j++)
                        {
                            // RowFilter = Convert.ToInt32(dtfabric.Rows[j][7].ToString());
                            if (dtWASHING.Rows[x][2].ToString() == dtWASHING.Rows[j][2].ToString())
                            {
                                html += "<div>" + dtWASHING.Rows[j][3].ToString() + "</div>";

                            }
                            else
                            {
                                x = j;
                                //j = 0;
                                goto Outer;

                            }

                        }
                        html += "</td>";
                        html += "</tr>";

                        //}



                    }
                }
                if (dtFINISHING.Rows.Count > 0)
                {

                    if (dtFINISHING.Rows[0][1].ToString() == "FINISHING")
                    {

                        html += "<tr>";

                        html += "<td colspan=" + 2 + ">" + "FINISHING" + "</td>";

                        html += "</tr>";

                        int x = 0;
                    Outer:
                        html += "<tr>";
                        html += "<td valign=" + "top" + ">";
                        html += dtFINISHING.Rows[x][2].ToString();
                        html += "</td>";

                        html += "<td>";
                        for (int j = x; j < dtFINISHING.Rows.Count; j++)
                        {
                            // RowFilter = Convert.ToInt32(dtfabric.Rows[j][7].ToString());
                            if (dtFINISHING.Rows[x][2].ToString() == dtFINISHING.Rows[j][2].ToString())
                            {
                                html += "<div>" + dtFINISHING.Rows[j][3].ToString() + "</div>";

                            }
                            else
                            {
                                x = j;
                                //j = 0;
                                goto Outer;

                            }

                        }
                        html += "</td>";
                        html += "</tr>";

                        //}



                    }
                }
                if (dtMAKING.Rows.Count > 0)
                {
                    if (dtMAKING.Rows[0][1].ToString() == "MAKING")
                    {

                        html += "<tr>";

                        html += "<td colspan=" + 2 + ">" + "MAKING" + "</td>";

                        html += "</tr>";

                        int x = 0;
                    Outer:
                        html += "<tr>";
                        html += "<td valign=" + "top" + ">";
                        html += dtMAKING.Rows[x][2].ToString();
                        html += "</td>";

                        html += "<td>";
                        for (int j = x; j < dtMAKING.Rows.Count; j++)
                        {
                            // RowFilter = Convert.ToInt32(dtfabric.Rows[j][7].ToString());
                            if (dtMAKING.Rows[x][2].ToString() == dtMAKING.Rows[j][2].ToString())
                            {
                                html += "<div>" + dtMAKING.Rows[j][3].ToString() + "</div>";
                            }
                            else
                            {
                                x = j;
                                //j = 0;
                                goto Outer;

                            }

                        }
                        html += "</td>";
                        html += "</tr>";

                    }
                }
                html += "</table>";


            }
            return html;

        }
        //end by abhishek

        private void BindControls()
        {
            if (OrderDetailID != -1)
            {
                qualityControl = this.QualityControllerInstance.GetQualityControl(OrderDetailID, InspectionID, Convert.ToInt32(QualityControlID));

                DataTable LineManQc = new DataTable();

                DataSet ds = new DataSet();
                ds = QualityControllerInstance.GetQCLineMan(OrderDetailID, Convert.ToInt32(QualityControlID));
                DataTable dtQC = ds.Tables[0];
                DataTable dtUnit = ds.Tables[2];

                if (dtQC.Rows.Count > 0)
                {
                    listQcName.DataSource = dtQC;
                    listQcName.DataTextField = "QcMan";
                    listQcName.DataValueField = "UserID";
                    listQcName.DataBind();

                    for (int irow = 0; irow < dtQC.Rows.Count; irow++)
                    {
                        if (dtQC.Rows[irow]["Selected"].ToString() == "1")
                            listQcName.Items[irow].Selected = true;
                    }

                }
                else
                {
                    lbllineplanPending.Visible = true;
                    btnSubmit.Visible = false;
                    btnSaveAllContracts_Rescan.Visible = false;
                }
                if (ds.Tables.Count > 1)
                {
                    DataTable dtLineMan = ds.Tables[1];

                    if (dtLineMan.Rows.Count > 0)
                    {
                        listLineMan.DataSource = dtLineMan;
                        listLineMan.DataTextField = "LineMan";
                        listLineMan.DataValueField = "UserID";
                        listLineMan.DataBind();

                        for (int irow = 0; irow < dtLineMan.Rows.Count; irow++)
                        {
                            if (dtLineMan.Rows[irow]["Selected"].ToString() == "True" || dtLineMan.Rows[irow]["Selected"].ToString() == "1")
                                listLineMan.Items[irow].Selected = true;
                        }
                    }
                }

                lblClient.Text = qualityControl.OrderDetail.ParentOrder.Client.CompanyName.ToString();
                lblIkandiSerial.Text = qualityControl.OrderDetail.ParentOrder.SerialNumber.ToString();
                lblStyleNumber.Text = qualityControl.OrderDetail.ParentOrder.Style.StyleNumber.ToString();
                lblTotalQty.Text = qualityControl.OrderDetail.Quantity.ToString();
                lblMainFabric.Text = qualityControl.OrderDetail.Fabric1.ToString();
                lblColour.Text = qualityControl.OrderDetail.Fabric1Details;
                lblccgsm.Text = qualityControl.OrderDetail.OrderDetailccgsm;
                lblLineItemNumber.Text = qualityControl.OrderDetail.LineItemNumber.ToString();
                lblContractNumber.Text = qualityControl.OrderDetail.ContractNumber.ToString();
                //  lblUnit.Text = qualityControl.OrderDetail.Unit.FactoryName.ToString();
                ddlUnitID.DataSource = dtUnit;
                ddlUnitID.DataTextField = "Name";
                ddlUnitID.DataValueField = "id";
                ddlUnitID.DataBind();
                //ddlUnitID.SelectedIndex = Convert.ToInt32(qualityControl.OrderDetail.Unit.ProductionUnitId);
                hdnUnitId.Value = qualityControl.OrderDetail.Unit.ProductionUnitId.ToString();


                //if (lblUnit.Text == "C 45-46" || lblUnit.Text == "C 47")
                //    lblChecker.Text = "Factory Mgr | Line man | QC";
                //else
                //    lblChecker.Text = "Factory Mgr | Checker | QC";

                if ((ddlUnitID.SelectedItem.Value == "3") || (ddlUnitID.SelectedItem.Value == "11") || (ddlUnitID.SelectedItem.Value == "96"))
                    lblChecker.Text = "Line man | QC";

                else
                    lblChecker.Text = "Checker | QC";

                if ((ddlUnitID.SelectedItem.Value == "3") || (ddlUnitID.SelectedItem.Value == "11") || (ddlUnitID.SelectedItem.Value == "96"))

                    lblFactoryMgrName.Text = "Factory Mgr";
                else
                    lblFactoryMgrName.Text = "Factory Mgr";

                if (qualityControl.OrderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked != 0)
                {
                    lblPack.Text = qualityControl.OrderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked.ToString();
                }
                if (qualityControl.OrderDetail.ParentOrder.StitchingDetail.OverallPcsStitched != 0)
                {
                    lblStitch.Text = qualityControl.OrderDetail.ParentOrder.StitchingDetail.OverallPcsStitched.ToString() + " " + "(" + qualityControl.OrderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched.ToString() + "%)";
                }

                lblPpmRemarks.Text = this.BindUserComments(qualityControl.OrderDetail.ParentOrder.Style.StyleID, "HOPPM");
                lblReskRemarks.Text = this.BindUserComments(qualityControl.OrderDetail.ParentOrder.Style.StyleID, "RISK");

                int Lastindex = qualityControl.OrderDetail.InlinePPM.FactoryManager.FirstName.ToString().LastIndexOf(" ");
                lblFactoryMgr.Text = qualityControl.OrderDetail.InlinePPM.FactoryManager.FirstName.ToString();//.Substring(0, Lastindex);
                //lblFactoryMgr.Text = qualityControl.OrderDetail.InlinePPM.FactoryManager.FirstName.ToString().Substring(0, Lastindex);
                lblFactoryMgr.ToolTip = qualityControl.OrderDetail.InlinePPM.FactoryManager.FirstName.ToString();
                string sTime = DateTime.Now.ToShortTimeString();
                lblCQD_QAManagerDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblTime.Text = sTime;
                lblShippingOfficerDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblDMMDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblBuyingHouseDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblBuyingHouseFactoryDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                lblBuyingHouseICDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

                lblStatus1.Text = qualityControl.OrderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode.ToString();
                lblQA.Text = qualityControl.OrderDetail.QA;
                hiddenOverallPcsStitched.Value = qualityControl.OrderDetail.ParentOrder.StitchingDetail.OverallPcsStitched.ToString();

                if (!string.IsNullOrEmpty(qualityControl.OrderDetail.TargetDateS))
                {
                    lblTarget.Visible = true;
                    lblTarget.Text = "Target Date: " + qualityControl.OrderDetail.TargetDateS;
                }

                hiddenStyleId.Value = qualityControl.OrderDetail.ParentOrder.Style.StyleID.ToString();
                hdnstylenumber.Value = qualityControl.OrderDetail.ParentOrder.Style.sCodeVersion.ToString();
                hdnOrderId.Value = qualityControl.OrderDetail.OrderID.ToString();
                hdnExFactory.Value = qualityControl.OrderDetail.ExFactory.ToString();
                hdnClientID.Value = qualityControl.OrderDetail.ParentOrder.Client.ClientID.ToString();
                hdnDeptId.Value = qualityControl.OrderDetail.DepartmentID.ToString();
                hdnContractsCount.Value = qualityControl.OrderDetail.ContractsCount;

                txtOtherProcessingInstruction.Enabled = false;
                if (InspectionID == "1" || InspectionID == "-10")
                {
                    lblInspectionName.Text = "Inline";
                    lblInspectionName1.Text = "Inline";
                }
                else if (InspectionID == "2")
                {
                    lblInspectionName.Text = "Mid";
                    lblInspectionName1.Text = "Mid";
                }

                else if (InspectionID == "4")
                {
                    lblInspectionName.Text = "Online";
                    lblInspectionName1.Text = "Online";
                }

                imgSampleImageURL1.ImageUrl = ResolveUrl("~/Uploads/Style/thumb-" + qualityControl.OrderDetail.ParentOrder.Style.SampleImageURL1);


                if ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)26) || (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)17))//CQD/GM QA
                {
                    //chkCQD_QAManager.Enabled = true;
                    chk_BuyingHouse.Enabled = true;
                    chk_BuyingHouseFactory.Enabled = true;
                    chk_BuyingHouseIC.Enabled = true;

                    RBBHPass.Enabled = true;
                    RBBHFail.Enabled = true;
                    txtBHQC.Enabled = true;
                    RBBHFPass.Enabled = true;
                    RBBHFFail.Enabled = true;
                    txtBHFQC.Enabled = true;
                    fldBuyingHouse.Enabled = true;
                    fldBuyingHouseFactory.Enabled = true;
                    fldBuyingHouseIC.Enabled = true;
                    hdnISCQDQA.Value = "1";

                }
                else
                {
                    //chkCQD_QAManager.Enabled = false;
                    chk_BuyingHouse.Enabled = false;
                    chk_BuyingHouseFactory.Enabled = false;
                    chk_BuyingHouseIC.Enabled = false;

                    RBBHPass.Enabled = false;
                    RBBHFail.Enabled = false;
                    txtBHQC.Enabled = false;
                    RBBHFPass.Enabled = false;
                    RBBHFFail.Enabled = false;
                    txtBHFQC.Enabled = false;
                    fldBuyingHouse.Enabled = false;
                    fldBuyingHouseFactory.Enabled = false;
                    fldBuyingHouseIC.Enabled = false;

                }

                if ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)37))//Shipping Officer
                    chk_ShippingOfficer.Enabled = true;
                else
                    chk_ShippingOfficer.Enabled = false;

                if ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)14))//DMM
                {
                    chk_DMM.Enabled = true;
                    txtCommentsBy_DMM.Enabled = true;
                    txtComments.Enabled = false;
                }
                else
                {
                    chk_DMM.Enabled = false;
                    txtCommentsBy_DMM.Enabled = false;
                    txtComments.Enabled = true;
                }

                if (qualityControl.OrderDetail.IsValid == 0 && (InspectionID == "-10" || InspectionID == "1"))
                {
                    btnSubmit.Visible = false;
                    btnSaveAllContracts_Rescan.Visible = false;
                    lblmsg.Text = "You can't submit this form because there is no any task created regarding this contract.";
                    lblmsg.Visible = true;
                }
                PopulateQualityData();

                QualityController qualityControl_Rescan = new QualityController();
                OrderDetailID = hdnOrderDetailID.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailID.Value);
                OrderID = hdnOrderId.Value == "" ? -1 : Convert.ToInt32(hdnOrderId.Value);
                DataTable QCDT_Rescan = qualityControl_Rescan.Get_AllQC_CotractsByOrder_Rescan(OrderID, OrderDetailID, InspectionID, Convert.ToInt32(hiddenQualityControlID.Value)).Tables[0];
                grdAllContracts_Rescan.DataSource = QCDT_Rescan;
                grdAllContracts_Rescan.DataBind();
                ProductivityRowCount = QCDT_Rescan.Rows.Count;
                lblProductivityrowcount.Text = ProductivityRowCount.ToString();
                if (ProductivityRowCount == 0)
                {
                    hypRescanDetails.Visible = false;
                }
                //if (chkCQD_QAManager.Checked) hypRescanDetails
                //{
                //    chkCQD_QAManager.Enabled = false;
                //    //UpdPnlCQD_QAManager.Update();
                //}

                if ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)26) || (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)17))
                {
                    //btnSubmit.Visible = true;
                }
                else
                {
                    if (qualityControl.InspectionID == 1 || qualityControl.InspectionID == 3)
                    {
                        btnSubmit.Visible = false;
                        btnSaveAllContracts_Rescan.Visible = false;
                    }
                }
            }
        }
        //protected void file250PcsUpload_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //  HyperLink imgfile = (HyperLink)e.Item.FindControl("imgfile");
        //  HiddenField hdnfile2 = (HiddenField)e.Item.FindControl("hdnfile2");
        //  string Ext = hdnfile2.Value;
        //  if (Path.GetExtension(Ext) == ".pdf" || Path.GetExtension(Ext) == ".Pdf")
        //  {
        //    imgfile.ImageUrl = "../../images/pdf.png";
        //  }
        //}
        private void PopulateQualityData()
        {
            hdnOrderDetailID.Value = (OrderDetailID).ToString();
            if (iKandi.Common.QualityControl.SQualityId > 0)
            {
                hiddenQualityControlID.Value = iKandi.Common.QualityControl.SQualityId.ToString();
                iKandi.Common.QualityControl.SQualityId = 0;
            }
            else
                hiddenQualityControlID.Value = Convert.ToInt32(QualityControlID) > 0 ? QualityControlID : "0";

            if (OrderDetailID != -1)
            {
                //DataTable dt = this.QualityControllerInstance.GetQcUploadFile(OrderDetailID, hiddenQualityControlID.Value);

                //DataTable dtLineQC = this.QualityControllerInstance.GetQcLinemannew(OrderDetailID, hiddenQualityControlID.Value);
                //if (dtLineQC.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dtLineQC.Rows)
                //    {
                //        if (dr["QcId"].ToString() != "0")
                //        {
                //            listQcName.SelectedValue = dr["QcId"].ToString();
                //        }
                //        else if (dr["LineManId"].ToString() != "0")
                //        {
                //            listLineMan.SelectedValue = dr["LineManId"].ToString();
                //        }
                //    }

                //}

                qualityControl = this.QualityControllerInstance.GetQualityControlBYQuality(OrderDetailID, hiddenQualityControlID.Value, InspectionID);
                //abhsihek 
                if (InspectionID == "1")
                {
                    txtmissfaultcount.Text = (qualityControl.MissedfaultCount == 0 ? "0" : qualityControl.MissedfaultCount.ToString());
                    txtfalutoccu.Text = (qualityControl.TotalOcuured == 0 ? "0" : qualityControl.TotalOcuured.ToString());
                }
                else
                {
                    mminline.Visible = false;
                }
                if (InspectionID == "4")
                {
                    hypRescanDetails.Visible = true;

                }

                hiddenQualityControlID.Value = qualityControl.Id > 0 ? qualityControl.Id.ToString() : "0";

                if (!string.IsNullOrEmpty(qualityControl.InlineTopFiftyReports))
                {
                    //hdnIMgPath.Value = qualityControl.InlineTopFiftyReports;
                    //imgfile50PcsUpload.Src = "~/uploads/Quality/" + qualityControl.InlineTopFiftyReports;
                    //hrefimgfile50PcsUpload.HRef = "~/uploads/Quality/" + qualityControl.InlineTopFiftyReports;
                    //hrefimgfile50PcsUpload.Target = "_blank";
                }

                chkCQD_QAManager.Checked = Convert.ToBoolean(qualityControl.ApprovedByCQD_QAManager);
                if (InspectionID == "3")
                {
                    lblInspectionName.Text = "Final";
                    lblInspectionName1.Text = "Final";
                    if (hdnRadioStatus.Value != "2")
                    {
                        lblPenaltyDesc.Text = "CTSL Detail";
                        tblQAFaults.Style.Add("display", "");
                        hdnBP_CR.Value = qualityControl.BP_CR.ToString();
                        GetQaFault();
                        if (qualityControl.IsShipped == true)
                            txtShippedQty.Enabled = false;
                    }
                }
                // Added By Ravi kumar on 10/1/2017
                if (qualityControl.WithoutNatureOfFaults)
                {
                    chkWithOutNature.Checked = true;
                    DivrptFault.Style.Add("display", "none");
                    rbtnPass.InputAttributes.Add("disabled", "disabled");
                    rbtnFail.InputAttributes.Add("disabled", "disabled");
                }
                if (qualityControl.ApprovedByCQD_QAManager == 1)
                    chkWithOutNature.Enabled = false;

                //Add by Ravi on 22/12/16
                chkGMQA.Checked = Convert.ToBoolean(qualityControl.chkGMQA);
                chkCQD.Checked = Convert.ToBoolean(qualityControl.chkCQD);
                chkFactoryManager.Checked = Convert.ToBoolean(qualityControl.chkFactoryManager);
                chkProdIncharge.Checked = Convert.ToBoolean(qualityControl.chkProdIncharge);
                chkQC.Checked = Convert.ToBoolean(qualityControl.chkQC);
                chkFinishIncharge.Checked = Convert.ToBoolean(qualityControl.chkFinishIncharge);
                chkFinishSuperwisor.Checked = Convert.ToBoolean(qualityControl.chkFinishSuperwisor);
                ckhLineMan.Checked = Convert.ToBoolean(qualityControl.ckhLineMan);
                chkAsstLineMan.Checked = Convert.ToBoolean(qualityControl.chkAsstLineMan);
                chkChecker.Checked = Convert.ToBoolean(qualityControl.chkChecker);
                chkPressMan.Checked = Convert.ToBoolean(qualityControl.chkPressMan);
                chkOthers.Checked = Convert.ToBoolean(qualityControl.chkOthers);
                txtAdditional.Text = qualityControl.AdditionalInformation;

                if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                {
                    repeaterSizes.DataSource = qualityControl.FaultsPP[0].SizesList;
                    repeaterSizes.DataBind();

                    repeaterQtyStock.DataSource = qualityControl.FaultsPP[0].SizesList;
                    repeaterQtyStock.DataBind();

                    repeaterQtyChecked.DataSource = qualityControl.FaultsPP[0].SizesList;
                    repeaterQtyChecked.DataBind();

                    lblDateConducted.Text = (qualityControl.FaultsPP[0].DateConducted != null && qualityControl.FaultsPP[0].DateConducted != DateTime.MinValue) ? qualityControl.FaultsPP[0].DateConducted.ToString("dd MMM yy (ddd)") : DateTime.Now.ToString("dd MMM yy (ddd)");
                    lblQtyFinal.Text = qualityControl.FaultsPP[0].ShippingQty.ToString();
                    lblSampleQty.Text = qualityControl.FaultsPP[0].SampleQuantity.ToString();
                    if (qualityControl.FaultsPP[0].ActualSamplesChecked != 0)
                    {
                        txtActualSamplesChecked.Text = qualityControl.FaultsPP[0].ActualSamplesChecked.ToString();
                    }
                    if (Convert.ToString(qualityControl.UserName) != "")
                    {
                        lblusernameText.Text = Convert.ToString(qualityControl.UserName);
                    }
                    else
                    {
                        lblusernameText.Text = "";
                    }

                    lblAql.Text = qualityControl.FaultsPP[0].AqlValue != null ? qualityControl.FaultsPP[0].AqlValue.ToString() : "";

                    lblMajorAllowed.Text = qualityControl.FaultsPP[0].MajorDefectsAllowed.ToString();
                    lblMinorAllowed.Text = qualityControl.FaultsPP[0].MinorDefectsAllowed.ToString();

                    hdnMajorAllowed.Value = qualityControl.FaultsPP[0].MajorDefectsAllowed.ToString();
                    hdnMinorAllowed.Value = qualityControl.FaultsPP[0].MinorDefectsAllowed.ToString();

                    lblStatus.Text = qualityControl.FaultsPP[0].Status.ToString();
                    hiddenStatus.Value = !(string.IsNullOrEmpty(qualityControl.FaultsPP[0].Status.ToString())) ? qualityControl.FaultsPP[0].Status.ToString() : "PEN.";
                    Status = qualityControl.FaultsPP[0].Status;
                    if (qualityControl.FaultsPP[0].Status.ToUpper() == Convert.ToString("Pass").ToUpper())
                    {
                        hdnRadioStatus.Value = "1";
                        rbtnPass.Checked = true;

                    }
                    else if (qualityControl.FaultsPP[0].Status.ToUpper() == Convert.ToString("Fail").ToUpper())
                    {
                        hdnRadioStatus.Value = "2";
                        chkCQD_QAManager.Enabled = true;
                        rbtnFail.Checked = true;
                    }
                    else
                        hdnRadioStatus.Value = "0";

                    if (qualityControl.FaultsPP[0].CheckingItems != null && qualityControl.FaultsPP[0].CheckingItems.Count > 0)
                    {
                        chkMainLabel1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[0].Missing);
                        chkMainLabel2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[0].NotRequired);
                        chkMainLabel3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[0].Present);
                        HiddenField1.Value = qualityControl.FaultsPP[0].CheckingItems[0].Id.ToString();

                        chkSizeLabel1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[1].Missing);
                        chkSizeLabel2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[1].NotRequired);
                        chkSizeLabel3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[1].Present);
                        HiddenField2.Value = qualityControl.FaultsPP[0].CheckingItems[1].Id.ToString();

                        chkWashCare1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[2].Missing);
                        chkWashCare2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[2].NotRequired);
                        chkWashCare3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[2].Present);
                        HiddenField3.Value = qualityControl.FaultsPP[0].CheckingItems[2].Id.ToString();

                        chkPriceTicket1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[3].Missing);
                        chkPriceTicket2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[3].NotRequired);
                        chkPriceTicket3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[3].Present);
                        HiddenField4.Value = qualityControl.FaultsPP[0].CheckingItems[3].Id.ToString();

                        chkPolybagSticker1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[4].Missing);
                        chkPolybagSticker2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[4].NotRequired);
                        chkPolybagSticker3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[4].Present);
                        HiddenField5.Value = qualityControl.FaultsPP[0].CheckingItems[4].Id.ToString();

                        chkCartonQuality1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[5].Missing);
                        chkCartonQuality2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[5].NotRequired);
                        chkCartonQuality3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[5].Present);
                        HiddenField6.Value = qualityControl.FaultsPP[0].CheckingItems[5].Id.ToString();

                        chkCartonStickers1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[6].Missing);
                        chkCartonStickers2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[6].NotRequired);
                        chkCartonStickers3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[6].Present);
                        HiddenField7.Value = qualityControl.FaultsPP[0].CheckingItems[6].Id.ToString();

                        chkPolybagQuality1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[7].Missing);
                        chkPolybagQuality2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[7].NotRequired);
                        chkPolybagQuality3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[7].Present);
                        HiddenField8.Value = qualityControl.FaultsPP[0].CheckingItems[7].Id.ToString();

                        chkHangers1.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[8].Missing);
                        chkHangers2.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[8].NotRequired);
                        chkHangers3.Checked = Convert.ToBoolean(qualityControl.FaultsPP[0].CheckingItems[8].Present);
                        HiddenField9.Value = qualityControl.FaultsPP[0].CheckingItems[8].Id.ToString();
                    }
                }
                // Add By Ravi kumar on 3/2/2017 for Quality Process Entry
                if (qualityControl.Process != null && qualityControl.Process.Count > 0)
                {
                    gvProcess.DataSource = qualityControl.Process;
                    gvProcess.DataBind();
                }
                //List<List<QualityFaults>> qualityFaults = new List<List<QualityFaults>>();

                if (qualityControl.Id > 0)
                {
                    txtComments.Text = string.Empty;
                    txtCommentsBy_DMM.Text = string.Empty;
                    if (!string.IsNullOrEmpty(qualityControl.Comments))
                    {
                        if (qualityControl.Comments.IndexOf("$$") > -1)
                        {
                            //lblLastComment.Text = qualityControl.Comments.ToString().Substring(qualityControl.Comments.LastIndexOf("$$") + 2);
                            lblLastComment.Text = qualityControl.Comments.ToString().Replace("$$", "<br/>");
                            hdnComment.Value = qualityControl.Comments.ToString().Replace("$$", "<br/>");
                        }
                        else
                        {
                            lblLastComment.Text = qualityControl.Comments.ToString();
                            hdnComment.Value = qualityControl.Comments.ToString();
                        }
                    }

                    //if (!string.IsNullOrEmpty(qualityControl.CommentsBy_DMM))
                    //{
                    //    if (qualityControl.CommentsBy_DMM.IndexOf("$$") > -1)
                    //    {
                    //        //lblLastComment.Text = qualityControl.Comments.ToString().Substring(qualityControl.Comments.LastIndexOf("$$") + 2);
                    //        lblLastCommentBy_DMM.Text = qualityControl.CommentsBy_DMM.ToString().Replace("$$", "<br/>");
                    //        hdnCommentBy_DMM.Value = qualityControl.CommentsBy_DMM.ToString().Replace("$$", "<br/>");
                    //    }
                    //    else
                    //    {
                    //        lblLastCommentBy_DMM.Text = qualityControl.Comments.ToString();
                    //        hdnCommentBy_DMM.Value = qualityControl.Comments.ToString();
                    //    }
                    //}

                    //lblLastComment.Text = qualityControl.Comments.ToString();
                    hdnComment.Value = qualityControl.Comments.ToString();
                    //hdnCommentBy_DMM.Value = qualityControl.CommentsBy_DMM.ToString();

                    chk_ShippingOfficer.Checked = Convert.ToBoolean(qualityControl.ApprovedByShippingOfficer);
                    chk_DMM.Checked = Convert.ToBoolean(qualityControl.ApprovedByDMM);

                    chk_BuyingHouse.Checked = Convert.ToBoolean(qualityControl.ApprovedByBuyingHouse);
                    chk_BuyingHouseFactory.Checked = Convert.ToBoolean(qualityControl.ApprovedByBuyingHouse_Factory);
                    chk_BuyingHouseIC.Checked = Convert.ToBoolean(qualityControl.ApprovedByBuyingHouse_IC);

                    if (qualityControl.BuyingHouse_Status == "1")
                        RBBHPass.Checked = true;
                    else if (qualityControl.BuyingHouse_Status == "2")
                        RBBHFail.Checked = true;

                    if (qualityControl.BuyingHouseFactory_Status == "1")
                        RBBHFPass.Checked = true;
                    else if (qualityControl.BuyingHouseFactory_Status == "2")
                        RBBHFFail.Checked = true;

                    txtBHQC.Text = qualityControl.BuyingHouse_QAName;
                    txtBHFQC.Text = qualityControl.BuyingHouseFactory_QAName;


                    if (qualityControl.ApprovedByCQD_QAManager == 1)
                    {
                        chkCQD_QAManager.Enabled = false;
                        string sTime = qualityControl.ApprovedByCQD_QAManagerOn.ToShortTimeString();
                        lblCQD_QAManagerDate.Text = qualityControl.ApprovedByCQD_QAManagerOn.ToString("dd MMM yy (ddd)");
                        lblTime.Text = sTime;
                    }

                    if (qualityControl.ApprovedByShippingOfficer == 1)
                    {
                        chk_ShippingOfficer.Enabled = false;
                        lblShippingOfficerDate.Text = qualityControl.ApprovedByShippingOfficerOn.ToString("dd MMM yy (ddd)");
                    }

                    if (qualityControl.ApprovedByDMM == 1)
                    {
                        chk_DMM.Enabled = false;
                        lblDMMDate.Text = qualityControl.ApprovedByDMMOn.ToString("dd MMM yy (ddd)");
                    }

                    if (qualityControl.ApprovedByBuyingHouse == 1)
                    {
                        chk_BuyingHouse.Enabled = false;
                        lblBuyingHouseDate.Text = qualityControl.ApprovedByBuyingHouseOn.ToString("dd MMM yy (ddd)");

                        RBBHPass.Enabled = false;
                        RBBHFail.Enabled = false;
                        txtBHQC.Enabled = false;
                        fldBuyingHouse.Enabled = false;
                    }

                    if (qualityControl.ApprovedByBuyingHouse_Factory == 1)
                    {
                        chk_BuyingHouseFactory.Enabled = false;
                        lblBuyingHouseFactoryDate.Text = qualityControl.ApprovedByBuyingHouse_FactoryOn.ToString("dd MMM yy (ddd)");

                        RBBHFPass.Enabled = false;
                        RBBHFFail.Enabled = false;
                        txtBHFQC.Enabled = false;
                        fldBuyingHouseFactory.Enabled = false;
                    }

                    if (qualityControl.ApprovedByBuyingHouse_IC == 1)
                    {
                        chk_BuyingHouseIC.Enabled = false;
                        lblBuyingHouseICDate.Text = qualityControl.ApprovedByBuyingHouse_ICOn.ToString("dd MMM yy (ddd)");
                        fldBuyingHouseIC.Enabled = false;
                    }





                    if (!string.IsNullOrEmpty(qualityControl.BuyingHouse_Factory_FilePath))
                    {
                        hplBuyingHouseFactory.Visible = true;
                        hplBuyingHouseFactory.ImageUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_Factory_FilePath;
                        hplBuyingHouseFactory.NavigateUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_Factory_FilePath;
                    }
                    if (!string.IsNullOrEmpty(qualityControl.BuyingHouse_FilePath))
                    {
                        hplBuyingHouse.Visible = true;
                        hplBuyingHouse.ImageUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_FilePath;
                        hplBuyingHouse.NavigateUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_FilePath;
                    }
                    //abhishek 6/1/2016
                    //if (!string.IsNullOrEmpty(qualityControl.BuyingHouse_IC_FilePath))
                    //{
                    //    hplBuyingHouseIC.Visible = true;
                    //    hplBuyingHouseIC.ImageUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_IC_FilePath;
                    //    hplBuyingHouseIC.NavigateUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_IC_FilePath;
                    //}
                    if (!string.IsNullOrEmpty(qualityControl.BuyingHouse_IC_FilePath))
                    {
                        //hplBuyingHouseIC.Visible = true;
                        //hplBuyingHouseIC.ImageUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_IC_FilePath;
                        //hplBuyingHouseIC.NavigateUrl = "~/uploads/Quality/" + qualityControl.BuyingHouse_IC_FilePath;
                        hdnFldresolutionIE.Value = qualityControl.BuyingHouse_IC_FilePath;
                    }
                    //-end
                    if (qualityControl.ProcessingInstruction == 4)
                    {
                        txtOtherProcessingInstruction.Enabled = true;
                        txtOtherProcessingInstruction.Text = qualityControl.OtherInstruction.ToString();
                        ddlProcessingInstructions.SelectedValue = "4";
                    }
                    else
                    {
                        ddlProcessingInstructions.SelectedValue = qualityControl.ProcessingInstruction.ToString();
                        txtOtherProcessingInstruction.Enabled = false;
                    }
                    if ((qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.ApprovedByDMM == 1) || //&& qualityControl.ApprovedByBuyingHouse == 1
                       (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.ApprovedByBuyingHouse == 1 && (hdnRadioStatus.Value.ToString() == "1" || hdnRadioStatus.Value.ToString() == "2") && ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)26) || (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)17))) ||
                       ((qualityControl.ApprovedByCQD_QAManager == 1 || qualityControl.ApprovedByBuyingHouse == 1) && hdnRadioStatus.Value.ToString() == "2" && (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)14)) //&& qualityControl.ApprovedByBuyingHouse == 1
                       && qualityControl.InspectionID == 1) //For Inline 
                    {
                        btnSubmit.Visible = false;
                        fldBuyingHouse.Visible = false;
                        chk_DMM.Enabled = false;
                        btnSaveAllContracts_Rescan.Visible = false;
                        lblmsg.Text = "Inspection type is done and locked. You may add another instance using (+) Button.";

                        if ((qualityControl.InspectionID == 2 || qualityControl.InspectionID == 3 || qualityControl.InspectionID == 4) && ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)14)
                            lblmsg.Visible = false;
                        else
                            lblmsg.Visible = true;
                        if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.ApprovedByDMM == 1)
                            DiableChecks();
                    }

                    if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.ApprovedByBuyingHouse == 1 && qualityControl.InspectionID == 2) //For Mid //
                    {
                        btnSubmit.Visible = false;
                        btnSaveAllContracts_Rescan.Visible = false;
                        //lblmsg.Visible = true;
                        if ((qualityControl.InspectionID == 2 || qualityControl.InspectionID == 3 || qualityControl.InspectionID == 4) && ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)14)
                            lblmsg.Visible = false;
                        else
                            lblmsg.Visible = true;
                        fldBuyingHouse.Visible = false;
                        DiableChecks();
                    }
                    if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 4) //For Online 
                    {
                        btnSubmit.Visible = false;
                        btnSaveAllContracts_Rescan.Visible = false;
                        //lblmsg.Visible = true;
                        if ((qualityControl.InspectionID == 2 || qualityControl.InspectionID == 3 || qualityControl.InspectionID == 4) && ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)14)
                            lblmsg.Visible = false;
                        else
                            lblmsg.Visible = true;
                        DiableChecks();
                    }
                    if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.InspectionID == 3) //For Final   && ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)26) || (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)17)) //&& qualityControl.ApprovedByBuyingHouse_Factory == 1 && qualityControl.ApprovedByBuyingHouse_IC == 1
                    {
                        btnSubmit.Visible = false;
                        btnSaveAllContracts_Rescan.Visible = false;
                        // lblmsg.Visible = true;
                        if ((qualityControl.InspectionID == 2 || qualityControl.InspectionID == 3 || qualityControl.InspectionID == 4) && ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)14)
                            lblmsg.Visible = false;
                        else
                            lblmsg.Visible = true;
                        fldBuyingHouseFactory.Visible = false;
                        fldBuyingHouseIC.Visible = false;
                        DiableChecks();
                    }


                    if (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)14)//DMM
                    {
                        if (qualityControl.ApprovedByCQD_QAManager == 1 && hdnRadioStatus.Value.ToString() == "1" && qualityControl.ApprovedByDMM == 0) //&& qualityControl.ApprovedByBuyingHouse == 1
                        {
                            chk_DMM.Enabled = true;
                            txtCommentsBy_DMM.Enabled = true;
                            btnSubmit.Visible = true;
                        }
                        else if (qualityControl.ApprovedByCQD_QAManager == 0) //&& qualityControl.ApprovedByBuyingHouse == 0
                        {
                            chk_DMM.Enabled = false;
                            txtCommentsBy_DMM.Enabled = false;
                            btnSubmit.Visible = false;
                            btnSaveAllContracts_Rescan.Visible = false;
                            lblmsg.Text = "You can't proceed this sheet without approved by CQD/QA Manager.";//and Buying House.
                            if (qualityControl.InspectionID == 2 || qualityControl.InspectionID == 3 || qualityControl.InspectionID == 4)
                                lblmsg.Visible = false;
                            else
                                lblmsg.Visible = true;
                        }
                    }
                    //if (qualityControl.ApprovedByShippingOfficer == 1 && qualityControl.InspectionID == 3 && (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)37)) //For Final
                    //{
                    //    btnSubmit.Visible = false;
                    //    lblmsg.Visible = true;
                    //    DiableChecks();
                    //}


                    if (((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)26) || (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)17)))
                    {

                        if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.ApprovedByDMM == 1 && qualityControl.ApprovedByBuyingHouse == 0 && hdnRadioStatus.Value.ToString() == "1" && qualityControl.InspectionID == 1)//For Inline 
                        {
                            btnSubmit.Visible = false;
                            btnSaveAllContracts_Rescan.Visible = false;
                            lblmsg.Visible = false;
                            btnBuyingHouse.Visible = true;
                            fldBuyingHouse.Visible = true;

                        }
                        else if (qualityControl.ApprovedByCQD_QAManager == 1 && qualityControl.ApprovedByBuyingHouse == 0 && hdnRadioStatus.Value.ToString() == "1" && qualityControl.InspectionID == 2)//For MID 
                        {
                            btnSubmit.Visible = false;
                            btnSaveAllContracts_Rescan.Visible = false;
                            lblmsg.Visible = false;
                            btnBuyingHouse.Visible = true;
                            fldBuyingHouse.Visible = true;

                        }
                        else if (qualityControl.ApprovedByCQD_QAManager == 1 && (qualityControl.ApprovedByBuyingHouse_Factory == 0 || qualityControl.ApprovedByBuyingHouse_IC == 0) && hdnRadioStatus.Value.ToString() == "1" && qualityControl.InspectionID == 3)//For FINAL 
                        {
                            btnSubmit.Visible = false;
                            btnSaveAllContracts_Rescan.Visible = false;
                            lblmsg.Visible = false;
                            btnBuyingHouse.Visible = true;
                            fldBuyingHouseFactory.Visible = true;
                            fldBuyingHouseIC.Visible = true;

                        }
                    }
                    if (qualityControl.InspectionID == 3)
                    {
                        if (qualityControl.shippedqty > 0)
                        {
                            lblpenalty.Text = "Penalty Done";

                        }
                        else
                        {
                            lblpenalty.Text = "Penalty Pending";
                            chkCQD_QAManager.Enabled = false;

                            if (hdnRadioStatus.Value == "2")
                                chkCQD_QAManager.Enabled = true;
                        }

                        lblpenalty.Visible = true;
                        //lnkopenShipedPopoup.Attributes.Add("onclick", "javascript:openShipedPopu('" + OrderDetailID + "',0, '" + qualityControl.OrderDetail.Quantity.ToString() + "')");
                    }
                    if (Convert.ToInt32(hdnContractsCount.Value) > 1)
                    {
                        hplContractList.Visible = true;
                        CotractsByOrder();
                    }
                    //else if (Convert.ToInt32(hdnContractsCount.Value) > 1 && hdnRadioStatus.Value == "2")
                    //{
                    //    hplContractList.Visible = true;
                    //    CotractsByOrder();
                    //}
                    else
                        hplContractList.Visible = false;
                }
            }
            BindFault();
            if (Session["save"] != null && Session["ApprovedByCQD"] != null)
            {
                if (Session["save"].ToString() == "1")
                {
                    var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                    //lblmsg1.Visible = true;
                    if ((qualityControl.ApprovedByCQD_QAManager == 1 && !Convert.ToBoolean(Session["ApprovedByCQD"]) && hdnRadioStatus.Value.ToString() == "1" && qualityControl.InspectionID == 1 && ((ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)26) || (ApplicationHelper.LoggedInUser.UserData.Designation == (Designation)17))) || //&& qualityControl.ApprovedByDMM == 1  && qualityControl.ApprovedByBuyingHouse == 1
                        (qualityControl.ApprovedByCQD_QAManager == 1 && !Convert.ToBoolean(Session["ApprovedByCQD"]) && hdnRadioStatus.Value.ToString() == "1" && qualityControl.InspectionID == 2) || //&& qualityControl.ApprovedByBuyingHouse == 1
                        (qualityControl.ApprovedByCQD_QAManager == 1 && !Convert.ToBoolean(Session["ApprovedByCQD"]) && hdnRadioStatus.Value.ToString() == "1" && qualityControl.InspectionID == 3)) // && qualityControl.ApprovedByBuyingHouse_Factory == 1 && qualityControl.ApprovedByBuyingHouse_IC == 1
                    {

                        if (Convert.ToInt32(hdnContractsCount.Value) > 1)
                        {
                            CotractsByOrder();
                            hdnIsOpenAllContractsPopUp.Value = "1";
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(hdnContractsCount.Value) > 1)
                        {
                            CotractsByOrder();
                            hdnIsOpenAllContractsPopUp.Value = "1";
                        }
                    }
                }
                Session["save"] = null;
                Session["ApprovedByCQD"] = null;
            }
            if (Session["saveBH"] != null && Session["saveBH"].ToString() == "1")
            {
                var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
                Session["saveBH"] = null;
            }

        }
        private void CotractsByOrder()
        {
            QualityController qualityControl = new QualityController();
            OrderDetailID = hdnOrderDetailID.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailID.Value);
            OrderID = hdnOrderId.Value == "" ? -1 : Convert.ToInt32(hdnOrderId.Value);
            DataTable QCDT = qualityControl.Get_AllQC_CotractsByOrder(OrderID, OrderDetailID, InspectionID).Tables[0];
            grdAllContracts.DataSource = QCDT;
            grdAllContracts.DataBind();
        }
        private void SaveQuality()
        {
            var oldStatus = "";
            iKandi.Common.QualityControl qualityControl = new iKandi.Common.QualityControl();
            QualityControlID = hiddenQualityControlID.Value;
            iKandi.Common.QualityControl qualityControlOld = this.QualityControllerInstance.GetQualityControlBYQuality(OrderDetailID, QualityControlID, InspectionID);

            Session["ApprovedByCQD"] = qualityControlOld.ApprovedByCQD_QAManager;
            if (qualityControlOld.FaultsPP.Count > 0)
            {
                ViewState["AQLType"] = qualityControlOld.FaultsPP[0].AqlValue;
                oldStatus = qualityControlOld.FaultsPP[0].Status;
            }
            qualityControl.OrderDetail = new OrderDetail();

            qualityControl.OrderDetail.OrderDetailID = OrderDetailID;
            qualityControlOld.OrderDetail.OrderDetailID = OrderDetailID;
            qualityControl.OrderDetail.OrderID = Convert.ToInt32(hdnOrderId.Value);
            qualityControl.OrderDetail.ExFactory = Convert.ToDateTime(hdnExFactory.Value);
            if (lblPack.Text != "")
            {
                qualityControl.OrderDetail.PercentageOverallPcsPacked = Convert.ToDouble(lblPack.Text);
            }

            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            string dateToday = DateTime.Today.ToString("dd MMM");
            string Comments = txtComments.Text;
            string CommentsBy_DMM = txtCommentsBy_DMM.Text;


            if (!string.IsNullOrEmpty(txtComments.Text))
                qualityControl.Comments = userName + " " + "(" + dateToday + ")" + " " + " : " + Comments + " ";
            else
                qualityControl.Comments = string.Empty;

            if (!string.IsNullOrEmpty(txtCommentsBy_DMM.Text))
                qualityControl.CommentsBy_DMM = userName + " " + "(" + dateToday + ")" + " " + " : " + CommentsBy_DMM + " ";
            else
                qualityControl.CommentsBy_DMM = string.Empty;

            qualityControl.ApprovedByCQD_QAManager = Convert.ToInt32(chkCQD_QAManager.Checked);
            qualityControl.ApprovedByShippingOfficer = Convert.ToInt32(chk_ShippingOfficer.Checked);
            qualityControl.ApprovedByDMM = Convert.ToInt32(chk_DMM.Checked);

            qualityControl.ApprovedByBuyingHouse = Convert.ToInt32(chk_BuyingHouse.Checked);
            qualityControl.ApprovedByBuyingHouse_Factory = Convert.ToInt32(chk_BuyingHouseFactory.Checked);
            qualityControl.ApprovedByBuyingHouse_IC = Convert.ToInt32(chk_BuyingHouseIC.Checked);

            qualityControl.BuyingHouse_Status = (RBBHPass.Checked) ? "1" : ((RBBHFail.Checked) ? "2" : "0");
            qualityControl.BuyingHouse_QAName = txtBHQC.Text;
            qualityControl.BuyingHouseFactory_Status = (RBBHFPass.Checked) ? "1" : ((RBBHFFail.Checked) ? "2" : "0");
            qualityControl.BuyingHouseFactory_QAName = txtBHFQC.Text;

            // Added By Ravi kumar on 10/1/2017
            qualityControl.WithoutNatureOfFaults = chkWithOutNature.Checked;

            //qualityControl.LineManId = Convert.ToInt32(listLineMan.SelectedValue);
            //qualityControl.QcId = Convert.ToInt32(listQcName.SelectedValue);
            // Add By Ravi kumar on 22/12/16


            qualityControl.chkGMQA = Convert.ToInt16(chkGMQA.Checked);
            qualityControl.chkCQD = Convert.ToInt16(chkCQD.Checked);
            qualityControl.chkFactoryManager = Convert.ToInt16(chkFactoryManager.Checked);
            qualityControl.chkProdIncharge = Convert.ToInt16(chkProdIncharge.Checked);
            qualityControl.chkQC = Convert.ToInt16(chkQC.Checked);
            qualityControl.chkFinishIncharge = Convert.ToInt16(chkFinishIncharge.Checked);
            qualityControl.chkFinishSuperwisor = Convert.ToInt16(chkFinishSuperwisor.Checked);
            qualityControl.ckhLineMan = Convert.ToInt16(ckhLineMan.Checked);
            qualityControl.chkAsstLineMan = Convert.ToInt16(chkAsstLineMan.Checked);
            qualityControl.chkChecker = Convert.ToInt16(chkChecker.Checked);
            qualityControl.chkPressMan = Convert.ToInt16(chkPressMan.Checked);
            qualityControl.chkOthers = Convert.ToInt16(chkOthers.Checked);
            qualityControl.AdditionalInformation = txtAdditional.Text;
            qualityControl.MissedfaultCount = txtmissfaultcount.Text == "" ? 0 : Convert.ToInt32(txtmissfaultcount.Text);
            qualityControl.TotalOcuured = txtfalutoccu.Text == "" ? 0 : Convert.ToInt32(txtfalutoccu.Text);



            if ((chkCQD_QAManager.Checked) == true)
            {
                if (qualityControlOld.ApprovedByCQD_QAManager == 0)
                    qualityControl.ApprovedByCQD_QAManagerOn = DateTime.Now;
                else
                    qualityControl.ApprovedByCQD_QAManagerOn = qualityControlOld.ApprovedByCQD_QAManagerOn;
            }

            if ((chk_ShippingOfficer.Checked) == true)
                if (qualityControlOld.ApprovedByShippingOfficer == 0)
                    qualityControl.ApprovedByShippingOfficerOn = DateHelper.ParseDate(lblShippingOfficerDate.Text).Value;
                else
                    qualityControl.ApprovedByShippingOfficerOn = qualityControlOld.ApprovedByShippingOfficerOn;

            if ((chk_DMM.Checked) == true)
                if (qualityControlOld.ApprovedByDMM == 0)
                    qualityControl.ApprovedByDMMOn = DateHelper.ParseDate(lblDMMDate.Text).Value;
                else
                    qualityControl.ApprovedByDMMOn = qualityControlOld.ApprovedByDMMOn;

            if ((chk_BuyingHouse.Checked) == true)
                if (qualityControlOld.ApprovedByBuyingHouse == 0)
                    qualityControl.ApprovedByBuyingHouseOn = DateHelper.ParseDate(lblBuyingHouseDate.Text).Value;
                else
                    qualityControl.ApprovedByBuyingHouseOn = qualityControlOld.ApprovedByBuyingHouseOn;

            if ((chk_BuyingHouseFactory.Checked) == true)
                if (qualityControlOld.ApprovedByBuyingHouse_Factory == 0)
                    qualityControl.ApprovedByBuyingHouse_FactoryOn = DateHelper.ParseDate(lblBuyingHouseFactoryDate.Text).Value;
                else
                    qualityControl.ApprovedByBuyingHouse_FactoryOn = qualityControlOld.ApprovedByBuyingHouse_FactoryOn;

            if ((chk_BuyingHouseIC.Checked) == true)
                if (qualityControlOld.ApprovedByBuyingHouse_IC == 0)
                    qualityControl.ApprovedByBuyingHouse_ICOn = DateHelper.ParseDate(lblBuyingHouseICDate.Text).Value;
                else
                    qualityControl.ApprovedByBuyingHouse_ICOn = qualityControlOld.ApprovedByBuyingHouse_ICOn;


            if (fldBuyingHouseFactory.HasFile)
            {
                qualityControl.BuyingHouse_Factory_FilePath = iKandi.Web.Components.FileHelper.SaveFile(fldBuyingHouseFactory.PostedFile.InputStream, fldBuyingHouseFactory.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
            }
            else
                qualityControl.BuyingHouse_Factory_FilePath = qualityControlOld.BuyingHouse_Factory_FilePath;

            if (fldBuyingHouse.HasFile)
            {
                qualityControl.BuyingHouse_FilePath = iKandi.Web.Components.FileHelper.SaveFile(fldBuyingHouse.PostedFile.InputStream, fldBuyingHouse.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
            }
            else
                qualityControl.BuyingHouse_FilePath = qualityControlOld.BuyingHouse_FilePath;

            if (hdnFldresolutionIE.Value != "")
            {
                qualityControl.BuyingHouse_IC_FilePath = hdnFldresolutionIE.Value;
                Server.MapPath("~/uploads/Quality/" + hdnFldresolutionIE.Value);
            }
            else
                qualityControl.BuyingHouse_IC_FilePath = qualityControlOld.BuyingHouse_IC_FilePath;


            if (ddlProcessingInstructions.SelectedValue == "4")
            {
                qualityControl.ProcessingInstruction = Convert.ToInt32(ddlProcessingInstructions.SelectedValue);
                if (!string.IsNullOrEmpty(txtOtherProcessingInstruction.Text))
                {
                    qualityControl.OtherInstruction = txtOtherProcessingInstruction.Text;
                }
            }
            else
            {
                qualityControl.ProcessingInstruction = Convert.ToInt32(ddlProcessingInstructions.SelectedValue);
                qualityControl.OtherInstruction = null;
            }

            //List<LineManQC> objListLineManQC = new List<LineManQC>();

            qualityControl.LineMan = new List<LineManQC>();


            for (int inext = 0; inext < listLineMan.Items.Count; inext++)
            {
                if (listLineMan.Items[inext].Selected == true)
                {
                    LineManQC objLineManQC = new LineManQC();
                    objLineManQC.LineManId = Convert.ToInt32(listLineMan.Items[inext].Value);
                    //string[] ArrLineMan = listLineMan.Items[inext].Text.Split('(');
                    //if (ArrLineMan.Length > 1)
                    //{
                    //    string sLine = ArrLineMan[1].ToString();
                    //    sLine = sLine.Substring(5, 2);
                    //    string[] ArrLine = sLine.Split(')');
                    //    if (ArrLine.Length > 1)
                    //        objLineManQC.LineNo = Convert.ToInt32(ArrLine[0].ToString().Trim());
                    //    else
                    //        objLineManQC.LineNo = Convert.ToInt32(sLine.Trim());
                    //}
                    //else
                    //    objLineManQC.LineNo = 0;
                    objLineManQC.QCId = -1;
                    // objLineManQC.UnitId = hdnUnitId.Value == "" ? -1 : Convert.ToInt32(hdnUnitId.Value);
                    qualityControl.LineMan.Add(objLineManQC);
                }
            }

            for (int inext = 0; inext < listQcName.Items.Count; inext++)
            {
                if (listQcName.Items[inext].Selected == true)
                {
                    LineManQC objLineManQC = new LineManQC();
                    objLineManQC.QCId = Convert.ToInt32(listQcName.Items[inext].Value);

                    //string[] ArrQCMan = listQcName.Items[inext].Text.Split('(');
                    //if (ArrQCMan.Length > 1)
                    //{
                    //    string sLine = ArrQCMan[1].ToString();
                    //    sLine = sLine.Substring(5, 2);
                    //    string[] ArrLine = sLine.Split(')');
                    //    if (ArrLine.Length > 1)
                    //        objLineManQC.LineNo = Convert.ToInt32(ArrLine[0].ToString().Trim());
                    //    else
                    //        objLineManQC.LineNo = Convert.ToInt32(sLine.Trim());
                    //}
                    //else
                    //    objLineManQC.LineNo = 0;

                    objLineManQC.LineManId = -1;
                    //objLineManQC.UnitId = hdnUnitId.Value == "" ? -1 : Convert.ToInt32(hdnUnitId.Value);
                    qualityControl.LineMan.Add(objLineManQC);
                }
            }
            qualityControl.Production_Unit = Convert.ToInt32(ddlUnitID.SelectedItem.Value);

            qualityControl.FaultsPP = new List<QualityFaults>();

            QualityFaults faultsPp = new QualityFaults();
            faultsPp.Id = Convert.ToInt32(hiddenQualityControlID.Value);

            if (!string.IsNullOrEmpty(txtActualSamplesChecked.Text))
                faultsPp.ActualSamplesChecked = Convert.ToInt32(txtActualSamplesChecked.Text);

            faultsPp.QA = ApplicationHelper.LoggedInUser.UserData.UserID;

            if (!string.IsNullOrEmpty(hdnRadioStatus.Value))
            {
                faultsPp.Status = hdnRadioStatus.Value;
            }
            else
            {
                faultsPp.Status = "0";
            }

            if (!string.IsNullOrEmpty(lblDateConducted.Text))
                faultsPp.DateConducted = DateHelper.ParseDate(lblDateConducted.Text).Value;
            faultsPp.InspectionID = InspectionID == "-10" ? "1" : InspectionID;

            #region CheckingItems
            faultsPp.CheckingItems = new List<ItemsToCheck>();
            iKandi.Common.ItemsToCheck itemChk1 = new iKandi.Common.ItemsToCheck();
            itemChk1.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk1.CheckingItem = 1;
            itemChk1.Missing = Convert.ToInt32(chkMainLabel1.Checked);
            itemChk1.NotRequired = Convert.ToInt32(chkMainLabel2.Checked);
            itemChk1.Present = Convert.ToInt32(chkMainLabel3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (!String.IsNullOrEmpty(HiddenField1.Value))
                    itemChk1.Id = Convert.ToInt32(HiddenField1.Value);
                else
                    itemChk1.Id = -1;

                itemChk1.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk1.Id = -1;
            faultsPp.CheckingItems.Add(itemChk1);

            iKandi.Common.ItemsToCheck itemChk2 = new iKandi.Common.ItemsToCheck();
            itemChk2.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk2.CheckingItem = 2;
            itemChk2.Missing = Convert.ToInt32(chkSizeLabel1.Checked);
            itemChk2.NotRequired = Convert.ToInt32(chkSizeLabel2.Checked);
            itemChk2.Present = Convert.ToInt32(chkSizeLabel3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField2.Value != "" || HiddenField2.Value != string.Empty)
                    itemChk2.Id = Convert.ToInt32(HiddenField2.Value);
                else
                    itemChk2.Id = -1;

                itemChk2.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk2.Id = -1;
            faultsPp.CheckingItems.Add(itemChk2);

            iKandi.Common.ItemsToCheck itemChk3 = new iKandi.Common.ItemsToCheck();
            itemChk3.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk3.CheckingItem = 3;
            itemChk3.Missing = Convert.ToInt32(chkWashCare1.Checked);
            itemChk3.NotRequired = Convert.ToInt32(chkWashCare2.Checked);
            itemChk3.Present = Convert.ToInt32(chkWashCare3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField3.Value != "" || HiddenField3.Value != string.Empty) // done as expection was thrown
                    itemChk3.Id = Convert.ToInt32(HiddenField3.Value);
                else
                    itemChk3.Id = -1;

                itemChk3.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk3.Id = -1;
            faultsPp.CheckingItems.Add(itemChk3);

            iKandi.Common.ItemsToCheck itemChk4 = new iKandi.Common.ItemsToCheck();
            itemChk4.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk4.CheckingItem = 4;
            itemChk4.Missing = Convert.ToInt32(chkPriceTicket1.Checked);
            itemChk4.NotRequired = Convert.ToInt32(chkPriceTicket2.Checked);
            itemChk4.Present = Convert.ToInt32(chkPriceTicket3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField4.Value != "" || HiddenField4.Value != string.Empty) // done as expection was thrown
                    itemChk4.Id = Convert.ToInt32(HiddenField4.Value);
                else
                    itemChk4.Id = -1;

                itemChk4.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk4.Id = -1;
            faultsPp.CheckingItems.Add(itemChk4);

            iKandi.Common.ItemsToCheck itemChk5 = new iKandi.Common.ItemsToCheck();
            itemChk5.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk5.CheckingItem = 5;
            itemChk5.Missing = Convert.ToInt32(chkPolybagSticker1.Checked);
            itemChk5.NotRequired = Convert.ToInt32(chkPolybagSticker2.Checked);
            itemChk5.Present = Convert.ToInt32(chkPolybagSticker3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField5.Value != "" || HiddenField5.Value != string.Empty) // done as expection was thrown
                    itemChk5.Id = Convert.ToInt32(HiddenField5.Value);
                else
                    itemChk5.Id = -1;

                itemChk5.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk5.Id = -1;
            faultsPp.CheckingItems.Add(itemChk5);

            iKandi.Common.ItemsToCheck itemChk6 = new iKandi.Common.ItemsToCheck();
            itemChk6.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk6.CheckingItem = 6;
            itemChk6.Missing = Convert.ToInt32(chkCartonQuality1.Checked);
            itemChk6.NotRequired = Convert.ToInt32(chkCartonQuality2.Checked);
            itemChk6.Present = Convert.ToInt32(chkCartonQuality3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField6.Value != "" || HiddenField6.Value != string.Empty) // done as expection was thrown
                    itemChk6.Id = Convert.ToInt32(HiddenField6.Value);
                else
                    itemChk6.Id = -1;

                itemChk6.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk6.Id = -1;
            faultsPp.CheckingItems.Add(itemChk6);

            iKandi.Common.ItemsToCheck itemChk7 = new iKandi.Common.ItemsToCheck();
            itemChk7.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk7.CheckingItem = 7;
            itemChk7.Missing = Convert.ToInt32(chkCartonStickers1.Checked);
            itemChk7.NotRequired = Convert.ToInt32(chkCartonStickers2.Checked);
            itemChk7.Present = Convert.ToInt32(chkCartonStickers3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField7.Value != "" || HiddenField7.Value != string.Empty)
                    itemChk7.Id = Convert.ToInt32(HiddenField7.Value);
                else
                    itemChk7.Id = -1;

                itemChk7.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk7.Id = -1;
            faultsPp.CheckingItems.Add(itemChk7);

            iKandi.Common.ItemsToCheck itemChk8 = new iKandi.Common.ItemsToCheck();
            itemChk8.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk8.CheckingItem = 8;
            itemChk8.Missing = Convert.ToInt32(chkPolybagQuality1.Checked);
            itemChk8.NotRequired = Convert.ToInt32(chkPolybagQuality2.Checked);
            itemChk8.Present = Convert.ToInt32(chkPolybagQuality3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField8.Value != "" || HiddenField8.Value != string.Empty) // done as expection was thrown
                    itemChk8.Id = Convert.ToInt32(HiddenField8.Value);
                else
                    itemChk8.Id = -1;

                itemChk8.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk8.Id = -1;
            faultsPp.CheckingItems.Add(itemChk8);

            iKandi.Common.ItemsToCheck itemChk9 = new iKandi.Common.ItemsToCheck();
            itemChk9.ParentQualityControl = new iKandi.Common.QualityControl();
            itemChk9.CheckingItem = 9;
            itemChk9.Missing = Convert.ToInt32(chkHangers1.Checked);
            itemChk9.NotRequired = Convert.ToInt32(chkHangers2.Checked);
            itemChk9.Present = Convert.ToInt32(chkHangers3.Checked);
            if (OrderDetailID == qualityControlOld.OrderDetail.OrderDetailID)
            {
                if (HiddenField9.Value != "" || HiddenField9.Value != string.Empty) // done as expection was thrown
                    itemChk9.Id = Convert.ToInt32(HiddenField9.Value);
                else
                    itemChk9.Id = -1;

                itemChk9.ParentQualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
            }
            else
                itemChk9.Id = -1;
            faultsPp.CheckingItems.Add(itemChk9);
            #endregion

            qualityControl.FaultsPP.Add(faultsPp);

            FaultXml.AppendLine("<root>");
            foreach (RepeaterItem rptItem in rptFault.Items)
            {
                FaultXml.AppendLine("<fault>");
                HtmlInputHidden hdnNatureOfFaults = (HtmlInputHidden)rptItem.FindControl("hdnNatureOfFaults");
                TextBox txtOccurrence = (TextBox)rptItem.FindControl("txtOccurrence");
                DropDownList ddlUser = (DropDownList)rptItem.FindControl("ddlUser");
                HtmlInputHidden hdnFldresolution = (HtmlInputHidden)rptItem.FindControl("hdnFldresolution");
                TextBox txtFaultDetails = (TextBox)rptItem.FindControl("txtFaultDetails");
                TextBox txtCorrectiveActionPlan = (TextBox)rptItem.FindControl("txtCorrectiveActionPlan");

                if (hdnNatureOfFaults.Value != "-10" && hdnNatureOfFaults.Value != "0" && hdnNatureOfFaults.Value != "-1" && hdnNatureOfFaults.Value != "")
                {
                    var faltTypeId = hdnNatureOfFaults.Value.ToString().Split('-');
                    FaultXml.AppendLine("<FaultID>" + faltTypeId[0] + "</FaultID>");
                    FaultXml.AppendLine("<FaultType>" + faltTypeId[1] + "</FaultType>");
                }
                string FaultDetails = txtFaultDetails.Text.Replace("'", "*").Replace("&", "^").Replace("<", "`").Replace(">", "~");
                string CorrectiveActionPlan = txtCorrectiveActionPlan.Text.Replace("'", "*").Replace("&", "^").Replace("<", "`").Replace(">", "~");

                FaultXml.AppendLine("<Owner>" + ddlUser.SelectedValue + "</Owner>");
                FaultXml.AppendLine("<Occurrence>" + txtOccurrence.Text + "</Occurrence>");
                FaultXml.AppendLine("<FilePath>" + hdnFldresolution.Value + "</FilePath>");
                FaultXml.AppendLine("<FaultDetails>" + FaultDetails + "</FaultDetails>");
                FaultXml.AppendLine("<CorrectiveActionPlan>" + CorrectiveActionPlan + "</CorrectiveActionPlan>");
                FaultXml.AppendLine("</fault>");
            }
            FaultXml.AppendLine("</root>");
            qualityControl.FaultXML = FaultXml.ToString();

            // Save Process By Ravi kumar on 3/2/17
            ProcessXml.AppendLine("<root>");
            foreach (GridViewRow gvr in gvProcess.Rows)
            {
                ProcessXml.AppendLine("<Process>");
                HiddenField hdnProcessId = (HiddenField)gvr.FindControl("hdnProcessId");
                RadioButton rbtnProcessPass = (RadioButton)gvr.FindControl("rbtnProcessPass");
                RadioButton rbtnProcessFail = (RadioButton)gvr.FindControl("rbtnProcessFail");
                TextBox txtActionPlan = (TextBox)gvr.FindControl("txtActionPlan");

                if (hdnProcessId.Value != "" && hdnProcessId.Value != "-1")
                    ProcessXml.AppendLine("<QaProcessId>" + hdnProcessId.Value + "</QaProcessId>");

                int ProcessStatus = 0;

                if (rbtnProcessPass.Checked)
                    ProcessStatus = 1;
                if (rbtnProcessFail.Checked)
                    ProcessStatus = 0;

                string ProcessActionPlan = txtActionPlan.Text.Replace("'", "*").Replace("&", "^").Replace("<", "`").Replace(">", "~");
                ProcessXml.AppendLine("<ProcessStatus>" + ProcessStatus + "</ProcessStatus>");
                ProcessXml.AppendLine("<CorrectiveActionPlan>" + ProcessActionPlan + "</CorrectiveActionPlan>");
                ProcessXml.AppendLine("</Process>");
            }
            ProcessXml.AppendLine("</root>");
            qualityControl.ProcessXML = ProcessXml.ToString();

            qualityControl.InspectionID = Convert.ToInt32(InspectionID == "-10" ? "1" : InspectionID);

            //Save QualityControl
            int iSaveFault = 1;
            if (InspectionID == "3")
            {
                if (hdnRadioStatus.Value != "2")
                {
                    iSaveFault = SaveFault();
                    qualityControl.shippedqty = txtShippedQty.Text == "" ? -1 : Convert.ToInt32(txtShippedQty.Text);
                }
                else
                {
                    int IsDeletedOld = this.OrderControllerInstance.DeleteAddFualtDetails(OrderDetailID, 0, "", "DELETE");
                    qualityControl.shippedqty = -1;
                }
            }
            else
            {
                qualityControl.shippedqty = -1;
            }


            if (iSaveFault != 0)
            {

                bool success = false;
                if (Convert.ToInt32(QualityControlID) > 0)
                {
                    qualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);
                    if (qualityControl.ApprovedByCQD_QAManager == 1)
                    {
                        if (hdnRadioStatus.Value == "1")
                        {
                            qualityControl.FaultsPP[0].Status = "1";
                        }
                        else if (hdnRadioStatus.Value == "2")
                        {
                            qualityControl.FaultsPP[0].Status = "2";
                        }

                        //End Of Code                      
                    }
                    int iDelete = this.QualityControllerInstance.DeleteQc_Lineman(OrderDetailID, Convert.ToInt32(QualityControlID));

                    success = this.QualityControllerInstance.UpdateQualityControlNew(qualityControl);

                }
                else
                    success = this.QualityControllerInstance.InsertQualityControlNew(qualityControl);

                if (hdnRadioStatus.Value.ToString() == "2" && success && (oldStatus.ToUpper() != "PASS") && chkCQD_QAManager.Checked && InspectionID != "4")
                {
                    NotificationEmailHistory NEH = new NotificationEmailHistory();
                    NEH.Type = "5";
                    NEH.EmailID = "12";
                    NEH.OrderID = "0";
                    NEH.OrderDetailsID = OrderDetailID.ToString();
                    NEH.InspectionID = Convert.ToInt16(InspectionID);
                    //this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                }

                var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";

                if (success)
                {
                    Session["save"] = "1";
                    Response.Redirect(Request.Url.ToString(), false);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);
            }
        }

        #region events
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveQuality();

        }

        protected void repeaterSizesItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                EmptyCell = EmptyCell + 1;

            if (e.Item.ItemType == ListItemType.Footer)
            {
                for (int i = 0; i < 10 - EmptyCell; i++)
                {
                    ((Label)e.Item.FindControl("lblEmptyCell")).Text = ((Label)e.Item.FindControl("lblEmptyCell")).Text + "<td></td>";
                }
            }
        }

        protected void repeaterQtyItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EmptyCell2 = EmptyCell2 + 1;
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                for (int i = 0; i < 10 - EmptyCell2; i++)
                {
                    ((Label)e.Item.FindControl("lblEmptyCell")).Text = ((Label)e.Item.FindControl("lblEmptyCell")).Text + "<td></td>";
                }
            }
        }

        protected void repeaterQtyCheckedItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EmptyCell3 = EmptyCell3 + 1;
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                for (int i = 0; i < 10 - EmptyCell3; i++)
                {
                    ((Label)e.Item.FindControl("lblEmptyCell")).Text = ((Label)e.Item.FindControl("lblEmptyCell")).Text + "<td></td>";
                }
            }
        }
        #endregion

        private void BindFault()
        {
            try
            {
                DataTable dt = new DataTable();
                if (QualityControlID != "0")
                {
                    MazorOccurance = 0;
                    MinorOccurance = 0;
                    CriticalOccurane = 0;
                    rptFault.DataSource = qualityControl.Faults;
                    rptFault.DataBind();
                    if (qualityControl.Faults != null && qualityControl.Faults.Count > 0)
                    {
                        for (int i = 0; i < qualityControl.Faults.Count; i++)
                        {
                            //DropDownList ddlNatureOfFaults = (DropDownList)rptFault.Items[i].FindControl("ddlNatureOfFaults");
                            TextBox txtNatureOfFaults = (TextBox)rptFault.Items[i].FindControl("txtNatureOfFaults");
                            HtmlInputHidden hdnNatureOfFaults = (HtmlInputHidden)rptFault.Items[i].FindControl("hdnNatureOfFaults");
                            DropDownList ddlUser = (DropDownList)rptFault.Items[i].FindControl("ddlUser");
                            //FileUpload Fldresolution = (FileUpload)rptFault.Items[i].FindControl("Fldresolution");
                            //HyperLink imgfile = (HyperLink)rptFault.Items[i].FindControl("imgfile");
                            Label lblClassification = (Label)rptFault.Items[i].FindControl("lblClassification");

                            if (qualityControl.Faults[i].Owner != 0)
                                ddlUser.SelectedValue = qualityControl.Faults[i].Owner.ToString();
                            else
                            {
                                if (ddlUser.Items.Count > 1)
                                    ddlUser.SelectedIndex = 1;
                            }
                            txtNatureOfFaults.Text = qualityControl.Faults[i].Fault;
                            hdnNatureOfFaults.Value = qualityControl.Faults[i].FaultValue.ToString();

                            if (qualityControl.Faults[i].FaultType == 1)
                                lblClassification.Text = "Critical";
                            else if (qualityControl.Faults[i].FaultType == 2)
                                lblClassification.Text = "Major";
                            else if (qualityControl.Faults[i].FaultType == 3)
                                lblClassification.Text = "Minor";

                            //if (!string.IsNullOrEmpty(qualityControl.Faults[i].FilePath.ToString()))
                            //{
                            //    imgfile.Visible = true;
                            //}
                            //else
                            //    imgfile.Visible = false;
                        }
                    }
                }
                else
                {
                    dt = CreateTable();
                    DataRow dr = dt.NewRow();
                    dr[0] = "";
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = "";
                    dr[4] = "";
                    dr[5] = "";
                    dr[6] = "";
                    dt.Rows.Add(dr);

                    MazorOccurance = 0;
                    MinorOccurance = 0;
                    CriticalOccurane = 0;
                    rptFault.DataSource = dt;
                    rptFault.DataBind();
                }
            }
            catch
            {

            }
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("FaultValue", typeof(string)));
            dt.Columns.Add(new DataColumn("Fault", typeof(string)));
            dt.Columns.Add(new DataColumn("Classification", typeof(string)));
            dt.Columns.Add(new DataColumn("Occurrence", typeof(string)));
            dt.Columns.Add(new DataColumn("FaultOwner", typeof(string)));
            dt.Columns.Add(new DataColumn("FilePath", typeof(string)));
            dt.Columns.Add(new DataColumn("FaultType", typeof(string)));
            dt.Columns.Add(new DataColumn("FaultDetails", typeof(string)));
            dt.Columns.Add(new DataColumn("CorrectiveActionPlan", typeof(string)));
            return dt;
        }

        protected void imgBtnadd_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DataTable dt = CreateTable();
                foreach (RepeaterItem rptItem in rptFault.Items)
                {
                    HiddenField hdnID = (HiddenField)rptItem.FindControl("hdnID");
                    //DropDownList ddlNatureOfFaults = (DropDownList)rptItem.FindControl("ddlNatureOfFaults");
                    TextBox txtNatureOfFaults = (TextBox)rptItem.FindControl("txtNatureOfFaults");
                    HtmlInputHidden hdnNatureOfFaults = (HtmlInputHidden)rptItem.FindControl("hdnNatureOfFaults");
                    Label lblClassification = (Label)rptItem.FindControl("lblClassification");
                    TextBox txtOccurrence = (TextBox)rptItem.FindControl("txtOccurrence");
                    DropDownList ddlUser = (DropDownList)rptItem.FindControl("ddlUser");
                    HtmlInputHidden hdnFldresolution = (HtmlInputHidden)rptItem.FindControl("hdnFldresolution");
                    //HtmlInputHidden hdnFaultResolution = (HtmlInputHidden)rptItem.FindControl("hdnFaultResolution");
                    HiddenField hdnClassificationId = (HiddenField)rptItem.FindControl("hdnClassificationId");
                    TextBox txtFaultDetails = (TextBox)rptItem.FindControl("txtFaultDetails");
                    TextBox txtCorrectiveActionPlan = (TextBox)rptItem.FindControl("txtCorrectiveActionPlan");

                    DataRow dr = dt.NewRow();
                    dr[0] = hdnID.Value;
                    dr[1] = hdnNatureOfFaults.Value;
                    dr[2] = txtNatureOfFaults.Text;
                    dr[3] = lblClassification.Text;
                    dr[4] = txtOccurrence.Text;
                    dr[5] = ddlUser.SelectedValue;
                    dr[6] = hdnFldresolution.Value;
                    dr[7] = hdnClassificationId.Value;
                    dr[8] = txtFaultDetails.Text;
                    dr[9] = txtCorrectiveActionPlan.Text;

                    dt.Rows.Add(dr);
                }

                DataRow dr1 = dt.NewRow();
                dr1[0] = "";
                dr1[1] = "";
                dr1[2] = "";
                dr1[3] = "";
                dr1[4] = "";
                dr1[5] = "";
                dr1[6] = "";
                dr1[7] = "";
                dr1[8] = "";
                dr1[9] = "";

                dt.Rows.Add(dr1);
                lblMajorActual.Text = "";
                lblMinorActual.Text = "";

                MazorOccurance = 0;
                MinorOccurance = 0;
                CriticalOccurane = 0;

                rptFault.DataSource = dt;
                rptFault.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //DropDownList ddlNatureOfFaults = (DropDownList)rptFault.Items[i].FindControl("ddlNatureOfFaults");
                    TextBox txtNatureOfFaults = (TextBox)rptFault.Items[i].FindControl("txtNatureOfFaults");
                    HtmlInputHidden hdnNatureOfFaults = (HtmlInputHidden)rptFault.Items[i].FindControl("hdnNatureOfFaults");
                    DropDownList ddlUser = (DropDownList)rptFault.Items[i].FindControl("ddlUser");
                    Label lblClassification = (Label)rptFault.Items[i].FindControl("lblClassification");
                    TextBox txtOccurrence = (TextBox)rptFault.Items[i].FindControl("txtOccurrence");
                    HtmlTableCell tdClassification = (HtmlTableCell)rptFault.Items[i].FindControl("tdClassification");
                    HiddenField hdnClassificationId = (HiddenField)rptFault.Items[i].FindControl("hdnClassificationId");

                    ddlUser.SelectedValue = dt.Rows[i]["FaultOwner"].ToString();
                    hdnNatureOfFaults.Value = dt.Rows[i]["FaultValue"].ToString();
                    txtNatureOfFaults.Text = dt.Rows[i]["Fault"].ToString();
                    txtOccurrence.Text = dt.Rows[i]["Occurrence"].ToString();
                    var FType = dt.Rows[i]["FaultValue"].ToString().Split('-');
                    if (FType.Length > 1)
                    {
                        if (FType[1] == "1")
                        {
                            lblClassification.Text = "Critical";
                            hdnClassificationId.Value = "1";
                            tdClassification.Attributes.Add("style", "background-color:#ff3300;");
                        }
                        else if (FType[1] == "2")
                        {
                            lblClassification.Text = "Major";
                            hdnClassificationId.Value = "2";
                            tdClassification.Attributes.Add("style", "background-color:#fd9903;");
                        }
                        else if (FType[1] == "3")
                        {
                            lblClassification.Text = "Minor";
                            hdnClassificationId.Value = "3";
                            tdClassification.Attributes.Add("style", "background-color:#FFFF00;");
                        }
                    }


                    if (txtActualSamplesChecked.Text != "")
                    {
                        decimal ActualSamplesChecked = Convert.ToDecimal(txtActualSamplesChecked.Text);
                        decimal hdnMajor = Convert.ToDecimal(hdnMajorAllowed.Value);
                        decimal hdnMinor = Convert.ToDecimal(hdnMinorAllowed.Value);
                        decimal lblSample = Convert.ToDecimal(lblSampleQty.Text);
                        lblMajorAllowed.Text = Math.Round(((hdnMajor * ActualSamplesChecked) / lblSample), 0).ToString();
                        lblMinorAllowed.Text = Math.Round(((hdnMinor * ActualSamplesChecked) / lblSample), 0).ToString();
                    }
                    else
                    {
                        lblMajorAllowed.Text = hdnMajorAllowed.Value;
                        lblMinorAllowed.Text = hdnMinorAllowed.Value;
                    }
                }
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SHowHideFile()", true);

                if (hdnRadioStatus.Value == "1")
                {
                    lblStatus.Text = "Pass";
                    tdStatus.Style.Add("background-color", "#01cc01");

                }
                if (hdnRadioStatus.Value == "2")
                {
                    lblStatus.Text = "Fail";
                    tdStatus.Style.Add("background-color", "#FF0000");
                }
            }
            catch
            {

            }
        }

        protected void imgBtndelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
                HiddenField hfID = (HiddenField)rptItem.FindControl("hdnID");
                DataTable dt = CreateTable();
                foreach (RepeaterItem rptItem1 in rptFault.Items)
                {
                    HiddenField hdnID = (HiddenField)rptItem1.FindControl("hdnID");
                    //DropDownList ddlNatureOfFaults = (DropDownList)rptItem1.FindControl("ddlNatureOfFaults");
                    TextBox txtNatureOfFaults = (TextBox)rptItem1.FindControl("txtNatureOfFaults");
                    HtmlInputHidden hdnNatureOfFaults = (HtmlInputHidden)rptItem1.FindControl("hdnNatureOfFaults");
                    Label lblClassification = (Label)rptItem1.FindControl("lblClassification");
                    TextBox txtOccurrence = (TextBox)rptItem1.FindControl("txtOccurrence");
                    DropDownList ddlUser = (DropDownList)rptItem1.FindControl("ddlUser");
                    HtmlInputHidden hdnFldresolution = (HtmlInputHidden)rptItem1.FindControl("hdnFldresolution");
                    //HtmlInputHidden hdnFaultResolution = (HtmlInputHidden)rptItem1.FindControl("hdnFaultResolution");
                    HiddenField hdnClassificationId = (HiddenField)rptItem1.FindControl("hdnClassificationId");
                    TextBox txtFaultDetails = (TextBox)rptItem1.FindControl("txtFaultDetails");
                    TextBox txtCorrectiveActionPlan = (TextBox)rptItem1.FindControl("txtCorrectiveActionPlan");

                    DataRow dr = dt.NewRow();
                    dr[0] = hdnID.Value;
                    dr[1] = hdnNatureOfFaults.Value;
                    dr[2] = txtNatureOfFaults.Text;
                    dr[3] = lblClassification.Text;
                    dr[4] = txtOccurrence.Text;
                    dr[5] = ddlUser.SelectedValue;
                    dr[6] = hdnFldresolution.Value;
                    dr[7] = hdnClassificationId.Value;
                    dr[8] = txtFaultDetails.Text;
                    dr[9] = txtCorrectiveActionPlan.Text;

                    dt.Rows.Add(dr);
                }
                dt.Rows[rptItem.ItemIndex].Delete();
                if (dt.Rows.Count > 0)
                {
                    MazorOccurance = 0;
                    MinorOccurance = 0;
                    CriticalOccurane = 0;

                    rptFault.DataSource = dt;
                    rptFault.DataBind();
                }
                else
                {
                    // dt = CreateTable();
                    DataRow dr = dt.NewRow();
                    dr[0] = "";
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = "";
                    dr[4] = "";
                    dr[5] = "";
                    dr[6] = "";
                    dr[7] = "";
                    dr[8] = "";
                    dt.Rows.Add(dr);

                    MazorOccurance = 0;
                    MinorOccurance = 0;
                    CriticalOccurane = 0;

                    rptFault.DataSource = dt;
                    rptFault.DataBind();
                }
                int TotalCriticalOccurrence = 0;
                int TotalMajorOccurrence = 0;
                int TotalMinorOccurrence = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //DropDownList ddlNatureOfFaults = (DropDownList)rptFault.Items[i].FindControl("ddlNatureOfFaults");
                    TextBox txtNatureOfFaults = (TextBox)rptFault.Items[i].FindControl("txtNatureOfFaults");
                    HtmlInputHidden hdnNatureOfFaults = (HtmlInputHidden)rptFault.Items[i].FindControl("hdnNatureOfFaults");
                    DropDownList ddlUser = (DropDownList)rptFault.Items[i].FindControl("ddlUser");
                    Label lblClassification = (Label)rptFault.Items[i].FindControl("lblClassification");
                    TextBox txtOccurrence = (TextBox)rptFault.Items[i].FindControl("txtOccurrence");
                    HtmlTableCell tdClassification = (HtmlTableCell)rptFault.Items[i].FindControl("tdClassification");
                    HiddenField hdnClassificationId = (HiddenField)rptFault.Items[i].FindControl("hdnClassificationId");

                    ddlUser.SelectedValue = dt.Rows[i]["FaultOwner"].ToString();
                    hdnNatureOfFaults.Value = dt.Rows[i]["FaultValue"].ToString();
                    txtNatureOfFaults.Text = dt.Rows[i]["Fault"].ToString();
                    txtOccurrence.Text = dt.Rows[i]["Occurrence"].ToString();
                    var FType = dt.Rows[i]["FaultValue"].ToString().Split('-');
                    if (FType.Length > 1)
                    {
                        if (FType[1] == "1")
                        {
                            lblClassification.Text = "Critical";
                            hdnClassificationId.Value = "1";
                            tdClassification.Attributes.Add("style", "background-color:#ff3300;");
                            TotalCriticalOccurrence = TotalCriticalOccurrence + Convert.ToInt32(txtOccurrence.Text);
                        }
                        else if (FType[1] == "2")
                        {
                            lblClassification.Text = "Major";
                            hdnClassificationId.Value = "2";
                            tdClassification.Attributes.Add("style", "background-color:#fd9903;");
                            TotalMajorOccurrence = TotalMajorOccurrence + Convert.ToInt32(txtOccurrence.Text);
                        }
                        else if (FType[1] == "3")
                        {
                            lblClassification.Text = "Minor";
                            hdnClassificationId.Value = "3";
                            tdClassification.Attributes.Add("style", "background-color:#FFFF00;");
                            TotalMinorOccurrence = TotalMinorOccurrence + Convert.ToInt32(txtOccurrence.Text);
                        }
                    }
                    if (txtActualSamplesChecked.Text != "")
                    {
                        decimal ActualSamplesChecked = Convert.ToDecimal(txtActualSamplesChecked.Text);
                        decimal hdnMajor = Convert.ToDecimal(hdnMajorAllowed.Value);
                        decimal hdnMinor = Convert.ToDecimal(hdnMinorAllowed.Value);
                        decimal lblSample = Convert.ToDecimal(lblSampleQty.Text);
                        lblMajorAllowed.Text = Math.Round(((hdnMajor * ActualSamplesChecked) / lblSample), 0).ToString();
                        lblMinorAllowed.Text = Math.Round(((hdnMinor * ActualSamplesChecked) / lblSample), 0).ToString();
                    }
                    else
                    {
                        lblMajorAllowed.Text = hdnMajorAllowed.Value;
                        lblMinorAllowed.Text = hdnMinorAllowed.Value;
                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "FaultsSummary(" + TotalCriticalOccurrence + ", " + TotalMajorOccurrence + ", " + TotalMinorOccurrence + ")", true);
            }
            catch
            {

            }
        }

        protected void rptFault_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //DropDownList ddlNatureOfFaults = (DropDownList)e.Item.FindControl("ddlNatureOfFaults");
                DropDownList ddlUser = (DropDownList)e.Item.FindControl("ddlUser");
                HiddenField hdnClassificationId = (HiddenField)e.Item.FindControl("hdnClassificationId");
                HtmlTableCell tdClassification = (HtmlTableCell)e.Item.FindControl("tdClassification");
                TextBox txtOccurrence = (TextBox)e.Item.FindControl("txtOccurrence");
                TextBox txtFaultDetails = (TextBox)e.Item.FindControl("txtFaultDetails");
                TextBox txtCorrectiveActionPlan = (TextBox)e.Item.FindControl("txtCorrectiveActionPlan");

                users = this.UserControllerInstance.GetFactoryManagerByClient(OrderDetailID);
                ddlUser.DataSource = users;
                ddlUser.DataTextField = "FullName";
                ddlUser.DataValueField = "UserID";
                ddlUser.DataBind();
                ddlUser.Items.Insert(0, new ListItem("--Select--", "0"));
                if (ddlUser.Items.Count > 1)
                    ddlUser.SelectedIndex = 1;

                hdnClassificationId.Value = hdnClassificationId.Value == "" ? "0" : hdnClassificationId.Value;

                if (txtFaultDetails.Text != "")
                {
                    txtFaultDetails.Text = txtFaultDetails.Text.Replace("*", "'").Replace("^", "&").Replace("`", "<").Replace("~", ">");
                }

                if (txtCorrectiveActionPlan.Text != "")
                {
                    txtCorrectiveActionPlan.Text = txtCorrectiveActionPlan.Text.Replace("*", "'").Replace("^", "&").Replace("`", "<").Replace("~", ">");
                }

                if (Convert.ToInt32(hdnClassificationId.Value) == 1)
                {
                    CriticalOccurane = CriticalOccurane + Convert.ToInt32(txtOccurrence.Text);
                    lblCriticalActual.Text = CriticalOccurane.ToString();
                    lblCriticalActual.Text = Convert.ToInt32(lblCriticalActual.Text) > 0 ? lblCriticalActual.Text : "";
                    tdClassification.Attributes.Add("style", "background-color:#ff3300;");
                }
                else if (Convert.ToInt32(hdnClassificationId.Value) == 2)
                {
                    MazorOccurance = MazorOccurance + Convert.ToInt32(txtOccurrence.Text);
                    lblMajorActual.Text = MazorOccurance.ToString();
                    lblMajorActual.Text = Convert.ToInt32(lblMajorActual.Text) > 0 ? lblMajorActual.Text : "";
                    tdClassification.Attributes.Add("style", "background-color:#fd9903;");
                }
                else if (Convert.ToInt32(hdnClassificationId.Value) == 3)
                {
                    MinorOccurance = MinorOccurance + Convert.ToInt32(txtOccurrence.Text);
                    lblMinorActual.Text = MinorOccurance.ToString();
                    lblMinorActual.Text = Convert.ToInt32(lblMinorActual.Text) > 0 ? lblMinorActual.Text : "";
                    tdClassification.Attributes.Add("style", "background-color:#FFFF00;");
                }
                else
                {
                    tdClassification.Attributes.Add("style", "background-color:#FFFFFF;");
                }
            }

        }

        protected void btnBuyingHouse_Click(object sender, EventArgs e)
        {
            int success;
            iKandi.Common.QualityControl qualityControl = new iKandi.Common.QualityControl();
            qualityControl.OrderDetail = new OrderDetail();
            QualityControlID = hiddenQualityControlID.Value;
            iKandi.Common.QualityControl qualityControlOld = this.QualityControllerInstance.GetQualityControlBYQuality(OrderDetailID, QualityControlID, InspectionID);
            qualityControl.OrderDetail.OrderDetailID = OrderDetailID;
            qualityControl.Id = Convert.ToInt32(hiddenQualityControlID.Value);

            qualityControl.ApprovedByBuyingHouse = Convert.ToInt32(chk_BuyingHouse.Checked);
            qualityControl.ApprovedByBuyingHouse_Factory = Convert.ToInt32(chk_BuyingHouseFactory.Checked);
            qualityControl.ApprovedByBuyingHouse_IC = Convert.ToInt32(chk_BuyingHouseIC.Checked);

            qualityControl.BuyingHouse_Status = (RBBHPass.Checked) ? "1" : ((RBBHFail.Checked) ? "2" : "0");
            qualityControl.BuyingHouse_QAName = txtBHQC.Text;
            qualityControl.BuyingHouseFactory_Status = (RBBHFPass.Checked) ? "1" : ((RBBHFFail.Checked) ? "2" : "0");
            qualityControl.BuyingHouseFactory_QAName = txtBHFQC.Text;


            if ((chk_BuyingHouse.Checked) == true)
                if (qualityControlOld.ApprovedByBuyingHouse == 0)
                    qualityControl.ApprovedByBuyingHouseOn = DateHelper.ParseDate(lblBuyingHouseDate.Text).Value;
                else
                    qualityControl.ApprovedByBuyingHouseOn = qualityControlOld.ApprovedByBuyingHouseOn;

            if ((chk_BuyingHouseFactory.Checked) == true)
                if (qualityControlOld.ApprovedByBuyingHouse_Factory == 0)
                    qualityControl.ApprovedByBuyingHouse_FactoryOn = DateHelper.ParseDate(lblBuyingHouseFactoryDate.Text).Value;
                else
                    qualityControl.ApprovedByBuyingHouse_FactoryOn = qualityControlOld.ApprovedByBuyingHouse_FactoryOn;

            if ((chk_BuyingHouseIC.Checked) == true)
                if (qualityControlOld.ApprovedByBuyingHouse_IC == 0)
                    qualityControl.ApprovedByBuyingHouse_ICOn = DateHelper.ParseDate(lblBuyingHouseICDate.Text).Value;
                else
                    qualityControl.ApprovedByBuyingHouse_ICOn = qualityControlOld.ApprovedByBuyingHouse_ICOn;


            if (fldBuyingHouseFactory.HasFile)
            {
                qualityControl.BuyingHouse_Factory_FilePath = iKandi.Web.Components.FileHelper.SaveFile(fldBuyingHouseFactory.PostedFile.InputStream, fldBuyingHouseFactory.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
            }
            else
                qualityControl.BuyingHouse_Factory_FilePath = qualityControlOld.BuyingHouse_Factory_FilePath;

            if (fldBuyingHouse.HasFile)
            {
                qualityControl.BuyingHouse_FilePath = iKandi.Web.Components.FileHelper.SaveFile(fldBuyingHouse.PostedFile.InputStream, fldBuyingHouse.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
            }
            else
                qualityControl.BuyingHouse_FilePath = qualityControlOld.BuyingHouse_FilePath;
            //abhishek
            //if (fldBuyingHouseIC.HasFile)
            //{
            //    qualityControl.BuyingHouse_IC_FilePath = iKandi.Web.Components.FileHelper.SaveFile(fldBuyingHouseIC.PostedFile.InputStream, fldBuyingHouseIC.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
            //    qualityControl.BuyingHouse_IC_FilePath = iKandi.Web.Components.FileHelper.SaveFile(fldBuyingHouseIC.PostedFile.InputStream, fldBuyingHouseIC.FileName, Constants.QUALITY_FOLDER_PATH, false, string.Empty);
            //}
            //else
            //    qualityControl.BuyingHouse_IC_FilePath = qualityControlOld.BuyingHouse_IC_FilePath;

            if (hdnFldresolutionIE.Value != "")
            {
                qualityControl.BuyingHouse_IC_FilePath = hdnFldresolutionIE.Value;
                Server.MapPath(Constants.QUALITY_FOLDER_PATH + hdnFldresolutionIE.Value);
            }
            else
                qualityControl.BuyingHouse_IC_FilePath = qualityControlOld.BuyingHouse_IC_FilePath;

            success = this.QualityControllerInstance.UpdateQualityControlBH(qualityControl);
            var script_fail = "ShowHideValidationBox(true, '" + "Some error has occured please contact support team." + "');";

            if (success > 0)
            {
                Session["saveBH"] = "1";
                Response.Redirect(Request.Url.ToString(), false);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_fail, true);

        }

        private void GetQaFault()
        {
            int DesignationID = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            int Departmentid = ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;
            DataSet ds = this.OrderControllerInstance.GetShippedDetailByID(OrderDetailID, DesignationID, Departmentid);
            DataTable dt = ds.Tables[0];
            DataTable dtQaFault = ds.Tables[2];
            DataTable dt3 = ds.Tables[3];
            ViewState["Faultname"] = dt3;
            if (dt.Rows.Count > 0)
            {
                txtcutqty.Text = dt.Rows[0]["CutQty"].ToString();
                txtShippedQty.Text = ViewState["ShipedValue"] == null ? dt.Rows[0]["shippedqty"].ToString() : ViewState["ShipedValue"].ToString();
                CutQty = txtcutqty.Text == "" ? 0 : Convert.ToInt32(txtcutqty.Text);
                ShippedQty = txtShippedQty.Text == "" ? 0 : Convert.ToInt32(txtShippedQty.Text);
                if (ShippedQty != 0)
                {
                    if ((hdnBP_CR.Value != "") && (hdnBP_CR.Value != "0"))
                    {
                        double BP_CR = Convert.ToDouble(hdnBP_CR.Value);
                        double Shipval = Math.Round((BP_CR * ShippedQty) / 1000, 0);
                        if (Shipval != 0)
                            lblShipValue.Text = "Value:  " + Shipval.ToString() + " k";
                    }
                }


                double ctsl = Math.Round((Convert.ToDouble(CutQty) - Convert.ToDouble(ShippedQty)) / Convert.ToDouble(CutQty) * 100, 1);
                lblCtsl.Text = ctsl.ToString() + " %";
                lblPending.Text = (CutQty - ShippedQty).ToString();
                if ((CutQty - ShippedQty) > 0)
                    lblPending.ForeColor = System.Drawing.Color.Red;
                else
                    lblPending.ForeColor = System.Drawing.Color.Green;
            }

            if (ViewState["dtQaFault"] != null)
            {
                txtcutqty.Text = dt.Rows[0]["CutQty"].ToString();
                txtShippedQty.Text = ViewState["ShipedValue"] == null ? dt.Rows[0]["shippedqty"].ToString() : ViewState["ShipedValue"].ToString();
                CutQty = txtcutqty.Text == "" ? 0 : Convert.ToInt32(txtcutqty.Text);
                ShippedQty = txtShippedQty.Text == "" ? 0 : Convert.ToInt32(txtShippedQty.Text);
                if (ShippedQty != 0)
                {
                    if ((CutQty - ShippedQty) > 0)
                    {
                        grdQafault.DataSource = (DataTable)ViewState["dtQaFault"];
                        grdQafault.DataBind();
                        grdQafault.Style.Add("display", "");
                        tblTotal.Style.Add("display", "");
                        tblTotal.Style.Add("border-collapse", "collapse");
                        tblTotal.Style.Add("border-top", "0px");
                        lblFooterTotalQty.Text = QaFaultQty.ToString() == "0" ? "" : QaFaultQty.ToString();
                        if (QaFaultValue != 0)
                            lblFooterTotalValue.Text = Math.Round(QaFaultValue / 1000, 0) == 0 ? "" : Math.Round(QaFaultValue / 1000, 0).ToString() + " k";
                    }
                    else
                    {
                        grdQafault.DataSource = null;
                        grdQafault.DataBind();
                        grdQafault.Style.Add("display", "none");
                        tblTotal.Style.Add("display", "none");
                    }
                }
                else
                {
                    grdQafault.DataSource = null;
                    grdQafault.DataBind();
                    grdQafault.Style.Add("display", "none");
                    tblTotal.Style.Add("display", "none");
                }
            }
            else
            {
                if (dtQaFault.Rows.Count > 0)
                {
                    grdQafault.DataSource = dtQaFault;
                    grdQafault.DataBind();
                    ViewState["dtQaFault"] = dtQaFault;
                    grdQafault.Style.Add("display", "");
                    tblTotal.Style.Add("display", "");
                    tblTotal.Style.Add("border-collapse", "collapse");
                    tblTotal.Style.Add("border-top", "0px");
                    lblFooterTotalQty.Text = QaFaultQty.ToString() == "0" ? "" : QaFaultQty.ToString();
                    if (QaFaultValue != 0)
                        lblFooterTotalValue.Text = Math.Round(QaFaultValue / 1000, 0) == 0 ? "" : Math.Round(QaFaultValue / 1000, 0).ToString() + " k";
                }
                else
                {
                    CutQty = txtcutqty.Text == "" ? 0 : Convert.ToInt32(txtcutqty.Text);
                    ShippedQty = txtShippedQty.Text == "" ? 0 : Convert.ToInt32(txtShippedQty.Text);
                    if (ShippedQty != 0)
                    {
                        if (CutQty <= ShippedQty)
                        {
                            grdQafault.Style.Add("display", "none");
                            tblTotal.Style.Add("display", "none");
                            grdQafault.DataSource = null;
                            grdQafault.DataBind();
                        }
                        else
                        {
                            grdQafault.DataSource = null;
                            grdQafault.DataBind();
                            ViewState["dtQaFault"] = null;
                            grdQafault.Style.Add("display", "");
                            tblTotal.Style.Add("display", "");
                            tblTotal.Style.Add("border-collapse", "collapse");
                            tblTotal.Style.Add("border-top", "0px");
                            lblFooterTotalQty.Text = QaFaultQty.ToString() == "0" ? "" : QaFaultQty.ToString();
                            if (QaFaultValue != 0)
                                lblFooterTotalValue.Text = Math.Round(QaFaultValue / 1000, 0) == 0 ? "" : Math.Round(QaFaultValue / 1000, 0).ToString() + " k";
                        }
                    }
                    else
                    {
                        grdQafault.DataSource = null;
                        grdQafault.DataBind();
                        grdQafault.Style.Add("display", "none");
                        tblTotal.Style.Add("display", "none");
                    }
                }
            }
            ValidateQafaultQty();
        }

        protected void grdQafault_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdQafault.Rows[e.RowIndex];

            HiddenField hdnAutoincretment = (HiddenField)row.FindControl("hdnAutoincretment");

            HiddenField hdnfaultid = (HiddenField)row.FindControl("hdnfaultid");
            DataTable dtnew = new DataTable();
            int rowIdnex = e.RowIndex;
            if (ViewState["dtQaFault"] != null)
            {
                dtnew = (DataTable)(ViewState["dtQaFault"]);
                if (hdnAutoincretment.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("ID=" + hdnfaultid.Value)[0]);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdnfaultid.Value)[0]);
                }
                ViewState["dtQaFault"] = dtnew;
            }
            if (dtnew.Rows.Count > 0)
            {
                int TotatCutQty = 0;
                foreach (DataRow dr in dtnew.Rows)
                {
                    string txtqty = dr["UnshippedQty"].ToString();
                    if (txtqty != "")
                    {
                        TotatCutQty += Convert.ToInt32(dr["UnshippedQty"]);
                    }
                }
                if (txtcutqty.Text != "")
                    CutQty = Convert.ToInt32(txtcutqty.Text);

                if (txtShippedQty.Text != "")
                {
                    ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                    int TotalShipped = ShippedQty + TotatCutQty;
                    if (TotalShipped > CutQty)
                    {
                        ShowAlert("Enter Penalty qty can not be greater than actual cut qty!");
                        chkCQD_QAManager.Enabled = false;
                    }
                    if (CutQty > TotalShipped)
                    {
                        chkCQD_QAManager.Enabled = false;
                    }
                }
            }

            grdQafault.EditIndex = -1;
            GetQaFault();

        }

        protected void grdQafault_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Result = string.Empty;

            int CutQty = txtcutqty.Text == "" ? 0 : Convert.ToInt32(txtcutqty.Text);

            if (e.CommandName == "Insert")
            {
                TextBox txtfoterfaultname = grdQafault.FooterRow.FindControl("txtfoterfaultname") as TextBox;
                TextBox txtfoterqnty = grdQafault.FooterRow.FindControl("txtfoterqnty") as TextBox;
                HiddenField hdnIDfoter = grdQafault.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;

                LinkButton abtnAdd = grdQafault.FooterRow.FindControl("abtnAdd") as LinkButton;


                string faultname = string.Empty;
                string qty = string.Empty;
                faultname = txtfoterfaultname.Text;
                qty = txtfoterqnty.Text;

                DataTable dtnewvalidate = new DataTable();
                dtnewvalidate = (DataTable)(ViewState["Faultname"]);

                foreach (DataRow dr in dtnewvalidate.Rows)
                {
                    if (dr["TextFields"].ToString() == faultname)
                    {
                        Flag = "HAS";
                    }
                }
                if (Flag != "HAS")
                {
                    ShowAlert("This fault is not a valid");
                    return;
                }
                Flag = "";

                if (ViewState["dtQaFault"] != null)
                {

                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtQaFault"]);
                    int RowCount = dtnew.Rows.Count;

                    DataRow row = dtnew.NewRow();
                    row["ID"] = RowCount + 1;
                    row["OrderDetailsID"] = OrderDetailID;
                    row["FaultsID"] = RowCount + 1;
                    row["UnshippedQty"] = txtfoterqnty.Text;
                    row["FaultID"] = RowCount + 1;
                    row["fault"] = faultname;

                    dtnew.Rows.Add(row);
                    dtnew.AcceptChanges();

                    ViewState["dtQaFault"] = dtnew;

                    int TotatCutQty = 0;
                    foreach (DataRow dr in dtnew.Rows)
                    {
                        string txtqty = dr["UnshippedQty"].ToString();
                        if (txtqty != "")
                        {
                            TotatCutQty += Convert.ToInt32(dr["UnshippedQty"]);
                        }
                    }

                    if (txtcutqty.Text != "")
                        CutQty = Convert.ToInt32(txtcutqty.Text);

                    if (txtShippedQty.Text != "")
                    {
                        ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                        int TotalShipped = ShippedQty + TotatCutQty;
                        if (TotalShipped > CutQty)
                        {
                            ShowAlert("Enter Penalty qty can not be greater than actual cut qty!");
                            txtfoterqnty.Text = "";
                            chkCQD_QAManager.Enabled = false;
                            dtnew.Rows[RowCount].Delete();
                            dtnew.AcceptChanges();
                            ViewState["dtQaFault"] = dtnew;
                            return;
                        }
                    }
                    if (lblPending.Text != "")
                    {
                        int PendingQty = Convert.ToInt32(lblPending.Text);
                        PendingQty = PendingQty - TotatCutQty;
                        lblPending.Text = PendingQty.ToString();
                        if (PendingQty == 0)
                            lblPending.ForeColor = System.Drawing.Color.Green;
                    }
                }

                ViewState["ShipedValue"] = txtShippedQty.Text.Trim();
                GetQaFault();

            }
            if (e.CommandName == "addnew")
            {
                Table tblGrdviewApplet = (Table)grdQafault.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                TextBox txtemptyfaultname = (TextBox)rows.FindControl("txtemptyfaultname");
                TextBox txtemptyqnty = (TextBox)rows.FindControl("txtemptyqnty");

                string faultname = string.Empty;
                string qty = string.Empty;
                faultname = txtemptyfaultname.Text;
                qty = txtemptyqnty.Text;

                DataTable dtnewvalidate = new DataTable();
                dtnewvalidate = (DataTable)(ViewState["Faultname"]);

                foreach (DataRow dr in dtnewvalidate.Rows)
                {
                    if (dr["TextFields"].ToString() == faultname)
                    {
                        Flag = "HAS";
                    }
                }
                if (Flag != "HAS")
                {
                    ShowAlert("This is not a valid fault");
                    return;
                }
                Flag = "";


                //if (ViewState["dtQaFault"] == null)
                //{
                DataTable dtnew = new DataTable();

                dtnew.Columns.Add(new DataColumn("Id", typeof(int)));
                dtnew.Columns.Add(new DataColumn("OrderDetailsID", typeof(int)));
                dtnew.Columns.Add(new DataColumn("FaultsID", typeof(int)));
                dtnew.Columns.Add(new DataColumn("UnshippedQty", typeof(string)));
                dtnew.Columns.Add(new DataColumn("FaultID", typeof(int)));
                dtnew.Columns.Add(new DataColumn("fault", typeof(string)));

                DataRow row = dtnew.NewRow();
                row["ID"] = 1;
                row["OrderDetailsID"] = OrderDetailID;
                row["FaultsID"] = 1;
                row["UnshippedQty"] = qty;
                row["FaultID"] = 1;
                row["fault"] = faultname;

                dtnew.Rows.Add(row);
                dtnew.AcceptChanges();
                ViewState["dtQaFault"] = dtnew;

                int TotatCutQty = 0;
                foreach (DataRow dr in dtnew.Rows)
                {
                    string txtqty = dr["UnshippedQty"].ToString();
                    if (txtqty != "")
                    {
                        TotatCutQty += Convert.ToInt32(dr["UnshippedQty"]);
                    }
                }
                if (txtcutqty.Text != "")
                    CutQty = Convert.ToInt32(txtcutqty.Text);

                if (txtShippedQty.Text != "")
                {
                    ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                    int TotalShipped = ShippedQty + TotatCutQty;
                    if (TotalShipped > CutQty)
                    {
                        ShowAlert("Enter Penalty qty can not be greater than actual cut qty!");
                        txtemptyqnty.Text = "";
                        chkCQD_QAManager.Enabled = false;
                        dtnew.Rows[0].Delete();
                        dtnew.AcceptChanges();
                        ViewState["dtQaFault"] = dtnew;
                        return;
                    }
                }
                if (lblPending.Text != "")
                {
                    int PendingQty = Convert.ToInt32(lblPending.Text);
                    PendingQty = PendingQty - TotatCutQty;
                    lblPending.Text = PendingQty.ToString();
                    if (PendingQty == 0)
                        lblPending.ForeColor = System.Drawing.Color.Green;
                }

                //}

                ViewState["ShipedValue"] = txtShippedQty.Text.Trim();

                GetQaFault();
            }
        }
        protected void grdAllContracts_Rescan_Rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField chkIsPacking = (HiddenField)e.Row.FindControl("chkIsPacking");
                CheckBox chkRescan = (CheckBox)e.Row.FindControl("chkRescan");
                Label lblDatePacked = (Label)e.Row.FindControl("lblDatePacked");
                if (chkIsPacking.Value != null)
                {
                    if (chkIsPacking.Value != "0")
                    {
                        chkRescan.Checked = true;
                    }
                }
                lblDatePacked.Text = (lblDatePacked.Text != null && Convert.ToDateTime(lblDatePacked.Text) != DateTime.MinValue) ? Convert.ToDateTime(lblDatePacked.Text).ToString("dd MMM yy (ddd)") : DateTime.Now.ToString("dd MMM yy (ddd)");

            }
        }
        protected void grdQafault_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CutQty = txtcutqty.Text == "" ? 0 : Convert.ToInt32(txtcutqty.Text);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQnty = (TextBox)e.Row.FindControl("txtQnty");
                Label lblCtsl = (Label)e.Row.FindControl("lblCtsl");
                Label lblValue = (Label)e.Row.FindControl("lblValue");
                if (txtQnty.Text != "")
                {
                    QaFaultQty = QaFaultQty + Convert.ToInt32(txtQnty.Text);
                    double ctsl = Math.Round(Convert.ToDouble(txtQnty.Text) / Convert.ToDouble(CutQty) * 100, 1);
                    lblCtsl.Text = ctsl.ToString() + " %";

                    if ((hdnBP_CR.Value != "") && (hdnBP_CR.Value != "0"))
                    {
                        lblValue.Text = Math.Round(Convert.ToDouble(txtQnty.Text) * Convert.ToDouble(hdnBP_CR.Value) / 1000, 0).ToString() + " k";
                        QaFaultValue = QaFaultValue + (Convert.ToDouble(txtQnty.Text) * Convert.ToDouble(hdnBP_CR.Value));
                    }

                    if (lblPending.Text != "")
                    {
                        int PendingQty = Convert.ToInt32(lblPending.Text);
                        PendingQty = PendingQty - Convert.ToInt32(txtQnty.Text);
                        lblPending.Text = PendingQty.ToString();
                        if (PendingQty == 0)
                            lblPending.ForeColor = System.Drawing.Color.Green;
                    }
                }
                if (chkCQD_QAManager.Checked)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    lnkDelete.Visible = false;
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                TextBox txtfoterqnty = (TextBox)e.Row.FindControl("txtfoterqnty");
                Label lblCtslFooter = (Label)e.Row.FindControl("lblCtslFooter");
                Label lblValueFooter = (Label)e.Row.FindControl("lblValueFooter");
                if (txtfoterqnty.Text != "")
                {
                    double ctsl = Math.Round(Convert.ToDouble(txtfoterqnty.Text) / Convert.ToDouble(CutQty) * 100, 1);
                    lblCtslFooter.Text = ctsl.ToString() + " %";

                    if ((hdnBP_CR.Value != "") && (hdnBP_CR.Value != "0"))
                        lblValueFooter.Text = Math.Round(Convert.ToDouble(txtfoterqnty.Text) * Convert.ToDouble(hdnBP_CR.Value) / 1000, 0).ToString() + " k";
                }
                if (chkCQD_QAManager.Checked)
                {
                    LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
                    abtnAdd.Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                TextBox txtemptyqnty = (TextBox)e.Row.FindControl("txtemptyqnty");
                Label lblCtslEmpty = (Label)e.Row.FindControl("lblCtslEmpty");
                Label lblValueEmpty = (Label)e.Row.FindControl("lblValueEmpty");
                if (txtemptyqnty.Text != "")
                {
                    double ctsl = Math.Round(Convert.ToDouble(txtemptyqnty.Text) / Convert.ToDouble(CutQty) * 100, 1);
                    lblCtslEmpty.Text = ctsl.ToString() + " %";

                    if ((hdnBP_CR.Value != "") && (hdnBP_CR.Value != "0"))
                        lblValueEmpty.Text = Math.Round(Convert.ToDouble(txtemptyqnty.Text) * Convert.ToDouble(hdnBP_CR.Value) / 1000, 0).ToString() + " k";
                }
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        private void AddQaFaultQty()
        {
            if (grdQafault.Rows.Count > 0)
            {
                int TotatCutQty = 0;
                DataTable dtQaFault = (DataTable)ViewState["dtQaFault"];
                int RowCount = 0;
                foreach (GridViewRow row in grdQafault.Rows)
                {
                    string txtqty = ((TextBox)row.FindControl("txtQnty")).Text;
                    if (txtqty != "")
                    {
                        TotatCutQty += Convert.ToInt32(((TextBox)row.FindControl("txtQnty")).Text);

                        dtQaFault.Rows[RowCount]["UnshippedQty"] = Convert.ToInt32(((TextBox)row.FindControl("txtQnty")).Text);
                        dtQaFault.AcceptChanges();
                    }
                    RowCount = RowCount + 1;
                }
                ViewState["dtQaFault"] = dtQaFault;

                if (txtcutqty.Text != "")
                    CutQty = Convert.ToInt32(txtcutqty.Text);

                if (txtShippedQty.Text != "")
                {
                    ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                    int TotalShipped = ShippedQty + TotatCutQty;

                    if (TotalShipped > CutQty)
                    {
                        ShowAlert("Enter Penalty qty can not be greater than actual cut qty!");
                    }

                }

                GetQaFault();
            }
        }

        private void ValidateQafaultQty()
        {
            if (grdQafault.Rows.Count > 0)
            {
                int TotatCutQty = 0;
                foreach (GridViewRow row in grdQafault.Rows)
                {
                    string txtqty = ((TextBox)row.FindControl("txtQnty")).Text;
                    if (txtqty != "")
                    {
                        TotatCutQty += Convert.ToInt32(((TextBox)row.FindControl("txtQnty")).Text);
                    }
                }
                if (txtcutqty.Text != "")
                    CutQty = Convert.ToInt32(txtcutqty.Text);

                if (txtShippedQty.Text != "")
                {
                    ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                    int TotalShipped = ShippedQty + TotatCutQty;
                    if (CutQty == TotalShipped)
                        chkCQD_QAManager.Enabled = true;
                    else
                        chkCQD_QAManager.Enabled = false;

                }
            }
            else
            {
                if (txtcutqty.Text != "")
                    CutQty = Convert.ToInt32(txtcutqty.Text);

                if (txtShippedQty.Text != "")
                {
                    ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                    if (ShippedQty >= CutQty)
                        chkCQD_QAManager.Enabled = true;
                    else
                        chkCQD_QAManager.Enabled = false;
                }
            }

        }

        private int SaveFault()
        {
            int Save = 1;
            try
            {
                if (grdQafault.Rows.Count > 0)
                {
                    int TotatCutQty = 0;
                    foreach (GridViewRow row in grdQafault.Rows)
                    {
                        string txtqty = ((TextBox)row.FindControl("txtQnty")).Text;
                        if (txtqty != "")
                        {
                            TotatCutQty += Convert.ToInt32(((TextBox)row.FindControl("txtQnty")).Text);
                        }
                    }
                    if (txtcutqty.Text != "")
                        CutQty = Convert.ToInt32(txtcutqty.Text);

                    if (txtShippedQty.Text != "")
                    {
                        ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                        int TotalShipped = ShippedQty + TotatCutQty;
                        if (TotalShipped > CutQty)
                        {
                            ShowAlert("Enter Penalty qty can not be greater than actual cut qty!");
                            Save = 0;
                        }

                    }

                    DataTable dtnewvalidate = new DataTable();
                    dtnewvalidate = (DataTable)(ViewState["Faultname"]);

                    foreach (GridViewRow rows in grdQafault.Rows)
                    {
                        TextBox txtFaultname = (TextBox)rows.FindControl("txtFaultname");
                        TextBox txtQnty = (TextBox)rows.FindControl("txtQnty");

                        foreach (DataRow dr in dtnewvalidate.Rows)
                        {
                            if (dr["TextFields"].ToString().Trim() == txtFaultname.Text.Trim())
                            {
                                Flag = "HAS";
                            }
                        }
                        if (Flag != "HAS")
                        {

                            ShowAlert("You can select either fault or unaccounted only" + " (" + txtFaultname.Text + ") " + "not a valid");
                            Save = 0;
                        }
                        Flag = "";

                    }
                }
                if (Save != 0)
                {
                    if (grdQafault.Rows.Count > 0)
                    {
                        int IsDeletedOld = this.OrderControllerInstance.DeleteAddFualtDetails(OrderDetailID, 0, "", "DELETE");
                        int results = 0;
                        if (IsDeletedOld > 0)
                        {
                            int qnty = 0;
                            string FaulName = string.Empty;
                            string FlagIsDelete = "NO";
                            foreach (GridViewRow row in grdQafault.Rows)
                            {
                                TextBox txtFaultname = (TextBox)row.FindControl("txtFaultname");
                                TextBox txtQnty = (TextBox)row.FindControl("txtQnty");
                                FaulName = txtFaultname.Text.Trim();
                                qnty = Convert.ToInt32(txtQnty.Text.Trim());

                                results = this.OrderControllerInstance.DeleteAddFualtDetails(OrderDetailID, qnty, FaulName, FlagIsDelete);
                            }
                        }
                        Save = results;
                    }
                }
                if (txtShippedQty.Text != "")
                {
                    if (txtcutqty.Text != "")
                        CutQty = Convert.ToInt32(txtcutqty.Text);
                    ShippedQty = Convert.ToInt32(txtShippedQty.Text);
                    if (ShippedQty >= CutQty)
                    {
                        int IsDeletedOld = this.OrderControllerInstance.DeleteAddFualtDetails(OrderDetailID, 0, "", "DELETE");
                        Save = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Save = 0;
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return Save;
        }

        protected void btnHdnShiped_Click(object sender, EventArgs e)
        {
            if (ViewState["dtQaFault"] != null)
            {
                DataTable dtnew = new DataTable();
                dtnew = (DataTable)(ViewState["dtQaFault"]);
                ViewState["dtQaFault"] = dtnew.Clone();
                ViewState["ShipedValue"] = txtShippedQty.Text.Trim();
                GetQaFault();
            }
            else
            {
                ViewState["ShipedValue"] = txtShippedQty.Text.Trim();
                GetQaFault();
            }
            if (hdnRadioStatus.Value == "1")
            {
                lblStatus.Text = "Pass";
                tdStatus.Style.Add("background-color", "#01cc01");

            }
            if (hdnRadioStatus.Value == "2")
            {
                lblStatus.Text = "Fail";
                tdStatus.Style.Add("background-color", "#FF0000");
            }
        }

        protected void btnHdnQnty_Click(object sender, EventArgs e)
        {
            AddQaFaultQty();
        }

        protected void grdAllContracts_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnODID = (HiddenField)e.Row.FindControl("hdnODID");
                CheckBox chkContract = (CheckBox)e.Row.FindControl("chkContract");
                if (hdnODID.Value == hdnOrderDetailID.Value)
                {
                    chkContract.Checked = true;
                    chkContract.Enabled = false;
                }


                HiddenField hdnTaskDone = (HiddenField)e.Row.FindControl("hdnTaskDone");
                if (Convert.ToBoolean(hdnTaskDone.Value) == true)
                {
                    if (InspectionID != "4")
                    {
                        chkContract.Enabled = false;
                        chkContract.Checked = true;
                    }
                    //else
                    //{
                    //    chkContract.Enabled = true;
                    //    chkContract.Checked = true;
                    //}
                }
            }


        }

        protected void btnContactSubmit_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void gvProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ProcessStatus = DataBinder.Eval(e.Row.DataItem, "ProcessStatus") == DBNull.Value ? -1 : Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "ProcessStatus"));
                RadioButton rbtnProcessPass = (RadioButton)e.Row.FindControl("rbtnProcessPass");
                RadioButton rbtnProcessFail = (RadioButton)e.Row.FindControl("rbtnProcessFail");
                if (ProcessStatus == 1)
                    rbtnProcessPass.Checked = true;
                if (ProcessStatus == 0)
                    rbtnProcessFail.Checked = true;
                if (ProcessStatus == -1)
                {
                    rbtnProcessPass.Checked = false;
                    rbtnProcessFail.Checked = false;
                }
            }
        }


    }
}