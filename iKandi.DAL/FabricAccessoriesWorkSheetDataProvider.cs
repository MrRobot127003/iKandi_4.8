using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;

namespace iKandi.DAL
{
    public class FabricAccessoriesWorkSheetDataProvider : BaseDataProvider
    {

        #region Counstrutor(s)

        public FabricAccessoriesWorkSheetDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {

        }

        #endregion

        #region Create Accessory

        public AccessoryWorking CreateAccessoryWorking(AccessoryWorking objAccessoryWorking)
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
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Insert);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters
                    SqlParameter paramOut;
                    SqlParameter paramIn;

                    paramOut = new SqlParameter("@d", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);

                    paramIn = new SqlParameter("@OrderId", SqlDbType.Int);
                    paramIn.Value = objAccessoryWorking.Order.OrderID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccessoryManager", SqlDbType.Int);
                    paramIn.Value = objAccessoryWorking.ApprovedByAccessoryManager;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccessoryManagerOn", SqlDbType.DateTime);
                    if (objAccessoryWorking.ApprovedByAccessoryManagerOn != DateTime.MinValue)
                    {
                        paramIn.Value = objAccessoryWorking.ApprovedByAccessoryManagerOn;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccountManager", SqlDbType.Int);
                    paramIn.Value = objAccessoryWorking.ApprovedByAccountManager;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccountManagerOn", SqlDbType.DateTime);
                    if (objAccessoryWorking.ApprovedByAccountManagerOn != DateTime.MinValue)
                    {
                        paramIn.Value = objAccessoryWorking.ApprovedByAccountManagerOn;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@MainLabel", SqlDbType.VarChar);
                    if (objAccessoryWorking.MainLabel != null)
                    {
                        paramIn.Value = objAccessoryWorking.MainLabel;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Tags", SqlDbType.VarChar);
                    if (objAccessoryWorking.Tags != null)
                    {
                        paramIn.Value = objAccessoryWorking.Tags;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SizeLabel", SqlDbType.VarChar);
                    if (objAccessoryWorking.SizeLabel != null)
                    {
                        paramIn.Value = objAccessoryWorking.SizeLabel;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@WashCare", SqlDbType.VarChar);
                    if (objAccessoryWorking.WashCare != null)
                    {
                        paramIn.Value = objAccessoryWorking.WashCare;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Swatch", SqlDbType.VarChar);
                    if (objAccessoryWorking.Swatch != null)
                    {

                        paramIn.Value = objAccessoryWorking.Swatch;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@History", SqlDbType.VarChar);
                    paramIn.Value = objAccessoryWorking.History;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    objAccessoryWorking.Id = Convert.ToInt32(paramOut.Value);

                    if (objAccessoryWorking.Id > 0)
                    {
                        foreach (AccessoryWorkingDetail objAccessoryWorkingDetail in objAccessoryWorking.AccessoryWorkingDetail)
                        {
                            if (!objAccessoryWorkingDetail.IsOld)
                            {
                                objAccessoryWorkingDetail.AccessoryWorkingID = objAccessoryWorking.Id;
                                CreateAccessoryWorkingDetails(objAccessoryWorkingDetail, cnx, transaction);
                            }
                        }

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
            return objAccessoryWorking;
        }

        private void CreateAccessoryWorkingDetails(AccessoryWorkingDetail objAccessoryWorkingDetail, SqlConnection cnx, SqlTransaction transaction)
        {
            // Create a SQL command object
            string cmdText = "sp_accessory_working_details_insert_accessory_working";
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

            paramIn = new SqlParameter("@AccessoryWorkingID", SqlDbType.Int);
            paramIn.Value = objAccessoryWorkingDetail.AccessoryWorkingID;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AccessoryName", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.AccessoryName;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Quantity", SqlDbType.Int);
            paramIn.Value = objAccessoryWorkingDetail.Quantity;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Details", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.Details;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Number", SqlDbType.Decimal);
            paramIn.Value = objAccessoryWorkingDetail.Number;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@sDtm", SqlDbType.Bit);
            paramIn.Value = objAccessoryWorkingDetail.IsDTM;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Swatch", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.Swatch;
            cmd.Parameters.Add(paramIn);
            paramIn = new SqlParameter("@ExtraContractWise", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FinalP1;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@QuantityContractWise", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FinalCN1;
            cmd.Parameters.Add(paramIn);
            //Added By Ashish on 27/3/2014
            paramIn = new SqlParameter("@flatwst", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FinalFw1;
            cmd.Parameters.Add(paramIn);
            //END

            cmd.ExecuteNonQuery();
            objAccessoryWorkingDetail.Id = Convert.ToInt32(paramOut.Value);
        }

        #endregion

        #region Update Accessory

        public AccessoryWorking UpdateAccessoryWorking(AccessoryWorking objAccessoryWorking,string diff)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_accessory_working_update_accessory_working";
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Update);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters                    
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@d", SqlDbType.Int);
                    paramIn.Value = objAccessoryWorking.Id;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccessoryManager", SqlDbType.Int);
                    paramIn.Value = objAccessoryWorking.ApprovedByAccessoryManager;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccessoryManagerOn", SqlDbType.DateTime);
                    if (objAccessoryWorking.ApprovedByAccessoryManagerOn != DateTime.MinValue)
                    {
                        paramIn.Value = objAccessoryWorking.ApprovedByAccessoryManagerOn;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                   // paramIn.Value = objAccessoryWorking.ApprovedByAccessoryManagerOn;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccountManager", SqlDbType.Int);
                    paramIn.Value = objAccessoryWorking.ApprovedByAccountManager;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ApprovedByAccountManagerOn", SqlDbType.DateTime);
                    if (objAccessoryWorking.ApprovedByAccountManagerOn != DateTime.MinValue)
                    {
                        paramIn.Value = objAccessoryWorking.ApprovedByAccountManagerOn;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                   
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@MainLabel", SqlDbType.VarChar);
                    if (objAccessoryWorking.MainLabel != null)
                    {
                        paramIn.Value = objAccessoryWorking.MainLabel;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Tags", SqlDbType.VarChar);
                    if (objAccessoryWorking.Tags != null)
                    {
                        paramIn.Value = objAccessoryWorking.Tags;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SizeLabel", SqlDbType.VarChar);
                    if (objAccessoryWorking.SizeLabel != null)
                    {
                        paramIn.Value = objAccessoryWorking.SizeLabel;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@WashCare", SqlDbType.VarChar);
                    if (objAccessoryWorking.WashCare != null)
                    {
                        paramIn.Value = objAccessoryWorking.WashCare;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Swatch", SqlDbType.VarChar);
                    if (objAccessoryWorking.Swatch != null)
                    {
                        paramIn.Value = objAccessoryWorking.Swatch;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@History", SqlDbType.VarChar);
                    if (objAccessoryWorking.History != null)
                    {
                        paramIn.Value = objAccessoryWorking.History;
                    }
                    else
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();

                    foreach (AccessoryWorkingDetail objAccessoryWorkingDetailCount in objAccessoryWorking.AccessoryWorkingDetailCount)
                    {
                        if (!objAccessoryWorkingDetailCount.IsOld)
                        {
                            objAccessoryWorkingDetailCount.AccessoryWorkingID = objAccessoryWorking.Id;
                            UpdateAccessoryWorkingDetails(objAccessoryWorkingDetailCount, cnx, transaction);
                        }
                        else
                        {
                            objAccessoryWorkingDetailCount.AccessoryWorkingID = objAccessoryWorking.Id;
                            DeleteAccessoryWorkingDetails(objAccessoryWorkingDetailCount, cnx, transaction);
                        }
                    }

                    this.UpdateAccessoryBlukInHouse(objAccessoryWorking.Order.OrderID, cnx, transaction);

                    transaction.Commit();


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
            return objAccessoryWorking;
        }
        public DataSet GetAllAccessory(int OrderID, int AccessoriesWorkingId, string session)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                if (AccessoriesWorkingId == 0)
                {
                    cmdText = "sp_Get_Accesories_Order_Form_For_New_Accesories";
                }
                else
                {
                    cmdText = "sp_Get_Accesories_Order_Form";
                }

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                cmd.Parameters.Add(param);

                if (AccessoriesWorkingId != 0)
                {
                    param = new SqlParameter("@AccesoriesID", SqlDbType.Int);
                    param.Value = AccessoriesWorkingId;
                    cmd.Parameters.Add(param);
                }

                param = new SqlParameter("@SessionID", SqlDbType.VarChar);
                param.Value = session;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;

            }
        }
        private string GetMinWastage(int OrderID)
        {
            string Wastage;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_GetMinWastage";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Wastage = cmd.ExecuteScalar().ToString();


                return Wastage;
            }
        }
        //added by abhishek on 16/5/2016
        public void DropUserSessions(string SessionTableName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();
                    string cmdText = "Usp_DeteleAcessoryForm_SessionTable";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                    cmd.Transaction = transaction;
                 
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter paramIn;
                    paramIn = new SqlParameter("@SessionTableName", SqlDbType.NVarChar);
                    paramIn.Value = SessionTableName;
                    cmd.Parameters.Add(paramIn);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();

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
        }
        public void GetCountAccesoriesDetails(int OrderID, int AccessoriesWorkingId, int count, string session1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {


                string cmdTextinsert;
                string cmdUpdate;
                string cmdtotalContract;
                int id = 0;
                string QuantractWise = "";
                string ExtraContractWise = "";
                string flatwst = "";
                int quantity;
                int NewOrderNumber = 0; ;
                int AccesoriesWorkingIDFabric;
                int totalQty = 0;
                int Wastage = 0;
                try
                {
                    //Wastage = GetMinWastage(OrderID);
                    DataSet dsorderDetail = new DataSet();
                    //cmdTextinsert = "SELECT * FROM TStat WHERE AccessoryWorkingId=" + accesoriesid + " ";
                    if (AccessoriesWorkingId != 0)
                    {
                        cmdTextinsert = "SELECT * FROM TStat" + session1 + " WHERE AccessoryWorkingId=" + AccessoriesWorkingId + ";SELECT ROUND(isnull(SUM(Quantity),0),0) d  FROM  order_detail_size WHERE OrderDetailID =(SELECT orderDetailsID FROM " + session1 + " WHERE " + session1 + ".TorderID=" + count + ")";
                    }
                    else
                    {
                        cmdTextinsert = "SELECT * FROM TStat" + session1 + "; SELECT ROUND(isnull(SUM(Quantity),0),0) d  FROM  order_detail_size WHERE OrderDetailID =(SELECT orderDetailsID FROM " + session1 + " WHERE " + session1 + ".TorderID=" + count + ")";
                    }


                    SqlCommand cmd = new SqlCommand(cmdTextinsert, cnx);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsorderDetail);
                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];
                        DataTable d1 = dsorderDetail.Tables[1];
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (AccessoriesWorkingId == 0)
                                {
                                    NewOrderNumber = Convert.ToInt32(dr["Number"]);
                                }
                                foreach (DataRow dr1 in d1.Rows)
                                {

                                    quantity = Convert.ToInt32(dr1["d"]);
                                    totalQty = quantity;
                                }
                                if (AccessoriesWorkingId != 0)
                                    AccesoriesWorkingIDFabric = Convert.ToInt32(dr["AccessoryWorkingID"]);
                                id = Convert.ToInt32(dr["id"]);
                                if (AccessoriesWorkingId != 0)
                                    QuantractWise = Convert.ToString(dr["QuantityContractWise"]);

                                else
                                {
                                    QuantractWise = "0";
                                }
                                if (AccessoriesWorkingId != 0)
                                    ExtraContractWise = Convert.ToString(dr["ExtraContractWise"]);

                                //Added By Ashish on 27/3/2014
                                if (AccessoriesWorkingId != 0)
                                {
                                    flatwst = Convert.ToString(dr["flatwst"]);
                                    //flatwst = Convert.ToString(Wastage);
                                }
                                //END
                                SqlTransaction transaction = null;

                                DateTime CreatedOn = DateTime.MinValue;
                                DataSet dsCreastedon = new DataSet();
                                string cmdTextCreastedon = "SELECT Id,OrderId,CreatedOn FROM accessory_working where OrderId=" + OrderID;
                                SqlCommand cmdCreate = new SqlCommand(cmdTextCreastedon, cnx);
                                SqlDataAdapter adapter1 = new SqlDataAdapter(cmdCreate);
                                adapter1.Fill(dsCreastedon);
                                if (dsCreastedon.Tables[0].Rows.Count > 0)
                                {
                                    CreatedOn = (dsCreastedon.Tables[0].Rows[0]["CreatedOn"] != DBNull.Value) ? Convert.ToDateTime(dsCreastedon.Tables[0].Rows[0]["CreatedOn"]) : DateTime.MinValue;
                                }
                                else
                                {
                                    CreatedOn = DateTime.MinValue;
                                }
                                //DateTime CreatedOn1 = (dsCreastedon.Tables[0].Rows[0]["CreatedOn"] != DBNull.Value) ? Convert.ToDateTime(dsCreastedon.Tables[0].Rows[0]["CreatedOn"]) : DateTime.MinValue;

                                if (QuantractWise == "0")
                                {
                                    if (AccessoriesWorkingId != 0)
                                    {

                                        if (ExtraContractWise == "0")
                                        {

                                            if (Convert.ToDateTime(CreatedOn) <= Convert.ToDateTime(System.DateTime.Now) || Convert.ToDateTime(CreatedOn) == DateTime.MinValue)
                                            {
                                                if (Convert.ToDateTime(CreatedOn).ToString("MM/dd/yyyy") == Convert.ToDateTime(System.DateTime.Now).ToString("MM/dd/yyyy"))
                                                {
                                                    // cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=" + ExtraContractWise + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                                    cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT dbo.fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=" + ExtraContractWise + ",fw" + count + "=" +Wastage+ " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                                }
                                                else
                                                {

                                                    //cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=4.4 WHERE Tstat" + session1 + ".ID=" + id + ";";
                                                    cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT dbo.fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=4.4,fw" + count + "=" + Wastage + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                                }
                                            }
                                            else
                                            {
                                                //cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=" + ExtraContractWise + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                                cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT dbo.fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=" + ExtraContractWise + ",fw" + count + "=" + Wastage + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                            }


                                        }
                                        else
                                        {
                                            //cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=" + ExtraContractWise + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                            cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=(SELECT dbo.fn_GetAccesoriesPercent( " + totalQty + " * Number) AS 'Quantity' FROM Accessory_Working_Detail WHERE AccessoryWorkingId=" + AccessoriesWorkingId + " AND Accessory_Working_Detail.ID=" + id + "),P" + count + "=" + ExtraContractWise + ",fw" + count + "=" + Wastage + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                        }
                                    }
                                    else
                                    {
                                        cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + count + "=" + totalQty + " * " + NewOrderNumber + ",fw" + count + "=" + Wastage + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                    }

                                    if (cnx.State != ConnectionState.Open)
                                        cnx.Open();
                                    SqlCommand cmd1 = new SqlCommand(cmdUpdate, cnx);
                                    cmd1.Transaction = transaction;
                                    cmd1.CommandType = CommandType.Text;
                                    cmd1.CommandTimeout = 180;
                                    cmd1.ExecuteNonQuery();


                                }
                                else
                                {
                                    string[] splitQuantractWiseValues = QuantractWise.Split(',');
                                    string[] splitExtraContractWiseValues = ExtraContractWise.Split(',');

                                    string[] splitFlatWastageValues = flatwst.Split(',');


                                    int countQuantractWiseValues = splitQuantractWiseValues.Length;

                                    for (int j = 0; j <= countQuantractWiseValues - 1; j++)
                                    {
                                        int k = j + 1;
                                        //cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + k + "=" + splitQuantractWiseValues[j] + ",P" + k + "=" + splitExtraContractWiseValues[j] + " WHERE Tstat" + session1 + ".ID=" + id + ";";
                                        cmdUpdate = "UPDATE TStat" + session1 + " SET CN" + k + "=" + splitQuantractWiseValues[j] + ",P" + k + "=" + splitExtraContractWiseValues[j] + ",fw" + k + "=" + splitFlatWastageValues[j] + "  WHERE Tstat" + session1 + ".ID=" + id + ";";
                                        if (cnx.State != ConnectionState.Open)
                                            cnx.Open();
                                        SqlCommand cmd1 = new SqlCommand(cmdUpdate, cnx);
                                        cmd1.Transaction = transaction;
                                        cmd1.CommandType = CommandType.Text;
                                        cmd1.CommandTimeout = 180;
                                        cmd1.ExecuteNonQuery();
                                    }
                                }


                            }

                        }
                        cmdtotalContract = "UPDATE TStat" + session1 + " SET CNTotal" + count + "=(SELECT ROUND(isnull(SUM(Quantity),0),0)  FROM order_detail_size WHERE OrderDetailID=(SELECT orderDetailsID FROM " + session1 + " WHERE " + session1 + ".TorderID=" + count + "))";
                        // UPDATE TStatdfgdfgfdgfdgfd SET CNTotal1=(SELECT ROUND(SUM(Quantity)) FROM  order_detail_size WHERE OrderDetailID=(SELECT orderDetailsID FROM Torder  WHERE TorderID=1));


                        if (cnx.State != ConnectionState.Open)
                            cnx.Open();
                        SqlCommand cmd2 = new SqlCommand(cmdtotalContract, cnx);
                        //   cmd2.Transaction = transaction;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandTimeout = 180;
                        cmd2.ExecuteNonQuery();
                    }



                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }

        }
      
        //edn by abishek

        public DataSet GetAllAccessoryDetailsCompleteData(int AccessoriesWorkingId, int orderID, string session3)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dscheck = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Accesories_CompleteData";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@AccesoriesID", SqlDbType.Int);
                param.Value = AccessoriesWorkingId;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = orderID;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@session3", SqlDbType.VarChar);
                param.Value = session3;
                cmd.Parameters.Add(param);

                // DataSet dscheck = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dscheck);
                cnx.Close();
                return dscheck;

            }
        }

        private void UpdateAccessoryWorkingDetails(AccessoryWorkingDetail objAccessoryWorkingDetail, SqlConnection cnx, SqlTransaction transaction)
        {
            // Create a SQL command object
            string cmdText = "sp_accessory_working_details_update_accessory_working";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters            
            SqlParameter paramIn;

            paramIn = new SqlParameter("@d", SqlDbType.Int);
            paramIn.Value = objAccessoryWorkingDetail.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AccessoryWorkingID", SqlDbType.Int);
            paramIn.Value = objAccessoryWorkingDetail.AccessoryWorkingID;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AccessoryName", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.AccessoryName;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Quantity", SqlDbType.Int);
            paramIn.Value = objAccessoryWorkingDetail.Quantity;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Details", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.Details;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Number", SqlDbType.Decimal);
            paramIn.Value = objAccessoryWorkingDetail.Number;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@sDtm", SqlDbType.Bit);
            paramIn.Value = objAccessoryWorkingDetail.IsDTM;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Swatch", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.Swatch;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ExtraContractWise", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FinalP1;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@QuantityContractWise", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FinalCN1;
            cmd.Parameters.Add(paramIn);

            //Added By Ashish on 27/3/2014
            paramIn = new SqlParameter("@flatwst", SqlDbType.VarChar);
            paramIn.Value = objAccessoryWorkingDetail.FinalFw1;
            cmd.Parameters.Add(paramIn);
            //END

            cmd.ExecuteNonQuery();
        }

        public void UpdateAccessoryBlukInHouse(int OrderID, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_accessory_update_bulk_in_house";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
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

        #region Get Accessory

        public List<Accessory> GetAllAccessory(Int32 OrderID)
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
                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Accessory> accessories = new List<Accessory>();

                while (reader.Read())
                {
                    Accessory accessory = new Accessory();
                    accessory.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    accessory.Name = (reader["Name"] != DBNull.Value) ? Convert.ToString(reader["Name"]) : String.Empty;
                    accessory.Quantity = (reader["Quantity"] != DBNull.Value) ? Convert.ToDecimal(reader["Quantity"]) : 0;
                    accessory.TotalQuantity = (reader["totalQty"] != DBNull.Value) ? Convert.ToInt32(reader["totalQty"]) : 0;
                    accessories.Add(accessory);
                }

                return accessories;
            }
        }
       

        public AccessoryWorking GetAccessoryWorking(Int32 orderID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_accessory_working_get_all_accessory_working";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = orderID;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                AccessoryWorking accessoriyWorking = new AccessoryWorking();

                while (reader.Read())
                {
                    accessoriyWorking.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    accessoriyWorking.Order = new Order();
                    accessoriyWorking.Order.OrderID = (reader["OrderId"] != DBNull.Value) ? Convert.ToInt32(reader["OrderID"]) : 0;
                    accessoriyWorking.ApprovedByAccessoryManager = (reader["ApprovedByAccessoryManager"] != DBNull.Value || reader["ApprovedByAccessoryManager"].ToString() != String.Empty) ? Convert.ToInt32(reader["ApprovedByAccessoryManager"]) : Int32.MinValue;
                    accessoriyWorking.ApprovedByAccessoryManagerOn = (reader["ApprovedByAccessoryManagerOn"] != DBNull.Value ? Convert.ToDateTime(reader["ApprovedByAccessoryManagerOn"]) : DateTime.MinValue);
                    accessoriyWorking.ApprovedByAccountManager = (reader["ApprovedByAccountManager"] != DBNull.Value || reader["ApprovedByAccountManager"].ToString() != String.Empty) ? Convert.ToInt32(reader["ApprovedByAccountManager"]) : Int32.MinValue;
                    accessoriyWorking.ApprovedByAccountManagerOn = (reader["ApprovedByAccountManagerOn"] != DBNull.Value ? Convert.ToDateTime(reader["ApprovedByAccountManagerOn"]) : DateTime.MinValue);
                    accessoriyWorking.MainLabel = (reader["MainLabel"] != DBNull.Value ? reader["MainLabel"].ToString() : String.Empty);
                    accessoriyWorking.Tags = (reader["Tags"] != DBNull.Value ? reader["Tags"].ToString() : String.Empty);
                    accessoriyWorking.SizeLabel = (reader["SizeLabel"] != DBNull.Value ? reader["SizeLabel"].ToString() : String.Empty);
                    accessoriyWorking.WashCare = (reader["WashCare"] != DBNull.Value ? reader["WashCare"].ToString() : String.Empty);
                    accessoriyWorking.Swatch = (reader["Swatch"] != DBNull.Value ? reader["Swatch"].ToString() : String.Empty);
                    accessoriyWorking.History = (reader["History"] != DBNull.Value ? reader["History"].ToString() : String.Empty);
                    accessoriyWorking.AccessoryWorkingDetailCount = GetAccessoryWorkingDetailsWithOrderID(accessoriyWorking.Id, orderID);

                }

                return accessoriyWorking;
            }
        }


        private List<AccessoryWorkingDetail> GetAccessoryWorkingDetailsWithOrderID(Int32 accessoryWorkingID, int orderID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_accessory_working_details_get_all_accessory_working_details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@AccessoryWorkingID", SqlDbType.Int);
                param.Value = accessoryWorkingID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = orderID;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                List<AccessoryWorkingDetail> accessoriyWorkingDetailCollection = new List<AccessoryWorkingDetail>();

                while (reader.Read())
                {
                    AccessoryWorkingDetail accessoriyWorkingDetail = new AccessoryWorkingDetail();
                    accessoriyWorkingDetail.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    accessoriyWorkingDetail.AccessoryName = (reader["AccessoryName"] != DBNull.Value) ? reader["AccessoryName"].ToString() : String.Empty;
                    accessoriyWorkingDetail.AccessoryWorkingID = accessoryWorkingID;
                    accessoriyWorkingDetail.Details = (reader["Details"] != DBNull.Value) ? Convert.ToString(reader["Details"]) : String.Empty;
                    accessoriyWorkingDetail.Number = (reader["Number"] != DBNull.Value || reader["Number"].ToString() != String.Empty) ? Convert.ToDecimal(reader["Number"]) : 0;
                    accessoriyWorkingDetail.Quantity = (reader["Quantity"] != DBNull.Value || reader["Quantity"].ToString() != String.Empty) ? Convert.ToInt32(reader["Quantity"]) : 0;
                    accessoriyWorkingDetail.FilePath = (reader["FilePath"] != DBNull.Value) ? Convert.ToString(reader["FilePath"]) : String.Empty;
                    accessoriyWorkingDetail.IsDTM = (reader["IsDTM"] != DBNull.Value) ? Convert.ToBoolean(reader["IsDTM"]) : false;
                    accessoriyWorkingDetail.Swatch = (reader["Swatch"] != DBNull.Value) ? Convert.ToString(reader["Swatch"]) : String.Empty;
                    accessoriyWorkingDetailCollection.Add(accessoriyWorkingDetail);
                }

                return accessoriyWorkingDetailCollection;
            }
        }

        private List<AccessoryWorkingDetail> GetAccessoryWorkingDetails(Int32 accessoryWorkingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_accessory_working_details_get_all_accessory_working_details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@AccessoryWorkingID", SqlDbType.Int);
                param.Value = accessoryWorkingID;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryWorkingDetail> accessoriyWorkingDetailCollection = new List<AccessoryWorkingDetail>();

                while (reader.Read())
                {
                    AccessoryWorkingDetail accessoriyWorkingDetail = new AccessoryWorkingDetail();
                    accessoriyWorkingDetail.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    accessoriyWorkingDetail.AccessoryName = (reader["AccessoryName"] != DBNull.Value) ? reader["AccessoryName"].ToString() : String.Empty;
                    accessoriyWorkingDetail.AccessoryWorkingID = accessoryWorkingID;
                    accessoriyWorkingDetail.Details = (reader["Details"] != DBNull.Value) ? Convert.ToString(reader["Details"]) : String.Empty;
                    accessoriyWorkingDetail.Number = (reader["Number"] != DBNull.Value || reader["Number"].ToString() != String.Empty) ? Convert.ToDecimal(reader["Number"]) : 0;
                    accessoriyWorkingDetail.Quantity = (reader["Quantity"] != DBNull.Value || reader["Quantity"].ToString() != String.Empty) ? Convert.ToInt32(reader["Quantity"]) : 0;
                    accessoriyWorkingDetail.FilePath = (reader["FilePath"] != DBNull.Value) ? Convert.ToString(reader["FilePath"]) : String.Empty;
                    accessoriyWorkingDetail.IsDTM = (reader["IsDTM"] != DBNull.Value) ? Convert.ToBoolean(reader["IsDTM"]) : false;
                    accessoriyWorkingDetail.Swatch = (reader["Swatch"] != DBNull.Value) ? Convert.ToString(reader["Swatch"]) : String.Empty;
                    accessoriyWorkingDetailCollection.Add(accessoriyWorkingDetail);
                }

                return accessoriyWorkingDetailCollection;
            }
        }


        public List<AccessoryWorking> GetAccessoryWorkingByCurrentDate(DateTime CurrentDate)
        {
            List<AccessoryWorking> accessoryWorkingCollection = new List<AccessoryWorking>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_accessory_working_get_accessory_workings_by_currentDate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@CurrentDate", SqlDbType.DateTime);
                param.Value = CurrentDate;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryWorking accessoryWorking = new AccessoryWorking();
                        accessoryWorking.Order = new Order();

                        accessoryWorking.Order.SerialNumber = Convert.ToString(reader["SerialNumber"]);

                        string History = Convert.ToString(reader["History"]);
                        if (History.ToString().IndexOf("$$") > -1)
                        {
                            History = History.ToString().Replace("$$", "<br/>");
                        }
                        accessoryWorking.History = History;
                        accessoryWorkingCollection.Add(accessoryWorking);
                    }
                }
            }
            return accessoryWorkingCollection;
        }

        #endregion

        #region Delete Accessory

        private void DeleteAccessoryWorkingDetails(AccessoryWorkingDetail objAccessoryWorkingDetail, SqlConnection cnx, SqlTransaction transaction)
        {
            // Create a SQL command object
            string cmdText = "sp_accessory_working_details_delete_accessory_working";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters            
            SqlParameter paramIn;

            paramIn = new SqlParameter("@d", SqlDbType.Int);
            paramIn.Value = objAccessoryWorkingDetail.Id;
            cmd.Parameters.Add(paramIn);

            cmd.ExecuteNonQuery();
        }

        #endregion

        public AccessoryWorkingDetail GetAccessoryWorkingDetailByID(int AccessoryWorkingDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_accessory_working_get_accessory_working_detail_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@AccessoryWorkingDetailID", SqlDbType.Int);
                param.Value = AccessoryWorkingDetailID;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                AccessoryWorkingDetail accessoriyWorkingDetail = new AccessoryWorkingDetail();

                if (reader.Read())
                {
                    accessoriyWorkingDetail.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    accessoriyWorkingDetail.AccessoryName = (reader["AccessoryName"] != DBNull.Value) ? reader["AccessoryName"].ToString() : String.Empty;
                    accessoriyWorkingDetail.Details = (reader["Details"] != DBNull.Value) ? Convert.ToString(reader["Details"]) : String.Empty;
                    accessoriyWorkingDetail.Number = (reader["Number"] != DBNull.Value || reader["Number"].ToString() != String.Empty) ? Convert.ToDecimal(reader["Number"]) : 0;
                    accessoriyWorkingDetail.Quantity = (reader["Quantity"] != DBNull.Value || reader["Quantity"].ToString() != String.Empty) ? Convert.ToInt32(reader["Quantity"]) : 0;
                    accessoriyWorkingDetail.FilePath = (reader["FilePath"] != DBNull.Value) ? Convert.ToString(reader["FilePath"]) : String.Empty;
                    accessoriyWorkingDetail.IsDTM = (reader["IsDTM"] != DBNull.Value) ? Convert.ToBoolean(reader["IsDTM"]) : false;
                    accessoriyWorkingDetail.Swatch = (reader["Swatch"] != DBNull.Value) ? Convert.ToString(reader["Swatch"]) : String.Empty;
                }

                return accessoriyWorkingDetail;
            }
        }

        public DataSet GetOrderQuantity(int orderID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dscheck = new DataSet();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Select Id,Quantity,OrderID from order_detail where Quantity > 0 and orderId=" + orderID;

                cmd = new SqlCommand(cmdText, cnx);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dscheck);
                cnx.Close();
                return dscheck;

            }
        }
        // add by sushil on date 27/3/2015
        public DataSet Getfabrictooltip(int orderID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dstooltip = new DataSet();
                cnx.Open();
                string cmdTextCreastedon = "select ( od.ContractNumber + char(10)+ od.LineItemNumber  + char(10)+ od.Fabric1 + char(10)+ od.Fabric1Details ) AS Fabtooltip from order_detail OD  where OD.OrderId=" + orderID;
                SqlCommand cmdCreate = new SqlCommand(cmdTextCreastedon, cnx);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmdCreate);
                adapter1.Fill(dstooltip);
                cnx.Close();
                return dstooltip;

            }
        }
        // end code sushil on date 27/3/2015

    }
}


