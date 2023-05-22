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
    public partial class FITsReport : BaseUserControl
    {
        DataSet dsFITs = new DataSet();

        #region Properties

        public int ClientId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["clientId"]))
                {
                    return Convert.ToInt32(Request.QueryString["clientId"]);
                }
                else
                {
                    return Convert.ToInt32(ddlClients.SelectedValue);
                }
            }
        }

        public int DepartmentId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["deptId"]))
                {
                    return Convert.ToInt32(Request.QueryString["deptId"]);
                }
                else
                {
                    return Convert.ToInt32(hiddenDeptId.Value);
                }
            }
        }

        public DateTime SuggestedFitsDate
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["suggestedFitsDate"]))
                {
                    return Convert.ToDateTime(Request.QueryString["suggestedFitsDate"]);
                }
                else
                {
                    return Convert.ToDateTime(DateHelper.ParseDate(txtSuggestedFitsDate.Text).Value);
                }
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            hiddenClientId.Value = Convert.ToString(this.ClientId);
            hiddenDeptId.Value = Convert.ToString(this.DepartmentId);
            hdnSuggestedFitsDate.Value = Convert.ToString(this.txtSuggestedFitsDate);

            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            int TotalRowCount = 0;

            dsFITs = this.ReportControllerInstance.GetFITsReport(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, this.ClientId, this.DepartmentId, this.SuggestedFitsDate);
            grdFITs.DataSource = dsFITs;
            grdFITs.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

            PageHelper.RemoveJScriptVariable("selectedDeptID");
            PageHelper.AddJScriptVariable("selectedDeptID", Convert.ToInt32(hiddenDeptId.Value));

        }

        protected void grdFITs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            if (dsFITs.Tables.Count > 0)
            {
                if (dsFITs.Tables[0].Rows.Count > 0)
                {
                    int result;
                    string Fabric1Details = dsFITs.Tables[0].Rows[e.Row.RowIndex]["Fabric1Details"].ToString();
                    var Fab1Det = Fabric1Details.Trim().Split(' ');
                    if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                    {
                        Fabric1Details = "PRD:" + Fabric1Details;
                        result = 0;
                    }

                    if (!string.IsNullOrEmpty(Fabric1Details))
                        ((Label)e.Row.FindControl("lblFabric1Details")).Text = " : " + Fabric1Details;

                    string Fabric2Details = dsFITs.Tables[0].Rows[e.Row.RowIndex]["Fabric2Details"].ToString();

                    var Fab2Det = Fabric2Details.Trim().Split(' ');
                    if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                    {
                        Fabric2Details = "PRD:" + Fabric2Details;
                        result = 0;
                    }

                    if (!string.IsNullOrEmpty(Fabric2Details))
                        ((Label)e.Row.FindControl("lblFabric2Details")).Text = " : " + Fabric2Details;

                    string Fabric3Details = dsFITs.Tables[0].Rows[e.Row.RowIndex]["Fabric3Details"].ToString();

                    var Fab3Det = Fabric3Details.Trim().Split(' ');
                    if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                    {
                        Fabric3Details = "PRD:" + Fabric3Details;
                        result = 0;
                    }

                    if (!string.IsNullOrEmpty(Fabric3Details))
                        ((Label)e.Row.FindControl("lblFabric3Details")).Text = " : " + Fabric3Details;

                    string Fabric4Details = dsFITs.Tables[0].Rows[e.Row.RowIndex]["Fabric4Details"].ToString();

                    var Fab4Det = Fabric4Details.Trim().Split(' ');
                    if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                    {
                        Fabric4Details = "PRD:" + Fabric4Details;
                        result = 0;
                    }

                    if (!string.IsNullOrEmpty(Fabric4Details))
                        ((Label)e.Row.FindControl("lblFabric4Details")).Text = " : " + Fabric4Details;

                    HiddenField hdnSerial = e.Row.FindControl("hdnSerial") as HiddenField;

                    (hdnSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(Convert.ToDateTime(dsFITs.Tables[0].Rows[e.Row.RowIndex]["ExFactory"])));

                    HyperLink hypfitstatus = new HyperLink();

                    string fitsStyleNumber = string.Empty;
                    if (dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"] != DBNull.Value)
                    {
                        fitsStyleNumber = dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"].ToString();
                    }
                    else if (dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCode"] != DBNull.Value)
                    {
                        fitsStyleNumber = dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCode"].ToString();
                    }

                    if (fitsStyleNumber != string.Empty)
                    {
                        if (dsFITs.Tables[0].Rows[e.Row.RowIndex]["CommentsSentFor"] != DBNull.Value && !string.IsNullOrEmpty(dsFITs.Tables[0].Rows[e.Row.RowIndex]["CommentsSentFor"].ToString()))
                        {
                            bool isSTCApproved = ((dsFITs.Tables[0].Rows[e.Row.RowIndex]["StcApproved"]) == DBNull.Value) ? false : Convert.ToBoolean(dsFITs.Tables[0].Rows[e.Row.RowIndex]["StcApproved"]);

                            if (isSTCApproved)
                            {
                                hypfitstatus.Text = "STC Approved On " + (((dsFITs.Tables[0].Rows[e.Row.RowIndex]["SealDate"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((dsFITs.Tables[0].Rows[e.Row.RowIndex]["SealDate"])).ToString("dd MMM yy (ddd)"));
                                hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + fitsStyleNumber + "','" + dsFITs.Tables[0].Rows[e.Row.RowIndex]["ClientDepartmentID"] + "','" + dsFITs.Tables[0].Rows[e.Row.RowIndex]["OrderDetailID"] + "')");
                            }
                            else
                            {
                                DateTime AckDate = ((dsFITs.Tables[0].Rows[e.Row.RowIndex]["AckDate"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime((dsFITs.Tables[0].Rows[e.Row.RowIndex]["AckDate"]));
                                string plannedFor = (((dsFITs.Tables[0].Rows[e.Row.RowIndex]["PlanningFor"]) == DBNull.Value) ? string.Empty : Convert.ToString((dsFITs.Tables[0].Rows[e.Row.RowIndex]["PlanningFor"])));

                                if (plannedFor.IndexOf("STC") > -1)
                                    hypfitstatus.Text = plannedFor + " Requested on " + (((dsFITs.Tables[0].Rows[e.Row.RowIndex]["FITRequestedOn"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((dsFITs.Tables[0].Rows[e.Row.RowIndex]["FITRequestedOn"])).ToString("dd MMM yy (ddd)"));
                                else if (AckDate == DateTime.MinValue)
                                    hypfitstatus.Text = (((dsFITs.Tables[0].Rows[e.Row.RowIndex]["CommentsSentFor"]) == DBNull.Value) ? string.Empty : Convert.ToString((dsFITs.Tables[0].Rows[e.Row.RowIndex]["CommentsSentFor"]))) + " Comment Received on " + (((dsFITs.Tables[0].Rows[e.Row.RowIndex]["FITRequestedOn"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((dsFITs.Tables[0].Rows[e.Row.RowIndex]["FITRequestedOn"])).ToString("dd MMM yy (ddd)"));
                                else
                                    hypfitstatus.Text = plannedFor + " Sent on " + (((dsFITs.Tables[0].Rows[e.Row.RowIndex]["AckDate"]) == DBNull.Value) ? DateTime.MinValue.ToString("dd MMM yy (ddd)") : Convert.ToDateTime((dsFITs.Tables[0].Rows[e.Row.RowIndex]["AckDate"])).ToString("dd MMM yy (ddd)"));
                            }
                        }
                        else
                        {
                            hypfitstatus.Text = "Show Sealer Pending Form";
                            hypfitstatus.Target = "SealingForm";

                            int deptId = 0;
                            int oDeptID;
                            if (dsFITs.Tables[0].Rows[e.Row.RowIndex]["DepartmentID"] != DBNull.Value)
                            {
                                if (int.TryParse(dsFITs.Tables[0].Rows[e.Row.RowIndex]["DepartmentID"].ToString(), out oDeptID))
                                    deptId = oDeptID;
                            }

                            if (dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"] == DBNull.Value || dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"].ToString() == string.Empty || dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"].ToString().Length < 5)
                            {
                                if (deptId == 0)
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleNumber"].ToString().Substring(3, 5);
                                else
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleNumber"].ToString().Substring(3, 5) + "&DeptId=" + deptId;

                            }
                            else if (dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"].ToString().Length >= 5)
                            {
                                if (deptId == 0)
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"].ToString();
                                else
                                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + dsFITs.Tables[0].Rows[e.Row.RowIndex]["StyleCodeVersion"].ToString() + "&DeptID=" + deptId;

                            }
                        }

                        e.Row.Cells[12].Controls.Add(hypfitstatus);
                    }

                    HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;
                    (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(Convert.ToDateTime(dsFITs.Tables[0].Rows[e.Row.RowIndex]["ExFactory"]), Convert.ToDateTime(dsFITs.Tables[0].Rows[e.Row.RowIndex]["DC"]), Convert.ToInt32(dsFITs.Tables[0].Rows[e.Row.RowIndex]["Mode"])));

                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }
    }
}