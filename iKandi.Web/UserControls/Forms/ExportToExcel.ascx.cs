using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;
using iKandi.BLL;
using System.IO;


namespace iKandi.Web
{
    public partial class ExportToExcelControl : BaseUserControl
    {
        #region Event Handlers
        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
        PrintController objprint =new PrintController();
        public static int ClientID;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }
        
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

            ////if (!string.IsNullOrEmpty(Request.Params[ddlDepartment.UniqueID]))
            ////{
            ////    DeptID = Convert.ToInt32(Request.Params[ddlDepartment.UniqueID]);
            ////}

            //List<OrderDetail> orderDetails = this.CommonControllerInstance.GetOrdersForExportToExcel(txtsearch.Text, Convert.ToInt32(ddlClients.SelectedValue), DeptID,
            //    Convert.ToInt32(ddlSupplyType.SelectedValue), Convert.ToInt32(ddlModeType.SelectedValue), Convert.ToInt32(ddlPackingType.SelectedValue), Convert.ToInt32(ddlTermType.SelectedValue), DateHelper.ParseDate(txtFromDate.Text).Value, DateHelper.ParseDate(txtToDate.Text).Value, Convert.ToInt16(ddlDateType.SelectedValue));

            //List<OrderDetail> orderDetails = this.CommonControllerInstance.GetOrdersForExportToExcel(txtsearch.Text, Convert.ToInt32(ddlClients.SelectedValue), DeptID,
            //    Convert.ToInt32(1), Convert.ToInt32(1), Convert.ToInt32(1), Convert.ToInt32(1), DateHelper.ParseDate(txtFromDate.Text).Value, DateHelper.ParseDate(txtToDate.Text).Value, Convert.ToInt16(ddlDateType.SelectedValue));
           // (string SearchText, string year, DateTime FromDate, DateTime ToDate, int clientid, int unitid, short DateType, int StatusMode, int StatusModeSequence, int BuyingHouseId, int Ordertype)
            string sfinance = ddlfinancial.SelectedItem.Value;

            List<OrderDetail> orderDetails = this.CommonControllerInstance.GetOrdersForExportToExcel_new(txtsearch.Text, sfinance,
           DateHelper.ParseDate(txtFromDate.Text).Value, DateHelper.ParseDate(txtToDate.Text).Value, Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt16(ddlDateType.SelectedValue), Convert.ToInt16(ddlStatusMode.SelectedValue), Convert.ToInt32(ddlStatusModeSequence.SelectedValue), Convert.ToInt32(ddlBH.SelectedValue), Convert.ToInt32(ddlordertype.SelectedValue));


            StringBuilder sb = new StringBuilder();

            if (orderDetails.Count > 0)
            {
                sb.Append("<TABLE width=100% cellpadding=0 cellspacing=0 border=1>");

                sb.Append("<TR>");

                sb.Append("<TH style='background-color : #f9ddf4;'>S.NO</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>Company Name</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>ORDER DATE.</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>SERIAL NUMBER</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>SUB.DEPT (PAR.DEPT)</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>STYLE NUMBER</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>LINE ITEM NUMBER</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>CONTRACT NUMBER</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>DELIVERY MODE</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>EX-FACTORY</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>DC </TH>");
                //sb.Append("<TH style='background-color : #f9ddf4;'>DC DATE</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>QTY</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>BIPLPrice</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>BIPL_Amount</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>iKandiPrice</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>iKandi_Amount</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>Week count</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>weekly ikandi Amount</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>Delivery Type</TH>");
                sb.Append("<TH style='background-color : #f9ddf4;'>Adjustment Amount</TH>");
              

                //// edit by surendra on 14/10/2013
                //sb.Append("<TH style='background-color : #f9ddf4;'>ShippedQty</TH>");
                //// end
                //sb.Append("<TH style='background-color : #f9ddf4;'>").Append((CommonHelper.IsFOBDelivery(orderDetails[0].Mode) ? "IKANDI AGREED PRICE" : "PROPOSED PRICE")).Append("</TH>");
                //sb.Append("<TH style='background-color  :#f9ddf4;'>AMOUNT</TH>");
                //sb.Append("<TH style='background-color : #f9ddf4;'>INVOICE NO.</TH>");
                //sb.Append("<TH style='background-color : #f9ddf4;'>Invoice Date</TH>");
                //sb.Append("<TH style='background-color : #f9ddf4;'>AWB/BL Date</TH>");
                //sb.Append("<TH style='background-color : #f9ddf4;'>").Append((CommonHelper.IsFOBDelivery(orderDetails[0].Mode) ? "BIPL AGREED PRICE" : "SHIPPING PRICE")).Append("</TH>");
                //sb.Append("<TH style='background-color : #f9ddf4;'>AMOUNT</TH>");
                //sb.Append("<TH style='background-color : #f9ddf4;'>DIFF</TH>");

                sb.Append("</TR>");
                int i = 1;
                foreach (OrderDetail od in orderDetails)
                {
                    //double conversionRate = 1.0;
                    //int fromConversion = od.ParentOrder.Costing.ConvertTo;
                    //if (Enum.IsDefined(typeof(Currency), fromConversion))
                    //    conversionRate = iKandi.BLL.CommonHelper.GetCurrencyRate((Currency)fromConversion, Currency.GBP);

                    sb.Append("<TR>");

                    sb.Append("<TD>" + i + "</TD>");
                    if (od.CompanyName != "")
                    {
                        sb.Append("<TD>" + od.CompanyName + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD>" + string.Empty + "</TD>");
                    }
                    // Order Date
                    string orderDateYear = od.ParentOrder.OrderDate == DateTime.MinValue ? string.Empty : od.ParentOrder.OrderDate.ToString("yyyy");
                    string orderDateMonth = od.ParentOrder.OrderDate == DateTime.MinValue ? string.Empty : od.ParentOrder.OrderDate.ToString("MM");
                    string orderDateDay = od.ParentOrder.OrderDate == DateTime.MinValue ? string.Empty : od.ParentOrder.OrderDate.ToString("dd");
                    string orderDate = od.ParentOrder.OrderDate == DateTime.MinValue ? string.Empty : od.ParentOrder.OrderDate.ToString("MM/dd/yyyy");

                    if (od.ParentOrder.OrderDate == DateTime.MinValue)
                    {
                        sb.Append("<TD>" + string.Empty + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD>").Append("=DATE(").Append(orderDateYear).Append(",").Append(orderDateMonth).Append(",").Append(orderDateDay).Append(")</TD>");
                    }

                    // Ikandi Serial No
                    if (od.ParentOrder.SerialNumber != "")
                    {
                        sb.Append("<TD>" + od.ParentOrder.SerialNumber.ToUpper() + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");
                    

                    // Dept.
                    sb.Append("<TD>" + od.ParentOrder.Style.cdept.Name.ToUpper() + "</TD>");

                    // Style Number
                    if (od.ParentOrder.Style.StyleNumber != "")
                    {
                        sb.Append("<TD>" + od.ParentOrder.Style.StyleNumber + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");

                   

                    // Line Number

                    if (od.LineItemNumber.ToUpper() != "")
                    {
                        sb.Append("<TD>" + od.LineItemNumber.ToUpper() + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");


                    

                    // Contect Number
                    if (od.ContractNumber != "")
                    {
                        sb.Append("<TD>" + od.ContractNumber.ToUpper() + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");

                   

                    // Descrioption
                    //sb.Append("<TD>" + od.Description.ToUpper() + "</TD>");

                    // Fabric Detail
                    //string fabricDetails = string.Empty;
                    //fabricDetails = od.Fabric.ToUpper().Replace("\n", @"<br/>");
                    //sb.Append("<TD>" + fabricDetails + "</TD>");

                    // Mode
                    sb.Append("<TD>" + od.ModeName.ToUpper() + "</TD>");

                    // ExFactory
                    // string exFactory = (od.ExFactory == DateTime.MinValue) ? string.Empty : od.ExFactory.ToString("MM/dd/yyyy");
                    string exFactoryYear = (od.ExFactory == DateTime.MinValue) ? string.Empty : od.ExFactory.ToString("yyyy");
                    string exFactoryMonth = (od.ExFactory == DateTime.MinValue) ? string.Empty : od.ExFactory.ToString("MM");
                    string exFactoryDay = (od.ExFactory == DateTime.MinValue) ? string.Empty : od.ExFactory.ToString("dd");

                    if (od.ExFactory == DateTime.MinValue)
                    {
                        //sb.Append("<TD style='background-color:" + iKandi.BLL.CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode) + "'>" + String.Empty + "</TD>");
                        sb.Append("<TD>" + String.Empty + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD>").Append("=DATE(").Append(exFactoryYear).Append(",").Append(exFactoryMonth).Append(",").Append(exFactoryDay).Append(")</TD>");
                    }

                    // DC

                   


                    string dc = (od.DC == DateTime.MinValue) ? String.Empty : od.DC.ToString("MM/dd/yyyy");
                    string dcYear = (od.DC == DateTime.MinValue) ? String.Empty : od.DC.ToString("yyyy");
                    string dcMonth = (od.DC == DateTime.MinValue) ? String.Empty : od.DC.ToString("MM");
                    string dcDay = (od.DC == DateTime.MinValue) ? String.Empty : od.DC.ToString("dd");

                    if (od.DC == DateTime.MinValue)
                    {
                        sb.Append("<TD>" + string.Empty + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD>").Append("=DATE(").Append(dcYear).Append(",").Append(dcMonth).Append(",").Append(dcDay).Append(")</TD>");
                    }

                    // Quantity
                    string quantity = GetValue(Convert.ToDouble(od.Quantity), 0);

                   // sb.Append(@"<TD style='mso-number-format : \#\,\#\#0_ \;\[Red\]\-\#\,\#\#0\ ;'>").Append(quantity).Append("</TD>");

                    if (quantity != "")
                    {
                        sb.Append(@"<TD style='mso-number-format : \#\,\#\#0_ \;\[Red\]\-\#\,\#\#0\ ;'>").Append(quantity).Append("</TD>");
                       // sb.Append("<TD>" + quantity + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");



                    if (od.ParentOrder.BiplPrice != 0)
                    {
                        sb.Append("<TD>" + od.ParentOrder.BiplPrice + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");


                    



                    //string shippedquantity = GetValue(Convert.ToDouble(od.shippingQty), 0);
                    //sb.Append(@"<TD style='mso-number-format : \#\,\#\#0_ \;\[Red\]\-\#\,\#\#0\ ;'>").Append(shippedquantity).Append("</TD>");


                    // Proposed Price
                    //double price1 = CommonHelper.IsFOBDelivery(od.Mode) ? od.iKandiPrice : od.ParentOrder.BiplPrice;
                    //double proposedPrice = (price1 * conversionRate);
                    //string proposedPriceValue = GetValue(proposedPrice, 2);

                    //if (proposedPrice == 0)
                    //{
                    //    sb.Append(@"<TD >").Append(string.Empty).Append("</TD>");
                    //}
                    //else
                    //{
                    //    sb.Append(@"<TD style=' mso-number-format: \#\,\#\#0\.00_ \;\[Red\]\-\#\,\#\#0\.00\ ;'>").Append(proposedPriceValue).Append("</TD>");
                   // }

                    // Amount
                    //double amt1 = price1 * od.Quantity;
                    //string Amt1 = GetValue(amt1, 2);

                    //if (amt1 == 0)
                    //{
                    //    sb.Append(@"<TD>").Append(string.Empty).Append("</TD>");
                    //}
                    //else
                    //{
                    //    sb.Append(@"<TD style='mso-number-format : \#\,\#\#0\.00_ \;\[Red\]\-\#\,\#\#0\.00\ ;'>").Append(Amt1).Append("</TD>");
                    //}

                    // InvoiceNumber
                    //sb.Append("<TD>" + od.SecondPartnerName + "</TD>");

                    // InvoiceDate                   
                    // string invoiceDate = (od.InvoiceDate == DateTime.MinValue) ? string.Empty : od.InvoiceDate.ToString("MM/dd/yyyy");
                    //string invoiceDateYear = od.InvoiceDate == DateTime.MinValue ? string.Empty : od.InvoiceDate.ToString("yyyy");
                    //string invoiceDateMonth = od.InvoiceDate == DateTime.MinValue ? string.Empty : od.InvoiceDate.ToString("MM");
                    //string invoiceDateDay = od.InvoiceDate == DateTime.MinValue ? string.Empty : od.InvoiceDate.ToString("dd");

                    //if (od.InvoiceDate == DateTime.MinValue)
                    //{
                    //    sb.Append("<TD>" + string.Empty + "</TD>");
                    //}
                    //else
                    //{
                    //    sb.Append("<TD>").Append("=Date(").Append(invoiceDateYear).Append(",").Append(invoiceDateMonth).Append(",").Append(invoiceDateDay).Append(")").Append("</TD>");
                    //}

                    //// AWB/BL Date                  

                    //string awbBlDateYear = od.AWBDate == DateTime.MinValue ? string.Empty : od.AWBDate.ToString("yyyy");
                    //string awbBLDateMonth = od.AWBDate == DateTime.MinValue ? string.Empty : od.AWBDate.ToString("MM");
                    //string awbBLDateDay = od.AWBDate == DateTime.MinValue ? string.Empty : od.AWBDate.ToString("dd");

                    //if (od.AWBDate == DateTime.MinValue)
                    //{
                    //    sb.Append("<TD>" + string.Empty + "</TD>");
                    //}
                    //else
                    //{
                    //    sb.Append("<TD>").Append("=Date(").Append(awbBlDateYear).Append(",").Append(awbBLDateMonth).Append(",").Append(awbBLDateDay).Append(")").Append("</TD>");
                    //}


                    // Shipping Price
                    //double price2 = CommonHelper.IsFOBDelivery(od.Mode) ? (od.ParentOrder.BiplPrice) : Convert.ToDouble(od.FirstPartnerName);
                    //double price2WithRate = (price2 * conversionRate);
                    //string price2Str = GetValue(price2WithRate, 2);

                    //if (price2WithRate == 0)
                    //{
                    //    sb.Append(@"<TD>").Append(string.Empty).Append("</TD>");
                    //}
                    //else
                    //{
                    //    sb.Append(@"<TD style='mso-number-format :\#\,\#\#0\.00_ \;\[Red\]\-\#\,\#\#0\.00\ ;'>").Append(price2Str).Append("</TD>");
                    //}

                    ////Amount
                    //double amt2 = price2 * od.Quantity;
                    //string Amt2 = GetValue(amt2, 2);

                    //if (amt2 == 0)
                    //{
                    //    sb.Append(@"<TD>").Append(string.Empty).Append("</TD>");
                    //}
                    //else
                    //{
                    //    sb.Append(@"<TD style='mso-number-format: \#\,\#\#0\.00_ \;\[Red\]\-\#\,\#\#0\.00\ ;'>").Append(Amt2).Append("</TD>");
                    //}

                    //// Diff
                    //double diff = (amt1 * conversionRate - amt2 * conversionRate);
                    //string difference = GetValue(diff, 2);
                    //sb.Append(@"<TD style='mso-number-format:\#\,\#\#0\.00_ \;\[Red\]\-\#\,\#\#0\.00\ ;'>" + (difference) + "</TD>");
                    if (od.Bipl_amount == 0)
                    {
                       
                        sb.Append("<TD>" + string.Empty + "</TD>");
                    }
                    else
                    {
                        sb.Append(@"<TD style=' mso-number-format: \#\,\#\#0\.00_ \;\[Red\]\-\#\,\#\#0\.00\ ;'>").Append(od.Bipl_amount).Append("</TD>");
                       // sb.Append("<TD>" + od.Bipl_amount + "</TD>");
                    }

                    if (od.iKandiPrice != 0)
                    {
                        sb.Append("<TD>" + od.iKandiPrice + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");

                    if (od.ikandi_amount != 0)
                    {
                        sb.Append("<TD>" + od.ikandi_amount + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");

                    if (od.WeekCount != 0)
                    {
                        sb.Append("<TD>" + od.WeekCount + "</TD>");
                    }
                    else
                        sb.Append("<TD>" + string.Empty + "</TD>");

                   
                    if (od.Weeklyikandi_amount == "")
                    {
                        sb.Append("<TD>" + "string.Empty" + "</TD>");
                    }
                    else
                    {
                        string[] Deptstring = String.Format("{0:0.00}", od.Weeklyikandi_amount).ToString().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                        sb.Append("<TD>").Append(Deptstring[0]).Append(".").Append(Deptstring[1]).Append("</TD>");

                        //sb.Append("<TD>").Append("=DATE(").Append(dcYear).Append(",").Append(dcMonth).Append(",").Append(dcDay).Append(")</TD>");
                       
                    }

                    if (od.DeliveryType != "")
                    {
                        sb.Append("<TD>" + od.DeliveryType + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD>" + string.Empty + "</TD>");
                    }
                    if (od.Adjustment_Amount != "")
                    {
                        sb.Append("<TD>" + od.Adjustment_Amount + "<TD>");
                    }

                    else
                    {
                        sb.Append("<TD>" + string.Empty + "<TD>");
                    }


                    sb.Append("</TR>");
                    i += 1;
                }

                sb.Append("</TABLE>");

                try
                {
                    // Set up the Response object...
                    //this.Response.BufferOutput = false;
                    ////this.Response.Charset = string.Empty;
                    //this.EnableViewState = false;
                    //this.Response.Clear();
                    //this.Response.ClearContent();
                    //this.Response.ClearHeaders();
                    //this.Response.ContentType = "application/vnd.ms-excel";
                    //this.Response.AppendHeader("content-disposition", "attachment; filename=ExportToExcel.xls");

                    ////string s = this.DeliveryControllerInstance.GeneratePackingListExcel(-1, 2, 11);
                    ////this.Response.Write(s);
                    //this.Response.Write(sb.ToString());

                    //// Close the Response stream...
                    //this.Response.Flush();
                    //this.Response.Close();
                    ////this.Response.End();
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                    string fileName = "attachment;fileName=ExportToExcel.xls";

                    Response.ContentType = "application/vnd.ms-excel";

                    //fileName = fileName + ".xls";

                    Response.AddHeader("Content-Disposition", fileName);

                    string[] font = new string[] { "Verdana", "Arial", "Sans-Serif" };

                    Response.Charset = "";

                    this.EnableViewState = false;

                    //StringBuilder sb = new StringBuilder();
                    //// Here we can find StringBuilder calss using using System.Text name space
                    //sb.Append("Write your Text Here");

                    StringWriter strwiriter = new System.IO.StringWriter();

                    strwiriter.Write(sb.ToString());

                    HtmlTextWriter ohtmltextwriter = new HtmlTextWriter(strwiriter);

                    Repeater rt = new Repeater();

                    rt.RenderControl(ohtmltextwriter);

                    Response.Write(strwiriter.ToString());

                    Response.End();


                }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();
                }
            }

        }

        #endregion

        #region Private Methods

        private string GetValue(double Number, int NumberOfDecimailPlace)
        {
            string value = "0";

            if (NumberOfDecimailPlace == 0)
            {
                value = Number.ToString("N0");
            }
            else
            {
                value = Number.ToString("0.00");

                if (value.IndexOf(".") > -1)
                {
                    int diff = 0;
                    string suffix = value.Substring(value.IndexOf(".") + 1);
                    int suffixLength = suffix.Length;
                    diff = NumberOfDecimailPlace - suffixLength;

                    if (diff > 0)
                    {
                        for (int i = 1; i <= diff; i++)
                        {
                            value = value + "0";
                        }
                    }
                }
                else
                {
                    value = value + ".";

                    for (int i = 1; i <= NumberOfDecimailPlace; i++)
                    {
                        value = value + "0";
                    }
                }
            }

            value = value.Replace(",", string.Empty);
            return value;
        }
        private void BindBuyingHouse()
        {

            ddlBH.DataSource = objBuyingHouseController.GetBuyingHouseById(ApplicationHelper.LoggedInUser.UserData.CompanyID, Convert.ToInt32(ddlDateType.SelectedValue), "2016,2017");
            ddlBH.DataTextField = "CompanyName";
            ddlBH.DataValueField = "ID";
            ddlBH.DataBind();

        }
        private void BindSalesYear()
        {
            System.Data.DataTable  dtYear = objBuyingHouseController.GetAllSalesYearBAL();
            ddlfinancial.DataSource = dtYear;
            ddlfinancial.DataTextField = "YearRange";
            ddlfinancial.DataValueField = "Years";
            ddlfinancial.DataBind();
            string sYear = Convert.ToString(DateTime.Now.Year);
            //for (int i = 0; i < dtYear.Rows.Count; i++)
            //{
            //    string[] YearArray = dtYear.Rows[i]["Years"].ToString().Split(',');
            //    string FromYear = YearArray[0].Trim().ToString();
            //    string ToYear = YearArray[1].Trim().ToString();
            //    if (sYear == FromYear)
            //    {
            //        ddlfinancial.SelectedValue = dtYear.Rows[i]["Years"].ToString();
            //    }
            //    else if (sYear == ToYear)
            //    {
            //        ddlfinancial.SelectedValue = dtYear.Rows[i]["Years"].ToString();
            //    }

            //}
            // for temprary set 15,16 year
           // ddlfinancial.SelectedValue = "-select-";
        }
        private void BindControls()
        {

            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
               // BindSalesYear();
                BindBuyingHouse();
                DropdownHelper.BindFilteredStatusMode(ddlStatusMode, ApplicationHelper.LoggedInUser.UserData.DesignationID);
                DropdownHelper.BindFilteredStatusModeBySequence(ddlStatusModeSequence, ApplicationHelper.LoggedInUser.UserData.DesignationID, true);
                DropdownHelper.FillUnit(ddlUnit, ApplicationHelper.LoggedInUser.UserData.DesignationID, ApplicationHelper.LoggedInUser.UserData.UserID);
            }
        }

        #endregion

        protected void ddlBH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropdownHelper.BindClients(ddlClients);
            List<Client> objClient = new List<Client>();
            objClient = objprint.GetAllClientDetailsForManageOrder(Convert.ToInt32(ddlBH.SelectedValue), Convert.ToInt32(ClientID), Convert.ToInt32(ddlDateType.SelectedValue), "2016,2017", ApplicationHelper.LoggedInUser.UserData.UserID, -1);
            //objClient.ClientID = Convert.ToInt32(reader["ClientId"]);
            //objClient.CompanyName = reader["companyname"].ToString();

            ddlClients.DataSource = objClient;
            ddlClients.DataTextField = "companyname";
            ddlClients.DataValueField = "ClientId";
            ddlClients.DataBind();
        }

        protected void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientID =  Convert.ToInt32(ddlClients.SelectedValue);

        }
    }
}