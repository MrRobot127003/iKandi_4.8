using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;

namespace iKandi.Web.UserControls.Reports
{
    public partial class frmFactoryPerformanceReports : System.Web.UI.UserControl
    {
        AdminController odjadminController = new AdminController();
        DataSet ds = new DataSet();
        DataTable dtfactoryDate = new DataTable();
        DataTable dtfactoryDateC47 = new DataTable();
        DataTable dtfactoryDateBipl = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindReport();
        }
        public void BindReport()
        {
            //DataSet ds = new DataSet();
            //DataTable dtfactoryDate = new DataTable();
            ds = odjadminController.getFactorySpecificlineTargetActual();
            dtfactoryDate = ds.Tables[0];

            grdC4546FactorytargetActual.DataSource = dtfactoryDate;
            grdC4546FactorytargetActual.DataBind();


            dtfactoryDateC47 = ds.Tables[1];
            grdC47FactorytargetActual.DataSource = dtfactoryDateC47;
            grdC47FactorytargetActual.DataBind();



           // DataSet dsBipl = new DataSet();
            
            //dsBipl = odjadminController.getFactorySpecificlineTargetActual();
            dtfactoryDateBipl = ds.Tables[2];
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
      

        protected void grdC4546FactorytargetActual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblFactorytargetActualDate = (Label)e.Row.FindControl("lblFactorytargetActualDate");
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
                    DataRowView dr = (DataRowView)e.Row.DataItem;                 
                            if (!dtfactoryDate.Columns.Contains("line1Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[1].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine1.Text = dr["line1Ach"].ToString() == "0" ? "" : dr["line1Ach"].ToString();
                                if (lblC4546FactoryAchLine1.Text != "")
                                {
                                    lblC4546FactoryAchLine1.Text = lblC4546FactoryAchLine1.Text + " %";
                                }
                                // lblC4546FactoryAchLine1.Text = dtfactoryDate.Columns["line1Ach"].ToString();
                            }

                            if (!dtfactoryDate.Columns.Contains("line2Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[2].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine2.Text = dr["line2Ach"].ToString() == "0" ? "" : dr["line2Ach"].ToString();
                                if (lblC4546FactoryAchLine2.Text != "")
                                {
                                    lblC4546FactoryAchLine2.Text = lblC4546FactoryAchLine2.Text + " %";
                                }
                              
                            }
                            if (!dtfactoryDate.Columns.Contains("line3Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[3].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine3.Text = dr["line3Ach"].ToString() == "0" ? "" : dr["line3Ach"].ToString();
                                if (lblC4546FactoryAchLine3.Text != "")
                                {
                                    lblC4546FactoryAchLine3.Text = lblC4546FactoryAchLine3.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line4Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[4].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine4.Text = dr["line4Ach"].ToString() == "0" ? "" : dr["line4Ach"].ToString();
                                if (lblC4546FactoryAchLine4.Text != "")
                                {
                                    lblC4546FactoryAchLine4.Text = lblC4546FactoryAchLine4.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line5Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[5].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine5.Text = dr["line5Ach"].ToString() == "0" ? "" : dr["line5Ach"].ToString();
                                if (lblC4546FactoryAchLine5.Text != "")
                                {
                                    lblC4546FactoryAchLine5.Text = lblC4546FactoryAchLine5.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line6Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[6].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine6.Text = dr["line6Ach"].ToString() == "0" ? "" : dr["line6Ach"].ToString();
                                if (lblC4546FactoryAchLine6.Text != "")
                                {
                                    lblC4546FactoryAchLine6.Text = lblC4546FactoryAchLine6.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line7Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[7].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine7.Text = dr["line7Ach"].ToString() == "0" ? "" : dr["line7Ach"].ToString();
                                if (lblC4546FactoryAchLine7.Text != "")
                                {
                                    lblC4546FactoryAchLine7.Text = lblC4546FactoryAchLine7.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line8Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[8].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine8.Text = dr["line8Ach"].ToString() == "0" ? "" : dr["line8Ach"].ToString();
                                if (lblC4546FactoryAchLine8.Text != "")
                                {
                                    lblC4546FactoryAchLine8.Text = lblC4546FactoryAchLine8.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line9Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[9].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine9.Text = dr["line9Ach"].ToString() == "0" ? "" : dr["line9Ach"].ToString();
                                if (lblC4546FactoryAchLine9.Text != "")
                                {
                                    lblC4546FactoryAchLine9.Text = lblC4546FactoryAchLine9.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line10Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[10].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine10.Text = dr["line10Ach"].ToString() == "0" ? "" : dr["line10Ach"].ToString();
                                if (lblC4546FactoryAchLine10.Text != "")
                                {
                                    lblC4546FactoryAchLine10.Text = lblC4546FactoryAchLine10.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line11Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[11].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine11.Text = dr["line11Ach"].ToString() == "0" ? "" : dr["line11Ach"].ToString();
                                if (lblC4546FactoryAchLine11.Text != "")
                                {
                                    lblC4546FactoryAchLine11.Text = lblC4546FactoryAchLine11.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line12Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[12].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine12.Text = dr["line12Ach"].ToString() == "0" ? "" : dr["line12Ach"].ToString();
                                if (lblC4546FactoryAchLine12.Text != "")
                                {
                                    lblC4546FactoryAchLine12.Text = lblC4546FactoryAchLine12.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line13Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[13].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine13.Text = dr["line13Ach"].ToString() == "0" ? "" : dr["line13Ach"].ToString();
                                if (lblC4546FactoryAchLine13.Text != "")
                                {
                                    lblC4546FactoryAchLine13.Text = lblC4546FactoryAchLine13.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line14Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[14].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine14.Text = dr["line14Ach"].ToString() == "0" ? "" : dr["line14Ach"].ToString();
                                if (lblC4546FactoryAchLine14.Text != "")
                                {
                                    lblC4546FactoryAchLine14.Text = lblC4546FactoryAchLine14.Text + " %";
                                }
                            }
                            if (!dtfactoryDate.Columns.Contains("line15Ach"))
                            {
                                grdC4546FactorytargetActual.Columns[15].Visible = false;
                            }
                            else
                            {
                                lblC4546FactoryAchLine15.Text = dr["line15Ach"].ToString() == "0" ? "" : dr["line15Ach"].ToString();
                                if (lblC4546FactoryAchLine15.Text != "")
                                {
                                    lblC4546FactoryAchLine15.Text = lblC4546FactoryAchLine15.Text + " %";
                                }
                            }

                            if (lblC4546FactoryTgtTotal.Text == "0")
                            {
                                lblC4546FactoryTgtTotal.Text = "";
                                
                            }
                            else
                            {
                                if(lblC4546FactoryTgtTotal.Text != "")
                                    lblC4546FactoryTgtTotal.Text = lblC4546FactoryTgtTotal.Text + " %";
                            }
                            if (lblC4546FactoryActTotal.Text == "0")
                            {
                                lblC4546FactoryActTotal.Text = "";                               
                            }
                            else
                            {
                               if(lblC4546FactoryActTotal.Text != "")
                                lblC4546FactoryActTotal.Text = lblC4546FactoryActTotal.Text + " %";
                            }
                            if (lblC4546FactoryAchTotal.Text == "0")
                            {
                                lblC4546FactoryAchTotal.Text = "";
                                
                            }
                            else
                            { 
                                if(lblC4546FactoryAchTotal.Text != "")
                                    lblC4546FactoryAchTotal.Text = lblC4546FactoryAchTotal.Text + " %";
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
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (!dtfactoryDateC47.Columns.Contains("line1Ach"))
                {
                    grdC47FactorytargetActual.Columns[0].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine1.Text = dr["line1Ach"].ToString() == "0" ? "" : dr["line1Ach"].ToString();

                    if (lblC47FactoryAchLine1.Text != "")
                    {
                        lblC47FactoryAchLine1.Text = lblC47FactoryAchLine1.Text + " %";
                    }
                    // lblC4546FactoryAchLine1.Text = dtfactoryDate.Columns["line1Ach"].ToString();
                }

                if (!dtfactoryDateC47.Columns.Contains("line2Ach"))
                {
                    grdC47FactorytargetActual.Columns[1].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine2.Text = dr["line2Ach"].ToString() == "0" ? "" : dr["line2Ach"].ToString();
                    if (lblC47FactoryAchLine2.Text != "")
                    {
                        lblC47FactoryAchLine2.Text = lblC47FactoryAchLine2.Text + " %";
                    }

                }
                if (!dtfactoryDateC47.Columns.Contains("line3Ach"))
                {
                    grdC47FactorytargetActual.Columns[2].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine3.Text = dr["line3Ach"].ToString() == "0" ? "" : dr["line3Ach"].ToString();
                    if (lblC47FactoryAchLine3.Text != "")
                    {
                        lblC47FactoryAchLine3.Text = lblC47FactoryAchLine3.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line4Ach"))
                {
                    grdC47FactorytargetActual.Columns[3].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine4.Text = dr["line4Ach"].ToString() == "0" ? "" : dr["line4Ach"].ToString();
                    if (lblC47FactoryAchLine4.Text != "")
                    {
                        lblC47FactoryAchLine4.Text = lblC47FactoryAchLine4.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line5Ach"))
                {
                    grdC47FactorytargetActual.Columns[4].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine5.Text = dr["line5Ach"].ToString() == "0" ? "" : dr["line5Ach"].ToString();
                    if (lblC47FactoryAchLine5.Text != "")
                    {
                        lblC47FactoryAchLine5.Text = lblC47FactoryAchLine5.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line6Ach"))
                {
                    grdC47FactorytargetActual.Columns[5].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine6.Text = dr["line6Ach"].ToString() == "0" ? "" : dr["line6Ach"].ToString();
                    if (lblC47FactoryAchLine6.Text != "")
                    {
                        lblC47FactoryAchLine6.Text = lblC47FactoryAchLine6.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line7Ach"))
                {
                    grdC47FactorytargetActual.Columns[6].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine7.Text = dr["line7Ach"].ToString() == "0" ? "" : dr["line7Ach"].ToString();
                    if (lblC47FactoryAchLine7.Text != "")
                    {
                        lblC47FactoryAchLine7.Text = lblC47FactoryAchLine7.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line8Ach"))
                {
                    grdC47FactorytargetActual.Columns[7].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine8.Text = dr["line8Ach"].ToString() == "0" ? "" : dr["line8Ach"].ToString();
                    if (lblC47FactoryAchLine8.Text != "")
                    {
                        lblC47FactoryAchLine8.Text = lblC47FactoryAchLine8.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line9Ach"))
                {
                    grdC47FactorytargetActual.Columns[8].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine9.Text = dr["line9Ach"].ToString() == "0" ? "" : dr["line9Ach"].ToString();
                    if (lblC47FactoryAchLine9.Text != "")
                    {
                        lblC47FactoryAchLine9.Text = lblC47FactoryAchLine9.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line10Ach"))
                {
                    grdC47FactorytargetActual.Columns[9].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine10.Text = dr["line10Ach"].ToString() == "0" ? "" : dr["line10Ach"].ToString();
                    if (lblC47FactoryAchLine10.Text != "")
                    {
                        lblC47FactoryAchLine10.Text = lblC47FactoryAchLine10.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line11Ach"))
                {
                    grdC47FactorytargetActual.Columns[10].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine11.Text = dr["line11Ach"].ToString() == "0" ? "" : dr["line11Ach"].ToString();
                    if (lblC47FactoryAchLine11.Text != "")
                    {
                        lblC47FactoryAchLine11.Text = lblC47FactoryAchLine11.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line12Ach"))
                {
                    grdC47FactorytargetActual.Columns[11].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine12.Text = dr["line12Ach"].ToString() == "0" ? "" : dr["line12Ach"].ToString();
                    if (lblC47FactoryAchLine12.Text != "")
                    {
                        lblC47FactoryAchLine12.Text = lblC47FactoryAchLine12.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line13Ach"))
                {
                    grdC47FactorytargetActual.Columns[12].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine13.Text = dr["line13Ach"].ToString() == "0" ? "" : dr["line13Ach"].ToString();
                    if (lblC47FactoryAchLine13.Text != "")
                    {
                        lblC47FactoryAchLine13.Text = lblC47FactoryAchLine13.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line14Ach"))
                {
                    grdC47FactorytargetActual.Columns[13].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine14.Text = dr["line14Ach"].ToString() == "0" ? "" : dr["line14Ach"].ToString();
                    if (lblC47FactoryAchLine14.Text != "")
                    {
                        lblC47FactoryAchLine14.Text = lblC47FactoryAchLine14.Text + " %";
                    }
                }
                if (!dtfactoryDateC47.Columns.Contains("line15Ach"))
                {
                    grdC47FactorytargetActual.Columns[14].Visible = false;
                }
                else
                {
                    lblC47FactoryAchLine15.Text = dr["line15Ach"].ToString() == "0" ? "" : dr["line15Ach"].ToString();
                    if (lblC47FactoryAchLine15.Text != "")
                    {
                        lblC47FactoryAchLine15.Text = lblC47FactoryAchLine15.Text + " %";
                    }
                }

                if (lblC47FactoryTgtTotal.Text == "0")
                {
                    lblC47FactoryTgtTotal.Text = "";

                }
                else
                {
                    if (lblC47FactoryTgtTotal.Text != "")
                        lblC47FactoryTgtTotal.Text = lblC47FactoryTgtTotal.Text + " %";
                }
                if (lblC47FactoryActTotal.Text == "0")
                {
                    lblC47FactoryActTotal.Text = "";
                }
                else
                {
                    if (lblC47FactoryActTotal.Text != "")
                        lblC47FactoryActTotal.Text = lblC47FactoryActTotal.Text + " %";
                }
                if (lblC47FactoryAchTotal.Text == "0")
                {
                    lblC47FactoryAchTotal.Text = "";

                }
                else
                {
                    if (lblC47FactoryAchTotal.Text != "")
                        lblC47FactoryAchTotal.Text = lblC47FactoryAchTotal.Text + " %";
                }

               
               
            }  

            
        }

        protected void grdFactorytargetActualBipl_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Label lblFactorytargetActualBiplTgt = (Label)e.Row.FindControl("lblFactorytargetActualBiplTgt");
            Label lblFactorytargetActualBiplAct = (Label)e.Row.FindControl("lblFactorytargetActualBiplAct");
            Label lblFactorytargetActualBiplAch = (Label)e.Row.FindControl("lblFactorytargetActualBiplAch");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (lblFactorytargetActualBiplTgt.Text == "0")
                {
                    lblFactorytargetActualBiplTgt.Text = "";

                }
                else
                {
                    if (lblFactorytargetActualBiplTgt.Text != "")
                        lblFactorytargetActualBiplTgt.Text = lblFactorytargetActualBiplTgt.Text + " %";
                }
                if (lblFactorytargetActualBiplAct.Text == "0")
                {
                    lblFactorytargetActualBiplAct.Text = "";
                }
                else
                {
                    if (lblFactorytargetActualBiplAct.Text != "")
                        lblFactorytargetActualBiplAct.Text = lblFactorytargetActualBiplAct.Text + " %";
                }
                if (lblFactorytargetActualBiplAch.Text == "0")
                {
                    lblFactorytargetActualBiplAch.Text = "";

                }
                else
                {
                    if (lblFactorytargetActualBiplAch.Text != "")
                        lblFactorytargetActualBiplAch.Text = lblFactorytargetActualBiplAch.Text + " %";
                }
                
            }
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
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[0].Visible = true;
                }
                if (lblC4546FactorySlotAchLine2.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[1].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[1].Visible = true;
                }
                if (lblC4546FactorySlotAchLine3.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[2].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[2].Visible = true;
                }
                if (lblC4546FactorySlotAchLine4.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[3].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[3].Visible = true;
                }
                if (lblC4546FactorySlotAchLine5.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[4].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[4].Visible = true;
                }
                if (lblC4546FactorySlotAchLine6.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[5].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[5].Visible = true;
                }
                if (lblC4546FactorySlotAchLine7.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[6].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[6].Visible = true;
                }
                if (lblC4546FactorySlotAchLine8.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[7].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[7].Visible = true;
                }
                if (lblC4546FactorySlotAchLine9.Text == "")
                {
                    grdC4546FactorytargetActual.Columns[8].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActual.Columns[8].Visible = true;
                }
                if (lblC4546FactorySlotAchLine10.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[9].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[9].Visible = true;
                }
                if (lblC4546FactorySlotAchLine11.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[10].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[10].Visible = true;
                }
                if (lblC4546FactorySlotAchLine12.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[11].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[11].Visible = true;
                }
                if (lblC4546FactorySlotAchLine13.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[12].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[12].Visible = true;
                }
                if (lblC4546FactorySlotAchLine14.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[13].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[13].Visible = true;
                }
                if (lblC4546FactorySlotAchLine15.Text == "")
                {
                    grdC4546FactorytargetActualSlot.Columns[14].Visible = false;
                }
                else
                {
                    grdC4546FactorytargetActualSlot.Columns[14].Visible = true;
                }
                if (lblC4546FactorySlotAchLine1.Text == "0")
                {
                    lblC4546FactorySlotAchLine1.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine1.Text != "")
                    {
                        lblC4546FactorySlotAchLine1.Text = lblC4546FactorySlotAchLine1.Text + " %";
                    }
                }
                if (lblC4546FactorySlotAchLine2.Text == "0")
                {
                    lblC4546FactorySlotAchLine2.Text = "";
                }
                else
                {
                    if(lblC4546FactorySlotAchLine2.Text !="")
                    lblC4546FactorySlotAchLine2.Text = lblC4546FactorySlotAchLine2.Text + "%";
                }
                if (lblC4546FactorySlotAchLine3.Text == "0")
                {

                    lblC4546FactorySlotAchLine3.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine3.Text != "")
                    lblC4546FactorySlotAchLine3.Text = lblC4546FactorySlotAchLine3.Text + " %";
                }
                if (lblC4546FactorySlotAchLine4.Text == "0")
                {
                    lblC4546FactorySlotAchLine4.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine4.Text != "")
                    lblC4546FactorySlotAchLine4.Text = lblC4546FactorySlotAchLine4.Text + " %";
                }
                if (lblC4546FactorySlotAchLine5.Text == "0")
                {
                    lblC4546FactorySlotAchLine5.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine5.Text != "")
                    lblC4546FactorySlotAchLine5.Text = lblC4546FactorySlotAchLine5.Text + " %";
                }
                if (lblC4546FactorySlotAchLine6.Text == "0")
                {
                    lblC4546FactorySlotAchLine6.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine6.Text != "")
                    lblC4546FactorySlotAchLine6.Text = lblC4546FactorySlotAchLine6.Text + " %";
                }
                if (lblC4546FactorySlotAchLine7.Text == "0")
                {
                    lblC4546FactorySlotAchLine7.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine7.Text != "")
                    lblC4546FactorySlotAchLine7.Text = lblC4546FactorySlotAchLine7.Text + " %";
                }
                if (lblC4546FactorySlotAchLine8.Text == "0")
                {
                    lblC4546FactorySlotAchLine8.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine8.Text != "")
                    lblC4546FactorySlotAchLine8.Text = lblC4546FactorySlotAchLine8.Text + " %";
                }
                if (lblC4546FactorySlotAchLine9.Text == "0")
                {
                    lblC4546FactorySlotAchLine9.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine9.Text != "")
                    lblC4546FactorySlotAchLine9.Text = lblC4546FactorySlotAchLine9.Text + " %";
                }
                if (lblC4546FactorySlotAchLine10.Text == "0")
                {
                    lblC4546FactorySlotAchLine10.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine10.Text != "")
                    lblC4546FactorySlotAchLine10.Text = lblC4546FactorySlotAchLine10.Text + " %";
                }
                if (lblC4546FactorySlotAchLine11.Text == "0")
                {
                    lblC4546FactorySlotAchLine11.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine11.Text != "")
                    lblC4546FactorySlotAchLine11.Text = lblC4546FactorySlotAchLine11.Text + " %";
                }
                if (lblC4546FactorySlotAchLine12.Text == "0")
                {
                    lblC4546FactorySlotAchLine12.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine12.Text != "")
                    lblC4546FactorySlotAchLine12.Text = lblC4546FactorySlotAchLine12.Text + " %";
                }
                if (lblC4546FactorySlotAchLine13.Text == "0")
                {
                    lblC4546FactorySlotAchLine13.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine13.Text != "")
                    lblC4546FactorySlotAchLine13.Text = lblC4546FactorySlotAchLine13.Text + " %";
                }
                if (lblC4546FactorySlotAchLine14.Text == "0")
                {
                    lblC4546FactorySlotAchLine14.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine14.Text != "")
                    lblC4546FactorySlotAchLine14.Text = lblC4546FactorySlotAchLine14.Text + " %";
                }
                if (lblC4546FactorySlotAchLine15.Text == "0")
                {
                    lblC4546FactorySlotAchLine15.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchLine15.Text != "")
                    lblC4546FactorySlotAchLine15.Text = lblC4546FactorySlotAchLine15.Text + "%";
                }
                if (lblC4546FactorySlotAchTotal.Text == "0")
                {
                    lblC4546FactorySlotAchTotal.Text = "";
                }
                else
                {
                    if (lblC4546FactorySlotAchTotal.Text != "")
                    lblC4546FactorySlotAchTotal.Text = lblC4546FactorySlotAchTotal.Text + " %";
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
                else
                {
                    grdC47FactorytargetActualSlot.Columns[0].Visible = true;
                }
                if (lblC47FactorySlotAchLine2.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[1].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[1].Visible = true;
                }
                if (lblC47FactorySlotAchLine3.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[2].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[2].Visible = true;
                }
                if (lblC47FactorySlotAchLine4.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[3].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[3].Visible = true;
                }
                if (lblC47FactorySlotAchLine5.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[4].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[4].Visible = true;
                }
                if (lblC47FactorySlotAchLine6.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[5].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[5].Visible = true;
                }
                if (lblC47FactorySlotAchLine7.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[6].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[6].Visible = true;
                }
                if (lblC47FactorySlotAchLine8.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[7].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[7].Visible = true;
                }
                if (lblC47FactorySlotAchLine9.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[8].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[8].Visible = true;
                }
                if (lblC47FactorySlotAchLine10.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[9].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[9].Visible = true;
                }
                if (lblC47FactorySlotAchLine11.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[10].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[10].Visible = true;
                }
                if (lblC47FactorySlotAchLine12.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[11].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[11].Visible = true;
                }
                if (lblC47FactorySlotAchLine13.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[12].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[12].Visible = true;
                }
                if (lblC47FactorySlotAchLine14.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[13].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[13].Visible = true;
                }
                if (lblC47FactorySlotAchLine15.Text == "")
                {
                    grdC47FactorytargetActualSlot.Columns[14].Visible = false;
                }
                else
                {
                    grdC47FactorytargetActualSlot.Columns[14].Visible = true;
                }
                if (lblC47FactorySlotAchLine1.Text == "0")
                {
                    lblC47FactorySlotAchLine1.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine1.Text != "")
                    lblC47FactorySlotAchLine1.Text = lblC47FactorySlotAchLine1.Text + " %";
                }
                if (lblC47FactorySlotAchLine2.Text == "0")
                {
                    lblC47FactorySlotAchLine2.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine2.Text != "")
                    lblC47FactorySlotAchLine2.Text = lblC47FactorySlotAchLine2.Text + " %";
                }
                if (lblC47FactorySlotAchLine3.Text == "0")
                {
                    lblC47FactorySlotAchLine3.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine3.Text != "")
                    lblC47FactorySlotAchLine3.Text = lblC47FactorySlotAchLine3.Text + " %";
                }
                if (lblC47FactorySlotAchLine4.Text == "0")
                {
                    lblC47FactorySlotAchLine4.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine4.Text != "")
                    lblC47FactorySlotAchLine4.Text = lblC47FactorySlotAchLine4.Text + " %";
                }
                if (lblC47FactorySlotAchLine5.Text == "0")
                {
                    lblC47FactorySlotAchLine5.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine5.Text != "")
                    lblC47FactorySlotAchLine5.Text = lblC47FactorySlotAchLine5.Text + " %";
                }
                if (lblC47FactorySlotAchLine6.Text == "0")
                {
                    lblC47FactorySlotAchLine6.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine6.Text != "")
                    lblC47FactorySlotAchLine6.Text = lblC47FactorySlotAchLine6.Text + " %";
                }
                if (lblC47FactorySlotAchLine7.Text == "0")
                {
                    lblC47FactorySlotAchLine7.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine7.Text != "")
                    lblC47FactorySlotAchLine7.Text = lblC47FactorySlotAchLine7.Text + " %";
                }
                if (lblC47FactorySlotAchLine8.Text == "0")
                {
                    lblC47FactorySlotAchLine8.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine8.Text != "")
                    lblC47FactorySlotAchLine8.Text = lblC47FactorySlotAchLine8.Text + " %";
                }
                if (lblC47FactorySlotAchLine9.Text == "0")
                {
                    lblC47FactorySlotAchLine9.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine9.Text != "")
                    lblC47FactorySlotAchLine9.Text = lblC47FactorySlotAchLine9.Text + " %";
                }
                if (lblC47FactorySlotAchLine10.Text == "0")
                {
                    lblC47FactorySlotAchLine10.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine10.Text != "")
                    lblC47FactorySlotAchLine10.Text = lblC47FactorySlotAchLine10.Text + " %";
                }
                if (lblC47FactorySlotAchLine11.Text == "0")
                {
                    lblC47FactorySlotAchLine11.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine11.Text != "")
                    lblC47FactorySlotAchLine11.Text = lblC47FactorySlotAchLine11.Text + " %";
                }
                if (lblC47FactorySlotAchLine12.Text == "0")
                {
                    lblC47FactorySlotAchLine12.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine12.Text != "")
                    lblC47FactorySlotAchLine12.Text = lblC47FactorySlotAchLine12.Text + " %";
                }
                if (lblC47FactorySlotAchLine13.Text == "0")
                {
                    lblC47FactorySlotAchLine13.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine13.Text != "")
                    lblC47FactorySlotAchLine13.Text = lblC47FactorySlotAchLine13.Text + " %";
                }
                if (lblC47FactorySlotAchLine14.Text == "0")
                {
                    lblC47FactorySlotAchLine14.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine14.Text != "")
                    lblC47FactorySlotAchLine14.Text = lblC47FactorySlotAchLine14.Text + " %";
                }
                if (lblC47FactorySlotAchLine15.Text == "0")
                {
                    lblC47FactorySlotAchLine15.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchLine15.Text != "")
                    lblC47FactorySlotAchLine15.Text = lblC47FactorySlotAchLine15.Text + " %";
                }
                if (lblC47FactorySlotAchTotal.Text == "0")
                {
                    lblC47FactorySlotAchTotal.Text = "";
                }
                else
                {
                    if (lblC47FactorySlotAchTotal.Text != "")
                    lblC47FactorySlotAchTotal.Text = lblC47FactorySlotAchTotal.Text + " %";
                }
            }



        }
        protected void grdFactorytargetActualBiplSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblFactorytargetActualBiplAchSlot = (Label)e.Row.FindControl("lblFactorytargetActualBiplAchSlot");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (lblFactorytargetActualBiplAchSlot.Text == "0")
                {
                    lblFactorytargetActualBiplAchSlot.Text = "";
                }
                else
                {
                    if (lblFactorytargetActualBiplAchSlot.Text != "")
                    lblFactorytargetActualBiplAchSlot.Text = lblFactorytargetActualBiplAchSlot.Text + " %";
                }
            }
        }
    }
}