using System;
using System.Collections;
using System.Collections.Generic;
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
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
using System.Drawing;
using System.Web.Services;
using System.Net;
using System.Net.Mail;
using System.IO;
using iTextSharp;
using Pechkin;
using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Web.Configuration;



namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricSupplierChallanDetails : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();

        #region Properties

        public int LoggedInUserID
        {
            get;
            set;
        }

        public int ChallanID
        {
            get;
            set;
        }

        public int FocId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["FocId"]))
                {
                    return Convert.ToInt32(Request.QueryString["FocId"]);
                }
                return -1;
            }
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
                return -1;
            }
        }

        public int DebitNote_Id
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["DebitNote_Id"]))
                {
                    return Convert.ToInt32(Request.QueryString["DebitNote_Id"]);
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
                return "";
            }
        }

        public string IsNewChallan
        {
            get;
            set;
        }

        public string FabType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["FabType"]))
                {
                    return (Request.QueryString["FabType"].ToString());
                }
                return "";
            }
        }

        public static string SendQty
        {
            get;
            set;

        }

        public static decimal Challaqty
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

        public int ReturnedChallanQty
        {
            get
            {
                if (hdnreturnedchallanqty.Value == "")
                {
                    hdnreturnedchallanqty.Value = "0";  // value -1 to 0 replaced 17042023 rajeevS
                    return 0;
                }
                return Convert.ToInt32(hdnreturnedchallanqty.Value);
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

        public string ColorPrint
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ColorPrint"]))
                {
                    return (Request.QueryString["ColorPrint"].ToString());
                }
                return "";
            }
        }

        string host1 = "";
        string MailType1 = "Fabric Send Challan ";
        string PoPath = string.Empty;
        public decimal Totalremaining = 0;
        public string IsClose;
        public static string FabricDetails;

        #endregion

        static decimal TotalSendQty = 0;
        public int SavedChallanQty = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            host1 = "http://" + Request.Url.Authority;
            GetQueryString();

            if (ApplicationHelper.LoggedInUser == null)
                Response.Redirect("~/public/Login.aspx");
            else
                LoggedInUserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            if (!IsPostBack)
            {
                DataTable dt = fabobj.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();

                DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", "", SupplierPoID).Tables[0];
                if (dtstatus.Rows.Count > 0)
                {
                    if (dtstatus.Rows[0]["postatus"].ToString() == "2")
                        fabric_challan_rategst.Visible = false;
                }

                if (SupplierPoID > 0)
                {
                    if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
                    {
                        IsClose = "1";
                        txtpodate.Enabled = false;

                        foreach (RepeaterItem rptItem in Repeater1.Items)
                        {
                            if (rptItem.FindControl("chkoption") != null)
                                ((CheckBox)rptItem.FindControl("chkoption")).Enabled = false;
                        }

                        lblsendreaming.Visible = false;
                        chkAuthorised.Enabled = false;
                        chkrecivegood.Enabled = false;
                        dvSendMail.Visible = false;
                        ddlsuppliername.Enabled = false;
                        txtthanvalue.Enabled = false;
                        txtsendqtyforinfo.Enabled = false;
                        chkAuthorised.Enabled = false;
                        btnSubmit.Visible = false;

                        foreach (Control c in Page.Controls)
                        {
                            foreach (Control ctrl in c.Controls)
                            {
                                if (ctrl is TextBox)
                                    ((TextBox)ctrl).Enabled = false;

                            }
                        }
                    }
                    else
                    {
                        IsClose = "0";
                    }

                }

                BindBasicDetails();
                SetPermission();
                Session["myTable"] = null;
                Session["myTable2"] = null;
                bindsplitsgrd();

                if (ChallanType.ToUpper() == "DEBITCHALLAN")
                {
                    if (chkrecivegood.Checked == false && chkAuthorised.Checked == false)
                    {
                        txtthanvalue.Enabled = true;
                        txtdiscription.Enabled = true;
                        chkrecivegood.Enabled = true;
                        chkAuthorised.Enabled = true;
                        btnSubmit.Visible = true;
                        dvSendMail.Visible = true;
                    }
                    if (hdnchkReceiver.Value == "1" && hdnchkAuthorized.Value == "1")
                    {

                        btnSubmit.Visible = true;
                        dvSendMail.Visible = true;
                    }
                }
            }

            //--------------Edit by surendra on 22-03-2021
            if (lblavailableqtydebitchallan.Text == "0")
                tdRightBorder.Attributes.Add("style", "display:none");
        }

        private void GetQueryString()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["SendQty"]))
            {
                SendQty = Request.QueryString["SendQty"].ToString();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["fabricdetails"]))
            {
                FabricDetails = Request.QueryString["fabricdetails"].ToString();
            }

            if (null != Request.QueryString["status"] && Request.QueryString["status"] != "")
            {
                hdnstatus.Value = Request.QueryString["status"].ToString();
            }

            if (null != Request.QueryString["IsNewChallan"] && Request.QueryString["IsNewChallan"] != "")
            {
                IsNewChallan = Request.QueryString["IsNewChallan"].ToString();
                hdnisnewchallan.Value = Request.QueryString["IsNewChallan"].ToString();
            }
            else IsNewChallan = "";

            if (null != Request.QueryString["ChallanID"] && Request.QueryString["ChallanID"] != "")
            {
                ChallanID = Convert.ToInt32(Request.QueryString["ChallanID"].ToString());
            }
        }

        public void SetPermission()
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation != iKandi.Common.Designation.BIPL_Fabrics_Manager &&
                iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation != iKandi.Common.Designation.BIPL_Fabrics_AssistantEntry &&
                iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation != iKandi.Common.Designation.BIPL_Fabrics_Assistant &&
                iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation != iKandi.Common.Designation.BIPL_Fabrics_Store_Assistent &&
                iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation != iKandi.Common.Designation.BIPL_Fabrics_Manager_Fabric_Store)
            {
                chkAuthorised.Enabled = false;
                btnSubmit.Visible = false;
            }
        }

        public void BindBasicDetails()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt = fabobj.GetSupplierChallanDetails("CHALLANPROCESS").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            dt = fabobj.GetSupplierChallanDetails("SUPPLIERNAME").Tables[0];
            ddlsuppliername.DataSource = dt;
            ddlsuppliername.DataTextField = "Name";
            ddlsuppliername.DataValueField = "Id";
            ddlsuppliername.DataBind();
            ddlsuppliername.Enabled = false;

            //new work start :Girish
            #region ExtraStockIssue

            if (ChallanType.ToUpper() == "ExtraStockIssue".ToUpper())
            {
                tdCompanyType.Attributes.Add("style", "display:none");
                intstylenumber.Visible = true;
                intserialnumber.Visible = true;

                txtsendqtyforinfo.Visible = false;
                tblisdayed.Visible = true;
                tdRightBorder.Visible = false;
                divsend.Visible = false;
                lblinternalconverttounit.Visible = true;
                extrastockissue.Visible = true;
                fabric_challan_rategst.Visible = false;

                ds = fabobj.Create_Challan_From_StockQty("ExtraStockIssue", IsNewChallan, OrderDetailsID, FabricQualityID, ColorPrint, "INTGS", ChallanID);
                dt = ds.Tables[0];

                ChallanPageHeading.InnerHtml = "Fabric Challan (Extra Stock Issue)";

                txtchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();

                if (dt.Rows[0]["ChallanDate"].ToString() != "")
                    txtpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");
                else
                    txtpodate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

                ddlext.SelectedValue = "0";

                DataTable dt_unit = fabobj.GetSupplierChallanDetails("PRODUCTIONUNIT").Tables[0];
                ddlsuppliername.DataSource = dt_unit;
                ddlsuppliername.DataBind();
                ddlsuppliername.Enabled = true;

                ddlsuppliername.SelectedValue = dt.Rows[0]["InternalUnit"].ToString();
                hdnSelectedSupplier.Value = dt.Rows[0]["InternalUnit"].ToString();

                //new work start(Showing GST No in Internal Challan): Girish

                hdnInternalUnitIds.Value = dt.Rows[0]["InternalUnitIds"].ToString();

                if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]) && Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                {
                    if (dt.Rows[0]["GSTNo"].ToString() == "")
                    {
                        trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:none;");
                    }
                    else
                    {
                        trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:contents;");
                        txtGSTNoForInternalChallan.Text = dt.Rows[0]["GSTNo"].ToString();
                        hdnGSTNoForInternalChallan.Value = dt.Rows[0]["GSTNo"].ToString();
                        txtGSTNoForInternalChallan.Enabled = false;
                        txtGSTNoForInternalChallan.Attributes.Add("style", "width: 50%;border:none;background-color:white;");
                    }
                }
                else
                {
                    if (!dt.AsEnumerable().Any(row => row.Field<string>("InternalUnitIds").Split(',').Any(val => val.Trim() == ddlsuppliername.SelectedValue)))
                    {
                        trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:contents;");
                        txtGSTNoForInternalChallan.Text = dt.Rows[0]["GSTNo"].ToString();
                        hdnGSTNoForInternalChallan.Value = dt.Rows[0]["GSTNo"].ToString();
                    }
                }
                //new work End : Girish

                txtstylenumber.Text = dt.Rows[0]["StyleNumber"].ToString();
                txtserialnumber.Text = dt.Rows[0]["SerialNumber"].ToString();
                //// rajeevs 10022023    ExtraStockIssue         
                //string HSNCode = dt.Rows[0]["HSNCode"].ToString();
                //if (((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString()))) && ((HSNCode == null) || (HSNCode == "")))
                //{
                //    spn_HSNCode.InnerHtml = "";
                //    lblHSNCode.Visible = false;
                //}
                //else
                //{
                //    if ((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString())))
                //        lblHSNCode.BorderStyle = BorderStyle.None;
                //    lblHSNCode.Visible = true;
                //    lblHSNCode.Text = HSNCode;
                //    spn_HSNCode.InnerHtml = "HSNCode";
                //}
                // rajeevs 10022023	

                lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";

                txtdiscription.Text = dt.Rows[0]["Description"].ToString();

                totalqtyissuedtillnow.InnerText = dt.Rows[0]["totalqtyissuedtillnow"].ToString();
                totalqtyissuedtillnow_unit.InnerText = dt.Rows[0]["totalqtyissuedtillnow_unit"].ToString();

                totalissuedfromstock.InnerText = dt.Rows[0]["totalissuedfromstock"].ToString();
                totalissuedfromstock_unit.InnerText = dt.Rows[0]["totalissuedfromstock_unit"].ToString();

                balanceinstock.InnerText = dt.Rows[0]["balanceinstock"].ToString();
                balanceinstock_unit.InnerText = dt.Rows[0]["balanceinstock_unit"].ToString();
                balanceinstock_stage.InnerText = dt.Rows[0]["balanceinstock_stage"].ToString() == "" ? "" : " (" + dt.Rows[0]["balanceinstock_stage"].ToString() + ")";

                txtthanvalue.Visible = true;
                txtthanvalue.Text = dt.Rows[0]["ThanValue"].ToString();
                txtqtytotal.Text = dt.Rows[0]["ChallanQty"].ToString();

                lbldebitnochallacaption.Visible = true;
                txtqtytotal.Visible = true;

                internalreturnchallanqty.Text = dt.Rows[0]["StockReverseQty"].ToString();

                if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]))
                {
                    chkAuthorised.Checked = true;
                    divChkAuthorized.Style.Add("display", "none");
                    divSigAuthorized.Visible = true;
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

                if (Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                {
                    chkrecivegood.Checked = true;
                    divChkReceive.Style.Add("display", "none");
                    divSigReceive.Visible = true;
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

                DataTable dtchk = null;
                if (IsNewChallan.ToLower() != "NEWCHALLAN".ToLower())
                {
                    dtchk = fabobj.deletechallan("SELECTEDPROCESS", ChallanID).Tables[0];
                }

                foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                        HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");

                        if (IsNewChallan.ToLower() == "NEWCHALLAN".ToLower())
                        {
                            if (hdnChallan_Process_Admin_Id.Value == "8")
                                chkprocess.Checked = true;
                        }
                        else
                        {
                            if (dtchk.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtchk.Rows)
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == row["ProcessID"].ToString())
                                        chkprocess.Checked = true;
                                }
                            }
                        }
                    }
                }

                if (Convert.ToBoolean(dt.Rows[0]["IsSettlementDone"]))
                    btnSubmit.Visible = false;

            }
            #endregion ExtraStockIssue
            //new work End :Girish

            //new work start :Girish
            #region FOC_CHALLAN

            else if (ChallanType.ToUpper() == "FOC_CHALLAN".ToUpper())
            {
                trToShowGSTNoForInternalChallan.Visible = false;
                ds = fabobj.GetSupplierChallanDetails("FOC_CHALLAN", SupplierPoID, "EXTFOC", FocId, IsNewChallan, 0);
                dt = ds.Tables[0];

                focextrapercenttext.Visible = true;
                focextrapercentbox.Visible = true;
                if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation == iKandi.Common.Designation.BIPL_Fabrics_Manager)
                {
                    focextrapercentbox.Enabled = true;
                }

                ChallanPageHeading.InnerHtml = "Fabric Challan(Foc)";

                sendqtyy.InnerHtml = "Foc Challan Qty. :";

                if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]) == true && Convert.ToBoolean(dt.Rows[0]["IsReceived"]) == true)
                {
                    externalreturnchallanqtytitle.InnerHtml = "Foc Reverse Challan Qty. :";
                    externalreturnchallanqtytitle.Visible = true;

                    externalreturnchallanqty.Visible = true;
                    externalreturnchallanqty.Text = dt.Rows[0]["FocReverseChallanQty"].ToString();
                    hdnexternalreturnchallanqty.Value = dt.Rows[0]["FocReverseChallanQty"].ToString() == "0" ? "" : dt.Rows[0]["FocReverseChallanQty"].ToString();

                    lblconverttounit2.Visible = true;
                    lblconverttounit2.Text = dt.Rows[0]["unit"].ToString();

                }
                if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]) == true || Convert.ToBoolean(dt.Rows[0]["IsReceived"]) == true)
                {
                    txtsendqtyforinfo.Enabled = false;

                }

                focnote.InnerHtml = "<br><span style='color:gray;font-weight:bold;'>Note:</span>&nbsp;(Foc Challan Qty. - Foc Reverse Qty.) cannot be greater than [Total Send Qty.(Without Foc) - Total Send Qty.(Foc)].<br><br>";

                focrequiredinfo.Visible = true;

                TotalSendQtyWithoutFoc.InnerText = dt.Rows[0]["TotalSendQtyWithoutFoc"].ToString();

                Withoutfocunit.InnerText = dt.Rows[0]["Withoutfocunit"].ToString();

                TotalSendQtyWithFoc.InnerText = dt.Rows[0]["TotalSendQtyWithFoc"].ToString();

                Withfocunit.InnerText = dt.Rows[0]["Withfocunit"].ToString();

                FocStockAvailableQty.InnerText = dt.Rows[0]["StockQty"].ToString();

                if (dt.Rows[0]["StockQty"].ToString() == "0" && dt.Rows[0]["TotalSendQtyWithFoc"].ToString() == "")
                    btnSubmit.Visible = false;

                hdnremainingqty.Value = dt.Rows[0]["StockQty"].ToString();

                stockqtyunit.InnerText = dt.Rows[0]["stockqtyunit"].ToString();

                StockAvailableQtyAtStage.InnerText = dt.Rows[0]["PreviousStage"].ToString() == "" ? "" : " (" + dt.Rows[0]["PreviousStage"].ToString() + ")";

                txtchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();
                hdnChallan_Number.Value = dt.Rows[0]["ChallanNumber"].ToString();

                txtponumber.Text = dt.Rows[0]["PO_Number"].ToString();

                // rajeevs 10022023  FOC_CHALLAN          
                string HSNCode = dt.Rows[0]["HSNCode"].ToString();
                if ((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString())) && ((HSNCode == null) || (HSNCode == "")))
                {
                    spn_HSNCode.InnerHtml = "";
                    lblHSNCode.Visible = false;
                }
                else
                {
                    if ((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString())))
                        lblHSNCode.BorderStyle = BorderStyle.None;
                    lblHSNCode.BackColor = Color.Transparent;
                    lblHSNCode.Visible = true;
                    lblHSNCode.Text = HSNCode;
                    spn_HSNCode.InnerHtml = "HSNCode";
                }
                // rajeevs 10022023	
                hdnPO_Number.Value = dt.Rows[0]["PO_Number"].ToString();

                if (dt.Rows[0]["ChallanDate"].ToString() != "")
                    txtpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");
                else
                    txtpodate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

                DataTable dtchk = null;
                if (IsNewChallan.ToLower() != "NEWCHALLAN".ToLower())
                {
                    dtchk = fabobj.deletechallan("SELECTEDPROCESS", FocId).Tables[0];
                }

                foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                        HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");

                        if (IsNewChallan.ToLower() == "NEWCHALLAN".ToLower())
                        {
                            if (FabType.ToLower() == "Dyed".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "2")
                                    chkprocess.Checked = true;
                            }

                            else if (FabType.ToLower() == "Printed".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "3")
                                    chkprocess.Checked = true;
                            }

                            else if (FabType.ToLower() == "Embellishment".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "30")
                                    chkprocess.Checked = true;
                            }

                            else if (FabType.ToLower() == "Embroidery".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "31")
                                    chkprocess.Checked = true;
                            }

                            else if (FabType.ToLower() == "RFD".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "29")
                                    chkprocess.Checked = true;
                            }
                        }
                        else
                        {
                            if (dtchk.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtchk.Rows)
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == row["ProcessID"].ToString())
                                        chkprocess.Checked = true;
                                }
                            }
                        }
                    }
                }

                ddlext.SelectedValue = "1";

                lblsuppliername.Text = dt.Rows[0]["SupplierName"].ToString();
                ddlsuppliername.SelectedValue = dt.Rows[0]["SupplierID"].ToString();

                lblgstno.Text = dt.Rows[0]["GSTNo"].ToString();

                lbladdress.Text = dt.Rows[0]["Address"].ToString();

                lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";
                hdnFabricQuality.Value = dt.Rows[0]["TradeName"].ToString();

                txtdiscription.Text = dt.Rows[0]["ChallanDescription"].ToString();

                lblrate.Text = dt.Rows[0]["Rate"].ToString();

                string GstNo = dt.Rows[0]["GSTNo"].ToString() == "" ? "" : dt.Rows[0]["GSTNo"].ToString().Substring(0, 2);

                hdnGst.Value = dt.Rows[0]["GST"].ToString();

                ConversionValue = Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString());
                hdnconversionvalue.Value = dt.Rows[0]["ConversionValue"].ToString();

               

                txtsendqtyforinfo.Text = dt.Rows[0]["ActualChallanQty"].ToString() == "0" ? "" : dt.Rows[0]["ActualChallanQty"].ToString();
                lblconverttounit.Text = dt.Rows[0]["unit"].ToString() == "0" ? "" : dt.Rows[0]["unit"].ToString();
                lblconverttounit.Visible = true;
                focextrapercentbox.Text = dt.Rows[0]["FocExtraPercent"].ToString() == "0" ? "" : dt.Rows[0]["FocExtraPercent"].ToString();

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

                hdnreturnedchallanqty.Value = dt.Rows[0]["FocReverseChallanQty"].ToString();

                string TotalAmount=Convert.ToString(Math.Round((((Convert.ToDecimal(dt.Rows[0]["Rate"]) * Convert.ToDecimal(dt.Rows[0]["ActualChallanQty"])) * (100 + Convert.ToDecimal(dt.Rows[0]["GST"]))) / 100),0));
                lblTotalAmount.Text = Math.Round((((Convert.ToDecimal(dt.Rows[0]["Rate"]) * Convert.ToDecimal(dt.Rows[0]["ActualChallanQty"])) * (100 + Convert.ToDecimal(dt.Rows[0]["GST"]))) / 100),0).ToString("0.00");
               
                if (GstNo == "09")
                {
                    licgst.Visible = true;
                    lisgst.Visible = true;
                    lblcgst.Text = Convert.ToString((Convert.ToDecimal(dt.Rows[0]["GST"]) / 2));
                    lblsgst.Text = Convert.ToString((Convert.ToDecimal(dt.Rows[0]["GST"]) / 2));
                    if (!string.IsNullOrEmpty(lblTotalAmount.Text))
                    {
                        lblCGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(TotalAmount) - (Convert.ToInt32(TotalAmount) * 100 / (100 + Convert.ToDecimal(dt.Rows[0]["GST"]) / 2)), 0)) +")";
                        lblSGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(TotalAmount) - (Convert.ToInt32(TotalAmount) * 100 / (100 + Convert.ToDecimal(dt.Rows[0]["GST"]) / 2)), 0)) +")";
                        if (lblSGSTValue.Text == "(₹" + "0" + ")")
                            lblSGSTValue.Text = "";
                        if (lblCGSTValue.Text == "(₹" + "0" + ")")
                            lblCGSTValue.Text = "";
                       
                    }
                    igst.Visible = false;
                    lblCGSTValue.Visible = true;
                    lblSGSTValue.Visible = true;
                    lblIGSTValue.Visible = false;
                    
                    
                    

                }
                else
                {
                    igst.Visible = true;
                    lblCGSTValue.Visible = false;
                    lblSGSTValue.Visible = false;
                    lblIGSTValue.Visible = true;
                   

                    lbligst.Text = dt.Rows[0]["GST"].ToString();
                    if (!string.IsNullOrEmpty(lblTotalAmount.Text))
                    {
                        lblIGSTValue.Text =  "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(TotalAmount) - (Convert.ToInt32(TotalAmount) * 100 / (100 + Convert.ToDecimal(dt.Rows[0]["GST"]))), 0))+")";
                        licgst.Visible = false;
                        if (lblIGSTValue.Text == "(₹" + "0" + ")")
                            lblIGSTValue.Text = "";
                    }
                    lisgst.Visible = false;
                }
            }
            #endregion FOC_CHALLAN
            //new work End :Girish

            #region DEBITCHALLAN Start
            else if (ChallanType.ToUpper() == "DEBITCHALLAN")
            {
                trToShowGSTNoForInternalChallan.Visible = false;
                ChallanPageHeading.InnerHtml = "Fabric Challan (Debit Note)";
                fabric_challan_rategst.Visible = true;
                lblavailableqtydebitchallan.Visible = true;
                lblavailbledebittext.Visible = true;

                divsend.Visible = false;

                ddlext.SelectedValue = "1";

                tblisdayed.Visible = true;
                if (ChallanID <= 0)
                {
                    IsNewChallan = "NEWCHALLAN";
                    hdnisnewchallan.Value = "NEWCHALLAN";
                }
                ds = fabobj.GetSupplierChallanDetails("CHALLAN", SupplierPoID, "EXT", ChallanID, IsNewChallan, DebitNote_Id);
                dt = ds.Tables[0];
                dt1 = ds.Tables[1];
                if (dt.Rows.Count > 0)
                {
                    hdndefaultunit.Value = dt.Rows[0]["GarmentUnit"].ToString();
                    hdnconverttounit.Value = dt.Rows[0]["ConvertToUnit"].ToString();
                    PoUnit = Convert.ToInt32(dt.Rows[0]["ConvertToUnit"].ToString());
                    //lblunitname.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(PoUnit));                   

                    if (IsNewChallan == "NEWCHALLAN")
                    {
                        lblgstno.Text = dt1.Rows[0]["GSTNo"].ToString();
                        lbladdress.Text = dt1.Rows[0]["address"].ToString();
                    }
                    else
                    {
                        lblTotalAmount.Text = dt1.Rows[0]["TotalAmount"].ToString();
                        lblgstno.Text = dt1.Rows[0]["GSTNo"].ToString();
                        lbladdress.Text = dt1.Rows[0]["address"].ToString();
                    }

                    hdnSendQty.Value = SendQty;
                    lblrate.Text = dt1.Rows[0]["Rate"].ToString();
                    hdnGst.Value = dt1.Rows[0]["GST"].ToString();

                    string gst = dt1.Rows[0]["GSTNo"].ToString() == "" ? "" : dt1.Rows[0]["GSTNo"].ToString().Substring(0, 2);
                    if (gst == "09")
                    {
                        licgst.Visible = true;
                        lisgst.Visible = true;
                        lblcgst.Text = Convert.ToString((Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2));
                        lblsgst.Text = Convert.ToString((Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2));
                        if (!string.IsNullOrEmpty(lblTotalAmount.Text))
                        {
                            lblCGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2)), 0)) + ")";
                            lblSGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2)), 0)) + ")";
                            if (lblSGSTValue.Text == "(₹" + "0" + ")")
                                lblSGSTValue.Text = "";
                            if (lblCGSTValue.Text == "(₹" + "0" + ")")
                                lblCGSTValue.Text = "";
                        }
                             igst.Visible = false;
                    }
                    else
                    {
                        TdCGSTValue.Visible = false;
                        TdSGSTValue.Visible = false;
                        lblCGSTValue.Visible = false;
                        lblSGSTValue.Visible = false;
                        igst.Visible = true;
                        lbligst.Text = dt1.Rows[0]["GST"].ToString();
                        if (!string.IsNullOrEmpty(lblTotalAmount.Text))
                        {
                            lblIGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(dt1.Rows[0]["GST"]))), 0)) + ")";
                            if (lblIGSTValue.Text == "(₹" + "0" + ")")
                                lblIGSTValue.Text = "";
                        }
                             licgst.Visible = false;
                        lisgst.Visible = false;
                    }
                    DataTable stxc = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderDetailsID), Convert.ToInt32(FabricQualityID), FabricQualityID, OrderDetailsID, "", dt.Rows[0]["ColorPrint"].ToString()).Tables[1];
                    if (stxc.Rows.Count > 0)
                    {
                        hdnmaxavailbleqty.Value = stxc.Rows[0]["LastestStageVal"].ToString();
                    }
                    lblinternalconverttounit.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(dt.Rows[0]["ConvertToUnit"].ToString()));
                    lblinternalconverttounit.Visible = true;

                    lblavailabelqtyunitname.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(dt.Rows[0]["ConvertToUnit"].ToString()));
                    lblavailabelqtyunitname.Visible = true;

                    if (dt.Rows[0]["TotalMeters"].ToString() != "")
                    {
                        int nNumber = int.TryParse(dt.Rows[0]["TotalMeters"].ToString().Replace(",", ""), out nNumber) ? nNumber : 0;
                        txtqtytotal.Text = decimal.Parse(nNumber.ToString()).ToString("#,#.##");
                    }
                    hdnconversionvalue.Value = dt.Rows[0]["ConversionValue"].ToString();
                    ConversionValue = Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString());
                    if (hdndefaultunit.Value != hdnconverttounit.Value)
                    {
                        lbldebitdefualtqty.Visible = true;
                        lbldebitdefualtunitstaticinfo.Visible = true;
                        lbldebitdefualtunitstaticinfo.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(dt.Rows[0]["GarmentUnit"].ToString()));
                    }
                    if (ChallanID > 0)
                    {
                        hdnmaxcount.Value = (dt.Rows[0]["TotalMeters"].ToString() == "" ? "0" : dt.Rows[0]["TotalMeters"].ToString());
                    }
                    else
                    {
                        hdnmaxcount.Value = (dt.Rows[0]["TotalMetersval"].ToString() == "" ? "0" : dt.Rows[0]["TotalMetersval"].ToString());
                    }
                    //issue reprted on 22022023
                    lblavailableqtydebitchallan.Text = Math.Abs((Convert.ToDecimal(hdnmaxcount.Value) - Convert.ToDecimal(dt.Rows[0]["debitavailableqty"].ToString()))).ToString("N0");
                    hdn_AvailableDebitChallanQty.Value = lblavailableqtydebitchallan.Text;

                    hdndebitavailebaleqty.Value = dt.Rows[0]["debitavailableqty"].ToString().ToString();

                    lbldebitdefualtqty.Text = (Math.Round((Convert.ToDecimal(lblavailableqtydebitchallan.Text == "0" ? SendQty : lblavailableqtydebitchallan.Text) / Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString())), 0)).ToString("N0");
                    hdn_DebitDefaultQty.Value = lbldebitdefualtqty.Text;

                    hdntotalmeter.Value = dt.Rows[0]["TotalMeters"].ToString();
                    ddlsuppliername.SelectedValue = dt.Rows[0]["SupplierID"].ToString();
                    lblsuppliername.Text = ddlsuppliername.SelectedItem.Text;
                    if (lblsuppliername.Text.ToLower() != "Select".ToLower())
                    {
                        ddlsuppliername.Attributes.Add("style", "display:none;");
                        lblsuppliername.Visible = true;
                    }

                    txtchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();
                    if (dt.Rows[0]["ChallanDate"].ToString() != "")
                        txtpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");
                    else
                        txtpodate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

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
                    if (Convert.ToBoolean(dt.Rows[0]["IsReceived"]) && Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]))
                    {
                        dvSendMail.Attributes.Add("style", "display:'';font-weight:bold;width:400px;");
                    }

                    txtthanvalue.Text = dt.Rows[0]["ThanCount"].ToString();
                    //ddlthanunitsvalue.SelectedValue = PoUnit.ToString();
                    txtponumber.Text = dt.Rows[0]["PO_Number"].ToString();
                    // rajeevs 10022023    DEBITCHALLAN        
                    string HSNCode = dt1.Rows[0]["HSNCode"].ToString();
                    if (((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString())) && ((HSNCode == null) || (HSNCode == ""))))
                    {
                        spn_HSNCode.InnerHtml = "";
                        lblHSNCode.Visible = false;
                    }
                    else
                    {
                        if ((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString())))
                            lblHSNCode.BorderStyle = BorderStyle.None;
                        lblHSNCode.BackColor = Color.Transparent;
                        lblHSNCode.Visible = true;
                        lblHSNCode.Text = HSNCode;
                        spn_HSNCode.InnerHtml = "HSNCode";
                    }
                    // rajeevs 10022023	
                    hdnPO_Number.Value = dt.Rows[0]["PO_Number"].ToString();                //new line
                    hdnChallan_Number.Value = dt.Rows[0]["ChallanNumber"].ToString();       //new line

                    ddlext.SelectedValue = "1";
                    txtstylenumber.Text = dt.Rows[0]["StyleNumber"].ToString();
                    txtserialnumber.Text = dt.Rows[0]["BuyerSrNumber"].ToString();
                    txtcolorprint.Text = dt.Rows[0]["TradeName"].ToString() + "/" + dt.Rows[0]["ColorPrint"].ToString();
                    lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";
                    hdnFabricQuality.Value = dt.Rows[0]["TradeName"].ToString(); //new line 23-04-2021
                    txtdiscription.Text = dt.Rows[0]["ChallanDescription"].ToString();
                    FabricDetails = dt.Rows[0]["ColorPrint"].ToString();

                    DataTable dtchk = null;
                    if (IsNewChallan.ToLower() != "NEWCHALLAN".ToLower())
                    {
                        dtchk = fabobj.deletechallan("SELECTEDPROCESS", ChallanID).Tables[0];
                    }

                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                            HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");

                            if (IsNewChallan.ToLower() == "NEWCHALLAN".ToLower())
                            {
                                if (FabType.ToLower() == "Dyed".ToLower())
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == "2")
                                        chkprocess.Checked = true;
                                }

                                else if (FabType.ToLower() == "Printed".ToLower())
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == "3")
                                        chkprocess.Checked = true;
                                }

                                else if (FabType.ToLower() == "Embellishment".ToLower())
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == "30")
                                        chkprocess.Checked = true;
                                }

                                else if (FabType.ToLower() == "Embroidery".ToLower())
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == "31")
                                        chkprocess.Checked = true;
                                }

                                else if (FabType.ToLower() == "RFD".ToLower())
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == "29")
                                        chkprocess.Checked = true;
                                }
                            }
                            else
                            {
                                if (dtchk.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtchk.Rows)
                                    {
                                        if (hdnChallan_Process_Admin_Id.Value == row["ProcessID"].ToString())
                                            chkprocess.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion DEBITCHALLAN

            #region SENDQTYCHALLAN
            else if (ChallanType.ToUpper() == "SENDQTYCHALLAN")
            {
                trToShowGSTNoForInternalChallan.Visible = false;
                txtSuppliername.Visible = true;
                txtGSTNo.Visible = true;
                txtSupplierAddress.Visible = true;

                ChallanPageHeading.InnerHtml = "Fabric Challan";
                sendqtyy.InnerHtml = "Send Qty. :";
                externalreturnchallanqtytitle.InnerHtml = "Returned Qty. :";

                hdnexternalchallanremainingqty.Value = SendQty;

                ds = fabobj.GetSupplierChallanDetails("CHALLAN", SupplierPoID, "EXTS", ChallanID, IsNewChallan, 0);
                dt = ds.Tables[0];
                dt1 = ds.Tables[1];

                lblsuppliername.Text = dt.Rows[0]["SupplierName"].ToString();
                if (lblsuppliername.Text.ToLower() != "Select".ToLower())
                {
                    ddlsuppliername.Attributes.Add("style", "display:none;");
                    lblsuppliername.Visible = true;
                }

                // rajeevs 10022023  Send Qty Challan         
                string HSNCode = dt1.Rows[0]["HSNCode"].ToString();
                if ((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString())) && ((HSNCode == null) || (HSNCode == "")))
                {
                    spn_HSNCode.InnerHtml = "";
                    lblHSNCode.Visible = false;
                }
                else
                {
                    if ((Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()) || Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString())))
                        lblHSNCode.BorderStyle = BorderStyle.None;
                    lblHSNCode.BackColor = Color.Transparent;
                    lblHSNCode.Visible = true;
                    lblHSNCode.Text = HSNCode;
                    spn_HSNCode.InnerHtml = "HSNCode";
                }
                // rajeevs 10022023	

                if (dt.Rows[0]["IsAuthorized"].ToString() == "True" || dt.Rows[0]["IsReceived"].ToString() == "True")
                {
                    txtsendqtyforinfo.Enabled = false;
                }

                if (dt.Rows[0]["IsAuthorized"].ToString() == "True" && dt.Rows[0]["IsReceived"].ToString() == "True")
                {
                    externalreturnchallanqtytitle.Visible = true;
                    externalreturnchallanqty.Visible = true;
                    lblconverttounit2.Visible = true;
                    lblconverttounit2.Text = dt.Rows[0]["unit"].ToString();
                }

                if (ds.Tables[1] != null)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dt1 = ds.Tables[1];

                        if (IsNewChallan == "NEWCHALLAN")
                        {
                            lblTotalAmount.Text = Math.Round(((Convert.ToDecimal(dt1.Rows[0]["Rate"]) * Convert.ToDecimal(SendQty) * (100 + Convert.ToInt32(dt1.Rows[0]["GST"]))) / 100),0).ToString();
                            hdnisnewchallan.Value = "NEWCHALLAN";
                            lblgstno.Text = dt1.Rows[0]["GSTNo"].ToString();
                            hdnforlblgstno.Value = dt1.Rows[0]["GSTNo"].ToString();

                            lbladdress.Text = dt1.Rows[0]["address"].ToString();
                            hdnForlbladdress.Value = dt1.Rows[0]["address"].ToString();
                        }
                        else
                        {
                            lblTotalAmount.Text = dt1.Rows[0]["TotalAmount"].ToString();
                            hdnreturnedchallanqty.Value = dt1.Rows[0]["ReturnedChallanQty"].ToString();
                            hdnactualchallanqty.Value = dt1.Rows[0]["ActualChallanQty"].ToString();

                            lblgstno.Text = dt1.Rows[0]["GSTNo"].ToString();
                            hdnforlblgstno.Value = dt1.Rows[0]["GSTNo"].ToString();

                            lbladdress.Text = dt1.Rows[0]["address"].ToString();
                            hdnForlbladdress.Value = dt1.Rows[0]["address"].ToString();
                        }
                        hdnSendQty.Value = SendQty;
                        lblrate.Text = dt1.Rows[0]["Rate"].ToString();
                        hdnGst.Value = dt1.Rows[0]["GST"].ToString();
                        string gst = dt1.Rows[0]["GSTNo"].ToString() == "" ? "" : dt1.Rows[0]["GSTNo"].ToString().Substring(0, 2);
                        if (gst == "09")
                        {
                            licgst.Visible = true;
                            lisgst.Visible = true;
                            lblcgst.Text = Convert.ToString((Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2));
                            lblsgst.Text = Convert.ToString((Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2));
                            if (!string.IsNullOrEmpty(lblTotalAmount.Text))
                            {
                                lblCGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2)), 0)) + ")";
                                lblSGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(dt1.Rows[0]["GST"]) / 2)), 0)) + ")";
                                if (lblSGSTValue.Text == "(₹" + "0" + ")")
                                    lblSGSTValue.Text = "";
                                if (lblCGSTValue.Text == "(₹" + "0" + ")")
                                    lblCGSTValue.Text = "";
                            }
                                 igst.Visible = false;
                        }
                        else
                        {
                            igst.Visible = true;
                            lblCGSTValue.Visible = false;
                            lblSGSTValue.Visible = false;
                            lbligst.Text = dt1.Rows[0]["GST"].ToString();
                            if (!string.IsNullOrEmpty(lblTotalAmount.Text))
                            {
                                lblIGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(dt1.Rows[0]["GST"]))), 0)) + ")";
                                if (lblIGSTValue.Text == "(₹" + "0" + ")")
                                    lblIGSTValue.Text = "";
                            }
                                 licgst.Visible = false;
                            lisgst.Visible = false;
                        }
                    }
                }
                hdndefaultunit.Value = dt.Rows[0]["GarmentUnit"].ToString();
                hdnconverttounit.Value = dt.Rows[0]["ConvertToUnit"].ToString();
                lblconverttounit.Visible = true;
                lblconverttounit.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value));
                lbldefualtunit.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefaultunit.Value));
                lbldefualtinitinfo.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefaultunit.Value));
                ConversionValue = Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString());
                SendQty = Math.Floor(Convert.ToDecimal(SendQty) * Convert.ToDecimal(ConversionValue)).ToString();
                hdnoldqty.Value = SendQty.ToString();
                hdnconversionvalue.Value = dt.Rows[0]["ConversionValue"].ToString();

                if (hdndefaultunit.Value != hdnconverttounit.Value)
                {
                    lbldefualtunit.Visible = true;
                    lbldefualtinitinfo.Visible = true;
                    lbldefualtremaningqty.Visible = true;
                    lbldefualtunitstaticinfo.Visible = true;
                    lbldefualtinitinfo.Visible = true;
                    lbldefualtunitstaticinfo.Text = (Math.Round((Convert.ToDecimal(SendQty) / Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString())), 0)).ToString("N0");
                }

                ddlext.SelectedValue = "1";
                tblisdayed.Visible = false;
                divsend.Visible = true;

                if (dt.Rows.Count > 0)
                {
                    int sendqty = 0;
                    DataTable stxc = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderDetailsID), Convert.ToInt32(FabricQualityID), FabricQualityID, OrderDetailsID, "", dt.Rows[0]["ColorPrint"].ToString()).Tables[1];
                    if (stxc.Rows.Count > 0)
                    {
                        hdnmaxavailbleqty.Value = stxc.Rows[0]["LastestStageVal"].ToString();
                    }
                    hdnmaxcount.Value = dt.Rows[0]["TotalMetersval"].ToString();
                    Int32.TryParse(txtsendqtyforinfo.Text.Replace(",", ""), out sendqty);
                    //Code Updated by RSB on dated 6 may 2021
                    if (decimal.TryParse(dt.Rows[0]["TotalSendQty"].ToString(), out TotalSendQty))
                    {
                        if (IsNewChallan == "")
                        {
                            Totalremaining = Convert.ToDecimal(SendQty.ToString());
                            lbldefualtunitstaticinfo.Text = (Math.Round((Convert.ToDecimal(Totalremaining) / Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString())), 0)).ToString("N0");
                        }
                        else
                        {
                            if ((TotalSendQty - Convert.ToDecimal(SendQty.ToString())) >= 0)
                            {
                                Totalremaining = Convert.ToDecimal(SendQty.ToString());
                                lbldefualtunitstaticinfo.Text = (Math.Round((Convert.ToDecimal(Totalremaining) / Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString())), 0)).ToString("N0");
                            }
                            else
                            {
                                if (IsClose == "1")
                                    Totalremaining = 0;

                                else
                                {
                                    Totalremaining = Convert.ToDecimal(SendQty.ToString());//we already handling total send qty. in respective function [dbo].[Fn_GetStockQty]
                                    lbldefualtunitstaticinfo.Text = (Math.Round((Convert.ToDecimal(Totalremaining) / Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString())), 0)).ToString("N0");

                                }
                            }
                        }
                    }
                    //End Of Code Updated by RSB on dated 6 may 2021

                    string RemainingUnit = "<span style='color:gray; font-weight:600'>" + lblconverttounit.Text + "</span>";
                    if (ChallanID <= 0)
                    {

                        txtsendqtyforinfo.Text = Totalremaining.ToString("N0");
                        lblsendreaming.Text = "Remaining quantity: " + Totalremaining.ToString("N0") + " " + RemainingUnit;
                        hdnexternalchallanremainingqty.Value = Totalremaining.ToString();

                        hdnremainingqty.Value = Totalremaining.ToString();
                        hdnsentRemainingQty.Value = Totalremaining.ToString();

                        hdnsentRemainingUnit.Value = lblconverttounit.Text;
                        Int32.TryParse(txtsendqtyforinfo.Text.Replace(",", ""), out sendqty);
                        Totalremaining = Convert.ToInt32(Totalremaining);

                        Totalremaining = Convert.ToInt32(Totalremaining) + Convert.ToInt32(sendqty);

                        if (lblsendreaming.Text == "Remaining quantity: 0 " + RemainingUnit)
                        {
                            lblsendreaming.Text = "";
                            lbldefualtunit.Visible = false;
                            lbldefualtinitinfo.Visible = false;
                            hdnremainingqty.Value = "0";
                        }
                        if (Convert.ToInt32(Totalremaining) <= 0 && Convert.ToInt32(sendqty) <= 0)
                        {
                            lbldefualtremaningqty.Text = "";
                            lblsendreaming.Text = "";
                            hdnremainingqty.Value = "0";
                            lbldefualtunit.Text = "";
                            lbldefualtinitinfo.Text = "";

                            lbldefualtunitstaticinfo.Visible = false;
                            lbldefualtunit.Visible = false;
                            lbldefualtremaningqty.Visible = false;
                        }
                        hdnsendtotalrening.Value = (Convert.ToInt32(Totalremaining) - Convert.ToInt32(sendqty)).ToString();
                    }
                    else
                    {

                        txtsendqtyforinfo.Text = Convert.ToDecimal(dt.Rows[0]["ChallanSendQty"]).ToString("N0");
                        hdnsavedsendqty.Value = dt.Rows[0]["ChallanSendQty"].ToString();
                        Challaqty = Convert.ToDecimal(dt.Rows[0]["ChallanSendQty"].ToString());
                        Int32.TryParse(txtsendqtyforinfo.Text.Replace(",", ""), out sendqty);
                        //txtsendqtyforinfo.Attributes.Add("onchange", "ValidateSendRemaningQty(" + (Totalremaining + sendqty) + "," + sendqty + "," + "'" + dt.Rows[0]["units"].ToString() + "'" + ");");
                        //lblsendreaming.Text = "Remaining quantity :" + (Totalremaining + sendqty) + " " + dt.Rows[0]["units"].ToString(); 
                        //if (dt.Rows[0]["IsAuthorized"].ToString() == "True" || dt.Rows[0]["IsReceived"].ToString() == "True")
                        //{
                        lblsendreaming.Text = "Remaining quantity: " + (Totalremaining).ToString() + " " + RemainingUnit;

                        hdnexternalchallanremainingqty.Value = (Totalremaining + Convert.ToDecimal(dt.Rows[0]["ChallanSendQty"])).ToString();
                        //}
                        //else
                        //{
                        //    lblsendreaming.Text = "Remaining quantity: " + (Totalremaining - Convert.ToInt32(dt.Rows[0]["ChallanSendQty"])).ToString() + " " + RemainingUnit;
                        //}


                        hdnremainingqty.Value = Totalremaining.ToString();
                        hdnsendtotalrening.Value = (Convert.ToInt32(Totalremaining) - Convert.ToInt32(sendqty)).ToString();
                        //Totalremaining = Convert.ToInt32(Totalremaining) + Convert.ToInt32(sendqty);

                        hdnsentRemainingQty.Value = Totalremaining.ToString();  //new line

                        hdnsentRemainingUnit.Value = lblconverttounit.Text;     //new line

                        //if (Convert.ToInt32(Totalremaining) == Convert.ToInt32(sendqty))
                        //{
                        //    lblsendreaming.Text = "";
                        //    hdnremainingqty.Value = "";
                        //    lbldefualtremaningqty.Text = "";


                        //    lbldefualtinitinfo.Text = "";
                        //    lbldefualtunitstaticinfo.Text = "";
                        //    lbldefualtinitinfo.Text = "";

                        //}
                    }
                    if (Totalremaining <= 0)
                    {
                        lbldefualtremaningqty.Text = "";

                        lbldefualtunitstaticinfo.Text = "";
                        lbldefualtinitinfo.Visible = false;
                        //  txtsendqtyforinfo.Enabled = false;
                        lblsendreaming.Text = "";
                        hdnremainingqty.Value = "";
                    }
                    decimal txtsendqty = (txtsendqtyforinfo.Text == "" ? 0 : Convert.ToDecimal(txtsendqtyforinfo.Text));
                    //if (Convert.ToDecimal(Totalremaining) == Convert.ToDecimal(sendqty))
                    //{
                    //    lblsendreaming.Text = "";
                    //    hdnremainingqty.Value = "";
                    //    lbldefualtunitstaticinfo.Text = "";
                    //    lbldefualtinitinfo.Text = "";
                    //}
                    if (ChallanID <= 0)
                    {
                        if (Convert.ToDecimal(hdnsendtotalrening.Value) == txtsendqty)
                        {
                            lblsendreaming.Text = "";
                            hdnremainingqty.Value = "";
                            lbldefualtunitstaticinfo.Text = "";
                            lbldefualtinitinfo.Text = "";
                        }
                    }
                    if (hdndefaultunit.Value != hdnconverttounit.Value)
                    {
                        lbldefualtremaningqty.Text = (Math.Round(txtsendqty / Convert.ToDecimal(dt.Rows[0]["ConversionValue"].ToString()), 0)).ToString("N0");

                    }
                    else
                    {
                        // lblsendreaming.Text = "Remaining quantity: " + (Convert.ToDecimal(hdnoldqty.Value) - txtsendqty).ToString("N0") + " " + RemainingUnit;        
                    }
                    ddlsuppliername.SelectedValue = dt.Rows[0]["SupplierID"].ToString();

                    txtchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();
                    if (dt.Rows[0]["ChallanDate"].ToString() != "")
                        txtpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");
                    else
                        txtpodate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");

                    if (dt.Rows[0]["IsAuthorized"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()))
                        {
                            //chkAuthorised.Checked = true;
                            //chkAuthorised.Enabled = false;
                            divChkAuthorized.Style.Add("display", "none");
                            divSigAuthorized.Visible = true;
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
                            //chkrecivegood.Checked = true;
                            //chkrecivegood.Enabled = false;
                            divChkReceive.Visible = false;
                            divSigReceive.Visible = true;
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
                    if (Convert.ToBoolean(dt.Rows[0]["IsReceived"]) && Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]))
                    {
                        //dvSendMail.Attributes.Add("style", "display:''");
                        dvSendMail.Attributes.Add("style", "display:'';font-weight:bold;width:400px;");
                    }

                    txtponumber.Text = dt.Rows[0]["PO_Number"].ToString();

                    hdnPO_Number.Value = dt.Rows[0]["PO_Number"].ToString();            //new line
                    hdnChallan_Number.Value = dt.Rows[0]["ChallanNumber"].ToString();   //new line
                    ddlext.SelectedValue = "1";
                    txtcolorprint.Text = dt.Rows[0]["TradeName"].ToString() + "/" + dt.Rows[0]["ColorPrint"].ToString();
                    lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";
                    hdnFabricQuality.Value = dt.Rows[0]["TradeName"].ToString(); //new line 23-04-2021
                    txtThan.Text = dt.Rows[0]["ThanCount"].ToString();
                    txtdiscription.Text = dt.Rows[0]["ChallanDescription"].ToString();
                    FabricDetails = dt.Rows[0]["ColorPrint"].ToString();

                    //new work start(2023-03-01) Girish
                    string SamplingSupplierName = dt1.Rows[0]["SamplingSupplierName"].ToString();
                    string SamplingGSTNo = dt1.Rows[0]["SamplingGSTNo"].ToString();
                    string SamplingSupplierAddress = dt1.Rows[0]["SamplingSupplierAddress"].ToString();


                    if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]) || Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                    {
                        if (SamplingSupplierName != "")
                        {
                            lblsuppliername.Text = SamplingSupplierName;
                            lblgstno.Text = SamplingGSTNo;
                            lbladdress.Text = SamplingSupplierAddress;

                            txtSuppliername.Visible = false;
                            txtGSTNo.Visible = false;
                            txtSupplierAddress.Visible = false;
                        }

                        foreach (RepeaterItem item in Repeater1.Items)
                        {
                            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                            {
                                HtmlInputCheckBox challanProcess = (HtmlInputCheckBox)item.FindControl("challanProcess");
                                challanProcess.Attributes.Add("disabled", "disabled");
                            }
                        }
                    }
                    else
                    {
                        if (SamplingSupplierName != "")
                        {
                            txtSuppliername.Text = SamplingSupplierName;
                            txtSuppliername.Enabled = true;
                            txtSuppliername.Attributes.Add("style", "border:1px solid black");
                            lblsuppliername.Attributes.Add("style", "display:none");

                            txtGSTNo.Text = SamplingGSTNo;
                            txtGSTNo.Enabled = true;
                            txtGSTNo.Attributes.Add("style", "border:1px solid black");
                            lblgstno.Attributes.Add("style", "display:none");

                            txtSupplierAddress.Text = SamplingSupplierAddress;
                            txtSupplierAddress.Enabled = true;
                            txtSupplierAddress.Attributes.Add("style", "border:1px solid black");
                            lbladdress.Attributes.Add("style", "display:none");

                        }
                    }
                    //new work End(2023-03-01) Girish
                }




                DataTable dtchk = null;
                if (IsNewChallan.ToLower() != "NEWCHALLAN".ToLower())
                {
                    dtchk = fabobj.deletechallan("SELECTEDPROCESS", ChallanID).Tables[0];
                }

                foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                        HtmlInputCheckBox challanProcess = (HtmlInputCheckBox)item.FindControl("challanProcess");

                        HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");

                        chkprocess.Visible = false;
                        challanProcess.Visible = true;

                        if (IsNewChallan.ToLower() == "NEWCHALLAN".ToLower())
                        {
                            if (FabType.ToLower() == "Dyed".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "2")
                                {
                                    challanProcess.Checked = true;
                                }

                            }

                            else if (FabType.ToLower() == "Printed".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "3")
                                {
                                    challanProcess.Checked = true;
                                }
                            }

                            else if (FabType.ToLower() == "Embellishment".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "30")
                                {
                                    challanProcess.Checked = true;
                                }
                            }

                            else if (FabType.ToLower() == "Embroidery".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "31")
                                {
                                    challanProcess.Checked = true;
                                }
                            }

                            else if (FabType.ToLower() == "RFD".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "29")
                                {
                                    challanProcess.Checked = true;
                                }
                            }
                        }
                        else
                        {
                            if (dtchk.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtchk.Rows)
                                {
                                    if (hdnChallan_Process_Admin_Id.Value == row["ProcessID"].ToString())
                                    {
                                        challanProcess.Checked = true;

                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion SENDQTYCHALLAN

            #region INTERNAL
            else if (ChallanType.ToUpper() == "INTERNAL")
            {
                tdCompanyType.Attributes.Add("style","display:none");
                externalChallantr.Visible = false;
                externalchallantr2.Visible = false;
                ChallanPageHeading.InnerHtml = "Fabric Challan";
                intstylenumber.Visible = true;
                intserialnumber.Visible = true;

                divsend.Visible = false;
                fabric_challan_rategst.Visible = false;
                lblTotalAmount.Visible = false;
                lblrate.Visible = false;
                lblsgst.Visible = false;
                lblcgst.Visible = false;
                lbligst.Visible = false;
                lblavailableqtydebitchallan.Visible = true;
                lblavailbledebittext.Visible = true;
                lblavailbledebittext.Text = "Available Qty: ";
                dt = fabobj.GetSupplierChallanDetails("PRODUCTIONUNIT").Tables[0];
                ddlsuppliername.DataSource = dt;
                ddlsuppliername.DataTextField = "Name";
                ddlsuppliername.DataValueField = "Id";
                ddlsuppliername.DataBind();
                ddlsuppliername.Enabled = true;

                ddlext.SelectedValue = "0";

                tblisdayed.Visible = true;

                if (ChallanID <= 0)
                {
                    IsNewChallan = "NEWCHALLAN";
                    hdnisnewchallan.Value = "NEWCHALLAN";
                }
                dt = fabobj.GetInternalChallanDetails("CHALLANINTERNAL", SupplierPoID, "INT", ChallanID, IsNewChallan, OrderDetailsID, FabricQualityID, FabricDetails).Tables[0];

                if (dt.Rows.Count > 0)
                {

                    ddlsuppliername.SelectedValue = dt.Rows[0]["InternalUnit"].ToString();
                    hdnSelectedSupplier.Value = dt.Rows[0]["InternalUnit"].ToString();
                    //lblsuppliername.Text = ddlsuppliername.SelectedItem.Text;
                    //if (lblsuppliername.Text.ToLower() != "Select".ToLower())
                    //{
                    //    ddlsuppliername.Attributes.Add("style", "display:none;");
                    //    lblsuppliername.Visible = true;
                    //}

                    //new work start(Showing GST No in Internal Challan): Girish

                    hdnInternalUnitIds.Value = dt.Rows[0]["InternalUnitIds"].ToString();

                    if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]) && Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                    {
                        if (dt.Rows[0]["GSTNo"].ToString() == "")
                        {
                            trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:none;");
                        }
                        else
                        {
                            trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:contents;");
                            txtGSTNoForInternalChallan.Text = dt.Rows[0]["GSTNo"].ToString();
                            hdnGSTNoForInternalChallan.Value = dt.Rows[0]["GSTNo"].ToString();
                            txtGSTNoForInternalChallan.Enabled = false;
                            txtGSTNoForInternalChallan.Attributes.Add("style", "width: 50%;border:none;background-color:white;");
                        }

                    }
                    else
                    {
                        if (!dt.AsEnumerable().Any(row => row.Field<string>("InternalUnitIds").Split(',').Any(val => val.Trim() == ddlsuppliername.SelectedValue)))
                        {
                            trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:contents;");
                            txtGSTNoForInternalChallan.Text = dt.Rows[0]["GSTNo"].ToString();
                            hdnGSTNoForInternalChallan.Value = dt.Rows[0]["GSTNo"].ToString();
                        }
                    }
                    //new work End : Girish


                    hdnconverttounit.Value = dt.Rows[0]["ConvertToUnit"].ToString();
                    hdnconversionvalue.Value = dt.Rows[0]["ConversionValue"].ToString();

                    lblinternalconverttounit.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(dt.Rows[0]["ConvertToUnit"].ToString()));
                    lblinternalconverttounit.Visible = true;

                    lblavailabelqtyunitname.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(dt.Rows[0]["ConvertToUnit"].ToString()));
                    lblavailabelqtyunitname.Visible = true;

                    DataTable stxc = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderDetailsID), Convert.ToInt32(FabricQualityID), FabricQualityID, OrderDetailsID, "", FabricDetails).Tables[1];
                    if (stxc.Rows.Count > 0)
                    {
                        decimal dStageVal = 0, existsqty = 0, finalavaliableqty = 0;
                        if (stxc.Rows[0]["LastestStageVal"].ToString() != "")
                        {
                            dStageVal = Convert.ToDecimal(stxc.Rows[0]["LastestStageVal"].ToString());
                        }
                        if (dt.Rows[0]["TotalMetersval"].ToString() != "")
                        {
                            //existsqty = Convert.ToDecimal(dt.Rows[0]["TotalMetersval"].ToString());
                            existsqty = Convert.ToDecimal(dt.Rows[0]["TotalMetersvaldebit"].ToString() == "" ? 0 : dt.Rows[0]["TotalMetersvaldebit"]);
                            SavedChallanQty = Convert.ToInt32(dt.Rows[0]["TotalMetersvaldebit"].ToString() == "" ? 0 : dt.Rows[0]["TotalMetersvaldebit"]);
                            hdnSavedChallanQty.Value = SavedChallanQty.ToString();
                        }
                        finalavaliableqty = (dStageVal - existsqty);
                        hdnmaxavailbleqty.Value = finalavaliableqty.ToString();

                        if (Convert.ToBoolean(dt.Rows[0]["IsReceived"].ToString()) && Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()))
                            lblavailableqtydebitchallan.Text = finalavaliableqty.ToString("N0");

                        else
                            lblavailableqtydebitchallan.Text = (Convert.ToInt32(finalavaliableqty) - (dt.Rows[0]["TotalMeters"].ToString() == string.Empty ? 0 : Convert.ToInt32(dt.Rows[0]["TotalMeters"]))).ToString();

                        hdnInternalRemainingQty.Value = finalavaliableqty.ToString();

                        hdndebitavailebaleqty.Value = Math.Abs(finalavaliableqty).ToString();

                        hdn_AvailableDebitChallanQty.Value = lblavailableqtydebitchallan.Text.Replace(",", "");

                    }

                    int nNumber = int.TryParse(dt.Rows[0]["TotalMeters"].ToString().Replace(",", ""), out nNumber) ? nNumber : 0;
                    txtqtytotal.Text = decimal.Parse(nNumber.ToString()).ToString("#,#.##");
                    hdntotalmeter.Value = dt.Rows[0]["TotalMeters"].ToString();
                    hdnmaxcount.Value = dt.Rows[0]["TotalMetersval"].ToString();

                    txtchallanno.Text = dt.Rows[0]["ChallanNumber"].ToString();
                    if (dt.Rows[0]["ChallanDate"].ToString() != "")
                        txtpodate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"].ToString()).ToString("dd MMM yy (ddd)");
                    else
                        txtpodate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");


                    if (dt.Rows[0]["IsAuthorized"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"].ToString()))
                        {
                            chkAuthorised.Checked = true;
                            divChkAuthorized.Style.Add("display", "none");
                            divSigAuthorized.Visible = true;
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
                            chkrecivegood.Checked = true;
                            //chkrecivegood.Enabled = false;
                            divChkReceive.Style.Add("display", "none");
                            divSigReceive.Visible = true;
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

                    txtthanvalue.Text = dt.Rows[0]["ThanCount"].ToString();
                    //ddlthanunitsvalue.SelectedValue = dt.Rows[0]["ConvertToUnit"].ToString();
                    //txtponumber.Text = dt.Rows[0]["PO_Number"].ToString();

                    txtstylenumber.Text = dt.Rows[0]["StyleNumber"].ToString();
                    txtserialnumber.Text = dt.Rows[0]["BuyerSrNumber"].ToString();
                    txtcolorprint.Text = dt.Rows[0]["TradeName"].ToString() + "/" + dt.Rows[0]["ColorPrint"].ToString();
                    lblcolorprintdetails.InnerHtml = "<span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span>" + " " + "<span style='color:black;font-weight:600;'>" + dt.Rows[0]["ColorPrint"].ToString() + "</span>";
                    hdnFabricQuality.Value = dt.Rows[0]["TradeName"].ToString(); //new line 23-04-2021
                    txtdiscription.Text = dt.Rows[0]["ChallanDescription"].ToString();

                    DataTable dtchk = null;
                    if (IsNewChallan.ToLower() != "NEWCHALLAN".ToLower())
                    {
                        dtchk = fabobj.deletechallan("SELECTEDPROCESS", ChallanID).Tables[0];
                    }

                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");

                            HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");

                            if (IsNewChallan.ToLower() == "NEWCHALLAN".ToLower())
                            {
                                if (hdnChallan_Process_Admin_Id.Value == "8")
                                    chkprocess.Checked = true;
                            }
                            else
                            {
                                if (dtchk.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtchk.Rows)
                                    {
                                        if (hdnChallan_Process_Admin_Id.Value == row["ProcessID"].ToString())
                                            chkprocess.Checked = true;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            #endregion INTERNAL

            if (txtsendqtyforinfo.Text == "0")
            {
                txtsendqtyforinfo.Text = "";
            }
        }

        public void bindsplitsgrd()
        {
            DataTable dtadd = new DataTable();
            dtadd = fabobj.GetSupplierChallanDetails("CHALLANBREAKDOWN", 0, "", ChallanID).Tables[0];
            int x = 1;
            if (dtadd.Rows.Count > 0)
            {
                foreach (var dt1 in SplitTable(dtadd, 16))
                {
                    DataTable dt = dt1;
                    if (x == 1)
                    {
                        //grdmaster.DataSource = dt;
                        //grdmaster.DataBind();
                        Session["myTable"] = dt;
                    }
                    else
                    {
                        //GridView1.DataSource = dt;
                        //GridView1.DataBind();
                        Session["myTable2"] = dt;
                    }
                    x += 1;
                }
                SetSeq();
            }

        }

        protected void btnDebitNoteSave(object sender, EventArgs e)
        {
            if (ChallanType.ToUpper() == "DEBITCHALLAN".ToUpper())
                SaveChallanDetails();
            else if (ChallanType.ToUpper() == "SENDQTYCHALLAN".ToUpper())
                SaveChallanSendQtyDetails();
            else if (ChallanType.ToUpper() == "INTERNAL".ToUpper())
                SaveChallanInternalDetails();
            else if (ChallanType.ToUpper() == "FOC_CHALLAN".ToUpper())
                SaveFocChallanDetails();
            else if (ChallanType.ToUpper() == "ExtraStockIssue".ToUpper())
                SaveExtraStockIssue();
        }

        public void SaveChallanDetails()
        {
            Decimal Rate = 0;
            string ChallanNumber = "";
            DateTime ChallanDate = DateTime.MinValue;
            int ChallanTypeOption;
            string StyleNumber = "";
            string BuyerSrNumber = "";
            int UnitID = -1;
            string ChallanDescription = "";
            int ThanCount = default(int);
            int ThanUnit = -1;
            Decimal TotalMeters = default(Decimal); ;
            int IsReceived;
            DateTime ReceivedDate = DateTime.MinValue;
            int IsAuthorized = 0;
            DateTime AuthorizedDate = DateTime.MinValue;
            //LoggedInUserID 
            int ChallanInternal = Convert.ToInt32(ddlext.SelectedValue);
            ChallanNumber = txtchallanno.Text;
            ChallanDate = txtpodate.Text != "" ? DateTime.ParseExact(txtpodate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            ChallanTypeOption = (Convert.ToInt32(ddlext.SelectedValue));
            if (ChallanType.ToUpper() != "DEBITCHALLAN")
            {
                StyleNumber = txtstylenumber.Text.Trim();
                BuyerSrNumber = txtserialnumber.Text.Trim();
            }
            UnitID = (Convert.ToInt32(ddlext.SelectedValue));
            ChallanDescription = txtdiscription.Text.Trim();
            if (txtthanvalue.Text != "")
            {
                ThanCount = Convert.ToInt32(txtthanvalue.Text);
            }
            //ThanUnit = Convert.ToInt32(ddlthanunitsvalue.Text);
            if (txtqtytotal.Text != "")
            {
                TotalMeters = Convert.ToDecimal(txtqtytotal.Text.Replace(",", ""));
            }
            IsReceived = (chkrecivegood.Checked == true ? 1 : 0);
            if (IsReceived == 1)
            {
                ReceivedDate = DateTime.Now;
            }
            IsAuthorized = (chkAuthorised.Checked == true ? 1 : 0);
            if (IsAuthorized == 1)
            {
                AuthorizedDate = DateTime.Now;
            }

            if (hdnchkAuthorized.Value == "0" || hdnchkReceiver.Value == "0")
            {
                string HSNCode = lblHSNCode.Text; ;
                DataTable dt = fabobj.UpdateSupplierChallanDetails("UPDATECHALLANDETAILS", SupplierPoID, ChallanNumber, ChallanDate, StyleNumber, BuyerSrNumber, UnitID, ChallanDescription, ThanCount, ThanUnit, TotalMeters, IsReceived, ReceivedDate, IsAuthorized, AuthorizedDate, ReturnedChallanQty, LoggedInUserID, ChallanID, UnitID, 0, 0, DebitNote_Id, 0, 0, FabricDetails, Convert.ToDecimal(hdnGst.Value), Rate, HSNCode, "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ChallanID = Convert.ToInt32(dt.Rows[0]["ChallanId"].ToString());
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                            HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");
                            if (chkprocess.Checked)
                            {
                                DataTable dtchk = fabobj.deletechallan("UPDATEPROCESSCHALLAN", ChallanID, Convert.ToInt32(hdnChallan_Process_Admin_Id.Value)).Tables[0];
                            }
                        }
                    }
                    DataTable dtm = fabobj.deletechallan("DELETECHALLANMETER", ChallanID, -1).Tables[0];
                    int meter = 0;
                    int Cmeter = 0;
                    //foreach (GridViewRow gvr in grdmaster.Rows)
                    //{
                    //    Label lblserial = (Label)gvr.FindControl("lblserial");
                    //    HiddenField hdnmtr = (HiddenField)gvr.FindControl("hdnmtr");
                    //    HiddenField hdncentimtr = (HiddenField)gvr.FindControl("hdncentimtr");
                    //    if (hdnmtr.Value != "" && hdncentimtr.Value != "")
                    //    {
                    //        meter = Convert.ToInt32(hdnmtr.Value);
                    //        Cmeter = Convert.ToInt32(hdncentimtr.Value);
                    //        DataTable dtchk = fabobj.deletechallan("INSERTCHALLANMETER", ChallanID, 0, Convert.ToInt32(lblserial.Text), meter, Cmeter).Tables[0];
                    //    }

                    //}

                    //foreach (GridViewRow gvr in GridView1.Rows)
                    //{
                    //    Label lblserial = (Label)gvr.FindControl("lblserial");
                    //    HiddenField hdnmtr = (HiddenField)gvr.FindControl("hdnmtr");
                    //    HiddenField hdncentimtr = (HiddenField)gvr.FindControl("hdncentimtr");
                    //    if (hdnmtr.Value != "" && hdncentimtr.Value != "")
                    //    {
                    //        meter = Convert.ToInt32(hdnmtr.Value);
                    //        Cmeter = Convert.ToInt32(hdncentimtr.Value);
                    //        DataTable dtchk = fabobj.deletechallan("INSERTCHALLANMETER", ChallanID, 0, Convert.ToInt32(lblserial.Text), meter, Cmeter).Tables[0];

                    //    }
                    //}

                    //new code on 24-03-2021 start                
                    if (chkAuthorised.Checked && chkrecivegood.Checked && rbtnYes.Checked)
                    {

                        RenderHtml();

                        string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                        string url = host1 + "/Uploads/Print/" + thisPath;

                        string EmailContent = HttpContent(url);

                        SendDebitNoteEmail("test", "kumar", EmailContent, MailType1);
                    }

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);

                    //new code on 24-03-2021 end

                }
            }
            //new code on 24-03-2021 start
            if (hdnchkAuthorized.Value == "1" && hdnchkReceiver.Value == "1" && (rbtnYes.Checked))
            {
                RenderHtml();

                string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                string url = host1 + "/Uploads/Print/" + thisPath;

                string EmailContent = HttpContent(url);

                SendDebitNoteEmail("test", "kumar", EmailContent, MailType1);
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
            }
            //new code on 24-03-2021 end
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "Savemtervalue();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
        }

        public void SaveChallanSendQtyDetails()
        {
            string ChallanNumber = "";
            DateTime ChallanDate = DateTime.MinValue;
            int ChallanTypeOption;
            string StyleNumber = "";
            string BuyerSrNumber = "";
            int UnitID = -1;
            string ChallanDescription = "";
            int ThanCount;
            int ThanUnit;
            Decimal TotalMeters = 0;
            int IsReceived;
            DateTime ReceivedDate = DateTime.MinValue;
            int IsAuthorized = 0;
            DateTime AuthorizedDate = DateTime.MinValue;
            int IsSendChallan = 0;
            int SendChallanQty = 0;

            int ExternalReturnChallanQty = 0;
            Decimal Rate = 0;

            ExternalReturnChallanQty = Convert.ToInt32(Math.Round(Convert.ToDecimal(hdnreturnedchallanqty.Value) / Convert.ToDecimal(ConversionValue)));
            Rate = Convert.ToDecimal(hdnrate.Value);

            if (txtsendqtyforinfo.Text != "")
            {
                SendChallanQty = Convert.ToInt32(Math.Round(Convert.ToDecimal(txtsendqtyforinfo.Text == "" ? "0" : txtsendqtyforinfo.Text.Replace(",", "")) / Convert.ToDecimal(ConversionValue), 0).ToString());
            }
            ChallanNumber = txtchallanno.Text;
            ChallanDate = txtpodate.Text != "" ? DateTime.ParseExact(txtpodate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            ChallanTypeOption = (Convert.ToInt32(ddlext.SelectedValue));
            if (ChallanType.ToUpper() != "DEBITCHALLAN" && ChallanType.ToUpper() != "SENDQTYCHALLAN")
            {
                StyleNumber = txtstylenumber.Text.Trim();
                BuyerSrNumber = txtserialnumber.Text.Trim();
            }
            UnitID = (Convert.ToInt32(ddlext.SelectedValue));
            ChallanDescription = txtdiscription.Text.Trim();
            if (!string.IsNullOrEmpty(txtThan.Text))
            {
                ThanCount = Convert.ToInt32(txtThan.Text);
            }
            else
            {
                ThanCount = 0;
            }
            ThanUnit = -1;
            TotalMeters = 0;
            if (ChallanType.ToUpper() == "SENDQTYCHALLAN")
            {
                IsSendChallan = 1;
            }

            IsReceived = (chkrecivegood.Checked == true ? 1 : 0);
            if (IsReceived == 1)
            {
                ReceivedDate = DateTime.Now;
            }
            IsAuthorized = (chkAuthorised.Checked == true ? 1 : 0);
            if (IsAuthorized == 1)
            {
                AuthorizedDate = DateTime.Now;
            }

            //added by Girish 
            string SamplingSupplierName = txtSuppliername.Text;
            string SamplingGstNo = txtGSTNo.Text;
            string SamplingSupplierAddress = txtSupplierAddress.Text;
            //added by Girish 

            string HSNCode = lblHSNCode.Text;
            if (hdnchkAuthorized.Value == "0" || hdnchkReceiver.Value == "0")
            {
                DataTable dt = fabobj.UpdateSupplierChallanDetails("UPDATECHALLANDETAILS", SupplierPoID, ChallanNumber, ChallanDate, StyleNumber, BuyerSrNumber, UnitID, ChallanDescription, ThanCount, ThanUnit, TotalMeters, IsReceived, ReceivedDate, IsAuthorized, AuthorizedDate, ExternalReturnChallanQty, LoggedInUserID, ChallanID, UnitID, IsSendChallan, SendChallanQty, DebitNote_Id, 0, 0, FabricDetails, Convert.ToDecimal(hdnGst.Value), Rate, HSNCode, "").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    //new work Start (2023-03-01)
                    if (hdnchkAuthorized.Value == "0" && hdnchkReceiver.Value == "0")
                    {
                        ChallanID = Convert.ToInt32(dt.Rows[0]["ChallanId"].ToString());

                        foreach (RepeaterItem item in Repeater1.Items)
                        {
                            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                            {
                                //added by Girish 
                                HtmlInputCheckBox challanProcess = (HtmlInputCheckBox)item.FindControl("challanProcess");
                                HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");
                                if (challanProcess.Checked)
                                {
                                    if (Convert.ToInt32(hdnChallan_Process_Admin_Id.Value) != 1)
                                    {
                                        SamplingSupplierName = "";
                                        SamplingGstNo = "";
                                        SamplingSupplierAddress = "";
                                    }
                                    int rowsAffected = fabobj.updateChallanProcess("UPDATEPROCESSCHALLAN", ChallanID, Convert.ToInt32(hdnChallan_Process_Admin_Id.Value), SamplingSupplierName, SamplingGstNo, SamplingSupplierAddress);
                                    break;
                                }
                                //added by Girish 
                            }
                        }
                    }
                    //new work end
                }
            }
            //new code on 24-03-2021 start   

            if (hdnchkAuthorized.Value == "1" && hdnchkReceiver.Value == "1")
            {
                DataTable dt = fabobj.UpdateSupplierChallanDetails("UPDATECHALLANDETAILS", SupplierPoID, ChallanNumber, ChallanDate, StyleNumber, BuyerSrNumber, UnitID, ChallanDescription, ThanCount, ThanUnit, TotalMeters, IsReceived, ReceivedDate, IsAuthorized, AuthorizedDate, ExternalReturnChallanQty, LoggedInUserID, ChallanID, UnitID, IsSendChallan, SendChallanQty, DebitNote_Id, 0, 0, FabricDetails, Convert.ToDecimal(hdnGst.Value), Rate, HSNCode, "").Tables[0];
            }

            if (chkAuthorised.Checked && chkrecivegood.Checked && rbtnYes.Checked)
            {
                RenderHtml();

                string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                string url = host1 + "/Uploads/Print/" + thisPath;
                string EmailContent = HttpContent(url);
                SendDebitNoteEmail("test", "kumar", EmailContent, MailType1);
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
        }

        //new work Start :Girish

        public void SaveFocChallanDetails()
        {

            string ChallanNumber = txtchallanno.Text;

            DateTime ChallanDate = txtpodate.Text != "" ? DateTime.ParseExact(txtpodate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

            string ChallanDescription = txtdiscription.Text.Trim();

            int SendChallanQty = txtsendqtyforinfo.Text == "" ? 0 : Convert.ToInt32(txtsendqtyforinfo.Text.Replace(",", ""));

            Decimal FocExtraPercentt = Convert.ToDecimal(focextrapercentbox.Text == "" ? "0" : focextrapercentbox.Text);

            Decimal Rate = Convert.ToDecimal(lblrate.Text);

            int IsReceived = (chkrecivegood.Checked == true ? 1 : 0);

            int IsAuthorized = (chkAuthorised.Checked == true ? 1 : 0);

            DateTime ReceivedDate;
            if (IsReceived == 1)
                ReceivedDate = DateTime.Now;
            else ReceivedDate = DateTime.MinValue;

            DateTime AuthorizedDate;
            if (IsAuthorized == 1)
                AuthorizedDate = DateTime.Now;
            else AuthorizedDate = DateTime.MinValue;

            int ExternalReturnChallanQty = externalreturnchallanqty.Text == "" ? 0 : Convert.ToInt32(externalreturnchallanqty.Text);

            string FOCProcessId = "";

            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                    HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");
                    if (chkprocess.Checked)
                    {
                        FOCProcessId = FOCProcessId + hdnChallan_Process_Admin_Id.Value + ",";
                    }
                }
            }
            //rajeevS
            string HSNCode = lblHSNCode.Text;
            Boolean IsSuccessful = fabobj.Update_Foc_Challan("Update_Foc_Challan", IsNewChallan, ChallanNumber, SupplierPoID, ChallanDate, ChallanDescription, SendChallanQty, FocExtraPercentt, Rate
                                                      , IsReceived, IsAuthorized, ReceivedDate, AuthorizedDate, LoggedInUserID, FocId, ExternalReturnChallanQty, FOCProcessId, HSNCode);
            if (IsSuccessful == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Success_msg", "alert('Foc Challan Saved Successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error_msg", "alert('Some Error Occured, Please try again.');", true);
            }

            if (chkAuthorised.Checked && chkrecivegood.Checked && rbtnYes.Checked)
            {
                RenderHtml();

                string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                string url = host1 + "/Uploads/Print/" + thisPath;

                string EmailContent = HttpContent(url);
                SendDebitNoteEmail("test", "kumar", EmailContent, "Fabric FOC Challan ");
            }
        }

        //new work End :Girish

        //new work Start :Girish
        public void SaveExtraStockIssue()
        {
            string GSTNo = "";
            //added on 2023-03-15
            if (txtGSTNoForInternalChallan.Enabled)
            {
                GSTNo = txtGSTNoForInternalChallan.Text;
            }
            else
            {
                GSTNo = hdnGSTNoForInternalChallan.Value;
            }
            //added on 2023-03-15

            string ChallanNumber = txtchallanno.Text;

            DateTime ChallanDate = txtpodate.Text != "" ? DateTime.ParseExact(txtpodate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

            int UnitID = Convert.ToInt32(ddlsuppliername.SelectedValue);

            string ChallanDescription = txtdiscription.Text.Trim();

            int SendChallanQty = txtqtytotal.Text == "" ? 0 : Convert.ToInt32(txtqtytotal.Text.Replace(",", ""));

            int ThanCount = 0;
            if (txtthanvalue.Text != "")
            {
                ThanCount = Convert.ToInt32(txtthanvalue.Text);
            }

            int IsReceived = (chkrecivegood.Checked == true ? 1 : 0);

            int IsAuthorized = (chkAuthorised.Checked == true ? 1 : 0);

            DateTime ReceivedDate;
            if (IsReceived == 1)
                ReceivedDate = DateTime.Now;
            else ReceivedDate = DateTime.MinValue;

            DateTime AuthorizedDate;
            if (IsAuthorized == 1)
                AuthorizedDate = DateTime.Now;
            else AuthorizedDate = DateTime.MinValue;

            string StyleNumber = txtstylenumber.Text.Trim();
            string BuyerSrNumber = txtserialnumber.Text.Trim();

            int InternalReturnQty = internalreturnchallanqty.Text == "" ? 0 : Convert.ToInt32(internalreturnchallanqty.Text);

            string ProcessId = "";

            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                    HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");
                    if (chkprocess.Checked)
                    {
                        ProcessId = ProcessId + hdnChallan_Process_Admin_Id.Value + ",";
                    }
                }
            }

            Boolean IsSuccessful = fabobj.Update_ExtraStockIssue_Challan("Update_ExtraStockIssue_Challan", IsNewChallan, -1, ChallanNumber, ChallanDate, ChallanDescription, SendChallanQty
                                                      , IsReceived, IsAuthorized, ReceivedDate, AuthorizedDate, LoggedInUserID, StyleNumber, BuyerSrNumber, UnitID, ThanCount, ColorPrint, OrderDetailsID
                                                      , ChallanID, InternalReturnQty, FabricQualityID, ProcessId, GSTNo);
            if (IsSuccessful == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Success_msg", "alert('Foc Challan Saved Successfully.');", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "closePage();", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error_msg", "alert('Some Error Occured, Please try again.');", true);

            }

        }
        //new work End :Girish


        public void SaveChallanInternalDetails()
        {
            string GSTNo = "";

            //added on 2023-03-15
            if (txtGSTNoForInternalChallan.Enabled)
            {
                GSTNo = txtGSTNoForInternalChallan.Text;
            }
            else
            {
                GSTNo = hdnGSTNoForInternalChallan.Value;
            }
            //added on 2023-03-15

            //added on 17-04-2023 start rajeevS
           if (string.IsNullOrEmpty(internalreturnchallanqty.Text))
           {
               hdnreturnedchallanqty.Value="0";
           }
     
            //added on 17-04-2023 end


            string h1 = ((HiddenField)hdnchkReceiver).Value;
            string h2 = ((HiddenField)hdnchkAuthorized).Value;

            if (h1 != "1" && h2 != "1")
            {
                string result = ValidateRecieveQty();
                if (result != "")
                {
                    ShowAlert(result);
                    return;
                }
            }
            string ChallanNumber = "";
            DateTime ChallanDate = DateTime.MinValue;
            int ChallanTypeOption;
            string StyleNumber = "";
            string BuyerSrNumber = "";
            int UnitID = -1;
            string ChallanDescription = "";
            int ThanCount;
            int ThanUnit;
            Decimal TotalMeters = 0;
            int IsReceived;
            DateTime ReceivedDate = DateTime.MinValue;
            int IsAuthorized = 0;
            DateTime AuthorizedDate = DateTime.MinValue;
            int IsSendChallan = 0;
            int SendChallanQty = 0;

            Decimal Rate = 0;

            ThanCount = 0;
            ThanUnit = -1;
            TotalMeters = 0;
            //LoggedInUserID 

            ChallanNumber = txtchallanno.Text;
            ChallanDate = txtpodate.Text != "" ? DateTime.ParseExact(txtpodate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            ChallanTypeOption = (Convert.ToInt32(ddlext.SelectedValue));
            StyleNumber = txtstylenumber.Text.Trim();
            BuyerSrNumber = txtserialnumber.Text.Trim();

            UnitID = (Convert.ToInt32(ddlext.SelectedValue));
            ChallanDescription = txtdiscription.Text.Trim();
            if (txtthanvalue.Text != "")
            {
                ThanCount = Convert.ToInt32(txtthanvalue.Text);
            }
            //ThanUnit = Convert.ToInt32(ddlthanunitsvalue.Text);
            if (txtqtytotal.Text != "")
            {
                TotalMeters = Convert.ToDecimal(txtqtytotal.Text.Replace(",", ""));
            }
            IsReceived = (chkrecivegood.Checked == true ? 1 : 0);
            if (IsReceived == 1)
            {
                ReceivedDate = DateTime.Now;
            }

            IsAuthorized = (chkAuthorised.Checked == true ? 1 : 0);
            if (IsAuthorized == 1)
            {
                AuthorizedDate = DateTime.Now;
            }
            UnitID = Convert.ToInt32(ddlsuppliername.SelectedValue);

            //if (hdnchkAuthorized.Value == "0" && hdnchkReceiver.Value == "0")
            //{
            string HSNCode = lblHSNCode.Text; ;
            DataTable dt = fabobj.UpdateSupplierChallanDetails("UPDATECHALLANDETAILS", -1, ChallanNumber, ChallanDate, StyleNumber, BuyerSrNumber, UnitID, ChallanDescription, ThanCount, ThanUnit, TotalMeters, IsReceived, ReceivedDate, IsAuthorized, AuthorizedDate, ReturnedChallanQty, LoggedInUserID, ChallanID, UnitID, IsSendChallan, SendChallanQty, DebitNote_Id, OrderDetailsID, FabricQualityID, FabricDetails, Convert.ToDecimal(hdnGst.Value), Rate, HSNCode, GSTNo).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ChallanID = Convert.ToInt32(dt.Rows[0]["ChallanId"].ToString());
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkprocess = (CheckBox)item.FindControl("chkprocess");
                        HiddenField hdnChallan_Process_Admin_Id = (HiddenField)item.FindControl("hdnChallan_Process_Admin_Id");
                        if (chkprocess.Checked)
                        {
                            DataTable dtchk = fabobj.deletechallan("UPDATEPROCESSCHALLAN", ChallanID, Convert.ToInt32(hdnChallan_Process_Admin_Id.Value)).Tables[0];
                        }
                    }
                }
            }

            DataTable dtm = fabobj.deletechallan("DELETECHALLANMETER", ChallanID, -1).Tables[0];
            int meter = 0;
            int Cmeter = 0;
            //foreach (GridViewRow gvr in grdmaster.Rows)
            //{
            //    Label lblserial = (Label)gvr.FindControl("lblserial");
            //    HiddenField hdnmtr = (HiddenField)gvr.FindControl("hdnmtr");
            //    HiddenField hdncentimtr = (HiddenField)gvr.FindControl("hdncentimtr");
            //    if (hdnmtr.Value != "" && hdncentimtr.Value != "")
            //    {
            //        meter = Convert.ToInt32(hdnmtr.Value);
            //        Cmeter = Convert.ToInt32(hdncentimtr.Value);
            //        DataTable dtchk = fabobj.deletechallan("INSERTCHALLANMETER", ChallanID, 0, Convert.ToInt32(lblserial.Text), meter, Cmeter).Tables[0];
            //    }

            //}

            //foreach (GridViewRow gvr in GridView1.Rows)
            //{
            //    Label lblserial = (Label)gvr.FindControl("lblserial");
            //    HiddenField hdnmtr = (HiddenField)gvr.FindControl("hdnmtr");
            //    HiddenField hdncentimtr = (HiddenField)gvr.FindControl("hdncentimtr");
            //    if (hdnmtr.Value != "" && hdncentimtr.Value != "")
            //    {
            //        meter = Convert.ToInt32(hdnmtr.Value);
            //        Cmeter = Convert.ToInt32(hdncentimtr.Value);
            //        DataTable dtchk = fabobj.deletechallan("INSERTCHALLANMETER", ChallanID, 0, Convert.ToInt32(lblserial.Text), meter, Cmeter).Tables[0];

            //    }
            //}
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "Savemtervalue();", true);
            //}
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        public string ValidateRecieveQty()
        {
            string result = "";
            DataSet ds = new DataSet();
            DataTable dtTotalPrint = new DataTable();

            DataSet dsStgae = new DataSet();
            DataTable dtStgae = new DataTable();

            //int Totalfebreq = 0;
            //ds = fabobj.GetFabricIssueDetails("CONTRACTDETAILS", Convert.ToInt32(OrderDetailsID), FabricQualityID, FabricQualityID, OrderDetailsID);
            //dsStgae = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderDetailsID), Convert.ToInt32(FabricQualityID), FabricQualityID, OrderDetailsID, "", FabricDetails);
            //    if (ds.Tables[2].Rows.Count > 0)
            //    {
            //        dtTotalPrint = ds.Tables[2];
            //        DataRow[] dr = dtTotalPrint.Select("Fabric_Quality_DetailsID = " + FabricQualityID);
            //        Totalfebreq = Convert.ToInt32(dr[0]["Totalfebreq"].ToString());

            //        decimal x = Convert.ToDecimal(dr[0]["Totalfebreq"].ToString()) * Convert.ToDecimal(dsStgae.Tables[0].Rows[0]["CutWidth"]);
            //        Totalfebreq = Convert.ToInt32(x);
            //    }
            //DataTable stxc = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderDetailsID), Convert.ToInt32(FabricQualityID), FabricQualityID, OrderDetailsID, "", FabricDetails).Tables[1];
            //if (stxc.Rows.Count > 0)
            //{
            //    hdnmaxavailbleqty.Value = stxc.Rows[0]["LastestStageVal"].ToString();
            //}
            DataTable stxc = fabobj.GetFabricIssueDetails("CUTWIDTH", OrderDetailsID, FabricQualityID, FabricQualityID, OrderDetailsID, "", FabricDetails).Tables[1];

            //   if (stxc.Rows.Count > 0)
            //   {
            //       Totalfebreq = Convert.ToInt32(stxc.Rows[0]["LastestStageVal"].ToString());
            //   }
            //decimal pendingqty_get = 0;
            //DataTable dtpendingqty_get = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderDetailsID), Convert.ToInt32(FabricQualityID), FabricQualityID, OrderDetailsID, "", FabricDetails).Tables[0];
            //if (dtpendingqty_get.Rows.Count > 0)
            //{
            //     pendingqty_get = (dtpendingqty_get.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty_get.Rows[0]["TotalPendingQty"].ToString()) : 0);

            //}

            int meter = 0;
            //foreach (GridViewRow gvr in grdmaster.Rows)
            //{
            //    HiddenField hdnmtr = (HiddenField)gvr.FindControl("hdnmtr");
            //    meter = meter + Convert.ToInt32(hdnmtr.Value);

            //}
            //foreach (GridViewRow gvr in GridView1.Rows)
            //{
            //    HiddenField hdnmtr = (HiddenField)gvr.FindControl("hdnmtr");
            //    meter = meter + Convert.ToInt32(hdnmtr.Value);

            //}
            //if (txtmeter.Text != "")
            //{
            //    meter = meter + Convert.ToInt32(txtmeter.Text);
            //}
            DataTable dt = fabobj.GetInternalChallanDetails("GETRECEIVED", SupplierPoID, "INT", ChallanID, IsNewChallan, OrderDetailsID, FabricQualityID, FabricDetails).Tables[0];
            if (ChallanType.ToUpper() == "INTERNAL")
            {
                if (dt.Rows.Count > 0)
                {
                    int TotalMtr = 0;
                    if (dt.Rows[0]["TotalMeters"].ToString() == "")
                        TotalMtr = 0;
                    else
                        TotalMtr = Convert.ToInt32(dt.Rows[0]["TotalMeters"]);

                    //meter = meter + TotalMtr;

                    int qty = txtqtytotal.Text == "" ? 0 : Convert.ToInt32(txtqtytotal.Text.Replace(",", ""));
                    meter = qty + TotalMtr;
                }

                if (meter > Convert.ToInt32(hdnmaxavailbleqty.Value) + Convert.ToInt32(hdnSavedChallanQty.Value))
                {
                    result = "Total issued cannot be greater than available quantity";
                    //tddebitqty.Attributes.Add("class", "input-validation-error");
                }
                //else
                //{
                //    tddebitqty.Attributes.Remove("class");
                //}
            }
            else if (ChallanType.ToUpper() == "DEBITCHALLAN")
            {
                int qty = txtqtytotal.Text == "" ? 0 : Convert.ToInt32(txtqtytotal.Text.Replace(",", ""));


                int availabedebitqty = int.Parse(hdndebitavailebaleqty.Value);
                int Enterdavailabedebitqty = qty;
                if (Enterdavailabedebitqty > availabedebitqty)
                {
                    result = "Total issued cannot be greater than debit available quantity";
                    // tddebitqty.Style[HtmlTextWriterStyle.BorderColor] = "red";
                    //tddebitqty.Attributes.Add("class", "input-validation-error");
                }
                else
                {
                    //tddebitqty.Attributes.Remove("class");
                }
            }


            return result;
        }

        protected void ImgBtnadd_Click(object sender, EventArgs e)
        {

            string result = ValidateRecieveQty();
            if (result != "")
            {
                ShowAlert(result);
                return;
            }

            SetSeq();
        }

        public DataTable gettable()
        {
            DataTable custTable = new DataTable("dt2");
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "Challan_BreakDown_Id";
            dtColumn.Caption = "Challan_BreakDown_Id";
            custTable.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "Challan_Id";
            dtColumn.Caption = "Challan_Id";
            custTable.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "Meter";
            dtColumn.Caption = "Meter";
            custTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "CM";
            dtColumn.Caption = "CM";
            custTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "SrNumber";
            dtColumn.Caption = "SrNumber";
            custTable.Columns.Add(dtColumn);

            return custTable;
        }

        protected void grdmaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblserial = (Label)e.Row.FindControl("lblserial");
                //lblserial.Text = (e.Row.RowIndex+1).ToString();

                //DataSet ds = fabobj.GetFabricpurchasedSupplier("GRIEGE", "GETPOSUPPLIERETA", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID);
                //DataTable dt = ds.Tables[0];
                //if (dt.Rows.Count > 0)
                //{
                if (e.Row.RowIndex == 0)
                {
                    //e.Row.Cells[0].Controls.Add(new Literal { Text = "" });
                    //e.Row.Cells[1].Controls.Add(new Literal { Text = "<asp:TextBox ID='txtmeter' Width='100%' onchange='javascript:updatecm(this)' class='noonly' runat='server' Text='' />" });
                    //e.Row.Cells[2].Controls.Add(new Literal { Text = "<asp:TextBox ID='txtcm' Enabled='false' Width='100%' class='noonly' runat='server' Text=''/>" });
                    //e.Row.Cells[3].Controls.Add(new Literal { Text = "<input type='image' id='dele' onclick='DeleteRow();return false;' />" });
                    e.Row.Cells[0].CssClass = "CloneRow txtcenter border_left_color";
                    e.Row.Cells[1].CssClass = "CloneRow txtcenter";
                    e.Row.Cells[2].CssClass = "CloneRow txtcenter";
                    e.Row.Cells[3].CssClass = "CloneRow txtcenter border_right_color";

                }
                //else
                //{
                //  //e.Row.Cells[0].Controls.Add(new Literal { Text = "<input type='hidden' name='fromqtyval' value='" + dt.Rows[e.Row.RowIndex]["FromQty"].ToString() + "'>" });
                //  //e.Row.Cells[1].Controls.Add(new Literal { Text = "<input type='hidden' name='toqtyval' value='" + dt.Rows[e.Row.RowIndex]["ToQty"].ToString() + "'>" });
                //  //e.Row.Cells[2].Controls.Add(new Literal { Text = "<input type='hidden' name='Etadate' value='" + dt.Rows[e.Row.RowIndex]["POETADate"].ToString() + "'>" });
                //  //e.Row.Cells[3].Controls.Add(new Literal { Text = "<img name='deleteetarow' src='../../images/del-butt.png' alt=''  title='Delete' onclick='DeleteRow();return false;' />" });
                //}
                // }

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblserial = (Label)e.Row.FindControl("lblserial");
                //lblserial.Text = (e.Row.RowIndex+grdmaster.Rows.Count + 1).ToString();
                //DataSet ds = fabobj.GetFabricpurchasedSupplier("GRIEGE", "GETPOSUPPLIERETA", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID);
                //DataTable dt = ds.Tables[0];
                //if (dt.Rows.Count > 0)
                //{
                if (e.Row.RowIndex == 0)
                {
                    //e.Row.Cells[0].Controls.Add(new Literal { Text = "" });
                    //e.Row.Cells[1].Controls.Add(new Literal { Text = "<asp:TextBox ID='txtmeter' Width='100%' onchange='javascript:updatecm(this)' class='noonly' runat='server' Text='' />" });
                    //e.Row.Cells[2].Controls.Add(new Literal { Text = "<asp:TextBox ID='txtcm' Enabled='false' Width='100%' class='noonly' runat='server' Text=''/>" });
                    //e.Row.Cells[3].Controls.Add(new Literal { Text = "<input type='image' id='dele' onclick='DeleteRow();return false;' />" });
                    e.Row.Cells[0].CssClass = "CloneRow txtcenter";
                    e.Row.Cells[1].CssClass = "CloneRow txtcenter";
                    e.Row.Cells[2].CssClass = "CloneRow txtcenter";
                    e.Row.Cells[3].CssClass = "CloneRow txtcenter";

                }
                //else
                //{
                //  //e.Row.Cells[0].Controls.Add(new Literal { Text = "<input type='hidden' name='fromqtyval' value='" + dt.Rows[e.Row.RowIndex]["FromQty"].ToString() + "'>" });
                //  //e.Row.Cells[1].Controls.Add(new Literal { Text = "<input type='hidden' name='toqtyval' value='" + dt.Rows[e.Row.RowIndex]["ToQty"].ToString() + "'>" });
                //  //e.Row.Cells[2].Controls.Add(new Literal { Text = "<input type='hidden' name='Etadate' value='" + dt.Rows[e.Row.RowIndex]["POETADate"].ToString() + "'>" });
                //  //e.Row.Cells[3].Controls.Add(new Literal { Text = "<img name='deleteetarow' src='../../images/del-butt.png' alt=''  title='Delete' onclick='DeleteRow();return false;' />" });
                //}
                // }

            }

        }

        public void SetSeq()
        {

            if (ChallanType.ToUpper() == "DEBITCHALLAN")
            {

                Decimal Leftdebitqty = 0;
                int availabedebitqty = int.Parse(hdndebitavailebaleqty.Value);
                int Enterdavailabedebitqty = (txtqtytotal.Text == "" ? 0 : Convert.ToInt32(txtqtytotal.Text.Replace(",", "")));

                lblavailableqtydebitchallan.Text = (Convert.ToDecimal(availabedebitqty) - Convert.ToDecimal(Enterdavailabedebitqty)).ToString("N0");
                hdn_AvailableDebitChallanQty.Value = lblavailableqtydebitchallan.Text; // new line 08-04-2021
                if (Convert.ToDecimal(lblavailableqtydebitchallan.Text == "" ? "0" : lblavailableqtydebitchallan.Text) > 0)
                {
                    Leftdebitqty = lblavailableqtydebitchallan.Text == "" ? 0 : Convert.ToDecimal(lblavailableqtydebitchallan.Text);
                    lbldebitdefualtqty.Text = Math.Round((Leftdebitqty / Convert.ToDecimal(ConversionValue))).ToString("N0");
                }

                if (Convert.ToDecimal(lblavailableqtydebitchallan.Text == "" ? "0" : lblavailableqtydebitchallan.Text) <= 0)
                {
                    lblavailableqtydebitchallan.Visible = false;
                    lblavailbledebittext.Visible = false;
                    lblavailabelqtyunitname.Visible = false;
                    lbldebitdefualtqty.Visible = false;
                    lbldebitdefualtunitstaticinfo.Visible = false;
                    //tddebitqty.Style[HtmlTextWriterStyle.BorderColor] = "";
                    tdRightBorder.Attributes.Add("style", "display:none");
                }
                else
                {
                    lblavailableqtydebitchallan.Visible = true;
                    lblavailbledebittext.Visible = true;
                    lblavailabelqtyunitname.Visible = true;

                    lbldebitdefualtqty.Visible = true;
                    lbldebitdefualtunitstaticinfo.Visible = true;
                    tdRightBorder.Attributes.Add("style", "display:block");
                }
                if (hdndefaultunit.Value == hdnconverttounit.Value)
                {

                    lbldebitdefualtqty.Visible = false;
                    lbldebitdefualtunitstaticinfo.Visible = false;

                }
            }
            if (ChallanType.ToUpper() == "INTERNAL")
            {
                int availabedebitqty = int.Parse(hdnmaxavailbleqty.Value);
                int Enterdavailabedebitqty = int.Parse(txtqtytotal.Text.Trim() == "" ? "0" : txtqtytotal.Text.Trim().Replace(",", ""));
                if (ChallanID > 0)
                {
                    int savedqty = Convert.ToInt32(hdntotalmeter.Value.Replace(",", "") == "" ? Convert.ToInt32(0) : Convert.ToInt32(hdntotalmeter.Value.Replace(",", "")));

                    int diffqty = 0;
                    if (chkrecivegood.Checked == true && chkAuthorised.Checked == true)
                        diffqty = Convert.ToInt32(Enterdavailabedebitqty) - Convert.ToInt32(savedqty);
                    else
                        diffqty = Convert.ToInt32(Enterdavailabedebitqty);

                    lblavailableqtydebitchallan.Text = Math.Abs((Convert.ToDecimal(availabedebitqty) - Convert.ToDecimal(diffqty))).ToString("N0");
                }
                else
                {
                    lblavailableqtydebitchallan.Text = Math.Abs((Convert.ToDecimal(availabedebitqty) - Convert.ToDecimal(Enterdavailabedebitqty))).ToString("N0");
                }

                hdn_AvailableDebitChallanQty.Value = lblavailableqtydebitchallan.Text;  //new line 08-04-2021
                if (Convert.ToDecimal(lblavailableqtydebitchallan.Text == "" ? "0" : lblavailableqtydebitchallan.Text) <= 0)
                {
                    lblavailableqtydebitchallan.Visible = false;
                    lblavailbledebittext.Visible = false;
                    lblavailabelqtyunitname.Visible = false;
                    //tddebitqty.Style[HtmlTextWriterStyle.BorderColor] = "";
                }
                else
                {
                    tdRightBorder.Attributes.Add("style", "display:block");
                    lblavailableqtydebitchallan.Visible = true;
                    lblavailbledebittext.Visible = true;
                    lblavailabelqtyunitname.Visible = true;
                }
            }
            ////txtqtytotal.Text = totalmeter.ToString("N0");


        }

        private static List<DataTable> SplitTable(DataTable originalTable, int batchSize)
        {
            List<DataTable> tables = new List<DataTable>();
            int i = 0;
            int j = 1;
            DataTable newDt = originalTable.Clone();
            newDt.TableName = "Table_" + j;
            newDt.Clear();
            foreach (DataRow row in originalTable.Rows)
            {
                DataRow newRow = newDt.NewRow();
                newRow.ItemArray = row.ItemArray;
                newDt.Rows.Add(newRow);
                i++;
                if (i == batchSize)
                {
                    tables.Add(newDt);
                    j++;
                    newDt = originalTable.Clone();
                    newDt.TableName = "Table_" + j;
                    newDt.Clear();
                    i = 0;
                }
            }
            if (newDt.Rows.Count > 0)
            {
                tables.Add(newDt);
                j++;
                newDt = originalTable.Clone();
                newDt.TableName = "Table_" + j;
                newDt.Clear();

            }
            return tables;
        }

        public void txtqtytotal_TextChanged(object sender, EventArgs e)
        {
            if (ChallanType.ToLower() == "ExtraStockIssue".ToLower())
            {

                int BalanceInStock = balanceinstock.InnerText == "" ? 0 : Convert.ToInt32(balanceinstock.InnerText);
                int EnteredQty = txtqtytotal.Text == "" ? 0 : Convert.ToInt32(txtqtytotal.Text);

                if (EnteredQty == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Please Enter Valid Foc Qty.')", true);
                    txtqtytotal.Text = "";
                }
                else if (EnteredQty > BalanceInStock)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('You cannot Issue More than Available Stock.')", true);
                    txtqtytotal.Text = "";
                }

                string unit = hdnInternalUnitIds.Value;

                if (unit.Split(',').Any(val => val.Trim() == ddlsuppliername.SelectedValue))
                {
                    trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:none;");

                }
                else
                {
                    trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:contents;");
                }
            }
            else
            {
                string haserror = ValidateRecieveQty();

                if (haserror != "")
                {
                    ShowAlert(haserror);

                    int nNumber = int.TryParse(hdntotalmeter.Value.Replace(",", ""), out nNumber) ? nNumber : 0;

                    txtqtytotal.Text = decimal.Parse(nNumber.ToString()).ToString("#,#.##");

                    lblavailableqtydebitchallan.Text = Convert.ToDecimal(hdndebitavailebaleqty.Value).ToString("N0");
                    lblavailbledebittext.Text = "Available Qty: ";
                    lblTotalAmount.Text = "";

                    return;
                }
                else
                {
                    if (txtqtytotal.Text != string.Empty && lblrate.Text != string.Empty && hdnGst.Value != string.Empty)
                    {
                        lblTotalAmount.Text = Math.Round((((Convert.ToDecimal(txtqtytotal.Text) * Convert.ToDecimal(lblrate.Text)) * (100 + Convert.ToDecimal(hdnGst.Value))) / 100),0).ToString();

                        if (lblgstno.Text.ToString().Substring(0, 2) == "09")
                        {
                            lblSGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value) / 2)), 0)) + ")";
                            lblCGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value) / 2)), 0)) + ")";
                            if (lblSGSTValue.Text == "(₹" + "0" + ")")
                                lblSGSTValue.Text = "";
                            if (lblCGSTValue.Text == "(₹" + "0" + ")")
                                lblCGSTValue.Text = "";
                            lblSGSTValue.Visible = true;
                            lblCGSTValue.Visible = true;
                           
                        }
                        else
                        {
                            lblIGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value))), 0)) + ")";
                            if (lblIGSTValue.Text == "(₹" + "0" + ")")
                                lblIGSTValue.Text = "";
                            lblSGSTValue.Visible = false;
                            lblCGSTValue.Visible = false;
                            lblIGSTValue.Visible = true;
                        } 
                    }
                    else
                    {
                        lblTotalAmount.Text = string.Empty;
                    }
                    SetSeq();
                }

                if (trToShowGSTNoForInternalChallan.Visible)
                {
                    string unit = hdnInternalUnitIds.Value;

                    if (unit.Split(',').Any(val => val.Trim() == ddlsuppliername.SelectedValue))
                    {
                        trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:none;");

                    }
                    else
                    {
                        trToShowGSTNoForInternalChallan.Attributes.Add("style", "display:contents;");
                    }
                }
            }           
        }

        public void RenderHtml()
        {
            hdnconversionvalue.Value = hdnconversionvalue.Value == "" ? "1" : hdnconversionvalue.Value;
            WebRequest Request = null;
            WebResponse Response;
            StreamReader reader;
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            string strHTML;

            #region FOC Challan
            if (ChallanType.ToUpper() == "FOC_CHALLAN".ToUpper())
            {
                Request = WebRequest.Create(host1 + "/FabricPdfFile/FabricExternalChallanPdf.aspx?SupplierPoID=" + SupplierPoID + "&ChallanNumber=" + txtchallanno.Text.Trim() + "&ChallanType=" + "FOC_CHALLAN" + "&IsNewChallan=" + "");

            }

            #endregion FOC Challan

            #region SENDQTYCHALLAN
            if (ChallanType.ToUpper() == "SENDQTYCHALLAN")
            {
                string sqty = "";

                if (txtsendqtyforinfo.Text == "")
                    sqty = "0";

                else
                    sqty = txtsendqtyforinfo.Text;

                string cunit = lblconverttounit.Text;

                if (sqty != "0" || sqty != "")
                    hdnConvertedQuantityForPdf.Value = (Convert.ToDecimal(sqty) / Convert.ToDecimal(hdnconversionvalue.Value == "" ? "1" : hdnconversionvalue.Value)).ToString();

                string drqty = hdnConvertedQuantityForPdf.Value;
                string dunit = lbldefualtunit.Text;
                string srmng = "";
                string units = "";
                decimal remainingqty = Convert.ToDecimal(hdnsentRemainingQty.Value) - Convert.ToDecimal(sqty);

                if (remainingqty != 0)
                    srmng = remainingqty.ToString();

                else
                    srmng = "";

                if (hdnsentRemainingUnit.Value != "0")
                    units = hdnsentRemainingUnit.Value;

                else units = "";

                string dustaticinfo = (remainingqty / Convert.ToDecimal(hdnconversionvalue.Value)).ToString();
                string dunitinfo = lbldefualtinitinfo.Text;

                Request = WebRequest.Create(host1 + "/FabricPdfFile/FabricExternalChallanPdf.aspx?SupplierPoID=" + SupplierPoID + "&ChallanID=" + ChallanID + "&UserId=" + UserId + "&DebitNoteId=" + DebitNote_Id + "&ChallanType=" + ChallanType + "&sqty=" + sqty + "&cunit=" + cunit + "&drqty=" + drqty + "&dunit=" + dunit + "&srmng=" + srmng + "&dustaticinfo=" + dustaticinfo + "&dunitinfo=" + dunitinfo + "&units=" + units);
            }
            #endregion SENDQTYCHALLAN

            #region DEBITCHALLAN
            if (ChallanType.ToUpper() == "DEBITCHALLAN")
            {
                string NoItem = "";
                string ItemUnit = "";
                string totalQty = "";
                string convrtunit = "";
                string AvaDebitCha = "";
                string AvaQty = "";
                string DebitdefQty = "";
                string DefStaticInfo = "";

                NoItem = txtthanvalue.Text;
                totalQty = txtqtytotal.Text.Replace(",", "");
                convrtunit = lblinternalconverttounit.Text;
                AvaDebitCha = hdn_AvailableDebitChallanQty.Value;
                AvaQty = lblavailabelqtyunitname.Text;
                DebitdefQty = hdn_DebitDefaultQty.Value;
                DefStaticInfo = lbldebitdefualtunitstaticinfo.Text;

                Request = WebRequest.Create(host1 + "/FabricPdfFile/FabricExternalChallanPdf.aspx?SupplierPoID=" + SupplierPoID + "&ChallanID=" + ChallanID + "&UserId=" + UserId + "&DebitNoteId=" + DebitNote_Id + "&ChallanType=" + ChallanType + "&NoItem=" + NoItem + "&ItemUnit=" + ItemUnit + "&totalQty=" + totalQty + "&convrtunit=" + convrtunit + "&AvaDebitCha=" + AvaDebitCha + "&AvaQty=" + AvaQty + "&DebitdefQty=" + DebitdefQty + "&DefStaticInfo=" + DefStaticInfo);

            }

            #endregion DEBITCHALLAN

            Request.Timeout = Convert.ToInt32(99999999);
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }

        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "Challan_" + hdnChallan_Number.Value + ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }

        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "Challan_" + hdnChallan_Number.Value + ".pdf");

            var pechkin = Factory.Create(new GlobalConfig());
            var pdf = pechkin.Convert(new ObjectConfig()
                                    .SetLoadImages(true).SetZoomFactor(1.5)
                                    .SetPrintBackground(true)
                                    .SetScreenMediaType(true)
                                    .SetCreateExternalLinks(true), (HTMLCode));
            using (FileStream file = System.IO.File.Create(strFileName))
            {
                file.Write(pdf, 0, pdf.Length);
            }

        }

        public string getImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

            RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);

                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
                        if (src == "../../signatured.jpg" || src == "../signatured.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/SignatureD.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {

                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);

                                //insert new url img tag in whole html code
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                            }
                        }
                    }
                }
            }
            return tempInput;
        }

        public static string HttpContent(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 80000000;
                //req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";

                using (var resp = req.GetResponse())
                {
                    result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message.ToString();
            }
            return result;
        }

        public Boolean SendDebitNoteEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();
                string email = "itsupport@boutique.in";
                to.Add(email);

                List<Attachment> atts = new List<Attachment>();

                if (File.Exists(Constants.PRINT_FOLDER_PATH + "Challan_" + hdnChallan_Number.Value + ".pdf"))
                {

                    PoPath = Path.Combine(Constants.PRINT_FOLDER_PATH, "Challan_" + hdnChallan_Number.Value + ".pdf");
                    atts.Add(new Attachment(PoPath));
                }

                this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }

        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String MailType, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType + "Against (" + hdnPO_Number.Value + ")";

            string ChallanType = "";
            if (hdnChallan_Number.Value.Contains("EXTFOC"))
                ChallanType = "FOC Challan ";
            else ChallanType = "Send Challlan ";

            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>" + ChallanType + "</span>" + "<b>" + hdnChallan_Number.Value + "</b> for " + "Purchase Order - " + hdnPO_Number.Value + " is raised for <span style='color:gray'> Fabric Quality </span>" + "<span style='color:#2f5597'>" + hdnFabricQuality.Value + "</span> for stage <span style='color:#2f5597'>" + FabType.ToString() + "</span>" + ". Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";

            mailMessage.IsBodyHtml = true;

            if (hasAppendAttachment && Attachments != null)
            {
                int i = 1;

                foreach (Attachment attachment in Attachments)
                {
                    if (attachment.ContentStream.Length > 0)
                    {
                        LinkedResource imageId = new LinkedResource(attachment.ContentStream, "image/jpeg");
                        imageId.ContentId = "imageId" + i.ToString();
                        imageId.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                    }
                    i++;
                }
            }
            else
            {
                mailMessage.Body = mailMessage.Body;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

            if (isDebug)
            {
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                //mailMessage.CC.Add("ravishankar@boutique.in");
                //mailMessage.CC.Add("ravi@boutique.in");
                mailMessage.CC.Add("itsupport@boutique.in");

            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);

                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.CC.Add("Bipl_fabric@boutique.in");
            }

            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            if (!hasAppendAttachment && Attachments != null)
            {
                foreach (Attachment att in Attachments)
                {
                    mailMessage.Attachments.Add(att);
                }
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE)
            {
                smtpClient.EnableSsl = true;
            }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                ShowAlert("Mail Sent successfully");
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + Subject.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }

            finally
            {
                try
                {
                    if (Attachments != null)
                    {
                        foreach (Attachment att in Attachments)
                        {
                            att.Dispose();
                        }

                        Attachments = null;
                    }

                    foreach (Attachment att in mailMessage.Attachments)
                    {
                        att.Dispose();
                    }

                    mailMessage = null;

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }

        public void txtsendqtyforinfo_TextChanged(object sender, EventArgs e)
        {
            #region SENDQTYCHALLAN
            if (ChallanType.ToUpper() == "SENDQTYCHALLAN")
            {
                decimal EnterdQty = (txtsendqtyforinfo.Text == "" ? 0 : Convert.ToDecimal(txtsendqtyforinfo.Text));

                decimal totalsendrem = 0;
                if (hdndefaultunit.Value != hdnconverttounit.Value)
                {
                    lbldefualtunit.Visible = true;
                    lbldefualtinitinfo.Visible = true;

                    lbldefualtremaningqty.Visible = true;


                    lbldefualtunitstaticinfo.Visible = true;
                    lbldefualtinitinfo.Visible = true;


                    if (ChallanID <= 0)
                    {
                        lbldefualtremaningqty.Text = (Math.Round((Convert.ToDecimal(EnterdQty) / Convert.ToDecimal(ConversionValue)), 0)).ToString("N0");


                        lbldefualtunit.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefaultunit.Value));
                        lbldefualtunitstaticinfo.Text = (Math.Round((Convert.ToDecimal(SendQty) / Convert.ToDecimal(ConversionValue)), 0)).ToString("N0");
                        totalsendrem = Convert.ToDecimal(hdnsendtotalrening.Value) - EnterdQty;
                        lblsendreaming.Text = "Remaining Qty.: " + totalsendrem.ToString("N0") + " " + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value));
                        hdnremainingqty.Value = totalsendrem.ToString();
                        decimal defualtremqty = (Math.Round((Convert.ToDecimal(totalsendrem) / Convert.ToDecimal(ConversionValue)), 0));
                        lbldefualtunitstaticinfo.Text = defualtremqty.ToString("N0");
                        lbldefualtinitinfo.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefaultunit.Value));

                    }
                    else
                    {
                        decimal remainingqty = (Convert.ToInt32(hdnexternalchallanremainingqty.Value)) - EnterdQty;
                        //decimal diffqty = EnterdQty - Challaqty;

                        lbldefualtremaningqty.Text = (Math.Round((Convert.ToDecimal(EnterdQty) / Convert.ToDecimal(ConversionValue)), 0)).ToString("N0");


                        lbldefualtunit.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefaultunit.Value));
                        lbldefualtunitstaticinfo.Text = (Math.Round((Convert.ToDecimal(SendQty) / Convert.ToDecimal(ConversionValue)), 0)).ToString("N0");

                        totalsendrem = remainingqty;
                        //totalsendrem = Convert.ToDecimal(hdnsendtotalrening.Value) - (diffqty);
                        lblsendreaming.Text = "Remaining quantity: " + totalsendrem.ToString("N0") + " " + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value));
                        hdnremainingqty.Value = totalsendrem.ToString();
                        decimal defualtremqty = (Math.Round((Convert.ToDecimal(totalsendrem) / Convert.ToDecimal(ConversionValue)), 0));
                        lbldefualtunitstaticinfo.Text = defualtremqty.ToString("N0");
                        lbldefualtinitinfo.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefaultunit.Value));
                    }


                    if (totalsendrem <= 0)
                    {
                        lblsendreaming.Text = "";
                        hdnremainingqty.Value = "";
                        lbldefualtunitstaticinfo.Text = "";
                        lbldefualtinitinfo.Text = "";
                    }
                    if (EnterdQty <= 0)
                    {
                        lbldefualtremaningqty.Text = "";


                        lbldefualtunit.Text = "";
                    }
                }
                else
                {
                    if (ChallanID <= 0)
                    {
                        totalsendrem = Convert.ToDecimal(hdnsendtotalrening.Value) - EnterdQty;
                        lblsendreaming.Text = "Remaining quantity: " + totalsendrem.ToString("N0") + " " + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value));
                        hdnremainingqty.Value = totalsendrem.ToString();
                    }
                    else
                    {
                        decimal remainingqty = (Convert.ToInt32(hdnexternalchallanremainingqty.Value)) - EnterdQty;

                        //decimal diffqty = EnterdQty - Challaqty;
                        //totalsendrem = Convert.ToDecimal(hdnsendtotalrening.Value) - (diffqty);

                        totalsendrem = remainingqty;

                        lblsendreaming.Text = "Remaining quantity: " + totalsendrem.ToString("N0") + " " + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value));
                        hdnremainingqty.Value = totalsendrem.ToString();
                    }

                    if (totalsendrem <= 0)
                    {
                        lblsendreaming.Text = "";
                        hdnremainingqty.Value = "";
                    }

                    //if (EnterdQty <= 0)
                    //{
                    //    lblsendreaming.Text = "";
                    //}
                }
                Decimal SendQtyy = txtsendqtyforinfo.Text == "" ? Convert.ToDecimal(0) : Convert.ToDecimal(txtsendqtyforinfo.Text);
                lblTotalAmount.Text = Math.Round((((Math.Round((SendQtyy / Convert.ToDecimal(ConversionValue)), 0) * Convert.ToDecimal(lblrate.Text)) * (100 + Convert.ToDecimal(hdnGst.Value))) / 100),0).ToString();

                if (lblgstno.Text.ToString().Substring(0, 2) == "09")
                {
                    lblSGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value) / 2)), 0)) +")";
                    lblCGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value) / 2)), 0)) + ")";
                    if (lblSGSTValue.Text == "(₹" + "0" + ")")
                        lblSGSTValue.Text = "";
                    if (lblCGSTValue.Text == "(₹" + "0" + ")")
                        lblCGSTValue.Text = "";
                    lblIGSTValue.Visible = false;
                    lblSGSTValue.Visible = true;
                    lblCGSTValue.Visible = true;
                   
                }
                else
                {
                    lblIGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value))), 0)) + ")";
                    if (lblIGSTValue.Text == "(₹" + "0" + ")")
                      lblIGSTValue.Text = "";
                    lblIGSTValue.Visible = true;
                    lblSGSTValue.Visible = false;
                    lblCGSTValue.Visible = false;
                } 
                ScriptManager.RegisterStartupScript(this, GetType(), "DisplaySendMail", "DisplaySendMail();", true);


                foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        HtmlInputCheckBox challanProcess = (HtmlInputCheckBox)item.FindControl("challanProcess");
                        Label lblfabricoprationType = (Label)item.FindControl("lblfabricoprationType");

                        if (challanProcess.Checked)
                        {
                            if (lblfabricoprationType.Text.ToLower() == "Sampling".ToLower())
                            {
                                txtSuppliername.Attributes.Add("style", "display:inline-block");
                                txtSuppliername.Enabled = true;
                                txtSuppliername.Attributes.Add("style", "border:1px solid black");
                                lblsuppliername.Attributes.Add("style", "display:none");


                                txtGSTNo.Attributes.Add("style", "display:inline-block");
                                txtGSTNo.Enabled = true;
                                txtGSTNo.Attributes.Add("style", "border:1px solid black");
                                lblgstno.Attributes.Add("style", "display:none");


                                txtSupplierAddress.Attributes.Add("style", "display:inline-block");
                                txtSupplierAddress.Enabled = true;
                                txtSupplierAddress.Attributes.Add("style", "border:1px solid black");
                                lbladdress.Attributes.Add("style", "display:none");

                                break;

                            }
                            else
                            {
                                lblsuppliername.Attributes.Add("style", "display:inline-block");
                                txtSuppliername.Attributes.Add("style", "display:none");

                                lblgstno.Attributes.Add("style", "display:inline-block");
                                txtGSTNo.Attributes.Add("style", "display:none");

                                lbladdress.Attributes.Add("style", "display:inline-block");
                                txtSupplierAddress.Attributes.Add("style", "display:none");
                                break;
                            }

                        }
                    }
                }
            }
            #endregion SENDQTYCHALLAN

            #region FOC_CHALLAN

            else if (ChallanType.ToUpper() == "FOC_CHALLAN")
            {
                int EnterdQty = txtsendqtyforinfo.Text == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(txtsendqtyforinfo.Text) / Convert.ToDecimal(ConversionValue), 0));
                int EnterdQtyWithoutConversion = txtsendqtyforinfo.Text == "" ? 0 : Convert.ToInt32(txtsendqtyforinfo.Text);
                string ConvertToUnit = lblconverttounit.Text;


                int TotalSendQtyWithoutFocc = TotalSendQtyWithoutFoc.InnerText == "" ? 0 : Convert.ToInt32(TotalSendQtyWithoutFoc.InnerText);

                int TotalSendQtyWithFocc = TotalSendQtyWithFoc.InnerText == "" ? 0 : Convert.ToInt32(TotalSendQtyWithFoc.InnerText);

                int focextrapercentboxx = focextrapercentbox.Text == "" ? 0 : Convert.ToInt32(focextrapercentbox.Text);

                int FocStockAvailableQtyy = FocStockAvailableQty.InnerText == "" ? 0 : Convert.ToInt32(FocStockAvailableQty.InnerText);

                if (EnterdQty == 0)
                {
                    if (EnterdQtyWithoutConversion == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Please Enter Foc Qty.')", true);
                        txtsendqtyforinfo.Text = "";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('You cannot send " + EnterdQtyWithoutConversion + " " + ConvertToUnit + " because when divided by Conversion Value : " + ConversionValue + " resulting to zero When Rounded To Zero Decimal Place, which is not Valid. Please Enter Correcty FOC Qty.')", true);
                        txtsendqtyforinfo.Text = "";
                    }
                }
                else
                {
                    if (focextrapercentboxx == 0)
                    {
                        if (EnterdQtyWithoutConversion > FocStockAvailableQtyy)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('You cannot Send more than Stock Available Qty. Which is currently " + FocStockAvailableQtyy + " for " + StockAvailableQtyAtStage.InnerText + "')", true);
                            txtsendqtyforinfo.Text = "";
                        }

                        else
                        {
                            if (EnterdQtyWithoutConversion > (TotalSendQtyWithoutFocc - TotalSendQtyWithFocc))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Entered Qty. cannot be greater than Total Send Qty.(Without Foc) - Total Send Qty.(Foc)')", true);
                                txtsendqtyforinfo.Text = "";
                            }
                        }
                    }

                    else if (focextrapercentboxx > 0)
                    {
                        Decimal A = TotalSendQtyWithoutFocc - TotalSendQtyWithFocc;
                        int FinalFocQtyThatCanBeSent = Convert.ToInt32(Math.Round(A + ((A * focextrapercentboxx) / 100), 0));

                        if (EnterdQtyWithoutConversion > FocStockAvailableQtyy)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('You cannot Send more than Stock Available Qty. Which is currently " + FocStockAvailableQtyy + " for " + StockAvailableQtyAtStage.InnerText + "')", true);
                            txtsendqtyforinfo.Text = "";
                        }
                        else
                        {
                            if (EnterdQtyWithoutConversion > FinalFocQtyThatCanBeSent)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Entered Qty. :" + EnterdQtyWithoutConversion + " cannot be greater than " + FinalFocQtyThatCanBeSent + ".')", true);
                                txtsendqtyforinfo.Text = "";
                            }
                            else if (EnterdQtyWithoutConversion <= FinalFocQtyThatCanBeSent)
                            {
                                if (EnterdQtyWithoutConversion <= (TotalSendQtyWithoutFocc - TotalSendQtyWithFocc))
                                {
                                    focextrapercentbox.Text = "";
                                }

                            }
                        }
                    }
                }


                lblTotalAmount.Text = Math.Round((((EnterdQty * Convert.ToDecimal(lblrate.Text)) * (100 + Convert.ToDecimal(hdnGst.Value))) / 100),0).ToString();
                if (lblgstno.Text.ToString().Substring(0, 2) == "09")
                {
                    lblSGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value) / 2)), 0)) + ")";
                    lblCGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value) / 2)), 0)) + ")";
                    if (lblSGSTValue.Text == "(₹" + "0" + ")")
                        lblSGSTValue.Text = "";
                    if (lblCGSTValue.Text == "(₹" + "0" + ")")
                        lblCGSTValue.Text = "";
                    lblSGSTValue.Visible = true;
                    lblCGSTValue.Visible = true;
                    lblIGSTValue.Visible = false;

                }
                else
                {
                    lblIGSTValue.Text = "(₹" + Convert.ToString(Math.Round(Convert.ToInt32(lblTotalAmount.Text) - (Convert.ToInt32(lblTotalAmount.Text) * 100 / (100 + Convert.ToDecimal(hdnGst.Value))), 0)) + ")";
                    if (lblIGSTValue.Text == "(₹" + "0" + ")")
                        lblIGSTValue.Text = "";
                    lblIGSTValue.Visible = true;
                    lblSGSTValue.Visible = false;
                    lblCGSTValue.Visible = false;
                } 

            }
            #endregion FOC_CHALLAN
        }

        public void addExtraPercentInFoc(object sender, EventArgs e)
        {
            txtsendqtyforinfo.Text = "";
            //ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "openFocExtraPercent('true')", true);
        }

        public void ExternalReturnChallanQty_TextChanged(object sender, EventArgs e)
        {
            #region FOC_CHALLAN

            if (ChallanType.ToUpper() == "FOC_CHALLAN")
            {
                int SendQtyy = Convert.ToInt32(txtsendqtyforinfo.Text);

                int EnterdReturnedQty = externalreturnchallanqty.Text == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(externalreturnchallanqty.Text) / Convert.ToDecimal(ConversionValue), 0));
                int EnterdReturnedQtyWithoutConversion = externalreturnchallanqty.Text == "" ? 0 : Convert.ToInt32(externalreturnchallanqty.Text);
                string ConvertToUnit = lblconverttounit.Text;

                if (EnterdReturnedQty == 0)
                {
                    if (EnterdReturnedQtyWithoutConversion == 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Please Enter Valid Foc Qty.')", true);
                        externalreturnchallanqty.Text = "";
                        txtsendqtyforinfo.Text = SendQtyy.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('You cannot Reverse " + EnterdReturnedQtyWithoutConversion + " " + ConvertToUnit + " because when divided by Conversion Value : " + ConversionValue + " resulting to zero When Rounded To Zero Decimal Place, which is not Valid. Please Enter Correcty FOC Qty.')", true);
                        externalreturnchallanqty.Text = "";
                        txtsendqtyforinfo.Text = SendQtyy.ToString();
                    }
                }
                else if (EnterdReturnedQty > SendQtyy)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Return Qty. Cannot be greater than Foc Qty.')", true);
                    externalreturnchallanqty.Text = hdnreturnedchallanqty.Value;
                }

            }
            #endregion FOC_CHALLAN
        }

        public void internalreturnchallanqty_TextChanged(object sender, EventArgs e)
        {
            #region ExtraStockIssue

            if (ChallanType.ToUpper() == "ExtraStockIssue".ToUpper())
            {
                int SendQtyy = Convert.ToInt32(txtqtytotal.Text);

                int EnterdReturnedQty = internalreturnchallanqty.Text == "" ? 0 : Convert.ToInt32(Convert.ToDecimal(internalreturnchallanqty.Text));

                if (EnterdReturnedQty > SendQtyy)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Return Qty. Cannot be greater than Send Qty.')", true);
                    internalreturnchallanqty.Text = "";
                }

                if (EnterdReturnedQty == 0)
                {
                    internalreturnchallanqty.Text = "";
                }

            }
            #endregion ExtraStockIssue
        }


    }
}
