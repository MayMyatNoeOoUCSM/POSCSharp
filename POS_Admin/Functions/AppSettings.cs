using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Admin.Functions
{
    /// <summary>
    /// Defines the <see cref="AppSettings" />.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// The GetSetting.
        /// </summary>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// The SetSetting.
        /// </summary>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <param name="value">The value<see cref="string"/>.</param>
        public void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
