using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Web.UI.HtmlControls;


namespace iKandi.Web.Internal.Production
{
    public partial class HourlyStitchingReport : System.Web.UI.Page
    {
        public int ProductionUnit
        {
            get;
            set;
        }
        public int SlotId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public string StartDate
        {
            get;
            set;
        }

        int Total_Slot1 = 0;
        int Total_Slot2 = 0;
        int Total_Slot3 = 0;
        int Total_Slot4 = 0;
        int Total_Slot5 = 0;
        int Total_Slot6 = 0;
        int Total_Slot7 = 0;
        int Total_Slot8 = 0;
        int Total_Slot9 = 0;
        int Total_Slot10 = 0;
        int Total_Slot11 = 0;
        int Total_Slot12 = 0;
        int Total_Slot13 = 0;
        int Total_Slot14 = 0;
        int Total_Slot15 = 0;
        int Total_Slot16 = 0;
        int Total_Slot17 = 0;
        int Total_Slot18 = 0;
        int Total_Slot19 = 0;
        int Total_Slot20 = 0;
        int Total_Slot21 = 0;
        int Total_Slot22 = 0;
        int Total_Slot23 = 0;
        int Total_Slot24 = 0;
        int IsStitchData = 0;
        int IsfinishData = 0;

        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                GetStitchingSlotTime();
                GetStitchingHourlyReport("C 47");
                GetStitchingHourlyReport("C 45-46");
                GetStitchingHourlyReport("B 45");
                HideStitchingUnUsedSlot();

                GetFinishingHourlyReport("C 47");
                GetFinishingHourlyReport("C 45-46");
                GetFinishingHourlyReport("B 45");
                HideFinishingUnUsedSlot();

                
            }
        }

            

        #region Stitching

        private void GetStitchingSlotTime()
        {            
            DataSet ds;
            ds = objProductionController.GetHourlyStitchingReport("", -1, -1, -1, -1, -1, -1, "SlotTime");
            DataTable dt = ds.Tables[0];
            DataTable dtSlot = new DataTable();
            int SlotCount = 1;
            DataRow row = dtSlot.NewRow();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtSlot.Columns.Add(new DataColumn("SlotStart" + SlotCount, typeof(string)));
                dtSlot.Columns.Add(new DataColumn("SlotEnd" + SlotCount, typeof(string)));

                row["SlotStart" + SlotCount] = dt.Rows[i]["SlotStart"].ToString();
                row["SlotEnd" + SlotCount] = dt.Rows[i]["SlotEnd"].ToString();

                SlotCount = SlotCount + 1;
            }
            dtSlot.Rows.Add(row);
            dtSlot.AcceptChanges();
            ViewState["dtSlot"] = dtSlot;
            if (ds.Tables[1].Rows.Count > 0)
            {
                hdnSlotId.Value = ds.Tables[1].Rows[0]["SLOTID"].ToString();
            }
        }

        private void GetStitchingHourlyReport(string sUnitName)
        {            
            DataSet ds;
            if (sUnitName == "C 47")
            {
                ds = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, -1, -1, -1, -1,  "HourlyReport");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsStitchData = 1;
                    StichFact1.Visible = true;
                    lblStitchUnit1.Visible = true;
                    gvHourlyStitchingReport1.DataSource = ds.Tables[0];
                    gvHourlyStitchingReport1.DataBind();
                }
            }
            if (sUnitName == "C 45-46")
            {
                ds = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, -1, -1, -1, -1, "HourlyReport");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsStitchData = 1;
                    StichFact2.Visible = true;
                    lblStitchUnit2.Visible = true;
                    gvHourlyStitchingReport2.DataSource = ds.Tables[0];
                    gvHourlyStitchingReport2.DataBind();
                }
            }
            if (sUnitName == "B 45")
            {
                ds = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, -1, -1, -1, -1, "HourlyReport");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsStitchData = 1;
                    StichFact3.Visible = true;
                    lblStitchUnit3.Visible = true;
                    gvHourlyStitchingReport3.DataSource = ds.Tables[0];
                    gvHourlyStitchingReport3.DataBind();
                }
            }
            if (IsStitchData == 1)
            {
                Stitching.Visible = true;
            }
        }

        private void GetLineDesignationDataTable()
        {
            DataTable dt = (DataTable)ViewState["tblLineDesignation"];
            DataTable dtLineDesignation = new DataTable();

            dtLineDesignation.Columns.Add(new DataColumn("StyleId", typeof(int)));
            
            int BaseStyle = -1;
            int UniqueBaseStyle = -1;
            for (int iStyle = 0; iStyle < dt.Rows.Count; iStyle++)
            {
                DataRow row = dtLineDesignation.NewRow();
                BaseStyle = Convert.ToInt32(dt.Rows[iStyle]["StyleId"]);
                
                if ((UniqueBaseStyle != BaseStyle) || (UniqueBaseStyle == -1))
                {
                    UniqueBaseStyle = BaseStyle;
                    int PrevStyleId = -1;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int StyleId = Convert.ToInt32(dt.Rows[i]["StyleId"]);

                        if (PrevStyleId == -1)
                        {
                            PrevStyleId = StyleId;
                            dtLineDesignation.Columns.Add(new DataColumn(dt.Rows[i]["Name"].ToString(), typeof(string)));
                            row["StyleId"] = Convert.ToInt32(dt.Rows[i]["StyleId"]);
                            row[dt.Rows[i]["Name"].ToString()] = dt.Rows[i]["DesignationName"].ToString();
                        }
                        else
                        {
                            dtLineDesignation.Columns.Add(new DataColumn(dt.Rows[i]["Name"].ToString(), typeof(string)));
                            row[dt.Rows[i]["Name"].ToString()] = dt.Rows[i]["DesignationName"].ToString();
                        }
                    }
                    dtLineDesignation.Rows.Add(row);
                    dtLineDesignation.AcceptChanges();
                }
            }

            ViewState["dtLineDesignation"] = dtLineDesignation;
        }

        protected void gvHourlyStitchingReport1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sUnitName = "C 47";
            DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblSlot1Time = (Label)e.Row.FindControl("lblSlot1Time");
                lblSlot1Time.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

                Label lblSlot2Time = (Label)e.Row.FindControl("lblSlot2Time");
                lblSlot2Time.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

                Label lblSlot3Time = (Label)e.Row.FindControl("lblSlot3Time");
                lblSlot3Time.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

                Label lblSlot4Time = (Label)e.Row.FindControl("lblSlot4Time");
                lblSlot4Time.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

                Label lblSlot5Time = (Label)e.Row.FindControl("lblSlot5Time");
                lblSlot5Time.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

                Label lblSlot6Time = (Label)e.Row.FindControl("lblSlot6Time");
                lblSlot6Time.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

                Label lblSlot7Time = (Label)e.Row.FindControl("lblSlot7Time");
                lblSlot7Time.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

                Label lblSlot8Time = (Label)e.Row.FindControl("lblSlot8Time");
                lblSlot8Time.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

                Label lblSlot9Time = (Label)e.Row.FindControl("lblSlot9Time");
                lblSlot9Time.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

                Label lblSlot10Time = (Label)e.Row.FindControl("lblSlot10Time");
                lblSlot10Time.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

                Label lblSlot11Time = (Label)e.Row.FindControl("lblSlot11Time");
                lblSlot11Time.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

                Label lblSlot12Time = (Label)e.Row.FindControl("lblSlot12Time");
                lblSlot12Time.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

                Label lblSlot13Time = (Label)e.Row.FindControl("lblSlot13Time");
                lblSlot13Time.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

                Label lblSlot14Time = (Label)e.Row.FindControl("lblSlot14Time");
                lblSlot14Time.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

                Label lblSlot15Time = (Label)e.Row.FindControl("lblSlot15Time");
                lblSlot15Time.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

                Label lblSlot16Time = (Label)e.Row.FindControl("lblSlot16Time");
                lblSlot16Time.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();

                Label lblSlot17Time = (Label)e.Row.FindControl("lblSlot17Time");
                lblSlot17Time.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

                Label lblSlot18Time = (Label)e.Row.FindControl("lblSlot18Time");
                lblSlot18Time.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

                Label lblSlot19Time = (Label)e.Row.FindControl("lblSlot19Time");
                lblSlot19Time.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

                Label lblSlot20Time = (Label)e.Row.FindControl("lblSlot20Time");
                lblSlot20Time.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

                Label lblSlot21Time = (Label)e.Row.FindControl("lblSlot21Time");
                lblSlot21Time.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

                Label lblSlot22Time = (Label)e.Row.FindControl("lblSlot22Time");
                lblSlot22Time.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

                Label lblSlot23Time = (Label)e.Row.FindControl("lblSlot23Time");
                lblSlot23Time.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();

                Label lblSlot24Time = (Label)e.Row.FindControl("lblSlot24Time");
                lblSlot24Time.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();                

               
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");
                if (hdnStyleId != null)
                    StyleId = Convert.ToInt32(hdnStyleId.Value);
                if (hdnLineNo != null)
                    LineNo = Convert.ToInt32(hdnLineNo.Value);
                DataSet ds;
                ds = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, -1, -1, -1, -1, "LinePlanning");
                DataList dlstLineDesignation = e.Row.FindControl("dlstLineDesignation") as DataList;
                dlstLineDesignation.DataSource = ds.Tables[0];
                dlstLineDesignation.DataBind();

                // Comment for hide Profit & Loss section
                //DataSet dsDepartment_Target;
                //dsDepartment_Target = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, "Department_Target");
                //ViewState["Department_Target"] = dsDepartment_Target.Tables[0];
                //Repeater rptDepartment_Target = e.Row.FindControl("rptDepartment_Target") as Repeater;
                //rptDepartment_Target.DataSource = dsDepartment_Target.Tables[0];
                //rptDepartment_Target.DataBind();

                //DataSet dsDepartment_BE;
                //dsDepartment_BE = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, "Department_BE");
                //ViewState["Department_BE"] = dsDepartment_Target.Tables[0];
                //Repeater rptDepartment_BE = e.Row.FindControl("rptDepartment_BE") as Repeater;
                //rptDepartment_BE.DataSource = dsDepartment_BE.Tables[0];
                //rptDepartment_BE.DataBind();
            }

        }

        protected void gvHourlyStitchingReport2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sUnitName = "C 45-46";
            DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblSlot1Time = (Label)e.Row.FindControl("lblSlot1Time");
                lblSlot1Time.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

                Label lblSlot2Time = (Label)e.Row.FindControl("lblSlot2Time");
                lblSlot2Time.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

                Label lblSlot3Time = (Label)e.Row.FindControl("lblSlot3Time");
                lblSlot3Time.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

                Label lblSlot4Time = (Label)e.Row.FindControl("lblSlot4Time");
                lblSlot4Time.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

                Label lblSlot5Time = (Label)e.Row.FindControl("lblSlot5Time");
                lblSlot5Time.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

                Label lblSlot6Time = (Label)e.Row.FindControl("lblSlot6Time");
                lblSlot6Time.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

                Label lblSlot7Time = (Label)e.Row.FindControl("lblSlot7Time");
                lblSlot7Time.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

                Label lblSlot8Time = (Label)e.Row.FindControl("lblSlot8Time");
                lblSlot8Time.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

                Label lblSlot9Time = (Label)e.Row.FindControl("lblSlot9Time");
                lblSlot9Time.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

                Label lblSlot10Time = (Label)e.Row.FindControl("lblSlot10Time");
                lblSlot10Time.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

                Label lblSlot11Time = (Label)e.Row.FindControl("lblSlot11Time");
                lblSlot11Time.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

                Label lblSlot12Time = (Label)e.Row.FindControl("lblSlot12Time");
                lblSlot12Time.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

                Label lblSlot13Time = (Label)e.Row.FindControl("lblSlot13Time");
                lblSlot13Time.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

                Label lblSlot14Time = (Label)e.Row.FindControl("lblSlot14Time");
                lblSlot14Time.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

                Label lblSlot15Time = (Label)e.Row.FindControl("lblSlot15Time");
                lblSlot15Time.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

                Label lblSlot16Time = (Label)e.Row.FindControl("lblSlot16Time");
                lblSlot16Time.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();

                Label lblSlot17Time = (Label)e.Row.FindControl("lblSlot17Time");
                lblSlot17Time.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

                Label lblSlot18Time = (Label)e.Row.FindControl("lblSlot18Time");
                lblSlot18Time.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

                Label lblSlot19Time = (Label)e.Row.FindControl("lblSlot19Time");
                lblSlot19Time.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

                Label lblSlot20Time = (Label)e.Row.FindControl("lblSlot20Time");
                lblSlot20Time.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

                Label lblSlot21Time = (Label)e.Row.FindControl("lblSlot21Time");
                lblSlot21Time.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

                Label lblSlot22Time = (Label)e.Row.FindControl("lblSlot22Time");
                lblSlot22Time.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

                Label lblSlot23Time = (Label)e.Row.FindControl("lblSlot23Time");
                lblSlot23Time.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();

                Label lblSlot24Time = (Label)e.Row.FindControl("lblSlot24Time");
                lblSlot24Time.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();                


            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");
                if (hdnStyleId != null)
                    StyleId = Convert.ToInt32(hdnStyleId.Value);
                if (hdnLineNo != null)
                    LineNo = Convert.ToInt32(hdnLineNo.Value);
                DataSet ds;
                ds = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, -1, -1,  -1, -1,"LinePlanning");
                DataList dlstLineDesignation = e.Row.FindControl("dlstLineDesignation") as DataList;
                dlstLineDesignation.DataSource = ds.Tables[0];
                dlstLineDesignation.DataBind();

                // Comment for hide Profit & Loss section
                //DataSet dsDepartment_Target;
                //dsDepartment_Target = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, "Department_Target");
                //ViewState["Department_Target"] = dsDepartment_Target.Tables[0];
                //Repeater rptDepartment_Target = e.Row.FindControl("rptDepartment_Target") as Repeater;
                //rptDepartment_Target.DataSource = dsDepartment_Target.Tables[0];
                //rptDepartment_Target.DataBind();

                //DataSet dsDepartment_BE;
                //dsDepartment_BE = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, "Department_BE");
                //ViewState["Department_BE"] = dsDepartment_Target.Tables[0];
                //Repeater rptDepartment_BE = e.Row.FindControl("rptDepartment_BE") as Repeater;
                //rptDepartment_BE.DataSource = dsDepartment_BE.Tables[0];
                //rptDepartment_BE.DataBind();
            }

        }

        protected void gvHourlyStitchingReport3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sUnitName = "B 45";
            DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblSlot1Time = (Label)e.Row.FindControl("lblSlot1Time");
                lblSlot1Time.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

                Label lblSlot2Time = (Label)e.Row.FindControl("lblSlot2Time");
                lblSlot2Time.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

                Label lblSlot3Time = (Label)e.Row.FindControl("lblSlot3Time");
                lblSlot3Time.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

                Label lblSlot4Time = (Label)e.Row.FindControl("lblSlot4Time");
                lblSlot4Time.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

                Label lblSlot5Time = (Label)e.Row.FindControl("lblSlot5Time");
                lblSlot5Time.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

                Label lblSlot6Time = (Label)e.Row.FindControl("lblSlot6Time");
                lblSlot6Time.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

                Label lblSlot7Time = (Label)e.Row.FindControl("lblSlot7Time");
                lblSlot7Time.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

                Label lblSlot8Time = (Label)e.Row.FindControl("lblSlot8Time");
                lblSlot8Time.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

                Label lblSlot9Time = (Label)e.Row.FindControl("lblSlot9Time");
                lblSlot9Time.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

                Label lblSlot10Time = (Label)e.Row.FindControl("lblSlot10Time");
                lblSlot10Time.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

                Label lblSlot11Time = (Label)e.Row.FindControl("lblSlot11Time");
                lblSlot11Time.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

                Label lblSlot12Time = (Label)e.Row.FindControl("lblSlot12Time");
                lblSlot12Time.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

                Label lblSlot13Time = (Label)e.Row.FindControl("lblSlot13Time");
                lblSlot13Time.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

                Label lblSlot14Time = (Label)e.Row.FindControl("lblSlot14Time");
                lblSlot14Time.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

                Label lblSlot15Time = (Label)e.Row.FindControl("lblSlot15Time");
                lblSlot15Time.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

                Label lblSlot16Time = (Label)e.Row.FindControl("lblSlot16Time");
                lblSlot16Time.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();

                Label lblSlot17Time = (Label)e.Row.FindControl("lblSlot17Time");
                lblSlot17Time.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

                Label lblSlot18Time = (Label)e.Row.FindControl("lblSlot18Time");
                lblSlot18Time.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

                Label lblSlot19Time = (Label)e.Row.FindControl("lblSlot19Time");
                lblSlot19Time.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

                Label lblSlot20Time = (Label)e.Row.FindControl("lblSlot20Time");
                lblSlot20Time.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

                Label lblSlot21Time = (Label)e.Row.FindControl("lblSlot21Time");
                lblSlot21Time.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

                Label lblSlot22Time = (Label)e.Row.FindControl("lblSlot22Time");
                lblSlot22Time.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

                Label lblSlot23Time = (Label)e.Row.FindControl("lblSlot23Time");
                lblSlot23Time.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();

                Label lblSlot24Time = (Label)e.Row.FindControl("lblSlot24Time");
                lblSlot24Time.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();                


            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");
                if (hdnStyleId != null)
                    StyleId = Convert.ToInt32(hdnStyleId.Value);
                if (hdnLineNo != null)
                    LineNo = Convert.ToInt32(hdnLineNo.Value);

                DataSet ds;
                ds = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, -1, -1, -1, -1, "LinePlanning");
                DataList dlstLineDesignation = e.Row.FindControl("dlstLineDesignation") as DataList;
                dlstLineDesignation.DataSource = ds.Tables[0];
                dlstLineDesignation.DataBind();

                // Comment for hide Profit & Loss section
                //DataSet dsDepartment_Target;
                //dsDepartment_Target = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, "Department_Target");
                //ViewState["Department_Target"] = dsDepartment_Target.Tables[0];
                //Repeater rptDepartment_Target = e.Row.FindControl("rptDepartment_Target") as Repeater;
                //rptDepartment_Target.DataSource = dsDepartment_Target.Tables[0];
                //rptDepartment_Target.DataBind();

                //DataSet dsDepartment_BE;
                //dsDepartment_BE = objProductionController.GetHourlyStitchingReport(sUnitName, StyleId, LineNo, "Department_BE");
                //ViewState["Department_BE"] = dsDepartment_Target.Tables[0];
                //Repeater rptDepartment_BE = e.Row.FindControl("rptDepartment_BE") as Repeater;
                //rptDepartment_BE.DataSource = dsDepartment_BE.Tables[0];
                //rptDepartment_BE.DataBind();
            }

        }

        private void HideStitchingUnUsedSlot()
        {
            SlotId = Convert.ToInt32(hdnSlotId.Value);
            SlotId = SlotId + 4;
            for (int i = SlotId; i < 28; i++)
            {
                gvHourlyStitchingReport1.Columns[i].Visible = false;
                gvHourlyStitchingReport2.Columns[i].Visible = false;
                gvHourlyStitchingReport3.Columns[i].Visible = false;
            }
        }

        #endregion Stitching

        #region Finishing


        private void GetFinishingHourlyReport(string sUnitName)
        {            
            DataSet ds;
            if (sUnitName == "C 47")
            {
                ds = objProductionController.GetHourlyFinishingReport(sUnitName, StyleId, "HourlyReport");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsfinishData = 1;
                    FinishFact1.Visible = true;
                    lblFinishUnit1.Visible = true;
                    gvHourlyFinishingReport1.DataSource = ds.Tables[0];
                    gvHourlyFinishingReport1.DataBind();
                }
            }
            if (sUnitName == "C 45-46")
            {
                ds = objProductionController.GetHourlyFinishingReport(sUnitName, StyleId, "HourlyReport");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsfinishData = 1;
                    FinishFact2.Visible = true;
                    lblFinishUnit2.Visible = true;
                    gvHourlyFinishingReport2.DataSource = ds.Tables[0];
                    gvHourlyFinishingReport2.DataBind();
                }
            }
            if (sUnitName == "B 45")
            {
                ds = objProductionController.GetHourlyFinishingReport(sUnitName, StyleId, "HourlyReport");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsfinishData = 1;
                    FinishFact3.Visible = true;
                    lblFinishUnit3.Visible = true;
                    gvHourlyFinishingReport3.DataSource = ds.Tables[0];
                    gvHourlyFinishingReport3.DataBind();
                }
            }
            if (IsfinishData == 1)
            {
                Finishing.Visible = true;
            }
        }

        private void HideFinishingUnUsedSlot()
        {
            SlotId = Convert.ToInt32(hdnSlotId.Value);
            SlotId = SlotId + 4;
            for (int i = SlotId; i < 28; i++)
            {
                gvHourlyFinishingReport1.Columns[i].Visible = false;
                gvHourlyFinishingReport2.Columns[i].Visible = false;
                gvHourlyFinishingReport3.Columns[i].Visible = false;
            }
        }

        protected void gvHourlyFinishingReport1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sUnitName = "C 47";
            DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblSlot1Time = (Label)e.Row.FindControl("lblSlot1Time");
                lblSlot1Time.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

                Label lblSlot2Time = (Label)e.Row.FindControl("lblSlot2Time");
                lblSlot2Time.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

                Label lblSlot3Time = (Label)e.Row.FindControl("lblSlot3Time");
                lblSlot3Time.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

                Label lblSlot4Time = (Label)e.Row.FindControl("lblSlot4Time");
                lblSlot4Time.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

                Label lblSlot5Time = (Label)e.Row.FindControl("lblSlot5Time");
                lblSlot5Time.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

                Label lblSlot6Time = (Label)e.Row.FindControl("lblSlot6Time");
                lblSlot6Time.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

                Label lblSlot7Time = (Label)e.Row.FindControl("lblSlot7Time");
                lblSlot7Time.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

                Label lblSlot8Time = (Label)e.Row.FindControl("lblSlot8Time");
                lblSlot8Time.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

                Label lblSlot9Time = (Label)e.Row.FindControl("lblSlot9Time");
                lblSlot9Time.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

                Label lblSlot10Time = (Label)e.Row.FindControl("lblSlot10Time");
                lblSlot10Time.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

                Label lblSlot11Time = (Label)e.Row.FindControl("lblSlot11Time");
                lblSlot11Time.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

                Label lblSlot12Time = (Label)e.Row.FindControl("lblSlot12Time");
                lblSlot12Time.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

                Label lblSlot13Time = (Label)e.Row.FindControl("lblSlot13Time");
                lblSlot13Time.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

                Label lblSlot14Time = (Label)e.Row.FindControl("lblSlot14Time");
                lblSlot14Time.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

                Label lblSlot15Time = (Label)e.Row.FindControl("lblSlot15Time");
                lblSlot15Time.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

                Label lblSlot16Time = (Label)e.Row.FindControl("lblSlot16Time");
                lblSlot16Time.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();

                Label lblSlot17Time = (Label)e.Row.FindControl("lblSlot17Time");
                lblSlot17Time.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

                Label lblSlot18Time = (Label)e.Row.FindControl("lblSlot18Time");
                lblSlot18Time.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

                Label lblSlot19Time = (Label)e.Row.FindControl("lblSlot19Time");
                lblSlot19Time.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

                Label lblSlot20Time = (Label)e.Row.FindControl("lblSlot20Time");
                lblSlot20Time.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

                Label lblSlot21Time = (Label)e.Row.FindControl("lblSlot21Time");
                lblSlot21Time.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

                Label lblSlot22Time = (Label)e.Row.FindControl("lblSlot22Time");
                lblSlot22Time.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

                Label lblSlot23Time = (Label)e.Row.FindControl("lblSlot23Time");
                lblSlot23Time.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();

                Label lblSlot24Time = (Label)e.Row.FindControl("lblSlot24Time");
                lblSlot24Time.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();                

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                if (hdnStyleId != null)
                    StyleId = Convert.ToInt32(hdnStyleId.Value);

                DataSet ds;
                ds = objProductionController.GetHourlyFinishingReport(sUnitName, StyleId, "Designation");               
                Repeater rptDesignation = e.Row.FindControl("rptDesignation") as Repeater;              
                rptDesignation.DataSource = ds.Tables[0];
                rptDesignation.DataBind();

                Total_Slot1 += DataBinder.Eval(e.Row.DataItem, "Slot1Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Pass"));
                Total_Slot2 += DataBinder.Eval(e.Row.DataItem, "Slot2Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Pass"));
                Total_Slot3 += DataBinder.Eval(e.Row.DataItem, "Slot3Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Pass"));
                Total_Slot4 += DataBinder.Eval(e.Row.DataItem, "Slot4Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Pass"));
                Total_Slot5 += DataBinder.Eval(e.Row.DataItem, "Slot5Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Pass"));
                Total_Slot6 += DataBinder.Eval(e.Row.DataItem, "Slot6Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Pass"));
                Total_Slot7 += DataBinder.Eval(e.Row.DataItem, "Slot7Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Pass"));
                Total_Slot8 += DataBinder.Eval(e.Row.DataItem, "Slot8Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Pass"));
                Total_Slot9 += DataBinder.Eval(e.Row.DataItem, "Slot9Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Pass"));
                Total_Slot10 += DataBinder.Eval(e.Row.DataItem, "Slot10Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Pass"));
                Total_Slot11 += DataBinder.Eval(e.Row.DataItem, "Slot11Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Pass"));
                Total_Slot12 += DataBinder.Eval(e.Row.DataItem, "Slot12Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Pass"));
                Total_Slot13 += DataBinder.Eval(e.Row.DataItem, "Slot13Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Pass"));
                Total_Slot14 += DataBinder.Eval(e.Row.DataItem, "Slot14Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Pass"));
                Total_Slot15 += DataBinder.Eval(e.Row.DataItem, "Slot15Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Pass"));
                Total_Slot16 += DataBinder.Eval(e.Row.DataItem, "Slot16Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Pass"));
                Total_Slot17 += DataBinder.Eval(e.Row.DataItem, "Slot17Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Pass"));
                Total_Slot18 += DataBinder.Eval(e.Row.DataItem, "Slot18Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Pass"));
                Total_Slot19 += DataBinder.Eval(e.Row.DataItem, "Slot19Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Pass"));
                Total_Slot20 += DataBinder.Eval(e.Row.DataItem, "Slot20Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Pass"));
                Total_Slot21 += DataBinder.Eval(e.Row.DataItem, "Slot21Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Pass"));
                Total_Slot22 += DataBinder.Eval(e.Row.DataItem, "Slot22Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Pass"));
                Total_Slot23 += DataBinder.Eval(e.Row.DataItem, "Slot23Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Pass"));
                Total_Slot24 += DataBinder.Eval(e.Row.DataItem, "Slot24Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Pass"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSlot1Total = (Label)e.Row.FindControl("lblSlot1Total");
                if(Total_Slot1 != 0)
                lblSlot1Total.Text = Total_Slot1.ToString();

                Label lblSlot2Total = (Label)e.Row.FindControl("lblSlot2Total");
                if (Total_Slot2 != 0)
                    lblSlot2Total.Text = Total_Slot2.ToString();

                Label lblSlot3Total = (Label)e.Row.FindControl("lblSlot3Total");
                if (Total_Slot3 != 0)
                    lblSlot3Total.Text = Total_Slot3.ToString();

                Label lblSlot4Total = (Label)e.Row.FindControl("lblSlot4Total");
                if (Total_Slot4 != 0)
                    lblSlot4Total.Text = Total_Slot4.ToString();

                Label lblSlot5Total = (Label)e.Row.FindControl("lblSlot5Total");
                if (Total_Slot5 != 0)
                    lblSlot5Total.Text = Total_Slot5.ToString();

                Label lblSlot6Total = (Label)e.Row.FindControl("lblSlot6Total");
                if (Total_Slot6 != 0)
                    lblSlot6Total.Text = Total_Slot6.ToString();

                Label lblSlot7Total = (Label)e.Row.FindControl("lblSlot7Total");
                if (Total_Slot7 != 0)
                    lblSlot7Total.Text = Total_Slot7.ToString();

                Label lblSlot8Total = (Label)e.Row.FindControl("lblSlot8Total");
                if (Total_Slot8 != 0)
                    lblSlot8Total.Text = Total_Slot8.ToString();

                Label lblSlot9Total = (Label)e.Row.FindControl("lblSlot9Total");
                if (Total_Slot9 != 0)
                    lblSlot9Total.Text = Total_Slot9.ToString();

                Label lblSlot10Total = (Label)e.Row.FindControl("lblSlot10Total");
                if (Total_Slot10 != 0)
                    lblSlot10Total.Text = Total_Slot10.ToString();

                Label lblSlot11Total = (Label)e.Row.FindControl("lblSlot11Total");
                if (Total_Slot11 != 0)
                    lblSlot11Total.Text = Total_Slot11.ToString();

                Label lblSlot12Total = (Label)e.Row.FindControl("lblSlot12Total");
                if (Total_Slot12 != 0)
                    lblSlot12Total.Text = Total_Slot12.ToString();

                Label lblSlot13Total = (Label)e.Row.FindControl("lblSlot13Total");
                if (Total_Slot13 != 0)
                    lblSlot13Total.Text = Total_Slot13.ToString();

                Label lblSlot14Total = (Label)e.Row.FindControl("lblSlot14Total");
                if (Total_Slot14 != 0)
                    lblSlot14Total.Text = Total_Slot14.ToString();

                Label lblSlot15Total = (Label)e.Row.FindControl("lblSlot15Total");
                if (Total_Slot15 != 0)
                    lblSlot15Total.Text = Total_Slot15.ToString();

                Label lblSlot16Total = (Label)e.Row.FindControl("lblSlot16Total");
                if (Total_Slot16 != 0)
                    lblSlot16Total.Text = Total_Slot16.ToString();

                Label lblSlot17Total = (Label)e.Row.FindControl("lblSlot17Total");
                if (Total_Slot17 != 0)
                    lblSlot17Total.Text = Total_Slot17.ToString();

                Label lblSlot18Total = (Label)e.Row.FindControl("lblSlot18Total");
                if (Total_Slot18 != 0)
                    lblSlot18Total.Text = Total_Slot18.ToString();

                Label lblSlot19Total = (Label)e.Row.FindControl("lblSlot19Total");
                if (Total_Slot19 != 0)
                    lblSlot19Total.Text = Total_Slot19.ToString();

                Label lblSlot20Total = (Label)e.Row.FindControl("lblSlot20Total");
                if (Total_Slot20 != 0)
                    lblSlot20Total.Text = Total_Slot20.ToString();

                Label lblSlot21Total = (Label)e.Row.FindControl("lblSlot21Total");
                if (Total_Slot21 != 0)
                    lblSlot21Total.Text = Total_Slot21.ToString();

                Label lblSlot22Total = (Label)e.Row.FindControl("lblSlot22Total");
                if (Total_Slot22 != 0)
                    lblSlot22Total.Text = Total_Slot22.ToString();

                Label lblSlot23Total = (Label)e.Row.FindControl("lblSlot23Total");
                if (Total_Slot23 != 0)
                    lblSlot23Total.Text = Total_Slot23.ToString();

                Label lblSlot24Total = (Label)e.Row.FindControl("lblSlot24Total");
                if (Total_Slot24 != 0)
                    lblSlot24Total.Text = Total_Slot24.ToString();


                 Total_Slot1 = 0;
                 Total_Slot2 = 0;
                 Total_Slot3 = 0;
                 Total_Slot4 = 0;
                 Total_Slot5 = 0;
                 Total_Slot6 = 0;
                 Total_Slot7 = 0;
                 Total_Slot8 = 0;
                 Total_Slot9 = 0;
                 Total_Slot10 = 0;
                 Total_Slot11 = 0;
                 Total_Slot12 = 0;
                 Total_Slot13 = 0;
                 Total_Slot14 = 0;
                 Total_Slot15 = 0;
                 Total_Slot16 = 0;
                 Total_Slot17 = 0;
                 Total_Slot18 = 0;
                 Total_Slot19 = 0;
                 Total_Slot20 = 0;
                 Total_Slot21 = 0;
                 Total_Slot22 = 0;
                 Total_Slot23 = 0;
                 Total_Slot24 = 0;
               
            }
        }

        protected void gvHourlyFinishingReport2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sUnitName = "C 45-46";
            DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblSlot1Time = (Label)e.Row.FindControl("lblSlot1Time");
                lblSlot1Time.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

                Label lblSlot2Time = (Label)e.Row.FindControl("lblSlot2Time");
                lblSlot2Time.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

                Label lblSlot3Time = (Label)e.Row.FindControl("lblSlot3Time");
                lblSlot3Time.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

                Label lblSlot4Time = (Label)e.Row.FindControl("lblSlot4Time");
                lblSlot4Time.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

                Label lblSlot5Time = (Label)e.Row.FindControl("lblSlot5Time");
                lblSlot5Time.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

                Label lblSlot6Time = (Label)e.Row.FindControl("lblSlot6Time");
                lblSlot6Time.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

                Label lblSlot7Time = (Label)e.Row.FindControl("lblSlot7Time");
                lblSlot7Time.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

                Label lblSlot8Time = (Label)e.Row.FindControl("lblSlot8Time");
                lblSlot8Time.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

                Label lblSlot9Time = (Label)e.Row.FindControl("lblSlot9Time");
                lblSlot9Time.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

                Label lblSlot10Time = (Label)e.Row.FindControl("lblSlot10Time");
                lblSlot10Time.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

                Label lblSlot11Time = (Label)e.Row.FindControl("lblSlot11Time");
                lblSlot11Time.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

                Label lblSlot12Time = (Label)e.Row.FindControl("lblSlot12Time");
                lblSlot12Time.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

                Label lblSlot13Time = (Label)e.Row.FindControl("lblSlot13Time");
                lblSlot13Time.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

                Label lblSlot14Time = (Label)e.Row.FindControl("lblSlot14Time");
                lblSlot14Time.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

                Label lblSlot15Time = (Label)e.Row.FindControl("lblSlot15Time");
                lblSlot15Time.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

                Label lblSlot16Time = (Label)e.Row.FindControl("lblSlot16Time");
                lblSlot16Time.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();

                Label lblSlot17Time = (Label)e.Row.FindControl("lblSlot17Time");
                lblSlot17Time.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

                Label lblSlot18Time = (Label)e.Row.FindControl("lblSlot18Time");
                lblSlot18Time.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

                Label lblSlot19Time = (Label)e.Row.FindControl("lblSlot19Time");
                lblSlot19Time.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

                Label lblSlot20Time = (Label)e.Row.FindControl("lblSlot20Time");
                lblSlot20Time.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

                Label lblSlot21Time = (Label)e.Row.FindControl("lblSlot21Time");
                lblSlot21Time.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

                Label lblSlot22Time = (Label)e.Row.FindControl("lblSlot22Time");
                lblSlot22Time.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

                Label lblSlot23Time = (Label)e.Row.FindControl("lblSlot23Time");
                lblSlot23Time.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();

                Label lblSlot24Time = (Label)e.Row.FindControl("lblSlot24Time");
                lblSlot24Time.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();                

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                if (hdnStyleId != null)
                    StyleId = Convert.ToInt32(hdnStyleId.Value);

                DataSet ds;
                ds = objProductionController.GetHourlyFinishingReport(sUnitName, StyleId, "Designation");
                Repeater rptDesignation = e.Row.FindControl("rptDesignation") as Repeater;
                rptDesignation.DataSource = ds.Tables[0];
                rptDesignation.DataBind();

                Total_Slot1 += DataBinder.Eval(e.Row.DataItem, "Slot1Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Pass"));
                Total_Slot2 += DataBinder.Eval(e.Row.DataItem, "Slot2Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Pass"));
                Total_Slot3 += DataBinder.Eval(e.Row.DataItem, "Slot3Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Pass"));
                Total_Slot4 += DataBinder.Eval(e.Row.DataItem, "Slot4Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Pass"));
                Total_Slot5 += DataBinder.Eval(e.Row.DataItem, "Slot5Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Pass"));
                Total_Slot6 += DataBinder.Eval(e.Row.DataItem, "Slot6Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Pass"));
                Total_Slot7 += DataBinder.Eval(e.Row.DataItem, "Slot7Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Pass"));
                Total_Slot8 += DataBinder.Eval(e.Row.DataItem, "Slot8Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Pass"));
                Total_Slot9 += DataBinder.Eval(e.Row.DataItem, "Slot9Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Pass"));
                Total_Slot10 += DataBinder.Eval(e.Row.DataItem, "Slot10Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Pass"));
                Total_Slot11 += DataBinder.Eval(e.Row.DataItem, "Slot11Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Pass"));
                Total_Slot12 += DataBinder.Eval(e.Row.DataItem, "Slot12Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Pass"));
                Total_Slot13 += DataBinder.Eval(e.Row.DataItem, "Slot13Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Pass"));
                Total_Slot14 += DataBinder.Eval(e.Row.DataItem, "Slot14Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Pass"));
                Total_Slot15 += DataBinder.Eval(e.Row.DataItem, "Slot15Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Pass"));
                Total_Slot16 += DataBinder.Eval(e.Row.DataItem, "Slot16Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Pass"));
                Total_Slot17 += DataBinder.Eval(e.Row.DataItem, "Slot17Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Pass"));
                Total_Slot18 += DataBinder.Eval(e.Row.DataItem, "Slot18Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Pass"));
                Total_Slot19 += DataBinder.Eval(e.Row.DataItem, "Slot19Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Pass"));
                Total_Slot20 += DataBinder.Eval(e.Row.DataItem, "Slot20Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Pass"));
                Total_Slot21 += DataBinder.Eval(e.Row.DataItem, "Slot21Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Pass"));
                Total_Slot22 += DataBinder.Eval(e.Row.DataItem, "Slot22Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Pass"));
                Total_Slot23 += DataBinder.Eval(e.Row.DataItem, "Slot23Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Pass"));
                Total_Slot24 += DataBinder.Eval(e.Row.DataItem, "Slot24Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Pass"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSlot1Total = (Label)e.Row.FindControl("lblSlot1Total");
                if(Total_Slot1 != 0)
                lblSlot1Total.Text = Total_Slot1.ToString();

                Label lblSlot2Total = (Label)e.Row.FindControl("lblSlot2Total");
                if (Total_Slot2 != 0)
                    lblSlot2Total.Text = Total_Slot2.ToString();

                Label lblSlot3Total = (Label)e.Row.FindControl("lblSlot3Total");
                if (Total_Slot3 != 0)
                    lblSlot3Total.Text = Total_Slot3.ToString();

                Label lblSlot4Total = (Label)e.Row.FindControl("lblSlot4Total");
                if (Total_Slot4 != 0)
                    lblSlot4Total.Text = Total_Slot4.ToString();

                Label lblSlot5Total = (Label)e.Row.FindControl("lblSlot5Total");
                if (Total_Slot5 != 0)
                    lblSlot5Total.Text = Total_Slot5.ToString();

                Label lblSlot6Total = (Label)e.Row.FindControl("lblSlot6Total");
                if (Total_Slot6 != 0)
                    lblSlot6Total.Text = Total_Slot6.ToString();

                Label lblSlot7Total = (Label)e.Row.FindControl("lblSlot7Total");
                if (Total_Slot7 != 0)
                    lblSlot7Total.Text = Total_Slot7.ToString();

                Label lblSlot8Total = (Label)e.Row.FindControl("lblSlot8Total");
                if (Total_Slot8 != 0)
                    lblSlot8Total.Text = Total_Slot8.ToString();

                Label lblSlot9Total = (Label)e.Row.FindControl("lblSlot9Total");
                if (Total_Slot9 != 0)
                    lblSlot9Total.Text = Total_Slot9.ToString();

                Label lblSlot10Total = (Label)e.Row.FindControl("lblSlot10Total");
                if (Total_Slot10 != 0)
                    lblSlot10Total.Text = Total_Slot10.ToString();

                Label lblSlot11Total = (Label)e.Row.FindControl("lblSlot11Total");
                if (Total_Slot11 != 0)
                    lblSlot11Total.Text = Total_Slot11.ToString();

                Label lblSlot12Total = (Label)e.Row.FindControl("lblSlot12Total");
                if (Total_Slot12 != 0)
                    lblSlot12Total.Text = Total_Slot12.ToString();

                Label lblSlot13Total = (Label)e.Row.FindControl("lblSlot13Total");
                if (Total_Slot13 != 0)
                    lblSlot13Total.Text = Total_Slot13.ToString();

                Label lblSlot14Total = (Label)e.Row.FindControl("lblSlot14Total");
                if (Total_Slot14 != 0)
                    lblSlot14Total.Text = Total_Slot14.ToString();

                Label lblSlot15Total = (Label)e.Row.FindControl("lblSlot15Total");
                if (Total_Slot15 != 0)
                    lblSlot15Total.Text = Total_Slot15.ToString();

                Label lblSlot16Total = (Label)e.Row.FindControl("lblSlot16Total");
                if (Total_Slot16 != 0)
                    lblSlot16Total.Text = Total_Slot16.ToString();

                Label lblSlot17Total = (Label)e.Row.FindControl("lblSlot17Total");
                if (Total_Slot17 != 0)
                    lblSlot17Total.Text = Total_Slot17.ToString();

                Label lblSlot18Total = (Label)e.Row.FindControl("lblSlot18Total");
                if (Total_Slot18 != 0)
                    lblSlot18Total.Text = Total_Slot18.ToString();

                Label lblSlot19Total = (Label)e.Row.FindControl("lblSlot19Total");
                if (Total_Slot19 != 0)
                    lblSlot19Total.Text = Total_Slot19.ToString();

                Label lblSlot20Total = (Label)e.Row.FindControl("lblSlot20Total");
                if (Total_Slot20 != 0)
                    lblSlot20Total.Text = Total_Slot20.ToString();

                Label lblSlot21Total = (Label)e.Row.FindControl("lblSlot21Total");
                if (Total_Slot21 != 0)
                    lblSlot21Total.Text = Total_Slot21.ToString();

                Label lblSlot22Total = (Label)e.Row.FindControl("lblSlot22Total");
                if (Total_Slot22 != 0)
                    lblSlot22Total.Text = Total_Slot22.ToString();

                Label lblSlot23Total = (Label)e.Row.FindControl("lblSlot23Total");
                if (Total_Slot23 != 0)
                    lblSlot23Total.Text = Total_Slot23.ToString();

                Label lblSlot24Total = (Label)e.Row.FindControl("lblSlot24Total");
                if (Total_Slot24 != 0)
                    lblSlot24Total.Text = Total_Slot24.ToString();


                 Total_Slot1 = 0;
                 Total_Slot2 = 0;
                 Total_Slot3 = 0;
                 Total_Slot4 = 0;
                 Total_Slot5 = 0;
                 Total_Slot6 = 0;
                 Total_Slot7 = 0;
                 Total_Slot8 = 0;
                 Total_Slot9 = 0;
                 Total_Slot10 = 0;
                 Total_Slot11 = 0;
                 Total_Slot12 = 0;
                 Total_Slot13 = 0;
                 Total_Slot14 = 0;
                 Total_Slot15 = 0;
                 Total_Slot16 = 0;
                 Total_Slot17 = 0;
                 Total_Slot18 = 0;
                 Total_Slot19 = 0;
                 Total_Slot20 = 0;
                 Total_Slot21 = 0;
                 Total_Slot22 = 0;
                 Total_Slot23 = 0;
                 Total_Slot24 = 0;               
            
            }
        }

        protected void gvHourlyFinishingReport3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sUnitName = "B 45";
            DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblSlot1Time = (Label)e.Row.FindControl("lblSlot1Time");
                lblSlot1Time.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

                Label lblSlot2Time = (Label)e.Row.FindControl("lblSlot2Time");
                lblSlot2Time.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

                Label lblSlot3Time = (Label)e.Row.FindControl("lblSlot3Time");
                lblSlot3Time.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

                Label lblSlot4Time = (Label)e.Row.FindControl("lblSlot4Time");
                lblSlot4Time.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

                Label lblSlot5Time = (Label)e.Row.FindControl("lblSlot5Time");
                lblSlot5Time.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

                Label lblSlot6Time = (Label)e.Row.FindControl("lblSlot6Time");
                lblSlot6Time.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

                Label lblSlot7Time = (Label)e.Row.FindControl("lblSlot7Time");
                lblSlot7Time.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

                Label lblSlot8Time = (Label)e.Row.FindControl("lblSlot8Time");
                lblSlot8Time.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

                Label lblSlot9Time = (Label)e.Row.FindControl("lblSlot9Time");
                lblSlot9Time.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

                Label lblSlot10Time = (Label)e.Row.FindControl("lblSlot10Time");
                lblSlot10Time.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

                Label lblSlot11Time = (Label)e.Row.FindControl("lblSlot11Time");
                lblSlot11Time.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

                Label lblSlot12Time = (Label)e.Row.FindControl("lblSlot12Time");
                lblSlot12Time.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

                Label lblSlot13Time = (Label)e.Row.FindControl("lblSlot13Time");
                lblSlot13Time.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

                Label lblSlot14Time = (Label)e.Row.FindControl("lblSlot14Time");
                lblSlot14Time.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

                Label lblSlot15Time = (Label)e.Row.FindControl("lblSlot15Time");
                lblSlot15Time.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

                Label lblSlot16Time = (Label)e.Row.FindControl("lblSlot16Time");
                lblSlot16Time.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();

                Label lblSlot17Time = (Label)e.Row.FindControl("lblSlot17Time");
                lblSlot17Time.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

                Label lblSlot18Time = (Label)e.Row.FindControl("lblSlot18Time");
                lblSlot18Time.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

                Label lblSlot19Time = (Label)e.Row.FindControl("lblSlot19Time");
                lblSlot19Time.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

                Label lblSlot20Time = (Label)e.Row.FindControl("lblSlot20Time");
                lblSlot20Time.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

                Label lblSlot21Time = (Label)e.Row.FindControl("lblSlot21Time");
                lblSlot21Time.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

                Label lblSlot22Time = (Label)e.Row.FindControl("lblSlot22Time");
                lblSlot22Time.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

                Label lblSlot23Time = (Label)e.Row.FindControl("lblSlot23Time");
                lblSlot23Time.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();

                Label lblSlot24Time = (Label)e.Row.FindControl("lblSlot24Time");
                lblSlot24Time.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();                

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                if (hdnStyleId != null)
                    StyleId = Convert.ToInt32(hdnStyleId.Value);

                DataSet ds;
                ds = objProductionController.GetHourlyFinishingReport(sUnitName, StyleId, "Designation");
                Repeater rptDesignation = e.Row.FindControl("rptDesignation") as Repeater;
                rptDesignation.DataSource = ds.Tables[0];
                rptDesignation.DataBind();

                Total_Slot1 += DataBinder.Eval(e.Row.DataItem, "Slot1Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Pass"));
                Total_Slot2 += DataBinder.Eval(e.Row.DataItem, "Slot2Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Pass"));
                Total_Slot3 += DataBinder.Eval(e.Row.DataItem, "Slot3Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Pass"));
                Total_Slot4 += DataBinder.Eval(e.Row.DataItem, "Slot4Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Pass"));
                Total_Slot5 += DataBinder.Eval(e.Row.DataItem, "Slot5Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Pass"));
                Total_Slot6 += DataBinder.Eval(e.Row.DataItem, "Slot6Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Pass"));
                Total_Slot7 += DataBinder.Eval(e.Row.DataItem, "Slot7Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Pass"));
                Total_Slot8 += DataBinder.Eval(e.Row.DataItem, "Slot8Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Pass"));
                Total_Slot9 += DataBinder.Eval(e.Row.DataItem, "Slot9Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Pass"));
                Total_Slot10 += DataBinder.Eval(e.Row.DataItem, "Slot10Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Pass"));
                Total_Slot11 += DataBinder.Eval(e.Row.DataItem, "Slot11Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Pass"));
                Total_Slot12 += DataBinder.Eval(e.Row.DataItem, "Slot12Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Pass"));
                Total_Slot13 += DataBinder.Eval(e.Row.DataItem, "Slot13Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Pass"));
                Total_Slot14 += DataBinder.Eval(e.Row.DataItem, "Slot14Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Pass"));
                Total_Slot15 += DataBinder.Eval(e.Row.DataItem, "Slot15Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Pass"));
                Total_Slot16 += DataBinder.Eval(e.Row.DataItem, "Slot16Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Pass"));
                Total_Slot17 += DataBinder.Eval(e.Row.DataItem, "Slot17Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Pass"));
                Total_Slot18 += DataBinder.Eval(e.Row.DataItem, "Slot18Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Pass"));
                Total_Slot19 += DataBinder.Eval(e.Row.DataItem, "Slot19Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Pass"));
                Total_Slot20 += DataBinder.Eval(e.Row.DataItem, "Slot20Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Pass"));
                Total_Slot21 += DataBinder.Eval(e.Row.DataItem, "Slot21Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Pass"));
                Total_Slot22 += DataBinder.Eval(e.Row.DataItem, "Slot22Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Pass"));
                Total_Slot23 += DataBinder.Eval(e.Row.DataItem, "Slot23Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Pass"));
                Total_Slot24 += DataBinder.Eval(e.Row.DataItem, "Slot24Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Pass"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSlot1Total = (Label)e.Row.FindControl("lblSlot1Total");
                if(Total_Slot1 != 0)
                lblSlot1Total.Text = Total_Slot1.ToString();

                Label lblSlot2Total = (Label)e.Row.FindControl("lblSlot2Total");
                if (Total_Slot2 != 0)
                    lblSlot2Total.Text = Total_Slot2.ToString();

                Label lblSlot3Total = (Label)e.Row.FindControl("lblSlot3Total");
                if (Total_Slot3 != 0)
                    lblSlot3Total.Text = Total_Slot3.ToString();

                Label lblSlot4Total = (Label)e.Row.FindControl("lblSlot4Total");
                if (Total_Slot4 != 0)
                    lblSlot4Total.Text = Total_Slot4.ToString();

                Label lblSlot5Total = (Label)e.Row.FindControl("lblSlot5Total");
                if (Total_Slot5 != 0)
                    lblSlot5Total.Text = Total_Slot5.ToString();

                Label lblSlot6Total = (Label)e.Row.FindControl("lblSlot6Total");
                if (Total_Slot6 != 0)
                    lblSlot6Total.Text = Total_Slot6.ToString();

                Label lblSlot7Total = (Label)e.Row.FindControl("lblSlot7Total");
                if (Total_Slot7 != 0)
                    lblSlot7Total.Text = Total_Slot7.ToString();

                Label lblSlot8Total = (Label)e.Row.FindControl("lblSlot8Total");
                if (Total_Slot8 != 0)
                    lblSlot8Total.Text = Total_Slot8.ToString();

                Label lblSlot9Total = (Label)e.Row.FindControl("lblSlot9Total");
                if (Total_Slot9 != 0)
                    lblSlot9Total.Text = Total_Slot9.ToString();

                Label lblSlot10Total = (Label)e.Row.FindControl("lblSlot10Total");
                if (Total_Slot10 != 0)
                    lblSlot10Total.Text = Total_Slot10.ToString();

                Label lblSlot11Total = (Label)e.Row.FindControl("lblSlot11Total");
                if (Total_Slot11 != 0)
                    lblSlot11Total.Text = Total_Slot11.ToString();

                Label lblSlot12Total = (Label)e.Row.FindControl("lblSlot12Total");
                if (Total_Slot12 != 0)
                    lblSlot12Total.Text = Total_Slot12.ToString();

                Label lblSlot13Total = (Label)e.Row.FindControl("lblSlot13Total");
                if (Total_Slot13 != 0)
                    lblSlot13Total.Text = Total_Slot13.ToString();

                Label lblSlot14Total = (Label)e.Row.FindControl("lblSlot14Total");
                if (Total_Slot14 != 0)
                    lblSlot14Total.Text = Total_Slot14.ToString();

                Label lblSlot15Total = (Label)e.Row.FindControl("lblSlot15Total");
                if (Total_Slot15 != 0)
                    lblSlot15Total.Text = Total_Slot15.ToString();

                Label lblSlot16Total = (Label)e.Row.FindControl("lblSlot16Total");
                if (Total_Slot16 != 0)
                    lblSlot16Total.Text = Total_Slot16.ToString();

                Label lblSlot17Total = (Label)e.Row.FindControl("lblSlot17Total");
                if (Total_Slot17 != 0)
                    lblSlot17Total.Text = Total_Slot17.ToString();

                Label lblSlot18Total = (Label)e.Row.FindControl("lblSlot18Total");
                if (Total_Slot18 != 0)
                    lblSlot18Total.Text = Total_Slot18.ToString();

                Label lblSlot19Total = (Label)e.Row.FindControl("lblSlot19Total");
                if (Total_Slot19 != 0)
                    lblSlot19Total.Text = Total_Slot19.ToString();

                Label lblSlot20Total = (Label)e.Row.FindControl("lblSlot20Total");
                if (Total_Slot20 != 0)
                    lblSlot20Total.Text = Total_Slot20.ToString();

                Label lblSlot21Total = (Label)e.Row.FindControl("lblSlot21Total");
                if (Total_Slot21 != 0)
                    lblSlot21Total.Text = Total_Slot21.ToString();

                Label lblSlot22Total = (Label)e.Row.FindControl("lblSlot22Total");
                if (Total_Slot22 != 0)
                    lblSlot22Total.Text = Total_Slot22.ToString();

                Label lblSlot23Total = (Label)e.Row.FindControl("lblSlot23Total");
                if (Total_Slot23 != 0)
                    lblSlot23Total.Text = Total_Slot23.ToString();

                Label lblSlot24Total = (Label)e.Row.FindControl("lblSlot24Total");
                if (Total_Slot24 != 0)
                    lblSlot24Total.Text = Total_Slot24.ToString();


                 Total_Slot1 = 0;
                 Total_Slot2 = 0;
                 Total_Slot3 = 0;
                 Total_Slot4 = 0;
                 Total_Slot5 = 0;
                 Total_Slot6 = 0;
                 Total_Slot7 = 0;
                 Total_Slot8 = 0;
                 Total_Slot9 = 0;
                 Total_Slot10 = 0;
                 Total_Slot11 = 0;
                 Total_Slot12 = 0;
                 Total_Slot13 = 0;
                 Total_Slot14 = 0;
                 Total_Slot15 = 0;
                 Total_Slot16 = 0;
                 Total_Slot17 = 0;
                 Total_Slot18 = 0;
                 Total_Slot19 = 0;
                 Total_Slot20 = 0;
                 Total_Slot21 = 0;
                 Total_Slot22 = 0;
                 Total_Slot23 = 0;
                 Total_Slot24 = 0;
                           
            }
        }

        protected void gvHourlyFinishingReport1_DataBound(object sender, EventArgs e)
        {
            for (int i = gvHourlyFinishingReport1.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvHourlyFinishingReport1.Rows[i];
                GridViewRow previousRow = gvHourlyFinishingReport1.Rows[i - 1];

                HiddenField hdnStyleId = (HiddenField)row.FindControl("hdnStyleId");

                HiddenField hdnPrevStyleId = (HiddenField)previousRow.FindControl("hdnStyleId");

                if (hdnStyleId.Value == hdnPrevStyleId.Value)
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

        protected void gvHourlyFinishingReport2_DataBound(object sender, EventArgs e)
        {
            for (int i = gvHourlyFinishingReport2.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvHourlyFinishingReport2.Rows[i];
                GridViewRow previousRow = gvHourlyFinishingReport2.Rows[i - 1];

                HiddenField hdnStyleId = (HiddenField)row.FindControl("hdnStyleId");

                HiddenField hdnPrevStyleId = (HiddenField)previousRow.FindControl("hdnStyleId");

                if (hdnStyleId.Value == hdnPrevStyleId.Value)
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

        protected void gvHourlyFinishingReport3_DataBound(object sender, EventArgs e)
        {
            for (int i = gvHourlyFinishingReport3.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvHourlyFinishingReport3.Rows[i];
                GridViewRow previousRow = gvHourlyFinishingReport3.Rows[i - 1];

                HiddenField hdnStyleId = (HiddenField)row.FindControl("hdnStyleId");

                HiddenField hdnPrevStyleId = (HiddenField)previousRow.FindControl("hdnStyleId");

                if (hdnStyleId.Value == hdnPrevStyleId.Value)
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

        #endregion

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    //
        //}
                      
       

        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            StringWriter strWriter = new StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string strMailBody = GetGridviewData(gvHourlyStitchingReport1);
        }

        

   
   }
}