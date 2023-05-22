using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class InvoiceDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public InvoiceDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Public Methods




        #endregion


        public List<InvoiceOrder> GetIKandiInvoiceOrders(int PageSize, int PageIndex, out int TotalRowCount, int ClientID, DateTime FromDate, DateTime ToDate, string SearchText)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_invoice_get_ikandi_invoice_query_with_paging";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = PageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageIndex", SqlDbType.Int);
                param.Value = PageIndex;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (FromDate != DateTime.MinValue)
                {
                    param.Value = FromDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (ToDate != DateTime.MinValue)
                {
                    param.Value = ToDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                double SumOfDueAmount = 0;
                List<InvoiceOrder> orders = new List<InvoiceOrder>();

                while (reader.Read())
                {
                    InvoiceOrder ip = new InvoiceOrder();
                    ip.Invoice = new Invoice();
                    ip.ProductionPlanning = new ProductionPlanning();
                    ip.ShipmentPlanning = new ShipmentPlanning();
                    ip.PackingList = new Packing();
                    ip.DeliveryBooking = new DeliveryBooking();

                    ip.ProductionPlanning.ShipmentQty = (reader["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(reader["ShippingQty"]) : -1;
                    ip.ProductionPlanning.IsPartShipment = (reader["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(reader["IsPartShipment"]) : false;
                    ip.ProductionPlanning.ProductionPlanningID = (reader["ProductionPlanningID"] != DBNull.Value) ? -1 : Convert.ToInt32(reader["ProductionPlanningID"]);

                    ip.ShipmentPlanning.ShipmentID = -1;
                    ip.ShipmentPlanning.ShipmentNumber = (reader["ShipmentNo"] != DBNull.Value) ? Convert.ToString(reader["ShipmentNo"]) : string.Empty;
                    //ip.ShipmentPlanning.ShipmentInstructionsFile = (reader["ShipmentInstructionsFile"] != DBNull.Value) ? Convert.ToString(reader["ShipmentInstructionsFile"]) : string.Empty;

                    ip.ShipmentPlanning.ShipmentPlanningOrder = new ShipmentPlanningOrder();
                    ip.ShipmentPlanning.ShipmentPlanningOrder.UploadCustomList = (reader["UploadCustomList"] != DBNull.Value) ? Convert.ToString(reader["UploadCustomList"]) : string.Empty;
                    ip.ShipmentPlanning.ShipmentPlanningOrder.UploadDocument = (reader["UploadDocument"] != DBNull.Value) ? Convert.ToString(reader["UploadDocument"]) : string.Empty;
                    ip.DeliveryBooking.ExpectedDC = (reader["ExpectedDC"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedDC"]) : DateTime.MinValue;
                    ip.DeliveryBooking.DeliveryNoteReceivedOn = (reader["DeliveryNoteReceivedOn"] != DBNull.Value) ? Convert.ToDateTime(reader["DeliveryNoteReceivedOn"]) : DateTime.MinValue;
                    ip.DeliveryBooking.BookingReferenceNo = (reader["BookingReferenceNo"] != DBNull.Value) ? Convert.ToString(reader["BookingReferenceNo"]) : string.Empty;
                    ip.DeliveryBooking.ExpectedDC = (reader["DeliveredDate"] != DBNull.Value) ? Convert.ToDateTime(reader["DeliveredDate"]) : DateTime.MinValue;

                    ip.OrderID = (reader["OrderID"] != DBNull.Value) ? Convert.ToInt32(reader["OrderID"]) : -1;
                    ip.OrderDetailID = (reader["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(reader["OrderDetailID"]) : -1;

                    ip.ParentOrder = new Order();
                    ip.ParentOrder.OrderID = (reader["OrderID"] != DBNull.Value) ? Convert.ToInt32(reader["OrderID"]) : -1;
                    ip.ParentOrder.SerialNumber = (reader["SerialNumber"] != DBNull.Value) ? Convert.ToString(reader["SerialNumber"]) : string.Empty;
                    ip.ParentOrder.DepartmentName = (reader["DepartmentName"] != DBNull.Value) ? Convert.ToString(reader["DepartmentName"]) : string.Empty;
                    ip.ParentOrder.Style = new Style();
                    ip.ParentOrder.Style.StyleID = (reader["StyleID"] != DBNull.Value) ? Convert.ToInt32(reader["StyleID"]) : -1;
                    ip.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] != DBNull.Value) ? Convert.ToString(reader["StyleNumber"]) : string.Empty;

                    ip.ParentOrder.Client = new Client();
                    ip.ParentOrder.Client.CompanyName = (reader["Buyer"] != DBNull.Value) ? Convert.ToString(reader["Buyer"]) : string.Empty;
                    ip.ParentOrder.Client.PaymentTerms = (reader["PaymentTerms"] != DBNull.Value) ? Convert.ToInt32(reader["PaymentTerms"]) : 0;

                    ip.ContractNumber = (reader["ContractNumber"] != DBNull.Value) ? Convert.ToString(reader["ContractNumber"]) : string.Empty;
                    ip.LineItemNumber = (reader["LineItemNumber"] != DBNull.Value) ? Convert.ToString(reader["LineItemNumber"]) : string.Empty;
                    ip.ParentOrder.Description = (reader["Description"] != DBNull.Value) ? Convert.ToString(reader["Description"]) : string.Empty;
                    ip.Quantity = (reader["Quantity"] != DBNull.Value) ? Convert.ToInt32(reader["Quantity"]) : 0;
                    ip.Mode = (reader["Mode"] != DBNull.Value) ? Convert.ToInt32(reader["Mode"]) : -1;
                    ip.ModeName = (reader["Code"] != DBNull.Value) ? Convert.ToString(reader["Code"]) : string.Empty;
                    ip.Status = (reader["Status"] != DBNull.Value) ? Convert.ToString(reader["Status"]) : string.Empty;
                    ip.StatusModeID = (reader["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(reader["StatusModeID"]) : -1;
                    ip.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                    ip.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;

                    ip.Invoice.AssocaitedBiplInvoicedId = (reader["BIPLInvoicedID"] != DBNull.Value) ? (Convert.ToString(reader["BIPLInvoicedID"]) + ",") : string.Empty;
                    ip.Invoice.AssocaitedBiplInvoicedNo = (reader["BIPLInvoiceNumber"] != DBNull.Value) ? (Convert.ToString(reader["BIPLInvoiceNumber"]) + ",") : string.Empty;
                    ip.Invoice.AssocaitedBiplInvoicedQuantity = (reader["BIPLInvoiceQuantity"] != DBNull.Value) ? Convert.ToString(reader["BIPLInvoiceQuantity"]) : string.Empty;
                    ip.Invoice.AssocaitedBiplInvoicedAmount = (reader["BIPLGrandTotal"] != DBNull.Value) ? Convert.ToString(reader["BIPLGrandTotal"]) : string.Empty;
                    ip.Invoice.PackingID = (reader["PackingID"] != DBNull.Value) ? Convert.ToInt32(reader["PackingID"]) : -1;
                    ip.Invoice.IkandiInvoiceID = (reader["InvoiceId"] != DBNull.Value) ? Convert.ToInt32(reader["InvoiceId"]) : 0;
                    ip.Invoice.IkandiInvoiceGrandTotal = (reader["GrandTotal"] != DBNull.Value) ? Convert.ToDouble(reader["GrandTotal"]) : 0;
                    ip.Invoice.IkandiInvoiceQuantity = (reader["IkandiInvoiceQuantity"] != DBNull.Value) ? Convert.ToInt32(reader["IkandiInvoiceQuantity"]) : 0;
                    ip.Invoice.ParentIkandiInvoiceID = (reader["ParentInvoiceID"] != DBNull.Value) ? Convert.ToInt32(reader["ParentInvoiceID"]) : 0;
                    ip.Invoice.InvoiceNo = (reader["InvoiceNumber"] != DBNull.Value) ? Convert.ToString(reader["InvoiceNumber"]) : string.Empty;
                    ip.Invoice.IkandiInvoiceDate = (reader["InvoiceDate"] != DBNull.Value) ? Convert.ToDateTime(reader["InvoiceDate"]) : DateTime.MinValue;
                    ip.Invoice.IkandiInvoiceDetails = (reader["IkandiInvoiceDetails"] != DBNull.Value) ? Convert.ToString(reader["IkandiInvoiceDetails"]) : string.Empty;

                    if (ip.Invoice.PaymentReceivedDate == DateTime.MinValue)
                    {
                        SumOfDueAmount += ip.Invoice.GrandTotal;
                    }
                    ip.Invoice.SumOfDueAmount = SumOfDueAmount;

                    if (ip.Status.ToLower() != "invoiced")
                    {
                        ip.Status = " Un-Invoiced";
                    }

                    ip.ParentOrder.Costing = new Costing();
                    ip.ParentOrder.Costing.ConvertTo = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);

                    orders.Add(ip);
                }


                cnx.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);

                return orders;

            }
        }

        public List<InvoiceOrder> GetBIPLInvoiceOrders(int ClientID, DateTime FromDate, DateTime ToDate, string BoutiqueInvoiceSearch, string BoutiqueBillingSearch, int BuyerId, int BuyerId2)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_invoice_get_bipl_invoice_orders";
                //  cmdText = "sp_invoice_get_bipl_invoice_orders_yaten";  

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = FromDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = ToDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BoutiqueInvoiceSearch", SqlDbType.VarChar);
                param.Value = BoutiqueInvoiceSearch;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BoutiqueBillingSearch", SqlDbType.VarChar);
                param.Value = BoutiqueBillingSearch;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyerId", SqlDbType.Int);
                param.Value = BuyerId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyerId2", SqlDbType.Int);
                param.Value = BuyerId2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                List<InvoiceOrder> orders = new List<InvoiceOrder>();

                double SumOfDueAmount = 0;
                foreach (DataRow row in dsOrders.Tables[0].Rows)
                {
                    InvoiceOrder ip = new InvoiceOrder();
                    ip.IsBoutiqueBilling = false;

                    ip.ProductionPlanning = new ProductionPlanning();
                    ip.ShipmentPlanning = new ShipmentPlanning();
                    ip.PackingList = new Packing();
                    ip.DeliveryBooking = new DeliveryBooking();
                    ip.BoutiqueBilling = new BoutiqueBilling();

                    ip.ProductionPlanning.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : -1;
                    ip.ProductionPlanning.ReasonForShortShipping = (row["ReasonForShortShipping"] != DBNull.Value) ? Convert.ToString(row["ReasonForShortShipping"]) : string.Empty;

                    ip.ShipmentPlanning.ShipmentID = -1;
                    ip.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                    ip.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    ip.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;

                    ip.ParentOrder = new Order();
                    ip.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    ip.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    ip.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                    ip.ParentOrder.Style = new Style();
                    ip.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    ip.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                    ip.ParentOrder.Client = new Client();
                    ip.ParentOrder.Client.CompanyName = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                    ip.ParentOrder.BiplPrice = (row["BIPLPrice"] != DBNull.Value) ? Convert.ToDouble(row["BIPLPrice"]) : 0;

                    ip.ParentOrder.Costing = new Costing();
                    ip.ParentOrder.Costing.ConvertTo = (row["ConvertTo"] != DBNull.Value) ? Convert.ToInt32(row["ConvertTo"]) : -1;
                    ip.ParentOrder.Costing.CurrencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(ip.ParentOrder.Costing.ConvertTo);

                    ip.ParentOrder.Client.PaymentTerms = (row["PaymentTerms"] != DBNull.Value) ? Convert.ToInt32(row["PaymentTerms"]) : 0;
                    ip.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    ip.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    ip.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    ip.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;

                    ip.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    ip.Fabric1Details = (row["Fabric1Details"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                    ip.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    ip.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    ip.iKandiPrice = (row["iKandiPrice"] != DBNull.Value) ? Convert.ToDouble(row["iKandiPrice"]) : 0;

                    double BIPLPrice = ip.ParentOrder.BiplPrice;
                    double iKandiPrice = ip.iKandiPrice;

                    if (ip.ModeName.IndexOf("D") > -1)
                    {
                        ip.ParentOrder.Client.Address = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                        BIPLPrice = iKandiPrice;
                    }
                    else
                    {
                        ip.ParentOrder.Client.Address = (row["CompanyName"] != DBNull.Value) ? Convert.ToString(row["CompanyName"]) : string.Empty;
                    }

                    ip.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    ip.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : -1;
                    ip.ExFactory = (row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue;
                    ip.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;

                    ip.Invoice = new Invoice();
                    ip.Invoice.InvoiceID = (row["InvoiceId"] != DBNull.Value) ? Convert.ToInt32(row["InvoiceId"]) : -1;
                    ip.Invoice.IkandiInvoiceID = (row["ikandiinvoiceid"] != DBNull.Value) ? Convert.ToInt32(row["ikandiinvoiceid"]) : -1;
                    ip.Invoice.InvoiceNo = (row["InvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["InvoiceNumber"]) : string.Empty;
                    ip.Invoice.BIPLPInvoiceNo = (row["BIPLInvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["BIPLInvoiceNumber"]) : string.Empty;
                    ip.Invoice.InvoiceDate = (row["InvoiceDate"] != DBNull.Value) ? Convert.ToDateTime(row["InvoiceDate"]) : DateTime.MinValue;
                    ip.Invoice.Total = (row["Total"] != DBNull.Value) ? Convert.ToDouble(row["Total"]) : Convert.ToDouble(BIPLPrice * ip.Quantity);
                    ip.Invoice.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    ip.IsMultiple = "N";
                    ip.IsSingle = "N";
                    ip.IsPaid = 0;
                    ip.BillCount = 0;
                    orders.Add(ip);
                }

                foreach (DataRow row in dsOrders.Tables[1].Rows)
                {
                    InvoiceOrder ip = new InvoiceOrder();

                    ip.IsBoutiqueBilling = true;

                    ip.ProductionPlanning = new ProductionPlanning();
                    ip.ShipmentPlanning = new ShipmentPlanning();
                    ip.PackingList = new Packing();
                    ip.DeliveryBooking = new DeliveryBooking();
                    ip.BoutiqueBilling = new BoutiqueBilling();

                    ip.ProductionPlanning.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : -1;

                    ip.ProductionPlanning.ReasonForShortShipping = (row["ReasonForShortShipping"] != DBNull.Value) ? Convert.ToString(row["ReasonForShortShipping"]) : string.Empty;

                    ip.ShipmentPlanning.ShipmentID = -1;
                    ip.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                    ip.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    ip.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;

                    ip.ParentOrder = new Order();
                    ip.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    ip.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    ip.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;

                    ip.ParentOrder.Style = new Style();
                    ip.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    ip.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;

                    ip.ParentOrder.Client = new Client();
                    ip.ParentOrder.Client.CompanyName = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                    ip.ParentOrder.Client.PaymentTerms = (row["PaymentTerms"] != DBNull.Value) ? Convert.ToInt32(row["PaymentTerms"]) : 0;

                    ip.ParentOrder.Costing = new Costing();
                    ip.ParentOrder.Costing.ConvertTo = (row["ConvertTo"] != DBNull.Value) ? Convert.ToInt32(row["ConvertTo"]) : -1;
                    ip.ParentOrder.Costing.CurrencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(ip.ParentOrder.Costing.ConvertTo);

                    ip.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    ip.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    ip.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    ip.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;
                    ip.ParentOrder.BiplPrice = (row["BIPLPrice"] != DBNull.Value) ? Convert.ToDouble(row["BIPLPrice"]) : 0;
                    ip.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    ip.Fabric1Details = (row["Fabric1Details"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                    ip.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    ip.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    ip.iKandiPrice = (row["iKandiPrice"] != DBNull.Value) ? Convert.ToDouble(row["iKandiPrice"]) : 0;
                    ip.IsMultiple = (row["IsMultiple"] != DBNull.Value) ? Convert.ToString(row["IsMultiple"]) : "N";
                    ip.IsSingle = (row["IsSingle"] != DBNull.Value) ? Convert.ToString(row["IsSingle"]) : "N";
                    ip.IsPaid = (row["IsPaid"] != DBNull.Value) ? Convert.ToInt32(row["IsPaid"]) : 0;
                    ip.PaymentHistory = (row["PaymentHistory"] != DBNull.Value) ? Convert.ToString(row["PaymentHistory"]).Replace(",", "</BR>") : "";
                    ip.TotalBEAmount = (row["TotalBEAmount"] != DBNull.Value) ? Convert.ToDouble(row["TotalBEAmount"]) : 0;
                    ip.BillCount = (row["BillCount"] != DBNull.Value) ? Convert.ToInt32(row["BillCount"]) : 0;
                    double BIPLPrice = ip.ParentOrder.BiplPrice;
                    double iKandiPrice = ip.iKandiPrice;

                    if (ip.ModeName.IndexOf("D") > -1)
                    {
                        ip.ParentOrder.Client.Address = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                        BIPLPrice = iKandiPrice;
                    }

                    else
                    {
                        //  ip.ParentOrder.Client.Address = "Ikandi";
                        ip.ParentOrder.Client.Address = (row["CompanyName"] != DBNull.Value) ? Convert.ToString(row["CompanyName"]) : string.Empty;
                    }

                    ip.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    ip.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : -1;
                    ip.ExFactory = (row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue;
                    ip.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;

                    ip.Invoice = new Invoice();
                    ip.Invoice.InvoiceID = (row["InvoiceId"] != DBNull.Value) ? Convert.ToInt32(row["InvoiceId"]) : -1;
                    ip.Invoice.InvoiceNo = (row["InvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["InvoiceNumber"]) : string.Empty;
                    ip.Invoice.BIPLPInvoiceNo = (row["BIPLInvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["BIPLInvoiceNumber"]) : string.Empty;
                    ip.Invoice.InvoiceDate = (row["InvoiceDate"] != DBNull.Value) ? Convert.ToDateTime(row["InvoiceDate"]) : DateTime.MinValue;
                    ip.Invoice.Total = (row["Total"] != DBNull.Value) ? Convert.ToDouble(row["Total"]) : Convert.ToDouble(BIPLPrice * ip.Quantity);
                    ip.Invoice.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    ip.Invoice.TermsInNumber = (row["TermsInNumber"] != DBNull.Value) ? Convert.ToInt32(row["TermsInNumber"]) : 0;

                    ip.BoutiqueBilling.BoutiqueBillingID = (row["BoutiqueBillingId"] != DBNull.Value) ? Convert.ToInt32(row["BoutiqueBillingId"]) : -1;
                    ip.BoutiqueBilling.BEDate = (row["BEDate"] != DBNull.Value) ? Convert.ToDateTime(row["BEDate"]) : DateTime.MinValue;
                    ip.BoutiqueBilling.BENumber = (row["BENumber"] != DBNull.Value) ? Convert.ToString(row["BENumber"]) : string.Empty;
                    ip.BoutiqueBilling.PaymentDueDate = (row["PaymentDueDate"] != DBNull.Value) ? Convert.ToDateTime(row["PaymentDueDate"]) : DateTime.MinValue;
                    //ip.BoutiqueBilling.PaymentReceivedDate = (row["PaymentReceivedDate"] != DBNull.Value) ? Convert.ToDateTime(row["PaymentReceivedDate"]) : DateTime.MinValue;
                    ip.BoutiqueBilling.PaymentReceivedDate = DateTime.MinValue;
                    //                    ip.BoutiqueBilling.PaymentReceivedAmount = (row["PaymentReceivedAmount"] != DBNull.Value) ? Convert.ToDouble(row["PaymentReceivedAmount"]) : 0;
                    ip.BoutiqueBilling.PaymentReceivedAmount = 0;
                    ip.BoutiqueBilling.tenure = (row["tenure"] == DBNull.Value || Convert.ToInt32(row["tenure"]) == 0) ? ip.Invoice.TermsInNumber : Convert.ToInt32(row["tenure"]);
                    if (ip.BoutiqueBilling.PaymentReceivedDate == DateTime.MinValue)
                    {
                        SumOfDueAmount += ip.Invoice.Total;
                    }
                    ip.Invoice.SumOfDueAmount = SumOfDueAmount;

                    orders.Add(ip);
                }

                cnx.Close();
                return orders;
            }
        }

        public List<InvoiceOrder> GetIkandiInvoicesBIPLInvoiceOrders(int ClientID, DateTime FromDate, DateTime ToDate, int StatusModesID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_ikandi_invoices_get_ikandi_invoice_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
                // if (FromDate != DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = FromDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
                //  if (ToDate != DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = ToDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeID", SqlDbType.Int);
                param.Value = StatusModesID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<InvoiceOrder> orders = new List<InvoiceOrder>();

                while (reader.Read())
                {
                    InvoiceOrder ip = new InvoiceOrder();
                    ip.IsBoutiqueBilling = false;

                    ip.ProductionPlanning = new ProductionPlanning();
                    ip.ShipmentPlanning = new ShipmentPlanning();
                    ip.PackingList = new Packing();
                    ip.DeliveryBooking = new DeliveryBooking();
                    ip.BoutiqueBilling = new BoutiqueBilling();

                    ip.ProductionPlanning.ProductionPlanningID = (reader["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(reader["ProductionPlanningID"]) : -1;
                    ip.ProductionPlanning.ShipmentQty = (reader["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(reader["ShippingQty"]) : -1;
                    ip.ProductionPlanning.IsPartShipment = (reader["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(reader["IsPartShipment"]) : false;
                    ip.ProductionPlanning.ReasonForShortShipping = (reader["ReasonForShortShipping"] != DBNull.Value) ? Convert.ToString(reader["ReasonForShortShipping"]) : string.Empty;

                    ip.ShipmentPlanning.ShipmentID = -1;
                    ip.ShipmentPlanning.ShipmentNumber = (reader["ShipmentNo"] != DBNull.Value) ? Convert.ToString(reader["ShipmentNo"]) : string.Empty;
                    //ip.ShipmentPlanning.ShipmentInstructionsFile = (reader["ShipmentInstructionsFile"] != DBNull.Value) ? Convert.ToString(reader["ShipmentInstructionsFile"]) : string.Empty;

                    ip.ShipmentPlanning.ShipmentPlanningOrder = new ShipmentPlanningOrder();
                    ip.ShipmentPlanning.ShipmentPlanningOrder.UploadCustomList = (reader["UploadCustomList"] != DBNull.Value) ? Convert.ToString(reader["UploadCustomList"]) : string.Empty;
                    ip.ShipmentPlanning.ShipmentPlanningOrder.UploadDocument = (reader["UploadDocument"] != DBNull.Value) ? Convert.ToString(reader["UploadDocument"]) : string.Empty;

                    ip.DeliveryBooking.ExpectedDC = (reader["ExpectedDC"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedDC"]) : DateTime.MinValue;
                    ip.DeliveryBooking.DeliveryNoteReceivedOn = (reader["DeliveryNoteReceivedOn"] != DBNull.Value) ? Convert.ToDateTime(reader["DeliveryNoteReceivedOn"]) : DateTime.MinValue;
                    ip.DeliveryBooking.BookingReferenceNo = (reader["BookingReferenceNo"] != DBNull.Value) ? Convert.ToString(reader["BookingReferenceNo"]) : string.Empty;
                    ip.DeliveryBooking.DeliveredDate = (reader["DeliveredDate"] != DBNull.Value) ? Convert.ToDateTime(reader["DeliveredDate"]) : DateTime.MinValue;

                    ip.OrderID = (reader["OrderID"] != DBNull.Value) ? Convert.ToInt32(reader["OrderID"]) : -1;
                    ip.OrderDetailID = (reader["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(reader["OrderDetailID"]) : -1;
                    ip.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;

                    ip.ParentOrder = new Order();
                    ip.ParentOrder.OrderID = (reader["OrderID"] != DBNull.Value) ? Convert.ToInt32(reader["OrderID"]) : -1;
                    ip.ParentOrder.SerialNumber = (reader["SerialNumber"] != DBNull.Value) ? Convert.ToString(reader["SerialNumber"]) : string.Empty;
                    ip.ParentOrder.DepartmentName = (reader["DepartmentName"] != DBNull.Value) ? Convert.ToString(reader["DepartmentName"]) : string.Empty;

                    ip.ParentOrder.Style = new Style();
                    ip.ParentOrder.Style.StyleID = (reader["StyleID"] != DBNull.Value) ? Convert.ToInt32(reader["StyleID"]) : -1;
                    ip.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] != DBNull.Value) ? Convert.ToString(reader["StyleNumber"]) : string.Empty;

                    ip.ParentOrder.Client = new Client();
                    ip.ParentOrder.Client.CompanyName = (reader["Buyer"] != DBNull.Value) ? Convert.ToString(reader["Buyer"]) : string.Empty;
                    ip.ParentOrder.Client.ClientID = (reader["ClientId"] != DBNull.Value) ? Convert.ToInt32(reader["ClientId"]) : 0;
                    ip.ParentOrder.Client.PaymentTerms = (reader["PaymentTerms"] != DBNull.Value) ? Convert.ToInt32(reader["PaymentTerms"]) : 0;
                    ip.ContractNumber = (reader["ContractNumber"] != DBNull.Value) ? Convert.ToString(reader["ContractNumber"]) : string.Empty;
                    ip.LineItemNumber = (reader["LineItemNumber"] != DBNull.Value) ? Convert.ToString(reader["LineItemNumber"]) : string.Empty;
                    ip.ParentOrder.Description = (reader["Description"] != DBNull.Value) ? Convert.ToString(reader["Description"]) : string.Empty;
                    ip.Quantity = (reader["Quantity"] != DBNull.Value) ? Convert.ToInt32(reader["Quantity"]) : 0;

                    ip.Fabric1 = (reader["Fabric1"] != DBNull.Value) ? Convert.ToString(reader["Fabric1"]) : string.Empty;
                    ip.Fabric1Details = (reader["Fabric1Details"] != DBNull.Value) ? Convert.ToString(reader["Fabric1Details"]) : string.Empty;
                    ip.Mode = (reader["Mode"] != DBNull.Value) ? Convert.ToInt32(reader["Mode"]) : -1;
                    ip.ModeName = (reader["Code"] != DBNull.Value) ? Convert.ToString(reader["Code"]) : string.Empty;

                    if (ip.ModeName.IndexOf("D") > -1)
                    {
                        ip.ParentOrder.Client.Address = (reader["Buyer"] != DBNull.Value) ? Convert.ToString(reader["Buyer"]) : string.Empty;
                    }
                    else
                    {
                        ip.ParentOrder.Client.Address = "Ikandi";
                    }

                    ip.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                    ip.Status = (reader["Status"] != DBNull.Value) ? Convert.ToString(reader["Status"]) : string.Empty;
                    ip.StatusModeID = (reader["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(reader["StatusModeID"]) : -1;
                    ip.DELIVERED_StatusModeID = (reader["DELIVERED_StatusModeID"] != DBNull.Value) ? Convert.ToInt32(reader["DELIVERED_StatusModeID"]) : -1;
                    ip.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                    ip.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;

                    ip.Invoice = new Invoice();
                    ip.Invoice.InvoiceID = (reader["InvoiceId"] != DBNull.Value) ? Convert.ToInt32(reader["InvoiceId"]) : -1;
                    ip.Invoice.BIPLPInvoiceNo = (reader["BIPLInvoiceNumber"] != DBNull.Value) ? Convert.ToString(reader["BIPLInvoiceNumber"]) : string.Empty;
                    ip.Invoice.InvoiceDate = (reader["BiplInvoiceDate"] != DBNull.Value) ? Convert.ToDateTime(reader["BiplInvoiceDate"]) : DateTime.MinValue;
                    ip.Invoice.BIPLInvoiceDate = (reader["BiplInvoiceDate"] != DBNull.Value) ? Convert.ToDateTime(reader["BiplInvoiceDate"]) : DateTime.MinValue;
                    ip.Invoice.Total = (reader["Total"] != DBNull.Value) ? Convert.ToDouble(reader["Total"]) : 0;
                    ip.Invoice.PackingID = (reader["PackingID"] != DBNull.Value) ? Convert.ToInt32(reader["PackingID"]) : -1;
                    ip.Invoice.PaymentDueDate = (reader["PaymentDueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["PaymentDueDate"]) : DateTime.MinValue;
                    ip.Invoice.PaymentReceivedDate = (reader["PaymentReceivedDate"] != DBNull.Value) ? Convert.ToDateTime(reader["PaymentReceivedDate"]) : DateTime.MinValue;
                    ip.Invoice.PaymentReceivedAmount = (reader["PaymentReceivedAmount"] != DBNull.Value) ? Convert.ToDouble(reader["PaymentReceivedAmount"]) : 0;
                    ip.Invoice.InvoiceComments = (reader["BiplInvoiceComment"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BiplInvoiceComment"]);

                    ip.Invoice.IkandiInvoiceDates = (reader["IkandiInvoiceDate"] != DBNull.Value) ? (reader["IkandiInvoiceDate"]).ToString() : string.Empty;
                    ip.Invoice.IkandiInvoiceIds = (reader["ikandiinvoiceid"] != DBNull.Value) ? (reader["ikandiinvoiceid"]).ToString() : string.Empty;
                    //ip.Invoice.IkandiInvoiceIds = (reader["ikandiinvoiceid"] != DBNull.Value) ? System.Text.ASCIIEncoding.ASCII.GetString((byte[])(reader["ikandiinvoiceid"])).ToString() : string.Empty;
                    ip.Invoice.IkandiInvoiceNumbers = (reader["IkandiInvoicedNumber"] != DBNull.Value) ? Convert.ToString(reader["IkandiInvoicedNumber"]) : string.Empty;

                    if (ip.Status.ToLower() != "invoiced")
                    {
                        ip.Status = ip.Status.ToUpper() + "<br/>" + " Un-Invoiced";
                    }

                    ip.ParentOrder.Costing = new Costing();
                    ip.ParentOrder.Costing.ConvertTo = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);

                    orders.Add(ip);
                }

                return orders;

            }
        }

        public void SaveBoutiqueBilling(BoutiqueBilling BB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_boutique_billing_save";

                SqlTransaction transaction = cnx.BeginTransaction();

                try
                {

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, transaction, QueryType.Insert);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outparam;
                    outparam = new SqlParameter("@NewID", SqlDbType.Int);
                    outparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outparam);

                    SqlParameter param;

                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = BB.BoutiqueBillingID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BENumber", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = BB.BENumber == null ? "" : BB.BENumber;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BEDate", SqlDbType.DateTime);
                    // if (BB.BEDate == DateTime.MinValue)
                    if ((BB.BEDate == DateTime.MinValue) || (BB.BEDate == Convert.ToDateTime("1753-01-01")) || (BB.BEDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = BB.BEDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PaymentDueDate", SqlDbType.DateTime);
                    // if (BB.PaymentDueDate == DateTime.MinValue)
                    if ((BB.PaymentDueDate == DateTime.MinValue) || (BB.PaymentDueDate == Convert.ToDateTime("1753-01-01")) || (BB.PaymentDueDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = BB.PaymentDueDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PaymentReceivedDate", SqlDbType.DateTime);
                    //  if (BB.PaymentReceivedDate == DateTime.MinValue)
                    if ((BB.PaymentReceivedDate == DateTime.MinValue) || (BB.PaymentReceivedDate == Convert.ToDateTime("1753-01-01")) || (BB.PaymentReceivedDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = BB.PaymentReceivedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PaymentReceivedAmount", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    param.Value = BB.PaymentReceivedAmount;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Tenure", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = BB.tenure;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = BB.InvoiceId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sSingle", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = BB.IsSingle == null ? "" : BB.IsSingle;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sMultiple", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = BB.IsMultiple == null ? "" : BB.IsMultiple;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    int BoutiqueID = BB.BoutiqueBillingID == -1 ? Convert.ToInt32(outparam.Value) : BB.BoutiqueBillingID;

                    if (BB.BillingOrders != null && BB.BillingOrders.Count > 0)
                    {
                        foreach (BoutiqueBillingOrder order in BB.BillingOrders)
                        {
                            if (order.BoutiqueBilling == null)
                                order.BoutiqueBilling = new BoutiqueBilling();

                            order.BoutiqueBilling.BoutiqueBillingID = BoutiqueID;

                            if (order.IsDelete)
                                DeleteBoutiqueBillingOrder(order.BoutiqueBillingOrderID, cnx, transaction);
                            else
                                SaveBoutiqueBillingOrder(order, cnx, transaction);
                        }
                    }

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

                cnx.Close();
            }
        }

        public void DeleteBoutiqueBilling(int BoutiqueBillingID, int InvoiceID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_boutique_billing_delete_boutique_billing";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@BoutiqueBillingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BoutiqueBillingID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nvoiceID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceID;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }



        public void SetInvoiceEntrySingle(int BoutiqueBillingID, string IsChecked)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_set_invoice_single";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@BoutiqueBillingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BoutiqueBillingID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sChecked", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = IsChecked;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }


        private void SaveBoutiqueBillingOrder(BoutiqueBillingOrder order, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_boutique_billing_order_save";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;
            cmd.Connection = cnx;

            SqlParameter param;
            param = new SqlParameter("@D", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = order.BoutiqueBillingOrderID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@nvoiceID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = order.InvoiceID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BoutiqueBillingId", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = order.BoutiqueBilling.BoutiqueBillingID;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }

        private void DeleteBoutiqueBillingOrder(int BoutiqueBillingOrderID, SqlConnection cnx, SqlTransaction transaction)
        {


            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "boutique_billing_order";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;
            cmd.Connection = cnx;

            SqlParameter param;
            param = new SqlParameter("@D", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = BoutiqueBillingOrderID;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }

        public void UpdateInvoicePayment(Invoice InvoiceData)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_invoice_update_payment";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@nvoiceID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceData.InvoiceID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentDueDate", SqlDbType.DateTime);
                param.Value = InvoiceData.PaymentDueDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentReceivedDate", SqlDbType.DateTime);
                if (InvoiceData.PaymentReceivedDate == null || InvoiceData.PaymentReceivedDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = InvoiceData.PaymentReceivedDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentReceivedAmount", SqlDbType.Float);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceData.PaymentReceivedAmount;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetInvoiceOrders(int InvoiceID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_invoice_get_order_detail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@nvoiceID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceID;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                cnx.Close();

                return dsOrders.Tables[0];


            }

        }


        public DataTable GetBiplInvoiceOrders(int BoutiqueBillingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_invoice_get_order_detail_id_by_boutique_billing_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@BoutiqueBillingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BoutiqueBillingId;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                cnx.Close();

                return dsOrders.Tables[0];


            }

        }

        public Packing GetPackingCollection(int orderId, int packingId, int productionUnitManagerId)
        {
            Packing objPacking = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_packing_get_packing_list";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = orderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PackingId", SqlDbType.Int);
                param.Value = packingId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionUnitManagerId", SqlDbType.Int);
                param.Value = productionUnitManagerId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPacking = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPacking);

                objPacking = ConvertDataSetToPackingCollection(dsPacking);
                objPacking.OrderID = orderId;
                objPacking.PackingID = packingId;
            }

            return objPacking;

        }

        private Packing ConvertDataSetToPackingCollection(DataSet dsPacking)
        {
            Packing objPacking = new Packing();
            string modename = string.Empty;
            iKandi.DAL.ConfigurationDataProvider config = new iKandi.DAL.ConfigurationDataProvider(LoggedInUser);

            if (dsPacking.Tables.Count == 2)
            {
                objPacking.Distributions = new List<PackingDistribution>();

                foreach (DataRow drPacking in dsPacking.Tables[0].Rows)
                {
                    PackingDistribution objPackingDistribution = new PackingDistribution();
                    objPackingDistribution.ProductionPlanningID = (drPacking["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["ProductionPlanningID"]);
                    objPackingDistribution.OrderDetailID = (drPacking["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["OrderDetailId"]);
                    objPackingDistribution.LineItemNumber = (drPacking["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["LineItemNumber"]);
                    objPackingDistribution.ContractNumber = (drPacking["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["ContractNumber"]);
                    objPackingDistribution.StyleNumber = (drPacking["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["StyleNumber"]);
                    objPackingDistribution.FabricColor = (drPacking["FabricColor"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FabricColor"]);
                    objPackingDistribution.Item = (drPacking["Item"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Item"]);
                    objPackingDistribution.Fabric = (drPacking["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Fabric"]);
                    objPackingDistribution.Quantity = (drPacking["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["Quantity"]);
                    objPackingDistribution.ShippingQuantity = (drPacking["ShippingQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["ShippingQuantity"]);
                    objPackingDistribution.Mode = (drPacking["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["Mode"]);
                    string BillingAddess = (drPacking["BillingAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["BillingAddress"]);
                    string OfficialName = (drPacking["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["OfficialName"]);
                    modename = (drPacking["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Code"]);

                    if (modename.IndexOf("D") > -1)
                    {
                        objPacking.Consignee = OfficialName + Environment.NewLine + BillingAddess;

                    }
                    else
                    {
                        objPacking.Consignee = config.GetKeyValue(Constants.IKANDI_ADDRESS);
                    }
                    //For showing proportional data for part shipment
                    double quantityRatio = (double)objPackingDistribution.ShippingQuantity / (double)objPackingDistribution.Quantity;

                    objPackingDistribution.PackingSizes = new List<OrderDetailSizes>();

                    foreach (DataRow drSizes in dsPacking.Tables[1].Rows)
                    {
                        if (objPackingDistribution.OrderDetailID == (drSizes["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(drSizes["OrderDetailId"])))
                        {
                            OrderDetailSizes objOrderDetailSizes = new OrderDetailSizes();
                            objOrderDetailSizes.OrderDetailID = (drSizes["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailId"]);
                            objOrderDetailSizes.OrderDetailSizeID = (drSizes["OrderDetailSizeId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailSizeId"]);
                            objOrderDetailSizes.Size = (drSizes["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(drSizes["Size"]);
                            objOrderDetailSizes.Quantity = (drSizes["Quantity"] == DBNull.Value) ? 0 : (int)Math.Round(quantityRatio * Convert.ToInt32(drSizes["Quantity"]));
                            objOrderDetailSizes.Singles = (drSizes["Singles"] == DBNull.Value) ? 0 : (int)Math.Round(quantityRatio * Convert.ToInt32(drSizes["Singles"]));
                            objOrderDetailSizes.Ratio = (drSizes["Ratio"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Ratio"]);
                            objOrderDetailSizes.RatioPack = (drSizes["RatioPack"] == DBNull.Value) ? 0 : (int)(quantityRatio * Convert.ToInt32(drSizes["RatioPack"]));

                            objPackingDistribution.PackingSizes.Add(objOrderDetailSizes);
                        }
                    }



                    objPacking.Distributions.Add(objPackingDistribution);
                }
            }
            else if (dsPacking.Tables.Count == 4)
            {
                if (dsPacking.Tables[0].Rows.Count == 1)
                {
                    DataRow drPacking = dsPacking.Tables[0].Rows[0];

                    //objPacking.BuyerOrderNumber = (drPacking["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["ContractNumber"]);
                    //objPacking.BuyerOrderDate = (drPacking["BuyerOrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(drPacking["BuyerOrderDate"]);
                    //objPacking.BuyerOtherThanConsignee = (drPacking["BuyerOtherThanConsignee"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["BuyerOtherThanConsignee"]);
                    //objPacking.Consignee = (drPacking["Consignee"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Consignee"]);
                    //objPacking.CountryOfFinalDestination = (drPacking["CountryOfFinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["CountryOfFinalDestination"]);
                    //objPacking.CountryOfOriginOfGoods = (drPacking["CountryOfOriginOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["CountryOfOriginOfGoods"]);
                    //objPacking.DescriptionOfGoods = (drPacking["DescriptionOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["DescriptionOfGoods"]);
                    //objPacking.Exporter = (drPacking["Exporter"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Exporter"]);
                    //objPacking.FinalDestination = (drPacking["FinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FinalDestination"]);
                    //objPacking.FlightNumber = (drPacking["FlightNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FlightNumber"]);
                    //objPacking.InvoiceDate = (drPacking["InvoiceDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(drPacking["InvoiceDate"]);
                    //objPacking.InvoiceNumber = (drPacking["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["InvoiceNumber"]);
                    //objPacking.MarksAndContainerNumber = (drPacking["MarksAndContainerNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["MarksAndContainerNumber"]);
                    //objPacking.NumberAndKindOfPackages = (drPacking["NumberAndKindOfPackages"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["NumberAndKindOfPackages"]);
                    //objPacking.OtherReferences = (drPacking["OtherReferences"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["OtherReferences"]);
                    //objPacking.PackageNumbers = (drPacking["PackageNumbers"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PackageNumbers"]);
                    //objPacking.PackingID = (drPacking["id"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["id"]);
                    //objPacking.PlaceOfReceiptByPreCarrier = (drPacking["PlaceOfReceiptByPreCarrier"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PlaceOfReceiptByPreCarrier"]);
                    //objPacking.PortOfDischarge = (drPacking["PortOfDischarge"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PortOfDischarge"]);
                    //objPacking.PortOfLoading = (drPacking["PortOfLoading"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PortOfLoading"]);
                    //objPacking.PreCarriageBy = (drPacking["PreCarriageBy"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PreCarriageBy"]);
                    //objPacking.Remarks = (drPacking["Remarks"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Remarks"]);
                    //objPacking.TermsOfDeliveryAndPayment = (drPacking["TermsOfDeliveryAndPayment"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["TermsOfDeliveryAndPayment"]);
                    //objPacking.TotalGrossWeight = (drPacking["TotalGrossWeight"] == DBNull.Value) ? 0 : Convert.ToDouble(drPacking["TotalGrossWeight"]);
                    //objPacking.TotalNetWeight = (drPacking["TotalNetWeight"] == DBNull.Value) ? 0 : Convert.ToDouble(drPacking["TotalNetWeight"]);
                    //objPacking.TotalPackages = (drPacking["TotalPackages"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["TotalPackages"]);

                    objPacking.BuyerOrderNumber = (drPacking["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["ContractNumber"]);
                    objPacking.SerialNumber = (drPacking["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["SerialNumber"]);
                    objPacking.BuyerOrderDate = (drPacking["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(drPacking["OrderDate"]);
                    objPacking.BuyerOtherThanConsignee = (drPacking["BuyerOtherThanConsignee"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["BuyerOtherThanConsignee"]);

                    modename = (drPacking["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Code"]);
                    string BillingAddess = (drPacking["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["BillingAddess"]);
                    string OfficialName = (drPacking["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["OfficialName"]);
                    if (modename.IndexOf("D") > -1)
                    {
                        objPacking.Consignee = (drPacking["Consignee"] == DBNull.Value) ? OfficialName + Environment.NewLine + BillingAddess : Convert.ToString(drPacking["Consignee"]);

                    }
                    else
                    {
                        objPacking.Consignee = config.GetKeyValue(Constants.IKANDI_ADDRESS);
                    }

                    if (modename.IndexOf("D") > -1)
                    {

                        objPacking.CountryOfFinalDestination = (drPacking["CountryOfFinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["CountryOfFinalDestination"]);
                        objPacking.FinalDestination = (drPacking["FinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FinalDestination"]);
                    }
                    else
                    {

                        objPacking.CountryOfFinalDestination = "U.K.";
                        objPacking.FinalDestination = "U.K.";
                    }
                    objPacking.FlightNumber = (drPacking["FlightNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FlightNumber"]);
                    objPacking.InvoiceDate = (drPacking["InvoiceDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(drPacking["InvoiceDate"]);
                    objPacking.InvoiceNumber = (drPacking["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["InvoiceNumber"]);

                    int TotalPackages = (drPacking["TotalPackages"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["TotalPackages"]);
                    string PackageNumbers = (drPacking["PackageNumbers"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PackageNumbers"]);
                    string MarkAndNo = "";
                    if (TotalPackages > 0)
                    {
                        MarkAndNo = TotalPackages.ToString() + " PKGS NOS. " + PackageNumbers.ToString().Replace("-", " TO ");
                    }
                    objPacking.MarksAndContainerNumber = (drPacking["MarksAndContainerNumber"] == DBNull.Value || drPacking["MarksAndContainerNumber"].ToString() == string.Empty) ? MarkAndNo : Convert.ToString(drPacking["MarksAndContainerNumber"]);
                    objPacking.PlaceOfReceiptByPreCarrier = (drPacking["PlaceOfReceiptByPreCarrier"] == DBNull.Value || drPacking["PlaceOfReceiptByPreCarrier"].ToString() == string.Empty) ? "NEW DELHI" : Convert.ToString(drPacking["PlaceOfReceiptByPreCarrier"]);

                    objPacking.DescriptionOfGoods = (drPacking["DescriptionOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["DescriptionOfGoods"]);




                    objPacking.OtherReferences = (drPacking["OtherReferences"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["OtherReferences"]);

                    objPacking.CountryOfOriginOfGoods = (drPacking["CountryOfOriginOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["CountryOfOriginOfGoods"]);

                    objPacking.PackingID = (drPacking["PackingID"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["PackingID"]);
                    if (modename.IndexOf("A/") > -1)
                    {
                        objPacking.PortOfLoading = (drPacking["PortOfLoading"] == DBNull.Value || drPacking["PortOfLoading"].ToString() == "") ? "NEW DELHI" : Convert.ToString(drPacking["PortOfLoading"]);
                        objPacking.PreCarriageBy = (drPacking["PreCarriageBy"] == DBNull.Value || drPacking["PreCarriageBy"].ToString() == "") ? "BY AIR" : Convert.ToString(drPacking["PreCarriageBy"]);
                        objPacking.PortOfDischarge = (drPacking["PortOfDischarge"] == DBNull.Value || drPacking["PortOfDischarge"].ToString() == "") ? "London" : Convert.ToString(drPacking["PortOfDischarge"]);
                    }
                    else if (modename.IndexOf("S/") > -1)
                    {
                        objPacking.PortOfLoading = (drPacking["PortOfLoading"] == DBNull.Value || drPacking["PortOfLoading"].ToString() == "") ? "MUMBAI" : Convert.ToString(drPacking["PortOfLoading"]);
                        objPacking.PreCarriageBy = (drPacking["PreCarriageBy"] == DBNull.Value || drPacking["PreCarriageBy"].ToString() == "") ? "BY SEA" : Convert.ToString(drPacking["PreCarriageBy"]);
                        objPacking.PortOfDischarge = (drPacking["PortOfDischarge"] == DBNull.Value || drPacking["PortOfDischarge"].ToString() == "") ? "FELIXSTOWE" : Convert.ToString(drPacking["PortOfDischarge"]);
                    }
                    int Shippingquantity = (drPacking["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["ShippingQty"]);
                    objPacking.Quantity = (drPacking["Quantity"] == DBNull.Value || drPacking["Quantity"].ToString() == "") ? Shippingquantity : Convert.ToInt32(drPacking["Quantity"]);

                    objPacking.TermsOfDeliveryAndPayment = (drPacking["TermsOfDeliveryAndPayment"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["TermsOfDeliveryAndPayment"]);

                    objPacking.TotalGrossWeight = (drPacking["TotalGrossWeight"] == DBNull.Value) ? 0 : Convert.ToDouble(drPacking["TotalGrossWeight"]);
                    objPacking.TotalNetWeight = (drPacking["TotalNetWeight"] == DBNull.Value) ? 0 : Convert.ToDouble(drPacking["TotalNetWeight"]);
                    objPacking.TotalPackages = (drPacking["TotalPackages"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["TotalPackages"]);
                    objPacking.Exporter = (drPacking["Exporter"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Exporter"]);


                    objPacking.Distributions = new List<PackingDistribution>();

                    foreach (DataRow drPackingDistribution in dsPacking.Tables[1].Rows)
                    {
                        PackingDistribution objPackingDistribution = new PackingDistribution();

                        objPackingDistribution.ContractNumber = (drPackingDistribution["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["ContractNumber"]);
                        objPackingDistribution.ProductionPlanningID = (drPackingDistribution["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["ProductionPlanningID"]);
                        objPackingDistribution.OrderDetailID = (drPackingDistribution["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["OrderDetailId"]);
                        objPackingDistribution.LineItemNumber = (drPackingDistribution["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["LineItemNumber"]);
                        objPackingDistribution.StyleNumber = (drPackingDistribution["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["StyleNumber"]);
                        objPackingDistribution.FabricColor = (drPackingDistribution["FabricColor"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["FabricColor"]);
                        objPackingDistribution.Item = (drPackingDistribution["Item"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["Item"]);
                        objPackingDistribution.Fabric = (drPackingDistribution["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["Fabric"]);
                        objPackingDistribution.Quantity = (drPackingDistribution["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["Quantity"]);

                        objPackingDistribution.PkgNoFrom = (drPackingDistribution["PkgNoFrom"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["PkgNoFrom"]);
                        objPackingDistribution.PkgNoTo = (drPackingDistribution["PkgNoTo"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["PkgNoTo"]);
                        objPackingDistribution.IsRatioPack = (drPackingDistribution["IsRatioPack"] == DBNull.Value) ? false : Convert.ToBoolean(drPackingDistribution["IsRatioPack"]);
                        objPackingDistribution.RatioPackQtyPerPkg = (drPackingDistribution["RatioPackQtyPerPkg"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["RatioPackQtyPerPkg"]);

                        objPackingDistribution.Sizes = new int[16];

                        for (int i = 1; i <= 16; i++)
                        {
                            objPackingDistribution.Sizes[i - 1] = (drPackingDistribution["Size" + i.ToString()] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["Size" + i.ToString()]);
                        }

                        objPackingDistribution.PackingSizes = new List<OrderDetailSizes>();

                        foreach (DataRow drSizes in dsPacking.Tables[2].Rows)
                        {
                            if (objPackingDistribution.OrderDetailID == (drSizes["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(drSizes["OrderDetailId"])))
                            {
                                OrderDetailSizes objOrderDetailSizes = new OrderDetailSizes();
                                objOrderDetailSizes.OrderDetailID = (drSizes["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailId"]);
                                objOrderDetailSizes.OrderDetailSizeID = (drSizes["OrderDetailSizeId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailSizeId"]);
                                objOrderDetailSizes.Size = (drSizes["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(drSizes["Size"]);
                                objOrderDetailSizes.Quantity = (drSizes["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Quantity"]);
                                objOrderDetailSizes.Singles = (drSizes["Singles"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Singles"]);
                                objOrderDetailSizes.Ratio = (drSizes["Ratio"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Ratio"]);
                                objOrderDetailSizes.RatioPack = (drSizes["RatioPack"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["RatioPack"]);

                                objPackingDistribution.PackingSizes.Add(objOrderDetailSizes);
                            }
                        }

                        objPacking.Distributions.Add(objPackingDistribution);
                    }

                    objPacking.Dimensions = new List<PackingDimension>();

                    foreach (DataRow drDimension in dsPacking.Tables[3].Rows)
                    {
                        PackingDimension objPackingDimension = new PackingDimension();

                        objPackingDimension.PackingDimensionID = (drDimension["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(drDimension["Id"]);
                        objPackingDimension.PackingID = (drDimension["PackingID"] == DBNull.Value) ? 0 : Convert.ToInt32(drDimension["PackingID"]);
                        objPackingDimension.Dimension = (drDimension["Dimension"] == DBNull.Value) ? string.Empty : Convert.ToString(drDimension["Dimension"]);
                        objPackingDimension.Quantity = (drDimension["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drDimension["Quantity"]);

                        objPacking.Dimensions.Add(objPackingDimension);
                    }
                }
            }

            return objPacking;
        }

        public bool SavePacking(Packing objPacking)
        {
            if (objPacking.PackingID == -1)
            {
                return InsertPacking(objPacking);
            }
            else
            {
                return UpdatePacking(objPacking);
            }
        }

        private bool InsertPacking(Packing objPacking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_packing_insert_packing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@PackingId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@Exporter", SqlDbType.Text);
                    param.Value = objPacking.Exporter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceNumber", SqlDbType.VarChar);
                    param.Value = objPacking.InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderNumber", SqlDbType.VarChar);
                    param.Value = objPacking.BuyerOrderNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderDate", SqlDbType.Date);
                    param.Value = objPacking.BuyerOrderDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherReferences", SqlDbType.VarChar);
                    param.Value = objPacking.OtherReferences;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Consignee", SqlDbType.Text);
                    param.Value = objPacking.Consignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOtherThanConsignee", SqlDbType.Text);
                    param.Value = objPacking.BuyerOtherThanConsignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfOriginOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfOriginOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfFinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfFinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreCarriageBy", SqlDbType.VarChar);
                    param.Value = objPacking.PreCarriageBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PlaceOfReceiptByPreCarrier", SqlDbType.VarChar);
                    param.Value = objPacking.PlaceOfReceiptByPreCarrier;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightNumber", SqlDbType.VarChar);
                    param.Value = objPacking.FlightNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfLoading", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfLoading;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfDischarge", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfDischarge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.FinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarksAndContainerNumber", SqlDbType.VarChar);
                    param.Value = objPacking.MarksAndContainerNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NumberAndKindOfPackages", SqlDbType.VarChar);
                    param.Value = objPacking.NumberAndKindOfPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DescriptionOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.DescriptionOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = objPacking.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalGrossWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalGrossWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalNetWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalNetWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalPackages", SqlDbType.Int);
                    param.Value = objPacking.TotalPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackageNumbers", SqlDbType.VarChar);
                    param.Value = objPacking.PackageNumbers;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
                    param.Value = objPacking.InvoiceDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TermsOfDeliveryAndPayment", SqlDbType.VarChar);
                    param.Value = objPacking.TermsOfDeliveryAndPayment;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    objPacking.PackingID = Convert.ToInt32(outParam.Value);

                    if (objPacking.PackingID <= 0)
                        return false;

                    foreach (PackingOrders objPackingOrders in objPacking.PackingOrdersCollection)
                    {
                        objPackingOrders.PackingID = objPacking.PackingID;
                        SavePackingOrderDetails(objPackingOrders, cnx, transaction);
                    }

                    foreach (PackingDistribution objPackingDistribution in objPacking.Distributions)
                    {
                        objPackingDistribution.PackingID = objPacking.PackingID;
                        InsertPackingDistribution(objPackingDistribution, cnx, transaction);
                    }

                    foreach (PackingDimension objPackingDimension in objPacking.Dimensions)
                    {
                        objPackingDimension.PackingID = objPacking.PackingID;
                        InsertPackingDimension(objPackingDimension, cnx, transaction);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }

            return false;
        }

        private bool UpdatePacking(Packing objPacking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_packing_update_packing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@PackingId", SqlDbType.Int);
                    param.Value = objPacking.PackingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Exporter", SqlDbType.Text);
                    param.Value = objPacking.Exporter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceNumber", SqlDbType.VarChar);
                    param.Value = objPacking.InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderNumber", SqlDbType.VarChar);
                    param.Value = objPacking.BuyerOrderNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderDate", SqlDbType.Date);
                    param.Value = objPacking.BuyerOrderDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherReferences", SqlDbType.VarChar);
                    param.Value = objPacking.OtherReferences;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Consignee", SqlDbType.Text);
                    param.Value = objPacking.Consignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOtherThanConsignee", SqlDbType.Text);
                    param.Value = objPacking.BuyerOtherThanConsignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfOriginOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfOriginOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfFinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfFinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreCarriageBy", SqlDbType.VarChar);
                    param.Value = objPacking.PreCarriageBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PlaceOfReceiptByPreCarrier", SqlDbType.VarChar);
                    param.Value = objPacking.PlaceOfReceiptByPreCarrier;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightNumber", SqlDbType.VarChar);
                    param.Value = objPacking.FlightNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfLoading", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfLoading;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfDischarge", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfDischarge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.FinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarksAndContainerNumber", SqlDbType.VarChar);
                    param.Value = objPacking.MarksAndContainerNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NumberAndKindOfPackages", SqlDbType.VarChar);
                    param.Value = objPacking.NumberAndKindOfPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DescriptionOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.DescriptionOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = objPacking.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalGrossWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalGrossWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalNetWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalNetWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalPackages", SqlDbType.Int);
                    param.Value = objPacking.TotalPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackageNumbers", SqlDbType.VarChar);
                    param.Value = objPacking.PackageNumbers;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
                    param.Value = objPacking.InvoiceDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TermsOfDeliveryAndPayment", SqlDbType.VarChar);
                    param.Value = objPacking.TermsOfDeliveryAndPayment;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    foreach (PackingOrders objPackingOrders in objPacking.PackingOrdersCollection)
                    {
                        objPackingOrders.PackingID = objPacking.PackingID;
                        SavePackingOrderDetails(objPackingOrders, cnx, transaction);
                    }

                    DeletePackingDistribution(objPacking.PackingID, cnx, transaction);
                    DeletePackingDimension(objPacking.PackingID, cnx, transaction);

                    foreach (PackingDistribution objPackingDistribution in objPacking.Distributions)
                    {
                        objPackingDistribution.PackingID = objPacking.PackingID;
                        InsertPackingDistribution(objPackingDistribution, cnx, transaction);
                    }

                    foreach (PackingDimension objPackingDimension in objPacking.Dimensions)
                    {
                        objPackingDimension.PackingID = objPacking.PackingID;
                        InsertPackingDimension(objPackingDimension, cnx, transaction);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }

            return false;
        }

        private bool SavePackingOrderDetails(PackingOrders objPackingOrder, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_order_save_packing_order";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            param.Value = objPackingOrder.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
            param.Value = objPackingOrder.OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalPackages", SqlDbType.Int);
            param.Value = objPackingOrder.TotalPackages;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PackageNumbers", SqlDbType.VarChar);
            param.Value = objPackingOrder.PackageNumbers;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.VarChar);
            param.Value = objPackingOrder.ProductionPlanningId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool InsertPackingDistribution(PackingDistribution objPackingDistribution, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_order_distribution_insert_distribution";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@PackingDistributionId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            param.Value = objPackingDistribution.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
            param.Value = objPackingDistribution.OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PkgNoFrom", SqlDbType.Int);
            param.Value = objPackingDistribution.PkgNoFrom;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PkgNoTo", SqlDbType.Int);
            param.Value = objPackingDistribution.PkgNoTo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric", SqlDbType.VarChar);
            param.Value = objPackingDistribution.Fabric;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalPackingQty", SqlDbType.Int);
            param.Value = objPackingDistribution.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sRatioPack", SqlDbType.Bit);
            param.Value = objPackingDistribution.IsRatioPack;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RatioPackQtyPerPkg", SqlDbType.Int);
            param.Value = objPackingDistribution.RatioPackQtyPerPkg;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            for (int i = 1; i <= objPackingDistribution.PackingSizes.Count; i++)
            {
                param = new SqlParameter("@Size" + i.ToString(), SqlDbType.Int);
                param.Value = objPackingDistribution.PackingSizes[i - 1].Quantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
            }

            for (int i = objPackingDistribution.PackingSizes.Count + 1; i <= 16; i++)
            {
                param = new SqlParameter("@Size" + i.ToString(), SqlDbType.Int);
                param.Value = 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery();

            int packingDistributionId = Convert.ToInt32(outParam.Value);

            return true;
        }

        private bool InsertPackingDimension(PackingDimension objPackingDimension, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_box_dimension_insert_dimension";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@PackingBoxDimensionID", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            param.Value = objPackingDimension.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Dimension", SqlDbType.VarChar);
            param.Value = objPackingDimension.Dimension;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = objPackingDimension.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int packingBoxDimensionId = Convert.ToInt32(outParam.Value);

            return true;
        }

        private bool DeletePackingDistribution(int packingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_order_distribution_delete_distribution";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param = new SqlParameter("@PackingId", SqlDbType.Int);
            param.Value = packingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool DeletePackingDimension(int packingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_box_dimension_delete_dimension";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param = new SqlParameter("@PackingId", SqlDbType.Int);
            param.Value = packingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }


        public int InsertIkandiInvoiceData(Invoice Invoice, SqlConnection cnx, SqlTransaction transaction)
        {
            int invoiceID = 0;

            string cmdText = "sp_invoice_insert_invoice";

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;
            SqlParameter paramOut;

            param = new SqlParameter("@ExporterName", SqlDbType.VarChar);
            param.Value = Invoice.ExporterName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Consignee", SqlDbType.VarChar);
            param.Value = Invoice.Consignee;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Notify", SqlDbType.VarChar);
            param.Value = Invoice.Notify;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PreCarriageBy", SqlDbType.VarChar);
            param.Value = Invoice.PreCarriageBy;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PlaceOfReceptPreCarriage", SqlDbType.VarChar);
            param.Value = Invoice.PlaceOfReceptPreCarriage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FlightNo", SqlDbType.VarChar);
            param.Value = Invoice.FlightNo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PortOfLoading", SqlDbType.VarChar);
            param.Value = Invoice.PortOfLoading;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PortOfDischarge", SqlDbType.VarChar);
            param.Value = Invoice.PortOfDischarge;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FinalDestination", SqlDbType.VarChar);
            param.Value = Invoice.FinalDestination;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@nvoiceNo", SqlDbType.VarChar);
            param.Value = Invoice.InvoiceNo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
            if ((Invoice.InvoiceDate == DateTime.MinValue) || (Invoice.InvoiceDate == Convert.ToDateTime("1753-01-01")) || (Invoice.InvoiceDate == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = Invoice.InvoiceDate;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExporterRefNo", SqlDbType.VarChar);
            param.Value = Invoice.ExporterRefNo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OtherRefrence", SqlDbType.VarChar);
            param.Value = Invoice.OtherRefrence;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Buyer", SqlDbType.VarChar);
            param.Value = Invoice.Buyer;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryOfOriginGoods", SqlDbType.VarChar);
            param.Value = Invoice.CountryOfOriginGoods;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryOfFinalGoods", SqlDbType.VarChar);
            param.Value = Invoice.CountryOfFinalDestination;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SBNO", SqlDbType.VarChar);
            param.Value = Invoice.SBNO;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SBDate", SqlDbType.DateTime);
            if ((Invoice.SBDate == DateTime.MinValue) || (Invoice.SBDate == Convert.ToDateTime("1753-01-01")) || (Invoice.SBDate == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = Invoice.SBDate;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MAWBNO", SqlDbType.VarChar);
            param.Value = Invoice.MAWBNO;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HAWBNO", SqlDbType.VarChar);
            param.Value = Invoice.HAWBNO;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HAWBDate", SqlDbType.DateTime);
            if ((Invoice.HAWBDate == DateTime.MinValue) || (Invoice.HAWBDate == Convert.ToDateTime("1753-01-01")) || (Invoice.HAWBDate == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = Invoice.HAWBDate;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Freight", SqlDbType.VarChar);
            param.Value = Invoice.Freight;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Terms", SqlDbType.VarChar);
            param.Value = Invoice.Terms;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MarkAndNo", SqlDbType.VarChar);
            param.Value = Invoice.MarkAndNo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description1", SqlDbType.VarChar);
            param.Value = Invoice.Description1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description2", SqlDbType.VarChar);
            param.Value = Invoice.Description2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description3", SqlDbType.VarChar);
            param.Value = Invoice.Description3;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description4", SqlDbType.VarChar);
            param.Value = Invoice.Description4;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = Invoice.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount1", SqlDbType.Float);
            param.Value = Invoice.Amount1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount2", SqlDbType.Float);
            param.Value = Invoice.Amount2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount3", SqlDbType.Float);
            param.Value = Invoice.Amount3;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Float);
            param.Value = Invoice.Total;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DiscountRate", SqlDbType.Float);
            param.Value = Invoice.DiscountRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DiscountTotal", SqlDbType.Float);
            param.Value = Invoice.DiscountTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GrossTotal", SqlDbType.Float);
            param.Value = Invoice.GrossTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VatRate", SqlDbType.Float);
            param.Value = Invoice.VatRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VatTotal", SqlDbType.Float);
            param.Value = Invoice.VatTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GrandTotal", SqlDbType.Float);
            param.Value = Invoice.GrandTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AmountInWord", SqlDbType.VarChar);
            param.Value = Invoice.AmountInWord;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@nvoiceType", SqlDbType.Int);
            param.Value = Invoice.InvoiceType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            if (Invoice.PackingID > 0)
            {
                param.Value = Invoice.PackingID;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TermsOfDelevery", SqlDbType.VarChar);
            param.Value = Invoice.TermsOfDelevery;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.VarChar);
            param.Value = Invoice.CreatedBy;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
            if ((Invoice.CreatedOn == DateTime.MinValue) || (Invoice.CreatedOn == Convert.ToDateTime("1753-01-01")) || (Invoice.CreatedOn == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                param.Value = Invoice.CreatedOn;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UpdatedBy", SqlDbType.VarChar);
            param.Value = Invoice.UpdatedBy;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
            if ((Invoice.UpdatedOn == DateTime.MinValue) || (Invoice.UpdatedOn == Convert.ToDateTime("1753-01-01")) || (Invoice.UpdatedOn == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = Invoice.UpdatedOn;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryOfOrigin", SqlDbType.VarChar);
            param.Value = Invoice.CountryOfOrigin;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VATNO", SqlDbType.VarChar);
            param.Value = Invoice.VATNO;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NumberAndKindOfPackages", SqlDbType.VarChar);
            param.Value = Invoice.NumberAndKindOfPackages;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PaymentDueDate", SqlDbType.DateTime);
            param.Value = DBNull.Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = Invoice.Rate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AmountMode", SqlDbType.VarChar);
            param.Value = Invoice.AmountMode;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FlightDate", SqlDbType.DateTime);
            if ((Invoice.FlightDate == DateTime.MinValue) || (Invoice.FlightDate == Convert.ToDateTime("1753-01-01")) || (Invoice.FlightDate == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = Invoice.FlightDate;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentInvoiceID", SqlDbType.Int);
            if (Invoice.ParentIkandiInvoiceID > 0)
            {
                param.Value = Invoice.ParentIkandiInvoiceID;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@nvoiceComments", SqlDbType.VarChar);
            param.Value = Invoice.InvoiceComments;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BuyerOrderNumber", SqlDbType.VarChar);
            param.Value = Invoice.BuyerOrderNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDate", SqlDbType.DateTime);
            if ((Invoice.OrderDate == DateTime.MinValue) || (Invoice.OrderDate == Convert.ToDateTime("1753-01-01")) || (Invoice.OrderDate == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = Invoice.OrderDate;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Manufacturer", SqlDbType.VarChar);
            param.Value = Invoice.Manufacturer;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@nvoiceDetails", SqlDbType.Text);
            param.Value = Invoice.InvoiceDetails;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail1Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail1Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail2Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail2Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail3Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail3Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail4Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail4Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail5Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail5Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail6Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail6Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail7Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail7Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail8Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail8Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail9Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail9Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail10Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail10Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail11Text", SqlDbType.VarChar);
            param.Value = Invoice.Detail11Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail1Value", SqlDbType.VarChar);
            param.Value = Invoice.Detail1Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail2Value", SqlDbType.VarChar);
            param.Value = Invoice.Detail2Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail3Value", SqlDbType.VarChar);
            param.Value = Invoice.Detail3Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Detail4Value", SqlDbType.VarChar);
            param.Value = Invoice.Detail4Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PackingDetails", SqlDbType.VarChar);
            param.Value = Invoice.PackingDetails;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FreightText", SqlDbType.VarChar);
            param.Value = Invoice.FreightText;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DiscountText", SqlDbType.VarChar);
            param.Value = Invoice.DiscountText;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@nsuranceText", SqlDbType.VarChar);
            param.Value = Invoice.InsuranceText;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DiscountVal", SqlDbType.Decimal);
            param.Value = Invoice.Discount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);




            paramOut = new SqlParameter("@d", SqlDbType.Int);
            paramOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramOut);

            cmd.ExecuteNonQuery();

            invoiceID = Convert.ToInt32(paramOut.Value);


            return invoiceID;
        }

        public int UpdateIkandiInvoiceData(Invoice Invoice, SqlConnection cnx, SqlTransaction transaction)
        {

            try
            {
                string cmdText = "sp_invoice_update_invoice";

                SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ExporterName", SqlDbType.VarChar);
                param.Value = Invoice.ExporterName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Consignee", SqlDbType.VarChar);
                param.Value = Invoice.Consignee;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Notify", SqlDbType.VarChar);
                param.Value = Invoice.Notify;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PreCarriageBy", SqlDbType.VarChar);
                param.Value = Invoice.PreCarriageBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PlaceOfReceptPreCarriage", SqlDbType.VarChar);
                param.Value = Invoice.PlaceOfReceptPreCarriage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlightNo", SqlDbType.VarChar);
                param.Value = Invoice.FlightNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FlightDate", SqlDbType.DateTime);
                param.Value = Invoice.FlightDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@PortOfLoading", SqlDbType.VarChar);
                param.Value = Invoice.PortOfLoading;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PortOfDischarge", SqlDbType.VarChar);
                param.Value = Invoice.PortOfDischarge;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinalDestination", SqlDbType.VarChar);
                param.Value = Invoice.FinalDestination;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nvoiceNo", SqlDbType.VarChar);
                param.Value = Invoice.InvoiceNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
                param.Value = Invoice.InvoiceDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExporterRefNo", SqlDbType.VarChar);
                param.Value = Invoice.ExporterRefNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OtherRefrence", SqlDbType.VarChar);
                param.Value = Invoice.OtherRefrence;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Buyer", SqlDbType.VarChar);
                param.Value = Invoice.Buyer;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountryOfOriginGoods", SqlDbType.VarChar);
                param.Value = Invoice.CountryOfOriginGoods;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountryOfFinalGoods", SqlDbType.VarChar);
                param.Value = Invoice.CountryOfFinalDestination;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SBNO", SqlDbType.VarChar);
                param.Value = Invoice.SBNO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SBDate", SqlDbType.DateTime);
                param.Value = Invoice.SBDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MAWBNO", SqlDbType.VarChar);
                param.Value = Invoice.MAWBNO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HAWBNO", SqlDbType.VarChar);
                param.Value = Invoice.HAWBNO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HAWBDate", SqlDbType.DateTime);
                param.Value = Invoice.HAWBDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Freight", SqlDbType.VarChar);
                param.Value = Invoice.Freight;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Terms", SqlDbType.VarChar);
                param.Value = Invoice.Terms;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TermsInNumber", SqlDbType.Int);
                param.Value = Invoice.TermsInNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MarkAndNo", SqlDbType.VarChar);
                param.Value = Invoice.MarkAndNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description1", SqlDbType.VarChar);
                param.Value = Invoice.Description1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description2", SqlDbType.VarChar);
                param.Value = Invoice.Description2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description3", SqlDbType.VarChar);
                param.Value = Invoice.Description3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description4", SqlDbType.VarChar);
                param.Value = Invoice.Description4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Quantity", SqlDbType.Int);
                param.Value = Invoice.Quantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate", SqlDbType.Float);
                param.Value = Invoice.Rate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount1", SqlDbType.Float);
                param.Value = Invoice.Amount1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount2", SqlDbType.Float);
                param.Value = Invoice.Amount2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount3", SqlDbType.Float);
                param.Value = Invoice.Amount3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Total", SqlDbType.Float);
                param.Value = Invoice.Total;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscountRate", SqlDbType.Float);
                param.Value = Invoice.DiscountRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscountTotal", SqlDbType.Float);
                param.Value = Invoice.DiscountTotal;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GrossTotal", SqlDbType.Float);
                param.Value = Invoice.GrossTotal;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VatRate", SqlDbType.Float);
                param.Value = Invoice.VatRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VatTotal", SqlDbType.Float);
                param.Value = Invoice.VatTotal;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GrandTotal", SqlDbType.Float);
                param.Value = Invoice.GrandTotal;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AmountInWord", SqlDbType.VarChar);
                param.Value = Invoice.AmountInWord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nvoiceType", SqlDbType.Int);
                param.Value = Invoice.InvoiceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PackingID", SqlDbType.Int);
                param.Value = Invoice.PackingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TermsOfDelevery", SqlDbType.VarChar);
                param.Value = Invoice.TermsOfDelevery;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.VarChar);
                param.Value = Invoice.CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UpdatedBy", SqlDbType.VarChar);
                param.Value = Invoice.UpdatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
                param.Value = Invoice.CreatedOn;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
                param.Value = Invoice.UpdatedOn;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountryOfOrigin", SqlDbType.VarChar);
                param.Value = Invoice.CountryOfOrigin;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VATNO", SqlDbType.VarChar);
                param.Value = Invoice.VATNO;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nvoiceID", SqlDbType.Int);
                param.Value = Invoice.InvoiceID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@NumberAndKindOfPackages", SqlDbType.VarChar);
                param.Value = Invoice.NumberAndKindOfPackages;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@DescOfGoods", SqlDbType.VarChar);
                //param.Value = Invoice.DescOfGoods;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@nsurancePrepaid", SqlDbType.Float);
                param.Value = Invoice.InsurancePrepaid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FreightPrepaid", SqlDbType.Float);
                param.Value = Invoice.FreightPrepaid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MAWBType", SqlDbType.VarChar);
                param.Value = Invoice.MAWBType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@HAWBType", SqlDbType.VarChar);
                param.Value = Invoice.HAWBType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AmountMode", SqlDbType.VarChar);
                param.Value = Invoice.AmountMode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TotalMode", SqlDbType.VarChar);
                param.Value = Invoice.TotalMode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nvoiceComments", SqlDbType.VarChar);
                param.Value = Invoice.InvoiceComments;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyerOrderNumber", SqlDbType.VarChar);
                param.Value = Invoice.BuyerOrderNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDate", SqlDbType.DateTime);
                if (Invoice.OrderDate != DateTime.MinValue)
                {
                    param.Value = Invoice.OrderDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                cmd.ExecuteNonQuery();


                return Invoice.InvoiceID;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return -1;
        }


        public void InsertInvoicePacking(int InvoiceID, int PackingID, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_invoice_packing_insert_invoice_packing";

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@nvoiceID", SqlDbType.Int);
            param.Value = InvoiceID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            param.Value = PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();


        }



        public List<Invoice> GetBiplInvoiceDataByInvoiceID(int InvoiceID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_invoice_bipl_invoice_data_by_invoiceid";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@nvoiceId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceID;
                cmd.Parameters.Add(param);



                reader = cmd.ExecuteReader();

                List<Invoice> objInvoice = new List<Invoice>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Invoice invoice = new Invoice();

                        invoice.ExporterName = (reader["Exporter"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Exporter"]);
                        invoice.ExporterRefNo = (reader["ExporterRefNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ExporterRefNo"]);
                        invoice.InvoiceNo = (reader["InvoiceNumber"] == DBNull.Value) ? string.Empty : (Convert.ToString(reader["InvoiceNumber"]) + ", ");
                        invoice.Consignee = (reader["Consignee"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Consignee"]);
                        invoice.OtherRefrence = (reader["OtherReferences"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OtherReferences"]);
                        invoice.Buyer = (reader["BuyerOtherThanConsignee"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BuyerOtherThanConsignee"]);
                        invoice.CountryOfOriginGoods = (reader["CountryOfOriginOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountryOfOriginOfGoods"]);
                        invoice.CountryOfOrigin = (reader["CountryOfOrigin"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountryOfOrigin"]);
                        invoice.PackingIDs = (reader["PackingID"] == DBNull.Value) ? string.Empty : (Convert.ToString(Convert.ToInt32(reader["PackingID"])) + ",");
                        invoice.PlaceOfReceptPreCarriage = (reader["PlaceOfReceiptByPreCarrier"] == DBNull.Value || reader["PlaceOfReceiptByPreCarrier"].ToString() == string.Empty) ? "NEW DELHI" : Convert.ToString(reader["PlaceOfReceiptByPreCarrier"]);
                        invoice.FlightNo = (reader["FlightNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FlightNumber"]);
                        invoice.TermsOfDelevery = (reader["TermsOfDeliveryAndPayment"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TermsOfDeliveryAndPayment"]);
                        invoice.InvoiceDate = (reader["InvoiceDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["InvoiceDate"]);
                        invoice.Description1 = (reader["DescriptionOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DescriptionOfGoods"]);

                        int Shippingquantity = (reader["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ShippingQty"]);
                        invoice.Quantity = (reader["Quantity"] == DBNull.Value || reader["Quantity"].ToString() == "") ? Shippingquantity : Convert.ToInt32(reader["Quantity"]);

                        invoice.Notify = (reader["Notify"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Notify"]);
                        invoice.SBNO = (reader["SBNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SBNO"]);
                        invoice.SBDate = (reader["SBDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SBDate"]);
                        invoice.MAWBNO = (reader["MAWBNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MAWBNO"]);
                        invoice.HAWBNO = (reader["HAWBNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["HAWBNO"]);
                        invoice.HAWBType = (reader["HAWBType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["HAWBType"]);
                        invoice.MAWBType = (reader["MAWBType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MAWBType"]);
                        invoice.HAWBDate = (reader["HAWBDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["HAWBDate"]);
                        invoice.Freight = (reader["Freight"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Freight"]);
                        invoice.Terms = (reader["Terms"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Terms"]);
                        invoice.TermsInNumber = (reader["TermsInNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["TermsInNumber"]);
                        invoice.FlightDate = (reader["FlightDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["FlightDate"]);
                        invoice.Description4 = (reader["Description4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description4"]);
                        invoice.Amount1 = (reader["Amount1"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount1"]);
                        invoice.Amount2 = (reader["Amount2"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount2"]);
                        invoice.Amount3 = (reader["Amount3"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount3"]);
                        invoice.Total = (reader["Total"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Total"]);
                        invoice.DiscountTotal = (reader["DiscountTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["DiscountTotal"]);
                        invoice.GrossTotal = (reader["GrossTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["GrossTotal"]);

                        invoice.VatTotal = (reader["VatTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["VatTotal"]);
                        invoice.GrandTotal = (reader["GrandTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["GrandTotal"]);
                        invoice.AmountInWord = (reader["AmountInWord"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AmountInWord"]);

                        invoice.CreatedBy = (reader["CreatedBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CreatedBy"]);
                        invoice.UpdatedBy = (reader["ModifiedBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ModifiedBy"]);
                        invoice.CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                        invoice.UpdatedOn = (reader["ModifiedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ModifiedOn"]);

                        invoice.VATNO = (reader["VATNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["VATNO"]);

                        invoice.InsurancePrepaid = (reader["InsurancePrepaid"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["InsurancePrepaid"]);
                        invoice.FreightPrepaid = (reader["FreightPrepaid"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["FreightPrepaid"]);

                        objInvoice.Add(invoice);

                    }
                }
                cnx.Close();
                return objInvoice;

            }


        }


        public Invoice GetIkandiInvoiceDataByInvoiceId(int InvoiceID, int InvoiceType)
        {
            Invoice invoice = new Invoice();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_invoice_get_ikandi_invoice_form_by_invoiceId";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@nvoiceID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nvoiceType", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceType;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        invoice.ExporterName = (reader["Exporter"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Exporter"]);
                        invoice.Consignee = (reader["Consignee"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Consignee"]);
                        invoice.Notify = (reader["Notify"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Notify"]);
                        invoice.PreCarriageBy = (reader["PreCarriageBy"] == DBNull.Value) ? "" : Convert.ToString(reader["PreCarriageBy"]);
                        invoice.PlaceOfReceptPreCarriage = (reader["PlaceOfReceiptByPreCarrier"] == DBNull.Value) ? "" : Convert.ToString(reader["PlaceOfReceiptByPreCarrier"]);
                        invoice.FlightNo = (reader["FlightNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FlightNumber"]);
                        invoice.PortOfLoading = (reader["PortOfLoading"] == DBNull.Value) ? "" : Convert.ToString(reader["PortOfLoading"]);
                        invoice.PortOfDischarge = (reader["PortOfDischarge"] == DBNull.Value) ? "" : Convert.ToString(reader["PortOfDischarge"]);
                        invoice.FinalDestination = (reader["FinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FinalDestination"]);
                        invoice.InvoiceNo = (reader["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["InvoiceNumber"]);
                        invoice.InvoiceDate = (reader["InvoiceDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["InvoiceDate"]);
                        invoice.ExporterRefNo = (reader["ExporterRefNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ExporterRefNo"]);
                        invoice.OtherRefrence = (reader["OtherReferences"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OtherReferences"]);
                        invoice.Buyer = (reader["BuyerOtherThanConsignee"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BuyerOtherThanConsignee"]);
                        invoice.CountryOfOriginGoods = (reader["CountryOfOriginOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountryOfOriginOfGoods"]);
                        invoice.CountryOfFinalDestination = (reader["CountryOfFinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountryOfFinalDestination"]);
                        invoice.SBNO = (reader["SBNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SBNO"]);
                        invoice.SBDate = (reader["SBDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SBDate"]);
                        invoice.MAWBNO = (reader["MAWBNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MAWBNO"]);
                        invoice.HAWBNO = (reader["HAWBNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["HAWBNO"]);
                        invoice.HAWBDate = (reader["HAWBDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["HAWBDate"]);
                        invoice.Freight = (reader["Freight"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Freight"]);
                        invoice.Terms = (reader["Terms"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Terms"]);
                        invoice.MarkAndNo = (reader["MarksAndContainerNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MarksAndContainerNumber"]);
                        invoice.Description1 = (reader["DescriptionOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DescriptionOfGoods"]);
                        invoice.Description2 = (reader["Description2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description2"]);
                        invoice.Description3 = (reader["Description3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description3"]);
                        invoice.Description4 = (reader["Description4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description4"]);
                        invoice.Quantity = (reader["Quantity"] == DBNull.Value || reader["Quantity"].ToString() == "") ? 0 : Convert.ToInt32(reader["Quantity"]);
                        invoice.Amount1 = (reader["Amount1"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount1"]);
                        invoice.Amount2 = (reader["Amount2"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount2"]);
                        invoice.Amount3 = (reader["Amount3"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount3"]);
                        invoice.Total = (reader["Total"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Total"]);
                        invoice.DiscountRate = (reader["DiscountRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["DiscountRate"]);
                        invoice.DiscountTotal = (reader["DiscountTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["DiscountTotal"]);
                        invoice.GrossTotal = (reader["GrossTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["GrossTotal"]);
                        invoice.VatRate = (reader["VatRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["VatRate"]);
                        invoice.VatTotal = (reader["VatTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["VatTotal"]);
                        invoice.GrandTotal = (reader["GrandTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["GrandTotal"]);
                        invoice.AmountInWord = (reader["AmountInWord"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AmountInWord"]);
                        invoice.InvoiceType = (reader["InvoiceType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["InvoiceType"]);
                        invoice.PackingID = (reader["PackingID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PackingID"]);
                        invoice.TermsOfDelevery = (reader["TermsOfDeliveryAndPayment"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TermsOfDeliveryAndPayment"]);
                        invoice.CreatedBy = (reader["CreatedBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CreatedBy"]);
                        invoice.UpdatedBy = (reader["ModifiedBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ModifiedBy"]);
                        invoice.CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                        invoice.UpdatedOn = (reader["ModifiedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ModifiedOn"]);
                        invoice.CountryOfOrigin = (reader["CountryOfOrigin"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountryOfOrigin"]);
                        invoice.VATNO = (reader["VATNO"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["VATNO"]);
                        invoice.PaymentDueDate = (reader["PaymentDueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["PaymentDueDate"]) : DateTime.MinValue;
                        invoice.PaymentReceivedDate = (reader["PaymentReceivedDate"] != DBNull.Value) ? Convert.ToDateTime(reader["PaymentReceivedDate"]) : DateTime.MinValue;
                        invoice.PaymentReceivedAmount = (reader["PaymentReceivedAmount"] != DBNull.Value) ? Convert.ToDouble(reader["PaymentReceivedAmount"]) : 0;
                        invoice.FreightPrepaid = (reader["FreightPrepaid"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["FreightPrepaid"]);
                        invoice.InsurancePrepaid = (reader["InsurancePrepaid"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["InsurancePrepaid"]);
                        invoice.HAWBType = (reader["HAWBType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["HAWBType"]);
                        invoice.MAWBType = (reader["MAWBType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MAWBType"]);
                        invoice.Rate = (reader["Rate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Rate"]);
                        invoice.AmountMode = (reader["AmountMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AmountMode"]);
                        invoice.FlightDate = (reader["FlightDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["FlightDate"]);
                        invoice.TotalMode = (reader["TotalMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TotalMode"]);
                        invoice.TermsInNumber = (reader["TermsInNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["TermsInNumber"]);
                        invoice.ParentIkandiInvoiceID = (reader["ParentInvoiceID"] != DBNull.Value) ? Convert.ToInt32(reader["ParentInvoiceID"]) : 0;
                        invoice.InvoiceComments = (reader["Comment"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Comment"]);
                        invoice.BuyerOrderNumber = (reader["BuyerOrderNumber"] != DBNull.Value) ? Convert.ToString(reader["BuyerOrderNumber"]) : string.Empty;
                        invoice.OrderDate = (reader["InvoiceOrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["InvoiceOrderDate"]);

                        invoice.OrderDetail = new OrderDetail();
                        invoice.OrderDetail.ParentOrder = new Order();
                        invoice.OrderDetail.ParentOrder.Costing = new Costing();
                        invoice.OrderDetail.ParentOrder.Costing.ConvertTo = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);
                    }
                }
                cnx.Close();
                return invoice;

            }


        }

        public DataTable GetProductionPlanningIdByOrderDetailID(int OrderDetailID) // newly added
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_get_production_planning_id_by_order_detail_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);

            }

            return ds.Tables[0];
        }

        public bool GetIsValidInvoiceNumber(string InvoiceNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_invoice_get_invoice_number";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@nvoiceNumber", SqlDbType.VarChar);
                    param.Value = InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public bool SetIkandiInvoiceVisible(int InvoiceId, string Details)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_invoice_set_ikandi_invoice_visible";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@nvoiceId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = InvoiceId;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Details", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Details;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            return true;
        }


        public DateTime GetDeliveredDateByInvoiceID(int InvoiceID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_get_deliveredDate_by_invoiceId";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@nvoiceID", SqlDbType.Int);
                    param.Value = InvoiceID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();
                    DateTime date = DateTime.MinValue;
                    while (reader.Read())
                    {
                        date = (reader["ActionDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate"]);
                    }

                    return date;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        //added by abhishek on 4/8/2017 shipping modual----------//
        public DataSet GetPackingInvoiceDetails(string Flag, int OrderID, int OrderDetailID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetPackingDetails";
                //string cmdText = "Usp_GetPackingDetails_back";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);

            }

            return ds;
        }
        public bool UpdatePackingList(PackingDelivery PackingDelivery, string Flags)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "Usp_SavePackingInvoiceDetails";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    //param.Value = "PACKING";
                    param.Value = Flags;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = PackingDelivery.OrderDetailsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingDocPath", SqlDbType.VarChar);
                    if (PackingDelivery.PackingListFilePath == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = PackingDelivery.PackingListFilePath;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsFileUpload", SqlDbType.Int);

                    param.Value = PackingDelivery.IsConsolidation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = PackingDelivery.LoggedInUserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippingNo", SqlDbType.VarChar);
                    param.Value = PackingDelivery.ShippingNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

            }

            return false;
        }
        public DataSet GetPackingShippingNo(string Flag, int OrderDetailID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetPackingDetails";
                //string cmdText = "Usp_GetPackingDetails_back";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);

            }

            return ds;
        }
        public bool UpdateConsolidation(PackingDelivery PackingDelivery)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "Usp_SavePackingInvoiceDetails";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = "CONSOLIDATION";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = PackingDelivery.OrderDetailsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippingNo", SqlDbType.VarChar);
                    param.Value = PackingDelivery.ShippingNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    string LandingETA = PackingDelivery.LandingETA.ToString().Substring(0, 9);
                    IFormatProvider Provider = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat; //(dd/mm/yyyy)
                    DateTime PrdDate = Convert.ToDateTime(LandingETA, Provider);
                    param = new SqlParameter("@LandingETA", SqlDbType.DateTime);
                    param.Value = PrdDate;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BINo", SqlDbType.VarChar);
                    if (PackingDelivery.BIno == string.Empty)
                        param.Value = DBNull.Value;
                    else
                        param.Value = PackingDelivery.BIno;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightDetail", SqlDbType.VarChar);
                    if (PackingDelivery.FlightDetails == string.Empty)
                        param.Value = DBNull.Value;
                    else
                        param.Value = PackingDelivery.FlightDetails;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsConsolidation", SqlDbType.Int);
                    param.Value = PackingDelivery.IsConsolidation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = PackingDelivery.LoggedInUserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippingNoID", SqlDbType.Int);
                    param.Value = PackingDelivery.ConsolidationShippingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

            }

            return false;
        }
        public bool AddShippingNumber(PackingDelivery PackingDelivery, out int NewShippingID)
        {
            NewShippingID = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "Usp_SavePackingInvoiceDetails";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = "CONSOLIDATION";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = PackingDelivery.OrderDetailsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippingNo", SqlDbType.VarChar);
                    param.Value = PackingDelivery.ShippingNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    string LandingETA = PackingDelivery.LandingETA.ToString().Substring(0, 9);
                    IFormatProvider Provider = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat; //(dd/mm/yyyy)
                    DateTime PrdDate = Convert.ToDateTime(LandingETA, Provider);
                    param = new SqlParameter("@LandingETA", SqlDbType.DateTime);
                    param.Value = PrdDate;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BINo", SqlDbType.VarChar);
                    if (PackingDelivery.BIno == string.Empty)
                        param.Value = DBNull.Value;
                    else
                        param.Value = PackingDelivery.BIno;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightDetail", SqlDbType.VarChar);
                    if (PackingDelivery.FlightDetails == string.Empty)
                        param.Value = DBNull.Value;
                    else
                        param.Value = PackingDelivery.FlightDetails;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsConsolidation", SqlDbType.Int);
                    param.Value = PackingDelivery.IsConsolidation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = PackingDelivery.LoggedInUserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippingNoID", SqlDbType.Int);
                    param.Value = PackingDelivery.ConsolidationShippingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentNoIDOut", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    NewShippingID = (int)cmd.Parameters["@ShipmentNoIDOut"].Value;
                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

            }

            return false;
        }
        public DataSet GetPackingDetailsByShippingNo(string Flag, int OrderID, int OrderDetailID, string ShippingNo, int shippingID, string SaerchText)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetPackingDetails";
                //string cmdText = "Usp_GetPackingDetails_back";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShippingNo", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = ShippingNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShippingNoID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = shippingID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = SaerchText;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);

            }

            return ds;
        }
        public bool UpdateInvoice(PackingDelivery PackingDelivery)
        {

            IFormatProvider Provider = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat; //(dd/mm/yyyy)

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "Usp_SavePackingInvoiceDetails";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = "INVOICED";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = PackingDelivery.OrderDetailsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippingNo", SqlDbType.VarChar);
                    param.Value = PackingDelivery.ShippingNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    string LandingETA = PackingDelivery.LandingETA.ToString().Substring(0, 9);

                    DateTime PrdDate = Convert.ToDateTime(LandingETA, Provider);
                    param = new SqlParameter("@LandingETA", SqlDbType.DateTime);
                    param.Value = PrdDate;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BINo", SqlDbType.VarChar);
                    if (PackingDelivery.BIno == string.Empty)
                        param.Value = DBNull.Value;
                    else
                        param.Value = PackingDelivery.BIno;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightDetail", SqlDbType.VarChar);
                    if (PackingDelivery.FlightDetails == string.Empty)
                        param.Value = DBNull.Value;
                    else
                        param.Value = PackingDelivery.FlightDetails;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsConsolidation", SqlDbType.Int);
                    param.Value = PackingDelivery.IsConsolidation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = PackingDelivery.LoggedInUserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippingNoID", SqlDbType.Int);
                    param.Value = PackingDelivery.ConsolidationShippingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InvoiceFilePath", SqlDbType.VarChar);
                    if (PackingDelivery.InvoiceFilePath == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = PackingDelivery.InvoiceFilePath;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@invoiceNumber", SqlDbType.VarChar);
                    param.Value = PackingDelivery.InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@invoiceAmount", SqlDbType.Decimal);
                    //param.Value = PackingDelivery.InvoiceAmount;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@invoiceAmount", SqlDbType.Decimal);
                    param.Value = PackingDelivery.InvoiceShipValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InvoiceShipValue", SqlDbType.Decimal);
                    param.Value = PackingDelivery.InvoiceAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrightCharge", SqlDbType.Decimal);
                    param.Value = PackingDelivery.FrightCharge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DiscountAmt", SqlDbType.Decimal);
                    param.Value = PackingDelivery.DiscountAmt;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InsuranceAmt", SqlDbType.Decimal);
                    param.Value = PackingDelivery.InsuranceAmt;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    string invoiceDate = PackingDelivery.InvoiceDate.ToString().Substring(0, 9);
                    DateTime DateInvoice = Convert.ToDateTime(invoiceDate, Provider);
                    param = new SqlParameter("@invoiceDate", SqlDbType.DateTime);
                    param.Value = DateInvoice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SbNo", SqlDbType.VarChar);
                    if (PackingDelivery.SBno == "")
                        param.Value = DBNull.Value;
                    else
                        param.Value = PackingDelivery.SBno;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@SbDate", SqlDbType.DateTime);
                    if (PackingDelivery.SBDate.ToString() != "")
                    {
                        string sbdate = PackingDelivery.SBDate.ToString().Substring(0, 9);
                        DateTime DateInvoiceSb = Convert.ToDateTime(sbdate, Provider);
                        param.Value = sbdate;
                    }
                    else
                        param.Value = DBNull.Value;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@InvoicePaymentDueDate", SqlDbType.DateTime);
                    if (PackingDelivery.PaymentDueDate.ToString() != "")
                    {
                        string paymentdueDate = PackingDelivery.PaymentDueDate.ToString().Substring(0, 9);
                        DateTime DateInvoicepaymentdue = Convert.ToDateTime(paymentdueDate, Provider);
                        param.Value = DateInvoicepaymentdue;
                    }
                    else
                        param.Value = DBNull.Value;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentNoIDOut", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

            }

            return false;
        }

        public List<PackingDelivery> GetBIPLInvoiceDetails(string Flag, string bankrefNo, string IsAction, string SearchText)
        {


            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetInvoiceDetails";
                //cmdText = "Usp_GetInvoiceDetails_testabhi";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Flag;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BankRefNos", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = bankrefNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsAction", SqlDbType.NChar);
                param.Direction = ParameterDirection.Input;
                param.Value = IsAction;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = SearchText;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<PackingDelivery> PackingDeliverys = new List<PackingDelivery>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PackingDelivery Invoicepayment = new PackingDelivery();

                        Invoicepayment.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        Invoicepayment.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        Invoicepayment.InvoiceNumber = (reader["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["InvoiceNumber"]);
                        Invoicepayment.InvoiceDate = (reader["InvoiceDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["InvoiceDate"]).ToString("dd MMM yy (ddd)");
                        Invoicepayment.SBno = (reader["SBNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SBNumber"]);
                        Invoicepayment.SBDate = (reader["SBDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["SBDate"]).ToString("dd MMM yy (ddd)");
                        Invoicepayment.ConvertTO = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);
                        Invoicepayment.InvoiceAmount = (reader["InvoiceAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["InvoiceAmt"]);
                        Invoicepayment.ShippingNo = (reader["ShipmentNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ShipmentNo"]);
                        Invoicepayment.TotalBEAmount = (reader["TotalAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TotalAmt"]);
                        Invoicepayment.BankRefNumber = (reader["BankRefNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BankRefNo"]);
                        Invoicepayment.PaymentReceiveDate = (reader["PaymentReceivedOn"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentReceivedOn"]).ToString("dd MMM yy (ddd)");
                        Invoicepayment.OrderDetailsID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
                        Invoicepayment.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        Invoicepayment.PaymentDueDate = (reader["PaymentDueDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentDueDate"]).ToString("dd MMM yy (ddd)");
                        Invoicepayment.BankRefNoCount = (reader["Counts"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Counts"]);
                        Invoicepayment.PaymentClearDate = (reader["PaymentCleareddate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentCleareddate"]).ToString("dd MMM yy (ddd)");
                        Invoicepayment.Tenure = (reader["Tenure"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Tenure"]);
                        Invoicepayment.BankRefID = (reader["BnkRefID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["BnkRefID"]);
                        Invoicepayment.IsSingle = (reader["IsSingle"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["IsSingle"]);
                        Invoicepayment.BankPaymentRecAmt = (reader["BnkPayemntRecAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BnkPayemntRecAmt"]);
                        Invoicepayment.IsFullPaymentCleard = (reader["IsPaymentCleared"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsPaymentCleared"]);
                        Invoicepayment.ShipmentNo__PkID = (reader["ShipmentNo__PkID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ShipmentNo__PkID"]);
                        Invoicepayment.IsAction = (reader["IsAction"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["IsAction"]);
                        Invoicepayment.BankPendingAmt = (reader["PedningBeAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PedningBeAmt"]);
                        PackingDeliverys.Add(Invoicepayment);


                    }
                }
                cnx.Close();
                return PackingDeliverys;

            }


        }
        public DataSet GetBankRefNoForGrouping(string Flag, int ClientCurrency)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetInvoiceDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientCurrency", SqlDbType.Int);
                param.Value = ClientCurrency;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);

            }

            return ds;
        }
        public bool UpdateInvoiceIsSingle(string BankRefNo, int BankRefID, string IsSingle)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_set_invoice_Payment_single";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@BankRefNo", SqlDbType.VarChar);
                    param.Value = BankRefNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BankRefID", SqlDbType.Int);
                    param.Value = BankRefID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sChecked", SqlDbType.NChar);
                    param.Value = IsSingle;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

            }

            return false;
        }
        public bool UpdateInvoiceBankPayment(PackingDelivery PackingDelivery)
        {
            IFormatProvider Provider = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat; //(dd/mm/yyyy)

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "Usp_SaveBankRefPaymentDetails";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = "BIPLPAYMENT";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = PackingDelivery.OrderDetailsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentNoID", SqlDbType.Int);
                    param.Value = PackingDelivery.ShipmentNo__PkID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BankRefNo", SqlDbType.VarChar);
                    param.Value = PackingDelivery.BankRefNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    if (PackingDelivery.PaymentClearDate.ToString() != "")
                    {
                        string PayClearDate = PackingDelivery.PaymentClearDate.ToString().Substring(0, 9);
                        DateTime Date = Convert.ToDateTime(PayClearDate, Provider);
                        param = new SqlParameter("@PayemntClearDate", SqlDbType.DateTime);
                        param.Value = Date;
                        cmd.Parameters.Add(param);

                    }
                    else
                    {
                        param = new SqlParameter("@PayemntClearDate", SqlDbType.DateTime);
                        param.Value = DBNull.Value;
                        cmd.Parameters.Add(param);
                    }



                    param = new SqlParameter("@Tenure", SqlDbType.Int);
                    if (PackingDelivery.Tenure == "0")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Convert.ToInt32(PackingDelivery.Tenure);
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    if (PackingDelivery.PaymentDueDate.ToString() != "")
                    {
                        string PaymentDueDate = PackingDelivery.PaymentDueDate.ToString().Substring(0, 9);
                        DateTime DatePaymentDueDate = Convert.ToDateTime(PaymentDueDate, Provider);
                        param = new SqlParameter("@PaymentDueDate", SqlDbType.DateTime);
                        param.Value = DatePaymentDueDate;
                        cmd.Parameters.Add(param);
                    }
                    else
                    {

                        param = new SqlParameter("@PaymentDueDate", SqlDbType.DateTime);
                        param.Value = DBNull.Value;
                        cmd.Parameters.Add(param);
                    }



                    param = new SqlParameter("@IsSingle", SqlDbType.NChar);
                    param.Value = PackingDelivery.IsSingle;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    if (PackingDelivery.PaymentReceiveDate.ToString() != "")
                    {
                        string FullPaymentRecDate = PackingDelivery.PaymentReceiveDate.ToString().Substring(0, 9);
                        DateTime DateFullPaymentRecDate = Convert.ToDateTime(FullPaymentRecDate, Provider);
                        param = new SqlParameter("@FullPaymentRecDate", SqlDbType.DateTime);
                        param.Value = DateFullPaymentRecDate;
                        cmd.Parameters.Add(param);
                    }
                    else
                    {

                        param = new SqlParameter("@FullPaymentRecDate", SqlDbType.DateTime);
                        param.Value = DBNull.Value;
                        cmd.Parameters.Add(param);
                    }
                    if (PackingDelivery.BankPaymentRecAmt > 0)
                    {
                        param = new SqlParameter("@FullPaymentRecAmt", SqlDbType.Float);
                        param.Value = PackingDelivery.BankPaymentRecAmt;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    else
                    {
                        param = new SqlParameter("@FullPaymentRecAmt", SqlDbType.Float);
                        param.Value = DBNull.Value;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }


                    param = new SqlParameter("@IsFullPaymentRec", SqlDbType.Bit);
                    param.Value = PackingDelivery.IsFullPaymentCleard;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@OldBankRefNo", SqlDbType.VarChar);
                    param.Value = PackingDelivery.OldBnkRefNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

            }

            return false;
        }
        //public bool UpdateBankRefNo(int ShipemntPkID,string OldBankRefNo,string NewBankRefNo)
        //{
        //    IFormatProvider Provider = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat; //(dd/mm/yyyy)

        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        SqlTransaction transaction = null;

        //        try
        //        {
        //            string cmdText = "Usp_SaveBankRefPaymentDetails";
        //            cnx.Open();

        //            transaction = cnx.BeginTransaction();

        //            SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //            cmd.Transaction = transaction;

        //            SqlParameter param;
        //            param = new SqlParameter("@Flag", SqlDbType.VarChar);
        //            param.Value = "UPDATEBANKREFNO";
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@ShipmentNoID", SqlDbType.Int);
        //            param.Value = ShipemntPkID;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@BankRefNo", SqlDbType.VarChar);
        //            param.Value = NewBankRefNo;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@OldBankRefNo", SqlDbType.VarChar);
        //            param.Value = OldBankRefNo;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);


        //            cmd.ExecuteNonQuery();

        //            transaction.Commit();
        //            return true;
        //        }
        //        catch (SqlException ex)
        //        {
        //            transaction.Rollback();
        //        }

        //    }

        //return false;
        // }

        public List<PackingDelivery> UpdateBankRefNo(int ShipemntPkID, string OldBankRefNo, string NewBankRefNo)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_SaveBankRefPaymentDetails";
                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "UPDATEBANKREFNO";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShipmentNoID", SqlDbType.Int);
                param.Value = ShipemntPkID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BankRefNo", SqlDbType.VarChar);
                param.Value = NewBankRefNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OldBankRefNo", SqlDbType.VarChar);
                param.Value = OldBankRefNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<PackingDelivery> PackingDeliverys = new List<PackingDelivery>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PackingDelivery Invoicepayment = new PackingDelivery();

                        Invoicepayment.PaymentClearDate = Convert.ToDateTime(reader["PayementClearDate"]).ToString() == Convert.ToDateTime("01/01/1900").ToString() ? "" : Convert.ToDateTime(reader["PayementClearDate"]).ToString("dd MMM yy (ddd)");

                        Invoicepayment.PaymentReceiveDate = Convert.ToDateTime(reader["PaymentReceiveOn"]).ToString() == Convert.ToDateTime("01/01/1900").ToString() ? "" : Convert.ToDateTime(reader["PaymentReceiveOn"]).ToString("dd MMM yy (ddd)");

                        Invoicepayment.PaymentDueDate = Convert.ToDateTime(reader["PayemntDueDate"]).ToString() == Convert.ToDateTime("01/01/1900").ToString() ? "" : Convert.ToDateTime(reader["PayemntDueDate"]).ToString("dd MMM yy (ddd)");

                        if ((reader["Tenure"]).ToString() == "0" || (reader["Tenure"] == DBNull.Value))
                        {
                            Invoicepayment.Tenure = "";
                        }
                        else
                        {
                            Invoicepayment.Tenure = Convert.ToString(reader["Tenure"]);
                        }

                        //Invoicepayment.PaymentClearDate = (reader["PayementClearDate"]) == DBNull.Value||(reader["PayementClearDate"]).ToString()=='1900-01-01') ? string.Empty : Convert.ToDateTime(reader["PayementClearDate"]).ToString("dd MMM yy (ddd)");
                        //Invoicepayment.Tenure = (reader["Tenure"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Tenure"]);
                        //Invoicepayment.PaymentReceiveDate = (reader["PaymentReceiveOn"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentReceiveOn"]).ToString("dd MMM yy (ddd)");
                        //Invoicepayment.PaymentDueDate = (reader["PaymentDueDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentDueDate"]).ToString("dd MMM yy (ddd)");
                        PackingDeliverys.Add(Invoicepayment);
                    }
                }
                cnx.Close();
                return PackingDeliverys;
            }




        }
        public DataTable UpdateBankRefNoDetails(string OldBankRefNo)
        {
            IFormatProvider Provider = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat; //(dd/mm/yyyy)
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;


                string cmdText = "Usp_SaveBankRefPaymentDetails";
                cnx.Open();

                transaction = cnx.BeginTransaction();

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.Transaction = transaction;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "GETBNK";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@OldBankRefNo", SqlDbType.VarChar);
                param.Value = OldBankRefNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
            }

            return dt;
        }
        public DataTable GetInvoiceShippedValue(string Flag, int OrderDetailID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetInvoiceDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "SHIPPEDVALUE";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

            }

            return dt;
        }
        public DataTable ValidateinvoiceNo(string Flag, string invoiceNo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetPackingDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@InvoiceNo", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = invoiceNo;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

            }

            return dt;
        }
        public DataTable GetSerialNumber(string Flag, string ShipmentNo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetInvoiceDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShipmentNo", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = ShipmentNo;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

            }

            return dt;
        }

        //Pending Payment Report abhishek 22 sep 17===============================//
        //public List<PackingDelivery> GetBankPaymentReport(string Flag, string bankrefNo, string IsAction, string SearchText)
        //{


        //  using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //  {
        //    cnx.Open();
        //    SqlDataReader reader;
        //    SqlCommand cmd;
        //    string cmdText;

        //    cmdText = "Usp_GetInvoiceDetails";

        //    cmd = new SqlCommand(cmdText, cnx);

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //    SqlParameter param;

        //    param = new SqlParameter("@Flag", SqlDbType.VarChar);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = Flag;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@BankRefNos", SqlDbType.VarChar);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = bankrefNo;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@IsAction", SqlDbType.NChar);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = IsAction;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@SearchText", SqlDbType.VarChar);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = SearchText;
        //    cmd.Parameters.Add(param);

        //    reader = cmd.ExecuteReader();
        //    List<PackingDelivery> PackingDeliverys = new List<PackingDelivery>();
        //    if (reader.HasRows)
        //    {
        //      while (reader.Read())
        //      {
        //        PackingDelivery Invoicepayment = new PackingDelivery();

        //        Invoicepayment.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
        //        Invoicepayment.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
        //        Invoicepayment.InvoiceNumber = (reader["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["InvoiceNumber"]);
        //        Invoicepayment.InvoiceDate = (reader["InvoiceDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["InvoiceDate"]).ToString("dd MMM yy (ddd)");
        //        Invoicepayment.SBno = (reader["SBNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SBNumber"]);
        //        Invoicepayment.SBDate = (reader["SBDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["SBDate"]).ToString("dd MMM yy (ddd)");
        //        Invoicepayment.ConvertTO = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);
        //        Invoicepayment.InvoiceAmount = (reader["InvoiceAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["InvoiceAmt"]);
        //        Invoicepayment.ShippingNo = (reader["ShipmentNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ShipmentNo"]);
        //        Invoicepayment.TotalBEAmount = (reader["TotalAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TotalAmt"]);
        //        Invoicepayment.BankRefNumber = (reader["BankRefNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BankRefNo"]);
        //        Invoicepayment.PaymentReceiveDate = (reader["PaymentReceivedOn"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentReceivedOn"]).ToString("dd MMM yy (ddd)");
        //        Invoicepayment.OrderDetailsID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
        //        Invoicepayment.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
        //        Invoicepayment.PaymentDueDate = (reader["PaymentDueDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentDueDate"]).ToString("dd MMM yy (ddd)");
        //        Invoicepayment.BankRefNoCount = (reader["Counts"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Counts"]);
        //        Invoicepayment.PaymentClearDate = (reader["PaymentCleareddate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentCleareddate"]).ToString("dd MMM yy (ddd)");
        //        Invoicepayment.Tenure = (reader["Tenure"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Tenure"]);
        //        Invoicepayment.BankRefID = (reader["BnkRefID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["BnkRefID"]);
        //        Invoicepayment.IsSingle = (reader["IsSingle"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["IsSingle"]);
        //        Invoicepayment.BankPaymentRecAmt = (reader["BnkPayemntRecAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BnkPayemntRecAmt"]);
        //        Invoicepayment.IsFullPaymentCleard = (reader["IsPaymentCleared"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsPaymentCleared"]);
        //        Invoicepayment.ShipmentNo__PkID = (reader["ShipmentNo__PkID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ShipmentNo__PkID"]);
        //        Invoicepayment.IsAction = (reader["IsAction"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["IsAction"]);
        //        Invoicepayment.BankPendingAmt = (reader["PedningBeAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PedningBeAmt"]);
        //        PackingDeliverys.Add(Invoicepayment);


        //      }
        //    }
        //    cnx.Close();
        //    return PackingDeliverys;

        //  }


        //}
        //end



    }
}
