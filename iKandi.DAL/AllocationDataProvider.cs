using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace iKandi.DAL
{
    public class AllocationDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public AllocationDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Methods
        //added by abhishek on 14/9/2015-------------------------
        public bool SaveProductionUnit(ProductionUnit objProductionUnit)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                bool isInsertion = true;

                if (objProductionUnit.ProductionUnitId > 0)
                    isInsertion = false;

                SqlTransaction transaction = null;

                try
                {
                    string cmdText;

                    if (isInsertion)
                        cmdText = "sp_production_unit_insert_production_unit";
                    else
                        cmdText = "sp_production_unit_update_production_unit";

                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam = new SqlParameter();
                    SqlParameter param;

                    if (isInsertion)
                    {
                        outParam = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                        outParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outParam);
                    }
                    else
                    {
                        param = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                        param.Value = objProductionUnit.ProductionUnitId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    param = new SqlParameter("@Name", SqlDbType.VarChar);
                    param.Value = objProductionUnit.FactoryName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryCode", SqlDbType.VarChar);
                    param.Value = objProductionUnit.FactoryCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Address", SqlDbType.VarChar);
                    param.Value = objProductionUnit.Address;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //add code by bharat on 01-02020
                    param = new SqlParameter("@EmailId", SqlDbType.VarChar);
                    param.Value = objProductionUnit.EmailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NumberOfMachines", SqlDbType.Int);
                    param.Value = objProductionUnit.NumberOfMachines;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NumberOfLines", SqlDbType.Int);
                    param.Value = objProductionUnit.NumberOfLines;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NumberOfFloors", SqlDbType.Int);
                    param.Value = objProductionUnit.NumberOfFloors;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Capacity", SqlDbType.Float);

                    param.Value = objProductionUnit.Capacity;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionUnitManagerId", SqlDbType.Int);
                    param.Value = objProductionUnit.ProductionUnitManagerId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionUnitColor", SqlDbType.VarChar);
                    param.Value = objProductionUnit.ProductionUnitColor;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Classificatio", SqlDbType.Int);
                    param.Value = objProductionUnit.Classification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Unit_Monthly_Overheads", SqlDbType.Int);
                    param.Value = objProductionUnit.Unit_Monthly_Overheads;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Cuttingshare", SqlDbType.Int);
                    param.Value = objProductionUnit.Cuttingshare;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stitchingshar", SqlDbType.Int);
                    param.Value = objProductionUnit.stitchingshar;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@finishingshar", SqlDbType.Int);
                    param.Value = objProductionUnit.finishingshar;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //Abhishk 18/2/2016
                    param = new SqlParameter("@Clientname", SqlDbType.VarChar);
                    if (objProductionUnit.Clientname == "0")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objProductionUnit.Clientname;
                    }
                    //end 
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //-----added on 17/8/2015
                    param = new SqlParameter("@Finishing_Active", SqlDbType.Bit);
                    param.Value = objProductionUnit.Finishing_Active;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Cutting_Active", SqlDbType.Bit);
                    param.Value = objProductionUnit.Cutting_Active;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //--End on 17/8/2015


                    //-----added on 28/8/2015
                    param = new SqlParameter("@factoryIE_ids", SqlDbType.VarChar);
                    param.Value = objProductionUnit.FactoryIE;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@writerIE_ids", SqlDbType.VarChar);
                    param.Value = objProductionUnit.WirterIE;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //--End on 28/8/2015

                    param = new SqlParameter("@FinishingAllocate_Unit", SqlDbType.Int);
                    param.Value = objProductionUnit.FinishingAllocate_Unit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CuttingAllocate_Unit", SqlDbType.Int);
                    param.Value = objProductionUnit.CuttingAllocate_Unit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadFile1", SqlDbType.VarChar);
                    param.Value = objProductionUnit.FileUploadUrl1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadFile2", SqlDbType.VarChar);
                    param.Value = objProductionUnit.FileUploadUrl2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadFile3", SqlDbType.VarChar);
                    param.Value = objProductionUnit.FileUploadUrl3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadFile4", SqlDbType.VarChar);
                    param.Value = objProductionUnit.FileUploadUrl4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FinshingSupervisor", SqlDbType.Int);
                    //param.Value = objProductionUnit.finishingSupervisor;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FinshingIncerge", SqlDbType.Int);
                    //param.Value = objProductionUnit.FinishingIncharge;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    //param = new SqlParameter("@FinshingQa", SqlDbType.Int);
                    //param.Value = objProductionUnit.finishingQa;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    param = new SqlParameter("@QAFactoryHeadID", SqlDbType.Int);
                    if (objProductionUnit.QAFactoryHeadId != -1)
                    {
                        param.Value = objProductionUnit.QAFactoryHeadId;
                    }


                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@CluserCount", SqlDbType.Int);
                    param.Value = objProductionUnit.Cluster;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsVA_Enabled", SqlDbType.Bit);
                    param.Value = objProductionUnit.IsVA_Enabled;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (isInsertion)
                    {
                        objProductionUnit.ProductionUnitId = Convert.ToInt32(outParam.Value);

                        if (objProductionUnit.ProductionUnitId == -1)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return false;
        }
        //end by abhishek 

        public bool DeleteProductionUnit(int productionUnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                int ReturnValue = 0;
                try
                {
                    string cmdText = "sp_production_unit_delete_production_unit";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                    param.Value = productionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam = new SqlParameter();

                    outParam = new SqlParameter("@Return", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    ReturnValue = Convert.ToInt32(outParam.Value);
                    if (ReturnValue == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

                return false;
            }
        }

        public int DeleteProductionUnit_ByUnitId(int productionUnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                int ReturnValue = 0;
                try
                {
                    string cmdText = "sp_production_unit_delete_production_unit";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                    param.Value = productionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam = new SqlParameter();

                    outParam = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    ReturnValue = Convert.ToInt32(outParam.Value);

                    transaction.Commit();
                    return ReturnValue;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return ReturnValue;
            }
        }

        public ProductionUnitCollection GetProductionUnits(string SearchTxt)
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

                SqlParameter param = new SqlParameter("@SearchTxt", SqlDbType.VarChar);
                param.Value = SearchTxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                ProductionUnitCollection objProductionUnitCollection = new ProductionUnitCollection();

                while (reader.Read())
                {
                    ProductionUnit objProductionUnit = new ProductionUnit();

                    objProductionUnit.ProductionUnitId = Convert.ToInt32(reader["Id"]);
                    objProductionUnit.FactoryName = Convert.ToString(reader["Name"]);
                    objProductionUnit.FactoryCode = Convert.ToString(reader["FactoryCode"]);
                    objProductionUnit.Address = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);
                    objProductionUnit.EmailId = (reader["emailID"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["emailID"]);
                    objProductionUnit.NumberOfMachines = (reader["NumberOfMachines"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["NumberOfMachines"]);
                    objProductionUnit.NumberOfLines = (reader["NumberOfLines"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["NumberOfLines"]);
                    objProductionUnit.NumberOfFloors = (reader["NumberOfFloors"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["NumberOfFloors"]);
                    objProductionUnit.Capacity = (reader["Capacity"] == DBNull.Value) ? 0 : Math.Round(Convert.ToDouble(reader["Capacity"])*100)/100;

                    objProductionUnit.ProductionUnitManagerId = (reader["ProductionUnitManagerId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductionUnitManagerId"]);
                    objProductionUnit.ProductionUnitManagerName = (reader["ProductionUnitManagerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductionUnitManagerName"]);

                    objProductionUnit.QAFactoryHeadId = (reader["FactoryHeadID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FactoryHeadID"]);
                    objProductionUnit.QAFactoryHeadName = (reader["ProductionUnitFactoryHeadName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductionUnitFactoryHeadName"]);

                    objProductionUnit.ProductionUnitColor = (reader["ProductionUnitColor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductionUnitColor"]);
                    //Added By abhishek on 8/6/2015
                    objProductionUnit.Classification = (reader["FactoryClassification"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["FactoryClassification"]);
                    objProductionUnit.Clientname = (reader["ClientID"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientID"]);

                    objProductionUnit.Cuttingshare = (reader["CuttingShare"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CuttingShare"]);
                    objProductionUnit.stitchingshar = (reader["Stitching"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Stitching"]);
                    objProductionUnit.finishingshar = (reader["Finishing"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Finishing"]);




                    objProductionUnit.Unit_Monthly_Overheads = (reader["MonthlyOverHead"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["MonthlyOverHead"]);
                    //END

                    // added on 17/8/2015
                    objProductionUnit.Finishing_Active = (reader["Finishing_Active"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Finishing_Active"]);
                    objProductionUnit.Cutting_Active = (reader["Cutting_Active"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Cutting_Active"]);
                    //end on 17/8/2015

                    //added on 24/8/2015


                    objProductionUnit.FactoryIE = (reader["FactoryIE"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryIE"]);
                    objProductionUnit.WirterIE = (reader["writerIE"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["writerIE"]);

                    //end on 24/8/2015
                    //added on 14/9/2015


                    objProductionUnit.FinishingAllocate_Unit = (reader["FinishingAllocate_Unit"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["FinishingAllocate_Unit"]);
                    objProductionUnit.CuttingAllocate_Unit = (reader["CuttingAllocate_Unit"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CuttingAllocate_Unit"]);

                    //end on 14/9/2015
                    objProductionUnit.FileUploadUrl1 = (reader["picture1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["picture1"]);
                    objProductionUnit.FileUploadUrl2 = (reader["picture2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["picture2"]);
                    objProductionUnit.FileUploadUrl3 = (reader["picture3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["picture3"]);
                    objProductionUnit.FileUploadUrl4 = (reader["AuditPicture"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AuditPicture"]);

                    objProductionUnit.finishingSupervisor = (reader["FinishingSupervisor"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FinishingSupervisor"]);
                    objProductionUnit.FinishingIncharge = (reader["FinishingIncharge"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FinishingIncharge"]);
                    objProductionUnit.finishingQa = (reader["FinishingQA"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FinishingQA"]);

                    objProductionUnit.finishingQa = (reader["FinishingQA"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FinishingQA"]);
                    objProductionUnit.Cluster = (reader["ClusterCount"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ClusterCount"]);
                    objProductionUnit.IsVA_Enabled = (reader["IsVAEnabled"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["IsVAEnabled"]);
                    objProductionUnitCollection.Add(objProductionUnit);
                }

                return objProductionUnitCollection;
            }
        }

        public ProductionUnit GetProductionUnits(Int32 UnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_production_unit_get_unit_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                ProductionUnit objProductionUnit = new ProductionUnit();

                while (reader.Read())
                {
                    objProductionUnit.ProductionUnitId = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]);
                    objProductionUnit.FactoryName = (reader["Name"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Name"]);
                    objProductionUnit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);
                    objProductionUnit.Address = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);

                    objProductionUnit.NumberOfMachines = (reader["NumberOfMachines"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["NumberOfMachines"]);
                    objProductionUnit.NumberOfLines = (reader["NumberOfLines"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["NumberOfLines"]);
                    objProductionUnit.NumberOfFloors = (reader["NumberOfFloors"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["NumberOfFloors"]);
                    objProductionUnit.Capacity = (reader["Capacity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Capacity"]);

                    objProductionUnit.ProductionUnitManagerId = (reader["ProductionUnitManagerId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductionUnitManagerId"]);
                    objProductionUnit.ProductionUnitManagerName = (reader["ProductionUnitManagerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductionUnitManagerName"]);

                    objProductionUnit.ProductionUnitColor = (reader["ProductionUnitColor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProductionUnitColor"]);

                    // added on 17/8/2015
                    objProductionUnit.Finishing_Active = (reader["Finishing_Active"] == DBNull.Value) ? 0: Convert.ToInt32(reader["Finishing_Active"]);
                    objProductionUnit.Cutting_Active = (reader["Cutting_Active"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Cutting_Active"]);
                    //end on 17/8/2015
                    //added on 24/8/2015


                    //objProductionUnit.Clientname = (reader["FactoryIE"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryIE"]);
                    //objProductionUnit.Clientname = (reader["writerIE"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["writerIE"]);

                    //end on 24/8/2015
                }

                return objProductionUnit;
            }
        }

        public AllocationCollection GetAllocationData()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                AllocationCollection objAllocationCollection = new AllocationCollection();

                string cmdText;

                try
                {
                    cmdText = "sp_get_allocation_data_with_accessories";
                    cnx.Open();

                    SqlCommand cmd;

                    cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsAllocationCollection = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsAllocationCollection);

                    if (dsAllocationCollection.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsAllocationCollection.Tables[0];
                        DataTable dt1 = dsAllocationCollection.Tables[1];
                        DataTable dt2 = dsAllocationCollection.Tables[2];


                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dt.Rows)
                            {
                                Allocation objAllocation = new Allocation();
                                objAllocation.OrderDetailID = Convert.ToInt32(reader["OrderDetailId"]);
                                objAllocation.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                                objAllocation.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                                objAllocation.OrderID = Convert.ToInt32(reader["OrderID"]);

                                objAllocation.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                                objAllocation.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                                objAllocation.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                                objAllocation.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);
                                objAllocation.CCGSM1 = (reader["Fabric11"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric11"]);
                                objAllocation.CCGSM2 = (reader["Fabric12"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric12"]);
                                objAllocation.CCGSM3 = (reader["Fabric13"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric13"]);
                                objAllocation.CCGSM4 = (reader["Fabric14"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric14"]);

                                bool success;
                                int result;

                                objAllocation.Fabric1Details = (reader["Fabric1DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1DetailsRef"]);
                                objAllocation.Fabric2Details = (reader["Fabric2DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2DetailsRef"]);
                                objAllocation.Fabric3Details = (reader["Fabric3DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3DetailsRef"]);
                                objAllocation.Fabric4Details = (reader["Fabric4DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4DetailsRef"]);

                                var Fab1Det = objAllocation.Fabric1Details.Trim().Split(' ');
                                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                                {
                                    objAllocation.Fabric1Details = "PRD:" + objAllocation.Fabric1Details;
                                    success = false;
                                    result = 0;
                                }

                                var Fab2Det = objAllocation.Fabric2Details.Trim().Split(' ');
                                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                                {
                                    objAllocation.Fabric2Details = "PRD:" + objAllocation.Fabric2Details;
                                    success = false;
                                    result = 0;
                                }

                                var Fab3Det = objAllocation.Fabric3Details.Trim().Split(' ');
                                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                                {
                                    objAllocation.Fabric3Details = "PRD:" + objAllocation.Fabric3Details;
                                    success = false;
                                    result = 0;
                                }

                                var Fab4Det = objAllocation.Fabric3Details.Trim().Split(' ');
                                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                                {
                                    objAllocation.Fabric4Details = "PRD:" + objAllocation.Fabric4Details;
                                    success = false;
                                    result = 0;
                                }

                                objAllocation.Quantity = Convert.ToInt32(reader["Quantity"]);
                                objAllocation.Mode = Convert.ToInt32(reader["Mode"]);
                                objAllocation.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                                objAllocation.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                                objAllocation.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;

                                objAllocation.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                                objAllocation.IsAllocated = (reader["IsAllocated"] != DBNull.Value) ? Convert.ToBoolean(reader["IsAllocated"]) : false;

                                objAllocation.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                                objAllocation.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                                objAllocation.IsRepeat = (reader["IsRepeat"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsRepeat"]);

                                objAllocation.PrevUnitId = (reader["PrevUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PrevUnitId"]);
                                objAllocation.PrevFactoryCode = (reader["PrevFactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrevFactoryCode"]);
                                objAllocation.PrevFactoryName = (reader["prevFactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["prevFactoryName"]);

                                objAllocation.Unit = new ProductionUnit();
                                objAllocation.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductionUnitId"]);
                                objAllocation.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);
                                objAllocation.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                                objAllocation.Unit.Capacity = (reader["Capacity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Capacity"]);

                                objAllocation.StitchingData = new StitchingDetail();
                                objAllocation.StitchingData.ID = (reader["StitchingDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StitchingDetailID"]);
                                objAllocation.StitchingData.CuttingReceived = (reader["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsIssued"]);
                                objAllocation.StitchingData.TotalPcsStitchedToday = (reader["TotalPcsStitchedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["TotalPcsStitchedToday"]);
                                objAllocation.StitchingData.OverallPcsStitched = (reader["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OverallPcsStitched"]);
                                objAllocation.StitchingData.PcsSent = (reader["PcsSent"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsSent"]);
                                objAllocation.StitchingData.PcsReceived = (reader["PcsReceived"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsReceived"]);

                                int PcsReceivedPack = 0;

                                if (objAllocation.StitchingData.PcsSent == 0)
                                {
                                    PcsReceivedPack = (reader["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OverallPcsStitched"]);
                                }
                                else
                                {
                                    PcsReceivedPack = (reader["PcsReceived"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsReceived"]);
                                }
                                objAllocation.StitchingData.PcsReceivedPack = PcsReceivedPack;
                                objAllocation.StitchingData.PcsPackedToday = (reader["PcsPackedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsPackedToday"]);
                                objAllocation.StitchingData.OverallPcsPacked = (reader["OverallPcsPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OverallPcsPacked"]);

                                objAllocation.ParentOrder = new Order();
                                objAllocation.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                                objAllocation.ParentOrder.WorkflowInstanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                                objAllocation.ParentOrder.WorkflowInstanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                                // edit by surendra on 3-sep-2013
                                //objAllocation.ParentOrder.WorkflowInstanceDetail.ischeckAllocationData = (reader["ischeckAllocationData"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ischeckAllocationData"]);
                                objAllocation.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                                objAllocation.ParentOrder.FabricInhouseHistory.Fabric1Percent = (reader["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse1"]);
                                objAllocation.ParentOrder.FabricInhouseHistory.Fabric2Percent = (reader["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse2"]);
                                objAllocation.ParentOrder.FabricInhouseHistory.Fabric3Percent = (reader["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse3"]);
                                objAllocation.ParentOrder.FabricInhouseHistory.Fabric4Percent = (reader["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse4"]);

                                objAllocation.ParentOrder.FabricInhouseHistory.PercentDate1 = (reader["Date1"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date1"]);
                                objAllocation.ParentOrder.FabricInhouseHistory.PercentDate2 = (reader["Date2"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date2"]);
                                objAllocation.ParentOrder.FabricInhouseHistory.PercentDate3 = (reader["Date3"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date3"]);
                                objAllocation.ParentOrder.FabricInhouseHistory.PercentDate4 = (reader["Date4"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date4"]);

                                objAllocation.ParentOrder.Fits = new Fits();
                                objAllocation.ParentOrder.Fits.StyleCode = (reader["StyleCode"] != DBNull.Value) ? Convert.ToString(reader["StyleCode"]) : "";
                                objAllocation.ParentOrder.Fits.StyleCodeVersion = (reader["StyleCodeVersion"] != DBNull.Value) ? Convert.ToString(reader["StyleCodeVersion"]) : string.Empty;
                                objAllocation.ParentOrder.Fits.SealDate = (reader["SealDate"] != DBNull.Value) ? Convert.ToDateTime(reader["SealDate"]) : DateTime.MinValue;

                                objAllocation.ParentOrder.Style = new Style();
                                objAllocation.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);

                                objAllocation.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                objAllocation.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                                objAllocation.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

                                objAllocation.ParentOrder.CuttingDetail = new CuttingDetail();
                                objAllocation.ParentOrder.CuttingDetail.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);
                                objAllocation.ParentOrder.CuttingDetail.PcsIssued = (reader["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsIssued"]);
                                objAllocation.ParentOrder.CuttingDetail.PercentagePcsCut = 0;

                                if (objAllocation.Quantity > 0)
                                {
                                    //updated by abhishek on 26/8/2015
                                    //objAllocation.ParentOrder.CuttingDetail.PercentagePcsCut = (objAllocation.ParentOrder.CuttingDetail.PcsCut * 100) / objAllocation.Quantity;
                                    objAllocation.ParentOrder.CuttingDetail.PercentagePcsCut = (int)Math.Round((objAllocation.ParentOrder.CuttingDetail.PcsCut * 100) / objAllocation.Quantity);
                                    //end
                                }
                               
                                string strx = "OrderDetailID =" + objAllocation.OrderDetailID;
                                string str = "OrderID =" + objAllocation.OrderID;
                                objAllocation.ParentOrder.AccessoryInHouseHistory = new AccessoryInHouseHistory();
                                
                                DataRow[] DataRows;
                                DataRows = dt1.Select(strx);
                                foreach (DataRow dr4 in DataRows)
                                {
                                    objAllocation.ParentOrder.AccessoryInHouseHistory.Date = (dr4["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr4["Date"]);
                                    objAllocation.ParentOrder.AccessoryInHouseHistory.PercentInHouse = (dr4["PercentInHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(dr4["PercentInHouse"]);
                                    objAllocation.ParentOrder.AccessoryInHouseHistory.AccessoryName = (dr4["AccessoryName"] == DBNull.Value) ? string.Empty : dr4["AccessoryName"].ToString();
                                    objAllocation.AccessoryHistory += objAllocation.ParentOrder.AccessoryInHouseHistory.AccessoryName + " " + objAllocation.ParentOrder.AccessoryInHouseHistory.PercentInHouse + "% on" + " " + objAllocation.ParentOrder.AccessoryInHouseHistory.Date.ToString("dd MMM yy (ddd)") + "<br/><br/>";

                                }
                                //}
                                DataRow[] DataRows2;
                                DataRows2 = dt2.Select(str);
                                foreach (DataRow dr5 in DataRows2)
                                {
                                    string AccessoryName = (dr5["AccessoryName"] == DBNull.Value) ? string.Empty : dr5["AccessoryName"].ToString();
                                    if (objAllocation.AccessoryHistory != null && objAllocation.AccessoryHistory != string.Empty)
                                    {
                                        if (objAllocation.AccessoryHistory.IndexOf(AccessoryName) == -1)
                                        {
                                            objAllocation.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                        }
                                    }
                                    else
                                    {
                                        objAllocation.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                    }

                                }


                                objAllocationCollection.Add(objAllocation);
                            }
                        }

                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return objAllocationCollection;
            }
        }


        public bool UpdateOrderDetailWithAllocationData(int[] orderDetailIds, int[] productionUnitIds, int[] allocatedIds)
        {
            if (orderDetailIds.Length != productionUnitIds.Length || orderDetailIds.Length != allocatedIds.Length || orderDetailIds.Length == 0)
                return false;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_order_detail_update_order_detail_with_allocation_data";

                    for (int i = 0; i < orderDetailIds.Length; i++)
                    {

                        if (productionUnitIds[i] <= 0)
                            continue;

                        SqlCommand cmd = new SqlCommand(cmdText, cnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        cmd.Transaction = transaction;

                        SqlParameter param;

                        param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                        param.Value = orderDetailIds[i];
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                        if (productionUnitIds[i] > 0)
                            param.Value = productionUnitIds[i];
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@AllocationDate", SqlDbType.Date);
                        param.Value = DateTime.Now.Date;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@sAllocated", SqlDbType.Bit);
                        param.Value = allocatedIds[i];
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return false;
        }

        public AllocationHistoryCollection GetAllocationHistory(int productionUnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                string cmdText = "sp_get_allocation_history";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                param.Value = productionUnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtAllocationHistory = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAllocationHistory);

                cnx.Close();

                AllocationHistoryCollection objAllocationHistoryCollection = ConvertDataTableToAllocationHistoryCollection(dtAllocationHistory);
                return objAllocationHistoryCollection;
            }
        }

        private AllocationHistoryCollection ConvertDataTableToAllocationHistoryCollection(DataTable dtAllocationHistory)
        {
            AllocationHistoryCollection objAllocationHistoryCollection = new AllocationHistoryCollection();
            AllocationHistory objAllocationHistory = null;

            foreach (DataRow dr in dtAllocationHistory.Rows)
            {
                objAllocationHistory = new AllocationHistory();

                objAllocationHistory.ProductionUnitId = (dr["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ProductionUnitId"]);
                objAllocationHistory.OrderDetailId = (dr["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OrderDetailId"]);
                objAllocationHistory.NumberOfContracts = (dr["NumberOfContracts"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["NumberOfContracts"]);
                objAllocationHistory.QuantityAll = (dr["QuantityAll"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["QuantityAll"]);
                objAllocationHistory.OverAllPcsStitched = (dr["OverAllPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OverAllPcsStitched"]);
                objAllocationHistory.BalanceOnMachine = (dr["BalanceOnMachine"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["BalanceOnMachine"]);
                objAllocationHistory.MonthName = (dr["MonthName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["MonthName"]);

                objAllocationHistoryCollection.Add(objAllocationHistory);
            }

            return objAllocationHistoryCollection;
        }

        public AllocationCollection GetAllocationSummary(DateTime AllocationDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                AllocationCollection objAllocationCollection = new AllocationCollection();

                string cmdText;

                try
                {
                    cmdText = "sp_get_allocation_summary";
                    cnx.Open();

                    SqlCommand cmd;

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@AllocationDate", SqlDbType.DateTime);
                    param.Value = AllocationDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsAllocationCollection = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsAllocationCollection);

                    if (dsAllocationCollection.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsAllocationCollection.Tables[0];


                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dt.Rows)
                            {

                                Allocation objAllocation = new Allocation();
                                objAllocation.OrderDetailID = Convert.ToInt32(reader["OrderDetailId"]);
                                objAllocation.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                                objAllocation.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                                objAllocation.OrderID = Convert.ToInt32(reader["OrderID"]);

                                objAllocation.Quantity = Convert.ToInt32(reader["Quantity"]);
                                objAllocation.Mode = Convert.ToInt32(reader["Mode"]);
                                objAllocation.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                                objAllocation.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                                objAllocation.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;

                                objAllocation.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                                objAllocation.IsAllocated = (reader["IsAllocated"] != DBNull.Value) ? Convert.ToBoolean(reader["IsAllocated"]) : false;

                                objAllocation.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                                objAllocation.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);

                                objAllocation.Unit = new ProductionUnit();
                                objAllocation.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ProductionUnitId"]);
                                objAllocation.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);
                                objAllocation.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                                objAllocation.Unit.Capacity = (reader["Capacity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Capacity"]);

                                objAllocation.ParentOrder = new Order();
                                objAllocation.ParentOrder.Fits = new Fits();
                                objAllocation.ParentOrder.Fits.SealDate = (reader["SealDate"] != DBNull.Value) ? Convert.ToDateTime(reader["SealDate"]) : DateTime.MinValue;

                                objAllocation.ParentOrder.Style = new Style();
                                objAllocation.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);

                                objAllocation.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                objAllocation.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                                objAllocation.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

                                objAllocation.ParentOrder.CuttingDetail = new CuttingDetail();
                                objAllocation.ParentOrder.CuttingDetail.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);
                                objAllocation.ParentOrder.CuttingDetail.PercentagePcsCut = 0;

                                if (objAllocation.Quantity > 0)
                                {
                                    objAllocation.ParentOrder.CuttingDetail.PercentagePcsCut = (int)Math.Round((objAllocation.ParentOrder.CuttingDetail.PcsCut * 100) / objAllocation.Quantity);
                                }

                                objAllocationCollection.Add(objAllocation);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return objAllocationCollection;
            }
        }


        public AllocationCollection AllocatedUnitData()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                AllocationCollection objAllocationCollection = new AllocationCollection();

                try
                {
                    string cmdText = "sp_send_production_email_body_containt";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Date", SqlDbType.DateTime);
                    param.Value = DateTime.Today.AddDays(-1);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsProductionContaint = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsProductionContaint);
                    if (dsProductionContaint.Tables.Count > 0)
                    {
                        if (dsProductionContaint.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtFactoryCode = dsProductionContaint.Tables[0];
                            DataTable dtPcsCutToday = dsProductionContaint.Tables[1];
                            DataTable dtPcsStitchedToday = dsProductionContaint.Tables[2];
                            DataTable dtBalofMach = dsProductionContaint.Tables[3];
                            DataTable dtPcsPackedToday = dsProductionContaint.Tables[4];
                            DataTable dtPcsExFactoriedToday = dsProductionContaint.Tables[5];
                            DataTable dtOverallPcsStitched = dsProductionContaint.Tables[6];

                            if (dtFactoryCode.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtFactoryCode.Rows)
                                {

                                    Allocation objAllocation = new Allocation();
                                    objAllocation.Unit = new ProductionUnit();
                                    objAllocation.StitchingData = new StitchingDetail();
                                    objAllocation.ParentOrder = new Order();
                                    objAllocation.ParentOrder.CuttingHistory = new CuttingHistory();
                                    objAllocation.ParentOrder.CuttingDetail = new CuttingDetail();

                                    objAllocation.Unit.ProductionUnitId = (dr["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ProductionUnitId"]);
                                    objAllocation.Unit.FactoryName = (dr["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryName"]);
                                    objAllocation.Unit.FactoryCode = (dr["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryCode"]);

                                    string strPcsCutToday = "UnitID =" + objAllocation.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsCut;
                                    DataRowPcsCut = dtPcsCutToday.Select(strPcsCutToday);
                                    if (DataRowPcsCut.Length > 0)
                                    {
                                        foreach (DataRow dr1 in DataRowPcsCut)
                                        {
                                            objAllocation.ParentOrder.CuttingHistory.Quantity = (dr1["TotalPcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(dr1["TotalPcsCut"]);

                                        }
                                    }
                                    else
                                    {

                                        objAllocation.ParentOrder.CuttingHistory.Quantity = 0;
                                    }

                                    string strPcsStitched = "UnitID =" + objAllocation.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsStitched;
                                    DataRowPcsStitched = dtPcsStitchedToday.Select(strPcsStitched);

                                    if (DataRowPcsStitched.Length > 0)
                                    {
                                        foreach (DataRow dr2 in DataRowPcsStitched)
                                        {
                                            objAllocation.StitchingData.TotalPcsStitchedToday = (dr2["TotalPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["TotalPcsStitched"]);
                                        }
                                    }
                                    else
                                    {
                                        objAllocation.StitchingData.TotalPcsStitchedToday = 0;
                                    }


                                    string strBalOfMach = "UnitID =" + objAllocation.Unit.ProductionUnitId;
                                    DataRow[] DataRowBalOfMech;
                                    DataRowBalOfMech = dtBalofMach.Select(strBalOfMach);

                                    if (DataRowBalOfMech.Length > 0)
                                    {
                                        foreach (DataRow dr3 in DataRowBalOfMech)
                                        {
                                            objAllocation.ParentOrder.CuttingDetail.PcsCut = (dr3["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(dr3["PcsCut"]);
                                            objAllocation.StitchingData.CuttingReceived = (dr3["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr3["PcsIssued"]);
                                        }
                                    }
                                    else
                                    {
                                        objAllocation.ParentOrder.CuttingDetail.PcsCut = 0;
                                        objAllocation.StitchingData.CuttingReceived = 0;
                                    }


                                    string strPcsPacked = "UnitID =" + objAllocation.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsPacked;
                                    DataRowPcsPacked = dtPcsPackedToday.Select(strPcsPacked);

                                    if (DataRowPcsPacked.Length > 0)
                                    {
                                        foreach (DataRow dr4 in DataRowPcsPacked)
                                        {
                                            objAllocation.StitchingData.PcsPackedToday = (dr4["TotalpcsPackedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr4["TotalpcsPackedToday"]);
                                        }
                                    }
                                    else
                                    {
                                        objAllocation.StitchingData.PcsPackedToday = 0;
                                    }


                                    string strPcsExFactoried = "UnitID =" + objAllocation.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsExFactoried;
                                    DataRowPcsExFactoried = dtPcsExFactoriedToday.Select(strPcsExFactoried);

                                    if (DataRowPcsExFactoried.Length > 0)
                                    {
                                        foreach (DataRow dr5 in DataRowPcsExFactoried)
                                        {
                                            objAllocation.Quantity = (dr5["TotalPcsExFactoriedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr5["TotalPcsExFactoriedToday"]);
                                        }
                                    }
                                    else
                                    {
                                        objAllocation.Quantity = 0;
                                    }

                                    string strOverallPcsStitchd = "UnitID =" + objAllocation.Unit.ProductionUnitId;
                                    DataRow[] DataRowOverallPcsStitchd;
                                    DataRowOverallPcsStitchd = dtOverallPcsStitched.Select(strOverallPcsStitchd);

                                    if (DataRowOverallPcsStitchd.Length > 0)
                                    {
                                        foreach (DataRow dr6 in DataRowOverallPcsStitchd)
                                        {
                                            objAllocation.StitchingData.OverallPcsStitched = (dr6["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr6["OverallPcsStitched"]);
                                            objAllocation.StitchingData.OverallPcsPacked = (dr6["OverallPcsPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(dr6["OverallPcsPacked"]);
                                        }
                                    }
                                    else
                                    {
                                        objAllocation.StitchingData.OverallPcsStitched = 0;
                                        objAllocation.StitchingData.OverallPcsPacked = 0;
                                    }

                                    objAllocationCollection.Add(objAllocation);
                                }

                            }
                        }
                    }
                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return objAllocationCollection;
            }
        }
        //Added by Abhishek On 8/6/2015
        //public DataTable GetClientnamrByID(int Id)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {

        //        cnx.Open();

        //        string cmdText = "Sp_getClient_Name";
        //        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param;

        //        param = new SqlParameter("@ClientId", SqlDbType.Int);
        //        param.Value = Id;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        DataTable ClientNames = new DataTable();
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);


        //        cnx.Close();


        //        return ClientNames;
        //    }

        //}

        //END



        #endregion


        //Added By Ashish on 8/11/2015
        public DataTable GetReAllocation() 
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "Usp_GetReAllocation";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    //SqlParameter param;
                    //param = new SqlParameter("@OperationId", SqlDbType.Int);
                    //param.Value = OperationId;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }
        public int UploadfileProductionUnit(int ProductionID, string fileName,string flag)
        {
            int Result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string text = "Usp_UpdatePrpductionUnit_FileUpload";
                SqlCommand cmd = new SqlCommand(text, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = ProductionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@fileName", SqlDbType.VarChar);
                param.Value = fileName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result=cmd.ExecuteNonQuery();
               
                cnx.Close();
            }

            return Result;
        }
        //added by abhishek 4/12/2015
        public int InserUpdateUserProduction(int Unitid, int Linedesignation, int UserId)
        {
            int Result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string text = "Usp_InserUpdateProductionUnit_User";
                SqlCommand cmd = new SqlCommand(text, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitID", SqlDbType.Int);
                param.Value = Unitid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = Linedesignation;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();

                cnx.Close();
            }

            return Result;
        }
        public DataTable GetSaveProductionDesignation(int unitid,int desiID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "Usp_GetSaveProductionDesignation";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@Unitid", SqlDbType.Int);
                    param.Value = unitid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@designationId", SqlDbType.Int);
                    param.Value = desiID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }
        //end by abhishek 4/12/2015

    }

}
