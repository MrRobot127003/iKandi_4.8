using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.DAL
{
    public class INDBlockDataProvider : BaseDataProvider
    {
        #region Ctor(s)

        public INDBlockDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<INDBlock> GetAllBlocks(int PageSize, int PageIndex, out int TotalRowCount, int ClientId, string SearchText)
        {
            // Create a connection object and data adapter
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                // Create a SQL command object
                string cmdText = "sp_ind_block_get_all_ind_block_with_paging";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                // Set the command type to StoredProcedure
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

                
                param = new SqlParameter("@ClientID", SqlDbType.Int);
                param.Value = ClientId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                param.Value = SearchText;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                List<INDBlock> indBlocks = new List<INDBlock>();

                while (reader.Read())
                {
                    INDBlock indBlock = new INDBlock();

                    indBlock.BlockID = Convert.ToInt32(reader["Id"]);
                    indBlock.BlockNumber = (reader["BlockNumber"]).ToString();
                    indBlock.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                    indBlock.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                    indBlock.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                    indBlock.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerFirstName"])) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerLastName"]));
                    indBlock.Brand = (reader["Brand"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Brand"]);
                    indBlock.Reference = (reader["Reference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Reference"]);
                    indBlock.BlockCost = (reader["BlockCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BlockCost"]);
                    indBlock.BlockCostCurrency = (reader["CostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["CostCurrency"]);
                    indBlock.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    indBlock.AdditionalImageUrl1 = (reader["AdditionalImageUrl1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AdditionalImageUrl1"]);
                    indBlock.AdditionalImageUrl2 = (reader["AdditionalImageUrl2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AdditionalImageUrl2"]);

                    indBlocks.Add(indBlock);
                }
               
                reader.Close();
                TotalRowCount = Convert.ToInt32(outParam.Value);
                return indBlocks;
            }
        }

        public bool InsertIndBlock(INDBlock Block)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();


                string cmdText = "sp_ind_block_insert_ind_block";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter outParam;
                outParam = new SqlParameter("@d", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                SqlParameter param;

                param = new SqlParameter("@BlockNumber", SqlDbType.VarChar);
                param.Value = Block.BlockNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.VarChar);
                param.Value = Block.Description;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = Block.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = Block.DesignerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Brand", SqlDbType.VarChar);
                param.Value = Block.Brand;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Reference", SqlDbType.VarChar);
                param.Value = Block.Reference;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BlockCost", SqlDbType.Float);
                param.Value = Block.BlockCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DatePurchased", SqlDbType.DateTime);
                param.Value = Block.DatePurchased;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostCurrency", SqlDbType.Int);
                param.Value = (int)Block.BlockCostCurrency;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@mageUrl", SqlDbType.VarChar);
                param.Value = Block.ImageUrl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdditionalImageUrl1", SqlDbType.VarChar);
                param.Value = Block.AdditionalImageUrl1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdditionalImageUrl2", SqlDbType.VarChar);
                param.Value = Block.AdditionalImageUrl2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int blockID = Convert.ToInt32(outParam.Value);

                cnx.Close();
            }

            return true;
        }

        public INDBlock GetBlockById(int BlockId)
        {
            INDBlock indBlock = new INDBlock();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_ind_block_get_block_by_id";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = BlockId;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        indBlock.BlockID = Convert.ToInt32(reader["Id"]);
                        indBlock.BlockNumber = Convert.ToString(reader["BlockNumber"]);
                        indBlock.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                        indBlock.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                        indBlock.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                        //indBlock.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerFirstName"])) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerLastName"]));
                        indBlock.Brand = (reader["Brand"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Brand"]);
                        indBlock.Reference = (reader["Reference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Reference"]);
                        indBlock.BlockCost = (reader["BlockCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BlockCost"]);
                        indBlock.BlockCostCurrency = (reader["CostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["CostCurrency"]);
                        indBlock.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                        indBlock.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);
                        indBlock.DesignerID = (reader["DesignerID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DesignerID"]);
                        indBlock.AdditionalImageUrl1 = (reader["AdditionalImageUrl1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AdditionalImageUrl1"]);
                        indBlock.AdditionalImageUrl2 = (reader["AdditionalImageUrl2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AdditionalImageUrl2"]);

                      
                    }
                }
            }
            return indBlock;
        }

        public INDBlock GetBlockByBlockNumber(string BlockNumber)
        {
            INDBlock indBlock = new INDBlock();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_ind_block_get_block_detail_by_block_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param = new SqlParameter("@BlockNumber", SqlDbType.VarChar);
                param.Value = BlockNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    indBlock.BlockID = Convert.ToInt32(reader["Id"]);
                    indBlock.BlockNumber = Convert.ToString(reader["BlockNumber"]);
                    indBlock.Description = (reader["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Description"]);
                    indBlock.ClientName = (reader["ClientName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ClientName"]);
                    indBlock.DatePurchased = (reader["DatePurchased"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["DatePurchased"]);
                    indBlock.DesignerName = ((reader["DesignerFirstName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerFirstName"])) + " " + ((reader["DesignerLastName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DesignerLastName"]));
                    indBlock.Brand = (reader["Brand"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Brand"]);
                    indBlock.Reference = (reader["Reference"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Reference"]);
                    indBlock.BlockCost = (reader["BlockCost"] == DBNull.Value) ? 0 : Convert.ToDouble(reader["BlockCost"]);
                    indBlock.BlockCostCurrency = (reader["CostCurrency"] == DBNull.Value) ? Currency.GBP : (Currency)Convert.ToInt16(reader["CostCurrency"]);
                    indBlock.ImageUrl = (reader["ImageUrl"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["ImageUrl"]);
                    indBlock.AdditionalImageUrl1 = (reader["AdditionalImageUrl1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AdditionalImageUrl1"]);
                    indBlock.AdditionalImageUrl2 = (reader["AdditionalImageUrl2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["AdditionalImageUrl2"]);
                    indBlock.ClientID = (reader["ClientID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["ClientID"]);
                    indBlock.DesignerID = (reader["DesignerID"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["DesignerID"]);
                }
            }
            return indBlock;
        }

        public bool UpdateIndBlock(INDBlock Block)
        {

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string cmdText = "sp_ind_block_update_ind_block";

                SqlCommand cmd = new SqlCommand(cmdText, cnx);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter param;

                param = new SqlParameter("@d", SqlDbType.Int);
                param.Value = Block.BlockID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BlockNumber", SqlDbType.VarChar);
                param.Value = Block.BlockNumber;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.VarChar);
                param.Value = Block.Description;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClientId", SqlDbType.Int);
                param.Value = Block.ClientID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DesignerID", SqlDbType.Int);
                param.Value = Block.DesignerID;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Brand", SqlDbType.VarChar);
                param.Value = Block.Brand;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Reference", SqlDbType.VarChar);
                param.Value = Block.Reference;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@BlockCost", SqlDbType.Float);
                param.Value = Block.BlockCost;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DatePurchased", SqlDbType.DateTime);
                param.Value = Block.DatePurchased;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CostCurrency", SqlDbType.Int);
                param.Value = (int)Block.BlockCostCurrency;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@mageUrl", SqlDbType.VarChar);
                param.Value = Block.ImageUrl;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdditionalImageUrl1", SqlDbType.VarChar);
                param.Value = Block.AdditionalImageUrl1;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdditionalImageUrl2", SqlDbType.VarChar);
                param.Value = Block.AdditionalImageUrl2;
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cnx.Close();

            }

            return true;

        }

        public string GetNewBlockNumber()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();


                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_ind_block_get_new_block_number";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                object obj = cmd.ExecuteScalar();
                string blockNumber = "";

                if (obj != DBNull.Value && obj != null)
                    blockNumber = (obj).ToString();

                return blockNumber;

            }

        }



    }


}

