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
using iKandi.Common;
using iKandi.Web.Components;
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.IO;
//using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iKandi.BLL;
using System.Collections.Generic;



namespace iKandi.Web
{
    public partial class ManageOrderBasicInfo : BaseUserControl
    {
        public string searchText
        {
            get;
            set;
        }
        public string Years
        {
            get;
            set;
        }

        public int ClientId
        {
            get;
            set;
        }
        public int ClientDeptId
        {
            get;
            set;
        }
        public int ClientParentDeptId
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        public int OutHouse
        {
            get;
            set;
        }

        public int DateType
        {
            get;
            set;
        }
        public int StatusMode
        {
            get;
            set;
        }
        public double StatusMode_ForIntial
        {
            get;
            set;
        }
        public double StatusMode_ForDouble
        {
            get;
            set;
        }
        public int StatusModeSequence
        {
            get;
            set;
        }
        public int OrderBy1
        {
            get;
            set;
        }
        public int OrderBy2
        {
            get;
            set;
        }
        public int OrderBy3
        {
            get;
            set;
        }

        public int OrderBy4
        {
            get;
            set;
        }
        public int OrderBy5
        {
            get;
            set;
        }
        public string OrderDetailIds
        {
            get;
            set;
        }
        public int BuyingHouseId
        {
            get;
            set;
        }
        public int desigId
        {
            get;
            set;
        }
        //added by uday
        public int DelayStatusId
        {
            get;
            set;
        }

        public int TaskCompleteOrderDetailId
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }

        public string OutHouseOrderDetailIds
        {
            get;
            set;
        }
        public int DeptId
        {
            get;
            set;
        }
        public int SalesView
        {
            get;
            set;
        }


        public DateTime FromDate
        {
            get;
            set;
        }
        public DateTime ToDate
        {
            get;
            set;
        }
        public int AM
        {
            get;
            set;
        }
        // Add by ravi kumar on 10/2/15 for Accessories color change
        public int Access_ColorGreen
        {
            get;
            set;
        }
        public int Access_ColorWhite
        {
            get;
            set;
        }
        public int Access_ColorRed
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }
        public string UserLoggedName
        {
            get;
            set;
        }
        public bool IsShipped
        {
            get;
            set;
        }
        //updated code by bharat 19-feb
        public bool IsOnHold
        {
            get;
            set;
        }
        //end 
        public int IsUnShipped
        {
            get;
            set;
        }
        public int count_production
        {
            get;
            set;
        }
        //abhishek 4/11/2016

        public int OrderTypes
        {
            get;
            set;
        }
        //end
        //abhishek 30dec 
        // [System.ComponentModel.DefaultValue(0)]
        public static int TotalCnt_Page
        {
            get;
            set;
        }
        // [System.ComponentModel.DefaultValue(0)]
        public static int PageIndex_Page = 0;
        //{
        //    get;
        //    set;
        //}
        public int Startfirstindex
        {
            get
            {
                return PageIndex_Page;
            }
            set
            {
                PageIndex_Page = value;
            }
        }

        public bool IsOuthouse_CutIssue
        {
            get;
            set;
        }
        //end  
        #region Production Section
        int CuttingShareAll = 0;
        int StitchingShareAll = 0;
        int FinishingShareAll = 0;
        int TotalCutPcsAll = 0;
        int TotalCutReadyAll = 0;
        int TotalStitchedAll = 0;
        int TotalFinishedAll = 0;
        int TotalValueAddedAll = 0;
        int TotalCutIssueAll = 0;
        int TotalRescanAll = 0;
        int TotalPendingRescan = 0;

        #endregion

        iKandi.Common.Permission prmSection = new iKandi.Common.Permission();
        String Deliveryfolder = "~/" + System.Configuration.ConfigurationManager.AppSettings["delivery.docs.folder"];//abhishek
        MOOrderDetails ord = new MOOrderDetails();
        string DelayOrderDetailIds = "";

        StyleController Bindmode = new StyleController();
        protected void Page_Load(object sender, EventArgs e)
        {


            //if (TotalCnt_Page != 0 && PageIndex_Page != 0)
            //{
            //    generatePager(TotalCnt_Page, 10, PageIndex_Page);
            //}
            //added by abhishek on 16/12/2015
            UserLoggedName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            //End
            hdnUserID.Value = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            //added by abhishek on 7/2/2015
            Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName + " " + "On" + " " + DateTime.Today.ToString("dd MMM yyyy");
            //End
            hdnDate.Value = DateTime.Today.ToString();

            //   Response.Write(DelayStatusId.ToString());
            if (Session["btn_check"] != null)
            {

                int i = (int)Session["btn_check"];
                if (i == 1)
                {



                    if (Session["Flag"] != null)
                    {
                        bool flag = Convert.ToBoolean(Session["Flag"]);
                        if (flag == true)
                        {
                            string strSeaVal = "";
                            strSeaVal = Request.QueryString["SeaVal"];
                            if (strSeaVal == "Yes")
                            {
                                if (Session["SearchValues"] != null)
                                {

                                    DataTable dtTemp = (DataTable)Session["SearchValues"];
                                    this.searchText = dtTemp.Rows[0]["dcsearchText"].ToString();
                                    // Add By Ravi kumar on Date 7-oct-2014
                                    this.Years = dtTemp.Rows[0]["dcYear"].ToString();
                                    this.FromDate = Convert.ToDateTime(dtTemp.Rows[0]["dcFromDate"]);
                                    this.ToDate = Convert.ToDateTime(dtTemp.Rows[0]["dcToDate"]);
                                    // end
                                    this.ClientId = Convert.ToInt32(dtTemp.Rows[0]["dcClientId"]);
                                    this.AM = Convert.ToInt32(dtTemp.Rows[0]["dcAM"]);
                                    this.ClientParentDeptId = Convert.ToInt32(dtTemp.Rows[0]["dcClientParentDeptId"]);
                                    this.ClientDeptId = Convert.ToInt32(dtTemp.Rows[0]["dcClientDeptId"]);
                                    this.DateType = Convert.ToInt32(dtTemp.Rows[0]["dcDateType"]);
                                    //this.StatusMode = Convert.ToInt32(dtTemp.Rows[0]["dcStatusMode"]);
                                    this.StatusMode_ForIntial = Convert.ToDouble(dtTemp.Rows[0]["dcStatusMode"]);
                                    //this.StatusModeSequence = Convert.ToInt32(dtTemp.Rows[0]["dcStatusModeSequence"]);
                                    this.StatusMode_ForDouble = Convert.ToDouble(dtTemp.Rows[0]["dcStatusModeSequence"]);
                                    this.OrderBy1 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy1"]);
                                    this.OrderBy2 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy2"]);
                                    this.OrderBy3 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy3"]);
                                    this.OrderBy4 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy4"]);
                                    // this.OrderBy5 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy5"]);
                                    this.BuyingHouseId = Convert.ToInt32(dtTemp.Rows[0]["dcBuyingHouseId"]);
                                    this.IsUnShipped = Convert.ToInt32(dtTemp.Rows[0]["IsUnShipped"]);

                                }
                                //   Session["SearchValues"] = null;
                                //  Session["Flag"] = false;                            
                            }
                        }
                    }

                }
            }
            //string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            iKandi.BLL.BLLCache.ClearDeliverModesCache(); //force remove cache kuldeep
            hdnPagesize.Value = GridView1.PageSize.ToString();
            //hdnPageIndex.Value = GridView1.PageIndex.ToString();

            if (!IsPostBack)
            {

            }

        }



        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridView1.Columns[0].HeaderText = "Text u wish for 1st column";
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            MOOrderDetails od = (e.Row.DataItem as MOOrderDetails);

            TextBox lblPatternSampleDate = e.Row.FindControl("lblPatternSampleDate") as TextBox;
            TextBox lblCuttingSheetDate = e.Row.FindControl("lblCuttingSheetDate") as TextBox;
            TextBox TextBox1 = e.Row.FindControl("TextBox1") as TextBox;
            TextBox TextBox2 = e.Row.FindControl("TextBox2") as TextBox;
            //TextBox TextBox4 = e.Row.FindControl("TextBox4") as TextBox;
            
            TextBox txtHanoverETA = e.Row.FindControl("txtHanoverETA") as TextBox;
            TextBox txtPatternReadyETADate = e.Row.FindControl("txtPatternReadyETADate") as TextBox;
            TextBox txtSampleSentETA = e.Row.FindControl("txtSampleSentETA") as TextBox;
            TextBox txtFitsCommentesUplaodETADate = e.Row.FindControl("txtFitsCommentesUplaodETADate") as TextBox;
            TextBox txtETAHOPPM = e.Row.FindControl("txtETAHOPPM") as TextBox;
            TextBox lblProductionFileDate = e.Row.FindControl("lblProductionFileDate") as TextBox;
            TextBox txHandoverActual = e.Row.FindControl("txHandoverActual") as TextBox;
            TextBox txtPatternReadyActualDate = e.Row.FindControl("txtPatternReadyActualDate") as TextBox;
            TextBox txtSampleSentActualDate = e.Row.FindControl("txtSampleSentActualDate") as TextBox;
            TextBox txtFitsCommentesUplaodActualDate = e.Row.FindControl("txtFitsCommentesUplaodActualDate") as TextBox;
            Label Label21 = e.Row.FindControl("Label21") as Label;
            Label Label17 = e.Row.FindControl("Label17") as Label;
            Label Label19 = e.Row.FindControl("Label19") as Label;
            Label lblCutwidth1 = e.Row.FindControl("lblCutwidth1") as Label;
            Label lblCutwidth2 = e.Row.FindControl("lblCutwidth2") as Label;
            Label lblCutwidth3 = e.Row.FindControl("lblCutwidth3") as Label;
            Label lblCutwidth4 = e.Row.FindControl("lblCutwidth4") as Label;
            Label lblPackingName = e.Row.FindControl("lblPackingName") as Label;
            HyperLink hypPackingName = e.Row.FindControl("hypPackingName") as HyperLink;
            HyperLink hypShipmentNo = e.Row.FindControl("hypShipmentNo") as HyperLink;
            Label lblConsolidated = e.Row.FindControl("lblConsolidated") as Label;
            HyperLink hypInvoice = e.Row.FindControl("hypInvoice") as HyperLink;
            HyperLink hypBankRefNo = e.Row.FindControl("hypBankRefNo") as HyperLink;
            Label lblInvoice = e.Row.FindControl("lblInvoice") as Label;
            Label lblBankRefNo = e.Row.FindControl("lblBankRefNo") as Label;
            Label lblPendingPayment = e.Row.FindControl("lblPendingPayment") as Label;
            Label lblPaymentDueDate = e.Row.FindControl("lblPaymentDueDate") as Label;
            DropDownList ddlOuthouse = e.Row.FindControl("ddlOuthouse") as DropDownList;
           // Label lblPPSampleTarget = e.Row.FindControl("lblPPSampleTarget") as Label;
            //Label lblSample = e.Row.FindControl("lblPPSampleTarget") as Label;

            //Label lblOutHouse = e.Row.FindControl("lblOutHouse") as Label;


            //  Add By Prabhaker 19-feb-18
            Label lblQAReportFile = e.Row.FindControl("lblQAReportFile") as Label;
            OrderController objOrderController = new OrderController();
            DataSet ds = new DataSet();
            TextBox txtWeight = e.Row.FindControl("txtWeight") as TextBox;
            Label lblWeight = e.Row.FindControl("lblWeight") as Label;
            Label lblUnitCostingWeight = e.Row.FindControl("lblUnitCostingWeight") as Label;
            Label lblQuantity = e.Row.FindControl("lblQuantity") as Label;
           
            decimal wightdecimal = 0;
            string qtygms="";
            string qtygmstooltip = "";
            int a = Convert.ToInt32( od.WeigtShipCost);
            float b = 1.15f;
            if (!string.IsNullOrEmpty(txtWeight.Text))
            {
              wightdecimal = Convert.ToDecimal(txtWeight.Text);   
            }

            qtygms = Math.Round(((Convert.ToDecimal(lblQuantity.Text) * Convert.ToDecimal(wightdecimal)) / 1000), 0, MidpointRounding.AwayFromZero).ToString();
            // updated code by bharat 7-jan-19
               qtygmstooltip = Math.Round((((Convert.ToInt32(qtygms)) * (Convert.ToInt32(a)) * (Convert.ToDecimal(b))) / 1000), 0).ToString();
            //end
           
            if (txtWeight.Text.Trim() == "0")
            {
                lblWeight.Text = "Pending weight";
                lblWeight.ForeColor = System.Drawing.Color.Red;
                txtWeight.Text = "";
                lblUnitCostingWeight.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                lblWeight.Text = "Weight";
                lblWeight.ForeColor = System.Drawing.Color.Gray;
                lblUnitCostingWeight.ForeColor = System.Drawing.Color.Gray;
                lblWeight.Attributes.Add("class", "Classnone");// updated by bharat
            }
            if (od.IsShiped == true)
            {
                lblWeight.ForeColor = System.Drawing.Color.Gray;
                lblUnitCostingWeight.ForeColor = System.Drawing.Color.Gray;
                txtWeight.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                txtWeight.ForeColor = System.Drawing.Color.Black;
            }
            //updated by bharat 31-Dec-18
            if (od.IsShiped == false)
            {
                lblUnitCostingWeight.Text = "<span style='color:gray !important;text-transform: lowercase !important'>" + lblUnitCostingWeight.Text + "</span>" + "        (" + qtygms + " kg)";
                lblUnitCostingWeight.ToolTip = " Airing Cost" + "  "  +"\u20B9" +" " + qtygmstooltip + "k"; //updated code by bharat  7-jan-19
            }
            else
            {
                lblUnitCostingWeight.Text = lblUnitCostingWeight.Text + "       (" + qtygms + " kg)";
                lblUnitCostingWeight.ToolTip = " Airing Cost" + "  "  + "\u20B9" + " " + qtygmstooltip + "k";  //updated code by bharat  7-jan-19
            }
            //end
            lblQAReportFile.Text = od.QaUploadReport;

            if (od.IsShiped == true)
            {
                lblQAReportFile.ForeColor = Color.Gray;
            }
            //End Of Code

            if (od.ModesIDByStyleID == 1)
            {
                txtWeight.Attributes.Add("disabled", "disabled");
            }

            //-----------------------------End----------------------------------

            //-------------------------STC and Order Sam---------------------------------------
            Label lblOrderSam = e.Row.FindControl("lblOrderSam") as Label;
            Label lblSTCSam = e.Row.FindControl("lblSTCSam") as Label;
            Label lblErrorShipment = e.Row.FindControl("lblErrorShipment") as Label;

            //------------------------End------------------------------------------------------
            Label lblQAStatus = e.Row.FindControl("lblQAStatus") as Label;
            Label lblRName = e.Row.FindControl("lblRName") as Label;
            Label lblMerChantFirstName = e.Row.FindControl("lblMerChantFirstName") as Label;
            Label lblMerChantRemarks = e.Row.FindControl("lblMerChantRemarks") as Label;
            HiddenField hdnAccRemarks = e.Row.FindControl("hdnAccRemarks") as HiddenField;
            Label lblAccessoriesRemark = e.Row.FindControl("lblAccessoriesRemark") as Label;
            Label lblFabUserName = e.Row.FindControl("lblFabUserName") as Label;
            Label lblFabRemark = e.Row.FindControl("lblFabRemark") as Label;
            HiddenField hdnFabRemarks = e.Row.FindControl("hdnFabRemarks") as HiddenField;
            HiddenField hdnMerchantRemarks = e.Row.FindControl("hdnMerchantRemarks") as HiddenField;

            Label lblPriceSymbol = e.Row.FindControl("lblPriceSymbol") as Label;
            Label lblikandiGross = e.Row.FindControl("lblikandiGross") as Label;
            Label lblIkandiPriceTag = e.Row.FindControl("lblIkandiPriceTag") as Label;
            Label lblIkandiDiscount = e.Row.FindControl("lblIkandiDiscount") as Label;
            Label lblMargin = e.Row.FindControl("lblMargin") as Label;
           // Label lblSeprator = e.Row.FindControl("lblSeprator") as Label;
            Label lblBusinessTag = e.Row.FindControl("lblBusinessTag") as Label;
            Label lblBusiness = e.Row.FindControl("lblBusiness") as Label;
            Label lblFitsName = e.Row.FindControl("lblFitsName") as Label;
            Label lblFitsRemark = e.Row.FindControl("lblFitsRemark") as Label;
            HiddenField hdnFitsRemarks = e.Row.FindControl("hdnFitsRemarks") as HiddenField;

            Label lblShippingName = e.Row.FindControl("lblShippingName") as Label;
            Label lblshippingRemarks = e.Row.FindControl("lblshippingRemarks") as Label;
            HiddenField hdnShipping = e.Row.FindControl("hdnShipping") as HiddenField;
            HtmlAnchor lnkShipping = e.Row.FindControl("lnkShipping") as HtmlAnchor;
            HtmlAnchor anchoeDetail_Rescan = e.Row.FindControl("anchoeDetail_Rescan") as HtmlAnchor;
            Label lblanchoeDetail_Rescan = e.Row.FindControl("lblanchoeDetail_Rescan") as Label;
            string anchorderDetailId = DataBinder.Eval(e.Row.DataItem, "OrderDetailID").ToString();
            string anchSerialNumber = od.ParentOrder.SerialNumber;
            string anchStyleNumber = od.ParentOrder.Style.StyleNumber;
            string anchQuantity = DataBinder.Eval(e.Row.DataItem, "Quantity").ToString();

            //anchoeDetail_Rescan.HRef = "javascript:SHOW_PRODUCTION_DETAIL('" + anchorderDetailId + "', '" + anchSerialNumber + "','" + anchStyleNumber + "','" + anchQuantity + "')";

            anchoeDetail_Rescan.HRef = "~/Internal/Production/ProductionDetails.aspx?OrderDetailId=" + anchorderDetailId + "&SerialNumber=" + anchSerialNumber + "&StyleNumber=" + anchStyleNumber + "&Quantity=" + anchQuantity;
            anchoeDetail_Rescan.Target = "_blank";
            
            TextBox lblDiscription = e.Row.FindControl("lblDiscription") as TextBox;
            TextBox lbLine = e.Row.FindControl("lbLine") as TextBox;
            TextBox lblContract = e.Row.FindControl("lblContract") as TextBox;
            Label lblOrderDate = e.Row.FindControl("lblOrderDate") as Label;
            HtmlAnchor hypstatusm = e.Row.FindControl("hypstatusmode") as HtmlAnchor;
            HtmlAnchor hypSerial1 = e.Row.FindControl("hypSerial") as HtmlAnchor;
            Label lblStatusUserName = e.Row.FindControl("lblStatusUserName") as Label;

            HtmlTableCell td1f1 = e.Row.FindControl("td1f1") as HtmlTableCell;
            HtmlTableCell td2f1 = e.Row.FindControl("td2f1") as HtmlTableCell;
            HtmlTableCell td3f1 = e.Row.FindControl("td3f1") as HtmlTableCell;
            HtmlTableCell td4f2 = e.Row.FindControl("td4f2") as HtmlTableCell;
            HtmlTableCell td5f2 = e.Row.FindControl("td5f2") as HtmlTableCell;
            HtmlTableCell td6f2 = e.Row.FindControl("td6f2") as HtmlTableCell;
            HtmlTableCell td7f3 = e.Row.FindControl("td7f3") as HtmlTableCell;
            HtmlTableCell td8f3 = e.Row.FindControl("td8f3") as HtmlTableCell;
            HtmlTableCell td9f3 = e.Row.FindControl("td9f3") as HtmlTableCell;
            HtmlTableCell td10f4 = e.Row.FindControl("td10f4") as HtmlTableCell;
            HtmlTableCell td11f4 = e.Row.FindControl("td11f4") as HtmlTableCell;
            HtmlTableCell td12f4 = e.Row.FindControl("td12f4") as HtmlTableCell;

            HtmlTableCell td1p1 = e.Row.FindControl("td1p1") as HtmlTableCell;
            HtmlTableCell td2p1 = e.Row.FindControl("td2p1") as HtmlTableCell;
            //HtmlTableCell td3p1 = e.Row.FindControl("td3p1") as HtmlTableCell;

            HtmlTableCell td1p2 = e.Row.FindControl("td1p2") as HtmlTableCell;
            HtmlTableCell td2p2 = e.Row.FindControl("td2p2") as HtmlTableCell;
            //HtmlTableCell td3p2 = e.Row.FindControl("td3p2") as HtmlTableCell;

            HtmlTableCell td1p3 = e.Row.FindControl("td1p3") as HtmlTableCell;
            HtmlTableCell td2p3 = e.Row.FindControl("td2p3") as HtmlTableCell;
            //HtmlTableCell td3p3 = e.Row.FindControl("td3p3") as HtmlTableCell;

            HtmlTableCell td1p4 = e.Row.FindControl("td1p4") as HtmlTableCell;
            HtmlTableCell td2p4 = e.Row.FindControl("td2p4") as HtmlTableCell;
            //HtmlTableCell td3p4 = e.Row.FindControl("td3p4") as HtmlTableCell;

            //Added By Ashish on 23/2/2015
            td1p1.Style.Add("background-color", od.BulkApproval1BackColor);
            td1p2.Style.Add("background-color", od.BulkApproval2BackColor);
            td1p3.Style.Add("background-color", od.BulkApproval3BackColor);
            td1p4.Style.Add("background-color", od.BulkApproval4BackColor);
            //END
            //Added By Ashish on 25/2/2015
            td3f1.Style.Add("background-color", od.Percent1BackColor);
            td6f2.Style.Add("background-color", od.Percent2BackColor);
            td9f3.Style.Add("background-color", od.Percent3BackColor);
            td12f4.Style.Add("background-color", od.Percent4BackColor);
            //END


            //Added By Ashish on 3/3/2014
            //For Permission
            HtmlAnchor spnSerialNumber = (HtmlAnchor)e.Row.FindControl("hypSerial");
            Label lblSerial = e.Row.FindControl("lblSerial") as Label;
            HtmlGenericControl spnStyleNumber = (HtmlGenericControl)e.Row.FindControl("spnStyleNumber");
            Label lblStyleNumber = e.Row.FindControl("lblStyleNumber") as Label;
            HtmlGenericControl spnBiplPrice = (HtmlGenericControl)e.Row.FindControl("spnBiplPrice");
            Label lblBiplPrice = (Label)e.Row.FindControl("lblBiplPrice");

            Label lbldressPrice = (Label)e.Row.FindControl("lbldressPrice");
            HtmlGenericControl spnDepartment = (HtmlGenericControl)e.Row.FindControl("spnDepartment");
            Label lblDepartment = (Label)e.Row.FindControl("lblDepartment");
            Label lblStatusMode = (Label)e.Row.FindControl("lblStatusMode");
            HtmlGenericControl exFactory = (HtmlGenericControl)e.Row.FindControl("exFactory");
            Label lblexFactory = (Label)e.Row.FindControl("lblexFactory");
            HtmlGenericControl spnmdano = (HtmlGenericControl)e.Row.FindControl("spnmdano");
            Label bllmda = (Label)e.Row.FindControl("bllmda");
            HtmlAnchor hypstatusmode1 = e.Row.FindControl("hypstatusmode") as HtmlAnchor;

            HtmlGenericControl fabric1name = (HtmlGenericControl)e.Row.FindControl("fabric1name");
            HtmlGenericControl fabric2name = (HtmlGenericControl)e.Row.FindControl("fabric2name");
            HtmlGenericControl fabric3name = (HtmlGenericControl)e.Row.FindControl("fabric3name");
            HtmlGenericControl fabric4name = (HtmlGenericControl)e.Row.FindControl("fabric4name");

            HtmlTableRow trFirstFabric = (HtmlTableRow)e.Row.FindControl("trFirstFabric");
            HtmlTableRow trfirstprint = (HtmlTableRow)e.Row.FindControl("trfirstprint");
            HtmlTableRow trsecFabric = (HtmlTableRow)e.Row.FindControl("trsecFabric");
            HtmlTableRow trsecPrint = (HtmlTableRow)e.Row.FindControl("trsecPrint");
            HtmlTableRow trthirdFabric = (HtmlTableRow)e.Row.FindControl("trthirdFabric");
            HtmlTableRow trthirdprint = (HtmlTableRow)e.Row.FindControl("trthirdprint");
            HtmlTableRow trfourFabric = (HtmlTableRow)e.Row.FindControl("trfourFabric");
            HtmlTableRow trfourprint = (HtmlTableRow)e.Row.FindControl("trfourprint");

            HyperLink hlkViewMe = (HyperLink)e.Row.FindControl("hlkViewMe");
            HyperLink viewolay1 = (HyperLink)e.Row.FindControl("viewolay1");
            HyperLink viewInvoice = (HyperLink)e.Row.FindControl("viewInvoice");

            HtmlGenericControl dvQCFileUpload = (HtmlGenericControl)e.Row.FindControl("dvQCFileUpload");



            //if (od.OBfile != "")
            //    hlkViewMe.NavigateUrl = "~/Uploads/Photo/" + od.OBfile;

            Label lblFab1 = (Label)e.Row.FindControl("lblFab1");
            Label lblFab2 = (Label)e.Row.FindControl("lblFab2");
            Label lblFab3 = (Label)e.Row.FindControl("lblFab3");
            Label lblFab4 = (Label)e.Row.FindControl("lblFab4");

            // Added by ravi kumar on 21/2/18
            HyperLink lnkreallocation = e.Row.FindControl("lnkreallocation") as HyperLink;
            lnkreallocation.NavigateUrl = "~/Internal/Merchandising/ReAllocationForm.aspx?OrderDetailId=" + od.OrderDetailID + "&styleId=" + (od.ParentOrder as iKandi.Common.Order).Style.StyleID.ToString() + "&StatusFrom=" + this.StatusMode_ForIntial.ToString() + "&StatusTo=" + this.StatusMode_ForDouble.ToString();
            if (lnkreallocation != null)
            {
                if (od.ReadWriteReallocationLink == true)
                {
                    lnkreallocation.Enabled = true;
                }
            }

            int Quantity = Convert.ToInt32(od.Quantity);
            if (spnSerialNumber != null)
            {
                if (od.bSerialNowrite != true)
                {
                    if (od.bSerialNo != true)
                    {
                        spnSerialNumber.Visible = false;
                        lblSerial.Visible = false;
                    }
                    else
                    {
                        spnSerialNumber.Visible = false;
                        lblSerial.Visible = true;
                    }
                }
                else
                {
                    spnSerialNumber.Visible = true;
                    lblSerial.Visible = false;
                }
            }
            if (spnStyleNumber != null)
            {
                if (od.bStyleNowrite != true)
                {
                    if (od.bStylelNo != true)
                    {
                        spnStyleNumber.Visible = false;
                        lblStyleNumber.Visible = false;
                    }
                    else
                    {
                        spnStyleNumber.Visible = false;
                        lblStyleNumber.Visible = true;
                    }
                }
                else
                {
                    spnStyleNumber.Visible = true;
                    lblStyleNumber.Visible = false;
                }
            }
            if (spnBiplPrice != null)
            {
                if (od.bBIPLPricewrite != true)
                {
                    if (od.bBIPLPrice != true)
                    {
                        spnBiplPrice.Visible = false;
                        lblBiplPrice.Visible = false;
                    }
                    else
                    {
                        spnBiplPrice.Visible = false;
                        lblBiplPrice.Visible = true;
                    }
                }
                else
                {
                    spnBiplPrice.Visible = true;
                    lblBiplPrice.Visible = false;
                }
            }
            //abhishek on 11/7/2016
            if (lbldressPrice != null)
            {

                if (lbldressPrice.Text == "" || lbldressPrice.Text == "0.00")
                {
                    lbldressPrice.Visible = false;
                }
                else
                {
                    double OldPrice = Convert.ToDouble((od.ParentOrder as iKandi.Common.Order).BiplPrice);

                    string strff = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto));
                    lbldressPrice.Text = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto)) + "" + lbldressPrice.Text + " |";
                    if ((od.DressPrice) == OldPrice)
                    {
                        lbldressPrice.Visible = false;
                    }
                    else
                    {
                        if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Company == iKandi.Common.Company.Boutique)
                            spnBiplPrice.Attributes.Add("Class", "redcrossline");
                    }
                }
            }

            //end abhishek on 13/7/2016
            lblPriceSymbol.Visible = od.bIKANDIPriceGrossRead;
            lblPriceSymbol.Enabled = od.bIKANDIPriceGrosswrite;
            lblikandiGross.Visible = od.bIKANDIPriceGrossRead;
            lblikandiGross.Enabled = od.bIKANDIPriceGrosswrite;

            lblIkandiDiscount.Visible = od.bIKANDIPriceRead;
            lblIkandiDiscount.Enabled = od.bIKANDIPricewrite;
            lblIkandiPriceTag.Visible = od.bIKANDIPriceRead;
            lblIkandiPriceTag.Enabled = od.bIKANDIPricewrite;
            lblMargin.Text = Convert.ToString(od.Margin) + "%";
            lblMargin.Visible = od.bMarginRead;
            lblMargin.Enabled = od.bMarginwrite;

            lblBusiness.Visible = od.bBusinessRead;
            lblBusiness.Enabled = od.bBusinesswrite;
            lblBusinessTag.Visible = od.bBusinessRead;
            lblBusinessTag.Enabled = od.bBusinesswrite;

            //added by 13/7/2016 abhishek if buyer of ikandi then hide all below lable else show
            if ((od.IsIkandiClient == 1))
            {
                lblIkandiPriceTag.Visible = true;
                lblIkandiDiscount.Visible = true;
                lblMargin.Visible = true;
               // lblSeprator.Visible = true;

            }
            else
            {
                lblIkandiPriceTag.Visible = false;
                lblIkandiDiscount.Visible = false;
              //  lblSeprator.Visible = false;
                lblMargin.Visible = false;
            }
            //end 

            if (spnDepartment != null)
            {
                if (od.bDepartmentwrite != true)
                {
                    if (od.bDepartmentRead != true)
                    {
                        spnDepartment.Visible = false;
                        lblDepartment.Visible = false;
                    }
                    else
                    {
                        spnDepartment.Visible = false;
                        lblDepartment.Visible = true;
                    }
                }
                else
                {
                    spnDepartment.Visible = true;
                    lblDepartment.Visible = false;
                }
            }

            if (hypstatusmode1 != null)
            {
                if (od.bStatuswrite != true)
                {
                    if (od.bStatusRead != true)
                    {
                        hypstatusmode1.Visible = false;
                        lblStatusMode.Visible = false;
                    }
                    else
                    {
                        hypstatusmode1.Visible = false;
                        lblStatusMode.Visible = true;
                    }
                }
                else
                {
                    hypstatusmode1.Visible = true;
                    lblStatusMode.Visible = false;
                }
            }

            HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("divexFactory");
            HtmlGenericControl divAgreement = (HtmlGenericControl)e.Row.FindControl("divAgreement");
            Label lblPendingAgrement = e.Row.FindControl("lblPendingAgrement") as Label;


            if (od.BIPLAgreementPending == 1)
            {
                divAgreement.Visible = true;
                if (od.IsShiped == true)
                    lblPendingAgrement.Style.Add("color", "#807F80");
                else
                    lblPendingAgrement.Style.Add("color", "red");
            }
            else
                divAgreement.Visible = false;


            if (exFactory != null)
            {
                if (od.bExFactorywrite != true)
                {
                    if (od.bExFactoryRead != true)
                    {
                        exFactory.Visible = false;
                        lblexFactory.Visible = false;
                        divexFactory.Visible = false;
                    }
                    else
                    {
                        exFactory.Visible = false;
                        lblexFactory.Visible = true;
                        divexFactory.Visible = true;
                    }
                }
                else
                {
                    exFactory.Visible = true;
                    lblexFactory.Visible = false;
                    divexFactory.Visible = false;
                }
            }
            if (spnmdano != null)
            {
                if (od.bMDAwrite != true)
                {
                    if (od.bMDARead != true)
                    {
                        spnmdano.Visible = false;
                        bllmda.Visible = false;
                    }
                    else
                    {
                        spnmdano.Visible = false;
                        bllmda.Visible = true;
                    }
                }
                else
                {
                    spnmdano.Visible = true;
                    bllmda.Visible = false;
                }
            }
            ddlOuthouse.SelectedValue = od.OutHouseAll;
            if (od.OutHouseAllocationWrite == false && od.OutHouseAllocationRead == false)
            {
                //lblOutHouse.Visible = false;
                ddlOuthouse.Visible = false;
            }
            else
            {
                if (od.IsShiped == true)
                {

                    ddlOuthouse.Enabled = false;
                    //lblOutHouse.Style.Add("color", "Gray");
                    ddlOuthouse.Style.Add("color", "Gray");

                }
                else
                {
                    if (od.OutHouseAllocationWrite)
                    {
                        ddlOuthouse.Enabled = true;
                    }
                    else
                    {
                        ddlOuthouse.Enabled = false;
                    }

                }
                //lblOutHouse.Visible = true;
                ddlOuthouse.Visible = true;

            }

            HtmlGenericControl maindivmda = e.Row.FindControl("maindivmda") as HtmlGenericControl;
            HiddenField hdnmda = e.Row.FindControl("hdnmda") as HiddenField;

            HtmlGenericControl lnkBalancePercentCut = e.Row.FindControl("lnkBalancePercentCut") as HtmlGenericControl;
            HtmlGenericControl lnkBPerCut = e.Row.FindControl("lnkBPerCut") as HtmlGenericControl;
            HtmlGenericControl divBlank = e.Row.FindControl("divBlank") as HtmlGenericControl;
            if (lnkBalancePercentCut != null)
            {
                if (od.POverallWrite != true)
                {
                    if (od.POverallRead != true)
                    {
                        lnkBalancePercentCut.Visible = false;
                        lnkBPerCut.Visible = false;
                        divBlank.Visible = true;
                    }
                    else
                    {
                        lnkBalancePercentCut.Visible = false;
                        lnkBPerCut.Visible = true;
                        divBlank.Visible = false;
                    }
                }
                else
                {
                    lnkBalancePercentCut.Visible = true;
                    lnkBPerCut.Visible = false;
                    divBlank.Visible = false;
                }
            }

            //Added by Ashish on 4/4/2014
            HtmlGenericControl BalancePercentStitchedIssued = e.Row.FindControl("BalancePercentStitchedIssued") as HtmlGenericControl;
            HtmlGenericControl BPercentStitchedIssued = e.Row.FindControl("BPercentStitchedIssued") as HtmlGenericControl;
            HtmlGenericControl BPercentStitchedIssuedBlanck = e.Row.FindControl("BPercentStitchedIssuedBlanck") as HtmlGenericControl;

            HtmlGenericControl divStitchedETA = e.Row.FindControl("divStitchedETA") as HtmlGenericControl;
            HtmlGenericControl divEmbETA = e.Row.FindControl("divEmbETA") as HtmlGenericControl;
            HtmlGenericControl divPacked = e.Row.FindControl("divPacked") as HtmlGenericControl;
            if (BalancePercentStitchedIssued != null)
            {
                if (od.POverallWrite != true)
                {
                    if (od.POverallRead != true)
                    {
                        BalancePercentStitchedIssued.Visible = false;
                        BPercentStitchedIssued.Visible = false;
                        BPercentStitchedIssuedBlanck.Visible = true;
                    }
                    else
                    {
                        BalancePercentStitchedIssued.Visible = false;
                        BPercentStitchedIssued.Visible = true;
                        BPercentStitchedIssuedBlanck.Visible = false;
                    }
                }
                else
                {
                    BalancePercentStitchedIssued.Visible = true;
                    BPercentStitchedIssued.Visible = false;
                    BPercentStitchedIssuedBlanck.Visible = false;
                }
            }


            HtmlGenericControl divBalancePercentPacked = e.Row.FindControl("divBalancePercentPacked") as HtmlGenericControl;
            HtmlGenericControl divlblBalancePercentPacked = e.Row.FindControl("divlblBalancePercentPacked") as HtmlGenericControl;
            HtmlGenericControl divBalancePercentPackedBlanck = e.Row.FindControl("divBalancePercentPackedBlanck") as HtmlGenericControl;
            if (divBalancePercentPacked != null)
            {
                if (od.POverallWrite != true)
                {
                    if (od.POverallRead != true)
                    {
                        divBalancePercentPacked.Visible = false;
                        divlblBalancePercentPacked.Visible = false;
                        divBalancePercentPackedBlanck.Visible = true;
                    }
                    else
                    {
                        divBalancePercentPacked.Visible = false;
                        divlblBalancePercentPacked.Visible = true;
                        divBalancePercentPackedBlanck.Visible = false;
                    }
                }
                else
                {
                    divBalancePercentPacked.Visible = true;
                    divlblBalancePercentPacked.Visible = false;
                    divBalancePercentPackedBlanck.Visible = false;
                }
            }


            Label lblFabric1Details = e.Row.FindControl("lblFabric1Details") as Label;
            Label lblFabric2Details = e.Row.FindControl("lblFabric2Details") as Label;
            Label lblFabric3Details = e.Row.FindControl("lblFabric3Details") as Label;
            Label lblFabric4Details = e.Row.FindControl("lblFabric4Details") as Label;

            Label lblfabricApprovalColor1 = e.Row.FindControl("lblfabricApprovalColor1") as Label;
            Label lblfabricApprovalColor2 = e.Row.FindControl("lblfabricApprovalColor2") as Label;
            Label lblfabricApprovalColor3 = e.Row.FindControl("lblfabricApprovalColor3") as Label;
            Label lblfabricApprovalColor4 = e.Row.FindControl("lblfabricApprovalColor4") as Label;

            if (od.FQualityWrite != true)
            {
                if (od.FQualityRead != true)
                {
                    fabric1name.Visible = false;
                    lblFab1.Visible = false;
                    fabric2name.Visible = false;
                    lblFab2.Visible = false;
                    fabric3name.Visible = false;
                    lblFab3.Visible = false;
                    fabric4name.Visible = false;
                    lblFab4.Visible = false;
                    lblFabric1Details.Visible = false;
                    lblFabric2Details.Visible = false;
                    lblFabric3Details.Visible = false;
                    lblFabric4Details.Visible = false;

                    lblfabricApprovalColor1.Visible = false;
                    lblfabricApprovalColor2.Visible = false;
                    lblfabricApprovalColor3.Visible = false;
                    lblfabricApprovalColor4.Visible = false;

                }
                else
                {
                    fabric1name.Visible = false;
                    lblFab1.Visible = true;
                    fabric2name.Visible = false;
                    lblFab2.Visible = true;
                    fabric3name.Visible = false;
                    lblFab3.Visible = true;
                    fabric4name.Visible = false;
                    lblFab4.Visible = true;

                    lblFabric1Details.Visible = true;
                    lblFabric2Details.Visible = true;
                    lblFabric3Details.Visible = true;
                    lblFabric4Details.Visible = true;

                    lblfabricApprovalColor1.Visible = true;
                    lblfabricApprovalColor2.Visible = true;
                    lblfabricApprovalColor3.Visible = true;
                    lblfabricApprovalColor4.Visible = true;
                }
            }
            else
            {
                if (fabric1name != null)
                {
                    if (od.CutWidth1 != 0)
                    {
                        lblCutwidth1.Text = "/" + od.CutWidth1 + " in";
                        lblCutwidth1.Visible = true;

                    }
                    fabric1name.Visible = true;
                    lblFab1.Visible = false;
                    lblFabric1Details.Visible = true;
                    lblfabricApprovalColor1.Visible = true;
                    fabric1name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric1name.InnerText.Trim() + "', " + "'" + lblFabric1Details.Text.Trim() + "', '" + 1 + "');");
                }
                if (fabric2name != null)
                {
                    if (od.CutWidth2 != 0)
                    {
                        lblCutwidth2.Text = "/" + od.CutWidth2 + " in";
                        lblCutwidth2.Visible = true;

                    }
                    fabric2name.Visible = true;
                    lblFab2.Visible = false;
                    lblFabric2Details.Visible = true;
                    lblfabricApprovalColor2.Visible = true;
                    fabric2name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric2name.InnerText.Trim() + "', " + "'" + lblFabric2Details.Text.Trim() + "', '" + 2 + "');");
                }
                if (fabric3name != null)
                {
                    if (od.CutWidth3 != 0)
                    {
                        lblCutwidth3.Text = "/" + od.CutWidth3 + " in";
                        lblCutwidth3.Visible = true;
                    }
                    fabric3name.Visible = true;
                    lblFab3.Visible = false;
                    lblFabric3Details.Visible = true;
                    lblfabricApprovalColor3.Visible = true;
                    fabric3name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric3name.InnerText.Trim() + "', " + "'" + lblFabric3Details.Text.Trim() + "', '" + 3 + "');");
                }
                if (fabric4name != null)
                {
                    if (od.CutWidth4 != 0)
                        lblCutwidth4.Text = "/" + od.CutWidth4 + " in";
                    lblCutwidth4.Visible = true;
                    fabric4name.Visible = true;
                    lblFab4.Visible = false;
                    lblFabric4Details.Visible = true;
                    lblfabricApprovalColor4.Visible = true;
                    fabric4name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric4name.InnerText.Trim() + "', " + "'" + lblFabric4Details.Text.Trim() + "','" + 4 + "');");
                }
            }
            //if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Company == iKandi.Common.Company.Boutique)
            //{
            if (od.ParentOrder.WorkflowInstanceDetail.StatusModeID >= 25)
                dvQCFileUpload.Visible = true;
            else
                dvQCFileUpload.Visible = false;

            //}
            //else
            //{
            //    dvQCFileUpload.Visible = false;
            //}

            HtmlGenericControl spnInline = (HtmlGenericControl)e.Row.FindControl("spnInline");
            Label lblInline = (Label)e.Row.FindControl("lblInline");
            if (spnInline != null)
            {
                if (od.FitsTgtDateWrite != true)
                {
                    if (od.FitsTgtDateRead != true)
                    {
                        spnInline.Visible = false;
                        lblInline.Visible = false;
                    }
                    else
                    {
                        spnInline.Visible = false;
                        lblInline.Visible = true;
                    }
                }
                else
                {
                    spnInline.Visible = true;
                    lblInline.Visible = false;
                }
            }

            HtmlGenericControl spanFabTracking = (HtmlGenericControl)e.Row.FindControl("spanFabTracking");
            if (spanFabTracking != null)
            {
                if (od.FFabricTrackingWrite == true || od.FFabricTrackingRead == true)
                {
                    spanFabTracking.Visible = true;
                }
                else
                {
                    spanFabTracking.Visible = false;
                }

            }

            HtmlAnchor spnOrdSam = (HtmlAnchor)e.Row.FindControl("spnOrdSam");
            Label lblOrdSam = (Label)e.Row.FindControl("lblOrdSam");
            HtmlAnchor spnStcSam = (HtmlAnchor)e.Row.FindControl("spnStcSam");
            Label lblSTC = (Label)e.Row.FindControl("lblSTC");
            if (spnOrdSam != null)
            {
                if (od.FitsOrderSamWrite != true)
                {
                    if (od.FitsOrderSamRead != true)
                    {
                        spnOrdSam.Visible = false;
                        lblOrdSam.Visible = false;
                    }
                    else
                    {
                        spnOrdSam.Visible = false;
                        lblOrdSam.Visible = true;
                    }
                }
                else
                {
                    spnOrdSam.Visible = true;
                    lblOrdSam.Visible = false;
                }
            }

            if (spnStcSam != null)
            {
                if (od.FitsSTCSamWrite != true)
                {
                    if (od.FitsSTCSamRead != true)
                    {
                        spnStcSam.Visible = false;
                        lblSTC.Visible = false;
                    }
                    else
                    {
                        spnStcSam.Visible = false;
                        lblSTC.Visible = true;
                    }
                }
                else
                {
                    spnStcSam.Visible = true;
                    lblSTC.Visible = false;
                }
            }

            //END 
            //====================================  spnOrdSam lblOrdSam

            if (td1f1 != null)
            {
                if (od.Fabric1 != "")
                {
                    trFirstFabric.Visible = true;
                    trfirstprint.Visible = true;

                }
            }
            if (td4f2 != null)
            {
                if (od.Fabric2 != "")
                {
                    trsecFabric.Visible = true;
                    trsecPrint.Visible = true;
                }
            }

            if (td7f3 != null)
            {
                if (od.Fabric3 != "")
                {
                    trthirdFabric.Visible = true;
                    trthirdprint.Visible = true;
                }

            }

            if (td10f4 != null)
            {
                if (od.Fabric4 != "")
                {
                    trfourFabric.Visible = true;
                    trfourprint.Visible = true;
                }

            }

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            HtmlAnchor lnkAccesspopup = e.Row.FindControl("lnkAccesspopup") as HtmlAnchor;
            if (lnkAccesspopup != null)
            {
                string strAccessRemark = hdnAccRemarks.Value.Replace("'", "!<@#");
                // lnkAccesspopup.Attributes.Add("onclick", "javascript:showRemarks('0','" + od.OrderDetailID + "','" + strAccessRemark + "','MANAGE_ORDERS_FILE_ACCESSORIES_ACCESSORIES_REMARKS','MANAGE_ORDER_FILE','0','')");
                lnkAccesspopup.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Access')");
                if (iKandi.Common.MOOrderDetails.AccRemarkWrite == true || iKandi.Common.MOOrderDetails.AccRemarkRead == true)
                {
                    lnkAccesspopup.Visible = true;
                    lblRName.Visible = true;
                    lblAccessoriesRemark.Visible = true;
                }
                else
                {
                    lnkAccesspopup.Visible = false;
                    lblRName.Visible = false;
                    lblAccessoriesRemark.Visible = false;
                }
            }

            HtmlAnchor lnkFabpopup = e.Row.FindControl("lnkFabpopup") as HtmlAnchor;

            HtmlAnchor lnkFitsPopUp = e.Row.FindControl("lnkFitsPopUp") as HtmlAnchor;
            HtmlAnchor lnkFitsPopUpETAfil = e.Row.FindControl("lnkFitsPopUpETAfil") as HtmlAnchor;
            HtmlAnchor lnkMerchantPopUp = e.Row.FindControl("lnkMerchantPopUp") as HtmlAnchor;

            lblPriceSymbol.Text = "Rs";
            //lblikandiGross.Text = Convert.ToString(od.iKandiPrice);
            lblikandiGross.Text = Convert.ToString(od.BoutiqueBusiness) + " " + "Lac | ";
            lblIkandiPriceTag.Text = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto));
            if (Convert.ToString(od.discount).Length >= 5)
                lblIkandiDiscount.Text = Convert.ToString(od.discount).Substring(0, 5) + " | ";
            else
                lblIkandiDiscount.Text = Convert.ToString(od.discount) + " | "; 

            //string strQARemarks = this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0);
            //if (strQARemarks.Length >= 42)
            //{
            //    lblQAStatus.Text = this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0).Substring(0, 42);
            //}
            //else
            //{
            //    lblQAStatus.Text = strQARemarks;
            //}
            ////  lblQAStatus.Text = this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0);
            //lblQAStatus.ToolTip = strQARemarks;

            if (od.ParentOrder.WorkflowInstanceDetail.StatusModeID < Convert.ToInt32(TaskMode.Sealed_To_Cut))
            {
                lblQAStatus.CssClass = "hide_me";

                //  lblStatusUserName.CssClass = "hide_me";
            }
            if (od.ParentOrder.Style.client.IsMDARequired == 0)
            {
                spnmdano.Attributes.Add("CssClass", "hide_me");
            }

            int OrderDetaildidforline = od.OrderDetailID;

            //if (od.PatternSampleDate != DateTime.MinValue)
            //{
            //    lblPatternSampleDate.CssClass = "do-not-allow-typing";
            //}
            if (od.CuttingReceivedDate != DateTime.MinValue)
            {
                lblCuttingSheetDate.CssClass = "do-not-allow-typing";
            }
            if (od.CuttingReceivedDateETA != DateTime.MinValue && od.CuttingReceivedDate != DateTime.MinValue)
            {
                TextBox1.CssClass = "do-not-allow-typing";
            }
            if (od.ProductionFileDate != DateTime.MinValue)
            {
                lblProductionFileDate.CssClass = "do-not-allow-typing";
            }
            if (od.ProductionFileDateETA != DateTime.MinValue && od.ProductionFileDate != DateTime.MinValue)
            {
                TextBox2.CssClass = "do-not-allow-typing";
            }
            //if (od.PPSampleETA != DateTime.MinValue)
            //{
            //    TextBox4.CssClass = "do-not-allow-typing";
            //}


            if (od.HandOverETADate != DateTime.MinValue && od.HandOverActualDate != DateTime.MinValue)
            {
                txtHanoverETA.CssClass = "do-not-allow-typing";
            }

            if (od.PatternReadyETADate != DateTime.MinValue && od.PatternReadyActualDate != DateTime.MinValue)
            {
                txtPatternReadyETADate.CssClass = "do-not-allow-typing";
            }

            if (od.SampleSentETADate != DateTime.MinValue && od.SampleSentActualDate != DateTime.MinValue)
            {
                txtSampleSentETA.CssClass = "do-not-allow-typing";
            }
            if (od.FitsCommentesETADate != DateTime.MinValue && od.FitsCommentesActualDate != DateTime.MinValue)
            {
                txtFitsCommentesUplaodETADate.CssClass = "do-not-allow-typing";
            }

            // edit by surendra if Prod date,cutting sheet date,
            lblBusinessTag.Text = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto));
            if (Convert.ToString(od.Business).Length >= 6)
                lblBusiness.Text = Convert.ToString(od.Business).Substring(0, 5) + " " + "K";
            else
                lblBusiness.Text = Convert.ToString(od.Business) + " " + "K";


            HtmlGenericControl newtext4 = e.Row.FindControl("newtext4") as HtmlGenericControl;
            Label lblDeptName = (Label)e.Row.FindControl("lblDeptName");


            Label lblStatusMode1 = (Label)e.Row.FindControl("lblStatusMode");
            HtmlGenericControl newtext2 = (HtmlGenericControl)e.Row.FindControl("newtext2");
            Label lblStyleNo = (Label)e.Row.FindControl("lblStyleNo");
            if (lnkFabpopup != null)
            {//Edited By Ashish on 5/3/2014
                string FabricRemark = hdnFabRemarks.Value.Replace("'", "!<@#");
                //lnkFabpopup.Attributes.Add("onclick", "javascript:showRemarks('" + od.OrderDetailID + "','0','" + FabricRemark + "','MANAGE_ORDERS_FILE_FABRIC_FABRIC_REMARKS','MANAGE_ORDER_FILE','0','')");
                lnkFabpopup.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Fabric')");
                if (od.FFabricRemarkWrite == true || od.FFabricRemarkRead == true)
                {
                    lnkFabpopup.Visible = true;
                    lblFabUserName.Visible = true;
                    lblFabRemark.Visible = true;
                }
                else
                {
                    lnkFabpopup.Visible = false;
                    lblFabUserName.Visible = false;
                    lblFabRemark.Visible = false;
                }
                //END
            }
            if (lnkMerchantPopUp != null)
            {
                lnkMerchantPopUp.Attributes.Add("onclick", "javascript:FabricRemark('" + hdnMerchantRemarks.Value.Replace("'", "!<@#") + "')");
            }
            if (lnkFitsPopUp != null)
            {

                // lnkFitsPopUp.Attributes.Add("onclick", "javascript:showRemarks('" + od.OrderDetailID + "','0','" + hdnFitsRemarks.Value.Replace("'", "!<@#") + "','MerchantNotes','MANAGE_ORDER_FILE','0','')");
                lnkFitsPopUp.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Technical')");
                if (od.FitsRemarkWrite == true || od.FitsRemarkRead == true)
                {
                    lnkFitsPopUp.Visible = true;
                    lblFitsName.Visible = true;
                    lblFitsRemark.Visible = true;
                }
                else
                {
                    lnkFitsPopUp.Visible = false;
                    lblFitsName.Visible = false;
                    lblFitsRemark.Visible = false;
                }
            }
            if (lnkFitsPopUpETAfil != null)
            {
                lnkFitsPopUpETAfil.Attributes.Add("onclick", "javascript:showEtaFitspopup(" + od.OrderDetailID + ")");
            }
            HiddenField hdnProductionRemark = e.Row.FindControl("hdnProductionRemark") as HiddenField;
            HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;


            HtmlAnchor lnkopenShipedPopoup = e.Row.FindControl("lnkopenShipedPopoup") as HtmlAnchor;
            lnkopenShipedPopoup.Attributes.Add("onclick", "javascript:openShipedPopu('" + od.OrderDetailID + "','" + od.OrderID + "', '" + od.Quantity + "')");

            if (od.IsShiped == true)
            {
                lnkopenShipedPopoup.Style.Add("background-color", "#F9F9FA");
                lnkopenShipedPopoup.Style.Add("color", "#807F80");
            }

            if (lnkProductionpopup != null)
            {
                string productionRemark = hdnProductionRemark.Value.Replace("'", "!<@#");
                //lnkProductionpopup.Attributes.Add("onclick", "javascript:showRemarks('0','" + od.OrderDetailID + "','" + productionRemark + "','ProdRemarks','MANAGE_ORDER_FILE','0','')");
                lnkProductionpopup.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Production')");
                if (od.PProductionRemarkRead == true || od.PProductionsRemarkWrite == true)
                {
                    lnkProductionpopup.Visible = true;
                }
                else
                {
                    lnkProductionpopup.Visible = false;
                }
            }
            // Update by Ravi kumar on /6/2016            
            CheckBox chkshipped = e.Row.FindControl("chkshipped") as CheckBox;
            if (od.IsShipedWrite)
            {
                //if ((od.Finish_80 == 1))
                //    chkshipped.Enabled = true;
                //else
                //    chkshipped.Enabled = false;
                // Edit by surendra on 04/08/2017 for checking packing upload path for enable check box of shipping pop up
                //if ((od.QCNarration.ToLower().Contains("fnl pass") || od.QualityControl_Prev_Status.ToLower().Contains("fnl pass")) && (od.PackingListUploadPath !=""))
                if ((od.QCNarration.ToLower().Contains("final pass") || od.QualityControl_Prev_Status.ToLower().Contains("final pass")))
                    chkshipped.Enabled = true;
                else
                    chkshipped.Enabled = false;
            }
            //if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID) == 11 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID) == 5)
            //{
            if (od.PackingListUploadPath != "")
            {
                //viewolay1.NavigateUrl = "~/Uploads/Photo/" + fabricWorking.Fabric1File;
                //viewolay1.Attributes.Add("style", "display:block;");
                //lnkFitsPopUp.Attributes.Add("onclick", "javascript:ShowPackingList('PACKING'" + od.OrderID + ")");
                viewolay1.Visible = true;
                viewolay1.NavigateUrl = Deliveryfolder + od.PackingListUploadPath;
            }
            //viewolay1.NavigateUrl = Path.Combine(Constants.PHOTO_FOLDER_PATH, od.PackingListUploadPath);

            //viewolay1.Attributes.Add("style", "display:block;");
            //lblPackingName.Text = "PkngList";
            //lblPackingName.Visible = false;
            //hypPackingName.Visible = true;
            //hypPackingName.Style.Remove("border"); hypPackingName.Style.Remove("padding");
            //hypPackingName.Attributes.Add("onclick", "javascript:return ShowPackingList('PACKING', " + od.OrderID + ", " + od.OrderDetailID + ");");
            if ((od.ParentOrder.WorkflowInstanceDetail.StatusModeSequence >= 61) && (od.ShipmentNo == ""))
            {
                hypShipmentNo.Visible = true;
                lblConsolidated.Text = "Consolidate";
                hypShipmentNo.Attributes.Add("onclick", "javascript:return ShowPackingList('CONSOLIDATION', " + od.OrderID + ", " + od.OrderDetailID + ");");

            }
            else
            {
                hypShipmentNo.Visible = true;
                lblConsolidated.Text = od.ShipmentNo;
                hypShipmentNo.Style.Remove("border"); hypShipmentNo.Style.Remove("padding");
                hypShipmentNo.Attributes.Add("onclick", "javascript:return ShowPackingList('CONSOLIDATION', " + od.OrderID + ", " + od.OrderDetailID + ");");
                if (od.InvoiceUploadPath != "")
                {
                    viewInvoice.Visible = true;

                    viewInvoice.NavigateUrl = Deliveryfolder + od.InvoiceUploadPath;
                    //viewolay1.NavigateUrl = Path.Combine(Constants.PHOTO_FOLDER_PATH, od.PackingListUploadPath);

                    //  viewInvoice.Attributes.Add("style", "display:block;");
                }
                else
                {
                    viewInvoice.Visible = false;

                    //viewolay1.NavigateUrl = Deliveryfolder + od.PackingListUploadPath;
                    ////viewolay1.NavigateUrl = Path.Combine(Constants.PHOTO_FOLDER_PATH, od.PackingListUploadPath);

                    //viewolay1.Attributes.Add("style", "display:block;");
                }
                string shipmentnp = od.ShipmentNo.Replace("-", " ");
                if (Convert.ToString(od.InvoiceNo) == "")
                {
                    if (od.ShipmentNo != "")
                    {
                        hypInvoice.Visible = true;
                        lblInvoice.Text = "Invoice";
                        hypInvoice.Attributes.Add("onclick", "javascript:return ShowInvoiceListNew('" + "INVOICED" + "','" + od.OrderID + "','" + od.OrderDetailID + "', '" + od.ShipmentNo + "');");
                    }

                }
                else
                {
                    hypInvoice.Visible = true;
                    lblInvoice.Text = "| " + od.InvoiceNo;
                    lblInvoice.Visible = true;
                    hypInvoice.Style.Remove("border"); hypInvoice.Style.Remove("padding");
                    hypInvoice.Attributes.Add("onclick", "javascript:return ShowInvoiceListNew('" + "INVOICED" + "','" + od.OrderID + "','" + od.OrderDetailID + "', '" + od.ShipmentNo + "');");
                    if (od.BankRefNo != "")
                    {

                        hypBankRefNo.Visible = true;
                        string[] bnkref = od.BankRefNo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                        if (bnkref[0].ToString().ToUpper() == "NEW")
                        {
                            lblBankRefNo.Text = "BnkRef";
                            lblPendingPayment.Visible = false;
                            lblPaymentDueDate.Visible = false;

                        }
                        else
                        {
                            lblBankRefNo.Text = "| " + od.BankRefNo;
                            lblPendingPayment.Visible = true;
                            lblPaymentDueDate.Visible = true;
                            hypBankRefNo.Style.Remove("border"); hypBankRefNo.Style.Remove("padding");
                        }

                        hypBankRefNo.Attributes.Add("onclick", "javascript:return ShowInvoicePayment('" + "INVOICEPAYMENT" + "','" + od.OrderID + "','" + od.OrderDetailID + "', '" + od.BankRefNo + "', '" + od.ShipmentNo + "');");

                    }
                    else
                    {
                        if (od.InvoiceNo != "")
                        {
                            hypInvoice.Visible = true;
                            lblInvoice.Text = "| " + od.InvoiceNo;
                            lblInvoice.Visible = true;
                        }
                    }


                    string CuySum = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto));

                    if (od.PendingPayment == "")
                        od.PendingPayment = "0";
                    if (od.TotalPayment == "")
                        od.TotalPayment = "0";

                    if (Convert.ToDouble(od.PendingPayment) > 0)
                    {
                        lblPendingPayment.Text = "Pending Payment " + CuySum + " " + od.PendingPayment + "k No Recieving yet";
                        if (Convert.ToDateTime(od.PaymentDueDate) < DateTime.Now)
                            lblPaymentDueDate.ForeColor = Color.Red;
                        else
                            lblPaymentDueDate.ForeColor = Color.Green;
                    }
                    if (Convert.ToDouble(od.TotalPayment) > 0)
                    {
                        lblPendingPayment.Text = "No Dues " + " (Received " + CuySum + " " + od.TotalPayment + "k ) ";
                        lblPaymentDueDate.ForeColor = Color.Black;
                    }
                    if ((Convert.ToDouble(od.PendingPayment) > 0) && (Convert.ToDouble(od.TotalPayment) > 0))
                    {
                        lblPendingPayment.Text = "Pending Payment " + CuySum + " " + od.PendingPayment + "k (Received " + CuySum + " " + od.TotalPayment + "k) ";
                        if (Convert.ToDateTime(od.PaymentDueDate) < DateTime.Now)
                            lblPaymentDueDate.ForeColor = Color.Red;
                        else
                            lblPaymentDueDate.ForeColor = Color.Green;
                    }
                    if ((Convert.ToDouble(od.PendingPayment) <= 0) && (Convert.ToDouble(od.TotalPayment) <= 0))
                    {
                        lblPendingPayment.Text = "";
                        if (Convert.ToDateTime(od.PaymentDueDate) < DateTime.Now)
                            lblPaymentDueDate.ForeColor = Color.Red;
                        else
                            lblPaymentDueDate.ForeColor = Color.Green;
                    }
                    //lblPendingPayment.Text = "Pndpay " + CuySum + " " + od.PendingPayment + " (Rece " + CuySum + " " + od.TotalPayment  + ") ";

                }
            }
            //}
            //}
            //else
            //{
            //    if (od.ParentOrder.WorkflowInstanceDetail.StatusModeSequence > 30)
            //    {
            //        lblPackingName.Text = "Upload Packing List";
            //        hypPackingName.Visible = true;
            //        hypPackingName.Attributes.Add("onclick", "javascript:return ShowPackingList('PACKING', " + od.OrderID + ", " + od.OrderDetailID + ");");
            //    }
            //}
            //--------------------------Set Permission of Shipping Module By surendra--------
            //if (od.PackingListWrite == true || od.PackingListRead == true)
            //    lblPackingName.Visible = true;
            //else
            //    lblPackingName.Visible = false;

            //if (od.PackingListImageWrite == true || od.PackingListImageRead == true)
            //    viewolay1.Visible = true;
            //else
            //    viewolay1.Visible = false;

            //if (od.ShipmentNoWrite == true || od.ShipmentNoRead == true)
            //{
            //    lblConsolidated.Visible = true;
            //}
            //else
            //{
            //    lblConsolidated.Visible = false;
            //}
            //if (od.InvoiceWrite == true || od.InvoiceRead == true)
            //{
            //    lblInvoice.Visible = true;
            //}
            //else
            //{
            //    lblInvoice.Visible = false;
            //}
            //if (od.BankRefrenceNoWrite == true || od.BankRefrenceNoWrite == true)
            //{
            //    lblBankRefNo.Visible = true;
            //}
            //else
            //{
            //    lblBankRefNo.Visible = false;
            //}
            //if (od.InvoiceImageWrite == true || od.InvoiceImageRead == true)
            //    viewInvoice.Visible = true;
            //else
            //    viewInvoice.Visible = false;


            //-------------------------------------End----------------------------------------


            // Update By ravi kumar on 3/2/2015
            string shipRemark = od.SanjeevRemarks.ToString().ToLower();
            if (shipRemark != "")
            {
                hdnShipping.Value = shipRemark;
                string shippingRemark;
                shippingRemark = Constants.GetLastComments(shipRemark.ToString(), "~", "....", 100);

                if (shippingRemark.Trim() == "")
                {

                    shippingRemark = Constants.GetComment(shipRemark.ToString(), "~", "....", 100);
                }

                cultureInfo = Thread.CurrentThread.CurrentCulture;
                textInfo = cultureInfo.TextInfo;
                shippingRemark = textInfo.ToTitleCase(shippingRemark);
                string[] shRemark = shippingRemark.Split('(');
                string sOnlyRemark = shRemark[1].ToString();
                string[] sOnlyRemarkArr = sOnlyRemark.Split(')');
                string sRemarkDate = sOnlyRemarkArr[0].ToString();
                string sLatestRemarkFull = sOnlyRemarkArr[0].ToString();

                string sLatestRemark = "";
                if (sLatestRemarkFull.Length >= 30)
                {
                    sLatestRemark = sLatestRemarkFull.Substring(0, 30);
                }
                else
                {
                    sLatestRemark = sLatestRemarkFull;
                }
                lblshippingRemarks.Text = sRemarkDate + sLatestRemark;

                sLatestRemarkFull = sRemarkDate + sLatestRemarkFull;
                lblshippingRemarks.ToolTip = sLatestRemarkFull;

            }
            if (lnkShipping != null)
            {
                string ShippingRemark = hdnShipping.Value.Replace(" ", "!<@#");

                lnkShipping.Attributes.Add("onclick", "javascript:showMoSanjeevInfo('" + od.ExFactory + "','" + od.ParentOrder.Style.StyleID + "','" + od.OrderDetailID + "','" + od.ParentOrder.Style.StyleNumber + "', '" + OutHouseOrderDetailIds + "')");
                if (od.bBasicInfoRemarkwrite == true || od.bBasicInfoRemarkRead == true)
                {
                    lnkShipping.Visible = true;
                    lblshippingRemarks.Visible = true;
                }
                else
                {
                    lnkShipping.Visible = false;
                    lblshippingRemarks.Visible = false;
                }
            }
            // End Update By ravi kumar on 3/2/2015

            HiddenField hdnFab1 = e.Row.FindControl("hdnFab1") as HiddenField;
            HiddenField hdnFab2 = e.Row.FindControl("hdnFab2") as HiddenField;
            HiddenField hdnFab3 = e.Row.FindControl("hdnFab3") as HiddenField;
            HiddenField hdnFab4 = e.Row.FindControl("hdnFab4") as HiddenField;

            HiddenField hdnOrderDetailsID = e.Row.FindControl("hdnOrderDetailsID") as HiddenField;
            Label lblFabric1OrderAverage = e.Row.FindControl("lblFabric1OrderAverage") as Label;
            Label lblFabric1STCAverage = e.Row.FindControl("lblFabric1STCAverage") as Label;
            Label lblFinalOrderFabric1 = e.Row.FindControl("lblFinalOrderFabric1") as Label;

            HiddenField hdnFinalFabric_ToolTip = e.Row.FindControl("hdnFinalFabric_ToolTip") as HiddenField;
            HiddenField hdnFina2Fabric_ToolTip = e.Row.FindControl("hdnFina2Fabric_ToolTip") as HiddenField;
            HiddenField hdnFina3Fabric_ToolTip = e.Row.FindControl("hdnFina3Fabric_ToolTip") as HiddenField;
            HiddenField hdnFina4Fabric_ToolTip = e.Row.FindControl("hdnFina4Fabric_ToolTip") as HiddenField;




            TextBox lblQuantityAvl1 = e.Row.FindControl("lblQuantityAvl1") as TextBox;

            lblQuantityAvl1.Text = lblQuantityAvl1.Text == "0k" ? "" : lblQuantityAvl1.Text;



            Label lblPercent1 = e.Row.FindControl("lblPercent1") as Label;
            //HtmlAnchor lnkPeekCapacity = e.Row.FindControl("lnkPeekCapacity") as HtmlAnchor;
            //lnkPeekCapacity.Attributes.Add("onclick", "javascript:FileUpload('" + od.OrderDetailID + "')");           

            //OrderController objContoller = new OrderController();
            //DataTable dtfile = new DataTable();
            //dtfile = objContoller.GetPeekCapacityFile(Convert.ToInt32(od.OrderDetailID));
            //string StrFileName = "";
            //if (dtfile.Rows.Count > 0)
            //{
            //    StrFileName = dtfile.Rows[0]["PeekCapacityFile"].ToString();
            //}

            TextBox lblSummary1 = e.Row.FindControl("lblSummary1") as TextBox;
            TextBox lblSummary2 = e.Row.FindControl("lblSummary2") as TextBox;
            TextBox lblSummary3 = e.Row.FindControl("lblSummary3") as TextBox;
            TextBox lblSummary4 = e.Row.FindControl("lblSummary4") as TextBox;

            Label lblFabric2OrderAverage = e.Row.FindControl("lblFabric2OrderAverage") as Label;
            Label lblFabric2STCAverage = e.Row.FindControl("lblFabric2STCAverage") as Label;
            Label lblFinalOrderFabric2 = e.Row.FindControl("lblFinalOrderFabric2") as Label;
            TextBox lblQuantityAvl2 = e.Row.FindControl("lblQuantityAvl2") as TextBox;


            lblQuantityAvl2.Text = lblQuantityAvl2.Text == "0k" ? "" : lblQuantityAvl2.Text;
            Label lblPercent2 = e.Row.FindControl("lblPercent2") as Label;

            //Label lblFabric3Details = e.Row.FindControl("lblFabric3Details") as Label;
            Label lblFabric3OrderAverage = e.Row.FindControl("lblFabric3OrderAverage") as Label;
            Label lblFabric3STCAverage = e.Row.FindControl("lblFabric3STCAverage") as Label;
            Label lblFinalOrderFabric3 = e.Row.FindControl("lblFinalOrderFabric3") as Label;
            TextBox lblQuantityAvl3 = e.Row.FindControl("lblQuantityAvl3") as TextBox;

            lblQuantityAvl3.Text = lblQuantityAvl3.Text == "0k" ? "" : lblQuantityAvl3.Text;
            Label lblPercent3 = e.Row.FindControl("lblPercent3") as Label;

            //Label lblFabric4Details = e.Row.FindControl("lblFabric4Details") as Label;
            Label lblFabric4OrderAverage = e.Row.FindControl("lblFabric4OrderAverage") as Label;
            Label lblFabric4STCAverage = e.Row.FindControl("lblFabric4STCAverage") as Label;
            Label lblFinalOrderFabric4 = e.Row.FindControl("lblFinalOrderFabric4") as Label;
            TextBox lblQuantityAvl4 = e.Row.FindControl("lblQuantityAvl4") as TextBox;
            lblQuantityAvl4.Text = lblQuantityAvl4.Text == "0k" ? "" : lblQuantityAvl4.Text;

            Label lblPercent4 = e.Row.FindControl("lblPercent4") as Label;

            HtmlGenericControl spanfab1pending = e.Row.FindControl("spanfab1pending") as HtmlGenericControl;
            HtmlGenericControl Spanfab2pending = e.Row.FindControl("Spanfab2pending") as HtmlGenericControl;
            HtmlGenericControl Spanfab3pending = e.Row.FindControl("Spanfab3pending") as HtmlGenericControl;
            HtmlGenericControl Spanfab4pending = e.Row.FindControl("Spanfab4pending") as HtmlGenericControl;


            TextBox lblfab1pending = e.Row.FindControl("lblfab1pending") as TextBox;
            TextBox lblfab2pending = e.Row.FindControl("lblfab2pending") as TextBox;
            TextBox fab3pending = e.Row.FindControl("fab3pending") as TextBox;
            TextBox lblfab4pending = e.Row.FindControl("lblfab4pending") as TextBox;

            // Add by ravi kumar on 10/2/15 for fabric color change

            TextBox txtFab1StartEta = e.Row.FindControl("txtFab1StartEta") as TextBox;
            TextBox txtFab2StartEta = e.Row.FindControl("lblFab2StartEta") as TextBox;
            TextBox txtFab3StartEta = e.Row.FindControl("lblFab3StartEta") as TextBox;
            TextBox txtFab4StartEta = e.Row.FindControl("lblFab4StartEta") as TextBox;

            TextBox txtFab1EndEta = e.Row.FindControl("txtFab1EndEta") as TextBox;
            TextBox txtFab2EndEta = e.Row.FindControl("lblFab2EndEta") as TextBox;
            TextBox txtFab3EndEta = e.Row.FindControl("lblFab3EndEta") as TextBox;
            TextBox txtFab4EndEta = e.Row.FindControl("lblFab4EndEta") as TextBox;


            //HtmlGenericControl dvBIHFabric = e.Row.FindControl("dvBIHFabric") as HtmlGenericControl;//FBIHDateRead
            //HtmlTableCell tdBIHFabric = e.Row.FindControl("tdBIHFabric") as HtmlTableCell;

            Label LabelBIHname = e.Row.FindControl("LabelBIHname") as Label;
            Label lblBulkInhouseTgt = e.Row.FindControl("lblBulkInhouseTgt") as Label;

            HtmlGenericControl dvBIHAccessories = e.Row.FindControl("dvBIHAccessories") as HtmlGenericControl;// FBIHDateRead
            //HtmlTableCell tdBIHAccessories = e.Row.FindControl("tdBIHAccessories") as HtmlTableCell;
            Label LabelAccBIHname = e.Row.FindControl("LabelAccBIHname") as Label;
            Label lblACCBulkInhouseTgt = e.Row.FindControl("lblACCBulkInhouseTgt") as Label;

            // End Add by ravi kumar on 10/2/15 for fabric color change

            Label lblShippedCaption = e.Row.FindControl("lblShippedCaption") as Label;


            Label lblShipped = e.Row.FindControl("lblShipped") as Label;
            //Gajendra 24-12-2015 TextBox txtISShippedDate = e.Row.FindControl("txtISShippedDate") as TextBox;


            Repeater RepProduction = e.Row.FindControl("repProduction") as Repeater;
            if (od.Production != null)
            {
                if (od.Production.Count > 0)
                {
                    //abhishek
                    count_production = od.Production.Count;
                    IsOuthouse_CutIssue = false;
                    for (int i = 0; i < count_production; i++)
                    {
                        if (od.Production[i].UnitId == 3 && od.Production[i].UnitId == 11 && od.Production[i].UnitId == 96 && od.Production[i].UnitId == 120)
                        {
                            IsOuthouse_CutIssue = false;

                        }
                        else
                        {
                            IsOuthouse_CutIssue = true;
                            break;

                        }
                    }
                    //end by abhishek
                    IsShipped = od.IsShiped;
                    IsOnHold = od.ContractStatus; //updated code by bharat 19-feb
                    IsVAcomplete = od.IsVaCompleted;
                    IsReScan = od.IsReScan;
                    if (Convert.ToInt32(IsReScan) == 1)
                    {
                        lblanchoeDetail_Rescan.Text = "Detail/ Rescan";
                    }
                    else
                    {
                        lblanchoeDetail_Rescan.Text = "Detail";
                    }
                    RepProduction.DataSource = od.Production;
                    RepProduction.DataBind();

                    HiddenField hdnCutReadyTotalAll = e.Row.FindControl("hdnCutReadyTotalAll") as HiddenField;
                    hdnCutReadyTotalAll.Value = TotalCutReadyAll.ToString();
                    HiddenField hdnStitchTotalAll = e.Row.FindControl("hdnStitchTotalAll") as HiddenField;
                    hdnStitchTotalAll.Value = TotalStitchedAll.ToString();

                    TotalCutReadyAll = 0;
                    TotalStitchedAll = 0;
                }
            }
           

            if (od.IsShiped == true)
            {
                lblSummary1.Attributes.Add("color", od.SummryColor);
                lblSummary2.Attributes.Add("color", od.SummryColor);
                lblSummary3.Attributes.Add("color", od.SummryColor);
                lblSummary4.Attributes.Add("color", od.SummryColor);
                lblFabric1Details.Attributes.Add("style", "color:gray");//updated by bhrat on 25-feb

                string ShippedDate = "";
                string ShortExtra = "";
                if (od.IsShipedDate != DateTime.MinValue)
                {
                    ShippedDate = od.IsShipedDate.ToString("dd MMM");
                }

                double dQuantity = od.Quantity;
                int ShippedQty = od.ShippedQty;

                if (dQuantity > Convert.ToDouble(ShippedQty))
                {
                    ShortExtra = "short";
                }
                else
                {
                    ShortExtra = "extra";
                }

                double ShortShipped = dQuantity - Convert.ToDouble(ShippedQty);
                double ShortShippedPercent = (ShortShipped * 100) / dQuantity;
                ShortShippedPercent = Math.Round(ShortShippedPercent, 2);

                // edit by surendra for ctpl
                var totalQtyForCTSL = od.TotalcutQtyforCTSL;
                double ctplqty = Convert.ToDouble(totalQtyForCTSL) - Convert.ToDouble(ShippedQty);
                double ctplPercentage = (ctplqty * 100) / Convert.ToDouble(totalQtyForCTSL);
                ctplPercentage = Math.Round(ctplPercentage, 2);
                //int CtplPercentage = (((Convert.ToInt32(od.OverallCut) - ShippedQty) / Convert.ToInt32(od.OverallCut)) * 100);
                // end
                string ShippedCaption = "";
                if (ctplPercentage == 0.0)
                {
                    if (ShortShippedPercent > 0.0)
                    {
                        ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + ") On " + ShippedDate;// ShippedQty + "Pcs shipped (" + ShortShippedPercent + " %) On " + ShippedDate + "";
                    }
                    else
                    {

                        ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + ") On " + ShippedDate;// ShippedQty + "Pcs shipped (" + ShortShippedPercent + " %) On " + ShippedDate + "";
                    }
                }
                else
                {
                    if (ctplPercentage > 0.0)
                    {
                        if (ShortShippedPercent > 0.0)
                        {
                            if (od.TotalPenalty == 0.0)
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
                            else
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";

                        }
                        else
                        {
                            if (od.TotalPenalty == 0.0)
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
                            else
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";
                        }

                    }
                    else
                    {
                        if (ShortShippedPercent > 0.0)
                        {
                            if (od.TotalPenalty == 0.0)
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
                            else
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";
                        }
                        else
                        {
                            if (od.TotalPenalty == 0.0)
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
                            else
                                ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";

                        }

                    }
                }
                if (IsShipped == false)
                    lblShippedCaption.Text = ShippedCaption;
                else
                    lblShippedCaption.Text = ShippedCaption.Replace("blue;", "black;").Replace("red;", "black;").Replace("green;", "black;");

                //Gajendra 24-12-2015  txtISShippedDate.Text = "";
                lblShipped.Text = "";
            }
            else
            {
                lblShipped.Text = "Waiting to be shipped";
                lblShippedCaption.Text = "";
                if (od.Caption1 == "Black")
                {
                    lblSummary1.CssClass = "summaryColor1";
                }
                if (od.Caption1 == "Red")
                {
                    lblSummary1.CssClass = "summaryColor2";
                }
                if (od.Caption1 == "Green")
                {
                    lblSummary1.CssClass = "summaryColor3";
                }
                if (od.Caption2 == "Black")
                {
                    lblSummary2.CssClass = "summaryColor1";
                }
                if (od.Caption2 == "Red")
                {
                    lblSummary2.CssClass = "summaryColor2";
                }
                if (od.Caption2 == "Green")
                {
                    lblSummary2.CssClass = "summaryColor3";
                }
                if (od.Caption3 == "Black")
                {
                    lblSummary3.CssClass = "summaryColor1";
                }
                if (od.Caption3 == "Red")
                {
                    lblSummary3.CssClass = "summaryColor2";
                }
                if (od.Caption3 == "Green")
                {
                    lblSummary3.CssClass = "summaryColor3";
                }
                if (od.Caption4 == "Black")
                {
                    lblSummary4.CssClass = "summaryColor1";
                }
                if (od.Caption4 == "Red")
                {
                    lblSummary4.CssClass = "summaryColor2";
                }
                if (od.Caption4 == "Green")
                {
                    lblSummary4.CssClass = "summaryColor3";
                }
            }
            DateTime BIHDate = od.BulkTarget;
            ViewState["BIHDate"] = BIHDate;
            BIHDate = Convert.ToDateTime(ViewState["BIHDate"].ToString());

            // Add by ravi kumar on 10/2/15 for fabric color change
            //int BIH_ColorGreen = 0;
            //int BIH_ColorWhite = 0;
            //int BIH_ColorRed = 0;

            //addde by abhishek on 19/8/2016

            Label Labelsamcap = e.Row.FindControl("Labelsamcap") as Label;
            Label Label15 = e.Row.FindControl("Label15") as Label;
            //Label lblICtext = (Label)e.Row.FindControl("lblICtext");
            //Label lblICDate = (Label)e.Row.FindControl("lblICDate");
            //CheckBox chkforIC = (CheckBox)e.Row.FindControl("chkforIC");

            //if (od.IsCheck == true)
            //{
            //    if (od.IsICCheckOnDate != "")
            //    {
            //        lblICDate.Text = "on" + " " + Convert.ToDateTime(od.IsICCheckOnDate).ToString("dd MMM");
            //    }


            //    //chkforIC.Enabled = false;
            //}
            if (od.IsShiped == true)
            {
                //chkforIC.Style.Add("background-color", "#F9F9FA");
                //chkforIC.Style.Add("color", "#807F80");

                //lblICtext.Style.Add("background-color", "#F9F9FA");
                //lblICtext.Style.Add("color", "#807F80");

                //lblICDate.Style.Add("background-color", "#F9F9FA");
                //lblICDate.Style.Add("color", "#807F80");

                //LblPeekCapacity.Style.Add("background-color", "#F9F9FA");
                //LblPeekCapacity.Style.Add("color", "#807F80");

                Labelsamcap.Style.Add("background-color", "#F9F9FA");
                Labelsamcap.Style.Add("color", "#807F80");


                Label15.Style.Add("background-color", "#F9F9FA");
                Label15.Style.Add("color", "#807F80");
                //fabric color

                fabric1name.Style.Add("background-color", "#F9F9FA");
                fabric1name.Style.Add("color", "#807F80");

                fabric2name.Style.Add("background-color", "#F9F9FA");
                fabric2name.Style.Add("color", "#807F80");

                fabric3name.Style.Add("background-color", "#F9F9FA");
                fabric3name.Style.Add("color", "#807F80");

                fabric4name.Style.Add("background-color", "#F9F9FA");
                fabric4name.Style.Add("color", "#807F80");




            }
            //end-

            #region Commented because "BIH_ColorGreen" value never used
            //if (lblPercent1.Visible != false)
            //{
            //    // Add By Ravi kumar on 6/2/2015
            //    if (BIHDate.Date >= System.DateTime.Now.Date)
            //    {
            //        if (txtFab1EndEta.Text != "")
            //        {
            //            if (lblPercent1.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent1.Text) >= 100)
            //                {
            //                    BIH_ColorGreen = 1;
            //                }
            //                else
            //                {
            //                    BIH_ColorWhite = 1;
            //                }
            //            }
            //            else
            //            {
            //                BIH_ColorWhite = 1;
            //            }
            //        }
            //        else
            //        {
            //            BIH_ColorWhite = 1;

            //        }

            //    }
            //    if (BIHDate.Date < System.DateTime.Now.Date)
            //    {
            //        if (txtFab1EndEta.Text != "")
            //        {
            //            if (BIHDate.Date < Convert.ToDateTime(od.Fabric1ENDETA).Date)
            //            {
            //                BIH_ColorRed = 1;
            //            }
            //            if (lblPercent1.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent1.Text) >= 100)
            //                {
            //                    if (BIHDate.Date >= Convert.ToDateTime(od.Fabric1ENDETA).Date)
            //                    {
            //                        BIH_ColorGreen = 1;
            //                    }
            //                }
            //                else
            //                {
            //                    BIH_ColorRed = 1;
            //                }

            //            }
            //            else
            //            {
            //                BIH_ColorRed = 1;
            //            }
            //        }
            //        else
            //        {
            //            BIH_ColorRed = 1;

            //        }

            //    }
            //    // End Add By Ravi kumar on 6/2/2015
            //}
            

            //if (lblPercent2.Visible != false)
            //{
            //    // Add By Ravi kumar on 6/2/2015
            //    if (BIHDate.Date >= System.DateTime.Now.Date)
            //    {
            //        if (txtFab2EndEta.Text != "")
            //        {
            //            if (lblPercent2.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent2.Text) >= 100)
            //                {
            //                    BIH_ColorGreen = 1;
            //                }
            //                else
            //                {
            //                    BIH_ColorWhite = 1;
            //                }

            //            }
            //            else
            //            {
            //                BIH_ColorWhite = 1;
            //            }

            //        }
            //        else
            //        {
            //            BIH_ColorWhite = 1;

            //        }
            //    }
            //    if (BIHDate.Date < System.DateTime.Now.Date)
            //    {
            //        if (txtFab2EndEta.Text != "")
            //        {
            //            if (BIHDate.Date < Convert.ToDateTime(od.Fabric2ENDETA).Date)
            //            {
            //                BIH_ColorRed = 1;
            //            }

            //            if (lblPercent2.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent2.Text) >= 100)
            //                {
            //                    if (BIHDate.Date >= Convert.ToDateTime(od.Fabric2ENDETA).Date)
            //                    {
            //                        BIH_ColorGreen = 1;
            //                    }
            //                }
            //                else
            //                {
            //                    BIH_ColorRed = 1;
            //                }
            //            }
            //            else
            //            {
            //                BIH_ColorRed = 1;
            //            }

            //        }
            //        else
            //        {
            //            BIH_ColorRed = 1;
            //        }

            //    }
            //    // End Add By Ravi kumar on 6/2/2015

            //}

            //if (lblPercent3.Visible != false)
            //{

            //    // Add By Ravi kumar on 6/2/2015
            //    if (BIHDate.Date >= System.DateTime.Now.Date)
            //    {
            //        if (txtFab3EndEta.Text != "")
            //        {
            //            if (lblPercent3.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent3.Text) >= 100)
            //                {
            //                    BIH_ColorGreen = 1;
            //                }
            //                else
            //                {
            //                    BIH_ColorWhite = 1;
            //                }

            //            }
            //            else
            //            {
            //                BIH_ColorWhite = 1;
            //            }
            //        }
            //        else
            //        {
            //            BIH_ColorWhite = 1;
            //        }

            //    }
            //    if (BIHDate.Date < System.DateTime.Now.Date)
            //    {
            //        if (txtFab3EndEta.Text != "")
            //        {
            //            if (BIHDate.Date < Convert.ToDateTime(od.Fabric3ENDETA).Date)
            //            {
            //                BIH_ColorRed = 1;
            //            }
            //            if (lblPercent3.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent3.Text) >= 100)
            //                {
            //                    if (BIHDate.Date >= Convert.ToDateTime(od.Fabric3ENDETA).Date)
            //                    {
            //                        BIH_ColorGreen = 1;
            //                    }
            //                }
            //                else
            //                {
            //                    BIH_ColorRed = 1;
            //                }
            //            }
            //            else
            //            {
            //                BIH_ColorRed = 1;
            //            }
            //        }
            //        else
            //        {
            //            BIH_ColorRed = 1;

            //        }
            //    }
            //    // End Add By Ravi kumar on 6/2/2015
            //}
            //if (lblPercent4.Visible != false)
            //{

            //    // Add By Ravi kumar on 6/2/2015
            //    if (BIHDate.Date >= System.DateTime.Now.Date)
            //    {
            //        if (txtFab4EndEta.Text != "")
            //        {
            //            if (lblPercent4.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent4.Text) >= 100)
            //                {
            //                    BIH_ColorGreen = 1;
            //                }
            //                else
            //                {
            //                    BIH_ColorWhite = 1;
            //                }
            //            }
            //            else
            //            {
            //                BIH_ColorWhite = 1;
            //            }

            //        }
            //        else
            //        {
            //            BIH_ColorWhite = 1;

            //        }

            //    }
            //    if (BIHDate.Date < System.DateTime.Now.Date)
            //    {
            //        if (txtFab4EndEta.Text != "")
            //        {
            //            if (BIHDate.Date < Convert.ToDateTime(od.Fabric4ENDETA).Date)
            //            {
            //                BIH_ColorRed = 1;
            //            }
            //            if (lblPercent4.Text != "")
            //            {
            //                if (Convert.ToInt32(lblPercent4.Text) >= 100)
            //                {
            //                    if (BIHDate.Date >= Convert.ToDateTime(od.Fabric4ENDETA).Date)
            //                    {
            //                        BIH_ColorGreen = 1;
            //                    }
            //                }
            //                else
            //                {
            //                    BIH_ColorRed = 1;
            //                }


            //            }
            //            else
            //            {
            //                BIH_ColorRed = 1;
            //            }

            //        }
            //        else
            //        {
            //            BIH_ColorRed = 1;

            //        }

            //    }
            //    // End Add By Ravi kumar on 6/2/2015
            //}

            #endregion


            if (hdnFab1 != null)
            {
                if (hdnFab1.Value == "")
                {
                    lblFabric1Details.Text = "";
                    lblFabric1OrderAverage.Text = "";
                    lblFabric1STCAverage.Text = "";
                    lblFinalOrderFabric1.Text = "";
                    lblQuantityAvl1.Text = "";
                    lblFabric1STCAverage.Visible = false;
                    lblSummary1.Visible = false;
                    //lblPercent1.Text = "";
                }
                else
                {
                    lblPercent1.Text = '(' + lblPercent1.Text + '%' + ')';
                }
            }

            if (hdnFab2 != null)
            {
                if (hdnFab2.Value == "")
                {
                    lblFabric2Details.Text = "";
                    lblFabric2OrderAverage.Text = "";
                    lblFabric2STCAverage.Text = "";
                    lblFinalOrderFabric2.Text = "";
                    lblQuantityAvl2.Text = "";
                    lblPercent2.Text = "";
                    lblFabric2STCAverage.Visible = false;
                    lblSummary2.Visible = false;
                }
                else
                {
                    lblPercent2.Text = '(' + lblPercent2.Text + '%' + ')';
                }
            }
            if (hdnFab3 != null)
            {
                if (hdnFab3.Value == "")
                {
                    lblFabric3Details.Text = "";
                    lblFabric3OrderAverage.Text = "";
                    lblFabric3STCAverage.Text = "";
                    lblFinalOrderFabric3.Text = "";
                    lblQuantityAvl3.Text = "";
                    lblPercent3.Text = "";
                    lblFabric3STCAverage.Visible = false;
                    lblSummary3.Visible = false;
                }
                else
                {
                    lblPercent3.Text = '(' + lblPercent3.Text + '%' + ')';
                }
            }
            if (hdnFab4 != null)
            {
                if (hdnFab4.Value == "")
                {
                    lblFabric4Details.Text = "";
                    lblFabric4OrderAverage.Text = "";
                    lblFabric4STCAverage.Text = "";
                    lblFinalOrderFabric4.Text = "";
                    lblQuantityAvl4.Text = "";
                    lblPercent4.Text = "";
                    lblFabric4STCAverage.Visible = false;
                    lblSummary4.Visible = false;
                }
                else
                {
                    lblPercent4.Text = '(' + lblPercent4.Text + '%' + ')';
                }
            }

            
            //Label lblExpectedDC = e.Row.FindControl("lblExpectedDC") as Label;
            (lblQuantity.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetQuantitySizeFilledColor(od.IsSizeFilledUp, od.IsCuttingFormSaved));

            if (lblQuantity != null)
            {
                string strQuantity = lblQuantity.Text;
                hdnQuantity.Value = strQuantity;
            }
            //if (od.ExpectedDC > od.DC)
            //{
            //    string ExpectedDC = od.ExpectedDC == DateTime.MinValue ? "" : od.ExpectedDC.ToString("dd MMM");
            //    if (ExpectedDC != "")
            //    {
            //        if ((od.ParentOrder.Style.client.ClientID == 2) && (od.Mode == 3) && ((od.OrderType == 1) || (od.OrderType == 4)))
            //        {
            //            lblExpectedDC.Text = "Exptd. DC : " + ExpectedDC;
            //        }
            //    }
            //}
            //Added By Ravi kumar on 19-3-18 for Planned Date
            Label lblPlanedForDate = e.Row.FindControl("lblPlanedForDate") as Label;
            TextBox txtPlannedForDate = e.Row.FindControl("txtPlannedForDate") as TextBox;
            HiddenField hdnPlanforDate = e.Row.FindControl("hdnPlanforDate") as HiddenField;

            DropDownList ddlMode = e.Row.FindControl("ddlMode") as DropDownList;
            DropDownList ddlUnPlanned = e.Row.FindControl("ddlUnPlanned") as DropDownList;

            int IsUnPlanned = od.IsUnPlanned;
            if ((od.PlanType > 0) && (od.PlanType <= 2))
            {
                if (od.PlanDate != DateTime.MinValue)
                {
                    if (od.bPlanedForDate == true)
                        lblPlanedForDate.Visible = true;
                    else
                        lblPlanedForDate.Visible = false;
                    if (od.bPlanedInputDate == true)
                        txtPlannedForDate.Visible = true;
                    else
                        txtPlannedForDate.Visible = false;
                    lblPlanedForDate.Text = "Planned For";
                    txtPlannedForDate.Text = od.PlanDate == DateTime.MinValue ? "" : od.PlanDate.ToString("dd MMM yy (ddd)");
                    hdnPlanforDate.Value = od.PlanDate == DateTime.MinValue ? "" : od.PlanDate.ToString("dd MMM yy (ddd)");
                }

                if ((od.PlanType > 0) && (od.PlanType <= 2))
                {
                    ddlMode.SelectedValue = od.PlanType.ToString();
                    if (od.bPlanedDropDown == true)
                        ddlMode.Visible = true;
                    else
                        ddlMode.Visible = false;
                    ddlUnPlanned.Visible = false;
                    if (od.PlanType == 1)
                    {
                        txtPlannedForDate.Style.Add("pointer-events", "none");
                    }
                }
            }
            else
            {
                if ((od.PlanType >= 3) && (od.PlanType <= 4))
                {
                    //if (od.bPlanedDropDown == true)
                    //    ddlMode.Visible = true;
                    //else
                    //    ddlMode.Visible = false;
                    ddlMode.Visible = false;
                    ddlUnPlanned.Visible = true;
                    ddlUnPlanned.SelectedValue = od.PlanType.ToString();
                    ddlUnPlanned.Enabled = false;
                    lblPlanedForDate.Visible = false;
                    txtPlannedForDate.Visible = false;
                }
            }
            if (od.bPlanedInputDate_Permission == true)
                txtPlannedForDate.Attributes.Add("class", "th do-not-allow-typing");
            else
                txtPlannedForDate.Attributes.Add("readonly", "readonly");

            //End By Ravi kumar on 19-3-18 for Planned Date

            Repeater repaccess = e.Row.FindControl("repAccess") as Repeater;

            if (od.Accessories.Count > 0)
            {
                //Repeater repaccess = e.Row.FindControl("repAccess") as Repeater;
                repaccess.DataSource = od.Accessories;
                repaccess.DataBind();
            }
            else
            {
                Access_ColorWhite = 1;
            }



            // Add by ravi kumar on 10/2/15 for color change
            if (Access_ColorRed == 1)
            {
                //Added By Ashish on 23/3/2015
                if (od.FBIHDateRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        dvBIHAccessories.Style.Add("background-color", "#F9F9FA");
                        LabelAccBIHname.Style.Add("color", "#807F80");
                        lblACCBulkInhouseTgt.Style.Add("color", "#807F80");
                    }
                    else
                    {
                        dvBIHAccessories.Style.Add("background-color", "#FF3300");
                        LabelAccBIHname.Style.Add("color", "#FDFD96");
                        lblACCBulkInhouseTgt.Style.Add("color", "#FDFD96");
                    }
                }
                else
                {
                    dvBIHAccessories.Style.Add("background-color", "#FFFFFF");

                }

            }
            else if (Access_ColorWhite == 1)
            {
                if (od.FBIHDateRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        dvBIHAccessories.Style.Add("background-color", "#F9F9FA");
                        LabelAccBIHname.Style.Add("color", "#807F80");
                        lblACCBulkInhouseTgt.Style.Add("color", "#807F80");
                    }
                    else
                    {
                        dvBIHAccessories.Style.Add("background-color", "#FFFFFF");
                        LabelAccBIHname.Style.Add("color", "#000000");
                        lblACCBulkInhouseTgt.Style.Add("color", "#000000");
                    }
                }
                else
                {
                    dvBIHAccessories.Style.Add("background-color", "#FFFFFF");

                }
            }
            else
            {
                if (od.FBIHDateRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        dvBIHAccessories.Style.Add("background-color", "#F9F9FA");
                        LabelAccBIHname.Style.Add("color", "#807F80");
                        lblACCBulkInhouseTgt.Style.Add("color", "#807F80");
                    }
                    else
                    {
                        dvBIHAccessories.Style.Add("background-color", "#00FF70");
                        LabelAccBIHname.Style.Add("color", "#000000");
                        lblACCBulkInhouseTgt.Style.Add("color", "#000000");
                    }
                }
                else
                {
                    dvBIHAccessories.Style.Add("background-color", "#FFFFFF");
                    LabelAccBIHname.Style.Add("color", "#000000");
                    lblACCBulkInhouseTgt.Style.Add("color", "#000000");
                }
            }

            Access_ColorRed = 0;
            Access_ColorWhite = 0;
            Access_ColorGreen = 0;

            // End Add by ravi kumar on 10/2/15 for color change



            HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
            (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(od.ExFactory));




            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode));

            HtmlAnchor hypstatusmode = e.Row.FindControl("hypstatusmode") as HtmlAnchor;
            (hypstatusmode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID));


            HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;

            Label lblFitsDate = e.Row.FindControl("lblFitsDate") as Label;

            Label lblActualProfitMargin = e.Row.FindControl("lblActualProfitMargin") as Label;

            if (!string.IsNullOrEmpty(lblActualProfitMargin.Text))
            {
              if (Convert.ToDecimal(lblActualProfitMargin.Text.Replace("%", "")) < 0)
              {
                lblActualProfitMargin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
              
              }
              if (od.AgreedPrice > 0)
              {
                lblActualProfitMargin.ToolTip = "Percentage Profit (Agreed Price " + od.AgreedPrice + ")";
              }
              else
              {
                lblActualProfitMargin.ToolTip = "Percentage Profit (Agreed Price missing)";
              }
            }
            if (od.IsShiped == true)
            {
              lblPriceSymbol.ForeColor = System.Drawing.ColorTranslator.FromHtml("#807F80");
              lblikandiGross.ForeColor = System.Drawing.ColorTranslator.FromHtml("#807F80");
              lblActualProfitMargin.ForeColor = System.Drawing.ColorTranslator.FromHtml("#807F80");
              //StrForColorCode = "#FFFF66";
            }
            else
            {
                if (lblActualProfitMargin.Text != "")
                {
                    if (Convert.ToDecimal(lblActualProfitMargin.Text.Replace("%", "")) < 0)
                    {
                        lblActualProfitMargin.Attributes.Add("style", "color:#FF0000; !impoartant");
                    }
                }
              lblPriceSymbol.Attributes.Add("style", "color:#008000; !impoartant");
              lblikandiGross.Attributes.Add("style", "color:#008000; !impoartant");
            }
            //-----------Added By Prabhaker 02-april-18-----------------//
            HiddenField hdnModeId = (HiddenField)e.Row.FindControl("hdnModeId");
            HiddenField hdnddlForecolor = (HiddenField)e.Row.FindControl("hdnddlForecolor");
            HiddenField hdnddlBackcolor = (HiddenField)e.Row.FindControl("hdnddlBackcolor");

            DropDownList ddlModeChange = (DropDownList)e.Row.FindControl("ddlModeChange");
            DataTable dtBindMo = Bindmode.BindMoMode();
            if (dtBindMo.Rows.Count > 0)
            {
                ddlModeChange.DataSource = dtBindMo;
                ddlModeChange.DataTextField = "Code";
                ddlModeChange.DataValueField = "Id";
                ddlModeChange.DataBind();
            }
            if (hdnModeId.Value != "")
            {
                ddlModeChange.SelectedValue = hdnModeId.Value;
                ddlModeChange.Style.Add("color", hdnddlForecolor.Value);
                ddlModeChange.Style.Add("background", hdnddlBackcolor.Value);
            }

            if (od.bSharingMode_Change == true)
            {
                ddlModeChange.Enabled = true;
            }
            else
            {
                ddlModeChange.Enabled = false;
            }
            //------------End Of Code----------------------//





            string str = "";
            //for (int iFitdays = 1; iFitdays <= 5; iFitdays++)
            //{

            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Mon) > 0)
            {
                // lblMon.CssClass = "status_meeting_day_selected_style";
                if (str == "")
                {
                    str = "Mon";
                }
                else
                {
                    str = str + "," + str;
                }

            }
            //else
            //{
            //    lblMon.CssClass = "status_meeting_day__style";
            //}

            //  Label lblTue = e.Row.FindControl("lblTue") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Tue) > 0)
            {
                //  lblTue.CssClass = "status_meeting_day_selected_style";
                //str += str+"," + "Tue";
                if (str == "")
                {
                    str = "Tue";
                }
                else
                {
                    str = str + "," + "Tue";
                }
            }
            //else
            //{
            //    lblTue.CssClass = "status_meeting_day__style";
            //}

            //    Label lblWed = e.Row.FindControl("lblWed") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Wed) > 0)
            {
                //   lblWed.CssClass = "status_meeting_day_selected_style";
                //str += str + "," + "Wed";
                if (str == "")
                {
                    str = "Wed";
                }
                else
                {
                    str = str + "," + "Wed";
                }

            }
            //else
            //{
            //    lblWed.CssClass = "status_meeting_day__style";
            //}

            //  Label lblThu = e.Row.FindControl("lblThu") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Thu) > 0)
            {
                // lblThu.CssClass = "status_meeting_day_selected_style";
                //str += str + "," + "Thu";

                if (str == "")
                {
                    str = "Thu";
                }
                else
                {
                    str = str + "," + "Thu";
                }
            }
            //else
            //{
            //    lblThu.CssClass = "status_meeting_day__style";
            //}

            //Label lblFri = e.Row.FindControl("lblFri") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Fri) > 0)
            {
                //  lblFri.CssClass = "status_meeting_day_selected_style";
                // str += str + "," + "Fri";

                if (str == "")
                {
                    str = "Fri";
                }
                else
                {
                    str = str + "," + "Fri";
                }
            }
            //else
            //{
            //    lblFri.CssClass = "status_meeting_day__style";
            //}
            //}
            if (str.Length > 7)
                lblFitsDate.Text = str.Substring(0, 7);
            else
                lblFitsDate.Text = str;
            lblFitsDate.ToolTip = str;

            //LblPeekCapacity.Attributes.Add("onclick", "javascript:FileUpload('" + od.OrderDetailID +"')");



            HyperLink hypfitstatus = new HyperLink();

            if (od.FitStatus != string.Empty)
            {
                hypfitstatus.Text = od.FitStatus;
                hypfitstatus.Target = "SealingForm";
                string stylecode = string.Empty;
                if (od.ParentOrder.Fits.StyleCodeVersion == string.Empty)
                    stylecode = Constants.GetFiveDigitStyleCodeByStyleCode(od.ParentOrder.Fits.StyleCode);
                else
                    if (od.FitsStatusRead == true && od.FitsStatusWrite == true)
                    {
                        hypfitstatus.Target = "SealingForm";
                        //stylecode = od.ParentOrder.Fits.StyleCodeVersion;
                        //hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + stylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "','" + od.ParentOrder.Style.StyleID + "','" + od.ParentOrder.Style.StyleCode + "','" + od.ParentOrder.Fits.StyleCodeVersion + "','" + od.ParentOrder.Style.client.ClientID + "')");
                        ////hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + od.ParentOrder.Style.StyleID + "','" + od.ParentOrder.Style.StyleNumber + "','" + od.ParentOrder.Fits.StyleCodeVersion + "','" + od.ParentOrder.Style.StyleCode + "','" + od.ParentOrder.ClientID + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");


                        //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                        //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                        //else
                        //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                        hypfitstatus.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");
                    }
            }

            else
            {
                hypfitstatus.Text = "Show Sealer Pending Form";
                hypfitstatus.Target = "SealingForm";

                //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                //else
                //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                hypfitstatus.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");

            }
            lblQAStatus.Visible = od.FitsQAStatusRead;
            lblQAStatus.Enabled = od.FitsQAStatusWrite;


            //Label lblQAStatus = e.Row.FindControl("lblQAStatus") as Label;
            //lblQAStatus.Text = this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0);
            //if (od.ParentOrder.WorkflowInstanceDetail.StatusModeSequence < 11)
            //{
            //    lblQAStatus.CssClass = "hide_me";
            //}
            string Planedstylecode = string.Empty;
            if (od.ParentOrder.Fits.StyleCodeVersion == string.Empty)
                Planedstylecode = Constants.GetFiveDigitStyleCodeByStyleCode(od.ParentOrder.Fits.StyleCode);
            else
                Planedstylecode = od.ParentOrder.Fits.StyleCodeVersion;

            HyperLink hypPlannedDate = new HyperLink();
            Label lblFitsStatus = e.Row.FindControl("lblFitsStatus") as Label;
            lblFitsStatus.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");
            //lblFitsStatus.Controls.Add(hypfitstatus);
            lblFitsStatus.Text = hypfitstatus.Text;

            Label lblstctgt = e.Row.FindControl("lblstctgt") as Label;
            (lblstctgt.Parent as TableCell).ForeColor = System.Drawing.ColorTranslator.FromHtml(od.FitStatusBgColor);


            Label lblPlannedDate = e.Row.FindControl("lblPlannedDate") as Label;
            Label lblBhPlannedDate = e.Row.FindControl("lblBHPlannedDate") as Label;
            if (lblPlannedDate != null)
            {
                //lblPlannedDate.Attributes.Add("class", "lblcolor");
                if (od.ParentOrder.FitsTrack.PlannedDispatchDate.Year == 1)
                {
                    lblPlannedDate.Text = "";
                    //lblPlannedDate.Visible = false;
                    //Added By Ashish on 4/3/2014
                    lblPlannedDate.Visible = false; ;
                    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;

                    //END
                }
                else
                {
                    lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.FitsTrack.PlannedDispatchDate).ToString("dd MMM (ddd)");
                    //lblPlannedDate.Visible = true;
                    //Added By Ashish on 4/3/2014
                    lblPlannedDate.Visible = false;
                    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
                    //END
                    hypPlannedDate.Text = lblPlannedDate.Text;
                    lblPlannedDate.Controls.Add(hypPlannedDate);
                    hypPlannedDate.Target = "SealingForm";
                    //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");

                    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                    //else
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");


                }
            }



            if (od.IsAllocated == true && od.BHPlannedMeeting > DateTime.MinValue && od.IsBHMeetingCompleted == 0)
            {
                lblBhPlannedDate.Text = "BH Meeting Planned On " + od.BHPlannedMeeting.ToString("dd MMM (ddd)");
                hypPlannedDate.Text = lblPlannedDate.Text;
                lblPlannedDate.Controls.Add(hypPlannedDate);
                hypPlannedDate.Target = "SealingForm";
                //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
                //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                //else
                //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");

            }

            if (od.FitStatus.Contains("Top Approved On"))
            {
                lblPlannedDate.Text = "";
            }
            else if (od.FitStatus.Contains("STC Approved"))
            {
                if (od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate != DateTime.MinValue)
                {
                    lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate).ToString("dd MMM (ddd)");
                    lblPlannedDate.Text = "TOP Planned For " + lblPlannedDate.Text;
                    hypPlannedDate.Text = lblPlannedDate.Text;
                    //lblPlannedDate.Visible = true;
                    //Added By Ashish on 4/3/2014
                    lblPlannedDate.Visible = false;
                    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
                    //END
                    lblPlannedDate.Controls.Add(hypPlannedDate);
                    hypPlannedDate.Target = "SealingForm";
                    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                    //else
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                    ////hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");

                    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");
                }
                else
                {
                    lblPlannedDate.Text = "";
                    //lblPlannedDate.Visible = false;
                    //Added By Ashish on 4/3/2014
                    lblPlannedDate.Visible = false;
                    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
                    //END
                }

            }
            else if (od.FitStatus.Contains("Top"))
            {
                if (od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate != DateTime.MinValue)
                {
                    lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate).ToString("dd MMM (ddd)");
                    lblPlannedDate.Text = "TOP Planned For " + lblPlannedDate.Text;
                    hypPlannedDate.Text = lblPlannedDate.Text;
                    //lblPlannedDate.Visible = true;
                    //Added By Ashish on 4/3/2014
                    lblPlannedDate.Visible = false;
                    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
                    //END
                    lblPlannedDate.Controls.Add(hypPlannedDate);
                    hypPlannedDate.Target = "SealingForm";
                    //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
                    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                    //else
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");

                }
                else
                {
                    lblPlannedDate.Text = "";
                    //lblPlannedDate.Visible = false;
                    //Added By Ashish on 4/3/2014
                    lblPlannedDate.Visible = false;
                    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
                    //END
                }

            }
            else if (od.FitStatus.Contains("FIT") && ((od.FitStatus.Contains("RECEIVED")) || (od.FitStatus.Contains("Received"))))
            {
                lblPlannedDate.Text = "Next Fit Planned For " + lblPlannedDate.Text;
                hypPlannedDate.Text = lblPlannedDate.Text;
                lblPlannedDate.Controls.Add(hypPlannedDate);
                hypPlannedDate.Target = "SealingForm";

                //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
                //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                //else
                //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");

            }
            else if ((od.FitStatus.ToUpper().Contains("SAMPLE") || od.FitStatus.ToUpper().Contains("SEALER")) && !od.FitStatus.ToUpper().Contains("SPEC") && lblPlannedDate.Text != "")
            {
                lblPlannedDate.Text = "Next Fit Planned For " + lblPlannedDate.Text;
                hypPlannedDate.Text = lblPlannedDate.Text;
                lblPlannedDate.Controls.Add(hypPlannedDate);
                hypPlannedDate.Target = "SealingForm";
                //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
                //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                //else
                //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");

            }
            else if (od.FitStatus == "" && hypfitstatus.Text.ToUpper().Contains("SHOW SEALER"))
            {
                if (od.ParentOrder.InlinePPMOrderContract.SpecUploadPlannedDate != DateTime.MinValue)
                {
                    lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.InlinePPMOrderContract.SpecUploadPlannedDate).ToString("dd MMM (ddd)");
                    lblPlannedDate.Text = "Spec Upload Planned For " + lblPlannedDate.Text;
                    hypPlannedDate.Text = lblPlannedDate.Text;
                    //lblPlannedDate.Visible = true;
                    //Added By Ashish on 4/3/2014
                    lblPlannedDate.Visible = false;
                    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
                    //END
                    lblPlannedDate.Controls.Add(hypPlannedDate);
                    hypPlannedDate.Target = "SealingForm";
                    //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
                    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                    //else
                    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

                    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "','" + od.PPSample_ContractStatus + "','" + od.OrderDetailID + "')");
                }
            }
            else
            {
                lblPlannedDate.Text = "";
                //lblPlannedDate.Visible = false;
                //Added By Ashish on 4/3/2014
                lblPlannedDate.Visible = false;
                lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
                //END
            }
            // cut avg not editable before STC
            //if ((od.ParentOrder.WorkflowInstanceDetail.StatusModeID < Convert.ToInt32(TaskMode.Sealed_To_Cut)))
            //{
            //    //lblFabric1STCAverage.CssClass = "do-not-allow-typing";
            //    //lblFabric2STCAverage.CssClass = "do-not-allow-typing";
            //    //lblFabric3STCAverage.CssClass = "do-not-allow-typing";
            //    //lblFabric4STCAverage.CssClass = "do-not-allow-typing";


            //}
            //else
            //{
            //----------------------------------------------Edit by surendra on 14-09-2016 for hide below section when line plan not done-------------------//
            //HtmlGenericControl divLKM = e.Row.FindControl("divLKM") as HtmlGenericControl;
            //HtmlGenericControl divLines = e.Row.FindControl("divLines") as HtmlGenericControl;
            //HtmlGenericControl divDays = e.Row.FindControl("divDays") as HtmlGenericControl;
            HtmlGenericControl divFooter = e.Row.FindControl("divFooter") as HtmlGenericControl;

            if (od.IsLinePlan == 1)
            {
                //divLKM.Visible = false;
                //divLines.Visible = false;
                //divDays.Visible = false;
                divFooter.Visible = true;
            }


            //----------------------------------------End---------------------------------------------------------------------------------------------------//
            //string imagepath = "";
            //string[] strcut;
            int StyleId = od.ParentOrder.Style.StyleID;
            string avg1 = lblFabric1OrderAverage.Text;
            string txtavg = lblFabric1STCAverage.Text;
            string Fabric1 = hdnFab1.Value;
            //lblFabric1STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'1', '" + avg1 + "', '" + StyleId + "', '" + Fabric1 + "')");
            if (od.FOrdWrite == true)
                td2p1.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'1', '" + avg1 + "', '" + StyleId + "', '" + Fabric1 + "','" + txtavg + "','" + od.ParentOrder.Style.StyleNumber + "')");
            //  OrderController objOrderController = new OrderController();
            int orderDetailID = 0;
            orderDetailID = Convert.ToInt32(hdnOrderDetailsID.Value);
            //imagepath = objOrderController.GetSketch(orderDetailID, "", 1);
            //strcut = imagepath.Split(',');
            //if (strcut[0].ToString() != "")
            //{
            //    viewolay1.NavigateUrl = "~/Uploads/Photo/" + strcut[0].ToString();
            //    viewolay1.Attributes.Add("style", "display:block;");
            //}

            string avg2 = lblFabric2OrderAverage.Text;
            string txtavg2 = lblFabric2STCAverage.Text;

            string Fabric2 = hdnFab2.Value;
            //  lblFabric2STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'2', '" + avg2 + "', '" + StyleId + "', '" + Fabric2 + "')");
            if (od.FOrdWrite == true)
                td2p2.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'2', '" + avg2 + "', '" + StyleId + "', '" + Fabric2 + "','" + txtavg2 + "','" + od.ParentOrder.Style.StyleNumber + "')");
            //imagepath = objOrderController.GetSketch(orderDetailID, "", 2);
            //strcut = imagepath.Split(',');
            ////img.ImageUrl = "~/Uploads/Photo/" + imagepath;
            //if (strcut[0].ToString() != "")
            //{
            //    viewolay2.NavigateUrl = "~/Uploads/Photo/" + strcut[0].ToString();
            //    viewolay2.Attributes.Add("style", "display:block;");
            //}

            string avg3 = lblFabric3OrderAverage.Text;
            string Fabric3 = hdnFab3.Value;
            string txtavg3 = lblFabric3STCAverage.Text;

            // lblFabric3STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'3', '" + avg3 + "', '" + StyleId + "', '" + Fabric3 + "')");
            if (od.FOrdWrite == true)
                td2p3.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'3', '" + avg3 + "', '" + StyleId + "', '" + Fabric3 + "','" + txtavg3 + "','" + od.ParentOrder.Style.StyleNumber + "')");

            //imagepath = objOrderController.GetSketch(orderDetailID, "", 3);
            //strcut = imagepath.Split(',');
            //if (strcut[0].ToString() != "")
            //{
            //    //img.ImageUrl = "~/Uploads/Photo/" + imagepath;
            //    viewolay3.NavigateUrl = "~/Uploads/Photo/" + strcut[0].ToString();
            //    viewolay3.Attributes.Add("style", "display:block;");
            //}

            string avg4 = lblFabric4OrderAverage.Text;
            string Fabric4 = hdnFab4.Value;
            string txtavg4 = lblFabric4STCAverage.Text;
            // lblFabric4STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'4', '" + avg4 + "', '" + StyleId + "', '" + Fabric4 + "')");
            if (od.FOrdWrite == true)
                td2p4.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'4', '" + avg4 + "', '" + StyleId + "', '" + Fabric4 + "','" + txtavg4 + "','" + od.ParentOrder.Style.StyleNumber + "')");

            //if (od.CutAvgFile1 != "")
            //{
            //    //viewolay1.NavigateUrl = "~/Uploads/Photo/" + od.CutAvgFile1.ToString();
            //    //viewolay1.Attributes.Add("style", "display:block;");
            //}
            //if (od.CutAvgFile2 != "")
            //{
            //    //viewolay2.NavigateUrl = "~/Uploads/Photo/" + od.CutAvgFile2.ToString();
            //    //viewolay2.Attributes.Add("style", "display:block;");
            //}
            //if (od.CutAvgFile3 != "")
            //{
            //    //viewolay3.NavigateUrl = "~/Uploads/Photo/" + od.CutAvgFile3.ToString();
            //    //viewolay3.Attributes.Add("style", "display:block;");
            //}
            //if (od.CutAvgFile4 != "")
            //{
            //    //viewolay4.NavigateUrl = "~/Uploads/Photo/" + od.CutAvgFile4.ToString();
            //    //viewolay4.Attributes.Add("style", "display:block;");
            //}
            hypfitstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000EE");
            hypPlannedDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000EE");

            //}

            //Added By Ashish on 14/1/2015
            if (od.IsFitsPending == true)
            {
                hypfitstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3300");
                hypPlannedDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3300");
                //StrForColorCode = "#FFFF66";
            }
            if (od.IsShiped == true)
            {
                hypfitstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#807F80");
                hypPlannedDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#807F80");
                //StrForColorCode = "#FFFF66";
            }
            TextBox lblstcpending = e.Row.FindControl("lblstcpending") as TextBox;
            TextBox lblSTCETA = e.Row.FindControl("lblSTCETA") as TextBox;
            TextBox PATTERNETA = e.Row.FindControl("PATTERNETA") as TextBox;
            TextBox lblTOPETA = e.Row.FindControl("lblTOPETA") as TextBox;
            //Added By Ashish on 4/3/2015
            TextBox txtFitsETA = e.Row.FindControl("txtFitsETA") as TextBox;
            //END
            HtmlGenericControl spanSTCAPPETA = e.Row.FindControl("spanSTCAPPETA") as HtmlGenericControl;
            HtmlGenericControl spanstcapppending = e.Row.FindControl("spanstcapppending") as HtmlGenericControl;
            TextBox lblstcapppending = e.Row.FindControl("lblstcapppending") as TextBox;
            HtmlGenericControl spanPatternpending = e.Row.FindControl("spanPatternpending") as HtmlGenericControl;
            TextBox lblpatternpending = e.Row.FindControl("lblpatternpending") as TextBox;

            if (lblFabric1STCAverage.Text == "0")
                lblFabric1STCAverage.Text = "";
            if (lblFabric2STCAverage.Text == "0")
                lblFabric2STCAverage.Text = "";
            if (lblFabric3STCAverage.Text == "0")
                lblFabric3STCAverage.Text = "";
            if (lblFabric4STCAverage.Text == "0")
                lblFabric4STCAverage.Text = "";
            if (lblPercent1.Text == "(0%)")
                lblPercent1.Text = "";
            if (lblPercent2.Text == "(0%)")
                lblPercent2.Text = "";
            if (lblPercent3.Text == "(0%)")
                lblPercent3.Text = "";
            if (lblPercent4.Text == "(0%)")
                lblPercent4.Text = "";
            if (lblQuantityAvl1.Text == "0")
                lblQuantityAvl1.Text = "";
            if (lblQuantityAvl2.Text == "0")
                lblQuantityAvl2.Text = "";
            if (lblQuantityAvl3.Text == "0")
                lblQuantityAvl3.Text = "";
            if (lblQuantityAvl4.Text == "0")
                lblQuantityAvl4.Text = "";
            if (lblFinalOrderFabric1.Text == "0")
                lblFinalOrderFabric1.Text = "";
            if (lblFinalOrderFabric2.Text == "0")
                lblFinalOrderFabric2.Text = "";
            if (lblFinalOrderFabric3.Text == "0")
                lblFinalOrderFabric3.Text = "";
            if (lblFinalOrderFabric4.Text == "0")
                lblFinalOrderFabric4.Text = "";

            //added by abhishek on 21/9/2016
            TextBox txtinhouseqntyfab1 = e.Row.FindControl("txtinhouseqntyfab1") as TextBox;
            TextBox txtinhouseqntyfab2 = e.Row.FindControl("txtinhouseqntyfab2") as TextBox;
            TextBox txtinhouseqntyfab3 = e.Row.FindControl("txtinhouseqntyfab3") as TextBox;
            TextBox txtinhouseqntyfab4 = e.Row.FindControl("txtinhouseqntyfab4") as TextBox;

            HiddenField hdnFab1incheckedval = e.Row.FindControl("hdnFab1incheckedval") as HiddenField;
            HiddenField hdnFab2incheckedval = e.Row.FindControl("hdnFab2incheckedval") as HiddenField;
            HiddenField hdnFab3incheckedval = e.Row.FindControl("hdnFab3incheckedval") as HiddenField;
            HiddenField hdnFab4incheckedval = e.Row.FindControl("hdnFab4incheckedval") as HiddenField;

            if (txtinhouseqntyfab1.Text == "0")
                txtinhouseqntyfab1.Text = "";
            if (txtinhouseqntyfab2.Text == "0")
                txtinhouseqntyfab2.Text = "";
            if (txtinhouseqntyfab3.Text == "0")
                txtinhouseqntyfab3.Text = "";
            if (txtinhouseqntyfab4.Text == "0")
                txtinhouseqntyfab4.Text = "";
            txtinhouseqntyfab1.Text = txtinhouseqntyfab1.Text == "0k" ? "" : txtinhouseqntyfab1.Text;
            txtinhouseqntyfab2.Text = txtinhouseqntyfab2.Text == "0k" ? "" : txtinhouseqntyfab2.Text;
            txtinhouseqntyfab3.Text = txtinhouseqntyfab3.Text == "0k" ? "" : txtinhouseqntyfab3.Text;
            txtinhouseqntyfab4.Text = txtinhouseqntyfab4.Text == "0k" ? "" : txtinhouseqntyfab4.Text;

            if (hdnFab1incheckedval.Value != "0" && hdnFab1incheckedval.Value != "")
            {
                txtinhouseqntyfab1.ToolTip = Convert.ToInt32(hdnFab1incheckedval.Value).ToString("N0");
            }
            if (hdnFab2incheckedval.Value != "0" && hdnFab2incheckedval.Value != "")
            {
                txtinhouseqntyfab2.ToolTip = Convert.ToInt32(hdnFab2incheckedval.Value).ToString("N0");
            }
            if (hdnFab3incheckedval.Value != "0" && hdnFab3incheckedval.Value != "")
            {
                txtinhouseqntyfab3.ToolTip = Convert.ToInt32(hdnFab3incheckedval.Value).ToString("N0");
            }
            if (hdnFab4incheckedval.Value != "0" && hdnFab4incheckedval.Value != "")
            {
                txtinhouseqntyfab4.ToolTip = Convert.ToInt32(hdnFab4incheckedval.Value).ToString("N0");
            }

            //Added by MR.A 9/2/2018
            Label lblfabinHouseAvg = e.Row.FindControl("lblfabinHouseAvg") as Label;
            Label lblfabinHouseAvg2 = e.Row.FindControl("lblfabinHouseAvg2") as Label;
            Label lblfabinHouseAvg3 = e.Row.FindControl("lblfabinHouseAvg3") as Label;
            Label lblfabinHouseAvg4 = e.Row.FindControl("lblfabinHouseAvg4") as Label;
            if (!string.IsNullOrEmpty(hdnFab1incheckedval.Value) && !string.IsNullOrEmpty(lblFabric1STCAverage.Text))
            {
                string fab1CutIssueAvgtooltip = Math.Round((Convert.ToDecimal(hdnFab1incheckedval.Value) / Convert.ToDecimal(lblFabric1STCAverage.Text)), 0, MidpointRounding.AwayFromZero).ToString();
                string fab1CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(hdnFab1incheckedval.Value) / Convert.ToDecimal(lblFabric1STCAverage.Text)) / 1000), 1, MidpointRounding.AwayFromZero).ToString();
                lblfabinHouseAvg.Text = " (" + fab1CutIssueAvgIn_K + "k Pcs)";
                lblfabinHouseAvg.Text = lblfabinHouseAvg.Text == " (0k Pcs)" ? "" : lblfabinHouseAvg.Text;
                lblfabinHouseAvg.ToolTip = Convert.ToInt32(fab1CutIssueAvgtooltip).ToString("N0");
                //txtinhouseqntyfab1.Text = txtinhouseqntyfab1.Text +" "+ lblfabinHouseAvg.Text;
            }
            if (od.IsShiped == true)
                lblfabinHouseAvg.ForeColor = Color.Gray;
            if (!string.IsNullOrEmpty(hdnFab2incheckedval.Value) && !string.IsNullOrEmpty(lblFabric2STCAverage.Text))
            {
                string fab2CutIssueAvgtooltip = Math.Round((Convert.ToDecimal(hdnFab2incheckedval.Value) / Convert.ToDecimal(lblFabric2STCAverage.Text)), 0, MidpointRounding.AwayFromZero).ToString();
                string fab2CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(hdnFab2incheckedval.Value) / Convert.ToDecimal(lblFabric2STCAverage.Text)) / 1000), 1, MidpointRounding.AwayFromZero).ToString();
                //if (Convert.ToDouble(fab2CutIssueAvgIn_K) > 0)
                lblfabinHouseAvg2.Text = " (" + fab2CutIssueAvgIn_K + "k Pcs)";
                lblfabinHouseAvg2.Text = lblfabinHouseAvg2.Text == " (0k Pcs)" ? "" : lblfabinHouseAvg2.Text;
                //if (Convert.ToDouble(fab2CutIssueAvgtooltip) > 0)
                lblfabinHouseAvg2.ToolTip = Convert.ToInt32(fab2CutIssueAvgtooltip).ToString("N0");
                //txtinhouseqntyfab2.Text = txtinhouseqntyfab2.Text +" "+ lblfabinHouseAvg.Text;
            }
            if (od.IsShiped == true)
                lblfabinHouseAvg2.ForeColor = Color.Gray;
            if (!string.IsNullOrEmpty(hdnFab3incheckedval.Value) && !string.IsNullOrEmpty(lblFabric3STCAverage.Text))
            {
                string fab3CutIssueAvgtooltip = Math.Round((Convert.ToDecimal(hdnFab3incheckedval.Value) / Convert.ToDecimal(lblFabric3STCAverage.Text)), 0, MidpointRounding.AwayFromZero).ToString();
                string fab3CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(hdnFab3incheckedval.Value) / Convert.ToDecimal(lblFabric3STCAverage.Text)) / 1000), 1, MidpointRounding.AwayFromZero).ToString();
                //if (Convert.ToDouble(fab3CutIssueAvgIn_K) > 0)
                lblfabinHouseAvg3.Text = " (" + fab3CutIssueAvgIn_K + "k Pcs)";
                //if (Convert.ToDouble(fab3CutIssueAvgtooltip) > 0)
                lblfabinHouseAvg3.Text = lblfabinHouseAvg3.Text == " (0k Pcs)" ? "" : lblfabinHouseAvg3.Text;
                lblfabinHouseAvg3.ToolTip = Convert.ToInt32(fab3CutIssueAvgtooltip).ToString("N0");
                //txtinhouseqntyfab3.Text = txtinhouseqntyfab3.Text +" "+ lblfabinHouseAvg.Text;
            }
            if (od.IsShiped == true)
                lblfabinHouseAvg3.ForeColor = Color.Gray;
            if (!string.IsNullOrEmpty(hdnFab4incheckedval.Value) && !string.IsNullOrEmpty(lblFabric4STCAverage.Text))
            {
                string fab4CutIssueAvgtooltip = Math.Round((Convert.ToDecimal(hdnFab4incheckedval.Value) / Convert.ToDecimal(lblFabric4STCAverage.Text)), 0, MidpointRounding.AwayFromZero).ToString();
                string fab4CutIssueAvgIn_K = Math.Round(((Convert.ToDecimal(hdnFab4incheckedval.Value) / Convert.ToDecimal(lblFabric4STCAverage.Text)) / 1000), 1, MidpointRounding.AwayFromZero).ToString();
                //if (Convert.ToDouble(fab4CutIssueAvgIn_K) > 0)
                lblfabinHouseAvg4.Text = " (" + fab4CutIssueAvgIn_K + "k Pcs)";
                lblfabinHouseAvg4.Text = lblfabinHouseAvg4.Text == " (0k Pcs)" ? "" : lblfabinHouseAvg4.Text;
                //if (Convert.ToDouble(fab4CutIssueAvgtooltip) > 0)
                lblfabinHouseAvg4.ToolTip = Convert.ToInt32(fab4CutIssueAvgtooltip).ToString("N0");
                //txtinhouseqntyfab4.Text = txtinhouseqntyfab4.Text +" "+ lblfabinHouseAvg.Text;
            }
            if (od.IsShiped == true)
                lblfabinHouseAvg4.ForeColor = Color.Gray;
            if (lblFinalOrderFabric1.Text != "")
            {
                double finalOrder1 = 0;

                finalOrder1 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric1.Text).Replace(",", "").Replace("k", ""));
                //lblFinalOrderFabric1.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder1 * 1000));


                // double FinalOrderFabric1_kd = (lblQuantity / 1000);

                //double FinalOrderFabric1_kd = ((Convert.ToDouble(lblQuantity.Text)* Quantity) / 1000);
                lblFinalOrderFabric1.Text = lblFinalOrderFabric1.Text.ToString() + "k"; ;
            }
            if (lblFinalOrderFabric2.Text != "")
            {
                double finalOrder2 = 0;

                finalOrder2 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric2.Text).Replace(",", "").Replace("k", ""));
                //lblFinalOrderFabric2.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder2 * 1000));

                //double FinalOrderFabric2_kd = (finalOrder2 / 1000);
                lblFinalOrderFabric2.Text = lblFinalOrderFabric2.Text.ToString() + "k"; ;
            }
            if (lblFinalOrderFabric3.Text != "")
            {
                double finalOrder3 = 0;

                finalOrder3 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric3.Text).Replace(",", "").Replace("k", ""));

                //lblFinalOrderFabric3.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder3 * 1000));
                // double FinalOrderFabric3_kd = (finalOrder3 / 1000);
                lblFinalOrderFabric3.Text = lblFinalOrderFabric3.Text.ToString() + "k";
            }
            if (lblFinalOrderFabric4.Text != "")
            {
                double finalOrder4 = 0;

                finalOrder4 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric4.Text).Replace(",", "").Replace("k", ""));

                //lblFinalOrderFabric4.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder4 * 1000));
                // double FinalOrderFabric4_kd = (finalOrder4 / 1000);
                lblFinalOrderFabric4.Text = lblFinalOrderFabric4.Text.ToString() + "k";
            }

            lblFinalOrderFabric1.Text = lblFinalOrderFabric1.Text == "0.0k" ? "" : lblFinalOrderFabric1.Text;
            lblFinalOrderFabric2.Text = lblFinalOrderFabric2.Text == "0.0k" ? "" : lblFinalOrderFabric2.Text;
            lblFinalOrderFabric3.Text = lblFinalOrderFabric3.Text == "0.0k" ? "" : lblFinalOrderFabric3.Text;
            lblFinalOrderFabric4.Text = lblFinalOrderFabric4.Text == "0.0k" ? "" : lblFinalOrderFabric4.Text;

            lblFinalOrderFabric1.ToolTip = od.Fabric1Required_ToolTip;
            lblFinalOrderFabric2.ToolTip = od.Fabric2Required_ToolTip;
            lblFinalOrderFabric3.ToolTip = od.Fabric3Required_ToolTip;
            lblFinalOrderFabric4.ToolTip = od.Fabric4Required_ToolTip;

            lblFinalOrderFabric1.ToolTip = od.Fabric1Required_ToolTip;
            lblFinalOrderFabric2.ToolTip = od.Fabric2Required_ToolTip;
            lblFinalOrderFabric3.ToolTip = od.Fabric3Required_ToolTip;
            lblFinalOrderFabric4.ToolTip = od.Fabric4Required_ToolTip;

            hdnFinalFabric_ToolTip.Value = lblFinalOrderFabric1.ToolTip == "" ? "0" : lblFinalOrderFabric1.ToolTip;
            hdnFina2Fabric_ToolTip.Value = lblFinalOrderFabric2.ToolTip == "" ? "0" : lblFinalOrderFabric2.ToolTip;
            hdnFina3Fabric_ToolTip.Value = lblFinalOrderFabric3.ToolTip == "" ? "0" : lblFinalOrderFabric3.ToolTip;
            hdnFina4Fabric_ToolTip.Value = lblFinalOrderFabric4.ToolTip == "" ? "0" : lblFinalOrderFabric4.ToolTip;

            //end by abhishek 

            //Added By Ashish on 4/3/2015
            string FitsETAdate = Convert.ToDateTime(od.FitsETA) == DateTime.MinValue ? "" : Convert.ToDateTime(od.FitsETA).ToString("dd MMM yy (ddd)");
            //END
            txtFitsETA.Attributes.Add("onclick", "javascript:showEtaPopup('FitsStatusETA','FitsETA','" + od.ParentOrder.Style.StyleID + "','','','" + FitsETAdate + "','','" + od.ParentOrder.Style.StyleNumber + "','','" + od.OrderDetailID + "','" + od.FitsETADateWrite + "', 62)");
            //txtFitsETA
            // Work For Color change of STC date By Ravi kumar

            if (od.ParentOrder.Fits.SealDate != DateTime.MinValue)
            {
                lblSTCETA.Attributes.Add("readonly", "readonly");
                //lnkStcDate.Attributes.Add("onclick", "javascript:void(0);");
            }
            else
            {
                string STCdate = Convert.ToDateTime(od.STCETA) == DateTime.MinValue ? "" : Convert.ToDateTime(od.STCETA).ToString("dd MMM yy (ddd)");
                //Added By Ashish on 23/2/2015
                lblSTCETA.Attributes.Add("onclick", "javascript:showEtaPopup('STCRequest','FitsETA','" + od.ParentOrder.Style.StyleID + "','','','" + STCdate + "','','" + od.ParentOrder.Style.StyleNumber + "','','" + od.OrderDetailID + "','" + od.FitsSTCETAWrite + "', 62)");
                //END
            }
            if (od.PatternSampleDate != DateTime.MinValue)
            {
                PATTERNETA.Attributes.Add("readonly", "readonly");
            }
            else
            {
                string PatternSampleEta = Convert.ToDateTime(od.PatternSampleDateETA) == DateTime.MinValue ? "" : Convert.ToDateTime(od.PatternSampleDateETA).ToString("dd MMM yy (ddd)");
                //Added By Ashish on 23/2/2015
                PATTERNETA.Attributes.Add("onclick", "javascript:showEtaPopup('PatternETA','FitsETA','" + od.ParentOrder.Style.StyleID + "','','','" + PatternSampleEta + "','','" + od.ParentOrder.Style.StyleNumber + "','','" + od.OrderDetailID + "','" + od.FitsPatternETAWrite + "', 63)");
                //END

            }

            if (od.ParentOrder.InlinePPMOrderContract.TopSentActual != DateTime.MinValue)
            {
                lblTOPETA.Attributes.Add("readonly", "readonly");
            }
            else
            {
                string sTOPETA = Convert.ToDateTime(od.TOPETA) == DateTime.MinValue ? "" : Convert.ToDateTime(od.TOPETA).ToString("dd MMM yy (ddd)");
                //Added By Ashish on 23/2/2015
                lblTOPETA.Attributes.Add("onclick", "javascript:showEtaPopup('TOPETA','FitsETA','" + od.ParentOrder.Style.StyleID + "','','','" + sTOPETA + "','','" + od.ParentOrder.Style.StyleNumber + "','','" + od.OrderDetailID + "','" + od.FitsTOPSentETAWrite + "', 64)");
                //END

            }

            //added by abhishek on 15/3/2016
            TextBox TxtPhotoshot = e.Row.FindControl("TxtPhotoshot") as TextBox;
            Label lblIsRepeatOrder = e.Row.FindControl("lblIsRepeatOrder") as Label;

            CheckBox chkPhotoshot = e.Row.FindControl("chkPhotoshot") as CheckBox;
            chkPhotoshot.Checked = Convert.ToBoolean(od.PhotoShoot);

            if (od.PhotoShotWrite == true)
            {
                if (od.PhotoShoot == true)
                {
                    chkPhotoshot.Enabled = false;
                }
            }
            else
            {
                chkPhotoshot.Enabled = false;
                TxtPhotoshot.Enabled = false;

            }
            if (od.IsRepeatWithChanges == true)
            {
                lblIsRepeatOrder.Text = od.IsRepeatWithChanges == true ? "Repeat" : string.Empty;
                lblIsRepeatOrder.ToolTip = "Repeat with changes";
            }
            else if (od.IsRepeat == true)
            {
                lblIsRepeatOrder.Text = od.IsRepeat == true ? "Direct Repeat" : string.Empty;
                lblIsRepeatOrder.ToolTip = "Direct Repeat with no changes";
            }


            //end by abhishek on 15/3/2016

            //added by abhishek on 11/2/2016
            HtmlTableCell tdTestReport = (HtmlTableCell)e.Row.FindControl("tdTestReport");
            TextBox TxtETATestReport = (TextBox)e.Row.FindControl("TxtETATestReport");
            String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
            HyperLink hlnktestupload = e.Row.FindControl("hlnktestupload") as HyperLink;
            //HyperLink hlnViewUpload = e.Row.FindControl("hlnViewUpload") as HyperLink;
            Label lbltestReportTagrgetsDates = e.Row.FindControl("lbltestReportTagrgetsDates") as Label;
            Label lblTestReportActualDate = e.Row.FindControl("lblTestReportActualDate") as Label;
            Label lbltextreport = e.Row.FindControl("lbltextreport") as Label;
            TxtETATestReport.Visible = od.FitsHOPPMETARead;

            if (od.TestReportWrite == true)
            {
                TxtETATestReport.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                TxtETATestReport.Attributes.Add("readonly", "readonly");
            }

            if (od.TestReportsDateETA != DateTime.MinValue && od.TestReportsDateActual != DateTime.MinValue)
            {
                TxtETATestReport.CssClass = "do-not-allow-typing";
            }
            if (lbltextreport != null)
            {
                if (od.IsTestReportDone == 2)
                {
                    lbltextreport.Text = "Test Report";
                }
                if (od.IsTestReportDone == 0)
                {
                    lbltextreport.Text = "Test Report Fail";
                }
                if (od.IsTestReportDone == 1)
                {
                    lbltextreport.Text = "Test Report Pass";
                }
                if (od.IsTestReportDone == 3)
                {
                    lbltextreport.Text = "Waive off Pass";
                }
            }


            if (od.IsShiped == true)
            {
                tdTestReport.Style.Add("background-color", "#F9F9FA");
                lbltextreport.Style.Add("color", "#807F80");
            }
            else
            {
                //Edited by abhishek on 8/1/2015 
                if (od.TestReportTargetETA >= DateTime.Now.Date)//test report target date
                {
                    //End by abhishek on 8/1/2015
                    if (lblTestReportActualDate.Text == "")
                    {
                        //tdTestReport.Style.Add("background-color", "#FFFFFF");
                        lbltextreport.Style.Add("color", "Gray");
                    }
                }
                else
                {

                    if (lblTestReportActualDate.Text == "")
                    {
                        tdTestReport.Style.Add("background-color", "#FDFD96");
                        lbltextreport.Style.Add("color", "#FF3300");
                    }
                }
            }


            if (TxtETATestReport != null)
            {
                if (od.FitsHOPPMRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //txtETAHOPPM.ForeColor = System.Drawing.Color.Gray;
                        lblTestReportActualDate.ForeColor = System.Drawing.Color.Gray;
                        lbltestReportTagrgetsDates.ForeColor = System.Drawing.Color.Gray;
                        tdTestReport.Style.Add("background-color", "#F9F9FA");
                        lbltextreport.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        if (TxtETATestReport.Text != "" && lblTestReportActualDate.Text != "")
                        {
                            //txtETAHOPPM.ForeColor = System.Drawing.Color.Gray;
                            lblTestReportActualDate.ForeColor = System.Drawing.Color.Gray;
                            lbltestReportTagrgetsDates.ForeColor = System.Drawing.Color.Gray;
                            //tdTestReport.Style.Add("background-color", "#FFFFFF");
                            TxtETATestReport.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            //txtETAHOPPM.ForeColor = System.Drawing.Color.Black;
                            lblTestReportActualDate.ForeColor = System.Drawing.Color.Black;
                            lbltestReportTagrgetsDates.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }
                else
                {
                    // tdTestReport.Style.Add("background-color", "#FFFFFF");
                }
            }


            //end by abhishek 11/2/2016

            //added by abhishek on 11/2/2016
            HtmlTableCell tdcdchat = (HtmlTableCell)e.Row.FindControl("tdcdchat");
            TextBox txtcdchartETA = (TextBox)e.Row.FindControl("txtcdchartETA");
            Label lblcdchat = (Label)e.Row.FindControl("lblcdchat");
            TextBox txtStrikeof1 = (TextBox)e.Row.FindControl("txtStrikeof1");
            TextBox txtStrikeof2 = (TextBox)e.Row.FindControl("txtStrikeof2");
            TextBox txtStrikeof3 = (TextBox)e.Row.FindControl("txtStrikeof3");
            TextBox txtStrikeof4 = (TextBox)e.Row.FindControl("txtStrikeof4");

            if (od.IntialAprd1 != 2)
                txtStrikeof1.Attributes.Add("class", "th do-not-allow-typing");
            if (od.IntialAprd2 != 2)
                txtStrikeof2.Attributes.Add("class", "th do-not-allow-typing");
            if (od.IntialAprd3 != 2)
                txtStrikeof3.Attributes.Add("class", "th do-not-allow-typing");
            if (od.IntialAprd4 != 2)
                txtStrikeof4.Attributes.Add("class", "th do-not-allow-typing");



            Label lblcdcharttargetdate = e.Row.FindControl("lblcdcharttargetdate") as Label;
            TextBox TxtactualDate = e.Row.FindControl("TxtactualDate") as TextBox;

            txtcdchartETA.Visible = od.FitsHOPPMETARead;

            if (od.CDCharWrite == true)
            {
                txtcdchartETA.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                txtcdchartETA.Attributes.Add("readonly", "readonly");
            }

            if (od.CdchartDateETA != DateTime.MinValue && od.CdchartActualDateETA != DateTime.MinValue)
            {
                txtcdchartETA.CssClass = "do-not-allow-typing";
            }
            if (od.CdchartActualDateETA != DateTime.MinValue)
            {
                TxtactualDate.CssClass = "do-not-allow-typing";
            }

            if (od.IsShiped == true)
            {
                tdcdchat.Style.Add("background-color", "#F9F9FA");
                lblcdchat.Style.Add("color", "#807F80");
            }
            else
            {
                if (od.CdchartTargetDateETA >= DateTime.Now.Date)
                {
                    if (TxtactualDate.Text == "")
                    {
                        // tdcdchat.Style.Add("background-color", "#FFFFFF");
                        lblcdchat.Style.Add("color", "Gray");
                    }
                }
                else
                {

                    if (TxtactualDate.Text == "")
                    {
                        tdcdchat.Style.Add("background-color", "#FDFD96");
                        lblcdchat.Style.Add("color", "#FF3300");
                    }
                }
            }

            if (txtcdchartETA != null)
            {
                if (od.FitsHOPPMRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //txtETAHOPPM.ForeColor = System.Drawing.Color.Gray;
                        TxtactualDate.ForeColor = System.Drawing.Color.Gray;
                        lblcdcharttargetdate.ForeColor = System.Drawing.Color.Gray;
                        tdcdchat.Style.Add("background-color", "#F9F9FA");
                        lblcdchat.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        if (txtcdchartETA.Text != "" && TxtactualDate.Text != "")
                        {
                            //txtETAHOPPM.ForeColor = System.Drawing.Color.Gray;
                            TxtactualDate.ForeColor = System.Drawing.Color.Gray;
                            lblcdcharttargetdate.ForeColor = System.Drawing.Color.Gray;
                            //tdcdchat.Style.Add("background-color", "#FFFFFF");
                            txtcdchartETA.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            //txtETAHOPPM.ForeColor = System.Drawing.Color.Black;
                            TxtactualDate.ForeColor = System.Drawing.Color.Black;
                            lblcdcharttargetdate.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }
                else
                {
                    //tdcdchat.Style.Add("background-color", "#FFFFFF");
                }
            }
            //end by abhishek 11/2/2016
            // Added By Ravi kumar on 28/12/2015
            Label lblst = (Label)e.Row.FindControl("lblst");
            Label lblEnd = (Label)e.Row.FindControl("lblEnd");
            Label lblCMTAct = (Label)e.Row.FindControl("lblCMTAct");
            Label lblCMTTgt = (Label)e.Row.FindControl("lblCMTTgt");
            Label lblCosted = (Label)e.Row.FindControl("lblCosted");
            Label lblProfitLoss = (Label)e.Row.FindControl("lblProfitLoss");
            Label lblActualEff = (Label)e.Row.FindControl("lblActualEff");
            Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
            Label lblBE = (Label)e.Row.FindControl("lblBE");
            Label lblstdate = (Label)e.Row.FindControl("lblstdate");
            TextBox txtProPlaningETA = (TextBox)e.Row.FindControl("txtProPlaningETA");
            //if (od.LinePlannigStartDate == "")//abhishek
            //{
            //  //lblst.Visible = false;
            //  lblstdate.Visible = false;
            //  txtProPlaningETA.Visible = true;
            //  if (ApplicationHelper.LoggedInUser.UserData.UserID != 646 && ApplicationHelper.LoggedInUser.UserData.UserID != 488)
            //  {
            //    txtProPlaningETA.Enabled = false;
            //    txtProPlaningETA.ToolTip = "You don't have permission to change date";
            //  }
            //}
            //else
            //{
            //  //lblst.Visible = true;
            //  lblstdate.Visible = true;
            //  txtProPlaningETA.Visible = false;
            //}
            if (od.LinePlannigStartDate == "")//abhishek
            {
              lblst.Visible = false;
            }
            if (od.IsLinePlannigStartDate.ToLower() == "false")//abhishek
            {
              lblst.Visible = true;
              lblstdate.Visible = false;
              txtProPlaningETA.Visible = true;
              if (ApplicationHelper.LoggedInUser.UserData.UserID != 646 && ApplicationHelper.LoggedInUser.UserData.UserID != 655)
              {
                txtProPlaningETA.Enabled = false;
                txtProPlaningETA.ToolTip = "You don't have permission to change date";
              }
            }
            else
            {
              //lblst.Visible = true;
              lblstdate.Visible = true;
              txtProPlaningETA.Visible = false;
            }

            TextBox1.Visible = od.FitsCuttingETARead;
            //TextBox1.Enabled = od.FitsCuttingETAWrite;
            if (od.FitsCuttingETAWrite == true)
            {
                //TextBox1.Style.Add("CssClass", "date-picker");
                TextBox1.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                TextBox1.Attributes.Add("readonly", "readonly");
            }
            TextBox2.Visible = od.FitsProdFileETARead;
            //TextBox2.Enabled = od.FitsProdFileETAWrite;
            if (od.FitsProdFileETAWrite == true)
            {
                TextBox2.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                TextBox2.Attributes.Add("readonly", "readonly");
            }

            //if (od.FitsProdFileETAWrite == true)
            //{
            //    TextBox4.Attributes.Add("class", "th do-not-allow-typing");
            //}
            //else
            //{
            //    TextBox4.Attributes.Add("readonly", "readonly");
            //}
            if (od.FitsProdFileETAWrite == true)
            {
                txtHanoverETA.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                txtHanoverETA.Attributes.Add("readonly", "readonly");
            }

            if (od.FitsProdFileETAWrite == true)
            {
                txtPatternReadyETADate.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                txtPatternReadyETADate.Attributes.Add("readonly", "readonly");
            }

            if (od.FitsProdFileETAWrite == true)
            {
                txtSampleSentETA.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                txtSampleSentETA.Attributes.Add("readonly", "readonly");
            }
            if (od.FitsProdFileETAWrite == true)
            {
                txtFitsCommentesUplaodETADate.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                txtFitsCommentesUplaodETADate.Attributes.Add("readonly", "readonly");
            }


            txtETAHOPPM.Visible = od.FitsHOPPMETARead;
            //txtETAHOPPM.Enabled = od.FitsHOPPMETAWrite;
            if (od.FitsHOPPMETAWrite == true)
            {
                txtETAHOPPM.Attributes.Add("class", "th do-not-allow-typing");
            }
            else
            {
                txtETAHOPPM.Attributes.Add("readonly", "readonly");
            }
            if (od.HOPPMETA != DateTime.MinValue && od.HOPPMActionactualDate != DateTime.MinValue)
            {
                txtETAHOPPM.CssClass = "do-not-allow-typing";
            }

            HtmlTableCell tdSTC = (HtmlTableCell)e.Row.FindControl("tdSTC");
            Label lblSTCName = (Label)e.Row.FindControl("lblSTCName");
            //lblSTCName.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");

            Label txtSealDate = (Label)e.Row.FindControl("txtrequested");
            //=================Prabhaker-16-jun-17-------------//
            if (txtSealDate.Text == "")
            {
                HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
                //HtmlControl apprShow = (HtmlTable)this.FindControl("apprShow");
                apprShow.Visible = true;
                HtmlTableRow apprShow1 = (HtmlTableRow)e.Row.FindControl("apprShow1");
                apprShow1.Visible = true;
                HtmlTableRow apprShow2 = (HtmlTableRow)e.Row.FindControl("apprShow2");
                apprShow2.Visible = true;
                HtmlTableRow apprShow3 = (HtmlTableRow)e.Row.FindControl("apprShow3");
                apprShow3.Visible = true;
                HtmlTableRow apprHide = (HtmlTableRow)e.Row.FindControl("apprHide");
                apprHide.Visible = false;
                HtmlTableRow apprHide1 = (HtmlTableRow)e.Row.FindControl("apprHide1");
                apprHide1.Visible = false;
                HtmlTableRow apprHide2 = (HtmlTableRow)e.Row.FindControl("apprHide2");
                apprHide2.Visible = false;
                HtmlTableRow apprHide3 = (HtmlTableRow)e.Row.FindControl("apprHide3");
                apprHide3.Visible = false;
                HtmlTableRow apprHide4 = (HtmlTableRow)e.Row.FindControl("apprHide4");
                apprHide4.Visible = false;
                HtmlTableRow apprHide5 = (HtmlTableRow)e.Row.FindControl("apprHide5");
                apprHide5.Visible = false;
                //added by prabhaker on 16/11/2017
                lblSTCETA.ToolTip = "STC Target Date";
                //End
            }
            else
            {
                HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
                apprShow.Visible = false;
                HtmlTableRow apprShow1 = (HtmlTableRow)e.Row.FindControl("apprShow1");
                apprShow1.Visible = false;
                HtmlTableRow apprShow2 = (HtmlTableRow)e.Row.FindControl("apprShow2");
                apprShow2.Visible = false;
                HtmlTableRow apprShow3 = (HtmlTableRow)e.Row.FindControl("apprShow3");
                apprShow3.Visible = false;
                HtmlTableRow apprHide = (HtmlTableRow)e.Row.FindControl("apprHide");
                apprHide.Visible = true;
                HtmlTableRow apprHide1 = (HtmlTableRow)e.Row.FindControl("apprHide1");
                apprHide1.Visible = true;
                HtmlTableRow apprHide2 = (HtmlTableRow)e.Row.FindControl("apprHide2");
                apprHide2.Visible = true;
                HtmlTableRow apprHide3 = (HtmlTableRow)e.Row.FindControl("apprHide3");
                apprHide3.Visible = true;
                HtmlTableRow apprHide4 = (HtmlTableRow)e.Row.FindControl("apprHide4");
                apprHide4.Visible = true;
                HtmlTableRow apprHide5 = (HtmlTableRow)e.Row.FindControl("apprHide5");
                apprHide5.Visible = true;
                //added by prabhaker on 16/11/2017

                lblSTCETA.ToolTip = "STC Requested Date";
                //End
            }

            //=================End Code of Prabhaker-16-jun-17-------------//



            if (od.IsShiped == true)
            {
                tdSTC.Style.Add("background-color", "#F9F9FA");
                lblSTCName.Style.Add("color", "#807F80");
            }
            else
            {

                if (od.STCtargetsDate.Date >= DateTime.Now.Date)
                {

                    if (txtSealDate.Text == "")
                    {

                        //tdSTC.Style.Add("background-color", "#FFFFFF");
                        lblSTCName.Style.Add("color", "Gray");
                    }
                }
                else
                {

                    if (txtSealDate.Text == "")
                    {
                        tdSTC.Style.Add("background-color", "#FDFD96");
                        lblSTCName.Style.Add("color", "#FF3300");
                    }
                }
            }

            if (lblSTCETA != null)
            {
                if (od.FitsPatternRead == true)
                {

                    if (od.IsShiped == true)
                    {
                        //lblSTCETA.ForeColor = System.Drawing.Color.Gray;
                        txtSealDate.ForeColor = System.Drawing.Color.Gray;
                        lblstctgt.ForeColor = System.Drawing.Color.Gray;
                        //tdSTC.Style.Add("background-color", "#F9F9FA");
                        lblSTCName.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        if (lblSTCETA.Text != "" && txtSealDate.Text != "")
                        {
                            //lblSTCETA.ForeColor = System.Drawing.Color.Gray;
                            txtSealDate.ForeColor = System.Drawing.Color.Gray;
                            lblstctgt.ForeColor = System.Drawing.Color.Gray;
                            // tdSTC.Style.Add("background-color", "#FFFFFF");
                            lblSTCName.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            //lblSTCETA.ForeColor = System.Drawing.Color.Black;
                            txtSealDate.ForeColor = System.Drawing.Color.Black;
                            lblstctgt.ForeColor = System.Drawing.Color.Black;
                        }


                    }
                }
                else
                {
                    //tdSTC.Style.Add("background-color", "#FFFFFF");
                }
            }
            if (txtSealDate.Text != "")
            {
                lnkFitsPopUpETAfil.Visible = false;
            }


            // End Work For Color change of STC date By Ravi kumar
            // Work For Color change of Pattern Sample date By Ravi kumar
            HtmlTableCell tdPatternSample = (HtmlTableCell)e.Row.FindControl("tdPatternSample");//lblPatternSampleName
            Label lblPatternSampleName = (Label)e.Row.FindControl("lblPatternSampleName");
            TextBox txtPatternSampleDate = (TextBox)e.Row.FindControl("lblPatternSampleDate");
            Label lblpatterntar = (Label)e.Row.FindControl("lblpatterntar");

            if (od.IsShiped == true)
            {
                tdPatternSample.Style.Add("background-color", "#F9F9FA");
                lblPatternSampleName.Style.Add("color", "#807F80");
            }
            else
            {
                if (od.PatternSampleTarget.Date >= DateTime.Now.Date)
                {
                    if (txtPatternSampleDate.Text == "")
                    {
                        //tdPatternSample.Style.Add("background-color", "#FFFFFF");
                        lblPatternSampleName.Style.Add("color", "Gray");
                    }
                }
                else
                {

                    if (txtPatternSampleDate.Text == "")
                    {
                        tdPatternSample.Style.Add("background-color", "#FFFF96");
                        lblPatternSampleName.Style.Add("color", "#FF3300");
                    }
                }
            }


            if (PATTERNETA != null)
            {
                if (od.FitsPatternRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //PATTERNETA.ForeColor = System.Drawing.Color.Gray;
                        txtPatternSampleDate.ForeColor = System.Drawing.Color.Gray;
                        lblpatterntar.ForeColor = System.Drawing.Color.Gray;
                        tdPatternSample.Style.Add("background-color", "#F9F9FA");
                        lblPatternSampleName.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        if (PATTERNETA.Text != "" && txtPatternSampleDate.Text != "")
                        {
                            //PATTERNETA.ForeColor = System.Drawing.Color.Gray;
                            txtPatternSampleDate.ForeColor = System.Drawing.Color.Gray;
                            lblpatterntar.ForeColor = System.Drawing.Color.Gray;

                            // tdPatternSample.Style.Add("background-color", "#FFFFFF");
                            lblPatternSampleName.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            //PATTERNETA.ForeColor = System.Drawing.Color.Black;
                            txtPatternSampleDate.ForeColor = System.Drawing.Color.Black;
                            lblpatterntar.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }
                else
                {
                    //tdPatternSample.Style.Add("background-color", "#FFFFFF");
                }
            }
            // End Work For Color change of Pattern Sample date By Ravi kumar
            // Work For Color change of Cutting sheet date By Ravi kumar
            HtmlTableCell tdCuttingSheet = (HtmlTableCell)e.Row.FindControl("tdCuttingSheet");
            Label lblCuttingSheet = (Label)e.Row.FindControl("lblCuttingSheet");
            TextBox txtCuttingSheetDate = (TextBox)e.Row.FindControl("lblCuttingSheetDate");
            Label lblcuttingtar = (Label)e.Row.FindControl("lblcuttingtar");

            if (od.IsShiped == true)
            {
                tdCuttingSheet.Style.Add("background-color", "#F9F9FA");
                lblCuttingSheet.Style.Add("color", "#807F80");
            }
            else
            {
                if (od.CuttingTarget.Date >= DateTime.Now.Date)
                {

                    if (txtCuttingSheetDate.Text == "")
                    {
                        //  tdCuttingSheet.Style.Add("background-color", "#FFFFFF");
                        lblCuttingSheet.Style.Add("color", "Gray");
                    }
                }
                else
                {

                    if (txtCuttingSheetDate.Text == "")
                    {
                        tdCuttingSheet.Style.Add("background-color", "#FFFF96");
                        lblCuttingSheet.Style.Add("color", "#FF3300");
                    }
                }
            }

            if (TextBox1 != null)
            {
                if (od.FitsCuttingkRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //TextBox1.ForeColor = System.Drawing.Color.Gray;
                        txtCuttingSheetDate.ForeColor = System.Drawing.Color.Gray;
                        lblcuttingtar.ForeColor = System.Drawing.Color.Gray;
                        tdCuttingSheet.Style.Add("background-color", "#F9F9FA");
                        lblCuttingSheet.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        if (TextBox1.Text != "" && txtCuttingSheetDate.Text != "")
                        {
                            //TextBox1.ForeColor = System.Drawing.Color.Gray;
                            txtCuttingSheetDate.ForeColor = System.Drawing.Color.Gray;
                            lblcuttingtar.ForeColor = System.Drawing.Color.Gray;

                            //tdCuttingSheet.Style.Add("background-color", "#FFFFFF");
                            lblCuttingSheet.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            //TextBox1.ForeColor = System.Drawing.Color.Black;
                            txtCuttingSheetDate.ForeColor = System.Drawing.Color.Black;
                            lblcuttingtar.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }
                else
                {
                    // tdCuttingSheet.Style.Add("background-color", "#FFFFFF");
                }
            }
          
            HtmlTableCell tdProdFile = (HtmlTableCell)e.Row.FindControl("tdProdFile");
        //    HtmlTableCell tdPPSample = (HtmlTableCell)e.Row.FindControl("tdPPSample");
            
            HtmlTableCell tdHandover = (HtmlTableCell)e.Row.FindControl("tdHandover");
            HtmlTableCell tdPatternReady = (HtmlTableCell)e.Row.FindControl("tdPatternReady");
            HtmlTableCell tdSampleSent = (HtmlTableCell)e.Row.FindControl("tdSampleSent");
            HtmlTableCell tdFitsCommentesUplaod = (HtmlTableCell)e.Row.FindControl("tdFitsCommentesUplaod");
            TextBox txtProductionFileDate = (TextBox)e.Row.FindControl("lblProductionFileDate");

            Label lblProdFile = (Label)e.Row.FindControl("lblProdFile");
            Label lblHandover = (Label)e.Row.FindControl("lblHandover");
            Label lblPatternReady = (Label)e.Row.FindControl("lblPatternReady");
            Label lblSamplesent = (Label)e.Row.FindControl("lblSamplesent");
            Label lblFitsCommentesUplaod = (Label)e.Row.FindControl("lblFitsCommentesUplaod");
            Label lblprodtar = (Label)e.Row.FindControl("lblprodtar");
            Label lblHandOverTargetDate = (Label)e.Row.FindControl("lblHandOverTargetDate");
            Label lblPatternReadyTargetDate = (Label)e.Row.FindControl("lblPatternReadyTargetDate");
            Label lblSamplesentTargetDate = (Label)e.Row.FindControl("lblSamplesentTargetDate");
            Label lblFitsCommentesUplaodTargetDate = (Label)e.Row.FindControl("lblFitsCommentesUplaodTargetDate");
            Label lblCADMaster = (Label)e.Row.FindControl("lblCADMaster");

            if (od.IsShiped == true)
            {
                tdProdFile.Style.Add("background-color", "#F9F9FA");
                lblProdFile.Style.Add("color", "#807F80");
            }
            else
            {
                if (od.ProductionFileTarget.Date >= DateTime.Now.Date)
                {

                    if (txtProductionFileDate.Text == "")
                    {
                        lblProdFile.Style.Add("color", "Gray");
                    }
                }
                else
                {
                    if (txtProductionFileDate.Text == "")
                    {
                        tdProdFile.Style.Add("background-color", "#FFFF96");
                        lblProdFile.Style.Add("color", "#FF3300");
                    }
                }
            }

            //------------------------------Handover---------------------------
            if (od.IsShiped == true)
            {
                tdHandover.Style.Add("background-color", "#F9F9FA");
                lblHandover.Style.Add("color", "#807F80");
            }
            else
            {
                if (od.HandOverTargetDate.Date >= DateTime.Now.Date)
                {

                    if (txHandoverActual.Text == "")
                    {
                        lblHandover.Style.Add("color", "Gray");
                    }
                }
                else
                {
                    if (txHandoverActual.Text == "")
                    {
                        tdHandover.Style.Add("background-color", "#FFFF96");
                        lblHandover.Style.Add("color", "#FF3300");
                    }
                }
            }
            if (od.CADMaster != string.Empty)
            {
                string[] CadMasterArr = od.CADMaster.Split(' ');

                lblCADMaster.Text = "(" + CadMasterArr[0].ToString() + ")";
            }


            //-----------------------------------------------------------------

            if (TextBox2 != null)
            {
                if (od.FitsProdFileRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //TextBox2.ForeColor = System.Drawing.Color.Gray;
                        lblProductionFileDate.ForeColor = System.Drawing.Color.Gray;
                        lblprodtar.ForeColor = System.Drawing.Color.Gray;
                        tdProdFile.Style.Add("background-color", "#F9F9FA");
                        lblProdFile.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        if (TextBox2.Text != "" && lblProductionFileDate.Text != "")
                        {
                            //TextBox2.ForeColor = System.Drawing.Color.Gray;
                            lblProductionFileDate.ForeColor = System.Drawing.Color.Gray;
                            lblprodtar.ForeColor = System.Drawing.Color.Gray;

                            // tdProdFile.Style.Add("background-color", "#FFFFFF");
                            lblProdFile.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            //TextBox2.ForeColor = System.Drawing.Color.Black;
                            lblProductionFileDate.ForeColor = System.Drawing.Color.Black;
                            lblprodtar.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }
                else
                {
                    //  tdProdFile.Style.Add("background-color", "#FFFFFF");
                }
            }
            //if (TextBox4 != null)
            //{
            //    if (od.FitsProdFileRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            //TextBox2.ForeColor = System.Drawing.Color.Gray;
            //           // lblProductionFileDate.ForeColor = System.Drawing.Color.Gray;
            //            lblPPSampleTarget.ForeColor = System.Drawing.Color.Gray;
            //           // tdPPSample.Style.Add("background-color", "#F9F9FA");
            //           // lblSample.ForeColor = System.Drawing.Color.Gray;
            //        }
            //        else
            //        {
            //            //if (TextBox4.Text != "")
            //            //{
            //            //    //TextBox2.ForeColor = System.Drawing.Color.Gray;
            //            //  //  lblProductionFileDate.ForeColor = System.Drawing.Color.Gray;
            //            //    lblPPSampleTarget.ForeColor = System.Drawing.Color.Gray;

            //            //    // tdProdFile.Style.Add("background-color", "#FFFFFF");
            //            //   // lblSample.ForeColor = System.Drawing.Color.Gray;
            //            //}
            //            //else
            //            //{
            //            //    //TextBox2.ForeColor = System.Drawing.Color.Black;
            //            //    lblPPSampleTarget.ForeColor = System.Drawing.Color.Black;
            //            //  //  lblSample.ForeColor = System.Drawing.Color.Black;
            //            //}
            //        }
            //    }
            //    else
            //    {
            //        //  tdProdFile.Style.Add("background-color", "#FFFFFF");
            //    }
            //}

            //-------------------------------HandOver------------------------
            if (txtHanoverETA != null)
            {
                if (od.FitsProdFileRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //TextBox2.ForeColor = System.Drawing.Color.Gray;
                        txHandoverActual.ForeColor = System.Drawing.Color.Gray;
                        lblHandOverTargetDate.ForeColor = System.Drawing.Color.Gray;
                        tdHandover.Style.Add("background-color", "#F9F9FA");
                        lblHandover.ForeColor = System.Drawing.Color.Gray;
                        if (txHandoverActual.Text != "")
                        {
                            txtHanoverETA.Text = txHandoverActual.Text;
                        }
                    }
                    else
                    {
                        if (txHandoverActual.Text != "")
                        {
                            txHandoverActual.ForeColor = System.Drawing.Color.Gray;
                            lblHandOverTargetDate.ForeColor = System.Drawing.Color.Gray;
                            lblHandover.ForeColor = System.Drawing.Color.Gray;
                            txtHanoverETA.Text = txHandoverActual.Text;
                        }
                        else
                        {
                            txHandoverActual.ForeColor = System.Drawing.Color.Black;
                            lblHandOverTargetDate.ForeColor = System.Drawing.Color.Black;

                        }
                        //if (txHandoverActual.Text == "")
                        //{
                        //    HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
                        //    apprShow.Attributes.Add("class", "yellow-back");
                        //}
                    }
                }
                else
                {
                    //  tdProdFile.Style.Add("background-color", "#FFFFFF");
                }
            }
            //-------------------------------end-----------------------------
            if (od.HandOverActualDate.Date > od.PatternReadyActualDate.Date)
            {
                txtPatternReadyActualDate.Text = "";
                txtSampleSentActualDate.Text = "";
                txtFitsCommentesUplaodActualDate.Text = "";
                //txtPatternReadyETADate.Text = "";
                //txtSampleSentETA.Text = "";
                //txtFitsCommentesUplaodETADate.Text = "";
                HtmlTableRow apprShow1 = (HtmlTableRow)e.Row.FindControl("apprShow1");
                apprShow1.Attributes.Add("class", "yellow-back");
            }
            if (od.PatternReadyActualDate.Date > od.SampleSentActualDate.Date)
            {
                txtSampleSentActualDate.Text = "";
                txtFitsCommentesUplaodActualDate.Text = "";
                //txtSampleSentETA.Text = "";
                //txtFitsCommentesUplaodETADate.Text = "";
                HtmlTableRow apprShow2 = (HtmlTableRow)e.Row.FindControl("apprShow2");
                apprShow2.Attributes.Add("class", "yellow-back");
            }
            if (od.SampleSentActualDate.Date > od.FitsCommentesActualDate.Date)
            {

                txtFitsCommentesUplaodActualDate.Text = "";
                //txtFitsCommentesUplaodETADate.Text = "";
                HtmlTableRow apprShow3 = (HtmlTableRow)e.Row.FindControl("apprShow3");
                apprShow3.Attributes.Add("class", "yellow-back");
            }
            if (txtFitsCommentesUplaodActualDate.Text != "" && txHandoverActual.Text == "")
            {
                HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
                apprShow.Attributes.Add("class", "yellow-back");

            }
            //-------------------------------Pattern Ready------------------------
            if (txtPatternReadyETADate != null)
            {
                if (od.FitsProdFileRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //TextBox2.ForeColor = System.Drawing.Color.Gray;
                        txtPatternReadyActualDate.ForeColor = System.Drawing.Color.Gray;
                        lblPatternReadyTargetDate.ForeColor = System.Drawing.Color.Gray;
                        tdPatternReady.Style.Add("background-color", "#F9F9FA");
                        lblPatternReady.ForeColor = System.Drawing.Color.Gray;
                        if (txtPatternReadyActualDate.Text != "")
                        {
                            txtPatternReadyETADate.Text = txtPatternReadyActualDate.Text;
                        }
                    }
                    else
                    {
                        if (txtPatternReadyActualDate.Text != "")
                        {
                            txtPatternReadyActualDate.ForeColor = System.Drawing.Color.Gray;
                            lblPatternReadyTargetDate.ForeColor = System.Drawing.Color.Gray;
                            lblPatternReady.ForeColor = System.Drawing.Color.Gray;
                            txtPatternReadyETADate.Text = txtPatternReadyActualDate.Text;
                        }
                        else
                        {
                            //TextBox2.ForeColor = System.Drawing.Color.Black;
                            txtPatternReadyActualDate.ForeColor = System.Drawing.Color.Black;
                            lblPatternReadyTargetDate.ForeColor = System.Drawing.Color.Black;
                        }
                        //if (txtPatternReadyActualDate.Text == "")
                        //{
                        //    HtmlTableRow apprShow1 = (HtmlTableRow)e.Row.FindControl("apprShow1");
                        //    apprShow1.Attributes.Add("class", "yellow-back");
                        //}
                    }
                }
                else
                {
                    //  tdProdFile.Style.Add("background-color", "#FFFFFF");
                }
            }


            //-------------------------------end-----------------------------

            //-------------------------------Sample sent------------------------
            if (txtSampleSentETA != null)
            {
                if (od.FitsProdFileRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //TextBox2.ForeColor = System.Drawing.Color.Gray;
                        txtSampleSentActualDate.ForeColor = System.Drawing.Color.Gray;
                        lblSamplesentTargetDate.ForeColor = System.Drawing.Color.Gray;
                        tdSampleSent.Style.Add("background-color", "#F9F9FA");
                        lblSamplesent.ForeColor = System.Drawing.Color.Gray;
                        if (txtSampleSentActualDate.Text != "")
                        {
                            txtSampleSentETA.Text = txtSampleSentActualDate.Text;
                        }
                    }
                    else
                    {
                        if (txtSampleSentActualDate.Text != "")
                        {
                            txtSampleSentActualDate.ForeColor = System.Drawing.Color.Gray;
                            lblSamplesentTargetDate.ForeColor = System.Drawing.Color.Gray;
                            lblSamplesent.ForeColor = System.Drawing.Color.Gray;
                            txtSampleSentETA.Text = txtSampleSentActualDate.Text;
                        }
                        else
                        {
                            txtSampleSentActualDate.ForeColor = System.Drawing.Color.Black;
                            lblSamplesentTargetDate.ForeColor = System.Drawing.Color.Black;
                        }
                        //if (txtSampleSentActualDate.Text == "")
                        //{
                        //    HtmlTableRow apprShow2 = (HtmlTableRow)e.Row.FindControl("apprShow2");
                        //    apprShow2.Attributes.Add("class", "yellow-back");
                        //}
                    }
                }
                else
                {
                    //  tdProdFile.Style.Add("background-color", "#FFFFFF");
                }
            }


            //-------------------------------end-----------------------------

            //-------------------------------Fits Commentes Uplaod------------------------

            if (txtFitsCommentesUplaodETADate != null)
            {
                if (od.FitsProdFileRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //TextBox2.ForeColor = System.Drawing.Color.Gray;
                        txtFitsCommentesUplaodActualDate.ForeColor = System.Drawing.Color.Gray;
                        lblFitsCommentesUplaodTargetDate.ForeColor = System.Drawing.Color.Gray;
                        tdFitsCommentesUplaod.Style.Add("background-color", "#F9F9FA");
                        lblFitsCommentesUplaod.ForeColor = System.Drawing.Color.Gray;
                        if (txtFitsCommentesUplaodActualDate.Text != "")
                        {
                            txtFitsCommentesUplaodETADate.Text = txtFitsCommentesUplaodActualDate.Text;
                        }
                    }
                    else
                    {
                        if (txtFitsCommentesUplaodActualDate.Text != "")
                        {
                            txtFitsCommentesUplaodActualDate.ForeColor = System.Drawing.Color.Gray;
                            lblFitsCommentesUplaodTargetDate.ForeColor = System.Drawing.Color.Gray;
                            lblFitsCommentesUplaod.ForeColor = System.Drawing.Color.Gray;
                            txtFitsCommentesUplaodETADate.Text = txtFitsCommentesUplaodActualDate.Text;
                        }
                        else
                        {
                            txtFitsCommentesUplaodActualDate.ForeColor = System.Drawing.Color.Black;
                            lblFitsCommentesUplaodTargetDate.ForeColor = System.Drawing.Color.Black;
                        }
                        //if (txtFitsCommentesUplaodActualDate.Text == "")
                        //{
                        //    HtmlTableRow apprShow3 = (HtmlTableRow)e.Row.FindControl("apprShow3");
                        //    apprShow3.Attributes.Add("class", "yellow-back");
                        //}
                    }
                }
                else
                {
                    //  tdProdFile.Style.Add("background-color", "#FFFFFF");
                }
            }



            //-------------------------------------end------------------------------------------------

            HtmlTableCell tdHoPPM = (HtmlTableCell)e.Row.FindControl("tdHoPPM");
            Label lblHOPPM = (Label)e.Row.FindControl("lblHOPPM");
            Label lblHOPPMActual = (Label)e.Row.FindControl("lblHOPPMActual");
            Label lblHOPPMTarget = (Label)e.Row.FindControl("lblHOPPMTarget");


            if (od.IsShiped == true)
            {
                tdHoPPM.Style.Add("background-color", "#F9F9FA");
                lblHOPPM.Style.Add("color", "#807F80");
            }
            else
            {
                if (od.HOPPMTargetETA.Date >= DateTime.Now.Date)
                {

                    if (lblHOPPMActual.Text == "")
                    {
                        lblHOPPM.Style.Add("color", "Gray");
                    }
                }
                else
                {

                    if (lblHOPPMActual.Text == "")
                    {
                        tdHoPPM.Style.Add("background-color", "#FDFD96"); //update color code feb-22
                        lblHOPPM.Style.Add("color", "#FF3300");
                    }
                }
            }


            if (txtETAHOPPM != null)
            {
                if (od.FitsHOPPMRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        lblHOPPMActual.ForeColor = System.Drawing.Color.Gray;
                        lblHOPPMTarget.ForeColor = System.Drawing.Color.Gray;
                        tdHoPPM.Style.Add("background-color", "#F9F9FA");
                        lblHOPPM.ForeColor = System.Drawing.Color.Gray;
                        if (lblHOPPMActual.Text != "")
                        {
                            txtETAHOPPM.Text = lblHOPPMActual.Text;
                        }
                    }
                    else
                    {
                        if (lblHOPPMActual.Text != "")
                        {
                            lblHOPPMActual.ForeColor = System.Drawing.Color.Gray;
                            lblHOPPMTarget.ForeColor = System.Drawing.Color.Gray;
                            lblHOPPM.ForeColor = System.Drawing.Color.Gray;
                            txtETAHOPPM.Text = lblHOPPMActual.Text;
                        }
                        else
                        {
                            lblHOPPMActual.ForeColor = System.Drawing.Color.Black;
                            lblHOPPMTarget.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }
                else
                {
                    //  tdHoPPM.Style.Add("background-color", "#FFFFFF");
                }
            }
            CheckBox chkonhold = (CheckBox)e.Row.FindControl("chkonhold");
            Label lblholdstatus = (Label)e.Row.FindControl("lblholdstatus");
            Label lblOrdDate = (Label)e.Row.FindControl("lblOrdDate");
            

            if (IsShipped)
            {
              lblholdstatus.CssClass = "MOProdSecGray";
              chkonhold.Enabled = false;
            }
            if (chkonhold.Checked)
            {
              txtCuttingSheetDate.ReadOnly = true;
              txtCuttingSheetDate.CssClass = "MOProdSecGray";
              txtCuttingSheetDate.Enabled = false;
              txtCuttingSheetDate.ToolTip = "you cannot change date because this contract on Hold";
                /*updated code by bharat 22-jan-19*/
               e.Row.Cells[0].CssClass = "onholdbgorenge1td" +" " + "newcss2";
               e.Row.Cells[0].Style.Add("background-color", "#ffcb82!important");
               e.Row.Cells[0].Style.Add(" border-color", " #f1c082 !important;");
               e.Row.Cells[1].CssClass = "onholdbgorenge2td"; 
               e.Row.Cells[1].Style.Add("background-color", "#ffcb82!important");
               e.Row.Cells[1].Style.Add(" border-color", "#f7c27f !important;");
               e.Row.Cells[2].Style.Add(" border-color", "#f7c27f !important;");
               e.Row.Cells[3].Style.Add(" border-color", "#f7c27f !important;");
               e.Row.Cells[4].Style.Add(" border-color", "#f7c27f !important;");
               e.Row.Cells[2].CssClass = "onholdbgorenge2td";
               e.Row.Cells[2].Style.Add("background-color", "#ffcb82!important");
               e.Row.Cells[3].CssClass = "newcss2" + " " + "onholdbgorenge3td";
               e.Row.Cells[3].Style.Add("background-color", "#ffcb82!important");
               e.Row.Cells[4].CssClass = "newcss2" + " " + "onholdbgorenge3td";
               e.Row.Cells[4].Style.Add("background-color", "#ffcb82!important");
            /**end*/
            }
            HtmlTableCell tdTopSent = (HtmlTableCell)e.Row.FindControl("tdTopSent");
            Label lblTopSent = (Label)e.Row.FindControl("lblTopSent");
            Label lblTopSendTarget = (Label)e.Row.FindControl("lblTopSendTarget");
            Label Label10 = (Label)e.Row.FindControl("Label10");
            // Added By Ravi kumar for Final Pass on 30/12/16
            HyperLink hlnkQaPrevStatus = (HyperLink)e.Row.FindControl("hlnkQaPrevStatus");
            Label lblInspection = (Label)e.Row.FindControl("lblInspection");
            if (od.QualityControl_Prev_Status == "")
            {
                lblInspection.Visible = true;
            }
            //if (od.QualityControl_Prev_Status="")
            //if (lblInspection.Text == " ")
            //{
            hlnkQaPrevStatus.NavigateUrl = "~/Internal/Merchandising/QC.aspx?OrderId=" + od.OrderID + "&OrderDetailID=" + od.OrderDetailID + "&InspectionIDM=3";
            hlnkQaPrevStatus.ToolTip = "Quality Assurance Form";
            //}
            // End adding By Ravi kumar
            if (od.IsShiped == true)
            {
                tdTopSent.Style.Add("background-color", "#F9F9FA");
                lblTopSent.Style.Add("color", "#807F80");
            }
            else
            {
                if (od.ParentOrder.InlinePPMOrderContract.TopSentTarget.Date >= DateTime.Now.Date)
                {

                    if (lblTopSendTarget.Text == "")
                    {
                        //   tdTopSent.Style.Add("background-color", "#FFFFFF");
                        lblTopSent.Style.Add("color", "Gray");
                    }
                }
                else
                {

                    if (lblTopSendTarget.Text == "")
                    {
                        tdTopSent.Style.Add("background-color", "#FFFF96");
                        lblTopSent.Style.Add("color", "#FF3300");
                    }
                }
            }


            if (lblTOPETA != null)
            {
                if (od.FitsTOPSentRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        //lblTOPETA.ForeColor = System.Drawing.Color.Gray;
                        lblTopSendTarget.ForeColor = System.Drawing.Color.Gray;
                        Label10.ForeColor = System.Drawing.Color.Gray;
                        tdTopSent.Style.Add("background-color", "#F9F9FA");
                        lblTopSent.ForeColor = System.Drawing.Color.Gray;
                        if (lblTopSendTarget.Text != "")
                        {
                            lblTOPETA.Text = lblTopSendTarget.Text;
                        }
                    }
                    else
                    {
                        if (lblTopSendTarget.Text != "")
                        {
                            lblTopSendTarget.ForeColor = System.Drawing.Color.Gray;
                            Label10.ForeColor = System.Drawing.Color.Gray;
                            lblTopSent.ForeColor = System.Drawing.Color.Gray;
                            lblTOPETA.Text = lblTopSendTarget.Text;
                        }
                        else
                        {
                            lblTopSendTarget.ForeColor = System.Drawing.Color.Black;
                            Label10.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                }
                else
                {
                    //  tdTopSent.Style.Add("background-color", "#FFFFFF");
                }
            }
            //lblTopSent.Style.Add("font-weight", "bold");
            // End Work For Color change of Top Sent date By Ravi kumar
        }

        public void MOPaging(int StartIndex)
        {

            if (this.searchText != null)
                hdnfld_SearchText.Value = this.searchText;
            if (hdnfld_SearchText.Value != null)
                this.searchText = hdnfld_SearchText.Value;

            if (this.Years != null)
                hdnfld_Years.Value = this.Years;
            if (hdnfld_Years.Value != null)
                this.Years = hdnfld_Years.Value;

            if (this.FromDate > Convert.ToDateTime("1990-01-01") || this.FromDate == Convert.ToDateTime("01-01-1753"))
                hdnfld_FromDate.Value = this.FromDate.ToString();
            if (hdnfld_FromDate.Value != "")
                this.FromDate = Convert.ToDateTime(hdnfld_FromDate.Value);

            if (this.ToDate > Convert.ToDateTime("1990-01-01") || this.ToDate == Convert.ToDateTime("01-01-1753"))
                hdnfld_ToDate.Value = this.ToDate.ToString();
            if (hdnfld_ToDate.Value != "")
                this.ToDate = Convert.ToDateTime(hdnfld_ToDate.Value);

            if (this.ClientId != 0)
                hdnfld_ClientId.Value = this.ClientId.ToString();

            if (hdnfld_ClientId.Value != null)
                this.ClientId = Convert.ToInt32(hdnfld_ClientId.Value);

            if (this.AM != 0)
                hdnfld_AM.Value = this.AM.ToString();

            if (hdnfld_AM.Value != null)
                this.AM = Convert.ToInt32(hdnfld_AM.Value);

            if (this.DateType != 0)
                hdnfld_DateType.Value = this.DateType.ToString();
            if (hdnfld_DateType.Value != null)
                this.DateType = Convert.ToInt32(hdnfld_DateType.Value);

            //if (this.StatusMode != 0)
            //    hdnfld_StatusMode.Value = this.StatusMode.ToString();
            //if (!string.IsNullOrEmpty(hdnfld_StatusMode.Value))
            //    this.StatusMode = Convert.ToInt32(hdnfld_StatusMode.Value);

            if (this.StatusMode_ForIntial != 0)
                hdnfld_StatusMode.Value = this.StatusMode_ForIntial.ToString();
            if (!string.IsNullOrEmpty(hdnfld_StatusMode.Value))
                this.StatusMode_ForIntial = Convert.ToDouble(hdnfld_StatusMode.Value);

            //if (this.StatusModeSequence != 0)
            //    hdnfld_StatusModeSequence.Value = this.StatusModeSequence.ToString();
            //if (!string.IsNullOrEmpty(hdnfld_StatusModeSequence.Value))
            //    this.StatusModeSequence = Convert.ToInt32(hdnfld_StatusModeSequence.Value);

            if (this.StatusMode_ForDouble != 0)
                hdnfld_StatusModeSequence.Value = this.StatusMode_ForDouble.ToString();
            if (!string.IsNullOrEmpty(hdnfld_StatusModeSequence.Value))
                this.StatusMode_ForDouble = Convert.ToDouble(hdnfld_StatusModeSequence.Value);

            if (this.OrderBy1 != 0)
                hdnfld_OrderBy1.Value = this.OrderBy1.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy1.Value))
                this.OrderBy1 = Convert.ToInt32(hdnfld_OrderBy1.Value);

            if (this.OrderBy2 != 0)
                hdnfld_OrderBy2.Value = this.OrderBy2.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy2.Value))
                this.OrderBy2 = Convert.ToInt32(hdnfld_OrderBy2.Value);

            if (this.OrderBy3 != 0)
                hdnfld_OrderBy3.Value = this.OrderBy3.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy3.Value))
                this.OrderBy3 = Convert.ToInt32(hdnfld_OrderBy3.Value);

            if (this.OrderBy4 != 0)
                hdnfld_OrderBy4.Value = this.OrderBy4.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy4.Value))
                this.OrderBy4 = Convert.ToInt32(hdnfld_OrderBy4.Value);

            if (this.BuyingHouseId != 0)
                hdnfld_BuyingHouseId.Value = this.BuyingHouseId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_BuyingHouseId.Value))
                this.BuyingHouseId = Convert.ToInt32(hdnfld_BuyingHouseId.Value);

            if (this.UnitId != 0)
                hdnfld_UnitId.Value = this.UnitId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_UnitId.Value))
                this.UnitId = Convert.ToInt32(hdnfld_UnitId.Value);

            if (this.OutHouse != 0)
                hdnfld_OutHouseId.Value = this.OutHouse.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OutHouseId.Value))
                this.OutHouse = Convert.ToInt32(hdnfld_OutHouseId.Value);


            if (this.desigId != 0)
                hdnfld_desigId.Value = this.desigId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_desigId.Value))
                this.desigId = Convert.ToInt32(hdnfld_desigId.Value);

            if (this.DeptId != 0)
                hdnfld_DeptId.Value = this.DeptId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_DeptId.Value))
                this.DeptId = Convert.ToInt32(hdnfld_DeptId.Value);

            if (this.SalesView != 0)
                hdnfld_SalesView.Value = this.SalesView.ToString();
            if (!string.IsNullOrEmpty(hdnfld_SalesView.Value))
                this.SalesView = Convert.ToInt32(hdnfld_SalesView.Value);

            if (this.ClientDeptId != 0)
                hdnfld_ClientDeptId.Value = this.ClientDeptId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_ClientDeptId.Value))
                this.ClientDeptId = Convert.ToInt32(hdnfld_ClientDeptId.Value);
            
            //Add by Surendra2 on 2018-11-21.
            if (this.ClientParentDeptId != 0)
                hdnfld_ParrentDeptId.Value = this.ClientParentDeptId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_ParrentDeptId.Value))
                this.ClientParentDeptId = Convert.ToInt32(hdnfld_ParrentDeptId.Value);

            // for OrderType
            if (this.OrderTypes != 0)
                hdnfld_OrderType.Value = this.OrderTypes.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderType.Value))
                this.OrderTypes = Convert.ToInt32(hdnfld_OrderType.Value);
            // end
            //Added By Ravi kumar for UnShipped data on 23-6-17          

            if (this.IsUnShipped != 0)
            {
                hdnIsUnShipped.Value = this.IsUnShipped.ToString();
                this.IsUnShipped = 0;
            }

            if (hdnIsUnShipped.Value != "")
                this.IsUnShipped = Convert.ToInt32(hdnIsUnShipped.Value);
            // end on 23-6-17

            string strUserID = "";
            string stringIds = Request.QueryString["winopn"];
            if (stringIds == "a")
            {
                strUserID = (string)Session["OrderDetailIds" + ApplicationHelper.LoggedInUser.UserData.UserID.ToString()];
            }
            else
            {
                strUserID = "";
            }
            if (Session["btn_check"] != null)
            {
                int i = (int)Session["btn_check"];
                if (i == 1)
                {
                    if (Session["Flag"] != null)
                    {
                        bool flag = Convert.ToBoolean(Session["Flag"]);
                        if (flag == true)
                        {
                            string strSeaVal = "";
                            strSeaVal = Request.QueryString["SeaVal"];
                            if (strSeaVal == "Yes")
                            {
                                if (Session["SearchValues"] != null)
                                {

                                    DataTable dtTemp = (DataTable)Session["SearchValues"];
                                    this.searchText = dtTemp.Rows[0]["dcsearchText"].ToString();
                                    this.FromDate = Convert.ToDateTime(dtTemp.Rows[0]["dcFromDate"]);
                                    this.ToDate = Convert.ToDateTime(dtTemp.Rows[0]["dcToDate"]);
                                    // Add By Ravi kumar on Date 7-oct-2014
                                    this.Years = dtTemp.Rows[0]["dcYear"].ToString();
                                    //this.FromWeek = Convert.ToInt32(dtTemp.Rows[0]["dcFromWeek"]);
                                    //this.ToWeek = Convert.ToInt32(dtTemp.Rows[0]["dcToWeek"]);
                                    // end
                                    this.ClientId = Convert.ToInt32(dtTemp.Rows[0]["dcClientId"]);
                                    this.AM = Convert.ToInt32(dtTemp.Rows[0]["dcAM"]);
                                    this.ClientParentDeptId = Convert.ToInt32(dtTemp.Rows[0]["dcClientParentDeptId"]);
                                    this.ClientDeptId = Convert.ToInt32(dtTemp.Rows[0]["dcClientDeptId"]);
                                    this.DateType = Convert.ToInt32(dtTemp.Rows[0]["dcDateType"]);
                                    //this.StatusMode = Convert.ToInt32(dtTemp.Rows[0]["dcStatusMode"]);
                                    this.StatusMode_ForIntial = Convert.ToDouble(dtTemp.Rows[0]["dcStatusMode"]);
                                    //this.StatusModeSequence = Convert.ToInt32(dtTemp.Rows[0]["dcStatusModeSequence"]);
                                    this.StatusMode_ForDouble = Convert.ToDouble(dtTemp.Rows[0]["dcStatusModeSequence"]);
                                    this.OrderBy1 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy1"]);
                                    this.OrderBy2 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy2"]);
                                    this.OrderBy3 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy3"]);
                                    this.OrderBy4 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy4"]);
                                    this.BuyingHouseId = Convert.ToInt32(dtTemp.Rows[0]["dcBuyingHouseId"]);
                                    this.OrderTypes = Convert.ToInt32(dtTemp.Rows[0]["dcordertypesId"]);
                                    this.IsUnShipped = Convert.ToInt32(dtTemp.Rows[0]["dcIsUnShipped"]);

                                }
                                // Session["SearchValues"] = null;
                                // Session["Flag"] = false;
                            }
                        }
                    }
                }
            }

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;


            DataTable dtSearchValue = new DataTable();

            DataColumn dcsearchText = new DataColumn("dcsearchText", typeof(string));
            dtSearchValue.Columns.Add(dcsearchText);

            DataColumn dcYear = new DataColumn("dcYear", typeof(string));
            dtSearchValue.Columns.Add(dcYear);


            DataColumn dcFromDate = new DataColumn("dcFromDate", typeof(DateTime));
            dtSearchValue.Columns.Add(dcFromDate);

            DataColumn dcToDate = new DataColumn("dcToDate", typeof(DateTime));
            dtSearchValue.Columns.Add(dcToDate);

            DataColumn dcClientId = new DataColumn("dcClientId", typeof(int));
            dtSearchValue.Columns.Add(dcClientId);

            DataColumn dcAM = new DataColumn("dcAM", typeof(int));
            dtSearchValue.Columns.Add(dcAM);

            DataColumn dcClientParentDeptId = new DataColumn("dcClientParentDeptId", typeof(int));
            dtSearchValue.Columns.Add(dcClientParentDeptId);

            DataColumn dcClientDeptId = new DataColumn("dcClientDeptId", typeof(int));
            dtSearchValue.Columns.Add(dcClientDeptId);

            DataColumn dcDateType = new DataColumn("dcDateType", typeof(int));
            dtSearchValue.Columns.Add(dcDateType);

            DataColumn dcUserId = new DataColumn("dcUserId", typeof(int));
            dtSearchValue.Columns.Add(dcUserId);

            DataColumn dcStatusMode = new DataColumn("dcStatusMode", typeof(int));
            dtSearchValue.Columns.Add(dcStatusMode);

            DataColumn dcStatusModeSequence = new DataColumn("dcStatusModeSequence", typeof(int));
            dtSearchValue.Columns.Add(dcStatusModeSequence);

            DataColumn dcOrderBy1 = new DataColumn("dcOrderBy1", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy1);

            DataColumn dcOrderBy2 = new DataColumn("dcOrderBy2", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy2);

            DataColumn dcOrderBy3 = new DataColumn("dcOrderBy3", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy3);

            DataColumn dcOrderBy4 = new DataColumn("dcOrderBy4", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy4);

            //DataColumn dcOrderBy5 = new DataColumn("dcOrderBy5", typeof(int));
            //dtSearchValue.Columns.Add(dcOrderBy5);


            DataColumn dcOrderDetailIds = new DataColumn("dcstrUserID", typeof(string));
            dtSearchValue.Columns.Add(dcOrderDetailIds);

            DataColumn dcBuyingHouseId = new DataColumn("dcBuyingHouseId", typeof(int));
            dtSearchValue.Columns.Add(dcBuyingHouseId);

            DataColumn dcOrderTypeId = new DataColumn("dcordertypesId", typeof(int));
            dtSearchValue.Columns.Add(dcOrderTypeId);

            DataColumn dcIsUnShipped = new DataColumn("dcIsUnShipped", typeof(string));
            dtSearchValue.Columns.Add(dcIsUnShipped);

            Session["SearchValue"] = this.searchText;

            //Gajendra 22-04-2016
            if (this.DelayStatusId != 0)
                hdnfld_DelayStatusId.Value = this.DelayStatusId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_DelayStatusId.Value))
                this.DelayStatusId = Convert.ToInt32(hdnfld_DelayStatusId.Value);

            DataRow dr;
            dr = dtSearchValue.NewRow();
            dtSearchValue.Rows.Add(dr);
            dtSearchValue.Rows[0][dcsearchText] = this.searchText;
            dtSearchValue.Rows[0][dcYear] = this.Years;
            dtSearchValue.Rows[0][dcFromDate] = this.FromDate;
            dtSearchValue.Rows[0][dcToDate] = this.ToDate;
            dtSearchValue.Rows[0][dcClientId] = this.ClientId;
            dtSearchValue.Rows[0][dcAM] = this.AM;
            dtSearchValue.Rows[0][dcClientParentDeptId] = this.ClientParentDeptId;
            dtSearchValue.Rows[0][dcClientDeptId] = this.ClientDeptId;
            dtSearchValue.Rows[0][dcDateType] = this.DateType;
            dtSearchValue.Rows[0][dcUserId] = UserId;
            //dtSearchValue.Rows[0][dcStatusMode] = this.StatusMode;
            dtSearchValue.Rows[0][dcStatusMode] = this.StatusMode_ForIntial;
            //dtSearchValue.Rows[0][dcStatusModeSequence] = this.StatusModeSequence;
            dtSearchValue.Rows[0][dcStatusModeSequence] = this.StatusMode_ForDouble;
            dtSearchValue.Rows[0][dcOrderBy1] = this.OrderBy1;
            dtSearchValue.Rows[0][dcOrderBy2] = this.OrderBy2;
            dtSearchValue.Rows[0][dcOrderBy3] = this.OrderBy3;
            dtSearchValue.Rows[0][dcOrderBy4] = this.OrderBy4;
            //dtSearchValue.Rows[0][dcOrderBy5] = this.OrderBy5;
            dtSearchValue.Rows[0][dcOrderDetailIds] = strUserID;
            dtSearchValue.Rows[0][dcBuyingHouseId] = this.BuyingHouseId;
            dtSearchValue.Rows[0][dcOrderTypeId] = this.OrderTypes;
            dtSearchValue.Rows[0][dcIsUnShipped] = this.IsUnShipped;

            DataTable dt = dtSearchValue;
            Session["SearchValues"] = dt;
            Session["btn_check"] = 1;
            //Added By ashish on 19/2/2014 
            this.desigId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.Designation);
            this.DeptId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);
            //if (Convert.ToInt32(Session["Client"]) == 1)
            //{
            //    this.DeptId = 5;
            //    UserId = 15;
            //}
            //string DelayOrderDetailIds = "";
            int iUserId = 0;

            WorkflowController objWorkflowController = new WorkflowController();
            if (this.DelayStatusId > 0)
            {
                string SessionId = Session.SessionID;

                if (ApplicationHelper.LoggedInUser.UserData != null)


                    iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                UserDetails usd = new UserDetails();


                SessionInfo sessionInfo = new SessionInfo();

                iKandi.Common.User user = null;
                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                bool flag = objWorkflowController.InsertDelayForMO(SessionId, DelayStatusId, iUserId);

                DelayOrderDetailIds = objWorkflowController.GetDelayOrderDetailIds(Session.SessionID);

            }
            else if (OutHouseOrderDetailIds != null)
            {
                DelayOrderDetailIds = OutHouseOrderDetailIds;
            }

            if (TaskCompleteOrderDetailId > 0)
            {
                DelayOrderDetailIds = TaskCompleteOrderDetailId.ToString();
            }

            if (StyleNumber != null)
            {
                this.searchText = StyleNumber;
            }
            string str = objWorkflowController.InsertDelayCountForMO(Session.SessionID, 1);
            if (str != "" || DelayStatusId != 0 || !string.IsNullOrEmpty(DelayOrderDetailIds)) //Gajendra Paging
            {
                int TotalCount = 0;
                if (Session["PageIndex"] != null)
                {
                    StartIndex = PageIndex_Page;
                }
      
                List<MOOrderDetails> objOrderDetail = this.OrderControllerInstance.GetOrdersBasicInfo(this.searchText,"", this.Years, this.FromDate, this.ToDate, this.ClientId, this.DateType, UserId, this.StatusMode_ForIntial, this.StatusMode_ForDouble, this.OrderBy1, this.OrderBy2, this.OrderBy3, this.OrderBy4, strUserID, this.BuyingHouseId, this.UnitId, this.desigId, this.DeptId, this.SalesView, HttpContext.Current.Session.SessionID, this.ClientDeptId, DelayOrderDetailIds, this.OrderTypes, StartIndex, out TotalCount, this.AM, this.IsUnShipped, this.OutHouse,this.ClientParentDeptId, 10);
                Session["objOrderDetail"] = objOrderDetail as List<MOOrderDetails>;
                GridView1.DataSource = objOrderDetail;
                GridView1.DataBind();
                
                generatePager(TotalCount, 10, StartIndex);

            }
            //PermissionInfo(); 
        }
        public void MOPagingFromMainPage(int StartIndex)
        {

            if (this.searchText != null)
                hdnfld_SearchText.Value = this.searchText;
            if (hdnfld_SearchText.Value != null)
                this.searchText = hdnfld_SearchText.Value;

            if (this.Years != null)
                hdnfld_Years.Value = this.Years;
            if (hdnfld_SearchText.Value != null)
                this.Years = hdnfld_Years.Value;

            if (this.FromDate > Convert.ToDateTime("1990-01-01") || this.FromDate == Convert.ToDateTime("01-01-1753"))
                hdnfld_FromDate.Value = this.FromDate.ToString();
            if (hdnfld_FromDate.Value != "")
                this.FromDate = Convert.ToDateTime(hdnfld_FromDate.Value);

            if (this.ToDate > Convert.ToDateTime("1990-01-01") || this.ToDate == Convert.ToDateTime("01-01-1753"))
                hdnfld_ToDate.Value = this.ToDate.ToString();
            if (hdnfld_ToDate.Value != "")
                this.ToDate = Convert.ToDateTime(hdnfld_ToDate.Value);

            if (this.ClientId != 0)
                hdnfld_ClientId.Value = this.ClientId.ToString();
            if (hdnfld_ClientId.Value != null)
                this.ClientId = Convert.ToInt32(hdnfld_ClientId.Value);

            if (this.AM != 0)
                hdnfld_AM.Value = this.AM.ToString();
            if (hdnfld_AM.Value != null)
                this.AM = Convert.ToInt32(hdnfld_AM.Value);

            if (this.DateType != 0)
                hdnfld_DateType.Value = this.DateType.ToString();
            if (hdnfld_DateType.Value != null)
                this.DateType = Convert.ToInt32(hdnfld_DateType.Value);

            //if (this.StatusMode != 0)
            hdnfld_StatusMode.Value = this.StatusMode_ForIntial.ToString();
            if (!string.IsNullOrEmpty(hdnfld_StatusMode.Value))
                this.StatusMode_ForIntial = Convert.ToDouble(hdnfld_StatusMode.Value);

            //if (this.StatusModeSequence != 0)
            //    hdnfld_StatusModeSequence.Value = this.StatusModeSequence.ToString();
            //if (!string.IsNullOrEmpty(hdnfld_StatusModeSequence.Value))
            //    this.StatusModeSequence = Convert.ToInt32(hdnfld_StatusModeSequence.Value);

            if (this.StatusMode_ForDouble != 0)
                hdnfld_StatusModeSequence.Value = this.StatusMode_ForDouble.ToString();
            if (!string.IsNullOrEmpty(hdnfld_StatusModeSequence.Value))
                this.StatusMode_ForDouble = Convert.ToDouble(hdnfld_StatusModeSequence.Value);

            if (this.OrderBy1 != 0)
                hdnfld_OrderBy1.Value = this.OrderBy1.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy1.Value))
                this.OrderBy1 = Convert.ToInt32(hdnfld_OrderBy1.Value);

            if (this.OrderBy2 != 0)
                hdnfld_OrderBy2.Value = this.OrderBy2.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy2.Value))
                this.OrderBy2 = Convert.ToInt32(hdnfld_OrderBy2.Value);

            if (this.OrderBy3 != 0)
                hdnfld_OrderBy3.Value = this.OrderBy3.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy3.Value))
                this.OrderBy3 = Convert.ToInt32(hdnfld_OrderBy3.Value);

            if (this.OrderBy4 != 0)
                hdnfld_OrderBy4.Value = this.OrderBy4.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderBy4.Value))
                this.OrderBy4 = Convert.ToInt32(hdnfld_OrderBy4.Value);

            if (this.BuyingHouseId != -1)
                hdnfld_BuyingHouseId.Value = this.BuyingHouseId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_BuyingHouseId.Value))
                this.BuyingHouseId = Convert.ToInt32(hdnfld_BuyingHouseId.Value);

            if (this.UnitId != 0)
                hdnfld_UnitId.Value = this.UnitId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_UnitId.Value))
                this.UnitId = Convert.ToInt32(hdnfld_UnitId.Value);

            if (this.OutHouse != 0)
                hdnfld_OutHouseId.Value = this.OutHouse.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OutHouseId.Value))
                this.OutHouse = Convert.ToInt32(hdnfld_OutHouseId.Value);


            if (this.desigId != 0)
                hdnfld_desigId.Value = this.desigId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_desigId.Value))
                this.desigId = Convert.ToInt32(hdnfld_desigId.Value);

            if (this.ClientParentDeptId != 0)
                hdnfld_ParrentDeptId.Value = this.ClientParentDeptId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_ParrentDeptId.Value))
                this.ClientParentDeptId = Convert.ToInt32(hdnfld_ParrentDeptId.Value);


            if (this.DeptId != 0)
                hdnfld_DeptId.Value = this.DeptId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_DeptId.Value))
                this.DeptId = Convert.ToInt32(hdnfld_DeptId.Value);

            
            if (this.SalesView != 0)
                hdnfld_SalesView.Value = this.SalesView.ToString();
            if (!string.IsNullOrEmpty(hdnfld_SalesView.Value))
                this.SalesView = Convert.ToInt32(hdnfld_SalesView.Value);

            if (this.ClientDeptId != 0)
                hdnfld_ClientDeptId.Value = this.ClientDeptId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_ClientDeptId.Value))
                this.ClientDeptId = Convert.ToInt32(hdnfld_ClientDeptId.Value);
            // for OrderType
            //if (this.OrderTypes != 0)
            hdnfld_OrderType.Value = this.OrderTypes.ToString();
            if (!string.IsNullOrEmpty(hdnfld_OrderType.Value))
                this.OrderTypes = Convert.ToInt32(hdnfld_OrderType.Value);
            // end
            //Added By Ravi kumar for UnShipped data on 23-6-17            
            //if ((hdnIsUnShipped.Value != "")&&(hdnIsUnShipped.Value != "False"))
            //    this.IsUnShipped = Convert.ToBoolean(hdnIsUnShipped.Value);
            //else
            //    hdnIsUnShipped.Value = this.IsUnShipped.ToString();
            if (this.IsUnShipped != 0)
            {
                hdnIsUnShipped.Value = this.IsUnShipped.ToString();
                this.IsUnShipped = 0;
            }

            if (hdnIsUnShipped.Value != "")
                this.IsUnShipped = Convert.ToInt32(hdnIsUnShipped.Value);
            // end on 23-6-17

            string strUserID = "";
            string stringIds = Request.QueryString["winopn"];
            string DelayOrderDetailIds = "";
            if (stringIds == "a")
            {
                strUserID = (string)Session["OrderDetailIds" + ApplicationHelper.LoggedInUser.UserData.UserID.ToString()];
            }
            else
            {
                strUserID = "";
            }
            if (Session["btn_check"] != null)
            {
                int i = (int)Session["btn_check"];
                if (i == 1)
                {
                    if (Session["Flag"] != null)
                    {
                        bool flag = Convert.ToBoolean(Session["Flag"]);
                        if (flag == true)
                        {
                            string strSeaVal = "";
                            strSeaVal = Request.QueryString["SeaVal"];
                            if (strSeaVal == "Yes")
                            {
                                if (Session["SearchValues"] != null)
                                {

                                    DataTable dtTemp = (DataTable)Session["SearchValues"];
                                    this.searchText = dtTemp.Rows[0]["dcsearchText"].ToString();
                                    this.FromDate = Convert.ToDateTime(dtTemp.Rows[0]["dcFromDate"]);
                                    this.ToDate = Convert.ToDateTime(dtTemp.Rows[0]["dcToDate"]);
                                    // Add By Ravi kumar on Date 7-oct-2014
                                    this.Years = dtTemp.Rows[0]["dcYear"].ToString();
                                    //this.FromWeek = Convert.ToInt32(dtTemp.Rows[0]["dcFromWeek"]);
                                    //this.ToWeek = Convert.ToInt32(dtTemp.Rows[0]["dcToWeek"]);
                                    // end
                                    this.ClientId = Convert.ToInt32(dtTemp.Rows[0]["dcClientId"]);
                                    this.AM = Convert.ToInt32(dtTemp.Rows[0]["dcAM"]);
                                    this.ClientParentDeptId = Convert.ToInt32(dtTemp.Rows[0]["dcClientParentDeptId"]);
                                    this.ClientDeptId = Convert.ToInt32(dtTemp.Rows[0]["dcClientDeptId"]);
                                    this.DateType = Convert.ToInt32(dtTemp.Rows[0]["dcDateType"]);
                                    //this.StatusMode = Convert.ToInt32(dtTemp.Rows[0]["dcStatusMode"]);
                                    this.StatusMode_ForIntial = Convert.ToInt32(dtTemp.Rows[0]["dcStatusMode"]);
                                    //this.StatusModeSequence = Convert.ToInt32(dtTemp.Rows[0]["dcStatusModeSequence"]);
                                    this.StatusMode_ForDouble = Convert.ToDouble(dtTemp.Rows[0]["dcStatusModeSequence"]);
                                    this.OrderBy1 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy1"]);
                                    this.OrderBy2 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy2"]);
                                    this.OrderBy3 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy3"]);
                                    this.OrderBy4 = Convert.ToInt32(dtTemp.Rows[0]["dcOrderBy4"]);
                                    this.BuyingHouseId = Convert.ToInt32(dtTemp.Rows[0]["dcBuyingHouseId"]);
                                    this.OrderTypes = Convert.ToInt32(dtTemp.Rows[0]["dcordertypesId"]);
                                    this.IsUnShipped = Convert.ToInt32(dtTemp.Rows[0]["dcIsUnShipped"]);
                                }
                                // Session["SearchValues"] = null;
                                // Session["Flag"] = false;
                            }
                        }
                    }
                }
            }

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;


            DataTable dtSearchValue = new DataTable();

            DataColumn dcsearchText = new DataColumn("dcsearchText", typeof(string));
            dtSearchValue.Columns.Add(dcsearchText);

            DataColumn dcYear = new DataColumn("dcYear", typeof(string));
            dtSearchValue.Columns.Add(dcYear);


            DataColumn dcFromDate = new DataColumn("dcFromDate", typeof(DateTime));
            dtSearchValue.Columns.Add(dcFromDate);

            DataColumn dcToDate = new DataColumn("dcToDate", typeof(DateTime));
            dtSearchValue.Columns.Add(dcToDate);

            DataColumn dcClientId = new DataColumn("dcClientId", typeof(int));
            dtSearchValue.Columns.Add(dcClientId);

            DataColumn dcAM = new DataColumn("dcAM", typeof(int));
            dtSearchValue.Columns.Add(dcAM);

            DataColumn dcClientParentDeptId = new DataColumn("dcClientParentDeptId", typeof(int));
            dtSearchValue.Columns.Add(dcClientParentDeptId);

            DataColumn dcClientDeptId = new DataColumn("dcClientDeptId", typeof(int));
            dtSearchValue.Columns.Add(dcClientDeptId);

            DataColumn dcDateType = new DataColumn("dcDateType", typeof(int));
            dtSearchValue.Columns.Add(dcDateType);

            DataColumn dcUserId = new DataColumn("dcUserId", typeof(int));
            dtSearchValue.Columns.Add(dcUserId);

            DataColumn dcStatusMode = new DataColumn("dcStatusMode", typeof(int));
            dtSearchValue.Columns.Add(dcStatusMode);

            DataColumn dcStatusModeSequence = new DataColumn("dcStatusModeSequence", typeof(int));
            dtSearchValue.Columns.Add(dcStatusModeSequence);

            DataColumn dcOrderBy1 = new DataColumn("dcOrderBy1", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy1);

            DataColumn dcOrderBy2 = new DataColumn("dcOrderBy2", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy2);

            DataColumn dcOrderBy3 = new DataColumn("dcOrderBy3", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy3);

            DataColumn dcOrderBy4 = new DataColumn("dcOrderBy4", typeof(int));
            dtSearchValue.Columns.Add(dcOrderBy4);

            //DataColumn dcOrderBy5 = new DataColumn("dcOrderBy5", typeof(int));
            //dtSearchValue.Columns.Add(dcOrderBy5);


            DataColumn dcOrderDetailIds = new DataColumn("dcstrUserID", typeof(string));
            dtSearchValue.Columns.Add(dcOrderDetailIds);

            DataColumn dcBuyingHouseId = new DataColumn("dcBuyingHouseId", typeof(int));
            dtSearchValue.Columns.Add(dcBuyingHouseId);

            DataColumn dcOrderTypeId = new DataColumn("dcordertypesId", typeof(int));
            dtSearchValue.Columns.Add(dcOrderTypeId);

            DataColumn dcIsUnShipped = new DataColumn("dcIsUnShipped", typeof(bool));
            dtSearchValue.Columns.Add(dcIsUnShipped);

            Session["SearchValue"] = this.searchText;

            //Gajendra 22-04-2016
            if (this.DelayStatusId != 0)
                hdnfld_DelayStatusId.Value = this.DelayStatusId.ToString();
            if (!string.IsNullOrEmpty(hdnfld_DelayStatusId.Value))
                this.DelayStatusId = Convert.ToInt32(hdnfld_DelayStatusId.Value);

            DataRow dr;
            dr = dtSearchValue.NewRow();
            dtSearchValue.Rows.Add(dr);
            dtSearchValue.Rows[0][dcsearchText] = this.searchText;
            dtSearchValue.Rows[0][dcYear] = this.Years;
            dtSearchValue.Rows[0][dcFromDate] = this.FromDate;
            dtSearchValue.Rows[0][dcToDate] = this.ToDate;
            dtSearchValue.Rows[0][dcClientId] = this.ClientId;
            dtSearchValue.Rows[0][dcAM] = this.AM;
            dtSearchValue.Rows[0][dcClientParentDeptId] = this.ClientParentDeptId;
            dtSearchValue.Rows[0][dcClientDeptId] = this.ClientDeptId;
            dtSearchValue.Rows[0][dcDateType] = this.DateType;
            dtSearchValue.Rows[0][dcUserId] = UserId;
            //dtSearchValue.Rows[0][dcStatusMode] = this.StatusMode;
            dtSearchValue.Rows[0][dcStatusMode] = this.StatusMode_ForIntial;
            //dtSearchValue.Rows[0][dcStatusModeSequence] = this.StatusModeSequence;
            dtSearchValue.Rows[0][dcStatusModeSequence] = this.StatusMode_ForDouble;
            dtSearchValue.Rows[0][dcOrderBy1] = this.OrderBy1;
            dtSearchValue.Rows[0][dcOrderBy2] = this.OrderBy2;
            dtSearchValue.Rows[0][dcOrderBy3] = this.OrderBy3;
            dtSearchValue.Rows[0][dcOrderBy4] = this.OrderBy4;
            //dtSearchValue.Rows[0][dcOrderBy5] = this.OrderBy5;
            dtSearchValue.Rows[0][dcOrderDetailIds] = strUserID;
            dtSearchValue.Rows[0][dcBuyingHouseId] = this.BuyingHouseId;
            dtSearchValue.Rows[0][dcOrderTypeId] = this.OrderTypes;

            DataTable dt = dtSearchValue;
            Session["SearchValues"] = dt;
            Session["btn_check"] = 1;
            //Added By ashish on 19/2/2014 
            this.desigId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.Designation);
            this.DeptId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);
            //if (Convert.ToInt32(Session["Client"]) == 1)
            //{
            //    this.DeptId = 5;
            //    UserId = 15;
            //}

            int iUserId = 0;

            WorkflowController objWorkflowController = new WorkflowController();
            if (this.DelayStatusId > 0)
            {
                string SessionId = Session.SessionID;

                if (ApplicationHelper.LoggedInUser.UserData != null)


                    iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                UserDetails usd = new UserDetails();

                SessionInfo sessionInfo = new SessionInfo();

                iKandi.Common.User user = null;
                user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                bool flag = objWorkflowController.InsertDelayForMO(SessionId, DelayStatusId, iUserId);

                DelayOrderDetailIds = objWorkflowController.GetDelayOrderDetailIds(Session.SessionID);

            }
            else if (OutHouseOrderDetailIds != null)
            {
                DelayOrderDetailIds = OutHouseOrderDetailIds;
            }

            if (TaskCompleteOrderDetailId > 0)
            {
                DelayOrderDetailIds = TaskCompleteOrderDetailId.ToString();
            }

            if (StyleNumber != null)
            {
                this.searchText = StyleNumber;
            }
            string str = objWorkflowController.InsertDelayCountForMO(Session.SessionID, 1);
            if (str != "" || DelayStatusId != 0 || !string.IsNullOrEmpty(DelayOrderDetailIds)) //Gajendra Paging
            {
                int TotalCount = 0;
                if (Session["PageIndex"] != null)
                {
                    if (Session["PageIndex"].ToString() == "1")
                    {
                        StartIndex = PageIndex_Page;
                    }
                }
                //StartIndex = PageIndex_Page > 0 ? PageIndex_Page : StartIndex;//abhishek 28 dec page index getting rest after page postback 
                //updated by abhishek 21/6/2017

                List<MOOrderDetails> objOrderDetail = this.OrderControllerInstance.GetOrdersBasicInfo(this.searchText,"", this.Years, this.FromDate, this.ToDate, this.ClientId, this.DateType, UserId, this.StatusMode_ForIntial, this.StatusMode_ForDouble, this.OrderBy1, this.OrderBy2, this.OrderBy3, this.OrderBy4, strUserID, this.BuyingHouseId, this.UnitId, this.desigId, this.DeptId, this.SalesView, HttpContext.Current.Session.SessionID, this.ClientDeptId, DelayOrderDetailIds, this.OrderTypes, StartIndex, out TotalCount, this.AM, this.IsUnShipped, this.OutHouse,this.ClientParentDeptId, 10);//Gajendra Paging
                //GridView1.DataSource = this.OrderControllerInstance.GetOrdersBasicInfo(this.searchText, this.Years, this.FromDate, this.ToDate, this.ClientId, this.DateType, UserId, this.StatusMode_ForIntial, this.StatusMode_ForDouble, this.OrderBy1, this.OrderBy2, this.OrderBy3, this.OrderBy4, strUserID, this.BuyingHouseId, this.UnitId, this.desigId, this.DeptId, this.SalesView, HttpContext.Current.Session.SessionID, this.ClientDeptId, DelayOrderDetailIds, this.OrderTypes, StartIndex, out TotalCount, this.AM);//Gajendra Paging
                Session["objOrderDetail"] = objOrderDetail as List<MOOrderDetails>;
                GridView1.DataSource = objOrderDetail;
                GridView1.DataBind();
                TotalCnt_Page = TotalCount;
                //if (StartIndex > 1)
                //{
                //PageIndex_Page = StartIndex;
                //}
                // Session["PageIndex"] = null;
                //this.PopulatePager(TotalCount, StartIndex);
                generatePager(TotalCount, 10, StartIndex);
            }
            //PermissionInfo(); 
        }

        #region Gajendra Paging
        //protected void Page_Changed(object sender, EventArgs e)
        //{
        //    int StartIndex = int.Parse((sender as LinkButton).CommandArgument);
        //    BindControls(StartIndex);
        //}

        //private void PopulatePager(int TotalCount, int currentPage)
        //{
        //    double dblPageCount = (double)((decimal)TotalCount / decimal.Parse("10"));
        //    int pageCount = (int)Math.Ceiling(dblPageCount);
        //    List<ListItem> pages = new List<ListItem>();
        //    if (pageCount > 0)
        //    {
        //        pages.Add(new ListItem("First", "1", currentPage > 1));
        //        for (int i = 1; i <= pageCount; i++)
        //        {
        //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        //        }
        //        pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        //    }
        //    rptPager.DataSource = pages;
        //    rptPager.DataBind();
        //}
        public void generatePager(int totalRowCount, int pageSize, int currentPage)
        {
            int totalLinkInPage = 10;
            int totalPageCount = (int)Math.Ceiling((decimal)totalRowCount / pageSize);

            int startPageLink = Math.Max(currentPage - (int)Math.Floor((decimal)totalLinkInPage / 2), 1);
            int lastPageLink = Math.Min(startPageLink + totalLinkInPage - 1, totalPageCount);

            if ((startPageLink + totalLinkInPage - 1) > totalPageCount)
            {
                lastPageLink = Math.Min(currentPage + (int)Math.Floor((decimal)totalLinkInPage / 2), totalPageCount);
                startPageLink = Math.Max(lastPageLink - totalLinkInPage + 1, 1);
            }

            List<ListItem> pageLinkContainer = new List<ListItem>();

            if (startPageLink != 1)
                pageLinkContainer.Add(new ListItem("First", "1", currentPage != 1));
            for (int i = startPageLink; i <= lastPageLink; i++)
            {
                pageLinkContainer.Add(new ListItem(i.ToString(), i.ToString(), currentPage != i));
            }
            if (lastPageLink != totalPageCount)
                pageLinkContainer.Add(new ListItem("Last", totalPageCount.ToString(), currentPage != totalPageCount));

            dlPager.DataSource = pageLinkContainer;
            dlPager.DataBind();
        }

        protected void dlPager_ItemCommand(object source, DataListCommandEventArgs e)
        {
            PageIndex_Page = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "PageNo")
            {
                MOPaging(Convert.ToInt32(e.CommandArgument));
                // bindGrid(Convert.ToInt32(e.CommandArgument));

            }
        }
        #endregion
        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    hdnPagesize.Value = GridView1.PageSize.ToString();
        //    //hdnPageIndex.Value = GridView1.PageIndex.ToString();
        //    BindControls();
        //}

        protected String GetHtmlEncode(String strFabric)
        {
            return strFabric.Replace('"', '\"');
        }

        // Edit By Surendra For Stiched Start eta
        protected void ColorChangeStartETA(DateTime StartEta, int Percentage, TextBox lblStitchedEta)
        {
            lblStitchedEta.ForeColor = System.Drawing.Color.Blue;
            if (Percentage >= 1)
            {
                lblStitchedEta.ForeColor = System.Drawing.Color.Gray;
            }

            if ((Percentage == 0) && (DateTime.Now > StartEta))
            {
                lblStitchedEta.ForeColor = System.Drawing.Color.Red;

            }


        }
        // Edit By Surendra For Stiched END eta
        protected void ColorChangeEndETA(DateTime EndEta, int Percentage, TextBox Label6)
        {
            Label6.ForeColor = System.Drawing.Color.Blue;
            if (DateTime.Now > EndEta)
            {
                Label6.ForeColor = System.Drawing.Color.Red;


            }
            if (Percentage >= 100)
            {
                Label6.ForeColor = System.Drawing.Color.Gray;
            }



        }

        // Edit By Surendra For Cut Ready Start eta
        protected void ColorChangeCutReadyStartETA(DateTime StartEta, int Percentage, TextBox lblCutReady)
        {
            lblCutReady.ForeColor = System.Drawing.Color.Blue;
            if (Percentage >= 1)
            {
                lblCutReady.ForeColor = System.Drawing.Color.Gray;
            }

            if ((Percentage == 0) && (DateTime.Now.Date > StartEta.Date))
            {
                lblCutReady.ForeColor = System.Drawing.Color.Red;

            }


        }
        // Edit By Surendra For Cut Ready END eta
        protected void ColorChangeCutReadyEndETA(DateTime EndEta, int Percentage, TextBox Label5)
        {
            Label5.ForeColor = System.Drawing.Color.Blue;

            if (DateTime.Now.Date > EndEta.Date)
            {
                Label5.ForeColor = System.Drawing.Color.Red;
            }
            if (Percentage >= 100)
            {
                Label5.ForeColor = System.Drawing.Color.Gray;
            }


        }
        // Edit By Surendra For VA Start eta
        protected void ColorChangeVAStartETA(DateTime StartEta, int Percentage, TextBox lblembEta)
        {
            lblembEta.ForeColor = System.Drawing.Color.Blue;
            if (Percentage >= 1)
            {
                lblembEta.ForeColor = System.Drawing.Color.Gray;
            }

            if ((Percentage == 0) && (DateTime.Now.Date > StartEta.Date))
            {
                lblembEta.ForeColor = System.Drawing.Color.Red;

            }


        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            hdnUploadPOid.Value = hdnUploadPOid.Value.Replace(",", "");
            int POorderdetailID = Convert.ToInt32(hdnUploadPOid.Value);
            string POUploadFile1Name = POUpload1.FileName;
            string POUploadFile2Name = POUpload2.FileName;
            string POUploadFile3Name = POUpload3.FileName;

            if (POUploadFile1Name != "")
            {
                POUpload1.SaveAs(Server.MapPath("~/Uploads/Order/") + POorderdetailID + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + POUploadFile1Name);
                POUploadFile1Name = POorderdetailID + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + POUploadFile1Name;
                //fabricWorking.Fabric1File = Fabric1UploadFileName == "" ? "" : s + Fabric1UploadFileName;
            }
            if (POUploadFile2Name != "")
            {
                POUpload2.SaveAs(Server.MapPath("~/Uploads/Order/") + POorderdetailID + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + POUploadFile2Name);
                POUploadFile2Name = POorderdetailID + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + POUploadFile2Name;
                //fabricWorking.Fabric1File = Fabric1UploadFileName == "" ? "" : s + Fabric1UploadFileName;
            }

            if (POUploadFile3Name != "")
            {
                POUpload3.SaveAs(Server.MapPath("~/Uploads/Order/") + POorderdetailID + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + POUploadFile3Name);
                POUploadFile3Name = POorderdetailID + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + POUploadFile3Name;
                //fabricWorking.Fabric1File = Fabric1UploadFileName == "" ? "" : s + Fabric1UploadFileName;
            }

            OrderController od = new OrderController();
            od.SaveMOOrderDetails(POUploadFile1Name, POUploadFile2Name, POUploadFile3Name, POorderdetailID);
            if (POUploadFile1Name != "" || POUploadFile2Name != "")
            {
                od.UpdatePOUploadTask(POorderdetailID, ApplicationHelper.LoggedInUser.UserData.UserID);
            }
            hdnUploadPOid.Value = "";


        }
        // Edit By Surendra For VA END eta
        protected void ColorChangeVAEndETA(DateTime EndEta, int Percentage, TextBox Label7)
        {
            Label7.ForeColor = System.Drawing.Color.Blue;

            if (DateTime.Now.Date > EndEta.Date)
            {
                Label7.ForeColor = System.Drawing.Color.Red;
            }
            if (Percentage >= 100)
            {
                Label7.ForeColor = System.Drawing.Color.Gray;
            }


        }

        // Edit By Surendra For Packed Start eta
        protected void ColorChangePackedStartETA(DateTime StartEta, int Percentage, TextBox lblPackedEta)
        {
            lblPackedEta.ForeColor = System.Drawing.Color.Blue;
            if (Percentage >= 1)
            {
                lblPackedEta.ForeColor = System.Drawing.Color.Gray;
            }

            if ((Percentage == 0) && (DateTime.Now.Date > StartEta.Date))
            {
                lblPackedEta.ForeColor = System.Drawing.Color.Red;
            }


        }
        // Edit By Surendra For Stiched END eta
        protected void repAccess_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string OrderDetailsID = (DataBinder.Eval(e.Item.DataItem, "OrderDetailsID").ToString());
                string AccessoriesName = (DataBinder.Eval(e.Item.DataItem, "AccessoriesName").ToString());
                string QuantityAvail = (DataBinder.Eval(e.Item.DataItem, "QuantityAvail").ToString());
                int ApprovedByAccessoryManager = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ApprovedByAccessoryManager"));
                int ApprovedByAccountManager = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ApprovedByAccountManager"));
                DateTime ApprovedByAccessoryManagerOn = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "ApprovedByAccessoryManagerOn"));
                DateTime ApprovedByAccountManagerOn = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "ApprovedByAccountManagerOn"));


                string Quantity = hdnQuantity.Value;

                TextBox lblApprovalDate = (TextBox)e.Item.FindControl("lblApprovalDate");
                HyperLink lnkApprovalDate = (HyperLink)e.Item.FindControl("lnkApprovalDate");
                HiddenField hdnApprovalDate = (HiddenField)e.Item.FindControl("hdnApprovalDate");
                HtmlAnchor lnkpopup = (HtmlAnchor)e.Item.FindControl("lnkpopup");
                Label lblAccessories = (Label)e.Item.FindControl("lblAccessories");

                //Added By Ashish on 23/3/2015
                // TextBox lblAppvDate = (TextBox)e.Item.FindControl("lblAppvDate"); 
                Label lblAppvDate = (Label)e.Item.FindControl("lblDateAcc");
                //END
                HiddenField hdnAppvDate = (HiddenField)e.Item.FindControl("hdnAppvDate");
                Label lblParcentInHouse = (Label)e.Item.FindControl("lblParcentInHouse");
                Label lblAccessPopup = (Label)e.Item.FindControl("lblAccessPopup");
                TextBox lblAvilableOn = (TextBox)e.Item.FindControl("txtQuantityAvail");
                TextBox txtTotal = (TextBox)e.Item.FindControl("txtRequired");
                lblAvilableOn.Visible = iKandi.Common.MOOrderDetails.AccAvilableOnRead;
                lblAvilableOn.Enabled = iKandi.Common.MOOrderDetails.AccAvilableOnWrite;
                //txtTotal.Visible = iKandi.Common.MOOrderDetails.AccTotalRead;
                //txtTotal.Enabled = iKandi.Common.MOOrderDetails.AccTotalWrite;

                //Added By Ashish on 30/12/2014
                HiddenField hdnAccessories = (HiddenField)e.Item.FindControl("hdnAccessories");
                HtmlAnchor lnkETA = (HtmlAnchor)e.Item.FindControl("lnkETA");

                txtTotal.Visible = iKandi.Common.MOOrderDetails.AccTotalRead;
                txtTotal.Enabled = iKandi.Common.MOOrderDetails.AccTotalWrite;

                //END
                //if (lnkETA != null)
                //{

                //    lnkETA.Attributes.Add("onclick", "javascript:showEtaPopup('" + OrderDetailsID + "', '" + AccessoriesName + "','" + Quantity + "')");
                //}
                hdnAccessories.Value = AccessoriesName;
                if (AccessoriesName.Length > 30)
                    lblAccessories.Text = AccessoriesName.Substring(0, 30);

                else
                    lblAccessories.Text = AccessoriesName;
                lblAccessories.ToolTip = AccessoriesName;
                lblAvilableOn.Enabled = iKandi.Common.MOOrderDetails.AccAvilableOnWrite;
                if ((ApprovedByAccessoryManager != 0 && ApprovedByAccountManager != 0) && (ApprovedByAccessoryManagerOn != DateTime.MinValue && ApprovedByAccountManagerOn != DateTime.MinValue))
                {
                    if (lblAvilableOn.Enabled == true)
                        lblAvilableOn.Enabled = true;
                }
                else
                {
                    lblAvilableOn.Enabled = false;
                }

                lblAvilableOn.Visible = iKandi.Common.MOOrderDetails.AccAvilableOnRead;

                if (lblAccessories != null)
                {
                    lblAccessories.Visible = iKandi.Common.MOOrderDetails.AccQualityRead;
                    lblAccessories.Enabled = iKandi.Common.MOOrderDetails.AccQualityWrite;

                }
                //if (lblAppvDate != null)
                //{
                //    lblAppvDate.Visible = iKandi.Common.MOOrderDetails.AccApprovedOnRead;
                //    //lblAppvDate.Enabled = iKandi.Common.MOOrderDetails.AccApprovedOnWrite;
                //    if (iKandi.Common.MOOrderDetails.AccApprovedOnWrite != true)
                //    {
                //        lblAppvDate.Attributes.Add("readonly", "readonly");
                //        lblAppvDate.Attributes.Add("Css", "do-not-allow-typing");
                //    }
                //    else
                //    {
                //        lblAppvDate.Attributes.Add("readonly", "readonly");
                //        lblAppvDate.Attributes.Add("class", "date-picker do-not-allow-typing");
                //    }

                //}
                TextBox txtDateAcc = (TextBox)e.Item.FindControl("txtDateAcc");
                if (txtDateAcc != null)
                {
                    txtDateAcc.Visible = iKandi.Common.MOOrderDetails.AccApprovedOnRead;
                    //lblAppvDate.Enabled = iKandi.Common.MOOrderDetails.AccApprovedOnWrite;
                    if (iKandi.Common.MOOrderDetails.AccApprovedOnWrite != true)
                    {
                        txtDateAcc.Attributes.Add("readonly", "readonly");
                        txtDateAcc.Attributes.Add("Css", "do-not-allow-typing");
                    }
                    if (QuantityAvail != "" && txtDateAcc.Text != "")
                    {
                        txtDateAcc.Attributes.Add("readonly", "readonly");
                        txtDateAcc.Enabled = false;
                    }
                    //else
                    //{
                    //   // txtDateAcc.Attributes.Add("readonly", "readonly");
                    //    txtDateAcc.Attributes.Add("class", "th do-not-allow-typing");

                    //    txtDateAcc.Attributes.Add("onchange", "javascript:UpdateAccsessoryAppDate(this)");
                    //}

                }

                if (lblParcentInHouse != null)
                {
                    lblParcentInHouse.Text = lblParcentInHouse.Text;
                    lblParcentInHouse.Visible = iKandi.Common.MOOrderDetails.AccRecdRead;
                }

                if (lblApprovalDate != null)
                {
                    lblApprovalDate.Enabled = iKandi.Common.MOOrderDetails.AccAvilableOnWrite;

                    if (lblApprovalDate.Text != "")
                    {
                        lnkpopup.Visible = false;
                        lblApprovalDate.Visible = iKandi.Common.MOOrderDetails.AccAvilableOnRead;
                        lblApprovalDate.Attributes.Add("readonly", "readonly");

                    }
                    else
                    {

                        lnkpopup.Attributes.Add("onclick", "javascript:showAccessoryPopup('" + OrderDetailsID + "', '" + AccessoriesName + "','" + Quantity + "')");
                        lblApprovalDate.Visible = false;
                        if (iKandi.Common.MOOrderDetails.AccApprovedOnWrite != true)
                        {
                            lnkpopup.Visible = false;
                            lblAccessPopup.Visible = iKandi.Common.MOOrderDetails.AccAvilableOnRead;

                        }
                        else
                        {
                            lnkpopup.Visible = iKandi.Common.MOOrderDetails.AccAvilableOnRead;
                            lblAccessPopup.Visible = false;

                        }

                    }

                }
                DateTime BIHDate = Convert.ToDateTime(ViewState["BIHDate"].ToString());
                HtmlTableCell tdParcentInHouse = (HtmlTableCell)e.Item.FindControl("tdParcentInHouse");
                HtmlTableCell tdAccessEta = (HtmlTableCell)e.Item.FindControl("tdAccessEta");
                HtmlTableCell tdAccessoriesName = (HtmlTableCell)e.Item.FindControl("tdAccessoriesName");

                //Added By Ashish on 14/1/2015
                TextBox lbletapending = (TextBox)e.Item.FindControl("lbletapending");
                TextBox lblAccess4StartEta = (TextBox)e.Item.FindControl("lblAccess4StartEta");
                HiddenField hdnAccesoriesEta = (HiddenField)e.Item.FindControl("hdnAccesoriesEta");
                //Added By Ashish on 23/3/2015
                lblAccess4StartEta.Visible = iKandi.Common.MOOrderDetails.AccessoriesETARead;
                lblAccess4StartEta.Enabled = iKandi.Common.MOOrderDetails.AccessoriesETAWrite;
                //END
                


                if (BIHDate.Date >= System.DateTime.Now.Date)
                {
                    if (hdnAccesoriesEta.Value != "")
                    {

                        if (lblParcentInHouse.Text != "")
                        {
                            if (Convert.ToInt32(lblParcentInHouse.Text) >= 100)
                            {
                                Access_ColorGreen = 1;
                            }
                            else
                            {
                                Access_ColorWhite = 1;
                            }


                        }
                        else
                        {
                            Access_ColorWhite = 1;
                        }
                    }
                    else
                    {
                        Access_ColorWhite = 1;
                    }

                }
                if (BIHDate.Date < System.DateTime.Now.Date)
                {
                    if (hdnAccesoriesEta.Value != "")
                    {

                        if (BIHDate.Date < Convert.ToDateTime(hdnAccesoriesEta.Value).Date)
                        {
                            Access_ColorRed = 1;
                        }
                        if (lblParcentInHouse.Text != "")
                        {
                            if (Convert.ToInt32(lblParcentInHouse.Text) >= 100)
                            {
                                if (BIHDate.Date >= Convert.ToDateTime(hdnAccesoriesEta.Value).Date)
                                {
                                    Access_ColorGreen = 1;
                                }
                            }
                            else
                            {
                                Access_ColorRed = 1;
                            }


                        }
                        else
                        {
                            Access_ColorRed = 1;
                        }
                    }
                    else
                    {
                        Access_ColorRed = 1;
                    }

                }


                //End Add By Ravi kumar on 6/2/2015

                lblParcentInHouse.Text = lblParcentInHouse.Text + "%";
                if (lblParcentInHouse.Text == "0%")
                    lblParcentInHouse.Text = "";
                if (lblAvilableOn.Text == "0")
                    lblAvilableOn.Text = "";
                if (txtTotal.Text == "0")
                    txtTotal.Text = "";

                //added by abhishek 23/9/2016

                txtTotal.ToolTip = txtTotal.Text;
                if (txtTotal.Text != "")
                {
                    double finalOrder1 = 0;
                    finalOrder1 = Convert.ToDouble(Convert.ToString(txtTotal.Text).Replace(",", ""));

                    //Add By Prabhaker On 11-sep-18
                    //double FinalOrderFabric1_kd = (finalOrder1 / 1000);
                    //txtTotal.Text = Math.Round((FinalOrderFabric1_kd), 1, MidpointRounding.AwayFromZero).ToString() + "k";
                    Double lac = 100000, thousand = 1000, crore = 10000000, tenk = 10000, tenl = 1000000, tencr = 100000000;

                    if (finalOrder1 < tenk)
                    {
                        double QtyAvail_k = (finalOrder1 / thousand);
                        txtTotal.Text = Math.Round((QtyAvail_k), 1, MidpointRounding.AwayFromZero).ToString() + "k";
                    }
                    else if (finalOrder1 >= tenk && finalOrder1 < lac)
                    {
                        double QtyAvail_k = Math.Round((finalOrder1 / thousand), 0);
                        if (QtyAvail_k < 100)
                        {
                            txtTotal.Text = Math.Round((QtyAvail_k), 0, MidpointRounding.AwayFromZero).ToString() + "k";
                        }
                        else
                        {
                            txtTotal.Text = Math.Round((QtyAvail_k / 100), 0, MidpointRounding.AwayFromZero).ToString() + "lc";
                        }
                    }
                    else if (finalOrder1 >= lac && finalOrder1 < tenl)
                    {
                        double QtyAvail_k = Math.Round((finalOrder1 / lac), 1);
                        txtTotal.Text = Math.Round((QtyAvail_k), 1, MidpointRounding.AwayFromZero).ToString() + "lc";

                    }
                    else if (finalOrder1 >= tenl && finalOrder1 < crore)
                    {
                        double QtyAvail_k = Math.Round((finalOrder1 / lac), 0);
                        if (QtyAvail_k < 100)
                        {
                            txtTotal.Text = Math.Round((QtyAvail_k), 0, MidpointRounding.AwayFromZero).ToString() + "lc";
                        }
                        else
                        {
                            txtTotal.Text = Math.Round((QtyAvail_k / 100), 0, MidpointRounding.AwayFromZero).ToString() + "cr";
                        }

                    }
                    else if (finalOrder1 >= crore && finalOrder1 < tencr)
                    {
                        double QtyAvail_k = Math.Round((finalOrder1 / crore), 1);
                        txtTotal.Text = Math.Round((QtyAvail_k), 1, MidpointRounding.AwayFromZero).ToString() + "cr";

                    }
                    else
                    {
                        double QtyAvail_k = Math.Round((finalOrder1 / crore), 0);
                        if (QtyAvail_k < 100)
                        {
                            txtTotal.Text = Math.Round((QtyAvail_k), 0, MidpointRounding.AwayFromZero).ToString() + "cr";
                        }
                        else
                        {
                            txtTotal.Text = Math.Round((QtyAvail_k / 100), 0, MidpointRounding.AwayFromZero).ToString() + "cr";
                        }

                    }




                    //End Of Code
                


                }
                lblAvilableOn.Text = lblAvilableOn.Text == "0k" ? "" : lblAvilableOn.Text;
                txtTotal.Text = txtTotal.Text == "0k" ? "" : txtTotal.Text;
            }
            //end--
        }

        // ADD By Ravi kumar on 6/1/2015
        public static int counts
        {
            get;
            set;
        }
        public string IsVAcomplete
        {
            get;
            set;
        }
        public string IsReScan
        {
            get;
            set;
        }
        protected void repProduction_ItemCreated(Object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Footer)
            //{
            //    e.Item.FindControl("tdva");
            //}
            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlTableCell tdva = (HtmlTableCell)e.Item.FindControl("tdva");

                e.Item.FindControl("tdva");
            }
        }

        protected void repProduction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlTableCell tdva = (HtmlTableCell)e.Item.FindControl("tdva");
                HtmlTableCell tdRescan = (HtmlTableCell)e.Item.FindControl("tdRescan");

                HtmlTableCell tdalloc_cut = (HtmlTableCell)e.Item.FindControl("tdCutallo");
                HtmlTableCell tdStitchedallco = (HtmlTableCell)e.Item.FindControl("tdStitchedallco");
                HtmlTableCell tdSFinshingallco = (HtmlTableCell)e.Item.FindControl("tdSFinshingallco");
                HtmlTableCell tdheadercutissue = (HtmlTableCell)e.Item.FindControl("tdheadercutissue");
                //HiddenField IsVisibleOutHouse = (HiddenField)e.Item.FindControl("IsVisibleOutHouse");
                if (Convert.ToInt32(IsReScan) == 1)
                {
                    tdRescan.Visible = true;
                }
                else
                {
                    tdRescan.Visible = false;
                }
                if (!string.IsNullOrEmpty(IsVAcomplete))
                {
                    tdva.Visible = false;
                }
                // Edit By Prabhaker 15-mar-18
                //if (count_production == 0 || count_production == 1)
                if (IsOuthouse_CutIssue == false)
                {
                    tdalloc_cut.Visible = false;
                    tdStitchedallco.Visible = false;
                    tdSFinshingallco.Visible = false;
                    tdheadercutissue.Visible = false;
                }
                else
                {
                    //if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 15 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 46)
                    //{
                    tdheadercutissue.Visible = true;
                    //}

                }
                // end  Edit By Prabhaker 15-mar-18

            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                HtmlGenericControl dvProduction = (HtmlGenericControl)e.Item.FindControl("dvProduction");

                HiddenField hdnIsvaComplete = (HiddenField)e.Item.FindControl("hdnIsvaComplete");

                HtmlGenericControl tdva = (HtmlGenericControl)e.Item.FindControl("tdva");
                HtmlTableCell tdRescan = (HtmlTableCell)e.Item.FindControl("tdRescan");

                int UnitId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UnitId"));             
                bool InFactory = false; bool InProductionDepartment = false;
                if (MOOrderDetails.FactoryID != null)
                {
                    InFactory = MOOrderDetails.FactoryID.IndexOf(UnitId) != -1;
                }

                if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 10)
                {
                    InProductionDepartment = true;
                }

                //==============================================================
                HiddenField hdnProOrderDetailId = (HiddenField)e.Item.FindControl("hdnProOrderDetailId");
                HiddenField hdnProOrderId = (HiddenField)e.Item.FindControl("hdnProOrderId");

                HiddenField hdnfactorycount = (HiddenField)e.Item.FindControl("hdnfactorycount");
                counts = Convert.ToInt32(hdnfactorycount.Value);
                Label lblCutAllocate = (Label)e.Item.FindControl("lblCutAllocate");
                Label lblStitchingAllocate = (Label)e.Item.FindControl("lblStitchingAllocate");
                Label lblFinishAllocate = (Label)e.Item.FindControl("lblFinishAllocate");

                TextBox txtCutToday = (TextBox)e.Item.FindControl("txtCutToday");
                TextBox txtCutReadyToday = (TextBox)e.Item.FindControl("txtCutReadyToday");
                TextBox txtStitchToday = (TextBox)e.Item.FindControl("txtStitchToday");
                TextBox txtFinishToday = (TextBox)e.Item.FindControl("txtFinishToday");
                TextBox txtVAToday = (TextBox)e.Item.FindControl("txtVAToday");
                TextBox txtcutissuetotal = (TextBox)e.Item.FindControl("txtcutissuetotal");

                Label txtCutTotal = (Label)e.Item.FindControl("txtCutTotal");
                Label txtCutReadyTotal = (Label)e.Item.FindControl("txtCutReadyTotal");
                Label txtStitchTotal = (Label)e.Item.FindControl("txtStitchTotal");
                Label txtVATotal = (Label)e.Item.FindControl("txtVATotal");
                Label txtFinishTotal = (Label)e.Item.FindControl("txtFinishTotal");
                Label lblrescanValue1 = (Label)e.Item.FindControl("lblrescanValue1");
                Label lblrescanValue2 = (Label)e.Item.FindControl("lblrescanValue2");

                HtmlTableCell tdvatoday = (HtmlTableCell)e.Item.FindControl("tdvatoday");
                HtmlTableCell tdvaVATotal = (HtmlTableCell)e.Item.FindControl("tdvaVATotal");
                HtmlTableCell tdrescanvalue1 = (HtmlTableCell)e.Item.FindControl("tdrescanvalue1");
                HtmlTableCell tdrescanValue2 = (HtmlTableCell)e.Item.FindControl("tdrescanValue2");

                HiddenField hdnCutTotal = (HiddenField)e.Item.FindControl("hdnCutTotal");
                HiddenField hdnCutReadyTotal = (HiddenField)e.Item.FindControl("hdnCutReadyTotal");
                HiddenField hdnStitchTotal = (HiddenField)e.Item.FindControl("hdnStitchTotal");
                HiddenField hdnFinishTotal = (HiddenField)e.Item.FindControl("hdnFinishTotal");

                Label lblcutissue = (Label)e.Item.FindControl("lblcutissue");
                TextBox txtcutissue = (TextBox)e.Item.FindControl("txtcutissue");

                if (!string.IsNullOrEmpty(IsVAcomplete))
                {
                    tdvatoday.Visible = false;
                    tdvaVATotal.Visible = false;
                }
                HtmlTableCell tditemCutalloc = (HtmlTableCell)e.Item.FindControl("tditemCutalloc");
                HtmlTableCell tditemStitchingalloc = (HtmlTableCell)e.Item.FindControl("tditemStitchingalloc");
                HtmlTableCell tditemFinishAllocate = (HtmlTableCell)e.Item.FindControl("tditemFinishAllocate");
                HtmlTableCell tdcutissue = (HtmlTableCell)e.Item.FindControl("tdcutissue");
                HtmlTableCell tdcutissuetotal = (HtmlTableCell)e.Item.FindControl("tdcutissuetotal");
                HtmlTableCell tdFacotryName = (HtmlTableCell)e.Item.FindControl("tdFacotryName");
              
                if (IsOuthouse_CutIssue == false)
                {
                    tditemCutalloc.Visible = false;
                    tditemStitchingalloc.Visible = false;
                    tditemFinishAllocate.Visible = false;
                    tdcutissue.Visible = false;
                    tdcutissuetotal.Visible = false;

                }
                else
                {                  
                    tdcutissue.Visible = true;
                    tdcutissuetotal.Visible = true;
                    txtcutissue.Enabled = false;
                    if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 15 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 46)
                    {
                        txtcutissue.Enabled = true;
                    }
                    //txtcutissue.CssClass = "MOProdSecGray";                    
                }
              
                txtCutToday.ToolTip = "Cut";
                txtCutReadyToday.ToolTip = "Cut Ready";
                txtStitchToday.ToolTip = "Stitching";
                txtFinishToday.ToolTip = "Finshing";
                txtVAToday.ToolTip = "V.A";
               
                Label lbllineno = (Label)e.Item.FindControl("lbllineno");
             
                if (Convert.ToDecimal(lblcutissue.Text) <= 0)
                    lblcutissue.Text = "";
                else
                {
                    if (Convert.ToDecimal(lblcutissue.Text) > 999)
                    {
                        decimal val = Math.Round(Convert.ToDecimal(lblcutissue.Text) / 1000, 1, MidpointRounding.AwayFromZero);
                        lblcutissue.Text = val + "k";
                    }
                    else
                    {
                        //lblcutissue.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "CutIssueQty")) + "k";
                    }
                }
                txtcutissue.Text = lblcutissue.Text;
                
                int OrderId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "OrderID"));
                int OrderDetailId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "OrderDetailID"));
                int CuttingShare = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "CuttingShare"));
                int StitchingShare = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "StitchingShare"));
                int FinishingShare = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "FinishingShare"));
                int TotalCutPcs = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TotalCutPcs"));
                int TotalCutReady = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TotalCutReady"));
                int TotalCutIssueQty = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "CutIssueQtyTotal"));
                int TotalStitched = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TotalStitched"));
                int TotalFinished = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TotalFinished"));
                int TodayCut = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TodayCut"));
                int TodayCutReady = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TodayCutReady"));
                int TodayStitch = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TodayStitch"));
                int TodayFinish = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TodayFinish"));
                int TotalValueAddedQty = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ValueAddedQty"));
                int TodayValueAddedQty = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ValueAddedQtyToday"));
                int FactorySpecification = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "FactorySpecification"));
                int IsShipped = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsShipped"));
                string Cutissuetooltip = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "CutIssueQtyTooltip"));
                int CutIssueQty = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "CutIssueQty"));
                int CutIssueQtyTotal = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "CutIssueQtyTotal"));
                int RescanTotalValue = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "RescanTotalValue"));
                int RescanPendingValue = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "RescanPendingValue"));
                int OutHouseHalfStitch = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "OutHouseHalfStitch"));
                int LinePlanning_StitchQty = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "LinePlanning_StitchQty"));
               
                if(OutHouseHalfStitch == 1)
                    tdFacotryName.Style.Add("background-color", "#91D19A");


                if (Convert.ToInt32(IsReScan) == 1)
                {                   
                    tdrescanvalue1.Visible = true;
                    tdrescanValue2.Visible = true;
                    lblrescanValue1.ToolTip = "Total Rescanned Qty.  " + RescanTotalValue;
                    lblrescanValue2.ToolTip = "Pending Rescan Qty.  " + RescanPendingValue;

                    double RescanTotalValueShareVal = 0.0;
                    double RescanPendingValueShareVal = 0.0;
                    if (Convert.ToDouble(RescanTotalValue) >= 1000)
                        RescanTotalValueShareVal = Math.Round(Convert.ToDouble(RescanTotalValue) / 1000, 1);
                    else
                        RescanTotalValueShareVal = Convert.ToInt32(Convert.ToDouble(RescanTotalValue));

                    if (Convert.ToDouble(RescanPendingValue) >= 1000)
                        RescanPendingValueShareVal = Math.Round(Convert.ToDouble(RescanPendingValue) / 1000, 1);
                    else
                        RescanPendingValueShareVal = Convert.ToInt32(Convert.ToDouble(RescanPendingValue));

                    if (RescanTotalValue >= 1000)
                        lblrescanValue1.Text = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString() + "k";
                    else
                        lblrescanValue1.Text = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString();
                    if (RescanPendingValue >= 1000)
                        lblrescanValue2.Text = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString() + "k";
                    else
                        lblrescanValue2.Text = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString();
                }
                else
                {                   
                    tdrescanvalue1.Visible = false;
                    tdrescanValue2.Visible = false;
                }

                hdnCutTotal.Value = DataBinder.Eval(e.Item.DataItem, "TotalCutPcs").ToString();
                hdnCutReadyTotal.Value = DataBinder.Eval(e.Item.DataItem, "TotalCutReady").ToString();
                hdnStitchTotal.Value = DataBinder.Eval(e.Item.DataItem, "LinePlanning_StitchQty").ToString();
                hdnFinishTotal.Value = DataBinder.Eval(e.Item.DataItem, "TotalFinished").ToString();

                string StyleNumber = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "StyleNumber"));
                DateTime ExFactory = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "ExFactory"));

                // var CuttingShare = 0.0; //var CutReadyPcsTotal = 0.0; var StitchTotalTotal = 0.0; var FinishTotalTotal = 0.0; var VATotalPcsTotal = 0.0;
                double CuttingSharVal = 0.0;
                if (Convert.ToDouble(CuttingShare) >= 1000)
                    CuttingSharVal = Math.Round(Convert.ToDouble(CuttingShare) / 1000, 1);
                else
                    CuttingSharVal = Convert.ToInt32(Convert.ToDouble(CuttingShare));             

                if (CuttingShare >= 1000)
                    lblCutAllocate.Text = CuttingSharVal == 0 ? "" : CuttingSharVal.ToString() + "k";
                else
                    lblCutAllocate.Text = CuttingSharVal == 0 ? "" : CuttingSharVal.ToString();              

                lblCutAllocate.ToolTip = "Total Cut/Cut Ready Alloc. Qty.  " + CuttingShare;

                double StitchingShareVal = 0.0;
                if (Convert.ToDouble(StitchingShare) >= 1000)
                    StitchingShareVal = Math.Round(Convert.ToDouble(StitchingShare) / 1000, 1);
                else
                    StitchingShareVal = Convert.ToInt32(Convert.ToDouble(StitchingShare));
               
                if (StitchingShare >= 1000)
                    lblStitchingAllocate.Text = StitchingShareVal == 0 ? "" : StitchingShareVal.ToString() + "k";
                else
                    lblStitchingAllocate.Text = StitchingShareVal == 0 ? "" : StitchingShareVal.ToString();

                lblStitchingAllocate.ToolTip = "Total Stitching Alloc. Qty.  " + StitchingShare;

                double FinishingShareVal = 0.0;
                if (Convert.ToDouble(FinishingShare) >= 1000)
                    FinishingShareVal = Math.Round(Convert.ToDouble(FinishingShare) / 1000, 1);
                else
                    FinishingShareVal = Convert.ToInt32(Convert.ToDouble(FinishingShare));
              
                if (FinishingShare >= 1000)
                    lblFinishAllocate.Text = FinishingShareVal == 0 ? "" : FinishingShareVal.ToString() + "k";
                else
                    lblFinishAllocate.Text = FinishingShareVal == 0 ? "" : FinishingShareVal.ToString();

                lblFinishAllocate.ToolTip = "Total Finishing & Packing Alloc. Qty.  " + FinishingShare;
               
               
                txtCutTotal.ToolTip = "Total Cut Qty.  " + TotalCutPcs;
                txtCutReadyTotal.ToolTip = "Total Cut Ready Qty.  " + TotalCutReady;                
                txtVATotal.ToolTip = "Total V.A Qty.  " + TotalValueAddedQty;
                txtFinishTotal.ToolTip = "Total Finished & Packed Qty.  " + TotalFinished;
                txtcutissuetotal.ToolTip = "Total Cut Issue Qty.  " + CutIssueQtyTotal;

                
                txtCutToday.Text = TodayCut == 0 ? "" : String.Format("{0:#,##0}", TodayCut);
                txtCutReadyToday.Text = TodayCutReady == 0 ? "" : String.Format("{0:#,##0}", TodayCutReady);
                txtStitchToday.Text = TodayStitch == 0 ? "" : String.Format("{0:#,##0}", TodayStitch);
                txtFinishToday.Text = TodayFinish == 0 ? "" : String.Format("{0:#,##0}", TodayFinish);
                txtVAToday.Text = TodayValueAddedQty == 0 ? "" : TodayValueAddedQty.ToString();
                // End Adding
                var CutPcsTotal = 0.0; var CutReadyPcsTotal = 0.0; var StitchTotalTotal = 0.0; var FinishTotalTotal = 0.0; var VATotalPcsTotal = 0.0; var CutIssuePcsTotal = 0.0;
                
                if (Convert.ToDouble(TotalCutPcs) >= 1000)
                    CutPcsTotal = Math.Round(Convert.ToDouble(TotalCutPcs) / 1000, 1);
                else
                    CutPcsTotal = Convert.ToInt32(Convert.ToDouble(TotalCutPcs));

                if (Convert.ToDouble(TotalCutReady) >= 1000)
                    CutReadyPcsTotal = Math.Round(Convert.ToDouble(TotalCutReady) / 1000, 1);
                else
                    CutReadyPcsTotal = Convert.ToInt32(Convert.ToDouble(TotalCutReady));

                if (Convert.ToDouble(CutIssueQtyTotal) >= 1000)
                    CutIssuePcsTotal = Math.Round(Convert.ToDouble(CutIssueQtyTotal) / 1000, 1);
                else
                    CutIssuePcsTotal = Convert.ToInt32(Convert.ToDouble(CutIssueQtyTotal));


                if (Convert.ToDouble(LinePlanning_StitchQty) >= 1000)
                    StitchTotalTotal = Math.Round(Convert.ToDouble(LinePlanning_StitchQty) / 1000, 1);
                else
                    StitchTotalTotal = Convert.ToInt32(Convert.ToDouble(LinePlanning_StitchQty));

                
                if (Convert.ToDouble(TotalFinished) >= 1000)
                    FinishTotalTotal = Math.Round(Convert.ToDouble(TotalFinished) / 1000, 1);
                else
                    FinishTotalTotal = Convert.ToInt32(Convert.ToDouble(TotalFinished));

              
                if (Convert.ToDouble(TotalValueAddedQty) >= 1000)
                    VATotalPcsTotal = Math.Round(Convert.ToDouble(TotalValueAddedQty) / 1000, 1);
                else
                    VATotalPcsTotal = Convert.ToInt32(Convert.ToDouble(TotalValueAddedQty));
               

                if (TotalCutPcs >= 1000)
                    txtCutTotal.Text = CutPcsTotal == 0 ? "" : CutPcsTotal.ToString() + "k";
                else
                    txtCutTotal.Text = CutPcsTotal == 0 ? "" : CutPcsTotal.ToString();

                if (TotalCutReady >= 1000)
                    txtCutReadyTotal.Text = CutReadyPcsTotal == 0 ? "" : CutReadyPcsTotal.ToString() + "k";
                else
                    txtCutReadyTotal.Text = CutReadyPcsTotal == 0 ? "" : CutReadyPcsTotal.ToString();

                if (CutIssueQtyTotal >= 1000)
                    txtcutissuetotal.Text = CutIssuePcsTotal == 0 ? "" : CutIssuePcsTotal.ToString() + "k";
                else
                    txtcutissuetotal.Text = CutIssuePcsTotal == 0 ? "" : CutIssuePcsTotal.ToString();

               
                if (LinePlanning_StitchQty >= 1000)
                    txtStitchTotal.Text = StitchTotalTotal == 0 ? "" : StitchTotalTotal.ToString() + "k";
                else
                    txtStitchTotal.Text = StitchTotalTotal == 0 ? "" : StitchTotalTotal.ToString();

                txtStitchTotal.ToolTip = "Total Stitched Qty.  " + LinePlanning_StitchQty;
                //}

                if (TotalFinished >= 1000)
                    txtFinishTotal.Text = FinishTotalTotal == 0 ? "" : FinishTotalTotal.ToString() + "k";
                else
                    txtFinishTotal.Text = FinishTotalTotal == 0 ? "" : FinishTotalTotal.ToString();

                if (TotalValueAddedQty >= 1000)
                    txtVATotal.Text = VATotalPcsTotal == 0 ? "" : VATotalPcsTotal.ToString() + "k";
                else
                    txtVATotal.Text = VATotalPcsTotal == 0 ? "" : VATotalPcsTotal.ToString();
              
                if (txtCutTotal.Text == "")
                    txtCutTotal.Style.Add("padding", "2px 18px");
                if (txtCutReadyTotal.Text == "")
                    txtCutReadyTotal.Style.Add("padding", "2px 18px");               
                if (txtStitchTotal.Text == "")
                    txtStitchTotal.Style.Add("padding", "2px 18px");
                if (txtVATotal.Text == "")
                    txtVATotal.Style.Add("padding", "2px 18px");
                if (txtFinishTotal.Text == "")
                    txtFinishTotal.Style.Add("padding", "2px 18px");

                if (lblCutAllocate.Text == "")
                    lblCutAllocate.Style.Add("padding", "2px 18px");
                if (lblStitchingAllocate.Text == "")
                    lblStitchingAllocate.Style.Add("padding", "2px 18px");
                if (lblFinishAllocate.Text == "")
                    lblFinishAllocate.Style.Add("padding", "2px 18px");

                //end
                txtVAToday.ReadOnly = true;

                if (IsShipped == 1)
                {
                    txtCutToday.CssClass = "MOProdSecGray ";
                    txtCutReadyToday.CssClass = "MOProdSecGray";
                    txtStitchToday.CssClass = "MOProdSecGray";
                    txtFinishToday.CssClass = "MOProdSecGray";
                    txtVAToday.CssClass = "MOProdSecGray";
                    txtCutTotal.CssClass = "MOProdSecGray do-not-allow-typing";
                    txtCutReadyTotal.CssClass = "MOProdSecGray do-not-allow-typing";
                    txtStitchTotal.CssClass = "MOProdSecGray do-not-allow-typing";
                    txtVATotal.CssClass = "MOProdSecGray do-not-allow-typing";
                    txtFinishTotal.CssClass = "MOProdSecGray do-not-allow-typing";
                    txtcutissuetotal.CssClass = "MOProdSecGray do-not-allow-typing";
                    txtcutissue.CssClass = "MOProdSecGray do-not-allow-typing";
                }


                if (FactorySpecification != 1)
                {
                    if (FinishingShare > 0)
                    {
                        if (!InFactory && !InProductionDepartment && MOOrderDetails.PVATodayWrite)
                        {
                            txtVAToday.Attributes.Add("onclick", "javascript:return ShowSizeSetEntry(" + OrderDetailId + ", 'ValueAdded'," + "'" + StyleNumber + "', " + UnitId + ");");

                        }
                        else if (InFactory && MOOrderDetails.PVATodayWrite)
                        {
                            txtVAToday.Attributes.Add("onclick", "javascript:return ShowSizeSetEntry(" + OrderDetailId + ", 'ValueAdded'," + "'" + StyleNumber + "', " + UnitId + ");");
                        }
                    }
                    if (CuttingShare <= 0)
                    {
                        txtCutToday.ReadOnly = true;
                        txtCutReadyToday.ReadOnly = true;
                        txtcutissue.ReadOnly = true;
                    }
                    if (StitchingShare <= 0)
                    {
                        txtStitchToday.ReadOnly = true;
                    }
                    if (FinishingShare <= 0)
                    {
                        txtFinishToday.ReadOnly = true;
                    }

                }
                else
                {
                    if (FinishingShare > 0)
                    {
                        if (!InFactory && !InProductionDepartment && MOOrderDetails.PVATodayWrite)
                        {
                            txtVAToday.Attributes.Add("onclick", "javascript:return ShowSizeSetEntry(" + OrderDetailId + ", 'ValueAdded'," + "'" + StyleNumber + "', " + UnitId + ");");
                        }
                        else if (InFactory && MOOrderDetails.PVATodayWrite)
                        {
                            txtVAToday.Attributes.Add("onclick", "javascript:return ShowSizeSetEntry(" + OrderDetailId + ", 'ValueAdded'," + "'" + StyleNumber + "', " + UnitId + ");");
                        }
                    }

                    txtCutToday.ReadOnly = true;
                    txtCutReadyToday.ReadOnly = true;
                    txtVAToday.ReadOnly = true;
                    txtStitchToday.ReadOnly = true;
                    txtFinishToday.ReadOnly = true;
                    txtcutissue.ReadOnly = true;

                    txtCutToday.Attributes.Remove("onblur");
                    txtCutReadyToday.Attributes.Remove("onblur");
                    txtVAToday.Attributes.Remove("onblur");
                    txtStitchToday.Attributes.Remove("onblur");
                    txtFinishToday.Attributes.Remove("onblur");
                    txtcutissue.Attributes.Remove("onclick");
                }
                int IsOldShipped = 0;
                if (ExFactory != DateTime.MinValue)
                {
                    TimeSpan t = (DateTime.Now.Date - ExFactory.Date);
                    IsOldShipped = Convert.ToInt32(t.TotalDays) > 30 ? 1 : 0;
                }

                if (FinishingShare > 0)
                {
                    if (!InFactory && !InProductionDepartment && MOOrderDetails.PVATotalWrite)
                    {
                        txtVATotal.Attributes.Add("onclick", "javascript:return ShowSizeHistory(" + OrderId + "," + OrderDetailId + ", 'ValueAdded','" + StyleNumber + "', " + IsShipped + ", " + UnitId + ", " + IsOldShipped + ");");
                    }
                    else if (InFactory && MOOrderDetails.PVATotalWrite)
                    {
                        txtVATotal.Attributes.Add("onclick", "javascript:return ShowSizeHistory(" + OrderId + "," + OrderDetailId + ", 'ValueAdded','" + StyleNumber + "', " + IsShipped + ", " + UnitId + ", " + IsOldShipped + ");");
                    }
                }

                //int StitchQty_OutHouse = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "StitchQty_OutHouse"));               
                //if (StitchQty_OutHouse > 0)
                //{
                //    if (FinishingShare > 0)
                //    {
                //        txtFinishToday.ReadOnly = false;
                //    }
                //}

                // Added by ravi kumar on 21/2/18
                if (UnitId != 3 && UnitId != 11 && UnitId != 96 && UnitId != 120)
                {
                    if (DataBinder.Eval(e.Item.DataItem, "LineNoOut").ToString() == "Line")
                    {
                        lbllineno.Text = "Plnd";
                    }
                    else if (DataBinder.Eval(e.Item.DataItem, "LineNoOut").ToString() == "pndg LP")
                    {

                        txtStitchToday.Enabled = false;
                        txtFinishToday.Enabled = false;
                        lbllineno.Text = "Pndg LP";
                        lbllineno.ToolTip = "Line not allocated";
                    }

                    if(lblStitchingAllocate.Text != "") 
                    txtStitchToday.Attributes.Add("onclick", "javascript:return Stitch_Finish_QtyUpdate(" + OrderId + ", " + OrderDetailId + ", " + UnitId + ", 'Stitch');");
                    if (lblFinishAllocate.Text != "")
                    {
                      //objorderdetail.
                        txtFinishToday.Attributes.Add("onclick", "javascript:return Stitch_Finish_QtyUpdate(" + OrderId + ", " + OrderDetailId + ", " + UnitId + ", 'Finish');");
                    }

                    if ((ApplicationHelper.LoggedInUser.UserData.DesignationID == 45))
                    {
                        txtFinishToday.Enabled = true;
                        txtStitchToday.Enabled = true;
                        txtcutissue.Enabled = true;
                    }
                    else
                    {
                        txtFinishToday.Enabled = false;
                        txtStitchToday.Enabled = false;
                        txtcutissue.Enabled = false;
                    }
                }
                else
                {
                    if (DataBinder.Eval(e.Item.DataItem, "LineNo") != null)
                    {
                        string LineNo = DataBinder.Eval(e.Item.DataItem, "LineNo").ToString();
                        if (LineNo != "")
                            lbllineno.Text = LineNo;
                        else
                        {
                            txtStitchToday.Enabled = false;
                            txtFinishToday.Enabled = false;
                        }
                    }
                   
                    //if (DataBinder.Eval(e.Item.DataItem, "LineNo").ToString() != null)
                    //{
                    //    string LineNo = DataBinder.Eval(e.Item.DataItem, "LineNo").ToString();
                    //    if (LineNo != "")
                    //        lbllineno.Text = LineNo;
                    //    else
                    //    {
                    //        txtStitchToday.Enabled = false;
                    //        txtFinishToday.Enabled = false;
                    //    }
                    //}
                }
                // End Added by ravi kumar on 21/2/18


                //================================================================================
                CuttingShareAll = CuttingShareAll + CuttingShare;

                if(OutHouseHalfStitch == 0)
                    StitchingShareAll = StitchingShareAll + StitchingShare;

                FinishingShareAll = FinishingShareAll + FinishingShare;

                TotalCutPcsAll = TotalCutPcsAll + TotalCutPcs;
                TotalCutReadyAll = TotalCutReadyAll + TotalCutReady;
                TotalStitchedAll = TotalStitchedAll + TotalStitched;
                TotalFinishedAll = TotalFinishedAll + TotalFinished;
                TotalValueAddedAll = TotalValueAddedAll + TotalValueAddedQty;
                TotalCutIssueAll = TotalCutIssueAll + CutIssueQtyTotal;
                TotalRescanAll = TotalRescanAll + RescanTotalValue;
                TotalPendingRescan = TotalPendingRescan + RescanPendingValue;
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                HtmlTableCell tdVATotalfoter = (HtmlTableCell)e.Item.FindControl("tdVATotalfoter");
                HtmlTableCell tdrescanFooter = (HtmlTableCell)e.Item.FindControl("tdrescanFooter");

                if (!string.IsNullOrEmpty(IsVAcomplete))
                {
                    tdVATotalfoter.Visible = false;
                }
                Label lblFactoryName_Footer = (Label)e.Item.FindControl("lblFactoryName_Footer");
                Label lblCutAllocate_Footer = (Label)e.Item.FindControl("lblCutAllocate_Footer");
                Label lblStitchingAllocate_Footer = (Label)e.Item.FindControl("lblStitchingAllocate_Footer");
                Label lblFinishAllocate_Footer = (Label)e.Item.FindControl("lblFinishAllocate_Footer");

                Label lblCutTotal_Footer = (Label)e.Item.FindControl("lblCutTotal_Footer");
                Label lblCutReadyTotal_Footer = (Label)e.Item.FindControl("lblCutReadyTotal_Footer");
                Label lblCutIssueFooter = (Label)e.Item.FindControl("lblCutIssueFooter");
                Label lblStitchTotal_Footer = (Label)e.Item.FindControl("lblStitchTotal_Footer");
                Label lblFinishTotal_Footer = (Label)e.Item.FindControl("lblFinishTotal_Footer");
                Label lblVATotal_Footer = (Label)e.Item.FindControl("lblVATotal_Footer");
                Label lblOverallRecanFooter = (Label)e.Item.FindControl("lblOverallRecanFooter");


                Label lblCutTotal_Percent = (Label)e.Item.FindControl("lblCutTotal_Percent");
                Label lblCutReadyTotal_Percent = (Label)e.Item.FindControl("lblCutReadyTotal_Percent");
                Label lblCutIssuetotal_percent = (Label)e.Item.FindControl("lblCutIssuetotal_percent");
                Label lblStitchTotal_Percent = (Label)e.Item.FindControl("lblStitchTotal_Percent");
                Label lblFinishTotal_Percent = (Label)e.Item.FindControl("lblFinishTotal_Percent");
                Label lblVATotal_Percent = (Label)e.Item.FindControl("lblVATotal_Percent");
                Label lblPendingRescanFooter = (Label)e.Item.FindControl("lblPendingRescanFooter");

                // added abhishek 12/4/2016======>if there is only one factory then hide foter row
                HiddenField hdnIsSingleProduction = (HiddenField)e.Item.FindControl("hdnIsSingleProduction");
                HtmlGenericControl DivCuttotal = (HtmlGenericControl)e.Item.FindControl("DivCuttotal");
                HtmlGenericControl DivCutReadyTotal = (HtmlGenericControl)e.Item.FindControl("DivCutReadyTotal");
                HtmlGenericControl DivStitchTotal = (HtmlGenericControl)e.Item.FindControl("DivStitchTotal");
                HtmlGenericControl DivVATotal = (HtmlGenericControl)e.Item.FindControl("DivVATotal");
                HtmlGenericControl DivFinishTotal = (HtmlGenericControl)e.Item.FindControl("DivFinishTotal");
                HtmlGenericControl DivCutIssuetotal = (HtmlGenericControl)e.Item.FindControl("DivCutIssuetotal");
                HtmlGenericControl DivRescanFooter = (HtmlGenericControl)e.Item.FindControl("DivRescanFooter");

                //updated code by bharat 19-feb
                if (IsOnHold == true)
                {
                    DivStitchTotal.Style.Add("Background-color", "#ffc882 !important");
                }
                //end

                if (Convert.ToInt32(IsReScan) == 1)
                {
                    tdrescanFooter.Visible = true;
                    lblOverallRecanFooter.ToolTip = "Overall Total Rescanned Qty.  " + TotalRescanAll;
                    lblPendingRescanFooter.ToolTip = "Overall Pending Rescan Qty.  " + TotalPendingRescan;
                    double RescanTotalValueShareVal = 0.0;
                    double RescanPendingValueShareVal = 0.0;
                    if (Convert.ToDouble(TotalRescanAll) >= 1000)
                        RescanTotalValueShareVal = Math.Round(Convert.ToDouble(TotalRescanAll) / 1000, 1);
                    else
                        RescanTotalValueShareVal = Convert.ToInt32(Convert.ToDouble(TotalRescanAll));

                    if (Convert.ToDouble(TotalPendingRescan) >= 1000)
                        RescanPendingValueShareVal = Math.Round(Convert.ToDouble(TotalPendingRescan) / 1000, 1);
                    else
                        RescanPendingValueShareVal = Convert.ToInt32(Convert.ToDouble(TotalPendingRescan));

                    if (TotalRescanAll >= 1000)
                        lblOverallRecanFooter.Text = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString() + "k";
                    else
                        lblOverallRecanFooter.Text = RescanTotalValueShareVal == 0 ? "" : RescanTotalValueShareVal.ToString();
                    if (TotalPendingRescan >= 1000)
                        lblPendingRescanFooter.Text = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString() + "k";
                    else
                        lblPendingRescanFooter.Text = RescanPendingValueShareVal == 0 ? "" : RescanPendingValueShareVal.ToString();
                }
                else
                {
                    tdrescanFooter.Visible = false;
                }

                //int IsSingleFactory = Convert.ToInt32(hdnIsSingleProduction.Value);

                HtmlTableCell tdcutalloca_foter = (HtmlTableCell)e.Item.FindControl("tdcutalloca_foter");
                HtmlTableCell tdStitchingAllocate_foter = (HtmlTableCell)e.Item.FindControl("tdStitchingAllocate_foter");
                HtmlTableCell tdFinishAllocate_foter = (HtmlTableCell)e.Item.FindControl("tdFinishAllocate_foter");
                HtmlTableCell tdcutissuefotertotal = (HtmlTableCell)e.Item.FindControl("tdcutissuefotertotal");
                // Edit By Prabhaker 15-mar-18
                //if (count_production == 0 || count_production == 1)
                if (IsOuthouse_CutIssue == false)
                {
                    tdcutalloca_foter.Visible = false;
                    tdStitchingAllocate_foter.Visible = false;
                    tdFinishAllocate_foter.Visible = false;
                    tdcutissuefotertotal.Visible = false;
                }
                else
                {
                    //if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 15)
                    //{
                    tdcutissuefotertotal.Visible = true;
                    //}
                    // Edit By Prabhaker 15-mar-18
                }

                //if (counts == 1)
                //{
          //updated code by bharat 19-feb
                //    DivCuttotal.Visible = false;
                //    DivCutReadyTotal.Visible = false;
                //    DivStitchTotal.Visible = false;
                //    DivVATotal.Visible = false;
                //    DivVATotal.Visible = false;
                //    DivFinishTotal.Visible = false;
                //    DivCutIssuetotal.Visible = false;
                //}

                //end

                //if ((ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 15) || (ApplicationHelper.LoggedInUser.UserData.DesignationID == 46))
                // {
                //     tdcutissuefotertotal.Visible = true;
                //     DivCutIssuetotal.Visible = true;
                // }
                //end
                //double CuttingShareAllVal = CuttingShareAll == 0 ? 0 : Math.Round(Convert.ToDouble(CuttingShareAll) / 1000, 1);
                //lblCutAllocate_Footer.Text = CuttingShareAllVal == 0 ? "" : CuttingShareAllVal.ToString() + "k";

                //double StitchingShareAllVal = StitchingShareAll == 0 ? 0 : Math.Round(Convert.ToDouble(StitchingShareAll) / 1000, 1);
                //lblStitchingAllocate_Footer.Text = StitchingShareAllVal == 0 ? "" : StitchingShareAllVal.ToString() + "k";

                //double FinishingShareAllVal = FinishingShareAll == 0 ? 0 : Math.Round(Convert.ToDouble(FinishingShareAll) / 1000, 1);
                //lblFinishAllocate_Footer.Text = FinishingShareAllVal == 0 ? "" : FinishingShareAllVal.ToString() + "k";


                /*
                //double TotalCutPcsAllVal = TotalCutPcsAll == 0 ? 0 : Math.Round(Convert.ToDouble(TotalCutPcsAll) / 1000, 1);
                //lblCutTotal_Footer.Text = TotalCutPcsAllVal == 0 ? "" : TotalCutPcsAllVal.ToString() + "k";
                 
                 double TotalCutReadyAllVal = TotalCutReadyAll == 0 ? 0 : Math.Round(Convert.ToDouble(TotalCutReadyAll) / 1000, 1);
                lblCutReadyTotal_Footer.Text = TotalCutReadyAllVal == 0 ? "" : TotalCutReadyAllVal.ToString() + "k";
                 
                 * 
                 * double TotalStitchedAllVal = TotalStitchedAll == 0 ? 0 : Math.Round(Convert.ToDouble(TotalStitchedAll) / 1000, 1);
                lblStitchTotal_Footer.Text = TotalStitchedAllVal == 0 ? "" : TotalStitchedAllVal.ToString() + "k";
                 * 
                 * 
                 *  double TotalFinishedAllVal = TotalFinishedAll == 0 ? 0 : Math.Round(Convert.ToDouble(TotalFinishedAll) / 1000, 1);
                lblFinishTotal_Footer.Text = TotalFinishedAllVal == 0 ? "" : TotalFinishedAllVal.ToString() + "k";

                double TotalValueAddedAllVal = TotalValueAddedAll == 0 ? 0 : Math.Round(Convert.ToDouble(TotalValueAddedAll) / 1000, 1);
                lblVATotal_Footer.Text = TotalValueAddedAllVal == 0 ? "" : TotalValueAddedAllVal.ToString() + "k";
                 */

                //Add By Prabhaker 15-11-17
                var BiplCutPcsTotal = 0.0; var BiplCutReadyPcsTotal = 0.0; var BiplStitchTotalTotal = 0.0; var BiplFinishTotalTotal = 0.0; var BiplVATotalPcsTotal = 0.0;
                var BiplCutAllocationTotal = 0.0; var BiplStitchAllocationTotal = 0.0; var BiplVAAllocationTotal = 0.0; var BiplCutIssueTotal = 0.0;

                if (Convert.ToDouble(TotalCutPcsAll) >= 1000)
                    BiplCutPcsTotal = Math.Round(Convert.ToDouble(TotalCutPcsAll) / 1000, 1);
                else
                    BiplCutPcsTotal = Convert.ToInt32(Convert.ToDouble(TotalCutPcsAll));
                if (Convert.ToDouble(TotalCutReadyAll) >= 1000)
                    BiplCutReadyPcsTotal = Math.Round(Convert.ToDouble(TotalCutReadyAll) / 1000, 1);
                else
                    BiplCutReadyPcsTotal = Convert.ToInt32(Convert.ToDouble(TotalCutReadyAll));

                if (Convert.ToDouble(TotalCutIssueAll) >= 1000)
                    BiplCutIssueTotal = Math.Round(Convert.ToDouble(TotalCutIssueAll) / 1000, 1);
                else
                    BiplCutIssueTotal = Convert.ToInt32(Convert.ToDouble(TotalCutIssueAll));


                if (Convert.ToDouble(TotalStitchedAll) >= 1000)
                    BiplStitchTotalTotal = Math.Round(Convert.ToDouble(TotalStitchedAll) / 1000, 1);
                else
                    BiplStitchTotalTotal = Convert.ToInt32(Convert.ToDouble(TotalStitchedAll));
                if (Convert.ToDouble(TotalFinishedAll) >= 1000)
                    BiplFinishTotalTotal = Math.Round(Convert.ToDouble(TotalFinishedAll) / 1000, 1);
                else
                    BiplFinishTotalTotal = Convert.ToInt32(Convert.ToDouble(TotalFinishedAll));
                if (Convert.ToDouble(TotalValueAddedAll) >= 1000)
                    BiplVATotalPcsTotal = Math.Round(Convert.ToDouble(TotalValueAddedAll) / 1000, 1);
                else
                    BiplVATotalPcsTotal = Convert.ToInt32(Convert.ToDouble(TotalValueAddedAll));
                if (Convert.ToDouble(CuttingShareAll) >= 1000)
                    BiplCutAllocationTotal = Math.Round(Convert.ToDouble(CuttingShareAll) / 1000, 1);
                else
                    BiplCutAllocationTotal = Convert.ToInt32(Convert.ToDouble(CuttingShareAll));
                if (Convert.ToDouble(StitchingShareAll) >= 1000)
                    BiplStitchAllocationTotal = Math.Round(Convert.ToDouble(StitchingShareAll) / 1000, 1);
                else
                    BiplStitchAllocationTotal = Convert.ToInt32(Convert.ToDouble(StitchingShareAll));
                if (Convert.ToDouble(FinishingShareAll) >= 1000)
                    BiplVAAllocationTotal = Math.Round(Convert.ToDouble(FinishingShareAll) / 1000, 1);
                else
                    BiplVAAllocationTotal = Convert.ToInt32(Convert.ToDouble(FinishingShareAll));

                //var BiplCutPcsTotal = Math.Round(Convert.ToDouble(TotalCutPcsAll) / 1000, 1);
                //var BiplCutReadyPcsTotal = Math.Round(Convert.ToDouble(TotalCutReadyAll) / 1000, 1);
                //var BiplStitchTotalTotal = Math.Round(Convert.ToDouble(TotalStitchedAll) / 1000, 1);
                //var BiplFinishTotalTotal = Math.Round(Convert.ToDouble(TotalFinishedAll) / 1000, 1);
                //var BiplVATotalPcsTotal = Math.Round(Convert.ToDouble(TotalValueAddedAll) / 1000, 1);

                //var BiplCutAllocationTotal = Math.Round(Convert.ToDouble(CuttingShareAll) / 1000, 1);
                //var BiplStitchAllocationTotal = Math.Round(Convert.ToDouble(StitchingShareAll) / 1000, 1);
                //var BiplVAAllocationTotal = Math.Round(Convert.ToDouble(FinishingShareAll) / 1000, 1);





                if (TotalCutPcsAll >= 1000)
                    lblCutTotal_Footer.Text = BiplCutPcsTotal == 0 ? "" : BiplCutPcsTotal.ToString() + "k";
                else
                    lblCutTotal_Footer.Text = BiplCutPcsTotal == 0 ? "" : BiplCutPcsTotal.ToString();

                //lblCutTotal_Footer.Text = BiplCutPcsTotal == 0 ? "" : BiplCutPcsTotal.ToString() + "k";

                if (TotalCutReadyAll >= 1000)
                    lblCutReadyTotal_Footer.Text = BiplCutReadyPcsTotal == 0 ? "" : BiplCutReadyPcsTotal.ToString() + "k";
                else
                    lblCutReadyTotal_Footer.Text = BiplCutReadyPcsTotal == 0 ? "" : BiplCutReadyPcsTotal.ToString();

                if (TotalCutIssueAll >= 1000)
                    lblCutIssueFooter.Text = BiplCutIssueTotal == 0 ? "" : BiplCutIssueTotal.ToString() + "k";
                else
                    lblCutIssueFooter.Text = BiplCutIssueTotal == 0 ? "" : BiplCutIssueTotal.ToString();


                if (TotalStitchedAll >= 1000)
                    lblStitchTotal_Footer.Text = BiplStitchTotalTotal == 0 ? "" : BiplStitchTotalTotal.ToString() + "k";
                else
                    lblStitchTotal_Footer.Text = BiplStitchTotalTotal == 0 ? "" : BiplStitchTotalTotal.ToString();

                //lblCutReadyTotal_Footer.Text = BiplCutReadyPcsTotal == 0 ? "" : BiplCutReadyPcsTotal.ToString() + "k";
                //lblStitchTotal_Footer.Text = BiplStitchTotalTotal == 0 ? "" : BiplStitchTotalTotal.ToString() + "k";



                if (TotalFinishedAll >= 1000)
                    lblFinishTotal_Footer.Text = BiplFinishTotalTotal == 0 ? "" : BiplFinishTotalTotal.ToString() + "k";
                else
                    lblFinishTotal_Footer.Text = BiplFinishTotalTotal == 0 ? "" : BiplFinishTotalTotal.ToString();

                // lblFinishTotal_Footer.Text = BiplFinishTotalTotal == 0 ? "" : BiplFinishTotalTotal.ToString() + "k";
                if (TotalValueAddedAll >= 1000)
                    lblVATotal_Footer.Text = BiplVATotalPcsTotal == 0 ? "" : BiplVATotalPcsTotal.ToString() + "k";
                else
                    lblVATotal_Footer.Text = BiplVATotalPcsTotal == 0 ? "" : BiplVATotalPcsTotal.ToString();



                // lblVATotal_Footer.Text = BiplVATotalPcsTotal == 0 ? "" : BiplVATotalPcsTotal.ToString() + "k";
                if (CuttingShareAll >= 1000)
                    lblCutAllocate_Footer.Text = BiplCutAllocationTotal == 0 ? "" : BiplCutAllocationTotal.ToString() + "k";
                else
                    lblCutAllocate_Footer.Text = BiplCutAllocationTotal == 0 ? "" : BiplCutAllocationTotal.ToString();


                // lblCutAllocate_Footer.Text = BiplCutAllocationTotal == 0 ? "" : BiplCutAllocationTotal.ToString() + "k";


                if (StitchingShareAll >= 1000)
                    lblStitchingAllocate_Footer.Text = BiplStitchAllocationTotal == 0 ? "" : BiplStitchAllocationTotal.ToString() + "k";
                else
                    lblStitchingAllocate_Footer.Text = BiplStitchAllocationTotal == 0 ? "" : BiplStitchAllocationTotal.ToString();

                //lblStitchingAllocate_Footer.Text = BiplStitchAllocationTotal == 0 ? "" : BiplStitchAllocationTotal.ToString() + "k";

                if (FinishingShareAll >= 1000)
                    lblFinishAllocate_Footer.Text = BiplVAAllocationTotal == 0 ? "" : BiplVAAllocationTotal.ToString() + "k";
                else
                    lblFinishAllocate_Footer.Text = BiplVAAllocationTotal == 0 ? "" : BiplVAAllocationTotal.ToString();



                //lblFinishAllocate_Footer.Text = BiplVAAllocationTotal == 0 ? "" : BiplVAAllocationTotal.ToString() + "k";


                //lblCutTotal_Footer.ToolTip = "Overall Cut Qty." + TotalCutPcsAll;
                //System.Drawing.Color.Black;
                //lblCutTotal_Footer.Set(textBox1, "<font color=\"red\">What is tooltip?</font>");

                lblCutTotal_Footer.ToolTip = "Overall Cut Qty.  " + TotalCutPcsAll;
                lblCutReadyTotal_Footer.ToolTip = "Overall Cut Ready Qty.  " + TotalCutReadyAll;
                lblCutIssueFooter.ToolTip = "Overall Cut Issue Qty.  " + TotalCutIssueAll;
                lblStitchTotal_Footer.ToolTip = "Overall Stitched Qty.  " + TotalStitchedAll;
                lblVATotal_Footer.ToolTip = "Overall V.A Qty. " + TotalValueAddedAll;
                lblFinishTotal_Footer.ToolTip = "Overall Finished & Packed Qty.  " + TotalFinishedAll;

                lblCutAllocate_Footer.ToolTip = "Overall Cut/Cut Ready Alloc. Qty.  " + CuttingShareAll;
                lblStitchingAllocate_Footer.ToolTip = "Overall Stitching Alloc. Qty.  " + StitchingShareAll;
                lblFinishAllocate_Footer.ToolTip = "Overall Finishing & Packing Alloc. Qty.  " + FinishingShareAll;

                if (lblCutTotal_Footer.Text == "")
                    lblCutTotal_Footer.Style.Add("padding", "2px 18px");

                if (lblCutIssueFooter.Text == "")
                    lblCutIssueFooter.Style.Add("padding", "2px 18px");

                if (lblCutReadyTotal_Footer.Text == "")
                    lblCutReadyTotal_Footer.Style.Add("padding", "2px 18px");
                if (lblStitchTotal_Footer.Text == "")
                    lblStitchTotal_Footer.Style.Add("padding", "2px 18px");
                if (lblVATotal_Footer.Text == "")
                    lblVATotal_Footer.Style.Add("padding", "2px 18px");
                if (lblFinishTotal_Footer.Text == "")
                    lblFinishTotal_Footer.Style.Add("padding", "2px 18px");

                if (lblCutAllocate_Footer.Text == "")
                    lblCutAllocate_Footer.Style.Add("padding", "2px 18px");
                if (lblStitchingAllocate_Footer.Text == "")
                    lblStitchingAllocate_Footer.Style.Add("padding", "2px 18px");
                if (lblFinishTotal_Footer.Text == "")
                    lblFinishTotal_Footer.Style.Add("padding", "2px 18px");
                //End Of Code


                //abhishek 
                //lblFinishAllocate_Footer.Text = FinishingShareAll == 0 ? "" : String.Format("{0:#,##0}", FinishingShareAll);
                //lblStitchingAllocate_Footer.Text = StitchingShareAll == 0 ? "" : String.Format("{0:#,##0}", StitchingShareAll);
                //lblCutAllocate_Footer.Text = CuttingShareAll == 0 ? "" : String.Format("{0:#,##0}", CuttingShareAll);
                //lblCutTotal_Footer.Text = TotalCutPcsAll == 0 ? "" : String.Format("{0:#,##0}", TotalCutPcsAll);
                //lblCutReadyTotal_Footer.Text = TotalCutReadyAll == 0 ? "" : String.Format("{0:#,##0}", TotalCutReadyAll);
                //lblStitchTotal_Footer.Text = TotalStitchedAll == 0 ? "" : String.Format("{0:#,##0}", TotalStitchedAll);
                //lblFinishTotal_Footer.Text = TotalFinishedAll == 0 ? "" : String.Format("{0:#,##0}", TotalFinishedAll);
                //lblVATotal_Footer.Text = TotalValueAddedAll == 0 ? "" : String.Format("{0:#,##0}", TotalValueAddedAll);
                //edn 



                if (Math.Round(((Convert.ToDouble(TotalCutPcsAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0) > 0)
                    lblCutTotal_Percent.Text = Math.Round(((Convert.ToDouble(TotalCutPcsAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0).ToString() + "%";

                if (Math.Round(((Convert.ToDouble(TotalCutReadyAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0) > 0)
                    lblCutReadyTotal_Percent.Text = Math.Round(((Convert.ToDouble(TotalCutReadyAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0).ToString() + "%";

                if (Math.Round(((Convert.ToDouble(TotalCutIssueAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0) > 0)
                    lblCutIssuetotal_percent.Text = Math.Round(((Convert.ToDouble(TotalCutIssueAll) / (CuttingShareAll == 0 ? 1 : CuttingShareAll)) * 100), 0).ToString() + "%";


                if (Math.Round(((Convert.ToDouble(TotalStitchedAll) / (StitchingShareAll == 0 ? 1 : StitchingShareAll)) * 100), 0) > 0)
                    lblStitchTotal_Percent.Text = Math.Round(((Convert.ToDouble(TotalStitchedAll) / (StitchingShareAll == 0 ? 1 : StitchingShareAll)) * 100), 0).ToString() + "%";

                if (Math.Round(((Convert.ToDouble(TotalFinishedAll) / (FinishingShareAll == 0 ? 1 : FinishingShareAll)) * 100), 0) > 0)
                    lblFinishTotal_Percent.Text = Math.Round(((Convert.ToDouble(TotalFinishedAll) / (FinishingShareAll == 0 ? 1 : FinishingShareAll)) * 100), 0).ToString() + "%";

                if (Math.Round(((Convert.ToDouble(TotalValueAddedAll) / (FinishingShareAll == 0 ? 1 : FinishingShareAll)) * 100), 0) > 0)
                    lblVATotal_Percent.Text = Math.Round(((Convert.ToDouble(TotalValueAddedAll) / (FinishingShareAll == 0 ? 1 : FinishingShareAll)) * 100), 0).ToString() + "%";

                CuttingShareAll = 0;
                StitchingShareAll = 0;
                FinishingShareAll = 0;
                TotalCutPcsAll = 0;
                TotalFinishedAll = 0;
                TotalValueAddedAll = 0;
                TotalCutIssueAll = 0;
                TotalRescanAll = 0;
                TotalPendingRescan = 0;
                //Gajendra MO                   
                if (IsShipped == false)
                {
                    lblCutReadyTotal_Percent.CssClass = "MOProdSecGray";
                    lblStitchTotal_Percent.CssClass = "MOProdSecGray";
                    lblVATotal_Percent.CssClass = "MOProdSecGray";
                    lblFinishTotal_Percent.CssClass = "MOProdSecGray";
                    lblCutTotal_Percent.CssClass = "MOProdSecGray";
                    lblCutIssuetotal_percent.CssClass = "MOProdSecGray";
                }
                if (IsShipped == true)
                {

                    lblCutTotal_Footer.CssClass = "MOProdSecGray";
                    lblCutReadyTotal_Footer.CssClass = "MOProdSecGray";
                    lblCutIssueFooter.CssClass = "MOProdSecGray";
                    lblStitchTotal_Footer.CssClass = "MOProdSecGray";
                    lblFinishTotal_Footer.CssClass = "MOProdSecGray";
                    lblStitchingAllocate_Footer.Attributes.Add("style", "color:gray");//updated code by bharat on 25-feb 
                    lblFinishAllocate_Footer.Attributes.Add("style", "color:gray");//updated code by bharat on 25-feb 
                    lblCutAllocate_Footer.Attributes.Add("style", "color:gray");//updated code by bharat on 25-feb 
                    lblVATotal_Footer.Attributes.Add("style", "color:gray");//updated code by bharat on 25-feb 

                    lblCutReadyTotal_Percent.CssClass = "MOProdSecGray";
                    lblStitchTotal_Percent.CssClass = "MOProdSecGray";
                    lblVATotal_Percent.CssClass = "MOProdSecGray";
                    lblFinishTotal_Percent.CssClass = "MOProdSecGray";
                    lblCutTotal_Percent.CssClass = "MOProdSecGray";
                    lblCutIssuetotal_percent.CssClass = "MOProdSecGray";
                    DivStitchTotal.Attributes.Add("style", "background:#f9f9fa !important;border-bottom: 1px solid #d6d6d699 !important;");//updated code by bharat on 19-feb 

                }
            }
        }
    }
}







