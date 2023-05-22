using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using iKandi.Common.Entities;
namespace iKandi.DAL
{
    public class OrderProcessFlow : BaseDataProvider
    {

        #region Ctor(s)

        public OrderProcessFlow(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion


        public List<Style> GetQAReusestyles(int styleid, int whichtab = 1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_Get_QAReusestyle";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@styleid", SqlDbType.VarChar);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@whichtab", SqlDbType.VarChar);
                param.Value = whichtab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();
                List<Style> ReusestyleCollection = new List<Style>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Style styleinfo = new Style();
                        styleinfo.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        styleinfo.StyleID = Convert.ToInt32(reader["ID"]);
                        ReusestyleCollection.Add(styleinfo);

                    }
                }

                return ReusestyleCollection;
            }
        }

        // create function for getting style info by sushil on date 27/2/2015
        public List<OrderDetail> Getstyleinfo(int styleno)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_getStyleBasicInfo";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@styleno", SqlDbType.Int);
                param.Value = styleno;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();
                List<OrderDetail> orderDetailCollection = new List<OrderDetail>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.CreatedOn = (reader["OrderDate"] != DBNull.Value) ? Convert.ToDateTime(reader["OrderDate"]) : DateTime.MinValue;
                        orderDetail.BIH = (reader["BIHFabric1"] != DBNull.Value) ? Convert.ToDateTime(reader["BIHFabric1"]) : DateTime.MinValue;
                        orderDetail.DC = (reader["DC"] != DBNull.Value) ? Convert.ToDateTime(reader["DC"]) : DateTime.MinValue;
                        orderDetail.ExFactory = (reader["ExFactory"] != DBNull.Value) ? Convert.ToDateTime(reader["ExFactory"]) : DateTime.MinValue;
                        orderDetail.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);
                        orderDetail.LineItemNumber = (reader["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineItemNumber"]);
                        orderDetail.ContractNumber = (reader["LineContract"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["LineContract"]);
                        orderDetail.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                        orderDetail.ContractQty = (reader["DesQty"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesQty"]);
                        orderDetail.Fabric1 = (reader["fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["fabric1"]);
                        orderDetail.Fabric2 = (reader["fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["fabric2"]);
                        orderDetail.Fabric3 = (reader["fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["fabric3"]);
                        orderDetail.Fabric4 = (reader["fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["fabric4"]);
                        orderDetail.ModeName = (reader["Mode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Mode"]);
                        orderDetail.CostAvg = (reader["price"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["price"]);
                        orderDetail.Status = (reader["Status"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Status"]);
                        orderDetail.IsShiped = (reader["IsShiped"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsShiped"]);
                        orderDetail.StyleNumber = (reader["stylename"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["stylename"]);
                        orderDetail.StyleCode = (reader["StyleCode"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleCode"]);
                        orderDetail.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt16(reader["ClientID"]);
                        orderDetail.DepartmentID = (reader["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DepartmentID"]);
                        orderDetail.RiskRemark = (reader["RiskRemark"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["RiskRemark"]);
                        orderDetail.IsApproveRisk = (reader["IsMerchandisingManagerApprovedOn"] == DBNull.Value) ? false : Convert.ToBoolean(reader["IsMerchandisingManagerApprovedOn"]);
                        orderDetail.OrderID = Convert.ToInt32(reader["Id"]);
                        orderDetail.ReUseRiskRemark = (reader["ReUseremark"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReUseremark"]);
                        orderDetail.ReUsestylenumber = (reader["ReUsestylename"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ReUsestylename"]);
                        orderDetail.ReusestyleID = (reader["ReusestyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ReusestyleID"]);
                        orderDetail.File = (reader["StyleImage"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleImage"]);
                        orderDetailCollection.Add(orderDetail);

                    }
                }

                return orderDetailCollection;
            }
        }
        public int insertRiskAnalysisRemark(int sid, int Istrue, string sRemark, int ReusestyleID)
        {

            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    string cmdText = "usp_insertRiskAnalysisRemark";
                    cnx.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@IsMerchandisingManagerApprovedOn", SqlDbType.Bit);
                    param.Value = Istrue;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = sid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@remark", SqlDbType.VarChar);
                    param.Value = sRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                    param.Value = ReusestyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return 1;
        }

        public int insertHoPPM(int sid, string scode, string HoppmAttendName, string PPMRemark, int factoryppm, int Hoppm, string jhoppmfile, int jReusestyleID)
        {
            try
            {

                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    string cmdText = "usp_insertHOPPMRemark";
                    cnx.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = scode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = sid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Isfactoryppm", SqlDbType.Int);
                    param.Value = factoryppm;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsHOPPM", SqlDbType.Int);
                    param.Value = Hoppm;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HoPPMRemark", SqlDbType.VarChar);
                    param.Value = PPMRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@HoppmAttendName", SqlDbType.VarChar);
                    param.Value = HoppmAttendName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@hoppmfile", SqlDbType.VarChar);
                    param.Value = jhoppmfile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@Reusestyleid", SqlDbType.Int);
                    param.Value = jReusestyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return 1;
        }

        //sushil kumar insert update order process flow for OB SAM
        public string InsertOBSAMOrderProcess(string root_breakdown, int jstyleId, string jstylenumber, int jSAMval, int jOBval, string jOBfile, float jAvailminval, int jReusestyleID)
        {
            string result = "";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string cmdText = "usp_Insertupdate_OrderOBSAM";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter paramIn;
                    paramIn = new SqlParameter("@root_breakdown", SqlDbType.Xml);
                    paramIn.Value = root_breakdown;
                    cmd.Parameters.Add(paramIn);
                    paramIn = new SqlParameter("@jstyleId", SqlDbType.Int);
                    paramIn.Value = jstyleId;
                    cmd.Parameters.Add(paramIn);
                    paramIn = new SqlParameter("@jSAMval", SqlDbType.Int);
                    paramIn.Value = jSAMval;
                    cmd.Parameters.Add(paramIn);
                    paramIn = new SqlParameter("@jOBval", SqlDbType.Int);
                    paramIn.Value = jOBval;
                    cmd.Parameters.Add(paramIn);
                    paramIn = new SqlParameter("@jOBfile", SqlDbType.NVarChar);
                    paramIn.Value = jOBfile;
                    cmd.Parameters.Add(paramIn);
                    paramIn = new SqlParameter("@jAvailminval", SqlDbType.Float);
                    paramIn.Value = jAvailminval;
                    cmd.Parameters.Add(paramIn);
                    paramIn = new SqlParameter("@jReusestyleID", SqlDbType.Int);
                    paramIn.Value = jReusestyleID;
                    cmd.Parameters.Add(paramIn);
                    cmd.ExecuteNonQuery();
                    result = "Record SAVE/Update Successfully .";
                    cnx.Close();

                }
                catch (Exception ex)
                {
                    result = "Error occurred please check & Retry .";
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    //throw ex;
                }
            }

            return result;
        }

        // Add By Ravi kumar on 29/4/2015

        public DataSet GetStyleNumberClientDept(int StyleID, int ReUseStyleId, int ClientId, int DeptID, int CreateNew, int NewRef, int ReUse, int Tab)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsStyle = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetStyleNumberClientDept";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUseStyleid", SqlDbType.Int);
                param.Value = ReUseStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateNew", SqlDbType.Int);
                param.Value = CreateNew;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NewRef", SqlDbType.Int);
                param.Value = NewRef;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUse", SqlDbType.Int);
                param.Value = ReUse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Tab", SqlDbType.Int);
                param.Value = Tab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsStyle);

                return dsStyle;
            }
        }

        public List<OrderFlow> CheckOrderProcess(int styleid, int ClientId, int DeptID, int whichtab = 1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_CheckOrderProcess";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@styleid", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@whichtab", SqlDbType.Int);
                param.Value = whichtab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();
                List<OrderFlow> OrderFlowcollection = new List<OrderFlow>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderFlow objOrderflow = new OrderFlow();
                        objOrderflow.StyleCode = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        objOrderflow.Styleid = Convert.ToInt32(reader["Styleid"]);
                        OrderFlowcollection.Add(objOrderflow);
                    }
                }

                return OrderFlowcollection;
            }
        }

        public DataSet CheckOrderProcessStyle(int styleid, int ClientId, int DeptID, int whichtab = 1)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet ds = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_CheckOrderProcess";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@styleid", SqlDbType.Int);
                param.Value = styleid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@whichtab", SqlDbType.Int);
                param.Value = whichtab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                return ds;

            }
        }

        // Start Risk Analysis 

        public DataSet CheckRiskAnalysis(string StyleCode, int StyleID, int ClientId, int DeptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsRiskAnalysis = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_CheckRiskAnalysis";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }

        public DataSet GetRiskAnalysis(string StyleCode, int StyleID, int ClientId, int DeptID, int OrderId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsRiskAnalysis = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetRiskAnalysis";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Value = OrderId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateNew", SqlDbType.Int);
                param.Value = CreateNew;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NewRef", SqlDbType.Int);
                param.Value = NewRef;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUse", SqlDbType.Int);
                param.Value = ReUse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                param.Value = ReUseStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);



                return dsRiskAnalysis;
            }
        }

        public int SaveRiskAnalysis(string StyleCode, int StyleID, int ClientId, int DeptID, int OrderID, int CreateNew, int ReUse, int ReUseStyleId, bool IsAccountMgr, bool IsQAPreProd, bool IsQAProd, bool IsMerchandisingMgr, bool isva, string QaRepresentativeIds, string QaRepresentativeNames, string FactoryRepresentativeIds, string FactoryRepresentativeNames, string MerchandiserId, string MerchandiserName, string IERepresentativesId, string IERepresentativesName, string SamplingRepresentativesId, string SamplingRepresentativesName,

            string FabricRepresentativesId, string FabricRepresentativesName, string AccessoryRepresentativesId, string AccessoryRepresentativesName, string OutRepresentativesId, string OutRepresentativesName)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    string cmdText = "usp_SaveRiskAnalysis";
                    cnx.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    param.Value = DeptID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsAccountMgr", SqlDbType.Bit);
                    param.Value = IsAccountMgr;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsQAPreProd", SqlDbType.Bit);
                    param.Value = IsQAPreProd;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsQAProd", SqlDbType.Bit);
                    param.Value = IsQAProd;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsMerchandisingMgr", SqlDbType.Bit);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Isva", SqlDbType.Bit);
                    param.Value = isva;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    //
                    //abhishek
                    param = new SqlParameter("@QaRepresentativeIds", SqlDbType.VarChar);
                    param.Value = QaRepresentativeIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QaRepresentativeNames", SqlDbType.VarChar);
                    param.Value = QaRepresentativeNames;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryRepresentativeIds", SqlDbType.VarChar);
                    param.Value = FactoryRepresentativeIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryRepresentativeNames", SqlDbType.VarChar);
                    param.Value = FactoryRepresentativeNames;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    
                    param = new SqlParameter("@MerchandiserRepresentativeId", SqlDbType.VarChar);
                    param.Value = MerchandiserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MerchandiserRepresentativeName", SqlDbType.VarChar);
                    param.Value = MerchandiserName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IERepresentativeId", SqlDbType.VarChar);
                    param.Value = IERepresentativesId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IERepresentativeName", SqlDbType.VarChar);
                    param.Value = IERepresentativesName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SamplingRepresentativeId", SqlDbType.VarChar);
                    param.Value = SamplingRepresentativesId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SamplingRepresentativeName", SqlDbType.VarChar);
                    param.Value = SamplingRepresentativesName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRepresentativeId", SqlDbType.VarChar);
                    param.Value = FabricRepresentativesId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRepresentativeName", SqlDbType.VarChar);
                    param.Value = FabricRepresentativesName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryRepresentativeId", SqlDbType.VarChar);
                    param.Value = AccessoryRepresentativesId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AccessoryRepresentativeName", SqlDbType.VarChar);
                    param.Value = AccessoryRepresentativesName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OutRepresentativeId", SqlDbType.VarChar);
                    param.Value = OutRepresentativesId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OutRepresentativeName", SqlDbType.VarChar);
                    param.Value = OutRepresentativesName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //end==========
                    cmd.ExecuteNonQuery();
                    //IsResult= cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //throw ex;
                return 0;
            }
            return 1;
        }

        // End Risk Analysis 

        // Start HOPPM 

        public DataSet CheckHOPPM(string StyleCode, int StyleID, int ClientId, int DeptID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsRiskAnalysis = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_CheckHOPPM";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }

        public DataSet GetHOPPM(string StyleCode, int StyleID, int ClientId, int DeptID, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsHOPPM = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetHOPPM";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateNew", SqlDbType.Int);
                param.Value = CreateNew;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUse", SqlDbType.Int);
                param.Value = ReUse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NewRef", SqlDbType.Int);
                param.Value = NewRef;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                param.Value = ReUseStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsHOPPM);



                return dsHOPPM;
            }
        }

        public int SaveHOPPM(string StyleCode, int StyleID, int ClientId, int DeptID, int CreateNew, int ReUse, int ReUseStyleId, string QaRepresentativeIds, string QaRepresentativeNames, string FactoryRepresentativeIds, string FactoryRepresentativeNames, string MerchandiserId, string MerchandiserName, bool IsMerchandisingManagerApprovedOn, bool IsQAProdApprovedOn, bool IsFactoryPPMComplete, bool IsHOPPMComplete, string FileUploadUrl1, string FileUploadUrl2, int UserId, bool Seam_Slippage_OK)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    string cmdText = "usp_SaveHOPPM";
                    cnx.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentID", SqlDbType.Int);
                    param.Value = DeptID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReusestyleID", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@QaRepresentativeIds", SqlDbType.VarChar);
                    param.Value = QaRepresentativeIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QaRepresentativeNames", SqlDbType.VarChar);
                    param.Value = QaRepresentativeNames;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryRepresentativeIds", SqlDbType.VarChar);
                    param.Value = FactoryRepresentativeIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FactoryRepresentativeNames", SqlDbType.VarChar);
                    param.Value = FactoryRepresentativeNames;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //Added By Ashish on 23/7/2015
                    param = new SqlParameter("@MerchandiserRepresentativeId", SqlDbType.VarChar);
                    param.Value = MerchandiserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MerchandiserRepresentativeName", SqlDbType.VarChar);
                    param.Value = MerchandiserName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //END

                    param = new SqlParameter("@IsMerchandisingManagerApprovedOn", SqlDbType.Bit);
                    param.Value = IsMerchandisingManagerApprovedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@IsQAPreProdApprovedOn", SqlDbType.Bit);
                    //param.Value = IsQAPreProdApprovedOn;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsQAProdApprovedOn", SqlDbType.Bit);
                    param.Value = IsQAProdApprovedOn;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsFactoryPPMComplete", SqlDbType.Bit);
                    param.Value = IsFactoryPPMComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsHOPPMComplete", SqlDbType.Bit);
                    param.Value = IsHOPPMComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    if (String.IsNullOrEmpty(FileUploadUrl1))
                    {
                        param = new SqlParameter("@FileUploadUrl1", SqlDbType.VarChar);
                        param.Value = "";
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    else
                    {
                        param = new SqlParameter("@FileUploadUrl1", SqlDbType.VarChar);
                        param.Value = FileUploadUrl1;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    if (String.IsNullOrEmpty(FileUploadUrl2))
                    {
                        param = new SqlParameter("@FileUploadUrl2", SqlDbType.VarChar);
                        param.Value = "";
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                    else
                    {
                        param = new SqlParameter("@FileUploadUrl2", SqlDbType.VarChar);
                        param.Value = FileUploadUrl2;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }

                    // Add by Ravi kumar on 28/1/2016 for HOPPM task

                    param = new SqlParameter("@AssignTo", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    // added by abhishek

                    param = new SqlParameter("@Seam_Slippage_OK", SqlDbType.Bit);
                    param.Value = Seam_Slippage_OK;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                //throw ex;
                return 0;
            }
            return 1;
        }


        //Added By Ashish on 19/8/2015

        public int UpdateHoppmFile(int StyleID, string FileUploadUrl1, string FileUploadUrl2)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {

                    string cmdText = "Usp_UpdateHoppmFileupload";
                    cnx.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = StyleID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FileUpload1", SqlDbType.VarChar);
                    param.Value = FileUploadUrl1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FileUpload2", SqlDbType.VarChar);
                    param.Value = FileUploadUrl2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return 0;
            }
            return 1;
        }

        //END

        // End HOPPM

        //Added By Ashish on 21/5/2015
        //For Risk Remarks
        public DataSet GetRiskFabricRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dt = new DataSet();
                List<MOOrderDetails> orderDetailCollection = new List<MOOrderDetails>();
                try
                {
                    string cmdText = "";
                    SqlCommand cmd;
                    cmdText = "Usp_GetRiskAnalysisRemark";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);




                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return dt;
            }
        }


        public DataSet GetRiskRemarkForLimitation(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dt = new DataSet();
                List<MOOrderDetails> orderDetailCollection = new List<MOOrderDetails>();
                try
                {
                    string cmdText = "";
                    SqlCommand cmd;
                    cmdText = "Usp_getRisklimitationRemarks";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);




                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return dt;
            }
        }
        public bool CheckIsRiskDone(int OrderId)
        {
            bool bReturn = false;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "";
                    SqlCommand cmd;
                    cmdText = "USP_CheckIsRiskDone";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderId", SqlDbType.Int);
                    param.Value = OrderId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    bReturn = Convert.ToBoolean(cmd.ExecuteScalar());
                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return bReturn;
            }
        }

        public int InsertUpdateRiskRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_InsertUpdateRiskAnalysisRemarks";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRemark", SqlDbType.VarChar);
                    param.Value = FabricRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RiskId", SqlDbType.VarChar);
                    param.Value = RiskFabricId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleSequence", SqlDbType.VarChar);
                    param.Value = StyleSequence;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
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

        public int InsertUpdateValueAddtion(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId, int fromst, int tost, int valid, bool isuse, bool isuseva, int orderid)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_InsertUpdateVARiskAnaylis";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRemark", SqlDbType.VarChar);
                    param.Value = FabricRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RiskId", SqlDbType.VarChar);
                    param.Value = RiskFabricId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleSequence", SqlDbType.VarChar);
                    param.Value = StyleSequence;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FromSttus", SqlDbType.Int);
                    param.Value = fromst;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    //param = new SqlParameter("@TOSttus", SqlDbType.Int);
                    //param.Value = UserId;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);


                    param = new SqlParameter("@TOSttus", SqlDbType.Int);
                    param.Value = tost;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@ValueAddtionid", SqlDbType.Int);
                    param.Value = valid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@isuse", SqlDbType.Bit);
                    param.Value = isuse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ISvArEQURIED", SqlDbType.Bit);
                    param.Value = isuseva;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@orderid", SqlDbType.Int);
                    param.Value = orderid;
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


        public int InsertForReuseRiskData(int styleid, int ReUse, string RemarksType, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "sp_ReUse_RiskAnalysisRemarks";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
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


        //For Fits Remarks
        public DataSet GetFitsRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dt = new DataSet();
                List<MOOrderDetails> orderDetailCollection = new List<MOOrderDetails>();
                try
                {
                    string cmdText = "";
                    SqlCommand cmd;
                    cmdText = "Usp_GetBIHRemarkForFits";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);





                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return dt;
            }
        }
        public int InsertUpdateFitsRemark(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_InsertUpdateFitsRemark";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRemark", SqlDbType.VarChar);
                    param.Value = FabricRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BHId", SqlDbType.VarChar);
                    param.Value = RiskFabricId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleSequence", SqlDbType.VarChar);
                    param.Value = StyleSequence;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
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
        public int InsertForReuseFitsRemark(int styleid, int ReUse, string RemarksType, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_InsertForReuseFitsBHRemark";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
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


        //For HOPPM Remark
        public DataSet GetHOPPMRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dt = new DataSet();
                List<MOOrderDetails> orderDetailCollection = new List<MOOrderDetails>();
                try
                {
                    string cmdText = "";
                    SqlCommand cmd;
                    cmdText = "Usp_GetHOPPMRemarks";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return dt;
            }
        }
        public int InsertUpdateHOPPMRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, string RemarksType, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_InsertUpdateHOPPMRemarksDetails";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FabricRemark", SqlDbType.VarChar);
                    param.Value = FabricRemark;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RiskFabricId", SqlDbType.VarChar);
                    param.Value = RiskFabricId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleSequence", SqlDbType.VarChar);
                    param.Value = StyleSequence;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
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
        public int ReuseHoppmRemarks(int styleid, int ReUse, string RemarksType, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_ReuseHoppmRemarks";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.VarChar);
                    param.Value = UserId;
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

        public int DeleteRiskRemarkById(int RiskId, string RemarksType)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_DeleteRiskRemarkById";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@RiskId", SqlDbType.Int);
                    param.Value = RiskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
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

        public int DeleteHoppmRemarkById(int RiskId, string RemarksType)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_DeleteHoppmRemarkById";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@RiskId", SqlDbType.Int);
                    param.Value = RiskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
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

        public int DeleteFitingRemarkById(int RiskId, string RemarksType)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_DeleteFitingRemarkById";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@RiskId", SqlDbType.Int);
                    param.Value = RiskId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
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

        //Added By abhishek
        public DataSet GetRiskAllRemark(string StyleCode, int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsRiskAnalysis = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetRiskAllRemark";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);


                return dsRiskAnalysis;
            }
        }

        public DataSet GetHoppm_AllRemark(string StyleCode, int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsRiskAnalysis = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetHoppmAllRemark";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);


                return dsRiskAnalysis;
            }
        }
        public DataSet GetFitingRemark(string StyleCode, int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsRiskAnalysis = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetFittingllRemark";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                param.Value = StyleCode;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);


                return dsRiskAnalysis;
            }

        }

        public DataTable GetOBSheet_CMT(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dtOBCMT = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_OBSheet_CMT";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.VarChar);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOBCMT);


                return dtOBCMT;
            }

        }

        public int GetStcApproved(int styleid)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "usp_GetStcApproved";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            intReturn = (reader["StcApproved"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["StcApproved"]);

                        }
                    }
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
            }
            return intReturn;
        }
        public DataTable GetStiched_OBSAM(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dtOBSAM = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetStiched_OBSAM";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.VarChar);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOBSAM);


                return dtOBSAM;
            }

        }

        public InlinePPM Get_InlineTopSection_by_style_id(int StyleID, string StyleNumber)
        {
            InlinePPM inlinePPM = new InlinePPM();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_InlineTopSection_by_style_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StyleNumber", SqlDbType.VarChar);
                if(StyleNumber == "")
                    param.Value = DBNull.Value;
                else
                    param.Value = StyleNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPM.OrderContracts = new List<InlinePPMOrderContract>();

                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];
                DataTable dtFabricApproval = dsInlineTopSection.Tables[1];
                int result;
                foreach (DataRow row in dtOrderContracts.Rows)
                {
                    InlinePPMOrderContract orderDetail = new InlinePPMOrderContract();

                    // TODO: Populate the fields
                    orderDetail.InlinePPMId = (row["InlinePPMID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["InlinePPMID"]);
                    orderDetail.OrderDetailID = (row["OrderContractDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["OrderContractDetailID"]);
                    // Add By Ravi kumar 'OrderID' on 3/2/2016
                    orderDetail.OrderID = (row["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["OrderID"]);
                    //end
                    orderDetail.ContractNumber = (row["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ContractNumber"]);
                    orderDetail.LineItemNumber = (row["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["LineItemNumber"]);
                    orderDetail.TopSentTarget = (row["TopSentTarget"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["TopSentTarget"]);
                    orderDetail.TopSentActual = (row["TopSentActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["TopSentActual"]);
                    orderDetail.TopActualApproval = (row["TopActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["TopActualApproval"]);
                    orderDetail.MDA = (row["MDANumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["MDANumber"]);
                    orderDetail.BIPLComments = (row["BIPLComments"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BIPLComments"]);
                    orderDetail.iKandiComments = (row["iKandiComments"] == DBNull.Value) ? string.Empty : Convert.ToString(row["iKandiComments"]);
                    orderDetail.iKandiUploadFile = (row["iKandiUploadFile"] == DBNull.Value) ? string.Empty : Convert.ToString(row["iKandiUploadFile"]);
                    orderDetail.BIPLUploadFile = (row["BIPLUploadFile"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BIPLUploadFile"]);
                    orderDetail.Quantity = (row["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Quantity"]);
                    orderDetail.ExFactory = (row["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ExFactory"]);
                    orderDetail.IsIkandiClient = (row["IsIkandiClient"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IsIkandiClient"]);
                  
                        orderDetail.Fabric1 = (row["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric1"]);
                        orderDetail.Fabric2 = (row["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric2"]);
                        orderDetail.Fabric3 = (row["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric3"]);
                        orderDetail.Fabric4 = (row["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric4"]);
                        orderDetail.Fabric5 = (row["Fabric5"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric5"]);
                        orderDetail.Fabric6 = (row["Fabric6"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric6"]);

                        orderDetail.CCGSM1 = (row["GSM1"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GSM1"]);
                        orderDetail.CCGSM2 = (row["GSM2"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GSM2"]);
                        orderDetail.CCGSM3 = (row["GSM3"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GSM3"]);
                        orderDetail.CCGSM4 = (row["GSM4"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GSM4"]);
                        orderDetail.CCGSM5 = (row["GSM5"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GSM5"]);
                        orderDetail.CCGSM6 = (row["GSM6"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GSM6"]);

                        orderDetail.FabricApproval1 = (row["Approval1"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval1"]);
                        orderDetail.FabricApproval2 = (row["Approval2"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval2"]);
                        orderDetail.FabricApproval3 = (row["Approval3"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval3"]);
                        orderDetail.FabricApproval4 = (row["Approval4"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval4"]);

                        orderDetail.Fabric1Details = (row["Fabric1DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric1DetailsRef"]);
                        orderDetail.Fabric2Details = (row["Fabric2DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric2DetailsRef"]);
                        orderDetail.Fabric3Details = (row["Fabric3DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric3DetailsRef"]);
                        orderDetail.Fabric4Details = (row["Fabric4DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric4DetailsRef"]);
                        orderDetail.Fabric5Details = (row["Fabric5DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric5DetailsRef"]);
                        orderDetail.Fabric6Details = (row["Fabric6DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric6DetailsRef"]);

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
                        orderDetail.SealerRemarksBIPL = (row["RemarksBIPL"] == DBNull.Value) ? string.Empty : Convert.ToString(row["RemarksBIPL"]);
                        orderDetail.SealerRemarksiKandi = (row["RemarksIKANDI"] == DBNull.Value) ? string.Empty : Convert.ToString(row["RemarksIKANDI"]);

                        orderDetail.ParentOrder = new Order();
                        orderDetail.ParentOrder.SerialNumber = (row["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["SerialNumber"]);
                        orderDetail.ParentOrder.OrderDate = (row["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["OrderDate"]);
                        orderDetail.ParentOrder.DepartmentID = (row["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["DepartmentID"]);

                        orderDetail.ParentOrder.Style = new Style();
                        orderDetail.ParentOrder.Style.InLineCutDate = (row["InlineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["InlineCutDate"]);
                        orderDetail.ParentOrder.Style.StyleID = (row["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["StyleID"]);

                        orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                        orderDetail.ParentOrder.Style.cdept.DeptID = (row["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["DepartmentID"]);
                        orderDetail.ParentOrder.Style.cdept.Name = (row["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DepartmentName"]);

                        orderDetail.Unit = new ProductionUnit();
                        orderDetail.Unit.ProductionUnitId = (row["UnitID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["UnitID"]);
                        orderDetail.Unit.FactoryCode = (row["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FactoryCode"]);
                        orderDetail.Unit.FactoryName = (row["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FactoryName"]);

                        //inlinePPM.Order.TotalQuantity += orderDetail.Quantity;

                        orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (row["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse1"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (row["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse2"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (row["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse3"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (row["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse4"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric5Percent = (row["PercentInHouse5"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse5"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric6Percent = (row["PercentInHouse6"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse6"]);

                        orderDetail.FabClass = (row["FabClass"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FabClass"]);
                        orderDetail.DetailClass = (row["DetailClass"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DetailClass"]);

                        //string strx = "OrderDetailID =" + orderDetail.OrderDetailID;

                        //DataRow[] DataRows3;
                        //DataRows3 = dtFabricApproval.Select(strx);
                        //int F1Status = 0;
                        //int F2Status = 0;
                        //int F3Status = 0;
                        //int F4Status = 0;
                        //int F5Status = 0;
                        //int F6Status = 0;

                        //int F1Stage = 0;
                        //int F2Stage = 0;
                        //int F3Stage = 0;
                        //int F4Stage = 0;
                        //int F5Stage = 0;
                        //int F6Stage = 0;

                        //DateTime ActionDate1 = DateTime.MinValue;
                        //DateTime ActionDate2 = DateTime.MinValue;
                        //DateTime ActionDate3 = DateTime.MinValue;
                        //DateTime ActionDate4 = DateTime.MinValue;
                        //DateTime ActionDate5 = DateTime.MinValue;
                        //DateTime ActionDate6 = DateTime.MinValue;
                        //foreach (DataRow dr6 in DataRows3)
                        //{
                        //    F1Status = (dr6["F1Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F1Status"]) : 0;
                        //    F2Status = (dr6["F2Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F2Status"]) : 0;
                        //    F3Status = (dr6["F3Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F3Status"]) : 0;
                        //    F4Status = (dr6["F4Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F4Status"]) : 0;

                        //    F1Stage = (dr6["F1Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F1Stage"]) : 0;
                        //    F2Stage = (dr6["F2Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F2Stage"]) : 0;
                        //    F3Stage = (dr6["F3Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F3Stage"]) : 0;
                        //    F4Stage = (dr6["F4Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F4Stage"]) : 0;

                        //    ActionDate1 = (dr6["ActionDate1"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate1"]) : DateTime.MinValue;
                        //    ActionDate2 = (dr6["ActionDate2"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate2"]) : DateTime.MinValue;
                        //    ActionDate3 = (dr6["ActionDate3"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate3"]) : DateTime.MinValue;
                        //    ActionDate4 = (dr6["ActionDate4"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate4"]) : DateTime.MinValue;

                        //}

                        //orderDetail.ParentOrder.FabricApprovalDetails = new FabricApprovalDetails();
                        //orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus = "";
                        //orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus = "";
                        //orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus = "";
                        //orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus = "";
                        //orderDetail.ParentOrder.FabricApprovalDetails.F9BulkStatus = "";
                        //orderDetail.ParentOrder.FabricApprovalDetails.F10BulkStatus = "";

                        //orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus = Constants.GetFabricStatus(F1Stage, F1Status, ActionDate1);
                        //orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus = Constants.GetFabricStatus(F2Stage, F2Status, ActionDate2);
                        //orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus = Constants.GetFabricStatus(F3Stage, F3Status, ActionDate3);
                        //orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus = Constants.GetFabricStatus(F4Stage, F4Status, ActionDate4);
                        //orderDetail.ParentOrder.FabricApprovalDetails.F9BulkStatus = Constants.GetFabricStatus(F5Stage, F5Status, ActionDate5);
                        //orderDetail.ParentOrder.FabricApprovalDetails.F10BulkStatus = Constants.GetFabricStatus(F6Stage, F6Status, ActionDate6);

                        orderDetail.TopStatus = (row["TopStatus"] == DBNull.Value) ? TopStatusType.UNKNOWN : (TopStatusType)Convert.ToInt32(row["TopStatus"]);
                   

                    inlinePPM.OrderContracts.Add(orderDetail);
                }


                return inlinePPM;
            }

        }
        public InlinePPM Get_PPSample_OrderDetaiLDID(int OrderDetailID)
        {
            InlinePPM inlinePPM = new InlinePPM();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_PPSample_By_OrderDetailID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

               

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPM.OrderContracts = new List<InlinePPMOrderContract>();

                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];
                DataTable dtFabricApproval = dsInlineTopSection.Tables[1];
                int result;
                foreach (DataRow row in dtOrderContracts.Rows)
                {
                    InlinePPMOrderContract orderDetail = new InlinePPMOrderContract();

                    // TODO: Populate the fields
                    orderDetail.InlinePPMId = (row["PPSample_order_contractID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["PPSample_order_contractID"]);
                    orderDetail.OrderDetailID = (row["OrderContractDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["OrderContractDetailID"]);
                    // Add By Ravi kumar 'OrderID' on 3/2/2016
                    orderDetail.OrderID = (row["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["OrderID"]);
                    //end
                    orderDetail.ContractNumber = (row["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ContractNumber"]);
                    orderDetail.LineItemNumber = (row["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["LineItemNumber"]);
                    orderDetail.TopSentTarget = (row["PPSampleTarget"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["PPSampleTarget"]);
                    orderDetail.TopSentActual = (row["PPSampleActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["PPSampleActual"]);
                    orderDetail.TopActualApproval = (row["PPSampleActualApproval"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["PPSampleActualApproval"]);
                    orderDetail.MDA ="";
                    orderDetail.BIPLComments = (row["BIPLComments"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BIPLComments"]);
                    orderDetail.iKandiComments = (row["iKandiComments"] == DBNull.Value) ? string.Empty : Convert.ToString(row["iKandiComments"]);
                    orderDetail.iKandiUploadFile = (row["iKandiUploadFile"] == DBNull.Value) ? string.Empty : Convert.ToString(row["iKandiUploadFile"]);
                    orderDetail.BIPLUploadFile = (row["BIPLUploadFile"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BIPLUploadFile"]);
                    orderDetail.Quantity = (row["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row["Quantity"]);
                    orderDetail.ExFactory = (row["ExFactory"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ExFactory"]);
                    orderDetail.IsIkandiClient = (row["IsIkandiClient"] == DBNull.Value) ? 0 : Convert.ToInt32(row["IsIkandiClient"]);
                    orderDetail.PPSampleStatus = (row["Cycle"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Cycle"]);
                    try
                    {
                        orderDetail.Fabric1 = (row["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric1"]);
                        orderDetail.Fabric2 = (row["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric2"]);
                        orderDetail.Fabric3 = (row["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric3"]);
                        orderDetail.Fabric4 = (row["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric4"]);
                       
                        orderDetail.CCGSM1 = (row["Fabric11"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric11"]);
                        orderDetail.CCGSM2 = (row["Fabric12"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric12"]);
                        orderDetail.CCGSM3 = (row["Fabric13"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric13"]);
                        orderDetail.CCGSM4 = (row["Fabric14"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric14"]);
                        orderDetail.FabricApproval1 = (row["Approval1"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval1"]);
                        orderDetail.FabricApproval2 = (row["Approval2"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval2"]);
                        orderDetail.FabricApproval3 = (row["Approval3"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval3"]);
                        orderDetail.FabricApproval4 = (row["Approval4"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval4"]);
                       
                    }
                    catch (Exception)
                    {
                    }
                    orderDetail.Fabric1Details = (row["Fabric1DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric1DetailsRef"]);
                    orderDetail.Fabric2Details = (row["Fabric2DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric2DetailsRef"]);
                    orderDetail.Fabric3Details = (row["Fabric3DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric3DetailsRef"]);
                    orderDetail.Fabric4Details = (row["Fabric4DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric4DetailsRef"]);
                   
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

                    orderDetail.SealerRemarksBIPL = (row["RemarksBIPL"] == DBNull.Value) ? string.Empty : Convert.ToString(row["RemarksBIPL"]);
                    orderDetail.SealerRemarksiKandi = (row["RemarksIKANDI"] == DBNull.Value) ? string.Empty : Convert.ToString(row["RemarksIKANDI"]);

                    orderDetail.ParentOrder = new Order();
                    orderDetail.ParentOrder.SerialNumber = (row["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["SerialNumber"]);
                    orderDetail.ParentOrder.OrderDate = (row["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["OrderDate"]);
                    orderDetail.ParentOrder.DepartmentID = (row["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["DepartmentID"]);


                    orderDetail.ParentOrder.Style = new Style();
                    orderDetail.ParentOrder.Style.InLineCutDate = (row["InlineCutDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["InlineCutDate"]);
                    orderDetail.ParentOrder.Style.StyleID = (row["StyleID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["StyleID"]);

                    orderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                    orderDetail.ParentOrder.Style.cdept.DeptID = (row["DepartmentID"] == DBNull.Value) ? 0 : Convert.ToInt32(row["DepartmentID"]);
                    orderDetail.ParentOrder.Style.cdept.Name = (row["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DepartmentName"]);

                    orderDetail.Unit = new ProductionUnit();
                    orderDetail.Unit.ProductionUnitId = (row["UnitID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["UnitID"]);
                    orderDetail.Unit.FactoryCode = (row["FactoryCode"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FactoryCode"]);
                    orderDetail.Unit.FactoryName = (row["FactoryName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FactoryName"]);

                    //inlinePPM.Order.TotalQuantity += orderDetail.Quantity;

                    orderDetail.ParentOrder.FabricInhouseHistory = new FabricInhouseHistory();
                    orderDetail.ParentOrder.FabricInhouseHistory.Fabric1Percent = (row["PercentInHouse1"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse1"]);
                    orderDetail.ParentOrder.FabricInhouseHistory.Fabric2Percent = (row["PercentInHouse2"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse2"]);
                    orderDetail.ParentOrder.FabricInhouseHistory.Fabric3Percent = (row["PercentInHouse3"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse3"]);
                    orderDetail.ParentOrder.FabricInhouseHistory.Fabric4Percent = (row["PercentInHouse4"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse4"]);
                    if ((cnx.Database == "donttouch") || (cnx.Database == "SamratDemo14May") || (cnx.Database == "SamratDemo27Aug") || (cnx.Database == "SanjeevStockissue") || (cnx.Database == "Final_Migration") || (cnx.Database == "Testing_Final_New") || (cnx.Database == "Material_Migration"))
                    {
                        orderDetail.Fabric5 = (row["Fabric5"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric5"]);
                        orderDetail.Fabric6 = (row["Fabric6"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric6"]);
                        orderDetail.FabricApproval5 = (row["Approval5"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval5"]);
                        orderDetail.FabricApproval6 = (row["Approval6"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Approval6"]);
                        orderDetail.CCGSM5 = (row["Fabric15"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric15"]);
                        orderDetail.CCGSM6 = (row["Fabric16"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric16"]);
                        orderDetail.Fabric5Details = (row["Fabric5DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric5DetailsRef"]);
                        orderDetail.Fabric6Details = (row["Fabric6DetailsRef"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric6DetailsRef"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric5Percent = (row["PercentInHouse5"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse5"]);
                        orderDetail.ParentOrder.FabricInhouseHistory.Fabric6Percent = (row["PercentInHouse6"] == DBNull.Value) ? 0 : Convert.ToInt32(row["PercentInHouse6"]);
                    }
                    orderDetail.FabClass = (row["FabClass"] == DBNull.Value) ? string.Empty : Convert.ToString(row["FabClass"]);
                    orderDetail.DetailClass = (row["DetailClass"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DetailClass"]);

                    string strx = "OrderDetailID =" + orderDetail.OrderDetailID;

                    DataRow[] DataRows3;
                    DataRows3 = dtFabricApproval.Select(strx);
                    int F1Status = 0;
                    int F2Status = 0;
                    int F3Status = 0;
                    int F4Status = 0;
                    int F5Status = 0;
                    int F6Status = 0;

                    int F1Stage = 0;
                    int F2Stage = 0;
                    int F3Stage = 0;
                    int F4Stage = 0;
                    int F5Stage = 0;
                    int F6Stage = 0;

                    DateTime ActionDate1 = DateTime.MinValue;
                    DateTime ActionDate2 = DateTime.MinValue;
                    DateTime ActionDate3 = DateTime.MinValue;
                    DateTime ActionDate4 = DateTime.MinValue;
                    DateTime ActionDate5 = DateTime.MinValue;
                    DateTime ActionDate6 = DateTime.MinValue;
                    foreach (DataRow dr6 in DataRows3)
                    {
                        F1Status = (dr6["F1Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F1Status"]) : 0;
                        F2Status = (dr6["F2Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F2Status"]) : 0;
                        F3Status = (dr6["F3Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F3Status"]) : 0;
                        F4Status = (dr6["F4Status"] != DBNull.Value) ? Convert.ToInt32(dr6["F4Status"]) : 0;

                        F1Stage = (dr6["F1Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F1Stage"]) : 0;
                        F2Stage = (dr6["F2Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F2Stage"]) : 0;
                        F3Stage = (dr6["F3Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F3Stage"]) : 0;
                        F4Stage = (dr6["F4Stage"] != DBNull.Value) ? Convert.ToInt32(dr6["F4Stage"]) : 0;

                        ActionDate1 = (dr6["ActionDate1"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate1"]) : DateTime.MinValue;
                        ActionDate2 = (dr6["ActionDate2"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate2"]) : DateTime.MinValue;
                        ActionDate3 = (dr6["ActionDate3"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate3"]) : DateTime.MinValue;
                        ActionDate4 = (dr6["ActionDate4"] != DBNull.Value) ? Convert.ToDateTime(dr6["ActionDate4"]) : DateTime.MinValue;

                    }

                    orderDetail.ParentOrder.FabricApprovalDetails = new FabricApprovalDetails();
                    orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus = "";
                    orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus = "";
                    orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus = "";
                    orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus = "";
                    orderDetail.ParentOrder.FabricApprovalDetails.F9BulkStatus = "";
                    orderDetail.ParentOrder.FabricApprovalDetails.F10BulkStatus = "";

                    orderDetail.ParentOrder.FabricApprovalDetails.F5BulkStatus = Constants.GetFabricStatus(F1Stage, F1Status, ActionDate1);
                    orderDetail.ParentOrder.FabricApprovalDetails.F6BulkStatus = Constants.GetFabricStatus(F2Stage, F2Status, ActionDate2);
                    orderDetail.ParentOrder.FabricApprovalDetails.F7BulkStatus = Constants.GetFabricStatus(F3Stage, F3Status, ActionDate3);
                    orderDetail.ParentOrder.FabricApprovalDetails.F8BulkStatus = Constants.GetFabricStatus(F4Stage, F4Status, ActionDate4);
                    orderDetail.ParentOrder.FabricApprovalDetails.F9BulkStatus = Constants.GetFabricStatus(F5Stage, F5Status, ActionDate5);
                    orderDetail.ParentOrder.FabricApprovalDetails.F10BulkStatus = Constants.GetFabricStatus(F6Stage, F6Status, ActionDate6);

                    orderDetail.TopStatus = (row["PPSampleStatus"] == DBNull.Value) ? TopStatusType.UNKNOWN : (TopStatusType)Convert.ToInt32(row["PPSampleStatus"]);

                    inlinePPM.OrderContracts.Add(orderDetail);
                }


                return inlinePPM;
            }

        }
        public InlinePPM Get_PPSample_History_OrderDetaiLDID(int OrderDetailID)
        {
            InlinePPM inlinePPM = new InlinePPM();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_Get_PPSample_By_History_OrderDetailID";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);



                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPM.OrderContracts = new List<InlinePPMOrderContract>();

                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];
              
                foreach (DataRow row in dtOrderContracts.Rows)
                {
                    InlinePPMOrderContract orderDetail = new InlinePPMOrderContract();

                    // TODO: Populate the fields
                  
                    //end
                    orderDetail.MDA = (row["PPSampleStatus"] == DBNull.Value) ? string.Empty : Convert.ToString(row["PPSampleStatus"]);
                    orderDetail.TopSentActual = (row["PPSampleActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["PPSampleActual"]);
                    orderDetail.PPSampleStatus = (row["Cycle"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Cycle"]);
                    inlinePPM.OrderContracts.Add(orderDetail);
                }

                return inlinePPM;
            }

        }

        // Update By Ravi kumar on 6/1/2015
        public void SaveOrderContractTOPDetails(InlinePPMOrderContract contract)
        {
            string cmdText = "sp_InlineTopSection_insert";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //foreach (InlinePPMOrderContract contract in InlinePPMData.OrderContracts)
                //{
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = contract.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                    param.Value = contract.InlinePPMId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TopSentTarget", SqlDbType.DateTime);
                    if ((contract.TopSentTarget == DateTime.MinValue) || (contract.TopSentTarget == Convert.ToDateTime("1753-01-01")) || (contract.TopSentTarget == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = contract.TopSentTarget;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TopSentActual", SqlDbType.DateTime);
                    if ((contract.TopSentActual == DateTime.MinValue) || (contract.TopSentActual == Convert.ToDateTime("1753-01-01")) || (contract.TopSentActual == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = contract.TopSentActual;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TopActualApproval", SqlDbType.DateTime);
                    if ((contract.TopActualApproval == DateTime.MinValue) || (contract.TopActualApproval == Convert.ToDateTime("1753-01-01")) || (contract.TopActualApproval == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = contract.TopActualApproval;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPLUploadFile", SqlDbType.VarChar);
                    param.Value = contract.BIPLUploadFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPLComments", SqlDbType.VarChar);
                    param.Value = contract.BIPLComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@KandiUploadFile", SqlDbType.VarChar);
                    param.Value = contract.iKandiUploadFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@KandiComments", SqlDbType.VarChar);
                    param.Value = contract.iKandiComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TopStatus", SqlDbType.Int);
                    param.Value = (int)contract.TopStatus;
                    //if (contract.TopStatus != TopStatusType.UNKNOWN)
                    //{

                    //}
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
        public void SavePPMDetails(InlinePPMOrderContract contract)
        {
            string cmdText = "sp_PPM_insert";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //foreach (InlinePPMOrderContract contract in InlinePPMData.OrderContracts)
                //{
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = contract.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@nlinePPMID", SqlDbType.Int);
                    param.Value = contract.InlinePPMId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TopSentTarget", SqlDbType.DateTime);
                    if ((contract.TopSentTarget == DateTime.MinValue) || (contract.TopSentTarget == Convert.ToDateTime("1753-01-01")) || (contract.TopSentTarget == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = contract.TopSentTarget;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TopSentActual", SqlDbType.DateTime);
                    if ((contract.TopSentActual == DateTime.MinValue) || (contract.TopSentActual == Convert.ToDateTime("1753-01-01")) || (contract.TopSentActual == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = contract.TopSentActual;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@TopActualApproval", SqlDbType.DateTime);
                    //if ((contract.TopActualApproval == DateTime.MinValue) || (contract.TopActualApproval == Convert.ToDateTime("1753-01-01")) || (contract.TopActualApproval == Convert.ToDateTime("1900-01-01")))
                    //{
                    //    param.Value = DBNull.Value;
                    //}
                    //else
                    //{
                    //    param.Value = contract.TopActualApproval;
                    //}
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPLUploadFile", SqlDbType.VarChar);
                    param.Value = contract.BIPLUploadFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BIPLComments", SqlDbType.VarChar);
                    param.Value = contract.BIPLComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@KandiUploadFile", SqlDbType.VarChar);
                    param.Value = contract.iKandiUploadFile;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@KandiComments", SqlDbType.VarChar);
                    param.Value = contract.iKandiComments;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TopStatus", SqlDbType.Int);
                    param.Value = (int)contract.TopStatus;
                    //if (contract.TopStatus != TopStatusType.UNKNOWN)
                    //{

                    //}
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Cycle", SqlDbType.VarChar);
                    param.Value = contract.PPSampleStatus;
                    //if (contract.TopStatus != TopStatusType.UNKNOWN)
                    //{

                    //}
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
      

        public DataTable OB_HeaderExist(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dtOBHeader = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_OB_HeaderExist";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOBHeader);


                return dtOBHeader;
            }

        }

        public int CreateNewRef_ReUse_All_OBdata(int styleid, string StyleCode, int ClientId, int DeptId, int ReUseStyleId, int ReUse, int NewRef, int UserId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "usp_CreateNewRef_ReUse_All_OBdata";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
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

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.VarChar);
                    param.Value = UserId;
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

        public DataTable GET_OB_ReUseStyle(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dtOBCMT = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GET_OB_ReUseStyle";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOBCMT);


                return dtOBCMT;
            }

        }



        //END
        //Added By Prabhaker On 29/05/2017

        public DataTable GetCostingComplete(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dtCostingExit = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_styles_Costing_style";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCostingExit);

                return dtCostingExit;
            }
        }




        //Added By bharat On 27/03/2019
        public DataTable Getbipladdress(int PoDetailID, string types, string Flag)
        {
       
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_SRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                param.Value = 0;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                 param = new SqlParameter("@Types", SqlDbType.VarChar);
                param.Value = types;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];
                // DataTable dtOrderAddress = dsInlineTopSection.Tables[1];

                return dtOrderContracts;
            }

        }
        public string[] Get_Srv_detailsProxy(string PartyBillNo, string Flag, string SrvId)
        {
            string Billdate = "";
            string PartyBillId = "";
            string PartyAmount = "";
            string AlertMsg = "";
            string IsFreeze = "";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_SRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PartyBillNo", SqlDbType.VarChar);
                param.Value = PartyBillNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "GETALLBILLNO";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = SrvId == "" ? 0 : Convert.ToInt32(SrvId);
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);
               
                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];               
             
                foreach (DataRow row in dtOrderContracts.Rows)
                {
                    Billdate = (row["PartyBillDate"] == DBNull.Value) ? "0" : Convert.ToDateTime(row["PartyBillDate"]).ToString("dd MMM yy (ddd)");
                    PartyBillId = (row["PartyBillId"] == DBNull.Value) ? "-1" : Convert.ToInt32(row["PartyBillId"]).ToString();
                    PartyAmount = (row["Amount"] == DBNull.Value) ? "" : Convert.ToString(row["Amount"]);
                    AlertMsg = (row["AlertMsg"] == DBNull.Value) ? "" : Convert.ToString(row["AlertMsg"]);
                    IsFreeze = (row["IsFreeze"] == DBNull.Value) ? "" : Convert.ToString(row["IsFreeze"]);  
                }
                string[] returnString = new string[5] { Billdate.ToString(), PartyBillId, PartyAmount, AlertMsg, IsFreeze };
                return returnString;
            }

        }

        public InlinePPM Get_Srv_details(int PoDetailID, string Type,string Flag)
        {
            InlinePPM inlinePPM = new InlinePPM();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_SRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                param.Value = PoDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                 param = new SqlParameter("@Types", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@Flag", SqlDbType.VarChar);
                //param.Value = Flag;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPM.OrderContracts = new List<InlinePPMOrderContract>();

                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];
                //DataTable dtOrderAddress = dsInlineTopSection.Tables[1];

                foreach (DataRow row in dtOrderContracts.Rows)
                {
                    InlinePPMOrderContract SrvDetail = new InlinePPMOrderContract();

                    // TODO: Populate the fields

                    //end
                    SrvDetail.SupplierName = (row["SupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["SupplierName"]);
                    SrvDetail.PO_Number = (row["PO_Number"] == DBNull.Value) ? string.Empty : Convert.ToString(row["PO_Number"]);
                    SrvDetail.Receiving_Voucher_No = (row["Receiving_Voucher_No"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Receiving_Voucher_No"]);
                    SrvDetail.SRVDate = (row["SRVDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["SRVDate"]);
                    SrvDetail.PartyChallanNumber = (row["PartyChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["PartyChallanNumber"]);
                    SrvDetail.ReceivedUnit = (row["ReceivedUnit"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ReceivedUnit"]);
                    SrvDetail.GateNumber = (row["GateNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GateNumber"]);
                    SrvDetail.ReceivedQty = (row["ReceivedQty"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ReceivedQty"]);
                    SrvDetail.ActualReceivedQty = (row["ActualReceivedQty"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ActualReceivedQty"]);
                    SrvDetail.SRVRemarks = (row["SRVRemarks"] == DBNull.Value) ? string.Empty : Convert.ToString(row["SRVRemarks"]);
                    SrvDetail.Rate = (row["Rate"] == DBNull.Value) ? Convert.ToDecimal(string.Empty) : Math.Round(Convert.ToDecimal(row["Rate"]), 0, MidpointRounding.AwayFromZero);
                    SrvDetail.GarmentUnit = (row["GarmentUnit"] == DBNull.Value) ? string.Empty : Convert.ToString(row["GarmentUnit"]);
                    SrvDetail.SRVFabric = (row["Fabric"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Fabric"]);
                    SrvDetail.PartyBillNumber = (row["PartyBillNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["PartyBillNumber"]);
                    SrvDetail.Print = (row["Print"] == DBNull.Value) ? string.Empty : Convert.ToString(row["Print"]);
                    SrvDetail.Billdate = (row["PartyBillDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["PartyBillDate"]);
                    SrvDetail.PartyBillId = (row["PartyNillId"] == DBNull.Value) ? -1 : Convert.ToInt32(row["PartyNillId"]);
                    SrvDetail.PartyAmount = (row["Amount"] == DBNull.Value) ? "" : Convert.ToString(row["Amount"]);
                    SrvDetail.SupplierMasterID = (row["SupplierID"] == DBNull.Value) ? -1 : Convert.ToInt32(row["SupplierID"]);

                    SrvDetail.StoreInchargeId = (row["IsStoreIncharge"] == DBNull.Value) ? -1 : Convert.ToInt32(row["IsStoreIncharge"]);
                    SrvDetail.QtyCheckedBy = (row["IsQtyChecked"] == DBNull.Value) ? -1 : Convert.ToInt32(row["IsQtyChecked"]);
                    SrvDetail.StoreInchargeCheckedDate = (row["StoreInchargeDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["StoreInchargeDate"]);
                    SrvDetail.QtyCheckedDate = (row["QtyCheckedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["QtyCheckedDate"]);
                    SrvDetail.PartyChallanQue = (row["PartyChallanQue"] == DBNull.Value) ? "" : Convert.ToString(row["PartyChallanQue"]);

                    SrvDetail.ConverToUnit = Convert.ToInt32(row["ConvertToUnit"]);
                    SrvDetail.ConversionValue = (float)Convert.ToDouble((row["ConversionValue"]));
                    SrvDetail.DefaultUnit = Convert.ToInt32(row["defualtunit"]);
                    SrvDetail.IsFabricGMCheckDone = Convert.ToInt32(row["IsFabricGMCheckDone"]);
                    inlinePPM.OrderContracts.Add(SrvDetail);
                }

               
                return inlinePPM;
            }

        }

        public DataTable getmaxvouchernumber(int PoDetailID, string Type, string Flag, int PartyBillId = 0, string PartyBillNo = "", int SupplierMasterID=0)
        {
          DataTable dt = new DataTable();
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();

            DataSet dsInlineTopSection = new DataSet();
            SqlCommand cmd;
            string cmdText;

            cmdText = "USP_Get_SRV";
            cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
            param.Value = PoDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Types", SqlDbType.VarChar);
            param.Value = Type;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartyBillNo", SqlDbType.VarChar);
            param.Value = PartyBillNo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Flag", SqlDbType.VarChar);
            param.Value = Flag;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PartyBillId", SqlDbType.Int);
            param.Value = PartyBillId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SupplierMasterID", SqlDbType.Int);
            param.Value = SupplierMasterID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
          }

        }


        //girish
        public DataTable getDataToBindGridWithId_grdbill(int MasterPoId, int SrvID,string BillNumber,string flag)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_SRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                param.Value = MasterPoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = SrvID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PartyBillNo", SqlDbType.VarChar);
                param.Value = BillNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);  

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }

        }


        public DataTable getmaxvouchernumbeAcc(int PoDetailID, string Type, string Flag, int PartyBillId = 0, string PartyBillNo = "", int SupplierMasterID = 0)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessorySRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = PoDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PartyBillNo", SqlDbType.VarChar);
                param.Value = PartyBillNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

              
                param = new SqlParameter("@PartyBillId", SqlDbType.Int);
                param.Value = PartyBillId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierMasterID", SqlDbType.Int);
                param.Value = SupplierMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }

        }
        public DataTable Accgetmaxvouchernumber(int PoDetailID, string Type, string Flag, int PartyBillId = 0, string PartyBillNo = "",int SupplierMasterID=0)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessorySRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierPoId", SqlDbType.Int);
                param.Value = PoDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

               

                param = new SqlParameter("@PartyBillNo", SqlDbType.VarChar);
                param.Value = PartyBillNo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PartyBillId", SqlDbType.Int);
                param.Value = PartyBillId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierMasterID", SqlDbType.Int);
                param.Value = SupplierMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }

        }
        public DataTable  GetPartyBillAmt(int SupplierMasterID, string PartyNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AccessorySRV";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@SupplierMasterID", SqlDbType.Int);
                param.Value = SupplierMasterID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@type", SqlDbType.VarChar);
                param.Value = "GETBILLISAMEPO";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@PartyBillNo", SqlDbType.VarChar);
                param.Value = PartyNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }

        }
        public void SaveSrv(InlinePPMOrderContract SrvDetail)
        {
            string cmdText = "sp_SRV_insert";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                //foreach (InlinePPMOrderContract contract in InlinePPMData.OrderContracts)
                //{
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                    param.Value = SrvDetail.PoDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SRVDate", SqlDbType.DateTime);
                    if ((SrvDetail.SRVDate == DateTime.MinValue) || (SrvDetail.SRVDate == Convert.ToDateTime("1753-01-01")) || (SrvDetail.SRVDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SrvDetail.SRVDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyChallanNumber", SqlDbType.VarChar);
                    param.Value = SrvDetail.PartyChallanNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsStoreIncharge", SqlDbType.Int);
                    param.Value = SrvDetail.StoreInchargeId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsQtyChecked", SqlDbType.Int);
                    param.Value = SrvDetail.QtyCheckedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StoreInchargeDate", SqlDbType.DateTime);
                    if (SrvDetail.StoreInchargeCheckedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SrvDetail.StoreInchargeCheckedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QtyCheckedDate", SqlDbType.DateTime);
                    if (SrvDetail.QtyCheckedDate == DateTime.MinValue)
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = SrvDetail.QtyCheckedDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@GateNumber", SqlDbType.VarChar);
                    param.Value = SrvDetail.GateNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedUnit", SqlDbType.VarChar);
                    param.Value = SrvDetail.ReceivedUnit;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReceivedQty", SqlDbType.Int);
                    param.Value = Convert.ToInt32(SrvDetail.ReceivedQty.Replace(",",""));
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Receiving_Voucher_No", SqlDbType.VarChar);
                    param.Value = SrvDetail.Receiving_Voucher_No;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PartyBillNumber", SqlDbType.VarChar);
                    param.Value = SrvDetail.PartyBillNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SingnFlag", SqlDbType.VarChar);
                    param.Value = SrvDetail.SignFlag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = SrvDetail.SRVRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.VarChar);
                    param.Value = SrvDetail.SRV_Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SrvID", SqlDbType.Int);
                    param.Value = SrvDetail.SrvMasterID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }


        public InlinePPM Get_DebitChallan_details(int DebitNoteId, int Flag, string type)
        {
            //InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
            InlinePPM inlinePPM = new InlinePPM();
            
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;
                
                    cmdText = "USP_GET_DEBITNOTE";
                
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPM.OrderContracts = new List<InlinePPMOrderContract>();

                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];
                
                foreach (DataRow row in dtOrderContracts.Rows)
                {
                    InlinePPMOrderContract dtDebitnotes = new InlinePPMOrderContract();
                    dtDebitnotes.DebitSupplierName = (row["DebitSupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DebitSupplierName"]);
                    dtDebitnotes.DebitNoteNumber = (row["DebitNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["DebitNoteNumber"]);
                    dtDebitnotes.DebitChallanDate = (row["DebitNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["DebitNoteDate"]);
                    dtDebitnotes.DebitAgaistBillNo = (row["BillNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BillNumber"]);
                    dtDebitnotes.debitPodate = (row["debitPodate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["debitPodate"]);
                    dtDebitnotes.PoBillDate = (row["Billdate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["Billdate"]);
                     
                    dtDebitnotes.DebitChallanReturnNo = (row["ReturnChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ReturnChallanNumber"]);
                    dtDebitnotes.FDebitChallanReturnDate = (row["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ChallanDate"]);
                    inlinePPM.OrderContracts.Add(dtDebitnotes);
                }

                return inlinePPM;
            }

        }
        public InlinePPM Get_CreditChallan_details(int CreditNoteId, int Flag, string type)
        {
            //InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
            InlinePPM inlinePPM = new InlinePPM();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_CREDITNOTE"; 

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = CreditNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPM.OrderContracts = new List<InlinePPMOrderContract>();

                DataTable dtOrderContracts = dsInlineTopSection.Tables[0];
                
                foreach (DataRow row in dtOrderContracts.Rows)
                {
                    InlinePPMOrderContract dtDebitnotes = new InlinePPMOrderContract();
                    dtDebitnotes.CreditSupplierName = (row["CreditSupplierName"] == DBNull.Value) ? string.Empty : Convert.ToString(row["CreditSupplierName"]);
                    dtDebitnotes.CreditNoteNumber = (row["CreditNoteNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["CreditNoteNumber"]);
                    dtDebitnotes.CreditChallanDate = (row["CreditNoteDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["CreditNoteDate"]);
                    dtDebitnotes.CreditAgaistBillNo = (row["BillNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["BillNumber"]);
                    dtDebitnotes.CreditPodate = (row["CreditPodate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["CreditPodate"]);
                    dtDebitnotes.PoBillDate = (row["Billdate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["Billdate"]);

                    dtDebitnotes.CreditChallanReturnNo = (row["ReturnChallanNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row["ReturnChallanNumber"]);
                    dtDebitnotes.FCreditChallanReturnDate = (row["ChallanDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ChallanDate"]);
                    inlinePPM.OrderContracts.Add(dtDebitnotes);
                }

                return inlinePPM;
            }

        }
        public DataTable Get_DebitChallan_details_id2(int DebitNoteId, int Flag, string type)
        {
            //InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
            DataTable inlinePPMs = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_DEBITNOTE";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);
                inlinePPMs = dsInlineTopSection.Tables[0];
                return inlinePPMs;
            }

        }
        public DataTable Get_CreditChallan_details_id2(int CreditNoteId, int Flag, string type)
        {
            //InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
            DataTable inlinePPMs = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_CREDITNOTE";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = CreditNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPMs = dsInlineTopSection.Tables[0];
                return inlinePPMs;
            }

        }
        public DataTable Get_DebitChallan_details_id(int DebitNoteId, int Flag, string type)
        {
          //InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
          DataTable inlinePPMs = new DataTable();

          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {

            cnx.Open();

            DataSet dsInlineTopSection = new DataSet();
            SqlCommand cmd;
            string cmdText;

            cmdText = "USP_GET_DEBITNOTE";

            cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
            param.Value = DebitNoteId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Flag", SqlDbType.Int);
            param.Value = Flag;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            param.Value = type;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dsInlineTopSection);

            inlinePPMs = dsInlineTopSection.Tables[1];
            return inlinePPMs;
          }

        }
        public DataTable Get_CreditChallan_details_id(int CreditNoteId, int Flag, string type)
        {
            //InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
            DataTable inlinePPMs = new DataTable();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_CREDITNOTE";

                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = CreditNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);

                inlinePPMs = dsInlineTopSection.Tables[1];

                return inlinePPMs;
            }

        }
        public DataTable Get_DebitChallan_detailsTable(int DebitNoteId, int Flag,string Type)
        {
            
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_DEBITNOTE";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                param.Value = DebitNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);
                

                DataTable dtgridDebitnotes = dsInlineTopSection.Tables[0];


                return dtgridDebitnotes;
            }

        }
        public DataTable Get_CreditChallan_detailsTable(int CreditNoteId, int Flag, string Type)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                cnx.Open();

                DataSet dsInlineTopSection = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_GET_CREDITNOTE";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@CreditNoteId", SqlDbType.Int);
                param.Value = CreditNoteId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar);
                param.Value = Type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsInlineTopSection);


                DataTable dtgridDebitnotes = dsInlineTopSection.Tables[0];


                return dtgridDebitnotes;
            }

        }


        //end
        public void Save_FabricDebitNote(InlinePPMOrderContract DebitNotesDetail, ref int DebitNoteID, int PO_id)
        {
            string cmdText = "USP_InsertUpdate_DebitNotes";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();               
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    //SqlParameter outParam;

                    //outParam = new SqlParameter("@DebitNoteIdOut", SqlDbType.Int);
                    //outParam.Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add(outParam);


                    //SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                    //param.Value = DebitNotesDetail.PoDetailID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    SqlParameter param;
                    param = new SqlParameter("@DebitNoteId", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteNumber", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                 

                    param = new SqlParameter("@DebitChallanDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.DebitChallanDate == DateTime.MinValue) || (DebitNotesDetail.DebitChallanDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.DebitChallanDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.DebitChallanDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PoBillDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.PoBillDate == DateTime.MinValue) || (DebitNotesDetail.PoBillDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.PoBillDate == Convert.ToDateTime("1900-01-01")))
                    {
                      param.Value = DBNull.Value;
                    }
                    else
                    {
                      param.Value = DebitNotesDetail.PoBillDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitAgaistBillNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitAgaistBillNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitChallanReturnNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitChallanReturnNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FDebitChallanReturnDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.FDebitChallanReturnDate == DateTime.MinValue) || (DebitNotesDetail.FDebitChallanReturnDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.FDebitChallanReturnDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.FDebitChallanReturnDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PO_id", SqlDbType.Int);
                    param.Value = PO_id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@DebitNoteIdOut", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                  
                    

                    cmd.ExecuteNonQuery();
                    DebitNoteID = Convert.ToInt32(outParam.Value);
                      //foreach (InlinePPMOrderContract DebitNotesDetail in DebitNotesDetail.ORDERC)
                  ///  DebitNotesDetail.DebitNoteId = Convert.ToInt32(outParam.Value);

                    //foreach (InlinePPMDebitNotesDetail objDebitNoteDetail in DebitNotesDetail.PPMDebitNotesDetail)
                    //{
                    //    Save_FabricDebitNoteDetail(objDebitNoteDetail, cnx);
                    //}

                    
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
        public void Save_FabricCreditNote(InlinePPMOrderContract DebitNotesDetail, ref int CreditNoteId, int PO_id)
        {
            string cmdText = "USP_InsertUpdate_CreditNotes";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    //SqlParameter outParam;

                    //outParam = new SqlParameter("@DebitNoteIdOut", SqlDbType.Int);
                    //outParam.Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add(outParam);


                    //SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                    //param.Value = DebitNotesDetail.PoDetailID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    SqlParameter param;
                    param = new SqlParameter("@CreditNoteId", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.CreditNoteId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreditNoteNumber", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.CreditNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@CreditChallanDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.CreditChallanDate == DateTime.MinValue) || (DebitNotesDetail.CreditChallanDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.CreditChallanDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.CreditChallanDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PoBillDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.PoBillDate == DateTime.MinValue) || (DebitNotesDetail.PoBillDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.PoBillDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.PoBillDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreditAgaistBillNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.CreditAgaistBillNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreditChallanReturnNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.CreditChallanReturnNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FCreditChallanReturnDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.FCreditChallanReturnDate == DateTime.MinValue) || (DebitNotesDetail.FCreditChallanReturnDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.FCreditChallanReturnDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.FCreditChallanReturnDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PO_id", SqlDbType.Int);
                    param.Value = PO_id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter outParam;
                    outParam = new SqlParameter("@CreditNoteIdOut", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);




                    cmd.ExecuteNonQuery();
                    CreditNoteId = Convert.ToInt32(outParam.Value);
                    //foreach (InlinePPMOrderContract DebitNotesDetail in DebitNotesDetail.ORDERC)
                    ///  DebitNotesDetail.DebitNoteId = Convert.ToInt32(outParam.Value);

                    //foreach (InlinePPMDebitNotesDetail objDebitNoteDetail in DebitNotesDetail.PPMDebitNotesDetail)
                    //{
                    //    Save_FabricDebitNoteDetail(objDebitNoteDetail, cnx);
                    //}


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
        public void Update_FabricDebitNote(InlinePPMOrderContract DebitNotesDetail, int Debit_Note_ID)
        {
            string cmdText = "USP_Update_DebitNotes";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    //SqlParameter outParam;

                    //outParam = new SqlParameter("@DebitNoteIdOut", SqlDbType.Int);
                    //outParam.Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add(outParam);


                    //SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                    //param.Value = DebitNotesDetail.PoDetailID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    SqlParameter param;
                    param = new SqlParameter("@DebitNoteId", SqlDbType.Int);
                    param.Value = Debit_Note_ID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteNumber", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@DebitChallanDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.DebitChallanDate == DateTime.MinValue) || (DebitNotesDetail.DebitChallanDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.DebitChallanDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.DebitChallanDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitAgaistBillNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitAgaistBillNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitChallanReturnNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitChallanReturnNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FDebitChallanReturnDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.FDebitChallanReturnDate == DateTime.MinValue) || (DebitNotesDetail.FDebitChallanReturnDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.FDebitChallanReturnDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.FDebitChallanReturnDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();
                   
                    //foreach (InlinePPMOrderContract DebitNotesDetail in DebitNotesDetail.ORDERC)
                    ///  DebitNotesDetail.DebitNoteId = Convert.ToInt32(outParam.Value);

                    //foreach (InlinePPMDebitNotesDetail objDebitNoteDetail in DebitNotesDetail.PPMDebitNotesDetail)
                    //{
                    //    Save_FabricDebitNoteDetail(objDebitNoteDetail, cnx);
                    //}


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
        public void Update_FabricCreditNote(InlinePPMOrderContract DebitNotesDetail, int CreditNoteID)
        {
            string cmdText = "USP_Update_CreditNotes";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    //SqlParameter outParam;

                    //outParam = new SqlParameter("@DebitNoteIdOut", SqlDbType.Int);
                    //outParam.Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add(outParam);


                    //SqlParameter param = new SqlParameter("@PoDetailID", SqlDbType.Int);
                    //param.Value = DebitNotesDetail.PoDetailID;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);
                    SqlParameter param;
                    param = new SqlParameter("@CreditNoteID", SqlDbType.Int);
                    param.Value = CreditNoteID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitNoteNumber", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitNoteNumber;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@DebitChallanDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.DebitChallanDate == DateTime.MinValue) || (DebitNotesDetail.DebitChallanDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.DebitChallanDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.DebitChallanDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitAgaistBillNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitAgaistBillNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitChallanReturnNo", SqlDbType.VarChar);
                    param.Value = DebitNotesDetail.DebitChallanReturnNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FDebitChallanReturnDate", SqlDbType.DateTime);
                    if ((DebitNotesDetail.FDebitChallanReturnDate == DateTime.MinValue) || (DebitNotesDetail.FDebitChallanReturnDate == Convert.ToDateTime("1753-01-01")) || (DebitNotesDetail.FDebitChallanReturnDate == Convert.ToDateTime("1900-01-01")))
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = DebitNotesDetail.FDebitChallanReturnDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();

                    //foreach (InlinePPMOrderContract DebitNotesDetail in DebitNotesDetail.ORDERC)
                    ///  DebitNotesDetail.DebitNoteId = Convert.ToInt32(outParam.Value);

                    //foreach (InlinePPMDebitNotesDetail objDebitNoteDetail in DebitNotesDetail.PPMDebitNotesDetail)
                    //{
                    //    Save_FabricDebitNoteDetail(objDebitNoteDetail, cnx);
                    //}


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }

        public void Save_FabricDebitNote_Particulers(InlinePPMOrderContract DebitNotesDetails, int Scope_Identity)
        {
            string cmdText = "USP_InsertUpdate_DebitNotes_Particulers";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                    
                    SqlParameter param;
                    param = new SqlParameter("@Scope_Id", SqlDbType.Int);
                    param.Value = Scope_Identity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulers", SqlDbType.VarChar);
                    param.Value = DebitNotesDetails.Particulars;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Qty", SqlDbType.Int);
                    param.Value = DebitNotesDetails.Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Float);
                    param.Value = DebitNotesDetails.Rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
        public void Save_FabricCreditNote_Particulers(InlinePPMOrderContract DebitNotesDetails, int Scope_Identity)
        {
            string cmdText = "USP_InsertUpdate_CreditNotes_Particulers";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    SqlParameter param;
                    param = new SqlParameter("@Scope_Id", SqlDbType.Int);
                    param.Value = Scope_Identity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulers", SqlDbType.VarChar);
                    param.Value = DebitNotesDetails.Particulars;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Qty", SqlDbType.Int);
                    param.Value = DebitNotesDetails.Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Float);
                    param.Value = DebitNotesDetails.Rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = 1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
        public void Update_FabricDebitNote_Particulers(InlinePPMOrderContract DebitNotesDetails, int Debit_Note_ID, int DebitParticulersID)
        {
            string cmdText = "USP_Update_DebitNotes_Particulers";

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                try
                {
                    SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    SqlParameter param;
                    param = new SqlParameter("@Debit_Note_ID", SqlDbType.Int);
                    param.Value = Debit_Note_ID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulers", SqlDbType.VarChar);
                    param.Value = DebitNotesDetails.Particulars;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Qty", SqlDbType.Int);
                    param.Value = DebitNotesDetails.Quantity;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Float);
                    param.Value = DebitNotesDetails.Rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitParticulersID", SqlDbType.Int);
                    param.Value = DebitParticulersID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                //}
                cnx.Close();
            }

        }
        public int UpdateFabricDebitNote_Particulers(int PO_id, string Particulars, int qty, decimal rate, int ParticulersID, string Type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                
                int intReturn;
                cnx.Open();
                string cmdText = "USP_Update_Particulers";
                SqlCommand cmd = base.SqlCommand(cmdText, cnx, QueryType.Insert);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                    SqlParameter param;
                    param = new SqlParameter("@PO_Id", SqlDbType.Int);
                    param.Value = PO_id;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Particulers", SqlDbType.VarChar);
                    param.Value = Particulars;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Qty", SqlDbType.Int);
                    param.Value = qty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rate", SqlDbType.Float);
                    param.Value = rate;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DebitParticulersID", SqlDbType.Int);
                    param.Value = ParticulersID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                     intReturn= cmd.ExecuteNonQuery();
                     cnx.Close();
                     return intReturn;
                    
                }
        }
       

        public int DeleteDebinoteID(int DebinoteID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                int intReturn;
                cnx.Open();
                string cmdText = "USP_Delete_Particulers";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@DebitParticulersID", SqlDbType.Int);
                param.Value = DebinoteID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                intReturn = cmd.ExecuteNonQuery();
                cnx.Close();
                return intReturn;
            }
        }
        //Added By Ashish on 28/7/2015 
        public int OBWSSAMachieved(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                int Isachieved = 0;
                DataTable dtSAMachieved = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_OBWS_SAMachieved";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSAMachieved);

                if (dtSAMachieved.Rows.Count > 0)
                {
                    Isachieved = 1;
                }


                return Isachieved;
            }

        }


        //END

        public List<HOPPMOB> GetHOPPMRemarksTest(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dt = new DataSet();
                List<HOPPMOB> hoppmlist = new List<HOPPMOB>();
                List<MOOrderDetails> orderDetailCollection = new List<MOOrderDetails>();
                try
                {
                    string cmdText = "";
                    SqlCommand cmd;
                    cmdText = "Usp_GetHOPPMRemarks";
                    cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@StyleCode", SqlDbType.VarChar);
                    param.Value = StyleCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@styleid", SqlDbType.Int);
                    param.Value = styleid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientId", SqlDbType.Int);
                    param.Value = strClientId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentId", SqlDbType.Int);
                    param.Value = DepartmentId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateNew", SqlDbType.Int);
                    param.Value = CreateNew;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@NewRef", SqlDbType.Int);
                    param.Value = NewRef;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUse", SqlDbType.Int);
                    param.Value = ReUse;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReUseStyleId", SqlDbType.Int);
                    param.Value = ReUseStyleId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RemarksType", SqlDbType.VarChar);
                    param.Value = RemarksType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        HOPPMOB list = new HOPPMOB();
                        list.FabricRemarks = dt.Tables[0].Rows[i]["FabricRemark"].ToString();
                        list.MakingRemarks = dt.Tables[0].Rows[i]["RemarksBy"].ToString();

                        hoppmlist.Add(list);
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return hoppmlist;
            }
        }

        //Added By Ashish on 13/8/2015
        public DataTable GetStyleNumber(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetStyleNumber";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }

        public DataSet GetStyleClientAndDept(int StyleID, int ReUseStyleId, int ClientId, int DeptID, int CreateNew, int NewRef, int ReUse, int Tab)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsStyle = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetStyleClientAndDept";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Styleid", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUseStyleid", SqlDbType.Int);
                param.Value = ReUseStyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DeptId", SqlDbType.Int);
                param.Value = DeptID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateNew", SqlDbType.Int);
                param.Value = CreateNew;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NewRef", SqlDbType.Int);
                param.Value = NewRef;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ReUse", SqlDbType.Int);
                param.Value = ReUse;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Tab", SqlDbType.Int);
                param.Value = Tab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsStyle);

                return dsStyle;
            }
        }


        //Added By abhishek  on 21/10/2015
        public DataTable Hoppm_OBComplete_Check(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "select isnull(tblhoppm.ishoppmcomplete,0) from tblhoppm where styleid=" + StyleID;
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }
        //end by abhishek on 21/10/2015

        public DataTable GetPackingListSizeDetails(int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }

        public DataTable GetPackingListQuantityDetails(int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }

        public DataTable GetValueAdditionDetails(int OrderDetailId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 3;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }
        public DataTable GetValueAdditionDetailss(int OrderDetailId,int vaid)
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();
            DataTable dsRiskAnalysis = new DataTable();
            SqlCommand cmd;
            string cmdText;

            cmdText = "Usp_GetPackingListDetails";
            cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter

            param = new SqlParameter("@inType", SqlDbType.Int);
            param.Value = 16;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
            param.Value = OrderDetailId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ValueAdditionID", SqlDbType.Int);
            param.Value = vaid;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dsRiskAnalysis);

            return dsRiskAnalysis;
          }
        }
        public int GetValueAddQty(int OrderDetailId, int SizeId, int ValueAdditionId, int UnitId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 4;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SizeId", SqlDbType.Int);
                param.Value = SizeId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ValueAdditionID", SqlDbType.Int);
                param.Value = ValueAdditionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                intReturn = Convert.ToInt32(cmd.ExecuteScalar());
                cnx.Close();

                return intReturn;
            }
        }

        public DataTable GetValueAdditionHistoryDetails(int OrderDetailId, int UnitId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 5;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsRiskAnalysis);

                return dsRiskAnalysis;
            }
        }

        public int GetValueAddQtyHistory(int OrderDetailId, int ValueAdditionId, DateTime Date, int UnitId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 6;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                param.Value = OrderDetailId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //param = new SqlParameter("@SizeId", SqlDbType.Int);
                //param.Value = SizeId;
                //param.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(param);

                param = new SqlParameter("@ValueAdditionID", SqlDbType.Int);
                param.Value = ValueAdditionId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                param.Value = Date;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                intReturn = Convert.ToInt32(cmd.ExecuteScalar());
                cnx.Close();

                return intReturn;
            }
        }

        public string GetUnitName(int UnitId)
        {
            string sReturn = "";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable dsRiskAnalysis = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Usp_GetPackingListDetails";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@inType", SqlDbType.Int);
                param.Value = 7;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = UnitId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                sReturn = Convert.ToString(cmd.ExecuteScalar());
                cnx.Close();

                return sReturn;
            }
        }

        public int UpdateQty(int OrderDetailId, int ValueAddQty, int ValueAdditionId, int UnitId)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_UpdateValueAddition_New";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@SizeId", SqlDbType.Int);
                    //param.Value = SizeId;
                    //param.Direction = ParameterDirection.Input;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@ValueAdditionID", SqlDbType.Int);
                    param.Value = ValueAdditionId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ValueAddQty", SqlDbType.Int);
                    param.Value = ValueAddQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
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

        public int UpdateQtywithflag(int OrderDetailId, int ValueAddQty, int ValueAdditionId, int UnitId, string flag, string val)
        {
          int intReturn = 0;
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            try
            {
              cnx.Open();
              string cmdText = "";
              cmdText = "Usp_UpdateValueAddition_New_flag";
              SqlCommand cmd = new SqlCommand(cmdText, cnx);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
              SqlParameter param;

              param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
              param.Value = OrderDetailId;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              //param = new SqlParameter("@SizeId", SqlDbType.Int);
              //param.Value = SizeId;
              //param.Direction = ParameterDirection.Input;
              //cmd.Parameters.Add(param);

              param = new SqlParameter("@ValueAdditionID", SqlDbType.Int);
              param.Value = ValueAdditionId;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@ValueAddQty", SqlDbType.Int);
              param.Value = ValueAddQty;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@UnitId", SqlDbType.Int);
              param.Value = UnitId;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@Flag", SqlDbType.VarChar);
              param.Value = flag;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);


              param = new SqlParameter("@val", SqlDbType.VarChar);
              param.Value = val;
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

        //added by raghvinder on 03-09-2020 start
        public DataSet Get_Reallocation_History(int StyleId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataSet ds_History = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "usp_GetReallocation_History";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@StyleId", SqlDbType.Int);
                param.Value = StyleId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds_History);

                return ds_History;
            }
        }

        //added by raghvinder on 03-09-2020 end


        public DataTable Get_OBOperations_History(int StyleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                DataTable OBOperations_HistoryDetails = new DataTable();
                SqlCommand cmd;
                string cmdText;

                cmdText = "Get_OBOperations_History";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter

                param = new SqlParameter("@StyleID", SqlDbType.Int);
                param.Value = StyleID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(OBOperations_HistoryDetails);

                return OBOperations_HistoryDetails;
            }
        }
        
        
   //this code added by bharat on 3-july 
        public DataSet Get_FabricFinish_details(int QualityId, int OrderDetail, string FabricDetails)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dsAmFabricPerformanceRe = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_AM_Fabric_Report";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Fabric_QualityID", SqlDbType.Int);
                param.Value = QualityId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetail;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FabricDetails", SqlDbType.VarChar);
                param.Value = FabricDetails;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAmFabricPerformanceRe);

                return dsAmFabricPerformanceRe;
            }

        }


        //new code 12 feb 2020 start

        public string[] GetCMTCalcualtor(int Quantity, float SAM1, int OB, float Eff, DateTime StartDate, string flag)
        {
            Costing objCosting = new Costing();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
               
                cnx.Open();

                DataSet dsAmFabricPerformanceRe = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_CMT_Autocalcualtion";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param = new SqlParameter("@Quantity", SqlDbType.Int);
                param.Value = Quantity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@OB", SqlDbType.Int);
                param.Value = OB;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SAM", SqlDbType.Float);
                param.Value = SAM1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Eff", SqlDbType.Float);
                param.Value = Eff;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StartDate", SqlDbType.DateTime);
                param.Value = StartDate;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                //new flag
                param = new SqlParameter("@FlangChange", SqlDbType.VarChar);
                param.Value = flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsAmFabricPerformanceRe);

                objCosting.EndDate = dsAmFabricPerformanceRe.Tables[0].Rows[0]["EndDate"].ToString();
                //objCosting.EndDate = Convert.ToDateTime(dsAmFabricPerformanceRe.Tables[0].Rows[0]["EndDate"].ToString());
                objCosting.Eff = Convert.ToDouble(dsAmFabricPerformanceRe.Tables[0].Rows[0]["EFF"].ToString());
                objCosting.PcsPerHrs = Convert.ToInt32(dsAmFabricPerformanceRe.Tables[0].Rows[0]["PcsPerHr"].ToString());
                objCosting.NoOfDays = Convert.ToDouble(dsAmFabricPerformanceRe.Tables[0].Rows[0]["NoOfDays"].ToString());
                objCosting.PcsPerDay = Convert.ToInt32(dsAmFabricPerformanceRe.Tables[0].Rows[0]["PcsPerDay"].ToString());
                objCosting.Holidays = Convert.ToInt32(dsAmFabricPerformanceRe.Tables[0].Rows[0]["Holidays"].ToString());

            }
            string[] returnString = new string[] { objCosting.EndDate.ToString(), objCosting.Eff.ToString(), objCosting.PcsPerHrs.ToString(), objCosting.NoOfDays.ToString(), objCosting.PcsPerDay.ToString(), objCosting.Holidays.ToString()};
            return returnString;

        }

        public DataSet GetCMTInfo(int OrderDetailID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                DataSet dscmt = new DataSet();
                SqlCommand cmd;
                string cmdText;

                cmdText = "USP_Get_CMT_Autocalcualtion";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                
                SqlParameter param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                param.Value = OrderDetailID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dscmt);

                return dscmt;
            }

        }

        //new code 12 feb 2020 end

        public int UpdateValueAddition(int OrderDetailId, int ValueAdditionId, int ValueAddQty, int ManPower, int QCId, int CheckerId, int UnitId, bool IsComplete, int UserID)
        {
            int intReturn = 0;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    cnx.Open();
                    string cmdText = "";
                    cmdText = "Usp_UpdateValueAddition";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ValueAdditionID", SqlDbType.Int);
                    param.Value = ValueAdditionId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ValueAddQty", SqlDbType.Int);
                    param.Value = ValueAddQty;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ManPower", SqlDbType.Int);
                    param.Value = ManPower;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@QCId", SqlDbType.Int);
                    param.Value = QCId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CheckerId", SqlDbType.Int);
                    param.Value = CheckerId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = UnitId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@IsComplete", SqlDbType.Bit);
                    param.Value = IsComplete;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserID;
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
      

    }
}
