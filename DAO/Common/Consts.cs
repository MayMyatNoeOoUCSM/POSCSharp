using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace DAO.Common
{
    /// <summary>
    /// Defines the <see cref="Consts" />.
    /// </summary>
    public class Consts
    {
        /// <summary>
        /// Defines the FORMPOINTFLAG.
        /// </summary>
        public static bool FORMPOINTFLAG = false;

        /// <summary>
        /// Defines the STAFFID.
        /// </summary>
        public static Int64 STAFFID = 0;

        /// <summary>
        /// Defines the SHOPID.
        /// </summary>
        public static Int64 SHOPID = 0;

        /// <summary>
        /// Defines the SALEID.
        /// </summary>
        public static Int64 SALEID = 0;

        /// <summary>
        /// Defines the ROUNDTO.
        /// </summary>
        public static string ROUNDTO = "N0";

        /// <summary>
        /// Defines the CURRENCYFORMAT.
        /// </summary>
        public static string CURRENCYFORMAT = "{0:C0}";

        /// <summary>
        /// Defines the TERMINALID.
        /// </summary>
        public static int TERMINALID = 0;

        /// <summary>
        /// Defines the FORMNAME.
        /// </summary>
        public static string FORMNAME = String.Empty;

        /// <summary>
        /// Defines the REPORTNAME.
        /// </summary>
        public static string REPORTNAME = String.Empty;

        /// <summary>
        /// Defines the DAMAGELOSSSTATUS.
        /// </summary>
        public static int DAMAGELOSSSTATUS = 0;

        /// <summary>
        /// Defines the INVOICESTATUS.
        /// </summary>
        public static int INVOICESTATUS = 0;

        /// <summary>
        /// Defines the TRANSFERSTATUS.
        /// </summary>
        public static int TRANSFERSTATUS = 0;

        /// <summary>
        /// Defines the INIPATH.
        /// </summary>
        public static string INIPATH = "/Config/system.ini";

        /// <summary>
        /// Defines the BASEPATH.
        /// </summary>
        public static string BASEPATH = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        /// <summary>
        /// Defines the FILEPATH.
        /// </summary>
        public static string FILEPATH = Path.Combine(BASEPATH + INIPATH);

        /// <summary>
        /// Defines the DATEFORMAT.
        /// </summary>
        public static string DATEFORMAT = "yyyy-MM-dd";

        /// <summary>
        /// Defines the SHOWDATEFORMAT.
        /// </summary>
        public static string SHOWDATEFORMAT = "dd/MM/yyyy";

        /// <summary>
        /// Defines the DEFAULTDATE.
        /// </summary>
        public static string DEFAULTDATE = "0001-01-01";

        /// <summary>
        /// Defines the APPEXITTYPE.
        /// </summary>
        public enum APPEXITTYPE
        {
            /// <summary>
            /// Defines the LOGOUT.
            /// </summary>
            LOGOUT,
            /// <summary>
            /// Defines the TERMINATE.
            /// </summary>
            TERMINATE,
            /// <summary>
            /// Defines the SHUTDOWN.
            /// </summary>
            SHUTDOWN,
            /// <summary>
            /// Defines the UNKNOWN.
            /// </summary>
            UNKNOWN
        }

        /// <summary>
        /// Defines the EXITTYPE.
        /// </summary>
        public static APPEXITTYPE EXITTYPE;

        /// <summary>
        /// Defines the Country Code.........
        /// </summary>
        public static int COUNTRYCODE = 883;

        /// <summary>
        /// Defines the Country Code.........
        /// </summary>
        public static string PRODUCTCODE = "0001";

        /// <summary>
        /// Defines the FROMDATE.
        /// </summary>
        public static string FROMDATE = String.Empty;

        /// <summary>
        /// Defines the TODATE.
        /// </summary>
        public static string TODATE = String.Empty;

        /// <summary>
        /// Defines the CATEGORYID.
        /// </summary>
        public static string CATEGORYID;

        /// <summary>
        /// Defines the SALEPAGECOUNT.
        /// </summary>
        public static int SALEPAGECOUNT = 0;

        /// <summary>
        /// Defines the PRODUCTSTAUTS.
        /// </summary>
        public static int PRODUCTSTAUTS = 1;

        /// <summary>
        /// Defines the WAREHOUSEID.
        /// </summary>
        public static Int64 WAREHOUSEID = 0;

        /// <summary>
        /// Defines the TEMPID.
        /// </summary>
        public static Int64 TEMPID = 0;

        /// <summary>
        /// Defines the RETURNID ....
        /// </summary>
        public static Int64? RETURNID = null;//for sale return id

        /// <summary>
        /// Defines the WARNINGDAY.
        /// </summary>
        public static int WARNINGDAY = 0;

        /// <summary>
        /// Defines the DAYS.
        /// </summary>
        public static int DAYS = 0;

        /// <summary>
        /// Defines the LANGUAGEID.
        /// </summary>
        public static int LANGUAGEID = 0;

        /// <summary>
        /// Defines the CHKACTIVE.
        /// </summary>
        public static int CHKACTIVE = 0;
    }
}
