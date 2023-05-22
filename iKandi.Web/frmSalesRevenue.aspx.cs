using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.Internal.Sales
{
    public partial class frmSalesRevenue : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        Double salesCurrBipl = 0;
        Double salesCurrIkandi = 0;
        Double salesCurrUnits = 0;
        Double DeliveryCurrBipl = 0;
        Double DeliveryCurrIkandi = 0;
        Double DeliveryCurrUnits = 0;

        Double salesPrevBipl = 0;
        Double salesPrevIkandi = 0;

        Double salesPrevUnits = 0;
        Double DeliveryPrevBipl = 0;
        Double DeliveryPrevIkandi = 0;
        Double DeliveryPrevUnits = 0;



        Double BiplValue_ERN_Current = 0;
        Double BiplSales_ERN_Current = 0;
        Double IkandiValue_ASO_Current = 0;
        Double IkandiSales_ASO_Current = 0;
        Double OtherValue_Other_Current = 0;
        Double OtherSales_Other_Current = 0;
        Double TotalValue_Total_Current = 0;
        Double TotalSales_Total_Current = 0;
        Double BiplValue_ERN_Prev = 0;
        Double BiplSales_ERN_Prev = 0;
        Double IkandiValue_ASO_Prev = 0;
        Double IkandiSales_ASO_Prev = 0;
        Double OtherValue_Other_Prev = 0;
        Double OtherSales_Other_Prev = 0;
        Double TotalValue_Total_Prev = 0;
        Double TotalSales_Total_Prev = 0;




        //Double salesPrevPrevBipl = 0;
        //Double salesPrevPrevIkandi = 0;
        //Double salesPrevPrevUnits = 0;
        //Double DeliveryPrevPrevBipl = 0;
        //Double DeliveryPrevPrevIkandi = 0;
        //Double DeliveryPrevPrevUnits = 0;
        Double DeliveryCurrDC = 0;
        Double DeliveryPrevDC = 0;
        //Double DeliveryPrevPrevDC = 0;
        DataTable dtGetRevenueForBarchartYear;
        protected void Page_Load(object sender, EventArgs e)
        {
            string BIPLSales_OnOrderDate = "BIPL_Sales_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            string BIPLSales_OnOrderDate_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", BIPLSales_OnOrderDate);

            string BIPLSales_OnExFactory = "BIPL_Export_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            string BIPLSales_OnExFactory_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", BIPLSales_OnExFactory);

            string IkandiSales_OnOrderDate = "Ikandi_Sales_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            string IkandiSales_OnOrderDate_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", IkandiSales_OnOrderDate);

            string IkandiSales_OnDC = "Ikandi_Delivery_ChartReport" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            string IkandiSales_OnDC_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", IkandiSales_OnDC);

            string BIPLSalesMonthly = "BIPLSalesMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            string BIPLDeliveryMonthly = "BIPLDeliveryMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";
            string IkandiDeliveryMonthly = "IkandiDeliveryMonthly" + DateTime.Now.ToString("dd-MM-yyyy") + ".png";

            string Month_OrderWise_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", BIPLSalesMonthly);
            string Month_Delivery_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", BIPLDeliveryMonthly);
            string Month_Delivery_DC_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", IkandiDeliveryMonthly);


            BIPLSalesChartReport_OnOrderDate.Src = BIPLSales_OnOrderDate_Img;
            BIPLSalesChartReport_OnExfactory.Src = BIPLSales_OnExFactory_Img;
            IkandiSalesChart_OnOrderDate.Src = IkandiSales_OnOrderDate_Img;
            IkandiSalesChart_DC.Src = IkandiSales_OnDC_Img;
            Month_OrderWise_Img_Chart.Src = Month_OrderWise_Img;
            Month_Delivery_Img_Chart.Src = Month_Delivery_Img;
            Month_Delivery_Img_Chart_DC.Src = Month_Delivery_DC_Img;
            BindRevenue_For_Barchart();
            BindRevenue_MonthWise_Delivery();
            BindRevenue_MonthWise();
           // BindRevenue_For_Barchart_Department(); commented by shubhendu on 22/02/2022
        }
        


        protected void BindRevenue_MonthWise()
        {
            DataSet dsGetMonthWise = new DataSet();
            dsGetMonthWise = objadmin.Get_RevenueMonthWise();
            DataTable dtGetGetMonthWiseCurr = dsGetMonthWise.Tables[0];
            DataTable dtGetGetMonthWisePrev = dsGetMonthWise.Tables[1];
            //DataTable dtGetRevenueForBarchartPrevPrev = dsGetRevenueForBarchart.Tables[2];
            dtGetRevenueForBarchartYear = dsGetMonthWise.Tables[2];
            int Rows = dtGetGetMonthWiseCurr.Rows.Count;
            string str = "";
            str = "<table cellspacing='0' cellpadding='0' class='bottom-table' border='1' style='width:100%;'>";
            str = str + "<tr>";
            str = str + "<th width='180' rowspan='3'>Months</th>";
            str = str + "<th colspan='8'>" + dtGetRevenueForBarchartYear.Rows[0]["FinancialYear"].ToString() + " " + "(" + "Sales" + ")" + "</th>";
            str = str + "<th colspan='8'>" + dtGetRevenueForBarchartYear.Rows[1]["FinancialYear"].ToString() + " " + "(" + "Sales" + ")" + "</th>";
            //str = str + "<th colspan='7'>" + dtGetRevenueForBarchartYear.Rows[2]["FinancialYear"].ToString() + "</th>";     
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + " <th colspan='2'> ERN </th>";
            str = str + "<th colspan='2'> ASOS</th>";
            str = str + "<th colspan='2'> Others </th>";
            str = str + "<th colspan='2'> Total</th>";
            str = str + " <th colspan='2'> ERN </th>";
            str = str + "<th colspan='2'> ASOS</th>";
            str = str + "<th colspan='2'> Others </th>";
            str = str + "<th colspan='2'> Total</th>";
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "</tr>";

            for (int i = 0; i < Rows; i++)
            {

                str = str + "<tr>";
                str = str + "<td> <b>" + dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() + "</b></td>";
                string[] BiplValue_Current = dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString().Split(' ');
                BiplValue_ERN_Current = BiplValue_ERN_Current + Convert.ToDouble(BiplValue_Current[0].ToString());

                dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"] = BiplValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString();
                if (BiplValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString() + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString() + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'> " + dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString() + "</span></td>";
                }
                string[] BiplSales_Current = dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString().Split(' ');
                BiplSales_ERN_Current = BiplSales_ERN_Current + Convert.ToDouble(BiplSales_Current[0].ToString());
                dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"] = BiplSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td> <b>" + dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</b></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</td>";

                string[] IkandiValue_Current = dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"].ToString().Split(' ');
                IkandiValue_ASO_Current = IkandiValue_ASO_Current + Convert.ToDouble(IkandiValue_Current[0].ToString().Replace("£", ""));
                dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] = IkandiValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"].ToString();
                if (IkandiValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'> " + dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] + "</span></td>";
                }
                string[] IkandiSales_Current = dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"].ToString().Split(' ');
                IkandiSales_ASO_Current = IkandiSales_ASO_Current + Convert.ToDouble(IkandiSales_Current[0].ToString());




                dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"] = IkandiSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td><b>" + dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"] + "</b></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"] + "</td>";
                string[] OtherValue_Current = dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Split(' ');
                OtherValue_Other_Current = OtherValue_Other_Current + Convert.ToDouble(OtherValue_Current[0].ToString().Replace("£", ""));

                dtGetGetMonthWiseCurr.Rows[i]["OtherValue"] = OtherValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString();
                if (OtherValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'>" + dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }

                string[] OtheSales_Current = dtGetGetMonthWiseCurr.Rows[i]["OtherSales"].ToString().Split(' ');
                OtherSales_Other_Current = OtherSales_Other_Current + Convert.ToDouble(OtheSales_Current[0].ToString());

                dtGetGetMonthWiseCurr.Rows[i]["OtherSales"] = OtheSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["OtherSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td><b>" + dtGetGetMonthWiseCurr.Rows[i]["OtherSales"] + "<b></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["OtherSales"] + "</td>";
                string[] TotalValue_Current = dtGetGetMonthWiseCurr.Rows[i]["TotalValue"].ToString().Split(' ');
                TotalValue_Total_Current = TotalValue_Total_Current + Convert.ToDouble(TotalValue_Current[0].ToString().Replace("£", ""));

                dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] = TotalValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["TotalValue"].ToString();
                if (TotalValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'>" + dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] + "</span></td>";
                }


                string[] TotalSales_Current = dtGetGetMonthWiseCurr.Rows[i]["TotalSales"].ToString().Split(' ');
                TotalSales_Total_Current = TotalSales_Total_Current + Convert.ToDouble(TotalSales_Current[0].ToString());

                dtGetGetMonthWiseCurr.Rows[i]["TotalSales"] = TotalSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["TotalSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td><b>" + dtGetGetMonthWiseCurr.Rows[i]["TotalSales"] + "</b ></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["TotalSales"] + "</td>";
                string[] BiplValue_Prev = dtGetGetMonthWisePrev.Rows[i]["BIPLValue"].ToString().Split(' ');
                BiplValue_ERN_Prev = BiplValue_ERN_Prev + Convert.ToDouble(BiplValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] = BiplValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["BIPLValue"].ToString();
                if (BiplValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] + "</span></td>";
                }
                string[] BiplSales_Prev = dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString().Split(' ');
                BiplSales_ERN_Prev = BiplSales_ERN_Prev + Convert.ToDouble(BiplSales_Prev[0].ToString());
                dtGetGetMonthWisePrev.Rows[i]["BIPLSales"] = BiplSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</span></b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</span></td>";

                string[] IkandiValue_Prev = dtGetGetMonthWisePrev.Rows[i]["IkandiValue"].ToString().Split(' ');
                IkandiValue_ASO_Prev = IkandiValue_ASO_Prev + Convert.ToDouble(IkandiValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] = IkandiValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["IkandiValue"].ToString();
                if (IkandiValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] + "</span></td>";
                }
                string[] IkandiSales_Prev = dtGetGetMonthWisePrev.Rows[i]["IkandiSales"].ToString().Split(' ');
                IkandiSales_ASO_Prev = IkandiSales_ASO_Prev + Convert.ToDouble(IkandiSales_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["IkandiSales"] = IkandiSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["IkandiSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["IkandiSales"] + "</b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["IkandiSales"] + "</td>";
                string[] OtherValue_Prev = dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Split(' ');
                OtherValue_Other_Prev = OtherValue_Other_Prev + Convert.ToDouble(OtherValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["OtherValue"] = OtherValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString();
                if (OtherValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }

                string[] OtheSales_Prev = dtGetGetMonthWisePrev.Rows[i]["OtherSales"].ToString().Split(' ');
                OtherSales_Other_Prev = OtherSales_Other_Prev + Convert.ToDouble(OtheSales_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["OtherSales"] = OtheSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["OtherSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["OtherSales"] + "</b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["OtherSales"] + "</td>";
                string[] TotalValue_Prev = dtGetGetMonthWisePrev.Rows[i]["TotalValue"].ToString().Split(' ');
                TotalValue_Total_Prev = TotalValue_Total_Prev + Convert.ToDouble(TotalValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["TotalValue"] = TotalValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["TotalValue"].ToString();
                if (TotalValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["TotalValue"] + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["TotalValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["TotalValue"] + "</span></td>";
                }

                string[] TotalSales_Prev = dtGetGetMonthWisePrev.Rows[i]["TotalSales"].ToString().Split(' ');
                TotalSales_Total_Prev = TotalSales_Total_Prev + Convert.ToDouble(TotalSales_Prev[0].ToString());
                dtGetGetMonthWisePrev.Rows[i]["TotalSales"] = TotalSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["TotalSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["TotalSales"] + "</b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["TotalSales"] + "</td>";
                str = str + "</tr>";

            }
            //str = str + "<tr>";
            //str = str + "<td><b>Total</b> </td>";
            //if (Math.Round(BiplValue_ERN_Current) > 0)
            //  str = str + "<td><b style='color:green'> &#8377; " + Math.Round(BiplValue_ERN_Current) + " Cr.</b></td>";
            //else
            //  str = str + "<td><b style='color:green'></b></td>";
            //if (Math.Round(BiplSales_ERN_Current) > 0)
            //    str = str + "<td><b>" + Math.Round(BiplSales_ERN_Current) + " L</b></td>";
            //else
            //    str = str + "<td><b></b></td>";
            //if (Math.Round(IkandiValue_ASO_Current) > 0)
            //    str = str + "<td><b style='color:green'> &#8377;" + Math.Round(IkandiValue_ASO_Current) + "  Cr.</b></td>";
            //else
            //    str = str + "<td><b style='color:green'></b></td>";
            //if (Math.Round(IkandiSales_ASO_Current) > 0)

            //    str = str + "<td><b>" + Math.Round(IkandiSales_ASO_Current) + " L</b></td>";
            //else
            //    str = str + "<td><b></b></td>";

            //if (Math.Round(OtherValue_Other_Current) > 0)
            //    str = str + "<td><b style='color:green'>&#8377;" + Math.Round(OtherValue_Other_Current) + "Cr.</b></td>";
            //else
            //    str = str + "<td><b style='color:green'></b></td>";
            //if (Math.Round(OtherSales_Other_Current) > 0)
            //    str = str + "<td><b>" + Math.Round(OtherSales_Other_Current) + " L</b></td>";
            //else
            //    str = str + "<td><b></b></td>";

            //if (Math.Round(TotalValue_Total_Current) > 0)
            //    str = str + "<td><b style='color:green'> &#8377; " + Math.Round(TotalValue_Total_Current) + " Cr.</b></td>";
            //else
            //    str = str + "<td><b style='color:green'></b></td>";

            //if (Math.Round(TotalSales_Total_Current) > 0)
            //str = str + "<td><b>" + Math.Round(TotalSales_Total_Current) + " L</b></td>";
            //else
            //    str = str + "<td><b></b></td>";

            //if (Math.Round(BiplValue_ERN_Prev) > 0)
            //str = str + "<td class='oldYear'><b style='color:green'>&#8377; " + Math.Round(BiplValue_ERN_Prev) + " Cr.</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b style='color:green'></b></td>";

            //if (Math.Round(BiplSales_ERN_Prev) > 0)
            //    str = str + "<td class='oldYear'><b>" + Math.Round(BiplSales_ERN_Prev) + " L</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b></b></td>";
            //if (Math.Round(IkandiValue_ASO_Prev) > 0)
            //str = str + "<td class='oldYear'><b style='color:green'>&#8377;" + Math.Round(IkandiValue_ASO_Prev) + " Cr.</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b style='color:green'></b></td>";

            //if (Math.Round(IkandiSales_ASO_Prev) > 0)
            //str = str + "<td class='oldYear'><b>" + Math.Round(IkandiSales_ASO_Prev) + " L</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b></b></td>";
            //if (Math.Round(OtherValue_Other_Prev) > 0)
            //    str = str + "<td class='oldYear'><b style='color:green'>&#8377;" + Math.Round(OtherValue_Other_Prev) + " Cr.</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b style='color:green'></b></td>";
            //if (Math.Round(OtherSales_Other_Prev) > 0)
            //str = str + "<td class='oldYear'><b>" + Math.Round(OtherSales_Other_Prev) + " L</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b></b></td>";
            //if (Math.Round(TotalValue_Total_Prev) > 0)
            //    str = str + "<td class='oldYear'><b style='color:green'>&#8377;" + Math.Round(TotalValue_Total_Prev) + " Cr.</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b></b></td>";
            //if (Math.Round(TotalSales_Total_Prev) > 0)
            //      str = str + "<td class='oldYear'><b>" + Math.Round(TotalSales_Total_Prev) + " L</b></td>";
            //else
            //    str = str + "<td class='oldYear'><b style='color:green'></b></td>";
            //str = str + "</tr>";

            str = str + "</table>";
            Revenue_For_Barchart_Month.InnerHtml = str;
        }
        protected void BindRevenue_MonthWise_Delivery()
        {
            DataSet dsGetMonthWise = new DataSet();
            dsGetMonthWise = objadmin.Get_RevenueMonthWise_Delivery();
            DataTable dtGetGetMonthWiseCurr = dsGetMonthWise.Tables[0];
            DataTable dtGetGetMonthWisePrev = dsGetMonthWise.Tables[1];
            //DataTable dtGetRevenueForBarchartPrevPrev = dsGetRevenueForBarchart.Tables[2];
            dtGetRevenueForBarchartYear = dsGetMonthWise.Tables[2];
            int Rows = dtGetGetMonthWiseCurr.Rows.Count;
            string str = "";
            str = "<table cellspacing='0' cellpadding='0' class='bottom-table' border='1' style='width:100%;'>";
            str = str + "<tr>";
            str = str + "<th width='180' rowspan='3'>Months</th>";
            str = str + "<th colspan='8'>" + dtGetRevenueForBarchartYear.Rows[0]["FinancialYear"].ToString() + " " + "(" + "Delivery" + ")" + "</th>";
            str = str + "<th colspan='8'>" + dtGetRevenueForBarchartYear.Rows[1]["FinancialYear"].ToString() + " " + "(" + "Delivery" + ")" + "</th>";
            //str = str + "<th colspan='7'>" + dtGetRevenueForBarchartYear.Rows[2]["FinancialYear"].ToString() + "</th>";     
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + " <th colspan='2'> ERN </th>";
            str = str + "<th colspan='2'> ASOS</th>";
            str = str + "<th colspan='2'> Others </th>";
            str = str + "<th colspan='2'> Total</th>";
            str = str + " <th colspan='2'> ERN </th>";
            str = str + "<th colspan='2'> ASOS</th>";
            str = str + "<th colspan='2'> Others </th>";
            str = str + "<th colspan='2'> Total</th>";
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th> Value</th>";
            str = str + "<th>Pcs</th>";
            str = str + "<th>Value</th>";
            str = str + "<th >Pcs</th>";
            str = str + "</tr>";

            for (int i = 0; i < Rows; i++)
            {

                str = str + "<tr>";
                str = str + "<td> <b>" + dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() + "</b></td>";
                string[] BiplValue_Current = dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString().Split(' ');
                BiplValue_ERN_Current = BiplValue_ERN_Current + Convert.ToDouble(BiplValue_Current[0].ToString());

                dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"] = BiplValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString();
                if (BiplValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString() + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString() + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'> " + dtGetGetMonthWiseCurr.Rows[i]["BIPLValue"].ToString() + "</span></td>";
                }
                string[] BiplSales_Current = dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString().Split(' ');
                BiplSales_ERN_Current = BiplSales_ERN_Current + Convert.ToDouble(BiplSales_Current[0].ToString());
                dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"] = BiplSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td> <b>" + dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</b></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</td>";

                string[] IkandiValue_Current = dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"].ToString().Split(' ');
                IkandiValue_ASO_Current = IkandiValue_ASO_Current + Convert.ToDouble(IkandiValue_Current[0].ToString().Replace("£", ""));
                dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] = IkandiValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"].ToString();
                if (IkandiValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377; " + dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'> " + dtGetGetMonthWiseCurr.Rows[i]["IkandiValue"] + "</span></td>";
                }
                string[] IkandiSales_Current = dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"].ToString().Split(' ');
                IkandiSales_ASO_Current = IkandiSales_ASO_Current + Convert.ToDouble(IkandiSales_Current[0].ToString());




                dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"] = IkandiSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td><b>" + dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"] + "</b></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["IkandiSales"] + "</td>";
                string[] OtherValue_Current = dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Split(' ');
                OtherValue_Other_Current = OtherValue_Other_Current + Convert.ToDouble(OtherValue_Current[0].ToString().Replace("£", ""));

                dtGetGetMonthWiseCurr.Rows[i]["OtherValue"] = OtherValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString();
                if (OtherValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'>" + dtGetGetMonthWiseCurr.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }

                string[] OtheSales_Current = dtGetGetMonthWiseCurr.Rows[i]["OtherSales"].ToString().Split(' ');
                OtherSales_Other_Current = OtherSales_Other_Current + Convert.ToDouble(OtheSales_Current[0].ToString());

                dtGetGetMonthWiseCurr.Rows[i]["OtherSales"] = OtheSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["OtherSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td><b>" + dtGetGetMonthWiseCurr.Rows[i]["OtherSales"] + "<b></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["OtherSales"] + "</td>";
                string[] TotalValue_Current = dtGetGetMonthWiseCurr.Rows[i]["TotalValue"].ToString().Split(' ');
                TotalValue_Total_Current = TotalValue_Total_Current + Convert.ToDouble(TotalValue_Current[0].ToString().Replace("£", ""));

                dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] = TotalValue_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["TotalValue"].ToString();
                if (TotalValue_Current[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td> <b><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] + "</span></b></td>";
                    else
                        str = str + "<td><span class='green'>&#8377;" + dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td><span class='green'>" + dtGetGetMonthWiseCurr.Rows[i]["TotalValue"] + "</span></td>";
                }


                string[] TotalSales_Current = dtGetGetMonthWiseCurr.Rows[i]["TotalSales"].ToString().Split(' ');
                TotalSales_Total_Current = TotalSales_Total_Current + Convert.ToDouble(TotalSales_Current[0].ToString());

                dtGetGetMonthWiseCurr.Rows[i]["TotalSales"] = TotalSales_Current[0].ToString() == "0.0" ? "" : dtGetGetMonthWiseCurr.Rows[i]["TotalSales"].ToString();
                if (dtGetGetMonthWiseCurr.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td><b>" + dtGetGetMonthWiseCurr.Rows[i]["TotalSales"] + "</b ></td>";
                else
                    str = str + "<td>" + dtGetGetMonthWiseCurr.Rows[i]["TotalSales"] + "</td>";
                string[] BiplValue_Prev = dtGetGetMonthWisePrev.Rows[i]["BIPLValue"].ToString().Split(' ');
                BiplValue_ERN_Prev = BiplValue_ERN_Prev + Convert.ToDouble(BiplValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] = BiplValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["BIPLValue"].ToString();
                if (BiplValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["BIPLValue"] + "</span></td>";
                }
                string[] BiplSales_Prev = dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString().Split(' ');
                BiplSales_ERN_Prev = BiplSales_ERN_Prev + Convert.ToDouble(BiplSales_Prev[0].ToString());
                dtGetGetMonthWisePrev.Rows[i]["BIPLSales"] = BiplSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</span></b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["BIPLSales"].ToString().Replace("£", "") + "</span></td>";

                string[] IkandiValue_Prev = dtGetGetMonthWisePrev.Rows[i]["IkandiValue"].ToString().Split(' ');
                IkandiValue_ASO_Prev = IkandiValue_ASO_Prev + Convert.ToDouble(IkandiValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] = IkandiValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["IkandiValue"].ToString();
                if (IkandiValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["IkandiValue"] + "</span></td>";
                }
                string[] IkandiSales_Prev = dtGetGetMonthWisePrev.Rows[i]["IkandiSales"].ToString().Split(' ');
                IkandiSales_ASO_Prev = IkandiSales_ASO_Prev + Convert.ToDouble(IkandiSales_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["IkandiSales"] = IkandiSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["IkandiSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["IkandiSales"] + "</b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["IkandiSales"] + "</td>";
                string[] OtherValue_Prev = dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Split(' ');
                OtherValue_Other_Prev = OtherValue_Other_Prev + Convert.ToDouble(OtherValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["OtherValue"] = OtherValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString();
                if (OtherValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["OtherValue"].ToString().Replace("£", "") + "</span></td>";
                }

                string[] OtheSales_Prev = dtGetGetMonthWisePrev.Rows[i]["OtherSales"].ToString().Split(' ');
                OtherSales_Other_Prev = OtherSales_Other_Prev + Convert.ToDouble(OtheSales_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["OtherSales"] = OtheSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["OtherSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["OtherSales"] + "</b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["OtherSales"] + "</td>";
                string[] TotalValue_Prev = dtGetGetMonthWisePrev.Rows[i]["TotalValue"].ToString().Split(' ');
                TotalValue_Total_Prev = TotalValue_Total_Prev + Convert.ToDouble(TotalValue_Prev[0].ToString());

                dtGetGetMonthWisePrev.Rows[i]["TotalValue"] = TotalValue_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["TotalValue"].ToString();
                if (TotalValue_Prev[0].ToString() != "0.0")
                {
                    if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                        str = str + "<td class='oldYear'><b><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["TotalValue"] + "</span></b></td>";
                    else
                        str = str + "<td class='oldYear'><span class='green'>&#8377;" + dtGetGetMonthWisePrev.Rows[i]["TotalValue"] + "</span></td>";
                }
                else
                {
                    str = str + "<td class='oldYear'><span class='green'>" + dtGetGetMonthWisePrev.Rows[i]["TotalValue"] + "</span></td>";
                }

                string[] TotalSales_Prev = dtGetGetMonthWisePrev.Rows[i]["TotalSales"].ToString().Split(' ');
                TotalSales_Total_Prev = TotalSales_Total_Prev + Convert.ToDouble(TotalSales_Prev[0].ToString());
                dtGetGetMonthWisePrev.Rows[i]["TotalSales"] = TotalSales_Prev[0].ToString() == "0.0" ? "" : dtGetGetMonthWisePrev.Rows[i]["TotalSales"].ToString();
                if (dtGetGetMonthWisePrev.Rows[i]["Month_Name"].ToString() == "Total")
                    str = str + "<td class='oldYear'><b>" + dtGetGetMonthWisePrev.Rows[i]["TotalSales"] + "</b></td>";
                else
                    str = str + "<td class='oldYear'>" + dtGetGetMonthWisePrev.Rows[i]["TotalSales"] + "</td>";
                str = str + "</tr>";

            }


            str = str + "</table>";
            Revenue_For_Barchart_Month_Delivery.InnerHtml = str;
        }
        protected void BindRevenue_For_Barchart()
        {
            DataSet dsGetRevenueForBarchart = new DataSet();
            dsGetRevenueForBarchart = objadmin.Get_RevenueForBarchart();
            DataTable dtGetRevenueForBarchartCurr = dsGetRevenueForBarchart.Tables[0];
            DataTable dtGetRevenueForBarchartPrev = dsGetRevenueForBarchart.Tables[1];
            //DataTable dtGetRevenueForBarchartPrevPrev = dsGetRevenueForBarchart.Tables[2];
            dtGetRevenueForBarchartYear = dsGetRevenueForBarchart.Tables[2];
            int Rows = dtGetRevenueForBarchartCurr.Rows.Count;
            string str = "";
            str = "<table cellspacing='0' cellpadding='0' class='bottom-table' border='1' style='width:100%;'>";
            str = str + "<tr>";
            str = str + "<th width='180' rowspan='4'>Clients</th>";
            str = str + "<th colspan='7'>" + dtGetRevenueForBarchartYear.Rows[0]["FinancialYear"].ToString() + "</th>";
            str = str + "<th colspan='7'>" + dtGetRevenueForBarchartYear.Rows[1]["FinancialYear"].ToString() + "</th>";
            //str = str + "<th colspan='7'>" + dtGetRevenueForBarchartYear.Rows[2]["FinancialYear"].ToString() + "</th>";     
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + " <th colspan='3'> Sales </th>";
            str = str + "<th colspan='4'> Delivery</th>";
            str = str + "<th colspan='3'> Sales </th>";
            str = str + "<th colspan='4'> Delivery</th>";
            //str = str + "<th colspan='3'> Sales </th>";     
            //str = str + "<th colspan='4'> Delivery</th>";     
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + "<th colspan='2'>Value</th>";
            str = str + "<th rowspan='2' style='width:60px'>Units</th>";
            str = str + "<th colspan='2'> Value</th>";
            str = str + "<th colspan='2'>Units</th>";
            str = str + "<th colspan='2'> Value</th>";
            str = str + "<th rowspan='2' style='width:60px'>Units</th>";
            str = str + "<th colspan='2'>Value</th>";
            str = str + "<th colspan='2'>Units</th>";
            //str = str + "<th colspan='2'> Value</th>";     
            //str = str + "<th rowspan='2' style='width:60px'>Units</th>";     
            //str = str + "<th colspan='2'> Value</th>";
            //str = str + "<th colspan='2'>Units</th>";     
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + "<th style='width:60px'>Bipl</th>";
            str = str + "<th style='width:60px'>Ikandi</th>";
            str = str + "<th style='width:60px'>Bipl</th>";
            str = str + "<th style='width:60px'>Ikandi</th>";

            str = str + "<th style='width:60px'>Ex.</th>";
            str = str + "<th style='width:60px'>Invoice</th>";

            str = str + "<th style='width:60px'>Bipl</th>";
            str = str + "<th style='width:60px'>Ikandi</th>";
            str = str + "<th style='width:60px'>Bipl</th>";
            str = str + "<th style='width:60px'>Ikandi</th>";
            str = str + "<th style='width:60px'>Ex.</th>";
            str = str + "<th style='width:60px'>Invoice</th>";
            //str = str + "<th style='width:60px'>Bipl</th>";
            //str = str + "<th style='width:60px'>Ikandi</th>";     
            //str = str + "<th style='width:60px'>Bipl</th>";     
            //str = str + "<th style='width:60px'>Ikandi</th>";
            //str = str + "<th style='width:60px'>Ex.</th>";
            //str = str + "<th style='width:60px'>Invoice</th>"; 
            str = str + "</tr>";
            for (int i = 0; i < Rows; i++)
            {
                if (dtGetRevenueForBarchartCurr.Rows[i]["IsRowEmpty"].ToString() != "1")
                {
                    str = str + "<tr>";
                    str = str + "<td>" + dtGetRevenueForBarchartCurr.Rows[i]["CompanyName"].ToString() + "</td>";
                    //Current Year Data
                    string[] SalesBiplCurr = dtGetRevenueForBarchartCurr.Rows[i]["BIPLSales"].ToString().Split(' ');
                    salesCurrBipl = salesCurrBipl + Convert.ToDouble(SalesBiplCurr[0].ToString());
                    if (Convert.ToDouble(SalesBiplCurr[0].ToString()) > 0)
                    {
                        str = str + "<td><span class='green'>&#8377; " + dtGetRevenueForBarchartCurr.Rows[i]["BIPLSales"].ToString() + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td>&nbsp;</td>";
                    }

                    string[] SalesIkandiCurr = dtGetRevenueForBarchartCurr.Rows[i]["IkandiSales"].ToString().Split(' ');
                    salesCurrIkandi = salesCurrIkandi + Convert.ToDouble(SalesIkandiCurr[0].ToString().Replace("£", ""));
                    if (Convert.ToDouble(SalesIkandiCurr[0].ToString().Replace("£", "")) > 0)
                    {
                        str = str + "<td><span class='green'>&#65505;" + dtGetRevenueForBarchartCurr.Rows[i]["IkandiSales"].ToString().Replace("£", "") + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td>&nbsp;</td>";
                    }


                    string[] SalesUnitsCurr = dtGetRevenueForBarchartCurr.Rows[i]["BIPLValue"].ToString().Split(' ');
                    salesCurrUnits = salesCurrUnits + Convert.ToDouble(SalesUnitsCurr[0].ToString());
                    if (Convert.ToDouble(SalesUnitsCurr[0].ToString()) > 0)
                    {
                        str = str + "<td>" + dtGetRevenueForBarchartCurr.Rows[i]["BIPLValue"] + "</td>";
                    }
                    else
                    {
                        str = str + "<td>&nbsp;</td>";
                    }

                    string[] DeliveryBiplCurr = dtGetRevenueForBarchartCurr.Rows[i]["BIPLDelivery"].ToString().Split(' ');
                    DeliveryCurrBipl = DeliveryCurrBipl + Convert.ToDouble(DeliveryBiplCurr[0].ToString());
                    if (Convert.ToDouble(DeliveryBiplCurr[0].ToString()) > 0)
                    {
                        str = str + "<td><span class='green'>&#8377; " + dtGetRevenueForBarchartCurr.Rows[i]["BIPLDelivery"] + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td>&nbsp;</td>";
                    }

                    string[] DeliveryIkandiCurr = dtGetRevenueForBarchartCurr.Rows[i]["IkandiDelivery"].ToString().Split(' ');
                    DeliveryCurrIkandi = DeliveryCurrIkandi + Convert.ToDouble(DeliveryIkandiCurr[0].ToString().Replace("£", ""));

                    if (Convert.ToDouble(DeliveryIkandiCurr[0].ToString().Replace("£", "")) > 0)
                    {
                        str = str + "<td><span class='green'>&#65505;" + dtGetRevenueForBarchartCurr.Rows[i]["IkandiDelivery"].ToString().Replace("£", "") + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td>&nbsp;</td>";
                    }
                    string[] DeliveryUnitsCurr = dtGetRevenueForBarchartCurr.Rows[i]["IkandiValue"].ToString().Split(' ');
                    DeliveryCurrUnits = DeliveryCurrUnits + Convert.ToDouble(DeliveryUnitsCurr[0].ToString());
                    if (Convert.ToDouble(DeliveryUnitsCurr[0].ToString()) > 0)
                    {
                        str = str + "<td>" + dtGetRevenueForBarchartCurr.Rows[i]["IkandiValue"] + "</td>";
                    }
                    else
                    {
                        str = str + "<td>&nbsp;</td>";
                    }

                    string[] DeliveryDCCurr = dtGetRevenueForBarchartCurr.Rows[i]["DCValue"].ToString().Split(' ');
                    DeliveryCurrDC = DeliveryCurrDC + Convert.ToDouble(DeliveryDCCurr[0].ToString());
                    if (Convert.ToDouble(DeliveryDCCurr[0].ToString()) > 0)
                    {
                        str = str + "<td>" + dtGetRevenueForBarchartCurr.Rows[i]["DCValue"] + "</td>";
                    }
                    else
                    {
                        str = str + "<td>&nbsp;</td>";
                    }

                    //Current Year Prev Year
                    string[] SalesBiplPrev = dtGetRevenueForBarchartPrev.Rows[i]["BIPLSales"].ToString().Split(' ');
                    salesPrevBipl = salesPrevBipl + Convert.ToDouble(SalesBiplPrev[0].ToString());

                    if (Convert.ToDouble(SalesBiplPrev[0].ToString()) > 0)
                    {
                        str = str + "<td class='oldYear'><span class='green'>&#8377; " + dtGetRevenueForBarchartPrev.Rows[i]["BIPLSales"] + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td class='oldYear'>&nbsp;</td>";
                    }
                    string[] SalesIkandiPrev = dtGetRevenueForBarchartPrev.Rows[i]["IkandiSales"].ToString().Split(' ');
                    salesPrevIkandi = salesPrevIkandi + Convert.ToDouble(SalesIkandiPrev[0].ToString().Replace("£", ""));
                    if (Convert.ToDouble(SalesIkandiPrev[0].ToString().Replace("£", "")) > 0)
                    {
                        str = str + "<td class='oldYear'><span class='green'>&#65505;" + dtGetRevenueForBarchartPrev.Rows[i]["IkandiSales"].ToString().Replace("£", "") + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td class='oldYear'>&nbsp;</td>";
                    }
                    string[] SalesUnitPrev = dtGetRevenueForBarchartPrev.Rows[i]["BIPLValue"].ToString().Split(' ');
                    salesPrevUnits = salesPrevUnits + Convert.ToDouble(SalesUnitPrev[0].ToString());
                    if (Convert.ToDouble(SalesUnitPrev[0].ToString()) > 0)
                    {
                        str = str + "<td class='oldYear'>" + dtGetRevenueForBarchartPrev.Rows[i]["BIPLValue"] + "</td>";
                    }
                    else
                    {
                        str = str + "<td class='oldYear'>&nbsp;</td>";
                    }
                    string[] DeliveryBiplPrev = dtGetRevenueForBarchartPrev.Rows[i]["BIPLDelivery"].ToString().Split(' ');
                    DeliveryPrevBipl = DeliveryPrevBipl + Convert.ToDouble(DeliveryBiplPrev[0].ToString());
                    if (Convert.ToDouble(DeliveryBiplPrev[0].ToString()) > 0)
                    {
                        str = str + "<td class='oldYear'><span class='green'>&#8377; " + dtGetRevenueForBarchartPrev.Rows[i]["BIPLDelivery"] + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td class='oldYear'>&nbsp;</td>";
                    }
                    string[] DeliveryIkandiPrev = dtGetRevenueForBarchartPrev.Rows[i]["IkandiDelivery"].ToString().Split(' ');
                    DeliveryPrevIkandi = DeliveryPrevIkandi + Convert.ToDouble(DeliveryIkandiPrev[0].ToString().Replace("£", ""));
                    if (Convert.ToDouble(DeliveryIkandiPrev[0].ToString().Replace("£", "")) > 0)
                    {
                        str = str + "<td class='oldYear'><span class='green'>&#65505;" + dtGetRevenueForBarchartPrev.Rows[i]["IkandiDelivery"].ToString().Replace("£", "") + "</span></td>";
                    }
                    else
                    {
                        str = str + "<td class='oldYear'>&nbsp;</td>";
                    }
                    string[] DeliveryUnitPrev = dtGetRevenueForBarchartPrev.Rows[i]["IkandiValue"].ToString().Split(' ');
                    DeliveryPrevUnits = DeliveryPrevUnits + Convert.ToDouble(DeliveryUnitPrev[0].ToString());
                    if (Convert.ToDouble(DeliveryUnitPrev[0].ToString()) > 0)
                    {
                        str = str + "<td class='oldYear'>" + dtGetRevenueForBarchartPrev.Rows[i]["IkandiValue"] + "</td>";
                    }
                    else
                    {
                        str = str + "<td class='oldYear'>&nbsp;</td>";
                    }

                    string[] DeliveryDCPrev = dtGetRevenueForBarchartPrev.Rows[i]["DCValue"].ToString().Split(' ');
                    DeliveryPrevDC = DeliveryPrevDC + Convert.ToDouble(DeliveryDCPrev[0].ToString());
                    if (Convert.ToDouble(DeliveryDCPrev[0].ToString()) > 0)
                    {
                        str = str + "<td class='oldYear'>" + dtGetRevenueForBarchartPrev.Rows[i]["DCValue"] + "</td>";
                    }
                    else
                    {
                        str = str + "<td class='oldYear'>&nbsp;</td>";
                    }

                    str = str + "</tr>";
                }
                else
                {
                    string[] SalesBiplPrev = dtGetRevenueForBarchartPrev.Rows[i]["BIPLSales"].ToString().Split(' ');
                    salesPrevBipl = salesPrevBipl + Convert.ToDouble(SalesBiplPrev[0].ToString());

                    string[] SalesIkandiPrev = dtGetRevenueForBarchartPrev.Rows[i]["IkandiSales"].ToString().Split(' ');
                    salesPrevIkandi = salesPrevIkandi + Convert.ToDouble(SalesIkandiPrev[0].ToString().Replace("£", ""));

                    string[] SalesUnitPrev = dtGetRevenueForBarchartPrev.Rows[i]["BIPLValue"].ToString().Split(' ');
                    salesPrevUnits = salesPrevUnits + Convert.ToDouble(SalesUnitPrev[0].ToString());

                    string[] DeliveryBiplPrev = dtGetRevenueForBarchartPrev.Rows[i]["BIPLDelivery"].ToString().Split(' ');
                    DeliveryPrevBipl = DeliveryPrevBipl + Convert.ToDouble(DeliveryBiplPrev[0].ToString());

                    string[] DeliveryIkandiPrev = dtGetRevenueForBarchartPrev.Rows[i]["IkandiDelivery"].ToString().Split(' ');
                    DeliveryPrevIkandi = DeliveryPrevIkandi + Convert.ToDouble(DeliveryIkandiPrev[0].ToString().Replace("£", ""));


                    string[] DeliveryUnitPrev = dtGetRevenueForBarchartPrev.Rows[i]["IkandiValue"].ToString().Split(' ');
                    DeliveryPrevUnits = DeliveryPrevUnits + Convert.ToDouble(DeliveryUnitPrev[0].ToString());

                    string[] DeliveryDCPrev = dtGetRevenueForBarchartPrev.Rows[i]["DCValue"].ToString().Split(' ');
                    DeliveryPrevDC = DeliveryPrevDC + Convert.ToDouble(DeliveryDCPrev[0].ToString());


                }
            }
            str = str + "<tr>";
            str = str + "<td><b>Total</b> </td>";
            if (Math.Round(salesCurrBipl) > 0)
                str = str + "<td><b style='color:green'> &#8377; " + Math.Round(salesCurrBipl) + " Cr.</b></td>";
            else
                str = str + "<td><b style='color:green'></b></td>";

            if (Math.Round(salesCurrIkandi) > 0)
                str = str + "<td><b style='color:green'>&#65505;" + Math.Round(salesCurrIkandi) + " M.</b></td>";
            else
                str = str + "<td><b style='color:green'></b></td>";

            if (Math.Round(salesCurrUnits) > 0)
                str = str + "<td><b>" + Math.Round(salesCurrUnits) + " L</b></td>";
            else
                str = str + "<td><b></b></td>";
            if (Math.Round(DeliveryCurrBipl) > 0)
                str = str + "<td><b style='color:green'> &#8377; " + Math.Round(DeliveryCurrBipl) + " Cr.</b></td>";
            else
                str = str + "<td><b style='color:green'></b></td>";
            if (Math.Round(DeliveryCurrIkandi) > 0)
                str = str + "<td><b style='color:green'>&#65505;" + Math.Round(DeliveryCurrIkandi) + "M.</b></td>";
            else
                str = str + "<td><b style='color:green'></b></td>";
            if (Math.Round(DeliveryCurrUnits) > 0)
                str = str + "<td><b>" + Math.Round(DeliveryCurrUnits) + " L</b></td>";
            else
                str = str + "<td><b></b></td>";
            if (Math.Round(DeliveryCurrDC) > 0)
                str = str + "<td><b>" + Math.Round(DeliveryCurrDC) + " L</b></td>";
            else
                str = str + "<td><b></b></td>";
            if (Math.Round(salesPrevBipl) > 0)
                str = str + "<td class='oldYear'><b style='color:green'>&#8377; " + Math.Round(salesPrevBipl) + " Cr.</b></td>";
            else
                str = str + "<td class='oldYear'><b style='color:green'></b></td>";
            if (Math.Round(salesPrevIkandi) > 0)
                str = str + "<td class='oldYear'><b style='color:green'>&#65505;" + Math.Round(salesPrevIkandi) + " M.</b></td>";
            else
                str = str + "<td class='oldYear'><b style='color:green'></b></td>";
            if (Math.Round(salesPrevUnits) > 0)
                str = str + "<td class='oldYear'><b>" + Math.Round(salesPrevUnits) + " L</b></td>";
            else
                str = str + "<td class='oldYear'><b></b></td>";
            if (Math.Round(DeliveryPrevBipl) > 0)
                str = str + "<td class='oldYear'><b style='color:green'> &#8377; " + Math.Round(DeliveryPrevBipl) + " Cr.</b></td>";
            else
                str = str + "<td class='oldYear'><b style='color:green'></b></td>";
            if (Math.Round(DeliveryPrevIkandi) > 0)
                str = str + "<td class='oldYear'><b style='color:green'>&#65505;" + Math.Round(DeliveryPrevIkandi) + " M.</b></td>";
            else
                str = str + "<td class='oldYear'><b style='color:green'></b></td>";
            if (Math.Round(DeliveryPrevUnits) > 0)
                str = str + "<td class='oldYear'><b>" + Math.Round(DeliveryPrevUnits) + " L</b></td>";
            else
                str = str + "<td class='oldYear'><b></b></td>";
            if (Math.Round(DeliveryPrevDC) > 0)
                str = str + "<td class='oldYear'><b>" + Math.Round(DeliveryPrevDC) + " L</b></td>";
            else
                str = str + "<td class='oldYear'><b></b></td>";
            str = str + "</tr>";

            str = str + "</table>";
            Revenue_For_Barchart.InnerHtml = str;
        }


        protected void BindRevenue_For_Barchart_Department()
        {
            DataSet dsGetRevenueForBarchart = objadmin.Get_RevenueForBarchart_Department();

            DataTable dt = dsGetRevenueForBarchart.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdGetRevenueForBarchartDepartment.DataSource = dt;
                grdGetRevenueForBarchartDepartment.DataBind();
            }
            GridViewRow lastrow = grdGetRevenueForBarchartDepartment.Rows[(grdGetRevenueForBarchartDepartment.Rows.Count) - 1];

            for (int i = 0; i < lastrow.Cells.Count; i++)
            {
                lastrow.Cells[i].Font.Bold = true;
            }
            lastrow.Cells[0].ColumnSpan = 2;
            lastrow.Cells[1].Visible = false;
        }
        protected void grdGetRevenueForBarchartDepartment_OnDataBound(object sender, EventArgs e)
        {
            for (int i = grdGetRevenueForBarchartDepartment.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdGetRevenueForBarchartDepartment.Rows[i];
                GridViewRow previousRow = grdGetRevenueForBarchartDepartment.Rows[i - 1];

                Label lblClient = (Label)row.Cells[0].FindControl("lblClient");
                Label lblPreviousClient = (Label)previousRow.Cells[1].FindControl("lblClient");

                if (lblClient.Text == lblPreviousClient.Text)
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
                }

            }

        }
        protected void grdGetRevenueForBarchartDepartment_RowdataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow4 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");
                headerRow3.Attributes.Add("class", "HeaderClass");
                headerRow4.Attributes.Add("class", "HeaderClass");
                TableCell HeaderCell = new TableCell();
                //Adding the Row at the 0th position (first row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "Clients";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 4;
                HeaderCell.Width = 100;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Department Name";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 4;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = dtGetRevenueForBarchartYear.Rows[0]["FinancialYear"].ToString();
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 7;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = dtGetRevenueForBarchartYear.Rows[1]["FinancialYear"].ToString();
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 7;
                headerRow1.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "ssdd";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 7;
                //headerRow1.Cells.Add(HeaderCell);

                //Adding the Row at the 1st position (Second row) in the Grid


                HeaderCell = new TableCell();
                HeaderCell.Text = "Sales";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Delivery";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Sales";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Delivery";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Sales";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 3;
                //headerRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Delivery";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 4;
                //headerRow2.Cells.Add(HeaderCell);

                //Adding the Row at the 3rd position (second row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "Value";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Units";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                HeaderCell.RowSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Value";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Units";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Value";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Units";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                HeaderCell.RowSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Value";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 2;
                //headerRow3.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Units";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 2;
                //headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Value";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Units";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Value";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 2;
                //headerRow3.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Units";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 2;
                //headerRow3.Cells.Add(HeaderCell);

                //Adding the Row at the 4th position (4th row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "Bipl";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ikandi";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Bipl";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ikandi";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ex.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Invoice";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Bipl";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ikandi";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Bipl";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ikandi";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Ex.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Invoice";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 70;
                headerRow4.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Bipl";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.Width = 70;
                //headerRow4.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Ikandi";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.Width = 70;
                //headerRow4.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Bipl";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.Width = 70;
                //headerRow4.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Ikandi";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.Width = 70;
                //headerRow4.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Ex.";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.Width = 70;
                //headerRow4.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Invoice";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.Width = 70;
                //headerRow4.Cells.Add(HeaderCell);


                grdGetRevenueForBarchartDepartment.Controls[0].Controls.AddAt(0, headerRow4);
                grdGetRevenueForBarchartDepartment.Controls[0].Controls.AddAt(0, headerRow3);
                grdGetRevenueForBarchartDepartment.Controls[0].Controls.AddAt(0, headerRow2);
                grdGetRevenueForBarchartDepartment.Controls[0].Controls.AddAt(0, headerRow1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBIplSalesCurr = (Label)e.Row.FindControl("lblBIplSalesCurr");
                Label lblIkandiSalesCurr = (Label)e.Row.FindControl("lblIkandiSalesCurr");
                Label lblUnitSalesCurr = (Label)e.Row.FindControl("lblUnitSalesCurr");
                Label lblBiplDeliveryCurr = (Label)e.Row.FindControl("lblBiplDeliveryCurr");
                Label lblIkandiDeliveryCurr = (Label)e.Row.FindControl("lblIkandiDeliveryCurr");
                Label lblIkandiDeliveryUnitCurr = (Label)e.Row.FindControl("lblIkandiDeliveryUnitCurr");
                Label lblIkandiDeliveryDcCurr = (Label)e.Row.FindControl("lblIkandiDeliveryDcCurr");

                Label lblBIplSalesPrev = (Label)e.Row.FindControl("lblBIplSalesPrev");
                Label lblIkandiSalesPrev = (Label)e.Row.FindControl("lblIkandiSalesPrev");
                Label lblUnitSalesPrev = (Label)e.Row.FindControl("lblUnitSalesPrev");
                Label lblBiplDeliveryPrev = (Label)e.Row.FindControl("lblBiplDeliveryPrev");
                Label lblIkandiDeliveryPrev = (Label)e.Row.FindControl("lblIkandiDeliveryPrev");
                Label lblIkandiDeliveryUnitPrev = (Label)e.Row.FindControl("lblIkandiDeliveryUnitPrev");
                Label lblIkandiDeliveryDcPrev = (Label)e.Row.FindControl("lblIkandiDeliveryDcPrev");

                //Label lblBIplSalesPrevPrev = (Label)e.Row.FindControl("lblBIplSalesPrevPrev");
                //Label lblIkandiSalesPrevPrev = (Label)e.Row.FindControl("lblIkandiSalesPrevPrev");
                //Label lblUnitSalesPrevPrev = (Label)e.Row.FindControl("lblUnitSalesPrevPrev");
                //Label lblBiplDeliveryPrevPrev = (Label)e.Row.FindControl("lblBiplDeliveryPrevPrev");
                //Label lblIkandiDeliveryPrevPrev = (Label)e.Row.FindControl("lblIkandiDeliveryPrevPrev");
                //Label lblIkandiDeliveryUnitPrevPrev = (Label)e.Row.FindControl("lblIkandiDeliveryUnitPrevPrev");
                //Label lblIkandiDeliveryDcPrevPrev = (Label)e.Row.FindControl("lblIkandiDeliveryDcPrevPrev");



                // Added by Yadvendra on 19/12/2019
                if (lblBIplSalesCurr.Text == "0.0 Cr.")
                {
                    lblBIplSalesCurr.Text = "";
                }
                else
                {
                    lblBIplSalesCurr.Text = " &#8377; " + Convert.ToDecimal(lblBIplSalesCurr.Text.Replace(" Cr.", "")).ToString("N1") + " Cr.";
                }

                if (lblIkandiSalesCurr.Text == "£0.0 M.")
                    lblIkandiSalesCurr.Text = "";
                else
                    lblIkandiSalesCurr.Text = "&#65505;" + Convert.ToDecimal(lblIkandiSalesCurr.Text.Replace("£", "").Replace(" M.", "")).ToString("N1") + " M.";

                if (lblUnitSalesCurr.Text == "0 L" || lblUnitSalesCurr.Text == "0 K")
                    lblUnitSalesCurr.Text = "";
                else
                {
                    if (lblUnitSalesCurr.Text.Contains("K"))
                        lblUnitSalesCurr.Text = Convert.ToDecimal(lblUnitSalesCurr.Text.Replace(" K", "")).ToString("N0") + " K";
                    if (lblUnitSalesCurr.Text.Contains("L"))
                        lblUnitSalesCurr.Text = Convert.ToDecimal(lblUnitSalesCurr.Text.Replace(" L", "")).ToString("N0") + " L";
                }

                if (lblBiplDeliveryCurr.Text == "0.0 Cr.")
                    lblBiplDeliveryCurr.Text = "";
                else
                    lblBiplDeliveryCurr.Text = " &#8377; " + Convert.ToDecimal(lblBiplDeliveryCurr.Text.Replace(" Cr.", "")).ToString("N1") + " Cr.";

                if (lblIkandiDeliveryCurr.Text == "£0.0 M.")
                    lblIkandiDeliveryCurr.Text = "";
                else
                    lblIkandiDeliveryCurr.Text = "&#65505;" + Convert.ToDecimal(lblIkandiDeliveryCurr.Text.Replace("£", "").Replace(" M.", "")).ToString("N1") + " M.";

                if (lblIkandiDeliveryUnitCurr.Text == "0 L" || lblIkandiDeliveryUnitCurr.Text == "0 K")
                    lblIkandiDeliveryUnitCurr.Text = "";
                else
                {
                    if (lblIkandiDeliveryUnitCurr.Text.Contains("K"))
                        lblIkandiDeliveryUnitCurr.Text = Convert.ToDecimal(lblIkandiDeliveryUnitCurr.Text.Replace(" K", "")).ToString("N0") + " K";
                    if (lblIkandiDeliveryUnitCurr.Text.Contains("L"))
                        lblIkandiDeliveryUnitCurr.Text = Convert.ToDecimal(lblIkandiDeliveryUnitCurr.Text.Replace(" L", "")).ToString("N0") + " L";
                }

                if (lblIkandiDeliveryDcCurr.Text == "0 L" || lblIkandiDeliveryDcCurr.Text == "0 K")
                    lblIkandiDeliveryDcCurr.Text = "";
                else
                {
                    if (lblIkandiDeliveryDcCurr.Text.Contains("K"))
                        lblIkandiDeliveryDcCurr.Text = Convert.ToDecimal(lblIkandiDeliveryDcCurr.Text.Replace(" K", "")).ToString("N0") + " K";
                    if (lblIkandiDeliveryDcCurr.Text.Contains("L"))
                        lblIkandiDeliveryDcCurr.Text = Convert.ToDecimal(lblIkandiDeliveryDcCurr.Text.Replace(" L", "")).ToString("N0") + " L";
                }

                if (lblBIplSalesPrev.Text == "0.0 Cr.")
                    lblBIplSalesPrev.Text = "";
                else
                    lblBIplSalesPrev.Text = " &#8377; " + Convert.ToDecimal(lblBIplSalesPrev.Text.Replace(" Cr.", "")).ToString("N1") + " Cr.";

                if (lblIkandiSalesPrev.Text == "£0.0 M.")
                    lblIkandiSalesPrev.Text = "";
                else
                    lblIkandiSalesPrev.Text = "&#65505;" + Convert.ToDecimal(lblIkandiSalesPrev.Text.Replace("£", "").Replace(" M.", "")).ToString("N1") + " M.";

                if (lblUnitSalesPrev.Text == "0 L" || lblUnitSalesPrev.Text == "0 K")
                    lblUnitSalesPrev.Text = "";
                else
                {
                    if (lblUnitSalesPrev.Text.Contains("K"))
                        lblUnitSalesPrev.Text = Convert.ToDecimal(lblUnitSalesPrev.Text.Replace(" K", "")).ToString("N0") + " K";
                    if (lblUnitSalesPrev.Text.Contains("L"))
                        lblUnitSalesPrev.Text = Convert.ToDecimal(lblUnitSalesPrev.Text.Replace(" L", "")).ToString("N0") + " L";
                }

                if (lblBiplDeliveryPrev.Text == "0.0 Cr.")
                    lblBiplDeliveryPrev.Text = "";
                else
                    lblBiplDeliveryPrev.Text = " &#8377; " + Convert.ToDecimal(lblBiplDeliveryPrev.Text.Replace(" Cr.", "")).ToString("N1") + " Cr.";

                if (lblIkandiDeliveryPrev.Text == "£0.0 M.")
                    lblIkandiDeliveryPrev.Text = "";
                else
                    lblIkandiDeliveryPrev.Text = "&#65505;" + Convert.ToDecimal(lblIkandiDeliveryPrev.Text.Replace("£", "").Replace(" M.", "")).ToString("N1") + " M.";

                if (lblIkandiDeliveryUnitPrev.Text == "0 L" || lblIkandiDeliveryUnitPrev.Text == "0 K")
                    lblIkandiDeliveryUnitPrev.Text = "";
                else
                {
                    if (lblIkandiDeliveryUnitPrev.Text.Contains("K"))
                        lblIkandiDeliveryUnitPrev.Text = Convert.ToDecimal(lblIkandiDeliveryUnitPrev.Text.Replace(" K", "")).ToString("N0") + " K";
                    if (lblIkandiDeliveryUnitPrev.Text.Contains("L"))
                        lblIkandiDeliveryUnitPrev.Text = Convert.ToDecimal(lblIkandiDeliveryUnitPrev.Text.Replace(" L", "")).ToString("N0") + " L";
                }

                if (lblIkandiDeliveryDcPrev.Text == "0 L" || lblIkandiDeliveryDcPrev.Text == "0 K")
                    lblIkandiDeliveryDcPrev.Text = "";
                else
                {
                    if (lblIkandiDeliveryDcPrev.Text.Contains("K"))
                        lblIkandiDeliveryDcPrev.Text = Convert.ToDecimal(lblIkandiDeliveryDcPrev.Text.Replace(" K", "")).ToString("N0") + " K";
                    if (lblIkandiDeliveryDcPrev.Text.Contains("L"))
                        lblIkandiDeliveryDcPrev.Text = Convert.ToDecimal(lblIkandiDeliveryDcPrev.Text.Replace(" L", "")).ToString("N0") + " L";
                }
                // End Added by Yadvendra on 19/12/2019

                //if (lblBIplSalesPrevPrev.Text == "0.0 Cr.")
                //    lblBIplSalesPrevPrev.Text = "";
                //else
                //    lblBIplSalesPrevPrev.Text = " &#8377; " + lblBIplSalesPrevPrev.Text;


                //if (lblIkandiSalesPrevPrev.Text == "£0.0 M.")
                //    lblIkandiSalesPrevPrev.Text = "";
                //else
                //    lblIkandiSalesPrevPrev.Text = "&#65505;" + lblIkandiSalesPrevPrev.Text.Replace("£", "");

                //if (lblUnitSalesPrevPrev.Text == "0 L" || lblUnitSalesPrevPrev.Text == "0 K")
                //    lblUnitSalesPrevPrev.Text = "";
                //if (lblBiplDeliveryPrevPrev.Text == "0.0 Cr.")
                //    lblBiplDeliveryPrevPrev.Text = "";
                //else
                //    lblBiplDeliveryPrevPrev.Text = " &#8377; " + lblBiplDeliveryPrevPrev.Text;

                //if (lblIkandiDeliveryPrevPrev.Text == "£0.0 M.")
                //    lblIkandiDeliveryPrevPrev.Text = "";
                //else
                //    lblIkandiDeliveryPrevPrev.Text = "&#65505;" + lblIkandiDeliveryPrevPrev.Text.Replace("£", "");

                //if (lblIkandiDeliveryUnitPrevPrev.Text == "0 L" || lblIkandiDeliveryUnitPrevPrev.Text == "0 K")
                //    lblIkandiDeliveryUnitPrevPrev.Text = "";
                //if (lblIkandiDeliveryDcPrevPrev.Text == "0 L" || lblIkandiDeliveryDcPrevPrev.Text == "0 K")
                //    lblIkandiDeliveryDcPrevPrev.Text = "";

            }
        }
    }
}