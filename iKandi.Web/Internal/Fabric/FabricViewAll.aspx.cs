
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using iKandi.Common;
using iKandi.Web.Components;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

using Pechkin;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricViewAll : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();

        Designation[] WastageDesig = { Designation.BIPL_Admin, Designation.BIPL_TopManagement_Manager, Designation.BIPL_Sales_Manager, Designation.BIPL_Fabrics_Manager, Designation.BIPL_Fabrics_Assistant, Designation.BIPL_Fabrics_Manager_Fabric_Store };
        Designation[] PoRaiseDesig = { Designation.BIPL_Admin, Designation.BIPL_TopManagement_Manager, Designation.BIPL_Sales_Manager, Designation.BIPL_Fabrics_Manager, Designation.BIPL_Fabrics_Assistant, Designation.BIPL_Fabrics_Manager_Fabric_Store };
        Designation[] PoReviseDesig = { Designation.BIPL_Admin, Designation.BIPL_TopManagement_Manager, Designation.BIPL_Sales_Manager, Designation.BIPL_Fabrics_Manager, Designation.BIPL_Fabrics_Assistant, Designation.BIPL_Fabrics_Manager_Fabric_Store };

        public string Fabtype { get; set; }
        public string TradeName { get; set; }
        public string Userid { get; set; }
        public int IcheckHideCol { get; set; }
        public int MasterPoID { get; set; }
        public int SupplierCount { get; set; }
        public string SupplierPO { get; set; }
        public string SelectedTab { get; set; }
        public string FabricQuality { get; set; }
        public string FabricQualityDetails { get; set; }
        public string MailPoNumber { get; set; }
        public string MailSupplierID { get; set; }
        public string MailIsMailSend { get; set; }
        public string PoSuplytype { get; set; }
        public string SupplyType { get; set; }
        public string MailhdnSessionQ { get; set; }

        public void getquerystring()
        {
            if (Request.QueryString["SupplyType"] != null)
            {
                SupplyType = Request.QueryString["SupplyType"].ToString();
            }
            else
            {
                SupplyType = "GRIEGE";
            }

            if (Request.QueryString["Fabtype"] != null)
            {
                Fabtype = Request.QueryString["Fabtype"].ToString();
                if (Fabtype.ToUpper() == "FINISHING")
                {
                    Fabtype = "FINISHED";
                }
            }
            else
            {
                Fabtype = "GRIEGE";
            }

            if (Request.QueryString["PoSuplytype"] != null)
            {
                PoSuplytype = Request.QueryString["PoSuplytype"].ToString();
                if (PoSuplytype.ToUpper() == "FINISHING") { PoSuplytype = "FINISHED"; }
                if (PoSuplytype.ToUpper() == "PRINTED") { PoSuplytype = "PRINT"; }
            }

            if (Request.QueryString["SupplierPO"] != null)
            {
                SupplierPO = Request.QueryString["SupplierPO"].ToString();
            }
            else
            {
                SupplierPO = "";
            }

            if (Request.QueryString["Po_number"] != null)
            {
                MailPoNumber = Request.QueryString["Po_number"].ToString();
            }
            else
            {
                MailPoNumber = "";
            }

            if (Request.QueryString["SupplierNasterID"] != null)
            {
                MailSupplierID = Request.QueryString["SupplierNasterID"].ToString();
            }
            else
            {
                MailSupplierID = "";
            }
            if (Request.QueryString["IsMailSend"] != null)
            {
                MailIsMailSend = Request.QueryString["IsMailSend"].ToString();
            }
            else
            {
                MailIsMailSend = "";
            }
            if (Request.QueryString["TradeName"] != null)
            {
                TradeName = Request.QueryString["TradeName"].ToString();
            }
            else
            {
                TradeName = "";
            }
            if (Request.QueryString["hdnSessionQ"] != null)
            {
                MailhdnSessionQ = Request.QueryString["hdnSessionQ"].ToString();
            }
            else
            {
                MailhdnSessionQ = "";
            }
        }

        List<FabricGroupAdmin.FabricBasic> fabbasic;
        List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER;
        List<FabricGroupAdmin.FabricStyleSerialDetail> ALLStyleSerialDetail;

        string host = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            host = "http://" + Request.Url.Authority;

            Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID.ToString();

            getquerystring();

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(TradeName)) { txtsearchkeyswords.Text = TradeName; }
                if (Session["q"] != null && Session["q"].ToString() != "")
                {
                    if (MailPoNumber != "")
                    {
                        hdnponumber.Value = MailPoNumber;
                        hdnmasterpoid.Value = MailSupplierID;
                        hdnIsMailSend.Value = MailIsMailSend;
                        hdnSessionQ.Value = Session["q"].ToString();
                        var uri = new Uri(host + "/FabricPurChasedFormPrint.aspx?" + hdnSessionQ.Value);
                        var query = HttpUtility.ParseQueryString(uri.Query);
                        Fabtype = query.Get("Fabtype").ToString();

                        if (hdnIsMailSend.Value != "" && hdnSessionQ.Value != null && hdnSessionQ.Value != "")
                        {
                            randorHtml();
                        }
                    }

                    if (SupplyType == null || SupplyType == "")
                        SupplyType = "GRIEGE";
                    else
                        hdnFabtype.Value = SupplyType;

                    rdb_SortBY.SelectedValue = "1";
                    btnSearch_Click(sender, e);
                }
                else
                {
                    hdnIsMailSend.Value = "";

                    if (hdnFabtype.Value == null || hdnFabtype.Value == "")
                        hdnFabtype.Value = "GRIEGE";
                    else
                        hdnFabtype.Value = SupplyType;

                    if (!string.IsNullOrEmpty(PoSuplytype))
                    { Fabtype = PoSuplytype; hdnFabtype.Value = PoSuplytype; }

                    rdb_SortBY.SelectedValue = "1";

                    BindAll(hdnFabtype.Value);
                    SetTab();
                }
            }

            Session["q"] = null;
            hdnSessionQ.Value = "";
            if (Request.RawUrl.Contains("#"))
            {
                string s = HttpUtility.UrlEncode(Request.RawUrl);
                HttpContext.Current.Server.UrlEncode(Request.RawUrl);
            }
        }

        #region Commman For All

        protected void LinkSupplyTab_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            hdnFabtype.Value = btn.CommandArgument;
            BindAll(hdnFabtype.Value);
            SetTab();
        }

        private void BindAll(string Refreshgrd)
        {
            if (Refreshgrd == "GRIEGE") // For Griege
            {
                GetDetailFromDataBase("GRIEGE");
                if (fabbasic.Count > 0)
                {
                    grdGRIEGE.DataSource = fabbasic;
                    grdGRIEGE.DataBind();

                    // To Compile Data and send Again to Database 
                    SaveGerigeData();

                    // To Rebind Data from Database
                    GetDetailFromDataBase("GRIEGE");
                    grdGRIEGE.DataSource = fabbasic;
                    grdGRIEGE.DataBind();
                    MergeRowsgrige(grdGRIEGE);
                }
                else
                {
                    grdGRIEGE.DataSource = null;
                    grdGRIEGE.DataBind();
                }
            }
            else if (Refreshgrd == "DYED") // For DYED
            {
                GetDetailFromDataBase("DYED");
                if (fabbasic.Count > 0)
                {
                    grdDYED.DataSource = fabbasic;
                    grdDYED.DataBind();

                    // To Compile Data and send Again to Database 
                    SaveDayedData();

                    // To Rebind Data from Database
                    GetDetailFromDataBase("DYED");
                    grdDYED.DataSource = fabbasic;
                    grdDYED.DataBind();

                    MergeRowsPrint(grdDYED);


                }
                else
                {
                    grdDYED.DataSource = null;
                    grdDYED.DataBind();
                }
            }
            else if (Refreshgrd == "PRINT")  // for Print
            {
                GetDetailFromDataBase("PRINT");
                if (fabbasic.Count > 0)
                {
                    grdPRINT.DataSource = fabbasic;
                    grdPRINT.DataBind();

                    // To Compile Data and send Again to Database 
                    SavePrintData();

                    // To Rebind Data from Database
                    GetDetailFromDataBase("PRINT");
                    grdPRINT.DataSource = fabbasic;
                    grdPRINT.DataBind();
                    MergeRowsPrint(grdPRINT);
                }
                else
                {
                    grdPRINT.DataSource = null;
                    grdPRINT.DataBind();
                }
            }
            else if (Refreshgrd == "FINISHED") // For FINISHED
            {
                GetDetailFromDataBase("FINISHED");
                if (fabbasic.Count > 0)
                {
                    grdFINISHED.DataSource = fabbasic;
                    grdFINISHED.DataBind();

                    // To Compile Data and send Again to Database 
                    SaveFinishData();

                    // To Rebind Data from Database
                    GetDetailFromDataBase("FINISHED");
                    grdFINISHED.DataSource = fabbasic;
                    grdFINISHED.DataBind();

                }
                else
                {
                    grdFINISHED.DataSource = null;
                    grdFINISHED.DataBind();
                }
            }
            else if (Refreshgrd == "RFD") // For RFD
            {
                GetDetailFromDataBase("RFD");
                if (fabbasic.Count > 0)
                {
                    grdRFD.DataSource = fabbasic;
                    grdRFD.DataBind();

                    // To Compile Data and send Again to Database 
                    SaveRFDData();

                    // To Rebind Data from Database
                    GetDetailFromDataBase("RFD");
                    grdRFD.DataSource = fabbasic;
                    grdRFD.DataBind();
                    MergeRowsPrint(grdRFD);
                }
                else
                {
                    grdRFD.DataSource = null;
                    grdRFD.DataBind();
                }
            }
            else if (Refreshgrd == "EMBELLISHMENT") // For EMBELLISHMENT
            {
                GetDetailFromDataBase("EMBELLISHMENT");
                if (fabbasic.Count > 0)
                {
                    grdEMBELLISHMENT.DataSource = fabbasic;
                    grdEMBELLISHMENT.DataBind();

                    // To Compile Data and send Again to Database 
                    SaveEmbellishmentData();

                    // To Rebind Data from Database
                    GetDetailFromDataBase("EMBELLISHMENT");
                    grdEMBELLISHMENT.DataSource = fabbasic;
                    grdEMBELLISHMENT.DataBind();
                    MergeRowsPrint(grdEMBELLISHMENT);
                }
                else
                {
                    grdEMBELLISHMENT.DataSource = null;
                    grdEMBELLISHMENT.DataBind();
                }

            }
            else if (Refreshgrd == "EMBROIDERY") // For EMBROIDERY
            {
                GetDetailFromDataBase("EMBROIDERY");
                if (fabbasic.Count > 0)
                {
                    grdEMBROIDERY.DataSource = fabbasic;
                    grdEMBROIDERY.DataBind();

                    // To Compile Data and send Again to Database 
                    SaveEmbroideryData();

                    // To Rebind Data from Database
                    GetDetailFromDataBase("EMBROIDERY");
                    grdEMBROIDERY.DataSource = fabbasic;
                    grdEMBROIDERY.DataBind();
                    MergeRowsPrint(grdEMBROIDERY);
                }
                else
                {
                    grdEMBROIDERY.DataSource = null;
                    grdEMBROIDERY.DataBind();
                }
            }

            margerows(Refreshgrd);
        }

        public void SetTab()
        {
            if (hdnFabtype.Value != null)
            {
                string SupplyTypeTab = hdnFabtype.Value;

                LnkGRIEGE.Attributes.Remove("class");
                LnkDYED.Attributes.Remove("class");
                LnkPRINT.Attributes.Remove("class");
                LnkFINISHED.Attributes.Remove("class");
                LnkRFD.Attributes.Remove("class");
                LnkEMBELLISHMENT.Attributes.Remove("class");
                LnkEMBROIDERY.Attributes.Remove("class");

                DivGRIEGE.Style.Add("display", "none");
                DivDYED.Style.Add("display", "none");
                DivPRINT.Style.Add("display", "none");
                DivFINISHED.Style.Add("display", "none");
                DivRFD.Style.Add("display", "none");
                DivEMBELLISHMENT.Style.Add("display", "none");
                DivEMBROIDERY.Style.Add("display", "none");

                switch (SupplyTypeTab)
                {
                    case "GRIEGE":
                        DivGRIEGE.Style.Add("display", "block");
                        LnkGRIEGE.Attributes.Add("class", "activeback");
                        break;
                    case "DYED":
                        DivDYED.Style.Add("display", "block");
                        LnkDYED.Attributes.Add("class", "activeback");
                        break;
                    case "PRINT":
                        DivPRINT.Style.Add("display", "block");
                        LnkPRINT.Attributes.Add("class", "activeback");
                        break;
                    case "FINISHED":
                        DivFINISHED.Style.Add("display", "block");
                        LnkFINISHED.Attributes.Add("class", "activeback");
                        break;
                    case "RFD":
                        DivRFD.Style.Add("display", "block");
                        LnkRFD.Attributes.Add("class", "activeback");
                        break;
                    case "EMBELLISHMENT":
                        DivEMBELLISHMENT.Style.Add("display", "block");
                        LnkEMBELLISHMENT.Attributes.Add("class", "activeback");
                        break;
                    case "EMBROIDERY":
                        DivEMBROIDERY.Style.Add("display", "block");
                        LnkEMBROIDERY.Attributes.Add("class", "activeback ");
                        break;
                    default:
                        goto case "GRIEGE";

                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAll(hdnFabtype.Value);
            SetTab();

        }

        private void GetDetailFromDataBase(string StageName)
        {
            fabbasic = new List<FabricGroupAdmin.FabricBasic>();

            ALLStyleSerialDetail = new List<FabricGroupAdmin.FabricStyleSerialDetail>();
            ALLRERAISESUPPLIER = new List<FabricGroupAdmin.FabricReRaiseDetails>();

            DataSet ds = fabobj.GetfabricViewdetailsNew(StageName, "GET", 0, 0, "", txtsearchkeyswords.Text.Trim(), 0, 0, 0, false, 0, 0, 0, 0, 0, rdb_SortBY.SelectedValue == string.Empty ? 1 : Convert.ToInt32(rdb_SortBY.SelectedValue));
            fabbasic = ConvertDataTable<FabricGroupAdmin.FabricBasic>(ds.Tables[0]);

            ALLStyleSerialDetail = ConvertDataTable<FabricGroupAdmin.FabricStyleSerialDetail>(ds.Tables[1]);
            ALLRERAISESUPPLIER = ConvertDataTable<FabricGroupAdmin.FabricReRaiseDetails>(ds.Tables[2]);


        }

        private List<FabricGroupAdmin.FabricReRaiseDetails> GetALLRERAISESUPPLIER(string StageName)
        {
            DataTable dt = fabobj.GetfabricViewdetailsNew(StageName, "ALLRERAISESUPPLIER", 0, 0, "", txtsearchkeyswords.Text.Trim()).Tables[0];
            return ConvertDataTable<FabricGroupAdmin.FabricReRaiseDetails>(dt);
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        try
                        {
                            object value = dr[column.ColumnName];
                            if (value == DBNull.Value) value = null;
                            pro.SetValue(obj, value, null);
                        }
                        catch
                        {
                            pro.SetValue(obj, null, null);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }

        private string PoNumberWithLink(bool IsJuniorSignatory, bool IsAuthorizedSignatory, bool IsPartySignature, string PO_Number)
        {
            string PoLink = "<tr>   <td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99; text-align:left;'> <a target='_blank'  class='per' ";

            if (IsJuniorSignatory == false && IsAuthorizedSignatory == false) // No Signature
            {
                PoLink += " style='color: #d5334b !important;text-decoration: none;' ";
            }
            else if (IsJuniorSignatory == true && IsAuthorizedSignatory == false) // only Junier Sign
            {
                PoLink += " style='color: #ff8c6a !important; text-decoration: none;' ";
            }
            else if (IsJuniorSignatory == true && IsAuthorizedSignatory == true && IsPartySignature == false) // only Junier & GM Sign
            {
                PoLink += " style='color: #515354 !important; text-decoration: none;' ";
            }
            else if (IsJuniorSignatory == true && IsAuthorizedSignatory == true && IsPartySignature == true) // All Sign
            {
                PoLink += " style='text-decoration: none;' href='FrmWorkingOnRaisedPO.aspx?PONumber=" + Server.UrlEncode(PO_Number) + "&postatus=0' ";
            }

            PoLink += " > " + PO_Number + " </a></td>   </tr>";

            return PoLink;
        }
        #endregion

        #region Griege  -- 1
        protected void grdGRIEGE_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int SupplierMasterID = 0;

            #region Header Creation
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fabric Quality (Unit)";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.Style.Add("padding-top", "0px!important");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Count Construction";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "80px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "50px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "50px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleNumber ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SerialNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity Breakdown";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdGRIEGE.Controls[0].Controls.AddAt(0, headerRow2);




            }
            #endregion

            #region Data Row Creation
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");

                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigedShrinkage = (TextBox)e.Row.FindControl("txtGreigedShrinkage");
                TextBox txtResidualSh = (TextBox)e.Row.FindControl("txtResidualSh");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                Label lblresidualshrink = (Label)e.Row.FindControl("lblresidualshrink");
                CheckBox chkApplyResShrinkage = (CheckBox)e.Row.FindControl("chkApplyResShrinkage");
                GridView grdstylenumber = (GridView)e.Row.FindControl("grdstylenumber");
                GridView grdserialnumber = (GridView)e.Row.FindControl("grdserialnumber");


                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");

                Label lbladjustmentqtyy = (Label)e.Row.FindControl("lbladjustmentqtyy");

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                Label ToReceive = (Label)e.Row.FindControl("ToReceive");

                HtmlControl balancetooltipp = (HtmlControl)e.Row.FindControl("balancetooltipp");
                //Label lblQutationCount = (Label)e.Row.FindControl("lblQutationCount");

                List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)).ToList();
                List<FabricGroupAdmin.FabricReRaiseDetails> ReRaiseSupplierDetail = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)).ToList();

                if (lblbalanceinhouseqty.Text != "")
                {
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:black'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.Text = "Adjustment qty from further stage:";
                        lbladjustmentqtyy.Text = hdnadjustmentqty.Value.ToString();

                        lblBalanceTooltip.CssClass = "TooltipTxt";
                        balancetooltipp.Attributes.Add("style", "display:Contents");
                    }
                }

                txtGreigedShrinkage.Attributes.Add("onchange", "javascript:UpdateGrige(this," + hdnfabricQuality.Value + ");");
                txtResidualSh.Attributes.Add("onchange", "javascript:showhideresidualshrinke(this);");

                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + "</span> ";

                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigedShrinkage.Text == "" ? "0" : txtGreigedShrinkage.Text;

                if (chkApplyResShrinkage.Checked)
                {
                    Residual = txtResidualSh.Text;
                }

                if (StyleSerialDetail.Count() > 0)
                {
                    grdstylenumber.DataSource = StyleSerialDetail;
                    grdstylenumber.DataBind();

                    grdserialnumber.DataSource = StyleSerialDetail;
                    grdserialnumber.DataBind();


                }


                lblFabQtyRemaning.Text = StyleSerialDetail[0].RemainingFabQty == 0 ? "" : StyleSerialDetail[0].RemainingFabQty.ToString();
                lblfabricorderavg.Text = StyleSerialDetail[0].TotalReuiredFabQty == 0 ? "" : Convert.ToDecimal(StyleSerialDetail[0].TotalReuiredFabQty).ToString("N0");
                lblfabricorderavg2.Text = StyleSerialDetail[0].TotalReuiredFabQty == 0 ? "" : Convert.ToDecimal(StyleSerialDetail[0].TotalReuiredFabQty).ToString("N0");
                lblFabQtyRemaning2.Text = StyleSerialDetail[0].TotalReuiredFabQty == 0 ? "" : Convert.ToDecimal(StyleSerialDetail[0].TotalReuiredFabQty).ToString("N0");
                lblTotalFabRequired.Text = StyleSerialDetail[0].TotalReuiredFabQty == 0 ? "" : StyleSerialDetail[0].TotalReuiredFabQty.ToString();
                lblresidualshrink.Text = StyleSerialDetail[0].Residual_Sh == 0 ? "" : StyleSerialDetail[0].Residual_Sh.ToString();
                lblcutwastgae.Text = StyleSerialDetail[0].CuttingWastage == 0 ? "" : StyleSerialDetail[0].CuttingWastage.ToString();
                cutwastage = lblcutwastgae.Text == "" ? "0" : lblcutwastgae.Text;
                lblrequiredqty.Text = StyleSerialDetail[0].FabricRequiredQty == 0 ? "" : Convert.ToDecimal(StyleSerialDetail[0].FabricRequiredQty).ToString("N0");

                if (WastageDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdmin('" + 1 + "','" + hdnfabricQuality.Value + "','" + "FabricDetails" + "','" + cutwastage + "');");
                }

                //if (Convert.ToInt16(lblQutationCount.Text) <= 0)
                //{
                //    divraise.Attributes.Add("Class", "HideRaisebtn");
                //}

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].RemaningQty != 0 && ReRaiseSupplierDetail[0].RemaningQty.ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(ReRaiseSupplierDetail[0].RemaningQty).ToString("N0");

                    }
                }
                else if (StyleSerialDetail.Count > 0)
                {
                    pendingQtyinorder.Text = Convert.ToDecimal(StyleSerialDetail[0].FabricQtyToOrder - Convert.ToInt32(lblbalanceinhouseqty.Text == "" ? "0" : lblbalanceinhouseqty.Text)).ToString("N0");
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat(PoNumberWithLink(FabricReRaiseDetails.IsJuniorSignatory, FabricReRaiseDetails.IsAuthorizedSignatory, FabricReRaiseDetails.IsPartySignature, FabricReRaiseDetails.PO_Number));
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[11].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99; text-align:left;padding-left:5px;padding-left:5px;'>" + FabricReRaiseDetails.SupplierName + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    int HoldQty = 0;
                    int CancelQty = 0;
                    int PoReceiveQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {

                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                            {
                                Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                                PoReceiveQty = PoReceiveQty + Convert.ToInt32(FabricReRaiseDetails.ReceivedQty);

                            }

                            HoldQty = HoldQty + FabricReRaiseDetails.HoldQty;
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }

                    if (PoReceiveQty > 0)
                    {
                        ToReceive.Text = PoReceiveQty.ToString("N0");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();
                    //pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }
                decimal Qtys = 0;
                if (ReRaiseSupplierDetail.Count() > 0)
                {

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        string Qty = "";
                        MasterPoID = FabricReRaiseDetails.MasterPO_Id;
                        SupplierMasterID = FabricReRaiseDetails.SupplierID;

                        if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                        {
                            Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                        }

                        if (FabricReRaiseDetails.PoStatus == 1 || FabricReRaiseDetails.PoStatus == 2)
                        {
                            string Status = "";
                            if (FabricReRaiseDetails.PoStatus == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (FabricReRaiseDetails.PoStatus == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {
                                if (Residual == "") { Residual = "0"; }

                                if (geriege == "") { geriege = "0"; }

                                if (cutwastage == "") { cutwastage = "0"; }

                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();

                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail.Where(x => x.PoStatus != 1 && x.ReceivedQty > 0))
                    {
                        Qtys += FabricReRaiseDetails.ReceivedQty;
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();

                }
                decimal Remaning = lblFabQtyRemaning2.Text == "" ? 0 : Convert.ToDecimal(lblFabQtyRemaning2.Text);
                decimal balanceInhOuse = lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToDecimal(lblbalanceinhouseqty.Text);
                if (lblFabQtyRemaning2.Text != "")
                {
                    decimal _cutwastage = lblcutwastgae.Text == "" ? 0 : Convert.ToDecimal(lblcutwastgae.Text);
                    decimal Totalre = ((Convert.ToDecimal(lblFabQtyRemaning2.Text) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - (Convert.ToDecimal(_cutwastage))));

                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if (PoRaiseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + txtGreigedShrinkage.Text + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('You do not have permission');");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            //  divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblcolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");

                Label lblArchieveQty = (Label)e.Row.FindControl("lblArchieveQty");
                HtmlTableRow trArchieveRow = e.Row.FindControl("trArchieveRow") as HtmlTableRow;

                //below added by Girish on 2023-03-31
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].QtyInArchieve > 0)
                    {
                        trArchieveRow.Visible = true;
                        lblArchieveQty.Text = ReRaiseSupplierDetail[0].QtyInArchieve.ToString("N0");
                        lblArchieveQty.ToolTip = "Sum Of Required Qty. Of Contracts Whose PO's are Still Open But Contracts are either Shipped/Cut Issue Completed.";
                        pendingQtyinorder.ToolTip = "(" + lblfabricorderavg2.Text +
                                                   " + " + lblArchieveQty.Text +
                                                   ")" + (lblbalanceinhouseqty.Text == "" ? "" : " - " + lblbalanceinhouseqty.Text) +
                                                   " - " + ToReceive.Text;
                    }
                    else
                    {
                        trArchieveRow.Visible = false;
                    }
                }

            }
            #endregion
        }
        public void SaveGerigeData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox) { ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", ""); }
                else if (x is Label) { ((Label)x).Text = ((Label)x).Text.Replace(",", ""); }
            }
            List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER = GetALLRERAISESUPPLIER("GRIEGE");
            List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets = new List<FabricGroupAdmin.FabricOrderAllUpdate>();

            int Qty = 0;
            int CancelQty = 0;
            int DeleteQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;

            int QtyInArchieve = 0;

            foreach (GridViewRow row in grdGRIEGE.Rows)
            {
                FabricGroupAdmin.FabricOrderAllUpdate Fabdet = new FabricGroupAdmin.FabricOrderAllUpdate();
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                TextBox txtGreigedShrinkage = (TextBox)row.FindControl("txtGreigedShrinkage");
                TextBox txtResidualSh = (TextBox)row.FindControl("txtResidualSh");
                CheckBox chkApplyResShrinkage = (CheckBox)row.FindControl("chkApplyResShrinkage");
                Label QtyToOrder = (Label)row.FindControl("lblfabricorderavg");
                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning2");

                int bal = (lblbalanceinhouseqty.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(lblbalanceinhouseqty.Text)))));

                int counter = 1;

                foreach (var RERAISESUPPLIER in ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)))
                {
                    if (RERAISESUPPLIER.ReceivedQty > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Cancel)
                        {
                            Qty += RERAISESUPPLIER.ReceivedQty;
                            HoldQty += RERAISESUPPLIER.HoldQty;
                        }
                    }
                    if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + RERAISESUPPLIER.ReceivedQty;
                    }
                    if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Close)
                    {
                        DeleteQty = DeleteQty + RERAISESUPPLIER.ReceivedQty;
                    }
                    CancelPoQty = CancelPoQty + RERAISESUPPLIER.CancelPoQty;

                    //below added by Girish on 2023-03-31
                    if (counter == 1)
                    {
                        QtyInArchieve = Convert.ToInt32(Math.Round(RERAISESUPPLIER.QtyInArchieve, 0));
                    }

                    counter++;
                }

                Qty = Qty - CancelPoQty;

                Fabdet.Fabric_QualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.GreigedShrinkage = (txtGreigedShrinkage.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigedShrinkage.Text));
                Fabdet.QtyToOrder = (PendingQtyToOrder.Text == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text))));
                if (chkApplyResShrinkage.Checked)
                {
                    Fabdet.ResidualShrinkage = (txtResidualSh.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualSh.Text));
                    Fabdet.IsResidualShrinkage = true;
                }
                else
                {
                    Fabdet.ResidualShrinkage = 0;
                    Fabdet.IsResidualShrinkage = false;
                }
                Fabdet.PendingQtyToOrder = PendingQtyToOrder.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text.Replace(",", "")))) - (Qty + HoldQty + bal)) + QtyInArchieve; //added by Girish
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                Qty = 0;
                CancelQty = 0;
                DeleteQty = 0;
                HoldQty = 0;
                CancelPoQty = 0;
                Fabdets.Add(Fabdet);

            }
            // Have to write function to save
            bool IsSave = fabobj.FabricOrderAllUpdateToProc("GRIEGE", "ALLUPDATE", Fabdets);
        }
        #endregion

        #region DYED  -- 2
        protected void grdDYED_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Header Creation
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "<table><tr><td colspan='3' style='border:0px;'>Fabric Quality (Unit)</td></tr><tr><td>Current Stage</td><td>Previous Stage</td><td>Style Specific</td></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "CountConstruction";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "80px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "50px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "50px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ColorPrint";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "110px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleNumber";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "80px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SerialNumber";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "80px");
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Rcvd. Qty.";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity Breakdown";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdDYED.Controls[0].Controls.AddAt(0, headerRow2);

            }
            #endregion
            #region Data Row Creation
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds;
                DataTable dt;
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");

                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label txtqtytosend = (Label)e.Row.FindControl("txtqtytosend");

                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");

                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                //Label lblQutationCount = (Label)e.Row.FindControl("lblQutationCount");
                HiddenField hdnGreigeshrk = (HiddenField)e.Row.FindControl("hdnGreigeshrk");

                Label ToReceive_Dyed = (Label)e.Row.FindControl("ToReceive_Dyed");

                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                GridView grdserialnumber = e.Row.FindControl("grdserialnumber") as GridView;

                Label lbladjustmentqtyy = (Label)e.Row.FindControl("lbladjustmentqtyy");

                List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = new List<FabricGroupAdmin.FabricStyleSerialDetail>();

                if (Convert.ToBoolean(hdnIsStyleSpecific.Value) == true)
                {
                    //List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                    StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                                                                                                                        && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()
                                                                                                                       && x.CurrentStage == Convert.ToInt32(hdnCurrentstage.Value)
                                                                                                                       && x.PreviousStage == Convert.ToInt32(hdnperiviousstgae.Value)
                                                                                                                        && x.StyleID == (Convert.ToBoolean(hdnIsStyleSpecific.Value) == false ? -1 : Convert.ToInt32(hdnStyleID.Value))
                                                                                                                       ).ToList();
                }
                else
                {
                    StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                                                                                                                      && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()
                                                                                                                      && x.CurrentStage == Convert.ToInt32(hdnCurrentstage.Value)
                                                                                                                      && x.PreviousStage == Convert.ToInt32(hdnperiviousstgae.Value)
                        //&& x.StyleID == (Convert.ToBoolean(hdnIsStyleSpecific.Value) == false ? -1 : Convert.ToInt32(hdnStyleID.Value))
                                                                                                                      ).ToList();
                }
                List<FabricGroupAdmin.FabricReRaiseDetails> ReRaiseSupplierDetail = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                                                                                                                  && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()
                                                                                                                  && x.CurrentStage == Convert.ToInt32(hdnCurrentstage.Value)
                                                                                                                  && x.PreviousStage == Convert.ToInt32(hdnperiviousstgae.Value)
                                                                                                                  && x.IsStyleSpecific == Convert.ToBoolean(hdnIsStyleSpecific.Value)
                                                                                                                  && x.StyleID == (Convert.ToBoolean(hdnIsStyleSpecific.Value) == false ? -1 : Convert.ToInt32(hdnStyleID.Value))
                                                                                                                  ).ToList();


                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                HtmlControl balancetooltipp = (HtmlControl)e.Row.FindControl("balancetooltipp");


                if (lblbalanceinhouseqty.Text != "")
                {
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:black'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.Text = "Adjustment qty from further stage:";
                        lbladjustmentqtyy.Text = hdnadjustmentqty.Value.ToString();

                        lblBalanceTooltip.CssClass = "TooltipTxt";
                        balancetooltipp.Attributes.Add("style", "display:Contents");

                    }
                }
                if (StyleSerialDetail.Count > 0)
                {
                    grdstylenumber.DataSource = StyleSerialDetail;
                    grdstylenumber.DataBind();

                    grdserialnumber.DataSource = StyleSerialDetail;
                    grdserialnumber.DataBind();

                    lblfabricQty.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblFabQtyToOrder.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = StyleSerialDetail[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = StyleSerialDetail[0].FabricRequiredQty.ToString("N0");


                }
                //LabelTotal.Text = Convert.ToString(Convert.ToInt32(Labelactual.Text) + Convert.ToInt32(LabelShippedButNotIssued.Text) + Convert.ToInt32(LabelShippedAndIssued.Text));


                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "") { IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1); }

                if (WastageDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 2 + "','" + hdnfabricQuality.Value + "','" + lblfabriccolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "','" + lblcutwastgae.Text + "');");
                }


                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = hdnGreigeshrk.Value == "" ? "0" : hdnGreigeshrk.Value;
                Residual = txtResidualShak.Text == "" ? "0" : txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text == "" ? "0" : lblcutwastgae.Text;
                if (txtResidualShak.Text == "0") { txtResidualShak.Text = ""; }

                //if (Convert.ToInt16(lblQutationCount.Text) <= 0)
                //{
                //    divraise.Attributes.Add("Class", "HideRaisebtn");
                //}

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].RemaningQty != 0 && ReRaiseSupplierDetail[0].RemaningQty.ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(ReRaiseSupplierDetail[0].RemaningQty).ToString("N0");
                    }
                }
                else if (StyleSerialDetail.Count > 0)
                {
                    pendingQtyinorder.Text = Convert.ToDecimal(StyleSerialDetail[0].FabricQtyToOrder - Convert.ToInt32(lblbalanceinhouseqty.Text == "" ? "0" : lblbalanceinhouseqty.Text)).ToString("N0");
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat(PoNumberWithLink(FabricReRaiseDetails.IsJuniorSignatory, FabricReRaiseDetails.IsAuthorizedSignatory, FabricReRaiseDetails.IsPartySignature, FabricReRaiseDetails.PO_Number));
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;text-align:left;'>" + FabricReRaiseDetails.SupplierName + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    int PoReceiveQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                            {
                                Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                                PoReceiveQty = PoReceiveQty + Convert.ToInt32(FabricReRaiseDetails.ReceivedQty);
                            }
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    if (PoReceiveQty > 0)
                    {
                        ToReceive_Dyed.Text = PoReceiveQty.ToString("N0");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[16].Text = sb.ToString();
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        string Qty = "";
                        MasterPoID = FabricReRaiseDetails.MasterPO_Id;
                        SupplierMasterID = FabricReRaiseDetails.SupplierID;
                        if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                        {
                            Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                        }
                        if (FabricReRaiseDetails.PoStatus == 1 || FabricReRaiseDetails.PoStatus == 2)
                        {
                            string Status = "";
                            if (FabricReRaiseDetails.PoStatus == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (FabricReRaiseDetails.PoStatus == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblfabriccolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[17].Text = sb.ToString();
                    decimal Qtys = 0;
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail.Where(x => x.PoStatus != 1 && x.SendQty > 0))
                    {
                        Qtys += FabricReRaiseDetails.SendQty;
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(Qtys, 0).ToString("N0");
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                    }
                    else
                    {
                        if (PoRaiseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblfabriccolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");

                Label lblArchieveQty = (Label)e.Row.FindControl("lblArchieveQty");
                HtmlTableRow trArchieveRow = e.Row.FindControl("trArchieveRow") as HtmlTableRow;

                //below added by Girish on 2023-03-31
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].QtyInArchieve > 0)
                    {
                        trArchieveRow.Visible = true;
                        lblArchieveQty.Text = ReRaiseSupplierDetail[0].QtyInArchieve.ToString("N0");
                        lblArchieveQty.ToolTip = "Sum Of Required Qty. Of Contracts Whose PO's are Still Open But Contracts are either Shipped/Cut Issue Completed.";
                        pendingQtyinorder.ToolTip = "(" + lblfabricQty.Text +
                                                   " + " + lblArchieveQty.Text +
                                                   ")" + (lblbalanceinhouseqty.Text == "" ? "" : " - " + lblbalanceinhouseqty.Text) +
                                                   " - " + txtqtytosend.Text;
                    }
                    else
                    {
                        trArchieveRow.Visible = false;
                    }
                }

            }
            #endregion
        }
        public void SaveDayedData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox) { ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", ""); }
                else if (x is Label) { ((Label)x).Text = ((Label)x).Text.Replace(",", ""); }
            }
            List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER = GetALLRERAISESUPPLIER("DYED");
            List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets = new List<FabricGroupAdmin.FabricOrderAllUpdate>();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;

            int QtyInArchieve = 0;

            int counter = 1;

            List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = new List<FabricGroupAdmin.FabricStyleSerialDetail>();

            foreach (GridViewRow row in grdDYED.Rows)
            {
                FabricGroupAdmin.FabricOrderAllUpdate Fabdet = new FabricGroupAdmin.FabricOrderAllUpdate();
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");

                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");

                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");
                HiddenField hdnfabprint = (HiddenField)row.FindControl("hdnfabprint");

                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;

                Fabdet.SendQty = 0;
                List<FabricGroupAdmin.FabricReRaiseDetails> FabricAllReRaiseSupplyer = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                                                                                                                     && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()
                                                                                                                     && x.CurrentStage == Convert.ToInt32(hdnCurrentstage.Value)
                                                                                                                     && x.PreviousStage == Convert.ToInt32(hdnperiviousstgae.Value)
                                                                                                                     && x.IsStyleSpecific == Convert.ToBoolean(hdnIsStyleSpecific.Value)
                                                                                                                     && x.StyleID == (Convert.ToBoolean(hdnIsStyleSpecific.Value) == false ? -1 : Convert.ToInt32(hdnStyleID.Value))
                                                                                                                     ).ToList();

                foreach (var RERAISESUPPLIER in FabricAllReRaiseSupplyer)
                {
                    if (RERAISESUPPLIER.ReceivedQty > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + RERAISESUPPLIER.ReceivedQty;
                            Fabdet.SendQty = Fabdet.SendQty + RERAISESUPPLIER.SendQty;
                            HoldQty = HoldQty + RERAISESUPPLIER.HoldQty;
                        }
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) == FabricPOStatus.Cancel)
                        {
                            CancelQty = CancelQty + RERAISESUPPLIER.SendQty;
                        }
                    }
                    CancelPoQty = CancelPoQty + RERAISESUPPLIER.CancelPoQty;

                    //below added by Girish on 2023-03-31
                    if (counter == 1)
                    {
                        QtyInArchieve = Convert.ToInt32(Math.Round(RERAISESUPPLIER.QtyInArchieve, 0));
                    }
                    counter++;
                }

                Fabdet.Fabric_QualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));//check shubhendu
                Fabdet.BallanceInHouse = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""))); // qty from stock

                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty) - (Fabdet.BallanceInHouse));

                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;

                int fabricQty = 0;
                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));

                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - Convert.ToInt32(hdnPreviousadjustmentqty.Value)) + QtyInArchieve;  //added by Girish;
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty)));
                }

                Fabdet.PrintName = hdnfabprint.Value;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.Stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.Stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.Stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.Stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleId = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.CurrentstageNumber = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.PrevStageType = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);

                Qty = 0;
                CancelQty = 0;
                HoldQty = 0;
                CancelPoQty = 0;

                Fabdets.Add(Fabdet);
            }

            bool IsSave = fabobj.FabricOrderAllUpdateToProc("DYED", "ALLUPDATE", Fabdets);
        }
        #endregion

        #region Print  -- 3
        protected void grdPRINT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Header Creation
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<table><tr><td colspan='3' style='border:0px;'>Fabric Quality (Unit)</td></tr><tr><td>Current Stage</td><td>Previous Stage</td><td>Style Specific</td></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "CountConstruction";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ColorPrint";
                HeaderCell.Style.Add("Width", "110px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SerialNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity Breakdown";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdPRINT.Controls[0].Controls.AddAt(0, headerRow2);

            }
            #endregion

            #region Data Row Creation
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");

                //Label lblQutationCount = (Label)e.Row.FindControl("lblQutationCount");

                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Label txtqtytosend = (Label)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                GridView grdserialnumber = e.Row.FindControl("grdserialnumber") as GridView;

                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");
                HiddenField hdnGreigeshrk = (HiddenField)e.Row.FindControl("hdnGreigeshrk");

                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");

                Label ToReceive_Print = (Label)e.Row.FindControl("ToReceive_Print");

                Label lbladjustmentqtyy = (Label)e.Row.FindControl("lbladjustmentqtyy");
                HtmlControl balancetooltipp = (HtmlControl)e.Row.FindControl("balancetooltipp");


                List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                                                                                                                && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()
                                                                                                                && x.CurrentStage == Convert.ToInt32(hdnCurrentstage.Value)
                                                                                                                && x.PreviousStage == Convert.ToInt32(hdnperiviousstgae.Value)
                                                                                                                ).ToList();
                List<FabricGroupAdmin.FabricReRaiseDetails> ReRaiseSupplierDetail = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                                                                                                                && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()
                                                                                                                && x.CurrentStage == Convert.ToInt32(hdnCurrentstage.Value)
                                                                                                                && x.PreviousStage == Convert.ToInt32(hdnperiviousstgae.Value)
                                                                                                                && x.IsStyleSpecific == Convert.ToBoolean(hdnIsStyleSpecific.Value)
                                                                                                                && x.StyleID == (Convert.ToBoolean(hdnIsStyleSpecific.Value) == false ? -1 : Convert.ToInt32(hdnStyleID.Value))
                                                                                                                ).ToList();

                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";
                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:black'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.Text = "Adjustment qty from further stage:";
                        lbladjustmentqtyy.Text = hdnadjustmentqty.Value.ToString();

                        lblBalanceTooltip.CssClass = "TooltipTxt";
                        balancetooltipp.Attributes.Add("style", "display:Contents");
                    }
                }

                if (StyleSerialDetail.Count > 0)
                {
                    grdstylenumber.DataSource = StyleSerialDetail;
                    grdstylenumber.DataBind();

                    grdserialnumber.DataSource = StyleSerialDetail;
                    grdserialnumber.DataBind();

                    lblfabricQty.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblFabQtyToOrder.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = StyleSerialDetail[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = StyleSerialDetail[0].FabricRequiredQty.ToString("N0");


                }
                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "") { IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1); }

                if (WastageDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "") { IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1); }
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 3 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "','" + lblcutwastgae.Text + "');");
                }


                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = hdnGreigeshrk.Value == "" ? "0" : hdnGreigeshrk.Value;
                Residual = txtResidualShak.Text == "" ? "0" : txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text == "" ? "0" : lblcutwastgae.Text;
                if (txtResidualShak.Text == "0")
                {
                    txtResidualShak.Text = "";
                }
                //if (Convert.ToInt16(lblQutationCount.Text) <= 0)
                //{
                //    divraise.Attributes.Add("Class", "HideRaisebtn");
                //}


                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].RemaningQty != 0 && ReRaiseSupplierDetail[0].RemaningQty.ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(ReRaiseSupplierDetail[0].RemaningQty).ToString("N0");
                    }
                }
                else if (StyleSerialDetail.Count > 0)
                {
                    pendingQtyinorder.Text = Convert.ToDecimal(StyleSerialDetail[0].FabricQtyToOrder - Convert.ToInt32(lblbalanceinhouseqty.Text == "" ? "0" : lblbalanceinhouseqty.Text)).ToString("N0");
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat(PoNumberWithLink(FabricReRaiseDetails.IsJuniorSignatory, FabricReRaiseDetails.IsAuthorizedSignatory, FabricReRaiseDetails.IsPartySignature, FabricReRaiseDetails.PO_Number));
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 70px;text-align:left;'>" + FabricReRaiseDetails.SupplierName + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    int HoldQty = 0;
                    int PoReceiveQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                            {
                                Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                                PoReceiveQty = PoReceiveQty + Convert.ToInt32(FabricReRaiseDetails.ReceivedQty);
                            }
                            HoldQty = HoldQty + Convert.ToInt32(FabricReRaiseDetails.HoldQty);
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    if (PoReceiveQty > 0)
                    {
                        ToReceive_Print.Text = PoReceiveQty.ToString("N0");
                    }

                    sb.Append("</table>");
                    e.Row.Cells[16].Text = sb.ToString();
                    //pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString("N0");
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        string Qty = "";
                        MasterPoID = FabricReRaiseDetails.MasterPO_Id;
                        SupplierMasterID = FabricReRaiseDetails.SupplierID;
                        if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                        {
                            Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                        }
                        if (FabricReRaiseDetails.PoStatus == 1 || FabricReRaiseDetails.PoStatus == 2)
                        {
                            string Status = "";
                            if (FabricReRaiseDetails.PoStatus == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (FabricReRaiseDetails.PoStatus == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[17].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if (FabricReRaiseDetails.PoStatus != 1)
                        {
                            if (FabricReRaiseDetails.ReceivedQty > 0)
                            {
                                Qtys += Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty);
                            }
                            if (Convert.ToDecimal(FabricReRaiseDetails.SendQty) > 0)
                            {
                                SQty += Convert.ToDecimal(FabricReRaiseDetails.SendQty);
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                    }
                    else
                    {
                        if (PoRaiseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");

                Label lblArchieveQty = (Label)e.Row.FindControl("lblArchieveQty");
                HtmlTableRow trArchieveRow = e.Row.FindControl("trArchieveRow") as HtmlTableRow;

                //below added by Girish on 2023-03-31
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].QtyInArchieve > 0)
                    {
                        trArchieveRow.Visible = true;
                        lblArchieveQty.Text = ReRaiseSupplierDetail[0].QtyInArchieve.ToString("N0");
                        lblArchieveQty.ToolTip = "Sum Of Required Qty. Of Contracts Whose PO's are Still Open But Contracts are either Shipped/Cut Issue Completed.";
                        pendingQtyinorder.ToolTip = "(" + lblfabricQty.Text +
                                                    " + " + lblArchieveQty.Text +
                                                    ")" + (lblbalanceinhouseqty.Text == "" ? "" : " - " + lblbalanceinhouseqty.Text) +
                                                    " - " + txtqtytosend.Text;
                    }
                    else
                    {
                        trArchieveRow.Visible = false;
                    }
                }

            }

            #endregion
        }
        public void SavePrintData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox) { ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", ""); }
                else if (x is Label) { ((Label)x).Text = ((Label)x).Text.Replace(",", ""); }
            }
            List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER = GetALLRERAISESUPPLIER("PRINT");
            List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets = new List<FabricGroupAdmin.FabricOrderAllUpdate>();

            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            int QtyInArchieve = 0;
            int counter = 1;
            foreach (GridViewRow row in grdPRINT.Rows)
            {
                FabricGroupAdmin.FabricOrderAllUpdate Fabdet = new FabricGroupAdmin.FabricOrderAllUpdate();
                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");

                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;

                Fabdet.SendQty = 0;
                List<FabricGroupAdmin.FabricReRaiseDetails> FabricAllReRaiseSupplyer = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value)
                                                                                                                     && x.PrintName == lblcolor.Text
                                                                                                                     && x.CurrentStage == Convert.ToInt32(hdnCurrentstage.Value)
                                                                                                                     && x.PreviousStage == Convert.ToInt32(hdnperiviousstgae.Value)
                                                                                                                     && x.IsStyleSpecific == Convert.ToBoolean(hdnIsStyleSpecific.Value)
                                                                                                                     && x.StyleID == (Convert.ToBoolean(hdnIsStyleSpecific.Value) == false ? -1 : Convert.ToInt32(hdnStyleID.Value))
                                                                                                                     ).ToList();

                foreach (var RERAISESUPPLIER in FabricAllReRaiseSupplyer)
                {
                    if (RERAISESUPPLIER.ReceivedQty > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(RERAISESUPPLIER.ReceivedQty);
                            Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                            HoldQty = HoldQty + Convert.ToInt32(RERAISESUPPLIER.HoldQty);
                        }
                    }
                    if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(RERAISESUPPLIER.CancelPoQty);
                    //below added by Girish on 2023-03-31
                    if (counter == 1)
                    {
                        QtyInArchieve = Convert.ToInt32(Math.Round(RERAISESUPPLIER.QtyInArchieve, 0));
                    }
                    counter++;
                }

                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;

                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");
                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");

                Fabdet.Fabric_QualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BallanceInHouse = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", "")));
                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty) - (Fabdet.BallanceInHouse));

                int fabricQty = 0;
                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));
                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - Convert.ToInt32(hdnPreviousadjustmentqty.Value)) + QtyInArchieve; //added by Girish;
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty)));
                }


                Fabdet.PrintName = lblcolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.Stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.Stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.Stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.Stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleId = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.CurrentstageNumber = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.PrevStageType = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);
                Qty = 0;
                CancelQty = 0;
                HoldQty = 0;
                CancelPoQty = 0;

                Fabdets.Add(Fabdet);
            }

            bool IsSave = fabobj.FabricOrderAllUpdateToProc("PRINT", "ALLUPDATE", Fabdets);
        }
        #endregion

        #region FINISHED  -- 10
        protected void grdFINISHED_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int SupplierMasterID = 0;
            #region Header Creation
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<table><tr><td colspan='3' style='border:0px;'>Fabric Quality (Unit)</td></tr><tr><td>Current Stage</td><td>Previous Stage</td><td>Style Specific</td></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "CountConstruction";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ColorPrint";
                HeaderCell.Style.Add("Width", "110px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SerialNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "120px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Rcvd. Qty. ";
                HeaderCell.Style.Add("min-width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity BreakDown";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdFINISHED.Controls[0].Controls.AddAt(0, headerRow2);

            }
            #endregion
            #region Data Row Creation
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label recqty = (Label)e.Row.FindControl("recqty");
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");

                //Label lblQutationCount = (Label)e.Row.FindControl("lblQutationCount");
                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");

                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtFINISHEDResidualShrinkage = (TextBox)e.Row.FindControl("txtFINISHEDResidualShrinkage");
                TextBox txtqtytosend = (TextBox)e.Row.FindControl("txtqtytosend");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                GridView grdserialnumber = e.Row.FindControl("grdserialnumber") as GridView;

                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");

                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");

                Label ToReceive_finished = (Label)e.Row.FindControl("ToReceive_finished");

                Label lbladjustmentqtyy = (Label)e.Row.FindControl("lbladjustmentqtyy");
                HtmlControl balancetooltipp = (HtmlControl)e.Row.FindControl("balancetooltipp");

                List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()).ToList();
                List<FabricGroupAdmin.FabricReRaiseDetails> ReRaiseSupplierDetail = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()).ToList();

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:black'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.Text = "Adjustment qty from further stage:";
                        lbladjustmentqtyy.Text = hdnadjustmentqty.Value.ToString();

                        lblBalanceTooltip.CssClass = "TooltipTxt";
                        balancetooltipp.Attributes.Add("style", "display:Contents");
                    }
                }

                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";

                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                Residual = txtFINISHEDResidualShrinkage.Text == "" ? "0" : txtFINISHEDResidualShrinkage.Text;
                if (StyleSerialDetail.Count > 0)
                {
                    grdstylenumber.DataSource = StyleSerialDetail;
                    grdstylenumber.DataBind();

                    grdserialnumber.DataSource = StyleSerialDetail;
                    grdserialnumber.DataBind();

                    lblFabQtyRemaning.Text = StyleSerialDetail[0].RemainingFabQty == 0 ? "" : StyleSerialDetail[0].RemainingFabQty.ToString();
                    lblFabQtyRemaning2.Text = (StyleSerialDetail[0].RemainingFabQty.ToString() == "" || StyleSerialDetail[0].RemainingFabQty.ToString() == "0") ? "" : Convert.ToDecimal(StyleSerialDetail[0].RemainingFabQty).ToString("N0");

                    lblfabricorderavg.Text = (StyleSerialDetail[0].RemainingFabQty.ToString() == "" || StyleSerialDetail[0].RemainingFabQty.ToString() == "0") ? "" : Convert.ToDecimal(StyleSerialDetail[0].RemainingFabQty).ToString("N0");
                    lblfabricorderavg2.Text = (StyleSerialDetail[0].RemainingFabQty.ToString() == "" || StyleSerialDetail[0].RemainingFabQty.ToString() == "0") ? "" : Convert.ToDecimal(StyleSerialDetail[0].RemainingFabQty).ToString("N0");


                    lblTotalFabRequired.Text = StyleSerialDetail[0].TotalReuiredFabQty == 0 ? "" : "(" + StyleSerialDetail[0].TotalReuiredFabQty + ")";
                    lblcutwastgae.Text = StyleSerialDetail[0].CuttingWastage == 0 ? "" : StyleSerialDetail[0].CuttingWastage.ToString();
                    cutwastage = lblcutwastgae.Text == "" ? "0" : lblcutwastgae.Text;

                    lblrequiredqty.Text = (StyleSerialDetail[0].FabricRequiredQty.ToString() == "" || StyleSerialDetail[0].FabricRequiredQty.ToString() == "0") ? "" : Convert.ToDecimal(StyleSerialDetail[0].FabricRequiredQty).ToString("N0");


                }
                if (WastageDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdmin('" + 10 + "','" + hdnfabricQuality.Value + "','" + lblfabriccolor.Text.Trim() + "','" + lblcutwastgae.Text + "');");
                }
                //if (Convert.ToInt16(lblQutationCount.Text) <= 0)
                //{
                //    divraise.Attributes.Add("Class", "HideRaisebtn");
                //}

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].RemaningQty != 0 && ReRaiseSupplierDetail[0].RemaningQty.ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(ReRaiseSupplierDetail[0].RemaningQty).ToString("N0");
                    }
                }
                else if (StyleSerialDetail.Count > 0)
                {
                    pendingQtyinorder.Text = Convert.ToDecimal(StyleSerialDetail[0].FabricQtyToOrder - Convert.ToInt32(lblbalanceinhouseqty.Text == "" ? "0" : lblbalanceinhouseqty.Text)).ToString("N0");
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat(PoNumberWithLink(FabricReRaiseDetails.IsJuniorSignatory, FabricReRaiseDetails.IsAuthorizedSignatory, FabricReRaiseDetails.IsPartySignature, FabricReRaiseDetails.PO_Number));
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[11].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 70px;text-align:left;'>" + FabricReRaiseDetails.SupplierName + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                decimal Qtys = 0;
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    int HoldQty = 0;
                    int PoReceiveQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                            {
                                Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                                PoReceiveQty = PoReceiveQty + Convert.ToInt32(FabricReRaiseDetails.ReceivedQty);
                            }
                            HoldQty = HoldQty + Convert.ToInt32(FabricReRaiseDetails.HoldQty);
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    if (PoReceiveQty > 0)
                    {
                        ToReceive_finished.Text = PoReceiveQty.ToString("N0");
                    }
                    //pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();

                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail.Where(x => x.PoStatus != 1 && x.ReceivedQty > 0))
                    {
                        Qtys += Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty);
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                }
                decimal Remaning = lblFabQtyRemaning2.Text == "" ? 0 : Convert.ToDecimal(lblFabQtyRemaning2.Text);
                decimal balanceInhOuse = lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToDecimal(lblbalanceinhouseqty.Text);
                if (lblFabQtyRemaning2.Text != "")
                {
                    decimal _cutwastage = lblcutwastgae.Text == "" ? 0 : Convert.ToDecimal(lblcutwastgae.Text);
                    decimal Totalre = ((Convert.ToDecimal(lblFabQtyRemaning2.Text) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - (Convert.ToDecimal(_cutwastage))));
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        string Qty = "";
                        MasterPoID = FabricReRaiseDetails.MasterPO_Id;
                        SupplierMasterID = FabricReRaiseDetails.SupplierID;
                        if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                        {
                            Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                        }
                        if (FabricReRaiseDetails.PoStatus == 1 || FabricReRaiseDetails.PoStatus == 2)
                        {
                            string Status = "";
                            if (FabricReRaiseDetails.PoStatus == 1)
                            {
                                Status = "Canceled";
                            }
                            if (FabricReRaiseDetails.PoStatus == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblfabriccolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip' > Re.PO</div></td></tr>");
                            }
                        }

                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                    }
                    else
                    {
                        if (PoRaiseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblfabriccolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text.Trim() + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");

                Label lblArchieveQty = (Label)e.Row.FindControl("lblArchieveQty");
                HtmlTableRow trArchieveRow = e.Row.FindControl("trArchieveRow") as HtmlTableRow;

                //below added by Girish on 2023-03-31
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].QtyInArchieve > 0)
                    {
                        trArchieveRow.Visible = true;
                        lblArchieveQty.Text = ReRaiseSupplierDetail[0].QtyInArchieve.ToString("N0");
                        lblArchieveQty.ToolTip = "Sum Of Required Qty. Of Contracts Whose PO's are Still Open But Contracts are either Shipped/Cut Issue Completed.";
                        pendingQtyinorder.ToolTip = "(" + lblfabricorderavg2.Text +
                                                    " + " + lblArchieveQty.Text +
                                                    ")" + (lblbalanceinhouseqty.Text == "" ? "" : " - " + lblbalanceinhouseqty.Text) +
                                                    " - " + ToReceive_finished.Text;
                    }
                    else
                    {
                        trArchieveRow.Visible = false;
                    }
                }
            }
            #endregion
        }
        public void SaveFinishData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox) { ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", ""); }
                else if (x is Label) { ((Label)x).Text = ((Label)x).Text.Replace(",", ""); }
            }
            List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER = GetALLRERAISESUPPLIER("FINISHED");
            List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets = new List<FabricGroupAdmin.FabricOrderAllUpdate>();

            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CutIssueDonePoQty = 0;
            int CancelPoQty = 0;
            int QtyInArchieve = 0;
            int counter = 1;

            foreach (GridViewRow row in grdFINISHED.Rows)
            {
                FabricGroupAdmin.FabricOrderAllUpdate Fabdet = new FabricGroupAdmin.FabricOrderAllUpdate();
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnResidualShrinkage = (HiddenField)row.FindControl("hdnResidualShrinkage");
                HiddenField hdnfabprint = (HiddenField)row.FindControl("hdnfabprint");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                int bal = (lblbalanceinhouseqty.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(lblbalanceinhouseqty.Text)))));
                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");

                List<FabricGroupAdmin.FabricReRaiseDetails> FabricAllReRaiseSupplyer = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()).ToList();

                foreach (var RERAISESUPPLIER in FabricAllReRaiseSupplyer)
                {
                    if (RERAISESUPPLIER.ReceivedQty > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Close)
                        {
                            Qty = Qty + Convert.ToInt32(RERAISESUPPLIER.ReceivedQty);
                            HoldQty = HoldQty + Convert.ToInt32(RERAISESUPPLIER.HoldQty);
                        }
                    }
                    if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(RERAISESUPPLIER.CancelPoQty);
                    //below added by Girish on 2023-03-31
                    if (counter == 1)
                    {
                        QtyInArchieve = Convert.ToInt32(Math.Round(RERAISESUPPLIER.QtyInArchieve, 0));
                    }

                    counter++;
                }
                Qty = Qty - CancelPoQty;

                TextBox txtFINISHEDResidualShrinkage = (TextBox)row.FindControl("txtFINISHEDResidualShrinkage");
                Label QtyToOrder = (Label)row.FindControl("lblfabricorderavg");
                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning2");
                Fabdet.Fabric_QualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (hdnResidualShrinkage.Value == "" ? 0 : (float)Convert.ToDouble(hdnResidualShrinkage.Value));
                Fabdet.QtyToOrder = (PendingQtyToOrder.Text == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text))));
                Fabdet.PendingQtyToOrder = PendingQtyToOrder.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text)) + CancelQty) - (Qty + HoldQty + bal + CutIssueDonePoQty)) + QtyInArchieve; //added by Girish;

                Fabdet.PrintName = hdnfabprint.Value;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Qty = 0;
                CancelQty = 0;
                HoldQty = 0;
                CancelPoQty = 0;
                Fabdets.Add(Fabdet);
            }

            bool IsSave = fabobj.FabricOrderAllUpdateToProc("FINISHED", "ALLUPDATE", Fabdets);
        }
        #endregion

        #region RFD  -- 29
        protected void grdRFD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Header Creation
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //  headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<table><tr><td colspan='3' style='border:0px;'>Fabric Quality (Unit)</td></tr><tr><td>Current Stage</td><td>Previous Stage</td><td>Style Specific</td></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "CountConstruction";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ColorPrint";
                HeaderCell.Style.Add("Width", "110px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SerialNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity Breakdown ";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdRFD.Controls[0].Controls.AddAt(0, headerRow2);

            }
            #endregion
            #region Data Row Creation
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");
                //Label lblQutationCount = (Label)e.Row.FindControl("lblQutationCount");

                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Label txtqtytosend = (Label)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                GridView grdserialnumber = e.Row.FindControl("grdserialnumber") as GridView;

                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");

                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";
                // string fabdetails = DataBinder.Eval(e.Row.DataItem, "FabricColor").ToString();
                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");

                Label ToReceive_rfd = (Label)e.Row.FindControl("ToReceive_rfd");
                Label lbladjustmentqtyy = (Label)e.Row.FindControl("lbladjustmentqtyy");
                HtmlControl balancetooltipp = (HtmlControl)e.Row.FindControl("balancetooltipp");



                List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == (hdnstage1.Value == "29" ? "" : lblfabriccolor.Text.ToLower())).ToList();
                List<FabricGroupAdmin.FabricReRaiseDetails> ReRaiseSupplierDetail = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == (hdnstage1.Value == "29" ? "" : lblfabriccolor.Text.ToLower())).ToList();


                if (lblbalanceinhouseqty.Text != "")
                {
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:black'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.Text = "Adjustment qty from further stage:";
                        lbladjustmentqtyy.Text = hdnadjustmentqty.Value.ToString();

                        lblBalanceTooltip.CssClass = "TooltipTxt";
                        balancetooltipp.Attributes.Add("style", "display:Contents");
                    }
                }

                if (StyleSerialDetail.Count > 0)
                {
                    grdstylenumber.DataSource = StyleSerialDetail;
                    grdstylenumber.DataBind();

                    grdserialnumber.DataSource = StyleSerialDetail;
                    grdserialnumber.DataBind();

                    lblfabricQty.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    //lblfabricQty.Text = ReRaiseSupplierDetail[0].SendQty.ToString("NO");
                    lblFabQtyToOrder.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = StyleSerialDetail[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = StyleSerialDetail[0].FabricRequiredQty.ToString("N0");

                }

                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "") { IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1); }
                if (WastageDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 29 + "','" + hdnfabricQuality.Value + "','" + lblfabriccolor.Text + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "','" + lblcutwastgae.Text + "');");
                }

                if (hdnstage1.Value == "29")
                {
                    lblfabriccolor.Text = "";
                }

                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text == "" ? "0" : txtGreigeshrk.Text;
                Residual = txtResidualShak.Text == "" ? "0" : txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text == "" ? "0" : lblcutwastgae.Text;

                if (txtResidualShak.Text == "0") { txtResidualShak.Text = ""; }

                //if (Convert.ToInt16(lblQutationCount.Text) <= 0)
                //{
                //    divraise.Attributes.Add("Class", "HideRaisebtn");
                //}


                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].RemaningQty != 0 && ReRaiseSupplierDetail[0].RemaningQty.ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(ReRaiseSupplierDetail[0].RemaningQty).ToString("N0");
                    }
                }
                else if (StyleSerialDetail.Count > 0)
                {
                    pendingQtyinorder.Text = Convert.ToDecimal(StyleSerialDetail[0].FabricQtyToOrder - Convert.ToInt32(lblbalanceinhouseqty.Text == "" ? "0" : lblbalanceinhouseqty.Text)).ToString("N0");
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat(PoNumberWithLink(FabricReRaiseDetails.IsJuniorSignatory, FabricReRaiseDetails.IsAuthorizedSignatory, FabricReRaiseDetails.IsPartySignature, FabricReRaiseDetails.PO_Number));
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99; text-align:left;padding-left:5px;padding-left:5px;'>" + FabricReRaiseDetails.SupplierName + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    int HoldQty = 0;
                    int PoReceiveQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                            {
                                Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                                PoReceiveQty = PoReceiveQty + Convert.ToInt32(FabricReRaiseDetails.ReceivedQty);
                            }
                            HoldQty = HoldQty + FabricReRaiseDetails.HoldQty;
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    if (PoReceiveQty > 0)
                    {
                        ToReceive_rfd.Text = PoReceiveQty.ToString("N0");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[16].Text = sb.ToString();
                    //pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        string Qty = "";
                        MasterPoID = FabricReRaiseDetails.MasterPO_Id;
                        SupplierMasterID = FabricReRaiseDetails.SupplierID;
                        if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                        {
                            Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                        }
                        if (FabricReRaiseDetails.PoStatus == 1 || FabricReRaiseDetails.PoStatus == 2)
                        {
                            string Status = "";
                            if (FabricReRaiseDetails.PoStatus == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (FabricReRaiseDetails.PoStatus == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblfabriccolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[17].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if (FabricReRaiseDetails.PoStatus != 1)
                        {
                            if (FabricReRaiseDetails.ReceivedQty > 0)
                            {
                                Qtys += Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty);
                            }
                            if (FabricReRaiseDetails.SendQty > 0)
                            {
                                if (Convert.ToInt32(hdnstage1.Value) == 29) { }
                                else
                                {
                                    SQty += Convert.ToDecimal(FabricReRaiseDetails.SendQty);
                                }
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    if (SQty > 0)
                        txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }

                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0") { divraise.Attributes.Add("Class", "HideRaisebtn"); pendingQtyinorder.Text = ""; }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0) { divraise.Attributes.Add("Class", "HideRaisebtn"); }
                    else
                    {
                        if (PoRaiseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblfabriccolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else { divraise.Attributes.Add("onclick", "PermissionAlertMsg();"); divraise.Attributes.Add("style", "Color:grey"); }
                    }
                }
                else { divraise.Attributes.Add("Class", "HideRaisebtn"); pendingQtyinorder.Text = ""; }

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");

                Label lblArchieveQty = (Label)e.Row.FindControl("lblArchieveQty");
                HtmlTableRow trArchieveRow = e.Row.FindControl("trArchieveRow") as HtmlTableRow;

                //below added by Girish on 2023-03-31
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].QtyInArchieve > 0)
                    {
                        trArchieveRow.Visible = true;
                        lblArchieveQty.Text = ReRaiseSupplierDetail[0].QtyInArchieve.ToString("N0");
                        lblArchieveQty.ToolTip = "Sum Of Required Qty. Of Contracts Whose PO's are Still Open But Contracts are either Shipped/Cut Issue Completed.";
                        pendingQtyinorder.ToolTip = "(" + lblfabricQty.Text +
                                                   " + " + lblArchieveQty.Text +
                                                   ")" + (lblbalanceinhouseqty.Text == "" ? "" : " - " + lblbalanceinhouseqty.Text) +
                                                   " - " + txtqtytosend.Text;
                    }
                    else
                    {
                        trArchieveRow.Visible = false;
                    }
                }


            }
            #endregion
        }
        public void SaveRFDData()
        {
            int QtyInArchieve = 0;
            int counter = 1;

            foreach (Control x in this.Controls)
            {
                if (x is TextBox) { ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", ""); }
                else if (x is Label) { ((Label)x).Text = ((Label)x).Text.Replace(",", ""); }
            }
            List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER = GetALLRERAISESUPPLIER("RFD");
            List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets = new List<FabricGroupAdmin.FabricOrderAllUpdate>();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdRFD.Rows)
            {
                FabricGroupAdmin.FabricOrderAllUpdate Fabdet = new FabricGroupAdmin.FabricOrderAllUpdate();
                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");

                Fabdet.SendQty = 0;
                foreach (var RERAISESUPPLIER in ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower()))
                {
                    if (RERAISESUPPLIER.ReceivedQty > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(RERAISESUPPLIER.ReceivedQty);
                            if (Convert.ToInt32(hdnstage1.Value) == 29)
                            {
                                Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(RERAISESUPPLIER.ReceivedQty);
                            }
                            else
                            {
                                Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                            }
                            HoldQty = HoldQty + Convert.ToInt32(RERAISESUPPLIER.HoldQty);
                        }
                    }
                    if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(RERAISESUPPLIER.CancelPoQty);
                    //below added by Girish on 2023-03-31
                    if (counter == 1)
                    {
                        QtyInArchieve = QtyInArchieve = Convert.ToInt32(Math.Round(RERAISESUPPLIER.QtyInArchieve, 0));
                    }

                    counter++;
                }

                //Fabdet.SendQty = (Fabdet.SendQty - CancelPoQty) - Convert.ToInt32(Math.Round(QtyInArchieve, 0));
                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;


                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");
                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;

                Fabdet.Fabric_QualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BallanceInHouse = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", "")));

                if (Convert.ToInt32(hdnstage1.Value) == 29)
                {
                    Fabdet.PendingQtyToOrder = lbltotalqtytosend.Text == "" ? 0 : (Convert.ToInt32(lbltotalqtytosend.Text.Replace(",", "")) - (Fabdet.SendQty));
                    Fabdet.PendingQtyToOrder = ((Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BallanceInHouse))) + QtyInArchieve; //added by Girish;
                }
                else
                {
                    Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty) - Convert.ToInt32(hdnPreviousadjustmentqty.Value)) + QtyInArchieve; //added by Girish;

                }

                int fabricQty = 0;
                if (Convert.ToInt32(hdnstage1.Value) == 29)
                {
                    if (!string.IsNullOrEmpty(lblpriorstageQty.Text))
                        fabricQty = Convert.ToInt32(lblpriorstageQty.Text.Replace(",", ""));
                }
                else
                {
                    if (!string.IsNullOrEmpty(lblfabricQty.Text))
                        fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));
                }

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));
                if (Convert.ToInt32(hdnstage1.Value) == 29)
                {
                    Fabdet.QtyToOrder = lbltotalqtytosend.Text == "" ? 0 : (Convert.ToInt32(lbltotalqtytosend.Text.Replace(",", "")));
                }
                else
                {
                    Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));
                }

                Fabdet.PrintName = lblfabriccolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.Stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.Stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.Stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.Stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleId = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.CurrentstageNumber = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.PrevStageType = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);

                Qty = 0;
                CancelQty = 0;
                HoldQty = 0;
                CancelPoQty = 0;
                Fabdets.Add(Fabdet);
            }
            // Have to write function to save
            bool IsSave = fabobj.FabricOrderAllUpdateToProc("RFD", "ALLUPDATE", Fabdets);
        }
        #endregion

        #region Embellishment  -- 30
        protected void grdEMBELLISHMENT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Header Creation
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                // headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<table><tr><td colspan='3' style='border:0px;'>Fabric Quality (Unit)</td></tr><tr><td>Current Stage</td><td>Previous Stage</td><td>Style Specific</td></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "CountConstruction";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ColorPrint";
                HeaderCell.Style.Add("Width", "110px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SerialNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity Breakdown";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdEMBELLISHMENT.Controls[0].Controls.AddAt(0, headerRow2);
                // grdEmbellishment.Controls[0].Controls.AddAt(0, headerRow1);

            }
            #endregion
            #region Data Row Creation
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");

                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Label txtqtytosend = (Label)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                GridView grdserialnumber = e.Row.FindControl("grdserialnumber") as GridView;

                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");


                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");

                Label ToReceive_embellishment = (Label)e.Row.FindControl("ToReceive_embellishment");

                Label lbladjustmentqtyy = (Label)e.Row.FindControl("lbladjustmentqtyy");
                HtmlControl balancetooltipp = (HtmlControl)e.Row.FindControl("balancetooltipp");
                //Label lblQutationCount = (Label)e.Row.FindControl("lblQutationCount");

                List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower() && x.StyleID == Convert.ToInt32(hdnStyleID.Value)).ToList();
                List<FabricGroupAdmin.FabricReRaiseDetails> ReRaiseSupplierDetail = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower() && x.StyleID == Convert.ToInt32(hdnStyleID.Value)).ToList();


                string ccn = "<span style='color:blue'>" + lblFabricQuality.Text + "</span><span style='color:gray'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + "</span> " + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:black'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.Text = "Adjustment qty from further stage:";
                        lbladjustmentqtyy.Text = hdnadjustmentqty.Value.ToString();

                        lblBalanceTooltip.CssClass = "TooltipTxt";
                        balancetooltipp.Attributes.Add("style", "display:Contents");
                    }
                }


                if (StyleSerialDetail.Count > 0)
                {
                    grdstylenumber.DataSource = StyleSerialDetail;
                    grdstylenumber.DataBind();

                    grdserialnumber.DataSource = StyleSerialDetail;
                    grdserialnumber.DataBind();

                    lblfabricQty.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");

                    lblFabQtyToOrder.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = StyleSerialDetail[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = StyleSerialDetail[0].FabricRequiredQty.ToString("N0");


                }

                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "") { IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1); }
                if (WastageDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 30 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "','" + lblcutwastgae.Text + "');");
                }

                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text == "" ? "0" : txtGreigeshrk.Text;
                Residual = txtResidualShak.Text == "" ? "0" : txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text == "" ? "0" : lblcutwastgae.Text;
                if (txtResidualShak.Text == "0") { txtResidualShak.Text = ""; }
                //if (Convert.ToInt16(lblQutationCount.Text) <= 0) { divraise.Attributes.Add("Class", "HideRaisebtn"); }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].RemaningQty != 0 && ReRaiseSupplierDetail[0].RemaningQty.ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(ReRaiseSupplierDetail[0].RemaningQty).ToString("N0");
                    }
                }
                else if (StyleSerialDetail.Count > 0)
                {
                    pendingQtyinorder.Text = Convert.ToDecimal(StyleSerialDetail[0].FabricQtyToOrder - Convert.ToInt32(lblbalanceinhouseqty.Text == "" ? "0" : lblbalanceinhouseqty.Text)).ToString("N0");
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                    }
                    else
                    {
                        if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat(PoNumberWithLink(FabricReRaiseDetails.IsJuniorSignatory, FabricReRaiseDetails.IsAuthorizedSignatory, FabricReRaiseDetails.IsPartySignature, FabricReRaiseDetails.PO_Number));
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99; text-align:left;padding-left:5px;padding-left:5px;'>" + FabricReRaiseDetails.SupplierName + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    int HoldQty = 0;
                    int PoReceiveQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                            {
                                Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                                PoReceiveQty = PoReceiveQty + Convert.ToInt32(FabricReRaiseDetails.ReceivedQty);
                            }
                            HoldQty = HoldQty + Convert.ToInt32(FabricReRaiseDetails.HoldQty);
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    if (PoReceiveQty > 0)
                    {
                        ToReceive_embellishment.Text = PoReceiveQty.ToString("N0");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[16].Text = sb.ToString();
                    //pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        string Qty = "";
                        MasterPoID = FabricReRaiseDetails.MasterPO_Id;
                        SupplierMasterID = FabricReRaiseDetails.SupplierID;
                        if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                        {
                            Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                        }
                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (FabricReRaiseDetails.PoStatus == 1 || FabricReRaiseDetails.PoStatus == 2)
                        {
                            string Status = "";
                            if (FabricReRaiseDetails.PoStatus == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (FabricReRaiseDetails.PoStatus == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[17].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if (FabricReRaiseDetails.PoStatus != 1)
                        {
                            if (FabricReRaiseDetails.ReceivedQty > 0)
                            {
                                Qtys += Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty);
                            }
                            if (Convert.ToDecimal(FabricReRaiseDetails.SendQty) > 0)
                            {
                                SQty += Convert.ToDecimal(FabricReRaiseDetails.SendQty);
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");

                Label lblArchieveQty = (Label)e.Row.FindControl("lblArchieveQty");
                HtmlTableRow trArchieveRow = e.Row.FindControl("trArchieveRow") as HtmlTableRow;

                //below added by Girish on 2023-03-31
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].QtyInArchieve > 0)
                    {
                        trArchieveRow.Visible = true;
                        lblArchieveQty.Text = ReRaiseSupplierDetail[0].QtyInArchieve.ToString("N0");
                        lblArchieveQty.ToolTip = "Sum Of Required Qty. Of Contracts Whose PO's are Still Open But Contracts are either Shipped/Cut Issue Completed.";
                        pendingQtyinorder.ToolTip = "(" + lblfabricQty.Text +
                                                   " + " + lblArchieveQty.Text +
                                                   ")" + (lblbalanceinhouseqty.Text == "" ? "" : " - " + lblbalanceinhouseqty.Text) +
                                                   " - " + txtqtytosend.Text;
                    }
                    else
                    {
                        trArchieveRow.Visible = false;
                    }
                }
            }
            #endregion
        }
        public void SaveEmbellishmentData()
        {
            int QtyInArchieve = 0;
            int counter = 1;

            foreach (Control x in this.Controls)
            {
                if (x is TextBox) { ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", ""); }
                else if (x is Label) { ((Label)x).Text = ((Label)x).Text.Replace(",", ""); }
            }
            List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER = GetALLRERAISESUPPLIER("EMBELLISHMENT");
            List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets = new List<FabricGroupAdmin.FabricOrderAllUpdate>();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdEMBELLISHMENT.Rows)
            {
                FabricGroupAdmin.FabricOrderAllUpdate Fabdet = new FabricGroupAdmin.FabricOrderAllUpdate();
                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");


                Fabdet.SendQty = 0;
                foreach (var RERAISESUPPLIER in ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblcolor.Text.ToLower() && x.StyleID == Convert.ToInt32(hdnStyleID.Value)))
                {
                    if (RERAISESUPPLIER.ReceivedQty > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(RERAISESUPPLIER.ReceivedQty);
                            Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                            HoldQty = HoldQty + Convert.ToInt32(RERAISESUPPLIER.HoldQty);
                        }
                    }
                    if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                    }

                    CancelPoQty = CancelPoQty + Convert.ToInt32(RERAISESUPPLIER.CancelPoQty);
                    //below added by Girish on 2023-03-31
                    if (counter == 1)
                    {
                        QtyInArchieve = Convert.ToInt32(Math.Round(RERAISESUPPLIER.QtyInArchieve, 0));
                    }

                    counter++;
                }
                //Fabdet.SendQty = (Fabdet.SendQty - CancelPoQty) - Convert.ToInt32(Math.Round(QtyInArchieve, 0));

                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;

                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");

                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;

                Fabdet.Fabric_QualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BallanceInHouse = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", "")));
                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty) - (Fabdet.BallanceInHouse));

                int fabricQty = 0;
                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));
                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));

                if (Fabdet.PendingQtyToOrder <= 0) { Fabdet.PendingQtyToOrder = 0; }
                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(hdnPreviousadjustmentqty.Value))) + QtyInArchieve; //added by Girish;
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty) - Convert.ToInt32(hdnadjustmentqty.Value)));
                }

                Fabdet.PrintName = lblcolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.Stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.Stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.Stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.Stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleId = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.CurrentstageNumber = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.PrevStageType = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);


                Qty = 0;
                Fabdets.Add(Fabdet);
            }

            bool IsSave = fabobj.FabricOrderAllUpdateToProc("EMBELLISHMENT", "ALLUPDATE", Fabdets);
        }
        #endregion

        #region Embroidery  -- 31
        protected void grdEMBROIDERY_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Header Creation
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<table><tr><td colspan='3' style='border:0px;'>Fabric Quality (Unit)</td></tr><tr><td>Current Stage</td><td>Previous Stage</td><td>Style Specific</td></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "CountConstruction";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "GSM";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Width";
                HeaderCell.Style.Add("Width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "ColorPrint";
                HeaderCell.Style.Add("Width", "110px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SerialNumber";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdEMBROIDERY.Controls[0].Controls.AddAt(0, headerRow2);
                // grdEmbroidery.Controls[0].Controls.AddAt(0, headerRow1);

            }
            #endregion

            #region Data Row Creation
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Label txtqtytosend = (Label)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                GridView grdserialnumber = e.Row.FindControl("grdserialnumber") as GridView;

                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");


                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");

                Label ToReceive_embroidery = (Label)e.Row.FindControl("ToReceive_embroidery");

                Label lbladjustmentqtyy = (Label)e.Row.FindControl("lbladjustmentqtyy");
                HtmlControl balancetooltipp = (HtmlControl)e.Row.FindControl("balancetooltipp");

                //Label lblQutationCount = (Label)e.Row.FindControl("lblQutationCount");



                List<FabricGroupAdmin.FabricStyleSerialDetail> StyleSerialDetail = ALLStyleSerialDetail.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower() && x.StyleID == Convert.ToInt32(hdnStyleID.Value)).ToList();
                List<FabricGroupAdmin.FabricReRaiseDetails> ReRaiseSupplierDetail = ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblfabriccolor.Text.ToLower() && x.StyleID == Convert.ToInt32(hdnStyleID.Value)).ToList();

                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";
                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:black'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.Text = "Adjustment qty from further stage:";
                        lbladjustmentqtyy.Text = hdnadjustmentqty.Value.ToString();

                        lblBalanceTooltip.CssClass = "TooltipTxt";
                        balancetooltipp.Attributes.Add("style", "display:Contents");
                    }
                }

                if (StyleSerialDetail.Count > 0)
                {
                    grdstylenumber.DataSource = StyleSerialDetail;
                    grdstylenumber.DataBind();

                    grdserialnumber.DataSource = StyleSerialDetail;
                    grdserialnumber.DataBind();


                    //lblfabricQty.Text = FabricEmbroidery[0].FabricQty.ToString("N0");
                    lblfabricQty.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblFabQtyToOrder.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = StyleSerialDetail[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = StyleSerialDetail[0].FabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = StyleSerialDetail[0].FabricRequiredQty.ToString("N0");


                }

                //MergeRows(grdstylenumber);
                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "") { IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1); }
                if (WastageDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 31 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "','" + lblcutwastgae.Text + "');");
                }
                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text == "" ? "0" : txtGreigeshrk.Text;
                Residual = txtResidualShak.Text == "" ? "0" : txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text == "" ? "0" : lblcutwastgae.Text;
                if (txtResidualShak.Text == "0") { txtResidualShak.Text = ""; }

                //if (Convert.ToInt16(lblQutationCount.Text) <= 0)
                //{
                //    divraise.Attributes.Add("Class", "HideRaisebtn");
                //}
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].RemaningQty != 0 && ReRaiseSupplierDetail[0].RemaningQty.ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(ReRaiseSupplierDetail[0].RemaningQty).ToString("N0");
                    }
                }
                else if (StyleSerialDetail.Count > 0)
                {
                    pendingQtyinorder.Text = Convert.ToDecimal(StyleSerialDetail[0].FabricQtyToOrder - Convert.ToInt32(lblbalanceinhouseqty.Text == "" ? "0" : lblbalanceinhouseqty.Text)).ToString("N0");
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if (PoRaiseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat(PoNumberWithLink(FabricReRaiseDetails.IsJuniorSignatory, FabricReRaiseDetails.IsAuthorizedSignatory, FabricReRaiseDetails.IsPartySignature, FabricReRaiseDetails.PO_Number));
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99; text-align:left;padding-left:5px;padding-left:5px;'>" + FabricReRaiseDetails.SupplierName + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                }
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    int HoldQty = 0;
                    int PoReceiveQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                            {
                                Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                                PoReceiveQty = PoReceiveQty + Convert.ToInt32(FabricReRaiseDetails.ReceivedQty);
                            }
                            HoldQty = HoldQty + Convert.ToInt32(FabricReRaiseDetails.HoldQty);
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    if (PoReceiveQty > 0)
                    {
                        ToReceive_embroidery.Text = PoReceiveQty.ToString("N0");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[16].Text = sb.ToString();
                    //pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }

                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        string Qty = "";
                        MasterPoID = FabricReRaiseDetails.MasterPO_Id;
                        SupplierMasterID = FabricReRaiseDetails.SupplierID;
                        if (Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty) > 0)
                        {
                            Qty = Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty).ToString("N0");
                        }
                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (FabricReRaiseDetails.PoStatus == 1 || FabricReRaiseDetails.PoStatus == 2)
                        {
                            string Status = "";
                            if (FabricReRaiseDetails.PoStatus == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (FabricReRaiseDetails.PoStatus == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Cancel && (FabricPOStatus)FabricReRaiseDetails.PoStatus != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if (PoReviseDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[17].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    foreach (FabricGroupAdmin.FabricReRaiseDetails FabricReRaiseDetails in ReRaiseSupplierDetail)
                    {
                        if (FabricReRaiseDetails.PoStatus != 1)
                        {
                            if (FabricReRaiseDetails.ReceivedQty > 0)
                            {
                                Qtys += Convert.ToDecimal(FabricReRaiseDetails.ReceivedQty);
                            }
                            if (Convert.ToDecimal(FabricReRaiseDetails.SendQty) > 0)
                            {
                                SQty += Convert.ToDecimal(FabricReRaiseDetails.SendQty);
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");

                Label lblArchieveQty = (Label)e.Row.FindControl("lblArchieveQty");
                HtmlTableRow trArchieveRow = e.Row.FindControl("trArchieveRow") as HtmlTableRow;

                //below added by Girish on 2023-03-31
                if (ReRaiseSupplierDetail.Count() > 0)
                {
                    if (ReRaiseSupplierDetail[0].QtyInArchieve > 0)
                    {
                        trArchieveRow.Visible = true;
                        lblArchieveQty.Text = ReRaiseSupplierDetail[0].QtyInArchieve.ToString("N0");
                        lblArchieveQty.ToolTip = "Sum Of Required Qty. Of Contracts Whose PO's are Still Open But Contracts are either Shipped/Cut Issue Completed.";
                        pendingQtyinorder.ToolTip = "(" + lblfabricQty.Text +
                                                   " + " + lblArchieveQty.Text +
                                                   ")" + (lblbalanceinhouseqty.Text == "" ? "" : " - " + lblbalanceinhouseqty.Text) +
                                                   " - " + txtqtytosend.Text;
                    }
                    else
                    {
                        trArchieveRow.Visible = false;
                    }
                }
            }
            #endregion
        }
        public void SaveEmbroideryData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox) { ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", ""); }
                else if (x is Label) { ((Label)x).Text = ((Label)x).Text.Replace(",", ""); }
            }
            List<FabricGroupAdmin.FabricReRaiseDetails> ALLRERAISESUPPLIER = GetALLRERAISESUPPLIER("EMBROIDERY");
            List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets = new List<FabricGroupAdmin.FabricOrderAllUpdate>();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            int QtyInArchieve = 0;
            int counter = 1;

            foreach (GridViewRow row in grdEMBROIDERY.Rows)
            {
                FabricGroupAdmin.FabricOrderAllUpdate Fabdet = new FabricGroupAdmin.FabricOrderAllUpdate();
                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");


                Fabdet.SendQty = 0;
                foreach (var RERAISESUPPLIER in ALLRERAISESUPPLIER.Where(x => x.Fabric_QualityID == Convert.ToInt32(hdnfabricQuality.Value) && x.PrintName.ToLower() == lblcolor.Text.ToLower() && x.StyleID == Convert.ToInt32(hdnStyleID.Value)))
                {
                    if (RERAISESUPPLIER.ReceivedQty > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(RERAISESUPPLIER.ReceivedQty);
                            Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                            HoldQty = HoldQty + Convert.ToInt32(RERAISESUPPLIER.HoldQty);
                        }
                    }
                    if ((FabricPOStatus)Convert.ToInt32(RERAISESUPPLIER.PoStatus) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(RERAISESUPPLIER.SendQty);
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(RERAISESUPPLIER.CancelPoQty);
                    //below added by Girish on 2023-03-31
                    if (counter == 1)
                    {
                        QtyInArchieve = Convert.ToInt32(Math.Round(RERAISESUPPLIER.QtyInArchieve, 0));
                    }

                    counter++;
                }
                //Fabdet.SendQty = (Fabdet.SendQty - CancelPoQty) - Convert.ToInt32(Math.Round(QtyInArchieve, 0));
                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;


                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");


                Fabdet.Fabric_QualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BallanceInHouse = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", "")));

                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty) - (Fabdet.BallanceInHouse));

                int fabricQty = 0;

                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));

                if (Fabdet.PendingQtyToOrder <= 0)
                {
                    Fabdet.PendingQtyToOrder = 0;
                }
                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(hdnPreviousadjustmentqty.Value))) + QtyInArchieve; //added by Girish;
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty) - Convert.ToInt32(hdnadjustmentqty.Value)));
                }

                Fabdet.PrintName = lblcolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.Stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.Stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.Stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.Stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleId = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.CurrentstageNumber = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.PrevStageType = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);

                Qty = 0;
                CancelQty = 0;
                HoldQty = 0;
                CancelPoQty = 0;
                Fabdets.Add(Fabdet);
            }

            bool IsSave = fabobj.FabricOrderAllUpdateToProc("EMBROIDERY", "ALLUPDATE", Fabdets);
        }
        #endregion

        #region Row Merging
        public void margerows(string Refreshgrd)
        {
            if (Refreshgrd == "GRIEGE") // For Griege
            {
                foreach (GridViewRow row in grdGRIEGE.Rows)
                {
                    GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                    MergeRowsnew(grdstylenumber);
                }
            }
            else if (Refreshgrd == "DYED") // For DYED
            {
                foreach (GridViewRow row in grdDYED.Rows)
                {
                    GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                    MergeRowsnew(grdstylenumber);
                }
            }
            else if (Refreshgrd == "PRINT")  // for Print
            {
                foreach (GridViewRow row in grdPRINT.Rows)
                {
                    GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                    MergeRowsnew(grdstylenumber);
                }
            }
            else if (Refreshgrd == "FINISHED") // For FINISHED
            {
                foreach (GridViewRow row in grdFINISHED.Rows)
                {
                    GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                    MergeRowsnew(grdstylenumber);
                }
            }
            else if (Refreshgrd == "RFD") // For RFD
            {
                foreach (GridViewRow row in grdRFD.Rows)
                {
                    GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                    MergeRowsnew(grdstylenumber);
                }
            }
            else if (Refreshgrd == "EMBELLISHMENT") // For EMBELLISHMENT
            {
                foreach (GridViewRow row in grdEMBELLISHMENT.Rows)
                {
                    GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                    MergeRowsnew(grdstylenumber);
                }
            }
            else if (Refreshgrd == "EMBROIDERY") // For EMBROIDERY
            {
                foreach (GridViewRow row in grdEMBROIDERY.Rows)
                {
                    GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                    MergeRowsnew(grdstylenumber);
                }
            }
        }

        public static void MergeRowsnew(GridView GridView1)
        {
            for (int i = GridView1.Rows.Count - 1; i > 0; i--)
            {

                GridViewRow row = GridView1.Rows[i];
                GridViewRow previousRow = GridView1.Rows[i - 1];
                Label lblStyleNumber = (Label)row.FindControl("lblStyleNumber");
                Label lblStyleNumberpreviousRow = (Label)previousRow.FindControl("lblStyleNumber");


                if (lblStyleNumber.Text == lblStyleNumberpreviousRow.Text)
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
                    }
                }

            }
        }

        public static void MergeRowsgrige(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                Label lblFabricQuality = (Label)row.FindControl("lblFabricQuality");
                Label lblFabricQualitynew = (Label)previousRow.FindControl("lblFabricQuality");

                HiddenField fabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField fabricQualityNew = (HiddenField)previousRow.FindControl("hdnfabricQuality");

                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                Label lblcolornew = (Label)previousRow.FindControl("lblfabriccolor");

                string A = fabricQuality.Value;
                string B = fabricQualityNew.Value;


                if (A == B)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;

                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;

                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;

                    row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                    previousRow.Cells[3].Visible = false;

                    row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                    previousRow.Cells[4].Visible = false;

                    row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
                    previousRow.Cells[5].Visible = false;

                    row.Cells[6].RowSpan = previousRow.Cells[6].RowSpan < 2 ? 2 : previousRow.Cells[6].RowSpan + 1;
                    previousRow.Cells[6].Visible = false;

                    row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
                    previousRow.Cells[7].Visible = false;

                    row.Cells[8].RowSpan = previousRow.Cells[8].RowSpan < 2 ? 2 : previousRow.Cells[8].RowSpan + 1;
                    previousRow.Cells[8].Visible = false;

                    row.Cells[9].RowSpan = previousRow.Cells[9].RowSpan < 2 ? 2 : previousRow.Cells[9].RowSpan + 1;
                    previousRow.Cells[9].Visible = false;

                    row.Cells[10].RowSpan = previousRow.Cells[10].RowSpan < 2 ? 2 : previousRow.Cells[10].RowSpan + 1;
                    previousRow.Cells[10].Visible = false;

                    row.Cells[11].RowSpan = previousRow.Cells[11].RowSpan < 2 ? 2 : previousRow.Cells[11].RowSpan + 1;
                    previousRow.Cells[11].Visible = false;

                    row.Cells[12].RowSpan = previousRow.Cells[12].RowSpan < 2 ? 2 : previousRow.Cells[12].RowSpan + 1;
                    previousRow.Cells[12].Visible = false;

                    row.Cells[13].RowSpan = previousRow.Cells[13].RowSpan < 2 ? 2 : previousRow.Cells[13].RowSpan + 1;
                    previousRow.Cells[13].Visible = false;

                    row.Cells[14].RowSpan = previousRow.Cells[14].RowSpan < 2 ? 2 : previousRow.Cells[14].RowSpan + 1;
                    previousRow.Cells[14].Visible = false;

                    row.Cells[15].RowSpan = previousRow.Cells[15].RowSpan < 2 ? 2 : previousRow.Cells[15].RowSpan + 1;
                    previousRow.Cells[15].Visible = false;

                    row.Attributes.Add("class", "bgon" + row.RowIndex.ToString());
                    previousRow.Attributes.Add("class", "bgon" + row.RowIndex.ToString());
                    row.Attributes.Add("onclick", "funcolor(" + "'" + row.RowIndex.ToString() + "'" + ")");
                    previousRow.Attributes.Add("onclick", "funcolor(" + "'" + row.RowIndex.ToString() + "'" + ")");
                }
            }
        }

        public static void MergeRowsPrint(GridView gridView)
        {
            try
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {

                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                    HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                    HiddenField hdnfabricQualitynew = (HiddenField)previousRow.FindControl("hdnfabricQuality");

                    Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                    Label lblcolornew = (Label)previousRow.FindControl("lblfabriccolor");

                    string A = hdnfabricQuality.Value + lblfabriccolor.Text;
                    string B = hdnfabricQualitynew.Value + lblcolornew.Text;



                    Label lblGreige_Sh = (Label)row.FindControl("lblGreige_Sh");
                    Label lblGreige_Shnew = (Label)previousRow.FindControl("lblGreige_Sh");


                    Label lblstylenumber = (Label)row.FindControl("lblstylenumber");
                    Label lblstylenumbernext = (Label)previousRow.FindControl("lblstylenumber");

                    Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
                    Label lblQuantityToOrdernew = (Label)previousRow.FindControl("lblQuantityToOrder");

                    Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                    Label lblbalanceinhouseqtynew = (Label)previousRow.FindControl("lblbalanceinhouseqty");


                    Label lblBestQuotedRate = (Label)row.FindControl("lblBestQuotedRate");
                    Label llblBestQuotedRatenew = (Label)previousRow.FindControl("lblBestQuotedRate");

                    Label lblBestQuotedRatedays = (Label)row.FindControl("lblBestQuotedRatedays");
                    Label lblBestQuotedRatedaysnew = (Label)previousRow.FindControl("lblBestQuotedRatedays");

                    Label lblgerigeshrinkage = (Label)row.FindControl("lblgerigeshrinkage");
                    Label lblgerigeshrinkagenew = (Label)previousRow.FindControl("lblgerigeshrinkage");

                    HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                    HiddenField hdnCurrentstageNext = (HiddenField)previousRow.FindControl("hdnCurrentstage");

                    HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                    HiddenField hdnperiviousstgaeNext = (HiddenField)previousRow.FindControl("hdnperiviousstgae");


                    HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                    HiddenField hdnIsStyleSpecificNext = (HiddenField)previousRow.FindControl("hdnIsStyleSpecific");

                    HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                    HiddenField hdnStyleIDNext = (HiddenField)previousRow.FindControl("hdnStyleID");

                    Label lblBalanceTooltip = (Label)row.FindControl("lblBalanceTooltip");
                    Label lblBalanceTooltipnext = (Label)previousRow.FindControl("lblBalanceTooltip");


                    HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                    HiddenField hdnadjustmentqtyNext = (HiddenField)previousRow.FindControl("hdnadjustmentqty");


                    if (hdnIsStyleSpecific.Value == "True")
                    {
                        A = A + hdnCurrentstage.Value + hdnperiviousstgae.Value + hdnIsStyleSpecific.Value + hdnStyleID.Value;
                        B = B + hdnCurrentstageNext.Value + hdnperiviousstgaeNext.Value + hdnIsStyleSpecificNext.Value + hdnStyleIDNext.Value;
                    }
                    else
                    {
                        A = A + hdnCurrentstage.Value + hdnperiviousstgae.Value + hdnIsStyleSpecific.Value;
                        B = B + hdnCurrentstageNext.Value + hdnperiviousstgaeNext.Value + hdnIsStyleSpecificNext.Value;
                    }

                    if (A == B)
                    {
                        //if (lblbalanceinhouseqty.Text != "")
                        //    balinhouseqty = balinhouseqty + Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                        //if (lblbalanceinhouseqtynew.Text != "")
                        //    balinhouseqty = balinhouseqty + Convert.ToInt32(lblbalanceinhouseqtynew.Text.Replace(",", ""));


                        //if (hdnadjustmentqty.Value != "")
                        //    balinhouseqtytooltip = balinhouseqtytooltip + Convert.ToInt32(hdnadjustmentqty.Value.Replace(",", ""));

                        //if (hdnadjustmentqtyNext.Value != "")
                        //    balinhouseqtytooltip = balinhouseqtytooltip + Convert.ToInt32(hdnadjustmentqtyNext.Value.Replace(",", ""));


                        row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                        previousRow.Cells[0].Visible = false;

                        row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                        previousRow.Cells[1].Visible = false;

                        row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                        previousRow.Cells[2].Visible = false;

                        row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                        previousRow.Cells[3].Visible = false;

                        row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                        previousRow.Cells[4].Visible = false;

                        row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
                        previousRow.Cells[5].Visible = false;

                        row.Cells[6].RowSpan = previousRow.Cells[6].RowSpan < 2 ? 2 : previousRow.Cells[6].RowSpan + 1;
                        previousRow.Cells[6].Visible = false;

                        row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
                        previousRow.Cells[7].Visible = false;

                        row.Cells[8].RowSpan = previousRow.Cells[8].RowSpan < 2 ? 2 : previousRow.Cells[8].RowSpan + 1;
                        previousRow.Cells[8].Visible = false;

                        row.Cells[9].RowSpan = previousRow.Cells[9].RowSpan < 2 ? 2 : previousRow.Cells[9].RowSpan + 1;
                        previousRow.Cells[9].Visible = false;

                        row.Cells[10].RowSpan = previousRow.Cells[10].RowSpan < 2 ? 2 : previousRow.Cells[10].RowSpan + 1;
                        previousRow.Cells[10].Visible = false;

                        row.Cells[11].RowSpan = previousRow.Cells[11].RowSpan < 2 ? 2 : previousRow.Cells[11].RowSpan + 1;
                        previousRow.Cells[11].Visible = false;

                        row.Cells[12].RowSpan = previousRow.Cells[12].RowSpan < 2 ? 2 : previousRow.Cells[12].RowSpan + 1;
                        previousRow.Cells[12].Visible = false;

                        row.Cells[13].RowSpan = previousRow.Cells[13].RowSpan < 2 ? 2 : previousRow.Cells[13].RowSpan + 1;
                        previousRow.Cells[13].Visible = false;

                        row.Cells[14].RowSpan = previousRow.Cells[14].RowSpan < 2 ? 2 : previousRow.Cells[14].RowSpan + 1;
                        previousRow.Cells[14].Visible = false;

                        row.Cells[15].RowSpan = previousRow.Cells[15].RowSpan < 2 ? 2 : previousRow.Cells[15].RowSpan + 1;
                        previousRow.Cells[15].Visible = false;

                        row.Cells[16].RowSpan = previousRow.Cells[16].RowSpan < 2 ? 2 : previousRow.Cells[16].RowSpan + 1;
                        previousRow.Cells[16].Visible = false;

                        row.Cells[16].RowSpan = previousRow.Cells[17].RowSpan < 2 ? 2 : previousRow.Cells[17].RowSpan + 1;
                        previousRow.Cells[17].Visible = false;

                        row.Cells[18].RowSpan = previousRow.Cells[18].RowSpan < 2 ? 2 : previousRow.Cells[18].RowSpan + 1;
                        previousRow.Cells[18].Visible = false;

                        row.Attributes.Add("class", "bgon" + row.RowIndex.ToString());
                        previousRow.Attributes.Add("class", "bgon" + row.RowIndex.ToString());
                        row.Attributes.Add("onclick", "funcolor(" + "'" + row.RowIndex.ToString() + "'" + ")");
                        previousRow.Attributes.Add("onclick", "funcolor(" + "'" + row.RowIndex.ToString() + "'" + ")");


                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void MergeRows(GridView gridView)
        {
            if (gridView.Rows.Count > 1)
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];
                    if (row.Cells[0].Text != "" && previousRow.Cells[0].Text != "")
                    {
                        if (row.Cells[0].Text == previousRow.Cells[0].Text)
                        {
                            row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                                   previousRow.Cells[0].RowSpan + 1;
                            previousRow.Cells[0].Visible = false;
                            gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                            gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");

                        }
                        else
                        {
                            gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                            gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");
                        }
                    }
                    gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                    gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");
                }
            }
            else
            {
                if (gridView.Rows.Count > 0)
                {
                    gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                    gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");
                }
            }
        }

        #endregion

        #region Mail Function

        public void randorHtml()
        {
            try
            {
                AdminController objadmin = new AdminController();

                string strHTML = "";
                string ss = host + "/../../FabricPurChasedFormPrint.aspx?" + Session["q"] + "&AuthName=" + "" + "&AuthPhoto=" + "" + "&ApproName=" + "" + "&ApproPhoto=" + "" + "&PoNumberPrint=" + hdnponumber.Value;
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



                string filename = "POFabric_view" + hdnponumber.Value + ".HTML";
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
                if (hdnIsMailSend.Value == "1")
                {
                    genertaePdf(strHTML, "ss");
                    DataTable dtgrid = new DataTable();
                    dtgrid = objadmin.GetSuppliarDetails(Convert.ToInt32(hdnmasterpoid.Value)).Tables[0];
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
                            string name = "POFabric_" + hdnponumber.Value + ".pdf";
                            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + name);
                            if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                            {

                                string FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                                atts.Add(new Attachment(FitsPath));
                            }

                            this.SendEmail(fromName, to, null, null, "Fabric PO (" + hdnponumber.Value + ")", name, atts, false, false, hdnponumber.Value);

                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  randorHtml function  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            Session["q"] = null;
            hdnSessionQ.Value = "";
            hdnIsMailSend.Value = "";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "alert('Mail sent')", true);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);

        }
        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync, string po_Number)
        {

            var uri = new Uri(host + "/../../FabricPurChasedFormPrint.aspx?" + hdnSessionQ.Value.ToString());

            var query = HttpUtility.ParseQueryString(uri.Query);

            string flag = "fabricPO";

            string[] array = GetPoDetailsForMail_Fabric(po_Number, flag);

            string tradeName = array[0];
            string supplierName = array[1];
            string receivedQty = array[2];
            string rate = array[3];
            string eta = array[4];
            string Order_text = array[5];





            var FabricQuality = query.Get("FabricQuality");
            hdnStageName.Value = query.Get("FabType").ToString();
            if (hdnStageName.Value == "GRIEGE")
            {
                hdnFabTypeForMail.Value = "GRIEGE";
            }
            else
            {
                hdnFabTypeForMail.Value = hdnStageName.Value;
            }

            //hdnFabricQuality.Value = hdnFabricQuality.Value.Contains('(') ? hdnFabricQuality.Value.Substring(0, hdnFabricQuality.Value.IndexOf('(')) : hdnFabricQuality.Value;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = Subject;
            //mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a Purchase Order " + hdintialsuppliercode.Value + " is raised against for  <span style='color:gray'>" + "Fabric Quality - " + hdnFabricQuality.Value + "</span> for stage  <span style='color:gray'> " + Fabtype.ToString() + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> <u>Disclaimer</u> : This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            mailMessage.Body = "<p><span style='font-size:13px; font-family:Arial;'>Dear&nbsp;<b style='font-size:14px;'>" + supplierName + ",</b><br><br><strong><span style='font-size:14px;'>Greetings from BIPL.</span></strong></span></p><p></p><p>We are pleased to confirm " + Order_text + "&nbsp<b style='color:#3727FE;font-weight:600;font-size:16px;'>" + po_Number + ",&nbsp;</b>for <b style='color:#3727FE;font-weight:600;font-size:16px;'>" + tradeName + "</b>&nbsp;of quantity <b style='color:#3727FE;fontweight:600;font-size:16px;'>" + Convert.ToDecimal(receivedQty).ToString("#,#.##") + "&nbsp;</b>@ ₹<b style='color:#37591A;font-weight:600;font-size:16px;'>" + rate + "</b> with eta <b style='color:#3727FE;font-weight:600;font-size:16px;'>" + eta + "</b> to you.</p><p><span style='color:#F489A2;'>Please read all instructions and details on PO and contact material team for any issues.</span></p><p><span style='color:#838383;font-size:13px;'>This is a system generated email so please don't reply.</span></p><p><strong>Thanks &amp; Best Regards&nbsp;</strong></p><p><strong>BIPL Team</strong></p>";
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
                mailMessage.CC.Add("sanjeev.v@boutique.in");
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
            try
            {
                string filename = "POFabric_" + hdnponumber.Value + ".pdf";
                string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
                using (var pechkin = Factory.Create(new GlobalConfig()))
                {
                    var pdf = pechkin.Convert(new ObjectConfig()
                                            .SetLoadImages(true).SetZoomFactor(1.5)
                                            .SetPrintBackground(true)
                                            .SetScreenMediaType(true)
                                            .SetCreateExternalLinks(true), (HTMLCode.Replace("flow-root;", "none;")));

                    using (FileStream file = System.IO.File.Create(strFileName))
                    {
                        file.Write(pdf, 0, pdf.Length);
                    }
                }

            }
            catch { }
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
        public string[] GetPoDetailsForMail_Fabric(string po_Number, string flag)
        {
            return fabobj.GetDetailsForMail(po_Number, flag);
        }

        #endregion
    }
}

