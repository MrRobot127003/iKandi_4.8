using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using iKandi.Common;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    public class SupplierDataProvider : EntityBaseDataProvider
    {
        #region Ctor(s)
        public SupplierDataProvider()
        {
        }

        public SupplierDataProvider(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }

        #endregion

        #region Methods
        #region GetAllSupplierTables
        public SupplierTables GetAllSupplierTables()
        {
            SupplierTables st = new SupplierTables();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetAllSupplierTables";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                FabricDataProvider fc = new FabricDataProvider();
                st.PoTypes = fc.GetPosFromTable(dsFabricQuality.Tables[0]);
                st.Processes = fc.GetProcessFromTable(dsFabricQuality.Tables[1]);
                st.Groups = fc.GetGroupsFromTable(dsFabricQuality.Tables[2]);
                st.Days = fc.GetPaymentDaysFromTable(dsFabricQuality.Tables[3]);
                st.Grades = fc.GetGradesFromTable(dsFabricQuality.Tables[4]);
            }
            return st;
        }
        #endregion

        #region Insert_Update_SupplierTables
        public int Insert_Update_SupplierTables(SupplierTables stbls)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_supplier_master_insert_update";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                SqlParameter param1 = new SqlParameter("@SupplierId", SqlDbType.Int);
                param1.Value = stbls.Id;
                param1.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param1);

                SqlParameter param = new SqlParameter("@GroupInitials", SqlDbType.VarChar);
                param.Value = stbls.Supplier.GroupInitial;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GroupName", SqlDbType.VarChar);
                param.Value = stbls.Supplier.GroupName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = stbls.Supplier.SupplierName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierIntials", SqlDbType.VarChar);
                param.Value = stbls.Supplier.SupplierInitial;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Address", SqlDbType.VarChar);
                param.Value = stbls.Supplier.Address;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MonthlyCapacity", SqlDbType.Int);
                param.Value = stbls.Supplier.MonthlyCapacity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.VarChar);
                param.Value = stbls.Supplier.Unit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentTerms", SqlDbType.VarChar);
                param.Value = stbls.Supplier.PaymentTerms;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierLeadTime", SqlDbType.Int);
                param.Value = stbls.Supplier.Leadtime;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                param.Value = stbls.Supplier.ModifiedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@U", SqlDbType.Int);
                param.Value = stbls.IU;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Pos", SqlDbType.VarChar);
                param.Value = stbls.PoTypes.Count < 1
                                  ? ""
                                  : string.Join(",", (from p in stbls.PoTypes select p.Id.ToString()).ToArray());
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Groups", SqlDbType.VarChar);
                param.Value = stbls.Groups.Count < 1
                                     ? ""
                                     : string.Join(",", (from p in stbls.Groups select p.Id.ToString()).ToArray());

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Processes", SqlDbType.VarChar);
                if (stbls.PoTypes.Count > 1)
                {
                    param.Value = stbls.Processes.Count < 1
                                  ? ""
                                  : string.Join(",", (from p in stbls.Processes select p.Id.ToString()).ToArray());
                }
                else
                {
                    if (stbls.PoTypes[0].Id != 1)
                        param.Value = stbls.Processes.Count < 1
                                  ? ""
                                  : string.Join(",", (from p in stbls.Processes select p.Id.ToString()).ToArray());
                    else
                        param.Value = "";
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter paramo = new SqlParameter("@oStatusId", SqlDbType.VarChar);
                paramo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramo);

                cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(paramo.Value);

                stbls.Id = Convert.ToInt32(param1.Value);
                if (result == 1)
                    Insert_Update_Contacts(stbls.Contacts, stbls.Id, stbls.IU == 1 ? -1 : stbls.Supplier.ModifiedBy);
                return result;
            }
        }
        #endregion

        #region Insert_Update_Contacts
        public void Insert_Update_Contacts(List<SupplierContact> pos, int id, int userId)
        {
            if (pos == null || pos.Count < 1)
                return;
            string tbl = "<table>";
            foreach (var sc in pos)
            {
                tbl += "<name>" + sc.Name + "</name>";
                tbl += "<phone>" + sc.Phone + "</phone>";
                tbl += "<email>" + sc.Email + "</email>";
                tbl += "<rem>" + sc.Remarks + "</rem>";
            }
            tbl += "</table>";
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_supplier_contact_insert_update";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                SqlParameter param = new SqlParameter("@SupplierId", SqlDbType.Int);
                param.Value = id;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Xml", SqlDbType.VarChar);
                param.Value = tbl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Cnt", SqlDbType.VarChar);
                param.Value = pos.Count;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sModified", SqlDbType.VarChar);
                param.Value = userId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region GetSupplierTableById
        public SupplierTables GetSupplierTableById(int Id)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SupplierTables stbls = new SupplierTables();
                stbls.Id = Id;
                const string cmdText = "sp_GetAllSupplierTablesById";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = Id;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1)
                    return null;
                if (dsFabricQuality.Tables[0].Rows.Count > 0)
                {
                    stbls.Supplier = GetSupplierAdminFromTable(dsFabricQuality.Tables[0].Rows[0]);
                }
                FabricDataProvider fc = new FabricDataProvider();
                stbls.PoTypes = fc.GetPosFromTable(dsFabricQuality.Tables[1]);
                stbls.Processes = fc.GetProcessFromTable(dsFabricQuality.Tables[2]);
                stbls.Groups = fc.GetGroupsFromTable(dsFabricQuality.Tables[3]);
                DataTable dt = dsFabricQuality.Tables[4];
                if (dt != null && dt.Rows.Count > 0)
                    stbls.Contacts = GetContactsFromTable(dt);
                return stbls;
            }
        }
        #endregion

        protected List<SupplierContact> GetContactsFromTable(DataTable dt)
        {
            List<SupplierContact> lst = new List<SupplierContact>();
            foreach (DataRow d in dt.Rows)
            {
                SupplierContact sc = new SupplierContact();
                sc.Name = d["PersonName"] == DBNull.Value ? "" : Convert.ToString(d["PersonName"]);
                sc.Phone = d["PhoneNo"] == DBNull.Value ? "" : Convert.ToString(d["PhoneNo"]);
                sc.Remarks = d["Remarks"] == DBNull.Value ? "" : Convert.ToString(d["Remarks"]);
                sc.Email = d["Email"] == DBNull.Value ? "" : Convert.ToString(d["Email"]);
                sc.Id = d["Id"] == DBNull.Value ? 0 : Convert.ToInt32(d["Id"]);
                sc.SupplierId = d["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(d["SupplierId"]);
                lst.Add(sc);
            }
            return lst;
        }

        #region GetSupplierAdminFromTable
        public SupplierAdmin GetSupplierAdminFromTable(DataRow dr)
        {
            SupplierAdmin supplier = new SupplierAdmin();
            supplier.GroupInitial = dr["GroupInitial"] == DBNull.Value ? "" : Convert.ToString(dr["GroupInitial"]);
            supplier.GroupName = dr["GroupName"] == DBNull.Value ? "" : Convert.ToString(dr["GroupName"]);
            supplier.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierName"]);
            supplier.SupplierInitial = dr["SupplierInitial"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierInitial"]);
            supplier.Address = dr["Address"] == DBNull.Value ? "" : Convert.ToString(dr["Address"]);
            supplier.MonthlyCapacity = dr["MonthlyCapacity"] == DBNull.Value ? 0 : Convert.ToInt32(dr["MonthlyCapacity"]);
            supplier.Unit = dr["Unit"] == DBNull.Value ? "" : Convert.ToString(dr["Unit"]);
            supplier.PaymentTerms = dr["PaymentTerms"] == DBNull.Value ? "" : Convert.ToString(dr["PaymentTerms"]);
            supplier.Leadtime = dr["SupplierLeadTime"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierLeadTime"]);
            supplier.Grade = dr["Grade"] == DBNull.Value ? "" : Convert.ToString(dr["Grade"]);
            return supplier;
        }
        #endregion

        #region GetContactsBySupplierId
        public List<SupplierContact> GetContactsBySupplierId(int supplierid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetSupplierContacts";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = supplierid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1)
                    return null;
                return GetContactsFromTable(dsFabricQuality.Tables[0]);
            }
        }
        #endregion

        #region GetGroupName
        public string GetGroupName(string gName)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_Get_Supplier_Group_Name";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param = new SqlParameter("@GroupName", SqlDbType.VarChar);
                param.Value = gName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                string name = Convert.ToString(cmd.ExecuteScalar());
                return name;
            }
        }
        #endregion

        #region GetDuplicateSupplier
        public int GetDuplicateSupplier(string gName, string sName, int sid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_Get_Duplicate_Supplier";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@GroupName", SqlDbType.VarChar);
                param.Value = gName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = sName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = sid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
        }
        #endregion

        #region GetSupplierTableList
        public DataSet GetSupplierTableList(SupplierSearch ss)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                string cmdText = "sp_GetAllSupplierTableList";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param = new SqlParameter("@SupplierId", SqlDbType.Int);
                param.Value = ss.SupplierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoId", SqlDbType.Int);
                param.Value = ss.PoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = ss.CategoryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessId", SqlDbType.Int);
                param.Value = ss.ProcessId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentTerms", SqlDbType.Int);
                param.Value = ss.PaymentTerms;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SltFrom", SqlDbType.Int);
                param.Value = ss.SupplierLeadTimeFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SltTo", SqlDbType.Int);
                param.Value = ss.SupplierLeadTimeTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@McFrom", SqlDbType.Int);
                param.Value = ss.MonthlyCapacityFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@McTo", SqlDbType.Int);
                param.Value = ss.MonthlyCapacityTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                return dsFabricQuality;
            }
        }
        #endregion

        #region GetSupplierTableLists
        public List<SupplierList> GetSupplierTableLists(SupplierSearch ss)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<SupplierList> slt = new List<SupplierList>();
                cnx.Open();
                const string cmdText = "sp_GetAllSupplierTableList";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@SupplierId", SqlDbType.Int);
                param.Value = ss.SupplierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PoId", SqlDbType.Int);
                param.Value = ss.PoId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = ss.CategoryId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProcessId", SqlDbType.Int);
                param.Value = ss.ProcessId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentTerms", SqlDbType.Int);
                param.Value = ss.PaymentTerms;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SltFrom", SqlDbType.Int);
                param.Value = ss.SupplierLeadTimeFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SltTo", SqlDbType.Int);
                param.Value = ss.SupplierLeadTimeTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@McFrom", SqlDbType.Int);
                param.Value = ss.MonthlyCapacityFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@McTo", SqlDbType.Int);
                param.Value = ss.MonthlyCapacityTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.VarChar);
                param.Value = ss.Unit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1)
                    return null;
                foreach (DataRow dataRow in dsFabricQuality.Tables[0].Rows)
                {
                    SupplierList sl = new SupplierList();
                    sl.Id = dataRow["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["Id"]);
                    sl.GroupInitial = dataRow["GroupInitial"] == DBNull.Value ? "" : Convert.ToString(dataRow["GroupInitial"]);
                    sl.GroupName = dataRow["GroupName"] == DBNull.Value ? "" : Convert.ToString(dataRow["GroupName"]);
                    sl.SupplierInitial = dataRow["SupplierInitial"] == DBNull.Value ? "" : Convert.ToString(dataRow["SupplierInitial"]);
                    sl.SupplierName = dataRow["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dataRow["SupplierName"]);
                    sl.Address = dataRow["Address"] == DBNull.Value ? "" : Convert.ToString(dataRow["Address"]);
                    sl.SupplyTypeDetails = dataRow["SupplyTypeDetails"] == DBNull.Value ? "" : Convert.ToString(dataRow["SupplyTypeDetails"]);
                    sl.ProcessDetails = dataRow["ProcessDetails"] == DBNull.Value ? "" : Convert.ToString(dataRow["ProcessDetails"]);
                    sl.FabricDetails = dataRow["FabricDetails"] == DBNull.Value ? "" : Convert.ToString(dataRow["FabricDetails"]);
                    sl.MonthlyCapacityDetail = dataRow["MonthlyCapacityDetail"] == DBNull.Value ? "" : Convert.ToString(dataRow["MonthlyCapacityDetail"]);
                    sl.PaymentTermDetail = dataRow["PaymentTermDetail"] == DBNull.Value ? "" : Convert.ToString(dataRow["PaymentTermDetail"]);
                    sl.LeadTimeDetail = dataRow["LeadTimeDetail"] == DBNull.Value ? "" : Convert.ToString(dataRow["LeadTimeDetail"]);
                    sl.Grade = dataRow["Grade"] == DBNull.Value ? "" : Convert.ToString(dataRow["Grade"]);
                    sl.Contacts = new List<SupplierContact>();
                    DataRow[] drs = dsFabricQuality.Tables[1].Select("SupplierId = " + sl.Id);
                    if (drs.Length > 0)
                    {
                        sl.Contacts = GetContactsFromTable(drs.CopyToDataTable());
                        /* DataTable cloneTable = dsFabricQuality.Tables[1].Clone();
                         foreach (DataRow row in drs)
                             cloneTable.ImportRow(row);*/
                        /*IEnumerable<DataRow> query = from order in dsFabricQuality.Tables[1].AsEnumerable()
                                                     where order.Field<Int32>("SupplierId") == sl.Id
                                                     select order;
                        DataTable boundTable = query.CopyToDataTable<DataRow>();*/

                        /*foreach (DataRow dr in drs)
                        {
                            SupplierContact sc = new SupplierContact();
                            sc.Id = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"]);
                            sc.SupplierId = dr["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierId"]);
                            sc.Name = dr["PersonName"] == DBNull.Value ? "" : Convert.ToString(dr["PersonName"]);
                            sc.Email = dr["Email"] == DBNull.Value ? "" : Convert.ToString(dr["Email"]);
                            sc.Phone = dr["PhoneNo"] == DBNull.Value ? "" : Convert.ToString(dr["PhoneNo"]);
                            sc.Remarks = dr["Remarks"] == DBNull.Value ? "" : Convert.ToString(dr["Remarks"]);
                            sl.Contacts.Add(sc);
                        }*/
                    }
                    slt.Add(sl);
                }
                return slt;
            }
        }
        #endregion

        #region GetGroupNameByName
        public List<string> GetGroupNameByName(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataReader reader;
                const string cmdText = "sp_GetGroupNameByName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@GroupName", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["GroupName"]));
                }
                return result;
            }
        }
        #endregion

        #region GetSupplierNameByName
        public List<string> GetSupplierNameByName(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetSupplierNameByName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["SupplierName"]));
                }
                return result;
            }
        }
        #endregion

        #region GetSupplierNameWithGroupByName
        public List<string> GetSupplierNameWithGroupByName(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetSupplierNameWithGroupByName";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["SupplierName"]));
                }
                return result;
            }
        }
        #endregion

        #region GetSupplierAddressByNameWithGroup
        public string GetSupplierAddressByNameWithGroup(string type)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetSupplierAddressByNameWithGroup";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlParameter oparam;
                oparam = new SqlParameter("@oAddress", SqlDbType.VarChar);
                oparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oparam);

                cmd.ExecuteNonQuery();

                return Convert.ToString(oparam.Value);
            }
        }
        #endregion

        #region GetDuplicateGroupInit
        public string GetDuplicateGroupInit(string type, int Sid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetDuplicateGroupInit";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param;
                param = new SqlParameter("@GroupInit", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = Sid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                object obj = cmd.ExecuteScalar();
                if (obj == DBNull.Value)
                    return "";
                return Convert.ToString(obj);
            }
        }
        #endregion

        #region GetDuplicateGroupName
        public int GetDuplicateGroupName(string type, int Sid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetDuplicateGroup";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param = new SqlParameter("@GroupName", SqlDbType.VarChar);
                param.Value = type;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = Sid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        #endregion

        #region GetDuplicateSupplierInit
        public int GetDuplicateSupplierInit(string sInit, int Sid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "sp_GetDuplicateSupplierInit";

                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                //iProcess
                SqlParameter param = new SqlParameter("@SupplierInit", SqlDbType.VarChar);
                param.Value = sInit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = Sid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        #endregion

        #region GetSupplierIdByNameWithGroup
        public int GetSupplierIdByNameWithGroup(string name)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_GetSupplierIdByNameWithGroup";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                SqlParameter outParam;
                outParam = new SqlParameter("@oId", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                int supplierid = Convert.ToInt32(outParam.Value);

                return supplierid;
            }
        }
        #endregion

        #endregion

        #region GetSupplierIdByNameWithGroup
        public string GetSupplierInitialByName(string name)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "sp_Get_SupplierInitial_By_Name";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlParameter outParam;
                outParam = new SqlParameter("@SupplierInitital", SqlDbType.VarChar);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                string supplierinit = Convert.ToString(outParam.Value);

                return supplierinit.Trim();
            }
        }
        #endregion

        public List<Supplier> GetSupplierInit(string name) 
        {
            
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_GetSupplierInitial";
                List<iKandi.Common.Supplier> list =new List<iKandi.Common.Supplier>();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@SupplierInitial", SqlDbType.VarChar);
                param.Value = name;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];
               
                foreach (DataRow row in dt1.Rows)
                {
                    Supplier items = new Supplier();

                    items.Id = Convert.ToInt32(row["Id"].ToString());
                    list.Add(items);
                }
                cnx.Close();
                return list;
            }
        }


        public List<Supplier> CheckGroupSupplierDAL(string GroupName, string SupName, string hdnSuppName)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_CheckGroupSupplier";
                List<iKandi.Common.Supplier> list = new List<iKandi.Common.Supplier>();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;
                param = new SqlParameter("@GroupName", SqlDbType.VarChar);
                param.Value = GroupName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupName", SqlDbType.VarChar);
                param.Value = SupName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Id", SqlDbType.VarChar);
                param.Value = hdnSuppName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable dt1 = ds.Tables[0];

                foreach (DataRow row in dt1.Rows)
                {
                    Supplier items = new Supplier();

                    items.Id = Convert.ToInt32(row["Id"].ToString());
                    items.value = row["SupplierName"].ToString();
                    list.Add(items);
                }
                cnx.Close();
                return list;
            }
        }

        public int InsertUpdateSuppilerDAL(List<SupplierContact> pos, Supplier prm_SupplierClass)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING)) 
            {
               
                cnx.Open();
                int id = 0;
                string tbl = "<root>";
                foreach (var sc in pos)
                {
                    tbl += "<table><PersonName>" + sc.Name + "</PersonName>";
                    tbl += "<Email>" + sc.Email + "</Email>";
                    tbl += "<PhoneNo>" + sc.Phone + "</PhoneNo>";
                    tbl += "<Remarks>" + sc.Remarks + "</Remarks></table>";
                }
                tbl += "</root>";


                const string cmdText = "Usp_InsertUpdateSuppliers";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };
                SqlParameter param1 = new SqlParameter("@Id", SqlDbType.Int);
                param1.Value = prm_SupplierClass.SupplierID;
                param1.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param1);

                SqlParameter param = new SqlParameter("@GroupInitial", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.GroupInitials;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GroupName", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.GroupName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.SupplierName;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierInitial", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.SupplierInitial;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MonthlyCapacity", SqlDbType.Int);
                param.Value = prm_SupplierClass.MonthCapacity;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.Unit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitMtr", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.UnitMtr;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PaymentID", SqlDbType.Int);
                param.Value = prm_SupplierClass.PaymentTerm;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierLeadTime", SqlDbType.Int);
                param.Value = prm_SupplierClass.SupplierLeadTime;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@SupplierAddress", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.Address;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierType", SqlDbType.VarChar);
                param.Value = prm_SupplierClass.FabricType;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param.Value = prm_SupplierClass.CreatedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifyBy", SqlDbType.Int);
                param.Value = prm_SupplierClass.ModifiedBy;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@xml", SqlDbType.VarChar);
                param.Value = tbl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                return id = cmd.ExecuteNonQuery();
            }
        }


        public DataTable GetPaymentAdmin() 
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_GetPaymentAdmin";
                List<iKandi.Common.Supplier> list = new List<iKandi.Common.Supplier>();
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cnx.Close();
                return dt;
            }
        }

         
        #region GetSupplierLists
        public List<SupplierList> GetSupplierLists(SupplierSearch ss)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                List<SupplierList> slt = new List<SupplierList>();
                cnx.Open();
                const string cmdText = "Usp_GetSupplierSearch";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Value = ss.SupplierId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BasicSearch", SqlDbType.VarChar);
                param.Value = ss.BasicSearch;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MCapacityFrom", SqlDbType.VarChar);
                param.Value = ss.MonthlyCapacityFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MCapacityTo", SqlDbType.VarChar);
                param.Value = ss.MonthlyCapacityTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Unit", SqlDbType.VarChar);
                param.Value = ss.Unit;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@payment", SqlDbType.Int);
                param.Value = ss.PaymentTerms;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SLeadTimeFrom", SqlDbType.VarChar);
                param.Value = ss.SupplierLeadTimeFrom;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SLeadTimeTo", SqlDbType.VarChar);
                param.Value = ss.SupplierLeadTimeTo;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierType", SqlDbType.Int);
                if (ss.supplierType == 0)
                {
                    param.Value = -1;
                }
                else
                {
                    param.Value = ss.supplierType;
                }
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);

                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1)
                    return null;
                foreach (DataRow dataRow in dsFabricQuality.Tables[0].Rows)
                {
                    SupplierList sl = new SupplierList();
                    sl.Id = dataRow["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dataRow["Id"]);
                    sl.GroupInitial = dataRow["GroupInitial"] == DBNull.Value ? "" : Convert.ToString(dataRow["GroupInitial"]);
                    sl.GroupName = dataRow["GroupName"] == DBNull.Value ? "" : Convert.ToString(dataRow["GroupName"]);
                    sl.SupplierInitial = dataRow["SupplierInitial"] == DBNull.Value ? "" : Convert.ToString(dataRow["SupplierInitial"]);
                    sl.SupplierName = dataRow["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dataRow["SupplierName"]);
                    sl.Unit = dataRow["Unit"] == DBNull.Value ? "" : Convert.ToString(dataRow["Unit"]);
                    sl.Address = dataRow["SupplierAddress"] == DBNull.Value ? "" : Convert.ToString(dataRow["SupplierAddress"]);
                    sl.MonthlyCapacityDetail = dataRow["MonthlyCapacityDetail"] == DBNull.Value ? "" : Convert.ToString(dataRow["MonthlyCapacityDetail"]);
                    sl.PaymentTermDetail = dataRow["PaymentTermDetail"] == DBNull.Value ? "" : Convert.ToString(dataRow["PaymentTermDetail"]);
                    sl.LeadTimeDetail = dataRow["LeadTimeDetail"] == DBNull.Value ? "" : Convert.ToString(dataRow["LeadTimeDetail"]);
                    sl.Grade = dataRow["Grade"] == DBNull.Value ? "" : Convert.ToString(dataRow["Grade"]);
                    sl.SupplierType = dataRow["SupplierType"] == DBNull.Value ? "" : Convert.ToString(dataRow["SupplierType"]);
                    sl.Contacts = new List<SupplierContact>();
                    DataRow[] drs = dsFabricQuality.Tables[1].Select("SupplierId = " + sl.Id);
                    if (drs.Length > 0)
                    {
                        sl.Contacts = GetContactsFromTable(drs.CopyToDataTable());
                       
                    }
                    slt.Add(sl);
                }
                return slt;
            }
        }
        #endregion



        #region GetContactsById
        public List<SupplierContact> GetContactsById(int supplierid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_SupplierContactById";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = supplierid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd); 
                adapter.Fill(dsFabricQuality);
                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1)
                    return null;
                return GetContactsFromTable(dsFabricQuality.Tables[1]);
            }
        }
        #endregion


        public DataTable GetSupplierById(int supplierid)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                const string cmdText = "Usp_SupplierContactById";
                SqlCommand cmd = new SqlCommand(cmdText, cnx) { CommandType = CommandType.StoredProcedure };

                SqlParameter param;
                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = supplierid;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                DataSet dsFabricQuality = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsFabricQuality);
                if (dsFabricQuality == null || dsFabricQuality.Tables.Count < 1)
                    return null;

                DataTable dt = new DataTable();
                dt = dsFabricQuality.Tables[0];
                return dt;
            }
        }

        public string GetSupplierCode(int Flag, string SupplierName, string Type)
        {
            string NewSupplierCode = string.Empty;
            try
            {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "Usp_GetSupplier";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierName", SqlDbType.VarChar);
                    param.Value = SupplierName;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);                    

                    param = new SqlParameter("@types", SqlDbType.VarChar);
                    param.Value = Type;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    string Result = cmd.ExecuteScalar().ToString();
                    int Val;
                    if (Result != string.Empty)
                    {
                        string[] SplitString = Result.Split('-');
                        if (SplitString.Length > 1)
                        {
                            Val = Convert.ToInt32(SplitString[1]);
                            Val = Val + 1;
                            NewSupplierCode = SplitString[0].ToString() + "-" + Val.ToString();
                        }
                        else
                        {
                            Val = 1;
                            NewSupplierCode = SplitString[0].ToString() + "-" + Val.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NewSupplierCode = "";
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return NewSupplierCode;
        }
        //Add Code By Bharat On 25-Aug-20
        public string SupplierCodeValidate(int Flag, string SupplierCode, int SupplierId)
        {
                using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
                {
                    cnx.Open();

                    string cmdText = "Usp_ValidateSupplierCodeEmail";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param;

                    param = new SqlParameter("@Flag", SqlDbType.Int);
                    param.Value = Flag;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierCode", SqlDbType.VarChar);
                    param.Value = SupplierCode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SupplierId", SqlDbType.Int);
                    param.Value = SupplierId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    string Result = cmd.ExecuteScalar().ToString();
                    return Result;
                }
        }

        public string SupplierEmailValidate(int Flag, string SupplierEmail, int grdsupId)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Usp_ValidateSupplierCodeEmail";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@Flag", SqlDbType.Int);
                param.Value = Flag;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierCode", SqlDbType.VarChar);
                param.Value = SupplierEmail;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SupplierId", SqlDbType.VarChar);
                param.Value = grdsupId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                string Result = cmd.ExecuteScalar().ToString();
                return Result;
            }
        }
    }
}