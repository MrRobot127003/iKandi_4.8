using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class PODataProvider : BaseDataProvider
    {
        #region Ctor(s)
        public PODataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }
        #endregion

        public PO GetPOByID(int POID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_po_by_id";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@POID", SqlDbType.Int);
                param.Value = POID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                PO currentPO = new PO();

                while (reader.Read())
                {
                    currentPO.POID = Convert.ToInt32(reader["id"]);
                    currentPO.PONumber = (reader["PONumber"]).ToString();
                    currentPO.PODate = reader["PODate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PODate"]);
                    currentPO.POType = reader["POType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["POType"]);
                    currentPO.QTY = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Quantity"]);
                    currentPO.Rate = reader["Rate"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Rate"]);
                    currentPO.Unit = reader["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Unit"]);
                    currentPO.CurrencyUnit = reader["CurrencyUnit"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CurrencyUnit"]);
                    currentPO.RecievedQty = reader["ReceivedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["ReceivedQty"]);
                    currentPO.RejectedQty = reader["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["RejectedQty"]);
                    currentPO.Shrinkage = reader["Shrinkage"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Shrinkage"]);
                    currentPO.IsActive = reader["IsActive"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IsActive"]);
                    currentPO.CreatedDate = reader["CreatedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                    currentPO.MasterPO = new MasterPO();
                    currentPO.MasterPO.MasterPOID = Convert.ToInt32(reader["MasterPOID"]);
                    currentPO.MasterPO.Client = new Client();
                    currentPO.MasterPO.Client.ClientID = Convert.ToInt32(reader["ClientID"]);

                    currentPO.MasterPO.Fabric = new POFabExt();
                    currentPO.MasterPO.Fabric.TradeName = reader["FabricName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FabricName"]);
                    currentPO.MasterPO.Fabric.Width = reader["Width"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Width"]);
                    currentPO.MasterPO.Fabric.Composition = reader["Composition"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Composition"]);
                    currentPO.MasterPO.Fabric.CountConstruction = reader["cc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["cc"]);
                    currentPO.MasterPO.Fabric.HandFeel = reader["handfeel"] == DBNull.Value ? string.Empty : Convert.ToString(reader["handfeel"]);
                    currentPO.MasterPO.Fabric.GSM = reader["gsm"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["gsm"]);
                    currentPO.MasterPO.Fabric.Shrinkage = reader["shrinkage_percent"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["shrinkage_percent"]);
                    currentPO.MasterPO.PrintName = reader["PrintColor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PrintColor"]);

                    currentPO.Process = new POProcess();
                    currentPO.Process.ProcessID = Convert.ToInt32(reader["ProcessID"]);
                    currentPO.Process.ProcessName = Convert.ToString(reader["ProcessName"]);
                    currentPO.Supplier = new Supplier();
                    currentPO.Supplier.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    currentPO.Supplier.SupplierName = reader["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SupplierName"]);
                    currentPO.Supplier.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    currentPO.Supplier.PaymentTerms = reader["PaymentTerms"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PaymentTerms"]);
                }


                reader.Close();
                return currentPO;
            }
        }

        public MasterPO GetMasterPOByID(int MID)
        {
            MasterPO masterPO = new MasterPO();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_masterpo_by_id";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MID", SqlDbType.Int);
                param.Value = MID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                PO currentPO = new PO();

                while (reader.Read())
                {
                    masterPO.MasterPOID = Convert.ToInt32(reader["MasterPOID"]);
                    masterPO.Client = new Client();
                    masterPO.Client.ClientID = Convert.ToInt32(reader["ClientID"]);
                    masterPO.Client.CompanyName = Convert.ToString(reader["CompanyName"]);
                    masterPO.Fabric = new POFabExt();
                    masterPO.Fabric.TradeName = reader["FabricName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FabricName"]);
                    masterPO.Fabric.Width = reader["Width"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Width"]);
                    masterPO.Fabric.Composition = reader["Composition"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Composition"]);
                    masterPO.Fabric.CountConstruction = reader["cc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["cc"]);
                    masterPO.Fabric.HandFeel = reader["handfeel"] == DBNull.Value ? string.Empty : Convert.ToString(reader["handfeel"]);
                    masterPO.Fabric.GSM = reader["gsm"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["gsm"]);
                    masterPO.Fabric.Shrinkage = reader["shrinkage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["shrinkage"]);
                    masterPO.PrintName = reader["PrintColor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PrintColor"]);
                    masterPO.Print = reader["Print"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Print"]);
                    masterPO.OrderType = (reader["OrderType"] == DBNull.Value ? 0 : Convert.ToInt32(reader["OrderType"]));
                    masterPO.POType = (reader["MainPOType"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MainPOType"]));
                    //masterPO.AssociatedPO = GetPOByMasterPOID(MID);

                }


                reader.Close();
                return masterPO;
            }


        }

        public Supplier GetSupplierBySID(int SID)
        {
            Supplier supplier = new Supplier();
            return supplier;
        }

        public POProcess GetProcessByPID(int PID)
        {
            POProcess process = new POProcess();
            return process;
        }

        public MasterPO GetMasterPOByPOID(int POID)
        {
            MasterPO masterPO = new MasterPO();
            return masterPO;
        }

        public List<PO> GetPOByMasterPOID(int MID)
        {
            List<PO> AssociatedPOs = new List<PO>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_all_po_by_masterid";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MID", SqlDbType.Int);
                param.Value = MID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PO currentPO = new PO();
                    currentPO.POID = Convert.ToInt32(reader["id"]);
                    currentPO.PONumber = (reader["PONumber"]).ToString();
                    currentPO.PODate = reader["PODate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PODate"]);
                    currentPO.POType = reader["POType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["POType"]);
                    currentPO.QTY = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Quantity"]);
                    currentPO.Rate = reader["Rate"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Rate"]);
                    currentPO.Unit = reader["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Unit"]);
                    currentPO.CurrencyUnit = reader["CurrencyUnit"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CurrencyUnit"]);
                    currentPO.RecievedQty = reader["ReceivedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["ReceivedQty"]);
                    currentPO.RejectedQty = reader["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["RejectedQty"]);
                    currentPO.IsDeleted = reader["IsDeleted"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IsDeleted"]);
                    currentPO.RelatedPOID = reader["RelatedPOID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RelatedPOID"]);
                    currentPO.IsActive = reader["IsActive"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IsActive"]);
                    currentPO.CreatedDate = reader["CreatedON"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedON"]);
                    currentPO.MasterPO = new MasterPO();
                    currentPO.MasterPO.MasterPOID = Convert.ToInt32(reader["MasterPOID"]);
                    currentPO.Process = new POProcess();
                    currentPO.Process.ProcessID = reader["ProcessID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ProcessID"]);
                    currentPO.Process.ProcessName = reader["ProcessName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProcessName"]);
                    currentPO.Supplier = new Supplier();
                    currentPO.Supplier.SupplierID = reader["SupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SupplierID"]);
                    currentPO.Supplier.SupplierName = reader["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SupplierName"]);
                    currentPO.Supplier.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    currentPO.Supplier.PaymentTerms = reader["PaymentTerms"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PaymentTerms"]);
                    currentPO.Remarks = reader["Remarks"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Remarks"]);
                    currentPO.DeliveryDate = reader["DeliveryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DeliveryDate"]);
                    AssociatedPOs.Add(currentPO);
                }
                reader.Close();
                return AssociatedPOs;
            }
        }

        public List<POProcess> GetProcessByMasterPOID(int MID)
        {
            List<POProcess> AssociatedProcess = new List<POProcess>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_all_process_mainPO";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POProcess process = new POProcess();
                    process.ProcessID = Convert.ToInt32(reader["ProcessID"]);
                    process.ProcessName = (reader["ProcessName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProcessName"]);
                    process.IsValid = (reader["IsValid"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsValid"]);
                    AssociatedProcess.Add(process);
                }
                reader.Close();
                return AssociatedProcess;
            }
        }

        public List<OrderDetail> GetOrderByMasterPOID(MasterPO masterPO)
        {
            List<OrderDetail> AssociatedContracts = new List<OrderDetail>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_all_related_order_contracts";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = masterPO.MasterPOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Clientid", SqlDbType.Int);
                param.Value = masterPO.Client.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = masterPO.Fabric.TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Print", SqlDbType.VarChar);
                param.Value = masterPO.Print;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    /*
                        `LineItemNumber`,  `ContractNumber`,  `Fabric4` AS Fabric1,  `Fabric4Details` AS Fabric1Details,    `ColorPrint`,
   `Quantity`,  `ExFactory`,  `DC`,  `Fabric4Average` AS Fabric1Average,  `Fabric4Quantity` AS Fabric1Quantity,
   `BulkTarget`,  `LabDipTarget`,  `BulkApprovalTarget`,o.styleid,o.clientid,o.orderdate,'' AS ImageUrl,
 w.currentstatusid AS StatusModeID,w.currentstatusid AS `Status`,0 AS StatusModeSequence,IFNULL(MainPOID,0) AS IsAdded
                     */
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.ParentOrder = new Order();
                    orderDetail.ParentOrder.OrderID = Convert.ToInt32(reader["OrderID"]);
                    orderDetail.ParentOrder.StyleID = Convert.ToInt32(reader["Styleid"]);
                    orderDetail.ParentOrder.Style = new Style();
                    orderDetail.ParentOrder.Print = new Print();
                    orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                    orderDetail.ParentOrder.Style.SketchURL = (reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"]);
                    orderDetail.ParentOrder.OrderDate = (reader["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(reader["OrderDate"]) : DateTime.MinValue;
                    orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                    orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                    orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                    orderDetail.Quantity = Convert.ToDouble(reader["Quantity"]);
                    orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                    orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                    orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                    orderDetail.Fabric1Average = (reader["Fabric1Average"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric1Average"]);
                    orderDetail.Fabric1Quantity = (reader["Fabric1Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric1Quantity"]);
                    orderDetail.Status = (reader["Status"] == DBNull.Value) ? "" : Convert.ToString(reader["Status"]);
                    orderDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                    orderDetail.StatusModeSequence = (reader["StatusModeSequence"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeSequence"]);
                    orderDetail.BulkTarget = (reader["BulkTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkTarget"]) : DateTime.MinValue;
                    orderDetail.LabDipTarget = (reader["LabDipTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["LabDipTarget"]) : DateTime.MinValue;
                    orderDetail.BulkApprovalTarget = (reader["BulkApprovalTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkApprovalTarget"]) : DateTime.MinValue;
                    orderDetail.ParentOrder.Print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    orderDetail.IsValid = (reader["IsActive"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsActive"]);
                    AssociatedContracts.Add(orderDetail);
                }
                reader.Close();
                return AssociatedContracts;
            }
        }
        //
        public Supplier GetSupplierByPOID(int POID)
        {
            Supplier supplier = new Supplier();
            return supplier;
        }

        public PO GetPODetails(int MOID, int SID, int POType, int ProcessID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_po_details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SID", SqlDbType.Int);
                param.Value = SID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@POType", SqlDbType.Int);
                param.Value = POType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessID", SqlDbType.Int);
                param.Value = ProcessID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                PO currentPO = new PO();

                while (reader.Read())
                {
                    currentPO.POID = -1;
                    currentPO.PONumber = (reader["PONumber"]).ToString();
                    currentPO.POType = reader["POType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["POType"]);
                    currentPO.Unit = reader["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Unit"]);
                    currentPO.CurrencyUnit = reader["CurrencyUnit"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CurrencyUnit"]);
                    currentPO.MasterPO = new MasterPO();
                    currentPO.MasterPO.MasterPOID = Convert.ToInt32(reader["MasterPOID"]);
                    currentPO.MasterPO.Client = new Client();
                    currentPO.MasterPO.Client.ClientID = Convert.ToInt32(reader["ClientID"]);

                    currentPO.MasterPO.Fabric = new POFabExt();
                    currentPO.MasterPO.Fabric.TradeName = reader["FabricName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FabricName"]);
                    currentPO.MasterPO.Fabric.Width = reader["Width"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Width"]);
                    currentPO.MasterPO.Fabric.Composition = reader["Composition"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Composition"]);
                    currentPO.MasterPO.Fabric.CountConstruction = reader["cc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["cc"]);
                    currentPO.MasterPO.Fabric.HandFeel = reader["handfeel"] == DBNull.Value ? string.Empty : Convert.ToString(reader["handfeel"]);
                    currentPO.MasterPO.Fabric.GSM = reader["gsm"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["gsm"]);
                    currentPO.MasterPO.Fabric.Shrinkage = reader["shrinkage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["shrinkage"]);
                    currentPO.MasterPO.PrintName = reader["PrintColor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PrintColor"]);

                    currentPO.Process = new POProcess();
                    currentPO.Process.ProcessID = Convert.ToInt32(reader["ProcessID"]);
                    currentPO.Process.ProcessName = Convert.ToString(reader["ProcessName"]);
                    currentPO.Supplier = new Supplier();
                    currentPO.Supplier.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    currentPO.Supplier.SupplierName = reader["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SupplierName"]);
                    currentPO.Supplier.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    currentPO.Supplier.PaymentTerms = reader["PaymentTerms"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PaymentTerms"]);
                    currentPO.Remarks = reader["Remarks"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Remarks"]);
                    currentPO.DeliveryDate = reader["DeliveryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DeliveryDate"]);
                    //currentPO.SpecificationID = reader["SpecificationID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SpecificationID"]);
                }
                reader.Close();
                return currentPO;
            }
        }

        public PO GetPODetailsByFabric(string fabric, string print, int SID, int POType, int ProcessID, int ClientID, int Washing)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_po_details_by_fabric";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = fabric;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Print", SqlDbType.VarChar);
                param.Value = print;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SID", SqlDbType.Int);
                param.Value = SID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@POType", SqlDbType.Int);
                param.Value = POType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessID", SqlDbType.Int);
                param.Value = ProcessID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sWashingRequired", SqlDbType.Int);
                param.Value = Washing;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                PO currentPO = new PO();

                while (reader.Read())
                {
                    currentPO.POID = -1;
                    currentPO.PONumber = (reader["PONumber"]).ToString();
                    currentPO.POType = reader["POType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["POType"]);
                    currentPO.Unit = reader["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Unit"]);
                    currentPO.CurrencyUnit = reader["CurrencyUnit"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CurrencyUnit"]);
                    currentPO.MasterPO = new MasterPO();
                    currentPO.MasterPO.MasterPOID = reader["MasterPOID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MasterPOID"]);
                    currentPO.MasterPO.Client = new Client();
                    currentPO.MasterPO.Client.ClientID = Convert.ToInt32(reader["ClientID"]);

                    currentPO.MasterPO.Fabric = new POFabExt();
                    currentPO.MasterPO.Fabric.TradeName = reader["FabricName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FabricName"]);
                    currentPO.MasterPO.Fabric.Width = reader["Width"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Width"]);
                    currentPO.MasterPO.Fabric.Composition = reader["Composition"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Composition"]);
                    currentPO.MasterPO.Fabric.CountConstruction = reader["cc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["cc"]);
                    currentPO.MasterPO.Fabric.HandFeel = reader["handfeel"] == DBNull.Value ? string.Empty : Convert.ToString(reader["handfeel"]);
                    currentPO.MasterPO.Fabric.GSM = reader["gsm"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["gsm"]);
                    currentPO.MasterPO.Fabric.Shrinkage = reader["shrinkage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["shrinkage"]);
                    currentPO.MasterPO.PrintName = reader["PrintColor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PrintColor"]);

                    currentPO.Process = new POProcess();
                    currentPO.Process.ProcessID = Convert.ToInt32(reader["ProcessID"]);
                    currentPO.Process.ProcessName = Convert.ToString(reader["ProcessName"]);
                    currentPO.Supplier = new Supplier();
                    currentPO.Supplier.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    currentPO.Supplier.SupplierName = reader["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SupplierName"]);
                    currentPO.Supplier.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    currentPO.Supplier.PaymentTerms = reader["PaymentTerms"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PaymentTerms"]);
                    currentPO.Remarks = reader["Remarks"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Remarks"]);
                    currentPO.DeliveryDate = reader["DeliveryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DeliveryDate"]);
                    //currentPO.SpecificationID = reader["SpecificationID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SpecificationID"]);
                }
                reader.Close();
                return currentPO;
            }
        }

        public List<PO> GetALLPOByID(int POID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_all_po_by_id";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@POID", SqlDbType.Int);
                param.Value = POID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<PO> AllPO = new List<PO>();
                while (reader.Read())
                {
                    PO currentPO = new PO();
                    currentPO.POID = Convert.ToInt32(reader["id"]);
                    currentPO.PONumber = (reader["PONumber"]).ToString();
                    currentPO.PODate = reader["PODate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PODate"]);
                    currentPO.POType = reader["POType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["POType"]);
                    currentPO.QTY = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Quantity"]);
                    currentPO.Rate = reader["Rate"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Rate"]);
                    currentPO.Unit = reader["Unit"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Unit"]);
                    currentPO.CurrencyUnit = reader["CurrencyUnit"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CurrencyUnit"]);
                    currentPO.RecievedQty = reader["ReceivedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["ReceivedQty"]);
                    currentPO.RejectedQty = reader["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["RejectedQty"]);
                    currentPO.IsDeleted = reader["IsDeleted"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IsDeleted"]);
                    currentPO.RelatedPOID = reader["RelatedPOID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RelatedPOID"]);
                    currentPO.IsActive = reader["IsActive"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IsActive"]);
                    currentPO.CreatedDate = reader["CreatedON"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedON"]);
                    currentPO.MasterPO = new MasterPO();
                    currentPO.MasterPO.MasterPOID = Convert.ToInt32(reader["MasterPOID"]);
                    currentPO.MasterPO.Client = new Client();
                    currentPO.MasterPO.Client.ClientID = Convert.ToInt32(reader["ClientID"]);

                    currentPO.MasterPO.Fabric = new POFabExt();
                    currentPO.MasterPO.Fabric.TradeName = reader["FabricName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FabricName"]);
                    currentPO.MasterPO.Fabric.Width = reader["Width"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Width"]);
                    currentPO.MasterPO.Fabric.Composition = reader["Composition"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Composition"]);
                    currentPO.MasterPO.Fabric.CountConstruction = reader["cc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["cc"]);
                    currentPO.MasterPO.Fabric.HandFeel = reader["handfeel"] == DBNull.Value ? string.Empty : Convert.ToString(reader["handfeel"]);
                    currentPO.MasterPO.Fabric.GSM = reader["gsm"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["gsm"]);
                    currentPO.MasterPO.Fabric.Shrinkage = reader["shrinkage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["shrinkage"]);
                    currentPO.MasterPO.PrintName = reader["PrintColor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PrintColor"]);

                    currentPO.Process = new POProcess();
                    currentPO.Process.ProcessID = reader["ProcessID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ProcessID"]);
                    currentPO.Process.ProcessName = reader["ProcessName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProcessName"]);
                    currentPO.Supplier = new Supplier();
                    currentPO.Supplier.SupplierID = reader["SupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SupplierID"]);
                    currentPO.Supplier.SupplierName = reader["SupplierName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SupplierName"]);
                    currentPO.Supplier.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    currentPO.Supplier.PaymentTerms = reader["PaymentTerms"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PaymentTerms"]);
                    string remarks = "";
                    if (reader["Remarks"] == DBNull.Value)
                        remarks = "";
                    else
                    {
                        remarks = Convert.ToString(reader["Remarks"]);
                        //UTF8Encoding enc = new UTF8Encoding();
                        //remarks = enc.GetString((byte[]) reader["Remarks"]);
                    }
                    currentPO.Remarks = remarks;
                    currentPO.DeliveryDate = reader["DeliveryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DeliveryDate"]);
                    //currentPO.SpecificationID = reader["SpecificationID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SpecificationID"]);
                    AllPO.Add(currentPO);
                }
                reader.Close();
                return AllPO;
            }
        }

        public DataSet GetPOInstruction(int MOID, int POType, int GroupType, int POID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_PO_instruction_for_po";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@POID", SqlDbType.Int);
                param.Value = POID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@POType", SqlDbType.Int);
                param.Value = POType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GroupType", SqlDbType.Int);
                param.Value = GroupType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return (ds);
            }
        }

        public DataSet GetMainPODeliveryDetails(int MOID, int ClientID, string fabricName, string PrintName, int OrderType, int POType)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_mainpo_details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Clientid", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = fabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Print", SqlDbType.VarChar);
                param.Value = PrintName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderType", SqlDbType.Int);
                param.Value = OrderType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@POType", SqlDbType.Int);
                param.Value = POType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return (ds);
            }
        }

        public DataSet GetAllProcessDetails(int MainPOID, int ProcessID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_all_process_details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MainPOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@ProcessID", SqlDbType.Int);
                param.Value = ProcessID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return (ds);
            }
        }

        public int SavePODetails(PO currentPO, int TaskID, int IsUpdate)
        {
            //sp_po_save_mainPO_details
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_po_save_po_details";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;

                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@POID", SqlDbType.Int);
                    param.Value = currentPO.POID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOID", SqlDbType.Int);
                    param.Value = currentPO.MasterPO.MasterPOID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SID", SqlDbType.Int);
                    param.Value = currentPO.Supplier.SupplierID; ;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@POType", SqlDbType.Int);
                    param.Value = Convert.ToInt32(currentPO.POType);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProcessID", SqlDbType.Int);
                    param.Value = currentPO.Process.ProcessID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierID", SqlDbType.Int);
                    param.Value = currentPO.Supplier.SupplierID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Float);
                    param.Value = currentPO.QTY;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Unit", SqlDbType.VarChar);
                    param.Value = currentPO.Unit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Decimal);
                    param.Value = currentPO.Rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Shrinkage", SqlDbType.Decimal);
                    param.Value = currentPO.Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = currentPO.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SpecificationID", SqlDbType.Int);
                    param.Value = currentPO.SpecificationID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StockID", SqlDbType.Int);
                    param.Value = currentPO.StockID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@TaskID", SqlDbType.Int);
                    param.Value = TaskID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sStock", SqlDbType.VarChar);
                    param.Value = currentPO.IsStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CurrencyUnit", SqlDbType.Int);
                    param.Value = currentPO.CurrencyUnit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sApproved", SqlDbType.Int);
                    param.Value = currentPO.IsApproved;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sUpdate", SqlDbType.Int);
                    param.Value = IsUpdate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DelDate", SqlDbType.DateTime);
                    param.Value = currentPO.DeliveryDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(outParam.Value) > 0)
                    {
                        transaction.Commit();
                        return Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }
        public int SaveMainPODetails(MasterPO masterPO)
        {

            //sp_po_save_mainPO_details
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_po_save_mainPO_details";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;

                    outParam = new SqlParameter("@MoId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                    param.Value = masterPO.Fabric.TradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Print", SqlDbType.VarChar);
                    param.Value = masterPO.PrintName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = masterPO.Client.ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sWashingRequired", SqlDbType.Int);
                    param.Value = masterPO.IsWashingReq;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderType", SqlDbType.Int);
                    param.Value = masterPO.OrderType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@POType", SqlDbType.Int);
                    param.Value = masterPO.POType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(outParam.Value) > 0)
                    {
                        transaction.Commit();
                        return Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }

        public DataSet GetMainPOGreigeDetails(string Fab, int MasterPOID, int ProcessID, string Params)
        {
            //
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_getGriegeDetail_mainPO";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Fab", SqlDbType.VarChar);
                param.Value = Fab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Params", SqlDbType.VarChar);
                param.Value = Params;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MasterPOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessID", SqlDbType.Int);
                param.Value = ProcessID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsclient);
                return (dsclient);

            }

        }

        public int SaveProcessDetails(string strXML, int MID)
        {
            //sp_po_save_mainPO_details
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_po_save_Process_details";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;
                    outParam = new SqlParameter("@PID", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@MID", SqlDbType.Int);
                    param.Value = MID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@XML", SqlDbType.VarChar);
                    param.Value = strXML;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(outParam.Value) > 0)
                    {
                        transaction.Commit();
                        return Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }
        public int SaveOrderDetails(string strXML, int MID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_po_save_Order_details";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;
                    outParam = new SqlParameter("@OID", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@MID", SqlDbType.Int);
                    param.Value = MID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@XML", SqlDbType.VarChar);
                    param.Value = strXML;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(outParam.Value) > 0)
                    {
                        transaction.Commit();
                        return Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }
        public int SaveReprocessingDetails(ReprocessPO currentPO, int ReType, string TypeID)
        {
            //sp_po_save_mainPO_details
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_po_save_reprocessing_details";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;

                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@ReType", SqlDbType.Int);
                    param.Value = ReType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReNo", SqlDbType.Int);
                    param.Value = currentPO.ReType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TypeID", SqlDbType.VarChar);
                    param.Value = TypeID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QtyDebt", SqlDbType.Float);
                    param.Value = currentPO.QtyDebt; ;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RateDebt", SqlDbType.Float);
                    param.Value = currentPO.RateDebt;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QtyReturn", SqlDbType.Float);
                    param.Value = currentPO.QtyReturn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QtyNewPO", SqlDbType.Float);
                    param.Value = currentPO.QtyNewPO; ;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvent", SqlDbType.Int);
                    param.Value = currentPO.IsMovetoInventory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Reusable", SqlDbType.Int);
                    param.Value = currentPO.IsReuasble;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(outParam.Value) > 0)
                    {
                        transaction.Commit();
                        return Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }

        public ListCM GetAllCurrency()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetAllCurrency";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataReader dataReader = cmd.ExecuteReader();
                ListCM lcm = new ListCM();
                while (dataReader.Read())
                {
                    CurrencyMaster cm = new CurrencyMaster();
                    cm.Id = dataReader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["Id"]);
                    cm.CurrencySymbol = dataReader["CurrencySymbol"] == DBNull.Value ? "" : Convert.ToString(dataReader["CurrencySymbol"]);
                    cm.CurrencyType = dataReader["CurrencyType"] == DBNull.Value ? "" : Convert.ToString(dataReader["CurrencyType"]);
                    lcm.Add(cm);
                }
                return lcm;
            }
        }

        public int SaveSamplingPo(ListSID lsd)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlTransaction trnx = cnx.BeginTransaction();
                try
                {
                    string cmdText = "sp_getSamplingMainId";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter oparam = new SqlParameter("@oMainid", SqlDbType.Int);
                    oparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(oparam);
                    cmd.ExecuteNonQuery();
                    int mainid = Convert.ToInt32(oparam.Value);
                    SqlParameter param;
                    foreach (SInventoryDetail sid in lsd)
                    {
                        cmdText = "sp_po_save_mainPO_details";

                        cmd = new SqlCommand(cmdText, cnx);

                        cmd.Transaction = trnx;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        SqlParameter outParam;

                        outParam = new SqlParameter("@MoId", SqlDbType.Int);
                        outParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outParam);

                        param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                        param.Value = sid.ItemName;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Print", SqlDbType.VarChar);
                        param.Value = sid.Description;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ClientId", SqlDbType.Int);
                        param.Value = sid.ClientId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@sWashingRequired", SqlDbType.Int);
                        param.Value = 0;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@OrderType", SqlDbType.Int);
                        param.Value = 3;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@POType", SqlDbType.Int);
                        param.Value = sid.PoType;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();

                        int mainpoid = Convert.ToInt32(outParam.Value);

                        cmdText = "sp_po_save_po_details";

                        cmd = new SqlCommand(cmdText, cnx);
                        cmd.Transaction = trnx;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        outParam = new SqlParameter("@d", SqlDbType.Int);
                        outParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outParam);

                        param = new SqlParameter("@POID", SqlDbType.Int);
                        param.Value = -1;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@MOID", SqlDbType.Int);
                        param.Value = mainpoid;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SID", SqlDbType.Int);
                        param.Value = sid.SupplierId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@POType", SqlDbType.Int);
                        param.Value = (int)PoType.Greige;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ProcessID", SqlDbType.Int);
                        param.Value = -1;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SupplierID", SqlDbType.Int);
                        param.Value = sid.SupplierId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Quantity", SqlDbType.Float);
                        param.Value = sid.Qty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Unit", SqlDbType.VarChar);
                        param.Value = sid.CurrencyUnit;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Rate", SqlDbType.Decimal);
                        param.Value = sid.Rate;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Shrinkage", SqlDbType.Decimal);
                        param.Value = 0;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                        param.Value = "";
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SpecificationID", SqlDbType.Int);
                        param.Value = -1;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@StockID", SqlDbType.Int);
                        param.Value = -1;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@TaskID", SqlDbType.Int);
                        param.Value = sid.TaskId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@sStock", SqlDbType.VarChar);
                        param.Value = sid.ClientId == -1 ? "Y" : "N";
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@CurrencyUnit", SqlDbType.Int);
                        param.Value = sid.CurrencyUnit;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@sApproved", SqlDbType.Int);
                        param.Value = 1;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@sUpdate", SqlDbType.Int);
                        param.Value = 0;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@DelDate", SqlDbType.DateTime);
                        param.Value = sid.DeliveryDate;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();

                        int poid = Convert.ToInt32(outParam.Value);

                        cmdText = "sp_InsertSamplingPo";

                        cmd = new SqlCommand(cmdText, cnx, trnx);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        param = new SqlParameter("@PoId", SqlDbType.VarChar);
                        param.Value = poid;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@MainId", SqlDbType.Int);
                        param.Value = mainid;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                    trnx.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    trnx.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }

        public int CancelPO(int POID, string CancelReason)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_po_CancelPO";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;

                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@POID", SqlDbType.Int);
                    param.Value = POID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CancelReason", SqlDbType.VarChar);
                    param.Value = CancelReason;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToInt32(outParam.Value) > 0)
                    {
                        transaction.Commit();
                        return Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }

        }

        public DataSet GetAllClosedPO(int MainPOID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_po_get_all_closed_po_mainPO";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MainPOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return (ds);
            }
        }
    }
}
