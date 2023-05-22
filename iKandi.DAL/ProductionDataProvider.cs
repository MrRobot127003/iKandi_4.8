using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;
namespace iKandi.DAL
{
    public class ProductionDataProvider : BaseDataProvider
    {
        #region Counstrutor(s)

        public ProductionDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {

        }

        #endregion


        #region Create Production Unit Data

        public OrderAllocationToProductionUnit CreateOrderAllocationToProductionUnit(OrderAllocationToProductionUnit objOrderAllocationToProductionUnit)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_accessory_working_insert_accessory_working";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters
                    SqlParameter paramOut;
                    SqlParameter paramIn;

                    paramOut = new SqlParameter("@d", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);

                    paramIn = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.ProductionUnit.ProductionUnitId;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@OrderId", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.Order.OrderID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.OrderDetail.OrderDetailID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TotalPCSIssuedToUnit", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.TotalPCSIssuedToUnit;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@PCSStichedToday", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.PCSStichedToday;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TotalPCSStiched", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.TotalPCSStiched;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@PCSPackedToday", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.PCSPackedToday;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TotalPCSPacked", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.TotalPCSPacked;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    objOrderAllocationToProductionUnit.Id = Convert.ToInt32(paramOut.Value);

                    if (objOrderAllocationToProductionUnit.Id > 0)
                    {
                        transaction.Commit();
                    }

                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

            }
            return objOrderAllocationToProductionUnit;
        }

        #endregion

        #region Update Production Unit Data

        public OrderAllocationToProductionUnit UpdateOrderAllocationToProductionUnit(OrderAllocationToProductionUnit objOrderAllocationToProductionUnit)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_accessory_working_insert_accessory_working";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters                    
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@d", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.Id;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.ProductionUnit.ProductionUnitId;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@OrderId", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.Order.OrderID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.OrderDetail.OrderDetailID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TotalPCSIssuedToUnit", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.TotalPCSIssuedToUnit;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@PCSStichedToday", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.PCSStichedToday;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TotalPCSStiched", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.TotalPCSStiched;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@PCSPackedToday", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.PCSPackedToday;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TotalPCSPacked", SqlDbType.Int);
                    paramIn.Value = objOrderAllocationToProductionUnit.TotalPCSPacked;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();

                    if (objOrderAllocationToProductionUnit.Id > 0)
                    {
                        transaction.Commit();
                    }

                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

            }
            return objOrderAllocationToProductionUnit;
        }

        #endregion

        #region Get Production Unit Data

        public List<OrderAllocationToProductionUnit> GetOrderAllocationToProductionUnit(Int32 OrderId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_accessory_get_all_accessory";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                List<OrderAllocationToProductionUnit> orderAllocationCollection = new List<OrderAllocationToProductionUnit>();

                while (reader.Read())
                {
                    OrderAllocationToProductionUnit orderAllocationToProductionUnit = new OrderAllocationToProductionUnit();
                    orderAllocationToProductionUnit.Id = (reader["Id"] != null) ? Convert.ToInt32(reader["Id"]) : 0;
                    orderAllocationToProductionUnit.ProductionUnit = GetProductionUnit(reader["ProductionUnitId"] != null ? Convert.ToInt32(reader["ProductionUnitId"]) : 0);
                    orderAllocationToProductionUnit.Order = new Order();
                    orderAllocationToProductionUnit.Order.OrderID = (reader["OrderId"] != null) ? Convert.ToInt32(reader["OrderId"]) : 0;
                    orderAllocationCollection.Add(orderAllocationToProductionUnit);
                }

                return orderAllocationCollection;
            }

        }

        public ProductionUnit GetProductionUnit(Int32 ProductionUnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_production_unit_get_all_production_unit";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                ProductionUnit productionUnit = new ProductionUnit();

                while (reader.Read())
                {
                    productionUnit.ProductionUnitId = (reader["Id"] != null) ? Convert.ToInt32(reader["Id"]) : 0;
                    productionUnit.FactoryName = (reader["Name"] != null) ? Convert.ToString(reader["Name"]) : String.Empty;
                    productionUnit.FactoryCode = (reader["FactoryCode"] != null) ? Convert.ToString(reader["FactoryCode"]) : String.Empty;
                }

                return productionUnit;
            }

        }

        public DataSet GetSlot_LinePlanning(string StartDate, int Lineno, int SlotId, int ProductionUnit, string Type, int UserId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetSlot_LinePlanning_Stitching";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StartDate", SqlDbType.VarChar);
                param.Value = StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                param.Value = Lineno;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = ProductionUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }

        public string[] SaveSlot_LinePlanning_Stitching(StitchingDetail objStitching, int UserId)
        {
            string[] SReturn = new string[2];
            string lineplannotexist = "";
            string error = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "usp_SaveSlot_LinePlanning_Stitching";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                    param.Value = objStitching.LinePlanningID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = objStitching.ProductionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrameStyleId", SqlDbType.Int);
                    param.Value = objStitching.FrameStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = objStitching.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = objStitching.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Lineno", SqlDbType.Int);
                    param.Value = objStitching.LineNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = objStitching.SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotPass", SqlDbType.Int);
                    if (objStitching.SlotPass == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.SlotPass;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotAlt", SqlDbType.Int);
                    if (objStitching.SlotAlt == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.SlotAlt;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotOB", SqlDbType.Int);
                    if (objStitching.ActualOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.ActualOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Efficiency", SqlDbType.Int);
                    param.Value = objStitching.Efficiency;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AvailMins", SqlDbType.Int);
                    if (objStitching.AvailMins == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.AvailMins;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TargetEarnedMins", SqlDbType.Int);
                    if (objStitching.TargetEarnedMins == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.TargetEarnedMins;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                    param.Value = objStitching.SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsStitched", SqlDbType.Bit);
                    param.Value = objStitching.IsStitched;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsDayClosed", SqlDbType.Bit);
                    param.Value = objStitching.IsDayClosed;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsHalfStitch", SqlDbType.Bit);
                    param.Value = objStitching.IsHalfStitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinePlanningSAM", SqlDbType.Float);
                    if (objStitching.LinePlanningSAM == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.LinePlanningSAM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotZeroProductivity", SqlDbType.Int);
                    param.Value = objStitching.ZeroProductvity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remark", SqlDbType.VarChar, 500);
                    param.Value = objStitching.StitchRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@cotvalue", SqlDbType.Int);//abhishek -28/6
                    if (objStitching.cot == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.cot;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakCapecity", SqlDbType.Int);
                    if (objStitching.PeakCapecity == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakCapecity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakOB", SqlDbType.Int);
                    if (objStitching.PeakOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Finishing Entry

                    param = new SqlParameter("@ActOB_Finish", SqlDbType.Int);
                    if (objStitching.FinishingOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.FinishingOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActTCOB", SqlDbType.Int);
                    if (objStitching.ActTCOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.ActTCOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActPressOB", SqlDbType.Int);
                    if (objStitching.ActPressOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.ActPressOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakCapTotal", SqlDbType.Int);
                    if (objStitching.PeakCapTotal == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakCapTotal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakCapTC", SqlDbType.Int);
                    if (objStitching.PeakCapTC == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakCapTC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakCapPress", SqlDbType.Int);
                    if (objStitching.PeakCapPress == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakCapPress;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakOB_Finish", SqlDbType.Int);
                    if (objStitching.PeakOB_Finish == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakOB_Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakTCOB", SqlDbType.Int);
                    if (objStitching.PeakTCOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakTCOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakPressOB", SqlDbType.Int);
                    if (objStitching.PeakPressOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakPressOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishPassPcs", SqlDbType.Int);
                    if (objStitching.FinishingPass == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.FinishingPass;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ZeroProductivity_Finish", SqlDbType.Bit);
                    param.Value = objStitching.ZeroProductivity_Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarkAsFinishedPacked", SqlDbType.Bit);
                    param.Value = objStitching.MarkAsFinishedPacked;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckRequiredActualOb", SqlDbType.Int);
                    param.Value = objStitching.checkRequiredActualOb;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Sequenceframe", SqlDbType.Bit);
                    param.Value = objStitching.Sequenceframe;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TargetQty", SqlDbType.Int);
                    param.Value = objStitching.TargetQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SAM", SqlDbType.Float);
                    param.Value = objStitching.StitchSAM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    //Add By Prabhaker 23-aug-18

                    param = new SqlParameter("@LineManId", SqlDbType.Int);
                    param.Value = objStitching.LineManId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //End OF code

                    param = new SqlParameter("@Error", SqlDbType.VarChar, 1000);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LineplanNotExist", SqlDbType.VarChar, 1000);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QcLineManID", SqlDbType.Int);
                    param.Value = objStitching.QCLineManID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    error = cmd.Parameters["@Error"].Value.ToString();
                    lineplannotexist = cmd.Parameters["@LineplanNotExist"].Value.ToString();

                    SReturn[0] = error;
                    SReturn[1] = lineplannotexist;
                    //intReturn = cmd.ExecuteNonQuery();
                    //cnx.Close();

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return SReturn;
        }

        public string SaveSlot_Cluster_Stitching(StitchingDetail objStitching, int UserId, string Issave = "")
        {
            string error = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "usp_Save_Cluster_LinePlan";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@ClusterId", SqlDbType.Int);
                    param.Value = objStitching.ClusterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                    //param.Value = objStitching.LinePlanningID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = objStitching.ProductionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = objStitching.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                    param.Value = objStitching.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@Lineno", SqlDbType.Int);
                    //param.Value = objStitching.LineNo;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = objStitching.SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@SlotPass", SqlDbType.Int);
                    //if (objStitching.SlotPass == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.SlotPass;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@SlotAlt", SqlDbType.Int);
                    //if (objStitching.SlotAlt == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.SlotAlt;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@SlotOB", SqlDbType.Int);
                    //if (objStitching.ActualOB == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.ActualOB;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@Efficiency", SqlDbType.Int);
                    //param.Value = objStitching.Efficiency;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@AvailMins", SqlDbType.Int);
                    //if (objStitching.AvailMins == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.AvailMins;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@TargetEarnedMins", SqlDbType.Int);
                    //if (objStitching.TargetEarnedMins == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.TargetEarnedMins;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskDate", SqlDbType.VarChar);
                    param.Value = objStitching.SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@IsStitched", SqlDbType.Bit);
                    //param.Value = objStitching.IsStitched;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsDayClosed", SqlDbType.Bit);
                    param.Value = objStitching.IsDayClosed;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@IsHalfStitch", SqlDbType.Bit);
                    //param.Value = objStitching.IsHalfStitch;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LinePlanningSAM", SqlDbType.Float);
                    //if (objStitching.LinePlanningSAM == 0)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.LinePlanningSAM;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@SlotZeroProductivity", SqlDbType.Int);
                    //param.Value = objStitching.ZeroProductvity;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@Remark", SqlDbType.VarChar, 500);
                    //param.Value = objStitching.StitchRemark;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@cotvalue", SqlDbType.Int);//abhishek -28/6
                    //if (objStitching.cot == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.cot;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@PeakCapecity", SqlDbType.Int);
                    //if (objStitching.PeakCapecity == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.PeakCapecity;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@PeakOB", SqlDbType.Int);
                    //if (objStitching.PeakOB == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = objStitching.PeakOB;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    // Finishing Entry

                    param = new SqlParameter("@ActOB_Finish", SqlDbType.Int);
                    if (objStitching.FinishingOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.FinishingOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActTCOB", SqlDbType.Int);
                    if (objStitching.ActTCOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.ActTCOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActPressOB", SqlDbType.Int);
                    if (objStitching.ActPressOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.ActPressOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakCapTotal", SqlDbType.Int);
                    if (objStitching.PeakCapTotal == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakCapTotal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakCapTC", SqlDbType.Int);
                    if (objStitching.PeakCapTC == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakCapTC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakCapPress", SqlDbType.Int);
                    if (objStitching.PeakCapPress == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakCapPress;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakOB_Finish", SqlDbType.Int);
                    if (objStitching.PeakOB_Finish == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakOB_Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakTCOB", SqlDbType.Int);
                    if (objStitching.PeakTCOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakTCOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PeakPressOB", SqlDbType.Int);
                    if (objStitching.PeakPressOB == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.PeakPressOB;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slotpass", SqlDbType.Int);//@FinishPassPcs
                    if (objStitching.FinishingPass == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objStitching.FinishingPass;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ZeroProductivity_Finish", SqlDbType.Bit);
                    param.Value = objStitching.ZeroProductivity_Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarkAsFinishedPacked", SqlDbType.Bit);
                    param.Value = objStitching.MarkAsFinishedPacked;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Error", SqlDbType.VarChar, 1000);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Isreset", SqlDbType.VarChar);
                    if (Issave == "")
                        param.Value = DBNull.Value;
                    else
                        param.Value = Issave;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    error = cmd.Parameters["@Error"].Value.ToString();

                    if (error == "")
                    {
                        saveClusterRemark(objStitching, UserId);

                    }
                    //intReturn = cmd.ExecuteNonQuery();
                    //cnx.Close();

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return error;
        }
        public string SaveSlot_Cluster_Delete1(StitchingDetail objStitching, int UserId)
        {
            string error = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "usp_Save_Cluster_delete";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@ClusterId", SqlDbType.Int);
                    param.Value = objStitching.ClusterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = objStitching.ProductionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                    param.Value = objStitching.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();
                    cnx.Close();





                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return error;
        }

        public DataSet saveClusterRemark(StitchingDetail objStitching, int UserId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_SaveClusterRemarksSlotWise";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = objStitching.ClusterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = objStitching.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = objStitching.OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = objStitching.StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = objStitching.ProductionUnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotCreateDate", SqlDbType.VarChar);
                param.Value = objStitching.SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CraetedBy", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = objStitching.SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotDescription", SqlDbType.VarChar);
                param.Value = objStitching.StitchRemark;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            return ds;
        }

        public DataSet GetFinshingByID(int Lineid, int Slotid)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "[dbo].[usp_GetSlot_LineFinishing]";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                param.Value = Lineid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = Slotid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            return ds;
        }

        public DataSet GetOrderContract_BySizeOption(int OrderDetailId, int OrderID, string Type, int UnitId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_GetOrderContract_BySizeOption";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitID", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return ds;
        }

        //Gajendra 11-12-2015 for Order History
        public DataTable GetOredrHistoryDetails(int OrderDetailID, DateTime CreatedDate, string Type, int UnitId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;
                    cmdText = "GetOredrHistoryDetails";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                    param.Value = CreatedDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return dt;
        }

        public DataTable GetSizeQuantity_Option(int OrderDetailID, int Option, string Type, int UnitID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_GetQuantityAndSize_Option";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Option", SqlDbType.Int);
                    param.Value = Option;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitID", SqlDbType.Int);
                    param.Value = UnitID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return dt;
        }

        public int SaveQuantityBySize(int OrderDetailId, string Size1, string Size2, string Size3, string Size4, string Size5, string Size6, string Size7, string Size8, string Size9, string Size10, string Size11, string Size12, string Size13, string Size14, string Size15, int Quantity1, int Quantity2, int Quantity3, int Quantity4, int Quantity5, int Quantity6, int Quantity7, int Quantity8, int Quantity9, int Quantity10, int Quantity11, int Quantity12, int Quantity13, int Quantity14, int Quantity15, int AltVal, string Type, int UnitId)
        {
            int intReturn;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {

                    cnx.Open();
                    string cmdText = "Usp_SaveQuantityBySize";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size1", SqlDbType.VarChar);
                    param.Value = Size1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size2", SqlDbType.VarChar);
                    param.Value = Size2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size3", SqlDbType.VarChar);
                    param.Value = Size3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size4", SqlDbType.VarChar);
                    param.Value = Size4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size5", SqlDbType.VarChar);
                    param.Value = Size5;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size6", SqlDbType.VarChar);
                    param.Value = Size6;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size7", SqlDbType.VarChar);
                    param.Value = Size7;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size8", SqlDbType.VarChar);
                    param.Value = Size8;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size9", SqlDbType.VarChar);
                    param.Value = Size9;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size10", SqlDbType.VarChar);
                    param.Value = Size10;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size11", SqlDbType.VarChar);
                    param.Value = Size11;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size12", SqlDbType.VarChar);
                    param.Value = Size12;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size13", SqlDbType.VarChar);
                    param.Value = Size13;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size14", SqlDbType.VarChar);
                    param.Value = Size14;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size15", SqlDbType.VarChar);
                    param.Value = Size15;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity1", SqlDbType.Int);
                    if (Quantity1 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity2", SqlDbType.Int);
                    if (Quantity2 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity3", SqlDbType.Int);
                    if (Quantity3 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity4", SqlDbType.Int);
                    if (Quantity4 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity5", SqlDbType.Int);
                    if (Quantity5 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity5;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity6", SqlDbType.Int);
                    if (Quantity6 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity6;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity7", SqlDbType.Int);
                    if (Quantity7 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity7;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity8", SqlDbType.Int);
                    if (Quantity8 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity8;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity9", SqlDbType.Int);
                    if (Quantity9 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity9;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity10", SqlDbType.Int);
                    if (Quantity10 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity10;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity11", SqlDbType.Int);
                    if (Quantity11 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity11;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity12", SqlDbType.Int);
                    if (Quantity12 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity12;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity13", SqlDbType.Int);
                    if (Quantity13 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity13;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity14", SqlDbType.Int);
                    if (Quantity14 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity14;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity15", SqlDbType.Int);
                    if (Quantity15 == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Quantity15;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@AltVal", SqlDbType.Int);
                    if (AltVal == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = AltVal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@UnitID", SqlDbType.Int);
                    if (UnitId == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    intReturn = 0;
                }

            }
            return intReturn;
        }

        public DataTable GetDepartmentLoss(string Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetDepartmentLoss";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public int SaveSlotWiseDistributionLoss(int SlotWiseFactoryId, int UnitId, int DeprtmentID, int SlotId, int LossDepartmentValue, int UserId, string SlotDate)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "usp_SaveSlotWiseDistributionLoss";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@SlotWiseFactoryId", SqlDbType.Int);
                    param.Value = SlotWiseFactoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DeprtmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LossDepartmentValue", SqlDbType.Int);
                    param.Value = LossDepartmentValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                    param.Value = SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return intReturn;
        }

        // Add by Ravi kumar on 18/2/2016
        public int SaveSlotWiseFactoryId_Ref(string SlotWiseFactoryIdAll, int UnitId, int SlotId, int UserId, string SlotDate)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "usp_SaveSlotWiseFactoryId_Ref";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@SlotWiseFactoryIdAll", SqlDbType.VarChar, 500);
                    param.Value = SlotWiseFactoryIdAll;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                    param.Value = SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return intReturn;
        }

        public int SaveSlot_LinePlanning_FactoryIE(int LinePlanningId, int UnitId, int OrderID, int OrderDetailId, int Lineno, int SlotId, string SlotDate, string SlotComment, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int intReturn;
                cnx.Open();
                string cmdText = "usp_SaveSlot_LinePlanning_FactoryIE";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                param.Value = LinePlanningId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Lineno", SqlDbType.Int);
                param.Value = Lineno;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                param.Value = SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SlotComment", SqlDbType.VarChar, 1000);
                if (SlotComment == "")
                    param.Value = DBNull.Value;
                else
                    param.Value = SlotComment;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                intReturn = cmd.ExecuteNonQuery();
                cnx.Close();
                return intReturn;
            }

        }

        //Added uday
        public int SaveSlot_LinePlanning_FinshingIE(string SlotDate, int LinePlanningID, int OrderDetailId, int OrderID, int unitid, int TotalFinshing, bool MarkAsDayCloseFinished, bool MarkAsFinishedPacked, int Slotpass, int SlotId, int Userid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int intReturn;
                cnx.Open();
                string cmdText = "Usp_InsertUpdateFinshingSlotpass";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                param.Value = SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                param.Value = LinePlanningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@unitID", SqlDbType.Int);
                param.Value = unitid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@totaltofinishingPcs", SqlDbType.Int);
                param.Value = TotalFinshing;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MarkAsDayCloseFinished", SqlDbType.Bit);
                param.Value = MarkAsDayCloseFinished;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MarkAsFinishedPacked", SqlDbType.Bit);
                param.Value = MarkAsFinishedPacked;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Slotid", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Slotpass", SqlDbType.Int);
                if (Slotpass == 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = Slotpass;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = Userid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                intReturn = cmd.ExecuteNonQuery();
                cnx.Close();
                return intReturn;
            }

        }

        #endregion
        //Addded by abhishek on 28/9/2015

        public int InsertUpdateCuttingSlotpass(string SlotDate, int OrderDetailsID, int OrderID, int unitID, int TotaltoCut, bool MarksAsCut, int slotpassVal, int CutReady, int Userid, int chkalmostdone)
        {
            int intReturn = 0;

            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    string cmdText = "Usp_InsertUpdateCuttingSlotpass";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                    param.Value = SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                    param.Value = OrderDetailsID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@unitID", SqlDbType.Int);
                    param.Value = unitID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@totaltoCutPcs", SqlDbType.Int);
                    param.Value = TotaltoCut;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarkasCut", SqlDbType.Bit);
                    param.Value = MarksAsCut;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Slot1pass", SqlDbType.Int);
                    if (slotpassVal == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = slotpassVal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CutReady", SqlDbType.Int);
                    if (CutReady == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = CutReady;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = Userid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AlmostDone", SqlDbType.Int);
                    param.Value = chkalmostdone;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

            return intReturn;
        }
        public DataSet GetSlot_LinePlanning_cutting(int UnitID, int ClientId, int ClientDeptID, string SearchText)//for get cutting record
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetSlot_LinePlanning_Cutting";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientDeptID", SqlDbType.Int);
                param.Value = ClientDeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }

        public DataSet GetSlot_LinePlanning_cutting_ByOrderDetailId(int UnitID, int OrderDetailId)//for get cutting record
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetSlot_LinePlanning_Cutting_ByOrderDetailId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }
        ////End by Abhishek 
        // Add by Ravi kumar on 5/10/15
        public DataSet GetAllStitchingSlot(int UnitID, string SlotDate, int UserId)//for gettin stitching slot
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsStitch = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAllStitchingSlot";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsStitch);
                return dsStitch;
            }
        }

        // Add by Ravi kumar on 17/02/16
        public DataSet GetAllStitchingFactoryIESlot(int UnitID, string SlotDate)//for getting StitchingFactoryIE slot
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsStitch = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAllStitchingFactoryIESlot";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsStitch);
                return dsStitch;
            }
        }

        //Added By uday on 10/15/2015
        public DataTable GetAllVaAddtion(int Orderid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dsFinish = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetValueAddtionCapcityQty";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@orderid", SqlDbType.Int);
                param.Value = Orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsFinish);
                return dsFinish;
            }
        }

        public int InsertUpdateValueEdttion(int riskvalid, int Qty)
        {
            int intReturn = 0;

            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    string cmdText = "Usp_updateCapcityQtyForVA";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@riskvalid", SqlDbType.Int);
                    param.Value = riskvalid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CapcityQty", SqlDbType.Int);
                    param.Value = Qty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

            return intReturn;
        }

        public DataSet GetAllFinishingSlot(int UnitID, string SlotDate, int UserId)//for gettin finishing slot
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsFinish = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAllFinishingSlot";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsFinish);
                return dsFinish;
            }
        }

        public string GetFactoryName(int UnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "usp_GetFactoryName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                string FactoryName = cmd.ExecuteScalar().ToString();
                return FactoryName;
            }

        }
        //added by abhishek on 7/10/2015

        public string InsertUpdateValueAddtion(int fromstatus, int tostatus, string VaddtionValue, bool IsAct, int id, decimal Rate)
        {
            string Result = string.Empty;

            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "Usp_InsertUpdateValueAddition";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@fromstatus", SqlDbType.Int);
                    param.Value = @fromstatus;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@tostatus", SqlDbType.Int);
                    param.Value = tostatus;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Valaddtion", SqlDbType.VarChar);
                    param.Value = VaddtionValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAct", SqlDbType.Bit);
                    param.Value = IsAct;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@id", SqlDbType.Int);
                    param.Value = id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@RetVal", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Float);
                    param.Value = Rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    Result = cmd.Parameters["@RetVal"].Value.ToString();

                }
            }
            catch (Exception ex)
             {
                 System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                 System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return Result;
        }

        public DataTable GetProductionStatus()//for get status production
        {
            DataTable dtstatus = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "select status_modeid as id,status_modename as name from admin_targetdate where status_modeid in (10,29,37,39,40)";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dtstatus);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return dtstatus;
        }
        public bool bCheckCalenderEvent()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "sp_CheckProductionEvent";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExistFabric = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckExistFabric);
                    int a = Convert.ToInt32(dsCheckExistFabric.Tables[0].Rows[0]["CheckEvent"]);
                    if (a == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool bCheckCalenderEvent_ForFits(DateTime DATE)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "sp_CheckProductionEvent_ForFits";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExistFabric = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    SqlParameter param;

                    param = new SqlParameter("@date", SqlDbType.Date);
                    param.Value = DATE;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    adapter.Fill(dsCheckExistFabric);
                    int a = Convert.ToInt32(dsCheckExistFabric.Tables[0].Rows[0]["CheckEvent"]);
                    if (a == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable GetValueAddtionDetails()//for get status production
        {
            DataTable dtstatus = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_GetValueAddtion";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtstatus);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return dtstatus;
        }

        //end by abhishek on 7/10/2015


        public string Check_Cut_For_Production(int OrderDetailId, string Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_Check_Cut_For_Production";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                string IsCutMsg = cmd.ExecuteScalar().ToString();
                return IsCutMsg;
            }

        }

        public string Check_CuttingAndIssued_Data(int OrderDetailId, string Type, int PcsCut)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_Check_Cut_For_Production";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PcsCut", SqlDbType.VarChar);
                param.Value = PcsCut;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                string IsCutMsg = cmd.ExecuteScalar().ToString();
                return IsCutMsg;
            }

        }

        public int CheckCuttingForStitching(int OrderDetailId, int UnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "usp_CheckCuttingForStitching";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int CuttingVal = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                return CuttingVal;
            }

        }

        // Hourly Report

        public DataSet GetHourlyStitchingReport(string FactoryName, int StyleId, int OrderId, int LineNo, int UnitId, int IsCluster, int ClusterId, string Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                //cmdText = "usp_GetHourly_Stitching_Finishing_Report";
                cmdText = "usp_GetHourly_Stitching_Finishing_Report_Optimize";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = FactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                param.Value = LineNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionUnit", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsCluster", SqlDbType.Int);
                param.Value = IsCluster;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = ClusterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }

        //added by abhishek on 12/7/2017
        public DataSet GetHourlyStitchingReport_top3fualtsSammury(string FactoryName, int StyleId, int OrderId, int LineNo, int UnitId, string Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                //cmdText = "usp_GetHourly_Stitching_Finishing_Report";
                cmdText = "usp_GetHourly_top3FualtSummary";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = FactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                param.Value = LineNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionUnit", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }
        //end

        public DataSet GetHourlyStitchingReportUser(string FactoryName, int StyleId, int LineNo, int OrderDetailId, int LinePlanningId, int UnitId, string Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetHourly_Stitching_Finishing_Report";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = FactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                param.Value = LineNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                param.Value = LinePlanningId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionUnit", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }


        public DataSet GetHourlyFinishingReport(string FactoryName, int StyleId, string Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetHourlyFinishingReport";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = FactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }

        public DataSet GetHourlyFinishingReportUser(string FactoryName, int StyleId, string Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetHourlyFinishingReport_User_test";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = FactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }

        public DataTable GetBiplUNITNAME_DAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_UNITNAME";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        //Gajendra Penalty Metrics
        public System.Data.DataTable GetCompanyName_Of_ShippedQty()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //string cmdText = "GetCompanyName_Of_ShippedQty";
                string cmdText = "GetCompanyName_Of_ShippedQty";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable CompanyName = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(CompanyName);
                cnx.Close();
                return CompanyName;

            }

        }
        //Gajendra Penalty Metrics
        public DataSet GetPenaltyMetrics(string UnitID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "GetPenaltyMetrics";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet Penalty = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Penalty);
                cnx.Close();
                return Penalty;

            }
        }
        //Gajendra Penalty Metrics 15-07-2016
        public DataSet GetPenaltyMetricsNew()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "GetPenaltyMetricsNew";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataSet Penalty = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Penalty);
                cnx.Close();
                return Penalty;

            }
        }
        //Gajendra Penalty Metrics
        public System.Data.DataSet GetPenaltyMetricsBIPL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "GetPenaltyMetricsBIPL";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet CompanyName = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(CompanyName);
                cnx.Close();
                return CompanyName;

            }

        }


        public int Update_Production_Outhouse(int OrderDetailId, int Quantity, int AltPcs, int UnitId, string Type, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {

                    cnx.Open();
                    string cmdText = "usp_Update_Production_Outhouse";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AltPcs", SqlDbType.Int);
                    param.Value = AltPcs;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return intReturn;
        }

        #region MMR Summary
        public string GetMMR_WorkingHours_DAL(DateTime dtDateFrom, DateTime dtDateTo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string workingdays = "";
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetMMR_WorkingHours";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (dtDateFrom != DateTime.MinValue)
                    param.Value = dtDateFrom.Date;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (dtDateTo != DateTime.MinValue)
                    param.Value = dtDateTo.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();
                if (result != null)
                {
                    workingdays = Convert.ToString(result);
                }
                return workingdays;
            }
        }

        public DataTable GetMMR_BudgetSummary_Daily_DAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_BudgetSummary_Daily";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThisDate", SqlDbType.DateTime);
                param.Value = dtDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }


        public DataTable GetMMR_Summary_Daily_DAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_Summary_Daily";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThisDate", SqlDbType.DateTime);
                param.Value = dtDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        #endregion

        #region DailyPerformance
        public DataTable Get_DailyPerformanceSummery_DAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_DailyPerformanceSummery";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThisDate", SqlDbType.DateTime);
                param.Value = dtDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion

        // Create by Ravi kumar on 11/3/2016 for Close Stitching and Finishing Task

        public int Close_Stitched_FinishTask(StitchingDetail objStitching, int RowCount, int UserId, string Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int intReturn;
                cnx.Open();
                string cmdText = "usp_Close_Stitched_FinishTask";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Slotid", SqlDbType.Int);
                param.Value = objStitching.SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                param.Value = objStitching.SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@unitID", SqlDbType.Int);
                param.Value = objStitching.ProductionUnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsDayCloseFinish", SqlDbType.Int);
                param.Value = objStitching.IsDayClosed;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@RowCount", SqlDbType.Int);
                param.Value = RowCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotClose", SqlDbType.Int);
                param.Value = objStitching.SlotClose;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsHalfStitch", SqlDbType.Int);
                param.Value = objStitching.IsAnyHalfStitch;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                intReturn = cmd.ExecuteNonQuery();
                cnx.Close();
                return intReturn;
            }

        }

        public int SaveHalfStitch_Data(int UnitId, int OrderDetailId, int SlotPass, int SlotAlt, string SlotDate, int Userid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int intReturn;
                cnx.Open();
                string cmdText = "usp_SaveHalfStitch_Data";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotPass", SqlDbType.Int);
                param.Value = SlotPass;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotAlt", SqlDbType.Int);
                param.Value = SlotAlt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotDate", SqlDbType.VarChar);
                param.Value = SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = Userid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                intReturn = cmd.ExecuteNonQuery();
                cnx.Close();
                return intReturn;
            }

        }

        public DataSet Get_ProductionDetails_History(string OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProductionDetails = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Get_ProductionDetails_History";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProductionDetails);
                return dsProductionDetails;
            }
        }
        public DataSet TotalFault_In_Percent(string OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProductionDetails = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Get_Rescan_TotalFault_In_Percent";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProductionDetails);
                return dsProductionDetails;
            }
        }

        // Production Matrix work

        public DataSet GetProductionMatrix(Int32 OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProductionMatrix = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Production_Matrix";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProductionMatrix);
                return dsProductionMatrix;
            }
        }


        public int SaveProduction_ExtraHrs(int OrderDetailId, string ProdDate, double ExtraHrs, int LinePlanningId, int UnitId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "usp_SaveProduction_ExtraHrs";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdDate", SqlDbType.VarChar);
                    param.Value = ProdDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExtraHrs", SqlDbType.Float);
                    if (ExtraHrs == 0)
                        param.Value = DBNull.Value;
                    else
                        param.Value = ExtraHrs;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                    param.Value = LinePlanningId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return intReturn;
        }

        public DataSet Get_ProductionDateOfMonth()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProductionDate = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_ProductionDateOfMonth";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProductionDate);
                return dsProductionDate;
            }
        }

        public int SavePeakCapecity_ByProdPlanning(int OrderDetailId, int UsingInPlanning, double CustEfficiency, int CustProdDay, int LinePlanningId, int UnitId, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "usp_SavePeakCapecity_ByProdPlanning";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UsingInPlanning", SqlDbType.Int);
                    param.Value = UsingInPlanning;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CustEfficiency", SqlDbType.Int);
                    param.Value = CustEfficiency;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CustProdDay", SqlDbType.Int);
                    param.Value = CustProdDay;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                    param.Value = LinePlanningId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return intReturn;
        }

        public DataTable Get_PeakEfficiency(int OrderDetailId, int LinePlanningId, int UnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtPeakEfficiency = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetPeakCapecity";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                param.Value = LinePlanningId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtPeakEfficiency);
                return dtPeakEfficiency;
            }
        }

        public int GetLineCount(int OrderDetailId)
        {
            int LineCount = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "usp_GetLineCount";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    LineCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                LineCount = 0;
            }
            return LineCount;
        }

        public DataSet GetProductionMatrix_ByLine(Int32 OrderDetailId, out int ExFactoryOld)
        {
            ExFactoryOld = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProductionMatrix = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Production_Matrix_ByLine";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter paramOut;
                paramOut = new SqlParameter("@IsExFactoryOld", SqlDbType.Int);
                paramOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramOut);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProductionMatrix);

                if (paramOut.Value != null)
                {
                    ExFactoryOld = Convert.ToInt32(paramOut.Value);
                }

                return dsProductionMatrix;
            }
        }
        public DataTable GetClientColorCode(int OrderDetailId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dsProductionMatrix = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_getClientColorCodeByOderDetailID";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProductionMatrix);



                return dsProductionMatrix;
            }
        }
        //abhishek on 7/2/2016
        public DataSet GetFinshingClusterDetails(string StartDate = "", int Lineno = 0, int SlotId = 0, int ProductionUnit = 0, string Type = "", int UserId = 0)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_getFinishingSlotCluster";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StartDate", SqlDbType.VarChar);
                param.Value = StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = ProductionUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@Type", SqlDbType.VarChar);
                //param.Value = Type;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);
                param = new SqlParameter("@Types", SqlDbType.Int);
                param.Value = Convert.ToInt32(Type);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }
        public DataSet GetFinshingClusterDetailsQcLineMan(string StartDate = "", int Lineno = 0, int SlotId = 0, int ProductionUnit = 0, string Type = "", int UserId = 0)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_getFinishingSlotCluster";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StartDate", SqlDbType.VarChar);
                param.Value = StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = ProductionUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@Type", SqlDbType.VarChar);
                //param.Value = Type;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);
                param = new SqlParameter("@Types", SqlDbType.Int);
                param.Value = Convert.ToInt32(Type);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }
        public DataSet GetFinshingClusterContarctDetails(string StartDate = "", int SlotId = 0, int ProductionUnit = 0, string Type = "", int UserId = 0, int ClusterID = 0, int ClusterCounts = 0)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_getFinishingSlotCluster";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StartDate", SqlDbType.VarChar);
                param.Value = StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = ProductionUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Types", SqlDbType.Int);
                param.Value = Convert.ToInt32(Type);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterID", SqlDbType.Int);
                param.Value = ClusterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterCounts", SqlDbType.Int);
                param.Value = ClusterCounts;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }
        // Added By Prabhaker on 9-5-18
        public DataSet GetBottleNeck_Operation_OrderID(int OrderID, int UnitId, int LineNo, int slotId, int ClusterId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsCount = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetBottleNeck_QC_HourlyReport";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderID", SqlDbType.VarChar);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                param.Value = LineNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@slotId", SqlDbType.Int);
                param.Value = slotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = ClusterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);
            }

        }

        // End on 9-5-18

        // Added By Ravi kumar on 6-7-17
        public DataSet GetStitch_PendingQty_ByStyleCode(string stylecode, int UnitId, int LIneNo, int Days, int TargetQty, int styleid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsCount = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetStitch_PendingQty_ByStyleCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = stylecode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LIneNo", SqlDbType.Int);
                param.Value = LIneNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Days", SqlDbType.Int);
                param.Value = Days;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetPcs", SqlDbType.Int);
                param.Value = TargetQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);

            }
        }

        // Updated on 26-4-2018
        public DataSet GetUpcomingStyle(string StyleCode, int UnitId, int LineNo)
        {
            DataSet UpcomingStyle = new DataSet();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "Usp_GetUpComing_StyleCode";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@UnitID", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LineNo", SqlDbType.Int);
                    param.Value = LineNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    // string UpcomingStyle = cmd.ExecuteScalar().ToString();
                    // return UpcomingStyle;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(UpcomingStyle);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return (UpcomingStyle);

        }

        // Added By Ravi kumar on 1-Sep-17
        public DataSet GetAllQuantity_ByStyleCode(string stylecode, int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsCount = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetAllQuantity_ByStyleCode_ForProductionMatrix";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = stylecode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);

            }
        }

        public DataSet Production_Matrix_Structure(Int32 OrderDetailId, string StyleCode, int FrameNo)
        {
            DataSet dsProductionMatrix = new DataSet();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_Production_Matrix_Structure";

                    cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrameNo", SqlDbType.Int);
                    if (FrameNo == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = FrameNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsProductionMatrix);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return dsProductionMatrix;
        }
        public DataSet GetSlotId()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                string cmdText;
                //cmdText = "usp_GetHourly_Stitching_Finishing_Report";
                cmdText = "GetSlotNo";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);


                cnx.Close();
                return ds;
            }
        }

        public DataSet Accessory_Fabric_ForMatrix(Int32 OrderDetailId, string StyleCode)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProductionMatrix = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Accessory_Fabric_ForMatrix";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProductionMatrix);


                return dsProductionMatrix;
            }
        }

        public string Production_Matrix_Color(int OrderDetailId, string sType, string FabricName, string FabricDetail, string Accessories, int TotalDayStitch)
        {
            string Result = string.Empty;

            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "usp_Production_Matrix_Color";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = sType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricName", SqlDbType.VarChar);
                    param.Value = FabricName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricDetail", SqlDbType.VarChar);
                    param.Value = FabricDetail;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Accessories", SqlDbType.VarChar);
                    param.Value = Accessories;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalDayStitch", SqlDbType.Int);
                    param.Value = TotalDayStitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Color", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    Result = cmd.Parameters["@Color"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return Result;
        }
        public DataTable GetValueAddtionQty(int OrderDetailID, DateTime CreateDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dtCostingExit = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                //cmdText = "Usp_GetPackingListDetails_test";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 10;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                param.Value = CreateDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCostingExit);

                return dtCostingExit;
            }
        }
        public int UpdateHrlyErrorLog(string ErrorMsg, int ProductionUnit, int SlotID, int LineNo, int StyleId)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateErrorLog_HrlyReports";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar);
                paramIn.Value = ErrorMsg;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@ProductionUnit", SqlDbType.Int);
                paramIn.Value = ProductionUnit;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@SlotID", SqlDbType.Int);
                paramIn.Value = SlotID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@LineNo", SqlDbType.Int);
                paramIn.Value = LineNo;
                cmd.Parameters.Add(paramIn);


                paramIn = new SqlParameter("@StyleId", SqlDbType.Int);
                paramIn.Value = StyleId;
                cmd.Parameters.Add(paramIn);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }
        public DataSet GetHalfStitchInOutQty(int Type, int OrderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dtCostingExit = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                //cmdText = "Usp_GetPackingListDetails_test";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCostingExit);

                return dtCostingExit;
            }
        }
        //abhishek 11/1/2018
        public DataSet GetSlotEntryDetails(DateTime SlotCreateDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dtCostingExit = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetSlotWiseEntryDetailsByDate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SlotCreateDate", SqlDbType.DateTime);
                param.Value = SlotCreateDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "All";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCostingExit);

                return dtCostingExit;
            }
        }
        //abhishek 12/9/2018
        public DataSet GetSlotEntryDetailsBylineID(int UnitId, DateTime SlotCreateDate, int LineplaningID, int OrderDetailId, int ClusterId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet ds = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetSlotWiseEntryDetailsByDate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotCreateDate", SqlDbType.DateTime);
                param.Value = SlotCreateDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanningID", SqlDbType.Int);
                param.Value = LineplaningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = ClusterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Single";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                return ds;
            }
        }
        // News letter  
        public DataSet GetMaterialLate(Int32 UnitId, string StyleCode, int LinePlanframeId, int type)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetMaterialLate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar, 20);
                if (StyleCode == string.Empty)
                    param.Value = DBNull.Value;
                else
                    param.Value = StyleCode;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanFrameId", SqlDbType.Int);
                if ((LinePlanframeId == -1) || (LinePlanframeId == 0))
                    param.Value = DBNull.Value;
                else
                    param.Value = LinePlanframeId;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);

                cnx.Close();

                return ds;
            }

        }

        public DataSet GetNewsLetterLinePlan(Int32 UnitId, int LineNo, int type)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetNewsLetterLinePlan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                if ((LineNo == -1) || (LineNo == 0))
                    param.Value = DBNull.Value;
                else
                    param.Value = LineNo;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);

                cnx.Close();

                return ds;
            }

        }

        public DataSet GetNewsLetterLinePlanSummary(int type)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetNewsLetterLinePlanSummary";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);

                cnx.Close();

                return ds;
            }

        }

        // Added By Ravi kumar on 23-3-18 for cluster Pending qty
        public DataSet GetCluster_PendingQty_ByStyleCode(string stylecode, int ClusterId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsCount = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetCluster_PendingQty_ByStyleCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = stylecode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = ClusterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);

            }
        }

        // Bottle Neck work on 2-May-18

        public List<BottleNeck> GetOB_Section_ByStyle(Int32 StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetOB_Section_ByStyle";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<BottleNeck> objBottleNeckList = new List<BottleNeck>();

                while (reader.Read())
                {
                    BottleNeck objBottleNeck = new BottleNeck();
                    objBottleNeck.OBSectionId = (reader["OBSectionId"] != null) ? Convert.ToInt32(reader["OBSectionId"]) : 0;
                    objBottleNeck.OBSectionName = (reader["OBSectionName"] != null) ? reader["OBSectionName"].ToString() : "";

                    objBottleNeckList.Add(objBottleNeck);
                }
                cnx.Close();
                return objBottleNeckList;
            }
        }

        public List<BottleNeck> GetOB_Operation_ByStyle(Int32 StyleId, string SectionName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetOB_Operation_ByStyle";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SectionName", SqlDbType.VarChar);
                param.Value = SectionName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<BottleNeck> objBottleNeckList = new List<BottleNeck>();

                while (reader.Read())
                {
                    BottleNeck objBottleNeck = new BottleNeck();
                    objBottleNeck.OperationId = (reader["OperationId"] != null) ? Convert.ToInt32(reader["OperationId"]) : 0;
                    objBottleNeck.FactoryWorkSpace = (reader["FactoryWorkSpace"] != null) ? reader["FactoryWorkSpace"].ToString() : "";

                    objBottleNeckList.Add(objBottleNeck);
                }

                cnx.Close();
                return objBottleNeckList;
            }
        }

        public int SaveStitching_BottleNeck(BottleNeck objBottleNeck, string SlotDate, int UserId)
        {
            int iSave = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_SaveStitching_BottleNeck";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = objBottleNeck.SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BottleNeckId", SqlDbType.Int);
                    param.Value = objBottleNeck.BottleNeckId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = objBottleNeck.OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                    param.Value = objBottleNeck.LinePlanningId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OBSectionName", SqlDbType.VarChar);
                    param.Value = objBottleNeck.OBSectionName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryWorkSpace", SqlDbType.VarChar);
                    param.Value = objBottleNeck.FactoryWorkSpace;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsBottleNeck", SqlDbType.Bit);
                    param.Value = objBottleNeck.IsBottleNeck;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DumpPcs", SqlDbType.Int);
                    if (objBottleNeck.DumpPcs == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objBottleNeck.DumpPcs;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TgtAgrdQuantity", SqlDbType.Int);
                    if (objBottleNeck.TgtAgrdQuantity == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objBottleNeck.TgtAgrdQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PerHrPcs", SqlDbType.Int);
                    if (objBottleNeck.PerHrPcs == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objBottleNeck.PerHrPcs;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Date", SqlDbType.VarChar);
                    param.Value = SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    iSave = 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                iSave = -1;
            }

            return iSave;
        }

        public DataTable GetStitching_BottleNeck(BottleNeck objBottleNeck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtBottleNeck = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetStitching_BottleNeck";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = objBottleNeck.OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                param.Value = objBottleNeck.LinePlanningId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtBottleNeck);
                return (dtBottleNeck);

            }
        }

        //public int GetResolve_AllBottleNeck(int OrderDetailId, int LinePlanningId, string SlotDate)
        //{
        //    int iSave = 0;
        //    try
        //    {
        //        using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //        {
        //            string result = string.Empty;
        //            cnx.Open();
        //            SqlCommand cmd;
        //            string cmdText;

        //            cmdText = "usp_GetResolve_AllBottleNeck";

        //            cmd = new SqlCommand(cmdText, cnx);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //            SqlParameter param;
        //            param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
        //            param.Value = OrderDetailId;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
        //            param.Value = LinePlanningId;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Date", SqlDbType.VarChar);
        //            param.Value = SlotDate;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            iSave = cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return iSave;
        //}

        public DataTable GetAllFactory_QC()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtBottleNeck = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllFactory_QC";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtBottleNeck);
                return (dtBottleNeck);

            }
        }

        public int SaveStitching_QC(StitchQC objStitchQC, string SlotDate, int UserId, int UnitID, out int QCSlotWiseId)
        {
            int iSave = 0;
            QCSlotWiseId = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_SaveStitching_QC";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = objStitchQC.SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = objStitchQC.OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                    param.Value = objStitchQC.LinePlanningId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PcsCheckd", SqlDbType.Int);
                    param.Value = objStitchQC.PcsChecked;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PcsFailed", SqlDbType.Int);
                    param.Value = objStitchQC.PcsFailed;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FMFI", SqlDbType.Int);
                    param.Value = objStitchQC.FMFI;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FMFI_Decision", SqlDbType.Int);
                    param.Value = objStitchQC.FMFI_Decision;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QCId", SqlDbType.Int);
                    param.Value = objStitchQC.QCId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Date", SqlDbType.VarChar);
                    param.Value = SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitID", SqlDbType.Int);
                    param.Value = UnitID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@ClusterId", SqlDbType.Int);
                    if (objStitchQC.ClusterId > 0)
                        param.Value = objStitchQC.ClusterId;
                    else
                        param.Value = DBNull.Value;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter paramOut;
                    paramOut = new SqlParameter("@QCSlotWiseId", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);

                    iSave = cmd.ExecuteNonQuery();

                    QCSlotWiseId = Convert.ToInt32(paramOut.Value);


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

            return iSave;
        }

        public int SaveStitching_QC_Faults(StitchQC objStitchQC, string SlotDate, int UserId, int QCSlotWiseId, int flag, int UnitID)
        {
            int iSave = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_SaveStitching_QC_Faults";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@QCSlotWiseFaultsId", SqlDbType.Int);
                    param.Value = objStitchQC.QCSlotWiseFaultsId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QCSlotWiseId", SqlDbType.Int);
                    param.Value = QCSlotWiseId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FaultCode", SqlDbType.VarChar);
                    param.Value = objStitchQC.FaultCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FaultCount", SqlDbType.Int);
                    param.Value = objStitchQC.FaultCount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = objStitchQC.SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Date", SqlDbType.VarChar);
                    param.Value = SlotDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@flag", SqlDbType.Int);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = objStitchQC.OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                    param.Value = objStitchQC.LinePlanningId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ClusterId", SqlDbType.Int);
                    if (objStitchQC.ClusterId > 0)
                        param.Value = objStitchQC.ClusterId;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    iSave = cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

            return iSave;
        }

        public DataSet GetStitching_QC(StitchQC objStitchQC, string SlotDate, int UnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsStitchingQC = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetStitching_QC";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = objStitchQC.SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = objStitchQC.OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanningId", SqlDbType.Int);
                param.Value = objStitchQC.LinePlanningId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                if (objStitchQC.ClusterId > 0)
                    param.Value = objStitchQC.ClusterId;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = SlotDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsStitchingQC);
                return (dsStitchingQC);

            }
        }

        public int Delete_BottleNeck(BottleNeck objBottleNeck)
        {
            int iDelete = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_Delete_BottleNeck";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@BottleNeckId", SqlDbType.Int);
                    param.Value = objBottleNeck.BottleNeckId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();
                    iDelete = 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                iDelete = -1;
            }

            return iDelete;
        }


        public int Delete_QC_Faults(StitchQC objStitchQC)
        {
            int iDelete = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_Delete_QC_Faults";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@SlotId", SqlDbType.Int);
                    param.Value = objStitchQC.SlotId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QCSlotWiseId", SqlDbType.Int);
                    param.Value = objStitchQC.QCId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QCSlotWiseFaultsId", SqlDbType.Int);
                    param.Value = objStitchQC.QCSlotWiseFaultsId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();
                    iDelete = 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                iDelete = -1;
            }

            return iDelete;
        }
        public List<string> GetOB_Operation_ByStyle_Autocompl(int StyleId, string SectionName, string q)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetOB_Operation_ByStyle";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SectionName", SqlDbType.VarChar);
                param.Value = SectionName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Q", SqlDbType.VarChar);
                param.Value = q;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> objBottleNeckList = new List<string>();

                while (reader.Read())
                {
                    string objBottleNeck = "";
                    //  objBottleNeck.OperationId = (reader["OperationId"] != null) ? Convert.ToInt32(reader["OperationId"]) : 0;
                    objBottleNeck = (reader["FactoryWorkSpace"] != null) ? reader["FactoryWorkSpace"].ToString() : "";

                    objBottleNeckList.Add(objBottleNeck);
                }

                cnx.Close();
                return objBottleNeckList;
            }
        }

        public DataSet GetHourlyReportStyleCode(string FactoryName, string StyleCode, int LineNo, int UnitId, int IsCluster, int ClusterId, string Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetHourly_Stitching_Finishing_Report";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = FactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineNo", SqlDbType.Int);
                param.Value = LineNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionUnit", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsCluster", SqlDbType.Int);
                param.Value = IsCluster;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = ClusterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }

        public DataSet GetBottleNeck_QC_StyleCode_HourlyReport(string StyleCode, int LinePlanFrameId, int UnitId, int slotId, int ClusterId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsCount = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetBottleNeck_QC_ByLinePlanFrameId_HourlyReport";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanFrameId", SqlDbType.Int);
                param.Value = LinePlanFrameId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@slotId", SqlDbType.Int);
                param.Value = slotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = ClusterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);
            }

        }

        public DataSet GetPending_Stitch_FinishQty_ByStyleCode(string stylecode, int StyleId, int UnitId, int LIneNo, int Days, int TargetQty)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsCount = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPending_Stitch_FinishQty_ByStyleCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = stylecode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LIneNo", SqlDbType.Int);
                param.Value = LIneNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Days", SqlDbType.Int);
                param.Value = Days;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetPcs", SqlDbType.Int);
                param.Value = TargetQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);

            }
        }

        public DataSet GetBottleNeck_QC_HourlyReport_ForFactory(int UnitId, int TotalCount, int SlotId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsCount = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetBottleNeck_QC_HourlyReport_ForFactory";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@TotalCount", SqlDbType.Int);
                param.Value = TotalCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SlotId", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);
            }

        }
        public DataTable GetTopFualtDetails(int orderDetailID, DateTime date)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dsCount = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetTopFualtPer";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OderDetailID", SqlDbType.Int);
                param.Value = orderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Date", SqlDbType.Date);
                param.Value = date;//DateTime.ParseExact(date, "dd MMM (ddd)", System.Globalization.CultureInfo.InvariantCulture);

                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCount);
                return (dsCount);
            }

        }

        public int UpdateSlotWiseEntryDetailsByDate(StitchingDetail objStitchingDetail, int UserId)
        {
            int iSave = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_UpdateSlotWiseEntryDetailsByDate";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = objStitchingDetail.ProductionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SlotCreateDate", SqlDbType.Date);
                    param.Value = objStitchingDetail.SlotCreateDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinePlanningID", SqlDbType.Int);
                    param.Value = objStitchingDetail.LinePlanningID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = objStitchingDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClusterId", SqlDbType.Int);
                    param.Value = objStitchingDetail.ClusterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Slot wise Stitch
                    param = new SqlParameter("@Slot1Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot1Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot2Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot2Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot3Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot3Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot4Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot4Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot5Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot5Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot6Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot6Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot7Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot7Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot8Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot8Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot9Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot9Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot10Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot10Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot11Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot11Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot12Stitch", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot12Stitch;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Slot wise Finish
                    param = new SqlParameter("@Slot1Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot1Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot2Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot2Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot3Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot3Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot4Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot4Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot5Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot5Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot6Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot6Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot7Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot7Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot8Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot8Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot9Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot9Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot10Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot10Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot11Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot11Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot12Finish", SqlDbType.Int);
                    param.Value = objStitchingDetail.Slot12Finish;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Slot wise ZeroProductivity
                    param = new SqlParameter("@Slot1ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot1ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot2ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot2ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot3ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot3ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot4ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot4ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot5ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot5ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot6ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot6ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot7ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot7ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot8ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot8ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot9ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot9ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot10ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot10ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot11ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot11ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slot12ZeroProductivity", SqlDbType.Bit);
                    param.Value = objStitchingDetail.Slot12ZeroProductivity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    iSave = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                iSave = 0;
            }

            return iSave;
        }

        public int AddRescanCycle(int OrderDetailId)
        {
            int iAdd = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_AddRescanCycle";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    iAdd = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                iAdd = -1;
            }

            return iAdd;
        }


        public DataSet GetProduction_SectionFor_HourlyReport(string StyleCode, int LinePlanFrameId, int StyleId, int UnitId, int LIneNo, int SlotId, int Days, int TargetQty, int IsCluster, int ClusterId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProduction = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetProduction_SectionFor_HourlyReport";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LinePlanFrameId", SqlDbType.Int);
                param.Value = LinePlanFrameId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LIneNo", SqlDbType.Int);
                param.Value = LIneNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@slotId", SqlDbType.Int);
                param.Value = SlotId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Days", SqlDbType.Int);
                param.Value = Days;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetPcs", SqlDbType.Int);
                param.Value = TargetQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsCluster", SqlDbType.Int);
                param.Value = IsCluster;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClusterId", SqlDbType.Int);
                param.Value = ClusterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsProduction);

                return dsProduction;

            }
        }

        public int SaveBIPLGlobalDailyIE(float CutQty_C45_46, float FinishedQty_C45_46, float StitchedQty_C45_46,
                                         float CutQty_C47, float FinishedQty_C47, float StitchedQty_C47,
                                         float CutQty_D169, float FinishedQty_D169, float StitchedQty_D169,
                                         float CutQty, float FinishedQty, float StitchedQty, 
                                         float CutRate_C45_46, float FinishedRate_C45_46, float StitchingEfficiency_C45_46, float Achievement_C45_46,
                                         float CutRate_C47, float FinishedRate_C47, float StitchingEfficiency_C47, float Achievement_C47,
                                         float CutRate_D169, float FinishedRate_D169, float StitchingEfficiency_D169, float Achievement_D169,
                                         float CutRate_BIPL, float FinishedRate_BIPL, float StitchingEfficiency_BIPL, float Achievement_BIPL,bool TaskClosed)
        {
            int Id = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_AddBIPLGlobalDailyIE";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;                    

                    param = new SqlParameter("@type", SqlDbType.VarChar);
                    param.Value = "insert";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@CutQty_C45", SqlDbType.Float);
                    param.Value = CutQty_C45_46;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedQty_C45", SqlDbType.Float);
                    param.Value = FinishedQty_C45_46;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchedQty_C45", SqlDbType.Float);
                    param.Value = StitchedQty_C45_46;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CutQty_C47", SqlDbType.Float);
                    param.Value = CutQty_C47;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedQty_C47", SqlDbType.Float);
                    param.Value = FinishedQty_C47;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchedQty_C47", SqlDbType.Float);
                    param.Value = StitchedQty_C47;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CutQty_D169", SqlDbType.Float);
                    param.Value = CutQty_D169;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedQty_D169", SqlDbType.Float);
                    param.Value = FinishedQty_D169;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchedQty_D169", SqlDbType.Float);
                    param.Value = StitchedQty_D169;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //added by raghvinder on 02-11-2020 start
                    //param = new SqlParameter("@CutQty_C52", SqlDbType.Float);
                    //param.Value = CutQty_C52;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FinishedQty_C52", SqlDbType.Float);
                    //param.Value = FinishedQty_C52;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@StitchedQty_C52", SqlDbType.Float);
                    //param.Value = StitchedQty_C52;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //added by raghvinder on 02-11-2020 end

                    param = new SqlParameter("@CutQty", SqlDbType.Float);
                    param.Value = CutQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedQty", SqlDbType.Float);
                    param.Value = FinishedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchedQty", SqlDbType.Float);
                    param.Value = StitchedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@CutRate_C45_46", SqlDbType.Float);
                    param.Value = CutRate_C45_46;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedRate_C45_46", SqlDbType.Float);
                    param.Value = FinishedRate_C45_46;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchingEfficiency_C45_46", SqlDbType.Float);
                    param.Value = StitchingEfficiency_C45_46;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@achievement_C45_46", SqlDbType.Float);
                    param.Value = Achievement_C45_46;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CutRate_C47", SqlDbType.Float);
                    param.Value = CutRate_C47;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedRate_C47", SqlDbType.Float);
                    param.Value = FinishedRate_C47;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchingEfficiency_C47", SqlDbType.Float);
                    param.Value = StitchingEfficiency_C47;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@achievement_C47", SqlDbType.Float);
                    param.Value = Achievement_C47;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CutRate_D169", SqlDbType.Float);
                    param.Value = CutRate_D169;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedRate_D169", SqlDbType.Float);
                    param.Value = FinishedRate_D169;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchingEfficiency_D169", SqlDbType.Float);
                    param.Value = StitchingEfficiency_D169;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@achievement_D169", SqlDbType.Float);
                    param.Value = Achievement_D169;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //added by raghvinder on 02-11-2020 start
                    //param = new SqlParameter("@CutRate_C52", SqlDbType.Float);
                    //param.Value = CutRate_C52;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FinishedRate_C52", SqlDbType.Float);
                    //param.Value = FinishedRate_C52;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@StitchingEfficiency_C52", SqlDbType.Float);
                    //param.Value = StitchingEfficiency_C52;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@achievement_C52", SqlDbType.Float);
                    //param.Value = Achievement_C52;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    ////added by raghvinder on 02-11-2020 end

                    param = new SqlParameter("@CutRate_BIPL", SqlDbType.Float);
                    param.Value = CutRate_BIPL;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishedRate_BIPL", SqlDbType.Float);
                    param.Value = FinishedRate_BIPL;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StitchingEfficiency_BIPL", SqlDbType.Float);
                    param.Value = StitchingEfficiency_BIPL;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@achievement_BIPL", SqlDbType.Float);
                    param.Value = Achievement_BIPL;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TaskClosed", SqlDbType.Bit);
                    param.Value = TaskClosed;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                Id = -1;
            }

            return Id;
        }

        //Code Added by bharat on 03-01-2020

        public int AddValueAdditonPo(PO_Valueaddition poValueaddition)
        {
            int Id = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "USP_Insert_Update_ValueAddedPO";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@DateofIssue", SqlDbType.DateTime);
                    if ((poValueaddition.DateofIssue == DateTime.MinValue) || (poValueaddition.DateofIssue == Convert.ToDateTime("01-01-1753")) || (poValueaddition.DateofIssue == Convert.ToDateTime("01-01-1753 12:00:00")) || (poValueaddition.DateofIssue == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = poValueaddition.DateofIssue;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreedQty", SqlDbType.Int);
                    param.Value = poValueaddition.AgreedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreedRate", SqlDbType.Decimal);
                    param.Value = poValueaddition.AgreedRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryStartDate", SqlDbType.DateTime);
                    if ((poValueaddition.DeliveryStartDate == DateTime.MinValue) || (poValueaddition.DeliveryStartDate == Convert.ToDateTime("01-01-1753")) || (poValueaddition.DeliveryStartDate == Convert.ToDateTime("01-01-1753 12:00:00")) || (poValueaddition.DeliveryStartDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = poValueaddition.DeliveryStartDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryEndDate", SqlDbType.DateTime);
                    if ((poValueaddition.DeliveryEndDate == DateTime.MinValue) || (poValueaddition.DeliveryEndDate == Convert.ToDateTime("01-01-1753")) || (poValueaddition.DeliveryEndDate == Convert.ToDateTime("01-01-1753 12:00:00")) || (poValueaddition.DeliveryEndDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = poValueaddition.DeliveryEndDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActualEndDate", SqlDbType.DateTime);
                    if ((poValueaddition.ActualEndDate == DateTime.MinValue) || (poValueaddition.ActualEndDate == Convert.ToDateTime("01-01-1753")) || (poValueaddition.ActualEndDate == Convert.ToDateTime("01-01-1753 12:00:00")) || (poValueaddition.ActualEndDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = poValueaddition.ActualEndDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateforLateDelivery", SqlDbType.Float);
                    param.Value = poValueaddition.DebitforLateDelivery;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitforAlteration", SqlDbType.Decimal);
                    param.Value = poValueaddition.DebitforAltration;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RiskVASupplierid", SqlDbType.Int);
                    param.Value = poValueaddition.RiskVASupplierid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                    param.Value = poValueaddition.SupplierName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VendorSig", SqlDbType.Bit);
                    param.Value = poValueaddition.VendorSignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BiplMngtSig", SqlDbType.Bit);
                    param.Value = poValueaddition.BIPLMngtSignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GmPlanningSig", SqlDbType.Bit);
                    param.Value = poValueaddition.GMPlanningSignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Unit", SqlDbType.VarChar);
                    param.Value = poValueaddition.Unit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = poValueaddition.UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Job", SqlDbType.VarChar);
                    param.Value = poValueaddition.job;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = poValueaddition.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PO_Number", SqlDbType.VarChar);
                    param.Value = poValueaddition.PoNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SerialNo", SqlDbType.VarChar);
                    param.Value = poValueaddition.SerialNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleNo", SqlDbType.VarChar);
                    param.Value = poValueaddition.StyleNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                   


                    Id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                Id = -1;
            }

            return Id;
        }

        public PO_Valueaddition GetValueAdditonPo(int RiskVASupplierId, string PONumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                PO_Valueaddition objvalueadditionpo = new PO_Valueaddition();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "ASP_Get_ValueAddedPO";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@RiskVASupplierId", SqlDbType.Int);
                param.Value = RiskVASupplierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GetValueAdditionPO";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PONumber", SqlDbType.VarChar);
                param.Value = PONumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];

                if (dt.Rows.Count > 0)
                {
                    objvalueadditionpo.PoNumber = dt.Rows[0]["Po_Number"] == DBNull.Value ? "" : dt.Rows[0]["Po_Number"].ToString();
                    objvalueadditionpo.DateofIssue = dt.Rows[0]["DateOfIssue"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DateOfIssue"]);
                    objvalueadditionpo.AgreedQty = dt.Rows[0]["AgreedQty"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["AgreedQty"]);
                    objvalueadditionpo.AgreedRate = dt.Rows[0]["AgreeRate"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["AgreeRate"]);
                    objvalueadditionpo.DeliveryStartDate = dt.Rows[0]["DeliveryStartForms"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DeliveryStartForms"]);
                    objvalueadditionpo.DeliveryEndDate = dt.Rows[0]["DeliveryEndForms"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DeliveryEndForms"]);
                    objvalueadditionpo.UserStartDate = dt.Rows[0]["UserStartDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["UserStartDate"]);
                    objvalueadditionpo.UserEndDate = dt.Rows[0]["UserEndDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["UserEndDate"]);
                    objvalueadditionpo.ActualEndDate = dt.Rows[0]["ActualEndDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["ActualEndDate"]);
                    objvalueadditionpo.DebitforLateDelivery = dt.Rows[0]["DebitForLateDelivery"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["DebitForLateDelivery"]);
                    objvalueadditionpo.DebitforAltration = dt.Rows[0]["DebitForAlternation"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["DebitForAlternation"]);
                    // objvalueadditionpo.RiskVASupplierid = dt.Rows[0]["RiskVA_Supplier_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["RiskVA_Supplier_ID"]);
                    objvalueadditionpo.SupplierName = dt.Rows[0]["Supplier"] == DBNull.Value ? "" : dt.Rows[0]["Supplier"].ToString();
                    objvalueadditionpo.VendorSignature = dt.Rows[0]["VendorSignature"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["VendorSignature"]);
                    objvalueadditionpo.BIPLMngtSignature = dt.Rows[0]["BIPLMangementSignature"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["BIPLMangementSignature"]);
                    objvalueadditionpo.GMPlanningSignature = dt.Rows[0]["GMPlanningSignature"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["GMPlanningSignature"]);
                    objvalueadditionpo.StyleNo = dt.Rows[0]["StyleNumber"] == DBNull.Value ? "" : dt.Rows[0]["StyleNumber"].ToString();
                    objvalueadditionpo.SAM = dt.Rows[0]["SAMValue"] == DBNull.Value ? "" : dt.Rows[0]["SAMValue"].ToString();
                    objvalueadditionpo.Unit = dt.Rows[0]["Unit"] == DBNull.Value ? "" : dt.Rows[0]["Unit"].ToString();
                    objvalueadditionpo.VendorSignatureDate = dt.Rows[0]["VendorSignatureDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["VendorSignatureDate"]);
                    objvalueadditionpo.BIPLMngtSignatureDate = dt.Rows[0]["BIPLMangementSignatureDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["BIPLMangementSignatureDate"]);
                    objvalueadditionpo.GMPlanningSignatureDate = dt.Rows[0]["GMPlanningSignatureDatetime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["GMPlanningSignatureDatetime"]);
                    objvalueadditionpo.SupplierId = dt.Rows[0]["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["SupplierId"]);
                    objvalueadditionpo.job = dt.Rows[0]["Job"] == DBNull.Value ? "" : dt.Rows[0]["Job"].ToString();
                    objvalueadditionpo.Remarks = dt.Rows[0]["Remarks"] == DBNull.Value ? "" : dt.Rows[0]["Remarks"].ToString();
                    objvalueadditionpo.GMPlanningID = dt.Rows[0]["GMPlanningID"] == DBNull.Value ? "" : dt.Rows[0]["GMPlanningID"].ToString();
                }

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (i == dt1.Rows.Count - 1)
                        objvalueadditionpo.SerialNo += dt1.Rows[i]["SerialNumber"].ToString();
                    else
                    objvalueadditionpo.SerialNo +=  dt1.Rows[i]["SerialNumber"].ToString() + ", ";                   
                }

                objvalueadditionpo.RateHistory = dt2.Rows[0]["RateHistory"].ToString();

                return objvalueadditionpo;
            }
        }


        //Code Adde By Bharat On 13-jul-2020
        public DataTable VAMinRateReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "SP_Get_Supplier_MinRate";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt;
            }
        }

        //public DataTable VendorServiceDetails()
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        DataTable dt = new DataTable();
        //        cnx.Open();
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "USP_Get_Supplier_Activity_OnValueAddition";

        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dt);

        //        return dt;
        //    }
        //}
        //End

        public DataTable GetValueAdditonPOHistory(int RiskVASupplierId, string PONumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "ASP_Get_ValueAddedPO";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@RiskVASupplierId", SqlDbType.Int);
                param.Value = RiskVASupplierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GetValueAdditionHistory";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PONumber", SqlDbType.VarChar);
                param.Value = PONumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dt);

                return dt;
            }
        }

        public int AddStitchHousePo(PO_StitchCutHouse ObjPoStitchHouse)
        {
            int Id = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "USP_Insert_Update_StichOutHousePO";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@DateofIssue", SqlDbType.DateTime);
                    if ((ObjPoStitchHouse.StitchDateofIssue == DateTime.MinValue) || (ObjPoStitchHouse.StitchDateofIssue == Convert.ToDateTime("01-01-1753")) || (ObjPoStitchHouse.StitchDateofIssue == Convert.ToDateTime("01-01-1753 12:00:00")) || (ObjPoStitchHouse.StitchDateofIssue == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = ObjPoStitchHouse.StitchDateofIssue;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreedQty", SqlDbType.Int);
                    param.Value = ObjPoStitchHouse.StitchAgreedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreedRate", SqlDbType.Decimal);
                    param.Value = ObjPoStitchHouse.StitchAgreedRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreedRateFinish", SqlDbType.Decimal);
                    param.Value = ObjPoStitchHouse.FinishAgreedRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryStartDate", SqlDbType.DateTime);
                    if ((ObjPoStitchHouse.StitchDeliveryStartDate == DateTime.MinValue) || (ObjPoStitchHouse.StitchDeliveryStartDate == Convert.ToDateTime("01-01-1753")) || (ObjPoStitchHouse.StitchDeliveryStartDate == Convert.ToDateTime("01-01-1753 12:00:00")) || (ObjPoStitchHouse.StitchDeliveryStartDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = ObjPoStitchHouse.StitchDeliveryStartDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryEndDate", SqlDbType.DateTime);
                    if ((ObjPoStitchHouse.StitchDeliveryEndDate == DateTime.MinValue) || (ObjPoStitchHouse.StitchDeliveryEndDate == Convert.ToDateTime("01-01-1753")) || (ObjPoStitchHouse.StitchDeliveryEndDate == Convert.ToDateTime("01-01-1753 12:00:00")) || (ObjPoStitchHouse.StitchDeliveryEndDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = ObjPoStitchHouse.StitchDeliveryEndDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActualEndDate", SqlDbType.DateTime);
                    if ((ObjPoStitchHouse.StitchActualEndDate == DateTime.MinValue) || (ObjPoStitchHouse.StitchActualEndDate == Convert.ToDateTime("01-01-1753")) || (ObjPoStitchHouse.StitchActualEndDate == Convert.ToDateTime("01-01-1753 12:00:00")) || (ObjPoStitchHouse.StitchActualEndDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = ObjPoStitchHouse.StitchActualEndDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateforLateDelivery", SqlDbType.Float);
                    param.Value = ObjPoStitchHouse.StitchDebitforLateDelivery;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitforAlteration", SqlDbType.Decimal);
                    param.Value = ObjPoStitchHouse.StitchDebitforAltration;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = ObjPoStitchHouse.StitchOrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LocationType", SqlDbType.Int);
                    param.Value = ObjPoStitchHouse.StitchLocationType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.StitchSupplierName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleNo", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.StitchStyleNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SerialNo", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.StitchSerialNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VendorSig", SqlDbType.Bit);
                    param.Value = ObjPoStitchHouse.StitchSignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@BiplMngtSig", SqlDbType.Bit);
                    param.Value = ObjPoStitchHouse.StitchBIPLMngtSignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GmPlanningSig", SqlDbType.Bit);
                    param.Value = ObjPoStitchHouse.StitchGMPlanningSignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Unit", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.StitchUnit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = ObjPoStitchHouse.StitchUserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Job", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.Stitchjob;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SAMValue", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.StitchSAM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.StitchRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PO_Number", SqlDbType.VarChar);
                    param.Value = ObjPoStitchHouse.StitchPoNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishSam", SqlDbType.VarChar);
                    if (ObjPoStitchHouse.FinishSAM == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = ObjPoStitchHouse.FinishSAM;
                    }
                    param.Value = ObjPoStitchHouse.FinishSAM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                Id = -1;
            }

            return Id;
        }

        public PO_StitchCutHouse GetStitchHousePo(int OrderDetailid, int LocationType, string PONumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                PO_StitchCutHouse objStitchPo = new PO_StitchCutHouse();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_StichOutHousePO";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GetStitchOutHosePO";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PONumber", SqlDbType.VarChar);
                param.Value = PONumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LocationType", SqlDbType.Int);
                param.Value = LocationType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];

                if (dt.Rows.Count > 0)
                {
                    objStitchPo.StitchPoNumber = dt.Rows[0]["Po_Number"] == DBNull.Value ? "" : dt.Rows[0]["Po_Number"].ToString();
                    objStitchPo.StitchDateofIssue = dt.Rows[0]["DateOfIssue"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DateOfIssue"]);
                    objStitchPo.StitchAgreedQty = dt.Rows[0]["AgreedQty"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["AgreedQty"]);
                    objStitchPo.StitchAgreedRate = dt.Rows[0]["AgreeRate"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["AgreeRate"]);
                    objStitchPo.FinishAgreedRate = dt.Rows[0]["FinishAgreedRate"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["FinishAgreedRate"]);
                    objStitchPo.StitchDeliveryStartDate = dt.Rows[0]["DeliveryStartForms"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DeliveryStartForms"]);
                    objStitchPo.StitchDeliveryEndDate = dt.Rows[0]["DeliveryEndForms"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DeliveryEndForms"]);
                    objStitchPo.StitchActualEndDate = dt.Rows[0]["ActualEndDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["ActualEndDate"]);
                    objStitchPo.StitchDebitforLateDelivery = dt.Rows[0]["DebitForLateDelivery"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["DebitForLateDelivery"]);
                    objStitchPo.StitchDebitforAltration = dt.Rows[0]["DebitForAlternation"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["DebitForAlternation"]);
                    // objvalueadditionpo.RiskVASupplierid = dt.Rows[0]["RiskVA_Supplier_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["RiskVA_Supplier_ID"]);
                    objStitchPo.StitchSupplierName = dt.Rows[0]["Supplier"] == DBNull.Value ? "" : dt.Rows[0]["Supplier"].ToString();
                    objStitchPo.StitchSignature = dt.Rows[0]["VendorSignature"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["VendorSignature"]);
                    objStitchPo.StitchBIPLMngtSignature = dt.Rows[0]["BIPLMangementSignature"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["BIPLMangementSignature"]);
                    objStitchPo.StitchGMPlanningSignature = dt.Rows[0]["GMPlanningSignature"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["GMPlanningSignature"]);
                    objStitchPo.StitchStyleNo = dt.Rows[0]["StyleNumber"] == DBNull.Value ? "" : dt.Rows[0]["StyleNumber"].ToString();
                    objStitchPo.StitchSAM = dt.Rows[0]["SAMValue"] == DBNull.Value ? "" : dt.Rows[0]["SAMValue"].ToString();
                    objStitchPo.FinishSAM = dt.Rows[0]["FinishSam"] == DBNull.Value ? "" : dt.Rows[0]["FinishSam"].ToString();
                    objStitchPo.StitchUnit = dt.Rows[0]["Unit"] == DBNull.Value ? "" : dt.Rows[0]["Unit"].ToString();
                    objStitchPo.StitchSignatureDate = dt.Rows[0]["VendorSignatureDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["VendorSignatureDate"]);
                    objStitchPo.StitchBIPLMngtSignatureDate = dt.Rows[0]["BIPLMangementSignatureDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["BIPLMangementSignatureDate"]);
                    objStitchPo.StitchGMPlanningSignatureDate = dt.Rows[0]["GMPlanningSignatureDatetime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["GMPlanningSignatureDatetime"]);
                    objStitchPo.StitchSupplierId = dt.Rows[0]["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["SupplierId"]);
                    objStitchPo.Stitchjob = dt.Rows[0]["Job"] == DBNull.Value ? "" : dt.Rows[0]["Job"].ToString();
                    objStitchPo.StitchRemarks = dt.Rows[0]["Remarks"] == DBNull.Value ? "" : dt.Rows[0]["Remarks"].ToString();
                }
                objStitchPo.StitchSerialNo = dt1.Rows[0]["SerialNumber"].ToString();
                //for (int i = 0; i < dt1.Rows.Count; i++)
                //{
                //    if (i == dt1.Rows.Count - 1)
                //        objStitchPo.StitchSerialNo += dt1.Rows[i]["SerialNumber"].ToString();
                //    else
                //        objStitchPo.StitchSerialNo += dt1.Rows[i]["SerialNumber"].ToString() + ", ";
                //}
                return objStitchPo;
            }
        }

        public DataTable GetStitchHousePOHistory(int OrderDetailId, int LocationType, string PONumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_StichOutHousePO";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GetStitchOutHoseHistory";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PONumber", SqlDbType.VarChar);
                param.Value = PONumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LocationType", SqlDbType.Int);
                param.Value = LocationType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dt);

                return dt;
            }
        }
        //added by raghvinder on 22-07-2020 start

        //added by raghvinder on 09-10-2020 start
        public DataTable GetMaterialRequired_Actual_Report()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtSavingReport = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_MaterialRequired_Actual_Report";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GRIDVIEW";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtSavingReport);

                return dtSavingReport;
            }
        }
        //added by raghvinder on 09-10-2020 end

        //added by raghvinder on 27-07-2020 start
        public DataTable GetSalesOHRevenue()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtSavingReport = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_Sales_Report_Barchart_Grid_Binding";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GRIDVIEW";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtSavingReport);

                return dtSavingReport;
            }
        }

        //added by raghvinder on 27-07-2020 end

        //added by raghvinder on 22-07-2020 end
        public DataTable GetFinancialSavingReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtSavingReport = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "uspGetMonthlyFinancialSavingReport";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtSavingReport);

                return dtSavingReport;
            }
        }
        //added by raghvinder on 21-07-2020 start
        public DataTable GetMeterRevenueReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtRevenueReport = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_Meter_Revenue_Reports";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtRevenueReport);

                return dtRevenueReport;
            }
        }
        //added by raghvinder on 21-07-2020 end
        
        public DataSet GetQuarterlyAverageReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsProduction = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GetQuarterlyAverageSavingReport";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsProduction);

                return dsProduction;
            }
        }


        public DataSet GetBIPLGlobalDailyIE()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_AddBIPLGlobalDailyIE";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param;

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "select";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds);

                return ds;
            }
        }
        public DataTable BindPODropDown()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_AddValueAddionPO";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

              
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

               

                adapter.Fill(dt);

                return dt;
            }
        }


        public DataTable BindSAMDropDown(int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetSAM_For_StitchPO";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param;

                param = new SqlParameter("@OrderDetailId", SqlDbType.VarChar);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dt);

                return dt;
            }
        }
        public DataTable BindFinishSAMDropDown(int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetSAM_For_StitchFinishPO";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param;

                param = new SqlParameter("@OrderDetailId", SqlDbType.VarChar);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dt);

                return dt;
            }
        }
        public DataSet PO_ValueAdditionName(string JobID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetJob_From_PO";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param;

                param = new SqlParameter("@JobID", SqlDbType.VarChar);
                param.Value = JobID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds);

                return ds;
            }
        }

        public DataSet GetDepartmentName()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                List<Client_Department> obkmain = new List<Client_Department>();
                Client_Department objDepartment = new Client_Department();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                //cmdText = "usp_Get_Department_For_ProductList";
                cmdText = "usp_Get_Filters_For_ProductList";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                
                return ds; 
            }
        }

        public DataSet GetDepartmentCurrency(int CurrencyValueB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                List<Client_Department> obkmain = new List<Client_Department>();
                Client_Department objDepartment = new Client_Department();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                //cmdText = "usp_Get_Department_For_ProductList";
                cmdText = "usp_Get_Filters_For_Currency";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param;

                param = new SqlParameter("@FlagCurrency", SqlDbType.Int);
                param.Value = CurrencyValueB;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds);

                return ds;
            }
        }

        //public List<Client_Department> GetFabricDepartmentName()
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        DataSet ds = new DataSet();
        //        List<Client_Department> FabData = new List<Client_Department>();

        //        cnx.Open();
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "usp_Get_Fabric_For_ProductList";

        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //        adapter.Fill(ds);
        //        DataTable dt = ds.Tables[0];
        //        // DataTable dt1 = ds.Tables[1];

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Client_Department objFabDepartment = new Client_Department();
        //            objFabDepartment.FabricDepartmentName = dt.Rows[i]["FabricName"] == DBNull.Value ? "" : dt.Rows[i]["FabricName"].ToString();
        //            //objFabDepartment.FabricDepartmentId = dt.Rows[i]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["ID"]);
        //            FabData.Add(objFabDepartment);
        //        }
        //        return FabData;
        //    }
        //}

        public List<Client_Department> GetDesinsPatterns(string FASearchVal, string ParentDepartVal, string FAFabriVal, string FTags, string FComposition, string FCollection, string MarMoq, decimal MinCostVlaue, decimal MaxCostValue, int CurrencyValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                List<Client_Department> DesData = new List<Client_Department>();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_ProductList";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param;
                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = FASearchVal;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDepartmentID", SqlDbType.VarChar);
                param.Value = ParentDepartVal;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                
                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = FAFabriVal;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Tags", SqlDbType.VarChar);
                param.Value = FTags;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Composition", SqlDbType.VarChar);
                param.Value = FComposition;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Collection", SqlDbType.VarChar);
                param.Value = FCollection;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MOQid", SqlDbType.VarChar);
                param.Value = MarMoq;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MinCostingVlaue", SqlDbType.Decimal);
                param.Value = MinCostVlaue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MaxCostingValue", SqlDbType.Decimal);
                param.Value = MaxCostValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DefaultCurrency", SqlDbType.Int);
                param.Value = CurrencyValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                // DataTable dt1 = ds.Tables[1];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Client_Department objDesinsPa = new Client_Department();
                    objDesinsPa.FabricStyleId = dt.Rows[i]["Styleid"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["Styleid"]);
                    objDesinsPa.DesignsImg = dt.Rows[i]["SampleImageURL"] == DBNull.Value ? "" : dt.Rows[i]["SampleImageURL"].ToString();
                    objDesinsPa.GarmentStyleNo = dt.Rows[i]["StyleNumber"] == DBNull.Value ? "" : dt.Rows[i]["StyleNumber"].ToString();
                    objDesinsPa.MarketingPrice = dt.Rows[i]["MarketingPrice"] == DBNull.Value ? "" : dt.Rows[i]["MarketingPrice"].ToString();
                    objDesinsPa.DesigFabricName = dt.Rows[i]["Fabric"] == DBNull.Value ? "" : dt.Rows[i]["Fabric"].ToString();
                    objDesinsPa.FabShortDescription = dt.Rows[i]["MarketingShortDescription"] == DBNull.Value ? "" : dt.Rows[i]["MarketingShortDescription"].ToString();
                    objDesinsPa.ProTitle = dt.Rows[i]["MarketingTitle"] == DBNull.Value ? "" : dt.Rows[i]["MarketingTitle"].ToString();
                    objDesinsPa.MarkingCount = dt.Rows[i]["LikeCount"] == DBNull.Value ? "" : dt.Rows[i]["LikeCount"].ToString();
                    DesData.Add(objDesinsPa);
                }
                return DesData;
            }
        }

        public Client_Department GetProductDetails(int ProductNameFro, int ProductCurrency)
        {
            Client_Department objDesinsProDe = new Client_Department();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_StyleDetails_ProductList";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param;
                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = ProductNameFro;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //added by raghvinder on 05-03-2020 start 
                param = new SqlParameter("@Currency", SqlDbType.Int);
                param.Value = ProductCurrency;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                //added by raghvinder on 05-03-2020 end

                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                // DataTable dt1 = ds.Tables[1];Jersey_Fashion_Top

                if (dt.Rows.Count > 0)
                {

                    objDesinsProDe.DesignsImg = dt.Rows[0]["MainImage"] == DBNull.Value ? "" : dt.Rows[0]["MainImage"].ToString();
                    objDesinsProDe.ProDuctImg1 = dt.Rows[0]["FirstImages"] == DBNull.Value ? "" : dt.Rows[0]["FirstImages"].ToString();
                    objDesinsProDe.ProDuctImg2 = dt.Rows[0]["SecondImages"] == DBNull.Value ? "" : dt.Rows[0]["SecondImages"].ToString();
                    objDesinsProDe.ProDuctImg3 = dt.Rows[0]["ThirdImages"] == DBNull.Value ? "" : dt.Rows[0]["ThirdImages"].ToString();
                    objDesinsProDe.ProDuctImg4 = dt.Rows[0]["FourthImages"] == DBNull.Value ? "" : dt.Rows[0]["FourthImages"].ToString();
                    objDesinsProDe.GarmentStyleNo = dt.Rows[0]["StyleNumber"] == DBNull.Value ? "" : dt.Rows[0]["StyleNumber"].ToString();
                    objDesinsProDe.GarmentDepartmentName = dt.Rows[0]["DepartmentName"] == DBNull.Value ? "" : dt.Rows[0]["DepartmentName"].ToString();
                    objDesinsProDe.DepartmentShortDes = dt.Rows[0]["MarketingShortDescription"] == DBNull.Value ? "" : dt.Rows[0]["MarketingShortDescription"].ToString();
                    objDesinsProDe.DepartmentlongDes = dt.Rows[0]["MarketingLongDescription"] == DBNull.Value ? "" : dt.Rows[0]["MarketingLongDescription"].ToString();
                    objDesinsProDe.DesigFabricName = dt.Rows[0]["FabricDescription"] == DBNull.Value ? "" : dt.Rows[0]["FabricDescription"].ToString();
                    objDesinsProDe.ProTitle = dt.Rows[0]["MarketingTitle"] == DBNull.Value ? "" : dt.Rows[0]["MarketingTitle"].ToString();
                    objDesinsProDe.MarkingTag = dt.Rows[0]["MarketingTagId"] == DBNull.Value ? "" : dt.Rows[0]["MarketingTagId"].ToString();
                    objDesinsProDe.MarkingCompositon = dt.Rows[0]["MarketingCompositionId"] == DBNull.Value ? "" : dt.Rows[0]["MarketingCompositionId"].ToString();
                    objDesinsProDe.MarkingCollect = dt.Rows[0]["MarketingCollectionId"] == DBNull.Value ? "" : dt.Rows[0]["MarketingCollectionId"].ToString();
                    objDesinsProDe.MarkingCount = dt.Rows[0]["LikeCount"] == DBNull.Value ? "" : dt.Rows[0]["LikeCount"].ToString();

                    //added by raghvinder on 05-03-2020 start
                    objDesinsProDe.MarketingPrice = dt.Rows[0]["MarketingPrice"] == DBNull.Value ? "" : dt.Rows[0]["MarketingPrice"].ToString();
                    //added by raghvinder on 05-03-2020 end
                    //ProductDeData.Add(objDesinsProDe);
                }

                return objDesinsProDe;

            }

        }
        //public List<Client_Department> GetLikeCount()
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        DataSet ds = new DataSet();
        //        List<Client_Department> objCount = new List<Client_Department>();

        //        cnx.Open();
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "Usp_Get_LikeCount";

        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //        adapter.Fill(ds);
        //        DataTable dt = ds.Tables[0];
        //        // DataTable dt1 = ds.Tables[1];

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Client_Department objCountLi = new Client_Department();

        //            objCountLi.ProLikeCount = dt.Rows[i]["LikeCount"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["LikeCount"]);
        //            objCount.Add(objCountLi);
        //        }
        //        return objCount;
        //    }
        //}

        public DataTable BindCurrencyDropDownList()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_Marketing_Currency";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //SqlParameter param;

                //param = new SqlParameter("@OrderDetailId", SqlDbType.VarChar);
                //param.Value = OrderDetailId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                adapter.Fill(dt);

                return dt;
            }
        }


        // added By ravishankar for storing daily cmt value
        public int InsertDailyActualCMTPercent(double CMTValue, DateTime HrlyDate)
        {
            int iSave = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string result = string.Empty;
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_SaveDailyCMT";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@CMT", SqlDbType.Decimal);
                    param.Value = CMTValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CmtDate", SqlDbType.DateTime);
                    param.Value = HrlyDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    iSave = cmd.ExecuteNonQuery();

                 }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  daily CMT Saving" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

            return iSave;
        }
    }

}
