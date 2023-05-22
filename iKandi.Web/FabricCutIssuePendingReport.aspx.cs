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

namespace iKandi.Web
{
    public partial class FabricCutIssuePendingReport : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = fabobj.GetFabricIssueDetails_Report("BASIC",1,"");
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdfabric.DataSource = dt;
                grdfabric.DataBind();
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int ioption=0;
            if (rbReuest.Checked)
            {
                ioption = 1;
            }
            else if (rbRequestPending.Checked)
            {
                ioption = 2;
            }
            else if (rbIssueRequest.Checked)
            {
                ioption = 3;
            }
            else if (rbIssueComplete.Checked)
            {
                ioption = 4;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = fabobj.GetFabricIssueDetails_Report("BASIC", ioption,txtsearchkeyswords.Text.Trim()); 
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdfabric.DataSource = dt;
                grdfabric.DataBind();
            }
        }
        protected void grdfabric_RowDatabound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.Header)
            {
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcontract = (Label)e.Row.FindControl("lblcontract");
                HiddenField hdnOrderdetailID = (HiddenField)e.Row.FindControl("hdnOrderdetailID");
                HiddenField hdnfabricqualityid = (HiddenField)e.Row.FindControl("hdnfabricqualityid");
                HiddenField hdnfabricdetails = (HiddenField)e.Row.FindControl("hdnfabricdetails");
                Label lblavailableqty = (Label)e.Row.FindControl("lblavailableqty");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Literal lblRequiredQtyIncludeCutWastage = (Literal)e.Row.FindControl("lblRequiredQtyIncludeCutWastage");
                Label lblcutwastage = (Label)e.Row.FindControl("lblcutwastage");
                Label lblreuiredqty = (Label)e.Row.FindControl("lblreuiredqty");
                
                if (lblcontract.Text.Length > 21)
                {
                    lblcontract.Attributes.Add("data-title", lblcontract.Text);
                    lblcontract.Text = lblcontract.Text.Substring(0, 20) + "...";
                }
                DataSet ds = fabobj.GetFabricIssueDetails_report("CUTWIDTH", Convert.ToInt32(hdnOrderdetailID.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnOrderdetailID.Value), "", hdnfabricdetails.Value);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string Unit = dt.Rows[0]["Unit"].ToString();
                    if (dt.Rows[0]["LastestStageVal"].ToString() != "")
                    {
                        lblavailableqty.Text = Convert.ToDecimal(dt.Rows[0]["LastestStageVal"].ToString()).ToString("N0") + " <span style='color:gray;font-weight:600'> " + Unit + "</span>";
                    }
                    if (dt.Rows[0]["CutWidth"].ToString() != "")
                    {
                        lblwidth.Text = Convert.ToDecimal(dt.Rows[0]["CutWidth"].ToString()).ToString("N0");
                        if (Convert.ToDecimal(dt.Rows[0]["CutWidth"].ToString()) <= 0)
                        {
                            lblwidth.Text = "";
                        }
                    }
                    lblreuiredqty.Text = lblreuiredqty.Text + " <span style='color:gray;font-weight:600'> " + Unit + "</span>.";
                }

                DataTable dtpendingqty = fabobj.GetFabricIssueDetails_report("GETPENDINGQTY", Convert.ToInt32(hdnOrderdetailID.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnOrderdetailID.Value), "", hdnfabricdetails.Value).Tables[0];
                decimal pendingqty = (dtpendingqty.Rows[0]["TotalPendingQty"].ToString() != "" ? Convert.ToDecimal(dtpendingqty.Rows[0]["TotalPendingQty"].ToString()) : 0);
                string Units = dtpendingqty.Rows[0]["Unit"].ToString();
                if (pendingqty > 0)
                {

                    lblRequiredQtyIncludeCutWastage.Text = Convert.ToDecimal(pendingqty.ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'> " + Units + "</span>.";
                }
                DataTable dtr = fabobj.GetFabricIssueDetails_report("GETCHALLAN", Convert.ToInt32(hdnOrderdetailID.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnOrderdetailID.Value), "", hdnfabricdetails.Value).Tables[0];

                if (dtr.Rows.Count > 0)
                {
                    System.Text.StringBuilder sbchallan = new System.Text.StringBuilder();
                    sbchallan.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");

                    for (int s = 0; s < dtr.Rows.Count; s++)
                    {
                        string ViewChllan = "<a  style='vertical-align:middle;cursor:pointer;' title='View send challan History' onclick='ShowSupplierChallanScreenSend(" + Convert.ToInt32(dtr.Rows[s]["Challan_Id"].ToString()) + ", " + Convert.ToInt32(dtr.Rows[s]["OrderDetailID"].ToString()) + "," + Convert.ToInt32(dtr.Rows[s]["Fabric_QualityID"].ToString()) + "," + "&apos;" + dtr.Rows[s]["FabricDetails"].ToString() + "&apos;" + ",0)'>" + dtr.Rows[s]["ChallanNumber"].ToString() + "</a>";
                        sbchallan.AppendFormat("<tr class='challanIssuTo'>" +
                           "<td class='process' style='width: 79px;border-bottom: 1px solid #999;color:blue;'>" + ViewChllan + " " + "</td>" +
                           "<td class='process' style='width: 75px;border-bottom: 1px solid #999;'>" + Convert.ToDecimal(dtr.Rows[s]["ThanCounts"].ToString()).ToString("N0") + "<span style='color:gray;font-weight:600'> Mtr.</span>" + "</td>" +
                            "<td class='process' style='width: 77px;border-bottom: 1px solid #999;border-right:0px !important'>" + dtr.Rows[s]["ChallanDate"].ToString().ToString().Replace("-", " ") + "</td></tr>");
                    }
                    sbchallan.Append("</table>");
                    e.Row.Cells[10].Text = sbchallan.ToString();

                }
                string val = "";
                DataTable dtw = new DataTable();
                dtw = fabobj.GetFabricIssueDetails_report("GETCUTWASTAGE", Convert.ToInt32(hdnOrderdetailID.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnfabricqualityid.Value), Convert.ToInt32(hdnOrderdetailID.Value), "", hdnfabricdetails.Value).Tables[0];
                
                if (lblcutwastage.Text == "0")
                {
                    lblcutwastage.Text = "";
                }
                string stockcaption = "";
                System.Text.StringBuilder strstock = new System.Text.StringBuilder();
                strstock.Append("<table id='data' style='width:100%'cellspacing='0' cellpadding='0'>");

                if (dtw.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtw.Rows[0]["stockqty"].ToString() != "0"))
                    {
                        stockcaption = "<br/><span style='color:gray'>Usable stock qty: </span>" + Convert.ToDecimal(dtw.Rows[0]["stockqty"].ToString()).ToString("N0") + "<br/>";                        
                    }
                    if (Convert.ToBoolean(dtw.Rows[0]["DebitQty"].ToString() != "0"))
                    {
                        stockcaption = stockcaption + "<span style='color:gray'>Debit qty: </span>" + Convert.ToDecimal(dtw.Rows[0]["DebitQty"].ToString()).ToString("N0");
                    }
                    strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;text-align:right !important;padding-right:4px'>" + stockcaption + "</td></tr>");
                }
                else
                {
                    strstock.AppendFormat("<tr>" + "<td class='process' style='border-bottom: 1px solid #999;'>" + "" + "</td></tr>");
                }
                strstock.Append("</table>");
                e.Row.Cells[13].Text = strstock.ToString();
                 
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
                Label lblcontract = (Label)row.Cells[0].FindControl("lblcontract");
                Label lblPreviouslblcontract = (Label)previousRow.Cells[0].FindControl("lblcontract");

                //if (lblcontract.Text == lblPreviouslblcontract.Text)
                //{
                //    if (previousRow.Cells[2].RowSpan == 0)
                //    {
                //        if (row.Cells[2].RowSpan == 0)
                //        {
                //            previousRow.Cells[2].RowSpan += 2;
                //        }
                //        else
                //        {
                //            previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
                //        }
                //        row.Cells[2].Visible = false;
                //    }
                //}
                //Label lblcutwastage = (Label)row.Cells[0].FindControl("lblcutwastage");
                //Label lblPreviouslblcutwastage = (Label)previousRow.Cells[0].FindControl("lblcutwastage");

                //if (lblcutwastage.Text == lblPreviouslblcutwastage.Text)
                //{
                //    if (previousRow.Cells[3].RowSpan == 0)
                //    {
                //        if (row.Cells[3].RowSpan == 0)
                //        {
                //            previousRow.Cells[3].RowSpan += 2;
                //        }
                //        else
                //        {
                //            previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
                //        }
                //        row.Cells[3].Visible = false;
                //    }
                //} 
            }

        }
    }
}