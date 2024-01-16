//<copyright file ="Encryption.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>2021/06/04</date>

using POS_Admin.Properties;
using DAO.Common;
using Services.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace POS_Admin.Utilities
{
    //<copyright file ="Encryption.cs"  company ="Seattle Consulting Myanmar">
    //Copyright(c) 2021  All Rights Reserved
    //</copyright>
    //<author> NAWZIN-PC\Naw Zin Marlar Win </author>
    //<date>2021/06/04</date>

    /// <summary>
    /// Defines the <see cref="Encryption" />.
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Defines the _privateKey.
        /// </summary>
        private static string _privateKey = "<RSAKeyValue><Modulus>0NPenqnadpPsgGwydsBdM7L3sp/B4WlPQJeIzVke2vLC2DeivTnrrBlBmppz1lHwh1LLEw9nm0+hoda8AGF77jaLRYF6OyozGrva5kYZzzClGF9Un2AET0QQSTSZWrmUyLz40t/XIraT2wLp75zeuk/kbebv5lTOMpx+pprKh+0=</Modulus><Exponent>AQAB</Exponent><P>2FoEjz6VH32dnzptb2MncQbZgiuTiFDnYCFDZ6n4nVrPTfCD1roY6PMx4Gu8+Nux5cZHY20vHmEx7xdA+aPw4w==</P><Q>9xjeMafayQen9SGryLzRHyJnyGGVp9oUIfgosDFCOf5yq7QWPNyer61ZUrquuHofyOA1ATmN0x658e3ja2YM7w==</Q><DP>oMCp+KFAfiiA0InCPGxJJxM21CB6u2OZt3Sft8u0PX7232thGlAmKBhjK+QBgksC8L6V1ouO4hzH1GXL0nF8jw==</DP><DQ>jaMFijULJfxrfAmm7FO/EzengabeH+7TZ31V5Vj2+0Ms+9sofA6CL3UQJGm5ySjHm19ZQrB46TFNqK2RlHhUpQ==</DQ><InverseQ>RjgTz8F6j8Z6W0uSv6klcRewP6qXnpxarkmoivVoTeG/fD8L4rRFLnGtmkTi/Ae8ckVljB7hO/CelFpZ7AZq3Q==</InverseQ><D>uIcvhbaDpBpsdsKlCQhMk12GwWGoGf5LmMEOkp44xLKVeCgZdupSlT2wGeR3jZ/UUk/XwJzxKW2BXxf4AsIhljE3fDO9pXMBH4SJ6Lp71ar0I4dqBcacXQXdlV9LpbLsdNXve00Jc14A3bqygsTDswSgTuOYsKjex2PsKCJFZAU=</D></RSAKeyValue>";

        /// <summary>
        /// Defines the _encoder.
        /// </summary>
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        /// <summary>
        /// The GetRandomSalt.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        /// <summary>
        /// The PasswordEncrypt.
        /// </summary>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string PasswordEncrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        /// <summary>
        /// The ValidatePassword.
        /// </summary>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <param name="correctHash">The correctHash<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

        /// <summary>
        /// The GetCheckExpire.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool GetCheckExpire()
        {
            bool isValid = false;
            string[] strLines;
            string companyName = String.Empty;
            var strList = new List<string>();
            AuthService authService = new AuthService();
            var fileStream = new FileStream(@"D:\extension.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    strList.Add(line);
                }
            }
            strLines = strList.ToArray();

            string[] decryptedValueArray = new string[strLines.Length];

            for (int i = 0; i < strLines.Length; i++)
            {
                decryptedValueArray[i] = RSADecrypt(strLines[i]);

            }
            DateTime realDate;
            //if (CheckNet())
            //{
            //    realDate = GetNetworkTime();
            //}
            //else
            //{
            //    realDate = DateTime.Now.Date;
            //}
            realDate = DateTime.Now.Date;
            companyName = authService.GetCompany().ToString();
            if (String.Equals(companyName, decryptedValueArray[1]))
            {
                var dateFrom = DateTime.ParseExact(decryptedValueArray[0], Consts.DATEFORMAT, CultureInfo.InvariantCulture);
                var dateTo = DateTime.ParseExact(realDate.ToString(Consts.DATEFORMAT), Consts.DATEFORMAT, CultureInfo.InvariantCulture);
                var result = (dateFrom - dateTo).TotalDays;
                if (result < 0)
                {
                    return true;
                }
                else if (result <= 7)
                {
                    Consts.WARNINGDAY = Convert.ToInt16((Convert.ToDateTime(decryptedValueArray[0]) - realDate).TotalDays);
                    return isValid;
                }
                else
                {
                    return isValid;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// The RSADecrypt.
        /// </summary>
        /// <param name="data">The data<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        static string RSADecrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();

            var encryptedData = Convert.FromBase64String(data);

            var dataArray = encryptedData;
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(_privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        /// <summary>
        /// The GetNetworkTime.
        /// </summary>
        /// <returns>The <see cref="DateTime"/>.</returns>
        public static DateTime GetNetworkTime()
        {
            const string ntpServer = "pool.ntp.org";
            var ntpData = new byte[48];
            ntpData[0] = 0x1B; //LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
            ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);

            return networkDateTime;
        }

        /// <summary>
        /// The InternetGetConnectedState.
        /// </summary>
        /// <param name="Description">The Description<see cref="int"/>.</param>
        /// <param name="ReservedValue">The ReservedValue<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        /// <summary>
        /// The CheckNet.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool CheckNet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
    }
}
