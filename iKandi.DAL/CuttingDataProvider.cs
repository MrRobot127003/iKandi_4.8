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
    public class CuttingDataProvider : BaseDataProvider
    {

        #region Ctor(s)

        public CuttingDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insertion Methods

        public bool InsertCutting(Cutting cutting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_cutting_sheet_insert_cutting_sheet";
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
                    param.Value = cutting.order.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchant", SqlDbType.Int);
                    param.Value = cutting.ApprovedByMerchant;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricHead", SqlDbType.Int);
                    param.Value = cutting.ApprovedByFabricHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByProductionHead", SqlDbType.Int);
                    param.Value = cutting.ApprovedByProductionHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchantOn", SqlDbType.DateTime);
                    if ((cutting.ApprovedByMerchantOn == DateTime.MinValue) || (cutting.ApprovedByMerchantOn == Convert.ToDateTime("1753-01-01")) || (cutting.ApprovedByMerchantOn == Convert.ToDateTime("1900-01-01")))
                    //if (cutting.ApprovedByMerchantOn==DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                    param.Value = cutting.ApprovedByMerchantOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricHeadOn", SqlDbType.DateTime);
                    if ((cutting.ApprovedByFabricHeadOn == DateTime.MinValue) || (cutting.ApprovedByFabricHeadOn == Convert.ToDateTime("1753-01-01")) || (cutting.ApprovedByFabricHeadOn == Convert.ToDateTime("1900-01-01")))
                   // if (cutting.ApprovedByFabricHeadOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                    param.Value = cutting.ApprovedByFabricHeadOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByProductionHeadOn", SqlDbType.DateTime);
                    if ((cutting.ApprovedByProductionHeadOn == DateTime.MinValue) || (cutting.ApprovedByProductionHeadOn == Convert.ToDateTime("1753-01-01")) || (cutting.ApprovedByProductionHeadOn == Convert.ToDateTime("1900-01-01")))
                   // if (cutting.ApprovedByProductionHeadOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                    param.Value = cutting.ApprovedByProductionHeadOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();

                    int cuttingID = Convert.ToInt32(outParam.Value);

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return false;
        }

        #endregion

        #region Read Methods

        public Cutting GetCuttingByOrderID(int orderID)
        {
            Cutting cutting = new Cutting();
            cutting.order = new Order();
            cutting.order.Style = new Style();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_cutting_sheet_get_cutting_sheet_by_order_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = orderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        cutting.order.OrderID = Convert.ToInt32(reader["OrderID"]);
                        cutting.order.Style.InLineCutDate = (reader["InlineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["InlineCutDate"]);
                        cutting.Id = Convert.ToInt32(reader["Id"]);
                        cutting.ApprovedByMerchant = Convert.ToInt32(reader["ApprovedByMerchant"]);
                        cutting.ApprovedByFabricHead = Convert.ToInt32(reader["ApprovedByFabricHead"]);
                        cutting.ApprovedByProductionHead = Convert.ToInt32(reader["ApprovedByProductionHead"]);
                        cutting.ApprovedByFabricHeadOn = (reader["ApprovedByFabricHeadOn"] == null || reader["ApprovedByFabricHeadOn"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["ApprovedByFabricHeadOn"]);
                        cutting.ApprovedByMerchantOn = (reader["ApprovedByMerchantOn"] == null || reader["ApprovedByMerchantOn"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["ApprovedByMerchantOn"]);
                        cutting.ApprovedByProductionHeadOn = (reader["ApprovedByProductionHeadOn"] == null || reader["ApprovedByProductionHeadOn"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["ApprovedByProductionHeadOn"]);
                    }
                }
            }
            return cutting;
        }


        #endregion

        #region Updation Methods

        public bool UpdateCutting(Cutting cutting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_cutting_sheet_update_cutting_sheet";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;

                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Value = cutting.Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = cutting.order.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchant", SqlDbType.Int);
                    param.Value = cutting.ApprovedByMerchant;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricHead", SqlDbType.Int);
                    param.Value = cutting.ApprovedByFabricHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByProductionHead", SqlDbType.Int);
                    param.Value = cutting.ApprovedByProductionHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchantOn", SqlDbType.DateTime);
                    if ((cutting.ApprovedByMerchantOn == DateTime.MinValue) || (cutting.ApprovedByMerchantOn == Convert.ToDateTime("1753-01-01")) || (cutting.ApprovedByMerchantOn == Convert.ToDateTime("1900-01-01")))
                    //if (cutting.ApprovedByMerchantOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = cutting.ApprovedByMerchantOn;
                    }                    
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricHeadOn", SqlDbType.DateTime);
                    if ((cutting.ApprovedByFabricHeadOn == DateTime.MinValue) || (cutting.ApprovedByFabricHeadOn == Convert.ToDateTime("1753-01-01")) || (cutting.ApprovedByFabricHeadOn == Convert.ToDateTime("1900-01-01")))
                    //if (cutting.ApprovedByFabricHeadOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = cutting.ApprovedByFabricHeadOn;
                    }                          
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByProductionHeadOn", SqlDbType.DateTime);
                    if ((cutting.ApprovedByProductionHeadOn == DateTime.MinValue) || (cutting.ApprovedByProductionHeadOn == Convert.ToDateTime("1753-01-01")) || (cutting.ApprovedByProductionHeadOn == Convert.ToDateTime("1900-01-01")))
                  //  if (cutting.ApprovedByProductionHeadOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = cutting.ApprovedByProductionHeadOn;
                    }                     
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    
                    return true;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return false;
        }

        #endregion

    }
}
