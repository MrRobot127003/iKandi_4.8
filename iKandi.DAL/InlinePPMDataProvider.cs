using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class InlinePPMDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public InlinePPMDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Public Methods

        public InlinePPM GetInlinePPMByStyleID(string StyleNumber, int StyleId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_inline_ppm_get_by_style_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsInlinePPM = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlinePPM);

                InlinePPM inlinePPM = ConvertDataSetToInlinePPM(dsInlinePPM);

                //inlinePPM.InlinePPmFile = 
                cnx.Close();

                return inlinePPM;
            }

        }



        public InlinePPM GetInlinePPM(string StyleNumber, int DeptID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_inline_ppm_get_by_style_id_and_dept_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsInlinePPM = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlinePPM);

                InlinePPM inlinePPM = ConvertDataSetToInlinePPM(dsInlinePPM);

                cnx.Close();

                return inlinePPM;
            }

        }







        public List<InlinePPMFile> GetPPMFileInfoByPPMID(int InlinePPMID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_inline_ppm_get_inline_ppm_by_inlineId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                param.Value = InlinePPMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<InlinePPMFile> inlinePPmFileCollection = new List<InlinePPMFile>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        InlinePPMFile objInlinePPMFile = new InlinePPMFile();
                        objInlinePPMFile.Id = (reader["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Id"]);
                        objInlinePPMFile.InlinePPMID = Convert.ToInt32(reader["InlinePPMID"]);
                        objInlinePPMFile.File = (reader["File"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["File"]);

                        inlinePPmFileCollection.Add(objInlinePPMFile);
                    }
                }

                return inlinePPmFileCollection;
            }
        }

        public void UpdateInlinePPM(InlinePPM InlinePPMData)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_inline_ppm_update";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                    param.Value = InlinePPMData.InlinePPMID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    param.Value = InlinePPMData.StyleNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = InlinePPMData.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateHeldOn", SqlDbType.DateTime);
                    if ((InlinePPMData.DateHeldOn == DateTime.MinValue) || (InlinePPMData.DateHeldOn == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.DateHeldOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.DateHeldOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Stitching Remarks
                    param = new SqlParameter("@StitchingComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.StitchingComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //Washcare
                    param = new SqlParameter("@WashCareComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.WashCareComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Embroidery
                    param = new SqlParameter("@EMBHandComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.EMBHandComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@EMBMachineComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.EMBMachineComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Linning
                    param = new SqlParameter("@LinningFusingComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiningFusingComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinningInterLinningComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiniingInterLiningComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinningPocketLiningComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiningPocketLiningComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinningShoulderPadComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiningShoulderPadComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Finishing
                    param = new SqlParameter("@FinishingDCComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.FinishingDCComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishingWashComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.FinishingWashComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishingCrincleComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.FinishingCrinckleComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Packing
                    param = new SqlParameter("@PackingTagsComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingTagsComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingSpareButtonsComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingSpaceButtonsComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingCardBoardComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingCardBoardComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingWOCardBoardComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingWOCardBoardComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingPolytheneComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingPolytheneComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingTissueComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingTissueComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingFoamComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingFoamComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingHandlerPackComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingHangerPackComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingBoxComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingBoxComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //Remarks amd PPM Instruction
                    param = new SqlParameter("@PPMRemarks", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PPMRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PPMInstructions", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PPMInstructions;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Meeting Attendence 
                    param = new SqlParameter("@sMeetingComplete", SqlDbType.Bit);
                    param.Value = InlinePPMData.IsMeetingComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sMeetingCompletedOn", SqlDbType.DateTime);
                    if ((InlinePPMData.IsMeetingCompletedOn == DateTime.MinValue) || (InlinePPMData.IsMeetingCompletedOn == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.IsMeetingCompletedOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.IsMeetingCompletedOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MeetingAttendedOtherUser", SqlDbType.VarChar);
                    param.Value = InlinePPMData.MeetingAttendedOtherUser;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBHMeetingComplete", SqlDbType.Bit);
                    param.Value = InlinePPMData.IsBHMeetingComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BHMeetingCompletedOn", SqlDbType.DateTime);
                    if ((InlinePPMData.BHMeetingCompleteOn == DateTime.MinValue) || (InlinePPMData.BHMeetingCompleteOn == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.BHMeetingCompleteOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.BHMeetingCompleteOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BHPlannedMeeting", SqlDbType.DateTime);
                    if ((InlinePPMData.BBPlannedMeeting == DateTime.MinValue) || (InlinePPMData.BBPlannedMeeting == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.BBPlannedMeeting == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.BBPlannedMeeting;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdSAM", SqlDbType.Float);
                    if (InlinePPMData.ProdSAM == -1)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.ProdSAM;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdOB", SqlDbType.Int);
                    if (InlinePPMData.ProdOB == -1)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.ProdOB;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdSamFile", SqlDbType.VarChar);
                    param.Value = InlinePPMData.ProdSamFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdOBfile", SqlDbType.VarChar);
                    param.Value = InlinePPMData.ProdOBfile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();

                    this.SaveTrimsComments(InlinePPMData, cnx, transaction);

                    this.SaveOrderContractTOPDetails(InlinePPMData, cnx, transaction);

                    this.SavePPMeetingAttendance(InlinePPMData, cnx, transaction);

                    this.InsertInlinePPMFile(InlinePPMData, cnx, transaction);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }
        }

        public void InsertInlinePPM(InlinePPM InlinePPMData)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_inline_ppm_insert";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@oInlinePPMID", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);
                    SqlParameter param;

                    param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    param.Value = InlinePPMData.StyleNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = InlinePPMData.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateHeldOn", SqlDbType.DateTime);
                    if ((InlinePPMData.DateHeldOn == DateTime.MinValue) || (InlinePPMData.DateHeldOn == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.DateHeldOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.DateHeldOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    // Stitching Remarks
                    param = new SqlParameter("@StitchingComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.StitchingComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // WashCare
                    param = new SqlParameter("@WashCareComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.WashCareComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Embroidery 
                    param = new SqlParameter("@EMBMachineComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.EMBMachineComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@EMBHandComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.EMBHandComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Lining
                    param = new SqlParameter("@LinningFusingComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiningFusingComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinningInterLinningComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiniingInterLiningComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinningPocketLiningComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiningPocketLiningComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LinningShoulderPadComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.LiningShoulderPadComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Finishing
                    param = new SqlParameter("@FinishingDCComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.FinishingDCComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishingWashComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.FinishingWashComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinishingCrincleComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.FinishingCrinckleComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Packing
                    param = new SqlParameter("@PackingTagsComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingTagsComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingSpareButtonsComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingSpaceButtonsComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingCardBoardComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingCardBoardComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingWOCardBoardComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingWOCardBoardComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingPolytheneComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingPolytheneComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingTissueComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingTissueComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingFoamComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingFoamComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingHandlerPackComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingHangerPackComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingBoxComments", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PackingBoxComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    // Remarks Portion + PP Instruction
                    param = new SqlParameter("@PPMRemarks", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PPMRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PPMInstructions", SqlDbType.VarChar);
                    param.Value = InlinePPMData.PPMInstructions;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // Meeting attendance Portioon
                    param = new SqlParameter("@sMeetingComplete", SqlDbType.Bit);
                    param.Value = InlinePPMData.IsMeetingComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sMeetingCompletedOn", SqlDbType.DateTime);
                    if ((InlinePPMData.IsMeetingCompletedOn == DateTime.MinValue) || (InlinePPMData.IsMeetingCompletedOn == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.IsMeetingCompletedOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.IsMeetingCompletedOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MeetingAttendedOtherUser", SqlDbType.VarChar);
                    param.Value = InlinePPMData.MeetingAttendedOtherUser;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@sBHMeetingComplete", SqlDbType.Bit);
                    param.Value = InlinePPMData.IsBHMeetingComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BHMeetingCompletedOn", SqlDbType.DateTime);
                    if ((InlinePPMData.BHMeetingCompleteOn == DateTime.MinValue) || (InlinePPMData.BHMeetingCompleteOn == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.BHMeetingCompleteOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.BHMeetingCompleteOn;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BHPlannedMeeting", SqlDbType.DateTime);
                    if ((InlinePPMData.BBPlannedMeeting == DateTime.MinValue) || (InlinePPMData.BBPlannedMeeting == Convert.ToDateTime("1753-01-01")) || (InlinePPMData.BBPlannedMeeting == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.BBPlannedMeeting;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdSAM", SqlDbType.Float);
                    if (InlinePPMData.ProdSAM == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.ProdSAM;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdOB", SqlDbType.Int);
                    if (InlinePPMData.ProdOB == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = InlinePPMData.ProdOB;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdSamFile", SqlDbType.VarChar);
                    param.Value = InlinePPMData.ProdSamFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProdOBfile", SqlDbType.VarChar);
                    param.Value = InlinePPMData.ProdOBfile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);




                    cmd.ExecuteNonQuery();

                    InlinePPMData.InlinePPMID = Convert.ToInt32(outParam.Value);

                    if (InlinePPMData.InlinePPMID == -1)
                        return;

                    this.SaveTrimsComments(InlinePPMData, cnx, transaction);

                    this.SaveOrderContractTOPDetails(InlinePPMData, cnx, transaction);

                    this.SavePPMeetingAttendance(InlinePPMData, cnx, transaction);

                    this.InsertInlinePPMFile(InlinePPMData, cnx, transaction);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }
        }

        #endregion

        #region Private Methods

        private void SaveOrderContractTOPDetails(InlinePPM InlinePPMData, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_inline_ppm_order_contract_insert";

            foreach (InlinePPMOrderContract contract in InlinePPMData.OrderContracts)
            {

                SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.Transaction = transaction;

                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = contract.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                param.Value = InlinePPMData.InlinePPMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TopSentTarget", SqlDbType.DateTime);
                if ((contract.TopSentTarget == DateTime.MinValue) || (contract.TopSentTarget == Convert.ToDateTime("1753-01-01")) || (contract.TopSentTarget == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = contract.TopSentTarget;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TopSentActual", SqlDbType.DateTime);
                if ((contract.TopSentActual == DateTime.MinValue) || (contract.TopSentActual == Convert.ToDateTime("1753-01-01")) || (contract.TopSentActual == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = contract.TopSentActual;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TopActualApproval", SqlDbType.DateTime);
                if ((contract.TopActualApproval == DateTime.MinValue) || (contract.TopActualApproval == Convert.ToDateTime("1753-01-01")) || (contract.TopActualApproval == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = contract.TopActualApproval;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BIPLUploadFile", SqlDbType.VarChar);
                param.Value = contract.BIPLUploadFile;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BIPLComments", SqlDbType.VarChar);
                param.Value = contract.BIPLComments;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@KandiUploadFile", SqlDbType.VarChar);
                param.Value = contract.iKandiUploadFile;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@KandiComments", SqlDbType.VarChar);
                param.Value = contract.iKandiComments;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TopStatus", SqlDbType.Int);
                if (contract.TopStatus != TopStatusType.UNKNOWN)
                {
                    param.Value = (int)contract.TopStatus;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }

        }


        private void SavePPMeetingAttendance(InlinePPM InlinePPMData, SqlConnection cnx, SqlTransaction transaction)
        {
            string[] delinComma = { "," };
            int pos = 0;
            int count = 0;

            // To get the count of ids
            while ((pos = InlinePPMData.UserIds.IndexOf(",", pos)) != -1)
            {
                count++;
                pos++;
            }

            // Declearing the int array
            int[] UserIdsIntArray = new int[count + 1];

            // Asigning the array with initial value
            foreach (int item in UserIdsIntArray)
            {
                UserIdsIntArray[item] = 0;
            }

            // Saperating  The ids into string array
            string[] UserIdsStringArray = InlinePPMData.UserIds.Split(delinComma, StringSplitOptions.None);

            // assigning the value of Id into int attay  and execuating the sp 
            for (int i = 0; i < count + 1; i++)
            {
                if (UserIdsStringArray[i].Trim() == "")
                    continue;

                UserIdsIntArray[i] = Convert.ToInt32(UserIdsStringArray[i]);

                string cmdText = "sp_inline_ppm_attendence_save_attendence";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.Transaction = transaction;

                SqlParameter param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                param.Value = InlinePPMData.InlinePPMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserIdsIntArray[i];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }

        private void InsertInlinePPMFile(InlinePPM InlinePPMData, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_inline_ppm_file_insert_file";

            foreach (InlinePPMFile file in InlinePPMData.InlinePPmFile)
            {
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.Transaction = transaction;

                SqlParameter param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                param.Value = InlinePPMData.InlinePPMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@File", SqlDbType.VarChar);
                param.Value = file.File;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
            }
        }

        public bool DeleteInlinePPMFile(int Id)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_inline_ppm_file_delete_by_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }
        }



        private void SaveTrimsComments(InlinePPM InlinePPMData, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_inline_ppm_trim_insert";

            foreach (InlinePPMTrims trim in InlinePPMData.TrimsComments)
            {
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.Transaction = transaction;

                SqlParameter param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                param.Value = InlinePPMData.InlinePPMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryDetailID", SqlDbType.Int);
                param.Value = trim.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Comments", SqlDbType.VarChar);
                param.Value = trim.TrimsComments;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LastCommentedOn", SqlDbType.DateTime);
                param.Value = DateTime.Today;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }



        private InlinePPM ConvertDataSetToInlinePPM(DataSet dsInlinePPM)
        {
            DataTable dtInline = dsInlinePPM.Tables[0];
            //int intstylenumber = (rows[0]["StyleNumber"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["StyleNumber"]);
            DataRowCollection rows = dtInline.Rows;

            InlinePPM inlinePPM = new InlinePPM();

            inlinePPM.Order = new Order();
            inlinePPM.Order.Style = new Style();

            if (rows.Count > 0)
            {
                string intstylenumber = (rows[0]["StyleNumber"] == DBNull.Value) ? "-1" : Convert.ToString(rows[0]["StyleNumber"]);
                // Id Main Key
                inlinePPM.InlinePPMID = (rows[0]["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["Id"]);

                //Per Production and Top
                inlinePPM.DateHeldOn = (rows[0]["DateHeldOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["DateHeldOn"]);
                inlinePPM.StyleNumber = (rows[0]["StyleNumber"] == DBNull.Value) ? "-1" : Convert.ToString(rows[0]["StyleNumber"]);

                // No Need??
                inlinePPM.AccountManager = new User();
                inlinePPM.AccountManager.UserID = (rows[0]["AccountManagerID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["AccountManagerID"]);
                inlinePPM.FactoryManager = new User();
                inlinePPM.FactoryManager.UserID = (rows[0]["FactoryManagerID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["FactoryManagerID"]);
                inlinePPM.MerchandisingManager = new User();
                inlinePPM.MerchandisingManager.UserID = (rows[0]["MerchandisingManagerID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["MerchandisingManagerID"]);
                inlinePPM.ProductionDirecrtor = new User();
                inlinePPM.ProductionDirecrtor.UserID = (rows[0]["ProductionDirectorID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["ProductionDirectorID"]);
                inlinePPM.ProductionMaster = new User();
                inlinePPM.ProductionMaster.UserID = (rows[0]["ProductionMasterID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["ProductionMasterID"]);
                inlinePPM.QAManager = new User();
                inlinePPM.QAManager.UserID = (rows[0]["QAManagerID"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["QAManagerID"]);
                // No Need???
                inlinePPM.IsApprovedByMerchandisingManager = (rows[0]["IsApprovedByMerchandisingManager"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsApprovedByMerchandisingManager"]);
                inlinePPM.IsApprovedByFactoryManager = (rows[0]["IsApprovedByFactoryManager"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsApprovedByFactoryManager"]);
                inlinePPM.IsApprovedByAccountManager = (rows[0]["IsApprovedByAccountManager"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsApprovedByAccountManager"]);
                inlinePPM.IsApprovedByProductionDirector = (rows[0]["IsApprovedByProductionDirector"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsApprovedByProductionDirector"]);
                inlinePPM.IsApprovedByProductionMaster = (rows[0]["IsApprovedByProductionMaster"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsApprovedByProductionMaster"]);
                inlinePPM.IsApprovedByQAManager = (rows[0]["IsApprovedByQAManager"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsApprovedByQAManager"]);
                inlinePPM.ApprovedByMerchandisingManagerOn = (rows[0]["ApprovedByMerchandisingManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedByMerchandisingManagerOn"]);
                inlinePPM.ApprovedByFactoryManagerOn = (rows[0]["ApprovedByFactoryManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedByFactoryManagerOn"]);
                inlinePPM.ApprovedByAccountManagerOn = (rows[0]["ApprovedByAccountManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedByAccountManagerOn"]);
                inlinePPM.ApprovedByProductionDirectorOn = (rows[0]["ApprovedByProductionDirectorOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedByProductionDirectorOn"]);
                inlinePPM.ApprovedByProductionMasterOn = (rows[0]["ApprovedByProductionMasterOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedByProductionMasterOn"]);
                inlinePPM.ApprovedByQAManagerOn = (rows[0]["ApprovedByQAManagerOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedByQAManagerOn"]);


                // Stitching Comment
                inlinePPM.StitchingComments = (rows[0]["StitchingComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["StitchingComments"]);

                // WashCare
                inlinePPM.WashCareComments = (rows[0]["WashCareComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["WashCareComments"]);

                // Embroidery Portion
                inlinePPM.EMBMachineComments = (rows[0]["EMBMachineComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["EMBMachineComments"]);
                inlinePPM.EMBHandComments = (rows[0]["EMBHandComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["EMBHandComments"]);

                // Lining Portion
                inlinePPM.LiningFusingComments = (rows[0]["LiningFusingComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["LiningFusingComments"]);
                inlinePPM.LiniingInterLiningComments = (rows[0]["LiningInterLiningComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["LiningInterLiningComments"]);
                inlinePPM.LiningPocketLiningComments = (rows[0]["LiningPocketLiningComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["LiningPocketLiningComments"]);
                inlinePPM.LiningShoulderPadComments = (rows[0]["LiningShoulderPadComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["LiningShoulderPadComments"]);

                // Finishing Portion
                inlinePPM.FinishingDCComments = (rows[0]["FinishingDCComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["FinishingDCComments"]);
                inlinePPM.FinishingWashComments = (rows[0]["FinishingWashComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["FinishingWashComments"]);
                inlinePPM.FinishingCrinckleComments = (rows[0]["FinishingCrinckleComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["FinishingCrinckleComments"]);

                // Packing Potion 
                inlinePPM.PackingTagsComments = (rows[0]["PackingTagsComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingTagsComments"]);
                inlinePPM.PackingSpaceButtonsComments = (rows[0]["PackingSpaceButtonsComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingSpaceButtonsComments"]);
                inlinePPM.PackingCardBoardComments = (rows[0]["PackingCardBoardComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingCardBoardComments"]);
                inlinePPM.PackingWOCardBoardComments = (rows[0]["PackingWOCardBoardComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingWOCardBoardComments"]);
                inlinePPM.PackingPolytheneComments = (rows[0]["PackingPolytheneComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingPolytheneComments"]);
                inlinePPM.PackingTissueComments = (rows[0]["PackingTissueComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingTissueComments"]);
                inlinePPM.PackingFoamComments = (rows[0]["PackingFoamComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingFoamComments"]);
                inlinePPM.PackingHangerPackComments = (rows[0]["PackingHangerPackComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingHangerPackComments"]);
                inlinePPM.PackingBoxComments = (rows[0]["PackingBoxComments"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PackingBoxComments"]);

                //  PPm Instruction Portion 
                inlinePPM.PPMInstructions = (rows[0]["PPMInstructions"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PPMInstructions"]);
                inlinePPM.PPMRemarks = (rows[0]["PPMRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PPMRemarks"]);

                // Meeting Attendance Portion
                inlinePPM.IsMeetingComplete = (rows[0]["IsMeetingComplete"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsMeetingComplete"]);

                inlinePPM.BBPlannedMeeting = (rows[0]["BHPlannedMeeting"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["BHPlannedMeeting"]);
                inlinePPM.IsBHMeetingComplete = (rows[0]["IsBHMeetingComplete"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsBHMeetingComplete"]);
                inlinePPM.BHMeetingCompleteOn = (rows[0]["BHMeetingCompletedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["BHMeetingCompletedOn"]);

                inlinePPM.IsMeetingCompletedOn = (rows[0]["IsMeetingCompletedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["IsMeetingCompletedOn"]);
                //inlinePPM.UserIds = (rows[0]["UserIDs"] == DBNull.Value) ? "" : System.Text.ASCIIEncoding.ASCII.GetString((byte[])(rows[0]["UserIDs"])).ToString();
                inlinePPM.UserIds = (rows[0]["UserIDs"] == DBNull.Value) ? "" : rows[0]["UserIDs"].ToString();
                inlinePPM.UserNames = (rows[0]["UserNames"] == DBNull.Value) ? "" : Convert.ToString(rows[0]["UserNames"]);
                inlinePPM.MeetingAttendedOtherUser = (rows[0]["MeetingAttendedOtherUser"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["MeetingAttendedOtherUser"]);

            }
            else
                inlinePPM.InlinePPMID = -1;


            // Trim Portion 
            inlinePPM.TrimsComments = new List<InlinePPMTrims>();

            DataTable dtTrims = dsInlinePPM.Tables[1];

            foreach (DataRow row in dtTrims.Rows)
            {
                InlinePPMTrims trim = new InlinePPMTrims();

                trim.AccessoryName = (row["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["AccessoryName"]);
                trim.TrimsComments = (row["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Comments"]);
                trim.Id = (row["AccessoryID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["AccessoryID"]);

                inlinePPM.TrimsComments.Add(trim);
            }


            // top Section
            inlinePPM.OrderContracts = new List<InlinePPMOrderContract>();

            DataTable dtOrderContracts = dsInlinePPM.Tables[2];
            DataTable dtFabricApproval = dsInlinePPM.Tables[4];

            inlinePPM.Order.TotalQuantity = 0;
            int result;
            foreach (DataRow row in dtOrderContracts.Rows)
            {
                InlinePPMOrderContract orderDetail = new InlinePPMOrderContract();

                // TODO: Populate the fields
                orderDetail.OrderDetailID = (row["OrderContractDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["OrderContractDetailID"]);
                orderDetail.ContractNumber = (row["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ContractNumber"]);
                orderDetail.LineItemNumber = (row["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["LineItemNumber"]);
                orderDetail.TopSentTarget = (row["TopSentTarget"] == DBNull.Value) ? ((row["StitchingETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["StitchingETA"])) : Convert.ToDateTime(row["TopSentTarget"]);
                orderDetail.TopSentActual = (row["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["TopSentActual"]);
                orderDetail.TopActualApproval = (row["TopActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["TopActualApproval"]);
                orderDetail.MDA = (row["MDANumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["MDANumber"]);
                orderDetail.BIPLComments = (row["BIPLComments"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BIPLComments"]);
                orderDetail.iKandiComments = (row["iKandiComments"] == DBNull.Value) ? string.Empty : Convert.ToString(row["iKandiComments"]);
                orderDetail.iKandiUploadFile = (row["iKandiUploadFile"] == DBNull.Value) ? string.Empty : Convert.ToString(row["iKandiUploadFile"]);
                orderDetail.BIPLUploadFile = (row["BIPLUploadFile"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BIPLUploadFile"]);
                orderDetail.Quantity = (row["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Quantity"]);
                orderDetail.ExFactory = (row["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ExFactory"]);
                orderDetail.IsIkandiClient = (row["IsIkandiClient"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IsIkandiClient"]);
                try
                {
                    orderDetail.Fabric1 = (row["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric1"]);
                    orderDetail.Fabric2 = (row["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric2"]);
                    orderDetail.Fabric3 = (row["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric3"]);
                    orderDetail.Fabric4 = (row["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric4"]);
                    orderDetail.CCGSM1 = (row["Fabric11"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric11"]);
                    orderDetail.CCGSM2 = (row["Fabric12"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric12"]);
                    orderDetail.CCGSM3 = (row["Fabric13"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric13"]);
                    orderDetail.CCGSM4 = (row["Fabric14"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric14"]);
                    orderDetail.FabricApproval1 = (row["Approval1"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval1"]);
                    orderDetail.FabricApproval2 = (row["Approval2"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval2"]);
                    orderDetail.FabricApproval3 = (row["Approval3"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval3"]);
                    orderDetail.FabricApproval4 = (row["Approval4"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval4"]);
                }
                catch (Exception)
                {
                }
                orderDetail.Fabric1Details = (row["Fabric1DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric1DetailsRef"]);
                orderDetail.Fabric2Details = (row["Fabric2DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric2DetailsRef"]);
                orderDetail.Fabric3Details = (row["Fabric3DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric3DetailsRef"]);
                orderDetail.Fabric4Details = (row["Fabric4DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric4DetailsRef"]);

                var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                {
                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                    result = 0;
                }

                var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                {
                    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                    result = 0;
                }

                var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                {
                    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                    result = 0;
                }

                var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                {
                    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                    result = 0;
                }

                orderDetail.SealerRemarksBIPL = (row["RemarksBIPL"] == DBNull.Value) ? string.Empty : Convert.ToString(row["RemarksBIPL"]);
                orderDetail.SealerRemarksiKandi = (row["RemarksIKANDI"] == DBNull.Value) ? string.Empty : Convert.ToString(row["RemarksIKANDI"]);

                orderDetail.ParentOrder = new Order();
                orderDetail.ParentOrder.SerialNumber = (row["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["SerialNumber"]);
                orderDetail.ParentOrder.OrderDate = (row["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["OrderDate"]);
                orderDetail.ParentOrder.DepartmentID = (row["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["DepartmentID"]);


                orderDetail.ParentOrder.Style = new Style();
                orderDetail.ParentOrder.Style.InLineCutDate = (row["InlineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["InlineCutDate"]);
                orderDetail.ParentOrder.Style.StyleID = (row["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["StyleID"]);

                orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                orderDetail.ParentOrder.Style.cdept.DeptID = (row["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["DepartmentID"]);
                orderDetail.ParentOrder.Style.cdept.Name = (row["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DepartmentName"]);

                orderDetail.Unit = new ProductionUnit();
                orderDetail.Unit.ProductionUnitId = (row["UnitID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["UnitID"]);
                orderDetail.Unit.FactoryCode = (row["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FactoryCode"]);
                orderDetail.Unit.FactoryName = (row["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FactoryName"]);

                inlinePPM.Order.TotalQuantity += orderDetail.Quantity;

                orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (row["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse1"]);
                orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (row["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse2"]);
                orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (row["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse3"]);
                orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (row["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse4"]);
                orderDetail.FabClass = (row["FabClass"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FabClass"]);
                orderDetail.DetailClass = (row["DetailClass"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DetailClass"]);

                string strx = "OrderDetailID =" + orderDetail.OrderDetailID;

                DataRow[] DataRows3;
                DataRows3 = dtFabricApproval.Select(strx);
                int F1Status = 0;
                int F2Status = 0;
                int F3Status = 0;
                int F4Status = 0;
                int F5Status = 0;
                int F6Status = 0;

                int F1Stage = 0;
                int F2Stage = 0;
                int F3Stage = 0;
                int F4Stage = 0;
                int F5Stage = 0;
                int F6Stage = 0;

                DateTime ActionDate1 = DateTime.MinValue;
                DateTime ActionDate2 = DateTime.MinValue;
                DateTime ActionDate3 = DateTime.MinValue;
                DateTime ActionDate4 = DateTime.MinValue;
                DateTime ActionDate5 = DateTime.MinValue;
                DateTime ActionDate6 = DateTime.MinValue;
                foreach (DataRow dr6 in DataRows3)
                {
                    F1Status = (dr6["F1Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F1Status"]) : 0;
                    F2Status = (dr6["F2Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F2Status"]) : 0;
                    F3Status = (dr6["F3Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F3Status"]) : 0;
                    F4Status = (dr6["F4Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F4Status"]) : 0;

                    F1Stage = (dr6["F1Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F1Stage"]) : 0;
                    F2Stage = (dr6["F2Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F2Stage"]) : 0;
                    F3Stage = (dr6["F3Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F3Stage"]) : 0;
                    F4Stage = (dr6["F4Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F4Stage"]) : 0;

                    ActionDate1 = (dr6["ActionDate1"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate1"]) : DateTime.MinValue;
                    ActionDate2 = (dr6["ActionDate2"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate2"]) : DateTime.MinValue;
                    ActionDate3 = (dr6["ActionDate3"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate3"]) : DateTime.MinValue;
                    ActionDate4 = (dr6["ActionDate4"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate4"]) : DateTime.MinValue;

                }

                orderDetail.ParentOrder.FabricApprovalDetails = new FabricApprovalDetails();
                orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus = "";
                orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus = "";
                orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus = "";
                orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus = "";
                orderDetail.ParentOrder.FabricApprovalDetails.F9BulkStatus = "";
                orderDetail.ParentOrder.FabricApprovalDetails.F10BulkStatus = "";
                
               

                orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus = Constants.GetFabricStatus(F1Stage, F1Status, ActionDate1);
                orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus = Constants.GetFabricStatus(F2Stage, F2Status, ActionDate2);
                orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus = Constants.GetFabricStatus(F3Stage, F3Status, ActionDate3);
                orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus = Constants.GetFabricStatus(F4Stage, F4Status, ActionDate4);
                orderDetail.ParentOrder.FabricApprovalDetails.F9BulkStatus = Constants.GetFabricStatus(F5Stage, F5Status, ActionDate5);
                orderDetail.ParentOrder.FabricApprovalDetails.F10BulkStatus = Constants.GetFabricStatus(F6Stage, F6Status, ActionDate6);

                orderDetail.TopStatus = (row["TopStatus"] == DBNull.Value) ? TopStatusType.UNKNOWN : (TopStatusType)Convert.ToInt32(row["TopStatus"]);

                inlinePPM.OrderContracts.Add(orderDetail);
            }


            DataTable dtOrder = dsInlinePPM.Tables[3];

            rows = dtOrder.Rows;

            if (rows.Count > 0)
            {
                inlinePPM.Order.Client = new Client();
                inlinePPM.Order.Client.IsMDARequired = (rows[0]["IsMDARequired"] == DBNull.Value) ? 0 : (Convert.ToBoolean(rows[0]["IsMDARequired"]) ? 1 : 0);
                inlinePPM.Order.Client.CompanyName = (rows[0]["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["CompanyName"]);
                inlinePPM.Order.Style.StyleNumber = (rows[0]["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["StyleNumber"]);
                inlinePPM.Order.Style.SampleImageURL1 = (rows[0]["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["SampleImageURL1"]);
                inlinePPM.Order.Style.SampleImageURL2 = (rows[0]["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["SampleImageURL2"]);
                inlinePPM.Order.Style.SampleImageURL3 = (rows[0]["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["SampleImageURL3"]);
                inlinePPM.Order.Style.InLineCutDate = (rows[0]["InlineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["InlineCutDate"]);
            }

            DataTable dtProduction = dsInlinePPM.Tables[5];
            rows = dtProduction.Rows;
            if (rows.Count > 0)
            {
                inlinePPM.ProdSAM = (rows[0]["ProductionSAM"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["ProductionSAM"]);
                inlinePPM.ProdOB = (rows[0]["ProductionOB"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["ProductionOB"]);
                inlinePPM.ProdSamFile = (rows[0]["UploadSAMFile"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["UploadSAMFile"]);
                inlinePPM.ProdOBfile = (rows[0]["UploadOBFile"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["UploadOBFile"]);
            }


            return inlinePPM;
        }

        #endregion

    }
}
