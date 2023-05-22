using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using iKandi.Common.Entities;
//this page is created by Ravi kumar 25-12-18
namespace iKandi.DAL
{
    public class OrderPlaceDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public OrderPlaceDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        private SqlCommand OrderPlaceSqlCommand(String cmdText, SqlConnection cnx, QueryType qryType, int UserId)
        {
            SqlCommand cmd = new SqlCommand(cmdText, cnx);

            //Check if procedure is for insert or update
            if (qryType == QueryType.Insert)
            {
                SqlParameter param1 = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param1.Value = UserId;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedBy", SqlDbType.Int);
                param1.Value = UserId;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);
            }
            else if (qryType == QueryType.Update)
            {
                SqlParameter param1 = new SqlParameter("@UpdatedBy", SqlDbType.Int);
                param1.Value = UserId;
                cmd.Parameters.Add(param1);

                param1 = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
                param1.Value = DateTime.Now;
                cmd.Parameters.Add(param1);
            }

            return cmd;
        }

        #endregion

        #region ManageOrder

        public int StyleExistForThisClient(int OrderId, string StyleNumber)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                OrderPlace order = new OrderPlace();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_StyleExistForThisClient";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    order.StyleExist = (reader["StyleExist"] != DBNull.Value)
                                                         ? Convert.ToInt32(reader["StyleExist"])
                                                         : 0;
                }
                cnx.Close();

                return order.StyleExist;
            }
        }

        public OrderPlace GetOrderInfoByStyleNumber(string StyleNumber)
        {
            OrderPlace order = new OrderPlace();
            order.Style = new Style();
            order.Costing = new Costing();
            order.Print = new Print();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_orders_get_info_by_style_number";

                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    param.Value = StyleNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            order.StyleID = Convert.ToInt32(reader["StyleID"]);
                            order.DepartmentID = (reader["DepartmentId"] != DBNull.Value) ? Convert.ToInt32(reader["DepartmentId"]) : 0;
                            order.ParentDepartmentID = (reader["ParentDepartmentID"] != DBNull.Value) ? Convert.ToInt32(reader["ParentDepartmentID"]) : 0;
                            order.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                            order.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                            order.Print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);

                            double PriceQuoted = (reader["PriceQuoted"] != DBNull.Value) ? Convert.ToDouble(reader["PriceQuoted"]) : 0;
                            order.Costing.AgreedPrice = (reader["AgreedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["AgreedPrice"]);

                            if (order.Costing.AgreedPrice == 0)
                                order.Costing.AgreedPrice = PriceQuoted;

                            order.Costing.CostingID = (reader["CostingID"] != DBNull.Value) ? Convert.ToInt32(reader["CostingID"]) : 0;
                            order.Costing.ConvertTo = (reader["ConvertTo"] != DBNull.Value) ? Convert.ToInt32(reader["ConvertTo"]) : -1;

                            order.Costing.CurrencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(order.Costing.ConvertTo);

                            order.ClientID = (reader["ClientID"] != DBNull.Value) ? Convert.ToInt32(reader["ClientID"]) : 0;

                            string fabrics = (reader["Fabrics"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabrics"]);

                            order.Description = (reader["OrderDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OrderDescription"]);

                            order.IsRepeat = (reader["OrderExist"] != DBNull.Value) ? Convert.ToBoolean(reader["OrderExist"]) : false;

                            order.AccountManagerName = (reader["AcountMgr"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AcountMgr"]);

                            order.IsIkandiClient = (reader["IsIkandiClient"] != DBNull.Value) ? Convert.ToBoolean(reader["IsIkandiClient"]) : false;

                            order.ConversionRate = (reader["ConversionRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ConversionRate"]);

                            order.ContractFabric = GetOrderDetail_FabricSection(order.StyleID, -1);
                            order.ContractAccessories = GetOrderDetail_AccessoriesSection(order.StyleID, -1);

                        }
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return order;
        }

        public OrderPlace Get_order_by_OrderId_ForOrderPlace(int OrderID, int UserId)
        {
            OrderPlace order = new OrderPlace();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_order_by_OrderId_ForOrderPlace";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        order.Style = new Style();
                        order.Costing = new Costing();
                        order.Print = new Print();

                        order.OrderID = OrderID;
                        order.StyleID = (reader["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StyleID"]);
                        order.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        order.ClientID = (reader["ClientID"] == DBNull.Value || Convert.ToString(reader["ClientID"]) == String.Empty) ? 0 : Convert.ToInt32(reader["ClientID"]);
                        order.IsIkandiClient = (reader["IsIkandiClient"] != DBNull.Value) ? Convert.ToBoolean(reader["IsIkandiClient"]) : false;
                        order.OrderDate = (reader["OrderDate"] == DBNull.Value || reader["OrderDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["OrderDate"]);
                        order.SerialNumber = Convert.ToString(reader["SerialNumber"]);
                        order.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                        order.ParentDepartmentID = (reader["ParrentDepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ParrentDepartmentID"]);
                        order.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentID"]);
                        order.ApprovedByMerchandiserManager = reader["ApprovedByMerchandiserManager"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ApprovedByMerchandiserManager"]);
                        order.ApprovedBySalesBIPL = reader["ApprovedBySalesBIPL"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ApprovedBySalesBIPL"]);
                        order.ApprovedByFabricManager = reader["ApprovedByFabricManager"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ApprovedByFabricManager"]);
                        order.ApprovedByAccessoryManager = reader["ApprovedByAccessoryManager"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ApprovedByAccessoryManager"]);

                        order.Costing.CostingID = (reader["CostingId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CostingId"]);
                        order.Costing.ConvertTo = (reader["ConvertTo"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ConvertTo"]);
                        order.Costing.CurrencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(order.Costing.ConvertTo);
                        order.ConversionRate = (reader["ConversionRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ConversionRate"]);

                        order.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                        order.Style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                        order.Print.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);

                        order.StatusModeSequence = reader["StatusModeSequence"] == DBNull.Value ? 0 : Convert.ToInt32(reader["StatusModeSequence"]);
                        order.IsBiplAgreement = (reader["IsBiplAgreement"] == DBNull.Value) ? 2 : Convert.ToInt32(reader["IsBiplAgreement"]);
                        order.IsApproved = (reader["IsApproved"] == DBNull.Value) ? 1 : Convert.ToInt32(reader["IsApproved"]);
                        order.OrderTypes = (reader["OrderType"] == DBNull.Value) ? 1 : Convert.ToInt32(reader["OrderType"]);
                        order.TotalQuantity = (reader["TotalQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["TotalQuantity"]);
                        order.TotalOrderPrice = (reader["OrderPrice"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["OrderPrice"]);
                        order.AccountManagerName = (reader["AcountMgr"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AcountMgr"]);
                        order.IsIkandiUser = reader["IsIkandiUser"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsIkandiUser"]);
                        order.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        order.ParentDepartmentName = (reader["ParentDepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ParentDepartmentName"]);

                        order.AgreementId = (reader["AgreementId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["AgreementId"]);
                        order.DepartmentID_d = (reader["DepartmentID_d"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentID_d"]);
                        order.ParrentDepartmentID_d = (reader["ParrentDepartmentID_d"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ParrentDepartmentID_d"]);
                        order.Description_d = (reader["Description_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description_d"]);
                        order.OrderType_d = (reader["OrderType_d"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderType_d"]);

                        order.IsFabricAvgDone = reader["IsFabricAvgDone"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsFabricAvgDone"]);
                        order.IsAccessoriesAvgDone = reader["IsAccessoriesAvgDone"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsAccessoriesAvgDone"]);
                        order.DeliveryType = (reader["DeliveryType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DeliveryType"]);
                        order.ApprovedByAccessoryManagerOn = (reader["ApprovedByAccessoryManagerOn"] == DBNull.Value || reader["ApprovedByAccessoryManagerOn"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["ApprovedByAccessoryManagerOn"]);
                        order.ApprovedBySalesBIPLOn = (reader["ApprovedBySalesBIPLOn"] == DBNull.Value || reader["ApprovedBySalesBIPLOn"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["ApprovedBySalesBIPLOn"]);
                        order.ApprovedByFabricManagerOn = (reader["ApprovedByFabricManagerOn"] == DBNull.Value || reader["ApprovedByFabricManagerOn"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["ApprovedByFabricManagerOn"]);
                        order.ApprovedByMerchandiserManagerOn = (reader["ApprovedByMerchandiserManagerOn"] == DBNull.Value || reader["ApprovedByMerchandiserManagerOn"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(reader["ApprovedByMerchandiserManagerOn"]);

                        order.SplittedContractCount = 0;

                        order.ContractDetail = Get_order_detail_BasicSection_by_orderId(OrderID);

                    }
                }
                cnx.Close();
            }

            return order;
        }

        public List<ContractDetails> Get_order_detail_BasicSection_by_orderId(int OrderID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_order_detail_BasicSection_by_orderId";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<ContractDetails> orderDetailCollection = new List<ContractDetails>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["Id"] != DBNull.Value && Convert.ToInt32(reader["Id"]) > 0)
                        {
                            ContractDetails orderDetail = new ContractDetails();

                            orderDetail.OrderDetailId = Convert.ToInt32(reader["Id"]);
                            orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                            orderDetail.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                            orderDetail.Quantity = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity"]);
                            orderDetail.ModeId = (reader["Mode"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Mode"]);
                            orderDetail.ModeCode = (reader["ModeCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ModeCode"]);
                            orderDetail.AmberRangeStart = (reader["AmberRangeStart"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AmberRangeStart"]);
                            orderDetail.AmberRangeEnd = (reader["AmberRangeEnd"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AmberRangeEnd"]);
                            orderDetail.GreenRangeStart = (reader["GreenRangeStart"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GreenRangeStart"]);
                            orderDetail.GreenRangeEnd = (reader["GreenRangeEnd"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GreenRangeEnd"]);
                            orderDetail.RedRangeStart = (reader["RedRangeStart"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["RedRangeStart"]);
                            orderDetail.RedRangeEnd = (reader["RedRangeEnd"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["RedRangeEnd"]);
                            orderDetail.BiplPrice = (reader["BIPLPrice"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["BIPLPrice"]);
                            orderDetail.ikandiPrice = (reader["iKandiPrice"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["iKandiPrice"]);
                            orderDetail.ExFactory = (reader["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ExFactory"]);
                            orderDetail.DC = (reader["DC"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DC"]);
                            orderDetail.ExFactoryWeek = (reader["WeekToEx"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["WeekToEx"]);
                            orderDetail.DCWeek = (reader["WeeksToDC"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["WeeksToDC"]);
                            orderDetail.DeliveryInstruction = (reader["DeliveryInstruction"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DeliveryInstruction"]);
                            orderDetail.typeofpacking = (reader["TypeOfPacking"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["TypeOfPacking"]);
                            orderDetail.SizeOption = (reader["SizeOption"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SizeOption"]);
                            orderDetail.PoUpload1 = (reader["File1"] == DBNull.Value || reader["File1"].ToString() == string.Empty) ? string.Empty : Convert.ToString(reader["File1"]);
                            orderDetail.PoUpload2 = (reader["File2"] == DBNull.Value || reader["File2"].ToString() == string.Empty) ? string.Empty : Convert.ToString(reader["File2"]);
                            orderDetail.CountryCodeId = (reader["CountryCodeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CountryCodeId"]);
                            orderDetail.CountryCode = (reader["Country_Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Country_Code"]);

                            orderDetail.LineItemNumber_d = (reader["LineItemNumber_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber_d"]);
                            orderDetail.ContractNumber_d = (reader["ContractNumber_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber_d"]);
                            orderDetail.Quantity_d = (reader["Quantity_d"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity_d"]);
                            orderDetail.ModeId_d = (reader["Mode_d"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Mode_d"]);
                            orderDetail.ModeCode_d = (reader["ModeCode_d"] == DBNull.Value) ? "" : Convert.ToString(reader["ModeCode_d"]);
                            orderDetail.BiplPrice_d = (reader["BIPLPrice_d"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["BIPLPrice_d"]);
                            orderDetail.ikandiPrice_d = (reader["iKandiPrice_d"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["iKandiPrice_d"]);
                            orderDetail.ExFactory_d = (reader["ExFactory_d"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ExFactory_d"]);
                            orderDetail.DC_d = (reader["DC_d"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DC_d"]);
                            orderDetail.ExFactoryWeek_d = (reader["WeekToEx_d"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["WeekToEx_d"]);
                            orderDetail.DCWeek_d = (reader["WeeksToDC_d"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["WeeksToDC_d"]);
                            orderDetail.DeliveryInstruction_d = (reader["DeliveryInstruction_d"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DeliveryInstruction_d"]);
                            orderDetail.typeofpacking_d = (reader["TypeOfPacking_d"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["TypeOfPacking_d"]);
                            orderDetail.PoUpload1_d = (reader["File1_d"] == DBNull.Value || reader["File1_d"].ToString() == string.Empty) ? string.Empty : Convert.ToString(reader["File1_d"]);
                            orderDetail.PoUpload2_d = (reader["File2_d"] == DBNull.Value || reader["File2_d"].ToString() == string.Empty) ? string.Empty : Convert.ToString(reader["File2_d"]);
                            orderDetail.CountryCode_d = (reader["CountyCode_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountyCode_d"]);
                            orderDetail.OrderDetailId_Ref = -1;
                            orderDetail.isSplit = 0;
                            orderDetail.isSplitted = 0;
                            orderDetail.SizeOption = (reader["SizeOption"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SizeOption"]);
                            orderDetail.SizeQty = (reader["SizeQty"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SizeQty"]);

                            orderDetail.LeadTime = (reader["LeadTime"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["LeadTime"]);
                            orderDetail.LeadTime_d = (reader["LeadTime_d"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["LeadTime_d"]);

                            orderDetail.ExFactoryColor = GetExFactoryColor(orderDetail);

                            orderDetail.ContractFabric = GetOrderDetail_FabricSection(-1, orderDetail.OrderDetailId);
                            orderDetail.ContractAccessories = GetOrderDetail_AccessoriesSection(-1, orderDetail.OrderDetailId);

                            //orderDetail.OrderSizes = GetOrderDetailSize(orderDetail.OrderDetailID);
                            //orderDetail.OrderSizes = GetOrderDetailSizeAndQuantity(orderDetail.OrderDetailID, orderDetail.SizeOption);

                            orderDetailCollection.Add(orderDetail);
                        }
                    }
                }

                return orderDetailCollection;
            }
        }

        public List<ContractDetailFabric> GetOrderDetail_FabricSection(int StyleId, int OrderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_order_detail_FabricSection";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<ContractDetailFabric> orderDetailFabricCollection = new List<ContractDetailFabric>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContractDetailFabric orderDetailFabric = new ContractDetailFabric();
                        orderDetailFabric.FabricId = (reader["FabricID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FabricID"]);
                        orderDetailFabric.FabricName = (reader["FabricName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricName"]);
                        orderDetailFabric.SeqId = (reader["SeqID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SeqID"]);
                        orderDetailFabric.GSM = (reader["GSM"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["GSM"]);
                        orderDetailFabric.DyedRate = (reader["DyedRate"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["DyedRate"]);
                        orderDetailFabric.PrintRate = (reader["PrintRate"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["PrintRate"]);
                        orderDetailFabric.CountConstruct = (reader["CountConstruct"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CountConstruct"]);
                        orderDetailFabric.FabTypeId = (reader["FabTypeId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FabTypeId"]);
                        orderDetailFabric.FabType = (reader["FabType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabType"]);
                        orderDetailFabric.FabricDetail = (reader["FabricDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricDetails"]);
                        orderDetailFabric.fabric_qualityID = (reader["fabric_qualityID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["fabric_qualityID"]);

                        orderDetailFabric.FabTypeID_d = (reader["FabTypeID_d"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["FabTypeID_d"]);
                        orderDetailFabric.FabType_d = (reader["FabType_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabType_d"]);
                        orderDetailFabric.FabricDetail_d = (reader["FabricDetails_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricDetails_d"]);
                        orderDetailFabric.Stage1 = (reader["Stage1"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Stage1"]);
                        orderDetailFabric.Stage2 = (reader["Stage2"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Stage2"]);
                        orderDetailFabric.Stage3 = (reader["Stage3"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Stage3"]);
                        orderDetailFabric.Stage4 = (reader["Stage4"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Stage4"]);

                        orderDetailFabric.CanChangeColorPrint = (reader["CanChangeColorPrint"] == DBNull.Value) ? true : Convert.ToBoolean(reader["CanChangeColorPrint"]);

                        
                        orderDetailFabricCollection.Add(orderDetailFabric);
                    }
                }

                return orderDetailFabricCollection;
            }
        }

        public List<ContractDetailAccessories> GetOrderDetail_AccessoriesSection(int StyleId, int OrderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_order_detail_Accessories_Section";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<ContractDetailAccessories> orderDetailAccessCollection = new List<ContractDetailAccessories>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                        orderDetailAccess.AccId = (reader["AccId"] == DBNull.Value) ? -1 : Convert.ToInt64(reader["AccId"]);
                        orderDetailAccess.AccessoriesId = (reader["AccessoriesId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoriesId"]);
                        orderDetailAccess.AccessoriesName = (reader["AccessoriesName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoriesName"]);
                        orderDetailAccess.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        orderDetailAccess.SizeId = (reader["SizeId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SizeId"]);
                        orderDetailAccess.SeqId = (reader["SequenceNumber"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SequenceNumber"]);
                        orderDetailAccess.ColorPrint = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        orderDetailAccess.IsDtm = (reader["IsDTM"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsDTM"]);
                        orderDetailAccess.AfterOrderConfirmation = (reader["AfterOrderConfirmation"] == DBNull.Value) ? false : Convert.ToBoolean(reader["AfterOrderConfirmation"]);
                        orderDetailAccess.IsAnyAccessoryAdded = (reader["IsAnyAccessoryAdded"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAnyAccessoryAdded"]);
                        orderDetailAccess.IsDefaultAccessory = (reader["IsDefaultAccessory"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsDefaultAccessory"]);
                        orderDetailAccess.ColorPrint_d = (reader["Color_Print_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print_d"]);
                        orderDetailAccess.IsDtm_d = (reader["IsDTM_d"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["IsDTM_d"]);
                        orderDetailAccess.IsSrvReceived = (reader["IsSrvReceived"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsSrvReceived"]);
                        orderDetailAccessCollection.Add(orderDetailAccess);
                    }
                }

                return orderDetailAccessCollection;
            }
        }

        public List<OrderPlace> Get_modes_For_OrderPlace(bool IsikandiClient, int CostingId, int ClientId, int DepartmentID, int OrderDetailId)
        {
            List<OrderPlace> OrderMode = new List<OrderPlace>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_get_modes_For_OrderPlace";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@IsikandiClient", SqlDbType.Bit);
                    param.Value = IsikandiClient;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = CostingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = "AllMode";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OrderPlace objOrder = new OrderPlace();

                            objOrder.ModeId = (reader["ModeId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ModeId"]);
                            objOrder.ModeCode = (reader["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Code"]);
                            objOrder.EnableMode = (reader["EnableMode"] == DBNull.Value) ? false : Convert.ToBoolean(reader["EnableMode"]);
                            OrderMode.Add(objOrder);
                        }
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return OrderMode;
        }

        public ContractDetails Get_ModeDetails_ByModeId(bool IsikandiClient, int CostingId, int ClientId, int DepartmentID, int ModeId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_modes_For_OrderPlace";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@IsikandiClient", SqlDbType.Bit);
                param.Value = IsikandiClient;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostingId", SqlDbType.Int);
                param.Value = CostingId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                param.Value = DepartmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModeId", SqlDbType.Int);
                param.Value = ModeId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "ByModeID";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                ContractDetails orderDetails = new ContractDetails();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        double PriceQuoted = (reader["QuotedPrice"] != DBNull.Value) ? Convert.ToDouble(reader["QuotedPrice"]) : 0;
                        orderDetails.BiplPrice = (reader["AgreedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["AgreedPrice"]);

                        if (orderDetails.BiplPrice == 0)
                            orderDetails.BiplPrice = PriceQuoted;

                        orderDetails.PackingType = (reader["PackingType"] != DBNull.Value) ? reader["PackingType"].ToString() : "";
                        orderDetails.OrderPackingType = (reader["OrderPackingType"] != DBNull.Value) ? Convert.ToInt32(reader["OrderPackingType"]) : 0;

                        orderDetails.AmberRangeStart = (reader["AmberRangeStart"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AmberRangeStart"]);
                        orderDetails.AmberRangeEnd = (reader["AmberRangeEnd"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AmberRangeEnd"]);
                        orderDetails.GreenRangeStart = (reader["GreenRangeStart"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GreenRangeStart"]);
                        orderDetails.GreenRangeEnd = (reader["GreenRangeEnd"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GreenRangeEnd"]);
                        orderDetails.RedRangeStart = (reader["RedRangeStart"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["RedRangeStart"]);
                        orderDetails.RedRangeEnd = (reader["RedRangeEnd"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["RedRangeEnd"]);

                        //orderDetails.ExFactoryColor = GetExFactoryColor(orderDetails);
                    }
                }

                cnx.Close();

                return orderDetails;
            }

        }

        public bool InsertOrder(OrderPlace order, int User, ref int NewOrderId, int IsRepeatWithChanges)
        {
            int orderID = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "usp_Insert_order";
                    SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Insert, User);
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;

                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);
                    SqlParameter param;

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = order.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = order.ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDate", SqlDbType.DateTime);
                    param.Value = order.OrderDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
                    param.Value = order.SerialNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Description", SqlDbType.VarChar);
                    param.Value = order.Description;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDepartmentId", SqlDbType.Int);
                    param.Value = order.ParentDepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    param.Value = order.DepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsRepeatWithChanges", SqlDbType.Bit);
                    param.Value = IsRepeatWithChanges;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderType", SqlDbType.Int);
                    param.Value = order.OrderTypes;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryType", SqlDbType.Int);
                    param.Value = order.DeliveryType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedBySalesIkandi", SqlDbType.Bit);
                    param.Value = order.ApprovedBySalesIkandi;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedBySalesBIPL", SqlDbType.Bit);
                    param.Value = order.ApprovedBySalesBIPL;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchandiserManager", SqlDbType.Bit);
                    param.Value = order.ApprovedByMerchandiserManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManager", SqlDbType.Bit);
                    param.Value = order.ApprovedByFabricManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccessoryManager", SqlDbType.Bit);
                    param.Value = order.ApprovedByAccessoryManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedBySalesBIPLOn", SqlDbType.DateTime);
                    if (order.ApprovedBySalesBIPLOn != DateTime.MinValue)
                    {
                        param.Value = order.ApprovedBySalesBIPLOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchandiserManagerOn", SqlDbType.DateTime);
                    if (order.ApprovedByMerchandiserManagerOn != DateTime.MinValue)
                    {
                        param.Value = order.ApprovedByMerchandiserManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManagerOn", SqlDbType.DateTime);
                    if (order.ApprovedByFabricManagerOn != DateTime.MinValue)
                    {
                        param.Value = order.ApprovedByFabricManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccessoryManagerOn", SqlDbType.DateTime);
                    if (order.ApprovedByAccessoryManagerOn != DateTime.MinValue)
                    {
                        param.Value = order.ApprovedByAccessoryManagerOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    orderID = Convert.ToInt32(outParam.Value);

                    if (orderID == -1)
                        return false;

                    order.OrderID = orderID;
                    NewOrderId = orderID;

                    if (order.OrderID > 0)
                    {
                        if (null != order.ContractDetail && order.ContractDetail.Count > 0)
                        {
                            foreach (ContractDetails orderDetail in order.ContractDetail)
                            {
                                if (orderDetail.OrderDetailId <= 0 && orderDetail.isDeleted == 0)
                                {
                                    orderDetail.OrderId = order.OrderID;

                                    int orderDetailId = InsertOrderDetail(orderDetail, cnx, transaction, User);
                                    orderDetail.OrderDetailId = orderDetailId;
                                    //Insert Fabric
                                    foreach (ContractDetailFabric orderdetailfabric in orderDetail.ContractFabric)
                                    {
                                        int ifab = Insert_Update_Fabric_order_detail(orderdetailfabric, cnx, transaction, orderDetail.OrderDetailId, User);
                                    }
                                    //Insert Accessories
                                    if (orderDetail.ContractAccessories != null)
                                    {
                                        foreach (ContractDetailAccessories orderdetailAccess in orderDetail.ContractAccessories)
                                        {
                                            int iAccess = Insert_Update_Accessories_OrderPlace(orderdetailAccess, cnx, transaction, order.OrderID, orderDetail.OrderDetailId, User);
                                        }
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }

                    transaction.Commit();
                    cnx.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    DELETE_Order_Comment(order.SerialNumber);
                    return false;
                }
            }
        }

        public int InsertOrderDetail(ContractDetails orderDetail, SqlConnection cnx, SqlTransaction transaction, int User)
        {

            string cmdText = "usp_Insert_order_detail";

            SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Insert, User);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@d", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@OrderID", SqlDbType.Int);
            param.Value = orderDetail.OrderId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@LineItemNumber", SqlDbType.VarChar);
            param.Value = orderDetail.LineItemNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ContractNumber", SqlDbType.VarChar);
            param.Value = orderDetail.ContractNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = orderDetail.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BIPLPrice", SqlDbType.Float);
            if (orderDetail.BiplPrice > 0)
                param.Value = orderDetail.BiplPrice;
            else
                param.Value = DBNull.Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@iKandiPrice", SqlDbType.Float);
            param.Value = orderDetail.ikandiPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExFactory", SqlDbType.DateTime);
            param.Value = orderDetail.ExFactory;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@WeekToEx", SqlDbType.Int);
            param.Value = orderDetail.ExFactoryWeek;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DC", SqlDbType.DateTime);
            param.Value = orderDetail.DC;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@WeeksToDC", SqlDbType.Int);
            param.Value = orderDetail.DCWeek;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeId", SqlDbType.Int);
            param.Value = orderDetail.ModeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DeliveryInstuction", SqlDbType.Int);
            param.Value = orderDetail.DeliveryInstruction;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TypeOfPacking", SqlDbType.Int);
            param.Value = orderDetail.typeofpacking;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@File1", SqlDbType.VarChar);
            param.Value = orderDetail.PoUpload1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@File2", SqlDbType.VarChar);
            param.Value = orderDetail.PoUpload2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SendProposal", SqlDbType.TinyInt);
            param.Value = orderDetail.SendProposal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryCodeId", SqlDbType.Int);
            param.Value = orderDetail.CountryCodeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int orderDetailID = Convert.ToInt32(outParam.Value);
            return orderDetailID;

        }

        public int Insert_Update_Fabric_order_detail(ContractDetailFabric orderdetailfabric, SqlConnection cnx, SqlTransaction transaction, int OrderDetailId, int User)
        {
            string cmdText = "usp_Insert_Update_Fabric_order_detail";

            SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Insert, User);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;

            param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
            param.Value = OrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SeqId", SqlDbType.Int);
            param.Value = orderdetailfabric.SeqId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricId", SqlDbType.Int);
            param.Value = orderdetailfabric.FabricId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountConstruct", SqlDbType.VarChar);
            param.Value = orderdetailfabric.CountConstruct;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GSM", SqlDbType.Float);
            param.Value = orderdetailfabric.GSM;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricQualityId", SqlDbType.Int);
            param.Value = orderdetailfabric.fabric_qualityID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabTypeId", SqlDbType.Int);
            param.Value = orderdetailfabric.FabTypeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricDetail", SqlDbType.VarChar);
            param.Value = orderdetailfabric.FabricDetail;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SendProposal", SqlDbType.TinyInt);
            param.Value = orderdetailfabric.SendProposal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AcceptProposal", SqlDbType.TinyInt);
            param.Value = orderdetailfabric.AcceptProposal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int isave = cmd.ExecuteNonQuery();
            return isave;

        }

        public int Insert_Update_Accessories_OrderPlace(ContractDetailAccessories orderdetailAccess, SqlConnection cnx, SqlTransaction transaction, int OrderId, int OrderDetailId, int User)
        {
            string cmdText = "usp_Insert_Update_Accessories_OrderPlace";

            SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Insert, User);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;

            param = new SqlParameter("@OrderId", SqlDbType.Int);
            param.Value = OrderId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
            param.Value = OrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SeqId", SqlDbType.Int);
            param.Value = orderdetailAccess.SeqId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoriesId", SqlDbType.Int);
            param.Value = orderdetailAccess.AccessoriesId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoriesName", SqlDbType.VarChar);
            param.Value = orderdetailAccess.AccessoriesName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SizeId", SqlDbType.Int);
            param.Value = orderdetailAccess.SizeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
            if (orderdetailAccess.ColorPrint.ToString() == "")
            {
                param.Value = "N/A";
            }
            else
            {
                param.Value = orderdetailAccess.ColorPrint.Trim();
            }
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsDTM", SqlDbType.Bit);
            param.Value = orderdetailAccess.IsDtm;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SendProposal", SqlDbType.TinyInt);
            param.Value = orderdetailAccess.SendProposal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AcceptProposal", SqlDbType.TinyInt);
            param.Value = orderdetailAccess.AcceptProposal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int isave = cmd.ExecuteNonQuery();
            return isave;

        }

        public bool UpdateOrder(OrderPlace order, int User, ref bool bCheckExistOrderSam, ref int AfterUpdation)
        {
            int orderID = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> IdsCollection = new List<string>();
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "usp_update_order";

                    SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Update, User);
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = order.OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = order.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OldStyleId", SqlDbType.Int);
                    param.Value = order.OldStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = order.ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDate", SqlDbType.DateTime);
                    param.Value = order.OrderDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
                    param.Value = order.SerialNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Description", SqlDbType.VarChar, 1000);
                    param.Value = order.Description;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDepartmentId", SqlDbType.Int);
                    param.Value = order.ParentDepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    param.Value = order.DepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderType", SqlDbType.Int);
                    param.Value = order.OrderTypes;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeliveryType", SqlDbType.Int);
                    param.Value = order.DeliveryType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreementBy", SqlDbType.Int);
                    param.Value = User;//
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedBySalesIkandi", SqlDbType.Bit);
                    param.Value = order.ApprovedBySalesIkandi;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchandiserManager", SqlDbType.Bit);
                    param.Value = order.ApprovedByMerchandiserManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedBySalesBIPL", SqlDbType.Bit);
                    param.Value = order.ApprovedBySalesBIPL;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManager", SqlDbType.Bit);
                    param.Value = order.ApprovedByFabricManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccessoryManager", SqlDbType.Bit);
                    param.Value = order.ApprovedByAccessoryManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByMerchandiserManagerOn", SqlDbType.DateTime);
                    if ((order.ApprovedByMerchandiserManagerOn == DateTime.MinValue) || (order.ApprovedByMerchandiserManagerOn == Convert.ToDateTime("1753-01-01")) || (order.ApprovedByMerchandiserManagerOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Convert.ToDateTime(order.ApprovedByMerchandiserManagerOn);
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedBySalesBIPLOn", SqlDbType.DateTime);
                    if ((order.ApprovedBySalesBIPLOn == DateTime.MinValue) || (order.ApprovedBySalesBIPLOn == Convert.ToDateTime("1753-01-01")) || (order.ApprovedBySalesBIPLOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Convert.ToDateTime(order.ApprovedBySalesBIPLOn);
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByFabricManagerOn", SqlDbType.DateTime);
                    if ((order.ApprovedByFabricManagerOn == DateTime.MinValue) || (order.ApprovedByFabricManagerOn == Convert.ToDateTime("1753-01-01")) || (order.ApprovedByFabricManagerOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Convert.ToDateTime(order.ApprovedByFabricManagerOn);
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedByAccessoryManagerOn", SqlDbType.DateTime);
                    if ((order.ApprovedByAccessoryManagerOn == DateTime.MinValue) || (order.ApprovedByAccessoryManagerOn == Convert.ToDateTime("1753-01-01")) || (order.ApprovedByAccessoryManagerOn == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Convert.ToDateTime(order.ApprovedByAccessoryManagerOn);
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@SendProposal", SqlDbType.TinyInt);
                    param.Value = order.SendProposal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AcceptProposal", SqlDbType.TinyInt);
                    param.Value = order.AcceptProposal;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (orderID == -1)
                        return false;

                    if (order.OrderID > -1)
                    {
                        if (order.IsOrderHistoryCreated)
                        {
                            bool IsHistoryCreated = Create_Order_History(order, cnx, transaction, User);
                        }

                        foreach (ContractDetails objOrderDetail in order.ContractDetail)
                        {

                            if (null != order.ContractDetail && order.ContractDetail.Count > 0)
                            {
                                if (objOrderDetail.OrderDetailId > 0 && objOrderDetail.isDeleted == 0) // if  OrderDetailID exists
                                {
                                    objOrderDetail.OrderId = order.OrderID;
                                    UpdateOrderDetail(objOrderDetail, cnx, transaction, User);

                                    if (objOrderDetail.IsContractHistoryCreated)
                                    {
                                        Create_Contract_History(objOrderDetail, cnx, transaction, User);
                                    }
                                    if (objOrderDetail.isSplitted == 1)
                                    {
                                        order.SplitedQuantityTotal = order.SplitedQuantityTotal + objOrderDetail.Quantity;
                                        order.SplitedQuantityString = order.SplitedQuantityString + objOrderDetail.Quantity.ToString() + ", ";
                                    }

                                    //Insert Fabric
                                    foreach (ContractDetailFabric orderdetailfabric in objOrderDetail.ContractFabric)
                                    {
                                        int ifab = Insert_Update_Fabric_order_detail(orderdetailfabric, cnx, transaction, objOrderDetail.OrderDetailId, User);

                                        if (orderdetailfabric.IsFabricHistoryCreated)
                                        {
                                            Create_Fabric_History(orderdetailfabric, cnx, transaction, objOrderDetail.OrderDetailId, User);
                                        }
                                    }
                                    //Insert Accessories
                                    if (objOrderDetail.ContractAccessories != null)
                                    {
                                        foreach (ContractDetailAccessories orderdetailAccess in objOrderDetail.ContractAccessories)
                                        {
                                            int iAccess = Insert_Update_Accessories_OrderPlace(orderdetailAccess, cnx, transaction, order.OrderID, objOrderDetail.OrderDetailId, User);

                                            if (orderdetailAccess.IsAccessoryHistoryCreated)
                                            {
                                                Create_Accessory_History(orderdetailAccess, cnx, transaction, objOrderDetail.OrderDetailId, User);
                                            }
                                        }
                                    }
                                }
                                else if (objOrderDetail.OrderDetailId <= 0 && objOrderDetail.isDeleted == 0) // if OrderDetailID is newly created
                                {
                                    int orderDetailId = -1;

                                    if (objOrderDetail.OrderDetailId <= 0)
                                    {
                                        objOrderDetail.OrderId = order.OrderID;

                                        if (objOrderDetail.isSplit > 0) // child OrderDetailID of splitted OrderDetailID
                                        {
                                            AfterUpdation = 1;
                                            orderDetailId = InsertOrderDetail_SplitOrder(objOrderDetail.OrderDetailId_Ref, objOrderDetail.Quantity, cnx, transaction);

                                            order.SplitedQuantityTotal = order.SplitedQuantityTotal + objOrderDetail.Quantity;
                                            order.SplitedQuantityString = order.SplitedQuantityString + objOrderDetail.Quantity.ToString() + ", ";

                                            if (orderDetailId > 0)
                                            {
                                                objOrderDetail.OrderDetailId = orderDetailId;
                                                UpdateOrderDetail(objOrderDetail, cnx, transaction, User);  // splitted OrderDetailID updated     

                                                foreach (ContractDetailFabric orderdetailfabric in objOrderDetail.ContractFabric)
                                                {
                                                    int ifab = Insert_Update_Fabric_order_detail(orderdetailfabric, cnx, transaction, objOrderDetail.OrderDetailId, User);
                                                }
                                                //Insert Accessories
                                                if (objOrderDetail.ContractAccessories != null)
                                                {
                                                    foreach (ContractDetailAccessories orderdetailAccess in objOrderDetail.ContractAccessories)
                                                    {
                                                        int iAccess = Insert_Update_Accessories_OrderPlace(orderdetailAccess, cnx, transaction, order.OrderID, objOrderDetail.OrderDetailId, User);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            AfterUpdation = 1;
                                            orderDetailId = InsertOrderDetail(objOrderDetail, cnx, transaction, User);

                                            if (orderDetailId > 0)
                                            {
                                                objOrderDetail.OrderDetailId = orderDetailId;

                                                foreach (ContractDetailFabric orderdetailfabric in objOrderDetail.ContractFabric)
                                                {
                                                    int ifab = Insert_Update_Fabric_order_detail(orderdetailfabric, cnx, transaction, objOrderDetail.OrderDetailId, User);
                                                }
                                                //Insert Accessories
                                                if (objOrderDetail.ContractAccessories != null)
                                                {
                                                    foreach (ContractDetailAccessories orderdetailAccess in objOrderDetail.ContractAccessories)
                                                    {
                                                        int iAccess = Insert_Update_Accessories_OrderPlace(orderdetailAccess, cnx, transaction, order.OrderID, objOrderDetail.OrderDetailId, User);
                                                    }
                                                }
                                            }

                                            //foreach (ContractDetailFabric orderdetailfabric in objOrderDetail.ContractFabric)
                                            //{
                                            //    int ifab = Insert_Update_Fabric_order_detail(orderdetailfabric, cnx, transaction, orderDetailId);
                                            //}
                                        }
                                    }
                                }

                            }
                        }
                        //Create Split Order History
                        if (order.SplittedContractCount > 0)
                        {
                            Create_Contract_Split_History(order, cnx, transaction, User);
                        }
                        //Split All the Sizes
                        if (order.SplittedOrderDetailId > 0)
                        {
                            int Split = SplitOrder_SizeSet(order.SplittedOrderDetailId, cnx, transaction);
                        }
                    }
                    else
                    {
                        return false;
                    }

                    transaction.Commit();
                    cnx.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return false;
                }
            }

        }

        public int InsertOrderDetail_SplitOrder(int OrderDetailID,int Quantity, SqlConnection cnx, SqlTransaction transaction)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            string cmdText = "sp_insert_order_detail_SplitOrder";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;

            outParam = new SqlParameter("@Id", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@OrderDetailID", SqlDbType.VarChar);
            param.Value = OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int orderDetailID = Convert.ToInt32(outParam.Value);

            return orderDetailID;
        }

        public string DeleteOrderDetail(int OrderDetailId, int UserId)
        {
            string ErrorMsg = string.Empty;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_order_detail_delete_order_detail";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam = new SqlParameter("@ERROR", SqlDbType.VarChar, 1000);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    ErrorMsg = outParam.Value.ToString();

                    cnx.Close();

                }
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message.ToString();
            }
            return ErrorMsg;
        }

        public bool AutoAllocation_ReallocationOrder(int orderID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> IdsCollection = new List<string>();
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "usp_AutoAllocation";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = orderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateOrderDetail(ContractDetails orderDetail, SqlConnection cnx, SqlTransaction transaction, int User)
        {
            string cmdText = "usp_Update_order_detail";

            SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Update, User);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@Id", SqlDbType.Int);
            param.Value = orderDetail.OrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderID", SqlDbType.Int);
            param.Value = orderDetail.OrderId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LineItemNumber", SqlDbType.VarChar);
            param.Value = orderDetail.LineItemNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ContractNumber", SqlDbType.VarChar);
            param.Value = orderDetail.ContractNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = Convert.ToInt32(orderDetail.Quantity);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BIPLPrice", SqlDbType.Float);
            if (orderDetail.BiplPrice != 0)
                param.Value = orderDetail.BiplPrice;
            else
                param.Value = DBNull.Value;

            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@iKandiPrice", SqlDbType.Float);
            param.Value = orderDetail.ikandiPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@ExFactory", SqlDbType.DateTime);
            param.Value = orderDetail.ExFactory;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@WeekToEx", SqlDbType.Int);
            param.Value = orderDetail.ExFactoryWeek;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DC", SqlDbType.DateTime);
            param.Value = orderDetail.DC;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@WeeksToDC", SqlDbType.Int);
            param.Value = orderDetail.DCWeek;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeId", SqlDbType.VarChar);
            param.Value = orderDetail.ModeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DeliveryInstuction", SqlDbType.Int);
            param.Value = orderDetail.DeliveryInstruction;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TypeOfPacking", SqlDbType.Int);
            param.Value = orderDetail.typeofpacking;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@File1", SqlDbType.VarChar);
            param.Value = orderDetail.PoUpload1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@File2", SqlDbType.VarChar);
            param.Value = orderDetail.PoUpload2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SendProposal", SqlDbType.TinyInt);
            param.Value = orderDetail.SendProposal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AcceptProposal", SqlDbType.TinyInt);
            param.Value = orderDetail.AcceptProposal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryCodeId", SqlDbType.Int);
            param.Value = orderDetail.CountryCodeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsSplit", SqlDbType.Bit);
            param.Value = orderDetail.isSplit;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsSplitted", SqlDbType.Int);
            param.Value = orderDetail.isSplitted;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int i = cmd.ExecuteNonQuery();

            return true;
        }

        public bool Create_Order_History(OrderPlace order, SqlConnection cnx, SqlTransaction transaction, int User)
        {
            string cmdText = "Usp_Create_Order_History";

            SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Insert, User);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@OrderID", SqlDbType.Int);
            param.Value = order.OrderID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TypeFlag", SqlDbType.Int);
            param.Value = order.TypeFlag;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Parent Department History
            param = new SqlParameter("@IsParentDept_Change", SqlDbType.Bit);
            param.Value = order.IsParentDept_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentDept_OldValue", SqlDbType.VarChar);
            param.Value = order.ParentDept_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentDept_NewValue", SqlDbType.VarChar);
            param.Value = order.ParentDept_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Department History
            param = new SqlParameter("@IsDept_Change", SqlDbType.Bit);
            param.Value = order.IsDept_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentDept_OldId", SqlDbType.Int);
            param.Value = order.ParentDept_OldId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentDept_NewId", SqlDbType.Int);
            param.Value = order.ParentDept_NewId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Dept_OldValue", SqlDbType.VarChar);
            param.Value = order.Dept_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Dept_NewValue", SqlDbType.VarChar);
            param.Value = order.Dept_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Description History
            param = new SqlParameter("@IsDescription_Change", SqlDbType.Bit);
            param.Value = order.IsDescription_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description_OldValue", SqlDbType.VarChar);
            param.Value = order.Description_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description_NewValue", SqlDbType.VarChar);
            param.Value = order.Description_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // OrderType History
            param = new SqlParameter("@IsOrderType_Change", SqlDbType.Bit);
            param.Value = order.IsOrderType_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderType_OldValue", SqlDbType.VarChar);
            param.Value = order.OrderType_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderType_NewValue", SqlDbType.VarChar);
            param.Value = order.OrderType_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //Approved By History
            param = new SqlParameter("@IsBiplManagerChecked", SqlDbType.Bit);
            param.Value = order.IsBiplManagerChecked;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsAccountManagerChecked", SqlDbType.Bit);
            param.Value = order.IsAccountManagerChecked;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsFabricManagerChecked", SqlDbType.Bit);
            param.Value = order.IsFabricManagerChecked;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsAccessoryManagerChecked", SqlDbType.Bit);
            param.Value = order.IsAccessoryManagerChecked;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int i = cmd.ExecuteNonQuery();

            return true;
        }

        public bool Create_Contract_History(ContractDetails orderDetail, SqlConnection cnx, SqlTransaction transaction, int UserId)
        {
            string cmdText = "Usp_Create_Contract_History";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@OrderID", SqlDbType.Int);
            param.Value = orderDetail.OrderId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailId", SqlDbType.BigInt);
            param.Value = orderDetail.OrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // LineNumber History
            param = new SqlParameter("@IsLineNumber_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsLineNumber_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LineNumber_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.LineNumber_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LineNumber_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.LineNumber_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // ContractNumber History
            param = new SqlParameter("@IsContractNumber_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsContractNumber_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ContractNumber_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.ContractNumber_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ContractNumber_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.ContractNumber_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Quantity History
            param = new SqlParameter("@IsQuantity_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsQuantity_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.Quantity_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.Quantity_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Mode History
            param = new SqlParameter("@IsMode_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsMode_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Mode_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.Mode_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Mode_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.Mode_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // ExFactory History
            param = new SqlParameter("@IsExFactory_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsExFactory_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExFactory_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.ExFactory_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExFactory_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.ExFactory_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // DC History
            param = new SqlParameter("@IsDC_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsDC_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DC_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.DC_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DC_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.DC_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // BIPLPrice History
            param = new SqlParameter("@IsBIPLPrice_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsBIPLPrice_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BIPLPrice_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.BIPLPrice_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BIPLPrice_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.BIPLPrice_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // IkandiPrice History
            param = new SqlParameter("@IsIkandiPrice_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsIkandiPrice_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IkandiPrice_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.IkandiPrice_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IkandiPrice_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.IkandiPrice_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // DeliveryInstruct History
            param = new SqlParameter("@IsDeliveryInstruct_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsDeliveryInstruct_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DeliveryInstruct_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.DeliveryInstruct_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DeliveryInstruct_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.DeliveryInstruct_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Typeofpacking History
            param = new SqlParameter("@IsTypeofpacking_Change", SqlDbType.Bit);
            param.Value = orderDetail.IsTypeofpacking_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Typeofpacking_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.Typeofpacking_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Typeofpacking_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.Typeofpacking_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Country Code History
            param = new SqlParameter("@IsCountryCodeChange", SqlDbType.Bit);
            param.Value = orderDetail.IsCountryCodeChange;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryCode_OldValue", SqlDbType.VarChar);
            param.Value = orderDetail.CountryCode_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountryCode_NewValue", SqlDbType.VarChar);
            param.Value = orderDetail.CountryCode_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserId", SqlDbType.Int);
            param.Value = UserId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int i = cmd.ExecuteNonQuery();

            return true;
        }

        public bool Create_Contract_Split_History(OrderPlace order, SqlConnection cnx, SqlTransaction transaction, int UserId)
        {
            string cmdText = "Usp_Create_Contract_Split_History";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@OrderID", SqlDbType.Int);
            param.Value = order.OrderID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailId", SqlDbType.BigInt);
            param.Value = order.SplittedOrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SplittedContractCount", SqlDbType.Int);
            param.Value = order.SplittedContractCount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalQty", SqlDbType.VarChar);
            param.Value = order.SplitedQuantityTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SplittedQty", SqlDbType.VarChar, 200);
            param.Value = order.SplitedQuantityString.Trim().TrimEnd(',');
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserId", SqlDbType.Int);
            param.Value = UserId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int i = cmd.ExecuteNonQuery();

            return true;
        }

        public bool Create_Fabric_History(ContractDetailFabric orderFabric, SqlConnection cnx, SqlTransaction transaction, int OrderDetailId, int User)
        {
            string cmdText = "Usp_Create_Fabric_History";

            SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Insert, User);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
            param.Value = OrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricName", SqlDbType.VarChar);
            param.Value = orderFabric.FabricName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsFabricDetail_Change", SqlDbType.Bit);
            param.Value = orderFabric.IsFabricDetail_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricDetail_OldValue", SqlDbType.VarChar);
            param.Value = orderFabric.FabricDetail_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricDetail_NewValue", SqlDbType.VarChar);
            param.Value = orderFabric.FabricDetail_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SeqId", SqlDbType.Int);
            param.Value = orderFabric.FabricDetailSeq;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int i = cmd.ExecuteNonQuery();

            return true;
        }

        public bool Create_Accessory_History(ContractDetailAccessories orderAccess, SqlConnection cnx, SqlTransaction transaction, int OrderDetailId, int User)
        {
            string cmdText = "Usp_Create_Accessory_History";

            SqlCommand cmd = OrderPlaceSqlCommand(cmdText, cnx, QueryType.Insert, User);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
            param.Value = OrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoryName", SqlDbType.VarChar);
            param.Value = orderAccess.AccessoriesName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsColorPrint_Change", SqlDbType.Bit);
            param.Value = orderAccess.IsColorPrint_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ColorPrint_OldValue", SqlDbType.VarChar);
            param.Value = orderAccess.ColorPrint_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ColorPrint_NewValue", SqlDbType.VarChar);
            param.Value = orderAccess.ColorPrint_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsDtm_Change", SqlDbType.Bit);
            param.Value = orderAccess.IsDtm_Change;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsDtm_OldValue", SqlDbType.VarChar);
            param.Value = orderAccess.IsDtm_OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsDtm_NewValue", SqlDbType.VarChar);
            param.Value = orderAccess.IsDtm_NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SeqId", SqlDbType.Int);
            param.Value = orderAccess.AccessSeq;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int i = cmd.ExecuteNonQuery();

            return true;
        }

        public string DELETE_Order_Comment(string SerialNo)
        {
            string ErrorMsg = string.Empty;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_DELETE_Order_Comment";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@SerialNo", SqlDbType.VarChar);
                    param.Value = SerialNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message.ToString();
            }
            return ErrorMsg;
        }

        public int OpenOrderForikandi(int OrderId, int IsClose)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_OpenOrderForikandi";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsClose", SqlDbType.Int);
                param.Value = IsClose;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                int iSave = cmd.ExecuteNonQuery();


                cnx.Close();

                return iSave;
            }
        }

        public List<string> GetAllPrintNumber(string searchValue, int ClientId, int PrintCategory)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAllPrintNumber";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SearchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
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

        public int CheckAccessories(string searchValue)
        {
            int AccessoryExist = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_CheckAccessories";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@searchValue", SqlDbType.VarChar);
                param.Value = searchValue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                AccessoryExist = Convert.ToInt16(cmd.ExecuteScalar());

                cnx.Close();
            }
            return AccessoryExist;
        }

        #endregion

        #region OrderPlace

        public List<ContractDetailAccessories> Get_Accessories_Section_OrderPlace(int OrderId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_Accessories_Section_OrderPlace";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();
                List<ContractDetailAccessories> orderDetailAccessCollection = new List<ContractDetailAccessories>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                        orderDetailAccess.AccId = (reader["AccId"] == DBNull.Value) ? -1 : Convert.ToInt64(reader["AccId"]);
                        orderDetailAccess.AccessoriesId = (reader["AccessoriesId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoriesId"]);
                        orderDetailAccess.AccessoriesName = (reader["AccessoriesName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoriesName"]);
                        orderDetailAccess.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        orderDetailAccess.SizeId = (reader["SizeId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SizeId"]);
                        orderDetailAccess.SeqId = (reader["SequenceNumber"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SequenceNumber"]);
                        orderDetailAccessCollection.Add(orderDetailAccess);
                    }
                }

                return orderDetailAccessCollection;
            }
        }

        public bool Delete_Accessories_OrderPlace(Int64 AccId, int UserID)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_Delete_Accessories_OrderPlace";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@AccId", SqlDbType.BigInt);
                    param.Value = AccId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }

        }

        public bool Insert_Update_Accessories(List<ContractDetailAccessories> ContractDetailAccess, int OrderId, int OrderDetailId, int User)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    foreach (ContractDetailAccessories orderdetailAccess in ContractDetailAccess)
                    {
                        int iAccess = Insert_Update_Accessories_OrderPlace(orderdetailAccess, cnx, transaction, OrderId, OrderDetailId, User);
                    }

                    transaction.Commit();
                    cnx.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool SplitOrder(int orderID, int orderDetailID, int parentOrder, int User, int Sort, int Sno)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> IdsCollection = new List<string>();
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_orders_split_order";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = orderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = orderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentId", SqlDbType.Int);
                    param.Value = parentOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Sort", SqlDbType.Int);
                    param.Value = Sort;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SplittedBy", SqlDbType.Int);
                    param.Value = User;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Sno", SqlDbType.Int);
                    param.Value = Sno;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();


                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public int SplitOrder_SizeSet(int ParentOrderDetailId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_order_Split_SizeSet";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;

            param = new SqlParameter("@ParentOrderDetailID", SqlDbType.Int);
            param.Value = ParentOrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            int isave = cmd.ExecuteNonQuery();
            return isave;

        }

        public DataSet GetSizeSetDetails(int ClientId, int DeptId, int OptionId, int OrderDetailId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;
                    cmdText = "Usp_GetSizeSetOption_OrderPlace";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OptionId", SqlDbType.Int);
                    if (OptionId > 0)
                        param.Value = OptionId;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    if (OrderDetailId > 0)
                        param.Value = OrderDetailId;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    //if (ds == null || ds.Tables[0].Rows.Count < 1)
                    //    return null;

                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }

            return ds;

        }

        public bool Insert_Update_OrderDetail_Size(ContractDetailSize orderDetailSize, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "Usp_Insert_Update_order_detail_size";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = orderDetailSize.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SizeOption", SqlDbType.Int);
                    param.Value = orderDetailSize.SizeOption;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size", SqlDbType.VarChar);
                    param.Value = orderDetailSize.Size.Trim();
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Singles", SqlDbType.Int);
                    if (orderDetailSize.Singles > 0)
                    {
                        param.Value = orderDetailSize.Singles;
                    }
                    else
                    {
                        param.Value = DBNull.Value;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@RatioPack", SqlDbType.Int);
                    if (orderDetailSize.RatioPack.HasValue)
                    {
                        param.Value = orderDetailSize.RatioPack;
                    }
                    else
                    {
                        param.Value = DBNull.Value;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Ratio", SqlDbType.Int);
                    if (orderDetailSize.RatioPack.HasValue)
                    {
                        param.Value = orderDetailSize.Ratio;
                    }
                    else
                    {
                        param.Value = DBNull.Value;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public static string GetExFactoryColor(ContractDetails orderDetail)
        {
            int days = Convert.ToInt16((orderDetail.DC - orderDetail.ExFactory).TotalDays);

            if (days >= orderDetail.RedRangeStart && days <= orderDetail.RedRangeEnd)
                return "#ff3300";
            else if (days <= orderDetail.AmberRangeEnd && days >= orderDetail.AmberRangeStart)
                return "#fd9903";
            else if (days <= orderDetail.GreenRangeEnd && days >= orderDetail.GreenRangeStart)
                return "#00FF70";
            return "#fd9903";
        }

        public List<OrderHistory> Get_Order_History(int OrderId, int Typeflag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_Order_History";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TypeFlag", SqlDbType.Int);
                param.Value = Typeflag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<OrderHistory> orderHistoryCollection = new List<OrderHistory>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        OrderHistory objOrderHistory = new OrderHistory();
                        objOrderHistory.OrderDetailId = (reader["OrderDetailId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailId"]);
                        objOrderHistory.TypeFlag = (reader["TypeFlag"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["TypeFlag"]);
                        objOrderHistory.FieldName = (reader["FieldName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FieldName"]);
                        objOrderHistory.OldValue = (reader["OldValue"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["OldValue"]);
                        objOrderHistory.NewValue = (reader["NewValue"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["NewValue"]);
                        objOrderHistory.DetailDescription = (reader["DetailDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DetailDescription"]);

                        orderHistoryCollection.Add(objOrderHistory);

                    }
                }

                return orderHistoryCollection;
            }
        }

        //added by raghvinder on 08-12-2020 start
        public bool IsOldHistoryCommentsValid(int OrderId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;
                    cmdText = "usp_IsOldHistoryComments";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }

                if (dt == null || dt.Rows.Count < 1)
                {
                    return false;
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["VALUE"]) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public List<OrderOldHistoryComments> Get_Old_Order_History(int OrderId, int Typeflag, int Type = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                if (Type == 1)
                {
                    cmdText = "Usp_Get_Order_History";
                }
                else
                {
                    cmdText = "Usp_Get_Order_Comment";
                }

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TypeFlag", SqlDbType.Int);
                param.Value = Typeflag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<OrderOldHistoryComments> OldHistoryCollection = new List<OrderOldHistoryComments>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderOldHistoryComments objOldHistory = new OrderOldHistoryComments();
                        objOldHistory.History = (reader["History"] == DBNull.Value) ? string.Empty : reader["History"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("$$", "</br>").Replace("</br></br>", "</br>").Replace("</br></br>", "</br>").Replace("$", "").Remove(0, 5);
                        objOldHistory.Comments = (reader["Commentes"] == DBNull.Value) ? string.Empty : reader["Commentes"].ToString().Replace("$$", " ");
                        objOldHistory.Flag = (reader["Flag"] == DBNull.Value) ? string.Empty : reader["Flag"].ToString();

                        OldHistoryCollection.Add(objOldHistory);

                    }
                }

                return OldHistoryCollection;
            }
        }
        //added by raghvinder on 08-12-2020 end

        public bool Create_Order_Comment(OrderComment ordercomment, int User)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<string> IdsCollection = new List<string>();
                SqlTransaction transaction = null;

                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "Usp_Create_Order_Comment";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = ordercomment.OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SerialNo", SqlDbType.VarChar);
                    param.Value = ordercomment.SerialNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TypeFlag", SqlDbType.Int);
                    param.Value = ordercomment.TypeFlag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comment", SqlDbType.VarChar, 2000);
                    param.Value = ordercomment.Comment;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = User;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();


                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<OrderComment> Get_Order_Comment(int OrderId, string SerialNo, int Typeflag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_Order_Comment";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SerialNo", SqlDbType.VarChar);
                param.Value = SerialNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TypeFlag", SqlDbType.Int);
                param.Value = Typeflag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<OrderComment> orderCommentCollection = new List<OrderComment>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderComment objOrderComment = new OrderComment();
                        objOrderComment.TypeFlag = (reader["TypeFlag"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["TypeFlag"]);
                        objOrderComment.FieldName = (reader["FieldName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FieldName"]);
                        objOrderComment.DetailDescription = (reader["DetailDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DetailDescription"]);

                        orderCommentCollection.Add(objOrderComment);
                    }
                }

                return orderCommentCollection;
            }
        }

        public List<ClientCountryCode> GetClientCountryCode(int ClientId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetClientCountryCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                reader = cmd.ExecuteReader();

                List<ClientCountryCode> objListCountry = new List<ClientCountryCode>();

                while (reader.Read())
                {
                    ClientCountryCode cCode = new ClientCountryCode();
                    cCode.CountryId = Convert.ToInt32(reader["Country_Code_Id"]);
                    cCode.CountryCode = Convert.ToString(reader["Country_Code"]);
                    objListCountry.Add(cCode);
                }
                return objListCountry;
            }
        }

        public List<DeliveryMode> GetLeadTime_Days_ByMode(int ModeID, string CountryCode)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetLeadTime_Days_ByMode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter paramIn;

                paramIn = new SqlParameter("@ModeId", SqlDbType.Int);
                paramIn.Value = ModeID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@CountryCode", SqlDbType.VarChar);
                paramIn.Value = CountryCode;
                cmd.Parameters.Add(paramIn);

                reader = cmd.ExecuteReader();
                List<DeliveryMode> modes = new List<DeliveryMode>();

                while (reader.Read())
                {
                    DeliveryMode deliveryMode = new DeliveryMode();
                    deliveryMode.ActualExDC = (reader["ActualEXDC"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ActualEXDC"]);
                    deliveryMode.LeadTime = (reader["LeadTime"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["LeadTime"]);
                    modes.Add(deliveryMode);
                }

                return modes;
            }
        }

        public int Update_Accessory_Order_Qty_ByOrderId(int OrderID)
        {
            int Result = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "USP_Update_Accessory_Order_Qty_ByOrderId";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                Result = cmd.ExecuteNonQuery();
                cnx.Close();

                return Result;
            }
        }

        public List<AccessoryPending> GetOrderAccesoryHistory(int OrderId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;

                string cmdText = "usp_AccessoriesHistory";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryHistoryList = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryHis = new AccessoryPending();
                        objAccessoryHis.DetailDescription = (reader["DetailDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DetailDescription"]);
                        AccessoryHistoryList.Add(objAccessoryHis);
                    }
                }
                return AccessoryHistoryList;
            }
        }
        #endregion
    }
}
