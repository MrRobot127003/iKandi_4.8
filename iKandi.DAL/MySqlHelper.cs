using System;
using System.Data;
using System.Data.SqlClient;


namespace iKandi.DAL
{

    /// <summary>
    /// Helper class that makes it easier to work with the provider.
    /// </summary>
    public sealed class MySqlHelper
    {
        // this class provides only static methods
        private MySqlHelper()
        {
            
        }

        #region ExecuteNonQuery

        /// <summary>
        /// Executes a single command against a MySQL database.  The <see cref="SqlConnection"/> is assumed to be
        /// open when the method is called and remains open after the method completes.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object to use</param>
        /// <param name="commandText">SQL command to be executed</param>
        /// <param name="commandParameters">Array of <see cref="SqlParameter"/> objects to use with the command.</param>
        /// <returns></returns>
        
        public static int ExecuteNonQuery(SqlConnection connection, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;

            if (commandParameters != null)
                foreach (SqlParameter p in commandParameters)
                    cmd.Parameters.Add(p);

            int result = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            return result;
        }

        /// <summary>
        /// Executes a single command against a MySQL database.  A new <see cref="SqlConnection"/> is created
        /// using the <see cref="SqlConnection.ConnectionString"/> given.
        /// </summary>
        /// <param name="connectionString"><see cref="SqlConnection.ConnectionString"/> to use</param>
        /// <param name="commandText">SQL command to be executed</param>
        /// <param name="parms">Array of <see cref="SqlParameter"/> objects to use with the command.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string commandText, params SqlParameter[] parms)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                //call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(cn, commandText, parms);
            }
        }
        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// Executes a single SQL command and returns the first row of the resultset.  A new SqlConnection object
        /// is created, opened, and closed during this method.
        /// </summary>
        /// <param name="connectionString">Settings to be used for the connection</param>
        /// <param name="commandText">Command to execute</param>
        /// <param name="parms">Parameters to use for the command</param>
        /// <returns>DataRow containing the first row of the resultset</returns>
        public static DataRow ExecuteDatarow(string connectionString, string commandText, params SqlParameter[] parms)
        {
            DataSet ds = ExecuteDataset(connectionString, commandText, parms);
            if (ds == null) return null;
            if (ds.Tables.Count == 0) return null;
            if (ds.Tables[0].Rows.Count == 0) return null;
            return ds.Tables[0].Rows[0];
        }

        /// <summary>
        /// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
        /// A new SqlConnection object is created, opened, and closed during this method.
        /// </summary>
        /// <param name="connectionString">Settings to be used for the connection</param>
        /// <param name="commandText">Command to execute</param>
        /// <returns><see cref="DataSet"/> containing the resultset</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataset(connectionString, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
        /// A new SqlConnection object is created, opened, and closed during this method.
        /// </summary>
        /// <param name="connectionString">Settings to be used for the connection</param>
        /// <param name="commandText">Command to execute</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns><see cref="DataSet"/> containing the resultset</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                //call the overload that takes a connection in place of the connection string
                return ExecuteDataset(cn, commandText, commandParameters);
            }
        }

        /// <summary>
        /// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
        /// The state of the <see cref="SqlConnection"/> object remains unchanged after execution
        /// of this method.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object to use</param>
        /// <param name="commandText">Command to execute</param>
        /// <returns><see cref="DataSet"/> containing the resultset</returns>
        public static DataSet ExecuteDataset(SqlConnection connection, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataset(connection, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// Executes a single SQL command and returns the resultset in a <see cref="DataSet"/>.  
        /// The state of the <see cref="SqlConnection"/> object remains unchanged after execution
        /// of this method.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object to use</param>
        /// <param name="commandText">Command to execute</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns><see cref="DataSet"/> containing the resultset</returns>
        public static DataSet ExecuteDataset(SqlConnection connection, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;

            if (commandParameters != null)
                foreach (SqlParameter p in commandParameters)
                    cmd.Parameters.Add(p);

            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            // detach the SqlParameters from the command object, so they can be used again.			
            cmd.Parameters.Clear();

            //return the dataset
            return ds;
        }

        /// <summary>
        /// Updates the given table with data from the given <see cref="DataSet"/>
        /// </summary>
        /// <param name="connectionString">Settings to use for the update</param>
        /// <param name="commandText">Command text to use for the update</param>
        /// <param name="ds"><see cref="DataSet"/> containing the new data to use in the update</param>
        /// <param name="tablename">Tablename in the dataset to update</param>
        public static void UpdateDataSet(string connectionString, string commandText, DataSet ds, string tablename)
        {
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(commandText, cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, tablename);
            cn.Close();
        }

        #endregion

        #region ExecuteDataReader

        /// <summary>
        /// Executes a single command against a MySQL database, possibly inside an existing transaction.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object to use for the command</param>
        /// <param name="transaction"><see cref="SqlTransaction"/> object to use for the command</param>
        /// <param name="commandText">Command text to use</param>
        /// <param name="commandParameters">Array of <see cref="SqlParameter"/> objects to use with the command</param>
        /// <param name="ExternalConn">True if the connection should be preserved, false if not</param>
        /// <returns><see cref="SqlDataReader"/> object ready to read the results of the command</returns>
        private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, string commandText, SqlParameter[] commandParameters, bool ExternalConn)
        {
            //create a command and prepare it for execution
             
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;

            if (commandParameters != null)
                foreach (SqlParameter p in commandParameters)
                    cmd.Parameters.Add(p);

            //create a reader
            SqlDataReader dr;

            // call ExecuteReader with the appropriate CommandBehavior
            if (ExternalConn)
            {
                dr = cmd.ExecuteReader();
            }
            else
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();

            return dr;
        }

        /// <summary>
        /// Executes a single command against a MySQL database.
        /// </summary>
        /// <param name="connectionString">Settings to use for this command</param>
        /// <param name="commandText">Command text to use</param>
        /// <returns><see cref="SqlDataReader"/> object ready to read the results of the command</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteReader(connectionString, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// Executes a single command against a MySQL database.
        /// </summary>
        /// <param name="connectionString">Settings to use for this command</param>
        /// <param name="commandText">Command text to use</param>
        /// <param name="commandParameters">Array of <see cref="SqlParameter"/> objects to use with the command</param>
        /// <returns><see cref="SqlDataReader"/> object ready to read the results of the command</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            try
            {
                //call the private overload that takes an internally owned connection in place of the connection string
                return ExecuteReader(cn, null, commandText, commandParameters, false);
            }
            catch
            {
                //if we fail to return the SqlDatReader, we need to close the connection ourselves
                cn.Close();
                throw;
            }
        }
        #endregion

        #region ExecuteScalar

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connectionString">Settings to use for the update</param>
        /// <param name="commandText">Command text to use for the update</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(string connectionString, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteScalar(connectionString, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connectionString">Settings to use for the command</param>
        /// <param name="commandText">Command text to use for the command</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                //call the overload that takes a connection in place of the connection string
                return ExecuteScalar(cn, commandText, commandParameters);
            }
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object to use</param>
        /// <param name="commandText">Command text to use for the command</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(SqlConnection connection, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteScalar(connection, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object to use</param>
        /// <param name="commandText">Command text to use for the command</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(SqlConnection connection, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;

            if (commandParameters != null)
                foreach (SqlParameter p in commandParameters)
                    cmd.Parameters.Add(p);

            //execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;

        }

        #endregion
    }
}