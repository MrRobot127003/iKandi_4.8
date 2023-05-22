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

namespace iKandi.Web
{
    public partial class ManageOrderFitsInfoPopup : BaseUserControl
    {
        public string StyleNumber
        {
            get;
            set;

        }

        public string StyleNumberDesc
        {
            get
            {
                return (this.StyleNumber.Split(' ').Length > 1) ? this.StyleNumber.Split(' ')[0] : this.StyleNumber;
               
            }
        }

        public int DepartmentID
        {
            get;
            set;

        }

        public int OrderDetailID
        {
            get;
            set;
        }

        public int StyleId
        {
            get;
            set;
        }
        public string StyleNo
        {
            get;
            set;
        }
        public string FitsStyle
        {
            get;
            set;
        }
           
        public int StrClientId
        {
            get; 
            set;
        }
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //fits.HRef = "/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + this.StyleNumber + "&DeptId=" + this.DepartmentID;

            fits.HRef = "/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=" + this.StyleId + "&stylenumber=" + this.StyleNo + "&FitsStyle=" + this.FitsStyle + "&ClientID=" + this.StrClientId + "&DeptId=" + this.DepartmentID + "&showFITSFORM="+"Yes";

            ds = this.OrderControllerInstance.ManageOrderGetFitsInfo(this.StyleNumber, this.DepartmentID, this.OrderDetailID);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataTable dt2 = dt.Clone();

                int i;

                foreach (DataRow row in dt.Rows)
                {
                    dt2.ImportRow(row);
                    dt2.ImportRow(row);
                }

                i = 0;

                if (dt2.Rows.Count > 0)
                {
                    DataRow[] dt2Rows = dt2.Select("", "FitsTrackID ASC");

                    foreach (DataRow row in dt2Rows)
                    {
                        if (row["SealDate"].ToString() != "")
                        {
                            if (Convert.ToDateTime(row["SealDate"]) != DateTime.MinValue)
                            {
                                lblSTCActual.Text = Convert.ToDateTime(row["SealDate"]).ToString("dd MMM yy (ddd)");

                            }
                        }
                        if (i % 2 == 0)
                        {
                            row["CommentsSentFor"] = row["CommentsSentFor"].ToString() + " COMMENT RECEIVED ";
                            row["AckDate"] = row["FITRequestedOn"];
                            if (i == 0)
                            {
                                //if (ds.Tables[2].Rows.Count > 0)
                                //    //row["NextPlannedDate"] = new MySql.Data.Types.MySqlDateTime(Convert.ToDateTime(ds.Tables[2].Rows[0]["OrderDate"]).AddDays(10));
                                //else
                                //    //row["NextPlannedDate"] = new MySql.Data.Types.MySqlDateTime(DateTime.MinValue);

                            }
                        }
                        else
                        {
                            if (row["PlanningFor"].ToString().ToUpper().IndexOf("STC") < 0)
                            {
                                row["CommentsSentFor"] = row["PlanningFor"].ToString() + " SENT ";

                                if (Convert.ToDateTime(row["NextPlannedDate"]) != DateTime.MinValue)
                                {
                                    //row["NextPlannedDate"] = new MySql.Data.Types.MySqlDateTime(Convert.ToDateTime(row["NextPlannedDate"]).AddDays(-2));
                                }
                                else
                                {
                                   // row["NextPlannedDate"] = new DateTime(DateTime.MinValue);
                                }
                            }
                            else
                            {
                                row.Delete();
                            }
                        }


                        i++;
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dt2;
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    int topStatus = -1;
                    DateTime topSendTargetDate = (ds.Tables[1].Rows[0]["TopSentTarget"] == DBNull.Value) ? ((ds.Tables[2].Rows.Count <= 0 || ds.Tables[2].Rows[0]["StitchingETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[2].Rows[0]["StitchingETA"])) : Convert.ToDateTime(ds.Tables[1].Rows[0]["TopSentTarget"]);
                    DateTime topSendActualDate = (ds.Tables[1].Rows[0]["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[1].Rows[0]["TopSentActual"]);
                    DateTime topsendplannedate = (ds.Tables[1].Rows[0]["TopPlannedDispatchdate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[1].Rows[0]["TopPlannedDispatchdate"]);
                    DateTime topApprovalTargetDate = DateTime.MinValue;

                    if (ds.Tables[2].Rows.Count > 0)
                        topApprovalTargetDate = (ds.Tables[2].Rows[0]["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[2].Rows[0]["ExFactory"]).AddDays(-7);
                    else
                        topApprovalTargetDate = DateTime.MinValue;

                    DateTime topApprovalActualDate = (ds.Tables[1].Rows[0]["TopActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[1].Rows[0]["TopActualApproval"]);

                    if (ds.Tables[1].Rows[0]["TopStatus"] != DBNull.Value)
                    {
                        topStatus = Convert.ToInt32(ds.Tables[1].Rows[0]["TopStatus"]);

                    }

                    if (topStatus == (int)TopStatusType.REJECTED && topSendActualDate == DateTime.MinValue)
                    {
                        trTopSentResentRow.Visible = false;
                        trTopApprovalRejectionRow.Visible = true;
                        lblTopSendText.Text = "TOP SENT";
                        lblTopApproved.Text = "TOP REJECTED";
                        lbltopplaneddate.Text = (topsendplannedate == DateTime.MinValue) ? "NOT PLANNED" : topsendplannedate.ToString("dd MMM yy (ddd)");
                        lbltopappplaneddate.Text = "NOT PLANNED";
                    }
                    else if (topStatus == (int)TopStatusType.REJECTED && topSendActualDate != DateTime.MinValue)
                    {
                        trTopSentResentRow.Visible = true;
                        trTopApprovalRejectionRow.Visible = false;
                        lblTopSendText.Text = "TOP RESENT";
                        lblTopApproved.Text = "TOP APPROVED";
                        // lbltopplaneddate.Text = string.Empty;
                    }
                    else
                    {
                        trTopSentResentRow.Visible = true;
                        trTopApprovalRejectionRow.Visible = true;
                        lblTopSendText.Text = "TOP SENT";
                        lblTopApproved.Text = "TOP APPROVED";
                        lbltopappplaneddate.Text = "NOT PLANNED";
                        // lbltopplaneddate.Text = (topsendplannedate == DateTime.MinValue) ? "NOT PLANNED" : topsendplannedate.ToString("dd MMM yy (ddd)");
                    }

                    lbltopsenttgt.Text = (topSendTargetDate == DateTime.MinValue) ? string.Empty : topSendTargetDate.ToString("dd MMM yy (ddd)");
                    lbltopsentact.Text = (topSendActualDate == DateTime.MinValue) ? string.Empty : topSendActualDate.ToString("dd MMM yy (ddd)");
                    lbltopappact.Text = (topApprovalActualDate == DateTime.MinValue) ? string.Empty : topApprovalActualDate.ToString("dd MMM yy (ddd)");
                    lbltopapptgt.Text = (topApprovalTargetDate == DateTime.MinValue) ? string.Empty : topApprovalTargetDate.ToString("dd MMM yy (ddd)");
                    //lbltopappplaneddate.Text = (topApprovalTargetDate == DateTime.MinValue) ? string.Empty : topApprovalTargetDate.ToString("dd MMM yy (ddd)");
                    //lbltopplaneddate.Text = (topApprovalTargetDate == DateTime.MinValue) ? string.Empty : topApprovalTargetDate.ToString("dd MMM yy (ddd)");
                    //stc planned date 
                    lbltopplaneddate.Text = (topsendplannedate == DateTime.MinValue) ? "NOT PLANNED" : topsendplannedate.ToString("dd MMM yy (ddd)");
                    
                }

                else
                {
                    trTopSentResentRow.Visible = true;
                    trTopApprovalRejectionRow.Visible = true;
                    lblTopSendText.Text = "TOP SENT";
                    lblTopApproved.Text = "TOP APPROVED";

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ////lbltopsenttgt.Text = ((ds.Tables[2].Rows[0]["StitchingETA"] == DBNull.Value) ? "" : Convert.ToDateTime(ds.Tables[2].Rows[0]["StitchingETA"]).ToString("dd MMM yy (ddd)"));
                    }
                    else
                    {
                        lbltopsenttgt.Text = string.Empty;
                    }

                    lbltopsentact.Text = string.Empty;
                    lbltopappact.Text = string.Empty;

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ////lbltopapptgt.Text = (ds.Tables[2].Rows[0]["ExFactory"] == DBNull.Value || Convert.ToDateTime(ds.Tables[2].Rows[0]["ExFactory"]) == DateTime.MinValue) ? "" : Convert.ToDateTime(ds.Tables[2].Rows[0]["ExFactory"]).AddDays(-7).ToString("dd MMM yy (ddd)");
                        //lbltopappplaneddate.Text = (ds.Tables[2].Rows[0]["PlannedDispatchDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[2].Rows[0]["PlannedDispatchDate"]) == DateTime.MinValue) ? "" : Convert.ToDateTime(ds.Tables[2].Rows[0]["PlannedDispatchDate"]).AddDays(-7).ToString("dd MMM yy (ddd)");
                    }
                    else
                    {
                        lbltopapptgt.Text = string.Empty;
                        //lbltopappplaneddate.Text = string.Empty;
 
                    }
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    lblSTCTarget.Text = (ds.Tables[2].Rows[0]["STCUnallocated"] == DBNull.Value) ? "" : Convert.ToDateTime(ds.Tables[2].Rows[0]["STCUnallocated"]).ToString("dd MMM yy (ddd)");
                    //sts planned date
                    lblSTCplaneddate.Text = (ds.Tables[2].Rows[0]["PlannedDispatchDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[2].Rows[0]["PlannedDispatchDate"]) == DateTime.MinValue) ? "NOT PLANNED" : Convert.ToDateTime(ds.Tables[2].Rows[0]["PlannedDispatchDate"]).ToString("dd MMM yy (ddd)");
                }
                else
                {
                    lblSTCTarget.Text = string.Empty;
                    lblSTCplaneddate.Text = "NOT PLANNED";
                }
                DateTime specsTargetDate = DateTime.MinValue;
                DateTime specsActualDate = DateTime.MinValue;
                //spec send date
                DateTime planeddate = DateTime.MinValue;
                if (ds.Tables[4].Rows.Count > 0)
                {
                    DataRow drSpecs = ds.Tables[4].Rows[0];
                    specsTargetDate = (drSpecs["SpecsUploadTargetDate"] == DBNull.Value || drSpecs["SpecsUploadTargetDate"].ToString() == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(drSpecs["SpecsUploadTargetDate"]);
                    specsActualDate = (drSpecs["SpecsUploadDate"] == DBNull.Value || drSpecs["SpecsUploadDate"].ToString() == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(drSpecs["SpecsUploadDate"]);
                    lblSpeceSendTarget.Text = (specsTargetDate == DateTime.MinValue) ? string.Empty : specsTargetDate.ToString("dd MMM yy (ddd)");
                    lblSpeceSendActual.Text = (specsActualDate == DateTime.MinValue) ? string.Empty : specsActualDate.ToString("dd MMM yy (ddd)");
                    //spec send palned date
                    //planeddate = (drSpecs["PlannedDispatchDate"] == DBNull.Value || drSpecs["PlannedDispatchDate"].ToString() == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(drSpecs["PlannedDispatchDate"]);
                    //lblSpeceSendplaneddate.Text = "Not Planned ";//(planeddate == DateTime.MinValue) ? "Not Planned" : planeddate.ToString("dd MMM yy (ddd)");
                }
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    //spec send palned date
                //    ////planeddate = (ds.Tables[0].Rows[0]["PlannedDispatchDate"] == DBNull.Value || ds.Tables[0].Rows[0]["PlannedDispatchDate"].ToString() == string.Empty) ? DateTime.MinValue : Convert.ToDateTime(ds.Tables[0].Rows[0]["PlannedDispatchDate"]);
                //    lblSpeceSendplaneddate.Text = (ds.Tables[0].Rows[0]["PlannedDispatchDate"] == DBNull.Value) ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["PlannedDispatchDate"]).ToString("dd MMM yy (ddd)");//(planeddate == DateTime.MinValue) ? string.Empty : planeddate.ToString("dd MMM yy (ddd)");
                //}

                tdSTC.Attributes.Add("style", "background-color:" + Constants.GetActualDateColor(DateHelper.ParseDate(lblSTCTarget.Text).Value, DateHelper.ParseDate(lblSTCActual.Text).Value));
                tdTopSent.Attributes.Add("style", "background-color:" + Constants.GetActualDateColor(DateHelper.ParseDate(lbltopsenttgt.Text).Value, DateHelper.ParseDate(lbltopsentact.Text).Value));
                tdTopApproval.Attributes.Add("style", "background-color:" + Constants.GetActualDateColor(DateHelper.ParseDate(lbltopapptgt.Text).Value, DateHelper.ParseDate(lbltopappact.Text).Value));
                tdSpecsSend.Attributes.Add("style", "background-color:" + Constants.GetActualDateColor(specsTargetDate, specsActualDate));

                string remarks = string.Empty;
                string remarksBipl = string.Empty;
                //status remark
                string statusremark = string.Empty;
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataRow drRemarks = ds.Tables[3].Rows[0];

                    remarks = ((drRemarks["RemarksIKANDI"]) == DBNull.Value) ? string.Empty : Convert.ToString(drRemarks["RemarksIKANDI"]).ToString();
                    remarksBipl = ((drRemarks["RemarksBIPL"]) == DBNull.Value) ? string.Empty : Convert.ToString(drRemarks["RemarksBIPL"]).ToString();
                    //status remark
                    statusremark = ((drRemarks["FitsRemarks"]) == DBNull.Value) ? string.Empty : Convert.ToString(drRemarks["FitsRemarks"]).ToString();
                    if (remarks.IndexOf("$$") > -1)
                    {
                        lblRemarks.Text = remarks.ToString().Substring(remarks.ToString().LastIndexOf("$$") + 2);
                        hdnRemarks.Value = remarks.ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");

                    }
                    else
                    {
                        lblRemarks.Text = remarks.ToString();
                        hdnRemarks.Value = remarks.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");

                    }
                    //statusremark
                    if (statusremark.IndexOf("$$") > -1)
                    {
                        //statusremark
                        lblstatusremark.Text = statusremark.ToString().Substring(statusremark.ToString().LastIndexOf("$$") + 2);
                        hdnstsremark.Value = statusremark.ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");

                    }
                    else
                    {
                        //statu remarks
                        lblstatusremark.Text = statusremark.ToString();
                        hdnstsremark.Value = statusremark.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");
                    }

                    if (remarksBipl.IndexOf("$$") > -1)
                    {
                        lblRemarksBIPL.Text = remarksBipl.ToString().Substring(remarksBipl.ToString().LastIndexOf("$$") + 2);
                        hdnRemarksBipl.Value = remarksBipl.ToString().Replace("$$", "<br />").Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");


                    }
                    else
                    {
                        lblRemarksBIPL.Text = remarksBipl.ToString();
                        hdnRemarksBipl.Value = remarksBipl.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");

                    }

                }
                else
                {
                    lblRemarks.Text = "";
                    hdnRemarks.Value = "";
                    lblRemarksBIPL.Text = "";
                    hdnRemarksBipl.Value = "";
                    hdnstsremark.Value = "";
                    lblstatusremark.Text = "";
                }

                if (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.SEALERS_PENDING_SEALER_REMARKS_IKANDI))
                {
                    hdnPermission.Value = "1";

                }
                else
                {
                    hdnPermission.Value = "0";
                }

                if (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.SEALERS_PENDING_SEALER_REMARKS_BIPL))
                {
                    hdnPermissionBipl.Value = "1";

                }
                else
                {
                    hdnPermissionBipl.Value = "0";
                }
                //staus remark information
                if (iKandi.Web.Components.PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.SEALERS_PENDING_SEALER_REMARKS_BIPL))
                {
                    hdnPermissionBipl.Value = "1";

                }
                else
                {
                    hdnPermissionBipl.Value = "0";
                }
                hdnstyleId.Value = this.StyleNumber.ToString();
                hdnDeptid.Value = this.DepartmentID.ToString();
                hdnstyleIdBipl.Value = this.StyleNumberDesc;
                hdnDeptidBipl.Value = this.DepartmentID.ToString();
                hdnstsstyleid.Value = this.StyleNumberDesc;
                hdnstsdepid.Value = this.DepartmentID.ToString();


                if (ds.Tables[3].Rows.Count > 0)
                {
                    lblSpeceSendplaneddate.Text=(Convert.ToString(ds.Tables[3].Rows[0]["SpecUploadPlannedDate"])=="" ? "NOT PLANNED" : Convert.ToString(ds.Tables[3].Rows[0]["SpecUploadPlannedDate"]));
                }

                lblTech.Text = Convert.ToString(ds.Tables[5].Rows[0]["Tech"]).Replace(",", ", ");
                lblFitMerchant.Text = Convert.ToString(ds.Tables[5].Rows[0]["FitMerchant"]).Replace(",", ", ");
            }
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            DataRowView row = e.Row.DataItem as DataRowView;
            if (row["AckDate"] != DBNull.Value)
            {
                e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(Convert.ToDateTime(row["NextPlannedDate"]), Convert.ToDateTime(row["AckDate"])));
            }
        }
    }
}