using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using iKandi.Common;
using iKandi.Common.Entities;

namespace iKandi.DAL
{
  public  class CmtAdminDataProvider : BaseDataProvider
    {
        //Readded by abhishek on 26/10/2015



      public int UpdateCMTAdmin(int CMTId, float AvlMinCost, float hrs, int barrierDays, int hdnUId, float txtpro_availble_mincost, float pro_hours,int maxload,int createobdays,int barrirday)
        {
            int Id = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdtext = "Usp_updateCMTAdmin";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@CmtID", SqlDbType.Int);
                param.Value = CMTId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AvlMinCost", SqlDbType.Float);
                param.Value = AvlMinCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@hrs", SqlDbType.Float);
                param.Value = hrs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@barrierDays", SqlDbType.Int);
                param.Value = barrierDays;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@txtpro_availble_mincost", SqlDbType.Float);
                param.Value = txtpro_availble_mincost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = hdnUId; 
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifyBy", SqlDbType.Int);
                param.Value = hdnUId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@pro_hours", SqlDbType.Float);
                param.Value = pro_hours;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MxLoad", SqlDbType.Int);
                param.Value = maxload;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@createobdays", SqlDbType.Int);
                param.Value = createobdays;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@BarrierdayforMAsterAllocation", SqlDbType.Int);
                param.Value = barrirday;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                Id = cmd.ExecuteNonQuery();
                cnx.Close();
                return Id;
            }
        }

      //added by bharat on 25-july
      public int InsertCRTOrderQty(int textval, int Sr_No, string Flag)
      {
          int Id = 0;
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
              cnx.Open();

              SqlDataAdapter adapter = new SqlDataAdapter();

              string cmdtext = "Usp_updateCRTOrderQtyn";

              SqlCommand cmd = new SqlCommand(cmdtext, cnx);

              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
              SqlParameter param;

              param = new SqlParameter("@textval", SqlDbType.Int);
              param.Value = textval;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@Sr_No", SqlDbType.Int);
              param.Value = Sr_No;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@Flag", SqlDbType.VarChar);
              param.Value = Flag;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);


              Id = cmd.ExecuteNonQuery();
              cnx.Close();
              return Id;
          }
      }
     //end  
        public int Update_FinancialDetail(string From, string to)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int id = 0;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdtext = "UpdateFinancialMonth_ForMO";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@From", SqlDbType.VarChar);
                param.Value = From;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@To", SqlDbType.VarChar);
                param.Value = to;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);





                cmd.ExecuteNonQuery();
                cnx.Close();

                return id;
            }

        }
        //end by abhishek on 26/10/2015
        public DataTable GetCmtDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;


                cmdText = "Usp_GetCmtAdmin";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();

                return dt1;
            }
        }

      //end by abhishek on 26/10/2015
       
        //

        public DataTable TargetDaysDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;


                cmdText = "Usp_GetTargetDays";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();

                return dt1;
            }
        }
        public DataTable GetAchievmentLabelsDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;


                cmdText = "Usp_GetAchievmentCMT";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();

                return dt1;
            }
        }
        public int InsertUpdateCMTEffDAL(CMTAdmin pro_cmt)
        {
            
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                int id = 0;
                string cmdtext = "Usp_insertUpdateCmtTargeEff";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TargetEffID", SqlDbType.Int);
                param.Value = pro_cmt.TargetEffID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Day", SqlDbType.Int);
                param.Value = pro_cmt.Day;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetDayEff", SqlDbType.Float);
                param.Value = pro_cmt.TargetDayEff;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = pro_cmt.CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifyBy", SqlDbType.Int);
                param.Value =pro_cmt.ModifyBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostingTargetDayEff", SqlDbType.Float);
                param.Value = pro_cmt.TargetDayCostingEff;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

               id=cmd.ExecuteNonQuery();
                cnx.Close();

                return id;
            }
           
        }
        //
        public int InsertUpdateCMTEAchievementdal(CMTAdmin pro_cmt)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                int id = 0;
                string cmdtext = "Usp_InsertUpdateAchievementlabels";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@AchievementlabelsID", SqlDbType.Int);
                param.Value = pro_cmt.AchievementlabelsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Achivementlabels", SqlDbType.VarChar);
                param.Value = pro_cmt.Achievement;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.VarChar);
                param.Value = pro_cmt.CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifyBy", SqlDbType.VarChar);
                param.Value = pro_cmt.ModifyBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                id = cmd.ExecuteNonQuery();
                cnx.Close();

                return id;
            }

        }


        #region GetSizeSet
        public List<CMTSizeAdmin> GetSizeSetAdmin()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "GetSizeSet";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt == null || dt.Rows.Count < 1)
                    return null;
                //return GetSizeSetFromTable(ds.Tables[1]);
                List<CMTSizeAdmin> lst = new List<CMTSizeAdmin>();
                foreach (DataRow d in dt.Rows)
                {
                    CMTSizeAdmin sc = new CMTSizeAdmin();
                    sc.SizeOption = d["SizeOption"] == DBNull.Value ? 0 : Convert.ToInt32(d["SizeOption"]);
                    sc.Sizes = d["Size"] == DBNull.Value ? "" : Convert.ToString(d["Size"]);

                    lst.Add(sc);
                }
                return lst;
            }
        }
        #endregion

        public DataTable GetSizeSet()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;


                cmdText = "GetSizeSet";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();

                return dt1;
            }
        }

        public int InsertSizeSet(List<CMTSizeAdmin> pos)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                int id = 0;
                string tbl = "<root>";
                foreach (var ss in pos)
                {
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size1 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size2 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size3 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size4 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size5 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size6 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size7 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size8 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size9 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size10 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size11 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size12 + "</Size></table>";

                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size13 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size14 + "</Size></table>";
                    tbl += "<table><SizeOption>" + ss.SizeOption + "</SizeOption>";
                    tbl += "<Size>" + ss.Size15 + "</Size></table>";

                }
                tbl += "</root>";



                const string cmdText = "Usp_InsertSizeSet";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                SqlParameter param1 = new SqlParameter("@xml", SqlDbType.VarChar);
                param1.Value = tbl;
                param1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param1);

                //SqlParameter param = new SqlParameter("@GroupInitial", SqlDbType.VarChar);
                //param.Value = prm_SupplierClass.GroupInitials;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);
                return id = cmd.ExecuteNonQuery();

            }
        }

        public List<CMTSizeAdmin> GetSizeSetById(int Option)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "GetSizeSetByOptipn";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@Option", SqlDbType.VarChar);
                param.Value = Option;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt == null || dt.Rows.Count < 1)
                    return null;
                //return GetSizeSetFromTable(ds.Tables[1]);
                List<CMTSizeAdmin> lst = new List<CMTSizeAdmin>();
                foreach (DataRow d in dt.Rows)
                {
                    CMTSizeAdmin sc = new CMTSizeAdmin();
                    sc.SizeOption = d["SizeOption"] == DBNull.Value ? 0 : Convert.ToInt32(d["SizeOption"]);
                    sc.Sizes = d["Size"] == DBNull.Value ? "" : Convert.ToString(d["Size"]);

                    lst.Add(sc);
                }
                return lst;
            }
        }

        protected List<CMTSizeAdmin> GetSizeSetFromTable(DataTable dt)
        {
            List<CMTSizeAdmin> lst = new List<CMTSizeAdmin>();
            foreach (DataRow d in dt.Rows)
            {
                CMTSizeAdmin sc = new CMTSizeAdmin();
                sc.SizeOption = d["SizeOption"] == DBNull.Value ? 0 : Convert.ToInt32(d["SizeOption"]);
                sc.Size1 = d["Size"] == DBNull.Value ? "" : Convert.ToString(d["Size"]);

                lst.Add(sc);
            }
            return lst;
        }
        //Adde By Ashish on 25/12/2014
        public DataTable BarrierDaysDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;


                cmdText = "USP_GetBarrierDays";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dt1 = new DataTable();
                //DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt1);
                //DataTable dt1 = ds.Tables[0];
                cnx.Close();

                return dt1;
            }
        }

        //Added By Ashish on 25/12/2014
        public int UpdateBarrierDaysDAL(CMTAdmin pro_cmt)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                int id = 0;
                string cmdtext = "Usp_UpdateBarrierDays";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@BarrierId", SqlDbType.Int);
                param.Value = pro_cmt.BarrierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartMin", SqlDbType.Float);
                param.Value = pro_cmt.StartMin;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndMin", SqlDbType.Float);
                param.Value = pro_cmt.EndMin;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Barrier", SqlDbType.Float);
                param.Value = pro_cmt.Barrier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                id = cmd.ExecuteNonQuery();
                cnx.Close();

                return id;
            }

        }
      //added by abhishek on 27/8/2015
        public DataTable getOtCMTdetails()
        {
            
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetCmtOtValue";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dt1 = new DataTable();
              
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt1);
              
                cnx.Close();

                return dt1;
            }
        }
        public DataTable Financial_dt()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetFinancialMonth";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dtFinancial = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFinancial);

                cnx.Close();

                return dtFinancial;
            }
        }
        public DataTable ProductionCost_dt()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetProduction_Stiching_Finshing_Cost";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dtProductionCost = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtProductionCost);

                cnx.Close();

                return dtProductionCost;
            }
        }
        public DataTable OBCost_dt()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetOBPerPices_Cost";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dtProductionCost = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtProductionCost);

                cnx.Close();

                return dtProductionCost;
            }
        }

        public int Update_getOtCMTdetails(double ot1, double ot2, double ot3, double ot4)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int id = 0;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
             
                string cmdtext = "UpdateOTCmtValue";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ot1", SqlDbType.Float);
                param.Value = ot1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ot2", SqlDbType.Float);
                param.Value = ot2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ot3", SqlDbType.Float);
                param.Value = ot3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ot4", SqlDbType.Float);
                param.Value = ot4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                cmd.ExecuteNonQuery();
                cnx.Close();

                return id;
            }

        }
        public int Update_getProductionPieces(double Stiching, double Finishing)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int id = 0;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdtext = "UpdateProductionPerPices_Cost";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Stiching", SqlDbType.Float);
                param.Value = Stiching;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Finishing", SqlDbType.Float);
                param.Value = Finishing;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

                return id;
            }

        }
        public int Update_OBCostPerPieces(double CuttingCost, double FactoryOverHead, double OBPerPicesCost, double FinishingCost, double FabricCost, double AccesoriesCost, double LabourBaseSalary, double PFESI, double DiwaliGift, double Gratuity, double WorkingDays, int ActualWorkingDays, double IGST, double CGST, double SGST, int CMTOHSLOT)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int id = 0;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdtext = "UpdateOBPerPices_Cost";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@CuttingCost", SqlDbType.Float);
                param.Value = CuttingCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FactoryOverHeadCost", SqlDbType.Float);
                param.Value = FactoryOverHead;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OBPerPicesCost", SqlDbType.Float);
                param.Value = OBPerPicesCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinishingCost", SqlDbType.Float);
                param.Value = FinishingCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricCost", SqlDbType.Float);
                param.Value = FabricCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccesoriesCost", SqlDbType.Float);
                param.Value = AccesoriesCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LabourBaseSalary", SqlDbType.Float);
                param.Value = LabourBaseSalary;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PFESI", SqlDbType.Float);
                param.Value = PFESI;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DiwaliGift", SqlDbType.Float);
                param.Value = DiwaliGift;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Gratuity", SqlDbType.Float);
                param.Value = Gratuity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WorkingDays", SqlDbType.Float);
                param.Value = WorkingDays;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActualWorkingDays", SqlDbType.Float);
                param.Value = ActualWorkingDays;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IGST", SqlDbType.Float);
                param.Value = IGST;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CGST", SqlDbType.Float);
                param.Value = CGST;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SGST", SqlDbType.Float);
                param.Value = SGST;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CMTOHSLOT", SqlDbType.Int);
                param.Value = CMTOHSLOT;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param); 

                cmd.ExecuteNonQuery();
                cnx.Close();

                return id;
            }

        }


      // Added By Ravi kumar on 18-4-18 for Update sunday working
        public int UpdateSundayWorking(int IsSundayWorking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int id = 0;
                cnx.Open();             

                string cmdtext = "UpdateSundayWorking";

                SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@IsSundayWorking", SqlDbType.Bit);
                param.Value = IsSundayWorking;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);                

                id  = cmd.ExecuteNonQuery();
                cnx.Close();
                return id;
            }

        }
       

      //End by abhishek on 27/8/2015

      //added by abhishek on 26/10/2015
        public int Update_CMT_barrieday(string Colname,int ColVal)
        {
            int id = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                   
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdtext = "Usp_UpdateCMT";

                    SqlCommand cmd = new SqlCommand(cmdtext, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Col_name", SqlDbType.VarChar);
                    param.Value = Colname;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Col_val", SqlDbType.Int);
                    param.Value = ColVal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);




                    id = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return id;
        }
        public DataTable getOtCMTdetails_barrieday()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "select isnull(BIHDays, 0) as BIHDays, isnull(Barrier_Days_Slot_1_Max, 0) as Barrier_Days_Slot_1_Max, isnull(Barrier_Days_Slot_1_Values, 0) as Barrier_Days_Slot_1_Values, isnull(Barrier_Days_Slot_2_Min, 0) as Barrier_Days_Slot_2_Min, isnull(Barrier_Days_Slot_2_Max, 0) as Barrier_Days_Slot_2_Max, isnull(Barrier_Days_Slot_2_Values, 0) as Barrier_Days_Slot_2_Values, isnull(Barrier_Days_Slot_3_Min, 0) as Barrier_Days_Slot_3_Min, isnull(Barrier_Days_Slot_3_Values,0) as Barrier_Days_Slot_3_Values from tblCMTAdmin";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dt1 = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt1);

                cnx.Close();

                return dt1;
            }
        }
      //end by abhishek on 26/10/2015
      //added by abhishek for cmt costing

        public DataSet GetCmtExpectedQty()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;


                cmdText = "Usp_GetCmtExpectedQty";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable dt1 = ds.Tables[0];
                cnx.Close();

                return ds;
            }
        }
        //public string UpdateCmtCostingExpectedQty(CMTAdmin objCmt)
        //{
        //    string str = string.Empty;
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        DataTable dt = new DataTable();

        //        cnx.Open();
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "Usp_UpdateCostingMultiplier";
        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param;

        //        param = new SqlParameter("@MultiplierId", SqlDbType.Int);
        //        param.Value = objCmt.Costing_MultiplierId;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@MinExpectedQty", SqlDbType.Int);
        //        param.Value = objCmt.MinExpectedQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@MaxExpectedQty", SqlDbType.Int);
        //        param.Value = objCmt.MaxExpectedQty;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Muliplier", SqlDbType.Int);
        //        param.Value = objCmt.Muliplier;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Flag", SqlDbType.VarChar);
        //        param.Value = objCmt.Flag;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //        adapter.Fill(dt);
        //        str = dt.Rows[0]["Result"].ToString();
        //        return (str);

        //    }
        //}
        public string UpdateCmtCostingExpectedQty(CMTAdmin objCmt)
        {
            string str = string.Empty;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_UpdateCostingMultiplier";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@MultiplierId", SqlDbType.Int);
                param.Value = objCmt.Costing_MultiplierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MinExpectedQty", SqlDbType.Int);
                param.Value = objCmt.MinExpectedQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MaxExpectedQty", SqlDbType.Int);
                param.Value = objCmt.MaxExpectedQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Muliplier", SqlDbType.Int);
                param.Value = objCmt.Muliplier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = objCmt.Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                str = dt.Rows[0]["Result"].ToString();
                return (str);

            }
        }
    }
}
