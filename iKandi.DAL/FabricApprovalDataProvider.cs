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
  public class FabricApprovalDataProvider : BaseDataProvider
  {
    #region Ctor(s)

    public FabricApprovalDataProvider(SessionInfo LoggedInUser)
      : base(LoggedInUser)
    {
    }

    #endregion

    #region Insertion Methods

    public bool InsertFabricApproval(FabricApproval fabricApproval)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        SqlTransaction transaction = null;

        try
        {
          string cmdText = "sp_fabric_approval_insert_fabric_Approval";
          cnx.Open();

          transaction = cnx.BeginTransaction();

          SqlCommand cmd = new SqlCommand(cmdText, cnx);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
          //cmd.CommandTimeout = 600000;
          cmd.Transaction = transaction;

          SqlParameter outParam;
          outParam = new SqlParameter("@d", SqlDbType.Int);
          outParam.Direction = ParameterDirection.Output;
          cmd.Parameters.Add(outParam);

          SqlParameter param;

          param = new SqlParameter("@FabricName", SqlDbType.VarChar);
          param.Value = fabricApproval.FabricName;
          param.Direction = ParameterDirection.Input;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@ClientID", SqlDbType.Int);
          param.Value = fabricApproval.ClientID;
          param.Direction = ParameterDirection.Input;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
          param.Value = fabricApproval.FabricDetails;
          if (fabricApproval.FabricDetails.IndexOf("PRD:") > -1 || fabricApproval.FabricDetails.IndexOf("prd") > -1)
          {
              string[] fab2 = fabricApproval.FabricDetails.Split('(');
              fabricApproval.FabricDetails = fab2[0].Replace("PRD:", "");
              fabricApproval.FabricDetails = fabricApproval.FabricDetails.Replace("prd:", "");
          }
          param.Direction = ParameterDirection.Input;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@OrderID", SqlDbType.Int);
          if (fabricApproval.OrderID == -1)
              param.Value = DBNull.Value;
          else
          param.Value = fabricApproval.OrderID;
          param.Direction = ParameterDirection.Input;
          cmd.Parameters.Add(param);

          param = new SqlParameter("@StyleID", SqlDbType.Int);
          if (fabricApproval.StyleID == -1)
              param.Value = DBNull.Value;
          else
              param.Value = fabricApproval.StyleID;
          param.Direction = ParameterDirection.Input;
          cmd.Parameters.Add(param);

          int fabricApprovalId = fabricApproval.Id;

          if (fabricApproval.Id == -1 && fabricApproval.FabricName.Trim() != string.Empty)
          {
              cmd.ExecuteNonQuery();
              fabricApprovalId = Convert.ToInt32(outParam.Value);
          }

          if (fabricApproval.FabricName.Trim() == string.Empty)
          {
              fabricApprovalId = -1;
          }

          //if (fabricApprovalId == -1)
          //  return false;

          

          if (fabricApproval.LabDipApproval != null && fabricApproval.LabDipApproval.Count > 0)
            foreach (FabricApprovalDetails labDipFabricApproval in fabricApproval.LabDipApproval)
            {
              if (labDipFabricApproval.Id == -1)
              {
                  if (fabricApprovalId != -1)
                  {
                      labDipFabricApproval.FabricApprovalId = fabricApprovalId;
                      int labDipId = InsertLabDipFabricApproval(labDipFabricApproval, cnx, transaction);
                      labDipFabricApproval.Id = labDipId;
                  }
              }
            }

          if (fabricApproval.BulkApproval != null && fabricApproval.BulkApproval.Count > 0)
            foreach (FabricApprovalDetails bulkFabricApproval in fabricApproval.BulkApproval)
            {
              if (bulkFabricApproval.Id == -1)
              {
                  if (fabricApprovalId != -1)
                  {
                      bulkFabricApproval.FabricApprovalId = fabricApprovalId;
                      int bulkId = InsertBulkFabricApproval(bulkFabricApproval, cnx, transaction);
                      bulkFabricApproval.Id = bulkId;
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

    public int InsertLabDipFabricApproval(FabricApprovalDetails labDipFabricApproval, SqlConnection cnx, SqlTransaction transaction)
    {

      SqlDataAdapter adapter = new SqlDataAdapter();

      string cmdText = "sp_fabric_approval_history_insert_fabric_approval_history";


      SqlCommand cmd = new SqlCommand(cmdText, cnx);

      cmd.CommandType = CommandType.StoredProcedure;
      cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
      cmd.Transaction = transaction;
      SqlParameter outParam;

      outParam = new SqlParameter("@d", SqlDbType.Int);
      outParam.Direction = ParameterDirection.Output;
      cmd.Parameters.Add(outParam);

      SqlParameter param;

      param = new SqlParameter("@FabricApprovalId", SqlDbType.Int);
      param.Value = labDipFabricApproval.FabricApprovalId;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@Stage", SqlDbType.Int);
      param.Value = labDipFabricApproval.Stage;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@SentDate", SqlDbType.DateTime);
      if ((labDipFabricApproval.SentDate == DateTime.MinValue) || (labDipFabricApproval.SentDate == Convert.ToDateTime("1753-01-01")) || (labDipFabricApproval.SentDate == Convert.ToDateTime("1900-01-01")))
      {
          param.Value = DBNull.Value;
      }
      else
      {
          param.Value = labDipFabricApproval.SentDate;
      }     
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@DHLNumber", SqlDbType.VarChar);
      param.Value = labDipFabricApproval.DHLNumber;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);


      param = new SqlParameter("@Status", SqlDbType.VarChar);
      param.Value = labDipFabricApproval.Status;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@Remarks", SqlDbType.VarChar);
      param.Value = labDipFabricApproval.Remarks;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
      if ((labDipFabricApproval.ActionDate == DateTime.MinValue) || (labDipFabricApproval.ActionDate == Convert.ToDateTime("1753-01-01")) || (labDipFabricApproval.ActionDate == Convert.ToDateTime("1900-01-01")))
      {
          param.Value = DBNull.Value;
      }
      else
      {
          param.Value = labDipFabricApproval.ActionDate;
      }    
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      cmd.ExecuteNonQuery();

      int labDipId = Convert.ToInt32(outParam.Value);

      return labDipId;


    }

    public int InsertBulkFabricApproval(FabricApprovalDetails bulkFabricApproval, SqlConnection cnx, SqlTransaction transaction)
    {

      SqlDataAdapter adapter = new SqlDataAdapter();

      string cmdText = "sp_fabric_approval_history_insert_fabric_approval_history";
     
      SqlCommand cmd = new SqlCommand(cmdText, cnx);

      cmd.CommandType = CommandType.StoredProcedure;
      cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
      cmd.Transaction = transaction;
      SqlParameter outParam;

      outParam = new SqlParameter("@d", SqlDbType.Int);
      outParam.Direction = ParameterDirection.Output;
      cmd.Parameters.Add(outParam);

      SqlParameter param;

      param = new SqlParameter("@FabricApprovalId", SqlDbType.Int);
      param.Value = bulkFabricApproval.FabricApprovalId;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@Stage", SqlDbType.Int);
      param.Value = bulkFabricApproval.Stage;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@SentDate", SqlDbType.DateTime);
      if ((bulkFabricApproval.SentDate == DateTime.MinValue) || (bulkFabricApproval.SentDate == Convert.ToDateTime("1753-01-01")) || (bulkFabricApproval.SentDate == Convert.ToDateTime("1900-01-01")))
      {
          param.Value = DBNull.Value;
      }
      else
      {
          param.Value = bulkFabricApproval.SentDate;
      }  
      
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@DHLNumber", SqlDbType.VarChar);
      param.Value = bulkFabricApproval.DHLNumber;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@Status", SqlDbType.VarChar);
      param.Value = bulkFabricApproval.Status;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@Remarks", SqlDbType.VarChar);
      param.Value = bulkFabricApproval.Remarks;
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@ActionDate", SqlDbType.DateTime);
      if ((bulkFabricApproval.ActionDate == DateTime.MinValue) || (bulkFabricApproval.ActionDate == Convert.ToDateTime("1753-01-01")) || (bulkFabricApproval.ActionDate == Convert.ToDateTime("1900-01-01")))
      {
          param.Value = DBNull.Value;
      }
      else
      {
          param.Value = bulkFabricApproval.ActionDate;
      }     
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      cmd.ExecuteNonQuery();

      int bulkId = Convert.ToInt32(outParam.Value);

      return bulkId;


    }

    #endregion

    #region Read Methods

    public FabricApproval GetFabricApproval(int FabricApprovalID)
    {
      FabricApproval fabricApproval = new FabricApproval();

      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        try
        {
          string cmdText = "sp_fabric_approval_get_fabric_approval_with_history";

          SqlCommand cmd = new SqlCommand(cmdText, cnx);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
          SqlParameter param = new SqlParameter("@FabricApprovalId", SqlDbType.Int);
          param.Value = FabricApprovalID;
          param.Direction = ParameterDirection.Input;
          cmd.Parameters.Add(param);

          DataSet dsFabricApproval = new DataSet();
          SqlDataAdapter adapter = new SqlDataAdapter(cmd);

          adapter.Fill(dsFabricApproval);

          if (dsFabricApproval.Tables[0].Rows.Count > 0)
            fabricApproval = ConvertDataSetToFabricApproval(dsFabricApproval);

        }
        catch (SqlException ex)
        {
            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        }
      }

      return fabricApproval;
    }

    private FabricApproval ConvertDataSetToFabricApproval(DataSet dsFabricApproval)
    {
      FabricApproval fabricApproval = new FabricApproval();

      DataTable dt = dsFabricApproval.Tables[0];

      DataRow row1 = dt.Rows[0];

      fabricApproval.FabricName = (row1["FabricName"] == null) ? string.Empty : Convert.ToString(row1["FabricName"]);
      fabricApproval.Id = (row1["Id"] == null) ? 0 : Convert.ToInt32(row1["Id"]);


      dt = dsFabricApproval.Tables[1];
      fabricApproval.LabDipApproval = new List<FabricApprovalDetails>();

      if (dt.Rows.Count > 0)
      {
        foreach (DataRow dr in dt.Rows)
        {
          FabricApprovalDetails labDipFabricApproval = new FabricApprovalDetails();
          labDipFabricApproval.Stage = (dr["Stage"] == null) ? 0 : Convert.ToInt32(dr["Stage"]);
          labDipFabricApproval.SentDate = (dr["SentDate"] == null || dr["SentDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(dr["SentDate"]);
          labDipFabricApproval.DHLNumber = (dr["DHLNumber"] == null) ? string.Empty : Convert.ToString(dr["DHLNumber"]);
          labDipFabricApproval.Status = (dr["Status"] == null) ? string.Empty : Convert.ToString(dr["Status"]);
          labDipFabricApproval.Remarks = (dr["Remarks"] == null) ? string.Empty : Convert.ToString(dr["Remarks"]);
          labDipFabricApproval.ActionDate = (dr["ActionDate"] == null || dr["ActionDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(dr["ActionDate"]);
          labDipFabricApproval.FabricApprovalId = (dr["FabricApprovalId"] == null) ? 0 : Convert.ToInt32(dr["FabricApprovalId"]);

          fabricApproval.LabDipApproval.Add(labDipFabricApproval);
        }
      }

      dt = dsFabricApproval.Tables[2];
      fabricApproval.BulkApproval = new List<FabricApprovalDetails>();

      if (dt.Rows.Count > 0)
      {
        foreach (DataRow dr in dt.Rows)
        {
          FabricApprovalDetails bulkFabricApproval = new FabricApprovalDetails();
          bulkFabricApproval.Stage = (dr["Stage"] == null) ? 0 : Convert.ToInt32(dr["Stage"]);
          bulkFabricApproval.SentDate = (dr["SentDate"] == null || dr["SentDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(dr["SentDate"]);
          bulkFabricApproval.DHLNumber = (dr["DHLNumber"] == null) ? string.Empty : Convert.ToString(dr["DHLNumber"]);
          bulkFabricApproval.Status = (dr["Status"] == null) ? string.Empty : Convert.ToString(dr["Status"]);
          bulkFabricApproval.Remarks = (dr["Remarks"] == null) ? string.Empty : Convert.ToString(dr["Remarks"]);
          bulkFabricApproval.ActionDate = (dr["ActionDate"] == null || dr["ActionDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(dr["ActionDate"]);
          bulkFabricApproval.FabricApprovalId = (dr["FabricApprovalId"] == null) ? 0 : Convert.ToInt32(dr["FabricApprovalId"]);

          fabricApproval.BulkApproval.Add(bulkFabricApproval);
        }
      }
      return fabricApproval;
    }





    





    public DataSet GetLabDipHistory(int clientID, string fabric, int orderID, int styleid, string fabricDetails)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        string cmdText = "sp_fabric_approval_history_get_fabric_approval_history_lab";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        SqlParameter param1 = new SqlParameter("@ClientID", SqlDbType.Int);
        param1.Value = clientID;
        param1.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param1);

        SqlParameter param2 = new SqlParameter("@Fabric", SqlDbType.VarChar);
        param2.Value = fabric;
        param2.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param2);

        SqlParameter param4 = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
        param4.Value = fabricDetails;
        param4.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param4);

        SqlParameter param3 = new SqlParameter("@OrderID", SqlDbType.Int);
        if (orderID == -1)
            param3.Value = DBNull.Value;
        else
        param3.Value = orderID;
        param3.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param3);

        SqlParameter param5 = new SqlParameter("@StyleID", SqlDbType.Int);
        if (styleid == -1)
            param5.Value = DBNull.Value;
        else
            param5.Value = styleid;
        param5.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param5);


        DataSet dsLabdipHistory = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(dsLabdipHistory);

        return dsLabdipHistory;
      }
    }

    public DataSet GetBulkHistory(int clientID, string fabric, int orderID, int styleid, string fabricDetails)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        string cmdText = "sp_fabric_approval_history_get_fabric_approval_history_bulk";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //cmd.CommandTimeout = 600000;
        SqlParameter param1 = new SqlParameter("@ClientID", SqlDbType.Int);
        param1.Value = clientID;
        param1.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param1);

        SqlParameter param2 = new SqlParameter("@Fabric", SqlDbType.VarChar);
        param2.Value = fabric;
        param2.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param2);

        SqlParameter param4 = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
        param4.Value = fabricDetails;
        param4.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param4);

        SqlParameter param3 = new SqlParameter("@OrderID", SqlDbType.Int);
        if (orderID == -1)
            param3.Value = DBNull.Value;
        else
        param3.Value = orderID;
        param3.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param3);

        SqlParameter param5 = new SqlParameter("@StyleID", SqlDbType.Int);
        if (styleid == -1)
            param5.Value = DBNull.Value;
        else
            param5.Value = styleid;
        param5.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param5);

        DataSet dsBulkHistory = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(dsBulkHistory);

        return dsBulkHistory;
      }
    }




     public string GetCcGsm(string fabricname)
                    {
                        using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                        {
                            try
                            {
                                string ss = null;
                                cnx.Open();
                                string cmdText = "sp_get_cc_and_gsm_for_approval";
                                SqlDataReader reader;
                                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                                SqlParameter param1 = new SqlParameter("fabricname", SqlDbType.VarChar);
                                param1.Value = fabricname;
                                param1.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(param1);

                                reader = cmd.ExecuteReader();

                                while (reader.Read())
                                {
                                    ss = Convert.ToString(reader["Fabric11"]);
                                }
                                return ss;
                            }
                            finally {

                                cnx.Close();
                            }
                        }                                                           
                            
                }
            










              
    #endregion
  }

}

