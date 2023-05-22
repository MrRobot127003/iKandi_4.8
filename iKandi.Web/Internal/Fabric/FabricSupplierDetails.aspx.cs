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
namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricSupplierDetails : System.Web.UI.Page
    {
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
        public int SupplierMasterID
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
        public string fab
        {
            get;
            set;

        }
        public string fabqty
        {
            get;
            set;

        }
        public string fabricdetails
        {
            get;
            set;

        }
        public string gsm
        {
            get;
            set;

        }
        public string cc
        {
            get;
            set;

        }
        public string width
        {
            get;
            set;

        }

        decimal qoted;
        string ccn = "";
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
                Potype = Request.QueryString["Potype"].ToString();
            }
            if (Request.QueryString["fabqty"] != null)
            {
                fabqty = Request.QueryString["fabqty"].ToString();
                fabricdetails = Request.QueryString["fabricdetails"].ToString();
                gsm = Request.QueryString["gsm"].ToString();
                cc = Request.QueryString["cc"].ToString();
                width = Request.QueryString["width"].ToString();
                ccn = "<span style='color:blue;'>" + fabqty + "</span><span style='color:gray;'> " + gsm + " " + cc + " " + width + "</span> " + " " + "<span  class='color_black' style='color:Black;font-weight:bold;'>" + fabricdetails + "</span>";
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
            if (Request.QueryString["fab"] != null)
            {
                if (Request.QueryString["fab"].ToString() != "undefined")
                {
                    fab = Request.QueryString["fab"].ToString();
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
        }
        int FabTypes = 0;
        int rowspan = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");


            if (!IsPostBack)
            {
                getquerystring();
                BindData();
            }
        }



        private void BindData()
        {
            DataSet dsSupplier = new DataSet();
            DataTable dtsupplierQuoted = new DataTable();
            DataTable dtSystemQuoted = new DataTable();
            DataTable dtPo;

            if (Fabtype.ToLower() == "GRIEGE".ToLower())
            {
                FabTypes = 1;

                DataSet ds = fabobj.GetfabricViewdetails("GRIEGE", "GETTOP3SUPPLIER_GRIGE", FabricQualityID, 100, colorprintdetail);
                DataTable dt = ds.Tables[0];
                dtPo = ds.Tables[3];
                gridPO.DataSource = dtPo;
                gridPO.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtsupplierQuoted = ds.Tables[0];
                    rowspan = dtsupplierQuoted.Rows.Count;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dtSystemQuoted = ds.Tables[1];
                    if (dtSystemQuoted.Rows.Count > 0)
                    {
                        if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                        {
                            qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                        }

                    }
                }
            }
            else if (Fabtype.ToLower() == "FINISHING".ToLower())
            {
                FabTypes = 10;

                DataSet ds = fabobj.GetfabricViewdetails("FINISHING", "GETTOP3SUPPLIER_FINISH", FabricQualityID, 100, colorprintdetail);
                DataTable dt = ds.Tables[0];
                dtPo = ds.Tables[3];
                gridPO.DataSource = dtPo;
                gridPO.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtsupplierQuoted = ds.Tables[0];
                    rowspan = dtsupplierQuoted.Rows.Count;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dtSystemQuoted = ds.Tables[1];
                    if (dtSystemQuoted.Rows.Count > 0)
                    {
                        if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                        {
                            qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                        }

                    }
                }

            }
            else if (Fabtype.ToLower() == "DYED".ToLower())
            {
                FabTypes = 2;
                if (isStyleSpecific == false)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("Dyed", "GETTOP3SUPPLIER_DAYEDNONSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, -1, Stage1, Stage2, Stage3, Stage4);
                    DataTable dt = ds.Tables[0];
                    dtPo = ds.Tables[2];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }

                }
                else if (isStyleSpecific == true)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("Dyed", "GETTOP3SUPPLIER_DAYEDSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, styleid, Stage1, Stage2, Stage3, Stage4);
                    dtPo = ds.Tables[2];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }
                }
            }
            else if (Fabtype.ToLower() == "RFD".ToLower())
            {
                FabTypes = 29;

                if (isStyleSpecific == false)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("RFD", "GETTOP3SUPPLIERFAB_RFDNONSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, -1, Stage1, Stage2, Stage3, Stage4);
                    DataTable dt = ds.Tables[0];
                    dtPo = ds.Tables[2];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }

                }
                else if (isStyleSpecific == true)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("RFD", "GETTOP3SUPPLIERFAB_RFDSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, styleid, Stage1, Stage2, Stage3, Stage4);
                    dtPo = ds.Tables[3];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }
                }
            }
            else if (Fabtype.ToLower() == "Embellishment".ToLower())
            {
                FabTypes = 30;
                if (isStyleSpecific == false)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("Embellishment", "GETTOP3SUPPLIER_EmbellishmentNONSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, -1, Stage1, Stage2, Stage3, Stage4);
                    DataTable dt = ds.Tables[0];                    
                    dtPo = ds.Tables[3];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }

                }
                else if (isStyleSpecific == true)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("Embellishment", "GETTOP3SUPPLIER_EmbellishmentSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, styleid, Stage1, Stage2, Stage3, Stage4);
                    dtPo = ds.Tables[3];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }
                }
            }
            else if (Fabtype.ToLower() == "Embroidery".ToLower())
            {
                FabTypes = 31;
                if (isStyleSpecific == false)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("Embroidery", "GETTOP3SUPPLIER_EmbroideryNONSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, -1, Stage1, Stage2, Stage3, Stage4);
                    DataTable dt = ds.Tables[0];
                    dtPo = ds.Tables[3];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }

                }
                else if (isStyleSpecific == true)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("Embroidery", "GETTOP3SUPPLIER_EmbroiderySTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, styleid, Stage1, Stage2, Stage3, Stage4);
                    dtPo = ds.Tables[2];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }
                }
            }
            else if (Fabtype.ToLower() == "PRINT".ToLower())
            {
                FabTypes = 3;
                if (isStyleSpecific == false)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINTNONSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, -1, Stage1, Stage2, Stage3, Stage4);
                    DataTable dt = ds.Tables[0];
                    dtPo = ds.Tables[2];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }

                }
                else if (isStyleSpecific == true)
                {
                    DataSet ds = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINTSTYLE", FabricQualityID, 100, colorprintdetail, "", 0, currentstage, previousstage, isStyleSpecific, styleid, Stage1, Stage2, Stage3, Stage4);
                    dtPo = ds.Tables[1];
                    gridPO.DataSource = dtPo;
                    gridPO.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                        rowspan = dtsupplierQuoted.Rows.Count;
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[0];
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() != "")
                            {
                                qoted = Convert.ToDecimal(dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString());
                            }

                        }
                    }
                }
            }

            grdSupplier.DataSource = dtsupplierQuoted;
            grdSupplier.DataBind();          
            MergeRowsnew();

        }
        public void MergeRowsnew()
        {
            for (int i = grdSupplier.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdSupplier.Rows[i];
                GridViewRow previousRow = grdSupplier.Rows[i - 1];
                Label lblcolorprint = (Label)row.FindControl("lblcolorprint");
                Label lblcolorprintpreviousRow = (Label)previousRow.FindControl("lblcolorprint");
                if (lblcolorprint.Text == lblcolorprintpreviousRow.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;

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
        protected void grdSupplier_DataBound(object sender, EventArgs e)
        {
            //for (int i = grdSupplier.Rows.Count - 1; i > 0; i--)
            //{
            //    GridViewRow row = grdSupplier.Rows[i];
            //    GridViewRow previousRow = grdSupplier.Rows[i - 1];
            //    string CurrentAccessory = "";
            //    string PreviousAccessory = "";

            //    HiddenField lblcolorprint = (HiddenField)row.FindControl("lblcolorprint");
            //    HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
            //    CurrentAccessory = hdAccessoryMasterId.Value + hdnAccessoryQualitySize.Value.Trim();


            //    HiddenField hdAccessoryMasterId_Previous = (HiddenField)previousRow.FindControl("hdAccessoryMasterId");
            //    HiddenField hdnAccessoryQualitySize_Previous = (HiddenField)previousRow.FindControl("hdnAccessoryQualitySize");
            //    PreviousAccessory = hdAccessoryMasterId_Previous.Value + hdnAccessoryQualitySize_Previous.Value.Trim();

            //    if (CurrentAccessory == PreviousAccessory)
            //    {
            //        if (previousRow.Cells[0].RowSpan == 0)
            //        {
            //            if (row.Cells[0].RowSpan == 0)
            //            {
            //                previousRow.Cells[0].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
            //            }
            //            row.Cells[0].Visible = false;
            //        }
            //    }
            //    Label lblShrinkage = (Label)row.FindControl("lblShrinkage");
            //    Label lblShrinkagePrev = (Label)previousRow.FindControl("lblShrinkage");

            //    if (lblShrinkage.Text == lblShrinkagePrev.Text)
            //    {
            //        if (previousRow.Cells[1].RowSpan == 0)
            //        {
            //            if (row.Cells[1].RowSpan == 0)
            //            {
            //                previousRow.Cells[1].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
            //            }
            //            row.Cells[1].Visible = false;
            //        }
            //    }
            //    Label lblWastage = (Label)row.FindControl("lblWastage");
            //    Label lblWastagePrev = (Label)previousRow.FindControl("lblWastage");

            //    if (lblWastage.Text == lblWastagePrev.Text)
            //    {
            //        if (previousRow.Cells[2].RowSpan == 0)
            //        {
            //            if (row.Cells[2].RowSpan == 0)
            //            {
            //                previousRow.Cells[2].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
            //            }
            //            row.Cells[2].Visible = false;
            //        }
            //    }

            //    Label lblIdealRate = (Label)row.FindControl("lblIdealRate");
            //    Label lblIdealRatePrev = (Label)previousRow.FindControl("lblIdealRate");

            //    if (lblIdealRate.Text == lblIdealRatePrev.Text)
            //    {
            //        if (previousRow.Cells[3].RowSpan == 0)
            //        {
            //            if (row.Cells[3].RowSpan == 0)
            //            {
            //                previousRow.Cells[3].RowSpan += 2;
            //            }
            //            else
            //            {
            //                previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
            //            }
            //            row.Cells[3].Visible = false;
            //        }
            //    }

            //}
        }

        protected void grdSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //    headerRow1.Attributes.Add("class", "HeaderClass");
            //    headerRow2.Attributes.Add("class", "HeaderClass");

            //    TableCell HeaderCell = new TableCell();

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "<Table><tr><td style='border:0px;'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr></table>";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Style.Add("min-width", "200px");
            //    headerRow2.Cells.Add(HeaderCell);


            //    grdSupplier.Controls[0].Controls.AddAt(0, headerRow2);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblsuppliername = (Label)e.Row.FindControl("lblsuppliername");

                //if (lblSize.Text != "")
                //    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";

                Label lblcolorprint = (Label)e.Row.FindControl("lblcolorprint");
                lblcolorprint.Text = ccn;

                Label lblIdealRate = (Label)e.Row.FindControl("lblIdealRate");
                if (qoted.ToString() != "" && qoted>0)
                    lblIdealRate.Text = "<span style='color:green'>₹ </span>" + qoted.ToString();

                Label lblQuotedLandedRate = (Label)e.Row.FindControl("lblQuotedLandedRate");
                if (lblQuotedLandedRate.Text != "")
                    lblQuotedLandedRate.Text = "<span style='color:green'>₹ </span>" + lblQuotedLandedRate.Text;

                Label lblQuotedLeadTime = (Label)e.Row.FindControl("lblQuotedLeadTime");
                if (lblQuotedLeadTime.Text != "")
                    lblQuotedLeadTime.Text = lblQuotedLeadTime.Text != "0" ? "(" + lblQuotedLeadTime.Text + " Days)" : "";

                if (DataBinder.Eval(e.Row.DataItem, "Create_Update_Date") != DBNull.Value)
                {
                    DateTime QuotationDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Create_Update_Date"));

                    if (QuotationDate != DateTime.MinValue)
                        lblsuppliername.Text = lblsuppliername.Text + " (" + QuotationDate.ToString("dd MMM yyyy") + ")";
                }

            }
        }
    }
}