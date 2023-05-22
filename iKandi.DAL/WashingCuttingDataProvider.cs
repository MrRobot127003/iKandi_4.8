using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using iKandi.Common;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    public class WashingCuttingDataProvider : BaseDataProvider
    {
        #region Ctor(s)
        public WashingCuttingDataProvider()
        {

        }

        public WashingCuttingDataProvider(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }
        #endregion

        #region Methods

        #region GetWashingCuttingDetails
        public WashingCutting GetWashingCuttingDetails(int OrderId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetWCDetail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count < 1 || dataSet.Tables[0].Rows.Count < 1)
                    return null;
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                WashingCutting wc = new WashingCutting();
                wc.IsWashingRequired = dataRow["IsWashingRequired"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["IsWashingRequired"]);
                wc.OrderId = dataRow["OrderId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["OrderId"]);
                wc.OrderDate = dataRow["OrderDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow["OrderDate"]);
                wc.OrderNumber = dataRow["SerialNumber"] == DBNull.Value ? "" : Convert.ToString(dataRow["SerialNumber"]);
                wc.ContractNumber = dataRow["ContractNumber"] == DBNull.Value ? "" : Convert.ToString(dataRow["ContractNumber"]);
                wc.LineItemNumber = dataRow["LineItemNumber"] == DBNull.Value ? "" : Convert.ToString(dataRow["LineItemNumber"]);
                wc.Pieces = dataRow["Pieces"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["Pieces"]);
                wc.Requirement = dataRow["FinalOrder"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["FinalOrder"]);
                wc.StyleId = dataRow["StyleId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StyleId"]);
                wc.StyleNumber = dataRow["StyleNumber"] == DBNull.Value ? "" : Convert.ToString(dataRow["StyleNumber"]);
                wc.ImageUrl = dataRow["SampleImageURL1"] == DBNull.Value ? "" : Convert.ToString(dataRow["SampleImageURL1"]);
                wc.Department = dataRow["DepartmentName"] == DBNull.Value ? "" : Convert.ToString(dataRow["DepartmentName"]);
                wc.Buyer = dataRow["CompanyName"] == DBNull.Value ? "" : Convert.ToString(dataRow["CompanyName"]);
                wc.FabricName = dataRow["fabricname"] == DBNull.Value ? "" : Convert.ToString(dataRow["fabricname"]);
                //wc.FabricDetails = dataRow["fabricdetails"] == DBNull.Value ? "" : Convert.ToString(dataRow["fabricdetails"]);
                wc.SrvQuantity = dataRow["SrvQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["SrvQuantity"]);
                wc.FPRQuantity = dataRow["FPRQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["FPRQuantity"]);
                wc.FPWQuantity = wc.IsWashingRequired == 1
                                     ? (dataRow["FPWQuantity"] == DBNull.Value
                                            ? 0
                                            : Convert.ToDouble(dataRow["FPWQuantity"]))
                                     : (dataRow["FPRQuantity"] == DBNull.Value
                                            ? 0
                                            : Convert.ToDouble(dataRow["FPRQuantity"]));
                wc.WashingPerc = dataRow["washing_percent"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["washing_percent"]);
                wc.CuttingPerc = dataRow["cutting_percent"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["cutting_percent"]);
                wc.OrderDetailId = dataRow["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["OrderDetailId"]);
                wc.StockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);
                if (wc.IsWashingRequired == 1)
                    wc.CutStockId = dataRow["CutStockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["CutStockId"]);
                else
                    wc.CutStockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);
                wc.Balance = wc.Requirement - (wc.Requirement * wc.WashingPerc / 100) - wc.FPRQuantity;
                wc.CuttingRequirement = wc.Requirement;
                wc.CuttingBalance = wc.CuttingRequirement - (wc.Requirement * wc.CuttingPerc / 100) -
                                    (wc.IsWashingRequired == 0 ? wc.FPRQuantity : wc.FPWQuantity);
                wc.Unit = dataRow["Unit"] == DBNull.Value ? "" : Convert.ToString(dataRow["Unit"]);
                wc.PrintColor = dataRow["PrintColor"] == DBNull.Value ? "" : Convert.ToString(dataRow["PrintColor"]);
                wc.AvgLength = dataRow["Average"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["Average"]);
                wc.ProcessId = dataRow["ProcessId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["ProcessId"]);
                wc.MasterPoId = dataRow["MasterPoId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["MasterPoId"]);
                wc.FactoryName = dataRow["FactoryName"] == DBNull.Value ? "" : Convert.ToString(dataRow["FactoryName"]);
                WashingCuttingTotal wct = GetWcDetailByOdIdAndFabric(OrderId, wc.FabricName, wc.PrintColor);
                if (wct != null)
                {
                    wc.OrderDetailId = wct.OrderDetailId;
                    wc.QtyWashIssuedTotal = wct.QtyWashIssuedTotal;
                    wc.QtyWashReceivedTotal = wct.QtyWashReceivedTotal;
                    wc.IsCompleteWash = wct.IsCompleteWash;
                    wc.QtyCutIssuedTotal = wct.QtyCutIssuedTotal;
                    wc.QtyCutReceivedTotal = wct.QtyCutReceivedTotal;
                    wc.IsCompleteCut = wct.IsCompleteCut;
                }
                else
                {
                    wc.QtyWashIssuedTotal = 0;
                    wc.QtyWashReceivedTotal = 0;
                    wc.IsCompleteWash = 0;
                    wc.QtyCutIssuedTotal = 0;
                    wc.QtyCutReceivedTotal = 0;
                    wc.IsCompleteCut = 0;
                }
                return wc;
            }
        }
        #endregion

        #region InsertWashing
        public int InsertWashing(WashingCuttingTotal wc)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //string cmdText = "sp_insert_washing";
                string cmdText = "sp_insert_washing_issued";
                SqlTransaction trnx = cnx.BeginTransaction();
                SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@StockId", SqlDbType.Int);
                param.Value = wc.StockId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@QuantityIssued", SqlDbType.Float);
                param.Value = wc.QtyWashIssued;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = wc.OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = wc.CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlParameter IdParam = new SqlParameter("@DocId", SqlDbType.Int);
                IdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(IdParam);
                SqlParameter paramstatus = new SqlParameter("@Status", SqlDbType.Int);
                paramstatus.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramstatus);
                try
                {
                    int status = 0;
                    if (wc.WahingCompleted == 0)
                    {
                        if ((wc.QtyWashIssued > 0 || wc.IsCompleteWash == 1 || wc.QtyWashReceived > 0) && wc.IsWashingRequired == 1)
                        {
                            cmd.ExecuteNonQuery();
                            status = Convert.ToInt32(paramstatus.Value);
                            if (status != 1)
                            {
                                trnx.Rollback();
                                return status;
                            }
                            wc.WashingId = Convert.ToInt32(IdParam.Value);


                            if (wc.QtyWashReceived > 0 || wc.IsCompleteWash == 1)
                            {
                                cmdText = "sp_insert_washing_received";
                                cmd = new SqlCommand(cmdText, cnx, trnx);

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                                param = new SqlParameter("@StockId", SqlDbType.Int);
                                param.Value = wc.StockId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                                param.Value = wc.OrderDetailId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@QuantityReceived", SqlDbType.Float);
                                param.Value = wc.QtyWashReceived;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@sComplete", SqlDbType.Int);
                                param.Value = wc.IsCompleteWash;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                                param.Value = wc.CreatedBy;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@DocId", SqlDbType.Int);
                                param.Value = wc.WashingId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                SqlParameter paramstatus1 = new SqlParameter("@Status", SqlDbType.Int);
                                paramstatus1.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(paramstatus1);
                                cmd.ExecuteNonQuery();
                                status = Convert.ToInt32(paramstatus1.Value);
                                if (status != 1)
                                {
                                    trnx.Rollback();
                                    return status + 10;
                                }
                            }
                        }
                    }
                    if (wc.CuttingCompleted == 0)
                    {
                        if (wc.QtyCutIssued > 0 || wc.IsCompleteCut == 1 || wc.QtyCutReceived > 0)
                        {
                            cmdText = "sp_insert_cutting_issued";

                            cmd = new SqlCommand(cmdText, cnx, trnx);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                            param = new SqlParameter("@StockId", SqlDbType.Int);
                            param.Value = wc.CutStockId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);
                            param = new SqlParameter("@QuantityIssued", SqlDbType.Float);
                            param.Value = wc.QtyCutIssued;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);
                            param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                            param.Value = wc.OrderDetailId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);
                            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                            param.Value = wc.CreatedBy;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);
                            IdParam = new SqlParameter("@DocId", SqlDbType.Int);
                            IdParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(IdParam);
                            paramstatus = new SqlParameter("@Status", SqlDbType.Int);
                            paramstatus.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(paramstatus);
                            cmd.ExecuteNonQuery();

                            status = Convert.ToInt32(paramstatus.Value);
                            if (status != 1)
                            {
                                trnx.Rollback();
                                return status + 20;
                            }
                            wc.CuttingId = Convert.ToInt32(IdParam.Value);

                            if (wc.QtyCutReceived > 0 || wc.IsCompleteCut == 1)
                            {
                                cmdText = "sp_insert_cutting_received";
                                cmd = new SqlCommand(cmdText, cnx, trnx);

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                                param = new SqlParameter("@StockId", SqlDbType.Int);
                                param.Value = wc.CutStockId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                                param.Value = wc.OrderDetailId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@QuantityReceived", SqlDbType.Float);
                                param.Value = wc.QtyCutReceived;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@AvgQty", SqlDbType.Float);
                                param.Value = wc.AvgLength;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@sComplete", SqlDbType.Int);
                                param.Value = wc.IsCompleteCut;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                                param.Value = wc.CreatedBy;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@DocId", SqlDbType.Int);
                                param.Value = wc.CuttingId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@TaskId", SqlDbType.Int);
                                param.Value = wc.TaskId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                paramstatus = new SqlParameter("@Status", SqlDbType.Int);
                                paramstatus.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(paramstatus);
                                cmd.ExecuteNonQuery();
                                status = Convert.ToInt32(paramstatus.Value);
                                if (status != 1)
                                {
                                    trnx.Rollback();
                                    return status + 30;
                                }
                            }
                        }
                    }
                    trnx.Commit();
                    return status;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    trnx.Rollback();
                    return 0;
                }
            }
        }

        #endregion

        #region InsertWashingList
        public int InsertWashingList(WCTList wclist, int userId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //string cmdText = "sp_insert_washing";
                string cmdText;
                SqlTransaction trnx = cnx.BeginTransaction();
                SqlCommand cmd;
                SqlParameter param;
                bool itw = false, rfw = false, itc = false;
                int citw = 0, crfw = 0, citc = 0;
                try
                {
                    if (wclist.Count > 0)
                    {
                        foreach (WashingCuttingTotal wc in wclist)
                        {
                            if (wc.QtyWashIssued > 0)
                            {
                                itw = true;
                                //break;
                            }
                            if (wc.QtyWashReceived > 0)
                            {
                                rfw = true;
                                //break;
                            }
                            if (wc.QtyCutIssued > 0)
                            {
                                itc = true;
                                //break;
                            }
                            //if ((itw && rfw) || itc)
                            //    break;
                        }
                    }
                    if (itc)
                    {
                        citc = CreateChallan(userId, 3, cnx, trnx);
                    }
                    if (itw)
                    {
                        citw = CreateChallan(userId, 1, cnx, trnx);
                    }
                    if (rfw)
                    {
                        crfw = CreateChallan(userId, 2, cnx, trnx);
                    }
                    foreach (WashingCuttingTotal wc in wclist)
                    {
                        cmdText = "sp_insert_washing_issued";
                        cmd = new SqlCommand(cmdText, cnx, trnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                        param = new SqlParameter("@StockId", SqlDbType.Int);
                        param.Value = wc.StockId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                        param = new SqlParameter("@QuantityIssued", SqlDbType.Float);
                        param.Value = wc.QtyWashIssued;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                        param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                        param.Value = wc.OrderDetailId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                        param.Value = wc.CreatedBy;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                        SqlParameter IdParam = new SqlParameter("@DocId", SqlDbType.Int);
                        IdParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(IdParam);
                        SqlParameter paramstatus = new SqlParameter("@Status", SqlDbType.Int);
                        paramstatus.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramstatus);
                        int status = 0;
                        if (wc.WahingCompleted == 0)
                        {
                            if ((wc.QtyWashIssued > 0 || wc.IsCompleteWash == 1 || wc.QtyWashReceived > 0) &&
                                wc.IsWashingRequired == 1)
                            {
                                cmd.ExecuteNonQuery();
                                status = Convert.ToInt32(paramstatus.Value);
                                if (status != 1)
                                {
                                    trnx.Rollback();
                                    return status;
                                }
                                InsertIiChallanDetail(wc.OrderDetailId, citw, 1, wc.QtyWashIssued, wc.FabricName, wc.FabricDetails, trnx, cnx);
                                wc.WashingId = Convert.ToInt32(IdParam.Value);
                                if (wc.QtyWashReceived > 0 || wc.IsCompleteWash == 1)
                                {
                                    cmdText = "sp_insert_washing_received";
                                    cmd = new SqlCommand(cmdText, cnx, trnx);

                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                                    param = new SqlParameter("@StockId", SqlDbType.Int);
                                    param.Value = wc.StockId;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                                    param.Value = wc.OrderDetailId;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@QuantityReceived", SqlDbType.Float);
                                    param.Value = wc.QtyWashReceived;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@sComplete", SqlDbType.Int);
                                    param.Value = wc.IsCompleteWash;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                                    param.Value = wc.CreatedBy;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@DocId", SqlDbType.Int);
                                    param.Value = wc.WashingId;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    SqlParameter paramstatus1 = new SqlParameter("@Status", SqlDbType.Int);
                                    paramstatus1.Direction = ParameterDirection.Output;
                                    cmd.Parameters.Add(paramstatus1);
                                    cmd.ExecuteNonQuery();
                                    status = Convert.ToInt32(paramstatus1.Value);
                                    if (status != 1)
                                    {
                                        trnx.Rollback();
                                        return status + 10;
                                    }
                                    InsertIiChallanDetail(wc.OrderDetailId, crfw, 2, wc.QtyWashReceived, wc.FabricName, wc.FabricDetails, trnx, cnx);
                                }
                            }
                        }
                        if (wc.CuttingCompleted == 0)
                        {
                            if (wc.QtyCutIssued > 0 || wc.IsCompleteCut == 1 || wc.QtyCutReceived > 0)
                            {
                                cmdText = "sp_insert_cutting_issued";

                                cmd = new SqlCommand(cmdText, cnx, trnx);

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                                param = new SqlParameter("@StockId", SqlDbType.Int);
                                param.Value = wc.CutStockId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@QuantityIssued", SqlDbType.Float);
                                param.Value = wc.QtyCutIssued;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                                param.Value = wc.OrderDetailId;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                                param.Value = wc.CreatedBy;
                                param.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param);
                                IdParam = new SqlParameter("@DocId", SqlDbType.Int);
                                IdParam.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(IdParam);
                                paramstatus = new SqlParameter("@Status", SqlDbType.Int);
                                paramstatus.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(paramstatus);
                                cmd.ExecuteNonQuery();

                                status = Convert.ToInt32(paramstatus.Value);
                                if (status != 1)
                                {
                                    trnx.Rollback();
                                    return status + 20;
                                }
                                InsertIiChallanDetail(wc.OrderDetailId, citc, 3, wc.QtyCutIssued, wc.FabricName, wc.FabricDetails, trnx, cnx);
                                wc.CuttingId = Convert.ToInt32(IdParam.Value);

                                if (wc.QtyCutReceived > 0 || wc.IsCompleteCut == 1)
                                {
                                    cmdText = "sp_insert_cutting_received";
                                    cmd = new SqlCommand(cmdText, cnx, trnx);

                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                                    param = new SqlParameter("@StockId", SqlDbType.Int);
                                    param.Value = wc.CutStockId;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                                    param.Value = wc.OrderDetailId;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@QuantityReceived", SqlDbType.Float);
                                    param.Value = wc.QtyCutReceived;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@AvgQty", SqlDbType.Float);
                                    param.Value = wc.AvgLength;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@sComplete", SqlDbType.Int);
                                    param.Value = wc.IsCompleteCut;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                                    param.Value = wc.CreatedBy;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@DocId", SqlDbType.Int);
                                    param.Value = wc.CuttingId;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    param = new SqlParameter("@TaskId", SqlDbType.Int);
                                    param.Value = wc.TaskId;
                                    param.Direction = ParameterDirection.Input;
                                    cmd.Parameters.Add(param);
                                    paramstatus = new SqlParameter("@Status", SqlDbType.Int);
                                    paramstatus.Direction = ParameterDirection.Output;
                                    cmd.Parameters.Add(paramstatus);
                                    cmd.ExecuteNonQuery();
                                    status = Convert.ToInt32(paramstatus.Value);
                                    if (status != 1)
                                    {
                                        trnx.Rollback();
                                        return status + 30;
                                    }
                                }
                            }
                        }
                    }
                    trnx.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    trnx.Rollback();
                    return 0;
                }
            }
        }

        #endregion

        #region CreateChallan()
        private int CreateChallan(int userid, int type, SqlConnection cnx, SqlTransaction trnx)
        {
            string cmdText = "sp_CreateIIChallan";
            SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@UserId", SqlDbType.Int);
            param.Value = userid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Type", SqlDbType.Int);
            param.Value = type;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            SqlParameter oparam = new SqlParameter("@oCid", SqlDbType.Float);
            oparam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(oparam);
            cmd.ExecuteNonQuery();
            int cid = Convert.ToInt32(oparam.Value);
            return cid;
        }
        #endregion

        #region InsertIiChallanDetail
        private void InsertIiChallanDetail(int odId, int cid, int type, double qty, string fabricName, string printcolor, SqlTransaction trnx, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertIIChallanDetail", conn, trnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;
            param = new SqlParameter("@OdId", SqlDbType.Int);
            param.Value = odId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Qty", SqlDbType.Float);
            param.Value = qty;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Cid", SqlDbType.Int);
            param.Value = cid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Type", SqlDbType.Int);
            param.Value = type;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@FabricName", SqlDbType.VarChar);
            param.Value = fabricName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@PrintColor", SqlDbType.VarChar);
            param.Value = printcolor;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region WashingCuttingComplete
        public int WashingCuttingComplete(WashingCuttingTotal wc)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_insert_washing";
                SqlTransaction trnx = cnx.BeginTransaction();
                SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = wc.OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@FabricName", SqlDbType.Int);
                param.Value = wc.FabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@WashComplete", SqlDbType.Int);
                param.Value = wc.IsCompleteWash;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@CutComplete", SqlDbType.Int);
                param.Value = wc.IsCompleteCut;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                return 1;
            }
        }
        #endregion

        #region GetWCDetailByOdIdAndFabric
        public WashingCuttingTotal GetWcDetailByOdIdAndFabric(int orderDetailId, string fabricName, string fabricDetails)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetWCDetailBy_ODId_Fabric";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = orderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricName", SqlDbType.VarChar);
                param.Value = fabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = fabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count < 1 || dataSet.Tables[0].Rows.Count < 1)
                    return null;

                DataRow dataRow = dataSet.Tables[0].Rows[0];
                WashingCuttingTotal wc = new WashingCuttingTotal();
                wc.OrderDetailId = dataRow["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["OrderDetailId"]);
                wc.QtyWashIssuedTotal = dataRow["WashIssuedQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["WashIssuedQuantity"]);
                wc.QtyWashReceivedTotal = dataRow["WashReceivedQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["WashReceivedQuantity"]);
                wc.IsCompleteWash = dataRow["WashComplete"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["WashComplete"]);
                wc.FabricName = dataRow["Fabricname"] == DBNull.Value ? "" : Convert.ToString(dataRow["Fabricname"]);
                wc.QtyCutIssuedTotal = dataRow["CutIssuedQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["CutIssuedQuantity"]);
                wc.QtyCutReceivedTotal = dataRow["CutReceivedQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["CutReceivedQuantity"]);
                wc.IsCompleteCut = dataRow["CutComplete"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["CutComplete"]);
                return wc;
            }
        }
        #endregion

        #region GetWashingCuttingDetailList
        public WashingCuttingList GetWashingCuttingDetailList(int OrderId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetWCDetailList";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count < 1 || dataSet.Tables[0].Rows.Count < 1)
                    return null;
                WashingCuttingList wcl = new WashingCuttingList();
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    WashingCutting wc = new WashingCutting();
                    wc.FabricName = dataRow["FabricName"] == DBNull.Value ? "" : Convert.ToString(dataRow["FabricName"]);
                    wc.PrintColor = dataRow["PrintColor"] == DBNull.Value ? "" : Convert.ToString(dataRow["PrintColor"]);
                    wc.OrderId = dataRow["OrderId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["OrderId"]);
                    wc.OrderDate = dataRow["OrderDate"] == DBNull.Value
                                       ? DateTime.MinValue
                                       : Convert.ToDateTime(dataRow["OrderDate"]);
                    wc.OrderNumber = dataRow["SerialNumber"] == DBNull.Value
                                         ? ""
                                         : Convert.ToString(dataRow["SerialNumber"]);
                    wc.OrderDetailId = dataRow["OrderDetailId"] == DBNull.Value
                                           ? 0
                                           : Convert.ToInt32(dataRow["OrderDetailId"]);
                    wc.ContractNumber = dataRow["ContractNumber"] == DBNull.Value
                                            ? ""
                                            : Convert.ToString(dataRow["ContractNumber"]);
                    wc.LineItemNumber = dataRow["LineItemNumber"] == DBNull.Value
                                            ? ""
                                            : Convert.ToString(dataRow["LineItemNumber"]);
                    wc.Pieces = dataRow["Pieces"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["Pieces"]);
                    wc.StyleId = dataRow["StyleId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StyleId"]);
                    wc.StyleNumber = dataRow["StyleNumber"] == DBNull.Value
                                         ? ""
                                         : Convert.ToString(dataRow["StyleNumber"]);
                    wc.ImageUrl = dataRow["SampleImageURL1"] == DBNull.Value
                                      ? ""
                                      : Convert.ToString(dataRow["SampleImageURL1"]);
                    wc.Department = dataRow["DepartmentName"] == DBNull.Value
                                        ? ""
                                        : Convert.ToString(dataRow["DepartmentName"]);
                    wc.Buyer = dataRow["CompanyName"] == DBNull.Value ? "" : Convert.ToString(dataRow["CompanyName"]);
                    wc.FPRQuantity = dataRow["FPRQuantity"] == DBNull.Value
                                         ? 0
                                         : Convert.ToDouble(dataRow["FPRQuantity"]);
                    wc.Requirement = dataRow["FinalOrder"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["FinalOrder"]);
                    wc.IsWashingRequired = dataRow["IsWashingRequired"] == DBNull.Value
                                               ? 0
                                               : Convert.ToInt32(dataRow["IsWashingRequired"]);
                    wc.MasterPoId = dataRow["MasterPoId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["MasterPoId"]);
                    wc.SrvQuantity = dataRow["SrvQuantity"] == DBNull.Value
                                         ? 0
                                         : Convert.ToDouble(dataRow["SrvQuantity"]);
                    //wc.FPWQuantity = dataRow["FPWQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["FPWQuantity"]);
                    wc.Unit = dataRow["Unit"] == DBNull.Value ? "" : Convert.ToString(dataRow["Unit"]);
                    wc.AvgLength = dataRow["Average"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["Average"]);
                    wc.WashingPerc = dataRow["washing_percent"] == DBNull.Value
                                         ? 0
                                         : Convert.ToInt32(dataRow["washing_percent"]);
                    wc.CuttingPerc = dataRow["cutting_percent"] == DBNull.Value
                                         ? 0
                                         : Convert.ToInt32(dataRow["cutting_percent"]);
                    wc.Balance = wc.Requirement - (wc.Requirement * wc.WashingPerc / 100) - wc.FPRQuantity;
                    wc.CuttingRequirement = wc.Requirement - (wc.Requirement * wc.WashingPerc / 100);
                    //wc.CuttingBalance = wc.CuttingRequirement - (wc.Requirement * wc.CuttingPerc / 100) - wc.FPWQuantity;
                    wc.FPWQuantity = wc.IsWashingRequired == 1
                                         ? (dataRow["FPWQuantity"] == DBNull.Value
                                                ? 0
                                                : Convert.ToDouble(dataRow["FPWQuantity"]))
                                         : (dataRow["FPRQuantity"] == DBNull.Value
                                                ? 0
                                                : Convert.ToDouble(dataRow["FPRQuantity"]));



                    //if (wc.IsWashingRequired == 1)
                    //    wc.CutStockId = dataRow["CutStockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["CutStockId"]);
                    //else
                    //    wc.CutStockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);

                    wc.CuttingBalance = wc.CuttingRequirement - (wc.Requirement * wc.CuttingPerc / 100) -
                                        (wc.IsWashingRequired == 0 ? wc.FPRQuantity : wc.FPWQuantity);
                    //wc.StockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);
                    //wc.ProcessId = dataRow["ProcessId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["ProcessId"]);
                    WashingCuttingTotal wct = GetWcDetailByOdIdAndFabric(wc.OrderDetailId, wc.FabricName, wc.PrintColor);
                    if (wct == null || wct.IsCompleteCut == 0)
                        continue;
                    wc.OrderDetailId = wct.OrderDetailId;
                    wc.QtyWashIssuedTotal = wct.QtyWashIssuedTotal;
                    wc.QtyWashReceivedTotal = wct.QtyWashReceivedTotal;
                    wc.IsCompleteWash = wct.IsCompleteWash;
                    wc.FabricName = wct.FabricName;
                    wc.QtyCutIssuedTotal = wct.QtyCutIssuedTotal;
                    wc.QtyCutReceivedTotal = wct.QtyCutReceivedTotal;
                    wc.IsCompleteCut = wct.IsCompleteCut;
                    wcl.Add(wc);
                }
                return wcl;
            }
        }
        #endregion

        #region GetWcDetailListProgress
        public WashingCuttingList GetWcDetailListProgress(int type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText="";

                if(type==1)
                    cmdText = "sp_GetWCDetailListProgressAll";
                if (type == 2)
                    cmdText = "sp_GetWCDetailListDoneAll";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //SqlParameter param;
                //param = new SqlParameter("@OrderId", SqlDbType.Int);
                //param.Value = orderId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count < 1 || dataSet.Tables[0].Rows.Count < 1)
                    return null;
                WashingCuttingList wcl = new WashingCuttingList();
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    WashingCutting wc = new WashingCutting();
                    wc.FabricName = dataRow["FabricName"] == DBNull.Value ? "" : Convert.ToString(dataRow["FabricName"]);
                    wc.PrintColor = dataRow["PrintColor"] == DBNull.Value ? "" : Convert.ToString(dataRow["PrintColor"]);
                    wc.OrderId = dataRow["OrderId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["OrderId"]);
                    wc.OrderDate = dataRow["OrderDate"] == DBNull.Value
                                       ? DateTime.MinValue
                                       : Convert.ToDateTime(dataRow["OrderDate"]);
                    wc.OrderNumber = dataRow["SerialNumber"] == DBNull.Value
                                         ? ""
                                         : Convert.ToString(dataRow["SerialNumber"]);
                    wc.OrderDetailId = dataRow["OrderDetailId"] == DBNull.Value
                                           ? 0
                                           : Convert.ToInt32(dataRow["OrderDetailId"]);
                    wc.ContractNumber = dataRow["ContractNumber"] == DBNull.Value
                                            ? ""
                                            : Convert.ToString(dataRow["ContractNumber"]);
                    wc.LineItemNumber = dataRow["LineItemNumber"] == DBNull.Value
                                            ? ""
                                            : Convert.ToString(dataRow["LineItemNumber"]);
                    wc.Pieces = dataRow["Pieces"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["Pieces"]);
                    wc.StyleId = dataRow["StyleId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StyleId"]);
                    wc.StyleNumber = dataRow["StyleNumber"] == DBNull.Value
                                         ? ""
                                         : Convert.ToString(dataRow["StyleNumber"]);
                    wc.ImageUrl = dataRow["SampleImageURL1"] == DBNull.Value
                                      ? ""
                                      : Convert.ToString(dataRow["SampleImageURL1"]);
                    wc.Department = dataRow["DepartmentName"] == DBNull.Value
                                        ? ""
                                        : Convert.ToString(dataRow["DepartmentName"]);
                    wc.Buyer = dataRow["CompanyName"] == DBNull.Value ? "" : Convert.ToString(dataRow["CompanyName"]);
                    wc.FPRQuantity = dataRow["FPRQuantity"] == DBNull.Value
                                         ? 0
                                         : Convert.ToDouble(dataRow["FPRQuantity"]);
                    wc.Requirement = dataRow["FinalOrder"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["FinalOrder"]);
                    wc.FcPerc = dataRow["FCPerc"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["FCPerc"]);
                    wc.IsWashingRequired = dataRow["IsWashingRequired"] == DBNull.Value
                                               ? 0
                                               : Convert.ToInt32(dataRow["IsWashingRequired"]);
                    wc.MasterPoId = dataRow["MasterPoId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["MasterPoId"]);
                    wc.SrvQuantity = dataRow["SrvQuantity"] == DBNull.Value
                                         ? 0
                                         : Convert.ToDouble(dataRow["SrvQuantity"]);
                    wc.FPWQuantity = dataRow["FPWQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["FPWQuantity"]);
                    wc.OdSrv = dataRow["OdSrv"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["OdSrv"]);
                    wc.Unit = dataRow["Unit"] == DBNull.Value ? "" : Convert.ToString(dataRow["Unit"]);
                    wc.AvgLength = dataRow["Average"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["Average"]);
                    wc.WashingPerc = dataRow["washing_percent"] == DBNull.Value
                                         ? 0
                                         : Convert.ToInt32(dataRow["washing_percent"]);
                    wc.CuttingPerc = dataRow["cutting_percent"] == DBNull.Value
                                         ? 0
                                         : Convert.ToInt32(dataRow["cutting_percent"]);
                    wc.Balance = wc.Requirement - (wc.Requirement * wc.WashingPerc / 100) - wc.FPRQuantity;
                    wc.CuttingRequirement = wc.Requirement - (wc.Requirement * wc.WashingPerc / 100);
                    wc.FPWQuantity = wc.IsWashingRequired == 1
                                         ? (dataRow["FPWQuantity"] == DBNull.Value
                                                ? 0
                                                : Convert.ToDouble(dataRow["FPWQuantity"]))
                                         : (dataRow["FPRQuantity"] == DBNull.Value
                                                ? 0
                                                : Convert.ToDouble(dataRow["FPRQuantity"]));

                    if (wc.IsWashingRequired == 1)
                        wc.CutStockId = dataRow["CutStockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["CutStockId"]);
                    else
                        wc.CutStockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);

                    wc.CuttingBalance = wc.CuttingRequirement - (wc.Requirement * wc.CuttingPerc / 100) -
                                        (wc.IsWashingRequired == 0 ? wc.FPRQuantity : wc.FPWQuantity);
                    wc.StockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);
                    //wc.ProcessId = dataRow["ProcessId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["ProcessId"]);
                    WashingCuttingTotal wct = GetWcDetailByOdIdAndFabric(wc.OrderDetailId, wc.FabricName, wc.PrintColor);
                    if (wct == null)
                    {
                        wc.QtyWashIssuedTotal = 0;
                        wc.QtyWashReceivedTotal = 0;
                        wc.IsCompleteWash = 0;
                        wc.QtyCutIssuedTotal = 0;
                        wc.QtyCutReceivedTotal = 0;
                        wc.IsCompleteCut = 0;
                    }
                    else
                    {
                        wc.OrderDetailId = wct.OrderDetailId;
                        wc.QtyWashIssuedTotal = wct.QtyWashIssuedTotal;
                        wc.QtyWashReceivedTotal = wct.QtyWashReceivedTotal;
                        wc.IsCompleteWash = wct.IsCompleteWash;
                        wc.QtyCutIssuedTotal = wct.QtyCutIssuedTotal;
                        wc.QtyCutReceivedTotal = wct.QtyCutReceivedTotal;
                        wc.IsCompleteCut = wct.IsCompleteCut;
                    }
                    wcl.Add(wc);
                }

                foreach (WashingCutting wc in wcl)
                {
                    wc.OrderDetailNumber = (from r in wcl where r.OrderDetailId == wc.OrderDetailId select r).Count();
                }

                FSQList fsqList = new FSQList();
                foreach (DataRow dataRow in dataSet.Tables[1].Rows)
                {
                    FabricSrvQuantity fsq = new FabricSrvQuantity();
                    fsq.FabricName = dataRow["FabricName"] == DBNull.Value ? "" : Convert.ToString(dataRow["FabricName"]);
                    fsq.FabricDetails = dataRow["PrintColor"] == DBNull.Value ? "" : Convert.ToString(dataRow["PrintColor"]);
                    fsq.Quantity = dataRow["TotalQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["TotalQty"]);
                    fsqList.Add(fsq);
                }

                foreach (WashingCutting wc in wcl)
                {
                    if (wc.OdSrv != 0)
                        wc.SrvQuantity = wc.OdSrv;
                    else
                    {
                        if (fsqList.Count > 0)
                        {
                            WashingCutting wc1 = wc;
                            List<FabricSrvQuantity> fsq = fsqList.FindAll(
                                r => ToLower(r.FabricName) == ToLower(wc1.FabricName) &&
                                     ToLower(r.FabricDetails) == ToLower(wc1.PrintColor));

                            if (fsq.Count() < 1 || fsq[0].Quantity == 0)
                            {
                                wc.SrvQuantity = 0;
                            }
                            else
                            {
                                if (fsq[0].Quantity > wc.Requirement)
                                {
                                    wc.SrvQuantity = wc.Requirement;
                                    fsq[0].Quantity -= wc.Requirement;
                                }
                                else
                                {
                                    wc.SrvQuantity = fsq[0].Quantity;
                                    fsq[0].Quantity = 0;
                                }
                            }
                        }
                    }
                }
                return wcl;
            }
        }
        #endregion

        #region ToLower
        public string ToLower(string str)
        {
            return str.Trim().ToLower();
        }
        #endregion

        #region GetChallanDetailListt
        public IICDList GetChallanDetailByOdId(int odId, int type, string fabricName, string printcolor)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetIIChallanDetailByOdId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OdId", SqlDbType.Int);
                param.Value = odId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricName", SqlDbType.VarChar);
                param.Value = fabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintcClor", SqlDbType.VarChar);
                param.Value = printcolor;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count < 1 || dataSet.Tables[0].Rows.Count < 1)
                    return null;

                return GetCDListFromTable(dataSet.Tables[0]);
            }
        }

        public IicdPage GetChallanDetailByChallanId(int cid, int type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetIIChallanDetailByChallanId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Cid", SqlDbType.Int);
                param.Value = cid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count < 1 || dataSet.Tables[0].Rows.Count < 1)
                    return null;

                IicdPage iicdPage = new IicdPage();
                iicdPage.Icm = new IIChallan_Main();
                iicdPage.Factory = dataSet.Tables[0];
                DataRow dRow = dataSet.Tables[1].Rows[0];
                iicdPage.Icm.FactoryName = dRow["FactoryName"] == DBNull.Value
                                               ? ""
                                               : Convert.ToString(dRow["FactoryName"]);
                iicdPage.Icm.ChallanNo = dRow["ChallanNo"] == DBNull.Value
                                             ? ""
                                             : Convert.ToString(dRow["ChallanNo"]);
                iicdPage.Icm.ChallanDate = dRow["CreatedOn"] == DBNull.Value
                                               ? DateTime.MinValue
                                               : Convert.ToDateTime(dRow["CreatedOn"]);
                iicdPage.Icm.Id = dRow["Id"] == DBNull.Value
                                      ? 0
                                      : Convert.ToInt32(dRow["Id"]);
                iicdPage.Icm.Type = dRow["Type"] == DBNull.Value ? 0 : Convert.ToInt32(dRow["Type"]);
                iicdPage.Icm.FactoryId = dRow["FactoryId"] == DBNull.Value
                                             ? 0
                                             : Convert.ToInt32(dRow["FactoryId"]);
                iicdPage.Icm.IssuedBy = dRow["IssuedBy"] == DBNull.Value
                                             ? 0
                                             : Convert.ToInt32(dRow["IssuedBy"]);
                iicdPage.Icm.IssuedName = dRow["IssuedName"] == DBNull.Value
                                             ? ""
                                             : Convert.ToString(dRow["IssuedName"]);
                switch (type)
                {
                    case 1:
                        iicdPage.Icm.ChallanFrom = "Fabric";
                        iicdPage.Icm.ChallanTo = "Washing";
                        break;
                    case 2:
                        iicdPage.Icm.ChallanFrom = "Washing";
                        iicdPage.Icm.ChallanTo = "Fabric";
                        break;
                    case 3:
                        iicdPage.Icm.ChallanFrom = "Fabric";
                        iicdPage.Icm.ChallanTo = "Cutting";
                        break;
                }
                iicdPage.LstIIcdAll = new List<IicdAll>();
                foreach (DataRow dataRow in dataSet.Tables[2].Rows)
                {
                    IicdAll cd = new IicdAll();
                    cd.Id = dataRow["Id"] == DBNull.Value
                                ? 0
                                : Convert.ToInt32(dataRow["Id"]);
                    cd.Quantity = dataRow["Quantity"] == DBNull.Value
                                      ? 0
                                      : Convert.ToDouble(dataRow["Quantity"]);
                    cd.Unit = dataRow["Unit"] == DBNull.Value
                                  ? ""
                                  : Convert.ToString(dataRow["Unit"]);
                    cd.FabricName = dataRow["FabricName"] == DBNull.Value
                                        ? ""
                                        : Convert.ToString(dataRow["FabricName"]);
                    cd.PrintColor = dataRow["PrintColor"] == DBNull.Value ? "" : Convert.ToString(dataRow["PrintColor"]);
                    cd.Description = cd.FabricName + " " + cd.PrintColor;
                    cd.Buyer = dataRow["CompanyName"] == DBNull.Value ? "" : Convert.ToString(dataRow["CompanyName"]);
                    cd.Remarks = dataRow["Remarks"] == DBNull.Value ? "" : Convert.ToString(dataRow["Remarks"]);
                    cd.Remarks = cd.Remarks.Replace("\r\n", "<br />");
                    cd.LineNo = dataRow["LineItemNumber"] == DBNull.Value
                                    ? ""
                                    : Convert.ToString(dataRow["LineItemNumber"]);
                    cd.ContractNo = dataRow["contractnumber"] == DBNull.Value
                                        ? ""
                                        : Convert.ToString(dataRow["contractnumber"]);
                    cd.CompanyName = dataRow["CompanyName"] == DBNull.Value
                                         ? ""
                                         : Convert.ToString(dataRow["CompanyName"]);
                    cd.SerialNo = dataRow["serialnumber"] == DBNull.Value
                                      ? ""
                                      : Convert.ToString(dataRow["serialnumber"]);
                    cd.StyleNo = dataRow["stylenumber"] == DBNull.Value
                                     ? ""
                                     : Convert.ToString(dataRow["stylenumber"]);
                    iicdPage.LstIIcdAll.Add(cd);
                }

                return iicdPage;
            }
        }

        public IICDList GetCDListFromTable(DataTable dt)
        {
            IICDList lst = new IICDList();
            foreach (DataRow dataRow in dt.Rows)
            {
                IIChallan_Detail wc = new IIChallan_Detail();
                wc.OrderDetailid = dataRow["OrderDetailId"] == DBNull.Value
                                       ? 0
                                       : Convert.ToInt32(dataRow["OrderDetailId"]);
                wc.ChallanId = dataRow["ChallanId"] == DBNull.Value
                                   ? 0
                                   : Convert.ToInt32(dataRow["ChallanId"]);
                wc.ChallanNo = dataRow["ChallanNo"] == DBNull.Value
                                   ? ""
                                   : Convert.ToString(dataRow["ChallanNo"]);
                wc.Id = dataRow["Id"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(dataRow["Id"]);
                wc.Quantity = dataRow["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["Quantity"]);
                wc.Remarks = dataRow["Remarks"] == DBNull.Value
                                 ? ""
                                 : Convert.ToString(dataRow["Remarks"]);
                wc.FabricName = dataRow["FabricName"] == DBNull.Value
                                ? ""
                                : Convert.ToString(dataRow["FabricName"]);
                wc.PrintColor = dataRow["PrintColor"] == DBNull.Value
                                ? ""
                                : Convert.ToString(dataRow["PrintColor"]);
                wc.Type = dataRow["Type"] == DBNull.Value
                              ? 0
                              : Convert.ToInt32(dataRow["Type"]);
                wc.ChallanDate = dataRow["CreatedOn"] == DBNull.Value
                                     ? DateTime.MinValue
                                     : Convert.ToDateTime(dataRow["CreatedOn"]);
                wc.Unit = dataRow["Unit"] == DBNull.Value
                               ? ""
                               : Convert.ToString(dataRow["Unit"]);
                lst.Add(wc);
            }
            return lst;
        }

        #endregion

        #region 
        public int InsertChallanPage(IicdPage iicdPage)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlTransaction trnx = cnx.BeginTransaction();
                try
                {
                    string cmdText = "sp_InsertIICPage";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@ChallanId", SqlDbType.Int);
                    param.Value = iicdPage.Icm.Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryId", SqlDbType.Int);
                    param.Value = iicdPage.Icm.FactoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = iicdPage.Icm.IssuedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    string tbl = "<table>";
                    foreach (var sc in iicdPage.LstIIcdAll)
                    {
                        tbl += "<Id>" + sc.Id + "</Id>";
                        tbl += "<Remarks>" + sc.Remarks + "</Remarks>";
                    }
                    tbl += "</table>";

                    param = new SqlParameter("@Xml", SqlDbType.VarChar);
                    param.Value = tbl;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Cnt", SqlDbType.Int);
                    param.Value = iicdPage.LstIIcdAll.Count;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    trnx.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    trnx.Rollback();
                    return 0;
                }
            }
        }

        #endregion

        #endregion
    }
}
