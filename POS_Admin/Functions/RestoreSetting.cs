using DAO.Common;
using POS_Admin.Properties;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace POS_Admin.Functions
{
    //using POS_Admin.Config;
    using DAO.Common;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="RestoreSetting" />.
    /// </summary>
    class RestoreSetting
    {
        /// <summary>
        /// Defines the strDatabaseName.
        /// </summary>
        string strDatabaseName = "POSInventoryDB";

        /// <summary>
        /// Defines the strPG_dumpPath.
        /// </summary>
        String strPG_dumpPath = String.Empty;

        /// <summary>
        /// Defines the strInstallLocation.
        /// </summary>
        string strInstallLocation = string.Empty;

        /// <summary>
        /// Defines the strBackupFilePath.
        /// </summary>
        string strBackupFilePath = string.Empty;

        /// <summary>
        /// Defines the strConnection.
        /// </summary>
        string strConnection = "Server=localhost;Port=5432;Database=postgres;Userid=postgres;Password=admin;";

        /// <summary>
        /// Defines the strServer.
        /// </summary>
        string strServer = string.Empty;

        /// <summary>
        /// Defines the strPort.
        /// </summary>
        string strPort = string.Empty;

        /// <summary>
        /// Defines the sbPG_dumpPath.
        /// </summary>
        StringBuilder sbPG_dumpPath = new StringBuilder();

        /// <summary>
        /// Defines the dbConnection.
        /// </summary>
        private DbConnection dbConnection = new DbConnection();

        /// <summary>
        /// The RestoreDatabase.
        /// </summary>
        public void RestoreDatabase()
        {
            try
            {                
                int start = strConnection.IndexOf("Server");
                start = start + ("Server").Length + 1;
                int end = strConnection.IndexOf(";", start);
                end = end - start;
                strServer = strConnection.Substring(start, end);

                start = strConnection.IndexOf("Port");
                start = start + ("Port").Length + 1;
                end = strConnection.IndexOf(";", start);
                end = end - start;
                strPort = strConnection.Substring(start, end);

                //check for the pre-requisites before restoring the database.*********
                if (strDatabaseName != "")
                {
                    // Do not change lines / spaces b/w words.
                    //StreamWriter sw = new StreamWriter(@"DBRestore.bat");
                    //string path = @"C:\Program Files (x86)\Backup\posdb.backup";
                    //Do not change lines / spaces b / w words.
                     StringBuilder strSB = new StringBuilder(strPG_dumpPath);
                    if (strSB.Length != 0)
                    {
                        //MessageBox.Show("hello");
                        checkDBExists(strDatabaseName);
                        //strSB.Append("pg_restore.exe --host " + strServer + " --port " + strPort + " --username postgres --dbname");
                        //strSB.Append(" \"" + strDatabaseName + "\"");
                        //strSB.Append(" --verbose ");
                        //strSB.Append("\"" + path + "\"");
                        //sw.WriteLine(strSB);
                        //sw.Dispose();
                        //sw.Close();
                        //MessageBox.Show("hello1");
                        Process processDB = Process.Start("DBRestore.bat");
                        do
                        {//dont perform anything
                        }
                        while (!processDB.HasExited);
                        {
                            MessageBox.Show(DAO.Common.Messages.I0021, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }                    
                }

            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// The checkDBExists.
        /// </summary>
        /// <param name="strdatabase">The strdatabase<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool checkDBExists(string strdatabase)
        {
            try
            {
                string strSql = "SELECT datname FROM pg_database WHERE datistemplate IS FALSE AND datallowconn IS TRUE AND datname!='postgres';";
                DataSet ds = new DataSet();
                ds = dbConnection.ExecuteDataSet(CommandType.Text, strSql,strConnection);
                bool databaseExists = false;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][0].ToString() == strdatabase)
                    {
                        databaseExists = true;
                        break;
                    }
                }
                if (databaseExists)//existing database
                {
                    //close the DB connections
                    string str = "select pg_terminate_backend(procpid) from pg_stat_activity where datname='" + strdatabase + "'";
                    dbConnection.ExecuteQuery(str,strConnection);
                    //drop the database
                    string str1 = "drop database \"" + strdatabase + "\" ";
                    dbConnection.ExecuteQuery(str1, strConnection);

                    string str2 = "create database \"" + strdatabase + "\" ";
                    dbConnection.ExecuteQuery(str2, strConnection);

                    return true;
                }
                else//new database
                {
                    //create the database
                    string str = "create database \"" + strdatabase + "\" ";
                    dbConnection.ExecuteQuery(str, strConnection);
                    Thread.Sleep(1000);
                    return true;
                }

                //return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// The PG_DumpExePath.
        /// </summary>
        private void PG_DumpExePath()
        {
            try
            {
                // Do not change lines / spaces b/w words.
                if (sbPG_dumpPath.Length == 0)
                {
                    //string strPG_dumpPath = string.Empty;
                    if (strPG_dumpPath == string.Empty)
                    {
                        strPG_dumpPath = LookForFile("pg_dump.exe");
                        if (strPG_dumpPath == string.Empty)
                        {
                            MessageBox.Show(DAO.Common.Messages.I0024, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    int a = strPG_dumpPath.IndexOf(":\\", 0);
                    a = a + 2;
                    string strSub = strPG_dumpPath.Substring(0, (a - 2));
                    strPG_dumpPath = strPG_dumpPath.Substring(a, (strPG_dumpPath.Length - a));

                    StringBuilder sbSB1 = new StringBuilder(strPG_dumpPath);
                    sbSB1.Replace("\\", "\r\n\r\ncd ");

                    StringBuilder sbSB2 = new StringBuilder("cd /D ");
                    sbSB2.Append(strSub);
                    sbSB2.Append(":\\");

                    sbSB1 = sbSB2.Append(sbSB1);
                    sbSB1 = sbSB1.Remove((sbSB1.Length - 3), 3);
                    sbPG_dumpPath = sbSB1;
                    strPG_dumpPath = sbSB1.ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// The LookForFile.
        /// </summary>
        /// <param name="strFileName">The strFileName<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string LookForFile(string strFileName)
        {
            string strPG_dumpPath = string.Empty;
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    strPG_dumpPath = performFileSearchTask(drive.Name, strFileName);
                    if (strPG_dumpPath.Length != 0)
                        break;
                }

            }
            catch (Exception ex)
            { }
            return strPG_dumpPath;
        }

        /// <summary>
        /// The performFileSearchTask.
        /// </summary>
        /// <param name="dirName">The dirName<see cref="string"/>.</param>
        /// <param name="strfileName">The strfileName<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string performFileSearchTask(string dirName, string strfileName)
        {
            try
            {
                if (strPG_dumpPath.Length == 0)
                {
                    try
                    {

                        foreach (string ddir in Directory.GetDirectories(dirName))
                        {
                            System.Security.Permissions.FileIOPermission ReadPermission =
                                new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, ddir);
                            if (System.Security.SecurityManager.IsGranted(ReadPermission))
                            {
                                try
                                {
                                    foreach (string dfile in Directory.GetFiles(ddir, strfileName))
                                    {
                                        strPG_dumpPath = ddir + "\\";
                                        if (strPG_dumpPath.Length > 0)
                                        {
                                            strInstallLocation = strPG_dumpPath;
                                            break;
                                        }
                                    }
                                    if (strPG_dumpPath.Length == 0)
                                        performFileSearchTask(ddir, strfileName);
                                }
                                catch (Exception ex)
                                { }
                            }
                            if (strPG_dumpPath != string.Empty)
                                break;
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception ex)
            { }
            return strPG_dumpPath;
        }

        /// <summary>
        /// The InitializeDatabase.
        /// </summary>
        public void InitializeDatabase()
        {
            try
            {
                DataSet dsDB = new DataSet();
                dsDB = dbConnection.ExecuteDataSet(CommandType.Text, "SELECT datname FROM pg_database WHERE datistemplate IS FALSE AND datallowconn IS TRUE AND datname!='postgres';",strConnection);
                if (dsDB != null)
                {
                    if (dsDB.Tables[0].Rows.Count == 0)
                    {
                        CheckPostgresServer();
                        RestoreDatabase();
                    }
                }                
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// The CheckPostgresServer.
        /// </summary>
        private void CheckPostgresServer()
        {

            try
            {
                if (sbPG_dumpPath.Length == 0)
                {

                    bool bPostgresService = false;
                    ServiceController[] services = ServiceController.GetServices();
                    // try to find service name
                    foreach (ServiceController service in services)
                    {
                        if (service.ServiceName.Contains("postgre") == true)
                        {
                            bPostgresService = true;
                            break;
                        }
                    }
                    if (bPostgresService == true)
                    {
                        PG_DumpExePath();
                        if (sbPG_dumpPath.Length != 0)
                        {
                            MessageBox.Show(DAO.Common.Messages.I0022, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show(DAO.Common.Messages.I0023, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
