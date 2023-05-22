using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Reflection;
using System.Data;

namespace iKandi.DAL
{
    public class StyleDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public StyleDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public bool DeleteStyle(int StyleID)
        {
            SqlTransaction transaction = null;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    string cmdText = "sp_style_delete_style";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters
                    SqlParameter param;

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = StyleID;
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

        // Added by Yadvendra on 06/01/2020
        public int CreateStyle(Style style, string DesignerCode, bool SaveStyleNew, int ParentStyleid, bool VisibleInMarketing)
        {

            int styleid = 0;
            //int id = 1;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_styles_insert_style";
                SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;
                SqlParameter param1;

                param1 = new SqlParameter("@Id", SqlDbType.Int);
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);

                param = new SqlParameter("@DesignerCode", SqlDbType.VarChar);
                param.Value = DesignerCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@VisibleInMarketing", SqlDbType.Bit);
                param.Value = VisibleInMarketing;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = style.StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumberDesc", SqlDbType.VarChar);
                param.Value = style.StyleNumberDesc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = style.ClientID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = style.DepartmentID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDepartmentID", SqlDbType.Int);
                param.Value = style.ParentDepartmentID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SketchURL", SqlDbType.VarChar);
                param.Value = style.SketchURL;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = style.DesignerID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@TargetPrice", SqlDbType.Float);
                param.Value = style.TargetPrice;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ETA", SqlDbType.DateTime);
                param.Value = style.ETA;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@IssuedOn", SqlDbType.DateTime);
                param.Value = style.IssuedOn;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@TargetPriceCurrency", SqlDbType.VarChar);
                param.Value = style.TargetPriceCurrency;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccountManagerID", SqlDbType.Int);
                param.Value = style.AccountManagerID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SamplingMerchandisingManagerID", SqlDbType.Int);
                param.Value = style.SamplingMerchandisingManagerID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                param.Value = style.FactoryName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Comments", SqlDbType.VarChar);
                param.Value = style.Comments;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SeasonID", SqlDbType.Int);
                param.Value = style.SeasonID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Story", SqlDbType.VarChar);
                param.Value = style.Story;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Meeting", SqlDbType.DateTime);
                if ((style.StyleMeeting == DateTime.MinValue) || (style.StyleMeeting == Convert.ToDateTime("1753-01-01")) || (style.StyleMeeting == Convert.ToDateTime("1900-01-01")))
                    param.Value = DBNull.Value;
                else
                    param.Value = style.StyleMeeting;

                //param.Value = style.StyleMeeting;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DocURL", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(style.DocURL))
                    style.DocURL = "";
                param.Value = style.DocURL;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                //abhishek 
                param = new SqlParameter("@TechPackFile", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(style.TackpackFile))
                    style.TackpackFile = "";
                param.Value = style.TackpackFile;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                //end

                param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                param.Value = style.SeasonName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //Gajendra Design
                param = new SqlParameter("@DivisionID", SqlDbType.Int);
                param.Value = style.DivisionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FitsType", SqlDbType.Int);
                param.Value = style.fitstype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsDefault", SqlDbType.Int);
                param.Value = style.IsDefaultStyle;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@TechPackFile1", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(style.TackpackFile1))
                    style.TackpackFile1 = "";
                param.Value = style.TackpackFile1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@TechPackFile2", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(style.TackpackFile2))
                    style.TackpackFile2 = "";
                param.Value = style.TackpackFile2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsSaveStyleAS", SqlDbType.Bit);
                param.Value = SaveStyleNew;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentStyleid", SqlDbType.Int);
                param.Value = ParentStyleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                styleid = Convert.ToInt32(param1.Value);
                cnx.Close();

            }
            return styleid;
        }

        public bool DeleteStyleFabric2(Int32 StyleId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                //foreach (StyleFabric stylefab in style.Fabrics)
                //{


                string cmdText = "sp_DeleteStyleFabric";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }


        public bool CreateStyleFabric(StyleFabric stylefab, bool SaveStyleNew, int CountFabric)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                //foreach (StyleFabric stylefab in style.Fabrics)
                //{


                string cmdText = "sp_style_fabrics_insert_style_fabric";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = stylefab.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricName", SqlDbType.VarChar, 3000);

                param.Value = stylefab.FabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintID", SqlDbType.Int);
                if (stylefab.PrintID.HasValue)
                {
                    param.Value = stylefab.PrintID;
                }
                else { param.Value = -1; }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SpecialFabricDetails", SqlDbType.VarChar);
                param.Value = stylefab.SpecialFabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = stylefab.Remarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricType", SqlDbType.Int);
                param.Value = stylefab.FabricType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@fabric_qualityID", SqlDbType.Int);
                param.Value = stylefab.FabricQualityId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                // condition added on 20-04-2023
                if (stylefab.GSM == "null")
                {
                    param = new SqlParameter("@GSM", SqlDbType.Float);
                    param.Value = 0;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }
                else
                {
                    param = new SqlParameter("@GSM", SqlDbType.Float);
                    param.Value = stylefab.GSM;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }

                param = new SqlParameter("@CostWidth", SqlDbType.Float);
                param.Value = stylefab.CostWidth;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DyedRate", SqlDbType.Float);
                param.Value =  stylefab.DyedRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintRate", SqlDbType.Float);
                param.Value = stylefab.PrintRate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DgtlRate", SqlDbType.Float);
                param.Value = stylefab.DigitalPrintRate;  // comment remove from here 1
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountConstruct", SqlDbType.VarChar);
                param.Value = stylefab.CountConstruct;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsSaveAs", SqlDbType.Bit);
                param.Value = SaveStyleNew;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CountFabric", SqlDbType.Int);
                param.Value = CountFabric;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                //}
                cnx.Close();

            }
            return true;
        }
        public bool CreateStyleRef(StyleReferenceBlock ReferenceBlock)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();



                string cmdText = "sp_style_reference_block_insert_style_reference_block";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = ReferenceBlock.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = ReferenceBlock.Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReferenceBlockURL", SqlDbType.VarChar);
                param.Value = ReferenceBlock.ImagePath;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = ReferenceBlock.Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                cnx.Close();
            }

            return true;
        }

        public bool CreateStyleRefs(Style Style)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                foreach (StyleReferenceBlock styleref in Style.ReferenceBlocks)
                {

                    string cmdText = "sp_style_reference_block_insert_style_reference_block";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    //cmd.Transaction = myTrans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;
                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = Style.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.VarChar);
                    param.Value = styleref.Name;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReferenceBlockURL", SqlDbType.VarChar);
                    if (string.IsNullOrEmpty(styleref.ImagePath))
                    {
                        param.Value = "";
                    }
                    else
                    {
                        param.Value = styleref.ImagePath;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.Int);
                    param.Value = styleref.Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                }
                cnx.Close();
            }

            return true;
        }


        public string GetStyleNumberById(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_StyleNumber_By_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                DataTable dt = dsorderDetail.Tables[0];

                string styleNumber = Convert.ToString(dt.Rows[0][0]);
                return styleNumber;

            }

        }

        public DataTable GetStyleFabricsPrints(string StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_fabric_prints";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.VarChar);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }

        public List<StyleFabric> GetStyleFabricsMultiplePrints(string StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlDataReader reader;
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_fabric_prints_multiple";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.VarChar);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Id = Convert.ToInt32(reader["Id"]);
                    StyleFab.FabricName = Convert.ToString(reader["fabric"]);
                    StyleFab.CCGSM = Convert.ToString(reader["ccgsm"]);
                    StyleFab.FabType = Convert.ToInt32(reader["fabtype"]);
                    int PrintID = reader.GetOrdinal("PrintID");
                    //int PrintNumber = reader.GetOrdinal("PrintNumber");
                    StyleFab.PrintNumber = string.Empty;
                    if (reader.IsDBNull(PrintID) == false)
                    {
                        StyleFab.PrintID = Convert.ToInt32(reader["PrintID"]);
                    }
                    StyleFab.SpecialFabricDetails = Convert.ToString(reader["SpecialFabricDetails"]);

                    StyleFab.Remarks = Convert.ToString(reader["Remarks"]);
                    //StyleFab.FabricType = (FabricType)Convert.ToInt32(reader["FabricType"]);
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;

            }

        }

        public Style GetStyleByStyleId(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_style_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                // worked by prabhaker 17-apr-17
                //SqlParameter outParam;
                //outParam = new SqlParameter("@IcheckAutoAllocationDone", SqlDbType.Int);
                ////param.Value = IcheckAutoAllocationDone;
                //outParam.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(outParam);
                // worked by prabhaker 17-apr-17
                reader = cmd.ExecuteReader();


                Style style = new Style();
                style.StyleID = StyleID;

                while (reader.Read())
                {
                    // worked by prabhaker 17-apr-17  TotalCount = Convert.ToInt32(outParam.Value);
                    style.IcheckAutoAllocationDone = checkFitsStatus(style.StyleID);
                    // worked by prabhaker 17-apr-17
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.StyleNumberDesc = (reader["StyleNumberDesc"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumberDesc"]);
                    style.SeasonID = (reader["SeasonID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["SeasonID"]);
                    style.SampleTrackingDate = (reader["SampleTrackingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SampleTrackingDate"]);
                    style.ClientID = Convert.ToInt32(reader["ClientID"]);
                    style.BuyingHouseID = Convert.ToInt32(reader["BuyingHouseID"]);
                    style.IsIkandiClient = Convert.ToInt32(reader["IsIkandiClient"]);
                    style.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    style.ParentDepartmentID = Convert.ToInt32(reader["ParentDepartmentID"]);
                    style.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                    style.SketchURL = Convert.ToString(reader["SketchURL"]);
                    style.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                    style.TargetPrice = Convert.ToDecimal(reader["TargetPrice"]);
                    style.TargetPriceCurrency = Convert.ToString(reader["TargetPriceCurrency"]);
                    style.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                    style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                    style.ClientName = Convert.ToString(reader["ClientName"]);
                    style.ClientDepartment = Convert.ToString(reader["ClientDepartment"]);
                    style.CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                    style.CourierSentOn = (reader["CourierSentOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierSentOn"]);
                    style.DesignerName = Convert.ToString(reader["DesignerFirstName"]) + " " + Convert.ToString(reader["DesignerLastName"]);
                    style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                    style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                    style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                    style.Comments = (reader["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Comments"]);
                    style.SeasonName = (reader["SeasonName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SeasonName"]);
                    style.UploadSpecsURL = (reader["UploadSpecsURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["UploadSpecsURL"]);
                    style.StyleMeeting = (reader["MeetingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["MeetingDate"]);
                    style.Story = Convert.ToString(reader["NewStory"]);
                    style.UpdatedOn = (reader["UpdatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["UpdatedOn"]);
                    style.UpdatedBy = Convert.ToString(reader["UpdatedByName"]);
                    style.DocURL = Convert.ToString(reader["DocURL"]);
                    style.DivisionID = Convert.ToString(reader["DivisionID"]);

                    style.fitstype = (reader["FitsType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["FitsType"]);
                    style.IsDefaultStyle = (reader["isDefaultStyleSequence"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["isDefaultStyleSequence"]);
                    style.TackpackFile = Convert.ToString(reader["TeckPackFile"]);//abhishek
                    //style.fitstype =Convert.ToInt32(reader["FitsType"]);//Gajendra Design
                    style.TackpackFile1 = Convert.ToString(reader["TechPackFile1"]);
                    style.TackpackFile2 = Convert.ToString(reader["TechPackFile2"]);
                    style.Sample_Sent_Action = Convert.ToString(reader["SampleSentActual"]);
                    // Added by Yadvendra on 06/01/2020
                    style.IsMarketingVisible = reader["IsMarketingVisible"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsMarketingVisible"]);

                }

                return style;
            }

        }
        public string GetStyleByCode(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Stle_By_Code";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                // worked by prabhaker 17-apr-17
                //SqlParameter outParam;
                //outParam = new SqlParameter("@IcheckAutoAllocationDone", SqlDbType.Int);
                ////param.Value = IcheckAutoAllocationDone;
                //outParam.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(outParam);
                // worked by prabhaker 17-apr-17
                reader = cmd.ExecuteReader();


                Style style = new Style();
                style.StyleID = StyleID;

                while (reader.Read())
                {
                    // worked by prabhaker 17-apr-17  TotalCount = Convert.ToInt32(outParam.Value);

                    // worked by prabhaker 17-apr-17
                    style.StyleCode = Convert.ToString(reader["StyleCode"]);


                }

                return style.StyleCode;
            }

        }

        public Style GetStyleByStyleNumber(string StyleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_style_by_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                Style style = new Style();
                while (reader.Read())
                {
                    style.StyleID = Convert.ToInt32(reader["Id"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.ClientID = Convert.ToInt32(reader["ClientID"]);
                    style.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    style.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                    style.SketchURL = Convert.ToString(reader["SketchURL"]);
                    style.ETA = Convert.ToDateTime(reader["ETA"]);
                    style.TargetPrice = Convert.ToDecimal(reader["TargetPrice"]);
                    style.TargetPriceCurrency = Convert.ToString(reader["TargetPriceCurrency"]);
                    style.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                    style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                    style.ClientName = Convert.ToString(reader["ClientName"]);
                    style.ClientDepartment = Convert.ToString(reader["ClientDepartment"]);
                    style.CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                    style.CourierSentOn = (reader["CourierSentOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierSentOn"]);
                    style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                    style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                    style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                    style.Comments = (reader["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Comments"]);
                    style.SeasonName = (reader["NewSeasonName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["NewSeasonName"]);

                }

                return style;
            }

        }
        public Style GetStyleByNumber_Courier(string StyleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_style_by_number_For_Courier";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                Style style = new Style();
                while (reader.Read())
                {
                    style.StyleID = Convert.ToInt32(reader["Id"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.ClientID = Convert.ToInt32(reader["ClientID"]);
                    style.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    style.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                    style.SketchURL = Convert.ToString(reader["SketchURL"]);
                    style.ETA = Convert.ToDateTime(reader["ETA"]);
                    style.TargetPrice = Convert.ToDecimal(reader["TargetPrice"]);
                    style.TargetPriceCurrency = Convert.ToString(reader["TargetPriceCurrency"]);
                    style.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                    style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                    style.ClientName = Convert.ToString(reader["ClientName"]);
                    style.ClientDepartment = Convert.ToString(reader["ClientDepartment"]);
                    style.CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                    style.CourierSentOn = (reader["CourierSentOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierSentOn"]);
                    style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                    style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                    style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                    style.Comments = (reader["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Comments"]);
                    style.SeasonName = (reader["NewSeasonName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["NewSeasonName"]);

                }

                return style;
            }

        }

        public Style GetStyleByStyleNumberUserSpacific(string StyleNumber, int userid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_style_by_number_userspecific";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Userid", SqlDbType.Int);
                param.Value = userid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                Style style = new Style();
                while (reader.Read())
                {
                    style.StyleID = Convert.ToInt32(reader["Id"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.ClientID = Convert.ToInt32(reader["ClientID"]);
                    style.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    style.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                    style.SketchURL = Convert.ToString(reader["SketchURL"]);
                    style.ETA = Convert.ToDateTime(reader["ETA"]);
                    style.TargetPrice = Convert.ToDecimal(reader["TargetPrice"]);
                    style.TargetPriceCurrency = Convert.ToString(reader["TargetPriceCurrency"]);
                    style.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                    style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                    style.ClientName = Convert.ToString(reader["ClientName"]);
                    style.ClientDepartment = Convert.ToString(reader["ClientDepartment"]);
                    style.CreatedOn = (reader["CreatedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOn"]);
                    style.CourierSentOn = (reader["CourierSentOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierSentOn"]);
                    style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                    style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                    style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                    style.Comments = (reader["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Comments"]);

                }

                return style;
            }

        }

        public int checkFitsStatus(int styleid)
        {
            int result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_Check_StyleFreeje_Status";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = Convert.ToInt32(cmd.ExecuteScalar());

                cnx.Close();

            }
            return result;

        }


        public void InsertFabricPrints(string fabXml)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_insert_fabric_prints";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("fabXml", SqlDbType.VarChar);
                param.Value = fabXml;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }



        public List<StyleFabric> GetStyleFabricsByStyleId(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_style_fabrics_get_style_fabrics_by_style_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Id = Convert.ToInt32(reader["Id"]);
                    StyleFab.FabricName = Convert.ToString(reader["FabricName"]);
                    int PrintID = reader.GetOrdinal("PrintID");
                    int PrintNumber = reader.GetOrdinal("PrintNumber");
                    StyleFab.PrintNumber = string.Empty;
                    if (reader.IsDBNull(PrintID) == false)
                    {
                        StyleFab.PrintID = Convert.ToInt32(reader["PrintID"]);
                    }
                    if (reader.IsDBNull(PrintNumber) == false)
                    {
                        StyleFab.PrintNumber = (reader["PrintNumber"]).ToString();
                    }
                    StyleFab.SpecialFabricDetails = Convert.ToString(reader["SpecialFabricDetails"]);
                    StyleFab.Remarks = Convert.ToString(reader["Remarks"]);
                    StyleFab.FabricType = (FabricType)Convert.ToInt32(reader["FabricType"]);
                    StyleFab.CCGSM = Convert.ToString(reader["Fabric11"]);
                    StyleFab.IsPrintMultiple = Convert.ToString(reader["IsPrintMultiple"]);
                    StyleFab.FabricDesc = Convert.ToString(reader["FabricDesc"]);
                    StyleFab.cost = Convert.ToString(reader["cost"]);
                    //-----------Temprary commentes this block,because this is releated to new costing---------

                    if ((cnx.Database == "SamratDemo14May") || (cnx.Database == "donttouch") || (cnx.Database == "SamratDemo27Aug") || (cnx.Database == "Final_Migration") || (cnx.Database == "SanjeevStockissue") || (cnx.Database == "Material_Migration") || (cnx.Database == "Testing_Final_New"))
                    {
                        StyleFab.FabricQualityId = Convert.ToInt32(reader["fabric_qualityID"]);
                        StyleFab.GSM = Convert.ToString(reader["GSM"]);
                        StyleFab.DyedRate = Convert.ToDouble(reader["DyedRate"]);
                        StyleFab.PrintRate = Convert.ToDouble(reader["PrintRate"]);
                        StyleFab.DigitalPrintRate = Convert.ToDouble(reader["DgtlRate"]);
                        StyleFab.CountConstruct = Convert.ToString(reader["CountConstruct"]);
                        StyleFab.CostWidth = Convert.ToDouble(reader["CostWidth"]);
                        StyleFab.FabTypeDetails = Convert.ToString(reader["fabtypedetail"]);
                    }
                    //---------------------------END------------------------------------------------------------
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }

        public List<StyleReferenceBlock> GetStyleReferenceByStyleId(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_style_reference_block_get_style_reference_block_by_Style_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.ReferenceBlocks = new List<StyleReferenceBlock>();

                while (reader.Read())
                {
                    StyleReferenceBlock StyleRef = new StyleReferenceBlock();
                    StyleRef.Id = Convert.ToInt32(reader["Id"]);
                    StyleRef.Name = Convert.ToString(reader["Name"]);
                    StyleRef.ImagePath = (reader["ReferenceBlockURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReferenceBlockURL"]);
                    StyleRef.Type = (reader["Type"] == DBNull.Value) ? (int)ReferenceBlockType.Block : Convert.ToInt32(reader["Type"]);
                    style.ReferenceBlocks.Add(StyleRef);
                }

                return style.ReferenceBlocks;
            }

        }
        public List<StyleReferenceBlock> GetStyleReferenceByINDnumber(int StyleID, string indnumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetINDFileUrl";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



                SqlParameter param = new SqlParameter("@INDNO", SqlDbType.VarChar);
                param.Value = indnumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.ReferenceBlocks = new List<StyleReferenceBlock>();

                while (reader.Read())
                {
                    StyleReferenceBlock StyleRef = new StyleReferenceBlock();
                    StyleRef.Id = Convert.ToInt32(reader["Id"]);
                    StyleRef.Name = Convert.ToString(reader["Name"]);
                    StyleRef.ImagePath = (reader["ReferenceBlockURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReferenceBlockURL"]);
                    StyleRef.Type = (reader["Type"] == DBNull.Value) ? (int)ReferenceBlockType.Block : Convert.ToInt32(reader["Type"]);
                    style.ReferenceBlocks.Add(StyleRef);
                }

                return style.ReferenceBlocks;
            }

        }
        // Added by Yadvendra on 06/01/2020
        public bool UpdateStyle(Style style)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_styles_update_style";
                //SqlCommand cmd = new SqlCommand(cmdText, cnx);

                SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Update);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;


                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = style.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = style.StyleNumber;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumberDesc", SqlDbType.VarChar);
                param.Value = style.StyleNumberDesc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsMarketingVisible", SqlDbType.Bit);
                param.Value = style.IsMarketingVisible;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = style.ClientID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = style.DepartmentID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDepartmentID", SqlDbType.Int);
                param.Value = style.ParentDepartmentID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SketchURL", SqlDbType.VarChar);
                param.Value = style.SketchURL;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = style.DesignerID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@TargetPrice", SqlDbType.Float);
                param.Value = style.TargetPrice;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@ETA", SqlDbType.DateTime);
                param.Value = style.ETA;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                param = new SqlParameter("@TargetPriceCurrency", SqlDbType.VarChar);
                param.Value = style.TargetPriceCurrency.ToString();
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@AccountManagerID", SqlDbType.Int);
                param.Value = style.AccountManagerID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SamplingMerchandisingManagerID", SqlDbType.Int);
                param.Value = style.SamplingMerchandisingManagerID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Comments", SqlDbType.VarChar);
                param.Value = style.Comments;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                //param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                //param.Value = style.CourierSentOn;
                //param.Direction = ParameterDirection.Input;

                param = new SqlParameter("@CourierSentOn", SqlDbType.DateTime);
                if ((style.CourierSentOn == DateTime.MinValue) || (style.CourierSentOn == Convert.ToDateTime("1753-01-01")) || (style.CourierSentOn == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = style.CourierSentOn;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SeasonID", SqlDbType.Int);
                param.Value = style.SeasonID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Story", SqlDbType.VarChar);
                param.Value = style.Story;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
                param = new SqlParameter("@Meeting", SqlDbType.DateTime);
                if ((style.StyleMeeting == DateTime.MinValue) || (style.StyleMeeting == Convert.ToDateTime("1753-01-01")) || (style.StyleMeeting == Convert.ToDateTime("1900-01-01")))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = style.StyleMeeting;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DocURL", SqlDbType.VarChar);
                param.Value = style.DocURL;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TechPackFile", SqlDbType.VarChar);
                param.Value = style.TackpackFile;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                param.Value = style.SeasonName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //Gajendra Design
                param = new SqlParameter("@DivisionID", SqlDbType.Int);
                param.Value = style.DivisionID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@FitsType", SqlDbType.Int);
                param.Value = style.fitstype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@IsDefault", SqlDbType.Int);
                param.Value = style.IsDefaultStyle;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TechPackFile1", SqlDbType.VarChar);
                param.Value = style.TackpackFile1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TechPackFile2", SqlDbType.VarChar);
                param.Value = style.TackpackFile2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }

        public bool UpdateStyleFromOrder(Style style)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SQL command object
                string cmdText = "sp_styles_update_styles_from_order_form";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;


                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = style.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = style.ClientID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = style.DepartmentID;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }
            return true;
        }

        public bool UpdateStyleFabrics(StyleFabric stylefab)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                //foreach (StyleFabric stylefab in style.Fabrics)
                //{


                string cmdText = "sp_style_fabrics_update_style_fabrics";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = stylefab.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = stylefab.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricName", SqlDbType.VarChar);
                param.Value = stylefab.FabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintID", SqlDbType.Int);
                if (stylefab.PrintID.HasValue)
                {
                    param.Value = stylefab.PrintID;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SpecialFabricDetails", SqlDbType.VarChar);
                param.Value = stylefab.SpecialFabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = stylefab.Remarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricType", SqlDbType.Int);
                param.Value = stylefab.FabricType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();

                //}
                cnx.Close();

            }
            return true;
        }
        public bool UpdateStyleRef(Style style)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                foreach (StyleReferenceBlock styleref in style.ReferenceBlocks)
                {

                    string cmdText = "sp_style_reference_block_update_style_reference_block";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    //cmd.Transaction = myTrans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Value = styleref.Id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = style.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.VarChar);
                    param.Value = styleref.Name;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReferenceBlockURL", SqlDbType.VarChar);
                    param.Value = styleref.ImagePath;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                }
                cnx.Close();
            }

            return true;
        }

        public bool UpdateUrls(Style style)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_styles_update_style_image_urls";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = style.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SampleImageURL1", SqlDbType.VarChar);
                param.Value = style.SampleImageURL1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SampleImageURL2", SqlDbType.VarChar);
                param.Value = style.SampleImageURL2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SampleImageURL3", SqlDbType.VarChar);
                param.Value = style.SampleImageURL3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }


        }
        public bool UpdateStyleRefBlock(StyleReferenceBlock styleref)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_style_reference_block_update_style_reference_block";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                //cmd.Transaction = myTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = styleref.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleref.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.VarChar);
                param.Value = styleref.Name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReferenceBlockURL", SqlDbType.VarChar);
                if (String.IsNullOrEmpty(styleref.ImagePath))
                {
                    param.Value = "";
                }
                else
                {
                    param.Value = styleref.ImagePath;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = styleref.Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }

            return true;

        }

        //public bool UpdateStyleSampleTrackingDate(Style objStyle)
        //{
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();
        //        SqlDataAdapter adapter = new SqlDataAdapter();
        //        string cmdText = "sp_style_update_sample_tracking_date";
        //        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        //        //cmd.Transaction = myTrans;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout =Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param;

        //        param = new SqlParameter("@d", SqlDbType.Int);
        //        param.Value = objStyle.StyleID;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@SampleTrackingDate", SqlDbType.DateTime);
        //        param.Value = objStyle.SampleTrackingDate;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        param = new SqlParameter("@UploadSpecsURL", SqlDbType.VarChar);
        //        param.Value = objStyle.UploadSpecsURL;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        cmd.ExecuteNonQuery();
        //        cnx.Close();
        //    }

        //    return true;

        //}

        public bool DeleteStyleRefBlock(StyleReferenceBlock StyleRef)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_style_reference_block_delete_style_reference_block";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleRef.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = StyleRef.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }


        }


        public bool DeleteStyleFabric(StyleFabric StyleFab)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_style_fabric_delete_style_fabric";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleFab.StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = StyleFab.Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }


        }
        public List<Style> GetAllStyles(int PageSize, int PageIndex, out int TotalRowCount, int ClientId, String SearchText, string SeasonName)
        {
            List<Style> styles = new List<Style>();
            TotalRowCount = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;

                    DataSet dsStyle = new DataSet();

                    cmdText = "sp_styles_get_all_styles";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
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

                    param = new SqlParameter("@UserID", SqlDbType.VarChar);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                    param.Value = SeasonName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsStyle);

                    if (dsStyle.Tables.Count > 0)
                    {
                        DataTable dtMainQuery = dsStyle.Tables[0];
                        DataTable dtCount = dsStyle.Tables[1];
                        DataTable dtCurrentUpdate = dsStyle.Tables[2];

                        if (dtMainQuery.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dtMainQuery.Rows)
                            {
                                SamplingStatus style = new SamplingStatus();
                                style.IssuedOn = (reader["IssuedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["IssuedOn"]);
                                style.StyleID = Convert.ToInt32(reader["Id"]);
                                style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                                style.ClientID = Convert.ToInt32(reader["ClientID"]);
                                style.Buyer = Convert.ToString(reader["ClientName"]);
                                style.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                style.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                                style.SketchURL = Convert.ToString(reader["SketchURL"]);
                                style.ETA = Convert.ToDateTime(reader["ETA"]);
                                style.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                                style.Fabric = (reader["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric"]);
                                if (style.Fabric == "N!!!!")
                                    style.Fabric = "";
                                style.AccountManagerName = ((reader["AccountFirstName"] == DBNull.Value) ? string.Empty : reader["AccountFirstName"].ToString()) + " " + ((reader["AccountLastName"] == DBNull.Value) ? string.Empty : reader["AccountLastName"].ToString());
                                style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                                style.SamplingMerchandisingManagerName = ((reader["SamplingFirstName"] == DBNull.Value) ? string.Empty : reader["SamplingFirstName"].ToString()) + " " + ((reader["SamplingLastName"] == DBNull.Value) ? string.Empty : reader["SamplingLastName"].ToString());
                                style.CourierReceivedOn = reader["CourierReceivedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CourierReceivedOn"]);

                                style.SeasonName = (reader["SeasonName"] != DBNull.Value) ? Convert.ToString(reader["SeasonName"]) : string.Empty;
                                style.Story = (reader["Story"] != DBNull.Value) ? Convert.ToString(reader["Story"]) : string.Empty;
                                style.LastStory = (reader["LastStory"] != DBNull.Value) ? Convert.ToString(reader["LastStory"]) : string.Empty;
                                style.DocURL = (reader["DocURL"] != DBNull.Value) ? Convert.ToString(reader["DocURL"]) : string.Empty;
                                style.StyleMeeting = (reader["MeetingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["MeetingDate"]);

                                style.CurrentUpdate = new List<StyleCurrentUpdate>();
                                string strStyleId = "StyleId =" + style.StyleID;
                                DataRow[] DataRowCurrentUpdate;
                                DataRowCurrentUpdate = dtCurrentUpdate.Select(strStyleId);

                                foreach (DataRow dr in DataRowCurrentUpdate)
                                {
                                    StyleCurrentUpdate objStyleCurrentUpdate = new StyleCurrentUpdate();
                                    objStyleCurrentUpdate.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                                    objStyleCurrentUpdate.StyleId = Convert.ToInt32(dr["StyleId"]);
                                    objStyleCurrentUpdate.Type = (StyleCurrentUpdates)Convert.ToInt32(dr["Type"]);
                                    objStyleCurrentUpdate.IsChecked = (dr["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsChecked"]);
                                    objStyleCurrentUpdate.Date = (dr["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
                                    style.CurrentUpdate.Add(objStyleCurrentUpdate);
                                }

                                styles.Add(style as Style);
                            }
                        }

                        if (dtCount.Rows.Count > 0)
                        {
                            TotalRowCount = Convert.ToInt32(dtCount.Rows[0]["totalCount"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return styles;
        }

        public List<Style> GetStylesByIDs(String StyleIds)
        {
            List<Style> styles = new List<Style>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_style_get_all_styles_by_Ids";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param;

                param = new SqlParameter("@StyleIds", SqlDbType.VarChar);
                param.Value = StyleIds;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SamplingStatus style = new SamplingStatus();
                    style.StyleID = Convert.ToInt32(reader["Id"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.ClientID = Convert.ToInt32(reader["ClientID"]);
                    style.Buyer = Convert.ToString(reader["ClientName"]);
                    style.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    style.SketchURL = Convert.ToString(reader["SketchURL"]);
                    style.ETA = Convert.ToDateTime(reader["ETA"]);
                    style.Fabric = (reader["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric"]);

                    style.Fab11 = (reader["Fab1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fab1"]);
                    style.Fab21 = (reader["Fab2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fab2"]);
                    style.Fab31 = (reader["Fab3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fab3"]);
                    style.Fab41 = (reader["Fab4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fab4"]);
                    style.Fab51 = (reader["Fab5"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fab5"]);
                    style.Fab61 = (reader["Fab6"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fab6"]);
                    style.CCGSM11 = (reader["CCGSM1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CCGSM1"]);
                    style.CCGSM21 = (reader["CCGSM2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CCGSM2"]);
                    style.CCGSM31 = (reader["CCGSM3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CCGSM3"]);
                    style.CCGSM41 = (reader["CCGSM4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CCGSM4"]);
                    style.CCGSM51 = (reader["CCGSM5"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CCGSM5"]);
                    style.CCGSM61 = (reader["CCGSM6"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["CCGSM6"]);


                    style.AccountManagerName = ((reader["AccountFirstName"] == DBNull.Value) ? string.Empty : reader["AccountFirstName"].ToString()) + " " + ((reader["AccountLastName"] == DBNull.Value) ? string.Empty : reader["AccountLastName"].ToString());
                    style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                    style.SamplingMerchandisingManagerName = ((reader["SamplingFirstName"] == DBNull.Value) ? string.Empty : reader["SamplingFirstName"].ToString()) + " " + ((reader["SamplingLastName"] == DBNull.Value) ? string.Empty : reader["SamplingLastName"].ToString());
                    style.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : reader["DesignerFirstName"].ToString()) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : reader["DesignerLastName"].ToString());

                    styles.Add(style as Style);

                }

                reader.Close();


            }

            return styles;

        }




        public List<Style> GetClientDAL(string ClientID)
        {
            List<Style> styles = new List<Style>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_GetClientDAL";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.VarChar);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SamplingStatus style = new SamplingStatus();
                    style.StyleID = Convert.ToInt32(reader["Id"]);
                    style.StyleNumber = Convert.ToString(reader["Name"]);



                    styles.Add(style as Style);

                }

                reader.Close();


            }

            return styles;

        }








        public List<Style> GetNewlyCreatedStyles(DateTime CreatedOn)
        {
            List<Style> styles = new List<Style>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText;
                    DataSet dsStyle = new DataSet();

                    cmdText = "sp_styles_get_new_styles_created";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                    param.Value = CreatedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsStyle);

                    if (dsStyle.Tables.Count > 0)
                    {
                        if (dsStyle.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtMainInformation = dsStyle.Tables[0];

                            foreach (DataRow reader in dtMainInformation.Rows)
                            {
                                Style style = new Style();//inserted on 6 sep 2011
                                //SamplingStatus style = new SamplingStatus(); commented on 6 sep 2011
                                style.StyleID = Convert.ToInt32(reader["Id"]);
                                style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                                style.ClientID = Convert.ToInt32(reader["ClientID"]);
                                style.Buyer = Convert.ToString(reader["ClientName"]);
                                style.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                                style.SketchURL = Convert.ToString(reader["SketchURL"]);
                                style.ETA = Convert.ToDateTime(reader["ETA"]);
                                style.DesignerID = Convert.ToInt32(reader["DesignerID"]);
                                style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                                style.SamplingMerchandisingManagerName = ((reader["SamplingFirstName"] == DBNull.Value) ? string.Empty : reader["SamplingFirstName"].ToString()) + " " + ((reader["SamplingLastName"] == DBNull.Value) ? string.Empty : reader["SamplingLastName"].ToString());
                                style.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : reader["DesignerFirstName"].ToString()) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : reader["DesignerLastName"].ToString());
                                style.BuyingHouseName = (reader["BuyingHouseName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["BuyingHouseName"]);
                                style.Season = (reader["SeasonName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SeasonName"]);
                                style.Story = (reader["EmailStory"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["EmailStory"]);


                                styles.Add(style as Style);
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return styles;
            }
        }

        public bool GetCheckIkandiClientDesignCretae(DateTime CreatedOn)
        {
            bool IsIkandi = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    string cmdText = "usp_CheckIkandiClient";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsStyle = new DataSet();
                    SqlParameter param;

                    param = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                    param.Value = CreatedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsStyle);
                    if (dsStyle.Tables.Count > 0)
                    {
                        IsIkandi = (dsStyle.Tables[8].Rows[0]["IsCheckIkandiClient"] == DBNull.Value) ? false : Convert.ToBoolean(dsStyle.Tables[8].Rows[0]["IsCheckIkandiClient"]);
                    }

                    //transaction.Commit();
                    cnx.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IsIkandi;
            }

        }

        public bool UpdateStyleRemarks(int StyleID, string Remarks)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_UpdateStyleRemarks";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = Remarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }
        public string GetStyleRemarks(int StyleId)
        {
            string Comment = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_GetStyleRemarks";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsStyle = new DataSet();

                    SqlParameter param;

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = StyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsStyle);
                    if (dsStyle.Tables.Count > 0)
                    {
                        if (dsStyle.Tables[0].Rows.Count > 0)
                        {
                            Comment = dsStyle.Tables[0].Rows[0][0].ToString();
                        }
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
                return Comment;
            }
        }

        public List<SamplingStatus> GetAllStylesPendingSamples(string SeasonName, int ClientID, String SearchText, int Marchent, DateTime FDate, DateTime Tdate, int DeptId, int FirstFilter, int SecondFilter, int ThirdFilter, int FourthFilter, decimal fromstatusID, decimal tostatusID, int Delay, int SortingOrder, int Criteria, int ChildDeptIDid)
        {
            List<SamplingStatus> styles = new List<SamplingStatus>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd;
                    string cmdText;

                    cmdText = "sp_styles_get_all_pending_samples_New";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsStyle = new DataSet();

                    SqlParameter param;

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@SeasonId", SqlDbType.VarChar);
                    param.Value = SeasonName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                    param.Value = SearchText;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.VarChar);
                    param.Value = this.LoggedInUser.UserData.UserID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Marchent", SqlDbType.VarChar);
                    param.Value = Marchent;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FromETA", SqlDbType.DateTime);
                    if ((FDate == DateTime.MinValue) || (FDate == Convert.ToDateTime("1753-01-01")) || (FDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = FDate;
                    }
                    //param.Value = FDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ToETA", SqlDbType.DateTime);
                    if ((Tdate == DateTime.MinValue) || (Tdate == Convert.ToDateTime("1753-01-01")) || (Tdate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Tdate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptID", SqlDbType.Int);
                    param.Value = DeptId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fromstatus", SqlDbType.Float);
                    param.Value = fromstatusID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Totatus", SqlDbType.Float);
                    param.Value = tostatusID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Delay", SqlDbType.Int);
                    param.Value = Delay;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SortingOrder", SqlDbType.Int);
                    param.Value = SortingOrder;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // ------------------Ordering In filter
                    param = new SqlParameter("@OrderBy1", SqlDbType.Int);
                    param.Value = FirstFilter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@OrderBy2", SqlDbType.Int);
                    param.Value = SecondFilter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@OrderBy3", SqlDbType.Int);
                    param.Value = ThirdFilter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@OrderBy4", SqlDbType.Int);
                    param.Value = FourthFilter;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Criteria", SqlDbType.Int);
                    param.Value = Criteria;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChildDeptIDid", SqlDbType.Int);
                    param.Value = ChildDeptIDid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // -----------------end

                    //param.Value = Tdate;



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsStyle);

                    if (dsStyle.Tables.Count > 0)
                    {
                        DataTable dtMainStyle = dsStyle.Tables[0];
                        DataTable dtCurrentUpdate = dsStyle.Tables[1];
                        DataTable dtBuyerDetail = dsStyle.Tables[2];

                        foreach (DataRow reader in dtMainStyle.Rows)
                        {
                            SamplingStatus style = new SamplingStatus();
                            style.IssuedOn = (reader["IssuedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["IssuedOn"]);
                            style.StyleID = Convert.ToInt32(reader["Id"]);
                            style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                            style.ClientID = Convert.ToInt32(reader["ClientID"]);
                            style.Buyer = Convert.ToString(reader["ClientName"]);
                            style.DepartmentName = Convert.ToString(reader["SubClientdName"]) + (Convert.ToString(reader["DepartmentName"]) == "" ? "" : "(" + Convert.ToString(reader["DepartmentName"]) + ")");
                            style.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                            style.SketchURL = Convert.ToString(reader["SketchURL"]);
                            style.Remarks = Convert.ToString(reader["Remarks"]);
                            style.ETA = (reader["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ETA"]);
                            style.MerchandiserDispatchDate = (reader["MerchandiserDispatchDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["MerchandiserDispatchDate"]);

                            style.Fabric = (reader["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric"]);
                            if (style.Fabric == "N!!!!")
                                style.Fabric = "";
                            style.CCGSM = (reader["Fabric11"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric11"]);
                            style.AccountManagerID = Convert.ToInt32(reader["AccountManagerID"]);
                            style.AccountManagerName = ((reader["AccountFirstName"] == DBNull.Value) ? string.Empty : reader["AccountFirstName"].ToString()) + " " + ((reader["AccountLastName"] == DBNull.Value) ? string.Empty : reader["AccountLastName"].ToString());
                            style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                            style.SamplingMerchandisingManagerName = ((reader["SamplingFirstName"] == DBNull.Value) ? string.Empty : reader["SamplingFirstName"].ToString()) + " " + ((reader["SamplingLastName"] == DBNull.Value) ? string.Empty : reader["SamplingLastName"].ToString());
                            style.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                            style.Status = (reader["StatusName"] != DBNull.Value) ? Convert.ToString(reader["StatusName"]) : string.Empty;
                            style.SamplingStatusRemarks = (reader["SamplingStatusRemarks"] != DBNull.Value) ? Convert.ToString(reader["SamplingStatusRemarks"]) : string.Empty;
                            style.CourierReceivedOn = (reader["CourierReceivedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CourierReceivedOn"]);
                            style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                            style.SampleImageURL2 = (reader["SampleImageURL2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL2"]);
                            style.SampleImageURL3 = (reader["SampleImageURL3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL3"]);
                            style.SeasonName = (reader["SeasonName"] != DBNull.Value) ? Convert.ToString(reader["SeasonName"]) : string.Empty;

                            style.Story = (reader["Story"] != DBNull.Value) ? Convert.ToString(reader["Story"]) : string.Empty;
                            style.LastStory = (reader["LastStory"] != DBNull.Value) ? Convert.ToString(reader["LastStory"]) : string.Empty;
                            style.DocURL = (reader["DocURL"] != DBNull.Value) ? Convert.ToString(reader["DocURL"]) : string.Empty;
                            style.StyleMeeting = (reader["MeetingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["MeetingDate"]);
                            // edit by prabhker on 26-07-2017--------------------------------------------------------------------------------------------
                            style.HandOverEta = (reader["HandOverEta"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverEta"]);
                            style.HandOverAct = (reader["HandOverAct"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["HandOverAct"]);
                            style.PatternReadyEta = (reader["PatternReadyEta"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PatternReadyEta"]);
                            style.PatternReadyAct = (reader["PatternReadyAct"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PatternReadyAct"]);
                            style.SampleSentEta = (reader["SampleSentEta"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentEta"]);
                            style.SampleSentAct = (reader["SampleSentAct"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SampleSentAct"]);
                            style.CostingBiplEta = (reader["CostingBiplEta"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CostingBiplEta"]);
                            style.CostingBiplAct = (reader["CostingBiplAct"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["CostingBiplAct"]);
                            style.PriceQuotedBiplEta = (reader["PriceQuotedBiplEta"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PriceQuotedBiplEta"]);
                            style.PriceQuotedBiplAct = (reader["PriceQuotedBiplAct"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PriceQuotedBiplAct"]);
                            style.fitstype = (reader["FitsType"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["FitsType"]);

                            style.CadMasterName = (reader["CadMasterName"] != DBNull.Value) ? Convert.ToString(reader["CadMasterName"]) : string.Empty;
                            style.BuyerStyleNumber = (reader["BuyerStyleNumber"] != DBNull.Value) ? Convert.ToString(reader["BuyerStyleNumber"]) : string.Empty;
                            style.IsSelected = (reader["IsSelected"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsSelected"]);
                            // end


                            style.CurrentUpdate = new List<StyleCurrentUpdate>();

                            string strStyleId = "StyleId =" + style.StyleID;
                            DataRow[] DataRowCurrentUpdate;
                            DataRowCurrentUpdate = dtCurrentUpdate.Select(strStyleId);

                            foreach (DataRow dr in DataRowCurrentUpdate)
                            {
                                StyleCurrentUpdate objStyleCurrentUpdate = new StyleCurrentUpdate();
                                objStyleCurrentUpdate.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                                objStyleCurrentUpdate.StyleId = Convert.ToInt32(dr["StyleId"]);
                                objStyleCurrentUpdate.Type = (StyleCurrentUpdates)Convert.ToInt32(dr["Type"]);
                                objStyleCurrentUpdate.IsChecked = (dr["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsChecked"]);
                                objStyleCurrentUpdate.Date = (dr["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
                                style.CurrentUpdate.Add(objStyleCurrentUpdate);
                            }

                            style.BuyerDetail = new List<StyleBuyerDetail>();

                            DataRow[] DataRowBuyerDetail;
                            DataRowBuyerDetail = dtBuyerDetail.Select(strStyleId);

                            foreach (DataRow dr in DataRowBuyerDetail)
                            {
                                StyleBuyerDetail objStyleBuyerDetail = new StyleBuyerDetail();
                                objStyleBuyerDetail.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                                objStyleBuyerDetail.StyleId = Convert.ToInt32(dr["StyleId"]);
                                objStyleBuyerDetail.FabricName = dr["FabricName"].ToString();
                                objStyleBuyerDetail.Fabric_Name = dr["Fabric_Name"].ToString();
                                objStyleBuyerDetail.Remarks = dr["Remarks"].ToString();
                                objStyleBuyerDetail.PrintID = (dr["PrintID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PrintID"]);
                                objStyleBuyerDetail.SpecialFabricDetails = dr["SpecialFabricDetails"].ToString();
                                objStyleBuyerDetail.FabricType = (dr["FabricType"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["FabricType"]);
                                objStyleBuyerDetail.RCVDBUYER = (dr["RCVDBUYER"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["RCVDBUYER"]);
                                objStyleBuyerDetail.ISSUEDON = (dr["ISSUEDON"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["ISSUEDON"]);
                                objStyleBuyerDetail.ETA = (dr["ETA"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["ETA"]);
                                objStyleBuyerDetail.Actual = (dr["Actual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Actual"]);
                                objStyleBuyerDetail.STATUS = Convert.ToInt32(dr["STATUS"]);

                                style.BuyerDetail.Add(objStyleBuyerDetail);
                            }

                            styles.Add(style);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return styles;
            }
        }





        public bool UpdateStylesCourierReceivedOnById(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_styles_update_courier_received_by_styleid";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourierReceivedOn", SqlDbType.DateTime);
                param.Value = DateTime.Now;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }





        /// <summary>
        /// ///
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ClientID"></param>
        /// <param name="SortBy"></param>
        /// <param name="Search"></param>
        /// <param name="SeasonId"></param>
        /// <param name="StoryText"></param>
        /// <returns></returns>


        public List<SamplingStatus> GetAllStyleSamplingStatusDAL(int UserId, int ClientID, int SortBy, string Search, string SeasonName, string IsOwnerLoggedIn)
        {
            List<SamplingStatus> styles = new List<SamplingStatus>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText = "sp_styles_get_all_style_sampling_status_season_filter";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsSamplingStatus = new DataSet();
                    SqlParameter param;
                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SortBy", SqlDbType.Int);
                    param.Value = SortBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Search", SqlDbType.VarChar);
                    if (!string.IsNullOrEmpty(Search))
                        param.Value = Search;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                    param.Value = SeasonName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sOwnerLoggedIn", SqlDbType.VarChar);
                    param.Value = IsOwnerLoggedIn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsSamplingStatus);

                    if (dsSamplingStatus.Tables[0].Rows.Count > 0)
                    {

                        DataTable dtBasicDetail = dsSamplingStatus.Tables[0];
                        DataTable dtCurrentUpdates = dsSamplingStatus.Tables[1];

                        if (dtBasicDetail.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dtBasicDetail.Rows)
                            {
                                SamplingStatus style = new SamplingStatus();
                                style.StyleID = Convert.ToInt32(reader["Id"]);
                                style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                                style.ClientName = style.Buyer = Convert.ToString(reader["Buyer"]);
                                style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                                style.FactoryName = (reader["FactoryName"] != DBNull.Value) ? Convert.ToString(reader["FactoryName"]) : string.Empty;
                                style.Fabric = (reader["Fabric"] != DBNull.Value) ? Convert.ToString(reader["Fabric"]) : string.Empty;
                                style.IssuedOn = (reader["IssuedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["IssuedOn"]) : DateTime.Now;
                                style.ReceivedOn = (reader["ReceivedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ReceivedOn"]) : style.IssuedOn;
                                style.ETA = (reader["ETA"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ETA"]) : DateTime.Now;

                                style.MerchandiserDispatchDate = (reader["MerchandiserDispatchDate"] != System.DBNull.Value) ? Convert.ToDateTime(reader["MerchandiserDispatchDate"]) : style.ETA;
                                style.SentToiKandiOn = (reader["SentToiKandiOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["SentToiKandiOn"]) : DateTime.MinValue;
                                style.CounterComplete = (reader["CounterComplete"] != System.DBNull.Value) ? Convert.ToInt32(reader["CounterComplete"]) : 0;
                                style.Status = (reader["Status"] != DBNull.Value) ? Convert.ToString(reader["Status"]) : string.Empty;
                                style.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                                style.StatusColor = Constants.GetStatusModeColor(style.StatusModeID);
                                style.SketchURL = (reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"]);
                                style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                                style.DesignerName = (reader["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerName"]);
                                style.SamplingMerchandisingManagerName = Convert.ToString(reader["SamplingMerchandisingManagerName"]);
                                style.SeasonName = (reader["SeasonName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SeasonName"]);
                                style.Story = (reader["AllStory"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllStory"]);
                                style.LastStory = (reader["LastStory"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastStory"]);
                                style.DocURL = (reader["DocURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DocURL"]);
                                style.StyleMeeting = (reader["MeetingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["MeetingDate"]);
                                string AssinmentString = (reader["Assignment"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Assignment"]);
                                style.Assignment = AssinmentString.Replace("#", "&nbsp");

                                string allfabric = (reader["lblFabric"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["lblFabric"]);
                                allfabric = allfabric.Replace("$$", "/Internal/Fabric/FabricApprovals.aspx");
                                allfabric = allfabric.Replace("SId", "StyleID");
                                allfabric = allfabric.Replace("**", "height");

                                allfabric = allfabric.Replace("!!", "style");

                                allfabric = allfabric.Replace("~~", "clientid");
                                // allfabric = allfabric.Replace("##", "<TABLE width=''100%'' cellpadding=''10'' cellspacing=''0''>");
                                allfabric = allfabric.Replace("@@", "background");
                                allfabric = allfabric.Replace("++", "span");
                                allfabric = allfabric.Replace("##", "color:blue");
                                allfabric = allfabric.Replace("^^", "fabricdetails");
                                if (allfabric.IndexOf("<<") != -1)
                                {
                                    allfabric = allfabric.Replace("<<", "<");
                                }

                                style.NewFabric = allfabric;
                                string remarks = (reader["SamplingStatusRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SamplingStatusRemarks"]);
                                style.FabRemarks = (reader["FabRem"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabRem"]);
                                style.AllFabRemarks = (reader["AllFabRem"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllFabRem"]);
                                string TrakingFirst = (reader["TrackingFirst"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TrackingFirst"]);
                                string TrakingSecond = (reader["TrackingSecond"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TrackingSecond"]);
                                if (TrakingFirst.IndexOf("~") != -1)
                                {
                                    TrakingFirst = TrakingFirst.Replace("~", "");
                                }
                                if (TrakingSecond.IndexOf("~") != -1)
                                {
                                    TrakingSecond = TrakingSecond.Replace("~", "");
                                }
                                string s = TrakingFirst + TrakingSecond;
                                s = "<table>" + s + "</table>";

                                // string strTracking = (reader["Tracking"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Tracking"]);
                                //// 'ACTUAL ISSUE','$$'),'ACTUAL RECEIVED','**'),'RECEIVING STATUS','!!'),'background-color','^^')
                                s = s.Replace("#", ",");
                                s = s.Replace("$$", "ACTUAL ISSUE");
                                s = s.Replace("**", "ACTUAL RECEIVED");
                                s = s.Replace("!!", "RECEIVING STATUS");
                                s = s.Replace("^^", "background");
                                s = s.Replace("++", "span");
                                s = s.Replace("@", "color:blue");
                                style.Tracking = s;
                                style.MeterageInHouse = (reader["MeterageHouse"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MeterageHouse"]);
                                style.OwnerAllResolution = (reader["AllResolutionRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllResolutionRemarks"]);
                                style.OwnerLastResolution = (reader["LastResolutionRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastResolutionRemarks"]);
                                style.WorkFlowAllResolution = (reader["AllWorkFlowRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllWorkFlowRemarks"]);
                                style.WorkFlowLastResolution = (reader["LastWorkFlowRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastWorkFlowRemarks"]);
                                style.AllSeasonStory = (reader["SeasonStory"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SeasonStory"]);
                                style.FabricCount = (reader["FabricCount"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricCount"]);


                                style.LastIssue = (reader["LastIssue"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastIssue"]);
                                style.AllIssue = (reader["AllIssue"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllIssue"]);
                                style.AllStyleFabric = (reader["AllStyleFabric"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllStyleFabric"]);

                                string replaceRemarks = remarks;

                                if (remarks.ToString().IndexOf("$$") > -1)
                                {
                                    remarks = remarks.ToString().Substring(remarks.ToString().LastIndexOf("$$") + 2);
                                }
                                else
                                {
                                    remarks = remarks.ToString();
                                }
                                style.SamplingStatusRemarks = remarks;

                                if (replaceRemarks.ToString().IndexOf("$$") > -1)
                                {
                                    replaceRemarks = replaceRemarks.ToString().Replace("$$", "<br/>");
                                }
                                else
                                {
                                    replaceRemarks = replaceRemarks.ToString();
                                }
                                style.SamplingStatusRemarksReplace = replaceRemarks.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");


                                style.CurrentUpdate = new List<StyleCurrentUpdate>();

                                string strStyleId = "StyleId =" + style.StyleID;
                                DataRow[] DataRowCurrentUpdate;
                                DataRowCurrentUpdate = dtCurrentUpdates.Select(strStyleId);

                                foreach (DataRow dr in DataRowCurrentUpdate)
                                {
                                    StyleCurrentUpdate objStyleCurrentUpdate = new StyleCurrentUpdate();
                                    objStyleCurrentUpdate.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                                    objStyleCurrentUpdate.StyleId = Convert.ToInt32(dr["StyleId"]);
                                    objStyleCurrentUpdate.Type = (StyleCurrentUpdates)Convert.ToInt32(dr["Type"]);
                                    objStyleCurrentUpdate.IsChecked = (dr["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsChecked"]);
                                    objStyleCurrentUpdate.Date = (dr["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
                                    style.CurrentUpdate.Add(objStyleCurrentUpdate);
                                }

                                styles.Add(style);
                            }
                        }
                    }
                }
                catch
                {

                }
                return styles;


            }
        }


        public List<SamplingStatus> GetAllStyleSamplingStatusDAL_Pdf(int UserId, int ClientID, int SortBy, string Search, string SeasonName, string IsOwnerLoggedIn)
        {
            List<SamplingStatus> styles = new List<SamplingStatus>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText = "sp_styles_get_all_style_sampling_status_season_filter_pdf";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsSamplingStatus = new DataSet();
                    SqlParameter param;
                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SortBy", SqlDbType.Int);
                    param.Value = SortBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Search", SqlDbType.VarChar);
                    if (!string.IsNullOrEmpty(Search))
                        param.Value = Search;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                    param.Value = SeasonName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sOwnerLoggedIn", SqlDbType.VarChar);
                    param.Value = IsOwnerLoggedIn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsSamplingStatus);

                    if (dsSamplingStatus.Tables[0].Rows.Count > 0)
                    {

                        DataTable dtBasicDetail = dsSamplingStatus.Tables[0];
                        DataTable dtCurrentUpdates = dsSamplingStatus.Tables[1];

                        if (dtBasicDetail.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dtBasicDetail.Rows)
                            {
                                SamplingStatus style = new SamplingStatus();
                                style.StyleID = Convert.ToInt32(reader["Id"]);
                                style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                                style.ClientName = style.Buyer = Convert.ToString(reader["Buyer"]);
                                style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                                style.FactoryName = (reader["FactoryName"] != DBNull.Value) ? Convert.ToString(reader["FactoryName"]) : string.Empty;
                                style.Fabric = (reader["Fabric"] != DBNull.Value) ? Convert.ToString(reader["Fabric"]) : string.Empty;
                                style.IssuedOn = (reader["IssuedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["IssuedOn"]) : DateTime.Now;
                                style.ReceivedOn = (reader["ReceivedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ReceivedOn"]) : style.IssuedOn;
                                style.ETA = (reader["ETA"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ETA"]) : DateTime.Now;

                                style.MerchandiserDispatchDate = (reader["MerchandiserDispatchDate"] != System.DBNull.Value) ? Convert.ToDateTime(reader["MerchandiserDispatchDate"]) : style.ETA;
                                style.SentToiKandiOn = (reader["SentToiKandiOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["SentToiKandiOn"]) : DateTime.MinValue;
                                style.CounterComplete = (reader["CounterComplete"] != System.DBNull.Value) ? Convert.ToInt32(reader["CounterComplete"]) : 0;
                                style.Status = (reader["Status"] != DBNull.Value) ? Convert.ToString(reader["Status"]) : string.Empty;
                                style.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                                style.StatusColor = Constants.GetStatusModeColor(style.StatusModeID);
                                style.SketchURL = (reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"]);
                                style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                                style.DesignerName = (reader["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerName"]);
                                style.SamplingMerchandisingManagerName = Convert.ToString(reader["SamplingMerchandisingManagerName"]);
                                style.SeasonName = (reader["SeasonName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SeasonName"]);
                                style.Story = (reader["AllStory"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllStory"]);
                                style.LastStory = (reader["LastStory"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastStory"]);
                                style.DocURL = (reader["DocURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DocURL"]);
                                style.StyleMeeting = (reader["MeetingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["MeetingDate"]);
                                style.Assignment = (reader["Assignment"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Assignment"]);
                                string allfabric = (reader["lblFabric"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["lblFabric"]);
                                allfabric = allfabric.Replace("$$", "/Internal/Fabric/FabricApprovals.aspx");
                                allfabric = allfabric.Replace("**", "height");
                                allfabric = allfabric.Replace("!!", "style");
                                allfabric = allfabric.Replace("~~", "clientid");
                                // allfabric = allfabric.Replace("##", "<TABLE width=''100%'' cellpadding=''10'' cellspacing=''0''>");
                                allfabric = allfabric.Replace("@@", "background");
                                allfabric = allfabric.Replace("++", "span");
                                allfabric = allfabric.Replace("##", "color:blue");
                                allfabric = allfabric.Replace("^^", "fabricdetails");
                                if (allfabric.IndexOf("<<") != -1)
                                {
                                    allfabric = allfabric.Replace("<<", "<");
                                }

                                style.NewFabric = allfabric;
                                string remarks = (reader["SamplingStatusRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SamplingStatusRemarks"]);
                                style.FabRemarks = (reader["FabRem"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabRem"]);
                                style.AllFabRemarks = (reader["AllFabRem"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllFabRem"]);
                                //string TrakingFirst = (reader["TrackingFirst"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TrackingFirst"]);
                                //string TrakingSecond = (reader["TrackingSecond"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TrackingSecond"]);
                                //if (TrakingFirst.IndexOf("~") != -1)
                                //{
                                //    TrakingFirst = TrakingFirst.Replace("~", "");
                                //}
                                //if (TrakingSecond.IndexOf("~") != -1)
                                //{
                                //    TrakingSecond = TrakingSecond.Replace("~", "");
                                //}
                                //string s = TrakingFirst + TrakingSecond;

                                //s = s.Replace("#", ",");
                                //s = s.Replace("$$", "ACTUAL ISSUE");
                                //s = s.Replace("**", "ACTUAL RECEIVED");
                                //s = s.Replace("!!", "RECEIVING STATUS");
                                //style.Tracking = s;


                                /////////////
                                string TrakingFirst = (reader["TrackingFirst"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TrackingFirst"]);
                                string TrakingSecond = (reader["TrackingSecond"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["TrackingSecond"]);
                                //if (TrakingFirst.IndexOf("~") != -1)
                                //{
                                //    TrakingFirst = TrakingFirst.Replace("~", "");
                                //}
                                //if (TrakingSecond.IndexOf("~") != -1)
                                //{
                                //    TrakingSecond = TrakingSecond.Replace("~", "");
                                //}
                                string s = TrakingFirst + "~" + TrakingSecond;
                                s = s.Replace("&", "");
                                // s = "<table>" + s + "</table>";

                                // string strTracking = (reader["Tracking"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Tracking"]);
                                //// 'ACTUAL ISSUE','$$'),'ACTUAL RECEIVED','**'),'RECEIVING STATUS','!!'),'background-color','^^')
                                s = s.Replace("#", ",");
                                s = s.Replace("$$", "ACTUAL ISSUE");
                                s = s.Replace("**", "ACTUAL RECEIVED");
                                s = s.Replace("!!", "RECEIVING STATUS");
                                s = s.Replace("^^", "background");
                                s = s.Replace("++", "span");
                                s = s.Replace("@", "color:blue");
                                style.Tracking = s;
                                ///////
                                style.MeterageInHouse = (reader["MeterageHouse"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["MeterageHouse"]);
                                style.OwnerAllResolution = (reader["AllResolutionRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllResolutionRemarks"]);
                                style.OwnerLastResolution = (reader["LastResolutionRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastResolutionRemarks"]);
                                style.WorkFlowAllResolution = (reader["AllWorkFlowRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllWorkFlowRemarks"]);
                                style.WorkFlowLastResolution = (reader["LastWorkFlowRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastWorkFlowRemarks"]);
                                style.AllSeasonStory = (reader["SeasonStory"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SeasonStory"]);
                                style.FabricCount = (reader["FabricCount"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FabricCount"]);


                                style.LastIssue = (reader["LastIssue"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LastIssue"]);
                                style.AllIssue = (reader["AllIssue"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AllIssue"]);


                                string replaceRemarks = remarks;

                                if (remarks.ToString().IndexOf("$$") > -1)
                                {
                                    remarks = remarks.ToString().Substring(remarks.ToString().LastIndexOf("$$") + 2);
                                }
                                else
                                {
                                    remarks = remarks.ToString();
                                }
                                style.SamplingStatusRemarks = remarks;

                                if (replaceRemarks.ToString().IndexOf("$$") > -1)
                                {
                                    replaceRemarks = replaceRemarks.ToString().Replace("$$", "<br/>");
                                }
                                else
                                {
                                    replaceRemarks = replaceRemarks.ToString();
                                }
                                style.SamplingStatusRemarksReplace = replaceRemarks.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");


                                style.CurrentUpdate = new List<StyleCurrentUpdate>();

                                string strStyleId = "StyleId =" + style.StyleID;
                                DataRow[] DataRowCurrentUpdate;
                                DataRowCurrentUpdate = dtCurrentUpdates.Select(strStyleId);

                                foreach (DataRow dr in DataRowCurrentUpdate)
                                {
                                    StyleCurrentUpdate objStyleCurrentUpdate = new StyleCurrentUpdate();
                                    objStyleCurrentUpdate.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                                    objStyleCurrentUpdate.StyleId = Convert.ToInt32(dr["StyleId"]);
                                    objStyleCurrentUpdate.Type = (StyleCurrentUpdates)Convert.ToInt32(dr["Type"]);
                                    objStyleCurrentUpdate.IsChecked = (dr["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsChecked"]);
                                    objStyleCurrentUpdate.Date = (dr["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
                                    style.CurrentUpdate.Add(objStyleCurrentUpdate);
                                }

                                styles.Add(style);
                            }
                        }
                    }
                }
                catch
                {

                }
                return styles;


            }
        }

        public List<SamplingStatus> GetAllStyleSamplingStatus(int UserId, int ClientID, int SortBy, string Search)
        {
            List<SamplingStatus> styles = new List<SamplingStatus>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText = "sp_styles_get_all_style_sampling_status";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsSamplingStatus = new DataSet();
                    SqlParameter param;
                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SortBy", SqlDbType.Int);
                    param.Value = SortBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Search", SqlDbType.VarChar);
                    if (!string.IsNullOrEmpty(Search))
                        param.Value = Search;
                    else
                        param.Value = DBNull.Value;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);




                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsSamplingStatus);

                    if (dsSamplingStatus.Tables[0].Rows.Count > 0)
                    {

                        DataTable dtBasicDetail = dsSamplingStatus.Tables[0];
                        DataTable dtCurrentUpdates = dsSamplingStatus.Tables[1];

                        if (dtBasicDetail.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dtBasicDetail.Rows)
                            {
                                SamplingStatus style = new SamplingStatus();
                                style.StyleID = Convert.ToInt32(reader["Id"]);
                                style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                                style.ClientName = style.Buyer = Convert.ToString(reader["Buyer"]);
                                style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                                style.FactoryName = (reader["FactoryName"] != DBNull.Value) ? Convert.ToString(reader["FactoryName"]) : string.Empty;
                                style.Fabric = (reader["Fabric"] != DBNull.Value) ? Convert.ToString(reader["Fabric"]) : string.Empty;
                                style.IssuedOn = (reader["IssuedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["IssuedOn"]) : DateTime.Now;
                                style.ReceivedOn = (reader["ReceivedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ReceivedOn"]) : style.IssuedOn;
                                style.ETA = (reader["ETA"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ETA"]) : DateTime.Now;
                                style.MerchandiserDispatchDate = (reader["MerchandiserDispatchDate"] != System.DBNull.Value) ? Convert.ToDateTime(reader["MerchandiserDispatchDate"]) : style.ETA;
                                style.SentToiKandiOn = (reader["SentToiKandiOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["SentToiKandiOn"]) : DateTime.MinValue;
                                style.CounterComplete = (reader["CounterComplete"] != System.DBNull.Value) ? Convert.ToInt32(reader["CounterComplete"]) : 0;
                                style.Status = (reader["Status"] != DBNull.Value) ? Convert.ToString(reader["Status"]) : string.Empty;
                                style.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                                style.StatusColor = Constants.GetStatusModeColor(style.StatusModeID);
                                style.SketchURL = (reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"]);
                                style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                                style.DesignerName = (reader["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerName"]);

                                string remarks = (reader["SamplingStatusRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SamplingStatusRemarks"]);
                                string replaceRemarks = remarks;

                                if (remarks.ToString().IndexOf("$$") > -1)
                                {
                                    remarks = remarks.ToString().Substring(remarks.ToString().LastIndexOf("$$") + 2);
                                }
                                else
                                {
                                    remarks = remarks.ToString();
                                }
                                style.SamplingStatusRemarks = remarks;

                                if (replaceRemarks.ToString().IndexOf("$$") > -1)
                                {
                                    replaceRemarks = replaceRemarks.ToString().Replace("$$", "<br/>");
                                }
                                else
                                {
                                    replaceRemarks = replaceRemarks.ToString();
                                }
                                style.SamplingStatusRemarksReplace = replaceRemarks.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");


                                style.CurrentUpdate = new List<StyleCurrentUpdate>();

                                string strStyleId = "StyleId =" + style.StyleID;
                                DataRow[] DataRowCurrentUpdate;
                                DataRowCurrentUpdate = dtCurrentUpdates.Select(strStyleId);

                                foreach (DataRow dr in DataRowCurrentUpdate)
                                {
                                    StyleCurrentUpdate objStyleCurrentUpdate = new StyleCurrentUpdate();
                                    objStyleCurrentUpdate.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                                    objStyleCurrentUpdate.StyleId = Convert.ToInt32(dr["StyleId"]);
                                    objStyleCurrentUpdate.Type = (StyleCurrentUpdates)Convert.ToInt32(dr["Type"]);
                                    objStyleCurrentUpdate.IsChecked = (dr["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsChecked"]);
                                    objStyleCurrentUpdate.Date = (dr["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
                                    style.CurrentUpdate.Add(objStyleCurrentUpdate);
                                }

                                styles.Add(style);
                            }
                        }
                    }
                }
                catch
                {

                }
                return styles;


            }
        }

        public bool UpdateStyleSampleStatus(SamplingStatus StyleStatus)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;
                try
                {
                    cnx.Open();
                    transaction = cnx.BeginTransaction();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "sp_styles_update_style_sample_status";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter param;

                    param = new SqlParameter("@d", SqlDbType.Int);
                    param.Value = StyleStatus.StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryName", SqlDbType.VarChar);
                    param.Value = StyleStatus.FactoryName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SamplingMerchandisingManagerID", SqlDbType.Int);
                    param.Value = StyleStatus.SamplingMerchandisingManagerID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedOn", SqlDbType.DateTime);
                    param.Value = StyleStatus.ReceivedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MerchandiserDispatchDate", SqlDbType.DateTime);
                    param.Value = StyleStatus.MerchandiserDispatchDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CounterComplete", SqlDbType.Int);
                    param.Value = StyleStatus.CounterComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    if (StyleStatus.CurrentUpdate != null)
                    {
                        if (StyleStatus.CurrentUpdate.Count > 0)
                        {
                            foreach (StyleCurrentUpdate objStyleCurrentUpdate in StyleStatus.CurrentUpdate)
                            {
                                if (objStyleCurrentUpdate.IsChecked == true && objStyleCurrentUpdate.Date != DateTime.MinValue)
                                {
                                    this.StyleCurrentUpdateOperation(objStyleCurrentUpdate, cnx, transaction);
                                }
                            }
                        }
                    }

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
            return true;
        }

        public void StyleCurrentUpdateOperation(StyleCurrentUpdate objStyleCurrentUpdate, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_style_current_insert_update_operation";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@StyleId", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objStyleCurrentUpdate.StyleId;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.Int);
            param.Value = objStyleCurrentUpdate.Type;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@sChecked", SqlDbType.Bit);
            param.Value = objStyleCurrentUpdate.IsChecked;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Date", SqlDbType.DateTime);
            param.Value = objStyleCurrentUpdate.Date;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }


        public string GetMaxStyleNumber(string Code)
        {
            string result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_styles_get_max_style_number";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Code", SqlDbType.Int);
                param.Value = Code;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object obj = cmd.ExecuteScalar();

                object ss = obj.GetType();

                if (obj != DBNull.Value && obj != null)
                    //result = (obj).ToString();
                    result = obj.ToString(); //System.Text.ASCIIEncoding.ASCII.GetString((byte[])(obj)).ToString();
                else
                    result = "XX 00001";

                cnx.Close();

            }
            return result;

        }

        public int GetPrintIdByPrintNumber(string PrintNumber)
        {
            int result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_styles_get_printId_by_printNumber";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@PrintNumber", SqlDbType.VarChar);
                param.Value = PrintNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = Convert.ToInt32(cmd.ExecuteScalar());

                cnx.Close();

            }
            return result;

        }

        //public int GetPrintNumberByPrintId(int PrintNumber)
        //{
        //    int result;
        //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        //    {
        //        cnx.Open();
        //        SqlDataAdapter adapter = new SqlDataAdapter();

        //        string cmdText = "sp_styles_get_printId_by_printNumber";
        //        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        //        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout =Constants.CONFIGURATION_TimeOut;
        //        SqlParameter param;

        //        param = new SqlParameter("@PrintNumber", SqlDbType.Int);
        //        param.Value = PrintNumber;
        //        param.Direction = ParameterDirection.Input;
        //        cmd.Parameters.Add(param);

        //        result = cmd.ExecuteScalar().ToString();
        //        cnx.Close();

        //    }
        //    return result;

        //}

        public List<Style> GetClientStyles(int ClientID)
        {
            List<Style> styles = new List<Style>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_client_styles";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Style style = new Style();
                    style.StyleID = Convert.ToInt32(reader["Id"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);

                    styles.Add(style);
                }
            }
            return styles;
        }

        public DataSet GetAllStylePhotos(int StyleID, int OrderID, int OrderDetailID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_style_get_all_style_photos";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.CommandText = cmdText;
                cmd.Connection = cnx;

                SqlParameter param;
                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = StyleID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = OrderDetailID;
                cmd.Parameters.Add(param);

                DataSet dsStylePhotos = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsStylePhotos);

                cnx.Close();

                return dsStylePhotos;


            }
        }

        public bool CloneStyleNumber(string parentStyleNumber, string styleNumber, int clientId, int departmentId, int costingId, string orderIDs, string selectedItemSample, int avg, int Cad, int obsheet, int sam, int ob, int cmt)
        {
            SqlTransaction transaction = null;

            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "sp_style_clone_style_number";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.CommandText = cmdText;
                    cmd.Connection = cnx;

                    SqlParameter outParam = new SqlParameter("@StyleId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter outParamCosting = new SqlParameter("@NewCostingId", SqlDbType.Int);
                    outParamCosting.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParamCosting);

                    SqlParameter param;
                    param = new SqlParameter("@ParentStyleNumber", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = parentStyleNumber;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = styleNumber;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = clientId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = departmentId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = costingId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderIDs", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = orderIDs;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleChecked", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = selectedItemSample;
                    cmd.Parameters.Add(param);

                    //added by abhishek 23/5/2017

                    //param = new SqlParameter("@avgval", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //if (avg == 0)
                    //{
                    //    param.Value = DBNull.Value;
                    //}
                    //else
                    //{
                    //    param.Value = avg;
                    //}                    
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@Cadval", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //if (Cad == 0)
                    //{
                    //    param.Value = DBNull.Value;
                    //}
                    //else
                    //{
                    //    param.Value = Cad;
                    //}
                    //cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsOBSheetRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = obsheet;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsSAMRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = sam;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsOBRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ob;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsCMTRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = cmt;
                    cmd.Parameters.Add(param);

                    //end

                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();

                    if (costingId > 0)
                    {
                        cmdText = "sp_style_clone_costing_tables";

                        cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        cmd.CommandText = cmdText;
                        cmd.Connection = cnx;

                        param = new SqlParameter("@CostingId", SqlDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = costingId;
                        cmd.Parameters.Add(param);




                        param = new SqlParameter("@NewCostingId", SqlDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = outParamCosting.Value;
                        cmd.Parameters.Add(param);



                        param = new SqlParameter("@IsAverageRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;

                        param.Value = avg;

                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@IsCADFileRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;

                        param.Value = Cad;

                        cmd.Parameters.Add(param);


                        param = new SqlParameter("@SampleChecked", SqlDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = selectedItemSample;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@IsSAMRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = sam;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@IsCMTRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = cmt;
                        cmd.Parameters.Add(param);

                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    cnx.Close();

                    return true;
                }
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

            return false;
        }
        public bool CloneStyleNumber_New(string parentStyleNumber, string styleNumber, int clientId, int departmentId, int costingId, string orderIDs, string selectedItemSample, int avg, int Cad, int obsheet, int sam, int ob, int cmt, int userID)
        {
            SqlTransaction transaction = null;

            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "sp_style_clone_style_number_New";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.CommandText = cmdText;
                    cmd.Connection = cnx;

                    SqlParameter outParam = new SqlParameter("@StyleId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter outParamCosting = new SqlParameter("@NewCostingId", SqlDbType.Int);
                    outParamCosting.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParamCosting);

                    SqlParameter param;
                    param = new SqlParameter("@ParentStyleNumber", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = parentStyleNumber;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = styleNumber;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = clientId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = departmentId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CostingId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = costingId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderIDs", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = orderIDs;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SampleChecked", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = selectedItemSample;
                    cmd.Parameters.Add(param);

                    //added by abhishek 23/5/2017

                    //param = new SqlParameter("@avgval", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //if (avg == 0)
                    //{
                    //    param.Value = DBNull.Value;
                    //}
                    //else
                    //{
                    //    param.Value = avg;
                    //}                    
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@Cadval", SqlDbType.Int);
                    //param.Direction = ParameterDirection.Input;
                    //if (Cad == 0)
                    //{
                    //    param.Value = DBNull.Value;
                    //}
                    //else
                    //{
                    //    param.Value = Cad;
                    //}
                    //cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsOBSheetRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = obsheet;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsSAMRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = sam;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsOBRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ob;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@IsCMTRemove", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = cmt;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = userID;
                    cmd.Parameters.Add(param);

                    //end

                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();

                    if (costingId > 0)
                    {
                        cmdText = "sp_style_clone_costing_tables_New";

                        cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        cmd.CommandText = cmdText;
                        cmd.Connection = cnx;

                        param = new SqlParameter("@CostingId", SqlDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = costingId;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@NewCostingId", SqlDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = outParamCosting.Value;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter("@IsAverageRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = avg;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@IsCADFileRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = Cad;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SampleChecked", SqlDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = selectedItemSample;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@IsSAMRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = sam;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@IsCMTRemove", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = cmt;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@UserID", SqlDbType.Int);
                        param.Direction = ParameterDirection.Input;
                        param.Value = userID;
                        cmd.Parameters.Add(param);                       


                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    cnx.Close();

                    return true;
                }
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

            return false;
        }

        public bool CostingEnquiryUpdateStyle(string styleNumber, int StyleId, int type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_costing_enquiry_update_style";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = styleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.VarChar);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.Int);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            return true;
        }

        public int CostingEnquiryUpdateStyleFromStyleNumber(string styleNumber)
        {
            int IsCosted = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_costing_enquiry_update_style_from_stylenumber";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter outParam;
                outParam = new SqlParameter("@sCosted", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;
                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = styleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteScalar();
                IsCosted = Convert.ToInt32(outParam.Value);
                cnx.Close();
            }
            return IsCosted;
        }

        public List<Style> CostingEnquiryGetAllStyles(int Type, int UserID)
        {
            List<Style> styles = new List<Style>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_costing_enquiry_get_all_styles";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Style style = new Style();
                    style.cdept = new ClientDepartment();

                    style.StyleID = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
                    style.StyleNumber = (reader["stylenumber"] != DBNull.Value) ? Convert.ToString(reader["stylenumber"]) : string.Empty; Convert.ToString(reader["stylenumber"]);
                    style.ClientName = (reader["companyname"] != DBNull.Value) ? Convert.ToString(reader["companyname"]) : string.Empty; Convert.ToString(reader["companyname"]);
                    style.Status = (reader["statusmode"] != DBNull.Value) ? Convert.ToString(reader["statusmode"]) : string.Empty;
                    style.StatusModeID = (reader["statusmodeid"] != DBNull.Value) ? Convert.ToInt32(reader["statusmodeid"]) : 0;
                    style.DepartmentName = (reader["DepartmentName"] != DBNull.Value) ? Convert.ToString(reader["DepartmentName"]) : string.Empty;

                    styles.Add(style);
                }
            }
            return styles;
        }

        public List<Style> GetAllStyleVariations(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                List<Style> styles = new List<Style>();
                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_all_styles_by_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Style style = new Style();
                    style.StyleID = Convert.ToInt32(reader["Id"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.BuyingHouseID = Convert.ToInt32(reader["BuyingHouseID"]);
                    style.IsIkandiClient = Convert.ToInt32(reader["IsIkandiClient"]);
                    styles.Add(style);
                }

                return styles;
            }

        }

        public string CloneStyleNumbers(List<ShowroomCosting> existingItems)
        {
            SqlTransaction transaction = null;
            string StyleIDs = string.Empty;

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    string cmdText = "sp_style_clone_style_costing";



                    foreach (ShowroomCosting sc in existingItems)
                    {

                        SqlCommand cmd = new SqlCommand(cmdText, cnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        cmd.Transaction = transaction;

                        SqlParameter outparam;

                        outparam = new SqlParameter("@StyleID", SqlDbType.Int);
                        outparam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outparam);

                        // Add parameters
                        SqlParameter param;

                        param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                        param.Value = sc.StyleNumber.Trim();
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Commission", SqlDbType.Decimal);
                        param.Value = sc.Commission;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Currency", SqlDbType.Int);
                        param.Value = (int)sc.Currency;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Markup", SqlDbType.Decimal);
                        param.Value = sc.Markup;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@NewStyle", SqlDbType.VarChar);
                        if (sc.VersionCode != "")
                        {
                            string stylenumberver = string.Empty;
                            string[] str = sc.StyleNumber.Split(' ');
                            if (str.Length == 3)
                            {
                                stylenumberver = str[0].ToString() + " " + str[1].ToString() + " " + sc.VersionCode.ToString().Trim();
                            }
                            else if (str.Length == 2)
                            {
                                if (str[0].Length == 2)
                                {
                                    stylenumberver = sc.StyleNumber.Trim() + " " + sc.VersionCode.ToString().Trim();
                                }
                                else
                                {
                                    stylenumberver = str[0].ToString() + " " + sc.VersionCode.ToString().Trim();
                                }
                            }
                            else if (str.Length == 1)
                            {
                                stylenumberver = sc.StyleNumber.Trim() + " " + sc.VersionCode.ToString().Trim();
                            }
                            //param.Value = sc.StyleNumber.Trim().Substring(0, 8) + " " + sc.VersionCode;

                            param.Value = stylenumberver;
                        }
                        else
                            param.Value = sc.StyleNumber.Trim();

                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);



                        cmd.ExecuteNonQuery();

                        if (StyleIDs == string.Empty)
                        {
                            if (outparam.Value != DBNull.Value && !string.IsNullOrEmpty(outparam.Value.ToString()))
                            {
                                StyleIDs = outparam.Value.ToString();
                            }
                        }
                        else
                        {
                            if (outparam.Value != DBNull.Value && !string.IsNullOrEmpty(outparam.Value.ToString()))
                            {
                                StyleIDs += "," + outparam.Value.ToString();
                            }
                        }
                    }

                    transaction.Commit();

                    cnx.Close();

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

            return StyleIDs;

        }


        public string CheckStyleVersion(string StyleNumber)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                List<ShowroomCosting> showroomStyles = new List<ShowroomCosting>();
                DataSet ds = new DataSet();
                SqlCommand cmd;
                string cmdText;
                string retVal;

                cmdText = "sp_check_version";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    retVal = "Y";
                else
                    retVal = "N";

                return retVal;
            }
        }


        public List<ShowroomCosting> GetShowroomStyleDetails(string StyleIDs)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                List<ShowroomCosting> showroomStyles = new List<ShowroomCosting>();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_all_showroom_styles_detail";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleIDs", SqlDbType.VarChar);
                param.Value = StyleIDs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShowroomCosting style = new ShowroomCosting();
                    style.StyleID = Convert.ToInt32(reader["StyleID"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.Fabric = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric"]);
                    style.CCGSM = (reader["Fabric11"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric11"]);
                    style.Minimums = (reader["Minimums"] == DBNull.Value) ? 1000 : Convert.ToInt32(reader["Minimums"]);
                    style.PriceQuoted = (reader["PriceQuoted"] == DBNull.Value) ? 0.00 : Convert.ToDouble(reader["PriceQuoted"]);
                    style.Currency = (reader["Currency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt32(reader["Currency"]);
                    style.StyleFrontImageURL = (reader["SampleImageURL1"] == DBNull.Value || string.IsNullOrEmpty(reader["SampleImageURL1"].ToString())) ? ((reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"])) : Convert.ToString(reader["SampleImageURL1"]);

                    showroomStyles.Add(style);
                }

                return showroomStyles;
            }
        }



        public List<ShowroomCosting> GetShowroomStyleDetails_Print(string StyleIDs)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                List<ShowroomCosting> showroomStyles = new List<ShowroomCosting>();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_get_all_showroom_styles_detail_print";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleIDs", SqlDbType.VarChar);
                param.Value = StyleIDs;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShowroomCosting style = new ShowroomCosting();
                    style.StyleID = Convert.ToInt32(reader["StyleID"]);
                    style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                    style.Fabric = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric"]);
                    style.CCGSM = (reader["Fabric11"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric11"]);
                    style.Minimums = (reader["Minimums"] == DBNull.Value) ? 1000 : Convert.ToInt32(reader["Minimums"]);
                    style.PriceQuoted = (reader["PriceQuoted"] == DBNull.Value) ? 0.00 : Convert.ToDouble(reader["PriceQuoted"]);
                    style.Currency = (reader["Currency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt32(reader["Currency"]);
                    style.StyleFrontImageURL = (reader["SampleImageURL1"] == DBNull.Value || string.IsNullOrEmpty(reader["SampleImageURL1"].ToString())) ? ((reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"])) : Convert.ToString(reader["SampleImageURL1"]);

                    showroomStyles.Add(style);
                }

                return showroomStyles;
            }
        }


        public List<ShowroomCosting> SearchShowroomStyles(int PageSize, int PageIndex, out int TotalRowCount, string ClientIDs, string DeptIDs, string GarmentType, int DateType, DateTime StartDate,
            DateTime EndDate, int IsBestSeller, double BIPLPriceFrom, double BIPLPriceTo, string TradeNames, int IsOrderPlaced, string SeasonName, Int64 ShippedQtyRange_From, Int64 ShippedQtyRange_To)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                TotalRowCount = 0;
                List<ShowroomCosting> showroomStyles = new List<ShowroomCosting>();
                try
                {
                    cnx.Open();

                    //SqlDataReader reader;
                    SqlCommand cmd;
                    string cmdText;

                    DataSet ds = new DataSet();
                    cmdText = "sp_virtual_styles_showroom2";
                    cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@ClientIDs", SqlDbType.VarChar);
                    param.Value = ClientIDs;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DeptIDs", SqlDbType.VarChar);
                    param.Value = DeptIDs;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GarmentTypes", SqlDbType.VarChar);
                    param.Value = GarmentType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateType", SqlDbType.Int);
                    param.Value = DateType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                    if ((StartDate == DateTime.MinValue) || (StartDate == Convert.ToDateTime("1753-01-01")) || (StartDate == Convert.ToDateTime("1900-01-01")))
                        param.Value = DBNull.Value;
                    else
                        param.Value = StartDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@EndDate", SqlDbType.DateTime);
                    if ((EndDate == DateTime.MinValue) || (EndDate == Convert.ToDateTime("1753-01-01")) || (EndDate == Convert.ToDateTime("1900-01-01")))

                        param.Value = DBNull.Value;
                    else
                        param.Value = EndDate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sBestSeller", SqlDbType.Int);
                    param.Value = IsBestSeller;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPLPriceFrom", SqlDbType.Float);
                    param.Value = BIPLPriceFrom;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPLPriceTo", SqlDbType.Float);
                    param.Value = BIPLPriceTo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                    param.Value = TradeNames;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sOrderPlaced", SqlDbType.Int);
                    param.Value = IsOrderPlaced;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PageSize", SqlDbType.Int);
                    param.Value = PageSize;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PageIndex", SqlDbType.Int);
                    param.Value = PageIndex;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SeasonName", SqlDbType.VarChar);
                    param.Value = SeasonName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippedQtyRange_From", SqlDbType.BigInt);
                    param.Value = ShippedQtyRange_From;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ShippedQtyRange_To", SqlDbType.BigInt);
                    param.Value = ShippedQtyRange_To;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dt.Rows)
                            {
                                ShowroomCosting style = new ShowroomCosting();
                                style.StyleID = Convert.ToInt32(reader["StyleID"]);
                                style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                                style.Fabric = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric"]);
                                style.Minimums = (reader["Minimums"] == DBNull.Value) ? 1000 : Convert.ToInt32(reader["Minimums"]);
                                style.PriceQuoted = (reader["PriceQuoted"] == DBNull.Value) ? 0.00 : Convert.ToDouble(reader["PriceQuoted"]);
                                style.Currency = (reader["Currency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt32(reader["Currency"]);
                                style.StyleFrontImageURL = (reader["SampleImageURL1"] == DBNull.Value || string.IsNullOrEmpty(reader["SampleImageURL1"].ToString())) ? ((reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"])) : Convert.ToString(reader["SampleImageURL1"]);

                                
                                style.ShippedMaxValue = reader["ShippedMaxValue"] == DBNull.Value ? 1 : Convert.ToInt64(reader["ShippedMaxValue"]); //added by Girish


                                showroomStyles.Add(style);
                            }
                            TotalRowCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Totalcount"]);
                        }

                    }

                    //reader.Close();

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    cnx.Close();
                }

                return showroomStyles;
            }
        }

        public bool DeleteStyleReferenceBlockById(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdtext = "sp_style_reference_block_delete";
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

        public bool UpdateUrl(int StyleID, int Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_styles_update_style_url";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

                return true;
            }


        }


        public List<SamplingStatus> GetSampleDalayedOrToBeDispatchEmail()
        {
            List<SamplingStatus> styles = new List<SamplingStatus>();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd;
                    string cmdText = "sp_send_sample_delayed_or_to_be_dispatch";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    DataSet dsSamplingStatus = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsSamplingStatus);

                    if (dsSamplingStatus.Tables[0].Rows.Count > 0)
                    {

                        DataTable dtBasicDetail = dsSamplingStatus.Tables[0];
                        DataTable dtCurrentUpdates = dsSamplingStatus.Tables[1];

                        if (dtBasicDetail.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dtBasicDetail.Rows)
                            {
                                SamplingStatus style = new SamplingStatus();
                                style.StyleID = Convert.ToInt32(reader["Id"]);
                                style.StyleNumber = Convert.ToString(reader["StyleNumber"]);
                                style.ClientName = style.Buyer = Convert.ToString(reader["Buyer"]);
                                style.SamplingMerchandisingManagerID = (reader["SamplingMerchandisingManagerID"] != System.DBNull.Value) ? Convert.ToInt32(reader["SamplingMerchandisingManagerID"]) : -1;
                                style.FactoryName = (reader["FactoryName"] != DBNull.Value) ? Convert.ToString(reader["FactoryName"]) : string.Empty;
                                style.Fabric = (reader["Fabric"] != DBNull.Value) ? Convert.ToString(reader["Fabric"]) : string.Empty;
                                style.IssuedOn = (reader["IssuedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["IssuedOn"]) : DateTime.Now;
                                style.ReceivedOn = (reader["ReceivedOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ReceivedOn"]) : style.IssuedOn;
                                style.ETA = (reader["ETA"] != System.DBNull.Value) ? Convert.ToDateTime(reader["ETA"]) : DateTime.Now;
                                style.MerchandiserDispatchDate = (reader["MerchandiserDispatchDate"] != System.DBNull.Value) ? Convert.ToDateTime(reader["MerchandiserDispatchDate"]) : style.ETA;
                                style.SentToiKandiOn = (reader["SentToiKandiOn"] != System.DBNull.Value) ? Convert.ToDateTime(reader["SentToiKandiOn"]) : DateTime.MinValue;
                                style.CounterComplete = (reader["CounterComplete"] != System.DBNull.Value) ? Convert.ToInt32(reader["CounterComplete"]) : 0;
                                style.Status = (reader["Status"] != DBNull.Value) ? Convert.ToString(reader["Status"]) : string.Empty;
                                style.StatusModeID = (reader["StatusModeID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StatusModeID"]);
                                style.StatusColor = Constants.GetStatusModeColor(style.StatusModeID);
                                style.SketchURL = (reader["SketchURL"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SketchURL"]);
                                style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);
                                style.DepartmentName = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                                style.DesignerName = (reader["DesignerName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerName"]);

                                string remarks = (reader["FinalDelayedRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["FinalDelayedRemarks"]);
                                string replaceRemarks = remarks;

                                if (remarks.ToString().IndexOf("$$") > -1)
                                {
                                    remarks = remarks.ToString().Substring(remarks.ToString().LastIndexOf("$$") + 2);
                                }
                                else
                                {
                                    remarks = remarks.ToString();
                                }
                                style.SamplingStatusRemarks = remarks;

                                if (replaceRemarks.ToString().IndexOf("$$") > -1)
                                {
                                    replaceRemarks = replaceRemarks.ToString().Replace("$$", "<br/>");
                                }
                                else
                                {
                                    replaceRemarks = replaceRemarks.ToString();
                                }
                                style.SamplingStatusRemarksReplace = replaceRemarks.ToString().Replace("\n", "").Replace("\r", "").Replace("/n/r", "").Replace(@"""", @"&quot;").Replace("'", "&#39;").Replace("&#39;", @"&rsquo;");


                                style.CurrentUpdate = new List<StyleCurrentUpdate>();

                                string strStyleId = "StyleId =" + style.StyleID;
                                DataRow[] DataRowCurrentUpdate;
                                DataRowCurrentUpdate = dtCurrentUpdates.Select(strStyleId);

                                foreach (DataRow dr in DataRowCurrentUpdate)
                                {
                                    StyleCurrentUpdate objStyleCurrentUpdate = new StyleCurrentUpdate();
                                    objStyleCurrentUpdate.Id = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                                    objStyleCurrentUpdate.StyleId = Convert.ToInt32(dr["StyleId"]);
                                    objStyleCurrentUpdate.Type = (StyleCurrentUpdates)Convert.ToInt32(dr["Type"]);
                                    objStyleCurrentUpdate.IsChecked = (dr["IsChecked"] == DBNull.Value) ? false : Convert.ToBoolean(dr["IsChecked"]);
                                    objStyleCurrentUpdate.Date = (dr["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
                                    style.CurrentUpdate.Add(objStyleCurrentUpdate);
                                }

                                styles.Add(style);
                            }
                        }
                    }
                }
                catch
                {

                }
                return styles;


            }
        }


        //public List<ShowroomCosting> SearchShowroomStyles(int PageSize, int PageIndex, out int TotalRowCount, string ClientIDs, string DeptIDs, string GartmentType, int DateType, DateTime StartDate, DateTime EndDate, int IsBestSeller, double BIPLPriceFrom, double BIPLPriceTo, string TradeNames, int IsOrderPlaced)
        //{
        //    throw new NotImplementedException();
        //}



        public void InsertMeterageValueDAL(int intStyleId, string stringMeterage, string stringFabric)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();
                    string cmdText = "sp_insert_fabric_meterage";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    // Add parameters
                    SqlParameter param;
                    param = new SqlParameter("@meterageValue", SqlDbType.VarChar);
                    param.Value = stringMeterage;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Value = intStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@Fabric", SqlDbType.VarChar);
                    param.Value = stringFabric;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    cnx.Close();

                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }

        }





        public void InsertIssueRemarksDAL(int intStyleId, string stringRemarks, int UserId)
        {



            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_styles_insert_Issue_remarks";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = intStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = stringRemarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);



                cmd.ExecuteNonQuery();

                cnx.Close();

            }

        }

        public void InsertFabricRemarksDAL(int intStyleId, string stringRemarks, string stringFileName, int UserId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_styles_insert_fabric_remarks";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = intStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = stringRemarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FileName", SqlDbType.VarChar);
                param.Value = stringFileName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);



                cmd.ExecuteNonQuery();

                cnx.Close();

            }

        }

        public void InsertOwnerRemarksDAL(int intStyleId, string stringRemarks, string stringFileName, string Status, string IsOwnerLoggedIn, int UserId)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = string.Empty;
                if (Status == "Owner")
                    cmdText = "sp_styles_insert_owner_remarks";
                if (Status == "Workflow")
                    cmdText = "sp_styles_insert_workflow_remarks";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = intStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                param.Value = stringRemarks;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FileName", SqlDbType.VarChar);
                param.Value = stringFileName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                if (Status == "Owner")
                {
                    param = new SqlParameter("@sOwnerLoggedIn", SqlDbType.VarChar);
                    param.Value = IsOwnerLoggedIn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }
                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                cmd.ExecuteNonQuery();

                cnx.Close();

            }

        }

        public DataTable GetAllSeasonDAL()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_all_Season";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }

        public DataTable GetExcelReport()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetStyle_Excel_By_Ikandi";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }


        public void DeleteSelectedCheckBox()
        {
            SqlTransaction transaction = null;
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "Delete_CheckBox_InDesign_List_Selection";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.CommandText = cmdText;
                    cmd.Connection = cnx;








                    transaction = cnx.BeginTransaction();
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    cnx.Close();


                }
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
        public DataTable GetAllMerchentDAL(int UserID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_get_SamplingMarchent";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        public int GetGlobalType(int UserID, out int GlobalType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_Get_GlobalType";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataSet dsWeekCount = new DataSet();
                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Out", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@SampleSent", SqlDbType.Int);
                //param.Value = SampleSent;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                //DataSet ds = new DataSet();
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //adapter.Fill(ds);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsWeekCount);
                GlobalType = Convert.ToInt32(param.Value);
                //result = cmd.ExecuteNonQuery();

                cnx.Close();
                return GlobalType;
            }




        }



        public void InsertOwnerSamplingDAL(string OwnerDetail)
        {


            string[] str = OwnerDetail.Split('$');
            for (int i = 0; i < str.Length - 1; i++)
            {
                InsertOwnerSamplingOnebyOneDAL(str[i], Convert.ToInt32(str[str.Length - 1]), i);
            }

        }


        public void InsertOwnerSamplingOnebyOneDAL(string OwnerName, int StyleId, int CheckFirstRow)
        {
            SqlTransaction transaction = null;
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "sp_styles_insert_owner_detail";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.CommandText = cmdText;
                    cmd.Connection = cnx;



                    SqlParameter param;
                    param = new SqlParameter("@ownerName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = OwnerName;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = StyleId;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@CheckFirstRow", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = CheckFirstRow;
                    cmd.Parameters.Add(param);


                    transaction = cnx.BeginTransaction();
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    cnx.Close();


                }
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

        public string GetOwnerSamplingDAL(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_owner_Samplingfile";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                DataTable dt = dsorderDetail.Tables[0];

                string styleNumber = Convert.ToString(dt.Rows[0][0]);
                return styleNumber;

            }

        }
        // Update By Ravi kumar on 11/8/15 For add style from order
        public int CloneStyleNumberByOrder(int ParentStyleID, string parentStyleNumber, string styleNumber, int clientId, int departmentId)
        {
            SqlTransaction transaction = null;
            int StyleId = 0;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "sp_style_clone_style_by_Order";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.CommandText = cmdText;
                    cmd.Connection = cnx;

                    SqlParameter outParam = new SqlParameter("@StyleId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;
                    param = new SqlParameter("@ParentStyleId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ParentStyleID;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ParentStyleNumber", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = parentStyleNumber;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = styleNumber;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = clientId;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = departmentId;
                    cmd.Parameters.Add(param);


                    transaction = cnx.BeginTransaction();

                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    if (outParam.Value != DBNull.Value)
                        StyleId = Convert.ToInt32(outParam.Value);

                    transaction.Commit();
                    cnx.Close();
                }

            }
            catch (SqlException ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                transaction.Rollback();
            }

            return StyleId;
        }

        public string IsRepeatedStyle(int StyleId)
        {
            string result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "usp_IsRepeatedStyle";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                result = cmd.ExecuteScalar().ToString();

                cnx.Close();

            }
            return result;

        }
        //added by abhishek on 15/9/2016
        public DataSet GetAccsessoryDetails(int styleid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_GetAccsessoryDetails";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet dsShippedDetails = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsShippedDetails);

                cnx.Close();
                return dsShippedDetails;
            }
        }
        public int DeleteAddACCDetails(int styleid, string AccesoriesName, string Remarks, int AccesoriesQualityID, string SIZE, double Rate, string FlagIsDelete)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "Usp_DeleteAddAccsessoryDetails_New";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleID", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccName", SqlDbType.VarChar);
                    param.Value = AccesoriesName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = Remarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FlagIsDelete", SqlDbType.VarChar);
                    param.Value = FlagIsDelete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccesoriesQualityID", SqlDbType.Int);
                    param.Value = AccesoriesQualityID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SIZE", SqlDbType.VarChar);
                    param.Value = SIZE;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Float);
                    param.Value = Rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    intReturn = cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return intReturn;
        }
        public string GetMaxStyleCode(string Designercode)
        {
            string StyleCode = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlCommand cmd;
                string cmdText;

                // cmdText = "sp_costing_get_makingprice_SAM";
                cmdText = "usp_GetMaxStyleCode_DesignerCode";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Designercode", SqlDbType.VarChar);
                param.Value = Designercode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@ExpectedQty", SqlDbType.Int);
                //param.Value = ExpectedQty;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    StyleCode = dt.Rows[0]["StyleCode"].ToString();
                }
                return StyleCode;


            }
        }
        public DataTable GetBuyerDetail(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetStyleBuyerDetails_New";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SyleiD", SqlDbType.VarChar);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);
                return (dsorderDetail.Tables[0]);

            }

        }
        public bool UpdateStylesFabricDetails(int ID, string dates, int status, string flag)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_GetStyleBuyerDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@RowID", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = dates;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flied", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = status;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }
        public bool UpdateBuyerStyleNumber(string SelectValue, string Styleid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {

                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "Update_Buyer_StyleNumber";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;



                    param = new SqlParameter("@BuyerStyleNumber", SqlDbType.VarChar);
                    param.Value = SelectValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = Convert.ToInt32(Styleid);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();
                }


            }
            return true;
        }
        public bool UpdateSelectExports(string SelectValue, string Styleid, string AllSelect)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {

                    cnx.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string cmdText = "Update_export_StyleNumber";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;



                    param = new SqlParameter("@BuyerStyleNumber", SqlDbType.VarChar);
                    param.Value = SelectValue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = Convert.ToInt32(Styleid);
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AllSelect", SqlDbType.VarChar);
                    param.Value = AllSelect;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    cmd.ExecuteNonQuery();
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();
                }


            }
            return true;
        }
        public string UpdateStylesFabricStatus(int ID, string Etadate)
        {
            string strstaus = string.Empty;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtstatus = new DataTable();
                cnx.Open();



                string cmdText = "Usp_GetStyleBuyerDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = Etadate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@RowID", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtstatus);
                strstaus = dtstatus.Rows[0]["STATUS"].ToString();
                cnx.Close();

            }
            return strstaus;
        }
        public string UpdateStylesFabricStatusActual(int ID, string Etadate, string UserId)
        {
            string strstaus = string.Empty;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dtstatus = new DataTable();
                cnx.Open();



                string cmdText = "Usp_GetStyleBuyerDetails";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Type", SqlDbType.Int);
                param.Value = 4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Date", SqlDbType.VarChar);
                param.Value = Etadate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@RowID", SqlDbType.Int);
                param.Value = ID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@userId", SqlDbType.VarChar);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtstatus);
                strstaus = dtstatus.Rows[0]["STATUS"].ToString();
                cnx.Close();

            }
            return strstaus;
        }
        //end by abhishek 
        //Add BY Prabhaker 30-March-2018
        public DataSet GetProfitOn_Mode_Mo(int OrderDetailId, int Mode, string Onhold)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "Usp_Get_Profit_OnMode_MO";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;


                param = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Mode", SqlDbType.Int);
                param.Value = Mode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Onhold", SqlDbType.VarChar);
                param.Value = Onhold;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);


                cnx.Close();
                return ds;
            }

        }


        public int UpdateProfitOn_Mode_Mo(int OrderDetailId, bool FinalisedPenalty, int SharePercent, int Mode, int Orderdiscount, string UserName)
        {
            int Result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_Update_Profit_OnMode_MO";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                // Add parameters
                SqlParameter param;


                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FinalisedPenalty", SqlDbType.Bit);
                param.Value = FinalisedPenalty;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@SharePercent", SqlDbType.Int);
                param.Value = SharePercent;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Mode", SqlDbType.Int);
                param.Value = Mode;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@Orderdiscount", SqlDbType.Int);
                param.Value = Orderdiscount;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserName", SqlDbType.VarChar);
                param.Value = UserName;
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }

        public int UpdateCuttingSheetSelection(int OrderDetailId, string UserSession)
        {
            int Result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_UpdateCuttingSheetprint";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDeatilID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SessionID", SqlDbType.VarChar);
                param.Value = UserSession;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }
        public DataTable BindMoMode()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_get_Mo_Mode";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);


                cnx.Close();
                return ds.Tables[0];
            }
        }
        public List<StyleFabric> GetStyleFabricsByStyleId_New(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_style_fabrics_get_style_fabrics_by_style_id_New";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Id = Convert.ToInt32(reader["Id"]);
                    StyleFab.FabricName = Convert.ToString(reader["FabricName"]);
                    int PrintID = reader.GetOrdinal("PrintID");
                    int PrintNumber = reader.GetOrdinal("PrintNumber");
                    StyleFab.PrintNumber = string.Empty;
                    if (reader.IsDBNull(PrintID) == false)
                    {
                        StyleFab.PrintID = Convert.ToInt32(reader["PrintID"]);
                    }
                    if (reader.IsDBNull(PrintNumber) == false)
                    {
                        StyleFab.PrintNumber = (reader["PrintNumber"]).ToString();
                    }
                    StyleFab.SpecialFabricDetails = Convert.ToString(reader["SpecialFabricDetails"]);
                    StyleFab.Remarks = Convert.ToString(reader["Remarks"]);
                    StyleFab.FabricType = (FabricType)Convert.ToInt32(reader["FabricType"]);
                    StyleFab.CCGSM = Convert.ToString(reader["Fabric11"]);
                    StyleFab.IsPrintMultiple = Convert.ToString(reader["IsPrintMultiple"]);
                    StyleFab.FabricDesc = Convert.ToString(reader["FabricDesc"]);
                    StyleFab.cost = Convert.ToString(reader["cost"]);
                    StyleFab.FabricQualityId = Convert.ToInt32(reader["fabric_qualityID"]);
                    StyleFab.GSM = Convert.ToString(reader["GSM"]);
                    StyleFab.DyedRate = Convert.ToDouble(reader["DyedRate"]);
                    StyleFab.PrintRate = Convert.ToDouble(reader["PrintRate"]);
                    StyleFab.DigitalPrintRate = Convert.ToDouble(reader["DgtlRate"]);
                    StyleFab.CountConstruct = Convert.ToString(reader["CountConstruct"]);
                    StyleFab.CostWidth = Convert.ToDouble(reader["CostWidth"]);
                    StyleFab.FabTypeDetails = Convert.ToString(reader["fabtypedetail"]);

                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }
        public List<StyleFabric> Get_RegisterAcc(string RegisterAccName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Register_Accesories";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@RegisterAccName", SqlDbType.VarChar);
                param.Value = RegisterAccName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Acc = Convert.ToString(reader["Message"]);
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }
        public List<StyleFabric> Get_RegisterProcess_Name(string RegisterProcessName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Register_Process";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@RegisterProcessName", SqlDbType.VarChar);
                param.Value = RegisterProcessName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Acc = Convert.ToString(reader["Message"]);
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }
        public List<StyleFabric> Get_RegisterFabric(string RegisterFabricName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Register_Fabric";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@RegisterFabricName", SqlDbType.VarChar);
                param.Value = RegisterFabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Acc = Convert.ToString(reader["Message"]);
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }


        public List<StyleFabric> Get_RegisterFabric_Design(string RegisterFabricName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Register_Fabric_design";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@RegisterFabricName", SqlDbType.VarChar);
                param.Value = RegisterFabricName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Acc = Convert.ToString(reader["Message"]);
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }

        public List<StyleFabric> Get_Register_Print(string RegisterPrint)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Register_Print";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@RegisterPrint", SqlDbType.VarChar);
                param.Value = RegisterPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Acc = Convert.ToString(reader["Message"]);
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }
        //End Of Code
        //add code by bharat on 6-2-20
        public string Get_Register_MarketingTag(string RegisterPrint)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsorderDetail = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_Registered_Tags";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@TagsName", SqlDbType.VarChar);
                param.Value = RegisterPrint;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsorderDetail);


                string ragisTag = dsorderDetail.Tables[0].Rows[0]["Result"].ToString();
                return ragisTag;


            }

        }
        //end
        public List<Client> BindDeptListAgainstParentDeptWithFlag(int UserId, int ClientId, int FitMerchantID, int ParentDeptID, string Flag)
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetDepartmentAgainst_FitMerchent";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FitMerchantID", SqlDbType.Int);
                param.Value = FitMerchantID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentDeptID", SqlDbType.Int);
                param.Value = ParentDeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(reader["DeptID"]);
                    client.CompanyName = Convert.ToString(reader["DeptName"]);
                    clients.Add(client);


                }
            }
            return clients;

        }
        public DataTable Getmodedetail(int orderdetailid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_GetFabDetail";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDeatilID", SqlDbType.Int);
                param.Value = orderdetailid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);


                cnx.Close();
                return ds.Tables[0];
            }
        }
        public int DeleteSessionID(string UserSession)
        {
            int Result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_DeleteSession";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;

                param = new SqlParameter("@SessionID", SqlDbType.VarChar);
                param.Value = UserSession;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }
        public int UpdateCuttingSheet_CheckBox(int OrderDetailId, int userid, bool Checkbox)
        {
            int Result = -1;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_UpdateCuttingSheet_CheckBox";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@OrderDeatilID", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.Int);
                param.Value = userid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CheckBox", SqlDbType.Bit);
                param.Value = Checkbox;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }
        public List<StyleFabric> Get_Final_Rate_From_PO(string fabricname, string fabtype, string print)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_Final_Rate_From_PO";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@TradeName", SqlDbType.VarChar);
                param.Value = fabricname;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Print_Type", SqlDbType.VarChar);
                param.Value = fabtype;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                if (fabtype == "1" || fabtype == "2")
                {
                    string[] Print = print.Split(new[] { " --- " }, StringSplitOptions.None);
                    if (Print.Length > 1)
                    {
                        param.Value = Print[1].Trim();

                    }
                    else
                    {
                        param.Value = print;
                    }
                }
                else
                {
                    param.Value = print;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@SupplierFabric", SqlDbType.VarChar);
                if (fabtype == "1" || fabtype == "2")
                {
                    param.Value = print.Replace(" --- ", "-");
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


                reader = cmd.ExecuteReader();

                Style style = new Style();
                style.Fabrics = new List<StyleFabric>();

                while (reader.Read())
                {
                    StyleFabric StyleFab = new StyleFabric();
                    StyleFab.Acc = Convert.ToString(reader["Message"]);
                    style.Fabrics.Add(StyleFab);

                }

                return style.Fabrics;
            }

        }
        // Added by Yadvendra on 06/01/2020
        public DataSet GetFileDetailsByStyleId(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_UploadModelShoot";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "Get";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);


                cnx.Close();
                return ds;
            }
        }

        public int SaveFileDetailByStyleId(int StyleId, string FilePath, int UserId, int SeqNumber)
        {
            int Result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_UploadModelShoot";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "Save";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FilePath", SqlDbType.VarChar);
                param.Value = FilePath;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SeqID", SqlDbType.Int);
                param.Value = SeqNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }

        public int SaveMarketingDescription(int StyleId, string Title, string GarType, Int32 MarKetingCollection, string MarKetingMOQ, decimal MarketPrice, string ShortDesc, string LongDesc, int UserId)
        {
            int Result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_UploadModelShoot";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "SaveMarketingDesc";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Title", SqlDbType.VarChar);
                param.Value = Title;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GarmentType", SqlDbType.VarChar);
                param.Value = GarType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //if (MarKetingTags > 0)
                //{
                //    param = new SqlParameter("@MarKetingTags", SqlDbType.Int);
                //    param.Value = MarKetingTags;
                //    param.Direction = ParameterDirection.Input;
                //    cmd.Parameters.Add(param);
                //}

                //if (MarKetingCompositon > 0)
                //{
                //    param = new SqlParameter("@MarKetingCompositon", SqlDbType.Int);
                //    param.Value = MarKetingCompositon;
                //    param.Direction = ParameterDirection.Input;
                //    cmd.Parameters.Add(param);
                //}

                if (MarKetingCollection > 0)
                {
                    param = new SqlParameter("@MarKetingCollection", SqlDbType.Int);
                    param.Value = MarKetingCollection;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }

                param = new SqlParameter("@MarKetingMOQ", SqlDbType.VarChar);
                param.Value = MarKetingMOQ;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Marketingprice", SqlDbType.Decimal);
                param.Value = MarketPrice;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ShortDesc", SqlDbType.VarChar);
                param.Value = ShortDesc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LongDesc", SqlDbType.VarChar);
                param.Value = LongDesc;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.Int);
                param.Value = UserId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }

        // added cod by bhrata on 6-2-20
        public int SaveTagNameByStyleId(int StyleId, string hdnTag)
        {
            int Result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_UploadModelShoot";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "SaveTagsforstyle";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MarKetingTags", SqlDbType.VarChar);
                param.Value = hdnTag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                Result = cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }

        public DataTable GetTagsByStyleId(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dt = new DataTable();
                string cmdText = "Usp_UploadModelShoot";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "GetTagsforstyle";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);


                cnx.Close();
                return dt;
            }
        }

        public int DeleteFilesByStyleId(int StyleId)
        {
            int Result;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "Usp_UploadModelShoot";


                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = "DeleteByStyleId";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                Result = cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return Result;
        }
        // End Added by Yadvendra on 06/01/2020

        //  Added by Bharat on 31/01/2020


        public DataTable BindGarmentTypeDropDown()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_Get_GarmentType_For_Marketing";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);



                adapter.Fill(dt);

                return dt;
            }
        }

        public DataSet BindMarketingTypeDropDown()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                // DataTable dt = new DataTable();

                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_MarketingDropDown";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                return ds;
            }
        }
    }
}
