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
    public class FabricWorkingDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public FabricWorkingDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insertion Methods

        public bool InsertFabricWorking(FabricWorking fabricWorking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_fabric_working_sheet_insert_fabric_working_sheet";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = fabricWorking.order.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //
                    param = new SqlParameter("@MOPercentadd1", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric1Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOPercentadd2", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric2Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOPercentadd3", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric3Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOPercentadd4", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric4Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //

                    param = new SqlParameter("@Fabric1Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1FinalOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2FinalOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3FinalOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric1Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric2Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric3Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric4Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRemarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.FabricRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalGreigeFabric", SqlDbType.Float);
                    param.Value = fabricWorking.TotalGreigeFabric;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AvgChecked", SqlDbType.Int);
                    param.Value = fabricWorking.AvgChecked;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccountManager", SqlDbType.Int);
                    param.Value = fabricWorking.ApprovedByAccountManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManager", SqlDbType.Int);
                    param.Value = fabricWorking.ApprovedByFabricManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccountManagerOn", SqlDbType.DateTime);
                    if ((fabricWorking.ApprovedByAccountManagerOn == DateTime.MinValue) || (fabricWorking.ApprovedByAccountManagerOn == Convert.ToDateTime("1753-01-01")) || (fabricWorking.ApprovedByAccountManagerOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.ApprovedByAccountManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManagerOn", SqlDbType.DateTime);
                    if ((fabricWorking.ApprovedByFabricManagerOn == DateTime.MinValue) || (fabricWorking.ApprovedByFabricManagerOn == Convert.ToDateTime("1753-01-01")) || (fabricWorking.ApprovedByFabricManagerOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.ApprovedByFabricManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AvgCheckedOn", SqlDbType.DateTime);
                    if ((fabricWorking.AvgCheckedOn == DateTime.MinValue) || (fabricWorking.AvgCheckedOn == Convert.ToDateTime("1753-01-01")) || (fabricWorking.AvgCheckedOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.AvgCheckedOn;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AllRemarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.AllRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage1", SqlDbType.VarChar);
                    param.Value = fabricWorking.UnitOfAverage1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage2", SqlDbType.VarChar);
                    param.Value = fabricWorking.UnitOfAverage2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage3", SqlDbType.VarChar);
                    param.Value = fabricWorking.UnitOfAverage3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage4", SqlDbType.VarChar);
                    param.Value = fabricWorking.UnitOfAverage4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Add By Ravi kumar on 11/12/2014
                    param = new SqlParameter("@Fabric1Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric1File == null ? "" : fabricWorking.Fabric1File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric2File == null ? "" : fabricWorking.Fabric2File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric3File == null ? "" : fabricWorking.Fabric3File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric4File == null ? "" : fabricWorking.Fabric4File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedAcknowledgementManager", SqlDbType.Int);
                    param.Value = fabricWorking.ApprovedAcknowledgementManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedAcknowledgementManagerOn", SqlDbType.DateTime);
                    if ((fabricWorking.ApprovedAcknowledgementManagerOn == DateTime.MinValue) || (fabricWorking.ApprovedAcknowledgementManagerOn == Convert.ToDateTime("1753-01-01")) || (fabricWorking.ApprovedAcknowledgementManagerOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.ApprovedAcknowledgementManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                    if ((fabricWorking.CreationDate == DateTime.MinValue) || (fabricWorking.CreationDate == Convert.ToDateTime("1753-01-01")) || (fabricWorking.CreationDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.CreationDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@History", SqlDbType.VarChar);
                    param.Value = fabricWorking.History;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    #region Fabric 07-04-2016


                    //param = new SqlParameter("@PrintColorRecdFabric1", SqlDbType.Int);
                    //param.Value = fabricWorking.PrintColorRecdFabric1;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@PrintColorRecdFabric2", SqlDbType.Int);
                    //param.Value = fabricWorking.PrintColorRecdFabric2;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@PrintColorRecdFabric3", SqlDbType.Int);
                    //param.Value = fabricWorking.PrintColorRecdFabric3;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@PrintColorRecdFabric4", SqlDbType.Int);
                    //param.Value = fabricWorking.PrintColorRecdFabric4;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@FabricQualtityAprdFabric1", SqlDbType.Int);
                    //if (fabricWorking.FabricQualtityAprdFabric1 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric1;
                    //}

                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FabricQualtityAprdFabric2", SqlDbType.Int);
                    //if (fabricWorking.FabricQualtityAprdFabric2 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric2;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@FabricQualtityAprdFabric3", SqlDbType.Int);

                    //if (fabricWorking.FabricQualtityAprdFabric3 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric3;
                    //}


                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);



                    //param = new SqlParameter("@FabricQualtityAprdFabric4", SqlDbType.Int);

                    //if (fabricWorking.FabricQualtityAprdFabric4 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric4;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@IntialApprovedFabric1", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric1 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric1;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@IntialApprovedFabric2", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric2 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric2;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@IntialApprovedFabric3", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric3 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric3;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@IntialApprovedFabric4", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric4 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric4;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@BulkApprovedFabric1", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric1 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric1;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@BulkApprovedFabric2", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric2 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric2;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@BulkApprovedFabric3", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric3 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric3;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@BulkApprovedFabric4", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric4 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric4;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    //param.Value = fabricWorking.OrderDetailID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    #endregion

                    cmd.ExecuteNonQuery();
                    int fabricWorkingID = Convert.ToInt32(outParam.Value);

                    foreach (OrderDetail orderDetail in fabricWorking.order.OrderBreakdown)
                    {
                        if (orderDetail.OrderID > 0)
                            UpdateOrderDetail(orderDetail, cnx, transaction);
                    }

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }

            return true;
        }

        #endregion

        #region Updation Methods

        // Update by Ravi kumar on 24/12/2014 for Ucknowledment update
        public bool UpdateFabricWorking(FabricWorking fabricWorking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_fabric_working_sheet_update_fabric_working_sheet";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Update);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = fabricWorking.order.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //
                    param = new SqlParameter("@MOPercentadd1", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric1Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOPercentadd2", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric2Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOPercentadd3", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric3Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOPercentadd4", SqlDbType.Float);
                    param.Value = fabricWorking.TotalFabric4Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //

                    param = new SqlParameter("@Fabric1Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Fabric1Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1FinalOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2FinalOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3FinalOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Wastage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Shrinkage", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Greige", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4Greige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4FinalOrder", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4FinalOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric1Remarks == null ? "" : fabricWorking.Fabric1Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric2Remarks == null ? "" : fabricWorking.Fabric2Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric3Remarks == null ? "" : fabricWorking.Fabric3Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Remarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric4Remarks == null ? "" : fabricWorking.Fabric4Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRemarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.FabricRemarks == null ? "" : fabricWorking.FabricRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalGreigeFabric", SqlDbType.Float);
                    param.Value = fabricWorking.TotalGreigeFabric;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AvgChecked", SqlDbType.Int);
                    param.Value = fabricWorking.AvgChecked;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccountManager", SqlDbType.Int);
                    param.Value = fabricWorking.ApprovedByAccountManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManager", SqlDbType.Int);
                    param.Value = fabricWorking.ApprovedByFabricManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccountManagerOn", SqlDbType.DateTime);
                    if (fabricWorking.ApprovedByAccountManagerOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.ApprovedByAccountManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManagerOn", SqlDbType.DateTime);
                    if (fabricWorking.ApprovedByFabricManagerOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.ApprovedByFabricManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AvgCheckedOn", SqlDbType.DateTime);
                    if (fabricWorking.AvgCheckedOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.AvgCheckedOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AllRemarks", SqlDbType.VarChar);
                    param.Value = fabricWorking.AllRemarks == null ? "" : fabricWorking.AllRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4InitialWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4InitialWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric1UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric1UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric2UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric3UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4UsableWidth", SqlDbType.Float);
                    param.Value = fabricWorking.Fabric4UsableWidth;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage1", SqlDbType.VarChar);
                    if (fabricWorking.UnitOfAverage1 == null)
                    {
                        param.Value = DBNull.Value;
                    }
                    {
                        param.Value = fabricWorking.UnitOfAverage1;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage2", SqlDbType.VarChar);
                    if (fabricWorking.UnitOfAverage2 == null)
                    {
                        param.Value = DBNull.Value;
                    }
                    {
                        param.Value = fabricWorking.UnitOfAverage2;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage3", SqlDbType.VarChar);
                    if (fabricWorking.UnitOfAverage3 == null)
                    {
                        param.Value = DBNull.Value;
                    }
                    {
                        param.Value = fabricWorking.UnitOfAverage3;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitOfAverage4", SqlDbType.VarChar);
                    if (fabricWorking.UnitOfAverage4 == null)
                    {
                        param.Value = DBNull.Value;
                    }
                    {
                        param.Value = fabricWorking.UnitOfAverage4;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                    param.Value = fabricWorking.CreationDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@History", SqlDbType.VarChar);
                    param.Value = fabricWorking.History == null ? "" : fabricWorking.History;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Add By Ravi kumar on 11/12/2014
                    param = new SqlParameter("@Fabric1Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric1File == null ? "" : fabricWorking.Fabric1File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric2Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric2File == null ? "" : fabricWorking.Fabric2File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric3Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric3File == null ? "" : fabricWorking.Fabric3File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric4Upload", SqlDbType.VarChar);
                    param.Value = fabricWorking.Fabric4File == null ? "" : fabricWorking.Fabric4File;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedAcknowledgementManager", SqlDbType.Int);
                    param.Value = fabricWorking.ApprovedAcknowledgementManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedAcknowledgementManagerOn", SqlDbType.DateTime);
                    if ((fabricWorking.ApprovedAcknowledgementManagerOn == DateTime.MinValue) || (fabricWorking.ApprovedAcknowledgementManagerOn == Convert.ToDateTime("1753-01-01")) || (fabricWorking.ApprovedAcknowledgementManagerOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = fabricWorking.ApprovedAcknowledgementManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@UnitOfAverage4", SqlDbType.VarChar);

                    #region Gajendra Commented 13-04-2016
                    //added by abhishek on 25/12/2015

                    //param = new SqlParameter("@PrintColorRecdFabric1", SqlDbType.Int);

                    ////param.Value = fabricWorking.PrintColorRecdFabric1;
                    //if (fabricWorking.PrintColorRecdFabric1 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.PrintColorRecdFabric1;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@PrintColorRecdFabric2", SqlDbType.Int);
                    ////param.Value = fabricWorking.PrintColorRecdFabric2;
                    //if (fabricWorking.PrintColorRecdFabric2 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.PrintColorRecdFabric2;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@PrintColorRecdFabric3", SqlDbType.Int);
                    ////param.Value = fabricWorking.PrintColorRecdFabric3;
                    //if (fabricWorking.PrintColorRecdFabric3 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.PrintColorRecdFabric3;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    //param = new SqlParameter("@PrintColorRecdFabric4", SqlDbType.Int);
                    ////param.Value = fabricWorking.PrintColorRecdFabric4;
                    //if (fabricWorking.PrintColorRecdFabric4 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.PrintColorRecdFabric4;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@FabricQualtityAprdFabric1", SqlDbType.Int);
                    //if (fabricWorking.FabricQualtityAprdFabric1 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric1;
                    //}

                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FabricQualtityAprdFabric2", SqlDbType.Int);
                    //if (fabricWorking.FabricQualtityAprdFabric2 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric2;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@FabricQualtityAprdFabric3", SqlDbType.Int);

                    //if (fabricWorking.FabricQualtityAprdFabric3 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric3;
                    //}


                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);



                    //param = new SqlParameter("@FabricQualtityAprdFabric4", SqlDbType.Int);

                    //if (fabricWorking.FabricQualtityAprdFabric4 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.FabricQualtityAprdFabric4;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@IntialApprovedFabric1", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric1 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric1;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@IntialApprovedFabric2", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric2 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric2;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@IntialApprovedFabric3", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric3 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric3;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@IntialApprovedFabric4", SqlDbType.Int);

                    //if (fabricWorking.IntialAprdFabric4 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.IntialAprdFabric4;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@BulkApprovedFabric1", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric1 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric1;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@BulkApprovedFabric2", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric2 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric2;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@BulkApprovedFabric3", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric3 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric3;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@BulkApprovedFabric4", SqlDbType.Int);

                    //if (fabricWorking.BulkAprdFabric4 == -1)
                    //{
                    //    param.Value = DBNull.Value;

                    //}
                    //else
                    //{
                    //    param.Value = fabricWorking.BulkAprdFabric4;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    //param.Value = fabricWorking.OrderDetailID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //end ny abhishek on 25/12/2015
                    #endregion

                    cmd.ExecuteNonQuery();

                    foreach (OrderDetail orderDetail in fabricWorking.order.OrderBreakdown)
                    {
                        if (orderDetail.OrderID > 0)
                            UpdateOrderDetail(orderDetail, cnx, transaction);
                    }

                    this.UpdateFabricBlukInHouse(fabricWorking.order.OrderID, cnx, transaction);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            return true;
        }
        // End by Ravi kumar on 24/12/2014 for Ucknowledment update


        public bool Update_FabricApproval_PopUp(FabricWorking fabricWorking, string Flag="", int UserID=-1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Update_FabricApproval_PopUp";
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@PrintColorRecdFabric", SqlDbType.Int);
                    if (fabricWorking.PrintColorRecdFabric == -1)                  
                        param.Value = DBNull.Value;
                    else               
                        param.Value = fabricWorking.PrintColorRecdFabric;
               
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                   


                    param = new SqlParameter("@FabricQualtityAprdFabric", SqlDbType.Int);
                    if (fabricWorking.FabricQualtityAprdFabric == -1)              
                        param.Value = DBNull.Value;
                    else                 
                        param.Value = fabricWorking.FabricQualtityAprdFabric;                 

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    


                    param = new SqlParameter("@IntialApprovedFabric", SqlDbType.Int);
                    if (fabricWorking.IntialAprdFabric == -1)               
                        param.Value = DBNull.Value;
                    else               
                        param.Value = fabricWorking.IntialAprdFabric;
                
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@BulkApprovedFabric", SqlDbType.Int);
                    if (fabricWorking.BulkAprdFabric == -1)                  
                        param.Value = DBNull.Value;
                    else               
                        param.Value = fabricWorking.BulkAprdFabric;
                  
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = fabricWorking.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.SmallInt);
                    param.Value = fabricWorking.Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricRemarks", SqlDbType.VarChar);
                    if (string.IsNullOrEmpty(fabricWorking.FabricRemarks))           
                        param.Value = DBNull.Value;
                    else            
                        param.Value = fabricWorking.FabricRemarks;
             
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = fabricWorking.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = fabricWorking.ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                    param.Value = fabricWorking.FabricName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Value = fabricWorking.FabricDetails;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //---------------------------------------abhishek

                    param = new SqlParameter("@FabQtyIntial", SqlDbType.DateTime);
                    if (string.IsNullOrEmpty(fabricWorking.FabQtyIntial))                
                        param.Value = DBNull.Value;
                    else 
                        param.Value = fabricWorking.FabQtyIntial;
                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                                      

                    //------------------2
                    param = new SqlParameter("@Intial", SqlDbType.DateTime);
                    if (string.IsNullOrEmpty(fabricWorking.Intial))                 
                        param.Value = DBNull.Value;
                    else                  
                        param.Value = fabricWorking.Intial;
               
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                                  
                  
                    //------------3

                    param = new SqlParameter("@BulkIntial", SqlDbType.DateTime);
                    if (string.IsNullOrEmpty(fabricWorking.BulkIntial))                  
                        param.Value = DBNull.Value;
                    else                
                        param.Value = fabricWorking.BulkIntial;
                  
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    
                    //------------4
                    param = new SqlParameter("@Fabprint", SqlDbType.DateTime);
                    if (string.IsNullOrEmpty(fabricWorking.PrintQly))                 
                        param.Value = DBNull.Value;
                    else                
                        param.Value = fabricWorking.PrintQly;
               
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@UserID", SqlDbType.Int);
                    //param.Value = UserID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@ApprovedByAccountManager", SqlDbType.Bit);
                    //param.Value = fabricWorking.ApprovedByAccountManager;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                   var ss=   cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    //transaction.Rollback();
                    throw ex;
                }
            }

            return true;
        }
        public bool UpdateFabricWorkingForSTM(FabricWorking fabricWorking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                cnx.Open();

                transaction = cnx.BeginTransaction();

                try
                {

                    foreach (OrderDetail orderDetail in fabricWorking.order.OrderBreakdown)
                    {
                        if (orderDetail.OrderID > 0)
                            UpdateOrderDetailForSTC(orderDetail, cnx, transaction);
                    }

                    //  this.UpdateFabricBlukInHouse(fabricWorking.order.OrderID, cnx, transaction);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            return true;
        }

        private bool UpdateOrderDetailForSTC(OrderDetail orderDetail, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_order_detail_update_order_detail_Cut_Average";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@OrderID", SqlDbType.Int);
            param.Value = orderDetail.OrderID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
            param.Value = orderDetail.OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Fabric1STCAverage", SqlDbType.Float);
            param.Value = orderDetail.Fabric1STCAverage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Fabric2STCAverage", SqlDbType.Float);
            param.Value = orderDetail.Fabric2STCAverage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Fabric3STCAverage", SqlDbType.Float);
            param.Value = orderDetail.Fabric3STCAverage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Fabric4STCAverage", SqlDbType.Float);
            param.Value = orderDetail.Fabric4STCAverage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        // Update By Ravi kumar on 4/12/2014

        private bool UpdateOrderDetail(OrderDetail orderDetail, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_order_detail_update_order_detail_fabrics";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@OrderID", SqlDbType.Int);
            param.Value = orderDetail.OrderID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
            param.Value = orderDetail.OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric1Average", SqlDbType.Float);
            param.Value = orderDetail.Fabric1Average;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric1Quantity", SqlDbType.Float);
            param.Value = orderDetail.Fabric1Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric2Average", SqlDbType.Float);
            param.Value = orderDetail.Fabric2Average;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric2Quantity", SqlDbType.Float);
            param.Value = orderDetail.Fabric2Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric3Average", SqlDbType.Float);
            param.Value = orderDetail.Fabric3Average;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric3Quantity", SqlDbType.Float);
            param.Value = orderDetail.Fabric3Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric4Average", SqlDbType.Float);
            param.Value = orderDetail.Fabric4Average;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric4Quantity", SqlDbType.Float);
            param.Value = orderDetail.Fabric4Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();

            return true;
        }


        // End By Ravi kumar on 4/12/2014

        public void UpdateFabricBlukInHouse(int OrderID, SqlConnection cnx, SqlTransaction transaction)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string cmdText = "sp_fabric_update_bulk_in_house";
            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Connection = cnx;
            SqlParameter paramIn;

            paramIn = new SqlParameter("@OrderID", SqlDbType.Int);
            paramIn.Value = OrderID;
            cmd.Parameters.Add(paramIn);

            cmd.ExecuteNonQuery();
        }

        #endregion

        #region Read Methods

        public FabricWorking GetFabricWorking_data(int orderID)
        {
            FabricWorking fabricWorking = new FabricWorking();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_fabric_working_get_fabric_working_by_orderid";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = orderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    DataSet dsFabricWorking = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsFabricWorking);
                    DataTable dt = dsFabricWorking.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row1 = dt.Rows[0];

                        fabricWorking.Id = Convert.ToInt32(row1["Id"]);
                        fabricWorking.order.OrderID = Convert.ToInt32(row1["OrderID"]);
                        fabricWorking.Fabric1Wastage = (row1["Fabric1Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Wastage"]);
                        fabricWorking.Fabric1Shrinkage = (row1["Fabric1Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Shrinkage"]);
                        fabricWorking.Fabric1Greige = (row1["Fabric1Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Greige"]);
                        fabricWorking.Fabric1FinalOrder = (row1["Fabric1FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1FinalOrder"]);
                        fabricWorking.Fabric2Wastage = (row1["Fabric2Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Wastage"]);
                        fabricWorking.Fabric2Shrinkage = (row1["Fabric2Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Shrinkage"]);
                        fabricWorking.Fabric2Greige = (row1["Fabric2Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Greige"]);
                        fabricWorking.Fabric2FinalOrder = (row1["Fabric2FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2FinalOrder"]);
                        fabricWorking.Fabric3Wastage = (row1["Fabric3Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Wastage"]);
                        fabricWorking.Fabric3Shrinkage = (row1["Fabric3Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Shrinkage"]);
                        fabricWorking.Fabric3Greige = (row1["Fabric3Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Greige"]);
                        fabricWorking.Fabric3FinalOrder = (row1["Fabric3FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3FinalOrder"]);
                        fabricWorking.Fabric4Wastage = (row1["Fabric4Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Wastage"]);
                        fabricWorking.Fabric4Shrinkage = (row1["Fabric4Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Shrinkage"]);
                        fabricWorking.Fabric4Greige = (row1["Fabric4Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Greige"]);
                        fabricWorking.Fabric4FinalOrder = (row1["Fabric4FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4FinalOrder"]);
                        fabricWorking.Fabric1Remarks = (row1["Fabric1Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric1Remarks"]);
                        fabricWorking.Fabric2Remarks = (row1["Fabric2Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric2Remarks"]);
                        fabricWorking.Fabric3Remarks = (row1["Fabric3Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric3Remarks"]);
                        fabricWorking.Fabric4Remarks = (row1["Fabric4Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric4Remarks"]);
                        fabricWorking.AllRemarks = (row1["AllRemarks"] == null) ? string.Empty : Convert.ToString(row1["AllRemarks"]);
                        fabricWorking.TotalGreigeFabric = (row1["TotalGreigeFabric"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["TotalGreigeFabric"]);
                        fabricWorking.AvgChecked = (row1["AvgChecked"] == null) ? 0 : Convert.ToInt32(row1["AvgChecked"]);
                        fabricWorking.ApprovedByAccountManager = (row1["ApprovedByAccountManager"] == null) ? 0 : Convert.ToInt32(row1["ApprovedByAccountManager"]);
                        fabricWorking.ApprovedByFabricManager = (row1["ApprovedByFabricManager"] == null) ? 0 : Convert.ToInt32(row1["ApprovedByFabricManager"]);
                        fabricWorking.FabricRemarks = (row1["FabricRemarks"] == null) ? string.Empty : Convert.ToString(row1["FabricRemarks"]);
                        fabricWorking.Fabric1InitialWidth = (row1["Fabric1InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1InitialWidth"]);
                        fabricWorking.Fabric2InitialWidth = (row1["Fabric2InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2InitialWidth"]);
                        fabricWorking.Fabric3InitialWidth = (row1["Fabric3InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3InitialWidth"]);
                        fabricWorking.Fabric4InitialWidth = (row1["Fabric4InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4InitialWidth"]);
                        fabricWorking.Fabric1UsableWidth = (row1["Fabric1UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1UsableWidth"]);
                        fabricWorking.Fabric2UsableWidth = (row1["Fabric2UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2UsableWidth"]);
                        fabricWorking.Fabric3UsableWidth = (row1["Fabric3UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3UsableWidth"]);
                        fabricWorking.Fabric4UsableWidth = (row1["Fabric4UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4UsableWidth"]);
                        fabricWorking.UnitOfAverage1 = (row1["UnitOfAverage1"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage1"]);
                        fabricWorking.UnitOfAverage2 = (row1["UnitOfAverage2"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage2"]);
                        fabricWorking.UnitOfAverage3 = (row1["UnitOfAverage3"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage3"]);
                        fabricWorking.UnitOfAverage4 = (row1["UnitOfAverage4"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage4"]);
                        fabricWorking.CreationDate = (row1["CreationDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["CreationDate"]);
                        fabricWorking.History = (row1["History"] == null) ? string.Empty : Convert.ToString(row1["History"]);
                    }

                    //fabricWorking = ConvertDataSetToFabricWorking(dsFabricWorking);

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return fabricWorking;
        }

        //public FabricWorking GetFabricWorking(int orderID,string OrderDetailID)
        //{
        //    FabricWorking fabricWorking = new FabricWorking();

        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        try
        //        {
        //            string cmdText = "sp_fabric_working_get_all_fabric_working";

        //            SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //            SqlParameter param;
        //            param = new SqlParameter("@OrderID", SqlDbType.Int);
        //            param.Value = orderID;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
        //            param.Value = OrderDetailID;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            DataSet dsFabricWorking = new DataSet();
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            adapter.Fill(dsFabricWorking);

        //            fabricWorking = ConvertDataSetToFabricWorking(dsFabricWorking);

        //        }
        //        catch (SqlException ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    return fabricWorking;
        //}
        public FabricWorking Get_FabricApprovalDetails(string OrderDetailID,string Type)
        {
            FabricWorking fabricWorking = new FabricWorking();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Get_FabricApprovalDetails";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsFabricApprovalDetails = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsFabricApprovalDetails);

                    DataTable dt = dsFabricApprovalDetails.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row1 = dt.Rows[0];
                        fabricWorking.PrintColorRecdFabric = (row1["PrintColorRecdFabric"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PrintColorRecdFabric"]);
                        fabricWorking.FabricQualtityAprdFabric = (row1["FabricQualtityAprdFabric"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["FabricQualtityAprdFabric"]);
                        fabricWorking.PrintColorRecdOnFabric = (row1["PrintColorRecdOnFabric"] == DBNull.Value) ? "" : (row1["PrintColorRecdOnFabric"].ToString());
                        fabricWorking.FabricQualtityAprdOnFabric = (row1["FabricQualtityAprdOnFabric"] == DBNull.Value) ? "" : (row1["FabricQualtityAprdOnFabric"].ToString());
                        fabricWorking.IntialAprdOnFabric = (row1["IntialAprdOnFabric"] == DBNull.Value) ? "" : (row1["IntialAprdOnFabric"].ToString());
                        fabricWorking.IntialAprdFabric = (row1["IntialAprdFabric"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["IntialAprdFabric"]);
                        fabricWorking.BulkAprdOnFabric = (row1["BulkAprdOnFabric"] == DBNull.Value) ? "" : (row1["BulkAprdOnFabric"].ToString());
                        fabricWorking.BulkAprdFabric = (row1["BulkAprdFabric"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["BulkAprdFabric"]);
                        fabricWorking.Fabric_ApprovalRemarks = (row1["Fabric_ApprovalRemarks"].ToString());
                        fabricWorking.ApprovedByAccountManager = (Convert.ToInt32(row1["ApprovedByAccountManager"].ToString()));
                        fabricWorking.Fabric = (row1["Fabric"] == DBNull.Value) ? "" : (row1["Fabric"].ToString());
                        fabricWorking.FabricChanged = (row1["FabricChanged"] == DBNull.Value) ? "" : (row1["FabricChanged"].ToString());
                        fabricWorking.FabricDetailChanged = (row1["FabricDetailChanged"] == DBNull.Value) ? "" : (row1["FabricDetailChanged"].ToString());
                 
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                return fabricWorking;
            }
        }
        public bool bCheck_Fabric_Approvel_Task(int OrderDetailID,string Flag )
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "sp_Check_Fabric_Approvel_Task";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExfactoryPermission = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckExfactoryPermission);
                    int a = Convert.ToInt32(dsCheckExfactoryPermission.Tables[0].Rows[0]["ApprovelTask"]);
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
        ////private FabricWorking ConvertDataSetToFabricWorking(DataSet dsFabricWorking)
        ////{
        ////    FabricWorking fabricWorking = new FabricWorking();

        ////    fabricWorking.order = new Order();

        ////    DataTable dt = dsFabricWorking.Tables[0];

        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        DataRow row1 = dt.Rows[0];

        ////        fabricWorking.Id = Convert.ToInt32(row1["Id"]);
        ////        fabricWorking.order.OrderID = Convert.ToInt32(row1["OrderID"]);
        ////        fabricWorking.Fabric1Wastage = (row1["Fabric1Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Wastage"]);
        ////        fabricWorking.Fabric1Shrinkage = (row1["Fabric1Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Shrinkage"]);
        ////        fabricWorking.Fabric1Greige = (row1["Fabric1Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1Greige"]);
        ////        fabricWorking.Fabric1FinalOrder = (row1["Fabric1FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1FinalOrder"]);
        ////        fabricWorking.Fabric2Wastage = (row1["Fabric2Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Wastage"]);
        ////        fabricWorking.Fabric2Shrinkage = (row1["Fabric2Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Shrinkage"]);
        ////        fabricWorking.Fabric2Greige = (row1["Fabric2Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2Greige"]);
        ////        fabricWorking.Fabric2FinalOrder = (row1["Fabric2FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2FinalOrder"]);
        ////        fabricWorking.Fabric3Wastage = (row1["Fabric3Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Wastage"]);
        ////        fabricWorking.Fabric3Shrinkage = (row1["Fabric3Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Shrinkage"]);
        ////        fabricWorking.Fabric3Greige = (row1["Fabric3Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3Greige"]);
        ////        fabricWorking.Fabric3FinalOrder = (row1["Fabric3FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3FinalOrder"]);
        ////        fabricWorking.Fabric4Wastage = (row1["Fabric4Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Wastage"]);
        ////        fabricWorking.Fabric4Shrinkage = (row1["Fabric4Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Shrinkage"]);
        ////        fabricWorking.Fabric4Greige = (row1["Fabric4Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4Greige"]);
        ////        fabricWorking.Fabric4FinalOrder = (row1["Fabric4FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4FinalOrder"]);
        ////        fabricWorking.Fabric1Remarks = (row1["Fabric1Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric1Remarks"]);
        ////        fabricWorking.Fabric2Remarks = (row1["Fabric2Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric2Remarks"]);
        ////        fabricWorking.Fabric3Remarks = (row1["Fabric3Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric3Remarks"]);
        ////        fabricWorking.Fabric4Remarks = (row1["Fabric4Remarks"] == null) ? string.Empty : Convert.ToString(row1["Fabric4Remarks"]);
        ////        fabricWorking.AllRemarks = (row1["AllRemarks"] == null) ? string.Empty : Convert.ToString(row1["AllRemarks"]);
        ////        fabricWorking.TotalGreigeFabric = (row1["TotalGreigeFabric"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["TotalGreigeFabric"]);
        ////        fabricWorking.AvgChecked = (row1["AvgChecked"] == null) ? 0 : Convert.ToInt32(row1["AvgChecked"]);
        ////        fabricWorking.ApprovedByAccountManager = (row1["ApprovedByAccountManager"] == null) ? 0 : Convert.ToInt32(row1["ApprovedByAccountManager"]);
        ////        fabricWorking.ApprovedByFabricManager = (row1["ApprovedByFabricManager"] == null) ? 0 : Convert.ToInt32(row1["ApprovedByFabricManager"]);
        ////        fabricWorking.ApprovedByAccountManagerOn = (row1["ApprovedByAccountManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["ApprovedByAccountManagerOn"]);
        ////        fabricWorking.ApprovedByFabricManagerOn = (row1["ApprovedByFabricManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["ApprovedByFabricManagerOn"]);
        ////        fabricWorking.AvgCheckedOn = (row1["AvgCheckedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["AvgCheckedOn"]);
        ////        fabricWorking.FabricRemarks = (row1["FabricRemarks"] == null) ? string.Empty : Convert.ToString(row1["FabricRemarks"]);
        ////        fabricWorking.Fabric1InitialWidth = (row1["Fabric1InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1InitialWidth"]);
        ////        fabricWorking.Fabric2InitialWidth = (row1["Fabric2InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2InitialWidth"]);
        ////        fabricWorking.Fabric3InitialWidth = (row1["Fabric3InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3InitialWidth"]);
        ////        fabricWorking.Fabric4InitialWidth = (row1["Fabric4InitialWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4InitialWidth"]);
        ////        fabricWorking.Fabric1UsableWidth = (row1["Fabric1UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric1UsableWidth"]);
        ////        fabricWorking.Fabric2UsableWidth = (row1["Fabric2UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric2UsableWidth"]);
        ////        fabricWorking.Fabric3UsableWidth = (row1["Fabric3UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric3UsableWidth"]);
        ////        fabricWorking.Fabric4UsableWidth = (row1["Fabric4UsableWidth"] == DBNull.Value) ? 0 : Convert.ToDouble(row1["Fabric4UsableWidth"]);
        ////        fabricWorking.UnitOfAverage1 = (row1["UnitOfAverage1"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage1"]);
        ////        fabricWorking.UnitOfAverage2 = (row1["UnitOfAverage2"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage2"]);
        ////        fabricWorking.UnitOfAverage3 = (row1["UnitOfAverage3"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage3"]);
        ////        fabricWorking.UnitOfAverage4 = (row1["UnitOfAverage4"] == DBNull.Value) ? "-1" : Convert.ToString(row1["UnitOfAverage4"]);

        ////        fabricWorking.Fabric1File = (row1["Fabric1POUpload"] == DBNull.Value) ? "" : Convert.ToString(row1["Fabric1POUpload"]);
        ////        fabricWorking.Fabric2File = (row1["Fabric2POUpload"] == DBNull.Value) ? "" : Convert.ToString(row1["Fabric2POUpload"]);
        ////        fabricWorking.Fabric3File = (row1["Fabric3POUpload"] == DBNull.Value) ? "" : Convert.ToString(row1["Fabric3POUpload"]);
        ////        fabricWorking.Fabric4File = (row1["Fabric4POUpload"] == DBNull.Value) ? "" : Convert.ToString(row1["Fabric4POUpload"]);
        ////        // End By Ravi kumar on 12/12/2014
        ////        // Add By Ravi kumar on 24/12/2014
        ////        fabricWorking.ApprovedAcknowledgementManager = (row1["ApprovedAcknowledgementManager"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["ApprovedAcknowledgementManager"]);
        ////        // end By Ravi kumar on 24/12/2014
        ////        fabricWorking.CreationDate = (row1["CreationDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["CreationDate"]);
        ////        fabricWorking.History = (row1["History"] == null) ? string.Empty : Convert.ToString(row1["History"]);
        ////    }

        ////    #region Gajendra Fabric 08-04-2016
        ////    dt = dsFabricWorking.Tables[2];
        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        DataRow row1 = dt.Rows[0];
        ////        fabricWorking.PrintColorRecdFabric1 = (row1["PrintColorRecdFabric1"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PrintColorRecdFabric1"]);
        ////        fabricWorking.PrintColorRecdFabric2 = (row1["PrintColorRecdFabric2"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PrintColorRecdFabric2"]);
        ////        fabricWorking.PrintColorRecdFabric3 = (row1["PrintColorRecdFabric3"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PrintColorRecdFabric3"]);
        ////        fabricWorking.PrintColorRecdFabric4 = (row1["PrintColorRecdFabric4"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PrintColorRecdFabric4"]);


        ////        fabricWorking.FabricQualtityAprdFabric1 = (row1["FabricQualtityAprdFabric1"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["FabricQualtityAprdFabric1"]);
        ////        fabricWorking.FabricQualtityAprdFabric2 = (row1["FabricQualtityAprdFabric2"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["FabricQualtityAprdFabric2"]);
        ////        fabricWorking.FabricQualtityAprdFabric3 = (row1["FabricQualtityAprdFabric3"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["FabricQualtityAprdFabric3"]);
        ////        fabricWorking.FabricQualtityAprdFabric4 = (row1["FabricQualtityAprdFabric4"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["FabricQualtityAprdFabric4"]);



        ////        fabricWorking.PrintColorRecdOnFabric1 = (row1["PrintColorRecdOnFabric1"] == DBNull.Value) ? "" : (row1["PrintColorRecdOnFabric1"].ToString());
        ////        fabricWorking.PrintColorRecdOnFabric2 = (row1["PrintColorRecdOnFabric2"] == DBNull.Value) ? "" : (row1["PrintColorRecdOnFabric2"].ToString());
        ////        fabricWorking.PrintColorRecdOnFabric3 = (row1["PrintColorRecdOnFabric3"] == DBNull.Value) ? "" : (row1["PrintColorRecdOnFabric3"].ToString());
        ////        fabricWorking.PrintColorRecdOnFabric4 = (row1["PrintColorRecdOnFabric4"] == DBNull.Value) ? "" : (row1["PrintColorRecdOnFabric4"].ToString());

        ////        fabricWorking.FabricQualtityAprdOnFabric1 = (row1["FabricQualtityAprdOnFabric1"] == DBNull.Value) ? "" : (row1["FabricQualtityAprdOnFabric1"].ToString());
        ////        fabricWorking.FabricQualtityAprdOnFabric2 = (row1["FabricQualtityAprdOnFabric2"] == DBNull.Value) ? "" : (row1["FabricQualtityAprdOnFabric2"].ToString());
        ////        fabricWorking.FabricQualtityAprdOnFabric3 = (row1["FabricQualtityAprdOnFabric3"] == DBNull.Value) ? "" : (row1["FabricQualtityAprdOnFabric3"].ToString());
        ////        fabricWorking.FabricQualtityAprdOnFabric4 = (row1["FabricQualtityAprdOnFabric4"] == DBNull.Value) ? "" : (row1["FabricQualtityAprdOnFabric4"].ToString());

        ////        fabricWorking.IntialAprdOnFabric1 = (row1["IntialAprdOnFabric1"] == DBNull.Value) ? "" : (row1["IntialAprdOnFabric1"].ToString());
        ////        fabricWorking.IntialAprdOnFabric2 = (row1["IntialAprdOnFabric2"] == DBNull.Value) ? "" : (row1["IntialAprdOnFabric2"].ToString());
        ////        fabricWorking.IntialAprdOnFabric3 = (row1["IntialAprdOnFabric3"] == DBNull.Value) ? "" : (row1["IntialAprdOnFabric3"].ToString());
        ////        fabricWorking.IntialAprdOnFabric4 = (row1["IntialAprdOnFabric4"] == DBNull.Value) ? "" : (row1["IntialAprdOnFabric4"].ToString());

        ////        fabricWorking.IntialAprdFabric1 = (row1["IntialAprdFabric1"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["IntialAprdFabric1"]);
        ////        fabricWorking.IntialAprdFabric2 = (row1["IntialAprdFabric2"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["IntialAprdFabric2"]);
        ////        fabricWorking.IntialAprdFabric3 = (row1["IntialAprdFabric3"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["IntialAprdFabric3"]);
        ////        fabricWorking.IntialAprdFabric4 = (row1["IntialAprdFabric4"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["IntialAprdFabric4"]);



        ////        fabricWorking.BulkAprdOnFabric1 = (row1["BulkAprdOnFabric1"] == DBNull.Value) ? "" : (row1["BulkAprdOnFabric1"].ToString());
        ////        fabricWorking.BulkAprdOnFabric2 = (row1["BulkAprdOnFabric2"] == DBNull.Value) ? "" : (row1["BulkAprdOnFabric2"].ToString());
        ////        fabricWorking.BulkAprdOnFabric3 = (row1["BulkAprdOnFabric3"] == DBNull.Value) ? "" : (row1["BulkAprdOnFabric3"].ToString());
        ////        fabricWorking.BulkAprdOnFabric4 = (row1["BulkAprdOnFabric4"] == DBNull.Value) ? "" : (row1["BulkAprdOnFabric4"].ToString());

        ////        fabricWorking.BulkAprdFabric1 = (row1["BulkAprdFabric1"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["BulkAprdFabric1"]);
        ////        fabricWorking.BulkAprdFabric2 = (row1["BulkAprdFabric2"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["BulkAprdFabric2"]);
        ////        fabricWorking.BulkAprdFabric3 = (row1["BulkAprdFabric3"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["BulkAprdFabric3"]);
        ////        fabricWorking.BulkAprdFabric4 = (row1["BulkAprdFabric4"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["BulkAprdFabric4"]);

        ////    }
        ////    #endregion

        ////    dt = dsFabricWorking.Tables[1];
        ////    fabricWorking.order.OrderBreakdown = new List<OrderDetail>();
        ////    int result;
        ////    bool success = false;

        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        foreach (DataRow dr in dt.Rows)
        ////        {
        ////            OrderDetail orderDetail = new OrderDetail();
        ////            orderDetail.LineItemNumber = (dr["LineItemNumber"] == null) ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
        ////            orderDetail.ContractNumber = (dr["ContractNumber"] == null) ? string.Empty : Convert.ToString(dr["ContractNumber"]);
        ////            orderDetail.Fabric1 = (dr["Fabric1"] == null) ? string.Empty : Convert.ToString(dr["Fabric1"]);
        ////            orderDetail.Fabric1Details = (dr["Fabric1DetailsRef"] == null) ? string.Empty : Convert.ToString(dr["Fabric1DetailsRef"]);
        ////            orderDetail.Fabric2 = (dr["Fabric2"] == null) ? string.Empty : Convert.ToString(dr["Fabric2"]);
        ////            orderDetail.Fabric2Details = (dr["Fabric2DetailsRef"] == null) ? string.Empty : Convert.ToString(dr["Fabric2DetailsRef"]);
        ////            orderDetail.Fabric3 = (dr["Fabric3"] == null) ? string.Empty : Convert.ToString(dr["Fabric3"]);
        ////            orderDetail.Fabric3Details = (dr["Fabric3DetailsRef"] == null) ? string.Empty : Convert.ToString(dr["Fabric3DetailsRef"]);
        ////            orderDetail.Fabric4 = (dr["Fabric4"] == null) ? string.Empty : Convert.ToString(dr["Fabric4"]);
        ////            orderDetail.Fabric4Details = (dr["Fabric4DetailsRef"] == null) ? string.Empty : Convert.ToString(dr["Fabric4DetailsRef"]);
        ////            orderDetail.CCGSM1 = (dr["Fabric11"] == null) ? string.Empty : Convert.ToString(dr["Fabric11"]);
        ////            orderDetail.CCGSM2 = (dr["Fabric21"] == null) ? string.Empty : Convert.ToString(dr["Fabric21"]);
        ////            orderDetail.CCGSM3 = (dr["Fabric31"] == null) ? string.Empty : Convert.ToString(dr["Fabric31"]);
        ////            orderDetail.CCGSM4 = (dr["Fabric41"] == null) ? string.Empty : Convert.ToString(dr["Fabric41"]);
        ////            var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

        ////            if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
        ////            {
        ////                orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
        ////                success = false;
        ////                result = 0;

        ////            }

        ////            var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

        ////            if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
        ////            {
        ////                orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
        ////                success = false;
        ////                result = 0;
        ////            }



        ////            var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

        ////            if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
        ////            {
        ////                orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
        ////                success = false;
        ////                result = 0;
        ////            }


        ////            var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

        ////            if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
        ////            {
        ////                orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
        ////                success = false;
        ////                result = 0;
        ////            }

        ////            orderDetail.Quantity = (dr["Quantity"] == null) ? 0 : Convert.ToInt32(dr["Quantity"]);
        ////            orderDetail.Fabric1Average = (dr["Fabric1Average"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric1Average"]);

        ////            orderDetail.Fabric1STCAverage = (dr["Fabric1STCAverage"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric1STCAverage"]);
        ////            orderDetail.Fabric2STCAverage = (dr["Fabric2STCAverage"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric2STCAverage"]);
        ////            orderDetail.Fabric3STCAverage = (dr["Fabric3STCAverage"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric3STCAverage"]);
        ////            orderDetail.Fabric4STCAverage = (dr["Fabric4STCAverage"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric4STCAverage"]);

        ////            orderDetail.Fabric1Quantity = (dr["Fabric1Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric1Quantity"]);
        ////            orderDetail.Fabric2Average = (dr["Fabric2Average"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric2Average"]);
        ////            orderDetail.Fabric2Quantity = (dr["Fabric2Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric2Quantity"]);
        ////            orderDetail.Fabric3Average = (dr["Fabric3Average"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric3Average"]);
        ////            orderDetail.Fabric3Quantity = (dr["Fabric3Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric3Quantity"]);
        ////            orderDetail.Fabric4Average = (dr["Fabric4Average"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric4Average"]);
        ////            orderDetail.Fabric4Quantity = (dr["Fabric4Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Fabric4Quantity"]);
        ////            orderDetail.OrderDetailID = (dr["Id"] == null) ? 0 : Convert.ToInt32(dr["Id"]);
        ////            orderDetail.Remarks = (dr["FabricRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FabricRemarks"]);
        ////            // Add By Ravi kumar on 11/12/2014

        ////            orderDetail.IsCutAvg1 = (dr["IsCutAverage1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsCutAverage1"]);
        ////            orderDetail.IsCutAvg2 = (dr["IsCutAverage2"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsCutAverage2"]);
        ////            orderDetail.IsCutAvg3 = (dr["IsCutAverage3"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsCutAverage3"]);
        ////            orderDetail.IsCutAvg4 = (dr["IsCutAverage4"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsCutAverage4"]);
        ////            // Edit by surendra 08-jan 2015
        ////            orderDetail.Fabric1AvgHistory = (dr["Fabric1Average"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Average"]);
        ////            orderDetail.Fabric2AvgHistory = (dr["Fabric2Average"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric2Average"]);
        ////            orderDetail.Fabric3AvgHistory = (dr["Fabric3Average"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric3Average"]);
        ////            orderDetail.Fabric4AvgHistory = (dr["Fabric4Average"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric4Average"]);
        ////            // end
        ////            orderDetail.IsAckAvg1 = (dr["IsAckAvg1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsAckAvg1"]);
        ////            orderDetail.IsAckAvg2 = (dr["IsAckAvg2"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsAckAvg2"]);
        ////            orderDetail.IsAckAvg3 = (dr["IsAckAvg3"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsAckAvg3"]);
        ////            orderDetail.IsAckAvg4 = (dr["IsAckAvg4"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["IsAckAvg4"]);
        ////            fabricWorking.order.OrderBreakdown.Add(orderDetail);

        ////        }
        ////    }
        ////    return fabricWorking;
        ////}

        public List<OrderDetail> GetFabricWorkingByCurrentDate()
        {
            List<OrderDetail> ordColl = new List<OrderDetail>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fabric_working_get_fabric_workings_by_currentDate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //SqlParameter param = new SqlParameter("@CurrentDate", SqlDbType.DateTime);
                //param.Value = CurrentDate;
                //cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail ord = new OrderDetail();
                        ord.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        ord.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        ord.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                        ord.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                        ord.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                        ord.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                        ord.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                        ord.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                        ord.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);
                        ord.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
                        ord.ExFactory = (reader["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ExFactory"]);

                        ord.ParentOrder = new Order();
                        ord.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        ord.ParentOrder.OrderDate = (reader["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["OrderDate"]);
                        ord.ParentOrder.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        ord.ParentOrder.Style = new Style();
                        ord.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        ord.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        ord.ParentOrder.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);

                        ord.ParentOrder.FabricWorking = new FabricWorking();




                        string History = Convert.ToString(reader["History"]);
                        if (History.ToString().IndexOf("$$") > -1)
                        {
                            History = History.ToString().Replace("$$", "<br/>");
                        }
                        ord.ParentOrder.FabricWorking.History = History;
                        ord.ParentOrder.FabricWorking.Fabric1Greige = (reader["Fabric1Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric1Greige"]);
                        ord.ParentOrder.FabricWorking.Fabric1FinalOrder = (reader["Fabric1FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric1FinalOrder"]);
                        ord.ParentOrder.FabricWorking.Fabric2Greige = (reader["Fabric2Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric2Greige"]);
                        ord.ParentOrder.FabricWorking.Fabric2FinalOrder = (reader["Fabric2FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric2FinalOrder"]);
                        ord.ParentOrder.FabricWorking.Fabric3Greige = (reader["Fabric3Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric3Greige"]);
                        ord.ParentOrder.FabricWorking.Fabric3FinalOrder = (reader["Fabric3FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric3FinalOrder"]);
                        ord.ParentOrder.FabricWorking.Fabric4Greige = (reader["Fabric4Greige"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric4Greige"]);
                        ord.ParentOrder.FabricWorking.Fabric4FinalOrder = (reader["Fabric4FinalOrder"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Fabric4FinalOrder"]);

                        ord.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                        ord.ParentOrder.WorkflowInstanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);

                        decimal diff1 = 0;
                        decimal diff2 = 0;
                        decimal diff3 = 0;
                        decimal diff4 = 0;

                        if (ord.ParentOrder.FabricWorking.Fabric1FinalOrder > 0 && ord.ParentOrder.FabricWorking.Fabric1Greige > 0)
                            diff1 = ((Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric1FinalOrder) - Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric1Greige)) / Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric1Greige)) * 100;
                        if (ord.ParentOrder.FabricWorking.Fabric2FinalOrder > 0 && ord.ParentOrder.FabricWorking.Fabric2Greige > 0)
                            diff2 = ((Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric2FinalOrder) - Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric2Greige)) / Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric2Greige)) * 100;
                        if (ord.ParentOrder.FabricWorking.Fabric3FinalOrder > 0 && ord.ParentOrder.FabricWorking.Fabric3Greige > 0)
                            diff3 = ((Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric3FinalOrder) - Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric3Greige)) / Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric3Greige)) * 100;
                        if (ord.ParentOrder.FabricWorking.Fabric4FinalOrder > 0 && ord.ParentOrder.FabricWorking.Fabric4Greige > 0)
                            diff4 = ((Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric4FinalOrder) - Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric4Greige)) / Convert.ToDecimal(ord.ParentOrder.FabricWorking.Fabric4Greige)) * 100;

                        if (!String.IsNullOrEmpty(ord.ParentOrder.FabricWorking.History))
                        {
                            if ((ord.ParentOrder.FabricWorking.History.IndexOf(DateTime.Today.ToString("dd MMM yy (ddd)")) > -1) || diff1 > 10 || diff1 < -10 || diff2 > 10 || diff2 < -10 || diff3 > 10 || diff3 < -10 || diff4 > 10 || diff4 < -10)
                                ordColl.Add(ord);
                        }
                        else
                        {
                            if (diff1 > 10 || diff1 < -10 || diff2 > 10 || diff2 < -10 || diff3 > 10 || diff3 < -10 || diff4 > 10 || diff4 < -10)
                                ordColl.Add(ord);
                        }
                    }
                }
            }
            return ordColl;
        }

        // Add By Ravi kumar On 11/12/2014
        public string[] GetCostingAvg(int OrderId, int SeqNo)
        {
            OrderDetail ord = new OrderDetail();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                // SqlTransaction transaction = null;

                try
                {
                    string cmdText = "SP_GET_COSTINGAVG";
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    SqlParameter param;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SeqNo", SqlDbType.Int);
                    param.Value = SeqNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@CostAvg", SqlDbType.Float);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();
                    ord.CostAvg = outParam.Value.ToString();

                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }

            }
            string[] returnString = new string[] { ord.CostAvg.ToString() };
            return returnString;
        }

        #endregion
    }
}


