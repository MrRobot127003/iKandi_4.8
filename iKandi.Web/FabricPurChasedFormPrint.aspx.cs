using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.Services;
using System.Globalization;
using iTextSharp.text;


namespace iKandi.Web
{
    public partial class FabricPurChasedFormPrint : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        PDFController pdfcon = new PDFController();
        FabricController fabobj = new FabricController();
        public string colorprintdetail;
        public string Fabtype
        {
            get;
            set;

        }
        public string Potype
        {
            get;
            set;

        }
        public string Userid
        {
            get;
            set;

        }

        public int FabricQualityID
        {
            get;
            set;

        }
        public string ParentPageUrlWithQuerystring
        {
            get;
            set;

        }
        public string RemaningQty
        {
            get;
            set;

        }
        public static int SupplierMasterID
        {
            get;
            set;

        }
        public int MasterPoID
        {
            get;
            set;

        }
        public string PoNumber
        {
            get;
            set;

        }
        public string ReceiveQty
        {
            get;
            set;

        }
        public string gerige
        {
            get;
            set;

        }
        public string residual
        {
            get;
            set;

        }
        public string cutwastage
        {
            get;
            set;

        }
        public string AuthName
        {
            get;
            set;

        }
        public string AuthPhoto
        {
            get;
            set;

        }
        public string ApproName
        {
            get;
            set;

        }
        public string ApproPhoto
        {
            get;
            set;

        }
        public string PoNumberPrint
        {
            get;
            set;

        }
        //public string LogedInDesignation
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(ApplicationHelper.LoggedInUser.UserData.UserID.ToString()))
        //        {
        //            return ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
        //        }

        //        return "";
        //    }
        //}
        //public string UserName
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName))
        //        {
        //            return ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName;
        //        }

        //        return "";
        //    }
        //}
        public string TodayDate
        {
            get
            {
                return DateTime.Today.ToString("dd MMM yy");
            }
        }
        public int currentstage
        {
            get;
            set;

        }
        public int previousstage
        {
            get;
            set;

        }
        public bool isStyleSpecific
        {
            get;
            set;

        }
        public int styleid
        {
            get;
            set;

        }
        public int Stage1
        {
            get;
            set;

        }
        public int Stage2
        {
            get;
            set;

        }
        public int Stage3
        {
            get;
            set;

        }
        public int Stage4
        {
            get;
            set;

        }
        public void getquerystring()
        {
            if (Request.QueryString["Fabtype"] != null)
            {
                Fabtype = Request.QueryString["Fabtype"].ToString();
                if (Fabtype.ToUpper() == "FINISHED")
                    Fabtype = "FINISHING";

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
            if (Request.QueryString["Potype"] != null)
            {
                //Potype = Request.QueryString["Potype"].ToString();
                Potype = "RERAISE";

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
                    MasterPoID = Convert.ToInt32(Request.QueryString["MasterPoID"].ToString());
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
            if (!string.IsNullOrEmpty(Request.QueryString["AuthName"]))
            {

                AuthName = Request.QueryString["AuthName"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["AuthPhoto"]))
            {

                AuthPhoto = Request.QueryString["AuthPhoto"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ApproName"]))
            {

                ApproName = Request.QueryString["ApproName"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ApproPhoto"]))
            {

                ApproPhoto = Request.QueryString["ApproPhoto"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["PoNumberPrint"]))
            {

                PoNumberPrint = Request.QueryString["PoNumberPrint"].ToString();
            }
        }
        int FabTypes = 0;
        DataTable dtpo = null;
        string host = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            ApplicationHelper.LoggedInUser = (SessionInfo)Session["ApplicationHelperNew"];

            if (HttpRuntime.Cache["APPLICATIONUSERSALL"] == null)
            {
                UserController controller = new UserController();
                HttpRuntime.Cache.Insert("APPLICATIONUSERSALL", controller.GetAllUsersALL(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }

            List<User> User = (HttpRuntime.Cache["APPLICATIONUSERSALL"] as List<User>);


            imgboutique.ImageUrl = host + "/images/boutique-logo.png";

            Userid = "13";

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
                getquerystring();
                dtpo = fabobj.Podetailsprint("PODETAILS", PoNumberPrint);
                if (dtpo.Rows.Count > 0)
                {
                    if (MasterPoID <= 0)
                    {
                        MasterPoID = Convert.ToInt32(dtpo.Rows[0]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dtpo.Rows[0]["SupplierID"].ToString());

                    }
                    if (dtpo.Rows[0]["AuthorizedId"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtpo.Rows[0]["AuthorizedId"]) > 0)
                        {
                            lblAuthorizedName.Text = dtpo.Rows[0]["AuthName"].ToString();
                            //  imgAuthorizedSignatory.ImageUrl = host + "/Uploads/Photo/" + dtpo.Rows[0]["AuthPhoto"].ToString();
                            imgAuthorizedSignatory.ImageUrl = string.IsNullOrEmpty(dtpo.Rows[0]["AuthPhoto"].ToString()) ? host + "/Uploads/Photo/NotSign.jpg" : host + "/Uploads/Photo/" + dtpo.Rows[0]["AuthPhoto"].ToString();
                        }
                    }
                    else
                    {
                        imgAuthorizedSignatory.Visible = false;
                    }
                    if (dtpo.Rows[0]["PartyId"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtpo.Rows[0]["PartyId"]) > 0)
                        {
                            lblPartyName.Text = dtpo.Rows[0]["ApproName"].ToString() + "</br>" + "<span style=font-size:8px;>(Signed  On Behalf of " + dtpo.Rows[0]["SupplierName"] + ")</span>";
                            // imgpartysingature.ImageUrl = host + "/Uploads/Photo/" + dtpo.Rows[0]["ApproPhoto"].ToString();
                            imgpartysingature.ImageUrl = string.IsNullOrEmpty(dtpo.Rows[0]["ApproPhoto"].ToString()) ? host + "/Uploads/Photo/NotSign.jpg" : host + "/Uploads/Photo/" + dtpo.Rows[0]["ApproPhoto"].ToString();
                        }
                        else
                        {
                            imgpartysingature.Visible = false;
                        }
                    }
                    else
                    {
                        imgpartysingature.Visible = false;
                    }
                }

                getwastage();
                BindPageFabrictype();
                BindTop3FabricSupplier();
                BindQtyRangeGrd();
                BindRemarks();

                if (ParentPageUrlWithQuerystring == "SuPPLIERVIEW")
                {
                    grdqtyrange.Columns[3].Visible = false;

                }
                //if (ParentPageUrlWithQuerystring == "SuPPLIERVIEW")
                //{            
                //    chkAuthorizedSignatory.Enabled = false;
                //}
                //else
                //{
                //    chkpartysignature.Visible = false;
                //}
                //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager)
                //{
                //   chkAuthorizedSignatory.Enabled = true;
                //}

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


            if (Fabtype.ToUpper() == "GRIEGE".ToUpper())
            {
                FabTypes = 1;
            }
            else if (Fabtype.ToUpper() == "FINISHING".ToUpper())
            {
                FabTypes = 10;
            }
            else if (Fabtype.ToUpper() == "DYED".ToUpper())
            {
                FabTypes = 2;
            }
            else if (Fabtype.ToUpper() == "RFD".ToUpper())
            {
                FabTypes = 29;
            }
            else if (Fabtype.ToUpper() == "Embellishment".ToUpper())
            {
                FabTypes = 30;
            }
            else if (Fabtype.ToUpper() == "Embroidery".ToUpper())
            {
                FabTypes = 31;
            }
            else if (Fabtype.ToUpper() == "PRINT".ToUpper())
            {
                FabTypes = 3;
            }

            DataTable dt = null;
            if (Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Dyed" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embroidery")
            {
                dt = fabobj.GetFabricPrintWastageDetails(Enum.GetName(typeof(FabricProcessTypes), FabTypes), "GET", FabricQualityID, colorprintdetail, currentstage, previousstage, isStyleSpecific, styleid, Stage1, Stage2, Stage3, Stage4);
                if (dt.Rows.Count > 0)
                {
                    if (Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Printed" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Dyed")
                    {
                        r_sh = 0; // Convert.ToDecimal(dt.Compute("min([Stage" + currentstage + "_Shrinkage])", string.Empty));
                    }
                    else if (Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "RFD" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embellishment" || Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "Embroidery")
                    {
                        g_sh = 0; //Convert.ToDecimal(dt.Compute("min([Stage" + currentstage + "_Wastage])", string.Empty));
                        g_sh = 0; //Stage1 == 29 && Enum.GetName(typeof(FabricProcessTypes), FabTypes) == "RFD" ? 0 : g_sh;
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
                        g_sh = 0; //Convert.ToDecimal(dt.Compute("min([Stage1_Wastage])", string.Empty));
                    }
                    else if (Fabtype == "FINISHING")
                    {
                        r_sh = 0; //Convert.ToDecimal(dt.Compute("min([Stage" + 1 + "_Shrinkage])", string.Empty));
                    }
                }
            }
            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            string strdec = r_sh.ToString(CultureInfo.CurrentCulture);
            residual = strdec.Contains(sep) ? strdec.TrimEnd('0').TrimEnd(sep.ToCharArray()) : strdec;

            strdec = g_sh.ToString(CultureInfo.CurrentCulture);
            gerige = strdec.Contains(sep) ? strdec.TrimEnd('0').TrimEnd(sep.ToCharArray()) : strdec;

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
                        lblRemarks.Text = dt.Rows[0]["CommentRemarks"].ToString();
                        //hdnOldremak.Value = dt.Rows[0]["CommentRemarks"].ToString();
                    }
                }
            }
            else
            {
                lblRemarks.Text = "";
            }

        }

        public void BindPageFabrictype()
        {
            String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (Fabtype.ToLower() == "RFD".ToLower())
            {

                if (isStyleSpecific == false)
                {
                    styleid = -1;
                }

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
                lblClintCode.Text = dt.Rows[0]["ClintCode"].ToString();
                // rajeevs 10022023            
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
                // rajeevs 10022023	

                if (Convert.ToInt32(dt.Rows[0]["POStatus"]) == 1)
                {
                    PoWaterMark.Visible = true;
                }
                int val = dt.Rows[0]["RateType"] == DBNull.Value || Convert.ToInt32(dt.Rows[0]["RateType"]) == 1 ? 1 : 2;
                foreach (System.Web.UI.WebControls.ListItem li in rdybtnListRateType.Items)
                {
                    if (val == 1 && li.Text == "Landed")
                    {
                        li.Selected = true;
                    }
                    else if (val == 2 && li.Text == "Ex Mill")
                    {

                        li.Selected = true;

                    }

                }
                rdybtnListRateType.Enabled = false;
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

                //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager)
                //{
                //    chkAuthorizedSignatory.Attributes.Remove("disabled");
                //}
                //else
                //{
                //    if (ParentPageUrlWithQuerystring == "SuPPLIERVIEW")
                //    {
                //        chkpartysignature.Attributes.Remove("disabled");
                //    }
                //}
                grdfabricpurchased.DataSource = dt;
                grdfabricpurchased.DataBind();

                if (dt.Rows[0]["IsPartySignature"].ToString() != "")
                {
                    chkpartysignature.Checked = Convert.ToBoolean(dt.Rows[0]["IsPartySignature"].ToString());
                }

                hdnconversionvalue.Value = dt.Rows[0]["ConversionValue"].ToString();

                if (chkpartysignature.Checked)
                {
                    chkpartysignature.Attributes.Add("style", "display:none");
                    PositonRightM.Visible = false;
                    //PositonRightM.Attributes.Add("class", "PositionRight");
                    //if (dt.Rows[0]["UploadSignature"].ToString().Length > 4)
                    //{
                    //    imgpartysingature.ImageUrl = ProductionFolderPath + dt.Rows[0]["UploadSignature"].ToString();
                    //}
                    //else
                    //{
                    //    imgpartysingature.ImageUrl = ProductionFolderPath + "NotSign.jpg";
                    //}
                    if (dt.Rows[0]["PartySignatureApprovedOn"].ToString() != "")
                    {
                        lblimgpartysingature.Text = Convert.ToDateTime(dt.Rows[0]["PartySignatureApprovedOn"]).ToString("dd MMM yy (ddd)");
                    }
                }
                else
                {
                    //chkpartysignature.Attributes.Add("style", "display:block");
                    chkpartysignature.Attributes.Remove("style");
                    PositonRightM.Visible = true;
                    //imgpartysingature.Attributes.Add("style", "display:none");
                }
                //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager)
                //{
                //    chkpartysignature.Attributes.Add("style", "display:none");
                //    imgpartysingature.Attributes.Add("style", "display:none");
                //}

                if (dt.Rows[0]["IsAuthorizedSignatory"].ToString() != "")
                {
                    chkAuthorizedSignatory.Checked = Convert.ToBoolean(dt.Rows[0]["IsAuthorizedSignatory"].ToString());
                    //imgAuthorizedSignatory.ImageUrl = ProductionFolderPath + "hemant_signature.png";

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

                        chkAuthorizedSignatory.Attributes.Remove("style");
                        spanAuthorizedSig.Visible = true;
                        imgAuthorizedSignatory.Attributes.Add("style", "display:none");
                    }
                }
                else
                {


                    chkAuthorizedSignatory.Attributes.Remove("style");
                    imgAuthorizedSignatory.Attributes.Add("style", "display:none");
                }
                //need to change host address after live 


                if ((dt.Rows[0]["PendingQtyToOrder"]).ToString() != "")
                {
                    RemaningQty = Convert.ToDecimal(dt.Rows[0]["PendingQtyToOrder"]).ToString("N0");
                }
                lblPoNo.Text = dt.Rows[0]["POnumber"].ToString();
                //lblh.Text = dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                // lblh.Text = dt.Rows[0]["TextHistory"].ToString().Replace("###", ""); ;
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
                        BindTop3FabricSupplier();

                        ddlSupplierName.SelectedValue = dt.Rows[0]["supplier_master_Id"].ToString();

                        if (Fabtype == "GRIEGE" || Fabtype == "FINISHING" || (Fabtype == "RFD" && currentstage == 1))
                        Order_text.InnerHtml = "Purchase Order";

                        else Order_text.InnerHtml = "Process Order";


                        lblsupplier.Text = ddlSupplierName.SelectedItem.Text;
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
            // BindQtyRangeGrd();
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
            }
            //existing supplier will be fixed with po after all check box done !
            if (dt.Rows.Count > 0)
            {
                ddlSupplierName.DataSource = dt;
                ddlSupplierName.DataValueField = "Supplier_master_ID";
                ddlSupplierName.DataTextField = "SupplierName2";
                ddlSupplierName.DataBind();
            }


            //ds = fabobj.GetfabricViewdetails(Fabtype, flagoption, FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, (isStyleSpecific == false ? -1 : styleid), Stage1, Stage2, Stage3, Stage4);
            //dt = ds.Tables[0];

            //if (MasterPoID > 0 && chkpartysignature.Checked == true && chkAuthorizedSignatory.Checked == true)
            //{
            //    ds = fabobj.GetfabricViewdetails("PO_SUPPLIERDETAILS", flagoption, FabricQualityID, 100, colorprintdetail, "", MasterPoID, currentstage, previousstage, isStyleSpecific, (isStyleSpecific == false ? -1 : styleid), Stage1, Stage2, Stage3, Stage4);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        if (ds.Tables[0].Rows[0]["SupplierName2"].ToString() != "")
            //        {
            //            dt = ds.Tables[0];
            //        }
            //    }

            //}

            //if (dt.Rows.Count <= 0)
            //{
            //    dt = ds.Tables[1];
            //}

            //if (dt.Rows.Count > 0)
            //{
            //    ddlSupplierName.DataSource = dt;
            //    ddlSupplierName.DataValueField = "Supplier_master_ID";
            //    ddlSupplierName.DataTextField = "SupplierName2";
            //    ddlSupplierName.DataBind();
            //}
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

                HeaderCell.Text = "<table style='width:100%;height:100%;' border='0' cellspacing='0' cellpadding='0'><tr><td class='colwidthG' style='border-left: 0;border-top: 0;border-bottom: 0;'>" + Hedrca + "</td><td class='colwidthG' style='border:0;text-align:center'>R.Sh.</td></tr></table>";

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
                HeaderCell.Text = "Quantity";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.ColumnSpan = 3;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Finance";
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
                decimal ReceivedQty = 0;
                decimal RateValue = 0;
                decimal finaltotalrecivedqty = 0;
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnSupplierMasterID = (HiddenField)e.Row.FindControl("hdnSupplierMasterID");
                DropDownList ddlSupplytype = (DropDownList)e.Row.FindControl("ddlSupplytype");
                Label txtsendQty = (Label)e.Row.FindControl("txtsendQty");
                Label txtreceivedqty = (Label)e.Row.FindControl("txtreceivedqty");
                Label txtrateSupplierQuotedRate = (Label)e.Row.FindControl("txtrateSupplierQuotedRate");
                Label lbltotalAmount = (Label)e.Row.FindControl("lbltotalAmount");
                Label Label1 = (Label)e.Row.FindControl("Label1");
                Label lblcolorprint = (Label)e.Row.FindControl("lblcolorprint");
                HiddenField hdnsendqty = (HiddenField)e.Row.FindControl("hdnsendqty");
                HiddenField hdngerigeshrnk = (HiddenField)e.Row.FindControl("hdngerigeshrnk");
                HiddenField hdnSendQtyValidate = (HiddenField)e.Row.FindControl("hdnSendQtyValidate");
                HiddenField hdnsaveconversionvalue = (HiddenField)e.Row.FindControl("hdnsaveconversionvalue");
                //HtmlAnchor ansendtooltip = e.Row.FindControl("ansendtooltip") as HtmlAnchor;
                //HtmlGenericControl spanx = e.Row.FindControl("spanmsgsendqty") as HtmlGenericControl;
                //HtmlGenericControl spanx2 = e.Row.FindControl("spanmsgsendqtys") as HtmlGenericControl;
                //HtmlAnchor anreceivetooltip = e.Row.FindControl("anreceivetooltip") as HtmlAnchor;
                Label lblGreige = (Label)e.Row.FindControl("lblGreige");
                hdnminsrv.Value = DataBinder.Eval(e.Row.DataItem, "Minsrvcehck").ToString();
                Label lblResdualSh = (Label)e.Row.FindControl("lblResdualSh");
                Label lblCutWes = (Label)e.Row.FindControl("lblCutWes");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblprocesstype = (Label)e.Row.FindControl("lblprocesstype");
                Label lblunit = (Label)e.Row.FindControl("lblunit");
                HiddenField hdndefualtorderunit = (HiddenField)e.Row.FindControl("hdndefualtorderunit");
                HiddenField hdnConvertTounit = (HiddenField)e.Row.FindControl("hdnConvertTounit");
                if (hdndefualtorderunit.Value != hdnConvertTounit.Value)
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Yellow;
                }
                hdnsaveconversionvalue.Value = (hdnsaveconversionvalue.Value == "" ? "1" : hdnsaveconversionvalue.Value);
                hdnconverttounit.Value = hdnConvertTounit.Value;
                lblunitto.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value));
                lblunitfrom.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value));
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
                if (gerige != "0" && Fabtype.ToUpper() != "GRIEGE" && Stage1!=29)
                {
                    string val = gerige == "0" ? "" : gerige + "%";
                    sb.Append("<td class='colwidthinnr gerige' style='display:block;width: 44px;text-align: center;border-right: 1px solid lightgray;line-height: 15px;'>" + val + "</td>");
                    lblgerigeshrinkage.Text = gerige;
                }
                else
                {
                    sb.Append("<td class='colwidthinnr'>" + " " + "</td>");
                }

                if (residual != "0")
                {
                    sb.Append("<td class='colwidthinnr residual hideresidual' style='width: 40px;text-align: center;display:none;'>" + residual + "</td>");
                    lblresidualshrinkage.Text = residual;
                }
                else
                {
                    sb.Append("<td class='colwidthinnr'>" + " " + "</td>");
                }
                ////if (cutwastage != "0")
                ////{
                ////    if (MasterPoID > 0)
                ////    {
                ////        cutwastage = DataBinder.Eval(e.Row.DataItem, "cutwastage").ToString();
                ////    }
                ////    sb.Append("<td class='colwidthC'>" + cutwastage + "</td>");
                ////}
                ////else
                ////{
                ////    sb.Append("<td class='colwidthC'>" + "" + "</td>");
                ////}
                sb.Append("</tr>");
                sb.Append("</table>");
                //lblGreige.Text = sb.ToString();
                e.Row.Cells[5].Text = sb.ToString();

                DropDownList ddlunits = (DropDownList)e.Row.FindControl("ddlunits");
                ReceiveQty = (DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString() == "" ? "0" : DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString());

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


                if (Fabtype.ToLower() == "GRIEGE".ToLower() || Fabtype.ToLower() == "FINISHING".ToLower() || (Fabtype.ToLower() == "RFD".ToLower() && currentstage == 1))
                {
                    //ddlSupplytype.SelectedValue = "1";
                    //ddlSupplytype.Enabled = false;
                    txtsendQty.Enabled = false;
                    //ansendtooltip.Attributes.Remove("class");

                    if (Fabtype.ToLower() != "FINISHING".ToLower())
                        lblcolorprint.Text = "";

                    grdhistorysend.Visible = false;
                    grdReceiveQtyHistory.Visible = true;

                    //if (DataBinder.Eval(e.Row.DataItem, "remainingQty").ToString() != "")
                    //{
                    //    //if (Potype != "RAISE")
                    //    //{
                    //    //    spanx2.InnerText = "you cannot enter send quantity more than remaining qty " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "remainingQty").ToString()).ToString("N0");
                    //    //}
                    //    //else
                    //    //{
                    //    //    spanx2.InnerText = "you cannot enter send quantity more than remaining qty " + txtsendQty.Text;
                    //    //}
                    //}
                    //else
                    //{
                    //    anreceivetooltip.Attributes.Remove("class");
                    //}
                    txtreceivedqty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString() == "" ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString())) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    hdnstorereceivedqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()==""?0:Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString())) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");

                    ReceivedQty = Convert.ToDecimal(txtreceivedqty.Text.Replace(",", "") == "0" ? 0 : Convert.ToDecimal(txtreceivedqty.Text.Replace(",", "")));
                    RateValue = Convert.ToDecimal(txtrateSupplierQuotedRate.Text == "0" ? 0 : Convert.ToDecimal(txtrateSupplierQuotedRate.Text));
                    finaltotalrecivedqty = Math.Round(ReceivedQty * RateValue, 0, MidpointRounding.AwayFromZero);
                    lbltotalAmount.Text = finaltotalrecivedqty.ToString("N0");

                }
                else// if (Fabtype.ToLower() != "FINISHING".ToLower() && Fabtype.ToLower() != "GRIEGE".ToLower() && Fabtype.ToLower() != "RFD".ToLower())
                {
                    txtsendQty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    //hdnremainingQty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString();
                    hdnstoresendqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    hdnsendqty.Value = DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString();

                    hdnSendQtyValidate.Value = DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString();
                    txtsendQty.ToolTip = "Remaining Qty: " + DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString();
                    //ansendtooltip.Attributes.Add("style", "Display:block");

                    //if (DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString() != "")
                    //{
                    //    //if (Potype != "RAISE")
                    //    //{
                    //    //    spanx.InnerText = "you cannot enter send quantity more than remaining qty " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString()).ToString("N0");
                    //    //}
                    //    //else
                    //    //{
                    //    //    spanx.InnerText = "you cannot enter send quantity more than remaining qty " + txtsendQty.Text;
                    //    //}
                    //}
                    //else
                    //{
                    //    ansendtooltip.Attributes.Remove("class");
                    //}
                    txtsendQty.Enabled = true;
                    ddlSupplytype.Enabled = false;
                    txtreceivedqty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                    hdnstorereceivedqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                }

                //if (lblgsm.Text != "")
                //{
                //    lblgsm.Text = "(" + lblgsm.Text + ")";

                //}

                //anreceivetooltip.Attributes.Remove("class");

                //if (Fabtype.ToLower() != "FINISHING".ToLower() && Fabtype.ToLower() != "GRIEGE".ToLower() && (Fabtype.ToLower() == "RFD".ToLower() && currentstage != 1))
                //{
                //    txtsendQty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                //    hdnstoresendqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                //    hdnsendqty.Value = DataBinder.Eval(e.Row.DataItem, "ReceiveQty").ToString();

                //    hdnSendQtyValidate.Value = DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString();
                //    txtsendQty.ToolTip = "Remaining Qty: " + DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString();
                //    ansendtooltip.Attributes.Add("style", "Display:block");

                //    if (DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString() != "")
                //    {
                //        if (Potype != "RAISE")
                //        {
                //            spanx.InnerText = "you cannot enter send quantity more than remaining qty " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValidateRemaningQty").ToString()).ToString("N0");
                //        }
                //        else
                //        {
                //            spanx.InnerText = "you cannot enter send quantity more than remaining qty " + txtsendQty.Text;
                //        }
                //    }
                //    else
                //    {
                //        ansendtooltip.Attributes.Remove("class");
                //    }
                //    txtsendQty.Enabled = true;
                //    ddlSupplytype.Enabled = false;
                //    txtreceivedqty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                //    hdnstorereceivedqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QtyToOrder").ToString()) * Convert.ToDecimal(hdnsaveconversionvalue.Value)), 0).ToString("N0");
                //}
                //Label1.Text = DataBinder.Eval(e.Row.DataItem, "Greige_Shrinkage").ToString();
                //hdngerigeshrnk.Value = DataBinder.Eval(e.Row.DataItem, "Greige_Shrinkage").ToString();

                // }
                if (Potype.ToUpper() == "RERAISE")
                {
                    txtreceivedqty.Enabled = true;
                    ddlunits.Enabled = true;
                }

                ReceivedQty = Convert.ToDecimal(txtreceivedqty.Text.Replace(",", "") == "0" ? 0 : Convert.ToDecimal(txtreceivedqty.Text.Replace(",", "")));
                RateValue = Convert.ToDecimal(txtrateSupplierQuotedRate.Text == "0" ? 0 : Convert.ToDecimal(txtrateSupplierQuotedRate.Text));
                finaltotalrecivedqty = Math.Round(ReceivedQty * RateValue, 0, MidpointRounding.AwayFromZero);
                lbltotalAmount.Text = finaltotalrecivedqty.ToString("N0");
                //txtrateSupplierQuotedRate.Text = "";
                lblprocesstype.Text = ddlSupplytype.SelectedItem.Text;
                lblunit.Text = ddlunits.SelectedItem.Text;
            }

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            //    pdfDoc.Open();
            //    htmlparser.Parse(sr);
            //    pdfDoc.Close();
            //    byte[] bytes = memoryStream.ToArray();
            //    memoryStream.Close();

            //    string result = string.Empty;
            //    string url = "http://codesolution.org";
            //    var request = HttpWebRequest.Create(url);
            //    using (var response = request.GetResponse())
            //    {
            //        result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //    }
            //    div1.InnerHtml = result;

            //}
            // randorHtml();
            //if (ParentPageUrlWithQuerystring != "")
            //{
            //    Response.Redirect(ParentPageUrlWithQuerystring);
            //}

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
            //DataTable dts = (DataTable)Session["qtyrange"];
            //grdqtyrange.DataSource = dts;
            //grdqtyrange.DataBind();
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

            //dt.DefaultView.Sort = "FromQty asc";
            //dt = dt.DefaultView.ToTable();
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' class='receivehis tableCenter' cellpadding='0' cellspacing='0' style='margin-top: -13px; border-top: 0px; width: 352px;float:right;margin-right: 5px;text-align:center;'>");
            str.Append("<thead style='background-color: #dddfe4;color:gray;border: 1px solid darkgray;'><tr><th style='width: 91px;border: 1px solid darkgray;padding: 3px;'>From (" + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value)) + ") </th><th style='width: 91px;border: 1px solid darkgray;padding: 3px;'>To (" + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnconverttounit.Value)) + ") </th><th style='width: 149px;border: 1px solid darkgray;padding: 3px;'>Date</th></tr></thead>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {


                TextBox txtfromqty = this.FindControl("txtfromqty" + (i).ToString()) as TextBox;
                TextBox txttoqty = this.FindControl("txttoqty" + (i).ToString()) as TextBox;

                Label lblfromqty = this.FindControl("lblfromqty" + (i).ToString()) as Label;
                Label lbltoqty = this.FindControl("lbltoqty" + (i).ToString()) as Label;

                TextBox txtetabreakedate = this.FindControl("txtetabreakedate" + (i).ToString()) as TextBox;
                Label lbletabreakedate = this.FindControl("lbletabreakedate" + (i).ToString()) as Label;

                if (txtfromqty != null && txttoqty != null)
                {
                    txtfromqty.Text = dt.Rows[i]["FromQty"].ToString();
                    lblfromqty.Text = dt.Rows[i]["FromQty"].ToString();

                    txttoqty.Text = dt.Rows[i]["ToQty"].ToString();
                    lbltoqty.Text = dt.Rows[i]["ToQty"].ToString();

                    txtetabreakedate.Text = dt.Rows[i]["POETADate"].ToString();
                    lbletabreakedate.Text = dt.Rows[i]["POETADate"].ToString();

                    if (i % 2 == 0)
                    {
                        str.Append("<tr class='even'>");
                    }
                    else
                    {
                        str.Append("<tr class='odd'>");
                    }
                    str.Append("<td style='Font-Weight:bold;'>" + Convert.ToDecimal(txtfromqty.Text).ToString("N0") + "</td>");
                    str.Append("<td style='Font-Weight:bold;'>" + Convert.ToDecimal(txttoqty.Text).ToString("N0") + "</td>");
                    str.Append("<td>" + txtetabreakedate.Text + "</td>");
                    str.Append("</tr>");

                }


            }
            str.Append("</table>");
            divrange.InnerHtml = str.ToString();
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
            //BindQtyRangeGrd();
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
            // BindQtyRangeGrd();
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
                    //BindQtyRangeGrd();
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
            //  BindQtyRangeGrd();
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

        //public void randorHtml()
        //{
        //    //WebRequest quest;
        //    //WebResponse ponse;
        //    //StreamReader reader;
        //    ////StreamWriter writer;
        //    //string strHTML;
        //    //string DomainName = HttpContext.Current.Request.Url.Host;

        //    //if (DomainName == "localhost")
        //    //{
        //    //    DomainName = "localhost:3220";
        //    //}
        //    ////http://localhost:3220/ClientDepartmentList.aspx
        //    //string myUri = "http://localhost:3220/Internal/Fabric/FabricPurChasedForm_Print.aspx?" + Request.QueryString;
        //    ////string host = myUri.Host; D:\tfs\iKandi.Web\Internal\Fabric\FabricPurChasedForm_Print.aspx
        //    //quest = WebRequest.Create(myUri);
        //    //quest.Timeout = Convert.ToInt32(99999999);


        //    //ponse = quest.GetResponse();
        //    //reader = new StreamReader(ponse.GetResponseStream());
        //    //strHTML = reader.ReadToEnd();
        //    //genertaePdf(strHTML, "ss");




        //    WebRequest quest;
        //    WebResponse ponse;
        //    StreamReader reader;
        //    //StreamWriter writer;

        //    string strHTML = Request.RawUrl.ToString().Replace("FabricPurChasedForm.aspx", "FabricPurChasedForm_Print.aspx");
        //    //Server.Transfer(Request.RawUrl.ToString().Replace("FabricPurChasedForm.aspx", "FabricPurChasedForm_Print.aspx"));
        //    // quest = WebRequest.Create(Request.RawUrl.ToString().Replace("FabricPurChasedForm.aspx", "FabricPurChasedForm_Print.aspx"));

        //    //quest = WebRequest.Create("http://localhost:3220/Internal/Fabric/FabricPurChasedForm_Print.aspx?FabricQualityID=17&Fabtype=GRIEGE");
        //    //quest.Credentials = new System.Net.NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password);
        //    //quest.Timeout = Convert.ToInt32(99999999);
        //    //ponse = quest.GetResponse();
        //    //reader = new StreamReader(ponse.GetResponseStream());
        //    //strHTML = reader.ReadToEnd();
        //    //genertaePdf(strHTML, "ss");

        //    string ss = "http://localhost:3220/Internal/Fabric/FabricPurChasedForm.aspx?FabricQualityID=17&Fabtype=GRIEGE&Potype=RERAISE&MasterPoID=55&colorprintdetail=&gerige=3&residual=2&cutwastage=7&currentstage=0&previousstage=0&isStyleSpecific=0&styleid=0&stage1=1&stage2=3&stage3=31&stage4=30";
        //    Uri requestUri = null;
        //    Uri.TryCreate((ss), UriKind.Absolute, out requestUri);
        //    NetworkCredential nc = new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password);
        //    CredentialCache cache = new CredentialCache();
        //    cache.Add(requestUri, "Basic", nc);
        //    cache.Add(new Uri(ss), "NTLM", new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password));

        //    // Requesting query string
        //    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
        //    request.Credentials = cache;

        //    // Getting response from WebRequest
        //    request.Method = WebRequestMethods.Http.Get;
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    StreamReader respStream = new StreamReader(response.GetResponseStream());
        //    strHTML = respStream.ReadToEnd();
        //    genertaePdf(strHTML, "ss");



        //}
        //public void genertaePdf(string HTMLCode, string PolicyFile)
        //{
        //    string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/Summery.pdf");
        //    HTMLCode = getImage(HTMLCode);
        //    getvartypeHTML(HTMLCode, strFileName);
        //}
        //public void getvartypeHTML(string HTMLCode, string PolicyFile)
        //{
        //    string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/Summery.pdf");

        //    var pechkin = Factory.Create(new GlobalConfig());
        //    var pdf = pechkin.Convert(new ObjectConfig()
        //                            .SetLoadImages(true).SetZoomFactor(1.5)
        //                            .SetPrintBackground(true)
        //                            .SetScreenMediaType(true)
        //                            .SetCreateExternalLinks(true), (HTMLCode));
        //    using (FileStream file = System.IO.File.Create(strFileName))
        //    {
        //        file.Write(pdf, 0, pdf.Length);
        //    }

        //}
        //public string getTitle(string input)
        //{
        //    if (input == null)
        //        return string.Empty;
        //    string tempInput = input;
        //    string pattern = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
        //    string title = string.Empty;

        //    //get and remove Title in HTML..
        //    foreach (Match m1 in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline))
        //    {
        //        if (m1.Success)
        //        {
        //            string tempM = m1.Value;
        //            try
        //            {
        //                //tempM = tempM.Remove(m1.Index, m1.Length);
        //                tempM = tempM.Replace(m1.Value, title);

        //                //insert new url img tag in whole html code
        //                //tempInput = tempInput.Remove(m1.Index, m1.Length);
        //                tempInput = tempInput.Replace(m1.Value, tempM);
        //            }
        //            catch (Exception ex)
        //            {
        //                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

        //                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        //            }
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    return tempInput;
        //}
        //public string getImage(string input)
        //{
        //    if (input == null)
        //        return string.Empty;
        //    string tempInput = input;
        //    string pattern = @"<img(.|\n)+?>";
        //    string src = string.Empty;
        //    HttpContext context = HttpContext.Current;

        //    //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
        //    foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

        //    RegexOptions.RightToLeft))
        //    {
        //        if (m.Success)
        //        {
        //            string tempM = m.Value;
        //            string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
        //            Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        //            Match mImg = reImg.Match(m.Value);

        //            if (mImg.Success)
        //            {
        //                src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
        //                if (src == "../../signatured.jpg" || src == "../signatured.jpg")
        //                {
        //                    string imgsrc = @Server.MapPath("~/Signature/SignatureD.jpg");
        //                    //src = src.Replace("../../", "/ErmNew/");
        //                    //src = src.Replace("../", "/ErmNew/");
        //                    src = "src=\"" + imgsrc + "\"";
        //                }
        //                if (src == "../../signdt.jpg" || src == "../signdt.jpg")
        //                {
        //                    string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
        //                    //src = src.Replace("../../", "/ErmNew/");
        //                    //src = src.Replace("../", "/ErmNew/");
        //                    src = "src=\"" + imgsrc + "\"";
        //                }
        //                if (src.ToLower().Contains("http://") == false)
        //                {
        //                    //Insert new URL in img tag
        //                    //src = "src=\"" + context.Request.Url.Scheme + "://" +
        //                    //context.Request.Url.Authority + src + "\"";
        //                    try
        //                    {
        //                        tempM = tempM.Remove(mImg.Index, mImg.Length);
        //                        tempM = tempM.Insert(mImg.Index, src);

        //                        //insert new url img tag in whole html code
        //                        tempInput = tempInput.Remove(m.Index, m.Length);
        //                        tempInput = tempInput.Insert(m.Index, tempM);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

        //                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        //                        //string imgsrc = @Server.MapPath("~/imgSignature/" + dt + ".jpg");
        //                        //string html = "<html><div><img src='" + imgsrc + "'</div></html>";
        //                        //generatepdf(html);
        //                        //File.Delete(imgsrc);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return tempInput;
        //}
        //public void CreatePDFDocument(string strHtml)
        //{
        //    string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/Summery.pdf");
        //    iTextSharp.text.Document document = new iTextSharp.text.Document();
        //    PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
        //    StringReader se = new StringReader(strHtml);
        //    HTMLWorker obj = new HTMLWorker(document);
        //    document.Open();
        //    obj.Parse(se);
        //    document.Close();
        //}
    }
}