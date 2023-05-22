using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Text;
using System.Net;
using System.IO;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.UserControls.Forms
{
    public partial class FabricSupplierQuotation : BaseUserControl
    {
        FabricController fabobj = new FabricController();
        AdminController onjadminCon = new AdminController();

        static DataTable DtPopupdata = new DataTable();

        int Userid = -1;

        string host = "";

        public string Fabtype
        {
            get;
            set;

        }

        public string Search
        {
            get;
            set;

        }

        public void getquerystring()
        {
            if (Request.QueryString["Fabtype"] != null)
            {
                Fabtype = Request.QueryString["Fabtype"].ToString();
            }
            else
            {
                Fabtype = "";
            }
            if (Request.QueryString["Search"] != null)
            {
                Search = Request.QueryString["Search"].ToString();
            }
            else
            {
                Search = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            host = "http://" + Request.Url.Authority;
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            getquerystring();
            if (!Page.IsPostBack)
            {
                Session["callbackclass"] = "";
                BindSupplierSpecificTab();
                BindFabricTabs();
            }
        }

        protected void LinkSupplyTab_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Fabtype = btn.CommandArgument;
            hdntabvalue.Value = btn.CommandArgument;
            BindFabricTabs();
            SetTab();

        }

        public void SetTab()
        {

            if (hdntabvalue.Value != null)
            {
                string SupplyTypeTab = hdntabvalue.Value;

                dvMymodelPopup.Attributes["class"] = dvMymodelPopup.Attributes["class"].Replace("Popupshow", "Popuphide").Trim();
                LnkGRIEGE.CssClass = "tab1greige";
                LnkDYED.CssClass = "tab1Dayed";
                LnkPRINT.CssClass = "tab1Print";
                LnkFINISHED.CssClass = "tab1finished";
                LnkRFD.CssClass = "tab1OtherRFD";

                grdGriege.Visible = false;
                grdDyed.Visible = false;
                grdprint.Visible = false;
                grdfinishing.Visible = false;
                grdRfd.Visible = false;

                switch (SupplyTypeTab)
                {
                    case "GREIGE":
                        grdGriege.Visible = true; LnkGRIEGE.CssClass = "activeback tab1greige";
                        break;
                    case "DYED":
                        grdDyed.Visible = true; LnkDYED.CssClass = "activeback tab1Dayed";
                        break;
                    case "PRINT":
                        grdprint.Visible = true; LnkPRINT.CssClass = "activeback tab1Print";
                        break;
                    case "FINISHED":
                        grdfinishing.Visible = true; LnkFINISHED.CssClass = "activeback tab1finished";
                        break;
                    case "RFD":
                        grdRfd.Visible = true; LnkRFD.CssClass = "activeback tab1OtherRFD";
                        break;
                    default:
                        goto case "GREIGE";
                }
                // dvMymodelPopup.Attributes["class"] = dvMymodelPopup.Attributes["class"].Replace("Popupshow", "Popuphide").Trim();
            }

        }

        private static void BindSerialAndStyle(GridView gridView, DataSet dtserialStyle, string Type)
        {
            foreach (GridViewRow row in gridView.Rows)
            {
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnfabricdetails = (HiddenField)row.FindControl("hdnfabricdetails");
                HiddenField hdnstyleid = (HiddenField)row.FindControl("hdnstyleid");
                Repeater RptStyle = (Repeater)row.FindControl("RptStyle");
                Repeater RptStyle1 = (Repeater)row.FindControl("RptStyle1");

                Repeater RptStylePreviousStage = (Repeater)row.FindControl("RptStylePreviousStage");
                Repeater RptStyleCurrentStage = (Repeater)row.FindControl("RptStyleCurrentStage");   

                string filter = "";

                filter = " Fabric_QualityID='" + hdnfabricQuality.Value + "' ";
                if (Type == "F" || Type == "D" || Type == "P")
                    filter = filter + " and PrintName='" + hdnfabricdetails.Value + "'  ";

                else if (Type == "RFD")
                {
                    //HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                    //HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");

                    filter = filter + " and PrintName='" + hdnfabricdetails.Value + "'";
                    //and Stage1='" + hdnstage1.Value + "' and Stage2='" + hdnstage2.Value + "'  ";
                }

                DataRow[] dv = dtserialStyle.Tables[1].Select(filter);
                if (dv.Count() > 0)
                {
                    RptStyle.DataSource = dv.CopyToDataTable();
                    RptStyle.DataBind();
                    RptStyle1.DataSource = dv.CopyToDataTable();
                    RptStyle1.DataBind();
                }
                if (Type != "G")
                {
                    DataRow[] dv1 = dtserialStyle.Tables[3].Select(filter);
                    if (dv1.Count() > 0)
                    {
                        RptStylePreviousStage.DataSource = dv1.CopyToDataTable();
                        RptStylePreviousStage.DataBind();

                        RptStyleCurrentStage.DataSource = dv1.CopyToDataTable();
                        RptStyleCurrentStage.DataBind();
                    }
                }

            }

            #region merging logic

            #region merging logic for griege
            if (Type == "G")
            {
                for (int i = gridView.Rows.Count - 2; i >= 0; i--)
                {
                    GridViewRow row = gridView.Rows[i];
                    GridViewRow previousRow = gridView.Rows[i + 1];

                    Repeater rpt1 = (Repeater)row.FindControl("RptStyle");
                    Repeater rpt11 = (Repeater)row.FindControl("RptStyle1");

                    Repeater rpt2 = (Repeater)previousRow.FindControl("RptStyle");
                    Repeater rpt22 = (Repeater)previousRow.FindControl("RptStyle1");

                    string s1 = "";
                    string s2 = "";

                    s1 = s1 + ((HiddenField)row.FindControl("hdnTradeName")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnGSM")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnwidth")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnCC")).Value;

                    foreach (RepeaterItem rptitem in rpt1.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                    }

                    foreach (RepeaterItem rptitem in rpt11.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                    }

                    s1 = s1 + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnUnits")).Value;
                    //s1 = s1 + ((HiddenField)row.FindControl("hdnGreigeSh")).Value;


                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnTradeName")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnGSM")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnwidth")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnCC")).Value;

                    foreach (RepeaterItem rptitem in rpt2.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                    }

                    int ItemCount = rpt1.Items.Count - 1;

                    for (int ii = rpt1.Items.Count - 1; ii > 0; ii--)
                    {
                        HtmlTableCell cellPrev = rpt1.Items[ii - 1].FindControl("tdstylenumber") as HtmlTableCell;
                        HtmlTableCell cell = rpt1.Items[ii].FindControl("tdstylenumber") as HtmlTableCell;
                        cell.RowSpan = (cell.RowSpan == -1) ? 1 : cell.RowSpan;
                        cellPrev.RowSpan = (cellPrev.RowSpan == -1) ? 1 : cellPrev.RowSpan;

                        if (cell.InnerText == cellPrev.InnerText)
                        {
                            cellPrev.RowSpan += cell.RowSpan;
                            cell.Visible = false;
                        }
                    }

                    foreach (RepeaterItem rptitem in rpt22.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                    }

                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnUnits")).Value;
                    //s2 = s2 + ((HiddenField)previousRow.FindControl("hdnGreigeSh")).Value;



                    if (s1.ToLower() == s2.ToLower())
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
                    }
                }
            }
            #endregion merging logic for griege

            #region merging logic for rfd
            else if (Type == "RFD")
            {
                for (int i = gridView.Rows.Count - 2; i >= 0; i--)
                {
                    GridViewRow row = gridView.Rows[i];
                    GridViewRow previousRow = gridView.Rows[i + 1];

                    Repeater rpt1 = (Repeater)row.FindControl("RptStyle");
                    Repeater rpt11 = (Repeater)row.FindControl("RptStyle1");
                    Repeater RptStyleCurrentStagerow = (Repeater)row.FindControl("RptStyleCurrentStage");
                    Repeater RptStylePreviousStagerow = (Repeater)row.FindControl("RptStylePreviousStage");



                    Repeater rpt2 = (Repeater)previousRow.FindControl("RptStyle");
                    Repeater rpt22 = (Repeater)previousRow.FindControl("RptStyle1");
                    Repeater RptStyleCurrentStagepreviousRow = (Repeater)previousRow.FindControl("RptStyleCurrentStage");
                    Repeater RptStylePreviousStagepreviousRow = (Repeater)previousRow.FindControl("RptStylePreviousStage");



                    string s1 = "";
                    string s2 = "";

                    s1 = s1 + ((HiddenField)row.FindControl("hdnTradeName")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnGSM")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnwidth")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnCC")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnFabricDetail")).Value;

                    foreach (RepeaterItem rptitem in rpt1.Items)
                    {

                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;

                    }
                    foreach (RepeaterItem rptitem in rpt11.Items)
                    {

                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;

                    }

                    s1 = s1 + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnUnits")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnResSh")).Value;

                    foreach (RepeaterItem rptitem in RptStyleCurrentStagerow.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;
                    }
                    foreach (RepeaterItem rptitem in RptStylePreviousStagerow.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }                


                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnTradeName")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnGSM")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnwidth")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnCC")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnFabricDetail")).Value;

                    foreach (RepeaterItem rptitem in rpt2.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                    }


                    foreach (RepeaterItem rptitem in rpt22.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                    }

                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnUnits")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnResSh")).Value;

                    foreach (RepeaterItem rptitem in RptStyleCurrentStagepreviousRow.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;
                    }
                    foreach (RepeaterItem rptitem in RptStylePreviousStagepreviousRow.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }
                


                    if (s1.ToLower() == s2.ToLower())
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

                        
                    }

                  
                }

            }
            #endregion merging logic for rfd

            else
            {
                for (int i = gridView.Rows.Count - 2; i >= 0; i--)
                {
                    GridViewRow row = gridView.Rows[i];
                    GridViewRow previousRow = gridView.Rows[i + 1];

                    Repeater rpt1 = (Repeater)row.FindControl("RptStyle");
                    Repeater rpt11 = (Repeater)row.FindControl("RptStyle1");
                    Repeater rpt111 = (Repeater)row.FindControl("RptStyleCurrentStage");
                    Repeater rpt1111 = (Repeater)row.FindControl("RptStylePreviousStage");

                    Repeater rpt2 = (Repeater)previousRow.FindControl("RptStyle");
                    Repeater rpt22 = (Repeater)previousRow.FindControl("RptStyle1");
                    Repeater rpt222 = (Repeater)previousRow.FindControl("RptStyleCurrentStage");
                    Repeater rpt2222 = (Repeater)previousRow.FindControl("RptStylePreviousStage");


                    string s1 = "";
                    string s2 = "";

                    //s1 start

                    s1 = s1 + ((HiddenField)row.FindControl("hdnTradeName")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnGSM")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnwidth")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnCC")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnFabricDetail")).Value;            

                    foreach (RepeaterItem rptitem in rpt1.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;                       
                    }

                    foreach (RepeaterItem rptitem in rpt11.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                    }

                    s1 = s1 + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnUnits")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnResSh")).Value;

                    foreach (RepeaterItem rptitem in rpt111.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;

                    }

                    foreach (RepeaterItem rptitem in rpt1111.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }

                    //s2 start

                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnTradeName")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnGSM")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnwidth")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnCC")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnFabricDetail")).Value;
                 

                    foreach (RepeaterItem rptitem in rpt2.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                    }

                    foreach (RepeaterItem rptitem in rpt22.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                    }

                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnUnits")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnResSh")).Value;

                    foreach (RepeaterItem rptitem in rpt222.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;

                    }

                    foreach (RepeaterItem rptitem in rpt2222.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }

                    if (s1.ToLower() == s2.ToLower())
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
                    }
                }
            }
            #endregion merging logic

            #region merging logic for stylenumber which is inside repeater

            if (Type !="G")
            {
                for (int i = gridView.Rows.Count - 2; i >= 0; i--)
                {
                    GridViewRow row = gridView.Rows[i];
                    GridViewRow previousRow = gridView.Rows[i + 1];


                    Repeater rpt1 = (Repeater)row.FindControl("RptStyle");
                    int ItemCount = rpt1.Items.Count - 1;
                    for (int ii = rpt1.Items.Count - 1; ii > 0; ii--)
                    {
                        HtmlTableCell cellPrev = rpt1.Items[ii - 1].FindControl("tdstylenumber") as HtmlTableCell;
                        HtmlTableCell cell = rpt1.Items[ii].FindControl("tdstylenumber") as HtmlTableCell;
                        cell.RowSpan = (cell.RowSpan == -1) ? 1 : cell.RowSpan;
                        cellPrev.RowSpan = (cellPrev.RowSpan == -1) ? 1 : cellPrev.RowSpan;

                        if (cell.InnerText == cellPrev.InnerText)
                        {
                            cellPrev.RowSpan += cell.RowSpan;
                            cell.Visible = false;
                        }
                    }

                }
            }
            #endregion merging logic for stylenumber which is inside repeater

        }

        private void BindFabricTabs()
        {
            int userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            if (userid == 122) { userid = 0; }

            if (Fabtype.ToLower() == "GREIGE".ToLower() || Fabtype.ToLower() == "" || Fabtype == null)
            {
                DataSet dsGreige = fabobj.GetGriegeFabDetailsUserID("1", userid, "", txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);
                if (dsGreige.Tables[0].Rows.Count > 0)
                {
                    DtPopupdata = dsGreige.Tables[2];
                    grdGriege.DataSource = dsGreige.Tables[0];

                    grdGriege.DataBind();
                    BindSerialAndStyle(grdGriege, dsGreige, "G");

                    DtPopupdata = dsGreige.Tables[2];        
                }
                else
                {
                    grdGriege.DataSource = null;
                    grdGriege.DataBind();
                }
                grdGriege.Visible = true;
            }
            else if (Fabtype.ToLower() == "DYED".ToLower())
            {
                DataSet dsdyed = fabobj.GetGriegeFabDetailsUserID("5", userid, "", txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);
                if (dsdyed.Tables[0].Rows.Count > 0)
                {
                    grdDyed.DataSource = dsdyed.Tables[0];
                    grdDyed.DataBind();

                    BindSerialAndStyle(grdDyed, dsdyed, "D");               

                    DtPopupdata = dsdyed.Tables[2];               
                }
                else
                {
                    grdDyed.DataSource = null;
                    grdDyed.DataBind();
                }
                grdDyed.Visible = true;
            }
            else if (Fabtype.ToLower() == "PRINT".ToLower())
            {
                DataSet dsprint = fabobj.GetGriegeFabDetailsUserID("7", userid, "", txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);
                if (dsprint.Tables[0].Rows.Count > 0)
                {
                    grdprint.DataSource = dsprint.Tables[0];
                    grdprint.DataBind();
                    BindSerialAndStyle(grdprint, dsprint, "P");
                  
                    DtPopupdata = dsprint.Tables[2];                
                }
                else
                {
                    grdprint.DataSource = null;
                    grdprint.DataBind();
                }

                grdprint.Visible = true;
            }
            else if (Fabtype.ToLower() == "FINISHED".ToLower())
            {
                DataSet dsfinishing = fabobj.GetGriegeFabDetailsUserID("3", userid, "", txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);

                if (dsfinishing.Tables[0].Rows.Count > 0)
                {
                    grdfinishing.DataSource = dsfinishing.Tables[0];
                    grdfinishing.DataBind();
                    BindSerialAndStyle(grdfinishing, dsfinishing, "F");
                    DtPopupdata = dsfinishing.Tables[2];
         
                    LinkButton lnkbtn = grdfinishing.Rows[0].FindControl("btnlnkpopup") as LinkButton;
                }
                else
                {
                    grdfinishing.DataSource = null;
                    grdfinishing.DataBind();
                }
                grdfinishing.Visible = true;
            }
            else if (Fabtype.ToLower() == "RFD".ToLower())
            {
                DataSet dsRfd = fabobj.GetOtherVaSupplierQoutation("BASIC", userid, txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);
                if (dsRfd.Tables[0].Rows.Count > 0)
                {
                    grdRfd.DataSource = dsRfd.Tables[0];
                    grdRfd.DataBind();

                    BindSerialAndStyle(grdRfd, dsRfd, "RFD");
                  
                    DtPopupdata = dsRfd.Tables[2];
                }
                else
                {
                    grdRfd.DataSource = null;
                    grdRfd.DataBind();
                }
                grdRfd.Visible = true;
            }
        }

        private void BindSupplierSpecificTab()
        {
            DataSet ds = new DataSet();
            DataTable dtFabtype = new DataTable();
            DataTable dtSupplier = new DataTable();
            ds = fabobj.GetGriegeFabDetailsUserID("9", iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID, "", "", DdlSearchType.SelectedValue);
            dtFabtype = ds.Tables[0];
            dtSupplier = ds.Tables[1];

            if (dtFabtype.Rows.Count > 0)
            {
                LnkGRIEGE.Style.Add("Display", "none;");
                LnkDYED.Style.Add("Display", "none;");
                LnkPRINT.Style.Add("Display", "none;");
                LnkFINISHED.Style.Add("Display", "none;");
                LnkRFD.Style.Add("Display", "none");
                int iCheckActiveTabClass = 0;
                foreach (DataRow dr in dtFabtype.Rows)
                {
                    if (dr["Name"].ToString().ToLower() == "Griege".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkGRIEGE.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkGRIEGE.Attributes.Add("class", "activeback tab1greige");
                            grdGriege.Style.Remove("display");
                        }
                    }
                    if (dr["Name"].ToString().ToLower() == "Dyed".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkDYED.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkDYED.Attributes.Add("class", "activeback tab1Dayed");
                            grdDyed.Style.Remove("display");
                        }
                    }
                    if (dr["Name"].ToString().ToLower() == "Printed".ToLower() || dr["Name"].ToString().ToLower() == "Digital Printed".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkPRINT.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkPRINT.Attributes.Add("class", "activeback tab1Print");
                            grdprint.Style.Remove("display");
                        }
                    }
                    if (dr["Name"].ToString().ToLower() == "Finished".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkFINISHED.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkFINISHED.Attributes.Add("class", "activeback tab1finished");
                            grdfinishing.Style.Remove("display");
                        }
                    }

                    if (dr["Name"].ToString().ToLower() == "Fabric softening".ToLower() || dr["Name"].ToString().ToLower() == "Width adjustment".ToLower() || dr["Name"].ToString().ToLower() == "RFD".ToLower() || dr["Name"].ToString().ToLower() == "Embellishment".ToLower() || dr["Name"].ToString().ToLower() == "Embroidery".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkRFD.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkRFD.Attributes.Add("class", "activeback tab1OtherRFD");
                            grdRfd.Style.Remove("display");
                        }
                    }
                }
                if (iCheckActiveTabClass == 0)
                {
                    LnkGRIEGE.Attributes.Add("class", "activeback tab1Dayed");
                    grdGriege.Style.Remove("display");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Fabtype = hdntabvalue.Value;
            BindFabricTabs();
            SetTab();
        }

        protected void GrdAllPo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string Flag = "";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnstatus = (HiddenField)e.Row.FindControl("hdnstatus");
                HtmlAnchor anchortag = e.Row.FindControl("hrfopenpopopup") as HtmlAnchor;

                if (hdnstatus.Value == "2")
                {
                    e.Row.Attributes.CssStyle.Value = "background-color: #ffc9c6;";
                    e.Row.ToolTip = "Closed PO";
                }
                if (hdnstatus.Value == "1")
                {
                    e.Row.Attributes.CssStyle.Value = "background-color: #fbcba2;";
                    e.Row.ToolTip = "Cancel PO";
                }
                Label lblpoqty = (Label)e.Row.FindControl("lblpoqty");
                if (Convert.ToDouble(lblpoqty.Text.Replace(",", "")) > 999)
                {
                    double d = Convert.ToDouble(lblpoqty.Text.Replace(",", "")) / Convert.ToDouble(1000);
                    lblpoqty.ToolTip = lblpoqty.Text;
                    lblpoqty.Text = Math.Round(d, 0) + " " + "k";
                }

                Button btnAccept = (Button)e.Row.FindControl("btnAccept");
                HiddenField hdnIsPartySignature = (HiddenField)e.Row.FindControl("hdnIsPartySignature");
                if (hdnIsPartySignature.Value.ToLower() == "false" && hdnstatus.Value != "2" && hdnstatus.Value != "1")
                    btnAccept.Visible = true;
                else
                    btnAccept.Visible = false;
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string confirmValue = confirm_value.Value;
            if (confirmValue == "Yes")
            {
                Button btnAccept = sender as Button;
                GridViewRow gvRow = btnAccept.NamingContainer as GridViewRow;
                string MasterPO_Id = (gvRow.FindControl("hdnMasterPO_Id") as HiddenField).Value;
                string PO_Number = (gvRow.FindControl("hdnPO_Number") as HiddenField).Value;

                string hdnQueryString = (gvRow.FindControl("hdnQueryString") as HiddenField).Value;
                try
                {
                    int sign = onjadminCon.UpdatePartySignBySupplier(Convert.ToInt32(MasterPO_Id), iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID, "Fabric");
                    if (sign > 0)
                    {
                        randorHtml(PO_Number, hdnQueryString);
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  btnAccept_Click function  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            confirm_value.Value = "No";
            btnSearch_Click(sender, e);
        }

        public void randorHtml(string hdnponumber, string QueryString)
        {
            try
            {
                string strHTML = "";
                string ss = host + "/../../FabricPurChasedFormPrint.aspx?AuthName=" + "" + "&AuthPhoto=" + "" + "&ApproName=" + "" + "&ApproPhoto=" + "" + "&" + QueryString;
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

                string filename = "POFabric_view" + hdnponumber + ".HTML";
                string strFileNameashtml = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);

                if ((File.Exists(strFileNameashtml)))
                {
                    File.Delete(strFileNameashtml);
                }
                using (FileStream fs = File.Create(strFileNameashtml))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes(strHTML);
                    fs.Write(title, 0, title.Length);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  randorHtml function  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }



        }

        protected void showPO(object sender, EventArgs e)
        {
            LinkButton lnkbtnpopup = sender as LinkButton;
            GridViewRow gvRow = lnkbtnpopup.NamingContainer as GridViewRow;
            GridView grdname = gvRow.Parent.Parent as GridView;
            string fabricQualityid = (gvRow.FindControl("hdnfabricQuality") as HiddenField).Value;
            string FabricDetails = (gvRow.FindControl("hdnfabricdetails") as HiddenField).Value;

            

            string filter = " Fabric_QualityID= '" + fabricQualityid + "'";

            if (grdname.ID == "grdDyed" || grdname.ID == "grdprint" || grdname.ID == "grdfinishing" || grdname.ID == "grdRfd")
            {
                filter = filter + "  and PrintName= '" + FabricDetails + "'  ";
            }

            //if (hdntabvalue.Value.ToUpper() == "RFD")
            //{
            //    string stage1 = (gvRow.FindControl("hdnstage1") as HiddenField).Value;
            //    string stage2 = (gvRow.FindControl("hdnstage2") as HiddenField).Value;

            //    if (stage1 == "29")
            //        filter = filter + " and PrintName=    '" + FabricDetails + "' ";
            //        //and Stage1= '" + stage1 + "'  ";
            //    else
            //        filter = filter + " and PrintName=    '" + FabricDetails + "' ";
            //        //and Stage1= '" + stage1 + "'   and Stage2= '" + stage2 + "' ";
            //}

            DataRow[] dr = DtPopupdata.Select(filter);
            if (dr.Count() > 0)
            {                
                dr.CopyToDataTable().DefaultView.Sort = "PODate DESC";
                GrdAllPo.DataSource = dr.CopyToDataTable();
                GrdAllPo.DataBind();
            }
            else
            {
                GrdAllPo.DataSource = null;
                GrdAllPo.DataBind();
            }

            dvMymodelPopup.Attributes.Remove("Popuphide");
            dvMymodelPopup.Attributes["class"] = dvMymodelPopup.Attributes["class"].Replace("Popuphide", "Popupshow").Trim();


        }
    }

}

