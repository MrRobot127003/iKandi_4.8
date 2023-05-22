using System;
using System.Linq;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;

namespace iKandi.Web.UserControls.Reports
{
    public partial class Penality_MatrixNew : System.Web.UI.UserControl
    {
        //abhishek=================
        //=============C45_46==========================//
        object Air_C45_46_1Week_var = 0;
        object Insp_C45_46_1Week_var = 0;
        object Plt_C45_46_1Week_var = 0;
        object Ship_C45_46_1Week_var = 0;
        object Perc_C45_46_1Week_var = 0;
        object CTSL_C45_46_1Week_var = 0;
        object QK_C45_46_1Week_var = 0;
        DataTable dt_C45_46_1Week_var;

        object Air_C45_46_3Month_var = 0;
        object Insp_C45_46_3Month_var = 0;
        object Plt_C45_46_3Month_var = 0;
        object Ship_C45_46_3Month_var = 0;
        object Perc_C45_46_3Month_var = 0;
        object CTSL_C45_46_3Month_var = 0;
        object QK_C45_46_3Month_var = 0;
        DataTable dt_C45_46_3Month_var;

        object Air_C45_46_1year_var = 0;
        object Insp_C45_46_1year_var = 0;
        object Plt_C45_46_1year_var = 0;
        object Ship_C45_46_1year_var = 0;
        object Perc_C45_46_1year_var = 0;
        object CTSL_C45_46_1year_var = 0;
        object QK_C45_46_1year_var = 0;

        DataTable dt_C45_46_1year_var;

        //=============C47==========================//
        object Air_C47_1Week_var = 0;
        object Insp_C47_1Week_var = 0;
        object Plt_C47_1Week_var = 0;
        object Ship_C47_1Week_var = 0;
        object Perc_C47_1Week_var = 0;
        object CTSL_C47_1Week_var = 0;
        object QK_C47_1Week_var = 0;
        DataTable dt_C47_1Week_var;

        object Air_C47_3Month_var = 0;
        object Insp_C47_3Month_var = 0;
        object Plt_C47_3Month_var = 0;
        object Ship_C47_3Month_var = 0;
        object Perc_C47_3Month_var = 0;
        object CTSL_C47_3Month_var = 0;
        object QK_C47_3Month_var = 0;
        DataTable dt_C47_3Month_var;

        object Air_C47_1year_var = 0;
        object Insp_C47_1year_var = 0;
        object Plt_C47_1year_var = 0;
        object Ship_C47_1year_var = 0;
        object Perc_C47_1year_var = 0;
        object CTSL_C47_1year_var = 0;
        object QK_C47_1year_var = 0;

        DataTable dt_C47_1year_var;

        //=============D 169==========================//
        object Air_D169_1Week_var = 0;
        object Insp_D169_1Week_var = 0;
        object Plt_D169_1Week_var = 0;
        object Ship_D169_1Week_var = 0;
        object Perc_D169_1Week_var = 0;
        object CTSL_D169_1Week_var = 0;
        object QK_D169_1Week_var = 0;
        DataTable dt_D169_1Week_var;

        object Air_D169_3Month_var = 0;
        object Insp_D169_3Month_var = 0;
        object Plt_D169_3Month_var = 0;
        object Ship_D169_3Month_var = 0;
        object Perc_D169_3Month_var = 0;
        object CTSL_D169_3Month_var = 0;
        object QK_D169_3Month_var = 0;
        DataTable dt_D169_3Month_var;

        object Air_D169_1year_var = 0;
        object Insp_D169_1year_var = 0;
        object Plt_D169_1year_var = 0;
        object Ship_D169_1year_var = 0;
        object Perc_D169_1year_var = 0;
        object CTSL_D169_1year_var = 0;
        object QK_D169_1year_var = 0;

        DataTable dt_D169_1year_var;


        //=============BIPL==========================//
        object Air_Bipl_1Week_var = 0;
        object Insp_Bipl_1Week_var = 0;
        object Plt_Bipl_1Week_var = 0;
        object Ship_Bipl_1Week_var = 0;
        object Perc_Bipl_1Week_var = 0;
        object CTSL_Bipl_1Week_var = 0;
        object QK_Bipl_1Week_var = 0;
        DataTable dt_Bipl_1Week_var;

        object Air_Bipl_3Month_var = 0;
        object Insp_Bipl_3Month_var = 0;
        object Plt_Bipl_3Month_var = 0;
        object Ship_Bipl_3Month_var = 0;
        object Perc_Bipl_3Month_var = 0;
        object CTSL_Bipl_3Month_var = 0;
        object QK_Bipl_3Month_var = 0;
        DataTable dt_Bipl_3Month_var;

        object Air_Bipl_1year_var = 0;
        object Insp_Bipl_1year_var = 0;
        object Plt_Bipl_1year_var = 0;
        object Ship_Bipl_1year_var = 0;
        object Perc_Bipl_1year_var = 0;
        object CTSL_Bipl_1year_var = 0;
        object QK_Bipl_1year_var = 0;

        DataTable dt_Bipl_1year_var;


        //=========end

        //===================================
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }

        private void BindData()
        {
            ProductionController objProductionController = new ProductionController();
            DataTable DT = objProductionController.GetCompanyName_Of_ShippedQty();
            gvPenalty_Matrix.DataSource = DT;
            gvPenalty_Matrix.DataBind();
            BindPenaltyMetrics();
            gvPenalty_Matrix.Columns[2].Visible = false;
            gvPenalty_Matrix.Columns[3].Visible = false;
            gvPenalty_Matrix.Columns[4].Visible = false;
            gvPenalty_Matrix.Columns[5].Visible = false;
            gvPenalty_Matrix.Columns[8].Visible = true;
            gvPenalty_Matrix.Columns[12].Visible = true;
        }
        //added by abhishek on 1/6/2017
        public void GetOtherClientVal(DataSet PenaltyMetrics)
        {
            //=============================================C45_46=====================================================================================//

            dt_C45_46_1Week_var = PenaltyMetrics.Tables[0];
            if (dt_C45_46_1Week_var.Rows.Count > 0)
            {
                Air_C45_46_1Week_var = dt_C45_46_1Week_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Insp_C45_46_1Week_var = dt_C45_46_1Week_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Plt_C45_46_1Week_var = dt_C45_46_1Week_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Ship_C45_46_1Week_var = dt_C45_46_1Week_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Perc_C45_46_1Week_var = dt_C45_46_1Week_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=11");
                CTSL_C45_46_1Week_var = dt_C45_46_1Week_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=11");
                QK_C45_46_1Week_var = dt_C45_46_1Week_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=11");
            }




            dt_C45_46_3Month_var = PenaltyMetrics.Tables[1];
            if (dt_C45_46_3Month_var.Rows.Count > 0)
            {
                Air_C45_46_3Month_var = dt_C45_46_3Month_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Insp_C45_46_3Month_var = dt_C45_46_3Month_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Plt_C45_46_3Month_var = dt_C45_46_3Month_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Ship_C45_46_3Month_var = dt_C45_46_3Month_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Perc_C45_46_3Month_var = dt_C45_46_3Month_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=11");
                CTSL_C45_46_3Month_var = dt_C45_46_3Month_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=11");
                QK_C45_46_3Month_var = dt_C45_46_3Month_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=11");
            }

            dt_C45_46_1year_var = PenaltyMetrics.Tables[2];
            if (dt_C45_46_1year_var.Rows.Count > 0)
            {
                Air_C45_46_1year_var = dt_C45_46_1year_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Insp_C45_46_1year_var = dt_C45_46_1year_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Plt_C45_46_1year_var = dt_C45_46_1year_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Ship_C45_46_1year_var = dt_C45_46_1year_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=11");
                Perc_C45_46_1year_var = dt_C45_46_1year_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=11");
                CTSL_C45_46_1year_var = dt_C45_46_1year_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=11");
                QK_C45_46_1year_var = dt_C45_46_1year_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=11");

            }
            //=============================================C47=====================================================================================//

            dt_C47_1Week_var = PenaltyMetrics.Tables[0];

            if (dt_C47_1Week_var.Rows.Count > 0)
            {
                Air_C47_1Week_var = dt_C47_1Week_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Insp_C47_1Week_var = dt_C47_1Week_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Plt_C47_1Week_var = dt_C47_1Week_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Ship_C47_1Week_var = dt_C47_1Week_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Perc_C47_1Week_var = dt_C47_1Week_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=3");
                CTSL_C47_1Week_var = dt_C47_1Week_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=3");
                QK_C47_1Week_var = dt_C47_1Week_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=3");
            }

            dt_C47_3Month_var = PenaltyMetrics.Tables[1];
            if (dt_C47_3Month_var.Rows.Count > 0)
            {
                Air_C47_3Month_var = dt_C47_3Month_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Insp_C47_3Month_var = dt_C47_3Month_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Plt_C47_3Month_var = dt_C47_3Month_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Ship_C47_3Month_var = dt_C47_3Month_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Perc_C47_3Month_var = dt_C47_3Month_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=3");
                CTSL_C47_3Month_var = dt_C47_3Month_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=3");
                QK_C47_3Month_var = dt_C47_3Month_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=3");
            }

            dt_C47_1year_var = PenaltyMetrics.Tables[2];
            if (dt_C47_1year_var.Rows.Count > 0)
            {
                Air_C47_1year_var = dt_C47_1year_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Insp_C47_1year_var = dt_C47_1year_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Plt_C47_1year_var = dt_C47_1year_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Ship_C47_1year_var = dt_C47_1year_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=3");
                Perc_C47_1year_var = dt_C47_1year_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=3");
                CTSL_C47_1year_var = dt_C47_1year_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=3");
                QK_C47_1year_var = dt_C47_1year_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=3");

            }
            //=============================================D 169=====================================================================================//

            dt_D169_1Week_var = PenaltyMetrics.Tables[0];

            if (dt_D169_1Week_var.Rows.Count > 0)
            {
                Air_D169_1Week_var = dt_D169_1Week_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Insp_D169_1Week_var = dt_D169_1Week_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Plt_D169_1Week_var = dt_D169_1Week_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Ship_D169_1Week_var = dt_D169_1Week_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Perc_D169_1Week_var = dt_D169_1Week_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=96");
                CTSL_D169_1Week_var = dt_D169_1Week_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=96");
                QK_D169_1Week_var = dt_D169_1Week_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=96");
            }




            dt_D169_3Month_var = PenaltyMetrics.Tables[1];
            if (dt_D169_3Month_var.Rows.Count > 0)
            {
                Air_D169_3Month_var = dt_D169_3Month_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Insp_D169_3Month_var = dt_D169_3Month_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Plt_D169_3Month_var = dt_D169_3Month_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Ship_D169_3Month_var = dt_D169_3Month_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Perc_D169_3Month_var = dt_D169_3Month_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=96");
                CTSL_D169_3Month_var = dt_D169_3Month_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=96");
                QK_D169_3Month_var = dt_D169_3Month_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=96");
            }

            dt_D169_1year_var = PenaltyMetrics.Tables[2];
            if (dt_D169_1year_var.Rows.Count > 0)
            {
                Air_D169_1year_var = dt_D169_1year_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Insp_D169_1year_var = dt_D169_1year_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Plt_D169_1year_var = dt_D169_1year_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Ship_D169_1year_var = dt_D169_1year_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID=96");
                Perc_D169_1year_var = dt_D169_1year_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID=96");
                CTSL_D169_1year_var = dt_D169_1year_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID=96");
                QK_D169_1year_var = dt_D169_1year_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID=96");

            }
            //=============================================BIPL=====================================================================================//

            dt_Bipl_1Week_var = PenaltyMetrics.Tables[0];

            if (dt_Bipl_1Week_var.Rows.Count > 0)
            {
                Air_Bipl_1Week_var = dt_Bipl_1Week_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Insp_Bipl_1Week_var = dt_Bipl_1Week_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Plt_Bipl_1Week_var = dt_Bipl_1Week_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Ship_Bipl_1Week_var = dt_Bipl_1Week_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Perc_Bipl_1Week_var = dt_Bipl_1Week_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                CTSL_Bipl_1Week_var = dt_Bipl_1Week_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                QK_Bipl_1Week_var = dt_Bipl_1Week_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
            }




            dt_Bipl_3Month_var = PenaltyMetrics.Tables[1];
            if (dt_Bipl_3Month_var.Rows.Count > 0)
            {
                Air_Bipl_3Month_var = dt_Bipl_3Month_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Insp_Bipl_3Month_var = dt_Bipl_3Month_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Plt_Bipl_3Month_var = dt_Bipl_3Month_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Ship_Bipl_3Month_var = dt_Bipl_3Month_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Perc_Bipl_3Month_var = dt_Bipl_3Month_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                CTSL_Bipl_3Month_var = dt_Bipl_3Month_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                QK_Bipl_3Month_var = dt_Bipl_3Month_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
            }

            dt_Bipl_1year_var = PenaltyMetrics.Tables[2];
            if (dt_Bipl_1year_var.Rows.Count > 0)
            {
                Air_Bipl_1year_var = dt_Bipl_1year_var.Compute("Sum(Airing)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Insp_Bipl_1year_var = dt_Bipl_1year_var.Compute("Sum(InspectionFailandTransport)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Plt_Bipl_1year_var = dt_Bipl_1year_var.Compute("Sum(TotalPenalty)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Ship_Bipl_1year_var = dt_Bipl_1year_var.Compute("Sum(ShippedValue)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                Perc_Bipl_1year_var = dt_Bipl_1year_var.Compute("Sum(PenaltyPercentAge)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                CTSL_Bipl_1year_var = dt_Bipl_1year_var.Compute("Sum(CTSL)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");
                QK_Bipl_1year_var = dt_Bipl_1year_var.Compute("Sum(QK)", "ClientId NOT IN ('50','2') AND UnitID in('3','11','96')");

            }
        }
        //end
        private void BindPenaltyMetrics()
        {
            ProductionController objProductionController = new ProductionController();
            DataSet PenaltyMetrics = objProductionController.GetPenaltyMetricsNew();


            GetOtherClientVal(PenaltyMetrics);




            foreach (GridViewRow GR in gvPenalty_Matrix.Rows)
            {
                HiddenField hdnfClientID = (HiddenField)GR.FindControl("hdnfClientID");
                //===================================C45_46============================
                Label lblAir_C45_46_1Week = (Label)GR.FindControl("lblAir_C45_46_1Week");
                Label lblInsp_C45_46_1Week = (Label)GR.FindControl("lblInsp_C45_46_1Week");
                Label lblPlt_C45_46_1Week = (Label)GR.FindControl("lblPlt_C45_46_1Week");
                Label lblShip_C45_46_1Week = (Label)GR.FindControl("lblShip_C45_46_1Week");
                Label lblPerc_C45_46_1Week = (Label)GR.FindControl("lblPerc_C45_46_1Week");
                Label lblCTSL_C45_46_1Week = (Label)GR.FindControl("lblCTSL_C45_46_1Week");

                Label lblAir_C45_46_3Month = (Label)GR.FindControl("lblAir_C45_46_3Month");
                Label lblInsp_C45_46_3Month = (Label)GR.FindControl("lblInsp_C45_46_3Month");
                Label lblPlt_C45_46_3Month = (Label)GR.FindControl("lblPlt_C45_46_3Month");
                Label lblShip_C45_46_3Month = (Label)GR.FindControl("lblShip_C45_46_3Month");
                Label lblPerc_C45_46_3Month = (Label)GR.FindControl("lblPerc_C45_46_3Month");
                Label lblCTSL_C45_46_3Month = (Label)GR.FindControl("lblCTSL_C45_46_3Month");

                Label lblAir_C45_46_1Year = (Label)GR.FindControl("lblAir_C45_46_1Year");
                Label lblInsp_C45_46_1Year = (Label)GR.FindControl("lblInsp_C45_46_1Year");
                Label lblPlt_C45_46_1Year = (Label)GR.FindControl("lblPlt_C45_46_1Year");
                Label lblShip_C45_46_1Year = (Label)GR.FindControl("lblShip_C45_46_1Year");
                Label lblPerc_C45_46_1Year = (Label)GR.FindControl("lblPerc_C45_46_1Year");
                Label lblCTSL_C45_46_1Year = (Label)GR.FindControl("lblCTSL_C45_46_1Year");

                //===================================C47============================
                Label lblAir_C47_1Week = (Label)GR.FindControl("lblAir_C47_1Week");
                Label lblInsp_C47_1Week = (Label)GR.FindControl("lblInsp_C47_1Week");
                Label lblPlt_C47_1Week = (Label)GR.FindControl("lblPlt_C47_1Week");
                Label lblShip_C47_1Week = (Label)GR.FindControl("lblShip_C47_1Week");
                Label lblPerc_C47_1Week = (Label)GR.FindControl("lblPerc_C47_1Week");
                Label lblCTSL_C47_1Week = (Label)GR.FindControl("lblCTSL_C47_1Week");

                Label lblAir_C47_3Month = (Label)GR.FindControl("lblAir_C47_3Month");
                Label lblInsp_C47_3Month = (Label)GR.FindControl("lblInsp_C47_3Month");
                Label lblPlt_C47_3Month = (Label)GR.FindControl("lblPlt_C47_3Month");
                Label lblShip_C47_3Month = (Label)GR.FindControl("lblShip_C47_3Month");
                Label lblPerc_C47_3Month = (Label)GR.FindControl("lblPerc_C47_3Month");
                Label lblCTSL_C47_3Month = (Label)GR.FindControl("lblCTSL_C47_3Month");

                Label lblAir_C47_1Year = (Label)GR.FindControl("lblAir_C47_1Year");
                Label lblInsp_C47_1Year = (Label)GR.FindControl("lblInsp_C47_1Year");
                Label lblPlt_C47_1Year = (Label)GR.FindControl("lblPlt_C47_1Year");
                Label lblShip_C47_1Year = (Label)GR.FindControl("lblShip_C47_1Year");
                Label lblPerc_C47_1Year = (Label)GR.FindControl("lblPerc_C47_1Year");
                Label lblCTSL_C47_1Year = (Label)GR.FindControl("lblCTSL_C47_1Year");

                //===================================D 169============================
                Label lblAir_D169_1Week = (Label)GR.FindControl("lblAir_D169_1Week");
                Label lblInsp_D169_1Week = (Label)GR.FindControl("lblInsp_D169_1Week");
                Label lblPlt_D169_1Week = (Label)GR.FindControl("lblPlt_D169_1Week");
                Label lblShip_D169_1Week = (Label)GR.FindControl("lblShip_D169_1Week");
                Label lblPerc_D169_1Week = (Label)GR.FindControl("lblPerc_D169_1Week");
                Label lblCTSL_D169_1Week = (Label)GR.FindControl("lblCTSL_D169_1Week");

                Label lblAir_D169_3Month = (Label)GR.FindControl("lblAir_D169_3Month");
                Label lblInsp_D169_3Month = (Label)GR.FindControl("lblInsp_D169_3Month");
                Label lblPlt_D169_3Month = (Label)GR.FindControl("lblPlt_D169_3Month");
                Label lblShip_D169_3Month = (Label)GR.FindControl("lblShip_D169_3Month");
                Label lblPerc_D169_3Month = (Label)GR.FindControl("lblPerc_D169_3Month");
                Label lblCTSL_D169_3Month = (Label)GR.FindControl("lblCTSL_D169_3Month");

                Label lblAir_D169_1Year = (Label)GR.FindControl("lblAir_D169_1Year");
                Label lblInsp_D169_1Year = (Label)GR.FindControl("lblInsp_D169_1Year");
                Label lblPlt_D169_1Year = (Label)GR.FindControl("lblPlt_D169_1Year");
                Label lblShip_D169_1Year = (Label)GR.FindControl("lblShip_D169_1Year");
                Label lblPerc_D169_1Year = (Label)GR.FindControl("lblPerc_D169_1Year");
                Label lblCTSL_D169_1Year = (Label)GR.FindControl("lblCTSL_D169_1Year");

                //===================================BIPL============================
                Label lblAir_BIPL_1Week = (Label)GR.FindControl("lblAir_BIPL_1Week");
                Label lblInsp_BIPL_1Week = (Label)GR.FindControl("lblInsp_BIPL_1Week");
                Label lblPlt_BIPL_1Week = (Label)GR.FindControl("lblPlt_BIPL_1Week");
                Label lblShip_BIPL_1Week = (Label)GR.FindControl("lblShip_BIPL_1Week");
                Label lblPerc_BIPL_1Week = (Label)GR.FindControl("lblPerc_BIPL_1Week");
                Label lblCTSL_BIPL_1Week = (Label)GR.FindControl("lblCTSL_BIPL_1Week");

                Label lblAir_BIPL_3Month = (Label)GR.FindControl("lblAir_BIPL_3Month");
                Label lblInsp_BIPL_3Month = (Label)GR.FindControl("lblInsp_BIPL_3Month");
                Label lblPlt_BIPL_3Month = (Label)GR.FindControl("lblPlt_BIPL_3Month");
                Label lblShip_BIPL_3Month = (Label)GR.FindControl("lblShip_BIPL_3Month");
                Label lblPerc_BIPL_3Month = (Label)GR.FindControl("lblPerc_BIPL_3Month");
                Label lblCTSL_BIPL_3Month = (Label)GR.FindControl("lblCTSL_BIPL_3Month");

                Label lblAir_BIPL_1Year = (Label)GR.FindControl("lblAir_BIPL_1Year");
                Label lblInsp_BIPL_1Year = (Label)GR.FindControl("lblInsp_BIPL_1Year");
                Label lblPlt_BIPL_1Year = (Label)GR.FindControl("lblPlt_BIPL_1Year");
                Label lblShip_BIPL_1Year = (Label)GR.FindControl("lblShip_BIPL_1Year");
                Label lblPerc_BIPL_1Year = (Label)GR.FindControl("lblPerc_BIPL_1Year");
                Label lblCTSL_BIPL_1Year = (Label)GR.FindControl("lblCTSL_BIPL_1Year");

                //================================================================C45_46=============================================================================
                DataRow[] result_C45_46_1week = PenaltyMetrics.Tables[0].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=11");//C 45-46 1week
                DataRow[] result_C45_46_3month = PenaltyMetrics.Tables[1].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=11");//C 45-46 3month
                DataRow[] result_C45_46_1year = PenaltyMetrics.Tables[2].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=11");//C 45-46 1Year



                //added by abhishek on 1/6/2017
                if (hdnfClientID.Value == "999")
                {
                    if (Air_C45_46_1Week_var == DBNull.Value)
                        Air_C45_46_1Week_var = 0;

                    if (Insp_C45_46_1Week_var == DBNull.Value)
                        Insp_C45_46_1Week_var = 0;

                    if (Plt_D169_1Week_var == DBNull.Value)
                        Plt_D169_1Week_var = 0;


                    if (Plt_C45_46_1Week_var == DBNull.Value)
                        Plt_C45_46_1Week_var = 0;

                    if (Ship_C45_46_1Week_var == DBNull.Value)
                        Ship_C45_46_1Week_var = 0;

                    if (Perc_C45_46_1Week_var == DBNull.Value)
                        Perc_C45_46_1Week_var = 0;

                    if (CTSL_C45_46_1Week_var == DBNull.Value)
                        CTSL_C45_46_1Week_var = 0;

                    //---------------------------------------------------
                    if (Air_C45_46_3Month_var == DBNull.Value)
                        Air_C45_46_3Month_var = 0;

                    if (Insp_C45_46_3Month_var == DBNull.Value)
                        Insp_C45_46_3Month_var = 0;

                    if (Plt_D169_3Month_var == DBNull.Value)
                        Plt_D169_3Month_var = 0;


                    if (Plt_C45_46_3Month_var == DBNull.Value)
                        Plt_C45_46_3Month_var = 0;

                    if (Ship_C45_46_3Month_var == DBNull.Value)
                        Ship_C45_46_3Month_var = 0;

                    if (Perc_C45_46_3Month_var == DBNull.Value)
                        Perc_C45_46_3Month_var = 0;

                    if (CTSL_C45_46_3Month_var == DBNull.Value)
                        CTSL_C45_46_3Month_var = 0;


                    //---------------------------------------------------
                    if (Air_C45_46_3Month_var == DBNull.Value)
                        Air_C45_46_3Month_var = 0;

                    if (Insp_C45_46_3Month_var == DBNull.Value)
                        Insp_C45_46_3Month_var = 0;

                    if (Plt_D169_3Month_var == DBNull.Value)
                        Plt_D169_3Month_var = 0;


                    if (Plt_C45_46_3Month_var == DBNull.Value)
                        Plt_C45_46_3Month_var = 0;

                    if (Ship_C45_46_3Month_var == DBNull.Value)
                        Ship_C45_46_3Month_var = 0;

                    if (Perc_C45_46_3Month_var == DBNull.Value)
                        Perc_C45_46_3Month_var = 0;

                    if (CTSL_C45_46_3Month_var == DBNull.Value)
                        CTSL_C45_46_3Month_var = 0;


                    //---------------------------------------------------

                   if (Air_C47_3Month_var== DBNull.Value)
                       Air_C47_3Month_var=0;
                   if (Insp_C47_3Month_var == DBNull.Value)
                       Insp_C47_3Month_var = 0;
                   if (Plt_C47_3Month_var == DBNull.Value)
                       Plt_C47_3Month_var = 0;
                   if (Ship_C47_3Month_var == DBNull.Value)
                       Ship_C47_3Month_var = 0;
                   if (Perc_C47_3Month_var == DBNull.Value)
                       Perc_C47_3Month_var = 0;
                   if (CTSL_C47_3Month_var == DBNull.Value)
                       CTSL_C47_3Month_var = 0;
                   if (Air_C47_1year_var == DBNull.Value)
                       Air_C47_1year_var = 0;
                   if (Insp_C47_1year_var == DBNull.Value)
                       Insp_C47_1year_var = 0;
                   if (Plt_C47_1year_var == DBNull.Value)
                       Plt_C47_1year_var = 0;
                   if (Ship_C47_1year_var == DBNull.Value)
                       Ship_C47_1year_var = 0;
                   if (Perc_C47_1year_var == DBNull.Value)
                       Perc_C47_1year_var = 0;
                   if (CTSL_C47_1year_var == DBNull.Value)
                       CTSL_C47_1year_var = 0;
                   if (Air_C47_1Week_var == DBNull.Value)
                       Air_C47_1Week_var = 0;
                   if (Insp_C47_1Week_var == DBNull.Value)
                       Insp_C47_1Week_var = 0;
                   if (Plt_C47_1Week_var == DBNull.Value)
                       Plt_C47_1Week_var = 0;
                   if (Ship_C47_1Week_var == DBNull.Value)
                       Ship_C47_1Week_var = 0;
                   if (Perc_C47_1Week_var == DBNull.Value)
                       Perc_C47_1Week_var = 0;
                   if (CTSL_C47_1Week_var == DBNull.Value)
                       CTSL_C47_1Week_var = 0;
                   if (Air_Bipl_1Week_var == DBNull.Value)
                       Air_Bipl_1Week_var = 0;
                   if (Insp_Bipl_1Week_var == DBNull.Value)
                       Insp_Bipl_1Week_var = 0;
                   if (Plt_Bipl_1Week_var == DBNull.Value)
                       Plt_Bipl_1Week_var = 0;
                   if (Ship_Bipl_1Week_var == DBNull.Value)
                       Ship_Bipl_1Week_var = 0;
                   if (Perc_Bipl_1Week_var == DBNull.Value)
                       Perc_Bipl_1Week_var = 0;
                   if (CTSL_Bipl_1Week_var == DBNull.Value)
                       CTSL_Bipl_1Week_var = 0;
                   if (Air_Bipl_3Month_var == DBNull.Value)
                       Air_Bipl_3Month_var = 0;
                   if (Insp_Bipl_3Month_var == DBNull.Value)
                       Insp_Bipl_3Month_var = 0;
                   if (Plt_Bipl_3Month_var == DBNull.Value)
                       Plt_Bipl_3Month_var = 0;
                   if (Ship_Bipl_3Month_var == DBNull.Value)
                       Ship_Bipl_3Month_var = 0;
                   if (Perc_Bipl_3Month_var == DBNull.Value)
                       Perc_Bipl_3Month_var = 0;
                   if (CTSL_Bipl_3Month_var == DBNull.Value)
                       CTSL_Bipl_3Month_var = 0;
                   if (Air_Bipl_1year_var == DBNull.Value)
                       Air_Bipl_1year_var = 0;
                   if (Insp_Bipl_1year_var == DBNull.Value)
                       Insp_Bipl_1year_var = 0;
                   if (Plt_Bipl_1year_var == DBNull.Value)
                       Plt_Bipl_1year_var = 0;
                   if (Ship_Bipl_1year_var == DBNull.Value)
                       Ship_Bipl_1year_var = 0;
                   if (Perc_Bipl_1year_var == DBNull.Value)
                       Perc_Bipl_1year_var = 0;
                   if (CTSL_Bipl_1year_var == DBNull.Value)
                       CTSL_Bipl_1year_var = 0;
                  
                

                    //-----------------------------

                    if (Air_C45_46_1year_var == DBNull.Value)
                        Air_C45_46_1year_var = 0;

                    if (Insp_C45_46_1year_var == DBNull.Value)
                        Insp_C45_46_1year_var = 0;

                    if (Plt_D169_1year_var == DBNull.Value)
                        Plt_D169_1year_var = 0;


                    if (Plt_C45_46_1year_var == DBNull.Value)
                        Plt_C45_46_1year_var = 0;

                    if (Ship_C45_46_1year_var == DBNull.Value)
                        Ship_C45_46_1year_var = 0;

                    if (Perc_C45_46_1year_var == DBNull.Value)
                        Perc_C45_46_1year_var = 0;

                    if (CTSL_C45_46_1year_var == DBNull.Value)
                        CTSL_C45_46_1year_var = 0;


                    //=================================================C45_46==========================================================================//
                    lblAir_C45_46_1Week.Text = (Convert.ToDecimal(Air_C45_46_1Week_var) <= 0) ? "" : "&#x20B9;" + Air_C45_46_1Week_var.ToString() + "L";
                    lblInsp_C45_46_1Week.Text = (Convert.ToDecimal(Insp_C45_46_1Week_var) <= 0) ? "" : "&#x20B9;" + Insp_C45_46_1Week_var.ToString() + "L";
                    lblPlt_C45_46_1Week.Text = (Convert.ToDecimal(Plt_C45_46_1Week_var) <= 0) ? "" : "&#x20B9;" + Plt_C45_46_1Week_var.ToString() + "L";
                    lblShip_C45_46_1Week.Text = (Convert.ToDecimal(Ship_C45_46_1Week_var) <= 0) ? "" : "&#x20B9;" + Ship_C45_46_1Week_var.ToString() + "Cr";
                    lblPerc_C45_46_1Week.Text = (Convert.ToDecimal(Perc_C45_46_1Week_var) <= 0) ? "" : Perc_C45_46_1Week_var.ToString() + "%";
                    lblCTSL_C45_46_1Week.Text = (Convert.ToDecimal(CTSL_C45_46_1Week_var) <= 0) ? "" : "<span class='per'>" + CTSL_C45_46_1Week_var.ToString() + "%</span>" + "(" + QK_C45_46_1Week_var.ToString() + "K)";


                    lblAir_C45_46_3Month.Text = (Convert.ToDecimal(Air_C45_46_3Month_var) <= 0) ? "" : "&#x20B9;" + Air_C45_46_3Month_var.ToString() + "L";
                    lblInsp_C45_46_3Month.Text = (Convert.ToDecimal(Insp_C45_46_3Month_var) <= 0) ? "" : "&#x20B9;" + Insp_C45_46_3Month_var.ToString() + "L";
                    lblPlt_C45_46_3Month.Text = (Convert.ToDecimal(Plt_C45_46_3Month_var) <= 0) ? "" : "&#x20B9;" + Plt_C45_46_3Month_var.ToString() + "L";
                    lblShip_C45_46_3Month.Text = (Convert.ToDecimal(Ship_C45_46_3Month_var) <= 0) ? "" : "&#x20B9;" + Ship_C45_46_3Month_var.ToString() + "Cr";
                    lblPerc_C45_46_3Month.Text = (Convert.ToDecimal(Perc_C45_46_3Month_var) <= 0) ? "" : Perc_C45_46_3Month_var.ToString() + "%";
                    lblCTSL_C45_46_3Month.Text = (Convert.ToDecimal(CTSL_C45_46_3Month_var) <= 0) ? "" : "<span class='per'>" + CTSL_C45_46_3Month_var.ToString() + "%</span>" + "(" + QK_C45_46_3Month_var.ToString() + "K)";

                    lblAir_C45_46_1Year.Text = (Convert.ToDecimal(Air_C45_46_1year_var) <= 0) ? "" : "&#x20B9;" + Air_C45_46_1year_var.ToString() + "L";
                    lblInsp_C45_46_1Year.Text = (Convert.ToDecimal(Insp_C45_46_1year_var) <= 0) ? "" : "&#x20B9;" + Insp_C45_46_1year_var.ToString() + "L";
                    lblPlt_C45_46_1Year.Text = (Convert.ToDecimal(Plt_C45_46_1year_var) <= 0) ? "" : "&#x20B9;" + Plt_C45_46_1year_var.ToString() + "L";
                    lblShip_C45_46_1Year.Text = (Convert.ToDecimal(Ship_C45_46_1year_var) <= 0) ? "" : "&#x20B9;" + Ship_C45_46_1year_var.ToString() + "Cr";
                    lblPerc_C45_46_1Year.Text = (Convert.ToDecimal(Perc_C45_46_1year_var) <= 0) ? "" : Perc_C45_46_1year_var.ToString() + "%";
                    lblCTSL_C45_46_1Year.Text = (Convert.ToDecimal(CTSL_C45_46_1year_var) <= 0) ? "" : "<span class='per'>" + CTSL_C45_46_1year_var.ToString() + "%</span>" + "(" + QK_C45_46_1year_var.ToString() + "K)";

                    //=================================================C 47==========================================================================//
                    lblAir_C47_1Week.Text = (Convert.ToDecimal(Air_C47_1Week_var) <= 0) ? "" : "&#x20B9;" + Air_C47_1Week_var.ToString() + "L";
                    lblInsp_C47_1Week.Text = (Convert.ToDecimal(Insp_C47_1Week_var) <= 0) ? "" : "&#x20B9;" + Insp_C47_1Week_var.ToString() + "L";
                    lblPlt_C47_1Week.Text = (Convert.ToDecimal(Plt_C47_1Week_var) <= 0) ? "" : "&#x20B9;" + Plt_C47_1Week_var.ToString() + "L";
                    lblShip_C47_1Week.Text = (Convert.ToDecimal(Ship_C47_1Week_var) <= 0) ? "" : "&#x20B9;" + Ship_C47_1Week_var.ToString() + "Cr";
                    lblPerc_C47_1Week.Text = (Convert.ToDecimal(Perc_C47_1Week_var) <= 0) ? "" : Perc_C47_1Week_var.ToString() + "%";
                    lblCTSL_C47_1Week.Text = (Convert.ToDecimal(CTSL_C47_1Week_var) <= 0) ? "" : "<span class='per'>" + CTSL_C47_1Week_var.ToString() + "%</span>" + "(" + QK_C47_1Week_var.ToString() + "K)";


                    lblAir_C47_3Month.Text = (Convert.ToDecimal(Air_C47_3Month_var) <= 0) ? "" : "&#x20B9;" + Air_C47_3Month_var.ToString() + "L";
                    lblInsp_C47_3Month.Text = (Convert.ToDecimal(Insp_C47_3Month_var) <= 0) ? "" : "&#x20B9;" + Insp_C47_3Month_var.ToString() + "L";
                    lblPlt_C47_3Month.Text = (Convert.ToDecimal(Plt_C47_3Month_var) <= 0) ? "" : "&#x20B9;" + Plt_C47_3Month_var.ToString() + "L";
                    lblShip_C47_3Month.Text = (Convert.ToDecimal(Ship_C47_3Month_var) <= 0) ? "" : "&#x20B9;" + Ship_C47_3Month_var.ToString() + "Cr";
                    lblPerc_C47_3Month.Text = (Convert.ToDecimal(Perc_C47_3Month_var) <= 0) ? "" : Perc_C47_3Month_var.ToString() + "%";
                    lblCTSL_C47_3Month.Text = (Convert.ToDecimal(CTSL_C47_3Month_var) <= 0) ? "" : "<span class='per'>" + CTSL_C47_3Month_var.ToString() + "%</span>" + "(" + QK_C47_3Month_var.ToString() + "K)";

                    lblAir_C47_1Year.Text = (Convert.ToDecimal(Air_C47_1year_var) <= 0) ? "" : "&#x20B9;" + Air_C47_1year_var.ToString() + "L";
                    lblInsp_C47_1Year.Text = (Convert.ToDecimal(Insp_C47_1year_var) <= 0) ? "" : "&#x20B9;" + Insp_C47_1year_var.ToString() + "L";
                    lblPlt_C47_1Year.Text = (Convert.ToDecimal(Plt_C47_1year_var) <= 0) ? "" : "&#x20B9;" + Plt_C47_1year_var.ToString() + "L";
                    lblShip_C47_1Year.Text = (Convert.ToDecimal(Ship_C47_1year_var) <= 0) ? "" : "&#x20B9;" + Ship_C47_1year_var.ToString() + "Cr";
                    lblPerc_C47_1Year.Text = (Convert.ToDecimal(Perc_C47_1year_var) <= 0) ? "" : Perc_C47_1year_var.ToString() + "%";
                    lblCTSL_C47_1Year.Text = (Convert.ToDecimal(CTSL_C47_1year_var) <= 0) ? "" : "<span class='per'>" + CTSL_C47_1year_var.ToString() + "%</span>" + "(" + QK_C47_1year_var.ToString() + "K)";

                    //=================================================D 169==========================================================================//
                    if (Air_D169_1Week_var == DBNull.Value)
                        Air_D169_1Week_var = 0;
                    if (Insp_D169_1Week_var == DBNull.Value)
                        Insp_D169_1Week_var = 0;

                    if (Plt_D169_1Week_var == DBNull.Value)
                        Plt_D169_1Week_var = 0;
                    if (Ship_D169_1Week_var == DBNull.Value)
                        Ship_D169_1Week_var = 0;

                    if (Perc_D169_1Week_var == DBNull.Value)
                        Perc_D169_1Week_var = 0;

                    if (CTSL_D169_1Week_var == DBNull.Value)
                        CTSL_D169_1Week_var = 0;

                    if (QK_D169_1Week_var == DBNull.Value)
                        QK_D169_1Week_var = 0;

                    lblAir_D169_1Week.Text = (Convert.ToDecimal(Air_D169_1Week_var) <= 0) ? "" : "&#x20B9;" + Air_D169_1Week_var.ToString() + "L";
                    lblInsp_D169_1Week.Text = (Convert.ToDecimal(Insp_D169_1Week_var) <= 0) ? "" : "&#x20B9;" + Insp_D169_1Week_var.ToString() + "L";
                    lblPlt_D169_1Week.Text = (Convert.ToDecimal(Plt_D169_1Week_var) <= 0) ? "" : "&#x20B9;" + Plt_D169_1Week_var.ToString() + "L";
                    lblShip_D169_1Week.Text = (Convert.ToDecimal(Ship_D169_1Week_var) <= 0) ? "" : "&#x20B9;" + Ship_D169_1Week_var.ToString() + "Cr";
                    lblPerc_D169_1Week.Text = (Convert.ToDecimal(Perc_D169_1Week_var) <= 0) ? "" : Perc_D169_1Week_var.ToString() + "%";
                    lblCTSL_D169_1Week.Text = (Convert.ToDecimal(CTSL_D169_1Week_var) <= 0) ? "" : "<span class='per'>" + CTSL_D169_1Week_var.ToString() + "%</span>" + "(" + QK_D169_1Week_var.ToString() + "K)";

                    if (Air_D169_3Month_var == DBNull.Value)
                        Air_D169_3Month_var = 0;
                    if (Insp_D169_3Month_var == DBNull.Value)
                        Insp_D169_3Month_var = 0;

                    if (Plt_D169_3Month_var == DBNull.Value)
                        Plt_D169_3Month_var = 0;
                    if (Ship_D169_3Month_var == DBNull.Value)
                        Ship_D169_3Month_var = 0;

                    if (Perc_D169_3Month_var == DBNull.Value)
                        Perc_D169_3Month_var = 0;

                    if (CTSL_D169_3Month_var == DBNull.Value)
                        CTSL_D169_3Month_var = 0;

                    if (QK_D169_3Month_var == DBNull.Value)
                        QK_D169_3Month_var = 0;

                    lblAir_D169_3Month.Text = (Convert.ToDecimal(Air_D169_3Month_var) <= 0) ? "" : "&#x20B9;" + Air_D169_3Month_var.ToString() + "L";
                    lblInsp_D169_3Month.Text = (Convert.ToDecimal(Insp_D169_3Month_var) <= 0) ? "" : "&#x20B9;" + Insp_D169_3Month_var.ToString() + "L";
                    lblPlt_D169_3Month.Text = (Convert.ToDecimal(Plt_D169_3Month_var) <= 0) ? "" : "&#x20B9;" + Plt_D169_3Month_var.ToString() + "L";
                    lblShip_D169_3Month.Text = (Convert.ToDecimal(Ship_D169_3Month_var) <= 0) ? "" : "&#x20B9;" + Ship_D169_3Month_var.ToString() + "Cr";
                    lblPerc_D169_3Month.Text = (Convert.ToDecimal(Perc_D169_3Month_var) <= 0) ? "" : Perc_D169_3Month_var.ToString() + "%";
                    lblCTSL_D169_3Month.Text = (Convert.ToDecimal(CTSL_D169_3Month_var) <= 0) ? "" : "<span class='per'>" + CTSL_D169_3Month_var.ToString() + "%</span>" + "(" + QK_D169_3Month_var.ToString() + "K)";


                    if (Air_D169_1year_var == DBNull.Value)
                        Air_D169_1year_var = 0;
                    if (Insp_D169_1year_var == DBNull.Value)
                        Insp_D169_1year_var = 0;

                    if (Plt_D169_1year_var == DBNull.Value)
                        Plt_D169_1year_var = 0;
                    if (Ship_D169_1year_var == DBNull.Value)
                        Ship_D169_1year_var = 0;

                    if (Perc_D169_1year_var == DBNull.Value)
                        Perc_D169_1year_var = 0;

                    if (CTSL_D169_1year_var == DBNull.Value)
                        CTSL_D169_1year_var = 0;

                    if (QK_D169_1year_var == DBNull.Value)
                        QK_D169_1year_var = 0;


                    lblAir_D169_1Year.Text = (Convert.ToDecimal(Air_D169_1year_var) <= 0) ? "" : "&#x20B9;" + Air_D169_1year_var.ToString() + "L";
                    lblInsp_D169_1Year.Text = (Convert.ToDecimal(Insp_D169_1year_var) <= 0) ? "" : "&#x20B9;" + Insp_D169_1year_var.ToString() + "L";
                    lblPlt_D169_1Year.Text = (Convert.ToDecimal(Plt_D169_1year_var) <= 0) ? "" : "&#x20B9;" + Plt_D169_1year_var.ToString() + "L";
                    lblShip_D169_1Year.Text = (Convert.ToDecimal(Ship_D169_1year_var) <= 0) ? "" : "&#x20B9;" + Ship_D169_1year_var.ToString() + "Cr";
                    lblPerc_D169_1Year.Text = (Convert.ToDecimal(Perc_D169_1year_var) <= 0) ? "" : Perc_D169_1year_var.ToString() + "%";
                    lblCTSL_D169_1Year.Text = (Convert.ToDecimal(CTSL_D169_1year_var) <= 0) ? "" : "<span class='per'>" + CTSL_D169_1year_var.ToString() + "%</span>" + "(" + QK_D169_1year_var.ToString() + "K)";


                    //=================================================BIPL==========================================================================//
                    lblAir_BIPL_1Week.Text = (Convert.ToDecimal(Air_Bipl_1Week_var) <= 0) ? "" : "&#x20B9;" + Air_Bipl_1Week_var.ToString() + "L";
                    lblInsp_BIPL_1Week.Text = (Convert.ToDecimal(Insp_Bipl_1Week_var) <= 0) ? "" : "&#x20B9;" + Insp_Bipl_1Week_var.ToString() + "L";
                    lblPlt_BIPL_1Week.Text = (Convert.ToDecimal(Plt_Bipl_1Week_var) <= 0) ? "" : "&#x20B9;" + Plt_Bipl_1Week_var.ToString() + "L";
                    lblShip_BIPL_1Week.Text = (Convert.ToDecimal(Ship_Bipl_1Week_var) <= 0) ? "" : "&#x20B9;" + Ship_Bipl_1Week_var.ToString() + "Cr";
                    lblPerc_BIPL_1Week.Text = (Convert.ToDecimal(Perc_Bipl_1Week_var) <= 0) ? "" : Perc_Bipl_1Week_var.ToString() + "%";
                    lblCTSL_BIPL_1Week.Text = (Convert.ToDecimal(CTSL_Bipl_1Week_var) <= 0) ? "" : "<span class='per'>" + CTSL_Bipl_1Week_var.ToString() + "%</span>" + "(" + QK_Bipl_1Week_var.ToString() + "K)";


                    lblAir_BIPL_3Month.Text = (Convert.ToDecimal(Air_Bipl_3Month_var) <= 0) ? "" : "&#x20B9;" + Air_Bipl_3Month_var.ToString() + "L";
                    lblInsp_BIPL_3Month.Text = (Convert.ToDecimal(Insp_Bipl_3Month_var) <= 0) ? "" : "&#x20B9;" + Insp_Bipl_3Month_var.ToString() + "L";
                    lblPlt_BIPL_3Month.Text = (Convert.ToDecimal(Plt_Bipl_3Month_var) <= 0) ? "" : "&#x20B9;" + Plt_Bipl_3Month_var.ToString() + "L";
                    lblShip_BIPL_3Month.Text = (Convert.ToDecimal(Ship_Bipl_3Month_var) <= 0) ? "" : "&#x20B9;" + Ship_Bipl_3Month_var.ToString() + "Cr";
                    lblPerc_BIPL_3Month.Text = (Convert.ToDecimal(Perc_Bipl_3Month_var) <= 0) ? "" : Perc_Bipl_3Month_var.ToString() + "%";
                    lblCTSL_BIPL_3Month.Text = (Convert.ToDecimal(CTSL_Bipl_3Month_var) <= 0) ? "" : "<span class='per'>" + CTSL_Bipl_3Month_var.ToString() + "%</span>" + "(" + QK_Bipl_3Month_var.ToString() + "K)";

                    lblAir_BIPL_1Year.Text = (Convert.ToDecimal(Air_Bipl_1year_var) <= 0) ? "" : "&#x20B9;" + Air_Bipl_1year_var.ToString() + "L";
                    lblInsp_BIPL_1Year.Text = (Convert.ToDecimal(Insp_Bipl_1year_var) <= 0) ? "" : "&#x20B9;" + Insp_Bipl_1year_var.ToString() + "L";
                    lblPlt_BIPL_1Year.Text = (Convert.ToDecimal(Plt_Bipl_1year_var) <= 0) ? "" : "&#x20B9;" + Plt_Bipl_1year_var.ToString() + "L";
                    lblShip_BIPL_1Year.Text = (Convert.ToDecimal(Ship_Bipl_1year_var) <= 0) ? "" : "&#x20B9;" + Ship_Bipl_1year_var.ToString() + "Cr";
                    lblPerc_BIPL_1Year.Text = (Convert.ToDecimal(Perc_Bipl_1year_var) <= 0) ? "" : Perc_Bipl_1year_var.ToString() + "%";
                    lblCTSL_BIPL_1Year.Text = (Convert.ToDecimal(CTSL_Bipl_1year_var) <= 0) ? "" : "<span class='per'>" + CTSL_Bipl_1year_var.ToString() + "%</span>" + "(" + QK_Bipl_1year_var.ToString() + "K)";

                    var PercBIPL_1Week_other = (Convert.ToDecimal(Plt_Bipl_1Week_var) / (Convert.ToDecimal(Ship_Bipl_1Week_var) <= 0 ? 1 : (Convert.ToDecimal(Ship_Bipl_1Week_var) * 100))) * 100;
                    var PercBIPL_3Month_other = (Convert.ToDecimal(Plt_Bipl_3Month_var) / (Convert.ToDecimal(Ship_Bipl_3Month_var) <= 0 ? 1 : (Convert.ToDecimal(Ship_Bipl_3Month_var) * 100))) * 100;
                    var PercBIPL_1Year_other = (Convert.ToDecimal(Plt_Bipl_1year_var) / (Convert.ToDecimal(Ship_Bipl_1year_var) <= 0 ? 1 : (Convert.ToDecimal(Ship_Bipl_1year_var) * 100))) * 100;

                    lblPerc_BIPL_1Week.Text = (Convert.ToDecimal(PercBIPL_1Week_other) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(PercBIPL_1Week_other.ToString("0.0")) + "%</span>";
                    lblPerc_BIPL_3Month.Text = (Convert.ToDecimal(PercBIPL_3Month_other) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(PercBIPL_3Month_other.ToString("0.0")) + "%</span>";
                    lblPerc_BIPL_1Year.Text = (Convert.ToDecimal(PercBIPL_1Year_other) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(PercBIPL_1Year_other.ToString("0.0")) + "%</span>";
                  
                    break;
                }

                //end


                foreach (DataRow o in result_C45_46_1week)
                {
                    lblAir_C45_46_1Week.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_C45_46_1Week.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_C45_46_1Week.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_C45_46_1Week.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_C45_46_1Week.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_C45_46_1Week.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in result_C45_46_3month)
                {
                    lblAir_C45_46_3Month.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_C45_46_3Month.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_C45_46_3Month.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_C45_46_3Month.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_C45_46_3Month.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_C45_46_3Month.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in result_C45_46_1year)
                {
                    lblAir_C45_46_1Year.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_C45_46_1Year.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_C45_46_1Year.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_C45_46_1Year.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_C45_46_1Year.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_C45_46_1Year.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                //================================================================C47=============================================================================
                DataRow[] result_C47_1week = PenaltyMetrics.Tables[0].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=3");//C 47 1week
                DataRow[] result_C47_3month = PenaltyMetrics.Tables[1].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=3");//C 47 3month
                DataRow[] result_C47_1year = PenaltyMetrics.Tables[2].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=3");//C 47 1Year

                foreach (DataRow o in result_C47_1week)
                {
                    lblAir_C47_1Week.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_C47_1Week.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_C47_1Week.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_C47_1Week.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_C47_1Week.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_C47_1Week.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in result_C47_3month)
                {
                    lblAir_C47_3Month.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_C47_3Month.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_C47_3Month.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_C47_3Month.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_C47_3Month.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_C47_3Month.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in result_C47_1year)
                {
                    lblAir_C47_1Year.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_C47_1Year.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_C47_1Year.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_C47_1Year.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_C47_1Year.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_C47_1Year.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                //================================================================D 169=============================================================================
                DataRow[] result_D169_1week = PenaltyMetrics.Tables[0].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=96");//C 47 1week
                DataRow[] result_D169_3month = PenaltyMetrics.Tables[1].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=96");//C 47 3month
                DataRow[] result_D169_1year = PenaltyMetrics.Tables[2].Select("ClientId =" + hdnfClientID.Value + " AND UnitID=96");//C 47 1Year

                foreach (DataRow o in result_D169_1week)
                {
                    lblAir_D169_1Week.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_D169_1Week.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_D169_1Week.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_D169_1Week.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_D169_1Week.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_D169_1Week.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in result_D169_3month)
                {
                    lblAir_D169_3Month.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_D169_3Month.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_D169_3Month.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_D169_3Month.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_D169_3Month.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_D169_3Month.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in result_D169_1year)
                {
                    lblAir_D169_1Year.Text = (Convert.ToDecimal(o["Airing"]) <= 0) ? "" : "&#x20B9;" + o["Airing"].ToString() + "L";
                    lblInsp_D169_1Year.Text = (Convert.ToDecimal(o["InspectionFailandTransport"]) <= 0) ? "" : "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    lblPlt_D169_1Year.Text = (Convert.ToDecimal(o["TotalPenalty"]) <= 0) ? "" : "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    lblShip_D169_1Year.Text = (Convert.ToDecimal(o["ShippedValue"]) <= 0) ? "" : "&#x20B9;" + o["ShippedValue"].ToString() + "Cr";
                    lblPerc_D169_1Year.Text = (Convert.ToDecimal(o["PenaltyPercentAge"]) <= 0) ? "" : o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_D169_1Year.Text = (Convert.ToDecimal(o["CTSL"]) <= 0) ? "" : "<span class='per'>" + o["CTSL"].ToString() + "%</span>" + "(" + o["QK"].ToString() + "K)";
                }
                //======================================================================BIPL================================================================================================================
                #region BIPL
                var AirBIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("Airing"));
                var AirBIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("Airing"));
                var AirBIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("Airing"));

                var InspBIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
                var InspBIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
                var InspBIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("InspectionFailandTransport"));

                var PltBIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("TotalPenalty"));
                var PltBIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("TotalPenalty"));
                var PltBIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("TotalPenalty"));

                var ShipBIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("ShippedValue"));
                var ShipBIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("ShippedValue"));
                var ShipBIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("ShippedValue"));

                var PercBIPL_1Week = (PltBIPL_1Week / (Convert.ToDecimal(ShipBIPL_1Week) <= 0 ? 1 : ShipBIPL_1Week * 100)) * 100;
                var PercBIPL_3Month = (PltBIPL_3Month / (Convert.ToDecimal(ShipBIPL_3Month) <= 0 ? 1 : ShipBIPL_3Month * 100)) * 100;
                var PercBIPL_1Year = (PltBIPL_1Year / (Convert.ToDecimal(ShipBIPL_1Year) <= 0 ? 1 : ShipBIPL_1Year * 100)) * 100;

                var CTSLBIPL_1Week = PenaltyMetrics.Tables[4].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("CTSLByClientWeek"));
                var CTSLBIPL_3Month = PenaltyMetrics.Tables[4].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("CTSLByClientMonth"));
                var CTSLBIPL_1Year = PenaltyMetrics.Tables[4].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("CTSLByClientYear"));

                var QKBIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("QK"));
                var QKBIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("QK"));
                var QKBIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("ClientId") == Convert.ToInt64(hdnfClientID.Value)).Sum(row => row.Field<decimal>("QK"));


                lblAir_BIPL_1Week.Text = (Convert.ToDecimal(AirBIPL_1Week) <= 0) ? "" : "&#x20B9;" + AirBIPL_1Week.ToString() + "L";
                lblAir_BIPL_3Month.Text = (Convert.ToDecimal(AirBIPL_3Month) <= 0) ? "" : "&#x20B9;" + AirBIPL_3Month.ToString() + "L";
                lblAir_BIPL_1Year.Text = (Convert.ToDecimal(AirBIPL_1Year) <= 0) ? "" : "&#x20B9;" + AirBIPL_1Year.ToString() + "L";

                lblInsp_BIPL_1Week.Text = (Convert.ToDecimal(InspBIPL_1Week) <= 0) ? "" : "&#x20B9;" + InspBIPL_1Week.ToString() + "L";
                lblInsp_BIPL_3Month.Text = (Convert.ToDecimal(InspBIPL_3Month) <= 0) ? "" : "&#x20B9;" + InspBIPL_3Month.ToString() + "L";
                lblInsp_BIPL_1Year.Text = (Convert.ToDecimal(InspBIPL_1Year) <= 0) ? "" : "&#x20B9;" + InspBIPL_1Year.ToString() + "L";

                lblPlt_BIPL_1Week.Text = (Convert.ToDecimal(PltBIPL_1Week) <= 0) ? "" : "&#x20B9;" + PltBIPL_1Week.ToString() + "L";
                lblPlt_BIPL_3Month.Text = (Convert.ToDecimal(PltBIPL_3Month) <= 0) ? "" : "&#x20B9;" + PltBIPL_3Month.ToString() + "L";
                lblPlt_BIPL_1Year.Text = (Convert.ToDecimal(PltBIPL_1Year) <= 0) ? "" : "&#x20B9;" + PltBIPL_1Year.ToString() + "L";

                lblShip_BIPL_1Week.Text = (Convert.ToDecimal(ShipBIPL_1Week) <= 0) ? "" : "&#x20B9;" + ShipBIPL_1Week.ToString() + "Cr";
                lblShip_BIPL_3Month.Text = (Convert.ToDecimal(ShipBIPL_3Month) <= 0) ? "" : "&#x20B9;" + ShipBIPL_3Month.ToString() + "Cr";
                lblShip_BIPL_1Year.Text = (Convert.ToDecimal(ShipBIPL_1Year) <= 0) ? "" : "&#x20B9;" + ShipBIPL_1Year.ToString() + "Cr";

                lblPerc_BIPL_1Week.Text = (Convert.ToDecimal(PercBIPL_1Week) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(PercBIPL_1Week.ToString("0.0")) + "%</span>";
                lblPerc_BIPL_3Month.Text = (Convert.ToDecimal(PercBIPL_3Month) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(PercBIPL_3Month.ToString("0.0")) + "%</span>";
                lblPerc_BIPL_1Year.Text = (Convert.ToDecimal(PercBIPL_1Year) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(PercBIPL_1Year.ToString("0.0")) + "%</span>";

                lblCTSL_BIPL_1Week.Text = (Convert.ToDecimal(CTSLBIPL_1Week) <= 0) ? "" : "<span class='per'>" + CTSLBIPL_1Week.ToString() + "%</span>" + "(" + QKBIPL_1Week + "K)";
                lblCTSL_BIPL_3Month.Text = (Convert.ToDecimal(CTSLBIPL_3Month) <= 0) ? "" : "<span class='per'>" + CTSLBIPL_3Month.ToString() + "%</span>" + "(" + QKBIPL_3Month + "K)";
                lblCTSL_BIPL_1Year.Text = (Convert.ToDecimal(CTSLBIPL_1Year) <= 0) ? "" : "<span class='per'>" + CTSLBIPL_1Year.ToString() + "%</span>" + "(" + QKBIPL_1Year + "K)";
                #endregion
            }
            //=================================== BIPL TOTAL================================================================
            #region BIPL TOTAL
            //===================================C45_46======================================================
            Label lblFAir_C45_46_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_C45_46_1Week");
            Label lblFInsp_C45_46_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_C45_46_1Week");
            Label lblFPlt_C45_46_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_C45_46_1Week");
            Label lblFShip_C45_46_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_C45_46_1Week");
            Label lblFPerc_C45_46_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_C45_46_1Week");
            Label lblFCTSL_C45_46_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_C45_46_1Week");

            Label lblFAir_C45_46_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_C45_46_3Month");
            Label lblFInsp_C45_46_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_C45_46_3Month");
            Label lblFPlt_C45_46_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_C45_46_3Month");
            Label lblFShip_C45_46_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_C45_46_3Month");
            Label lblFPerc_C45_46_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_C45_46_3Month");
            Label lblFCTSL_C45_46_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_C45_46_3Month");

            Label lblFAir_C45_46_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_C45_46_1Year");
            Label lblFInsp_C45_46_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_C45_46_1Year");
            Label lblFPlt_C45_46_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_C45_46_1Year");
            Label lblFShip_C45_46_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_C45_46_1Year");
            Label lblFPerc_C45_46_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_C45_46_1Year");
            Label lblFCTSL_C45_46_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_C45_46_1Year");

            //===================================C47========================================================
            Label lblFAir_C47_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_C47_1Week");
            Label lblFInsp_C47_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_C47_1Week");
            Label lblFPlt_C47_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_C47_1Week");
            Label lblFShip_C47_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_C47_1Week");
            Label lblFPerc_C47_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_C47_1Week");
            Label lblFCTSL_C47_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_C47_1Week");

            Label lblFAir_C47_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_C47_3Month");
            Label lblFInsp_C47_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_C47_3Month");
            Label lblFPlt_C47_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_C47_3Month");
            Label lblFShip_C47_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_C47_3Month");
            Label lblFPerc_C47_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_C47_3Month");
            Label lblFCTSL_C47_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_C47_3Month");

            Label lblFAir_C47_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_C47_1Year");
            Label lblFInsp_C47_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_C47_1Year");
            Label lblFPlt_C47_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_C47_1Year");
            Label lblFShip_C47_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_C47_1Year");
            Label lblFPerc_C47_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_C47_1Year");
            Label lblFCTSL_C47_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_C47_1Year");

            //===================================D 169=======================================================
            Label lblFAir_D169_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_D169_1Week");
            Label lblFInsp_D169_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_D169_1Week");
            Label lblFPlt_D169_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_D169_1Week");
            Label lblFShip_D169_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_D169_1Week");
            Label lblFPerc_D169_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_D169_1Week");
            Label lblFCTSL_D169_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_D169_1Week");

            Label lblFAir_D169_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_D169_3Month");
            Label lblFInsp_D169_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_D169_3Month");
            Label lblFPlt_D169_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_D169_3Month");
            Label lblFShip_D169_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_D169_3Month");
            Label lblFPerc_D169_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_D169_3Month");
            Label lblFCTSL_D169_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_D169_3Month");

            Label lblFAir_D169_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_D169_1Year");
            Label lblFInsp_D169_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_D169_1Year");
            Label lblFPlt_D169_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_D169_1Year");
            Label lblFShip_D169_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_D169_1Year");
            Label lblFPerc_D169_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_D169_1Year");
            Label lblFCTSL_D169_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_D169_1Year");

            //===================================BIPL=======================================================
            Label lblFAir_BIPL_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_BIPL_1Week");
            Label lblFInsp_BIPL_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_BIPL_1Week");
            Label lblFPlt_BIPL_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_BIPL_1Week");
            Label lblFShip_BIPL_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_BIPL_1Week");
            Label lblFPerc_BIPL_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_BIPL_1Week");
            Label lblFCTSL_BIPL_1Week = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_BIPL_1Week");

            Label lblFAir_BIPL_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_BIPL_3Month");
            Label lblFInsp_BIPL_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_BIPL_3Month");
            Label lblFPlt_BIPL_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_BIPL_3Month");
            Label lblFShip_BIPL_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_BIPL_3Month");
            Label lblFPerc_BIPL_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_BIPL_3Month");
            Label lblFCTSL_BIPL_3Month = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_BIPL_3Month");

            Label lblFAir_BIPL_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFAir_BIPL_1Year");
            Label lblFInsp_BIPL_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFInsp_BIPL_1Year");
            Label lblFPlt_BIPL_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPlt_BIPL_1Year");
            Label lblFShip_BIPL_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFShip_BIPL_1Year");
            Label lblFPerc_BIPL_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFPerc_BIPL_1Year");
            Label lblFCTSL_BIPL_1Year = (Label)gvPenalty_Matrix.FooterRow.FindControl("lblFCTSL_BIPL_1Year");

            //========================================================C45_46======================================================
            var TotalAir_C45_46_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_C45_46_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_C45_46_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_C45_46_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_C45_46_1Week = (TotalPlt_C45_46_1Week / (Convert.ToDecimal(TotalShip_C45_46_1Week) <= 0 ? 1 : TotalShip_C45_46_1Week * 100)) * 100;
            var TotalCTSL_C45_46_1Week = PenaltyMetrics.Tables[3].Rows[0]["CTSLByWeek_C_45_46"];
            var TotalQK_C45_46_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("QK"));

            lblFAir_C45_46_1Week.Text = (Convert.ToDecimal(TotalAir_C45_46_1Week) <= 0) ? "" : "&#x20B9;" + TotalAir_C45_46_1Week.ToString() + "L";
            lblFInsp_C45_46_1Week.Text = (Convert.ToDecimal(TotalInsp_C45_46_1Week) <= 0) ? "" : "&#x20B9;" + TotalInsp_C45_46_1Week.ToString() + "L";
            lblFPlt_C45_46_1Week.Text = (Convert.ToDecimal(TotalPlt_C45_46_1Week) <= 0) ? "" : "&#x20B9;" + TotalPlt_C45_46_1Week.ToString() + "L";
            lblFShip_C45_46_1Week.Text = (Convert.ToDecimal(TotalShip_C45_46_1Week) <= 0) ? "" : "&#x20B9;" + TotalShip_C45_46_1Week.ToString() + "Cr";
            lblFPerc_C45_46_1Week.Text = (Convert.ToDecimal(TotalPerc_C45_46_1Week) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_C45_46_1Week.ToString("0.0")) + "%</span>";
            lblFCTSL_C45_46_1Week.Text = (Convert.ToDecimal(TotalCTSL_C45_46_1Week) <= 0) ? "" : "<span class='per'>" + TotalCTSL_C45_46_1Week.ToString() + "%</span>" + "(" + TotalQK_C45_46_1Week + "K)";

            var TotalAir_C45_46_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_C45_46_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_C45_46_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_C45_46_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_C45_46_3Month = (TotalPlt_C45_46_3Month / (Convert.ToDecimal(TotalShip_C45_46_3Month) <= 0 ? 1 : TotalShip_C45_46_3Month * 100)) * 100;
            var TotalCTSL_C45_46_3Month = PenaltyMetrics.Tables[3].Rows[0]["CTSLByMonth_C_45_46"];
            var TotalQK_C45_46_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("QK"));

            lblFAir_C45_46_3Month.Text = (Convert.ToDecimal(TotalAir_C45_46_3Month) <= 0) ? "" : "&#x20B9;" + TotalAir_C45_46_3Month.ToString() + "L";
            lblFInsp_C45_46_3Month.Text = (Convert.ToDecimal(TotalInsp_C45_46_3Month) <= 0) ? "" : "&#x20B9;" + TotalInsp_C45_46_3Month.ToString() + "L";
            lblFPlt_C45_46_3Month.Text = (Convert.ToDecimal(TotalPlt_C45_46_3Month) <= 0) ? "" : "&#x20B9;" + TotalPlt_C45_46_3Month.ToString() + "L";
            lblFShip_C45_46_3Month.Text = (Convert.ToDecimal(TotalShip_C45_46_3Month) <= 0) ? "" : "&#x20B9;" + TotalShip_C45_46_3Month.ToString() + "Cr";
            lblFPerc_C45_46_3Month.Text = (Convert.ToDecimal(TotalPerc_C45_46_3Month) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_C45_46_3Month.ToString("0.0")) + "%</span>";
            lblFCTSL_C45_46_3Month.Text = (Convert.ToDecimal(TotalCTSL_C45_46_3Month) <= 0) ? "" : "<span class='per'>" + TotalCTSL_C45_46_3Month.ToString() + "%</span>" + "(" + TotalQK_C45_46_3Month + "K)";

            var TotalAir_C45_46_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_C45_46_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_C45_46_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_C45_46_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_C45_46_1Year = (TotalPlt_C45_46_1Year / (Convert.ToDecimal(TotalShip_C45_46_1Year) <= 0 ? 1 : TotalShip_C45_46_1Year * 100)) * 100;
            var TotalCTSL_C45_46_1Year = PenaltyMetrics.Tables[3].Rows[0]["CTSLByYear_C_45_46"];
            var TotalQK_C45_46_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 11).Sum(row => row.Field<decimal>("QK"));

            lblFAir_C45_46_1Year.Text = (Convert.ToDecimal(TotalAir_C45_46_1Year) <= 0) ? "" : "&#x20B9;" + TotalAir_C45_46_1Year.ToString() + "L";
            lblFInsp_C45_46_1Year.Text = (Convert.ToDecimal(TotalInsp_C45_46_1Year) <= 0) ? "" : "&#x20B9;" + TotalInsp_C45_46_1Year.ToString() + "L";
            lblFPlt_C45_46_1Year.Text = (Convert.ToDecimal(TotalPlt_C45_46_1Year) <= 0) ? "" : "&#x20B9;" + TotalPlt_C45_46_1Year.ToString() + "L";
            lblFShip_C45_46_1Year.Text = (Convert.ToDecimal(TotalShip_C45_46_1Year) <= 0) ? "" : "&#x20B9;" + TotalShip_C45_46_1Year.ToString() + "Cr";
            lblFPerc_C45_46_1Year.Text = (Convert.ToDecimal(TotalPerc_C45_46_1Year) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_C45_46_1Year.ToString("0.0")) + "%</span>";
            lblFCTSL_C45_46_1Year.Text = (Convert.ToDecimal(TotalCTSL_C45_46_1Year) <= 0) ? "" : "<span class='per'>" + TotalCTSL_C45_46_1Year.ToString() + "%</span>" + "(" + TotalQK_C45_46_1Year + "K)";

            //========================================================C47===================================================================================================================
            var TotalAir_C47_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_C47_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_C47_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_C47_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_C47_1Week = (TotalPlt_C47_1Week / (Convert.ToDecimal(TotalShip_C47_1Week) <= 0 ? 1 : TotalShip_C47_1Week * 100)) * 100;
            var TotalCTSL_C47_1Week = PenaltyMetrics.Tables[3].Rows[0]["CTSLByWeek_C_47"];
            var TotalQK_C47_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("QK"));

            lblFAir_C47_1Week.Text = (Convert.ToDecimal(TotalAir_C47_1Week) <= 0) ? "" : "&#x20B9;" + TotalAir_C47_1Week.ToString() + "L";
            lblFInsp_C47_1Week.Text = (Convert.ToDecimal(TotalInsp_C47_1Week) <= 0) ? "" : "&#x20B9;" + TotalInsp_C47_1Week.ToString() + "L";
            lblFPlt_C47_1Week.Text = (Convert.ToDecimal(TotalPlt_C47_1Week) <= 0) ? "" : "&#x20B9;" + TotalPlt_C47_1Week.ToString() + "L";
            lblFShip_C47_1Week.Text = (Convert.ToDecimal(TotalShip_C47_1Week) <= 0) ? "" : "&#x20B9;" + TotalShip_C47_1Week.ToString() + "Cr";
            lblFPerc_C47_1Week.Text = (Convert.ToDecimal(TotalPerc_C47_1Week) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_C47_1Week.ToString("0.0")) + "%</span>";
            lblFCTSL_C47_1Week.Text = (Convert.ToDecimal(TotalCTSL_C47_1Week) <= 0) ? "" : "<span class='per'>" + TotalCTSL_C47_1Week.ToString() + "%</span>" + "(" + TotalQK_C47_1Week + "K)";

            var TotalAir_C47_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_C47_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_C47_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_C47_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_C47_3Month = (TotalPlt_C47_3Month / (Convert.ToDecimal(TotalShip_C47_3Month) <= 0 ? 1 : TotalShip_C47_3Month * 100)) * 100;
            var TotalCTSL_C47_3Month = PenaltyMetrics.Tables[3].Rows[0]["CTSLByMonth_C_47"];
            var TotalQK_C47_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("QK"));

            lblFAir_C47_3Month.Text = (Convert.ToDecimal(TotalAir_C47_3Month) <= 0) ? "" : "&#x20B9;" + TotalAir_C47_3Month.ToString() + "L";
            lblFInsp_C47_3Month.Text = (Convert.ToDecimal(TotalInsp_C47_3Month) <= 0) ? "" : "&#x20B9;" + TotalInsp_C47_3Month.ToString() + "L";
            lblFPlt_C47_3Month.Text = (Convert.ToDecimal(TotalPlt_C47_3Month) <= 0) ? "" : "&#x20B9;" + TotalPlt_C47_3Month.ToString() + "L";
            lblFShip_C47_3Month.Text = (Convert.ToDecimal(TotalShip_C47_3Month) <= 0) ? "" : "&#x20B9;" + TotalShip_C47_3Month.ToString() + "Cr";
            lblFPerc_C47_3Month.Text = (Convert.ToDecimal(TotalPerc_C47_3Month) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_C47_3Month.ToString("0.0")) + "%</span>";
            lblFCTSL_C47_3Month.Text = (Convert.ToDecimal(TotalCTSL_C47_3Month) <= 0) ? "" : "<span class='per'>" + TotalCTSL_C47_3Month.ToString() + "%</span>" + "(" + TotalQK_C47_3Month + "K)";

            var TotalAir_C47_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_C47_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_C47_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_C47_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_C47_1Year = (TotalPlt_C47_1Year / (Convert.ToDecimal(TotalShip_C47_1Year) <= 0 ? 1 : TotalShip_C47_1Year * 100)) * 100;
            var TotalCTSL_C47_1Year = PenaltyMetrics.Tables[3].Rows[0]["CTSLByYear_C_47"];
            var TotalQK_C47_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 3).Sum(row => row.Field<decimal>("QK"));

            lblFAir_C47_1Year.Text = (Convert.ToDecimal(TotalAir_C47_1Year) <= 0) ? "" : "&#x20B9;" + TotalAir_C47_1Year.ToString() + "L";
            lblFInsp_C47_1Year.Text = (Convert.ToDecimal(TotalInsp_C47_1Year) <= 0) ? "" : "&#x20B9;" + TotalInsp_C47_1Year.ToString() + "L";
            lblFPlt_C47_1Year.Text = (Convert.ToDecimal(TotalPlt_C47_1Year) <= 0) ? "" : "&#x20B9;" + TotalPlt_C47_1Year.ToString() + "L";
            lblFShip_C47_1Year.Text = (Convert.ToDecimal(TotalShip_C47_1Year) <= 0) ? "" : "&#x20B9;" + TotalShip_C47_1Year.ToString() + "Cr";
            lblFPerc_C47_1Year.Text = (Convert.ToDecimal(TotalPerc_C47_1Year) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_C47_1Year.ToString("0.0")) + "%</span>";
            lblFCTSL_C47_1Year.Text = (Convert.ToDecimal(TotalCTSL_C47_1Year) <= 0) ? "" : "<span class='per'>" + TotalCTSL_C47_1Year.ToString() + "%</span>" + "(" + TotalQK_C47_1Year + "K)";

            //========================================================D 169===================================================================================================================
            var TotalAir_D169_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_D169_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_D169_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_D169_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_D169_1Week = (TotalPlt_D169_1Week / (Convert.ToDecimal(TotalShip_D169_1Week) <= 0 ? 1 : TotalShip_D169_1Week * 100)) * 100;
            var TotalCTSL_D169_1Week = PenaltyMetrics.Tables[3].Rows[0]["CTSLByWeek_D169"];
            var TotalQK_D169_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("QK"));

            lblFAir_D169_1Week.Text = (Convert.ToDecimal(TotalAir_D169_1Week) <= 0) ? "" : "&#x20B9;" + TotalAir_D169_1Week.ToString() + "L";
            lblFInsp_D169_1Week.Text = (Convert.ToDecimal(TotalInsp_D169_1Week) <= 0) ? "" : "&#x20B9;" + TotalInsp_D169_1Week.ToString() + "L";
            lblFPlt_D169_1Week.Text = (Convert.ToDecimal(TotalPlt_D169_1Week) <= 0) ? "" : "&#x20B9;" + TotalPlt_D169_1Week.ToString() + "L";
            lblFShip_D169_1Week.Text = (Convert.ToDecimal(TotalShip_D169_1Week) <= 0) ? "" : "&#x20B9;" + TotalShip_D169_1Week.ToString() + "Cr";
            lblFPerc_D169_1Week.Text = (Convert.ToDecimal(TotalPerc_D169_1Week) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_D169_1Week.ToString("0.0")) + "%</span>";
            lblFCTSL_D169_1Week.Text = (Convert.ToDecimal(TotalCTSL_D169_1Week) <= 0) ? "" : "<span class='per'>" + TotalCTSL_D169_1Week.ToString() + "%</span>" + "(" + TotalQK_D169_1Week + "K)";

            var TotalAir_D169_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_D169_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_D169_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_D169_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_D169_3Month = (TotalPlt_D169_3Month / (Convert.ToDecimal(TotalShip_D169_3Month) <= 0 ? 1 : TotalShip_D169_3Month * 100)) * 100;
            var TotalCTSL_D169_3Month = PenaltyMetrics.Tables[3].Rows[0]["CTSLByMonth_D169"];
            var TotalQK_D169_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("QK"));

            lblFAir_D169_3Month.Text = (Convert.ToDecimal(TotalAir_D169_3Month) <= 0) ? "" : "&#x20B9;" + TotalAir_D169_3Month.ToString() + "L";
            lblFInsp_D169_3Month.Text = (Convert.ToDecimal(TotalInsp_D169_3Month) <= 0) ? "" : "&#x20B9;" + TotalInsp_D169_3Month.ToString() + "L";
            lblFPlt_D169_3Month.Text = (Convert.ToDecimal(TotalPlt_D169_3Month) <= 0) ? "" : "&#x20B9;" + TotalPlt_D169_3Month.ToString() + "L";
            lblFShip_D169_3Month.Text = (Convert.ToDecimal(TotalShip_D169_3Month) <= 0) ? "" : "&#x20B9;" + TotalShip_D169_3Month.ToString() + "Cr";
            lblFPerc_D169_3Month.Text = (Convert.ToDecimal(TotalPerc_D169_3Month) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_D169_3Month.ToString("0.0")) + "%</span>";
            lblFCTSL_D169_3Month.Text = (Convert.ToDecimal(TotalCTSL_D169_3Month) <= 0) ? "" : "<span class='per'>" + TotalCTSL_D169_3Month.ToString() + "%</span>" + "(" + TotalQK_D169_3Month + "K)";

            var TotalAir_D169_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_D169_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_D169_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_D169_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_D169_1Year = (TotalPlt_D169_1Year / (Convert.ToDecimal(TotalShip_D169_1Year) <= 0 ? 1 : TotalShip_D169_1Year * 100)) * 100;
            var TotalCTSL_D169_1Year = PenaltyMetrics.Tables[3].Rows[0]["CTSLByYear_D169"];
            var TotalQK_D169_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Where(row => row.Field<Int64>("UnitId") == 96).Sum(row => row.Field<decimal>("QK"));

            lblFAir_D169_1Year.Text = (Convert.ToDecimal(TotalAir_D169_1Year) <= 0) ? "" : "&#x20B9;" + TotalAir_D169_1Year.ToString() + "L";
            lblFInsp_D169_1Year.Text = (Convert.ToDecimal(TotalInsp_D169_1Year) <= 0) ? "" : "&#x20B9;" + TotalInsp_D169_1Year.ToString() + "L";
            lblFPlt_D169_1Year.Text = (Convert.ToDecimal(TotalPlt_D169_1Year) <= 0) ? "" : "&#x20B9;" + TotalPlt_D169_1Year.ToString() + "L";
            lblFShip_D169_1Year.Text = (Convert.ToDecimal(TotalShip_D169_1Year) <= 0) ? "" : "&#x20B9;" + TotalShip_D169_1Year.ToString() + "Cr";
            lblFPerc_D169_1Year.Text = (Convert.ToDecimal(TotalPerc_D169_1Year) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_D169_1Year.ToString("0.0")) + "%</span>";
            lblFCTSL_D169_1Year.Text = (Convert.ToDecimal(TotalCTSL_D169_1Year) <= 0) ? "" : "<span class='per'>" + TotalCTSL_D169_1Year.ToString() + "%</span>" + "(" + TotalQK_D169_1Year + "K)";


            //========================================================BIPL===================================================================================================================
            var TotalAir_BIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_BIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_BIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_BIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_BIPL_1Week = (TotalPlt_BIPL_1Week / (Convert.ToDecimal(TotalShip_BIPL_1Week) <= 0 ? 1 : TotalShip_BIPL_1Week * 100)) * 100;
            var TotalCTSL_BIPL_1Week = PenaltyMetrics.Tables[3].Rows[0]["CTSLByWeek_BIPL"];
            var TotalQK_BIPL_1Week = PenaltyMetrics.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("QK"));

            lblFAir_BIPL_1Week.Text = (Convert.ToDecimal(TotalAir_BIPL_1Week) <= 0) ? "" : "&#x20B9;" + TotalAir_BIPL_1Week.ToString() + "L";
            lblFInsp_BIPL_1Week.Text = (Convert.ToDecimal(TotalInsp_BIPL_1Week) <= 0) ? "" : "&#x20B9;" + TotalInsp_BIPL_1Week.ToString() + "L";
            lblFPlt_BIPL_1Week.Text = (Convert.ToDecimal(TotalPlt_BIPL_1Week) <= 0) ? "" : "&#x20B9;" + TotalPlt_BIPL_1Week.ToString() + "L";
            lblFShip_BIPL_1Week.Text = (Convert.ToDecimal(TotalShip_BIPL_1Week) <= 0) ? "" : "&#x20B9;" + TotalShip_BIPL_1Week.ToString() + "Cr";
            lblFPerc_BIPL_1Week.Text = (Convert.ToDecimal(TotalPerc_BIPL_1Week) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_BIPL_1Week.ToString("0.0")) + "%</span>";
            lblFCTSL_BIPL_1Week.Text = (Convert.ToDecimal(TotalCTSL_BIPL_1Week) <= 0) ? "" : "<span class='per'>" + TotalCTSL_BIPL_1Week.ToString() + "%</span>" + "(" + TotalQK_BIPL_1Week + "K)";

            var TotalAir_BIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_BIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_BIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_BIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_BIPL_3Month = (TotalPlt_BIPL_3Month / (Convert.ToDecimal(TotalShip_BIPL_3Month) <= 0 ? 1 : TotalShip_BIPL_3Month * 100)) * 100;
            var TotalCTSL_BIPL_3Month = PenaltyMetrics.Tables[3].Rows[0]["CTSLByMonth_BIPL"];
            var TotalQK_BIPL_3Month = PenaltyMetrics.Tables[1].AsEnumerable().Sum(row => row.Field<decimal>("QK"));

            lblFAir_BIPL_3Month.Text = (Convert.ToDecimal(TotalAir_BIPL_3Month) <= 0) ? "" : "&#x20B9;" + TotalAir_BIPL_3Month.ToString() + "L";
            lblFInsp_BIPL_3Month.Text = (Convert.ToDecimal(TotalInsp_BIPL_3Month) <= 0) ? "" : "&#x20B9;" + TotalInsp_BIPL_3Month.ToString() + "L";
            lblFPlt_BIPL_3Month.Text = (Convert.ToDecimal(TotalPlt_BIPL_3Month) <= 0) ? "" : "&#x20B9;" + TotalPlt_BIPL_3Month.ToString() + "L";
            lblFShip_BIPL_3Month.Text = (Convert.ToDecimal(TotalShip_BIPL_3Month) <= 0) ? "" : "&#x20B9;" + TotalShip_BIPL_3Month.ToString() + "Cr";
            lblFPerc_BIPL_3Month.Text = (Convert.ToDecimal(TotalPerc_BIPL_3Month) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_BIPL_3Month.ToString("0.0")) + "%</span>";
            lblFCTSL_BIPL_3Month.Text = (Convert.ToDecimal(TotalCTSL_BIPL_3Month) <= 0) ? "" : "<span class='per'>" + TotalCTSL_BIPL_3Month.ToString() + "%</span>" + "(" + TotalQK_BIPL_3Month + "K)";

            var TotalAir_BIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Sum(row => row.Field<decimal>("Airing"));
            var TotalInsp_BIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Sum(row => row.Field<decimal>("InspectionFailandTransport"));
            var TotalPlt_BIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Sum(row => row.Field<decimal>("TotalPenalty"));
            var TotalShip_BIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Sum(row => row.Field<decimal>("ShippedValue"));
            var TotalPerc_BIPL_1Year = (TotalPlt_BIPL_1Year / (Convert.ToDecimal(TotalShip_BIPL_1Year) <= 0 ? 1 : TotalShip_BIPL_1Year * 100)) * 100;
            var TotalCTSL_BIPL_1Year = PenaltyMetrics.Tables[3].Rows[0]["CTSLByYear_BIPL"];
            var TotalQK_BIPL_1Year = PenaltyMetrics.Tables[2].AsEnumerable().Sum(row => row.Field<decimal>("QK"));

            lblFAir_BIPL_1Year.Text = (Convert.ToDecimal(TotalAir_BIPL_1Year) <= 0) ? "" : "&#x20B9;" + TotalAir_BIPL_1Year.ToString() + "L";
            lblFInsp_BIPL_1Year.Text = (Convert.ToDecimal(TotalInsp_BIPL_1Year) <= 0) ? "" : "&#x20B9;" + TotalInsp_BIPL_1Year.ToString() + "L";
            lblFPlt_BIPL_1Year.Text = (Convert.ToDecimal(TotalPlt_BIPL_1Year) <= 0) ? "" : "&#x20B9;" + TotalPlt_BIPL_1Year.ToString() + "L";
            lblFShip_BIPL_1Year.Text = (Convert.ToDecimal(TotalShip_BIPL_1Year) <= 0) ? "" : "&#x20B9;" + TotalShip_BIPL_1Year.ToString() + "Cr";
            lblFPerc_BIPL_1Year.Text = (Convert.ToDecimal(TotalPerc_BIPL_1Year) <= 0) ? "" : "<span class='per'>" + Convert.ToDecimal(TotalPerc_BIPL_1Year.ToString("0.0")) + "%</span>";
            lblFCTSL_BIPL_1Year.Text = (Convert.ToDecimal(TotalCTSL_BIPL_1Year) <= 0) ? "" : "<span class='per'>" + TotalCTSL_BIPL_1Year.ToString() + "%</span>" + "(" + TotalQK_BIPL_1Year + "K)";

            #endregion
        }
    }
}