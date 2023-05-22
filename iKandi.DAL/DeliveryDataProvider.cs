using System;
using System.Collections.Generic;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class DeliveryDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public DeliveryDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<ProductionPlanning> GetProductionPlanningOrders(int iFactoryManagerID, int iClientId, string iSearch)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_production_planning_get_production_planning_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = iFactoryManagerID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = iClientId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = iSearch;
                cmd.Parameters.Add(param);

                DataSet dsPPOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPPOrders);

                List<ProductionPlanning> orders = new List<ProductionPlanning>();

                DataTable table = dsPPOrders.Tables[0];
                DataTable packingDimensions = dsPPOrders.Tables[1];

                foreach (DataRow row in table.Rows)
                {
                    ProductionPlanning pp = new ProductionPlanning();

                    pp.ProductionPlanningID = (row["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(row["ProductionPlanningID"]) : -1;
                    pp.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : -1;
                    pp.ReasonForShortShipping = (row["ReasonForShortShipping"] != DBNull.Value) ? Convert.ToString(row["ReasonForShortShipping"]) : string.Empty;
                    pp.IsShipmentPlanning = (row["IsShipmentPlanning"] != DBNull.Value) ? Convert.ToBoolean(row["IsShipmentPlanning"]) : false;
                    pp.IsShortShipment = (row["IsShortShipment"] != DBNull.Value) ? Convert.ToBoolean(row["IsShortShipment"]) : false;
                    pp.IsPartShipment = (row["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(row["IsPartShipment"]) : false;
                    pp.PlannedEx = (row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : DateTime.MinValue;
                    pp.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;
                    pp.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    pp.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                    pp.ParentOrder = new Order();
                    pp.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    pp.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;
                    pp.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    pp.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                    pp.ParentOrder.Style = new Style();
                    pp.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    pp.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                    pp.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    pp.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    pp.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    pp.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;

                    if (pp.ShipmentQty == -1)
                        pp.ShipmentQty = pp.Quantity;

                    pp.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    pp.CCGSM = (row["Fabric11"] != DBNull.Value) ? Convert.ToString(row["Fabric11"]) : string.Empty;
                    pp.Fabric1Details = (row["Fabric1DetailsRef"] != DBNull.Value) ? Convert.ToString(row["Fabric1DetailsRef"]) : string.Empty;
                    pp.CuttingETA = (row["SealETA"] != DBNull.Value) ? Convert.ToDateTime(row["SealETA"]) : DateTime.MinValue;
                    pp.StitchingETA = (row["StitchingETA"] != DBNull.Value) ? Convert.ToDateTime(row["StitchingETA"]) : DateTime.MinValue;

                    pp.TopSentTarget = (row["TopSentTarget"] != DBNull.Value) ? Convert.ToDateTime(row["TopSentTarget"]) : pp.StitchingETA;
                    pp.TopActualApproval = (row["TopActualApproval"] != DBNull.Value) ? Convert.ToDateTime(row["TopActualApproval"]) : DateTime.MinValue;

                    pp.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;

                    pp.ExFactory = (row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue;
                    pp.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;

                    pp.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    pp.Unit = new ProductionUnit();
                    pp.Unit.FactoryCode = (row["FactoryCode"] != DBNull.Value) ? Convert.ToString(row["FactoryCode"]) : string.Empty;

                    pp.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    pp.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : 0;
                    pp.StatusModeSequence = (row["StatusModeSequence"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeSequence"]) : 0;
                   
                    

                    pp.Packing = new Packing();
                    pp.Packing.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    pp.Packing.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty;
                    pp.Packing.TotalGrossWeight = (row["TotalGrossWeight"] != DBNull.Value) ? Convert.ToDouble(row["TotalGrossWeight"]) : 0;
                    pp.Packing.TotalNetWeight = (row["TotalNetWeight"] != DBNull.Value) ? Convert.ToDouble(row["TotalNetWeight"]) : 0;
                    pp.Packing.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;

                    DataRow[] results = packingDimensions.Select("PackingID=" + pp.Packing.PackingID);

                    pp.Packing.Dimensions = new List<PackingDimension>();

                    foreach (DataRow dimRow in results)
                    {
                        PackingDimension pd = new PackingDimension();

                        pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                        pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                        pd.PackingID = pp.Packing.PackingID;
                        pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                        pp.Packing.Dimensions.Add(pd);
                    }

                    orders.Add(pp);
                }

                cnx.Close();

                return orders;

            }
        }

        public void UpdateProductionPlanningOrder(ProductionPlanning pp)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_production_planning_update_available_order";

                SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Insert);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = pp.ProductionPlanningID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = pp.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShippingQty", SqlDbType.Int);
                param.Value = pp.ShipmentQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BalanceQty", SqlDbType.Int);
                param.Value = pp.Quantity - pp.ShipmentQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReasonForShortShipping", SqlDbType.VarChar);
                param.Value = pp.ReasonForShortShipping;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sShortShipment", SqlDbType.Bit);
                param.Value = pp.IsShortShipment;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PlannedEx", SqlDbType.DateTime);
                if ((pp.PlannedEx == DateTime.MinValue) || (pp.PlannedEx == Convert.ToDateTime("1753-01-01")) || (pp.PlannedEx == Convert.ToDateTime("1900-01-01")))
            //    if (pp.PlannedEx == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = pp.PlannedEx;
                }
                
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }

        public void UpdateProductionPlannedOrder(ProductionPlanning pp)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_production_planning_update_planned_order";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = pp.ProductionPlanningID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PlannedEx", SqlDbType.DateTime);
                param.Value = pp.PlannedEx;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }

        public List<ProductionPlanning> GetOrdersForShipmentPlanning(int ClientID, string Search,int intId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_shipment_planning_get_shipment_planning_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ClientID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Search;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BuyingHouseID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = intId;
                cmd.Parameters.Add(param);
                DataSet dsPPOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsPPOrders);

                List<ProductionPlanning> orders = new List<ProductionPlanning>();

                DataTable table = dsPPOrders.Tables[0];
                DataTable packingDimensions = dsPPOrders.Tables[1];

                foreach (DataRow row in table.Rows)
                {
                    ProductionPlanning pp = new ProductionPlanning();

                    pp.ProductionPlanningID = (row["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(row["ProductionPlanningID"]) : -1;
                    pp.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : -1;
                    pp.ReasonForShortShipping = (row["ReasonForShortShipping"] != DBNull.Value) ? Convert.ToString(row["ReasonForShortShipping"]) : string.Empty;
                    pp.IsShipmentPlanning = (row["IsShipmentPlanning"] != DBNull.Value) ? Convert.ToBoolean(row["IsShipmentPlanning"]) : false;
                    //pp.IsProductionPlanning = (row["IsProductionPlanning"] != DBNull.Value) ? Convert.ToBoolean(row["IsProductionPlanning"]) : false;
                    pp.PlannedEx = (row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : DateTime.MinValue;
                    pp.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    pp.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                    Update_Productionplanning(pp.OrderDetailID);
                    pp.ParentOrder = new Order();
                    pp.ParentOrder.ClientID = (row["ClientId"] != DBNull.Value) ? Convert.ToInt32(row["ClientId"]) : -1;
                    pp.ParentOrder.Client = new Client();
                    pp.ParentOrder.Client.ClientID = pp.ParentOrder.ClientID;
                    pp.ParentOrder.Client.CompanyName = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                    pp.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    pp.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    pp.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                    pp.ParentOrder.Style = new Style();
                    pp.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    pp.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                    pp.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    pp.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;

                    pp.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    pp.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    pp.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;

                    if (pp.ShipmentQty == -1)
                        pp.ShipmentQty = pp.Quantity;

                    pp.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    pp.Fabric1Details = (row["Fabric1Details"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                    pp.CuttingETA = (row["SealETA"] != DBNull.Value) ? Convert.ToDateTime(row["SealETA"]) : DateTime.MinValue;
                    pp.TopSentTarget = (row["TopSentTarget"] != DBNull.Value) ? Convert.ToDateTime(row["TopSentTarget"]) : DateTime.MinValue;
                    pp.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    pp.ExFactory = (row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue;
                    pp.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;
                    pp.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;

                    pp.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    pp.Unit = new ProductionUnit();
                    pp.Unit.FactoryCode = (row["FactoryCode"] != DBNull.Value) ? Convert.ToString(row["FactoryCode"]) : string.Empty;

                    pp.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    pp.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : -1;
                    pp.ApprovedToExSequence = (row["ApprovedToExSequence"] != DBNull.Value) ? Convert.ToInt32(row["ApprovedToExSequence"]) : 0;

                    pp.Packing = new Packing();
                    pp.Packing.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    pp.Packing.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty;
                    pp.Packing.TotalGrossWeight = (row["TotalGrossWeight"] != DBNull.Value) ? Convert.ToDouble(row["TotalGrossWeight"]) : 0;
                    pp.Packing.TotalNetWeight = (row["TotalNetWeight"] != DBNull.Value) ? Convert.ToDouble(row["TotalNetWeight"]) : 0;
                    pp.Packing.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;
                    pp.ShipmentPlanningOrderId = (row["ShipmentPlanningOrderId"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentPlanningOrderId"]) : -1;
                    pp.ShipmentNo = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;
                    pp.ShipmentId = (row["ShipmentId"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentId"]) : -1;
                    //string ccgsm = qualityControl.OrderDetail.OrderDetailccgsm;

                    string ccgsm = (row["Fabric11"] != DBNull.Value) ? Convert.ToString(row["Fabric11"]) : string.Empty;
                    //pp.CCGSM = (row["Fabric11"] != DBNull.Value) ? Convert.ToString(row["Fabric11"]) : string.Empty;
                    //try
                    //{
                    //    string ccgsmvalue = string.Empty;
                    //    string[] ccgsmpart = ccgsm.Split(' ');
                    //    if (ccgsmpart[2] == "" && ccgsmpart[1] == "CC:")
                    //    {
                    //        ccgsm = ccgsmpart[2] + ccgsmpart[3];
                    //    }
                    //    if (ccgsmpart[4] == "" && ccgsmpart[3] == "GSM:")
                    //    {
                    //        ccgsm += ccgsmpart[0] + ccgsmpart[1];
                    //    }

                    //}
                    //catch (Exception)
                    //{
                    //}
                   pp.CCGSM = ccgsm;

                    if (pp.Packing.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + pp.Packing.PackingID);

                        pp.Packing.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = pp.Packing.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            pp.Packing.Dimensions.Add(pd);
                        }
                    }

                    orders.Add(pp);
                }

                cnx.Close();

                return orders;
            }
        }

        public void UpdateShipmentPlanningOrder(ProductionPlanning pp)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_shipment_planning_update_planned_order";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = pp.ProductionPlanningID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = pp.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sShippingPlanning", SqlDbType.Int);
                param.Value = pp.IsShipmentPlanning;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShippingQty", SqlDbType.Int);
                param.Value = pp.ShipmentQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }

        public void Update_Productionplanning(int OrderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Update_ProductionPlanning";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
              

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

               

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }

        public List<ShipmentPlanning> GetShipmentPlannedOrders(string stringSearchText, string txtAdvice, int iClientIdPlaning, int iClientIdAdvise)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
             
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_shipment_planning_get_shipment_planned_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SearchStr", SqlDbType.VarChar);
                param.Value = stringSearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter("@SearchAdvice", SqlDbType.VarChar);
                param1.Value = txtAdvice;
                param1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@ClientIdPlaning", SqlDbType.Int);
                param2.Value = iClientIdPlaning;
                param2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@ClientIdAdvice", SqlDbType.Int);
                param3.Value = iClientIdAdvise;
                param3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param3);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                List<ShipmentPlanning> shipmentPlanning = new List<ShipmentPlanning>();

                DataTable dtShipment = dsOrders.Tables[0];
                DataTable dtShipmentPlanning = dsOrders.Tables[1];
                DataTable packingDimensions = dsOrders.Tables[2];

                foreach (DataRow row in dtShipment.Rows)
                {
                    ShipmentPlanning sp = new ShipmentPlanning();

                    sp.ShipmentID = (row["Id"] != DBNull.Value) ? Convert.ToInt32(row["Id"]) : -1;
                    sp.BLAWBNumber = (row["BLAWBNo"] != DBNull.Value) ? Convert.ToString(row["BLAWBNo"]) : string.Empty;
                    sp.ExpectedDispatchDate = (row["ExpectedDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(row["ExpectedDispatchDate"]) : DateTime.MinValue;
                    sp.DCDate = (row["DCDate"] != DBNull.Value) ? Convert.ToDateTime(row["DCDate"]) : DateTime.MinValue;
                    sp.FlightSailingDetails = (row["FlightSailingDetails"] != DBNull.Value) ? Convert.ToString(row["FlightSailingDetails"]) : string.Empty;
                    sp.FlightDate = (row["FlightDate"] != DBNull.Value) ? Convert.ToDateTime(row["FlightDate"]) : DateTime.MinValue;
                    sp.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;

                    sp.Partner = new Partner();
                    sp.Partner.PartnerID = (row["PartnerID"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID"]) : -1;
                    sp.Partner.PartnerName = (row["PartnerName"] != DBNull.Value) ? Convert.ToString(row["PartnerName"]) : string.Empty;

                    sp.Partner2 = new Partner();
                    sp.Partner2.PartnerID = (row["PartnerID2"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID2"]) : -1;
                    sp.Partner2.PartnerName = (row["PartnerName2"] != DBNull.Value) ? Convert.ToString(row["PartnerName2"]) : string.Empty;

                    sp.IndiaPartner = new Partner();
                    sp.IndiaPartner.PartnerID = (row["PartnerID3"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID3"]) : -1;
                    sp.IndiaPartner.PartnerName = (row["PartnerName3"] != DBNull.Value) ? Convert.ToString(row["PartnerName3"]) : string.Empty;

                    sp.SendEmail = (row["SendEmail"] != DBNull.Value) ? Convert.ToInt32(row["SendEmail"]) : -1;
                    sp.ShipmentInstructionsFile = (row["ShipmentInstructionsFile"] != DBNull.Value) ? Convert.ToString(row["ShipmentInstructionsFile"]) : string.Empty;
                    sp.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;
                    sp.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                    sp.SpecialInstructions = (row["SpecialInstructions"] != DBNull.Value) ? Convert.ToString(row["SpecialInstructions"]) : string.Empty;
                    sp.UploadDocument = (row["UploadDocument"] != DBNull.Value) ? Convert.ToString(row["UploadDocument"]) : string.Empty;
                    sp.IsShipmentAdvise = (row["IsShipmentAdvise"] != DBNull.Value) ? Convert.ToBoolean(row["IsShipmentAdvise"]) : false;
                    sp.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    shipmentPlanning.Add(sp);
                }

                List<ShipmentPlanningOrder> shipmentOrders = new List<ShipmentPlanningOrder>();

                foreach (DataRow row in dtShipmentPlanning.Rows)
                {
                    ShipmentPlanningOrder spo = new ShipmentPlanningOrder();

                    int shipQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;
                    int poQty = (row["POQty"] != DBNull.Value) ? Convert.ToInt32(row["POQty"]) : 0;

                    spo.IsPartShipment = (row["POIsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(row["POIsPartShipment"]) : (shipQty != poQty);
                    spo.PackingList = new Packing();
                    spo.PackingList.PackingID = (row["PackingListID"] != DBNull.Value) ? Convert.ToInt32(row["PackingListID"]) : -1;
                    spo.PackingList.InvoiceID = (row["InvoiceID"] != DBNull.Value) ? Convert.ToInt32(row["InvoiceID"]) : -1;
                    spo.PackingList.InvoiceNumber = (row["BIPLInvoiceNumber2"] != DBNull.Value) ? Convert.ToString(row["BIPLInvoiceNumber2"]) : string.Empty;
                    spo.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;
                    spo.PartShipmentRemarks = (row["ReasonForShortShipping"] != DBNull.Value) ? Convert.ToString(row["ReasonForShortShipping"]) : string.Empty;
                    spo.ShipmentPlanningOrderID = (row["ShipmentPlanningOrderID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentPlanningOrderID"]) : -1;
                    spo.ModeId = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    spo.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    spo.ClientId = (row["ClientId"] != DBNull.Value) ? Convert.ToInt32(row["ClientId"]) : -1;
                    spo.PlannedEx = (row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : DateTime.MinValue;
                    spo.ProductionPlanningId = row["ProductionPlanningId"] != DBNull.Value ? Convert.ToInt32(row["ProductionPlanningId"]) : -1;

                    int shipmentID = (row["ShipmentID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentID"]) : -1;

                    ShipmentPlanning sp = shipmentPlanning.Find(delegate(ShipmentPlanning splanning)
                    {
                        return splanning.ShipmentID == shipmentID;
                    });

                    if (sp != null)
                    {
                        spo.ShipmentPlanning = sp;

                        if (spo.ShipmentPlanning.ShipmentPlanningOrders == null)
                            spo.ShipmentPlanning.ShipmentPlanningOrders = new List<ShipmentPlanningOrder>();

                        spo.ShipmentPlanning.ShipmentPlanningOrders.Add(spo);
                        sp.TotalPackages += spo.PackingList.TotalPackages;
                    }
                    else
                    {
                        spo.ShipmentPlanning = new ShipmentPlanning();
                        spo.ShipmentPlanning.ShipmentID = shipmentID;

                        if (spo.ShipmentPlanning.ShipmentPlanningOrders == null)
                            spo.ShipmentPlanning.ShipmentPlanningOrders = new List<ShipmentPlanningOrder>();

                        spo.ShipmentPlanning.ShipmentPlanningOrders.Add(spo);

                        shipmentPlanning.Add(spo.ShipmentPlanning);
                    }

                    


                    spo.QAStatus = (row["QAStatus"] != DBNull.Value) ? ((Convert.ToInt32(row["QAStatus"]) == 1) ? "PASS" : (Convert.ToInt32(row["QAStatus"]) == 2) ? "FAIL" : string.Empty) : string.Empty;
                    spo.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    spo.StatusModeId = (row["StatusModeId"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeId"]) : 0;
                    spo.StatusModeSequence = (row["StatusModeSequence"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeSequence"]) : 0;
                    spo.DELIVEREDSequence = (row["DELIVEREDSequence"] != DBNull.Value) ? Convert.ToInt32(row["DELIVEREDSequence"]) : 0;
                    spo.ApprovedToExSequence = (row["ApprovedToExSequence"] != DBNull.Value) ? Convert.ToInt32(row["ApprovedToExSequence"]) : 0;
                    spo.UploadBuyerList = (row["UploadBuyerList"] != DBNull.Value) ? Convert.ToString(row["UploadBuyerList"]) : string.Empty;
                    spo.UploadCustomList = (row["UploadCustomList"] != DBNull.Value) ? Convert.ToString(row["UploadCustomList"]) : string.Empty;
                    spo.UploadDocument = (row["UploadDocument"] != DBNull.Value) ? Convert.ToString(row["UploadDocument"]) : string.Empty;

                    if (spo.PackingList.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + spo.PackingList.PackingID);

                        spo.PackingList.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = spo.PackingList.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            spo.PackingList.Dimensions.Add(pd);
                        }
                    }

                    if (row["Mode"] != null)
                    {
                        string modeName = string.Empty;

                        modeName = Convert.ToString(row["Code"]);

                        if (modeName != string.Empty)
                        {
                            if (modeName.ToLower().IndexOf("d") > -1)
                            {
                                spo.ShipmentTo = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                                spo.ShipmentTo += " / " + modeName;
                            }
                            else
                            {
                                spo.ShipmentTo = "iKandi / " + modeName;
                            }
                        }
                    }

                    spo.Unit = new ProductionUnit();
                    spo.Unit.FactoryCode = (row["ProductionUnitCode"] != DBNull.Value) ? Convert.ToString(row["ProductionUnitCode"]) : string.Empty;
                    spo.Unit.FactoryName = (row["ProductionUnitName"] != DBNull.Value) ? Convert.ToString(row["ProductionUnitName"]) : string.Empty;

                    shipmentOrders.Add(spo);
                }

                cnx.Close();

                return shipmentPlanning;

            }
        }

        public void UpdateBookingOrder(DeliveryBooking BookingOrder)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_booking_update_booking";

                SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Insert);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@BookingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BookingOrder.BookingID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BookingRequestedOn", SqlDbType.DateTime);
                if ((BookingOrder.BookingRequestedOn == DateTime.MinValue) || (BookingOrder.BookingRequestedOn == Convert.ToDateTime("1753-01-01")) || (BookingOrder.BookingRequestedOn == Convert.ToDateTime("1900-01-01")))
               // if (BookingOrder.BookingRequestedOn == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.BookingRequestedOn;
                }                
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BookingReferenceNo", SqlDbType.VarChar);
                param.Value = BookingOrder.BookingReferenceNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sPackinglistCompleteBooking", SqlDbType.Int);
                param.Value = BookingOrder.IsPackinglistCompleteBooking;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExpectedDC", SqlDbType.DateTime);
                if ((BookingOrder.ExpectedDC == DateTime.MinValue) || (BookingOrder.ExpectedDC == Convert.ToDateTime("1753-01-01")) || (BookingOrder.ExpectedDC == Convert.ToDateTime("1900-01-01")))
                //if (BookingOrder.ExpectedDC == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.ExpectedDC;
                }                  
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = BookingOrder.OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BookingDocuments", SqlDbType.VarChar);
                param.Value = BookingOrder.BookingDocuments;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Value = BookingOrder.ProductionPlanningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }

        public void UpdateProcessingOrder(DeliveryBooking BookingOrder)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_booking_save_processing_order";

                SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@BookingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BookingOrder.BookingID;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                //param.Direction = ParameterDirection.Input;
                //param.Value = BookingOrder.OrderDetailID;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@NextStatusETA", SqlDbType.DateTime);
                //param.Value = BookingOrder.NextStatusETA;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@DeliveryNoteFile", SqlDbType.VarChar);
                param.Value = BookingOrder.DeliveryNoteFile;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sPackinglistCompletePartner", SqlDbType.Int);
                param.Value = BookingOrder.IsPackinglistCompletePartner;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CargoReceiptDate", SqlDbType.DateTime);
                if ((BookingOrder.CargoReceiptDate == DateTime.MinValue) || (BookingOrder.CargoReceiptDate == Convert.ToDateTime("1753-01-01")) || (BookingOrder.CargoReceiptDate == Convert.ToDateTime("1900-01-01")))
               // if (BookingOrder.CargoReceiptDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.CargoReceiptDate;
                }                    
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeliveredDate", SqlDbType.DateTime);
                if ((BookingOrder.DeliveredDate == DateTime.MinValue) || (BookingOrder.DeliveredDate == Convert.ToDateTime("1753-01-01")) || (BookingOrder.DeliveredDate == Convert.ToDateTime("1900-01-01")))
               // if (BookingOrder.DeliveredDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.DeliveredDate;
                }                
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessingCompletedOn", SqlDbType.DateTime);
                if ((BookingOrder.ProcessingCompleteOn == DateTime.MinValue) || (BookingOrder.ProcessingCompleteOn == Convert.ToDateTime("1753-01-01")) || (BookingOrder.ProcessingCompleteOn == Convert.ToDateTime("1900-01-01")))
                //if (BookingOrder.ProcessingCompleteOn == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.ProcessingCompleteOn;
                }                   
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeliveryNoteReceivedOn", SqlDbType.DateTime);
                if ((BookingOrder.DeliveryNoteReceivedOn == DateTime.MinValue) || (BookingOrder.DeliveryNoteReceivedOn == Convert.ToDateTime("1753-01-01")) || (BookingOrder.DeliveryNoteReceivedOn == Convert.ToDateTime("1900-01-01")))
                //if (BookingOrder.DeliveryNoteReceivedOn == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.DeliveryNoteReceivedOn;
                }               
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Value = BookingOrder.ProductionPlanningID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();
            }
        }

        public void UpdateForwarderOrder(DeliveryBooking BookingOrder)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_booking_save_forwarder_order";

                SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Insert);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@BookingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BookingOrder.BookingID;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                //param.Direction = ParameterDirection.Input;
                //param.Value = BookingOrder.OrderDetailID;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@DeliveryNoteFile", SqlDbType.VarChar);
                param.Value = BookingOrder.DeliveryNoteFile;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sPackinglistCompletePartner", SqlDbType.Int);
                param.Value = BookingOrder.IsPackinglistCompletePartner;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CargoReceiptDate", SqlDbType.DateTime);
                if ((BookingOrder.CargoReceiptDate == DateTime.MinValue) || (BookingOrder.CargoReceiptDate == Convert.ToDateTime("1753-01-01")) || (BookingOrder.CargoReceiptDate == Convert.ToDateTime("1900-01-01")))
               // if (BookingOrder.CargoReceiptDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.CargoReceiptDate;
                }                
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SentToProcessingHouseOn", SqlDbType.DateTime);
               // if (BookingOrder.SentToProcessingHouseOn == DateTime.MinValue)
                    if ((BookingOrder.SentToProcessingHouseOn == DateTime.MinValue) || (BookingOrder.SentToProcessingHouseOn == Convert.ToDateTime("1753-01-01")) || (BookingOrder.SentToProcessingHouseOn == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.SentToProcessingHouseOn;
                }                
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeliveredDate", SqlDbType.DateTime);
                if ((BookingOrder.DeliveredDate == DateTime.MinValue) || (BookingOrder.DeliveredDate == Convert.ToDateTime("1753-01-01")) || (BookingOrder.DeliveredDate == Convert.ToDateTime("1900-01-01")))
                //if (BookingOrder.DeliveredDate == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.DeliveredDate;
                } 
               
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeliveryNoteReceivedOn", SqlDbType.DateTime);
                if ((BookingOrder.DeliveryNoteReceivedOn == DateTime.MinValue) || (BookingOrder.DeliveryNoteReceivedOn == Convert.ToDateTime("1753-01-01")) || (BookingOrder.DeliveryNoteReceivedOn == Convert.ToDateTime("1900-01-01")))
              //  if (BookingOrder.DeliveryNoteReceivedOn == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = BookingOrder.DeliveryNoteReceivedOn;
                }                 
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BookingOrder.ProductionPlanningID;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                cnx.Close();
            }
        }

        public List<DeliveryBooking> GetBookingOrders(int ClientID, string Search)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_delivery_get_booking_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ClientID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Search;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                DataTable dtBookingAvailable = dsOrders.Tables[0];
                DataTable dtBookingOrders = dsOrders.Tables[1];
                DataTable packingDimensions = dsOrders.Tables[2];

                List<DeliveryBooking> bookingOrders = new List<DeliveryBooking>();

                foreach (DataRow row in dtBookingAvailable.Rows)
                {
                    DeliveryBooking booking = new DeliveryBooking();

                    booking.IsBooking = false;

                    booking.ShipmentPlanningOrder = new ShipmentPlanningOrder();

                    booking.ParentOrder = new Order();
                    booking.ParentOrder.Style = new Style();
                    booking.ParentOrder.Client = new Client();
                    booking.ParentOrder.Client.CompanyName = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;

                    booking.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                    booking.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    booking.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    booking.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;
                    booking.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    booking.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                    booking.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                    booking.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    booking.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    booking.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    booking.ExFactory = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : ((row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : ((row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue));
                    booking.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;
                    booking.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    booking.CCGSM = (row["Fabric11"] != DBNull.Value) ? Convert.ToString(row["Fabric11"]) : string.Empty;
                    booking.Fabric1Details = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                    booking.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    booking.MDA = (row["MDA"] != DBNull.Value) ? Convert.ToString(row["MDA"]) : string.Empty;
                    booking.ProductionPlanningID = (row["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(row["ProductionPlanningID"]) : -1;
                    booking.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    
                    booking.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    booking.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : -1;

                    booking.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;
                    booking.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;
                    booking.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;

                    booking.ShipmentPlanningOrder.ShipmentPlanning = new ShipmentPlanning();
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentID = (row["ShipmentID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentID"]) : -1;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                    booking.ShipmentPlanningOrder.PackingList = new Packing();
                    booking.ShipmentPlanningOrder.PackingList.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    booking.ShipmentPlanningOrder.PackingList.InvoiceNumber = (row["InvoiceNo"] != DBNull.Value) ? Convert.ToString(row["InvoiceNo"]) : string.Empty;
                    booking.ShipmentPlanningOrder.PackingList.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty; ;
                    booking.ShipmentPlanningOrder.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;

                    if (booking.ShipmentPlanningOrder.PackingList.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + booking.ShipmentPlanningOrder.PackingList.PackingID);

                        booking.ShipmentPlanningOrder.PackingList.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = booking.ShipmentPlanningOrder.PackingList.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            booking.ShipmentPlanningOrder.PackingList.Dimensions.Add(pd);
                        }
                    }

                    bookingOrders.Add(booking);
                }

                foreach (DataRow row in dtBookingOrders.Rows)
                {
                    DeliveryBooking booking = new DeliveryBooking();

                    booking.IsBooking = true;

                    booking.BookingID = (row["BookingID"] != DBNull.Value) ? Convert.ToInt32(row["BookingID"]) : -1;
                    booking.BookingRequestedOn = (row["BookingRequestedOn"] != DBNull.Value) ? Convert.ToDateTime(row["BookingRequestedOn"]) : DateTime.MinValue;
                    booking.BookingReferenceNo = (row["BookingReferenceNo"] != DBNull.Value) ? Convert.ToString(row["BookingReferenceNo"]) : string.Empty;
                    booking.ExpectedDC = (row["ExpectedDC"] != DBNull.Value) ? Convert.ToDateTime(row["ExpectedDC"]) : DateTime.MinValue;

                    booking.ShipmentPlanningOrder = new ShipmentPlanningOrder();

                    booking.ParentOrder = new Order();
                    booking.ParentOrder.Style = new Style();
                    booking.ParentOrder.Client = new Client();
                    booking.ParentOrder.Client.CompanyName = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;

                    booking.IsEmailSent = (row["IsEmailSent"] != DBNull.Value) ? Convert.ToBoolean(row["IsEmailSent"]) : false;
                    booking.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                    booking.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    booking.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    booking.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;
                    booking.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    booking.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                    booking.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                    booking.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    booking.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    booking.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    booking.ExFactory = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : ((row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : ((row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue));
                    booking.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;
                    booking.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    booking.CCGSM = (row["Fabric11"] != DBNull.Value) ? Convert.ToString(row["Fabric11"]) : string.Empty;


                    booking.Fabric1Details = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                    booking.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    booking.MDA = (row["MDA"] != DBNull.Value) ? Convert.ToString(row["MDA"]) : string.Empty;
                    booking.NextStatusETA = (row["NextStatusETA"] != DBNull.Value) ? Convert.ToDateTime(row["NextStatusETA"]) : DateTime.MinValue;
                    booking.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;
                    booking.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;
                    booking.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;
                    booking.IsPackinglistCompleteBooking = (row["IsPackinglistCompleteBooking"] != DBNull.Value) ? Convert.ToBoolean(row["IsPackinglistCompleteBooking"]) : false;
                    booking.ProductionPlanningID = (row["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(row["ProductionPlanningID"]) : -1;

                    booking.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    booking.BookingDocuments = (row["BookingDocuments"] != DBNull.Value) ? Convert.ToString(row["BookingDocuments"]) : string.Empty;
                    booking.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    booking.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : -1;

                    booking.ShipmentPlanningOrder.ShipmentPlanning = new ShipmentPlanning();
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentID = (row["ShipmentID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentID"]) : -1;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                    booking.ShipmentPlanningOrder.PackingList = new Packing();
                    booking.ShipmentPlanningOrder.PackingList.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    booking.ShipmentPlanningOrder.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : -1;
                    booking.ShipmentPlanningOrder.PackingList.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty;
                    booking.ShipmentPlanningOrder.PackingList.InvoiceNumber = (row["InvoiceNo"] != DBNull.Value) ? Convert.ToString(row["InvoiceNo"]) : string.Empty;

                    if (booking.ShipmentPlanningOrder.PackingList.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + booking.ShipmentPlanningOrder.PackingList.PackingID);

                        booking.ShipmentPlanningOrder.PackingList.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = booking.ShipmentPlanningOrder.PackingList.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            booking.ShipmentPlanningOrder.PackingList.Dimensions.Add(pd);
                        }
                    }

                    bookingOrders.Add(booking);
                }

                cnx.Close();

                return bookingOrders;

            }
        }

        public void SaveShipmentPlanning(ShipmentPlanning SP)
        {
            
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlTransaction transaction = cnx.BeginTransaction();

                try
                {
                    string cmdText = "sp_shipping_planning_save";

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@NewShipmentID", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@ShipmentID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SP.ShipmentID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentNoInitial", SqlDbType.VarChar);
                    param.Value = SP.ShipmentNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentInstructionsFile", SqlDbType.VarChar);
                    param.Value = SP.ShipmentInstructionsFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartnerID", SqlDbType.Int);
                    if (SP.Partner.PartnerID == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = SP.Partner.PartnerID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartnerID2", SqlDbType.Int);
                    if (SP.Partner2.PartnerID == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = SP.Partner2.PartnerID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartnerID3", SqlDbType.Int);
                    if (SP.IndiaPartner.PartnerID == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = SP.IndiaPartner.PartnerID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentSentForwarder", SqlDbType.DateTime);
                    if ((SP.ShipmentSentForwarder == DateTime.MinValue) || (SP.ShipmentSentForwarder == Convert.ToDateTime("1753-01-01")) || (SP.ShipmentSentForwarder == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.ShipmentSentForwarder;
                    }                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalPackages", SqlDbType.Int);
                    param.Value = SP.TotalPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BLAWBNo", SqlDbType.VarChar);
                    param.Value = SP.BLAWBNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExpectedDispatchDate", SqlDbType.DateTime);
                    if ((SP.ExpectedDispatchDate == DateTime.MinValue) || (SP.ExpectedDispatchDate == Convert.ToDateTime("1753-01-01")) || (SP.ExpectedDispatchDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.ExpectedDispatchDate;
                    }                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightSailingDetails", SqlDbType.VarChar);
                    param.Value = SP.FlightSailingDetails;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LandingETA", SqlDbType.DateTime);
                    if ((SP.LandingETA == DateTime.MinValue) || (SP.LandingETA == Convert.ToDateTime("1753-01-01")) || (SP.LandingETA == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.LandingETA;
                    }                  

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DCDate", SqlDbType.DateTime);
                    if ((SP.DCDate == DateTime.MinValue) || (SP.DCDate == Convert.ToDateTime("1753-01-01")) || (SP.DCDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.DCDate;
                    }                   
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SendEmail", SqlDbType.Int);
                    param.Value = SP.SendEmail;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadDocument", SqlDbType.VarChar);
                    param.Value = SP.UploadDocument;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SpecialInstructions", SqlDbType.VarChar);
                    param.Value = SP.SpecialInstructions;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentAdvise", SqlDbType.Int);
                    param.Value = SP.IsShipmentAdvise;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);                    

                    cmd.ExecuteNonQuery();

                    int shipmentID = Convert.ToInt32(outParam.Value);
                    
                    foreach (ShipmentPlanningOrder order in SP.ShipmentPlanningOrders)
                    {
                        if (order.ShipmentPlanning == null)
                            order.ShipmentPlanning = new ShipmentPlanning();

                        order.ShipmentPlanning.ShipmentID = shipmentID;

                        if (order.IsShipmentPlanning)
                        {
                            if (order.IsDelete)
                            {
                                this.DeleteShipmentPlannedOrder(order.ShipmentPlanningOrderID, shipmentID, cnx, transaction);                                
                            }
                            else
                                SaveShipmentPlannedOrder(order, cnx, transaction);
                        }
                        else if (!(order.IsShipmentPlanning))
                        {
                            if (order.IsDeleteShipment)
                            {
                                this.DeleteShipmentPlannedOrderPrevious(order.ShipmentPlanningOrderID, shipmentID, true, cnx, transaction);
                                order.ShipmentPlanningOrderID = -1;
                                SavePreviousShipmentPlannedOrder(order, cnx, transaction);
                            }
                            else
                            SavePreviousShipmentPlannedOrder(order, cnx, transaction);
                        }
                        
                    }

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

                cnx.Close();


            }

        }

        private void SaveShipmentPlannedOrder(ShipmentPlanningOrder Order, SqlConnection cnx, SqlTransaction transaction)
        {

            string cmdText = "sp_shipping_planning_order_save";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;
            cmd.Connection = cnx;

            SqlParameter param;
            param = new SqlParameter("@ShipmentPlanningOrderID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = Order.ShipmentPlanningOrderID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ShipmentID", SqlDbType.Int);
            param.Value = Order.ShipmentPlanning.ShipmentID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PackingListID", SqlDbType.Int);
            if (Order.PackingList.PackingID == -1)
                param.Value = DBNull.Value;
            else
                param.Value = Order.PackingList.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UploadCustomList", SqlDbType.VarChar);
            param.Value = Order.UploadCustomList;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UploadBuyerList", SqlDbType.VarChar);
            param.Value = Order.UploadBuyerList;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UploadDocument", SqlDbType.VarChar);
            param.Value = Order.UploadDocument;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sPartShipment", SqlDbType.Int);
            param.Value = Order.IsPartShipment;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartShipmentRemarks", SqlDbType.VarChar);
            param.Value = Order.PartShipmentRemarks;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();


        }

        private void SavePreviousShipmentPlannedOrder(ShipmentPlanningOrder Order, SqlConnection cnx, SqlTransaction transaction)
        {

            string cmdText = "sp_shipping_planning_order_save_previous";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;
            cmd.Connection = cnx;

            SqlParameter param;
            param = new SqlParameter("@ShipmentPlanningOrderID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = Order.ShipmentPlanningOrderID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ShipmentID", SqlDbType.Int);
            param.Value = Order.ShipmentPlanning.ShipmentID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PackingListID", SqlDbType.Int);
            if (Order.PackingList.PackingID == -1)
                param.Value = DBNull.Value;
            else
                param.Value = Order.PackingList.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UploadCustomList", SqlDbType.VarChar);
            param.Value = Order.UploadCustomList;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UploadBuyerList", SqlDbType.VarChar);
            param.Value = Order.UploadBuyerList;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UploadDocument", SqlDbType.VarChar);
            param.Value = Order.UploadDocument;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sPartShipment", SqlDbType.Int);
            param.Value = Order.IsPartShipment;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartShipmentRemarks", SqlDbType.VarChar);
            param.Value = Order.PartShipmentRemarks;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sDeleteShipment", SqlDbType.Bit);
            param.Value = Order.IsDeleteShipment;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);            

            cmd.ExecuteNonQuery();


        }

        public void SaveShipmentPlanningAdvise(ShipmentPlanning SP)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlTransaction transaction = cnx.BeginTransaction();

                try
                {
                    string cmdText = "sp_shipping_planning_save_advise";

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Update);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@ShipmentID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SP.ShipmentID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShipmentNo", SqlDbType.VarChar);
                    param.Value = SP.ShipmentNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BLAWBNo", SqlDbType.VarChar);
                    param.Value = SP.BLAWBNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExpectedDispatchDate", SqlDbType.DateTime);
                    //param.Value = SP.ExpectedDispatchDate;
                    if ((SP.ExpectedDispatchDate == DateTime.MinValue) || (SP.ExpectedDispatchDate == Convert.ToDateTime("1753-01-01")) || (SP.ExpectedDispatchDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.ExpectedDispatchDate;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightSailingDetails", SqlDbType.VarChar);
                    param.Value = SP.FlightSailingDetails;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightDate", SqlDbType.DateTime);
                    //param.Value = SP.FlightDate;
                    if ((SP.FlightDate == DateTime.MinValue) || (SP.FlightDate == Convert.ToDateTime("1753-01-01")) || (SP.FlightDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.FlightDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LandingETA", SqlDbType.DateTime);
                    if ((SP.LandingETA == DateTime.MinValue) || (SP.LandingETA == Convert.ToDateTime("1753-01-01")) || (SP.LandingETA == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.LandingETA;
                    }


                    //if (SP.LandingETA == null || SP.LandingETA == DateTime.MinValue)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = SP.LandingETA;

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DCDate", SqlDbType.DateTime);
                    if ((SP.DCDate == DateTime.MinValue) || (SP.DCDate == Convert.ToDateTime("1753-01-01")) || (SP.DCDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SP.DCDate;
                    }
                    //if (SP.DCDate == null || SP.DCDate == DateTime.MinValue)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = SP.DCDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SendEmail", SqlDbType.Int);
                    param.Value = SP.SendEmail;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadDocument", SqlDbType.VarChar);
                    param.Value = SP.UploadDocument;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SpecialInstructions", SqlDbType.VarChar);
                    param.Value = SP.SpecialInstructions;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sShipmentAdvise", SqlDbType.Bit);
                    param.Value = SP.IsShipmentAdvise;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

                cnx.Close();


            }

        }

        private void DeleteShipmentPlannedOrder(int ShipmentPlanningOrderID, int shipmentID,SqlConnection cnx, SqlTransaction transaction)
        {

            string cmdText = "sp_shipment_plannnig_order_delete";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;
            cmd.Connection = cnx;


            SqlParameter param;

            param = new SqlParameter("@ShipmentPlanningOrderID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = ShipmentPlanningOrderID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ShipmentID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = shipmentID;
            cmd.Parameters.Add(param);

           cmd.ExecuteNonQuery();

        }

        private void DeleteShipmentPlannedOrderPrevious(int ShipmentPlanningOrderID, int shipmentID, bool isDeleteShipment, SqlConnection cnx, SqlTransaction transaction)
        {

            string cmdText = "sp_shipment_plannnig_order_delete_previous";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;
            cmd.Connection = cnx;


            SqlParameter param;

            param = new SqlParameter("@ShipmentPlanningOrderID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = ShipmentPlanningOrderID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ShipmentID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = shipmentID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sDeleteShipment", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = isDeleteShipment;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }

        public List<DeliveryBooking> GetOrdersForProcessing(int PartnerID, int ClientID, string Search)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_delivery_get_processing_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@PartnerID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = PartnerID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ClientID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Search;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                DataTable dtBookingAvailable = dsOrders.Tables[0];
                DataTable packingDimensions = dsOrders.Tables[1];

                List<DeliveryBooking> bookingOrders = new List<DeliveryBooking>();

                foreach (DataRow row in dtBookingAvailable.Rows)
                {
                    DeliveryBooking booking = new DeliveryBooking();

                    booking.IsBooking = false;

                    booking.ShipmentPlanningOrder = new ShipmentPlanningOrder();

                    booking.ParentOrder = new Order();
                    booking.ParentOrder.Style = new Style();
                    booking.ParentOrder.Client = new Client();
                    booking.ParentOrder.Client.CompanyName = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                    
                    booking.BookingID = (row["BookingID"] != DBNull.Value) ? Convert.ToInt32(row["BookingID"]) : -1;
                    booking.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                    booking.ProductionPlanningID = (row["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(row["ProductionPlanningID"]) : -1;
                    booking.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    booking.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    booking.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;
                    booking.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    booking.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                    booking.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                    booking.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    booking.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    booking.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    booking.ExFactory = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : ((row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : ((row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue));
                    booking.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;
                    booking.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    booking.Fabric1Details = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                    booking.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    booking.MDA = (row["MDA"] != DBNull.Value) ? Convert.ToString(row["MDA"]) : string.Empty;
                    booking.NextStatusETA = (row["NextStatusETA"] != DBNull.Value) ? Convert.ToDateTime(row["NextStatusETA"]) : DateTime.MinValue;
                    booking.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;
                    booking.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;
                    booking.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;
                    booking.IsPartShipment = (row["IsPartShipment5"] != DBNull.Value) ? (Convert.ToInt32(row["IsPartShipment5"]) == 1 ? true : false) : false;

                    int ProcessingInstructionID = (row["ProcessingInstruction"] != DBNull.Value) ? Convert.ToInt32(row["ProcessingInstruction"]) : -1;
                    string ProcessingInstruction = Constants.GetProcessingInstructionName(ProcessingInstructionID);
                    if (ProcessingInstruction == "other".ToUpper())
                    {
                        booking.ProcessingInstructions = (row["OtherInstruction"] == DBNull.Value) ? string.Empty : Convert.ToString(row["OtherInstruction"]);
                    }
                    else
                    {
                        booking.ProcessingInstructions = ProcessingInstruction;
                    }
                    booking.SpecialInstructions = (row["SpecialInstruction"] == DBNull.Value) ? string.Empty : Convert.ToString(row["SpecialInstruction"]);

                    booking.ModeName = (row["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Code"]);
                   
                    booking.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    booking.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : -1;

                    booking.DeliveryNoteFile = (row["DeliveryNoteFile"] != DBNull.Value) ? Convert.ToString(row["DeliveryNoteFile"]) : string.Empty;
                    booking.BookingReferenceNo = (row["BookingReferenceNo"] != DBNull.Value) ? Convert.ToString(row["BookingReferenceNo"]) : string.Empty;
                    booking.DeliveryNoteReceivedOn = (row["DeliveryNoteReceivedOn"] != DBNull.Value) ? Convert.ToDateTime(row["DeliveryNoteReceivedOn"]) : DateTime.MinValue;
                    booking.DeliveredDate = (row["DeliveredDate"] != DBNull.Value) ? Convert.ToDateTime(row["DeliveredDate"]) : DateTime.MinValue;
                    booking.SentToProcessingHouseOn = (row["SentToProcessingHouseOn"] != DBNull.Value) ? Convert.ToDateTime(row["SentToProcessingHouseOn"]) : DateTime.MinValue;
                    booking.CargoReceiptDate = (row["CargoReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(row["CargoReceiptDate"]) : DateTime.MinValue;
                    booking.ExpectedDC = (row["ExpectedDC"] != DBNull.Value) ? Convert.ToDateTime(row["ExpectedDC"]) : DateTime.MinValue;
                    booking.ProcessingCompleteOn = (row["ProcessingCompletedOn"] != DBNull.Value) ? Convert.ToDateTime(row["ProcessingCompletedOn"]) : DateTime.MinValue;

                    booking.ShipmentPlanningOrder.ShipmentPlanning = new ShipmentPlanning();
                    booking.ShipmentPlanningOrder.ShipmentPlanning.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                    booking.ShipmentPlanningOrder.PackingList = new Packing();
                    booking.ShipmentPlanningOrder.PackingList.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    booking.ShipmentPlanningOrder.PackingList.InvoiceNumber = (row["BIPLInvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["BIPLInvoiceNumber"]) : string.Empty;
                    booking.ShipmentPlanningOrder.PackingList.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty; ;
                    booking.ShipmentPlanningOrder.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;

                    if (booking.ShipmentPlanningOrder.PackingList.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + booking.ShipmentPlanningOrder.PackingList.PackingID);

                        booking.ShipmentPlanningOrder.PackingList.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = booking.ShipmentPlanningOrder.PackingList.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            booking.ShipmentPlanningOrder.PackingList.Dimensions.Add(pd);
                        }
                    }

                    bookingOrders.Add(booking);
                }


                cnx.Close();

                return bookingOrders;
            }
        }

        public List<DeliveryBooking> GetOrdersForForwarding(int PartnerID, int ClientID, string Search)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_delivery_get_forwarding_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@PartnerID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = PartnerID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ClientID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = Search;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                DataTable dtBookingAvailable = dsOrders.Tables[0];
                DataTable packingDimensions = dsOrders.Tables[1];

                List<DeliveryBooking> bookingOrders = new List<DeliveryBooking>();

                foreach (DataRow row in dtBookingAvailable.Rows)
                {
                    DeliveryBooking booking = new DeliveryBooking();

                    booking.IsBooking = false;

                    booking.ShipmentPlanningOrder = new ShipmentPlanningOrder();

                    booking.ParentOrder = new Order();
                    booking.ParentOrder.Style = new Style();
                    booking.ParentOrder.Client = new Client();
                    booking.ParentOrder.Client.CompanyName = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                    
                    booking.BookingID = (row["BookingID"] != DBNull.Value) ? Convert.ToInt32(row["BookingID"]) : -1;
                    booking.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                    booking.ProductionPlanningID = (row["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(row["ProductionPlanningID"]) : -1;
                    booking.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                    booking.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                    booking.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;
                    booking.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                    booking.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                    booking.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                    booking.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                    booking.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                    booking.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                    booking.ExFactory = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : ((row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : ((row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue));
                    booking.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;
                    booking.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                    booking.Fabric1Details = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                    booking.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    booking.MDA = (row["MDA"] != DBNull.Value) ? Convert.ToString(row["MDA"]) : string.Empty;
                    booking.NextStatusETA = (row["NextStatusETA"] != DBNull.Value) ? Convert.ToDateTime(row["NextStatusETA"]) : DateTime.MinValue;
                    booking.DC = (row["DC"] != DBNull.Value) ? Convert.ToDateTime(row["DC"]) : DateTime.MinValue;
                    booking.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;
                    booking.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;
                    booking.IsPartShipment = (row["IsPartShipment5"] != DBNull.Value) ? (Convert.ToInt32(row["IsPartShipment5"]) == 1 ? true : false) : false;
                    booking.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    booking.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    booking.StatusModeID = (row["StatusModeID"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeID"]) : -1;
                    booking.StatusModeSequence = (row["StatusModeSequence"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeSequence"]) : -1;
                    booking.DeliveryNoteReceivedOn = (row["DeliveryNoteReceivedOn"] != DBNull.Value) ? Convert.ToDateTime(row["DeliveryNoteReceivedOn"]) : DateTime.MinValue;
                    booking.DeliveredDate = (row["DeliveredDate"] != DBNull.Value) ? Convert.ToDateTime(row["DeliveredDate"]) : DateTime.MinValue;
                    booking.DeliveryNoteFile = (row["DeliveryNoteFile"] != DBNull.Value) ? Convert.ToString(row["DeliveryNoteFile"]) : string.Empty;
                    booking.BookingReferenceNo = (row["BookingReferenceNo"] != DBNull.Value) ? Convert.ToString(row["BookingReferenceNo"]) : string.Empty;
                    booking.SentToProcessingHouseOn = (row["SentToProcessingHouseOn"] != DBNull.Value) ? Convert.ToDateTime(row["SentToProcessingHouseOn"]) : DateTime.MinValue;
                    booking.CargoReceiptDate = (row["CargoReceiptDate"] != DBNull.Value) ? Convert.ToDateTime(row["CargoReceiptDate"]) : DateTime.MinValue;
                    booking.ExpectedDC = (row["ExpectedDC"] != DBNull.Value) ? Convert.ToDateTime(row["ExpectedDC"]) : DateTime.MinValue;

                    booking.ShipmentPlanningOrder.ShipmentPlanning = new ShipmentPlanning();
                    booking.ShipmentPlanningOrder.ShipmentPlanning.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                    booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                    booking.ShipmentPlanningOrder.PackingList = new Packing();
                    booking.ShipmentPlanningOrder.PackingList.PackingID = (row["PackingID"] != DBNull.Value) ? Convert.ToInt32(row["PackingID"]) : -1;
                    booking.ShipmentPlanningOrder.PackingList.InvoiceNumber = (row["BIPLInvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["BIPLInvoiceNumber"]) : string.Empty;
                    booking.ShipmentPlanningOrder.PackingList.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty; ;
                    booking.ShipmentPlanningOrder.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;

                    if (booking.ShipmentPlanningOrder.PackingList.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + booking.ShipmentPlanningOrder.PackingList.PackingID);

                        booking.ShipmentPlanningOrder.PackingList.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = booking.ShipmentPlanningOrder.PackingList.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            booking.ShipmentPlanningOrder.PackingList.Dimensions.Add(pd);
                        }
                    }

                    bookingOrders.Add(booking);
                }

                cnx.Close();

                return bookingOrders;
            }
        }

        public DeliveryBooking GetBookingOrder(int BookingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_delivery_get_booking_order_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@BookingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = BookingID;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                DataTable dtBookingAvailable = dsOrders.Tables[0];
                DataTable packingDimensions = dsOrders.Tables[1];

                DeliveryBooking booking = new DeliveryBooking();

                if (dtBookingAvailable.Rows.Count == 0)
                    return null;

                DataRow row = dtBookingAvailable.Rows[0];


                booking.IsBooking = false;

                booking.ShipmentPlanningOrder = new ShipmentPlanningOrder();

                booking.ParentOrder = new Order();
                booking.ParentOrder.Style = new Style();

                booking.BookingID = (row["BookingID"] != DBNull.Value) ? Convert.ToInt32(row["BookingID"]) : -1;
                booking.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                booking.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                booking.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                booking.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;
                booking.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                booking.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                booking.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                booking.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                booking.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                booking.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                booking.ExFactory = (row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue;
                booking.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;
                booking.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                booking.Fabric1Details = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                booking.MDA = (row["MDA"] != DBNull.Value) ? Convert.ToString(row["MDA"]) : string.Empty;
                booking.NextStatusETA = (row["NextStatusETA"] != DBNull.Value) ? Convert.ToDateTime(row["NextStatusETA"]) : DateTime.MinValue;
                booking.DC = (row["NextStatusETA"] != DBNull.Value) ? Convert.ToDateTime(row["NextStatusETA"]) : DateTime.MinValue;
                booking.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;
                booking.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;
                booking.DeliveryNoteFile = (row["DeliveryNoteFile"] != DBNull.Value) ? Convert.ToString(row["DeliveryNoteFile"]) : string.Empty;
                booking.BookingDocuments = (row["BookingDocuments"] != DBNull.Value) ? Convert.ToString(row["BookingDocuments"]) : string.Empty;
                booking.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                booking.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;

                booking.ShipmentPlanningOrder.ClientId = (row["ClientId"] != DBNull.Value) ? Convert.ToInt32(row["ClientId"]) : 0;
                booking.ShipmentPlanningOrder.Buyer = (row["CompanyName"] != DBNull.Value) ? Convert.ToString(row["CompanyName"]) : string.Empty;

                booking.ShipmentPlanningOrder.ShipmentPlanning = new ShipmentPlanning();
                booking.ShipmentPlanningOrder.ShipmentPlanning.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;
                booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                booking.ShipmentPlanningOrder.ShipmentPlanning.ExpectedDispatchDate = (row["ExpectedDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(row["ExpectedDispatchDate"]) : DateTime.MinValue;
                booking.ShipmentPlanningOrder.ShipmentPlanning.BLAWBNumber = (row["BLAWBNo"] != DBNull.Value) ? Convert.ToString(row["BLAWBNo"]) : string.Empty;

                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner = new Partner();
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner.PartnerID = (row["PartnerID"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID"]) : -1;
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner2 = new Partner();
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner2.PartnerID = (row["PartnerID2"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID2"]) : -1;
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner.PartnerName = (row["PartnerName2"] != DBNull.Value) ? Convert.ToString(row["PartnerName2"]) : string.Empty;

                booking.ShipmentPlanningOrder.PackingList = new Packing();
                booking.ShipmentPlanningOrder.PackingList.PackingID = (row["PackingListID"] != DBNull.Value) ? Convert.ToInt32(row["PackingListID"]) : -1;
                booking.ShipmentPlanningOrder.PackingList.InvoiceNumber = (row["InvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["InvoiceNumber"]) : string.Empty;
                booking.ShipmentPlanningOrder.PackingList.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty; ;
                booking.ShipmentPlanningOrder.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;


                if (booking.ShipmentPlanningOrder.PackingList.PackingID != -1)
                {
                    DataRow[] results = packingDimensions.Select("PackingID=" + booking.ShipmentPlanningOrder.PackingList.PackingID);

                    booking.ShipmentPlanningOrder.PackingList.Dimensions = new List<PackingDimension>();

                    foreach (DataRow dimRow in results)
                    {
                        PackingDimension pd = new PackingDimension();

                        pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                        pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                        pd.PackingID = booking.ShipmentPlanningOrder.PackingList.PackingID;
                        pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                        booking.ShipmentPlanningOrder.PackingList.Dimensions.Add(pd);
                    }
                }

                cnx.Close();

                return booking;
            }
        }

        public DeliveryBooking GetBookingByOrderID(int ProductionPlanningID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_delivery_get_booking_order_by_order_detail_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ProductionPlanningID;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                DataTable dtBookingAvailable = dsOrders.Tables[0];
                DataTable packingDimensions = dsOrders.Tables[1];

                DeliveryBooking booking = new DeliveryBooking();

                if (dtBookingAvailable.Rows.Count == 0)
                    return null;

                DataRow row = dtBookingAvailable.Rows[0];


                booking.IsBooking = false;

                booking.ShipmentPlanningOrder = new ShipmentPlanningOrder();

                booking.ParentOrder = new Order();
                booking.ParentOrder.Style = new Style();

                booking.BookingID = (row["BookingID"] != DBNull.Value) ? Convert.ToInt32(row["BookingID"]) : -1;
                booking.OrderDetailID = (row["OrderDetailID"] != DBNull.Value) ? Convert.ToInt32(row["OrderDetailID"]) : -1;
                booking.ProductionPlanningID = (row["ProductionPlanningID"] != DBNull.Value) ? Convert.ToInt32(row["ProductionPlanningID"]) : -1; 
                booking.ParentOrder.OrderID = (row["OrderID"] != DBNull.Value) ? Convert.ToInt32(row["OrderID"]) : -1;
                booking.ParentOrder.SerialNumber = (row["SerialNumber"] != DBNull.Value) ? Convert.ToString(row["SerialNumber"]) : string.Empty;
                booking.ParentOrder.OrderDate = (row["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(row["OrderDate"]) : DateTime.MinValue;
                booking.ParentOrder.Style.StyleID = (row["StyleID"] != DBNull.Value) ? Convert.ToInt32(row["StyleID"]) : -1;
                booking.ParentOrder.Style.StyleNumber = (row["StyleNumber"] != DBNull.Value) ? Convert.ToString(row["StyleNumber"]) : string.Empty;
                booking.ParentOrder.DepartmentName = (row["DepartmentName"] != DBNull.Value) ? Convert.ToString(row["DepartmentName"]) : string.Empty;
                booking.LineItemNumber = (row["LineItemNumber"] != DBNull.Value) ? Convert.ToString(row["LineItemNumber"]) : string.Empty;
                booking.ContractNumber = (row["ContractNumber"] != DBNull.Value) ? Convert.ToString(row["ContractNumber"]) : string.Empty;
                booking.ParentOrder.Description = (row["Description"] != DBNull.Value) ? Convert.ToString(row["Description"]) : string.Empty;
                booking.ExFactory = (row["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(row["ExFactory"]) : DateTime.MinValue;
                booking.SanjeevRemarks = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["SanjeevRemarks"]) : string.Empty;
                booking.Fabric1 = (row["Fabric1"] != DBNull.Value) ? Convert.ToString(row["Fabric1"]) : string.Empty;
                booking.Fabric1Details = (row["SanjeevRemarks"] != DBNull.Value) ? Convert.ToString(row["Fabric1Details"]) : string.Empty;
                booking.MDA = (row["MDA"] != DBNull.Value) ? Convert.ToString(row["MDA"]) : string.Empty;
                booking.NextStatusETA = (row["NextStatusETA"] != DBNull.Value) ? Convert.ToDateTime(row["NextStatusETA"]) : DateTime.MinValue;
                booking.DC = (row["NextStatusETA"] != DBNull.Value) ? Convert.ToDateTime(row["NextStatusETA"]) : DateTime.MinValue;
                booking.Quantity = (row["Quantity"] != DBNull.Value) ? Convert.ToInt32(row["Quantity"]) : 0;
                booking.ShipmentQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;
                booking.DeliveryNoteFile = (row["DeliveryNoteFile"] != DBNull.Value) ? Convert.ToString(row["DeliveryNoteFile"]) : string.Empty;
                booking.BookingDocuments = (row["BookingDocuments"] != DBNull.Value) ? Convert.ToString(row["BookingDocuments"]) : string.Empty;
                booking.Mode = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                booking.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                booking.ShipmentPlanningOrder.ClientId = (row["ClientId"] != DBNull.Value) ? Convert.ToInt32(row["ClientId"]) : 0;
                booking.ShipmentPlanningOrder.Buyer = (row["CompanyName"] != DBNull.Value) ? Convert.ToString(row["CompanyName"]) : string.Empty;

                booking.ShipmentPlanningOrder.ShipmentPlanning = new ShipmentPlanning();
                booking.ShipmentPlanningOrder.ShipmentPlanning.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;
                booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                booking.ShipmentPlanningOrder.ShipmentPlanning.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;

                booking.ShipmentPlanningOrder.ShipmentPlanning.ExpectedDispatchDate = (row["ExpectedDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(row["ExpectedDispatchDate"]) : DateTime.MinValue;
                booking.ShipmentPlanningOrder.ShipmentPlanning.BLAWBNumber = (row["BLAWBNo"] != DBNull.Value) ? Convert.ToString(row["BLAWBNo"]) : string.Empty;

                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner = new Partner();
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner.PartnerID = (row["PartnerID"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID"]) : -1;
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner2 = new Partner();
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner2.PartnerID = (row["PartnerID2"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID2"]) : -1;
                booking.ShipmentPlanningOrder.ShipmentPlanning.Partner.PartnerName = (row["PartnerName2"] != DBNull.Value) ? Convert.ToString(row["PartnerName2"]) : string.Empty;

                booking.ShipmentPlanningOrder.PackingList = new Packing();
                booking.ShipmentPlanningOrder.PackingList.PackingID = (row["PackingListID"] != DBNull.Value) ? Convert.ToInt32(row["PackingListID"]) : -1;
                booking.ShipmentPlanningOrder.PackingList.InvoiceNumber = (row["InvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["InvoiceNumber"]) : string.Empty;
                booking.ShipmentPlanningOrder.PackingList.PackageNumbers = (row["PackageNumbers"] != DBNull.Value) ? Convert.ToString(row["PackageNumbers"]) : string.Empty; ;
                booking.ShipmentPlanningOrder.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;


                if (booking.ShipmentPlanningOrder.PackingList.PackingID != -1)
                {
                    DataRow[] results = packingDimensions.Select("PackingID=" + booking.ShipmentPlanningOrder.PackingList.PackingID);

                    booking.ShipmentPlanningOrder.PackingList.Dimensions = new List<PackingDimension>();

                    foreach (DataRow dimRow in results)
                    {
                        PackingDimension pd = new PackingDimension();

                        pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                        pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                        pd.PackingID = booking.ShipmentPlanningOrder.PackingList.PackingID;
                        pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                        booking.ShipmentPlanningOrder.PackingList.Dimensions.Add(pd);
                    }
                }

                cnx.Close();

                return booking;
            }
        }

        public void AddOrderForBooking(DeliveryBooking DB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlTransaction transaction = cnx.BeginTransaction();

                try
                {
                    string cmdText = "sp_booking_add_for_booking";

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx,QueryType.Insert);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = DB.OrderDetailID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = DB.ProductionPlanningID;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }

                cnx.Close();


            }

        }

        public DataTable GetPackingOrders(int PackingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_packing_get_order_detail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@PackingID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = PackingID;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                cnx.Close();

                return dsOrders.Tables[0];


            }

        }

        public ShipmentPlanning GetShipmentPlanning(int ShipmentID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_shipment_planning_get_shipment_planning_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ShipmentID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ShipmentID;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                DataTable dtShipment = dsOrders.Tables[0];
                DataTable dtShipmentPlanning = dsOrders.Tables[1];
                DataTable packingDimensions = dsOrders.Tables[2];

                ShipmentPlanning sp = new ShipmentPlanning();

                if (dtShipment.Rows.Count > 0)
                {

                    DataRow row = dtShipment.Rows[0];

                    sp.ShipmentID = (row["Id"] != DBNull.Value) ? Convert.ToInt32(row["Id"]) : -1;
                    sp.BLAWBNumber = (row["BLAWBNo"] != DBNull.Value) ? Convert.ToString(row["BLAWBNo"]) : string.Empty;
                    sp.DCDate = (row["DCDate"] != DBNull.Value) ? Convert.ToDateTime(row["DCDate"]) : DateTime.MinValue;
                    sp.FlightSailingDetails = (row["FlightSailingDetails"] != DBNull.Value) ? Convert.ToString(row["FlightSailingDetails"]) : string.Empty;
                    sp.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;

                    sp.Partner = new Partner();
                    sp.Partner.PartnerID = (row["PartnerID"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID"]) : -1;
                    sp.Partner.PartnerName = (row["PartnerName"] != DBNull.Value) ? Convert.ToString(row["PartnerName"]) : string.Empty;

                    sp.Partner2 = new Partner();
                    sp.Partner2.PartnerID = (row["PartnerID2"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID2"]) : -1;
                    sp.Partner2.PartnerName = (row["PartnerName2"] != DBNull.Value) ? Convert.ToString(row["PartnerName2"]) : string.Empty;

                    sp.IndiaPartner = new Partner();
                    sp.IndiaPartner.PartnerID = (row["PartnerID3"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID3"]) : -1;
                    sp.IndiaPartner.PartnerName = (row["PartnerName3"] != DBNull.Value) ? Convert.ToString(row["PartnerName3"]) : string.Empty;

                    sp.SendEmail = (row["SendEmail"] != DBNull.Value) ? Convert.ToInt32(row["SendEmail"]) : -1;
                    sp.ShipmentInstructionsFile = (row["ShipmentInstructionsFile"] != DBNull.Value) ? Convert.ToString(row["ShipmentInstructionsFile"]) : string.Empty;
                    sp.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;
                    sp.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                    sp.SpecialInstructions = (row["SpecialInstructions"] != DBNull.Value) ? Convert.ToString(row["SpecialInstructions"]) : string.Empty;
                    sp.UploadDocument = (row["UploadDocument"] != DBNull.Value) ? Convert.ToString(row["UploadDocument"]) : string.Empty;
                    sp.IsShipmentAdvise = (row["IsShipmentAdvise"] != DBNull.Value) ? Convert.ToBoolean(row["IsShipmentAdvise"]) : false;


                }

                List<ShipmentPlanningOrder> shipmentOrders = new List<ShipmentPlanningOrder>();

                foreach (DataRow row in dtShipmentPlanning.Rows)
                {
                    ShipmentPlanningOrder spo = new ShipmentPlanningOrder();


                    spo.IsPartShipment = (row["IsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(row["IsPartShipment"]) : false;
                    spo.PackingList = new Packing();
                    spo.PackingList.PackingID = (row["PackingListID"] != DBNull.Value) ? Convert.ToInt32(row["PackingListID"]) : -1;
                    spo.PackingList.InvoiceNumber = (row["InvoiceNumber"] != DBNull.Value) ? Convert.ToString(row["InvoiceNumber"]) : string.Empty;
                    spo.PartShipmentRemarks = (row["PartShipmentRemarks"] != DBNull.Value) ? Convert.ToString(row["PartShipmentRemarks"]) : string.Empty;
                    spo.ShipmentPlanningOrderID = (row["ShipmentPlanningOrderID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentPlanningOrderID"]) : -1;

                    int shipmentID = (row["ShipmentID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentID"]) : -1;

                    sp.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : -1;

                    spo.ShipmentPlanning = sp;

                    if (spo.ShipmentPlanning.ShipmentPlanningOrders == null)
                        spo.ShipmentPlanning.ShipmentPlanningOrders = new List<ShipmentPlanningOrder>();

                    spo.ShipmentPlanning.ShipmentPlanningOrders.Add(spo);

                    spo.UploadBuyerList = (row["UploadBuyerList"] != DBNull.Value) ? Convert.ToString(row["UploadBuyerList"]) : string.Empty;
                    spo.UploadCustomList = (row["UploadCustomList"] != DBNull.Value) ? Convert.ToString(row["UploadCustomList"]) : string.Empty;
                    spo.UploadDocument = (row["UploadDocument"] != DBNull.Value) ? Convert.ToString(row["UploadDocument"]) : string.Empty;

                    if (spo.PackingList.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + spo.PackingList.PackingID);

                        spo.PackingList.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = spo.PackingList.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            spo.PackingList.Dimensions.Add(pd);
                        }
                    }

                    if (row["Mode"] != null)
                    {
                        spo.ModeName = Convert.ToString(row["Code"]); 

                        if (spo.ModeName != string.Empty)
                        {
                            if (spo.ModeName.ToLower().IndexOf("d") > -1)
                            {
                                spo.ShipmentTo = spo.Buyer = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                                spo.ShipmentTo += " / " + spo.ModeName;
                            }
                            else
                            {
                                spo.Buyer = "iKandi";
                                spo.ShipmentTo = "iKandi / " + spo.ModeName;
                            }
                        }
                    }

                    shipmentOrders.Add(spo);
                }

                cnx.Close();

                return sp;

            }
        }

        public DataTable GetShipmentPlanningOrders(int ShipmentID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_shipment_planning_get_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ShipmentID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = ShipmentID;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                DataTable dtShipment = dsOrders.Tables[0];

                cnx.Close();

                return dtShipment;
            }
        }

        public int SavePartShipmentOrder(PartShipmentOrder Order)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_part_shipment_order_save";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@NewID", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@D", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Order.PartShipmentOrderID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Order.OrderDetailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Qty", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = Order.PartShipmentQuantity;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return Convert.ToInt32(outParam.Value);
            }
        }

        public DataSet GetOrderDetailByShipmentId(int shipmentId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_order_detail_get_order_detail_by_shipment_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ShipmentId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = shipmentId;
                cmd.Parameters.Add(param);

                DataSet dsOrderDetail = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrderDetail);

                return dsOrderDetail;
            }
        }

        public DataTable GetShipmentIdsForTodaysLandingETA()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "get_shipment_ids_for_todays_landingeta";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
               
                DataTable dtShipmentIds = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtShipmentIds);

                return dtShipmentIds;
            }
        }

        public void RemoveOrderFromPlannedOrders(int productionPlanningId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_production_planning_remove_order_from_planned_orders";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ProductionPlanningId", SqlDbType.Int);
                param.Value = productionPlanningId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
        }

        public void RemoveOrderFromBookingView(int bookingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_booking_remove_order_from_booking_view";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@BookingId", SqlDbType.Int);
                param.Value = bookingId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
        }

        #region Packing Methods


        public Packing GetPackingCollection(int orderId, int packingId, int productionUnitManagerId)
        {
            Packing objPacking = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                
                    string cmdText = "sp_packing_get_packing_list";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = orderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackingId", SqlDbType.Int);
                    param.Value = packingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionUnitManagerId", SqlDbType.Int);
                    param.Value = productionUnitManagerId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsPacking = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsPacking);

                    objPacking = ConvertDataSetToPackingCollection(dsPacking);
                    objPacking.OrderID = orderId;
                    objPacking.PackingID = packingId;
              
            }

            return objPacking;

        }

        private Packing ConvertDataSetToPackingCollection(DataSet dsPacking)
        {
            Packing objPacking = new Packing();

            if (dsPacking.Tables.Count == 2)
            {
                objPacking.Distributions = new List<PackingDistribution>();

                foreach (DataRow drPacking in dsPacking.Tables[0].Rows)
                {
                    PackingDistribution objPackingDistribution = new PackingDistribution();
                    objPackingDistribution.OrderDetailID = (drPacking["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["OrderDetailId"]);
                    objPackingDistribution.LineItemNumber = (drPacking["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["LineItemNumber"]);
                    objPackingDistribution.StyleNumber = (drPacking["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["StyleNumber"]);
                    objPackingDistribution.FabricColor = (drPacking["FabricColor"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FabricColor"]);
                    objPackingDistribution.Item = (drPacking["Item"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Item"]);
                    objPackingDistribution.Fabric = (drPacking["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Fabric"]);
                    objPackingDistribution.Quantity = (drPacking["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["Quantity"]);
                    objPackingDistribution.ShippingQuantity = (drPacking["ShippingQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["ShippingQuantity"]);
                    objPackingDistribution.Mode = (drPacking["Mode"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["Mode"]);

                    //For showing proportional data for part shipment
                    double quantityRatio = (double)objPackingDistribution.ShippingQuantity / (double)objPackingDistribution.Quantity;

                    objPackingDistribution.PackingSizes = new List<OrderDetailSizes>();

                    foreach (DataRow drSizes in dsPacking.Tables[1].Rows)
                    {
                        if (objPackingDistribution.OrderDetailID == (drSizes["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(drSizes["OrderDetailId"])))
                        {
                            OrderDetailSizes objOrderDetailSizes = new OrderDetailSizes();
                            objOrderDetailSizes.OrderDetailID = (drSizes["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailId"]);
                            objOrderDetailSizes.OrderDetailSizeID = (drSizes["OrderDetailSizeId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailSizeId"]);
                            objOrderDetailSizes.Size = (drSizes["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(drSizes["Size"]);
                            objOrderDetailSizes.Quantity = (drSizes["Quantity"] == DBNull.Value) ? 0 : (int)(quantityRatio * Convert.ToInt32(drSizes["Quantity"]));
                            objOrderDetailSizes.Singles = (drSizes["Singles"] == DBNull.Value) ? 0 : (int)(quantityRatio * Convert.ToInt32(drSizes["Singles"]));
                            objOrderDetailSizes.Ratio = (drSizes["Ratio"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Ratio"]);
                            objOrderDetailSizes.RatioPack = (drSizes["RatioPack"] == DBNull.Value) ? 0 : (int)(quantityRatio * Convert.ToInt32(drSizes["RatioPack"]));

                            objPackingDistribution.PackingSizes.Add(objOrderDetailSizes);
                        }
                    }

                    objPacking.Distributions.Add(objPackingDistribution);
                }
            }
            else if (dsPacking.Tables.Count == 4)
            {
                if (dsPacking.Tables[0].Rows.Count == 1)
                {
                    DataRow drPacking = dsPacking.Tables[0].Rows[0];

                    objPacking.BuyerOrderNumber = (drPacking["BuyerOrderNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["BuyerOrderNumber"]);
                    objPacking.BuyerOrderDate = (drPacking["BuyerOrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(drPacking["BuyerOrderDate"]);
                    objPacking.BuyerOtherThanConsignee = (drPacking["BuyerOtherThanConsignee"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["BuyerOtherThanConsignee"]);
                    objPacking.Consignee = (drPacking["Consignee"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Consignee"]);
                    objPacking.CountryOfFinalDestination = (drPacking["CountryOfFinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["CountryOfFinalDestination"]);
                    objPacking.CountryOfOriginOfGoods = (drPacking["CountryOfOriginOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["CountryOfOriginOfGoods"]);
                    objPacking.DescriptionOfGoods = (drPacking["DescriptionOfGoods"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["DescriptionOfGoods"]);
                    objPacking.Exporter = (drPacking["Exporter"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Exporter"]);
                    objPacking.FinalDestination = (drPacking["FinalDestination"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FinalDestination"]);
                    objPacking.FlightNumber = (drPacking["FlightNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["FlightNumber"]);
                    objPacking.InvoiceDate = (drPacking["InvoiceDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(drPacking["InvoiceDate"]);
                    objPacking.InvoiceNumber = (drPacking["InvoiceNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["InvoiceNumber"]);
                    objPacking.MarksAndContainerNumber = (drPacking["MarksAndContainerNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["MarksAndContainerNumber"]);
                    objPacking.NumberAndKindOfPackages = (drPacking["NumberAndKindOfPackages"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["NumberAndKindOfPackages"]);
                    objPacking.OtherReferences = (drPacking["OtherReferences"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["OtherReferences"]);
                    objPacking.PackageNumbers = (drPacking["PackageNumbers"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PackageNumbers"]);
                    objPacking.PackingID = (drPacking["id"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["id"]);
                    objPacking.PlaceOfReceiptByPreCarrier = (drPacking["PlaceOfReceiptByPreCarrier"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PlaceOfReceiptByPreCarrier"]);
                    objPacking.PortOfDischarge = (drPacking["PortOfDischarge"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PortOfDischarge"]);
                    objPacking.PortOfLoading = (drPacking["PortOfLoading"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PortOfLoading"]);
                    objPacking.PreCarriageBy = (drPacking["PreCarriageBy"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["PreCarriageBy"]);
                    objPacking.Remarks = (drPacking["Remarks"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["Remarks"]);
                    objPacking.TermsOfDeliveryAndPayment = (drPacking["TermsOfDeliveryAndPayment"] == DBNull.Value) ? string.Empty : Convert.ToString(drPacking["TermsOfDeliveryAndPayment"]);
                    objPacking.TotalGrossWeight = (drPacking["TotalGrossWeight"] == DBNull.Value) ? 0 : Convert.ToDouble(drPacking["TotalGrossWeight"]);
                    objPacking.TotalNetWeight = (drPacking["TotalNetWeight"] == DBNull.Value) ? 0 : Convert.ToDouble(drPacking["TotalNetWeight"]);
                    objPacking.TotalPackages = (drPacking["TotalPackages"] == DBNull.Value) ? 0 : Convert.ToInt32(drPacking["TotalPackages"]);

                    objPacking.Distributions = new List<PackingDistribution>();

                    foreach (DataRow drPackingDistribution in dsPacking.Tables[1].Rows)
                    {
                        PackingDistribution objPackingDistribution = new PackingDistribution();

                        objPackingDistribution.OrderDetailID = (drPackingDistribution["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["OrderDetailId"]);
                        objPackingDistribution.LineItemNumber = (drPackingDistribution["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["LineItemNumber"]);
                        objPackingDistribution.StyleNumber = (drPackingDistribution["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["StyleNumber"]);
                        objPackingDistribution.FabricColor = (drPackingDistribution["FabricColor"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["FabricColor"]);
                        objPackingDistribution.Item = (drPackingDistribution["Item"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["Item"]);
                        objPackingDistribution.Fabric = (drPackingDistribution["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(drPackingDistribution["Fabric"]);
                        objPackingDistribution.Quantity = (drPackingDistribution["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["Quantity"]);

                        objPackingDistribution.PkgNoFrom = (drPackingDistribution["PkgNoFrom"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["PkgNoFrom"]);
                        objPackingDistribution.PkgNoTo = (drPackingDistribution["PkgNoTo"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["PkgNoTo"]);
                        objPackingDistribution.IsRatioPack = (drPackingDistribution["IsRatioPack"] == DBNull.Value) ? false : Convert.ToBoolean(drPackingDistribution["IsRatioPack"]);
                        objPackingDistribution.RatioPackQtyPerPkg = (drPackingDistribution["RatioPackQtyPerPkg"] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["RatioPackQtyPerPkg"]);

                        objPackingDistribution.Sizes = new int[16];

                        for (int i = 1; i <= 16; i++)
                        {
                            objPackingDistribution.Sizes[i - 1] = (drPackingDistribution["Size" + i.ToString()] == DBNull.Value) ? 0 : Convert.ToInt32(drPackingDistribution["Size" + i.ToString()]);
                        }

                        objPackingDistribution.PackingSizes = new List<OrderDetailSizes>();

                        foreach (DataRow drSizes in dsPacking.Tables[2].Rows)
                        {
                            if (objPackingDistribution.OrderDetailID == (drSizes["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt32(drSizes["OrderDetailId"])))
                            {
                                OrderDetailSizes objOrderDetailSizes = new OrderDetailSizes();
                                objOrderDetailSizes.OrderDetailID = (drSizes["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailId"]);
                                objOrderDetailSizes.OrderDetailSizeID = (drSizes["OrderDetailSizeId"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["OrderDetailSizeId"]);
                                objOrderDetailSizes.Size = (drSizes["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(drSizes["Size"]);
                                objOrderDetailSizes.Quantity = (drSizes["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Quantity"]);
                                objOrderDetailSizes.Singles = (drSizes["Singles"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Singles"]);
                                objOrderDetailSizes.Ratio = (drSizes["Ratio"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["Ratio"]);
                                objOrderDetailSizes.RatioPack = (drSizes["RatioPack"] == DBNull.Value) ? 0 : Convert.ToInt32(drSizes["RatioPack"]);

                                objPackingDistribution.PackingSizes.Add(objOrderDetailSizes);
                            }
                        }

                        objPacking.Distributions.Add(objPackingDistribution);
                    }

                    objPacking.Dimensions = new List<PackingDimension>();

                    foreach (DataRow drDimension in dsPacking.Tables[3].Rows)
                    {
                        PackingDimension objPackingDimension = new PackingDimension();

                        objPackingDimension.PackingDimensionID = (drDimension["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(drDimension["Id"]);
                        objPackingDimension.PackingID = (drDimension["PackingID"] == DBNull.Value) ? 0 : Convert.ToInt32(drDimension["PackingID"]);
                        objPackingDimension.Dimension = (drDimension["Dimension"] == DBNull.Value) ? string.Empty : Convert.ToString(drDimension["Dimension"]);
                        objPackingDimension.Quantity = (drDimension["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(drDimension["Quantity"]);

                        objPacking.Dimensions.Add(objPackingDimension);
                    }
                }
            }

            return objPacking;
        }

        public bool SavePacking(Packing objPacking)
        {

            if (objPacking.PackingID == -1)
            {
                return InsertPacking(objPacking);
            }
            else
            {
                return UpdatePacking(objPacking);
            }
        }

        private bool InsertPacking(Packing objPacking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_packing_insert_packing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@PackingId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@Exporter", SqlDbType.Text);
                    param.Value = objPacking.Exporter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceNumber", SqlDbType.VarChar);
                    param.Value = objPacking.InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderNumber", SqlDbType.VarChar);
                    param.Value = objPacking.BuyerOrderNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderDate", SqlDbType.Date);
                    param.Value = objPacking.BuyerOrderDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherReferences", SqlDbType.VarChar);
                    param.Value = objPacking.OtherReferences;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Consignee", SqlDbType.Text);
                    param.Value = objPacking.Consignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOtherThanConsignee", SqlDbType.Text);
                    param.Value = objPacking.BuyerOtherThanConsignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfOriginOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfOriginOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfFinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfFinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreCarriageBy", SqlDbType.VarChar);
                    param.Value = objPacking.PreCarriageBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PlaceOfReceiptByPreCarrier", SqlDbType.VarChar);
                    param.Value = objPacking.PlaceOfReceiptByPreCarrier;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightNumber", SqlDbType.VarChar);
                    param.Value = objPacking.FlightNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfLoading", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfLoading;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfDischarge", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfDischarge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.FinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarksAndContainerNumber", SqlDbType.VarChar);
                    param.Value = objPacking.MarksAndContainerNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NumberAndKindOfPackages", SqlDbType.VarChar);
                    param.Value = objPacking.NumberAndKindOfPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DescriptionOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.DescriptionOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = objPacking.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalGrossWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalGrossWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalNetWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalNetWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalPackages", SqlDbType.Int);
                    param.Value = objPacking.TotalPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackageNumbers", SqlDbType.VarChar);
                    param.Value = objPacking.PackageNumbers;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
                    param.Value = objPacking.InvoiceDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TermsOfDeliveryAndPayment", SqlDbType.VarChar);
                    param.Value = objPacking.TermsOfDeliveryAndPayment;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    objPacking.PackingID = Convert.ToInt32(outParam.Value);

                    if (objPacking.PackingID <= 0)
                        return false;

                    foreach (PackingOrders objPackingOrders in objPacking.PackingOrdersCollection)
                    {
                        objPackingOrders.PackingID = objPacking.PackingID;
                        SavePackingOrderDetails(objPackingOrders, cnx, transaction);
                    }

                    foreach (PackingDistribution objPackingDistribution in objPacking.Distributions)
                    {
                        objPackingDistribution.PackingID = objPacking.PackingID;
                        InsertPackingDistribution(objPackingDistribution, cnx, transaction);
                    }

                    foreach (PackingDimension objPackingDimension in objPacking.Dimensions)
                    {
                        objPackingDimension.PackingID = objPacking.PackingID;
                        InsertPackingDimension(objPackingDimension, cnx, transaction);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }
        }

        private bool UpdatePacking(Packing objPacking)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_packing_update_packing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@PackingId", SqlDbType.Int);
                    param.Value = objPacking.PackingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Exporter", SqlDbType.Text);
                    param.Value = objPacking.Exporter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceNumber", SqlDbType.VarChar);
                    param.Value = objPacking.InvoiceNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderNumber", SqlDbType.VarChar);
                    param.Value = objPacking.BuyerOrderNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOrderDate", SqlDbType.Date);
                    param.Value = objPacking.BuyerOrderDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OtherReferences", SqlDbType.VarChar);
                    param.Value = objPacking.OtherReferences;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Consignee", SqlDbType.Text);
                    param.Value = objPacking.Consignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyerOtherThanConsignee", SqlDbType.Text);
                    param.Value = objPacking.BuyerOtherThanConsignee;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfOriginOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfOriginOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryOfFinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.CountryOfFinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreCarriageBy", SqlDbType.VarChar);
                    param.Value = objPacking.PreCarriageBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PlaceOfReceiptByPreCarrier", SqlDbType.VarChar);
                    param.Value = objPacking.PlaceOfReceiptByPreCarrier;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlightNumber", SqlDbType.VarChar);
                    param.Value = objPacking.FlightNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfLoading", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfLoading;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PortOfDischarge", SqlDbType.VarChar);
                    param.Value = objPacking.PortOfDischarge;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDestination", SqlDbType.VarChar);
                    param.Value = objPacking.FinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarksAndContainerNumber", SqlDbType.VarChar);
                    param.Value = objPacking.MarksAndContainerNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NumberAndKindOfPackages", SqlDbType.VarChar);
                    param.Value = objPacking.NumberAndKindOfPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DescriptionOfGoods", SqlDbType.VarChar);
                    param.Value = objPacking.DescriptionOfGoods;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = objPacking.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalGrossWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalGrossWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalNetWeight", SqlDbType.Float);
                    param.Value = objPacking.TotalNetWeight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalPackages", SqlDbType.Int);
                    param.Value = objPacking.TotalPackages;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackageNumbers", SqlDbType.VarChar);
                    param.Value = objPacking.PackageNumbers;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nvoiceDate", SqlDbType.DateTime);
                    param.Value = objPacking.InvoiceDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TermsOfDeliveryAndPayment", SqlDbType.VarChar);
                    param.Value = objPacking.TermsOfDeliveryAndPayment;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    foreach (PackingOrders objPackingOrders in objPacking.PackingOrdersCollection)
                    {
                        objPackingOrders.PackingID = objPacking.PackingID;
                        SavePackingOrderDetails(objPackingOrders, cnx, transaction);
                    }

                    DeletePackingDistribution(objPacking.PackingID, cnx, transaction);
                    DeletePackingDimension(objPacking.PackingID, cnx, transaction);

                    foreach (PackingDistribution objPackingDistribution in objPacking.Distributions)
                    {
                        objPackingDistribution.PackingID = objPacking.PackingID;
                        InsertPackingDistribution(objPackingDistribution, cnx, transaction);
                    }

                    foreach (PackingDimension objPackingDimension in objPacking.Dimensions)
                    {
                        objPackingDimension.PackingID = objPacking.PackingID;
                        InsertPackingDimension(objPackingDimension, cnx, transaction);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        private bool SavePackingOrderDetails(PackingOrders objPackingOrder, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_order_save_packing_order";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            param.Value = objPackingOrder.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
            param.Value = objPackingOrder.OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalPackages", SqlDbType.Int);
            param.Value = objPackingOrder.TotalPackages;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PackageNumbers", SqlDbType.VarChar);
            param.Value = objPackingOrder.PackageNumbers;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.VarChar);
            param.Value = objPackingOrder.ProductionPlanningId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool DeletePackingDistribution(int packingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_order_distribution_delete_distribution";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param = new SqlParameter("@PackingId", SqlDbType.Int);
            param.Value = packingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool DeletePackingDimension(int packingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_box_dimension_delete_dimension";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param = new SqlParameter("@PackingId", SqlDbType.Int);
            param.Value = packingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool InsertPackingDistribution(PackingDistribution objPackingDistribution, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_order_distribution_insert_distribution";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@PackingDistributionId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            param.Value = objPackingDistribution.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
            param.Value = objPackingDistribution.OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProductionPlanningID", SqlDbType.Int);
            param.Value = objPackingDistribution.ProductionPlanningID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PkgNoFrom", SqlDbType.Int);
            param.Value = objPackingDistribution.PkgNoFrom;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PkgNoTo", SqlDbType.Int);
            param.Value = objPackingDistribution.PkgNoTo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric", SqlDbType.VarChar);
            param.Value = objPackingDistribution.Fabric;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalPackingQty", SqlDbType.Int);
            param.Value = objPackingDistribution.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sRatioPack", SqlDbType.Bit);
            param.Value = objPackingDistribution.IsRatioPack;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@RatioPackQtyPerPkg", SqlDbType.Int);
            param.Value = objPackingDistribution.RatioPackQtyPerPkg;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            for (int i = 1; i <= objPackingDistribution.PackingSizes.Count; i++)
            {
                param = new SqlParameter("@Size" + i.ToString(), SqlDbType.Int);
                param.Value = objPackingDistribution.PackingSizes[i - 1].Quantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
            }

            for (int i = objPackingDistribution.PackingSizes.Count + 1; i <= 16; i++)
            {
                param = new SqlParameter("@Size" + i.ToString(), SqlDbType.Int);
                param.Value = 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery();

            int packingDistributionId = Convert.ToInt32(outParam.Value);

            return true;
        }

        private bool InsertPackingDimension(PackingDimension objPackingDimension, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_packing_box_dimension_insert_dimension";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@PackingBoxDimensionID", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@PackingID", SqlDbType.Int);
            param.Value = objPackingDimension.PackingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Dimension", SqlDbType.VarChar);
            param.Value = objPackingDimension.Dimension;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int);
            param.Value = objPackingDimension.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int packingBoxDimensionId = Convert.ToInt32(outParam.Value);

            return true;
        }

        #endregion

        public void UpdateShipmentEmailInfo(int ShipmentID, int ShipmentEmailType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_shipment_email_info";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ShipmentID", SqlDbType.Int);
                param.Value = ShipmentID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                 param = new SqlParameter("@ShipmentEmailType", SqlDbType.Int);
                param.Value = ShipmentEmailType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
        }

        public void UpdateBookingEmailInfo(int BookingID, bool IsEmailSent)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_booking_update_email_info";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@BookingID", SqlDbType.Int);
                param.Value = BookingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sEmailSent", SqlDbType.Bit);
                param.Value = IsEmailSent;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
        }

        public int GetIsOrderExfactoried(int OrderDetailID)
        {
            int isOrderExfactoried = 0;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_shipment_planning_get_is_order_exfactoried";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object ObjIsOrderExfactoried = cmd.ExecuteScalar();

                if (null != ObjIsOrderExfactoried)
                    isOrderExfactoried = Convert.ToInt32(ObjIsOrderExfactoried);
            }
            return isOrderExfactoried;
        }

        public int GetIsOrderDelivered(int OrderDetailID)
        {
            int isOrderDelivered = 0;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_shipment_planning_get_is_order_delivered";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object ObjIsOrderDelivered = cmd.ExecuteScalar();

                if (null != ObjIsOrderDelivered)
                    isOrderDelivered = Convert.ToInt32(ObjIsOrderDelivered);
            }
            return isOrderDelivered;
        }




        public List<ShipmentPlanning> GetShipmentPlannedOrdersPlanningDAL(string SearchText)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_shipment_planning_get_shipment_planned_orders_Planning";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsOrders = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsOrders);

                List<ShipmentPlanning> shipmentPlanning = new List<ShipmentPlanning>();

                DataTable dtShipment = dsOrders.Tables[0];
                DataTable dtShipmentPlanning = dsOrders.Tables[1];
                DataTable packingDimensions = dsOrders.Tables[2];

                foreach (DataRow row in dtShipment.Rows)
                {
                    ShipmentPlanning sp = new ShipmentPlanning();

                    sp.ShipmentID = (row["Id"] != DBNull.Value) ? Convert.ToInt32(row["Id"]) : -1;
                    sp.BLAWBNumber = (row["BLAWBNo"] != DBNull.Value) ? Convert.ToString(row["BLAWBNo"]) : string.Empty;
                    sp.ExpectedDispatchDate = (row["ExpectedDispatchDate"] != DBNull.Value) ? Convert.ToDateTime(row["ExpectedDispatchDate"]) : DateTime.MinValue;
                    sp.DCDate = (row["DCDate"] != DBNull.Value) ? Convert.ToDateTime(row["DCDate"]) : DateTime.MinValue;
                    sp.FlightSailingDetails = (row["FlightSailingDetails"] != DBNull.Value) ? Convert.ToString(row["FlightSailingDetails"]) : string.Empty;
                    sp.FlightDate = (row["FlightDate"] != DBNull.Value) ? Convert.ToDateTime(row["FlightDate"]) : DateTime.MinValue;
                    sp.LandingETA = (row["LandingETA"] != DBNull.Value) ? Convert.ToDateTime(row["LandingETA"]) : DateTime.MinValue;

                    sp.Partner = new Partner();
                    sp.Partner.PartnerID = (row["PartnerID"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID"]) : -1;
                    sp.Partner.PartnerName = (row["PartnerName"] != DBNull.Value) ? Convert.ToString(row["PartnerName"]) : string.Empty;

                    sp.Partner2 = new Partner();
                    sp.Partner2.PartnerID = (row["PartnerID2"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID2"]) : -1;
                    sp.Partner2.PartnerName = (row["PartnerName2"] != DBNull.Value) ? Convert.ToString(row["PartnerName2"]) : string.Empty;

                    sp.IndiaPartner = new Partner();
                    sp.IndiaPartner.PartnerID = (row["PartnerID3"] != DBNull.Value) ? Convert.ToInt32(row["PartnerID3"]) : -1;
                    sp.IndiaPartner.PartnerName = (row["PartnerName3"] != DBNull.Value) ? Convert.ToString(row["PartnerName3"]) : string.Empty;

                    sp.SendEmail = (row["SendEmail"] != DBNull.Value) ? Convert.ToInt32(row["SendEmail"]) : -1;
                    sp.ShipmentInstructionsFile = (row["ShipmentInstructionsFile"] != DBNull.Value) ? Convert.ToString(row["ShipmentInstructionsFile"]) : string.Empty;
                    sp.ShipmentNumber = (row["ShipmentNo"] != DBNull.Value) ? Convert.ToString(row["ShipmentNo"]) : string.Empty;
                    sp.ShipmentSentForwarder = (row["ShipmentSentForwarder"] != DBNull.Value) ? Convert.ToDateTime(row["ShipmentSentForwarder"]) : DateTime.MinValue;
                    sp.SpecialInstructions = (row["SpecialInstructions"] != DBNull.Value) ? Convert.ToString(row["SpecialInstructions"]) : string.Empty;
                    sp.UploadDocument = (row["UploadDocument"] != DBNull.Value) ? Convert.ToString(row["UploadDocument"]) : string.Empty;
                    sp.IsShipmentAdvise = (row["IsShipmentAdvise"] != DBNull.Value) ? Convert.ToBoolean(row["IsShipmentAdvise"]) : false;

                    shipmentPlanning.Add(sp);
                }

                List<ShipmentPlanningOrder> shipmentOrders = new List<ShipmentPlanningOrder>();

                foreach (DataRow row in dtShipmentPlanning.Rows)
                {
                    ShipmentPlanningOrder spo = new ShipmentPlanningOrder();

                    int shipQty = (row["ShippingQty"] != DBNull.Value) ? Convert.ToInt32(row["ShippingQty"]) : 0;
                    int poQty = (row["POQty"] != DBNull.Value) ? Convert.ToInt32(row["POQty"]) : 0;

                    spo.IsPartShipment = (row["POIsPartShipment"] != DBNull.Value) ? Convert.ToBoolean(row["POIsPartShipment"]) : (shipQty != poQty);
                    spo.PackingList = new Packing();
                    spo.PackingList.PackingID = (row["PackingListID"] != DBNull.Value) ? Convert.ToInt32(row["PackingListID"]) : -1;
                    spo.PackingList.InvoiceID = (row["InvoiceID"] != DBNull.Value) ? Convert.ToInt32(row["InvoiceID"]) : -1;
                    spo.PackingList.InvoiceNumber = (row["BIPLInvoiceNumber2"] != DBNull.Value) ? Convert.ToString(row["BIPLInvoiceNumber2"]) : string.Empty;
                    spo.PackingList.TotalPackages = (row["TotalPackages"] != DBNull.Value) ? Convert.ToInt32(row["TotalPackages"]) : 0;
                    spo.PartShipmentRemarks = (row["ReasonForShortShipping"] != DBNull.Value) ? Convert.ToString(row["ReasonForShortShipping"]) : string.Empty;
                    spo.ShipmentPlanningOrderID = (row["ShipmentPlanningOrderID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentPlanningOrderID"]) : -1;
                    spo.ModeId = (row["Mode"] != DBNull.Value) ? Convert.ToInt32(row["Mode"]) : -1;
                    spo.ModeName = (row["Code"] != DBNull.Value) ? Convert.ToString(row["Code"]) : string.Empty;
                    spo.ClientId = (row["ClientId"] != DBNull.Value) ? Convert.ToInt32(row["ClientId"]) : -1;
                    spo.PlannedEx = (row["PlannedEx"] != DBNull.Value) ? Convert.ToDateTime(row["PlannedEx"]) : DateTime.MinValue;
                    spo.ProductionPlanningId = row["ProductionPlanningId"] != DBNull.Value ? Convert.ToInt32(row["ProductionPlanningId"]) : -1;

                    int shipmentID = (row["ShipmentID"] != DBNull.Value) ? Convert.ToInt32(row["ShipmentID"]) : -1;

                    ShipmentPlanning sp = shipmentPlanning.Find(delegate(ShipmentPlanning splanning)
                    {
                        return splanning.ShipmentID == shipmentID;
                    });

                    if (sp != null)
                    {
                        spo.ShipmentPlanning = sp;

                        if (spo.ShipmentPlanning.ShipmentPlanningOrders == null)
                            spo.ShipmentPlanning.ShipmentPlanningOrders = new List<ShipmentPlanningOrder>();

                        spo.ShipmentPlanning.ShipmentPlanningOrders.Add(spo);
                        sp.TotalPackages += spo.PackingList.TotalPackages;
                    }
                    else
                    {
                        spo.ShipmentPlanning = new ShipmentPlanning();
                        spo.ShipmentPlanning.ShipmentID = shipmentID;

                        if (spo.ShipmentPlanning.ShipmentPlanningOrders == null)
                            spo.ShipmentPlanning.ShipmentPlanningOrders = new List<ShipmentPlanningOrder>();

                        spo.ShipmentPlanning.ShipmentPlanningOrders.Add(spo);

                        shipmentPlanning.Add(spo.ShipmentPlanning);
                    }




                    spo.QAStatus = (row["QAStatus"] != DBNull.Value) ? ((Convert.ToInt32(row["QAStatus"]) == 1) ? "PASS" : (Convert.ToInt32(row["QAStatus"]) == 2) ? "FAIL" : string.Empty) : string.Empty;
                    spo.Status = (row["Status"] != DBNull.Value) ? Convert.ToString(row["Status"]) : string.Empty;
                    spo.StatusModeId = (row["StatusModeId"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeId"]) : 0;
                    spo.StatusModeSequence = (row["StatusModeSequence"] != DBNull.Value) ? Convert.ToInt32(row["StatusModeSequence"]) : 0;

                    spo.UploadBuyerList = (row["UploadBuyerList"] != DBNull.Value) ? Convert.ToString(row["UploadBuyerList"]) : string.Empty;
                    spo.UploadCustomList = (row["UploadCustomList"] != DBNull.Value) ? Convert.ToString(row["UploadCustomList"]) : string.Empty;
                    spo.UploadDocument = (row["UploadDocument"] != DBNull.Value) ? Convert.ToString(row["UploadDocument"]) : string.Empty;

                    if (spo.PackingList.PackingID != -1)
                    {
                        DataRow[] results = packingDimensions.Select("PackingID=" + spo.PackingList.PackingID);

                        spo.PackingList.Dimensions = new List<PackingDimension>();

                        foreach (DataRow dimRow in results)
                        {
                            PackingDimension pd = new PackingDimension();

                            pd.Dimension = (dimRow["Dimension"] != DBNull.Value) ? Convert.ToString(dimRow["Dimension"]) : string.Empty;
                            pd.Quantity = (dimRow["Quantity"] != DBNull.Value) ? Convert.ToInt32(dimRow["Quantity"]) : 0;
                            pd.PackingID = spo.PackingList.PackingID;
                            pd.PackingDimensionID = (dimRow["Id"] != DBNull.Value) ? Convert.ToInt32(dimRow["Id"]) : 0;

                            spo.PackingList.Dimensions.Add(pd);
                        }
                    }

                    if (row["Mode"] != null)
                    {
                        string modeName = string.Empty;

                        modeName = Convert.ToString(row["Code"]);

                        if (modeName != string.Empty)
                        {
                            if (modeName.ToLower().IndexOf("d") > -1)
                            {
                                spo.ShipmentTo = (row["Buyer"] != DBNull.Value) ? Convert.ToString(row["Buyer"]) : string.Empty;
                                spo.ShipmentTo += " / " + modeName;
                            }
                            else
                            {
                                spo.ShipmentTo = "iKandi / " + modeName;
                            }
                        }
                    }

                    spo.Unit = new ProductionUnit();
                    spo.Unit.FactoryCode = (row["ProductionUnitCode"] != DBNull.Value) ? Convert.ToString(row["ProductionUnitCode"]) : string.Empty;
                    spo.Unit.FactoryName = (row["ProductionUnitName"] != DBNull.Value) ? Convert.ToString(row["ProductionUnitName"]) : string.Empty;

                    shipmentOrders.Add(spo);
                }

                cnx.Close();

                return shipmentPlanning;

            }
        }
    }
}

