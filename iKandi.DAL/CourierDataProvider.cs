using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class CourierDataProvider: BaseDataProvider
    {
        #region Ctor(s)

        public CourierDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public Couriers GetAllCourier()
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_courier_get_all_courier_details";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataReader reader = cmd.ExecuteReader();

                Couriers couriers = new Couriers();

                while (reader.Read())
                {
                    Courier courier = new Courier();

                    courier.CourierID = Convert.ToInt32(reader["Id"]);
                    courier.ContactName = (reader["ContactName"] == DBNull.Value) ? string.Empty : reader["ContactName"].ToString();
                    courier.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : reader["ClientName"].ToString();
                    courier.Department = (reader["Department"] == DBNull.Value) ? string.Empty : reader["Department"].ToString();
                    courier.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : reader["StyleNumber"].ToString();
                    courier.CourierCompany = (reader["CourierCompany"] == DBNull.Value) ? string.Empty : reader["CourierCompany"].ToString();
                    courier.CourierNumber = (reader["CourierNumber"] == DBNull.Value) ? string.Empty : reader["CourierNumber"].ToString();
                    courier.Fabric = (reader["Fabric"] == DBNull.Value) ? string.Empty : reader["Fabric"].ToString();
                    courier.Fab1 = (reader["Fabric"] == DBNull.Value) ? string.Empty : reader["Fabric"].ToString();
                    courier.CCGSM = (reader["Fabric11"] == DBNull.Value) ? string.Empty : reader["Fabric11"].ToString();
                    courier.Item = (reader["Item"] == DBNull.Value) ? string.Empty : reader["Item"].ToString();
                    courier.Purpose = (reader["Purpose"] == DBNull.Value) ? string.Empty : reader["Purpose"].ToString();
                    courier.Quantity = (reader["Quantity"] == DBNull.Value) ? string.Empty : reader["Quantity"].ToString();
                    courier.SentByUserName = ((reader["SentByFirstName"] == DBNull.Value) ? string.Empty : reader["SentByFirstName"].ToString()) + " " + ((reader["SentByLastName"] == DBNull.Value) ? string.Empty : reader["SentByLastName"].ToString());
                    courier.SentByUserID = (reader["SentByUserID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SentByUserID"].ToString());
                    courier.CourierSentOn = (reader["CourierSentOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierSentOn"].ToString());

                    couriers.Add(courier);
                }

                cnx.Close();

                return couriers;
            }
        }

    //Abhishek Added 
        public DataTable GetAttchemrntEmilBuyingHouseDAL(DateTime SentOn, string SearchKeyword, int Type, int BuyingHouseId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                //string date = SentOn.Day.ToString();
                //string month = SentOn.Month.ToString();
                //string year = SentOn.Year.ToString();
                //string ExectDate = date + "/" + month + "/" + year;
                //DateTime oDate = DateTime.ParseExact(ExectDate, "yyyy-MM-dd HH:mm tt",null);

                string cmdText = "sp_attachment_get_all_courier_for_particular_buyinghouse";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                param.Value = SentOn;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchKeyword", SqlDbType.VarChar);
                param.Value = SearchKeyword;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BHType", SqlDbType.Int);
                param.Value = BuyingHouseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //SqlDataReader reader = cmd.ExecuteReader();



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                
                return dt;


            }

        }

        //END

//added by abhishek on 7/7/2015 for dispatch_couriermail
        public Couriers GetAllCourierByDate_2(DateTime SentOn, string SearchKeyword, int Type, int BHType)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_attachment_get_all_courier_for_particular_buyinghouse";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                param.Value = new DateTime(SentOn.Year, SentOn.Month, SentOn.Day, 0, 0, 0);
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchKeyword", SqlDbType.VarChar);
                param.Value = SearchKeyword;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BHType", SqlDbType.Int);
                param.Value = BHType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                Couriers couriers = new Couriers();

                while (reader.Read())
                {
                    Courier courier = new Courier();

                    courier.CourierID = Convert.ToInt32(reader["Id"]);
                    courier.ContactName = (reader["ContactName"] == DBNull.Value) ? string.Empty : reader["ContactName"].ToString();
                    courier.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : reader["ClientName"].ToString();
                    courier.Department = (reader["Department"] == DBNull.Value) ? string.Empty : reader["Department"].ToString();
                    courier.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : reader["StyleNumber"].ToString();
                    courier.CourierCompany = (reader["CourierCompany"] == DBNull.Value) ? string.Empty : reader["CourierCompany"].ToString();
                    courier.CourierNumber = (reader["CourierNumber"] == DBNull.Value) ? string.Empty : reader["CourierNumber"].ToString();
                    courier.Fabric = (reader["Fabric"] == DBNull.Value) ? string.Empty : reader["Fabric"].ToString();
                    courier.Fab1 = (reader["Fab1"] == DBNull.Value) ? string.Empty : reader["Fab1"].ToString();
                    courier.Fab2 = (reader["Fab2"] == DBNull.Value) ? string.Empty : reader["Fab2"].ToString();
                    courier.Fab3 = (reader["Fab3"] == DBNull.Value) ? string.Empty : reader["Fab3"].ToString();
                    courier.Fab4 = (reader["Fab4"] == DBNull.Value) ? string.Empty : reader["Fab4"].ToString();
                    courier.CCGSM1 = (reader["CCGSM1"] == DBNull.Value) ? string.Empty : reader["CCGSM1"].ToString();
                    courier.CCGSM2 = (reader["CCGSM2"] == DBNull.Value) ? string.Empty : reader["CCGSM2"].ToString();
                    courier.CCGSM3 = (reader["CCGSM3"] == DBNull.Value) ? string.Empty : reader["CCGSM3"].ToString();
                    courier.CCGSM4 = (reader["CCGSM4"] == DBNull.Value) ? string.Empty : reader["CCGSM4"].ToString();
                    courier.Fab11 = (reader["Fabric"] == DBNull.Value) ? string.Empty : reader["Fabric"].ToString();
                    courier.Item = (reader["Item"] == DBNull.Value) ? string.Empty : reader["Item"].ToString();
                    courier.Purpose = (reader["Purpose"] == DBNull.Value) ? string.Empty : reader["Purpose"].ToString();
                    courier.Quantity = (reader["Quantity"] == DBNull.Value) ? string.Empty : reader["Quantity"].ToString();
                    courier.SentByUserName = ((reader["SentByFirstName"] == DBNull.Value) ? string.Empty : reader["SentByFirstName"].ToString()) + " " + ((reader["SentByLastName"] == DBNull.Value) ? string.Empty : reader["SentByLastName"].ToString());
                    courier.SentByUserID = (reader["SentByUserID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SentByUserID"].ToString());
                    courier.CourierSentOn = (reader["CourierSentOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierSentOn"].ToString());
                    courier.CourierSentOnString = (reader["CourierSentOn"] == DBNull.Value || Convert.ToDateTime(reader["CourierSentOn"]) == DateTime.MinValue) ? string.Empty : Convert.ToDateTime(reader["CourierSentOn"]).ToString("dd MMM yy (ddd)");
                    couriers.Add(courier);
                }

                cnx.Close();

                return couriers;
            }
        }


        public Couriers GetAllCourierByDate(DateTime SentOn, string SearchKeyword, int Type)//, int BHType)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_courier_get_all_courier_detail_by_date";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                param.Value = new DateTime(SentOn.Year, SentOn.Month, SentOn.Day, 0, 0, 0);
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchKeyword", SqlDbType.VarChar);
                param.Value = SearchKeyword;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@BHType", SqlDbType.Int);
                //param.Value = BHType;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                Couriers couriers = new Couriers();

                while (reader.Read())
                {
                    Courier courier = new Courier();

                    courier.CourierID = Convert.ToInt32(reader["Id"]);
                    courier.ContactName = (reader["ContactName"] == DBNull.Value) ? string.Empty : reader["ContactName"].ToString();
                    courier.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : reader["ClientName"].ToString();
                    courier.Department = (reader["Department"] == DBNull.Value) ? string.Empty : reader["Department"].ToString();
                    courier.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : reader["StyleNumber"].ToString();
                    courier.CourierCompany = (reader["CourierCompany"] == DBNull.Value) ? string.Empty : reader["CourierCompany"].ToString();
                    courier.CourierNumber = (reader["CourierNumber"] == DBNull.Value) ? string.Empty : reader["CourierNumber"].ToString();
                    courier.Fabric = (reader["Fabric"] == DBNull.Value) ? string.Empty : reader["Fabric"].ToString();
                    courier.Fab1 = (reader["Fab1"] == DBNull.Value) ? string.Empty : reader["Fab1"].ToString();
                    courier.Fab2 = (reader["Fab2"] == DBNull.Value) ? string.Empty : reader["Fab2"].ToString();
                    courier.Fab3 = (reader["Fab3"] == DBNull.Value) ? string.Empty : reader["Fab3"].ToString();
                    courier.Fab4 = (reader["Fab4"] == DBNull.Value) ? string.Empty : reader["Fab4"].ToString();
                    courier.Fab5 = (reader["Fab5"] == DBNull.Value) ? string.Empty : reader["Fab5"].ToString();
                    courier.Fab6 = (reader["Fab6"] == DBNull.Value) ? string.Empty : reader["Fab6"].ToString();
                    courier.CCGSM1 = (reader["CCGSM1"] == DBNull.Value) ? string.Empty : reader["CCGSM1"].ToString();
                    courier.CCGSM2 = (reader["CCGSM2"] == DBNull.Value) ? string.Empty : reader["CCGSM2"].ToString();
                    courier.CCGSM3 = (reader["CCGSM3"] == DBNull.Value) ? string.Empty : reader["CCGSM3"].ToString();
                    courier.CCGSM4 = (reader["CCGSM4"] == DBNull.Value) ? string.Empty : reader["CCGSM4"].ToString();
                    courier.CCGSM5 = (reader["CCGSM5"] == DBNull.Value) ? string.Empty : reader["CCGSM5"].ToString();
                    courier.CCGSM6 = (reader["CCGSM6"] == DBNull.Value) ? string.Empty : reader["CCGSM6"].ToString();
                    courier.Fab11 = (reader["Fabric"] == DBNull.Value) ? string.Empty : reader["Fabric"].ToString();
                    courier.Item = (reader["Item"] == DBNull.Value) ? string.Empty : reader["Item"].ToString();
                    courier.Purpose = (reader["Purpose"] == DBNull.Value) ? string.Empty : reader["Purpose"].ToString();
                    courier.Quantity = (reader["Quantity"] == DBNull.Value) ? string.Empty : reader["Quantity"].ToString();
                    courier.SentByUserName = ((reader["SentByFirstName"] == DBNull.Value) ? string.Empty : reader["SentByFirstName"].ToString()) + " " + ((reader["SentByLastName"] == DBNull.Value) ? string.Empty : reader["SentByLastName"].ToString());
                    courier.SentByUserID = (reader["SentByUserID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SentByUserID"].ToString());
                    courier.CourierSentOn = (reader["CourierSentOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierSentOn"].ToString());
                    courier.CourierSentOnString = (reader["CourierSentOn"] == DBNull.Value || Convert.ToDateTime(reader["CourierSentOn"]) == DateTime.MinValue) ? string.Empty : Convert.ToDateTime(reader["CourierSentOn"]).ToString("dd MMM yy (ddd)");
                    courier.SampleSent = (reader["SampleSent"] == DBNull.Value) ? false : Convert.ToBoolean(reader["SampleSent"]);
                    couriers.Add(courier);
                }

                cnx.Close();

                return couriers;
            }
        }

        public int InsertCourier(Courier CourierDetail)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_courier_insert_carrier_detail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters

                SqlParameter outParam;
                outParam = new SqlParameter("@CourierID", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@ContactName", SqlDbType.VarChar);
                param.Value = CourierDetail.ContactName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param.Value = CourierDetail.ClientName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Department", SqlDbType.VarChar);
                param.Value = CourierDetail.Department;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = CourierDetail.StyleNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@tem", SqlDbType.VarChar);
                param.Value = CourierDetail.Item;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Quantity", SqlDbType.VarChar);
                param.Value = CourierDetail.Quantity;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = CourierDetail.Fabric;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Purpose", SqlDbType.VarChar);
                param.Value = CourierDetail.Purpose;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourierNumber", SqlDbType.VarChar);
                param.Value = CourierDetail.CourierNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourierCompany", SqlDbType.VarChar);
                param.Value = CourierDetail.CourierCompany;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SentByUserID", SqlDbType.Int);
                param.Value = CourierDetail.SentByUserID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                param.Value = CourierDetail.CourierSentOn;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsSampleSent", SqlDbType.Bit);
                param.Value = CourierDetail.SampleSent;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int courierID = Convert.ToInt32(outParam.Value);

                cnx.Close();

                return courierID;
            }
        }

        public void UpdateCourier(Courier CourierDetail)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_courier_update_courier_detail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters

                SqlParameter param;
                param = new SqlParameter("@CourierID", SqlDbType.Int);
                param.Value = CourierDetail.CourierID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ContactName", SqlDbType.VarChar);
                param.Value = CourierDetail.ContactName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientName", SqlDbType.VarChar);
                param.Value = CourierDetail.ClientName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Department", SqlDbType.VarChar);
                param.Value = CourierDetail.Department;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = CourierDetail.StyleNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@tem", SqlDbType.VarChar);
                param.Value = CourierDetail.Item;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Quantity", SqlDbType.VarChar);
                param.Value = CourierDetail.Quantity;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = CourierDetail.Fabric;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Purpose", SqlDbType.VarChar);
                param.Value = CourierDetail.Purpose;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourierNumber", SqlDbType.VarChar);
                param.Value = CourierDetail.CourierNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourierCompany", SqlDbType.VarChar);
                param.Value = CourierDetail.CourierCompany;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SentByUserID", SqlDbType.Int);
                param.Value = CourierDetail.SentByUserID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                param.Value = CourierDetail.CourierSentOn;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                //param = new SqlParameter("@IsSampleSent", SqlDbType.Bit);
                //param.Value = CourierDetail.SampleSent;
                //param.Direction = ParameterDirection.Input;

                //cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }
       



    }

}
