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
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Drawing.Printing;


namespace iKandi.Web
{
    public partial class CriticalPathReports : BaseUserControl
    {
        int ClientID = 0;
        int DeptID = 0;
        #region Properties

        public int IsClient
        {
            get;
            set;

        }
        public int BuyingHouse
        {
            get;
            set;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ApplicationHelper.LoggedInUser.ClientData != null)
            {
                
                this.IsClient = 1;
                this.BuyingHouse = -1;
                tdFilter.Attributes.Add("style", "display:none");
            }
            else
            {
                this.IsClient = 0;
            }
            if (!IsPostBack)
            {
                lblPage.Text = "";
                DataTable Dt = this.PrintControllerInstance.GetAllBuyingHouseBAL();
                ddlBH.DataSource = Dt;
                ddlBH.DataTextField = "CompanyName";
                ddlBH.DataValueField = "ID";
                ddlBH.DataBind();
                DropdownHelper.FillDropDownClient(ddlClients, Convert.ToInt32(ddlBH.SelectedValue),true,0);
                Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);
            }
            if (this.IsClient == 1)
            {
                //tdDepartment.Visible = false;
                // tdClients.Visible = false;

                //tdDepartment.Style:Visible = "hidden";

                hdnIsClient.Value = "1";
                if (ApplicationHelper.LoggedInUser.ClientData.Client != null)
                    ClientID = ApplicationHelper.LoggedInUser.ClientData.Client.ClientID;
                DeptID = ApplicationHelper.LoggedInUser.ClientData.DeptID;
                hdnSupplyType.Value = "-1";
                hdnModeType.Value = "-1";
                hdnPackingType.Value = "-1";
                hdnTermType.Value = "-1";
                tdDepartment.Attributes.Add("style", "visibility:hidden");
                tdDepartment.Attributes.Add("style", "visibility:hidden");
            }
            else
            {
                hdnIsClient.Value = "0";
                ClientID = Convert.ToInt32(ddlClients.SelectedValue);
                DeptID = Convert.ToInt32(hiddenDeptId.Value);
                hdnSupplyType.Value = ddlSupplyType.SelectedValue;
                hdnModeType.Value = ddlModeType.SelectedValue;
                hdnPackingType.Value = ddlPackingType.SelectedValue;
                hdnTermType.Value = ddlTermType.SelectedValue;
                this.BuyingHouse = Convert.ToInt32(ddlBH.SelectedValue);
            }
            hdnClientId.Value = ClientID.ToString();
            hdnDeptId.Value = DeptID.ToString();
            if (!IsPostBack)
            {
                dvPaging.Visible = false;
                btnSearch_Click(this, new EventArgs());
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int UserId=0;
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager)
            {
                UserId = -1;
            }
            else
            {
                UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            }

            string searchText = txtsearch.Text;

            DataSet dsClientReport = null;
            string strsort = string.Empty;


            dsClientReport = this.ReportControllerInstance.CriticalPatchReport(searchText, ClientID, DeptID, Convert.ToInt32(hdnSupplyType.Value), Convert.ToInt32(hdnModeType.Value), Convert.ToInt32(hdnPackingType.Value), Convert.ToInt32(hdnTermType.Value), UserId,this.BuyingHouse);
            ViewState["tblPermission"] = dsClientReport.Tables[1];//Report Permissions                


            if (dsClientReport.Tables[0].Rows.Count == 0)
            {
                ViewState["Table1"] = dsClientReport.Tables[0];
                lblPage.Text = "Page 1 Of 1";
                hdnPage.Value = "1";
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'No Record Found ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                plcCriticalPath.Controls.Clear();

                lblPage.Text = "Page 1 Of 1";

                dvPaging.Visible = false;

                return;
            }
            else
            {
                dvPaging.Visible = true;
            }

            dsClientReport.Tables[0].DefaultView.Sort = ddlSort1.SelectedValue + "," + ddlSort2.SelectedValue + "," + ddlSort3.SelectedValue;

            DataView dv = new DataView();
            dv = dsClientReport.Tables[0].DefaultView;

            if (dsClientReport.Tables[0].Rows.Count > 0)
            {
                ViewState["Table1"] = dv.ToTable();                
            }
            if (dsClientReport.Tables[0].Rows.Count == 0 || (dsClientReport.Tables[1].Rows.Count == 0 && this.IsClient==1))   
            {                
                dvPaging.Visible = false;
                return;
            }           
            DataTable dtClientReport = ShowDataPageWise("F");

            ShowDataPageWise(dtClientReport);

        }





        private DataTable ShowDataPageWise(string IndexSet)
        {
            DataTable Dt = new DataTable();
            DataTable RetTable = new DataTable();

            int LoopStartValue = 0;
            int LoopEndValue = 0;
            decimal TotalPages;
            decimal TotalPagesMin;
            int TotalRows;
            Dt = (DataTable)ViewState["Table1"];
            RetTable = Dt.Clone();
            TotalRows = Dt.Rows.Count;
            TotalPages = Math.Ceiling(Convert.ToDecimal(Dt.Rows.Count) / 30);
            TotalPagesMin = Math.Floor(Convert.ToDecimal(Dt.Rows.Count) / 30);

            if (hdnPage.Value == "1" && IndexSet == "P")
            {
                IndexSet = "F";
            }
            if (Convert.ToInt16(hdnPage.Value) + 1 == Convert.ToInt16(TotalPages) && IndexSet=="N")
            {
                IndexSet = "L";
            }

            if (IndexSet == "N" && Convert.ToInt16(hdnPage.Value) == TotalPages)
            {
                IndexSet = "L";
            }

            if (IndexSet == "F")
            {
                LoopEndValue = 0;
                LoopEndValue = 30;
                hdnPage.Value = "1";
            }
            else if (IndexSet == "N")
            {
                LoopStartValue = Convert.ToInt16(hdnPage.Value) * 30;
                LoopEndValue = LoopStartValue + 30;
                hdnPage.Value = Convert.ToString(Convert.ToInt16(hdnPage.Value) + 1);
            }
            else if (IndexSet == "P")
            {
                if(Convert.ToInt16(hdnPage.Value)==2)
                    LoopStartValue = 0;
                else
                    LoopStartValue = (Convert.ToInt16(hdnPage.Value) - 1) * 30;

                LoopEndValue = LoopStartValue + 30;
                hdnPage.Value = Convert.ToString(Convert.ToInt16(hdnPage.Value) - 1);
            }
            else if (IndexSet == "L")
            {
                LoopStartValue = Convert.ToInt32(TotalPagesMin) * 30;
                LoopEndValue = TotalRows;
                hdnPage.Value = Convert.ToString(TotalPages);
            }
            else if (IndexSet == "C")
            {
                if (Convert.ToInt16(hdnPage.Value) == 1)
                {
                    LoopStartValue = 0;
                    LoopEndValue = 30;
                    hdnPage.Value = "1";
                }
                else
                {
                    LoopStartValue = (Convert.ToInt16(hdnPage.Value)) * 30;
                    LoopEndValue = LoopStartValue + 30;
                }
            }
            else if (IndexSet == "A")
            {
                LoopStartValue = 0;
                LoopEndValue = TotalRows;
            }

            if (LoopEndValue >= TotalRows)
                LoopEndValue = TotalRows;
            int row;
            for (row = LoopStartValue; row <= LoopEndValue - 1; row++)
            {
                RetTable.ImportRow(Dt.Rows[row]);
            }
            lblPage.Text = "Page " + Convert.ToString(hdnPage.Value) + " Of " + Convert.ToString(TotalPages);
            return RetTable;
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            ShowDataPageWise(ShowDataPageWise("N"));
        }

        protected void lnkLast_Click(object sender, EventArgs e)
        {
            ShowDataPageWise(ShowDataPageWise("L")); ;
        }

        protected void lnkPre_Click(object sender, EventArgs e)
        {
            ShowDataPageWise(ShowDataPageWise("P"));
        }

        protected void lnkFirst_Click(object sender, EventArgs e)
        {
            ShowDataPageWise(ShowDataPageWise("F"));
        }

        private void ShowDataPageWise(DataTable dtClientReport)
        {
            //DataTable dtPermissions = null;
            string fab1 = string.Empty;
            int result;
            //bool success;
            string myUrl;
            var ExcelImageUpload=Request.Url.OriginalString.ToString().Replace("//","#").Split('/');
            myUrl = ExcelImageUpload[0].Replace("#", "//");
            myUrl = myUrl + "/Uploads/Style";
            string ColumnClass = string.Empty;
            string ReportWidth = string.Empty;  
            if (rdoVertical.Checked == true)
            {
                ColumnClass = "vertical_header_1";
                ReportWidth = "120%";
            }
            else
            {
                
                ColumnClass = "critical_path_column";
                ReportWidth = (this.IsClient==1) ? "200%" : "270%";
            }

           
            //ExcelImageUpload=ExcelImageUpload.

            if (dtClientReport.Rows.Count > 0)
            {
                StringBuilder strbld = new StringBuilder();
                DataView dv = new DataView();
                string bulkapp = string.Empty;
       
                string str = string.Empty;
                strbld.Append("<table id='tbla' border=0  width="+ReportWidth+" align=centre cellpadding=0 cellspacing=1   bordercolor=#FFFFFF rules=cols class=bottom_item_list>");
                strbld.Append("<tr style='background-color:#23446F; color:white;width:'100%'>");
                if (this.IsClient == 1)
                {

                    if(IsFieldPermitted("FieldHeading","Basic Information"))
                        strbld.Append("<td class=top_round_corner colspan=" + GetRowSpan("FieldHeading", "Basic Information") + " align=center>Basic Information</td>");

                    if (IsFieldPermitted("FieldHeading", "FABRIC/TRIM STATUS"))
                        strbld.Append("<td class=top_round_corner colspan=" + GetRowSpan("FieldHeading", "FABRIC/TRIM STATUS") + " align=center>Fabric/Trim Status</td>");

                    if (IsFieldPermitted("FieldHeading", "Fit STATUS"))
                        strbld.Append("<td class=top_round_corner align=center style=width:70px>Fit Status</td>");

                    if (IsFieldPermitted("FieldHeading", "Pre Production"))
                        strbld.Append("<td class=top_round_corner colspan=" + GetRowSpan("FieldHeading", "Pre Production") + "  style='background-color:#23446F; color:white;' align=center>Pre Production </td>");

                    if (IsFieldPermitted("FieldHeading", "Production Planning & Actual Status"))
                        strbld.Append("<td class=top_round_corner colspan=" + GetRowSpan("FieldHeading", "Production Planning & Actual Status") + " style='background-color:#23446F; color:white;' align=center>Production Planning &amp; Actual Status </td>");

                    if (IsFieldPermitted("FieldHeading", "Inspection Status"))
                    {
                        int cs = GetRowSpan("FieldHeading", "Inspection Status");
                        strbld.Append("<td class=top_round_corner align=center colspan=" + cs + ">Inspection Status</td>");
                    }

                    strbld.Append("</tr>");
                    strbld.Append("<tr class=bottom_item_list_td  style='background-color:#FCD9EF;'>");

                    if (IsFieldPermitted("FieldId", "1"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Order Date </td>");

                    if (IsFieldPermitted("FieldId", "2"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Serial No. </td>");

                    if (IsFieldPermitted("FieldId", "3"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Client</td>");

                    if (IsFieldPermitted("FieldId", "4"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Department</td>");

                    if (IsFieldPermitted("FieldId", "5"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Style no. </td>");

                    if (IsFieldPermitted("FieldId", "6"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Line no. </td>");

                    if (IsFieldPermitted("FieldId", "7"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Contract no.</td>");

                    if (IsFieldPermitted("FieldId", "8"))
                    strbld.Append("<td width=200 rowspan=2>Description </td>");

                    if (IsFieldPermitted("FieldId", "9"))
                    strbld.Append("<td width=40 rowspan=2>Qty</td>");

                    if (IsFieldPermitted("FieldId", "10"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Mode</td>");

                    if (IsFieldPermitted("FieldId", "11"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pack Type </td>");

                    if (IsFieldPermitted("FieldId", "12"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>DC Date </td>");

                    if (IsFieldPermitted("FieldId", "28"))
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Order Status </td>");

                    if (IsFieldPermitted("FieldId", "31"))
                        strbld.Append("<td class='" + ColumnClass + "' rowspan=2>QA Status </td>");

                    if (IsFieldPermitted("FieldId", "13"))
                    strbld.Append("<td width='400' rowspan=2>Fabric</td>");

                    if (IsFieldPermitted("FieldId", "14"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Accessories</td>");

                    if (IsFieldPermitted("FieldId", "15"))
                    strbld.Append("<td width='600' rowspan=2>Fit Status</td>");

                    if (IsFieldPermitted("FieldId", "16") || IsFieldPermitted("FieldId", "17") || IsFieldPermitted("FieldId", "29"))
                        strbld.Append("<td height=20 colspan=" + GetRowSpan("FieldSubHeading", "PPM") + ">PPM</td>");

                    if (IsFieldPermitted("FieldId", "18") || IsFieldPermitted("FieldId", "19"))
                        strbld.Append("<td colspan=" + GetRowSpan("FieldSubHeading", "PCD") + ">PCD</td>");

                    if (IsFieldPermitted("FieldId", "20") || IsFieldPermitted("FieldId", "21") || IsFieldPermitted("FieldId", "22"))
                        strbld.Append("<td colspan=" + GetRowSpan("FieldSubHeading", "Target Date") + " width=350 align=center>Target Start Date - Target End Date</td>");

                    if (IsFieldPermitted("FieldId", "23"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pcs Cut</td>");

                    if (IsFieldPermitted("FieldId", "24"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pcs Stiched</td>");

                    if (IsFieldPermitted("FieldId", "25"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pcs Packed </td>");

                    if (IsFieldPermitted("FieldId", "26"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Inline</td>");

                    if (IsFieldPermitted("FieldId", "30"))
                        strbld.Append("<td class='" + ColumnClass + "' rowspan=2>Offer</td>");

                    if (IsFieldPermitted("FieldId", "27"))
                    strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Final</td>");


                    strbld.Append("</tr>");

                    strbld.Append("<tr class='bottom_item_list_td' style='background-color:#FCD9EF;'>");

                    if (IsFieldPermitted("FieldId", "16"))
                    strbld.Append("<td class='"+ColumnClass+"' height=20>Target</td>");


                    if (IsFieldPermitted("FieldId", "29"))
                        strbld.Append("<td class='" + ColumnClass + "' >Planned</td>");


                    if (IsFieldPermitted("FieldId", "17"))
                    strbld.Append("<td class='"+ColumnClass+"' >Actual</td>");

                    if (IsFieldPermitted("FieldId", "18"))
                    strbld.Append("<td class='"+ColumnClass+"' >Target</td>");

                    if (IsFieldPermitted("FieldId", "19"))
                    strbld.Append("<td class='"+ColumnClass+"' >Actual</td>");

                    if (IsFieldPermitted("FieldId", "20"))
                    strbld.Append("<td class='"+ColumnClass+"' >Cutting</td>");

                    if (IsFieldPermitted("FieldId", "21"))
                    strbld.Append("<td class='"+ColumnClass+"' >Sewing</td>");

                    if (IsFieldPermitted("FieldId", "22"))
                    strbld.Append("<td class='"+ColumnClass+"' >Finsh/ Pack</td>");

                    strbld.Append("</tr>");

                }
                else
                {
                        strbld.Append("<td class=top_round_corner colspan=14 align=center style='width:40%'>Basic Information</td>");
                        strbld.Append("<td class=top_round_corner colspan=2 align=center style='width:5%'>Fabric/Trim Status</td>");
                        strbld.Append("<td class=top_round_corner align=center style='width:8%'>Fit Status</td>");
                        strbld.Append("<td class=top_round_corner colspan=5  style='background-color:#23446F; color:white;width:17%' align=center>Pre Production </td>");
                        strbld.Append("<td class=top_round_corner colspan=6 style='background-color:#23446F; color:white;width:20%' align=center>Production Planning &amp; Actual Status </td>");
                        strbld.Append("<td class=top_round_corner align=center colspan=3 style='width:10%'>Inspection Status</td>");


                        strbld.Append("</tr>");
                        strbld.Append("<tr class=bottom_item_list_td  style='background-color:#FCD9EF;'>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Order Date </td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Serial No. </td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Client</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Department</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Style no. </td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Line no. </td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Contract no.</td>");
                        strbld.Append("<td width=200 rowspan=2>Description </td>");
                        strbld.Append("<td width=40 rowspan=2>Qty</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Mode</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pack Type </td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>DC Date </td>");
                        strbld.Append("<td class='" + ColumnClass + "' rowspan=2>Order Status </td>");
                        strbld.Append("<td class='" + ColumnClass + "' rowspan=2>QA Status </td>");
                        strbld.Append("<td width='400' rowspan=2>Fabric</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Accessories</td>");
                        strbld.Append("<td width='600' rowspan=2>Fit Status</td>");
                        strbld.Append("<td height=20 colspan=3>PPM</td>");
                        strbld.Append("<td colspan=2>PCD</td>");
                        strbld.Append("<td colspan=3 width=350 align=center>Target Start Date - Target End Date</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pcs Cut</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pcs Stiched</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Pcs Packed </td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Inline</td>");
                        strbld.Append("<td class='" + ColumnClass + "' rowspan=2>Offer</td>");
                        strbld.Append("<td class='"+ColumnClass+"' rowspan=2>Final</td>");
                        strbld.Append("</tr>");
                        strbld.Append("<tr class='bottom_item_list_td' style='background-color:#FCD9EF;'>");
                        strbld.Append("<td class='"+ColumnClass+"' height=20>Target</td>");
                        strbld.Append("<td class='" + ColumnClass + "' height=20>Planned</td>");
                        strbld.Append("<td class='"+ColumnClass+"' >Actual</td>");
                        strbld.Append("<td class='"+ColumnClass+"' >Target</td>");
                        strbld.Append("<td class='"+ColumnClass+"' >Actual</td>");
                        strbld.Append("<td class='"+ColumnClass+"' >Cutting</td>");
                        strbld.Append("<td class='"+ColumnClass+"' >Sewing</td>");
                        strbld.Append("<td class='"+ColumnClass+"' >Finish/ Pack</td>");
                        strbld.Append("</tr>");

                }
                //strbld.Append("<td colspan=2 width=300><table width=100% border='0' cellspacing=0 cellpadding=0>");
                //strbld.Append("<tr style='background-color:#23446F; color:white;'><td class='top_round_corner' width='98%' height='30' style='border-right:none;' align=center colspan=2>Inspection Status </td>");
                //strbld.Append("<td width='2%' align='right'></td>");
                //strbld.Append("</tr></table></td>");

               




                for (int i = 0; i <= dtClientReport.Rows.Count - 1; i++)
                {



                    var Fab1Det = Convert.ToString(dtClientReport.Rows[i]["Fabric1Details"]).Trim().Split(' ');

                    if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dtClientReport.Rows[i]["Fabric1Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric1Details"]) != "")
                    {
                        dtClientReport.Rows[i]["Fabric1Details"] = "PRD:" + Convert.ToString(dtClientReport.Rows[i]["Fabric1Details"]);
                        //success = false;
                        result = 0;
                    }
                    if (dtClientReport.Rows[i]["Fabric1Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric1Details"]) != "")
                        dtClientReport.Rows[i]["Fabric1"] = Convert.ToString(dtClientReport.Rows[i]["Fabric1"]) + " " + Convert.ToString(dtClientReport.Rows[i]["Fabric1Details"]);

                    var Fab2Det = Convert.ToString(dtClientReport.Rows[i]["Fabric2Details"]).Trim().Split(' ');


                    if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dtClientReport.Rows[i]["Fabric2Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric2Details"]) != "")
                    {
                        dtClientReport.Rows[i]["Fabric2Details"] = "PRD:" + Convert.ToString(dtClientReport.Rows[i]["Fabric2Details"]);
                        //success = false;
                        result = 0;
                    }

                    if (dtClientReport.Rows[i]["Fabric2Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric2Details"]) != "")
                        dtClientReport.Rows[i]["Fabric2"] = Convert.ToString(dtClientReport.Rows[i]["Fabric2"]) + " " + Convert.ToString(dtClientReport.Rows[i]["Fabric2Details"]);


                    var Fab3Det = Convert.ToString(dtClientReport.Rows[i]["Fabric3Details"]).Trim().Split(' ');

                    if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dtClientReport.Rows[i]["Fabric3Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric3Details"]) != "")
                    {
                        dtClientReport.Rows[i]["Fabric3Details"] = "PRD:" + Convert.ToString(dtClientReport.Rows[i]["Fabric3Details"]);
                        //success = false;
                        result = 0;
                    }

                    if (dtClientReport.Rows[i]["Fabric3Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric3Details"]) != "")
                        dtClientReport.Rows[i]["Fabric3"] = Convert.ToString(dtClientReport.Rows[i]["Fabric3"]) + " " + Convert.ToString(dtClientReport.Rows[i]["Fabric3Details"]);



                    var Fab4Det = Convert.ToString(dtClientReport.Rows[i]["Fabric4Details"]).Trim().Split(' ');

                    if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)) && dtClientReport.Rows[i]["Fabric4Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric4Details"]) != "")
                    {
                        dtClientReport.Rows[i]["Fabric4Details"] = "PRD:" + Convert.ToString(dtClientReport.Rows[i]["Fabric4Details"]);
                        //success = false;
                        result = 0;
                    }
                    if (dtClientReport.Rows[i]["Fabric4Details"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric4Details"]) != "")
                        dtClientReport.Rows[i]["Fabric4"] = Convert.ToString(dtClientReport.Rows[i]["Fabric4"]) + " " + Convert.ToString(dtClientReport.Rows[i]["Fabric4Details"]);



                    if (dtClientReport.Rows[i]["Fabric1"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric1"]) != "")
                    {
                        fab1 = "<nobr>" + dtClientReport.Rows[i]["Fabric1"] + " " + "(<span class='bulkappr'>" + dtClientReport.Rows[i]["Fabric1InHouse"] + "</span>)</nobr>";
                        if (dtClientReport.Rows[i]["Fabric1Approval"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric1Approval"]) != "")
                        {
                            fab1 = fab1 + "<BR>" + dtClientReport.Rows[i]["Fabric1Approval"];
                        }
                    }

                    if (dtClientReport.Rows[i]["Fabric2"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric2"]) != "")
                    {
                        fab1 = fab1 + "<BR><nobr>" + dtClientReport.Rows[i]["Fabric2"] + " " + "(<span class='bulkappr'>" + dtClientReport.Rows[i]["Fabric2InHouse"] + "</span>)</nobr>";
                        if (dtClientReport.Rows[i]["Fabric2Approval"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric2Approval"]) != "")
                        {
                            fab1 = fab1 + "<BR>" + dtClientReport.Rows[i]["Fabric2Approval"];
                        }
                    }

                    if (dtClientReport.Rows[i]["Fabric3"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric3"]) != "")
                    {
                        fab1 = fab1 + "<BR><nobr>" + dtClientReport.Rows[i]["Fabric3"] + " " + "(<span class='bulkappr'>" + dtClientReport.Rows[i]["Fabric3InHouse"] + "</span>)</nobr>";
                        if (dtClientReport.Rows[i]["Fabric3Approval"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric3Approval"]) != "")
                        {
                            fab1 = fab1 + "<BR>" + dtClientReport.Rows[i]["Fabric3Approval"];
                        }
                    }

                    if (dtClientReport.Rows[i]["Fabric4"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric4"]) != "")
                    {
                        fab1 = fab1 + "<BR><nobr>" + dtClientReport.Rows[i]["Fabric4"] + " " + "(<span class='bulkappr'>" + dtClientReport.Rows[i]["Fabric4InHouse"] + "</span>)</nobr>";
                        if (dtClientReport.Rows[i]["Fabric4Approval"] != null && Convert.ToString(dtClientReport.Rows[i]["Fabric4Approval"]) != "")
                        {
                            fab1 = fab1 + "<BR>" + dtClientReport.Rows[i]["Fabric4Approval"];
                        }
                    }


                    if (this.IsClient == 1)
                    {
                        
                        strbld.Append("<tr class=table-content-text style='background-color:#f7f7f7;'>");

                        if (IsFieldPermitted("FieldId", "1"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' style=width: auto; >" + dtClientReport.Rows[i]["OrderDate"] + "</td>");

                        if (IsFieldPermitted("FieldId", "2"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' style=width: auto; >" + dtClientReport.Rows[i]["SerialNumber"] + "</td>");

                        if (IsFieldPermitted("FieldId", "3"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Buyer"] + "</td>");

                        if (IsFieldPermitted("FieldId", "4"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["DepartmentName"] + "</td>");

                        if (IsFieldPermitted("FieldId", "5"))
                        {
                            strbld.Append("<td class='classTD' >" + dtClientReport.Rows[i]["StyleNumber"] + "<BR/>");
                            strbld.Append("<img style='height: 55px ! important;' border=0px src='" + ResolveUrl(myUrl + "/thumb-" + dtClientReport.Rows[i]["SampleImageURL1"].ToString()) + "'/></td>");
                        }

                        if (IsFieldPermitted("FieldId", "6"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["LineItemNumber"] + "</td>");

                        if (IsFieldPermitted("FieldId", "7"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["ContractNumber"] + "</td>");

                        if (IsFieldPermitted("FieldId", "8"))
                        strbld.Append("<td class='classTD' >" + dtClientReport.Rows[i]["OrderDescription"] + "</td>");

                        if (IsFieldPermitted("FieldId", "9"))
                        strbld.Append("<td class='classTD' >" + dtClientReport.Rows[i]["Quantity"] + "</td>");

                        if (IsFieldPermitted("FieldId", "10"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Code"] + "</td>");

                        if (IsFieldPermitted("FieldId", "11"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' > " + dtClientReport.Rows[i]["PackType"] + " </td>");

                        if (IsFieldPermitted("FieldId", "12"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["DCDate"] + "</td>");

                        if (IsFieldPermitted("FieldId", "28"))
                            strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Order_Status"] + "</td>");

                        if (IsFieldPermitted("FieldId", "31"))
                            strbld.Append("<td class='classTD " + ColumnClass + "' >" + dtClientReport.Rows[i]["LastStatus"] + "</td>");

                        if (IsFieldPermitted("FieldId", "13"))
                        strbld.Append("<td class='classTD'>" + fab1 + "</td>");

                        if (IsFieldPermitted("FieldId", "14"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["AccessoryApproval"] + "</td>");

                        if (IsFieldPermitted("FieldId", "15"))
                        strbld.Append("<td class='classTD' ><nobr>" + Convert.ToString(dtClientReport.Rows[i]["FITPopStatus"]).Replace(",", "</nobr><BR><nobr>") + "</nobr></td>");

                        if (IsFieldPermitted("FieldId", "16"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PPM_Planned"] + "</td>");

                        if (IsFieldPermitted("FieldId", "29"))
                            strbld.Append("<td class='classTD " + ColumnClass + "' >" + dtClientReport.Rows[i]["BHPlannedMeeting"] + "</td>");

                        if (IsFieldPermitted("FieldId", "17"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PPM_Actual"] + "</td>");

                        if (IsFieldPermitted("FieldId", "18"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PCDPlanned"] + "</td>");

                        if (IsFieldPermitted("FieldId", "19"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PCDActual"] + "</td>");

                        if (IsFieldPermitted("FieldId", "20"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Cutting"] + "</td>");

                        if (IsFieldPermitted("FieldId", "21"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Sewing"] + "</td>");

                        if (IsFieldPermitted("FieldId", "22"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Finish_Pack"] + "</td>");

                        if (IsFieldPermitted("FieldId", "23"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PcsCut"] + "</td>");

                        if (IsFieldPermitted("FieldId", "24"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PcsStitched"] + "</td>");

                        if (IsFieldPermitted("FieldId", "25"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PcsPacked"] + "</td>");

                        if (IsFieldPermitted("FieldId", "26"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Inline_Inspection"] + "</td>");

                        if (IsFieldPermitted("FieldId", "30"))
                            strbld.Append("<td class='classTD " + ColumnClass + "' >" + dtClientReport.Rows[i]["ShipmentDate"] + "</td>");

                        if (IsFieldPermitted("FieldId", "27"))
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Final_Inspection"] + "</td>");
                                                
                        strbld.Append("</tr>");
                        strbld.Append("<tr class=table-content-text>");
                        bulkapp = "";

                        strbld.Append("</tr>");

                    }
                    else
                    {
                        strbld.Append("<tr class=table-content-text style='background-color:#f7f7f7;'>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' style=width: auto; >" + dtClientReport.Rows[i]["OrderDate"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' style=width: auto; >" + dtClientReport.Rows[i]["SerialNumber"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Buyer"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["DepartmentName"] + "</td>");
                        strbld.Append("<td class='classTD' ><nobr>" + dtClientReport.Rows[i]["StyleNumber"] + "</nobr><BR/>");
                        strbld.Append("<img style='height: 55px ! important;' border=0px src='" + ResolveUrl(myUrl + "/thumb-" + dtClientReport.Rows[i]["SampleImageURL1"].ToString()) + "'/></td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["LineItemNumber"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["ContractNumber"] + "</td>");
                        strbld.Append("<td class='classTD' >" + dtClientReport.Rows[i]["OrderDescription"] + "</td>");
                        strbld.Append("<td class='classTD' >" + dtClientReport.Rows[i]["Quantity"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Code"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' > " + dtClientReport.Rows[i]["PackType"] + " </td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["DCDate"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Order_Status"] + "</td>");
                        strbld.Append("<td class='classTD " + ColumnClass + "' >" + dtClientReport.Rows[i]["LastStatus"] + "</td>");
                        strbld.Append("<td class='classTD'>" + fab1 + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["AccessoryApproval"] + "</td>");
                        strbld.Append("<td class='classTD' ><nobr>" + Convert.ToString(dtClientReport.Rows[i]["FITPopStatus"]).Replace(",", "</nobr><BR><nobr>") + "</nobr></td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PPM_Planned"] + "</td>");
                        strbld.Append("<td class='classTD " + ColumnClass + "' >" + dtClientReport.Rows[i]["BHPlannedMeeting"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PPM_Actual"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PCDPlanned"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PCDActual"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Cutting"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Sewing"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Finish_Pack"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PcsCut"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PcsStitched"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["PcsPacked"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Inline_Inspection"] + "</td>");
                        strbld.Append("<td class='classTD " + ColumnClass + "' >" + dtClientReport.Rows[i]["ShipmentDate"] + "</td>");
                        strbld.Append("<td class='classTD "+ColumnClass+"' >" + dtClientReport.Rows[i]["Final_Inspection"] + "</td>");

                        
                        strbld.Append("</tr>");
                        strbld.Append("<tr class=table-content-text>");
                        bulkapp = "";

                        strbld.Append("</tr>");
                    }
                }
                strbld.Append("</table></td></tr></table>");
                Literal lit = default(Literal);
                lit = new Literal();
                lit.Text = strbld.ToString();
                plcCriticalPath.Controls.Clear();
                plcCriticalPath.Controls.Add(lit);
                dvPaging.Visible = true;
            }


        }

        private bool IsFieldPermitted(string FieldName,string Value)
        {
           DataTable dtPermissions = (DataTable)ViewState["tblPermission"];
           dtPermissions.DefaultView.RowFilter = FieldName + "='" + Value + "'";
           DataView dv = dtPermissions.DefaultView;
           if (dv.Count > 0)
               return true;
           else
               return false;
        }

        private int GetRowSpan(string FieldName, string Value)
        {
            DataTable dtPermissions = (DataTable)ViewState["tblPermission"];
            dtPermissions.DefaultView.RowFilter = FieldName + "='" + Value + "'";
            DataView dv = dtPermissions.DefaultView;
            return dv.Count;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowDataPageWise(ShowDataPageWise("A"));

            string attachment = "attachment; filename=CriticalPathReport.xls";

            Response.ClearContent();

            Response.AddHeader("content-disposition", attachment);

            Response.ContentType = "application/ms-excel";

            System.IO.StringWriter stw = new System.IO.StringWriter();

            HtmlTextWriter htextw = new HtmlTextWriter(stw);

            plcCriticalPath.RenderControl(htextw);
            ShowDataPageWise(ShowDataPageWise("C"));
            Response.Write(stw.ToString());
            Response.End();
        }

        protected void btnExport0_Click(object sender, EventArgs e)
        {
            string myUrl=string.Empty;
             var ExcelImageUpload=Request.Url.OriginalString.ToString().Replace("//","#").Split('/');
            myUrl = ExcelImageUpload[0].Replace("#", "//");
            myUrl = myUrl + "/Uploads/Style";
            DataTable Dt = (DataTable)ViewState["Table1"];
            DataTable dtPermissions = (DataTable)ViewState["tblPermission"];
            if (Dt.Rows.Count <= 0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'NO RECORD FOUND');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                return;
            }

            if (this.IsClient == 1 && dtPermissions.Rows.Count <= 0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'NO PERMISSION DEFINED.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                return;
            }
           
                string PDFfile = this.PDFControllerInstance.GeneratePDFCriticalPath(Dt, myUrl, dtPermissions, this.IsClient);
                this.RenderFile(PDFfile, "Critical Path Report.PDF", Constants.CONTENT_TYPE_PDF);
                  
        }

        protected void ddlBH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropdownHelper.FillDropDownClient(ddlClients, Convert.ToInt32(ddlBH.SelectedValue),true,0);
            dvPaging.Visible = false;
        }

        protected void rdoVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["Table1"] == DBNull.Value || ViewState["Table1"] == null)
                return;
            ShowDataPageWise(ShowDataPageWise("C"));
        }

        protected void rdoHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["Table1"] == DBNull.Value || ViewState["Table1"] == null)
                return;
            ShowDataPageWise(ShowDataPageWise("C"));
        }

    }

}