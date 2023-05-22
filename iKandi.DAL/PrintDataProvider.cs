using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class PrintDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public PrintDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<Print> GetAllPrints(int PageSize, int PageIndex, out int TotalRowCount, int ClientId, string SearchText, int PrintTypeID)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_prints_get_all_prints_with_paging";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
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


                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintTypeID", SqlDbType.Int);
                param.Value = PrintTypeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Print> prints = new List<Print>();

                while (reader.Read())
                {
                    Print print = new Print();

                    print.PrintID = Convert.ToInt32(reader["Id"]);
                    print.PrintNumber = (reader["PrintNumber"]).ToString();
                    print.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                    print.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                    print.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                    print.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerFirstName"])) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerLastName"]));
                    print.PrintCompany = (reader["PrintCompany"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompany"]);
                    print.PrintCompanyReference = (reader["PrintCompanyReference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompanyReference"]);
                    print.PrintCost = (reader["PrintCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PrintCost"]);
                    print.PrintCostCurrency = (reader["PrintCostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["PrintCostCurrency"]);
                    print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    print.FabricQuality = (reader["FabricQuality"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricQuality"]);
                    print.Status = (Convert.ToBoolean(reader["IsSold"]) == true) ? PrintStatus.Sold : PrintStatus.Unsold;
                    print.PrintType = (reader["PrintType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintType"]);
                    prints.Add(print);
                }


                reader.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return prints;
            }
        }

        public List<Print> SearchShowroomPrints(int PageSize, int PageIndex, out int TotalRowCount, string ClientIds, string SearchText, string PrintTypeIDs, DateTime StartDate, DateTime EndDate, int SoldStatus)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_virtualshowroom_prints_showroom2";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
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

                param = new SqlParameter("@ClientIDs", SqlDbType.VarChar);
                param.Value = ClientIds;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintTypeIDs", SqlDbType.VarChar);
                param.Value = PrintTypeIDs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                // if (StartDate == DateTime.MinValue)
                if ((StartDate == DateTime.MinValue) || (StartDate == Convert.ToDateTime("1753-01-01")) || (StartDate == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                //  if (EndDate == DateTime.MinValue)
                if ((EndDate == DateTime.MinValue) || (EndDate == Convert.ToDateTime("1753-01-01")) || (EndDate == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = EndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sSoldStatus", SqlDbType.Int);
                param.Value = SoldStatus;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataReader reader = cmd.ExecuteReader();

                List<Print> prints = new List<Print>();

                while (reader.Read())
                {
                    Print print = new Print();

                    print.PrintID = Convert.ToInt32(reader["Id"]);
                    print.PrintNumber = (reader["PrintNumber"]).ToString();
                    print.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                    print.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                    print.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                    print.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerFirstName"])) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerLastName"]));
                    print.PrintCompany = (reader["PrintCompany"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompany"]);
                    print.PrintCompanyReference = (reader["PrintCompanyReference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompanyReference"]);
                    print.PrintCost = (reader["PrintCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PrintCost"]);
                    print.PrintCostCurrency = (reader["PrintCostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["PrintCostCurrency"]);
                    print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    print.FabricQuality = (reader["FabricQuality"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricQuality"]);
                    print.Status = (Convert.ToBoolean(reader["IsSold"]) == true) ? PrintStatus.Sold : PrintStatus.Unsold;
                    print.PrintType = (reader["PrintType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintType"]);
                    prints.Add(print);
                }

                reader.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return prints;
            }
        }

        public List<Print> GetShowroomPrintDetails(string PrintIDs)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_styles_get_all_showroom_prints_detail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@PrintIDs", SqlDbType.VarChar);
                param.Value = PrintIDs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataReader reader = cmd.ExecuteReader();

                List<Print> prints = new List<Print>();

                while (reader.Read())
                {
                    Print print = new Print();

                    print.PrintID = Convert.ToInt32(reader["Id"]);
                    print.PrintNumber = (reader["PrintNumber"]).ToString();
                    print.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                    print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    print.Status = (Convert.ToBoolean(reader["IsSold"]) == true) ? PrintStatus.Sold : PrintStatus.Unsold;

                    prints.Add(print);
                }

                reader.Close();

                return prints;
            }
        }

        public bool InsertPrint(Print FabricPrint)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_prints_insert_print";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter outParam;
                outParam = new SqlParameter("@d", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.VarChar);
                param.Value = FabricPrint.Description;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = FabricPrint.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = FabricPrint.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = FabricPrint.DesignerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCompany", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintCompany;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCompanyReference", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintCompanyReference;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCost", SqlDbType.Float);
                param.Value = FabricPrint.PrintCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DatePurchased", SqlDbType.DateTime);
                param.Value = FabricPrint.DatePurchased;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCostCurrency", SqlDbType.Int);
                param.Value = (int)FabricPrint.PrintCostCurrency;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@mageUrl", SqlDbType.VarChar);
                param.Value = FabricPrint.ImageUrl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Devloped_mageUrl", SqlDbType.NVarChar);
                param.Value = FabricPrint.DevelopedImageUrl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FabricQuality", SqlDbType.VarChar);
                param.Value = FabricPrint.FabricQuality;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintTypeID", SqlDbType.Int);
                param.Value = FabricPrint.PrintTypeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                param.Value = FabricPrint.PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintRefNo", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintRefNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDepartmentID", SqlDbType.Int);
                param.Value = FabricPrint.ParentDeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();

                int printID = Convert.ToInt32(outParam.Value);

                cnx.Close();
            }

            return true;
        }

        public Print GetPrintById(int PrintId)
        {
            //System.Diagnostics.Debugger.Break();
            Print print = new Print();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_prints_get_print_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = PrintId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        print.PrintID = Convert.ToInt32(reader["Id"]);
                        print.PrintNumber = Convert.ToString(reader["PrintNumber"]);
                        print.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                        print.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                        print.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                        //print.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerFirstName"])) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerLastName"]));
                        print.PrintCompany = (reader["PrintCompany"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompany"]);
                        print.PrintCompanyReference = (reader["PrintCompanyReference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompanyReference"]);
                        print.PrintCost = (reader["PrintCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PrintCost"]);
                        print.PrintCostCurrency = (reader["PrintCostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["PrintCostCurrency"]);
                        print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                        print.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);
                        print.DesignerID = (reader["DesignerID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DesignerID"]);
                        print.FabricQuality = (reader["FabricQuality"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricQuality"]);
                        print.PrintTypeID = (reader["PrintType"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PrintType"]);
                        print.PrintCategory = (reader["PrintCategory"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PrintCategory"]);
                        print.PrintRefNo = (reader["PrintRefNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintRefNo"]);
                        print.DevelopedImageUrl = (reader["DevelopedImageURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DevelopedImageURL"]);
                        print.DeptID = (reader["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentID"]);
                        print.ParentDeptID = (reader["ParentDepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ParentDepartmentID"]);
                    }
                }
            }
            return print;
        }

        public Print GetPrintByPrintNumber(string PrintNumber)
        {
            Print print = new Print();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_prints_get_print_detail_by_print_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    print.PrintID = Convert.ToInt32(reader["Id"]);
                    print.PrintNumber = Convert.ToString(reader["PrintNumber"]);
                    print.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                    print.ClientID = (reader["ClientID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientID"]) : -1;
                    print.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                    print.DesignerName = ((reader["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerName"]));
                    print.ClientName = ((reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]));
                    print.SampleMerchandiserName = ((reader["SamplingMerchantName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SamplingMerchantName"]));
                    print.PrintCompany = (reader["PrintCompany"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompany"]);
                    print.PrintCompanyReference = (reader["PrintCompanyReference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompanyReference"]);
                    print.PrintCost = (reader["PrintCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PrintCost"]);
                    print.PrintCostCurrency = (reader["PrintCostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["PrintCostCurrency"]);
                    print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    print.FabricQuality = (reader["FabricQuality"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricQuality"]);
                }
            }
            return print;
        }

        public string GetPrintImageUrlByPrintNumber(string PrintNumber)
        {
            string printImageUrl = string.Empty;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_prints_get_print_image_url_by_print_number";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object url = cmd.ExecuteScalar();

                if (null != url)
                    printImageUrl = url.ToString();
            }

            return printImageUrl;
        }



        public string GetPrintNumberByRefBDAL(string RefNumber)
        {
            string printImageUrl = string.Empty;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_PrintNumber_By_RefNo";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PrintRef", SqlDbType.VarChar);
                param.Value = RefNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                object url = cmd.ExecuteScalar();

                if (null != url)
                    printImageUrl = url.ToString();
                return printImageUrl;

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //adapter.Fill(dsorderDetail);
                //DataTable dt = dsorderDetail.Tables[0];

                //string styleNumber = Convert.ToString(dt.Rows[0][0]);
                //return styleNumber;

            }

        }





        public bool UpdatePrint(Print FabricPrint)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_prints_update_print";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.VarChar);
                param.Value = FabricPrint.Description;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = FabricPrint.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = FabricPrint.DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = FabricPrint.DesignerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCompany", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintCompany;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCompanyReference", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintCompanyReference;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCost", SqlDbType.Float);
                param.Value = FabricPrint.PrintCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DatePurchased", SqlDbType.DateTime);
                param.Value = FabricPrint.DatePurchased;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCostCurrency", SqlDbType.Int);
                param.Value = (int)FabricPrint.PrintCostCurrency;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@mageUrl", SqlDbType.VarChar);
                param.Value = FabricPrint.ImageUrl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Devloped_mageUrl", SqlDbType.NVarChar);
                param.Value = FabricPrint.DevelopedImageUrl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = FabricPrint.PrintID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQuality", SqlDbType.VarChar);
                param.Value = FabricPrint.FabricQuality;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintTypeID", SqlDbType.Int);
                param.Value = FabricPrint.PrintTypeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintCategory", SqlDbType.Int);
                param.Value = FabricPrint.PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintRefNo", SqlDbType.VarChar);
                param.Value = FabricPrint.PrintRefNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDepartmentID", SqlDbType.Int);
                param.Value = FabricPrint.ParentDeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();

                cnx.Close();

            }

            return true;

        }

        public List<Print> GetAllPrintsNo()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_prints_get_all_prints_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();
                List<Print> prints = new List<Print>();

                while (reader.Read())
                {
                    Print print = new Print();
                    print.PrintID = Convert.ToInt32(reader["Id"]);
                    print.PrintNumber = reader["PrintNumber"].ToString();
                    prints.Add(print);
                }

                return prints;
            }



        }

        public string GetNewPrintNumber()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_prints_get_new_print_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                object obj = cmd.ExecuteScalar();
                string printNumber = "";

                if (obj != DBNull.Value && obj != null)
                    printNumber = (obj).ToString();

                return printNumber;

            }

        }

        public List<Print> GetPrintVariations(int PrintId)
        {
            //System.Diagnostics.Debugger.Break();
            List<Print> Prints = new List<Print>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_prints_get_all_prints_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = PrintId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Print print = new Print();
                        print.PrintID = Convert.ToInt32(reader["Id"]);
                        print.PrintNumber = Convert.ToString(reader["PrintNumber"]);
                        Prints.Add(print);
                    }
                }
            }
            return Prints;
        }

        public int SavePrintTestingHistory(PrintHistory PrintTesting)
        {
            int printHistoryID;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_print_testing_history_save_print_testing_history";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@oId", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@d", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = PrintTesting.PrintHistoryID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintID", SqlDbType.Int);
                param.Value = PrintTesting.ParentPrint.PrintID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TestingDate", SqlDbType.DateTime);
                param.Value = PrintTesting.TestingDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Comments", SqlDbType.VarChar);
                param.Value = PrintTesting.Comments;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = PrintTesting.Status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PDFPath", SqlDbType.VarChar);
                param.Value = PrintTesting.PDFPath;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                printHistoryID = Convert.ToInt32(outParam.Value);

                cnx.Close();
            }

            return printHistoryID;
        }

        public List<PrintHistory> GetPrintTestingHistoryByPrintId(int PrintId)
        {
            List<PrintHistory> PrintsHistory = new List<PrintHistory>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_print_testing_history_get_by_print_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@PrintId", SqlDbType.Int);
                param.Value = PrintId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PrintHistory printHistory = new PrintHistory();
                        printHistory.ParentPrint = new Print();
                        printHistory.ParentPrint.PrintID = Convert.ToInt32(reader["PrintID"]);
                        printHistory.TestingDate = (reader["TestingDate"] != DBNull.Value) ? Convert.ToDateTime(reader["TestingDate"]) : DateTime.MinValue;
                        printHistory.Comments = (reader["Comments"] != DBNull.Value) ? Convert.ToString(reader["Comments"]) : String.Empty;
                        printHistory.PDFPath = (reader["FilePath"] != DBNull.Value) ? Convert.ToString(reader["FilePath"]) : String.Empty;
                        printHistory.Status = (reader["Status"] != DBNull.Value) ? Convert.ToInt32(reader["Status"]) : 0;
                        PrintsHistory.Add(printHistory);
                    }
                }
            }
            return PrintsHistory;
        }


        /// <summary>
        /// Yaten : Get All Buying House 31 May
        /// </summary>
        /// <param name="StyleID"></param>
        /// <returns></returns>

        public DataTable GetAllBuyingHouseDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllBuyingHouse";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        public DataTable GetDivisionBy_Designation(string DesignationID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetDivisionBy_Designation";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        #region Gajendra Client Form Updates
        //Gajendra Client Form 26-11-2015
        public DataTable GetDivisionName()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetDivisionName";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        //Gajendra Client Form 26-11-2015
        public DataTable GetBuyingHouseByDivision(string DivisionID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetBuyingHouseByDivision";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@DivisionID", SqlDbType.Int);
                param.Value = DivisionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        #endregion

        public DataTable GetAllAqlStans()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_BuyingHouse_get_all_AqlStand";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }

        /// <summary>
        /// Yaten : Get all client according to Buying House 31 May
        /// </summary>
        /// <param name="intId"></param>
        /// <returns></returns>

        public DataTable GetAllClientForBuyingHouseDAL(int intId, int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllClient_For_BuyingHouse";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }


        public DataTable GetAllDeptForClient(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_PrintList_DepartmentList";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }

        // Edit by surendra on 20 may 2013
        public DataTable GetAllUnitL(int DesignationID, int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllUnit";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@DesignationID", SqlDbType.Int);
                param.Value = DesignationID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }        
        public List<Print> GetAllPrintsBuyingHouseDAL(out int TotalRowCount, int ClientId, string SearchText, int PrintTypeID, int PrintCategory, int intBuyingHouseId, int intDepartmentID, int ChildClientDeptID)
        {            
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_prints_get_all_prints_with_paging_BuyingHouse";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                
                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintTypeID", SqlDbType.Int);
                param.Value = PrintTypeID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Printcategory", SqlDbType.Int);
                param.Value = PrintCategory;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseID", SqlDbType.Int);
                param.Value = intBuyingHouseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                
                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = intDepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChildClientDeptID", SqlDbType.Int);
                param.Value = ChildClientDeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Print> prints = new List<Print>();

                while (reader.Read())
                {
                    Print print = new Print();

                    print.PrintID = Convert.ToInt32(reader["Id"]);
                    print.PrintNumber = (reader["PrintNumber"]).ToString();
                    print.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                    print.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                    print.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                    print.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerFirstName"])) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerLastName"]));
                    print.PrintCompany = (reader["PrintCompany"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompany"]);
                    print.PrintCompanyReference = (reader["PrintCompanyReference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCompanyReference"]);
                    print.PrintCost = (reader["PrintCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PrintCost"]);
                    print.PrintCostCurrency = (reader["PrintCostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["PrintCostCurrency"]);
                    print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    print.FabricQuality = (reader["FabricQuality"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricQuality"]);
                    print.Status = (Convert.ToBoolean(reader["IsSold"]) == true) ? PrintStatus.Sold : PrintStatus.Unsold;
                    print.PrintType = (reader["PrintType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintType"]);
                    print.PrintRefNo = (reader["PrintRefNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintRefNo"]);
                    print.DevelopedImageUrl = (reader["DevelopedImageURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DevelopedImageURL"]);
                    print.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                    print.PrintCategoryName = (reader["PrintCategoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintCategoryName"]);
                    prints.Add(print);
                }


                reader.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return prints;
            }
        }

        // Add by Ravi kumar on 4/4/2015 for Department on Manage Order
        public DataTable GetAllDeptByClientDAL(int intId, int UseId, bool IsClient, bool IsClientDept)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetDepartment_For_Client";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClient", SqlDbType.Bit);
                param.Value = IsClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClientDept", SqlDbType.Bit);
                param.Value = IsClientDept;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        //Added By Ashish on 14/4/2015 
        public DataTable GetAllDeptByClientForManageOrderDAL(int intId, int ClientId, int DateType, string YearRange, int UserId,int AM)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dsorderDetail = new DataTable();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllClient_For_ManageOrder";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intId;
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

                param = new SqlParameter("@UserId", SqlDbType.VarChar);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);

                return dsorderDetail;

            }



        }
        //END
        //Added By Ashish on 16/4/2015
        public DataTable GetAllDeptByClientId(int intId, int UseId, bool IsClient, bool IsClientDept, int DateType, string YearRange,int AM,int ParentDeptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetDepartmentBy_ClientId_ForManageOrder";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClient", SqlDbType.Bit);
                param.Value = IsClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClientDept", SqlDbType.Bit);
                param.Value = IsClientDept;
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

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptID", SqlDbType.Int);
                param.Value = ParentDeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        public DataTable GetParentDeptID(int intId, int UseId, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetParentDepartment_ForManageOrder";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClient", SqlDbType.Bit);
                param.Value = IsClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClientDept", SqlDbType.Bit);
                param.Value = IsClientDept;
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

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        //END
        //public DataTable FillddlBuyingHouse(int intId)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        DataSet dsorderDetail = new DataSet();
        //        cnx.Open();
        //        SqlCommand cmd;
        //        string cmdText;

        //        cmdText = "";
        //        cmd = new SqlCommand(cmdText, cnx);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
        //        param.Value = intId;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dsorderDetail);
        //        return (dsorderDetail.Tables[0]);

        //    }

        //}


        //Added By Abhishek on 27/4/2015 for Ajax Bind Ddl Client
        public List<Client> GetAllDeptByClientForManageOrderDAL1(int intId, int ClientId, int DateType, string YearRange, int UserId,int AM)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllClient_For_ManageOrder";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intId;
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

                param = new SqlParameter("@UserId", SqlDbType.VarChar);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Client> clientss = new List<Client>();



                while (reader.Read())
                {

                    Client objClient = new Client();
                    objClient.ClientID = Convert.ToInt32(reader["ClientId"]);
                    objClient.CompanyName = reader["companyname"].ToString();

                    clientss.Add(objClient);


                }

                return clientss;

            }





        }
        public List<Client> GetClientDetailslist_ForAM(int intId, int ClientId, int DateType, string YearRange, int UserId,int AM)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetAllClient_For_ManageOrder_AM";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intId;
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

                param = new SqlParameter("@UserId", SqlDbType.VarChar);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Client> clientss = new List<Client>();



                while (reader.Read())
                {

                    Client objClient = new Client();
                    objClient.ClientID = Convert.ToInt32(reader["ClientId"]);
                    objClient.CompanyName = reader["companyname"].ToString();

                    clientss.Add(objClient);


                }

                return clientss;

            }





        }
        public List<Client> GetAllAM(int DateType, string YearRange)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
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
                param.Value = YearRange;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

             

                reader = cmd.ExecuteReader();
                List<Client> clientss = new List<Client>();



                while (reader.Read())
                {

                    Client objClient = new Client();
                    objClient.ClientID = Convert.ToInt32(reader["ID"]);
                    objClient.CompanyName = reader["UserName"].ToString();

                    clientss.Add(objClient);


                }

                return clientss;

            }





        }
        public List<Department> GetAllDepartmentDetailsbyId(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM, int ParentDepartmentID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetDepartmentBy_ClientId_ForManageOrder";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClient", SqlDbType.Bit);
                param.Value = IsClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClientDept", SqlDbType.Bit);
                param.Value = IsClientDept;
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

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptID", SqlDbType.Int);
                param.Value = ParentDepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Department> Deptobj = new List<Department>();



                while (reader.Read())
                {

                    Department objdepts = new Department();
                    objdepts.Name = reader["DepartmentName"].ToString();
                    objdepts.DepartmentID = Convert.ToInt32(reader["UserID"]);

                    Deptobj.Add(objdepts);


                }

                return Deptobj;

            }


        }
        public List<Department> Get_Parent_DepartmentDetailslist(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetParentDepartmentBy_ClientId_ForManageOrder";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClient", SqlDbType.Bit);
                param.Value = IsClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClientDept", SqlDbType.Bit);
                param.Value = IsClientDept;
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

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Department> Deptobj = new List<Department>();



                while (reader.Read())
                {

                    Department objdepts = new Department();
                    objdepts.Name = reader["DepartmentName"].ToString();
                    objdepts.DepartmentID = Convert.ToInt32(reader["UserID"]);

                    Deptobj.Add(objdepts);


                }

                return Deptobj;

            }


        }
        public List<Department> GetDepartmentDetailslist_ForAM(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange,int AM)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetDepartmentBy_ClientId_ForManageOrder_AM";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ntId", SqlDbType.Int);
                param.Value = intID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClient", SqlDbType.Bit);
                param.Value = IsClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClientDept", SqlDbType.Bit);
                param.Value = IsClientDept;
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

                param = new SqlParameter("@AM", SqlDbType.Int);
                param.Value = AM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<Department> Deptobj = new List<Department>();



                while (reader.Read())
                {

                    Department objdepts = new Department();
                    objdepts.Name = reader["DepartmentName"].ToString();
                    objdepts.DepartmentID = Convert.ToInt32(reader["UserID"]);

                    Deptobj.Add(objdepts);


                }

                return Deptobj;

            }


        }
        //added by abhishek on 14/9/2015
        public DataTable GetAllfactoryUnit(int p_id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetAllfactoryUnit";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@p_id", SqlDbType.Int);
                param.Value = p_id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        //end by abhishek on 14/9/2015

      //added by abhishek on 20/2/2018
        public DataSet GetAllPrintsBuyingHouseDALsolddetails()
        {

          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            DataSet dsorderDetail = new DataSet();
            cnx.Open();
            SqlCommand cmd;
            string cmdText;

            cmdText = "sp_prints_get_all_prints_with_paging_BuyingHouse_assos";
            cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dsorderDetail);
            return dsorderDetail;

          }
        }

        public string GetPrintNumberByRefBDAL_New(string RefNumber)
        {
            string printImageUrl = string.Empty;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_PrintNumber_By_RefNo";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PrintRef", SqlDbType.VarChar);
                param.Value = RefNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                object url = cmd.ExecuteScalar();

                if (null != url)
                    printImageUrl = url.ToString();
                return printImageUrl;

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //adapter.Fill(dsorderDetail);
                //DataTable dt = dsorderDetail.Tables[0];

                //string styleNumber = Convert.ToString(dt.Rows[0][0]);
                //return styleNumber;

            }

        }

        public string GetPrintImageUrlByPrintNumber_New(string PrintNumber)
        {
            string printImageUrl = string.Empty;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_prints_get_print_image_url_by_print_number";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object url = cmd.ExecuteScalar();

                if (null != url)
                    printImageUrl = url.ToString();
            }

            return printImageUrl;
        }
        public string CheckPrintAlreadyExists(string PrintNumber,int printId)
        {
          string printImageUrl = string.Empty;

          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();

            string cmdText = "Usp_CheckPrintNo";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
            param.Value = PrintNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PrintId", SqlDbType.Int);
            param.Value = printId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            object url = cmd.ExecuteScalar();

            if (null != url)
              printImageUrl = url.ToString();
          }

          return printImageUrl;
        }

        public DataTable CountryCode()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GETCountryCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "GetCountryList";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(ds);
                return (ds.Tables[0]);

            }

        }
       
    }





}
