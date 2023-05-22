using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using iKandi.Common;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    public class FinancialDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public FinancialDataProvider(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }

        #endregion

        #region Methods

        #region GetSupplierGroupDueListTemp
        /// <summary>
        /// Get All Supplier Dues on SupplierGroup
        /// </summary>
        /// <returns></returns>
        public ListFosp GetSupplierGroupDueListTemp()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetSupplierGroupDueList";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataReader reader = cmd.ExecuteReader();

                ListFosp lfosp = new ListFosp();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FabricOutStandingPayments fosp = new FabricOutStandingPayments();
                        fosp.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                        fosp.SupplierGroup = reader["GroupName"] == DBNull.Value ? "" : Convert.ToString(reader["GroupName"]);
                        fosp.Delayed = reader["Delayed"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Delayed"]);
                        fosp.CurrentDue = reader["CurrentDue"] == DBNull.Value ? 0 : Convert.ToDouble(reader["CurrentDue"]);
                        fosp.NextDue = reader["NextDue"] == DBNull.Value ? 0 : Convert.ToDouble(reader["NextDue"]);
                        fosp.PoType = reader["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PoTypeId"]);
                        fosp.SuggestedAmount = reader["SuggestedAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["SuggestedAmount"]);
                        fosp.AuthorizedAmount = reader["AuthorizedAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["AuthorizedAmount"]);
                        fosp.PaidAmount = reader["PaidAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["PaidAmount"]);
                        fosp.SuggestedDate = (reader["SuggestedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SuggestedDate"]);
                        fosp.AuthorizedDate = (reader["AuthorizedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AuthorizedDate"]);
                        fosp.PaidDate = (reader["PaidDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PaidDate"]);
                        fosp.TotalDue = fosp.Delayed + fosp.CurrentDue;
                        fosp.Exposure = fosp.Delayed + fosp.CurrentDue + fosp.NextDue;
                        fosp.FF2Id = reader["FF2Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FF2Id"]);
                        fosp.FF1Id = reader["FF1Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FF1Id"]);
                        fosp.FF2SAmount = reader["FF2SAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["FF2SAmount"]);
                        fosp.FF2SDate = reader["FF2SDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FF2SDate"]);
                        fosp.FF2AAmount = reader["FF2AAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["FF2AAmount"]);
                        fosp.FF2ADate = reader["FF2ADate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FF2ADate"]);
                        fosp.FF2PAmount = reader["FF2PAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["FF2PAmount"]);
                        fosp.FF2PDate = reader["FF2PDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FF2PDate"]);
                        if (fosp.FF1Id == fosp.FF2Id)
                        {
                            fosp.FF1SAmount = fosp.FF2Id != 0 ? 0 : fosp.Exposure;
                            fosp.FF1SDate = DateTime.Now;
                            fosp.FF1AAmount = 0;
                            fosp.FF1ADate = DateTime.Now;
                            fosp.FF1PAmount = 0;
                            fosp.FF1PDate = DateTime.Now;
                        }
                        else
                        {
                            fosp.FF1SAmount = reader["FF1SAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1SAmount"]);
                            if (fosp.FF1SAmount > 0)
                                fosp.FF1SDate = reader["FF1SDate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1SDate"]);
                            else
                                fosp.FF1SDate = DateTime.Now;
                            fosp.FF1AAmount = reader["FF1SAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1SAmount"]);
                            if (fosp.FF1AAmount > 0)
                                fosp.FF1ADate = reader["FF1ADate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1ADate"]);
                            else
                                fosp.FF1ADate = DateTime.Now;
                            fosp.FF1PAmount = reader["FF1PAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1PAmount"]);
                            if (fosp.FF1PAmount > 0)
                                fosp.FF1PDate = reader["FF1PDate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1PDate"]);
                            else
                                fosp.FF1PDate = DateTime.Now;
                        }
                        //fosp.Exposure -= fosp.FF2PAmount;
                        lfosp.Add(fosp);
                    }
                    return lfosp;
                }
            }
            return null;
        }
        #endregion

        #region GetSupplierGroupDueList
        /// <summary>
        /// Get All Supplier Dues on SupplierGroup
        /// </summary>
        /// <returns></returns>
        public ListFosp GetSupplierGroupDueList()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetSupplierGroupDueList";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlDataReader reader = cmd.ExecuteReader();

                ListFosp lfosp = new ListFosp();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FabricOutStandingPayments fosp = new FabricOutStandingPayments();
                        fosp.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                        fosp.SupplierGroup = reader["GroupName"] == DBNull.Value ? "" : Convert.ToString(reader["GroupName"]);
                        fosp.DAmount = reader["DAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["DAmount"]);
                        fosp.CAmount = reader["CAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["CAmount"]);
                        fosp.NAmount = reader["NAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["NAmount"]);
                        fosp.Delayed = reader["Delayed"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Delayed"]);
                        fosp.CurrentDue = reader["CurrentDue"] == DBNull.Value ? 0 : Convert.ToDouble(reader["CurrentDue"]);
                        fosp.NextDue = reader["NextDue"] == DBNull.Value ? 0 : Convert.ToDouble(reader["NextDue"]);
                        fosp.PoType = reader["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PoTypeId"]);
                        fosp.SuggestedAmount = reader["SuggestedAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["SuggestedAmount"]);
                        fosp.AuthorizedAmount = reader["AuthorizedAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["AuthorizedAmount"]);
                        fosp.PaidAmount = reader["PaidAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["PaidAmount"]);
                        fosp.SuggestedDate = (reader["SuggestedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["SuggestedDate"]);
                        fosp.AuthorizedDate = (reader["AuthorizedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["AuthorizedDate"]);
                        fosp.PaidDate = (reader["PaidDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["PaidDate"]);
                        fosp.TotalDue = fosp.Delayed + fosp.CurrentDue;
                        fosp.Exposure = fosp.Delayed + fosp.CurrentDue + fosp.NextDue;
                        fosp.FF2Id = reader["FF2Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FF2Id"]);
                        fosp.FF1Id = reader["FF1Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FF1Id"]);
                        fosp.FF2SAmount = reader["FF2SAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["FF2SAmount"]);
                        fosp.FF2SDate = reader["FF2SDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FF2SDate"]);
                        fosp.FF2AAmount = reader["FF2AAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["FF2AAmount"]);
                        fosp.FF2ADate = reader["FF2ADate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FF2ADate"]);
                        fosp.FF2PAmount = reader["FF2PAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["FF2PAmount"]);
                        fosp.FF2PDate = reader["FF2PDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FF2PDate"]);
                        if (fosp.FF1Id == fosp.FF2Id)
                        {
                            fosp.FF1SAmount = fosp.FF2Id != 0 ? 0 : fosp.Exposure;
                            fosp.FF1SDate = DateTime.Now;
                            fosp.FF1AAmount = 0;
                            fosp.FF1ADate = DateTime.Now;
                            fosp.FF1PAmount = 0;
                            fosp.FF1PDate = DateTime.Now;
                        }
                        else
                        {
                            fosp.FF1SAmount = reader["FF1SAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1SAmount"]);
                            if (fosp.FF1SAmount > 0)
                                fosp.FF1SDate = reader["FF1SDate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1SDate"]);
                            else
                                fosp.FF1SDate = DateTime.Now;
                            fosp.FF1AAmount = reader["FF1SAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1SAmount"]);
                            if (fosp.FF1AAmount > 0)
                                fosp.FF1ADate = reader["FF1ADate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1ADate"]);
                            else
                                fosp.FF1ADate = DateTime.Now;
                            fosp.FF1PAmount = reader["FF1PAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1PAmount"]);
                            if (fosp.FF1PAmount > 0)
                                fosp.FF1PDate = reader["FF1PDate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1PDate"]);
                            else
                                fosp.FF1PDate = DateTime.Now;
                        }
                        //fosp.Exposure -= fosp.FF2PAmount;
                        lfosp.Add(fosp);
                    }
                    //if(lfosp.Count<1)
                    //    return lfosp;
                    //foreach (FabricOutStandingPayments fosp in lfosp)
                    //{
                    //    if (fosp.FF2PAmount > 0 && fosp.DAmount > 0)
                    //        fosp.Delayed = Math.Abs(fosp.DAmount - fosp.FF2PAmount);
                    //    else
                    //        fosp.Delayed = fosp.DAmount;
                    //    if (fosp.FF2PAmount > 0 && (fosp.DAmount+fosp.CAmount) > 0 && fosp.FF2PAmount > fosp.DAmount)
                    //        fosp.CurrentDue = Math.Abs(fosp.DAmount + fosp.CAmount - fosp.FF2PAmount);
                    //    else
                    //        fosp.CurrentDue = fosp.CAmount;
                    //    if (fosp.FF2PAmount > 0 && (fosp.DAmount + fosp.CAmount + fosp.DAmount) > 0 && fosp.FF2PAmount > (fosp.DAmount + fosp.CAmount))
                    //        fosp.Delayed = Math.Abs(fosp.DAmount + fosp.CAmount + fosp.CAmount - fosp.FF2PAmount);
                    //    else
                    //        fosp.Delayed = fosp.NAmount;
                    //}
                    return lfosp;
                }
            }
            return null;
        }
        #endregion

        #region GetSupplierGroupDueListByLevel
        /// <summary>
        /// Get All Supplier Dues on SupplierGroup
        /// </summary>
        /// <returns></returns>
        public ListFosp GetSupplierGroupDueListByLevel(int level)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetSupplierGroupDueListByLevel";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@Level", SqlDbType.Int);
                param.Value = level;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                ListFosp lfosp = new ListFosp();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FabricOutStandingPayments fosp = new FabricOutStandingPayments();
//                        fosp.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                        fosp.Id = reader["ff1Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ff1Id"]);
                        fosp.SupplierGroup = reader["GroupName"] == DBNull.Value
                                                 ? ""
                                                 : Convert.ToString(reader["GroupName"]);
                        fosp.DAmount = reader["DAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["DAmount"]);
                        fosp.CAmount = reader["CAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["CAmount"]);
                        fosp.NAmount = reader["NAmount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["NAmount"]);
                        fosp.Delayed = reader["Delayed"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Delayed"]);
                        fosp.CurrentDue = reader["CurrentDue"] == DBNull.Value
                                              ? 0
                                              : Convert.ToDouble(reader["CurrentDue"]);
                        fosp.NextDue = reader["NextDue"] == DBNull.Value ? 0 : Convert.ToDouble(reader["NextDue"]);
                        fosp.PoType = reader["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PoTypeId"]);
                        fosp.SuggestedAmount = reader["SuggestedAmount"] == DBNull.Value
                                                   ? 0
                                                   : Convert.ToDouble(reader["SuggestedAmount"]);
                        fosp.AuthorizedAmount = reader["AuthorizedAmount"] == DBNull.Value
                                                    ? 0
                                                    : Convert.ToDouble(reader["AuthorizedAmount"]);
                        fosp.PaidAmount = reader["PaidAmount"] == DBNull.Value
                                              ? 0
                                              : Convert.ToDouble(reader["PaidAmount"]);
                        fosp.SuggestedDate = (reader["SuggestedDate"] == DBNull.Value)
                                                 ? DateTime.MinValue
                                                 : Convert.ToDateTime(reader["SuggestedDate"]);
                        fosp.AuthorizedDate = (reader["AuthorizedDate"] == DBNull.Value)
                                                  ? DateTime.MinValue
                                                  : Convert.ToDateTime(reader["AuthorizedDate"]);
                        fosp.PaidDate = (reader["PaidDate"] == DBNull.Value)
                                            ? DateTime.MinValue
                                            : Convert.ToDateTime(reader["PaidDate"]);
                        fosp.TotalDue = fosp.Delayed + fosp.CurrentDue;
                        fosp.Exposure = fosp.Delayed + fosp.CurrentDue + fosp.NextDue;
                        fosp.FF2Id = reader["FF2Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FF2Id"]);
                        fosp.FF1Id = reader["FF1Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["FF1Id"]);
                        fosp.FF2SAmount = reader["FF2SAmount"] == DBNull.Value
                                              ? 0
                                              : Convert.ToDouble(reader["FF2SAmount"]);
                        fosp.FF2SDate = reader["FF2SDate"] == DBNull.Value
                                            ? DateTime.MinValue
                                            : Convert.ToDateTime(reader["FF2SDate"]);
                        fosp.FF2AAmount = reader["FF2AAmount"] == DBNull.Value
                                              ? 0
                                              : Convert.ToDouble(reader["FF2AAmount"]);
                        fosp.FF2ADate = reader["FF2ADate"] == DBNull.Value
                                            ? DateTime.MinValue
                                            : Convert.ToDateTime(reader["FF2ADate"]);
                        fosp.FF2PAmount = reader["FF2PAmount"] == DBNull.Value
                                              ? 0
                                              : Convert.ToDouble(reader["FF2PAmount"]);
                        fosp.FF2PDate = reader["FF2PDate"] == DBNull.Value
                                            ? DateTime.MinValue
                                            : Convert.ToDateTime(reader["FF2PDate"]);
                        if (fosp.FF1Id == fosp.FF2Id)
                        {
                            //fosp.FF1SAmount = fosp.FF2Id != 0 ? 0 : fosp.Exposure;
                            fosp.FF1SAmount = 0;
                            fosp.FF1SDate = DateTime.Now;
                            fosp.FF1AAmount = 0;
                            fosp.FF1ADate = DateTime.Now;
                            fosp.FF1PAmount = 0;
                            fosp.FF1PDate = DateTime.Now;
                        }
                        else
                        {
                            fosp.FF1SAmount = reader["FF1SAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1SAmount"]);
                            if (fosp.FF1SAmount > 0)
                                fosp.FF1SDate = reader["FF1SDate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1SDate"]);
                            else
                                fosp.FF1SDate = DateTime.Now;
                            fosp.FF1AAmount = reader["FF1AAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1AAmount"]);
                            if (fosp.FF1AAmount > 0)
                                fosp.FF1ADate = reader["FF1ADate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1ADate"]);
                            else
                                fosp.FF1ADate = DateTime.Now;
                            fosp.FF1PAmount = reader["FF1PAmount"] == DBNull.Value
                                                  ? 0
                                                  : Convert.ToDouble(reader["FF1PAmount"]);
                            if (fosp.FF1PAmount > 0)
                                fosp.FF1PDate = reader["FF1PDate"] == DBNull.Value
                                                    ? DateTime.MinValue
                                                    : Convert.ToDateTime(reader["FF1PDate"]);
                            else
                                fosp.FF1PDate = DateTime.Now;
                        }
                       // fosp.Exposure -= fosp.FF2PAmount;
                        lfosp.Add(fosp);
                    }
                    //if(lfosp.Count<1)
                    //    return lfosp;
                    //foreach (FabricOutStandingPayments fosp in lfosp)
                    //{
                    //    if (fosp.FF2PAmount > 0 && fosp.DAmount > 0)
                    //        fosp.Delayed = Math.Abs(fosp.DAmount - fosp.FF2PAmount);
                    //    else
                    //        fosp.Delayed = fosp.DAmount;
                    //    if (fosp.FF2PAmount > 0 && (fosp.DAmount+fosp.CAmount) > 0 && fosp.FF2PAmount > fosp.DAmount)
                    //        fosp.CurrentDue = Math.Abs(fosp.DAmount + fosp.CAmount - fosp.FF2PAmount);
                    //    else
                    //        fosp.CurrentDue = fosp.CAmount;
                    //    if (fosp.FF2PAmount > 0 && (fosp.DAmount + fosp.CAmount + fosp.DAmount) > 0 && fosp.FF2PAmount > (fosp.DAmount + fosp.CAmount))
                    //        fosp.Delayed = Math.Abs(fosp.DAmount + fosp.CAmount + fosp.CAmount - fosp.FF2PAmount);
                    //    else
                    //        fosp.Delayed = fosp.NAmount;
                    //}
                    return lfosp;
                }
            }
            return null;
        }
        #endregion

        #region GetSupplierDueList
        /// <summary>
        /// Get All Supplier Dues on suppliername
        /// </summary>
        /// <returns></returns>
        public ListSdl GetSupplierDueList(string supplierGroup, int poType, int fortNight)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetSupplierDueList";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                param.Value = supplierGroup;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoType", SqlDbType.Int);
                param.Value = poType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FortNight", SqlDbType.Int);
                param.Value = fortNight;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                if (dsFabric.Tables.Count < 1 || dsFabric.Tables[0].Rows.Count < 1)
                    return null;
                
                ListSdl lfosp = GetSdlFromTable(dsFabric.Tables[0], 1);
                return lfosp;
            }
        }

        public SupplierSettleMent GetSsDueList(int fpId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetSSDueList";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@FopId", SqlDbType.VarChar);
                param.Value = fpId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                if (dsFabric.Tables.Count < 1 || dsFabric.Tables[0].Rows.Count < 1)
                    return null;

                SupplierSettleMent ssm = new SupplierSettleMent();

                DataRow dr = dsFabric.Tables[0].Rows[0];
                ssm.SupplierGroup = dr["SupplierGroupName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierGroupName"]);
                ssm.AuthorizedAmount = dr["AuthorizedAmount"] == DBNull.Value ? 0 : Convert.ToDouble(dr["AuthorizedAmount"]);
                ssm.SuggestedAmount = dr["SuggestedAmount"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SuggestedAmount"]);
                ssm.PaidAmount = dr["PaidAmount"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PaidAmount"]);
                ssm.PoTypeId = dr["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PoTypeId"]);
                ssm.Id = fpId;

                if (dsFabric.Tables.Count < 2 || dsFabric.Tables[1].Rows.Count < 1)
                    ssm.LSdl = null;
                else
                {
                    ssm.LSdl = GetSdlFromTable(dsFabric.Tables[1], 2);
                    //ListSdl lsdl = GetSdlFromTable(dsFabric.Tables[1], 2);
                    double sum = (from r in ssm.LSdl where r.TType == "DBT" select r.ClaimedAmount).Sum();
                    double aamount = ssm.AuthorizedAmount + sum;
                    if(aamount>0)
                    {
                        foreach (SupplierDueList sdl in ssm.LSdl)
                        {
                            if(sdl.TType!="DBT" && aamount>0 && sdl.ApprovedAmount!=0)
                            {
                                if (sdl.ClaimedAmount < aamount)
                                {
                                    sdl.SuggestedAmount = sdl.ClaimedAmount;
                                    aamount -= sdl.SuggestedAmount;
                                }
                                else
                                {
                                    sdl.SuggestedAmount = aamount;
                                    aamount = 0;
                                }
                                if(sdl.SuggestedAmount==sdl.ClaimedAmount)
                                    sdl.Clearance = "Complete";
                                else
                                    sdl.Clearance = "Partial";
                            }
                            if(sdl.TType=="DBT")
                            {
                                sdl.SuggestedAmount = sdl.ClaimedAmount;
                            }
                        }
                    }
                }
                return ssm;
            }
        }

        public ListSdl GetSdlFromTable(DataTable dt, int flag)
        {
            ListSdl lfosp = new ListSdl();
            foreach (DataRow dr in dt.Rows)
            {
                SupplierDueList fosp = new SupplierDueList();
                fosp.SupplierGroup = dr["GroupName"] == DBNull.Value ? "" : Convert.ToString(dr["GroupName"]);
                fosp.SrvId = dr["SrvId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SrvId"]);
                fosp.PoId = dr["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PoId"]);
                fosp.SupplierId = dr["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierId"]);
                fosp.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierName"]);
                fosp.BillNo = dr["BillNo"] == DBNull.Value ? "" : Convert.ToString(dr["BillNo"]);
                fosp.BillDate = (dr["BillDate"] == DBNull.Value)
                                    ? DateTime.MinValue
                                    : Convert.ToDateTime(dr["BillDate"]);
                fosp.Amount = dr["Amount"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Amount"]);
                fosp.PoType = dr["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PoTypeId"]);
                fosp.LeadDate = (dr["LeadDate"] == DBNull.Value)
                                    ? DateTime.MinValue
                                    : Convert.ToDateTime(dr["LeadDate"]);
                fosp.SuggestedAmount = 0;
                if (flag == 2)
                {

                    fosp.TType = dr["TType"] == DBNull.Value ? "" : Convert.ToString(dr["TType"]).Trim().ToUpper();
                    fosp.ApprovedAmount = dr["AmountApproved"] == DBNull.Value ? 0 : Convert.ToDouble(dr["AmountApproved"]);
                    fosp.ClaimedAmount = dr["AmountClaimed"] == DBNull.Value ? 0 : Convert.ToDouble(dr["AmountClaimed"]);
                    //if (fosp.SuggestedAmount == fosp.Amount && fosp.Amount != 0)
                    //    fosp.Clearance = "Complete";
                    //else
                    //    fosp.Clearance = "Partial";
                }
                lfosp.Add(fosp);
            }
            return lfosp;
        }
        #endregion

        #region GetSrvBySupplierGroup
        /// <summary>
        /// Get All Srvs related with suppliergroup
        /// </summary>
        /// <param name="supplierGroup"></param>
        /// <returns></returns>
        public ListSrvBill GetSrvBySupplierGroup(string supplierGroup)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetSrvBySupplierGroup";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                param.Value = supplierGroup;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                if(dsFabric.Tables.Count<1 || dsFabric.Tables[0].Rows.Count<1)
                    return null;

                return GetSrvList(dsFabric.Tables[0]);
            }
        }
        #endregion

        #region GetPendingSrvBySrvId
        /// <summary>
        /// Get All Srvs related with suppliergroup
        /// </summary>
        /// <param name="supplierGroup"></param>
        /// <returns></returns>
        public ListSrvBill GetPendingSrvBySrvId(int srvId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetPendingSrvBySrvId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = srvId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                if(dsFabric.Tables.Count<1 || dsFabric.Tables[0].Rows.Count<1)
                    return null;

                return GetSrvList(dsFabric.Tables[0]);
            }
        }
        #endregion

        #region GetSupplierGroupBySrvId
        /// <summary>
        /// Get All Srvs related with suppliergroup
        /// </summary>
        /// <param name="supplierGroup"></param>
        /// <returns></returns>
        public string GetSupplierGroupBySrvId(int srvId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetSupplierGroupBySrvId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SrvId", SqlDbType.Int);
                param.Value = srvId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter oparam = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                oparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oparam);

                cmd.ExecuteNonQuery();

                string sgroup = oparam.Value == DBNull.Value ? "" : Convert.ToString(oparam.Value);
                return sgroup;
            }
        }
        #endregion

        #region GetSupplierGroupBySrvBillId
        /// <summary>
        /// Get All Srvs related with suppliergroup
        /// </summary>
        /// <param name="supplierGroup"></param>
        /// <returns></returns>
        public string GetSupplierGroupBySrvBillId(int sbId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetSupplierGroupBySrvBillId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SbId", SqlDbType.Int);
                param.Value = sbId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter oparam = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                oparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oparam);

                cmd.ExecuteNonQuery();

                string sgroup = oparam.Value == DBNull.Value ? "" : Convert.ToString(oparam.Value);
                return sgroup;
            }
        }
        #endregion

        #region GetSrvList
        public ListSrvBill GetSrvList(DataTable dt)
        {
            ListSrvBill lfosp = new ListSrvBill();
            foreach (DataRow dr in dt.Rows)
            {
                SrvBill fosp = new SrvBill();
                fosp.SupplierGroupName = dr["groupname"] == DBNull.Value ? "" : Convert.ToString(dr["groupname"]);
                fosp.SupplierId = dr["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierId"]);
                fosp.SupplierName = dr["suppliername"] == DBNull.Value ? "" : Convert.ToString(dr["suppliername"]);
                fosp.SrvId = dr["SrvId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SrvId"]);
                fosp.SrvNo = dr["srvno"] == DBNull.Value ? "" : Convert.ToString(dr["srvno"]);
                fosp.SrvDate = (dr["SrvDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["SrvDate"]);
                fosp.ChallanNo = dr["ChallanNo"] == DBNull.Value ? "" : Convert.ToString(dr["ChallanNo"]);
                fosp.ChallanDate = (dr["ChallanDate"] == DBNull.Value)
                                       ? DateTime.MinValue
                                       : Convert.ToDateTime(dr["ChallanDate"]);
                fosp.BillNo = dr["BillNo"] == DBNull.Value ? "" : Convert.ToString(dr["BillNo"]);
                fosp.BillDate = (dr["BillDate"] == DBNull.Value)
                                    ? DateTime.MinValue
                                    : Convert.ToDateTime(dr["BillDate"]);
                fosp.Unit = (dr["Unit"] == DBNull.Value) ? "" : Convert.ToString(dr["Unit"]);
                fosp.ClaimedQty = dr["ClaimedQty"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ClaimedQty"]);
                fosp.PoId = dr["PoId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PoId"]);
                fosp.PoType = dr["PoTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PoTypeId"]);
                fosp.PoNumber = dr["PoNumber"] == DBNull.Value ? "" : Convert.ToString(dr["PoNumber"]);
                lfosp.Add(fosp);
            }
            return lfosp;
        }
        #endregion

        #region GetSrvListByBillId
        public SrvBillDetail GetSrvListByBillId(int billId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetSrvByBillId";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@BillId", SqlDbType.VarChar);
                param.Value = billId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                if (dsFabric.Tables.Count < 1 || dsFabric.Tables[0].Rows.Count < 1)
                    return null;
                SrvBillDetail sbd = new SrvBillDetail();
                DataRow dr = dsFabric.Tables[0].Rows[0];
                sbd.BillNo = GetString(dr["BillNo"]);
                sbd.Id = billId;
                sbd.PoId = GetInt(dr["PoId"]);
                sbd.PoNumber = GetString(dr["ponumber"]);
                sbd.SupplierGroup = GetString(dr["SupplierGroup"]);
                sbd.lSrvBill = new ListSrvBill();
                if (dsFabric.Tables.Count < 2 || dsFabric.Tables[1].Rows.Count < 1)
                    return sbd;
                sbd.lSrvBill = GetSrvList(dsFabric.Tables[1]);
                return sbd;
                //return GetSrvList(dsFabric.Tables[0]);
            }
        }
        #endregion

        #region InsertIntoSrvBill
        public int InsertIntoSrvBill(int poid,string suppliergroup,int createdby,string srvids)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlTransaction trnx = cnx.BeginTransaction();
                try
                {
                    const string cmdText = "sp_InsertSrvBill";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@PoId", SqlDbType.VarChar);
                    param.Value = poid;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                    param.Value = suppliergroup;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Srvs", SqlDbType.VarChar);
                    param.Value = srvids;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.VarChar);
                    param.Value = createdby;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter oparam = new SqlParameter("@SrvBillId", SqlDbType.Int);
                    oparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(oparam);

                    cmd.ExecuteNonQuery();
                    trnx.Commit();
                    return Convert.ToInt32(oparam.Value);
                }catch(Exception ex)
                {
                    trnx.Rollback();
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    return -1;
                }
            }
        }
        #endregion

        #region GetSrvDetailBySupplierGroup
        public DataSet GetSrvDetailBySupplierGroup(string suppliergroup)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_GetSrvDetailBySupplierGroup";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                param.Value = suppliergroup;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabric = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabric);

                return dsFabric;
            }
        }
        #endregion

        #region GetSBDetailListByBillId
        public ListSbDetail GetSBDetailListBySupplierGroup(string supplierGroup,int level)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetSDListALLBySGroup";
                //switch (level)
                //{
                //    case 0:
                //        cmdText = "sp_GetSDListALLBySGroup";
                //        break;
                //    case -1:
                //        cmdText = "sp_GetSDListALLBySGroup";
                //        break;
                //    case 1:
                //        cmdText = "sp_GetSDListBySGFabric";
                //        break;
                //    case 2:
                //        cmdText = "sp_GetSDListBySGFinance";
                //        break;
                //}

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                param.Value = supplierGroup;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Level", SqlDbType.Int);
                param.Value = level;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    ListSbDetail lsbd = new ListSbDetail();
                    while (reader.Read())
                    {
                        SrvBillDetail sbd = new SrvBillDetail();
                        sbd.Id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]);
                        sbd.UserName = reader["UserName"] == DBNull.Value
                                                ? ""
                                                : Convert.ToString(reader["UserName"]);
                        sbd.Designation = reader["Designation"] == DBNull.Value
                                                ? ""
                                                : Convert.ToString(reader["Designation"]);
                        sbd.BillNo = reader["billno"] == DBNull.Value ? "" : Convert.ToString(reader["billno"]);
                        sbd.PoId = reader["poid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["poid"]);
                        sbd.PoNumber = reader["ponumber"] == DBNull.Value ? "" : Convert.ToString(reader["ponumber"]);
                        sbd.SupplierGroup = reader["suppliergroup"] == DBNull.Value
                                                ? ""
                                                : Convert.ToString(reader["suppliergroup"]);
                        sbd.PoType = reader["potypeid"] == DBNull.Value
                                               ? 0
                                               : Convert.ToInt32(reader["potypeid"]);

                        sbd.OrderType = reader["OrderType"] == DBNull.Value
                                               ? 0
                                               : Convert.ToInt32(reader["OrderType"]);

                        sbd.CurrencyUnit = reader["CurrencyUnit"] == DBNull.Value
                                               ? 0
                                               : Convert.ToInt32(reader["CurrencyUnit"]);
                        sbd.CurrencySymbol = reader["currencysymbol"] == DBNull.Value
                                                 ? ""
                                                 : Convert.ToString(reader["currencysymbol"]);
                        sbd.Rate = reader["Rate"] == DBNull.Value ? 0 : Convert.ToDouble(reader["rate"]);
                        sbd.PaymentTerms = reader["PaymentTerms"] == DBNull.Value
                                               ? 0
                                               : Convert.ToInt32(reader["PaymentTerms"]);
                        sbd.SrvIds = reader["SrvIds"] == DBNull.Value ? "" : Convert.ToString(reader["SrvIds"]);
                        sbd.SrvNos = reader["srvnos"] == DBNull.Value ? "" : Convert.ToString(reader["srvnos"]);
                        sbd.ClaimedQty = reader["ClaimedQty"] == DBNull.Value
                                             ? 0
                                             : Convert.ToDouble(reader["ClaimedQty"]);
                        sbd.Amount = reader["Amount"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Amount"]);
                        sbd.IsSample = reader["IsSample"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IsSample"]);
                        sbd.SbmId = reader["SbmId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SbmId"]);
                        sbd.SupplierBillNo = reader["SupplierBillNo"] == DBNull.Value
                                                 ? ""
                                                 : Convert.ToString(reader["SupplierBillNo"]);
                        sbd.SupplierBillDate = reader["SupplierBillDate"] == DBNull.Value
                                                   ? DateTime.MinValue
                                                   : Convert.ToDateTime(reader["SupplierBillDate"]);
                        sbd.ExtraBill = reader["ExtraBill"] == DBNull.Value ? 0 : Convert.ToDouble(reader["ExtraBill"]);
                        sbd.ScreenCost = reader["ScreenCost"] == DBNull.Value
                                             ? 0
                                             : Convert.ToDouble(reader["ScreenCost"]);

                        sbd.TotalAmount = sbd.Amount + sbd.ExtraBill + sbd.ScreenCost;

                        sbd.DeadLine = reader["DeadLine"] == DBNull.Value
                                           ? DateTime.MinValue
                                           : Convert.ToDateTime(reader["DeadLine"]);
                        sbd.Instruction = reader["Instruction"] == DBNull.Value
                                              ? ""
                                              : Convert.ToString(reader["Instruction"]);
                        sbd.FabricChecked = reader["FabricChecked"] == DBNull.Value
                                                ? 0
                                                : Convert.ToInt32(reader["FabricChecked"]);
                        sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                                                 ? 0
                                                 : Convert.ToInt32(reader["FinanceChecked"]);
                        sbd.FinanceDate = reader["FinanceDate"] == DBNull.Value
                                                  ? DateTime.MinValue
                                                  : Convert.ToDateTime(reader["FinanceDate"]);

                        sbd.FabricDate = reader["FabricDate"] == DBNull.Value
                                                ? DateTime.MinValue
                                                : Convert.ToDateTime(reader["FabricDate"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        //sbd.FinanceChecked = reader["FinanceChecked"] == DBNull.Value
                        //                        ? 0
                        //                        : Convert.ToInt32(reader["FinanceChecked"]);

                        lsbd.Add(sbd);
                    }
                    List<int> poList = new List<int>();
                    foreach (SrvBillDetail sbd in lsbd)
                    {
                        if (sbd.IsSample > 0)
                        {
                            if (poList.Contains(sbd.PoId))
                            {
                                sbd.IsSample = 0;
                                continue;
                            }
                            sbd.IsSample = 1;
                            poList.Add(sbd.PoId);
                        }
                    }
                    return lsbd;
                }
                return null;
            }
        }

        #endregion

        #region InsertIntoSrvBillManagement
        public void InsertIntoSrvBillManagement(ListSbDetail lsb)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_InsertSrvBillManagement";

                SqlTransaction trnx = cnx.BeginTransaction();
                try
                {
                    foreach (SrvBillManagement sbm in lsb)
                    {
                        SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        SqlParameter param = new SqlParameter("@SrvBillId", SqlDbType.VarChar);
                        param.Value = sbm.SrvBillId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@BillNo", SqlDbType.VarChar);
                        param.Value = sbm.SupplierBillNo;
                        param.Direction = ParameterDirection.Input; 
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@BillDate", SqlDbType.DateTime);
                        param.Value = sbm.SupplierBillDate;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Amount", SqlDbType.Float);
                        param.Value = sbm.Amount;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ExtraBill", SqlDbType.Float);
                        param.Value = sbm.ExtraBill;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ScreenCost", SqlDbType.Float);
                        param.Value = sbm.ScreenCost;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@DeadLine", SqlDbType.DateTime);
                        param.Value = sbm.DeadLine;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@nstruction", SqlDbType.VarChar);
                        param.Value = sbm.Instruction;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@FabricChecked", SqlDbType.Int);
                        param.Value = sbm.FabricChecked;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@FinanceChecked", SqlDbType.Int);
                        param.Value = sbm.FinanceChecked;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                        param.Value = sbm.CreatedBy;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@FabricDepttId", SqlDbType.Int);
                        param.Value = sbm.FabricDepttId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@FinanceDepttId", SqlDbType.Int);
                        param.Value = sbm.FinanceDepttId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Level", SqlDbType.Int);
                        param.Value = sbm.Level;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                    trnx.Commit();
                }
                catch (Exception)
                {
                    trnx.Rollback();
                }
            }
        }
        #endregion

        #region InsertIntoFinancialFop
        public void InsertIntoFinancialFop(ListFinancialFop lsb)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                const string cmdText = "sp_InsertFinancialFop";

                SqlTransaction trnx = cnx.BeginTransaction();
                try
                {
                    foreach (FinancialFop sbm in lsb)
                    {
                        SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        SqlParameter param = null;
                        param = new SqlParameter("@FopId", SqlDbType.Int);
                        param.Value = sbm.Id;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                        param.Value = sbm.SupplierGroup;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@DelayAmount", SqlDbType.Float);
                        param.Value = sbm.DelayAmount;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@CurFortNight", SqlDbType.Float);
                        param.Value = sbm.CurFortNight;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@NextFortNight", SqlDbType.Float);
                        param.Value = sbm.NextFortNight;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SuggestedAmount", SqlDbType.Float);
                        param.Value = sbm.SuggestedAmount;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@AuthorizedAmount", SqlDbType.Float);
                        param.Value = sbm.AuthorizedAmount;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@PaidAmount", SqlDbType.Float);
                        param.Value = sbm.PaidAmount;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@PoTypeId", SqlDbType.Int);
                        param.Value = sbm.PoTypeId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Level", SqlDbType.Int);
                        param.Value = sbm.Level;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                        param.Value = sbm.CreatedBy;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                    trnx.Commit();
                }
                catch (Exception)
                {
                    trnx.Rollback();
                }
            }
        }
        #endregion

        public int InsertIntoSupplierMainBill(SSMainBill ssMainBill)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_InsertSSmainBill";

                SqlTransaction trnx = cnx.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = null;
                    param = new SqlParameter("@SupplierGroup", SqlDbType.VarChar);
                    param.Value = ssMainBill.SupplierGroup;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AuthorizedAmount", SqlDbType.Float);
                    param.Value = ssMainBill.AuthorizedAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalPaidAmount", SqlDbType.Float);
                    param.Value = ssMainBill.TotalPaidAmount;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BillNo", SqlDbType.VarChar);
                    param.Value = ssMainBill.BillNo;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PoType", SqlDbType.Int);
                    param.Value = ssMainBill.PoType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@FopId", SqlDbType.Int);
                    param.Value = ssMainBill.FopId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                    param.Value = ssMainBill.CreatedBy;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    SqlParameter oparam = new SqlParameter("@d", SqlDbType.Int);
                    oparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(oparam);

                    cmd.ExecuteNonQuery();

                    int billid = Convert.ToInt32(oparam.Value);

                    foreach (SSBillCheque ssBillCheque in ssMainBill.ListCheque)
                    {
                        cmdText = "sp_InsertSBillCheque";

                        cmd = new SqlCommand(cmdText, cnx, trnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        param = new SqlParameter("@SupplierId", SqlDbType.Int);
                        param.Value = ssBillCheque.SupplierId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@PaidAmount", SqlDbType.Float);
                        param.Value = ssBillCheque.PaidAmount;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ChequeNo", SqlDbType.VarChar);
                        param.Value = ssBillCheque.ChequeNo;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ChequeDate", SqlDbType.DateTime);
                        param.Value = ssBillCheque.ChequeDate;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SSMainBillId", SqlDbType.Int);
                        param.Value = billid;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        oparam = new SqlParameter("@d", SqlDbType.Int);
                        oparam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(oparam);

                        cmd.ExecuteNonQuery();

                        int chquebillid = Convert.ToInt32(oparam.Value);

                        SSBillCheque cheque = ssBillCheque;
                        var suplliers = from r in ssMainBill.ListSupplier
                                       where r.SupplierId == cheque.SupplierId
                                       select r;
                        string tbl = "<table>";
                        foreach (var supllier in suplliers)
                        {
                            tbl += "<SupplierBillNo>" + supllier.SupplierBillNo + "</SupplierBillNo>";
                            tbl += "<BillAmount>" + supllier.BillAmount + "</BillAmount>";
                            tbl += "<DueDate>" + supllier.DueDate.ToString("yyyy-dd-MM") + "</DueDate>";
                            tbl += "<AmountPay>" + supllier.AmountPay + "</AmountPay>";
                            tbl += "<Status>" + supllier.Status + "</Status>";
                            tbl += "<SrvId>" + supllier.SrvId + "</SrvId>";
                            tbl += "<TType>" + supllier.TType + "</TType>"; 
                        }
                        tbl += "</table>";

                        cmdText = "sp_InsertSBillSupplier";

                        cmd = new SqlCommand(cmdText, cnx, trnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                        param = new SqlParameter("@SupplierId", SqlDbType.Int);
                        param.Value = ssBillCheque.SupplierId;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@SSBillChequeId", SqlDbType.Float);
                        param.Value = chquebillid;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Xml", SqlDbType.VarChar);
                        param.Value = tbl;
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Cnt", SqlDbType.Int);
                        param.Value = suplliers.Count();
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }

                    trnx.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    trnx.Rollback();
                    return 0;
                }
            }
        }

        //NEW CODE START
        public DataTable GetFinancialYear()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "usp_getsalesyear";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt;
            }
        }


        public DataSet GetMonthlyActualCMTValue(string FinancialYear)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "uspMonthlyActualCMT";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Flag", SqlDbType.VarChar);
                param.Value = "GET";
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
                param.Value = FinancialYear;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
        }
        //NEW CODE END

        //added by abhishek 2/11/2018
        public DataSet GetBIPLfinancialValue()
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();
            const string cmdText = "GetBIPLfinancialValue";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            DataSet dsFabric = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dsFabric);

            return dsFabric;
          }
        }

        public int InsertActualCMT(int FinancialID, int MonthNumber, string FinancialYear, double ActualCMT, int CreatedBy)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
            cnx.Open();
            const string cmdText = "uspMonthlyActualCMT";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
            param.Value = "INSERT";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FinancialCMTId", SqlDbType.Int);
            param.Value = FinancialID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Month_Number", SqlDbType.Int);
            param.Value = MonthNumber;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FinancialYear", SqlDbType.VarChar);
            param.Value = FinancialYear;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActualCMT", SqlDbType.Float);
            param.Value = ActualCMT;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Value = CreatedBy;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            //DataSet dsFabric = new DataSet();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //adapter.Fill(dsFabric);
            int  i  = cmd.ExecuteNonQuery();
            return i;
            }
        }
        
        public int InsertbiplExportrevenue(int p_ID, double BIPLExportValues, double BIPLExportPCS, double IkandiExportValues, double IkandiExportPCS)
        {
          using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
          {
            cnx.Open();
            SqlTransaction trnx = cnx.BeginTransaction();
            try
            {
              const string cmdText = "GetBIPLfinancialValue";

              SqlCommand cmd = new SqlCommand(cmdText, cnx, trnx);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
              SqlParameter param = new SqlParameter("@Flag", SqlDbType.VarChar);
              param.Value = "UPDATE";
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@p_ID", SqlDbType.Int);
              param.Value = p_ID;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@BIPLExportValues", SqlDbType.Float);
              param.Value = BIPLExportValues;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@BIPLExportPCS", SqlDbType.Float);
              param.Value = BIPLExportPCS;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@IkandiExportValues", SqlDbType.Float);
              param.Value = IkandiExportValues;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

              param = new SqlParameter("@IkandiExportPCS", SqlDbType.Float);
              param.Value = IkandiExportPCS;
              param.Direction = ParameterDirection.Input;
              cmd.Parameters.Add(param);

            

              int  i  = cmd.ExecuteNonQuery();
              trnx.Commit();
              return i;
            }
            catch (Exception ex)
            {
              trnx.Rollback();
              System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
              System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
              return -1;
            }
          }
        }
        #endregion
    }
}
