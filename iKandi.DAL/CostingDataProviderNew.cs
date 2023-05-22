using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;

namespace iKandi.DAL
{
    public class CostingDataProviderNew : BaseDataProvider
    {
        #region Ctor(s)

        public CostingDataProviderNew(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insertion Methods

        public int InsertCosting_New(Costing objCosting, int Role)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_costing_insert_costing_New";
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

                    param = new SqlParameter("@SAM", SqlDbType.Float);
                    param.Value = objCosting.SAM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CMT", SqlDbType.Float);
                    param.Value = objCosting.CMTF;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingCutWastage", SqlDbType.Float);
                    param.Value = objCosting.CostingCutWastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingVAWastage", SqlDbType.Float);
                    param.Value = objCosting.CostingVAWastage;
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
            }

            return -1;
        }
        public void OpenCosing(int styleid, int IsCostingOpen, int Userid)
        {
            SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING);
            string cmdText = "sp_costing_insert_Open_Costing";
            cnx.Open();
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;
            param = new SqlParameter("@Styleid", SqlDbType.Int);
            param.Value = styleid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsCostingOpen", SqlDbType.Int);
            param.Value = IsCostingOpen;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Value = Userid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            cnx.Close();

        }




        private bool InsertFabricCosting_New(FabricCosting objFabricCosting, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fabric_costing_insert_fabric_costing_New";

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


            param = new SqlParameter("@FabricQualityID", SqlDbType.VarChar, 500);
            param.Value = objFabricCosting.FabricQualityId.Trim();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabTypeId", SqlDbType.Int);
            param.Value = objFabricCosting.FabTypeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ResidualShrinkage", SqlDbType.Float);
            param.Value = objFabricCosting.ResidualShrinkage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GSM", SqlDbType.Float);
            param.Value = objFabricCosting.GSM;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DyedRate", SqlDbType.Float);
            param.Value = objFabricCosting.DyedRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PrintRate", SqlDbType.Float);
            param.Value = objFabricCosting.PrintRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DgtlRate", SqlDbType.Float);
            param.Value = objFabricCosting.DigitalPrintRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostWidth", SqlDbType.Float);
            param.Value = objFabricCosting.CostWidth;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CountConstruct", SqlDbType.VarChar, 500);
            param.Value = objFabricCosting.CountConstruct;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Added by Ravi kumar on 3 Feb 2020
            param = new SqlParameter("@ValueAdditionId1", SqlDbType.Int);
            if (objFabricCosting.ValueAdditionId1 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.ValueAdditionId1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ValueAdditionId2", SqlDbType.Int);
            if (objFabricCosting.ValueAdditionId2 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.ValueAdditionId2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VAWastage1", SqlDbType.Float);
            if (objFabricCosting.VAWastage1 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VAWastage1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VAWastage2", SqlDbType.Float);
            if (objFabricCosting.VAWastage2 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VAWastage2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VARate1", SqlDbType.Float);
            if (objFabricCosting.VARate1 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VARate1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VARate2", SqlDbType.Float);
            if (objFabricCosting.VARate2 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VARate2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int fabricCostingID = Convert.ToInt32(outParam.Value);

            return true;
        }

        public int UpdateFabQuality_New(string[] tradeName, string[] count, double[] gsm)
        {
            SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING);
            string cmdText = "sp_style_update_fabQuality_New";
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

        private bool InsertAccessories_New(Accessories objAccessories, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_accessories_insert_accessories_New";

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

            param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
            param.Value = objAccessories.AccessoryQualityID == "" ? "-1" : objAccessories.AccessoryQualityID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Wastage", SqlDbType.Float);
            param.Value = objAccessories.Wastage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsDefaultAccessory", SqlDbType.Int);
            param.Value = objAccessories.IsDefaultAccessory;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int accessoryId = Convert.ToInt32(outParam.Value);

            return true;
        }

        private bool InsertCharges_New(Charges objCharges, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_charges_insert_charges_New";

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

        private bool InsertLandedCosting_New(LandedCosting objLandedCosting, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_landed_costing_insert_landed_costing_New";

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
            param.Value = objLandedCosting.ProcessCost;
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
            param.Value = DBNull.Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CalculatedDeliveryDate", SqlDbType.DateTime);
            param.Value = DBNull.Value;
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

            param = new SqlParameter("@ModeCostId", SqlDbType.Int);
            param.Value = objLandedCosting.ModeCostID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProcessCostId", SqlDbType.Int);
            param.Value = objLandedCosting.ProcessCostId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeId", SqlDbType.Int);
            param.Value = objLandedCosting.ModeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int landedCostingId = Convert.ToInt32(outParam.Value);
            return true;
        }

        private bool InsertFOBPricing_New(FOBPricing objFOBPricing, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fob_pricing_insert_fob_pricing_New";

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
            param.Value = DBNull.Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CalculatedDeliveryDate", SqlDbType.DateTime);
            param.Value = DBNull.Value;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objFOBPricing.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModeId", SqlDbType.Int);
            param.Value = objFOBPricing.ModeId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SequenceNumber", SqlDbType.Int);
            param.Value = objFOBPricing.SequenceNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            int fobPricingId = Convert.ToInt32(outParam.Value);

            return true;
        }

        private bool InsertCommentHistory_New(CommentHistory objCommentHistory, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "Usp_Insert_Costing_Comment_History";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;

            param = new SqlParameter("@CostingID", SqlDbType.Int);
            param.Value = objCommentHistory.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TypeFlag", SqlDbType.Int);
            param.Value = objCommentHistory.TypeFlag;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FieldName", SqlDbType.VarChar);
            param.Value = objCommentHistory.FieldName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OldValue", SqlDbType.VarChar);
            param.Value = objCommentHistory.OldValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NewValue", SqlDbType.VarChar);
            param.Value = objCommentHistory.NewValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UpdatedByUserId", SqlDbType.Int);
            param.Value = objCommentHistory.UpdatedByUserId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
            param.Value = objCommentHistory.UpdatedOn;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DetailDescription", SqlDbType.VarChar);
            param.Value = objCommentHistory.DetailDescription;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Isbipl", SqlDbType.Bit);
            param.Value = objCommentHistory.isBipl;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsPriceQuote", SqlDbType.Bit);
            param.Value = objCommentHistory.isPriceQuote;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool InsertProcesses_New(Processes objProcesses, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "Costing_ProcessInsert";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@ProcessCostingId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@ValueAdditionID", SqlDbType.Float);
            param.Value = objProcesses.ValueAdditionID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objProcesses.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Float);
            param.Value = objProcesses.Amount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SeqNo", SqlDbType.Int);
            param.Value = objProcesses.SeqNo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objProcesses.Rate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Wastage", SqlDbType.Float);
            param.Value = objProcesses.Wastage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

            int processId = Convert.ToInt32(outParam.Value);

            return true;
        }


        private bool UpdateTotalCost_New(Int64 CostingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_update_costing_totalprice_New";

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

        public bool UpdateCosting_New(Costing objCosting, int Role)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_costing_update_costing_New";
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

                    param = new SqlParameter("@SAM", SqlDbType.Float);
                    param.Value = objCosting.SAM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CMT", SqlDbType.Float);
                    param.Value = objCosting.CMTF;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingCutWastage", SqlDbType.Float);
                    param.Value = objCosting.CostingCutWastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingVAWastage", SqlDbType.Float);
                    param.Value = objCosting.CostingVAWastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    SaveCosting(objCosting, cnx, transaction, true, Role);

                    transaction.Commit();
                    return true;
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
            }

            return false;
        }

        public bool Remove_Costing_Agreement_from_IKandi_User_When_NoChange_Exists(int StyleId, int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "Remove_Costing_Agreement_from_IKandi_User_When_NoChange_Exists";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd =new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;
                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserID;
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
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                }
            }

            return false;
        }

        private bool UpdateFabricCosting_New(FabricCosting objFabricCosting, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fabric_costing_update_fabric_costing_New";

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

            param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
            param.Value = objFabricCosting.FabricQualityId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SupplyType", SqlDbType.Int);
            param.Value = objFabricCosting.SupplyType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ResidualShrinkage", SqlDbType.Float);
            param.Value = objFabricCosting.ResidualShrinkage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // Added by Ravi kumar on 3 Feb 2020
            param = new SqlParameter("@ValueAdditionId1", SqlDbType.Int);
            if (objFabricCosting.ValueAdditionId1 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.ValueAdditionId1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ValueAdditionId2", SqlDbType.Int);
            if (objFabricCosting.ValueAdditionId2 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.ValueAdditionId2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VAWastage1", SqlDbType.Float);
            if (objFabricCosting.VAWastage1 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VAWastage1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VAWastage2", SqlDbType.Float);
            if (objFabricCosting.VAWastage2 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VAWastage2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VARate1", SqlDbType.Float);
            if (objFabricCosting.VARate1 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VARate1;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@VARate2", SqlDbType.Float);
            if (objFabricCosting.VARate2 <= 0)
                param.Value = DBNull.Value;
            else
                param.Value = objFabricCosting.VARate2;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        private bool UpdateAccessories_New(Accessories objAccessories, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_accessories_update_accessories_New";

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

            param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
            param.Value = objAccessories.AccessoryQualityID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Wastage", SqlDbType.Float);
            param.Value = objAccessories.Wastage;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();

            return true;
        }

        private bool UpdateCharges_New(Charges objCharges, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_charges_update_charges_New";

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

        private bool UpdateLandedCosting_New(LandedCosting objLandedCosting, SqlConnection cnx, SqlTransaction transaction)
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
            param.Value = objLandedCosting.ProcessCost;
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

        private bool UpdateFOBPricing_New(FOBPricing objFOBPricing, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fob_pricing_update_fob_pricing_New";

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

        private bool UpdateProcesses_New(Processes objProcesses, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "Costing_ProcessUpdate";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@ProcessCostingId", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ValueAdditionID", SqlDbType.Float);
            param.Value = objProcesses.ValueAdditionID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingId", SqlDbType.Int);
            param.Value = objProcesses.CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Float);
            param.Value = objProcesses.Amount;
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
                        InsertFabricCosting_New(objFabricCosting, cnx, transaction);
                    else if (objFabricCosting.CostingQueryType == QueryType.Update)
                        UpdateFabricCosting_New(objFabricCosting, cnx, transaction);
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
                        InsertAccessories_New(objAccessories, cnx, transaction);
                    else if (objAccessories.CostingQueryType == QueryType.Update)
                        UpdateAccessories_New(objAccessories, cnx, transaction);
                    else if (isUpdation)
                        DeleteAccessories(objAccessories.AccessoryID, cnx, transaction);
                }
            }

            if (null != objCosting.ProcessItems && objCosting.ProcessItems.Count > 0)
            {
                foreach (Processes objProcesses in objCosting.ProcessItems)
                {
                    objProcesses.CostingID = objCosting.CostingID;
                    if (objProcesses.CostingQueryType == QueryType.Insert)
                        InsertProcesses_New(objProcesses, cnx, transaction);
                    else if (objProcesses.CostingQueryType == QueryType.Update)
                        UpdateProcesses_New(objProcesses, cnx, transaction);
                    else if (isUpdation)
                        DeleteProcesses(objProcesses.ProcessCostingId, cnx, transaction);
                }
            }

            if (null != objCosting.ChargesItems && objCosting.ChargesItems.Count > 0)
            {
                foreach (Charges objcharges in objCosting.ChargesItems)
                {
                    objcharges.CostingID = objCosting.CostingID;

                    if (objcharges.CostingQueryType == QueryType.Insert)
                        InsertCharges_New(objcharges, cnx, transaction);
                    else if (objcharges.CostingQueryType == QueryType.Update)
                        UpdateCharges_New(objcharges, cnx, transaction);
                    else if (isUpdation)
                        DeleteCharges(objcharges.ChargeID, cnx, transaction);
                }
            }

            if (null != objCosting.LandedCostingItems && objCosting.LandedCostingItems.Count > 0)
            {
                foreach (LandedCosting objLandedCosting in objCosting.LandedCostingItems)
                {
                    objLandedCosting.CostingID = objCosting.CostingID;

                    if (objLandedCosting.CostingQueryType == QueryType.Insert)
                        InsertLandedCosting_New(objLandedCosting, cnx, transaction);
                    else if (objLandedCosting.CostingQueryType == QueryType.Update)
                        UpdateLandedCosting_New(objLandedCosting, cnx, transaction);
                    else if (isUpdation)
                        DeleteLandedCosting(objLandedCosting.LandedCostingID, cnx, transaction);
                }
            }

            if (null != objCosting.FOBPricingItemNew && objCosting.FOBPricingItemNew.Count > 0)
            {
                foreach (FOBPricing objFobCosting in objCosting.FOBPricingItemNew)
                {
                    objFobCosting.CostingID = objCosting.CostingID;

                    if (objFobCosting.CostingQueryType == QueryType.Insert)
                        InsertFOBPricing_New(objFobCosting, cnx, transaction);
                    else if (objFobCosting.CostingQueryType == QueryType.Update)
                        UpdateFOBPricing_New(objFobCosting, cnx, transaction);
                }
            }

            if (null != objCosting.CommetHistoryItems && objCosting.CommetHistoryItems.Count > 0)
            {
                foreach (CommentHistory objCommentHistory in objCosting.CommetHistoryItems)
                {
                    objCommentHistory.CostingID = objCosting.CostingID;
                    InsertCommentHistory_New(objCommentHistory, cnx, transaction);
                }
            }
            UpdateTotalCost_New(objCosting.CostingID, cnx, transaction);

            //Delete Accessory from Order Form if exist

            if (null != objCosting.DeleteAccessoriesItem && objCosting.DeleteAccessoriesItem.Count > 0)
            {
                foreach (DeleteAccessoris objAccess in objCosting.DeleteAccessoriesItem)
                {
                    DeleteOrderAccessories_FromCosting(objAccess, cnx, transaction, objCosting.StyleID,objCosting.CostingID,Role);
                }
            }

            //Update Fabric and Accessory from Order Form if exist
            Update_Fabric_Accessories_FromCosting(cnx, transaction, objCosting.StyleID);
        }

        private bool DeleteCostingChildTableData(int costingId, SqlConnection cnx, SqlTransaction transaction, int Role)
        {
            string cmdText = "sp_costing_delete_from_costing_child_tables_by_costing_id_New";

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

            SqlParameter outParam = new SqlParameter("@return", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            int i = cmd.ExecuteNonQuery();
            return true;
        }

        private bool DeleteOrderAccessories_FromCosting(DeleteAccessoris objAccess, SqlConnection cnx, SqlTransaction transaction, int StyleId, int CostingID,int Role)
        {
            string cmdText = "sp_DeleteOrderAccessories_FromCosting";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
            param.Value = StyleId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
            param.Value = objAccess.AccessoryQualitySizeID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
            param.Value = objAccess.AccessoryMasterId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoriesName", SqlDbType.VarChar);
            param.Value = objAccess.AccessoryName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CostingID", SqlDbType.Int);
            param.Value = CostingID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Role", SqlDbType.Int);
            param.Value = Role;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
           
            return true;
        }

        private bool Update_Fabric_Accessories_FromCosting(SqlConnection cnx, SqlTransaction transaction, int StyleId)
        {
            string cmdText = "usp_Update_Fabric_Accessories_FromCosting";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
            param.Value = StyleId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        #endregion

        #region Deletion Methods

        private bool DeleteFabricCosting(int fabricCostingId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_fabric_costing_delete_fabric_costing_by_id_New";

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
            string cmdText = "sp_accessories_delete_accessories_by_id_New";

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
            string cmdText = "sp_charges_delete_charges_by_id_New";

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
            string cmdText = "sp_landed_costing_delete_landed_costing_by_id_New";

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

        private bool DeleteProcesses(string processId, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "Costing_delete_Process_by_id";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter param = new SqlParameter("@ProcessCostingId", SqlDbType.Int);
            param.Value = processId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            return true;
        }

        #endregion

        #region Read Methods

        public CostingCollection GetCosting_New(int costingId)
        {
            CostingCollection objCostingCollection = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_costing_get_all_costing_New";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Value = costingId;
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

                objCosting.Quantity = (dt.Rows[0]["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["Quantity"]);
                objCosting.Weight = (dt.Rows[0]["Weight"] == DBNull.Value) ? 0 : Convert.ToDecimal(dt.Rows[0]["Weight"]);
                objCosting.ParentCostingID = (dt.Rows[0]["ParentCostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["ParentCostingId"]);
                objCosting.PrintIds = (dt.Rows[0]["PrintIds"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["PrintIds"]);
                objCosting.AgreedPrice = (dt.Rows[0]["AgreedPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["AgreedPrice"]);
                objCosting.CurrencySymbol = (dt.Rows[0]["CurrencySymbol"] == DBNull.Value) ? string.Empty : Convert.ToString(dt.Rows[0]["CurrencySymbol"]);

                objCosting.PriceQuoted = (dt.Rows[0]["PriceQuoted"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["PriceQuoted"]);

                objCosting.FrieghtUptoFinalDestination = (dt.Rows[0]["FrieghtUptoFinalDestination"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["FrieghtUptoFinalDestination"]);
                objCosting.FrieghtUptoPort = (dt.Rows[0]["FrieghtUptoPort"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["FrieghtUptoPort"]);
                objCosting.FincCost = (dt.Rows[0]["FincCost"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["FincCost"]);
                objCosting.DirectCost = (dt.Rows[0]["DirectCost"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["DirectCost"]);

                objCosting.ConvertTo = (dt.Rows[0]["ConvertTo"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["ConvertTo"]);
                objCosting.MarkupOnUnitCTC = (dt.Rows[0]["MarkupOnUnitCTC"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["MarkupOnUnitCTC"]);
                objCosting.CommisionPercent = (dt.Rows[0]["CommisionPercent"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["CommisionPercent"]);
                objCosting.ConversionRate = (dt.Rows[0]["ConversionRate"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["ConversionRate"]);
                objCosting.DefaultConversionRate = (dt.Rows[0]["DefaultConversionRate"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["DefaultConversionRate"]);

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

                objCosting.CreatedOn = (dt.Rows[0]["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);

                objCosting.OverHead = (dt.Rows[0]["OverHeadQty"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["OverHeadQty"]);

                objCosting.DesignCommission = (dt.Rows[0]["DesignCommission"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["DesignCommission"]);
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

                objCosting.SAM = (dt.Rows[0]["SAM"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["SAM"]);
                objCosting.CMTF = (dt.Rows[0]["CMT"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["CMT"]);
                objCosting.CostingCutWastage = (dt.Rows[0]["CostingCutWastage"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["CostingCutWastage"]);
                objCosting.CostingVAWastage = (dt.Rows[0]["CostingVAWastage"] == DBNull.Value) ? 0 : Convert.ToDouble(dt.Rows[0]["CostingVAWastage"]);
                // Added by Ravi kumar on 6/1/2015
                objCosting.CostingTask = (dt.Rows[0]["CostingTask"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["CostingTask"]);
                objCosting.Weight_ReadOnly = (dt.Rows[0]["Weight_ReadOnly"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["Weight_ReadOnly"]);
                objCosting.ActionBy = (dt.Rows[0]["ActionBy"] == DBNull.Value) ? "" : dt.Rows[0]["ActionBy"].ToString();
                objCosting.IsOrderConfirmed = (dt.Rows[0]["IsOrderConfirm"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["IsOrderConfirm"]);
                objCosting.IsCostingOpen = (dt.Rows[0]["IsCostingOpen"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["IsCostingOpen"]);
                
                //objCosting.Disabled_ACC = (dt.Rows[0]["Disabled_ACC"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["Disabled_ACC"]);
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
                    var X = 0.0; var Y = 0.0;
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
                    //objFabricCosting.SupplierName = (dr["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SupplierName"]);
                    objFabricCosting.ResidualShrinkage = (dr["ResidualShrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["ResidualShrinkage"]);
                    objFabricCosting.FabricQualityId = dr["FabricQualityId"] == DBNull.Value ? "0" : dr["FabricQualityId"].ToString();
                    objFabricCosting.GSM = dr["GSM"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GSM"].ToString());
                    objFabricCosting.DyedRate = dr["DyedRate"] == DBNull.Value ? 0 : Convert.ToDouble(dr["DyedRate"].ToString());
                    objFabricCosting.PrintRate = dr["PrintRate"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PrintRate"].ToString());
                    objFabricCosting.DigitalPrintRate = dr["DgtlRate"] == DBNull.Value ? 0 : Convert.ToDouble(dr["DgtlRate"].ToString());
                    objFabricCosting.CountConstruct = dr["CountConstruct"] == DBNull.Value ? "" : dr["CountConstruct"].ToString();
                    objFabricCosting.CostWidth = dr["CostWidth"] == DBNull.Value ? 0 : Convert.ToDouble(dr["CostWidth"].ToString());
                    objFabricCosting.FabTypeId = dr["FabTypeId"] == DBNull.Value ? "0" : dr["FabTypeId"].ToString();
                    //objCosting.Disabled_Fabric = (dt.Rows[0]["Disabled_Fabric"] == DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0]["Disabled_Fabric"]);
                    objFabricCosting.Disabled_Fabric = Convert.ToBoolean(dr["Disabled_Fabric"]);
                    objFabricCosting.ValueAdditionId1 = (dr["ValueAdditionID1"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["ValueAdditionID1"]);
                    objFabricCosting.ValueAdditionId2 = (dr["ValueAdditionID2"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["ValueAdditionID2"]);
                    objFabricCosting.VAWastage1 = dr["VA_Wastage1"] == DBNull.Value ? 0 : Convert.ToDouble(dr["VA_Wastage1"].ToString());
                    objFabricCosting.VAWastage2 = dr["VA_Wastage2"] == DBNull.Value ? 0 : Convert.ToDouble(dr["VA_Wastage2"].ToString());
                    objFabricCosting.VARate1 = dr["VA_Rate1"] == DBNull.Value ? 0 : Convert.ToDouble(dr["VA_Rate1"].ToString());
                    objFabricCosting.VARate2 = dr["VA_Rate2"] == DBNull.Value ? 0 : Convert.ToDouble(dr["VA_Rate2"].ToString());

                    X = objFabricCosting.Amount;
                    Y = objFabricCosting.Average;

                    objFabricCosting.Total = X;
                    objFabricCosting.TotalFabric = (Y); //K
                    objFabricCosting.TotalPrice = Math.Round(X);//L

                    objCosting.FabricCostingItems.Add(objFabricCosting);
                }

                //dt = dsCosting.Tables[2 + accessCounter];
                //objCosting.ChargesItems = new List<Charges>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    Charges objCharges = new Charges();
                //    objCharges.ChargeID = (dr["ChargeId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ChargeId"]);
                //    objCharges.ChargeName = (dr["ChargeName"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ChargeName"]);
                //    objCharges.ChargeValue = (dr["ChargeValue"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["ChargeValue"]);
                //    objCharges.CostingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                //    objCharges.SequenceNumber = (dr["SequenceNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SequenceNumber"]);

                //    objCosting.ChargesItems.Add(objCharges);
                //}

                dt = dsCosting.Tables[2 + accessCounter];
                objCosting.ProcessItems = new List<Processes>();
                foreach (DataRow dr in dt.Rows)
                {
                    Processes objProcess = new Processes();
                    objProcess.ProcessCostingId = (dr["ProcessCostingId"] == DBNull.Value) ? "0" : dr["ProcessCostingId"].ToString();
                    objProcess.Item = (dr["Item"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Item"]);
                    objProcess.Amount = (dr["Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Amount"]);
                    objProcess.ValueAdditionID = (dr["ValueAdditionID"] == DBNull.Value) ? "0" : dr["ValueAdditionID"].ToString();
                    objProcess.FromStatus = dr["FromStatus"] == DBNull.Value ? "" : dr["FromStatus"].ToString();
                    objProcess.ToStatus = dr["ToStatus"] == DBNull.Value ? "" : dr["ToStatus"].ToString();
                    objProcess.SeqNo = dr["SeqNo"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SeqNo"].ToString());
                    objProcess.CostingVAWastage = dr["CostingVAWastage"] == DBNull.Value ? "0" : dr["CostingVAWastage"].ToString();
                    objProcess.Rate = dr["Rate"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Rate"]);
                    objProcess.Wastage = dr["Wastage"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Wastage"]);
                    objCosting.ProcessItems.Add(objProcess);
                }

                dt = dsCosting.Tables[3 + accessCounter];
                objCosting.AccessoryItems = new List<Accessories>();
                foreach (DataRow dr in dt.Rows)
                {
                    Accessories objAccessories = new Accessories();
                    objAccessories.AccessoryID = (dr["AccessoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["AccessoryId"]);
                    objAccessories.Item = (dr["Item"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Item"]);
                    objAccessories.remarks = (dr["remarks"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["remarks"]);
                    objAccessories.Quantity = (dr["Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Quantity"]);
                    objAccessories.Rate = (dr["Rate"] == DBNull.Value) ? 0 : Convert.ToDouble(dr["Rate"]);

                    objAccessories.Amount = Math.Round(objAccessories.Quantity * objAccessories.Rate);
                    objAccessories.CostingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                    objAccessories.SequenceNumber = (dr["SequenceNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SequenceNumber"]);
                    objAccessories.AccessoryPercent = (dr["AccessoryPercent"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["AccessoryPercent"]);
                    objAccessories.AccessoryQualityID = (dr["AccesoriesQualityID"] == DBNull.Value) ? "0" : dr["AccesoriesQualityID"].ToString();

                    objAccessories.Disabled_ACC = Convert.ToBoolean(dr["Disabled_ACC"]);
                    objAccessories.IsDefaultAccessory = (dr["IsDefaultAccessory"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["IsDefaultAccessory"]);
                    objAccessories.ClientId = (dr["ClientId"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["ClientId"]);
                    objAccessories.ParentDepartmentId = (dr["ParentDepartmentId"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["ParentDepartmentId"]);
                    objAccessories.DepartmentId = (dr["DepartmentId"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["DepartmentId"]);

                    objAccessories.TotalPrice = Math.Round(objAccessories.Amount);
                    objAccessories.TotalQuantity = (objAccessories.Quantity);

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
                    objLandedCosting.ModeId = (dr["ModesID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ModesID"]);
                    objLandedCosting.ModeCostID = (dr["ModeCost_ClientCostingDefaultID"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["ModeCost_ClientCostingDefaultID"]);
                    objLandedCosting.ProcessCostId = (dr["ProcessCost_ClientCostingDefault"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["ProcessCost_ClientCostingDefault"]);
                    objLandedCosting.Code = (dr["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Code"]);
                    objLandedCosting.ProcessCost = (dr["Processing"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Processing"]);

                    objCosting.LandedCostingItems.Add(objLandedCosting);
                }

                dt = dsCosting.Tables[5 + accessCounter];
                objCosting.FOBPricingItemNew = new List<FOBPricing>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

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
                        objFOBPricing.ModeId = (dr["ModeId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ModeId"]);
                        objFOBPricing.Code = (dr["Code"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Code"]);
                        objFOBPricing.SequenceNumber = (dr["SequenceNumber"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SequenceNumber"]);

                        objCosting.FOBPricingItemNew.Add(objFOBPricing);
                    }
                }

                objCostingCollection.Add(objCosting);
            }

            return objCostingCollection;
        }
        // edit by surendra technical module
        public bool bCheckOB_New(int styleid)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "sp_CheckSamObValue_TechModule_New";

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
        public CostingCollection GetCostingByStyleNumber_New(string styleNumber, byte isGetMultiple, int SingleVersion)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                if (SingleVersion == 0)
                    cmdText = "sp_costing_get_costing_style_by_style_number_New";
                else
                    cmdText = "sp_costing_get_costing_style_by_style_number_Only_For_SingleVersion_New";
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

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = styleNumber.Trim();
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









        public DataTable GetCostedStyles_New(DateTime CostingDate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_costing_get_costed_styles_New";

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

        public bool DeleteStyleAndCostingSheet_New(int styleId, int costingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_style_delete_style_costing_workflow_by_style_costing_id_New";

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
            }

            return false;
        }
        public bool bCheck_Update_Price_Visibilty_New(int costingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_Check_Update_Order_Price_Visibilty_New";

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
            }

            return false;
        }

        #endregion

        #region Misc Methods

        public bool AgreeForIKandiCostingData_New(int costingId, int parentCostingId, Costing objCosting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    SqlTransaction transaction = null;
                    string cmdText = "sp_costing_agree_for_iKandi_costing_data_New";

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

                    if (null != objCosting.CommetHistoryItems && objCosting.CommetHistoryItems.Count > 0)
                    {
                        foreach (CommentHistory objCommentHistory in objCosting.CommetHistoryItems)
                        {
                            objCommentHistory.CostingID = costingId;
                            InsertCommentHistory_New(objCommentHistory, cnx, transaction);
                        }
                    }

                    return true;
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

            return false;
        }

        public bool DisagreeForIKandiCostingData_New(int costingId, int parentCostingId, Costing objCosting)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    SqlTransaction transaction = null;
                    string cmdText = "sp_costing_disagree_for_iKandi_costing_data_New";

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

                    if (null != objCosting.CommetHistoryItems && objCosting.CommetHistoryItems.Count > 0)
                    {
                        foreach (CommentHistory objCommentHistory in objCosting.CommetHistoryItems)
                        {
                            objCommentHistory.CostingID = parentCostingId;
                            InsertCommentHistory_New(objCommentHistory, cnx, transaction);
                        }
                    }

                    return true;
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

            return false;
        }
        // create by surendra2 on 17-12-2018.
        public double Get_LP_New(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "SELECT [dbo].[fnc_get_Last_OrderPrice](@StyleId)";

                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    object rowCount = cmd.ExecuteScalar();

                    if (null != rowCount)
                        return Convert.ToDouble(rowCount);
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

            return 0;
        }
        public int CheckIfIKandiData_New(int costingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_costing_check_if_iKandi_data_New";

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

            return 0;
        }

        public List<string> GetAllZipDetails_New()
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

        //added by abhishek 26/112/2018
        public DataTable GetClientDeptName(int id, string flag)
        {
            ClientDepartment cDept = new ClientDepartment();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetDeptName";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataTable ds = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }
        //END
        public string GetPriceForGarmentTypeSAM_New(int PutSAM, int ExpectedQty)
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


        public string CostingExpectedQtyDAL_New(int Qty)
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


        public int GetParentCostingID_New(int ChildCostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_parent_costing_id_New";
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
        public int GetClientID_New(int ChildCostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                int iClientID = 0;

                cmdText = "sp_costing_get_parent_costing_id_With_ClientID_New";
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
        public int GetDeptID_New(int ChildCostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;
                int iDeptID = 0;

                cmdText = "sp_costing_get_parent_costing_id_With_DeptID_New";
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

        public string UpdateBIPLPriceOnOrders_New(int CostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_update_bipl_price_in_all_running_orders_New";
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
        public string UpdateiKandiPriceOnOrders_Old_New(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_update_ikandi_price_in_all_running_orders_old_New";
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


        public string UpdateiKandiPriceOnOrders_New(string OrderIds, int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
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


        public string UpdateiKandiPriceOnOrders_New(int CostingID, bool isAF, bool isAH, bool isSF, bool isSH, bool isFOB)
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
        public string GetPriceForGarmentType_New(string GarmentType, int ExpectedQty, string DdlType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_makingprice_New";
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

        public string GetDefaultExpectedQty_New()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                //  cmdText = "sp_costing_get_default_ExpectedQty";
                cmdText = "sp_costing_get_default_ExpectedQty_SAM_New";
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

        public DataTable GetGarmentTypeOption_New(string makingType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_garmentType_options_New";
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

        public DataSet GetExpectedQtyRangewiseDAL_New()
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Get_ExpectedQtyRangewise_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBulkHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsBulkHistory);

                return dsBulkHistory;
            }

        }

        //created by surendra2 on 17-12-2018.
        public DataSet Get_LP_Details_New(int StyleId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "USP_Get_Last_OrderPrice_BreakDown";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBiplHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dsBiplHistory);

                return dsBiplHistory;
            }

        }
        public DataSet GetRegisterFabric_Details(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetRegisterFebric";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBiplHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dsBiplHistory);

                return dsBiplHistory;
            }

        }
        public DataSet GetRegisterAccessory_Details(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetRegisterAccessory";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBiplHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dsBiplHistory);

                return dsBiplHistory;
            }

        }
        public DataSet GetRegisterProcess_Details(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetRegisterProcess";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBiplHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dsBiplHistory);

                return dsBiplHistory;
            }

        }
        public DataSet GetRegisterPrint_Details(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetRegisterPrint";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBiplHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dsBiplHistory);

                return dsBiplHistory;
            }

        }
        public DataSet GetBiplHistory_Details_New(string CostingId, string type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetBiplHistory_Details";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBiplHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                param.Value = CostingId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dsBiplHistory);

                return dsBiplHistory;
            }

        }
        public DataSet GetIkandiHistory_Details_New(string CostingId, string type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetIkandiHistory_Details";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBiplHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                param.Value = CostingId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                adapter.Fill(dsBiplHistory);

                return dsBiplHistory;
            }

        }

        public string GetGarmentNameOption_New(string garmentType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_garmentName_options_New";
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

        public int GetCurrencyConversion_New(int currencyID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_get_currency_coversion_New";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@currencyID", SqlDbType.Int);
                param.Value = currencyID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object objCID = cmd.ExecuteScalar();

                if (objCID == DBNull.Value)
                    return 0;
                else
                    return Convert.ToInt32(objCID);

            }
        }

        public string GetCurrencySymbolDAL_New(string currencyID)
        {
            if (string.IsNullOrEmpty(currencyID.Trim()))
                return "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_Currency_symbol_New";
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

        public DataTable GetBIPLOrderPriceDetails_New(int StyleId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    string cmdText = "Usp_UpdateBIPLOrderPrice_New";
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

        public DataTable GetCurrencyDAL_New()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "sp_Default_Currency_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBulkHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsBulkHistory);

                return dsBulkHistory.Tables[0];
            }
        }
        public DataTable GetYello_Remarks(int StyleId, int ChildCostingID, string Type)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    cnx.Open();
                    string cmdText = "USP_Get_Agreement_Yellow_Sheet";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChildCostingID", SqlDbType.Int);
                    param.Value = ChildCostingID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
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



        public DataTable GetChargeValueDAL_New()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Get_ChargesValue_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsBulkHistory = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsBulkHistory);

                return dsBulkHistory.Tables[0];
            }
        }
        //added by abhishek on 3/5/2017
        public decimal[] GetCostingCmt_New(double SAM, int Quantity, int OB)
        {
            DataTable dt = new DataTable();
            decimal[] res = new decimal[3];
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetCmtExpectedQty_Costing_New";

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

                param = new SqlParameter("@OB", SqlDbType.Int);
                param.Value = OB;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

                res[0] = Convert.ToDecimal(dt.Rows[0]["Cmt"]);
                res[1] = Convert.ToInt32(dt.Rows[0]["Overhead"]);
                res[2] = Convert.ToDecimal(dt.Rows[0]["CutWastage"]);

                return res;
            }
        }
        public string[] GetCMT_Value_New(double SAM, int OB_WS, int Achivement, int ClientId, int DeptId, int StyleId, int Quantity, int createdby)
        {
            Costing objCosting = new Costing();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {                    
                    decimal[] arr=GetCostingCmt_New(SAM, Quantity, OB_WS);

                    objCosting.CMT = arr[0];
                    objCosting.Overhead = Convert.ToInt32(arr[1]);
                    objCosting.Total_Made = arr[2];
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            string[] returnString = new string[] { objCosting.CMT.ToString(), objCosting.OB_WS.ToString(), objCosting.Total_Made.ToString(), objCosting.Overhead.ToString() };
            return returnString;
        }



        public List<Costing> GetClientCostingBy_New(int ClientId, int DeptId, string StyleNumber, int ExpectedQty)
        {
            //Costing objCosting = new Costing();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<Costing> liCost = new List<Costing>();
                string cmdText = "sp_costing_get_client_costing_By_Client_Dept_New";
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

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

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
                    objCosting.CommisionPercent = Convert.ToDouble(dtCost.Rows[0]["COMMISION"]);
                    objCosting.ConvertTo = Convert.ToInt32(dtCost.Rows[0]["CONVERSIONTO"]);
                    objCosting.CoffinBox = Convert.ToDouble(dtCost.Rows[0]["COFFIN_BOX"]);
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
                    objCosting.IsOldOverHead = Convert.ToBoolean(dtCost.Rows[0]["IsOldOverHead"]);

                    //objCosting.Fabric_Adj_Price = Convert.ToInt32(dtCost.Rows[0]["Fabric_Adj_Price"]);
                    //objCosting.Acc_Adj_Price = Convert.ToInt32(dtCost.Rows[0]["Acc_Adj_Price"]);
                    liCost.Add(objCosting);

                }
                return liCost;
            }
        }

        //added by abhishek on 4/5/2017=====================================//
        public List<Costing> GetCostingVariance(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<Costing> liCosts = new List<Costing>();
                string cmdText = "Usp_GetCostingFromToVariance";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtCost = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtCost);

                foreach (DataRow dtRow in dtCost.Rows)
                {
                    Costing objCosting = new Costing();
                    objCosting.fromvari = (dtCost.Rows[0]["FromVarraice"] == DBNull.Value) ? 0 : Convert.ToInt32(dtCost.Rows[0]["FromVarraice"]);
                    objCosting.tovari = (dtCost.Rows[0]["ToVarraice"] == DBNull.Value) ? 0 : Convert.ToInt32(dtCost.Rows[0]["ToVarraice"]);

                    liCosts.Add(objCosting);
                }
                return liCosts;
            }
        }
        public DataTable GetCostingVariance_new(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<Costing> liCosts = new List<Costing>();
                string cmdText = "Usp_GetCostingFromToVariance";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtCost = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtCost);

                foreach (DataRow dtRow in dtCost.Rows)
                {
                    Costing objCosting = new Costing();
                    objCosting.fromvari = (dtCost.Rows[0]["FromVarraice"] == DBNull.Value) ? 0 : Convert.ToInt32(dtCost.Rows[0]["FromVarraice"]);
                    objCosting.tovari = (dtCost.Rows[0]["ToVarraice"] == DBNull.Value) ? 0 : Convert.ToInt32(dtCost.Rows[0]["ToVarraice"]);

                    liCosts.Add(objCosting);
                }
                return dtCost;
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


        public int SaveClientCostingDefault_New(int ClientId, int DeptID, double commission, int Conversion, double coffinbox, double Hangerloops, double lblTags, double OverHeadcost, double ProfitMargin, double Test, double Hangers, double DesignCommision, int Achievement, double ExpectedQuantity, double frtUptoport, int CreatedBy)
        {
            int i = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    string cmdText = "sp_costing_client_default_Update_New";

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
        //Add By Prabhaker
        public string UpdateClientCostingMode_ByClient_New(int ClientId, int DeptId, string HeaderName, int Values)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText, sReturn = "";

                cmdText = "usp_UpdateClientCostingModeValues_ByClient";
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

                param = new SqlParameter("@HeaderName", SqlDbType.VarChar);
                param.Value = HeaderName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Values", SqlDbType.Bit);
                param.Value = Values;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);




                int i = cmd.ExecuteNonQuery();
                sReturn = i.ToString();

                return sReturn;

            }
        }
        //End Of Code

        public string UpdateClientCostingValues_ByClient_New(int ClientId, int DeptId, int HeaderNo, double Values)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText, sReturn = "";

                cmdText = "usp_UpdateClientCostingValues_ByClient_New";
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


                int i = cmd.ExecuteNonQuery();
                sReturn = i.ToString();

                return sReturn;

            }
        }

        public string UpdateExpectedByClient_New(int ClientId, int DeptId, int ExpectedQuantity)
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

        public int Check_UpdateBiplPrice_ShowHide_New(int CostingID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                int checkshowhide = 0;
                string cmdText;
                cmdText = "usp_Check_UpdateBiplPrice_ShowHide_New";
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
        public DataTable Get_OrderDetailBy_StyleId_New(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Get_OrderDetailBy_StyleId_New";

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

        public int UpdateBIPLPrice_New(int OrderId, float AgreedPrice)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;
                cmdText = "Usp_UpdateBIPLOrderPrice_New";
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
        //Add By Prabhaker 16-jul-18
        public DataSet GetModeCost(int CreatedBy, int flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();

                string cmdText = "Usp_ModeCost_ClientCostingDefault";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }
        public int InsertModeCost(decimal ModeCost, int CreatedBy, int flag)
        {
            int result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_ModeCost_ClientCostingDefault";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@ModeCost", SqlDbType.Decimal);
                    param.Value = ModeCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return result;
        }

        public int UpdateModeCost(int id, decimal ModeCost, int CreatedBy, int flag)
        {
            int Result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    //DataSet dsorderDetail = new DataSet();
                    string cmdText = "Usp_ModeCost_ClientCostingDefault";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@id", SqlDbType.Int);
                    param.Value = id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ModeCost", SqlDbType.Decimal);
                    param.Value = ModeCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Result = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return Result;
        }

        public DataSet GetProcessCost(int CreatedBy, int flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet ds = new DataSet();
                cnx.Open();

                string cmdText = "Usp_ProcessCost_ClientCostingDefault";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
        }


        public int InsertProcessCost(decimal ModeCost, int CreatedBy, int flag)
        {
            int result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_ProcessCost_ClientCostingDefault";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@ModeCost", SqlDbType.Decimal);
                    param.Value = ModeCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return result;
        }

        public int UpdateProcessCost(int id, decimal ModeCost, int CreatedBy, int flag)
        {
            int Result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // DataSet dsorderDetail = new DataSet();
                    string cmdText = "Usp_ProcessCost_ClientCostingDefault";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;
                    param = new SqlParameter("@id", SqlDbType.Int);
                    param.Value = id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ModeCost", SqlDbType.Decimal);
                    param.Value = ModeCost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    //adapter.Fill(dsorderDetail);
                    Result = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return Result;

        }
        public List<Costing> GetIsCheckOrderConfirmed(string StyleNumber)
        {

            //Costing objCosting = new Costing();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                List<Costing> liCost = new List<Costing>();

                string cmdText = "USP_GetIsCheckOrderConfirmed";

                cnx.Open();



                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataTable dtCost = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtCost);

                foreach (DataRow dtRow in dtCost.Rows)
                {
                    Costing objCosting = new Costing();
                    objCosting.IsOrderConfirmed = Convert.ToInt32(dtCost.Rows[0]["IsOrderConfirmed"]);
                    objCosting.IsCutting = Convert.ToInt32(dtCost.Rows[0]["IsCutting"]);
                    liCost.Add(objCosting);

                }
                return liCost;
            }
        }



        #region Gajendra Costing

        public FabricCosting GetRateBySupplier_New(int FabType, string Trade, string Suplier)
        {
            FabricCosting objFabCosting = new FabricCosting();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "GetRateBySupplier";
                cnx.Open();

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FabType", SqlDbType.Int);
                param.Value = FabType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Trade", SqlDbType.VarChar);
                param.Value = Trade;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Suplier", SqlDbType.VarChar);
                param.Value = Suplier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtCost = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtCost);

                objFabCosting.Rate = (dtCost.Rows[0]["Rate"] == DBNull.Value) ? 0 : Convert.ToInt32(dtCost.Rows[0]["Rate"]);
            }
            return objFabCosting;

        }

        public DataTable GetCostingDefaultBy_Client_Dept_New(int ClientId, int DeptId, int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_GetAccessoryDefaultBy_Client_Dept_Style";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cnx.Close();
                return dt;
            }
        }

        public List<Accessories> GetCostingUnitQtyBy_Client_Dept_New(int ClientId, int DeptId)
        {

            List<Accessories> UnitQtyList = new List<Accessories>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "GetCostingUnitQtyBy_Client_Dept";
                cnx.Open();

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtCost = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtCost);

                foreach (DataRow dtRow in dtCost.Rows)
                {
                    Accessories objAccesCosting = new Accessories();
                    objAccesCosting.AccessoryID = (dtCost.Rows[0]["AccessoryID"] == DBNull.Value) ? 0 : Convert.ToInt32(dtRow["AccessoryID"]);
                    objAccesCosting.UnitQty = (dtCost.Rows[0]["UnitQty"] == DBNull.Value) ? 0 : Convert.ToInt32(dtRow["UnitQty"]);

                    UnitQtyList.Add(objAccesCosting);
                }
            }
            return UnitQtyList;
        }

        public Accessories GetAccessoryQualityDataByTradeName_New(string TradeName, string Suplier)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "GetAccessoryQualityDataBy_Trade_Supp";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar, 500);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Suplier", SqlDbType.VarChar, 500);
                param.Value = Suplier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccQuality);
                DataTable aqTable = dsAccQuality.Tables[0];

                DataRowCollection rows = aqTable.Rows;
                Accessories accessoryqualityob = new Accessories();

                if (rows.Count == 0)
                {
                    return null;
                }
                accessoryqualityob.AccessoryID = Convert.ToInt32(rows[0]["AccessoryId"]);
                accessoryqualityob.Wastage = (rows[0]["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["Wastage"]);
                accessoryqualityob.Rate = (rows[0]["Price"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["Price"]);
                accessoryqualityob.Unit = (rows[0]["Unit"] == DBNull.Value) ? "N/A" : rows[0]["Unit"].ToString();
                cnx.Close();
                return accessoryqualityob;
            }
        }

        public Processes GetProcessDataByProcessName_New(string Name, string ExpectedQty)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "GetProcessDataBy_ProcessName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ProcessName", SqlDbType.VarChar, 100);
                param.Value = Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ExpectedQty", SqlDbType.Int);
                param.Value = ExpectedQty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsProcess = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsProcess);
                DataTable aqTable = dsProcess.Tables[0];

                DataRowCollection rows = aqTable.Rows;
                Processes processob = new Processes();

                if (rows.Count == 0)
                {
                    return null;
                }
                processob.ValueAdditionID = rows[0]["ValueAdditionID"].ToString();
                processob.FromStatus = rows[0]["FromStatus"].ToString();
                processob.ToStatus = rows[0]["ToStatus"].ToString();
                processob.CostingVAWastage = rows[0]["CostingVAWastage"].ToString();
                processob.Rate = Convert.ToDouble(rows[0]["Rate"]);
                processob.Wastage = Convert.ToDouble(rows[0]["Wastage"]);
                processob.Amount = Convert.ToDouble(rows[0]["Amount"]);
                cnx.Close();
                return processob;
            }
        }

        public List<ValueAddition> GetValueAdditionDDL(int ValueAdditionId)
        {
            List<ValueAddition> ValueAdditionCollenction = new List<ValueAddition>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "Usp_GetValueAddtion_ForCosting";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ValueAddition objValueAddition = new ValueAddition();
                            objValueAddition.ValueAdditionName = reader["ValueAdditionName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ValueAdditionName"]);
                            objValueAddition.ValueAdditionID = reader["ValueAdditionID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ValueAdditionID"]);

                            ValueAdditionCollenction.Add(objValueAddition);
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
            return ValueAdditionCollenction;
        }
        //added by raghvinder on 09-12-2020 start
        public bool IsCostingOldHistoryValid(int CostingID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;
                    cmdText = "usp_IsCostingOldHistoryComments";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@CostingID", SqlDbType.Int);
                    param.Value = CostingID;
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

        public List<OrderOldHistoryComments> Get_Costing_Old_History(int CostingId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_Costing_Old_History_Comment";


                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CostingId", SqlDbType.Int);
                param.Value = CostingId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<OrderOldHistoryComments> OldHistoryCollection = new List<OrderOldHistoryComments>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderOldHistoryComments objOldHistory = new OrderOldHistoryComments();
                        objOldHistory.History = (reader["History"] == DBNull.Value) ? string.Empty : reader["History"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("$$", "</br>").Replace("</br></br></br></br></br></br>", "</br>").Replace("</br></br></br></br></br>", "</br>").Replace("</br></br></br></br>", "</br>").Replace("</br></br></br>", "</br>").Replace("</br></br>", "</br>").Replace("$", "").Remove(0, 5);
                        // objOldHistory.Comments = (reader["Commentes"] == DBNull.Value) ? string.Empty : reader["Commentes"].ToString().Replace("$$", " by ");                    
                        objOldHistory.Comments = (reader["Commentes"] == DBNull.Value) ? string.Empty : reader["Commentes"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("$$", "</br>").Replace("</br></br></br></br></br></br>", "</br>").Replace("</br></br></br></br></br>", "</br>").Replace("</br></br></br></br>", "</br>").Replace("</br></br></br>", "</br>").Replace("</br></br>", "</br>").Replace("$", "").Remove(0, 5);

                        OldHistoryCollection.Add(objOldHistory);
                    }
                }
                return OldHistoryCollection;
            }
        }
        //added by raghvinder on 09-12-2020 end

        public ValueAddition Get_Wastage_Rate_For_Costing(int StyleId, int SequenceNo, int ValueAdditionId, int WastageId, int type)
        {
            ValueAddition objValueAddition = new ValueAddition();
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "usp_Get_Wastage_Rate_For_Costing";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("SequenceNo", SqlDbType.Int);
                    param.Value = SequenceNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ValueAdditionId", SqlDbType.Int);
                    param.Value = ValueAdditionId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WastageId", SqlDbType.Int);
                    param.Value = WastageId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.Int);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objValueAddition.VA_Wastage = reader["VA_Wastage"] == DBNull.Value ? -1 : Convert.ToDouble(reader["VA_Wastage"]);
                        objValueAddition.VA_Rate = reader["VA_Rate"] == DBNull.Value ? -1 : Convert.ToDouble(reader["VA_Rate"]);
                    }

                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return objValueAddition;
        }

        public bool bCheck_CMT_ReadOnly(int ClientID, int DepartmentID, int ParentDeptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_Check_CMT_ReadOnly";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    DataSet dsCheckVisibilty = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;


                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptID", SqlDbType.Int);
                    param.Value = DepartmentID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDeptID", SqlDbType.Int);
                    param.Value = ParentDeptID;
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
            }

            return false;
        }

        public List<Accessories> GetAccessoryBy_Client_Dept_Change(int ClientId, int DeptId, int CostingId)
        {

            List<Accessories> AccessoryList = new List<Accessories>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string cmdText = "Usp_GetAccessoryBy_Client_Dept_Change";
                cnx.Open();

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptID", SqlDbType.Int);
                param.Value = DeptId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CostingId", SqlDbType.Int);
                param.Value = CostingId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Accessories objAccesCosting = new Accessories();
                    objAccesCosting.AccessoryID = (reader["AccessoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["AccessoryId"]);
                    objAccesCosting.AccessoryQualityID = (reader["AccessoryQualityID"] == DBNull.Value) ? "-1" : reader["AccessoryQualityID"].ToString();
                    objAccesCosting.Item = reader["Item"].ToString();
                    objAccesCosting.Rate = (reader["Rate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Rate"]);
                    objAccesCosting.Quantity = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Quantity"]);
                    objAccesCosting.IsDefaultAccessory = (reader["IsDefaultAccessory"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsDefaultAccessory"]);
                    objAccesCosting.ClientId = (reader["ClientId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientId"]);
                    objAccesCosting.ParentDepartmentId = (reader["ParentDepartmentId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ParentDepartmentId"]);
                    objAccesCosting.DepartmentId = (reader["DepartmentId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentId"]);
                    objAccesCosting.Unit = (reader["Unit"] == DBNull.Value) ? "-1" : reader["Unit"].ToString();
                    objAccesCosting.Wastage = (reader["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Wastage"]);
                    objAccesCosting.TotalQuantity = (reader["TotalQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TotalQuantity"]);
                    objAccesCosting.TotalPrice = (reader["TotalPrice"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TotalPrice"]);
                    objAccesCosting.CostingID = (reader["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["CostingId"]);
                    objAccesCosting.AccessoryPercent = (reader["AccessoryPercent"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["AccessoryPercent"]);
                    objAccesCosting.Disabled_ACC = (reader["Disabled_ACC"] == DBNull.Value) ? false : Convert.ToBoolean(reader["Disabled_ACC"]);
                    objAccesCosting.remarks = reader["remarks"].ToString();
                    objAccesCosting.SequenceNumber = (reader["Seq"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Seq"]);

                    AccessoryList.Add(objAccesCosting);
                }
            }
            return AccessoryList;
        }

    }
        #endregion



}

