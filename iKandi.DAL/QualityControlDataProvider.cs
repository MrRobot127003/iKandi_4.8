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
    public class QualityControlDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public QualityControlDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insertion Methods

        public bool InsertQuality(QualityControl qualityControl)
        {
            //int intStatus = Convert.ToInt32(qualityControl.FaultsPP[0].Status);
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_quality_control_insert_quality_control";
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

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = qualityControl.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = qualityControl.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByQAManager", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByQAManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByQAManagerOn", SqlDbType.DateTime);
                    //if (qualityControl.ApprovedByQAManagerOn == DateTime.MinValue)
                    if ((qualityControl.ApprovedByQAManagerOn == DateTime.MinValue) || (qualityControl.ApprovedByQAManagerOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByQAManagerOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByQAManagerOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProcessingInstruction", SqlDbType.Int);
                    param.Value = qualityControl.ProcessingInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherInstruction", SqlDbType.VarChar);
                    param.Value = qualityControl.OtherInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //added by abhishek on 17/12/2015
                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //end by abhishek 17/12/2015


                    #region Gajendra Workflow
                    param = new SqlParameter("@ApprovedByClientHead", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByClientHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByClientHeadOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByClientHeadOn == DateTime.MinValue) || (qualityControl.ApprovedByClientHeadOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByClientHeadOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByClientHeadOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFactoryHead", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByFactoryHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFactoryHeadOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByFactoryHeadOn == DateTime.MinValue) || (qualityControl.ApprovedByFactoryHeadOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByFactoryHeadOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByFactoryHeadOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    #endregion

                    cmd.ExecuteNonQuery();

                    int qId = Convert.ToInt32(outParam.Value);

                    if (qId == -1)
                        return false;

                    qualityControl.Id = qId;
                    int s = 0;
                    if (qualityControl.Faults != null && qualityControl.Faults.Count > 0)
                        foreach (QualityFaults qFaults in qualityControl.Faults)
                        {
                            if (qFaults.Id == -1)
                            {
                                qFaults.ParentQualityControl.Id = qualityControl.Id;
                                int qFaultsId = InsertQualityFaults(qFaults, cnx, transaction, s);
                                qFaults.Id = qFaultsId;
                                s = s + 1;
                            }
                        }
                    int temp = 0;
                    if (qualityControl.Faults1 != null && qualityControl.Faults1.Count > 0)
                        foreach (QualityFaults qFaults1 in qualityControl.Faults1)
                        {
                            if (qFaults1.Id == -1)
                            {
                                qFaults1.ParentQualityControl.Id = qualityControl.Id;
                                int qFaults1Id = InsertQualityFaults(qFaults1, cnx, transaction, temp);
                                qFaults1.Id = qFaults1Id;
                                temp = temp + 1;
                            }
                        }

                    if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                        foreach (QualityFaults qFaultsPP in qualityControl.FaultsPP)
                        {
                            if (qFaultsPP.Id <= 0)
                            {
                                qFaultsPP.ParentQualityControl = new QualityControl();
                                qFaultsPP.ParentQualityControl.Id = qualityControl.Id;
                                int qFaultsPPId = InsertQualityFaultsPP(qFaultsPP, cnx, transaction);
                                qFaultsPP.Id = qFaultsPPId;

                                if (qFaultsPP.CheckingItems != null && qFaultsPP.CheckingItems.Count > 0)
                                    foreach (ItemsToCheck itemsToCheck in qFaultsPP.CheckingItems)
                                    {
                                        if (itemsToCheck.Id == -1)
                                        {
                                            itemsToCheck.ParentQualityControl.Id = qualityControl.Id;
                                            int qitemsToCheckId = InsertCheckingItems(itemsToCheck, cnx, transaction);
                                            itemsToCheck.Id = qitemsToCheckId;
                                        }
                                    }
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

        public int InsertQualityFaults(QualityFaults qualityFaults, SqlConnection cnx, SqlTransaction transaction, int intStatus)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_quality_control_fault_insert_quality_control_fault";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //SqlTransaction sqlTrans = cnx.BeginTransaction();

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@d", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@FaultID", SqlDbType.Int);
            param.Value = qualityFaults.FaultId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = qualityFaults.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //param = new SqlParameter("@Resolution", SqlDbType.VarChar);
            //param.Value = qualityFaults.Resolution;
            //param.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(param);

            param = new SqlParameter("@Owner", SqlDbType.Int);
            param.Value = qualityFaults.Owner;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sOnline", SqlDbType.Int);
            param.Value = qualityFaults.IsOnline;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Occurrence", SqlDbType.Int);
            param.Value = qualityFaults.Occurrence;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FaultType", SqlDbType.Int);
            param.Value = qualityFaults.FaultType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
            param.Value = qualityFaults.ProductionPlanningID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@TempStatus", SqlDbType.Int);
            param.Value = intStatus;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();

            int qFaultID = Convert.ToInt32(outParam.Value);

            return qFaultID;

        }

        public int InsertQualityFaultsPP(QualityFaults qualityFaults, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_quality_control_status_insert_quality_control_status";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //SqlTransaction sqlTrans = cnx.BeginTransaction();

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@d", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = qualityFaults.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
            param.Value = qualityFaults.ProductionPlanningID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DateConducted", SqlDbType.DateTime);
            // if (qualityFaults.DateConducted == DateTime.MinValue)
            if ((qualityFaults.DateConducted == DateTime.MinValue) || (qualityFaults.DateConducted == Convert.ToDateTime("1753-01-01")) || (qualityFaults.DateConducted == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = qualityFaults.DateConducted;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QA", SqlDbType.Int);
            param.Value = qualityFaults.QA;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActualSampleChecked", SqlDbType.Int);
            param.Value = qualityFaults.ActualSamplesChecked;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Value = Convert.ToInt32(qualityFaults.Status);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FailCount", SqlDbType.Int);
            if (qualityFaults.Status == "2")
                param.Value = 1;
            else
                param.Value = 0;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int qFaultID = Convert.ToInt32(outParam.Value);

            return qFaultID;

        }

        public int InsertCheckingItems(ItemsToCheck itemsToCheck, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_quality_control_checked_items_insert_checked_items";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            // SqlTransaction sqlTrans = cnx.BeginTransaction();

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@d", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@CheckingItem", SqlDbType.Int);
            param.Value = itemsToCheck.CheckingItem;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = itemsToCheck.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Missing", SqlDbType.Int);
            param.Value = itemsToCheck.Missing;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NotRequired", SqlDbType.Int);
            param.Value = itemsToCheck.NotRequired;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Present", SqlDbType.Int);
            param.Value = itemsToCheck.Present;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
            param.Value = itemsToCheck.ProductionPlanningID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);



            //NEW


            cmd.ExecuteNonQuery();

            int qCheckingId = Convert.ToInt32(outParam.Value);

            return qCheckingId;

        }

        //public string SaveQAStatusDetails(string ixml, int userID)
        //{
        //    return this.OrderDataProviderInstance.SaveQAStatusDetails(ixml, userID);
        //}

        public string SaveQAStatusDetails(string ixml, int orderdetailid, int styleid, int userID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string result = string.Empty;
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_QAStatus_save_xml";
                //cmdText = "sp_QAStatus_save_xml_test";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Xml", SqlDbType.VarChar);
                param.Size = 4000;
                param.Value = ixml;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@orderdetailid", SqlDbType.Int);
                param.Value = orderdetailid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@styleid", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = userID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                return "1";
            }
        }

        #endregion

        #region Get Methods

        //Add By Prabhaker 27/feb/18


        public DataSet GetReallocation_OutHouse_Emb(string Reallocation_OutHouse_Emb)
        {
            DataSet dsOutHouse_Emb = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Usp_GetOutHouseExcelReport";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Reallocation_OutHouse_Emb;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsOutHouse_Emb);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return dsOutHouse_Emb;
        }

        public DataSet GetReallocation_OutHouse(string Reallocation_OutHouse)
        {
            DataSet dsOutHouse_Emb = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Usp_GetOutHouseExcelReport";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Reallocation_OutHouse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsOutHouse_Emb);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return dsOutHouse_Emb;
        }
        //End of Code





        public QualityControl GetQualityControl(int orderDetailID, string InspectionID, int QualityControlID)
        {
            QualityControl qualityControl = new QualityControl();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_get_quality_control";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.Int);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = QualityControlID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsQuality);

                    if (dsQuality.Tables[0].Rows.Count > 0)
                    {
                        qualityControl = ConvertDataSetToQuality(dsQuality);
                    }
                    else
                    {
                        qualityControl.OrderDetail = new OrderDetail();
                        qualityControl.OrderDetail.OrderDetailID = 0;
                    }
                    if (dsQuality.Tables[5].Rows.Count > 0)
                    {
                        qualityControl.RiskRemarks = dsQuality.Tables[5].Rows[0][0].ToString();
                    }


                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl;
        }

        public DataSet GetQAStatus(int orderDetailID, int styleID)
        {
            DataSet dsQuality = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_get_qa_status";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = styleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsQuality);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return dsQuality;
        }

        public string GetQAStatusMO(int orderDetailID, int styleID)
        {
            string qualityStatus = string.Empty;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_get_qa_status_mo";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = styleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsQuality);
                    qualityStatus = Convert.ToString(dsQuality.Tables[0].Rows[0]["LastStatus"]);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return qualityStatus;
        }

        private QualityControl ConvertDataSetToQuality(DataSet dsQuality)
        {
            QualityControl qualityControl = new QualityControl();
            qualityControl.OrderDetail = new OrderDetail();
            qualityControl.OrderDetail.ParentOrder = new Order();
            qualityControl.OrderDetail.ParentOrder.Client = new Client();

            qualityControl.OrderDetail.ParentOrder.Style = new Style();
            qualityControl.OrderDetail.ParentOrder.Style.cdept = new ClientDepartment();
            qualityControl.Faults = new List<QualityFaults>();
            qualityControl.OrderDetail.OrderSizes = new List<OrderDetailSizes>();
            qualityControl.OrderDetail.Unit = new ProductionUnit();
            qualityControl.OrderDetail.InlinePPM = new InlinePPM();
            qualityControl.OrderDetail.InlinePPM.FactoryManager = new User();
            qualityControl.OrderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
            qualityControl.OrderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
            qualityControl.Category = new List<QualityFaultsCategory>();
            qualityControl.SubCategory = new List<QualityFaultsSubCategory>();


            DataTable dt = dsQuality.Tables[0];
            DataTable dtC = dsQuality.Tables[1];
            DataTable dtSubC = dsQuality.Tables[2];
            DataTable dtSampleQty = dsQuality.Tables[4];

            //if (dsQuality.Tables.Count > 0 && dtSampleQty != null && dtSampleQty.Rows.Count > 0)
            //{
            //    qualityControl.SampleQuantity = (dtSampleQty.Rows[0]["SampleQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dtSampleQty.Rows[0]["SampleQty"]);
            //    qualityControl.MajorDefectsAllowed = (dtSampleQty.Rows[0]["MajorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dtSampleQty.Rows[0]["MajorAllowed"]);
            //    qualityControl.MinorDefectsAllowed = (dtSampleQty.Rows[0]["MinorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dtSampleQty.Rows[0]["MinorAllowed"]);
            //    qualityControl.AqlValue = (dtSampleQty.Rows[0]["AQLType"] == DBNull.Value) ? String.Empty : Convert.ToString(dtSampleQty.Rows[0]["AQLType"]);
            //}
            //else
            //{
            //    qualityControl.SampleQuantity = 0;
            //    qualityControl.MajorDefectsAllowed = 0;
            //    qualityControl.MinorDefectsAllowed = 0;
            //    qualityControl.AqlValue = String.Empty;
            //}


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    QualityFaults qualityFaults = new QualityFaults();
                    qualityFaults.FaultId = (row["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Id"]);
                    qualityFaults.Fault = (row["Fault"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Fault"]);
                    qualityFaults.FaultType = (row["FaultType"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultType"]);
                    qualityFaults.FaultValue = qualityFaults.FaultId + "-" + qualityFaults.FaultType;
                    qualityFaults.QualityFaultsCategoryId = (row["CategoryID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["CategoryID"]);
                    qualityFaults.QualityFaultsSubCategoryId = (row["SubcategoryID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["SubcategoryID"]);
                    qualityFaults.FaultCategoryType = (row["CategoryType"] == DBNull.Value) ? String.Empty : Convert.ToString(row["CategoryType"]);
                    qualityFaults.FaultSubCategoryType = (row["SubcategoryType"] == DBNull.Value) ? String.Empty : Convert.ToString(row["SubcategoryType"]);
                    qualityControl.Faults.Add(qualityFaults);

                }
            }


            if (dtC.Rows.Count > 0)
            {
                foreach (DataRow row3 in dtC.Rows)
                {
                    QualityFaultsCategory qfc = new QualityFaultsCategory();
                    qfc.Id = (row3["CategoryID"] == DBNull.Value) ? 0 : Convert.ToInt32(row3["CategoryID"]);
                    qfc.FaultCategoryType = (row3["CategoryType"] == DBNull.Value) ? String.Empty : Convert.ToString(row3["CategoryType"]);
                    qualityControl.Category.Add(qfc);
                }
            }



            if (dtSubC.Rows.Count > 0)
            {
                foreach (DataRow row4 in dtSubC.Rows)
                {
                    QualityFaultsSubCategory qfsc = new QualityFaultsSubCategory();
                    qfsc.Id = (row4["SubCategoryID"] == DBNull.Value) ? 0 : Convert.ToInt32(row4["SubCategoryID"]);
                    qfsc.FaultSubCategoryType = (row4["SubcategoryType"] == DBNull.Value) ? String.Empty : Convert.ToString(row4["SubcategoryType"]);
                    qualityControl.SubCategory.Add(qfsc);
                }

            }

            DataTable dt1 = dsQuality.Tables[3];
            if (dt1.Rows.Count > 0)
            {
                DataRow row1 = dt1.Rows[0];
                qualityControl.OrderDetail.OrderID = (row1["OrderId"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["OrderId"]);
                qualityControl.OrderDetail.ParentOrder.Client.CompanyName = (row1["CompanyName"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["CompanyName"]);
                qualityControl.OrderDetail.ParentOrder.Client.ClientID = (row1["ClientId"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["ClientId"]);
                qualityControl.OrderDetail.ParentOrder.Style.cdept.Name = (row1["DepartmentName"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["DepartmentName"]);
                qualityControl.OrderDetail.DC = (row1["DC"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["DC"]);
                qualityControl.OrderDetail.ContractNumber = (row1["ContractNumber"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["ContractNumber"]);
                qualityControl.OrderDetail.ParentOrder.SerialNumber = (row1["SerialNumber"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["SerialNumber"]);
                qualityControl.OrderDetail.ParentOrder.Style.StyleNumber = (row1["StyleNumber"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["StyleNumber"]);
                qualityControl.OrderDetail.ParentOrder.Style.SampleImageURL1 = (row1["SampleImageURL1"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["SampleImageURL1"]);
                qualityControl.OrderDetail.ParentOrder.Style.StyleID = (row1["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["StyleID"]);
                qualityControl.OrderDetail.ParentOrder.Style.StyleCode = (row1["StyleNumber"] == DBNull.Value) ? "-1" : Constants.ExtractStyleCode(row1["StyleNumber"].ToString());
                qualityControl.OrderDetail.ParentOrder.Style.sCodeVersion = (row1["StyleCodeVersion"] == DBNull.Value) ? "-1" : Convert.ToString((row1["StyleCodeVersion"]).ToString());
                qualityControl.OrderDetail.ParentOrder.Description = (row1["Description"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["Description"]);
                qualityControl.OrderDetail.Quantity = (row1["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["Quantity"]);
                qualityControl.OrderDetail.Fabric1 = (row1["Fabric1"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["Fabric1"]);
                qualityControl.OrderDetail.Fabric1Details = (row1["Fabric1Details"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["Fabric1Details"]);
                qualityControl.OrderDetail.IsValid = (row1["IsValid"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["IsValid"]);
                qualityControl.OrderDetail.DepartmentID = (row1["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["DepartmentID"]);
                qualityControl.OrderDetail.TargetDateS = (row1["TargetDate"] == DBNull.Value) ? "" : row1["TargetDate"].ToString();
                qualityControl.OrderDetail.QA = (row1["QA"] == DBNull.Value) ? "" : row1["QA"].ToString();
                qualityControl.OrderDetail.ContractsCount = (row1["ContractsCount"] == DBNull.Value) ? "0" : row1["ContractsCount"].ToString();
                qualityControl.OrderDetail.IsShiped = (row1["IsShiped"] == DBNull.Value) ? false : Convert.ToBoolean(row1["IsShiped"]);
                qualityControl.OrderDetail.MissedfaultCount = (row1["missedfaultcount"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["missedfaultcount"]);
                qualityControl.OrderDetail.TotalOcuured = (row1["totalfaultoccured"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["totalfaultoccured"]);

                if (!string.IsNullOrEmpty(qualityControl.OrderDetail.Fabric1Details))
                {
                    string[] fd = qualityControl.OrderDetail.Fabric1Details.Trim().Split(new char[] { ' ' });

                    int printNo = 0;

                    if (fd.Length > 0 && fd[0].Length == 4 && int.TryParse(fd[0], out printNo))
                    {
                        qualityControl.OrderDetail.Fabric1Details = "PRD " + qualityControl.OrderDetail.Fabric1Details;
                    }

                }

                qualityControl.OrderDetail.LineItemNumber = (row1["LineItemNumber"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["LineItemNumber"]);
                qualityControl.OrderDetail.ExFactory = (row1["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["ExFactory"]);
                qualityControl.OrderDetail.Unit.FactoryCode = (row1["FactoryCode"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["FactoryCode"]);
                qualityControl.OrderDetail.InlinePPM.FactoryManager.FirstName = (row1["FirstName"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["FirstName"]);
                qualityControl.OrderDetail.InlinePPM.DateHeldOn = (row1["DateHeldOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row1["DateHeldOn"]);
                qualityControl.OrderDetail.InlinePPM.PPMRemarks = (row1["PPMRemarks"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["PPMRemarks"]);
                qualityControl.OrderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked = (row1["PercentPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PercentPacked"]);
                qualityControl.OrderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched = (row1["PercentStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["PercentStitched"]);
                qualityControl.OrderDetail.ParentOrder.StitchingDetail.OverallPcsStitched = (row1["Stitchedqty"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["Stitchedqty"]);
                qualityControl.OrderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (row1["Status"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["Status"]);
                qualityControl.OrderDetail.TotalPackages = (row1["TotalPackages"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["TotalPackages"]);
                qualityControl.OrderDetail.OrderDetailccgsm = (row1["Fabric11"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["Fabric11"]);
                qualityControl.OrderDetail.Unit.FactoryName = (row1["FactoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(row1["FactoryName"]);
                qualityControl.OrderDetail.Unit.ProductionUnitId = (row1["UnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["UnitId"]);
                //Add By Prabhaker 08/aug/18

                //End
            }
            //DataTable dt2 = dsQuality.Tables[5];
            //if (dt2.Rows.Count > 0)
            //{
            //    foreach (DataRow row in dt2.Rows)
            //    {
            //        OrderDetailSizes orderDetailSize = new OrderDetailSizes();
            //        orderDetailSize.OrderDetailID = Convert.ToInt32(row["OrderDetailID"]);
            //        orderDetailSize.Size = (row["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Size"]);
            //        orderDetailSize.Quantity = (row["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Quantity"]);
            //        qualityControl.OrderDetail.OrderSizes.Add(orderDetailSize);

            //    }
            //}

            return qualityControl;
        }

        public DataSet GetAuditChart(String AqlValue)
        {
            DataSet dsAuditChart = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_get_audit_chart";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@AqlValue", SqlDbType.VarChar);
                    param.Value = AqlValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsAuditChart);

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dsAuditChart;
        }



        private QualityControl ConvertDataSetToQualityByID(DataSet dsQuality)
        {
            //System.Diagnostics.Debugger.Break();
            QualityControl qualityControl = new QualityControl();
            qualityControl.OrderDetail = new OrderDetail();
            qualityControl.Faults = new List<QualityFaults>();
            qualityControl.Faults1 = new List<QualityFaults>();
            qualityControl.FaultsPP = new List<QualityFaults>();

            DataTable dt = dsQuality.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                qualityControl.Id = (row["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Id"]);
                qualityControl.OrderDetail.OrderDetailID = (row["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["OrderDetailID"]);
                //qualityControl.TotalBoxes = (row["TotalBoxes"] == DBNull.Value) ? 0 : Convert.ToInt32(row["TotalBoxes"]);
                //qualityControl.QA = (row["QA"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QA"]);
                //qualityControl.ActualSamplesChecked = (row["ActualSampleChecked"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ActualSampleChecked"]);
                //qualityControl.TotalMajorFaults = (row["TotalMajor"] == DBNull.Value) ? 0 : Convert.ToInt32(row["TotalMajor"]);
                //qualityControl.TotalMinorFaults = (row["TotalMinor"] == DBNull.Value) ? 0 : Convert.ToInt32(row["TotalMinor"]);
                //qualityControl.TotalCriticalFaults = (row["TotalCritical"] == DBNull.Value) ? 0 : Convert.ToInt32(row["TotalCritical"]);
                qualityControl.ApprovedByQAManager = (row["ApprovedByQAManager"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByQAManager"]);
                qualityControl.ApprovedByQAManagerOn = (row["ApprovedByQAManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByQAManagerOn"]);
                //qualityControl.DateConducted = (row["DateConducted"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["DateConducted"]);
                //qualityControl.Status = (row["Status"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Status"]);
                qualityControl.Comments = (row["Comments"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Comments"]);
                qualityControl.ProcessingInstruction = (row["ProcessingInstruction"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ProcessingInstruction"]);
                qualityControl.OtherInstruction = (row["OtherInstruction"] == DBNull.Value) ? String.Empty : Convert.ToString(row["OtherInstruction"]);
                //added by abhishek on 17/12/2015
                qualityControl.UserName = (row["FirstName"] == DBNull.Value) ? String.Empty : Convert.ToString(row["FirstName"]);
                //end by abhishek on 17/12/2015

                #region Gajendra Workflow
                qualityControl.ApprovedByClientHead = (row["ApprovedByClientHead"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByClientHead"]);
                qualityControl.ApprovedByClientHeadOn = (row["ApprovedByClientHeadOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByClientHeadOn"]);
                qualityControl.ApprovedByFactoryHead = (row["ApprovedByFactoryHead"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByFactoryHead"]);
                qualityControl.ApprovedByFactoryHeadOn = (row["ApprovedByFactoryHeadOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByFactoryHeadOn"]);
                #endregion
            }

            DataTable dt1 = dsQuality.Tables[1];
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    QualityFaults qualityFaults = new QualityFaults();
                    qualityFaults.ParentQualityControl = new QualityControl();
                    qualityFaults.Id = (row["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Id"]);
                    qualityFaults.ParentQualityControl.Id = (row["QualityControlID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QualityControlID"]);
                    qualityFaults.FaultId = (row["FaultID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultID"]);
                    qualityFaults.Resolution = (row["Resolution"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Resolution"]);
                    qualityFaults.Owner = (row["Owner"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Owner"]);
                    qualityFaults.IsOnline = (row["IsOnline"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IsOnline"]);
                    qualityFaults.Occurrence = (row["Occurrence"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Occurrence"]);
                    qualityFaults.FaultType = (row["FaultType"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultType"]);
                    qualityFaults.FaultValue = qualityFaults.FaultId + "-" + qualityFaults.FaultType;
                    qualityFaults.ProductionPlanningID = (row["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ProductionPlanningID"]);
                    if (qualityFaults.IsOnline == 1)
                        qualityControl.Faults.Add(qualityFaults);
                    else if (qualityFaults.IsOnline == 0)
                        qualityControl.Faults1.Add(qualityFaults);
                }
            }

            DataTable dt2 = dsQuality.Tables[2];
            DataTable dt3 = dsQuality.Tables[3];
            if (dt2.Rows.Count > 0 && dt3.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow dr in dt2.Rows)
                {
                    string strx = "ProductionPlanningID =" + dr["ProductionPlanningID"];
                    DataRow[] faultRows;
                    faultRows = dt3.Select(strx);
                    int c = faultRows.Count();
                    if (c > 0)
                    {
                        foreach (DataRow row in dt3.Rows)
                        {
                            QualityFaults qualityFaults = new QualityFaults();
                            if (((row["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ProductionPlanningID"])) == ((dr["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ProductionPlanningID"])))
                            {
                                qualityFaults.ParentQualityControl = new QualityControl();
                                qualityFaults.CheckingItems = new List<ItemsToCheck>();
                                qualityFaults.SizesList = new List<OrderDetailSizes>();

                                qualityFaults.ParentQualityControl = new QualityControl();
                                qualityFaults.Id = (row["QCPartID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QCPartID"]);
                                qualityFaults.ParentQualityControl.Id = (row["QualityControlID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QualityControlID"]);
                                qualityFaults.FaultId = (row["FaultID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultID"]);
                                qualityFaults.Resolution = (row["Resolution"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Resolution"]);
                                qualityFaults.Owner = (row["Owner"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Owner"]);
                                qualityFaults.IsOnline = (row["IsOnline"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IsOnline"]);
                                qualityFaults.Occurrence = (row["Occurrence"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Occurrence"]);
                                qualityFaults.FaultType = (row["FaultType"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultType"]);
                                qualityFaults.FaultValue = qualityFaults.FaultId + "-" + qualityFaults.FaultType;
                                qualityFaults.ProductionPlanningID = (row["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ProductionPlanningID"]);
                                //qualityFaults.ShippingQty = (dt3.Rows[j]["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dt3.Rows[j]["ShippingQty"]);
                                //qualityFaults.IsPartShipment = (dt3.Rows[j]["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(dt3.Rows[j]["IsPartShipment"]) : false;
                                qualityFaults.ShippingQty = (row["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ShippingQty"]);
                                qualityFaults.IsPartShipment = (row["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(row["IsPartShipment"]) : false;
                                qualityFaults.ActualSamplesChecked = (row["ActualSampleChecked"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ActualSampleChecked"]);
                                qualityFaults.DateConducted = (row["DateConducted"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["DateConducted"]);
                                qualityFaults.Status = (row["Status"] == DBNull.Value || (Convert.ToInt32(row["Status"]) == 0)) ? String.Empty : ((Convert.ToInt32(row["Status"]) == 1) ? "PASS" : "FAIL");
                                qualityFaults.QA = (row["QA"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QA"]);

                                DataTable dt4 = dsQuality.Tables[4];
                                if (dt4 != null && dt4.Rows.Count > 0 && i <= dt4.Rows.Count)
                                {
                                    qualityFaults.SampleQuantity = (dt4.Rows[i]["SampleQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["SampleQty"]);
                                    qualityFaults.MajorDefectsAllowed = (dt4.Rows[i]["MajorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MajorAllowed"]);
                                    qualityFaults.MinorDefectsAllowed = (dt4.Rows[i]["MinorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MinorAllowed"]);
                                    qualityFaults.AqlValue = (dt4.Rows[i]["AQLType"] == DBNull.Value) ? String.Empty : Convert.ToString(dt4.Rows[i]["AQLType"]);
                                }

                                qualityFaults.CheckingItems = GetCheckingItems(qualityFaults.ParentQualityControl.Id, qualityFaults.ProductionPlanningID);
                                qualityFaults.SizesList = GetSizesForPart(qualityFaults.ParentQualityControl.Id, qualityFaults.ProductionPlanningID);

                                qualityControl.FaultsPP.Add(qualityFaults);

                            }
                           
                        }
                    }
                    else
                    {
                        QualityFaults qualityFaults = new QualityFaults();
                        qualityFaults.ParentQualityControl = new QualityControl();
                        qualityFaults.CheckingItems = new List<ItemsToCheck>();
                        qualityFaults.SizesList = new List<OrderDetailSizes>();

                        qualityFaults.ParentQualityControl = new QualityControl();
                        qualityFaults.Id = (dr["FaultsPPID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["FaultsPPID"]);
                        qualityFaults.ParentQualityControl.Id = 0;
                        qualityFaults.FaultId = -1;
                        qualityFaults.Resolution = String.Empty;
                        qualityFaults.Owner = 0;
                        qualityFaults.IsOnline = 0;
                        qualityFaults.Occurrence = 0;
                        qualityFaults.FaultType = 0;
                        qualityFaults.FaultValue = "-1";
                        qualityFaults.ProductionPlanningID = (dr["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ProductionPlanningID"]);
                        qualityFaults.ShippingQty = (dr["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ShippingQty"]);
                        qualityFaults.IsPartShipment = (dr["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(dr["IsPartShipment"]) : false;
                        qualityFaults.ActualSamplesChecked = 0;
                        qualityFaults.DateConducted = DateTime.MinValue;
                        qualityFaults.Status = (dr["Status"] == DBNull.Value || (Convert.ToInt32(dr["Status"]) == 0)) ? String.Empty : ((Convert.ToInt32(dr["Status"]) == 1) ? "PASS" : "FAIL");
                        qualityFaults.QA = 0;

                        DataTable dt4 = dsQuality.Tables[4];
                        if (dt4 != null && dt4.Rows.Count > 0 && i < dt4.Rows.Count)
                        {
                            qualityFaults.SampleQuantity = (dt4.Rows[i]["SampleQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["SampleQty"]);
                            qualityFaults.MajorDefectsAllowed = (dt4.Rows[i]["MajorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MajorAllowed"]);
                            qualityFaults.MinorDefectsAllowed = (dt4.Rows[i]["MinorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MinorAllowed"]);
                            qualityFaults.AqlValue = (dt4.Rows[i]["AQLType"] == DBNull.Value) ? String.Empty : Convert.ToString(dt4.Rows[i]["AQLType"]);
                        }

                        qualityFaults.CheckingItems = GetCheckingItems(qualityFaults.ParentQualityControl.Id, qualityFaults.ProductionPlanningID);
                        qualityFaults.SizesList = GetSizesForPart(qualityFaults.ParentQualityControl.Id, qualityFaults.ProductionPlanningID);

                        qualityControl.FaultsPP.Add(qualityFaults);

                    }
                    i++;
                }
            }
            else if (dt3.Rows.Count == 0)
            {
                foreach (DataRow row2 in dt2.Rows)
                {
                    int i = 0;
                    QualityFaults qualityFaults = new QualityFaults();
                    qualityFaults.ParentQualityControl = new QualityControl();
                    qualityFaults.CheckingItems = new List<ItemsToCheck>();
                    qualityFaults.SizesList = new List<OrderDetailSizes>();

                    qualityFaults.ParentQualityControl = new QualityControl();
                    qualityFaults.Id = (row2["FaultsPPID"] == DBNull.Value) ? 0 : Convert.ToInt32(row2["FaultsPPID"]);
                    qualityFaults.ParentQualityControl.Id = 0;
                    qualityFaults.FaultId = -1;
                    qualityFaults.Resolution = String.Empty;
                    qualityFaults.Owner = 0;
                    qualityFaults.IsOnline = 0;
                    qualityFaults.Occurrence = 0;
                    qualityFaults.FaultType = 0;
                    qualityFaults.FaultValue = "-1";
                    qualityFaults.ProductionPlanningID = (row2["ProductionPlanningID"] == DBNull.Value) ? 0 : Convert.ToInt32(row2["ProductionPlanningID"]);
                    qualityFaults.ShippingQty = (row2["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(row2["ShippingQty"]);
                    qualityFaults.IsPartShipment = (row2["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(row2["IsPartShipment"]) : false;
                    qualityFaults.ActualSamplesChecked = 0;
                    qualityFaults.DateConducted = DateTime.MinValue;
                    qualityFaults.Status = (row2["Status"] == DBNull.Value || (Convert.ToInt32(row2["Status"]) == 0)) ? String.Empty : ((Convert.ToInt32(row2["Status"]) == 1) ? "PASS" : "FAIL");
                    qualityFaults.QA = 0;

                    DataTable dt4 = dsQuality.Tables[4];
                    if (dt4 != null && dt4.Rows.Count > 0 && i < dt4.Rows.Count)
                    {
                        qualityFaults.SampleQuantity = (dt4.Rows[i]["SampleQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["SampleQty"]);
                        qualityFaults.MajorDefectsAllowed = (dt4.Rows[i]["MajorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MajorAllowed"]);
                        qualityFaults.MinorDefectsAllowed = (dt4.Rows[i]["MinorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MinorAllowed"]);
                        qualityFaults.AqlValue = (dt4.Rows[i]["AQLType"] == DBNull.Value) ? String.Empty : Convert.ToString(dt4.Rows[i]["AQLType"]);
                    }

                    qualityFaults.CheckingItems = GetCheckingItems(qualityFaults.ParentQualityControl.Id, qualityFaults.ProductionPlanningID);
                    qualityFaults.SizesList = GetSizesForPart(qualityFaults.ParentQualityControl.Id, qualityFaults.ProductionPlanningID);

                    qualityControl.FaultsPP.Add(qualityFaults);
                    i++;
                }
            }

            return qualityControl;

        }

        public List<ItemsToCheck> GetCheckingItems(int qid, int ppid)
        {
            QualityControlStatus qualityControl = new QualityControlStatus();
            qualityControl.CheckingItems = new List<ItemsToCheck>();
            iKandi.Common.ItemsToCheck itemTochk = new ItemsToCheck();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_checked_items_get_checked_items_by_id";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = qid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                    param.Value = ppid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsQuality);

                    if (dsQuality.Tables[0].Rows.Count > 0)
                    {
                        qualityControl.CheckingItems = ConvertDataSetToCheckingItem(dsQuality);
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl.CheckingItems;
        }

        private List<ItemsToCheck> ConvertDataSetToCheckingItem(DataSet dsQuality)
        {
            QualityFaults qualityControl = new QualityFaults();
            qualityControl.CheckingItems = new List<ItemsToCheck>();

            DataTable dt1 = dsQuality.Tables[0];
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    ItemsToCheck iToChk = new ItemsToCheck();
                    iToChk.ParentQualityControl = new QualityControl();
                    iToChk.Id = (row["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Id"]);
                    iToChk.Missing = (row["Missing"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Missing"]);
                    iToChk.NotRequired = (row["NotRequired"] == DBNull.Value) ? 0 : Convert.ToInt32(row["NotRequired"]);
                    iToChk.Present = (row["Present"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Present"]);
                    iToChk.CheckingItem = (row["CheckingItem"] == DBNull.Value) ? 0 : Convert.ToInt32(row["CheckingItem"]);
                    qualityControl.CheckingItems.Add(iToChk);
                }
            }

            return qualityControl.CheckingItems;
        }

        public List<OrderDetailSizes> GetSizesForPart(int QualityControlID, int ProductionPlanningID)
        {
            List<OrderDetailSizes> ordSizes = new List<OrderDetailSizes>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_sizes_get_sizes_for_part";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = QualityControlID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                    param.Value = ProductionPlanningID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsSizes = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsSizes);

                    if (dsSizes.Tables[0].Rows.Count > 0)
                    {
                        ordSizes = ConvertDataSetToSizes(dsSizes);
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return ordSizes;
        }

        private List<OrderDetailSizes> ConvertDataSetToSizes(DataSet dsSizes)
        {
            List<OrderDetailSizes> sizes = new List<OrderDetailSizes>();

            DataTable dt1 = dsSizes.Tables[0];
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    OrderDetailSizes size = new OrderDetailSizes();
                    size.Size = (row["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Size"]);
                    size.Quantity = (row["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Quantity"]);
                    sizes.Add(size);
                }
            }

            return sizes;
        }

        public DataSet GetEmail(string owner)
        {
            DataSet dsOwner = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_get_email_of_qa_owners";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@Owner", SqlDbType.VarChar);
                    param.Value = owner;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsOwner);


                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dsOwner;
        }

        public List<QualityFaultsCategory> GetQualityFaultCategories()
        {
            List<QualityFaultsCategory> qualityFaultsCategories = new List<QualityFaultsCategory>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_inspection_category_get_all_inspection_categories";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        QualityFaultsCategory qualityFaultsCategory = new QualityFaultsCategory();
                        qualityFaultsCategory.Id = (reader["CategoryID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CategoryID"]);
                        qualityFaultsCategory.FaultCategoryType = (reader["CategoryType"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["CategoryType"]);
                        qualityFaultsCategories.Add(qualityFaultsCategory);

                    }
                }
            }
            return qualityFaultsCategories;

        }

        public DataTable GetQualityFaultSubCategories()
        {
            DataSet dsSubCategories = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_inspection_sub_category_get_all_sub_categories";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsSubCategories);


                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dsSubCategories.Tables[0];
        }

        #endregion

        #region Updation Methods

        public bool UpdateQuality(QualityControl qualityControl)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                int intStatus = Convert.ToInt32(qualityControl.FaultsPP[0].Status);
                try
                {
                    string cmdText = "sp_quality_control_update_quality_control";
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = qualityControl.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = qualityControl.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByQAManager", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByQAManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByQAManagerOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByQAManagerOn == DateTime.MinValue) || (qualityControl.ApprovedByQAManagerOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByQAManagerOn == Convert.ToDateTime("1900-01-01")))
                    //if (qualityControl.ApprovedByQAManagerOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = qualityControl.ApprovedByQAManagerOn;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProcessingInstruction", SqlDbType.Int);
                    param.Value = qualityControl.ProcessingInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherInstruction", SqlDbType.VarChar);
                    param.Value = qualityControl.OtherInstruction == null ? "" : qualityControl.OtherInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    //added by abhoshek on 17/12/2015

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //End by abhishek on 17/12/2015

                    #region Gajendra Workflow
                    param = new SqlParameter("@ApprovedByClientHead", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByClientHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByClientHeadOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByClientHeadOn == DateTime.MinValue) || (qualityControl.ApprovedByClientHeadOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByClientHeadOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByClientHeadOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFactoryHead", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByFactoryHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFactoryHeadOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByFactoryHeadOn == DateTime.MinValue) || (qualityControl.ApprovedByFactoryHeadOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByFactoryHeadOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByFactoryHeadOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    #endregion

                    cmd.ExecuteNonQuery();
                    int s = 0;
                    foreach (QualityFaults qFaults in qualityControl.Faults)
                    {
                        if (qFaults.Id > 0 && qFaults.IsDeleted == 0)
                        {
                            UpdateQualityFaults(qFaults, cnx, transaction, s);
                        }
                        else if (qFaults.Id == -1 && qFaults.IsDeleted == 0)
                        {
                            if (qualityControl.Faults != null && qualityControl.Faults.Count > 0)
                            {
                                foreach (QualityFaults qFaultsInsert in qualityControl.Faults)
                                {
                                    if (qFaultsInsert.Id == -1)
                                    {
                                        qFaultsInsert.ParentQualityControl.Id = qualityControl.Id;
                                        int qFaultsId = InsertQualityFaults(qFaultsInsert, cnx, transaction, s);
                                        qFaultsInsert.Id = qFaultsId;
                                        s = s + 1;
                                    }
                                }
                            }
                        }
                        else if (qFaults.IsDeleted == 1)
                        {
                            DeleteQualityFaults(qFaults, cnx, transaction);
                        }
                        s = s + 1;
                    }
                    int intTemp = 0;
                    foreach (QualityFaults qFaults1 in qualityControl.Faults1)
                    {

                        if (qFaults1.Id > 0 && qFaults1.IsDeleted == 0)
                        {
                            UpdateQualityFaults(qFaults1, cnx, transaction, intTemp);
                        }
                        else if (qFaults1.Id == -1 && qFaults1.IsDeleted == 0)
                        {
                            if (qualityControl.Faults1 != null && qualityControl.Faults1.Count > 0)
                            {
                                foreach (QualityFaults qFaults1Insert in qualityControl.Faults1)
                                {
                                    if (qFaults1Insert.Id == -1)
                                    {
                                        qFaults1Insert.ParentQualityControl.Id = qualityControl.Id;
                                        int qFaults1Id = InsertQualityFaults(qFaults1Insert, cnx, transaction, intTemp);
                                        qFaults1Insert.Id = qFaults1Id;
                                        intTemp = intTemp + 1;
                                    }
                                }
                            }
                        }
                        else if (qFaults1.IsDeleted == 1)
                        {
                            DeleteQualityFaults(qFaults1, cnx, transaction);
                        }
                        intTemp = intTemp + 1;
                    }

                    foreach (QualityFaults qFaultsPP in qualityControl.FaultsPP)
                    {
                        if (qFaultsPP.Id > 0)
                        {
                            qFaultsPP.ParentQualityControl = new QualityControl();
                            qFaultsPP.ParentQualityControl.Id = qualityControl.Id;
                            UpdateQualityFaultsPP(qFaultsPP, cnx, transaction, intStatus);
                            if (qFaultsPP.CheckingItems != null && qFaultsPP.CheckingItems.Count > 0)
                                foreach (ItemsToCheck itemsToCheck in qFaultsPP.CheckingItems)
                                {
                                    if (itemsToCheck.Id != -1)
                                    {
                                        UpdateCheckingItems(itemsToCheck, cnx, transaction);
                                    }
                                }
                        }
                        else if (qFaultsPP.Id <= 0)
                        {
                            qFaultsPP.ParentQualityControl = new QualityControl();
                            qFaultsPP.ParentQualityControl.Id = qualityControl.Id;
                            int qFaultsPPId = InsertQualityFaultsPP(qFaultsPP, cnx, transaction);
                            qFaultsPP.Id = qFaultsPPId;

                            if (qFaultsPP.CheckingItems != null && qFaultsPP.CheckingItems.Count > 0)
                                foreach (ItemsToCheck itemsToCheck in qFaultsPP.CheckingItems)
                                {
                                    if (itemsToCheck.Id == -1)
                                    {
                                        itemsToCheck.ParentQualityControl.Id = qualityControl.Id;
                                        int qitemsToCheckId = InsertCheckingItems(itemsToCheck, cnx, transaction);
                                        itemsToCheck.Id = qitemsToCheckId;
                                    }
                                }
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

        public bool UpdateQualityFaults(QualityFaults qualityFaults, SqlConnection cnx, SqlTransaction transaction, int intStatus)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_quality_control_fault_update_quality_control_fault";
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //SqlTransaction sqlTrans = cnx.BeginTransaction();

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@d", SqlDbType.Int);
            param.Value = qualityFaults.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FaultID", SqlDbType.Int);
            param.Value = qualityFaults.FaultId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = qualityFaults.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //param = new SqlParameter("@Resolution", SqlDbType.VarChar);
            //param.Value = qualityFaults.Resolution;
            //param.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(param);

            param = new SqlParameter("@Owner", SqlDbType.Int);
            param.Value = qualityFaults.Owner;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sOnline", SqlDbType.Int);
            param.Value = qualityFaults.IsOnline;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Occurrence", SqlDbType.Int);
            param.Value = qualityFaults.Occurrence;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FaultType", SqlDbType.Int);
            param.Value = qualityFaults.FaultType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
            param.Value = qualityFaults.ProductionPlanningID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Value = intStatus;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //NEW 






            cmd.ExecuteNonQuery();

            return true;

        }

        public bool UpdateQualityFaultsPP(QualityFaults qualityFaults, SqlConnection cnx, SqlTransaction transaction, int intStatus)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_quality_control_status_update_quality_control_status";

                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                //SqlTransaction sqlTrans = cnx.BeginTransaction();

                SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = qualityFaults.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                param.Value = qualityFaults.ParentQualityControl.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Value = qualityFaults.ProductionPlanningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateConducted", SqlDbType.DateTime);
                if ((qualityFaults.DateConducted == DateTime.MinValue) || (qualityFaults.DateConducted == Convert.ToDateTime("1753-01-01")) || (qualityFaults.DateConducted == Convert.ToDateTime("1900-01-01")))
                // if (qualityFaults.DateConducted == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = qualityFaults.DateConducted;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QA", SqlDbType.Int);
                param.Value = qualityFaults.QA;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActualSampleChecked", SqlDbType.Int);
                param.Value = qualityFaults.ActualSamplesChecked;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = Convert.ToInt32(qualityFaults.Status);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return true;

        }

        public bool UpdateCheckingItems(ItemsToCheck itemsToCheck, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_quality_control_checked_items_update_checked_items";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //SqlTransaction sqlTrans = cnx.BeginTransaction();

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@d", SqlDbType.Int);
            param.Value = itemsToCheck.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CheckingItem", SqlDbType.Int);
            param.Value = itemsToCheck.CheckingItem;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = itemsToCheck.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Missing", SqlDbType.Int);
            param.Value = itemsToCheck.Missing;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NotRequired", SqlDbType.Int);
            param.Value = itemsToCheck.NotRequired;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Present", SqlDbType.Int);
            param.Value = itemsToCheck.Present;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
            param.Value = itemsToCheck.ProductionPlanningID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);



            cmd.ExecuteNonQuery();

            return true;

        }


        #endregion


        public bool DeleteQualityFaults(QualityFaults qFaults, SqlConnection cnx, SqlTransaction transaction)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_quality_control_fault_delete_quality_control_fault";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //SqlTransaction sqlTrans = cnx.BeginTransaction();

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@d", SqlDbType.Int);
            param.Value = qFaults.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();


            return true;

        }



        public DataTable GetQualityControlSatatusFailData(int ProductionPlanningID) // newly added
        {
            DataSet dsQCStatus = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_quality_control_get_status_fail_email_content";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Value = ProductionPlanningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsQCStatus);

            }

            return dsQCStatus.Tables[0];
        }

        public DataTable GetAllAqlStanderdDAL(int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsAql = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_all_Aql_Standard";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsAql);
                return (dsAql.Tables[0]);

            }

        }

        public DataTable GetAllAqlExistingStanderdDAL(double AQLType, double DoubleNewAQL)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsAql = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_all_Existing_Aql_Standard";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@AQLType", SqlDbType.Float);
                param.Value = AQLType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@NewAQL", SqlDbType.Float);
                param.Value = DoubleNewAQL;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsAql);
                return (dsAql.Tables[0]);

            }

        }

        public void InserNewAQLDAL(string stringXMLDataAQL)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();


                string cmdText = "sp_insert_New_AQL";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Xml", SqlDbType.VarChar);
                param.Value = stringXMLDataAQL;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }
        //added by abhishek on 11/5/2016
        public int InserNewAQLMidInLineDAL(int SampleSize, int MajorDefectsPass, int MajorDefectsFail, int MinorDefectsPass, int MinorDefectsFail, string AQLtype)
        {
            int result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();


                string cmdText = "Usp_InsertUpdateAQLType";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SampleSize", SqlDbType.Int);
                param.Value = SampleSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MajorDefectsPass", SqlDbType.Int);
                param.Value = MajorDefectsPass;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MajorDefectsFail", SqlDbType.Int);
                param.Value = MajorDefectsFail;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@MinorDefectsPass", SqlDbType.Int);
                param.Value = MinorDefectsPass;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MinorDefectsFail", SqlDbType.Int);
                param.Value = MinorDefectsFail;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AQLtype", SqlDbType.VarChar);
                param.Value = AQLtype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
            }
            return result;


        }

        public DataTable GetAllAqlExistingStanderdMINLINEDAL(string AQLType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsAql = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_all_Existing_Aql_MID_Line";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@AQLType", SqlDbType.VarChar);
                param.Value = AQLType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsAql);
                return (dsAql.Tables[0]);

            }

        }
        //end by abhishek 

        public QualityControl GetQualityControlHistoryDAL(int orderDetailID)
        {
            QualityControl qualityControl = new QualityControl();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_get_quality_control_history";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsQuality);

                    if (dsQuality.Tables[0].Rows.Count > 0)
                    {
                        qualityControl = ConvertDataSetToQuality(dsQuality);
                    }
                    else
                    {
                        qualityControl.OrderDetail = new OrderDetail();
                        qualityControl.OrderDetail.OrderDetailID = 0;
                    }



                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl;
        }

        public QualityControl GetQualityControlByID(int orderDetailID)
        {
            QualityControl qualityControl = new QualityControl();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_get_quality_control_by_id";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsQuality);

                    if (dsQuality.Tables.Count > 0)
                    {
                        qualityControl = ConvertDataSetToQualityByID(dsQuality);
                    }
                    else
                    {
                        qualityControl.OrderDetail = new OrderDetail();
                        qualityControl.OrderDetail.OrderDetailID = 0;
                    }

                    //int qid = qualityControl.Id;
                    //qualityControl.CheckingItems = GetCheckingItems(qid);

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl;
        }





        public QualityControl GetQualityControlByIDHistoryDAL(int orderDetailID)
        {
            QualityControl qualityControl = new QualityControl();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "spQualityControlGetQualityControlByIdHistory";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsQuality);

                    if (dsQuality.Tables.Count > 0)
                    {
                        qualityControl = ConvertDataSetToQualityByID(dsQuality);
                    }
                    else
                    {
                        qualityControl.OrderDetail = new OrderDetail();
                        qualityControl.OrderDetail.OrderDetailID = 0;
                    }

                    //int qid = qualityControl.Id;
                    //qualityControl.CheckingItems = GetCheckingItems(qid);

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl;
        }

        public void InsertFinalAuditAndQualityAssuranceDAL(string[] stringFianalAudit, int ProductionId, string stringXML, int intQualitycontrolID, double AQLType, string FaultRepoting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {


                try
                {
                    string cmdText = "sp_Insert_FinalAudit_And_QualityAssurance";
                    cnx.Open();



                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    SqlParameter param;

                    param = new SqlParameter("@DateConducted", SqlDbType.VarChar);
                    param.Value = stringFianalAudit[0].ToString();
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QTY", SqlDbType.Int);
                    param.Value = Convert.ToInt32(stringFianalAudit[1]);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AQLSampleQTY", SqlDbType.Int);
                    param.Value = Convert.ToInt32(stringFianalAudit[2]);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ActualChecked", SqlDbType.Int);
                    param.Value = Convert.ToInt32(stringFianalAudit[3]);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QA", SqlDbType.VarChar);
                    param.Value = stringFianalAudit[4].ToString();
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionID", SqlDbType.Int);
                    param.Value = ProductionId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stringXML", SqlDbType.VarChar);
                    param.Value = stringXML;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlID", SqlDbType.VarChar);
                    param.Value = intQualitycontrolID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@AQLType", SqlDbType.Float);
                    param.Value = AQLType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stringFaultReporting", SqlDbType.VarChar);
                    param.Value = FaultRepoting;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);




                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }


        }

        public DataSet GET_FinalAuditAndQualityAssuranceDAL(int intOrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataSet dsQAHistory = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_QA_History";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.VarChar);
                param.Value = intOrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsQAHistory);
                return (dsQAHistory);
            }


        }

        public string GetPriviousAQLDAL(int intOrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataSet dsQAHistory = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                string str = "";
                cmdText = "sp_Get_Previous_AQL";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param1;
                param1 = new SqlParameter("@oPreviousAQL", SqlDbType.VarChar, 50);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);

                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = intOrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                // retrives the value of the autogenerated id of the category
                if (param1.Value != DBNull.Value)
                {
                    str = Convert.ToString(param1.Value);
                }
                else
                {
                    str = "";
                }
                cnx.Close();

                return str;


            }


        }
        public DataSet GetQCUserComments(int styleid, string flag)
        {
            DataSet DScomments = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Usp_GetQCUserComments";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@Styleid", SqlDbType.VarChar);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(DScomments);


                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return DScomments;
        }




        public DataSet GetQCLineMan(int OrderDetailID, int QualityControlID)
        {
            DataSet DSLineManQc = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quality_control_get_LineMan_Qc";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlId", SqlDbType.Int);
                    param.Value = QualityControlID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(DSLineManQc);

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return DSLineManQc;
        }
        //============================================================================================================
        #region Gajendra New QC
        public DataSet GetQualityControlBYContract(string OrderId, string OrderDetailID, string InspectionID, string InspectionIDMO)
        {
            QualityControl qualityControl = new QualityControl();
            DataSet DSQuality = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    SqlParameter param;
                    string cmdText = "GetQualityControlBYContract";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.Int);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionIDMO", SqlDbType.Int);
                    param.Value = InspectionIDMO;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(DSQuality);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return DSQuality;
        }
        public DataTable GetQcUploadFile(int orderDetailID, string QualityControlID)
        {
            QualityControl qualityControl = new QualityControl();
            DataTable DSQuality = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    SqlParameter param;
                    string cmdText = "Usp_GetQcquality_controlFile";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlId", SqlDbType.Int);
                    param.Value = QualityControlID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(DSQuality);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return DSQuality;
        }

        public DataTable GetQcLinemannew(int orderDetailID, string QualityControlID)
        {
            QualityControl qualityControl = new QualityControl();
            DataTable DSQuality = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    SqlParameter param;
                    string cmdText = "Usp_GetQc_Lineman";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlId", SqlDbType.Int);
                    param.Value = QualityControlID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(DSQuality);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return DSQuality;
        }


        public List<QualityContract> GetContractBYOrder(string OrderId, string InspectionID)
        {
            List<QualityContract> obj = new List<QualityContract>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                try
                {
                    SqlParameter param;
                    string cmdText = "GetContractBYOrder";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.Int);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        QualityContract objContract = new QualityContract();
                        objContract.ContractNumber = reader["ContractNumber"].ToString();
                        objContract.OrderDetailID = reader["OrderDetailID"].ToString();
                        obj.Add(objContract);
                    }
                }
                catch
                {

                }
            }
            return obj;
        }

        public QualityControl GetQualityControlBYQuality(int orderDetailID, string QualityControlID, string InspectionType)
        {
            QualityControl qualityControl = new QualityControl();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Get_quality_control_BYQuality";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = QualityControlID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionType", SqlDbType.Int);
                    param.Value = InspectionType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsQuality);

                    if (dsQuality.Tables.Count > 0)
                    {
                        qualityControl = ConvertDataSetToQualityByQualityID(dsQuality, orderDetailID, InspectionType);
                    }
                    else
                    {
                        qualityControl.OrderDetail = new OrderDetail();
                        qualityControl.OrderDetail.OrderDetailID = 0;
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl;
        }

        private QualityControl ConvertDataSetToQualityByQualityID(DataSet dsQuality, int orderDetailID, string InspectionType)
        {
            QualityControl qualityControl = new QualityControl();
            qualityControl.OrderDetail = new OrderDetail();
            qualityControl.Faults = new List<QualityFaults>();
            qualityControl.Faults1 = new List<QualityFaults>();
            qualityControl.FaultsPP = new List<QualityFaults>();
            qualityControl.Process = new List<QualityProcess>();
            qualityControl.OrderDetail.OrderDetailID = orderDetailID;
            qualityControl.InspectionID = Convert.ToInt32(InspectionType);

            DataTable dt = dsQuality.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                qualityControl.Id = (row["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Id"]);
                qualityControl.OrderDetail.OrderDetailID = (row["OrderDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["OrderDetailID"]);
                qualityControl.InspectionID = (row["InspectionID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["InspectionID"]);

                qualityControl.Comments = (row["Comments"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Comments"]);
                qualityControl.CommentsBy_DMM = (row["CommentsBy_DMM"] == DBNull.Value) ? String.Empty : Convert.ToString(row["CommentsBy_DMM"]);
                qualityControl.ProcessingInstruction = (row["ProcessingInstruction"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ProcessingInstruction"]);
                qualityControl.OtherInstruction = (row["OtherInstruction"] == DBNull.Value) ? String.Empty : Convert.ToString(row["OtherInstruction"]);
                qualityControl.UserName = (row["FirstName"] == DBNull.Value) ? String.Empty : Convert.ToString(row["FirstName"]);

                qualityControl.ApprovedByCQD_QAManager = (row["ApprovedByCQD_QAManager"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByCQD_QAManager"]);
                qualityControl.ApprovedByCQD_QAManagerOn = (row["ApprovedByCQD_QAManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByCQD_QAManagerOn"]);
                qualityControl.ApprovedByShippingOfficer = (row["ApprovedByShippingOfficer"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByShippingOfficer"]);
                qualityControl.ApprovedByShippingOfficerOn = (row["ApprovedByShippingOfficerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByShippingOfficerOn"]);
                qualityControl.ApprovedByDMM = (row["ApprovedByDMM"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByDMM"]);
                qualityControl.ApprovedByDMMOn = (row["ApprovedByDMMOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByDMMOn"]);

                qualityControl.ApprovedByBuyingHouse = (row["ApprovedByBuyingHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByBuyingHouse"]);
                qualityControl.ApprovedByBuyingHouseOn = (row["ApprovedByBuyingHouseOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByBuyingHouseOn"]);
                qualityControl.ApprovedByBuyingHouse_Factory = (row["ApprovedByBuyingHouse_Factory"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByBuyingHouse_Factory"]);
                qualityControl.ApprovedByBuyingHouse_FactoryOn = (row["ApprovedByBuyingHouse_FactoryOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByBuyingHouse_FactoryOn"]);
                qualityControl.ApprovedByBuyingHouse_IC = (row["ApprovedByBuyingHouse_IC"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ApprovedByBuyingHouse_IC"]);
                qualityControl.ApprovedByBuyingHouse_ICOn = (row["ApprovedByBuyingHouse_ICOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ApprovedByBuyingHouse_ICOn"]);
                qualityControl.BuyingHouse_FilePath = (row["BuyingHouse_FilePath"] == DBNull.Value) ? String.Empty : Convert.ToString(row["BuyingHouse_FilePath"]);
                qualityControl.BuyingHouse_Factory_FilePath = (row["BuyingHouse_Factory_FilePath"] == DBNull.Value) ? String.Empty : Convert.ToString(row["BuyingHouse_Factory_FilePath"]);
                qualityControl.BuyingHouse_IC_FilePath = (row["BuyingHouse_IC_FilePath"] == DBNull.Value) ? String.Empty : Convert.ToString(row["BuyingHouse_IC_FilePath"]);

                qualityControl.BuyingHouse_QAName = (row["BuyingHouse_QAName"] == DBNull.Value) ? String.Empty : Convert.ToString(row["BuyingHouse_QAName"]);
                qualityControl.BuyingHouseFactory_QAName = (row["BuyingHouseFactory_QAName"] == DBNull.Value) ? String.Empty : Convert.ToString(row["BuyingHouseFactory_QAName"]);
                qualityControl.BuyingHouse_Status = (row["BuyingHouse_Status"] == DBNull.Value) ? "0" : Convert.ToString(row["BuyingHouse_Status"]);
                qualityControl.BuyingHouseFactory_Status = (row["BuyingHouseFactory_Status"] == DBNull.Value) ? "0" : Convert.ToString(row["BuyingHouseFactory_Status"]);
                qualityControl.shippedqty = (row["shippedqty"] == DBNull.Value) ? 0 : Convert.ToInt32(row["shippedqty"]);
                qualityControl.IsShipped = (row["IsShipped"] == DBNull.Value) ? false : Convert.ToBoolean(row["IsShipped"]);
                qualityControl.BP_CR = (row["BP_CR"] == DBNull.Value) ? 0 : Convert.ToDouble(row["BP_CR"]);
                // Add By Ravi on 22/12/16
                qualityControl.chkGMQA = (row["chkGMQA"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkGMQA"]);
                qualityControl.chkCQD = (row["chkCQD"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkCQD"]);
                qualityControl.chkFactoryManager = (row["chkFactoryManager"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkFactoryManager"]);
                qualityControl.chkProdIncharge = (row["chkProdIncharge"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkProdIncharge"]);
                qualityControl.chkQC = (row["chkQC"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkQC"]);
                qualityControl.chkFinishIncharge = (row["chkFinishIncharge"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkFinishIncharge"]);
                qualityControl.chkFinishSuperwisor = (row["chkFinishSuperwisor"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkFinishSuperwisor"]);
                qualityControl.ckhLineMan = (row["ckhLineMan"] == DBNull.Value) ? 0 : Convert.ToInt16(row["ckhLineMan"]);
                qualityControl.chkAsstLineMan = (row["chkAsstLineMan"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkAsstLineMan"]);
                qualityControl.chkChecker = (row["chkChecker"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkChecker"]);
                qualityControl.chkPressMan = (row["chkPressMan"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkPressMan"]);
                qualityControl.chkOthers = (row["chkOthers"] == DBNull.Value) ? 0 : Convert.ToInt16(row["chkOthers"]);
                qualityControl.AdditionalInformation = (row["AdditionalInformation"] == DBNull.Value) ? String.Empty : Convert.ToString(row["AdditionalInformation"]);
                qualityControl.WithoutNatureOfFaults = (row["WithoutNatureOfFaults"] == DBNull.Value) ? false : Convert.ToBoolean(row["WithoutNatureOfFaults"]);
                qualityControl.InlineTopFiftyReports = (row["InlineTopFiftyReports"] == DBNull.Value) ? String.Empty : Convert.ToString(row["InlineTopFiftyReports"]);
                qualityControl.MissedfaultCount = (row["missedfaultcount"] == DBNull.Value) ? 0 : Convert.ToInt32(row["missedfaultcount"]);
                qualityControl.TotalOcuured = (row["totalfaultoccured"] == DBNull.Value) ? 0 : Convert.ToInt32(row["totalfaultoccured"]);
            }

            DataTable dt1 = dsQuality.Tables[1];
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    QualityFaults qualityFaults = new QualityFaults();
                    qualityFaults.ParentQualityControl = new QualityControl();
                    qualityFaults.Id = (row["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Id"]);
                    qualityFaults.ParentQualityControl.Id = (row["QualityControlID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QualityControlID"]);
                    qualityFaults.FaultId = (row["FaultID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultID"]);
                    qualityFaults.Resolution = (row["Resolution"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Resolution"]).Replace("^", "&").Replace("`", "<").Replace("~", ">");
                    qualityFaults.Owner = (row["Owner"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Owner"]);
                    qualityFaults.Occurrence = (row["Occurrence"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Occurrence"]);
                    qualityFaults.FaultType = (row["FaultType"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultType"]);
                    qualityFaults.InspectionID = (row["InspectionID"] == DBNull.Value) ? "0" : row["InspectionID"].ToString();
                    qualityFaults.FilePath = (row["FilePath"] == DBNull.Value) ? "" : row["FilePath"].ToString();
                    qualityFaults.FaultValue = (row["FaultValue"] == DBNull.Value) ? String.Empty : Convert.ToString(row["FaultValue"]);
                    qualityFaults.Fault = (row["Faults"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Faults"]);
                    qualityFaults.FaultDetails = (row["FaultDetails"] == DBNull.Value) ? String.Empty : Convert.ToString(row["FaultDetails"]);
                    qualityFaults.CorrectiveActionPlan = (row["CorrectiveActionPlan"] == DBNull.Value) ? String.Empty : Convert.ToString(row["CorrectiveActionPlan"]);
                    qualityControl.Faults.Add(qualityFaults);
                }
            }

            DataTable dt2 = dsQuality.Tables[2];
            DataTable dt3 = dsQuality.Tables[3];
            if (dt2.Rows.Count > 0 && dt3.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow dr in dt2.Rows)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        QualityFaults qualityFaults = new QualityFaults();
                        qualityFaults.ParentQualityControl = new QualityControl();
                        qualityFaults.CheckingItems = new List<ItemsToCheck>();
                        qualityFaults.SizesList = new List<OrderDetailSizes>();

                        qualityFaults.ParentQualityControl = new QualityControl();
                        qualityFaults.Id = (row["QCPartID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QCPartID"]);
                        qualityFaults.ParentQualityControl.Id = (row["QualityControlID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QualityControlID"]);
                        qualityFaults.FaultId = (row["FaultID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultID"]);
                        qualityFaults.Resolution = (row["Resolution"] == DBNull.Value) ? String.Empty : Convert.ToString(row["Resolution"]);
                        qualityFaults.Owner = (row["Owner"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Owner"]);
                        qualityFaults.IsOnline = (row["IsOnline"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IsOnline"]);
                        qualityFaults.Occurrence = (row["Occurrence"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Occurrence"]);
                        qualityFaults.FaultType = (row["FaultType"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FaultType"]);
                        qualityFaults.FaultValue = qualityFaults.FaultId + "-" + qualityFaults.FaultType;
                        qualityFaults.ShippingQty = (row["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ShippingQty"]);
                        qualityFaults.ActualSamplesChecked = (row["ActualSampleChecked"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ActualSampleChecked"]);
                        qualityFaults.DateConducted = (row["DateConducted"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["DateConducted"]);
                        qualityFaults.Status = (row["Status"] == DBNull.Value || (Convert.ToInt32(row["Status"]) == 0)) ? String.Empty : ((Convert.ToInt32(row["Status"]) == 1) ? "PASS" : "FAIL");
                        qualityFaults.QA = (row["QA"] == DBNull.Value) ? 0 : Convert.ToInt32(row["QA"]);

                        DataTable dt4 = dsQuality.Tables[4];
                        if (dt4 != null && dt4.Rows.Count > 0 && i <= dt4.Rows.Count)
                        {
                            qualityFaults.SampleQuantity = (dt4.Rows[i]["SampleQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["SampleQty"]);
                            qualityFaults.MajorDefectsAllowed = (dt4.Rows[i]["MajorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MajorAllowed"]);
                            qualityFaults.MinorDefectsAllowed = (dt4.Rows[i]["MinorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MinorAllowed"]);
                            qualityFaults.AqlValue = (dt4.Rows[i]["AQLType"] == DBNull.Value) ? String.Empty : Convert.ToString(dt4.Rows[i]["AQLType"]);
                        }

                        qualityFaults.CheckingItems = GetCheckingItemsByQuality(qualityFaults.ParentQualityControl.Id, qualityControl.InspectionID);
                        qualityFaults.SizesList = GetSizesForPartByQuality(qualityFaults.ParentQualityControl.Id, qualityControl.OrderDetail.OrderDetailID);

                        qualityControl.FaultsPP.Add(qualityFaults);
                    }
                    i++;
                }
            }
            else if (dt3.Rows.Count == 0)
            {
                foreach (DataRow row2 in dt2.Rows)
                {
                    int i = 0;
                    QualityFaults qualityFaults = new QualityFaults();
                    qualityFaults.ParentQualityControl = new QualityControl();
                    qualityFaults.CheckingItems = new List<ItemsToCheck>();
                    qualityFaults.SizesList = new List<OrderDetailSizes>();

                    qualityFaults.ParentQualityControl = new QualityControl();
                    qualityFaults.Id = (row2["FaultsPPID"] == DBNull.Value) ? 0 : Convert.ToInt32(row2["FaultsPPID"]);
                    qualityFaults.ParentQualityControl.Id = 0;
                    qualityFaults.FaultId = -1;
                    qualityFaults.Resolution = String.Empty;
                    qualityFaults.Owner = 0;
                    qualityFaults.IsOnline = 0;
                    qualityFaults.Occurrence = 0;
                    qualityFaults.FaultType = 0;
                    qualityFaults.FaultValue = "-1";
                    qualityFaults.ShippingQty = (row2["ShippingQty"] == DBNull.Value) ? 0 : Convert.ToInt32(row2["ShippingQty"]);
                    qualityFaults.ActualSamplesChecked = 0;
                    qualityFaults.DateConducted = DateTime.MinValue;
                    qualityFaults.Status = (row2["Status"] == DBNull.Value || (Convert.ToInt32(row2["Status"]) == 0)) ? String.Empty : ((Convert.ToInt32(row2["Status"]) == 1) ? "PASS" : "FAIL");
                    qualityFaults.QA = 0;

                    DataTable dt4 = dsQuality.Tables[4];
                    if (dt4 != null && dt4.Rows.Count > 0 && i < dt4.Rows.Count)
                    {
                        qualityFaults.SampleQuantity = (dt4.Rows[i]["SampleQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["SampleQty"]);
                        qualityFaults.MajorDefectsAllowed = (dt4.Rows[i]["MajorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MajorAllowed"]);
                        qualityFaults.MinorDefectsAllowed = (dt4.Rows[i]["MinorAllowed"] == DBNull.Value) ? 0 : Convert.ToInt32(dt4.Rows[i]["MinorAllowed"]);
                        qualityFaults.AqlValue = (dt4.Rows[i]["AQLType"] == DBNull.Value) ? String.Empty : Convert.ToString(dt4.Rows[i]["AQLType"]);
                    }

                    qualityFaults.CheckingItems = GetCheckingItemsByQuality(qualityFaults.ParentQualityControl.Id, qualityControl.InspectionID);
                    qualityFaults.SizesList = GetSizesForPartByQuality(qualityFaults.ParentQualityControl.Id, qualityControl.OrderDetail.OrderDetailID);

                    qualityControl.FaultsPP.Add(qualityFaults);
                    i++;
                }
            }

            DataTable dtProcess = dsQuality.Tables[5];
            if (dtProcess.Rows.Count > 0)
            {
                foreach (DataRow row in dtProcess.Rows)
                {
                    QualityProcess qualityProcess = new QualityProcess();

                    qualityProcess.ProcessId = (row["QaProcessId"] == DBNull.Value) ? "" : row["QaProcessId"].ToString();
                    qualityProcess.ProcessName = (row["ProcessName"] == DBNull.Value) ? "" : row["ProcessName"].ToString();
                    qualityProcess.ProcessStatus = (row["ProcessStatus"] == DBNull.Value) ? -1 : Convert.ToInt16(row["ProcessStatus"]);
                    qualityProcess.ProcessActivePlan = (row["CorrectiveActionPlan"] == DBNull.Value) ? "" : row["CorrectiveActionPlan"].ToString();
                    qualityControl.Process.Add(qualityProcess);
                }
            }

            return qualityControl;

        }

        public List<ItemsToCheck> GetCheckingItemsByQuality(int qid, int Inspectionid)
        {
            QualityControlStatus qualityControl = new QualityControlStatus();
            qualityControl.CheckingItems = new List<ItemsToCheck>();
            iKandi.Common.ItemsToCheck itemTochk = new ItemsToCheck();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Get_quality_control_checked_items_ByQuality";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = qid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Inspectionid", SqlDbType.Int);
                    param.Value = Inspectionid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsQuality = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsQuality);

                    if (dsQuality.Tables[0].Rows.Count > 0)
                    {
                        qualityControl.CheckingItems = ConvertDataSetToCheckingItem(dsQuality);
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl.CheckingItems;
        }

        public List<OrderDetailSizes> GetSizesForPartByQuality(int QualityControlID, int OrderDetailID)
        {
            List<OrderDetailSizes> ordSizes = new List<OrderDetailSizes>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Get_quality_control_sizes_ByQuality";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = QualityControlID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsSizes = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsSizes);

                    if (dsSizes.Tables[0].Rows.Count > 0)
                    {
                        ordSizes = ConvertDataSetToSizes(dsSizes);
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return ordSizes;
        }

        public DataSet GetFault_Subcategory()
        {
            QualityControl qualityControl = new QualityControl();
            DataSet Fault_Subcategory = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "usp_GetFault_Subcategory";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(Fault_Subcategory);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return Fault_Subcategory;
        }

        public bool InsertQualityNew(QualityControl qualityControl)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "InsertQualityNew";
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

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = qualityControl.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = qualityControl.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CommentsBy_DMM", SqlDbType.VarChar);
                    param.Value = qualityControl.CommentsBy_DMM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByCQD_QAManager", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByCQD_QAManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByCQD_QAManagerOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByCQD_QAManagerOn == DateTime.MinValue) || (qualityControl.ApprovedByCQD_QAManagerOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByCQD_QAManagerOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByCQD_QAManagerOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProcessingInstruction", SqlDbType.Int);
                    param.Value = qualityControl.ProcessingInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherInstruction", SqlDbType.VarChar);
                    param.Value = qualityControl.OtherInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByShippingOfficer", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByShippingOfficer;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByShippingOfficerOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByShippingOfficerOn == DateTime.MinValue) || (qualityControl.ApprovedByShippingOfficerOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByShippingOfficerOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByShippingOfficerOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByDMM", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByDMM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByDMMOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByDMMOn == DateTime.MinValue) || (qualityControl.ApprovedByDMMOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByDMMOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByDMMOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ApprovedByBuyingHouse", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByBuyingHouse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouseOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByBuyingHouseOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouseOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouseOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByBuyingHouseOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_Factory", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByBuyingHouse_Factory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_FactoryOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByBuyingHouse_FactoryOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouse_FactoryOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouse_FactoryOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByBuyingHouse_FactoryOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_IC", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByBuyingHouse_IC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_ICOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByBuyingHouse_ICOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouse_ICOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouse_ICOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByBuyingHouse_ICOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_FilePath", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_Factory_FilePath", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_Factory_FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_IC_FilePath", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_IC_FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
                    param.Value = qualityControl.InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_QAName", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_QAName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouseFactory_QAName", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouseFactory_QAName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_Status", SqlDbType.Int);
                    param.Value = qualityControl.BuyingHouse_Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouseFactory_Status", SqlDbType.Int);
                    param.Value = qualityControl.BuyingHouseFactory_Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@XMLDocument", SqlDbType.Xml);
                    param.Value = qualityControl.FaultXML;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippedQty", SqlDbType.Int);
                    if (qualityControl.shippedqty != -1)
                        param.Value = qualityControl.shippedqty;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Added By Ravi kumar on 26/12/2016
                    param = new SqlParameter("@chkGMQA", SqlDbType.Int);
                    param.Value = qualityControl.chkGMQA;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkCQD", SqlDbType.Int);
                    param.Value = qualityControl.chkCQD;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkFactoryManager", SqlDbType.Int);
                    param.Value = qualityControl.chkFactoryManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkProdIncharge", SqlDbType.Int);
                    param.Value = qualityControl.chkProdIncharge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkQC", SqlDbType.Int);
                    param.Value = qualityControl.chkQC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkFinishIncharge", SqlDbType.Int);
                    param.Value = qualityControl.chkFinishIncharge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkFinishSuperwisor", SqlDbType.Int);
                    param.Value = qualityControl.chkFinishSuperwisor;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ckhLineMan", SqlDbType.Int);
                    param.Value = qualityControl.ckhLineMan;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkAsstLineMan", SqlDbType.Int);
                    param.Value = qualityControl.chkAsstLineMan;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkChecker", SqlDbType.Int);
                    param.Value = qualityControl.chkChecker;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkPressMan", SqlDbType.Int);
                    param.Value = qualityControl.chkPressMan;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkOthers", SqlDbType.Int);
                    param.Value = qualityControl.chkOthers;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AdditionalInformation", SqlDbType.VarChar);
                    param.Value = qualityControl.AdditionalInformation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WithoutNatureOfFaults", SqlDbType.Bit);
                    param.Value = qualityControl.WithoutNatureOfFaults;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@LineManId", SqlDbType.Int);
                    param.Value = qualityControl.LineManId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@QcId", SqlDbType.Int);
                    param.Value = qualityControl.QcId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@XMLProcess", SqlDbType.Xml);
                    param.Value = qualityControl.ProcessXML;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@missedfaultcount", SqlDbType.Int);
                    param.Value = qualityControl.MissedfaultCount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@totalfaultoccured", SqlDbType.Int);
                    param.Value = qualityControl.TotalOcuured;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();

                    int qId = Convert.ToInt32(outParam.Value);

                    if (qId == -1)
                        return false;

                    qualityControl.Id = qId;
                    QualityControl.SQualityId = qId;

                    if (qualityControl.FaultsPP != null && qualityControl.FaultsPP.Count > 0)
                    {
                        foreach (QualityFaults qFaultsPP in qualityControl.FaultsPP)
                        {
                            if (qFaultsPP.Id <= 0)
                            {
                                qFaultsPP.ParentQualityControl = new QualityControl();
                                qFaultsPP.ParentQualityControl.Id = qualityControl.Id;
                                int qFaultsPPId = InsertQualityFaultsPPNew(qFaultsPP, cnx, transaction);
                                qFaultsPP.Id = qFaultsPPId;

                                if (qFaultsPP.CheckingItems != null && qFaultsPP.CheckingItems.Count > 0)
                                    foreach (ItemsToCheck itemsToCheck in qFaultsPP.CheckingItems)
                                    {
                                        if (itemsToCheck.Id == -1)
                                        {
                                            itemsToCheck.ParentQualityControl.Id = qualityControl.Id;
                                            itemsToCheck.ParentQualityControl.InspectionID = qualityControl.InspectionID;
                                            int qitemsToCheckId = InsertCheckingItemsNew(itemsToCheck, cnx, transaction);
                                            itemsToCheck.Id = qitemsToCheckId;
                                        }
                                    }
                            }
                        }
                    }
                    foreach (LineManQC objLineManQC in qualityControl.LineMan)
                    {
                        int iInsertQC = InsertQc_Lineman(cnx, transaction, objLineManQC, qualityControl.OrderDetail.OrderDetailID, qualityControl.Id, this.LoggedInUser.UserData.UserID, qualityControl.Production_Unit);
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


        // Added By ravi kumar on 9-oct-18
        public int InsertQc_Lineman(SqlConnection cnx, SqlTransaction transaction, LineManQC objLineManQC, int OrderDetailId, int QualityControlId, int UserId, int ProductionUnit_ID)
        {
            int iSave = 0;
            try
            {
                string cmdText = "Usp_InsertQc_Lineman";

                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }

                SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityControlId", SqlDbType.Int);
                param.Value = QualityControlId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LineManId", SqlDbType.Int);
                param.Value = objLineManQC.LineManId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QCId", SqlDbType.Int);
                param.Value = objLineManQC.QCId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@LineNo", SqlDbType.Int);
                //param.Value = objLineManQC.LineNo;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@UnitId", SqlDbType.Int);
                //param.Value = objLineManQC.UnitId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionUnitID", SqlDbType.Int);
                param.Value = ProductionUnit_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                iSave = cmd.ExecuteNonQuery();
                //cnx.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return iSave;
        }

        // End By ravi kumar on 9-oct-18

        public int InsertQualityFaultsPPNew(QualityFaults qualityFaults, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "InsertQualityFaultsPPNew";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@d", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = qualityFaults.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DateConducted", SqlDbType.DateTime);
            if ((qualityFaults.DateConducted == DateTime.MinValue) || (qualityFaults.DateConducted == Convert.ToDateTime("1753-01-01")) || (qualityFaults.DateConducted == Convert.ToDateTime("1900-01-01")))
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = qualityFaults.DateConducted;
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QA", SqlDbType.Int);
            param.Value = qualityFaults.QA;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActualSampleChecked", SqlDbType.Int);
            param.Value = qualityFaults.ActualSamplesChecked;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Value = Convert.ToInt32(qualityFaults.Status);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FailCount", SqlDbType.Int);
            if (qualityFaults.Status == "2")
                param.Value = 1;
            else
                param.Value = 0;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
            param.Value = qualityFaults.InspectionID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int qFaultID = Convert.ToInt32(outParam.Value);

            return qFaultID;

        }

        public int InsertCheckingItemsNew(ItemsToCheck itemsToCheck, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "InsertCheckingItemsNew";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@d", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@CheckingItem", SqlDbType.Int);
            param.Value = itemsToCheck.CheckingItem;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = itemsToCheck.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Missing", SqlDbType.Int);
            param.Value = itemsToCheck.Missing;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NotRequired", SqlDbType.Int);
            param.Value = itemsToCheck.NotRequired;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Present", SqlDbType.Int);
            param.Value = itemsToCheck.Present;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@InspectionID", SqlDbType.Int);
            param.Value = itemsToCheck.ParentQualityControl.InspectionID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int qCheckingId = Convert.ToInt32(outParam.Value);

            return qCheckingId;

        }

        // Added By ravi kumar on 9-oct-18
        public int DeleteQc_Lineman(int OrderDetailId, int QualityControlId)
        {
            int iDelete = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    string cmdText = "Usp_DeleteQc_Lineman";

                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlId", SqlDbType.Int);
                    param.Value = QualityControlId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    iDelete = cmd.ExecuteNonQuery();
                    cnx.Close();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return iDelete;
        }

        // End By ravi kumar on 9-oct-18

        public bool UpdateQualityNew(QualityControl qualityControl)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                int intStatus = Convert.ToInt32(qualityControl.FaultsPP[0].Status);
                try
                {
                    string cmdText = "UpdateQualityNew";
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = qualityControl.Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = qualityControl.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = qualityControl.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CommentsBy_DMM", SqlDbType.VarChar);
                    param.Value = qualityControl.CommentsBy_DMM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByCQD_QAManager", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByCQD_QAManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByCQD_QAManagerOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByCQD_QAManagerOn == DateTime.MinValue) || (qualityControl.ApprovedByCQD_QAManagerOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByCQD_QAManagerOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByCQD_QAManagerOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProcessingInstruction", SqlDbType.Int);
                    param.Value = qualityControl.ProcessingInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherInstruction", SqlDbType.VarChar);
                    param.Value = qualityControl.OtherInstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByShippingOfficer", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByShippingOfficer;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByShippingOfficerOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByShippingOfficerOn == DateTime.MinValue) || (qualityControl.ApprovedByShippingOfficerOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByShippingOfficerOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByShippingOfficerOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByDMM", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByDMM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByDMMOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByDMMOn == DateTime.MinValue) || (qualityControl.ApprovedByDMMOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByDMMOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByDMMOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByBuyingHouse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouseOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByBuyingHouseOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouseOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouseOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByBuyingHouseOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_Factory", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByBuyingHouse_Factory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_FactoryOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByBuyingHouse_FactoryOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouse_FactoryOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouse_FactoryOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByBuyingHouse_FactoryOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_IC", SqlDbType.Int);
                    param.Value = qualityControl.ApprovedByBuyingHouse_IC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByBuyingHouse_ICOn", SqlDbType.DateTime);
                    if ((qualityControl.ApprovedByBuyingHouse_ICOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouse_ICOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouse_ICOn == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = qualityControl.ApprovedByBuyingHouse_ICOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_FilePath", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_Factory_FilePath", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_Factory_FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_IC_FilePath", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_IC_FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
                    param.Value = qualityControl.InspectionID;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_QAName", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouse_QAName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouseFactory_QAName", SqlDbType.VarChar);
                    param.Value = qualityControl.BuyingHouseFactory_QAName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouse_Status", SqlDbType.Int);
                    param.Value = qualityControl.BuyingHouse_Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouseFactory_Status", SqlDbType.Int);
                    param.Value = qualityControl.BuyingHouseFactory_Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@XMLDocument", SqlDbType.Xml);
                    param.Value = qualityControl.FaultXML;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippedQty", SqlDbType.Int);
                    if (qualityControl.shippedqty != -1)
                        param.Value = qualityControl.shippedqty;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@chkGMQA", SqlDbType.Int);
                    param.Value = qualityControl.chkGMQA;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkCQD", SqlDbType.Int);
                    param.Value = qualityControl.chkCQD;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkFactoryManager", SqlDbType.Int);
                    param.Value = qualityControl.chkFactoryManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkProdIncharge", SqlDbType.Int);
                    param.Value = qualityControl.chkProdIncharge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkQC", SqlDbType.Int);
                    param.Value = qualityControl.chkQC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkFinishIncharge", SqlDbType.Int);
                    param.Value = qualityControl.chkFinishIncharge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkFinishSuperwisor", SqlDbType.Int);
                    param.Value = qualityControl.chkFinishSuperwisor;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ckhLineMan", SqlDbType.Int);
                    param.Value = qualityControl.ckhLineMan;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkAsstLineMan", SqlDbType.Int);
                    param.Value = qualityControl.chkAsstLineMan;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkChecker", SqlDbType.Int);
                    param.Value = qualityControl.chkChecker;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkPressMan", SqlDbType.Int);
                    param.Value = qualityControl.chkPressMan;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@chkOthers", SqlDbType.Int);
                    param.Value = qualityControl.chkOthers;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AdditionalInformation", SqlDbType.VarChar);
                    param.Value = qualityControl.AdditionalInformation;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WithoutNatureOfFaults", SqlDbType.Bit);
                    param.Value = qualityControl.WithoutNatureOfFaults;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LineManId", SqlDbType.Int);
                    param.Value = qualityControl.LineManId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QcId", SqlDbType.Int);
                    param.Value = qualityControl.QcId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@XMLProcess", SqlDbType.Xml);
                    param.Value = qualityControl.ProcessXML;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@missedfaultcount", SqlDbType.Int);
                    param.Value = qualityControl.MissedfaultCount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@totalfaultoccured", SqlDbType.Int);
                    param.Value = qualityControl.TotalOcuured;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@ProductionUnitID", SqlDbType.Int);
                    //param.Value = qualityControl.Production_Unit;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                    foreach (QualityFaults qFaultsPP in qualityControl.FaultsPP)
                    {
                        if (qFaultsPP.Id > 0)
                        {
                            qFaultsPP.ParentQualityControl = new QualityControl();
                            qFaultsPP.ParentQualityControl.Id = qualityControl.Id;
                            UpdateQualityFaultsPPNew(qFaultsPP, cnx, transaction, intStatus);
                            if (qFaultsPP.CheckingItems != null && qFaultsPP.CheckingItems.Count > 0)
                                foreach (ItemsToCheck itemsToCheck in qFaultsPP.CheckingItems)
                                {
                                    if (itemsToCheck.Id != -1)
                                    {
                                        itemsToCheck.ParentQualityControl.InspectionID = qualityControl.InspectionID;
                                        UpdateCheckingItemsNew(itemsToCheck, cnx, transaction);
                                    }
                                    else if (itemsToCheck.Id == -1)
                                    {
                                        itemsToCheck.ParentQualityControl.InspectionID = qualityControl.InspectionID;
                                        itemsToCheck.ParentQualityControl.Id = qualityControl.Id;
                                        int qitemsToCheckId = InsertCheckingItemsNew(itemsToCheck, cnx, transaction);
                                        itemsToCheck.Id = qitemsToCheckId;
                                    }
                                }
                        }
                    }

                    foreach (LineManQC objLineManQC in qualityControl.LineMan)
                    {
                        int iInsertQC = InsertQc_Lineman(cnx, transaction, objLineManQC, qualityControl.OrderDetail.OrderDetailID, qualityControl.Id, this.LoggedInUser.UserData.UserID, qualityControl.Production_Unit);
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

        public bool UpdateQualityFaultsPPNew(QualityFaults qualityFaults, SqlConnection cnx, SqlTransaction transaction, int intStatus)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "UpdateQualityFaultsPPNew";

                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                //SqlTransaction sqlTrans = cnx.BeginTransaction();

                SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                //param = new SqlParameter("@d", SqlDbType.Int);
                //param.Value = qualityFaults.Id;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                param.Value = qualityFaults.ParentQualityControl.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateConducted", SqlDbType.DateTime);
                if ((qualityFaults.DateConducted == DateTime.MinValue) || (qualityFaults.DateConducted == Convert.ToDateTime("1753-01-01")) || (qualityFaults.DateConducted == Convert.ToDateTime("1900-01-01")))
                // if (qualityFaults.DateConducted == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = qualityFaults.DateConducted;
                }

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QA", SqlDbType.Int);
                param.Value = qualityFaults.QA;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActualSampleChecked", SqlDbType.Int);
                param.Value = qualityFaults.ActualSamplesChecked;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = Convert.ToInt32(qualityFaults.Status);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
                param.Value = qualityFaults.InspectionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return true;

        }

        public bool UpdateCheckingItemsNew(ItemsToCheck itemsToCheck, SqlConnection cnx, SqlTransaction transaction)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "UpdateCheckingItemsNew";

            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //SqlTransaction sqlTrans = cnx.BeginTransaction();

            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@d", SqlDbType.Int);
            param.Value = itemsToCheck.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CheckingItem", SqlDbType.Int);
            param.Value = itemsToCheck.CheckingItem;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QualityControlID", SqlDbType.Int);
            param.Value = itemsToCheck.ParentQualityControl.Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Missing", SqlDbType.Int);
            param.Value = itemsToCheck.Missing;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NotRequired", SqlDbType.Int);
            param.Value = itemsToCheck.NotRequired;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Present", SqlDbType.Int);
            param.Value = itemsToCheck.Present;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
            //param.Value = itemsToCheck.InspectionID;
            //param.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

            return true;

        }

        public string CreateQualityProxy(string OrderDetailID, string InspectionID, string None, string RefOrderDetailID)
        {
            string Success = "0";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "CreateQualityProxy";
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@None", SqlDbType.VarChar);
                    param.Value = None;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RefOrderDetailID", SqlDbType.Int);
                    param.Value = RefOrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Success = cmd.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return Success;

        }

        public bool CloseQC_Task(string OrderDetailID, string InspectionID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "UpdateQC_Task";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
                param.Direction = ParameterDirection.Input;
                param.Value = InspectionID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return true;
        }

        public bool CreateQC_Final_Inspection_Task(TaskMode Mode, int WorkflowID, DateTime ETA)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "CreateQC_Final_Inspection_Task";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@WorkflowInstanceID", SqlDbType.Int);
                param.Value = WorkflowID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Mode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ETA", SqlDbType.Date);
                param.Value = ETA;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return true;
        }

        public bool Create_CloseQC_Mid_Online_Inspection_Task(string OrderDetailID, string InspectionID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Create_CloseQC_Mid_Online_Inspection_Task";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@InspectionID", SqlDbType.TinyInt);
                param.Direction = ParameterDirection.Input;
                param.Value = InspectionID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return true;
        }

        public bool CloseQCInline_Task(string OrderDetailID, string status)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "CloseQCInline_Task";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return true;
        }

        // Added By Ravi kumar for auto complete Nature of faults
        public string GetNatureOfFaults_Value(string NatureOfFaults)
        {
            string Value = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "usp_GetNatureOfFaults_Value";
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@TextField", SqlDbType.VarChar, 500);
                    param.Value = NatureOfFaults;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Value = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return Value;

        }


        public DataSet Get_AllQC_CotractsByOrder(int OrderID, int OrderDetailId, string InspectionID)
        {
            DataSet AllQC_Cotracts = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Get_AllQC_CotractsByOrder";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDeatilId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.Int);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(AllQC_Cotracts);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return AllQC_Cotracts;
        }
        public DataSet Get_AllQC_CotractsByOrder_Rescan(int OrderID, int OrderDetailId, string InspectionID, int QualityControlId)
        {
            DataSet AllQC_Cotracts = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Get_All_Packing_Details_Against_DoOnline";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDeatilId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.Int);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = QualityControlId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(AllQC_Cotracts);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return AllQC_Cotracts;
        }


        public DataSet Get_AllQCInline_Task(string OrderID, string ODID)
        {
            DataSet AllQC_Cotracts = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Get_AllQCInline_Task";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@OrderID", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = ODID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(AllQC_Cotracts);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return AllQC_Cotracts;
        }

        //Add BY Prabhaker On 31-aug-18
        public string CreateQCContractsProxy_Rescan(string OrderDetailID, string RescanDate, int QualityControlId, bool IsTaskDone)
        {
            string Success = "0";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Usp_Update_Packing_History_Against_QualityControlID";
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RescanDate", SqlDbType.DateTime);
                    param.Value = RescanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                    param.Value = QualityControlId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsDoOnline", SqlDbType.Bit);
                    param.Value = IsTaskDone;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    Success = cmd.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return Success;

        }




        //End Of Code



        public string CreateQCContractsProxy(string OrderDetailID, string InspectionID, bool IsTaskDone, string RefOrderDetailID, int InLineFromPopUp, int Status, int QualityControlId)
        {
            string Success = "0";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "CreateQCContractsProxy";
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.Int);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RefOrderDetailID", SqlDbType.Int);
                    param.Value = RefOrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsTaskDone", SqlDbType.Bit);
                    param.Value = IsTaskDone;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InLineFromPopUp", SqlDbType.Int);
                    param.Value = InLineFromPopUp;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.Int);
                    param.Value = Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityControlId", SqlDbType.BigInt);
                    param.Value = QualityControlId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Success = cmd.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return Success;

        }


        public int UpdateQualityControlBH(QualityControl qualityControl)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "UpdateQualityControlBH";
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@QualityControlID", SqlDbType.Int);
                param.Value = qualityControl.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = qualityControl.OrderDetail.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApprovedByBuyingHouse", SqlDbType.Int);
                param.Value = qualityControl.ApprovedByBuyingHouse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApprovedByBuyingHouseOn", SqlDbType.DateTime);
                if ((qualityControl.ApprovedByBuyingHouseOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouseOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouseOn == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = qualityControl.ApprovedByBuyingHouseOn;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApprovedByBuyingHouse_Factory", SqlDbType.Int);
                param.Value = qualityControl.ApprovedByBuyingHouse_Factory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApprovedByBuyingHouse_FactoryOn", SqlDbType.DateTime);
                if ((qualityControl.ApprovedByBuyingHouse_FactoryOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouse_FactoryOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouse_FactoryOn == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = qualityControl.ApprovedByBuyingHouse_FactoryOn;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApprovedByBuyingHouse_IC", SqlDbType.Int);
                param.Value = qualityControl.ApprovedByBuyingHouse_IC;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ApprovedByBuyingHouse_ICOn", SqlDbType.DateTime);
                if ((qualityControl.ApprovedByBuyingHouse_ICOn == DateTime.MinValue) || (qualityControl.ApprovedByBuyingHouse_ICOn == Convert.ToDateTime("1753-01-01")) || (qualityControl.ApprovedByBuyingHouse_ICOn == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = qualityControl.ApprovedByBuyingHouse_ICOn;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouse_FilePath", SqlDbType.VarChar);
                param.Value = qualityControl.BuyingHouse_FilePath;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouse_Factory_FilePath", SqlDbType.VarChar);
                param.Value = qualityControl.BuyingHouse_Factory_FilePath;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouse_IC_FilePath", SqlDbType.VarChar);
                param.Value = qualityControl.BuyingHouse_IC_FilePath;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouse_QAName", SqlDbType.VarChar);
                param.Value = qualityControl.BuyingHouse_QAName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseFactory_QAName", SqlDbType.VarChar);
                param.Value = qualityControl.BuyingHouseFactory_QAName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouse_Status", SqlDbType.Int);
                param.Value = qualityControl.BuyingHouse_Status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseFactory_Status", SqlDbType.Int);
                param.Value = qualityControl.BuyingHouseFactory_Status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                return (cmd.ExecuteNonQuery());
            }
        }
        #endregion

        public string VAlidateSerialNumber(string SerialNumber)
        {
            string res = "";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                try
                {
                    string cmdText = "UspValidateSerialNumber";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@SerialNuber", SqlDbType.VarChar);
                    param.Value = SerialNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);
                    res = dt.Rows[0]["Result"].ToString();


                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return res;
        }
        //added by abhishek on 27/7/2017
        public QualityControl GetQcFualtSummary()
        {
            QualityControl qualityControl = new QualityControl();
            DataSet QcReport = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Usp_GetQcFaultDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    //SqlParameter param;
                    //param = new SqlParameter("@OrderID", SqlDbType.Int);
                    //param.Value = OrderID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(QcReport);

                    if (QcReport.Tables[0].Rows.Count > 0)
                    {
                        qualityControl = ConvertDataSetToQc(QcReport);
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return qualityControl;

        }

        private QualityControl ConvertDataSetToQc(DataSet QcReport)
        {
            QualityControl qualityControl = new QualityControl();

            qualityControl.Process = new List<QualityProcess>();

            DataTable dtProcess = QcReport.Tables[0];
            if (dtProcess.Rows.Count > 0)
            {
                foreach (DataRow row in dtProcess.Rows)
                {
                    QualityProcess qualityProcess = new QualityProcess();

                    qualityProcess.ProcessId = (row["QaProcessId"] == DBNull.Value) ? "" : row["QaProcessId"].ToString();
                    qualityProcess.ProcessName = (row["ProcessName"] == DBNull.Value) ? "" : row["ProcessName"].ToString();
                    qualityControl.Process.Add(qualityProcess);
                }
            }

            return qualityControl;

        }

        public DataSet GetQcFualtPer(int UnitID, string Flag, string FaultTypeID)
        {
            DataSet dsQuality = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "Usp_GetQCFualtSummary";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    param = new SqlParameter("@UnitID", SqlDbType.Int);
                    param.Value = UnitID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FaultTypeID", SqlDbType.VarChar);
                    param.Value = FaultTypeID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsQuality);


                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dsQuality;
        }
        //Added by abishek on 6.2.2018
        public List<iKandi.Common.QCFormSupport> UpdateSupportIssue(string Flag, int OrderdetailID, string createdon, int QAtype)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_UpdateSupportIssue";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderdetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QcDate", SqlDbType.DateTime);
                param.Value = DateTime.Parse(createdon);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@inspectionID", SqlDbType.Int);
                param.Value = QAtype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                List<iKandi.Common.QCFormSupport> QcDetail = new List<iKandi.Common.QCFormSupport>();
                while (reader.Read())
                {
                    QCFormSupport QC = new QCFormSupport();
                    QC.QCID = reader["QualitycontrolID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["QualitycontrolID"].ToString());
                    QC.OrderDetailID = reader["OrderDetailID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["OrderDetailID"].ToString());
                    QC.Contarctnumber = reader["ContractNumber"] == DBNull.Value ? "" : reader["ContractNumber"].ToString();
                    QC.Updatedon = reader["UpdatedOn"] == DBNull.Value ? "" : reader["UpdatedOn"].ToString();
                    QC.CQDname = reader["CQDName"] == DBNull.Value ? "" : reader["CQDName"].ToString();
                    QC.Qty = reader["Qty"] == DBNull.Value ? "" : reader["Qty"].ToString();
                    QC.SerialNumber = reader["SerialNumber"] == DBNull.Value ? "" : reader["SerialNumber"].ToString();
                    QcDetail.Add(QC);
                }

                return QcDetail;
            }
        }
        public bool UpdateQCSheetStatus(string flag, int QCID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_UpdateSupportIssue";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@QCid", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = QCID;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return true;
        }
        public bool PendingOrderSummaryUpdateOnStagechange(string flag, string StagesCount, int OrderDetailID, int fabricMasterID, string ColorPrin, 
            int NewSelectionStageNo1 ,int NewSelectionStageNo2 ,int NewSelectionStageNo3 ,int NewSelectionStageNo4 ,int OldSelectionStageNo1 ,int OldSelectionStageNo2 ,int OldSelectionStageNo3 ,int OldSelectionStageNo4 ,int FabricPending_Orders_Id, Boolean finlized)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_UpdatePOStageAfterRaised";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@StagesCount", SqlDbType.VarChar);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = StagesCount;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@orderdetailsid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OrderDetailID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@fabricqualityid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricMasterID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@fabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ColorPrin;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@NewSelectionStageNo1", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = NewSelectionStageNo1;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewSelectionStageNo2", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = NewSelectionStageNo2;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewSelectionStageNo3", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = NewSelectionStageNo3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewSelectionStageNo4", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = NewSelectionStageNo4;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@OldSelectionStageNo1", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OldSelectionStageNo1;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OldSelectionStageNo2", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OldSelectionStageNo2;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OldSelectionStageNo3", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OldSelectionStageNo3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OldSelectionStageNo4", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OldSelectionStageNo4;
                    cmd.Parameters.Add(param);


                    //param = new SqlParameter("@FabricPending_Orders_Id", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = FabricPending_Orders_Id;
                    //cmd.Parameters.Add(param);


                    param = new SqlParameter("@ISfinlized", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = finlized;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }

        public bool PendingOrderSummaryUpdate(string flag, string StagesCount, int OrderDetailID, int fabricMasterID, string ColorPrin, int Stagevalt, int FabricPending_Orders_Id, Boolean finlized)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_PendingOrderSummary";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StagesCount", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = StagesCount;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OrderDetailID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@fabricMasterID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricMasterID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ColorPrin;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Stageval", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Stagevalt;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricPending_Orders_Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = FabricPending_Orders_Id;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ISfinlized", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = finlized;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }

        //--------------Edit by surendra on Lock down crona virus spread time for Auto stock Allocated.................
        public bool AutoAllocate_Fabric_From_Stock(int OrderDetailID, int fabricMasterID, string ColorPrin, int Stage1, int Stage2, int Stage3, int Stage4,bool Checked)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_AutoAllocate_Fabric_From_Stock";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@FirstSelection", SqlDbType.Int);
                    param.Value = Stage1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SecondSelection", SqlDbType.Int);
                    param.Value = Stage2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ThirdSelection", SqlDbType.Int);
                    param.Value = Stage3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FourthSelection", SqlDbType.Int);
                    param.Value = Stage4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OrderDetailID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric_QualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricMasterID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric_Details", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ColorPrin;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedCheckBox", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Checked;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        //---------------End by surendra on Lock down crona virus spread time for Auto stock Allocated.................

        public bool updatePendingGreigeOrdersSupplier(string flag, int Fabric_MasterID, float QuotedLandedRate, int Supplier_master_ID, int SupplierGreigedOrder_Id, int fabQtyID, string FabricDetails,int DeliveryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "GetFabricCutWithGsm";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric_MasterID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Fabric_MasterID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QuotedLandedRate", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QuotedLandedRate;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = LeadTimes;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@Supplier_master_ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Supplier_master_ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierGreigedOrder_Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SupplierGreigedOrder_Id;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@fabQtyID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabQtyID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = FabricDetails;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = DeliveryType;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();


                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool UpdateQuatationEmbellishmentVA(string flag, int QualityID, int VAID, float QuotedLandedRate,  int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetVaSupplierQuotation";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QualityID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VAID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = VAID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Styleid;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@QuotedLandedRate", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QuotedLandedRate;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = LeadTimes;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = @SuppliermasterID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricdetails;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@stage1", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage1;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage2", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage2;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage3", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@stage4", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage4;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = DeliveryType;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool UpdateQuatationDayedVA(string flag, int QualityID, int VAID, float QuotedLandedRate,int SuppliermasterID, string fabricdetails, int Styleid,int DeliveryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();


                    string cmdText = "Usp_GetVaSupplierQuotationDayed";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QualityID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VAID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = VAID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Styleid;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@QuotedLandedRate", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QuotedLandedRate;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = LeadTimes;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = @SuppliermasterID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricdetails;
                    cmd.Parameters.Add(param);

               

                    param = new SqlParameter("@DeliveryType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = DeliveryType;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool UpdateQuatationPrintVA(string flag, int QualityID, int VAID, float QuotedLandedRate,  int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_GetVaSupplierQuotationPrint";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QualityID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VAID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = VAID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Styleid;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@QuotedLandedRate", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QuotedLandedRate;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = LeadTimes;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SuppliermasterID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricdetails;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage1", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage1;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage2", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage2;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage3", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage4", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage4;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = DeliveryType;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool UpdateQuatationotherVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4,int DeliveryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_SupplierQuataionOtherVA";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QualityID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VAID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = VAID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Styleid;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@QuotedLandedRate", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QuotedLandedRate;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = LeadTimes;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = @SuppliermasterID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricdetails;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage1", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage1;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage2", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage2;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage3", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage4", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage4;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = DeliveryType;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
        public bool UpdateQuatationStyleBasedVA(string flag, int QualityID, int VAID, float QuotedLandedRate, int LeadTimes, int SuppliermasterID, string fabricdetails, int Styleid, int stage1, int stage2, int stage3, int stage4)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_SupplierQuataionOtherStyleVA";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QualityID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QualityID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VAID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = VAID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Styleid;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@QuotedLandedRate", SqlDbType.Float);
                    param.Direction = ParameterDirection.Input;
                    param.Value = QuotedLandedRate;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //param.Value = LeadTimes;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@SuppliermasterID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = @SuppliermasterID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = fabricdetails;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage1", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage1;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage2", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage2;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage3", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage4", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = stage4;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return true;
        }
    }
}
