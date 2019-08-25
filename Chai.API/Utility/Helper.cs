using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Chai.API.Utility
{
    public static class Helper
    {
        /// <summary>
        /// Get Connection String value
        /// </summary>
        /// <param name="name">connection string name</param>
        /// <returns>connection string value</returns>
        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Gets AppSetting value from Configuration
        /// </summary>
        /// <param name="key">Key for key-value pair</param>
        /// <returns>AppSetting value given the key</returns>
        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}