using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Drawing;
using iKandi.BLL.Production;
using System.Net.Mail;
using iKandi.Common;
using System.IO;
using iKandi.BLL;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;

namespace iKandi.Web
{
    public partial class frmCopyPieChartToserver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_C47.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_C47.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_C45.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_C45.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_BIPL.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_BIPL.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_D_169.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_D_169.png");
            }

            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_BIPL.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_BIPL.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_C45.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_C45.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_C47.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_C47.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_D_169.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_D_169.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLSalesMonthly.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLSalesMonthly.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLDeliveryMonthly.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLDeliveryMonthly.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\IkandiDeliveryMonthly.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\IkandiDeliveryMonthly.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyEff.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyEff.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyRescan.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyRescan.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCQDPASS.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCQDPASS.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyPenalty.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyPenalty.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyFinishRate.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyFinishRate.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCutRate.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCutRate.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyEff.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyEff.png");
            }
            //----------------------------Shipment reports Imgae Capture------------------------------------------
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyFinishedQty.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyFinishedQty.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyShipQty.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyShipQty.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyStitchQty.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyStitchQty.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCutQty.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCutQty.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCTSL.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCTSL.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyStitchingValue.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyStitchingValue.png");
            }


            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyAchievement.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyAchievement.png");
            }

            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCOSTTOORDERREVENUELK.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCOSTTOORDERREVENUELK.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\biplCosttoOrderSavingPer.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\biplCosttoOrderSavingPer.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLORDERTOCUTREVENUELK.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLORDERTOCUTREVENUELK.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\biplOrdertoCutSavingper.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\biplOrdertoCutSavingper.png");
            }


            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPCHARTMATERIALCOST.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPCHARTMATERIALCOST.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCHARTOHPROFITCOST.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCHARTOHPROFITCOST.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCMTCOST.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCMTCOST.png");
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLEXFACTCOST.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\BIPLEXFACTCOST.png");
            }
            //added on 1 june 2021
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\ActualPerPcpng.png")))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\ActualPerPcpng.png");
            }






            //-----------------------------End--------------------------------------------------------------------

            string BIPL_Sales_ChartReport = "";
            string BIPL_Export_ChartReport = "";
            string Ikandi_Sales_ChartReport = "";
            string Ikandi_Delivery_ChartReport = "";
            string BIPLSalesMonthly = "";
            string BIPLDeliveryMonthly = "";
            string IkandiDeliveryMonthly = "";
            string BIPL_Compliance_Audit = "";
            string BIPL_Quality_Audit = "";
            string BIPL_CQD_FaultPack = "";
            string Fabric_Average_Saving_C47 = "";
            string Fabric_Average_Saving_C45_46 = "";
            string Fabric_Average_Saving_D_169 = "";

            BIPL_Sales_ChartReport = "BIPL_Sales_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            BIPL_Export_ChartReport = "BIPL_Export_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            Ikandi_Sales_ChartReport = "Ikandi_Sales_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            Ikandi_Delivery_ChartReport = "Ikandi_Delivery_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";

            BIPLSalesMonthly = "BIPLSalesMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            BIPLDeliveryMonthly = "BIPLDeliveryMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            IkandiDeliveryMonthly = "IkandiDeliveryMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            BIPL_Compliance_Audit = "BIPLHRAuditMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            BIPL_Quality_Audit = "BIPLQualityAuditMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            BIPL_CQD_FaultPack = "BIPLCQDFaultsPackedMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            //----------------------Average saving chart.....................................................
            Fabric_Average_Saving_C47 = "Fabric_Average_Saving_C47_" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            Fabric_Average_Saving_C45_46 = "Fabric_Average_Saving_C45-46_" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            Fabric_Average_Saving_D_169 = "Fabric_Average_Saving_D-169_" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            //--------------------End saving chart-----------------------------------------------------------

            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Sales_ChartReport)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Sales_ChartReport);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Export_ChartReport)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Export_ChartReport);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + Ikandi_Sales_ChartReport)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + Ikandi_Sales_ChartReport);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + Ikandi_Delivery_ChartReport)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + Ikandi_Delivery_ChartReport);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPLSalesMonthly)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPLSalesMonthly);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPLDeliveryMonthly)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPLDeliveryMonthly);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + IkandiDeliveryMonthly)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + IkandiDeliveryMonthly);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Compliance_Audit)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Compliance_Audit);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Quality_Audit)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Quality_Audit);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_CQD_FaultPack)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_CQD_FaultPack);
            }
            //-------------------------Average saving value-----------
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_C47)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_C47);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_C45_46)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_C45_46);
            }
            if ((System.IO.File.Exists("\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_D_169)))
            {
                System.IO.File.Delete("\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_D_169);
            }
            //-------------------------end----------------------------

            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\TopFualtPieChart_C47.png", "\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_C47.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\TopFualtPieChart_C45.png", "\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_C45.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\TopFualtPieChart_BIPL.png", "\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_BIPL.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\TopFualtPieChart_D_169.png", "\\\\192.168.0.4\\UpComming_Exfactory\\TopFualtPieChart_D_169.png", true);

            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\QC_PieChart_BIPL.png", "\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_BIPL.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\QC_PieChart_C45.png", "\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_C45.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\QC_PieChart_C47.png", "\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_C47.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\QC_PieChart_D_169.png", "\\\\192.168.0.4\\UpComming_Exfactory\\QC_PieChart_D_169.png", true);

            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + BIPL_Sales_ChartReport, "\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Sales_ChartReport, true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + BIPL_Export_ChartReport, "\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Export_ChartReport, true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + Ikandi_Sales_ChartReport, "\\\\192.168.0.4\\UpComming_Exfactory\\" + Ikandi_Sales_ChartReport, true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + Ikandi_Delivery_ChartReport, "\\\\192.168.0.4\\UpComming_Exfactory\\" + Ikandi_Delivery_ChartReport, true);

            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + BIPLSalesMonthly, "\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPLSalesMonthly, true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + BIPLDeliveryMonthly, "\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPLDeliveryMonthly, true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + IkandiDeliveryMonthly, "\\\\192.168.0.4\\UpComming_Exfactory\\" + IkandiDeliveryMonthly, true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + BIPL_Compliance_Audit, "\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Compliance_Audit, true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + BIPL_Quality_Audit, "\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_Quality_Audit, true);

            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + BIPL_CQD_FaultPack, "\\\\192.168.0.4\\UpComming_Exfactory\\" + BIPL_CQD_FaultPack, true);

            //-------------------------Average saving chart----------------
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + Fabric_Average_Saving_C47, "\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_C47, true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + Fabric_Average_Saving_C45_46, "\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_C45_46, true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\" + Fabric_Average_Saving_D_169, "\\\\192.168.0.4\\UpComming_Exfactory\\" + Fabric_Average_Saving_D_169, true);

            //--------------------------end--------------------------------


            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLSalesMonthly.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLSalesMonthly.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLDeliveryMonthly.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLDeliveryMonthly.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLOHDelayMonthly.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLOHDelayMonthly.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLOPFactorMonthly.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLOPFactorMonthly.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyEff.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyEff.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyRescan.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyRescan.png", true);
            //System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\IkandiDeliveryMonthly.png", "\\\\192.168.0.4\\UpComming_Exfactory\\IkandiDeliveryMonthly.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyCQDPASS.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCQDPASS.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyPenalty.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyPenalty.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyFinishRate.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyFinishRate.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyCutRate.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCutRate.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyEff.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyEff.png", true);

            //----------------------------Shipment reports image file moved.............
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyFinishedQty.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyFinishedQty.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyShipQty.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyShipQty.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyStitchQty.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyStitchQty.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyCutQty.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCutQty.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyCTSL.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyCTSL.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyStitchingValue.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyStitchingValue.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLMonthlyAchievement.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLMonthlyAchievement.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLCOSTTOORDERREVENUELK.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCOSTTOORDERREVENUELK.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\biplCosttoOrderSavingPer.png", "\\\\192.168.0.4\\UpComming_Exfactory\\biplCosttoOrderSavingPer.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLORDERTOCUTREVENUELK.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLORDERTOCUTREVENUELK.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\biplOrdertoCutSavingper.png", "\\\\192.168.0.4\\UpComming_Exfactory\\biplOrdertoCutSavingper.png", true);

            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPCHARTMATERIALCOST.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPCHARTMATERIALCOST.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLCHARTOHPROFITCOST.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCHARTOHPROFITCOST.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLCMTCOST.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLCMTCOST.png", true);
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\BIPLEXFACTCOST.png", "\\\\192.168.0.4\\UpComming_Exfactory\\BIPLEXFACTCOST.png", true);
            // added on 1 june 2021
            System.IO.File.Copy("D:\\Abhishek_PenaltyChart\\BarchartRelease\\Uploads\\Photo\\ActualPerPcpng.png", "\\\\192.168.0.4\\UpComming_Exfactory\\ActualPerPcpng.png", true);

            //--------------------------------------------------------------------------
        }
    }
}