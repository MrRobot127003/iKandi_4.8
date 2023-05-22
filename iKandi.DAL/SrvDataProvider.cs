using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.Common.Entities;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    public class SrvDataProvider : EntityBaseDataProvider
    { 
        #region Ctor(s)
        public SrvDataProvider()
        {
        }

        public SrvDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Methods
        #region GetDetailForRCBySRId
        public RCDetail GetDetailForRCBySRId(int srId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "sp_GetDetailForRCBySRId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.VarChar);
                param.Value = srId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                //iProcess
                RCDetail rc = new RCDetail();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    rc.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    rc.Id = srId;
                    rc.SupplierId = reader["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SupplierId"]);
                    rc.SupplierName = reader["SupplierName"] == DBNull.Value ? "" : Convert.ToString(reader["SupplierName"]);
                    rc.GateEntryNo = reader["GateEntryNo"] == DBNull.Value ? "" : Convert.ToString(reader["GateEntryNo"]);
                    rc.ChallanNo = reader["ChallanNo"] == DBNull.Value ? "" : Convert.ToString(reader["ChallanNo"]);
                    rc.ChallanDate = reader["ChallanDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);
                    rc.FabricName = reader["FabricName"] == DBNull.Value ? "" : Convert.ToString(reader["FabricName"]);
                    rc.PoNumber = reader["PoNumber"] == DBNull.Value ? "" : Convert.ToString(reader["PoNumber"]);
                    rc.PoId = reader["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PoId"]);
                    rc.SRVNo = reader["Srvno"] == DBNull.Value ? "" : Convert.ToString(reader["Srvno"]);
                    rc.Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Quantity"]);
                    rc.PoQuantity = reader["PoQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["PoQty"]);
                    rc.Rate = reader["Rate"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Rate"]);
                    rc.Amount = reader["Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Amount"]);
                    rc.Unit = reader["Unit"] == DBNull.Value ? "" : Convert.ToString(reader["Unit"]);
                    rc.PrintColor = reader["printcolor"] == DBNull.Value ? "" : Convert.ToString(reader["printcolor"]);
                    rc.CurrencySymbol = reader["CurrencySymbol"] == DBNull.Value ? "" : Convert.ToString(reader["CurrencySymbol"]);
                }
                return rc;
            }
        }
        #endregion

        #region Insert_Update_SRV
        public int Insert_Update_SRV(RCDetail rcd)
        {
            SqlTransaction transaction = null;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "sp_Insert_Update_Srv";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter SrvId;
                    SrvId = new SqlParameter("@SrvId", SqlDbType.Int);
                    SrvId.Value = rcd.Id;
                    SrvId.Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.Add(SrvId);

                    SqlParameter param;
                    param = new SqlParameter("@SrId", SqlDbType.Int);
                    param.Value = rcd.SrId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PoId", SqlDbType.Int);
                    param.Value = rcd.PoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanNo", SqlDbType.VarChar);
                    param.Value = rcd.ChallanNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDate", SqlDbType.DateTime);
                    param.Value = rcd.ChallanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Description", SqlDbType.VarChar);
                    param.Value = rcd.Description;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvNo", SqlDbType.VarChar);
                    param.Value = rcd.SRVNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvDate", SqlDbType.DateTime);
                    param.Value = rcd.SRVDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    param.Value = rcd.BillNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BillDate", SqlDbType.DateTime);
                    param.Value = rcd.BillDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClaimedQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalThans.ClaimedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalThans.CheckedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RejectedQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalThans.RejectedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LshortQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalThans.LshortQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalThans.ApprovedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnedQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalReturned;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitedQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalDebited;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Decimal);
                    param.Value = rcd.Rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalValue", SqlDbType.Decimal);
                    param.Value = rcd.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = rcd.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReasonForRejection", SqlDbType.VarChar);
                    param.Value = rcd.Rejection;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GateEntryNo", SqlDbType.VarChar);
                    param.Value = rcd.GateEntryNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sFinalize", SqlDbType.Int);
                    param.Value = rcd.IsFinalize;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = rcd.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@U", SqlDbType.VarChar);
                    param.Value = rcd.IU;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskId", SqlDbType.VarChar);
                    param.Value = rcd.TaskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter Status;
                    Status = new SqlParameter("@Status", SqlDbType.VarChar);
                    Status.Value = rcd.Remarks;
                    Status.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(Status);

                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;

                    cmd.ExecuteNonQuery();

                    int status = Convert.ToInt32(Status.Value);

                    if (status == 1)
                    {
                        int srvId = Convert.ToInt32(SrvId.Value);

                        if(rcd.IsFinalize==1)
                        {
                            cmdText = "sp_Stock_Update_Srv";
                            cmd = new SqlCommand(cmdText, cnx, transaction);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                            param = new SqlParameter("@SrvId", SqlDbType.Int);
                            param.Value = srvId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@UserId", SqlDbType.Int);
                            param.Value = rcd.CreatedBy;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            cmd.ExecuteNonQuery();
                        }

                        if (rcd.Thans.Count > 0)
                        {
                            string thans = "<table>";
                            foreach (ThanQuantity tq in rcd.Thans)
                            {
                                thans += "<Id>" + tq.Id + "</Id>";
                                thans += "<ThanNo>" + tq.ThanNo + "</ThanNo>";
                                thans += "<ApprovedQty>" + tq.ApprovedQty + "</ApprovedQty>";
                                thans += "<CheckedQty>" + tq.CheckedQty + "</CheckedQty>";
                                thans += "<ClaimedQty>" + tq.ClaimedQty + "</ClaimedQty>";
                                thans += "<LshortQty>" + tq.LshortQty + "</LshortQty>";
                                thans += "<RejectedQty>" + tq.RejectedQty + "</RejectedQty>";
                            }
                            thans += "</table>";
                            cmdText = "sp_Insert_Update_Srv_Thans";

                            cmd = new SqlCommand(cmdText, cnx, transaction);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                            param = new SqlParameter("@SrvId", SqlDbType.Int);
                            param.Value = srvId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Xml", SqlDbType.VarChar);
                            param.Value = thans;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@U", SqlDbType.Int);
                            param.Value = rcd.IU;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Count", SqlDbType.Int);
                            param.Value = rcd.Thans.Count;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            cmd.ExecuteNonQuery();
                        }
                        if (rcd.Checkers.Count > 0)
                        {
                            InsertDocCheckerDetail(rcd.Checkers,srvId,"SRV",cnx,transaction);

                            //string checkers = rcd.Checkers.Count < 1
                            //                      ? ""
                            //                      : string.Join(",", (from p in rcd.Checkers select p).ToArray());
                            //cmdText = "sp_Insert_Update_doc_checker_details";

                            //cmd = null;
                            //cmd = new SqlCommand(cmdText, cnx, transaction);

                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.CommandTimeout =Constants.CONFIGURATION_TimeOut;
                            //param = new SqlParameter("@SrvId", SqlDbType.Int);
                            //param.Value = srvId;
                            //param.Direction = ParameterDirection.Input;
                            //cmd.Parameters.Add(param);

                            //param = new SqlParameter("@Checkers", SqlDbType.VarChar);
                            //param.Value = checkers;
                            //param.Direction = ParameterDirection.Input;
                            //cmd.Parameters.Add(param);

                            //param = new SqlParameter("@DocCheckType", SqlDbType.VarChar);
                            //param.Value = "SRV";
                            //param.Direction = ParameterDirection.Input;
                            //cmd.Parameters.Add(param);

                            //cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();

                    cnx.Close();
                    return status;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
            }
        }
        #endregion

        #region GetRCDetailById
        public RCDetail GetRCDetailById(int srvId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_GetSrvDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = srvId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                //iProcess
                RCDetail rc = new RCDetail();
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1 || dsFabricQuality.Tables[0].Rows.Count < 1)
                    return null;
                DataRow dataRow = dsFabricQuality.Tables[0].Rows[0];
                rc.Id = dataRow["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["Id"]);
                rc.PoId = dataRow["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["PoId"]);
                rc.ChallanNo = dataRow["ChallanNo"] == DBNull.Value ? "" : Convert.ToString(dataRow["ChallanNo"]);
                rc.ChallanDate = dataRow["ChallanDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow["ChallanDate"]);
                rc.Description = dataRow["Description"] == DBNull.Value ? "" : Convert.ToString(dataRow["Description"]);
                rc.SRVNo = dataRow["SRVNo"] == DBNull.Value ? "" : Convert.ToString(dataRow["SRVNo"]);
                rc.SRVDate = dataRow["SRVDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow["SRVDate"]);
                rc.BillNo = dataRow["BillNo"] == DBNull.Value ? "" : Convert.ToString(dataRow["BillNo"]);
                rc.BillDate = dataRow["BillDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow["BillDate"]);
                rc.TotalThans = new ThanQuantity();
                rc.TotalThans.LshortQty = dataRow["LshortQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["LshortQty"]);
                rc.TotalThans.ClaimedQty = dataRow["ClaimedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["ClaimedQty"]);
                rc.TotalThans.ApprovedQty = dataRow["ApprovedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["ApprovedQty"]);
                rc.TotalThans.CheckedQty = dataRow["CheckedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["CheckedQty"]);
                rc.TotalThans.RejectedQty = dataRow["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["RejectedQty"]);
                rc.TotalThans.ReturnedQty = dataRow["ReturnedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["ReturnedQty"]);
                //rc.TotalThans.ClaimedQty -= rc.TotalThans.ReturnedQty;
                rc.Rate = dataRow["Rate"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["Rate"]);
                rc.Value = dataRow["TotalValue"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["TotalValue"]);
                rc.TotalRejected = dataRow["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["RejectedQty"]);
                rc.TotalReturned = dataRow["ReturnedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["ReturnedQty"]);
                rc.TotalDebited = dataRow["DebitedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["DebitedQty"]);
                rc.Remarks = dataRow["Remarks"] == DBNull.Value ? "" : Convert.ToString(dataRow["Remarks"]);
                rc.Rejection = dataRow["ReasonForRejection"] == DBNull.Value ? "" : Convert.ToString(dataRow["ReasonForRejection"]);
                rc.GateEntryNo = dataRow["GateEntryNo"] == DBNull.Value ? "" : Convert.ToString(dataRow["GateEntryNo"]);
                rc.StockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);
                rc.IsFinalize = dataRow["IsFinalize"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["IsFinalize"]);
                rc.Unit = dataRow["Unit"] == DBNull.Value ? "" : Convert.ToString(dataRow["Unit"]);
                if (dsFabricQuality.Tables[1].Rows.Count > 0)
                {
                    rc.Thans = new List<ThanQuantity>();
                    foreach (DataRow dr in dsFabricQuality.Tables[1].Rows)
                    {
                        ThanQuantity thanQuantity = new ThanQuantity();
                        thanQuantity.LshortQty = dr["LshortQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["LshortQty"]);
                        thanQuantity.ClaimedQty = dr["ClaimedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ClaimedQty"]);
                        thanQuantity.ApprovedQty = dr["ApprovedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ApprovedQty"]);
                        thanQuantity.CheckedQty = dr["CheckedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["CheckedQty"]);
                        thanQuantity.RejectedQty = dr["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["RejectedQty"]);
                        thanQuantity.ReturnedQty = dr["ReturnedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ReturnedQty"]);
                        //thanQuantity.ClaimedQty -= thanQuantity.ReturnedQty;
                        thanQuantity.Id = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"]);
                        thanQuantity.ThanNo = dr["ThanNo"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ThanNo"]);
                        rc.Thans.Add(thanQuantity);
                    }
                }
                if (dsFabricQuality.Tables[2].Rows.Count > 0)
                {
                    rc.Checkers = new List<string>();
                    foreach (DataRow dr in dsFabricQuality.Tables[2].Rows)
                    {
                        rc.Checkers.Add(dr["CheckedBy"] == DBNull.Value ? "" : Convert.ToString(dr["CheckedBy"]));
                    }
                }
                if (dsFabricQuality.Tables[3].Rows.Count > 0)
                {
                    rc.SrId = Convert.ToInt32(dsFabricQuality.Tables[3].Rows[0]["SrId"]);
                }
                return rc;
            }
        }
        #endregion

        #region GetRCDetailList
        public List<RCDetail> GetRCDetailList(string ponumber, string suppliername, string fabricname, string challanno)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_GetSrvDetailsList";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@PoNo", SqlDbType.VarChar);
                param.Value = ponumber.Trim();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = suppliername.Trim();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricName", SqlDbType.VarChar);
                param.Value = fabricname.Trim();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNo", SqlDbType.VarChar);
                param.Value = challanno.Trim();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                //iProcess

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1 || dsFabricQuality.Tables[0].Rows.Count < 1)
                    return null;
                List<RCDetail> rcList = new List<RCDetail>();
                foreach (DataRow dataRow in dsFabricQuality.Tables[0].Rows)
                {
                    RCDetail rc = new RCDetail();
                    rc.Id = dataRow["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["Id"]);
                    rc.PoId = dataRow["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["PoId"]);
                    rc.ChallanNo = dataRow["ChallanNo"] == DBNull.Value ? "" : Convert.ToString(dataRow["ChallanNo"]);
                    rc.ChallanDate = dataRow["ChallanDate"] == DBNull.Value
                                         ? DateTime.MinValue
                                         : Convert.ToDateTime(dataRow["ChallanDate"]);
                    rc.Description = dataRow["Description"] == DBNull.Value
                                         ? ""
                                         : Convert.ToString(dataRow["Description"]);
                    rc.SRVNo = dataRow["SRVNo"] == DBNull.Value ? "" : Convert.ToString(dataRow["SRVNo"]);
                    rc.SRVDate = dataRow["SRVDate"] == DBNull.Value
                                     ? DateTime.MinValue
                                     : Convert.ToDateTime(dataRow["SRVDate"]);
                    rc.BillNo = dataRow["BillNo"] == DBNull.Value ? "" : Convert.ToString(dataRow["BillNo"]);
                    rc.BillDate = dataRow["BillDate"] == DBNull.Value
                                      ? DateTime.MinValue
                                      : Convert.ToDateTime(dataRow["BillDate"]);
                    rc.TotalThans = new ThanQuantity();
                    rc.TotalThans.LshortQty = dataRow["LshortQty"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToInt32(dataRow["LshortQty"]);
                    rc.TotalThans.ClaimedQty = dataRow["ClaimedQty"] == DBNull.Value
                                                   ? 0
                                                   : Convert.ToDouble(dataRow["ClaimedQty"]);
                    rc.TotalThans.ApprovedQty = dataRow["ApprovedQty"] == DBNull.Value
                                                    ? 0
                                                    : Convert.ToDouble(dataRow["ApprovedQty"]);
                    rc.TotalThans.CheckedQty = dataRow["CheckedQty"] == DBNull.Value
                                                   ? 0
                                                   : Convert.ToDouble(dataRow["CheckedQty"]);
                    rc.TotalThans.RejectedQty = dataRow["RejectedQty"] == DBNull.Value
                                                    ? 0
                                                    : Convert.ToDouble(dataRow["RejectedQty"]);
                    rc.TotalThans.DebitedQty = dataRow["DebitedQty"] == DBNull.Value
                                                    ? 0
                                                    : Convert.ToDouble(dataRow["DebitedQty"]);
                    rc.TotalThans.ReturnedQty = dataRow["ReturnedQty"] == DBNull.Value
                                                    ? 0
                                                    : Convert.ToInt32(dataRow["ReturnedQty"]);
                    rc.Rate = dataRow["Rate"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["Rate"]);
                    rc.Value = dataRow["TotalValue"] == DBNull.Value ? 0 : Convert.ToDouble(dataRow["TotalValue"]);
                    rc.Remarks = dataRow["Remarks"] == DBNull.Value ? "" : Convert.ToString(dataRow["Remarks"]);
                    rc.Rejection = dataRow["ReasonForRejection"] == DBNull.Value
                                       ? ""
                                       : Convert.ToString(dataRow["ReasonForRejection"]);
                    rc.GateEntryNo = dataRow["GateEntryNo"] == DBNull.Value
                                         ? ""
                                         : Convert.ToString(dataRow["GateEntryNo"]);
                    rc.SupplierName = dataRow["SupplierName"] == DBNull.Value
                                       ? ""
                                       : Convert.ToString(dataRow["SupplierName"]);
                    rc.PoNumber = dataRow["PoNumber"] == DBNull.Value
                                       ? ""
                                       : Convert.ToString(dataRow["PoNumber"]);
                    rc.StockId = dataRow["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["StockId"]);
                    rc.IsFinalize = dataRow["IsFinalize"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["IsFinalize"]);
                    rcList.Add(rc);
                }
                return rcList;
            }
        }
        #endregion

        #region GetPoNumberByName
        public List<string> GetPoNumberByName(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "sp_GetPoNumberByName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@PoNumber", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["PoNumber"]));
                }
                return result;
            }
        }
        #endregion

        #region GetChallanNoByName
        public List<string> GetChallanNoByName(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "sp_GetChallanNoByName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ChallanNo", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ChallanNo"]));
                }
                return result;
            }
        }
        #endregion

        #region GetDescriptionByName
        public List<string> GetDescriptionByName(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "sp_GetDescriptionByName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Description", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["Description"]));
                }
                return result;
            }
        }
        #endregion

        #region Insert_Update_SRVReturn
        public int Insert_Update_SRVReturn(RCDetail rcd)
        {
            SqlTransaction transaction = null;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "sp_Insert_Update_SupplierReturnChecking";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter idparam;
                    idparam = new SqlParameter("@d", SqlDbType.Int);
                    idparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idparam);

                    SqlParameter param;
                    param = new SqlParameter("@SupplierId", SqlDbType.Int);
                    param.Value = rcd.SupplierId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SRVId", SqlDbType.Int);
                    param.Value = rcd.Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanNo", SqlDbType.VarChar);
                    param.Value = rcd.ChallanNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RejectedQty", SqlDbType.VarChar);
                    param.Value = rcd.TotalThans.RejectedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NullifyQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalThans.NullifyQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnedQty", SqlDbType.Decimal);
                    param.Value = rcd.TotalThans.QtyReturned;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RejectReason", SqlDbType.VarChar);
                    param.Value = rcd.Rejection;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = rcd.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = rcd.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@U", SqlDbType.VarChar);
                    param.Value = rcd.IU;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskId", SqlDbType.VarChar);
                    param.Value = rcd.TaskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter Status;
                    Status = new SqlParameter("@Status", SqlDbType.VarChar);
                    Status.Value = rcd.Remarks;
                    Status.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(Status);

                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;

                    cmd.ExecuteNonQuery();

                    int status = Convert.ToInt32(Status.Value);

                    if (status == 1)
                    {
                        int srId = Convert.ToInt32(idparam.Value);
                        cmdText = "sp_Stock_Update_SrvReturn";

                        cmd = new SqlCommand(cmdText, cnx, transaction);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        param = new SqlParameter("@SrvId", SqlDbType.Int);
                        param.Value = rcd.Id;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SrId", SqlDbType.Int);
                        param.Value = srId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ReturnedQty", SqlDbType.Decimal);
                        param.Value = rcd.TotalThans.QtyReturned - rcd.TotalThans.NullifyQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@RejectedQty", SqlDbType.Decimal);
                        param.Value = rcd.TotalRejected;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@UserId", SqlDbType.Int);
                        param.Value = rcd.CreatedBy;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        Status = new SqlParameter("@Status", SqlDbType.Int);
                        Status.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(Status);

                        cmd.ExecuteNonQuery();
                        status = Convert.ToInt32(Status.Value);
                        if(status != 1)
                        {
                            transaction.Rollback();
                            return status + 10;
                        }

                        if (rcd.Thans.Count > 0)
                        {
                            string thans = "<table>";
                            foreach (ThanQuantity tq in rcd.Thans)
                            {
                                thans += "<Id>" + tq.Id + "</Id>";
                                thans += "<ThanNo>" + tq.ThanNo + "</ThanNo>";
                                thans += "<ReturnedQty>" + tq.QtyReturned + "</ApprovedQty>";
                            }
                            thans += "</table>";
                            cmdText = "sp_Insert_Update_Return_Thans";

                            cmd = new SqlCommand(cmdText, cnx, transaction);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                            param = new SqlParameter("@SrvId", SqlDbType.Int);
                            param.Value = rcd.Id;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Xml", SqlDbType.VarChar);
                            param.Value = thans;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@U", SqlDbType.Int);
                            param.Value = rcd.IU;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Count", SqlDbType.Int);
                            param.Value = rcd.Thans.Count;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            cmd.ExecuteNonQuery();
                        }
                        if (rcd.Checkers.Count > 0)
                        {
                            InsertDocCheckerDetail(rcd.Checkers,srId,"SRET",cnx,transaction);
                            //string checkers = rcd.Checkers.Count < 1
                            //                      ? ""
                            //                      : string.Join(",", (from p in rcd.Checkers select p).ToArray());
                            //cmdText = "sp_Insert_Update_doc_checker_details";

                            //cmd = null;
                            //cmd = new SqlCommand(cmdText, cnx, transaction);

                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.CommandTimeout =Constants.CONFIGURATION_TimeOut;
                            //param = new SqlParameter("@SrvId", SqlDbType.Int);
                            //param.Value = srId;
                            //param.Direction = ParameterDirection.Input;
                            //cmd.Parameters.Add(param);
                            
                            //param = new SqlParameter("@Checkers", SqlDbType.VarChar);
                            //param.Value = checkers;
                            //param.Direction = ParameterDirection.Input;
                            //cmd.Parameters.Add(param);

                            //param = new SqlParameter("@DocCheckType", SqlDbType.VarChar);
                            //param.Value = "SRet";
                            //param.Direction = ParameterDirection.Input;
                            //cmd.Parameters.Add(param);

                            //cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();

                    cnx.Close();
                    return status;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
            }
        }
        #endregion

        #region GetEIChallanHeader
        public EiChallan GetEIChallanHeader(int poid, int stockId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "sp_Get_ExtChallanHeader";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@PoId", SqlDbType.Int);
                param.Value = poid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StockId", SqlDbType.Int);
                param.Value = stockId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    EiChallan eic = new EiChallan();
                    eic.PoNumber = reader["ponumber"] == DBNull.Value ? "" : Convert.ToString(reader["ponumber"]);
                    eic.SupplierName = reader["suppliername"] == DBNull.Value ? "" : Convert.ToString(reader["suppliername"]);
                    eic.ChallanNo = reader["ChallanNo"] == DBNull.Value ? "" : Convert.ToString(reader["ChallanNo"]);
                    eic.FabricName = reader["fabricname"] == DBNull.Value ? "" : Convert.ToString(reader["fabricname"]);
                    eic.PrintColor = reader["printcolor"] == DBNull.Value ? "" : Convert.ToString(reader["printcolor"]);
                    eic.Quantity = reader["quantity"] == DBNull.Value ? 0 : Convert.ToDouble(reader["quantity"]);
                    eic.Unit = reader["unit"] == DBNull.Value ? "" : Convert.ToString(reader["unit"]);
                    eic.StockQuantity = reader["StockQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(reader["StockQuantity"]);
                    eic.RejectedQuantity = reader["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["RejectedQty"]);
                    eic.PoId = poid;
                    eic.StockId = stockId;
                    return eic;
                }
                return null;
            }
        }
        #endregion

        #region Insert External Issue Challan
        public int Insert_Update_EIChallan(EiChallan eic)
        {
            SqlTransaction transaction = null;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "sp_insert_EIChallan_Main";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StockId", SqlDbType.Int);
                    param.Value = eic.StockId;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PoId", SqlDbType.Int);
                    param.Value = eic.PoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Description", SqlDbType.VarChar);
                    param.Value = eic.Description;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalQty", SqlDbType.Float);
                    param.Value = eic.Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = eic.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@U", SqlDbType.Int);
                    param.Value = eic.IU;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskId", SqlDbType.Int);
                    param.Value = eic.TaskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Reprocess", SqlDbType.Int);
                    param.Value = eic.IsReProcessed;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter idparam;
                    idparam = new SqlParameter("@d", SqlDbType.Int);
                    idparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idparam);

                    SqlParameter sparam;
                    sparam = new SqlParameter("@Status", SqlDbType.Int);
                    sparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(sparam);                    

                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;

                    cmd.ExecuteNonQuery();

                    int status = Convert.ToInt32(sparam.Value);

                    if (status == 1)
                    {
                        int srId = Convert.ToInt32(idparam.Value);

                        if (eic.ThanList.Count() > 0)
                        {
                            string thans = "<table>";
                            foreach (EIChallanThanDetail tq in eic.ThanList)
                            {
                                thans += "<SlNo>" + tq.ThanNo + "</SlNo>";
                                thans += "<Quantity>" + tq.Quantity + "</Quantity>";
                            }
                            thans += "</table>";
                            cmdText = "sp_insert_EIChallan_Than";

                            cmd = new SqlCommand(cmdText, cnx, transaction);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                            param = new SqlParameter("@ChallanId", SqlDbType.Int);
                            param.Value = srId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Xml", SqlDbType.VarChar);
                            param.Value = thans;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Count", SqlDbType.Int);
                            param.Value = eic.ThanList.Count();
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            cmd.ExecuteNonQuery();
                        }
                        if (eic.Checkers.Count > 0)
                        {
                            InsertDocCheckerDetail(eic.Checkers, srId, "EIC", cnx, transaction);
                        }
                    }
                    transaction.Commit();

                    cnx.Close();
                    return status;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
            }
        }
        #endregion

        #region GetSRCQHeader
        public SRCQ GetSRCQHeader(int FpId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "Sp_GetSRCQHeader";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@FpId", SqlDbType.Int);
                param.Value = FpId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    SRCQ eic = new SRCQ();
                    eic.FpId = reader["FpId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FpId"]);
                    eic.ReturnedQty = reader["ReturnedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["ReturnedQty"]);
                    eic.RejectedQty = reader["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(reader["RejectedQty"]);
                    eic.PoId = reader["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PoId"]);
                    eic.SupplierId = reader["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SupplierId"]);
                    eic.PoNumber = reader["ponumber"] == DBNull.Value ? "" : Convert.ToString(reader["ponumber"]);
                    eic.SupplierName = reader["suppliername"] == DBNull.Value ? "" : Convert.ToString(reader["suppliername"]);
                    eic.ChallanNo = reader["ChallanNo"] == DBNull.Value ? "" : Convert.ToString(reader["ChallanNo"]);
                    eic.FabricName = reader["fabricname"] == DBNull.Value ? "" : Convert.ToString(reader["fabricname"]);
                    eic.PrintColor = reader["printcolor"] == DBNull.Value ? "" : Convert.ToString(reader["printcolor"]);
                    eic.Unit = reader["unit"] == DBNull.Value ? "" : Convert.ToString(reader["unit"]);
                    eic.StockQuantity = reader["Rejected"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Rejected"]);
                    eic.StockId = reader["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["StockId"]);
                    return eic;
                }
                return null;
            }
        }
        #endregion

        #region GetSRChallanNo
        public string GetSRChallanNo(int id,int type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_GetReturnChallanNo";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter oparam = new SqlParameter("@oChallanNo", SqlDbType.VarChar);
                oparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oparam);

                cmd.ExecuteNonQuery();

                return Convert.ToString(oparam.Value);

            }
        }
        #endregion

        #region Insert External Supplier Return Challan Quality
        public int Insert_Update_SRCQ(SRCQ eic)
        {
            SqlTransaction transaction = null;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "sp_insert_SRCQ";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StockId", SqlDbType.Int);
                    param.Value = eic.StockId;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PoId", SqlDbType.Int);
                    param.Value = eic.PoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RoRejection", SqlDbType.VarChar);
                    param.Value = eic.Rejection;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = eic.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnedQty", SqlDbType.Float);
                    param.Value = eic.ReturnedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    
                    param = new SqlParameter("@RejectedQty", SqlDbType.Float);
                    param.Value = eic.RejectedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NullifyQty", SqlDbType.Float);
                    param.Value = eic.NullifyQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FpId", SqlDbType.Int);
                    param.Value = eic.FpId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = eic.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@U", SqlDbType.Int);
                    param.Value = eic.IU;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskId", SqlDbType.Int);
                    param.Value = eic.TaskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter idparam;
                    idparam = new SqlParameter("@d", SqlDbType.Int);
                    idparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idparam);

                    SqlParameter sparam;
                    sparam = new SqlParameter("@Status", SqlDbType.Int);
                    sparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(sparam);

                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;

                    cmd.ExecuteNonQuery();

                    int status = Convert.ToInt32(sparam.Value);

                    if (status == 1)
                    {
                        int srId = Convert.ToInt32(idparam.Value);

                        if (eic.ThanList.Count() > 0)
                        {
                            string thans = "<table>";
                            foreach (EIChallanThanDetail tq in eic.ThanList)
                            {
                                thans += "<SlNo>" + tq.ThanNo + "</SlNo>";
                                thans += "<Quantity>" + tq.Quantity + "</Quantity>";
                            }
                            thans += "</table>";
                            cmdText = "sp_insert_SRCQ_Than";

                            cmd = new SqlCommand(cmdText, cnx, transaction);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                            param = new SqlParameter("@ChallanId", SqlDbType.Int);
                            param.Value = srId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Xml", SqlDbType.VarChar);
                            param.Value = thans;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Count", SqlDbType.Int);
                            param.Value = eic.ThanList.Count();
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            cmd.ExecuteNonQuery();
                        }
                        if (eic.Checkers.Count > 0)
                        {
                            InsertDocCheckerDetail(eic.Checkers, srId, "SRCQ", cnx, transaction);
                        }
                    }
                    transaction.Commit();

                    cnx.Close();
                    return status;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return -1;
                }
            }
        }
        #endregion

        #region GetDuplicateSrvByPoId_BillNo
        public int GetDuplicateSrvByPoId_BillNo(int poId,string billNo,int srvId)
        {
            //sp_Get_Srv_By_POID_BillNo
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "sp_Get_Srv_By_POID_BillNo";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = null;

                    param = new SqlParameter("@PoId", SqlDbType.Int);
                    param.Value = poId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    param.Value = billNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvId", SqlDbType.VarChar);
                    param.Value = srvId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter cparam = new SqlParameter("@Cnt", SqlDbType.Int);
                    cparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(cparam);

                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(cparam.Value);
                }catch(Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return 0;
            }
        }
        #endregion


/// <summary>
/// Yaten: Dabit Mgmt 
/// </summary>
/// <param name="TaskId"></param>
/// <param name="SupName"></param>
/// <param name="PoNumber"></param>
/// <returns></returns>
        public DataSet GetAllDebitNoteDAL(int TaskId,string SupName,string PoNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
               cmdText = "sp_GetAllDebitNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.VarChar);
                param.Value = TaskId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = SupName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@PoNumber", SqlDbType.VarChar);
                param.Value = PoNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsclient);
                return (dsclient);
            }
        }

        /// <summary>
        /// Yaten : All Credit Note "After compliting approval Debit Mgmt." 
        /// </summary>
        /// <param name="supplierName"></param>
        /// <param name="PoNumber"></param>
        /// <returns></returns>

        public DataSet GetAllCreditNoteDAL(string supplierName, string PoNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_Get_AllCreditNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = supplierName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoNumber", SqlDbType.VarChar);
                param.Value = PoNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsclient);
                return (dsclient);
            }
        }



        /// <summary>
        /// Yaten : Get All DebitNote From Srv,FPC and Other
        /// </summary>
        /// <param name="sup"></param>
        /// <param name="PoTyp"></param>
        /// <param name="Fab"></param>
        /// <param name="PoNo"></param>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <returns></returns>

        public DataSet GetAllDebitCreditNoteDAL(string sup, int PoTyp, string Fab, string PoNo, DateTime dtFrom, DateTime dtTo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_Get_AllCrediDebitNot";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = sup;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoType", SqlDbType.Int);
                param.Value = PoTyp;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQuality", SqlDbType.VarChar);
                param.Value = Fab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoNumber", SqlDbType.VarChar);
                param.Value = PoNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDead", SqlDbType.DateTime);
                param.Value = dtFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromToDead", SqlDbType.DateTime);
                param.Value = dtTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsclient);
                return (dsclient);
            }
        }

        /// <summary>
        /// Yaten: Insert DebitNote Data for DebitMgmt Fabric Approval 
        /// </summary>
        /// <param name="Qty"></param>
        /// <param name="Amount"></param>
        /// <param name="intPOID"></param>
        /// <param name="stringXMLData"></param>
        /// <param name="stringReason"></param>
        /// <param name="SupName"></param>
        /// <returns></returns>
        public string InserCreditNoteDAL(string Qty, double Amount, int intPOID, string stringXMLData, string stringReason, string SupName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();


                string cmdText = "sp_insert_DebitNote";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Qty", SqlDbType.VarChar);
                param.Value = Qty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount", SqlDbType.Float);
                param.Value = Amount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@POID", SqlDbType.VarChar);
                param.Value = intPOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Xml", SqlDbType.VarChar);
                param.Value = stringXMLData;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Reason", SqlDbType.VarChar);
                param.Value = stringReason;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupName", SqlDbType.VarChar);
                param.Value = SupName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlParameter param1;
                param1 = new SqlParameter("@oId", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);

                cmd.ExecuteNonQuery();

                string OutPutId = string.Empty;
                if (param1.Value != DBNull.Value)
                {
                    OutPutId = Convert.ToString(param1.Value);
                }
                else
                {
                    OutPutId = "";
                }
                return OutPutId;
            }
        }


        /// <summary>
        /// Yaten : For Insert DebitNoteData For Approval
        /// </summary>
        /// <param name="RecValue"></param>
        /// <param name="RecType"></param>
        /// <param name="Reason"></param>
        /// <param name="NetAmount"></param>
        /// <param name="FabId"></param>
        /// <param name="FinanceId"></param>
        /// <param name="Id"></param>
        /// <param name="TaskToFinish"></param>
        /// <param name="TaskType"></param>
        public void InsertDebitNoteManagmentDAL(double RecValue, int RecType, string Reason, double NetAmount, int FabId, int FinanceId, int Id, int TaskToFinish, int TaskType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                //int intReturn;
                cnx.Open();
                string cmdText = "sp_InsertDebitManagement";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                //iID INT,iConversion FLOAT,iType VARCHAR(20),iSymbol VARCHAR(10)
                param = new SqlParameter("@ReconcilationValue", SqlDbType.Float);
                param.Value = RecValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReconcilationType", SqlDbType.Int);
                param.Value = RecType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Reason", SqlDbType.VarChar);
                param.Value = Reason;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NetAmount", SqlDbType.Float);

                param.Value = NetAmount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricDepttId", SqlDbType.Int);

                param.Value = FabId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FinanceDepttId", SqlDbType.Int);

                param.Value = FinanceId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@d", SqlDbType.Int);

                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskToFinish", SqlDbType.Int);

                param.Value = TaskToFinish;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskType", SqlDbType.Int);

                param.Value = TaskType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
             
                

           


                cmd.ExecuteNonQuery();


             
               


                cnx.Close();

                



            }

        }





        /// <summary>
        /// yaten: For insertint Credit Detail
        /// </summary>
        /// <param name="Qty"></param>
        /// <param name="Amount"></param>
        /// <param name="intPOID"></param>
        /// <param name="stringXMLData"></param>
        /// <param name="stringReason"></param>
        /// <param name="SupName"></param>
        /// <returns></returns>
        //(iSupName VARCHAR(50),iAmount DOUBLE,iRemarks VARCHAR(2000),iUserId INT,iXmlTable2 VARCHAR(2000),iXmlTable3 VARCHAR(2000),oId VARCHAR(50))
        public string InsertCreditNoteDetailDAL(string SupName, double Amount, string Remarks,int UserId,string XmlDetail,string XmlPODeiakl)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();


                string cmdText = "sp_InsertCreditNote";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SupName", SqlDbType.VarChar);
                param.Value = SupName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount", SqlDbType.Float);
                param.Value = Amount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = Remarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.VarChar);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@XmlTable2", SqlDbType.VarChar);
                param.Value = XmlDetail;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@XmlTable3", SqlDbType.VarChar);
                param.Value = XmlPODeiakl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlParameter param1;
                param1 = new SqlParameter("@oId", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);

                cmd.ExecuteNonQuery();

                string OutPutId = string.Empty;
                if (param1.Value != DBNull.Value)
                {
                    OutPutId = Convert.ToString(param1.Value);
                }
                else
                {
                    OutPutId = "";
                }
                return OutPutId;
            }
        }



        /// <summary>
        ///  Get PopUp data By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public DataSet DebitNotePopUpDAL(int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_DebitNotePopUp";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
              
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsclient);
                return (dsclient);
            }
        }



        /// <summary>
        /// Yaten : For Insert CreditNoteData For Approval
        /// </summary>
        /// <param name="RecValue"></param>
        /// <param name="RecType"></param>
        /// <param name="Reason"></param>
        /// <param name="NetAmount"></param>
        /// <param name="FabId"></param>
        /// <param name="FinanceId"></param>
        /// <param name="Id"></param>
        /// <param name="TaskToFinish"></param>
        /// <param name="TaskType"></param>

        public void InsertCreditNoteManagmentDAL(double RecValue, int RecType, string Reason, double NetAmount, int FabId, int FinanceId, int Id, int TaskToFinish, int TaskType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                //int intReturn;
                cnx.Open();
                string cmdText = "sp_InsertCreditManagement";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                //iID INT,iConversion FLOAT,iType VARCHAR(20),iSymbol VARCHAR(10)
                param = new SqlParameter("@ReconValue", SqlDbType.Float);
                param.Value = RecValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReconType", SqlDbType.Int);
                param.Value = RecType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReconReason", SqlDbType.VarChar);
                param.Value = Reason;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
              




                param = new SqlParameter("@NetAmount", SqlDbType.Float);

                param.Value = NetAmount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricDepttId", SqlDbType.Int);

                param.Value = FabId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FinanceDepttId", SqlDbType.Int);

                param.Value = FinanceId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@d", SqlDbType.Int);

                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskToFinish", SqlDbType.Int);

                param.Value = TaskToFinish;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TaskType", SqlDbType.Int);

                param.Value = TaskType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);






                cmd.ExecuteNonQuery();






                cnx.Close();





            }

        }



        /// <summary>
        /// yaten : Get Data After save Confirmation page
        /// </summary>
        /// <param name="sup"></param>
        /// <param name="PoTyp"></param>
        /// <param name="Fab"></param>
        /// <param name="PoNo"></param>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <returns></returns>
        public DataSet GetAllDebitCreditNoteDALAfterSave(string sup, int PoTyp, string Fab, string PoNo, DateTime dtFrom, DateTime dtTo, string PONumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_Get_AllCrediDebitNotAfterSave";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = sup;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoType", SqlDbType.Int);
                param.Value = PoTyp;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabQuality", SqlDbType.VarChar);
                param.Value = Fab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoNumber", SqlDbType.VarChar);
                param.Value = PoNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDead", SqlDbType.DateTime);
                param.Value = dtFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromToDead", SqlDbType.DateTime);
                param.Value = dtTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoNumberAfterSave", SqlDbType.VarChar);
                param.Value = PONumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsclient);
                return (dsclient);
            }
        }


        #endregion
    }
}
