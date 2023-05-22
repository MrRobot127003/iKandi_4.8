using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using iKandi.Common;
using System.Data;

namespace iKandi.Web.UserControls.Reports
{
    public partial class Penalty_Matrics : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();

        }

        private void BindData()
        {
            ProductionController objProductionController = new ProductionController();
            DataTable DT = objProductionController.GetCompanyName_Of_ShippedQty();
            gvPenalty_Matrics_Unit1.DataSource = DT;
            gvPenalty_Matrics_Unit1.DataBind();

            gvPenalty_Matrics_Unit2.DataSource = DT;
            gvPenalty_Matrics_Unit2.DataBind();

            gvPenalty_Matrics_Unit3.DataSource = DT;
            gvPenalty_Matrics_Unit3.DataBind();

            gvPenalty_Matrics_BIPL.DataSource = DT;
            gvPenalty_Matrics_BIPL.DataBind();
            BindPenaltyMetrics();
        }


        private void BindPenaltyMetrics()
        {
            ProductionController objProductionController = new ProductionController();
            DataSet PenaltyMetrics1 = objProductionController.GetPenaltyMetrics("3");//C 47
            DataSet PenaltyMetrics2 = objProductionController.GetPenaltyMetrics("11");//C 45-46
            DataSet PenaltyMetrics3 = objProductionController.GetPenaltyMetrics("12");//B 45
            DataSet PenaltyMetricsBIPL = objProductionController.GetPenaltyMetricsBIPL();//All
            //gvPenalty_Matrics_Unit1.HeaderRow.Cells[0].ColumnSpan = 2;
            //gvPenalty_Matrics_Unit1.HeaderRow.Cells[1].Visible = false;
            #region Unit1
            foreach (GridViewRow GR in gvPenalty_Matrics_Unit1.Rows)
            {

                HiddenField hdnfClientID = (HiddenField)GR.FindControl("hdnfClientID");
                Label lblExpressAiringToUK_1Week_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Week_C47");
                Label lblCIFAir_1Week_C47 = (Label)GR.FindControl("lblCIFAir_1Week_C47");
                Label lblFiftyPercentCIFAir_1Week_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Week_C47");
                Label lblAirToMumbai_1Week_C47 = (Label)GR.FindControl("lblAirToMumbai_1Week_C47");
                Label lblInspectionFailandTransport_1Week_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Week_C47");
                Label lblTotalPenalty_1Week_C47 = (Label)GR.FindControl("lblTotalPenalty_1Week_C47");
                Label lblShippedValue_1Week_C47 = (Label)GR.FindControl("lblShippedValue_1Week_C47");
                Label lblPenaltyPercentAge_1Week_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Week_C47");
                Label lblCTSL_1Week_C47 = (Label)GR.FindControl("lblCTSL_1Week_C47");



                Label lblExpressAiringToUK_1Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Month_C47");
                Label lblCIFAir_1Month_C47 = (Label)GR.FindControl("lblCIFAir_1Month_C47");
                Label lblFiftyPercentCIFAir_1Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Month_C47");
                Label lblAirToMumbai_1Month_C47 = (Label)GR.FindControl("lblAirToMumbai_1Month_C47");
                Label lblInspectionFailandTransport_1Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Month_C47");
                Label lblTotalPenalty_1Month_C47 = (Label)GR.FindControl("lblTotalPenalty_1Month_C47");
                Label lblShippedValue_1Month_C47 = (Label)GR.FindControl("lblShippedValue_1Month_C47");
                Label lblPenaltyPercentAge_1Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Month_C47");
                Label lblCTSL_1Month_C47 = (Label)GR.FindControl("lblCTSL_1Month_C47");

                Label lblExpressAiringToUK_6Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_6Month_C47");
                Label lblCIFAir_6Month_C47 = (Label)GR.FindControl("lblCIFAir_6Month_C47");
                Label lblFiftyPercentCIFAir_6Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_6Month_C47");
                Label lblAirToMumbai_6Month_C47 = (Label)GR.FindControl("lblAirToMumbai_6Month_C47");
                Label lblInspectionFailandTransport_6Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_6Month_C47");
                Label lblTotalPenalty_6Month_C47 = (Label)GR.FindControl("lblTotalPenalty_6Month_C47");
                Label lblShippedValue_6Month_C47 = (Label)GR.FindControl("lblShippedValue_6Month_C47");
                Label lblPenaltyPercentAge_6Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_6Month_C47");
                Label lblCTSL_6Month_C47 = (Label)GR.FindControl("lblCTSL_6Month_C47");

                Label lblExpressAiringToUK_1Year_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Year_C47");
                Label lblCIFAir_1Year_C47 = (Label)GR.FindControl("lblCIFAir_1Year_C47");
                Label lblFiftyPercentCIFAir_1Year_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Year_C47");
                Label lblAirToMumbai_1Year_C47 = (Label)GR.FindControl("lblAirToMumbai_1Year_C47");
                Label lblInspectionFailandTransport_1Year_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Year_C47");
                Label lblTotalPenalty_1Year_C47 = (Label)GR.FindControl("lblTotalPenalty_1Year_C47");
                Label lblShippedValue_1Year_C47 = (Label)GR.FindControl("lblShippedValue_1Year_C47");
                Label lblPenaltyPercentAge_1Year_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Year_C47");
                Label lblCTSL_1Year_C47 = (Label)GR.FindControl("lblCTSL_1Year_C47");

                DataRow[] resultweek = PenaltyMetrics1.Tables[0].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul1month = PenaltyMetrics1.Tables[1].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul6month = PenaltyMetrics1.Tables[2].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul12month = PenaltyMetrics1.Tables[3].Select("ClientId =" + hdnfClientID.Value);

                foreach (DataRow o in resultweek)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Week_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Week_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Week_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Week_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Week_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                   // lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                   
                    if (lblPenaltyPercentAge_1Week_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Week_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                    lblCTSL_1Week_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul1month)
                {
                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Month_C47.Text = "";
                    }

                    else
                    lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";

                   // lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";



                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                   // lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                   // lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";

                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";


                  //  lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";

                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";




                  //  lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";



                    //lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    if (lblPenaltyPercentAge_1Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                  
                    lblCTSL_1Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul6month)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_6Month_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_6Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_6Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_6Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_6Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                    //lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                   lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    if (lblPenaltyPercentAge_6Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_6Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    lblCTSL_6Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul12month)
                {


                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Year_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Year_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Year_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Year_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Year_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";

















                    //lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    if (lblPenaltyPercentAge_1Year_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Year_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    lblCTSL_1Year_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }
            }
            #endregion

            #region Unit2
            foreach (GridViewRow GR in gvPenalty_Matrics_Unit2.Rows)
            {

                HiddenField hdnfClientID = (HiddenField)GR.FindControl("hdnfClientID");

                Label lblExpressAiringToUK_1Week_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Week_C47");
                Label lblCIFAir_1Week_C47 = (Label)GR.FindControl("lblCIFAir_1Week_C47");
                Label lblFiftyPercentCIFAir_1Week_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Week_C47");
                Label lblAirToMumbai_1Week_C47 = (Label)GR.FindControl("lblAirToMumbai_1Week_C47");
                Label lblInspectionFailandTransport_1Week_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Week_C47");
                Label lblTotalPenalty_1Week_C47 = (Label)GR.FindControl("lblTotalPenalty_1Week_C47");
                Label lblShippedValue_1Week_C47 = (Label)GR.FindControl("lblShippedValue_1Week_C47");
                Label lblPenaltyPercentAge_1Week_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Week_C47");
                Label lblCTSL_1Week_C47 = (Label)GR.FindControl("lblCTSL_1Week_C47");



                Label lblExpressAiringToUK_1Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Month_C47");
                Label lblCIFAir_1Month_C47 = (Label)GR.FindControl("lblCIFAir_1Month_C47");
                Label lblFiftyPercentCIFAir_1Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Month_C47");
                Label lblAirToMumbai_1Month_C47 = (Label)GR.FindControl("lblAirToMumbai_1Month_C47");
                Label lblInspectionFailandTransport_1Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Month_C47");
                Label lblTotalPenalty_1Month_C47 = (Label)GR.FindControl("lblTotalPenalty_1Month_C47");
                Label lblShippedValue_1Month_C47 = (Label)GR.FindControl("lblShippedValue_1Month_C47");
                Label lblPenaltyPercentAge_1Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Month_C47");
                Label lblCTSL_1Month_C47 = (Label)GR.FindControl("lblCTSL_1Month_C47");

                Label lblExpressAiringToUK_6Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_6Month_C47");
                Label lblCIFAir_6Month_C47 = (Label)GR.FindControl("lblCIFAir_6Month_C47");
                Label lblFiftyPercentCIFAir_6Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_6Month_C47");
                Label lblAirToMumbai_6Month_C47 = (Label)GR.FindControl("lblAirToMumbai_6Month_C47");
                Label lblInspectionFailandTransport_6Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_6Month_C47");
                Label lblTotalPenalty_6Month_C47 = (Label)GR.FindControl("lblTotalPenalty_6Month_C47");
                Label lblShippedValue_6Month_C47 = (Label)GR.FindControl("lblShippedValue_6Month_C47");
                Label lblPenaltyPercentAge_6Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_6Month_C47");
                Label lblCTSL_6Month_C47 = (Label)GR.FindControl("lblCTSL_6Month_C47");

                Label lblExpressAiringToUK_1Year_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Year_C47");
                Label lblCIFAir_1Year_C47 = (Label)GR.FindControl("lblCIFAir_1Year_C47");
                Label lblFiftyPercentCIFAir_1Year_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Year_C47");
                Label lblAirToMumbai_1Year_C47 = (Label)GR.FindControl("lblAirToMumbai_1Year_C47");
                Label lblInspectionFailandTransport_1Year_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Year_C47");
                Label lblTotalPenalty_1Year_C47 = (Label)GR.FindControl("lblTotalPenalty_1Year_C47");
                Label lblShippedValue_1Year_C47 = (Label)GR.FindControl("lblShippedValue_1Year_C47");
                Label lblPenaltyPercentAge_1Year_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Year_C47");
                Label lblCTSL_1Year_C47 = (Label)GR.FindControl("lblCTSL_1Year_C47");

                DataRow[] resultweek = PenaltyMetrics2.Tables[0].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul1month = PenaltyMetrics2.Tables[1].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul6month = PenaltyMetrics2.Tables[2].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul12month = PenaltyMetrics2.Tables[3].Select("ClientId =" + hdnfClientID.Value);

                foreach (DataRow o in resultweek)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Week_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Week_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Week_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Week_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Week_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                    // lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    if (lblPenaltyPercentAge_1Week_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Week_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";




                    lblCTSL_1Week_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul1month)
                {
                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Month_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";

                    // lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";



                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    // lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    // lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";

                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";


                    //  lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";

                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";




                    //  lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";



                    //lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";


                    lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";



                    if (lblPenaltyPercentAge_1Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";



                    lblCTSL_1Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul6month)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_6Month_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_6Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_6Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_6Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_6Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                    //lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    if (lblPenaltyPercentAge_6Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_6Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    lblCTSL_6Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul12month)
                {


                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Year_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Year_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Year_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Year_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Year_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";

















                    //lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                      lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                    if (lblPenaltyPercentAge_1Year_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Year_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";




                 
                    lblCTSL_1Year_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }









                //foreach (DataRow o in resultweek)
                //{
                //    lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Week_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul1month)
                //{
                //    lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul6month)
                //{
                //    lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_6Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul12month)
                //{
                //    lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Year_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}
            }
            #endregion

            #region Unit3
            foreach (GridViewRow GR in gvPenalty_Matrics_Unit3.Rows)
            {

                HiddenField hdnfClientID = (HiddenField)GR.FindControl("hdnfClientID");

                Label lblExpressAiringToUK_1Week_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Week_C47");
                Label lblCIFAir_1Week_C47 = (Label)GR.FindControl("lblCIFAir_1Week_C47");
                Label lblFiftyPercentCIFAir_1Week_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Week_C47");
                Label lblAirToMumbai_1Week_C47 = (Label)GR.FindControl("lblAirToMumbai_1Week_C47");
                Label lblInspectionFailandTransport_1Week_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Week_C47");
                Label lblTotalPenalty_1Week_C47 = (Label)GR.FindControl("lblTotalPenalty_1Week_C47");
                Label lblShippedValue_1Week_C47 = (Label)GR.FindControl("lblShippedValue_1Week_C47");
                Label lblPenaltyPercentAge_1Week_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Week_C47");
                Label lblCTSL_1Week_C47 = (Label)GR.FindControl("lblCTSL_1Week_C47");

                Label lblExpressAiringToUK_1Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Month_C47");
                Label lblCIFAir_1Month_C47 = (Label)GR.FindControl("lblCIFAir_1Month_C47");
                Label lblFiftyPercentCIFAir_1Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Month_C47");
                Label lblAirToMumbai_1Month_C47 = (Label)GR.FindControl("lblAirToMumbai_1Month_C47");
                Label lblInspectionFailandTransport_1Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Month_C47");
                Label lblTotalPenalty_1Month_C47 = (Label)GR.FindControl("lblTotalPenalty_1Month_C47");
                Label lblShippedValue_1Month_C47 = (Label)GR.FindControl("lblShippedValue_1Month_C47");
                Label lblPenaltyPercentAge_1Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Month_C47");
                Label lblCTSL_1Month_C47 = (Label)GR.FindControl("lblCTSL_1Month_C47");

                Label lblExpressAiringToUK_6Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_6Month_C47");
                Label lblCIFAir_6Month_C47 = (Label)GR.FindControl("lblCIFAir_6Month_C47");
                Label lblFiftyPercentCIFAir_6Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_6Month_C47");
                Label lblAirToMumbai_6Month_C47 = (Label)GR.FindControl("lblAirToMumbai_6Month_C47");
                Label lblInspectionFailandTransport_6Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_6Month_C47");
                Label lblTotalPenalty_6Month_C47 = (Label)GR.FindControl("lblTotalPenalty_6Month_C47");
                Label lblShippedValue_6Month_C47 = (Label)GR.FindControl("lblShippedValue_6Month_C47");
                Label lblPenaltyPercentAge_6Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_6Month_C47");
                Label lblCTSL_6Month_C47 = (Label)GR.FindControl("lblCTSL_6Month_C47");

                Label lblExpressAiringToUK_1Year_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Year_C47");
                Label lblCIFAir_1Year_C47 = (Label)GR.FindControl("lblCIFAir_1Year_C47");
                Label lblFiftyPercentCIFAir_1Year_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Year_C47");
                Label lblAirToMumbai_1Year_C47 = (Label)GR.FindControl("lblAirToMumbai_1Year_C47");
                Label lblInspectionFailandTransport_1Year_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Year_C47");
                Label lblTotalPenalty_1Year_C47 = (Label)GR.FindControl("lblTotalPenalty_1Year_C47");
                Label lblShippedValue_1Year_C47 = (Label)GR.FindControl("lblShippedValue_1Year_C47");
                Label lblPenaltyPercentAge_1Year_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Year_C47");
                Label lblCTSL_1Year_C47 = (Label)GR.FindControl("lblCTSL_1Year_C47");

                DataRow[] resultweek = PenaltyMetrics3.Tables[0].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul1month = PenaltyMetrics3.Tables[1].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul6month = PenaltyMetrics3.Tables[2].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul12month = PenaltyMetrics3.Tables[3].Select("ClientId =" + hdnfClientID.Value);


                foreach (DataRow o in resultweek)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Week_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Week_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Week_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Week_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Week_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                    // lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    if (lblPenaltyPercentAge_1Week_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Week_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";




                    lblCTSL_1Week_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul1month)
                {
                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Month_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";

                    // lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";



                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    // lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    // lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";

                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";


                    //  lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";

                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";




                    //  lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";



                    //lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";


                    lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    if (lblPenaltyPercentAge_1Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";





                    lblCTSL_1Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul6month)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_6Month_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_6Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_6Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_6Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_6Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                    //lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                   lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    if (lblPenaltyPercentAge_6Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_6Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";




                    lblCTSL_6Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul12month)
                {


                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Year_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Year_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Year_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Year_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Year_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";

















                    //lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    if (lblPenaltyPercentAge_1Year_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Year_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    lblCTSL_1Year_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }











                //foreach (DataRow o in resultweek)
                //{
                //    lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Week_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul1month)
                //{
                //    lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul6month)
                //{
                //    lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_6Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul12month)
                //{
                //    lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Year_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}
            }
            #endregion

            #region BIPL
            foreach (GridViewRow GR in gvPenalty_Matrics_BIPL.Rows)
            {

                HiddenField hdnfClientID = (HiddenField)GR.FindControl("hdnfClientID");

                Label lblExpressAiringToUK_1Week_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Week_C47");
                Label lblCIFAir_1Week_C47 = (Label)GR.FindControl("lblCIFAir_1Week_C47");
                Label lblFiftyPercentCIFAir_1Week_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Week_C47");
                Label lblAirToMumbai_1Week_C47 = (Label)GR.FindControl("lblAirToMumbai_1Week_C47");
                Label lblInspectionFailandTransport_1Week_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Week_C47");
                Label lblTotalPenalty_1Week_C47 = (Label)GR.FindControl("lblTotalPenalty_1Week_C47");
                Label lblShippedValue_1Week_C47 = (Label)GR.FindControl("lblShippedValue_1Week_C47");
                Label lblPenaltyPercentAge_1Week_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Week_C47");
                Label lblCTSL_1Week_C47 = (Label)GR.FindControl("lblCTSL_1Week_C47");

                Label lblExpressAiringToUK_1Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Month_C47");
                Label lblCIFAir_1Month_C47 = (Label)GR.FindControl("lblCIFAir_1Month_C47");
                Label lblFiftyPercentCIFAir_1Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Month_C47");
                Label lblAirToMumbai_1Month_C47 = (Label)GR.FindControl("lblAirToMumbai_1Month_C47");
                Label lblInspectionFailandTransport_1Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Month_C47");
                Label lblTotalPenalty_1Month_C47 = (Label)GR.FindControl("lblTotalPenalty_1Month_C47");
                Label lblShippedValue_1Month_C47 = (Label)GR.FindControl("lblShippedValue_1Month_C47");
                Label lblPenaltyPercentAge_1Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Month_C47");
                Label lblCTSL_1Month_C47 = (Label)GR.FindControl("lblCTSL_1Month_C47");

                Label lblExpressAiringToUK_6Month_C47 = (Label)GR.FindControl("lblExpressAiringToUK_6Month_C47");
                Label lblCIFAir_6Month_C47 = (Label)GR.FindControl("lblCIFAir_6Month_C47");
                Label lblFiftyPercentCIFAir_6Month_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_6Month_C47");
                Label lblAirToMumbai_6Month_C47 = (Label)GR.FindControl("lblAirToMumbai_6Month_C47");
                Label lblInspectionFailandTransport_6Month_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_6Month_C47");
                Label lblTotalPenalty_6Month_C47 = (Label)GR.FindControl("lblTotalPenalty_6Month_C47");
                Label lblShippedValue_6Month_C47 = (Label)GR.FindControl("lblShippedValue_6Month_C47");
                Label lblPenaltyPercentAge_6Month_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_6Month_C47");
                Label lblCTSL_6Month_C47 = (Label)GR.FindControl("lblCTSL_6Month_C47");

                Label lblExpressAiringToUK_1Year_C47 = (Label)GR.FindControl("lblExpressAiringToUK_1Year_C47");
                Label lblCIFAir_1Year_C47 = (Label)GR.FindControl("lblCIFAir_1Year_C47");
                Label lblFiftyPercentCIFAir_1Year_C47 = (Label)GR.FindControl("lblFiftyPercentCIFAir_1Year_C47");
                Label lblAirToMumbai_1Year_C47 = (Label)GR.FindControl("lblAirToMumbai_1Year_C47");
                Label lblInspectionFailandTransport_1Year_C47 = (Label)GR.FindControl("lblInspectionFailandTransport_1Year_C47");
                Label lblTotalPenalty_1Year_C47 = (Label)GR.FindControl("lblTotalPenalty_1Year_C47");
                Label lblShippedValue_1Year_C47 = (Label)GR.FindControl("lblShippedValue_1Year_C47");
                Label lblPenaltyPercentAge_1Year_C47 = (Label)GR.FindControl("lblPenaltyPercentAge_1Year_C47");
                Label lblCTSL_1Year_C47 = (Label)GR.FindControl("lblCTSL_1Year_C47");

                DataRow[] resultweek = PenaltyMetricsBIPL.Tables[0].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul1month = PenaltyMetricsBIPL.Tables[1].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul6month = PenaltyMetricsBIPL.Tables[2].Select("ClientId =" + hdnfClientID.Value);
                DataRow[] resul12month = PenaltyMetricsBIPL.Tables[3].Select("ClientId =" + hdnfClientID.Value);


                foreach (DataRow o in resultweek)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Week_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Week_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Week_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Week_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Week_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Week_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                    // lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                    if (lblPenaltyPercentAge_1Week_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Week_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";



                    lblCTSL_1Week_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul1month)
                {
                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Month_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";

                    // lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";



                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    // lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    // lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";

                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";


                    //  lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";

                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";




                    //  lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";



                    //lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";


                    lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    if (lblPenaltyPercentAge_1Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";



                    lblCTSL_1Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul6month)
                {

                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_6Month_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_6Month_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_6Month_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_6Month_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_6Month_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_6Month_C47.Text = "";
                    }

                    else
                        lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";




                    //lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                   lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    if (lblPenaltyPercentAge_6Month_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_6Month_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";




                    lblCTSL_6Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }

                foreach (DataRow o in resul12month)
                {


                    if (o["ExpressAiringToUK"].ToString() == "0.0")
                    {
                        lblExpressAiringToUK_1Year_C47.Text = "";
                    }

                    else
                        lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";


                    if (o["CIFAir"].ToString() == "0.0")
                    {
                        lblCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";


                    if (o["FiftyPercentCIFAir"].ToString() == "0.0")
                    {
                        lblFiftyPercentCIFAir_1Year_C47.Text = "";
                    }

                    else
                        lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";


                    if (o["AirToMumbai"].ToString() == "0.0")
                    {
                        lblAirToMumbai_1Year_C47.Text = "";
                    }

                    else
                        lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";


                    if (o["InspectionFailandTransport"].ToString() == "0.0")
                    {
                        lblInspectionFailandTransport_1Year_C47.Text = "";
                    }

                    else
                        lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";



                    if (o["TotalPenalty"].ToString() == "0.0")
                    {
                        lblTotalPenalty_1Year_C47.Text = "";
                    }

                    else
                        lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";


                    if (o["ShippedValue"].ToString() == "0.0")
                    {
                        lblShippedValue_1Year_C47.Text = "";
                    }

                    else
                        lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";

















                    //lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                    //lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                    //lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                    //lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                    //lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                    //lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                    //lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                    lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";

                    if (lblPenaltyPercentAge_1Year_C47.Text == "0%")
                    {
                        lblPenaltyPercentAge_1Year_C47.Text = "";
                    }
                    else
                        lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";


                    lblCTSL_1Year_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                }













                //foreach (DataRow o in resultweek)
                //{
                //    lblExpressAiringToUK_1Week_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Week_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Week_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Week_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Week_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Week_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Week_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Week_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Week_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul1month)
                //{
                //    lblExpressAiringToUK_1Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul6month)
                //{
                //    lblExpressAiringToUK_6Month_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_6Month_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_6Month_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_6Month_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_6Month_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_6Month_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_6Month_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_6Month_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_6Month_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}

                //foreach (DataRow o in resul12month)
                //{
                //    lblExpressAiringToUK_1Year_C47.Text = "&#x20B9;" + o["ExpressAiringToUK"].ToString() + "L";
                //    lblCIFAir_1Year_C47.Text = "&#x20B9;" + o["CIFAir"].ToString() + "L";
                //    lblFiftyPercentCIFAir_1Year_C47.Text = "&#x20B9;" + o["FiftyPercentCIFAir"].ToString() + "L";
                //    lblAirToMumbai_1Year_C47.Text = "&#x20B9;" + o["AirToMumbai"].ToString() + "L";
                //    lblInspectionFailandTransport_1Year_C47.Text = "&#x20B9;" + o["InspectionFailandTransport"].ToString() + "L";
                //    lblTotalPenalty_1Year_C47.Text = "&#x20B9;" + o["TotalPenalty"].ToString() + "L";
                //    lblShippedValue_1Year_C47.Text = "&#x20B9;" + o["ShippedValue"].ToString() + "L";
                //    lblPenaltyPercentAge_1Year_C47.Text = o["PenaltyPercentAge"].ToString() + "%";
                //    lblCTSL_1Year_C47.Text = o["CTSL"].ToString() + "%" + "(" + o["QK"].ToString() + "K)";
                //}
            }
            #endregion
        }
    }
}