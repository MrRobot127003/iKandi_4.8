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
using System.Web.Services;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using Pechkin;

using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;

using System.Web.Configuration;

using System.Net;
using System.Net.Mail;


namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricPurChasedForm : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        PDFController pdfcon = new PDFController();
        FabricController fabobj = new FabricController();
        Designation[] AuthorizedDesig = { Designation.BIPL_Fabrics_Manager };
        Designation[] JuniorDesig = { Designation.BIPL_Fabrics_Assistant, Designation.BIPL_Fabrics_Manager_Fabric_Store };
        public string colorprintdetail;
        public string Fabtype { get; set; }
        public string Potype { get; set; }
        public static string FabtypeETA { get; set; }
        public static string FabricQuanlityName { get; set; }
        public static int MasterPoIDETA { get; set; }
        public string Userid { get; set; }
        public int FabricQualityID { get; set; }
        public string ParentPageUrlWithQuerystring { get; set; }
        public string RemaningQty { get; set; }
        public static int SupplierMasterID { get; set; }
        public int MasterPoID { get; set; }
        public string PoNumber { get; set; }
        public static string PoNumberETA { get; set; }
        public string ReceiveQty { get; set; }
        public string gerige { get; set; }
        public string residual { get; set; }
        public string cutwastage { get; set; }
        public int Count { get; set; }
        public string LogedInDesignation
        {
            get
            {
                if (!string.IsNullOrEmpty(ApplicationHelper.LoggedInUser.UserData.UserID.ToString()))
                {
                    return ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
                }

                return "";
            }
        }
        public string UserName
        {
            get
            {
                if (!string.IsNullOrEmpty(ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName))
                {
                    return ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName;
                }

                return "";
            }
        }
        public string TodayDate { get { return DateTime.Today.ToString("dd MMM yy"); } }
        public int currentstage { get; set; }
        public int previousstage { get; set; }
        public bool isStyleSpecific { get; set; }
        public int styleid { get; set; }
        public int Stage1 { get; set; }
        public int Stage2 { get; set; }
        public int Stage3 { get; set; }
        public int Stage4 { get; set; }
        public string serialNumber { get; set; }

        public void getquerystring()
        {
            if (Request.QueryString["Fabtype"] != null)
            {
                Fabtype = Request.QueryString["Fabtype"].ToString();
                FabtypeETA = Request.QueryString["Fabtype"].ToString();

                hdnSupplyType.Value = Request.QueryString["Fabtype"].ToString();

                if (Fabtype.ToUpper() == "FINISHED")
                {
                    Fabtype = "FINISHING";
                    FabtypeETA = "FINISHING";
                }

                Session["CallBackTab"] = Request.QueryString["Fabtype"].ToString();
                Session["ISCALLBACK"] = "YES";
            }
            else
            {
                Fabtype = "";
            }
            if (Request.QueryString["FabricQualityID"] != null)
            {
                FabricQualityID = Convert.ToInt32(Request.QueryString["FabricQualityID"].ToString());
            }
            if (Request.QueryString["serialNumber"] != null)
            {
                serialNumber = Request.QueryString["serialNumber"].ToString();
            }
            if (Request.QueryString["Potype"] != null)
            {
                Potype = Request.QueryString["Potype"].ToString();

            }
            if (Request.QueryString["ParentPageUrlWithQuerystring"] != null)
            {
                ParentPageUrlWithQuerystring = Request.QueryString["ParentPageUrlWithQuerystring"].ToString();
            }
            if (Request.QueryString["SupplierMasterID"] != null)
            {
                if (Request.QueryString["SupplierMasterID"].ToString() != "")
                    SupplierMasterID = Convert.ToInt32(Request.QueryString["SupplierMasterID"].ToString());
            }
            if (Request.QueryString["MasterPoID"] != null)
            {
                if (Request.QueryString["MasterPoID"].ToString() != "")
                {
                    MasterPoID = Convert.ToInt32(Request.QueryString["MasterPoID"].ToString());
                    MasterPoIDETA = Convert.ToInt32(Request.QueryString["MasterPoID"].ToString());
                }
            }
            if (Request.QueryString["colorprintdetail"] != null)
            {
                if (Request.QueryString["colorprintdetail"].ToString() != "undefined")
                {
                    colorprintdetail = Request.QueryString["colorprintdetail"].ToString();
                }
            }
            if (Request.QueryString["gerige"] != null)
            {
                gerige = Request.QueryString["gerige"].ToString();
            }
            if (Request.QueryString["residual"] != null)
            {
                residual = Request.QueryString["residual"].ToString();
            }
            if (Request.QueryString["gerige"] != null)
            {
                cutwastage = Request.QueryString["cutwastage"].ToString();

            }
            if (Request.QueryString["currentstage"] != null)
            {
                currentstage = Convert.ToInt32(Request.QueryString["currentstage"].ToString());
                hdncurrentstage.Value = Request.QueryString["currentstage"].ToString();

            }
            if (Request.QueryString["previousstage"] != null)
            {
                previousstage = Convert.ToInt32(Request.QueryString["previousstage"].ToString());

            }
            if (Request.QueryString["isStyleSpecific"] != null)
            {
                isStyleSpecific = Convert.ToBoolean(Request.QueryString["isStyleSpecific"].ToString() == "1" ? true : false);
            }
            if (Request.QueryString["styleid"] != null)
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());

            }
            if (!string.IsNullOrEmpty(Request.QueryString["Stage1"]))
            {

                if (Request.QueryString["Stage1"].ToString() != "undefined")
                    Stage1 = Convert.ToInt32(Request.QueryString["Stage1"].ToString());

            }
            if (!string.IsNullOrEmpty(Request.QueryString["Stage2"]))
            {
                if (Request.QueryString["Stage2"].ToString() != "undefined")
                    Stage2 = Convert.ToInt32(Request.QueryString["Stage2"].ToString());

            }
            if (!string.IsNullOrEmpty(Request.QueryString["Stage3"]))
            {
                if (Request.QueryString["Stage3"].ToString() != "undefined")
                    Stage3 = Convert.ToInt32(Request.QueryString["Stage3"].ToString());

            }
            if (!string.IsNullOrEmpty(Request.QueryString["Stage4"]))
            {
                if (Request.QueryString["Stage4"].ToString() != "undefined")
                    Stage4 = Convert.ToInt32(Request.QueryString["Stage4"].ToString());
            }
        }
        int FabTypes = 0;
        public static string JuniorName { get; set; }
        public static string JuniorPhoto { get; set; }
        public static string AuthName { get; set; }
        public static string AuthPhoto { get; set; }
        public static string ApproName { get; set; }
        public static string ApproPhoto { get; set; }

        public string hdnSessionQ { get; set; }


        string host = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            host = "http://" + Request.Url.Authority;
            Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            getquerystring();           

            if (!Page.IsPostBack)
            {            

                txtETADate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                Session["qtyrange"] = null;
                txtPoDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                //    txtetadateSupplier.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                //new code start
                DataTable dt = fabobj.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
                //new code end              


                getwastage();
                BindPageFabrictype();
                BindRemarks();
                BindTop3FabricSupplier();
                BindQtyRangeGrd();
                if (ParentPageUrlWithQuerystring == "SuPPLIERVIEW")
                {
                    grdqtyrange.Columns[3].Visible = false;

                }
                Session["FabTypes"] = null;
                //if (ParentPageUrlWithQuerystring == "SuPPLIERVIEW")
                //{            
                //    chkAuthorizedSignatory.Enabled = false;
                //}
                //else
                //{
                //    chkpartysignature.Visible = false;
                //}


                if (JuniorDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    chkJuniorSignatory.Attributes.Remove("disabled");
                    chkJuniorSignatory.Enabled = true;
                    chkAuthorizedSignatory.Visible = false;
                }
                else
                {
                    if (AuthorizedDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                    {
                        chkAuthorizedSignatory.Attributes.Remove("disabled");
                        chkAuthorizedSignatory.Enabled = true;
                    }
                }


                Session["q"] = Request.QueryString.ToString() + "&FabricQuality=" + FabricQuanlityName;
                hdnSessionQ = Request.QueryString.ToString() + "&FabricQuality=" + FabricQuanlityName;
            }
            else
            {
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "SubmitFabricOrderForm", "SubmitFabricOrderForm()", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SubmitFabricOrderForm", "SubmitFabricOrderForm()", true);
            }
            //randorHtml();




        }
        public void binds()
        {
            getquerystring();
            BindPageFabrictype();
            //BindTop3FabricSupplier();
            //BindQtyRangeGrd();
        }
        public static Boolean ToBoolean(string str)
        {
            String cleanValue = (str ?? "").Trim();
            if (String.Equals(cleanValue, "False", StringComparison.OrdinalIgnoreCase))
                return false;
            return
                (String.Equals(cleanValue, "True", StringComparison.OrdinalIgnoreCase)) ||
                (cleanValue != "0");
        }
        public void getwastage()
        {
            decimal g_sh = 0;
            decimal r_sh = 0;


            if (Fabtype.ToUpper() == "GRIEGE".ToUpper()) { FabTypes = 1; }
            else if (Fabtype.ToUpper() == "FINISHING".ToUpper()) { FabTypes = 10; }
            else if (Fabtype.ToUpper() == "DYED".ToUpper()) { FabTypes = 2; }
            else if (Fabtype.ToUpper() == "RFD".ToUpper()) { FabTypes = 29; }
            else if (Fabtype.ToUpper() == "Embellishment".ToUpper()) { FabTypes = 30; }
            else if (Fabtype.ToUpper() == "Embroidery".ToUpper()) { FabTypes = 31; }
            else if (Fabtype.ToUpper() == "PRINT".ToUpper()) { FabTypes = 3; }

            DataTable dt = null;
            if (Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embroidery")
            {
                dt = fabobj.GetFabricPrintWastageDetails(Enum.GetName(typeof(FabricProcessTypes), FabTypes), "GET", FabricQualityID, colorprintdetail, currentstage, previousstage, isStyleSpecific, styleid, Stage1, Stage2, Stage3, Stage4);
                if (dt.Rows.Count > 0)
                {
                    if (Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Dyed")
                    {
                        r_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage" + currentstage + "_Shrinkage])", string.Empty));
                        g_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage1_Wastage])", string.Empty));
                    }
                    else if (Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embroidery")
                    {
                        if ((Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "RFD"))
                        {
                           
                            if (currentstage == 1)
                            {
                                g_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage" + currentstage + "_Shrinkage])", string.Empty));
                            }
                            else
                            {
                                r_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage" + currentstage + "_Wastage])", string.Empty));
                                g_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage1_Wastage])", string.Empty));
                            }
                            g_sh = Stage1 == 29 ? 0 : g_sh;
                        }
                        else
                        {
                            g_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage" + currentstage + "_Wastage])", string.Empty));
                        }
                    }
                }
            }
            else
            {
                dt = fabobj.GetFabricWastageDetails(Enum.GetName(typeof(FabricProcessTypes), FabTypes), "GET", FabricQualityID, colorprintdetail);
                if (dt.Rows.Count > 0)
                {
                    if (Fabtype == "GRIEGE")
                    {
                        g_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage1_Wastage])", string.Empty)); 

                    }
                    else if (Fabtype == "FINISHING")
                    {
                        r_sh = 0;//Convert.ToDecimal(dt.Compute("min([Stage" + 1 + "_Shrinkage])", string.Empty));
                    }
                }
            }
            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            string strdec = r_sh.ToString(CultureInfo.CurrentCulture);
            residual = strdec.Contains(sep) ? strdec.TrimEnd('0').TrimEnd(sep.ToCharArray()) : strdec;

            strdec = g_sh.ToString(CultureInfo.CurrentCulture);
            gerige = strdec.Contains(sep) ? strdec.TrimEnd('0').TrimEnd(sep.ToCharArray()) : strdec;

        }
        public string pagehtml
        {
            get;
            set;

        }
        public void BindRemarks()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (lblPoNo.Text.Trim() != "")
            {

                ds = fabobj.PopulateRemarks(lblPoNo.Text.Trim());
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CommentRemarks"].ToString()))
                    {
                        comment.InnerText = dt.Rows[0]["CommentRemarks"].ToString();
                        hdnOldremak.Value = dt.Rows[0]["CommentRemarks"].ToString();
                    }
                }
            }
            else
            {
                comment.InnerText = "";
            }

        }
        public void BindPageFabrictype()
        {
            String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (Fabtype.ToLower() == "RFD".ToLower())
            {
                if (isStyleSpecific == false) { styleid = -1; }

                ds = fabobj.GetFabricpurchasedSupplierRFD(Fabtype, "GET", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID, colorprintdetail, currentstage, previousstage, styleid, isStyleSpecific, Stage1, Stage2, Stage3, Stage4);
                dt = ds.Tables[0];

            }
            else
            {
                ds = fabobj.GetFabricpurchasedSupplier(Fabtype, "GET", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID, colorprintdetail, currentstage, previousstage, styleid, isStyleSpecific, Stage1, Stage2, Stage3, Stage4);
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                string updateProgress = "REOPEN";
                //ClientScript.RegisterStartupScript(this.GetType(), "ConversionValueChange", "ConversionValueChange('" + updateProgress + "');", true);

                //if (Fabtype.ToLower() == "GRIEGE".ToLower())
                //{
                //    gerige = dt.Rows[0]["Greige_Sh"].ToString();
                //    if (ToBoolean(dt.Rows[0]["IsResidualShrinkaage"].ToString()) == true)
                //        residual = dt.Rows[0]["ResidualShrinkaage"].ToString();
                //    else
                //        residual = "";
                //}
                //else
                //{
                //    gerige = dt.Rows[0]["Greige_Sh"].ToString();


                //    residual = dt.Rows[0]["ResidualShrinkaage"].ToString();
                //}
                lblClientcode.Text = dt.Rows[0]["ClintCode"].ToString();               
                //RajeevS 10022023
                string HSNCode = dt.Rows[0]["HSNCode"].ToString();
                if (HSNCode == "")
                {
                    spn_HSNCode.InnerHtml = "";
                    lblHSNCode.Visible = false;
                }
                else
                {
                    lblHSNCode.Visible = true;
                    lblHSNCode.Text = HSNCode;
                    spn_HSNCode.InnerHtml = "HSNCode";
                }
                //RajeevS 10022023 
                hdnFabricQuality.Value = dt.Rows[0]["TradeName"].ToString();
                int val = dt.Rows[0]["RateType"] == DBNull.Value || dt.Rows[0]["RateType"] == "0" ? 0 : Convert.ToInt32(dt.Rows[0]["RateType"]);
                foreach (System.Web.UI.WebControls.ListItem li in rdybtnListRateType.Items)
                {
                    if (val == 1 && li.Text=="Landed")
                    {
                        li.Selected = true;
                    }
                    else if (val == 2 && li.Text == "Ex-Mill")
                    {

                        li.Selected = true;

                    }

                }
                grdfabricpurchased.DataSource = dt;
                grdfabricpurchased.DataBind();
                hdnconversionvalue.Value = dt.Rows[0]["ConversionValue"].ToString();

                if (dt.Rows[0]["IsJuniorSignatory"].ToString() != "")
                {
                    chkJuniorSignatory.Checked = Convert.ToBoolean(dt.Rows[0]["IsJuniorSignatory"].ToString());
                }
                if (chkJuniorSignatory.Checked)
                {
                    chkJuniorSignatory.Attributes.Add("style", "display:none");
                    spanJuniorSig.Visible = false;
                    if (dt.Rows[0]["JuniorSignatoryApprovedOn"].ToString() != "")
                    {
                        lblJuniorSignatorydate.Text = Convert.ToDateTime(dt.Rows[0]["JuniorSignatoryApprovedOn"]).ToString("dd MMM yy (ddd)");
                    }
                }
                else
                {
                    chkJuniorSignatory.Attributes.Remove("style");
                    spanJuniorSig.Visible = true;
                    imgJuniorSignatory.Attributes.Add("style", "display:none");
                }

                if (Convert.ToInt32(dt.Rows[0]["JuniorSignatoryId"]) > 0)
                {
                    var user = ApplicationHelper.Users.Where(x => x.UserID == Convert.ToInt32(dt.Rows[0]["JuniorSignatoryId"])).FirstOrDefault();
                    if (user != null)
                    {
                        lblJuniorName.Text = user.FirstName + " " + user.LastName;
                        imgJuniorSignatory.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";

                        JuniorName = lblJuniorName.Text;
                        JuniorPhoto = user.SignPath != string.Empty ? user.SignPath : "NotSign.jpg";
                    }
                }

                if (dt.Rows[0]["IsAuthorizedSignatory"].ToString() != "")
                {
                    chkAuthorizedSignatory.Checked = Convert.ToBoolean(dt.Rows[0]["IsAuthorizedSignatory"].ToString());
                    if (chkAuthorizedSignatory.Checked)
                    {
                        chkAuthorizedSignatory.Attributes.Add("style", "display:none");
                        spanAuthorizedSig.Visible = false;
                        imgAuthorizedSignatory.Attributes.Remove("");
                        if (dt.Rows[0]["AuthorizedApprovedOn"].ToString() != "")
                        {
                            lblAuthorizedSignatorydate.Text = Convert.ToDateTime(dt.Rows[0]["AuthorizedApprovedOn"]).ToString("dd MMM yy (ddd)");
                        }
                    }
                    else
                    {
                        chkAuthorizedSignatory.Attributes.Remove("");
                        spanAuthorizedSig.Visible = true;
                        imgAuthorizedSignatory.Attributes.Add("style", "display:none");
                    }
                }
                else
                {
                    chkAuthorizedSignatory.Attributes.Remove("");
                    imgAuthorizedSignatory.Attributes.Add("style", "display:none");
                }
                if (Convert.ToInt32(dt.Rows[0]["AuthorizedId"]) > 0)
                {
                    var user = ApplicationHelper.Users.Where(x => x.UserID == Convert.ToInt32(dt.Rows[0]["AuthorizedId"])).FirstOrDefault();
                    if (user != null)
                    {
                        lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                        imgAuthorizedSignatory.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";

                        ApproName = lblAuthorizedName.Text;
                        ApproPhoto = user.SignPath != string.Empty ? user.SignPath : "NotSign.jpg";
                    }
                }


                if (dt.Rows[0]["IsPartySignature"].ToString() != "")
                {
                    chkpartysignature.Checked = Convert.ToBoolean(dt.Rows[0]["IsPartySignature"].ToString());
                }
                if (chkpartysignature.Checked)
                {
                    chkpartysignature.Attributes.Add("style", "display:none");
                    PositonRightM.Visible = false;
                    if (dt.Rows[0]["PartySignatureApprovedOn"].ToString() != "")
                    {
                        lblimgpartysingature.Text = Convert.ToDateTime(dt.Rows[0]["PartySignatureApprovedOn"]).ToString("dd MMM yy (ddd)");
                    }
                }
                else
                {
                    chkpartysignature.Attributes.Remove("style");
                    PositonRightM.Visible = true;
                    imgpartysingature.Attributes.Add("style", "display:none");
                }
                if (Convert.ToInt32(dt.Rows[0]["PartyId"]) > 0)
                {
                    var user = ApplicationHelper.Users.Where(x => x.UserID == Convert.ToInt32(dt.Rows[0]["PartyId"])).FirstOrDefault();
                    if (user != null)
                    {
                        lblPartyName.Text = user.FirstName + " " + user.LastName;
                        if (user.DesignationID != 160)
                        {
                            lblPartyName.Text += "<br />" + "<span style=font-size:9px> ( On behalf of " + dt.Rows[0]["SupplierName"].ToString() + ")</span>";
                        }
                        imgpartysingature.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";

                        AuthName = lblPartyName.Text;
                        AuthPhoto = user.SignPath != string.Empty ? user.SignPath : "NotSign.jpg";
                    }
                }


                if ((dt.Rows[0]["PendingQtyToOrder"]).ToString() != "")
                {
                    RemaningQty = Convert.ToDecimal(dt.Rows[0]["PendingQtyToOrder"]).ToString("N0");
                }
                lblPoNo.Text = dt.Rows[0]["POnumber"].ToString();
                PoNumberETA = dt.Rows[0]["POnumber"].ToString();

                //lblh.Text = dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                lblh.Text = dt.Rows[0]["TextHistory"].ToString().Replace("###", ""); ;
                PoNumber = dt.Rows[0]["POnumber"].ToString();
                if (Potype.ToUpper() == "RERAISE")
                {
                    if (dt.Rows[0]["PODate"].ToString() != "")
                    {
                        txtPoDate.Text = Convert.ToDateTime(dt.Rows[0]["PODate"]).ToString("dd MMM yy (ddd)");

                    }
                    if (dt.Rows[0]["ETADATE"].ToString() != "")
                    {
                        txtETADate.Text = Convert.ToDateTime(dt.Rows[0]["ETADATE"]).ToString("dd MMM yy (ddd)");
                    }
                    if (dt.Rows[0]["supplier_master_Id"].ToString() != "")
                    {
                        ddlSupplierName.SelectedValue = dt.Rows[0]["supplier_master_Id"].ToString();
                        SupplierMasterID = Convert.ToInt32(dt.Rows[0]["supplier_master_Id"].ToString());
                    }

                    //  txtPoDate.Enabled = false;
                    //txtETADate.Enabled = false;

                }
                else if (Potype.ToUpper() == "RAISE")
                {
                    txtPoDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                    //txtETADate.Text =  DateTime.Today.ToString("dd MMM yy (ddd)");
                    //ddlSupplierName.SelectedValue = "-1";
                    // chkpartysignature.Visible = false;

                }
            }
            BindSupplierETAGrd();
            BindQtyRangeGrd();

            PoNumberETA = hdintialsuppliercode.Value;
        }
        public void BindSupplierETAGrd()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dthistory = new DataTable();

            if (Fabtype.ToLower() == "RFD".ToLower())
            {

                if (isStyleSpecific == false)
                {
                    styleid = -1;
                }

                ds = fabobj.GetFabricpurchasedSupplierRFD(Fabtype, "GETPOSUPPLIERETA", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID, colorprintdetail, currentstage, previousstage, styleid);
                dt = ds.Tables[0];
                dthistory = ds.Tables[2];

            }
            else
            {
                ds = fabobj.GetFabricpurchasedSupplier(Fabtype, "GETPOSUPPLIERETA", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID, colorprintdetail, currentstage, previousstage, styleid);
                dt = ds.Tables[0];
                dthistory = ds.Tables[2];
            }

            if (dt.Rows.Count == 0)
            {
                //If no records then add a dummy row.
                dt.Rows.Add();
            }

            gvqtyrange.DataSource = dt;
            gvqtyrange.DataBind();

            if (dthistory.Rows.Count > 0)
            {
                if (Fabtype.ToLower() == "GRIEGE".ToLower())
                {
                    grdReceiveQtyHistory.DataSource = dthistory;
                    grdReceiveQtyHistory.DataBind();
                }

                else if (Fabtype.ToLower() == "FINISHING".ToLower())
                {
                    grdReceiveQtyHistory.DataSource = dthistory;
                    grdReceiveQtyHistory.DataBind();
                }

                else if (Fabtype.ToLower() == "DYED".ToLower() || Fabtype.ToLower() == "PRINT".ToLower() || Fabtype.ToLower() == "Embellishment".ToLower() || Fabtype.ToLower() == "Embroidery".ToLower() || (Fabtype.ToLower() == "RFD".ToLower() && currentstage != 1))
                {
                    grdhistorysend.DataSource = dthistory;
                    grdhistorysend.DataBind();
                }
                else if (Fabtype.ToLower() == "RFD".ToLower() && currentstage == 1)
                {
                    grdReceiveQtyHistory.DataSource = dthistory;
                    grdReceiveQtyHistory.DataBind();
                }
            }
            divguidline.InnerHtml = ds.Tables[1].Rows[0]["value"].ToString();
        }
        public void BindTop3FabricSupplier()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string flagoption = "";
            if (Fabtype.ToLower() == "FINISHING".ToLower())
            {
                flagoption = "GETTOP3SUPPLIER_FINISH";
            }
            else if (Fabtype.ToLower() == "GRIEGE".ToLower())
            {
                flagoption = "GETTOP3SUPPLIER_GRIGE";
            }
            else if (Fabtype.ToLower() == "DYED".ToLower())
            {
                if (isStyleSpecific == false)
                {
                    flagoption = "GETTOP3SUPPLIER_DAYEDNONSTYLE";
                }
                else if (isStyleSpecific == true)
                {
                    flagoption = "GETTOP3SUPPLIER_DAYEDSTYLE";
                }
            }
            else if (Fabtype.ToLower() == "PRINT".ToLower())
            {
                if (isStyleSpecific == false)
                {
                    flagoption = "GETTOP3SUPPLIER_PRINTNONSTYLE";
                }
                else if (isStyleSpecific == true)
                {
                    flagoption = "GETTOP3SUPPLIER_PRINTSTYLE";
                }
            }
            else if (Fabtype.ToLower() == "RFD".ToLower())
            {
                if (isStyleSpecific == false)
                {
                    flagoption = "GETTOP3SUPPLIER_RFDNONSTYLE";
                }
                else if (isStyleSpecific == true)
                {
                    flagoption = "GETTOP3SUPPLIER_RFDSTYLE";
                }
            }
            else if (Fabtype.ToLower() == "Embellishment".ToLower())
            {
                if (isStyleSpecific == false)
                {
                    flagoption = "GETTOP3SUPPLIER_EmbellishmentNONSTYLE";
                }
                else if (isStyleSpecific == true)
                {
                    flagoption = "GETTOP3SUPPLIER_EmbellishmentSTYLE";
                }
            }
            else if (Fabtype.ToLower() == "Embroidery".ToLower())
            {
                if (isStyleSpecific == false)
                {
                    flagoption = "GETTOP3SUPPLIER_EmbroideryNONSTYLE";
                }
                else if (isStyleSpecific == true)
                {
                    flagoption = "GETTOP3SUPPLIER_EmbroiderySTYLE";
                }
            }
            //ds = fabobj.GetfabricViewdetails(Fabtype, flagoption, FabricQualityID, 100, colorprintdetail);
            //dt = ds.Tables[0];
            //if (dt.Rows.Count <= 0)
            //{
            //    dt = ds.Tables[1];
            //}
            ds = fabobj.GetfabricViewdetails(Fabtype, flagoption, FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, (isStyleSpecific == false ? -1 : styleid), Stage1, Stage2, Stage3, Stage4);
            dt = ds.Tables[0];

            if (MasterPoID > 0 && chkpartysignature.Checked == true && chkAuthorizedSignatory.Checked == true)
            {
                ds = fabobj.GetfabricViewdetails("PO_SUPPLIERDETAILS", flagoption, FabricQualityID, 100, colorprintdetail, "", MasterPoID, currentstage, previousstage, isStyleSpecific, (isStyleSpecific == false ? -1 : styleid), Stage1, Stage2, Stage3, Stage4);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["SupplierName2"].ToString() != "")
                    {
                        
                        dt = ds.Tables[0];
                        
                    }
                }

            }

            if (dt.Rows.Count <= 0)
            {
                dt = ds.Tables[1];
             //   ddlSupplierName.Enabled = false;
                Count = 1;

               // since there is no supplier is selected in ddlSupplierName 
            }

            if (dt.Rows.Count > 0)
            {
              //  int count = 0;
                ddlSupplierName.DataSource = dt;

                ddlSupplierName.DataValueField = "Supplier_master_ID";
                ddlSupplierName.DataTextField = "SupplierName2";

                ddlSupplierName.DataBind();

                foreach (DataRow  dr in dt.Rows)
                {
                    foreach (System.Web.UI.WebControls.ListItem item in ddlSupplierName.Items)
                    {
                        if (item.Value == "-1")
                            continue;
                        if (dr["ISQuoted"].ToString() == "0" && dt.Rows.IndexOf(dr) ==(ddlSupplierName.Items.IndexOf(item)-1))
                        {
                            item.Attributes.Add("class", "ddlisNotQuoted");
                          
                            //count = count + 1;
                            //break;
                            
                        }
                        else
                        {
                            //item.Attributes.Add("class", "ddlisQuoted");
                        }
                    }
                }
            }
        }

        protected void grdfabricpurchased_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();
                HeaderCell = new TableCell();
                HeaderCell.Text = "Fabric Quality";
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "C&C";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ColorPrint";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);             


                HeaderCell = new TableCell();          
                string Hedrca = "";
                if (Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embroidery")
                    Hedrca = "Wastage";
                else
                    Hedrca = "G.Sh.";

                HeaderCell.Text = "<table style='width:100%;height:100%;' border='0' cellspacing='0' cellpadding='0'><tr><td class='colwidthG'>" + Hedrca + "</td><td class='colwidthG' style='border-right:0px'>R.Sh.<br></td></tr></table>";

                HeaderCell.Style.Add("Width", "100px");
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fabric Type";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity" + "<span style='color: red; font-size: 12px;'>*</span>"; ;
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.ColumnSpan = 3;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Finance" + "<span style='color: red; font-size: 12px;'>*</span>";
                HeaderCell.Style.Add("Width", "70px");
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                //row 2 
                HeaderCell = new TableCell();
                HeaderCell.Text = "Send";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "70px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Receivable";
                HeaderCell.Style.Add("Width", "70px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Unit";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rate";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "90px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Amount";
                HeaderCell.Style.Add("Width", "100px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdfabricpurchased.Controls[0].Controls.AddAt(0, headerRow2);
                grdfabricpurchased.Controls[0].Controls.AddAt(0, headerRow1);

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnSupplierMasterID = (HiddenField)e.Row.FindControl("hdnSupplierMasterID");
                DropDownList ddlSupplytype = (DropDownList)e.Row.FindControl("ddlSupplytype");
                TextBox txtsendQty = (TextBox)e.Row.FindControl("txtsendQty");
                TextBox txtreceivedqty = (TextBox)e.Row.FindControl("txtreceivedqty");
                TextBox txtrateSupplierQuotedRate = (TextBox)e.Row.FindControl("txtrateSupplierQuotedRate");
                Label lbltotalAmount = (Label)e.Row.FindControl("lbltotalAmount");
                Label Label1 = (Label)e.Row.FindControl("Label1");
                Label lblcolorprint = (Label)e.Row.FindControl("lblcolorprint");
                HiddenField hdnsendqty = (HiddenField)e.Row.FindControl("hdnsendqty");
                HiddenField hdngerigeshrnk = (HiddenField)e.Row.FindControl("hdngerigeshrnk");
                HiddenField hdnSendQtyValidate = (HiddenField)e.Row.FindControl("hdnSendQtyValidate");
                HiddenField hdnsaveconversionvalue = (HiddenField)e.Row.FindControl("hdnsaveconversionvalue");
                HtmlAnchor ansendtooltip = e.Row.FindControl("ansendtooltip") as HtmlAnchor;
                HtmlGenericControl spanx = e.Row.FindControl("spanmsgsendqty") as HtmlGenericControl;
                HtmlGenericControl spanx2 = e.Row.FindControl("spanmsgsendqtys") as HtmlGenericControl;
                HtmlAnchor anreceivetooltip = e.Row.FindControl("anreceivetooltip") as HtmlAnchor;
                Label lblGreige = (Label)e.Row.FindControl("lblGreige");
                hdnminsrv.Value = DataBinder.Eval(e.Row.DataItem, "Minsrvcehck").ToString();
                Label lblResdualSh = (Label)e.Row.FindControl("lblResdualSh");
                Label lblCutWes = (Label)e.Row.FindControl("lblCutWes");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                HiddenField hdnremainingQty = (HiddenField)e.Row.FindControl("hdnremainingQty");
                FabricQuanlityName = DataBinder.Eval(e.Row.DataItem, "TradeName").ToString();
                lblunitto.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Converttounit").ToString()));
                lblunitfrom.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Converttounit").ToString()));

                hdnsaveconversionvalue.Value = (hdnsaveconversionvalue.Value == "" ? "1" : hdnsaveconversionvalue.Value);
                if (!string.IsNullOrEmpty(colorprintdetail))
                    lblcolorprint.Text = colorprintdetail;

                StringBuilder sb = new StringBuilder();
                if (Potype.ToUpper() == "RERAISE")
                {

                    if (DataBinder.Eval(e.Row.DataItem, "GerigeShrinkageExists").ToString() != "0")
                    {
                        gerige = DataBinder.Eval(e.Row.DataItem, "GerigeShrinkageExists").ToString();
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "ResidualShrinkageExists").ToString() != "0")
                    {
                        residual = DataBinder.Eval(e.Row.DataItem, "ResidualShrinkageExists").ToString();
                    }
                }
                sb.Append("<table border='0' cellspacing='0' cellpadding='0' style='width:100%; height:100%'>");
                sb.Append("<tr>");
                if (Convert.ToInt32(gerige) != 0 && Fabtype.ToUpper() == "GRIEGE" || (Stage1==29 && Fabtype.ToUpper()=="RFD") )
                {
                    sb.Append("<td class='colwidthinnr gerige'style='display:none'> " + gerige + "</td>"); // b
                    lblgerigeshrinkage.Text = gerige;
                }
                else
                {
                    string val = gerige == "0" ? "" : gerige;
                    string val2 = gerige == "0" ? "" : gerige + "%";

                    sb.Append("<td class='colwidthinnr' style='display:block'>" + val2 + "</td>");
                    lblgerigeshrinkage.Text = val;
                }

                if (residual != "0")
                {
                    sb.Append("<td class='colwidthinnr residual hide' >" + residual + "</td>");
                    lblresidualshrinkage.Text = residual;
                }
                else
                {
                    sb.Append("<td class='colwidthinnr'>" + " " + "</td>");
                }

                if (cutwastage != "0")
                {
                    if (MasterPoID > 0)
                    {
                        hdncutwastage.Value = DataBinder.Eval(e.Row.DataItem, "cutwastage").ToString();
                    }
                    else
                    {
                        hdncutwastage.Value = cutwastage;
                    }

                }
                else
                {
                    hdncutwastage.Value = "0";

                }
                if (Fabtype.ToLower() == "PRINT".ToLower())
                {
                    ddlSupplytype.SelectedValue = "3";
                }
                else if (Fabtype.ToLower() == "RFD".ToLower())
                {
                    ddlSupplytype.SelectedValue = "29";

                }
                else if (Fabtype.ToLower() == "Embellishment".ToLower())
                {
                    ddlSupplytype.SelectedValue = "30";
                }
                else if (Fabtype.ToLower() == "Embroidery".ToLower())
                {
                    ddlSupplytype.SelectedValue = "31";
                }
                else if (Fabtype.ToLower() == "DYED".ToLower())
                {
                    ddlSupplytype.SelectedValue = "2";
                }
                else if (Fabtype.ToLower() == "GRIEGE".ToLower())
                {
                    ddlSupplytype.SelectedValue = "1";
                }
                else if (Fabtype.ToLower() == "FINISHING".ToLower())
                {
                    ddlSupplytype.SelectedValue = "10";
                }

                sb.Append("</tr>");
                sb.Append("</table>");
                //lblGreige.Text = sb.ToString();
                e.Row.Cells[5].Text = sb.ToString();

                DropDownList ddlunits = (DropDownList)e.Row.FindControl("ddlunits");
                ReceiveQty = (DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString() == "" ? "0" : DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString());
                if (Fabtype.ToLower() == "GRIEGE".ToLower() || Fabtype.ToLower() == "FINISHING".ToLower() || (Fabtype.ToLower() == "RFD".ToLower() && currentstage == 1))
                {
                    // ddlSupplytype.SelectedValue = "1";
                    ddlSupplytype.Enabled = false;
                    //txtsendQty.Enabled = false;
                    ansendtooltip.Attributes.Remove("class");

                    //  lblcolorprint.Text = "";

                    grdhistorysend.Visible = false;
                    grdReceiveQtyHistory.Visible = true;

                    if (DataBinder.Eval(e.Row.DataItem, "remainingQty").ToString() != "")
                    {
                        //if (Potype != "RAISE")
                        //{
                        //    spanx2.InnerText = "you cannot enter send quantity more than remaining qty " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "remainingQty").ToString()).ToString("N0");
                        //}
                        //else
                        //{
                        //    spanx2.InnerText = "you cannot enter send quantity more than remaining qty " + txtsendQty.Text;
                        //}
                    }
                    else
                    {
                        anreceivetooltip.Attributes.Remove("class");
                    }
                    txtreceivedqty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    hdnstorereceivedqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                }
                else// if (Fabtype.ToLower() != "FINISHING".ToLower() && Fabtype.ToLower() != "GRIEGE".ToLower() && Fabtype.ToLower() != "RFD".ToLower())
                {
                    txtsendQty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    hdnremainingQty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingQtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString();
                    hdnstoresendqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    hdnsendqty.Value = DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString();

                    hdnSendQtyValidate.Value = DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString();
                    txtsendQty.ToolTip = "Remaining Qty: " + DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString();
                    ansendtooltip.Attributes.Add("style", "Display:block");

                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingQtyToOrder").ToString()).ToString() != "")
                    {
                        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingQtyToOrder").ToString()) > 0)
                        {
                            if (Potype != "RAISE")
                            {
                                spanx.InnerText = "you cannot enter send quantity more than remaining qty " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingQtyToOrder").ToString()).ToString("N0");
                            }
                            else
                            {
                                spanx.InnerText = "you cannot enter send quantity more than remaining qty " + txtsendQty.Text;
                            }
                        }
                        else
                        {
                            ansendtooltip.Attributes.Remove("class");
                        }
                    }
                    else
                    {
                        ansendtooltip.Attributes.Remove("class");

                    }
                    txtsendQty.Enabled = true;
                    ddlSupplytype.Enabled = false;
                    txtreceivedqty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    hdnstorereceivedqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                }

                //if (lblgsm.Text != "")
                //{
                //    lblgsm.Text =  lblgsm.Text ;

                //}
                anreceivetooltip.Attributes.Remove("class");

                if (Potype.ToUpper() == "RERAISE")
                {
                    txtreceivedqty.Enabled = true;
                    ddlunits.Enabled = true;
                }
            //    txtrateSupplierQuotedRate.Text = ""; commented by shubhendu since NaN Value Comming 
            }
        }
        public void UpdateSplitOrderETA()
        {
            int IsAuthIsg = 0;
            int IsPartySign = 0;
            int IsJuniorSign = 0;

            string FabType = Fabtype;


            string potypes_ = "";
            if (Potype == "RERAISE")
            {
                potypes_ = "REVISEUPDATED";
            }
            else if (Potype == "RAISE")
            {
                potypes_ = "RAISEINSERT";
            }


            int SupplierNasterID = Convert.ToInt32(ddlSupplierName.SelectedValue);

            // int SendQty = 0,Po_ReceivedQty=0;
            //string Po_number = lblPoNo.Text;
            //DateTime Po_Date  =  DateTime.ParseExact(txtPoDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime Po_ETADate   = DateTime.ParseExact(txtETADate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            //// var Po_ReceivedQty = 0;
            //float gerige_ = (float)Convert.ToDecimal(lblgerigeshrinkage.Text == "" ? "0" : lblgerigeshrinkage.Text);
            //float residual_ = (float)Convert.ToDecimal(lblresidualshrinkage.Text == "" ? "0" : lblresidualshrinkage.Text);



            // DropDownList ddlunits = (DropDownList)grdfabricpurchased.Rows[0].FindControl("ddlunits");
            // HiddenField HdnConvertTounits = (HiddenField)grdfabricpurchased.Rows[0].FindControl("HdnConvertTounit");
            // HiddenField hdndefualtorderunits = (HiddenField)grdfabricpurchased.Rows[0].FindControl("hdndefualtorderunit");
            // HiddenField hdnconversionvalue = (HiddenField)grdfabricpurchased.Rows[0].FindControl("hdnconversionvalue");
            // TextBox txtsendQty = (TextBox)grdfabricpurchased.Rows[0].FindControl("txtsendQty");
            // TextBox txtreceivedqty = (TextBox)grdfabricpurchased.Rows[0].FindControl("txtreceivedqty");
            // TextBox txtrateSupplierQuotedRate = (TextBox)grdfabricpurchased.Rows[0].FindControl("txtrateSupplierQuotedRate");
            // int HdnConvertTounit = Convert.ToInt32(ddlunits.SelectedValue);
            // int select =Convert.ToInt32(ddlunits.SelectedValue);
            // int defualtorderUnit =Convert.ToInt32(hdndefualtorderunits.Value);
            // float conversionvalue = Convert.ToInt32(hdnconversionvalue.Value);
            // int garmentunits = Convert.ToInt32(hdndefualtorderunits.Value);
            // if (txtsendQty.Text.Replace(",", "") != "")
            // {
            //     SendQty = Convert.ToInt32(txtsendQty.Text.Replace(",", ""));
            // }
            //  if (txtreceivedqty.Text.Replace(",", "") != "")
            // {
            //     Po_ReceivedQty = Convert.ToInt32(txtreceivedqty.Text.Replace(",", ""));
            // }
            // decimal Po_SupplierQuotedRate = Convert.ToDecimal(txtrateSupplierQuotedRate.Text);

            // if (chkAuthorizedSignatory.Checked)
            // {
            //     IsAuthIsg = 1;
            // }
            // else
            // {
            //     IsAuthIsg = 0;
            // }
            // if (chkpartysignature.Checked)
            // {
            //     IsPartySign = 1;
            // }
            // else
            // {
            //     IsPartySign = 0;
            // }

            // if (HdnConvertTounit == defualtorderUnit) {
            //     conversionvalue = 1;
            // }
            // else {
            //     if (SendQty != 0) {
            //         SendQty  =  Convert.ToInt32(Math.Round(Convert.ToDecimal(SendQty) / Convert.ToDecimal(conversionvalue),0)); 
            //     }
            //     if (Po_ReceivedQty != 0) {
            //         Po_ReceivedQty = Convert.ToInt32(Math.Round(Convert.ToDecimal(Po_ReceivedQty) / Convert.ToDecimal(conversionvalue), 0)); 
            //     }
            // }         
            // string h = hdnhistory.Value;
            // bool s = fabobj.UpdateFabricPurchasedDetails(FabType, potypes_, FabricQualityID, SupplierNasterID, Po_number, Po_Date,  
            // Convert.ToInt32(Userid), Po_ReceivedQty, (float)Po_SupplierQuotedRate, Po_ETADate, garmentunits, SendQty, colorprintdetail, IsAuthIsg, IsPartySign, gerige_, residual_, currentstage, previousstage, isStyleSpecific,  styleid, Stage1, Stage2, Stage3, Stage4, HdnConvertTounit, conversionvalue, h, (float)Convert.ToDecimal(cutwastage)); 

            bool isdeletepoeta = fabobj.UpdateFabricPurchasedETA(FabtypeETA, "GETPOSUPPLIERETA_DELETE", DateTime.ParseExact(DateTime.Now.ToString(), "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture), ApplicationHelper.LoggedInUser.UserData.UserID, 1, 1, MasterPoIDETA, hdintialsuppliercode.Value, IsAuthIsg, IsPartySign, IsJuniorSign);

            string str = hdnetastring.Value;
            string[] t = str.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < t.Length; i++)
            {
                string[] t2 = t[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (t2[0] != null && t2[0].ToString() != "" && t2[1] != null && t2[1].ToString() != "")
                {
                    string f = t2[0].ToString();
                    string tq = t2[1].ToString();
                    string td = t2[2].ToString();

                    System.DateTime ETAdate_ = DateTime.ParseExact(td, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                    bool a = fabobj.UpdateFabricPurchasedETA(FabtypeETA, "GETPOSUPPLIERETA_INSERT", ETAdate_, ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(f.Replace(",", "")), Convert.ToInt32(tq.Replace(",", "")), MasterPoIDETA, hdintialsuppliercode.Value, IsAuthIsg, IsPartySign, IsJuniorSign);
                }
            }

            //for (int i = 0; i < 8; i++)
            //{

            //    TextBox txtfromqty = this.Master.FindControl("cph_main_content").FindControl("txtfromqty" + (i).ToString()) as TextBox;
            //    TextBox txttoqty = this.Master.FindControl("cph_main_content").FindControl("txttoqty" + (i).ToString()) as TextBox;

            //    Label lblfromqty = this.Master.FindControl("cph_main_content").FindControl("lblfromqty" + (i).ToString()) as Label;
            //    Label lbltoqty = this.Master.FindControl("cph_main_content").FindControl("lbltoqty" + (i).ToString()) as Label;

            //    TextBox txtetabreakedate = this.Master.FindControl("cph_main_content").FindControl("txtetabreakedate" + (i).ToString()) as TextBox;
            //    Label lbletabreakedate = this.Master.FindControl("cph_main_content").FindControl("lbletabreakedate" + (i).ToString()) as Label;

            //    if (txtfromqty != null && txtfromqty.Text != "" && txttoqty != null && txttoqty.Text!="")
            //    {                  
            //        System.DateTime ETAdate_ = DateTime.ParseExact(lbletabreakedate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            //        bool a = fabobj.UpdateFabricPurchasedETA(Fabtype, "GETPOSUPPLIERETA_INSERT", ETAdate_, ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(txtfromqty.Text.Replace(",", "")), Convert.ToInt32(lbltoqty.Text.Replace(",", "")), MasterPoID, lblPoNo.Text, IsAuthIsg, IsPartySign);
            //    }               
            //}
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            // ScriptManager.RegisterStartupScript(this, this.GetType(), "SubmitFabricOrderForm", "SubmitFabricOrderForm();", true);
            // UpdateSplitOrderETA();
            //randorHtml();
            Session["FabTypes"] = Fabtype;
            //Response.Redirect("FabricView.aspx");

            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hitback", "Hitback();", true);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            ////for (int i = 0; i < dt.Rows.Count; i++)
            ////{

            ////    TextBox txtfromqty = this.Master.FindControl("cph_main_content").FindControl("txtfromqty" + (i).ToString()) as TextBox;
            ////    TextBox txttoqty = this.Master.FindControl("cph_main_content").FindControl("txttoqty" + (i).ToString()) as TextBox;

            ////    Label lblfromqty = this.Master.FindControl("cph_main_content").FindControl("lblfromqty" + (i).ToString()) as Label;
            ////    Label lbltoqty = this.Master.FindControl("cph_main_content").FindControl("lbltoqty" + (i).ToString()) as Label;

            ////    TextBox txtetabreakedate = this.Master.FindControl("cph_main_content").FindControl("txtetabreakedate" + (i).ToString()) as TextBox;
            ////    Label lbletabreakedate = this.Master.FindControl("cph_main_content").FindControl("lbletabreakedate" + (i).ToString()) as Label;

            ////    if (txtfromqty != null && txttoqty != null)
            ////    {
            ////        txtfromqty.Text = dt.Rows[i]["FromQty"].ToString();
            ////        lblfromqty.Text = dt.Rows[i]["FromQty"].ToString();

            ////        txttoqty.Text = dt.Rows[i]["ToQty"].ToString();
            ////        lbltoqty.Text = dt.Rows[i]["ToQty"].ToString();

            ////        txtetabreakedate.Text = dt.Rows[i]["POETADate"].ToString();
            ////        lbletabreakedate.Text = dt.Rows[i]["POETADate"].ToString();
            ////    }


            ////}



        }
        protected void gvqtyrange_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.RowIndex == 0)
                {
                    e.Row.Attributes.Add("display", "none");

                }

                DataSet ds = fabobj.GetFabricpurchasedSupplier("GRIEGE", "GETPOSUPPLIERETA", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    e.Row.Cells[0].Controls.Add(new Literal { Text = "<input type='hidden' name='fromqtyval' value='" + dt.Rows[e.Row.RowIndex]["FromQty"].ToString() + "'>" });
                    e.Row.Cells[1].Controls.Add(new Literal { Text = "<input type='hidden' name='toqtyval' value='" + dt.Rows[e.Row.RowIndex]["ToQty"].ToString() + "'>" });
                    e.Row.Cells[2].Controls.Add(new Literal { Text = "<input type='hidden' name='Etadate' value='" + dt.Rows[e.Row.RowIndex]["POETADate"].ToString() + "'>" });
                    e.Row.Cells[3].Controls.Add(new Literal { Text = "<img name='deleteetarow' src='../../images/del-butt.png' alt=''  title='Delete' onclick='DeleteRow();return false;' />" });
                }

            }
        }
        public void BindQtyRangeGrd()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dthistory = new DataTable();
            //ds = fabobj.GetFabricpurchasedSupplier(Fabtype, "GET", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID, colorprintdetail);
            //dt = ds.Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    RemaningQty = Convert.ToDecimal(dt.Rows[0]["remainingQty"]).ToString("N0");
            //    lblPoNo.Text = dt.Rows[0]["POnumber"].ToString();
            //    hdintialsuppliercode.Value = dt.Rows[0]["POnumber"].ToString();
            //}
            if (Fabtype.ToLower() == "RFD".ToLower())
            {

                if (isStyleSpecific == false)
                {
                    styleid = -1;
                }

                ds = fabobj.GetFabricpurchasedSupplierRFD(Fabtype, "GETPOSUPPLIERETA", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID, colorprintdetail, currentstage, previousstage, styleid);
                dt = ds.Tables[0];


            }
            else
            {
                ds = fabobj.GetFabricpurchasedSupplier(Fabtype, "GETPOSUPPLIERETA", FabricQualityID, 0, Potype, SupplierMasterID, MasterPoID, colorprintdetail);
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count == 0)
            {
                if (Session["qtyrange"] != null)
                {
                    DataTable dts = (DataTable)Session["qtyrange"];

                    if (dts.Rows.Count > 0)
                    {
                        grdqtyrange.DataSource = dts;
                        grdqtyrange.DataBind();
                        Session["qtyrange"] = dts;
                    }
                }
                else
                {
                    dt.Rows.Add(new Object[] { dt.Rows.Count + 1, dt.Rows.Count + 1, MasterPoID, 1, Math.Round(Convert.ToDecimal(ReceiveQty)), txtETADate.Text.Trim() });
                    dt.AcceptChanges();
                    Session["qtyrange"] = dt;
                    dt.AcceptChanges();
                    grdqtyrange.DataSource = dt;
                    grdqtyrange.DataBind();
                }
            }
            else
            {
                if (Session["qtyrange"] != null)
                {
                    DataTable dts = (DataTable)Session["qtyrange"];
                    if (dts.Rows.Count > 0)
                    {
                        grdqtyrange.DataSource = dts;
                        grdqtyrange.DataBind();
                        Session["qtyrange"] = dts;
                    }
                }
                else
                {
                    grdqtyrange.DataSource = dt;
                    grdqtyrange.DataBind();
                    Session["qtyrange"] = dt;
                }

            }
            // dt.DefaultView.Sort = "FromQty asc";
            //         //dt = dt.DefaultView.ToTable();
            //          DataView dv = ft.DefaultView;
            //dv.Sort = "occr desc";
            //DataTable sortedDT = dv.ToTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                TextBox txtfromqty = this.Master.FindControl("cph_main_content").FindControl("txtfromqty" + (i).ToString()) as TextBox;
                TextBox txttoqty = this.Master.FindControl("cph_main_content").FindControl("txttoqty" + (i).ToString()) as TextBox;

                Label lblfromqty = this.Master.FindControl("cph_main_content").FindControl("lblfromqty" + (i).ToString()) as Label;
                Label lbltoqty = this.Master.FindControl("cph_main_content").FindControl("lbltoqty" + (i).ToString()) as Label;

                TextBox txtetabreakedate = this.Master.FindControl("cph_main_content").FindControl("txtetabreakedate" + (i).ToString()) as TextBox;
                Label lbletabreakedate = this.Master.FindControl("cph_main_content").FindControl("lbletabreakedate" + (i).ToString()) as Label;

                if (txtfromqty != null && txttoqty != null)
                {
                    txtfromqty.Text = dt.Rows[i]["FromQty"].ToString();
                    lblfromqty.Text = dt.Rows[i]["FromQty"].ToString();

                    txttoqty.Text = dt.Rows[i]["ToQty"].ToString();
                    lbltoqty.Text = dt.Rows[i]["ToQty"].ToString();

                    txtetabreakedate.Text = dt.Rows[i]["POETADate"].ToString();
                    lbletabreakedate.Text = dt.Rows[i]["POETADate"].ToString();
                }


            }
        }
        protected void grdqtyrange_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdqtyrange.EditIndex = e.NewEditIndex;

            BindQtyRangeGrd();

            GridViewRow Rows = grdqtyrange.Rows[e.NewEditIndex];

            TextBox txtdates = this.grdqtyrange.Rows[e.NewEditIndex].Controls[0].FindControl("txtdates") as TextBox;
            TextBox txtedittoqty = this.grdqtyrange.Rows[e.NewEditIndex].Controls[0].FindControl("txtedittoqty") as TextBox;
            hdntxtdates.Value = txtdates.Text;
            hdntoqty.Value = txtedittoqty.Text.Replace(",", "");
            if (grdqtyrange.Rows.Count == 1)
            {
                txtedittoqty.Text = hdnstorereceivedqty.Value.Replace(",", "");
                hdntoqty.Value = hdnstorereceivedqty.Value.Replace(",", "");
            }
            //string ss = txtETADate.Text;
            // ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>setbackviewstate();</script>", false);
        }
        [WebMethod]
        public static void SetSession(string sessionval)
        {
            HttpContext.Current.Session["qtyrange"] = null;
        }
        protected void grdqtyrange_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            getquerystring();
            binds();
            if (e.CommandName == "Edit")
            {
                //Bindgrd();
            }
            if (e.CommandName == "Insert")
            {
            }

        }
        public decimal FindDifference(decimal nr1, decimal nr2)
        {
            return Math.Abs(nr1 - nr2);
        }
        protected void grdqtyrange_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdqtyrange.EditIndex = -1;
            BindQtyRangeGrd();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>setbackviewstate();</script>", false);
        }
        protected void grdqtyrange_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdqtyrange.Rows[e.RowIndex];
            HiddenField hdnSupplierPO_ETA_Id = (HiddenField)row.FindControl("hdnSupplierPO_ETA_Id");

            if (Session["qtyrange"] != null)
            {
                DataTable dt = (DataTable)Session["qtyrange"];
                dt.DefaultView.Sort = "Row_Number ASC";

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["Row_Number"].ToString() == (e.RowIndex + 1).ToString())
                        dr.Delete();
                }
                dt.AcceptChanges();
                int _icheck = 1;
                foreach (DataRow dr in dt.Rows)
                {

                    dr["Row_Number"] = _icheck.ToString();
                    _icheck = _icheck + 1;
                    dt.AcceptChanges();
                }
                int _ToqtySet = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count == 1)
                    {
                        dt.Rows[0]["FromQty"] = 1;
                        dt.Rows[0]["ToQty"] = hdnstorereceivedqty.Value;
                        dt.Rows[0]["POETADate"] = hdnstoreetadate.Value;
                        dt.AcceptChanges();
                    }
                    else
                    {
                        _ToqtySet = Convert.ToInt32(dt.Rows[i]["ToQty"].ToString().Replace(",", ""));
                        for (int x = i + 1; x < dt.Rows.Count; x++)
                        {
                            dt.Rows[x]["FromQty"] = (_ToqtySet + 1).ToString();
                            dt.AcceptChanges();
                        }
                    }
                }
                Session["qtyrange"] = dt;
            }
            BindQtyRangeGrd();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>setbackviewstate();</script>", false);
        }

        protected void grdReceiveQtyHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblpoqty = (Label)e.Row.FindControl("lblpoqty");
                Label lnluntis = (Label)e.Row.FindControl("lnluntis");
                //lnluntis.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(SrvDetail.ConverToUnit));
                if (lblpoqty != null)
                {
                    if (hdnconversionvalue.Value == "")
                        hdnconversionvalue.Value = "0";
                    decimal f = Convert.ToDecimal(hdnconversionvalue.Value) <= 0 ? 1 : Convert.ToDecimal(hdnconversionvalue.Value);
                    lblpoqty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "POQuantity").ToString()) * Convert.ToDecimal(f)), 0).ToString("N0");
                }
                if (lblpoqty.Text == "0")
                {
                    e.Row.Visible = false;
                }

            }
        }

        protected void grdhistorysend_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblpoqty = (Label)e.Row.FindControl("lblpoqty");
                Label lnluntis = (Label)e.Row.FindControl("lnluntis");

                Label lblpoqtyre = (Label)e.Row.FindControl("lblpoqtyre");
                Label lnluntisre = (Label)e.Row.FindControl("lnluntisre");
                //lnluntis.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(SrvDetail.ConverToUnit));
                if (lblpoqty != null)
                {
                    if (hdnconversionvalue.Value == "")
                        hdnconversionvalue.Value = "0";
                    decimal f = Convert.ToDecimal(hdnconversionvalue.Value) <= 0 ? 1 : Convert.ToDecimal(hdnconversionvalue.Value);
                    if (lblpoqty.Text != "")
                    {
                        lblpoqty.Text = Math.Round((Convert.ToDecimal(lblpoqty.Text.Replace(",", "")) * Convert.ToDecimal(f)), 0).ToString("N0");
                    }
                    // lnluntis.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnstoreunitsid.Value));

                    if (lblpoqtyre.Text != "")
                    {
                        lblpoqtyre.Text = Math.Round((Convert.ToDecimal(lblpoqtyre.Text.Replace(",", "")) * Convert.ToDecimal(f)), 0).ToString("N0");
                    }
                    // lnluntisre.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnstoreunitsid.Value));
                    if (lblpoqty.Text == "0" && lblpoqtyre.Text == "0")
                    {
                        e.Row.Visible = false;
                    }
                }

            }
        }


        protected void grdqtyrange_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (lnkDelete != null)
                {
                    if (e.Row.RowIndex == 0)
                    {
                        lnkDelete.Visible = false;

                    }
                }

            }
        }
        protected void grdqtyrange_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string etadate = hdnstoreetadate.Value;
            GridViewRow Rows = grdqtyrange.Rows[e.RowIndex];
            TextBox txteditfromqty = Rows.FindControl("txteditfromqty") as TextBox;
            TextBox txtedittoqty = Rows.FindControl("txtedittoqty") as TextBox;
            TextBox txtdates = Rows.FindControl("txtdates") as TextBox;
            if (hdnstorereceivedqty.Value == "")
            {
                hdnstorereceivedqty.Value = "0";
            }
            if (hdntoqty.Value == "")
            {
                hdntoqty.Value = "0";
            }

            //HiddenField hdntxtdates = Rows.FindControl("hdntxtdates") as HiddenField;
            if (checkDates(hdntxtdates.Value) == false)
            {
                ShowAlert("Seleced Eta dates should be between po dates and eta dates");
                txtETADate.Text = hdnstoreetadate.Value;
                txtdates.Text = "";
                hdntxtdates.Value = "";
                //grdqtyrange.EditIndex = -1;
                if (grdqtyrange.Rows.Count == 1)
                {
                    txtedittoqty.Text = hdnstorereceivedqty.Value.Replace(",", "");
                }
                return;
            }
            HiddenField hdnsupplierpoid = Rows.FindControl("hdnsupplierpoid") as HiddenField;
            HiddenField hdnSupplierPO_ETA_Id = Rows.FindControl("hdnSupplierPO_ETA_Id") as HiddenField;
            HiddenField hdnrownumber = Rows.FindControl("hdnrownumber") as HiddenField;

            DataTable dtnew = (DataTable)(Session["qtyrange"]);
            dtnew.DefaultView.Sort = "Row_Number ASC";
            if (Convert.ToInt32(hdntoqty.Value.Replace(",", "")) > Convert.ToInt32(hdnstorereceivedqty.Value.Replace(",", "")))
            {
                ShowAlert("To quantity cannot be grether then total receive qty ");
                if (grdqtyrange.Rows.Count == 1)
                {
                    txtedittoqty.Text = hdnstorereceivedqty.Value.Replace(",", "");
                }
                return;
            }
            else
            {
                foreach (DataRow dr in dtnew.Rows)
                {
                    if (dr["Row_Number"].ToString() == hdnrownumber.Value)
                    {
                        dr["FromQty"] = txteditfromqty.Text.ToString().Trim();
                        dr["ToQty"] = hdntoqty.Value.Trim();
                        dr["POETADate"] = hdntxtdates.Value.Trim();
                        break;
                    }
                }
                var rows = dtnew.Select("Row_Number >" + hdnrownumber.Value);
                foreach (var row in rows)
                    row.Delete();

                dtnew.AcceptChanges();
                Session["qtyrange"] = dtnew;

                dtnew.AcceptChanges();
                grdqtyrange.EditIndex = -1;
                dtnew.DefaultView.Sort = "Row_Number ASC";
                if (Convert.ToDecimal(hdntoqty.Value.Replace(",", "")) != Convert.ToDecimal(hdnstorereceivedqty.Value.Replace(",", "")))
                {
                    if ((FindDifference(Convert.ToDecimal(hdntoqty.Value), Convert.ToDecimal(hdnstorereceivedqty.Value.Replace(",", "")))) < Convert.ToInt32(hdnstorereceivedqty.Value.Replace(",", "")))
                    {
                        dtnew.Rows.Add(new Object[] { dtnew.Rows.Count + 1, hdnSupplierPO_ETA_Id.Value, MasterPoID, Convert.ToDecimal(hdntoqty.Value.Replace(",", "")) + 1, hdnstorereceivedqty.Value.Replace(",", ""), hdnstoreetadate.Value.Trim() });
                        dtnew.AcceptChanges();
                        dtnew.DefaultView.Sort = "Row_Number ASC";
                    }
                }
                Session["qtyrange"] = dtnew;
                if (Session["qtyrange"] != null)
                {
                    BindQtyRangeGrd();
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>setbackviewstate();</script>", false);
        }
        public bool checkDates(string selecteddates)
        {
            bool res = true;
            DateTime selectes = DateTime.ParseExact(selecteddates, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            DateTime min = DateTime.ParseExact(hdnstorepodate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            DateTime max = DateTime.ParseExact(hdnstoreetadate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            if (selectes < min)
            {
                res = false;
            }
            if (selectes > max)
            {
                res = false;
            }
            return res;
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            BindQtyRangeGrd();
            // getquerystring();
            Session["qtyrange"] = null;
            // BindQtyRangeGrd();
        }
        #region "METHOD FOR SHOW ALERT"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        [WebMethod]
        public void Name()
        {
            Session["qtyrange"] = null;
        }
        #endregion
        //===============================================================================================Print area

        public void randorHtml()
        {
            string strHTML = "";
            string ss = host + "/../../FabricPurChasedFormPrint.aspx?" + Request.QueryString.ToString() + "&AuthName=" + AuthName + "&AuthPhoto=" + AuthPhoto + "&ApproName=" + ApproName + "&ApproPhoto=" + ApproPhoto + "&PoNumberPrint=" + hdintialsuppliercode.Value;
            //FabricQualityID=17&Fabtype=GRIEGE&Potype=RERAISE&MasterPoID=55&colorprintdetail=&gerige=3&residual=2&cutwastage=7&currentstage=0&previousstage=0&isStyleSpecific=0&styleid=0&stage1=1&stage2=3&stage3=31&stage4=30";
            Uri requestUri = null;
            Uri.TryCreate((ss), UriKind.Absolute, out requestUri);
            NetworkCredential nc = new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password);
            CredentialCache cache = new CredentialCache();
            cache.Add(requestUri, "Basic", nc);
            cache.Add(new Uri(ss), "NTLM", new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password));

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            request.Credentials = cache;

            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader respStream = new StreamReader(response.GetResponseStream());
            strHTML = respStream.ReadToEnd();
            genertaePdf(strHTML, "ss");


            string filename = "POFabric_view" + hdintialsuppliercode.Value + ".HTML";
            string strFileNameashtml = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
            //new System.IO.DirectoryInfo(@"C:\Temp").Delete(true);

            if ((File.Exists(strFileNameashtml)))
            {
                File.Delete(strFileNameashtml);
            }
            using (FileStream fs = File.Create(strFileNameashtml))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(strHTML);
                fs.Write(title, 0, title.Length);
            }
            if (rdoyes.Checked)
            {
                DataTable dtgrid = new DataTable();
                dtgrid = objadmin.GetSuppliarDetails(SupplierMasterID <= 0 ? Convert.ToInt32(hdnstoresupplierid.Value) : SupplierMasterID).Tables[0];
                if (dtgrid.Rows.Count > 0)
                {
                    DataRow dr = dtgrid.Select("IsUserlogin1 = " + "True").First();
                    string SupplierMailID = dr["Email"].ToString();

                    try
                    {
                        List<Attachment> atts = new List<Attachment>();
                        String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                        List<String> to = new List<String>();
                        NotificationController objcontroller = new NotificationController();
                        to.Add(SupplierMailID);
                        //to.Add("bipl_itsupport@boutique.in");
                        string name = "POFabric_" + hdintialsuppliercode.Value + ".pdf";
                        string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + name);
                        if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                        {

                            string FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                            atts.Add(new Attachment(FitsPath));
                        }

                        this.SendEmail(fromName, to, null, null, "Fabric PO (" + hdintialsuppliercode.Value + ")", name, atts, false, false);

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                    }


                }
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "alert('Mail sent')", true);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);

        }
        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            hdnFabricQuality.Value = hdnFabricQuality.Value.Contains('(') ? hdnFabricQuality.Value.Substring(0, hdnFabricQuality.Value.IndexOf('(')) : hdnFabricQuality.Value;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = Subject;
            //mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a Purchase Order " + hdintialsuppliercode.Value + " is raised against for  <span style='color:gray'>" + "Fabric Quality - " + hdnFabricQuality.Value + "</span> for stage  <span style='color:gray'> " + Fabtype.ToString() + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> <u>Disclaimer</u> : This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear<b style='font-size:14px;'> Supplier</b><br><br><b><span style='font-size:14px'>Greetings from BIPL.</span></b><br><br></span>We are pleased to confirm Purchase Order <b style='color:blue;font-weight:600;font-size:16px;'>" + hdintialsuppliercode.Value +"</b>, on <b style='color:blue;font-weight:600;font-size:16px;'>" + hdnFabricQuality.Value + "</b>for <b  style='color:blue;font-weight:600;font-size:16px;'>hdnstorereceivedqty +</b> @ <b style='color:green;font-weight:600;font-size:16px;'>" + hdnstorerate + "</b> with <b style='color:blue;font-weight:600;font-size:16px;'>" + hdntxtdates + "</b> with you. <br><span style='color:orange;'>Please read all instructions and details on PO and contact material team for any issues.</span><br><span style='color:grey;font-size:13px'>This is a system generated email so please don’t reply.</span><br><b>Thanks & Best Regards </b> <br><b>BIPL Team</b>";
            mailMessage.IsBodyHtml = true;

            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            //mailMessage.AlternateViews.Add(htmlView);

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
                        //htmlView.LinkedResources.Add(imageId);
                    }

                    i++;
                }
            }
            else
            {
                //mailMessage.Body = Subject;                
                mailMessage.Body = mailMessage.Body;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                mailMessage.CC.Add("itsupport@boutique.in");
                mailMessage.CC.Add("samrat@boutique.in");
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);

                if (CC != null)
                    foreach (String to in CC)
                        mailMessage.CC.Add(to);

                if (BCC != null)
                    foreach (String to in BCC)
                        mailMessage.Bcc.Add(to);


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                //mailmessage.bcc.add("bipl_fabric@boutique.in");
                mailMessage.Bcc.Add("bipl_fabric@boutique.in");// ADDED by shubhendu 8/02/2022


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
                // ShowAlert("Mail Sent successfully");
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
        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = "";
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }
        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string filename = "POFabric_" + hdintialsuppliercode.Value + ".pdf";
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {
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

        }
        public string getTitle(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
            string title = string.Empty;

            //get and remove Title in HTML..
            foreach (Match m1 in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline))
            {
                if (m1.Success)
                {
                    string tempM = m1.Value;
                    try
                    {
                        //tempM = tempM.Remove(m1.Index, m1.Length);
                        tempM = tempM.Replace(m1.Value, title);

                        //insert new url img tag in whole html code
                        //tempInput = tempInput.Remove(m1.Index, m1.Length);
                        tempInput = tempInput.Replace(m1.Value, tempM);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    }
                }
                else
                {
                    return "";
                }
            }
            return tempInput;
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
                            //src = src.Replace("../../", "/ErmNew/");
                            //src = src.Replace("../", "/ErmNew/");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            //src = src.Replace("../../", "/ErmNew/");
                            //src = src.Replace("../", "/ErmNew/");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {
                            //Insert new URL in img tag
                            //src = "src=\"" + context.Request.Url.Scheme + "://" +
                            //context.Request.Url.Authority + src + "\"";
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
                                //string imgsrc = @Server.MapPath("~/imgSignature/" + dt + ".jpg");
                                //string html = "<html><div><img src='" + imgsrc + "'</div></html>";
                                //generatepdf(html);
                                //File.Delete(imgsrc);
                            }
                        }
                    }
                }
            }
            return tempInput;
        }
        public void CreatePDFDocument(string strHtml)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/Summery.pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
            StringReader se = new StringReader(strHtml);
            HTMLWorker obj = new HTMLWorker(document);
            document.Open();
            obj.Parse(se);
            document.Close();
        }



    }
}