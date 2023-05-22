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


namespace iKandi.Web
{
    public partial class PendingBuyerOrderForms : BaseUserControl
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
            }
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            ds = this.ReportControllerInstance.GetPendingBuyerOrderForms(Convert.ToInt32(ddlClients.SelectedValue));

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"] != DBNull.Value)
                        (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(Convert.ToDateTime(ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"])));

                    HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;
                    if ((ds.Tables[0].Rows[e.Row.DataItemIndex]["Mode"] != DBNull.Value) && (ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"] != DBNull.Value) && (ds.Tables[0].Rows[e.Row.DataItemIndex]["DC"] != DBNull.Value))
                        (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(Convert.ToDateTime(ds.Tables[0].Rows[e.Row.DataItemIndex]["ExFactory"]), Convert.ToDateTime(ds.Tables[0].Rows[e.Row.DataItemIndex]["DC"]), Convert.ToInt32(ds.Tables[0].Rows[e.Row.DataItemIndex]["Mode"])));

                    HiddenField lblStatus = e.Row.FindControl("lblStatus") as HiddenField;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StatusModeID"] != DBNull.Value)
                        (lblStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(Convert.ToInt32(ds.Tables[0].Rows[e.Row.DataItemIndex]["StatusModeID"])));

                    string fitStyleNumber = string.Empty;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"] != DBNull.Value)
                    {
                        fitStyleNumber = ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString();
                    }
                    else if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCode"] != DBNull.Value)
                    {
                        fitStyleNumber = ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCode"].ToString().PadLeft(5, '0');
                    }

                    if (fitStyleNumber != string.Empty)
                    {
                        HyperLink hypfitstatus = new HyperLink();

                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["CommentsSentFor"] != DBNull.Value || !string.IsNullOrEmpty(ds.Tables[0].Rows[e.Row.DataItemIndex]["CommentsSentFor"].ToString()))
                        {
                            bool isSTCApproved = ((ds.Tables[0].Rows[e.Row.DataItemIndex]["StcApproved"]) == DBNull.Value) ? false : Convert.ToBoolean(ds.Tables[0].Rows[e.Row.DataItemIndex]["StcApproved"]);

                            if (isSTCApproved)
                            {
                                hypfitstatus.Text = "STC Approved On " + (((ds.Tables[0].Rows[e.Row.DataItemIndex]["SealDate"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((ds.Tables[0].Rows[e.Row.DataItemIndex]["SealDate"])).ToString("dd MMM yy (ddd)"));
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
                            }

                            hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + fitStyleNumber + "','" + ds.Tables[0].Rows[e.Row.DataItemIndex]["ClientDepartmentID"] + "','" + ds.Tables[0].Rows[e.Row.DataItemIndex]["Id"] + "')");
                        }
                        else
                        {
                            hypfitstatus.Text = "Show Sealer Pending Form";
                            hypfitstatus.Target = "SealingForm";

                            int departmentID = 0;
                            int oDeptId;
                            if (ds.Tables[0].Rows[e.Row.DataItemIndex]["ClientDepartmentID"] != DBNull.Value)
                            {
                                if (int.TryParse(ds.Tables[0].Rows[e.Row.DataItemIndex]["ClientDepartmentID"].ToString(), out oDeptId))
                                {
                                    departmentID = oDeptId;
                                }
                            }

                            if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"] == DBNull.Value || ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString() == string.Empty || ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString().Length < 5)
                            {
                                if (departmentID == 0)
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleNumber"].ToString().Substring(3, 5);
                                else
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleNumber"].ToString().Substring(3, 5) + "&DeptId=" + departmentID;
                            }
                            else if (ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString().Length >= 5)
                            {
                                if (departmentID == 0)
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString();
                                else
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + ds.Tables[0].Rows[e.Row.DataItemIndex]["StyleCodeVersion"].ToString() + "&DeptId=" + departmentID;
                            }
                        }

                        Label lblFitStatus = e.Row.FindControl("lblFitStatus") as Label;
                        lblFitStatus.Controls.Add(hypfitstatus);
                    }

                    Label lblFileExist = e.Row.FindControl("lblFileExist") as Label;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["File"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["File"].ToString().Trim() != string.Empty && ds.Tables[0].Rows[e.Row.DataItemIndex]["File"].ToString().Trim().ToUpper() != "NULL")
                    {
                        (lblFileExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }

                    Label lblLineNOExist = e.Row.FindControl("lblLineNOExist") as Label;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["LineItemNumber"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["LineItemNumber"].ToString().Trim() != string.Empty && ds.Tables[0].Rows[e.Row.DataItemIndex]["LineItemNumber"].ToString().Trim().ToUpper() != "NULL")
                    {
                        (lblLineNOExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }

                    Label lblContractNoExist = e.Row.FindControl("lblContractNoExist") as Label;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["ContractNumber"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["ContractNumber"].ToString().Trim() != string.Empty && ds.Tables[0].Rows[e.Row.DataItemIndex]["ContractNumber"].ToString().Trim().ToUpper() != "NULL")
                    {
                        (lblContractNoExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }

                    Label lblFabricDetailsExist = e.Row.FindControl("lblFabricDetailsExist") as Label;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric4"] != DBNull.Value && !string.IsNullOrEmpty(ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric4"].ToString()))
                    {
                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric4Details"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric4Details"].ToString().Trim() != string.Empty && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric4Details"].ToString().Trim().ToUpper() != "NULL")
                            (lblFabricDetailsExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }
                    else if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric3"] != DBNull.Value && !string.IsNullOrEmpty(ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric3"].ToString()))
                    {
                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric3Details"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric3Details"].ToString().Trim() != string.Empty && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric3Details"].ToString().Trim().ToUpper() != "NULL")
                            (lblFabricDetailsExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }
                    else if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric2"] != DBNull.Value && !string.IsNullOrEmpty(ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric2"].ToString()))
                    {
                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric2Details"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric2Details"].ToString().Trim() != string.Empty && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric2Details"].ToString().Trim().ToUpper() != "NULL")
                            (lblFabricDetailsExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }
                    else if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric1"] != DBNull.Value && !string.IsNullOrEmpty(ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric1"].ToString()))
                    {
                        if (ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric1Details"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric1Details"].ToString().Trim() != string.Empty && ds.Tables[0].Rows[e.Row.DataItemIndex]["Fabric1Details"].ToString().Trim().ToUpper() != "NULL")
                            (lblFabricDetailsExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }

                    Label lblBiplPriceExistExist = e.Row.FindControl("lblBiplPriceExistExist") as Label;
                    double result1;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["BIPLPrice"] == DBNull.Value || ds.Tables[0].Rows[e.Row.DataItemIndex]["BIPLPrice"].ToString().Trim() == string.Empty || Double.TryParse(ds.Tables[0].Rows[e.Row.DataItemIndex]["BIPLPrice"].ToString().Trim(), out result1) == false)
                    {
                        (lblBiplPriceExistExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else
                    {
                        (lblBiplPriceExistExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }

                    Label lblIkandiPriceExistExist = e.Row.FindControl("lblIkandiPriceExistExist") as Label;
                    double result2;
                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["iKandiPrice"] == DBNull.Value || ds.Tables[0].Rows[e.Row.DataItemIndex]["iKandiPrice"].ToString().Trim() == string.Empty || Double.TryParse(ds.Tables[0].Rows[e.Row.DataItemIndex]["iKandiPrice"].ToString().Trim(), out result2) == false)
                    {
                        (lblIkandiPriceExistExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else
                    {
                        (lblIkandiPriceExistExist.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01CC01");
                    }

                    int sign = -1;
                    string currencySign = "&pound;";

                    if (ds.Tables[0].Rows[e.Row.DataItemIndex]["ConvertTo"] != DBNull.Value && ds.Tables[0].Rows[e.Row.DataItemIndex]["ConvertTo"].ToString() != string.Empty)
                    {
                        sign = Convert.ToInt32(ds.Tables[0].Rows[e.Row.DataItemIndex]["ConvertTo"]);
                    }
                    currencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(sign);

                    Label lblPriceSign = e.Row.FindControl("lblPriceSign") as Label;
                    Label lblPrice = e.Row.FindControl("lblPrice") as Label;

                    if (lblPrice.Text != string.Empty)
                    {
                        lblPriceSign.Text = currencySign;
                    }
                }
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }
    }
}