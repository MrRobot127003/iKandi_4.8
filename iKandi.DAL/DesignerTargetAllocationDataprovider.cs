using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
   public class DesignerTargetAllocationDataprovider:BaseDataProvider
    {
         #region Ctor(s)

        public DesignerTargetAllocationDataprovider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion


        public DataSet GetDTAByDesignerId(int DesignerId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_designer_target_allocation_get_by_designer_id";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = DesignerId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsDesignerTarget = new DataSet();
                SqlDataAdapter adpapter = new SqlDataAdapter(cmd);
                adpapter.Fill(dsDesignerTarget);
                cnx.Close();
                return dsDesignerTarget;

            }
        
        }

        public DataSet GetAllDTA(int iBHId, int iClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_designer_target_allocation_get_all";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@BHId", SqlDbType.Int);
                param.Value = iBHId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = iClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsDesignerTarget = new DataSet();
                SqlDataAdapter adpapter = new SqlDataAdapter(cmd);
                adpapter.Fill(dsDesignerTarget);
                cnx.Close();
                return dsDesignerTarget;
            }
        }

      
        public int UpdateDesignerTargetAllocation(DesignerTargetAllocation objDesignerTarget)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_designer_target_allocation_update_designer_target_allocation";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = objDesignerTarget.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetTurnOver", SqlDbType.VarChar);
                param.Value = objDesignerTarget.TargetTurnOver;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetTurnOver_BIPL", SqlDbType.VarChar);
                param.Value = objDesignerTarget.TargetTurnOver_BIPL;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@TotalSamplingAllocation", SqlDbType.Int);
                param.Value = objDesignerTarget.TotalSamplingAllocation;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetHitRate", SqlDbType.Int);
                param.Value = objDesignerTarget.TargetHitRateStyle;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@DesignerID", SqlDbType.Int);
                //param.Value = objDesignerTarget.DesignerID;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = objDesignerTarget.Client.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                param.Value = objDesignerTarget.DepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@SalesExecutiveId", SqlDbType.Int);
                //param.Value = objDesignerTarget.SalesExecutiveId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@TotalPrintAllocation", SqlDbType.Int);
                param.Value = objDesignerTarget.TotalPrintAllocation;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetHitRatePrint", SqlDbType.Int);
                param.Value = objDesignerTarget.TargetHitRatePrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AverageBhPrice", SqlDbType.Float);
                param.Value = objDesignerTarget.AverageBhPrice;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CalculatedQty", SqlDbType.Float);
                param.Value = objDesignerTarget.CalculatedQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                int ID = objDesignerTarget.Id;
                cnx.Close();
                return ID;
            }
        }

    }
}
