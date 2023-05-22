using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Text;
using System.Net;
using System.IO;
using System.Linq;

namespace iKandi.Web.UserControls.Forms
{
    public partial class StyleSpecificSupplierQuotation : System.Web.UI.UserControl
    {
        FabricController fabobj = new FabricController();
        AdminController onjadminCon = new AdminController();
        public static DataTable Openpopupdata = new DataTable();
        int Userid = -1;
        string host = "";
        public string Currentatab
        {
            get
            {
                return (HttpContext.Current.Session["tabs"] == null) ? "" : HttpContext.Current.Session["tabs"].ToString();
            }
        }
        public string Fabtype { get; set; }
        public string Search { get; set; }
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
                BindStyleSpecificTabs();
            }
        }

        protected void LinkSupplyTab_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Fabtype = btn.CommandArgument;
            hdntabvalue.Value = btn.CommandArgument;
            BindStyleSpecificTabs();
            SetTab();
        }

        public void SetTab()
        {
            if (hdntabvalue.Value != null)
            {
                divmModelPopupForStyleSpecific.Attributes["class"] = divmModelPopupForStyleSpecific.Attributes["class"].Replace("Popupshow", "Popuphide").Trim();
                string SupplyTypeTab = hdntabvalue.Value;

                LnkDYEDStyle.CssClass = "tab1Dayed";
                LnkPRINTStyle.CssClass = "tab1Print";
                LnkEmbeEmbr.CssClass = "tab1EmbeEmbr";

                grddayedstyle.Visible = false;
                grdprintstyle.Visible = false;
                grdEmbeEmbr.Visible = false;

                switch (SupplyTypeTab)
                {
                    case "DYEDStyle":
                        grddayedstyle.Visible = true;
                        LnkDYEDStyle.CssClass = "activeback tab1Dayed";
                        break;
                    case "PRINTStyle":
                        grdprintstyle.Visible = true;
                        LnkPRINTStyle.CssClass = "activeback tab1Print";
                        break;
                    case "EmbeEmbr":
                        grdEmbeEmbr.Visible = true;
                        LnkEmbeEmbr.CssClass = "activeback tab1EmbeEmbr";
                        break;
                    default:
                        goto case "DYEDStyle";
                }
            }
        }

        public static void MergeRowsEmbeEmbr(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnfabricQualitynew = (HiddenField)previousRow.FindControl("hdnfabricQuality");

                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcolornew = (Label)previousRow.FindControl("lblcolor");

                Label lblvaname = (Label)row.FindControl("lblvaname");
                Label lblvanamenext = (Label)previousRow.FindControl("lblvaname");

                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage1next = (HiddenField)previousRow.FindControl("hdnstage1");

                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage2next = (HiddenField)previousRow.FindControl("hdnstage2");

                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage3next = (HiddenField)previousRow.FindControl("hdnstage3");

                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnstage4next = (HiddenField)previousRow.FindControl("hdnstage4");

                string A = hdnfabricQuality.Value + lblcolor.Text + lblvaname.Text + hdnstage1.Value + hdnstage2.Value + hdnstage3.Value + hdnstage4.Value;
                string B = hdnfabricQualitynew.Value + lblcolornew.Text + lblvanamenext.Text + hdnstage1next.Value + hdnstage2next.Value + hdnstage3next.Value + hdnstage4next.Value;

                HiddenField hdnstyleid = (HiddenField)row.FindControl("hdnstyleid");
                HiddenField hdnstyleidnext = (HiddenField)previousRow.FindControl("hdnstyleid");

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

                    if (hdnstyleid.Value == hdnstyleidnext.Value)
                    {
                        if (lblvaname.Text == lblvanamenext.Text)
                        {
                            row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                            previousRow.Cells[4].Visible = false;


                            row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
                            previousRow.Cells[5].Visible = false;

                        }
                    }
                }
            }
        }

        public static void MergeRowsDayedPrint(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnfabricQualitynew = (HiddenField)previousRow.FindControl("hdnfabricQuality");

                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcolornew = (Label)previousRow.FindControl("lblcolor");

                string A = hdnfabricQuality.Value + lblcolor.Text;
                string B = hdnfabricQualitynew.Value + lblcolornew.Text;

                HiddenField hdnstyleid = (HiddenField)row.FindControl("hdnstyleid");
                HiddenField hdnstyleidnext = (HiddenField)previousRow.FindControl("hdnstyleid");


                if (A == B)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;

                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;

                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;

                    if (hdnstyleid.Value == hdnstyleidnext.Value)
                    {
                        row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                        previousRow.Cells[3].Visible = false;

                        row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                        previousRow.Cells[4].Visible = false;
                    }
                }
            }
        }

        private void BindSerialAndStyle(GridView gridView, DataSet dtserialStyle, string Type)
        {
            foreach (GridViewRow row in gridView.Rows)
            {
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnfabricdetails = (HiddenField)row.FindControl("hdnfabricdetails");
                HiddenField hdnstyleid = (HiddenField)row.FindControl("hdnstyleid");
                HiddenField hdnSupplierName = (HiddenField)row.FindControl("hdnSupplierName");

                Repeater RptStylePreviousStage = (Repeater)row.FindControl("RptStylePreviousStage");
                Repeater RptStyleCurrentStage = (Repeater)row.FindControl("RptStyleCurrentStage"); 

                Repeater RptStyle = (Repeater)row.FindControl("RptStyle");
                Repeater RptStyle1 = (Repeater)row.FindControl("RptStyle1");

                string Filter = string.Empty;
                Filter = " Fabric_QualityID='" + hdnfabricQuality.Value + "' and PrintName='" + hdnfabricdetails.Value + "' and StyleID='" + hdnstyleid.Value + "'  ";
                if (Type == "E")
                {
                    HiddenField hdnSupplyTypeId = (HiddenField)row.FindControl("hdnSupplyTypeId");
                    HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                    HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                    HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                    HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                    HiddenField hdnPreviousStage = (HiddenField)row.FindControl("hdnPreviousStage");

                    Filter = Filter + @"    and PreviousStage='" + hdnPreviousStage.Value + "' and SupplyTypeId='" + hdnSupplyTypeId.Value + @"'
                                            and Stage1='" + hdnstage1.Value + "' and Stage2='" + hdnstage2.Value + @"'
                                            and Stage3='" + hdnstage3.Value + "' and Stage4='" + hdnstage4.Value + "' ";

                }
                DataRow[] dv = dtserialStyle.Tables[1].Select(Filter);
                if (dv.Count() > 0)
                {
                    RptStyle.DataSource = dv.CopyToDataTable();
                    RptStyle.DataBind();
                    RptStyle1.DataSource = dv.CopyToDataTable();
                    RptStyle1.DataBind();
                }

                DataRow[] dv1 = dtserialStyle.Tables[3].Select(Filter);
                if (dv1.Count() > 0)
                {
                    RptStylePreviousStage.DataSource = dv1.CopyToDataTable();
                    RptStylePreviousStage.DataBind();

                    RptStyleCurrentStage.DataSource = dv1.CopyToDataTable();
                    RptStyleCurrentStage.DataBind();
                }
            }
            if (Type != "E")
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

                    string s1StyleNumber = "";
                    string s1SerialNumber = "";

                    string s2StyleNumber = "";

                    string s2SerialNumber = "";

                    s1 = s1 + ((HiddenField)row.FindControl("hdnTradeName")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnGSM")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnwidth")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnCC")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnFabricDetail")).Value;

                    foreach (RepeaterItem rptitem in rpt1.Items)
                    {
                        s1StyleNumber = s1StyleNumber + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                    }
                    foreach (RepeaterItem rptitem in rpt11.Items)
                    {
                        s1SerialNumber = s1SerialNumber + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                    }

                    foreach (RepeaterItem rptitem in rpt111.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;

                    }

                    foreach (RepeaterItem rptitem in rpt1111.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }

                    string s1CutMeterageRequired = "";

                    s1 = s1 + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;

                    s1CutMeterageRequired = s1CutMeterageRequired + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;

                    s1 = s1 + ((HiddenField)row.FindControl("hdnUnits")).Value;

                    s1CutMeterageRequired = s1CutMeterageRequired + ((HiddenField)row.FindControl("hdnUnits")).Value;

                    string s1ResidualShr	 = "";

                    s1 = s1 + ((HiddenField)row.FindControl("hdnResSh")).Value;
                    s1ResidualShr = s1ResidualShr + ((HiddenField)row.FindControl("hdnResSh")).Value;




                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnTradeName")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnGSM")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnwidth")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnCC")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnFabricDetail")).Value;

                    foreach (RepeaterItem rptitem in rpt2.Items)
                    {

                        s2StyleNumber = s2StyleNumber + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;

                    }


                    foreach (RepeaterItem rptitem in rpt22.Items)
                    {

                        s2SerialNumber = s2SerialNumber + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;

                    }
                    foreach (RepeaterItem rptitem in rpt222.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;

                    }

                    foreach (RepeaterItem rptitem in rpt2222.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }

                    string s2CutMeterageRequired = "";

                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;
                    s2CutMeterageRequired = s2CutMeterageRequired + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;

                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnUnits")).Value;
                    s2CutMeterageRequired = s2CutMeterageRequired + ((HiddenField)previousRow.FindControl("hdnUnits")).Value;

                    string s2ResidualShr = "";


                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnResSh")).Value;
                    s2ResidualShr = s2ResidualShr + ((HiddenField)previousRow.FindControl("hdnResSh")).Value;


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

                        if (s1StyleNumber.ToLower() == s2StyleNumber.ToLower())
                        {
                            row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
                            previousRow.Cells[7].Visible = false;


                        }
                        if (s1SerialNumber.ToLower() == s2SerialNumber.ToLower())
                        {
                            row.Cells[8].RowSpan = previousRow.Cells[8].RowSpan < 2 ? 2 : previousRow.Cells[8].RowSpan + 1;
                            previousRow.Cells[8].Visible = false;

                        }
                        if (s1CutMeterageRequired.ToLower() == s2CutMeterageRequired.ToLower())
                        {

                            row.Cells[9].RowSpan = previousRow.Cells[9].RowSpan < 2 ? 2 : previousRow.Cells[9].RowSpan + 1;
                            previousRow.Cells[9].Visible = false;
                        }

                        if (s1ResidualShr.ToLower() == s2ResidualShr.ToLower())
                        {

                            row.Cells[10].RowSpan = previousRow.Cells[10].RowSpan < 2 ? 2 : previousRow.Cells[10].RowSpan + 1;
                            previousRow.Cells[10].Visible = false;
                        }

                    }
                }
            }
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

                    string s1StyleNumber = "";
                    string s1SerialNumber = "";
                    string s1QuantityToOrder = "";
                    string s1ResSh = "";
                    string s1VAName = "";


                    string s2StyleNumber = "";
                    string s2SerialNumber = "";
                    string s2QuantityToOrder = "";
                    string s2ResSh = "";
                    string s2VAName = "";

                    s1 = s1 + ((HiddenField)row.FindControl("hdnTradeName")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnGSM")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnwidth")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnCC")).Value;
                    s1 = s1 + ((HiddenField)row.FindControl("hdnFabricDetail")).Value;

                    foreach (RepeaterItem rptitem in rpt1.Items)
                    {
                        s1StyleNumber = s1StyleNumber + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;
                    }
                    foreach (RepeaterItem rptitem in rpt11.Items)
                    {
                        s1SerialNumber = s1SerialNumber + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;
                    }

                    foreach (RepeaterItem rptitem in rpt111.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;

                    }

                    foreach (RepeaterItem rptitem in rpt1111.Items)
                    {
                        s1 = s1 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }

                    s1QuantityToOrder = s1QuantityToOrder + ((HiddenField)row.FindControl("hdnQuantityToOrder")).Value;
                    s1QuantityToOrder = s1QuantityToOrder + ((HiddenField)row.FindControl("hdnUnits")).Value;
                    s1QuantityToOrder = s1QuantityToOrder + ((HiddenField)row.FindControl("hdnVAWastage")).Value;


                    s1ResSh = s1ResSh + ((HiddenField)row.FindControl("hdnResSh")).Value;

                    s1VAName = s1VAName + ((Label)row.FindControl("lblvaname")).Text;
                    



                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnTradeName")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnGSM")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnwidth")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnCC")).Value;
                    s2 = s2 + ((HiddenField)previousRow.FindControl("hdnFabricDetail")).Value;

                    foreach (RepeaterItem rptitem in rpt2.Items)
                    {

                        s2StyleNumber = s2StyleNumber + ((HiddenField)rptitem.FindControl("hdnStyleNumber")).Value;

                    }


                    foreach (RepeaterItem rptitem in rpt22.Items)
                    {

                        s2SerialNumber = s2SerialNumber + ((HiddenField)rptitem.FindControl("hdnSerialNumber")).Value;

                    }
                    foreach (RepeaterItem rptitem in rpt222.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdncurrentStage")).Value;

                    }

                    foreach (RepeaterItem rptitem in rpt2222.Items)
                    {
                        s2 = s2 + ((HiddenField)rptitem.FindControl("hdnPreviousStage")).Value;
                    }

                    s2QuantityToOrder = s2QuantityToOrder + ((HiddenField)previousRow.FindControl("hdnQuantityToOrder")).Value;
                    s2QuantityToOrder = s2QuantityToOrder + ((HiddenField)previousRow.FindControl("hdnUnits")).Value;
                    s2QuantityToOrder = s2QuantityToOrder + ((HiddenField)previousRow.FindControl("hdnVAWastage")).Value;

                    s2ResSh = s2ResSh + ((HiddenField)previousRow.FindControl("hdnResSh")).Value;

                    s2VAName = s2VAName + ((Label)previousRow.FindControl("lblvaname")).Text;


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

                        if (s1StyleNumber.ToLower() == s2StyleNumber.ToLower())
                        {
                            row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
                            previousRow.Cells[7].Visible = false;


                        }
                        if (s1SerialNumber.ToLower() == s2SerialNumber.ToLower())
                        {
                            row.Cells[8].RowSpan = previousRow.Cells[8].RowSpan < 2 ? 2 : previousRow.Cells[8].RowSpan + 1;
                            previousRow.Cells[8].Visible = false;

                        }

                        if (s1QuantityToOrder.ToLower() == s2QuantityToOrder.ToLower())
                        {

                            row.Cells[9].RowSpan = previousRow.Cells[9].RowSpan < 2 ? 2 : previousRow.Cells[9].RowSpan + 1;
                            previousRow.Cells[9].Visible = false;

                        }
                        if (s1ResSh.ToLower() == s2ResSh.ToLower())
                        {

                            row.Cells[10].RowSpan = previousRow.Cells[10].RowSpan < 2 ? 2 : previousRow.Cells[10].RowSpan + 1;
                            previousRow.Cells[10].Visible = false;

                        }
                        if (s1VAName.ToLower() == s2VAName.ToLower())
                        {

                            row.Cells[11].RowSpan = previousRow.Cells[11].RowSpan < 2 ? 2 : previousRow.Cells[11].RowSpan + 1;
                            previousRow.Cells[11].Visible = false;

                        }
                    }
                }

            }
        }

        //        private void BindSupplierPo(GridView gridView, DataTable dtSupplierPo, string Type)
        //        {
        //            foreach (GridViewRow row in gridView.Rows)
        //            {
        //                string Filter = "";
        //                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
        //                HiddenField hdnfabricdetails = (HiddenField)row.FindControl("hdnfabricdetails");
        //                HiddenField hdnstyleid = (HiddenField)row.FindControl("hdnstyleid");
        //                HiddenField hdnSupplierMasterID = (HiddenField)row.FindControl("hdnSupplierMasterID");
        //                GridView grdsupplierpo = (GridView)row.FindControl("grdsupplierpo");

        //                Filter = " Fabric_QualityID=     '" + hdnfabricQuality.Value + "' and SupplierID=   '" + hdnSupplierMasterID.Value + "'   and PrintName= '" + hdnfabricdetails.Value + "'  ";
        //                if (Type == "E")
        //                {
        //                    HiddenField hdnSupplyTypeId = (HiddenField)row.FindControl("hdnSupplyTypeId");
        //                    HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
        //                    HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
        //                    HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
        //                    HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
        //                    HiddenField hdnPreviousStage = (HiddenField)row.FindControl("hdnPreviousStage");

        //                    Filter = Filter + @"    and PreviousStage='" + hdnPreviousStage.Value + @"' and SupplyTypeId='" + hdnSupplyTypeId.Value + @"'
        //                                            and Stage1='" + hdnstage1.Value + "' and Stage2='" + hdnstage2.Value + @"'
        //                                            and Stage3='" + hdnstage3.Value + "' and Stage4='" + hdnstage4.Value + "' ";
        //                }
        //                DataRow[] dv = dtSupplierPo.Select(Filter);
        //                if (dv.Count() > 0)
        //                {
        //                    grdsupplierpo.DataSource = dv.CopyToDataTable();
        //                    grdsupplierpo.DataBind();
        //                }
        //            }
        //        }


        protected void lnkOpenPopup_Click(object sender, EventArgs e)
        {
            string Filter = "";
            LinkButton lnkopenpopup = sender as LinkButton;
            GridViewRow gvr = lnkopenpopup.NamingContainer as GridViewRow;
            GridView grd = gvr.Parent.Parent as GridView;
            HiddenField hdnfabricQuality = gvr.FindControl("hdnfabricQuality") as HiddenField;
            HiddenField hdnfabricdetails = gvr.FindControl("hdnfabricdetails") as HiddenField;
            HiddenField hdnstyleid = (HiddenField)gvr.FindControl("hdnstyleid");
            HiddenField hdnSupplierMasterID = (HiddenField)gvr.FindControl("hdnSupplierMasterID");
            Filter = " Fabric_QualityID=     '" + hdnfabricQuality.Value + "'   and PrintName= '" + hdnfabricdetails.Value + "'  ";

            if (grd.ID == "grdEmbeEmbr")
            {
                HiddenField hdnSupplyTypeId = (HiddenField)gvr.FindControl("hdnSupplyTypeId");
                HiddenField hdnstage1 = (HiddenField)gvr.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)gvr.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)gvr.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)gvr.FindControl("hdnstage4");
                HiddenField hdnPreviousStage = (HiddenField)gvr.FindControl("hdnPreviousStage");

                Filter = Filter + @"    and PreviousStage='" + hdnPreviousStage.Value + @"' and SupplyTypeId='" + hdnSupplyTypeId.Value + @"'
                                                            and Stage1='" + hdnstage1.Value + "' and Stage2='" + hdnstage2.Value + @"'
                                                             and Stage3='" + hdnstage3.Value + "' and Stage4='" + hdnstage4.Value + "' ";

            }

            DataRow[] dr = Openpopupdata.Select(Filter);
            if (dr.Count() > 0)
            {

                grdsupplierpo.DataSource = dr.CopyToDataTable();
                grdsupplierpo.DataBind();

            }

            else
            {
                grdsupplierpo.DataSource = null;
                grdsupplierpo.DataBind();

            }

            divmModelPopupForStyleSpecific.Attributes["class"] = divmModelPopupForStyleSpecific.Attributes["class"].Replace("Popuphide", "Popupshow").Trim();




        }
        private void BindStyleSpecificTabs()
        {
            int userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            if (userid == 122) { userid = 0; }
            if (Fabtype.ToLower() == "DYEDStyle".ToLower() || Fabtype.ToLower() == "" || Fabtype == null)
            {
                DataSet dsDYEDStyle = fabobj.GetVaSupplierQoutationDayed("BASIC", userid, txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);
                if (dsDYEDStyle.Tables[0].Rows.Count > 0)
                {
                    grddayedstyle.DataSource = dsDYEDStyle.Tables[0];
                    grddayedstyle.DataBind();
                    BindSerialAndStyle(grddayedstyle, dsDYEDStyle, "D");
                    //BindSupplierPo(grddayedstyle, dsDYEDStyle.Tables[2], "D");
                    Openpopupdata = dsDYEDStyle.Tables[2];
                    //MergeRowsDayedPrint(grddayedstyle);
                }
                else
                {
                    grddayedstyle.DataSource = null;
                    grddayedstyle.DataBind();
                }
                grddayedstyle.Visible = true;
            }
            if (Fabtype.ToLower() == "PRINTStyle".ToLower())
            {
                DataSet dsPRINTStyle = fabobj.GetVaSupplierQoutationPrint("BASIC", userid, txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);
                if (dsPRINTStyle.Tables[0].Rows.Count > 0)
                {
                    grdprintstyle.DataSource = dsPRINTStyle.Tables[0];
                    grdprintstyle.DataBind();
                    BindSerialAndStyle(grdprintstyle, dsPRINTStyle, "P");
                    //BindSupplierPo(grdprintstyle, dsPRINTStyle.Tables[2], "P");
                    Openpopupdata = dsPRINTStyle.Tables[2];
                    //MergeRowsDayedPrint(grdprintstyle);
                }
                else
                {
                    grdprintstyle.DataSource = null;
                    grdprintstyle.DataBind();
                }
                grdprintstyle.Visible = true;
            }
            if (Fabtype.ToLower() == "EmbeEmbr".ToLower())
            {
                DataSet dsEmbeEmbr = fabobj.GetVaSupplierQoutationEmbellishment("BASIC", userid, txtsearchkeyswords.Text.Trim(), DdlSearchType.SelectedValue);
                if (dsEmbeEmbr.Tables[0].Rows.Count > 0)
                {
                    grdEmbeEmbr.DataSource = dsEmbeEmbr.Tables[0];
                    grdEmbeEmbr.DataBind();
                    BindSerialAndStyle(grdEmbeEmbr, dsEmbeEmbr, "E");
                    //BindSupplierPo(grdEmbeEmbr, dsEmbeEmbr.Tables[2], "E");
                    Openpopupdata = dsEmbeEmbr.Tables[2];

                    //MergeRowsEmbeEmbr(grdEmbeEmbr);
                }
                else
                {
                    grdEmbeEmbr.DataSource = null;
                    grdEmbeEmbr.DataBind();
                }
                grdEmbeEmbr.Visible = true;
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
                LnkDYEDStyle.Style.Add("Display", "none;");
                LnkPRINTStyle.Style.Add("Display", "none;");
                LnkEmbeEmbr.Style.Add("Display", "none;");
                int iCheckActiveTabClass = 0;
                foreach (DataRow dr in dtFabtype.Rows)
                {
                    if (dr["Name"].ToString().ToLower() == "Dyed".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkDYEDStyle.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkDYEDStyle.Attributes.Add("class", "activeback tab1Dayed");
                            grddayedstyle.Style.Remove("display");
                        }
                    }
                    if (dr["Name"].ToString().ToLower() == "Printed".ToLower() || dr["Name"].ToString().ToLower() == "Digital Printed".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkPRINTStyle.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkPRINTStyle.Attributes.Add("class", "activeback tab1Print");
                            grdprintstyle.Style.Remove("display");
                        }
                    }
                    if (dr["Name"].ToString().ToLower() == "Embellishment".ToLower() || dr["Name"].ToString().ToLower() == "Embroidery".ToLower())
                    {
                        iCheckActiveTabClass = iCheckActiveTabClass + 1;
                        LnkEmbeEmbr.Style.Remove("display");
                        if (iCheckActiveTabClass == 1)
                        {
                            LnkEmbeEmbr.Attributes.Add("class", "activeback tab1Embe");
                            grdEmbeEmbr.Style.Remove("display");
                        }
                    }
                }

                if (iCheckActiveTabClass == 0)
                {
                    LnkDYEDStyle.Attributes.Add("class", "activeback tab1Dayed");
                    grdprintstyle.Style.Remove("display");
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Fabtype = hdntabvalue.Value;
            BindStyleSpecificTabs();
            SetTab();
        }

        protected void grddayedstyle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    HiddenField hdnstage1 = e.Row.FindControl("hdnstage1") as HiddenField;
            //    HiddenField hdnstage2 = e.Row.FindControl("hdnstage2") as HiddenField;
            //    HiddenField hdnstage3 = e.Row.FindControl("hdnstage3") as HiddenField;
            //    Label lblcurrentStage = e.Row.FindControl("lblcurrentStage") as Label;
            //    Label lblPreviousStage = e.Row.FindControl("lblPreviousStage") as Label;


            //    HiddenField hdnstage4 = e.Row.FindControl("hdnstage4") as HiddenField;

            //    if (hdnstage2.Value == "2")
            //    {
            //        lblcurrentStage.Text = "2";
            //        lblPreviousStage.Text = hdnstage1.Value;
            //    }
            //    else if (hdnstage3.Value == "3")
            //    {
            //        lblcurrentStage.Text = "3";
            //        lblPreviousStage.Text = hdnstage2.Value;

            //    }
            //    else if (hdnstage4.Value == "2")
            //    {
            //        lblcurrentStage.Text = "4";
            //        lblPreviousStage.Text = hdnstage3.Value;

            //    }
            //    //HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
            //    //HiddenField hdnSupplierMasterID = (HiddenField)e.Row.FindControl("hdnSupplierMasterID");
            //    //Label lblBestQuotedRate = (Label)e.Row.FindControl("lblBestQuotedRate");
            //    //Label lblBestQuotedRatedays = (Label)e.Row.FindControl("lblBestQuotedRatedays");
            //    //if (hdnfabricQuality.Value != "" && hdnSupplierMasterID.Value != "")
            //    //{
            //    //    if (lblBestQuotedRate.Text != "")
            //    //    {
            //    //        lblBestQuotedRate.Text = "<span style='color: green; font-size: 11px'>₹</span>" + " " + lblBestQuotedRate.Text;
            //    //    }
            //    //    if (lblBestQuotedRatedays.Text != "")
            //    //    {
            //    //        lblBestQuotedRatedays.Text = " " + lblBestQuotedRatedays.Text + " <span style='color: gray;'> Days</span>";
            //    //    }
            //    //}
            //}
        }

        protected void grdprintstyle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    HiddenField hdnstage1 = e.Row.FindControl("hdnstage1") as HiddenField;
            //    HiddenField hdnstage2 = e.Row.FindControl("hdnstage2") as HiddenField;
            //    HiddenField hdnstage3 = e.Row.FindControl("hdnstage3") as HiddenField;
            //    Label lblcurrentStage = e.Row.FindControl("lblcurrentStage") as Label;
            //    Label lblPreviousStage = e.Row.FindControl("lblPreviousStage") as Label;


            //    HiddenField hdnstage4 = e.Row.FindControl("hdnstage4") as HiddenField;

            //    if (hdnstage2.Value == "3")
            //    {
            //        lblcurrentStage.Text = "2";
            //        lblPreviousStage.Text = hdnstage1.Value;
            //    }
            //    else if (hdnstage3.Value == "3")
            //    {
            //        lblcurrentStage.Text = "3";
            //        lblPreviousStage.Text = hdnstage2.Value;

            //    }
            //    else if (hdnstage4.Value == "3")
            //    {
            //        lblcurrentStage.Text = "4";
            //        lblPreviousStage.Text = hdnstage3.Value;

            //    }
            //    //HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
            //    //HiddenField hdnSupplierMasterID = (HiddenField)e.Row.FindControl("hdnSupplierMasterID");
            //    //Label lblBestQuotedRate = (Label)e.Row.FindControl("lblBestQuotedRate");
            //    //Label lblBestQuotedRatedays = (Label)e.Row.FindControl("lblBestQuotedRatedays");

            //    //if (hdnfabricQuality.Value != "" && hdnSupplierMasterID.Value != "")
            //    //{
            //    //    if (lblBestQuotedRate.Text != "")
            //    //    {
            //    //        lblBestQuotedRate.Text = "<span style='color: green; font-size: 11px'>₹</span>" + " " + lblBestQuotedRate.Text;
            //    //    }
            //    //    if (lblBestQuotedRatedays.Text != "")
            //    //    {
            //    //        lblBestQuotedRatedays.Text = " " + lblBestQuotedRatedays.Text + " <span style='color: gray;'> Days</span>";
            //    //    }
            //    //}
            //}
        }

        protected void grdEmbeEmbr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                //HiddenField hdnstage1 = e.Row.FindControl("hdnstage1") as HiddenField;
                //HiddenField hdnstage2 = e.Row.FindControl("hdnstage2") as HiddenField;
                //HiddenField hdnstage3 = e.Row.FindControl("hdnstage3") as HiddenField;
                //Label lblcurrentStage = e.Row.FindControl("lblcurrentStage") as Label;
                //Label lblPreviousStage = e.Row.FindControl("lblPreviousStage") as Label;
                //HiddenField hdnPreviousStage = e.Row.FindControl("hdnPreviousStage") as HiddenField;
                //HiddenField hdnCurrentStage = e.Row.FindControl("hdnCurrentStage") as HiddenField;


                //HiddenField hdnstage4 = e.Row.FindControl("hdnstage4") as HiddenField;

                //lblcurrentStage.Text = hdnCurrentStage.Value;
                //lblPreviousStage.Text = hdnPreviousStage.Value;

                //if (hdnstage2.Value == "30" || hdnstage2.Value == "31")
                //{
                //    lblcurrentStage.Text = "2";
                //    lblPreviousStage.Text = hdnstage1.Value;
                //}
                //else if (hdnstage3.Value == "30" || hdnstage3.Value == "31")
                //{
                //    lblcurrentStage.Text = "3";
                //    lblPreviousStage.Text = hdnstage2.Value;

                //}
                //else if (hdnstage4.Value == "30" || hdnstage4.Value == "31")
                //{
                //    lblcurrentStage.Text = "4";
                //    lblPreviousStage.Text = hdnstage3.Value;

                //}
                //HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                //HiddenField hdnSupplierMasterID = (HiddenField)e.Row.FindControl("hdnSupplierMasterID");
                //Label lblVAWastage = (Label)e.Row.FindControl("lblVAWastage");
                //if (iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 49)
                //    lblVAWastage.Visible = false;

                //Label lblBestQuotedRate = (Label)e.Row.FindControl("lblBestQuotedRate");
                //Label lblBestQuotedRatedays = (Label)e.Row.FindControl("lblBestQuotedRatedays");

                //if (hdnfabricQuality.Value != "" && hdnSupplierMasterID.Value != "")
                //{
                //    if (lblBestQuotedRate.Text != "")
                //    {
                //        lblBestQuotedRate.Text = "<span style='color: green; font-size: 11px'>₹</span>" + " " + lblBestQuotedRate.Text;
                //    }
                //    if (lblBestQuotedRatedays.Text != "")
                //    {
                //        lblBestQuotedRatedays.Text = " " + lblBestQuotedRatedays.Text + "<span style='color: gray;'> Days</span>";
                //    }
                //}
            }
        }

        protected void grdsupplierpo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnstatus = (HiddenField)e.Row.FindControl("hdnstatus");
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
    }
}


