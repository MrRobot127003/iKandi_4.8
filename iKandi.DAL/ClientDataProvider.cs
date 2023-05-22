using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;



namespace iKandi.DAL
{
    public class ClientDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public ClientDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        #region Gajendra Client Form Updates
        public int CreateClient(Client ClientUser)
        {

            int clientid = 0;
            //int id = 1;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_clients_insert_info";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                SqlParameter param1;

                param1 = new SqlParameter("@ClientId", SqlDbType.Int);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);


                param = new SqlParameter("@CompanyName", SqlDbType.VarChar);
                param.Value = ClientUser.CompanyName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Website", SqlDbType.VarChar);
                param.Value = ClientUser.Website;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@Address", SqlDbType.VarChar);
                param.Value = ClientUser.Address;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Phone", SqlDbType.VarChar);
                param.Value = ClientUser.Phone;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientCode", SqlDbType.VarChar);
                param.Value = ClientUser.ClientCode;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@GroupID", SqlDbType.Int);
                param.Value = ClientUser.GroupID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientSince", SqlDbType.Date);
                param.Value = ClientUser.ClientSince;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@Aql", SqlDbType.Float);
                param.Value = ClientUser.Aql;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@sMDARequired", SqlDbType.Int);
                param.Value = ClientUser.IsMDARequired;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Discount", SqlDbType.Decimal);
                param.Value = ClientUser.Discount;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentTerms", SqlDbType.Int);
                param.Value = ClientUser.PaymentTerms;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Email", SqlDbType.VarChar);
                param.Value = ClientUser.Email;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@BillingAddess", SqlDbType.VarChar);
                param.Value = ClientUser.BillingAddess;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@OfficialName", SqlDbType.VarChar);
                param.Value = ClientUser.OfficialName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@BHID", SqlDbType.Int);
                param.Value = ClientUser.BuyingHouseId;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@FPCAcceptanceCriteria", SqlDbType.Int);
                param.Value = ClientUser.FPCAcceptanceCriteria;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                // Gajendra Client Form 30-11-2015
                param = new SqlParameter("@DivisionID", SqlDbType.Int);
                param.Value = ClientUser.DivisionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                // Gajendra Client Form 28-01-2016
                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@ClinetColorCode", SqlDbType.VarChar);
                param.Value = ClientUser.ClientColorCode;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsPPSampleRequired", SqlDbType.Int);
                param.Value = ClientUser.IsPPSampleRequired;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@CountryCode", SqlDbType.VarChar);
                param.Value = ClientUser.CountryCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                clientid = Convert.ToInt32(param1.Value);
                cnx.Close();

            }
            return clientid;
        }

        public Client GetClientByID(int ClientId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_by_clientid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                Client client = new Client();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        client.CompanyName = Convert.ToString(reader["CompanyName"]);
                        client.Address = Convert.ToString(reader["Address"]);
                        client.Website = Convert.ToString(reader["CompanyWebsite"]);
                        client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                        client.GroupID = Convert.ToInt32(reader["GroupID"]);
                        client.ClientCode = reader["ClientCode"].ToString();
                        client.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        client.Aql = Convert.ToDouble(reader["AqlStandards"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        client.PaymentTerms = Convert.ToInt32(reader["PaymentTerms"]);
                        client.Discount = Convert.ToDecimal(reader["Discount"]);
                        client.Email = Convert.ToString(reader["Email"]);
                        client.IsMDARequired = Convert.ToInt32(reader["IsMDARequired"]);
                        client.BillingAddess = (reader["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillingAddess"]);
                        client.OfficialName = (reader["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OfficialName"]);
                        client.BuyingHouseName = reader["BHName"].ToString();
                        client.FPCAcceptanceCriteria = (reader["FPCAcceptanceCriteria"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["FPCAcceptanceCriteria"]);
                        client.DivisionID = Convert.ToString(reader["DivisionID"]); // Gajendra Client Form 30-11-2015
                        client.ClientColorCode = Convert.ToString(reader["ClientColorCode"]);
                        client.IsPPSampleRequired = Convert.ToInt32(reader["IsPPSampleRequired"]);
                    }
                }
                cnx.Close();
                return client;
            }
        }
        //Gajendra Client Form 27-11-2015
        public DataTable GetDesignationByDivision(string DivisionID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataTable dt = null;
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetDesignationByDivision";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DivisionID", SqlDbType.Int);
                param.Value = DivisionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                if (ds != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }
                return dt;
            }
        }
        //Gajendra Client Form 30-11-2015
        public DataTable GetUserListByDeptid(string DptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataTable dt = null;
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetUserListByDeptid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                if (ds != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }
                return dt;
            }
        }
        //Gajendra Client Form 02-12-2015
        public DataTable GETDepartmentByClientID(string ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataTable dt = null;
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GETDepartmentByClientID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = @ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                if (ds != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }

                return dt;
            }
        }
        //Gajendra Client Form 02-12-2015
        public DataTable GetUserListNameByDeptID(string DeptId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataTable dt = null;
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetUserListNameByDeptID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                if (ds != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }

                return dt;
            }
        }
        #endregion

        public bool CreateUserClient(User InternalUser)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_users_create_client";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.VarChar);
                param.Value = InternalUser.MembershipUserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //Below code Added for Acessess restriction
                param = new SqlParameter("@GlobalAcc", SqlDbType.Int);
                param.Value = InternalUser.iGlobalAcc;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                int result = cmd.ExecuteNonQuery();

                cnx.Close();

            }

            return true;

        }

        public bool CreateClientDept(ClientDepartment clientdept)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();


                string cmdText = "sp_clients_insert_dept";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@d", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientdept.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = clientdept.Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = clientdept.UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Mon", SqlDbType.Int);
                param.Value = clientdept.Mon;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Tue", SqlDbType.Int);
                param.Value = clientdept.Tue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Wed", SqlDbType.Int);
                param.Value = clientdept.Wed;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Thu", SqlDbType.Int);
                param.Value = clientdept.Thu;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fri", SqlDbType.Int);
                param.Value = clientdept.Fri;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentId", SqlDbType.Int);
                param.Value = clientdept.ParentId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int ID = Convert.ToInt32(outParam.Value);
                foreach (ClientDepartmentAssociation cda in clientdept.ClientDepartmentAssociation)
                {
                    cda.DeptID = ID;
                    if (cda.Id == -1)
                        CreateClientDeptAssociation(cda);
                }
                foreach (ClientDepartmentAssociation cda in clientdept.ClientDepartmentAssociation)
                {
                    cda.DeptID = clientdept.ParentId;
                    CreateClientDeptAssociation(cda);
                    //UpdateClientDeptAssociation(cda);
                }

                cnx.Close();

            }
            return true;
        }

        public bool CreateClientDeptAssociation(ClientDepartmentAssociation cda)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_clients_insert_client_department_association";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = cda.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = cda.UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationId", SqlDbType.Int);
                param.Value = cda.DesignationId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }
            return true;
        }

        public bool CreateClientContact(ClientContact ccontact)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();



                //foreach (ClientContact ccontact in ClientUser.Contacts)
                //{

                string cmdText = "sp_clients_insert_contacts";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ccontact.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = ccontact.Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Phone", SqlDbType.VarChar);
                param.Value = ccontact.Phone;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Email", SqlDbType.VarChar);
                param.Value = ccontact.Email;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();

                //}
                cnx.Close();
            }

            return true;
        }


        public Client GetClientAssociatedUserDetailByID(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_associated_user_detail_by_clientid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                Client client = new Client();

                if (reader.Read())
                {
                    client.SamplingMerchantName = (reader["SamplingMerchantName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SamplingMerchantName"]);
                    client.DesignerName = (reader["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerName"]);
                }

                cnx.Close();
                return client;

            }
        }

        public List<ClientDepartment> GetClientDeptByClientID(int ClientId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_dept_by_clientid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                Client client = new Client();
                client.Departments = new List<ClientDepartment>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClientDepartment cdept = new ClientDepartment();
                        cdept.Name = Convert.ToString(reader["DepartmentName"]);
                        cdept.UserId = Convert.ToInt32(reader["UserId"]);
                        cdept.Username = Convert.ToString(reader["Email"]);
                        //cdept.Password = Convert.ToString(reader["Password"]);
                        cdept.DeptID = Convert.ToInt32(reader["Id"]);
                        cdept.Mon = Convert.ToInt32(reader["Mon"]);
                        cdept.Tue = Convert.ToInt32(reader["Tue"]);
                        cdept.Wed = Convert.ToInt32(reader["Wed"]);
                        cdept.Thu = Convert.ToInt32(reader["Thu"]);
                        cdept.Fri = Convert.ToInt32(reader["Fri"]);

                        cdept.ClientDepartmentAssociation = GetClientDeptAssociationByDeptID(cdept);
                        client.Departments.Add(cdept);

                    }
                }
                cnx.Close();
                return client.Departments;

            }
        }

        public DataTable GetClientDeptByClientIDDataTable(int ClientId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                DataTable dt = null;
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_dept_by_clientid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                if (ds != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }

                return dt;
            }
        }

        public List<ClientDepartmentAssociation> GetClientDeptAssociationByDeptID(ClientDepartment cDept)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_dept_association_by_deptid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = cDept.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();

                cDept.SalesManagerIDs = string.Empty;
                cDept.DeliveryManagerIDs = string.Empty;
                cDept.SamplingMerchantIDs = string.Empty;
                cDept.ShippingManagerIDs = string.Empty;
                cDept.TechnologistIDs = string.Empty;
                cDept.FITMerchantIDs = string.Empty;
                cDept.AccountManagerIDs = string.Empty;
                cDept.DesignerIDs = string.Empty;
                cDept.ClientHeadIDs = string.Empty;

                List<ClientDepartmentAssociation> cdaList = new List<ClientDepartmentAssociation>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = Convert.ToInt32(reader["Id"]);
                        cda.UserId = (reader["UserId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["UserId"]);
                        cda.DesignationId = (reader["DesignationId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DesignationId"]);
                        cda.DeptID = Convert.ToInt32(reader["ClientDepartmentId"]);
                        cdaList.Add(cda);

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.iKandi_Sales_SalesManager))
                        {
                            cDept.SalesManagerIDs = cDept.SalesManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.iKandi_Design_Designers))
                        {
                            cDept.DesignerIDs = cDept.DesignerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Logistics_DeliveryManager))
                        {
                            cDept.DeliveryManagerIDs = cDept.DeliveryManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant))
                        {
                            cDept.SamplingMerchantIDs = cDept.SamplingMerchantIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Logistics_ShippingManager))
                        {
                            cDept.ShippingManagerIDs = cDept.ShippingManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.iKandi_Technical_Technologist))
                        {
                            cDept.TechnologistIDs = cDept.TechnologistIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant))
                        {
                            cDept.FITMerchantIDs = cDept.FITMerchantIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager))
                        {
                            cDept.AccountManagerIDs = cDept.AccountManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Client_Head))
                        {
                            cDept.ClientHeadIDs = cDept.ClientHeadIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                    }
                }

                if (!String.IsNullOrEmpty(cDept.SalesManagerIDs))
                    cDept.SalesManagerIDs = cDept.SalesManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.DesignerIDs))
                    cDept.DesignerIDs = cDept.DesignerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.DeliveryManagerIDs))
                    cDept.DeliveryManagerIDs = cDept.DeliveryManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.SamplingMerchantIDs))
                    cDept.SamplingMerchantIDs = cDept.SamplingMerchantIDs + ",";

                if (!String.IsNullOrEmpty(cDept.ShippingManagerIDs))
                    cDept.ShippingManagerIDs = cDept.ShippingManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.TechnologistIDs))
                    cDept.TechnologistIDs = cDept.TechnologistIDs + ",";

                if (!String.IsNullOrEmpty(cDept.FITMerchantIDs))
                    cDept.FITMerchantIDs = cDept.FITMerchantIDs + ",";

                if (!String.IsNullOrEmpty(cDept.AccountManagerIDs))
                    cDept.AccountManagerIDs = cDept.AccountManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.ClientHeadIDs))
                    cDept.ClientHeadIDs = cDept.ClientHeadIDs + ",";

                cnx.Close();
                return cdaList;
            }
        }
        public ClientDepartment GetClientDeptAssociationByDeptID(int deptID)
        {

            //manisha 21 june 2011
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_dept_association_by_deptid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = deptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();

                cDept.SalesManagerIDs = string.Empty;
                cDept.DeliveryManagerIDs = string.Empty;
                cDept.SamplingMerchantIDs = string.Empty;
                cDept.ShippingManagerIDs = string.Empty;
                cDept.TechnologistIDs = string.Empty;
                cDept.FITMerchantIDs = string.Empty;
                cDept.AccountManagerIDs = string.Empty;
                cDept.DesignerIDs = string.Empty;
                cDept.ClientHeadIDs = string.Empty;

                List<ClientDepartmentAssociation> cdaList = new List<ClientDepartmentAssociation>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = Convert.ToInt32(reader["Id"]);
                        cda.UserId = (reader["UserId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["UserId"]);
                        cda.DesignationId = (reader["DesignationId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DesignationId"]);
                        cda.DeptID = Convert.ToInt32(reader["ClientDepartmentId"]);
                        cdaList.Add(cda);

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.iKandi_Sales_SalesManager))
                        {
                            cDept.SalesManagerIDs = cDept.SalesManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.iKandi_Design_Designers))
                        {
                            cDept.DesignerIDs = cDept.DesignerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Logistics_DeliveryManager))
                        {
                            cDept.DeliveryManagerIDs = cDept.DeliveryManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant))
                        {
                            cDept.SamplingMerchantIDs = cDept.SamplingMerchantIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Logistics_ShippingManager))
                        {
                            cDept.ShippingManagerIDs = cDept.ShippingManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.iKandi_Technical_Technologist))
                        {
                            cDept.TechnologistIDs = cDept.TechnologistIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant))
                        {
                            cDept.FITMerchantIDs = cDept.FITMerchantIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager))
                        {
                            cDept.AccountManagerIDs = cDept.AccountManagerIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                        if (Convert.ToInt32(reader["DesignationId"]) == Convert.ToInt32(Designation.BIPL_Client_Head))
                        {
                            cDept.ClientHeadIDs = cDept.ClientHeadIDs + "," + Convert.ToInt32(reader["UserId"]);
                        }

                    }
                }

                if (!String.IsNullOrEmpty(cDept.SalesManagerIDs))
                    cDept.SalesManagerIDs = cDept.SalesManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.DesignerIDs))
                    cDept.DesignerIDs = cDept.DesignerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.DeliveryManagerIDs))
                    cDept.DeliveryManagerIDs = cDept.DeliveryManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.SamplingMerchantIDs))
                    cDept.SamplingMerchantIDs = cDept.SamplingMerchantIDs + ",";

                if (!String.IsNullOrEmpty(cDept.ShippingManagerIDs))
                    cDept.ShippingManagerIDs = cDept.ShippingManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.TechnologistIDs))
                    cDept.TechnologistIDs = cDept.TechnologistIDs + ",";

                if (!String.IsNullOrEmpty(cDept.FITMerchantIDs))
                    cDept.FITMerchantIDs = cDept.FITMerchantIDs + ",";

                if (!String.IsNullOrEmpty(cDept.AccountManagerIDs))
                    cDept.AccountManagerIDs = cDept.AccountManagerIDs + ",";

                if (!String.IsNullOrEmpty(cDept.ClientHeadIDs))
                    cDept.ClientHeadIDs = cDept.ClientHeadIDs + ",";

                cnx.Close();
                return cDept;
            }
        }

        public DataSet GetClientDeptAssociationByClientIDDeptID(int deptID)
        {
            //manisha 21 june 2011
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_details_by_clientid_deptid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = deptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }

        public DataTable GetClientDeptAssociationByDeptIDDataTable(int cDept)
        {
            //manisha 21 june 2011
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_dept_association_by_deptid_dt";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = cDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }
                return dt;
            }
        }

        public List<ClientContact> GetClientContactByClientID(int ClientId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_contact_by_clientid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();

                Client client = new Client();
                client.Contacts = new List<ClientContact>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClientContact cc = new ClientContact();
                        cc.Name = Convert.ToString(reader["Name"]);
                        cc.Phone = Convert.ToString(reader["Phone"]);
                        cc.Email = Convert.ToString(reader["Email"]);
                        cc.ContactID = Convert.ToInt32(reader["Id"]);
                        client.Contacts.Add(cc);
                    }
                }
                cnx.Close();
                return client.Contacts;

            }




        }

        public bool UpdateClient(iKandi.Common.Client ClientUser)
        {

            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_clients_update_info";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                // Add parameters
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientUser.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CompanyName", SqlDbType.VarChar);
                param.Value = ClientUser.CompanyName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Website", SqlDbType.VarChar);
                param.Value = ClientUser.Website;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                //param = new SqlParameter("@SalesPersonID", SqlDbType.Int);
                //param.Value = ClientUser.SalesPersonID;
                //param.Direction = ParameterDirection.Input;

                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@DesignerID", SqlDbType.Int);
                //param.Value = ClientUser.DesignerID;
                //param.Direction = ParameterDirection.Input;

                //cmd.Parameters.Add(param);


                //param = new SqlParameter("@AccountManagerID", SqlDbType.Int);
                //param.Value = ClientUser.AccountManagerID;
                //param.Direction = ParameterDirection.Input;

                //cmd.Parameters.Add(param);


                //param = new SqlParameter("@TechnicalManagerID", SqlDbType.Int);
                //param.Value = ClientUser.TechnicalManagerID;
                //param.Direction = ParameterDirection.Input;

                //cmd.Parameters.Add(param);


                //param = new SqlParameter("@DeliveryManagerID", SqlDbType.Int);
                //param.Value = ClientUser.DeliveryManagerID;

                //cmd.Parameters.Add(param);

                param = new SqlParameter("@Address", SqlDbType.VarChar);
                param.Value = ClientUser.Address;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Phone", SqlDbType.VarChar);
                param.Value = ClientUser.Phone;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientCode", SqlDbType.VarChar);
                param.Value = ClientUser.ClientCode;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@GroupID", SqlDbType.Int);
                param.Value = ClientUser.GroupID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientSince", SqlDbType.Date);
                param.Value = ClientUser.ClientSince;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@Aql", SqlDbType.Float);
                param.Value = ClientUser.Aql;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@sMDARequired", SqlDbType.Int);
                param.Value = ClientUser.IsMDARequired;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Discount", SqlDbType.Decimal);
                param.Value = ClientUser.Discount;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentTerms", SqlDbType.Int);
                param.Value = ClientUser.PaymentTerms;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Email", SqlDbType.VarChar);
                param.Value = ClientUser.Email;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@BillingAddess", SqlDbType.VarChar);
                param.Value = ClientUser.BillingAddess;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@OfficialName", SqlDbType.VarChar);
                param.Value = ClientUser.OfficialName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                //param = new SqlParameter("@FitMerchantID", SqlDbType.Int);
                //param.Value = ClientUser.FitMerchantID;
                //param.Direction = ParameterDirection.Input;

                //cmd.Parameters.Add(param);

                param = new SqlParameter("@BHID", SqlDbType.Int);
                param.Value = ClientUser.BuyingHouseId;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@FPCAcceptanceCriteria", SqlDbType.Int);
                param.Value = ClientUser.FPCAcceptanceCriteria;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClinetColorCode", SqlDbType.VarChar);
                param.Value = ClientUser.ClientColorCode;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsPPSampleRequired", SqlDbType.Int);
                param.Value = ClientUser.IsPPSampleRequired;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }

            return true;

        }

        public bool UpdateClientDeptAssociation(ClientDepartmentAssociation cda)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_clients_update_client_department_association";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = cda.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = cda.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = cda.UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignationId", SqlDbType.Int);
                param.Value = cda.DesignationId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }
            return true;
        }

        public bool UpdateClientDept(ClientDepartment clientdept)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                // foreach (ClientDepartment clientdept in ClientUser.Departments)
                // {

                string cmdText = "sp_clients_update_dept";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = clientdept.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = clientdept.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = clientdept.Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@UserID", SqlDbType.Int);
                //param.Value = clientdept.UserId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@Mon", SqlDbType.Int);
                param.Value = clientdept.Mon;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Tue", SqlDbType.Int);
                param.Value = clientdept.Tue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Wed", SqlDbType.Int);
                param.Value = clientdept.Wed;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Thu", SqlDbType.Int);
                param.Value = clientdept.Thu;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fri", SqlDbType.Int);
                param.Value = clientdept.Fri;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentId", SqlDbType.Int);
                param.Value = clientdept.ParentId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                foreach (ClientDepartmentAssociation cda in clientdept.ClientDepartmentAssociation)
                {
                    cda.DeptID = clientdept.DeptID;
                    CreateClientDeptAssociation(cda);
                    //UpdateClientDeptAssociation(cda);
                }
                foreach (ClientDepartmentAssociation cda in clientdept.ClientDepartmentAssociation)
                {
                    cda.DeptID = clientdept.ParentId;
                    CreateClientDeptAssociation(cda);
                    //UpdateClientDeptAssociation(cda);
                }

                //}

                cnx.Close();

            }
            return true;
        }

        public bool UpdateClientContact(ClientContact ccontact)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                //foreach (ClientContact ccontact in ClientUser.Contacts)
                //{

                string cmdText = "sp_clients_update_contact";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ccontact.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ContactID", SqlDbType.VarChar);
                param.Value = ccontact.ContactID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = ccontact.Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Phone", SqlDbType.VarChar);
                param.Value = ccontact.Phone;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Email", SqlDbType.VarChar);
                param.Value = ccontact.Email;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                //}
            }
            return true;
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
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
                        client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                        client.BuyingHouseName = Convert.ToString(reader["BuyingHouse"]);
                        //client.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        client.SalesPersonName = ((reader["SalesName"] == DBNull.Value) ? string.Empty : reader["SalesName"].ToString());
                        //client.TechnicalManagerID = Convert.ToInt32(reader["TechnicalManagerID"]);
                        client.TechnicalManagerName = ((reader["TechnicalName"] == DBNull.Value) ? string.Empty : reader["TechnicalName"].ToString());                 //client.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                        client.AccountManagerName = ((reader["AccountName"] == DBNull.Value) ? string.Empty : reader["AccountName"].ToString());                //client.ClientFactoryContactID = Convert.ToInt32(reader["ClientFactoryContactID"]);
                        client.DeliveryManagerName = ((reader["DeliveryName"] == DBNull.Value) ? string.Empty : reader["DeliveryName"].ToString());                  //client.ExportManagerID = Convert.ToInt32(reader["ExportManagerID"]);
                        client.ExportManagerName = ((reader["ExportName"] == DBNull.Value) ? string.Empty : reader["ExportName"].ToString());                  //client.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                        client.DesignerName = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : reader["DesignerName"].ToString());               //client.GroupID = Convert.ToInt32(reader["GroupID"]);
                        client.ClientCode = reader["ClientCode"].ToString();
                        client.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        //client.Aql = Convert.ToDecimal(reader["AqlStandards"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        //client.PaymentTerms = Convert.ToInt32(reader["PaymentTerms"]);
                        //client.Discount = Convert.ToDecimal(reader["Discount"]);
                        //client.Email = Convert.ToString(reader["Email"]);
                        client.BillingAddess = (reader["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillingAddess"]);
                        client.OfficialName = (reader["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OfficialName"]);
                        client.IsActive = (reader["IsActive"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsActive"]);



                        clients.Add(client);

                    }
                }
            }
            return clients;

        }



        public List<Client> GetAll_Clients_WithCode()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetAll_Clients_WithCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.ClientID = Convert.ToInt32(reader["ClientId"]);
                        client.CompanyName = Convert.ToString(reader["ClientName"]);                       
                        client.ClientCode = reader["ClientCode"].ToString();                     

                        clients.Add(client);

                    }
                }
            }
            return clients;

        }


        //Add By Prabhaker 22-Mar-2018
        public List<Department> BindAllPrintDept(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_PrintList_DepartmentList";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();
                List<Department> Deptobj = new List<Department>();

                while (reader.Read())
                {
                    Department objdepts = new Department();
                    objdepts.Name = reader["DEPARTMENTNAME"].ToString();
                    objdepts.DepartmentID = Convert.ToInt32(reader["ID"]);
                    Deptobj.Add(objdepts);
                }

                return Deptobj;
            }

        }


        //End Of Code

        public List<Client> BindDesignListAllClient(string flag = " ", int UserID = 0)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients_for_DesignList";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@UserID", SqlDbType.VarChar);
                param.Value = UserID;
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
                        //client.Address = Convert.ToString(reader["Address"]);
                        //client.Website = Convert.ToString(reader["CompanyWebsite"]);
                        //client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                        //client.BuyingHouseName = Convert.ToString(reader["BuyingHouse"]);
                        ////client.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        //client.SalesPersonName = ((reader["SalesName"] == DBNull.Value) ? string.Empty : reader["SalesName"].ToString());
                        ////client.TechnicalManagerID = Convert.ToInt32(reader["TechnicalManagerID"]);
                        //client.TechnicalManagerName = ((reader["TechnicalName"] == DBNull.Value) ? string.Empty : reader["TechnicalName"].ToString());                 //client.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                        //client.AccountManagerName = ((reader["AccountName"] == DBNull.Value) ? string.Empty : reader["AccountName"].ToString());                //client.ClientFactoryContactID = Convert.ToInt32(reader["ClientFactoryContactID"]);
                        //client.DeliveryManagerName = ((reader["DeliveryName"] == DBNull.Value) ? string.Empty : reader["DeliveryName"].ToString());                  //client.ExportManagerID = Convert.ToInt32(reader["ExportManagerID"]);
                        //client.ExportManagerName = ((reader["ExportName"] == DBNull.Value) ? string.Empty : reader["ExportName"].ToString());                  //client.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                        //client.DesignerName = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : reader["DesignerName"].ToString());               //client.GroupID = Convert.ToInt32(reader["GroupID"]);
                        //client.ClientCode = reader["ClientCode"].ToString();
                        //client.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        ////client.Aql = Convert.ToDecimal(reader["AqlStandards"]);
                        //client.Phone = Convert.ToString(reader["Phone"]);
                        ////client.PaymentTerms = Convert.ToInt32(reader["PaymentTerms"]);
                        ////client.Discount = Convert.ToDecimal(reader["Discount"]);
                        ////client.Email = Convert.ToString(reader["Email"]);
                        //client.BillingAddess = (reader["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillingAddess"]);
                        //client.OfficialName = (reader["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OfficialName"]);


                        clients.Add(client);

                    }
                }
            }
            return clients;

        }





        public int GetClientsInfo_BuyingHouse(int ClientID)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_BuyingHouse_get_clients_info_clientID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;


                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();

                return (result == null) ? 0 : Convert.ToInt32(result);
            }
        }
        //Edit by surendra on 10 jan 2013
        public int GetDuplicateStyleNo(string styleNo)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_duplicate_styleNo";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@styleid", SqlDbType.VarChar);
                param.Value = styleNo;
                param.Direction = ParameterDirection.Input;


                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();

                return (result == null) ? 0 : Convert.ToInt32(result);
            }
        }
        public int checkStylecode(string styleNo)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_duplicate_stylecode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@styleid", SqlDbType.VarChar);
                param.Value = styleNo;
                param.Direction = ParameterDirection.Input;


                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();

                return (result == null) ? 0 : Convert.ToInt32(result);
            }
        }
        //end
        //GetClientsInfo_BuyingHouse

        public List<Client> GetAllClients(int BuyingHouseId)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients_ByBuyingHouse";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                param.Value = BuyingHouseId;
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
                        client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                        client.BuyingHouseName = Convert.ToString(reader["BuyingHouse"]);
                        //client.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        client.SalesPersonName = ((reader["SalesName"] == DBNull.Value) ? string.Empty : reader["SalesName"].ToString());
                        //client.TechnicalManagerID = Convert.ToInt32(reader["TechnicalManagerID"]);
                        client.TechnicalManagerName = ((reader["TechnicalName"] == DBNull.Value) ? string.Empty : reader["TechnicalName"].ToString());                 //client.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                        client.AccountManagerName = ((reader["AccountName"] == DBNull.Value) ? string.Empty : reader["AccountName"].ToString());                //client.ClientFactoryContactID = Convert.ToInt32(reader["ClientFactoryContactID"]);
                        client.DeliveryManagerName = ((reader["DeliveryName"] == DBNull.Value) ? string.Empty : reader["DeliveryName"].ToString());                  //client.ExportManagerID = Convert.ToInt32(reader["ExportManagerID"]);
                        client.ExportManagerName = ((reader["ExportName"] == DBNull.Value) ? string.Empty : reader["ExportName"].ToString());                  //client.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                        client.DesignerName = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : reader["DesignerName"].ToString());               //client.GroupID = Convert.ToInt32(reader["GroupID"]);
                        client.ClientCode = reader["ClientCode"].ToString();
                        client.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        //client.Aql = Convert.ToDecimal(reader["AqlStandards"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        //client.PaymentTerms = Convert.ToInt32(reader["PaymentTerms"]);
                        //client.Discount = Convert.ToDecimal(reader["Discount"]);
                        //client.Email = Convert.ToString(reader["Email"]);
                        client.BillingAddess = (reader["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillingAddess"]);
                        client.OfficialName = (reader["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OfficialName"]);


                        clients.Add(client);

                    }
                }
            }
            return clients;

        }

        public List<Client> GetAllClients(int PageSize, int PageIndex, out int TotalRowCount, int BuyingID, int intClientID)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients_with_paging";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = PageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageIndex", SqlDbType.Int);
                param.Value = PageIndex;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseID", SqlDbType.Int);
                param.Value = BuyingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = intClientID;
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
                        client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                        client.BuyingHouseName = Convert.ToString(reader["BuyingHouse"]);
                        client.IsIkandiClient = Convert.ToInt32(reader["IsIkandiClient"]);
                        //client.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                        client.SalesPersonName = ((reader["SalesName"] == DBNull.Value) ? string.Empty : reader["SalesName"].ToString());
                        //client.TechnicalManagerID = Convert.ToInt32(reader["TechnicalManagerID"]);

                        client.AccountManagerName = ((reader["AccountName"] == DBNull.Value) ? string.Empty : reader["AccountName"].ToString());                //client.ClientFactoryContactID = Convert.ToInt32(reader["ClientFactoryContactID"]);
                        client.DeliveryManagerName = ((reader["DeliveryName"] == DBNull.Value) ? string.Empty : reader["DeliveryName"].ToString());                  //client.ExportManagerID = Convert.ToInt32(reader["ExportManagerID"]);
                        client.ExportManagerName = ((reader["ExportName"] == DBNull.Value) ? string.Empty : reader["ExportName"].ToString());                  //client.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                        if (client.IsIkandiClient == 1)
                        {
                            client.TechnicalManagerName = ((reader["TechnicalName"] == DBNull.Value) ? string.Empty : reader["TechnicalName"].ToString());                 //client.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                            client.DesignerName = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : reader["DesignerName"].ToString());
                        }
                        else
                        {
                            client.TechnicalManagerName = "";
                            client.DesignerName = "";
                        }
                        client.FitMerchantName = ((reader["FitMerchantName"] == DBNull.Value) ? string.Empty : reader["FitMerchantName"].ToString());
                        client.SamplingMerchantName = ((reader["SamplingMerchantName"] == DBNull.Value) ? string.Empty : reader["SamplingMerchantName"].ToString());
                        //client.GroupID = Convert.ToInt32(reader["GroupID"]);
                        client.ClientCode = reader["ClientCode"].ToString();
                        client.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                        //client.Aql = Convert.ToDecimal(reader["AqlStandards"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        //client.PaymentTerms = Convert.ToInt32(reader["PaymentTerms"]);
                        //client.Discount = Convert.ToDecimal(reader["Discount"]);
                        //client.Email = Convert.ToString(reader["Email"]);
                        client.BillingAddess = (reader["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillingAddess"]);
                        client.OfficialName = (reader["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OfficialName"]);

                        clients.Add(client);

                    }
                }
                reader.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
            }
            return clients;

        }

        public List<Client> GetAllClientsNameIkandi()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients_name_ikandi";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Client> clients = new List<Client>();

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(reader["ClientId"]);
                    client.CompanyName = reader["CompanyName"].ToString();
                    client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                    clients.Add(client);
                }

                return clients;
            }

        }






        public List<Client> GetAllClientsNameForFabric()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients_name_ForFabric";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseID", SqlDbType.VarChar);
                param.Value = "0";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Client> clients = new List<Client>();

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(reader["ClientId"]);
                    client.CompanyName = reader["CompanyName"].ToString();
                    client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                    clients.Add(client);
                }

                return clients;
            }

        }




        public List<Client> GetAllClientsName()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients_name";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseID", SqlDbType.VarChar);
                param.Value = "0";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Client> clients = new List<Client>();

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(reader["ClientId"]);
                    client.CompanyName = reader["CompanyName"].ToString();
                    client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                    clients.Add(client);
                }

                return clients;
            }

        }

        public List<Client> GetAllClientsName(int BuyingHouseID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_all_clients_name";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseID", SqlDbType.Int);
                param.Value = BuyingHouseID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Client> clients = new List<Client>();
                Client client1 = new Client();
                client1.ClientID = -1;
                client1.CompanyName = "Select";
                client1.BuyingHouseId = -1;
                clients.Add(client1);

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(reader["ClientId"]);
                    client.CompanyName = reader["CompanyName"].ToString();
                    client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                    clients.Add(client);
                }

                return clients;
            }

        }

        public DataTable GetAllClientsName(int BuyingHouseID, int temp)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                //   SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                DataSet dsorderDetail = new DataSet();
                cmdText = "sp_clients_get_all_clients_name";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseID", SqlDbType.Int);
                param.Value = BuyingHouseID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);
            }

        }



        public List<ClientDepartment> GetClientDeptsByClientID(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_depts_by_clientid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Client client = new Client();
                client.Departments = new List<ClientDepartment>();
                while (reader.Read())
                {
                    ClientDepartment cdept = new ClientDepartment();
                    cdept.DeptID = Convert.ToInt32(reader["Id"]);
                    cdept.Name = Convert.ToString(reader["DepartmentName"]);
                    client.Departments.Add(cdept);

                }

                return client.Departments;
            }
        }
        public List<ClientDepartment> GetClientDeptsByClientID_ForDesignForm(int ClientId, int UserID, int ParentDeptId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_depts_by_clientid_ForDesign";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDepID", SqlDbType.Int);
                param.Value = ParentDeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                Client client = new Client();
                client.Departments = new List<ClientDepartment>();
                while (reader.Read())
                {
                    ClientDepartment cdept = new ClientDepartment();
                    cdept.DeptID = Convert.ToInt32(reader["Id"]);
                    cdept.Name = Convert.ToString(reader["DepartmentName"]);
                    client.Departments.Add(cdept);

                }

                return client.Departments;
            }
        }


        public List<ClientDepartment> GetClientDeptsByClientIDOnlyForOrders(Int32 ClientId, string StyleCodeVersion)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_depts_by_clientid_stylecode_only_for_order";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleCodeVersion", SqlDbType.VarChar);
                param.Value = StyleCodeVersion;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Client client = new Client();
                client.Departments = new List<ClientDepartment>();

                //if (reader.HasRows)
                //{
                while (reader.Read())
                {
                    ClientDepartment cdept = new ClientDepartment();
                    cdept.DeptID = Convert.ToInt32(reader["Id"]);
                    cdept.Name = Convert.ToString(reader["DepartmentName"]);
                    cdept.Mon = Convert.ToInt32(reader["Mon"]);
                    cdept.Tue = Convert.ToInt32(reader["Tue"]);
                    cdept.Wed = Convert.ToInt32(reader["Wed"]);
                    cdept.Thu = Convert.ToInt32(reader["Thu"]);
                    cdept.Fri = Convert.ToInt32(reader["Fri"]);
                    cdept.Client = new Client();
                    cdept.Client.CompanyName = Convert.ToString(reader["CompanyName"]);
                    cdept.Client.ClientID = Convert.ToInt32(reader["ClientID"]);
                    client.Departments.Add(cdept);

                }
                //}

                return client.Departments;
            }


        }

        public List<User> GetClientAccMgrByClientID(int DepartmentId, int DesignationID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_accmgr_by_clientId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                param.Value = DepartmentId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //Gajendra Design
                param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<User> users = new List<User>();

                //if (reader.HasRows)
                //{
                while (reader.Read())
                {
                    User user = new User();
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    users.Add(user);

                }
                //}

                return users;

            }
        }

        public bool DeleteClientDept(ClientDepartment clientdept)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                //foreach (ClientDepartment clientdept in ClientUser.Departments)
                //{

                string cmdText = "sp_clients_delete_dept";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = clientdept.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = clientdept.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                //}

                cnx.Close();

            }
            return true;


        }

        public bool DeleteClientContact(ClientContact ccontact)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                //foreach (ClientContact ccontact in ClientUser.Contacts)
                //{

                string cmdText = "sp_clients_delete_contact";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ccontact.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ContactID", SqlDbType.VarChar);
                param.Value = ccontact.ContactID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                // }
            }
            return true;
        }

        public ClientDepartment GetClientDepartmentByUserID(int UserID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_dept_by_userid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                ClientDepartment clientDept = new ClientDepartment();

                if (reader.Read())
                {
                    clientDept.Client = new Client();

                    clientDept.Client.ClientID = Convert.ToInt32(reader["ClientId"]);
                    clientDept.Client.CompanyName = Convert.ToString(reader["CompanyName"]);
                    clientDept.Client.Address = Convert.ToString(reader["Address"]);
                    clientDept.Client.Website = Convert.ToString(reader["CompanyWebsite"]);
                    //clientDept.Client.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                    //clientDept.Client.TechnicalManagerID = Convert.ToInt32(reader["TechnicalManagerID"]);
                    //clientDept.Client.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                    ////client.DeliveryManagerID = Convert.ToInt32(reader["DeliveryManagerID"]);

                    //client.ExportManagerID = Convert.ToInt32(reader["ExportManagerID"]);
                    //client.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                    //client.GroupID = Convert.ToInt32(reader["GroupID"]);
                    clientDept.Client.ClientCode = reader["ClientCode"].ToString();
                    clientDept.Client.ClientSince = Convert.ToDateTime(reader["ClientSince"]);
                    clientDept.Client.Aql = Convert.ToDouble(reader["AqlStandards"]);
                    clientDept.Client.Phone = Convert.ToString(reader["Phone"]);
                    clientDept.Client.PaymentTerms = Convert.ToInt32(reader["PaymentTerms"]);
                    clientDept.Client.Discount = Convert.ToDecimal(reader["Discount"]);
                    clientDept.Client.Email = Convert.ToString(reader["Email"]);
                    clientDept.Client.IsMDARequired = Convert.ToInt32(reader["IsMDARequired"]);
                    clientDept.Client.BillingAddess = (reader["BillingAddess"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillingAddess"]);
                    clientDept.Client.OfficialName = (reader["OfficialName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OfficialName"]);

                    clientDept.Name = Convert.ToString(reader["DepartmentName"]);
                    clientDept.DeptID = Convert.ToInt32(reader["Id"]);
                }

                cnx.Close();
                return clientDept;

            }



        }

        public double GetClientDiscountByClientId(int clientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_discount_by_client_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object result = cmd.ExecuteScalar();
                cnx.Close();

                return (result == null) ? 0 : Convert.ToDouble(result);

            }
        }

        public bool DeleteClientDeptAssociation(ClientDepartmentAssociation clientdept)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_clients_delete_client_dept_association";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = clientdept.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }
            return true;


        }

        public List<ClientDepartment> GetClientListAssismentByClientID(int clientId)
        {
            List<ClientDepartment> ClientDepartment = new List<ClientDepartment>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_list_assigments";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClientDepartment clientDept = new ClientDepartment();
                        clientDept.Client = new Client();
                        clientDept.Name = ((reader["DepartmentName"] == DBNull.Value) ? string.Empty : reader["DepartmentName"].ToString());
                        clientDept.Client.SalesPersonName = ((reader["SalesName"] == DBNull.Value) ? string.Empty : reader["SalesName"].ToString());
                        clientDept.Client.TechnicalManagerName = ((reader["TechnicalName"] == DBNull.Value) ? string.Empty : reader["TechnicalName"].ToString());
                        clientDept.Client.AccountManagerName = ((reader["AccountName"] == DBNull.Value) ? string.Empty : reader["AccountName"].ToString());
                        clientDept.Client.DeliveryManagerName = ((reader["DeliveryName"] == DBNull.Value) ? string.Empty : reader["DeliveryName"].ToString());
                        clientDept.Client.ExportManagerName = ((reader["ExportName"] == DBNull.Value) ? string.Empty : reader["ExportName"].ToString());
                        clientDept.Client.DesignerName = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : reader["DesignerName"].ToString());
                        clientDept.Client.FitMerchantName = ((reader["FitMerchantName"] == DBNull.Value) ? string.Empty : reader["FitMerchantName"].ToString());
                        clientDept.Client.SamplingMerchantName = ((reader["SamplingMerchantName"] == DBNull.Value) ? string.Empty : reader["SamplingMerchantName"].ToString());
                        clientDept.Client.ClientHeadName = ((reader["ClientHeadName"] == DBNull.Value) ? string.Empty : (reader["ClientHeadName"]).ToString());

                        ClientDepartment.Add(clientDept);

                    }
                }
            }
            return ClientDepartment;

        }

        public List<ClientDepartment> GetClientViewDepartmentByClientID(int clientId)
        {
            List<ClientDepartment> ClientDepartment = new List<ClientDepartment>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_list_assigments";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClientDepartment clientDept = new ClientDepartment();
                        clientDept.Client = new Client();
                        clientDept.Name = ((reader["DepartmentName"] == DBNull.Value) ? string.Empty : reader["DepartmentName"].ToString());
                        clientDept.Username = (reader["Email"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Email"]);
                        clientDept.Mon = (reader["Mon"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Mon"]);
                        clientDept.Tue = (reader["Tue"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Tue"]);
                        clientDept.Wed = (reader["Wed"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Wed"]);
                        clientDept.Thu = (reader["Thu"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Thu"]);
                        clientDept.Fri = (reader["Fri"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Fri"]);
                        clientDept.SalesManagerNames = ((reader["SalesName"] == DBNull.Value) ? string.Empty : reader["SalesName"].ToString());
                        clientDept.TechnologistNames = ((reader["TechnicalName"] == DBNull.Value) ? string.Empty : reader["TechnicalName"].ToString());
                        clientDept.AccountManagerNames = ((reader["AccountName"] == DBNull.Value) ? string.Empty : reader["AccountName"].ToString());
                        clientDept.DeliveryManagerNames = ((reader["DeliveryName"] == DBNull.Value) ? string.Empty : reader["DeliveryName"].ToString());
                        clientDept.ShippingManagerNames = ((reader["ExportName"] == DBNull.Value) ? string.Empty : reader["ExportName"].ToString());
                        clientDept.DesignerNames = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : reader["DesignerName"].ToString());
                        clientDept.FITMerchantNames = ((reader["FitMerchantName"] == DBNull.Value) ? string.Empty : reader["FitMerchantName"].ToString());
                        clientDept.SamplingMerchantNames = ((reader["SamplingMerchantName"] == DBNull.Value) ? string.Empty : reader["SamplingMerchantName"].ToString());
                        clientDept.ClientHeadNames = ((reader["ClientHeadName"] == DBNull.Value) ? string.Empty : reader["ClientHeadName"].ToString());
                        ClientDepartment.Add(clientDept);

                    }
                }
            }
            return ClientDepartment;

        }


        public List<ClientDepartment> GetClientDeptsByClientIDByUserID(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_depts_by_clientid_by_user_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Client client = new Client();
                client.Departments = new List<ClientDepartment>();
                while (reader.Read())
                {
                    ClientDepartment cdept = new ClientDepartment();
                    cdept.DeptID = Convert.ToInt32(reader["Id"]);
                    cdept.Name = Convert.ToString(reader["DepartmentName"]);
                    client.Departments.Add(cdept);

                }

                return client.Departments;
            }
        }







        public DataTable GetAllClientDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_All_Client_For_Season";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsclient);
                return (dsclient.Tables[0]);

            }

        }


        public DataTable GetAllSeasonListInfoDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_SeasonList";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsclient);
                return (dsclient.Tables[0]);

            }

        }



        public DataTable GetAllSeasonListInfoWithClientDAL(int SeasonID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_ClientList_forSeason";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SeasonId", SqlDbType.Int);
                param.Value = SeasonID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsclient);
                return (dsclient.Tables[0]);

            }

        }





        public DataSet GetAllSeasonUpdateDAL(int SeasonID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Update_SeasonInfo";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SeasonId", SqlDbType.Int);
                param.Value = SeasonID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsclient);
                return (dsclient);

            }

        }

        public DataTable GetSeasonByClient(int ClientID, string StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;



                //  cmdText = "sp_Get_all_Season_by_clientID";
                cmdText = "sp_Get_Season_ByClientID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.VarChar);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }









        public void InsertSeasonDAL(int[] SeasonDates, int intID, string SeasonName, DateTime StartDate, DateTime endDate, string clientXML, int IsActive)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Insert_Season";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = intID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                param.Value = SeasonName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SeasonStartDate", SqlDbType.DateTime);
                param.Value = System.DateTime.Today; // StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SeasonEndDate", SqlDbType.DateTime);
                param.Value = System.DateTime.Today; //endDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClintIdXML", SqlDbType.VarChar);
                param.Value = clientXML;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@IsActive", SqlDbType.Int);
                param.Value = IsActive;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartMonth", SqlDbType.Int);
                param.Value = SeasonDates[0];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.Int);
                param.Value = SeasonDates[1];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@EndMonth", SqlDbType.Int);
                param.Value = SeasonDates[2];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.Int);
                param.Value = SeasonDates[3];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);













                cmd.ExecuteNonQuery();


                //}
                cnx.Close();

            }

        }



        public int CheckDateStatusDAL(int[] SeasonDates, int intID, DateTime StartDate, DateTime endDate, int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                int ss = 0;
                cmdText = "sp_SeasonDate_Status";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                // Add parameters
                SqlParameter param;
                SqlParameter param1;
                param1 = new SqlParameter("@oStatus", SqlDbType.Int);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);

                param = new SqlParameter("@SeasonId", SqlDbType.Int);
                param.Value = intID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@StartMonth", SqlDbType.Int);
                param.Value = SeasonDates[0];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.Int);
                param.Value = SeasonDates[1];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@EndMonth", SqlDbType.Int);
                param.Value = SeasonDates[2];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.Int);
                param.Value = SeasonDates[3];
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                cmd.ExecuteNonQuery();

                if (param1.Value != DBNull.Value)
                {
                    ss = Convert.ToInt32(param1.Value);
                }
                cnx.Close();
                return ss;
               

            }

        }




        //Add by Surendra2 on 01/11/2018.
        public int InsertIkandiSales_Admin(int Client, int PDept, int Dept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                int ss = 0;
                cmdText = "Usp_Inst_Updt_IkandiCommitSales_Admin";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Clients", SqlDbType.Int);
                param.Value = Client;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptId", SqlDbType.Int);
                param.Value = PDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = Dept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = Month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Value", SqlDbType.Int);
                param.Value = Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Pces", SqlDbType.Int);
                param.Value = Pcs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Userid", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                ss = cmd.ExecuteNonQuery();

                cnx.Close();
                return ss;               

            }

        }
        public int UpdateIkandiSales_Admin(int Client, int PDept, int Dept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                int ss = 0;
                cmdText = "Usp_Inst_Updt_IkandiCommitSales_Admin";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Clients", SqlDbType.Int);
                param.Value = Client;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptId", SqlDbType.Int);
                param.Value = PDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = Dept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = Month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Value", SqlDbType.Int);
                param.Value = Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Pces", SqlDbType.Int);
                param.Value = Pcs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Userid", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                ss = cmd.ExecuteNonQuery();

                cnx.Close();
                return ss;

            }

        }
        public DataSet GetIkandiSales_AdminByYear(int PrevYear, int NextYear)
        {            
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();               
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetIkandiCommitSales_Admin";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PrevYear", SqlDbType.Int);
                param.Value = PrevYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NextYear", SqlDbType.Int);
                param.Value = NextYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }

        //Add by Surendra2 on 05/11/2018.
        public int InsertIkandiSales_AdminNew(int Client, int PDept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                int ss = 0;
                cmdText = "Usp_Inst_Updt_IkandiCommitSales_AdminNew";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Clients", SqlDbType.Int);
                param.Value = Client;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptId", SqlDbType.Int);
                param.Value = PDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                
                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = Month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Value", SqlDbType.Int);
                param.Value = Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Pces", SqlDbType.Int);
                param.Value = Pcs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Userid", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                ss = cmd.ExecuteNonQuery();

                cnx.Close();
                return ss;

            }

        }
        public int UpdateIkandiSales_AdminNew(int Client, int PDept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                int ss = 0;
                cmdText = "Usp_Inst_Updt_IkandiCommitSales_AdminNew";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Clients", SqlDbType.Int);
                param.Value = Client;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptId", SqlDbType.Int);
                param.Value = PDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = Month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Value", SqlDbType.Int);
                param.Value = Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Pces", SqlDbType.Int);
                param.Value = Pcs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Userid", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                ss = cmd.ExecuteNonQuery();

                cnx.Close();
                return ss;

            }

        }
        public DataSet GetIkandiSales_AdminByYearNew(int PrevYear, int NextYear)
        {            
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();               
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetIkandiCommitSales_AdminNew";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PrevYear", SqlDbType.Int);
                param.Value = PrevYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NextYear", SqlDbType.Int);
                param.Value = NextYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }
        public DataSet GetIkandiSales_AdminByYearNew_Report(int PrevYear, int NextYear)
        {
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetIkandiCommitSales_AdminNew_Actual";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PrevYear", SqlDbType.Int);
                param.Value = PrevYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NextYear", SqlDbType.Int);
                param.Value = NextYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }




        public int CheckDuplicateSeasonDAL(string SeasonName, int SeasonId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                int ss = 0;
                cmdText = "sp_Check_Duplicate_Season";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                // Add parameters
                SqlParameter param;
                SqlParameter param1;
                param1 = new SqlParameter("@oStatus", SqlDbType.Int);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);

                param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                param.Value = SeasonName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@SeasonId", SqlDbType.Int);
                param.Value = SeasonId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();

                if (param1.Value != DBNull.Value)
                {
                    ss = Convert.ToInt32(param1.Value);
                }
                cnx.Close();
                return ss;
                //}
                

            }

        }

        public int CheckClientStatusDAL(int SeasonId, int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                int ss = 0;
                cmdText = "sp_CheckClient_Status";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                // Add parameters
                SqlParameter param;
                SqlParameter param1;
                param1 = new SqlParameter("@oStatus", SqlDbType.Int);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);

                param = new SqlParameter("@SeasonId", SqlDbType.Int);
                param.Value = SeasonId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                if (param1.Value != DBNull.Value)
                {
                    ss = Convert.ToInt32(param1.Value);
                }
                cnx.Close();
                return ss;
                //}
                

            }

        }









        public List<ClientDepartment> GetClientDeptsByClientIDs(string ClientIds)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();



                SqlDataReader reader;

                SqlCommand cmd;

                string cmdText;



                cmdText = "sp_clients_get_client_depts_by_clientids";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@ClientIds", SqlDbType.VarChar);

                param.Value = ClientIds;

                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);



                reader = cmd.ExecuteReader();



                Client client = new Client();

                client.Departments = new List<ClientDepartment>();

                while (reader.Read())
                {

                    ClientDepartment cdept = new ClientDepartment();

                    cdept.DeptID = Convert.ToInt32(reader["Id"]);

                    cdept.Name = Convert.ToString(reader["DepartmentName"]);

                    client.Departments.Add(cdept);

                }



                return client.Departments;

            }

        }

        // For Client Login on Manage Order



        public string[] GetClientDeptByUserId(int UserId)
        {
            ClientDepartment clntDept = new ClientDepartment();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_GetClientDeptByUserId";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            clntDept.ClientID = (reader["ClientId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientId"]);
                            clntDept.DeptID = (reader["DeptID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DeptID"]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            string[] Client = new string[] { Convert.ToString(clntDept.ClientID), Convert.ToString(clntDept.DeptID) };
            return Client;
        }
        //Added By Ashish on 17/4/2015
        public List<Client> GetAllClientsNameForIkandi(int BuyingHouseId, int ClientId, int DateType, string YearRange, int UserId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllClient_For_ManageOrder_ForIkandi";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = BuyingHouseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@YearRange", SqlDbType.VarChar);
                param.Value = YearRange;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                reader = cmd.ExecuteReader();
                List<Client> clients = new List<Client>();

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(reader["ClientId"]);
                    client.CompanyName = reader["CompanyName"].ToString();
                    // client.BuyingHouseId = Convert.ToInt32(reader["BuyingHouseID"]);
                    clients.Add(client);
                }

                return clients;
            }

        }
        //END
        public List<ClientDepartment> GetClientDeptsByClientID_New(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_clients_get_client_depts_by_clientid_New";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Client client = new Client();
                client.Departments = new List<ClientDepartment>();
                while (reader.Read())
                {
                    ClientDepartment cdept = new ClientDepartment();
                    cdept.DeptID = Convert.ToInt32(reader["Id"]);
                    cdept.Name = Convert.ToString(reader["DepartmentName"]);
                    client.Departments.Add(cdept);

                }

                return client.Departments;
            }
        }

        // End

        //// for fits only
        //public List<ClientDepartment> GetClientDeptsByDeptID(Int32 ClientId, Int32 DeptID, Int32 StyleNumber)
        //{

        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();

        //        SqlDataReader reader;
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "sp_clients_get_client_depts_by_deptid";
        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //        SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
        //        param.Value = ClientId;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@DeptID", SqlDbType.Int);
        //        param.Value = DeptID;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@StyleNumber", SqlDbType.Int);
        //        param.Value = StyleNumber;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        reader = cmd.ExecuteReader();

        //        Client client = new Client();
        //        client.Departments = new List<ClientDepartment>();

        //        //if (reader.HasRows)
        //        //{
        //        while (reader.Read())
        //        {
        //            ClientDepartment cdept = new ClientDepartment();
        //            cdept.DeptID = Convert.ToInt32(reader["Id"]);
        //            cdept.Name = Convert.ToString(reader["DepartmentName"]);
        //            cdept.Mon = Convert.ToInt32(reader["Mon"]);
        //            cdept.Tue = Convert.ToInt32(reader["Tue"]);
        //            cdept.Wed = Convert.ToInt32(reader["Wed"]);
        //            cdept.Thu = Convert.ToInt32(reader["Thu"]);
        //            cdept.Fri = Convert.ToInt32(reader["Fri"]);
        //            cdept.Client = new Client();
        //            cdept.Client.CompanyName = Convert.ToString(reader["CompanyName"]);
        //            cdept.Client.ClientID = Convert.ToInt32(reader["ClientID"]);
        //            client.Departments.Add(cdept);

        //        }
        //        //}

        //        return client.Departments;
        //    }
        //}

        public List<Client> get_all_clients_Order(int UnitId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_all_clients_Order";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                

                reader = cmd.ExecuteReader();
                List<Client> clients = new List<Client>();
                Client client1 = new Client();
                client1.ClientID = -1;
                client1.CompanyName = "Select";
                client1.BuyingHouseId = -1;
                clients.Add(client1);

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(reader["ClientId"]);
                    client.CompanyName = reader["CompanyName"].ToString();                    
                    clients.Add(client);
                }

                return clients;
            }

        }
      //added by abhishek 26/112/2018
        public DataSet GetIkandiSales_AdminByYearNew_Critical_Path_Report(int PrevYear, int NextYear,int PDeptID)
        {
          ClientDepartment cDept = new ClientDepartment();
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();
            SqlCommand cmd;
            string cmdText;

            cmdText = "Usp_GetIkandiCommitSales_AdminNew_Actual";
            cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@PrevYear", SqlDbType.Int);
            param.Value = PrevYear;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NextYear", SqlDbType.Int);
            param.Value = NextYear;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ClientUserID", SqlDbType.Int);
            param.Value = PDeptID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
          }
        }

        //below added by Girish on 2023-03-30
        public DataSet GetDataFor_grdIkandiadminCommit_sales_Grid(string DeptID)
        {
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetIkandiCommitSales_AdminNew_Actual";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@DeptID", SqlDbType.VarChar);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }

        public DataSet GetIkandiSales_AdminByYearNew_Report_DC(int PrevYear, int NextYear)
        {
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetIkandiCommitSales_AdminNew_Actual_DC";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PrevYear", SqlDbType.Int);
                param.Value = PrevYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NextYear", SqlDbType.Int);
                param.Value = NextYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }

        public string GetCountryById(string CountryId)
        {
            string CountryCode;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GETCountryCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "GetCountryCodeById";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountryId", SqlDbType.VarChar);
                param.Value = CountryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                CountryCode = Convert.ToString(cmd.ExecuteScalar());
                return CountryCode;
            }
        }

        public DataSet GetCountryCodesByClientID(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GETCountryCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "GetCountryCodesByClientID";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }

        public int SaveCountryCodes(int ClientID, int CountryId,string Flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GETCountryCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountryId", SqlDbType.Int);
                param.Value = CountryId;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                int result = cmd.ExecuteNonQuery();

                cnx.Close();
                return result;
            }
        }

      //END
    }
}
