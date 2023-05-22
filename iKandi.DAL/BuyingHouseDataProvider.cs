using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;


namespace iKandi.DAL
{
    public class BuyingHouseDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public BuyingHouseDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public int CreateBuyingHouse(BuyingHouse BHUser)
        {

            int bhid = 0;
            //int id = 1;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_BuyingHouse_insert_info";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                SqlParameter param1;

                param1 = new SqlParameter("@BHId", SqlDbType.Int);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);


                param = new SqlParameter("@CompanyName", SqlDbType.VarChar);
                param.Value = BHUser.CompanyName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Website", SqlDbType.VarChar);
                param.Value = BHUser.Website;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Address", SqlDbType.VarChar);
                param.Value = BHUser.Address;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Phone", SqlDbType.VarChar);
                param.Value = BHUser.Phone;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@BHCode", SqlDbType.VarChar);
                param.Value = BHUser.BHCode;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientSince", SqlDbType.Date);
                param.Value = BHUser.ClientSince;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Email", SqlDbType.VarChar);
                param.Value = BHUser.Email;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@sActive", SqlDbType.Int);
                param.Value = BHUser.IsActive;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);




                cmd.ExecuteNonQuery();
                bhid = Convert.ToInt32(param1.Value);
                cnx.Close();

            }
            return bhid;
        }

        public bool UpdateBuyingHouse(iKandi.Common.BuyingHouse BHUser)
        {

            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_BuyingHouse_update_info";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                // Add parameters
                param = new SqlParameter("@BHId", SqlDbType.Int);
                param.Value = BHUser.BuyingHouseID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CompanyName", SqlDbType.VarChar);
                param.Value = BHUser.CompanyName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Website", SqlDbType.VarChar);
                param.Value = BHUser.Website;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Address", SqlDbType.VarChar);
                param.Value = BHUser.Address;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Phone", SqlDbType.VarChar);
                param.Value = BHUser.Phone;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@BHCode", SqlDbType.VarChar);
                param.Value = BHUser.BHCode;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientSince", SqlDbType.Date);
                param.Value = BHUser.ClientSince;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Email", SqlDbType.VarChar);
                param.Value = BHUser.Email;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@sActive", SqlDbType.VarChar);
                param.Value = BHUser.IsActive;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);




                cmd.ExecuteNonQuery();

                cnx.Close();

            }

            return true;

        }

        public BuyingHouse GetBHByID(int BHId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_BuyingHouse_get_bh_by_bhid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@BHId", SqlDbType.Int);
                param.Value = BHId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                BuyingHouse bh = new BuyingHouse();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bh.CompanyName = Convert.ToString(reader["CompanyName"]);
                        bh.Address = Convert.ToString(reader["Address"]);
                        bh.Website = Convert.ToString(reader["CompanyWebsite"]);
                        bh.BHCode = (reader["BHCode"] == DBNull.Value) ? "" : reader["BHCode"].ToString();
                        bh.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        bh.Phone = Convert.ToString(reader["Phone"]);
                        bh.Email = Convert.ToString(reader["Email"]);
                        bh.IsActive = Convert.ToInt32(reader["IsActive"]);

                    }
                }
                cnx.Close();
                return bh;
            }
        }

        public BuyingHouse GetBHByClientID(int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_BuyingHouse_get_bh_by_clientid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                BuyingHouse bh = new BuyingHouse();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bh.CompanyName = Convert.ToString(reader["CompanyName"]);
                        bh.BuyingHouseID = Convert.ToInt32(reader["id"]);
                    }
                }
                cnx.Close();
                return bh;
            }
        }

        public List<BuyingHouse> GetAllBuyingName()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_buyingHouse_name";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<BuyingHouse> clients = new List<BuyingHouse>();

                while (reader.Read())
                {
                    BuyingHouse client = new BuyingHouse();
                    client.CompanyName = reader["CompanyName"].ToString();
                    client.BuyingHouseID = Convert.ToInt32(reader["BuyingHouseID"]);
                    clients.Add(client);
                }

                return clients;
            }

        }

        public DataTable GetFPCAcceptanceCriteria()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                DataSet dsorderDetail = new DataSet();
                cmdText = "sp_get_acceptance_criteria";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsorderDetail);
                DataTable dt = dsorderDetail.Tables[0];
                return dt;
            }

        }
        public List<BuyingHouse> GetAllBuyingHouse()
        {
            List<BuyingHouse> bh = new List<BuyingHouse>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_BuyingHouse_get_all_bh";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BuyingHouse bhouse = new BuyingHouse();
                        bhouse.BuyingHouseID = Convert.ToInt32(reader["Id"]);
                        bhouse.CompanyName = Convert.ToString(reader["CompanyName"]);
                        bhouse.Address = Convert.ToString(reader["Address"]);
                        bhouse.Website = Convert.ToString(reader["CompanyWebsite"]);
                        bhouse.BHCode = (reader["BHCode"] == DBNull.Value) ? "" : reader["BHCode"].ToString();
                        bhouse.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        bhouse.Phone = Convert.ToString(reader["Phone"]);
                        bhouse.Email = Convert.ToString(reader["Email"]);
                        bhouse.IsActive = Convert.ToInt32(reader["IsActive"]);
                        bh.Add(bhouse);

                    }
                }
            }
            return bh;

        }

        public List<Client> GetClientsByBHID(int BHId)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_BuyingHouse_get_clients_by_bhid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@BHId", SqlDbType.Int);
                param.Value = BHId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.ClientID = Convert.ToInt32(reader["ClientId"]);
                        client.CompanyName = Convert.ToString(reader["CompanyName"]);
                        client.Address = Convert.ToString(reader["Address"]);
                        client.Website = Convert.ToString(reader["CompanyWebsite"]);
                        client.SalesPersonName = ((reader["SalesName"] == DBNull.Value) ? string.Empty : reader["SalesName"].ToString());
                        client.TechnicalManagerName = ((reader["TechnicalName"] == DBNull.Value) ? string.Empty : reader["TechnicalName"].ToString());                 //client.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                        client.AccountManagerName = ((reader["AccountName"] == DBNull.Value) ? string.Empty : reader["AccountName"].ToString());                //client.ClientFactoryContactID = Convert.ToInt32(reader["ClientFactoryContactID"]);
                        client.DeliveryManagerName = ((reader["DeliveryName"] == DBNull.Value) ? string.Empty : reader["DeliveryName"].ToString());                  //client.ExportManagerID = Convert.ToInt32(reader["ExportManagerID"]);
                        client.ExportManagerName = ((reader["ExportName"] == DBNull.Value) ? string.Empty : reader["ExportName"].ToString());                  //client.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                        client.DesignerName = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : reader["DesignerName"].ToString());               //client.GroupID = Convert.ToInt32(reader["GroupID"]);
                        client.ClientCode = reader["ClientCode"].ToString();
                        client.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        client.BillingAddess = (reader["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillingAddess"]);
                        client.OfficialName = (reader["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OfficialName"]);
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }

        public int GetBuyingHouseStyleData(int ClientID)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_BuyingHouse_get_clients_style_data";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();

                return (result == null) ? 0 : Convert.ToInt32(result);

            }
        }



        /*  public string GetDateInStringFormatDAL(string date)
          {
              List<Client> clients = new List<Client>();
              using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
              {

                  cnx.Open();

                  SqlDataReader reader;
                  SqlCommand cmd;
                  string cmdText;

                  cmdText = "sp_BuyingHouse_get_clients_style_data";
                  cmd = new SqlCommand(cmdText, cnx);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandTimeout =Constants.CONFIGURATION_TimeOut;

                  SqlParameter param = new SqlParameter("@Date", SqlDbType.VarChar);
                  param.Value = date;
                  param.Direction = ParameterDirection.Input;
                  cmd.Parameters.Add(param);

                  object result = cmd.ExecuteScalar();
                  cnx.Close();
                  if(result != null)
                  {
                     return Convert.ToString(result);
                  }
                  else
                      return date;
                

              }
          }*/



        public string GetDateInStringFormatDAL(string date)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_StringToDate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = date;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                DataTable dt = dsorderDetail.Tables[0];

                string ConvertDate = Convert.ToString(dt.Rows[0][0]);
                if (ConvertDate == "01 Jan 01 (Mon)")
                    return "";
                else
                    return ConvertDate;

            }

        }


        public int GetBuyingHouseStatusDAL(int intBuyingHouseID)
        {
            int intStatus = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Create a SQL command object
                    string cmdText = "sp_Check_BuyingHouse_ClientStatus";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    // Set the command type to StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters              
                    SqlParameter param1;
                    param1 = new SqlParameter("@Status", SqlDbType.Int);
                    param1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param1);
                    SqlParameter param;

                    param = new SqlParameter("@buyingHouseID", SqlDbType.VarChar);
                    param.Value = intBuyingHouseID;
                    param.Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(param);
                    // executes the query
                    cmd.ExecuteNonQuery();
                    // retrives the value of the autogenerated id of the category

                    if (param1.Value != DBNull.Value)
                    {
                        intStatus = Convert.ToInt32(param1.Value);
                    }
                    else
                    {
                        intStatus = -1;
                    }
                    cnx.Close();

                    return intStatus;
                }
                catch
                {
                    intStatus = -1;
                    return intStatus;
                }
            }
        }

        // Add By Ravi kumar on 07-oct-2014

        public DataTable GetAllBuyingHouseDAL(int CompanyId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetBuyingHouse_ByCompanyId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CompanyId", SqlDbType.Int);
                param.Value = CompanyId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;

            }

        }

        // Add By Ravi kumar on 07-oct-2014

        public DataTable GetAllSalesYearDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetSalesYear";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;

            }

        }

        // Add By Ravi kumar on 07-oct-2014

        public DataTable GetWeekByMonthDAL(int Year)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetWeekByYear";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;

            }

        }
        // Add By Ravi kumar on 07-oct-2014
        public DataTable GetBipl_Ikandi_MIS_Report_ProductionUnit_DAL(string year, int FromWeek, int ToWeek, int ClientID, int DateType, int UserId, int StatusMode, int StatusModeSequence, int unintID, int BH, string SessionId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_BIPL_IKANDI_MIS_REPORT_ProductionUnit";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Years", SqlDbType.VarChar);
                param.Value = year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeek", SqlDbType.Int);
                param.Value = FromWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeek", SqlDbType.Int);
                param.Value = ToWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = unintID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusMode", SqlDbType.Int);
                param.Value = StatusMode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeSequence", SqlDbType.Int);
                param.Value = StatusModeSequence;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                param.Value = BH;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.NVarChar);
                param.Value = SessionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;

            }

        }

        public DataSet GetBipl_Ikandi_MIS_Report_DAL(string year, int FromWeek, int ToWeek, int ClientID, int DateType, int UserId, int StatusMode, int StatusModeSequence, int unintID, int BH, string SessionId, int AM, int DeptID, int ParentDeptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                if (AM != -1)
                cmdText = "USP_BIPL_IKANDI_MIS_REPORT_Without_ProductionUnit_AM";
                else
                cmdText = "USP_BIPL_IKANDI_MIS_REPORT_Without_ProductionUnit";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Years", SqlDbType.VarChar);
                param.Value = year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeek", SqlDbType.Int);
                param.Value = FromWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeek", SqlDbType.Int);
                param.Value = ToWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = unintID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusMode", SqlDbType.Int);
                param.Value = StatusMode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeSequence", SqlDbType.Int);
                param.Value = StatusModeSequence;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                param.Value = BH;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.NVarChar);
                param.Value = SessionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                if (AM != -1)
                {
                    param = new SqlParameter("@AM", SqlDbType.Int);
                    param.Value = AM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }
                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptID", SqlDbType.Int);
                param.Value = ParentDeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;

            }

        }

        public DataTable GetBiplTotalBreakEvenEffDAL_Budget(int ClientID, int DateType, int StatusMode, int StatusModeSequence, int unintID, int BH, string SessionId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Total_AvgCMT_AvgSam";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = unintID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusMode", SqlDbType.Int);
                param.Value = StatusMode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeSequence", SqlDbType.Int);
                param.Value = StatusModeSequence;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                param.Value = BH;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.NVarChar);
                param.Value = SessionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBiplTotalBreakEvenEffDAL(int ClientID, int DateType, int StatusMode, int StatusModeSequence, int unintID, int BH, DateTime StartDate, DateTime EndDate, string SessionId,int AM,int DeptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                if(AM !=-1)
                    cmdText = "sp_Total_AvgCMT_AvgSam_Without_ProductionUnit_AM";
                else
                    cmdText = "sp_Total_AvgCMT_AvgSam_Without_ProductionUnit";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = unintID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusMode", SqlDbType.Int);
                param.Value = StatusMode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StatusModeSequence", SqlDbType.Int);
                param.Value = StatusModeSequence;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                param.Value = BH;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@From", SqlDbType.DateTime);
                param.Value = StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@to", SqlDbType.DateTime);
                param.Value = EndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.NVarChar);
                param.Value = SessionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                if (AM != -1)
                {
                    param = new SqlParameter("@AM", SqlDbType.Int);
                    param.Value = AM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }
                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBipl_Ikandi_MIS_Breaked_ReportDAL(string sDateRangeDetails, string SessionId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_BIPL_IKANDI_MIS_BREAKED_REPORT";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DateRangeDetails", SqlDbType.VarChar);
                param.Value = sDateRangeDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.NVarChar);
                param.Value = SessionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable FillBudgetDetailsDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetBudgetDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable FillDepartmentDetailsDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetWorkForceTypeDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@in_type", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable FillWorkerTypeDetailsDAL(string sStaffDept)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetWorkForceTypeDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@in_type", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StaffDept", SqlDbType.VarChar);
                param.Value = sStaffDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetAttandanceListDAL(string sFactoryName, DateTime dtStartDate, DateTime dtEndDate, string sDept, string sWorkerType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetAttandanceList";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sFactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Dept", SqlDbType.VarChar);
                param.Value = sDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WorkerType", SqlDbType.VarChar);
                param.Value = sWorkerType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DateTime CheckLatestBudgetDAL(DateTime dtAttandanceDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DateTime dtReturn;
                cnx.Open();
                string cmdText = "Usp_CheckLatestBudget";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@AttandanceDate", SqlDbType.DateTime);
                param.Value = dtAttandanceDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                dtReturn = Convert.ToDateTime(cmd.ExecuteScalar());
                cnx.Close();
                return dtReturn;
            }
        }

        public DataTable GetAttandanceSummaryDAL(string sFactoryName, DateTime dtStartDate, DateTime dtEndDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetAttandanceSummary";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sFactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable CheckTimeFrameDAL(DateTime dtStartDate, DateTime dtEndDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Check_BIPL_IKandi_Budget_TimeFrame";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public decimal GetAbsentismDAL(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo)
        {
            decimal dAbsentism = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_GetWorkingHours";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeekCount", SqlDbType.Int);
                param.Value = iFromWeekNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeekCount", SqlDbType.Int);
                param.Value = iToWeekNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                dAbsentism = Convert.ToDecimal(cmd.ExecuteScalar());

                cnx.Close();
            }
            return dAbsentism;
        }

        public DataTable GetWorkingHoursDAL(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetWorkingHours";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeekCount", SqlDbType.Int);
                param.Value = iFromWeekNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeekCount", SqlDbType.Int);
                param.Value = iToWeekNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBiplAvailMinDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_Budget_AvailMin";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBudgetLineFloorDetailsDAL(string sUnitName, DateTime dtStartDate, DateTime dtEndDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                SqlParameter param;

                cmdText = "Usp_GetBudgetLineFloorDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                param = new SqlParameter("@UnitName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeek", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeek", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBiplWorkerTypeDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_Budget_details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBiplAlreadyCreatedBudgetWorkerTypeDAL(DateTime dtStartDate, DateTime dtEndDate, bool IsAlreadyCreatedBudget)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_Budget_details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@From", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@to", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsAlreadyCreatedBudget", SqlDbType.Bit);
                param.Value = IsAlreadyCreatedBudget;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBiplFactoryDetailsDAL(string sUnitName, DateTime dtStartDate, DateTime dtEndDate, decimal dAbsentism, decimal dWorkingHours, int iFromWeek, int iToWeek, string sFinancialYear, bool IsFinalizeBudget, int iUserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_Budget_details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@From", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@to", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Absentism", SqlDbType.Decimal);
                param.Value = dAbsentism;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WorkingHours", SqlDbType.Decimal);
                param.Value = dWorkingHours;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeekCount", SqlDbType.Int);
                param.Value = iFromWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeekCount", SqlDbType.Int);
                param.Value = iToWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsFinalizeBudget", SqlDbType.Bit);
                param.Value = IsFinalizeBudget;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = iUserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public bool CheckIsEnabledBudgetDAL(int iFromWeek, int iToWeek)
        {
            bool IsEnabled = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_Check_BIPL_IKandi_Latest_Budget_Details";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FromWeekCount", SqlDbType.Int);
                param.Value = iFromWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeekCount", SqlDbType.Int);
                param.Value = iToWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                IsEnabled = Convert.ToBoolean(cmd.ExecuteScalar());

                cnx.Close();
            }
            return IsEnabled;
        }

        public bool CheckIsFinalizeBudgetDAL(DateTime dtFromWeek, DateTime dtToWeek)
        {
            bool IsFinalizeBudget = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_GetWorkingHours";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = dtFromWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = dtToWeek;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                IsFinalizeBudget = Convert.ToBoolean(cmd.ExecuteScalar());

                cnx.Close();
            }
            return IsFinalizeBudget;
        }

        public DataTable GetBiplBudgetMMRDetailsDAL(DateTime dtStartDate, DateTime dtEndDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_Budget_MMR_Details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@From", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@to", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBiplBudgetCPAMDetailsDAL(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo, decimal dWorkingHours, string sFactoryName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_Budget_CPAM_Details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@From", SqlDbType.DateTime);
                param.Value = dtStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@to", SqlDbType.DateTime);
                param.Value = dtEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeekCount", SqlDbType.Int);
                param.Value = iFromWeekNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeekCount", SqlDbType.Int);
                param.Value = iToWeekNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WorkingHours", SqlDbType.Decimal);
                param.Value = dWorkingHours;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@factoryName", SqlDbType.VarChar);
                param.Value = sFactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public int UpdateWorkingHours(int iOrderId, decimal dAbsentism, int iOT1, int iOT2, int iOT3, int iOT4, DateTime dtFromWeek, DateTime dtToWeek, bool IsFinalizeBudget, int iUserId)
        {
            int Id = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_UpdateWorkingHours";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = iOrderId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Absentism", SqlDbType.Decimal);
                param.Value = dAbsentism;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OT1", SqlDbType.Int);
                param.Value = iOT1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OT2", SqlDbType.Int);
                param.Value = iOT2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OT3", SqlDbType.Int);
                param.Value = iOT3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OT4", SqlDbType.Int);
                param.Value = iOT4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeek", SqlDbType.DateTime);
                param.Value = dtFromWeek;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeek", SqlDbType.DateTime);
                param.Value = dtToWeek;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsFinalizeBudget", SqlDbType.Bit);
                param.Value = IsFinalizeBudget;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = iUserId;
                cmd.Parameters.Add(param);

                Id = cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return Id;
        }

        public int UpdateBudgetLines_Floor(string UnitName, string Mode, int Cutting, int Stitching, int Finishing, DateTime dtFromWeek, DateTime dtToWeek)
        {
            int Id = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "[Usp_UpdateBudgetLineFloorDetails]";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UnitName", SqlDbType.VarChar);
                param.Value = UnitName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Mode", SqlDbType.VarChar);
                param.Value = Mode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Cutting", SqlDbType.Int);
                param.Value = Cutting;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stitching", SqlDbType.Int);
                param.Value = Stitching;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Finishing", SqlDbType.Int);
                param.Value = Finishing;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeek", SqlDbType.DateTime);
                param.Value = dtFromWeek;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeek", SqlDbType.DateTime);
                param.Value = dtToWeek;
                cmd.Parameters.Add(param);

                Id = cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return Id;
        }

        public int UpdateBudgetDetails(int iWorkerTypeId, int iFactoryWorkSpce, int iUnitId, int iFromWeekCountNo, int iToWeekCountNo, int iBudCount, decimal dBudCost, decimal dHrDay, int iModifyBy)
        {
            int Id = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_BIPL_IKandi_tblBudget_Update";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@WorkerTypeOrderId", SqlDbType.Int);
                param.Value = iWorkerTypeId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FactoryWorkSpace", SqlDbType.Int);
                param.Value = iFactoryWorkSpce;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionUnit", SqlDbType.Int);
                param.Value = iUnitId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromWeekCount", SqlDbType.Int);
                param.Value = iFromWeekCountNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToWeekCount", SqlDbType.Int);
                param.Value = iToWeekCountNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BudCount", SqlDbType.Int);
                param.Value = iBudCount;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BudCost", SqlDbType.Decimal);
                param.Value = dBudCost;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Hr_Day", SqlDbType.Decimal);
                param.Value = dHrDay;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifyBy", SqlDbType.Int);
                param.Value = iModifyBy;
                cmd.Parameters.Add(param);

                Id = cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return Id;
        }


        public int InsertSalesView(int Year, int Month, int Week, string SessionId)
        {
            int SalesId = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "usp_InsertSalesTempYear";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@inType", SqlDbType.Int);
                paramIn.Value = 1;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Year", SqlDbType.Int);
                paramIn.Value = Year;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Month", SqlDbType.Int);
                paramIn.Value = Month;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Week", SqlDbType.Int);
                paramIn.Value = Week;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@SessionId", SqlDbType.NVarChar);
                paramIn.Value = SessionId;
                cmd.Parameters.Add(paramIn);

                SalesId = cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return SalesId;
        }

        public int InsertSalesView_Styles(DateTime FromDate, DateTime ToDate, int ClientId, int DateType, int FromStatus, int ToStatus, int unitID, int BH, bool IsSTC, bool IsBIH, bool IsBIHSTC, string SessionId)
        {
            int SalesId = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "usp_InsertSalesTempYear";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@inType", SqlDbType.Int);
                paramIn.Value = 2;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@FromDate", SqlDbType.DateTime);
                paramIn.Value = FromDate;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@ToDate", SqlDbType.DateTime);
                paramIn.Value = ToDate;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@ClientID", SqlDbType.Int);
                paramIn.Value = ClientId;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Datatype", SqlDbType.Int);
                paramIn.Value = DateType;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@FromStatus", SqlDbType.Int);
                paramIn.Value = FromStatus;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@ToStatus", SqlDbType.Int);
                paramIn.Value = ToStatus;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@UnitId", SqlDbType.Int);
                paramIn.Value = unitID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                paramIn.Value = BH;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@IsSTC", SqlDbType.Bit);
                paramIn.Value = IsSTC;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@IsBIH", SqlDbType.Bit);
                paramIn.Value = IsBIH;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@IsBIHSTC", SqlDbType.Bit);
                paramIn.Value = IsBIHSTC;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@SessionId", SqlDbType.NVarChar);
                paramIn.Value = SessionId;
                cmd.Parameters.Add(paramIn);

                SalesId = cmd.ExecuteNonQuery();

                cnx.Close();
            }
            return SalesId;
        }


        public double GetExportConverstionRate()
        {
            double ConversionRate = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "usp_GetExportConverstionRate";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                ConversionRate = (double)cmd.ExecuteScalar();

                cnx.Close();

            }
            return ConversionRate;
        }


        //Added By Ashish on 14/4/2015
        public DataTable GetBuyingHouseById(int CompanyId, int DateType, string YearRenge)
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetBuyingHouse_ById";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@CompanyId", SqlDbType.Int);
                    param.Value = CompanyId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateType", SqlDbType.Int);
                    param.Value = DateType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@YearRange", SqlDbType.VarChar);
                    param.Value = YearRenge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);


                }

            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }
        public DataTable GetAMList(int DateType, string YearRenge)
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetAMList";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@DateType", SqlDbType.Int);
                    param.Value = DateType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@YearRange", SqlDbType.VarChar);
                    param.Value = YearRenge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);


                }

            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }

        //Added By Abhishek on 25/4/2015
        public List<BuyingHouse> GetBuyingHouselistById(int CompanyId, int DateType, string YearRenge)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetBuyingHouse_ById";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CompanyId", SqlDbType.Int);
                param.Value = CompanyId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@YearRange", SqlDbType.VarChar);
                param.Value = YearRenge;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<BuyingHouse> clients = new List<BuyingHouse>();

                while (reader.Read())
                {
                    BuyingHouse client = new BuyingHouse();
                    client.BuyingHouseID = Convert.ToInt32(reader["ID"]);
                    client.CompanyName = reader["CompanyName"].ToString();
                    clients.Add(client);
                }

                return clients;

            }
        }
        public List<BuyingHouse> GetBuyingHouselistById_ForAM(int CompanyId, int DateType, string YearRenge,int AM)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetBuyingHouse_ById_ForAM";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CompanyId", SqlDbType.Int);
                param.Value = CompanyId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@YearRange", SqlDbType.VarChar);
                param.Value = YearRenge;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<BuyingHouse> clients = new List<BuyingHouse>();

                while (reader.Read())
                {
                    BuyingHouse client = new BuyingHouse();
                    client.BuyingHouseID = Convert.ToInt32(reader["ID"]);
                    client.CompanyName = reader["CompanyName"].ToString();
                    clients.Add(client);
                }

                return clients;

            }
        }

        //END

        #region MMR Report
        public DataTable GetDaily_MMR_Report_DAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_Report_Daily";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (dtDateFrom != DateTime.MinValue)
                    param.Value = dtDateFrom.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (dtDateTo != DateTime.MinValue)
                    param.Value = dtDateTo.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public string GetWorkingDays_DAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string workingdays = "";
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetWorkingDays";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                object result = cmd.ExecuteScalar();
                cnx.Close();
                if (result != null)
                {
                    workingdays = Convert.ToString(result);
                }
                return workingdays;
            }
        }

        public string GetMMR_WorkingHours_DAL(DateTime dtDateFrom, DateTime dtDateTo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string workingdays = "";
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetMMR_WorkingHours";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (dtDateFrom != DateTime.MinValue)
                    param.Value = dtDateFrom.Date;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (dtDateTo != DateTime.MinValue)
                    param.Value = dtDateTo.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();
                if (result != null)
                {
                    workingdays = Convert.ToString(result);
                }
                return workingdays;
            }
        }

        public DataTable GetMMR_Summary_Daily_DAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_Summary_Daily";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThisDate", SqlDbType.DateTime);
                param.Value = dtDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public string GetCostedProductionCost_DAL(DateTime dtDateFrom, DateTime dtDateTo, string FactoryName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string workingdays = "";
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetCostedProductionCost";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@From", SqlDbType.DateTime);
                if (dtDateFrom != DateTime.MinValue)
                    param.Value = dtDateFrom.Date;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@to", SqlDbType.DateTime);
                if (dtDateTo != DateTime.MinValue)
                    param.Value = dtDateTo.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = FactoryName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();
                if (result != null)
                {
                    workingdays = Convert.ToString(result);
                }
                return workingdays;
            }
        }

        public DataTable GetMMR_CMT_Report_Daily_DAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_CMT_Report_Daily";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThisDate", SqlDbType.DateTime);
                param.Value = dtDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        #endregion



        public DataTable GetBiplUNITNAME_DAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_BIPL_IKandi_UNITNAME";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetMMR_CMT_Report_DateRange_DAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_CMT_Report_DateRange";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (dtDateFrom != DateTime.MinValue)
                    param.Value = dtDateFrom.Date;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (dtDateTo != DateTime.MinValue)
                    param.Value = dtDateTo.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetMMR_BudgetSummary_Daily_DAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_BudgetSummary_Daily";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ThisDate", SqlDbType.DateTime);
                param.Value = dtDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetMMR_BudgetSummary_DateRange_DAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_BudgetSummary_DateRange";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (dtDateFrom != DateTime.MinValue)
                    param.Value = dtDateFrom.Date;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (dtDateTo != DateTime.MinValue)
                    param.Value = dtDateTo.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetMMR_Summary_DateRange_DAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_MMR_Summary_DateRange";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = sUnitName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (dtDateFrom != DateTime.MinValue)
                    param.Value = dtDateFrom.Date;
                else
                    param.Value = DBNull.Value;

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (dtDateTo != DateTime.MinValue)
                    param.Value = dtDateTo.Date;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = sFinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }
        //Added by abhishek on 14/10/2015-------------------------------------------------//
        public DataTable GetBuingHouseName()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "select id,CompanyName from buying_house where IsActive=1";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDivison_Details(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetManage_Divison";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }


        public String InsertUpdateManage_Divison(string groupName, string DivisonName, bool IsAct, string BuyingHouseID, string domainName, int ID = 0)
        {
            string Result = string.Empty;
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_InsertUpdate_Mange_Divison";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@groupName", SqlDbType.VarChar);
                    param.Value = groupName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DivisonName", SqlDbType.VarChar);
                    param.Value = DivisonName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAct", SqlDbType.Bit);
                    param.Value = IsAct;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouseID", SqlDbType.VarChar);
                    param.Value = BuyingHouseID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@domainName", SqlDbType.VarChar);
                    param.Value = domainName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RetVal", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Output;
                    param.Size = 50;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("ID", SqlDbType.Int);
                    param.Value = ID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    Result = cmd.Parameters["@RetVal"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return Result;
        }
        //end by abhishek on 14/10/2015----------------------------------------------------//

        public DataTable GetBreakedStyleDetails(string CompleteDateRange, string SessionId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_BIPL_IKANDI_MIS_REPORT_Style";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DateRangeDetails", SqlDbType.VarChar);
                param.Value = CompleteDateRange;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SessionId", SqlDbType.VarChar);
                param.Value = SessionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
