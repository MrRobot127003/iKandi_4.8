using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;

namespace iKandi.DAL
{
    public class CostingDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public CostingDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insertion Methods

        public int InsertCosting(Costing objCosting, int Role)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_costing_insert_costing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    //SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@CostingId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = objCosting.ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    param.Value = objCosting.DepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDepartmentID", SqlDbType.Int);
                    param.Value = objCosting.ParentDepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = objCosting.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBestSeller", SqlDbType.Bit);
                    param.Value = objCosting.IsBestSeller;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = objCosting.Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Weight", SqlDbType.Decimal);
                    param.Value = objCosting.Weight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentCostingId", SqlDbType.Int);
                    param.Value = objCosting.ParentCostingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PrintIds", SqlDbType.VarChar);
                    param.Value = objCosting.PrintIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreedPrice", SqlDbType.Float);
                    param.Value = objCosting.AgreedPrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceQuoted", SqlDbType.Float);
                    param.Value = objCosting.PriceQuoted;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrieghtUptoFinalDestination", SqlDbType.Float);
                    param.Value = objCosting.FrieghtUptoFinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrieghtUptoPort", SqlDbType.Float);
                    param.Value = objCosting.FrieghtUptoPort;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FincCost", SqlDbType.Float);
                    param.Value = objCosting.FincCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DirectCost", SqlDbType.Float);
                    param.Value = objCosting.DirectCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConvertTo", SqlDbType.Int);
                    param.Value = objCosting.ConvertTo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarkupOnUnitCTC", SqlDbType.Float);
                    param.Value = objCosting.MarkupOnUnitCTC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CommisionPercent", SqlDbType.Float);
                    param.Value = objCosting.CommisionPercent;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConversionRate", SqlDbType.Float);
                    param.Value = objCosting.ConversionRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //manisha 12th may 2011
                    param = new SqlParameter("@OverHead", SqlDbType.Float);
                    param.Value = objCosting.OverHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //Added By Ashish on 26/2/2014
                    param = new SqlParameter("@DesignCommission", SqlDbType.Float);
                    param.Value = objCosting.DesignCommission;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //END

                    //manisha 13th may 2011
                    param = new SqlParameter("@MakingType", SqlDbType.VarChar);
                    param.Value = objCosting.MakingType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@ExpectedQty", SqlDbType.Int);
                    param.Value = objCosting.ExpectedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //

                    param = new SqlParameter("@OverallComments", SqlDbType.VarChar);
                    param.Value = objCosting.OverallComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = objCosting.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPlChangesHistory", SqlDbType.VarChar);
                    param.Value = objCosting.BIPlChangesHistory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@KandiChangesHistory", SqlDbType.VarChar);
                    param.Value = objCosting.iKandiChangesHistory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FileName", SqlDbType.VarChar);
                    param.Value = objCosting.FileName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@OB_WS", SqlDbType.Int);
                    param.Value = objCosting.OB_WS;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Achievement", SqlDbType.Int);
                    param.Value = objCosting.Achivement;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    objCosting.CostingID = Convert.ToInt32(outParam.Value);

                    if (objCosting.CostingID == -1)
                        return objCosting.CostingID;

                    SaveCosting(objCosting, cnx, transaction, false, Role);

                    transaction.Commit();
                    return objCosting.CostingID;
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
            }

            return -1;
        }

        private bool InsertFabricCosting(FabricCosting objFabricCosting, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fabric_costing_insert_fabric_costing";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@FabricCostingId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@FabricType", SqlDbType.VarChar);
            param.Value = objFabricCosting.FabricType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric", SqlDbType.VarChar);
            param.Value = objFabricCosting.Fabric;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PrintType", SqlDbType.VarChar);
            param.Value = objFabricCosting.PrintType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Width", SqlDbType.Float);
            param.Value = objFabricCosting.Width;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Average", SqlDbType.Float);
            param.Value = objFabricCosting.Average;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objFabricCosting.Rate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Float);
            param.Value = objFabricCosting.Amount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Waste", SqlDbType.VarChar);
            param.Value = objFabricCosting.Waste;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objFabricCosting.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objFabricCosting.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sAir", SqlDbType.Bit);
            param.Value = objFabricCosting.IsAir;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Layfilepath", SqlDbType.VarChar, 500);
            param.Value = objFabricCosting.LayFileName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int fabricCostingID = Convert.ToInt32(outParam.Value);

            return true;
        }

        public int UpdateFabQuality(string[] tradeName, string[] count, double[] gsm)
        {
            SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING);
            string cmdText = "sp_style_update_fabQuality";
            cnx.Open();
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param;

            param = new SqlParameter("@TradeName1", SqlDbType.VarChar);
            param.Value = tradeName[0].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TradeName2", SqlDbType.VarChar);
            param.Value = tradeName[1].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TradeName3", SqlDbType.VarChar);
            param.Value = tradeName[2].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TradeName4", SqlDbType.VarChar);
            param.Value = tradeName[3].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountConstruction1", SqlDbType.VarChar);
            param.Value = count[0].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountConstruction2", SqlDbType.VarChar);
            param.Value = count[1].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountConstruction3", SqlDbType.VarChar);
            param.Value = count[2].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountConstruction4", SqlDbType.VarChar);
            param.Value = count[3].ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GSM1", SqlDbType.Float);
            param.Value = gsm[0];
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GSM2", SqlDbType.Float);
            param.Value = gsm[1];
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GSM3", SqlDbType.Float);
            param.Value = gsm[2];
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GSM4", SqlDbType.Float);
            param.Value = gsm[3];
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            cnx.Close();
            return 1;
        }

        private bool InsertAccessories(Accessories objAccessories, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_accessories_insert_accessories";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@AccessoryId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@tem", SqlDbType.VarChar);
            param.Value = objAccessories.Item;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Float);
            param.Value = objAccessories.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objAccessories.Rate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objAccessories.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objAccessories.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoryPercent", SqlDbType.Int);
            param.Value = objAccessories.AccessoryPercent;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int accessoryId = Convert.ToInt32(outParam.Value);

            return true;
        }

        private bool InsertCharges(Charges objCharges, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_charges_insert_charges";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@ChargeId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@ChargeName", SqlDbType.VarChar);
            param.Value = objCharges.ChargeName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ChargeValue", SqlDbType.Float);
            param.Value = objCharges.ChargeValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objCharges.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objCharges.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int accessoryId = Convert.ToInt32(outParam.Value);

            return true;
        }

        private bool InsertLandedCosting(LandedCosting objLandedCosting, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_landed_costing_insert_landed_costing";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@LandedCostingId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@Mode", SqlDbType.VarChar);
            param.Value = objLandedCosting.Mode;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FOBBoutique", SqlDbType.VarChar);
            param.Value = objLandedCosting.FOBBoutique;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FOBIkandi", SqlDbType.VarChar);
            param.Value = objLandedCosting.FOBIkandi;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeCost", SqlDbType.VarChar);
            param.Value = objLandedCosting.ModeCost;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Duty", SqlDbType.VarChar);
            param.Value = objLandedCosting.Duty;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Handling", SqlDbType.VarChar);
            param.Value = objLandedCosting.Handling;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Delivery", SqlDbType.VarChar);
            param.Value = objLandedCosting.Delivery;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Processing", SqlDbType.VarChar);
            param.Value = objLandedCosting.Processing;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Margin", SqlDbType.Float);
            param.Value = objLandedCosting.Margin;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Discount", SqlDbType.Float);
            param.Value = objLandedCosting.Discount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GrandTotal", SqlDbType.Float);
            param.Value = objLandedCosting.GrandTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QuotedPrice", SqlDbType.Float);
            param.Value = objLandedCosting.QuotedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AgreedPrice", SqlDbType.Float);
            param.Value = objLandedCosting.AgreedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeDeliveryTime", SqlDbType.Int);
            param.Value = objLandedCosting.ModeDeliveryTime;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExpectedBookingDate", SqlDbType.DateTime);
            param.Value = objLandedCosting.ExpectedBookingDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CalculatedDeliveryDate", SqlDbType.DateTime);
            param.Value = objLandedCosting.CalculatedDeliveryDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objLandedCosting.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objLandedCosting.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int landedCostingId = Convert.ToInt32(outParam.Value);
            return true;
        }

        private bool InsertFOBPricing(FOBPricing objFOBPricing, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fob_pricing_insert_fob_pricing";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@FOBPricingId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@FOBDelhi", SqlDbType.VarChar);
            param.Value = objFOBPricing.FOBDelhi;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HaulageCharges", SqlDbType.VarChar);
            param.Value = objFOBPricing.HaulageCharges;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FOBMargin", SqlDbType.Float);
            param.Value = objFOBPricing.FOBMargin;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Discount", SqlDbType.Float);
            param.Value = objFOBPricing.Discount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GrandTotal", SqlDbType.Float);
            param.Value = objFOBPricing.GrandTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QuotedPrice", SqlDbType.Float);
            param.Value = objFOBPricing.QuotedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AgreedPrice", SqlDbType.Float);
            param.Value = objFOBPricing.AgreedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeDelivery", SqlDbType.VarChar);
            param.Value = objFOBPricing.ModeDelivery;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExpectedBookingDate", SqlDbType.DateTime);
            param.Value = objFOBPricing.ExpectedBookingDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CalculatedDeliveryDate", SqlDbType.DateTime);
            param.Value = objFOBPricing.CalculatedDeliveryDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objFOBPricing.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int fobPricingId = Convert.ToInt32(outParam.Value);

            return true;
        }


        private bool UpdateTotalCost(Int64 CostingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_update_costing_totalprice";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;

            param = new SqlParameter("@CostingId", SqlDbType.VarChar);
            param.Value = CostingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            return true;
        }

        #endregion

        #region Updation Methods

        public bool UpdateCosting(Costing objCosting, int Role)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_costing_update_costing";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    //SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Update);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = objCosting.CostingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = objCosting.ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    param.Value = objCosting.DepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDepartmentID", SqlDbType.Int);
                    param.Value = objCosting.ParentDepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = objCosting.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBestSeller", SqlDbType.Bit);
                    param.Value = objCosting.IsBestSeller;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = objCosting.Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Weight", SqlDbType.Decimal);
                    param.Value = objCosting.Weight;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PrintIds", SqlDbType.VarChar);
                    param.Value = objCosting.PrintIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AgreedPrice", SqlDbType.Float);
                    param.Value = objCosting.AgreedPrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceQuoted", SqlDbType.Float);
                    param.Value = objCosting.PriceQuoted;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrieghtUptoFinalDestination", SqlDbType.Float);
                    param.Value = objCosting.FrieghtUptoFinalDestination;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FrieghtUptoPort", SqlDbType.Float);
                    param.Value = objCosting.FrieghtUptoPort;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FincCost", SqlDbType.Float);
                    param.Value = objCosting.FincCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DirectCost", SqlDbType.Float);
                    param.Value = objCosting.DirectCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //manisha 12th may 2011
                    param = new SqlParameter("@OverHead", SqlDbType.Float);
                    param.Value = objCosting.OverHead;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //Added By Ashish on 26/2/2014
                    param = new SqlParameter("@DesignCommission", SqlDbType.Float);
                    param.Value = objCosting.DesignCommission;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //END

                    //manisha 13th may 2011
                    param = new SqlParameter("@MakingType", SqlDbType.VarChar);
                    param.Value = objCosting.MakingType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@ExpectedQty", SqlDbType.Int);
                    param.Value = objCosting.ExpectedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //

                    param = new SqlParameter("@ConvertTo", SqlDbType.Int);
                    param.Value = objCosting.ConvertTo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MarkupOnUnitCTC", SqlDbType.Float);
                    param.Value = objCosting.MarkupOnUnitCTC;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CommisionPercent", SqlDbType.Float);
                    param.Value = objCosting.CommisionPercent;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConversionRate", SqlDbType.Float);
                    param.Value = objCosting.ConversionRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OverallComments", SqlDbType.VarChar);
                    param.Value = objCosting.OverallComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = objCosting.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPlChangesHistory", SqlDbType.VarChar);
                    param.Value = objCosting.BIPlChangesHistory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@KandiChangesHistory", SqlDbType.VarChar);
                    param.Value = objCosting.iKandiChangesHistory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FileName", SqlDbType.VarChar);
                    param.Value = objCosting.FileName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OB_WS", SqlDbType.Int);
                    param.Value = objCosting.OB_WS;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Achievement", SqlDbType.Int);
                    param.Value = objCosting.Achivement;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                    SaveCosting(objCosting, cnx, transaction, true, Role);

                    transaction.Commit();
                    return true;
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
            }

            return false;
        }

        private bool UpdateFabricCosting(FabricCosting objFabricCosting, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fabric_costing_update_fabric_costing";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            //cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@FabricCostingId", SqlDbType.Int);
            param.Value = objFabricCosting.FabricCostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricType", SqlDbType.VarChar);
            param.Value = objFabricCosting.FabricType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fabric", SqlDbType.VarChar);
            param.Value = objFabricCosting.Fabric;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PrintType", SqlDbType.VarChar);
            param.Value = objFabricCosting.PrintType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Width", SqlDbType.Float);
            param.Value = objFabricCosting.Width;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Average", SqlDbType.Float);
            param.Value = objFabricCosting.Average;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objFabricCosting.Rate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Float);
            param.Value = objFabricCosting.Amount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Waste", SqlDbType.Float);
            param.Value = objFabricCosting.Waste;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objFabricCosting.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sAir", SqlDbType.Bit);
            param.Value = objFabricCosting.IsAir;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Layfilepath", SqlDbType.VarChar, 500);
            param.Value = objFabricCosting.LayFileName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();

            return true;
        }

        private bool UpdateAccessories(Accessories objAccessories, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_accessories_update_accessories";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@AccessoryId", SqlDbType.Int);
            param.Value = objAccessories.AccessoryID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@tem", SqlDbType.VarChar);
            param.Value = objAccessories.Item;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Float);
            param.Value = objAccessories.Quantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objAccessories.Rate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objAccessories.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoryPercent", SqlDbType.Int);
            param.Value = objAccessories.AccessoryPercent;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool UpdateCharges(Charges objCharges, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_charges_update_charges";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@ChargeId", SqlDbType.Int);
            param.Value = objCharges.ChargeID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ChargeName", SqlDbType.VarChar);
            param.Value = objCharges.ChargeName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ChargeValue", SqlDbType.Int);
            param.Value = objCharges.ChargeValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objCharges.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool UpdateLandedCosting(LandedCosting objLandedCosting, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_landed_costing_update_landed_costing";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@LandedCostingId", SqlDbType.Int);
            param.Value = objLandedCosting.LandedCostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Mode", SqlDbType.VarChar);
            param.Value = objLandedCosting.Mode;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FOBBoutique", SqlDbType.VarChar);
            param.Value = objLandedCosting.FOBBoutique;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FOBIkandi", SqlDbType.VarChar);
            param.Value = objLandedCosting.FOBIkandi;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeCost", SqlDbType.VarChar);
            param.Value = objLandedCosting.ModeCost;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Duty", SqlDbType.VarChar);
            param.Value = objLandedCosting.Duty;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Handling", SqlDbType.VarChar);
            param.Value = objLandedCosting.Handling;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Delivery", SqlDbType.VarChar);
            param.Value = objLandedCosting.Delivery;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Processing", SqlDbType.VarChar);
            param.Value = objLandedCosting.Processing;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Margin", SqlDbType.Float);
            param.Value = objLandedCosting.Margin;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Discount", SqlDbType.Float);
            param.Value = objLandedCosting.Discount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GrandTotal", SqlDbType.Float);
            param.Value = objLandedCosting.GrandTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QuotedPrice", SqlDbType.Float);
            param.Value = objLandedCosting.QuotedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AgreedPrice", SqlDbType.Float);
            param.Value = objLandedCosting.AgreedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeDeliveryTime", SqlDbType.Int);
            param.Value = objLandedCosting.ModeDeliveryTime;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExpectedBookingDate", SqlDbType.DateTime);
            param.Value = objLandedCosting.ExpectedBookingDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CalculatedDeliveryDate", SqlDbType.DateTime);
            param.Value = objLandedCosting.CalculatedDeliveryDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objLandedCosting.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool UpdateFOBPricing(FOBPricing objFOBPricing, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fob_pricing_update_fob_pricing";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@FOBPricingId", SqlDbType.Int);
            param.Value = objFOBPricing.FOBPricingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FOBDelhi", SqlDbType.VarChar);
            param.Value = objFOBPricing.FOBDelhi;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@HaulageCharges", SqlDbType.VarChar);
            param.Value = objFOBPricing.HaulageCharges;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FOBMargin", SqlDbType.Float);
            param.Value = objFOBPricing.FOBMargin;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Discount", SqlDbType.Float);
            param.Value = objFOBPricing.Discount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GrandTotal", SqlDbType.Float);
            param.Value = objFOBPricing.GrandTotal;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@QuotedPrice", SqlDbType.Float);
            param.Value = objFOBPricing.QuotedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AgreedPrice", SqlDbType.Float);
            param.Value = objFOBPricing.AgreedPrice;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeDelivery", SqlDbType.VarChar);
            param.Value = objFOBPricing.ModeDelivery;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ExpectedBookingDate", SqlDbType.DateTime);
            param.Value = objFOBPricing.ExpectedBookingDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CalculatedDeliveryDate", SqlDbType.DateTime);
            param.Value = objFOBPricing.CalculatedDeliveryDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        #endregion

        #region Common Methods for Insertion & Deletion

        private void SaveCosting(Costing objCosting, SqlConnection cnx, SqlTransaction transaction, bool isUpdation, int Role)
        {
            DeleteCostingChildTableData(objCosting.CostingID, cnx, transaction, Role);

            if (null != objCosting.FabricCostingItems && objCosting.FabricCostingItems.Count > 0)
            {
                foreach (FabricCosting objFabricCosting in objCosting.FabricCostingItems)
                {
                    objFabricCosting.CostingID = objCosting.CostingID;

                    if (objFabricCosting.CostingQueryType == QueryType.Insert)
                        InsertFabricCosting(objFabricCosting, cnx, transaction);
                    else if (objFabricCosting.CostingQueryType == QueryType.Update)
                        UpdateFabricCosting(objFabricCosting, cnx, transaction);
                    else if (isUpdation)
                        DeleteFabricCosting(objFabricCosting.FabricCostingID, cnx, transaction);
                }
            }

            if (null != objCosting.AccessoryItems && objCosting.AccessoryItems.Count > 0)
            {
                foreach (Accessories objAccessories in objCosting.AccessoryItems)
                {
                    objAccessories.CostingID = objCosting.CostingID;

                    if (objAccessories.CostingQueryType == QueryType.Insert)
                        InsertAccessories(objAccessories, cnx, transaction);
                    else if (objAccessories.CostingQueryType == QueryType.Update)
                        UpdateAccessories(objAccessories, cnx, transaction);
                    else if (isUpdation)
                        DeleteAccessories(objAccessories.AccessoryID, cnx, transaction);
                }
            }

            if (null != objCosting.ChargesItems && objCosting.ChargesItems.Count > 0)
            {
                foreach (Charges objCharges in objCosting.ChargesItems)
                {
                    objCharges.CostingID = objCosting.CostingID;

                    if (objCharges.CostingQueryType == QueryType.Insert)
                        InsertCharges(objCharges, cnx, transaction);
                    else if (objCharges.CostingQueryType == QueryType.Update)
                        UpdateCharges(objCharges, cnx, transaction);
                    else if (isUpdation)
                        DeleteCharges(objCharges.ChargeID, cnx, transaction);
                }
            }
            if (null != objCosting.LandedCostingItems && objCosting.LandedCostingItems.Count > 0)
            {
                foreach (LandedCosting objLandedCosting in objCosting.LandedCostingItems)
                {
                    objLandedCosting.CostingID = objCosting.CostingID;

                    if (objLandedCosting.CostingQueryType == QueryType.Insert)
                        InsertLandedCosting(objLandedCosting, cnx, transaction);
                    else if (objLandedCosting.CostingQueryType == QueryType.Update)
                        UpdateLandedCosting(objLandedCosting, cnx, transaction);
                    else if (isUpdation)
                        DeleteLandedCosting(objLandedCosting.LandedCostingID, cnx, transaction);
                }
            }

            if (null != objCosting.FOBPricingItem && null != objCosting.FOBPricingItem.FOBDelhi && objCosting.FOBPricingItem.FOBDelhi != string.Empty)
            {
                objCosting.FOBPricingItem.CostingID = objCosting.CostingID;

                if (objCosting.FOBPricingItem.CostingQueryType == QueryType.Insert)
                    InsertFOBPricing(objCosting.FOBPricingItem, cnx, transaction);
                else if (objCosting.FOBPricingItem.CostingQueryType == QueryType.Update)
                    UpdateFOBPricing(objCosting.FOBPricingItem, cnx, transaction);
            }
            //Kuldeep to update totalPrice in Costing.
            UpdateTotalCost(objCosting.CostingID, cnx, transaction);
        }

        private bool DeleteCostingChildTableData(int costingId, SqlConnection cnx, SqlTransaction transaction, int Role)
        {
            string cmdText = "sp_costing_delete_from_costing_child_tables_by_costing_id";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = costingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Role", SqlDbType.Int);
            param.Value = Role;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //param = new SqlParameter("@Role", SqlDbType.Int);
            //param.Value = Role;
            //param.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(param);

            SqlParameter outParam = new SqlParameter("@return", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            int i = cmd.ExecuteNonQuery();
            //return Convert.ToInt32(outParam.Value);
            return true;
        }

        #endregion

        #region Deletion Methods

        private bool DeleteFabricCosting(int fabricCostingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fabric_costing_delete_fabric_costing_by_id";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param = new SqlParameter("@FabricCostingId", SqlDbType.Int);
            param.Value = fabricCostingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool DeleteAccessories(int accessoryId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_accessories_delete_accessories_by_id";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param = new SqlParameter("@AccessoryId", SqlDbType.Int);
            param.Value = accessoryId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool DeleteCharges(int chargeId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_charges_delete_charges_by_id";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param = new SqlParameter("@ChargeId", SqlDbType.Int);
            param.Value = chargeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool DeleteLandedCosting(int landedCostingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_landed_costing_delete_landed_costing_by_id";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param = new SqlParameter("@LandedCostingId", SqlDbType.Int);
            param.Value = landedCostingId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        #endregion

        #region Read Methods

        public CostingCollection GetCosting(int costingId, int UserID)
        {
            CostingCollection objCostingCollection = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_costing_get_all_costing";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = costingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    DataSet dsCosting = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCosting);

                    objCostingCollection = ConvertDataSetToCostingCollection(dsCosting);
                }
                catch (SqlException ex) 
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex) 
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return objCostingCollection;
        }

        private CostingCollection ConvertDataSetToCostingCollection(DataSet dsCosting)
        {
            int repeatCount = 1;
            CostingCollection objCostingCollection = new CostingCollection();

            if (dsCosting.Tables.Count == 12)
                repeatCount = 2;

            for (int i = 0; i < repeatCount; i++)
            {
                //Because each Costing 
                var accessCounter = 6 * i;

                Costing objCosting = new Costing();

                DataTable dt = dsCosting.Tables[0 + accessCounter];

                if (dt.Rows.Count == 0)
                    return objCostingCollection;

                objCosting.CostingID = (dt.Rows[0]["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["CostingId"]);
                objCosting.ClientID = (dt.Rows[0]["ClientId"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["ClientId"]);
                objCosting.ClientName = (dt.Rows[0]["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["ClientName"]);
                objCosting.DepartmentID = (dt.Rows[0]["DepartmentId"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["DepartmentId"]);
                objCosting.ParentDepartmentID = (dt.Rows[0]["ParentDepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["ParentDepartmentID"]);
                objCosting.IsIkandiClient = (dt.Rows[0]["IsIkandiClient"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["IsIkandiClient"]);

                objCosting.FileName = Convert.ToString(dt.Rows[0]["FilePath"]);

                objCosting.StyleID = (dt.Rows[0]["StyleId"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["StyleId"]);
                objCosting.StyleNumber = (dt.Rows[0]["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["StyleNumber"]);
                objCosting.OrderId = (dt.Rows[0]["OrderId"] == DBNull.Value) ? -1 : Convert.ToInt32(dt.Rows[0]["OrderId"]);
                objCosting.OrderDetailId = (dt.Rows[0]["OrderDetailId"] == DBNull.Value) ? -1 : Convert.ToInt32(dt.Rows[0]["OrderDetailId"]);
                objCosting.IsBestSeller = (dt.Rows[0]["IsBestSeller"] == DBNull.Value) ? false : Convert.ToBoolean(dt.Rows[0]["IsBestSeller"]);
                objCosting.TeckFileDoc = (dt.Rows[0]["TeckPackFile"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["TeckPackFile"]);

                objCosting.Quantity = (dt.Rows[0]["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["Quantity"]);
                objCosting.Weight = (dt.Rows[0]["Weight"] == DBNull.Value) ? 0 : Convert.ToDecimal(dt.Rows[0]["Weight"]);
                objCosting.ParentCostingID = (dt.Rows[0]["ParentCostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["ParentCostingId"]);
                objCosting.PrintIds = (dt.Rows[0]["PrintIds"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["PrintIds"]);
                objCosting.AgreedPrice = (dt.Rows[0]["AgreedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["AgreedPrice"]);
                objCosting.PriceQuoted = (dt.Rows[0]["PriceQuoted"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["PriceQuoted"]);

                objCosting.FrieghtUptoFinalDestination = (dt.Rows[0]["FrieghtUptoFinalDestination"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["FrieghtUptoFinalDestination"]);
                objCosting.FrieghtUptoPort = (dt.Rows[0]["FrieghtUptoPort"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["FrieghtUptoPort"]);
                objCosting.FincCost = (dt.Rows[0]["FincCost"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["FincCost"]);
                objCosting.DirectCost = (dt.Rows[0]["DirectCost"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["DirectCost"]);

                objCosting.ConvertTo = (dt.Rows[0]["ConvertTo"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["ConvertTo"]);
                objCosting.MarkupOnUnitCTC = (dt.Rows[0]["MarkupOnUnitCTC"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["MarkupOnUnitCTC"]);
                objCosting.CommisionPercent = (dt.Rows[0]["CommisionPercent"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["CommisionPercent"]);
                objCosting.ConversionRate = (dt.Rows[0]["ConversionRate"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["ConversionRate"]);

                objCosting.OverallComments = (dt.Rows[0]["OverallComments"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["OverallComments"]);
                objCosting.Comments = (dt.Rows[0]["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["Comments"]);

                objCosting.iKandiChangesHistory = (dt.Rows[0]["iKandiChangesHistory"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["iKandiChangesHistory"]);
                objCosting.BIPlChangesHistory = (dt.Rows[0]["BIPlChangesHistory"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["BIPlChangesHistory"]);

                objCosting.SampleImageURL1 = (dt.Rows[0]["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["SampleImageURL1"]);
                objCosting.SampleImageURL2 = (dt.Rows[0]["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["SampleImageURL2"]);

                objCosting.TargetPrice = (dt.Rows[0]["TargetPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["TargetPrice"]);
                objCosting.TargetPriceCurrency = (dt.Rows[0]["TargetPriceCurrency"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["TargetPriceCurrency"]);
                objCosting.DesignerName = (dt.Rows[0]["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["DesignerName"]);

                objCosting.Discount = (dt.Rows[0]["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(dt.Rows[0]["Discount"]);
                objCosting.AllQuantity = (dt.Rows[0]["AllQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["AllQuantity"]);

                objCosting.UpdatedOn = (dt.Rows[0]["UpdatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["UpdatedOn"]);
                //Added By Ashish on 27/2/2014
                objCosting.CreatedOn = (dt.Rows[0]["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                //END
                //manisha on 12th may 2011
                objCosting.OverHead = (dt.Rows[0]["OverHeadQty"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["OverHeadQty"]);
                //
                //Added By Ashish on 27/2/2014
                objCosting.DesignCommission = (dt.Rows[0]["DesignCommission"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["DesignCommission"]);

                //END
                //manisha on 13th may 2011
                objCosting.MakingType = (dt.Rows[0]["MakingTypeVal"] == DBNull.Value) ? "Select" : Convert.ToString(dt.Rows[0]["MakingTypeVal"]);
                objCosting.ExpectedQty = (dt.Rows[0]["ExpectedQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["ExpectedQty"]);
                //
                objCosting.CurrentStatusID = (dt.Rows[0]["CurrentStatusID"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["CurrentStatusID"]);
                objCosting.PriceQuotedVisibility = (dt.Rows[0]["PriceQuotedVisibility"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["PriceQuotedVisibility"]);
                objCosting.CounterComplete = (dt.Rows[0]["CounterComplete"] == DBNull.Value) ? false : Convert.ToBoolean(dt.Rows[0]["CounterComplete"]);

                // Added by Ravi kumar on 26/8/2014
                //objCosting.LayFileName = Convert.ToString(dt.Rows[0]["Layfilepath"]);
                objCosting.Achivement = (dt.Rows[0]["Acheivement"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["Acheivement"]);
                objCosting.OB_WS = (dt.Rows[0]["OB_WS"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["OB_WS"]);
                objCosting.IsVersion = (dt.Rows[0]["IsVersion"] == DBNull.Value) ? false : Convert.ToBoolean(dt.Rows[0]["IsVersion"]);
                objCosting.VerifyCosting = (dt.Rows[0]["VerifyCosting"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["VerifyCosting"]);
                objCosting.Costing_Waste = (dt.Rows[0]["FrieghtUptoFinalDestination"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["FrieghtUptoFinalDestination"]);
                //objCosting.frtUptoport = (dt.Rows[0]["FrieghtUptoPort"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["FrieghtUptoPort"]);
                // Added by Ravi kumar on 6/1/2015
                objCosting.CostingTask = (dt.Rows[0]["CostingTask"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["CostingTask"]);
                objCosting.Weight_ReadOnly = (dt.Rows[0]["Weight_ReadOnly"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["Weight_ReadOnly"]);
                // End Added by Ravi kumar on 6/1/2015
                Fits fits = new Fits();
                fits.IsStcApproved = (dt.Rows[0]["StcApproved"] == DBNull.Value) ? false : Convert.ToBoolean(dt.Rows[0]["StcApproved"]);
                fits.SealDate = (dt.Rows[0]["SealDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["SealDate"]);
                fits.SpecsUploadDate = (dt.Rows[0]["SpecsUploadDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["SpecsUploadDate"]);
                fits.SpecsUploadTargetDate = (dt.Rows[0]["SpecsUploadTargetDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["SpecsUploadTargetDate"]);

                FitsTrack fitsTrack = new FitsTrack();
                fitsTrack.CommentsSentFor = (dt.Rows[0]["CommentsSentFor"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["CommentsSentFor"]);
                fitsTrack.PlanningFor = (dt.Rows[0]["PlanningFor"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["PlanningFor"]);
                fitsTrack.fitRequestedOn = (dt.Rows[0]["fitRequestedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["fitRequestedOn"]);
                fitsTrack.AckDate = (dt.Rows[0]["AckDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["AckDate"]);
                fitsTrack.NextPlannedDate = (dt.Rows[0]["NextPlannedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["NextPlannedDate"]);

                InlinePPMOrderContract inlinePPMOrderContract = new InlinePPMOrderContract(); // to get top send target and top send actual
                inlinePPMOrderContract.TopSentActual = (dt.Rows[0]["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["TopSentActual"]);
                inlinePPMOrderContract.TopActualApproval = (dt.Rows[0]["TopActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["TopActualApproval"]);
                inlinePPMOrderContract.TopStatus = (dt.Rows[0]["TopStatus"] == DBNull.Value) ? TopStatusType.UNKNOWN : (TopStatusType)Convert.ToInt32(dt.Rows[0]["TopStatus"]);

                objCosting.FITsStatus = Constants.GetFitsStatus(inlinePPMOrderContract.TopSentActual, inlinePPMOrderContract.TopActualApproval, fits.IsStcApproved, fits.SealDate,
                                     fitsTrack.CommentsSentFor, fitsTrack.PlanningFor, fitsTrack.fitRequestedOn, fitsTrack.AckDate, inlinePPMOrderContract.TopStatus, fits.SpecsUploadTargetDate, fits.SpecsUploadDate);

                dt = dsCosting.Tables[1 + accessCounter];
                objCosting.FabricCostingItems = new List<FabricCosting>();

                foreach (DataRow dr in dt.Rows)
                {
                    FabricCosting objFabricCosting = new FabricCosting();
                    objFabricCosting.FabricCostingID = (dr["FabricCostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["FabricCostingId"]);
                    objFabricCosting.FabricType = (dr["FabricType"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FabricType"]);
                    objFabricCosting.Fabric = (dr["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Fabric"]);
                    objFabricCosting.PrintType = (dr["PrintType"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PrintType"]);
                    objFabricCosting.Width = (dr["Width"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Width"]);
                    objFabricCosting.Average = (dr["Average"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Average"]);
                    objFabricCosting.Rate = (dr["Rate"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Rate"]);
                    objFabricCosting.Amount = (dr["Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Amount"]);
                    objFabricCosting.Waste = (dr["Waste"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Waste"]);
                   // objFabricCosting.Total = objFabricCosting.Amount * (1 + objFabricCosting.Waste / 100);
                    objFabricCosting.Total = objFabricCosting.Amount;
                    objFabricCosting.CostingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                    objFabricCosting.SequenceNumber = (dr["SequenceNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SequenceNumber"]);
                    objFabricCosting.IsAir = (dr["IsAir"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsAir"]);
                    objFabricCosting.isMultiple = (dr["IsMultiple"] == DBNull.Value) ? "N" : Convert.ToString(dr["IsMultiple"]);
                    //objFabricCosting.FabricType = (dr["SpecialFabricDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SpecialFabricDetails"]);
                    objFabricCosting.FabPrintNumber = (dr["PrintNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["PrintNumber"]);
                    objFabricCosting.IsPrint = (dr["IsPrint"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["IsPrint"]);
                    objFabricCosting.specialFabricDetails = (dr["SpecialFabricDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SpecialFabricDetails"]);
                    objFabricCosting.LayFileName = (dr["Layfilepath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Layfilepath"]);
                    objFabricCosting.CadFileName = (dr["CADFilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["CADFilePath"]);
                    objFabricCosting.StcFileName = (dr["MarkerLayFilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["MarkerLayFilePath"]);

                    objCosting.FabricCostingItems.Add(objFabricCosting);
                }

                dt = dsCosting.Tables[2 + accessCounter];
                objCosting.ChargesItems = new List<Charges>();

                foreach (DataRow dr in dt.Rows)
                {
                    Charges objCharges = new Charges();
                    objCharges.ChargeID = (dr["ChargeId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ChargeId"]);
                    objCharges.ChargeName = (dr["ChargeName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ChargeName"]);
                    objCharges.ChargeValue = (dr["ChargeValue"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["ChargeValue"]);
                    objCharges.CostingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                    objCharges.SequenceNumber = (dr["SequenceNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SequenceNumber"]);

                    objCosting.ChargesItems.Add(objCharges);
                }

                dt = dsCosting.Tables[3 + accessCounter];
                objCosting.AccessoryItems = new List<Accessories>();

                foreach (DataRow dr in dt.Rows)
                {
                    Accessories objAccessories = new Accessories();
                    objAccessories.AccessoryID = (dr["AccessoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["AccessoryId"]);
                    objAccessories.Item = (dr["Item"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Item"]);
                    objAccessories.Quantity = (dr["Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Quantity"]);
                    objAccessories.Rate = (dr["Rate"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Rate"]);
                    objAccessories.Amount = objAccessories.Quantity * objAccessories.Rate;
                    objAccessories.CostingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                    objAccessories.SequenceNumber = (dr["SequenceNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SequenceNumber"]);
                    objAccessories.AccessoryPercent = (dr["AccessoryPercent"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["AccessoryPercent"]);

                    objCosting.AccessoryItems.Add(objAccessories);
                }

                dt = dsCosting.Tables[4 + accessCounter];
                objCosting.LandedCostingItems = new List<LandedCosting>();

                foreach (DataRow dr in dt.Rows)
                {
                    LandedCosting objLandedCosting = new LandedCosting();
                    objLandedCosting.LandedCostingID = (dr["LandedCostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["LandedCostingId"]);
                    objLandedCosting.Mode = (dr["Mode"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Mode"]);
                    objLandedCosting.FOBBoutique = (dr["FobBoutique"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FobBoutique"]);
                    objLandedCosting.FOBIkandi = (dr["FOBIkandi"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FOBIkandi"]);
                    objLandedCosting.ModeCost = (dr["ModeCost"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ModeCost"]);
                    objLandedCosting.Duty = (dr["Duty"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Duty"]);
                    objLandedCosting.Handling = (dr["Handling"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Handling"]);
                    objLandedCosting.Delivery = (dr["Delivery"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Delivery"]);
                    objLandedCosting.Processing = (dr["Processing"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Processing"]);
                    objLandedCosting.Margin = (dr["Margin"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Margin"]);
                    objLandedCosting.Discount = (dr["Discount"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Discount"]);
                    objLandedCosting.GrandTotal = (dr["GrandTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["GrandTotal"]);
                    objLandedCosting.QuotedPrice = (dr["QuotedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["QuotedPrice"]);
                    objLandedCosting.AgreedPrice = (dr["AgreedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["AgreedPrice"]);
                    objLandedCosting.ModeDeliveryTime = (dr["ModeDeliveryTime"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ModeDeliveryTime"]);
                    objLandedCosting.ExpectedBookingDate = (dr["ExpectedBookingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["ExpectedBookingDate"]);
                    objLandedCosting.CalculatedDeliveryDate = (dr["CalculatedDeliveryDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CalculatedDeliveryDate"]);
                    objLandedCosting.CostingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                    objLandedCosting.SequenceNumber = (dr["SequenceNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SequenceNumber"]);

                    objCosting.LandedCostingItems.Add(objLandedCosting);
                }

                dt = dsCosting.Tables[5 + accessCounter];
                objCosting.FOBPricingItem = new FOBPricing();

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    FOBPricing objFOBPricing = new FOBPricing();
                    objFOBPricing.FOBPricingID = (dr["FOBPricingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["FOBPricingId"]);
                    objFOBPricing.CostingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                    objFOBPricing.FOBDelhi = (dr["FOBDelhi"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FOBDelhi"]);
                    objFOBPricing.HaulageCharges = (dr["HaulageCharges"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["HaulageCharges"]);
                    objFOBPricing.FOBMargin = (dr["FOBMargin"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["FOBMargin"]);
                    objFOBPricing.Discount = (dr["Discount"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Discount"]);
                    objFOBPricing.GrandTotal = (dr["GrandTotal"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["GrandTotal"]);
                    objFOBPricing.QuotedPrice = (dr["QuotedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["QuotedPrice"]);
                    objFOBPricing.AgreedPrice = (dr["AgreedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["AgreedPrice"]);
                    objFOBPricing.ModeDelivery = (dr["ModeDelivery"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ModeDelivery"]);
                    objFOBPricing.ExpectedBookingDate = (dr["ExpectedBookingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["ExpectedBookingDate"]);
                    objFOBPricing.CalculatedDeliveryDate = (dr["CalculatedDeliveryDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CalculatedDeliveryDate"]);

                    objCosting.FOBPricingItem = objFOBPricing;
                }

                objCostingCollection.Add(objCosting);
            }

            return objCostingCollection;
        }
        // edit by surendra technical module
        public bool bCheckOB(int styleid)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "sp_CheckSamObValue_TechModule";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    DataSet dsCheckExistFabric = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckExistFabric);
                    int a = Convert.ToInt32(dsCheckExistFabric.Tables[0].Rows[0]["FinalOB"]);
                    if (a == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        // end
        public CostingCollection GetCostingByStyleNumber(string styleNumber, byte isGetMultiple, int SingleVersion)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                if (SingleVersion == 0)
                    cmdText = "sp_costing_get_costing_style_by_style_number";
                else
                    cmdText = "sp_costing_get_costing_style_by_style_number_Only_For_SingleVersion";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SmallStyleNumber", SqlDbType.VarChar);
                if (SingleVersion == 0)
                {
                    // Code applied for duplicate costing by RSB dated on 16 march 2017
                    if (styleNumber.EndsWith(" "))
                    {
                        param.Value = styleNumber;
                    }
                    else
                    {
                        param.Value = ((styleNumber.Trim().Split(' ').Length > 1) ? styleNumber.Trim().Split(' ')[1] : styleNumber).Trim();
                    }
                }
                else
                {
                    param.Value = styleNumber;
                }
                // end of Code applied for duplicate costing by RSB dated on 16 march 2017
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = styleNumber;//.Trim();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Role", SqlDbType.Int);
                param.Value = GetRoleForCosting();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sGetMultiple", SqlDbType.Bit);
                param.Value = isGetMultiple;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                CostingCollection objCostingCollection = new CostingCollection();

                while (reader.Read())
                {
                    Costing costing = new Costing();

                    costing.StyleID = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]);
                    costing.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);

                    costing.OrderId = (reader["OrderId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderId"]);

                    costing.ClientID = (reader["ClientID"] == DBNull.Value) ? ((reader["styleClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["styleClientID"])) : Convert.ToInt32(reader["ClientID"]);
                    costing.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                    costing.Discount = (reader["Discount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Discount"]);
                    costing.DepartmentID = (reader["DepartmentID"] == DBNull.Value || Convert.ToInt32(reader["DepartmentID"]) <= 0) ? (reader["styleDepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["styleDepartmentID"]) : Convert.ToInt32(reader["DepartmentID"]);
                    costing.ParentDepartmentID = (reader["ParentDepartmentID"] == DBNull.Value || Convert.ToInt32(reader["ParentDepartmentID"]) <= 0) ? (reader["styleParentDepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["styleParentDepartmentID"]) : Convert.ToInt32(reader["ParentDepartmentID"]);
                    costing.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                    costing.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);

                    costing.TargetPrice = (reader["TargetPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TargetPrice"]);
                    costing.TargetPriceCurrency = (reader["TargetPriceCurrency"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TargetPriceCurrency"]);
                    costing.DesignerName = (reader["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerName"]);

                    costing.CostingID = (reader["CostingId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CostingId"]);
                    costing.ParentCostingID = (reader["ParentCostingId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ParentCostingId"]);

                    costing.PriceQuoted = (reader["PriceQuoted"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PriceQuoted"]);
                    costing.AllQuantity = (reader["AllQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["AllQuantity"]);

                    costing.CurrentStatusID = (reader["CurrentStatusID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CurrentStatusID"]);
                    costing.PriceQuotedVisibility = (reader["PriceQuotedVisibility"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PriceQuotedVisibility"]);
                    costing.CounterComplete = (reader["CounterComplete"] == DBNull.Value) ? false : Convert.ToBoolean(reader["CounterComplete"]);

                    //if (GetRoleForCosting() == 1 && costing.PriceQuoted == 0)
                    //    continue;

                    var objCosting = from c in objCostingCollection where c.StyleNumber == costing.StyleNumber select c;

                    if (objCosting.ToList().Count == 1 && objCosting.ToList()[0].ParentCostingID == -1)
                        objCostingCollection.Remove(objCosting.ToList()[0]);
                    else if (objCosting.ToList().Count == 1 && costing.ParentCostingID == -1)
                        continue;

                    objCostingCollection.Add(costing);
                }

                return objCostingCollection;
            }

        }









        public DataTable GetCostedStyles(DateTime CostingDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_costing_get_costed_styles";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@CostingDate", SqlDbType.DateTime);
                param.Value = CostingDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsCostedStyles = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsCostedStyles);

                if (dsCostedStyles.Tables.Count > 0)
                    return dsCostedStyles.Tables[0];
                else
                    return null;
            }
        }

        public bool DeleteStyleAndCostingSheet(int styleId, int costingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_style_delete_style_costing_workflow_by_style_costing_id";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = styleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = costingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    //transaction = cnx.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    // transaction.Commit();

                    return true;
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
            }

            return false;
        }
        public bool bCheck_Update_Price_Visibilty(int costingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_Check_Update_Order_Price_Visibilty";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    DataSet dsCheckVisibilty = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;


                    param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = costingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCheckVisibilty);
                    int a = Convert.ToInt32(dsCheckVisibilty.Tables[0].Rows[0]["CheckVisibilty"]);
                    if (a == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    //transaction = cnx.BeginTransaction();
                    // cmd.ExecuteNonQuery();
                    // transaction.Commit();

                    //return true;
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
            }

            return false;
        }

        #endregion

        #region Misc Methods

        public bool AgreeForIKandiCostingData(int costingId, int parentCostingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_costing_agree_for_iKandi_costing_data";

                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = costingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentCostingId", SqlDbType.Int);
                    param.Value = parentCostingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    return true;
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

            return false;
        }

        public bool DisagreeForIKandiCostingData(int costingId, int parentCostingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_costing_disagree_for_iKandi_costing_data";

                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = costingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentCostingId", SqlDbType.Int);
                    param.Value = parentCostingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    return true;
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

            return false;
        }

        public int CheckIfIKandiData(int costingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_costing_check_if_iKandi_data";

                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = costingId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    object rowCount = cmd.ExecuteScalar();

                    if (null != rowCount)
                        return Convert.ToInt32(rowCount);
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

            return 0;
        }

        public List<string> GetAllZipDetails()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_zip_get_all_zip_details";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsZip = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsZip);

                reader = cmd.ExecuteReader();
                List<string> zipDetails = new List<string>();

                string strZipDetail = string.Empty;

                while (reader.Read())
                {
                    strZipDetail = reader["Detail"].ToString();
                    zipDetails.Add(strZipDetail);
                }

                zipDetails.Sort();
                return zipDetails;
            }
        }

        private int GetRoleForCosting()
        {
            switch (this.LoggedInUser.UserData.DesignationID)
            {
                case (int)Designation.BIPL_Sales_Manager:
                case (int)Designation.BIPL_Merchandising_Manager:
                case (int)Designation.BIPL_Sales_Advisor:
                case (int)Designation.BIPL_Merchandising_AccountManager:
                case (int)Designation.BIPL_FITs_Manager:
                case (int)Designation.BIPL_Merchandising_FitMerchant:
                case (int)Designation.BIPL_Merchandising_SamplingMerchant:
                    
                    return 0;
                case (int)Designation.iKandi_Sales_Manager:
                case (int)Designation.iKandi_Sales_SalesManager:
                    return 1;
                default:
                    return -1;
            }
        }

        #endregion


        public string GetPriceForGarmentTypeSAM(int PutSAM, int ExpectedQty)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                // cmdText = "sp_costing_get_makingprice_SAM";
                cmdText = "sp_costing_get_makingprice_SAM_New";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@PutSAM", SqlDbType.VarChar);
                param.Value = PutSAM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExpectedQty", SqlDbType.Int);
                param.Value = ExpectedQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object objCID = cmd.ExecuteScalar();

                if (objCID == DBNull.Value)
                    return "";
                else
                    return Convert.ToString(objCID);

            }
        }


        public string CostingExpectedQtyDAL(int Qty)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                // cmdText = "sp_costing_get_makingprice_SAM";
                cmdText = "sp_costing_get_makingprice_SAM_New_RangeWise";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ExpectedQty", SqlDbType.VarChar);
                param.Value = Qty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                object objCID = cmd.ExecuteScalar();

                if (objCID == DBNull.Value)
                    return "";
                else
                    return Convert.ToString(objCID);

            }
        }


        public int GetParentCostingID(int ChildCostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_parent_costing_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ChildCostingId", SqlDbType.Int);
                param.Value = ChildCostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object objCID = cmd.ExecuteScalar();

                if (objCID == DBNull.Value)
                    return -1;
                else
                    return Convert.ToInt32(objCID);

            }
        }
        // edit by surendra support issue
        public int GetClientID(int ChildCostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                int iClientID = 0;

                cmdText = "sp_costing_get_parent_costing_id_With_ClientID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ChildCostingId", SqlDbType.Int);
                param.Value = ChildCostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        iClientID = reader["ClientID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ClientID"]);
                    }
                }

                //  object objCID = cmd.ExecuteScalar();
                return Convert.ToInt32(iClientID);

            }
        }
        public int GetDeptID(int ChildCostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                int iDeptID = 0;

                cmdText = "sp_costing_get_parent_costing_id_With_DeptID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@ChildCostingId", SqlDbType.Int);
                param.Value = ChildCostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        iDeptID = reader["DepartmentId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DepartmentId"]);
                    }
                }

                //  object objCID = cmd.ExecuteScalar();
                return Convert.ToInt32(iDeptID);



            }
        }
        //

        public string UpdateBIPLPriceOnOrders(int CostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_update_bipl_price_in_all_running_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //cmd.CommandTimeout = 6000;
                SqlParameter param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = this.LoggedInUser.UserData.FullName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@OrderIDList", SqlDbType.VarChar, 2000);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                return outParam.Value.ToString();

            }
        }
        public string GetPairedCosting(int CostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                string PairedCosting = string.Empty;

                cmdText = "SP_GetPairedCosting";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PairedCosting = reader["PairedID"] == DBNull.Value ? "" : Convert.ToString(reader["PairedID"]);
                    }
                }

                //  object objCID = cmd.ExecuteScalar();
                return PairedCosting;



            }
        }
        public string UpdateiKandiPriceOnOrders_Old(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_update_ikandi_price_in_all_running_orders_old";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = this.LoggedInUser.UserData.FullName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AF", SqlDbType.Int);
                param.Value = (isAF) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AH", SqlDbType.Int);
                param.Value = (isAH) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SF", SqlDbType.Int);
                param.Value = (isSF) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SH", SqlDbType.Int);
                param.Value = (isSH) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FOB", SqlDbType.Int);
                param.Value = (isFOB) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@OrderIDList", SqlDbType.VarChar, 2000);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                return outParam.Value.ToString();

            }
        }


        public string UpdateiKandiPriceOnOrders(string OrderIds, int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_update_ikandi_price_in_all_running_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderIds", SqlDbType.VarChar);
                param.Value = OrderIds;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = this.LoggedInUser.UserData.FullName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AF", SqlDbType.Int);
                param.Value = (isAF) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AH", SqlDbType.Int);
                param.Value = (isAH) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SF", SqlDbType.Int);
                param.Value = (isSF) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SH", SqlDbType.Int);
                param.Value = (isSH) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FOB", SqlDbType.Int);
                param.Value = (isFOB) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@OrderIDList", SqlDbType.VarChar);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                return outParam.Value.ToString();

            }
        }


        public string UpdateiKandiPriceOnOrders(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_update_ikandi_price_in_all_running_orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = this.LoggedInUser.UserData.FullName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AF", SqlDbType.Int);
                param.Value = (isAF) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AH", SqlDbType.Int);
                param.Value = (isAH) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SF", SqlDbType.Int);
                param.Value = (isSF) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SH", SqlDbType.Int);
                param.Value = (isSH) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FOB", SqlDbType.Int);
                param.Value = (isFOB) ? 1 : 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter outParam = new SqlParameter("@OrderIDList", SqlDbType.VarChar);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                return outParam.Value.ToString();

            }
        }

        #region ExpectedQuantity on Costing Sheet
        //manisha 13th may 2011
        public string GetPriceForGarmentType(string GarmentType, int ExpectedQty, string DdlType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_makingprice";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@GarmentName", SqlDbType.VarChar);
                param.Value = GarmentType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExpectedQty", SqlDbType.Int);
                param.Value = ExpectedQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ddlType", SqlDbType.VarChar);
                param.Value = DdlType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object objCID = cmd.ExecuteScalar();

                if (objCID == DBNull.Value)
                    return "";
                else
                    return Convert.ToString(objCID);

            }
        }

        public string GetDefaultExpectedQty()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                //  cmdText = "sp_costing_get_default_ExpectedQty";
                cmdText = "sp_costing_get_default_ExpectedQty_SAM";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                object objCID = cmd.ExecuteScalar();

                if (objCID == DBNull.Value)
                    return "";
                else
                    return Convert.ToString(objCID);

            }
        }

        public DataTable GetGarmentTypeOption(string makingType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_garmentType_options";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@GarmentName", SqlDbType.VarChar);
                param.Value = makingType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");//25th may 2011
                dt.Columns.Add("Option");
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = reader["Id"].ToString();
                    dr["Option"] = reader["Option"].ToString();
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        public DataSet GetExpectedQtyRangewiseDAL()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Get_ExpectedQtyRangewise";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBulkHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsBulkHistory);

                return dsBulkHistory;
            }

        }
        public string GetGarmentNameOption(string garmentType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_garmentName_options";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@GarmentType", SqlDbType.VarChar);
                param.Value = garmentType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                object garmentName = cmd.ExecuteScalar();

                if (garmentName == DBNull.Value)
                    return "";
                else
                    return Convert.ToString(garmentName);

            }
        }

        public int GetCurrencyConversion(int currencyID,string StyleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_currency_coversion";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@currencyID", SqlDbType.Int);
                param.Value = currencyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;


                cmd.Parameters.Add(param);

                object objCID = cmd.ExecuteScalar();

                if (objCID == DBNull.Value)
                    return 0;
                else
                    return Convert.ToInt32(objCID);

            }
        }

        public string GetCurrencySymbolDAL(string currencyID)
        {
            if (string.IsNullOrEmpty(currencyID.Trim()))
                return "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_Currency_symbol";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@currencyID", SqlDbType.VarChar);
                param.Value = currencyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsorderDetail = new DataSet();
                adapter.Fill(dsorderDetail);
                DataTable dt = dsorderDetail.Tables[0];

                string styleNumber = Convert.ToString(dt.Rows[0][0]);
                return styleNumber;

            }
        }

        public DataTable GetBIPLOrderPriceDetails(int StyleId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    string cmdText = "Usp_UpdateBIPLOrderPrice";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }

        public DataTable GetIkandiOrderPriceDetails(int StyleId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    string cmdText = "Usp_UpdateIkandiOrderPrice";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@inType", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return dt;
        }

        public DataTable GetCurrencyDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_Default_Currency";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBulkHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsBulkHistory);

                return dsBulkHistory.Tables[0];
            }
        }



        public DataTable GetChargeValueDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Get_ChargesValue";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBulkHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsBulkHistory);

                return dsBulkHistory.Tables[0];
            }
        }        

        public string[] GetCMT_Value(double SAM, int OB_WS, int Achivement, int ClientId, int DeptId, int StyleId, int Quantity, int createdby)
        {
            Costing objCosting = new Costing();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                // SqlTransaction transaction = null;

                try
                {
                    string cmdText = "usp_Efficiency_CMT_Call";
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter outParam1;

                    outParam1 = new SqlParameter("@CMT", SqlDbType.Int);
                    outParam1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam1);

                    SqlParameter outParam2;

                    outParam2 = new SqlParameter("@OB_WS_OUT", SqlDbType.Int);
                    outParam2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam2);

                    SqlParameter outParam3;

                    outParam3 = new SqlParameter("@TotalMade_OUT", SqlDbType.Int);
                    outParam3.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam3);

                    SqlParameter param;

                    param = new SqlParameter("@SAM", SqlDbType.Float);
                    param.Value = SAM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OB_WS", SqlDbType.Int);
                    param.Value = OB_WS;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Achivement", SqlDbType.Int);
                    param.Value = Achivement;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = createdby;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    //objCosting.CMT = Convert.ToInt32(outParam1.Value);
                    objCosting.CMT = GetCostingCmt(SAM, Quantity);
                    objCosting.OB_WS = Convert.ToInt32(outParam2.Value);
                    objCosting.Total_Made = Convert.ToInt32(outParam3.Value);

                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
                //catch (Exception ex)
                //{
                //    transaction.Rollback();
                //}
            }
            string[] returnString = new string[] { objCosting.CMT.ToString(), objCosting.OB_WS.ToString(), objCosting.Total_Made.ToString() };
            return returnString;
        }
        //added by abhishek on 3/5/2017
        public int GetCostingCmt(double SAM, int Quantity)
        {
            DataTable dt = new DataTable();
            int res = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetCmtExpectedQty_Costing";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Sam", SqlDbType.Float);
                param.Value = SAM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExpectedAmt", SqlDbType.Int);
                param.Value = Quantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

                res = Convert.ToInt32(dt.Rows[0]["Cmt"]);
                return res;
            }
        }

        public List<Costing> GetClientCostingBy(int ClientId, int DeptId)
        {

            //Costing objCosting = new Costing();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                List<Costing> liCost = new List<Costing>();

                string cmdText = "sp_costing_get_client_costing_By_Client_Dept";

                cnx.Open();



                SqlCommand cmd = new SqlCommand(cmdText, cnx);

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



                DataTable dtCost = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dtCost);

                foreach (DataRow dtRow in dtCost.Rows)
                {

                    Costing objCosting = new Costing();



                    objCosting.CommisionPercent = Convert.ToDouble(dtCost.Rows[0]["COMMISION"]);

                    objCosting.ConvertTo = Convert.ToInt32(dtCost.Rows[0]["CONVERSIONTO"]);

                    objCosting.Finish = Convert.ToDouble(dtCost.Rows[0]["COFFIN_BOX"]);

                    objCosting.HANGER_LOOPS = Convert.ToDouble(dtCost.Rows[0]["HANGERLOOPS"]);

                    objCosting.LBL_TAGS = Convert.ToDouble(dtCost.Rows[0]["LBL_TAGS"]);

                    objCosting.MarkupOnUnitCTC = Convert.ToDouble(dtCost.Rows[0]["PROFITMARGIN"]);

                    objCosting.TEST = Convert.ToDouble(dtCost.Rows[0]["TEST"]);

                    objCosting.OverHead = Convert.ToDouble(dtCost.Rows[0]["OVERHEADCOST"]);

                    objCosting.Hangers = Convert.ToDouble(dtCost.Rows[0]["HANGERS"]);

                    objCosting.DesignCommission = Convert.ToDouble(dtCost.Rows[0]["DESIGNCOMM"]);

                    objCosting.Achivement = Convert.ToInt32(dtCost.Rows[0]["ACHIEVEMENT"]);

                    objCosting.ExpectedQty = Convert.ToInt32(dtCost.Rows[0]["EXPECTEDQTY"]);
                    objCosting.FrieghtUptoPort = Convert.ToDouble(dtCost.Rows[0]["FRTUPTOPORT"]);

                    objCosting.CostingWaste = Convert.ToInt32(dtCost.Rows[0]["Costing_waste"]);
                    objCosting.MinOverHead = Convert.ToInt32(dtCost.Rows[0]["MinOverHead"]);
                    objCosting.MaxOverHead = Convert.ToInt32(dtCost.Rows[0]["MaxOverHead"]);
                    objCosting.MinCMT = Convert.ToInt32(dtCost.Rows[0]["MinCMT"]);
                    objCosting.MinProfit = Convert.ToInt32(dtCost.Rows[0]["MinProfit"]);
                    objCosting.OHValue_ForPercent = Convert.ToInt32(dtCost.Rows[0]["OHValue_ForPercent"]);
                    objCosting.OHPercent = Convert.ToInt32(dtCost.Rows[0]["OHPercent"]);
                    objCosting.ApplicableCoffinBox = dtCost.Rows[0]["ApplicableCoffinBox"].ToString();
                    //objCosting.Fabric_Adj_Price = Convert.ToInt32(dtCost.Rows[0]["Fabric_Adj_Price"]);
                    //objCosting.Acc_Adj_Price = Convert.ToInt32(dtCost.Rows[0]["Acc_Adj_Price"]);
               

                    liCost.Add(objCosting);



                }



                return liCost;



            }



        }
        public List<Costing> GetWastage(int ExpectedQty)
        {

            //Costing objCosting = new Costing();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                List<Costing> liCost = new List<Costing>();

                string cmdText = "sp_Get_Wastage";

                cnx.Open();



                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



                SqlParameter param;



                param = new SqlParameter("@ExpectedQty", SqlDbType.Int);

                param.Value = ExpectedQty;

                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);



               


                DataTable dtCost = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dtCost);

                foreach (DataRow dtRow in dtCost.Rows)
                {

                    Costing objCosting = new Costing();



                    
                    objCosting.WastageQty = dtCost.Rows[0]["Wastage"].ToString();
                    //objCosting.Fabric_Adj_Price = Convert.ToInt32(dtCost.Rows[0]["Fabric_Adj_Price"]);
                    //objCosting.Acc_Adj_Price = Convert.ToInt32(dtCost.Rows[0]["Acc_Adj_Price"]);


                    liCost.Add(objCosting);



                }



                return liCost;



            }



        }

        //public string[] GetClient_Costing_ByClient(int ClientId, int DeptId)
        //{
        //    Costing objCosting = new Costing();

        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {

        //        try
        //        {
        //            string cmdText = "sp_costing_get_client_costing_By_Client_Dept";
        //            cnx.Open();                  

        //            SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        //            SqlParameter param;

        //            param = new SqlParameter("@ClientId", SqlDbType.Int);
        //            param.Value = ClientId;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@DeptId", SqlDbType.Int);
        //            param.Value = DeptId;
        //            param.Direction = ParameterDirection.Input;
        //            cmd.Parameters.Add(param);

        //            DataTable dtCost = new DataTable();
        //            SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //            sda.Fill(dtCost);

        //            if(dtCost.Rows.Count > 0)
        //            {
        //                objCosting.CommisionPercent = Convert.ToDouble(dtCost.Rows[0]["COMMISION"]);
        //                objCosting.ConvertTo = Convert.ToInt32(dtCost.Rows[0]["CONVERSIONTO"]);
        //                objCosting.Finish = Convert.ToDouble(dtCost.Rows[0]["COFFIN_BOX"]);
        //                objCosting.HANGER_LOOPS = Convert.ToDouble(dtCost.Rows[0]["HANGERLOOPS"]);
        //                objCosting.LBL_TAGS = Convert.ToDouble(dtCost.Rows[0]["LBL_TAGS"]);
        //                objCosting.MarkupOnUnitCTC = Convert.ToDouble(dtCost.Rows[0]["PROFITMARGIN"]);
        //                objCosting.TEST = Convert.ToDouble(dtCost.Rows[0]["TEST"]);
        //                objCosting.OverHead = Convert.ToDouble(dtCost.Rows[0]["OVERHEADCOST"]);
        //                objCosting.Hangers = Convert.ToDouble(dtCost.Rows[0]["HANGERS"]);
        //                objCosting.DesignCommission = Convert.ToDouble(dtCost.Rows[0]["DESIGNCOMM"]);
        //                objCosting.Achivement = Convert.ToInt32(dtCost.Rows[0]["ACHIEVEMENT"]);
        //                objCosting.ExpectedQty = Convert.ToInt32(dtCost.Rows[0]["EXPECTEDQTY"]);

        //         }


        //        }
        //        catch (SqlException ex)
        //        {

        //        }

        //    }
        //    string[] returnString = new string[] { objCosting.CommisionPercent.ToString(), objCosting.ConvertTo.ToString(), objCosting.Finish.ToString(), objCosting.HANGER_LOOPS.ToString(), objCosting.LBL_TAGS.ToString(), objCosting.MarkupOnUnitCTC.ToString(), objCosting.TEST.ToString(), objCosting.OverHead.ToString(), objCosting.Hangers.ToString(), objCosting.DesignCommission.ToString(), objCosting.Achivement.ToString(), objCosting.ExpectedQty.ToString() };
        //    return returnString;
        //}


        public int SaveClientCostingDefault(int ClientId, int DeptID, double commission, int Conversion, double coffinbox, double Hangerloops, double lblTags, double OverHeadcost, double ProfitMargin, double Test, double Hangers, double DesignCommision, int Achievement, double ExpectedQuantity, double frtUptoport, int CreatedBy)
        {
            int i = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    string cmdText = "sp_costing_client_default_Update";

                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param;

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptId", SqlDbType.Int);
                    param.Value = DeptID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@COMMISION", SqlDbType.Float);
                    param.Value = commission;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CONVERSIONTO", SqlDbType.Int);
                    param.Value = Conversion;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@COFFIN_BOX", SqlDbType.Float);
                    param.Value = coffinbox;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HANGERLOOPS", SqlDbType.Float);
                    param.Value = Hangerloops;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@lblTags", SqlDbType.Float);
                    param.Value = lblTags;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OVERHEADCOST", SqlDbType.Float);
                    param.Value = OverHeadcost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PROFITMARGIN", SqlDbType.Float);
                    param.Value = ProfitMargin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TEST", SqlDbType.Float);
                    param.Value = Test;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HANGERS", SqlDbType.Float);
                    param.Value = Hangers;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DESIGNCOMM", SqlDbType.Float);
                    param.Value = DesignCommision;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ACHIEVEMENT", SqlDbType.Int);
                    param.Value = Achievement;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@EXPECTEDQTY", SqlDbType.Float);
                    param.Value = ExpectedQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FRTUPTOPORT", SqlDbType.Float);
                    param.Value = frtUptoport;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CREATEDBY", SqlDbType.Int);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    i = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }

            }
            return i;
        }

        public string UpdateClientCostingValues_ByClient(int ClientId, int DeptId, int HeaderNo, double Values )
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();
                string RetVal = string.Empty;
                SqlCommand cmd;
                string cmdText, sReturn = "";

                cmdText = "usp_UpdateClientCostingValues_ByClient";
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

                param = new SqlParameter("@HeaderNo", SqlDbType.Int);
                param.Value = HeaderNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Values", SqlDbType.Float);
                param.Value = Values;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MSG", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);


                //intReturn = cmd.ExecuteNonQuery();
                //RetVal = cmd.Parameters["@Output"].Value.ToString();
                //cnx.Close();


                int i = cmd.ExecuteNonQuery();
                RetVal = cmd.Parameters["@MSG"].Value.ToString();
                if (RetVal == "" && i > 0)
                {
                    RetVal = "This has been updated successfully!";
                }
                sReturn = RetVal.ToString();

                return sReturn;

            }
        }

        public string UpdateExpectedByClient(int ClientId, int DeptId, int ExpectedQuantity)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText, sReturn = "";

                cmdText = "usp_UpdateExpected_ByClient";
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

                param = new SqlParameter("@Achievement", SqlDbType.Int);
                param.Value = ExpectedQuantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                int i = cmd.ExecuteNonQuery();
                sReturn = i.ToString();

                return sReturn;

            }
        }

        #endregion

        public int Check_UpdateBiplPrice_ShowHide(int CostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                int checkshowhide = 0;
                string cmdText;
                cmdText = "usp_Check_UpdateBiplPrice_ShowHide";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                //cmd.CommandTimeout = 6000;
                SqlParameter param = new SqlParameter("@CostingID", SqlDbType.Int);
                param.Value = CostingID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    checkshowhide = Convert.ToInt32(obj);
                }

                return checkshowhide;

            }
        }

        // Add By Ravi for notification in Costing
        public DataTable Get_OrderDetailBy_StyleId(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Get_OrderDetailBy_StyleId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtOrder = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtOrder);

                return dtOrder;
            }
        }

        public int UpdateBIPLPrice(int OrderId, float AgreedPrice)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_UpdateBIPLOrderPrice";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BIPLPrice", SqlDbType.Float);
                param.Value = AgreedPrice;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Userid", SqlDbType.Int);
                param.Value = this.LoggedInUser.UserData.UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
                return 1;
            }
        }
        public int UpdateIkandiPrice(int OrderId, float AgreedPrice)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_UpdateIkandiOrderPrice";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BIPLPrice", SqlDbType.Float);
                param.Value = AgreedPrice;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = this.LoggedInUser.UserData.FullName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
                return 1;
            }
        }
        public int UpdateFabric_Color_Print(int OrderId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_UpdateFabric_Color_Print";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

               
                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
                return 1;
            }
        }
        //abhishek 18/9/2017
        public List<Costing> GetExpWastageQty(int ClientId, int DeptId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                List<Costing> liCost = new List<Costing>();

                string cmdText = "Usp_GetExpectedWastedQty";

                cnx.Open();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);

                param.Value = ClientId;

                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptId;

                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
               
                DataSet ds = new DataSet();
                DataTable dtCost = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtCost);
                var i = 0;
                foreach (DataRow dtRow in dtCost.Rows)
                {
                    Costing objCosting = new Costing();
                    objCosting.WastageID = Convert.ToInt32(dtCost.Rows[i]["WastageID"]);
                    objCosting.ExpectedID = Convert.ToInt32(dtCost.Rows[i]["ExpectedID"]);
                    objCosting.WastageQty = Convert.ToString(dtCost.Rows[i]["Qty"]);
                    liCost.Add(objCosting);
                    i++;
                }



                return liCost;



            }



        }



        public List<Costing> GetStyleNumber_From_Order(string MOid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                List<Costing> liCost = new List<Costing>();

                string cmdText = "Usp_GetStylenumberFrom_MOParameter";

                cnx.Open();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@MOid", SqlDbType.VarChar);

                param.Value = MOid;

                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

              

                DataSet ds = new DataSet();
                DataTable dtCost = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtCost);
                var i = 0;
                foreach (DataRow dtRow in dtCost.Rows)
                {
                    Costing objCosting = new Costing();
                    objCosting.StyleNumber = Convert.ToString(dtCost.Rows[i]["StyleNumber"]);
                 
                    liCost.Add(objCosting);
                    i++;
                }



                return liCost;



            }



        }
        //add code by bhrarat on 1-27-2020 
        public string SaveLikeCountProduct(int PStyleId, int PCount)
        {
            var Isave1 = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_LikeCount_Garment";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@PStyleId", SqlDbType.Int);
                param.Value = PStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PCount", SqlDbType.Int);
                param.Value = PCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave1 = cmd.ExecuteNonQuery();
            }
            return Isave1.ToString();

        }

        //add code by bhrarat on 1-27-2020 
        public string CheckCancelPO(int OrderDetailId)
        {
            int Isave1=0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_Cancelled_Validation";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@OrderDetailid", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                //Isave1 = cmd.ExecuteNonQuery();
                Isave1 = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return Isave1.ToString();

        }
        //add code by bhrarat on 1-27-2020 
        public string SaveLikeCountProductDetails(int PDStyleId, int PDeCount)
        {
            var Isave1 = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_LikeCount_Garment";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@PStyleId", SqlDbType.Int);
                param.Value = PDStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PCount", SqlDbType.Int);
                param.Value = PDeCount;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave1 = cmd.ExecuteNonQuery();
            }
            return Isave1.ToString();

        }
        public string UpdateClientCostingValues_ByClient_ApplicableCoffinBox(int ClientId, int DeptId, int HeaderNo, string Values)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();
                string RetVal = string.Empty;
                SqlCommand cmd;
                string cmdText, sReturn = "";

                cmdText = "usp_UpdateClientCostingValues_ByClient_ApplicableCoffinBox";
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

                param = new SqlParameter("@HeaderNo", SqlDbType.Int);
                param.Value = HeaderNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Values", SqlDbType.VarChar);
                param.Value = Values;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MSG", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);


                //intReturn = cmd.ExecuteNonQuery();
                //RetVal = cmd.Parameters["@Output"].Value.ToString();
                //cnx.Close();


                int i = cmd.ExecuteNonQuery();
                RetVal = cmd.Parameters["@MSG"].Value.ToString();
                if (RetVal == "" && i > 0)
                {
                    RetVal = "This has been updated successfully!";
                }
                sReturn = RetVal.ToString();

                return sReturn;

            }
        }

        //End Of Code



       


       
    }
}