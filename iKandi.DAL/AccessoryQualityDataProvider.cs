using iKandi.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace iKandi.DAL
{
    public class AccessoryQualityDataProvider : BaseDataProvider
    {

        #region Ctor(s)

        public AccessoryQualityDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Insert AccessoryQuality

        public string UpdateAccQuality(Boolean isDefalt, int CatGroupID, int AccessoryMasterId, string AccQuality, int ClientId, int ParentDeptId, int DeptId, string DefaultTradeName, int Wastage, int Shrinkage, int GarmentUnit, int UserID)
        {
            string strReturn = string.Empty;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "Usp_GetAccQualityDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@flag", SqlDbType.Int);
                    param.Value = 3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsDefault", SqlDbType.Bit);
                    param.Value = isDefalt;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CatGroupID", SqlDbType.Int);
                    param.Value = CatGroupID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccMasterID", SqlDbType.Int);
                    param.Value = AccessoryMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccQuality", SqlDbType.VarChar);
                    param.Value = AccQuality;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentDepartmentId", SqlDbType.Int);
                    param.Value = ParentDeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DefaultTradeName", SqlDbType.VarChar);
                    param.Value = DefaultTradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Wastage", SqlDbType.Int);
                    param.Value = Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Shrinkage", SqlDbType.Int);
                    param.Value = Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Unit", SqlDbType.Int);
                    param.Value = GarmentUnit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam = new SqlParameter();
                    outParam = new SqlParameter("@OutReslt", SqlDbType.VarChar, 50);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    //string Parameter = "";
                    //foreach (SqlParameter par in cmd.Parameters)
                    //{
                    //    Parameter += par.ParameterName.ToString() + " ='" + par.Value + "' , ";
                    //}



                    cmd.ExecuteNonQuery();
                    strReturn = outParam.Value.ToString();
                    cnx.Close();

                    return strReturn;
                }
                catch (Exception ex)
                {

                }
            }
            return strReturn;

        }

        public int InsertAccessoryQuality(AccessoryQuality objAccessoryQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();


                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_accessory_quality_insert_accessory_quality";

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    //string str = System.Configuration.ConfigurationSettings.AppSettings["Timeout"];
                    SqlParameter outParam;
                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.SupplierName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Category", SqlDbType.VarChar);
                    param.Value = "";// objAccessoryQuality.Category;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Composition", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.Composition;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccRef", SqlDbType.VarChar);
                    param.Value = "";// objAccessoryQuality.AccRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Origin", SqlDbType.Int);
                    param.Value = objAccessoryQuality.Origin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = "";// objAccessoryQuality.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Wastage", SqlDbType.Int);
                    param.Value = objAccessoryQuality.Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTime", SqlDbType.Int);
                    param.Value = objAccessoryQuality.LeadTime;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadBaseTestFile", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.UploadBaseTestFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TestConductedOn", SqlDbType.DateTime);
                    param.Value = objAccessoryQuality.TestConductedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinimumOrderQuality", SqlDbType.Float);
                    param.Value = objAccessoryQuality.MinimumOrderQuality;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CategoryId", SqlDbType.Int);
                    param.Value = objAccessoryQuality.CategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                    param.Value = objAccessoryQuality.SubCategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dentification", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.Identification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.TradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.SupplierReference;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Price", SqlDbType.Float);
                    param.Value = objAccessoryQuality.Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBiplRegistered", SqlDbType.Bit);
                    param.Value = objAccessoryQuality.IsBiplRegistered;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        objAccessoryQuality.AccessoryQualityID = Convert.ToInt32(outParam.Value);
                    else
                        objAccessoryQuality.AccessoryQualityID = -1;

                    cnx.Close();

                    return objAccessoryQuality.AccessoryQualityID;
                }
                catch
                {
                    objAccessoryQuality.AccessoryQualityID = -1;
                    return objAccessoryQuality.AccessoryQualityID;
                }
            }
        }

        public void InsertAccessoryQualityBuyer(AccessoryQualityBuyer objAccessoryQualityBuyer)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //FQualityBuyer.Client = new Client();
                //FQualityBuyer.FabricQuality = new FabricQuality();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_accessory_quality_buyer_insert_accessory_quality_buyer";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = objAccessoryQualityBuyer.Client.ClientID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
                param.Value = objAccessoryQualityBuyer.AccessoryQuality.AccessoryQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

            }
        }

        public void InsertAccessoryQualityPicture(AccessoryQualityPicture objAccessoryQualityPicture)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_accessory_quality_picture_insert_accessory_quality_picture";

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
                param.Value = objAccessoryQualityPicture.ImageFile;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
                param.Value = objAccessoryQualityPicture.AccessoryQuality.AccessoryQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Update

        public int UpdateAccessoryQuality(AccessoryQuality AccessoryQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int Id = -1;
                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_accessory_quality_update_accessory_quality";

                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Update);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter paramOut;

                    paramOut = new SqlParameter("@oId", SqlDbType.Int);
                    paramOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramOut);

                    SqlParameter param;
                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Value = AccessoryQuality.AccessoryQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                    param.Value = AccessoryQuality.SupplierName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Category", SqlDbType.VarChar);
                    param.Value = "";// AccessoryQuality.Category;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Composition", SqlDbType.VarChar);
                    param.Value = AccessoryQuality.Composition;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccRef", SqlDbType.VarChar);
                    param.Value = "";// AccessoryQuality.AccRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Origin", SqlDbType.Int);
                    param.Value = AccessoryQuality.Origin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = "";// AccessoryQuality.Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Wastage", SqlDbType.Int);
                    param.Value = AccessoryQuality.Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTime", SqlDbType.Int);
                    param.Value = AccessoryQuality.LeadTime;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadBaseTestFile", SqlDbType.VarChar);
                    param.Value = AccessoryQuality.UploadBaseTestFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TestConductedOn", SqlDbType.DateTime);
                    param.Value = AccessoryQuality.TestConductedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinimumOrderQuality", SqlDbType.Float);
                    param.Value = AccessoryQuality.MinimumOrderQuality;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CategoryId", SqlDbType.Int);
                    param.Value = AccessoryQuality.CategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                    param.Value = AccessoryQuality.SubCategoryId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dentification", SqlDbType.VarChar);
                    param.Value = AccessoryQuality.Identification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                    param.Value = AccessoryQuality.TradeName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                    param.Value = AccessoryQuality.SupplierReference;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Price", SqlDbType.Float);
                    param.Value = AccessoryQuality.Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBiplRegistered", SqlDbType.Bit);
                    param.Value = AccessoryQuality.IsBiplRegistered;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (paramOut.Value != DBNull.Value)
                    {
                        AccessoryQuality.AccessoryQualityID = Convert.ToInt32(paramOut.Value);
                        Id = AccessoryQuality.AccessoryQualityID;
                    }
                    else
                    {
                        AccessoryQuality.AccessoryQualityID = -1;
                        Id = -1;
                    }

                    cnx.Close();
                    return Id;
                }
                catch
                {
                    return Id;
                }
            }
        }

        #endregion

        #region Fetch

        public AccessoryQuality GetAccessoryQualiyById(int AccessoryQualityID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_accessory_quality_get_all_by_id";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.VarChar);
                param.Value = AccessoryQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);


                AccessoryQuality accessoryQuality = ConvertDataSetToAccessoryQuality(dsAccessoryQuality);


                cnx.Close();

                return accessoryQuality;
            }
        }


        private AccessoryQuality ConvertDataSetToAccessoryQuality(DataSet DSAccessoryQuality)
        {
            DataTable AQTable = DSAccessoryQuality.Tables[0];
            DataRowCollection rows = AQTable.Rows;
            AccessoryQuality accessoryqualityobject = new AccessoryQuality();
            accessoryqualityobject.AccessoryQualityID = (rows[0]["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["Id"]);
            accessoryqualityobject.SupplierName = (rows[0]["SupplierName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["SupplierName"]);
            accessoryqualityobject.Category = (rows[0]["Category"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Category"]);
            accessoryqualityobject.Composition = (rows[0]["Composition"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Composition"]);
            accessoryqualityobject.AccRef = (rows[0]["AccRef"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["AccRef"]);
            accessoryqualityobject.Origin = (rows[0]["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows[0]["Origin"]);
            accessoryqualityobject.Remarks = (rows[0]["Remarks"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Remarks"]);
            accessoryqualityobject.Wastage = (rows[0]["Wastage"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["Wastage"]);
            accessoryqualityobject.LeadTime = (rows[0]["LeadTime"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["LeadTime"]);
            accessoryqualityobject.UploadBaseTestFile = (rows[0]["UploadBaseTestFile"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["UploadBaseTestFile"]);
            accessoryqualityobject.TestConductedOn = (rows[0]["TestConductedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows[0]["TestConductedOn"]);
            accessoryqualityobject.MinimumOrderQuality = (rows[0]["MinimumOrderQuality"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["MinimumOrderQuality"]);
            accessoryqualityobject.CategoryId = (rows[0]["CategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["CategoryId"]);
            accessoryqualityobject.SubCategoryId = (rows[0]["SubCategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows[0]["SubCategoryId"]);
            accessoryqualityobject.Identification = (rows[0]["Identification"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["Identification"]);
            accessoryqualityobject.TradeName = (rows[0]["TradeName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["TradeName"]);
            accessoryqualityobject.SupplierReference = (rows[0]["SupplierReference"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["SupplierReference"]);
            accessoryqualityobject.Price = (rows[0]["Price"] == DBNull.Value) ? 0 : Convert.ToDouble(rows[0]["Price"]);
            accessoryqualityobject.IsBiplRegistered = (rows[0]["IsBiplRegistered"] == DBNull.Value) ? false : Convert.ToBoolean(rows[0]["IsBiplRegistered"]);
            accessoryqualityobject.CategoryName = (rows[0]["CategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["CategoryName"]);
            accessoryqualityobject.SubCategoryName = (rows[0]["SubCategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows[0]["SubCategoryName"]);

            DataTable AccessoryQualityBuyerTable = DSAccessoryQuality.Tables[1];
            accessoryqualityobject.Buyers = new List<AccessoryQualityBuyer>();

            foreach (DataRow row in AccessoryQualityBuyerTable.Rows)
            {
                AccessoryQualityBuyer Buyer = new AccessoryQualityBuyer();
                Buyer.Client = new Client();
                Buyer.Client.ClientID = (row["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ClientID"]);
                Buyer.AccessoryQuality = new AccessoryQuality();
                Buyer.AccessoryQuality.AccessoryQualityID = (row["AccessoryQualityID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["AccessoryQualityID"]);
                accessoryqualityobject.Buyers.Add(Buyer);
            }

            DataTable AccessoryQualityPictureTable = DSAccessoryQuality.Tables[2];
            accessoryqualityobject.Pictures = new List<AccessoryQualityPicture>();
            foreach (DataRow Rows in AccessoryQualityPictureTable.Rows)
            {
                AccessoryQualityPicture objPicture = new AccessoryQualityPicture();
                objPicture.AccessoryQuality = new AccessoryQuality();
                objPicture.AccessoryQuality.AccessoryQualityID = (Rows["AccessoryQualityID"] == DBNull.Value) ? 0 : Convert.ToInt32(Rows["AccessoryQualityID"]);
                objPicture.id = (Rows["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(Rows["Id"]);
                objPicture.ImageFile = (Rows["ImageFile"] == DBNull.Value) ? String.Empty : Convert.ToString(Rows["ImageFile"]);
                accessoryqualityobject.Pictures.Add(objPicture);

            }
            return accessoryqualityobject;
        }



        #region GetAllAccessoryQuality

        public List<AccessoryQuality> GetAllAccessoryQuality(int PageSize, int PageIndex, out int TotalRowCount, string SearchText, int GroupId, int SubGroupId, String PriceFrom, String PriceTo, int IsReg, int OrderBy1, int OrderBy2, int OrderBy3)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_accessory_quality_get_all_with_paging";

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

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);

                List<AccessoryQuality> accessoryQuality = ConvertDataSetToGetAllAccessoryQuality(dsAccessoryQuality);
                cnx.Close();

                TotalRowCount = Convert.ToInt32(outParam.Value);
                return accessoryQuality;
            }
        }
        //added by abhishek on 16/5/2016
        private void DeleteUserSession(string SessionTableName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();
                    string cmdText = "";
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter paramIn;
                    paramIn = new SqlParameter("@SessionTableName", SqlDbType.Int);
                    paramIn.Value = SessionTableName;
                    cmd.Parameters.Add(paramIn);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
            }
        }
        //edn by abishek

        private List<AccessoryQuality> ConvertDataSetToGetAllAccessoryQuality(DataSet DSAccessoryQuality)
        {
            List<AccessoryQuality> objAccessoryQuality = new List<AccessoryQuality>();
            DataTable AQTable = DSAccessoryQuality.Tables[0];
            //DataRowCollection rows = AQTable.Rows;

            foreach (DataRow rows in AQTable.Rows)
            {
                AccessoryQuality accessoryqualityobject = new AccessoryQuality();
                accessoryqualityobject.AccessoryQualityID = (rows["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["Id"]);
                accessoryqualityobject.SupplierName = (rows["SupplierName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierName"]);
                accessoryqualityobject.Category = (rows["Category"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Category"]);
                accessoryqualityobject.Composition = (rows["Composition"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Composition"]);
                accessoryqualityobject.AccRef = (rows["AccRef"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["AccRef"]);
                accessoryqualityobject.Origin = (rows["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows["Origin"]);
                accessoryqualityobject.Remarks = (rows["Remarks"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Remarks"]);
                accessoryqualityobject.Wastage = (rows["Wastage"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["Wastage"]);
                accessoryqualityobject.LeadTime = (rows["LeadTime"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["LeadTime"]);
                //accessoryqualityobject.CategoryId = (rows["CategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["CategoryId"]);
                //accessoryqualityobject.SubCategoryId = (rows["SubCategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["SubCategoryId"]);
                accessoryqualityobject.Identification = (rows["Identification"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Identification"]);
                accessoryqualityobject.TradeName = (rows["TradeName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["TradeName"]);
                accessoryqualityobject.CategoryName = (rows["CategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["CategoryName"]);
                accessoryqualityobject.SubCategoryName = (rows["SubCategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SubCategoryName"]);
                accessoryqualityobject.SupplierReference = (rows["SupplierReference"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierReference"]);
                accessoryqualityobject.IsBiplRegistered = (rows["IsBiplRegistered"] == DBNull.Value) ? false : Convert.ToBoolean(rows["IsBiplRegistered"]);
                accessoryqualityobject.Price = (rows["Price"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["Price"]);
                DataTable AccessoryQualityBuyerTable = DSAccessoryQuality.Tables[1];
                accessoryqualityobject.Buyers = new List<AccessoryQualityBuyer>();

                //AccessoryQualityBuyer Buyer = new AccessoryQualityBuyer();
                //if(accessoryqualityobject.AccessoryQualityID==Buyer.AccessoryQuality.AccessoryQualityID)

                foreach (DataRow row in DSAccessoryQuality.Tables[1].Rows)
                {
                    AccessoryQualityBuyer Buyer = new AccessoryQualityBuyer();

                    if (accessoryqualityobject.AccessoryQualityID == Convert.ToInt32(row["AccessoryQualityID"]))
                    {
                        Buyer.Client = new Client();
                        Buyer.Client.ClientID = (row["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["ClientID"]);
                        Buyer.Client.CompanyName = (row["CompanyName"] == DBNull.Value) ? String.Empty : Convert.ToString(row["CompanyName"]);
                        Buyer.AccessoryQuality = new AccessoryQuality();
                        Buyer.AccessoryQuality.AccessoryQualityID = (row["AccessoryQualityID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["AccessoryQualityID"]);
                        accessoryqualityobject.Buyers.Add(Buyer);
                    }
                }


                DataTable AccQualityPic = DSAccessoryQuality.Tables[2];
                accessoryqualityobject.Pictures = new List<AccessoryQualityPicture>();

                foreach (DataRow row in DSAccessoryQuality.Tables[2].Rows)
                {

                    AccessoryQualityPicture Pic = new AccessoryQualityPicture();

                    if (accessoryqualityobject.AccessoryQualityID == Convert.ToInt32(row["AccessoryQualityID"]))
                    {
                        Pic.ImageFile = (row["ImageFile"] == DBNull.Value) ? String.Empty : Convert.ToString(row["ImageFile"]);

                    }
                    accessoryqualityobject.Pictures.Add(Pic);
                }

                objAccessoryQuality.Add(accessoryqualityobject);
            }

            return objAccessoryQuality;
        }


        public DataSet GetAllAccessoryPhotos(int AccessoryQualityId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_accessory_quality_picture_get_all_photos";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                cmd.CommandText = cmdText;
                cmd.Connection = cnx;

                SqlParameter param;
                param = new SqlParameter("@AccessoryQualityId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = AccessoryQualityId;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQualityPhotos = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQualityPhotos);

                cnx.Close();

                return dsAccessoryQualityPhotos;
            }
        }

        #endregion

        public int GetIdBySupplierRef(string SupplierRef)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_accessory_quality_get_id_by_supplier_name";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@SupplierRef", SqlDbType.VarChar);
                param.Value = SupplierRef;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                int Id = Convert.ToInt32(cmd.ExecuteScalar());
                return Id;
            }

        }


        #region GetnewAccRefNo

        public string GetNewAccRefNo()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                SqlCommand cmd;
                string cmdText;
                SqlDataReader reader;
                string AccRef = "";

                cmdText = "sp_accessory_quality_get_new_accref";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AccRef = Convert.ToString((reader["AccessoryRefNo"]));
                }

                return AccRef;

            }

        }
        #endregion

        public int GetAccIdByTradeName(string TradeName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_accessory_quality_get_id_by_trade_name";

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

        #endregion

        #region Delete

        public bool DeleteAccessoryQualityBuyer(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdtext = "sp_accessory_quality_buyer_delete";
                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
                cnx.Close();


            }
            return true;
        }



        public bool DeleteAccessoryQualityPicture(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdtext = "sp_accessory_quality_pictures_delete";
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



        public bool DeleteAccessoryQuality(int AccessoryQualityID)
        {
            SqlTransaction transaction = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "sp_accessory_quality_delete_accessory_quality";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
                    param.Value = AccessoryQualityID;
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

        #region New AQ

        //Added by shubhendu 17/11/2021

        public DataSet FourPointCheckLabFileForAccessory(int type, int SrvID, string FileName, char Action)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdtext = "USP_FourPointCheckLabFilesForAccessory";
                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@type", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = type;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FileName", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Value = FileName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = SrvID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Action", SqlDbType.Char);
                param.Direction = ParameterDirection.Input;
                param.Value = Action;
                cmd.Parameters.Add(param);

                DataSet DsLabFiles = new DataSet();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DsLabFiles);

                return DsLabFiles;

            }
        }
        public DataSet GetAccessoryQualityMaster(string SearchItem, string GroupID, string SubGroupID, string TradeName, string UnitID, string Origin, string AccsessoryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "GetAccessoryQualityMaster";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsAccessoryQuality = new DataSet();
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

                param = new SqlParameter("@AccsessoryType", SqlDbType.Int);
                param.Value = AccsessoryType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);
                cnx.Close();
                return dsAccessoryQuality;
            }
        }
        public List<AccessoryPending> UnitMastEdt(string ID)
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

                List<AccessoryPending> AccessoryPendingList = new List<AccessoryPending>();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AccessoryPending objAccessoryPending = new AccessoryPending();
                    objAccessoryPending.GarmentUnitName = reader["UnitName"].ToString();
                    objAccessoryPending.GarmentUnit = reader["GroupUnitID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["GroupUnitID"]);
                    objAccessoryPending.Acc_Wastage = reader["AccesoriesWastage"] == DBNull.Value ? -1 : Convert.ToDouble(reader["AccesoriesWastage"]);

                    AccessoryPendingList.Add(objAccessoryPending);
                }

                cnx.Close();
                return AccessoryPendingList;
            }
        }
        public int AccessoryQualityMaster_InsUpdt(AccessoryQuality AQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "AccessoryQualityMaster_InsUpdt";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@AccessoryMaster_Id", SqlDbType.Int);
                param.Value = AQuality.AQMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = AQuality.CategoryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                param.Value = AQuality.SubCategoryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = AQuality.TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.Int);
                param.Value = AQuality.StockUnit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
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
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsUnit = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsUnit);
                cnx.Close();
                return dsUnit;
            }
        }
        public DataTable AccessoryQualityMasterEdit(string ID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "AccessoryQualityMasterEdit";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@AccessoryMaster_Id", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtAccessorysQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAccessorysQuality);
                cnx.Close();
                return dtAccessorysQuality;
            }
        }

        public DataTable Get_AccessoryUnit(int AccessoryMasterId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_Get_AccessoryUnit";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtAccessorysQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAccessorysQuality);
                cnx.Close();
                return dtAccessorysQuality;
            }
        }

        public DataTable Get_AccessoryUnit_ForOrder(int OrderId, int AccessoryWorkingDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_Get_AccessoryUnit_ForOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryWorkingDetailId", SqlDbType.Int);
                param.Value = AccessoryWorkingDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtAccessorysQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAccessorysQuality);
                cnx.Close();
                return dtAccessorysQuality;
            }
        }
        public DataTable Get_SerailNumber_Against_PO(int MasterPOId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_Get_SerailNumber_AgainstPO";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@MasterPOId", SqlDbType.Int);
                param.Value = MasterPOId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dtSerailNumber = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSerailNumber);
                cnx.Close();
                return dtSerailNumber;
            }
        }

        public DataTable Get_AccessoryPODetail(int SupplierPoId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_GetAccessory_SupplierDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GETPODETAILS";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dtSerailNumber = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSerailNumber);
                cnx.Close();
                return dtSerailNumber;
            }
        }

        public List<GroupUnit> Get_AccessoryDDL_ForOrder(int OrderId, int AccessoryWorkingDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                string cmdText = "usp_Get_AccessoryUnit_ForOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryWorkingDetailId", SqlDbType.Int);
                param.Value = AccessoryWorkingDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<GroupUnit> objList = new List<GroupUnit>();

                while (reader.Read())
                {
                    GroupUnit cCode = new GroupUnit();
                    cCode.GroupUnitID = Convert.ToInt32(reader["GroupUnitID"]);
                    cCode.UnitName = Convert.ToString(reader["UnitName"]);
                    objList.Add(cCode);
                }
                return objList;
            }
        }

        //added by raghvinder on 03-11-2020 start
        public DataTable Get_FabricUnit_ForOrder(int OrderDetailID, int FabricQualityID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_Get_FabricUnit_ForOrder";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricQualityID", SqlDbType.Int);
                param.Value = FabricQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cnx.Close();
                return dt;
            }
        }
        //added by raghvinder on 03-11-2020 end

        public List<AccessoryQuality> GetAccessoryQualityDetails(string AQMID, int AccessoryQualityID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "GetAccessoryQualityDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@AQMID", SqlDbType.Int);
                param.Value = AQMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
                param.Value = AccessoryQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);

                List<AccessoryQuality> Accessoryquality = ConvertDataSetToAccessoryQualityDetails(dsAccessoryQuality);

                cnx.Close();

                return Accessoryquality;
            }
        }

        private List<AccessoryQuality> ConvertDataSetToAccessoryQualityDetails(DataSet accessoryqualityds)
        {
            List<AccessoryQuality> objAccessoryQuality = new List<AccessoryQuality>();
            DataTable AccessoryQualityTable = accessoryqualityds.Tables[0];

            foreach (DataRow rows in AccessoryQualityTable.Rows)
            {
                AccessoryQuality accessoryqualityobject = new AccessoryQuality();

                accessoryqualityobject.AQMasterID = (rows["AccessoryMaster_Id"] == DBNull.Value) ? "0" : rows["AccessoryMaster_Id"].ToString();
                accessoryqualityobject.AccessoryQualityID = Convert.ToInt32(rows["Id"]);
                accessoryqualityobject.SupplierName = (rows["SupplierName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierName"]);
                accessoryqualityobject.SupplierId = (rows["SupplierID"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["SupplierID"]);
                accessoryqualityobject.Origin = (rows["Origin"] == DBNull.Value) ? -1 : Convert.ToInt32(rows["Origin"]);
                accessoryqualityobject.LeadTime = (rows["LeadTime"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["LeadTime"]);
                accessoryqualityobject.CategoryId = (rows["CategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["CategoryId"]);
                accessoryqualityobject.SubCategoryId = (rows["SubCategoryId"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["SubCategoryId"]);
                accessoryqualityobject.Identification = (rows["Identification"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["Identification"]);
                accessoryqualityobject.TradeName = (rows["TradeName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["TradeName"]);
                accessoryqualityobject.CategoryName = (rows["CategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["CategoryName"]);
                accessoryqualityobject.SubCategoryName = (rows["SubCategoryName"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SubCategoryName"]);
                accessoryqualityobject.SupplierReference = (rows["SupplierReference"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["SupplierReference"]);
                accessoryqualityobject.UploadBaseTestFile = (rows["UploadBaseTestFile"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["UploadBaseTestFile"]);
                accessoryqualityobject.TestConductedOn = (rows["TestConductedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows["TestConductedOn"]);
                accessoryqualityobject.MinimumOrderQuality = (rows["MinimumOrderQuality"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["MinimumOrderQuality"]);
                accessoryqualityobject.ApprovedOn = (rows["ApprovedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rows["ApprovedOn"]);
                accessoryqualityobject.StockUnit = (rows["StockUnit"] == DBNull.Value) ? 0 : Convert.ToInt32(rows["StockUnit"]);
                accessoryqualityobject.Price = (rows["Price"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["Price"]);
                accessoryqualityobject.FilePath = (rows["UploadPic"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["UploadPic"]);
                accessoryqualityobject.AccTypeReg_UnReg = (rows["AccessoryType"] == DBNull.Value) ? String.Empty : Convert.ToString(rows["AccessoryType"]);
                accessoryqualityobject.OldPrice = (rows["OldPriceValue"] == DBNull.Value) ? 0 : Convert.ToDouble(rows["OldPriceValue"]);

                objAccessoryQuality.Add(accessoryqualityobject);
            }
            return objAccessoryQuality;
        }

        public int AccessoryQualityDetail_InsUpdt(AccessoryQuality objAccessoryQuality)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "AccessoryQualityDetail_InsUpdt";
                    SqlParameter param;
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@AQMasterID", SqlDbType.Int);
                    param.Value = objAccessoryQuality.AQMasterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
                    param.Value = objAccessoryQuality.AccessoryQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierID", SqlDbType.Int);
                    param.Value = objAccessoryQuality.SupplierId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Origin", SqlDbType.Int);
                    param.Value = objAccessoryQuality.Origin;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UploadBaseTestFile", SqlDbType.VarChar);
                    if (!string.IsNullOrEmpty(objAccessoryQuality.UploadBaseTestFile))
                        param.Value = objAccessoryQuality.UploadBaseTestFile;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TestConductedOn", SqlDbType.DateTime);
                    if ((objAccessoryQuality.TestConductedOn == DateTime.MinValue) || (objAccessoryQuality.TestConductedOn == Convert.ToDateTime("1753-01-01")) || (objAccessoryQuality.TestConductedOn == Convert.ToDateTime("1900-01-01")))
                        //  if (FQuality.ApprovedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryQuality.TestConductedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MinimumOrderQuantity", SqlDbType.Float);
                    param.Value = objAccessoryQuality.MinimumOrderQuality;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dentification", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.Identification;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeadTime", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.LeadTime;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Price", SqlDbType.Float);
                    param.Value = objAccessoryQuality.Price;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierReference", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.SupplierReference;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ApprovedOn", SqlDbType.DateTime);
                    if ((objAccessoryQuality.ApprovedOn == DateTime.MinValue) || (objAccessoryQuality.ApprovedOn == Convert.ToDateTime("1753-01-01")) || (objAccessoryQuality.ApprovedOn == Convert.ToDateTime("1900-01-01")))
                        //  if (FQuality.ApprovedOn == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryQuality.ApprovedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FilePath", SqlDbType.VarChar);
                    param.Value = objAccessoryQuality.FilePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccsessoryType", SqlDbType.Int);
                    param.Value = objAccessoryQuality.AccTypeReg_UnReg;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


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

        public int DeleteAccessoryQualityDetails(string AQMID, int AccessoryQualityID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int result;

                cnx.Open();

                string cmdText = "DeleteAccessoryQualityDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@AQMID", SqlDbType.Int);
                param.Value = AQMID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryQualityID", SqlDbType.Int);
                param.Value = AccessoryQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteNonQuery();
                cnx.Close();
                return result;
            }

        }
        #endregion
        //added by abhishek on 27//12/2018
        public DataSet GetAccessoryOrderSizedeatils(string Flag, int orderid, string SizeOption, int OrderDetailID = 0, string SizeNo = "")
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetAccOrderSummaryDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@orderid", SqlDbType.Int);
                param.Value = orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@optionNo", SqlDbType.VarChar);
                param.Value = SizeOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sizeName", SqlDbType.VarChar);
                param.Value = SizeNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);
                cnx.Close();
                return dsAccessoryQuality;
            }
        }
        public DataSet GetAccOrderShrinkage(int Flag, int orderid, int AccMasterId = 0)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetAccSizeDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@orderid", SqlDbType.Int);
                param.Value = orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccMasterId", SqlDbType.Int);
                param.Value = AccMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);
                cnx.Close();
                return dsAccessoryQuality;
            }
        }

        public DataTable LabManagerChecked(int SRV_Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdtext = "USP_Accessories_Inspection";
                SqlCommand cmd = new SqlCommand(cmdtext, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = SRV_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "LabChecked";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cmd.ExecuteNonQuery();
                cnx.Close();
                return dt;
            }

        }
        public DataSet GetAccessoriesInspection(int SupplierPoId, int SrvId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "USP_Accessories_Inspection";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "Get_AccessoriesInspection_Detail";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = SrvId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cnx.Close();
                return ds;
            }
        }


        public DataTable GetPrintNo(int Flag, int OrderDetailID, int AccessoryworkingdetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetAccSizeDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryworkingdetailId", SqlDbType.Int);
                param.Value = AccessoryworkingdetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dsAccessoryQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);
                cnx.Close();
                return dsAccessoryQuality;
            }
        }
        public int UpdateAccWorkingdetails(int Flag, int AccessoryworkingdetailId = 0, decimal numberacc = 0, int orderid = 0, int OrderDetailID = 0)
        {
            int result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "Usp_GetAccSizeDetails";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryworkingdetailId", SqlDbType.Int);
                    param.Value = AccessoryworkingdetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Numbers", SqlDbType.Float);
                    param.Value = numberacc;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@orderid", SqlDbType.Int);
                    param.Value = orderid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    result = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return result;
        }
        //end

        #region Pending Accessory Summery

        public List<AccessoryPending> Get_AccessoryPending_Orders(int OrderID, int AccessoryMasterId, string Size, string ColorPrint, string Searchtext)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_AccessoryPending_Orders";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtext;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();
                        objAccessoryPending.OrderId = (reader["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderID"]);
                        objAccessoryPending.AccessoryMasterId = (reader["AccessoryMaster_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryMaster_Id"]);
                        objAccessoryPending.AccessoryQualitySizeId = (reader["accessory_quality_SizeID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["accessory_quality_SizeID"]);
                        objAccessoryPending.AccessoryWorkingDetailId = (reader["AccessoryWorkingDetailId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryWorkingDetailId"]);
                        objAccessoryPending.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        objAccessoryPending.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryPending.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        objAccessoryPending.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        objAccessoryPending.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        objAccessoryPending.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                        objAccessoryPending.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        objAccessoryPending.OrderDetailId = (reader["OrderDetailId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderDetailId"]);
                        objAccessoryPending.ContractQty = (reader["Quantity"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Quantity"]);
                        objAccessoryPending.AccessoryAvg = (reader["AccessoryAvg"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["AccessoryAvg"]);
                        objAccessoryPending.AccessoryQty = (reader["AccessoryQty"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["AccessoryQty"]);
                        objAccessoryPending.Stage1 = (reader["Stage1"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Stage1"]);
                        objAccessoryPending.Stage2 = (reader["Stage2"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Stage2"]);
                        objAccessoryPending.OrderDate = (reader["OrderDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["OrderDate"]));
                        objAccessoryPending.IsAccessoryFinish = (reader["IsAccessoryFinished"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAccessoryFinished"]);
                        objAccessoryPending.IsDefaultAccessory = (reader["IsDefaultAccessory"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsDefaultAccessory"]);
                        objAccessoryPending.Stage1SRVReceivedQty = (reader["Stage1SRVReceivedQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Stage1SRVReceivedQty"]);
                        objAccessoryPending.Stage2SRVReceivedQty = (reader["Stage2SRVReceivedQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Stage2SRVReceivedQty"]);
                        objAccessoryPending.ExFactory = (reader["ExFactory"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ExFactory"]));
                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public AccessoryPending Update_AccessoryPending_Orders(int OrderDetailID, int AccessoryworkingdetailId, int Stage1, int Stage2, int UserId)
        {
            AccessoryPending objAccessPending = new AccessoryPending();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "Usp_Update_AccessoryPending_Orders";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryWorkingDetailId", SqlDbType.Int);
                    param.Value = AccessoryworkingdetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage1", SqlDbType.Int);
                    if (Stage1 == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Stage1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Stage2", SqlDbType.Int);
                    if (Stage2 == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = Stage2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam1;
                    outParam1 = new SqlParameter("@Stage1SRVQty", SqlDbType.Int);
                    outParam1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam1);

                    SqlParameter outParam2;
                    outParam2 = new SqlParameter("@Stage2SRVQty", SqlDbType.Int);
                    outParam2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam2);

                    cmd.ExecuteNonQuery();

                    objAccessPending.Stage1SRVReceivedQty = Convert.ToInt32(outParam1.Value);
                    objAccessPending.Stage2SRVReceivedQty = Convert.ToInt32(outParam2.Value);

                    cnx.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return objAccessPending;
        }

        public DataSet GetAccessory_Supplier_QuotationDetails(int UserID, string Searchtxt, int type, string SearchType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_GetAccessory_Supplier_QuotationDetail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchType", SqlDbType.Int);
                param.Value = SearchType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet dsAccessoryQuotationDetails = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuotationDetails);
                cnx.Close();
                return dsAccessoryQuotationDetails;
            }
        }

        public List<AccessoryPending> GetAccessory_Supplier_Quotation(int UserID, string Searchtxt, int type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_Supplier_Quotation";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();

                        objAccessoryPending.AccessoryMasterId = (reader["AccessoryMaster_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryMaster_Id"]);
                        objAccessoryPending.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        //objAccessoryPending.AccessoryQualitySizeId = (reader["AccessoryQualitySizeId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryQualitySizeId"]);
                        objAccessoryPending.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryPending.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        objAccessoryPending.SupplierId = (reader["supplier_master_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["supplier_master_Id"]);
                        objAccessoryPending.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);

                        objAccessoryPending.Shrinkage = (reader["Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Shrinkage"]);
                        objAccessoryPending.Wastage = (reader["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Wastage"]);
                        objAccessoryPending.QuantityToOrder = (reader["QuantityToOrder"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["QuantityToOrder"]);
                        objAccessoryPending.GarmentUnitName = (reader["UnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["UnitName"]);

                        objAccessoryPending.MinimumRate = (reader["MinimumRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["MinimumRate"]);
                        objAccessoryPending.MinimumLeadTime = (reader["MinimumLeadtime"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["MinimumLeadtime"]);

                        objAccessoryPending.QuotedLandedRate = (reader["QuotedLandedRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["QuotedLandedRate"]);
                        objAccessoryPending.QuotedLeadTime = (reader["QuotedLeadTime"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["QuotedLeadTime"]);
                        objAccessoryPending.QuotedDate = (reader["QuotedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["QuotedDate"]);

                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public List<AccessoryPending> GetAccessory_PoDetails_Supplier_Quotation(int SupplierID, int AccessoryMasterId, string Size, string ColorPrint, int type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_PoDetails_Supplier_Quotation";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierID", SqlDbType.Int);
                param.Value = SupplierID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();
                        objAccessoryPending.AccessoryMasterId = AccessoryMasterId;
                        objAccessoryPending.Size = Size;
                        objAccessoryPending.Color_Print = ColorPrint;
                        objAccessoryPending.SupplierPoId = (reader["SupplierPO_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SupplierPO_Id"]);
                        objAccessoryPending.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryPending.PoDate = (reader["PODate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PODate"]);
                        objAccessoryPending.ReceivedQty = (reader["PoRecievedQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["PoRecievedQty"]);
                        //objAccessoryPending.IsCompleteIssue = (reader["IsIssueComplete"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsIssueComplete"]);
                        objAccessoryPending.DefaultGarmentUnitName = (reader["UnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["UnitName"]);
                        objAccessoryPending.FinalRate = (reader["Rate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Rate"]);
                        objAccessoryPending.Status = (reader["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Status"]);
                        objAccessoryPending.SupplyType = (reader["SupplyType"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["SupplyType"]);
                        objAccessoryPending.IsPartySignature = (reader["IsPartySignature"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsPartySignature"]);

                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public int Save_Accessory_Supplier_Quotation(int SupplierID, int AccessoryMasterId, string Size, string ColorPrint, double QuotedLandedRate, int UserId, int type)
        {
            int result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "usp_Save_Accessory_Supplier_Quotation";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@SupplierID", SqlDbType.Int);
                    param.Value = SupplierID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                    param.Value = AccessoryMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size", SqlDbType.VarChar);
                    param.Value = Size.Trim();
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    if (ColorPrint == "")
                        param.Value = DBNull.Value;
                    else
                        param.Value = ColorPrint.Trim();
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QuotedLandedRate", SqlDbType.Float);
                    if (QuotedLandedRate == -1)
                        param.Value = DBNull.Value;
                    else
                        param.Value = QuotedLandedRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //if (LeadTimes == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = LeadTimes;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@LeadTimes", SqlDbType.Int);
                    //if (LeadTimes == -1)
                    //    param.Value = DBNull.Value;
                    //else
                    //    param.Value = LeadTimes;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.Int);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    result = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    result = -1;
                }
            }
            return result;
        }

        public List<AccessoryPending> GetAccessory_OrderPlacement(int UserID, int type, string Searchtxt)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_OrderPlacement";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();

                        objAccessoryPending.AccessoryMasterId = (reader["AccessoryMasterId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryMasterId"]);
                        objAccessoryPending.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);

                        objAccessoryPending.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryPending.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);

                        objAccessoryPending.Shrinkage = (reader["Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Shrinkage"]);
                        objAccessoryPending.Wastage = (reader["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Wastage"]);
                        objAccessoryPending.BalanceQty = (reader["BalanceQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["BalanceQty"]);
                        objAccessoryPending.Stage1ReverseQty = (reader["Stage1ReverseQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Stage1ReverseQty"]);

                        objAccessoryPending.AccessoryQty = (reader["AccessoryQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["AccessoryQty"]);
                        objAccessoryPending.TotalQtyRecieved = (reader["RecievedQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["RecievedQty"]);
                        objAccessoryPending.TotalPassQty = (reader["TotalPassQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPassQty"]);
                        objAccessoryPending.SendQty = (reader["SendQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SendQty"]);
                        objAccessoryPending.PoQuantity = (reader["GreigePoQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["GreigePoQty"]);

                        objAccessoryPending.TotalHoldQty = (reader["HoldQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["HoldQty"]);
                        objAccessoryPending.GarmentUnitName = (reader["GarmentUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GarmentUnitName"]);
                        objAccessoryPending.QuantityToOrder = (reader["QtyToOdr"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["QtyToOdr"]);

                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public DataSet GetAccessory_Supplier_OrderPlacement(int AccessoryMasterId, string Size, string ColorPrint, int type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_GetAccessory_Supplier_OrderPlacement";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size.Trim();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint.Trim();
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);
                cnx.Close();
                return dsAccessoryQuality;
            }
        }

        public List<AccessoryPending> GetAccessory_SupplierDetails(int AccessoryMasterId, string Size, string ColorPrint, int AccessoryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_SupplierDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "SUPPLIER_DETAILS";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryType", SqlDbType.Int);
                param.Value = AccessoryType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();

                        objAccessoryPending.AccessoryMasterId = AccessoryMasterId;
                        objAccessoryPending.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);

                        objAccessoryPending.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryPending.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        objAccessoryPending.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);

                        objAccessoryPending.Shrinkage = (reader["Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Shrinkage"]);
                        objAccessoryPending.Wastage = (reader["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Wastage"]);
                        objAccessoryPending.IdealRate = (reader["IdealRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["IdealRate"]);

                        objAccessoryPending.QuotedLandedRate = (reader["QuotedLandedRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["QuotedLandedRate"]);
                        objAccessoryPending.QuotedLeadTime = (reader["QuotedLeadTimes"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["QuotedLeadTimes"]);
                        objAccessoryPending.SupplierId = (reader["supplierId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["supplierId"]);
                        //objAccessoryPending.SupplierNameWithRate = (reader["SupplierNameWithRate"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierNameWithRate"]);
                        objAccessoryPending.QuotedDate = (reader["QuotedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["QuotedDate"]);

                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public List<AccessoryPending> GetAccessory_ListedSupplier(int AccessoryMasterId, string Size, string ColorPrint, int AccessoryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_SupplierDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "LISTED_SUPPLIER";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryType", SqlDbType.Int);
                param.Value = AccessoryType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();

                        objAccessoryPending.SupplierId = (reader["supplierId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["supplierId"]);
                        objAccessoryPending.SupplierNameWithRate = (reader["SupplierNameWithRate"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierNameWithRate"]);
                        objAccessoryPending.IsQuoted = (reader["IsQuoted"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsQuoted"]);
                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public List<AccessoryPending> GetAccessory_SupplierCode(int AccessoryMasterId, string Size, string ColorPrint, int SupplierId, int AccessoryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_SupplierDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                //SqlParameter param = new SqlParameter("@FlagOption", SqlDbType.VarChar);
                //param.Value = FlagOption;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                SqlParameter param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierId", SqlDbType.Int);
                param.Value = SupplierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "SUPPLIER_CODE";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryType", SqlDbType.Int);
                param.Value = AccessoryType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();

                        //if (reader.GetName(0).Equals("leadday", StringComparison.InvariantCultureIgnoreCase))
                        //{
                        objAccessoryPending.leadday = (reader["leadday"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["leadday"]);
                        objAccessoryPending.leadrange = (reader["leadrange"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["leadrange"]);
                        //}
                        //else
                        //{
                        objAccessoryPending.AccessoryMasterId = AccessoryMasterId;
                        objAccessoryPending.PoNumber = (reader["PoNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PoNumber"]);
                        objAccessoryPending.QuotedLandedRate = (reader["QuotedLandedRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["QuotedLandedRate"]);
                        //objAccessoryPending.QuotedLeadTime = (reader["LeadTimes"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["LeadTimes"]);
                        //}
                        AccessoryPendingCollection.Add(objAccessoryPending);

                    }

                }

                return AccessoryPendingCollection;
            }
        }

        public List<AccessoryPending> GetAccessory_SupplierPurchaseOrder(int AccessoryMasterId, string Size, string ColorPrint, int SupplierPO_Id, int AccessoryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_SupplierDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPO_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "SUPPLIER_PURCHASE_ORDER";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryType", SqlDbType.Int);
                param.Value = AccessoryType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();

                        objAccessoryPending.AccessoryMasterId = AccessoryMasterId;
                        objAccessoryPending.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        objAccessoryPending.Size = Size;
                        objAccessoryPending.Color_Print = ColorPrint;
                        objAccessoryPending.Shrinkage = (reader["Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Shrinkage"]);
                        objAccessoryPending.Wastage = (reader["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Wastage"]);

                        objAccessoryPending.SupplierPoId = (reader["SupplierPO_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplierPO_Id"]);
                        objAccessoryPending.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryPending.PoDate = (reader["PODate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PODate"]);
                        objAccessoryPending.PoEta = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                        objAccessoryPending.SupplierId = (reader["supplierId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["supplierId"]);
                        objAccessoryPending.GarmentUnit = (reader["GarmentUnit"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GarmentUnit"]);
                        objAccessoryPending.GarmentUnitName = (reader["GarmentUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GarmentUnitName"]);
                        objAccessoryPending.FinalRate = (reader["FinalRate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["FinalRate"]);
                        objAccessoryPending.ReceivedQty = (reader["ReceivedQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ReceivedQty"]); //modified by raghvinder on 09-11-2020
                        objAccessoryPending.SendQty = (reader["SendQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SendQty"]);
                        objAccessoryPending.IsPartySignature = (reader["IsPartySignature"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsPartySignature"]);
                        objAccessoryPending.IsAuthorizedSignatory = (reader["IsAuthorizedSignatory"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAuthorizedSignatory"]);
                        objAccessoryPending.PartySignatureBy = (reader["PartySignatureBy"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartySignatureBy"]);
                        objAccessoryPending.AuthorizedSignatureBy = (reader["AuthorizedSignatureBy"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AuthorizedSignatureBy"]);
                        objAccessoryPending.PartySignatureDate = (reader["PartySignatureDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PartySignatureDate"]);
                        objAccessoryPending.AuthorizedSignatureDate = (reader["AuthorizedSignatureDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AuthorizedSignatureDate"]);

                        objAccessoryPending.IsJuniorSignatory = (reader["IsJuniorSignatory"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsJuniorSignatory"]);
                        objAccessoryPending.JuniorSignatoryApprovedOn = (reader["JuniorSignatoryApprovedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["JuniorSignatoryApprovedOn"]);
                        objAccessoryPending.JuniorSignatoryId = (reader["JuniorSignatoryId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["JuniorSignatoryId"]);

                        objAccessoryPending.New_GarmentUnit = (reader["New_GarmentUnit"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["New_GarmentUnit"]);
                        objAccessoryPending.New_RecievedQty = (reader["New_RecievedQty"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["New_RecievedQty"]);
                        objAccessoryPending.New_SendQty = (reader["New_SendQty"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["New_SendQty"]);
                        objAccessoryPending.ConversionValue = (reader["ConversionValue"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["ConversionValue"]);
                        objAccessoryPending.UnitChange = (reader["UnitChange"] == DBNull.Value) ? false : Convert.ToBoolean(reader["UnitChange"]);
                        objAccessoryPending.HistoryExist = (reader["HistoryExist"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["HistoryExist"]);
                        objAccessoryPending.SrvCount = (reader["SrvCount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SrvCount"]);
                        objAccessoryPending.SRVQuantity = (reader["SRVQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SRVQty"]);
                        objAccessoryPending.SupplierEmail = (reader["SupplierEmail"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierEmail"]);
                        objAccessoryPending.SupplierNameWithRate = (reader["SupplierNameWithRate"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierNameWithRate"]);
                        objAccessoryPending.DefaultGarmentUnitName = (reader["NewGarmentUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["NewGarmentUnitName"]);
                        objAccessoryPending.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : reader["SupplierName"].ToString();
                        objAccessoryPending.AccessoryRemarks = (reader["AccessoryRemarks"] == DBNull.Value) ? string.Empty : reader["AccessoryRemarks"].ToString();
                        objAccessoryPending.ClientCode = (reader["ClintCode"] == DBNull.Value) ? string.Empty : reader["ClintCode"].ToString();
                        objAccessoryPending.Status = (reader["PoStatus"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PoStatus"].ToString());
                        //rajeevS
                        objAccessoryPending.HSNCode = (reader["HSNCode"] == DBNull.Value) ? string.Empty : (reader["HSNCode"].ToString());
                        //RajeevS
                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }
        public DataSet GetAccessoryRemarks(string PO_Number)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetAccessoryRemarks";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Po_Number", SqlDbType.VarChar);
                param.Value = PO_Number;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                DataSet dsAccessoryRemarks = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryRemarks);

                cnx.Close();

                return dsAccessoryRemarks;
            }
        }

        public DataSet GetAccessory_SupplierPurchase_Eta_History(int SupplierPO_Id, int AccessoryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_SupplierDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPO_Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "SUPPLIER_PURCHASE_ETA_HISTORY";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryType", SqlDbType.Int);
                param.Value = AccessoryType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);

                cnx.Close();

                return dsAccessoryQuality;
            }
        }

        public int SaveAccessory_PurchaseOrder(AccessoryPending objAccessoryPurchase, int AccessoryType, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int SupplierId = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "usp_SaveAccessory_PurchaseOrder";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.AccessoryMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size", SqlDbType.VarChar);
                    param.Value = objAccessoryPurchase.Size;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    param.Value = objAccessoryPurchase.Color_Print;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Shrinkage", SqlDbType.Float);
                    param.Value = objAccessoryPurchase.Shrinkage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Wastage", SqlDbType.Float);
                    param.Value = objAccessoryPurchase.Wastage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PO_Number", SqlDbType.VarChar);
                    param.Value = objAccessoryPurchase.PoNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PO_Date", SqlDbType.Date);
                    param.Value = objAccessoryPurchase.PoDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PO_ETA", SqlDbType.Date);
                    param.Value = objAccessoryPurchase.PoEta;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GarmentUnit", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.GarmentUnit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalRate", SqlDbType.Float);
                    param.Value = objAccessoryPurchase.FinalRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedQty", SqlDbType.Decimal);
                    param.Value = objAccessoryPurchase.ReceivedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@SendQty", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.SendQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@New_GarmentUnit", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.New_GarmentUnit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@New_RecievedQty", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.New_RecievedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@New_SendQty", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.New_SendQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitChange", SqlDbType.Bit);
                    param.Value = objAccessoryPurchase.UnitChange;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConversionValue", SqlDbType.Float);
                    param.Value = objAccessoryPurchase.ConversionValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierId", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.SupplierId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsJuniorSignatory", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.IsJuniorSignatory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAuthorizedSignatory", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.IsAuthorizedSignatory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsPartySignature", SqlDbType.Int);
                    param.Value = objAccessoryPurchase.IsPartySignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryType", SqlDbType.Int);
                    param.Value = AccessoryType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    int i = cmd.ExecuteNonQuery();

                    objAccessoryPurchase.SupplierPoId = Convert.ToInt32(outParam.Value);

                    DeleteAll_AccessoryRangeEta(objAccessoryPurchase.SupplierPoId, cnx, transaction);

                    foreach (AccessoryEtaRange objAccessoryEtaRange in objAccessoryPurchase.AccessoryEtaRangeDetail)
                    {
                        SaveAccessoryRangeEta(objAccessoryEtaRange, objAccessoryPurchase.SupplierPoId, UserId, cnx, transaction);
                    }

                    // Update Min Eta Date
                    Update_MinPOETADate(objAccessoryPurchase, AccessoryType, UserId, cnx, transaction);

                    SupplierId = objAccessoryPurchase.SupplierPoId;

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    SupplierId = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return SupplierId;
            }
        }

        #region PO Working Screen
        private int DeleteAll_AccessoryRangeEta(int SupplierPoId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "usp_DeleteAll_AccessoryRangeEta";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
            param.Value = SupplierPoId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        private int SaveAccessoryRangeEta(AccessoryEtaRange objAccessoryEtaRange, int SupplierPoId, int UserId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "usp_SaveAccessoryEta_PurchaseOrder";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@SupplierPO_ETA_Id", SqlDbType.Int);
            param.Value = objAccessoryEtaRange.SupplierPoEtaId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
            param.Value = SupplierPoId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FromQty", SqlDbType.Int);
            param.Value = objAccessoryEtaRange.FromQty;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ToQty", SqlDbType.Int);
            param.Value = objAccessoryEtaRange.ToQty;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@POETADate", SqlDbType.Date);
            param.Value = objAccessoryEtaRange.POETADate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserId", SqlDbType.Int);
            param.Value = UserId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        private int Update_MinPOETADate(AccessoryPending objAccessoryPurchase, int SupplyType, int UserId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "usp_Update_MinPOETADate";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
            param.Value = objAccessoryPurchase.SupplierPoId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
            param.Value = objAccessoryPurchase.AccessoryMasterId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Size", SqlDbType.VarChar);
            param.Value = objAccessoryPurchase.Size;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
            param.Value = objAccessoryPurchase.Color_Print;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SupplyType", SqlDbType.Int);
            param.Value = SupplyType;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserId", SqlDbType.Int);
            param.Value = UserId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        public List<AccessoryPending> GetAccessory_SupplierPO_DETAILS(int AccessoryMasterId, string Size, string ColorPrint, int AccessoryType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_SupplierDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "PO_DETAILS";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryType", SqlDbType.Int);
                param.Value = AccessoryType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();
                        objAccessoryPending.SupplierPoId = (reader["SupplierPO_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplierPO_Id"]);
                        objAccessoryPending.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryPending.SupplierId = (reader["supplierId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["supplierId"]);
                        objAccessoryPending.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryPending.ReceivedQty = (reader["ReceivedQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ReceivedQty"]);
                        objAccessoryPending.SendQty = (reader["SendQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SendQty"]);
                        objAccessoryPending.IsJuniorSignatory = (reader["IsJuniorSignatory"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsJuniorSignatory"]);
                        objAccessoryPending.IsAuthorizedSignatory = (reader["IsAuthorizedSignatory"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAuthorizedSignatory"]);
                        objAccessoryPending.IsPartySignature = (reader["IsPartySignature"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsPartySignature"]);
                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public int Delete_AccessoryPO(int SupplierPoId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int iDelete = 0;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "usp_Delete_AccessoryPO";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                    param.Value = SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    iDelete = cmd.ExecuteNonQuery();

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    iDelete = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return iDelete;
            }
        }

        public List<AccessoryPending> GetRaisedPO_AccessoryWorking(int SupplierPoId, int OrderDetailId, string Searchtxt, string type, int Status,int DropDownType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetRaisedPO_AccessoryWorking";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = Status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DropDownType", SqlDbType.Int);
                param.Value = DropDownType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryPending> AccessoryPendingCollection = new List<AccessoryPending>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryPending objAccessoryPending = new AccessoryPending();

                        objAccessoryPending.AccessoryMasterId = (reader["AccessoryMasterId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryMasterId"]);
                        objAccessoryPending.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);

                        objAccessoryPending.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryPending.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);

                        objAccessoryPending.SupplierPoId = (reader["SupplierPO_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplierPO_Id"]);
                        objAccessoryPending.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryPending.PoDate = (reader["PODate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PODate"]);
                        objAccessoryPending.CommitedStartDate = (reader["CommitedStartDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CommitedStartDate"]);
                        objAccessoryPending.PoEta = (reader["CommitedEndDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CommitedEndDate"]);
                        objAccessoryPending.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);

                        objAccessoryPending.ReceivedQty = (reader["TotalPoQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["TotalPoQty"]);
                        objAccessoryPending.TotalQtyRecieved = (reader["TotalQtyRcvd"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalQtyRcvd"]);
                        objAccessoryPending.TotalPassQty = (reader["TotalPassQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPassQty"]);
                        objAccessoryPending.TotalCheckedQty = (reader["TotalCheckedQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalCheckedQty"]);
                        objAccessoryPending.TotalFailQty = (reader["TotalFailQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalFailQty"]);
                        objAccessoryPending.TotalHoldQty = (reader["TotalHoldQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalHoldQty"]);
                        objAccessoryPending.TotalSendChallanQty = (reader["SendChallanQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["SendChallanQty"]);

                        objAccessoryPending.SendQty = (reader["SendQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["SendQty"]);
                        objAccessoryPending.Status = (reader["Status"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Status"]);
                        objAccessoryPending.AccessoryType = (reader["AccessoryType"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryType"]);
                        objAccessoryPending.SupplyType = (reader["SupplyType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplyType"]);
                        objAccessoryPending.IsPartySignature = (reader["IsPartySignature"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsPartySignature"]);
                        objAccessoryPending.IsAuthorizedSignatory = (reader["IsAuthorizedSignatory"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAuthorizedSignatory"]);
                        objAccessoryPending.SrvCount = (reader["SrvCount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SrvCount"]);
                        objAccessoryPending.TotalRecChallanQty = (reader["ReceivedChallanQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["ReceivedChallanQty"]);
                        objAccessoryPending.GreigePassQty = (reader["GriegePassQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["GriegePassQty"]);

                        objAccessoryPending.GarmentUnitName = (reader["NewUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["NewUnitName"]);
                        objAccessoryPending.DefaultGarmentUnitName = (reader["UnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["UnitName"]);
                        objAccessoryPending.UnitChange = (reader["UnitChange"] == DBNull.Value) ? false : Convert.ToBoolean(reader["UnitChange"]);
                        objAccessoryPending.ConversionValue = (reader["ConversionValue"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ConversionValue"]);
                        objAccessoryPending.UsableStockQty = (reader["UsableStockQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["UsableStockQty"]);
                        objAccessoryPending.InspectUsableStock = (reader["InspectUsableStock"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["InspectUsableStock"]);
                        objAccessoryPending.IsAccessoryGM = (reader["IsAccessoryGM"] == DBNull.Value) ? Convert.ToBoolean(0) : Convert.ToBoolean(reader["IsAccessoryGM"]);

                        AccessoryPendingCollection.Add(objAccessoryPending);
                    }
                }

                return AccessoryPendingCollection;
            }
        }

        public bool AccessoryCancel_Close_PO(int SupplierPoId, string field)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "Usp_update_Cancel_Close_From_Working_Screen_Acc";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@Po_ID", SqlDbType.Int);
                paramIn.Value = SupplierPoId;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Flag", SqlDbType.NVarChar);
                paramIn.Value = field;
                cmd.Parameters.Add(paramIn);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            return true;
        }
        #endregion End PO Working Screen

        #region SRV Work
        public List<AccessorySRV> GetRaisedPO_SRV_Detail(int SupplierPoId, string type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetRaisedPO_AccessoryWorking";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessorySRV> AccessorySRVCollection = new List<AccessorySRV>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessorySRV objAccessorySRV = new AccessorySRV();

                        objAccessorySRV.SRV_Id = (reader["SRV_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SRV_Id"]);
                        objAccessorySRV.PartyChallanNumber = (reader["PartyChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyChallanNumber"]);
                        objAccessorySRV.ReceivedUnit = (reader["ReceivedUnit"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ReceivedUnit"]);
                        objAccessorySRV.GateNo = (reader["GateNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GateNumber"]);
                        objAccessorySRV.ReceivedQty = (reader["ReceivedQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ReceivedQty"]);
                        objAccessorySRV.ReceivedUnitName = (reader["UnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["UnitName"]);
                        objAccessorySRV.InspectionId = (reader["Inspection_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Inspection_Id"]);
                        objAccessorySRV.InspectionCheckedQty = (reader["CheckedQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["CheckedQty"]);
                        objAccessorySRV.PassQty = (reader["PassQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["PassQty"]);
                        objAccessorySRV.FailQty = (reader["FailQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["FailQty"]);
                        objAccessorySRV.HoldQty = (reader["HoldQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["HoldQty"]);
                        objAccessorySRV.InspectionRaisedDebit = (reader["InspectRaiseDebit"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["InspectRaiseDebit"]);
                        objAccessorySRV.InspectionUsableStock = (reader["InspectUsableStock"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["InspectUsableStock"]);

                        AccessorySRVCollection.Add(objAccessorySRV);
                    }
                }

                return AccessorySRVCollection;
            }
        }

        public AccessorySRV Get_AccessorySRV(int SupplierPoId, int SrvId)
        {
            AccessorySRV objAccessorySRV = new AccessorySRV();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_AccessorySRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = SrvId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "SRV_DETAIL";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objAccessorySRV.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        objAccessorySRV.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessorySRV.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        objAccessorySRV.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessorySRV.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessorySRV.GarmentUnitName = (reader["GarmentUnit"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GarmentUnit"]);
                        objAccessorySRV.DefaultGarmentUnitName = (reader["DefaultUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DefaultUnitName"]);
                        objAccessorySRV.UnitChange = (reader["UnitChange"] == DBNull.Value) ? false : Convert.ToBoolean(reader["UnitChange"]);
                        objAccessorySRV.ConversionValue = (reader["ConversionValue"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["ConversionValue"]);
                        objAccessorySRV.ReceivedQty = (reader["ReceivedQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ReceivedQty"]);     //modified by raghvinder on 09-11-2020
                        objAccessorySRV.DefaultRecievedQty = (reader["DefaultRecievedQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["DefaultRecievedQty"]);     //modified by raghvinder on 09-11-2020
                        objAccessorySRV.ActualReceivedQty = (reader["ActualReceivedQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ActualReceivedQty"]);     //modified by raghvinder on 09-11-2020

                        objAccessorySRV.Shrinkage = (reader["Shrinkage"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Shrinkage"]);
                        objAccessorySRV.Wastage = (reader["Wastage"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Wastage"]);
                        objAccessorySRV.FinalRate = (reader["Rate"] == DBNull.Value) ? -1 : Convert.ToDouble(reader["Rate"]);
                        objAccessorySRV.IsPartySignature = (reader["IsPartySignature"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsPartySignature"]);
                        objAccessorySRV.IsAuthorizedSignatory = (reader["IsAuthorizedSignatory"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAuthorizedSignatory"]);

                        objAccessorySRV.Receiving_Voucher_No = (reader["Receiving_Voucher_No"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Receiving_Voucher_No"]);
                        objAccessorySRV.SRV_Id = (reader["SRV_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SRV_Id"]);
                        objAccessorySRV.SRVDate = (reader["SRVDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SRVDate"]);
                        objAccessorySRV.PartyChallanNumber = (reader["PartyChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyChallanNumber"]);
                        objAccessorySRV.ReceivedUnit = (reader["ReceivedUnit"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ReceivedUnit"]);
                        objAccessorySRV.GateNo = (reader["GateNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GateNumber"]);
                        objAccessorySRV.srvRemark = (reader["Remarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Remarks"]);
                        objAccessorySRV.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objAccessorySRV.PartyBillNumber = (reader["PartyBillNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyBillNo"]);
                        objAccessorySRV.PartyBillDate = (reader["PartyBillDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PartyBillDate"]);
                        objAccessorySRV.Amount = (reader["Amount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Amount"]);

                        objAccessorySRV.BIPLAddress = (reader["BIPLAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLAddress"]);
                        objAccessorySRV.SupplierId = (reader["supplier_master_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["supplier_master_Id"]);
                        objAccessorySRV.StoreInchargeId = (reader["IsStoreIncharge"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsStoreIncharge"]);
                        objAccessorySRV.QtyCheckedBy = (reader["IsQtyChecked"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsQtyChecked"]);
                        objAccessorySRV.StoreInchargeCheckedDate = (reader["StoreInchargeDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["StoreInchargeDate"]);
                        objAccessorySRV.QtyCheckedDate = (reader["QtyCheckedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["QtyCheckedDate"]);
                        objAccessorySRV.IsFourPointCheckedByGM = (reader["IsFourPointCheckedByGM"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsFourPointCheckedByGM"]);
                    }
                }

                return objAccessorySRV;
            }
        }

        public List<Accessory_Srv_Bill> GetAccessory_Srv_BillDetail(int SupplierPoId, int PartyBillId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessorySRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "BILL_DETAIL";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PartyBillId", SqlDbType.Int);
                param.Value = PartyBillId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Accessory_Srv_Bill> AccessorySRVCollection = new List<Accessory_Srv_Bill>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Accessory_Srv_Bill objSrvBill = new Accessory_Srv_Bill();

                        objSrvBill.SRV_Id = (reader["SRV_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SRV_Id"]);
                        objSrvBill.PartyChallanNumber = (reader["PartyChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyChallanNumber"]);
                        objSrvBill.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        //objSrvBill.PartyBillNumber = (reader["PartyBillNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyBillNo"]);
                        //objSrvBill.PartyBillDate = (reader["PartyBillDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PartyBillDate"]);
                        //objSrvBill.Amount = (reader["Amount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Amount"]);
                        objSrvBill.IsChecked = (reader["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsChecked"]);

                        AccessorySRVCollection.Add(objSrvBill);
                    }
                }

                return AccessorySRVCollection;
            }
        }

        public int SaveAccessory_Srv(AccessorySRV objAccessorySRV, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Insert_Update_AccessorySRV";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = objAccessorySRV.SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvId", SqlDbType.Int);
                    param.Value = objAccessorySRV.SRV_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SRVDate", SqlDbType.Date);
                    param.Value = objAccessorySRV.SRVDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyChallanNumber", SqlDbType.VarChar);
                    param.Value = objAccessorySRV.PartyChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GateNumber", SqlDbType.VarChar);
                    param.Value = objAccessorySRV.GateNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedUnit", SqlDbType.Int);
                    param.Value = objAccessorySRV.ReceivedUnit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedQty", SqlDbType.Decimal);
                    param.Value = objAccessorySRV.ReceivedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar, 1000);
                    param.Value = objAccessorySRV.srvRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsStoreIncharge", SqlDbType.Int);
                    param.Value = objAccessorySRV.StoreInchargeId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsQtyChecked", SqlDbType.Int);
                    param.Value = objAccessorySRV.QtyCheckedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsSigned", SqlDbType.VarChar);
                    param.Value = objAccessorySRV.IsSigned;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StoreInchargeDate", SqlDbType.DateTime);
                    if (objAccessorySRV.StoreInchargeCheckedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objAccessorySRV.StoreInchargeCheckedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QtyCheckedDate", SqlDbType.DateTime);
                    if (objAccessorySRV.QtyCheckedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = objAccessorySRV.QtyCheckedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    foreach (Accessory_Srv_Bill objSrvBill in objAccessorySRV.Accessory_Srv_BillList)
                    {
                        Save_AccessorySrv_Bill(objSrvBill, UserId, cnx, transaction);
                    }

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }

        private int Save_AccessorySrv_Bill(Accessory_Srv_Bill objSrvBill, int UserId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "sp_Save_AccessorySrv_Bill";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
            param.Value = objSrvBill.SupplierPoId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartyBillId", SqlDbType.Int);
            param.Value = objSrvBill.PartyBillId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartyBillNumber", SqlDbType.VarChar);
            param.Value = objSrvBill.PartyBillNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartyBillDate", SqlDbType.Date);
            param.Value = objSrvBill.PartyBillDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Int);
            param.Value = objSrvBill.Amount;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SrvId", SqlDbType.Int);
            param.Value = objSrvBill.SRV_Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@UserId", SqlDbType.Int);
            param.Value = UserId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        public string CheckChallanNumber(int SupplierPoId, int SRV_Id, string PartyChallanNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string ValidString = "";

                try
                {
                    cnx.Open();

                    string cmdText = "USP_Get_AccessorySRV";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvId", SqlDbType.Int);
                    param.Value = SRV_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyChallanNumber", SqlDbType.VarChar);
                    param.Value = PartyChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@type", SqlDbType.VarChar);
                    param.Value = "CHECK_CHALLAN_NUMBER";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    ValidString = cmd.ExecuteScalar().ToString();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    ValidString = string.Empty;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return ValidString;
            }
        }

        public string Save_Accessory_Description(int OrderDetailId, string ComVal)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string ValidString = "";

                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "USP_Update_Acc_DetailDescription";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    paramIn.Value = OrderDetailId;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@Description", SqlDbType.NVarChar);
                    paramIn.Value = ComVal;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    cnx.Close();




                }
                catch (SqlException ex)
                {
                    ValidString = string.Empty;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return ValidString;
            }
        }

        //Added by shubhendu 4/02/2022
        public string Save_Accessory_AccessoryRemarks(int orderid, string ComVal)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                string ValidString = "";

                try
                {
                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "USP_Update_Acc_AccessoryRemarks";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@OrderID", SqlDbType.Int);
                    paramIn.Value = orderid;
                    cmd.Parameters.Add(paramIn);

                    paramIn = new SqlParameter("@AccessoryRemarksDescription", SqlDbType.VarChar);
                    paramIn.Value = ComVal;
                    cmd.Parameters.Add(paramIn);

                    cmd.ExecuteNonQuery();
                    cnx.Close();




                }
                catch (SqlException ex)
                {
                    ValidString = string.Empty;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return ValidString;
            }
        }
        #endregion SRV Work

        #region Debit Note Work
        public List<AccessoryDebitNoteCls> GetAccessoryDebitNoteList(int SupplierPoId, string Searchtxt)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryDebitNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "DEBITNOTE_LIST";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryDebitNoteCls> AccessoryDebitNoteCollection = new List<AccessoryDebitNoteCls>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryDebitNoteCls objAccessoryDebitNote = new AccessoryDebitNoteCls();

                        objAccessoryDebitNote.DebitNoteId = (reader["DebitNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DebitNote_Id"]);
                        objAccessoryDebitNote.DebitNoteNumber = (reader["DebitNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DebitNoteNumber"]);
                        objAccessoryDebitNote.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objAccessoryDebitNote.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryDebitNote.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);

                        objAccessoryDebitNote.ReturnChallanId = (reader["Challan_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Challan_Id"]);
                        objAccessoryDebitNote.ReturnChallanNumber = (reader["ReturnChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReturnChallanNumber"]);
                        objAccessoryDebitNote.ChallanDate = (reader["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);
                        objAccessoryDebitNote.BIPLAddress = (reader["BIPLAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLAddress"]);

                        objAccessoryDebitNote.PartyBillNumber = (reader["PartyBillNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyBillNo"]);
                        objAccessoryDebitNote.PartyBillDate = (reader["PartyBillDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PartyBillDate"]);
                        objAccessoryDebitNote.Amount = (reader["Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount"]);

                        AccessoryDebitNoteCollection.Add(objAccessoryDebitNote);
                    }
                }

                return AccessoryDebitNoteCollection;
            }
        }

        public AccessoryDebitNoteCls Get_AccessoryDebitNote(int SupplierPoId, int DebitNoteId, int PartyBillId)
        {
            AccessoryDebitNoteCls objAccessoryDebitNote = new AccessoryDebitNoteCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryDebitNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "DEBITNOTE_HEADER";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objAccessoryDebitNote.DebitNoteId = (reader["DebitNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["DebitNote_Id"]);
                        objAccessoryDebitNote.DebitNoteNumber = (reader["DebitNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DebitNoteNumber"]);
                        objAccessoryDebitNote.GSTNo = (reader["GSTNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GSTNo"]);//new line
                        objAccessoryDebitNote.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objAccessoryDebitNote.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryDebitNote.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryDebitNote.PoDate = (reader["PoDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PoDate"]);
                        objAccessoryDebitNote.ReturnChallanNumber = (reader["ReturnChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReturnChallanNumber"]);
                        objAccessoryDebitNote.ChallanDate = (reader["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);
                        objAccessoryDebitNote.DebitNoteDate = (reader["DebitNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DebitNoteDate"]);
                        objAccessoryDebitNote.BIPLAddress = (reader["BIPLAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLAddress"]);
                        objAccessoryDebitNote.IGST = (reader["IGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["IGST"]);
                        objAccessoryDebitNote.CGST = (reader["CGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["CGST"]);
                        objAccessoryDebitNote.SGST = (reader["SGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["SGST"]);
                        objAccessoryDebitNote.SRVQuantity = (reader["SRVQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["SRVQuantity"]);
                        objAccessoryDebitNote.IsDebitNoteSigned = (reader["IsSigned"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsSigned"]);
                        objAccessoryDebitNote.DebitNoteSignDate = (reader["SignDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SignDate"]);
                        objAccessoryDebitNote.DebitNoteSignedBy = (reader["SignedBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SignedBy"]);
                        objAccessoryDebitNote.AuthSignature = (reader["SignaturePath"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SignaturePath"]);
                        objAccessoryDebitNote.GarmentUnitName = (reader["GarmentUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GarmentUnitName"]);
                        objAccessoryDebitNote.PartyBillNumber = (reader["PartyBillNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyBillNo"]);
                        //objAccessoryDebitNote.TotalFailQty = (reader["POFailQty"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["POFailQty"]);
                        objAccessoryDebitNote.AccQualityName = (reader["TradeName"] == DBNull.Value) ? "" : reader["TradeName"].ToString();
                        objAccessoryDebitNote.AccColor_Print = (reader["Color_Print"] == DBNull.Value) ? "" : reader["Color_Print"].ToString();

                        objAccessoryDebitNote.SupplierGstNo = (reader["GSTNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GSTNo"]);

                        objAccessoryDebitNote.SupplierAddress = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);
                        //rajeevS
                        objAccessoryDebitNote.HSNCode = reader["HSNCode"].ToString();
                        //rajeevS

                    }
                }
                reader.Dispose();
                objAccessoryDebitNote.AccessoryDebitNoteParticularsList = AccessoryDebitNoteParticulars(SupplierPoId, DebitNoteId, PartyBillId, cnx);

                return objAccessoryDebitNote;
            }
        }

        private List<AccessoryDebitNoteParticulars> AccessoryDebitNoteParticulars(int SupplierPoId, int DebitNoteId, int PartyBillId, SqlConnection cnx)
        {

            string cmdText = "USP_Get_AccessoryDebitNote";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
            param.Value = SupplierPoId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
            param.Value = DebitNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartyBillId", SqlDbType.Int);
            param.Value = PartyBillId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "DEBITNOTE_PARTICULAR";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataReader reader1;

            reader1 = cmd.ExecuteReader();

            List<AccessoryDebitNoteParticulars> DebitNoteParticularsCollection = new List<AccessoryDebitNoteParticulars>();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    AccessoryDebitNoteParticulars objDebitNoteParticulars = new Common.AccessoryDebitNoteParticulars();

                    objDebitNoteParticulars.DebitNoteId = (reader1["DebitNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["DebitNote_Id"]);
                    objDebitNoteParticulars.DebitNoteParticularId = (reader1["DebitNote_Particulers_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["DebitNote_Particulers_Id"]);
                    objDebitNoteParticulars.Acc_DebitNote_SRVID = (reader1["Acc_DebitNote_SrvID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["Acc_DebitNote_SrvID"]);

                    objDebitNoteParticulars.DebitQuantity = (reader1["DebitQty"] == DBNull.Value) ? 0 : Convert.ToDouble(reader1["DebitQty"]);
                    objDebitNoteParticulars.ParticularName = (reader1["Particulars"] == DBNull.Value) ? string.Empty : Convert.ToString(reader1["Particulars"]);

                    objDebitNoteParticulars.DebitRate = (reader1["Rate"] == DBNull.Value) ? 0 : Convert.ToDouble(reader1["Rate"]);
                    objDebitNoteParticulars.IsExtraQty = (reader1["IsExtraQty"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["IsExtraQty"]);
                    objDebitNoteParticulars.SrvNo = (reader1["SRV_Id"] == DBNull.Value) ? " " : reader1["SRV_Id"].ToString();
                    objDebitNoteParticulars.PartyBillNumber = (reader1["PartyBillNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader1["PartyBillNo"]);

                    DebitNoteParticularsCollection.Add(objDebitNoteParticulars);
                }
            }

            return DebitNoteParticularsCollection;
        }

        public List<Accessory_Srv_Bill> GetAccessory_Srv_Bill_DropDownList(int SupplierPoId, int DebitNoteId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_Accessory_Srv_Bill";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Accessory_Srv_Bill> Accessory_Srv_BillCollection = new List<Accessory_Srv_Bill>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Accessory_Srv_Bill objAccessory_Srv_Bill = new Accessory_Srv_Bill();

                        objAccessory_Srv_Bill.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objAccessory_Srv_Bill.BillDetails = (reader["BillDetails"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BillDetails"]);

                        Accessory_Srv_BillCollection.Add(objAccessory_Srv_Bill);
                    }
                }
                return Accessory_Srv_BillCollection;
            }
        }

        public int Save_Accessory_DebitNote(AccessoryDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1, DebitNoteId = 0;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Accessory_DebitNote";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteNumber", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.DebitNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.DebitNoteDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.DebitNoteDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyBillId", SqlDbType.Int);
                    param.Value = objAccessoryDebitNote.PartyBillId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReturnChallanNo", SqlDbType.VarChar);
                    param.Value = objAccessoryDebitNote.ReturnChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDate", SqlDbType.Date);
                    if (objAccessoryDebitNote.ChallanDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryDebitNote.ChallanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.IGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.CGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SGST", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.SGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalAmount", SqlDbType.Float);
                    param.Value = objAccessoryDebitNote.TotalAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsSigned", SqlDbType.Bit);
                    param.Value = objAccessoryDebitNote.IsDebitNoteSigned;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@ReturnDebitNoteId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    count = cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                    {
                        objAccessoryDebitNote.DebitNoteId = Convert.ToInt32(outParam.Value);
                        DebitNoteId = Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        objAccessoryDebitNote.DebitNoteId = -1;
                    }

                    foreach (AccessoryDebitNoteParticulars objDebitNoteParticulars in objAccessoryDebitNote.AccessoryDebitNoteParticularsList)
                    {
                        Save_Accessory_DebitNotePartyCulars(objDebitNoteParticulars, objAccessoryDebitNote.DebitNoteId, UserId, cnx, transaction);
                    }

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                //return count;
                return DebitNoteId;
            }
        }

        private int Save_Accessory_DebitNotePartyCulars(AccessoryDebitNoteParticulars objDebitNoteParticulars, int DebitNoteId, int UserId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "sp_Save_Accessory_DebitNotePartyCulars";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
            param.Value = DebitNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DebitNotePartyCularId", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.DebitNoteParticularId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Acc_DebitNote_SRVID", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.Acc_DebitNote_SRVID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Particulars", SqlDbType.VarChar);
            param.Value = objDebitNoteParticulars.ParticularName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IsExtraQty", SqlDbType.Int);
            param.Value = objDebitNoteParticulars.IsExtraQty;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Float);
            param.Value = objDebitNoteParticulars.DebitQuantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objDebitNoteParticulars.DebitRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserId", SqlDbType.Int);
            param.Value = UserId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "SAVE";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        public int Update_Accessory_DebitNotePartyCulars(AccessoryDebitNoteParticulars objDebitNoteParticulars, int UserId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Accessory_DebitNotePartyCulars";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNotePartyCularId", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitNoteParticularId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Acc_DebitNote_SRVID", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.Acc_DebitNote_SRVID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulars", SqlDbType.VarChar);
                    param.Value = objDebitNoteParticulars.ParticularName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Int);
                    param.Value = objDebitNoteParticulars.DebitRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();


                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }

        #endregion Debit Note Work

        #region Challan Work
        public List<AccessoryChallanCls> GetRaisedPO_Challan_Detail(int SupplierPoId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetRaisedPO_AccessoryWorking";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryChallanCls> AccessoryChallanCollection = new List<AccessoryChallanCls>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();

                        objAccessoryChallan.ChallanId = (reader["SendChallanId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SendChallanId"]);
                        objAccessoryChallan.ChallanNumber = (reader["SendChallanNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SendChallanNo"]);
                        objAccessoryChallan.IsChallanRecieved = (reader["IsChallanRecieved"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsChallanRecieved"]);

                        AccessoryChallanCollection.Add(objAccessoryChallan);
                    }
                }

                return AccessoryChallanCollection;
            }
        }


        public AccessoryChallanCls Get_AccessoryChallan(int SupplierPoId, int DebitNoteId, int ChallanId)
        {
            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "CHALLAN_HEADER";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objAccessoryChallan.ChallanId = (reader["Challan_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Challan_Id"]);
                        objAccessoryChallan.ChallanNumber = (reader["ChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ChallanNumber"]);
                        objAccessoryChallan.ChallanDate = (reader["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);
                        objAccessoryChallan.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryChallan.ChallanType = (reader["ChallanType"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ChallanType"]);
                        objAccessoryChallan.AccessoryMasterId = (reader["AccessoryMasterId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryMasterId"]);
                        objAccessoryChallan.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        objAccessoryChallan.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryChallan.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        objAccessoryChallan.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryChallan.ChallanDesc = (reader["ChallanDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ChallanDescription"]);
                        //objAccessoryChallan.AccessoryUnitId = (reader["GroupUnitId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GroupUnitId"]);                        
                        objAccessoryChallan.IsPartySignature = (reader["IsReceived"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsReceived"]);
                        objAccessoryChallan.IsAuthorizedSignatory = (reader["IsAuthorized"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAuthorized"]);
                        objAccessoryChallan.ReceivedDate = (reader["ReceivedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ReceivedDate"]);
                        objAccessoryChallan.AuthorizedDate = (reader["AuthorizedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AuthorizedDate"]);
                        objAccessoryChallan.RecievedBy = (reader["RecievedBy"] == DBNull.Value) ? string.Empty : reader["RecievedBy"].ToString();
                        objAccessoryChallan.AuthoriseBy = (reader["AuthorisedBy"] == DBNull.Value) ? string.Empty : reader["AuthorisedBy"].ToString();
                        objAccessoryChallan.TotalPcs = (reader["TotalPcs"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPcs"]);
                        objAccessoryChallan.BalanceQty = (reader["AvailableQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["AvailableQty"]);
                        objAccessoryChallan.ProductionUnitId = (reader["UnitID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitID"]);
                        objAccessoryChallan.GarmentUnitName = (reader["GarmentUnitName"] == DBNull.Value) ? string.Empty : reader["GarmentUnitName"].ToString();
                        objAccessoryChallan.TotalRecChallanQty = (reader["ReceivedChallanQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["ReceivedChallanQty"]);
                        objAccessoryChallan.UnitCount = (reader["UnitCount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitCount"]);
                        objAccessoryChallan.SupplyType = (reader["SupplyType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplyType"]);

                        objAccessoryChallan.SupplierGstNo = (reader["GSTNo"] == DBNull.Value) ? string.Empty : reader["GSTNo"].ToString();
                        objAccessoryChallan.SupplierAddress = (reader["Address"] == DBNull.Value) ? string.Empty : reader["Address"].ToString();
                        objAccessoryChallan.HSNCode = (reader["HSNCode"] == DBNull.Value) ? string.Empty : reader["HSNCode"].ToString();

                    }
                }
                //reader.Dispose();
                //objAccessoryChallan.ChallanBreakDownList = AccessoryChallanBreakDown(objAccessoryChallan.ChallanId, cnx);

                return objAccessoryChallan;
            }
        }

        public AccessoryChallanCls Get_AccessoryChallan(int ChallanId, int OrderDetailId, int AccessoryMasterId, string Size, string ColorPrint)
        {
            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "INTERNAL_CHALLAN";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanId", SqlDbType.Int);
                param.Value = ChallanId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objAccessoryChallan.ChallanId = (reader["Challan_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Challan_Id"]);
                        objAccessoryChallan.ChallanNumber = (reader["ChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ChallanNumber"]);
                        objAccessoryChallan.ChallanDate = (reader["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);

                        objAccessoryChallan.ChallanType = (reader["ChallanType"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ChallanType"]);
                        objAccessoryChallan.AccessoryMasterId = (reader["AccessoryMasterId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryMasterId"]);
                        objAccessoryChallan.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        objAccessoryChallan.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryChallan.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);

                        objAccessoryChallan.ChallanDesc = (reader["ChallanDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ChallanDescription"]);

                        objAccessoryChallan.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        objAccessoryChallan.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        objAccessoryChallan.TotalPcs = (reader["TotalPcs"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalPcs"]);
                        objAccessoryChallan.IsPartySignature = (reader["IsReceived"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsReceived"]);
                        objAccessoryChallan.IsAuthorizedSignatory = (reader["IsAuthorized"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAuthorized"]);
                        objAccessoryChallan.ReceivedDate = (reader["ReceivedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ReceivedDate"]);
                        objAccessoryChallan.AuthorizedDate = (reader["AuthorizedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AuthorizedDate"]);
                        objAccessoryChallan.RecievedBy = (reader["RecievedBy"] == DBNull.Value) ? string.Empty : reader["RecievedBy"].ToString();
                        objAccessoryChallan.AuthoriseBy = (reader["AuthorisedBy"] == DBNull.Value) ? string.Empty : reader["AuthorisedBy"].ToString();
                        objAccessoryChallan.ProductionUnitId = (reader["UnitID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["UnitID"]);
                        objAccessoryChallan.GarmentUnitName = (reader["GarmentUnitName"] == DBNull.Value) ? string.Empty : reader["GarmentUnitName"].ToString();
                        objAccessoryChallan.TotalRecChallanQty = (reader["ReceivedChallanQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["ReceivedChallanQty"]);
                        objAccessoryChallan.UnitCount = (reader["UnitCount"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["UnitCount"]);
                    }
                }
                reader.Dispose();
                objAccessoryChallan.ChallanBreakDownList = AccessoryChallanBreakDown(objAccessoryChallan.ChallanId, cnx);



                return objAccessoryChallan;
            }
        }



        public AccessoryGstRateTotalAmount AccessoryGstRateTotalAmount(int SupplierPoid, int challanId, string Flag)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                //SqlDataReader reader;
                //   SqlCommand cmd;
                // string cmdText;

                string cmdText = "USP_Get_AccessoryChallan";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoID", SqlDbType.Int);
                param.Value = SupplierPoid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanId ", SqlDbType.Int);
                param.Value = challanId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader1;

                reader1 = cmd.ExecuteReader();

                //List<AccessoryGstRateTotalAmount> AccessoryGstRateTotalAmount = new List<AccessoryGstRateTotalAmount>();
                AccessoryGstRateTotalAmount objAccessoryGstRateTotalAmount = new Common.AccessoryGstRateTotalAmount();

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {                        
                        objAccessoryGstRateTotalAmount.Gst = (reader1["GST"] == DBNull.Value) ? 0 : Convert.ToInt32(reader1["GST"]);
                        objAccessoryGstRateTotalAmount.Rate = (reader1["Rate"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader1["Rate"]);
                        objAccessoryGstRateTotalAmount.TotalAmount = (reader1["TotalAmount"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader1["TotalAmount"]);
                        objAccessoryGstRateTotalAmount.GSTno = (reader1["GSTno"] == DBNull.Value) ? string.Empty : Convert.ToString(reader1["GSTno"]);
                    }
                    // AccessoryGstRateTotalAmount.Add(objAccessoryGstRateTotalAmount);
                }

                return objAccessoryGstRateTotalAmount;
            }
        }

        private List<AccessoryChallanBreakDown> AccessoryChallanBreakDown(int ChallanId, SqlConnection cnx)
        {

            string cmdText = "USP_Get_AccessoryChallan";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@ChallanId", SqlDbType.Int);
            param.Value = ChallanId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "CHALLAN_BREAKDOWN";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataReader reader1;

            reader1 = cmd.ExecuteReader();

            List<AccessoryChallanBreakDown> ChallanBreakDownCollection = new List<AccessoryChallanBreakDown>();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    AccessoryChallanBreakDown objChallanBreakDown = new Common.AccessoryChallanBreakDown();

                    objChallanBreakDown.Challan_BreakDown_Id = (reader1["Challan_BreakDown_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["Challan_BreakDown_Id"]);
                    objChallanBreakDown.Pcs = (reader1["Pcs"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["Pcs"]);
                    objChallanBreakDown.RowNo = (reader1["RowNum"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["RowNum"]);
                    ChallanBreakDownCollection.Add(objChallanBreakDown);
                }
            }

            return ChallanBreakDownCollection;
        }
        public DataTable GetChallanProcessListForPdf(int ChallanId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ChallanId", SqlDbType.Int);
                param.Value = ChallanId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "CHALLAN_PROCESS";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //reader = cmd.ExecuteReader();
                //return ChallanProcessCollection;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cnx.Close();
                return dt;

            }
        }

        public List<ChallanProcess> GetChallanProcessList(int ChallanId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@ChallanId", SqlDbType.Int);
                param.Value = ChallanId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "CHALLAN_PROCESS";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<ChallanProcess> ChallanProcessCollection = new List<ChallanProcess>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ChallanProcess objChallanProcess = new ChallanProcess();

                        objChallanProcess.ChallanProcessId = (reader["Challan_Process_Admin_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Challan_Process_Admin_Id"]);
                        objChallanProcess.ProcessName = (reader["ProcessName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ProcessName"]);
                        objChallanProcess.IsChecked = (reader["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsChecked"]);
                        ChallanProcessCollection.Add(objChallanProcess);
                    }
                }

                return ChallanProcessCollection;
            }
        }

        public List<GroupUnit> GetGroupUnitList()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GROUP_UNIT";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<GroupUnit> GroupUnitCollection = new List<GroupUnit>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GroupUnit objGroupUnit = new GroupUnit();

                        objGroupUnit.GroupUnitID = (reader["GroupUnitID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GroupUnitID"]);
                        objGroupUnit.UnitName = (reader["UnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["UnitName"]);

                        GroupUnitCollection.Add(objGroupUnit);
                    }
                }

                return GroupUnitCollection;
            }
        }



        //To Save Accessory Internal Challan Start : Created By Girish
        public Boolean Save_Accessory_Internal_Challan(SaveAccessoryInternalChallan SaveAccessoryInternalChallan, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Accessory_Internal_Challan";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                    param.Value = SaveAccessoryInternalChallan.ChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDate", SqlDbType.DateTime);
                    param.Value = SaveAccessoryInternalChallan.ChallanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProductionUnitId", SqlDbType.Int);
                    param.Value = SaveAccessoryInternalChallan.ProductionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsReceived", SqlDbType.Bit);
                    param.Value = 0;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAuthorized", SqlDbType.Bit);
                    param.Value = 0;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AuthorizedDate", SqlDbType.Date);
                    param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedDate", SqlDbType.Date);
                    param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProcessIds", SqlDbType.VarChar);
                    param.Value = SaveAccessoryInternalChallan.ProcessIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GSTNo", SqlDbType.VarChar);
                    param.Value = SaveAccessoryInternalChallan.GSTNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    int currentIteration = 1;

                    foreach (AccessoryInternalChallanGridData AccessoryInternalChallanGridData in SaveAccessoryInternalChallan.GridData)
                    {
                        if (currentIteration == SaveAccessoryInternalChallan.GridData.Count)
                        {
                            bool IsReceivedExists = cmd.Parameters.Contains("@IsReceived");
                            bool IsAuthorizedExists = cmd.Parameters.Contains("@IsAuthorized");
                            bool AuthorizedDateExists = cmd.Parameters.Contains("@AuthorizedDate");
                            bool ReceivedDateExists = cmd.Parameters.Contains("@ReceivedDate");

                            if (IsReceivedExists)
                            {
                                int Index = cmd.Parameters.IndexOf("@IsReceived");
                                cmd.Parameters.RemoveAt(Index);
                            }

                            if (IsAuthorizedExists)
                            {
                                int Index = cmd.Parameters.IndexOf("@IsAuthorized");
                                cmd.Parameters.RemoveAt(Index);
                            }

                            if (AuthorizedDateExists)
                            {
                                int Index = cmd.Parameters.IndexOf("@AuthorizedDate");
                                cmd.Parameters.RemoveAt(Index);
                            }

                            if (ReceivedDateExists)
                            {
                                int Index = cmd.Parameters.IndexOf("@ReceivedDate");
                                cmd.Parameters.RemoveAt(Index);
                            }
                            param = new SqlParameter("@IsReceived", SqlDbType.Bit);
                            param.Value = SaveAccessoryInternalChallan.IsPartySignature;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@IsAuthorized", SqlDbType.Bit);
                            param.Value = SaveAccessoryInternalChallan.IsAuthorizedSignatory;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@AuthorizedDate", SqlDbType.Date);
                            if (SaveAccessoryInternalChallan.AuthorizedDate == DateTime.MinValue)
                                param.Value = DBNull.Value;
                            else
                                param.Value = SaveAccessoryInternalChallan.AuthorizedDate;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);

                            param = new SqlParameter("@ReceivedDate", SqlDbType.Date);
                            if (SaveAccessoryInternalChallan.ReceivedDate == DateTime.MinValue)
                                param.Value = DBNull.Value;
                            else
                                param.Value = SaveAccessoryInternalChallan.ReceivedDate;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);
                        }

                        param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                        param.Value = AccessoryInternalChallanGridData.AccessoryMasterId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Size", SqlDbType.VarChar);
                        param.Value = AccessoryInternalChallanGridData.Size;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                        param.Value = AccessoryInternalChallanGridData.ColorPrint;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                        param.Value = AccessoryInternalChallanGridData.OrderDetailId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@NoOfItems", SqlDbType.Int);
                        param.Value = AccessoryInternalChallanGridData.NoOfItems;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@QtyToIssue", SqlDbType.Decimal);
                        param.Value = AccessoryInternalChallanGridData.QtyToIssue;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Description", SqlDbType.VarChar);
                        param.Value = AccessoryInternalChallanGridData.Description;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ReturnedQty", SqlDbType.Decimal);
                        param.Value = AccessoryInternalChallanGridData.ReturnedQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();

                        currentIteration++;

                        bool param1Exists = cmd.Parameters.Contains("@AccessoryMasterId");
                        bool param2Exists = cmd.Parameters.Contains("@Size");
                        bool param3Exists = cmd.Parameters.Contains("@ColorPrint");
                        bool param4Exists = cmd.Parameters.Contains("@OrderDetailId");
                        bool param5Exists = cmd.Parameters.Contains("@NoOfItems");
                        bool param6Exists = cmd.Parameters.Contains("@QtyToIssue");
                        bool param7Exists = cmd.Parameters.Contains("@Description");
                        bool param8Exists = cmd.Parameters.Contains("@ReturnedQty");

                        if (param1Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@AccessoryMasterId");
                            cmd.Parameters.RemoveAt(Index);
                        }
                        if (param2Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@Size");
                            cmd.Parameters.RemoveAt(Index);
                        }
                        if (param3Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@ColorPrint");
                            cmd.Parameters.RemoveAt(Index);
                        }
                        if (param4Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@OrderDetailId");
                            cmd.Parameters.RemoveAt(Index);
                        }
                        if (param5Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@NoOfItems");
                            cmd.Parameters.RemoveAt(Index);
                        }
                        if (param6Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@QtyToIssue");
                            cmd.Parameters.RemoveAt(Index);
                        }
                        if (param7Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@Description");
                            cmd.Parameters.RemoveAt(Index);
                        }
                        if (param8Exists)
                        {
                            int Index = cmd.Parameters.IndexOf("@ReturnedQty");
                            cmd.Parameters.RemoveAt(Index);
                        }
                    }
                    transaction.Commit();
                    cnx.Close();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    return false;
                }
                finally
                {
                    cnx.Close();
                }
                return true;

            }

        }
        //To Save Accessory Internal Challan End :Created By Girish


        //To Get ChallanNumber For AccessoryInternalChallan Start: Girish
        public DataTable GetChallanNumberForAccessoryInternalChallan(int OrderID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "USP_InternalAccessoryChallan";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = OrderID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = "GetChallanNumber";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cnx.Close();
                return dt;
            }
        }
        //To Get ChallanNumber For AccessoryInternalChallan End


        //To Get BasicDetails For AccessoryInternal Challan Start:Girish
        public DataTable GetBasicDetailsForAccessoryInternalChallan(string SerialNumber = "", string ChallanNumber = "")
        {
            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_InternalAccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = "BASIC_DETAILS_FOR_INTERNAL_CHALLAN";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
                param.Value = SerialNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt;
            }
        }
        //To Get BasicDetails For AccessoryInternal Challan:End


        //GetBasicDetailsForAccessoryInternalChallan Start: Girish
        public DataTable GetDataForAccessoryInternalChallanGrid(string flag, string flagOption, string SerialNumber, string ChallanNumber)
        {
            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_InternalAccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@flagOption", SqlDbType.VarChar);
                param.Value = flagOption;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SerialNumber", SqlDbType.VarChar);
                param.Value = SerialNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanNumber", SqlDbType.VarChar);
                param.Value = ChallanNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt;
            }
        }
        //GetBasicDetailsForAccessoryInternalChallan End




        public int Save_Accessory_Challan(AccessoryChallanCls objAccessoryChallanCls, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1, challanId = 0;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Accessory_Challan";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    if (objAccessoryChallanCls.SupplierPoId > 0)
                    {
                        param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                        param.Value = objAccessoryChallanCls.SupplierPoId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (objAccessoryChallanCls.Rate > 0)
                    {
                        param = new SqlParameter("@Rate", SqlDbType.Decimal);
                        param.Value = objAccessoryChallanCls.Rate;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (objAccessoryChallanCls.OrderDetailId > 0)
                    {
                        param = new SqlParameter("@OrderDetailsId", SqlDbType.Int);
                        param.Value = objAccessoryChallanCls.OrderDetailId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (objAccessoryChallanCls.DebitNoteId > 0)
                    {
                        param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                        param.Value = objAccessoryChallanCls.DebitNoteId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (objAccessoryChallanCls.AccessoryMasterId > 0)
                    {
                        param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                        param.Value = objAccessoryChallanCls.AccessoryMasterId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    param.Value = objAccessoryChallanCls.Color_Print;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size", SqlDbType.VarChar);
                    param.Value = objAccessoryChallanCls.Size;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanId", SqlDbType.Int);
                    param.Value = objAccessoryChallanCls.ChallanId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanNo", SqlDbType.VarChar);
                    param.Value = objAccessoryChallanCls.ChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDate", SqlDbType.Date);
                    if (objAccessoryChallanCls.ChallanDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryChallanCls.ChallanDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanType", SqlDbType.Int);
                    param.Value = objAccessoryChallanCls.ChallanType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GroupUnitId", SqlDbType.Int);
                    param.Value = objAccessoryChallanCls.AccessoryUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChallanDesc", SqlDbType.VarChar);
                    param.Value = objAccessoryChallanCls.ChallanDesc;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SendQty", SqlDbType.Decimal);
                    param.Value = objAccessoryChallanCls.SendQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedChallanQty", SqlDbType.Decimal);
                    param.Value = objAccessoryChallanCls.TotalRecChallanQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitCount", SqlDbType.Int);
                    param.Value = objAccessoryChallanCls.UnitCount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsPartySign", SqlDbType.Bit);
                    param.Value = objAccessoryChallanCls.IsPartySignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAuthoriseSign", SqlDbType.Bit);
                    param.Value = objAccessoryChallanCls.IsAuthorizedSignatory;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ProDuctionUnitId", SqlDbType.Int);
                    param.Value = objAccessoryChallanCls.ProductionUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GST", SqlDbType.Decimal);
                    param.Value = objAccessoryChallanCls.GST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HSNCode", SqlDbType.VarChar);
                    param.Value = objAccessoryChallanCls.HSNCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@ReturnChallanId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    count = cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                    {
                        objAccessoryChallanCls.ChallanId = Convert.ToInt32(outParam.Value);
                        challanId = Convert.ToInt32(outParam.Value);
                    }
                    else
                    {
                        objAccessoryChallanCls.ChallanId = -1;
                    }

                    foreach (ChallanProcess objChallanProcess in objAccessoryChallanCls.ChallanProcessList)
                    {
                        Save_Accessory_ChallanProcess(objChallanProcess, objAccessoryChallanCls.ChallanId, cnx, transaction);
                    }
                    //if (objAccessoryChallanCls.ChallanBreakDownList != null)
                    //{
                    //    foreach (AccessoryChallanBreakDown objChallanBreakDown in objAccessoryChallanCls.ChallanBreakDownList)
                    //    {
                    //        Save_Accessory_ChallanBreakDown(objChallanBreakDown, objAccessoryChallanCls.ChallanId, cnx, transaction);
                    //    }
                    //}

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                // return count;
                return challanId;
            }
        }

        private int Save_Accessory_ChallanProcess(ChallanProcess objChallanProcess, int ChallanId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "sp_Save_Accessory_Challan_Process";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@ChallanId", SqlDbType.Int);
            param.Value = ChallanId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProcessId", SqlDbType.Int);
            param.Value = objChallanProcess.ChallanProcessId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        private int Save_Accessory_ChallanBreakDown(AccessoryChallanBreakDown objChallanBreakDown, int ChallanId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "sp_Save_Accessory_ChallanBreakDown";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@ChallanId", SqlDbType.Int);
            param.Value = ChallanId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ChallanBreakDownId", SqlDbType.Int);
            param.Value = objChallanBreakDown.Challan_BreakDown_Id;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Pcs", SqlDbType.Int);
            param.Value = objChallanBreakDown.Pcs;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GroupUnitId", SqlDbType.Int);
            param.Value = objChallanBreakDown.GroupUnitId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "SAVE";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        public int Delete_ChallanBreakDown(int ChallanBreakDownId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Accessory_ChallanBreakDown";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@ChallanBreakDownId", SqlDbType.Int);
                    param.Value = ChallanBreakDownId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = "DELETE";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }

        public AccessoryChallanCls Get_AccessorySendChallan(int SupplierPoId, int ChallanId, int UserID)
        {
            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryChallan";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ChallanId", SqlDbType.Int);
                param.Value = ChallanId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "SEND_CHALLAN";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objAccessoryChallan.ChallanId = (reader["Challan_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Challan_Id"]);
                        objAccessoryChallan.ChallanNumber = (reader["ChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ChallanNumber"]);
                        objAccessoryChallan.ChallanDate = (reader["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ChallanDate"]);
                        objAccessoryChallan.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryChallan.ChallanType = (reader["ChallanType"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ChallanType"]);
                        objAccessoryChallan.AccessoryMasterId = (reader["AccessoryMasterId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["AccessoryMasterId"]);
                        objAccessoryChallan.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        objAccessoryChallan.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryChallan.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        objAccessoryChallan.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryChallan.ChallanDesc = (reader["ChallanDescription"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ChallanDescription"]);
                        objAccessoryChallan.AccessoryUnitId = (reader["GroupUnitId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["GroupUnitId"]);

                        objAccessoryChallan.UnitChange = (reader["UnitChange"] == DBNull.Value) ? false : Convert.ToBoolean(reader["UnitChange"]);
                        objAccessoryChallan.ConversionValue = (reader["ConversionValue"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["ConversionValue"]);

                        objAccessoryChallan.GarmentUnitName = (reader["GarmentUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GarmentUnitName"]);
                        objAccessoryChallan.DefaultGarmentUnitName = (reader["DefaultGarmentUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DefaultGarmentUnitName"]);

                        objAccessoryChallan.Remaining_SendQty = (reader["Remaining_SendQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Remaining_SendQty"]);
                        objAccessoryChallan.Default_Remaining_SendQty = (reader["Default_Remaining_SendQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Default_Remaining_SendQty"]);

                        objAccessoryChallan.SendChallanQty = (reader["SendChallanQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["SendChallanQty"]);
                        objAccessoryChallan.Default_SendChallanQty = (reader["Default_SendChallanQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Default_SendChallanQty"]);

                        objAccessoryChallan.IsAuthorizedSignatory = (reader["IsAuthorized"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsAuthorized"]);
                        objAccessoryChallan.AuthorizedDate = (reader["AuthorizedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AuthorizedDate"]);
                        objAccessoryChallan.AuthoriseBy = (reader["AuthoriseBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AuthoriseBy"]);
                        objAccessoryChallan.AuthSignature = (reader["AuthSignature"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AuthSignature"]);

                        objAccessoryChallan.IsPartySignature = (reader["IsReceived"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsReceived"]);
                        objAccessoryChallan.ReceivedDate = (reader["ReceivedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ReceivedDate"]);
                        objAccessoryChallan.RecievedBy = (reader["RecievedBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["RecievedBy"]);
                        objAccessoryChallan.RecievedSignature = (reader["RecievedSignature"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["RecievedSignature"]);
                        objAccessoryChallan.ProductionUnitId = (reader["UnitID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["UnitID"]);

                        objAccessoryChallan.SupplierGstNo = (reader["GSTNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GSTNo"]);
                        objAccessoryChallan.SupplierAddress = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);
                        //rajeevS 13022023
                        objAccessoryChallan.HSNCode = reader["HSNCode"].ToString();
                        //rajeevS 13022023
                    }
                }
                reader.Dispose();
                objAccessoryChallan.ChallanBreakDownList = AccessoryChallanBreakDown(objAccessoryChallan.ChallanId, cnx);

                // objAccessoryChallan.AccessoryGstRateTotalAmount = AccessoryGstRateTotalAmount(SupplierPoId, cnx);

                return objAccessoryChallan;
            }
        }

        #endregion Challan Work

        #region Credit Note Work
        public List<AccessoryCreditNoteCls> GetAccessoryCreditNoteList(int SupplierPoId, string Searchtxt)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryCreditNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
                param.Value = Searchtxt;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "CREDITNOTE_LIST";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<AccessoryCreditNoteCls> AccessoryCreditNoteCollection = new List<AccessoryCreditNoteCls>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AccessoryCreditNoteCls objAccessoryCreditNote = new AccessoryCreditNoteCls();

                        objAccessoryCreditNote.CreditNoteId = (reader["CreditNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CreditNote_Id"]);
                        objAccessoryCreditNote.CreditNoteNumber = (reader["CreditNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CreditNoteNumber"]);
                        objAccessoryCreditNote.CreditNoteDate = (reader["CreditNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreditNoteDate"]);
                        objAccessoryCreditNote.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objAccessoryCreditNote.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryCreditNote.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);

                        objAccessoryCreditNote.DebitNoteId = (reader["DebitNote_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DebitNote_Id"]);
                        objAccessoryCreditNote.DebitNoteNumber = (reader["DebitNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DebitNoteNumber"]);
                        objAccessoryCreditNote.DebitNoteDate = (reader["DebitNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DebitNoteDate"]);
                        objAccessoryCreditNote.BIPLAddress = (reader["BIPLAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLAddress"]);

                        objAccessoryCreditNote.PartyBillNumber = (reader["PartyBillNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PartyBillNo"]);
                        objAccessoryCreditNote.PartyBillDate = (reader["PartyBillDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PartyBillDate"]);
                        objAccessoryCreditNote.Amount = (reader["Amount"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Amount"]);



                        AccessoryCreditNoteCollection.Add(objAccessoryCreditNote);
                    }
                }

                return AccessoryCreditNoteCollection;
            }
        }

        public AccessoryCreditNoteCls Get_AccessoryCreditNote(int SupplierPoId, int CreditNoteId)
        {
            AccessoryCreditNoteCls objAccessoryCreditNote = new AccessoryCreditNoteCls();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessoryCreditNote";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = CreditNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "CREDITNOTE_HEADER";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objAccessoryCreditNote.CreditNoteId = (reader["CreditNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["CreditNote_Id"]);
                        objAccessoryCreditNote.CreditNoteNumber = (reader["CreditNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CreditNoteNumber"]);
                        objAccessoryCreditNote.PartyBillId = (reader["PartyBillId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["PartyBillId"]);
                        objAccessoryCreditNote.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryCreditNote.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryCreditNote.PoDate = (reader["PoDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PoDate"]);
                        objAccessoryCreditNote.DebitNoteId = (reader["DebitNote_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DebitNote_Id"]);
                        objAccessoryCreditNote.DebitNoteNumber = (reader["DebitNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DebitNoteNumber"]);
                        objAccessoryCreditNote.DebitNoteDate = (reader["DebitNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DebitNoteDate"]);
                        objAccessoryCreditNote.CreditNoteDate = (reader["CreditNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreditNoteDate"]);
                        objAccessoryCreditNote.BIPLAddress = (reader["BIPLAddress"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BIPLAddress"]);
                        objAccessoryCreditNote.IGST = (reader["IGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["IGST"]);
                        objAccessoryCreditNote.CGST = (reader["CGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["CGST"]);
                        objAccessoryCreditNote.SGST = (reader["SGST"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["SGST"]);
                        objAccessoryCreditNote.IsCreditNoteSigned = (reader["IsSigned"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsSigned"]);
                        objAccessoryCreditNote.CreditNoteSignDate = (reader["SignDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SignDate"]);
                        objAccessoryCreditNote.CreditNoteSignedBy = (reader["SignedBy"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SignedBy"]);
                        objAccessoryCreditNote.AuthSignature = (reader["SignaturePath"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SignaturePath"]);
                        objAccessoryCreditNote.GSTNo = (reader["GSTNo"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GSTNo"]);


                        objAccessoryCreditNote.SupplierAddress = (reader["Address"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Address"]);
                        objAccessoryCreditNote.HSNCode = (reader["HSNCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["HSNCode"]);


                    }
                }
                reader.Dispose();
                objAccessoryCreditNote.AccessoryCreditNoteParticularsList = AccessoryCreditNoteParticulars(CreditNoteId, cnx);

                return objAccessoryCreditNote;
            }
        }

        private List<AccessoryCreditNoteParticulars> AccessoryCreditNoteParticulars(int CreditNoteId, SqlConnection cnx)
        {

            string cmdText = "USP_Get_AccessoryCreditNote";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
            param.Value = CreditNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "CreditNOTE_PARTICULAR";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataReader reader1;

            reader1 = cmd.ExecuteReader();

            List<AccessoryCreditNoteParticulars> CreditNoteParticularsCollection = new List<AccessoryCreditNoteParticulars>();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    AccessoryCreditNoteParticulars objCreditNoteParticulars = new Common.AccessoryCreditNoteParticulars();

                    objCreditNoteParticulars.CreditNoteId = (reader1["CreditNote_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["CreditNote_Id"]);
                    objCreditNoteParticulars.CreditNoteParticularId = (reader1["CreditNote_Particulers_Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader1["CreditNote_Particulers_Id"]);
                    objCreditNoteParticulars.ParticularName = (reader1["Particulers"] == DBNull.Value) ? string.Empty : Convert.ToString(reader1["Particulers"]);
                    objCreditNoteParticulars.CreditQuantity = (reader1["Quantity"] == DBNull.Value) ? -1 : Convert.ToDouble(reader1["Quantity"]);
                    objCreditNoteParticulars.CreditRate = (reader1["Rate"] == DBNull.Value) ? -1 : Convert.ToDouble(reader1["Rate"]);

                    CreditNoteParticularsCollection.Add(objCreditNoteParticulars);
                }
            }

            return CreditNoteParticularsCollection;
        }
        //new added on 12 Jan 2021 start
        public DataTable Getbipladdress(string Name)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                DataTable dtAddress = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetBiplAddress";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAddress);

                //DataTable dtOrderContracts = dsInlineTopSection.Tables[0];               

                return dtAddress;
            }

        }
        //new added on 12 Jan 2021 end
        public List<Accessory_Srv_Bill> GetAccessory_List_Against_Debit_Bill(int SupplierPoId, int CreditNoteId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_List_Against_Debit_Bill";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = CreditNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<Accessory_Srv_Bill> Accessory_Srv_BillCollection = new List<Accessory_Srv_Bill>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Accessory_Srv_Bill objAccessory_Srv_Bill = new Accessory_Srv_Bill();

                        objAccessory_Srv_Bill.PartyBillId = (reader["ResultId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ResultId"]);
                        objAccessory_Srv_Bill.BillDetails = (reader["Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Details"]);

                        Accessory_Srv_BillCollection.Add(objAccessory_Srv_Bill);
                    }
                }
                return Accessory_Srv_BillCollection;
            }
        }

        public DataTable GetCreditNote(int SupplierPoId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_GetAccessory_List_Against_Debit_Bill";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtCredit = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCredit);
                cnx.Close();
                return dtCredit;
            }
        }

        public int Save_Accessory_CreditNote(AccessoryCreditNoteCls objAccessoryCreditNote, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Accessory_CreditNote";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = objAccessoryCreditNote.SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                    param.Value = objAccessoryCreditNote.CreditNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreditNoteNumber", SqlDbType.VarChar);
                    param.Value = objAccessoryCreditNote.CreditNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreditNoteDate", SqlDbType.Date);
                    if (objAccessoryCreditNote.CreditNoteDate == DateTime.MinValue)
                        param.Value = DBNull.Value;
                    else
                        param.Value = objAccessoryCreditNote.CreditNoteDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyBillId", SqlDbType.Int);
                    param.Value = objAccessoryCreditNote.PartyBillId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = objAccessoryCreditNote.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IGST", SqlDbType.Float);
                    param.Value = objAccessoryCreditNote.IGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CGST", SqlDbType.Float);
                    param.Value = objAccessoryCreditNote.CGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SGST", SqlDbType.Float);
                    param.Value = objAccessoryCreditNote.SGST;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalAmount", SqlDbType.Float);
                    param.Value = objAccessoryCreditNote.TotalAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsSigned", SqlDbType.Bit);
                    param.Value = objAccessoryCreditNote.IsCreditNoteSigned;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@ReturnCreditNoteId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    count = cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        objAccessoryCreditNote.CreditNoteId = Convert.ToInt32(outParam.Value);
                    else
                        objAccessoryCreditNote.CreditNoteId = -1;

                    foreach (AccessoryCreditNoteParticulars objCreditNoteParticulars in objAccessoryCreditNote.AccessoryCreditNoteParticularsList)
                    {
                        Save_Accessory_CreditNotePartyCulars(objCreditNoteParticulars, objAccessoryCreditNote.CreditNoteId, cnx, transaction);
                    }

                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }

        public AccessoriesInspect SaveAccessoriesInspection(AccessoriesInspectSystem accessoriesInspectSystem)
        {
            AccessoriesInspect objAccessoriesInspect = new AccessoriesInspect();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "USP_Accessories_Inspection";
                    SqlParameter param;

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@type", SqlDbType.VarChar);
                    param.Value = "INSERT";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.SupplierPO_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvId", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.SRV_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckerName1", SqlDbType.VarChar);
                    param.Value = accessoriesInspectSystem.CheckerName1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckerName2", SqlDbType.VarChar);
                    param.Value = accessoriesInspectSystem.CheckerName2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionDate", SqlDbType.DateTime);
                    param.Value = accessoriesInspectSystem.InspectionDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalQty", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.TotalQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RecievedQty", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.RecievedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckedQty", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.CheckedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    if (accessoriesInspectSystem.PassQty > 0)
                    {
                        param = new SqlParameter("@PassQty", SqlDbType.Decimal);
                        param.Value = accessoriesInspectSystem.PassQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (accessoriesInspectSystem.HoldQty > 0)
                    {
                        param = new SqlParameter("@HoldQty", SqlDbType.Decimal);
                        param.Value = accessoriesInspectSystem.HoldQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (accessoriesInspectSystem.FailQty > 0)
                    {
                        param = new SqlParameter("@FailQty", SqlDbType.Decimal);
                        param.Value = accessoriesInspectSystem.FailQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments", SqlDbType.VarChar);
                    param.Value = accessoriesInspectSystem.Comments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAccessoryQA", SqlDbType.Bit);
                    param.Value = accessoriesInspectSystem.IsAccessoryQA;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAccessoryGM", SqlDbType.Bit);
                    param.Value = accessoriesInspectSystem.IsAccessoryGM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //new parameters start

                    param = new SqlParameter("@ClaimedQty", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.ClaimedQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalLabSpeciman", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.InternalLabSpeciman;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalLabSpeciman", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.ExternalLabSpeciman;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalSentToLab", SqlDbType.Bit);
                    param.Value = accessoriesInspectSystem.InternalSentToLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalSentToLab", SqlDbType.Bit);
                    param.Value = accessoriesInspectSystem.ExternalSentToLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalReceivedInLab", SqlDbType.Bit);
                    param.Value = accessoriesInspectSystem.InternalReceivedInLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalReceivedInLab", SqlDbType.Bit);
                    param.Value = accessoriesInspectSystem.ExternalReceivedInLab;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalSentToLabDate", SqlDbType.DateTime);
                    if ((accessoriesInspectSystem.InternalSentToLabDate == DateTime.MinValue) || (accessoriesInspectSystem.InternalSentToLabDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.InternalSentToLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.InternalSentToLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalSentToLabDate", SqlDbType.DateTime);

                    if ((accessoriesInspectSystem.ExternalSentToLabDate == DateTime.MinValue) || (accessoriesInspectSystem.ExternalSentToLabDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.ExternalSentToLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.ExternalSentToLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalReceivedInLabDate", SqlDbType.DateTime);
                    if ((accessoriesInspectSystem.InternalReceivedInLabDate == DateTime.MinValue) || (accessoriesInspectSystem.InternalReceivedInLabDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.InternalReceivedInLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.InternalReceivedInLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalReceivedInLabDate", SqlDbType.DateTime);
                    if ((accessoriesInspectSystem.ExternalReceivedInLabDate == DateTime.MinValue) || (accessoriesInspectSystem.ExternalReceivedInLabDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.ExternalReceivedInLabDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.ExternalReceivedInLabDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalLabReport", SqlDbType.VarChar);
                    if (accessoriesInspectSystem.InternalLabReport == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.InternalLabReport;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalLabReport", SqlDbType.VarChar);
                    if (accessoriesInspectSystem.ExternalLabReport == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.ExternalLabReport;
                    }
                    //param.Value = accessoriesInspectSystem.ExternalLabReport;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDecision", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.FinalDecision;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //  added by shubhendu -----------------
                    param = new SqlParameter("@IsCommercialPass", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.IsCommercialpass;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InternalLabDecesion", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.InternalLabDec;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalLabDecision", SqlDbType.Int);
                    param.Value = accessoriesInspectSystem.ExternalLabDec;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //  till here------------------------ 

                    param = new SqlParameter("@TotalExternalQty", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.TotalExternalQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailedRaisedDebit", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.FailedRaisedDebit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailedStock", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.FailedStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailedGoodStock", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.FailedGoodStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailedParticular", SqlDbType.VarChar);
                    param.Value = accessoriesInspectSystem.FailedParticular;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectRaisedDebit", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.InspectRaisedDebit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectUsableStock", SqlDbType.Decimal);
                    param.Value = accessoriesInspectSystem.InspectUsableStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectParticular", SqlDbType.VarChar);
                    param.Value = accessoriesInspectSystem.InspectParticular;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsLabManager", SqlDbType.Bit);
                    param.Value = accessoriesInspectSystem.IsLabManager;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LabManagerApprovedDate", SqlDbType.DateTime);

                    if ((accessoriesInspectSystem.LabManagerApprovedDate == DateTime.MinValue) || (accessoriesInspectSystem.LabManagerApprovedDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.LabManagerApprovedDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.LabManagerApprovedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QAManagerApprovedDate", SqlDbType.DateTime);

                    if ((accessoriesInspectSystem.QAManagerApprovedDate == DateTime.MinValue) || (accessoriesInspectSystem.QAManagerApprovedDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.QAManagerApprovedDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.QAManagerApprovedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GMManagerApprovedDate", SqlDbType.DateTime);

                    if ((accessoriesInspectSystem.GMManagerApprovedDate == DateTime.MinValue) || (accessoriesInspectSystem.GMManagerApprovedDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.GMManagerApprovedDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.GMManagerApprovedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FinalDecisionDate", SqlDbType.DateTime);
                    if ((accessoriesInspectSystem.FinalDecisionDate == DateTime.MinValue) || (accessoriesInspectSystem.FinalDecisionDate == Convert.ToDateTime("1753-01-01")) || (accessoriesInspectSystem.FinalDecisionDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.FinalDecisionDate;
                    }
                    //param.Value = accessoriesInspectSystem.FinalDecisionDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@AccessoryQABy", SqlDbType.Int);
                    //param.Value = accessoriesInspectSystem.AccessoryQABy;
                    if (accessoriesInspectSystem.AccessoryQABy == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.AccessoryQABy;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryGMBy", SqlDbType.Int);
                    //param.Value = accessoriesInspectSystem.AccessoryGMBy;
                    if (accessoriesInspectSystem.AccessoryGMBy == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.AccessoryGMBy;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LabManagerBy", SqlDbType.Int);
                    //param.Value = accessoriesInspectSystem.LabManagerBy;
                    if (accessoriesInspectSystem.LabManagerBy == 0)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = accessoriesInspectSystem.LabManagerBy;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //new parameters end

                    SqlParameter outParam;
                    outParam = new SqlParameter("@InspectId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter outParam1;
                    outParam1 = new SqlParameter("@Excess_Stock_Qty", SqlDbType.Int);
                    outParam1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam1);

                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                    {
                        objAccessoriesInspect.Inspection_Id = Convert.ToInt32(outParam.Value);
                    }
                    if (outParam1.Value != DBNull.Value)
                    {
                        objAccessoriesInspect.StockQty = Convert.ToInt32(outParam1.Value);
                    }

                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    //return -1;
                }
                return objAccessoriesInspect;
            }
        }

        public int SaveInspectionParticular(AccessoriesInspect accessoriesInspect)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int InspectionId = -1;
                try
                {
                    cnx.Open();

                    string cmdText = "USP_Accessories_Inspection";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@type", SqlDbType.VarChar);
                    param.Value = "InsertTInspectionParticular";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Inspection_Id", SqlDbType.Int);
                    param.Value = accessoriesInspect.Inspection_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionParticularId", SqlDbType.Int);
                    param.Value = accessoriesInspect.InspectionParticular_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BoxNo", SqlDbType.Int);
                    param.Value = accessoriesInspect.BoxNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    if (accessoriesInspect.DieLot > 0)
                    {
                        param = new SqlParameter("@DieLot", SqlDbType.Int);
                        param.Value = accessoriesInspect.DieLot;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    //new code start
                    if (accessoriesInspect.ClaimedLength > 0)
                    {
                        param = new SqlParameter("@ClaimedLength", SqlDbType.Decimal);
                        param.Value = accessoriesInspect.ClaimedLength;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    //new code end

                    if (accessoriesInspect.ActLength > 0)
                    {
                        param = new SqlParameter("@ActLength", SqlDbType.Decimal);
                        param.Value = accessoriesInspect.ActLength;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (accessoriesInspect.CheckedQty > 0)
                    {
                        param = new SqlParameter("@CheckedQty1", SqlDbType.Decimal);
                        param.Value = accessoriesInspect.CheckedQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (accessoriesInspect.PassQty > 0)
                    {
                        param = new SqlParameter("@PassQty1", SqlDbType.Decimal);
                        param.Value = accessoriesInspect.PassQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (accessoriesInspect.FailQty > 0)
                    {
                        param = new SqlParameter("@FailQty1", SqlDbType.Decimal);
                        param.Value = accessoriesInspect.FailQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    if (accessoriesInspect.HoldQty > 0)
                    {
                        param = new SqlParameter("@HoldQty1", SqlDbType.Decimal);
                        param.Value = accessoriesInspect.HoldQty;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    if (accessoriesInspect.Decision != null)
                    {
                        param = new SqlParameter("@Decision", SqlDbType.Int);
                        param.Value = Convert.ToInt32(accessoriesInspect.Decision);
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    param = new SqlParameter("@CreatedBy1", SqlDbType.Int);
                    param.Value = accessoriesInspect.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlParameter outParam;
                    outParam = new SqlParameter("@InspectId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                    {
                        InspectionId = Convert.ToInt32(outParam.Value);
                    }

                    cnx.Close();
                    return InspectionId;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }

        public void DeleteInspectionParticular(int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "USP_Accessories_Inspection";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@type", SqlDbType.VarChar);
                    param.Value = "DELETE";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionParticularId", SqlDbType.Int);
                    param.Value = Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }

        private int Save_Accessory_CreditNotePartyCulars(AccessoryCreditNoteParticulars objCreditNoteParticulars, int CreditNoteId, SqlConnection cnx, SqlTransaction trans)
        {
            int iSave = 0;

            string cmdText = "sp_Save_Accessory_CreditNotePartyCulars";
            SqlParameter param;
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
            param.Value = CreditNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreditNotePartyCularId", SqlDbType.Int);
            param.Value = objCreditNoteParticulars.CreditNoteParticularId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Particulars", SqlDbType.VarChar);
            param.Value = objCreditNoteParticulars.ParticularName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Float);
            param.Value = objCreditNoteParticulars.CreditQuantity;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", SqlDbType.Float);
            param.Value = objCreditNoteParticulars.CreditRate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = "SAVE";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            iSave = cmd.ExecuteNonQuery();

            return iSave;
        }

        public int Update_Accessory_CreditNotePartyCulars(AccessoryCreditNoteParticulars objCreditNoteParticulars, int UserId, string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_Save_Accessory_CreditNotePartyCulars";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                    param.Value = objCreditNoteParticulars.CreditNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreditNotePartyCularId", SqlDbType.Int);
                    param.Value = objCreditNoteParticulars.CreditNoteParticularId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulars", SqlDbType.VarChar);
                    param.Value = objCreditNoteParticulars.ParticularName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Quantity", SqlDbType.Int);
                    param.Value = objCreditNoteParticulars.CreditQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Int);
                    param.Value = objCreditNoteParticulars.CreditRate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();


                    transaction.Commit();
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }

                return count;
            }
        }

        #endregion Credit Note Work

        public DataSet GetAccessory_AMPerformanceReport(int AccworkingWorkingDetailID, int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet ds = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AM_Accesories_Report";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@AccworkingWorkingID", SqlDbType.Int);
                param.Value = AccworkingWorkingDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                return ds;
            }

        }

        public List<AccessoryQualityIssuing> GetAccessoriesQualityIssuing(string search, bool IsRequestPending, bool IsRequestSend, bool IsCompleteIssue, int orderId)
        {
            List<AccessoryQualityIssuing> objAccessoryPendingDetailsColect = new List<AccessoryQualityIssuing>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Accessory_Issuing";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "Get_Accessory_Issuing";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Search", SqlDbType.VarChar);
                param.Value = search;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsRequestPending", SqlDbType.Bit);
                param.Value = IsRequestPending;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsIssueRequest", SqlDbType.Bit);
                param.Value = IsRequestSend;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsCompleteIssue", SqlDbType.Bit);
                param.Value = IsCompleteIssue;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = orderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AccessoryQualityIssuing objQualityIssue = new AccessoryQualityIssuing();
                    objQualityIssue.OrderId = (reader["OrderID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderID"]);
                    objQualityIssue.OrderDetailId = (reader["OrderDetailId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderDetailId"]);
                    objQualityIssue.AccessoryWorkingDetailId = (reader["accessory_working_detail_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["accessory_working_detail_Id"]);
                    objQualityIssue.AccessoryMasterId = (reader["AccessoryMaster_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["AccessoryMaster_Id"]);
                    objQualityIssue.SupplyType = (reader["SupplyType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplyType"]);
                    objQualityIssue.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                    objQualityIssue.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                    objQualityIssue.ContractNumber = (reader["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ContractNumber"]);
                    objQualityIssue.ContractQty = (reader["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Quantity"]);
                    objQualityIssue.TradName = (reader["TradeName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TradeName"]);
                    objQualityIssue.Size = reader["Size"] == DBNull.Value ? string.Empty : reader["Size"].ToString();
                    objQualityIssue.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                    objQualityIssue.AccessoryAvg = (reader["Number"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Number"]);
                    objQualityIssue.totalRequired = (reader["Total_AccRequired"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["Total_AccRequired"]);
                    objQualityIssue.GarmentUnitName = (reader["UnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["UnitName"]);
                    objQualityIssue.AvailableQtyToIssued = (reader["AvailableQtyToIssued"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["AvailableQtyToIssued"]);
                    objQualityIssue.IsIssueRequest = (reader["IsIssueRequest"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsIssueRequest"]);
                    objQualityIssue.RequiredQty = (reader["RequiredQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["RequiredQty"]);
                    objQualityIssue.IsCompleteIssue = (reader["IsCompleteIssue"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsCompleteIssue"]);
                    objQualityIssue.LeftQuantity = (reader["LeftQuantity"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["LeftQuantity"]);
                    objQualityIssue.IssueRequestDate = (reader["IssueRequestDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["IssueRequestDate"]);
                    objQualityIssue.IssueCompleteDate = (reader["IssueCompleteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["IssueCompleteDate"]);
                    objQualityIssue.TotalSendChallanQty = (reader["TotalChallanQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["TotalChallanQty"]);
                    objQualityIssue.Wastage = (reader["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Wastage"]);
                    objQualityIssue.StockQty = (reader["StockQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["StockQty"]);
                    objQualityIssue.DebitQty = (reader["DebitQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["DebitQty"]);
                    objQualityIssue.Unitid = (reader["unitid"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["unitid"]);
                    objQualityIssue.CanMakeNewChallan = (reader["CanMakeNewChallan"] == DBNull.Value) ? Convert.ToBoolean(0) : Convert.ToBoolean(reader["CanMakeNewChallan"]);
                    objQualityIssue.ReturnedQty = (reader["ReturnedQty"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader["ReturnedQty"]);


                    if (objQualityIssue.TotalSendChallanQty > 0)
                        objQualityIssue.RequiredQty = objQualityIssue.RequiredQty - (objQualityIssue.TotalSendChallanQty - objQualityIssue.ReturnedQty) - (objQualityIssue.StockQty + objQualityIssue.DebitQty);

                    objAccessoryPendingDetailsColect.Add(objQualityIssue);
                }
                return objAccessoryPendingDetailsColect;
            }

        }

        public List<AccessoryQualityIssuing> GetChallanDetailsByOrderDetailId(int OrderDetailId, int AccessoryMasterId, string Size, string ColorPrint)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Accessory_Issuing";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "Get_Challan_Details";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                List<AccessoryQualityIssuing> objAccessoryQualityIssuingCollection = new List<AccessoryQualityIssuing>();

                while (reader.Read())
                {
                    AccessoryQualityIssuing objAccessoryQualityIssuing = new AccessoryQualityIssuing();
                    objAccessoryQualityIssuing.ChallanId = (reader["Challan_Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Challan_Id"]);
                    objAccessoryQualityIssuing.ChallanNumber = (reader["ChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ChallanNumber"]);
                    objAccessoryQualityIssuing.ChallanQty = (reader["ReceivedChallanQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ReceivedChallanQty"]);
                    objAccessoryQualityIssuing.ChallanDateWithFormat = (reader["ChallanDate"] == DBNull.Value) ? "" : Convert.ToDateTime(reader["ChallanDate"]).ToString("dd MMM");
                    objAccessoryQualityIssuing.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);

                    objAccessoryQualityIssuingCollection.Add(objAccessoryQualityIssuing);
                }
                return objAccessoryQualityIssuingCollection;
            }

        }

        public int SaveAccessoryInternalIssueSheet(AccessoryQualityIssuing accessoryIssuing)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int iSave = 0;
                try
                {
                    cnx.Open();

                    string cmdText = "sp_Accessory_Issuing";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@type", SqlDbType.VarChar);
                    param.Value = "SaveAccessoryIssueSheet";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = accessoryIssuing.OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = accessoryIssuing.OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                    param.Value = accessoryIssuing.AccessoryMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IssueSheetId", SqlDbType.Int);
                    param.Value = accessoryIssuing.IssueSheetId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsIssueRequest", SqlDbType.Int);
                    param.Value = accessoryIssuing.IsIssueRequest;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsCompleteIssue", SqlDbType.Int);
                    param.Value = accessoryIssuing.IsCompleteIssue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    if (accessoryIssuing.IssueRequestDate == DateTime.MinValue)
                    {
                        param = new SqlParameter("@IssueRequestDate", SqlDbType.DateTime);
                        param.Value = System.DBNull.Value;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    else
                    {
                        param = new SqlParameter("@IssueRequestDate", SqlDbType.DateTime);
                        param.Value = accessoryIssuing.IssueRequestDate;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (accessoryIssuing.IssueCompleteDate == DateTime.MinValue)
                    {
                        param = new SqlParameter("@IssueCompleteDate", SqlDbType.DateTime);
                        param.Value = System.DBNull.Value;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    else
                    {
                        param = new SqlParameter("@IssueCompleteDate", SqlDbType.DateTime);
                        param.Value = accessoryIssuing.IssueCompleteDate;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    param.Value = accessoryIssuing.Color_Print.Trim();
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size", SqlDbType.VarChar);
                    param.Value = accessoryIssuing.Size.Trim();
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = accessoryIssuing.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@Unitid", SqlDbType.Int);
                    param.Value = accessoryIssuing.Unitid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    iSave = cmd.ExecuteNonQuery();

                    return iSave;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }

        //added by raghvinder on 23-03-2021 start
        public decimal GetAccessory_ConversionValue(int CurrentUnitId, int PreviousUnitId)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();

                    string cmdText = "usp_GetAccessoryConversionValue";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@CurrentUnitId", SqlDbType.Int);
                    param.Value = CurrentUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreviousUnitId", SqlDbType.Int);
                    param.Value = PreviousUnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return Convert.ToDecimal(dt.Rows[0]["ConvertedValue"]);
            }

        }
        //added by raghvinder on 23-03-2021 end

        //added by raghvinder on 23-10-2020 start
        public int Save_Accessory_Average(string Type, float Avg, int Unit, int OrderID, int AccWorkingDetailId, bool CheckValue, int CreatedBy)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_Update_AccessoryAVG_Unit";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Avg", SqlDbType.Float);
                    param.Value = Avg;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Unit", SqlDbType.Float);
                    param.Value = Unit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Orderid", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryworkingdetailId", SqlDbType.Int);
                    param.Value = AccWorkingDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckValue", SqlDbType.Bit);
                    param.Value = CheckValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return count;
            }
        }

        public int Update_SupplierPo_PartySignature(int SupplierPO_Id, int IsPartySignature, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    string cmdText = "usp_Update_SupplierPo_PartySignature";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                    param.Value = SupplierPO_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsPartySignature", SqlDbType.Bit);
                    param.Value = IsPartySignature;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return count;
            }
        }

        public AccessoryPending GetAccessory_PoDetails_Liability(int SupplierPoId, int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetAccessory_SupplierDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                param.Value = SupplierPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "PODETAILS_LIABILITY";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                AccessoryPending objAccessoryPending = new AccessoryPending();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        objAccessoryPending.AccessoryName = (reader["AccessoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AccessoryName"]);
                        objAccessoryPending.Size = (reader["Size"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Size"]);
                        objAccessoryPending.Color_Print = (reader["Color_Print"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Color_Print"]);
                        objAccessoryPending.SupplierName = (reader["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SupplierName"]);
                        objAccessoryPending.GarmentUnitName = (reader["GarmentUnitName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["GarmentUnitName"]);
                        objAccessoryPending.Shrinkage = (reader["Shrinkage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Shrinkage"]);
                        objAccessoryPending.Wastage = (reader["Wastage"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["Wastage"]);

                        objAccessoryPending.PoNumber = (reader["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PO_Number"]);
                        objAccessoryPending.PoDate = (reader["PODate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PODate"]);
                        objAccessoryPending.PoEta = (reader["SRV_EndETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SRV_EndETA"]);

                        objAccessoryPending.QuantityToOrder = (reader["OrderQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["OrderQty"]);
                        objAccessoryPending.SRVQuantity = (reader["SRVQuantity"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["SRVQuantity"]);
                        objAccessoryPending.PoQuantity = (reader["PoQuantity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["PoQuantity"]);
                        objAccessoryPending.SendQty = (reader["SendQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SendQty"]);
                        objAccessoryPending.LiabilityQty = (reader["LiabilityQty"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["LiabilityQty"]);
                        objAccessoryPending.SupplyType = (reader["SupplyType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SupplyType"]);
                    }
                }

                return objAccessoryPending;
            }
        }

        public int Save_AccessoryLiability(AccessoryPending objAccessoryPending, int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    string cmdText = "sp_Save_AccessoryLiability";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                    param.Value = objAccessoryPending.SupplierPoId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = objAccessoryPending.OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderQty", SqlDbType.Int);
                    param.Value = objAccessoryPending.QuantityToOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PoQty", SqlDbType.Int);
                    param.Value = objAccessoryPending.PoQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvQty", SqlDbType.Int);
                    param.Value = objAccessoryPending.SRVQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SendQty", SqlDbType.Int);
                    param.Value = objAccessoryPending.SendQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LiabilityQty", SqlDbType.Int);
                    param.Value = objAccessoryPending.LiabilityQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return count;
            }
        }

        public DataTable GetSupplier_Type(int UserId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_GetSupplier_Type";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataTable dtFabricsQuality = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFabricsQuality);
                cnx.Close();
                return dtFabricsQuality;
            }
        }

        public int GetIssueSheetId(int OrderDetailId, int AccessoryMasterId, string ColorPrint, string Size)
        {
            int IssueSheetId = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_Accessory_Issuing";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "GetIssueSheetId";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                param.Value = AccessoryMasterId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                param.Value = ColorPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Size", SqlDbType.VarChar);
                param.Value = Size;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                IssueSheetId = Convert.ToInt32(cmd.ExecuteScalar());
                cnx.Close();
                return IssueSheetId;
            }
        }

        public DataSet GetAccessoryWastage(string flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_Accessory_Wastage";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
        }

        public List<AccessoryPending> GetPOAccesoryHistory(int SupplierPOId)
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
                param = new SqlParameter("@SupplierPOId", SqlDbType.Int);
                param.Value = SupplierPOId;
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

        public DataSet GetAccessoryWastageDetails(string flag, int accessoryQualityId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_Accessory_Wastage";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterID", SqlDbType.VarChar);
                param.Value = accessoryQualityId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
        }

        public int DeleteWastage(string flag, int accessoryQtyId, int AccessoryBarrierWastageId)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_Accessory_Wastage";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterID", SqlDbType.VarChar);
                param.Value = accessoryQtyId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@AccessoryBarrierWastageId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = AccessoryBarrierWastageId;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }

        public int UpdateAccessoryWastageDetails(string flag, int AccessoryQualityID, int AccessoryBarrierWastage, int fromqty, int toqty, int solid, int print, int createdBy)
        {
            int Isave = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "Usp_Accessory_Wastage";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryMasterID", SqlDbType.Int);
                param.Value = AccessoryQualityID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryBarrierWastageId", SqlDbType.Int);
                param.Value = AccessoryBarrierWastage;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@From_Qty", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = fromqty;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@To_Qty", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = toqty;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Solid_Barrier", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = solid;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Print_Barrier", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = print;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = createdBy;
                cmd.Parameters.Add(param);

                Isave = cmd.ExecuteNonQuery();

            }
            return Isave;
        }

        public int SaveQtyLeftInStock(AccessoryQualityIssuing objQualityIssue)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int count = -1;
                try
                {
                    cnx.Open();

                    string cmdText = "sp_Accessory_Issuing";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@type", SqlDbType.VarChar);
                    param.Value = "MoveInStock";
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = objQualityIssue.OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryMasterId", SqlDbType.Int);
                    param.Value = objQualityIssue.AccessoryMasterId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryWorkingDetailId", SqlDbType.Int);
                    param.Value = objQualityIssue.AccessoryWorkingDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Size", SqlDbType.VarChar);
                    param.Value = objQualityIssue.Size;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ColorPrint", SqlDbType.VarChar);
                    param.Value = objQualityIssue.Color_Print;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplyTypeId", SqlDbType.Int);
                    param.Value = objQualityIssue.SupplyType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StockQty", SqlDbType.Decimal);
                    param.Value = objQualityIssue.StockQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitQty", SqlDbType.Decimal);
                    param.Value = objQualityIssue.DebitQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LeftQty", SqlDbType.Decimal);
                    param.Value = objQualityIssue.LeftQuantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitParticular", SqlDbType.VarChar, 500);
                    param.Value = objQualityIssue.DebitParticulars;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = objQualityIssue.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    count = cmd.ExecuteNonQuery();

                    cnx.Close();

                }
                catch (SqlException ex)
                {
                    count = -1;
                    throw ex;
                }
                finally
                {
                    cnx.Close();
                }
                return count;
            }
        }

        public int Stock_Qty_Update_ToRaise_DebitNote(int SupplierPO_Id, int InspectionID, int flag, int StockQty)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int Save;
                try
                {
                    cnx.Open();

                    string cmdText = "Usp_Stock_Qty_Update_ToRaise_DebitNote";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@SupplierPO_Id", SqlDbType.Int);
                    param.Value = SupplierPO_Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectionID", SqlDbType.Int);
                    param.Value = InspectionID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Flag", SqlDbType.Bit);
                    param.Value = flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StockQty", SqlDbType.Int);
                    param.Value = StockQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    Save = cmd.ExecuteNonQuery();

                    cnx.Close();
                    return Save;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }

        // Added by shubhendu on 28-01-2022
        public int UpdateAccessoryGMSignature(int isGmChecked, decimal FailedRaisedDebit, decimal FailedStock, decimal FailedGoodStock, decimal InspectRaisedDebit, decimal InspectUsableStock, int Srv_id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int Save;
                try
                {
                    cnx.Open();

                    string cmdText = "USP_UpdateGmSignatureAndSection";
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    param = new SqlParameter("@isGmChecked", SqlDbType.Int);
                    param.Value = isGmChecked;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailedRaisedDebit", SqlDbType.Decimal);
                    param.Value = FailedRaisedDebit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@FailedStock", SqlDbType.Bit);
                    param.Value = FailedStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FailedGoodStock", SqlDbType.Int);
                    param.Value = FailedGoodStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectRaisedDebit", SqlDbType.Int);
                    param.Value = InspectRaisedDebit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@InspectUsableStock", SqlDbType.Int);
                    param.Value = InspectUsableStock;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Srvid", SqlDbType.Int);
                    param.Value = Srv_id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    Save = cmd.ExecuteNonQuery();

                    cnx.Close();
                    return Save;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }

        public DataTable GetAllActive_ClientCode()
        {
            DataTable dtClientCode = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_GetAllActive_ClientCode";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtClientCode);
                cnx.Close();

                return dtClientCode;
            }
        }

        public DataTable Get_AccessoryProductionUnit()
        {
            DataTable dtProUnit = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_get_all_unit";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtProUnit);
                cnx.Close();

                return dtProUnit;
            }
        }

        public string Save_UnRagisterAccessories(string AccessoriesName, string AccessoryRateSize)
        {
            var Isave1 = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "usp_Insert_Costing_Order_Accesories";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Accessories";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = AccessoriesName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Xml", SqlDbType.VarChar);
                param.Value = AccessoryRateSize;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Isave1 = cmd.ExecuteNonQuery();
            }
            return Isave1.ToString();

        }

        public DataSet Get_UnRagisterAccessories(string Tradename)
        {
            // var GetAccessory=0;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "usp_Insert_Costing_Order_Accesories";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "Get";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = Tradename;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet GetAccessory = new DataSet();
                adapter.Fill(GetAccessory);
                cnx.Close();

                return GetAccessory;

            }
        }

        public DataSet Get_AccessoryPrintOrderSummary(int orderid, int AccessoryworkingdetailId, int type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "USP_AccessoryPrintOrderSummary";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param;
                param = new SqlParameter("@orderid", SqlDbType.Int);
                param.Value = orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccessoryworkingdetailId", SqlDbType.Int);
                param.Value = AccessoryworkingdetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet GetPrintAccessory = new DataSet();
                adapter.Fill(GetPrintAccessory);
                cnx.Close();

                return GetPrintAccessory;
            }
        }
        #endregion
        public int UpdateAccessoryRemarks(string po_Number, string CommentRemarks, int UserId)
        {

            int i = 0;

            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "UpdateAccessoryRemarks";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@PO_Number", SqlDbType.VarChar, 500);
                    param.Value = po_Number;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@AccessoryRemarks", SqlDbType.VarChar, 500);
                    param.Value = CommentRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Userid", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    i = cmd.ExecuteNonQuery();

                    cnx.Close();
                }


            }
            catch (Exception ex)
            {
            }
            return i;
        }

        // Added By Shubhendu 29-08-2022
        public List<string> SuggestAccessoryByName(string q, string Flag, string TradeName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                List<string> AccessoryDetails = new List<string>();
                string cmdText = "Get_AccessoryAutoPopulateForQuantityRe";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@SearchValue", SqlDbType.VarChar);
                param.Value = q;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = TradeName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {


                    string value = reader["AccessoryDetails"].ToString();
                    AccessoryDetails.Add(value);


                }


                return AccessoryDetails;

            }
        }


        public DataTable GetAccessoryQualityDetailsByTradeName_New(string TradeName, string CategoryID, string UnitId, int SearchDefault)
        {
            DataTable DtFabricQualityDetail = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_Accessory_quality_details_by_trade_name_New";

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

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchDefault", SqlDbType.Int);
                param.Value = SearchDefault;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(DtFabricQualityDetail);

            }

            return DtFabricQualityDetail;
        }



        public DataSet GetAccessoryOrderSummaryPrint(int Flag, int orderid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_GetAccessoryOrderSummaryPrint";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Value = orderid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsAccessoryQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAccessoryQuality);
                cnx.Close();
                return dsAccessoryQuality;
            }
        }
    }
}
