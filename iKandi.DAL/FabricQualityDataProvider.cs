using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;
using iKandi.Common.Entities;

namespace iKandi.DAL
{
    public class FabricQualityDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public FabricQualityDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insert FabricQuality

        public int InsertFabricQuality(FabricQuality FQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_fabric_quality_insert_fabric_quality";

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter outParam;
                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                    param.Value = FQuality.SupplierReference;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                    param.Value = FQuality.TradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FabricDesign", SqlDbType.Int);
                    //param.Value = FQuality.FabricDesign;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountConstruction", SqlDbType.VarChar);
                    param.Value = FQuality.CountConstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Origin", SqlDbType.Int);
                    param.Value = FQuality.Origin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Composition", SqlDbType.VarChar);
                    param.Value = FQuality.Composition;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSM", SqlDbType.Float);
                    param.Value = FQuality.GSM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                    param.Value = FQuality.Fabric;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Width", SqlDbType.Decimal);
                    param.Value = FQuality.Width;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    //param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    //param.Value = FQuality.Remarks;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadBaseTestFile", SqlDbType.VarChar);
                    param.Value = FQuality.UpdateBaseTestFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TestConductedOn", SqlDbType.DateTime);
                    if ((FQuality.TestConductedOn == DateTime.MinValue) || (FQuality.TestConductedOn == Convert.ToDateTime("1753-01-01")) || (FQuality.TestConductedOn == Convert.ToDateTime("1900-01-01")))
                        // if (FQuality.TestConductedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = FQuality.TestConductedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinimumOrderQuantity", SqlDbType.Float);
                    param.Value = FQuality.MinimumOrderQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTimeForGreige", SqlDbType.Int);
                    param.Value = FQuality.LeadTimeForGreige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTimeForDyed", SqlDbType.Int);
                    param.Value = FQuality.LeadTimeForDyed;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTimeForPrinted", SqlDbType.Int);
                    param.Value = FQuality.LeadTimeForPrinted;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedOn", SqlDbType.DateTime);
                    if ((FQuality.ApprovedOn == DateTime.MinValue) || (FQuality.ApprovedOn == Convert.ToDateTime("1753-01-01")) || (FQuality.ApprovedOn == Convert.ToDateTime("1900-01-01")))
                        //  if (FQuality.ApprovedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = FQuality.ApprovedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                    param.Value = FQuality.SupplierName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CategoryId", SqlDbType.Int);
                    if (Convert.ToInt32(FQuality.CategoryId) == -1)
                        param.Value = null;
                    else
                        param.Value = FQuality.CategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                    if (Convert.ToInt32(FQuality.SubCategoryId) == -1)
                        param.Value = null;
                    else
                        param.Value = FQuality.SubCategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dentification", SqlDbType.VarChar);
                    param.Value = FQuality.Identification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Wastage", SqlDbType.Decimal);
                    param.Value = FQuality.Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PricePrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.PricePrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBiplRegistered", SqlDbType.Bit);
                    param.Value = FQuality.IsBiplRegistered;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = FQuality.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sCommentsHistoryDeleted", SqlDbType.Bit);
                    param.Value = FQuality.IsCommentHistoryDeleted;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //Yaten: Add two new Perameter for Entering Min Stock Qty.

                    //param = new SqlParameter("@MinQty", SqlDbType.Int);
                    //if (FQuality.MinStockQuality.HasValue)
                    //    param.Value = FQuality.MinStockQuality;
                    //else
                    //    param.Value = 0;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@QtyUnit", SqlDbType.Int);
                    //param.Value = FQuality.StockUnit;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        FQuality.FabricQualityID = Convert.ToInt32(outParam.Value);

                    cnx.Close();

                    return FQuality.FabricQualityID;
                }
                catch
                {
                    FQuality.FabricQualityID = -1;
                    return FQuality.FabricQualityID;
                }
            }
        }

        public void InsertFabricQualityBuyer(FabricQualityBuyer FQualityBuyer)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //FQualityBuyer.Client = new Client();
                //FQualityBuyer.FabricQuality = new FabricQuality();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_fabric_quality_buyer_insert_fabric_quality_buyer";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = FQualityBuyer.Client.ClientID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FQualityBuyer.FabricQuality.FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                cmd.ExecuteNonQuery();
            }
        }

        public void InsertFabricQualityPicture(FabricQualityPicture objFabricQualityPicture)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_fabric_quality_picture_insert_fabric_quality_picture";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@d", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@mageFile", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = objFabricQualityPicture.ImageFile;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = objFabricQualityPicture.FabricQuality.FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Update

        public int UpdateFabricQuality(FabricQuality FQuality, string UserName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int Id = -1;
                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_fabric_quality_update_fabric_quality";

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Update);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter paramOut;

                    paramOut = new SqlParameter("@oId", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);

                    SqlParameter param;

                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Value = FQuality.FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                    param.Value = FQuality.SupplierReference;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                    param.Value = FQuality.TradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@FabricDesign", SqlDbType.Int);
                    //param.Value = FQuality.FabricDesign;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountConstruction", SqlDbType.VarChar);
                    param.Value = FQuality.CountConstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Origin", SqlDbType.Int);
                    param.Value = FQuality.Origin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Composition", SqlDbType.VarChar);
                    param.Value = FQuality.Composition;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSM", SqlDbType.Float);
                    param.Value = FQuality.GSM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                    param.Value = FQuality.Fabric;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Width", SqlDbType.Decimal);
                    param.Value = FQuality.Width;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    //param.Value = FQuality.Remarks;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadBaseTestFile", SqlDbType.VarChar);
                    param.Value = FQuality.UpdateBaseTestFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TestConductedOn", SqlDbType.DateTime);
                    if (FQuality.TestConductedOn == DateTime.MinValue)
                    {
                        param.Value = Convert.ToDateTime("01/01/1900");
                    }
                    else
                    {
                        param.Value = FQuality.TestConductedOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinimumOrderQuantity", SqlDbType.Float);
                    param.Value = FQuality.MinimumOrderQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTimeForGreige", SqlDbType.Int);
                    param.Value = FQuality.LeadTimeForGreige;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTimeForDyed", SqlDbType.Int);
                    param.Value = FQuality.LeadTimeForDyed;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTimeForPrinted", SqlDbType.Int);
                    param.Value = FQuality.LeadTimeForPrinted;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedOn", SqlDbType.DateTime);
                    if ((FQuality.ApprovedOn == DateTime.MinValue) || (FQuality.ApprovedOn == Convert.ToDateTime("1753-01-01")) || (FQuality.ApprovedOn == Convert.ToDateTime("1900-01-01")))
                    //  if (FQuality.ApprovedOn == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = FQuality.ApprovedOn;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                    param.Value = FQuality.SupplierName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CategoryId", SqlDbType.Int);
                    if (Convert.ToInt32(FQuality.CategoryId) == -1)
                        param.Value = null;
                    else
                        param.Value = FQuality.CategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                    if (Convert.ToInt32(FQuality.SubCategoryId) == -1)
                        param.Value = null;
                    else
                        param.Value = FQuality.SubCategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dentification", SqlDbType.VarChar);
                    param.Value = FQuality.Identification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Wastage", SqlDbType.Decimal);
                    param.Value = FQuality.Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PricePrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.PricePrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBiplRegistered", SqlDbType.Bit);
                    param.Value = FQuality.IsBiplRegistered;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = FQuality.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sCommentsHistoryDeleted", SqlDbType.Bit);
                    param.Value = FQuality.IsCommentHistoryDeleted;
                    param.Direction = ParameterDirection.Input;

                    // edit by surendra

                    param = new SqlParameter("@oldAirGreigePrice", SqlDbType.Float);
                    param.Value = FQuality.oldAirGreigePrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@oldAirDyingPrice", SqlDbType.Float);
                    param.Value = FQuality.oldAirDyingPrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@oldAirPrintingPrice", SqlDbType.Float);
                    param.Value = FQuality.oldAirPrintingPrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@oldSeaGreigePrice", SqlDbType.Float);
                    param.Value = FQuality.oldSeaGreigePrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@oldSeaDyingPrice", SqlDbType.Float);
                    param.Value = FQuality.oldSeaDyingPrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@oldSeaPrintingPrice", SqlDbType.Float);
                    param.Value = FQuality.oldSeaPrintingPrice;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //
                    param = new SqlParameter("@oldGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.oldGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@oldDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.oldDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@oldPrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.oldPrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //
                    param = new SqlParameter("@UserName", SqlDbType.VarChar);
                    param.Value = UserName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //added by abhishek on 1/7/2015
                    param = new SqlParameter("@oldwithvalue", SqlDbType.Decimal);
                    param.Value = FQuality.oldWidthInchValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@widthvalue", SqlDbType.Decimal);
                    param.Value = FQuality.NewWidthInchValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //END


                    //   cmd.Parameters.Add(param);




                    //Yaten: Add two new Perameter for Entering Min Stock Qty.

                    //param = new SqlParameter("@MinQty", SqlDbType.Int);
                    //if (FQuality.MinStockQuality.HasValue)
                    //    param.Value = FQuality.MinStockQuality;
                    //else
                    //    param.Value = 0;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@QtyUnit", SqlDbType.Int);
                    //param.Value = FQuality.StockUnit;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);





                    cmd.ExecuteNonQuery();

                    if (paramOut.Value != DBNull.Value)
                    {
                        FQuality.FabricQualityID = Convert.ToInt32(paramOut.Value);
                        Id = FQuality.FabricQualityID;
                    }

                    cnx.Close();

                    return Id;
                }
                catch
                {
                    FQuality.FabricQualityID = Id;
                    return Id;
                }
            }
        }

        #endregion

        #region Fetch

        public FabricQuality GetFabricQualityByID(int FabricQualityID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_get_all_by_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.VarChar);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                FabricQuality fabricquality = ConvertDataSetToFabricQuality(dsFabricQuality);

                cnx.Close();

                return fabricquality;
            }
        }

        private FabricQuality ConvertDataSetToFabricQuality(DataSet dsFabricQuality)
        {
            DataTable fqTable = dsFabricQuality.Tables[0];

            DataRowCollection rows = fqTable.Rows;

            FabricQuality fabricqualityob = new FabricQuality();

            fabricqualityob.FabricQualityID = Convert.ToInt32(rows[0]["Id"]);



            fabricqualityob.MinStockQuality = (rows[0]["StockMinQty"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["StockMinQty"]);
            fabricqualityob.StockUnit = (rows[0]["StockUnit"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["StockUnit"]);

            fabricqualityob.SupplierReference = (rows[0]["SupplierReference"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["SupplierReference"]);
            fabricqualityob.TradeName = (rows[0]["TradeName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["TradeName"]);
            //fabricqualityob.FabricDesign = (rows[0]["FabricDesign"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["FabricDesign"]);
            fabricqualityob.CountConstruction = (rows[0]["CountConstruction"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["CountConstruction"]);
            fabricqualityob.Origin = (rows[0]["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["Origin"]);
            fabricqualityob.Composition = (rows[0]["Composition"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Composition"]);
            fabricqualityob.GSM = (rows[0]["GSM"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["GSM"]);
            fabricqualityob.Fabric = (rows[0]["Fabric"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Fabric"]);
            fabricqualityob.Width = (rows[0]["Width"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["Width"]);
            //fabricqualityob.Remarks = (rows[0]["Remarks"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Remarks"]);
            fabricqualityob.UpdateBaseTestFile = (rows[0]["UploadBaseTestFile"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["UploadBaseTestFile"]);
            fabricqualityob.TestConductedOn = (rows[0]["TestConductedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["TestConductedOn"]);
            fabricqualityob.MinimumOrderQuantity = (rows[0]["MinimumOrderQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["MinimumOrderQuantity"]);
            fabricqualityob.LeadTimeForGreige = (rows[0]["LeadTimeForGreige"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["LeadTimeForGreige"]);
            fabricqualityob.LeadTimeForDyed = (rows[0]["LeadTimeForDyed"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["LeadTimeForDyed"]);
            fabricqualityob.LeadTimeForPrinted = (rows[0]["LeadTimeForPrinted"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["LeadTimeForPrinted"]);
            fabricqualityob.PriceForGreigeByAir = (rows[0]["PriceForGreigeByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForGreigeByAir"]);
            fabricqualityob.PriceForGreigeBySea = (rows[0]["PriceForGreigeBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForGreigeBySea"]);
            fabricqualityob.PriceForDyedByAir = (rows[0]["PriceForDyedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForDyedByAir"]);
            fabricqualityob.PriceForDyedBySea = (rows[0]["PriceForDyedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForDyedBySea"]);
            fabricqualityob.PriceForPrintedByAir = (rows[0]["PriceForPrintedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForPrintedByAir"]);
            fabricqualityob.PriceForPrintedBySea = (rows[0]["PriceForPrintedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForPrintedBySea"]);
            fabricqualityob.ApprovedOn = (rows[0]["ApprovedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedOn"]);
            fabricqualityob.SupplierName = (rows[0]["SupplierName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["SupplierName"]);
            fabricqualityob.CategoryId = (rows[0]["CategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["CategoryId"]);
            fabricqualityob.SubCategoryId = (rows[0]["SubCategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["SubCategoryId"]);
            fabricqualityob.Group = (rows[0]["Group"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Group"]);
            fabricqualityob.SubGroup = (rows[0]["SubGroup"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["SubGroup"]);
            fabricqualityob.Identification = (rows[0]["Identification"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Identification"]);
            fabricqualityob.Wastage = (rows[0]["Wastage"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["Wastage"]);
            fabricqualityob.PriceGreigeIndian = (rows[0]["GreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["GreigeIndian"]);
            fabricqualityob.PriceDyedIndian = (rows[0]["DyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["DyedIndian"]);
            fabricqualityob.PricePrintedIndian = (rows[0]["PrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PrintedIndian"]);
            fabricqualityob.IsBiplRegistered = (rows[0]["IsBiplRegistered"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsBiplRegistered"]);
            fabricqualityob.Comments = (rows[0]["Comments"] == DBNull.Value) ? string.Empty : (rows[0]["Comments"].ToString().IndexOf("$$") > -1 ? rows[0]["Comments"].ToString().Replace("$$", "<br/>") : rows[0]["Comments"].ToString());

            DataTable FabricQualityBuyerTable = dsFabricQuality.Tables[1];
            fabricqualityob.Buyers = new List<FabricQualityBuyer>();

            foreach (DataRow row in FabricQualityBuyerTable.Rows)
            {
                FabricQualityBuyer Buyer = new FabricQualityBuyer();

                Buyer.Client = new Client();
                Buyer.Client.ClientID = (row["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ClientID"]);
                Buyer.FabricQuality = new FabricQuality();
                Buyer.FabricQuality.FabricQualityID = (row["FabricQualityID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["FabricQualityID"]);
                fabricqualityob.Buyers.Add(Buyer);
            }

            DataTable FabricQualityPictureTable = dsFabricQuality.Tables[2];
            fabricqualityob.Pictures = new List<FabricQualityPicture>();
            foreach (DataRow Rows in FabricQualityPictureTable.Rows)
            {
                FabricQualityPicture objPicture = new FabricQualityPicture();
                objPicture.FabricQuality = new FabricQuality();
                objPicture.FabricQuality.FabricQualityID = (Rows["FabricQualityID"] == DBNull.Value) ? 0 : Convert.ToInt32(Rows["FabricQualityID"]);
                objPicture.id = (Rows["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(Rows["Id"]);
                objPicture.ImageFile = (Rows["ImageFile"] == DBNull.Value) ? String.Empty : Convert.ToString(Rows["ImageFile"]);
                fabricqualityob.Pictures.Add(objPicture);
            }

            return fabricqualityob;
        }

        public List<FabricQuality> GetAllFabricQuality(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, int GroupId, int SubGroupId, String GsmFrom, String GsmTo, String WidthFrom, String WidthTo, String PriceFrom, String PriceTo, int IsReg, int OrderBy1, int OrderBy2, int OrderBy3, int OrderBy4)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_get_all";

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

                param = new SqlParameter("@GroupId", SqlDbType.Int);
                if (GroupId == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = GroupId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SubGroupId", SqlDbType.Int);
                if (SubGroupId == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = SubGroupId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GsmFrom", SqlDbType.Float);
                if (!String.IsNullOrEmpty(GsmFrom))
                    param.Value = Convert.ToDouble(GsmFrom);
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GsmTo", SqlDbType.Float);
                if (!String.IsNullOrEmpty(GsmTo))
                    param.Value = Convert.ToDouble(GsmTo);
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WidthFrom", SqlDbType.Decimal);
                if (!String.IsNullOrEmpty(WidthFrom))
                    param.Value = Convert.ToDecimal(WidthFrom);
                else
                    param.Value = DBNull.Value;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WidthTo", SqlDbType.Decimal);
                if (!String.IsNullOrEmpty(WidthTo))
                    param.Value = Convert.ToDecimal(WidthTo);
                else
                    param.Value = DBNull.Value;
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

                param = new SqlParameter("@sReg", SqlDbType.Int);
                if (IsReg == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = IsReg;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderBy1", SqlDbType.Int);
                if (OrderBy1 == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = OrderBy1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderBy2", SqlDbType.Int);
                if (OrderBy2 == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = OrderBy2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@OrderBy3", SqlDbType.Int);
                if (OrderBy3 == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = OrderBy3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderBy4", SqlDbType.Int);
                if (OrderBy4 == -1)
                    param.Value = DBNull.Value;
                else
                    param.Value = OrderBy4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                //FabricQuality fabricquality = ConvertDataSetToFabricQuality(dsFabricQuality);
                List<FabricQuality> fabricquality = ConvertDataSetToGetAllFabricQuality(dsFabricQuality);
                cnx.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);
                return fabricquality;
            }
        }

        private List<FabricQuality> ConvertDataSetToGetAllFabricQuality(DataSet dsFabricQuality)
        {
            List<FabricQuality> objFabricQuality = new List<FabricQuality>();
            DataTable FabricQualityTable = dsFabricQuality.Tables[0];

            foreach (DataRow rows in FabricQualityTable.Rows)
            {
                FabricQuality fabricqualityob = new FabricQuality();

                fabricqualityob.FabricQualityID = Convert.ToInt32(rows["Id"]);
                fabricqualityob.SupplierReference = (rows["SupplierReference"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierReference"]);
                fabricqualityob.TradeName = (rows["TradeName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["TradeName"]);
                //fabricqualityob.FabricDesign = (rows["FabricDesign"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["FabricDesign"]);
                fabricqualityob.CountConstruction = (rows["CountConstruction"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["CountConstruction"]);
                fabricqualityob.Origin = (rows["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows["Origin"]);
                fabricqualityob.Composition = (rows["Composition"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Composition"]);
                fabricqualityob.GSM = (rows["GSM"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSM"]);
                fabricqualityob.Fabric = (rows["Fabric"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Fabric"]);
                fabricqualityob.Width = (rows["Width"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["Width"]);
                //fabricqualityob.Remarks = (rows["Remarks"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Remarks"]);
                fabricqualityob.UpdateBaseTestFile = (rows["UploadBaseTestFile"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["UploadBaseTestFile"]);
                fabricqualityob.SupplierName = (rows["SupplierName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierName"]);
                fabricqualityob.CategoryName = (rows["CategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["CategoryName"]);
                fabricqualityob.SubCategoryName = (rows["SubCategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SubCategoryName"]);
                fabricqualityob.Identification = (rows["Identification"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Identification"]);
                fabricqualityob.IsBiplRegistered = (rows["IsBiplRegistered"] == DBNull.Value) ? false : Convert.ToBoolean(rows["IsBiplRegistered"]);
                //fabricqualityob.TestConductedOn = (rows[0]["TestConductedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["TestConductedOn"]);
                //fabricqualityob.MinimumOrderQuantity = (rows[0]["MinimumOrderQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["MinimumOrderQuantity"]);
                //fabricqualityob.LeadTimeForGreige = (rows[0]["LeadTimeForGreige"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["LeadTimeForGreige"]);
                //fabricqualityob.LeadTimeForDyed = (rows[0]["LeadTimeForDyed"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["LeadTimeForDyed"]);
                //fabricqualityob.LeadTimeForPrinted = (rows[0]["LeadTimeForPrinted"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["LeadTimeForPrinted"]);
                fabricqualityob.PriceForGreigeByAir = (rows["PriceForGreigeByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeByAir"]);
                fabricqualityob.PriceForGreigeBySea = (rows["PriceForGreigeBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeBySea"]);
                fabricqualityob.PriceForDyedByAir = (rows["PriceForDyedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedByAir"]);
                fabricqualityob.PriceForDyedBySea = (rows["PriceForDyedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedBySea"]);
                fabricqualityob.PriceForPrintedByAir = (rows["PriceForPrintedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedByAir"]);
                fabricqualityob.PriceForPrintedBySea = (rows["PriceForPrintedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedBySea"]);
                //fabricqualityob.ApprovedOn = (rows[0]["ApprovedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["ApprovedOn"]);
                fabricqualityob.PriceDyedIndian = (rows["DyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["DyedIndian"]);
                fabricqualityob.PriceGreigeIndian = (rows["GreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GreigeIndian"]);
                fabricqualityob.PricePrintedIndian = (rows["PrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PrintedIndian"]);
                fabricqualityob.Wastage = (rows["Wastage"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["Wastage"]);
                fabricqualityob.Comments = (rows["Comments"] == DBNull.Value) ? string.Empty : (rows["Comments"].ToString().IndexOf("$$") > -1 ? rows["Comments"].ToString().Replace("$$", "<br/>") : rows["Comments"].ToString());

                DataTable FabricQualityBuyerTable = dsFabricQuality.Tables[1];
                fabricqualityob.Buyers = new List<FabricQualityBuyer>();

                foreach (DataRow row in FabricQualityBuyerTable.Rows)
                {
                    FabricQualityBuyer Buyer = new FabricQualityBuyer();
                    if (fabricqualityob.FabricQualityID == Convert.ToInt32(row["FabricQualityID"]))
                    {
                        Buyer.Client = new Client();
                        Buyer.Client.ClientID = Convert.ToInt32(row["ClientID"]);
                        Buyer.Client.CompanyName = (row["CompanyName"] == DBNull.Value) ? String.Empty : Convert.ToString(row["CompanyName"]);
                        Buyer.FabricQuality = new FabricQuality();
                        Buyer.FabricQuality.FabricQualityID = Convert.ToInt32(row["FabricQualityID"]);
                        fabricqualityob.Buyers.Add(Buyer);
                    }
                }

                DataTable FabQualityPic = dsFabricQuality.Tables[2];
                fabricqualityob.Pictures = new List<FabricQualityPicture>();

                foreach (DataRow row in dsFabricQuality.Tables[2].Rows)
                {

                    FabricQualityPicture Pic = new FabricQualityPicture();

                    if (fabricqualityob.FabricQualityID == Convert.ToInt32(row["FabricQualityID"]))
                    {
                        Pic.ImageFile = (row["ImageFile"] == DBNull.Value) ? String.Empty : Convert.ToString(row["ImageFile"]);
                    }
                    fabricqualityob.Pictures.Add(Pic);
                }

                objFabricQuality.Add(fabricqualityob);

            }
            return objFabricQuality;

        }

        public string GetNewCountConstruction()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                SqlDataReader reader;
                string cmdText;
                string CountConstruction = "";

                cmdText = "sp_fabric_quality_get_new_count_construction";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CountConstruction = Convert.ToString(reader["CountConstruction"]);

                }
                return CountConstruction;

            }
        }


        public DataSet GetAllFabricPhotos(int FabricQualityId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_picture_get_all_photos";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.CommandText = cmdText;
                cmd.Connection = cnx;

                SqlParameter param;
                param = new SqlParameter("@FabricQualityId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = FabricQualityId;
                cmd.Parameters.Add(param);

                DataSet dsFabricQualityPhotos = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQualityPhotos);

                cnx.Close();

                return dsFabricQualityPhotos;


            }
        }

        #endregion

        public int GetIdBySupplierReferenceNo(string SupplierReferenceNo)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_get_id_by_supplier_reference_no";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                param.Value = SupplierReferenceNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int Id = Convert.ToInt32(cmd.ExecuteScalar());
                return Id;
            }
        }

        public int GetIdByTradeName(string TradeName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_get_id_by_trade_name";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                int Id = Convert.ToInt32(cmd.ExecuteScalar());
                return Id;
            }

        }

        #region Delete
        public bool DeleteFabricQualityBuyer(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_fabric_quality_buyer_delete";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }
            return true;
        }

        public bool DeleteFabricQualityPicture(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdtext = "sp_fabric_quality_pictures_delete";
                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
                cnx.Close();


            }
            return true;
        }

        public bool DeleteFabricQuality(int FabricQualityID)
        {
            SqlTransaction transaction = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "sp_fabric_quality_delete_fabric_quality";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Value = FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;

                    cmd.ExecuteNonQuery();

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
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    transaction.Rollback();
                    return false;
                }

            }


        }

        #endregion

        public FabricQuality GetFabricQualityDetailsByTradeName(string TradeName, string Details, int Mode)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_details_by_trade_name";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar, 2000);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                FabricQuality fabricqualityob = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }
                if (Details == " " || Details == "#")
                {
                    Details = "PRD";
                }
                fabricqualityob.GSM = Convert.ToInt32(rows[0]["GSM"]);
                fabricqualityob.CountConstruction = Convert.ToString(rows[0]["CountConstruction"]);
                fabricqualityob.FabricQualityID = Convert.ToInt32(rows[0]["Id"]);
                fabricqualityob.Width = (rows[0]["Width"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["Width"]);
                fabricqualityob.Wastage = (rows[0]["Wastage"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["Wastage"]);
                fabricqualityob.Origin = (rows[0]["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["Origin"]);
                // fabricqualityob.
                if (fabricqualityob.Origin == 2)
                {
                    if (Details.Contains("COL") && Mode == 0)
                        fabricqualityob.Price = (rows[0]["PriceForDyedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForDyedBySea"]);
                    else if (Details.Contains("COL") && Mode == 1)
                        fabricqualityob.Price = (rows[0]["PriceForDyedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForDyedByAir"]);
                    else if (Details.Contains("PRD") && Mode == 0)
                        fabricqualityob.Price = (rows[0]["PriceForPrintedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForPrintedBySea"]);
                    else if (Details.Contains("PRD") && Mode == 1)
                        fabricqualityob.Price = (rows[0]["PriceForPrintedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceForPrintedByAir"]);
                }
                else if (fabricqualityob.Origin == 1)
                {
                    if (Details.Contains("PRD"))
                        fabricqualityob.Price = (rows[0]["PrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PrintedIndian"]);
                    else
                        fabricqualityob.Price = (rows[0]["DyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["DyedIndian"]);
                }
                else
                    fabricqualityob.Price = 0;

                cnx.Close();

                return fabricqualityob;
            }
        }

        public FabricQuality GetFabricQualityDetailsByTradeNameForPrint(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_details_by_trade_name_For_Print";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                FabricQuality fabricqualityob = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }
                fabricqualityob.CountConstruction = Convert.ToString(rows[0]["GSM"]);

                cnx.Close();

                return fabricqualityob;
            }
        }

        public List<string> Get_Vender_NameForReallocation(string vanderName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_Vender_name";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@VenderName", SqlDbType.VarChar);
                param.Value = vanderName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                List<string> fabricqualityob = new List<string>();
                FactoryAdmin factory = new FactoryAdmin();

                if (rows.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < fqTable.Rows.Count; i++)
                {
                    factory.Name = fqTable.Rows[i]["Name"].ToString();
                    fabricqualityob.Add(string.Format(factory.Name));
                }

                cnx.Close();

                return fabricqualityob;
            }
        }

        public FabricQuality GetFabricQualityDetailsByTradeNameForPrintOnLoad(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_details_by_trade_name_print_load";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                FabricQuality fabricqualityob = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }//TradeName
                fabricqualityob.CountConstruction = Convert.ToString(rows[0]["GSM"]);
                fabricqualityob.TradeName = Convert.ToString(rows[0]["TradeName"]);
                fabricqualityob.Composition = Convert.ToString(rows[0]["Composition"]);

                cnx.Close();

                return fabricqualityob;
            }
        }

        public DataSet GetRegisteredFabrics()
        {
            List<string> fabrics = new List<string>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_registered_fabrics";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsRegFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRegFabricQuality);

                cnx.Close();

                return dsRegFabricQuality;

            }
        }

        public DataSet GetUnRegisteredFabrics()
        {
            List<string> fabrics = new List<string>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_reports_unregistered_fabrics";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsUnRegFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsUnRegFabricQuality);

                cnx.Close();

                return dsUnRegFabricQuality;
            }
        }

        public string GetAllAqlExistingStanderdDAL(double AQLType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsAql = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_aql_chart";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@AQLType", SqlDbType.Float);
                param.Value = AQLType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsAql);
                DataTable dt = dsAql.Tables[0];

                string styleNumber = Convert.ToString(dt.Rows[0][0]);
                return styleNumber;
            }
        }

        #region New FQ
        //Add by Surendra2 on 09-07-2018
        public DataSet GetFabricsQualityMaster(string SearchItem, string Category, string Quality, string UnitID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetFabricsQualityMaster";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFabricsQuality = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@SearchItem", SqlDbType.VarChar);
                param.Value = SearchItem;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = Category;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = Quality;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricsQuality);
                cnx.Close();
                return dsFabricsQuality;
            }
        }

        public DataSet GetCetegory()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetCategory";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsCategory = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsCategory);
                cnx.Close();
                return dsCategory;
            }
        }

        public DataSet GetCetegoryByID(int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetCategoryByFabricMaster_Id";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsCategory = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsCategory);
                cnx.Close();
                return dsCategory;
            }
        }

        public List<string> Get_Finsh_Value(string ID, string Name)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_Get_Finish_Value";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                List<string> fabricqualityob = new List<string>();
                FabricQuality fabricquality = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < fqTable.Rows.Count; i++)
                {
                    fabricquality.DyedRate = Convert.ToDouble(fqTable.Rows[i][0].ToString());
                    fabricqualityob.Add(string.Format(fabricquality.DyedRate.ToString()));
                }

                cnx.Close();

                return fabricqualityob;
            }
        }

        public List<string> Get_Griege_Value(string ID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_Get_Griege_Value";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                List<string> fabricqualityob = new List<string>();
                FabricQuality fabricquality = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < fqTable.Rows.Count; i++)
                {
                    fabricquality.DyedRate = Convert.ToDouble(fqTable.Rows[i][0].ToString());
                    fabricqualityob.Add(string.Format(fabricquality.DyedRate.ToString()));

                }

                cnx.Close();

                return fabricqualityob;
            }
        }

        public DataSet Get_GriegeRate_Value(string ID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_Get_Griege_Value";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                cnx.Close();

                return dsFabricQuality;
            }
        }

        public DataSet Get_GriegeRate_Value_By_Supplier(string ID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_Get_Griege_Value_by_Supplier";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                cnx.Close();

                return dsFabricQuality;
            }
        }

        public DataSet GetUnit()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_Get_CommonUnit";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsUnit = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsUnit);
                cnx.Close();
                return dsUnit;
            }
        }

        public int FabricQualityMaster_InstUpdt(FabricQuality FQuality, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_FabricsQualityMaster_InsUpdt";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = FQuality.FQMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = FQuality.CategoryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = FQuality.TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.Int);
                param.Value = FQuality.StockUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Dyeing_Greige_Sh", SqlDbType.Int);
                if (FQuality.Dyeing_Greige_Sh == 0)
                    param.Value = 0;
                else
                    param.Value = FQuality.Dyeing_Greige_Sh;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Printing_Greige_Sh", SqlDbType.Int);
                if (FQuality.Printing_Greige_Sh == 0)
                    param.Value = 0;
                else
                    param.Value = FQuality.Printing_Greige_Sh;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Res_Sh", SqlDbType.Int);
                if (FQuality.Res_Sh == 0)
                    param.Value = 0;
                else
                    param.Value = FQuality.Res_Sh;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }

        public DataTable FabricQualityMastEdt(string ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_FabricsQualityMasterEdit";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtFabricsQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFabricsQuality);
                cnx.Close();
                return dtFabricsQuality;
            }
        }

        public DataTable UnitMastEdt(string ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_UnitMasterEdit";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtFabricsQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFabricsQuality);
                cnx.Close();
                return dtFabricsQuality;
            }
        }

        //added on 16-09-2020 start
        public bool GetIS_CANDC_VALUE(int FabricMaster_ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_GetIsCandC";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                DataSet dsCheckExistFabric = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_ID", SqlDbType.Int);
                param.Value = FabricMaster_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsCheckExistFabric);
                int a = Convert.ToInt32(dsCheckExistFabric.Tables[0].Rows[0]["IsCC"]);
                if (a == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //added on 16-09-2020 end


        public DataSet GetGreigeDetails(int FabricMaster_ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetGreigeDeatils";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsGriegeDtails = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_ID", SqlDbType.Int);
                param.Value = FabricMaster_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsGriegeDtails);
                cnx.Close();
                return dsGriegeDtails;
            }
        }

        public int GreigetoFinish_InstUpdt(int Id, int FabricMaster_Id, double GreigeRate, double CutWidth, double CostWidth, string GSM, string CountConstruction, int OptionNo, int CreatedBy, double GriegeWidth,string greigeCC)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_GreigetoFinish_InstUpdt";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Fabric_Quality_DetailsID", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = FabricMaster_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GreigeRate", SqlDbType.Float);
                param.Value = GreigeRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutWidth", SqlDbType.Float);
                param.Value = CutWidth;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostWidth", SqlDbType.Float);
                param.Value = CostWidth;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GSM", SqlDbType.VarChar);
                param.Value = GSM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountConstruction", SqlDbType.VarChar);
                param.Value = CountConstruction;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Createdby", SqlDbType.Int);
                param.Value = CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OptionNo", SqlDbType.Int);
                param.Value = OptionNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GriegeWidth", SqlDbType.Float);
                param.Value = GriegeWidth;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@GreigeCC", SqlDbType.VarChar,500);
                param.Value = greigeCC;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }

        public int GreigetoFinish_Delete(int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_GreigetoFinish_Delete";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Fabric_Quality_DetailsID", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }

        public DataSet GetFinishDetails(int FabricMaster_ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetFinishDeatils";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFinishDtails = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_ID", SqlDbType.Int);
                param.Value = FabricMaster_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFinishDtails);
                cnx.Close();
                return dsFinishDtails;
            }
        }

        public int Finish_InstUpdt(int Id, int FabricMaster_Id, double GreigeWidth, double CutWidth, double CostWidth, string GSM, string CountConstruction, int CreatedBy)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_GreigetoFinish_InstUpdt";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Fabric_Quality_DetailsID", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = FabricMaster_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GreigeWidth", SqlDbType.Float);
                param.Value = GreigeWidth;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CutWidth", SqlDbType.Float);
                param.Value = CutWidth;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostWidth", SqlDbType.Float);
                param.Value = CostWidth;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GSM", SqlDbType.VarChar);
                param.Value = GSM;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountConstruction", SqlDbType.VarChar);
                param.Value = CountConstruction;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Createdby", SqlDbType.Int);
                param.Value = CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }

        public DataSet GetFQHeader(int FabricMaster_ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetFQHeader";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFinishDtails = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_ID", SqlDbType.Int);
                param.Value = FabricMaster_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFinishDtails);
                cnx.Close();
                return dsFinishDtails;
            }
        }

        // Add By Surendra2 On 17/08/2018
        public List<string> GetFQHeaderforSupplier(string FabricMaster_ID)
        {
            try
            {
                DataSet dsFinishDtails = new DataSet();
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "Usp_Get_Griege_Value_by_Supplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@Id", SqlDbType.Int);
                    param.Value = FabricMaster_ID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsFinishDtails);
                    cnx.Close();
                }
                List<string> ls = new List<string>();
                if (dsFinishDtails.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < dsFinishDtails.Tables[0].Rows.Count; i++)
                {
                    ls.Add(string.Format(dsFinishDtails.Tables[0].Rows[i]["Name"].ToString()));

                }
                return ls;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return null;
            }
        }

        public DataSet GetFQDetails(int FabricMaster_ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetFQDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFinishDtails = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_ID", SqlDbType.Int);
                param.Value = FabricMaster_ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFinishDtails);
                cnx.Close();
                return dsFinishDtails;
            }
        }

        public DataSet GetFQ_Details_By_Fabric_Quality_DetailsID(int Fabric_Quality_DetailsID, int supplier)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_FQ_Details_By_Fabric_Quality_DetailsID";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFinishDtails = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@Fabric_Quality_DetailsID", SqlDbType.Int);
                param.Value = Fabric_Quality_DetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@supplier", SqlDbType.Int);
                param.Value = supplier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFinishDtails);
                cnx.Close();
                return dsFinishDtails;
            }
        }

        public DataSet GetBindSupplier(int FabricMaster_Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_BindSupplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFinishDtails = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = FabricMaster_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFinishDtails);
                cnx.Close();
                return dsFinishDtails;
            }
        }

        public int FQ_Details_Greige_InstUpdate(int Id, int Fabric_Quality_DetailsID, int Supplier, bool Greige, bool Dyed, bool Print, bool DigitalPrint, double MinimumOrderQuantity, int CreatedBy, double GreigeRate, double GreigeFinalRate, int DyedRate, int PrintRate, int DigitalPrintRate)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_FQ_Details_InstUpdt";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Fabric_Quality_Supplier_Specific", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric_Quality_DetailsID", SqlDbType.Int);
                param.Value = Fabric_Quality_DetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Supplier", SqlDbType.Int);
                param.Value = Supplier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Greige", SqlDbType.Bit);
                param.Value = Greige;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Dyed", SqlDbType.Bit);
                param.Value = Dyed;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Print", SqlDbType.Bit);
                param.Value = Print;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DigitalPrint", SqlDbType.Bit);
                param.Value = DigitalPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MinimumOrderQuantity", SqlDbType.Float);
                param.Value = MinimumOrderQuantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Createdby", SqlDbType.Int);
                param.Value = CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GreigeRate", SqlDbType.Float);
                param.Value = GreigeRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GreigeFinalRate", SqlDbType.Float);
                param.Value = GreigeFinalRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DyedRate", SqlDbType.Int);
                param.Value = DyedRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintRate", SqlDbType.Int);
                param.Value = PrintRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DigitalPrintRate", SqlDbType.Int);
                param.Value = DigitalPrintRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }

        public int FQ_Details_Finish_InstUpdate(int Id, int Fabric_Quality_DetailsID, int Supplier, double GreigeShrinkage, double ResidualShrinkage, double GreigeRate, double GreigeFinalRate, double DyedRate, double PrintRate, double DigitalPrint, double MinimumOrderQuantity, int CreatedBy)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_FQ_Details_InstUpdt";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Fabric_Quality_Supplier_Specific", SqlDbType.Int);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fabric_Quality_DetailsID", SqlDbType.Int);
                param.Value = Fabric_Quality_DetailsID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Supplier", SqlDbType.Int);
                param.Value = Supplier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GreigeShrinkage", SqlDbType.Float);
                param.Value = GreigeShrinkage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ResidualShrinkage", SqlDbType.Float);
                param.Value = ResidualShrinkage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GreigeRate", SqlDbType.Float);
                param.Value = GreigeRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GreigeFinalRate", SqlDbType.Float);
                param.Value = GreigeFinalRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DyedRate", SqlDbType.Float);
                param.Value = DyedRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintRate", SqlDbType.Float);
                param.Value = PrintRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DigitalPrint", SqlDbType.Float);
                param.Value = DigitalPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MinimumOrderQuantity", SqlDbType.Float);
                param.Value = MinimumOrderQuantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Createdby", SqlDbType.Int);
                param.Value = CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }

        public int FQ_Details_Delete(string Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_FQ_Details_Delete";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Fabric_Quality_Supplier_Specific", SqlDbType.VarChar);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }
        //End

        public DataSet GetFabricsQualityMaster(string SearchItem, string GroupID, string SubGroupID, string TradeName, string UnitID, string Origin, string FabricType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "GetFabricsQualityMaster";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsFabricsQuality = new DataSet();
                SqlParameter param;

                param = new SqlParameter("@SearchItem", SqlDbType.VarChar);
                param.Value = SearchItem;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = GroupID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                param.Value = SubGroupID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.Int);
                param.Value = UnitID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Origin", SqlDbType.Int);
                param.Value = Origin;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricType", SqlDbType.Int);
                param.Value = FabricType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricsQuality);
                cnx.Close();
                return dsFabricsQuality;
            }
        }

        public int FabricsQualityMaster_InsUpdt(FabricQuality FQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "FabricsQualityMaster_InsUpdt";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = FQuality.FQMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = FQuality.CategoryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                param.Value = FQuality.SubCategoryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = FQuality.TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.Int);
                param.Value = FQuality.StockUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }
        }

        public DataTable FabricsQualityMasterEdit(string ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "FabricsQualityMasterEdit";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@FabricMaster_Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtFabricsQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFabricsQuality);
                cnx.Close();
                return dtFabricsQuality;
            }
        }

        public List<FabricQuality> GetFabricQualityDetails(string FQMID, int FabricQualityID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "GetFabricQualityDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FQMID", SqlDbType.Int);
                param.Value = FQMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                List<FabricQuality> fabricquality = ConvertDataSetToFabricQualityDetails(dsFabricQuality);

                cnx.Close();

                return fabricquality;
            }
        }

        private List<FabricQuality> ConvertDataSetToFabricQualityDetails(DataSet dsFabricQuality)
        {
            List<FabricQuality> objFabricQuality = new List<FabricQuality>();
            DataTable FabricQualityTable = dsFabricQuality.Tables[0];

            foreach (DataRow rows in FabricQualityTable.Rows)
            {
                FabricQuality fabricqualityob = new FabricQuality();

                fabricqualityob.FabricQualityID = Convert.ToInt32(rows["Id"]);
                fabricqualityob.FQMasterID = (rows["FabricMaster_Id"] == DBNull.Value) ? "0" : rows["FabricMaster_Id"].ToString();

                fabricqualityob.MinStockQuality = (rows["StockMinQty"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["StockMinQty"]);
                fabricqualityob.StockUnit = (rows["StockUnit"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["StockUnit"]);
                fabricqualityob.SupplierReference = (rows["SupplierReference"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierReference"]);
                fabricqualityob.TradeName = (rows["TradeName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["TradeName"]);

                fabricqualityob.CountConstruction = (rows["CountConstruction"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["CountConstruction"]);
                fabricqualityob.Origin = (rows["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows["Origin"]);
                fabricqualityob.Composition = (rows["Composition"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Composition"]);
                fabricqualityob.GSMGreigeAir = (rows["GSMGreigeAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMGreigeAir"]);
                fabricqualityob.Fabric = (rows["Fabric"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Fabric"]);
                fabricqualityob.WidthGreigeAir = (rows["WidthGreigeAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthGreigeAir"]);
                fabricqualityob.UpdateBaseTestFile = (rows["UploadBaseTestFile"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["UploadBaseTestFile"]);
                fabricqualityob.TestFileVisibility = (rows["UploadBaseTestFile"] == DBNull.Value) ? false : true;
                fabricqualityob.TestConductedOn = (rows["TestConductedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows["TestConductedOn"]);
                fabricqualityob.MinimumOrderQuantity = (rows["MinimumOrderQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["MinimumOrderQuantity"]);
                fabricqualityob.MOQPrint = (rows["MOQPrint"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["MOQPrint"]);
                fabricqualityob.PriceForGreigeByAir = (rows["PriceForGreigeByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeByAir"]);
                fabricqualityob.PriceForGreigeBySea = (rows["PriceForGreigeBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeBySea"]);
                fabricqualityob.PriceForDyedByAir = (rows["PriceForDyedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedByAir"]);
                fabricqualityob.PriceForDyedBySea = (rows["PriceForDyedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedBySea"]);
                fabricqualityob.PriceForPrintedByAir = (rows["PriceForPrintedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedByAir"]);
                fabricqualityob.PriceForPrintedBySea = (rows["PriceForPrintedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedBySea"]);
                fabricqualityob.ApprovedOn = (rows["ApprovedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows["ApprovedOn"]);
                fabricqualityob.SupplierName = (rows["SupplierName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierName"]);
                fabricqualityob.SupplierId = (rows["SupplierID"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["SupplierID"]);
                fabricqualityob.CategoryId = (rows["CategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["CategoryId"]);
                fabricqualityob.SubCategoryId = (rows["SubCategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["SubCategoryId"]);
                fabricqualityob.Group = (rows["Group"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Group"]);
                fabricqualityob.SubGroup = (rows["SubGroup"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SubGroup"]);
                fabricqualityob.Identification = (rows["Identification"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Identification"]);
                fabricqualityob.Wastage = (rows["Wastage"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["Wastage"]);
                fabricqualityob.PriceGreigeIndian = (rows["PriceGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceGreigeIndian"]);
                fabricqualityob.PriceDyedIndian = (rows["PriceDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceDyedIndian"]);
                fabricqualityob.PricePrintedIndian = (rows["PricePrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PricePrintedIndian"]);
                fabricqualityob.IsBiplRegistered = (rows["IsBiplRegistered"] == DBNull.Value) ? false : Convert.ToBoolean(rows["IsBiplRegistered"]);
                fabricqualityob.Comments = (rows["Comments"] == DBNull.Value) ? string.Empty : (rows["Comments"].ToString().IndexOf("$$") > -1 ? rows["Comments"].ToString().Replace("$$", "<br/>") : rows["Comments"].ToString());
                fabricqualityob.ResidualShrinkageGreigeAir = (rows["ResidualShrinkageGreigeAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageGreigeAir"]);
                fabricqualityob.FilePath = (rows["FilePath"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["FilePath"]);

                fabricqualityob.GSMDyedAir = (rows["GSMDyedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDyedAir"]);
                fabricqualityob.WidthDyedAir = (rows["WidthDyedAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDyedAir"]);
                fabricqualityob.ResidualShrinkageDyedAir = (rows["ResidualShrinkageDyedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDyedAir"]);

                fabricqualityob.GSMPrintedAir = (rows["GSMPrintedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMPrintedAir"]);
                fabricqualityob.WidthPrintedAir = (rows["WidthPrintedAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthPrintedAir"]);
                fabricqualityob.ResidualShrinkagePrintedAir = (rows["ResidualShrinkagePrintedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkagePrintedAir"]);

                fabricqualityob.PriceForDigitalByAir = (rows["PriceForDigitalByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalByAir"]);
                fabricqualityob.GSMDigitalAir = (rows["GSMDigitalAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDigitalAir"]);
                fabricqualityob.WidthDigitalAir = (rows["WidthDigitalAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDigitalAir"]);
                fabricqualityob.ResidualShrinkageDigitalAir = (rows["ResidualShrinkageDigitalAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDigitalAir"]);

                fabricqualityob.GSMDyedSea = (rows["GSMDyedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDyedSea"]);
                fabricqualityob.WidthDyedSea = (rows["WidthDyedSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDyedSea"]);
                fabricqualityob.ResidualShrinkageDyedSea = (rows["ResidualShrinkageDyedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDyedSea"]);

                fabricqualityob.GSMGreigeSea = (rows["GSMGreigeSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMGreigeSea"]);
                fabricqualityob.WidthGreigeSea = (rows["WidthGreigeSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthGreigeSea"]);
                fabricqualityob.ResidualShrinkageGreigeSea = (rows["ResidualShrinkageGreigeSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageGreigeSea"]);

                fabricqualityob.GSMPrintedSea = (rows["GSMPrintedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMPrintedSea"]);
                fabricqualityob.WidthPrintedSea = (rows["WidthPrintedSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthPrintedSea"]);
                fabricqualityob.ResidualShrinkagePrintedSea = (rows["ResidualShrinkagePrintedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkagePrintedSea"]);

                fabricqualityob.PriceForDigitalBySea = (rows["PriceForDigitalBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalBySea"]);
                fabricqualityob.GSMDigitalSea = (rows["GSMDigitalSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDigitalSea"]);
                fabricqualityob.WidthDigitalSea = (rows["WidthDigitalSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDigitalSea"]);
                fabricqualityob.ResidualShrinkageDigitalSea = (rows["ResidualShrinkageDigitalSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDigitalSea"]);

                fabricqualityob.GSMDyedIndian = (rows["GSMDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDyedIndian"]);
                fabricqualityob.WidthDyedIndian = (rows["WidthDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDyedIndian"]);
                fabricqualityob.ResidualShrinkageDyedIndian = (rows["ResidualShrinkageDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDyedIndian"]);

                fabricqualityob.GSMGreigeIndian = (rows["GSMGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMGreigeIndian"]);
                fabricqualityob.WidthGreigeIndian = (rows["WidthGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthGreigeIndian"]);
                fabricqualityob.ResidualShrinkageGreigeIndian = (rows["ResidualShrinkageGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageGreigeIndian"]);

                fabricqualityob.GSMPrintedIndian = (rows["GSMPrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMPrintedIndian"]);
                fabricqualityob.WidthPrintedIndian = (rows["WidthPrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthPrintedIndian"]);
                fabricqualityob.ResidualShrinkagePrintedIndian = (rows["ResidualShrinkagePrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkagePrintedIndian"]);

                fabricqualityob.PriceForDigitalByIndian = (rows["PriceForDigitalByIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalByIndian"]);
                fabricqualityob.GSMDigitalIndian = (rows["GSMDigitalIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDigitalIndian"]);
                fabricqualityob.WidthDigitalIndian = (rows["WidthDigitalIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDigitalIndian"]);
                fabricqualityob.ResidualShrinkageDigitalIndian = (rows["ResidualShrinkageDigitalIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDigitalIndian"]);
                fabricqualityob.FabricTypeReg_UnReg = (rows["FabricType"] == DBNull.Value) ? string.Empty : Convert.ToString(rows["FabricType"]);

                objFabricQuality.Add(fabricqualityob);
            }
            return objFabricQuality;
        }
        //abhishek
        public DataTable GetSuplier(int FabricMasterID, int Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "GetSuplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@FabricMasterID", SqlDbType.Int);
                param.Value = FabricMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cnx.Close();
                return dt;
            }
        }

        public int FabricQualityDetail_InsUpdt(FabricQuality FQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "FabricQualityDetail_InsUpdt";
                    SqlParameter param;
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@FQMasterID", SqlDbType.Int);
                    param.Value = FQuality.FQMasterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Value = FQuality.FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                    param.Value = FQuality.SupplierReference;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountConstruction", SqlDbType.VarChar);
                    param.Value = FQuality.CountConstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Origin", SqlDbType.Int);
                    param.Value = FQuality.Origin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Composition", SqlDbType.VarChar);
                    param.Value = FQuality.Composition;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMGreigeAir", SqlDbType.Float);
                    param.Value = FQuality.GSMGreigeAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                    param.Value = FQuality.Fabric;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthGreigeAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthGreigeAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadBaseTestFile", SqlDbType.VarChar);
                    if (!string.IsNullOrEmpty(FQuality.UpdateBaseTestFile))
                        param.Value = FQuality.UpdateBaseTestFile;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TestConductedOn", SqlDbType.DateTime);
                    if ((FQuality.TestConductedOn == DateTime.MinValue) || (FQuality.TestConductedOn == Convert.ToDateTime("1753-01-01")) || (FQuality.TestConductedOn == Convert.ToDateTime("1900-01-01")))
                        // if (FQuality.TestConductedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = FQuality.TestConductedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinimumOrderQuantity", SqlDbType.Float);
                    param.Value = FQuality.MinimumOrderQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedOn", SqlDbType.DateTime);
                    if ((FQuality.ApprovedOn == DateTime.MinValue) || (FQuality.ApprovedOn == Convert.ToDateTime("1753-01-01")) || (FQuality.ApprovedOn == Convert.ToDateTime("1900-01-01")))
                        //  if (FQuality.ApprovedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = FQuality.ApprovedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierID", SqlDbType.Int);
                    param.Value = FQuality.SupplierId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dentification", SqlDbType.VarChar);
                    param.Value = FQuality.Identification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PricePrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.PricePrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = FQuality.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageGreigeAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageGreigeAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOQPrint", SqlDbType.Float);
                    param.Value = FQuality.MOQPrint;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinQty", SqlDbType.Int);
                    if (FQuality.MinStockQuality.HasValue)
                        param.Value = FQuality.MinStockQuality;
                    else
                        param.Value = 0;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    param.Value = FQuality.FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    #region new fields


                    param = new SqlParameter("@GSMDyedAir", SqlDbType.Float);
                    param.Value = FQuality.GSMDyedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDyedAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDyedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDyedAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDyedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMPrintedAir", SqlDbType.Float);
                    param.Value = FQuality.GSMPrintedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthPrintedAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthPrintedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkagePrintedAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkagePrintedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDigitalByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForDigitalByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDigitalAir", SqlDbType.Float);
                    param.Value = FQuality.GSMDigitalAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDigitalAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDigitalAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDigitalAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDigitalAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDyedSea", SqlDbType.Float);
                    param.Value = FQuality.GSMDyedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDyedSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDyedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDyedSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDyedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMGreigeSea", SqlDbType.Float);
                    param.Value = FQuality.GSMGreigeSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthGreigeSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthGreigeSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageGreigeSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageGreigeSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMPrintedSea", SqlDbType.Float);
                    param.Value = FQuality.GSMPrintedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthPrintedSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthPrintedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkagePrintedSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkagePrintedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDigitalBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForDigitalBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@GSMDigitalSea", SqlDbType.Float);
                    param.Value = FQuality.GSMDigitalSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDigitalSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDigitalSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDigitalSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDigitalSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDyedIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ResidualShrinkageDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthGreigeIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMPrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMPrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthPrintedIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthPrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkagePrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkagePrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDigitalByIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceForDigitalByIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDigitalIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMDigitalIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDigitalIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDigitalIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDigitalIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDigitalIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabriType", SqlDbType.Int);
                    param.Value = FQuality.FabricTypeReg_UnReg;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    #endregion

                    count = cmd.ExecuteNonQuery();
                    FabricQualityDetail_InsUpdt_history(FQuality);//abhishek
                    cnx.Close();
                    return count;
                }
                catch
                {
                    return -1;
                }
            }
        }

        //added by abhishek for fabric Quality History 16/6/2017==============
        public List<FabricQuality> GetFabricQualityDetails_history(string FQMID, int FabricQualityID, string Identification)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "GetFabricQualityDetails_history";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FQMID", SqlDbType.Int);
                param.Value = FQMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Identification", SqlDbType.VarChar);
                param.Value = Identification;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                List<FabricQuality> fabricquality = ConvertDataSetToFabricQualityDetails_history(dsFabricQuality);

                cnx.Close();

                return fabricquality;
            }
        }

        private List<FabricQuality> ConvertDataSetToFabricQualityDetails_history(DataSet dsFabricQuality)
        {
            List<FabricQuality> objFabricQuality = new List<FabricQuality>();
            DataTable FabricQualityTable = dsFabricQuality.Tables[0];

            foreach (DataRow rows in FabricQualityTable.Rows)
            {
                FabricQuality fabricqualityob = new FabricQuality();

                fabricqualityob.FabricQualityID = Convert.ToInt32(rows["Id"]);
                fabricqualityob.FQMasterID = (rows["FabricMaster_Id"] == DBNull.Value) ? "0" : rows["FabricMaster_Id"].ToString();

                fabricqualityob.MinStockQuality = (rows["StockMinQty"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["StockMinQty"]);
                fabricqualityob.StockUnit = (rows["StockUnit"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["StockUnit"]);
                fabricqualityob.SupplierReference = (rows["SupplierReference"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierReference"]);
                fabricqualityob.TradeName = (rows["TradeName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["TradeName"]);
                //fabricqualityob.FabricDesign = (rows["FabricDesign"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["FabricDesign"]);
                fabricqualityob.CountConstruction = (rows["CountConstruction"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["CountConstruction"]);
                fabricqualityob.Origin = (rows["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows["Origin"]);
                fabricqualityob.Composition = (rows["Composition"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Composition"]);
                fabricqualityob.GSMGreigeAir = (rows["GSMGreigeAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMGreigeAir"]);
                fabricqualityob.Fabric = (rows["Fabric"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Fabric"]);
                fabricqualityob.WidthGreigeAir = (rows["WidthGreigeAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthGreigeAir"]);
                //fabricqualityob.Remarks = (rows["Remarks"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Remarks"]);
                fabricqualityob.UpdateBaseTestFile = (rows["UploadBaseTestFile"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["UploadBaseTestFile"]);
                fabricqualityob.TestFileVisibility = (rows["UploadBaseTestFile"] == DBNull.Value) ? false : true;
                fabricqualityob.TestConductedOn = (rows["TestConductedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows["TestConductedOn"]);
                fabricqualityob.MinimumOrderQuantity = (rows["MinimumOrderQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["MinimumOrderQuantity"]);
                fabricqualityob.MOQPrint = (rows["MOQPrint"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["MOQPrint"]);
                //fabricqualityob.LeadTimeForGreige = (rows["LeadTimeForGreige"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["LeadTimeForGreige"]);
                //fabricqualityob.LeadTimeForDyed = (rows["LeadTimeForDyed"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["LeadTimeForDyed"]);
                //fabricqualityob.LeadTimeForPrinted = (rows["LeadTimeForPrinted"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["LeadTimeForPrinted"]);
                fabricqualityob.PriceForGreigeByAir = (rows["PriceForGreigeByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeByAir"]);
                fabricqualityob.PriceForGreigeBySea = (rows["PriceForGreigeBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeBySea"]);
                fabricqualityob.PriceForDyedByAir = (rows["PriceForDyedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedByAir"]);
                fabricqualityob.PriceForDyedBySea = (rows["PriceForDyedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedBySea"]);
                fabricqualityob.PriceForPrintedByAir = (rows["PriceForPrintedByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedByAir"]);
                fabricqualityob.PriceForPrintedBySea = (rows["PriceForPrintedBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedBySea"]);
                fabricqualityob.ApprovedOn = (rows["ApprovedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows["ApprovedOn"]);
                fabricqualityob.SupplierName = (rows["SupplierName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierName"]);
                fabricqualityob.SupplierId = (rows["SupplierID"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["SupplierID"]);
                fabricqualityob.CategoryId = (rows["CategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["CategoryId"]);
                fabricqualityob.SubCategoryId = (rows["SubCategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["SubCategoryId"]);
                fabricqualityob.Group = (rows["Group"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Group"]);
                fabricqualityob.SubGroup = (rows["SubGroup"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SubGroup"]);
                fabricqualityob.Identification = (rows["Identification"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Identification"]);
                fabricqualityob.Wastage = (rows["Wastage"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["Wastage"]);
                fabricqualityob.PriceGreigeIndian = (rows["PriceGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceGreigeIndian"]);
                fabricqualityob.PriceDyedIndian = (rows["PriceDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceDyedIndian"]);
                fabricqualityob.PricePrintedIndian = (rows["PricePrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PricePrintedIndian"]);
                fabricqualityob.IsBiplRegistered = (rows["IsBiplRegistered"] == DBNull.Value) ? false : Convert.ToBoolean(rows["IsBiplRegistered"]);
                fabricqualityob.Comments = (rows["Comments"] == DBNull.Value) ? string.Empty : (rows["Comments"].ToString().IndexOf("$$") > -1 ? rows["Comments"].ToString().Replace("$$", "<br/>") : rows["Comments"].ToString());
                fabricqualityob.ResidualShrinkageGreigeAir = (rows["ResidualShrinkageGreigeAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageGreigeAir"]);
                fabricqualityob.FilePath = (rows["FilePath"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["FilePath"]);


                fabricqualityob.GSMDyedAir = (rows["GSMDyedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDyedAir"]);
                fabricqualityob.WidthDyedAir = (rows["WidthDyedAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDyedAir"]);
                fabricqualityob.ResidualShrinkageDyedAir = (rows["ResidualShrinkageDyedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDyedAir"]);

                fabricqualityob.GSMPrintedAir = (rows["GSMPrintedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMPrintedAir"]);
                fabricqualityob.WidthPrintedAir = (rows["WidthPrintedAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthPrintedAir"]);
                fabricqualityob.ResidualShrinkagePrintedAir = (rows["ResidualShrinkagePrintedAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkagePrintedAir"]);

                fabricqualityob.PriceForDigitalByAir = (rows["PriceForDigitalByAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalByAir"]);
                fabricqualityob.GSMDigitalAir = (rows["GSMDigitalAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDigitalAir"]);
                fabricqualityob.WidthDigitalAir = (rows["WidthDigitalAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDigitalAir"]);
                fabricqualityob.ResidualShrinkageDigitalAir = (rows["ResidualShrinkageDigitalAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDigitalAir"]);

                fabricqualityob.GSMDyedSea = (rows["GSMDyedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDyedSea"]);
                fabricqualityob.WidthDyedSea = (rows["WidthDyedSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDyedSea"]);
                fabricqualityob.ResidualShrinkageDyedSea = (rows["ResidualShrinkageDyedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDyedSea"]);

                fabricqualityob.GSMGreigeSea = (rows["GSMGreigeSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMGreigeSea"]);
                fabricqualityob.WidthGreigeSea = (rows["WidthGreigeSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthGreigeSea"]);
                fabricqualityob.ResidualShrinkageGreigeSea = (rows["ResidualShrinkageGreigeSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageGreigeSea"]);

                fabricqualityob.GSMPrintedSea = (rows["GSMPrintedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMPrintedSea"]);
                fabricqualityob.WidthPrintedSea = (rows["WidthPrintedSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthPrintedSea"]);
                fabricqualityob.ResidualShrinkagePrintedSea = (rows["ResidualShrinkagePrintedSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkagePrintedSea"]);

                fabricqualityob.PriceForDigitalBySea = (rows["PriceForDigitalBySea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalBySea"]);
                fabricqualityob.GSMDigitalSea = (rows["GSMDigitalSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDigitalSea"]);
                fabricqualityob.WidthDigitalSea = (rows["WidthDigitalSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDigitalSea"]);
                fabricqualityob.ResidualShrinkageDigitalSea = (rows["ResidualShrinkageDigitalSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDigitalSea"]);

                fabricqualityob.GSMDyedIndian = (rows["GSMDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDyedIndian"]);
                fabricqualityob.WidthDyedIndian = (rows["WidthDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDyedIndian"]);
                fabricqualityob.ResidualShrinkageDyedIndian = (rows["ResidualShrinkageDyedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDyedIndian"]);

                fabricqualityob.GSMGreigeIndian = (rows["GSMGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMGreigeIndian"]);
                fabricqualityob.WidthGreigeIndian = (rows["WidthGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthGreigeIndian"]);
                fabricqualityob.ResidualShrinkageGreigeIndian = (rows["ResidualShrinkageGreigeIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageGreigeIndian"]);

                fabricqualityob.GSMPrintedIndian = (rows["GSMPrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMPrintedIndian"]);
                fabricqualityob.WidthPrintedIndian = (rows["WidthPrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthPrintedIndian"]);
                fabricqualityob.ResidualShrinkagePrintedIndian = (rows["ResidualShrinkagePrintedIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkagePrintedIndian"]);

                fabricqualityob.PriceForDigitalByIndian = (rows["PriceForDigitalByIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalByIndian"]);
                fabricqualityob.GSMDigitalIndian = (rows["GSMDigitalIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["GSMDigitalIndian"]);
                fabricqualityob.WidthDigitalIndian = (rows["WidthDigitalIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows["WidthDigitalIndian"]);
                fabricqualityob.ResidualShrinkageDigitalIndian = (rows["ResidualShrinkageDigitalIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["ResidualShrinkageDigitalIndian"]);
                fabricqualityob.FabricTypeReg_UnReg = (rows["FabricType"] == DBNull.Value) ? string.Empty : Convert.ToString(rows["FabricType"]);
                //abhishek
                //-----sea-----------//
                fabricqualityob.PriceForGreigeBySea_old = (rows["PriceForGreigeBySea_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeBySea_old"]);
                fabricqualityob.PriceForDyedBySea_old = (rows["PriceForDyedBySea_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedBySea_old"]);
                fabricqualityob.PriceForPrintedBySea_old = (rows["PriceForPrintedBySea_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedBySea_old"]);
                fabricqualityob.PriceForDigitalBySea_old = (rows["PriceForDigitalBySea_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalBySea_old"]);

                //-----Air-----------//
                fabricqualityob.PriceForGreigeByAir_old = (rows["PriceForGreigeByAir_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeByAir_old"]);
                fabricqualityob.PriceForDyedByAir_old = (rows["PriceForDyedByAir_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedByAir_old"]);
                fabricqualityob.PriceForPrintedByAir_old = (rows["PriceForPrintedByAir_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedByAir_old"]);
                fabricqualityob.PriceForDigitalByAir_old = (rows["PriceForDigitalByAir_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalByAir_old"]);

                //-----Indian-----------//
                fabricqualityob.PriceForGreigeByIndian_old = (rows["PriceForGreigeByIndian_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForGreigeByIndian_old"]);
                fabricqualityob.PriceForDyedByIndian_old = (rows["PriceForDyedByIndian_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDyedByIndian_old"]);
                fabricqualityob.PriceForPrintedByIndian_old = (rows["PriceForPrintedByIndian_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForPrintedByIndian_old"]);
                fabricqualityob.PriceForDigitalByIndian_old = (rows["PriceForDigitalByIndian_old"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["PriceForDigitalByIndian_old"]);
                //end---------------------------------

                objFabricQuality.Add(fabricqualityob);
            }
            return objFabricQuality;
        }

        public int FabricQualityDetail_InsUpdt_history(FabricQuality FQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "FabricQualityDetail_InsUpdt_history";
                    SqlParameter param;
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@FQMasterID", SqlDbType.Int);
                    param.Value = FQuality.FQMasterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                    param.Value = FQuality.FabricQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                    param.Value = FQuality.SupplierReference;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountConstruction", SqlDbType.VarChar);
                    param.Value = FQuality.CountConstruction;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Origin", SqlDbType.Int);
                    param.Value = FQuality.Origin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Composition", SqlDbType.VarChar);
                    param.Value = FQuality.Composition;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMGreigeAir", SqlDbType.Float);
                    param.Value = FQuality.GSMGreigeAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                    param.Value = FQuality.Fabric;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthGreigeAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthGreigeAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadBaseTestFile", SqlDbType.VarChar);
                    if (!string.IsNullOrEmpty(FQuality.UpdateBaseTestFile))
                        param.Value = FQuality.UpdateBaseTestFile;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TestConductedOn", SqlDbType.DateTime);
                    if ((FQuality.TestConductedOn == DateTime.MinValue) || (FQuality.TestConductedOn == Convert.ToDateTime("1753-01-01")) || (FQuality.TestConductedOn == Convert.ToDateTime("1900-01-01")))
                        // if (FQuality.TestConductedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = FQuality.TestConductedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinimumOrderQuantity", SqlDbType.Float);
                    param.Value = FQuality.MinimumOrderQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForGreigeBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForGreigeBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDyedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForDyedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForPrintedBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForPrintedBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedOn", SqlDbType.DateTime);
                    if ((FQuality.ApprovedOn == DateTime.MinValue) || (FQuality.ApprovedOn == Convert.ToDateTime("1753-01-01")) || (FQuality.ApprovedOn == Convert.ToDateTime("1900-01-01")))
                        //  if (FQuality.ApprovedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = FQuality.ApprovedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierID", SqlDbType.Int);
                    param.Value = FQuality.SupplierId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dentification", SqlDbType.VarChar);
                    param.Value = FQuality.Identification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PricePrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.PricePrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = FQuality.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageGreigeAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageGreigeAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MOQPrint", SqlDbType.Float);
                    param.Value = FQuality.MOQPrint;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinQty", SqlDbType.Int);
                    if (FQuality.MinStockQuality.HasValue)
                        param.Value = FQuality.MinStockQuality;
                    else
                        param.Value = 0;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    param.Value = FQuality.FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    #region new fields


                    param = new SqlParameter("@GSMDyedAir", SqlDbType.Float);
                    param.Value = FQuality.GSMDyedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDyedAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDyedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDyedAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDyedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMPrintedAir", SqlDbType.Float);
                    param.Value = FQuality.GSMPrintedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthPrintedAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthPrintedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkagePrintedAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkagePrintedAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDigitalByAir", SqlDbType.Float);
                    param.Value = FQuality.PriceForDigitalByAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDigitalAir", SqlDbType.Float);
                    param.Value = FQuality.GSMDigitalAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDigitalAir", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDigitalAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDigitalAir", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDigitalAir;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDyedSea", SqlDbType.Float);
                    param.Value = FQuality.GSMDyedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDyedSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDyedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDyedSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDyedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMGreigeSea", SqlDbType.Float);
                    param.Value = FQuality.GSMGreigeSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthGreigeSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthGreigeSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageGreigeSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageGreigeSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMPrintedSea", SqlDbType.Float);
                    param.Value = FQuality.GSMPrintedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthPrintedSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthPrintedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkagePrintedSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkagePrintedSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDigitalBySea", SqlDbType.Float);
                    param.Value = FQuality.PriceForDigitalBySea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@GSMDigitalSea", SqlDbType.Float);
                    param.Value = FQuality.GSMDigitalSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDigitalSea", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDigitalSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDigitalSea", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDigitalSea;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDyedIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ResidualShrinkageDyedIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDyedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthGreigeIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageGreigeIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageGreigeIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMPrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMPrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthPrintedIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthPrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkagePrintedIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkagePrintedIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PriceForDigitalByIndian", SqlDbType.Float);
                    param.Value = FQuality.PriceForDigitalByIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSMDigitalIndian", SqlDbType.Float);
                    param.Value = FQuality.GSMDigitalIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@WidthDigitalIndian", SqlDbType.Decimal);
                    param.Value = FQuality.WidthDigitalIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ResidualShrinkageDigitalIndian", SqlDbType.Float);
                    param.Value = FQuality.ResidualShrinkageDigitalIndian;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabriType", SqlDbType.Int);
                    param.Value = FQuality.FabricTypeReg_UnReg;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    #endregion

                    count = cmd.ExecuteNonQuery();
                    cnx.Close();
                    return count;
                }
                catch
                {
                    return -1;
                }
            }
        }
        //end by abhishek 

        public int DeleteFabricQualityDetails(string FQMID, int FabricQualityID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;

                cnx.Open();

                string cmdText = "DeleteFabricQualityDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@FQMID", SqlDbType.Int);
                param.Value = FQMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }

        }

        public string GetSupplier_SupplyType(string SupplierID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "GetSupplier_SupplyType";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierID", SqlDbType.Int);
                param.Value = SupplierID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                string SupplyType = "";
                SupplyType = cmd.ExecuteScalar().ToString();
                cnx.Close();

                return SupplyType;
            }
        }
        #endregion
        //Gajendra Costing
        public FabricQuality GetFabricQualityDetailsByTradeName_New(string TradeName, string Details, int Mode, int FabricType, string Suplier)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_details_by_trade_name_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar, 500);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricType", SqlDbType.Int);
                param.Value = FabricType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Suplier", SqlDbType.VarChar, 500);
                param.Value = Suplier;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                FabricQuality fabricqualityob = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }
                if (Details == " " || Details == "#")
                {
                    Details = "PRD";
                }

                fabricqualityob.CountConstruction = Convert.ToString(rows[0]["CountConstruction"]);
                fabricqualityob.FabricQualityID = Convert.ToInt32(rows[0]["Id"]);
                fabricqualityob.Wastage = (rows[0]["Wastage"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["Wastage"]);
                fabricqualityob.Origin = (rows[0]["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["Origin"]);
                if (fabricqualityob.Origin == 2)
                {
                    if (Mode == 0)
                    {
                        fabricqualityob.Price = (rows[0]["PriceSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceSea"]);
                        fabricqualityob.GSM = (rows[0]["GSMSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["GSMSea"]);
                        fabricqualityob.Width = (rows[0]["WidthSea"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["WidthSea"]);
                        fabricqualityob.ResidualShrinkageDyedAir = (rows[0]["ResidualShrinkageSea"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["ResidualShrinkageSea"]);

                    }
                    else if (Mode == 1)
                    {
                        fabricqualityob.Price = (rows[0]["PriceAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceAir"]);
                        fabricqualityob.GSM = (rows[0]["GSMAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["GSMAir"]);
                        fabricqualityob.Width = (rows[0]["WidthAir"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["WidthAir"]);
                        fabricqualityob.ResidualShrinkageDyedAir = (rows[0]["ResidualShrinkageAir"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["ResidualShrinkageAir"]);
                    }
                }

                else if (fabricqualityob.Origin == 1)
                {
                    fabricqualityob.Price = (rows[0]["PriceIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["PriceIndian"]);
                    fabricqualityob.GSM = (rows[0]["GSMIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["GSMIndian"]);
                    fabricqualityob.Width = (rows[0]["WidthIndian"] == DBNull.Value) ? 0 : Convert.ToDecimal(rows[0]["WidthIndian"]);
                    fabricqualityob.ResidualShrinkageDyedAir = (rows[0]["ResidualShrinkageIndian"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["ResidualShrinkageIndian"]);

                }
                else
                {
                    fabricqualityob.Price = 0;
                    fabricqualityob.GSM = 0;
                    fabricqualityob.Width = 0;
                    fabricqualityob.ResidualShrinkageDyedIndian = 0;
                }

                cnx.Close();

                return fabricqualityob;
            }
        }

        public FabricQuality GetFabricQualityDetailsByTradeNameForPrint_New(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_details_by_trade_name_For_Print_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                FabricQuality fabricqualityob = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }
                fabricqualityob.CountConstruction = Convert.ToString(rows[0]["GSM"]);

                cnx.Close();

                return fabricqualityob;
            }
        }

        public FabricQuality GetFabricQualityDetailsByTradeNameForPrintOnLoad_New(string TradeName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_fabric_quality_details_by_trade_name_print_load_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                DataTable fqTable = dsFabricQuality.Tables[0];

                DataRowCollection rows = fqTable.Rows;

                FabricQuality fabricqualityob = new FabricQuality();

                if (rows.Count == 0)
                {
                    return null;
                }//TradeName
                fabricqualityob.CountConstruction = Convert.ToString(rows[0]["GSM"]);
                fabricqualityob.TradeName = Convert.ToString(rows[0]["TradeName"]);
                fabricqualityob.Composition = Convert.ToString(rows[0]["Composition"]);

                cnx.Close();

                return fabricqualityob;
            }
        }

        public DataTable GetFabricQualityDetailsByTradeName_New(string TradeName, string CategoryID, string UnitId)
        {
            DataTable DtFabricQualityDetail = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_fabric_quality_details_by_trade_name_New";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar, 500);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryID", SqlDbType.Int);
                param.Value = CategoryID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.VarChar, 500);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DtFabricQualityDetail);

            }

            return DtFabricQualityDetail;
        }
    }
}
