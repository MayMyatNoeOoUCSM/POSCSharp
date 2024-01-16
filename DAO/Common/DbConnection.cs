using System.Data.SQLite;
using System.Configuration;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace DAO.Common
{
    /// <summary>
    /// Defines the <see cref="DbConnection" />.
    /// </summary>
    public class DbConnection
    {
        /// <summary>
        /// Defines the iniPath.
        /// </summary>
        public string iniPath = Consts.FILEPATH;

        /// <summary>
        /// Defines the conStr.
        /// </summary>
        public static string conStr = String.Empty;

        /// <summary>
        /// Defines the conn.
        /// </summary>
        public static SQLiteConnection conn = new SQLiteConnection();

        /// <summary>
        /// Defines the sqliteCmd.
        /// </summary>
        public static SQLiteCommand sqliteCmd = new SQLiteCommand();

        /// <summary>
        /// Defines the adapter.
        /// </summary>
        public static SQLiteDataAdapter adapter = new SQLiteDataAdapter();

        /// <summary>
        /// The GetConnection.
        /// </summary>
        private static string GetConnection(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        /// <summary>
        /// The GetImagePathSring.
        /// </summary>
        /// <param name="folder_name">The folder_name<see cref="string"/>.</param>
        /// <param name="path">The path<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetImagePathSring(string folder_name, string path)
        {
            return GetIniString(folder_name, path, iniPath);
        }

        /// <summary>
        /// The GetPrivateProfileString.
        /// </summary>
        /// <param name="Section">The Section<see cref="string"/>.</param>
        /// <param name="Key">The Key<see cref="string"/>.</param>
        /// <param name="Default">The Default<see cref="string"/>.</param>
        /// <param name="RetVal">The RetVal<see cref="StringBuilder"/>.</param>
        /// <param name="Size">The Size<see cref="int"/>.</param>
        /// <param name="FilePath">The FilePath<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        /// <summary>
        /// The GetIniString.
        /// </summary>
        /// <param name="Section">The Section<see cref="String"/>.</param>
        /// <param name="Keyname">The Keyname<see cref="String"/>.</param>
        /// <param name="IniFile">The IniFile<see cref="String"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetIniString(String Section, String Keyname, String IniFile)
        {
            StringBuilder iniString = new StringBuilder(255);
            GetPrivateProfileString(Section, Keyname, "", iniString, iniString.Capacity, IniFile);
            return iniString.ToString();
        }

        /// <summary>
        /// The ExecuteDataTable.
        /// </summary>
        /// <param name="TypeOfCommand">The TypeOfCommand<see cref="CommandType"/>.</param>
        /// <param name="CmdText">The CmdText<see cref="string"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable ExecuteDataTable(
                                   CommandType TypeOfCommand,
                                   string CmdText
                               )
        {
            DataSet dtSet = new DataSet();
            conStr = GetConnection();
            using (SQLiteConnection sqliteConn = new SQLiteConnection(conStr))
            {
                try
                {
                    if (sqliteConn.State != ConnectionState.Open)
                    {
                        sqliteConn.Open();
                    }
                    sqliteCmd.Connection = sqliteConn;
                    sqliteCmd.CommandText = CmdText;
                    sqliteCmd.CommandType = TypeOfCommand;
                    sqliteCmd.CommandTimeout = 200;

                    adapter = new SQLiteDataAdapter(CmdText, conn);
                    adapter.SelectCommand = sqliteCmd;
                    dtSet.Reset();
                    adapter.Fill(dtSet);
                    sqliteCmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                }
                finally
                {
                    sqliteConn.Close();
                }
            }
            return dtSet.Tables[0];
        }

        /// <summary>
        /// The ExecuteScalar.
        /// </summary>
        /// <param name="TypeOfCommand">The TypeOfCommand<see cref="CommandType"/>.</param>
        /// <param name="CmdText">The CmdText<see cref="string"/>.</param>
        /// <param name="NpgSqlParams">The NpgSqlParams<see cref="NpgsqlParameter[]"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object ExecuteScalar(
                                   CommandType TypeOfCommand,
                                   string CmdText,
                                   SQLiteParameter[] SqliteParams
                               )
        {
            //Create temp object.
            object objTemp = null;
            conStr = GetConnection();
            using (SQLiteConnection sqliteConn = new SQLiteConnection(conStr))
            {
                try
                {
                    sqliteCmd.Connection = sqliteConn;
                    sqliteCmd.CommandType = TypeOfCommand;
                    sqliteCmd.CommandText = CmdText;
                    sqliteCmd.CommandTimeout = 200;

                    if (SqliteParams != null)
                    {
                        foreach (SQLiteParameter SqliteParam in SqliteParams)
                        {
                            SqliteParam.Value = (SqliteParam.Value == null || SqliteParam.Value.ToString() == String.Empty ?
                            DBNull.Value : (object)SqliteParam.Value);
                            sqliteCmd.Parameters.Add(SqliteParam);
                        }
                    }
                    if (sqliteConn.State != ConnectionState.Open)
                    {
                        sqliteCmd.Connection.Open();
                    }
                    //Execute and sets object returned.
                    objTemp = sqliteCmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                }
                finally
                {
                    sqliteCmd.Connection.Close();
                    sqliteCmd.Parameters.Clear();
                }
            }
            // Return from function
            return objTemp;
        }

        /// <summary>
        /// The ExecuteNonQuery.
        /// </summary>
        /// <param name="TypeOfCommand">The TypeOfCommand<see cref="CommandType"/>.</param>
        /// <param name="CmdText">The CmdText<see cref="String"/>.</param>
        /// <param name="NpgSqlParams">The NpgSqlParams<see cref="NpgsqlParameter[]"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public bool ExecuteNonQuery(
                                CommandType TypeOfCommand,
                                String CmdText,
                                SQLiteParameter[] SqliteParams
                                )
        {
            int affectedRow = 0;
            conStr = GetConnection();
            using (SQLiteConnection sqliteConn = new SQLiteConnection(conStr))
            {
                try
                {
                    if (sqliteConn.State != ConnectionState.Open)
                    {
                        sqliteConn.Open();
                    }
                    sqliteCmd.Connection = sqliteConn;
                    sqliteCmd.CommandText = CmdText;
                    sqliteCmd.CommandType = TypeOfCommand;
                    sqliteCmd.CommandTimeout = 200;
                    if (SqliteParams != null)
                    {
                        foreach (SQLiteParameter SqliteParam in SqliteParams)
                        {
                            SqliteParam.Value = (SqliteParam.Value == null || SqliteParam.Value.ToString() == String.Empty ?
                            DBNull.Value : (object)SqliteParam.Value);
                            sqliteCmd.Parameters.Add(SqliteParam);
                        }
                    }
                    affectedRow = sqliteCmd.ExecuteNonQuery();
                    if (sqliteConn.State != ConnectionState.Open)
                    {
                        sqliteCmd.Connection.Open();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                }
                finally
                {
                    sqliteCmd.Parameters.Clear();
                    sqliteCmd.Connection.Close();
                }
            }
            if(affectedRow >0)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        /// <summary>
        /// The ExecuteDataSet.
        /// </summary>
        /// <param name="TypeOfCommand">The TypeOfCommand<see cref="CommandType"/>.</param>
        /// <param name="CmdText">The CmdText<see cref="String"/>.</param>
        /// <returns>The <see cref="DataSet"/>.</returns>
        public DataSet ExecuteDataSet(
                                        CommandType TypeOfCommand,
                                        String CmdText
                                    )
        {
            conStr = GetConnection();
            DataSet dsSet = new DataSet();
            using (SQLiteConnection sqliteConn = new SQLiteConnection(conStr))
            {
                try
                {
                    // Execute the command
                    sqliteCmd.Connection = sqliteConn;
                    sqliteCmd.CommandText = CmdText;
                    sqliteCmd.CommandType = TypeOfCommand;
                    sqliteCmd.CommandTimeout = 200;
                    if (sqliteConn.State != ConnectionState.Open)
                    {
                        sqliteCmd.Connection.Open();
                    }
                    adapter.SelectCommand = sqliteCmd;
                    adapter.Fill(dsSet);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                }
                finally
                {
                    sqliteCmd.Connection.Close();
                }
            }
            // Return from function
            return dsSet;
        }

        /// <summary>
        /// ExecuteQuery
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="conStr"></param>
        /// <returns></returns>
        public bool ExecuteQuery(string strQuery, string conStr)
        {
            bool bstatus = false;
            try
            {
                SQLiteConnection m_sqlConnection = new SQLiteConnection(conStr);
                int snReturnValue = 0;
                try
                {
                    if (m_sqlConnection.State != ConnectionState.Open)
                        m_sqlConnection.Open();
                    if (m_sqlConnection.State == ConnectionState.Open)
                    {
                        SQLiteCommand objSqlCommand = new SQLiteCommand(strQuery, m_sqlConnection);

                        snReturnValue = objSqlCommand.ExecuteNonQuery();
                        if (snReturnValue == -1)
                            bstatus = false;
                        else
                            bstatus = true;
                    }
                    if (m_sqlConnection.State == ConnectionState.Open)
                        m_sqlConnection.Close();

                    if (m_sqlConnection != null)
                        m_sqlConnection.Dispose();
                }
                catch (Exception ex)
                {
                    bstatus = false;
                    if (m_sqlConnection.State == ConnectionState.Open)
                        m_sqlConnection.Close();

                    if (m_sqlConnection != null)
                        m_sqlConnection.Dispose();
                }
            }
            catch (Exception ex)
            { }
            return bstatus;
        }

        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="TypeOfCommand"></param>
        /// <param name="CmdText"></param>
        /// <param name="conStr"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(
                                        CommandType TypeOfCommand,
                                        String CmdText,
                                        string conStr
                                    )
        {
            DataSet dsSet = new DataSet();
            using (SQLiteConnection sqliteConn = new SQLiteConnection(conStr))
            {
                try
                {
                    sqliteCmd.Connection = sqliteConn;
                    sqliteCmd.CommandText = CmdText;
                    sqliteCmd.CommandType = TypeOfCommand;
                    sqliteCmd.CommandTimeout = 200;
                    if (sqliteConn.State != ConnectionState.Open)
                    {
                        sqliteCmd.Connection.Open();
                    }
                    adapter.SelectCommand = sqliteCmd;
                    adapter.Fill(dsSet);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                }
                finally
                {
                    sqliteCmd.Connection.Close();
                }
            }
            // Return from function
            return dsSet;
        }
    }
}
