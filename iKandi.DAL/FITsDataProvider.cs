using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;
using System.Collections;

namespace iKandi.DAL
{
    public class FITsDataProvider : BaseDataProvider
    {
        # region Construtor

        public FITsDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Create Fits

        public Fits CreateFits(Fits objFits, bool isIkandiUser)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_fits_insert_fits";
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

                    paramIn = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    paramIn.Value = objFits.StyleCodeVersion;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    paramIn.Value = objFits.Department.DeptID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StcApproved", SqlDbType.Bit);
                    paramIn.Value = objFits.IsStcApproved;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Comments", SqlDbType.VarChar);
                    paramIn.Value = objFits.Comments;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    paramIn.Value = objFits.FilePath;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SealDate", SqlDbType.DateTime);

                    //
                    if ((objFits.SealDate == DateTime.MinValue) || (objFits.SealDate == Convert.ToDateTime("1753-01-01")) || (objFits.SealDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SealDate;
                    }
                    //
                    //

                    //  paramIn.Value = Convert.ToDateTime("1/1/0001");
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SampleTrackingDate", SqlDbType.DateTime);
                    if ((objFits.SampleTrackingDate == DateTime.MinValue) || (objFits.SampleTrackingDate == Convert.ToDateTime("1753-01-01")) || (objFits.SampleTrackingDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SampleTrackingDate;
                    }
                    //  paramIn.Value = objFits.SampleTrackingDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsURL", SqlDbType.VarChar);
                    paramIn.Value = objFits.SpecsURL;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsUploadDate", SqlDbType.DateTime);
                    if ((objFits.SpecsUploadDate == DateTime.MinValue) || (objFits.SpecsUploadDate == Convert.ToDateTime("1753-01-01")) || (objFits.SpecsUploadDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SpecsUploadDate;
                    }
                    // paramIn.Value = objFits.SpecsUploadDate;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    objFits.Id = Convert.ToInt32(paramOut.Value);

                    if (objFits.Id > 0)
                    {

                        foreach (FitsTrack objFitsTrack in objFits.FitsTrack)
                        {
                            objFitsTrack.Fits = objFits;

                            if (isIkandiUser == true)
                            {
                                CreateFitsTrack(objFitsTrack, cnx, transaction);
                                if (objFitsTrack.SuggestedFitDate <= Convert.ToDateTime("1/1/0001").AddDays(8))
                                {
                                    objFitsTrack.SuggestedFitDate = GetNextDate(objFitsTrack.NextPlannedDate, objFits.Department);
                                }
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
            return objFits;
        }

        public DataTable GetAllClient(string sStyleCodeVersion)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "SELECT DISTINCT CompanyName, ClientId FROM client WHERE ClientId IN (SELECT ClientID FROM v_styles WHERE StyleCodeVersion = '" + sStyleCodeVersion + "')";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }

        public DataTable GetAllDepartment(string sStyleCodeVersion, int iClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "SELECT DISTINCT DepartmentName, Id FROM client_department WHERE ClientID = " + iClientId + " AND Id IN (SELECT DepartmentID FROM v_styles WHERE StyleCodeVersion = '" + sStyleCodeVersion + "')";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }

        public DataTable GetStyleDetails(string sStyleCodeVersion)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "select * from v_styles where v_styles.StyleCodeVersion='" + sStyleCodeVersion + "'";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        public Fits CreateNewFits(Fits objFits)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_fits_insert_new_fits_operation";
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

                    paramIn = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    paramIn.Value = objFits.StyleCodeVersion;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    paramIn.Value = objFits.Department.DeptID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StcApproved", SqlDbType.Bit);
                    paramIn.Value = objFits.IsStcApproved;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Comments", SqlDbType.VarChar);
                    paramIn.Value = objFits.Comments;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    paramIn.Value = objFits.FilePath;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SealDate", SqlDbType.DateTime);
                    paramIn.Value = objFits.SealDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SampleTrackingDate", SqlDbType.DateTime);
                    paramIn.Value = objFits.SampleTrackingDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsURL", SqlDbType.VarChar);
                    paramIn.Value = objFits.SpecsURL;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsUploadDate", SqlDbType.DateTime);
                    paramIn.Value = objFits.SpecsUploadDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FitsStyleCodeDropdownValue", SqlDbType.VarChar);
                    paramIn.Value = objFits.FitsStyleCodeDropdownValue;
                    paramIn.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    objFits.Id = Convert.ToInt32(paramOut.Value);

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
            return objFits;
        }

        public Fits FitsFitsTrackOperations(Fits objFits)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_fits_fitstrack_new_fits_operation";
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

                    paramIn = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    paramIn.Value = objFits.StyleCodeVersion;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    paramIn.Value = objFits.Department.DeptID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FitsStyleCodeDropdownValue", SqlDbType.VarChar);
                    paramIn.Value = objFits.FitsStyleCodeDropdownValue;
                    paramIn.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();

                    if (Convert.ToString(paramOut.Value) == "")
                        objFits.Id = 1;

                    else
                        objFits.Id = Convert.ToInt32(paramOut.Value);

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
            return objFits;
        }


        private void CreateFitsTrack(FitsTrack objFitsTrack, SqlConnection cnx, SqlTransaction transaction)
        {
            // Create a SQL command object
            string cmdText = "sp_fits_track_insert_fits_track";
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

            paramIn = new SqlParameter("@FitsID", SqlDbType.Int);
            paramIn.Value = objFitsTrack.Fits.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ActualDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.ActualDispatchDate == DateTime.MinValue) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.ActualDispatchDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@CommentsSentFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.CommentsSentFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.FilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@BiplFilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.BiplFilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@NextPlannedDate", SqlDbType.DateTime);
            if ((objFitsTrack.NextPlannedDate == DateTime.MinValue) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.NextPlannedDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlannedDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.PlannedDispatchDate == DateTime.MinValue) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.PlannedDispatchDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlanningFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.PlanningFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@RequiredSample", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.RequiredSample;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AcknowledgeTick", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.AcknowledgeTick;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@SuggestedFitDate", SqlDbType.DateTime);
            if ((objFitsTrack.SuggestedFitDate == DateTime.MinValue) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.SuggestedFitDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FitsRequestedOn", SqlDbType.DateTime);
            paramIn.Value = DateTime.Now;
            cmd.Parameters.Add(paramIn);


            cmd.ExecuteNonQuery();
            objFitsTrack.Id = Convert.ToInt32(paramOut.Value);
        }

        public GarmentTesting CreateGarmentTesting(GarmentTesting objGarmentTesting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_garment_testing_insert_garment_testing";
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

                    paramIn = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    paramIn.Value = objGarmentTesting.OrderDetail.OrderDetailID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReportCompletionDate", SqlDbType.DateTime);
                    paramIn.Value = objGarmentTesting.ReportCompletionDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TestingCompletionDate", SqlDbType.DateTime);
                    paramIn.Value = objGarmentTesting.TestingCompletionDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Status", SqlDbType.Bit);
                    paramIn.Value = objGarmentTesting.Status;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    objGarmentTesting.Id = Convert.ToInt32(paramOut.Value);

                    if (objGarmentTesting.Id > 0)
                    {
                        foreach (GarmentTestingUploadedReport objGarmentTestingUploadedReport in objGarmentTesting.GarmentTestingUploadedReport)
                        {
                            objGarmentTestingUploadedReport.GarmentTesting = objGarmentTesting;
                            CreateGarmentTestingUploadedReport(objGarmentTestingUploadedReport, (int)GarmentTestingReport.GarmentTest, cnx, transaction);
                        }

                        foreach (GarmentTestingUploadedReport objGarmentTestingUploadedReport in objGarmentTesting.GarmentTestingUploadedReport)
                        {
                            objGarmentTestingUploadedReport.GarmentTesting = objGarmentTesting;
                            CreateGarmentTestingUploadedReport(objGarmentTestingUploadedReport, (int)GarmentTestingReport.BulkTest, cnx, transaction);
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
            return objGarmentTesting;
        }

        private void CreateGarmentTestingUploadedReport(GarmentTestingUploadedReport objGarmentTestingUploadedReport, int Type, SqlConnection cnx, SqlTransaction transaction)
        {
            // Create a SQL command object
            string cmdText = "sp_garment_testing_uploaded_report_insert_garment_testing_track";
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

            paramIn = new SqlParameter("@UploadedReportFilePath", SqlDbType.VarChar);
            paramIn.Value = objGarmentTestingUploadedReport.UploadedReportFilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@GarmentTestingID", SqlDbType.Int);
            paramIn.Value = objGarmentTestingUploadedReport.GarmentTesting.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Type", SqlDbType.Int);
            paramIn.Value = Type;
            cmd.Parameters.Add(paramIn);

            cmd.ExecuteNonQuery();
            objGarmentTestingUploadedReport.Id = Convert.ToInt32(paramOut.Value);
        }

        //public Fits CreateFitsBeforeOrder(Fits objFits)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        SqlTransaction transaction = null;

        //        try
        //        {
        //            cnx.Open();
        //            transaction = cnx.BeginTransaction();

        //            // Create a SQL command object
        //            string cmdText = "sp_fits_insert_fits_before_order";
        //            SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //            cmd.Transaction = transaction;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //            // Add parameters
        //            SqlParameter paramOut;
        //            SqlParameter paramIn;

        //            paramOut = new SqlParameter("@d", SqlDbType.Int);
        //            paramOut.Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(paramOut);

        //            paramIn = new SqlParameter("@StyleNumber", SqlDbType.Int);
        //            paramIn.Value = objFits.StyleNumber;
        //            cmd.Parameters.Add(paramIn);

        //            paramIn = new SqlParameter("@DepartmentID", SqlDbType.Int);
        //            paramIn.Value = objFits.Department.DeptID;
        //            cmd.Parameters.Add(paramIn);

        //            paramIn = new SqlParameter("@SealDate", SqlDbType.DateTime);
        //            paramIn.Value = Convert.ToDateTime("1/1/0001");
        //            cmd.Parameters.Add(paramIn);

        //            cmd.ExecuteNonQuery();
        //            objFits.Id = Convert.ToInt32(paramOut.Value);
        //            if (objFits.Id > 0)
        //                transaction.Commit();
        //        }
        //        catch (SqlException ex)
        //        {
        //            transaction.Rollback();
        //            throw ex;
        //        }
        //        finally
        //        {
        //            cnx.Close();
        //        }

        //    }
        //    return objFits;
        //}

        #endregion

        #region Update Fits

        public Fits UpdateFits(Fits objFits, bool isIkandiUser)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_fits_update_fits";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters                    
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@d", SqlDbType.Int);
                    paramIn.Value = objFits.Id;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    paramIn.Value = objFits.StyleCodeVersion;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    paramIn.Value = objFits.Department.DeptID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StcApproved", SqlDbType.Bit);
                    paramIn.Value = objFits.IsStcApproved;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Comments", SqlDbType.VarChar);
                    paramIn.Value = objFits.Comments;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    paramIn.Value = objFits.FilePath;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SealDate", SqlDbType.DateTime);
                    if ((objFits.SealDate == DateTime.MinValue) || (objFits.SealDate == Convert.ToDateTime("1753-01-01")) || (objFits.SealDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SealDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SampleTrackingDate", SqlDbType.DateTime);
                    if ((objFits.SampleTrackingDate == DateTime.MinValue) || (objFits.SampleTrackingDate == Convert.ToDateTime("1753-01-01")) || (objFits.SampleTrackingDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SampleTrackingDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsURL", SqlDbType.VarChar);
                    paramIn.Value = objFits.SpecsURL;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsUploadDate", SqlDbType.DateTime);
                    if ((objFits.SpecsUploadDate == DateTime.MinValue) || (objFits.SpecsUploadDate == Convert.ToDateTime("1753-01-01")) || (objFits.SpecsUploadDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SpecsUploadDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();

                    if (objFits.Id > 0)
                    {
                        foreach (FitsTrack objFitsTrack in objFits.FitsTrack)
                        {
                            objFitsTrack.Fits = objFits;
                            if (objFitsTrack.Id > 0)
                            {
                                UpdateFitsTrack(objFitsTrack, cnx, transaction);
                                if (objFitsTrack.SuggestedFitDate <= Convert.ToDateTime("1/1/0001").AddDays(8))
                                {
                                    objFitsTrack.SuggestedFitDate = GetNextDate(objFitsTrack.NextPlannedDate, objFits.Department);
                                }
                            }
                            else
                            {
                                if (isIkandiUser == true)
                                {
                                    CreateFitsTrack(objFitsTrack, cnx, transaction);

                                    if (objFitsTrack.SuggestedFitDate <= Convert.ToDateTime("1/1/0001").AddDays(8))
                                    {
                                        objFitsTrack.SuggestedFitDate = GetNextDate(objFitsTrack.NextPlannedDate, objFits.Department);
                                    }
                                }
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
            return objFits;
        }

        private void UpdateFitsTrack(FitsTrack objFitsTrack, SqlConnection cnx, SqlTransaction transaction)
        {
            // Create a SQL command object
            string cmdText = "sp_fits_track_update_fits_track";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters            
            SqlParameter paramIn;

            paramIn = new SqlParameter("@d", SqlDbType.Int);
            paramIn.Value = objFitsTrack.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FitsID", SqlDbType.Int);
            paramIn.Value = objFitsTrack.Fits.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ActualDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.ActualDispatchDate == DateTime.MinValue) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.ActualDispatchDate;
            }

            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@CommentsSentFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.CommentsSentFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.FilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@BiplFilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.BiplFilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@NextPlannedDate", SqlDbType.DateTime);
            if ((objFitsTrack.NextPlannedDate == DateTime.MinValue) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.NextPlannedDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlannedDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.PlannedDispatchDate == DateTime.MinValue) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.PlannedDispatchDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlanningFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.PlanningFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@RequiredSample", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.RequiredSample;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AcknowledgeTick", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.AcknowledgeTick;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@SuggestedFitDate", SqlDbType.DateTime);
            if ((objFitsTrack.SuggestedFitDate == DateTime.MinValue) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.SuggestedFitDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AckTime", SqlDbType.DateTime);
            if ((objFitsTrack.AckDate == DateTime.MinValue) || (objFitsTrack.AckDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.AckDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.AckDate;
            }
            cmd.Parameters.Add(paramIn);

            cmd.ExecuteNonQuery();
        }

        //public void UpdateFitsTarck(String StyleNo, String DeptName, DateTime CourierSentOn)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        SqlTransaction transaction = null;

        //        try
        //        {
        //            cnx.Open();
        //            transaction = cnx.BeginTransaction();

        //            // Create a SQL command object                                       

        //            string cmdText = "sp_fits_track_update_fits_track_style_deptname";
        //            SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //            cmd.Transaction = transaction;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //            SqlParameter param = new SqlParameter("@StyleNo", SqlDbType.Int);
        //            param.Value = StyleNo;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@DeptName", SqlDbType.Int);
        //            param.Value = DeptName;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
        //            param.Value = DeptName;
        //            cmd.Parameters.Add(param);

        //            cmd.ExecuteNonQuery();

        //            transaction.Commit();
        //        }
        //        catch (SqlException ex)
        //        {
        //            transaction.Rollback();
        //            throw ex;
        //        }
        //        finally
        //        {
        //            cnx.Close();
        //        }
        //    }
        //}

        public GarmentTesting UpdateGarmentTesting(GarmentTesting objGarmentTesting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_garment_testing_update_garment_testing";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters                    
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@d", SqlDbType.Int);
                    paramIn.Value = objGarmentTesting.Id;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    paramIn.Value = objGarmentTesting.OrderDetail.OrderDetailID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReportCompletionDate", SqlDbType.DateTime);
                    paramIn.Value = objGarmentTesting.ReportCompletionDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@TestingCompletionDate", SqlDbType.DateTime);
                    paramIn.Value = objGarmentTesting.TestingCompletionDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Status", SqlDbType.Bit);
                    paramIn.Value = objGarmentTesting.Status;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();

                    if (objGarmentTesting.Id > 0)
                    {
                        foreach (GarmentTestingUploadedReport objGarmentTestingUploadedReport in objGarmentTesting.GarmentTestingUploadedReport)
                        {
                            objGarmentTestingUploadedReport.GarmentTesting = objGarmentTesting;
                            //if (objGarmentTestingUploadedReport.Id > 0)
                            //{
                            //    UpdateGarmentTestingUploadedReport(objGarmentTestingUploadedReport, cnx, transaction);
                            //}
                            //else
                            //{
                            CreateGarmentTestingUploadedReport(objGarmentTestingUploadedReport, (int)GarmentTestingReport.GarmentTest, cnx, transaction);
                            //}
                        }

                        foreach (GarmentTestingUploadedReport objGarmentTestingUploadedReport in objGarmentTesting.BulkTestingUploadedReport)
                        {
                            objGarmentTestingUploadedReport.GarmentTesting = objGarmentTesting;
                            //if (objGarmentTestingUploadedReport.Id > 0)
                            //{
                            //    UpdateGarmentTestingUploadedReport(objGarmentTestingUploadedReport, cnx, transaction);
                            //}
                            //else
                            //{
                            CreateGarmentTestingUploadedReport(objGarmentTestingUploadedReport, (int)GarmentTestingReport.BulkTest, cnx, transaction);
                            //}
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
            return objGarmentTesting;
        }

        private void UpdateGarmentTestingUploadedReport(GarmentTestingUploadedReport objGarmentTestingUploadedReport, SqlConnection cnx, SqlTransaction transaction)
        {
            // Create a SQL command object
            string cmdText = "sp_garment_testing_uploaded_report_update_garment_testing_track";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters

            SqlParameter paramIn;

            paramIn = new SqlParameter("@d", SqlDbType.Int);
            paramIn.Value = objGarmentTestingUploadedReport.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@UploadedReportFile", SqlDbType.VarChar);
            paramIn.Value = objGarmentTestingUploadedReport.UploadedReportFilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@GarmentTestingID", SqlDbType.Int);
            paramIn.Value = objGarmentTestingUploadedReport.GarmentTesting.Id;
            cmd.Parameters.Add(paramIn);

            cmd.ExecuteNonQuery();
        }
                
        // Add By Ravi kumar For Reschedule Pattern on 20-Apr-2017
        public bool Update_Reschedule_StyleToPattern(SamplePattern objSamplePattern, int UserId, string Type)
        {
            bool returntype;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "sp_Update_Reschedule_StyleToPattern";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@CadMasterId", SqlDbType.Int);
                    param.Value = objSamplePattern.CADMasterRoleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PrevCadMasterId", SqlDbType.Int);
                    param.Value = objSamplePattern.PrevCadMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = objSamplePattern.Styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PrevStyleId", SqlDbType.Int);
                    param.Value = objSamplePattern.PrevStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NextStyleId", SqlDbType.Int);
                    param.Value = objSamplePattern.NextStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SequenceId", SqlDbType.Int);
                    param.Value = objSamplePattern.SequenceId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PrevSequenceId", SqlDbType.Int);
                    param.Value = objSamplePattern.PrevSequenceId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NextSequenceId", SqlDbType.Int);
                    param.Value = objSamplePattern.NextSequenceId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AllocationDate", SqlDbType.Date);
                    param.Value = objSamplePattern.AllocationDate;
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

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    returntype = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                returntype = false;
            }

            return returntype;
        }
        // End By Ravi kumar For Reschedule Pattern on 20-Apr-2017

        // Add By Ravi kumar For Save Sampling Fits Cycle flow on 5-May-2017
        public string SaveSamplingFitsCycleFlow(SamplePattern objSamplePattern, int UserId, bool IsBiplUser, bool IsIkandiUser, int ReUse, int ReUseStyleId)
        {
            string error = "";
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "sp_SaveSamplingFitsCycleFlow";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = objSamplePattern.Styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = objSamplePattern.ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = objSamplePattern.ClientDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.VarChar);
                    param.Value = objSamplePattern.Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsQC", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsQCPresent;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MasterQCId", SqlDbType.Int);
                    param.Value = objSamplePattern.QCMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsSentFor", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsSentFor;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsPlanningFor", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsPlanningFor;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsUpload", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsCommentUpload;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsUpload_New", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsCommentUpload_New;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsRefSample", SqlDbType.Bit);
                    param.Value = objSamplePattern.ReqRefSample;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsHandover", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsHandOver;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HandoverDate", SqlDbType.Date);
                    if (objSamplePattern.HandOverActDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objSamplePattern.HandOverActDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsPatternReady", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsPatternReady;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatternReadyDate", SqlDbType.Date);
                    if (objSamplePattern.PatternReadyActualDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objSamplePattern.PatternReadyActualDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsSampleSent", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsSampleSent;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleSentDate", SqlDbType.Date);
                    if (objSamplePattern.SampleSentActualDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objSamplePattern.SampleSentActualDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleUpload", SqlDbType.VarChar);
                    param.Value = objSamplePattern.SampleUpload;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleUpload_New", SqlDbType.VarChar);
                    param.Value = objSamplePattern.SampleUpload_New;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StcApproved", SqlDbType.Bit);
                    param.Value = objSamplePattern.StcApproved;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comment", SqlDbType.VarChar, 1000);
                    param.Value = objSamplePattern.Commentes;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsIkandiClient", SqlDbType.Int);
                    param.Value = objSamplePattern.IsIkandiClient;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsIkandiUser", SqlDbType.Bit);
                    param.Value = IsIkandiUser;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsBiplUser", SqlDbType.Bit);
                    param.Value = IsBiplUser;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@HandoverActDate", SqlDbType.Date);
                    //param.Value = HandoverActDate;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@PatternActDate", SqlDbType.Date);
                    //param.Value = PatternActDate;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@SampleActDate", SqlDbType.Date);
                    //param.Value = SampleActDate;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@Error", SqlDbType.VarChar, 1000);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    error = cmd.Parameters["@Error"].Value.ToString();   
                    //cmd.ExecuteNonQuery();
                    //cnx.Close();
                    //returntype = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
            }

            return error;
        }
        public string SaveSamplingFitsCycleFlow_PreOrder(SamplePattern objSamplePattern, int UserId, bool IsBiplUser, bool IsIkandiUser, int ReUse, int ReUseStyleId)
        {
            string error = "";
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "sp_SaveSamplingFitsCycleFlow_PreOrder";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = objSamplePattern.Styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = objSamplePattern.ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = objSamplePattern.ClientDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.VarChar);
                    param.Value = objSamplePattern.Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsQC", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsQCPresent;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MasterQCId", SqlDbType.Int);
                    param.Value = objSamplePattern.QCMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsSentFor", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsSentFor;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsPlanningFor", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsPlanningFor;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsUpload", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsCommentUpload;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FitsUpload_New", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsCommentUpload_New;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsRefSample", SqlDbType.Bit);
                    param.Value = objSamplePattern.ReqRefSample;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsHandover", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsHandOver;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HandoverDate", SqlDbType.Date);
                    if (objSamplePattern.HandOverActDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objSamplePattern.HandOverActDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsPatternReady", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsPatternReady;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatternReadyDate", SqlDbType.Date);
                    if (objSamplePattern.PatternReadyActualDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objSamplePattern.PatternReadyActualDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsSampleSent", SqlDbType.Bit);
                    param.Value = objSamplePattern.IsSampleSent;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleSentDate", SqlDbType.Date);
                    if (objSamplePattern.SampleSentActualDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objSamplePattern.SampleSentActualDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleUpload", SqlDbType.VarChar);
                    param.Value = objSamplePattern.SampleUpload;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleUpload_New", SqlDbType.VarChar);
                    param.Value = objSamplePattern.SampleUpload_New;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StcApproved", SqlDbType.Bit);
                    param.Value = objSamplePattern.StcApproved;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comment", SqlDbType.VarChar, 1000);
                    param.Value = objSamplePattern.Commentes;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsIkandiClient", SqlDbType.Int);
                    param.Value = objSamplePattern.IsIkandiClient;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsIkandiUser", SqlDbType.Bit);
                    param.Value = IsIkandiUser;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsBiplUser", SqlDbType.Bit);
                    param.Value = IsBiplUser;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@HandoverActDate", SqlDbType.Date);
                    //param.Value = HandoverActDate;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@PatternActDate", SqlDbType.Date);
                    //param.Value = PatternActDate;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@PDDecesion", SqlDbType.VarChar);
                    param.Value = objSamplePattern.PDDecesion;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HandoverFileUpload", SqlDbType.VarChar);
                    param.Value = objSamplePattern.FitsCommentUpload_New;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Error", SqlDbType.VarChar, 1000);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    error = cmd.Parameters["@Error"].Value.ToString();
                    //cmd.ExecuteNonQuery();
                    //cnx.Close();
                    //returntype = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
            }

            return error;
        }
        // End By Ravi kumar For Save Sampling Fits Cycle flow on 5-May-2017

        // Add By Ravi kumar For Re use Fits cycle flow on 1-June-2017
        public bool ReUseSamplingFitsCycleFlow(int StyleId, int ReUse, int UserId, string status)
        {
            bool returntype;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "usp_ReUseSamplingFitsCycleFlow";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Bit);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.VarChar);
                    param.Value = status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);                    

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    returntype = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                returntype = false;
            }

            return returntype;
        }
        // End By Ravi kumar For Re use Fits cycle flow on 1-June-2017

        #endregion

        #region Get Fits

        public Fits GetFITsBasicInfo(string styleCodeVersion, Int32 departmentId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_get_fits_basic_info";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCodeVersion", SqlDbType.VarChar);
                param.Value = styleCodeVersion;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = departmentId;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Fits fits = new Fits();

                while (reader.Read())
                {
                    fits.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    fits.SpecsURL = (reader["SpecsURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SpecsURL"]);
                    fits.SampleTrackingDate = (reader["SampleTrackingDate"] == DBNull.Value) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(reader["SampleTrackingDate"]);
                    fits.SpecsUploadDate = (reader["SpecsUploadDate"] == DBNull.Value) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(reader["SpecsUploadDate"]);
                    fits.StyleCodeVersion = (reader["StyleNumber"] != DBNull.Value) ? Convert.ToString(reader["StyleNumber"]) : string.Empty;

                    fits.Department = new ClientDepartment();
                    fits.Department.DeptID = (reader["DepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["DepartmentID"]) : 0;
                    fits.Department.Mon = (reader["Mon"] != DBNull.Value) ? Convert.ToInt32(reader["Mon"]) : 0;
                    fits.Department.Tue = (reader["Tue"] != DBNull.Value) ? Convert.ToInt32(reader["Tue"]) : 0;
                    fits.Department.Wed = (reader["Wed"] != DBNull.Value) ? Convert.ToInt32(reader["Wed"]) : 0;
                    fits.Department.Thu = (reader["Thu"] != DBNull.Value) ? Convert.ToInt32(reader["Thu"]) : 0;
                    fits.Department.Fri = (reader["Fri"] != DBNull.Value) ? Convert.ToInt32(reader["Fri"]) : 0;
                    fits.IsStcApproved = (reader["StcApproved"] != DBNull.Value) ? Convert.ToBoolean(reader["StcApproved"]) : false;
                    fits.Comments = (reader["Comments"] != DBNull.Value) ? Convert.ToString(reader["Comments"]) : String.Empty;
                    fits.FilePath = (reader["FilePath"] != DBNull.Value) ? Convert.ToString(reader["FilePath"]) : String.Empty;
                    fits.SealDate = (reader["SealDate"] != DBNull.Value) ? Convert.ToDateTime(reader["SealDate"]) : Convert.ToDateTime("1/1/0001");
                    fits.FitsTrack = GetFITsTrack(fits.Id, fits.Department);
                }
                return fits;
            }
        }
        public Fits GetFITsBasicInfo_ForOrderProcess(string styleCodeVersion, Int32 departmentId, int StyleId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, int Save)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_get_fits_basic_info_ForOrderProcess";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCodeVersion", SqlDbType.VarChar);
                param.Value = styleCodeVersion;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = departmentId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateNew", SqlDbType.Int);
                param.Value = CreateNew;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NewRef", SqlDbType.Int);
                param.Value = NewRef;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUse", SqlDbType.Int);
                param.Value = ReUse;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                param.Value = ReUseStyleId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Save", SqlDbType.Int);
                param.Value = Save;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Fits fits = new Fits();

                while (reader.Read())
                {
                    fits.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    fits.SpecsURL = (reader["SpecsURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SpecsURL"]);
                    fits.SampleTrackingDate = (reader["SampleTrackingDate"] == DBNull.Value) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(reader["SampleTrackingDate"]);
                    fits.SpecsUploadDate = (reader["SpecsUploadDate"] == DBNull.Value) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(reader["SpecsUploadDate"]);
                    fits.StyleCodeVersion = (reader["StyleNumber"] != DBNull.Value) ? Convert.ToString(reader["StyleNumber"]) : string.Empty;

                    fits.Department = new ClientDepartment();
                    fits.Department.DeptID = (reader["DepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["DepartmentID"]) : 0;
                    fits.Department.Mon = (reader["Mon"] != DBNull.Value) ? Convert.ToInt32(reader["Mon"]) : 0;
                    fits.Department.Tue = (reader["Tue"] != DBNull.Value) ? Convert.ToInt32(reader["Tue"]) : 0;
                    fits.Department.Wed = (reader["Wed"] != DBNull.Value) ? Convert.ToInt32(reader["Wed"]) : 0;
                    fits.Department.Thu = (reader["Thu"] != DBNull.Value) ? Convert.ToInt32(reader["Thu"]) : 0;
                    fits.Department.Fri = (reader["Fri"] != DBNull.Value) ? Convert.ToInt32(reader["Fri"]) : 0;
                    fits.IsStcApproved = (reader["StcApproved"] != DBNull.Value) ? Convert.ToBoolean(reader["StcApproved"]) : false;
                    fits.Comments = (reader["Comments"] != DBNull.Value) ? Convert.ToString(reader["Comments"]) : String.Empty;
                    fits.FilePath = (reader["FilePath"] != DBNull.Value) ? Convert.ToString(reader["FilePath"]) : String.Empty;
                    fits.SealDate = (reader["SealDate"] != DBNull.Value) ? Convert.ToDateTime(reader["SealDate"]) : Convert.ToDateTime("1/1/0001");
                    fits.IsReUse = (reader["IsReuse"] != DBNull.Value) ? Convert.ToBoolean(reader["IsReuse"]) : false;
                    fits.FitsTrack = GetFITsTrack(fits.Id, fits.Department);
                }
                return fits;
            }
        }
        public DataSet GetFitsCodeVirsion(string StyleCode, int CreateNew)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsFitsVirsion = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetFitsCodeVirsion";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateNew", SqlDbType.Int);
                param.Value = CreateNew;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFitsVirsion);

                return dsFitsVirsion;
            }
        }
        public Fits CreateFitsForOrderProcess(Fits objFits, bool isIkandiUser, int StyleId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_fits_insert_fits_ForOrderProcess";
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

                    paramIn = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    paramIn.Value = objFits.StyleCodeVersion;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    paramIn.Value = objFits.Department.DeptID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StcApproved", SqlDbType.Bit);
                    paramIn.Value = objFits.IsStcApproved;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Comments", SqlDbType.VarChar);
                    paramIn.Value = objFits.Comments;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    paramIn.Value = objFits.FilePath;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SealDate", SqlDbType.DateTime);

                    //
                    if ((objFits.SealDate == DateTime.MinValue) || (objFits.SealDate == Convert.ToDateTime("1753-01-01")) || (objFits.SealDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SealDate;
                    }
                    //
                    //

                    //  paramIn.Value = Convert.ToDateTime("1/1/0001");
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SampleTrackingDate", SqlDbType.DateTime);
                    if ((objFits.SampleTrackingDate == DateTime.MinValue) || (objFits.SampleTrackingDate == Convert.ToDateTime("1753-01-01")) || (objFits.SampleTrackingDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SampleTrackingDate;
                    }
                    //  paramIn.Value = objFits.SampleTrackingDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsURL", SqlDbType.VarChar);
                    paramIn.Value = objFits.SpecsURL;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsUploadDate", SqlDbType.DateTime);
                    if ((objFits.SpecsUploadDate == DateTime.MinValue) || (objFits.SpecsUploadDate == Convert.ToDateTime("1753-01-01")) || (objFits.SpecsUploadDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SpecsUploadDate;
                    }
                    // paramIn.Value = objFits.SpecsUploadDate;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Styleid", SqlDbType.Int);
                    paramIn.Value = StyleId;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@CreateNew", SqlDbType.Int);
                    paramIn.Value = CreateNew;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReUse", SqlDbType.Int);
                    paramIn.Value = ReUse;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReUseStyleid", SqlDbType.Int);
                    paramIn.Value = ReUseStyleId;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    objFits.Id = Convert.ToInt32(paramOut.Value);

                    if (objFits.Id > 0)
                    {
                        if (objFits.FitsTrack != null)
                        {
                            foreach (FitsTrack objFitsTrack in objFits.FitsTrack)
                            {
                                objFitsTrack.Fits = objFits;

                                if (isIkandiUser == true)
                                {
                                    CreateFitsTrackForOrderProcess(objFitsTrack, cnx, transaction, StyleId, CreateNew, ReUse, ReUseStyleId);
                                    if (objFitsTrack.SuggestedFitDate <= Convert.ToDateTime("1/1/0001").AddDays(8))
                                    {
                                        objFitsTrack.SuggestedFitDate = GetNextDate(objFitsTrack.NextPlannedDate, objFits.Department);
                                    }
                                }
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
            return objFits;
        }
        // ADD by Ravi kumar For ReUse Fits on 22/5/2015
        private void CreateFitsTrackForOrderProcess(FitsTrack objFitsTrack, SqlConnection cnx, SqlTransaction transaction, int StyleId, int CreateNew, int ReUse, int ReUseStyleId)
        {
            // Create a SQL command object
            string cmdText = "sp_fits_track_insert_fits_track_ForOrderProcess";
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

            paramIn = new SqlParameter("@FitsID", SqlDbType.Int);
            paramIn.Value = objFitsTrack.Fits.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ActualDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.ActualDispatchDate == DateTime.MinValue) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.ActualDispatchDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@CommentsSentFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.CommentsSentFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.FilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@BiplFilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.BiplFilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@NextPlannedDate", SqlDbType.DateTime);
            if ((objFitsTrack.NextPlannedDate == DateTime.MinValue) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.NextPlannedDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlannedDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.PlannedDispatchDate == DateTime.MinValue) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.PlannedDispatchDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlanningFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.PlanningFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@RequiredSample", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.RequiredSample;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AcknowledgeTick", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.AcknowledgeTick;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@SuggestedFitDate", SqlDbType.DateTime);
            if ((objFitsTrack.SuggestedFitDate == DateTime.MinValue) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.SuggestedFitDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FitsRequestedOn", SqlDbType.DateTime);
            paramIn.Value = DateTime.Now;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@Styleid", SqlDbType.Int);
            paramIn.Value = StyleId;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@CreateNew", SqlDbType.Int);
            paramIn.Value = CreateNew;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ReUse", SqlDbType.Int);
            paramIn.Value = ReUse;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ReUseStyleid", SqlDbType.Int);
            paramIn.Value = ReUseStyleId;
            cmd.Parameters.Add(paramIn);


            cmd.ExecuteNonQuery();
            objFitsTrack.Id = Convert.ToInt32(paramOut.Value);
        }
        public bool ReUse_Fits_FitsTrackInsert(Fits objFits, int StyleId, int ReUseStyleId, int IsReUse, int NewRef, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_ReUse_Fits_FitsTrackInsert";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = objFits.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = objFits.StyleCodeVersion;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = objFits.Department.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                param.Value = ReUseStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUse", SqlDbType.Int);
                param.Value = IsReUse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NewRef", SqlDbType.Int);
                param.Value = NewRef;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            return true;
        }
        // Edit by surendra for Fits flow for pre order
        public bool BcheckIsGrading(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet dsBcheckIsGrading = new DataSet();
                string cmdText = "sp_CheckIsGrading";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsBcheckIsGrading);
                int a = Convert.ToInt32(dsBcheckIsGrading.Tables[0].Rows[0]["IsGrading"]);
                if (a == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
        public bool checkTechPacksOrDesign(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet dsBcheckIsGrading = new DataSet();
                string cmdText = "sp_checkTechPacksOrDesign";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsBcheckIsGrading);
                int a = Convert.ToInt32(dsBcheckIsGrading.Tables[0].Rows[0]["checkTechPacksOrDesign"]);
                if (a == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
        // end
        public bool ReUse_Fits_fits_track(int StyleId, int IsReUse)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_ReUse_Fits_fits_track";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUse", SqlDbType.Int);
                param.Value = IsReUse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            return true;
        }
        public Fits UpdateFits_ForOrderProcess(Fits objFits, bool isIkandiUser, int StyleId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    // Create a SQL command object
                    string cmdText = "sp_fits_update_fits_ForOrderProcess";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters                    
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@d", SqlDbType.Int);
                    paramIn.Value = objFits.Id;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    paramIn.Value = objFits.StyleCodeVersion;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    paramIn.Value = objFits.Department.DeptID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StcApproved", SqlDbType.Bit);
                    paramIn.Value = objFits.IsStcApproved;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Comments", SqlDbType.VarChar);
                    paramIn.Value = objFits.Comments;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    paramIn.Value = objFits.FilePath;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SealDate", SqlDbType.DateTime);
                    if ((objFits.SealDate == DateTime.MinValue) || (objFits.SealDate == Convert.ToDateTime("1753-01-01")) || (objFits.SealDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SealDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SampleTrackingDate", SqlDbType.DateTime);
                    if ((objFits.SampleTrackingDate == DateTime.MinValue) || (objFits.SampleTrackingDate == Convert.ToDateTime("1753-01-01")) || (objFits.SampleTrackingDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SampleTrackingDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsURL", SqlDbType.VarChar);
                    paramIn.Value = objFits.SpecsURL;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SpecsUploadDate", SqlDbType.DateTime);
                    if ((objFits.SpecsUploadDate == DateTime.MinValue) || (objFits.SpecsUploadDate == Convert.ToDateTime("1753-01-01")) || (objFits.SpecsUploadDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFits.SpecsUploadDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StyleId", SqlDbType.Int);
                    paramIn.Value = StyleId;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@CreateNew", SqlDbType.Int);
                    paramIn.Value = CreateNew;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReUse", SqlDbType.Int);
                    paramIn.Value = ReUse;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                    paramIn.Value = ReUseStyleId;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();

                    if (objFits.Id > 0)
                    {
                        foreach (FitsTrack objFitsTrack in objFits.FitsTrack)
                        {
                            objFitsTrack.Fits = objFits;

                            if (objFitsTrack.Id > 0)
                            {
                                UpdateFitsTrack_ForOrderProcess(objFitsTrack, cnx, transaction, StyleId, CreateNew, ReUse, ReUseStyleId);
                                
                                if (objFitsTrack.SuggestedFitDate <= Convert.ToDateTime("1/1/0001").AddDays(8))
                                {
                                    objFitsTrack.SuggestedFitDate = GetNextDate(objFitsTrack.NextPlannedDate, objFits.Department);
                                }
                            }

                            else
                            {

                                if (isIkandiUser == true)
                                {
                                    CreateFitsTrackForOrderProcess(objFitsTrack, cnx, transaction, StyleId, CreateNew, ReUse, ReUseStyleId);
                                    //createnew = 1;
                                    if (objFitsTrack.SuggestedFitDate <= Convert.ToDateTime("1/1/0001").AddDays(8))
                                    {
                                        objFitsTrack.SuggestedFitDate = GetNextDate(objFitsTrack.NextPlannedDate, objFits.Department);
                                    }
                                }
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
            return objFits;
        }
        public List<FitsTrack> GetFITsTrack(Int32 fitsId, ClientDepartment objClientDepartment)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_track_get_fits_track_basic_info";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@FitsID", SqlDbType.Int);
                param.Value = fitsId;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<FitsTrack> fitsTrackCollection = new List<FitsTrack>();

                while (reader.Read())
                {
                    FitsTrack fitsTrack = new FitsTrack();

                    fitsTrack.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    fitsTrack.Fits = new Fits();
                    fitsTrack.Fits.Id = fitsId;
                    fitsTrack.CommentsSentFor = (reader["CommentsSentFor"] != DBNull.Value) ? Convert.ToString(reader["CommentsSentFor"]) : String.Empty;
                    fitsTrack.NextPlannedDate = GetNextDate((reader["NextPlannedDate"] != DBNull.Value) ? Convert.ToDateTime(reader["NextPlannedDate"]) : Convert.ToDateTime("1/1/0001"), objClientDepartment);
                    fitsTrack.RequiredSample = (reader["RequiredSample"] != DBNull.Value) ? Convert.ToBoolean(reader["RequiredSample"]) : false;
                    fitsTrack.AcknowledgeTick = (reader["AcknowledgeTick"] != DBNull.Value) ? Convert.ToBoolean(reader["AcknowledgeTick"]) : false;
                    fitsTrack.FilePath = (reader["FilePath"] != DBNull.Value) ? Convert.ToString(reader["FilePath"]) : String.Empty;
                    fitsTrack.BiplFilePath = (reader["BiplFilePath"] != DBNull.Value) ? Convert.ToString(reader["BiplFilePath"]) : String.Empty;
                    fitsTrack.PlanningFor = (reader["PlanningFor"] != DBNull.Value) ? Convert.ToString(reader["PlanningFor"]) : String.Empty;
                    fitsTrack.PlannedDispatchDate = (reader["PlannedDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(reader["PlannedDispatchDate"]) : Convert.ToDateTime("1/1/0001");
                    fitsTrack.ActualDispatchDate = (reader["ActualDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualDispatchDate"]) : Convert.ToDateTime("1/1/0001");
                    fitsTrack.SuggestedFitDate = (reader["SuggestedFitDate"] != DBNull.Value) ? Convert.ToDateTime(reader["SuggestedFitDate"]) : Convert.ToDateTime("1/1/0001");
                    fitsTrack.AckDate = (reader["AckDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AckDate"]) : Convert.ToDateTime("1/1/0001");
                    //if (fitsTrack.SuggestedFitDate == Convert.ToDateTime("1/1/0001"))
                    //{
                    //    fitsTrack.SuggestedFitDate = fitsTrack.NextPlannedDate;
                    //}
                    fitsTrackCollection.Add(fitsTrack);
                }

                return fitsTrackCollection;
            }
        }
        private void UpdateFitsTrack_ForOrderProcess(FitsTrack objFitsTrack, SqlConnection cnx, SqlTransaction transaction, int StyleId, int CreateNew, int ReUse, int ReUseStyleId)
        {
            // Create a SQL command object
            string cmdText = "sp_fits_track_update_fits_track_ForOrderProcess";
            SqlCommand cmd = new SqlCommand(cmdText, cnx, transaction);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters            
            SqlParameter paramIn;

            paramIn = new SqlParameter("@d", SqlDbType.Int);
            paramIn.Value = objFitsTrack.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FitsID", SqlDbType.Int);
            paramIn.Value = objFitsTrack.Fits.Id;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ActualDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.ActualDispatchDate == DateTime.MinValue) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.ActualDispatchDate;
            }

            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@CommentsSentFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.CommentsSentFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.FilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@BiplFilePath", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.BiplFilePath;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@NextPlannedDate", SqlDbType.DateTime);
            if ((objFitsTrack.NextPlannedDate == DateTime.MinValue) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.NextPlannedDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlannedDispatchDate", SqlDbType.DateTime);
            if ((objFitsTrack.PlannedDispatchDate == DateTime.MinValue) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.PlannedDispatchDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@PlanningFor", SqlDbType.VarChar);
            paramIn.Value = objFitsTrack.PlanningFor;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@RequiredSample", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.RequiredSample;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AcknowledgeTick", SqlDbType.Bit);
            paramIn.Value = objFitsTrack.AcknowledgeTick;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@SuggestedFitDate", SqlDbType.DateTime);
            if ((objFitsTrack.SuggestedFitDate == DateTime.MinValue) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.SuggestedFitDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@AckTime", SqlDbType.DateTime);
            if ((objFitsTrack.AckDate == DateTime.MinValue) || (objFitsTrack.AckDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.AckDate == Convert.ToDateTime("1900-01-01")))
            {
                paramIn.Value = DBNull.Value;
            }
            else
            {
                paramIn.Value = objFitsTrack.AckDate;
            }
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@StyleId", SqlDbType.Int);
            paramIn.Value = StyleId;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@CreateNew", SqlDbType.Int);
            paramIn.Value = CreateNew;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ReUse", SqlDbType.Int);
            paramIn.Value = ReUse;
            cmd.Parameters.Add(paramIn);

            paramIn = new SqlParameter("@ReusestyleID", SqlDbType.Int);
            paramIn.Value = ReUseStyleId;
            cmd.Parameters.Add(paramIn);

            cmd.ExecuteNonQuery();
        }
        public bool NewRef_FitsTrackUpdate(Fits objFits, int StyleId, int ReUseStyleId, int IsReUse, int NewRef)
        {
            foreach (FitsTrack objFitsTrack in objFits.FitsTrack)
            {
                objFitsTrack.Fits = objFits;

                UpdateFitsTrack_ForOrderProcess_NewRef(objFitsTrack, StyleId, 0, 0, ReUseStyleId);

                if (objFitsTrack.SuggestedFitDate <= Convert.ToDateTime("1/1/0001").AddDays(8))
                {
                    objFitsTrack.SuggestedFitDate = GetNextDate(objFitsTrack.NextPlannedDate, objFits.Department);
                }
            }
            return true;
        }
        private void UpdateFitsTrack_ForOrderProcess_NewRef(FitsTrack objFitsTrack, int StyleId, int CreateNew, int ReUse, int ReUseStyleId)
        {
            // Create a SQL command object
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                //SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    //transaction = cnx.BeginTransaction();
                    string cmdText = "sp_fits_track_update_fits_track_ForOrderProcess";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters            
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@d", SqlDbType.Int);
                    paramIn.Value = objFitsTrack.Id;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FitsID", SqlDbType.Int);
                    paramIn.Value = objFitsTrack.Fits.Id;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ActualDispatchDate", SqlDbType.DateTime);
                    if ((objFitsTrack.ActualDispatchDate == DateTime.MinValue) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.ActualDispatchDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFitsTrack.ActualDispatchDate;
                    }

                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@CommentsSentFor", SqlDbType.VarChar);
                    paramIn.Value = objFitsTrack.CommentsSentFor;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    paramIn.Value = objFitsTrack.FilePath;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@BiplFilePath", SqlDbType.VarChar);
                    paramIn.Value = objFitsTrack.BiplFilePath;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@NextPlannedDate", SqlDbType.DateTime);
                    if ((objFitsTrack.NextPlannedDate == DateTime.MinValue) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.NextPlannedDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFitsTrack.NextPlannedDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@PlannedDispatchDate", SqlDbType.DateTime);
                    if ((objFitsTrack.PlannedDispatchDate == DateTime.MinValue) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.PlannedDispatchDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFitsTrack.PlannedDispatchDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@PlanningFor", SqlDbType.VarChar);
                    paramIn.Value = objFitsTrack.PlanningFor;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@RequiredSample", SqlDbType.Bit);
                    paramIn.Value = objFitsTrack.RequiredSample;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@AcknowledgeTick", SqlDbType.Bit);
                    paramIn.Value = objFitsTrack.AcknowledgeTick;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@SuggestedFitDate", SqlDbType.DateTime);
                    if ((objFitsTrack.SuggestedFitDate == DateTime.MinValue) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.SuggestedFitDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFitsTrack.SuggestedFitDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@AckTime", SqlDbType.DateTime);
                    if ((objFitsTrack.AckDate == DateTime.MinValue) || (objFitsTrack.AckDate == Convert.ToDateTime("1753-01-01")) || (objFitsTrack.AckDate == Convert.ToDateTime("1900-01-01")))
                    {
                        paramIn.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIn.Value = objFitsTrack.AckDate;
                    }
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StyleId", SqlDbType.Int);
                    paramIn.Value = StyleId;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@CreateNew", SqlDbType.Int);
                    paramIn.Value = CreateNew;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReUse", SqlDbType.Int);
                    paramIn.Value = ReUse;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                    paramIn.Value = ReUseStyleId;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
            }
        }

        //public FitsTrack GetFITsTrack(String StyleNo, String DeptName)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();

        //        SqlDataReader reader;
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "sp_fits_track_get_fits_track_style_deptname";
        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param = new SqlParameter("@StyleNo", SqlDbType.Int);
        //        param.Value = StyleNo;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@DeptName", SqlDbType.Int);
        //        param.Value = DeptName;
        //        cmd.Parameters.Add(param);

        //        reader = cmd.ExecuteReader();

        //        FitsTrack fitsTrack = new FitsTrack();

        //        while (reader.Read())
        //        {
        //            fitsTrack.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
        //        }

        //        return fitsTrack;
        //    }
        //}

        public List<GarmentTesting> GetGarmentTesting(Int32 StyleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_garment_testing_get_garment_testing_info";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.Int);
                param.Value = StyleNumber;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<GarmentTesting> objGarmentTesting = new List<GarmentTesting>();
                while (reader.Read())
                {
                    GarmentTesting garmentTesting = new GarmentTesting();
                    garmentTesting.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    garmentTesting.OrderDetail = new OrderDetail();
                    garmentTesting.OrderDetail.ParentOrder = new Order();
                    garmentTesting.OrderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] != DBNull.Value) ? Convert.ToString(reader["SerialNumber"]) : String.Empty;
                    garmentTesting.OrderDetail.LineItemNumber = (reader["LineItemNumber"] != DBNull.Value) ? Convert.ToString(reader["LineItemNumber"]) : String.Empty;
                    garmentTesting.OrderDetail.ContractNumber = (reader["ContractNumber"] != DBNull.Value) ? Convert.ToString(reader["ContractNumber"]) : String.Empty;
                    garmentTesting.OrderDetail.Fabric1 = (reader["Fabric1"] != DBNull.Value) ? Convert.ToString(reader["Fabric1"]) : String.Empty;
                    garmentTesting.OrderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : Convert.ToDateTime("1/1/0001");
                    garmentTesting.OrderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : Convert.ToDateTime("1/1/0001");
                    garmentTesting.OrderDetail.Mode = (reader["Mode"] != DBNull.Value) ? Convert.ToInt32(reader["Mode"]) : -0;
                    garmentTesting.OrderDetail.OrderDetailID = (reader["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(reader["OrderDetailID"]) : 0;
                    garmentTesting.OrderDetail.ParentOrder.OrderDate = (reader["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(reader["OrderDate"]) : Convert.ToDateTime("1/1/0001");
                    garmentTesting.ReportCompletionDate = (reader["ReportCompletionDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ReportCompletionDate"]) : Convert.ToDateTime("1/1/0001");
                    garmentTesting.TestingCompletionDate = (reader["BulkTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkTarget"]) : Convert.ToDateTime("1/1/0001");
                    garmentTesting.Status = (reader["Status"] != DBNull.Value) ? Convert.ToBoolean(reader["Status"]) : false;
                    garmentTesting.GarmentTestingUploadedReport = GetGarmentTestingUploadedReport(garmentTesting.Id, (Int16)GarmentTestingReport.GarmentTest);
                    garmentTesting.BulkTestingUploadedReport = GetBulkTestingUploadedReport(garmentTesting.Id, (Int16)GarmentTestingReport.BulkTest);
                    objGarmentTesting.Add(garmentTesting);
                }

                return objGarmentTesting;
            }
        }

        public List<BulkTestingUploadedReport> GetBulkTestingUploadedReport(Int32 garmentTestingId, int Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_garment_testing_uploaded_report_get_report_file";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@GarmentTestingId", SqlDbType.Int);
                param.Value = garmentTestingId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<BulkTestingUploadedReport> GarmentTestingUploadedReportCollection = new List<BulkTestingUploadedReport>();

                while (reader.Read())
                {
                    BulkTestingUploadedReport garmentTestingUploadedReport = new BulkTestingUploadedReport();

                    garmentTestingUploadedReport.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    garmentTestingUploadedReport.GarmentTesting = new GarmentTesting();
                    garmentTestingUploadedReport.GarmentTesting.Id = garmentTestingId;
                    garmentTestingUploadedReport.UploadedReportFilePath = (reader["UploadedReportPath"] != DBNull.Value) ? Convert.ToString(reader["UploadedReportPath"]) : String.Empty;
                    GarmentTestingUploadedReportCollection.Add(garmentTestingUploadedReport);
                }


                cnx.Close();

                return GarmentTestingUploadedReportCollection;
            }
        }

        public List<GarmentTestingUploadedReport> GetGarmentTestingUploadedReport(Int32 garmentTestingId, int Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_garment_testing_uploaded_report_get_report_file";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@GarmentTestingId", SqlDbType.Int);
                param.Value = garmentTestingId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<GarmentTestingUploadedReport> GarmentTestingUploadedReportCollection = new List<GarmentTestingUploadedReport>();

                while (reader.Read())
                {
                    GarmentTestingUploadedReport garmentTestingUploadedReport = new GarmentTestingUploadedReport();

                    garmentTestingUploadedReport.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    garmentTestingUploadedReport.GarmentTesting = new GarmentTesting();
                    garmentTestingUploadedReport.GarmentTesting.Id = garmentTestingId;
                    garmentTestingUploadedReport.UploadedReportFilePath = (reader["UploadedReportPath"] != DBNull.Value) ? Convert.ToString(reader["UploadedReportPath"]) : String.Empty;
                    GarmentTestingUploadedReportCollection.Add(garmentTestingUploadedReport);
                }

                cnx.Close();

                return GarmentTestingUploadedReportCollection;

            }
        }

        public SealerPending GetSealerPendingInfo(string styleNumber, Int32 departmentId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_sealer_pending_get_styleid_clientdepartmentid_info";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = styleNumber;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientDepartmentID", SqlDbType.Int);
                param.Value = departmentId;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                SealerPending sealerPending = new SealerPending();

                while (reader.Read())
                {

                    //  string StyleNumber = string.Empty;
                    //  if(reader["StyleNumber"]!=null)
                    //        StyleNumber = reader["StyleNumber"] != DBNull.Value
                    //   (reader["StyleNumber"] != DBNull.Value) ? Convert.ToInt32(reader["StyleNumber"]) : 0;
                    sealerPending.StyleNumber = (reader["StyleNumber"] != DBNull.Value) ? Convert.ToString(reader["StyleNumber"]) : String.Empty;
                    sealerPending.ClientDepartmentId = (reader["ClientDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientDepartmentID"]) : 0;
                    sealerPending.RemarksBIPL = (reader["RemarksBIPL"] != DBNull.Value) ? Convert.ToString(reader["RemarksBIPL"]) : String.Empty;
                    sealerPending.RemarksIKANDI = (reader["RemarksIKANDI"] != DBNull.Value) ? Convert.ToString(reader["RemarksIKANDI"]) : String.Empty;
                }

                return sealerPending;
            }
        }

        public DataSet GetFITsCommentsUploaded(DateTime CommentUploadedDate, int bcheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_get_all_comments_received_new";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@CommentsDate", SqlDbType.DateTime);
                param.Value = CommentUploadedDate;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Bcheck", SqlDbType.Int);
                param.Value = bcheck;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                cnx.Close();

                return dsOrders;
            }
        }

        private DateTime GetNextDate(DateTime dtNextPlanned, ClientDepartment objClientDepartment)
        {
            if (dtNextPlanned != Convert.ToDateTime("1/1/0001"))
            {
                return dtNextPlanned;
            }
            else
            {
                dtNextPlanned = DateTime.Now.AddDays(7);
            }

            ArrayList arr = new ArrayList();
            arr.Add(objClientDepartment.Mon);
            arr.Add(objClientDepartment.Tue);
            arr.Add(objClientDepartment.Wed);
            arr.Add(objClientDepartment.Thu);
            arr.Add(objClientDepartment.Fri);
            arr.Add("0");
            arr.Add("0");
            arr.Add(objClientDepartment.Mon);
            arr.Add(objClientDepartment.Tue);
            arr.Add(objClientDepartment.Wed);
            arr.Add(objClientDepartment.Thu);
            arr.Add(objClientDepartment.Fri);


            DateTime dt = dtNextPlanned;

            int i = Convert.ToInt32(Enum.Parse(DayOfWeek.Monday.GetType(), dtNextPlanned.DayOfWeek.ToString()));

            for (int l = i; l < arr.Count; l++)
            {
                if (arr[l].ToString() == "1")
                {
                    dt = dtNextPlanned.AddDays(l - i + 1);
                    break;
                }
            }

            return dt;
        }

        public DataSet GetFITsPendingComments()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_get_all_pending_comments";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                cnx.Close();

                return dsOrders;
            }
        }

        public DataSet GetFITsPendingComments_WithPrice(int bCheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_get_all_pending_forMail_ForNew";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@bCheck", SqlDbType.Int);
                param.Value = bCheck;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                cnx.Close();

                return dsOrders;
            }
        }

        public DataSet GetSamplePendingComments_WithPrice(int bcheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_sample_get_all_pending_forMail_New";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@bCheck", SqlDbType.Int);
                param.Value = bcheck;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                cnx.Close();

                return dsOrders;
            }
        }

        public Fits GetFitsByStyleCodeVersion(string StyleCodeVersion)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_get_fits_by_style_code_version";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCodeVersion", SqlDbType.VarChar);
                param.Value = StyleCodeVersion;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                Fits fits = new Fits();
                fits.Style = new Style();

                while (reader.Read())
                {
                    fits.Id = reader["Id"] == DBNull.Value ? -1 : Convert.ToInt32(reader["Id"]);
                    fits.StyleCodeVersion = Convert.ToString(reader["StyleNumber"]);
                    fits.SpecsURL = (reader["SpecsURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SpecsURL"]);
                    fits.SampleTrackingDate = (reader["SampleTrackingDate"] == DBNull.Value) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(reader["SampleTrackingDate"]);
                    fits.SpecsUploadDate = (reader["SpecsUploadDate"] == DBNull.Value) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(reader["SpecsUploadDate"]);
                    fits.Style.ClientID = (reader["ClientID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ClientID"]);
                    fits.Style.StyleNumber = (reader["CompleteStyleNumber"] == DBNull.Value) ? string.Empty : (reader["CompleteStyleNumber"]).ToString();
                    fits.Style.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DepartmentID"]);
                }
                return fits;
            }
        }

        public Boolean GetIsValidateStyleCodeByStyleNumber(string StyleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_validate_style_code";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    param.Value = StyleNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public bool GetSamplePendingComments_WithPrice_CheckIkandi(int bCheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_sample_get_all_pending_forMail_For_CheckBuyingHouse";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@bCheck", SqlDbType.Int);
                    param.Value = bCheck;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public bool GetAllOrderDeliveredTodayCompanyWise_CheckIkandi(DateTime date,int bCheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_sending_delivered_email_CompanyWise_CheckIkandi";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@Date", SqlDbType.DateTime);
                    param.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                     param = new SqlParameter("@bCheck", SqlDbType.Int);
                    param.Value = bCheck;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public bool GetOrderByCurrentDate_CheckIkandi(DateTime date, int bCheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_orders_get_order_by_currentDate_CheckIkandi";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@CurrentDate", SqlDbType.DateTime);
                    param.Value = date;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@bCheck", SqlDbType.Int);
                    param.Value = bCheck;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public bool GetFITsCommentsUploaded_CheckIkandi(DateTime dtCommentUploadedDate, int bCheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_fits_get_all_comments_received_CheckForNonIkandi";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@CommentsDate", SqlDbType.DateTime);
                    param.Value = dtCommentUploadedDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@bCheck", SqlDbType.Int);
                    param.Value = bCheck;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public bool GetFITsPendingComments_WithPrice_CheckIkandi(int bCheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_fits_get_all_pending_forMail_CheckIsIkandiorNot";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@bCheck", SqlDbType.Int);
                    param.Value = bCheck;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public List<Fits> GetFitsDropdownRelatedInformation(string StyleCodeVersion, int DepartmentID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fits_get_all_by_style_code_and_departmentid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCodeVersion", SqlDbType.VarChar);
                param.Value = StyleCodeVersion;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Fits> objFits = new List<Fits>();

                Fits fit1 = new Fits();
                fit1.StyleCodeVersion = "New Fit Process";
                objFits.Add(fit1);

                while (reader.Read())
                {
                    if (reader["StyleNumber"] != DBNull.Value)
                    {
                        Fits objFit = new Fits();
                        objFit.StyleCodeVersion = Convert.ToString(reader["StyleNumber"]);
                        objFits.Add(objFit);
                    }
                }                
                cnx.Close();

                return objFits;
            }
        }

        // Add By Ravi kumar For Reschedule Pattern on 19-Apr-2017

        public List<SamplePattern> GetReschedule_StyleToPattern(SamplePattern objSample, int UserId)
        {
            List<SamplePattern> objSamplePattern = new List<SamplePattern>();
            try
              {                
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {                
                    cnx.Open();
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetReschedule_StyleToPattern";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@Style", SqlDbType.VarChar);
                    param.Value = objSample.StyleNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FromDate", SqlDbType.Date);
                    if (objSample.FromDate != DateTime.MinValue)
                        param.Value = objSample.FromDate;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", SqlDbType.Date);
                    if (objSample.ToDate != DateTime.MinValue)
                        param.Value = objSample.ToDate;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CrossBarrier", SqlDbType.Bit);
                    param.Value = objSample.CrossBarrier;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CadMasterId", SqlDbType.Int);
                    param.Value = objSample.CADMasterRoleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = objSample.ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientDeptid", SqlDbType.Int);
                    param.Value = objSample.ClientDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDepartmentID", SqlDbType.Int);
                    param.Value = objSample.ClientParentDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.VarChar);
                    param.Value = objSample.Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();
                    

                    while (reader.Read())
                    {

                        SamplePattern objSampleNew = new SamplePattern();
                        objSampleNew.CADMasterRoleID = reader["CADMasterRoleID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["CADMasterRoleID"]);
                        objSampleNew.Styleid = reader["Styleid"] == DBNull.Value ? -1 : Convert.ToInt32(reader["Styleid"]);
                        objSampleNew.StyleNumber = reader["StyleNumber"].ToString();
                        objSampleNew.CreatedOn = reader["CreatedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                        objSampleNew.Fabric = reader["Fabric"].ToString();
                        objSampleNew.FabricDetails = reader["FabricDetails"].ToString();
                        objSampleNew.FitsCommentDate = reader["FitsCommentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsCommentDate"]);
                        objSampleNew.SketchUrl = reader["SketchUrl"].ToString();
                        objSampleNew.Status = reader["Status"].ToString();
                        objSampleNew.ClientName = reader["ClientName"].ToString();
                        objSampleNew.DeptName = reader["DeptName"].ToString();
                        objSampleNew.PD_MarchentName = reader["PD_MarchentName"].ToString();
                        objSampleNew.AcountMgrName = reader["AcountMgrName"].ToString();
                        objSampleNew.AllocationDate = reader["AllocationDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["AllocationDate"]);
                        objSampleNew.StcEta = reader["StcEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["StcEta"]);
                        objSampleNew.HandOverEta = reader["HandOverEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverEta"]);
                        objSampleNew.PatterntEta = reader["PatterntEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatterntEta"]);
                        objSampleNew.SampleSentEta = reader["SampleSentEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentEta"]);
                        objSampleNew.SequenceId = reader["SequenceID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["SequenceID"]);
                        objSampleNew.MasterSequence = reader["MasterSequence"] == DBNull.Value ? -1 : Convert.ToInt32(reader["MasterSequence"]);
                        objSampleNew.BarrierDays = reader["BarrierDays"] == DBNull.Value ? -1 : Convert.ToInt32(reader["BarrierDays"]);
                        objSamplePattern.Add(objSampleNew);
                    }

                    cnx.Close();                     
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return objSamplePattern;   
            
        }

        public List<SamplePattern> CADMaster()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_CADMaster";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
               
                reader = cmd.ExecuteReader();
                List<SamplePattern> objSamplePattern = new List<SamplePattern>();

                while (reader.Read())
                {

                    SamplePattern objSample = new SamplePattern();
                    objSample.CADMasterRoleID = reader["CADMasterRoleID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["CADMasterRoleID"]);
                    objSample.MasterName = reader["MasterName"].ToString();
                    
                    objSamplePattern.Add(objSample);
                }

                cnx.Close();

                return objSamplePattern;
            }
        }
        
        public List<SamplePattern> Get_Client_ByAutoAllocPattern()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_Client_ByAutoAllocPattern";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                reader = cmd.ExecuteReader();
                List<SamplePattern> objSamplePattern = new List<SamplePattern>();

                while (reader.Read())
                {

                    SamplePattern objSample = new SamplePattern();
                    objSample.ClientId = reader["ClientId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ClientId"]);
                    objSample.ClientName = reader["ClientName"].ToString();

                    objSamplePattern.Add(objSample);
                }

                cnx.Close();

                return objSamplePattern;
            }
        }

        public List<SamplePattern> Get_ClientDepts_ByAutoAllocPattern(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_ClientDepts_ByAutoAllocPattern";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<SamplePattern> objSamplePattern = new List<SamplePattern>();

                while (reader.Read())
                {

                    SamplePattern objSample = new SamplePattern();
                    objSample.ClientDeptid = reader["DeptId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["DeptId"]);
                    objSample.DeptName = reader["DepartmentName"].ToString();

                    objSamplePattern.Add(objSample);
                }

                cnx.Close();

                return objSamplePattern;
            }
        }
        //added by abhishek on 18/10/2018

        public List<SamplePattern> Get_ClientDeptsParent(int ClientId,string type,int ParentDeptID)
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();
       
            SqlCommand cmd;
            string cmdText;
            DataTable dt = new DataTable();
            cmdText = "sp_get_parentDepName";
            cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
            param.Value = ClientId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = type;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentDepID", SqlDbType.Int);
            param.Value = ParentDeptID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            List<SamplePattern> objSamplePattern = new List<SamplePattern>();
            foreach (DataRow dtRow in dt.Rows)
            {
              SamplePattern objSample = new SamplePattern();
              objSample.ClientDeptid = dtRow["DeptId"] == DBNull.Value ? -1 : Convert.ToInt32(dtRow["DeptId"].ToString());
              objSample.DeptName = dtRow["DepartmentName"].ToString();
              objSamplePattern.Add(objSample);
            }
            //reader = cmd.ExecuteReader();

            
            //while (reader.Read())
            //{
            //  SamplePattern objSample = new SamplePattern();
            //  objSample.ClientDeptid = reader["DeptId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["DeptId"]);
            //  objSample.DeptName = reader["DepartmentName"].ToString();
            //  objSamplePattern.Add(objSample);
            //}
            cnx.Close();
            return objSamplePattern;
          }
        }

        public List<SamplePattern> GetAutoAllocation_Status()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAutoAllocation_Status";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                reader = cmd.ExecuteReader();
                List<SamplePattern> objSamplePattern = new List<SamplePattern>();

                while (reader.Read())
                {

                    SamplePattern objSample = new SamplePattern();

                    objSample.Status = reader["Status"].ToString();

                    objSamplePattern.Add(objSample);
                }

                cnx.Close();

                return objSamplePattern;
            }
        }

        // End By Ravi kumar For Reschedule Pattern on 19-Apr-2017

        // Add by Ravi kumar for Sampling Fits Cycle Flow on 26-Apr-2017

        public List<SamplePattern> GetSamplingFitsCycleFlow(SamplePattern objSample, int UserId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            List<SamplePattern> objSamplePattern = new List<SamplePattern>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetSamplingFitsCycleFlow";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = objSample.Styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Style", SqlDbType.VarChar);
                    param.Value = objSample.StyleNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = objSample.ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("ClientDeptid", SqlDbType.Int);
                    param.Value = objSample.ClientDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDeptID", SqlDbType.Int);
                    param.Value = objSample.ClientParentDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Status", SqlDbType.VarChar);
                    param.Value = objSample.Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleID", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        SamplePattern objSampleNew = new SamplePattern();
                        objSampleNew.CADMasterRoleID = reader["CADMasterRoleID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["CADMasterRoleID"]);
                        objSampleNew.Styleid = reader["Styleid"] == DBNull.Value ? -1 : Convert.ToInt32(reader["Styleid"]);
                        objSampleNew.StyleNumber = reader["StyleNumber"].ToString();
                        objSampleNew.CreatedOn = reader["CreatedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                        objSampleNew.Fabric = reader["Fabric"].ToString();
                        objSampleNew.FabricDetails = reader["FabricDetails"].ToString();
                        objSampleNew.FitsCommentDate = reader["FitsCommentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsCommentDate"]);
                        objSampleNew.SketchUrl = reader["SketchUrl"].ToString();
                        objSampleNew.Status = reader["Status"].ToString();
                        objSampleNew.ClientName = reader["ClientName"].ToString();
                        objSampleNew.DeptName = reader["DeptName"].ToString();
                        objSampleNew.PD_MarchentName = reader["PD_MarchentName"].ToString();
                        objSampleNew.AcountMgrName = reader["AcountMgrName"].ToString();

                        objSampleNew.StcEta = reader["StcEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["StcEta"]);
                        objSampleNew.SampleSentDate = reader["SampleSentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentDate"]);
                        objSampleNew.IsQCPresent = reader["IsQCPresent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsQCPresent"]);
                        objSampleNew.QCMasterId = reader["MasterQCID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["MasterQCID"]);
                        objSampleNew.FitsId = reader["FitsId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsId"]);
                        objSampleNew.FitsStatus = reader["FitsStatus"].ToString();
                        objSampleNew.ReqRefSample = reader["ReqRefSample"] == DBNull.Value ? false : Convert.ToBoolean(reader["ReqRefSample"]);
                        objSampleNew.FitsCommentUpload = reader["FitsCommentUpload"].ToString();
                        objSampleNew.FitsETADate = reader["FitsETADate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsETADate"]);
                        objSampleNew.FitsActualDate = reader["FitsActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsActualDate"]);
                        objSampleNew.IsHandOver = reader["IsHandOver"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsHandOver"]);
                        objSampleNew.HandOverEta = reader["HandOverEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverEta"]);
                        objSampleNew.HandOverActDate = reader["HandOverActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverActualDate"]);
                        objSampleNew.IsPatternReady = reader["IsPatternReady"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsPatternReady"]);
                        objSampleNew.PatterntEta = reader["PatterntEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatterntEta"]);
                        objSampleNew.PatternReadyActualDate = reader["PatternReadyActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatternReadyActualDate"]);
                        objSampleNew.IsSampleSent = reader["IsSampleSent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsSampleSent"]);
                        objSampleNew.SampleSentEta = reader["SampleSentEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentEta"]);
                        objSampleNew.SampleSentActualDate = reader["SampleSentActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentActualDate"]);
                        objSampleNew.SampleUpload = reader["SampleUpload"].ToString();
                        objSampleNew.StcApproved = reader["StcApproved"] == DBNull.Value ? false : Convert.ToBoolean(reader["StcApproved"]);
                        objSampleNew.Commentes = reader["Commentes"].ToString();
                        objSampleNew.IsReUseStyle = reader["IsReUseStyle"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsReUseStyle"]);
                        objSampleNew.IsIkandiClient = reader["IsIkandiClient"] == DBNull.Value ? -1 : Convert.ToInt32(reader["IsIkandiClient"]);
                        objSampleNew.FitsType = reader["FitsType"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsType"]);
                        objSampleNew.ClientId = reader["ClientId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ClientId"]);
                        objSampleNew.ClientDeptid = reader["DeptId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["DeptId"]);
                        objSampleNew.IsOrderExist = reader["OrderExist"] == DBNull.Value ? false : Convert.ToBoolean(reader["OrderExist"]);
                        objSampleNew.FitsRequestDone = reader["FitsRequestDone"] == DBNull.Value ? false : Convert.ToBoolean(reader["FitsRequestDone"]);
                        objSampleNew.FitsApprovedDone = reader["FitsApprovedDone"] == DBNull.Value ? false : Convert.ToBoolean(reader["FitsApprovedDone"]);
                        objSampleNew.FitsNotRequest = reader["FitsNotRequest"] == DBNull.Value ? false : Convert.ToBoolean(reader["FitsNotRequest"]);
                        objSampleNew.HistoryPresent = reader["HistoryPresent"] == DBNull.Value ? false : Convert.ToBoolean(reader["HistoryPresent"]);
                        objSampleNew.FitsCommentSentFor = reader["FitsCommentSentFor"].ToString();
                        objSampleNew.FitsPlanningFor = reader["FitsPlanningFor"].ToString();
                        objSampleNew.BiplFilePath = reader["BiplFilePath"].ToString();
                        objSampleNew.SamplingHandOverEta = reader["SamplingHandOverEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SamplingHandOverEta"]);
                        objSampleNew.IsCostingWithPattern = reader["IsCostingWithPattern"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsCostingWithPattern"]);
                        //Add By Prabhaker on 07-09-17//
                        //objSampleNew.EventDate = Convert.ToString(reader["EventDate"]);
                        //objSampleNew.nonworkingdaycount = Convert.ToString(reader["nonworkingdaycount"]);
                        //end of code
                        // Added By Ravi kumar on 21/9/17 for new comment upload
                        objSampleNew.SampleUpload_New = reader["SampleUpload_New"].ToString();
                        objSampleNew.FitsCommentUpload_New = reader["FitsCommentUpload_New"].ToString();   

                        objSamplePattern.Add(objSampleNew);
                    }

                    cnx.Close();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return objSamplePattern;

        }
        public List<SamplePattern> GetSamplingFitsCycleFlow_PreOrder(SamplePattern objSample, int UserId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            List<SamplePattern> objSamplePattern = new List<SamplePattern>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetSamplingFitsCycleFlow_PreOrder";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = objSample.Styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Style", SqlDbType.VarChar);
                    param.Value = objSample.StyleNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = objSample.ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("ClientDeptid", SqlDbType.Int);
                    param.Value = objSample.ClientDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDeptID", SqlDbType.Int);
                    param.Value = objSample.ClientParentDeptid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Status", SqlDbType.VarChar);
                    param.Value = objSample.Status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleID", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        SamplePattern objSampleNew = new SamplePattern();
                        objSampleNew.CADMasterRoleID = reader["CADMasterRoleID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["CADMasterRoleID"]);
                        objSampleNew.Styleid = reader["Styleid"] == DBNull.Value ? -1 : Convert.ToInt32(reader["Styleid"]);
                        objSampleNew.StyleNumber = reader["StyleNumber"].ToString();
                        objSampleNew.CreatedOn = reader["CreatedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                        objSampleNew.Fabric = reader["Fabric"].ToString();
                        objSampleNew.FabricDetails = reader["FabricDetails"].ToString();
                        objSampleNew.FitsCommentDate = reader["FitsCommentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsCommentDate"]);
                        objSampleNew.SketchUrl = reader["SketchUrl"].ToString();
                        objSampleNew.Status = reader["Status"].ToString();
                        objSampleNew.ClientName = reader["ClientName"].ToString();
                        objSampleNew.DeptName = reader["DeptName"].ToString();
                        objSampleNew.PD_MarchentName = reader["PD_MarchentName"].ToString();
                        objSampleNew.AcountMgrName = reader["AcountMgrName"].ToString();

                        objSampleNew.StcEta = reader["StcEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["StcEta"]);
                        objSampleNew.SampleSentDate = reader["SampleSentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentDate"]);
                        objSampleNew.IsQCPresent = reader["IsQCPresent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsQCPresent"]);
                        objSampleNew.QCMasterId = reader["MasterQCID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["MasterQCID"]);
                        objSampleNew.FitsId = reader["FitsId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsId"]);
                        objSampleNew.FitsStatus = reader["FitsStatus"].ToString();
                        objSampleNew.ReqRefSample = reader["ReqRefSample"] == DBNull.Value ? false : Convert.ToBoolean(reader["ReqRefSample"]);
                        objSampleNew.FitsCommentUpload = reader["FitsCommentUpload"].ToString();
                        objSampleNew.FitsETADate = reader["FitsETADate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsETADate"]);
                        objSampleNew.FitsActualDate = reader["FitsActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsActualDate"]);
                        objSampleNew.IsHandOver = reader["IsHandOver"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsHandOver"]);
                        objSampleNew.HandOverEta = reader["HandOverEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverEta"]);
                        objSampleNew.HandOverActDate = reader["HandOverActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverActualDate"]);
                        objSampleNew.IsPatternReady = reader["IsPatternReady"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsPatternReady"]);
                        objSampleNew.PatterntEta = reader["PatterntEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatterntEta"]);
                        objSampleNew.PatternReadyActualDate = reader["PatternReadyActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatternReadyActualDate"]);
                        objSampleNew.IsSampleSent = reader["IsSampleSent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsSampleSent"]);
                        objSampleNew.SampleSentEta = reader["SampleSentEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentEta"]);
                        objSampleNew.SampleSentActualDate = reader["SampleSentActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentActualDate"]);
                        objSampleNew.SampleUpload = reader["SampleUpload"].ToString();
                        objSampleNew.StcApproved = reader["StcApproved"] == DBNull.Value ? false : Convert.ToBoolean(reader["StcApproved"]);
                        objSampleNew.Commentes = reader["Commentes"].ToString();
                        objSampleNew.IsReUseStyle = reader["IsReUseStyle"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsReUseStyle"]);
                        objSampleNew.IsIkandiClient = reader["IsIkandiClient"] == DBNull.Value ? -1 : Convert.ToInt32(reader["IsIkandiClient"]);
                        objSampleNew.FitsType = reader["FitsType"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsType"]);
                        objSampleNew.ClientId = reader["ClientId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ClientId"]);
                        objSampleNew.ClientDeptid = reader["DeptId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["DeptId"]);
                        objSampleNew.IsOrderExist = reader["OrderExist"] == DBNull.Value ? false : Convert.ToBoolean(reader["OrderExist"]);
                        objSampleNew.FitsRequestDone = reader["FitsRequestDone"] == DBNull.Value ? false : Convert.ToBoolean(reader["FitsRequestDone"]);
                        objSampleNew.FitsApprovedDone = reader["FitsApprovedDone"] == DBNull.Value ? false : Convert.ToBoolean(reader["FitsApprovedDone"]);
                        objSampleNew.FitsNotRequest = reader["FitsNotRequest"] == DBNull.Value ? false : Convert.ToBoolean(reader["FitsNotRequest"]);
                        objSampleNew.HistoryPresent = reader["HistoryPresent"] == DBNull.Value ? false : Convert.ToBoolean(reader["HistoryPresent"]);
                        objSampleNew.FitsCommentSentFor = reader["FitsCommentSentFor"].ToString();
                        objSampleNew.FitsPlanningFor = reader["FitsPlanningFor"].ToString();
                        objSampleNew.BiplFilePath = reader["BiplFilePath"].ToString();
                        objSampleNew.SamplingHandOverEta = reader["SamplingHandOverEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SamplingHandOverEta"]);
                        objSampleNew.IsCostingWithPattern = reader["IsCostingWithPattern"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsCostingWithPattern"]);
                        //Add By Prabhaker on 07-09-17//
                        //objSampleNew.EventDate = Convert.ToString(reader["EventDate"]);
                        //objSampleNew.nonworkingdaycount = Convert.ToString(reader["nonworkingdaycount"]);
                        //end of code
                        // Added By Ravi kumar on 21/9/17 for new comment upload
                        objSampleNew.SampleUpload_New = reader["SampleUpload_New"].ToString();
                        objSampleNew.FitsCommentUpload_New = reader["FitsCommentUpload_New"].ToString();
                        objSampleNew.PDDecesion = reader["PDDecesion"].ToString();

                        objSamplePattern.Add(objSampleNew);
                    }

                    cnx.Close();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return objSamplePattern;

        }

        public List<SamplePattern> GetAllCQD()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllCQD";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                reader = cmd.ExecuteReader();
                List<SamplePattern> objSamplePattern = new List<SamplePattern>();

                while (reader.Read())
                {

                    SamplePattern objSample = new SamplePattern();
                    objSample.CQDId = reader["CQDId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["CQDId"]);
                    objSample.CQDName = reader["CQDNAME"].ToString();

                    objSamplePattern.Add(objSample);
                }

                cnx.Close();

                return objSamplePattern;
            }
        }


        public List<SamplePattern> GetSamplingFitsCycleHistory(int StyleId, int Mode)
        {
            List<SamplePattern> objSamplePattern = new List<SamplePattern>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetSamplingFitsCycleHistory";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Mode", SqlDbType.Int);
                    param.Value = Mode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param); 


                    reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        SamplePattern objSampleNew = new SamplePattern();                        
                        objSampleNew.Styleid = reader["Styleid"] == DBNull.Value ? -1 : Convert.ToInt32(reader["Styleid"]);
                        objSampleNew.StyleNumber = reader["StyleNumber"].ToString();
                        objSampleNew.CreatedOn = reader["CreatedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                        objSampleNew.Fabric = reader["Fabric"].ToString();
                        objSampleNew.FabricDetails = reader["FabricDetails"].ToString();
                        objSampleNew.FitsCommentDate = reader["FitsCommentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsCommentDate"]);
                        objSampleNew.SketchUrl = reader["SketchUrl"].ToString();
                        objSampleNew.Status = reader["Status"].ToString();
                        objSampleNew.ClientName = reader["ClientName"].ToString();
                        objSampleNew.DeptName = reader["DeptName"].ToString();
                        objSampleNew.PD_MarchentName = reader["PD_MarchentName"].ToString();
                        objSampleNew.AcountMgrName = reader["AcountMgrName"].ToString();


                        objSampleNew.StcEta = reader["StcEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["StcEta"]);
                        objSampleNew.SampleSentDate = reader["SampleSentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentDate"]);
                        objSampleNew.IsQCPresent = reader["IsQCPresent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsQCPresent"]);
                        objSampleNew.QCMasterId = reader["MasterQCID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["MasterQCID"]);
                        objSampleNew.FitsId = reader["FitsId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsId"]);
                        objSampleNew.FitsStatus = reader["FitsStatus"].ToString();
                        objSampleNew.ReqRefSample = reader["ReqRefSample"] == DBNull.Value ? false : Convert.ToBoolean(reader["ReqRefSample"]);
                        objSampleNew.FitsCommentUpload = reader["FitsCommentUpload"].ToString();
                        objSampleNew.FitsETADate = reader["FitsETADate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsETADate"]);
                        objSampleNew.FitsActualDate = reader["FitsActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsActualDate"]);
                        objSampleNew.IsHandOver = reader["IsHandOver"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsHandOver"]);
                        objSampleNew.HandOverEta = reader["HandOverEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverEta"]);
                        objSampleNew.HandOverActDate = reader["HandOverActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverActualDate"]);
                        objSampleNew.IsPatternReady = reader["IsPatternReady"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsPatternReady"]);
                        objSampleNew.PatterntEta = reader["PatterntEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatterntEta"]);
                        objSampleNew.PatternReadyActualDate = reader["PatternReadyActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatternReadyActualDate"]);
                        objSampleNew.IsSampleSent = reader["IsSampleSent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsSampleSent"]);
                        objSampleNew.SampleSentEta = reader["SampleSentEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentEta"]);
                        objSampleNew.SampleSentActualDate = reader["SampleSentActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentActualDate"]);
                        objSampleNew.SampleUpload = reader["SampleUpload"].ToString();
                        objSampleNew.StcApproved = reader["StcApproved"] == DBNull.Value ? false : Convert.ToBoolean(reader["StcApproved"]);
                        objSampleNew.Commentes = reader["Commentes"].ToString();                       
                        objSampleNew.FitsType = reader["FitsType"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsType"]);
                        objSampleNew.ClientId = reader["ClientId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ClientId"]);
                        objSampleNew.ClientDeptid = reader["DeptId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["DeptId"]);
                        objSampleNew.IsOrderExist = reader["OrderExist"] == DBNull.Value ? false : Convert.ToBoolean(reader["OrderExist"]);
                        objSampleNew.FitsCommentSentFor = reader["FitsCommentSentFor"].ToString();
                        objSampleNew.FitsPlanningFor = reader["FitsPlanningFor"].ToString();
                        objSampleNew.BiplFilePath = reader["BiplFilePath"].ToString();
                        objSampleNew.CQDName = reader["CQDName"].ToString();
                        objSampleNew.SampleUpload_New = reader["SampleUpload_New"].ToString();
                        objSampleNew.FitsCommentUpload_New = reader["FitsCommentUpload_New"].ToString();
                        objSampleNew.RemakeCount = (reader["RemakeCount"].ToString() == "" ? "" : "("+reader["RemakeCount"].ToString()+")");//abhishek 6/10/2017
                        objSamplePattern.Add(objSampleNew);
                    }

                    cnx.Close();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return objSamplePattern;

        }
        public List<SamplePattern> GetSamplingFitsCycleHistory_ForPreOrder(int StyleId)
        {
            List<SamplePattern> objSamplePattern = new List<SamplePattern>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetSamplingFitsCycleHistory_PreOrder";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                   


                    reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        SamplePattern objSampleNew = new SamplePattern();
                        objSampleNew.Styleid = reader["Styleid"] == DBNull.Value ? -1 : Convert.ToInt32(reader["Styleid"]);
                        objSampleNew.StyleNumber = reader["StyleNumber"].ToString();
                        objSampleNew.CreatedOn = reader["CreatedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                        objSampleNew.Fabric = reader["Fabric"].ToString();
                        objSampleNew.FabricDetails = reader["FabricDetails"].ToString();
                        objSampleNew.FitsCommentDate = reader["FitsCommentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsCommentDate"]);
                        objSampleNew.SketchUrl = reader["SketchUrl"].ToString();
                        objSampleNew.Status = reader["Status"].ToString();
                        objSampleNew.ClientName = reader["ClientName"].ToString();
                        objSampleNew.DeptName = reader["DeptName"].ToString();
                        objSampleNew.PD_MarchentName = reader["PD_MarchentName"].ToString();
                        objSampleNew.AcountMgrName = reader["AcountMgrName"].ToString();


                        objSampleNew.StcEta = reader["StcEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["StcEta"]);
                        objSampleNew.SampleSentDate = reader["SampleSentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentDate"]);
                        objSampleNew.IsQCPresent = reader["IsQCPresent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsQCPresent"]);
                        objSampleNew.QCMasterId = reader["MasterQCID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["MasterQCID"]);
                        objSampleNew.FitsId = reader["FitsId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsId"]);
                        objSampleNew.FitsStatus = reader["FitsStatus"].ToString();
                        objSampleNew.ReqRefSample = reader["ReqRefSample"] == DBNull.Value ? false : Convert.ToBoolean(reader["ReqRefSample"]);
                        objSampleNew.FitsCommentUpload = reader["FitsCommentUpload"].ToString();
                        objSampleNew.FitsETADate = reader["FitsETADate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsETADate"]);
                        objSampleNew.FitsActualDate = reader["FitsActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FitsActualDate"]);
                        objSampleNew.IsHandOver = reader["IsHandOver"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsHandOver"]);
                        objSampleNew.HandOverEta = reader["HandOverEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverEta"]);
                        objSampleNew.HandOverActDate = reader["HandOverActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverActualDate"]);
                        objSampleNew.IsPatternReady = reader["IsPatternReady"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsPatternReady"]);
                        objSampleNew.PatterntEta = reader["PatterntEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatterntEta"]);
                        objSampleNew.PatternReadyActualDate = reader["PatternReadyActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PatternReadyActualDate"]);
                        objSampleNew.IsSampleSent = reader["IsSampleSent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsSampleSent"]);
                        objSampleNew.SampleSentEta = reader["SampleSentEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentEta"]);
                        objSampleNew.SampleSentActualDate = reader["SampleSentActualDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentActualDate"]);
                        objSampleNew.SampleUpload = reader["SampleUpload"].ToString();
                        objSampleNew.StcApproved = reader["StcApproved"] == DBNull.Value ? false : Convert.ToBoolean(reader["StcApproved"]);
                        objSampleNew.Commentes = reader["Commentes"].ToString();
                        objSampleNew.FitsType = reader["FitsType"] == DBNull.Value ? -1 : Convert.ToInt32(reader["FitsType"]);
                        objSampleNew.ClientId = reader["ClientId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ClientId"]);
                        objSampleNew.ClientDeptid = reader["DeptId"] == DBNull.Value ? -1 : Convert.ToInt32(reader["DeptId"]);
                        objSampleNew.IsOrderExist = reader["OrderExist"] == DBNull.Value ? false : Convert.ToBoolean(reader["OrderExist"]);
                        objSampleNew.FitsCommentSentFor = reader["FitsCommentSentFor"].ToString();
                        objSampleNew.FitsPlanningFor = reader["FitsPlanningFor"].ToString();
                        objSampleNew.BiplFilePath = reader["BiplFilePath"].ToString();
                        objSampleNew.CQDName = reader["CQDName"].ToString();
                        objSampleNew.SampleUpload_New = reader["SampleUpload_New"].ToString();
                        objSampleNew.FitsCommentUpload_New = reader["FitsCommentUpload_New"].ToString();
                        objSampleNew.RemakeCount = (reader["RemakeCount"].ToString() == "" ? "" : "(" + reader["RemakeCount"].ToString() + ")");//abhishek 6/10/2017
                        objSampleNew.HandoverFileUpload = reader["HandoverFileUpload"].ToString();
                        objSamplePattern.Add(objSampleNew);
                    }

                    cnx.Close();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return objSamplePattern;

        }
        public bool bCheckPreOrder(string Stylecode)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                int CheckOrder = 1;
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_CheckPreOrder_Style";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Stylecode", SqlDbType.VarChar);
                param.Value = Stylecode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                  reader = cmd.ExecuteReader();
                 while (reader.Read())
                {
                    CheckOrder = reader["PreOrder"] == DBNull.Value ? 1 : Convert.ToInt32(reader["PreOrder"]);
                }
                 cnx.Close();
                 if (CheckOrder == 1)
                     return true;
                 else
                     return false;
              }
           }
        public int Update_Fits_Track_InPreOrder(int styleid, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
              
               
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_CreateFitsCycle_PreOrder";
                cmd = new SqlCommand(cmdText, cnx);
                DataSet Fits_Track_InPreOrder = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@styleid", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Fits_Track_InPreOrder);
                cnx.Close();
                return 1;
            
            }
        }

        #endregion

        #region Delete Fits



        #endregion
        //Addded by abhishek on 11/9/2018 
        public DataSet GetSamplingFitsCycle(int Styleid )
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            DataSet ds = new DataSet();
            cnx.Open();

            string cmdText = "Usp_GetSTCSampleRequest";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;
            param = new SqlParameter("@Flag", SqlDbType.Int);
            param.Value = 1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StyleID", SqlDbType.Int);
            param.Value = Styleid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);

            cnx.Close();
            return ds;
          }
        }
        public DataSet GetSamplingFitsCycleForHistory(int Styleid)
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            DataSet ds = new DataSet();
            cnx.Open();

            string cmdText = "Usp_GetSTCSampleRequest";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;
            param = new SqlParameter("@Flag", SqlDbType.Int);
            param.Value = 5;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StyleID", SqlDbType.Int);
            param.Value = Styleid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);

            cnx.Close();
            return ds;
          }
        }
        public int InsertSamplingFitsCycle(int Styleid,String RequestSample ,int ID,string Status)
        {
          int Result = 0;        
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {             
                try
                {
                    cnx.Open();                
                    string cmdText = "Usp_GetSTCSampleRequest";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    
                    SqlParameter paramIn;
                    paramIn = new SqlParameter("@Flag", SqlDbType.Int);
                    paramIn.Value = 2;
                    paramIn.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@StyleID", SqlDbType.Int);
                    paramIn.Value = Styleid;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@ReqSample", SqlDbType.VarChar);
                    paramIn.Value = RequestSample;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@FitsRequest_AfterSTCApproved", SqlDbType.Int);
                    paramIn.Value = ID;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Status", SqlDbType.VarChar);
                    paramIn.Value = Status;
                    cmd.Parameters.Add(paramIn);
                                      
                    Result = cmd.ExecuteNonQuery();
                    return Result;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
            }
        }
        public DataSet GetProDuctionFitsCycle(int Styleid)
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            DataSet ds = new DataSet();
            cnx.Open();

            string cmdText = "Usp_GetSTCSampleRequest";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;
            param = new SqlParameter("@Flag", SqlDbType.Int);
            param.Value = 3;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StyleID", SqlDbType.Int);
            param.Value = Styleid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);

            cnx.Close();
            return ds;
          }
        }
        public DataSet GetReqSample(int Styleid)
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            DataSet ds = new DataSet();
            cnx.Open();

            string cmdText = "Usp_GetSTCSampleRequest";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;
            param = new SqlParameter("@Flag", SqlDbType.Int);
            param.Value = 6;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StyleID", SqlDbType.Int);
            param.Value = Styleid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);

            cnx.Close();
            return ds;
          }
        }
        public int InsertProductionFitsCycle(int Styleid, String RequestSample, int ID, string Status)
        {
          int Result = 0;
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            try
            {
              cnx.Open();
              string cmdText = "Usp_GetSTCSampleRequest";
              SqlCommand cmd = new SqlCommand(cmdText, cnx);

              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

              SqlParameter paramIn;
              paramIn = new SqlParameter("@Flag", SqlDbType.Int);
              paramIn.Value = 4;
              paramIn.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(paramIn);

              paramIn = new SqlParameter("@StyleID", SqlDbType.Int);
              paramIn.Value = Styleid;
              cmd.Parameters.Add(paramIn);

              paramIn = new SqlParameter("@ReqSample", SqlDbType.VarChar);
              paramIn.Value = RequestSample;
              cmd.Parameters.Add(paramIn);

              paramIn = new SqlParameter("@FitsRequest_AfterSTCApproved", SqlDbType.Int);
              paramIn.Value = ID;
              cmd.Parameters.Add(paramIn);

              paramIn = new SqlParameter("@Status", SqlDbType.VarChar);
              paramIn.Value = Status;
              cmd.Parameters.Add(paramIn);

              Result = cmd.ExecuteNonQuery();
              return Result;
            }
            catch (SqlException ex)
            {
              throw ex;
            }
            finally
            {
              cnx.Close();
            }
          }
        }
        public bool bCheck_ProductionRequestIntiate(int Styleid, bool IsproductionSample)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "Usp_GetCheckIntiateProductionSample";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExistFabric = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = Styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsProductionSample", SqlDbType.Int);
                    param.Value = IsproductionSample;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckExistFabric);
                    int a = Convert.ToInt32(dsCheckExistFabric.Tables[0].Rows[0]["IsProductionSample"]);
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
      //END abhishek
        public bool IsShowPre_Order_Sampling(int StyleID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "sp_ShowPre_Order_Sampling";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExfactoryPermission = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                  

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckExfactoryPermission);
                    int a = Convert.ToInt32(dsCheckExfactoryPermission.Tables[0].Rows[0]["Permission"]);
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

    }
}
