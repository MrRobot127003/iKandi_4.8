using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Drawing;
using System.Web.Services;



namespace iKandi.Web.Internal.Fabric
{
    public partial class FrmWorkingOnRaisedPO : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();
        public string challannumber;

        public static int orderid { get; set; }
        public static int OrderDetailID { get; set; }
        public int SupplierPO { get; set; }
        public string CreditNote { get; set; }
        public string postatus { get; set; }
        string host = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!Page.IsPostBack)
            {
                GetQueryString();
                HttpContext.Current.Session["SupplierPO_Id"] = null;
                HttpContext.Current.Session["imgurlsset"] = null;
                if (!string.IsNullOrEmpty(postatus))
                    ddlstatus.SelectedValue = postatus;
                if (Request.QueryString["PONumber"] != null)
                {
                    txtsearchkeyswords.Text = Request.QueryString["PONumber"];
                    ddlSearchOption.SelectedValue = "4";
                }
                //bindgrd(0);
                Session["dts"] = null;

                bindgrd(0);
            }
            
        }

        public void GetQueryString()
        {
            if (Request.QueryString["orderid"] != null)
                orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            else
                orderid = -1;

            if (Request.QueryString["OrderDetailID"] != null)
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
            else
                OrderDetailID = -1;

            if (Request.QueryString["SupplierPO"] != null)
                SupplierPO = Convert.ToInt32(Request.QueryString["SupplierPO"]);
            else
                SupplierPO = 0;

            if (Request.QueryString["CreditNote"] != null)
                CreditNote = Request.QueryString["CreditNote"].ToString();
            else
                CreditNote = "";

            if (Request.QueryString["postatus"] != null)
                postatus = Request.QueryString["postatus"].ToString();
            else
                postatus = "";

        }
        public void bindgrd(int FromSearch)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", Fabtype(""), Convert.ToInt32(SupplierPO)).Tables[0];
            if (!string.IsNullOrEmpty(SupplierPO.ToString()))
            {
                if (dtstatus.Rows.Count > 0)
                {
                    ddlstatus.Attributes.Add("disabled", "disabled");
                    btnSearch.Attributes.Add("disabled", "disabled");
                    txtsearchkeyswords.Attributes.Add("disabled", "disabled");
                    ddlstatus.SelectedValue = dtstatus.Rows[0]["postatus"].ToString();

                }
            }
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Store_Accountant || ApplicationHelper.LoggedInUser.UserData.PrimaryGroup.ToString() == iKandi.Common.Group.BIPL_QA.ToString())
            {
                lnkPendingOrderSuppary.Style.Add("display", "none");
                lnkSupplierQuotation.Style.Add("display", "none");
                lnkRaisePo.Style.Add("display", "none");
                // ddlstatus.Attributes.Add("disabled", "disabled");

                string SearchVal = txtsearchkeyswords.Text.Trim();
                //if ((SearchVal == "") && (FromSearch == 1))
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Please Enter PO Number');", true);
                //}
                //else if ((SearchVal != "") && (FromSearch == 1))               
                // {
                ds = fabobj.GetRaisedPOWorkingDetails("GET", "", SupplierPO, txtsearchkeyswords.Text.Trim(), Convert.ToInt32(ddlstatus.SelectedValue), OrderDetailID, Convert.ToInt32(ddlSearchOption.SelectedValue));
                dt = ds.Tables[0];

                grdraisedpoworking.DataSource = dt;
                grdraisedpoworking.DataBind();
                MergeRows(grdraisedpoworking);
                Session["dts"] = dt;

                //  }
            }
            else
            {
                ds = fabobj.GetRaisedPOWorkingDetails("GET", "", SupplierPO, txtsearchkeyswords.Text.Trim(), Convert.ToInt32(ddlstatus.SelectedValue), OrderDetailID, Convert.ToInt32(ddlSearchOption.SelectedValue));
                dt = ds.Tables[0];

                grdraisedpoworking.DataSource = dt;
                grdraisedpoworking.DataBind();
                MergeRows(grdraisedpoworking);
                Session["dts"] = dt;
            }
        }

      

        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                Label lblfab = (Label)row.Cells[0].FindControl("lblfab");
                Label lblPreviouslblfab = (Label)previousRow.Cells[0].FindControl("lblfab");

                if (lblfab.Text.ToLower() == lblPreviouslblfab.Text.ToLower())
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                           previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;
                    //gridView.Rows[0].Cells[0].CssClass = row.Cells[0].Text;
                    //gridView.Rows[0].Cells[1].CssClass = row.Cells[0].Text;
                    //gridView.Rows[0].Cells[0].Attributes.Add("onclick", "callme(" + row.Cells[0].Text + ")");
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public static void StoreSessionValue(string theValue, string imgurl)
        {
            HttpContext.Current.Session["SupplierPO_Id"] = theValue;
            //if (HttpContext.Current.Session["imgurlsset"] == null)
            //{
            HttpContext.Current.Session["imgurlsset"] = imgurl;
            //}
        }
        public string GetUnitName(string po)
        {
            DataTable dt = fabobj.GetUnitName();

            //DataView dv = new DataView(dt);
            //dv.RowFilter = "(PO_Number == " + po + ")";
            DataRow[] dv = dt.Select("PO_Number = '" + po + "'");

            return dv[0]["UnitsNames"].ToString();
        }

        protected void grdraisedpoworking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string srvid = "";
            int IsSrvMultiple = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                challannumber = "";
                HiddenField hdnSupplierPO_Id = (HiddenField)e.Row.FindControl("hdnSupplierPO_Id");
                LinkButton lnkplus = (LinkButton)e.Row.FindControl("lnkplus");
                Label lblTotalpoQty = (Label)e.Row.FindControl("lblTotalpoQty");
                Label lbltotalqtyreceived = (Label)e.Row.FindControl("lbltotalqtyreceived");
                Label lblbalanceQty = (Label)e.Row.FindControl("lblbalanceQty");
                Label lblfabrictype = (Label)e.Row.FindControl("lblfabrictype");
                Label lblsendQty = (Label)e.Row.FindControl("lblsendQty");
                Label lblponumber = (Label)e.Row.FindControl("lblponumber");
                Label lblunits = (Label)e.Row.FindControl("lblunits");
                HtmlAnchor anopensrv = (HtmlAnchor)e.Row.FindControl("anopensrv");
                // ImageButton imgbtnsendchallan = (ImageButton)e.Row.FindControl("imgbtnsendchallan");
                HtmlAnchor imgbtnsendchallan = (HtmlAnchor)e.Row.FindControl("imgbtnsendchallan");
                Label lblfab = (Label)e.Row.FindControl("lblfab");
                HiddenField hdnIsAuthorizedSignatory = (HiddenField)e.Row.FindControl("hdnIsAuthorizedSignatory");
                HiddenField hdnIsPartySignature = (HiddenField)e.Row.FindControl("hdnIsPartySignature");
                HiddenField hdncurrentstage = (HiddenField)e.Row.FindControl("hdncurrentstage");
                HiddenField hdnchallanmeter = (HiddenField)e.Row.FindControl("hdnchallanmeter");
                HiddenField hdnConvertToUnit = (HiddenField)e.Row.FindControl("hdnConvertToUnit");
                HiddenField hdndefualtunit = (HiddenField)e.Row.FindControl("hdndefualtunit");
                HiddenField hdnconversionvalue = (HiddenField)e.Row.FindControl("hdnconversionvalue");
                HiddenField hdnActualSendQty = (HiddenField)e.Row.FindControl("hdnActualSendQty");
                GridView grdpo = (GridView)e.Row.FindControl("grdpo");
                HyperLink hplk = (HyperLink)e.Row.FindControl("hplk");
                DataTable dtpo = fabobj.GetRaisedPOWorkingDetails("PODETAILS", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0];
                if (dtpo.Rows.Count > 0)
                {
                    grdpo.DataSource = dtpo;
                    grdpo.DataBind();
                }
                else
                {
                    hplk.Visible = false;
                }
                if (hdndefualtunit.Value != hdnConvertToUnit.Value)
                {
                    lblunits.Attributes.Add("style", "background-color: yellow;");
                    //lblunits.ToolTip = "This po moved to diffrent" + " (" + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefualtunit.Value)) + " to " + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnConvertToUnit.Value)) + ")" + " unit conversion value : " + hdnconversionvalue.Value;
                    lblunits.ToolTip = "This PO moved to different" + " (" + "<span style='color:yellow'><strong>" + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefualtunit.Value)) + "</strong></span>" + " to " + "<span style='color:yellow'><strong>" + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnConvertToUnit.Value)) + "</strong></span>" + ")" + " unit conversion value : " + "<span style='color:yellow'><strong>" + hdnconversionvalue.Value + "</strong></span>";
                    //lblunits.Attributes.Add("class", "tooltip;");

                    //e.Row.Cells[2].Attributes.Add("style", "background-color: yellow;");
                    //e.Row.Cells[2].ToolTip = "This po moved to diffrent" + "{" +  Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdndefualtunit.Value))  + " to " +  Enum.GetName(typeof(FabricUnit), Convert.ToInt32(hdnConvertToUnit.Value)) + "}" + " unit conversion value :" + hdnconversionvalue.Value;
                    //e.Row.Cells[2].Attributes.Add("class", "tooltip;");

                }
                // HtmlTableCell tdsrv = e.Row.FindControl("tdsrv") as HtmlTableCell;
                //imgbtnsendchallan.Attributes.Add("onclick", "ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "'" + lblfabrictype.Text + "'" + "," + lblsendQty.Text + ")");
                TextBox txtsendchallanno = (TextBox)e.Row.FindControl("txtsendchallanno");
                Label lblbiplsign = (Label)e.Row.FindControl("lblbiplsign");
                Label lblsuppliersign = (Label)e.Row.FindControl("lblsuppliersign");
                if (hdnIsAuthorizedSignatory.Value.ToLower() != "true")
                {
                    lblbiplsign.Text = "<br /> Pndg. GM conf.";
                    lblbiplsign.ForeColor = Color.Red;
                }
                else { lblbiplsign.Text = ""; }
                if (hdnIsPartySignature.Value.ToLower() != "true")
                {
                    lblsuppliersign.Text = "<br /> Pndg. Supp. conf.";
                    lblsuppliersign.ForeColor = Color.Red;
                }
                else { lblsuppliersign.Text = ""; }

                e.Row.Cells[0].Attributes.Add("onclick", "Setback(" + "Cotton Chambrey Poplin" + ")");
                e.Row.Cells[1].CssClass = "Cotton Chambrey Poplin PlusWidth";
                //e.Row.Cells[2].CssClass = "Cotton Chambrey Poplin";
                e.Row.Cells[3].CssClass = "Cotton Chambrey Poplin TypeWidth";
                e.Row.Cells[4].CssClass = "Cotton Chambrey Poplin";
                e.Row.Cells[5].CssClass = "Cotton Chambrey Poplin DateWidth";
                int IsMultiChallan = 0;
                Label lblstats = (Label)e.Row.FindControl("lblstats");
                //if (CreditNote == "")
                //{
                //    grdraisedpoworking.Columns[21].Visible = false;
                //    widthdiv.Attributes.Add("class", "table_width");
                //}
                if (lblfabrictype.Text.ToLower() == "Greige".ToLower() || lblfabrictype.Text.ToLower() == "Finished".ToLower())
                {
                    //txtsendchallanno.Visible = false;
                    lblsendQty.Text = "";
                    //imgbtnsendchallan.Visible = false;
                }
                lblunits.Text = GetUnitName(lblponumber.Text);
                int bal = Convert.ToInt32(hdnchallanmeter.Value.Replace(",", ""));
                lblbalanceQty.Text = Convert.ToDecimal(bal).ToString("N0");
                if (lblfabrictype.Text.ToLower() == "Greige".ToLower() || lblfabrictype.Text.ToLower() == "Finished".ToLower())

                    if (hdnchallanmeter.Value.Replace(",", "") != "0")
                        lbltotalqtyreceived.Attributes.Add("title", "Challan qty" + " " + hdnchallanmeter.Value);

                if (lblTotalpoQty.Text == "0")
                {
                    lblTotalpoQty.Text = "";
                }
                if (lblbalanceQty.Text == "0")
                {
                    lblbalanceQty.Text = "";
                }


                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                DataSet dsSend = new DataSet();
                DataTable dtsend = new DataTable();
                // if po cancel or closed then disabled row
                DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0];
                int IsCanceled = 0;

                if (dtstatus.Rows.Count > 0)
                {
                    if (dtstatus.Rows[0]["postatus"].ToString() == "2")
                    {
                        IsCanceled = 1;
                    }
                    if (dtstatus.Rows[0]["postatus"].ToString() == "1")
                    {
                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#fbcba2");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        e.Row.BackColor = c;
                    }
                    else if (dtstatus.Rows[0]["postatus"].ToString() == "2")
                    {
                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#ffc9c6");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        e.Row.BackColor = c;
                    }
                }
                System.Text.StringBuilder sb7 = new System.Text.StringBuilder();
                sb7.Append("<table id='data' style='width:100%' >");
                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                {
                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSENDCHALLNUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));

                    dtsend = dsSend.Tables[0];

                    if (dtsend.Rows.Count > 0)
                    {

                        srvid = (dtsend.Rows[0]["SRV_Id"].ToString() == "" ? "-1" : dtsend.Rows[0]["SRV_Id"].ToString());
                        challannumber = (dtsend.Rows[0]["challanNumber"].ToString() == "" ? "-1" : dtsend.Rows[0]["challanNumber"].ToString());

                        if (dtsend.Rows.Count == 1)
                        {
                            int i = 0;
                            for (i = 0; i < dtsend.Rows.Count; i++)
                            {

                            string SupplierPO_Id = (dtsend.Rows[i]["SupplierPO_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SupplierPO_Id"].ToString());
                            string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());
                            challannumber = (dtsend.Rows[i]["challanNumber"].ToString() == "" ? "-1" : dtsend.Rows[i]["challanNumber"].ToString());
                            string PartyBillNumber = (dtsend.Rows[i]["PartyBillNumber"].ToString() == "" ? "" : dtsend.Rows[i]["PartyBillNumber"].ToString());
                            int nNumber = int.TryParse(hdnActualSendQty.Value.Replace(",", ""), out nNumber) ? nNumber : 0;

                            if (IsCanceled == 1)
                            {
                                nNumber = 0;
                                sb7.AppendFormat("<tr>" +
                                                             "<td class='process' style='min-width: 70px !important;border-bottom: 1px solid #b1aeae;text-align:left;'>" +
                                                             "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 75% !important;text-align:left;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() +
                                                             "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + nNumber + ")'/>"
                                                             + (nNumber > 0 ? "<a  style='float:right;vertical-align:middle;cursor:pointer;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + nNumber + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" : "") + "</td></tr>");

                            }
                            else
                            {
                                sb7.AppendFormat("<tr>" +
                                  "<td class='process' style='min-width: 70px !important;border-bottom: 1px solid #b1aeae;text-align:left;'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 75% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() +
                                  "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + nNumber + ")'/>" + "</td>");

                                if (hdnIsPartySignature.Value == "True" && IsCanceled != 1)
                                {
                                    int actualsendqty = 0;
                                    if (hdnActualSendQty.Value.Replace(",", "") == "")
                                    {
                                        actualsendqty = 0;
                                    }
                                    else
                                    {
                                        actualsendqty = Convert.ToInt32(hdnActualSendQty.Value.Replace(",", ""));
                                    }
                                    if (actualsendqty > 0)
                                    {
                                        if (Convert.ToBoolean(dtsend.Rows[0]["CanMakeNewChallann"]) == true)
                                        {
                                            sb7.AppendFormat("<td class='process' style='min-width: 10px !important; margin-left: -13px; border-bottom: 1px solid #b1aeae; display: inline-block;'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;margin-top:6px;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + nNumber + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>");
                                        }
                                        else
                                        {
                                            sb7.AppendFormat("<td class='process' style='min-width: 10px !important; margin-left: -13px; border-bottom: 1px solid #b1aeae; display: inline-block;'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;margin-top:6px;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + nNumber + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>");
                                        }
                                    }
                                }
                                sb7.AppendFormat("</tr>");
                            }
                            }
                        }
                        else
                        {
                            if (dtsend.Rows.Count > 1)
                            {
                                IsMultiChallan = IsMultiChallan + dtsend.Rows.Count;
                                lnkplus.Attributes.Add("style", "display:block");
                                sb7.AppendFormat("<tr>" + "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "<img src='../../images/Arrow-Down2.png'>" + "</td></tr>");
                            }
                            else if (dtsend.Rows.Count <= 0)
                            {
                                sb7.AppendFormat("<tr>" + "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "" + "</td></tr>");
                            }
                        }
                    }
                    else
                    {
                        if (hdnIsPartySignature.Value == "True")
                        {
                            int actualsendqty = 0;
                            if (hdnActualSendQty.Value.Replace(",", "") == "")
                            {
                                actualsendqty = 0;
                            }
                            else
                            {
                                actualsendqty = Convert.ToInt32(hdnActualSendQty.Value.Replace(",", ""));
                            }
                            if (actualsendqty > 0)
                            {                               
                                    sb7.AppendFormat("<tr>"
                                                         + "<td class='process' style='border-bottom: 1px solid #b1aeae;'>"
                                                         + "<a  style='float:right;vertical-align:middle;cursor:pointer' title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>"
                                                    + "</tr>"
                                                     );
                                
                               
                            }
                        }
                    }
                    sb7.Append("</table>");
                    e.Row.Cells[8].Text = sb7.ToString();
                    //  e.Row.Cells[12].Text = sb7.ToString();
                }


                //FOC Start

                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                {
                    System.Text.StringBuilder sb8 = new System.Text.StringBuilder();
                    sb8.Append("<table id='data' style='width:100%' >");

                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSENDCHALLNUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));

                    dtsend = dsSend.Tables[0];

                    if (dtsend.Rows.Count > 0)
                    {
                        DataSet dsSend_foc = fabobj.GetRaisedPOWorkingDetails("GET_FOC_NUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                        DataTable dtsend_foc = dsSend_foc.Tables[0];

                        if (dtsend_foc.Rows.Count > 0)
                        {
                            if (dtsend_foc.Rows.Count == 1)
                            {
                                string FocId =  dtsend_foc.Rows[0]["FocId"].ToString();

                                if (IsCanceled != 1)
                                {
                                    sb8.AppendFormat("<tr>" +
                                       "<td class='process' style='min-width: 70px !important;border-bottom: 1px solid #b1aeae;text-align:left;'>" +
                                       "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 75% !important;text-align:left;' class='test inptunoneborder' title='' value='" + dtsend_foc.Rows[0]["FocNumber"].ToString() +
                                       "'onclick='ShowFOCScreen(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + FocId + "," + "&apos;" + lblfabrictype.Text + "&apos;" + ")'/>" + "</td>");

                                    if (Convert.ToBoolean(dtsend_foc.Rows[0]["CanMakeNewChallan"]) == true)
                                    {
                                        //if (dtsend_foc.Rows[0]["Status"].ToString() == "0")
                                        //{
                                        sb8.AppendFormat("<td class='process' style='min-width: 10px !important; margin-left: -13px; border-bottom: 1px solid #b1aeae; display: inline-block;'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;margin-top:6px;'   title='Create New Foc Challan' onclick='ShowFOCScreen_New(" + dtsend_foc.Rows[0]["Status"].ToString() + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>");
                                            sb8.AppendFormat("</tr>");
                                        //}
                                    }
                                    else
                                    {
                                        //if (dtsend_foc.Rows[0]["Status"].ToString() == "0")
                                        //{
                                        sb8.AppendFormat("<td class='process' style='min-width: 10px !important; margin-left: -13px; border-bottom: 1px solid #b1aeae; display: inline-block;'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;margin-top:6px;'   title='Create New Foc Challan' onclick='ShowFOCScreen_New(" + dtsend_foc.Rows[0]["Status"].ToString() + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>");
                                            sb8.AppendFormat("</tr>");
                                        //}

                                    }
                                    
                                }

                            }
                            else 
                            {
                                IsMultiChallan = IsMultiChallan + dtsend_foc.Rows.Count;
                                lnkplus.Attributes.Add("style", "display:block");
                                sb8.AppendFormat("<tr>" + "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "<img src='../../images/Arrow-Down2.png'>" + "</td></tr>");
                            }
                        }
                        else
                        {
                            //if (dtsend_foc.Rows[0]["Status"].ToString() == "0")
                            //{
                                sb8.AppendFormat("<td class='process' style='min-width: 10px !important;border-bottom: 1px solid #b1aeae;'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;margin-right:5px;'   title='Create new Foc Challan' onclick='ShowFOCScreen_New(" + dtsend_foc.Rows[0]["Status"].ToString() + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>");
                            //}
                        }
                    }

                    sb8.Append("</table>");
                    e.Row.Cells[9].Text = sb8.ToString();
                    e.Row.Cells[9].Visible = true;
                }

                System.Text.StringBuilder sb6 = new System.Text.StringBuilder();
                sb6.Append("<table id='data' style='width:100%' >");
                dsSend = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLE", "EXT", Convert.ToInt32(hdnSupplierPO_Id.Value));
                dtsend = dsSend.Tables[0];

                ////if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                ////{
                ////  if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                ////  {
                ////    //anopensrv.Attributes.Add("onclick", "alert('Generate send challan number first');");
                ////  }
                ////}
                if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroup.ToString() == iKandi.Common.Group.BIPL_QA.ToString())
                {
                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote'>" + "DebitNote" + "</td></tr>");
                }
                else
                {
                    if (dtsend.Rows.Count > 0)
                    {

                        //for (int i = 0; i < dtsend.Rows.Count; i++)
                        for (int i = 0; i < dtsend.Rows.Count; )
                        {
                            DataTable dtchallan = new DataTable();
                            string DebitNote_Id = (dtsend.Rows[i]["DebitNote_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["DebitNote_Id"].ToString());
                            string SupplierPO_Id = (dtsend.Rows[i]["SupplierPO_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SupplierPO_Id"].ToString());
                            string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());
                            string PartyBillNumber = (dtsend.Rows[i]["PartyBillNumber"].ToString() == "" ? "" : dtsend.Rows[i]["PartyBillNumber"].ToString());
                            string SRV_id = (dtsend.Rows[i]["SRV_id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SRV_id"].ToString());
                            // decimal debitqty = (dtsend.Rows[i]["debitQuantity"].ToString() == "" ? "-1" : dtsend.Rows[i]["debitQuantity"].ToString());
                            if (Convert.ToInt32(DebitNote_Id) > 0)
                            {

                                if (dtsend.Rows[i]["debitQuantity"].ToString() != "0" && dtsend.Rows[i]["debitQuantity"].ToString() != "")
                                {
                                    if (IsCanceled == 1)
                                    {
                                        // sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumbers"].ToString() + "' />" + "</td></tr>");
                                        decimal d_ = Convert.ToDecimal(dtsend.Rows[i]["debitQuantity"].ToString());
                                        // sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='₹" + d_.ToString("N0") + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + ")'/>" + "</td></tr>");
                                        if (PartyBillNumber == "")
                                            sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote_Grey'>" + "DebitNote" + "</td></tr>");
                                        else
                                            sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote'  onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'>" + "DebitNote" + "</td></tr>");

                                    }
                                    else
                                    {
                                        //if (IsCanceled == 1)
                                        //{
                                        //    // sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumbers"].ToString() + "' />" + "</td></tr>");
                                        //    decimal d_ = Convert.ToDecimal(dtsend.Rows[i]["debitQuantity"].ToString());
                                        //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;width: 67% !important;' class='test inptunoneborder' title='' value='' />" + "</td></tr>");
                                        //}
                                        //else
                                        //{
                                        //sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumbers"].ToString() + "' onclick='ShowSupplierChallanScreen(" + dtsend.Rows[i]["DebitNote_Id"].ToString() + "," + dtsend.Rows[i]["SupplierPO_Id"].ToString() + "," + dtsend.Rows[i]["Challan_Id"].ToString() + "," + "&apos;" + lblfabrictype.Text + "&apos;" + ")'/>" + "</td></tr>");
                                        decimal d_ = Convert.ToDecimal(dtsend.Rows[i]["debitQuantity"].ToString());
                                        //sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='₹" + d_.ToString("N0") + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + ")'/>" + "</td></tr>");
                                        if (PartyBillNumber == "")
                                            sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote_Grey'>" + "DebitNote" + "</td></tr>");
                                        else
                                            sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote'  onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'>" + "DebitNote" + "</td></tr>");

                                        //}
                                    }
                                }
                                else
                                {
                                    //if (IsCanceled == 1)
                                    //{
                                    //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                    //}
                                    //else
                                    //{
                                    if (PartyBillNumber == "")
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote_Grey'>" + "DebitNote" + "</td></tr>");
                                    else
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote'  onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'>" + "DebitNote" + "</td></tr>");

                                    //}
                                }

                                break;
                            }
                            else
                            {
                                //if (IsCanceled == 1)
                                //{
                                //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                //}
                                //else
                                //{
                                // sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + ")'/>" + "</td></tr>");
                                if (PartyBillNumber == "")
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote_Grey'>" + "DebitNote" + "</td></tr>");
                                else
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote'  onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'>" + "DebitNote" + "</td></tr>");

                                //}
                            }

                            break;
                        }
                    }
                    else
                    {
                        //if (IsCanceled == 1)
                        //{
                        //    sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "'  />" + "</td></tr>");
                        //}
                        //else
                        //{
                        // sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' onclick='ShowDebitnoteScreen(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + ")' />" + "</td></tr>");

                        //sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote_Grey' onclick='ShowDebitnoteScreen(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + ")'>" + "DebitNote" + "</td></tr>");

                        //if (PartyBillNumber == "")
                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote_Grey'>" + "DebitNote" + "</td></tr>");
                        //else
                        //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'><span class='btnDebitNote'  onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + ")'>" + "DebitNote" + "</td></tr>");

                        // }
                    }
                }

                sb6.Append("</table>");
                // add code by bharat on 10-june
                if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroup.ToString() == iKandi.Common.Group.BIPL_QA.ToString())
                {
                    string str = "";
                    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV'>Srv</a>";
                    e.Row.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                }
                else
                {
                    if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                    {
                        //string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test anopensrv1'  title=''><img src='../../images/edit.png'  /></a>";
                        //e.Row.Cells[17].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() && hdncurrentstage.Value != "1"))
                        {
                            // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "jqcall();", true);
                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' onclick='alertmsg()'><img src='../../images/edit.png' /></a>";
                            e.Row.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        }
                        else
                        {
                            if (IsCanceled == 1)
                            {
                                string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV'>Srv</a>";
                                str = "";
                                e.Row.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            }
                            else
                            {
                                string str = "";
                                if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
                                {
                                    //string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    e.Row.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                }
                                else
                                {
                                    //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                                    //{
                                    //    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    //}
                                    //e.Row.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                                    if (hdnIsPartySignature.Value == "True")
                                    {
                                        str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    }
                                    e.Row.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                }
                            }

                        }

                    }
                    else
                    {
                        if (IsCanceled == 1)
                        {
                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' >Srv</a>";
                            str = "";
                            e.Row.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        }
                        else
                        {
                            //string str = "";
                            //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                            //{
                            //    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                            //}
                            //e.Row.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                            string str = "";
                            if (hdnIsPartySignature.Value == "True")
                            {
                                str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                            }
                            e.Row.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                        }
                    }
                    if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                    {
                        //if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() && hdncurrentstage.Value != "1"))
                        // above case is comented by sanjeev on 06/09/2021 
                        if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && !(lblfabrictype.Text.ToLower() == "RFD".ToLower() && hdncurrentstage.Value == "1"))
                        {
                            e.Row.Cells[21].Text = "";
                            e.Row.Cells[21].Enabled = false;
                            e.Row.Cells[21].Attributes.Add("onclick", "alert('Generate send challan number first');");
                        }
                    }
                }

                ds = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    IsSrvMultiple = IsSrvMultiple + dt.Rows.Count;
                }
                if (dt.Rows.Count <= 1 && IsMultiChallan <= 1)
                {
                    lnkplus.Attributes.Add("style", "display:none");
                }
                if (dt.Rows.Count == 1)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' style='width:100%'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string units = "";
                        units = dt.Rows[i]["UnitName"].ToString() + " " + "(" + dt.Rows[i]["GateNumber"].ToString() + ")";
                        sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + units + "</td></tr>");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[10].Text = sb.ToString();

                    System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
                    System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                    System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                    System.Text.StringBuilder sb5 = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbpass = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbhold = new System.Text.StringBuilder();

                    sb2.Append("<table id='data' style='width:100%' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //if (IsCanceled == 1)
                        //{
                        //    sb2.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title=''>" + dt.Rows[i]["PartyChallanNumber"].ToString() + "</a>" + "</td></tr>");
                        //}
                        //else
                        //{
                        sb2.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' onclick='ShowSrvbyChallanNo(" + dt.Rows[i]["SRV_Id"].ToString() + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ',' + dt.Rows[i]["SupplierPo_Id"].ToString() + ")'> F-" + dt.Rows[i]["Receiving_Voucher_No"].ToString() + "</a>" + "</td></tr>");
                        // }

                    }
                    if (dt.Rows.Count == 0)
                    {
                        e.Row.Cells[22].Text = "";
                    }



                    sb2.Append("</table>");
                    //  e.Row.Cells[14].Text = sb2.ToString();
                    e.Row.Cells[11].Text = sb2.ToString();


                    sb3.Append("<table id='data' class='process' style='width:100%'>");
                    if (dt.Rows.Count == 1)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["ReceivedQty"].ToString() != "")
                            {

                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());

                                sb3.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + d_.ToString("N0") + "</td></tr>");
                            }
                            else
                            {
                                sb3.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + "" + "</td></tr>");
                            }
                        }
                        sb3.Append("</table>");
                        e.Row.Cells[16].Text = sb3.ToString();




                        sb4.Append("<table id='data' style='width:100%'>");

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows.Count == 1)
                            {
                                if (dt.Rows[0]["CheckedQty"].ToString() != "")
                                {
                                    decimal d_ = Convert.ToDecimal(dt.Rows[0]["CheckedQty"].ToString());
                                    string srt = "";
                                    if (d_.ToString("N0") != "0")
                                    {
                                        srt = d_.ToString("N0");
                                    }
                                    if (Convert.ToInt32(dt.Rows[0]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt.Rows[0]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["IsQtyChecked"].ToString())) > 0)
                                    {
                                        sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' onclick='ShowFourPointCheck(" + dt.Rows[0]["SRV_Id"].ToString() + "," + dt.Rows[0]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");
                                    }
                                }
                                else
                                {
                                    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "'/>" + "</td></tr>");
                                }
                            }
                            else
                            {
                                decimal d_ = 0;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["CheckedQty"].ToString() != "")
                                    {
                                        d_ += Convert.ToDecimal(dt.Rows[i]["CheckedQty"].ToString());
                                    }
                                }
                                string srt = "";
                                if (d_.ToString("N0") != "0")
                                {
                                    srt = d_.ToString("N0");
                                }

                                if (d_ > 0)
                                {
                                    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' />" + "</td></tr>");
                                }
                                else
                                {
                                    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "'/>" + "</td></tr>");
                                }
                            }
                        }
                        sb4.Append("</table>");
                        e.Row.Cells[17].Text = sb4.ToString();

                        sbpass.Append("<table id='data' style='width:100%' >");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["passQty"].ToString() != "")
                            {
                                decimal raisedebit = 0, UsableStock = 0;
                                raisedebit = dt.Rows[i]["InspectRaiseDebit"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectRaiseDebit"].ToString());
                                UsableStock = dt.Rows[i]["InspectUsableStock"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectUsableStock"].ToString());

                                string de = "";
                                if (raisedebit > 0)
                                {
                                    de = de + "<span style=font-size: 10px;>Raise Debit: </span>" + "<span style=color:yellow>" + raisedebit.ToString("N0") + "</span>";
                                }
                                if (UsableStock > 0)
                                {
                                    de = de + "</br>" + "<span style=font-size: 10px;>Usable Stock: " + "<span style=color:black>" + UsableStock.ToString("N0") + "</span>";
                                }


                                if (IsCanceled == 1)
                                {
                                    decimal d_ = Convert.ToDecimal(dt.Rows[i]["passQty"].ToString());
                                    if (de != "")
                                        sbpass.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text'  style='font-size: 11px;cursor:pointer;color:blue;width: 90% !important;' class='test inptunoneborder tooltip' title='" + de.ToString() + "' value='" + d_.ToString("N0") + "' />" + "</td></tr>");
                                    else
                                        sbpass.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 90% !important;' class='test inptunoneborder' title='" + "" + "' value='" + d_.ToString("N0") + "' />" + "</td></tr>");
                                }
                                else
                                {
                                    decimal d_ = Convert.ToDecimal(dt.Rows[i]["passQty"].ToString());
                                    if (de != "")
                                        sbpass.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text'  style='font-size: 11px;color:green;width: 90% !important;' class='test inptunoneborder tooltip' title='" + de.ToString() + "' value='" + d_.ToString("N0") + "' />" + "</td></tr>");
                                    else
                                        sbpass.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;color:green;width: 90% !important;' class='test inptunoneborder' title='" + "" + "' value='" + d_.ToString("N0") + "' />" + "</td></tr>");
                                }
                            }
                            else
                            {
                                if (IsCanceled == 1)
                                {
                                    sbpass.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #999;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                }
                                else
                                {
                                    sbpass.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #999;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                                }
                            }
                        }
                        sbpass.Append("</table>");
                        e.Row.Cells[18].Text = sbpass.ToString();


                        sbhold.Append("<table id='data' style='width:100%' >");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["HoldQty"].ToString() != "")
                            {
                                if (IsCanceled == 1)
                                {
                                    decimal d_ = Convert.ToDecimal(dt.Rows[i]["HoldQty"].ToString());
                                    string bgstr = d_ <= 0 ? "" : "background-color: #ffff80;";
                                    sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;color:black;width: 71% !important; " + bgstr + "' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                                }
                                else
                                {
                                    decimal d_ = Convert.ToDecimal(dt.Rows[i]["HoldQty"].ToString());
                                    string bgstr = d_ <= 0 ? "" : "background-color: #ffff80;";
                                    sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;color:black;width: 71% !important; " + bgstr + "' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "' />" + "</td></tr>");
                                }
                            }
                            else
                            {
                                if (IsCanceled == 1)
                                {
                                    sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #999;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;color:black;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                }
                                else
                                {
                                    sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #999;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;color:black;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                }
                            }
                        }
                        sbhold.Append("</table>");
                        e.Row.Cells[19].Text = sbhold.ToString();



                        sb5.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["FailQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["FailQty"].ToString());
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                    }
                    sb5.Append("</table>");
                    e.Row.Cells[20].Text = sb5.ToString();
                }
                else
                {
                    ds = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLE", "EXT", Convert.ToInt32(hdnSupplierPO_Id.Value));
                    dt = ds.Tables[0];


                    if (IsSrvMultiple > 1)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<table id='data' style='width:100%'>");
                        sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<img src='../../images/Arrow-Down2.png'>" + "</td></tr>");
                        sb.Append("</table>");

                        e.Row.Cells[10].Text = sb.ToString();
                        e.Row.Cells[11].Text = sb.ToString();

                    }


                    if (dt.Rows.Count == 1)
                    {
                        System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                        sb3.Append("<table id='data' class='process'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["ReceivedQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                                sb3.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + d_.ToString("N0") + "</td></tr>");
                            }
                        }
                        sb3.Append("</table>");
                        e.Row.Cells[16].Text = sb3.ToString();


                        System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                        sb4.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["CheckedQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["CheckedQty"].ToString());
                                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["CheckedQty"].ToString());
                                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "'/>" + "</td></tr>");

                            }
                        }
                        sb4.Append("</table>");
                        e.Row.Cells[17].Text = sb4.ToString();

                        System.Text.StringBuilder sbpass = new System.Text.StringBuilder();
                        sbpass.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["passQty"].ToString() != "")
                            {
                                decimal raisedebit = 0, UsableStock = 0;
                                raisedebit = dt.Rows[i]["InspectRaiseDebit"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectRaiseDebit"].ToString());
                                UsableStock = dt.Rows[i]["InspectUsableStock"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectUsableStock"].ToString());

                                string de = "";
                                if (raisedebit > 0)
                                {
                                    de = de + "<span style=font-size: 10px;>Raise Debit: </span>" + "<span style=color:yellow>" + raisedebit.ToString("N0") + "</span>";
                                }
                                if (UsableStock > 0)
                                {
                                    de = de + "</br>" + "<span style=font-size: 10px;>Usable Stock: " + "<span style=color:black>" + UsableStock.ToString("N0") + "</span>";
                                }
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["passQty"].ToString());
                                if (de != "")
                                    sbpass.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 90% !important;' class='test inptunoneborder tooltip' title='" + de.ToString() + "' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                                else
                                    sbpass.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 90% !important;' class='test inptunoneborder' title='" + "" + "' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                sbpass.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                        sbpass.Append("</table>");
                        e.Row.Cells[18].Text = sbpass.ToString();


                        System.Text.StringBuilder sbhold = new System.Text.StringBuilder();
                        sbhold.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (dt.Rows[i]["HoldQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["HoldQty"].ToString());
                                string bgstr = d_ <= 0 ? "" : "background-color: #ffff80;";
                                sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:black;width: 71% !important; " + bgstr + "' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:black;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                        sbhold.Append("</table>");
                        e.Row.Cells[19].Text = sbhold.ToString();


                        System.Text.StringBuilder sb5 = new System.Text.StringBuilder();
                        sb5.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["FailQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["FailQty"].ToString());
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                        sb5.Append("</table>");
                        e.Row.Cells[20].Text = sb5.ToString();
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            System.Text.StringBuilder sb5 = new System.Text.StringBuilder();
                            sb5.Append("<table id='data' style='width:100%'>");

                            if (dt.Rows[0]["FailQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[0]["FailQty"].ToString());
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }

                            sb5.Append("</table>");
                            e.Row.Cells[20].Text = sb5.ToString();
                        }
                    }

                }
            }
        }
        protected void lnkplus_Click(object sender, EventArgs e)
        {
            int SearchVal = 0;
            if (txtsearchkeyswords.Text != "")
                SearchVal = 1;

            bindgrd(SearchVal);
        }
        protected void lnkminus_Click(object sender, EventArgs e)
        {
            Session["SupplierPO_Id"] = null;
            Session["imgurlsset"] = null;
            int SearchVal = 0;
            if (txtsearchkeyswords.Text != "")
                SearchVal = 1;

            bindgrd(SearchVal);

        }
        public string Fabtype(string types)
        {
            string result = "";
            if (types.ToLower() == "Greige".ToLower() || types.ToLower() == "Finished".ToLower() || types.ToLower() == "RFD".ToLower())
            {
                result = "EXT";
            }
            if (types.ToLower() == "Dyed".ToLower() || types.ToLower() == "Printed".ToLower() || types.ToLower() == "Embellishment".ToLower() || types.ToLower() == "Embroidery".ToLower())
            {
                result = "EXTS";
            }
            return result;
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            int SearchVal = 0;
            if (txtsearchkeyswords.Text != "")
                SearchVal = 1;

            bindgrd(SearchVal);
        }
        public void SetRow()
        {
            string srvid = "";
            int IsMultiChallan = 0;
            foreach (GridViewRow gvr in grdraisedpoworking.Rows)
            {
                gvr.CssClass = "Unhighlighted";
                challannumber = "";
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                LinkButton lnkplus = (LinkButton)gvr.FindControl("lnkplus") as LinkButton;
                LinkButton lnkminus = (LinkButton)gvr.FindControl("lnkminus") as LinkButton;
                Label lblfabrictype = (Label)gvr.FindControl("lblfabrictype") as Label;
                HiddenField hdnSupplierPO_Id = (HiddenField)gvr.FindControl("hdnSupplierPO_Id") as HiddenField;
                HiddenField hdnIsPartySignature = (HiddenField)gvr.FindControl("hdnIsPartySignature") as HiddenField;
                HiddenField hdnIsAuthorizedSignatory = (HiddenField)gvr.FindControl("hdnIsAuthorizedSignatory") as HiddenField;
                HtmlAnchor anopensrv = (HtmlAnchor)gvr.FindControl("anopensrv");
                Label lblsendQty = (Label)gvr.FindControl("lblsendQty") as Label;
                lnkplus.Attributes.Add("style", "display:block;");
                lnkminus.Attributes.Add("style", "display:none;");
                Label lblponumber = (Label)gvr.FindControl("lblponumber") as Label;
                HiddenField hdncurrentstage = (HiddenField)gvr.FindControl("hdncurrentstage") as HiddenField;
                HiddenField hdnActualSendQty = (HiddenField)gvr.FindControl("hdnActualSendQty");
                DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0];
                int IsCanceled = 0;

                if (dtstatus.Rows.Count > 0)
                {
                    if (dtstatus.Rows[0]["postatus"].ToString() == "2")
                    {
                        IsCanceled = 1;
                    }
                }



                if (dtstatus.Rows.Count > 0)
                {
                    if (dtstatus.Rows[0]["postatus"].ToString() == "2")
                    {
                        IsCanceled = 1;
                    }
                    if (dtstatus.Rows[0]["postatus"].ToString() == "1")
                    {
                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#fbcba2");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        gvr.BackColor = c;
                        gvr.Attributes.Remove("class");

                    }
                    else if (dtstatus.Rows[0]["postatus"].ToString() == "2")
                    {
                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#ffc9c6");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        gvr.BackColor = c;
                        gvr.Attributes.Remove("class");


                    }
                }
                ds = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLE", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                dt = ds.Tables[0];
                if (fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0].Rows.Count <= 1)
                {
                    lnkplus.Attributes.Add("style", "display:none");
                }
                System.Text.StringBuilder sb78 = new System.Text.StringBuilder();
                sb78.Append("<table id='data' style='width:100%' >");

                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                {
                    //if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                    //{
                    DataSet dsSend = new DataSet();
                    DataTable dtsend = new DataTable();
                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSENDCHALLNUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                    dtsend = dsSend.Tables[0];
                    if (dtsend.Rows.Count > 0)
                    {
                        if (dtsend.Rows.Count == 1)
                        {
                            for (int i = 0; i < dtsend.Rows.Count; i++)
                            {

                                string SupplierPO_Id = (dtsend.Rows[i]["SupplierPO_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SupplierPO_Id"].ToString());
                                string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());
                                challannumber = (dtsend.Rows[i]["challanNumber"].ToString() == "" ? "-1" : dtsend.Rows[i]["challanNumber"].ToString());
                                string PartyBillNumber = (dtsend.Rows[i]["PartyBillNumber"].ToString() == "" ? "" : dtsend.Rows[i]["PartyBillNumber"].ToString());

                                if (IsCanceled == 1)
                                {
                                    int nNumber = int.TryParse(hdnActualSendQty.Value.Replace(",", ""), out nNumber) ? nNumber : 0;
                                    nNumber = 0;

                                    if (Convert.ToBoolean(dtsend.Rows[0]["CanMakeNewChallann"]) == true)
                                    {
                                        sb78.AppendFormat("<tr>" +
                                                                     "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" +
                                                                     "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 71% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() +
                                                                     "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + lblsendQty.Text.Replace(",", "") + "&apos;" + "YES" + "&apos;" + ")'/>" + (nNumber > 0 ? "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + nNumber + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" : "") + "</td></tr>");
                                    }
                                    else
                                    {
                                        sb78.AppendFormat("<tr>" +
                                                                     "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" +
                                                                     "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 71% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() +
                                                                     "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + lblsendQty.Text.Replace(",", "") + "&apos;" + "NO" + "&apos;" + ")'/>" + (nNumber > 0 ? "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + nNumber + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" : "") + "</td></tr>");

                                    }

                                }
                                else
                                {
                                    sb78.AppendFormat("<tr>" +
                                      "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 71% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() +
                                      "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + ")'/>" + "</td>");

                                    if (hdnIsPartySignature.Value == "True" && IsCanceled != 1)
                                    {
                                        int actualsendqty = 0;
                                        if (hdnActualSendQty.Value.Replace(",", "") == "")
                                        {
                                            actualsendqty = 0;
                                        }
                                        else
                                        {
                                            actualsendqty = Convert.ToInt32(hdnActualSendQty.Value.Replace(",", ""));
                                        }
                                        if (actualsendqty > 0)
                                        {
                                            if (Convert.ToBoolean(dtsend.Rows[0]["CanMakeNewChallann"]) == true)
                                            {
                                                sb78.AppendFormat("<td class='process' style='min-width: 10px !important;border-bottom: 1px solid #b1aeae;'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>");
                                            }
                                            else
                                            {
                                                sb78.AppendFormat("<td class='process' style='min-width: 10px !important;border-bottom: 1px solid #b1aeae;'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td>");

                                            }
                                        }


                                    }
                                    sb78.AppendFormat("</tr>");
                                }
                            }
                        }
                        else
                        {
                            if (dtsend.Rows.Count > 1)
                            {
                                // IsMultiChallan = IsMultiChallan + dtsend.Rows.Count;
                                lnkplus.Attributes.Add("style", "display:block");
                                sb78.AppendFormat("<tr>" + "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "<img src='../../images/Arrow-Down2.png'>" + "</td></tr>");
                            }
                            else if (dtsend.Rows.Count <= 0)
                            {
                                sb78.AppendFormat("<tr>" + "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "" + "</td></tr>");
                            }


                        }
                    }
                    else
                    {
                        int actualsendqty = 0;
                        if (hdnActualSendQty.Value.Replace(",", "") == "")
                        {
                            actualsendqty = 0;
                        }
                        else
                        {
                            actualsendqty = Convert.ToInt32(hdnActualSendQty.Value.Replace(",", ""));
                        }
                        if (actualsendqty > 0)
                        {
                            if (Convert.ToBoolean(dtsend.Rows[0]["CanMakeNewChallann"]) == true)
                            {
                                sb78.AppendFormat("<tr>" +
                                           "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" +
                                           "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                            }
                            else
                            {
                                sb78.AppendFormat("<tr>" +
                                           "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" +
                                           "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                            }
                        }
                    }




                    //else
                    //{
                    //    if (dtsend.Rows.Count > 0)
                    //    {
                    //        srvid = (dtsend.Rows[0]["SRV_Id"].ToString() == "" ? "-1" : dtsend.Rows[0]["SRV_Id"].ToString());
                    //        challannumber = (dtsend.Rows[0]["challanNumber"].ToString() == "" ? "-1" : dtsend.Rows[0]["challanNumber"].ToString());
                    //    }
                    //    if (IsCanceled == 1)
                    //    {
                    //        sb78.AppendFormat("<tr>" +
                    //                       "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" +
                    //                       "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' ><img src='../../images/edit.png' /></a>" + "</td></tr>");
                    //    }
                    //    else
                    //    {
                    //        sb78.AppendFormat("<tr>" +
                    //                       "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" +
                    //                       "<a  style='float:right;vertical-align:middle;cursor:pointer'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + lblsendQty.Text.Replace(",", "") + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                    //    }
                    //}
                    sb78.Append("</table>");
                    //gvr.Cells[12].Text = sb78.ToString();
                    gvr.Cells[8].Text = sb78.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                    sb3.Append("<table id='data' class='process'>");
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    for (int i = 0; i < dt.Rows.Count; )
                    {
                        if (dt.Rows[i]["ReceivedQty"].ToString() != "")
                        {
                            decimal d_ = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            sb3.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + d_.ToString("N0") + "</td></tr>");
                        }
                        break;
                    }
                    DataTable dtt = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0];
                    if (dtt.Rows.Count > 0)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
                        System.Text.StringBuilder sbs = new System.Text.StringBuilder();
                        if (dtt.Rows.Count == 1)
                        {
                            sb.Append("<table id='data' style='width:100%'>");
                            sb2.Append("<table id='data' style='width:100%'>");
                            for (int i = 0; i < dtt.Rows.Count; i++)
                            {
                                //if (IsCanceled == 1)
                                //{
                                //    string units = "";
                                //    units = dtt.Rows[i]["UnitName"].ToString() + " " + "(" + dtt.Rows[i]["GateNumber"].ToString() + ")";
                                //    sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + units + "</td></tr>");
                                //    sb2.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' >" + dtt.Rows[0]["PartyChallanNumber"].ToString() + "</a>" + "</td></tr>");
                                //}
                                //else
                                //{
                                string units = "";
                                units = dtt.Rows[i]["UnitName"].ToString() + " " + "(" + dtt.Rows[i]["GateNumber"].ToString() + ")";
                                sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + units + "</td></tr>");
                                sb2.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' onclick='ShowSrvbyChallanNo(" + dtt.Rows[0]["SRV_Id"].ToString() + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ',' + dt.Rows[i]["SupplierPo_Id"].ToString() + ")'> F-" + dtt.Rows[0]["Receiving_Voucher_No"].ToString() + "</a>" + "</td></tr>");
                                //}
                            }
                            sb.Append("</table>");
                            gvr.Cells[10].Text = sb.ToString();

                            sb2.Append("</table>");
                            gvr.Cells[11].Text = sb2.ToString();

                        }
                        if (dtt.Rows.Count > 1)
                        {
                            System.Text.StringBuilder sbrsv = new System.Text.StringBuilder();
                            sbrsv.Append("<table id='data' style='width:100%'>");
                            sbrsv.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<img src='../../images/Arrow-Down2.png'>" + "</td></tr>");
                            sbrsv.Append("</table>");

                            gvr.Cells[10].Text = sbrsv.ToString();
                            gvr.Cells[11].Text = sbrsv.ToString();

                        }

                        ds = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLEFOUR", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                        dt = ds.Tables[0];
                        DataSet dsscheck = new DataSet();
                        DataTable dtcheck = new DataTable();
                        dsscheck = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                        dtcheck = dsscheck.Tables[0];

                        System.Text.StringBuilder sbReceivedQty3 = new System.Text.StringBuilder();
                        sbReceivedQty3.Append("<table id='data' class='process'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["ReceivedQty"].ToString() != "")
                            {

                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                                string srt = "";
                                if (d_.ToString("N0") != "0")
                                {
                                    srt = d_.ToString("N0");
                                }

                                sbReceivedQty3.AppendFormat("<tr ><td class='process' title='" + GetUnitName(lblponumber.Text) + "' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + srt + "</td></tr>");

                            }
                        }
                        sbReceivedQty3.Append("</table>");
                        gvr.Cells[16].Text = sbReceivedQty3.ToString();


                        System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                        sb4.Append("<table id='data' style='width:100%'>");
                        DataSet dss = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                        DataTable dt1 = dss.Tables[0];
                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows.Count == 1)
                            {
                                if (dt1.Rows[0]["CheckedQty"].ToString() != "")
                                {
                                    decimal d_ = Convert.ToDecimal(dt1.Rows[0]["CheckedQty"].ToString());
                                    string srt = "";
                                    if (d_.ToString("N0") != "0")
                                    {
                                        srt = d_.ToString("N0");
                                    }
                                    if (Convert.ToInt32(dt1.Rows[0]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[0]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt1.Rows[0]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[0]["IsQtyChecked"].ToString())) > 0)
                                    {
                                        sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' onclick='ShowFourPointCheck(" + dt1.Rows[0]["SRV_Id"].ToString() + "," + dt1.Rows[0]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");
                                    }
                                }
                                else
                                {
                                    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "'/>" + "</td></tr>");
                                }
                            }
                            else
                            {
                                decimal d_ = 0;
                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    if (dt1.Rows[i]["CheckedQty"].ToString() != "")
                                    {
                                        d_ += Convert.ToDecimal(dt1.Rows[i]["CheckedQty"].ToString());
                                    }
                                }
                                string srt = "";
                                if (d_.ToString("N0") != "0")
                                {
                                    srt = d_.ToString("N0");
                                }

                                if (d_ > 0)
                                {
                                    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' />" + "</td></tr>");
                                }
                                else
                                {
                                    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "'/>" + "</td></tr>");
                                }
                            }
                        }
                        sb4.Append("</table>");
                        gvr.Cells[17].Text = sb4.ToString();

                        //DataSet dss = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                        //DataTable dt1 = dss.Tables[0];
                        //if (dt1.Rows.Count == 1)
                        //{
                        //    System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                        //    sb4.Append("<table id='data' style='width:100%' >");
                        //    for (int i = 0; i < dt1.Rows.Count; i++)
                        //    {
                        //        if (dt1.Rows[i]["CheckedQty"].ToString() != "")
                        //        {
                        //            decimal d_ = Convert.ToDecimal(dt1.Rows[i]["CheckedQty"].ToString());
                        //            string srt = "";
                        //            if (d_.ToString("N0") != "0")
                        //            {
                        //                srt = d_.ToString("N0");
                        //            }

                        //            if (Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString())) > 0)
                        //                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' />" + "</td></tr>");

                        //        }
                        //        else
                        //        {

                        //            if (Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString())) > 0)
                        //                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "' onclick='ShowFourPointCheck(" + dt1.Rows[i]["SRV_Id"].ToString() + "," + dt1.Rows[i]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");

                        //        }

                        //    }
                        //    sb4.Append("</table>");
                        //    gvr.Cells[16].Text = sb4.ToString();

                        //}


                        System.Text.StringBuilder sbpass = new System.Text.StringBuilder();
                        sbpass.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["passQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["passQty"].ToString());
                                string srt = "";
                                if (d_.ToString("N0") != "0")
                                {
                                    srt = d_.ToString("N0");
                                }
                                decimal raisedebit = 0, UsableStock = 0;
                                raisedebit = dt.Rows[i]["InspectRaiseDebit"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectRaiseDebit"].ToString());
                                UsableStock = dt.Rows[i]["InspectUsableStock"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectUsableStock"].ToString());

                                string de = "";
                                if (raisedebit > 0)
                                {
                                    de = de + "<span style=font-size: 10px;>Raise Debit: </span>" + "<span style=color:yellow>" + raisedebit.ToString("N0") + "</span>";
                                }
                                if (UsableStock > 0)
                                {
                                    de = de + "</br>" + "<span style=font-size: 10px;>Usable Stock: " + "<span style=color:black>" + UsableStock.ToString("N0") + "</span>";
                                }
                                if (de != "")
                                    sbpass.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder tooltip' title='" + de.ToString() + "' value='" + srt + "'/>" + "</td></tr>");
                                else
                                    sbpass.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder' title='" + "" + "' value='" + srt + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                sbpass.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                        sbpass.Append("</table>");
                        gvr.Cells[18].Text = sbpass.ToString();


                        System.Text.StringBuilder sbhold = new System.Text.StringBuilder();
                        sbhold.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["HoldQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["HoldQty"].ToString());
                                string srt = "";
                                if (d_.ToString("N0") != "0")
                                {
                                    srt = d_.ToString("N0");
                                }
                                string bgstr = d_ <= 0 ? "" : "background-color: #ffff80;";
                                sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:black;width: 71% !important; " + bgstr + "' class='test inptunoneborder' title='' value='" + srt + "'/>" + "</td></tr>");

                            }
                            else
                            {
                                sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:black;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                        sbhold.Append("</table>");
                        gvr.Cells[19].Text = sbhold.ToString();


                        System.Text.StringBuilder sb5 = new System.Text.StringBuilder();
                        sb5.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["FailQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["FailQty"].ToString());
                                string srt = "";
                                if (d_.ToString("N0") != "0")
                                {
                                    srt = d_.ToString("N0");
                                }

                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + srt + "'/>" + "</td></tr>");

                            }
                            else
                            {
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                        sb5.Append("</table>");
                        gvr.Cells[20].Text = sb5.ToString();


                    }
                    System.Text.StringBuilder sb7 = new System.Text.StringBuilder();
                    sb7.Append("<table id='data' style='width:100%' >");


                    sb3.Append("</table>");
                    gvr.Cells[16].Text = sb3.ToString();

                    DataSet dsSend = new DataSet();
                    DataTable dtsend = new DataTable();
                    System.Text.StringBuilder sb6 = new System.Text.StringBuilder();
                    sb6.Append("<table id='data' style='width:100%' >");
                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLE", "EXT", Convert.ToInt32(hdnSupplierPO_Id.Value));
                    dtsend = dsSend.Tables[0];

                    DataTable dts = fabobj.GetRaisedPOWorkingDetails("GETSENDCHALLNUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0];
                    if (dts.Rows.Count > 0)
                    {
                        challannumber = (dts.Rows[0]["challanNumber"].ToString() == "" ? "-1" : dts.Rows[0]["challanNumber"].ToString());
                    }
                    if (dtsend.Rows.Count > 0)
                    {
                        //for (int i = 0; i < dtsend.Rows.Count; i++)
                        for (int i = 0; i < dtsend.Rows.Count; )
                        {
                            DataTable dtchallan = new DataTable();
                            string DebitNote_Id = (dtsend.Rows[i]["DebitNote_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["DebitNote_Id"].ToString());
                            string SupplierPO_Id = (dtsend.Rows[i]["SupplierPO_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SupplierPO_Id"].ToString());
                            string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());
                            string PartyBillNumber = (dtsend.Rows[i]["PartyBillNumber"].ToString() == "" ? "" : dtsend.Rows[i]["PartyBillNumber"].ToString());
                            string SRV_id = (dtsend.Rows[i]["SRV_id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SRV_id"].ToString());

                            ////if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                            ////{
                            ////  if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                            ////  {
                            ////    //anopensrv.Attributes.Add("onclick", "alert('Generate send challan number first');");
                            ////  }
                            ////}
                            if (Convert.ToInt32(DebitNote_Id) > 0)
                            {
                                if (dtsend.Rows[i]["debitQuantity"].ToString() != "0" && dtsend.Rows[i]["debitQuantity"].ToString() != "")
                                {
                                    //if (IsCanceled == 1)
                                    //{
                                    //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text ' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumbers"].ToString() + "' />" + "</td></tr>");
                                    //}
                                    //else
                                    //{
                                    //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text ' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumbers"].ToString() + "' onclick='ShowSupplierChallanScreen(" + dtsend.Rows[i]["DebitNote_Id"].ToString() + "," + dtsend.Rows[i]["SupplierPO_Id"].ToString() + "," + dtsend.Rows[i]["Challan_Id"].ToString() + "," + "&apos;" + lblfabrictype.Text + "&apos;" + ")'/>" + "</td></tr>");
                                    //}
                                    decimal d_ = Convert.ToDecimal(dtsend.Rows[i]["debitQuantity"].ToString());
                                    string srt = "";
                                    if (d_.ToString("N0") != "0")
                                    {
                                        srt = d_.ToString("N0");
                                    }
                                    //if (IsCanceled == 1)
                                    //{
                                    //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='' />" + "</td></tr>");
                                    //}
                                    //else
                                    //{
                                    if (PartyBillNumber == "")
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text ' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='DebitNote' />" + "</td></tr>");
                                    else
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text ' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='DebitNote' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'/>" + "</td></tr>");

                                    //}
                                }
                                else
                                {
                                    //if (IsCanceled == 1)
                                    //{
                                    //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                    //}
                                    //else
                                    //{
                                    if (PartyBillNumber == "")
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'/>" + "</td></tr>");
                                    else
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'/>" + "</td></tr>");

                                    //}
                                }
                                break;
                            }
                            else
                            {
                                //if (IsCanceled == 1)
                                //{
                                //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                //}
                                //else
                                //{
                                if (PartyBillNumber == "")
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'/>" + "</td></tr>");
                                else
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'/>" + "</td></tr>");


                                //}
                            }
                            break;
                        }
                    }
                    else
                    {
                        //if (IsCanceled == 1)
                        //{
                        //    sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "'  />" + "</td></tr>");
                        //}
                        //else
                        //{

                        sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px' title='" + GetUnitName(lblponumber.Text) + "'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + ")' />" + "</td></tr>");
                        //}
                    }
                    sb6.Append("</table>");

                    if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                    {

                        // if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                        if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                        {
                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' onclick='alertmsg()'><img src='../../images/edit.png' /></a>";
                            gvr.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                        }
                        else
                        {
                            if (IsCanceled == 1)
                            {
                                string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' >Srv</a>";
                                str = "";
                                gvr.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd '>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            }
                            else
                            {
                                string str = "";
                                if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
                                {

                                    gvr.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                }
                                else
                                {
                                    //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                                    //{
                                    //    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    //}

                                    //gvr.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                                    if (hdnIsPartySignature.Value == "True")
                                    {
                                        str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    }

                                    gvr.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                }
                            }

                        }
                    }
                    else
                    {
                        if (IsCanceled == 1)
                        {
                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' >Srv</a>";
                            str = "";
                            gvr.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        }
                        else
                        {
                            //    string str = "";
                            //    if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                            //    {
                            //        str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                            //    }
                            //    gvr.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                            string str = "";
                            if (hdnIsPartySignature.Value == "True")
                            {
                                str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                            }
                            gvr.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        }
                        //gvr.Cells[17].Text = sb6.ToString();
                    }
                    //end
                }
            }
        }
        //protected void LinkButton_Click(Object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Session.RemoveAll();
        //    Session.Abandon();
        //    Response.Redirect("Login.aspx");
        //}
        protected void grdraisedpoworking_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {



            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            DataSet dsSend = new DataSet();
            DataTable dtsend = new DataTable();
            challannumber = "";
            //Table tblGrdviewApplet = (Table)grdraisedpoworking.Controls[0];
            //GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
            GridViewRow rows = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            //int Index = Convert.ToInt32(e.CommandArgument);
            // GridViewRow rows = grdraisedpoworking.Rows[Index];
            LinkButton lnkplus = (LinkButton)rows.FindControl("lnkplus") as LinkButton;
            LinkButton lnkminus = (LinkButton)rows.FindControl("lnkminus") as LinkButton;
            HiddenField hdnSupplierPO_Id = (HiddenField)rows.FindControl("hdnSupplierPO_Id") as HiddenField;
            Label lblfabrictype = (Label)rows.FindControl("lblfabrictype") as Label;
            Label lblsendQty = (Label)rows.FindControl("lblsendQty") as Label;
            HtmlAnchor anopensrv = (HtmlAnchor)rows.FindControl("anopensrv");
            HiddenField hdnIsPartySignature = (HiddenField)rows.FindControl("hdnIsPartySignature") as HiddenField;
            HiddenField hdnIsAuthorizedSignatory = (HiddenField)rows.FindControl("hdnIsAuthorizedSignatory") as HiddenField;
            HiddenField hdncurrentstage = (HiddenField)rows.FindControl("hdncurrentstage") as HiddenField;
            HiddenField hdnActualSendQty = (HiddenField)rows.FindControl("hdnActualSendQty");
            DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0];
            int IsCanceled = 0;
            // bindgrd(0);
            //if (e.CommandName == "Plus")
            //{
            //    grdraisedpoworking_OnRowCommand(grdraisedpoworking, new GridViewCommandEventArgs(lnkplus, new CommandEventArgs(lnkplus.CommandName, lnkplus.CommandArgument)));
            //}
            //else
            //{
            //    grdraisedpoworking_OnRowCommand(grdraisedpoworking, new GridViewCommandEventArgs(lnkminus, new CommandEventArgs(lnkminus.CommandName, lnkminus.CommandArgument)));
            //}
            if (dtstatus.Rows.Count > 0)
            {
                if (dtstatus.Rows[0]["postatus"].ToString() == "2")
                {
                    IsCanceled = 1;
                }
            }
            //SetRow();

            rows.CssClass = "highlighted";
            if (e.CommandName == "Plus")
            {
                //bindgrd();
                lnkplus.Attributes.Add("style", "display:none;");
                lnkminus.Attributes.Add("style", "display:block;");

                ds = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                dt = ds.Tables[0];

                System.Text.StringBuilder sbs = new System.Text.StringBuilder();
                sbs.Append("<table id='data' style='width:100%'>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string units = "";
                    units = dt.Rows[i]["UnitName"].ToString() + " " + "(" + dt.Rows[i]["GateNumber"].ToString() + ")";
                    sbs.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + units + "</td></tr>");
                }
                sbs.Append("</table>");
                // rows.Cells[13].Text = sbs.ToString();
                rows.Cells[10].Text = sbs.ToString();
                if (dt.Rows.Count <= 1)
                {
                    lnkplus.Attributes.Add("style", "display:none");
                }
                System.Text.StringBuilder sb7 = new System.Text.StringBuilder();

                sb7.Append("<table id='data' style='width:100%' >");
                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                {
                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSENDCHALLNUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                    dtsend = dsSend.Tables[0];

                    for (int i = 0; i < dtsend.Rows.Count; i++)
                    {
                        string SupplierPO_Id = (dtsend.Rows[i]["SupplierPO_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SupplierPO_Id"].ToString());
                        string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());
                        challannumber = (dtsend.Rows[i]["challanNumber"].ToString() == "" ? "-1" : dtsend.Rows[i]["challanNumber"].ToString());
                        string PartyBillNumber = (dtsend.Rows[i]["PartyBillNumber"].ToString() == "" ? "" : dtsend.Rows[i]["PartyBillNumber"].ToString());
                        // add code by bharat on 10-june
                        if (i == 0)
                        {
                            // if (IsCanceled == 1)
                            // {
                            //     sb7.AppendFormat("<tr>" +
                            //   "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align: center;padding-left:2px; padding-right-2px;'>" +
                            //   "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 70% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() + "' />"
                            //  +

                            //"<a  style='vertical-align:middle;cursor:pointer;padding-right: 4px;' title='Create new send challan number' ><img src='../../images/edit.png' /></a>" + "</td></tr>");

                            // }
                            // else
                            // {

                            
                                sb7.AppendFormat("<tr>" +
                                  "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align: center;padding-left:2px; padding-right-2px;'>" +
                                  "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 70% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() + "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + ")'/>" + "</td></tr>");
                            
                          

                            // "<a  style='float:right;vertical-align:middle;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;;" + lblfabrictype.Text + "&apos;;" + "," + lblsendQty.Text + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                            //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                            //{
                            //    sb7.AppendFormat("<a  style='float:right;vertical-align:middle;cursor:pointer;padding-right: 4px;' title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + lblsendQty.Text.Replace(",", "") + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                            //}

                            // }
                        }
                        else
                        {
                            //if (IsCanceled == 1)
                            //{
                            //    sb7.AppendFormat("<tr>" +
                            //                                       "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align: center;padding-left:2px; padding-right-2px;'>" +
                            //                                       "<input readonly type='text inptunoneborder' style='font-size: 9px;cursor:pointer;color:blue;width: 70% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() + "' /></td></tr>");
                            //}
                            //else
                            //{
                            sb7.AppendFormat("<tr>" +
                               "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align: center;padding-left:2px; padding-right-2px;'>" +
                               "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 70% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() + "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + ")'/></td></tr>");
                            //}

                        }

                        //end
                    }
                    if (hdnIsPartySignature.Value == "True" && IsCanceled != 1)
                    {
                        int actualsendqty = 0;
                        if (hdnActualSendQty.Value.Replace(",", "") == "")
                        {
                            actualsendqty = 0;
                        }
                        else
                        {
                            actualsendqty = Convert.ToInt32(hdnActualSendQty.Value.Replace(",", ""));
                        }
                        if (actualsendqty > 0)
                        {
                            if (Convert.ToBoolean(dtsend.Rows[0]["CanMakeNewChallann"]) == true)
                            {
                                sb7.AppendFormat("<tr><td class='process' style='border-right:0px'><a  style='vertical-align:middle;cursor:pointer;padding-right: 4px;' title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," +"&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                            }
                            else
                            {
                                sb7.AppendFormat("<tr><td class='process' style='border-right:0px'><a  style='vertical-align:middle;cursor:pointer;padding-right: 4px;' title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");

                            }
                        }


                    }
                    sb7.Append("</table>");
                    //   rows.Cells[12].Text = sb7.ToString(); // comment bhy bharat on 15-july
                    rows.Cells[8].Text = sb7.ToString();
                }


                //Foc When Clicked on Plus Button Start
                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                {
                    System.Text.StringBuilder sb8 = new System.Text.StringBuilder();
                    sb8.Append("<table id='data' style='width:100%' >");

                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSENDCHALLNUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));

                    dtsend = dsSend.Tables[0];

                    if (dtsend.Rows.Count > 0)
                    {
                        DataSet dsSend_foc = fabobj.GetRaisedPOWorkingDetails("GET_FOC_NUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                        DataTable dtsend_foc = dsSend_foc.Tables[0];

                        for (int i = 0; i < dtsend_foc.Rows.Count; i++)
                        {
                            string FocId = dtsend_foc.Rows[i]["FocId"].ToString();

                            //if (dtsend_foc.Rows[0]["Status"].ToString() == "0")
                            //{

                                sb8.AppendFormat("<tr>" +
                                   "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align: center;padding-left:2px; padding-right-2px;'>" +
                                   "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 70% !important;' class='test inptunoneborder' title='' value='" + dtsend_foc.Rows[i]["FocNumber"].ToString() + "' onclick='ShowFOCScreen(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + FocId + "," + "&apos;" + lblfabrictype.Text + "&apos;" + ")'/></td></tr>");
                            //}
                        }
                        if (dtsend_foc.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dtsend_foc.Rows[0]["CanMakeNewChallan"]) == true)
                            {
                                //if (dtsend_foc.Rows[0]["Status"].ToString() == "0")
                                //{
                                sb8.AppendFormat("<tr><td class='process' style='border-right:0px'><a  style='vertical-align:middle;cursor:pointer;padding-right: 4px;' title='Create new FOC Challan' onclick='ShowFOCScreen_New(" + dtsend_foc.Rows[0]["Status"].ToString()+"," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                                    sb8.Append("</table>");
                                //}
                            }
                            else
                            {
                                //if (dtsend_foc.Rows[0]["Status"].ToString() == "0")
                                //{
                                sb8.AppendFormat("<tr><td class='process' style='border-right:0px'><a  style='vertical-align:middle;cursor:pointer;padding-right: 4px;' title='Create new FOC Challan' onclick='ShowFOCScreen_New(" + dtsend_foc.Rows[0]["Status"].ToString() + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                                    sb8.Append("</table>");
                                //}
                            }
                        }
                        else
                        {
                            //if (dtsend_foc.Rows[0]["Status"].ToString() == "0")
                            //{
                            sb8.AppendFormat("<tr><td class='process' style='border-right:0px'><a  style='vertical-align:middle;cursor:pointer;padding-right: 4px;' title='Create new FOC Challan' onclick='ShowFOCScreen_New(" + dtsend_foc.Rows[0]["Status"].ToString() + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                                sb8.Append("</table>");
                            //}
                        }
                    }
                    rows.Cells[9].Text = sb8.ToString();
                }
                //Foc When Clicked on Plus Button End 


                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
                    sb2.Append("<table id='data' style='width:100%' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //if (IsCanceled == 1)
                        //{
                        //    sb2.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' >" + dt.Rows[i]["PartyChallanNumber"].ToString() + "</a>" + "</td></tr>");
                        //}
                        //else
                        //{
                        //if (dtstatus.Rows[0]["postatus"].ToString() != "1" && dtstatus.Rows[0]["postatus"].ToString() != "2")
                        //{
                        sb2.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' onclick='ShowSrvbyChallanNo(" + dt.Rows[i]["SRV_Id"].ToString() + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ',' + Convert.ToInt32(hdnSupplierPO_Id.Value) + ")'> F-" + dt.Rows[i]["Receiving_Voucher_No"].ToString() + "</a>" + "</td></tr>");
                        //}
                        // }
                    }
                    sb2.Append("</table>");
                    // rows.Cells[14].Text = sb2.ToString();
                    rows.Cells[11].Text = sb2.ToString();

                    System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                    sb3.Append("<table id='data' class='process' style='width:100%'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ReceivedQty"].ToString() != "")
                        {

                            decimal d_ = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            string srt = "";
                            if (d_.ToString("N0") != "0")
                            {
                                srt = d_.ToString("N0");
                            }
                            sb3.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + srt + "</td></tr>");
                        }
                        else
                        {
                            sb3.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + "" + "</td></tr>");
                        }
                    }
                    sb3.Append("</table>");
                    rows.Cells[16].Text = sb3.ToString();


                    System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                    sb4.Append("<table id='data' style='width:100%' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["CheckedQty"].ToString() != "")
                        {
                            decimal d_ = Convert.ToDecimal(dt.Rows[i]["CheckedQty"].ToString());
                            string srt = "";
                            if (d_.ToString("N0") != "0")
                            {
                                srt = d_.ToString("N0");
                            }
                            //if (IsCanceled == 1)
                            //{
                            //    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' />" + "</td></tr>");
                            //}
                            //else
                            //{
                            if (Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString())) > 0)
                                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' onclick='ShowFourPointCheck(" + dt.Rows[i]["SRV_Id"].ToString() + "," + dt.Rows[i]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");
                            //}
                        }
                        else
                        {
                            //if (IsCanceled == 1)
                            //{
                            //    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "' />" + "</td></tr>");
                            //}
                            //else
                            //{
                            if (Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString())) > 0)
                                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "' onclick='ShowFourPointCheck(" + dt.Rows[i]["SRV_Id"].ToString() + "," + dt.Rows[i]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");
                            //}
                        }
                    }
                    sb4.Append("</table>");
                    rows.Cells[17].Text = sb4.ToString();
                    // rows.Cells[18].Text = sb4.ToString();

                    System.Text.StringBuilder sbpass = new System.Text.StringBuilder();
                    sbpass.Append("<table id='data' style='width:100%'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["passQty"].ToString() != "")
                        {
                            decimal d_ = Convert.ToDecimal(dt.Rows[i]["passQty"].ToString());
                            string srt = "";
                            if (d_.ToString("N0") != "0")
                            {
                                srt = d_.ToString("N0");
                            }
                            decimal raisedebit = 0, UsableStock = 0;
                            raisedebit = dt.Rows[i]["InspectRaiseDebit"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectRaiseDebit"].ToString());
                            UsableStock = dt.Rows[i]["InspectUsableStock"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["InspectUsableStock"].ToString());

                            string de = "";
                            if (raisedebit > 0)
                            {
                                de = de + "<span style=font-size: 10px;>Raise Debit: </span>" + "<span style=color:yellow>" + raisedebit.ToString("N0") + "</span>";
                            }
                            if (UsableStock > 0)
                            {
                                de = de + "</br>" + "<span style=font-size: 10px;>Usable Stock: " + "<span style=color:black>" + UsableStock.ToString("N0") + "</span>";
                            }
                            if (de != "")
                                sbpass.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder tooltip' title='" + de.ToString() + "' value='" + srt + "'/>" + "</td></tr>");
                            else
                                sbpass.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder' title='" + "" + "' value='" + srt + "'/>" + "</td></tr>");
                        }
                        else
                        {
                            sbpass.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:green;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                        }
                    }
                    sbpass.Append("</table>");
                    rows.Cells[18].Text = sbpass.ToString();

                    System.Text.StringBuilder sbhold = new System.Text.StringBuilder();
                    sbhold.Append("<table id='data' style='width:100%'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["HoldQty"].ToString() != "")
                        {
                            decimal d_ = Convert.ToDecimal(dt.Rows[i]["HoldQty"].ToString());
                            string srt = "";
                            if (d_.ToString("N0") != "0")
                            {
                                srt = d_.ToString("N0");
                            }
                            string bgstr = d_ <= 0 ? "" : "background-color: #ffff80;";
                            sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:black;width: 71% !important; " + bgstr + "' class='test inptunoneborder' title='' value='" + srt + "'/>" + "</td></tr>");
                        }
                        else
                        {
                            sbhold.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:black;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                        }
                    }
                    sbhold.Append("</table>");
                    rows.Cells[19].Text = sbhold.ToString();


                    System.Text.StringBuilder sb5 = new System.Text.StringBuilder();
                    sb5.Append("<table id='data' style='width:100%'>");
                    decimal ds_ = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["FailQty"].ToString() != "")
                        {
                            ds_ = Convert.ToDecimal(dt.Rows[i]["FailQty"].ToString());
                            string srt = "";
                            //if (ds_.ToString("N0") != "0")
                            //{
                                srt = ds_.ToString("N0");
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + srt + "'/>" + "</td></tr>");
                            //}

                        }
                        else
                        {
                            sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                        }
                    }
                    sb5.Append("</table>");
                    //  rows.Cells[17].Text = sb5.ToString();
                    rows.Cells[20].Text = sb5.ToString();


                    System.Text.StringBuilder sb6 = new System.Text.StringBuilder();
                    sb6.Append("<table id='data' style='width:100%' >");
                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLE", "EXT", Convert.ToInt32(hdnSupplierPO_Id.Value));
                    dtsend = dsSend.Tables[0];

                    string DebitNote_Id = "-1";
                    if (dtsend.Rows.Count > 0)
                    {
                        //for (int i = 0; i < dtsend.Rows.Count; i++)
                        for (int i = 0; i < dtsend.Rows.Count; )
                        {
                            DataTable dtchallan = new DataTable();
                            DebitNote_Id = (dtsend.Rows[i]["DebitNote_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["DebitNote_Id"].ToString());
                            string SupplierPO_Id = (dtsend.Rows[i]["SupplierPO_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SupplierPO_Id"].ToString());
                            string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());
                            string PartyBillNumber = (dtsend.Rows[i]["PartyBillNumber"].ToString() == "" ? "" : dtsend.Rows[i]["PartyBillNumber"].ToString());
                            string SRV_id = (dtsend.Rows[i]["SRV_id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SRV_id"].ToString());

                            if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                            {
                                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                                {
                                    // anopensrv.Attributes.Add("onclick", "alert('Generate send challan number first');");
                                }
                            }
                            if (Convert.ToInt32(DebitNote_Id) > 0)
                            {
                                if (dtsend.Rows[i]["debitQuantity"].ToString() != "0" && dtsend.Rows[i]["debitQuantity"].ToString() != "")
                                {

                                    decimal d_ = Convert.ToDecimal(dtsend.Rows[i]["debitQuantity"].ToString());
                                    string srt = "";
                                    if (d_.ToString("N0") != "0")
                                    {
                                        srt = d_.ToString("N0");
                                    }
                                    //if (IsCanceled == 1)
                                    //{
                                    //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='DebitNote' />" + "</td></tr>");
                                    //}
                                    //else
                                    //{
                                    if (PartyBillNumber == "")
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='DebitNote' />" + "</td></tr>");
                                    else
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='DebitNote' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'/>" + "</td></tr>");
                                    //}
                                }
                                else
                                {
                                    //if (IsCanceled == 1)
                                    //{
                                    //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                    //}
                                    //else
                                    //{
                                    if (PartyBillNumber == "")
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' />" + "</td></tr>");
                                    else
                                        sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")' />" + "</td></tr>");

                                    //}

                                }
                                break;
                            }
                            else
                            {
                                //if (IsCanceled == 1)
                                //{
                                //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                //}
                                //else
                                //{
                                if (PartyBillNumber == "")
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' />" + "</td></tr>");
                                else
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")' />" + "</td></tr>");

                                //}
                            }
                            break;
                        }
                    }
                    else
                    {
                        //if (IsCanceled == 1)
                        //{
                        //    sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "'  />" + "</td></tr>");
                        //}
                        //else
                        //{


                        //}
                        if (DebitNote_Id != "-1")
                        {
                            sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + ")' />" + "</td></tr>");
                        }
                        else
                        {
                            sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "'  />" + "</td></tr>");
                        }
                    }
                    sb6.Append("</table>");

                    // code by bharat on 10-june
                    if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                    {
                        //if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                        if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                        {
                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test' title='' onclick='alertmsg()'><img src='../../images/edit.png' /></a>";
                            rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            //  rows.Cells[18]
                        }
                        else
                        {
                            if (IsCanceled == 1)
                            {
                                string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' >Srv</a>";
                                str = "";
                                rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            }
                            else
                            {
                                string str = "";
                                if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
                                {


                                    rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                }
                                else
                                {
                                    //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                                    //{
                                    //    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    //}
                                    //rows.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                    if (hdnIsPartySignature.Value == "True")
                                    {
                                        str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    }
                                    rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                                }
                            }
                        }
                    }
                    else
                    {
                        if (IsCanceled == 1)
                        {

                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' >Srv</a>";
                            str = "";
                            rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        }
                        else
                        {
                            string str = "";
                            if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
                            {

                                rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            }
                            else
                            {
                                //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                                //{
                                //    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                //}
                                //rows.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                                if (hdnIsPartySignature.Value == "True")
                                {
                                    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                }
                                rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                            }

                        }

                    }
                    //end

                    //  rows.Cells[17].Text = sb6.ToString();

                }
                // bindgrd();
            }
            if (e.CommandName == "Minus")
            {
                challannumber = "";
                Session["SupplierPO_Id"] = null;
                Session["imgurlsset"] = null;
                lnkplus.Attributes.Add("style", "display:block;");
                lnkminus.Attributes.Add("style", "display:none;");

                System.Text.StringBuilder sb7 = new System.Text.StringBuilder();
                sb7.Append("<table id='data' style='width:100%' >");
                //if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                {
                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSENDCHALLNUMBER", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                    dtsend = dsSend.Tables[0];
                    if (dtsend.Rows.Count == 1)
                    {
                        for (int i = 0; i < dtsend.Rows.Count; i++)
                        {

                            //"<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 70% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() + "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + lblsendQty.Text.Replace(",", "") + ")'/>"
                            challannumber = (dtsend.Rows[0]["challanNumber"].ToString() == "" ? "-1" : dtsend.Rows[0]["challanNumber"].ToString());
                            string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());

                            int actualsendqty = 0;
                            if (hdnActualSendQty.Value.Replace(",", "") == "")
                            {
                                actualsendqty = 0;
                            }
                            else
                            {
                                actualsendqty = Convert.ToInt32(hdnActualSendQty.Value.Replace(",", ""));
                            }
                            sb7.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align: center;padding-left:2px; padding-right-2px;'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 70% !important;' class='test inptunoneborder' title='' value='" + dtsend.Rows[i]["challanNumber"].ToString() + "' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Challan_Id + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + ")'/></td></tr>");
                            if (actualsendqty > 0)
                            {
                                if (Convert.ToBoolean(dtsend.Rows[0]["CanMakeNewChallann"]) == true)
                                {
                                    sb7.AppendFormat("<tr><td class='process' style='border-right:0px'>" + "<a  style='vertical-align:middle;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "YES" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                                }
                                else
                                {
                                    sb7.AppendFormat("<tr><td class='process' style='border-right:0px'>" + "<a  style='vertical-align:middle;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + "," + "&apos;" + "NO" + "&apos;" + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");

                                }
                            }



                        }
                    }
                    if (dtsend.Rows.Count > 1)
                    {
                        // IsMultiChallan = IsMultiChallan + dtsend.Rows.Count;
                        //lnkplus.Attributes.Add("style", "display:block");
                        sb7.AppendFormat("<tr>" + "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "<img src='../../images/Arrow-Down2.png'>" + "</td></tr>");
                    }
                    else if (dtsend.Rows.Count <= 0)
                    {
                        sb7.AppendFormat("<tr>" + "<td class='process' style='min-width: 80px !important;border-bottom: 1px solid #b1aeae;'>" + "" + "</td></tr>");
                    }
                    if (IsCanceled != 1)
                    {
                        //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                        //{
                        //    sb7.AppendFormat("<tr>" +
                        //       "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" +
                        //       "<a  style='float:right;vertical-align:middle;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + lblsendQty.Text.Replace(",", "") + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                        //}

                        //if (hdnIsPartySignature.Value == "True")
                        //{
                        //    sb7.AppendFormat("<tr>" +
                        //       "<td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" +
                        //       "<a  style='float:right;vertical-align:middle;'   title='Create new send challan number' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + "," + "&apos;" + lblfabrictype.Text + "&apos;" + "," + hdnActualSendQty.Value.Replace(",", "") + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                        //}

                    }
                    //rows.Cells[12].Text = sb7.ToString(); // comment by bharat on 15-july
                    sb7.Append("</table>");
                    rows.Cells[8].Text = sb7.ToString();

                }
                ds = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLE", "EXT", Convert.ToInt32(hdnSupplierPO_Id.Value));
                dt = ds.Tables[0];
                //if (dt.Rows.Count <= 1)
                //{
                //  lnkplus.Attributes.Add("style", "display:none");
                //}
                DataSet dss = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value));
                DataTable dt1 = dss.Tables[0];
                if (dt1.Rows.Count == 1)
                {
                    System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                    sb4.Append("<table id='data' style='width:100%' >");
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt1.Rows[i]["CheckedQty"].ToString() != "")
                        {
                            decimal d_ = Convert.ToDecimal(dt1.Rows[i]["CheckedQty"].ToString());
                            string srt = "";
                            if (d_.ToString("N0") != "0")
                            {
                                srt = d_.ToString("N0");
                            }

                            if (Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString())) > 0)
                                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' />" + "</td></tr>");

                        }
                        else
                        {

                            if (Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt1.Rows[i]["IsQtyChecked"].ToString())) > 0)
                                sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "' onclick='ShowFourPointCheck(" + dt1.Rows[i]["SRV_Id"].ToString() + "," + dt1.Rows[i]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");

                        }

                    }
                    sb4.Append("</table>");
                    rows.Cells[17].Text = sb4.ToString();

                }

                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                    System.Text.StringBuilder sb5 = new System.Text.StringBuilder();
                    System.Text.StringBuilder sb4 = new System.Text.StringBuilder();

                    sb3.Append("<table id='data' class='process'>");
                    if (dt.Rows.Count == 1)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["ReceivedQty"].ToString() != "")
                            {
                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                                sb3.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #b1aeae;width: 77px;'>" + d_.ToString("N0") + "</td></tr>");
                            }
                        }
                        sb3.Append("</table>");
                        rows.Cells[16].Text = sb3.ToString();



                        //sb4.Append("<table id='data' style='width:100%'>");
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    if (dt.Rows[i]["CheckedQty"].ToString() != "")
                        //    {
                        //        decimal d_ = Convert.ToDecimal(dt.Rows[i]["CheckedQty"].ToString());
                        //        sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                        //    }
                        //    else
                        //    {
                        //        sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "'/>" + "</td></tr>");
                        //    }
                        //}
                        //sb4.Append("</table>");
                        //rows.Cells[16].Text = sb4.ToString();



                        sb5.Append("<table id='data' style='width:100%'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["FailQty"].ToString() != "")
                            {

                                decimal d_ = Convert.ToDecimal(dt.Rows[i]["FailQty"].ToString());
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                            }
                            else
                            {
                                sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                            }
                        }
                        sb5.Append("</table>");
                    }
                    else
                    {
                        sb5.Append("<table id='data' style='width:100%'>");
                        decimal d_ = 0;
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["FailQty"].ToString() != "")
                            {
                                d_ = Convert.ToDecimal(dt.Rows[0]["FailQty"].ToString());

                            }

                        }
                        if (d_ > 0)
                        {

                            sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + d_.ToString("N0") + "'/>" + "</td></tr>");
                        }
                        else
                        {
                            sb5.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' style='font-size: 11px;color:red;width: 71% !important;' class='test inptunoneborder' title='' value='" + "" + "'/>" + "</td></tr>");
                        }
                        sb5.Append("</table>");
                    }


                    rows.Cells[20].Text = sb5.ToString();

                    System.Text.StringBuilder sb6 = new System.Text.StringBuilder();
                    sb6.Append("<table id='data' style='width:100%' >");

                    DataTable dtsrvcheck = fabobj.GetRaisedPOWorkingDetails("GETSRV", Fabtype(lblfabrictype.Text), Convert.ToInt32(hdnSupplierPO_Id.Value)).Tables[0];

                    if (dtsrvcheck.Rows.Count > 1)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<table id='data' style='width:100%'>");
                        sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<img src='../../images/Arrow-Down2.png'>" + "</td></tr>");
                        sb.Append("</table>");

                        rows.Cells[10].Text = sb.ToString();
                        rows.Cells[11].Text = sb.ToString();

                    }


                    dsSend = fabobj.GetRaisedPOWorkingDetails("GETSRVSINGLE", "EXT", Convert.ToInt32(hdnSupplierPO_Id.Value));
                    dtsend = dsSend.Tables[0];

                    string DebitNote_Id = "- 1";
                    if (dtsend.Rows.Count > 0)
                    {
                        DebitNote_Id = (dtsend.Rows[0]["DebitNote_Id"].ToString() == "" ? "-1" : dtsend.Rows[0]["DebitNote_Id"].ToString());
                        //System.Text.StringBuilder sb4 = new System.Text.StringBuilder();
                        //sb4.Append("<table id='data' style='width:100%' >");
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    if (dt.Rows[i]["CheckedQty"].ToString() != "")
                        //    {
                        //        decimal d_ = Convert.ToDecimal(dt.Rows[i]["CheckedQty"].ToString());
                        //        string srt = "";
                        //        if (d_.ToString("N0") != "0")
                        //        {
                        //            srt = d_.ToString("N0");
                        //        }
                        //        //if (IsCanceled == 1)
                        //        //{
                        //        //    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' />" + "</td></tr>");
                        //        //}
                        //        //else
                        //        //{
                        //        if (Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString())) > 0)
                        //            sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + srt + "' onclick='ShowFourPointCheck(" + dt.Rows[i]["SRV_Id"].ToString() + "," + dt.Rows[i]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");
                        //        //}
                        //    }
                        //    else
                        //    {
                        //        //if (IsCanceled == 1)
                        //        //{
                        //        //    sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "' />" + "</td></tr>");
                        //        //}
                        //        //else
                        //        //{
                        //        if (Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsStoreIncharge"].ToString())) > 0 || Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["IsQtyChecked"].ToString())) > 0)
                        //            sb4.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;'>" + "<input readonly type='text' title='Open four point check' style='font-size: 11px;cursor:pointer;color:blue;width: 71% !important;' class='test' title='' value='" + "" + "' onclick='ShowFourPointCheck(" + dt.Rows[i]["SRV_Id"].ToString() + "," + dt.Rows[i]["SupplierPO_Id"].ToString() + "," + orderid + "," + OrderDetailID + ")'/>" + "</td></tr>");
                        //        //}
                        //    }
                        //}
                        //sb4.Append("</table>");
                        //rows.Cells[16].Text = sb4.ToString();

                        //for (int i = 0; i < dtsend.Rows.Count; i++)
                        for (int i = 0; i < dtsend.Rows.Count; )
                        {
                            DataTable dtchallan = new DataTable();
                            DebitNote_Id = (dtsend.Rows[i]["DebitNote_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["DebitNote_Id"].ToString());
                            string SupplierPO_Id = (dtsend.Rows[i]["SupplierPO_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SupplierPO_Id"].ToString());
                            string Challan_Id = (dtsend.Rows[i]["Challan_Id"].ToString() == "" ? "-1" : dtsend.Rows[i]["Challan_Id"].ToString());
                            string PartyBillNumber = (dtsend.Rows[i]["PartyBillNumber"].ToString() == "" ? "" : dtsend.Rows[i]["PartyBillNumber"].ToString());
                            string SRV_id = (dtsend.Rows[i]["SRV_id"].ToString() == "" ? "-1" : dtsend.Rows[i]["SRV_id"].ToString());

                            if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                            {
                                if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                                {
                                    //anopensrv.Attributes.Add("onclick", "alert('Generate send challan number first');");
                                }
                            }
                            if (Convert.ToInt32(DebitNote_Id) > 0)
                            {

                                //if (IsCanceled == 1)
                                //{
                                //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                //}
                                //else
                                //{
                                if (PartyBillNumber == "")
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' />" + "</td></tr>");
                                else
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")' />" + "</td></tr>");
                                //}

                                break;
                            }
                            else
                            {
                                //if (IsCanceled == 1)
                                //{
                                //    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "' />" + "</td></tr>");
                                //}
                                //else
                                //{
                                if (PartyBillNumber == "")
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' />" + "</td></tr>");
                                else
                                    sb6.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + DebitNote_Id + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + Convert.ToInt32(SRV_id) + ")'/>" + "</td></tr>");
                                //}
                            }
                            break;
                        }
                    }
                    else
                    {
                        //if (IsCanceled == 1)
                        //{
                        //    sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:blue;width: 67% !important;' class='test inptunoneborder' title='' value='" + "" + "'  />" + "</td></tr>");
                        //}
                        //else
                        //{
                        if (DebitNote_Id != "-1")
                        {
                            sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "' onclick='ShowDebitnoteScreen(" + -1 + "," + Convert.ToInt32(hdnSupplierPO_Id.Value) + "," + -1 + ")' />" + "</td></tr>");
                        }
                        else
                        {
                            sb6.AppendFormat("<tr><td class='process'  style='width: 77px;border-bottom: 1px solid #b1aeae;text-align:left;padding-left:2px'>" + "<input readonly  type='text' style='font-size: 9px;cursor:pointer;color:grey;width: 67% !important;' class='test inptunoneborder' title='' value='" + "DebitNote" + "'  />" + "</td></tr>");
                        }
                        //}
                    }
                    sb6.Append("</table>");

                    // code by bharat on 10-june
                    if (challannumber == "0" || challannumber == "" || challannumber == "-1")
                    {
                        //if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower())
                        if (lblfabrictype.Text.ToLower() != "Greige".ToLower() && lblfabrictype.Text.ToLower() != "Finished".ToLower() && (lblfabrictype.Text.ToLower() != "RFD".ToLower() || hdncurrentstage.Value != "1"))
                        {
                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='alertmsg()'>Srv</a>";
                            rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        }
                        else
                        {
                            if (IsCanceled == 1)
                            {
                                string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' >Srv</a>";
                                str = "";
                                rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            }
                            else
                            {
                                string str = "";
                                if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
                                {
                                    rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                }
                                else
                                {

                                    //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                                    //{
                                    //    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    //}
                                    //rows.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                                    if (hdnIsPartySignature.Value == "True")
                                    {
                                        str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                    }
                                    rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                                }
                            }
                        }
                    }
                    else
                    {
                        if (IsCanceled == 1)
                        {
                            string str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' >Srv</a>";
                            str = "";
                            rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                        }
                        else
                        {
                            string str = "";
                            if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
                            {

                                rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            }
                            else
                            {
                                //if (hdnIsPartySignature.Value == "True" && hdnIsAuthorizedSignatory.Value == "True")
                                //{
                                //    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                //}
                                //rows.Cells[20].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";

                                if (hdnIsPartySignature.Value == "True")
                                {
                                    str = "<a style='font-size: 11px;cursor:pointer;color:blue;' class='test btnSrv' title='Create New SRV' onclick='ShowSrvbySupplierID(" + Convert.ToInt32(hdnSupplierPO_Id.Value) + ',' + "&apos;" + lblfabrictype.Text + "&apos;" + ")'>Srv</a>";
                                }
                                rows.Cells[21].Text = "<table class='challanTable'> <tr><td class='challantd'>" + sb6.ToString() + "</td><td class='challanimgtd'>" + str + "</td></tr></table>";
                            }
                        }

                    }

                    // rows.Cells[17].Text = sb6.ToString();
                }

            }
        }
        protected void imgpsupplierponumber_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            if (Session["dts"] != null)
            {
                dt = (DataTable)Session["dts"];
                ImageButton imgbtn = (ImageButton)(sender);
                if (imgbtn.CommandName == "sort")
                {
                    if (imgbtn.CommandArgument == "desc")
                    {
                        if (dt.Rows.Count > 0)
                        {
                            dt.DefaultView.Sort = "PO_Number Desc";
                            dt.AcceptChanges();
                            grdraisedpoworking.DataSource = dt;
                            grdraisedpoworking.DataBind();
                            MergeRows(grdraisedpoworking);
                            imgpsupplierponumberdecnding.Style.Add("Display", "block;");
                            imgpsupplierponumberaccnding.Style.Add("Display", "None;");
                        }
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            dt.DefaultView.Sort = "PO_Number ASC";
                            dt.AcceptChanges();
                            grdraisedpoworking.DataSource = dt;
                            grdraisedpoworking.DataBind();
                            MergeRows(grdraisedpoworking);
                            imgpsupplierponumberdecnding.Style.Add("Display", "None;");
                            imgpsupplierponumberaccnding.Style.Add("Display", "block;");
                        }

                    }
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrd(1);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "callhide();", true);
        }       
        //protected void grdraisedpoworking_PageIndexChanging(object sender, GridViewPageEventArgs e)// Added by shubhendu
        //{
        //   // DataSet ds= new DataSet();
        //   // DataTable dt=new DataTable();

        //   // grdraisedpoworking.PageIndex = e.NewPageIndex;
        //   //ds= fabobj.GetRaisedPOWorkingDetailsIndex("GET", "", e.NewPageIndex, 10, SupplierPO, txtsearchkeyswords.Text.Trim(), Convert.ToInt32(ddlstatus.SelectedItem.Value), OrderDetailID);
        //   //dt = ds.Tables[0];
        //   //if (dt != null)
        //   //{

        //   //    grdraisedpoworking.DataSource = dt;
        //   //    grdraisedpoworking.DataBind();
        //   //}


        //}



    }
}

