using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;


namespace iKandi.DAL
{
    public class FabricSamplingDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public FabricSamplingDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public bool InsertSamplingFabric(SamplingFabric Fabric)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_fabric_sampling_insert_sampling_fabric";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = Fabric.PrintNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@MillName", SqlDbType.VarChar);
                param.Value = Fabric.MillName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@MillDesignNumber", SqlDbType.VarChar);
                param.Value = Fabric.MillDesignNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = Fabric.Fabric;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@PrintType", SqlDbType.Int);
                param.Value = Fabric.PrintTypeID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@PrintTechnology", SqlDbType.Int);
                param.Value = Fabric.PrintTechnologyID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                param = new SqlParameter("@QuantityReceived", SqlDbType.Int);
                param.Value = Fabric.QuantityReceived;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@QuantityOrdered", SqlDbType.Int);
                param.Value = Fabric.QuantityOrdered;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Origin", SqlDbType.Int);
                param.Value = Fabric.OriginID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@sNew", SqlDbType.Int);
                param.Value = Fabric.IsNew;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@NumberOfScreens", SqlDbType.Int);
                param.Value = Fabric.NumberOfScreens;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostPerScreen", SqlDbType.Float);
                param.Value = Fabric.CostPerScreen;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostCurrency", SqlDbType.Int);
                param.Value = Fabric.CostCurrencyID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@sSample", SqlDbType.Int);
                param.Value = Fabric.IsSample;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = Fabric.Remarks;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateOfReceiving", SqlDbType.DateTime);
                if ((Fabric.DateOfReceiving == DateTime.MinValue) || (Fabric.DateOfReceiving == Convert.ToDateTime("1753-01-01")) || (Fabric.DateOfReceiving == Convert.ToDateTime("1900-01-01")))
               // if (Fabric.DateOfReceiving == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.DateOfReceiving;
                }
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExpectedIssueDate", SqlDbType.DateTime);
                if ((Fabric.ExpectedIssueDate == DateTime.MinValue) || (Fabric.ExpectedIssueDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ExpectedIssueDate == Convert.ToDateTime("1900-01-01")))
                //if (Fabric.ExpectedIssueDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ExpectedIssueDate;
                }                
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActualIssueDate", SqlDbType.DateTime);
              //  if (Fabric.ActualIssueDate == DateTime.MinValue)
                    if ((Fabric.ActualIssueDate == DateTime.MinValue) || (Fabric.ActualIssueDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ActualIssueDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ActualIssueDate;
                }                    
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                param = new SqlParameter("@ExpectedReceiptDate", SqlDbType.DateTime);
                if ((Fabric.ExpectedReceiptDate == DateTime.MinValue) || (Fabric.ExpectedReceiptDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ExpectedReceiptDate == Convert.ToDateTime("1900-01-01")))
               // if (Fabric.ExpectedReceiptDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ExpectedReceiptDate;
                }    
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@ActualReceiptDate", SqlDbType.DateTime);
               // if (Fabric.ActualReceiptDate == DateTime.MinValue)
                    if ((Fabric.ActualReceiptDate == DateTime.MinValue) || (Fabric.ActualReceiptDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ActualReceiptDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ActualReceiptDate;
                }                   
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = Fabric.ClientID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@Suffix", SqlDbType.VarChar);
                param.Value = Fabric.Suffix;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


            }

            return true;
        }

        /// <summary>
        /// yaten: for Solid Detail in popUp 26 Apr
        /// </summary>
        /// <param name="Fabric"></param>
        /// <returns></returns>
        public DataTable Get_All_Solid_Special(string StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_All_Solid_Special";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleId", SqlDbType.VarChar);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }





        public bool UpdateSamplingFabric(SamplingFabric Fabric)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_fabric_sampling_update_sampling_fabric";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = Fabric.SamplingFabricID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = Fabric.PrintNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@MillName", SqlDbType.VarChar);
                param.Value = Fabric.MillName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@MillDesignNumber", SqlDbType.VarChar);
                param.Value = Fabric.MillDesignNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                param.Value = Fabric.Fabric;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@PrintType", SqlDbType.Int);
                param.Value = Fabric.PrintTypeID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@PrintTechnology", SqlDbType.Int);
                param.Value = Fabric.PrintTechnologyID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                param = new SqlParameter("@QuantityReceived", SqlDbType.Int);
                param.Value = Fabric.QuantityReceived;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@QuantityOrdered", SqlDbType.Int);
                param.Value = Fabric.QuantityOrdered;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Origin", SqlDbType.Int);
                param.Value = Fabric.OriginID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@sNew", SqlDbType.Int);
                param.Value = Fabric.IsNew;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@NumberOfScreens", SqlDbType.Int);
                param.Value = Fabric.NumberOfScreens;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostPerScreen", SqlDbType.Float);
                param.Value = Fabric.CostPerScreen;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostCurrency", SqlDbType.Int);
                param.Value = Fabric.CostCurrencyID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@sSample", SqlDbType.Int);
                param.Value = Fabric.IsSample;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                //param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                //param.Value = Fabric.Remarks;
                //param.Direction = ParameterDirection.Input;

                //cmd.Parameters.Add(param);

                param = new SqlParameter("@DateOfReceiving", SqlDbType.DateTime);
                if ((Fabric.DateOfReceiving == DateTime.MinValue) || (Fabric.DateOfReceiving == Convert.ToDateTime("1753-01-01")) || (Fabric.DateOfReceiving == Convert.ToDateTime("1900-01-01")))
            //    if (Fabric.DateOfReceiving == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.DateOfReceiving;
                }
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExpectedIssueDate", SqlDbType.DateTime);
                if ((Fabric.ExpectedIssueDate == DateTime.MinValue) || (Fabric.ExpectedIssueDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ExpectedIssueDate == Convert.ToDateTime("1900-01-01")))
             //   if (Fabric.ExpectedIssueDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ExpectedIssueDate;
                }                
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ActualIssueDate", SqlDbType.DateTime);
                if ((Fabric.ActualIssueDate == DateTime.MinValue) || (Fabric.ActualIssueDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ActualIssueDate == Convert.ToDateTime("1900-01-01")))
                //if (Fabric.ActualIssueDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ActualIssueDate;
                }                
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                param = new SqlParameter("@ExpectedReceiptDate", SqlDbType.DateTime);
                if ((Fabric.ExpectedReceiptDate == DateTime.MinValue) || (Fabric.ExpectedReceiptDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ExpectedReceiptDate == Convert.ToDateTime("1900-01-01")))
             //   if (Fabric.ExpectedReceiptDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ExpectedReceiptDate;
                } 
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                param = new SqlParameter("@ActualReceiptDate", SqlDbType.DateTime);
                if ((Fabric.ActualReceiptDate == DateTime.MinValue) || (Fabric.ActualReceiptDate == Convert.ToDateTime("1753-01-01")) || (Fabric.ActualReceiptDate == Convert.ToDateTime("1900-01-01")))
               // if (Fabric.ActualReceiptDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = Fabric.ActualReceiptDate;
                } 
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = Fabric.ClientID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Suffix", SqlDbType.VarChar);
                param.Value = Fabric.Suffix;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();


            }

            return true;
        }

        public List<SamplingFabric> GetAllSamplingFabric(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, int ShowLastPage)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fabric_sampling_get_all_sampling_fabric";

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

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShowLastPage", SqlDbType.Int);
                param.Value = ShowLastPage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                List<SamplingFabric> fabrics = new List<SamplingFabric>();

                while (reader.Read())
                {
                    SamplingFabric sf = new SamplingFabric();
                    sf.ActualIssueDate = (reader["ActualIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualIssueDate"]) : DateTime.MinValue;
                    sf.ActualReceiptDate = (reader["ActualReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualReceiptDate"]) : DateTime.MinValue;
                    sf.ClientName = (reader["ClientName"] != DBNull.Value) ? Convert.ToString(reader["ClientName"]) : string.Empty;
                    sf.CostCurrency = (reader["CostCurrency"] != DBNull.Value) ? (Currency)Convert.ToInt32(reader["CostCurrency"]) : Currency.GBP;
                    sf.CostPerScreen = (reader["CostPerScreen"] != DBNull.Value) ? Convert.ToDouble(reader["CostPerScreen"]) : 0;
                    sf.DateOfReceiving = (reader["DateOfReceiving"] != DBNull.Value) ? Convert.ToDateTime(reader["DateOfReceiving"]) : DateTime.MinValue;
                    // sf.DesignerName = ((reader["DesignerFirstName"] != DBNull.Value) ? Convert.ToString(reader["DesignerFirstName"]) : string.Empty) + " " + ((reader["DesignerLastName"] != DBNull.Value) ? Convert.ToString(reader["DesignerLastName"]) : string.Empty);
                    sf.DesignerName = ((reader["DesignerName"] != DBNull.Value) ? Convert.ToString(reader["DesignerName"]) : string.Empty);
                    sf.ExpectedReceiptDate = (reader["ExpectedReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedReceiptDate"]) : DateTime.MinValue;
                    sf.ExpectedIssueDate = (reader["ExpectedIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedIssueDate"]) : DateTime.MinValue;
                    sf.Fabric = (reader["Fabric"] != DBNull.Value) ? Convert.ToString(reader["Fabric"]) : string.Empty;
                    sf.MillDesignNumber = (reader["MillDesignNumber"] != DBNull.Value) ? Convert.ToString(reader["MillDesignNumber"]) : string.Empty;
                    sf.MillName = (reader["MillName"] != DBNull.Value) ? Convert.ToString(reader["MillName"]) : string.Empty;
                    sf.NumberOfScreens = (reader["NumberOfScreens"] != DBNull.Value) ? Convert.ToInt32(reader["NumberOfScreens"]) : 0;
                    sf.Origin = (reader["Origin"] != DBNull.Value) ? (Origin)Convert.ToInt32(reader["Origin"]) : (Origin)(-1);
                    //sf.PrintNumber = (reader["PrintNumber"] != DBNull.Value) ? Convert.ToString("PRD:" + reader["PrintNumber"]) : string.Empty;
                    sf.PrintNumber = (reader["PrintNumber"] != DBNull.Value) ? Convert.ToString(reader["PrintNumber"]) : string.Empty;
                    sf.PrintID = (reader["PrintID"] != DBNull.Value) ? Convert.ToInt32(reader["PrintID"]) : -1;
                    sf.PrintTechnology = (reader["PrintTechnology"] != DBNull.Value) ? (PrintTechnology)Convert.ToInt32(reader["PrintTechnology"]) : (PrintTechnology)(-1);
                    sf.PrintType = (reader["PrintType"] != DBNull.Value) ? (PrintType)Convert.ToInt32(reader["PrintType"]) : (PrintType)(-1);
                    sf.QuantityOrdered = (reader["QuantityOrdered"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityOrdered"]) : 0;
                    sf.QuantityReceived = (reader["QuantityReceived"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityReceived"]) : 0;
                    sf.Remarks = (reader["Remarks"] != DBNull.Value) ? Convert.ToString(reader["Remarks"]) : string.Empty;
                    sf.SamplingFabricID = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : -1;
                    //sf.SamplingMerchandiserName = ((reader["SampleMerchantFirstName"] != DBNull.Value) ? Convert.ToString(reader["SampleMerchantFirstName"]) : string.Empty) + " " + ((reader["SampleMerchantLastName"] != DBNull.Value) ? Convert.ToString(reader["SampleMerchantLastName"]) : string.Empty);
                    sf.SamplingMerchandiserName = ((reader["SamplingMerchantName"] != DBNull.Value) ? Convert.ToString(reader["SamplingMerchantName"]) : string.Empty);
                    sf.IsSample = (reader["OrderDetailID"] != DBNull.Value) ? (Convert.ToInt32(reader["OrderDetailID"]) > 0 ? false : true) : true;
                    sf.IsNew = (reader["IsNew"] != DBNull.Value) ? (Convert.ToInt32(reader["IsNew"]) > 0 ? true : false) : true;
                    sf.ImageUrl = (reader["ImageUrl"] != DBNull.Value) ? Convert.ToString(reader["ImageUrl"]) : string.Empty;
                    sf.ClientID = (reader["ClientID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientID"]) : -1;
                    sf.Suffix = (reader["Suffix"] != DBNull.Value) ? Convert.ToString(reader["Suffix"]) : string.Empty;
                    fabrics.Add(sf);

                }

                reader.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);

                return fabrics;
            }
        }

        public SamplingFabric GetSamplingFabricByID(int SamplingFabricID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fabric_sampling_get_sampling_fabric_by_id";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = SamplingFabricID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                SamplingFabric sf = new SamplingFabric();

                if (reader.Read())
                {

                    sf.ActualIssueDate = (reader["ActualIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualIssueDate"]) : DateTime.MinValue;
                    sf.ActualReceiptDate = (reader["ActualReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualReceiptDate"]) : DateTime.MinValue;
                    sf.ClientName = (reader["ClientName"] != DBNull.Value) ? Convert.ToString(reader["ClientName"]) : string.Empty;
                    sf.CostCurrency = (reader["CostCurrency"] != DBNull.Value) ? (Currency)Convert.ToInt32(reader["CostCurrency"]) : Currency.GBP;
                    sf.CostPerScreen = (reader["CostPerScreen"] != DBNull.Value) ? Convert.ToDouble(reader["CostPerScreen"]) : 0;
                    sf.DateOfReceiving = (reader["DateOfReceiving"] != DBNull.Value) ? Convert.ToDateTime(reader["DateOfReceiving"]) : DateTime.MinValue;
                    sf.DesignerName = ((reader["DesignerFirstName"] != DBNull.Value) ? Convert.ToString(reader["DesignerFirstName"]) : string.Empty) + " " + ((reader["DesignerLastName"] != DBNull.Value) ? Convert.ToString(reader["DesignerLastName"]) : string.Empty);
                    sf.ExpectedReceiptDate = (reader["ExpectedReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedReceiptDate"]) : DateTime.MinValue;
                    sf.ExpectedIssueDate = (reader["ExpectedIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedIssueDate"]) : DateTime.MinValue;
                    sf.Fabric = (reader["Fabric"] != DBNull.Value) ? Convert.ToString(reader["Fabric"]) : string.Empty;
                    sf.MillDesignNumber = (reader["MillDesignNumber"] != DBNull.Value) ? Convert.ToString(reader["MillDesignNumber"]) : string.Empty;
                    sf.MillName = (reader["MillName"] != DBNull.Value) ? Convert.ToString(reader["MillName"]) : string.Empty;
                    sf.NumberOfScreens = (reader["NumberOfScreens"] != DBNull.Value) ? Convert.ToInt32(reader["NumberOfScreens"]) : 0;
                    sf.Origin = (reader["Origin"] != DBNull.Value) ? (Origin)Convert.ToInt32(reader["Origin"]) : (Origin)(-1);
                    sf.PrintNumber = (reader["PrintNumber"] != DBNull.Value) ? Convert.ToString(reader["PrintNumber"]) : string.Empty;
                    sf.PrintID = (reader["PrintID"] != DBNull.Value) ? Convert.ToInt32(reader["PrintID"]) : -1;
                    sf.PrintTechnology = (reader["PrintTechnology"] != DBNull.Value) ? (PrintTechnology)Convert.ToInt32(reader["PrintTechnology"]) : (PrintTechnology)(-1);
                    sf.PrintType = (reader["PrintType"] != DBNull.Value) ? (PrintType)Convert.ToInt32(reader["PrintType"]) : (PrintType)(-1);
                    sf.QuantityOrdered = (reader["QuantityOrdered"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityOrdered"]) : 0;
                    sf.QuantityReceived = (reader["QuantityReceived"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityReceived"]) : 0;
                    sf.Remarks = (reader["Remarks"] != DBNull.Value) ? Convert.ToString(reader["Remarks"]) : string.Empty;
                    sf.SamplingFabricID = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : -1;
                    sf.SamplingMerchandiserName = ((reader["SampleMerchantFirstName"] != DBNull.Value) ? Convert.ToString(reader["SampleMerchantFirstName"]) : string.Empty) + " " + ((reader["SampleMerchantLastName"] != DBNull.Value) ? Convert.ToString(reader["SampleMerchantLastName"]) : string.Empty);

                }

                return sf;
            }
        }

        public List<SamplingFabric> GetSamplingFabricByPrintNumber(string PrintNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fabric_sampling_get_sampling_fabric_by_print_number";
               // cmdText = "sp_get_style_fabric_prints";
            
                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
               
                reader = cmd.ExecuteReader();

                List<SamplingFabric> fabrics = new List<SamplingFabric>();

                while (reader.Read())
                {
                    SamplingFabric sf = new SamplingFabric();

                    sf.ActualIssueDate = (reader["ActualIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualIssueDate"]) : DateTime.MinValue;
                    sf.ActualReceiptDate = (reader["ActualReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualReceiptDate"]) : DateTime.MinValue;
                    sf.ClientName = (reader["ClientName"] != DBNull.Value) ? Convert.ToString(reader["ClientName"]) : string.Empty;
                    sf.CostCurrency = (reader["CostCurrency"] != DBNull.Value) ? (Currency)Convert.ToInt32(reader["CostCurrency"]) : Currency.GBP;
                    sf.CostPerScreen = (reader["CostPerScreen"] != DBNull.Value) ? Convert.ToDouble(reader["CostPerScreen"]) : 0;
                    sf.DateOfReceiving = (reader["DateOfReceiving"] != DBNull.Value) ? Convert.ToDateTime(reader["DateOfReceiving"]) : DateTime.MinValue;
                    sf.DesignerName = ((reader["DesignerName"] != DBNull.Value) ? Convert.ToString(reader["DesignerName"]) : string.Empty);
                    sf.ExpectedReceiptDate = (reader["ExpectedReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedReceiptDate"]) : DateTime.MinValue;
                    sf.ExpectedIssueDate = (reader["ExpectedIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedIssueDate"]) : DateTime.MinValue;
                    sf.Fabric = (reader["FabricCCGSM"] != DBNull.Value) ? Convert.ToString(reader["FabricCCGSM"]) : string.Empty;
                    sf.MillDesignNumber = (reader["MillDesignNumber"] != DBNull.Value) ? Convert.ToString(reader["MillDesignNumber"]) : string.Empty;
                    sf.MillName = (reader["MillName"] != DBNull.Value) ? Convert.ToString(reader["MillName"]) : string.Empty;
                    sf.NumberOfScreens = (reader["NumberOfScreens"] != DBNull.Value) ? Convert.ToInt32(reader["NumberOfScreens"]) : 0;
                    sf.Origin = (reader["Origin"] != DBNull.Value) ? (Origin)Convert.ToInt32(reader["Origin"]) : (Origin)(-1);
                    sf.PrintNumber = (reader["PrintNumber"] != DBNull.Value) ? Convert.ToString(reader["PrintNumber"]) : string.Empty;
                    sf.PrintID = (reader["PrintID"] != DBNull.Value) ? Convert.ToInt32(reader["PrintID"]) : -1;
                    sf.PrintTechnology = (reader["PrintTechnology"] != DBNull.Value) ? (PrintTechnology)Convert.ToInt32(reader["PrintTechnology"]) : (PrintTechnology)(-1);
                    sf.PrintType = (reader["PrintType"] != DBNull.Value) ? (PrintType)Convert.ToInt32(reader["PrintType"]) : (PrintType)(-1);
                    sf.QuantityOrdered = (reader["QuantityOrdered"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityOrdered"]) : 0;
                    sf.QuantityReceived = (reader["QuantityReceived"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityReceived"]) : 0;
                    sf.Remarks = (reader["Remarks"] != DBNull.Value) ? Convert.ToString(reader["Remarks"]) : string.Empty;
                    sf.SamplingFabricID = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : -1;
                    sf.ClientID = (reader["ClientID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientID"]) : -1;
                    sf.SamplingMerchandiserName = ((reader["SamplingMerchantName"] != DBNull.Value) ? Convert.ToString(reader["SamplingMerchantName"]) : string.Empty);
                    sf.ImageUrl = (reader["ImageUrl"] != DBNull.Value) ? Convert.ToString(reader["ImageUrl"]) : string.Empty;
                    sf.Suffix = (reader["Suffix"] != DBNull.Value) ? Convert.ToString(reader["Suffix"]) : string.Empty;
                    fabrics.Add(sf);
                }

                return fabrics;
            }
        }









        public List<SamplingFabric> GetSamplingFabricByPrintNumber_And_StyleId(string PrintNumber, string iStyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                // cmdText = "sp_fabric_sampling_get_sampling_fabric_by_print_number";
                cmdText = "sp_get_style_fabric_prints";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@StyleId", SqlDbType.VarChar);
                param.Value = iStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                List<SamplingFabric> fabrics = new List<SamplingFabric>();

                while (reader.Read())
                {
                    SamplingFabric sf = new SamplingFabric();

                    sf.ActualIssueDate = (reader["ActualIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualIssueDate"]) : DateTime.MinValue;
                    sf.ActualReceiptDate = (reader["ActualReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualReceiptDate"]) : DateTime.MinValue;
                    sf.ClientName = (reader["ClientName"] != DBNull.Value) ? Convert.ToString(reader["ClientName"]) : string.Empty;
                    sf.CostCurrency = (reader["CostCurrency"] != DBNull.Value) ? (Currency)Convert.ToInt32(reader["CostCurrency"]) : Currency.GBP;
                    sf.CostPerScreen = (reader["CostPerScreen"] != DBNull.Value) ? Convert.ToDouble(reader["CostPerScreen"]) : 0;
                    sf.DateOfReceiving = (reader["DateOfReceiving"] != DBNull.Value) ? Convert.ToDateTime(reader["DateOfReceiving"]) : DateTime.MinValue;
                    sf.DesignerName = ((reader["DesignerName"] != DBNull.Value) ? Convert.ToString(reader["DesignerName"]) : string.Empty);
                    sf.ExpectedReceiptDate = (reader["ExpectedReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedReceiptDate"]) : DateTime.MinValue;
                    sf.ExpectedIssueDate = (reader["ExpectedIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedIssueDate"]) : DateTime.MinValue;
                    sf.Fabric = (reader["FabricCCGSM"] != DBNull.Value) ? Convert.ToString(reader["FabricCCGSM"]) : string.Empty;
                    sf.MillDesignNumber = (reader["MillDesignNumber"] != DBNull.Value) ? Convert.ToString(reader["MillDesignNumber"]) : string.Empty;
                    sf.MillName = (reader["MillName"] != DBNull.Value) ? Convert.ToString(reader["MillName"]) : string.Empty;
                    sf.NumberOfScreens = (reader["NumberOfScreens"] != DBNull.Value) ? Convert.ToInt32(reader["NumberOfScreens"]) : 0;
                    sf.Origin = (reader["Origin"] != DBNull.Value) ? (Origin)Convert.ToInt32(reader["Origin"]) : (Origin)(-1);
                    sf.PrintNumber = (reader["PrintNumber"] != DBNull.Value) ? Convert.ToString(reader["PrintNumber"]) : string.Empty;
                    sf.PrintRefNo = (reader["PrintRefNo"] != DBNull.Value) ? Convert.ToString(reader["PrintRefNo"]) : string.Empty;
                    sf.PrintID = (reader["PrintID"] != DBNull.Value) ? Convert.ToInt32(reader["PrintID"]) : -1;
                    sf.PrintTechnology = (reader["PrintTechnology"] != DBNull.Value) ? (PrintTechnology)Convert.ToInt32(reader["PrintTechnology"]) : (PrintTechnology)(-1);
                    sf.PrintType = (reader["PrintType"] != DBNull.Value) ? (PrintType)Convert.ToInt32(reader["PrintType"]) : (PrintType)(-1);
                    sf.QuantityOrdered = (reader["QuantityOrdered"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityOrdered"]) : 0;
                    sf.QuantityReceived = (reader["QuantityReceived"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityReceived"]) : 0;
                    sf.Remarks = (reader["Remarks"] != DBNull.Value) ? Convert.ToString(reader["Remarks"]) : string.Empty;
                    sf.SamplingFabricID = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : -1;
                    sf.ClientID = (reader["ClientID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientID"]) : -1;
                    sf.SamplingMerchandiserName = ((reader["SamplingMerchantName"] != DBNull.Value) ? Convert.ToString(reader["SamplingMerchantName"]) : string.Empty);
                    sf.ImageUrl = (reader["ImageUrl"] != DBNull.Value) ? Convert.ToString(reader["ImageUrl"]) : string.Empty;
                    sf.Suffix = (reader["Suffix"] != DBNull.Value) ? Convert.ToString(reader["Suffix"]) : string.Empty;
                    fabrics.Add(sf);
                }

                return fabrics;
            }
        }














        public List<SamplingFabric> GetSamplingFabricByStyleNumber(string StyleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_fabric_sampling_get_sampling_fabric_by_style_number";

                cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<SamplingFabric> fabrics = new List<SamplingFabric>();

                while (reader.Read())
                {
                    SamplingFabric sf = new SamplingFabric();

                    sf.ActualIssueDate = (reader["ActualIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualIssueDate"]) : DateTime.MinValue;
                    sf.ActualReceiptDate = (reader["ActualReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ActualReceiptDate"]) : DateTime.MinValue;
                    sf.ClientName = (reader["ClientName"] != DBNull.Value) ? Convert.ToString(reader["ClientName"]) : string.Empty;
                    sf.CostCurrency = (reader["CostCurrency"] != DBNull.Value) ? (Currency)Convert.ToInt32(reader["CostCurrency"]) : Currency.GBP;
                    sf.CostPerScreen = (reader["CostPerScreen"] != DBNull.Value) ? Convert.ToDouble(reader["CostPerScreen"]) : 0;
                    sf.DateOfReceiving = (reader["DateOfReceiving"] != DBNull.Value) ? Convert.ToDateTime(reader["DateOfReceiving"]) : DateTime.MinValue;
                    sf.DesignerName = ((reader["DesignerFirstName"] != DBNull.Value) ? Convert.ToString(reader["DesignerFirstName"]) : string.Empty) + " " + ((reader["DesignerLastName"] != DBNull.Value) ? Convert.ToString(reader["DesignerLastName"]) : string.Empty);
                    sf.ExpectedReceiptDate = (reader["ExpectedReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedReceiptDate"]) : DateTime.MinValue;
                    sf.ExpectedIssueDate = (reader["ExpectedIssueDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ExpectedIssueDate"]) : DateTime.MinValue;
                    sf.Fabric = (reader["FabricCCGSM"] != DBNull.Value) ? Convert.ToString(reader["FabricCCGSM"]) : string.Empty;
                    sf.MillDesignNumber = (reader["MillDesignNumber"] != DBNull.Value) ? Convert.ToString(reader["MillDesignNumber"]) : string.Empty;
                    sf.MillName = (reader["MillName"] != DBNull.Value) ? Convert.ToString(reader["MillName"]) : string.Empty;
                    sf.NumberOfScreens = (reader["NumberOfScreens"] != DBNull.Value) ? Convert.ToInt32(reader["NumberOfScreens"]) : 0;
                    sf.Origin = (reader["Origin"] != DBNull.Value) ? (Origin)Convert.ToInt32(reader["Origin"]) : (Origin)(-1);
                    sf.PrintNumber = (reader["PrintNumber"] != DBNull.Value) ? Convert.ToString(reader["PrintNumber"]) : string.Empty;
                    sf.PrintRefNo = (reader["PrintRefNo"] != DBNull.Value) ? Convert.ToString(reader["PrintRefNo"]) : string.Empty;
                    sf.PrintID = (reader["PrintID"] != DBNull.Value) ? Convert.ToInt32(reader["PrintID"]) : -1;
                    sf.PrintTechnology = (reader["PrintTechnology"] != DBNull.Value) ? (PrintTechnology)Convert.ToInt32(reader["PrintTechnology"]) : (PrintTechnology)(-1);
                    sf.PrintType = (reader["PrintType"] != DBNull.Value) ? (PrintType)Convert.ToInt32(reader["PrintType"]) : (PrintType)(-1);
                    sf.QuantityOrdered = (reader["QuantityOrdered"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityOrdered"]) : 0;
                    sf.QuantityReceived = (reader["QuantityReceived"] != DBNull.Value) ? Convert.ToInt32(reader["QuantityReceived"]) : 0;
                    sf.Remarks = (reader["Remarks"] != DBNull.Value) ? Convert.ToString(reader["Remarks"]) : string.Empty;
                    sf.SamplingFabricID = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : -1;
                    sf.SamplingMerchandiserName = ((reader["SampleMerchantFirstName"] != DBNull.Value) ? Convert.ToString(reader["SampleMerchantFirstName"]) : string.Empty) + " " + ((reader["SampleMerchantLastName"] != DBNull.Value) ? Convert.ToString(reader["SampleMerchantLastName"]) : string.Empty);

                    fabrics.Add(sf);
                }

                return fabrics;
            }
        }

    }
}
