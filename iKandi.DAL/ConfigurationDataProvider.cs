using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data.Common;
using System.ComponentModel;
using System.Collections;
using System.Data.SqlClient;

namespace iKandi.DAL
{
    [DataObject(true)]
    public class ConfigurationDataProvider: BaseDataProvider
    {
        #region Ctor(s)

        public ConfigurationDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

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
        public string GetKeyValue(string Key)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter("Select * from system_configuration where name='" + Key + "'", Constants.CONFIGURATION_STRING);
            ada.Fill(dt);
            return dt.Rows.Count > 0 ? dt.Rows[0]["value"].ToString() : String.Empty;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(string Value, string Name)
        {
            MySqlHelper.ExecuteNonQuery(Constants.CONFIGURATION_STRING, "Update system_configuration set value='" + Value + "' where name ='" + Name + "'");

        }

        #endregion
    }
}
