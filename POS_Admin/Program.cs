using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;
using POS_Admin.Functions;
using Services.License;
using System.Data;
using POS_Admin.Views;
using DAO.Common;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace POS_Admin
{
    static class Program
    {
        /// <summary>
        /// Defines the log.
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Defines the appGuid.
        /// </summary>
        public static string appGuid = "e15f11fe-475b-42c8-ba30-9aa39a6297cf";

        /// <summary>
        /// Defines the licenseService.
        /// </summary>
        private static LicenseService licenseService = new LicenseService();

        /// <summary>
        /// Defines the dtLicense.
        /// </summary>
        private static DataTable dtLicense = new DataTable();


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]     
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    log.Warn(String.Format("{0}:{1}", DateTime.Now.ToLongDateString(), DAO.Common.Messages.W0027));
                    MessageBox.Show(DAO.Common.Messages.W0027, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                GC.Collect();
                // Add handler to handle the exception raised by main threads
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                // Add handler to handle the exception raised by additional threads
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                RestoreSetting restoreSetting = new RestoreSetting();
                restoreSetting.InitializeDatabase();

                dtLicense = licenseService.GetLicenseList();
                if (dtLicense.Rows.Count > 0)
                {
                    string keys;
                    keys = dtLicense.Rows[0]["license_key"].ToString();
                    SKGL.Validate validate = new SKGL.Validate();
                    validate.Key = keys;
                    Consts.DAYS = validate.DaysLeft;
                    if (Consts.DAYS > 0)
                    {
                        Application.Run(new FrmLoginForm());
                    }
                    else
                    {
                        if (MessageBox.Show(DAO.Common.Messages.W0077, DAO.Common.Messages.T0002, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            licenseService.UpdateLicenseKey();
                            ExtendLicenseForm licenseForm = new ExtendLicenseForm();
                            licenseForm.ShowDialog();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    ExtendLicenseForm licenseForm = new ExtendLicenseForm();
                    licenseForm.ShowDialog();
                    dtLicense = licenseService.GetLicenseList();
                    if (dtLicense.Rows.Count > 0)
                    {
                        Application.Run(new FrmLoginForm());
                    }
                }
            }
        }

        /// <summary>
        /// The Application_ThreadException.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.Threading.ThreadExceptionEventArgs"/>.</param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ShowExceptionDetails(e.Exception);
        }

        /// <summary>
        /// The CurrentDomain_UnhandledException.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="UnhandledExceptionEventArgs"/>.</param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowExceptionDetails(e.ExceptionObject as Exception);
            // Suspend the current thread for now to stop the exception from throwing.
            Thread.CurrentThread.Suspend();
        }

        /// <summary>
        /// The ShowExceptionDetails.
        /// </summary>
        /// <param name="ex">The ex<see cref="Exception"/>.</param>
        static void ShowExceptionDetails(Exception ex)
        {
            // Do logging of exception details
            var exDetail = String.Format(
                            ex.Message,
                            Environment.NewLine,
                            ex.Source,
                            ex.StackTrace,
                            ex.InnerException);

            MessageBox.Show(exDetail);

            log.Error(string.Format("{0}:{1}", DateTime.Now.ToLongDateString(), exDetail));
            MessageBox.Show(DAO.Common.Messages.E0003, DAO.Common.Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// The Application_ApplicationExit.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            switch (Consts.EXITTYPE)
            {
                case Consts.APPEXITTYPE.LOGOUT:
                    log.Info(string.Format("Staff \"{0}\" " + DAO.Common.Messages.I0012 + Environment.NewLine, Consts.STAFFID));
                    break;

                case Consts.APPEXITTYPE.SHUTDOWN:
                    log.Info(string.Format("Staff \"{0}\" " + DAO.Common.Messages.I0013 + Environment.NewLine, Consts.STAFFID));
                    break;

                case Consts.APPEXITTYPE.TERMINATE:
                    log.Info(string.Format("Staff \"{0}\" " + DAO.Common.Messages.I0014 + Environment.NewLine, Consts.STAFFID));
                    break;

                case Consts.APPEXITTYPE.UNKNOWN:
                    log.Info(string.Format("\"{0}\" " + Messages.I0015 + Environment.NewLine, Consts.STAFFID));
                    break;
            }
        }
    }
}

