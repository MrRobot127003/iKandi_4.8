using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;


namespace iKandi.DAL
{
   public class GreigeStockDataProvider: BaseDataProvider
    {
       
        #region Ctor(s)

        public GreigeStockDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        public List<iKandi.Common.FabricGroupAdmin.Fabric> getFabricBIPLinfoDAL(string Fabric)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_getFabricBIPLinfo";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;


                SqlParameter param = new SqlParameter("@FabName", SqlDbType.VarChar);
                param.Value = Fabric;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                FabricGroupAdmin FGA = new FabricGroupAdmin();
                FGA.FabricGroup = new List<iKandi.Common.FabricGroupAdmin.Fabric>();
               

                while (reader.Read())
                {
                  
                    iKandi.Common.FabricGroupAdmin.Fabric fab = new iKandi.Common.FabricGroupAdmin.Fabric();
                    fab.FabName = Convert.ToString(reader["TradeName"]);
                    fab.CC = Convert.ToString(reader["CountConstruction"]);
                    fab.Composition = Convert.ToString(reader["Composition"]);
                    fab.GSM = Convert.ToString(reader["GSM"]);
                    fab.Handfeel = Convert.ToString(reader["HandFeel"]);
                    fab.width = Convert.ToString(reader["Width"]);
                    
                    
               
                    FGA.FabricGroup.Add(fab);
                }

             
                return FGA.FabricGroup;
                
            }

        }

        public DataSet GetSupplierAllDAL(string Fab, string Qty,string isStock, int MasterPOID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_getAllSupplier";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@Fab", SqlDbType.VarChar);
                param.Value = Fab;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Qty", SqlDbType.VarChar);
                param.Value = Qty;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@sStock", SqlDbType.VarChar);
                param.Value = isStock;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@MOID", SqlDbType.Int);
                param.Value = MasterPOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsclient);
                return (dsclient);

            }

        }

        public DataSet GetPOQualityDAL( int MasterPOID)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                DataSet dsclient = new DataSet();
                cnx.Open();
                SqlCommand cmd;
                string cmdText;

                cmdText = "GetPOQualityControl";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter param;
                param = new SqlParameter("@MasterPOId", SqlDbType.Int);
                param.Value = MasterPOID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsclient);
                return (dsclient);

            }

        }
    
    }
}
