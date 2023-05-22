using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using iKandi.Common;


namespace iKandi.BLL.Configuration
{
    [DataObject(true)]
    public class Configuration
    {
        #region Fields

        private string keyName = string.Empty;
        private string keyValue = string.Empty;

        public string KeyName
        {
            get
            {
                return this.keyName;
            }
            set
            {
                this.keyName = value;
            }
        }

        public string KeyValue 
        {
            get
            {
                return this.keyValue;
            }
            set
            {
                this.keyValue = value;
            }
        }

        #endregion

        #region Constants


        #endregion

        #region Static Methods

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataTable GetAllKeyValues()
        {
            DataTable dt = new DataTable();
            
            SqlDataAdapter ada = new SqlDataAdapter("Select * from system_configuration", Constants.CONFIGURATION_STRING);
            ada.Fill(dt);
            return dt;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public string GetKeyValue2(string Key)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter("Select * from system_configuration where name='"+Key+"'", Constants.CONFIGURATION_STRING);
            ada.Fill(dt);
            return dt.Rows[0]["value"].ToString();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(string Value, string Name)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                string cmdText = "Update system_configuration set value='" + Value + "' where name ='" + Name + "'";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
          
           
           // cmd.ExecuteNonQuery(Constants.CONFIGURATION_STRING, "Update system_configuration set value='" + Value + "' where name ='" + Name + "'");
           // mySqlCommand.ExecuteNonQuery(Constants.CONFIGURATION_STRING, "Update system_configuration set value='" + Value + "' where name ='" + Name + "'");

            BLLCache.ClearSystemConfigurationCache();

        }

        #endregion
    }
}
