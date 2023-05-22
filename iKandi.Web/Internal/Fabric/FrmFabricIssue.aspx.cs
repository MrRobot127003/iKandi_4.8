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

namespace iKandi.Web.Internal.Fabric
{
    public partial class FrmFabricIssue : System.Web.UI.Page
    {
        Designation[] IssueRequestDesig = { Designation.BIPL_Production_PPC_Exec, Designation.BIPL_Fabrics_PPC_Fabric_Executive, Designation.BIPL_Fabrics_Manager_PPC, Designation.BIPL_Admin };
        Designation[] IssueRequestedDesig = { Designation.BIPL_Admin, Designation.BIPL_Fabrics_Manager, Designation.BIPL_Fabrics_Manager_Fabric_Store, Designation.BIPL_Fabrics_Store_Assistent };
        int userid;
        public static int Quality_ID
        {
            get;
            set;
        }

        public static string UnitName
        {
            get;
            set;
        }
        public static int orderDetailID
        {
            get;
            set;
        }
        public static int OrderID
        {
            get;
            set;
        }
        public static int Unitid
        {
            get;
            set;
        }

        public static int IsAllUpdate
        {
            get;
            set;
        }
        public static int AnyIraise
        {
            get;
            set;
        }
        // this code added by bharat on 2-july for header hide
        public static int HeaderHideFa
        {
            get;
            set;
        }
        public static string CutIssueComplete
        {
            get;
            set;
        }
        // end
        FabricController fabobj = new FabricController();
        public string GetUnitName(string po)
        {
            DataTable dt = fabobj.GetUnitName();

            //DataView dv = new DataView(dt);
            //dv.RowFilter = "(PO_Number == " + po + ")";
            DataRow[] dv = dt.Select("PO_Number = '" + po + "'");

            return dv[0]["UnitsNames"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            GetQueryString();
            if (!Page.IsPostBack)
            {

                IsAllUpdate = 0;
                AnyIraise = 0;
                BindGrd();
                //if (UnitName != "")
                //{
                //    UnitName = "";
                //}
            }
        }
        public void GetQueryString()
        {
            if (Request.UrlReferrer != null)// added by shubhendu 22/03/2022
            {

                UnitName = "";

            }
            if (Request.QueryString["Quality_ID"] != null)
                Quality_ID = Convert.ToInt32(Request.QueryString["Quality_ID"]);
            else
            {
                Quality_ID = -1; //4feb
            }
            if (Request.QueryString["orderDetailID"] != null)
                orderDetailID = Convert.ToInt32(Request.QueryString["orderDetailID"]);
            else
            {
                orderDetailID = -1;

            }
            if (Request.QueryString["OrderID"] != null)
                OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
            else
            {
                OrderID = -1;

            }
            if (orderDetailID != -1)
            {
                btnSearch.Visible = false;
                txtsearchkeyswords.Visible = false;
                lbltotalrequest.Visible = false;
                lblpending.Visible = false;
            }
            if (OrderID != -1)
            {
                btnSearch.Visible = false;
                txtsearchkeyswords.Visible = false;
                lbltotalrequest.Visible = false;
                lblpending.Visible = false;
            }
            //if (Request.QueryString["HeaderHideFa"] != null)
            //    HeaderHideFa = Convert.ToInt32(Request.QueryString["HeaderHideFa"]);
            //else
            //{
            //    HeaderHideFa = 3;

            //}
            //hdnheaderID.Value = HeaderHideFa.ToString();

        }

        public void BindGrd()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = fabobj.GetFabricIssueDetails("BASIC", -1, -1, Quality_ID, OrderID, txtsearchkeyswords.Text.Trim());
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (IsAllUpdate != 1)
                {
                    if (dt.Rows[0]["Unitid"].ToString() != "")
                    {
                        Unitid = Convert.ToInt32(dt.Rows[0]["Unitid"]);
                    }
                }
                grdfabric.DataSource = dt;
                grdfabric.DataBind();
                emptyrow.Visible = false;
                grdfabric.Visible = true;
                DropDownList ddlFactoryUnit = ((DropDownList)this.grdfabric.HeaderRow.FindControl("ddlFactoryUnit"));
                if (dt.Rows[0]["Unitid"].ToString() != "")
                {
                    ddlFactoryUnit.SelectedValue = dt.Rows[0]["Unitid"].ToString();
                    UnitName = ddlFactoryUnit.SelectedItem.Text;
                }


                if (Convert.ToInt32(AnyIraise) > 0)
                {
                    CheckBox chkraisecuttingall = ((CheckBox)this.grdfabric.HeaderRow.FindControl("chkraisecuttingall"));
                    chkraisecuttingall.Checked = true;
                    chkraisecuttingall.Enabled = false;
                    //  DropDownList ddlFactoryUnit = ((DropDownList)this.grdfabric.HeaderRow.FindControl("ddlFactoryUnit"));
                    ddlFactoryUnit.Enabled = false;
                    ddlFactoryUnit.Visible = false;

                }
            }
            else
            {
                emptyrow.Visible = true;
                grdfabric.Visible = false;


                string valToRe = "0";
                lbltotalrequest.Text = "Total Request:" + "<b style='color:blue;font-weight:500'>" + " " + valToRe + "</b>";

                string valToPen = "0";
                lblpending.Text = "Total Pending Issue:" + "<b style='color:blue;font-weight:500'>" + " " + valToPen + "</b>";

            }
        }
        protected void grdfabric_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            string IsIssueComplete = "";
            string stockcaption = "";
            if (e.Row.RowType == DataControlRowType.Header)
            {
                DropDownList ddlFactoryUnit = ((DropDownList)e.Row.FindControl("ddlFactoryUnit"));
                DataTable dtProd = new DataTable();
                dtProd = fabobj.GetSupplierChallanDetails("PRODUCTIONUNIT").Tables[0];
                ddlFactoryUnit.DataSource = dtProd;
                ddlFactoryUnit.DataBind();
                ddlFactoryUnit.SelectedValue = Unitid.ToString();
                UnitName = ddlFactoryUnit.SelectedItem.Text == "Select" ? "" : "(" + ddlFactoryUnit.SelectedItem.Text + ")";



                //UnitName = ddlFactoryUnit.SelectedItem.Text;

                //Unitid = Convert.ToInt32(ddlFactoryUnit.SelectedItem.Value);
                //  ddlFactoryUnit.SelectedItem.Text = UnitName;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataSet ds = new DataSet();
                DataSet dsPriorStage = new DataSet();
                DataTable dtFabric = new DataTable();
                DataTable dtPrint = new DataTable();
                DataTable dtTotalPrint = new DataTable();
                DataTable dtPriorStage = new DataTable();

                // HiddenField hdnOrderdetailID = (HiddenField)e.Row.FindControl("hdnOrderdetailID");
                CheckBox chkraise = (CheckBox)e.Row.FindControl("chkraise");
                HiddenField hdnavailableqty = (HiddenField)e.Row.FindControl("hdnavailableqty");
                Label lblcontract = (Label)e.Row.FindControl("lblcontract");





                //TextBox txtcutwastage = (HiddenField)e.Row.FindControl("txtcutwastage");
                int OrderdetailID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OderDetailID"));

                if (lblcontract.Text.Length > 21)
                {
                    lblcontract.Attributes.Add("data-title", lblcontract.Text);
                    lblcontract.Text = lblcontract.Text.Substring(0, 10) + "...";
                }


                //int CuttingRequest_IssueSheet_Id=0;//= Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CuttingRequest_IssueSheet_Id"));
                //var outputParam = DataBinder.Eval(e.Row.DataItem, "CuttingRequest_IssueSheet_Id");
                //if (!(outputParam is DBNull))
                //  CuttingRequest_IssueSheet_Id = Convert.ToInt32(outputParam);

                ds = fabobj.GetFabricIssueDetails("CONTRACTDETAILS", Convert.ToInt32(OrderdetailID), -1, Quality_ID, orderDetailID);
                dtFabric = ds.Tables[0];
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dtPrint = ds.Tables[1];
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    dtTotalPrint = ds.Tables[2];
                }
                try
                {
                    DataTable drs = fabobj.GetFabricIssueDetails("PENDINGISSUEDETAILS", 0, 0, Quality_ID, orderDetailID).Tables[0];
                    if (drs.Rows.Count > 0)
                    {
                        string valToRe = drs.Rows[0]["totalreq"].ToString();
                        lbltotalrequest.Text = "Total Request:" + "<b style='color:blue;font-weight:500'>" + " " + valToRe + "</b>";

                        string valToPen = drs.Rows[0]["PendingIssueCom"].ToString();
                        lblpending.Text = "Total Pending Issue:" + "<b style='color:blue;font-weight:500'>" + " " + valToPen + "</b>";
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                    sbfab.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    for (int i = 0; i < Convert.ToInt32(dtFabric.Rows[0]["maxseqnumber"].ToString()); i++)
                    {
                        string fabcaption = (dtPrint.Rows[0]["Fabric_Details" + (i + 1).ToString()].ToString().ToLower() == "Tbd".ToLower() ? "<span style='color:black;font-weight:600 !important;background-color: orange;'>" + dtPrint.Rows[0]["Fabric_Details" + (i + 1).ToString()].ToString() + "</span>" : "<span style='color:black;font-weight:600 !important;'>" + dtPrint.Rows[0]["Fabric_Details" + (i + 1).ToString()].ToString() + "</span>");
                        sbfab.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;text-align:left !important;padding-left:4px'><span style='color:blue !important;'>" + dtFabric.Rows[0]["Fabric" + (i + 1).ToString()].ToString() + "</span>/" + fabcaption + "/" + dtPrint.Rows[0]["Avgs" + (i + 1).ToString()].ToString() + "</td></tr>");
                    }
                    sbfab.Append("</table>");
                    e.Row.Cells[4].Text = sbfab.ToString();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    System.Text.StringBuilder sbcutwastage = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbraisereq = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbchallan = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbextrastockissue = new System.Text.StringBuilder();

                    //System.Text.StringBuilder sbVIEWS = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbpendingQty = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbissuecomplete = new System.Text.StringBuilder();
                    System.Text.StringBuilder qtyleft = new System.Text.StringBuilder();
                    System.Text.StringBuilder strstock = new System.Text.StringBuilder();
                    //string vals = "";
                    sbcutwastage.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbraisereq.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbchallan.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbextrastockissue.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");

                    //sbVIEWS.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbpendingQty.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbissuecomplete.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    qtyleft.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");

                    strstock.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    String IsChallanExits = "";
                    string aa = "";
                    for (int i = 0; i < Convert.ToInt32(dtFabric.Rows[0]["maxseqnumber"].ToString()); i++)
                    {
                        IsIssueComplete = "";
                        DataTable dt = new DataTable();
                        dt = fabobj.GetFabricIssueDetails("GETCUTWASTAGE", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];
                        string val = "";
                        string IsCheck = "";
                        string IsCheckDate = "";
                        string IsDisable = "";

                        string IsCheck_Issue = "";
                        string IsSettlementDone = "";

                        string IsCheckDate_issue = "";
                        string SettlementDate = "";

                        string IsDisable_issue = "";
                        string IsDisable_Settlement = "disabled";

                        // IsIssueComplete = dt.Rows[0]["IsCompleteIssue"].ToString();
                        if (dt.Rows.Count > 0)
                        {
                            val = dt.Rows[0]["CuttingWastage"].ToString();
                            // val = dtTotalPrint.Rows[i]["cutwas"].ToString();
                        }

                        dt = fabobj.GetFabricIssueDetails("GETCUTWASTAGE", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];

                        string idissue = "txtCutwas" + OrderdetailID.ToString() + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dt.Rows[0]["IsCompleteIssue"].ToString() != ""))
                                if (Convert.ToBoolean(dt.Rows[0]["IsCompleteIssue"].ToString() != "0"))
                                {

                                    IsIssueComplete = "disabled";
                                }


                            if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString() != ""))
                                if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString() != "0"))
                                {
                                    AnyIraise = AnyIraise + 1;
                                    IsCheck = "checked";
                                    IsDisable = "disabled";
                                    //IsCheckDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CuttingRequestDate"]))) ? "" : Convert.ToDateTime(dt.Rows[0]["CuttingRequestDate"]).ToString("dd/MM/yyyy");
                                    IsCheckDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CuttingRequestDate"]))) ? "" : dt.Rows[0]["CuttingRequestDate"].ToString();
                                }
                            if (IsIssueComplete == "disabled")
                            {
                                IsDisable = "disabled";
                            }

                        }
                        //-------------------------------Edit By surendra on 14 Aug 2019 for check box "Raise Cutting Request Date",enable when some quantity of prior stage is avalable--
                        else
                        {
                            dsPriorStage = fabobj.GetPriorStage(Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"]), orderDetailID);
                            dtPriorStage = dsPriorStage.Tables[0];
                            //if (Convert.ToInt32( dtPriorStage.Rows[0]["PriorStageQty"])==0)
                            //    IsDisable = "disabled"; 
                            IsDisable = "disabled";
                            if (ApplicationHelper.LoggedInUser.UserData.Designation != Designation.BIPL_Production_PPC_Exec)
                            {
                                IsDisable = "disabled";

                            }

                        }

                        string idissuess = "chkfaissue" + OrderdetailID.ToString() + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        string idissuess1 = "IssueComplete" + OrderdetailID.ToString() + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString());

                        CutIssueComplete = idissuess;

                        //------------------------------End-------------------------------------------------------------------------------------------------

                        //sbcutwastage.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input CssClass = 'allownumericwithdecimal' onkeypress='return isNumberKey(event)' id='" + idissue + "'  value='" + val + "' " + IsIssueComplete + "   type='text' MaxLength = '6'  style='font-size: 9px;cursor:pointer;color:blue;width: 85% !important;text-align:center' class='test' title='' value='" + "" + "'  onchange='UpdateWastage(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + ")'/>" + "</td></tr>");
                        if (val == "0")
                        {
                            val = "";
                        }
                        sbcutwastage.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" + val + "</td></tr>");


                        string id = "chkfabCutreq" + OrderdetailID.ToString() + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        sbraisereq.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input  " + IsCheck + " id='" + id + "'    type='checkbox' " + IsDisable + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onchange='UpdateRaiseCuttingReq(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span style='position:relative;top:5px;'>" + IsCheckDate + "</span><span style='position:relative;top:5px;'>" + "&nbsp;&nbsp;" + UnitName + "&nbsp;&nbsp;" + "</span></td> </tr>");
                        if (IsAllUpdate == 1)
                        {
                            int isupdate = fabobj.UpdateFabricRaise(1, "CUTTINGRAISE", OrderdetailID, Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), dtTotalPrint.Rows[i]["FabricDetails"].ToString(), Unitid, userid);
                        }
                        DataTable dtr = fabobj.GetFabricIssueDetails("GETCHALLAN", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];
                        DataSet ds_extrastockissue = fabobj.GetFabricIssueDetails("Get_ExtraStockIssue_Challan_List", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString());
                        DataTable dt_extrastockissue = ds_extrastockissue.Tables[0];
                        DataTable dt_extrastockissue_table2 = ds_extrastockissue.Tables[1];

                        decimal valssss = 0;
                        if (dtr.Rows.Count > 0)
                        {
                            DataSet dss = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString());
                            DataTable dtrs = dss.Tables[1];


                            if (dtrs.Rows.Count > 0)
                            {

                                if (dtrs.Rows[0]["LastestStageVal"].ToString() != "0" && dtrs.Rows[0]["LastestStageVal"].ToString() != "" && dtr.Rows[0]["ThanCounts"].ToString() != "")
                                {
                                    valssss = Convert.ToDecimal(dtrs.Rows[0]["LastestStageVal"]);
                                    hdnavailableqty.Value = dtrs.Rows[0]["LastestStageVal"].ToString();
                                    //string s = Math.Round((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()))-((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString())) * (Convert.ToDecimal(dtTotalPrint.Rows[0]["Shrinkage"].ToString())) / Convert.ToDecimal(100))).ToString();
                                    //aa = ((Convert.ToDecimal(dtrs.Rows[0]["LastestStageVal"])) - ((Convert.ToDecimal(dtr.Rows[0]["ThanCounts"])) + Convert.ToDecimal(dtrs.Rows[0]["StockMoveQty"]))).ToString();

                                    // comented by sanjeev on 30/08/2021 due to ' , ' between intiger
                                    // aa = (Convert.ToDecimal(dtrs.Rows[0]["leftvalue"])).ToString("N0");
                                    aa = (Convert.ToDecimal(dtrs.Rows[0]["leftvalue"])).ToString();

                                    if (aa == "")
                                    {
                                        aa = "0";
                                    }

                                }

                                DataTable dtpendingqty_get_returnedchallanqty = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID).Tables[0];
                                if (Convert.ToBoolean(dtpendingqty_get_returnedchallanqty.Rows[0]["ReturnedChallanQty"].ToString() != "0"))
                                {
                                    stockcaption = stockcaption + "<br/><span style='color:gray'>Returned Qty: </span>" + Convert.ToDecimal(dtpendingqty_get_returnedchallanqty.Rows[0]["ReturnedChallanQty"].ToString()).ToString("N0");
                                    //strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + stockcaption + "</td></tr>");

                                }

                                if (Convert.ToBoolean(dt.Rows[0]["stockqty"].ToString() != "0"))
                                {
                                    stockcaption = stockcaption + "<br/><span style='color:gray'>Usable stock qty: </span>" + Convert.ToDecimal(dt.Rows[0]["stockqty"].ToString()).ToString("N0");
                                    //strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + stockcaption + "</td></tr>");

                                }
                                if (Convert.ToBoolean(dt.Rows[0]["DebitQty"].ToString() != "0"))
                                {
                                    stockcaption = stockcaption + "<br/><span style='color:gray'>Debit qty: </span>" + Convert.ToDecimal(dt.Rows[0]["DebitQty"].ToString()).ToString("N0");
                                    //strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + stockcaption + "</td></tr>");

                                }
                                if (Convert.ToBoolean(dt.Rows[0]["ResiShrinkQty"].ToString() != "0"))
                                {
                                    stockcaption = stockcaption + "<br/><span style='color:gray'>Resi Shrink Qty: </span>" + Convert.ToDecimal(dt.Rows[0]["ResiShrinkQty"].ToString()).ToString("N0");
                                    //strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + stockcaption + "</td></tr>");

                                }
                                //RajeevS 08052023
                                if (Convert.ToBoolean(dt.Rows[0]["ExtraWastageQty"].ToString() != "0"))
                                {
                                    stockcaption = stockcaption + "<br/><span style='color:gray'>Ext Wastage Qty: </span>" + Convert.ToDecimal(dt.Rows[0]["ExtraWastageQty"].ToString()).ToString("N0");
                                    //strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + stockcaption + "</td></tr>");

                                }
                                //RajeevS 08052023
                                strstock.Append("</table>");
                                //if (Convert.ToBoolean(dt.Rows[0]["Particulartext"].ToString() != ""))
                                //{
                                //    stockcaption = stockcaption + "Par. " + "&apos;" + dt.Rows[0]["Particulartext"].ToString() + "&apos;";

                                //}
                                qtyleft.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<a  style='vertical-align:middle;cursor:pointer;color:blue;position: relative;top:3px;right:2px' title='Move Quantity'  onclick='MoveQty(" + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'>" + aa + "</td> </tr>");
                            }
                            else
                            {
                                qtyleft.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "" + "</td> </tr>");
                            }
                            //if (i == 0)
                            //{
                            string TDBdisabled = "";
                            TDBdisabled = (dtTotalPrint.Rows[i]["FabricDetails"].ToString().ToLower() == "TBD".ToLower() ? "style='display: none;'" : "");
                            if (IssueRequestedDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                            {

                                DataTable dtpendingqty_get = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID).Tables[0];
                                decimal pendingqty_get = (dtpendingqty_get.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty_get.Rows[0]["TotalPendingQty"].ToString()) : 0);
                                if (valssss > 0)
                                {


                                    string ViewChllan = "";
                                    string ViewStockIssuedChallan = "";

                                    if (dtr.Rows.Count > 0)
                                    {
                                        ViewChllan = "<a  style='vertical-align:middle;cursor:pointer;' title='View send challan History' onclick='ShowAllSupplier(" + "&apos;" + CutIssueComplete.ToString() + "&apos;" + "," + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'><img src='../../images/viewicon.png' style='width: 19px;' /></a>";
                                    }
                                    if (dt_extrastockissue.Rows.Count > 0)
                                    {
                                        ViewStockIssuedChallan = "<a  style='vertical-align:middle;cursor:pointer;' title='View Stock Issued Challan History' onclick='ShowStockIssuedChallan(" + "&apos;" + CutIssueComplete.ToString() + "&apos;" + "," + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'><img src='../../images/viewicon.png' style='width: 19px;' /></a>";
                                    }

                                    sbchallan.AppendFormat("<tr class='challanIssuTo'>" +
                                       "<td  class='process' style='border-bottom: 1px solid #999;'>" + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;' title='update send challan number' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + hdnavailableqty.Value + ")'></a>" + "<a  style='vertical-align:middle;cursor:pointer;position: relative;top:3px;right:13px' title='Create New Challan'  onclick='ShowSupplierChallanScreenSendNEW(" + "&apos;" + dtrs.Rows[0]["IsCompleteIssue"].ToString() + "&apos;" + "," + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dtrs.Rows[0]["CanMakeNewChallan"].ToString() + ")'><img src='../../images/edit.png' style='position:relative;top:-3px;' /></a><span style='position:relative;left:23px;'>" + ViewChllan + "</span></td></tr>");

                                    if (Convert.ToInt32(dt_extrastockissue_table2.Rows[0]["RemainingQty"]) > 0)
                                    {
                                        sbextrastockissue.AppendFormat("<tr class='challanIssuTo'>" +
                                             "<td  class='process' style='border-bottom: 1px solid #999;border-right: 1px solid #999'>" + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;'"
                                              + "title='Update Stock Issued Challan' onclick='ShowExtraStockIssue(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + hdnavailableqty.Value + "&apos;" + "ExtraStockIssue" + "&apos;" + ")'></a>" + "<a  style='vertical-align:middle;cursor:pointer;position: relative;top:3px;right:13px' title='Create new Challan From Stock Qty.' onclick='ShowExtraStockIssueNew(" + "&apos;" + dtrs.Rows[0]["IsSettlementDone"].ToString() + "&apos;" + "," + "&apos;" + dtrs.Rows[0]["IsCompleteIssue"].ToString() + "&apos;" + "," + "&apos;" + "ExtraStockIssue" + "&apos;" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + "1" + ")'><img src='../../images/edit.png' style='position:relative;top:-3px;' /></a><span style='position:relative;left:23px;'>" + ViewStockIssuedChallan + "</span></td>" +
                                             "<td class='process' style='border-bottom: 1px solid #999;border-right:0px !important;text-align:right !important;'><span style='position:relative;right:6px;'>" +
                                             Convert.ToDecimal(dtr.Rows[0]["ThanCounts"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'>" + " " + dtr.Rows[0]["Unit"].ToString() + " " + "</span></span>" + " <span style='position:relative;right:5px;'>" + stockcaption + "</span></td></tr>");

                                    }
                                    else
                                    {
                                        sbextrastockissue.AppendFormat("<tr class='challanIssuTo'>" +
                                             "<td  class='process' style='border-bottom: 1px solid #999;border-right: 1px solid #999'>" + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;'"
                                              + "title='Update Stock Issued Challan' onclick='ShowExtraStockIssue(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + hdnavailableqty.Value + "&apos;" + "ExtraStockIssue" + "&apos;" + ")'></a>" + "<a  style='vertical-align:middle;cursor:pointer;position: relative;top:3px;right:13px' title='Create new Challan From Stock Qty.' onclick='ShowExtraStockIssueNew(" + "&apos;" + dtrs.Rows[0]["IsSettlementDone"].ToString() + "&apos;" + "," + "&apos;" + dtrs.Rows[0]["IsCompleteIssue"].ToString() + "&apos;" + "," + "&apos;" + "ExtraStockIssue" + "&apos;" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + "0" + ")'><img src='../../images/edit.png' style='position:relative;top:-3px;' /></a><span style='position:relative;left:23px;'>" + ViewStockIssuedChallan + "</span></td>" +
                                             "<td class='process' style='border-bottom: 1px solid #999;border-right:0px !important;text-align:right !important;'><span style='position:relative;right:6px;'>" +
                                             Convert.ToDecimal(dtr.Rows[0]["ThanCounts"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'>" + " " + dtr.Rows[0]["Unit"].ToString() + " " + "</span></span>" + " <span style='position:relative;right:5px;'>" + stockcaption + "</span></td></tr>");

                                    }



                                    IsChallanExits = "YES";
                                }
                                else
                                {
                                    sbchallan.AppendFormat("<tr class='challanIssuTo'>" +
                                          "<td  class='process' style='border-bottom: 1px solid #999;'>" + dtr.Rows[0]["ChallanNumber"].ToString() + " " + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;'></a>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;position: relative;top:3px;right:2px' title='Create New Challan'><img src='../../images/edit.png' style='position:relative;top:-2px;' /></a></td></tr>");


                                    sbextrastockissue.AppendFormat("<tr class='challanIssuTo'>" +
                                          "<td  class='process' style='border-bottom: 1px solid #999;border-right: 1px solid #999'>" + dtr.Rows[0]["ChallanNumber"].ToString() + " " + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;'></a>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;position: relative;top:3px;right:2px' title='Create new Challan From Stock Qty.'><img src='../../images/edit.png' style='position:relative;top:-2px;' /></a></td>" +
                                          "<td class='process' style='border-bottom: 1px solid #999;border-right:0px !important'>" +
                                            Convert.ToDecimal(dtr.Rows[0]["ThanCounts"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'>" + " " + dtr.Rows[0]["Unit"].ToString() + " " + "</span>" + " " + stockcaption + "</td></tr>");


                                    IsChallanExits = "YES";
                                }
                                stockcaption = "";
                            }
                            else
                            {

                                sbchallan.AppendFormat("<tr class='challanIssuTo'>" +
                                         "<td  class='process' style='border-bottom: 1px solid #999;'>" + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;'></a>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;position: relative;top:3px;right:2px' title='Create New Challan'  onclick='ShowSupplierChallanScreenSendNEW(" + "&apos;" + dtrs.Rows[0]["IsCompleteIssue"].ToString() + "&apos;" + "," + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dtrs.Rows[0]["CanMakeNewChallan"].ToString() + ")'><img src='../../images/edit.png' style='position:relative;top:-2px;' /></a></td></tr>");

                                if (Convert.ToInt32(dt_extrastockissue_table2.Rows[0]["RemainingQty"]) > 0)
                                {
                                    sbextrastockissue.AppendFormat("<tr class='challanIssuTo'>" +
                                             "<td  class='process' style='border-bottom: 1px solid #999;border-right: 1px solid #999;'>" + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;'></a>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;position: relative;top:3px;right:2px' title='Create new Challan From Stock Qty.'  onclick='ShowExtraStockIssueNew(" + "&apos;" + dtrs.Rows[0]["IsSettlementDone"].ToString() + "&apos;" + "," + "&apos;" + dtrs.Rows[0]["IsCompleteIssue"].ToString() + "&apos;" + "," + "&apos;" + "ExtraStockIssue" + "&apos;" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + "1" + ")'><img src='../../images/edit.png' style='position:relative;top:-2px;' /></a></td>" +
                                             "<td class='process' style='border-bottom: 1px solid #999;border-right:0px !important'>" +
                                                dtr.Rows[0]["ThanCounts"].ToString() + "<span style='color:gray;font-weight:600'>" + " " + dtr.Rows[0]["Unit"].ToString() + " " + "</span>" + " " + strstock + "</td></tr>");
                                }
                                else
                                {
                                    sbextrastockissue.AppendFormat("<tr class='challanIssuTo'>" +
                                             "<td  class='process' style='border-bottom: 1px solid #999;border-right: 1px solid #999;'>" + "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;'></a>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;position: relative;top:3px;right:2px' title='Create new Challan From Stock Qty.'  onclick='ShowExtraStockIssueNew(" + "&apos;" + dtrs.Rows[0]["IsSettlementDone"].ToString() + "&apos;" + "," + "&apos;" + dtrs.Rows[0]["IsCompleteIssue"].ToString() + "&apos;" + "," + "&apos;" + "ExtraStockIssue" + "&apos;" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + "0" + ")'><img src='../../images/edit.png' style='position:relative;top:-2px;' /></a></td>" +
                                             "<td class='process' style='border-bottom: 1px solid #999;border-right:0px !important'>" +
                                                dtr.Rows[0]["ThanCounts"].ToString() + "<span style='color:gray;font-weight:600'>" + " " + dtr.Rows[0]["Unit"].ToString() + " " + "</span>" + " " + strstock + "</td></tr>");
                                }


                                IsChallanExits = "YES";
                            }
                            //"<a  style='float:right;vertical-align:middle;cursor:pointer;position: relative;top:3px;right:2px' title='Create New Challan' onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + ")'><img src='../../images/edit.png' /></a>" + "</td></tr>");
                        }

                        else
                        {
                            IsChallanExits = "";
                            string TDBdisabled = "";
                            if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 7)
                            {
                                DataTable dtpendingqty_get_ano = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID).Tables[0];
                                bool bCutting_IssuePermsission = false;
                                bCutting_IssuePermsission = fabobj.IsCheckPermissionCuttingIssue(Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()));

                                decimal pendingqty_get = (dtpendingqty_get_ano.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty_get_ano.Rows[0]["TotalPendingQty"].ToString()) : 0);
                                TDBdisabled = (dtTotalPrint.Rows[i]["FabricDetails"].ToString().ToLower() == "TBD".ToLower() ? "style='display: none;'" : "");
                                if (bCutting_IssuePermsission == true)
                                {
                                    string ViewChllan = "";
                                    string ViewStockIssuedChallan = "";

                                    if (dtr.Rows.Count > 0)
                                    {
                                        ViewChllan = "<a  style='vertical-align:middle;cursor:pointer;' title='View send challan History' onclick='ShowAllSupplier(" + "&apos;" + CutIssueComplete.ToString() + "&apos;" + "," + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'><img src='../../images/viewicon.png' style='width: 19px;' /></a>";
                                    }
                                    if (dt_extrastockissue.Rows.Count > 0)
                                    {
                                        ViewStockIssuedChallan = "<a  style='vertical-align:middle;cursor:pointer;' title='View Stock Issued Challan History' onclick='ShowStockIssuedChallan(" + "&apos;" + CutIssueComplete.ToString() + "&apos;" + "," + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'><img src='../../images/viewicon.png' style='width: 19px;' /></a>";
                                    }
                                    sbchallan.AppendFormat("<tr class='EmptychallanIssuTo'>" +
                                   "<td  class='process' style='border-bottom: 1px solid #9999;border-right: 0px solid #9999;'>" +
                                   "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;position:relative;right:23px;' title='Create New Challan'  onclick='ShowSupplierChallanScreenSendNEW(" + "&apos;" + "False" + "&apos;" + "," + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + 1 + ")'><img src='../../images/edit.png' /></a>" + "<span style='position:relative;left:23px;'>" + ViewChllan + "</span></td><td class='process' style='border-bottom: 1px solid #9999;border-right:0px; border-left: 0px;'></td></tr>");

                                    if (Convert.ToInt32(dt_extrastockissue_table2.Rows[0]["RemainingQty"]) > 0)
                                    {
                                        sbextrastockissue.AppendFormat("<tr class='EmptychallanIssuTo'>" +
                                       "<td  class='process' style='border-bottom: 1px solid #9999;border-right: 0px solid #9999;'>" +
                                       "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;position:relative;right:23px;' title='Create new Challan From Stock Qty.'  onclick='ShowExtraStockIssueNew(" + "&apos;" + "False" + "&apos;" + "&apos;" + "ExtraStockIssue" + "&apos;" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + "1" + ")'><img src='../../images/edit.png' /></a>" + "<span style='position:relative;left:23px;'>" + ViewStockIssuedChallan + "</span></td><td class='process' style='border-bottom: 1px solid #9999;border-right:0px; border-left: 0px;'></td></tr>");
                                    }
                                    else
                                    {
                                        sbextrastockissue.AppendFormat("<tr class='EmptychallanIssuTo'>" +
                                      "<td  class='process' style='border-bottom: 1px solid #9999;border-right: 0px solid #9999;'>" +
                                      "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;position:relative;right:23px;' title='Create new Challan From Stock Qty.'  onclick='ShowExtraStockIssueNew(" + "&apos;" + "False" + "&apos;" + "&apos;" + "ExtraStockIssue" + "&apos;" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + "0" + ")'><img src='../../images/edit.png' /></a>" + "<span style='position:relative;left:23px;'>" + ViewStockIssuedChallan + "</span></td><td class='process' style='border-bottom: 1px solid #9999;border-right:0px; border-left: 0px;'></td></tr>");
                                    }



                                    qtyleft.AppendFormat("<tr><td class='process' style='style='width: 77px;border-bottom: 1px solid #9999;text-align:left;padding-left:4px'>" + "" + "</td> </tr>");
                                }
                                else
                                {
                                    sbchallan.AppendFormat("<tr class='EmptychallanIssuTo'>" +
                                    "<td  class='process' style='border-bottom: 1px solid #999;border-right: 0px solid #9999;'>" +
                                    "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;position:relative;right:23px;' title='Create New Challan'><img src='../../images/edit.png' /></a>" + "</td><td class='process' style='border-bottom: 1px solid #999;border-right:0px; border-left: 0px;'></td></tr>");


                                    sbextrastockissue.AppendFormat("<tr class='EmptychallanIssuTo'>" +
                                    "<td  class='process' style='border-bottom: 1px solid #999;border-right: 0px solid #9999;'>" +
                                    "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;position:relative;right:23px;' title='Create new Challan From Stock Qty.'><img src='../../images/edit.png' /></a>" + "</td><td class='process' style='border-bottom: 1px solid #999;border-right:0px; border-left: 0px;'></td></tr>");


                                    qtyleft.AppendFormat("<tr><td class='process' style='style='width: 77px;border-bottom: 1px solid #9999;text-align:left;padding-left:4px'>" + "" + "</td> </tr>");
                                }

                            }
                            else
                            {
                                sbchallan.AppendFormat("<tr>" +
                                    "<td  class='process' style='border-bottom: 1px solid #9999;border-right: 0px solid #9999'>" +
                                    "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;position:relative;right:23px;' title='Create New Challan'><img src='../../images/edit.png' /></a>" + "</td><td class='process' style='border-bottom: 1px solid #9999;border-right:0px; border-left: 0px;'></td></tr>");


                                sbextrastockissue.AppendFormat("<tr>" +
                                   "<td  class='process' style='border-bottom: 1px solid #9999;border-right: 0px solid #9999'>" +
                                   "<a " + " " + TDBdisabled + " " + " style='vertical-align:middle;cursor:pointer;position:relative;right:23px;' title='Create new Challan From Stock Qty.'><img src='../../images/edit.png' /></a>" + "</td><td class='process' style='border-bottom: 1px solid #9999;border-right:0px; border-left: 0px;'></td></tr>");



                                qtyleft.AppendFormat("<tr><td class='process' style='style='width: 77px;border-bottom: 1px solid #9999;text-align:left;padding-left:4px'>" + "" + "</td> </tr>");
                            }

                        }


                        /********************* Commented by Bharat on 08-jan-20********* 
                          if (dtr.Rows.Count > 0)
                          {
                              sbVIEWS.AppendFormat("<tr>" +
                                 "<td class='process' style='min-width: 30px;max-width: 30px;border-bottom: 1px solid #9999;text-align:center;padding-left:4px'>" +
                                 "<a  style='vertical-align:middle;cursor:pointer;' title='View send challan History' onclick='ShowAllSupplier(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;"+dtTotalPrint.Rows[i]["FabricDetails"].ToString()+"&apos;" + ")'><img src='../../images/viewicon.png' style='width: 19px;' /></a>"
                                 + "</td>"
                                 + "</tr>");
                          }
                          else {
                              sbVIEWS.AppendFormat("<tr>" +
                                "<td class='process' style='min-width: 30px;max-width: 30px;border-bottom: 1px solid #999;text-align:center;padding-left:4px'>" + "</td>"+ "</tr>");
                          }
                          */
                        /////////
                        DataTable dtpendingqty = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];
                        decimal pendingqty = (dtpendingqty.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty.Rows[0]["TotalPendingQty"].ToString()) : 0);
                        string ToltipTxt = "";
                        if (dtr.Rows.Count > 0)
                            ToltipTxt = "(" + dtTotalPrint.Rows[i]["Totalfebreq"].ToString() + "/(1-" + val + "%)) -" + dtr.Rows[0]["ThanCounts"].ToString();
                        else
                            ToltipTxt = "(" + dtTotalPrint.Rows[i]["Totalfebreq"].ToString() + "/(1-" + val + "%))";

                        if (pendingqty > 0)
                        {
                            //sbpendingQty.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #9999;'><div class='FabToltip'>" + pendingqty.ToString("N0") + "<span style='color:gray'> Mtr.</span><span class='TooltipTxt'>" + ToltipTxt + "</span></div></td>" + "</tr>");
                            sbpendingQty.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #9999;'><div class='FabToltip'>" + pendingqty.ToString("N0") + "<span style='color:gray'>" + " " + dtTotalPrint.Rows[i]["Unit"].ToString() + " " + "</span><span class='TooltipTxt'>" + ToltipTxt + "</span></div></td>" + "</tr>");
                        }
                        else
                        {
                            sbpendingQty.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;text-align:left;padding-left:4px'>" + "" + "</td>" + "</tr>");
                        }
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToString(dt.Rows[0]["IsCompleteIssue"]) == "True")
                            {
                                IsCheck_Issue = "checked";
                                IsDisable_issue = "disabled";
                                IsDisable_Settlement = "";
                                IsCheckDate_issue = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["IssueCompleteDate"]))) ? "" : dt.Rows[0]["IssueCompleteDate"].ToString();
                            }
                            if (Convert.ToString(dt.Rows[0]["IsSettlementDone"]) == "True")
                            {
                                IsSettlementDone = "checked";
                                IsDisable_Settlement = "disabled";
                                SettlementDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SettlementDate"]))) ? "" : dt.Rows[0]["SettlementDate"].ToString();
                            }
                            if (dtTotalPrint.Rows[i]["FabricDetails"].ToString().ToLower() == "TBD".ToLower())
                            {
                                IsDisable = "disabled";
                                IsDisable_issue = "disabled";
                            }
                            else if (IsIssueComplete == "disabled")
                            {
                                IsDisable = "disabled"; ;
                            }
                            else if (IsChallanExits == "")
                            {
                                IsDisable = "disabled";
                                IsDisable_issue = "disabled";
                            }

                        }
                        //string idissuess = "chkfaissue" + OrderdetailID.ToString() + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        ////if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 7)
                        ////{
                        ////    if (IsDisable == "disabled")
                        ////    {
                        ////        if (dt.Rows.Count > 0)
                        ////        {
                        ////            if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString() == "0"))
                        ////                sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "" + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/> <span style='position:relative;top:5px;'>" + IsCheckDate_issue + "</span></td> </tr>");
                        ////            else
                        ////                sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' " + IsDisable_issue + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "" + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span style='position:relative;top:5px;'>" + IsCheckDate_issue + "</span></td> </td> </tr>");
                        ////        }
                        ////        else
                        ////        {
                        ////            sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "" + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span style='position:relative;top:5px;'>" + IsCheckDate_issue + "</span></td> </td> </tr>");
                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        //if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString()=="0"))
                        ////        sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "" + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span style='position:relative;top:5px;'>" + IsCheckDate_issue + "</span></td> </td> </tr>");
                        ////    }
                        ////}
                        ////else
                        ////{
                        ////    sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "" + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/>" + IsCheckDate_issue + "</td> </tr>");
                        ////}

                        if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 7)
                        {
                            if (IsDisable == "disabled")
                            {

                                if (dt.Rows.Count > 0)
                                {
                                    //if (aa == "0")
                                    //{
                                    //    aa = "";
                                    //}
                                    if (aa == "")
                                    {
                                        aa = "0";
                                    }
                                    if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString() == "0"))
                                    {
                                        sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left!important;display: block;padding-left:4px;border-bottom: none;padding-top: 2px;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess1 + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='IssueComplete(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dt.Rows[0]["stockqty"].ToString() + "," + dt.Rows[0]["DebitQty"].ToString() + "," + "&apos;" + dt.Rows[0]["Particulartext"].ToString() + "&apos;" + ")' /> <span style='position:relative;top:-3px;'>" + IsCheckDate_issue + "</span>" + "" + "</td>     <td class='process' style='text-align:left!important;display:block;padding-left:4px;'>" + "<input  " + IsSettlementDone + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dt.Rows[0]["stockqty"].ToString() + "," + dt.Rows[0]["DebitQty"].ToString() + "," + "&apos;" + dt.Rows[0]["Particulartext"].ToString() + "&apos;" + ")' /> <span style='position:relative;top:-3px;'>" + SettlementDate + "</span>" + "" + "</td>   </tr>");
                                    }
                                    else
                                    {

                                        sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left!important;display: block;padding-left:4px;border-bottom: none;padding-top: 2px;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess1 + "'    type='checkbox' " + IsDisable_issue + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='IssueComplete(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dt.Rows[0]["stockqty"].ToString() + "," + dt.Rows[0]["DebitQty"].ToString() + "," + "&apos;" + dt.Rows[0]["Particulartext"].ToString() + "&apos;" + ")' /><span style='position:relative;top:-3px;'>" + IsCheckDate_issue + "</span>" + "" + "</td>   <td class='process' style='text-align:left!important;display:block;padding-left:4px;'>" + "<input  " + IsSettlementDone + " id='" + idissuess + "'    type='checkbox' " + IsDisable_Settlement + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dt.Rows[0]["stockqty"].ToString() + "," + dt.Rows[0]["DebitQty"].ToString() + "," + "&apos;" + dt.Rows[0]["Particulartext"].ToString() + "&apos;" + ")' /><span style='position:relative;top:-3px;'>" + SettlementDate + "</span>" + "" + "</td> </tr>");
                                    }
                                }
                                else
                                {
                                    sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left!important;display: block;padding-left:4px;border-bottom: none;padding-top: 2px;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess1 + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='IssueComplete(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + 0.ToString() + "," + 0.ToString() + "," + "&apos;" + "" + "&apos;" + ")' /><span style='position:relative;top:-3px;'>" + IsCheckDate_issue + "</span>" + "" + "</td>   <td class='process' style='text-align:left!important;display:block;padding-left:4px;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + 0.ToString() + "," + 0.ToString() + "," + "&apos;" + "" + "&apos;" + ")' /><span style='position:relative;top:-3px;'>" + IsCheckDate_issue + "</span>" + "" + "</td> </tr>");

                                }
                            }
                            else
                            {
                                //if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString()=="0"))
                                sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left!important;display: block;padding-left:4px;border-bottom: none;padding-top: 2px;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess1 + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='IssueComplete(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dt.Rows[0]["stockqty"].ToString() + "," + dt.Rows[0]["DebitQty"].ToString() + "," + "&apos;" + dt.Rows[0]["Particulartext"].ToString() + "&apos;" + ")' /><span style='position:relative;top:-3px;'>" + IsCheckDate_issue + "</span>" + "" + "</td>   <td class='process' style='text-align:left!important;display:block;padding-left:4px;'>" + "<input  " + IsSettlementDone + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + dt.Rows[0]["stockqty"].ToString() + "," + dt.Rows[0]["DebitQty"].ToString() + "," + "&apos;" + dt.Rows[0]["Particulartext"].ToString() + "&apos;" + ")' /><span style='position:relative;top:-3px;'>" + SettlementDate + "</span>" + "" + "</td> </tr>");

                            }
                        }
                        else
                        {
                            string stockqty = "";
                            string DebitQty = "";
                            string Particulartext = "";

                            if (dt.Rows.Count > 0)
                            {
                                stockqty = dt.Rows[0]["stockqty"].ToString();
                                DebitQty = dt.Rows[0]["DebitQty"].ToString();
                                Particulartext = dt.Rows[0]["Particulartext"].ToString();
                            }
                            sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left!important;display: block;padding-left:4px;border-bottom: none;padding-top: 2px;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess1 + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='IssueComplete(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + stockqty + "," + DebitQty + "," + "&apos;" + Particulartext + "&apos;" + ")' />" + IsCheckDate_issue + "</td>   <td class='process' style='text-align:left!important;display:block;padding-left:4px;'>" + "<input  " + IsSettlementDone + " id='" + idissuess + "'    type='checkbox' " + "  style='font-size: 9px;cursor:pointer;color:blue;' class='test' title='' value='" + "" + "' onclick='MoveQty(" + "this" + "," + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + stockqty + "," + DebitQty + "," + "&apos;" + Particulartext + "&apos;" + ")' />" + SettlementDate + "</td> </tr>");

                        }
                    }
                    sbcutwastage.Append("</table>");
                    e.Row.Cells[3].Text = sbcutwastage.ToString();

                    sbraisereq.Append("</table>");
                    e.Row.Cells[8].Text = sbraisereq.ToString();

                    sbchallan.Append("</table>");
                    e.Row.Cells[10].Text = sbchallan.ToString();

                    sbextrastockissue.Append("</table>");
                    e.Row.Cells[11].Text = sbextrastockissue.ToString();

                    //sbVIEWS.Append("</table>");
                    //e.Row.Cells[11].Text = sbVIEWS.ToString();

                    sbpendingQty.Append("</table>");
                    e.Row.Cells[9].Text = sbpendingQty.ToString();

                    sbissuecomplete.Append("</table>");
                    e.Row.Cells[13].Text = sbissuecomplete.ToString();

                    qtyleft.Append("</table>");
                    e.Row.Cells[14].Text = qtyleft.ToString();

                }
                if (dtTotalPrint.Rows.Count > 0)
                {
                    DataSet d1 = new DataSet();
                    DataTable dt = new DataTable();

                    System.Text.StringBuilder sbfabTotalsec = new System.Text.StringBuilder();
                    System.Text.StringBuilder s1 = new System.Text.StringBuilder();
                    System.Text.StringBuilder s2 = new System.Text.StringBuilder();

                    sbfabTotalsec.Append("<table id='data' style='width:100%;'cellspacing='0' cellpadding='0'>");
                    s1.Append("<table id='data' style='width:100%;'cellspacing='0' cellpadding='0'>");
                    s2.Append("<table id='data' style='width:100%;'cellspacing='0' cellpadding='0'>");



                    for (int i = 0; i < Convert.ToInt32(dtFabric.Rows[0]["maxseqnumber"].ToString()); i++)
                    {
                        string res = "";
                        string S1with = "";
                        string S2inhouse = "";

                        if (dtTotalPrint.Rows[i]["Totalfebreq"].ToString() != "")
                        {
                            if (Convert.ToDouble(dtTotalPrint.Rows[i]["Totalfebreq"].ToString()) > 0)
                            {
                                //res = Convert.ToDouble(dtTotalPrint.Rows[i]["Totalfebreq"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'> Mtr.</span>";
                                res = Convert.ToDouble(dtTotalPrint.Rows[i]["Totalfebreq"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'>" + " " + dtTotalPrint.Rows[i]["Unit"].ToString() + " " + "</span>";
                                d1 = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString());
                                if (d1.Tables[0].Rows.Count > 0)
                                {
                                    dt = d1.Tables[0];
                                    if (dt.Rows[0]["CutWidth"].ToString() != "0" && dt.Rows[0]["CutWidth"].ToString() != "")
                                    {
                                        S1with = Convert.ToDecimal(dt.Rows[0]["CutWidth"].ToString()).ToString("N0");
                                    }
                                }
                                if (d1.Tables[1].Rows.Count > 0)
                                {
                                    dt = d1.Tables[1];
                                    if (dt.Rows[0]["LastestStageVal"].ToString() != "0" && dt.Rows[0]["LastestStageVal"].ToString() != "")
                                    {
                                        //string s = Math.Round((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()))-((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString())) * (Convert.ToDecimal(dtTotalPrint.Rows[0]["Shrinkage"].ToString())) / Convert.ToDecimal(100))).ToString();
                                        //string aa= Math.Round((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()))-((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString())))
                                        //S2inhouse = Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()).ToString("N0") + " <span style='color:gray;font-weight:600'> Mtr.</span>";
                                        S2inhouse = Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()).ToString("N0") + " <span style='color:gray;font-weight:600'>" + " " + dt.Rows[0]["Unit"].ToString() + " " + "</span>";
                                        if (Convert.ToBoolean(dtTotalPrint.Rows[0]["Shrinkage"].ToString() != ""))
                                        {
                                            // if (Convert.ToBoolean(dtTotalPrint.Rows[0]["Shrinkage"].ToString() != "0"))
                                            //{
                                            // S2inhouse = S2inhouse + " " + "<br/>" + "<span style='color:black'> "  + "<span style='color:black'> " + dtTotalPrint.Rows[0]["cutwas"].ToString() + "</span>";
                                            //   S2inhouse = S2inhouse + " " + "<br/>" + "<span style='color:black'> ";
                                            //  }
                                        }
                                    }


                                }
                            }
                        }

                        sbfabTotalsec.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" + res + "</td></tr>");
                        s1.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" + S1with + "</td></tr>");
                        s2.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" + S2inhouse + "</td></tr>");

                    }
                    sbfabTotalsec.Append("</table>");
                    s1.Append("</table>");
                    s2.Append("</table>");

                    e.Row.Cells[5].Text = sbfabTotalsec.ToString();
                    e.Row.Cells[6].Text = s1.ToString();
                    e.Row.Cells[7].Text = s2.ToString();
                }
            }
            //UnitName = "";
            //Unitid = -1;
        }
        protected void grdfabric_DataBound(object sender, EventArgs e)
        {
            for (int i = grdfabric.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdfabric.Rows[i];
                GridViewRow previousRow = grdfabric.Rows[i - 1];

                Label lblstylenumber = (Label)row.Cells[0].FindControl("lblstylenumber");
                Label lblPreviouslblstylenumber = (Label)previousRow.Cells[0].FindControl("lblstylenumber");

                if (lblstylenumber.Text == lblPreviouslblstylenumber.Text)
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

                Label lblserial = (Label)row.Cells[0].FindControl("lblserial");
                Label lblPreviouslblserial = (Label)previousRow.Cells[0].FindControl("lblserial");

                if (lblserial.Text == lblPreviouslblserial.Text)
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
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
            //  HiddenField HiddenField = (HiddenField)row.Cells[0].FindControl("hdnOrderdetailID");
            //  HiddenField lblPreviousHiddenField = (HiddenField)previousRow.Cells[0].FindControl("hdnOrderdetailID");

            //  if (HiddenField.Value == lblPreviousHiddenField.Value)
            //  {
            //    if (previousRow.Cells[2].RowSpan == 0)
            //    {
            //      if (row.Cells[2].RowSpan == 0)
            //      {
            //        previousRow.Cells[2].RowSpan += 2;
            //      }
            //      else
            //      {
            //        previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
            //      }
            //      row.Cells[2].Visible = false;
            //    }
            //  }
            //}
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            if (hdnfabricqtyid.Value != "")
            {
                int FabQtyID = Convert.ToInt32(hdnfabricqtyid.Value);
                string FabricDetails = hdnfabricdetails.Value;
                int StockQty = Convert.ToInt32(txtmoveqty.Text == "" ? "0" : txtmoveqty.Text);
                int OrderDetailsID = Convert.ToInt32(hdnorderdetailsID.Value);

                int EntredDebitStockQty = Convert.ToInt32(txtmovetodebit.Text == "" ? "0" : txtmovetodebit.Text);
                int EntredResiShrinkQty = Convert.ToInt32(txtResiShrinkQty.Text == "" ? "0" : txtResiShrinkQty.Text);
                int EntredExtraWastageQty = Convert.ToInt32(txtExtraWastageQty.Text == "" ? "0" : txtExtraWastageQty.Text);
                int ActualQty = Convert.ToInt32(hdnstaockqty.Value);

                string particular = txtparticular.Text;

                if (ActualQty <= (StockQty + EntredDebitStockQty + EntredResiShrinkQty + EntredExtraWastageQty))
                {
                    int issave = fabobj.UpdateFabricRaise(1, "CutIssueSettlement", OrderDetailsID, FabQtyID, FabricDetails, Unitid, userid);
                }
                int issave1 = fabobj.UpdateStockQty("UPDATESTOACKQTY", FabQtyID, FabricDetails, StockQty, OrderDetailsID, EntredDebitStockQty, particular, EntredResiShrinkQty, EntredExtraWastageQty);
            }

            IsAllUpdate = 0;
            AnyIraise = 0;
            BindGrd();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrd();
        }
        protected void btnqtysubmit_Click(object sender, EventArgs e)
        {

            Response.Redirect(Request.RawUrl);
        }
        protected void chkraisecuttingall_CheckedChanged(Object sender, EventArgs args)
        {
            CheckBox linkedItem = sender as CheckBox;

            DropDownList ddlFactoryUnit = ((DropDownList)this.grdfabric.HeaderRow.FindControl("ddlFactoryUnit"));
            Unitid = Convert.ToInt32(ddlFactoryUnit.SelectedItem.Value);
            UnitName = ddlFactoryUnit.SelectedItem.Text;
            if (linkedItem.Checked)
            {
                IsAllUpdate = 1;
                BindGrd();
                BindGrd();
            }

            //Boolean itemState = linkedItem.Checked;
            //Int32 itemId = Int32.Parse(linkedItem.InputAttributes["Value"].ToString());
            //DataAccessLayer.UpdateLinkedItem(m_linkingItem, Utilities.GetCategoryItemFromId(itemId), itemState);
        }
    }
}