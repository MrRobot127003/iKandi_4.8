using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.BLL
{
    public class InvoiceController : BaseController
    {
        #region Ctors

        public InvoiceController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<InvoiceOrder> GetIKandiInvoiceOrders(int PageSize, int PageIndex, out int TotalRowCount, int ClientID, DateTime FromDate, DateTime ToDate, string SearchText)
        {
            return this.InvoiceDataProviderInstance.GetIKandiInvoiceOrders(PageSize, PageIndex, out TotalRowCount, ClientID, FromDate, ToDate, SearchText);
        }

        public List<InvoiceOrder> GetBIPLInvoiceOrders(int ClientID, DateTime FromDate, DateTime ToDate, string BoutiqueInvoiceSearch, string BoutiqueBillingSearch,int BuyerId,int BuyerId2)
        {
            return this.InvoiceDataProviderInstance.GetBIPLInvoiceOrders(ClientID, FromDate, ToDate, BoutiqueInvoiceSearch, BoutiqueBillingSearch, BuyerId, BuyerId2);
        }
        public List<InvoiceOrder> GetIkandiInvoicesBIPLInvoiceOrders(int ClientID, DateTime FromDate, DateTime ToDate,int StatusModesID)
        {
            return this.InvoiceDataProviderInstance.GetIkandiInvoicesBIPLInvoiceOrders(ClientID, FromDate, ToDate, StatusModesID);
        }

        public void SaveBoutiqueBilling(BoutiqueBilling BB)
        {
            this.InvoiceDataProviderInstance.SaveBoutiqueBilling(BB);

            if (BB.BillingOrders[0].InvoiceID > 0 && BB.PaymentReceivedDate == DateTime.MinValue && BB.PaymentReceivedAmount >= 0)
                return;

            try
            {
                //DataTable dt = this.InvoiceDataProviderInstance.GetInvoiceOrders(BB.BillingOrders[0].InvoiceID);
                DataTable dt = this.InvoiceDataProviderInstance.GetBiplInvoiceOrders(BB.BoutiqueBillingID);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["OrderDetailID"] != DBNull.Value)
                        {
                            int orderDetailID = Convert.ToInt32(row["OrderDetailID"]);

                            if (row["Code"] != DBNull.Value)
                            {
                                string mode = row["Code"].ToString();

                                if (mode.ToUpper().IndexOf("D") > -1)
                                {
                                    // Update workflow
                                    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailID);

                                    if (instance.WorkflowInstanceID > 0)
                                    {
                                        List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

                                        if (tasks.Count > 0)
                                        {
                                            foreach (WorkflowInstanceDetail task in tasks)
                                            {
                                                this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void DeleteBoutiqueBilling(int BoutiqueBillingID, int InvoiceID)
        {
            this.InvoiceDataProviderInstance.DeleteBoutiqueBilling(BoutiqueBillingID, InvoiceID);
        }

        public void SetInvoiceEntrySingle(int BoutiqueBillingID,string IsChecked)
        {
            this.InvoiceDataProviderInstance.SetInvoiceEntrySingle(BoutiqueBillingID, IsChecked);
        }
        public void UpdateInvoicePayment(Invoice InvoiceData)
        {

            this.InvoiceDataProviderInstance.UpdateInvoicePayment(InvoiceData);

            if (InvoiceData.InvoiceID > 0 && InvoiceData.PaymentReceivedDate == DateTime.MinValue && InvoiceData.PaymentReceivedAmount > 0)
                return;

            try
            {
                DataTable dt = this.InvoiceDataProviderInstance.GetInvoiceOrders(InvoiceData.InvoiceID);

                foreach (DataRow row in dt.Rows)
                {
                    int orderDetailID = Convert.ToInt32(row["OrderDetailID"]);

                    // Update workflow
                    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailID);

                    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    foreach (WorkflowInstanceDetail task in tasks)
                    {
                        this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public DataTable GetInvoiceOrders(int InvoiceID)
        {
            return this.InvoiceDataProviderInstance.GetInvoiceOrders(InvoiceID);
        }

        public Packing GetPackingCollection(int orderId, int packingId, int productionUnitManagerId)
        {
            return this.InvoiceDataProviderInstance.GetPackingCollection(orderId, packingId, productionUnitManagerId);
        }

        public bool SavePacking(Packing objPacking)
        {
            bool success = this.DeliveryDataProviderInstance.SavePacking(objPacking);

            return success;
        }

     


        public List<Invoice> GetBiplInvoiceDataByInvoiceID(int InvoiceID)
        {
            return this.InvoiceDataProviderInstance.GetBiplInvoiceDataByInvoiceID(InvoiceID);
        }

   


        public Invoice GetIkandiInvoiceDataByInvoiceId(int InvoiceID, int InvoiceType)
        {
            return this.InvoiceDataProviderInstance.GetIkandiInvoiceDataByInvoiceId(InvoiceID, InvoiceType);
        }

        public DataTable GetProductionPlanningIdByOrderDetailID(int OrderDetailID)
        {
            return this.InvoiceDataProviderInstance.GetProductionPlanningIdByOrderDetailID(OrderDetailID);
        }

        public Boolean GetIsValidInvoiceNumber(string InvoiceNumber)
        {
            return this.InvoiceDataProviderInstance.GetIsValidInvoiceNumber(InvoiceNumber);
        }

        public Boolean SetIkandiInvoiceVisible(int InvoiceId, string Details )
        {
            return this.InvoiceDataProviderInstance.SetIkandiInvoiceVisible(InvoiceId, Details);
        }

        public DateTime GetDeliveredDateByInvoiceID(int InvoiceID)
        {
            return this.InvoiceDataProviderInstance.GetDeliveredDateByInvoiceID(InvoiceID);
        }
        //added by abhishek on 4/8/2017

        public DataSet GetPackingInvoiceDetails(string Flag, int OrderID, int OrderDetailID)
        {
            return this.InvoiceDataProviderInstance.GetPackingInvoiceDetails(Flag,OrderID,OrderDetailID);
        }
        public bool UpdatePackingList(PackingDelivery PackingDelivery, string Flags)
        {
            return this.InvoiceDataProviderInstance.UpdatePackingList(PackingDelivery, Flags);
        }
        public DataSet GetPackingShippingNo(string Flag, int OrderDetailID)
        {
            return this.InvoiceDataProviderInstance.GetPackingShippingNo(Flag, OrderDetailID);
        }
        public bool UpdateConsolidation(PackingDelivery PackingDelivery)
        {
            return this.InvoiceDataProviderInstance.UpdateConsolidation(PackingDelivery);
        }
        public bool AddShippingNumber(PackingDelivery PackingDelivery, out int NewShippingID)
        {
            return this.InvoiceDataProviderInstance.AddShippingNumber(PackingDelivery, out NewShippingID);
        }
        public DataSet GetPackingDetailsByShippingNo(string Flag, int OrderID, int OrderDetailID, string ShippingNo, int shippingID, string SaerchText)
        {
            return this.InvoiceDataProviderInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, ShippingNo, shippingID,SaerchText);
        }
        public bool UpdateInvoice(PackingDelivery PackingDelivery)
        {
            return this.InvoiceDataProviderInstance.UpdateInvoice(PackingDelivery);
        }
        public List<PackingDelivery> GetBIPLInvoiceDetails(string Flag, string bankrefNo, string IsAction,string SearchText)
        {
            return this.InvoiceDataProviderInstance.GetBIPLInvoiceDetails(Flag, bankrefNo, IsAction, SearchText);
        }
        public DataSet GetBankRefNoForGrouping(string Flag, int ClientCurrency)
        {
            return this.InvoiceDataProviderInstance.GetBankRefNoForGrouping(Flag,ClientCurrency);
        }
        public bool UpdateInvoiceIsSingle(string BankRefNo, int BankRefID, string IsSingle)
        {
            return this.InvoiceDataProviderInstance.UpdateInvoiceIsSingle(BankRefNo, BankRefID,IsSingle);
        }
        public bool UpdateInvoiceBankPayment(PackingDelivery PackingDelivery)
        {
            return this.InvoiceDataProviderInstance.UpdateInvoiceBankPayment(PackingDelivery);
        }
        public List<PackingDelivery> UpdateBankRefNo(int ShipemntPkID, string OldBankRefNo, string NewBankRefNo)
        {
          return this.InvoiceDataProviderInstance.UpdateBankRefNo(ShipemntPkID, OldBankRefNo, NewBankRefNo);
        }
        public DataTable GetInvoiceShippedValue(string Flag, int OrderDetailID)
        {
            return this.InvoiceDataProviderInstance.GetInvoiceShippedValue(Flag, OrderDetailID);
        }
        public DataTable ValidateinvoiceNo(string Flag, string invoiceNo)
        {
            return this.InvoiceDataProviderInstance.ValidateinvoiceNo(Flag, invoiceNo);
        }
        public DataTable GetSerialNumber(string Flag, string ShipmentNo)
        {
            return this.InvoiceDataProviderInstance.GetSerialNumber(Flag, ShipmentNo);
        }
        public DataTable UpdateBankRefNoDetails(string OldBankRefNo)
        {
          return this.InvoiceDataProviderInstance.UpdateBankRefNoDetails(OldBankRefNo);
        }
      

    }

}
