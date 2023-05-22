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
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iKandi.BLL;
using System.Collections.Generic;
namespace iKandi.Web.Admin.FitsSample
{
    public partial class FitsEtaPopup : System.Web.UI.Page
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
        public int UnitId
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

        //end  
       

        iKandi.Common.Permission prmSection = new iKandi.Common.Permission();
        MOOrderDetails ord = new MOOrderDetails();
      
        public int OrderDetailId
        {
            get;
            set;
        }
        public void GetQueryString()
        {
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"].ToString());
            }

        }
        public void SetPermission()
        {
            string DesignationID = ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString();
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox lblPatternSampleDate = (TextBox)row.FindControl("lblPatternSampleDate");
                TextBox lblCuttingSheetDate = (TextBox)row.FindControl("lblCuttingSheetDate");
                TextBox lblProductionFileDate = (TextBox)row.FindControl("lblProductionFileDate");
                
                if (DesignationID == "18" || DesignationID == "46" || DesignationID == "19" || DesignationID == "13")
                {
                    break;                 
                }
                else
                {
                    lblPatternSampleDate.Enabled = false;
                    lblCuttingSheetDate.Enabled = false;
                    lblProductionFileDate.Enabled = false;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            GetQueryString();
            BindGrd();
            SetPermission();
        }
        public void BindGrd()
        {
            if (Session["objOrderDetail"] != null)
            {

                List<MOOrderDetails> objOrderDetail = Session["objOrderDetail"] as List<MOOrderDetails>;
                //objOrderDetail= objOrderDetail.Where(t => objOrderDetail.Contains(t.OrderDetailID, OrderDetailId));
                List<MOOrderDetails> objOrderDetails = objOrderDetail.FindAll(delegate(MOOrderDetails a) { return ((a.OrderDetailID == OrderDetailId)); });
                GridView1.DataSource = objOrderDetails;
                GridView1.DataBind();
            }
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
            Label lblSeprator = e.Row.FindControl("lblSeprator") as Label;
            Label lblBusinessTag = e.Row.FindControl("lblBusinessTag") as Label;
            Label lblBusiness = e.Row.FindControl("lblBusiness") as Label;
            Label lblFitsName = e.Row.FindControl("lblFitsName") as Label;
            Label lblFitsRemark = e.Row.FindControl("lblFitsRemark") as Label;
            HiddenField hdnFitsRemarks = e.Row.FindControl("hdnFitsRemarks") as HiddenField;

            Label lblShippingName = e.Row.FindControl("lblShippingName") as Label;
            Label lblshippingRemarks = e.Row.FindControl("lblshippingRemarks") as Label;
            HiddenField hdnShipping = e.Row.FindControl("hdnShipping") as HiddenField;
            HtmlAnchor lnkShipping = e.Row.FindControl("lnkShipping") as HtmlAnchor;

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
            //td1p1.Style.Add("background-color", od.BulkApproval1BackColor);
            //td1p2.Style.Add("background-color", od.BulkApproval2BackColor);
            //td1p3.Style.Add("background-color", od.BulkApproval3BackColor);
            //td1p4.Style.Add("background-color", od.BulkApproval4BackColor);
            ////END
            ////Added By Ashish on 25/2/2015
            //td3f1.Style.Add("background-color", od.Percent1BackColor);
            //td6f2.Style.Add("background-color", od.Percent2BackColor);
            //td9f3.Style.Add("background-color", od.Percent3BackColor);
            //td12f4.Style.Add("background-color", od.Percent4BackColor);
            //END


            //Added By Ashish on 3/3/2014
            //For Permission
            //HtmlAnchor spnSerialNumber = (HtmlAnchor)e.Row.FindControl("hypSerial");
            //Label lblSerial = e.Row.FindControl("lblSerial") as Label;
            //HtmlGenericControl spnStyleNumber = (HtmlGenericControl)e.Row.FindControl("spnStyleNumber");
            //Label lblStyleNumber = e.Row.FindControl("lblStyleNumber") as Label;
            //HtmlGenericControl spnBiplPrice = (HtmlGenericControl)e.Row.FindControl("spnBiplPrice");
            //Label lblBiplPrice = (Label)e.Row.FindControl("lblBiplPrice");

            //Label lbldressPrice = (Label)e.Row.FindControl("lbldressPrice");
            //HtmlGenericControl spnDepartment = (HtmlGenericControl)e.Row.FindControl("spnDepartment");
            //Label lblDepartment = (Label)e.Row.FindControl("lblDepartment");
            //Label lblStatusMode = (Label)e.Row.FindControl("lblStatusMode");
            //HtmlGenericControl exFactory = (HtmlGenericControl)e.Row.FindControl("exFactory");
            //Label lblexFactory = (Label)e.Row.FindControl("lblexFactory");
            //HtmlGenericControl spnmdano = (HtmlGenericControl)e.Row.FindControl("spnmdano");
            //Label bllmda = (Label)e.Row.FindControl("bllmda");
            //HtmlAnchor hypstatusmode1 = e.Row.FindControl("hypstatusmode") as HtmlAnchor;

            //HtmlGenericControl fabric1name = (HtmlGenericControl)e.Row.FindControl("fabric1name");
            //HtmlGenericControl fabric2name = (HtmlGenericControl)e.Row.FindControl("fabric2name");
            //HtmlGenericControl fabric3name = (HtmlGenericControl)e.Row.FindControl("fabric3name");
            //HtmlGenericControl fabric4name = (HtmlGenericControl)e.Row.FindControl("fabric4name");

            //HtmlTableRow trFirstFabric = (HtmlTableRow)e.Row.FindControl("trFirstFabric");
            //HtmlTableRow trfirstprint = (HtmlTableRow)e.Row.FindControl("trfirstprint");
            //HtmlTableRow trsecFabric = (HtmlTableRow)e.Row.FindControl("trsecFabric");
            //HtmlTableRow trsecPrint = (HtmlTableRow)e.Row.FindControl("trsecPrint");
            //HtmlTableRow trthirdFabric = (HtmlTableRow)e.Row.FindControl("trthirdFabric");
            //HtmlTableRow trthirdprint = (HtmlTableRow)e.Row.FindControl("trthirdprint");
            //HtmlTableRow trfourFabric = (HtmlTableRow)e.Row.FindControl("trfourFabric");
            //HtmlTableRow trfourprint = (HtmlTableRow)e.Row.FindControl("trfourprint");

            //HyperLink hlkViewMe = (HyperLink)e.Row.FindControl("hlkViewMe");
            //if (od.OBfile != "")
            //    hlkViewMe.NavigateUrl = "~/Uploads/Photo/" + od.OBfile;

            //Label lblFab1 = (Label)e.Row.FindControl("lblFab1");
            //Label lblFab2 = (Label)e.Row.FindControl("lblFab2");
            //Label lblFab3 = (Label)e.Row.FindControl("lblFab3");
            //Label lblFab4 = (Label)e.Row.FindControl("lblFab4");
            ////added by abhishek on 22/2/2016
            ////HtmlAnchor lnkreallocation = e.Row.FindControl("lnkreallocation") as HtmlAnchor;
            //HyperLink lnkreallocation = e.Row.FindControl("lnkreallocation") as HyperLink;
            //lnkreallocation.NavigateUrl = "~/Internal/Merchandising/ReAllocationForm.aspx?OrderDetailId=" + od.OrderDetailID + "+&styleId=" + (od.ParentOrder as iKandi.Common.Order).Style.StyleID.ToString();
            //if (lnkreallocation != null)
            //{
            //    if (od.ReadWriteReallocationLink == true)
            //    {
            //        lnkreallocation.Enabled = true;
            //    }
            //}

            //int Quantity = Convert.ToInt32(od.Quantity);
            //if (spnSerialNumber != null)
            //{
            //    if (od.bSerialNowrite != true)
            //    {
            //        if (od.bSerialNo != true)
            //        {
            //            spnSerialNumber.Visible = false;
            //            lblSerial.Visible = false;
            //        }
            //        else
            //        {
            //            spnSerialNumber.Visible = false;
            //            lblSerial.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnSerialNumber.Visible = true;
            //        lblSerial.Visible = false;
            //    }
            //}
            //if (spnStyleNumber != null)
            //{
            //    if (od.bStyleNowrite != true)
            //    {
            //        if (od.bStylelNo != true)
            //        {
            //            spnStyleNumber.Visible = false;
            //            lblStyleNumber.Visible = false;
            //        }
            //        else
            //        {
            //            spnStyleNumber.Visible = false;
            //            lblStyleNumber.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnStyleNumber.Visible = true;
            //        lblStyleNumber.Visible = false;
            //    }
            //}
            //if (spnBiplPrice != null)
            //{
            //    if (od.bBIPLPricewrite != true)
            //    {
            //        if (od.bBIPLPrice != true)
            //        {
            //            spnBiplPrice.Visible = false;
            //            lblBiplPrice.Visible = false;
            //        }
            //        else
            //        {
            //            spnBiplPrice.Visible = false;
            //            lblBiplPrice.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnBiplPrice.Visible = true;
            //        lblBiplPrice.Visible = false;
            //    }
            //}
            //abhishek on 11/7/2016
            //if (lbldressPrice != null)
            //{

            //    if (lbldressPrice.Text == "" || lbldressPrice.Text == "0.00")
            //    {
            //        lbldressPrice.Visible = false;
            //    }
            //    else
            //    {
            //        string OldPrice = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Company == iKandi.Common.Company.Boutique ?
            //        Convert.ToDouble((od.ParentOrder as iKandi.Common.Order).BiplPrice).ToString("N2") : Convert.ToDouble(od.iKandiPrice).ToString("N2");

            //        string strff = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto));
            //        lbldressPrice.Text = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto)) + "" + lbldressPrice.Text + " |";
            //        if (Convert.ToString(od.DressPrice) == OldPrice)
            //        {
            //            lbldressPrice.Visible = false;
            //        }
            //        else
            //        {
            //            spnBiplPrice.Attributes.Add("Class", "redcrossline");
            //        }
            //    }
            //}

            //end abhishek on 13/7/2016
            //lblPriceSymbol.Visible = od.bIKANDIPriceGrossRead;
            //lblPriceSymbol.Enabled = od.bIKANDIPriceGrosswrite;
            //lblikandiGross.Visible = od.bIKANDIPriceGrossRead;
            //lblikandiGross.Enabled = od.bIKANDIPriceGrosswrite;

            //lblIkandiDiscount.Visible = od.bIKANDIPriceRead;
            //lblIkandiDiscount.Enabled = od.bIKANDIPricewrite;
            //lblIkandiPriceTag.Visible = od.bIKANDIPriceRead;
            //lblIkandiPriceTag.Enabled = od.bIKANDIPricewrite;
            //lblMargin.Text = Convert.ToString(od.Margin) + "%";
            //lblMargin.Visible = od.bMarginRead;
            //lblMargin.Enabled = od.bMarginwrite;

            //lblBusiness.Visible = od.bBusinessRead;
            //lblBusiness.Enabled = od.bBusinesswrite;
            //lblBusinessTag.Visible = od.bBusinessRead;
            //lblBusinessTag.Enabled = od.bBusinesswrite;

            ////added by 13/7/2016 abhishek if buyer of ikandi then hide all below lable else show
            //if ((od.IsIkandiClient == 1))
            //{
            //    lblIkandiPriceTag.Visible = true;
            //    lblIkandiDiscount.Visible = true;
            //    lblMargin.Visible = true;
            //    lblSeprator.Visible = true;

            //}
            //else
            //{
            //    lblIkandiPriceTag.Visible = false;
            //    lblIkandiDiscount.Visible = false;
            //    lblSeprator.Visible = false;
            //    lblMargin.Visible = false;
            //}
            ////end 

            //if (spnDepartment != null)
            //{
            //    if (od.bDepartmentwrite != true)
            //    {
            //        if (od.bDepartmentRead != true)
            //        {
            //            spnDepartment.Visible = false;
            //            lblDepartment.Visible = false;
            //        }
            //        else
            //        {
            //            spnDepartment.Visible = false;
            //            lblDepartment.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnDepartment.Visible = true;
            //        lblDepartment.Visible = false;
            //    }
            //}

            //if (hypstatusmode1 != null)
            //{
            //    if (od.bStatuswrite != true)
            //    {
            //        if (od.bStatusRead != true)
            //        {
            //            hypstatusmode1.Visible = false;
            //            lblStatusMode.Visible = false;
            //        }
            //        else
            //        {
            //            hypstatusmode1.Visible = false;
            //            lblStatusMode.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        hypstatusmode1.Visible = true;
            //        lblStatusMode.Visible = false;
            //    }
            //}

            //HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("divexFactory");
            //HtmlGenericControl divAgreement = (HtmlGenericControl)e.Row.FindControl("divAgreement");
            //Label lblPendingAgrement = e.Row.FindControl("lblPendingAgrement") as Label;


            //if (od.BIPLAgreementPending == 1)
            //{
            //    divAgreement.Visible = true;
            //    if (od.IsShiped == true)
            //        lblPendingAgrement.Style.Add("color", "#807F80");
            //    else
            //        lblPendingAgrement.Style.Add("color", "red");
            //}
            //else
            //    divAgreement.Visible = false;


            //if (exFactory != null)
            //{
            //    if (od.bExFactorywrite != true)
            //    {
            //        if (od.bExFactoryRead != true)
            //        {
            //            exFactory.Visible = false;
            //            lblexFactory.Visible = false;
            //            divexFactory.Visible = false;
            //        }
            //        else
            //        {
            //            exFactory.Visible = false;
            //            lblexFactory.Visible = true;
            //            divexFactory.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        exFactory.Visible = true;
            //        lblexFactory.Visible = false;
            //        divexFactory.Visible = false;
            //    }
            //}
            //if (spnmdano != null)
            //{
            //    if (od.bMDAwrite != true)
            //    {
            //        if (od.bMDARead != true)
            //        {
            //            spnmdano.Visible = false;
            //            bllmda.Visible = false;
            //        }
            //        else
            //        {
            //            spnmdano.Visible = false;
            //            bllmda.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnmdano.Visible = true;
            //        bllmda.Visible = false;
            //    }
            //}

            //HtmlGenericControl maindivmda = e.Row.FindControl("maindivmda") as HtmlGenericControl;
            //HiddenField hdnmda = e.Row.FindControl("hdnmda") as HiddenField;

            //HtmlGenericControl lnkBalancePercentCut = e.Row.FindControl("lnkBalancePercentCut") as HtmlGenericControl;
            //HtmlGenericControl lnkBPerCut = e.Row.FindControl("lnkBPerCut") as HtmlGenericControl;
            //HtmlGenericControl divBlank = e.Row.FindControl("divBlank") as HtmlGenericControl;
            //if (lnkBalancePercentCut != null)
            //{
            //    if (od.POverallWrite != true)
            //    {
            //        if (od.POverallRead != true)
            //        {
            //            lnkBalancePercentCut.Visible = false;
            //            lnkBPerCut.Visible = false;
            //            divBlank.Visible = true;
            //        }
            //        else
            //        {
            //            lnkBalancePercentCut.Visible = false;
            //            lnkBPerCut.Visible = true;
            //            divBlank.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        lnkBalancePercentCut.Visible = true;
            //        lnkBPerCut.Visible = false;
            //        divBlank.Visible = false;
            //    }
            //}

            //Added by Ashish on 4/4/2014
            //HtmlGenericControl BalancePercentStitchedIssued = e.Row.FindControl("BalancePercentStitchedIssued") as HtmlGenericControl;
            //HtmlGenericControl BPercentStitchedIssued = e.Row.FindControl("BPercentStitchedIssued") as HtmlGenericControl;
            //HtmlGenericControl BPercentStitchedIssuedBlanck = e.Row.FindControl("BPercentStitchedIssuedBlanck") as HtmlGenericControl;

            //HtmlGenericControl divStitchedETA = e.Row.FindControl("divStitchedETA") as HtmlGenericControl;
            //HtmlGenericControl divEmbETA = e.Row.FindControl("divEmbETA") as HtmlGenericControl;
            //HtmlGenericControl divPacked = e.Row.FindControl("divPacked") as HtmlGenericControl;
            //if (BalancePercentStitchedIssued != null)
            //{
            //    if (od.POverallWrite != true)
            //    {
            //        if (od.POverallRead != true)
            //        {
            //            BalancePercentStitchedIssued.Visible = false;
            //            BPercentStitchedIssued.Visible = false;
            //            BPercentStitchedIssuedBlanck.Visible = true;
            //        }
            //        else
            //        {
            //            BalancePercentStitchedIssued.Visible = false;
            //            BPercentStitchedIssued.Visible = true;
            //            BPercentStitchedIssuedBlanck.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        BalancePercentStitchedIssued.Visible = true;
            //        BPercentStitchedIssued.Visible = false;
            //        BPercentStitchedIssuedBlanck.Visible = false;
            //    }
            //}


            //HtmlGenericControl divBalancePercentPacked = e.Row.FindControl("divBalancePercentPacked") as HtmlGenericControl;
            //HtmlGenericControl divlblBalancePercentPacked = e.Row.FindControl("divlblBalancePercentPacked") as HtmlGenericControl;
            //HtmlGenericControl divBalancePercentPackedBlanck = e.Row.FindControl("divBalancePercentPackedBlanck") as HtmlGenericControl;
            //if (divBalancePercentPacked != null)
            //{
            //    if (od.POverallWrite != true)
            //    {
            //        if (od.POverallRead != true)
            //        {
            //            divBalancePercentPacked.Visible = false;
            //            divlblBalancePercentPacked.Visible = false;
            //            divBalancePercentPackedBlanck.Visible = true;
            //        }
            //        else
            //        {
            //            divBalancePercentPacked.Visible = false;
            //            divlblBalancePercentPacked.Visible = true;
            //            divBalancePercentPackedBlanck.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        divBalancePercentPacked.Visible = true;
            //        divlblBalancePercentPacked.Visible = false;
            //        divBalancePercentPackedBlanck.Visible = false;
            //    }
            //}


            //Label lblFabric1Details = e.Row.FindControl("lblFabric1Details") as Label;
            //Label lblFabric2Details = e.Row.FindControl("lblFabric2Details") as Label;
            //Label lblFabric3Details = e.Row.FindControl("lblFabric3Details") as Label;
            //Label lblFabric4Details = e.Row.FindControl("lblFabric4Details") as Label;

            //Label lblfabricApprovalColor1 = e.Row.FindControl("lblfabricApprovalColor1") as Label;
            //Label lblfabricApprovalColor2 = e.Row.FindControl("lblfabricApprovalColor2") as Label;
            //Label lblfabricApprovalColor3 = e.Row.FindControl("lblfabricApprovalColor3") as Label;
            //Label lblfabricApprovalColor4 = e.Row.FindControl("lblfabricApprovalColor4") as Label;

            //if (od.FQualityWrite != true)
            //{
            //    if (od.FQualityRead != true)
            //    {
            //        fabric1name.Visible = false;
            //        lblFab1.Visible = false;
            //        fabric2name.Visible = false;
            //        lblFab2.Visible = false;
            //        fabric3name.Visible = false;
            //        lblFab3.Visible = false;
            //        fabric4name.Visible = false;
            //        lblFab4.Visible = false;
            //        lblFabric1Details.Visible = false;
            //        lblFabric2Details.Visible = false;
            //        lblFabric3Details.Visible = false;
            //        lblFabric4Details.Visible = false;

            //        lblfabricApprovalColor1.Visible = false;
            //        lblfabricApprovalColor2.Visible = false;
            //        lblfabricApprovalColor3.Visible = false;
            //        lblfabricApprovalColor4.Visible = false;

            //    }
            //    else
            //    {
            //        fabric1name.Visible = false;
            //        lblFab1.Visible = true;
            //        fabric2name.Visible = false;
            //        lblFab2.Visible = true;
            //        fabric3name.Visible = false;
            //        lblFab3.Visible = true;
            //        fabric4name.Visible = false;
            //        lblFab4.Visible = true;

            //        lblFabric1Details.Visible = true;
            //        lblFabric2Details.Visible = true;
            //        lblFabric3Details.Visible = true;
            //        lblFabric4Details.Visible = true;

            //        lblfabricApprovalColor1.Visible = true;
            //        lblfabricApprovalColor2.Visible = true;
            //        lblfabricApprovalColor3.Visible = true;
            //        lblfabricApprovalColor4.Visible = true;
            //    }
            //}
            //else
            //{
            //    if (fabric1name != null)
            //    {
            //        if (od.CutWidth1 != 0)
            //        {
            //            lblCutwidth1.Text = "/" + od.CutWidth1 + " in";
            //            lblCutwidth1.Visible = true;

            //        }
            //        fabric1name.Visible = true;
            //        lblFab1.Visible = false;
            //        lblFabric1Details.Visible = true;
            //        lblfabricApprovalColor1.Visible = true;
            //        fabric1name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric1name.InnerText + "', " + "'" + lblFabric1Details.Text + "', '" + 1 + "');");
            //    }
            //    if (fabric2name != null)
            //    {
            //        if (od.CutWidth2 != 0)
            //        {
            //            lblCutwidth2.Text = "/" + od.CutWidth2 + " in";
            //            lblCutwidth2.Visible = true;

            //        }
            //        fabric2name.Visible = true;
            //        lblFab2.Visible = false;
            //        lblFabric2Details.Visible = true;
            //        lblfabricApprovalColor2.Visible = true;
            //        fabric2name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric2name.InnerText + "', " + "'" + lblFabric2Details.Text + "', '" + 2 + "');");
            //    }
            //    if (fabric3name != null)
            //    {
            //        if (od.CutWidth3 != 0)
            //        {
            //            lblCutwidth3.Text = "/" + od.CutWidth3 + " in";
            //            lblCutwidth3.Visible = true;
            //        }
            //        fabric3name.Visible = true;
            //        lblFab3.Visible = false;
            //        lblFabric3Details.Visible = true;
            //        lblfabricApprovalColor3.Visible = true;
            //        fabric3name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric3name.InnerText + "', " + "'" + lblFabric3Details.Text + "', '" + 3 + "');");
            //    }
            //    if (fabric4name != null)
            //    {
            //        if (od.CutWidth4 != 0)
            //            lblCutwidth4.Text = "/" + od.CutWidth4 + " in";
            //        lblCutwidth4.Visible = true;
            //        fabric4name.Visible = true;
            //        lblFab4.Visible = false;
            //        lblFabric4Details.Visible = true;
            //        lblfabricApprovalColor4.Visible = true;
            //        fabric4name.Attributes.Add("onclick", "javascript:return ShowFabricApproval(" + od.ParentOrder.Style.client.ClientID + ", " + od.OrderID + ", " + od.OrderDetailID + ", " + "'" + fabric4name.InnerText + "', " + "'" + lblFabric4Details.Text + "','" + 4 + "');");
            //    }
            //}
            //HtmlGenericControl spnInline = (HtmlGenericControl)e.Row.FindControl("spnInline");
            //Label lblInline = (Label)e.Row.FindControl("lblInline");
            //if (spnInline != null)
            //{
            //    if (od.FitsTgtDateWrite != true)
            //    {
            //        if (od.FitsTgtDateRead != true)
            //        {
            //            spnInline.Visible = false;
            //            lblInline.Visible = false;
            //        }
            //        else
            //        {
            //            spnInline.Visible = false;
            //            lblInline.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnInline.Visible = true;
            //        lblInline.Visible = false;
            //    }
            //}

            //HtmlGenericControl spanFabTracking = (HtmlGenericControl)e.Row.FindControl("spanFabTracking");
            //if (spanFabTracking != null)
            //{
            //    if (od.FFabricTrackingWrite == true || od.FFabricTrackingRead == true)
            //    {
            //        spanFabTracking.Visible = true;
            //    }
            //    else
            //    {
            //        spanFabTracking.Visible = false;
            //    }

            //}

            //HtmlAnchor spnOrdSam = (HtmlAnchor)e.Row.FindControl("spnOrdSam");
            //Label lblOrdSam = (Label)e.Row.FindControl("lblOrdSam");
            //HtmlAnchor spnStcSam = (HtmlAnchor)e.Row.FindControl("spnStcSam");
            //Label lblSTC = (Label)e.Row.FindControl("lblSTC");
            //if (spnOrdSam != null)
            //{
            //    if (od.FitsOrderSamWrite != true)
            //    {
            //        if (od.FitsOrderSamRead != true)
            //        {
            //            spnOrdSam.Visible = false;
            //            lblOrdSam.Visible = false;
            //        }
            //        else
            //        {
            //            spnOrdSam.Visible = false;
            //            lblOrdSam.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnOrdSam.Visible = true;
            //        lblOrdSam.Visible = false;
            //    }
            //}

            //if (spnStcSam != null)
            //{
            //    if (od.FitsSTCSamWrite != true)
            //    {
            //        if (od.FitsSTCSamRead != true)
            //        {
            //            spnStcSam.Visible = false;
            //            lblSTC.Visible = false;
            //        }
            //        else
            //        {
            //            spnStcSam.Visible = false;
            //            lblSTC.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        spnStcSam.Visible = true;
            //        lblSTC.Visible = false;
            //    }
            //}

            ////END 
            ////====================================  spnOrdSam lblOrdSam

            //if (td1f1 != null)
            //{
            //    if (od.Fabric1 != "")
            //    {
            //        trFirstFabric.Visible = true;
            //        trfirstprint.Visible = true;

            //    }
            //}
            //if (td4f2 != null)
            //{
            //    if (od.Fabric2 != "")
            //    {
            //        trsecFabric.Visible = true;
            //        trsecPrint.Visible = true;
            //    }
            //}

            //if (td7f3 != null)
            //{
            //    if (od.Fabric3 != "")
            //    {
            //        trthirdFabric.Visible = true;
            //        trthirdprint.Visible = true;
            //    }

            //}

            //if (td10f4 != null)
            //{
            //    if (od.Fabric4 != "")
            //    {
            //        trfourFabric.Visible = true;
            //        trfourprint.Visible = true;
            //    }

            //}

            //CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            //TextInfo textInfo = cultureInfo.TextInfo;

            //HtmlAnchor lnkAccesspopup = e.Row.FindControl("lnkAccesspopup") as HtmlAnchor;
            //if (lnkAccesspopup != null)
            //{
            //    string strAccessRemark = hdnAccRemarks.Value.Replace("'", "!<@#");
            //    // lnkAccesspopup.Attributes.Add("onclick", "javascript:showRemarks('0','" + od.OrderDetailID + "','" + strAccessRemark + "','MANAGE_ORDERS_FILE_ACCESSORIES_ACCESSORIES_REMARKS','MANAGE_ORDER_FILE','0','')");
            //    lnkAccesspopup.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Access')");
            //    if (iKandi.Common.MOOrderDetails.AccRemarkWrite == true || iKandi.Common.MOOrderDetails.AccRemarkRead == true)
            //    {
            //        lnkAccesspopup.Visible = true;
            //        lblRName.Visible = true;
            //        lblAccessoriesRemark.Visible = true;
            //    }
            //    else
            //    {
            //        lnkAccesspopup.Visible = false;
            //        lblRName.Visible = false;
            //        lblAccessoriesRemark.Visible = false;
            //    }
            //}

            //HtmlAnchor lnkFabpopup = e.Row.FindControl("lnkFabpopup") as HtmlAnchor;

            //HtmlAnchor lnkFitsPopUp = e.Row.FindControl("lnkFitsPopUp") as HtmlAnchor;
            //HtmlAnchor lnkFitsPopUpETAfil = e.Row.FindControl("lnkFitsPopUpETAfil") as HtmlAnchor;
            //HtmlAnchor lnkMerchantPopUp = e.Row.FindControl("lnkMerchantPopUp") as HtmlAnchor;

            //lblPriceSymbol.Text = "Rs";
            ////lblikandiGross.Text = Convert.ToString(od.iKandiPrice);
            //lblikandiGross.Text = Convert.ToString(od.BoutiqueBusiness) + " " + "Lac";
            //lblIkandiPriceTag.Text = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto));
            //if (Convert.ToString(od.discount).Length >= 5)
            //    lblIkandiDiscount.Text = Convert.ToString(od.discount).Substring(0, 5);
            //else
            //    lblIkandiDiscount.Text = Convert.ToString(od.discount);

           //this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0);
            //if (strQARemarks.Length >= 42)
            //{
            //    lblQAStatus.Text = "";//this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0).Substring(0, 42);
            //}
            //else
            //{
            //    lblQAStatus.Text = strQARemarks;
            //}
            ////  lblQAStatus.Text = this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0);
            //lblQAStatus.ToolTip = strQARemarks;

            //if (od.ParentOrder.WorkflowInstanceDetail.StatusModeID < Convert.ToInt32(TaskMode.Sealed_To_Cut))
            //{
            //    lblQAStatus.CssClass = "hide_me";

            //    //  lblStatusUserName.CssClass = "hide_me";
            //}
            //if (od.ParentOrder.Style.client.IsMDARequired == 0)
            //{
            //    spnmdano.Attributes.Add("CssClass", "hide_me");
            //}

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


            if (od.HandOverETADate != DateTime.MinValue && od.HandOverActualDate != DateTime.MinValue)
            {
                txtHanoverETA.CssClass = "do-not-allow-typing";
            }

            if (od.PatternReadyETADate != DateTime.MinValue && od.PatternReadyActualDate != DateTime.MinValue)
            {
                txtPatternReadyETADate.CssClass = "do-not-allow-typing";
            }

            //if (od.SampleSentETADate != DateTime.MinValue && od.SampleSentActualDate != DateTime.MinValue)
            //{
            //    txtSampleSentETA.CssClass = "do-not-allow-typing";
            //}
            //if (od.FitsCommentesETADate != DateTime.MinValue && od.FitsCommentesActualDate != DateTime.MinValue)
            //{
            //    txtFitsCommentesUplaodETADate.CssClass = "do-not-allow-typing";
            //}

            // edit by surendra if Prod date,cutting sheet date,
            ////lblBusinessTag.Text = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((od.Convertto));
            //if (Convert.ToString(od.Business).Length >= 6)
            //    lblBusiness.Text = Convert.ToString(od.Business).Substring(0, 5) + " " + "K";
            //else
            //    lblBusiness.Text = Convert.ToString(od.Business) + " " + "K";


            //HtmlGenericControl newtext4 = e.Row.FindControl("newtext4") as HtmlGenericControl;
            //Label lblDeptName = (Label)e.Row.FindControl("lblDeptName");


            //Label lblStatusMode1 = (Label)e.Row.FindControl("lblStatusMode");
            //HtmlGenericControl newtext2 = (HtmlGenericControl)e.Row.FindControl("newtext2");
            //Label lblStyleNo = (Label)e.Row.FindControl("lblStyleNo");
            //if (lnkFabpopup != null)
            //{//Edited By Ashish on 5/3/2014
            //    string FabricRemark = hdnFabRemarks.Value.Replace("'", "!<@#");
            //    //lnkFabpopup.Attributes.Add("onclick", "javascript:showRemarks('" + od.OrderDetailID + "','0','" + FabricRemark + "','MANAGE_ORDERS_FILE_FABRIC_FABRIC_REMARKS','MANAGE_ORDER_FILE','0','')");
            //    lnkFabpopup.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Fabric')");
            //    if (od.FFabricRemarkWrite == true || od.FFabricRemarkRead == true)
            //    {
            //        lnkFabpopup.Visible = true;
            //        lblFabUserName.Visible = true;
            //        lblFabRemark.Visible = true;
            //    }
            //    else
            //    {
            //        lnkFabpopup.Visible = false;
            //        lblFabUserName.Visible = false;
            //        lblFabRemark.Visible = false;
            //    }
            //    //END
            //}
            //if (lnkMerchantPopUp != null)
            //{
            //    lnkMerchantPopUp.Attributes.Add("onclick", "javascript:FabricRemark('" + hdnMerchantRemarks.Value.Replace("'", "!<@#") + "')");
            //}
            //if (lnkFitsPopUp != null)
            //{

            //    // lnkFitsPopUp.Attributes.Add("onclick", "javascript:showRemarks('" + od.OrderDetailID + "','0','" + hdnFitsRemarks.Value.Replace("'", "!<@#") + "','MerchantNotes','MANAGE_ORDER_FILE','0','')");
            //    lnkFitsPopUp.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Technical')");
            //    if (od.FitsRemarkWrite == true || od.FitsRemarkRead == true)
            //    {
            //        lnkFitsPopUp.Visible = true;
            //        lblFitsName.Visible = true;
            //        lblFitsRemark.Visible = true;
            //    }
            //    else
            //    {
            //        lnkFitsPopUp.Visible = false;
            //        lblFitsName.Visible = false;
            //        lblFitsRemark.Visible = false;
            //    }
            //}
            //if (lnkFitsPopUpETAfil != null)
            //{
            //    //lnkFitsPopUpETAfil.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Technical')");
            //    lnkFitsPopUpETAfil.Attributes.Add("onclick", "javascript:showEtaFitspopup(" + od.OrderDetailID + ")");
            //    //if (od.FitsRemarkWrite == true || od.FitsRemarkRead == true)
            //    //{
            //    //    lnkFitsPopUp.Visible = true;
            //    //    lblFitsName.Visible = true;
            //    //    lblFitsRemark.Visible = true;
            //    //}
            //    //else
            //    //{
            //    //    lnkFitsPopUp.Visible = false;
            //    //    lblFitsName.Visible = false;
            //    //    lblFitsRemark.Visible = false;
            //    //}
            //}
            //HiddenField hdnProductionRemark = e.Row.FindControl("hdnProductionRemark") as HiddenField;
            //HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;


            //HtmlAnchor lnkopenShipedPopoup = e.Row.FindControl("lnkopenShipedPopoup") as HtmlAnchor;
            //lnkopenShipedPopoup.Attributes.Add("onclick", "javascript:openShipedPopu('" + od.OrderDetailID + "','" + od.OrderID + "', '" + od.Quantity + "')");

            //if (od.IsShiped == true)
            //{
            //    lnkopenShipedPopoup.Style.Add("background-color", "#F9F9FA");
            //    lnkopenShipedPopoup.Style.Add("color", "#807F80");
            //}

            //if (lnkProductionpopup != null)
            //{
            //    string productionRemark = hdnProductionRemark.Value.Replace("'", "!<@#");
            //    //lnkProductionpopup.Attributes.Add("onclick", "javascript:showRemarks('0','" + od.OrderDetailID + "','" + productionRemark + "','ProdRemarks','MANAGE_ORDER_FILE','0','')");
            //    lnkProductionpopup.Attributes.Add("onclick", "javascript:showEtaRemarks(" + od.OrderDetailID + ",'Production')");
            //    if (od.PProductionRemarkRead == true || od.PProductionsRemarkWrite == true)
            //    {
            //        lnkProductionpopup.Visible = true;
            //    }
            //    else
            //    {
            //        lnkProductionpopup.Visible = false;
            //    }
            //}
            // Update by Ravi kumar on /6/2016            
            //CheckBox chkshipped = e.Row.FindControl("chkshipped") as CheckBox;
            //if (od.IsShipedWrite)
            //{
            //    //if ((od.Finish_80 == 1))
            //    //    chkshipped.Enabled = true;
            //    //else
            //    //    chkshipped.Enabled = false;

            //    if (od.QCNarration.ToLower().Contains("final pass") || od.QualityControl_Prev_Status.ToLower().Contains("final pass"))
            //        chkshipped.Enabled = true;
            //    else
            //        chkshipped.Enabled = false;
            //}

            // Update By ravi kumar on 3/2/2015
            //string shipRemark = od.SanjeevRemarks.ToString().ToLower();
            //if (shipRemark != "")
            //{
            //    hdnShipping.Value = shipRemark;
            //    string shippingRemark;
            //    shippingRemark = Constants.GetLastComments(shipRemark.ToString(), "~", "....", 100);

            //    if (shippingRemark.Trim() == "")
            //    {

            //        shippingRemark = Constants.GetComment(shipRemark.ToString(), "~", "....", 100);
            //    }

            //    cultureInfo = Thread.CurrentThread.CurrentCulture;
            //    textInfo = cultureInfo.TextInfo;
            //    shippingRemark = textInfo.ToTitleCase(shippingRemark);
            //    string[] shRemark = shippingRemark.Split('(');
            //    string sOnlyRemark = shRemark[1].ToString();
            //    string[] sOnlyRemarkArr = sOnlyRemark.Split(')');
            //    string sRemarkDate = sOnlyRemarkArr[0].ToString();
            //    string sLatestRemarkFull = sOnlyRemarkArr[1].ToString();

            //    string sLatestRemark = "";
            //    if (sLatestRemarkFull.Length >= 30)
            //    {
            //        sLatestRemark = sLatestRemarkFull.Substring(0, 30);
            //    }
            //    else
            //    {
            //        sLatestRemark = sLatestRemarkFull;
            //    }
            //    lblshippingRemarks.Text = sRemarkDate + sLatestRemark;

            //    sLatestRemarkFull = sRemarkDate + sLatestRemarkFull;
            //    lblshippingRemarks.ToolTip = sLatestRemarkFull;

            //}
            //if (lnkShipping != null)
            //{
            //    string ShippingRemark = hdnShipping.Value.Replace(" ", "!<@#");

            //    lnkShipping.Attributes.Add("onclick", "javascript:showMoSanjeevInfo('" + od.ExFactory + "','" + od.ParentOrder.Style.StyleID + "','" + od.OrderDetailID + "','" + od.ParentOrder.Style.StyleNumber + "', '" + OutHouseOrderDetailIds + "')");
            //    if (od.bBasicInfoRemarkwrite == true || od.bBasicInfoRemarkRead == true)
            //    {
            //        lnkShipping.Visible = true;
            //        lblshippingRemarks.Visible = true;
            //    }
            //    else
            //    {
            //        lnkShipping.Visible = false;
            //        lblshippingRemarks.Visible = false;
            //    }
            //}
            //// End Update By ravi kumar on 3/2/2015

            //HiddenField hdnFab1 = e.Row.FindControl("hdnFab1") as HiddenField;
            //HiddenField hdnFab2 = e.Row.FindControl("hdnFab2") as HiddenField;
            //HiddenField hdnFab3 = e.Row.FindControl("hdnFab3") as HiddenField;
            //HiddenField hdnFab4 = e.Row.FindControl("hdnFab4") as HiddenField;

            //HiddenField hdnOrderDetailsID = e.Row.FindControl("hdnOrderDetailsID") as HiddenField;
            //Label lblFabric1OrderAverage = e.Row.FindControl("lblFabric1OrderAverage") as Label;
            ////Label lblFabric1STCAverage = e.Row.FindControl("lblFabric1STCAverage") as Label;
            ////Label lblFinalOrderFabric1 = e.Row.FindControl("lblFinalOrderFabric1") as Label;




            //TextBox lblQuantityAvl1 = e.Row.FindControl("lblQuantityAvl1") as TextBox;

            //lblQuantityAvl1.Text = lblQuantityAvl1.Text == "0k" ? "" : lblQuantityAvl1.Text;



            //Label lblPercent1 = e.Row.FindControl("lblPercent1") as Label;
            //HtmlAnchor lnkPeekCapacity = e.Row.FindControl("lnkPeekCapacity") as HtmlAnchor;
            //lnkPeekCapacity.Attributes.Add("onclick", "javascript:FileUpload('" + od.OrderDetailID + "')");           

            OrderController objContoller = new OrderController();
            //DataTable dtfile = new DataTable();
            //dtfile = objContoller.GetPeekCapacityFile(Convert.ToInt32(od.OrderDetailID));
            //string StrFileName = "";
            //if (dtfile.Rows.Count > 0)
            //{
            //    StrFileName = dtfile.Rows[0]["PeekCapacityFile"].ToString();
            //}

            //TextBox lblSummary1 = e.Row.FindControl("lblSummary1") as TextBox;
            //TextBox lblSummary2 = e.Row.FindControl("lblSummary2") as TextBox;
            //TextBox lblSummary3 = e.Row.FindControl("lblSummary3") as TextBox;
            //TextBox lblSummary4 = e.Row.FindControl("lblSummary4") as TextBox;

            //Label lblFabric2OrderAverage = e.Row.FindControl("lblFabric2OrderAverage") as Label;
            //Label lblFabric2STCAverage = e.Row.FindControl("lblFabric2STCAverage") as Label;
            //Label lblFinalOrderFabric2 = e.Row.FindControl("lblFinalOrderFabric2") as Label;
            //TextBox lblQuantityAvl2 = e.Row.FindControl("lblQuantityAvl2") as TextBox;


            //lblQuantityAvl2.Text = lblQuantityAvl2.Text == "0k" ? "" : lblQuantityAvl2.Text;
            //Label lblPercent2 = e.Row.FindControl("lblPercent2") as Label;

            ////Label lblFabric3Details = e.Row.FindControl("lblFabric3Details") as Label;
            //Label lblFabric3OrderAverage = e.Row.FindControl("lblFabric3OrderAverage") as Label;
            //Label lblFabric3STCAverage = e.Row.FindControl("lblFabric3STCAverage") as Label;
            //Label lblFinalOrderFabric3 = e.Row.FindControl("lblFinalOrderFabric3") as Label;
            //TextBox lblQuantityAvl3 = e.Row.FindControl("lblQuantityAvl3") as TextBox;

            //lblQuantityAvl3.Text = lblQuantityAvl3.Text == "0k" ? "" : lblQuantityAvl3.Text;
            //Label lblPercent3 = e.Row.FindControl("lblPercent3") as Label;

            ////Label lblFabric4Details = e.Row.FindControl("lblFabric4Details") as Label;
            //Label lblFabric4OrderAverage = e.Row.FindControl("lblFabric4OrderAverage") as Label;
            //Label lblFabric4STCAverage = e.Row.FindControl("lblFabric4STCAverage") as Label;
            //Label lblFinalOrderFabric4 = e.Row.FindControl("lblFinalOrderFabric4") as Label;
            //TextBox lblQuantityAvl4 = e.Row.FindControl("lblQuantityAvl4") as TextBox;
            //lblQuantityAvl4.Text = lblQuantityAvl4.Text == "0k" ? "" : lblQuantityAvl4.Text;

            //Label lblPercent4 = e.Row.FindControl("lblPercent4") as Label;

            //HtmlGenericControl spanfab1pending = e.Row.FindControl("spanfab1pending") as HtmlGenericControl;
            //HtmlGenericControl Spanfab2pending = e.Row.FindControl("Spanfab2pending") as HtmlGenericControl;
            //HtmlGenericControl Spanfab3pending = e.Row.FindControl("Spanfab3pending") as HtmlGenericControl;
            //HtmlGenericControl Spanfab4pending = e.Row.FindControl("Spanfab4pending") as HtmlGenericControl;


            //TextBox lblfab1pending = e.Row.FindControl("lblfab1pending") as TextBox;
            //TextBox lblfab2pending = e.Row.FindControl("lblfab2pending") as TextBox;
            //TextBox fab3pending = e.Row.FindControl("fab3pending") as TextBox;
            //TextBox lblfab4pending = e.Row.FindControl("lblfab4pending") as TextBox;

            // Add by ravi kumar on 10/2/15 for fabric color change

            //TextBox txtFab1StartEta = e.Row.FindControl("txtFab1StartEta") as TextBox;
            //TextBox txtFab2StartEta = e.Row.FindControl("lblFab2StartEta") as TextBox;
            //TextBox txtFab3StartEta = e.Row.FindControl("lblFab3StartEta") as TextBox;
            //TextBox txtFab4StartEta = e.Row.FindControl("lblFab4StartEta") as TextBox;

            //TextBox txtFab1EndEta = e.Row.FindControl("txtFab1EndEta") as TextBox;
            //TextBox txtFab2EndEta = e.Row.FindControl("lblFab2EndEta") as TextBox;
            //TextBox txtFab3EndEta = e.Row.FindControl("lblFab3EndEta") as TextBox;
            //TextBox txtFab4EndEta = e.Row.FindControl("lblFab4EndEta") as TextBox;


            ////HtmlGenericControl dvBIHFabric = e.Row.FindControl("dvBIHFabric") as HtmlGenericControl;//FBIHDateRead
            ////HtmlTableCell tdBIHFabric = e.Row.FindControl("tdBIHFabric") as HtmlTableCell;

            //Label LabelBIHname = e.Row.FindControl("LabelBIHname") as Label;
            //Label lblBulkInhouseTgt = e.Row.FindControl("lblBulkInhouseTgt") as Label;

            //HtmlGenericControl dvBIHAccessories = e.Row.FindControl("dvBIHAccessories") as HtmlGenericControl;// FBIHDateRead
            ////HtmlTableCell tdBIHAccessories = e.Row.FindControl("tdBIHAccessories") as HtmlTableCell;
            //Label LabelAccBIHname = e.Row.FindControl("LabelAccBIHname") as Label;
            //Label lblACCBulkInhouseTgt = e.Row.FindControl("lblACCBulkInhouseTgt") as Label;

            //// End Add by ravi kumar on 10/2/15 for fabric color change

            //Label lblShippedCaption = e.Row.FindControl("lblShippedCaption") as Label;
            //Label lblShipped = e.Row.FindControl("lblShipped") as Label;
            //Gajendra 24-12-2015 TextBox txtISShippedDate = e.Row.FindControl("txtISShippedDate") as TextBox;


            //Repeater RepProduction = e.Row.FindControl("repProduction") as Repeater;
            //if (od.Production != null)
            //{
            //    if (od.Production.Count > 0)
            //    {
            //        //abhishek
            //        count_production = od.Production.Count;
            //        //end by abhishek
            //        IsShipped = od.IsShiped;
            //        IsVAcomplete = od.IsVaCompleted;
            //        RepProduction.DataSource = od.Production;
            //        RepProduction.DataBind();

            //        HiddenField hdnCutReadyTotalAll = e.Row.FindControl("hdnCutReadyTotalAll") as HiddenField;
            //        hdnCutReadyTotalAll.Value = TotalCutReadyAll.ToString();
            //        HiddenField hdnStitchTotalAll = e.Row.FindControl("hdnStitchTotalAll") as HiddenField;
            //        hdnStitchTotalAll.Value = TotalStitchedAll.ToString();

            //        TotalCutReadyAll = 0;
            //        TotalStitchedAll = 0;
            //    }
            //}

            //if (od.IsShiped == true)
            //{
            //    lblSummary1.Attributes.Add("color", od.SummryColor);
            //    lblSummary2.Attributes.Add("color", od.SummryColor);
            //    lblSummary3.Attributes.Add("color", od.SummryColor);
            //    lblSummary4.Attributes.Add("color", od.SummryColor);

            //    string ShippedDate = "";
            //    string ShortExtra = "";
            //    if (od.IsShipedDate != DateTime.MinValue)
            //    {
            //        ShippedDate = od.IsShipedDate.ToString("dd MMM");
            //    }

            //    double dQuantity = od.Quantity;
            //    int ShippedQty = od.ShippedQty;

            //    if (dQuantity > Convert.ToDouble(ShippedQty))
            //    {
            //        ShortExtra = "short";
            //    }
            //    else
            //    {
            //        ShortExtra = "extra";
            //    }

            //    double ShortShipped = dQuantity - Convert.ToDouble(ShippedQty);
            //    double ShortShippedPercent = (ShortShipped * 100) / dQuantity;
            //    ShortShippedPercent = Math.Round(ShortShippedPercent, 2);

            //    // edit by surendra for ctpl
            //    var totalQtyForCTSL = od.TotalcutQtyforCTSL;
            //    double ctplqty = Convert.ToDouble(totalQtyForCTSL) - Convert.ToDouble(ShippedQty);
            //    double ctplPercentage = (ctplqty * 100) / Convert.ToDouble(totalQtyForCTSL);
            //    ctplPercentage = Math.Round(ctplPercentage, 2);
            //    //int CtplPercentage = (((Convert.ToInt32(od.OverallCut) - ShippedQty) / Convert.ToInt32(od.OverallCut)) * 100);
            //    // end
            //    string ShippedCaption = "";
            //    if (ctplPercentage == 0.0)
            //    {
            //        if (ShortShippedPercent > 0.0)
            //        {
            //            ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + ") On " + ShippedDate;// ShippedQty + "Pcs shipped (" + ShortShippedPercent + " %) On " + ShippedDate + "";
            //        }
            //        else
            //        {

            //            ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + ") On " + ShippedDate;// ShippedQty + "Pcs shipped (" + ShortShippedPercent + " %) On " + ShippedDate + "";
            //        }
            //    }
            //    else
            //    {
            //        if (ctplPercentage > 0.0)
            //        {
            //            if (ShortShippedPercent > 0.0)
            //            {
            //                if (od.TotalPenalty == 0.0)
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
            //                else
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";

            //            }
            //            else
            //            {
            //                if (od.TotalPenalty == 0.0)
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
            //                else
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: red; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";
            //            }

            //        }
            //        else
            //        {
            //            if (ShortShippedPercent > 0.0)
            //            {
            //                if (od.TotalPenalty == 0.0)
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
            //                else
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd ( <span style='color: red; font-weight:bold;'>" + ShortShippedPercent + "</span> % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";
            //            }
            //            else
            //            {
            //                if (od.TotalPenalty == 0.0)
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & No Penalty </span>";
            //                else
            //                    ShippedCaption = "<span style='color: blue; font-weight:bold;'>" + ShippedQty + "</span> Shpd (" + ShortShippedPercent + " % " + ShortExtra + "), CTSL (" + "<span style='color: green; font-weight:bold;'>" + ctplPercentage + "</span>" + "%) On " + ShippedDate + " & Pnlty % to Shpd <span style='color: red; font-weight:bold;'> " + od.PenaltyPercentAge + "%</span> Total Pnlty <span style='color: blue; font-weight:bold;'>" + od.TotalPenalty + "</span>";

            //            }

            //        }
            //    }
            //    if (IsShipped == false)
            //        lblShippedCaption.Text = ShippedCaption;
            //    else
            //        lblShippedCaption.Text = ShippedCaption.Replace("blue;", "black;").Replace("red;", "black;").Replace("green;", "black;");

            //    //Gajendra 24-12-2015  txtISShippedDate.Text = "";
            //    lblShipped.Text = "";
            //}
            //else
            //{
            //    lblShipped.Text = "Waiting to be shipped";
            //    lblShippedCaption.Text = "";
            //    if (od.Caption1 == "Black")
            //    {
            //        lblSummary1.CssClass = "summaryColor1";
            //    }
            //    if (od.Caption1 == "Red")
            //    {
            //        lblSummary1.CssClass = "summaryColor2";
            //    }
            //    if (od.Caption1 == "Green")
            //    {
            //        lblSummary1.CssClass = "summaryColor3";
            //    }
            //    if (od.Caption2 == "Black")
            //    {
            //        lblSummary2.CssClass = "summaryColor1";
            //    }
            //    if (od.Caption2 == "Red")
            //    {
            //        lblSummary2.CssClass = "summaryColor2";
            //    }
            //    if (od.Caption2 == "Green")
            //    {
            //        lblSummary2.CssClass = "summaryColor3";
            //    }
            //    if (od.Caption3 == "Black")
            //    {
            //        lblSummary3.CssClass = "summaryColor1";
            //    }
            //    if (od.Caption3 == "Red")
            //    {
            //        lblSummary3.CssClass = "summaryColor2";
            //    }
            //    if (od.Caption3 == "Green")
            //    {
            //        lblSummary3.CssClass = "summaryColor3";
            //    }
            //    if (od.Caption4 == "Black")
            //    {
            //        lblSummary4.CssClass = "summaryColor1";
            //    }
            //    if (od.Caption4 == "Red")
            //    {
            //        lblSummary4.CssClass = "summaryColor2";
            //    }
            //    if (od.Caption4 == "Green")
            //    {
            //        lblSummary4.CssClass = "summaryColor3";
            //    }
            //}
            //DateTime BIHDate = od.BulkTarget;
            //ViewState["BIHDate"] = BIHDate;
            //BIHDate = Convert.ToDateTime(ViewState["BIHDate"].ToString());

            // Add by ravi kumar on 10/2/15 for fabric color change
            //int BIH_ColorGreen = 0;
            //int BIH_ColorWhite = 0;
            //int BIH_ColorRed = 0;

            //addde by abhishek on 19/8/2016

            //Label Labelsamcap = e.Row.FindControl("Labelsamcap") as Label;
            //Label Label15 = e.Row.FindControl("Label15") as Label;
            //Label lblICtext = (Label)e.Row.FindControl("lblICtext");
            //Label lblICDate = (Label)e.Row.FindControl("lblICDate");
            //CheckBox chkforIC = (CheckBox)e.Row.FindControl("chkforIC");

            //if (od.IsCheck == true)
            //{
            //    if (od.IsICCheckOnDate != "")
            //    {
            //        lblICDate.Text = "on" + " " + Convert.ToDateTime(od.IsICCheckOnDate).ToString("dd MMM");
            //    }


            //    chkforIC.Enabled = false;
            //}
            //if (od.IsShiped == true)
            //{
            //    chkforIC.Style.Add("background-color", "#F9F9FA");
            //    chkforIC.Style.Add("color", "#807F80");

            //    lblICtext.Style.Add("background-color", "#F9F9FA");
            //    lblICtext.Style.Add("color", "#807F80");

            //    lblICDate.Style.Add("background-color", "#F9F9FA");
            //    lblICDate.Style.Add("color", "#807F80");

            //    //LblPeekCapacity.Style.Add("background-color", "#F9F9FA");
            //    //LblPeekCapacity.Style.Add("color", "#807F80");

            //    Labelsamcap.Style.Add("background-color", "#F9F9FA");
            //    Labelsamcap.Style.Add("color", "#807F80");


            //    Label15.Style.Add("background-color", "#F9F9FA");
            //    Label15.Style.Add("color", "#807F80");
            //    //fabric color

            //    fabric1name.Style.Add("background-color", "#F9F9FA");
            //    fabric1name.Style.Add("color", "#807F80");

            //    fabric2name.Style.Add("background-color", "#F9F9FA");
            //    fabric2name.Style.Add("color", "#807F80");

            //    fabric3name.Style.Add("background-color", "#F9F9FA");
            //    fabric3name.Style.Add("color", "#807F80");

            //    fabric4name.Style.Add("background-color", "#F9F9FA");
            //    fabric4name.Style.Add("color", "#807F80");




            //}
            //end-
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
            //if (BIHDate.Date < System.DateTime.Now.Date)
            //{
            //    if (txtFab4EndEta.Text != "")
            //    {
            //        if (BIHDate.Date < Convert.ToDateTime(od.Fabric4ENDETA).Date)
            //        {
            //            BIH_ColorRed = 1;
            //        }
            //        if (lblPercent4.Text != "")
            //        {
            //            if (Convert.ToInt32(lblPercent4.Text) >= 100)
            //            {
            //                if (BIHDate.Date >= Convert.ToDateTime(od.Fabric4ENDETA).Date)
            //                {
            //                    BIH_ColorGreen = 1;
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
            //    else
            //    {
            //        BIH_ColorRed = 1;

            //    }

            //}
            // End Add By Ravi kumar on 6/2/2015
            //}


            //if (hdnFab1 != null)
            //{
            //    if (hdnFab1.Value == "")
            //    {
            //       // lblFabric1Details.Text = "";
            //       // lblFabric1OrderAverage.Text = "";
            //       //// lblFabric1STCAverage.Text = "";
            //       // //lblFinalOrderFabric1.Text = "";
            //       // lblQuantityAvl1.Text = "";
            //       //// lblFabric1STCAverage.Visible = false;
            //       // lblSummary1.Visible = false;
            //       // //lblPercent1.Text = "";
            //    }
            //    else
            //    {
            //        lblPercent1.Text = '(' + lblPercent1.Text + '%' + ')';
            //    }
            //}

            //if (hdnFab2 != null)
            //{
            //    if (hdnFab2.Value == "")
            //    {
            //        lblFabric2Details.Text = "";
            //        lblFabric2OrderAverage.Text = "";
            //        lblFabric2STCAverage.Text = "";
            //        lblFinalOrderFabric2.Text = "";
            //        lblQuantityAvl2.Text = "";
            //        lblPercent2.Text = "";
            //        lblFabric2STCAverage.Visible = false;
            //        lblSummary2.Visible = false;
            //    }
            //    else
            //    {
            //        lblPercent2.Text = '(' + lblPercent2.Text + '%' + ')';
            //    }
            //}
            //if (hdnFab3 != null)
            //{
            //    if (hdnFab3.Value == "")
            //    {
            //        lblFabric3Details.Text = "";
            //        lblFabric3OrderAverage.Text = "";
            //        lblFabric3STCAverage.Text = "";
            //        lblFinalOrderFabric3.Text = "";
            //        lblQuantityAvl3.Text = "";
            //        lblPercent3.Text = "";
            //        lblFabric3STCAverage.Visible = false;
            //        lblSummary3.Visible = false;
            //    }
            //    else
            //    {
            //        lblPercent3.Text = '(' + lblPercent3.Text + '%' + ')';
            //    }
            //}
            //if (hdnFab4 != null)
            //{
            //    if (hdnFab4.Value == "")
            //    {
            //        lblFabric4Details.Text = "";
            //        lblFabric4OrderAverage.Text = "";
            //        lblFabric4STCAverage.Text = "";
            //        lblFinalOrderFabric4.Text = "";
            //        lblQuantityAvl4.Text = "";
            //        lblPercent4.Text = "";
            //        lblFabric4STCAverage.Visible = false;
            //        lblSummary4.Visible = false;
            //    }
            //    else
            //    {
            //        lblPercent4.Text = '(' + lblPercent4.Text + '%' + ')';
            //    }
            //}

            //Label lblQuantity = e.Row.FindControl("lblQuantity") as Label;
            //Label lblExpectedDC = e.Row.FindControl("lblExpectedDC") as Label;
            //(lblQuantity.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetQuantitySizeFilledColor(od.IsSizeFilledUp, od.IsCuttingFormSaved));

            //if (lblQuantity != null)
            //{
            //    string strQuantity = lblQuantity.Text;
            //    //hdnQuantity.Value = strQuantity;
            //}
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


            //Repeater repaccess = e.Row.FindControl("repAccess") as Repeater;

            //if (od.Accessories.Count > 0)
            //{
            //    //Repeater repaccess = e.Row.FindControl("repAccess") as Repeater;
            //    repaccess.DataSource = od.Accessories;
            //    repaccess.DataBind();
            //}
            //else
            //{
            //    Access_ColorWhite = 1;
            //}



            // Add by ravi kumar on 10/2/15 for color change
            //if (Access_ColorRed == 1)
            //{
            //    //Added By Ashish on 23/3/2015
            //    if (od.FBIHDateRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            dvBIHAccessories.Style.Add("background-color", "#F9F9FA");
            //            LabelAccBIHname.Style.Add("color", "#807F80");
            //            lblACCBulkInhouseTgt.Style.Add("color", "#807F80");
            //        }
            //        else
            //        {
            //            dvBIHAccessories.Style.Add("background-color", "#FF3300");
            //            LabelAccBIHname.Style.Add("color", "#FFFF66");
            //            lblACCBulkInhouseTgt.Style.Add("color", "#FFFF66");
            //        }
            //    }
            //    else
            //    {
            //        dvBIHAccessories.Style.Add("background-color", "#FFFFFF");

            //    }

            //}
            //else if (Access_ColorWhite == 1)
            //{
            //    if (od.FBIHDateRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            dvBIHAccessories.Style.Add("background-color", "#F9F9FA");
            //            LabelAccBIHname.Style.Add("color", "#807F80");
            //            lblACCBulkInhouseTgt.Style.Add("color", "#807F80");
            //        }
            //        else
            //        {
            //            dvBIHAccessories.Style.Add("background-color", "#FFFFFF");
            //            LabelAccBIHname.Style.Add("color", "#000000");
            //            lblACCBulkInhouseTgt.Style.Add("color", "#000000");
            //        }
            //    }
            //    else
            //    {
            //        dvBIHAccessories.Style.Add("background-color", "#FFFFFF");

            //    }
            //}
            //else
            //{
            //    if (od.FBIHDateRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            dvBIHAccessories.Style.Add("background-color", "#F9F9FA");
            //            LabelAccBIHname.Style.Add("color", "#807F80");
            //            lblACCBulkInhouseTgt.Style.Add("color", "#807F80");
            //        }
            //        else
            //        {
            //            dvBIHAccessories.Style.Add("background-color", "#00FF70");
            //            LabelAccBIHname.Style.Add("color", "#000000");
            //            lblACCBulkInhouseTgt.Style.Add("color", "#000000");
            //        }
            //    }
            //    else
            //    {
            //        dvBIHAccessories.Style.Add("background-color", "#FFFFFF");
            //        LabelAccBIHname.Style.Add("color", "#000000");
            //        lblACCBulkInhouseTgt.Style.Add("color", "#000000");
            //    }
            //}

            //Access_ColorRed = 0;
            //Access_ColorWhite = 0;
            //Access_ColorGreen = 0;

            // End Add by ravi kumar on 10/2/15 for color change



            //HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
            //(hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(od.ExFactory));




            //Label lblMode = e.Row.FindControl("lblMode") as Label;
            //(lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode));

            //HtmlAnchor hypstatusmode = e.Row.FindControl("hypstatusmode") as HtmlAnchor;
            //(hypstatusmode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID));


            //HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;

            //Label lblFitsDate = e.Row.FindControl("lblFitsDate") as Label;
  
            //for (int iFitdays = 1; iFitdays <= 5; iFitdays++)
            //{

            //if (Convert.ToInt32(od.ParentOrder.Style.cdept.Mon) > 0)
            //{
            //    // lblMon.CssClass = "status_meeting_day_selected_style";
            //    if (str == "")
            //    {
            //        str = "Mon";
            //    }
            //    else
            //    {
            //        str = str + "," + str;
            //    }

            //}
            //else
            //{
            //    lblMon.CssClass = "status_meeting_day__style";
            //}

            //  Label lblTue = e.Row.FindControl("lblTue") as Label;
            //if (Convert.ToInt32(od.ParentOrder.Style.cdept.Tue) > 0)
            //{
            //    //  lblTue.CssClass = "status_meeting_day_selected_style";
            //    //str += str+"," + "Tue";
            //    if (str == "")
            //    {
            //        str = "Tue";
            //    }
            //    else
            //    {
            //        str = str + "," + "Tue";
            //    }
            //}
            //else
            //{
            //    lblTue.CssClass = "status_meeting_day__style";
            //}

            //    Label lblWed = e.Row.FindControl("lblWed") as Label;
            //if (Convert.ToInt32(od.ParentOrder.Style.cdept.Wed) > 0)
            //{
            //    //   lblWed.CssClass = "status_meeting_day_selected_style";
            //    //str += str + "," + "Wed";
            //    if (str == "")
            //    {
            //        str = "Wed";
            //    }
            //    else
            //    {
            //        str = str + "," + "Wed";
            //    }

            //}
            //else
            //{
            //    lblWed.CssClass = "status_meeting_day__style";
            //}

            //  Label lblThu = e.Row.FindControl("lblThu") as Label;
            //if (Convert.ToInt32(od.ParentOrder.Style.cdept.Thu) > 0)
            //{
            //    // lblThu.CssClass = "status_meeting_day_selected_style";
            //    //str += str + "," + "Thu";

            //    if (str == "")
            //    {
            //        str = "Thu";
            //    }
            //    else
            //    {
            //        str = str + "," + "Thu";
            //    }
            //}
            //else
            //{
            //    lblThu.CssClass = "status_meeting_day__style";
            //}

            //Label lblFri = e.Row.FindControl("lblFri") as Label;
            //if (Convert.ToInt32(od.ParentOrder.Style.cdept.Fri) > 0)
            //{
            //    //  lblFri.CssClass = "status_meeting_day_selected_style";
            //    // str += str + "," + "Fri";

            //    if (str == "")
            //    {
            //        str = "Fri";
            //    }
            //    else
            //    {
            //        str = str + "," + "Fri";
            //    }
            //}
            //else
            //{
            //    lblFri.CssClass = "status_meeting_day__style";
            //}
            //}
            //if (str.Length > 7)
            //    lblFitsDate.Text = str.Substring(0, 7);
            //else
            //    lblFitsDate.Text = str;
            //lblFitsDate.ToolTip = str;

            //LblPeekCapacity.Attributes.Add("onclick", "javascript:FileUpload('" + od.OrderDetailID +"')");



            //HyperLink hypfitstatus = new HyperLink();

            //if (od.FitStatus != string.Empty)
            //{
            //    hypfitstatus.Text = od.FitStatus;
            //    hypfitstatus.Target = "SealingForm";
            //    string stylecode = string.Empty;
            //    if (od.ParentOrder.Fits.StyleCodeVersion == string.Empty)
            //        stylecode = Constants.GetFiveDigitStyleCodeByStyleCode(od.ParentOrder.Fits.StyleCode);
            //    else
            //        if (od.FitsStatusRead == true && od.FitsStatusWrite == true)
            //        {
            //            hypfitstatus.Target = "SealingForm";
            //            //stylecode = od.ParentOrder.Fits.StyleCodeVersion;
            //            //hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + stylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "','" + od.ParentOrder.Style.StyleID + "','" + od.ParentOrder.Style.StyleCode + "','" + od.ParentOrder.Fits.StyleCodeVersion + "','" + od.ParentOrder.Style.client.ClientID + "')");
            //            ////hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + od.ParentOrder.Style.StyleID + "','" + od.ParentOrder.Style.StyleNumber + "','" + od.ParentOrder.Fits.StyleCodeVersion + "','" + od.ParentOrder.Style.StyleCode + "','" + od.ParentOrder.ClientID + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");


            //            //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //            //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //            //else
            //            //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //            hypfitstatus.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");
            //        }
            //}

            //else
            //{
            //    hypfitstatus.Text = "Show Sealer Pending Form";
            //    hypfitstatus.Target = "SealingForm";

            //    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //    //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //    //else
            //    //    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //    hypfitstatus.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");

            //}
            //lblQAStatus.Visible = od.FitsQAStatusRead;
            //lblQAStatus.Enabled = od.FitsQAStatusWrite;


            //Label lblQAStatus = e.Row.FindControl("lblQAStatus") as Label;
            //lblQAStatus.Text = this.QualityControllerInstance.GetQAStatusMO(od.OrderDetailID, 0);
            //if (od.ParentOrder.WorkflowInstanceDetail.StatusModeSequence < 11)
            //{
            //    lblQAStatus.CssClass = "hide_me";
            //}
            //string Planedstylecode = string.Empty;
            //if (od.ParentOrder.Fits.StyleCodeVersion == string.Empty)
            //    Planedstylecode = Constants.GetFiveDigitStyleCodeByStyleCode(od.ParentOrder.Fits.StyleCode);
            //else
            //    Planedstylecode = od.ParentOrder.Fits.StyleCodeVersion;

            // HyperLink hypPlannedDate = new HyperLink();
            //Label lblFitsStatus = e.Row.FindControl("lblFitsStatus") as Label;
            //lblFitsStatus.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");
            ////lblFitsStatus.Controls.Add(hypfitstatus);
            //lblFitsStatus.Text = hypfitstatus.Text;

            //Label lblstctgt = e.Row.FindControl("lblstctgt") as Label;
            //(lblstctgt.Parent as TableCell).ForeColor = System.Drawing.ColorTranslator.FromHtml(od.FitStatusBgColor);


            //Label lblPlannedDate = e.Row.FindControl("lblPlannedDate") as Label;
            //Label lblBhPlannedDate = e.Row.FindControl("lblBHPlannedDate") as Label;
            //if (lblPlannedDate != null)
            //{
            //    //lblPlannedDate.Attributes.Add("class", "lblcolor");
            //if (od.ParentOrder.FitsTrack.PlannedDispatchDate.Year == 1)
            //{
            //    lblPlannedDate.Text = "";
            //    //lblPlannedDate.Visible = false;
            //    //Added By Ashish on 4/3/2014
            //    lblPlannedDate.Visible = false; ;
            //    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;

            //    //END
            //}
            //else
            //{
            //    lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.FitsTrack.PlannedDispatchDate).ToString("dd MMM");
            //    //lblPlannedDate.Visible = true;
            //    //Added By Ashish on 4/3/2014
            //    lblPlannedDate.Visible = false;
            //    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
            //    //END
            //    hypPlannedDate.Text = lblPlannedDate.Text;
            //    lblPlannedDate.Controls.Add(hypPlannedDate);
            //    hypPlannedDate.Target = "SealingForm";
            //    //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");

            //    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //    //else
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");


            //}
            //  }



            //if (od.IsAllocated == true && od.BHPlannedMeeting > DateTime.MinValue && od.IsBHMeetingCompleted == 0)
            //{
            //    lblBhPlannedDate.Text = "BH Meeting Planned On " + od.BHPlannedMeeting.ToString("dd MMM");
            //    hypPlannedDate.Text = lblPlannedDate.Text;
            //    lblPlannedDate.Controls.Add(hypPlannedDate);
            //    hypPlannedDate.Target = "SealingForm";
            //    //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
            //    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //    //else
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");

            //}

            //if (od.FitStatus.Contains("Top Approved On"))
            //{
            //    lblPlannedDate.Text = "";
            //}
            //else if (od.FitStatus.Contains("STC Approved"))
            //{
            //    if (od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate != DateTime.MinValue)
            //    {
            //        lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate).ToString("dd MMM");
            //        lblPlannedDate.Text = "TOP Planned For " + lblPlannedDate.Text;
            //        hypPlannedDate.Text = lblPlannedDate.Text;
            //        //lblPlannedDate.Visible = true;
            //        //Added By Ashish on 4/3/2014
            //        lblPlannedDate.Visible = false;
            //        lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
            //        //END
            //        lblPlannedDate.Controls.Add(hypPlannedDate);
            //        hypPlannedDate.Target = "SealingForm";
            //        //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //        //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //        //else
            //        //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //        ////hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");

            //        hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");
            //    }
            //    else
            //    {
            //        lblPlannedDate.Text = "";
            //        //lblPlannedDate.Visible = false;
            //        //Added By Ashish on 4/3/2014
            //        lblPlannedDate.Visible = false;
            //        lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
            //        //END
            //    }

            //}
            //else if (od.FitStatus.Contains("Top"))
            //{
            //    if (od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate != DateTime.MinValue)
            //    {
            //        lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.InlinePPMOrderContract.TOPPlannedDispatchDate).ToString("dd MMM");
            //        lblPlannedDate.Text = "TOP Planned For " + lblPlannedDate.Text;
            //        hypPlannedDate.Text = lblPlannedDate.Text;
            //        //lblPlannedDate.Visible = true;
            //        //Added By Ashish on 4/3/2014
            //        lblPlannedDate.Visible = false;
            //        lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
            //        //END
            //        lblPlannedDate.Controls.Add(hypPlannedDate);
            //        hypPlannedDate.Target = "SealingForm";
            //        //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
            //        //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //        //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //        //else
            //        //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //        hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");

            //    }
            //    else
            //    {
            //        lblPlannedDate.Text = "";
            //        //lblPlannedDate.Visible = false;
            //        //Added By Ashish on 4/3/2014
            //        lblPlannedDate.Visible = false;
            //        lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
            //        //END
            //    }

            //}
            //else if (od.FitStatus.Contains("FIT") && ((od.FitStatus.Contains("RECEIVED")) || (od.FitStatus.Contains("Received"))))
            //{
            //    lblPlannedDate.Text = "Next Fit Planned For " + lblPlannedDate.Text;
            //    hypPlannedDate.Text = lblPlannedDate.Text;
            //    lblPlannedDate.Controls.Add(hypPlannedDate);
            //    hypPlannedDate.Target = "SealingForm";

            //    //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
            //    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //    //else
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");

            //}
            //else if ((od.FitStatus.ToUpper().Contains("SAMPLE") || od.FitStatus.ToUpper().Contains("SEALER")) && !od.FitStatus.ToUpper().Contains("SPEC") && lblPlannedDate.Text != "")
            //{
            //    lblPlannedDate.Text = "Next Fit Planned For " + lblPlannedDate.Text;
            //    hypPlannedDate.Text = lblPlannedDate.Text;
            //    lblPlannedDate.Controls.Add(hypPlannedDate);
            //    hypPlannedDate.Target = "SealingForm";
            //    //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
            //    //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //    //else
            //    //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //    hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");

            //}
            //else if (od.FitStatus == "" && hypfitstatus.Text.ToUpper().Contains("SHOW SEALER"))
            //{
            //    if (od.ParentOrder.InlinePPMOrderContract.SpecUploadPlannedDate != DateTime.MinValue)
            //    {
            //        lblPlannedDate.Text = Convert.ToDateTime(od.ParentOrder.InlinePPMOrderContract.SpecUploadPlannedDate).ToString("dd MMM");
            //        lblPlannedDate.Text = "Spec Upload Planned For " + lblPlannedDate.Text;
            //        hypPlannedDate.Text = lblPlannedDate.Text;
            //        //lblPlannedDate.Visible = true;
            //        //Added By Ashish on 4/3/2014
            //        lblPlannedDate.Visible = false;
            //        lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
            //        //END
            //        lblPlannedDate.Controls.Add(hypPlannedDate);
            //        hypPlannedDate.Target = "SealingForm";
            //        //hypPlannedDate.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + Planedstylecode + "','" + od.ParentOrder.Style.cdept.DeptID + "','" + od.OrderDetailID + "')");
            //        //if (!String.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
            //        //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
            //        //else
            //        //    hypPlannedDate.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Style.StyleCode + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            //        hypPlannedDate.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");
            //    }
            //}
            //else
            //{
            //    lblPlannedDate.Text = "";
            //    //lblPlannedDate.Visible = false;
            //    //Added By Ashish on 4/3/2014
            //    lblPlannedDate.Visible = false;
            //    lblPlannedDate.Enabled = od.FitsTgtPlannedDateWrite;
            //    //END
            //}
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
            //HtmlGenericControl divFooter = e.Row.FindControl("divFooter") as HtmlGenericControl;

            //if (od.IsLinePlan == 1)
            //{
            //    //divLKM.Visible = false;
            //    //divLines.Visible = false;
            //    //divDays.Visible = false;
            //    divFooter.Visible = true;
            //}


            //----------------------------------------End---------------------------------------------------------------------------------------------------//
            //string imagepath = "";
            //string[] strcut;
            //int StyleId = od.ParentOrder.Style.StyleID;
            //string avg1 = lblFabric1OrderAverage.Text;
            //string txtavg = lblFabric1STCAverage.Text;
            //string Fabric1 = hdnFab1.Value;
            ////lblFabric1STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'1', '" + avg1 + "', '" + StyleId + "', '" + Fabric1 + "')");
            //if (od.FOrdWrite == true)
            //    td2p1.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'1', '" + avg1 + "', '" + StyleId + "', '" + Fabric1 + "','" + txtavg + "','" + od.ParentOrder.Style.StyleNumber + "')");
            //OrderController objOrderController = new OrderController();
            //int orderDetailID = 0;
            //orderDetailID = Convert.ToInt32(hdnOrderDetailsID.Value);
            //imagepath = objOrderController.GetSketch(orderDetailID, "", 1);
            //strcut = imagepath.Split(',');
            //if (strcut[0].ToString() != "")
            //{
            //    viewolay1.NavigateUrl = "~/Uploads/Photo/" + strcut[0].ToString();
            //    viewolay1.Attributes.Add("style", "display:block;");
            //}

            //string avg2 = lblFabric2OrderAverage.Text;
            //string txtavg2 = lblFabric2STCAverage.Text;

            //string Fabric2 = hdnFab2.Value;
            ////  lblFabric2STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'2', '" + avg2 + "', '" + StyleId + "', '" + Fabric2 + "')");
            //if (od.FOrdWrite == true)
            //    td2p2.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'2', '" + avg2 + "', '" + StyleId + "', '" + Fabric2 + "','" + txtavg2 + "','" + od.ParentOrder.Style.StyleNumber + "')");
            //imagepath = objOrderController.GetSketch(orderDetailID, "", 2);
            //strcut = imagepath.Split(',');
            ////img.ImageUrl = "~/Uploads/Photo/" + imagepath;
            //if (strcut[0].ToString() != "")
            //{
            //    viewolay2.NavigateUrl = "~/Uploads/Photo/" + strcut[0].ToString();
            //    viewolay2.Attributes.Add("style", "display:block;");
            //}

            //string avg3 = lblFabric3OrderAverage.Text;
            //string Fabric3 = hdnFab3.Value;
            //string txtavg3 = lblFabric3STCAverage.Text;

            //// lblFabric3STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'3', '" + avg3 + "', '" + StyleId + "', '" + Fabric3 + "')");
            //if (od.FOrdWrite == true)
            //    td2p3.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'3', '" + avg3 + "', '" + StyleId + "', '" + Fabric3 + "','" + txtavg3 + "','" + od.ParentOrder.Style.StyleNumber + "')");

            //imagepath = objOrderController.GetSketch(orderDetailID, "", 3);
            //strcut = imagepath.Split(',');
            //if (strcut[0].ToString() != "")
            //{
            //    //img.ImageUrl = "~/Uploads/Photo/" + imagepath;
            //    viewolay3.NavigateUrl = "~/Uploads/Photo/" + strcut[0].ToString();
            //    viewolay3.Attributes.Add("style", "display:block;");
            //}

            //string avg4 = lblFabric4OrderAverage.Text;
            //string Fabric4 = hdnFab4.Value;
            //string txtavg4 = lblFabric4STCAverage.Text;
            // lblFabric4STCAverage.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'4', '" + avg4 + "', '" + StyleId + "', '" + Fabric4 + "')");
            //if (od.FOrdWrite == true)
            //    td2p4.Attributes.Add("onclick", "javascript:return UpdateCutAvg(this,'4', '" + avg4 + "', '" + StyleId + "', '" + Fabric4 + "','" + txtavg4 + "','" + od.ParentOrder.Style.StyleNumber + "')");

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
            //hypfitstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000EE");
            //hypPlannedDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000EE");

            //}

            //Added By Ashish on 14/1/2015
            //if (od.IsFitsPending == true)
            //{
            //    hypfitstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3300");
            //    hypPlannedDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3300");
            //    //StrForColorCode = "#FFFF66";
            //}
            //if (od.IsShiped == true)
            //{
            //    //hypfitstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#807F80");
            //    //hypPlannedDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#807F80");
            //    //StrForColorCode = "#FFFF66";
            //}
            //TextBox lblstcpending = e.Row.FindControl("lblstcpending") as TextBox;
            //TextBox lblSTCETA = e.Row.FindControl("lblSTCETA") as TextBox;
            TextBox PATTERNETA = e.Row.FindControl("PATTERNETA") as TextBox;
            TextBox lblTOPETA = e.Row.FindControl("lblTOPETA") as TextBox;
            //Added By Ashish on 4/3/2015
            //TextBox txtFitsETA = e.Row.FindControl("txtFitsETA") as TextBox;
            //END
            HtmlGenericControl spanSTCAPPETA = e.Row.FindControl("spanSTCAPPETA") as HtmlGenericControl;
            //HtmlGenericControl spanstcapppending = e.Row.FindControl("spanstcapppending") as HtmlGenericControl;
            //TextBox lblstcapppending = e.Row.FindControl("lblstcapppending") as TextBox;
            HtmlGenericControl spanPatternpending = e.Row.FindControl("spanPatternpending") as HtmlGenericControl;
            TextBox lblpatternpending = e.Row.FindControl("lblpatternpending") as TextBox;

            //if (lblFabric1STCAverage.Text == "0")
            //    lblFabric1STCAverage.Text = "";
            //if (lblFabric2STCAverage.Text == "0")
            //    lblFabric2STCAverage.Text = "";
            //if (lblFabric3STCAverage.Text == "0")
            //    lblFabric3STCAverage.Text = "";
            //if (lblFabric4STCAverage.Text == "0")
            //    lblFabric4STCAverage.Text = "";
            //if (lblPercent1.Text == "(0%)")
            //    lblPercent1.Text = "";
            //if (lblPercent2.Text == "(0%)")
            //    lblPercent2.Text = "";
            //if (lblPercent3.Text == "(0%)")
            //    lblPercent3.Text = "";
            //if (lblPercent4.Text == "(0%)")
            //    lblPercent4.Text = "";
            //if (lblQuantityAvl1.Text == "0")
            //    lblQuantityAvl1.Text = "";
            //if (lblQuantityAvl2.Text == "0")
            //    lblQuantityAvl2.Text = "";
            //if (lblQuantityAvl3.Text == "0")
            //    lblQuantityAvl3.Text = "";
            //if (lblQuantityAvl4.Text == "0")
            //    lblQuantityAvl4.Text = "";
            //if (lblFinalOrderFabric1.Text == "0")
            //    lblFinalOrderFabric1.Text = "";
            //if (lblFinalOrderFabric2.Text == "0")
            //    lblFinalOrderFabric2.Text = "";
            //if (lblFinalOrderFabric3.Text == "0")
            //    lblFinalOrderFabric3.Text = "";
            //if (lblFinalOrderFabric4.Text == "0")
            //    lblFinalOrderFabric4.Text = "";

            //added by abhishek on 21/9/2016
            //TextBox txtinhouseqntyfab1 = e.Row.FindControl("txtinhouseqntyfab1") as TextBox;
            //TextBox txtinhouseqntyfab2 = e.Row.FindControl("txtinhouseqntyfab2") as TextBox;
            //TextBox txtinhouseqntyfab3 = e.Row.FindControl("txtinhouseqntyfab3") as TextBox;
            //TextBox txtinhouseqntyfab4 = e.Row.FindControl("txtinhouseqntyfab4") as TextBox;

            //HiddenField hdnFab1incheckedval = e.Row.FindControl("hdnFab1incheckedval") as HiddenField;
            //HiddenField hdnFab2incheckedval = e.Row.FindControl("hdnFab2incheckedval") as HiddenField;
            //HiddenField hdnFab3incheckedval = e.Row.FindControl("hdnFab3incheckedval") as HiddenField;
            //HiddenField hdnFab4incheckedval = e.Row.FindControl("hdnFab4incheckedval") as HiddenField;

            //if (txtinhouseqntyfab1.Text == "0")
            //    txtinhouseqntyfab1.Text = "";
            //if (txtinhouseqntyfab2.Text == "0")
            //    txtinhouseqntyfab2.Text = "";
            //if (txtinhouseqntyfab3.Text == "0")
            //    txtinhouseqntyfab3.Text = "";
            //if (txtinhouseqntyfab4.Text == "0")
            //    txtinhouseqntyfab4.Text = "";
            //txtinhouseqntyfab1.Text = txtinhouseqntyfab1.Text == "0k" ? "" : txtinhouseqntyfab1.Text;
            //txtinhouseqntyfab2.Text = txtinhouseqntyfab2.Text == "0k" ? "" : txtinhouseqntyfab2.Text;
            //txtinhouseqntyfab3.Text = txtinhouseqntyfab3.Text == "0k" ? "" : txtinhouseqntyfab3.Text;
            //txtinhouseqntyfab4.Text = txtinhouseqntyfab4.Text == "0k" ? "" : txtinhouseqntyfab4.Text;

            //if (hdnFab1incheckedval.Value != "0" && hdnFab1incheckedval.Value != "")
            //{
            //    txtinhouseqntyfab1.ToolTip = Convert.ToInt32(hdnFab1incheckedval.Value).ToString("N0");
            //}
            //if (hdnFab2incheckedval.Value != "0" && hdnFab2incheckedval.Value != "")
            //{
            //    txtinhouseqntyfab2.ToolTip = Convert.ToInt32(hdnFab2incheckedval.Value).ToString("N0");
            //}
            //if (hdnFab3incheckedval.Value != "0" && hdnFab3incheckedval.Value != "")
            //{
            //    txtinhouseqntyfab3.ToolTip = Convert.ToInt32(hdnFab3incheckedval.Value).ToString("N0");
            //}
            //if (hdnFab4incheckedval.Value != "0" && hdnFab4incheckedval.Value != "")
            //{
            //    txtinhouseqntyfab4.ToolTip = Convert.ToInt32(hdnFab4incheckedval.Value).ToString("N0");
            //}




            //if (lblFinalOrderFabric1.Text != "")
            //{
            //    double finalOrder1 = 0;

            //    finalOrder1 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric1.Text).Replace(",", "").Replace("k", ""));
            //    //lblFinalOrderFabric1.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder1 * 1000));


            //    // double FinalOrderFabric1_kd = (lblQuantity / 1000);

            //    //double FinalOrderFabric1_kd = ((Convert.ToDouble(lblQuantity.Text)* Quantity) / 1000);
            //    lblFinalOrderFabric1.Text = lblFinalOrderFabric1.Text.ToString() + "k"; ;
            //}
            //if (lblFinalOrderFabric2.Text != "")
            //{
            //    double finalOrder2 = 0;

            //    finalOrder2 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric2.Text).Replace(",", "").Replace("k", ""));
            //    //lblFinalOrderFabric2.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder2 * 1000));

            //    //double FinalOrderFabric2_kd = (finalOrder2 / 1000);
            //    lblFinalOrderFabric2.Text = lblFinalOrderFabric2.Text.ToString() + "k"; ;
            //}
            //if (lblFinalOrderFabric3.Text != "")
            //{
            //    double finalOrder3 = 0;

            //    finalOrder3 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric3.Text).Replace(",", "").Replace("k", ""));

            //    //lblFinalOrderFabric3.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder3 * 1000));
            //    // double FinalOrderFabric3_kd = (finalOrder3 / 1000);
            //    lblFinalOrderFabric3.Text = lblFinalOrderFabric3.Text.ToString() + "k";
            //}
            //if (lblFinalOrderFabric4.Text != "")
            //{
            //    double finalOrder4 = 0;

            //    finalOrder4 = Convert.ToDouble(Convert.ToString(lblFinalOrderFabric4.Text).Replace(",", "").Replace("k", ""));

            //    //lblFinalOrderFabric4.ToolTip = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0}", Convert.ToString(finalOrder4 * 1000));
            //    // double FinalOrderFabric4_kd = (finalOrder4 / 1000);
            //    lblFinalOrderFabric4.Text = lblFinalOrderFabric4.Text.ToString() + "k";
            //}

            //lblFinalOrderFabric1.Text = lblFinalOrderFabric1.Text == "0.0k" ? "" : lblFinalOrderFabric1.Text;
            //lblFinalOrderFabric2.Text = lblFinalOrderFabric2.Text == "0.0k" ? "" : lblFinalOrderFabric2.Text;
            //lblFinalOrderFabric3.Text = lblFinalOrderFabric3.Text == "0.0k" ? "" : lblFinalOrderFabric3.Text;
            //lblFinalOrderFabric4.Text = lblFinalOrderFabric4.Text == "0.0k" ? "" : lblFinalOrderFabric4.Text;

            //lblFinalOrderFabric1.ToolTip = od.Fabric1Required_ToolTip;
            //lblFinalOrderFabric2.ToolTip = od.Fabric2Required_ToolTip;
            //lblFinalOrderFabric3.ToolTip = od.Fabric3Required_ToolTip;
            //lblFinalOrderFabric4.ToolTip = od.Fabric4Required_ToolTip;

            //end by abhishek 

            //Added By Ashish on 4/3/2015
            string FitsETAdate = Convert.ToDateTime(od.FitsETA) == DateTime.MinValue ? "" : Convert.ToDateTime(od.FitsETA).ToString("dd MMM yy (ddd)");
            //END
            //txtFitsETA.Attributes.Add("onclick", "javascript:showEtaPopup('FitsStatusETA','FitsETA','" + od.ParentOrder.Style.StyleID + "','','','" + FitsETAdate + "','','" + od.ParentOrder.Style.StyleNumber + "','','" + od.OrderDetailID + "','" + od.FitsETADateWrite + "', 62)");
            //txtFitsETA
            // Work For Color change of STC date By Ravi kumar

            if (od.ParentOrder.Fits.SealDate != DateTime.MinValue)
            {
                //lblSTCETA.Attributes.Add("readonly", "readonly");
                //lnkStcDate.Attributes.Add("onclick", "javascript:void(0);");
            }
            else
            {
                string STCdate = Convert.ToDateTime(od.STCETA) == DateTime.MinValue ? "" : Convert.ToDateTime(od.STCETA).ToString("dd MMM yy (ddd)");
                //Added By Ashish on 23/2/2015
                //lblSTCETA.Attributes.Add("onclick", "javascript:showEtaPopup('STCRequest','FitsETA','" + od.ParentOrder.Style.StyleID + "','','','" + STCdate + "','','" + od.ParentOrder.Style.StyleNumber + "','','" + od.OrderDetailID + "','" + od.FitsSTCETAWrite + "', 62)");
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
            //TextBox TxtPhotoshot = e.Row.FindControl("TxtPhotoshot") as TextBox;
            //Label lblIsRepeatOrder = e.Row.FindControl("lblIsRepeatOrder") as Label;

            //CheckBox chkPhotoshot = e.Row.FindControl("chkPhotoshot") as CheckBox;
            //chkPhotoshot.Checked = Convert.ToBoolean(od.PhotoShoot);

            //if (od.PhotoShotWrite == true)
            //{
            //    if (od.PhotoShoot == true)
            //    {
            //        chkPhotoshot.Enabled = false;
            //    }
            //}
            //else
            //{
            //    chkPhotoshot.Enabled = false;
            //    TxtPhotoshot.Enabled = false;

            //}
            //if (od.IsRepeatWithChanges == true)
            //{
            //    lblIsRepeatOrder.Text = od.IsRepeatWithChanges == true ? "R" : string.Empty;
            //    lblIsRepeatOrder.ToolTip = "(R:) repeat with changes";
            //}
            //else if (od.IsRepeat == true)
            //{
            //    lblIsRepeatOrder.Text = od.IsRepeat == true ? "R(D)" : string.Empty;
            //    lblIsRepeatOrder.ToolTip = "(DR:) direct repeat with no changes";
            //}


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
                        tdTestReport.Style.Add("background-color", "#FFFF66");
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
            //HtmlTableCell tdcdchat = (HtmlTableCell)e.Row.FindControl("tdcdchat");
            //TextBox txtcdchartETA = (TextBox)e.Row.FindControl("txtcdchartETA");
            //Label lblcdchat = (Label)e.Row.FindControl("lblcdchat");
            //TextBox txtStrikeof1 = (TextBox)e.Row.FindControl("txtStrikeof1");
            //TextBox txtStrikeof2 = (TextBox)e.Row.FindControl("txtStrikeof2");
            //TextBox txtStrikeof3 = (TextBox)e.Row.FindControl("txtStrikeof3");
            //TextBox txtStrikeof4 = (TextBox)e.Row.FindControl("txtStrikeof4");

            //if (od.IntialAprd1 != 2)
            //    txtStrikeof1.Attributes.Add("class", "th do-not-allow-typing");
            //if (od.IntialAprd2 != 2)
            //    txtStrikeof2.Attributes.Add("class", "th do-not-allow-typing");
            //if (od.IntialAprd3 != 2)
            //    txtStrikeof3.Attributes.Add("class", "th do-not-allow-typing");
            //if (od.IntialAprd4 != 2)
            //    txtStrikeof4.Attributes.Add("class", "th do-not-allow-typing");



            //Label lblcdcharttargetdate = e.Row.FindControl("lblcdcharttargetdate") as Label;
            //TextBox TxtactualDate = e.Row.FindControl("TxtactualDate") as TextBox;

            //txtcdchartETA.Visible = od.FitsHOPPMETARead;

            //if (od.CDCharWrite == true)
            //{
            //    txtcdchartETA.Attributes.Add("class", "th do-not-allow-typing");
            //}
            //else
            //{
            //    txtcdchartETA.Attributes.Add("readonly", "readonly");
            //}

            //if (od.CdchartDateETA != DateTime.MinValue && od.CdchartActualDateETA != DateTime.MinValue)
            //{
            //    txtcdchartETA.CssClass = "do-not-allow-typing";
            //}
            //if (od.CdchartActualDateETA != DateTime.MinValue)
            //{
            //    TxtactualDate.CssClass = "do-not-allow-typing";
            //}

            //if (od.IsShiped == true)
            //{
            //    tdcdchat.Style.Add("background-color", "#F9F9FA");
            //    lblcdchat.Style.Add("color", "#807F80");
            //}
            //else
            //{
            //    if (od.CdchartTargetDateETA >= DateTime.Now.Date)
            //    {
            //        if (TxtactualDate.Text == "")
            //        {
            //            // tdcdchat.Style.Add("background-color", "#FFFFFF");
            //            lblcdchat.Style.Add("color", "Gray");
            //        }
            //    }
            //    else
            //    {

            //        if (TxtactualDate.Text == "")
            //        {
            //            tdcdchat.Style.Add("background-color", "#FFFF66");
            //            lblcdchat.Style.Add("color", "#FF3300");
            //        }
            //    }
            //}

            //if (txtcdchartETA != null)
            //{
            //    if (od.FitsHOPPMRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            //txtETAHOPPM.ForeColor = System.Drawing.Color.Gray;
            //            TxtactualDate.ForeColor = System.Drawing.Color.Gray;
            //            lblcdcharttargetdate.ForeColor = System.Drawing.Color.Gray;
            //            tdcdchat.Style.Add("background-color", "#F9F9FA");
            //            lblcdchat.ForeColor = System.Drawing.Color.Gray;
            //        }
            //        else
            //        {
            //            if (txtcdchartETA.Text != "" && TxtactualDate.Text != "")
            //            {
            //                //txtETAHOPPM.ForeColor = System.Drawing.Color.Gray;
            //                TxtactualDate.ForeColor = System.Drawing.Color.Gray;
            //                lblcdcharttargetdate.ForeColor = System.Drawing.Color.Gray;
            //                //tdcdchat.Style.Add("background-color", "#FFFFFF");
            //                txtcdchartETA.ForeColor = System.Drawing.Color.Gray;
            //            }
            //            else
            //            {
            //                //txtETAHOPPM.ForeColor = System.Drawing.Color.Black;
            //                TxtactualDate.ForeColor = System.Drawing.Color.Black;
            //                lblcdcharttargetdate.ForeColor = System.Drawing.Color.Black;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        //tdcdchat.Style.Add("background-color", "#FFFFFF");
            //    }
            //}
            //end by abhishek 11/2/2016
            // Added By Ravi kumar on 28/12/2015
            //Label lblst = (Label)e.Row.FindControl("lblst");
            //Label lblEnd = (Label)e.Row.FindControl("lblEnd");
            //Label lblCMTAct = (Label)e.Row.FindControl("lblCMTAct");
            //Label lblCMTTgt = (Label)e.Row.FindControl("lblCMTTgt");
            //Label lblCosted = (Label)e.Row.FindControl("lblCosted");
            //Label lblProfitLoss = (Label)e.Row.FindControl("lblProfitLoss");
            //Label lblActualEff = (Label)e.Row.FindControl("lblActualEff");
            //Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
            //Label lblBE = (Label)e.Row.FindControl("lblBE");

            if (od.LinePlannigStartDate == "")
                // lblst.Visible = false;

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
            //    txtHanoverETA.Attributes.Add("class", "th do-not-allow-typing");
            //}
            //else
            //{
            //    txtHanoverETA.Attributes.Add("readonly", "readonly");
            //}

            //if (od.FitsProdFileETAWrite == true)
            //{
            //    txtPatternReadyETADate.Attributes.Add("class", "th do-not-allow-typing");
            //}
            //else
            //{
            //    txtPatternReadyETADate.Attributes.Add("readonly", "readonly");
            //}

            //if (od.FitsProdFileETAWrite == true)
            //{
            //    txtSampleSentETA.Attributes.Add("class", "th do-not-allow-typing");
            //}
            //else
            //{
            //    txtSampleSentETA.Attributes.Add("readonly", "readonly");
            //}
            //if (od.FitsProdFileETAWrite == true)
            //{
            //    txtFitsCommentesUplaodETADate.Attributes.Add("class", "th do-not-allow-typing");
            //}
            //else
            //{
            //    txtFitsCommentesUplaodETADate.Attributes.Add("readonly", "readonly");
            //}


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


            //lblSTCName.Attributes.Add("onclick", "javascript:return ShowSamplingFitsHistory('" + od.ParentOrder.Style.StyleID + "')");

            Label txtSealDate = (Label)e.Row.FindControl("txtrequested");
            //=================Prabhaker-16-jun-17-------------//
            //////if (txtSealDate.Text == "")
            //////{
            //////    HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
            //////    //HtmlControl apprShow = (HtmlTable)this.FindControl("apprShow");
            //////    apprShow.Visible = true;
            //////    HtmlTableRow apprShow1 = (HtmlTableRow)e.Row.FindControl("apprShow1");
            //////    apprShow1.Visible = true;
            //////    HtmlTableRow apprShow2 = (HtmlTableRow)e.Row.FindControl("apprShow2");
            //////    apprShow2.Visible = true;
            //////    HtmlTableRow apprShow3 = (HtmlTableRow)e.Row.FindControl("apprShow3");
            //////    apprShow3.Visible = true;
            //////    HtmlTableRow apprHide = (HtmlTableRow)e.Row.FindControl("apprHide");
            //////    apprHide.Visible = false;
            //////    HtmlTableRow apprHide1 = (HtmlTableRow)e.Row.FindControl("apprHide1");
            //////    apprHide1.Visible = false;
            //////    HtmlTableRow apprHide2 = (HtmlTableRow)e.Row.FindControl("apprHide2");
            //////    apprHide2.Visible = false;
            //////    HtmlTableRow apprHide3 = (HtmlTableRow)e.Row.FindControl("apprHide3");
            //////    apprHide3.Visible = false;
            //////    HtmlTableRow apprHide4 = (HtmlTableRow)e.Row.FindControl("apprHide4");
            //////    apprHide4.Visible = false;
            //////    HtmlTableRow apprHide5 = (HtmlTableRow)e.Row.FindControl("apprHide5");
            //////    apprHide5.Visible = false;
            //////}
            //////else
            //////{
            //////    HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
            //////    apprShow.Visible = false;
            //////    HtmlTableRow apprShow1 = (HtmlTableRow)e.Row.FindControl("apprShow1");
            //////    apprShow1.Visible = false;
            //////    HtmlTableRow apprShow2 = (HtmlTableRow)e.Row.FindControl("apprShow2");
            //////    apprShow2.Visible = false;
            //////    HtmlTableRow apprShow3 = (HtmlTableRow)e.Row.FindControl("apprShow3");
            //////    apprShow3.Visible = false;
            //////    HtmlTableRow apprHide = (HtmlTableRow)e.Row.FindControl("apprHide");
            //////    apprHide.Visible = true;
            //////    HtmlTableRow apprHide1 = (HtmlTableRow)e.Row.FindControl("apprHide1");
            //////    apprHide1.Visible = true;
            //////    HtmlTableRow apprHide2 = (HtmlTableRow)e.Row.FindControl("apprHide2");
            //////    apprHide2.Visible = true;
            //////    HtmlTableRow apprHide3 = (HtmlTableRow)e.Row.FindControl("apprHide3");
            //////    apprHide3.Visible = true;
            //////    HtmlTableRow apprHide4 = (HtmlTableRow)e.Row.FindControl("apprHide4");
            //////    apprHide4.Visible = true;
            //////    HtmlTableRow apprHide5 = (HtmlTableRow)e.Row.FindControl("apprHide5");
            //////    apprHide5.Visible = true;

            //////}

            //=================End Code of Prabhaker-16-jun-17-------------//


            //if (od.IsShiped == true)
            //{
            //    tdSTC.Style.Add("background-color", "#F9F9FA");
            //    lblSTCName.Style.Add("color", "#807F80");
            //}
            //else
            //{

            //    if (od.STCtargetsDate.Date >= DateTime.Now.Date)
            //    {

            //        if (txtSealDate.Text == "")
            //        {

            //            //tdSTC.Style.Add("background-color", "#FFFFFF");
            //            lblSTCName.Style.Add("color", "Gray");
            //        }
            //    }
            //    else
            //    {

            //        if (txtSealDate.Text == "")
            //        {
            //            tdSTC.Style.Add("background-color", "#FFFF66");
            //            lblSTCName.Style.Add("color", "#FF3300");
            //        }
            //    }
            //}

            //if (lblSTCETA != null)
            //{
            //    if (od.FitsPatternRead == true)
            //    {

            //        if (od.IsShiped == true)
            //        {
            //            //lblSTCETA.ForeColor = System.Drawing.Color.Gray;
            //            txtSealDate.ForeColor = System.Drawing.Color.Gray;
            //            lblstctgt.ForeColor = System.Drawing.Color.Gray;
            //            //tdSTC.Style.Add("background-color", "#F9F9FA");
            //            lblSTCName.ForeColor = System.Drawing.Color.Gray;
            //        }
            //        else
            //        {
            //            if (lblSTCETA.Text != "" && txtSealDate.Text != "")
            //            {
            //                //lblSTCETA.ForeColor = System.Drawing.Color.Gray;
            //                txtSealDate.ForeColor = System.Drawing.Color.Gray;
            //                lblstctgt.ForeColor = System.Drawing.Color.Gray;
            //                // tdSTC.Style.Add("background-color", "#FFFFFF");
            //                lblSTCName.ForeColor = System.Drawing.Color.Gray;
            //            }
            //            else
            //            {
            //                //lblSTCETA.ForeColor = System.Drawing.Color.Black;
            //                txtSealDate.ForeColor = System.Drawing.Color.Black;
            //                lblstctgt.ForeColor = System.Drawing.Color.Black;
            //            }


            //        }
            //    }
            //    else
            //    {

            //    }
            //}
            //==========================================================// 
            //PatternSample=============
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
                        tdPatternSample.Style.Add("background-color", "#FFFF66");
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
                        tdCuttingSheet.Style.Add("background-color", "#FFFF66");
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
                        tdProdFile.Style.Add("background-color", "#FFFF66");
                        lblProdFile.Style.Add("color", "#FF3300");
                    }
                }
            }

            //------------------------------Handover---------------------------
            //if (od.IsShiped == true)
            //{
            //    tdHandover.Style.Add("background-color", "#F9F9FA");
            //    lblHandover.Style.Add("color", "#807F80");
            //}
            //else
            //{
            //    if (od.HandOverTargetDate.Date >= DateTime.Now.Date)
            //    {

            //        if (txHandoverActual.Text == "")
            //        {
            //            lblHandover.Style.Add("color", "Gray");
            //        }
            //    }
            //    else
            //    {
            //        if (txHandoverActual.Text == "")
            //        {
            //            tdHandover.Style.Add("background-color", "#FFFF66");
            //            lblHandover.Style.Add("color", "#FF3300");
            //            HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
            //            apprShow.Attributes.Add("class", "yellow-back");
            //        }
            //    }
            //}


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

            //-------------------------------HandOver------------------------
            //if (txtHanoverETA != null)
            //{
            //    if (od.FitsProdFileRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            //TextBox2.ForeColor = System.Drawing.Color.Gray;
            //            txHandoverActual.ForeColor = System.Drawing.Color.Gray;
            //            lblHandOverTargetDate.ForeColor = System.Drawing.Color.Gray;
            //            tdHandover.Style.Add("background-color", "#F9F9FA");
            //            lblHandover.ForeColor = System.Drawing.Color.Gray;
            //            if (txHandoverActual.Text != "")
            //            {
            //                txtHanoverETA.Text = txHandoverActual.Text;
            //            }
            //        }
            //        else
            //        {
            //            if (txHandoverActual.Text != "")
            //            {
            //                txHandoverActual.ForeColor = System.Drawing.Color.Gray;
            //                lblHandOverTargetDate.ForeColor = System.Drawing.Color.Gray;
            //                lblHandover.ForeColor = System.Drawing.Color.Gray;
            //                txtHanoverETA.Text = txHandoverActual.Text;
            //            }
            //            else
            //            {
            //                txHandoverActual.ForeColor = System.Drawing.Color.Black;
            //                lblHandOverTargetDate.ForeColor = System.Drawing.Color.Black;

            //            }
            //            if (txHandoverActual.Text == "")
            //            {
            //                HtmlTableRow apprShow = (HtmlTableRow)e.Row.FindControl("apprShow");
            //                apprShow.Attributes.Add("class", "yellow-back");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        //  tdProdFile.Style.Add("background-color", "#FFFFFF");
            //    }
            //}
            //-------------------------------end-----------------------------

            //-------------------------------Pattern Ready------------------------
            //if (txtPatternReadyETADate != null)
            //{
            //    if (od.FitsProdFileRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            //TextBox2.ForeColor = System.Drawing.Color.Gray;
            //            txtPatternReadyActualDate.ForeColor = System.Drawing.Color.Gray;
            //            lblPatternReadyTargetDate.ForeColor = System.Drawing.Color.Gray;
            //            tdPatternReady.Style.Add("background-color", "#F9F9FA");
            //            lblPatternReady.ForeColor = System.Drawing.Color.Gray;
            //            if (txtPatternReadyActualDate.Text != "")
            //            {
            //                txtPatternReadyETADate.Text = txtPatternReadyActualDate.Text;
            //            }
            //        }
            //        else
            //        {
            //            if (txtPatternReadyActualDate.Text != "")
            //            {
            //                txtPatternReadyActualDate.ForeColor = System.Drawing.Color.Gray;
            //                lblPatternReadyTargetDate.ForeColor = System.Drawing.Color.Gray;
            //                lblPatternReady.ForeColor = System.Drawing.Color.Gray;
            //                txtPatternReadyETADate.Text = txtPatternReadyActualDate.Text;
            //            }
            //            else
            //            {
            //                //TextBox2.ForeColor = System.Drawing.Color.Black;
            //                txtPatternReadyActualDate.ForeColor = System.Drawing.Color.Black;
            //                lblPatternReadyTargetDate.ForeColor = System.Drawing.Color.Black;
            //            }
            //            if (txtPatternReadyActualDate.Text == "")
            //            {
            //                HtmlTableRow apprShow1 = (HtmlTableRow)e.Row.FindControl("apprShow1");
            //                apprShow1.Attributes.Add("class", "yellow-back");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        //  tdProdFile.Style.Add("background-color", "#FFFFFF");
            //    }
            //}


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
                        if (txtSampleSentActualDate.Text == "")
                        {
                            HtmlTableRow apprShow2 = (HtmlTableRow)e.Row.FindControl("apprShow2");
                            apprShow2.Attributes.Add("class", "yellow-back");
                        }
                    }
                }
                else
                {
                    //  tdProdFile.Style.Add("background-color", "#FFFFFF");
                }
            }


            //-------------------------------end-----------------------------

            //-------------------------------Fits Commentes Uplaod------------------------

            //if (txtFitsCommentesUplaodETADate != null)
            //{
            //    if (od.FitsProdFileRead == true)
            //    {
            //        if (od.IsShiped == true)
            //        {
            //            //TextBox2.ForeColor = System.Drawing.Color.Gray;
            //            txtFitsCommentesUplaodActualDate.ForeColor = System.Drawing.Color.Gray;
            //            lblFitsCommentesUplaodTargetDate.ForeColor = System.Drawing.Color.Gray;
            //            tdFitsCommentesUplaod.Style.Add("background-color", "#F9F9FA");
            //            lblFitsCommentesUplaod.ForeColor = System.Drawing.Color.Gray;
            //            if (txtFitsCommentesUplaodActualDate.Text != "")
            //            {
            //                txtFitsCommentesUplaodETADate.Text = txtFitsCommentesUplaodActualDate.Text;
            //            }
            //        }
            //        else
            //        {
            //            if (txtFitsCommentesUplaodActualDate.Text != "")
            //            {
            //                txtFitsCommentesUplaodActualDate.ForeColor = System.Drawing.Color.Gray;
            //                lblFitsCommentesUplaodTargetDate.ForeColor = System.Drawing.Color.Gray;
            //                lblFitsCommentesUplaod.ForeColor = System.Drawing.Color.Gray;
            //                txtFitsCommentesUplaodETADate.Text = txtFitsCommentesUplaodActualDate.Text;
            //            }
            //            else
            //            {
            //                txtFitsCommentesUplaodActualDate.ForeColor = System.Drawing.Color.Black;
            //                lblFitsCommentesUplaodTargetDate.ForeColor = System.Drawing.Color.Black;
            //            }
            //            if (txtFitsCommentesUplaodActualDate.Text == "")
            //            {
            //                HtmlTableRow apprShow3 = (HtmlTableRow)e.Row.FindControl("apprShow3");
            //                apprShow3.Attributes.Add("class", "yellow-back");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        //  tdProdFile.Style.Add("background-color", "#FFFFFF");
            //    }
            //}



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
                        tdHoPPM.Style.Add("background-color", "#FFFF66");
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

            HtmlTableCell tdTopSent = (HtmlTableCell)e.Row.FindControl("tdTopSent");
            Label lblTopSent = (Label)e.Row.FindControl("lblTopSent");
            Label lblTopSendTarget = (Label)e.Row.FindControl("lblTopSendTarget");
            Label Label10 = (Label)e.Row.FindControl("Label10");
            // Added By Ravi kumar for Final Pass on 30/12/16
            //HyperLink hlnkQaPrevStatus = (HyperLink)e.Row.FindControl("hlnkQaPrevStatus");
            //Label lblInspection = (Label)e.Row.FindControl("lblInspection");
            //if (lblInspection.Text == " ")
            //{
            //    hlnkQaPrevStatus.NavigateUrl = "~/Internal/Merchandising/QC.aspx?OrderId=" + od.OrderID + "&OrderDetailID=" + od.OrderDetailID + "&InspectionIDM=3";
            //    hlnkQaPrevStatus.ToolTip = "Quality Assurance Form";
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
                        tdTopSent.Style.Add("background-color", "#FFFF66");
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

    }
}