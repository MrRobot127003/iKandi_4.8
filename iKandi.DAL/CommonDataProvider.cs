using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;


namespace iKandi.DAL
{
    public class CommonDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public CommonDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<string> SuggestForAutoComplete(string searchValue, string searchContext)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                // cmdText = "sp_Febric_As_TradeName";
                cmdText = "sp_suggest_for_auto_complete";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                if (searchContext == "RegisteredTradeName")
                {
                    if (reader.RecordsAffected > 1)
                    {
                        while (reader.Read())
                        {
                            result.Add(Convert.ToString(reader["idFabric_support"]));
                        }
                    }
                }
                else if (searchContext == "UnRegAccessoryName")
                {
                    //if (reader.RecordsAffected > 1)
                    //{
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["ResultValue"]));
                    }
                    //}
                }
                else
                {
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["ResultValue"]));
                    }
                }
                return result;
            }
        }
        //RajeevS 27042023
        public List<string> SuggestForAccAutoComplete(string SearchText, string SearchArea)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;                
                cmdText = "USP_SuggestedAccQualPrintPOSupplier";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("SearchArea", SqlDbType.VarChar);
                param.Value = SearchArea;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                if (SearchArea == "AccQuality")
                {                   
                        while (reader.Read())
                        {
                            result.Add(Convert.ToString(reader["TradeName"]));
                        }                   
                }
                else if (SearchArea == "AccColorPrint")
                {
                   while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["Color_Print"]));
                    }                 
                }
                else if (SearchArea == "AccPONumber")
                {                  
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["PO_Number"]));
                    }                
                }
                else if (SearchArea == "AccSupplier")
                {                    
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["SupplerName"]));
                    }                   
                }
               
                return result;
            }
        }      
        //
        public List<string> GetAccessoryList_ByTradeName(string searchValue, int StyleID, int ClientId, int ParentDeptId, int DeptId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    List<string> result = new List<string>();
                    SqlCommand cmd;
                    string cmdText;
                    cnx.Open();
                    cmdText = "Usp_GetAccessory_Populate";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    SqlParameter param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                    param.Value = searchValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDeptId", SqlDbType.Int);
                    param.Value = ParentDeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["AccessoryDetails"]));
                    }
                    cnx.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return null;
                }
            }
        }

        public List<string> GetAccessoryList_ByTradeName_Design(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    List<string> result = new List<string>();
                    SqlCommand cmd;
                    string cmdText;
                    cnx.Open();
                    cmdText = "Usp_GetAccessory_Populate_ForDesign";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                    param.Value = searchValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 1)
                    {
                        foreach (DataRow rows in dt.Rows)
                        {
                            string r = Convert.ToString(rows["AccessoryDetails"]);
                            result.Add(r);
                        }
                    }
                    cnx.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return null;
                }
            }
        }

        public DataSet GetAccessory_Size_Rate(string searchValue, int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    SqlCommand cmd;
                    string cmdText;
                    cnx.Open();
                    cmdText = "Usp_Get_Accessory_Size_Rate";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@AccessoryMaster_Id", SqlDbType.VarChar);
                    param.Value = searchValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet ds = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return null;
                }
            }
        }

        //added by abhishek on 12 AutoComplete unit wise
        public List<string> SuggestForAutoCompleteByunitid(string searchValue, string searchContext, int unitid)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                // cmdText = "sp_Febric_As_TradeName";
                cmdText = "sp_suggest_for_auto_complete";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("UnitID", SqlDbType.Int);
                param.Value = unitid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                if (searchContext == "RegisteredTradeName")
                {
                    if (reader.RecordsAffected > 1)
                    {
                        while (reader.Read())
                        {
                            result.Add(Convert.ToString(reader["idFabric_support"]));
                        }
                    }
                }
                else
                {
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["ResultValue"]));
                    }
                }
                return result;
            }
        }
        //added by abhishek for only manage order autocomplete ..
        public List<string> SuggestForAutoComplete1(string searchValue, string str, string searchContext)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                // cmdText = "sp_Febric_As_TradeName";
                cmdText = "sp_suggest_for_auto_complete";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                List<string> result = new List<string>();
                //reader = cmd.ExecuteReader();
                try
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["ResultValue"]));
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }


                return result;
            }
        }


        /// <summary>
        /// For Autocomplete Story : Yaten 31 Aug
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="searchContext"></param>
        /// <returns></returns>

        public List<string> SuggestStoryDAL(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                // cmdText = "sp_Febric_As_TradeName";
                cmdText = "sp_Get_Suggested_Story";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                List<string> result = new List<string>();
                try
                {
                    reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["story"]));
                    }



                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return result;
            }
        }



        public List<string> SuggestSupplierNameDAL(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                // cmdText = "sp_Febric_As_TradeName";
                cmdText = "sp_Get_Suggested_Story";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                List<string> result = new List<string>();
                try
                {
                    reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["story"]));
                    }



                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return result;
            }
        }


        public List<string> SuggestProcessOrderDAL(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Suggested_PO";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                List<string> result = new List<string>();
                try
                {
                    reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["PONumber"]));
                    }



                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return result;
            }
        }







        //public int GetModeDays(int modeValue)
        //{
        //    int days = 2;
        //    switch (modeValue)
        //    {
        //        case 1:
        //            days = 17;
        //            break;

        //        case 2:
        //            days = 21;
        //            break;

        //        case 3:
        //            days = 45;
        //            break;

        //        case 4:
        //            days = 52;
        //            break;

        //        case 5:
        //            days = 45;
        //            break;

        //        case 6:
        //        case 7:
        //        case 8:
        //        case 9:
        //        case 10:
        //        case 11:
        //            days = 17;
        //            break;

        //        case 12:
        //            days = 21;
        //            break;

        //        default:
        //            break;

        //    }

        //    return days;
        //}

        public double GetZipRateStyle(string zipDetail, ZipRateType zipType, string zipSize, int styleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                object zipRate = null;

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_zip_get_zip_rate_styleId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Detail", SqlDbType.VarChar);
                param.Value = zipDetail;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = zipType.ToString();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.Int);
                param.Value = zipSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@styleId", SqlDbType.Int);
                param.Value = styleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                zipRate = cmd.ExecuteScalar();

                if (null == zipRate)
                    return 0;
                else
                    return Convert.ToDouble(zipRate);
            }
        }


        public double GetZipRate(string zipDetail, ZipRateType zipType, string zipSize)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                object zipRate = null;

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_zip_get_zip_rate";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Detail", SqlDbType.VarChar);
                param.Value = zipDetail;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = zipType.ToString();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.Int);
                param.Value = zipSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                zipRate = cmd.ExecuteScalar();

                if (null == zipRate)
                    return 0;
                else
                    return Convert.ToDouble(zipRate);
            }
        }

        public List<iKandi.Common.ProductionUnit> GetUnitByUserId(int userId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_unit_get_unit_by_userId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UserId", SqlDbType.VarChar);
                param.Value = userId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<iKandi.Common.ProductionUnit> units = new List<iKandi.Common.ProductionUnit>();
                while (reader.Read())
                {
                    ProductionUnit unit = new ProductionUnit();
                    unit.FactoryCode = reader["Unit"].ToString();
                    unit.ProductionUnitId = Convert.ToInt32(reader["Id"]);
                    units.Add(unit);
                }

                return units;
            }
        }




        public List<iKandi.Common.ProductionUnit> GetUnitReports()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_report_Units";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                reader = cmd.ExecuteReader();

                List<iKandi.Common.ProductionUnit> units = new List<iKandi.Common.ProductionUnit>();
                while (reader.Read())
                {
                    ProductionUnit unit = new ProductionUnit();
                    unit.FactoryCode = reader["UnitName"].ToString();
                    unit.ProductionUnitId = Convert.ToInt32(reader["Id"]);
                    units.Add(unit);
                }

                return units;
            }
        }


        public List<string> SuggestForPrintNumberAutoComplete2(string searchValue, string searchContext, int clientId, int PrintCategory)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_suggest_for_print_number_auto_complete";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                param.Value = PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ResultValue"]));
                }

                return result;
            }
        }

        // Adding new service for the color suggestion in design form by Bharat veer dated on 22 may 2019
        public List<string> SuggestForColorAutoComplete2(string searchValue, int clientId, int PrintCategory)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_suggest_for_color_auto_complete";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("searchContext", SqlDbType.VarChar);
                //param.Value = searchContext;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                param.Value = PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ResultValue"]));
                }

                return result;
            }
        }

        /// <summary>
        ///Yaten : Suggest Registered Client List  18 Apr
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="searchContext"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public List<string> SuggestForRegisteredClient(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_suggest_for_registered_client";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["companyName"]));
                }

                return result;
            }
        }
        public List<string> SuggestForAutoComplete_supplier(string searchValue, string searchContext)
        {
            List<string> result = new List<string>();
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    //cmdText = "sp_suggest_for_registered_fabrics_auto_complete";
                    cmdText = "sp_suggest_for_auto_complete_for_supplier";
                    //   cmdText = "sp_Febric_As_TradeName";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                    param.Value = searchValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("searchContext", SqlDbType.VarChar);
                    param.Value = searchContext;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet ds = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    DataTable dt1 = ds.Tables[0];





                    foreach (DataRow rows in dt1.Rows)
                    {
                        string r = Convert.ToString(rows["ResultValue"]);
                        result.Add(r);
                    }



                    cnx.Close();


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return result;
        }


        /// <summary>
        /// Yaten: Fetch Data for StyleId 18 Apr
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="SubCategoryId"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public List<string> SuggestPrintNumbers_ForMultiplePrints2(string searchValue, string searchContext, int clientId, string iStylenumber, int PrintCategory)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_print_style_fabic";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stylenumber", SqlDbType.VarChar);
                param.Value = iStylenumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                param.Value = PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ResultValue"]));
                }

                return result;
            }
        }

        //added on 27 Jan 2021 start
        public List<string> AutoComplete_Accessory_Pending_OrderSummary1(string searchValue, string searchContext, int clientId, string iStylenumber, int PrintCategory)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                //cmdText = "sp_get_AutoPopulated_PendingScreen";
                cmdText = "sp_get_AutoPopulated_Acc_PendingScreen";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stylenumber", SqlDbType.VarChar);
                param.Value = iStylenumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                param.Value = PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ResultValue"]));
                }

                return result;
            }
        }
        //added on 27 Jan 2021 end

        //added on 07 Jan 2021 start
        public List<string> AutoComplete_Fabric_Pending_OrderSummary1(string searchValue, string searchContext, int clientId, string iStylenumber, int PrintCategory)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_AutoPopulated_PendingScreen";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stylenumber", SqlDbType.VarChar);
                param.Value = iStylenumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                param.Value = PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ResultValue"]));
                }

                return result;
            }
        }
        //added on 07 Jan 2021 end
        /// <summary>
        ///Yaten : Fetch Prints for Style Number 18 Apr
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="searchContext"></param>
        /// <param name="clientId"></param>
        /// <param name="iStylenumber"></param>
        /// <returns></returns>
        public List<string> SuggestPrintNumbers_ForMultiplePrintsStyleNumber2(string searchValue, string searchContext, int clientId, string iStylenumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_print_style_fabic_StyleNumber2";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Stylenumber", SqlDbType.VarChar);
                param.Value = iStylenumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["ResultValue"]));
                }

                return result;
            }
        }


        public string GetIdentification(int CategoryId, int SubCategoryId, int Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {


                SqlCommand cmd;
                string cmdText;
                string identification = "";

                try
                {
                    cmdText = "sp_category_get_identification";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@CategoryId", SqlDbType.Int);
                    param.Value = CategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                    param.Value = SubCategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.Int);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter paramOut;
                    paramOut = new SqlParameter("@Code", SqlDbType.VarChar, 50);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);

                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    identification = Convert.ToString(paramOut.Value);
                }
                catch (SqlException sql)
                {
                    sql.Message.ToString();
                }

                //if ((categoryCode.Rows.Count > 0) && (subCategoryCode.Rows.Count > 0) && (code.Rows.Count > 0))
                //    identification = categoryCode.Rows[0]["CategoryCode"].ToString() + "-" + subCategoryCode.Rows[0]["SubCategoryCode"].ToString() + "-" + (System.Text.ASCIIEncoding.ASCII.GetString((byte[])code.Rows[0]["Code"])).ToString();

                return identification;
            }

        }



        public List<string> SuggestForRegisteredTradeNamesAutoCompleteForOrder(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                //cmdText = "sp_suggest_for_registered_fabrics_auto_complete";
                cmdText = "sp_Febric_As_TradeName_ForOrder";
                //   cmdText = "sp_Febric_As_TradeName";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                DataTable dt1 = ds.Tables[0];
                //DataTable dt2 = ds.Tables[1];
                //DataTable dt3 = ds.Tables[2];

                List<string> result = new List<string>();
                //List<string> result1 = new List<string>();
                //List<string> result2 = new List<string>();

                foreach (DataRow rows in dt1.Rows)
                {
                    string r = Convert.ToString(rows["idFabric_support"]);
                    result.Add(r);
                }



                cnx.Close();

                return result;
            }
        }
        /// <summary>
        /// Yaten : Get resoluotion closed tast 13 Apr
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public DataTable GetClosedTask(int userId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_Get_all_closed_task";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = userId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }
        }

        /// <summary>
        /// Yaten : Get Critical Report Status 18 Apr
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>


        public DataTable ShowCriticalReportStatus(int intClientId, int intReportId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_critical_path_report_permissions";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = intClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReportId", SqlDbType.Int);
                param.Value = intReportId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }
        }
        /// <summary>
        /// Yaten : For Bind Client lisdt dropdown list on Critical path Admin  18 Apr
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetClientNamesAndIds()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_get_ClientId_ClientsNames";
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




        /// <summary>
        /// Yaten : For Update Permissions 18 Apr
        /// </summary>
        /// <param name="intClientId"></param>
        /// <param name="intReportId"></param>
        /// <returns></returns>

        public void UpdatePermissionsReport(string stringXml, int intClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_update_report_permissions";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("fabXml", SqlDbType.VarChar);
                param.Value = stringXml;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
        }


        public List<string> SuggestForRegisteredTradeNamesAutoComplete(string searchValue)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                //cmdText = "sp_suggest_for_registered_fabrics_auto_complete";

                cmdText = "sp_Febric_As_TradeName";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                DataTable dt1 = ds.Tables[0];
                //DataTable dt2 = ds.Tables[1];
                //DataTable dt3 = ds.Tables[2];

                List<string> result = new List<string>();
                //List<string> result1 = new List<string>();
                //List<string> result2 = new List<string>();

                foreach (DataRow rows in dt1.Rows)
                {
                    string r = Convert.ToString(rows["idFabric_support"]);
                    result.Add(r);
                }

                //foreach (DataRow rows in dt2.Rows)
                //{
                //    string r = Convert.ToString(rows["ResultValue"]);
                //    result1.Add(r);
                //}

                //foreach (DataRow rows in dt3.Rows)
                //{
                //    string r = Convert.ToString(rows["ResultValue"]);
                //    result2.Add(r);
                //}
                //result.AddRange(result1);
                //result.AddRange(result2);

                cnx.Close();

                return result;
            }
        }

        //public List<OrderDetail> GetOrdersForExportToExcel(string SearchText, int Client, int Department, int SupplyType, int ModeType, int PackingType, int Terms, DateTime FromDate, DateTime ToDate, short DateType)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();

        //        SqlDataReader reader;
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "sp_export_to_excel_get_order_data";
        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param;

        //        param = new SqlParameter("@SearchText", SqlDbType.VarChar);
        //        param.Value = SearchText;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Client", SqlDbType.Int);
        //        param.Value = Client;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Department", SqlDbType.Int);
        //        param.Value = Department;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@SupplyType", SqlDbType.Int);
        //        param.Value = SupplyType;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ModeType", SqlDbType.Int);
        //        param.Value = ModeType;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@PackingType", SqlDbType.Int);
        //        param.Value = PackingType;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@Terms", SqlDbType.Int);
        //        param.Value = Terms;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@ToDate", SqlDbType.DateTime);
        //        if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
        //       // if (ToDate == DateTime.MinValue)
        //            param.Value = DBNull.Value;
        //        else
        //            param.Value = ToDate;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@FromDate", SqlDbType.DateTime);
        //        if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
        //        //if (FromDate == DateTime.MinValue)
        //            param.Value = DBNull.Value;
        //        else
        //            param.Value = FromDate;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@DateType", SqlDbType.Int);
        //        param.Value = DateType;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);


        //        reader = cmd.ExecuteReader();

        //        List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

        //        int result;
        //        bool success;

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                OrderDetail orderDetail = new OrderDetail();
        //                orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
        //                orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
        //                orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
        //                orderDetail.Description = (reader["OrderDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OrderDescription"]);

        //               // int shippingQty = 0;
        //                orderDetail.shippingQty = reader["ShippingQty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ShippingQty"]);
        //               // orderDetail.Quantity = (shippingQty != 0) ? shippingQty : (reader["orderQty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["orderQty"]));
        //                orderDetail.Quantity = reader["orderQty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["orderQty"]);
        //                orderDetail.iKandiPrice = (reader["iKandiPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["iKandiPrice"]);
        //                orderDetail.Mode = (reader["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Mode"]);
        //                orderDetail.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);

        //                orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
        //                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
        //                orderDetail.WeekToEx = Convert.ToInt32(reader["WeekToEx"]);
        //                orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
        //                orderDetail.WeeksToDC = Convert.ToInt32(reader["WeeksToDC"]);
        //                orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
        //                orderDetail.STCUnallocated = (reader["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(reader["STCUnallocated"]) : DateTime.MinValue;
        //                orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
        //                orderDetail.CuttingETA = (reader["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["CuttingETA"]) : DateTime.MinValue;
        //                orderDetail.PackingETA = (reader["PackingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["PackingETA"]) : DateTime.MinValue;
        //                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
        //                orderDetail.BulkTarget = (reader["BulkTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkTarget"]) : DateTime.MinValue;
        //                orderDetail.LabDipTarget = (reader["LabDipTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["LabDipTarget"]) : DateTime.MinValue;
        //                orderDetail.BulkApprovalTarget = (reader["BulkApprovalTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkApprovalTarget"]) : DateTime.MinValue;
        //                orderDetail.InvoiceDate = (reader["InvoiceDate"] != DBNull.Value) ? Convert.ToDateTime(reader["InvoiceDate"]) : DateTime.MinValue;
        //                orderDetail.AWBDate = (reader["ExpectedDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedDispatchDate"]) : DateTime.MinValue;

        //                orderDetail.ParentOrder = new Order();
        //                orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
        //                orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
        //                orderDetail.ParentOrder.BiplPrice = (reader["BiplPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BiplPrice"]);

        //                orderDetail.ParentOrder.Costing = new Costing();
        //                orderDetail.ParentOrder.Costing.ConvertTo = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);

        //                orderDetail.ParentOrder.Style = new Style();
        //                orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
        //                orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);
        //                orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
        //                orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
        //                orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

        //                orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
        //                orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
        //                orderDetail.ParentOrder.Style.cdept.DeptID = (reader["ClientDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientDepartmentID"]) : 0;

        //                orderDetail.ParentOrder.Style.client = new Client();
        //                orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(reader["ClientID"]);

        //                orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
        //                orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
        //                orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
        //                orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);

        //                success = Int32.TryParse(orderDetail.Fabric1Details, out result);                        
        //                if (success.Equals(true))
        //                {
        //                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
        //                    success = false;
        //                    result = 0;
        //                }
        //                success = Int32.TryParse(orderDetail.Fabric2Details, out result);
        //                if (success.Equals(true))
        //                {
        //                    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
        //                    success = false;
        //                    result = 0;
        //                }
        //                success = Int32.TryParse(orderDetail.Fabric3Details, out result);
        //                if (success.Equals(true))
        //                {
        //                    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
        //                    success = false;
        //                    result = 0;
        //                }
        //                success = Int32.TryParse(orderDetail.Fabric4Details, out result);
        //                if (success.Equals(true))
        //                {
        //                    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
        //                    success = false;
        //                    result = 0;
        //                }

        //                orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
        //                orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
        //                orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
        //                orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

        //                // Just storing Invoice Number in this field, else we have to unncessary create new fields
        //                orderDetail.SecondPartnerName = (reader["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["InvoiceNumber"]);
        //                // Just storing Invoice Rate in this field, else we have to unncessary create new fields
        //                orderDetail.FirstPartnerName = (reader["Rate"] == DBNull.Value) ? "0" : Convert.ToString(reader["Rate"]);


        //                orderDetailCollection.Add(orderDetail);
        //            }
        //        }
        //        cnx.Close();
        //        return orderDetailCollection;
        //    }
        //}
        //adbhishek
        public List<OrderDetail> GetOrdersForExportToExcel_new(string SearchText, string year, DateTime FromDate, DateTime ToDate, int clientid, int unitid, short DateType, int StatusMode, int StatusModeSequence, int BuyingHouseId, int Ordertype)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_sp_export_to_excel_get_order_data";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Years", SqlDbType.VarChar);
                param.Value = year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
                    //if (FromDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = FromDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
                    // if (ToDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = ToDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = clientid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = unitid;
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
                param.Value = BuyingHouseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderTypes", SqlDbType.Int);
                param.Value = Ordertype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        //orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                        orderDetail.CompanyName = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        //orderDetail.Description = (reader["OrderDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OrderDescription"]);

                        // int shippingQty = 0;
                        //orderDetail.shippingQty = reader["ShippingQty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ShippingQty"]);
                        // orderDetail.Quantity = (shippingQty != 0) ? shippingQty : (reader["orderQty"] == DBNull.Value ? 0 : Convert.ToInt32(reader["orderQty"]));
                        orderDetail.Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Quantity"]);
                        orderDetail.iKandiPrice = (reader["iKandiPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["iKandiPrice"]);
                        // orderDetail.Mode = (reader["Delivery_Mode"] == DBNull.Value) ? 0 : Convert.ToString(reader["Delivery_Mode"]);
                        orderDetail.ModeName = (reader["Delivery_Mode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Delivery_Mode"]);
                        orderDetail.Bipl_amount = (reader["BIPL_Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BIPL_Amount"]);
                        orderDetail.ikandi_amount = (reader["iKandi_Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["iKandi_Amount"]);
                        orderDetail.WeekCount = (reader["WeekCount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["WeekCount"]);
                        orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                        orderDetail.Weeklyikandi_amount = (reader["WeekTotalikandiamount"] == DBNull.Value) ? "" : Convert.ToString(reader["WeekTotalikandiamount"]);
                        //orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                        //orderDetail.WeekToEx = Convert.ToInt32(reader["WeekToEx"]);
                        orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                        //orderDetail.WeeksToDC = Convert.ToInt32(reader["WeeksToDC"]);
                        //orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                        //orderDetail.STCUnallocated = (reader["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(reader["STCUnallocated"]) : DateTime.MinValue;
                        //orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                        //orderDetail.CuttingETA = (reader["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["CuttingETA"]) : DateTime.MinValue;
                        //orderDetail.PackingETA = (reader["PackingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["PackingETA"]) : DateTime.MinValue;
                        //orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                        //orderDetail.BulkTarget = (reader["BulkTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkTarget"]) : DateTime.MinValue;
                        //orderDetail.LabDipTarget = (reader["LabDipTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["LabDipTarget"]) : DateTime.MinValue;
                        //orderDetail.BulkApprovalTarget = (reader["BulkApprovalTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkApprovalTarget"]) : DateTime.MinValue;
                        //orderDetail.InvoiceDate = (reader["InvoiceDate"] != DBNull.Value) ? Convert.ToDateTime(reader["InvoiceDate"]) : DateTime.MinValue;
                        //orderDetail.AWBDate = (reader["ExpectedDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedDispatchDate"]) : DateTime.MinValue;
                        orderDetail.DeliveryType = (reader["DeliveryType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DeliveryType"]);
                        orderDetail.Adjustment_Amount = (reader["Adjustment_Amount"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Adjustment_Amount"]);
                       

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                        orderDetail.ParentOrder.BiplPrice = (reader["BiplPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BiplPrice"]);

                        //orderDetail.ParentOrder.Costing = new Costing();
                        //orderDetail.ParentOrder.Costing.ConvertTo = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        //orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);
                        //orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        //orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                        //orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

                        orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                        orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);

                        
                        //orderDetail.ParentOrder.Style.cdept.DeptID = (reader["ClientDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientDepartmentID"]) : 0;

                        //orderDetail.ParentOrder.Style.client = new Client();
                        //orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(reader["ClientID"]);

                        //orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                        //orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                        //orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                        //orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);

                        //success = Int32.TryParse(orderDetail.Fabric1Details, out result);
                        //if (success.Equals(true))
                        //{
                        //    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                        //    success = false;
                        //    result = 0;
                        //}
                        //success = Int32.TryParse(orderDetail.Fabric2Details, out result);
                        //if (success.Equals(true))
                        //{
                        //    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                        //    success = false;
                        //    result = 0;
                        //}
                        //success = Int32.TryParse(orderDetail.Fabric3Details, out result);
                        //if (success.Equals(true))
                        //{
                        //    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                        //    success = false;
                        //    result = 0;
                        //}
                        //success = Int32.TryParse(orderDetail.Fabric4Details, out result);
                        //if (success.Equals(true))
                        //{
                        //    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                        //    success = false;
                        //    result = 0;
                        //}

                        //orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                        //orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                        //orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                        //orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                        // Just storing Invoice Number in this field, else we have to unncessary create new fields
                        //orderDetail.SecondPartnerName = (reader["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["InvoiceNumber"]);
                        //// Just storing Invoice Rate in this field, else we have to unncessary create new fields
                        //orderDetail.FirstPartnerName = (reader["Rate"] == DBNull.Value) ? "0" : Convert.ToString(reader["Rate"]);


                        orderDetailCollection.Add(orderDetail);
                    }
                }
                cnx.Close();
                return orderDetailCollection;
            }
        }
        public List<iKandi.Common.ProductionUnit> GetAllUnits()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_unit_get_all_units";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                List<iKandi.Common.ProductionUnit> units = new List<iKandi.Common.ProductionUnit>();
                while (reader.Read())
                {
                    ProductionUnit unit = new ProductionUnit();
                    unit.FactoryCode = reader["Name"].ToString();
                    unit.ProductionUnitId = Convert.ToInt32(reader["Id"]);
                    units.Add(unit);
                }

                return units;
            }
        }

        public List<iKandi.Common.Print> GetAllPrintTypes()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_print_type_get_all_print_types";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                List<iKandi.Common.Print> printTypes = new List<iKandi.Common.Print>();
                while (reader.Read())
                {
                    Print printType = new Print();
                    printType.PrintType = reader["Type"].ToString();
                    printType.PrintTypeID = Convert.ToInt32(reader["Id"]);
                    printTypes.Add(printType);
                }

                return printTypes;
            }
        }



        public DataTable GetFATasksDAL(int iDesignationId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_GetFATasks";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DesignationId", SqlDbType.Int);
                param.Value = iDesignationId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
                cnx.Close();
                return dt1;
            }
        }



        public DataSet GetFATasks(int iDesignationId)
        {
            //using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            //{
            //    cnx.Open();

            //    SqlCommand cmd;
            //    string cmdText;
            //    cmdText = "sp_GetFATasks";
            //    cmd = new SqlCommand(cmdText, cnx);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            //    SqlParameter param;

            //    param = new SqlParameter("@DesignationId", SqlDbType.Int);
            //    param.Value = iDesignationId;
            //    param.Direction = ParameterDirection.Input;
            //    cmd.Parameters.Add(param);

            //    DataSet ds = new DataSet();
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    adapter.Fill(ds);
            //    cnx.Close();
            //    return ds;
            //}
            return null;
        }

        //Gajendra New Costing

        public List<string> GetFabricList_ByTradeName(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> result = new List<string>();
                SqlCommand cmd;
                string cmdText;
                cnx.Open();
                cmdText = "GetFabricList_ByTradeName";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                foreach (DataRow rows in dt.Rows)
                {
                    string r = Convert.ToString(rows["FabricDetails"]);
                    result.Add(r);
                }
                cnx.Close();

                return result;
            }
        }
        //abhishek user search by deptid
        public List<string> GetUserNameByDeptID(string searchValue, int Deptid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> result = new List<string>();
                SqlCommand cmd;
                string cmdText;
                cnx.Open();
                cmdText = "sp_user_get_user_information_by_DeptID";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = Deptid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                foreach (DataRow rows in dt.Rows)
                {
                    string r = Convert.ToString(rows["Names"]);
                    result.Add(r);
                }
                cnx.Close();

                return result;
            }
        }
        //abhishek 26/12/2017
        //public List<LinePlanningStyle> SuggestForAutoCompleteByunitidLine(string searchValue, int unitid, int LineNumber, string status, string StylePrefix)
        //{
        //  List<LinePlanningStyle> objStyle = new List<LinePlanningStyle>();
        //  try
        //  {
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //      cnx.Open();


        //      SqlCommand cmd;
        //      string cmdText;
        //      cmdText = "Usp_FillFactorySpecificLinePlanning_autoComplete";
        //      cmd = new SqlCommand(cmdText, cnx);
        //      cmd.CommandType = CommandType.StoredProcedure;
        //      cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //      SqlParameter param = new SqlParameter("@StyleSearchText", SqlDbType.VarChar);
        //      param.Value = searchValue;
        //      param.Direction = ParameterDirection.Input;
        //      cmd.Parameters.Add(param);              

        //      param = new SqlParameter("@UnitId", SqlDbType.Int);
        //      param.Value = unitid;
        //      param.Direction = ParameterDirection.Input;
        //      cmd.Parameters.Add(param);

        //      param = new SqlParameter("@LineNo", SqlDbType.Int);
        //      param.Value = LineNumber;
        //      param.Direction = ParameterDirection.Input;
        //      cmd.Parameters.Add(param);

        //      param = new SqlParameter("@Status", SqlDbType.VarChar);
        //      param.Value = status;
        //      param.Direction = ParameterDirection.Input;
        //      cmd.Parameters.Add(param);

        //      param = new SqlParameter("@StylePrefix", SqlDbType.VarChar);
        //      param.Value = StylePrefix;
        //      param.Direction = ParameterDirection.Input;
        //      cmd.Parameters.Add(param);

        //      SqlDataReader reader;
        //      reader = cmd.ExecuteReader();

        //      while (reader.Read())
        //      {

        //        LinePlanningStyle objstylenew = new LinePlanningStyle();
        //        objstylenew.StyleCode = reader["StyleCode"].ToString();
        //        objStyle.Add(objstylenew);
        //      }
        //      cnx.Close();
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    string str = ex.Message;
        //  }         
        //  return objStyle;
        //}
        public List<string> SuggestForAutoCompleteByunitidLine(string searchValue, int unitid, int LineNumber, string status)
        {
            List<string> result = new List<string>();
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_FillFactorySpecificLinePlanning_autoComplete";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@StyleSearchText", SqlDbType.VarChar);
                    param.Value = searchValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = unitid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LineNo", SqlDbType.Int);
                    param.Value = LineNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.VarChar);
                    param.Value = status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@StylePrefix", SqlDbType.VarChar);
                    //param.Value = StylePrefix;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["StyleCode"]));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return result;

        }

        public int check_for_auto_complete(string searchValue, string searchContext)
        {
            int iReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;
                cmdText = "sp_check_for_auto_complete";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("searchContext", SqlDbType.VarChar);
                param.Value = searchContext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                iReturn = Convert.ToInt32(cmd.ExecuteScalar());


                return iReturn;
            }
        }
        public List<string> GetProcessList_ByName(string searchValue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> result = new List<string>();
                SqlCommand cmd;
                string cmdText;
                cnx.Open();
                cmdText = "GetProcessListBy_Name";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SerachItem", SqlDbType.NVarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                foreach (DataRow rows in dt.Rows)
                {

                    string r = Convert.ToString(rows["ProcessDetails"]);
                    result.Add(r);
                }
                cnx.Close();
                return result;
            }
        }
        //public List<string> GetFabricList_ByTradeName_New(string searchValue, string Print_Details, int PrintCategory)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        List<string> result = new List<string>();
        //        SqlCommand cmd;
        //        string cmdText;
        //        cnx.Open();
        //        cmdText = "Usp_GetFabric_Populate";

        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param = new SqlParameter("searchValue", SqlDbType.VarChar);
        //        param.Value = searchValue;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        DataTable dt = new DataTable();
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dt);
        //        if (dt.Rows.Count > 1)
        //        {

        //            foreach (DataRow rows in dt.Rows)
        //            {
        //                string r = Convert.ToString(rows["FabricDetails"]);
        //                result.Add(r);
        //            }
        //        }
        //        cnx.Close();
        //        return result;
        //    }
        //}
        public List<string> GetFabricList_ByTradeName_New(string searchValue, string Print_Details, int PrintCategory, string StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> result = new List<string>();
                SqlCommand cmd;
                string cmdText;
                cnx.Open();
                if (Print_Details.Substring(Print_Details.Length - 2, 2) == "##")
                    cmdText = "Usp_GetFabric_Populate";
                else
                    cmdText = "Usp_GetFabric_Populate_Rate_From_PO";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                if (cmdText != "Usp_GetFabric_Populate")
                {
                    param = new SqlParameter("@Print_Details", SqlDbType.VarChar);
                    if (PrintCategory == 1 || PrintCategory == 2)
                    {
                        string[] Print = Print_Details.Split(new[] { " --- " }, StringSplitOptions.None);
                        if (Print.Length > 1)
                        {
                            param.Value = Print[1].Trim();

                        }

                    }
                    else
                    {
                        param.Value = Print_Details;
                    }

                    //param.Value = Print_Details;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                    param.Value = PrintCategory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierFabric", SqlDbType.VarChar);
                    if (PrintCategory == 1 || PrintCategory == 2 || PrintCategory == 0)
                    {
                        param.Value = Print_Details.Replace(" --- ", "-");
                    }
                    //if (fabtype == "1" || fabtype == "2")
                    //{
                    //    string[] Print = print.Split(new[] { " --- " }, StringSplitOptions.None);
                    //    if (Print.Length > 1)
                    //    {
                    //        param.Value = Print[0].Trim();

                    //    }

                    //}
                    //else
                    //{
                    //    param.Value = print;
                    //}
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }
                else
                {
                    param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                    param.Value = PrintCategory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }

                param = new SqlParameter("@Styleid", SqlDbType.VarChar);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count > 1)
                {
                    foreach (DataRow rows in dt.Rows)
                    {
                        string r = Convert.ToString(rows["FabricDetails"]);
                        result.Add(r);
                    }
                }
                if (dt.Rows.Count == 1)
                {
                    foreach (DataRow rows in dt.Rows)
                    {
                        string r = Convert.ToString(rows["FabricDetails"]);
                        result.Add(r);
                    }
                    result.Add("<table cellpaddig='0' cellspacing='0' border='0' width='100%' style='table-layout:fixed;'  class='fabri_listtable' ><tr><td width='100%'>No Record Found </td> </tr></table>");
                }
                cnx.Close();
                return result;
            }
        }
        public int UpdateTaskSupportIssue(string flag, string SerialNo)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlCommand cmd;
                string cmdText;
                int Iupdte = 0;
                try
                {
                    cmdText = "Usp_SupprtIssue";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SerialNo", SqlDbType.VarChar);
                    param.Value = SerialNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cnx.Open();
                    Iupdte = cmd.ExecuteNonQuery();
                }
                catch (SqlException sql)
                {
                    sql.Message.ToString();
                }

                return Iupdte;
            }

        }
        public int UpdateStatus(string po_number, string status, string Flag)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlCommand cmd;
                string cmdText;
                int Iupdte = 0;
                try
                {
                    if (Flag == "Fabric")
                        cmdText = "Usp_PO_Cancel_Close";
                    else
                        cmdText = "Usp_PO_Acc_Cancel_Close";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                    param.Value = po_number;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = status;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cnx.Open();
                    Iupdte = cmd.ExecuteNonQuery();
                }
                catch (SqlException sql)
                {
                    sql.Message.ToString();
                }

                return Iupdte;
            }

        }

        public DateTime GetCommonRptDateOnPage()
        {
            DateTime dtCommonDate;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "usp_GetCommonRptDateOnPage";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                dtCommonDate = Convert.ToDateTime(cmd.ExecuteScalar());


                return dtCommonDate;
            }
        }
    }
}
