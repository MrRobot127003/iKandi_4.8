using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;
using System.Web;

namespace iKandi.DAL
{
    public class LiabilityDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public LiabilityDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Get Methods

        public Liability GetLiability(int orderDetailID, int LiabilityID)
        {
            Liability liability = new Liability();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_liability_accessory_get_liability_accessory";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LiabilityID", SqlDbType.Int);
                    param.Value = LiabilityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsLiability = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsLiability);

                    if (dsLiability.Tables.Count > 0)
                    {
                        liability = ConvertDataSetToLiabilityBasic(dsLiability);
                    }
                    else
                    {

                        liability.OrderDetail = new OrderDetail();
                        liability.OrderDetail.OrderDetailID = 0;
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return liability;
        }

        private Liability ConvertDataSetToLiabilityBasic(DataSet dsLiability)
        {
            Liability liability = new Liability();
            liability.OrderDetail = new OrderDetail();
            liability.AccessoryLiability = new List<LiabilityAccessory>();

            DataTable dt = dsLiability.Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row1 in dt.Rows)
                {
                    LiabilityAccessory liabilityAccessory = new LiabilityAccessory();
                    liabilityAccessory.AccessoryWorkingDetail = new AccessoryWorkingDetail();

                    liabilityAccessory.AccessoryWorkingDetail.Quantity = (row1["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["Quantity"]);
                    liabilityAccessory.AccessoryWorkingDetail.TotalQuantity = (row1["TotalQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["TotalQuantity"]);
                    liabilityAccessory.AccessoryWorkingDetail.Id = (row1["AccessoryWorkingDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["AccessoryWorkingDetailID"]);
                    liabilityAccessory.AccessoryWorkingDetail.AccessoryName = (row1["AccessoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["AccessoryName"]);
                    liabilityAccessory.Amount = (row1["Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Amount"]);
                    liabilityAccessory.Id = 0;
                    liability.AccessoryLiability.Add(liabilityAccessory);
                }
            }

            dt = dsLiability.Tables[1];
            if (dt.Rows.Count > 0)
            {
                DataRow row2 = dt.Rows[0];
                liability.Fabric1Length = (row2["Fabric1Length"] == DBNull.Value) ? 0 : Convert.ToDouble(row2["Fabric1Length"]);
            }
            else
                liability.Fabric1Length = 0;

            dt = dsLiability.Tables[2];
            if (dt.Rows.Count > 0)
            {
                DataRow row3 = dt.Rows[0];
                liability.Fabric2Length = (row3["Fabric2Length"] == DBNull.Value) ? 0 : Convert.ToDouble(row3["Fabric2Length"]);
            }
            else
                liability.Fabric2Length = 0;

            dt = dsLiability.Tables[3];
            if (dt.Rows.Count > 0)
            {
                DataRow row4 = dt.Rows[0];
                liability.Fabric3Length = (row4["Fabric3Length"] == DBNull.Value) ? 0 : Convert.ToDouble(row4["Fabric3Length"]);
            }
            else
                liability.Fabric3Length = 0;

            dt = dsLiability.Tables[4];
            if (dt.Rows.Count > 0)
            {                
                DataRow row5 = dt.Rows[0];
                liability.Fabric4Length = (row5["Fabric4Length"] == DBNull.Value) ? 0 : Convert.ToDouble(row5["Fabric4Length"]);
            }
            else
                liability.Fabric4Length = 0;

            dt = dsLiability.Tables[5];
            if (dt.Rows.Count > 0)
            {
                DataRow row6 = dt.Rows[0];
                liability.OrderDetail.OrderDetailID = (row6["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(row6["OrderDetailID"]);
            }
            else
                liability.OrderDetail.OrderDetailID = 0;  
          



            return liability;
        }

        public Liability GetLiabilityData(int orderDetailID, int LiabilityID)
        {
            Liability liability = new Liability();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_liability_get_liability_by_order_detail_id";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LiabilityID", SqlDbType.Int);
                    param.Value = LiabilityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsLiability = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsLiability);

                    if (dsLiability.Tables[0].Rows.Count > 0)
                    {
                        liability = ConvertDataSetToLiability(dsLiability);
                    }
                    else
                    {
                        liability.OrderDetail = new OrderDetail();
                        liability.OrderDetail.OrderDetailID = 0;
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return liability;
        }

        private Liability ConvertDataSetToLiability(DataSet dsLiability)
        {
            Liability liability = new Liability();
            liability.OrderDetail = new OrderDetail();
            DataTable dt = dsLiability.Tables[0];

            DataRow row1 = dt.Rows[0];
            liability.OrderDetail.OrderDetailID = (row1["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["OrderDetailID"]);
            liability.DateCancelled = (row1["DateCancelled"] == DBNull.Value || row1["DateCancelled"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["DateCancelled"]);
            liability.QuantityCancelled = (row1["QuantityCancelled"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["QuantityCancelled"]);
            liability.Fabric1Price = (row1["Fabric1Price"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Price"]);
            liability.Fabric2Price = (row1["Fabric2Price"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Price"]);
            liability.Fabric3Price = (row1["Fabric3Price"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Price"]);
            liability.Fabric4Price = (row1["Fabric4Price"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Price"]);           
            liability.Fabric1Quantity = (row1["Fabric1Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Quantity"]);
            liability.Fabric2Quantity = (row1["Fabric2Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Quantity"]);
            liability.Fabric3Quantity = (row1["Fabric3Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Quantity"]);
            liability.Fabric4Quantity = (row1["Fabric4Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Quantity"]);
            liability.InvoiceDate = (row1["InvoiceDate"] == DBNull.Value || row1["InvoiceDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["InvoiceDate"]);
            liability.Owner = (row1["Owner"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Owner"]);
            liability.PaymentStatus = (row1["PaymentStatus"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PaymentStatus"]);
            liability.MerchantRemarks = (row1["MerchantRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["MerchantRemarks"]);
            liability.DocumentationRemarks = (row1["DocumentationRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["DocumentationRemarks"]);
            liability.CancellationCost = (row1["CancellationCost"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["CancellationCost"]);
            liability.Id = (row1["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["Id"]);
            liability.InvoiceNumber = (row1["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["InvoiceNumber"]);
            liability.HoldTillDate = (row1["HoldTillDate"] == DBNull.Value || row1["HoldTillDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["HoldTillDate"]);
            liability.LiabilityDocuments = (row1["LiabilityDocuments"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["LiabilityDocuments"]);
            liability.RaiseCustomerInvoice = (row1["RaiseCustomerInvoice"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["RaiseCustomerInvoice"]);
            liability.AcceptanceToSettle = (row1["AcceptanceToSettle"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["AcceptanceToSettle"]);
            liability.IkandiAcknowledge = (row1["IkandiAcknowledge"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["IkandiAcknowledge"]);
            liability.AcknowledgementDate = (row1["AcknowledgementDate"] == DBNull.Value || row1["AcknowledgementDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["AcknowledgementDate"]);
            liability.SettlementDate = (row1["SettlementDate"] == DBNull.Value || row1["SettlementDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["SettlementDate"]);
            liability.InvoiceRaisedDate = (row1["InvoiceRaisedDate"] == DBNull.Value || row1["InvoiceRaisedDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["InvoiceRaisedDate"]);
            liability.LiabilityNumber = (row1["LiabilityNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["LiabilityNumber"]);

            dt = dsLiability.Tables[1];
            liability.AccessoryLiability = new List<LiabilityAccessory>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LiabilityAccessory liabilityAccessory = new LiabilityAccessory();
                    liabilityAccessory.AccessoryWorkingDetail = new AccessoryWorkingDetail();
                    liabilityAccessory.AccessoryWorkingDetail.Id = (dr["AccessoryWorkingDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["AccessoryWorkingDetailID"]);
                    liabilityAccessory.Amount = (dr["Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Amount"]);
                    liabilityAccessory.LiabilityID = (dr["LiabilityID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["LiabilityID"]);
                    liabilityAccessory.AccessoryWorkingDetail.AccessoryName = (dr["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["AccessoryName"]);
                    liabilityAccessory.AccessoryWorkingDetail.Quantity = (dr["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["Quantity"]);
                    liabilityAccessory.AccessoryWorkingDetail.TotalQuantity = (dr["TotalQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TotalQuantity"]);
                    liabilityAccessory.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                    liability.AccessoryLiability.Add(liabilityAccessory);
                }
            }

            dt = dsLiability.Tables[2];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    liability.Fabric1Average = (row["Fabric1Average"] == DBNull.Value) ? 0 : Convert.ToDouble(row["Fabric1Average"]);
                    liability.Fabric2Average = (row["Fabric2Average"] == DBNull.Value) ? 0 : Convert.ToDouble(row["Fabric2Average"]);
                    liability.Fabric3Average = (row["Fabric3Average"] == DBNull.Value) ? 0 : Convert.ToDouble(row["Fabric3Average"]);
                    liability.Fabric4Average = (row["Fabric4Average"] == DBNull.Value) ? 0 : Convert.ToDouble(row["Fabric4Average"]);
                }
            }

            return liability;
        }

        public System.Data.DataSet GetLiabilityReport(int PageSize, int PageIndex, out int TotalRowCount, int PaymentStatus, DateTime FromDate, DateTime ToDate, int Year,int ClientId,string StrSearch)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_liability";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

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

                param = new SqlParameter("@PaymentStatus", SqlDbType.Int);
                param.Value = PaymentStatus;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
                //if (FromDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = FromDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
               // if (ToDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = ToDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StrSearch", SqlDbType.VarChar);
                param.Value = StrSearch;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsLiability = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsLiability);

                cnx.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return dsLiability;
            }
        }

        public int GetOrderDetailIDByContractNumber(string ContractNumber)
        {
            int result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_order_detail_get_orderdetailid_by_contractNumber";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ContractNumber", SqlDbType.VarChar);
                param.Value = ContractNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = Convert.ToInt32(cmd.ExecuteScalar());

                cnx.Close();

            }
            return result;

        }




        public int GetAccessoryTotalDAL(int intLiabilityID)
        {
            int result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_GetAccossryTotal";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@LiabilityID", SqlDbType.VarChar);
                param.Value = intLiabilityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = Convert.ToInt32(cmd.ExecuteScalar());

                cnx.Close();

            }
            return result;

        }


        public string GetNewLiabilityNumber()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_liability_get_new_liability_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                object obj = cmd.ExecuteScalar();
                string liabilityNumber = "";

                if (obj != DBNull.Value && obj != null)
                    liabilityNumber = (obj).ToString();

                return liabilityNumber;
            }
        }

        #endregion

        #region Insertion Methods

        public bool InsertLiability(Liability liability)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_liability_insert_liability";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@CurrentStatusId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Convert.ToInt32(StatusMode.CANCELLED);
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = LoggedInUser.UserData.UserID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActionId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Convert.ToInt32(WorkflowStatusActionID.Cancel);
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = liability.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateCancelled", SqlDbType.DateTime);
                    if ((liability.DateCancelled == DateTime.MinValue) || (liability.DateCancelled == Convert.ToDateTime("1753-01-01")) || (liability.DateCancelled == Convert.ToDateTime("1900-01-01")))
                    //if (liability.DateCancelled == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.DateCancelled;
                    }                         
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QuantityCancelled", SqlDbType.Int);
                    param.Value = liability.QuantityCancelled;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
                    if ((liability.InvoiceDate == DateTime.MinValue) || (liability.InvoiceDate == Convert.ToDateTime("1753-01-01")) || (liability.InvoiceDate == Convert.ToDateTime("1900-01-01")))
                   // if (liability.InvoiceDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.InvoiceDate;
                    }                        
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Owner", SqlDbType.VarChar);
                    param.Value = liability.Owner;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PaymentStatus", SqlDbType.Int);
                    param.Value = liability.PaymentStatus;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MerchantRemarks", SqlDbType.VarChar);
                    param.Value = liability.MerchantRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DocumentationRemarks", SqlDbType.VarChar);
                    param.Value = liability.DocumentationRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Price", SqlDbType.Float);
                    param.Value = liability.Fabric1Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Price", SqlDbType.Float);
                    param.Value = liability.Fabric2Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Price", SqlDbType.Float);
                    param.Value = liability.Fabric3Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Price", SqlDbType.Float);
                    param.Value = liability.Fabric4Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric1Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric2Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric3Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric4Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CancellationCost", SqlDbType.Float);
                    param.Value = liability.CancellationCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceNumber", SqlDbType.VarChar);
                    param.Value = liability.InvoiceNumber == null ? "" : liability.InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LiabilityDocuments", SqlDbType.VarChar);
                    param.Value = liability.LiabilityDocuments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HoldTillDate", SqlDbType.DateTime);
                    if ((liability.HoldTillDate == DateTime.MinValue) || (liability.HoldTillDate == Convert.ToDateTime("1753-01-01")) || (liability.HoldTillDate == Convert.ToDateTime("1900-01-01")))
                   // if (liability.HoldTillDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.HoldTillDate;
                    } 
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RaiseCustomerInvoice", SqlDbType.Bit);
                    param.Value = liability.RaiseCustomerInvoice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@kandiAcknowledge", SqlDbType.Bit);
                    param.Value = liability.IkandiAcknowledge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AcceptanceToSettle", SqlDbType.Bit);
                    param.Value = liability.AcceptanceToSettle;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AcknowledgementDate", SqlDbType.DateTime);
                    //if (liability.AcknowledgementDate == DateTime.MinValue)
                        if ((liability.AcknowledgementDate == DateTime.MinValue) || (liability.AcknowledgementDate == Convert.ToDateTime("1753-01-01")) || (liability.AcknowledgementDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.AcknowledgementDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SettlementDate", SqlDbType.DateTime);
                    //if (liability.SettlementDate == DateTime.MinValue)
                        if ((liability.SettlementDate == DateTime.MinValue) || (liability.SettlementDate == Convert.ToDateTime("1753-01-01")) || (liability.SettlementDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.SettlementDate;
                    }  
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceRaisedDate", SqlDbType.DateTime);
                    if ((liability.InvoiceRaisedDate == DateTime.MinValue) || (liability.InvoiceRaisedDate == Convert.ToDateTime("1753-01-01")) || (liability.InvoiceRaisedDate == Convert.ToDateTime("1900-01-01")))
                  //  if (liability.InvoiceRaisedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.InvoiceRaisedDate;
                    }                         
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LiabilityNumber", SqlDbType.VarChar);
                    param.Value = liability.LiabilityNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    int liabilityID = Convert.ToInt32(outParam.Value);

                    if (liabilityID == -1)
                        return false;

                    liability.Id = liabilityID;

                    if (liability.AccessoryLiability != null && liability.AccessoryLiability.Count > 0)
                        foreach (LiabilityAccessory liabilityAccessory in liability.AccessoryLiability)
                        {
                            if (liabilityAccessory.Id == -1)
                            {
                                liabilityAccessory.LiabilityID = liability.Id;
                                int liabilityAccessoryId = InsertLiabilityAccessory(liabilityAccessory, cnx, transaction);
                                liabilityAccessory.Id = liabilityAccessoryId;
                            }
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
            }

            return false;
        }

        public int InsertLiabilityAccessory(LiabilityAccessory liabilityAccessory, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_liability_accessory_insert_liability_accessory";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@d", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@AccessoryWorkingDetailID", SqlDbType.Int);
            param.Value = liabilityAccessory.AccessoryWorkingDetail.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Float);
            param.Value = liabilityAccessory.Amount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = liabilityAccessory.TotalQuantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LiabilityID", SqlDbType.Int);
            param.Value = liabilityAccessory.LiabilityID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int liabilityAccessoryId = Convert.ToInt32(outParam.Value);

            return liabilityAccessoryId;

        }

        public bool InsertLiabilityMerchantRemarks(int OrderDetailID, string Remarks, int Option)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_liability_create_liability_from_merchant_remarks";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = Remarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CurrentStatusId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Convert.ToInt32(TaskMode.CANCELLED);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = LoggedInUser.UserData.UserID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActionId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Convert.ToInt32(WorkflowStatusActionID.Cancel);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Option", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Option;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }

        #endregion

        #region Updation Methods

        public bool UpdateLiability(Liability liability)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_liability_update_liability";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Update);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;

                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Value = liability.Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    //param.Value = liability.OrderDetail.OrderDetailID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateCancelled", SqlDbType.DateTime);
                    if ((liability.DateCancelled == DateTime.MinValue) || (liability.DateCancelled == Convert.ToDateTime("1753-01-01")) || (liability.DateCancelled == Convert.ToDateTime("1900-01-01")))
                   // if (liability.DateCancelled == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.DateCancelled;
                    }                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QuantityCancelled", SqlDbType.Int);
                    param.Value = liability.QuantityCancelled;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
                    if ((liability.InvoiceDate == DateTime.MinValue) || (liability.InvoiceDate == Convert.ToDateTime("1753-01-01")) || (liability.InvoiceDate == Convert.ToDateTime("1900-01-01")))
                   // if (liability.InvoiceDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.InvoiceDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Owner", SqlDbType.VarChar);
                    param.Value = liability.Owner;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PaymentStatus", SqlDbType.Int);
                    param.Value = liability.PaymentStatus;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MerchantRemarks", SqlDbType.VarChar);
                    param.Value = liability.MerchantRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DocumentationRemarks", SqlDbType.VarChar);
                    param.Value = liability.DocumentationRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CancellationCost", SqlDbType.Float);
                    param.Value = liability.CancellationCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Price", SqlDbType.Float);
                    param.Value = liability.Fabric1Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Price", SqlDbType.Float);
                    param.Value = liability.Fabric2Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Price", SqlDbType.Float);
                    param.Value = liability.Fabric3Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Price", SqlDbType.Float);
                    param.Value = liability.Fabric4Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric1Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric2Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric3Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Quantity", SqlDbType.Float);
                    param.Value = liability.Fabric4Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceNumber", SqlDbType.VarChar);
                    param.Value = liability.InvoiceNumber == null ? "" : liability.InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LiabilityDocuments", SqlDbType.VarChar);
                    param.Value = liability.LiabilityDocuments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HoldTillDate", SqlDbType.DateTime);
                    if ((liability.HoldTillDate == DateTime.MinValue) || (liability.HoldTillDate == Convert.ToDateTime("1753-01-01")) || (liability.HoldTillDate == Convert.ToDateTime("1900-01-01")))
                   // if (liability.HoldTillDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.HoldTillDate;
                    }                    
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RaiseCustomerInvoice", SqlDbType.Bit);
                    param.Value = liability.RaiseCustomerInvoice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@kandiAcknowledge", SqlDbType.Bit);
                    param.Value = liability.IkandiAcknowledge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AcceptanceToSettle", SqlDbType.Bit);
                    param.Value = liability.AcceptanceToSettle;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AcknowledgementDate", SqlDbType.DateTime);
                    if ((liability.AcknowledgementDate == DateTime.MinValue) || (liability.AcknowledgementDate == Convert.ToDateTime("1753-01-01")) || (liability.AcknowledgementDate == Convert.ToDateTime("1900-01-01")))
                  //  if (liability.AcknowledgementDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.AcknowledgementDate;
                    }                    
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SettlementDate", SqlDbType.DateTime);
                    if ((liability.SettlementDate == DateTime.MinValue) || (liability.SettlementDate == Convert.ToDateTime("1753-01-01")) || (liability.SettlementDate == Convert.ToDateTime("1900-01-01")))
                    //if (liability.SettlementDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.SettlementDate;
                    }                    
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceRaisedDate", SqlDbType.DateTime);
                    if ((liability.InvoiceRaisedDate == DateTime.MinValue) || (liability.InvoiceRaisedDate == Convert.ToDateTime("1753-01-01")) || (liability.InvoiceRaisedDate == Convert.ToDateTime("1900-01-01")))
                   // if (liability.InvoiceRaisedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = liability.InvoiceRaisedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LiabilityNumber", SqlDbType.VarChar);
                    param.Value = liability.LiabilityNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    foreach (LiabilityAccessory liabilityAccessory in liability.AccessoryLiability)
                    {
                        if (liabilityAccessory.Id != -1)
                        {
                            UpdateLiabilityAccessory(liabilityAccessory, cnx, transaction);
                        }
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
            }

            return false;
        }

        public bool UpdateLiabilityAccessory(LiabilityAccessory liabilityAccessory, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_liability_accessory_update_liability_accessory";

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@d", SqlDbType.Int);
            param.Value = liabilityAccessory.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoryWorkingDetailID", SqlDbType.Int);
            param.Value = liabilityAccessory.AccessoryWorkingDetail.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Float);
            param.Value = liabilityAccessory.Amount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = liabilityAccessory.TotalQuantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LiabilityID", SqlDbType.Int);
            param.Value = liabilityAccessory.LiabilityID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }




        public void UpdateAvgLiabilityDAL(string Avg1, string Avg2, string Avg3, string Avg4,int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
               

                
                    string cmdText = "sp_liability_update_avg_liability";
                    cnx.Open();


                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@Avg1", SqlDbType.VarChar);
                    param.Value = Avg1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Avg2", SqlDbType.VarChar);
                    param.Value = Avg2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Avg3", SqlDbType.VarChar);
                    param.Value = Avg3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Avg4", SqlDbType.VarChar);
                    param.Value = Avg4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Value = Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();

               
               
            }

           
        }



        #endregion

       
    }
}
