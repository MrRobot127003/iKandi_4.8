using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class PartnerDataProvider : BaseDataProvider
    {

        #region Ctor(s)

        public PartnerDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Create methods

        public int InsertPartner(Partner objPartner)
        {
            int partnerID = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_partner_insert";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    SqlParameter paramOut;

                    paramOut = new SqlParameter("@d", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                  //  paramOut.Value = objPartner.PartnerID;
                    cmd.Parameters.Add(paramOut);

                    param = new SqlParameter("@PartnerName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.PartnerName;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartnerCode", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.PartnerCode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Website", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.Website == string.Empty)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objPartner.Website;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Phone", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.Phone == string.Empty)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {

                        param.Value = objPartner.Phone;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Email", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.Email;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Address", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.Address == string.Empty)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objPartner.Address;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryMode", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.DeliveryMode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartnerType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.PartnerType == PartnerType.UNKNOWN)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objPartner.PartnerType;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.UserID;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    partnerID = Convert.ToInt32(paramOut.Value);

                    //Save Partner Emails & Partner Client
                    if (partnerID > 0)
                    {
                        objPartner.PartnerID = partnerID;
                        foreach (PartnerClient objPartnerClient in objPartner.PartnerClient)
                        {
                            objPartnerClient.Partner.PartnerID = objPartner.PartnerID;
                            this.InsertPartnerClient(objPartnerClient, cnx, transaction);
                        }

                        foreach (PartnerEmail email in objPartner.EmailDetails)
                        {
                            if (email.PartnerEmailId == -1 && email.IsDeletedContact == false)
                            {
                                email.PartnerId = objPartner.PartnerID;
                                this.CreatePartnerEmail(email, cnx, transaction);
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
            return partnerID;
        }

        public int CreatePartnerEmail(PartnerEmail objPartnerEmail, SqlConnection cnx, SqlTransaction transaction)
        {
            int PartnerEmailId = 0;
            // Create a SQL command object
            string cmdText = "sp_partner_email_insert";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            // Set the command type to StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            // Add parameters
            SqlParameter param;
            SqlParameter paramOut;

            paramOut = new SqlParameter("@oId", SqlDbType.Int);
            paramOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramOut);

            param = new SqlParameter("@PartnerID", SqlDbType.Int);
            param.Value = objPartnerEmail.PartnerId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Name", SqlDbType.VarChar);
            param.Value = objPartnerEmail.Name;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.VarChar);
            param.Value = objPartnerEmail.Email;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Function", SqlDbType.Int);
            param.Value = objPartnerEmail.Function;
            param.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            PartnerEmailId = Convert.ToInt32(paramOut.Value);

            return PartnerEmailId;
        }

        public void InsertPartnerClient(PartnerClient objPartnerClient, SqlConnection cnx, SqlTransaction transaction)
        {

            string cmdText = "sp_partner_client_insert";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            // Set the command type to StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;
            param = new SqlParameter("@ClientID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPartnerClient.Client.ClientID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartnerID", SqlDbType.Int);
            param.Value = objPartnerClient.Partner.PartnerID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }

        #endregion

        #region Update Methods

        public bool UpdatePartner(Partner objPartner)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_partner_update";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@PartnerName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.PartnerName;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartnerCode", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.PartnerCode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Website", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.Website == string.Empty)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objPartner.Website;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Phone", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.Phone == string.Empty)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {

                        param.Value = objPartner.Phone;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Email", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.Email;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Address", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.Address == string.Empty)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objPartner.Address;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryMode", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.DeliveryMode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartnerType", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    if (objPartner.PartnerType == PartnerType.UNKNOWN)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objPartner.PartnerType;
                    }
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.UserID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = objPartner.PartnerID;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    //Now update Partner Email
                    foreach (PartnerEmail email in objPartner.EmailDetails)
                    {
                        if (email.PartnerEmailId == -1 && email.IsDeletedContact == false)
                        {
                            this.CreatePartnerEmail(email, cnx, transaction);
                        }
                        else if (email.IsDeletedContact == true)
                        {

                            this.DeletePartnerEmail(email, cnx, transaction);
                        }
                        else if (email.PartnerEmailId > 0 && email.IsDeletedContact == false)
                        {
                            this.UpdatePartnerEmail(email, cnx, transaction);
                        }
                    }

                    this.DeletePartnerClient(objPartner.PartnerID);

                    foreach (PartnerClient objPartnerClient in objPartner.PartnerClient)
                    {

                        this.InsertPartnerClient(objPartnerClient, cnx, transaction);
                    }

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
            return true;
        }


        public bool UpdatePartnerEmail(PartnerEmail objPartnerEmail, SqlConnection cnx, SqlTransaction transaction)
        {

            string cmdText = "sp_partner_email_update";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;
            param = new SqlParameter("@d", SqlDbType.Int);
            param.Value = objPartnerEmail.PartnerEmailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartnerID", SqlDbType.Int);
            param.Value = objPartnerEmail.PartnerId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Name", SqlDbType.VarChar);
            param.Value = objPartnerEmail.Name;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.VarChar);
            param.Value = objPartnerEmail.Email;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@Function", SqlDbType.Int);
            param.Value = objPartnerEmail.Function;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }
        #endregion

        #region Get Methods

        public Partner GetPartner(int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_partner_get_partner_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPartner = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPartner);

                Partner partner = ConvertDataSetToPartner(dsPartner);

                cnx.Close();
                return partner;
            }

        }

        private Partner ConvertDataSetToPartner(DataSet dsPartner)
        {
            DataTable partnerTable = dsPartner.Tables[0];

            DataRowCollection rows = partnerTable.Rows;

            Partner partners = new Partner();

            partners.PartnerID = Convert.ToInt32(rows[0]["Id"]);
            partners.PartnerName = (rows[0]["PartnerName"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["PartnerName"]);
            partners.PartnerCode = (rows[0]["PartnerCode"] == DBNull.Value ) ? string.Empty : Convert.ToString(rows[0]["PartnerCode"]);
            partners.Website = (rows[0]["Website"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["Website"]);
            partners.Phone = (rows[0]["Phone"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["Phone"]);
            partners.Email = Convert.ToString(rows[0]["Email"]);
            partners.Address = (rows[0]["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(rows[0]["Address"]);
            partners.DeliveryMode = (PartnerDeliveryMode)Convert.ToInt32(rows[0]["DeliveryMode"]);
            partners.PartnerType = (rows[0]["PartnerType"] == DBNull.Value) ? PartnerType.UNKNOWN : (PartnerType)Convert.ToInt32(rows[0]["PartnerType"]);
            partners.UserID = Convert.ToInt32(rows[0]["UserID"]);

            DataTable PartnerClientTable = dsPartner.Tables[1];

            partners.PartnerClient = new List<PartnerClient>();

            foreach (DataRow row in PartnerClientTable.Rows)
            {
                PartnerClient partnerClient = new PartnerClient();

                partnerClient.Client = new Client();
                partnerClient.Client.ClientID = Convert.ToInt32(row["ClientID"]);
                partnerClient.Partner = new Partner();
                partnerClient.Partner.PartnerID = Convert.ToInt32(row["PartnerID"]);

                partners.PartnerClient.Add(partnerClient);


            }

            return partners;
        }

        public List<Partner> GetAllPartner()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                String cmdText;

                cmdText = "sp_partner_get_all_partner";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                List<Partner> partners = new List<Partner>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Partner partner = new Partner();
                        partner.PartnerID = Convert.ToInt32(reader["Id"]);
                        partner.PartnerName = (reader["PartnerName"] == DBNull.Value ) ? string.Empty : (reader["PartnerName"]).ToString();
                        partner.PartnerCode = (reader["PartnerCode"] == DBNull.Value ) ? string.Empty : (reader["PartnerCode"]).ToString();
                        partner.Website = (reader["Website"] == DBNull.Value) ? string.Empty : (reader["Website"]).ToString();
                        partner.Phone = (reader["Phone"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Phone"]);
                        partner.Email = Convert.ToString(reader["Email"]);
                        partner.Address = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);
                        partner.DeliveryMode = (PartnerDeliveryMode)Convert.ToInt32(reader["DeliveryMode"]);
                        partner.PartnerType = (reader["PartnerType"] == DBNull.Value) ? PartnerType.UNKNOWN : (PartnerType)Convert.ToInt32(reader["PartnerType"]);
                        partner.UserID = Convert.ToInt32(reader["UserID"]);

                        partners.Add(partner);

                    }
                }
                cnx.Close();
                return partners;
            }

        }

        public List<PartnerEmail> GetPartnerEmail(int PartnerID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_partner_email_get_partner_email_by_partnerid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PartnerID", SqlDbType.Int);
                param.Value = PartnerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<PartnerEmail> partnerEmail = new List<PartnerEmail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PartnerEmail email = new PartnerEmail();
                        email.PartnerEmailId = Convert.ToInt32(reader["Id"]);
                        email.PartnerId = Convert.ToInt32(reader["PartnerID"]);
                        email.Name = reader["Name"].ToString();
                        email.Email = reader["Email"].ToString();
                        email.Function = (PartnerEmailFunction)Convert.ToInt32(reader["Function"]);
                        partnerEmail.Add(email);

                    }
                }
                cnx.Close();
                return partnerEmail;

            }
        }

        public System.Data.DataSet GetPatnerIDByMode(int modeId, int clientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_partner_get_partner_by_mode";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ModeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = modeId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = clientId;
                cmd.Parameters.Add(param);

                DataSet dsPartnerIDs = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPartnerIDs);

                cnx.Close();

                return dsPartnerIDs;
                                
            }

        }

        public Partner GetPartnerByUserID(int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_partner_get_partner_by_userid";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader(); ;

                Partner partner = new Partner();

                if (reader.Read())
                {
                    partner.PartnerID = Convert.ToInt32(reader["Id"]);
                    partner.PartnerName = (reader["PartnerName"] == DBNull.Value ) ? string.Empty : Convert.ToString(reader["PartnerName"]);
                    partner.PartnerCode = (reader["PartnerCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartnerCode"]);
                    partner.Website = (reader["Website"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Website"]);
                    partner.Phone = (reader["Phone"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Phone"]);
                    partner.Email = Convert.ToString(reader["Email"]);
                    partner.Address = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);
                    partner.DeliveryMode = (PartnerDeliveryMode)Convert.ToInt32(reader["DeliveryMode"]);
                    partner.PartnerType = (reader["PartnerType"] == DBNull.Value) ? PartnerType.UNKNOWN : (PartnerType)Convert.ToInt32(reader["PartnerType"]);
                    partner.UserID = Convert.ToInt32(reader["UserID"]);
                }

                cnx.Close();
                return partner;
            }

        }


        #endregion

        #region Delete Methods


        public bool DeletePartner(int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_partner_delete_partner";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Id;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            return true;
        }

        public bool DeletePartnerEmail(PartnerEmail objPartner, SqlConnection cnx, SqlTransaction transaction)
        {

            string cmdText = "sp_partner_email_delete_partner_email";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;
            param = new SqlParameter("@d", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPartner.PartnerEmailId;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeletePartnerClient(int PartnerID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_partner_client_delete";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;


                param = new SqlParameter("@PartnerID", SqlDbType.Int);
                param.Value = PartnerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }
            return true;
        }



        #endregion



    }
}

