using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Forms
{
    public partial class factory_line_slot_target_achievement : System.Web.UI.UserControl
    {
        AdminController odjadminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindReport();
        }
        public void BindReport()
        {
            DataSet ds = new DataSet();
            DataTable dtfactoryDate = new DataTable();
            ds = odjadminController.getFactorySpecificlineTargetActual();
            dtfactoryDate = ds.Tables[0];
            grdFactorytargetActualDate.DataSource = dtfactoryDate;
            grdFactorytargetActualDate.DataBind();

            grdC4546FactorytargetActual.DataSource = dtfactoryDate;
            grdC4546FactorytargetActual.DataBind();

            DataSet dsC47 = new DataSet();
            DataTable dtfactoryDateC47 = new DataTable();
            dsC47 = odjadminController.getFactorySpecificlineTargetActual();
            dtfactoryDateC47 = dsC47.Tables[1];
            grdC47FactorytargetActual.DataSource = dtfactoryDateC47;
            grdC47FactorytargetActual.DataBind();



            DataSet dsBipl = new DataSet();
            DataTable dtfactoryDateBipl = new DataTable();
            dsBipl = odjadminController.getFactorySpecificlineTargetActual();
            dtfactoryDateBipl = dsBipl.Tables[2];
            grdFactorytargetActualBipl.DataSource = dtfactoryDateBipl;
            grdFactorytargetActualBipl.DataBind();





            DataSet dsSlot = new DataSet();
            DataTable dtfactorySlot = new DataTable();
            dsSlot = odjadminController.getFactorySlotSpecificlineTargetActual();
            dtfactorySlot = dsSlot.Tables[0];
            grdFactorytargetSlot.DataSource = dtfactorySlot;
            grdFactorytargetSlot.DataBind();

            grdC4546FactorytargetActualSlot.DataSource = dtfactorySlot;
            grdC4546FactorytargetActualSlot.DataBind();

            DataSet dsSlotC47 = new DataSet();
            DataTable dtSlotfactoryDateC47 = new DataTable();
            dsSlotC47 = odjadminController.getFactorySlotSpecificlineTargetActual();
            dtSlotfactoryDateC47 = dsSlotC47.Tables[1];
            grdC47FactorytargetActualSlot.DataSource = dtSlotfactoryDateC47;
            grdC47FactorytargetActualSlot.DataBind();



            DataSet dsSlotBipl = new DataSet();
            DataTable dtSlotfactoryDateBipl = new DataTable();
            dsSlotBipl = odjadminController.getFactorySlotSpecificlineTargetActual();
            dtSlotfactoryDateBipl = dsSlotBipl.Tables[2];
            grdFactorytargetActualBiplSlot.DataSource = dtSlotfactoryDateBipl;
            grdFactorytargetActualBiplSlot.DataBind();

        }


        protected void grdFactorytargetActualDate_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Label lblFactorytargetActualDate = (Label)e.Row.FindControl("lblFactorytargetActualDate");
        }

        protected void grdC4546FactorytargetActual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblC4546FactoryAchLine1 = (Label)e.Row.FindControl("lblC4546FactoryAchLine1");
            Label lblC4546FactoryAchLine2 = (Label)e.Row.FindControl("lblC4546FactoryAchLine2");
            Label lblC4546FactoryAchLine3 = (Label)e.Row.FindControl("lblC4546FactoryAchLine3");
            Label lblC4546FactoryAchLine4 = (Label)e.Row.FindControl("lblC4546FactoryAchLine4");
            Label lblC4546FactoryAchLine5 = (Label)e.Row.FindControl("lblC4546FactoryAchLine5");
            Label lblC4546FactoryAchLine6 = (Label)e.Row.FindControl("lblC4546FactoryAchLine6");
            Label lblC4546FactoryAchLine7 = (Label)e.Row.FindControl("lblC4546FactoryAchLine7");
            Label lblC4546FactoryAchLine8 = (Label)e.Row.FindControl("lblC4546FactoryAchLine8");
            Label lblC4546FactoryAchLine9 = (Label)e.Row.FindControl("lblC4546FactoryAchLine9");
            Label lblC4546FactoryAchLine10 = (Label)e.Row.FindControl("lblC4546FactoryAchLine10");
            Label lblC4546FactoryAchLine11 = (Label)e.Row.FindControl("lblC4546FactoryAchLine11");
            Label lblC4546FactoryAchLine12 = (Label)e.Row.FindControl("lblC4546FactoryAchLine12");
            Label lblC4546FactoryAchLine13 = (Label)e.Row.FindControl("lblC4546FactoryAchLine13");
            Label lblC4546FactoryAchLine14 = (Label)e.Row.FindControl("lblC4546FactoryAchLine14");
            Label lblC4546FactoryAchLine15 = (Label)e.Row.FindControl("lblC4546FactoryAchLine15");
            Label lblC4546FactoryTgtTotal = (Label)e.Row.FindControl("lblC4546FactoryTgtTotal");
            Label lblC4546FactoryActTotal = (Label)e.Row.FindControl("lblC4546FactoryActTotal");
            Label lblC4546FactoryAchTotal = (Label)e.Row.FindControl("lblC4546FactoryAchTotal");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lblC4546FactoryAchLine1.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[0].Visible = false;
                }
                if (lblC4546FactoryAchLine2.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[1].Visible = false;
                }
                if (lblC4546FactoryAchLine3.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[2].Visible = false;
                }
                if (lblC4546FactoryAchLine4.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[3].Visible = false;
                }
                if (lblC4546FactoryAchLine5.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[4].Visible = false;
                }
                if (lblC4546FactoryAchLine6.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[5].Visible = false;
                }
                if (lblC4546FactoryAchLine7.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[6].Visible = false;
                }
                if (lblC4546FactoryAchLine8.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[7].Visible = false;
                }
                if (lblC4546FactoryAchLine9.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[8].Visible = false;
                }
                if (lblC4546FactoryAchLine10.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[9].Visible = false;
                }
                if (lblC4546FactoryAchLine11.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[10].Visible = false;
                }
                if (lblC4546FactoryAchLine12.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[11].Visible = false;
                }
                if (lblC4546FactoryAchLine13.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[12].Visible = false;
                }
                if (lblC4546FactoryAchLine14.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[13].Visible = false;
                }
                if (lblC4546FactoryAchLine15.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[14].Visible = false;
                }



                if (lblC4546FactoryAchLine1.Text == "")
                {
                    lblC4546FactoryAchLine1.Text = "";
                }
                if (lblC4546FactoryAchLine2.Text == "")
                {
                    lblC4546FactoryAchLine2.Text = "";
                }
                if (lblC4546FactoryAchLine3.Text == "")
                {
                    lblC4546FactoryAchLine3.Text = "";
                }
                if (lblC4546FactoryAchLine4.Text == "0")
                {
                    lblC4546FactoryAchLine4.Text = "";
                }
                if (lblC4546FactoryAchLine5.Text == "0")
                {
                    lblC4546FactoryAchLine5.Text = "";
                }
                if (lblC4546FactoryAchLine6.Text == "0")
                {
                    lblC4546FactoryAchLine6.Text = "";
                }
                if (lblC4546FactoryAchLine7.Text == "0")
                {
                    lblC4546FactoryAchLine7.Text = "";
                }
                if (lblC4546FactoryAchLine8.Text == "0")
                {
                    lblC4546FactoryAchLine8.Text = "";
                }
                if (lblC4546FactoryAchLine9.Text == "0")
                {
                    lblC4546FactoryAchLine9.Text = "";
                }
                if (lblC4546FactoryAchLine10.Text == "0")
                {
                    lblC4546FactoryAchLine10.Text = "";
                }
                if (lblC4546FactoryAchLine11.Text == "0")
                {
                    lblC4546FactoryAchLine11.Text = "";
                }
                if (lblC4546FactoryAchLine12.Text == "0")
                {
                    lblC4546FactoryAchLine12.Text = "";
                }
                if (lblC4546FactoryAchLine13.Text == "0")
                {
                    lblC4546FactoryAchLine13.Text = "";
                }
                if (lblC4546FactoryAchLine14.Text == "0")
                {
                    lblC4546FactoryAchLine14.Text = "";
                }
                if (lblC4546FactoryAchLine15.Text == "0")
                {
                    lblC4546FactoryAchLine15.Text = "";
                }
            }


        }

        protected void grdC47FactorytargetActual_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Label lblC47FactoryAchLine1 = (Label)e.Row.FindControl("lblC47FactoryAchLine1");
            Label lblC47FactoryAchLine2 = (Label)e.Row.FindControl("lblC47FactoryAchLine2");
            Label lblC47FactoryAchLine3 = (Label)e.Row.FindControl("lblC47FactoryAchLine3");
            Label lblC47FactoryAchLine4 = (Label)e.Row.FindControl("lblC47FactoryAchLine4");
            Label lblC47FactoryAchLine5 = (Label)e.Row.FindControl("lblC47FactoryAchLine5");
            Label lblC47FactoryAchLine6 = (Label)e.Row.FindControl("lblC47FactoryAchLine6");
            Label lblC47FactoryAchLine7 = (Label)e.Row.FindControl("lblC47FactoryAchLine7");
            Label lblC47FactoryAchLine8 = (Label)e.Row.FindControl("lblC47FactoryAchLine8");
            Label lblC47FactoryAchLine9 = (Label)e.Row.FindControl("lblC47FactoryAchLine9");
            Label lblC47FactoryAchLine10 = (Label)e.Row.FindControl("lblC47FactoryAchLine10");
            Label lblC47FactoryAchLine11 = (Label)e.Row.FindControl("lblC47FactoryAchLine11");
            Label lblC47FactoryAchLine12 = (Label)e.Row.FindControl("lblC47FactoryAchLine12");
            Label lblC47FactoryAchLine13 = (Label)e.Row.FindControl("lblC47FactoryAchLine13");
            Label lblC47FactoryAchLine14 = (Label)e.Row.FindControl("lblC47FactoryAchLine14");
            Label lblC47FactoryAchLine15 = (Label)e.Row.FindControl("lblC47FactoryAchLine15");
            Label lblC47FactoryTgtTotal = (Label)e.Row.FindControl("lblC47FactoryTgtTotal");
            Label lblC47FactoryActTotal = (Label)e.Row.FindControl("lblC47FactoryActTotal");
            Label lblC47FactoryAchTotal = (Label)e.Row.FindControl("lblC47FactoryAchTotal");


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lblC47FactoryAchLine1.Text == "")
                {
                    grdC47FactorytargetActual.Columns[0].Visible = false;
                }
                if (lblC47FactoryAchLine2.Text == "")
                {
                    grdC47FactorytargetActual.Columns[1].Visible = false;
                }
                if (lblC47FactoryAchLine3.Text == "")
                {
                    grdC47FactorytargetActual.Columns[2].Visible = false;
                }
                if (lblC47FactoryAchLine4.Text == "")
                {
                    grdC47FactorytargetActual.Columns[3].Visible = false;
                }
                if (lblC47FactoryAchLine5.Text == "")
                {
                    grdC47FactorytargetActual.Columns[4].Visible = false;
                }
                if (lblC47FactoryAchLine6.Text == "")
                {
                    grdC47FactorytargetActual.Columns[5].Visible = false;
                }
                if (lblC47FactoryAchLine7.Text == "")
                {
                    grdC47FactorytargetActual.Columns[6].Visible = false;
                }
                if (lblC47FactoryAchLine8.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[7].Visible = false;
                }
                if (lblC47FactoryAchLine9.Text == "")
                {
                    grdC47FactorytargetActual.Columns[8].Visible = false;
                }
                if (lblC47FactoryAchLine10.Text == "")
                {
                    grdC47FactorytargetActual.Columns[9].Visible = false;
                }
                if (lblC47FactoryAchLine11.Text == "")
                {
                    grdC47FactorytargetActual.Columns[10].Visible = false;
                }
                if (lblC47FactoryAchLine12.Text == "")
                {
                    grdC47FactorytargetActual.Columns[11].Visible = false;
                }
                if (lblC47FactoryAchLine13.Text == "")
                {
                    grdC47FactorytargetActual.Columns[12].Visible = false;
                }
                if (lblC47FactoryAchLine14.Text == "")
                {
                    grdC47FactorytargetActual.Columns[13].Visible = false;
                }
                if (lblC47FactoryAchLine15.Text == "")
                {
                    grdC47FactorytargetActual.Columns[14].Visible = false;
                }

                if (lblC47FactoryAchLine1.Text == "")
                {
                    lblC47FactoryAchLine1.Text = "";
                }
                if (lblC47FactoryAchLine2.Text == "0")
                {
                    lblC47FactoryAchLine2.Text = "";
                }
                if (lblC47FactoryAchLine3.Text == "0")
                {
                    lblC47FactoryAchLine3.Text = "";
                }
                if (lblC47FactoryAchLine4.Text == "0")
                {
                    lblC47FactoryAchLine4.Text = "";
                }
                if (lblC47FactoryAchLine5.Text == "")
                {
                    lblC47FactoryAchLine5.Text = "";
                }
                if (lblC47FactoryAchLine6.Text == "")
                {
                    lblC47FactoryAchLine6.Text = "";
                }
                if (lblC47FactoryAchLine7.Text == "0")
                {
                    lblC47FactoryAchLine7.Text = "";
                }
                if (lblC47FactoryAchLine8.Text == "0")
                {
                    lblC47FactoryAchLine8.Text = "";
                }
                if (lblC47FactoryAchLine9.Text == "0")
                {
                    lblC47FactoryAchLine9.Text = "";
                }
                if (lblC47FactoryAchLine10.Text == "0")
                {
                    lblC47FactoryAchLine10.Text = "";
                }
                if (lblC47FactoryAchLine11.Text == "0")
                {
                    lblC47FactoryAchLine11.Text = "";
                }
                if (lblC47FactoryAchLine12.Text == "0")
                {
                    lblC47FactoryAchLine12.Text = "";
                }
                if (lblC47FactoryAchLine13.Text == "")
                {
                    lblC47FactoryAchLine13.Text = "";
                }
                if (lblC47FactoryAchLine14.Text == "0")
                {
                    lblC47FactoryAchLine14.Text = "";
                }
                if (lblC47FactoryAchLine15.Text == "0")
                {
                    lblC47FactoryAchLine15.Text = "";
                }
            }
        }

        protected void grdFactorytargetActualBipl_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Label lblFactorytargetActualBiplTgt = (Label)e.Row.FindControl("lblFactorytargetActualBiplTgt");
            Label lblFactorytargetActualBiplAct = (Label)e.Row.FindControl("lblFactorytargetActualBiplAct");
            Label lblFactorytargetActualBiplAch = (Label)e.Row.FindControl("lblFactorytargetActualBiplAch");
        }


        protected void grdFactorytargetSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.Cells[0].RowSpan = 2;

                }
                // Remove the extra cells created due to row span for odd rows
                if (e.Row.RowIndex % 2 == 1)
                {
                    e.Row.Cells.RemoveAt(0);

                }
            }

            Label lblFactorytargetSlotNo = (Label)e.Row.FindControl("lblFactorytargetSlotNo");
            Label lblNoOfMonth = (Label)e.Row.FindControl("lblNoOfMonth");
        }

        protected void grdC4546FactorytargetActualSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblC4546FactorySlotAchLine1 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine1");
            Label lblC4546FactorySlotAchLine2 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine2");
            Label lblC4546FactorySlotAchLine3 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine3");
            Label lblC4546FactorySlotAchLine4 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine4");
            Label lblC4546FactorySlotAchLine5 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine5");
            Label lblC4546FactorySlotAchLine6 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine6");
            Label lblC4546FactorySlotAchLine7 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine7");
            Label lblC4546FactorySlotAchLine8 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine8");
            Label lblC4546FactorySlotAchLine9 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine9");
            Label lblC4546FactorySlotAchLine10 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine10");
            Label lblC4546FactorySlotAchLine11 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine11");
            Label lblC4546FactorySlotAchLine12 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine12");
            Label lblC4546FactorySlotAchLine13 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine13");
            Label lblC4546FactorySlotAchLine14 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine14");
            Label lblC4546FactorySlotAchLine15 = (Label)e.Row.FindControl("lblC4546FactorySlotAchLine15");
            Label lblC4546FactorySlotAchTotal = (Label)e.Row.FindControl("lblC4546FactorySlotAchTotal");


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lblC4546FactorySlotAchLine1.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[0].Visible = false;
                }
                if (lblC4546FactorySlotAchLine2.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[1].Visible = false;
                }
                if (lblC4546FactorySlotAchLine3.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[2].Visible = false;
                }
                if (lblC4546FactorySlotAchLine4.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[3].Visible = false;
                }
                if (lblC4546FactorySlotAchLine5.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[4].Visible = false;
                }
                if (lblC4546FactorySlotAchLine6.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[5].Visible = false;
                }
                if (lblC4546FactorySlotAchLine7.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[6].Visible = false;
                }
                if (lblC4546FactorySlotAchLine8.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[7].Visible = false;
                }
                if (lblC4546FactorySlotAchLine9.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[8].Visible = false;
                }
                if (lblC4546FactorySlotAchLine10.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[9].Visible = false;
                }
                if (lblC4546FactorySlotAchLine11.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[10].Visible = false;
                }
                if (lblC4546FactorySlotAchLine12.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[11].Visible = false;
                }
                if (lblC4546FactorySlotAchLine13.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[12].Visible = false;
                }
                if (lblC4546FactorySlotAchLine14.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[13].Visible = false;
                }
                if (lblC4546FactorySlotAchLine15.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[14].Visible = false;
                }
                if (lblC4546FactorySlotAchLine1.Text == "0")
                {
                    lblC4546FactorySlotAchLine1.Text = "";
                }
                if (lblC4546FactorySlotAchLine2.Text == "0")
                {
                    lblC4546FactorySlotAchLine2.Text = "";
                }
                if (lblC4546FactorySlotAchLine3.Text == "0")
                {
                    lblC4546FactorySlotAchLine3.Text = "";
                }
                if (lblC4546FactorySlotAchLine4.Text == "0")
                {
                    lblC4546FactorySlotAchLine4.Text = "";
                }
                if (lblC4546FactorySlotAchLine5.Text == "0")
                {
                    lblC4546FactorySlotAchLine5.Text = "";
                }
                if (lblC4546FactorySlotAchLine6.Text == "0")
                {
                    lblC4546FactorySlotAchLine6.Text = "";
                }
                if (lblC4546FactorySlotAchLine7.Text == "0")
                {
                    lblC4546FactorySlotAchLine7.Text = "";
                }
                if (lblC4546FactorySlotAchLine8.Text == "0")
                {
                    lblC4546FactorySlotAchLine8.Text = "";
                }
                if (lblC4546FactorySlotAchLine9.Text == "0")
                {
                    lblC4546FactorySlotAchLine9.Text = "";
                }
                if (lblC4546FactorySlotAchLine10.Text == "0")
                {
                    lblC4546FactorySlotAchLine10.Text = "";
                }
                if (lblC4546FactorySlotAchLine11.Text == "0")
                {
                    lblC4546FactorySlotAchLine11.Text = "";
                }
                if (lblC4546FactorySlotAchLine12.Text == "0")
                {
                    lblC4546FactorySlotAchLine12.Text = "";
                }
                if (lblC4546FactorySlotAchLine13.Text == "0")
                {
                    lblC4546FactorySlotAchLine13.Text = "";
                }
                if (lblC4546FactorySlotAchLine14.Text == "0")
                {
                    lblC4546FactorySlotAchLine14.Text = "";
                }
                if (lblC4546FactorySlotAchLine15.Text == "0")
                {
                    lblC4546FactorySlotAchLine15.Text = "";
                }
            }




        }
        protected void grdC47FactorytargetActualSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblC47FactorySlotAchLine1 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine1");
            Label lblC47FactorySlotAchLine2 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine2");
            Label lblC47FactorySlotAchLine3 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine3");
            Label lblC47FactorySlotAchLine4 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine4");
            Label lblC47FactorySlotAchLine5 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine5");
            Label lblC47FactorySlotAchLine6 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine6");
            Label lblC47FactorySlotAchLine7 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine7");
            Label lblC47FactorySlotAchLine8 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine8");
            Label lblC47FactorySlotAchLine9 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine9");
            Label lblC47FactorySlotAchLine10 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine10");
            Label lblC47FactorySlotAchLine11 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine11");
            Label lblC47FactorySlotAchLine12 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine12");
            Label lblC47FactorySlotAchLine13 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine13");
            Label lblC47FactorySlotAchLine14 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine14");
            Label lblC47FactorySlotAchLine15 = (Label)e.Row.FindControl("lblC47FactorySlotAchLine15");
            Label lblC47FactorySlotAchTotal = (Label)e.Row.FindControl("lblC47FactorySlotAchTotal");


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lblC47FactorySlotAchLine1.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[0].Visible = false;
                }
                if (lblC47FactorySlotAchLine2.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[1].Visible = false;
                }
                if (lblC47FactorySlotAchLine3.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[2].Visible = false;
                }
                if (lblC47FactorySlotAchLine4.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[3].Visible = false;
                }
                if (lblC47FactorySlotAchLine5.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[4].Visible = false;
                }
                if (lblC47FactorySlotAchLine6.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[5].Visible = false;
                }
                if (lblC47FactorySlotAchLine7.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[6].Visible = false;
                }
                if (lblC47FactorySlotAchLine8.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[7].Visible = false;
                }
                if (lblC47FactorySlotAchLine9.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[8].Visible = false;
                }
                if (lblC47FactorySlotAchLine10.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[9].Visible = false;
                }
                if (lblC47FactorySlotAchLine11.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[10].Visible = false;
                }
                if (lblC47FactorySlotAchLine12.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[11].Visible = false;
                }
                if (lblC47FactorySlotAchLine13.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[12].Visible = false;
                }
                if (lblC47FactorySlotAchLine14.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[13].Visible = false;
                }
                if (lblC47FactorySlotAchLine15.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[14].Visible = false;
                }
                if (lblC47FactorySlotAchLine1.Text == "0")
                {
                    lblC47FactorySlotAchLine1.Text = "";
                }
                if (lblC47FactorySlotAchLine2.Text == "0")
                {
                    lblC47FactorySlotAchLine2.Text = "";
                }
                if (lblC47FactorySlotAchLine3.Text == "0")
                {
                    lblC47FactorySlotAchLine3.Text = "";
                }
                if (lblC47FactorySlotAchLine4.Text == "0")
                {
                    lblC47FactorySlotAchLine4.Text = "";
                }
                if (lblC47FactorySlotAchLine5.Text == "0")
                {
                    lblC47FactorySlotAchLine5.Text = "";
                }
                if (lblC47FactorySlotAchLine6.Text == "0")
                {
                    lblC47FactorySlotAchLine6.Text = "";
                }
                if (lblC47FactorySlotAchLine7.Text == "0")
                {
                    lblC47FactorySlotAchLine7.Text = "";
                }
                if (lblC47FactorySlotAchLine8.Text == "0")
                {
                    lblC47FactorySlotAchLine8.Text = "";
                }
                if (lblC47FactorySlotAchLine9.Text == "0")
                {
                    lblC47FactorySlotAchLine9.Text = "";
                }
                if (lblC47FactorySlotAchLine10.Text == "0")
                {
                    lblC47FactorySlotAchLine10.Text = "";
                }
                if (lblC47FactorySlotAchLine11.Text == "0")
                {
                    lblC47FactorySlotAchLine11.Text = "";
                }
                if (lblC47FactorySlotAchLine12.Text == "0")
                {
                    lblC47FactorySlotAchLine12.Text = "";
                }
                if (lblC47FactorySlotAchLine13.Text == "0")
                {
                    lblC47FactorySlotAchLine13.Text = "";
                }
                if (lblC47FactorySlotAchLine14.Text == "0")
                {
                    lblC47FactorySlotAchLine14.Text = "";
                }
                if (lblC47FactorySlotAchLine15.Text == "0")
                {
                    lblC47FactorySlotAchLine15.Text = "";
                }
            }



        }
        protected void grdFactorytargetActualBiplSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}