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
    public partial class FabricCutIssuePendingReport : System.Web.UI.Page
    {
        public static int Quality_ID
        {
            get;
            set;
        }
        public static int orderDetailID
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

        
       
        // end
        FabricController fabobj = new FabricController();
        string SearchString;
        bool IsRequestPending = false;
        bool IsIssueRequest = false;
        bool IsCompleteIssue = false;
        public string GetUnitName(string po)
        {
            DataTable dt = fabobj.GetUnitName();

            DataRow[] dv = dt.Select("PO_Number = '" + po + "'");

            return dv[0]["UnitsNames"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!Page.IsPostBack)
            {
                BindGrd();
            }
        }
        public void GetQueryString()
        {
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
        }
        public void BindGrd()
        {
            IsRequestPending = rbRequestPending.Checked;
            IsIssueRequest = rbIssueRequest.Checked;
            IsCompleteIssue = rbIssueComplete.Checked;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = fabobj.GetFabricIssueDetails("BASIC", -1, -1, Quality_ID, orderDetailID, txtsearchkeyswords.Text.Trim(),"", IsRequestPending, IsIssueRequest, IsCompleteIssue);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdfabric.DataSource = dt;
                grdfabric.DataBind();
            }
        }
        protected void grdfabric_RowDatabound(object sender, GridViewRowEventArgs e)
        {
           
            string IsIssueComplete = "";
           
            if (e.Row.RowType == DataControlRowType.Header)
            {
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = new DataSet();
                DataSet dsPriorStage = new DataSet();
                DataTable dtFabric = new DataTable();
                DataTable dtPrint = new DataTable();
                DataTable dtTotalPrint = new DataTable();
                DataTable dtPriorStage = new DataTable();
              
                CheckBox chkraise = (CheckBox)e.Row.FindControl("chkraise");
                HiddenField hdnavailableqty = (HiddenField)e.Row.FindControl("hdnavailableqty");

              
                int OrderdetailID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OderDetailID"));
              

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
                    //if (drs.Rows.Count > 0)
                    //{
                    //    string valToRe = drs.Rows[0]["totalreq"].ToString();
                    //    lbltotalrequest.Text = "Total Request:" + "<b style='color:blue;font-weight:500'>" + " " + valToRe + "</b>";

                    //    string valToPen = drs.Rows[0]["PendingIssueCom"].ToString();
                    //    lblpending.Text = "Total Pending Issue:" + "<b style='color:blue;font-weight:500'>" + " " + valToPen + "</b>";
                    //}
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
                        sbfab.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;text-align:left !important;padding-left:4px'><span style='color:blue !important;'>" + dtFabric.Rows[0]["Fabric" + (i + 1).ToString()].ToString() + "</span><span style='color:black;font-weight:600 !important'>/" + dtPrint.Rows[0]["Fabric_Details" + (i + 1).ToString()].ToString() + "</span>/" + dtPrint.Rows[0]["Avgs" + (i + 1).ToString()].ToString() + "</td></tr>");
                    }
                    sbfab.Append("</table>");
                    e.Row.Cells[4].Text = sbfab.ToString();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    System.Text.StringBuilder sbcutwastage = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbraisereq = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbchallan = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbVIEWS = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbpendingQty = new System.Text.StringBuilder();
                    System.Text.StringBuilder sbissuecomplete = new System.Text.StringBuilder();
                    System.Text.StringBuilder qtyleft = new System.Text.StringBuilder();
                    System.Text.StringBuilder strstock = new System.Text.StringBuilder();
                    //string vals = "";
                    sbcutwastage.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbraisereq.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbchallan.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbVIEWS.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbpendingQty.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    sbissuecomplete.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    qtyleft.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    strstock.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");
                    String IsChallanExits = "";
                    for (int i = 0; i < Convert.ToInt32(dtFabric.Rows[0]["maxseqnumber"].ToString()); i++)
                    {
                        string stockcaption = "";

                        IsIssueComplete = "";
                        DataTable dt = new DataTable();
                        dt = fabobj.GetFabricIssueDetails("GETCUTWASTAGE", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];
                        string val = "";
                        string IsCheck = "";
                        string IsCheckDate = "";
                        string IsDisable = "";

                        string IsCheck_Issue = "";
                        string IsCheckDate_issue = "";
                        string IsDisable_issue = "";
                        // IsIssueComplete = dt.Rows[0]["IsCompleteIssue"].ToString();
                        if (dtTotalPrint.Rows.Count > 0)
                        {
                            //val = dt.Rows[0]["CuttingWastage"].ToString();
                            val = dtTotalPrint.Rows[i]["cutwas"].ToString();
                        }

                        dt = fabobj.GetFabricIssueDetails("GETCUTWASTAGE", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dt.Rows[0]["stockqty"].ToString() != "0"))
                            {
                                  
                                stockcaption =  "<br/><span style='color:gray'>Usable stock qty: </span>" + Convert.ToDecimal(dt.Rows[0]["stockqty"].ToString()).ToString("N0") + "<br/>";
                                //strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + stockcaption + "</td></tr>");
                            }
                            
                            if (Convert.ToBoolean(dt.Rows[0]["DebitQty"].ToString() != "0"))
                            {
                                stockcaption =   stockcaption+"<span style='color:gray'>Debit qty: </span>" + Convert.ToDecimal(dt.Rows[0]["DebitQty"].ToString()).ToString("N0");                               
                            }
                            strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + stockcaption + "</td></tr>");
                        }
                        else
                        {
                            strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + "" + "</td></tr>");
                        }

                       
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
                                    IsCheck = "checked";
                                    IsDisable = "disabled";
                                    //IsCheckDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CuttingRequestDate"]))) ? "" : Convert.ToDateTime(dt.Rows[0]["CuttingRequestDate"]).ToString("dd/MM/yyyy");
                                    IsCheckDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CuttingRequestDate"]))) ? "" : dt.Rows[0]["CuttingRequestDate"].ToString().Replace("-"," ");
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
                            if (Convert.ToInt32(dtPriorStage.Rows[0]["PriorStageQty"]) == 0)
                                IsDisable = "disabled";
                            if (ApplicationHelper.LoggedInUser.UserData.Designation != Designation.BIPL_Production_PPC_Exec)
                            {
                                IsDisable = "disabled";

                            }

                        }
                        //------------------------------End-------------------------------------------------------------------------------------------------

                        //sbcutwastage.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input CssClass = 'allownumericwithdecimal' onkeypress='return isNumberKey(event)' id='" + idissue + "'  value='" + val + "' " + IsIssueComplete + "   type='text' MaxLength = '6'  style='font-size: 9px;cursor:pointer;color:blue;width: 85% !important;text-align:center' class='test' title='' value='" + "" + "'  onchange='UpdateWastage(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + ")'/>" + "</td></tr>");
                        sbcutwastage.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" + val + "</td></tr>");


                        string id = "chkfabCutreq" + OrderdetailID.ToString() + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        sbraisereq.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<input  " + IsCheck + " id='" + id + "'    type='checkbox' " + IsDisable + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onchange='UpdateRaiseCuttingReq(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span style='position:relative;top:3px;'>" + IsCheckDate.Replace("-", " ") + "</span></td> </tr>");

                        DataTable dtr = fabobj.GetFabricIssueDetails("GETCHALLAN", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];
                        decimal valssss = 0;
                        if (dtr.Rows.Count > 0)
                        {
                            DataSet dss = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString());
                            DataTable dtrs = dss.Tables[1];
                            //if (dtrs.Rows.Count > 0)
                            //{
                                string aa = "";
                                if (dtrs.Rows[0]["LastestStageVal"].ToString() != "0" && dtrs.Rows[0]["LastestStageVal"].ToString() != "" && dtr.Rows[0]["ThanCounts"].ToString() != "")
                                {
                                    valssss = Convert.ToDecimal(dtrs.Rows[0]["LastestStageVal"]);
                                    hdnavailableqty.Value = dtrs.Rows[0]["LastestStageVal"].ToString();
                                    //string s = Math.Round((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()))-((Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString())) * (Convert.ToDecimal(dtTotalPrint.Rows[0]["Shrinkage"].ToString())) / Convert.ToDecimal(100))).ToString();
                                    aa = ((Convert.ToDecimal(dtrs.Rows[0]["LastestStageVal"])) - ((Convert.ToDecimal(dtr.Rows[0]["ThanCounts"])) + Convert.ToDecimal(dtrs.Rows[0]["StockMoveQty"]))).ToString();
                                    if (aa == "0")
                                    {
                                        aa = "";
                                    }

                                }

                                qtyleft.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px'>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;color:blue;position: relative;top:3px;right:2px' title='Move Quantity'  onclick='MoveQty(" + aa + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'>" + aa + "</td> </tr>");
                           
                                DataTable dtpendingqty_get = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID).Tables[0];
                                decimal pendingqty_get = (dtpendingqty_get.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty_get.Rows[0]["TotalPendingQty"].ToString()) : 0);
                                //if (valssss > 0)
                                //{
                                for (int s = 0; s < dtr.Rows.Count; s++)
                                {
                                    sbchallan.AppendFormat("<tr class='challanIssuTo'>" +

                                       "<td class='process' style='width: 79px;border-bottom: 1px solid #999;color:blue;'>" + dtr.Rows[s]["ChallanNumber"].ToString() + " " +
                                        //"<a  style='vertical-align:middle;cursor:pointer;' title='update send challan number' onclick='ShowSupplierChallanScreenSend(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + "," + hdnavailableqty.Value + ")'></a>" + "<a  style='float:right;vertical-align:middle;cursor:pointer;position: relative;top:3px;right:2px' title='Create new send challan number'  onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + ")'><img src='../../images/edit.png' style='position:relative;top:-2px;' /></a>
                                       "</td>" +
                                       "<td class='process' style='width: 75px;border-bottom: 1px solid #999;'>" +

                                           //Convert.ToDecimal(dtr.Rows[s]["ThanCounts"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'> Mtr.</span>" + "</td>" +
                                            Convert.ToDecimal(dtr.Rows[s]["ThanCounts"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'>" + " "  + dtr.Rows[s]["Unit"].ToString() + " " +  "</span>" + "</td>" +
                                           "<td class='process' style='width: 77px;border-bottom: 1px solid #999;border-right:0px !important'>" +

                                        dtr.Rows[s]["ChallanDate"].ToString().ToString().Replace("-", " ") + "</td></tr>");
                                    IsChallanExits = "YES";
                                }

                                
                              
                        }

                        else
                        {
                            if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 7)
                            {
                                DataTable dtpendingqty_get_ano = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID).Tables[0];
                                bool bCutting_IssuePermsission = false;
                                bCutting_IssuePermsission = fabobj.IsCheckPermissionCuttingIssue(Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()));

                                decimal pendingqty_get = (dtpendingqty_get_ano.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty_get_ano.Rows[0]["TotalPendingQty"].ToString()) : 0);
                                if (bCutting_IssuePermsission == true)
                                {
                                    sbchallan.AppendFormat("<tr>" +
                                   "<td class='process' style='width: 77px;border-bottom: 1px solid #999;' colspan='3'>" +
                                   //"<a  style='float:right;vertical-align:middle;cursor:pointer;' title='Create new send challan number'  onclick='ShowSupplierChallanScreenSendNEW(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + ")'><img src='../../images/edit.png' /></a>" 
                                    "</td></tr>");

                                    qtyleft.AppendFormat("<tr><td class='process' style='style='width: 77px;border-bottom: 1px solid #9999;text-align:left;padding-left:4px'>" + "" + "</td> </tr>");
                                }
                                else
                                {
                                    sbchallan.AppendFormat("<tr>" +
                                    "<td class='process' style='width: 77px;border-bottom: 1px solid #999;' colspan='3'>" +
                                    //"<a  style='float:right;vertical-align:middle;cursor:pointer;' title='Create new send challan number'><img src='../../images/edit.png' /></a>" 
                                     "</td></tr>");

                                    qtyleft.AppendFormat("<tr><td class='process' style='style='width: 77px;border-bottom: 1px solid #9999;text-align:left;padding-left:4px'>" + "" + "</td> </tr>");
                                }

                            }
                            else
                            {
                                sbchallan.AppendFormat("<tr>" +
                                    "<td class='process' style='width: 77px;border-bottom: 1px solid #999;' colspan='3'>" +
                                   // "<a  style='float:right;vertical-align:middle;cursor:pointer;' title='Create new send challan number'><img src='../../images/edit.png' /></a>" 
                                     "</td></tr>");

                                qtyleft.AppendFormat("<tr><td class='process' style='style='width: 77px;border-bottom: 1px solid #9999;text-align:left;padding-left:4px'>" + "" + "</td> </tr>");
                            }

                        }


                        if (dtr.Rows.Count > 0)
                        {
                            sbVIEWS.AppendFormat("<tr>" +
                               "<td class='process' style='min-width: 30px;max-width: 30px;border-bottom: 1px solid #9999;text-align:center;padding-left:4px'>" +
                               "<a  style='vertical-align:middle;cursor:pointer;' title='View send challan History' onclick='ShowAllSupplier(" + -1 + "," + Convert.ToInt32(0) + "," + -1 + "," + "&apos;" + "" + "&apos;" + "," + "0" + "," + Convert.ToInt32(OrderdetailID) + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'><img src='../../images/viewicon.png' style='width: 19px;' /></a>"
                               + "</td>"
                               + "</tr>");
                        }
                        else
                        {
                            sbVIEWS.AppendFormat("<tr>" +
                              "<td class='process' style='min-width: 30px;max-width: 30px;border-bottom: 1px solid #999;text-align:center;padding-left:4px'>" + "</td>" + "</tr>");
                        }
                        DataTable dtpendingqty = fabobj.GetFabricIssueDetails("GETPENDINGQTY", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString()).Tables[0];
                        decimal pendingqty = (dtpendingqty.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty.Rows[0]["TotalPendingQty"].ToString()) : 0);
                        string Unit = dtpendingqty.Rows[0]["Unit"].ToString();
                        if (pendingqty > 0)
                        {

                            sbpendingQty.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #9999;'>" + Convert.ToDecimal(pendingqty.ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'> " + Unit + "</span>" + "</td>" + "</tr>");
                        }
                        else
                        {
                            sbpendingQty.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;text-align:left;padding-left:4px'>" + "" + "</td>" + "</tr>");
                        }
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dt.Rows[0]["IssueCompleteDate"].ToString() != ""))
                                if (Convert.ToBoolean(dt.Rows[0]["IssueCompleteDate"].ToString() != "0"))
                                {
                                    IsCheck_Issue = "checked";
                                    IsDisable_issue = "disabled";
                                    //IsCheckDate_issue = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["IssueCompleteDate"]))) ? "" : Convert.ToDateTime(dt.Rows[0]["IssueCompleteDate"]).ToString("dd/MM/yyyy");
                                    IsCheckDate_issue = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["IssueCompleteDate"]))) ? "" : dt.Rows[0]["IssueCompleteDate"].ToString().Replace("-"," ");
                                }
                            if (IsIssueComplete == "disabled")
                            {
                                IsDisable = "disabled"; ;
                            }
                            if (IsChallanExits == "")
                            {
                                IsDisable = "disabled";
                            }

                        }
                        string idissuess = "chkfaissue" + OrderdetailID.ToString() + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString());
                        if (ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID == 7)
                        {
                            if (IsDisable == "disabled")
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString() == "0"))
                                        sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px;border-bottom: 1px solid;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span class='chekboxissuedate'>" + IsCheckDate_issue + "</span></td> </tr>");
                                    else
                                        sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px;border-bottom: 1px solid;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' " + IsDisable_issue + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span class='chekboxissuedate'>" + IsCheckDate_issue + "</span></td> </tr>");
                                }
                                else
                                {
                                    sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px;border-bottom: 1px solid;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/><span class='chekboxissuedate'>" + IsCheckDate_issue + "</span></td> </tr>");
                                }

                            }
                            else
                            {
                                //if (Convert.ToBoolean(dt.Rows[0]["IsCuttingRequest"].ToString()=="0"))
                                sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px;border-bottom: 1px solid;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/>" + IsCheckDate_issue + "</td> </tr>");

                            }

                        }
                        else

                            sbissuecomplete.AppendFormat("<tr><td class='process' style='text-align:left;padding-left:4px;border-bottom: 1px solid;'>" + "<input  " + IsCheck_Issue + " id='" + idissuess + "'    type='checkbox' disabled " + "  style='font-size: 9px;cursor:pointer;color:blue;width: 15% !important;float:left' class='test' title='' value='" + "" + "' onchange='UpdateIssueComplete(this," + OrderdetailID + "," + Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()) + "," + "&apos;" + dtTotalPrint.Rows[i]["FabricDetails"].ToString() + "&apos;" + ")'/>" + IsCheckDate_issue + "</td> </tr>");

                      

                    }
                    sbcutwastage.Append("</table>");
                    e.Row.Cells[3].Text = sbcutwastage.ToString();

                    sbraisereq.Append("</table>");
                    e.Row.Cells[8].Text = sbraisereq.ToString();

                    sbchallan.Append("</table>");
                    e.Row.Cells[10].Text = sbchallan.ToString();

                    sbVIEWS.Append("</table>");
                    e.Row.Cells[11].Text = sbVIEWS.ToString();

                    sbpendingQty.Append("</table>");
                    e.Row.Cells[9].Text = sbpendingQty.ToString();

                    sbissuecomplete.Append("</table>");
                    e.Row.Cells[12].Text = sbissuecomplete.ToString();

                    //qtyleft.Append("</table>");
                    //e.Row.Cells[13].Text = qtyleft.ToString();

                    strstock.Append("</table>");
                    e.Row.Cells[13].Text = strstock.ToString();
                   
                    
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
                                res = Convert.ToDouble(Convert.ToDecimal(dtTotalPrint.Rows[i]["Totalfebreq"].ToString()).ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'> " + dtTotalPrint.Rows[i]["Unit"].ToString() + "</span>";
                              
                                d1 = fabobj.GetFabricIssueDetails("CUTWIDTH", Convert.ToInt32(OrderdetailID), Convert.ToInt32(dtTotalPrint.Rows[i]["Fabric_Quality_DetailsID"].ToString()), Quality_ID, orderDetailID, "", dtTotalPrint.Rows[i]["FabricDetails"].ToString());
                                if (d1.Tables[0].Rows.Count > 0)
                                {
                                    dt = d1.Tables[0];
                                    if (dt.Rows[0]["CutWidth"].ToString() != "0" && dt.Rows[0]["CutWidth"].ToString() != "")
                                    {
                                        //S1with = dt.Rows[0]["CutWidth"].ToString();
                                        S1with = Convert.ToDecimal(dt.Rows[0]["CutWidth"].ToString()).ToString("N0");
                                    }
                                }
                                if (d1.Tables[1].Rows.Count > 0)
                                {
                                    dt = d1.Tables[1];
                                    if (dt.Rows[0]["LastestStageVal"].ToString() != "0" && dt.Rows[0]["LastestStageVal"].ToString() != "")
                                    {
                                       
                                        string Unit = dt.Rows[0]["Unit"].ToString();
                                        S2inhouse = Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()).ToString("N0") + " <span style='color:gray;font-weight:600'> " + Unit + "</span>";
                                        if (Convert.ToBoolean(dtTotalPrint.Rows[0]["Shrinkage"].ToString() != ""))
                                        {
                                            
                                        }
                                    }

                                }
                            }
                        }
                 
                        sbfabTotalsec.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" + res + "</td></tr>");
                        s1.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" + S1with + "</td></tr>");
                        s2.AppendFormat("<tr>" + "<td class='process' style='width: 77px;border-bottom: 1px solid #999;'>" +   S2inhouse + "</td></tr>");

                    }
                    sbfabTotalsec.Append("</table>");
                    s1.Append("</table>");
                    s2.Append("</table>");

                    e.Row.Cells[5].Text = sbfabTotalsec.ToString();
                    e.Row.Cells[6].Text = s1.ToString();
                    e.Row.Cells[7].Text = s2.ToString();
                }
            }
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
           
        }
       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchString = txtsearchkeyswords.Text.Trim();
            BindGrd();
        }

        protected void rbReuest_OnCheckedChanged(object sender, EventArgs e)
        {

            BindGrd();
        }
        protected void rbRequestPending_OnCheckedChanged(object sender, EventArgs e)
        {
           
            BindGrd();
        }

        protected void rbIssueRequest_OnCheckedChanged(object sender, EventArgs e)
        {

            BindGrd();
        }
        protected void rbIssueComplete_OnCheckedChanged(object sender, EventArgs e)
        {

            BindGrd();
        }
    }
}