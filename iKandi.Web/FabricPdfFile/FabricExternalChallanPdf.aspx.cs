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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
using System.Drawing;
using System.Web.Services;

namespace iKandi.Web.FabricPdfFile
{
    public partial class FabricExternalChallanPdf : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();

        #region Properties

        public string ChallanNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ChallanNumber"]))
                    return (Request.QueryString["ChallanNumber"].ToString());

                else return "";
            }
        }

        public int LoggedInUserID
        {
            get;
            set;
        }
        public static int ChallanID
        {
            get;
            set;
        }
        public static decimal ConversionValue
        {
            get;
            set;
        }
        public static int PoUnit
        {
            get;
            set;
        }
        public int SupplierPoID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["SupplierPoID"]))
                {
                    return Convert.ToInt32(Request.QueryString["SupplierPoID"]);
                }

                //return -1;
                return 139;
            }
        }
        public int DebitNoteId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["DebitNoteId"]))
                {
                    return Convert.ToInt32(Request.QueryString["DebitNoteId"]);
                }

                return -1;
            }
        }

        public string ChallanType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ChallanType"]))
                {
                    return (Request.QueryString["ChallanType"].ToString());
                }

                //return "";
                return "DEBITCHALLAN";
            }
        }
        //public string IsNewChallan
        //{
        //  get
        //  {
        //    if (!string.IsNullOrEmpty(Request.QueryString["IsNewChallan"]))
        //    {
        //      return (Request.QueryString["IsNewChallan"].ToString());
        //    }

        //    return "";
        //  }
        //}
        public string IsNewChallan;


        public string SendQty
        {
            get;
            set;

        }

        public int OrderDetailsID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailsID"]))
                {
                    return Convert.ToInt32(Request.QueryString["OrderDetailsID"]);
                }

                return -1;
            }
        }
        public int FabricQualityID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["FabricQualityID"]))
                {
                    return Convert.ToInt32(Request.QueryString["FabricQualityID"]);
                }

                return -1;
            }
        }
        public int UserId
        {
            get;
            set;
        }

        public string sqty
        {
            get;
            set;
        }
        public string cunit
        {
            get;
            set;
        }

        public string drqty
        {
            get;
            set;
        }

        public string dunit
        {
            get;
            set;
        }
        public string srmng
        {
            get;
            set;
        }
        public string units
        {
            get;
            set;
        }
        public string dustaticinfo
        {
            get;
            set;
        }
        public string dunitinfo
        {
            get;
            set;
        }


        public string NoItem
        {
            get;
            set;
        }

        public string ItemUnit
        {
            get;
            set;
        }

        public string totalQty
        {
            get;
            set;
        }

        public string AvaDebitCha
        {
            get;
            set;
        }

        public string AvaQty
        {
            get;
            set;
        }

        public string DebitdefQty
        {
            get;
            set;
        }

        public string DefStaticInfo
        {
            get;
            set;
        }

        public string convrtunit
        {
            get;
            set;
        }


        string host = "";

        public decimal Totalremaining = 0;
        public string IsClose;
        public static string FabricDetails;
        public string sendqtyinfo, converttounit, defualtremaningqty, defualtunit, sendreaming, defualtunitstaticinfo, defualtinitinfo, unit;

        public string NoItemVal, ItemUnitVal, totalQtyVal, AvaDebitChaVal, AvaQtyVal, DebitdefQtyVal, DefStaticInfoVal, convrtunitVal;



        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            GetQueryString();

            BindUnit();
            BindBasicDetails();

            DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress4");
            divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();

        }

        private void GetQueryString()
        {

            if (Request.QueryString["ChallanID"] != null)
            {
                ChallanID = Convert.ToInt32(Request.QueryString["ChallanID"]);
            }
            else
            {
                ChallanID = 125;
                //ChallanID = 0;
            }
            if (Request.QueryString["IsNewChallan"] != null)
            {
                IsNewChallan = Convert.ToString(Request.QueryString["IsNewChallan"].ToString());
            }
            if (!string.IsNullOrEmpty(Request.QueryString["SendQty"]))
            {
                SendQty = Request.QueryString["SendQty"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["fabricdetails"]))
            {
                FabricDetails = Request.QueryString["fabricdetails"].ToString();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["sqty"]))
            {
                sendqtyinfo = Request.QueryString["sqty"].ToString();
            }
            else
            {
                sendqtyinfo = "0";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cunit"]))
            {
                converttounit = Request.QueryString["cunit"].ToString();
            }
            else
            {
                converttounit = "";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["drqty"]))
            {
                defualtremaningqty = Request.QueryString["drqty"].ToString();
            }
            else
            {
                defualtremaningqty = "0";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["dunit"]))
            {
                defualtunit = Request.QueryString["dunit"].ToString();
            }
            else
            {
                defualtunit = "";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["srmng"]))
            {
                sendreaming = Request.QueryString["srmng"].ToString();
            }
            else
            {
                sendreaming = "0";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["units"]))
            {
                unit = Request.QueryString["units"].ToString();
            }
            else
            {
                unit = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["dustaticinfo"]))
            {
                defualtunitstaticinfo = Request.QueryString["dustaticinfo"].ToString();
            }
            else
            {
                defualtunitstaticinfo = "0";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["dunitinfo"]))
            {
                defualtinitinfo = Request.QueryString["dunitinfo"].ToString();
            }
            else
            {
                defualtinitinfo = "";
            }


            if (!string.IsNullOrEmpty(Request.QueryString["NoItem"]))
            {
                NoItemVal = Request.QueryString["NoItem"].ToString();
            }
            else
            {
                NoItemVal = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["ItemUnit"]))
            {
                ItemUnitVal = Request.QueryString["ItemUnit"].ToString();
            }
            else
            {
                ItemUnitVal = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["totalQty"]))
            {
                totalQtyVal = Request.QueryString["totalQty"].ToString();
            }
            else
            {
                totalQtyVal = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["AvaDebitCha"]))
            {
                AvaDebitChaVal = Request.QueryString["AvaDebitCha"].ToString();
            }
            else
            {
                AvaDebitChaVal = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["AvaQty"]))
            {
                AvaQtyVal = Request.QueryString["AvaQty"].ToString();
            }
            else
            {
                AvaQtyVal = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["DebitdefQty"]))
            {
                DebitdefQtyVal = Request.QueryString["DebitdefQty"].ToString();
            }
            else
            {
                DebitdefQtyVal = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["DefStaticInfo"]))
            {
                DefStaticInfoVal = Request.QueryString["DefStaticInfo"].ToString();
            }
            else
            {
                DefStaticInfoVal = "";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["convrtunit"]))
            {
                convrtunitVal = Request.QueryString["convrtunit"].ToString();
            }
            else
            {
                convrtunitVal = "";
            }


        }

        public void BindUnit()
        {
            DataTable dt = new DataTable();
            dt = fabobj.GetUnit();
            ddlthanunitsvalue.DataSource = dt;
            ddlthanunitsvalue.DataTextField = "UnitName";
            ddlthanunitsvalue.DataValueField = "GroupUnitID";
            ddlthanunitsvalue.DataBind();
        }

        public void BindBasicDetails()
        {
            boutiqueImg.ImageUrl = host + "/images/200x50 bipllog.png";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = fabobj.GetSupplierChallanDetails("CHALLANPROCESS").Tables[0];
            dt = fabobj.GetSupplierChallanDetails("SUPPLIERNAME").Tables[0];
            ddlsuppliername.DataSource = dt;
            ddlsuppliername.DataTextField = "Name";
            ddlsuppliername.DataValueField = "Id";
            ddlsuppliername.DataBind();
            ddlsuppliername.Enabled = false;

            #region DEBITCHALLAN
            if (ChallanType.ToUpper() == "DEBITCHALLAN")
            {
                ChallanPageHeading.InnerHtml = "Fabric Challan (Debit Note)";

                lblavailableqtydebitchallan.Visible = true;

                ddlext.SelectedValue = "1";
                trchallantype.Visible = false;
                tblisdayed.Visible = true;

                if (ChallanID <= 0)
                {
                    IsNewChallan = "NEWCHALLAN";
                }

                dt = fabobj.GetSupplierChallanDetails("CHALLAN", SupplierPoID, "EXT", ChallanID, IsNewChallan, DebitNoteId).Tables[0];



                if (dt.Rows.Count > 0)
                {
                    lblgstno.Text = dt.Rows[0]["GSTNo"].ToString();
                    lbladdress.Text = dt.Rows[0]["address"].ToString();

                    hdndefaultunit.Value = dt.Rows[0]["GarmentUnit"].ToString();
                    hdnconverttounit.Value = dt.Rows[0]["ConvertToUnit"].ToString();
                    PoUnit = Convert.ToInt32(dt.Rows[0]["ConvertToUnit"].ToString());
                    hdntotalmeter.Value = dt.Rows[0]["TotalMeters"].ToString();
                    ddlsuppliername.SelectedValue = dt.Rows[0]["SupplierID"].ToString();
                    lblsuppliername.Text = ddlsuppliername.SelectedItem.Text;

                    if (lblsuppliername.Text.ToLower() != "Select".ToLower())
                    {
                        ddlsuppliername.Attributes.Add("style", "display:none;");
                        lblsuppliername.Visible = true;
                    }


                    lblchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();
                    if (dt.Rows[0]["ChallanDate"].ToString() != "")
                        lblpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");
                    else
                        lblpodate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

                    if (dt.Rows[0]["IsAuthorized"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()))
                        {
                            divChkAuthorized.Style.Add("display", "none");
                            divSigAuthorized.Visible = true;
                            chkAuthorised.Checked = true;

                            hdnchkAuthorized.Value = "1";
                            foreach (var user in ApplicationHelper.Users)
                            {
                                if (Convert.ToInt32(dt.Rows[0]["AuthorisedBy"]) == user.UserID)
                                {
                                    lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                                    imgAuthorized.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                                    lblAuthorizedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["AuthorizedDate"]).ToString("dd MMM yy (ddd)");
                                }
                            }
                        }
                    }

                    if (dt.Rows[0]["IsReceived"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString()))
                        {
                            divChkReceive.Visible = false;
                            divSigReceive.Visible = true;
                            chkrecivegood.Checked = true;
                            hdnchkReceiver.Value = "1";
                            foreach (var user in ApplicationHelper.Users)
                            {
                                if (Convert.ToInt32(dt.Rows[0]["RecievedBy"]) == user.UserID)
                                {
                                    lblReceiverName.Text = user.FirstName + " " + user.LastName;
                                    imgReceiver.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                                    lblReceivedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["ReceivedDate"]).ToString("dd MMM yy (ddd)");
                                }
                            }
                        }
                    }

                    txtthanvalue.Text = dt.Rows[0]["ThanCount"].ToString();

                    ddlthanunitsvalue.SelectedValue = PoUnit.ToString();

                    txtponumber.Text = dt.Rows[0]["PO_Number"].ToString();

                    ddlext.SelectedValue = "1";

                    txtstylenumber.Text = dt.Rows[0]["StyleNumber"].ToString();

                    txtserialnumber.Text = dt.Rows[0]["BuyerSrNumber"].ToString();

                    txtcolorprint.Text = dt.Rows[0]["TradeName"].ToString() + "/" + dt.Rows[0]["ColorPrint"].ToString();

                    lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";

                    lblDescription.Text = dt.Rows[0]["ChallanDescription"].ToString().Replace("\r", "").Replace("\n", "<br>");

                    FabricDetails = dt.Rows[0]["ColorPrint"].ToString();

                    txtqtytotal.Text = totalQtyVal == "0" ? "" : decimal.Parse(totalQtyVal).ToString("#,#.##");

                    lblinternalconverttounit.Text = convrtunitVal;

                    if (txtqtytotal.Text != "")
                    {
                        lblinternalconverttounit.Visible = true;
                    }

                    lblavailableqtydebitchallan.Text = AvaDebitChaVal == "0" ? "" : AvaDebitChaVal;

                    lblavailabelqtyunitname.Text = AvaQtyVal;
                    if (lblavailableqtydebitchallan.Text != "")
                    {
                        lblavailbledebittext.Visible = true;
                        lblavailableqtydebitchallan.Visible = true;
                        lblavailabelqtyunitname.Visible = true;
                        lbldebitdefualtunitstaticinfo.Visible = true;
                        lbldebitdefualtqty.Visible = true;
                    }

                    lbldebitdefualtqty.Text = DebitdefQtyVal == "0" ? "" : DebitdefQtyVal;
                    lbldebitdefualtunitstaticinfo.Text = DefStaticInfoVal;

                    DataTable dtchk = fabobj.GetSelectedProcessForPdf("SELECTED_PROCESS_FOR_PDF", ChallanID);
                    for (int i = 0; i < dtchk.Rows.Count; i++)
                    {
                        if (lblCheckedList.Text == "")
                            lblCheckedList.Text = dtchk.Rows[i]["ProcessName"] == DBNull.Value ? "" : dtchk.Rows[i]["ProcessName"].ToString();

                        else
                            lblCheckedList.Text = lblCheckedList.Text + ", " + (dtchk.Rows[i]["ProcessName"] == DBNull.Value ? "" : dtchk.Rows[i]["ProcessName"].ToString());
                    }

                }
            }
            #endregion DEBITCHALLAN

            #region SENDQTYCHALLAN
            else if (ChallanType.ToUpper() == "SENDQTYCHALLAN")
            {
                ChallanPageHeading.InnerHtml = "Fabric Challan";

                sendqtyy.InnerHtml = "Send Qty. :";

                ds = fabobj.GetSupplierChallanDetails("CHALLAN", SupplierPoID, "EXTS", ChallanID, IsNewChallan);

                dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];

                hdndefaultunit.Value = dt.Rows[0]["GarmentUnit"].ToString();

                hdnconverttounit.Value = dt.Rows[0]["ConvertToUnit"].ToString();

                lblgstno.Text = dt.Rows[0]["GSTNo"].ToString();
                lbladdress.Text = dt.Rows[0]["address"].ToString();
               // rajeevs 09022023
                if (dt.Rows[0]["HSNCode"] != DBNull.Value)
                {
                    string HSNCode = dt.Rows[0]["HSNCode"].ToString();
                    if (HSNCode == "")
                    {
                        lblHSNcodeLabel.Visible = false;
                        lblHSNCode1.Visible = false;
                    }
                    else
                    {
                        lblHSNcodeLabel.Visible = true;
                        lblHSNCode1.Visible = true;
                        lblHSNCode1.Text = HSNCode;
                    }
                }
                // rajeevs 09022023
                ddlext.SelectedValue = "1";

                trchallantype.Visible = false;
                tblisdayed.Visible = false;
                divsend.Visible = true;
                tblmeterentry.Visible = false;

                if (dt.Rows.Count > 0)
                {
                    ddlsuppliername.SelectedValue = dt.Rows[0]["SupplierID"].ToString();
                    lblsuppliername.Text = ddlsuppliername.SelectedItem.Text;
                    if (lblsuppliername.Text.ToLower() != "Select".ToLower())
                    {
                        ddlsuppliername.Attributes.Add("style", "display:none;");
                        lblsuppliername.Visible = true;
                    }

                    string SamplingSupplierName = dt1.Rows[0]["SamplingSupplierName"].ToString();

                    if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]) && Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                    {
                        if (SamplingSupplierName != "")
                        {
                            lblsuppliername.Text = SamplingSupplierName;
                        }
                    }

                    lblchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();
                    if (dt.Rows[0]["ChallanDate"].ToString() != "")
                        lblpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");
                    else
                        lblpodate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

                    if (dt.Rows[0]["IsAuthorized"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()))
                        {
                            divChkAuthorized.Style.Add("display", "none");
                            divSigAuthorized.Visible = true;
                            hdnchkAuthorized.Value = "1";
                            foreach (var user in ApplicationHelper.Users)
                            {
                                if (Convert.ToInt32(dt.Rows[0]["AuthorisedBy"]) == user.UserID)
                                {
                                    lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                                    imgAuthorized.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                                    lblAuthorizedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["AuthorizedDate"]).ToString("dd MMM yy (ddd)");
                                }
                            }
                        }
                    }

                    if (dt.Rows[0]["IsReceived"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString()))
                        {
                            divChkReceive.Visible = false;
                            divSigReceive.Visible = true;
                            hdnchkReceiver.Value = "1";
                            foreach (var user in ApplicationHelper.Users)
                            {
                                if (Convert.ToInt32(dt.Rows[0]["RecievedBy"]) == user.UserID)
                                {
                                    lblReceiverName.Text = user.FirstName + " " + user.LastName;
                                    imgReceiver.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                                    lblReceivedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["ReceivedDate"]).ToString("dd MMM yy (ddd)");
                                }
                            }
                        }
                    }

                    txtponumber.Text = dt.Rows[0]["PO_Number"].ToString();
                    ddlext.SelectedValue = "1";
                    txtcolorprint.Text = dt.Rows[0]["TradeName"].ToString() + "/" + dt.Rows[0]["ColorPrint"].ToString();

                    lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";

                   lblDescription.Text = dt.Rows[0]["ChallanDescription"].ToString().Replace("\r", "").Replace("\n", "<br>");

                    FabricDetails = dt.Rows[0]["ColorPrint"].ToString();

                    txtsendqtyforinfo.Text = Convert.ToInt32(sendqtyinfo.Replace(",", "")) <= 0 ? "0" : Convert.ToInt32(sendqtyinfo.Replace(",", "")).ToString("N0");

                    lblconverttounit.Text = converttounit;

                    lbldefualtremaningqty.Text = Convert.ToInt32(defualtremaningqty.Replace(",", "")) <= 0 ? "0" : Convert.ToInt32(defualtremaningqty.Replace(",", "")).ToString("N0");

                    lbldefualtunit.Text = defualtunit;

                    sendreaming = Convert.ToDecimal(sendreaming) <= 0 ? "0" : sendreaming;

                    if (sendreaming != "0")
                        lblsendreaming.Text = "<span style='margin-left:5px;'>" + "</span>" + "Remaining Qty: " + Convert.ToDecimal(sendreaming).ToString("N0") + " " + unit;

                    else
                        lblsendreaming.Text = "";

                    lbldefualtunitstaticinfo.Text = Convert.ToInt32(defualtunitstaticinfo.Replace(",", "")) <= 0 ? "0" : Convert.ToInt32(defualtunitstaticinfo).ToString("N0");

                    lbldefualtinitinfo.Text = defualtinitinfo;

                    if (txtsendqtyforinfo.Text == "" || txtsendqtyforinfo.Text == "0")
                    {
                        txtsendqtyforinfo.Attributes.Add("style", "display:none");
                        lblconverttounit.Attributes.Add("style", "display:none");
                    }

                    if (lbldefualtremaningqty.Text == "" || lbldefualtremaningqty.Text == "0")
                    {
                        lbldefualtremaningqty.Attributes.Add("style", "display:none");
                        lbldefualtunit.Attributes.Add("style", "display:none");
                    }

                    if (lbldefualtunitstaticinfo.Text == "" || lbldefualtunitstaticinfo.Text == "0")
                    {
                        lbldefualtunitstaticinfo.Attributes.Add("style", "display:none");
                        lbldefualtinitinfo.Attributes.Add("style", "display:none");
                    }

                    if (lblsendreaming.Text == "" || lblsendreaming.Text == "0")
                        lblsendreaming.Text = "";


                    if (converttounit == defualtunit)
                    {
                        lbldefualtremaningqty.Text = "";
                        lbldefualtunit.Text = "";
                        lbldefualtunitstaticinfo.Text = "";
                        lbldefualtinitinfo.Text = "";
                    }


                    DataTable dtchk = fabobj.GetSelectedProcessForPdf("SELECTED_PROCESS_FOR_PDF", ChallanID);
                    for (int i = 0; i < dtchk.Rows.Count; i++)
                    {
                        if (lblCheckedList.Text == "")
                            lblCheckedList.Text = dtchk.Rows[i]["ProcessName"] == DBNull.Value ? "" : dtchk.Rows[i]["ProcessName"].ToString();

                        else
                            lblCheckedList.Text = lblCheckedList.Text + ", " + (dtchk.Rows[i]["ProcessName"] == DBNull.Value ? "" : dtchk.Rows[i]["ProcessName"].ToString());

                    }

                }
            }
            #endregion SENDQTYCHALLAN

            #region FOC_CHALLAN
            else if (ChallanType.ToUpper() == "FOC_CHALLAN".ToUpper())
            {
                ds = fabobj.GetSupplierChallanDetails("FOC_CHALLAN", SupplierPoID, "EXTFOC", -1, IsNewChallan, 0, ChallanNumber);
                dt = ds.Tables[0];

                trchallantype.Visible = false;

                ChallanPageHeading.InnerHtml = "Fabric Challan(Foc)";
                sendqtyy.InnerHtml = "Foc Challan Qty. :";

                lblchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();

                txtponumber.Text = dt.Rows[0]["PO_Number"].ToString();

                lblpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");

                lblCheckedList.Text = dt.Rows[0]["ProcessName"].ToString();

                ddlext.SelectedValue = "1";

                lblsuppliername.Text = dt.Rows[0]["SupplierName"].ToString();

                lblgstno.Text = dt.Rows[0]["GSTNo"].ToString();

                // rajeevs 09022023
                if (dt.Rows[0]["HSNCode"] != DBNull.Value)
                {
                    string HSNCode = dt.Rows[0]["HSNCode"].ToString();
                    if (HSNCode == "")
                    {
                        lblHSNcodeLabel.Visible = false;
                        lblHSNCode1.Visible = false;
                    }
                    else
                    {
                        lblHSNcodeLabel.Visible = true;
                        lblHSNCode1.Visible = true;
                        lblHSNCode1.Text = HSNCode;
                    }
                }
                // rajeevs 09022023

                lbladdress.Text = dt.Rows[0]["Address"].ToString();

                lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";

                lblDescription.Text = dt.Rows[0]["ChallanDescription"].ToString();

                divsend.Visible = true;

                txtsendqtyforinfo.Text = dt.Rows[0]["ActualChallanQty"].ToString() == "0" ? "" : dt.Rows[0]["ActualChallanQty"].ToString();

                if (dt.Rows[0]["IsAuthorized"].ToString() != "")
                {
                    if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()))
                    {
                        divChkAuthorized.Style.Add("display", "none");
                        divSigAuthorized.Visible = true;
                        chkAuthorised.Checked = true;

                        hdnchkAuthorized.Value = "1";
                        foreach (var user in ApplicationHelper.Users)
                        {
                            if (Convert.ToInt32(dt.Rows[0]["AuthorisedBy"]) == user.UserID)
                            {
                                lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                                imgAuthorized.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                                lblAuthorizedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["AuthorizedDate"]).ToString("dd MMM yy (ddd)");
                            }
                        }
                    }
                }
                if (dt.Rows[0]["IsReceived"].ToString() != "")
                {
                    if (Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString()))
                    {
                        divChkReceive.Visible = false;
                        divSigReceive.Visible = true;
                        chkrecivegood.Checked = true;
                        hdnchkReceiver.Value = "1";
                        foreach (var user in ApplicationHelper.Users)
                        {
                            if (Convert.ToInt32(dt.Rows[0]["RecievedBy"]) == user.UserID)
                            {
                                lblReceiverName.Text = user.FirstName + " " + user.LastName;
                                imgReceiver.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                                lblReceivedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["ReceivedDate"]).ToString("dd MMM yy (ddd)");
                            }
                        }
                    }
                }

            }
            #endregion FOC_CHALLAN

            if (txtsendqtyforinfo.Text == "0")
            {

                txtsendqtyforinfo.Text = "";
                txtsendqtyforinfo.Enabled = false;
            }
        }
    }
}