
using System;
using System.Collections.Generic;
using System.Data;
using iKandi.Common;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    public class FourPointDataProvider : EntityBaseDataProvider
    {
        #region Ctor(s)
        public FourPointDataProvider()
        {
        }

        public FourPointDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }
        #endregion

        #region Methods

        #region GetFourPointCheck
        public List<FourPointCheckAdmin> GetFourPointCheck(int tableId, int id)
        {
            List<FourPointCheckAdmin> lst = new List<FourPointCheckAdmin>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetFourPointAdmin";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Table", SqlDbType.Int);
                param.Value = tableId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                DataTable FabricQualityTable = dsFabricQuality.Tables[0];
                lst = GetFourPointCheckAdminList(FabricQualityTable);
                return lst;
            }
        }
        #endregion

        #region GetFourPointCheckAdminList
        public List<FourPointCheckAdmin> GetFourPointCheckAdminList(DataTable dataTable)
        {
            List<FourPointCheckAdmin> lst = new List<FourPointCheckAdmin>();
            foreach (DataRow rows in dataTable.Rows)
            {
                FourPointCheckAdmin fpc = new FourPointCheckAdmin();
                fpc.Id = rows["fourpt_admin_id"] == DBNull.Value ? 0 : Convert.ToInt32(rows["fourpt_admin_id"]);
                fpc.process = rows["process"] == DBNull.Value ? "" : Convert.ToString(rows["process"]);
                fpc.patta = rows["patta"] == DBNull.Value ? 0 : Convert.ToInt32(rows["patta"]);
                fpc.hole = rows["hole"] == DBNull.Value ? 0 : Convert.ToInt32(rows["hole"]);
                fpc.sizeUnit = rows["sizeUnit"] == DBNull.Value ? "" : Convert.ToString(rows["sizeUnit"]);
                fpc.minsize = rows["minsize"] == DBNull.Value ? 0 : Convert.ToInt32(rows["minsize"]);
                fpc.maxsize = rows["maxsize"] == DBNull.Value ? "" : Convert.ToString(rows["maxsize"]);
                fpc.points = rows["points"] == DBNull.Value ? 0 : Convert.ToInt32(rows["points"]);
                fpc.typeflag = rows["typeflag"] == DBNull.Value ? "" : Convert.ToString(rows["typeflag"]);
                fpc.sorting = rows["sorting"] == DBNull.Value ? 0 : Convert.ToInt32(rows["sorting"]);
                fpc.ObjectLength = rows["ObjectLength"] == DBNull.Value ? "" : Convert.ToString(rows["ObjectLength"]);
                fpc.Sequence = rows["Sequence"] == DBNull.Value ? 0 : Convert.ToInt32(rows["Sequence"]);
                lst.Add(fpc);
            }
            return lst;
        }
        #endregion

        #region UpdateFourPointCheckHolePatta
        public int UpdateFourPointCheckHolePatta(int patta, int hole)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_UpdatePointAdminHolePatta";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Patta", SqlDbType.Int);
                param.Value = patta;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Hole", SqlDbType.Int);
                param.Value = hole;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Insert_UpdateFourPointAC
        public int Insert_UpdateFourPointAC(string process, int point, int iu, int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_Insert_UpdateFourPointAC";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Process", SqlDbType.VarChar);
                param.Value = process;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Point", SqlDbType.VarChar);
                param.Value = point;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@U", SqlDbType.Int);
                param.Value = iu;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int status = 0;
                SqlParameter outparam = new SqlParameter("@Status", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparam);
                cmd.ExecuteNonQuery();
                if (outparam.Value != DBNull.Value)
                    status = Convert.ToInt32(outparam.Value);
                return status;
            }
        }
        #endregion

        #region DeleteFourPointAC
        public void DeleteFourPointAC(int id, int TableId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_DeleteFourPointAC";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@TableId", SqlDbType.Int);
                param.Value = TableId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Insert_UpdateFourPointPR
        public int Insert_UpdateFourPointPR(FourPointCheckAdmin fpc)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_Insert_UpdateFourPointPR";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Process", SqlDbType.VarChar);
                param.Value = fpc.process;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Point", SqlDbType.VarChar);
                param.Value = fpc.points;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@MinSize", SqlDbType.Int);
                param.Value = fpc.minsize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@MaxSize", SqlDbType.VarChar);
                param.Value = fpc.maxsize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@SizeUnit", SqlDbType.VarChar);
                param.Value = fpc.sizeUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@U", SqlDbType.Int);
                param.Value = fpc.IU;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = fpc.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int status = 0;
                SqlParameter outparam = new SqlParameter("@Status", SqlDbType.Int);
                outparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparam);
                cmd.ExecuteNonQuery();
                if (outparam.Value != DBNull.Value)
                    status = Convert.ToInt32(outparam.Value);
                return status;
            }
        }
        #endregion

        #region GetFourPointAC
        public List<string> GetFourPointProcess(string type, string q)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "sp_GetAccessoryFourPoint";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Process", SqlDbType.VarChar);
                param.Value = q;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["PROCESS"]));
                }
                return result;
            }
        }
        #endregion

        #region Insert_UpdateFourPointDetail
        public int Insert_UpdateFourPointDetail(FourPointDetail fpc)
        {
            SqlTransaction transaction = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                transaction = cnx.BeginTransaction();
                try
                {


                    string cmdText = "sp_Insert_Update_FpMain";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter IdParam;
                    IdParam = new SqlParameter("@d", SqlDbType.Int);
                    IdParam.Value = fpc.Id;
                    IdParam.Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.Add(IdParam);

                    SqlParameter param;
                    param = new SqlParameter("@PoId", SqlDbType.Int);
                    param.Value = fpc.PoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedQty", SqlDbType.Int);
                    param.Value = fpc.CheckedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedBy1", SqlDbType.Int);
                    param.Value = fpc.CheckedBy1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedBy2", SqlDbType.Int);
                    param.Value = fpc.CheckedBy2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedDate", SqlDbType.DateTime);
                    param.Value = fpc.CheckedDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = fpc.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sQAApproved", SqlDbType.Int);
                    param.Value = fpc.IsQAApproved;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QAComments", SqlDbType.VarChar);
                    param.Value = fpc.QAComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sFabricMgrApproved", SqlDbType.Int);
                    param.Value = fpc.IsFabricMgrApproved;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricMgrComments", SqlDbType.VarChar);
                    param.Value = fpc.FabricMgrComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabStatus", SqlDbType.VarChar);
                    param.Value = fpc.FabStatus;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RejectedQty", SqlDbType.Decimal);
                    param.Value = fpc.RejectedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnedQty", SqlDbType.Decimal);
                    param.Value = fpc.ReturnedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitedQty", SqlDbType.Float);
                    param.Value = fpc.DebitedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = fpc.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@U", SqlDbType.Int);
                    param.Value = fpc.IU;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OdId", SqlDbType.Int);
                    param.Value = fpc.OdId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WId", SqlDbType.Int);
                    param.Value = fpc.WashingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sFinalize", SqlDbType.Decimal);
                    param.Value = fpc.IsFinalize;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StockId", SqlDbType.Decimal);
                    param.Value = fpc.StockId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskId", SqlDbType.Decimal);
                    param.Value = fpc.TaskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter StatusParam;
                    StatusParam = new SqlParameter("@Status", SqlDbType.Int);
                    StatusParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(StatusParam);

                    cmd.ExecuteNonQuery();
                    int status = 0;
                    if (StatusParam.Value != DBNull.Value)
                        status = Convert.ToInt32(StatusParam.Value);
                    if (status != 1)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    int FpId = Convert.ToInt32(IdParam.Value);

                    if (fpc.IU == 2)
                    {
                        cmdText = "sp_Delete_FourPointData";

                        cmd = new SqlCommand(cmdText, cnx, transaction);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        IdParam = new SqlParameter("@FourPointId", SqlDbType.Int);
                        IdParam.Value = fpc.Id;
                        IdParam.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(IdParam);
                        cmd.ExecuteNonQuery();
                    }

                    if (fpc.IsFinalize == 1)
                    {
                        cmdText = "sp_Stock_Update_FourPoint";

                        cmd = new SqlCommand(cmdText, cnx, transaction);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        IdParam = new SqlParameter("@FpMainId", SqlDbType.Int);
                        IdParam.Value = FpId;
                        IdParam.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(IdParam);

                        IdParam = new SqlParameter("@UserId", SqlDbType.Int);
                        IdParam.Value = fpc.CreatedBy;
                        IdParam.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(IdParam);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (FourPointProcess fpp in fpc.Processes)
                    {
                        cmdText = "sp_Insert_Update_FpMainDetails";

                        cmd = new SqlCommand(cmdText, cnx, transaction);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        IdParam = new SqlParameter("@d", SqlDbType.Int);
                        IdParam.Value = fpp.Id;
                        IdParam.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(IdParam);

                        param = new SqlParameter("@FourPointId", SqlDbType.Int);
                        param.Value = FpId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@RollNo", SqlDbType.Int);
                        param.Value = fpp.RollNo;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@MillDyeLot", SqlDbType.VarChar);
                        param.Value = fpp.MillDyeLot;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@BIPLDyeLot", SqlDbType.VarChar);
                        param.Value = fpp.BIPLDyeLot;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ActualLength", SqlDbType.Float);
                        param.Value = fpp.ActualLength;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Width_S", SqlDbType.Int);
                        param.Value = fpp.Width_S;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Width_M", SqlDbType.Int);
                        param.Value = fpp.Width_M;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Width_E", SqlDbType.Int);
                        param.Value = fpp.Width_E;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Patta", SqlDbType.Int);
                        param.Value = fpp.Patta;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Hole", SqlDbType.Int);
                        param.Value = fpp.Hole;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@FabStatus", SqlDbType.VarChar);
                        param.Value = fpp.FabStatus;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@U", SqlDbType.Int);
                        param.Value = fpp.IU;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        StatusParam = new SqlParameter("@Status", SqlDbType.Int);
                        StatusParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(StatusParam);

                        cmd.ExecuteNonQuery();
                        status = 0;
                        if (StatusParam.Value != DBNull.Value)
                            status = Convert.ToInt32(StatusParam.Value);
                        if (status != 1)
                        {
                            transaction.Rollback();
                            return 0;
                        }
                        int ProcessId = Convert.ToInt32(IdParam.Value);

                        if (fpp.Details.Count > 0)
                        {
                            string xml = "<table>";
                            foreach (FourPointProcessDetail fpd in fpp.Details)
                            {
                                xml += string.Format("<AdminId>{0}</AdminId>", fpd.Id);
                                xml += string.Format("<Value>{0}</Value>", fpd.Value);
                                xml += string.Format("<Status>{0}</Status>", fpd.Status);
                            }
                            xml += "</table>";

                            cmdText = "sp_Insert_Update_FpProcess";

                            cmd = new SqlCommand(cmdText, cnx, transaction);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                            param = new SqlParameter("@FpMainId", SqlDbType.Int);
                            param.Value = FpId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@FpDetailId", SqlDbType.Int);
                            param.Value = ProcessId;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Xml", SqlDbType.VarChar);
                            param.Value = xml;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@Cnt", SqlDbType.VarChar);
                            param.Value = fpp.Details.Count;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return status;
                }
                catch (SqlException ex)
                {
                    if (transaction != null)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        transaction.Rollback();
                    }
                }
                return 0;
            }

        }

        #endregion

        #region GetFpsHeader
        public FourPointSystemHeader GetFpsHeader(int poId,int wId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Sp_GetFpsHeader";

                FourPointSystemHeader fpsh = new FourPointSystemHeader();

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@PoId", SqlDbType.VarChar);
                param.Value = poId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WId", SqlDbType.VarChar);
                param.Value = wId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                if(dsFabricQuality==null || dsFabricQuality.Tables.Count<1 || dsFabricQuality.Tables[0].Rows.Count<1)
                    return null;

                DataRow dr = dsFabricQuality.Tables[0].Rows[0];
                fpsh = GetFourPointHeaderData(dr);
                return fpsh;
            }
        }
        #endregion

        #region GetFourPointHeader
        public FourPointSystemHeader GetFourPointHeaderData(DataRow dr)
        {
            FourPointSystemHeader fpsh = new FourPointSystemHeader();
            fpsh.StockId = dr["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["StockId"]);
            fpsh.StoreId = dr["StoreId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["StoreId"]);
            fpsh.FabricName = dr["ItemName"] == DBNull.Value ? "" : Convert.ToString(dr["ItemName"]);
            fpsh.PoId = dr["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PoId"]);
            fpsh.PoNo = dr["PoNumber"] == DBNull.Value ? "" : Convert.ToString(dr["PoNumber"]);
            fpsh.PoQty = dr["PoQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PoQty"]);
            fpsh.AvlQuantity = dr["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Quantity"]);
            fpsh.PrintColor = dr["PrintColor"] == DBNull.Value ? "" : Convert.ToString(dr["PrintColor"]);
            fpsh.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierName"]);
            //fpsh.Checker1 = dr["Checker1"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Checker1"]);
            //fpsh.Checker2 = dr["Checker2"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Checker2"]);
            fpsh.SupplierId = dr["supplierId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["supplierId"]);
            fpsh.BuyerName = dr["CompanyName"] == DBNull.Value ? "" : Convert.ToString(dr["CompanyName"]);
            fpsh.BuyerId = dr["ClientId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ClientId"]);
            fpsh.PoTypeId = dr["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PoTypeId"]);
            fpsh.CheckedQuantity = dr["FPCQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["FPCQty"]);
            fpsh.StockQuantity = dr["StockQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(dr["StockQuantity"]);
            fpsh.AcCriteria = dr["FPCAcceptanceCriteria"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FPCAcceptanceCriteria"]);
            fpsh.OrderDetailId = dr["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OrderDetailId"]);
            fpsh.StyleNumbers = dr["StyleNumber"] == DBNull.Value ? "" : Convert.ToString(dr["StyleNumber"]);
            fpsh.OrderNumbers = dr["Order_Number"] == DBNull.Value ? "" : Convert.ToString(dr["Order_Number"]);
            fpsh.Unit = dr["Unit"] == DBNull.Value ? "" : Convert.ToString(dr["Unit"]);
            return fpsh;
        }
        #endregion

        #region GetFourPointData
        public FourPointDetail GetFourPointData(int FourPointId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_Get_FourPointData";
                FourPointDetail fourPointDetail = new FourPointDetail();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@FourPointId", SqlDbType.Int);
                param.Value = FourPointId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                if (dsFabric == null || dsFabric.Tables.Count < 1 || dsFabric.Tables[0].Rows.Count < 1)
                    return null;
                fourPointDetail = GetFourPointDetail(dsFabric.Tables[0].Rows[0]);
                fourPointDetail.Processes = new List<FourPointProcess>();
                foreach (DataRow dr in dsFabric.Tables[1].Rows)
                {
                    FourPointProcess fpp = GetFourPointProcessList(dr);
                    DataTable dt = dsFabric.Tables[2].Select("FpDetailId = " + fpp.Id).CopyToDataTable();
                    fpp.Details = GetFourPointProcessDetailList(dt);
                    fourPointDetail.Processes.Add(fpp);
                }
                fourPointDetail.FpAdmins = GetFourPointCheckAdminList(dsFabric.Tables[3]);
                fourPointDetail.FpHeader = GetFourPointHeaderData(dsFabric.Tables[4].Rows[0]);
                return fourPointDetail;
            }
        }
        #endregion

        #region GetFourPointDetails
        public FourPointDetail GetFourPointDetail(DataRow dr)
        {
            FourPointDetail fp = new FourPointDetail();
            fp.Id = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"]);
            fp.PoId = dr["POId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["POId"]);
            fp.CheckedQty = dr["CheckedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["CheckedQty"]);
            fp.CheckedBy1 = dr["CheckedBy1"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CheckedBy1"]);
            fp.CheckedBy2 = dr["CheckedBy2"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CheckedBy2"]);
            fp.CheckedDate = dr["CheckedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CheckedDate"]);
            fp.Remarks = dr["Remarks"] == DBNull.Value ? "" : Convert.ToString(dr["Remarks"]);
            fp.IsQAApproved = dr["IsQAApproved"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsQAApproved"]);
            fp.QAComments = dr["QAComments"] == DBNull.Value ? "" : Convert.ToString(dr["QAComments"]);
            fp.IsFabricMgrApproved = dr["IsFabricMgrApproved"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFabricMgrApproved"]);
            fp.FabricMgrComments = dr["FabricMgrComments"] == DBNull.Value ? "" : Convert.ToString(dr["FabricMgrComments"]);
            fp.FabStatus = dr["Status"] == DBNull.Value ? default(char) : Convert.ToChar(dr["Status"]);
            fp.RejectedQty = dr["RejectedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["RejectedQty"]);
            fp.ReturnedQty = dr["ReturnedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ReturnedQty"]);
            fp.DebitedQty = dr["DebitedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["DebitedQty"]);
            fp.IsFinalize = dr["IsFinalize"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IsFinalize"]);
            fp.StockId = dr["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["StockId"]);
            return fp;
        }
        #endregion

        #region GetFourPointProcessList
        public FourPointProcess GetFourPointProcessList(DataRow dr)
        {
            FourPointProcess fp = new FourPointProcess();
            fp.Id = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"]);
            fp.FourPointId = dr["FourPointId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FourPointId"]);
            fp.RollNo = dr["RollNo"] == DBNull.Value ? 0 : Convert.ToInt32(dr["RollNo"]);
            fp.MillDyeLot = dr["MillDyeLot"] == DBNull.Value ? "" : Convert.ToString(dr["MillDyeLot"]);
            fp.BIPLDyeLot = dr["BIPLDyeLot"] == DBNull.Value ? "" : Convert.ToString(dr["BIPLDyeLot"]);
            fp.ActualLength = dr["ActualLength"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ActualLength"]);
            fp.Width_S = dr["Width_S"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Width_S"]);
            fp.Width_M = dr["Width_M"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Width_M"]);
            fp.Width_E = dr["Width_E"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Width_E"]);
            fp.Patta = dr["Patta"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Patta"]);
            fp.Hole = dr["Hole"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Hole"]);
            fp.FabStatus = dr["Status"] == DBNull.Value ? default(char) : Convert.ToChar(dr["Status"]);
            return fp;
        }
        #endregion

        #region GetFourPointProcessDetailList
        public List<FourPointProcessDetail> GetFourPointProcessDetailList(DataRow[] drs)
        {
            List<FourPointProcessDetail> fpds = new List<FourPointProcessDetail>();
            foreach (var dr in drs)
            {
                FourPointProcessDetail fp = new FourPointProcessDetail();
                fp.Id = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"]);
                fp.FpMainId = dr["FpMainId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FpMainId"]);
                fp.FpDetailId = dr["FpDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FpDetailId"]);
                fp.FpAdminId = dr["FpAdminId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FpAdminId"]);
                fp.Value = dr["Value"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Value"]);
                fp.FabStatus = dr["Status"] == DBNull.Value ? default(char) : Convert.ToChar(dr["Status"]);
                fpds.Add(fp);
            }
            return fpds;
        }

        public List<FourPointProcessDetail> GetFourPointProcessDetailList(DataTable dt)
        {
            return GetFourPointProcessDetailList(dt.Select("", ""));
        }
        #endregion

        #region Insert4PCFMQA
        public int Insert4PCFMQA(FourPointDetail fpd)
        {
            SqlTransaction transaction = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();
                    string cmdText = "sp_FpC_QA_FM";

                    FourPointSystemHeader fpsh = new FourPointSystemHeader();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@FpId", SqlDbType.VarChar);
                    param.Value = fpd.Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@lid", SqlDbType.Int);
                    param.Value = fpd.LevelId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskId", SqlDbType.VarChar);
                    param.Value = fpd.TaskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sFmQAApproved", SqlDbType.Int);
                    param.Value = fpd.IsFMQAApproved;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FMQAComments", SqlDbType.VarChar);
                    param.Value = fpd.FMQAComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabStatus", SqlDbType.VarChar);
                    param.Value = fpd.FabStatus;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RejectedQty", SqlDbType.Float);
                    param.Value = fpd.RejectedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnedQty", SqlDbType.Float);
                    param.Value = fpd.ReturnedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitedQty", SqlDbType.Float);
                    param.Value = fpd.DebitedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter sparam;
                    sparam = new SqlParameter("@Status", SqlDbType.Int);
                    sparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(sparam);

                    cmd.ExecuteNonQuery();

                    int status = Convert.ToInt32(sparam.Value);

                    if (fpd.LevelId == 2 && status == 1)
                    {
                        cmdText = "sp_Stock_Update_FourPoint";

                        cmd = new SqlCommand(cmdText, cnx, transaction);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        param = new SqlParameter("@FpMainId", SqlDbType.Int);
                        param.Value = fpd.Id;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@UserId", SqlDbType.Int);
                        param.Value = fpd.CreatedBy;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    return status;
                }
                catch (SqlException ex)
                {
                    if (transaction != null)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                        transaction.Rollback();
                    }
                }
            }

            return 0;
        }
        #endregion

        #endregion
    }
}
