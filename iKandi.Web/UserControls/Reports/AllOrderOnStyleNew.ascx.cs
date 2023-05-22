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
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports
{
    public partial class AllOrderOnStyleNew : BaseUserControl
    {
        DataSet ds = new DataSet();
        public string styleNumber;
        public string orderIdList = "";
        public bool allOrders = true;


        #region Properties

       
        # endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            int inrStyleId = Convert.ToInt32(Session["StyleId"]);
            BindControls(inrStyleId);
            //string oo = hdnstyleId.Value;
        }

        public void BindControls(int inrStyleId)
        {
            if (!String.IsNullOrEmpty(styleNumber))
            {

                divPrint.Visible = false;
            }


            // ds = this.ReportControllerInstance.GetAllOrdersOnStyle(this.StyleNumber, this.OrderIDList, false);
            ds = this.ReportControllerInstance.GetAllOrdersOnStyleNew(inrStyleId);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                int i = e.Row.Cells.Count;
                CheckBox chk9 = new CheckBox();
                chk9.ID = "id9";
                chk9.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                              chk9.ClientID
                                          );
                Label lbl9 = new Label();
                lbl9.ID = "lbl9";
                lbl9.Text = "Is Update";
                e.Row.Cells[e.Row.Cells.Count - 1].Controls.Add(chk9);
                e.Row.Cells[e.Row.Cells.Count - 1].Controls.Add(lbl9);
            }
            int Quantity = 0;
            int cutPercent = 0;
            int stitchingPercent = 0;
            int packingPercent = 0;


            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    Label lblSerialNumber = e.Row.FindControl("lblSerialNumber") as Label;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["SerialNumber"] != DBNull.Value)
                    {
                        lblSerialNumber.Text = ds.Tables[0].Rows[e.Row.DataItemIndex]["SerialNumber"].ToString();
                    }
                    else
                    {
                        lblSerialNumber.Text = string.Empty;
                    }

                    HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"] != DBNull.Value)
                    {
                        (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(Convert.ToDateTime(ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"])));
                    }

                    HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;
                    if ((ds.Tables[0].Rows[e.Row.DataItemIndex]["Mode"] != DBNull.Value) && (ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"] != DBNull.Value) && (ds.Tables[0].Rows[e.Row.DataItemIndex]["DC"] != DBNull.Value))
                        (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(Convert.ToDateTime(ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"]), Convert.ToDateTime(ds.Tables[0].Rows[e.Row.DataItemIndex]["DC"]), Convert.ToInt32(ds.Tables[0].Rows[e.Row.DataItemIndex]["Mode"])));

                    HiddenField lblStatus = e.Row.FindControl("lblStatus") as HiddenField;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StatusModeID"] != DBNull.Value)
                        (lblStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(Convert.ToInt32(ds.Tables[0].Rows[e.Row.DataItemIndex]["StatusModeID"])));

                    HyperLink hypfitstatus = new HyperLink();

                    string fitsStyleNumber = string.Empty;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"] != DBNull.Value)
                    {
                        fitsStyleNumber = ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString();
                    }
                    else if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCode"] != DBNull.Value)
                    {
                        fitsStyleNumber = ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCode"].ToString().PadLeft(5, '0');
                    }

                    if (fitsStyleNumber != string.Empty)
                    {
                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["CommentsSentFor"] != DBNull.Value && !string.IsNullOrEmpty(ds.Tables[0].Rows[e.Row.DataItemIndex]["CommentsSentFor"].ToString()))
                        {
                            bool isSTCApproved = ((ds.Tables[0].Rows[e.Row.DataItemIndex]["StcApproved"]) == DBNull.Value) ? false : Convert.ToBoolean(ds.Tables[0].Rows[e.Row.DataItemIndex]["StcApproved"]);

                            if (isSTCApproved)
                            {
                                hypfitstatus.Text = "STC Approved On " + (((ds.Tables[0].Rows[e.Row.DataItemIndex]["SealDate"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((ds.Tables[0].Rows[e.Row.DataItemIndex]["SealDate"])).ToString("dd MMM yy (ddd)"));
                                hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + fitsStyleNumber + "','" + ds.Tables[0].Rows[e.Row.DataItemIndex]["ClientDepartmentID"] + "','" + ds.Tables[0].Rows[e.Row.DataItemIndex]["Id"] + "')");


                            }
                            else
                            {
                                DateTime AckDate = ((ds.Tables[0].Rows[e.Row.DataItemIndex]["AckDate"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime((ds.Tables[0].Rows[e.Row.DataItemIndex]["AckDate"]));
                                string plannedFor = (((ds.Tables[0].Rows[e.Row.DataItemIndex]["PlanningFor"]) == DBNull.Value) ? string.Empty : Convert.ToString((ds.Tables[0].Rows[e.Row.DataItemIndex]["PlanningFor"])));

                                if (plannedFor.IndexOf("STC") > -1)
                                    hypfitstatus.Text = plannedFor + " Requested on " + (((ds.Tables[0].Rows[e.Row.DataItemIndex]["FITRequestedOn"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((ds.Tables[0].Rows[e.Row.DataItemIndex]["FITRequestedOn"])).ToString("dd MMM yy (ddd)"));
                                else if (AckDate == DateTime.MinValue)
                                    hypfitstatus.Text = (((ds.Tables[0].Rows[e.Row.DataItemIndex]["CommentsSentFor"]) == DBNull.Value) ? string.Empty : Convert.ToString((ds.Tables[0].Rows[e.Row.DataItemIndex]["CommentsSentFor"]))) + " Comment Received on " + (((ds.Tables[0].Rows[e.Row.DataItemIndex]["FITRequestedOn"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((ds.Tables[0].Rows[e.Row.DataItemIndex]["FITRequestedOn"])).ToString("dd MMM yy (ddd)"));
                                else
                                    hypfitstatus.Text = plannedFor + " Sent on " + (((ds.Tables[0].Rows[e.Row.DataItemIndex]["AckDate"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((ds.Tables[0].Rows[e.Row.DataItemIndex]["AckDate"])).ToString("dd MMM yy (ddd)"));

                                hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + fitsStyleNumber + "','" + ds.Tables[0].Rows[e.Row.DataItemIndex]["ClientDepartmentID"] + "','" + ds.Tables[0].Rows[e.Row.DataItemIndex]["Id"] + "')");
                            }
                        }
                        else
                        {
                            hypfitstatus.Text = "Show Sealer Pending Form";
                            hypfitstatus.Target = "SealingForm";

                            int deptID = 0;
                            int oDeptID;
                            if (ds.Tables[0].Rows[e.Row.DataItemIndex]["ClientDepartmentID"] != DBNull.Value)
                            {
                                if (int.TryParse(ds.Tables[0].Rows[e.Row.DataItemIndex]["ClientDepartmentID"].ToString(), out oDeptID))
                                    deptID = oDeptID;
                            }

                            if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"] == DBNull.Value || ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString() == string.Empty || ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString().Length < 5)
                            {
                                if (deptID == 0)
                                    hypfitstatus.NavigateUrl = "~/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleNumber"].ToString().Substring(3, 5);
                                else
                                    hypfitstatus.NavigateUrl = "~/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleNumber"].ToString().Substring(3, 5) + "&DeptId=" + deptID;
                            }
                            else if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString().Length >= 5)
                            {
                                if (deptID == 0)
                                    hypfitstatus.NavigateUrl = "~/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString();
                                else
                                    hypfitstatus.NavigateUrl = "~/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString() + "&DeptId=" + deptID;
                            }
                        }

                        e.Row.Cells[10].Controls.Add(hypfitstatus);
                    }

                    Label lblCut = e.Row.FindControl("lblCut") as Label;
                    Label lblStitch = e.Row.FindControl("lblStitch") as Label;
                    Label lblPacked = e.Row.FindControl("lblPacked") as Label;


                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Quantity"] != DBNull.Value)
                    {
                        Quantity = Convert.ToInt32(ds.Tables[0].Rows[e.Row.DataItemIndex]["Quantity"]);
                    }

                    if (Quantity > 0)
                    {
                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["PcsCut"] != DBNull.Value)
                        {
                            cutPercent = Convert.ToInt32((Convert.ToDouble(ds.Tables[0].Rows[e.Row.DataItemIndex]["PcsCut"]) / Quantity) * 100);
                        }

                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["PcsStitched"] != DBNull.Value)
                        {
                            stitchingPercent = Convert.ToInt32((Convert.ToDouble(ds.Tables[0].Rows[e.Row.DataItemIndex]["PcsStitched"]) / Quantity) * 100);
                        }

                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["PcsPacked"] != DBNull.Value)
                        {
                            packingPercent = Convert.ToInt32((Convert.ToDouble(ds.Tables[0].Rows[e.Row.DataItemIndex]["PcsPacked"]) / Quantity) * 100);
                        }
                    }

                    lblCut.Text = cutPercent.ToString("N0");
                    lblStitch.Text = stitchingPercent.ToString("N0");
                    lblPacked.Text = packingPercent.ToString("N0");

                    Label lblBiplPriceSymbal = e.Row.FindControl("lblBiplPriceSymbal") as Label;
                    Label lblIkandiPriceSymble = e.Row.FindControl("lblIkandiPriceSymble") as Label;
                    int symbalType = -1;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["ConvertTo"] != DBNull.Value && Convert.ToString(ds.Tables[0].Rows[e.Row.DataItemIndex]["ConvertTo"]) != string.Empty)
                    {
                        symbalType = Convert.ToInt32(ds.Tables[0].Rows[e.Row.DataItemIndex]["ConvertTo"]);
                    }
                    lblBiplPriceSymbal.Text = Constants.GetCurrencySymbalByCurrencyType(symbalType);
                    lblIkandiPriceSymble.Text = Constants.GetCurrencySymbalByCurrencyType(symbalType);
                }
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // BindControls();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            //BindControls();
        }


    }
}