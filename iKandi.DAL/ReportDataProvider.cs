using System;
using System.Collections.Generic;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class ReportDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public ReportDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion


// For New critical path Report
        public DataSet CriticalPatchReport(string SearchText, int Client, int Department, int SupplyType, int ModeType, int PackingType, int Terms,int UserId,int BuyingHouse)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_report_critical_path";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Client", SqlDbType.Int);
                param.Value = Client;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Department", SqlDbType.Int);
                param.Value = Department;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplyType", SqlDbType.Int);
                param.Value = SupplyType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModeType", SqlDbType.Int);
                param.Value = ModeType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PackingType", SqlDbType.Int);
                param.Value = PackingType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Terms", SqlDbType.Int);
                param.Value = Terms;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("SortOrder1", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("SortOrder2", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("SortOrder3", SqlDbType.Int);
                param.Value = 3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouse", SqlDbType.Int);
                param.Value = BuyingHouse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
              
                //cmd.CommandTimeout = 30000;
                DataSet dsCriticalPath = new DataSet();
                SqlDataAdapter adpCriticalPath = new SqlDataAdapter(cmd);
                adpCriticalPath.Fill(dsCriticalPath);
                cnx.Close();
                return dsCriticalPath;             
                
            }
        }
        public DataSet GetSamplingStatusReport(int PageSize, int PageIndex, out int TotalRowCount, int BuyerID, int StyleID, DateTime FromDate, DateTime ToDate, string SearchText)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_sampling_status";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

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

                param = new SqlParameter("@BuyerID", SqlDbType.Int);
                param.Value = BuyerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
               // if (FromDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = FromDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
               // if (ToDate == DateTime.MinValue)
                    if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = ToDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsSamplingStatus = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsSamplingStatus);

                cnx.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return dsSamplingStatus;
            }
        }

        public DataSet GetSamplingDispatchReport(DateTime CourierDate, string SearchText)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_sampling_dispatch";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                if ((CourierDate == DateTime.MinValue) || (CourierDate == Convert.ToDateTime("1753-01-01")) || (CourierDate == Convert.ToDateTime("1900-01-01")))
               // if (CourierDate == DateTime.MinValue)
                    param.Value = DBNull.Value;
                else
                    param.Value = CourierDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsSamplingDispatch = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsSamplingDispatch);

                cnx.Close();

                return dsSamplingDispatch;
            }
        }


        public DataSet GetFabricSamplingReport(string SearchText)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fabric_sampling";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricSampling = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricSampling);

                cnx.Close();

                return dsFabricSampling;
            }
        }
        public int GetMOQAStatusHistory(string SearchText, string BuyerID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                int Temp = 0;
                string cmdText = "sp_reports_fabric_running_quality_By_Buyer";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = new SqlParameter("@BuyerID", SqlDbType.VarChar);
                param.Value = BuyerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPendingimages = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPendingimages);

                cnx.Close();

                return Temp;
            }
        }

        public DataSet GetPendingImagesReport(int BuyerID, string SearchText)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_pending_images";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@BuyerID", SqlDbType.Int);
                param.Value = BuyerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPendingimages = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPendingimages);

                cnx.Close();

                return dsPendingimages;
            }
        }

        public DataSet GetFabricQualityPendingReport(string SearchText)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fabric_quality_pending";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQualityPending = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQualityPending);

                cnx.Close();

                return dsFabricQualityPending;
            }
        }

        public DataSet GetFabricRunningQuality(int BuyerID, int FromPrice, int ToPrice)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fabric_running_quality";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@BuyerID", SqlDbType.Int);
                param.Value = BuyerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FromPrice", SqlDbType.Int);
                param.Value = FromPrice;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@ToPrice", SqlDbType.Int);
                param.Value = ToPrice;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricRunningQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricRunningQuality);

                cnx.Close();

                return dsFabricRunningQuality;
            }
        }


        public DataSet GetDesignerTargetAllocation(int DesignerID, int Year, int Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_designer_target_allocation";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = DesignerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsDesignerTargetAllocation = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsDesignerTargetAllocation);

                cnx.Close();

                return dsDesignerTargetAllocation;
            }
        }




        public List<OrderDetail> GetiKandiViewReportsFinancials(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_reports_ikandi_view_reports_financials";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@searchText", SqlDbType.VarChar);
                param.Value = searchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (FromDate != DateTime.MinValue)
                {
                    param.Value = FromDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (ToDate != DateTime.MinValue)
                {
                    param.Value = ToDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                int result;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.Costing = new Costing();
                        orderDetail.ParentOrder.Costing.CostingID = (reader["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CostingId"]);

                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        orderDetail.ParentOrder.Style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        orderDetail.ParentOrder.Style.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentID"]);

                        orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);
                        double PriceQuoted = (reader["PriceQuoted"] != DBNull.Value) ? Convert.ToDouble(reader["PriceQuoted"]) : 0;
                        orderDetail.ParentOrder.Costing.AgreedPrice = (reader["AgreedPrice"] != DBNull.Value) ? Convert.ToDouble(reader["AgreedPrice"]) : PriceQuoted;

                        orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                        orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                        orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                        orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
                        var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                            result = 0;

                        }

                        var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                            result = 0;
                        }



                        var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                            result = 0;
                        }


                        var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                            result = 0;
                        }


                        orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                        orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                        orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                        orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                        orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                        orderDetail.Mode = Convert.ToInt32(reader["Mode"]);
                        orderDetail.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                        orderDetail.iKandiPrice = Convert.ToDouble(reader["iKandiPrice"]);
                        orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                        orderDetail.WeekToEx = Convert.ToInt32(reader["WeekToEx"]);
                        orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                        orderDetail.WeeksToDC = Convert.ToInt32(reader["WeeksToDC"]);
                        orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                        string SanjeevRemarks = reader["SanjeevRemarks"].ToString();
                        orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("$$", "<br/><br/>");
                        string MerchantNotes = reader["MerchantNotes"].ToString();
                        orderDetail.MerchantNotes = MerchantNotes.Replace("$$", "<br/><br/>");

                        orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                        orderDetail.ProductionUnitId = (reader["UnitID"] != DBNull.Value) ? Convert.ToInt32(reader["UnitID"]) : 0;

                        orderDetail.Unit = new ProductionUnit();
                        orderDetail.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitID"]);
                        orderDetail.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                        orderDetail.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);

                        orderDetail.ParentOrder.LandedCosting = new LandedCosting();
                        orderDetail.ParentOrder.LandedCosting.Margin = (reader["Margin"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Margin"]);
                        orderDetail.ParentOrder.LandedCosting.Discount = (reader["Discount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Discount"]);

                        orderDetail.ParentOrder.Style.client = new Client();
                        orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(reader["ClientID"]);


                        orderDetailCollection.Add(orderDetail);
                    }
                }

                return orderDetailCollection;
            }
        }

        public List<OrderDetail> GetiKandiViewReportsTechnicals(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_reports_ikandi_view_reports_get_technical";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@searchText", SqlDbType.VarChar);
                param.Value = searchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (FromDate != DateTime.MinValue)
                {
                    param.Value = FromDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (ToDate != DateTime.MinValue)
                {
                    param.Value = ToDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                int result;
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        orderDetail.ParentOrder.Style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);
                        orderDetail.ParentOrder.Style.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentID"]);

                        orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                        orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                        orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                        orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
                        var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;                            
                            result = 0;

                        }

                        var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;                            
                            result = 0;
                        }



                        var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                            result = 0;
                        }


                        var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                            result = 0;
                        }

                        orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                        orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                        orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                        orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                        orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                        orderDetail.Mode = Convert.ToInt32(reader["Mode"]);
                        orderDetail.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                        orderDetail.iKandiPrice = Convert.ToDouble(reader["iKandiPrice"]);
                        orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                        orderDetail.WeekToEx = Convert.ToInt32(reader["WeekToEx"]);
                        orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                        orderDetail.WeeksToDC = Convert.ToInt32(reader["WeeksToDC"]);
                        orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                        string SanjeevRemarks = reader["SanjeevRemarks"].ToString();
                        orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("$$", "<br/><br/>");
                        string MerchantNotes = reader["MerchantNotes"].ToString();
                        orderDetail.MerchantNotes = MerchantNotes.Replace("$$", "<br/><br/>");

                        orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                        orderDetail.ProductionUnitId = (reader["UnitID"] != DBNull.Value) ? Convert.ToInt32(reader["UnitID"]) : 0;

                        orderDetail.Unit = new ProductionUnit();
                        orderDetail.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitID"]);
                        orderDetail.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                        orderDetail.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);

                        orderDetail.ParentOrder.Costing = new Costing();
                        orderDetail.ParentOrder.Costing.CostingID = (reader["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CostingId"]);

                        orderDetail.ParentOrder.Style.client = new Client();
                        orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(reader["ClientID"]);

                        orderDetailCollection.Add(orderDetail);
                    }
                }

                return orderDetailCollection;
            }
        }


        public DataSet GetModeReports(int StatusId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_mode_reports";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StatusId", SqlDbType.VarChar);
                param.Value = StatusId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsModeReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsModeReport);

                cnx.Close();

                return dsModeReport;
            }
        }

        //TODO:Get Basic Info For Order Summary
        public List<OrderDetail> GetOrderSummaryReport(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_reports_order_summary";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@searchText", SqlDbType.VarChar);
                param.Value = searchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (FromDate != DateTime.MinValue)
                {
                    param.Value = FromDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (ToDate != DateTime.MinValue)
                {
                    param.Value = ToDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                int result;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        orderDetail.ParentOrder.Style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);
                        orderDetail.ParentOrder.Style.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentID"]);

                        orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                        orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

                        orderDetail.ParentOrder.Style.client = new Client();
                        orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(reader["ClientID"]);

                        orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                        orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                        orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                        orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);

                        var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                            result = 0;

                        }

                        var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                            result = 0;
                        }



                        var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                            result = 0;
                        }


                        var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                            result = 0;
                        }

                        orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                        orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                        orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                        orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                        orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                        orderDetail.Mode = Convert.ToInt32(reader["Mode"]);
                        orderDetail.iKandiPrice = Convert.ToDouble(reader["iKandiPrice"]);
                        orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                        orderDetail.WeekToEx = Convert.ToInt32(reader["WeekToEx"]);
                        orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                        orderDetail.WeeksToDC = Convert.ToInt32(reader["WeeksToDC"]);
                        orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                        string SanjeevRemarks = reader["SanjeevRemarks"].ToString();
                        orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("$$", "<br/><br/>");
                        string MerchantNotes = reader["MerchantNotes"].ToString();
                        orderDetail.MerchantNotes = MerchantNotes.Replace("$$", "<br/><br/>");

                        orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                        orderDetail.ProductionUnitId = (reader["UnitID"] != DBNull.Value) ? Convert.ToInt32(reader["UnitID"]) : 0;
                        orderDetail.IsAllocated = (reader["IsAllocated"] != DBNull.Value) ? Convert.ToBoolean(reader["IsAllocated"]) : false;

                        orderDetail.Unit = new ProductionUnit();
                        orderDetail.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitID"]);
                        orderDetail.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                        orderDetail.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);

                        orderDetail.ParentOrder.Costing = new Costing();
                        orderDetail.ParentOrder.Costing.CostingID = (reader["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CostingId"]);

                        orderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                        orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);


                        orderDetailCollection.Add(orderDetail);
                    }
                }

                return orderDetailCollection;
            }
        }

   

        public List<OrderDetail> GetOrdersSummaryReportCutting(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();
                int result;
                try
                {
                    string cmdText = "sp_reports_order_summary_get_cutting";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsorderDetail = new DataSet();
                    SqlParameter param;

                    param = new SqlParameter("@searchText", SqlDbType.VarChar);
                    param.Value = searchText;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                    if (FromDate != DateTime.MinValue)
                    {
                        param.Value = FromDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                    if (ToDate != DateTime.MinValue)
                    {
                        param.Value = ToDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsorderDetail);

                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];
                        DataTable dt1 = dsorderDetail.Tables[1];
                        DataTable dt2 = dsorderDetail.Tables[2];
                        DataTable dt3 = dsorderDetail.Tables[3];
                        int orderid = -1;
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                OrderDetail orderDetail = new OrderDetail();
                                orderDetail.OrderDetailID = Convert.ToInt32(dr["Id"]);
                                orderDetail.LineItemNumber = (dr["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                                orderDetail.ContractNumber = (dr["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ContractNumber"]);

                                orderDetail.ParentOrder = new Order();
                                orderDetail.ParentOrder.SerialNumber = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                                orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                                orderDetail.ParentOrder.Style = new Style();
                                orderDetail.ParentOrder.Style.StyleNumber = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                                orderDetail.ParentOrder.Style.DepartmentName = (dr["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                                orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(dr["StyleID"]);
                                orderDetail.ParentOrder.Style.InLineCutDate = (dr["InLineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["InLineCutDate"]);


                                orderDetail.Fabric1 = (dr["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1"]);
                                orderDetail.Fabric1Details = (dr["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                                var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                                    result = 0;

                                }


                                orderDetail.Quantity = Convert.ToInt32(dr["Quantity"]);
                                orderDetail.Mode = Convert.ToInt32(dr["Mode"]);
                                orderDetail.iKandiPrice = Convert.ToDouble(dr["iKandiPrice"]);
                                orderDetail.ExFactory = (dr["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(dr["ExFactory"]) : DateTime.MinValue;
                                orderDetail.WeekToEx = Convert.ToInt32(dr["WeekToEx"]);
                                orderDetail.DC = (dr["DC"] != DBNull.Value) ? Convert.ToDateTime(dr["DC"]) : DateTime.MinValue;
                                orderDetail.WeeksToDC = Convert.ToInt32(dr["WeeksToDC"]);
                                orderDetail.OrderID = Convert.ToInt32(dr["OrderID"]);
                                string SanjeevRemarks = dr["SanjeevRemarks"].ToString();
                                orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("$$", "<br/><br/>");
                                string MerchantNotes = dr["MerchantNotes"].ToString();
                                orderDetail.MerchantNotes = MerchantNotes.Replace("$$", "<br/><br/>");

                                if (orderid != orderDetail.OrderID)
                                {
                                    string strExpr = "OrderID =" + orderDetail.OrderID;
                                    DataRow[] DataRows;
                                    DataRows = dt1.Select(strExpr);
                                    foreach (DataRow dr1 in DataRows)
                                    {
                                        DateTime currentdate = (dr1["CurrentDate"] == DBNull.Value) ? DateTime.Now : Convert.ToDateTime(dr1["CurrentDate"]);
                                        orderDetail.AccessoryHistory += dr1["AccessoryName"] + " " + "in House Date 100% on" + " " + currentdate.ToString("dd MMM yy (ddd)") + "<br/><br/>";

                                        orderid = orderDetail.OrderID;
                                    }
                                }

                                orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
                                orderDetail.ParentOrder.CuttingDetail.CuttingSheetID = -1;
                                orderDetail.ParentOrder.CuttingDetail.ID = -1;

                                string str = "OrderID =" + orderDetail.OrderID;
                                DataRow[] DataRow1;
                                DataRow1 = dt2.Select(str);

                                foreach (DataRow dr2 in DataRow1)
                                {

                                    orderDetail.ParentOrder.CuttingDetail.CuttingSheetID = Convert.ToInt32(dr2["CuttingSheetID"]);

                                }

                                string strx = "OrderDetailID =" + orderDetail.OrderDetailID;
                                DataRow[] DataRow;
                                DataRow = dt3.Select(strx);

                                foreach (DataRow dr2 in DataRow)
                                {
                                    orderDetail.ParentOrder.CuttingDetail.ID = Convert.ToInt32(dr2["CuttingDetailID"]);
                                    orderDetail.ParentOrder.CuttingDetail.PcsCut = (dr2["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["PcsCut"]);
                                    orderDetail.ParentOrder.CuttingDetail.PcsIssued = (dr2["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["PcsIssued"]);
                                    orderDetail.ParentOrder.CuttingDetail.PercentagePcsCut = Convert.ToInt32(dr2["PcsCut"]) / Convert.ToInt32(dr["Quantity"]) * 100;
                                }

                                orderDetailCollection.Add(orderDetail);

                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return orderDetailCollection;
            }
        }

        public List<OrderDetail> GetOrdersSummaryReportStiching(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_reports_order_summary_get_stiching";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                DataSet dsorderDetailCollection = new DataSet();

                SqlParameter param;

                param = new SqlParameter("@searchText", SqlDbType.VarChar);
                param.Value = searchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if (FromDate != DateTime.MinValue)
                {
                    param.Value = FromDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                if (ToDate != DateTime.MinValue)
                {
                    param.Value = ToDate;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetailCollection);

                if (dsorderDetailCollection.Tables[0].Rows.Count > 0)
                {
                    int result;
                    foreach (DataRow dr in dsorderDetailCollection.Tables[0].Rows)
                    {
                        //if (reader.HasRows)
                        //{
                        //    while (reader.Read())
                        //    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(dr["Id"]);
                        orderDetail.LineItemNumber = (dr["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                        orderDetail.ContractNumber = (dr["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ContractNumber"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.SerialNumber = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleNumber = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                        orderDetail.ParentOrder.Style.DepartmentName = (dr["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                        orderDetail.ParentOrder.Style.StyleID = (dr["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StyleID"]);


                        orderDetail.Fabric1 = (dr["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1"]);
                        orderDetail.Fabric1Details = (dr["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                        var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                            result = 0;

                        }

                        orderDetail.Quantity = Convert.ToInt32(dr["Quantity"]);
                        orderDetail.Mode = Convert.ToInt32(dr["Mode"]);
                        orderDetail.iKandiPrice = Convert.ToDouble(dr["iKandiPrice"]);
                        orderDetail.ExFactory = (dr["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(dr["ExFactory"]) : DateTime.MinValue;
                        orderDetail.WeekToEx = Convert.ToInt32(dr["WeekToEx"]);
                        orderDetail.DC = (dr["DC"] != DBNull.Value) ? Convert.ToDateTime(dr["DC"]) : DateTime.MinValue;
                        orderDetail.WeeksToDC = Convert.ToInt32(dr["WeeksToDC"]);
                        orderDetail.OrderID = Convert.ToInt32(dr["OrderID"]);
                        string SanjeevRemarks = dr["SanjeevRemarks"].ToString();
                        orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("$$", "<br/><br/>");

                        orderDetail.ParentOrder.StitchingHistory = new StitchingHistory();
                        orderDetail.ParentOrder.StitchingHistory.TotalQuantity = 0;
                        string str = "OrderDetailID=" + orderDetail.OrderDetailID;
                        DataRow[] DataRow;
                        DataRow = dsorderDetailCollection.Tables[1].Select(str);
                        foreach (DataRow dr1 in DataRow)
                        {
                            orderDetail.ParentOrder.StitchingHistory.TotalQuantity += Convert.ToInt32(dr1["Quantity"]);
                        }

                        //orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
                        //orderDetail.ParentOrder.CuttingDetail.PcsIssued = (dr["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsIssued"]);

                        orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
                        orderDetail.ParentOrder.StitchingDetail.ID = (dr["StitchingDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StitchingDetailID"]);
                        orderDetail.ParentOrder.StitchingDetail.CuttingReceived = (dr["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsIssued"]);
                        orderDetail.ParentOrder.StitchingDetail.TotalPcsStitchedToday = (dr["TotalPcsStitchedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TotalPcsStitchedToday"]);
                        orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched = (dr["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OverallPcsStitched"]);
                        orderDetail.ParentOrder.StitchingDetail.PcsSent = (dr["PcsSent"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsSent"]);
                        orderDetail.ParentOrder.StitchingDetail.PcsReceived = (dr["PcsReceived"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsReceived"]);

                        int PcsReceivedPack = 0;
                        if (orderDetail.ParentOrder.StitchingDetail.PcsSent == 0)
                        {
                            PcsReceivedPack = (dr["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OverallPcsStitched"]);
                        }
                        else
                        {
                            PcsReceivedPack = (dr["PcsReceived"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsReceived"]);
                        }
                        orderDetail.ParentOrder.StitchingDetail.PcsReceivedPack = PcsReceivedPack;
                        orderDetail.ParentOrder.StitchingDetail.PcsPackedToday = (dr["PcsPackedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsPackedToday"]);
                        orderDetail.ParentOrder.StitchingDetail.OverallPcsPacked = (dr["OverallPcsPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OverallPcsPacked"]);
                        orderDetail.ParentOrder.StitchingDetail.ProdRemarks = (dr["ProdRemarks"] == DBNull.Value) ? string.Empty : dr["ProdRemarks"].ToString();


                        orderDetailCollection.Add(orderDetail);
                        //    }
                        //}
                    }
                }

                return orderDetailCollection;
            }
        }

        public DataSet GetOrdersSummaryReportAccessories(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            DataSet dsAccessories = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_reports_order_summary_get_accessory";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@searchText", SqlDbType.VarChar);
                    param.Value = searchText;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                    if (FromDate != DateTime.MinValue)
                    {
                        param.Value = FromDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                    if (ToDate != DateTime.MinValue)
                    {
                        param.Value = ToDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsAccessories);

                }
                catch (SqlException ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dsAccessories;
        }

        public DataSet GetClientDepartmentOrder(int DeptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_client_department_orders";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsClientDepartmentOrder = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsClientDepartmentOrder);

                cnx.Close();

                return dsClientDepartmentOrder;
            }
        }

        public DataSet GetOrderClientSummaryReport(int ClientID)
        {
            DataSet dsClientSummary = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_reports_order_summary_get_client_summary";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@ClientID", SqlDbType.Int);
                    paramIn.Value = ClientID;
                    cmd.Parameters.Add(paramIn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsClientSummary);

                }
                catch (SqlException ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dsClientSummary;
        }



        public DataSet GetSealerPendingOrdersReport(int ClientID, String SearchText)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_order_get_sealer_pending_orders";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsSealerPendingOrder = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsSealerPendingOrder);

                cnx.Close();

                return dsSealerPendingOrder;
            }
        }


        public List<OrderDetail> GetProductionReportInfo(string searchText, DateTime FromDate, DateTime ToDate, int ClientID, int UserId, int Unit)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();
                int result;
                String cmdText;

                try
                {
                    cmdText = "sp_reports_production_with_accessories";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsorderDetail = new DataSet();
                    SqlParameter param;

                    param = new SqlParameter("@searchText", SqlDbType.VarChar);
                    param.Value = searchText;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    
                    param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                    if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
                    // if (FromDate != DateTime.MinValue)
                    {
                        param.Value = DBNull.Value ;
                    }
                    else
                    {
                        param.Value = FromDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                    if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
                    //  if (ToDate != DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = ToDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Unit", SqlDbType.Int);
                    param.Value = Unit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsorderDetail);

                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];
                        DataTable dt1 = dsorderDetail.Tables[1];
                        DataTable dt2 = dsorderDetail.Tables[2];
                        

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dt.Rows)
                            {
                                OrderDetail orderDetail = new OrderDetail();
                                orderDetail.OrderDetailID = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]);
                                if (orderDetail.OrderDetailID == 0)
                                continue;
                                orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                                orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                                orderDetail.SealETA = (reader["SealETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SealETA"]);

                                orderDetail.ParentOrder = new Order();
                                orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                                orderDetail.ParentOrder.OrderDate = (reader["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["OrderDate"]);
                                orderDetail.ParentOrder.Description = (reader["OrderDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OrderDescription"]);

                                orderDetail.ParentOrder.Style = new Style();
                                orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                                orderDetail.ParentOrder.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                                orderDetail.ParentOrder.Style.InLineCutDate = (reader["InlineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["InlineCutDate"]);
                                orderDetail.ParentOrder.Style.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);
                                orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                                orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                                
                                orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                                orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                                orderDetail.ParentOrder.Style.cdept.DeptID = (reader["ClientDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientDepartmentID"]) : 0;

                                orderDetail.ParentOrder.Style.client = new Client();
                                orderDetail.ParentOrder.Style.client.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);
                                orderDetail.ParentOrder.Style.client.CompanyName = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                                
                                orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                                orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                                orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                                orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
                                var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                                    result = 0;
                                }

                                var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                                    result = 0;
                                }
                                
                                var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                                    result = 0;
                                }
                                
                                var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                                    result = 0;
                                }

                                orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                                orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                                orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                                orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);
                                orderDetail.Quantity = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity"]);
                                orderDetail.Mode = (reader["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Mode"]);
                                if (orderDetail.Mode != 0)
                                    orderDetail.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                                orderDetail.iKandiPrice = (reader["iKandiPrice"] == DBNull.Value) ? 0.0 : Convert.ToDouble(reader["iKandiPrice"]);
                                orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                                orderDetail.WeekToEx = (reader["WeekToEx"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["WeekToEx"]);
                                orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                                orderDetail.WeeksToDC = (reader["WeeksToDC"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["WeeksToDC"]);
                                orderDetail.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderID"]);
                                string SanjeevRemarks = reader["SanjeevRemarks"].ToString();
                                orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("$$", "<BR/><BR/>");
                                string MerchantNotes = reader["MerchantNotes"].ToString();
                                orderDetail.MerchantNotes = MerchantNotes.Replace("$$", "<BR/><BR/>");
                                orderDetail.STCUnallocated = (reader["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(reader["STCUnallocated"]) : DateTime.MinValue;
                                orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                                orderDetail.ProductionUnitId = (reader["UnitID"] != DBNull.Value) ? Convert.ToInt32(reader["UnitID"]) : 0;
                                orderDetail.IsAllocated = (reader["IsAllocated"] != DBNull.Value) ? Convert.ToBoolean(reader["IsAllocated"]) : false;
                                orderDetail.CuttingETA = (reader["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["CuttingETA"]) : DateTime.MinValue;
                                orderDetail.PackingETA = (reader["PackingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["PackingETA"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;

                                orderDetail.ParentOrder.InlinePPMOrderContract = new InlinePPMOrderContract(); // to get top send target and top send actual
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget = (reader["TopSentTarget"] == DBNull.Value) ? orderDetail.STCUnallocated : Convert.ToDateTime(reader["TopSentTarget"]);
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual = (reader["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["TopSentActual"]);
                                
                                orderDetail.Unit = new ProductionUnit();
                                orderDetail.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitID"]);
                                orderDetail.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                                orderDetail.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);
                                orderDetail.Unit.ProductionUnitColor = (reader["ProductionUnitColor"] == DBNull.Value || Convert.ToString(reader["ProductionUnitColor"]) == string.Empty) ? "#ffffff" : Convert.ToString(reader["ProductionUnitColor"]);

                                orderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);// Add this

                                orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
                                orderDetail.ParentOrder.CuttingDetail.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);
                                orderDetail.ParentOrder.CuttingDetail.PcsIssued = (reader["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsIssued"]);

                                orderDetail.ParentOrder.CuttingHistory = new CuttingHistory();
                                orderDetail.ParentOrder.CuttingHistory.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);

                                if (orderDetail.Quantity != 0)
                                {
                                    orderDetail.ParentOrder.CuttingHistory.PercentagePcsCut = (orderDetail.ParentOrder.CuttingHistory.PcsCut * 100) / orderDetail.Quantity;
                                }
                                else
                                {
                                    orderDetail.ParentOrder.CuttingHistory.PercentagePcsCut = 0;
                                }
                                orderDetail.ParentOrder.CuttingHistory.Date = (reader["CuttingActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CuttingActual"]);

                                orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
                                orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched = (reader["PcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsStitched"]);
                                orderDetail.ParentOrder.StitchingDetail.OverallPcsPacked = (reader["PcsPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsPacked"]);
                                orderDetail.ParentOrder.StitchingDetail.TotalPcsStitchedToday = (reader["TotalPcsStitchedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["TotalPcsStitchedToday"]);
                                orderDetail.ParentOrder.StitchingDetail.PcsPackedToday = (reader["PcsPackedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsPackedToday"]);
                                orderDetail.ParentOrder.StitchingDetail.CuttingReceived = (reader["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsIssued"]);

                                if (orderDetail.Quantity != 0)
                                {
                                    orderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched = (orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched * 100) / orderDetail.Quantity;
                                    orderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked = (orderDetail.ParentOrder.StitchingDetail.OverallPcsPacked * 100) / orderDetail.Quantity;
                                }
                                else
                                {
                                    orderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched = 0;
                                    orderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked = 0;
                                }

                                orderDetail.ParentOrder.StitchingDetail.ProdRemarks = (reader["ProdRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProdRemarks"]);
                                String[] charArr = { "$$" };
                                string[] prodremarks = orderDetail.ParentOrder.StitchingDetail.ProdRemarks.Split(charArr, StringSplitOptions.None);
                                int ProdRemarksLength = prodremarks.Length;
                                if (ProdRemarksLength > 0)
                                    orderDetail.ParentOrder.StitchingDetail.ProdRemarks = prodremarks[ProdRemarksLength - 1];

                                orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (reader["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse1"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (reader["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse2"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (reader["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse3"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (reader["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse4"]);

                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate1 = (reader["Date1"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date1"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate2 = (reader["Date2"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date2"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate3 = (reader["Date3"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date3"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate4 = (reader["Date4"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date4"]);


                                orderDetail.ParentOrder.Fits = new Fits();
                                orderDetail.ParentOrder.Fits.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);
                                orderDetail.ParentOrder.Fits.StyleCodeVersion = (reader["StyleCodeVersion"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleCodeVersion"]);
                                orderDetail.ParentOrder.Fits.IsStcApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);
                                orderDetail.ParentOrder.Fits.SealDate = (reader["SealDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SealDate"]);

                                orderDetail.ParentOrder.FitsTrack = new FitsTrack();
                                orderDetail.ParentOrder.FitsTrack.PlanningFor = (reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]);
                                orderDetail.ParentOrder.FitsTrack.fitRequestedOn = (reader["fitRequestedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["fitRequestedOn"]);

                                if (orderDetail.ParentOrder.Fits.IsStcApproved == true)
                                {
                                    orderDetail.FitStatus = orderDetail.ParentOrder.FitsTrack.PlanningFor + " " + "On" + " " + orderDetail.ParentOrder.Fits.SealDate.ToString("dd MMM yy (ddd)");
                                }
                                else if (orderDetail.ParentOrder.FitsTrack.PlanningFor != string.Empty)
                                {
                                    orderDetail.FitStatus = orderDetail.ParentOrder.FitsTrack.PlanningFor + " Requested On " + orderDetail.ParentOrder.FitsTrack.fitRequestedOn.ToString("dd MMM yy (ddd)");
                                }
                                                        

                                string str = "OrderID =" + orderDetail.OrderID;
                                string strx = "OrderDetailID =" + orderDetail.OrderDetailID;

                                orderDetail.ParentOrder.AccessoryInHouseHistory = new AccessoryInHouseHistory();
                                
                                DataRow[] DataRows;
                                DataRows = dt1.Select(strx);
                                foreach (DataRow dr4 in DataRows)
                                {
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.Date = (dr4["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr4["Date"]);
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse = (dr4["PercentInHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(dr4["PercentInHouse"]);
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName = (dr4["AccessoryName"] == DBNull.Value) ? string.Empty : dr4["AccessoryName"].ToString();
                                    orderDetail.AccessoryHistory += orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse + "% on" + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.Date.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                }

                                DataRow[] DataRows2;
                                DataRows2 = dt2.Select(str);
                                foreach (DataRow dr5 in DataRows2)
                                {
                                    string AccessoryName = (dr5["AccessoryName"] == DBNull.Value) ? string.Empty : dr5["AccessoryName"].ToString();
                                    if (orderDetail.AccessoryHistory != null && orderDetail.AccessoryHistory != string.Empty)
                                    {
                                        if (orderDetail.AccessoryHistory.IndexOf(AccessoryName) == -1)
                                        {
                                            orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                    }

                                }

                                orderDetailCollection.Add(orderDetail);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return orderDetailCollection;
            }
        }
         
        public DataTable GetStyleDigitalInfo(string iClientId,int iDateType,DateTime iFromDate,DateTime iToDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                String cmdText;
                DataSet dsStyleDigit = new DataSet();
                try
                {
                    cmdText = "sp_style_digital_Info";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@ClientId", SqlDbType.VarChar);
                    param.Value =iClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateType", SqlDbType.Int);
                    param.Value = iDateType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                    param.Value = iFromDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                    param.Value = iToDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsStyleDigit);

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return dsStyleDigit.Tables[0];
            }
        }

        public List<OrderDetail> GetCriticalPatchReport(string SearchText, int Client, int Department, int SupplyType, int ModeType, int PackingType, int Terms)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_reports_get_critical_patch_repert";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Client", SqlDbType.Int);
                param.Value = Client;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Department", SqlDbType.Int);
                param.Value = Department;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplyType", SqlDbType.Int);
                param.Value = SupplyType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModeType", SqlDbType.Int);
                param.Value = ModeType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PackingType", SqlDbType.Int);
                param.Value = PackingType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Terms", SqlDbType.Int);
                param.Value = Terms;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                
                reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                int result;
                bool success;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        orderDetail.Description = (reader["OrderDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OrderDescription"]);
                        orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);

                        orderDetail.Mode = (reader["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Mode"]);
                        orderDetail.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);

                        orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                        orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                        orderDetail.WeekToEx = Convert.ToInt32(reader["WeekToEx"]);
                        orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                        orderDetail.WeeksToDC = Convert.ToInt32(reader["WeeksToDC"]);
                        orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                        orderDetail.STCUnallocated = (reader["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(reader["STCUnallocated"]) : DateTime.MinValue;
                        orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                        orderDetail.CuttingETA = (reader["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["CuttingETA"]) : DateTime.MinValue;
                        orderDetail.PackingETA = (reader["PackingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["PackingETA"]) : DateTime.MinValue;
                        orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                        orderDetail.BulkTarget = (reader["BulkTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkTarget"]) : DateTime.MinValue;
                        orderDetail.LabDipTarget = (reader["LabDipTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["LabDipTarget"]) : DateTime.MinValue;
                        orderDetail.BulkApprovalTarget = (reader["BulkApprovalTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkApprovalTarget"]) : DateTime.MinValue;
                        
                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);
                        orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                        orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                        orderDetail.ParentOrder.Style.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);

                        orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                        orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        orderDetail.ParentOrder.Style.cdept.DeptID = (reader["ClientDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientDepartmentID"]) : 0;
                        
                        orderDetail.ParentOrder.Style.client = new Client();
                        orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(reader["ClientID"]);
                        orderDetail.ParentOrder.Style.client.CompanyName = (reader["Buyer"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Buyer"]);

                        orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                        orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                        orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                        orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
                        success = Int32.TryParse(orderDetail.Fabric1Details, out result);
                        if (success.Equals(true))
                        {
                            orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                            success = false;
                            result = 0;
                        }
                        success = Int32.TryParse(orderDetail.Fabric2Details, out result);
                        if (success.Equals(true))
                        {
                            orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                            success = false;
                            result = 0;
                        }
                        success = Int32.TryParse(orderDetail.Fabric3Details, out result);
                        if (success.Equals(true))
                        {
                            orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                            success = false;
                            result = 0;
                        }
                        success = Int32.TryParse(orderDetail.Fabric4Details, out result);
                        if (success.Equals(true))
                        {
                            orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                            success = false;
                            result = 0;
                        }

                        orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                        orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                        orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                        orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                        orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (reader["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse1"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (reader["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse2"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (reader["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse3"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (reader["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse4"]);

                        orderDetail.ParentOrder.FabricInhouseHistory.PercentDate1 = (reader["Date1"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date1"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.PercentDate2 = (reader["Date2"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date2"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.PercentDate3 = (reader["Date3"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date3"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.PercentDate4 = (reader["Date4"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date4"]);
                        
                        orderDetail.ParentOrder.InlinePPMOrderContract = new InlinePPMOrderContract(); // to get top send target and top send actual
                        orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget = (reader["TopSentTarget"] == DBNull.Value) ? orderDetail.StitchingETA : Convert.ToDateTime(reader["TopSentTarget"]);
                        orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual = (reader["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["TopSentActual"]);
                        orderDetail.ParentOrder.InlinePPMOrderContract.TopActualApproval = (reader["TopActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["TopActualApproval"]);
                        orderDetail.ParentOrder.InlinePPMOrderContract.TopStatus = (reader["TopStatus"] == DBNull.Value) ? TopStatusType.UNKNOWN : (TopStatusType)Convert.ToInt32(reader["TopStatus"]);

                        orderDetail.ParentOrder.Fits = new Fits();
                        orderDetail.ParentOrder.Fits.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);
                        orderDetail.ParentOrder.Fits.IsStcApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);
                        orderDetail.ParentOrder.Fits.SealDate = (reader["SealDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SealDate"]);
                        orderDetail.ParentOrder.Fits.SpecsUploadTargetDate = (reader["SpecsUploadTargetDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SpecsUploadTargetDate"]);
                        orderDetail.ParentOrder.Fits.SpecsUploadDate = (reader["SpecsUploadDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SpecsUploadDate"]);
                        orderDetail.ParentOrder.Fits.StyleCodeVersion = (reader["StyleCodeVersion"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleCodeVersion"]);

                        orderDetail.ParentOrder.FitsTrack = new FitsTrack();
                        orderDetail.ParentOrder.FitsTrack.CommentsSentFor = (reader["CommentsSentFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CommentsSentFor"]);
                        orderDetail.ParentOrder.FitsTrack.PlanningFor = (reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]);
                        orderDetail.ParentOrder.FitsTrack.fitRequestedOn = (reader["fitRequestedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["fitRequestedOn"]);
                        orderDetail.ParentOrder.FitsTrack.AckDate = (reader["AckDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AckDate"]);
                        orderDetail.ParentOrder.FitsTrack.NextPlannedDate = (reader["NextPlannedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["NextPlannedDate"]);

                        orderDetail.FitStatus = Constants.GetFitsStatus(orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual, orderDetail.ParentOrder.InlinePPMOrderContract.TopActualApproval, orderDetail.ParentOrder.Fits.IsStcApproved, orderDetail.ParentOrder.Fits.SealDate,
                        orderDetail.ParentOrder.FitsTrack.CommentsSentFor, orderDetail.ParentOrder.FitsTrack.PlanningFor, orderDetail.ParentOrder.FitsTrack.fitRequestedOn, orderDetail.ParentOrder.FitsTrack.AckDate, orderDetail.ParentOrder.InlinePPMOrderContract.TopStatus,
                        orderDetail.ParentOrder.Fits.SpecsUploadTargetDate, orderDetail.ParentOrder.Fits.SpecsUploadDate);
                        
                        orderDetail.FitStatusBgColor = Constants.GetFitsStatusColor(orderDetail.ExFactory, orderDetail.STCUnallocated, orderDetail.ParentOrder.OrderDate, orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget, orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual,
                                               orderDetail.ParentOrder.InlinePPMOrderContract.TopActualApproval, orderDetail.ParentOrder.Fits.SealDate, orderDetail.ParentOrder.FitsTrack.fitRequestedOn, orderDetail.ParentOrder.FitsTrack.NextPlannedDate, orderDetail.ParentOrder.FitsTrack.AckDate, orderDetail.ParentOrder.Fits.IsStcApproved,
                                               orderDetail.ParentOrder.FitsTrack.CommentsSentFor, orderDetail.ParentOrder.FitsTrack.PlanningFor, orderDetail.ParentOrder.InlinePPMOrderContract.TopStatus, orderDetail.ParentOrder.Fits.SpecsUploadTargetDate, orderDetail.ParentOrder.Fits.SpecsUploadDate);
                        

                        orderDetailCollection.Add(orderDetail);
                    }
                }
                cnx.Close();
                return orderDetailCollection;
            }
        }


        public List<OrderDetail> GetManagingOrderSummaryReport(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, int ClientID, int SortedBy1, int SortedBy2, int SortedBy3, int SortedBy4, out int TotalQuantity, int FactoryManagerID, int userId, DateTime FromDate, DateTime ToDate)
        {
            TotalRowCount = 0;
            TotalQuantity = 0;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();
                int result;

                try
                {
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_reports_get_order_summary_reports_with_paging";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsorderDetail = new DataSet();

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

                    param = new SqlParameter("@Client", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderBy1", SqlDbType.Int);
                    param.Value = SortedBy1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    
                    param = new SqlParameter("@OrderBy2", SqlDbType.Int);
                    param.Value = SortedBy2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    
                    param = new SqlParameter("@OrderBy3", SqlDbType.Int);
                    param.Value = SortedBy3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    
                    param = new SqlParameter("@OrderBy4", SqlDbType.Int);
                    param.Value = SortedBy4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryManagerID", SqlDbType.Int);
                    param.Value = FactoryManagerID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    
                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = userId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                    if ((FromDate == DateTime.MinValue) || (FromDate == Convert.ToDateTime("1753-01-01")) || (FromDate == Convert.ToDateTime("1900-01-01")))
                    // if (FromDate != DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                      
                        param.Value = FromDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                    if ((ToDate == DateTime.MinValue) || (ToDate == Convert.ToDateTime("1753-01-01")) || (ToDate == Convert.ToDateTime("1900-01-01")))
                    // if (ToDate != DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                      
                    }
                    else
                    {
                        param.Value = ToDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsorderDetail);

                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];
                        DataTable dt1 = dsorderDetail.Tables[1];
                        DataTable dtTotalQty = dsorderDetail.Tables[2];
                        DataTable dtRowCount = dsorderDetail.Tables[3];
                        
                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow reader in dt.Rows)
                            {
                                OrderDetail orderDetail = new OrderDetail();
                                orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                                orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                                orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                                orderDetail.Description = (reader["OrderDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OrderDescription"]);
                                orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                                orderDetail.MDANumber = (reader["MDA"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MDA"]);
                                orderDetail.Mode = (reader["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Mode"]);
                                orderDetail.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                                orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                                orderDetail.WeekToEx = Convert.ToInt32(reader["WeekToEx"]);
                                orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                                orderDetail.WeeksToDC = Convert.ToInt32(reader["WeeksToDC"]);
                                orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                                orderDetail.STCUnallocated = (reader["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(reader["STCUnallocated"]) : DateTime.MinValue;
                                orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                                orderDetail.CuttingETA = (reader["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["CuttingETA"]) : DateTime.MinValue;
                                orderDetail.PackingETA = (reader["PackingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["PackingETA"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                                orderDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                                orderDetail.BulkTarget = (reader["BulkTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkTarget"]) : DateTime.MinValue;
                                orderDetail.LabDipTarget = (reader["LabDipTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["LabDipTarget"]) : DateTime.MinValue;
                                orderDetail.BulkApprovalTarget = (reader["BulkApprovalTarget"] != DBNull.Value) ? Convert.ToDateTime(reader["BulkApprovalTarget"]) : DateTime.MinValue;
                                string SanjeevRemarks = reader["SanjeevRemarks"] == DBNull.Value ? string.Empty : reader["SanjeevRemarks"].ToString();
                                orderDetail.SanjeevRemarks = SanjeevRemarks;
                                orderDetail.PlannedEx = reader["PlannedExDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["PlannedExDate"]);

                                orderDetail.ParentOrder = new Order();
                                orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                                orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);

                                orderDetail.ParentOrder.Style = new Style();
                                orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                                orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(reader["StyleID"]);
                                orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                                orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                                orderDetail.ParentOrder.Style.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);

                                orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                                orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                                orderDetail.ParentOrder.Style.cdept.DeptID = (reader["ClientDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientDepartmentID"]) : 0;
                                orderDetail.ParentOrder.Style.cdept.Mon = (reader["Mon"] != DBNull.Value) ? Convert.ToInt32(reader["Mon"]) : 0;
                                orderDetail.ParentOrder.Style.cdept.Tue = (reader["Tue"] != DBNull.Value) ? Convert.ToInt32(reader["Tue"]) : 0;
                                orderDetail.ParentOrder.Style.cdept.Wed = (reader["Wed"] != DBNull.Value) ? Convert.ToInt32(reader["Wed"]) : 0;
                                orderDetail.ParentOrder.Style.cdept.Thu = (reader["Thu"] != DBNull.Value) ? Convert.ToInt32(reader["Thu"]) : 0;
                                orderDetail.ParentOrder.Style.cdept.Fri = (reader["Fri"] != DBNull.Value) ? Convert.ToInt32(reader["Fri"]) : 0;

                                orderDetail.ParentOrder.Style.client = new Client();
                                orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(reader["ClientID"]);
                                orderDetail.ParentOrder.Style.client.CompanyName = reader["Buyer"].ToString();

                                orderDetail.ParentOrder.InlinePPMOrderContract = new InlinePPMOrderContract(); // to get top send target and top send actual
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget = (reader["TopSentTarget"] == DBNull.Value) ? orderDetail.StitchingETA : Convert.ToDateTime(reader["TopSentTarget"]);
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual = (reader["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["TopSentActual"]);
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopActualApproval = (reader["TopActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["TopActualApproval"]);
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopStatus = (reader["TopStatus"] == DBNull.Value) ? TopStatusType.UNKNOWN : (TopStatusType)Convert.ToInt32(reader["TopStatus"]);

                                orderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["StatusModeID"]);// Add this

                                orderDetail.ParentOrder.Fits = new Fits();
                                orderDetail.ParentOrder.Fits.StyleCode = (reader["StyleCode"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleCode"]);
                                orderDetail.ParentOrder.Fits.IsStcApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);
                                orderDetail.ParentOrder.Fits.SealDate = (reader["SealDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SealDate"]);
                                orderDetail.ParentOrder.Fits.SpecsUploadTargetDate = (reader["SpecsUploadTargetDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SpecsUploadTargetDate"]);
                                orderDetail.ParentOrder.Fits.SpecsUploadDate = (reader["SpecsUploadDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SpecsUploadDate"]);
                                orderDetail.ParentOrder.Fits.StyleCodeVersion = (reader["StyleCodeVersion"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleCodeVersion"]);

                                orderDetail.ParentOrder.FitsTrack = new FitsTrack();
                                orderDetail.ParentOrder.FitsTrack.CommentsSentFor = (reader["CommentsSentFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CommentsSentFor"]);
                                orderDetail.ParentOrder.FitsTrack.PlanningFor = (reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]);
                                orderDetail.ParentOrder.FitsTrack.fitRequestedOn = (reader["fitRequestedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["fitRequestedOn"]);
                                orderDetail.ParentOrder.FitsTrack.AckDate = (reader["AckDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AckDate"]);
                                orderDetail.ParentOrder.FitsTrack.NextPlannedDate = (reader["NextPlannedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["NextPlannedDate"]);

                                orderDetail.FitStatus = Constants.GetFitsStatus(orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual, orderDetail.ParentOrder.InlinePPMOrderContract.TopActualApproval, orderDetail.ParentOrder.Fits.IsStcApproved, orderDetail.ParentOrder.Fits.SealDate,
                                    orderDetail.ParentOrder.FitsTrack.CommentsSentFor, orderDetail.ParentOrder.FitsTrack.PlanningFor, orderDetail.ParentOrder.FitsTrack.fitRequestedOn, orderDetail.ParentOrder.FitsTrack.AckDate, orderDetail.ParentOrder.InlinePPMOrderContract.TopStatus,
                                    orderDetail.ParentOrder.Fits.SpecsUploadTargetDate, orderDetail.ParentOrder.Fits.SpecsUploadDate);

                                orderDetail.FitStatusBgColor = Constants.GetFitsStatusColor(orderDetail.ExFactory, orderDetail.STCUnallocated, orderDetail.ParentOrder.OrderDate, orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget, orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual,
                                                       orderDetail.ParentOrder.InlinePPMOrderContract.TopActualApproval, orderDetail.ParentOrder.Fits.SealDate, orderDetail.ParentOrder.FitsTrack.fitRequestedOn, orderDetail.ParentOrder.FitsTrack.NextPlannedDate, orderDetail.ParentOrder.FitsTrack.AckDate, orderDetail.ParentOrder.Fits.IsStcApproved,
                                                       orderDetail.ParentOrder.FitsTrack.CommentsSentFor, orderDetail.ParentOrder.FitsTrack.PlanningFor, orderDetail.ParentOrder.InlinePPMOrderContract.TopStatus, orderDetail.ParentOrder.Fits.SpecsUploadTargetDate, orderDetail.ParentOrder.Fits.SpecsUploadDate);

                                orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
                                orderDetail.ParentOrder.StitchingDetail.ProdRemarks = (reader["ProdRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProdRemarks"]);

                                orderDetail.Unit = new ProductionUnit();
                                orderDetail.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                                orderDetail.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);
                                orderDetail.Unit.ProductionUnitColor = (reader["ProductionUnitColor"] == DBNull.Value || Convert.ToString(reader["ProductionUnitColor"]) == string.Empty) ? "#ffffff" : Convert.ToString(reader["ProductionUnitColor"]);

                                orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                                orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                                orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                                orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
                                
                                var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                                    result = 0;
                                }

                                var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                                    result = 0;
                                }

                                var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                                    result = 0;
                                }

                                var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                                    result = 0;
                                }

                                orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                                orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                                orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                                orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                                orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (reader["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse1"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (reader["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse2"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (reader["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse3"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (reader["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse4"]);

                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate1 = (reader["Date1"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date1"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate2 = (reader["Date2"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date2"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate3 = (reader["Date3"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date3"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate4 = (reader["Date4"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date4"]);

                                string strx = "OrderDetailID =" + orderDetail.OrderDetailID;
                                DataRow[] DataRows1;
                                DataRows1 = dt1.Select(strx);
                                int F1Status = 0;
                                int F2Status = 0;
                                int F3Status = 0;
                                int F4Status = 0;

                                int F1Stage = 0;
                                int F2Stage = 0;
                                int F3Stage = 0;
                                int F4Stage = 0;

                                DateTime ActionDate1 = DateTime.MinValue;
                                DateTime ActionDate2 = DateTime.MinValue;
                                DateTime ActionDate3 = DateTime.MinValue;
                                DateTime ActionDate4 = DateTime.MinValue;
                                foreach (DataRow dr1 in DataRows1)
                                {
                                    F1Status = (dr1["F1Status"] != DBNull.Value) ? Convert.ToInt32(dr1["F1Status"]) : 0;
                                    F2Status = (dr1["F2Status"] != DBNull.Value) ? Convert.ToInt32(dr1["F2Status"]) : 0;
                                    F3Status = (dr1["F3Status"] != DBNull.Value) ? Convert.ToInt32(dr1["F3Status"]) : 0;
                                    F4Status = (dr1["F4Status"] != DBNull.Value) ? Convert.ToInt32(dr1["F4Status"]) : 0;

                                    F1Stage = (dr1["F1Stage"] != DBNull.Value) ? Convert.ToInt32(dr1["F1Stage"]) : 0;
                                    F2Stage = (dr1["F2Stage"] != DBNull.Value) ? Convert.ToInt32(dr1["F2Stage"]) : 0;
                                    F3Stage = (dr1["F3Stage"] != DBNull.Value) ? Convert.ToInt32(dr1["F3Stage"]) : 0;
                                    F4Stage = (dr1["F4Stage"] != DBNull.Value) ? Convert.ToInt32(dr1["F4Stage"]) : 0;

                                    ActionDate1 = (dr1["ActionDate1"] != DBNull.Value) ? Convert.ToDateTime(dr1["ActionDate1"]) : DateTime.MinValue;
                                    ActionDate2 = (dr1["ActionDate2"] != DBNull.Value) ? Convert.ToDateTime(dr1["ActionDate2"]) : DateTime.MinValue;
                                    ActionDate3 = (dr1["ActionDate3"] != DBNull.Value) ? Convert.ToDateTime(dr1["ActionDate3"]) : DateTime.MinValue;
                                    ActionDate4 = (dr1["ActionDate4"] != DBNull.Value) ? Convert.ToDateTime(dr1["ActionDate4"]) : DateTime.MinValue;
                                }

                                orderDetail.ParentOrder.FabricApprovalDetails = new FabricApprovalDetails();
                                orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus = Constants.GetFabricStatus(F1Stage, F1Status, ActionDate1);
                                orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus = Constants.GetFabricStatus(F2Stage, F2Status, ActionDate2);
                                orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus = Constants.GetFabricStatus(F3Stage, F3Status, ActionDate3);
                                orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus = Constants.GetFabricStatus(F4Stage, F4Status, ActionDate4);
                                
                                orderDetailCollection.Add(orderDetail);
                            }

                            if (dtTotalQty != null && dtTotalQty.Rows.Count > 0)
                            {
                                TotalQuantity = (dtTotalQty.Rows[0]["TotalQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dtTotalQty.Rows[0]["TotalQuantity"]);
                            }

                            if (dtRowCount != null && dtRowCount.Rows.Count > 0)
                            {
                                TotalRowCount = (dtRowCount.Rows[0]["RowCount"] == DBNull.Value) ? 0 : Convert.ToInt32(dtRowCount.Rows[0]["RowCount"]);
                            }
                        }                      
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                
                return orderDetailCollection;
            }
        }

             
        public DataSet GetFabricPendingApprovalReport(int PageSize, int PageIndex, out int TotalRowCount, int ClientID, int DepartmentID, int Stage)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_reports_fabric_approval_pending";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //Edit by surendra on 10 jan 2013
                //cmd.CommandTimeout = 3600;
                //end
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
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Stage", SqlDbType.Int);
                param.Value = Stage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsPendingFabricApproval = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsPendingFabricApproval);

                cnx.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return dsPendingFabricApproval;
            }
        }



        public DataSet GetFITsReport(int PageSize, int PageIndex, out int TotalRowCount, int ClientID, int DepartmentID, DateTime SuggestedFitsDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fits";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
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
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SuggestedFitsDate", SqlDbType.DateTime);
                param.Value = SuggestedFitsDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                
                DataSet dsFITs = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsFITs);

                cnx.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return dsFITs;
            }
        }


        public DataSet GetClientDepartmentSalesReport(int ClientID, int Year, int DateType, int PriceType,int BuyingHouseId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_client_department_qty_revenue_breakdown";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                param.Value = BuyingHouseId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsClientDeptSalesReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsClientDeptSalesReport);

                cnx.Close();

                return dsClientDeptSalesReport;
            }
        }


        public DataSet GetOverallSalesReport(int Year, int DateType, int PriceType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_orders_qty_revenue_breakdown";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsOverallSalesReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsOverallSalesReport);

                cnx.Close();

                return dsOverallSalesReport;
            }
        }

        public DataSet GetOverallSalesReportTemp(int Year, int DateType, int PriceType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_orders_qty_revenue_breakdown_temp";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsOverallSalesReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsOverallSalesReport);

                cnx.Close();

                return dsOverallSalesReport;
            }
        }

        public DataSet GetOverallSalesReportById(int Year, int DateType, int PriceType,int id,int UserId,bool IsBIPL,int FactoryCode)
        {
            if (DateType == 1)// && UserId == 6)
                PriceType = 1;
            if (UserId == 5)
                UserId = 7;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "";
                if (id == 1)
                    cmdText = (IsBIPL==false) ? "sp_salesview1" : "sp_salesview1_BIPL";
                if (id == 2)
                    cmdText = (IsBIPL == false) ? "sp_salesview2" : "sp_salesview2_BIPL";
                if (id == 3)
                    cmdText = (IsBIPL == false) ? "sp_salesview3" : "sp_salesview3_BIPL";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@YearCode", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                if (IsBIPL == true)
                {
                    param = new SqlParameter("@FactoryCode", SqlDbType.Int);
                    param.Value = FactoryCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }
                DataSet dsOverallSalesReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsOverallSalesReport);

                cnx.Close();

                return dsOverallSalesReport;
            }
        }


        public DataSet GetOverallSalesReportSExecutive(int Year, int DateType, int PriceType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_orders_qty_revenue_breakdown_sexecutive";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsOverallSalesReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsOverallSalesReport);

                cnx.Close();

                return dsOverallSalesReport;
            }
        }

        public DataSet GetOverallSalesReportBuyingHouse(int Year, int DateType, int PriceType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_orders_qty_revenue_breakdown_buyinghouse";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsOverallSalesReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsOverallSalesReport);

                cnx.Close();

                return dsOverallSalesReport;
            }
        }

        public DataSet GetClientQuantityRevenueReport(int Year, int DateType, int PriceType,int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_client_qty_revenue_breakdown";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsClientQuantityRevenueReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsClientQuantityRevenueReport);

                cnx.Close();

                return dsClientQuantityRevenueReport;
            }
        }

        public DataSet GetClientAllReport(int Year, int DateType, int PriceType,int UserId,bool IsBIPL,int FactoryCode)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                //string cmdText = "sp_clientreport_Quarter";
                string cmdText = "sp_reports_orders_qty_revenue_breakdown_sub_clientreport";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceType", SqlDbType.Int);
                param.Value = PriceType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                if (IsBIPL == true)
                {
                    param = new SqlParameter("@FactoryCode", SqlDbType.Int);
                    param.Value = FactoryCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }

                DataSet dsClientQuantityRevenueReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsClientQuantityRevenueReport);

                cnx.Close();

                return dsClientQuantityRevenueReport;
            }
        }

        public DataSet GetDhrByDesigner(int Year,int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                 // sp_Designer_Hit_Ratio
                string cmdText = "sp_Designer_Hit_Ratio_For_All";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@YearCode", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsClientQuantityRevenueReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsClientQuantityRevenueReport);

                cnx.Close();

                return dsClientQuantityRevenueReport;
            }
        }

        public DataSet GetExFactoryQuantityReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_exfactory_quantity";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsExFactoryQuantity = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsExFactoryQuantity);

                cnx.Close();

                return dsExFactoryQuantity;
            }
        }


        public DataSet GetAllOrdersOnStyle(string styleNumber, string OrderIDList, bool AllOrders)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_all_orders_on_style";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = styleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AllOrders", SqlDbType.Bit);
                param.Value = (AllOrders) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderIDList", SqlDbType.VarChar);
                param.Value = OrderIDList;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsStyles = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsStyles);

                cnx.Close();

                return dsStyles;
            }
        }


        public DataSet GetPendingBuyerOrderForms(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_pending_buyer_order_forms_on_style";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPendingBuyers = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPendingBuyers);

                cnx.Close();

                return dsPendingBuyers;
            }
        }

        public DataSet GetSealingPerformance(int OrderDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_sealing_performance";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@OrderDatePeriod", SqlDbType.Int);
                param.Value = OrderDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsSealing = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsSealing);

                cnx.Close();

                return dsSealing;
            }
        }

        public DataSet GetExFactoryMakeUpReport(int Year, int DateType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_laura_vikrant_qty_breakdown";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsOverallSalesReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsOverallSalesReport);

                cnx.Close();

                return dsOverallSalesReport;
            }
        }

        public DataSet GetFabricPerformance(int OrderDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fabric_performance";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@OrderDatePeriod", SqlDbType.Int);
                param.Value = OrderDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                cnx.Close();

                return dsFabric;
            }
        }

        public DataSet GetAccessoryPerformance(int OrderDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_accessory_performance";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@OrderDatePeriod", SqlDbType.Int);
                param.Value = OrderDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessory);

                cnx.Close();

                return dsAccessory;
            }
        }

        public DataSet GetFabricBaseTestPending(int PageSize, int PageIndex, out int TotalRowCount)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fabric_base_test_pending";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

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

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                cnx.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);

                return dsFabric;
            }
        }


        // Have to move it into Order data provider
        public List<OrderDetail> GetAllTopRequestedReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();
                int result;
                try
                {
                    string cmdText = "sp_manage_order_get_cutting_for_sending_top_requested_email";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsorderDetail = new DataSet();
                    



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsorderDetail);

                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];
                        DataTable dt1 = dsorderDetail.Tables[1];

                        
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {

                                OrderDetail orderDetail = new OrderDetail();
                                orderDetail.OrderDetailID = Convert.ToInt32(dr["Id"]);
                                orderDetail.LineItemNumber = (dr["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                                orderDetail.ContractNumber = (dr["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                                orderDetail.OrderID = Convert.ToInt32(dr["OrderID"]);

                                orderDetail.ParentOrder = new Order();
                                orderDetail.ParentOrder.SerialNumber = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                                orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                                orderDetail.ParentOrder.Style = new Style();
                                orderDetail.ParentOrder.Style.StyleNumber = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                                orderDetail.ParentOrder.Style.DepartmentName = (dr["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                                orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(dr["StyleID"]);
                                orderDetail.ParentOrder.Style.InLineCutDate = (dr["InLineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["InLineCutDate"]);

                                orderDetail.ParentOrder.Style.SampleImageURL1 = (dr["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL1"]);
                                orderDetail.ParentOrder.Style.SampleImageURL2 = (dr["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL2"]);
                                orderDetail.ParentOrder.Style.SampleImageURL3 = (dr["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL3"]);

                                orderDetail.Fabric1Details = (dr["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                                orderDetail.Fabric2Details = (dr["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric2Details"]);
                                orderDetail.Fabric3Details = (dr["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric3Details"]);
                                orderDetail.Fabric4Details = (dr["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric4Details"]);
                                var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                                    result = 0;

                                }

                                var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                                    result = 0;
                                }



                                var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                                    result = 0;
                                }


                                var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                                    result = 0;
                                }

                                orderDetail.Fabric1 = (dr["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1"]);
                                orderDetail.Fabric2 = (dr["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric2"]);
                                orderDetail.Fabric3 = (dr["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric3"]);
                                orderDetail.Fabric4 = (dr["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric4"]);

                                orderDetail.Quantity = Convert.ToInt32(dr["Quantity"]);
                                orderDetail.Mode = (dr["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["Mode"]);
                                orderDetail.ModeName = (dr["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Code"]);
                                orderDetail.iKandiPrice = Convert.ToDouble(dr["iKandiPrice"]);
                                orderDetail.ExFactory = (dr["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(dr["ExFactory"]) : DateTime.MinValue;
                                orderDetail.WeekToEx = Convert.ToInt32(dr["WeekToEx"]);
                                orderDetail.DC = (dr["DC"] != DBNull.Value) ? Convert.ToDateTime(dr["DC"]) : DateTime.MinValue;
                                orderDetail.WeeksToDC = Convert.ToInt32(dr["WeeksToDC"]);
                                orderDetail.OrderID = Convert.ToInt32(dr["OrderID"]);
                                string SanjeevRemarks = dr["SanjeevRemarks"].ToString();
                                orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("&&", "<br/><br/>");
                                string MerchantNotes = dr["MerchantNotes"].ToString();
                                orderDetail.MerchantNotes = MerchantNotes.Replace("&&", "<br/><br/>");
                                orderDetail.CuttingETA = (dr["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(dr["CuttingETA"]) : DateTime.MinValue;
                                orderDetail.SealETA = (dr["SealETA"] != DBNull.Value) ? Convert.ToDateTime(dr["SealETA"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (dr["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(dr["StitchingETA"]) : DateTime.MinValue;
                                orderDetail.STCUnallocated = (dr["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(dr["STCUnallocated"]) : DateTime.MinValue;

                                orderDetail.ParentOrder.Fits = new Fits();
                                orderDetail.ParentOrder.Fits.SealDate = (dr["SealDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["SealDate"]);
                                orderDetail.ParentOrder.Fits.Comments = (dr["FitsRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FitsRemarks"]);


                                orderDetail.ParentOrder.Style.client = new Client();
                                orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(dr["ClientID"]);

                                orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
                                orderDetail.ParentOrder.CuttingDetail.CuttingSheetID = -1;
                                orderDetail.ParentOrder.CuttingDetail.ID = -1;


                                string sealerBiplReamrks = (dr["RemarksBIPL"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["RemarksBIPL"]);
                                orderDetail.Remarks = sealerBiplReamrks.Replace("&&", "<br/><br/>");

                                string strx = "OrderDetailID =" + orderDetail.OrderDetailID;
                                DataRow[] DataRow;
                                DataRow = dt1.Select(strx);

                                foreach (DataRow dr2 in DataRow)
                                {
                                    orderDetail.ParentOrder.CuttingDetail.ID = Convert.ToInt32(dr2["CuttingDetailID"]);
                                    orderDetail.ParentOrder.CuttingDetail.PcsCut = (dr2["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["PcsCut"]);
                                    orderDetail.ParentOrder.CuttingDetail.PcsIssued = (dr2["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["PcsIssued"]);
                                    orderDetail.ParentOrder.CuttingDetail.PercentagePcsCut = 0;
                                    if (orderDetail.Quantity > 0)
                                    {
                                        orderDetail.ParentOrder.CuttingDetail.PercentagePcsCut = (orderDetail.ParentOrder.CuttingDetail.PcsCut * 100) / orderDetail.Quantity;
                                    }
                                    orderDetail.ParentOrder.CuttingDetail.PcsToBeCut = orderDetail.Quantity - orderDetail.ParentOrder.CuttingDetail.PcsCut;
                                }

                                orderDetail.Unit = new ProductionUnit();
                                orderDetail.Unit.ProductionUnitId = (dr["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UnitID"]);
                                orderDetail.Unit.FactoryName = (dr["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryName"]);
                                orderDetail.Unit.FactoryCode = (dr["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryCode"]);
                                orderDetail.Unit.ProductionUnitColor = (dr["ProductionUnitColor"] == DBNull.Value || Convert.ToString(dr["ProductionUnitColor"]) == string.Empty) ? "#ffffff" : Convert.ToString(dr["ProductionUnitColor"]);

                                orderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (dr["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StatusMode"]);
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusModeID = (dr["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StatusModeID"]);// Add this

                                orderDetail.ParentOrder.InlinePPMOrderContract = new InlinePPMOrderContract();
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual = (dr["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TopSentActual"]);
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget = (dr["TopSentTarget"] == DBNull.Value) ? orderDetail.StitchingETA : Convert.ToDateTime(dr["TopSentTarget"]);

                                orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
                                orderDetail.ParentOrder.StitchingDetail.ProdRemarks = (dr["ProdRemarks"] == DBNull.Value) ? string.Empty : dr["ProdRemarks"].ToString();

                                orderDetail.ParentOrder.CuttingHistory = new CuttingHistory();
                                orderDetail.ParentOrder.CuttingHistory.Date = (dr["CuttingActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CuttingActual"]);
                                orderDetailCollection.Add(orderDetail);

                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return orderDetailCollection;
            }
        }

        public List<OrderDetail> GetAllPPMeetingPending(DateTime SentOn)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();
                int result;
                try
                {
                    string cmdText = "sp_manage_order_get_cutting_for_sending_pp_meeting_pending_email";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@Date", SqlDbType.DateTime);
                    param.Value = new DateTime(SentOn.Year, SentOn.Month, SentOn.Day, 0, 0, 0);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    DataSet dsorderDetail = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsorderDetail);

                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];
                        DataTable dt1 = dsorderDetail.Tables[1];
                        DataTable dt2 = dsorderDetail.Tables[2];
                        DataTable dt3 = dsorderDetail.Tables[3];
                        DataTable dt4 = dsorderDetail.Tables[4];

                        
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {

                                OrderDetail orderDetail = new OrderDetail();
                                orderDetail.OrderDetailID = Convert.ToInt32(dr["Id"]);
                                orderDetail.LineItemNumber = (dr["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                                orderDetail.ContractNumber = (dr["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ContractNumber"]);
                                orderDetail.OrderID = Convert.ToInt32(dr["OrderID"]);

                                orderDetail.ParentOrder = new Order();
                                orderDetail.ParentOrder.SerialNumber = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);
                                orderDetail.ParentOrder.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                               
                                orderDetail.ParentOrder.Style = new Style();
                                orderDetail.ParentOrder.Style.StyleNumber = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                                orderDetail.ParentOrder.Style.DepartmentName = (dr["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                                orderDetail.ParentOrder.Style.StyleID = Convert.ToInt32(dr["StyleID"]);
                                orderDetail.ParentOrder.Style.InLineCutDate = (dr["InLineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["InLineCutDate"]);

                                orderDetail.ParentOrder.Style.SampleImageURL1 = (dr["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL1"]);
                                orderDetail.ParentOrder.Style.SampleImageURL2 = (dr["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL2"]);
                                orderDetail.ParentOrder.Style.SampleImageURL3 = (dr["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL3"]);

                                orderDetail.Fabric1Details = (dr["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                                orderDetail.Fabric2Details = (dr["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric2Details"]);
                                orderDetail.Fabric3Details = (dr["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric3Details"]);
                                orderDetail.Fabric4Details = (dr["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric4Details"]);
                                var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                                    result = 0;
                                }

                                var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                                    result = 0;
                                }

                                var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                                    result = 0;
                                }

                                var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                                    result = 0;
                                }

                                orderDetail.Fabric1 = (dr["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1"]);
                                orderDetail.Fabric2 = (dr["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric2"]);
                                orderDetail.Fabric3 = (dr["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric3"]);
                                orderDetail.Fabric4 = (dr["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric4"]);

                                orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (dr["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PercentInHouse1"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (dr["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PercentInHouse2"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (dr["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PercentInHouse3"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (dr["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PercentInHouse4"]);
                                
                                orderDetail.Quantity = Convert.ToInt32(dr["Quantity"]);
                                orderDetail.Mode = (dr["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["Mode"]);
                                orderDetail.ModeName = (dr["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Code"]);
                                orderDetail.iKandiPrice = Convert.ToDouble(dr["iKandiPrice"]);
                                orderDetail.ExFactory = (dr["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(dr["ExFactory"]) : DateTime.MinValue;
                                orderDetail.WeekToEx = Convert.ToInt32(dr["WeekToEx"]);
                                orderDetail.DC = (dr["DC"] != DBNull.Value) ? Convert.ToDateTime(dr["DC"]) : DateTime.MinValue;
                                orderDetail.WeeksToDC = Convert.ToInt32(dr["WeeksToDC"]);
                                orderDetail.OrderID = Convert.ToInt32(dr["OrderID"]);
                                string SanjeevRemarks = dr["SanjeevRemarks"].ToString();
                                orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("&&", "<br/><br/>");
                                string MerchantNotes = dr["MerchantNotes"].ToString();
                                orderDetail.MerchantNotes = MerchantNotes.Replace("&&", "<br/><br/>");
                                orderDetail.CuttingETA = (dr["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(dr["CuttingETA"]) : DateTime.MinValue;
                                orderDetail.SealETA = (dr["SealETA"] != DBNull.Value) ? Convert.ToDateTime(dr["SealETA"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (dr["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(dr["StitchingETA"]) : DateTime.MinValue;
                                orderDetail.STCUnallocated = (dr["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(dr["STCUnallocated"]) : DateTime.MinValue;

                                orderDetail.ParentOrder.Fits = new Fits();
                                orderDetail.ParentOrder.Fits.SealDate = (dr["SealDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["SealDate"]);

                                orderDetail.ParentOrder.Style.client = new Client();
                                orderDetail.ParentOrder.Style.client.ClientID = Convert.ToInt32(dr["ClientID"]);

                                orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
                                orderDetail.ParentOrder.CuttingDetail.CuttingSheetID = -1;
                                orderDetail.ParentOrder.CuttingDetail.ID = -1;

                                string str = "OrderID =" + orderDetail.OrderID;
                                DataRow[] DataRow1;
                                DataRow1 = dt1.Select(str);

                                foreach (DataRow dr2 in DataRow1)
                                {
                                    orderDetail.ParentOrder.CuttingDetail.CuttingSheetID = Convert.ToInt32(dr2["CuttingSheetID"]);
                                }

                                string strx = "OrderDetailID =" + orderDetail.OrderDetailID;
                                DataRow[] DataRow;
                                DataRow = dt2.Select(strx);

                                foreach (DataRow dr2 in DataRow)
                                {
                                    orderDetail.ParentOrder.CuttingDetail.ID = Convert.ToInt32(dr2["CuttingDetailID"]);
                                    orderDetail.ParentOrder.CuttingDetail.PcsCut = (dr2["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["PcsCut"]);
                                    orderDetail.ParentOrder.CuttingDetail.PcsIssued = (dr2["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["PcsIssued"]);
                                    orderDetail.ParentOrder.CuttingDetail.PercentagePcsCut = 0;
                                    if (orderDetail.Quantity > 0)
                                    {
                                        orderDetail.ParentOrder.CuttingDetail.PercentagePcsCut = (orderDetail.ParentOrder.CuttingDetail.PcsCut * 100) / orderDetail.Quantity;
                                    }
                                    orderDetail.ParentOrder.CuttingDetail.PcsToBeCut = orderDetail.Quantity - orderDetail.ParentOrder.CuttingDetail.PcsCut;
                                }
                                orderDetail.ParentOrder.AccessoryInHouseHistory = new AccessoryInHouseHistory();
                                
                                DataRow[] DataRows;
                                DataRows = dt3.Select(strx);
                                foreach (DataRow dr4 in DataRows)
                                {
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.Date = (dr4["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr4["Date"]);
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse = (dr4["PercentInHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(dr4["PercentInHouse"]);
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName = (dr4["AccessoryName"] == DBNull.Value) ? string.Empty : dr4["AccessoryName"].ToString();
                                    orderDetail.AccessoryHistory += orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse + "% on" + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.Date.ToString("dd MMM yy (ddd)") + "<br/><br/>";

                                }

                                DataRow[] DataRows2;
                                DataRows2 = dt4.Select(str);
                                foreach (DataRow dr5 in DataRows2)
                                {
                                    string AccessoryName = (dr5["AccessoryName"] == DBNull.Value) ? string.Empty : dr5["AccessoryName"].ToString();
                                    if (orderDetail.AccessoryHistory != null && orderDetail.AccessoryHistory != string.Empty)
                                    {
                                        if (orderDetail.AccessoryHistory.IndexOf(AccessoryName) == -1)
                                        {
                                            orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                    }

                                }

                                orderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (dr["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StatusMode"]);
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusModeID = (dr["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StatusModeID"]);// Add this

                                orderDetail.ParentOrder.InlinePPMOrderContract = new InlinePPMOrderContract();
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual = (dr["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TopSentActual"]);
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget = (dr["TopSentTarget"] == DBNull.Value) ? orderDetail.StitchingETA : Convert.ToDateTime(dr["TopSentTarget"]);

                                orderDetail.ParentOrder.CuttingHistory = new CuttingHistory();
                                orderDetail.ParentOrder.CuttingHistory.Date = (dr["CuttingActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CuttingActual"]);

                                orderDetail.Unit = new ProductionUnit();
                                orderDetail.Unit.ProductionUnitId = (dr["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UnitID"]);
                                orderDetail.Unit.FactoryName = (dr["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryName"]);
                                orderDetail.Unit.FactoryCode = (dr["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryCode"]);
                                
                                orderDetailCollection.Add(orderDetail);
                                
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return orderDetailCollection;
            }
        }

        public List<OrderDetail> GetAllQAPendingFromProductionReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();
                int result;
                String cmdText;

                try
                {
                    cmdText = "sp_reoprts_for_sending_production_reports_qa_panding_email";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsorderDetail = new DataSet();                   
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsorderDetail);

                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];
                        DataTable dt1 = dsorderDetail.Tables[1];
                        DataTable dt2 = dsorderDetail.Tables[2];

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dt.Rows)
                            {

                                OrderDetail orderDetail = new OrderDetail();

                                orderDetail.OrderDetailID = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]);
                                if (orderDetail.OrderDetailID == 0)
                                    continue;
                                orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                                orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                                orderDetail.SealETA = (reader["SealETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SealETA"]);
                                orderDetail.ParentOrder = new Order();
                                orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                                orderDetail.ParentOrder.OrderDate = (reader["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["OrderDate"]);
                                orderDetail.ParentOrder.Description = (reader["OrderDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OrderDescription"]);
                                orderDetail.ParentOrder.Style = new Style();
                                orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                                orderDetail.ParentOrder.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                                orderDetail.ParentOrder.Style.InLineCutDate = (reader["InlineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["InlineCutDate"]);
                                orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                                orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                                orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                                orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                                orderDetail.ParentOrder.Style.cdept.DeptID = (reader["ClientDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientDepartmentID"]) : 0;
                                orderDetail.ParentOrder.Style.client = new Client();
                                orderDetail.ParentOrder.Style.client.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);
                                orderDetail.ParentOrder.Style.client.CompanyName = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                                orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                                orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                                orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                                orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
                                var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                                    result = 0;
                                }

                                var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
                                    result = 0;
                                }

                                var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');
                                if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
                                    result = 0;
                                }

                                var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

                                if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
                                {
                                    orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
                                    result = 0;
                                }

                                orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                                orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                                orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                                orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                                orderDetail.Quantity = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity"]);

                                orderDetail.ParentOrder.ProductionPlanning = new ProductionPlanning();
                                orderDetail.ParentOrder.ProductionPlanning.ShipmentQty = (reader["ShippingQty"] == DBNull.Value) ? orderDetail.Quantity : Convert.ToInt32(reader["ShippingQty"]);

                                orderDetail.Mode = (reader["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Mode"]);
                                if (orderDetail.Mode != 0)
                                    orderDetail.ModeName = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                                orderDetail.iKandiPrice = (reader["iKandiPrice"] == DBNull.Value) ? 0.0 : Convert.ToDouble(reader["iKandiPrice"]);
                                orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;
                                orderDetail.WeekToEx = (reader["WeekToEx"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["WeekToEx"]);
                                orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                                orderDetail.WeeksToDC = (reader["WeeksToDC"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["WeeksToDC"]);
                                orderDetail.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderID"]);
                                string SanjeevRemarks = reader["SanjeevRemarks"].ToString();
                                orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("$$", "<BR/><BR/>");
                                string MerchantNotes = reader["MerchantNotes"].ToString();
                                orderDetail.MerchantNotes = MerchantNotes.Replace("$$", "<BR/><BR/>");
                                orderDetail.STCUnallocated = (reader["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(reader["STCUnallocated"]) : DateTime.MinValue;

                                orderDetail.AllocationDate = (reader["AllocationDate"] != DBNull.Value) ? Convert.ToDateTime(reader["AllocationDate"]) : DateTime.MinValue;
                                orderDetail.ProductionUnitId = (reader["UnitID"] != DBNull.Value) ? Convert.ToInt32(reader["UnitID"]) : 0;
                                orderDetail.IsAllocated = (reader["IsAllocated"] != DBNull.Value) ? Convert.ToBoolean(reader["IsAllocated"]) : false;
                                orderDetail.CuttingETA = (reader["CuttingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["CuttingETA"]) : DateTime.MinValue;
                                orderDetail.PackingETA = (reader["PackingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["PackingETA"]) : DateTime.MinValue;
                                orderDetail.StitchingETA = (reader["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(reader["StitchingETA"]) : DateTime.MinValue;

                                orderDetail.ParentOrder.InlinePPMOrderContract = new InlinePPMOrderContract(); // to get top send target and top send actual
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget = (reader["TopSentTarget"] == DBNull.Value) ? orderDetail.STCUnallocated : Convert.ToDateTime(reader["TopSentTarget"]);
                                orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual = (reader["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["TopSentActual"]);


                                orderDetail.Unit = new ProductionUnit();
                                orderDetail.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitID"]);
                                orderDetail.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
                                orderDetail.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);

                                orderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (reader["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StatusMode"]);
                                orderDetail.ParentOrder.WorkflowInstanceDetail.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);// Add this

                                orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
                                orderDetail.ParentOrder.CuttingDetail.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);
                                orderDetail.ParentOrder.CuttingDetail.PcsIssued = (reader["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsIssued"]);

                                orderDetail.ParentOrder.CuttingHistory = new CuttingHistory();
                                orderDetail.ParentOrder.CuttingHistory.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);
                                if (orderDetail.Quantity != 0)
                                    orderDetail.ParentOrder.CuttingHistory.PercentagePcsCut = (orderDetail.ParentOrder.CuttingHistory.PcsCut * 100) / orderDetail.Quantity;
                                orderDetail.ParentOrder.CuttingHistory.Date = (reader["CuttingActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CuttingActual"]);

                                orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
                                orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched = (reader["PcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsStitched"]);
                                orderDetail.ParentOrder.StitchingDetail.OverallPcsPacked = (reader["PcsPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsPacked"]);

                                if (orderDetail.Quantity != 0)
                                {
                                    orderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsStitched = (orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched * 100) / orderDetail.Quantity;
                                    orderDetail.ParentOrder.StitchingDetail.PercentageOverallPcsPacked = (orderDetail.ParentOrder.StitchingDetail.OverallPcsPacked * 100) / orderDetail.Quantity;
                                }

                                orderDetail.ParentOrder.StitchingDetail.ProdRemarks = (reader["ProdRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProdRemarks"]);
                                String[] charArr = { "$$" };
                                string[] prodremarks = orderDetail.ParentOrder.StitchingDetail.ProdRemarks.Split(charArr, StringSplitOptions.None);
                                int ProdRemarksLength = prodremarks.Length;
                                if (ProdRemarksLength > 0)
                                    orderDetail.ParentOrder.StitchingDetail.ProdRemarks = prodremarks[ProdRemarksLength - 1];

                                orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (reader["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse1"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (reader["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse2"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (reader["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse3"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (reader["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PercentInHouse4"]);

                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate1 = (reader["Date1"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date1"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate2 = (reader["Date2"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date2"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate3 = (reader["Date3"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date3"]);
                                orderDetail.ParentOrder.FabricInhouseHistory.PercentDate4 = (reader["Date4"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["Date4"]);


                                orderDetail.ParentOrder.Fits = new Fits();
                                orderDetail.ParentOrder.Fits.IsStcApproved = (reader["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["StcApproved"]);
                                orderDetail.ParentOrder.Fits.SealDate = (reader["SealDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SealDate"]);

                                orderDetail.ParentOrder.FitsTrack = new FitsTrack();
                                orderDetail.ParentOrder.FitsTrack.PlanningFor = (reader["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PlanningFor"]);
                                orderDetail.ParentOrder.FitsTrack.fitRequestedOn = (reader["fitRequestedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["fitRequestedOn"]);

                                if (orderDetail.ParentOrder.Fits.IsStcApproved == true)
                                {
                                    orderDetail.FitStatus = orderDetail.ParentOrder.FitsTrack.PlanningFor + " " + "On" + " " + orderDetail.ParentOrder.Fits.SealDate.ToString("dd MMM yy (ddd)");
                                }
                                else if (orderDetail.ParentOrder.FitsTrack.PlanningFor != string.Empty)
                                {
                                    orderDetail.FitStatus = orderDetail.ParentOrder.FitsTrack.PlanningFor + " Requested On " + orderDetail.ParentOrder.FitsTrack.fitRequestedOn.ToString("dd MMM yy (ddd)");
                                }

                                string str = "OrderID =" + orderDetail.OrderID;
                                string strx = "OrderDetailID =" + orderDetail.OrderDetailID;

                                orderDetail.ParentOrder.AccessoryInHouseHistory = new AccessoryInHouseHistory();
                                
                                DataRow[] DataRows;
                                DataRows = dt1.Select(strx);
                                foreach (DataRow dr4 in DataRows)
                                {
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.Date = (dr4["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr4["Date"]);
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse = (dr4["PercentInHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(dr4["PercentInHouse"]);
                                    orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName = (dr4["AccessoryName"] == DBNull.Value) ? string.Empty : dr4["AccessoryName"].ToString();
                                    orderDetail.AccessoryHistory += orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse + "% on" + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.Date.ToString("dd MMM yy (ddd)") + "<br/><br/>";

                                }

                                DataRow[] DataRows2;
                                DataRows2 = dt2.Select(str);
                                foreach (DataRow dr5 in DataRows2)
                                {
                                    string AccessoryName = (dr5["AccessoryName"] == DBNull.Value) ? string.Empty : dr5["AccessoryName"].ToString();
                                    if (orderDetail.AccessoryHistory != null && orderDetail.AccessoryHistory != string.Empty)
                                    {
                                        if (orderDetail.AccessoryHistory.IndexOf(AccessoryName) == -1)
                                        {
                                            orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
                                    }

                                }
                                orderDetailCollection.Add(orderDetail);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return orderDetailCollection;
            }
        }

        public List<OrderDetail> GetRejectedQaContracts(int PageSize, int PageIndex, out int TotalRowCount, int ClientID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_reports_rejected_qa_contracts";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                DataSet dsorderDetailCollection = new DataSet();

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
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetailCollection);

                if (dsorderDetailCollection.Tables[0].Rows.Count > 0)
                {
                    int result;
                    foreach (DataRow dr in dsorderDetailCollection.Tables[0].Rows)
                    {

                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(dr["Id"]);
                        orderDetail.LineItemNumber = (dr["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["LineItemNumber"]);
                        orderDetail.ContractNumber = (dr["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ContractNumber"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.SerialNumber = (dr["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SerialNumber"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleNumber = (dr["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StyleNumber"]);
                        orderDetail.ParentOrder.Style.DepartmentName = (dr["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["DepartmentName"]);
                        orderDetail.ParentOrder.Style.StyleID = (dr["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StyleID"]);

                        orderDetail.ParentOrder.Style.SampleImageURL1 = (dr["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL1"]);
                        orderDetail.ParentOrder.Style.SampleImageURL2 = (dr["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL2"]);
                        orderDetail.ParentOrder.Style.SampleImageURL3 = (dr["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SampleImageURL3"]);

                        orderDetail.Fabric1 = (dr["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1"]);
                        orderDetail.Fabric1Details = (dr["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric1Details"]);
                        var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

                        if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
                        {
                            orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
                            result = 0;

                        }

                        orderDetail.Quantity = Convert.ToInt32(dr["Quantity"]);
                        orderDetail.Mode = (dr["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["Mode"]);
                        orderDetail.ModeName = (dr["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Code"]);
                        orderDetail.MDANumber = (dr["MDA"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["MDA"]);
                        orderDetail.iKandiPrice = Convert.ToDouble(dr["iKandiPrice"]);
                        orderDetail.ExFactory = (dr["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(dr["ExFactory"]) : DateTime.MinValue;
                        orderDetail.WeekToEx = Convert.ToInt32(dr["WeekToEx"]);
                        orderDetail.DC = (dr["DC"] != DBNull.Value) ? Convert.ToDateTime(dr["DC"]) : DateTime.MinValue;
                        orderDetail.WeeksToDC = Convert.ToInt32(dr["WeeksToDC"]);
                        orderDetail.OrderID = Convert.ToInt32(dr["OrderID"]);
                        string SanjeevRemarks = dr["SanjeevRemarks"].ToString();
                        orderDetail.SanjeevRemarks = SanjeevRemarks.Replace("&&", "<br/><br/>");
                        orderDetail.StitchingETA = (dr["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(dr["StitchingETA"]) : DateTime.MinValue;
                        orderDetail.STCUnallocated = (dr["STCUnallocated"] != DBNull.Value) ? Convert.ToDateTime(dr["STCUnallocated"]) : DateTime.MinValue;

                        orderDetail.ParentOrder.InlinePPMOrderContract = new InlinePPMOrderContract(); // to get top send target and top send actual
                        orderDetail.ParentOrder.InlinePPMOrderContract.TopSentTarget = (dr["TopSentTarget"] == DBNull.Value) ? orderDetail.StitchingETA : Convert.ToDateTime(dr["TopSentTarget"]);
                        orderDetail.ParentOrder.InlinePPMOrderContract.TopSentActual = (dr["TopSentActual"] == DBNull.Value) ? orderDetail.StitchingETA : Convert.ToDateTime(dr["TopSentActual"]);
                        orderDetail.ParentOrder.InlinePPMOrderContract.TopActualApproval = (dr["TopActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TopActualApproval"]);

                        orderDetail.ParentOrder.StitchingHistory = new StitchingHistory();
                        orderDetail.ParentOrder.StitchingHistory.TotalQuantity = 0;
                        string str = "OrderDetailID=" + orderDetail.OrderDetailID;
                        DataRow[] DataRow;
                        DataRow = dsorderDetailCollection.Tables[1].Select(str);
                        foreach (DataRow dr1 in DataRow)
                        {
                            orderDetail.ParentOrder.StitchingHistory.TotalQuantity += (dr1["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dr1["Quantity"]);
                        }

                        orderDetail.ParentOrder.WorkflowInstanceDetail = new WorkflowInstanceDetail();
                        orderDetail.ParentOrder.WorkflowInstanceDetail.StatusMode = (dr["StatusMode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["StatusMode"]);
                        orderDetail.ParentOrder.WorkflowInstanceDetail.StatusModeID = (dr["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StatusModeID"]);// Add this

                        orderDetail.Unit = new ProductionUnit();
                        orderDetail.Unit.FactoryCode = (dr["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryCode"]);

                        orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
                        orderDetail.ParentOrder.StitchingDetail.ID = (dr["StitchingDetailID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["StitchingDetailID"]);
                        orderDetail.ParentOrder.StitchingDetail.CuttingReceived = (dr["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsIssued"]);
                        orderDetail.ParentOrder.StitchingDetail.CuttingPending = orderDetail.Quantity - orderDetail.ParentOrder.StitchingDetail.CuttingReceived;
                        orderDetail.ParentOrder.StitchingDetail.TotalPcsStitchedToday = (dr["TotalPcsStitchedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TotalPcsStitchedToday"]);
                        orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched = (dr["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OverallPcsStitched"]);
                        orderDetail.ParentOrder.StitchingDetail.PcsSent = (dr["PcsSent"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsSent"]);
                        orderDetail.ParentOrder.StitchingDetail.PcsReceived = (dr["PcsReceived"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsReceived"]);
                        orderDetail.ParentOrder.StitchingDetail.ExpectedFinishDate = (dr["ExpectedFinishDate"] != DBNull.Value) ? Convert.ToDateTime(dr["ExpectedFinishDate"]) : DateTime.MinValue;

                        int PcsReceivedPack = 0;
                        if (orderDetail.ParentOrder.StitchingDetail.PcsSent == 0)
                        {
                            PcsReceivedPack = (dr["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OverallPcsStitched"]);
                        }
                        else
                        {
                            PcsReceivedPack = (dr["PcsReceived"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsReceived"]);
                        }
                        orderDetail.ParentOrder.StitchingDetail.OrderQtyBal = orderDetail.Quantity - orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched;
                        orderDetail.ParentOrder.StitchingDetail.PcsReceivedPack = PcsReceivedPack;
                        orderDetail.ParentOrder.StitchingDetail.PcsPackedToday = (dr["PcsPackedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PcsPackedToday"]);
                        orderDetail.ParentOrder.StitchingDetail.OverallPcsPacked = (dr["OverallPcsPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["OverallPcsPacked"]);
                        orderDetail.ParentOrder.StitchingDetail.OrderQtyBalPck = orderDetail.Quantity - orderDetail.ParentOrder.StitchingDetail.OverallPcsPacked;
                        orderDetail.ParentOrder.StitchingDetail.ProdRemarks = (dr["ProdRemarks"] == DBNull.Value) ? string.Empty : dr["ProdRemarks"].ToString();


                        orderDetailCollection.Add(orderDetail);

                    }
                }

                cnx.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);

                return orderDetailCollection;
            }
        }

        public DataTable SaveQuoteToolInformation(string styleNumber, int[] modeIdCollection)
        {


            DataTable dtQuoteTool = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                SqlCommand cmd = null;
                SqlParameter param = null;

                try
                {
                    string cmdText = "sp_quote_tool_insert_quote_tool";

                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    foreach (int modeId in modeIdCollection)
                    {
                        cmd = new SqlCommand(cmdText, cnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        SqlParameter outParam = new SqlParameter("@StyleId", SqlDbType.Int);
                        outParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outParam);

                        param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                        param.Value = styleNumber;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ModeId", SqlDbType.Int);
                        param.Value = modeId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();

                        int styleId = outParam.Value == null ? -1 : Convert.ToInt32(outParam.Value);

                        if (styleId > 0)
                        {
                            dtQuoteTool.Merge(GetQuoteToolInformation(cnx, styleId, modeId));
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dtQuoteTool;
        }

        public bool DeleteQuoteToolInformation()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quote_tool_delete_quote_tool";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return false;
        }

        public DataTable GetAllQuoteToolInformation()
        {
            DataTable dtQuoteTool = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_quote_tool_get_all_quote_tool";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataTable dtStyleModeIds = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtStyleModeIds);

                    foreach (DataRow dr in dtStyleModeIds.Rows)
                    {
                        int styleId = (dr["StyleId"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["StyleId"]);
                        int modeId = (dr["ModeId"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["ModeId"]);

                        dtQuoteTool.Merge(GetQuoteToolInformation(cnx, styleId, modeId));
                    }
                }
                catch (Exception ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dtQuoteTool;
        }











        public DataSet GetPrintsPerformanceReport(string Duration)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataSet dsPrintsPerformanceReport = new DataSet();
              
                    string cmdText = "sp_reports_get_print_performance_report";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Duration", SqlDbType.VarChar);
                    param.Value = Duration;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsPrintsPerformanceReport);
                    cnx.Close();

                return dsPrintsPerformanceReport;
            }
        }

        private DataTable GetQuoteToolInformation(SqlConnection cnx, int styleId, int modeId)
        {
            string subCmdText = "sp_quote_tool_get_quote_information_from_style_and_mode";

            SqlCommand cmd = new SqlCommand(subCmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@StyleId", SqlDbType.Int);
            param.Value = styleId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeName", SqlDbType.VarChar);
            // param.Value = (modeId == 5) ? "FOB" : Constants.GetOrderDeliveryMode(modeId).Replace("/", string.Empty);
            param.Value = Constants.GetQuoteToolMode(modeId);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            DataTable dtQuoteTool = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dtQuoteTool);

            return dtQuoteTool;
        }

        public DataSet GetBestSellers(int PageSize, int PageIndex, out int TotalRowCount, int IsBest, int Limit)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_bestsellers";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

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

                param = new SqlParameter("@Best", SqlDbType.Int);
                param.Value = IsBest;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Limit", SqlDbType.Int);
                param.Value = Limit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsBestSellers = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsBestSellers);

                cnx.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);

                return dsBestSellers;
            }
        }

        public DataSet GetFabricPrices(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, string PriceFrom, string PriceTo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fabric_prices";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

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

                param = new SqlParameter("@PriceFrom", SqlDbType.Float);
                if (!String.IsNullOrEmpty(PriceFrom))
                    param.Value = Convert.ToDouble(PriceFrom);
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PriceTo", SqlDbType.Float);
                if (!String.IsNullOrEmpty(PriceTo))
                    param.Value = Convert.ToDouble(PriceTo);
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricPrices = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricPrices);

                cnx.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);

                return dsFabricPrices;
            }
        }

        public DataSet GetIndAndPrintCostReport(DateTime FromDate, DateTime ToDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_get_ind_cost_and_print_cost";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param.Value = FromDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param.Value = ToDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsIndPrintReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsIndPrintReport);

                cnx.Close();

                return dsIndPrintReport;
            }
        }

        public DataSet GetHitRateForDesigners(int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_report_hit_rate_for_designers";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsHitRateForDesigners = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsHitRateForDesigners);

                cnx.Close();

                return dsHitRateForDesigners;
            }
        }

        public DataSet GetDesignerMonthlyWork(int Year)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_designer_monthly_work";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsDesignerMonthlyWork = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsDesignerMonthlyWork);

                cnx.Close();

                return dsDesignerMonthlyWork;
            }
        }

        public DataSet GetDesignersHitRate(int Year)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_report_designer_hit_rate";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = Year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet dsHitRateForDesigners = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsHitRateForDesigners);

                cnx.Close();

                return dsHitRateForDesigners;
            }
        }

        public DataSet GetAllFitDays()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fit_days";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataSet allFitDays = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(allFitDays);

                cnx.Close();

                return allFitDays;
            }
        }

        public DataSet GetAllFitDays(int start, int pageSize, out int totalRecords)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fit_days";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param;

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = start;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Count", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);


                DataSet allFitDays = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(allFitDays);

                cnx.Close();
                totalRecords = Convert.ToInt32(param.Value);

                return allFitDays;
            }
        }
        public DataSet GetProductionEmailContaintWeekly()
        {
            DataSet dsProductionContaint = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                try
                {
                    string cmdText = "sp_ProductionReportWeekly";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsProductionContaint);

                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return dsProductionContaint;
            }
        }

        public DataSet GetProductionEmailContaintDaily()
        {
            DataSet dsProductionContaint = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                try
                {
                    string cmdText = "sp_GetProductionReportDaily";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsProductionContaint);

                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return dsProductionContaint;
            }
        }

        public List<OrderDetail> GetProductionEmailContaint()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                try
                {
                    string cmdText = "sp_send_production_email_body_containt";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Date", SqlDbType.DateTime);
                    param.Value = DateTime.Today.AddDays(-1);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsProductionContaint = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsProductionContaint);
                    if (dsProductionContaint.Tables.Count > 0)
                    {
                        if (dsProductionContaint.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtFactoryCode = dsProductionContaint.Tables[0];
                            DataTable dtPcsCutToday = dsProductionContaint.Tables[1];
                            DataTable dtPcsStitchedToday = dsProductionContaint.Tables[2];
                            DataTable dtBalofMach = dsProductionContaint.Tables[3];
                            DataTable dtPcsPackedToday = dsProductionContaint.Tables[4];
                            DataTable dtPcsExFactoriedToday = dsProductionContaint.Tables[5];
                            DataTable dtOverallPcsStitched = dsProductionContaint.Tables[6];

                            if (dtFactoryCode.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtFactoryCode.Rows)
                                {

                                    OrderDetail orderDetail = new OrderDetail();
                                    orderDetail.ParentOrder = new Order();
                                    orderDetail.Unit = new ProductionUnit();
                                    orderDetail.ParentOrder.CuttingHistory = new CuttingHistory();
                                    orderDetail.ParentOrder.StitchingHistory = new StitchingHistory();
                                    orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
                                    orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();

                                    orderDetail.Unit.ProductionUnitId = (dr["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ProductionUnitId"]);
                                    orderDetail.Unit.FactoryName = (dr["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryName"]);
                                    orderDetail.Unit.FactoryCode = (dr["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FactoryCode"]);

                                    string strPcsCutToday = "UnitID =" + orderDetail.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsCut;
                                    DataRowPcsCut = dtPcsCutToday.Select(strPcsCutToday);
                                    if (DataRowPcsCut.Length > 0)
                                    {
                                        foreach (DataRow dr1 in DataRowPcsCut)
                                        {
                                            orderDetail.ParentOrder.CuttingHistory.Quantity = (dr1["TotalPcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(dr1["TotalPcsCut"]);

                                        }
                                    }
                                    else
                                    {

                                        orderDetail.ParentOrder.CuttingHistory.Quantity = 0;
                                    }

                                    string strPcsStitched = "UnitID =" + orderDetail.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsStitched;
                                    DataRowPcsStitched = dtPcsStitchedToday.Select(strPcsStitched);

                                    if (DataRowPcsStitched.Length > 0)
                                    {
                                        foreach (DataRow dr2 in DataRowPcsStitched)
                                        {
                                            orderDetail.ParentOrder.StitchingHistory.Quantity = (dr2["TotalPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr2["TotalPcsStitched"]);
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.ParentOrder.StitchingHistory.Quantity = 0;
                                    }


                                    string strBalOfMach = "UnitID =" + orderDetail.Unit.ProductionUnitId;
                                    DataRow[] DataRowBalOfMech;
                                    DataRowBalOfMech = dtBalofMach.Select(strBalOfMach);

                                    if (DataRowBalOfMech.Length > 0)
                                    {
                                        foreach (DataRow dr3 in DataRowBalOfMech)
                                        {
                                            //orderDetail.ParentOrder.CuttingDetail.PcsCut = (dr3["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(dr3["PcsCut"]);
                                            orderDetail.ParentOrder.CuttingDetail.PcsCut = (dr3["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(dr3["PcsIssued"]);
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.ParentOrder.CuttingDetail.PcsCut = 0;
                                        orderDetail.ParentOrder.CuttingDetail.PcsIssued = 0;
                                    }


                                    string strPcsPacked = "UnitID =" + orderDetail.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsPacked;
                                    DataRowPcsPacked = dtPcsPackedToday.Select(strPcsPacked);

                                    if (DataRowPcsPacked.Length > 0)
                                    {
                                        foreach (DataRow dr4 in DataRowPcsPacked)
                                        {
                                            orderDetail.ParentOrder.StitchingDetail.PcsPackedToday = (dr4["TotalpcsPackedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr4["TotalpcsPackedToday"]);
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.ParentOrder.StitchingDetail.PcsPackedToday = 0;
                                    }


                                    string strPcsExFactoried = "UnitID =" + orderDetail.Unit.ProductionUnitId;
                                    DataRow[] DataRowPcsExFactoried;
                                    DataRowPcsExFactoried = dtPcsExFactoriedToday.Select(strPcsExFactoried);

                                    if (DataRowPcsExFactoried.Length > 0)
                                    {
                                        foreach (DataRow dr5 in DataRowPcsExFactoried)
                                        {
                                            orderDetail.Quantity = (dr5["TotalPcsExFactoriedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(dr5["TotalPcsExFactoriedToday"]);
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.Quantity = 0;
                                    }


                                    string strOverallPcsStitchd = "UnitID =" + orderDetail.Unit.ProductionUnitId;
                                    DataRow[] DataRowOverallPcsStitchd;
                                    DataRowOverallPcsStitchd = dtOverallPcsStitched.Select(strOverallPcsStitchd);

                                    if (DataRowOverallPcsStitchd.Length > 0)
                                    {
                                        foreach (DataRow dr6 in DataRowOverallPcsStitchd)
                                        {
                                            orderDetail.ParentOrder.CuttingDetail.PcsIssued = (dr6["OverallPcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(dr6["OverallPcsStitched"]);
                                            //objAllocation.StitchingData.OverallPcsPacked = (dr6["OverallPcsPacked"] == DBNull.Value) ? 0 : Convert.ToInt32(dr6["OverallPcsPacked"]);
                                        }
                                    }
                                    else
                                    {
                                        orderDetail.ParentOrder.CuttingDetail.PcsIssued = 0;
                                    }

                                    orderDetailCollection.Add(orderDetail);
                                }

                            }
                        }
                    }
                }

                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return orderDetailCollection;
            }
        }


        public List<OrderDetail> GetAllOrderDeliveredToday(DateTime SentOn)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_sending_delivered_email";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Date", SqlDbType.DateTime);
                param.Value = new DateTime(SentOn.Year, SentOn.Month, SentOn.Day, 0, 0, 0);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailDeleveredEmail = new List<OrderDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        orderDetail.Quantity = (reader["DeliveredQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DeliveredQty"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderID"]);
                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                        orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

                        orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                        orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        orderDetail.ParentOrder.Style.cdept.DeptID = (reader["DepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["DepartmentID"]) : 0;

                        orderDetail.ParentOrder.Style.client = new Client();
                        orderDetail.ParentOrder.Style.client.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);
                        orderDetail.ParentOrder.Style.client.CompanyName = (reader["Buyer"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Buyer"]);

                        orderDetail.FirstPartnerName = (reader["PartnerName1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartnerName1"]);
                        orderDetail.SecondPartnerName = (reader["PartnerName2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartnerName2"]);

                        orderDetailDeleveredEmail.Add(orderDetail);
                    }
                }

                return orderDetailDeleveredEmail;
            }
        }

        public DataSet GetClientsWeeklyStylesQuantity()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_get_clients_weekly_quantity";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);

                cnx.Close();

                return ds;
            }
        }


        public List<OrderDetail> GetEmbellishmentReport(string FromPrice, string ToPrice, int Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_report_get_embellishment_report";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FromPrice", SqlDbType.Int);
                if (!String.IsNullOrEmpty(FromPrice))
                    param.Value = Convert.ToDouble(FromPrice);
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@ToPrice", SqlDbType.Int);
                if (!String.IsNullOrEmpty(ToPrice))
                    param.Value = Convert.ToDouble(ToPrice);
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.ParentOrder = new Order();

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                        orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

                        orderDetail.ParentOrder.Style.client = new Client();
                        orderDetail.ParentOrder.Style.client.CompanyName = (reader["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CompanyName"]);
                        orderDetail.ParentOrder.Style.client.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);

                        orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                        orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        orderDetail.ParentOrder.Style.DepartmentID = (reader["ClientDepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientDepartmentID"]);

                        orderDetail.ParentOrder.Style.StyleReferenceBlocks = new StyleReferenceBlock();
                        orderDetail.ParentOrder.Style.StyleReferenceBlocks.Id = (reader["StyleRefrenceBlockID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleRefrenceBlockID"]);
                        orderDetail.ParentOrder.Style.StyleReferenceBlocks.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                        orderDetail.ParentOrder.Style.StyleReferenceBlocks.Name = (reader["Name"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Name"]);
                        orderDetail.ParentOrder.Style.StyleReferenceBlocks.ImagePath = (reader["EmbellishmentUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["EmbellishmentUrl"]);
                        orderDetail.ParentOrder.Style.StyleReferenceBlocks.Type = (reader["Type"] == DBNull.Value) ? (int)ReferenceBlockType.EMBELLISHMENT : Convert.ToInt32(reader["Type"]);

                        orderDetail.ParentOrder.Costing = new Costing();
                        orderDetail.ParentOrder.Costing.CostingID = (reader["CostingID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CostingID"]);

                        orderDetail.ParentOrder.Costing.CostingCharges = new Charges();
                        orderDetail.ParentOrder.Costing.CostingCharges.ChargeValue = (reader["Price"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Price"]);

                        orderDetailCollection.Add(orderDetail);
                    }
                }

                return orderDetailCollection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetWhereAreMyOrdersReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_where_are_my_orders";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsWhereAreMyOrdersReport = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsWhereAreMyOrdersReport);

                cnx.Close();

                return dsWhereAreMyOrdersReport;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetShipmentByUnitReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_shipment_by_unit";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsShipmentByUnit = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsShipmentByUnit);

                cnx.Close();

                return dsShipmentByUnit;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetOrdersPlacedVsShippedReport(int UnitID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_order_placed_versus_order_shipped";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@UnitID", SqlDbType.Int);
                if (UnitID > 0)
                    param.Value = UnitID;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsOrdersPlacedVsShipped = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsOrdersPlacedVsShipped);

                cnx.Close();

                return dsOrdersPlacedVsShipped;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetCIFContracts(int month, int year)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_get_cif_contracts";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param;

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsCIFContracts = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsCIFContracts);

                cnx.Close();

                return dsCIFContracts;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRecord"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetWeeklyShipmentsReport(int startRecord, int pageSize, out int totalRecords,
            DateTime start, DateTime end, int clientId, int supplyType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_weekly_shipments";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = startRecord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = start;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = end;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplyType", SqlDbType.Int);
                param.Value = supplyType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsWeeklyShipments = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsWeeklyShipments);

                cnx.Close();

                totalRecords = Convert.ToInt32(outParam.Value);

                return dsWeeklyShipments;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRecord"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <param name="exStart"></param>
        /// <param name="exEnd"></param>
        /// <param name="dcStart"></param>
        /// <param name="dcEnd"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetPendingOrdersReport(
            int startRecord,
            int pageSize,
            out int totalRecords,
            DateTime exStart,
            DateTime exEnd,
            DateTime dcStart,
            DateTime dcEnd,
            int clientID,
            int supplyType,
            out int totalQuantity,
            out double totalAmount
            )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_pending_orders";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter outParamTotalQty;
                outParamTotalQty = new SqlParameter("@oTotalQuantity", SqlDbType.Int);
                outParamTotalQty.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParamTotalQty);

                SqlParameter outParamTotalAmt;
                outParamTotalAmt = new SqlParameter("@oTotalAmmount", SqlDbType.Float);
                outParamTotalAmt.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParamTotalAmt);

                SqlParameter param;

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = startRecord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExStartDate", SqlDbType.DateTime);
                param.Value = exStart;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExEndDate", SqlDbType.DateTime);
                param.Value = exEnd;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DCStartDate", SqlDbType.DateTime);
                param.Value = dcStart;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DCEndDate", SqlDbType.DateTime);
                param.Value = dcEnd;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = clientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplyType", SqlDbType.Int);
                param.Value = supplyType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPendingOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsPendingOrders);

                cnx.Close();

                if (outParam.Value == DBNull.Value)
                {
                    totalRecords = 0;
                }
                else
                {
                    totalRecords = Convert.ToInt32(outParam.Value);
                }

                if (outParamTotalAmt.Value == DBNull.Value)
                {
                    totalAmount = 0;
                }
                else
                {
                    totalAmount = Convert.ToDouble(outParamTotalAmt.Value);
                }
                if (outParamTotalQty.Value == DBNull.Value)
                {
                    totalQuantity = 0;
                }
                else
                {
                    totalQuantity = Convert.ToInt32(outParamTotalQty.Value);
                }

                return dsPendingOrders;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRecord"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <param name="exStart"></param>
        /// <param name="exEnd"></param>
        /// <param name="dcStart"></param>
        /// <param name="dcEnd"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetShipmentRegisterReport(int startRecord, int pageSize, out int totalRecords,
            DateTime start, DateTime end, int clientId, int supplyType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_shipment_register";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = startRecord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = start;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                param.Value = end;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = clientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplyType", SqlDbType.Int);
                param.Value = supplyType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsShipmentRegister = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsShipmentRegister);

                cnx.Close();

                totalRecords = Convert.ToInt32(outParam.Value);

                return dsShipmentRegister;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRecord"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <param name="exStart"></param>
        /// <param name="exEnd"></param>
        /// <param name="dcStart"></param>
        /// <param name="dcEnd"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <author>vikas.agarwal</author>
        public DataSet GetShipmentMonthlyDetailsReport(
            int startRecord,
            int pageSize,
            out int totalRecords,
            int month,
            int year
            )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_monthly_shipment_details";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = startRecord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = month;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = year;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsMonthlyShipmentDetails = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsMonthlyShipmentDetails);

                cnx.Close();

                totalRecords = Convert.ToInt32(outParam.Value);

                return dsMonthlyShipmentDetails;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="StartRecord"></param>
        /// <param name="Count"></param>
        /// <param name="DueStartDate"></param>
        /// <param name="DueEndDate"></param>
        /// <param name="BEStartDate"></param>
        /// <param name="BEEndDate"></param>
        /// <param name="BENumber"></param>
        /// <param name="ClientID"></param>
        /// <returns></returns>
        public DataSet GetPendingPaymentsReport(
           int startRecord,
           int pageSize,
           out int totalRecords,
           DateTime dueStartDate,
           DateTime dueEndDate,
           DateTime beStartDate,
           DateTime beEndDate,
           string beNumber,
           int clientID,
            string GroupField)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                //string cmdText = "sp_reports_pending_payments";

                string cmdText = "sp_reports_pending_payments_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = pageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartRecord", SqlDbType.Int);
                param.Value = startRecord;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DueStartDate", SqlDbType.DateTime);
                if ((dueStartDate == DateTime.MinValue) || (dueStartDate == Convert.ToDateTime("1753-01-01")) || (dueStartDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = dueStartDate;
                }
              //  param.Value = dueStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DueEndDate", SqlDbType.DateTime);
                if ((dueEndDate == DateTime.MinValue) || (dueEndDate == Convert.ToDateTime("1753-01-01")) || (dueEndDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = dueEndDate;
                }
               // param.Value = dueEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BEStartDate", SqlDbType.DateTime);
                if ((beStartDate == DateTime.MinValue) || (beStartDate == Convert.ToDateTime("1753-01-01")) || (beStartDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = beStartDate;
                }
               // param.Value = beStartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BEEndDate", SqlDbType.DateTime);
                if ((beEndDate == DateTime.MinValue) || (beEndDate == Convert.ToDateTime("1753-01-01")) || (beEndDate == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = beEndDate;
                }
                //param.Value = beEndDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BENumber", SqlDbType.VarChar);
                param.Value = beNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = clientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("GroupOn", SqlDbType.VarChar);
                param.Value = GroupField;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet dsPendingPayments = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsPendingPayments);

                cnx.Close();

                totalRecords = Convert.ToInt32(outParam.Value);

                return dsPendingPayments;
            }
        }



        public DataSet GetShipmentEmailReportData(DateTime FromDate, DateTime ToDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_send_invoice_statement_email";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param.Value = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day, 0, 0, 0);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param.Value = new DateTime(ToDate.Year, ToDate.Month, ToDate.Day, 0, 0, 0);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsShipmentDetails = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsShipmentDetails);

                cnx.Close();



                return dsShipmentDetails;
            }
        }

        public DataSet GetPPMeetingFormDataForStyleCutToday(DateTime SendOn)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_send_pp_meeting_form_for_style_cut_today";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Date", SqlDbType.DateTime);
                param.Value = new DateTime(SendOn.Year, SendOn.Month, SendOn.Day, 0, 0, 0);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsPPM = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsPPM);

                cnx.Close();

                return dsPPM;
            }
        }


        //public List<OrderDetail> GetFactoryLineWisePlanReport(string searchText, DateTime FromDate, DateTime ToDate, int Unit)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {

        //        List<OrderDetail> orderDetailCollection = new List<OrderDetail>();
        //        int result;
        //        bool success;
        //        String cmdText;

        //        try
        //        {

        //            cmdText = "sp_reports_factory_line_wise_plan_with_accessories";

        //            SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout =Constants.CONFIGURATION_TimeOut;
        //            DataSet dsorderDetail = new DataSet();
        //            SqlParameter param;

        //            param = new SqlParameter("@searchText", SqlDbType.VarChar);
        //            param.Value = searchText;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);


        //            param = new SqlParameter("@FromDate", SqlDbType.DateTime);
        //            if (FromDate != DateTime.MinValue)
        //            {
        //                param.Value = FromDate;
        //            }
        //            else
        //                param.Value = DBNull.Value;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@ToDate", SqlDbType.DateTime);
        //            if (ToDate != DateTime.MinValue)
        //            {
        //                param.Value = ToDate;
        //            }
        //            else
        //                param.Value = DBNull.Value;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Unit", SqlDbType.Int);
        //            param.Value = Unit;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            adapter.Fill(dsorderDetail);

        //            if (dsorderDetail.Tables[0].Rows.Count > 0)
        //            {
        //                DataTable dt = dsorderDetail.Tables[0];
        //                DataTable dt1 = dsorderDetail.Tables[2];
        //                DataTable dt2 = dsorderDetail.Tables[3];
        //                DataTable dtLines = dsorderDetail.Tables[1];
        //                int orderid = -1;

        //                if (dt.Rows.Count > 0)
        //                {
        //                    foreach (DataRow reader in dt.Rows)
        //                    {

        //                        OrderDetail orderDetail = new OrderDetail();

        //                        orderDetail.OrderDetailID = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]);
        //                        if (orderDetail.OrderDetailID == 0)
        //                            continue;
        //                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
        //                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);

        //                        orderDetail.ParentOrder = new Order();
        //                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);

        //                        orderDetail.ParentOrder.Style = new Style();
        //                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
        //                        orderDetail.ParentOrder.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);

        //                        orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
        //                        orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
        //                        orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

        //                        orderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
        //                        orderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
        //                        orderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
        //                        orderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);
        //                        var Fab1Det = orderDetail.Fabric1Details.Trim().Split(' ');

        //                        if (!string.IsNullOrEmpty(Fab1Det[0]) && Int32.TryParse(Fab1Det[0], out result) && (Fab1Det.Length == 1 || (Fab1Det.Length == 2 && Fab1Det[1].Length <= 2)))
        //                        {
        //                            orderDetail.Fabric1Details = "PRD:" + orderDetail.Fabric1Details;
        //                            success = false;
        //                            result = 0;

        //                        }

        //                        var Fab2Det = orderDetail.Fabric2Details.Trim().Split(' ');

        //                        if (!string.IsNullOrEmpty(Fab2Det[0]) && Int32.TryParse(Fab2Det[0], out result) && (Fab2Det.Length == 1 || (Fab2Det.Length == 2 && Fab2Det[1].Length <= 2)))
        //                        {
        //                            orderDetail.Fabric2Details = "PRD:" + orderDetail.Fabric2Details;
        //                            success = false;
        //                            result = 0;
        //                        }



        //                        var Fab3Det = orderDetail.Fabric3Details.Trim().Split(' ');

        //                        if (!string.IsNullOrEmpty(Fab3Det[0]) && Int32.TryParse(Fab3Det[0], out result) && (Fab3Det.Length == 1 || (Fab3Det.Length == 2 && Fab3Det[1].Length <= 2)))
        //                        {
        //                            orderDetail.Fabric3Details = "PRD:" + orderDetail.Fabric3Details;
        //                            success = false;
        //                            result = 0;
        //                        }


        //                        var Fab4Det = orderDetail.Fabric4Details.Trim().Split(' ');

        //                        if (!string.IsNullOrEmpty(Fab4Det[0]) && Int32.TryParse(Fab4Det[0], out result) && (Fab4Det.Length == 1 || (Fab4Det.Length == 2 && Fab4Det[1].Length <= 2)))
        //                        {
        //                            orderDetail.Fabric4Details = "PRD:" + orderDetail.Fabric4Details;
        //                            success = false;
        //                            result = 0;
        //                        }

        //                        orderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
        //                        orderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
        //                        orderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
        //                        orderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

        //                        orderDetail.Quantity = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity"]);

        //                        orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
        //                        orderDetail.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderID"]);
        //                        orderDetail.ProductionUnitId = (reader["UnitID"] != DBNull.Value) ? Convert.ToInt32(reader["UnitID"]) : 0;

        //                        orderDetail.Unit = new ProductionUnit();
        //                        orderDetail.Unit.ProductionUnitId = (reader["ProductionUnitId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitID"]);
        //                        orderDetail.Unit.FactoryName = (reader["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryName"]);
        //                        orderDetail.Unit.FactoryCode = (reader["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FactoryCode"]);
        //                        orderDetail.Unit.ProductionUnitColor = (reader["ProductionUnitColor"] == DBNull.Value || Convert.ToString(reader["ProductionUnitColor"]) == string.Empty) ? "#ffffff" : Convert.ToString(reader["ProductionUnitColor"]);

        //                        orderDetail.ParentOrder.CuttingDetail = new CuttingDetail();
        //                        orderDetail.ParentOrder.CuttingDetail.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);
        //                        orderDetail.ParentOrder.CuttingDetail.PcsIssued = (reader["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsIssued"]);

        //                        orderDetail.ParentOrder.CuttingHistory = new CuttingHistory();
        //                        orderDetail.ParentOrder.CuttingHistory.PcsCut = (reader["PcsCut"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsCut"]);


        //                        orderDetail.ParentOrder.StitchingDetail = new StitchingDetail();
        //                        orderDetail.ParentOrder.StitchingDetail.OverallPcsStitched = (reader["PcsStitched"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsStitched"]);
        //                        orderDetail.ParentOrder.StitchingDetail.TotalPcsStitchedToday = (reader["TotalPcsStitchedToday"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["TotalPcsStitchedToday"]);
        //                        orderDetail.ParentOrder.StitchingDetail.CuttingReceived = (reader["PcsIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PcsIssued"]);

        //                        string str = "OrderID =" + orderDetail.OrderID;
        //                        string strx = "OrderDetailID =" + orderDetail.OrderDetailID;

        //                        orderDetail.ParentOrder.AccessoryInHouseHistory = new AccessoryInHouseHistory();
        //                        DataRow[] DataRows;
        //                        DataRows = dt1.Select(strx);
        //                        foreach (DataRow dr4 in DataRows)
        //                        {
        //                            orderDetail.ParentOrder.AccessoryInHouseHistory.Date = (dr4["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr4["Date"]);
        //                            orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse = (dr4["PercentInHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(dr4["PercentInHouse"]);
        //                            orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName = (dr4["AccessoryName"] == DBNull.Value) ? string.Empty : dr4["AccessoryName"].ToString();
        //                            orderDetail.AccessoryHistory += orderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse + "% on" + " " + orderDetail.ParentOrder.AccessoryInHouseHistory.Date.ToString("dd MMM yy (ddd)") + "<br/><br/>";

        //                            orderid = orderDetail.OrderID;
        //                        }

        //                        DataRow[] DataRows2;
        //                        DataRows2 = dt2.Select(str);
        //                        foreach (DataRow dr5 in DataRows2)
        //                        {
        //                            string AccessoryName = (dr5["AccessoryName"] == DBNull.Value) ? string.Empty : dr5["AccessoryName"].ToString();
        //                            if (orderDetail.AccessoryHistory != null && orderDetail.AccessoryHistory != string.Empty)
        //                            {
        //                                if (orderDetail.AccessoryHistory.IndexOf(AccessoryName) == -1)
        //                                {
        //                                    orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
        //                                }
        //                            }
        //                            else
        //                            {
        //                                orderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/><br/>";
        //                            }

        //                        }

        //                        orderDetail.TotalPackages = (dtLines.Rows[0]["MaxLines"] == DBNull.Value) ? 0 : Convert.ToInt32(dtLines.Rows[0]["MaxLines"]);

        //                        orderDetailCollection.Add(orderDetail);
        //                    }
        //                }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {

        //        }
        //        return orderDetailCollection;
        //    }
        //}


        public DataSet GetFactoryLineWisePlanReport(string searchText, DateTime FromDate, DateTime ToDate, int Unit)
        {
            DataSet dsFactory = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_reports_factory_line_wise_plan_with_accessories";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@searchText", SqlDbType.VarChar);
                param.Value = searchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                //if (FromDate != DateTime.MinValue)
                    if ((FromDate != DateTime.MinValue) || (FromDate != Convert.ToDateTime("1753-01-01")) || (FromDate != Convert.ToDateTime("1900-01-01")))
                    param.Value = FromDate;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
              //  if (ToDate != DateTime.MinValue)
                    if ((FromDate != DateTime.MinValue) || (FromDate != Convert.ToDateTime("1753-01-01")) || (FromDate != Convert.ToDateTime("1900-01-01")))
                    param.Value = ToDate;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.Int);
                param.Value = Unit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFactory);

            }

            return dsFactory;
        }

        public DataSet GetPriceVariationReport(int Type)
        {
            DataSet dsPriceVariation = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_reports_price_variations";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPriceVariation);
            }

            return dsPriceVariation;
        }

        public DataSet GetSignOff(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_report_sign_off";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsSignOff = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsSignOff);

                cnx.Close();

                return dsSignOff;
            }
        }

        /// <summary>
        /// us /25/march/11
        /// report in status meeting
        /// </summary>
        /// <returns></returns>

        public DataSet GetFitDelay()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_report_delay_fits";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                     
                DataSet dsFitDelay = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFitDelay);

                cnx.Close();


                return dsFitDelay;
            }
        }
        /// <summary>
        /// us /25/march/11
        /// for factory pending at factory
        /// </summary>
        /// <returns></returns>
        public DataSet GetFitDelayforFactory()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_fit_days_for_factory";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataSet dsFitDelayforfact = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFitDelayforfact);

                cnx.Close();


                return dsFitDelayforfact;
            }
        }

        public DataSet GetPendingBuyingSamplesReport(int PageSize, int PageIndex, out int TotalRowCount, string searchText, DateTime FromDate, DateTime ToDate)
        {
            DataSet dsPendingSamples = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_reports_pending_buying_samples";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@searchText", SqlDbType.VarChar);
                param.Value = searchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = PageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageIndex", SqlDbType.Int);
                param.Value = PageIndex;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                if ((FromDate != DateTime.MinValue) || (FromDate != Convert.ToDateTime("1753-01-01")) || (FromDate != Convert.ToDateTime("1900-01-01")))
                //if (FromDate != DateTime.MinValue)
                    param.Value = FromDate;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDate", SqlDbType.DateTime);
               // if (ToDate != DateTime.MinValue)
                    if ((ToDate != DateTime.MinValue) || (ToDate != Convert.ToDateTime("1753-01-01")) || (ToDate != Convert.ToDateTime("1900-01-01")))
                    param.Value = ToDate;
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

               
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPendingSamples);
                TotalRowCount = Convert.ToInt32(outParam.Value);
            }
            return dsPendingSamples;
        }

        public DataSet GetFabricBookedPerformanceReport(int PageSize, int PageIndex, out int TotalRowCount, string searchText, int Months)
        {
            DataSet dsFabric = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_reports_fabric_booked_performance";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = searchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam;
                outParam = new SqlParameter("@Count", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                param = new SqlParameter("@PageSize", SqlDbType.Int);
                param.Value = PageSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageIndex", SqlDbType.Int);
                param.Value = PageIndex;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Months", SqlDbType.Int);
                param.Value = Months;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);
                TotalRowCount = Convert.ToInt32(outParam.Value);
            }
            return dsFabric;
        }

        public DataSet GetAverageLeadTimesReport(int DateType, int ClientID)
        {
            DataSet dsLeadTime = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_reports_average_lead_times";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DateType", SqlDbType.Int);
                param.Value = DateType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsLeadTime);
             }
            return dsLeadTime;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="DateType"></param>
        /// <param name="ClientID"></param>
        /// <returns></returns>
        public List<string> GetAllClientNames(string stringClient)
        {
          
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_get_all_clients";
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientTxt", SqlDbType.VarChar);
                param.Value = stringClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader=cmd.ExecuteReader();
                List<string> result = new List<string>();                
                     while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["companyname"]));
                    }
                cnx.Close();
               return result;
            }           
        }
        public List<OrderDetail> GetAllOrderDeliveredTodayCompanyWise(DateTime SentOn, int bCheck)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_sending_delivered_email_CompanyWise_New";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@Date", SqlDbType.DateTime);
                param.Value = new DateTime(SentOn.Year, SentOn.Month, SentOn.Day, 0, 0, 0);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Company", SqlDbType.Int);
                param.Value = bCheck;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<OrderDetail> orderDetailDeleveredEmail = new List<OrderDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = Convert.ToInt32(reader["Id"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        orderDetail.Quantity = (reader["DeliveredQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DeliveredQty"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.OrderID = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderID"]);
                        orderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                        orderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        orderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        orderDetail.ParentOrder.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                        orderDetail.ParentOrder.Style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);

                        orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                        orderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        orderDetail.ParentOrder.Style.cdept.DeptID = (reader["DepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["DepartmentID"]) : 0;

                        orderDetail.ParentOrder.Style.client = new Client();
                        orderDetail.ParentOrder.Style.client.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);
                        orderDetail.ParentOrder.Style.client.CompanyName = (reader["Buyer"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Buyer"]);

                        orderDetail.FirstPartnerName = (reader["PartnerName1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartnerName1"]);
                        orderDetail.SecondPartnerName = (reader["PartnerName2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartnerName2"]);

                        orderDetailDeleveredEmail.Add(orderDetail);
                    }
                }

                return orderDetailDeleveredEmail;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringClient"></param>
        /// <returns></returns>

        public DataSet GetAllOrdersOnStyleDAL(int styleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_all_orders_on_style_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = styleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet dsStyles = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsStyles);

                cnx.Close();

                return dsStyles;
            }
        }



        public string GetAllClientsIds(string stringClient)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_ClientIds";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.VarChar);
                param.Value = stringClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];

                string styleNumber = Convert.ToString(dt.Rows[0][0]);
                cnx.Close();
                return styleNumber;

            }
        }
        //Pending Payment Report abhishek 22 sep 17===============================//

      //int startRecord,
      //     int pageSize,
      //     out int totalRecords,
      //     DateTime dueStartDate,
      //     DateTime dueEndDate,
      //     DateTime beStartDate,
      //     DateTime beEndDate,
      //     string beNumber,
      //     int clientID,
      //      string GroupField
        public List<PackingDelivery> GetBankPaymentReport(string SearchText, DateTime frm, DateTime to, int PaymentType, int pageIndex, int PageSize , out int recordCount)
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();
            SqlDataReader reader;
            SqlCommand cmd;
            string cmdText;

            cmdText = "Usp_GetBankPaymentDetails_Report";
            cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            

            SqlParameter param;

            param = new SqlParameter("@SearchText", SqlDbType.VarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = SearchText;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fromdate", SqlDbType.Date);
            param.Direction = ParameterDirection.Input;
            param.Value = frm;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Todate", SqlDbType.Date);
            param.Direction = ParameterDirection.Input;
            param.Value = to;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsPaymentCleared", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = PaymentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageIndex", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = pageIndex;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageSize", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = PageSize;
            cmd.Parameters.Add(param);          

            SqlParameter outParam;
            outParam = new SqlParameter("@RecordCount", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);


            reader = cmd.ExecuteReader();
            List<PackingDelivery> PackingDeliverys = new List<PackingDelivery>();
            if (reader.HasRows)
            {
              while (reader.Read())
              {
                PackingDelivery Invoicepayment = new PackingDelivery();

                Invoicepayment.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                Invoicepayment.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                Invoicepayment.InvoiceNumber = (reader["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["InvoiceNumber"]);
                Invoicepayment.InvoiceDate = (reader["InvoiceDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["InvoiceDate"]).ToString("dd MMM yy (ddd)");
                Invoicepayment.SBno = (reader["SBNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SBNumber"]);
                Invoicepayment.SBDate = (reader["SBDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["SBDate"]).ToString("dd MMM yy (ddd)");
                Invoicepayment.ConvertTO = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);
                Invoicepayment.InvoiceAmount = (reader["InvoiceAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["InvoiceAmt"]);
                Invoicepayment.ShippingNo = (reader["ShipmentNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ShipmentNo"]);
                Invoicepayment.TotalBEAmount = (reader["TotalAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TotalAmt"]);
                Invoicepayment.BankRefNumber = (reader["BankRefNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BankRefNo"]);
                Invoicepayment.PaymentReceiveDate = (reader["PaymentReceivedOn"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentReceivedOn"]).ToString("dd MMM yy (ddd)");
                Invoicepayment.OrderDetailsID = (reader["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailID"]);
                Invoicepayment.OrderID = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                Invoicepayment.PaymentDueDate = (reader["PaymentDueDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentDueDate"]).ToString("dd MMM yy (ddd)");
                Invoicepayment.BankRefNoCount = (reader["Counts"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Counts"]);
                Invoicepayment.PaymentClearDate = (reader["PaymentCleareddate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(reader["PaymentCleareddate"]).ToString("dd MMM yy (ddd)");
                Invoicepayment.Tenure = (reader["Tenure"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Tenure"]);
                Invoicepayment.BankRefID = (reader["BnkRefID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["BnkRefID"]);
                Invoicepayment.IsSingle = (reader["IsSingle"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["IsSingle"]);
                Invoicepayment.BankPaymentRecAmt = (reader["BnkPayemntRecAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BnkPayemntRecAmt"]);
                Invoicepayment.IsFullPaymentCleard = (reader["IsPaymentCleared"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsPaymentCleared"]);
                Invoicepayment.ShipmentNo__PkID = (reader["ShipmentNo__PkID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ShipmentNo__PkID"]);
                Invoicepayment.IsAction = (reader["IsAction"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["IsAction"]);
                Invoicepayment.BankPendingAmt = (reader["PedningBeAmt"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PedningBeAmt"]);
                PackingDeliverys.Add(Invoicepayment);


              }
            }
            cnx.Close();
            recordCount = Convert.ToInt32(outParam.Value);
            return PackingDeliverys;

          }


        }
        public DataTable GetSerialNumber(string Flag, string ShipmentNo)
        {
          DataTable dt = new DataTable();
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            string cmdText = "Usp_GetInvoiceDetails";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
            param.Value = Flag;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ShipmentNo", SqlDbType.VarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = ShipmentNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);

          }

          return dt;
        }
      //end


    }
}


