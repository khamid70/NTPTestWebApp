using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTPTest.StackExchange.Common
{
    /// <summary>
    /// Represents a Stack Exchange API configuration for use with API requests.
    /// </summary>
    public class ConfigurationHandler: IDisposable
    {
        #region Class Declarations

        private const string StackApiApiBaseUrl = "{Protocol}://api.stackexchange.com/{Version}/";

        /// <summary>
        /// This is the upper bound of the Page Size for <b>most</b> requests. Currently 100.
        /// </summary>
        public const int MaxPageSize = 100;

        #endregion

        #region Class Methods

        /// <summary>
        /// Purpose: ConfigurationHandler class constructor
        /// </summary>
        public ConfigurationHandler()
        {
            InitConfigurationHandler();
        }

        /// <summary>
        /// Purpose: Implements the IDispose interface.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        private void InitConfigurationHandler()
        {
            StackApiAccessKey = GetAppSettingsValueByKey("NTPTest.StackApiAccessKey");
            StackApiVersion = GetAppSettingsValueByKey("NTPTest.StackApiVersion");
            StackApiUseHttps = bool.Parse(GetAppSettingsValueByKey("NTPTest.StackApiUseHttps").ToLower());
            StackApiUrl = StackApiApiBaseUrl.Replace("{Protocol}", StackApiUseHttps ? "https" : "http").Replace("{Version}", StackApiVersion);
        }

        public string GetAppSettingsValueByKey(string sKey)
        {
            try
            {
                if (string.IsNullOrEmpty(sKey))
                    throw new ArgumentNullException("sKey", "The AppSettings key name can't be Null or Empty.");

                if (ConfigurationManager.AppSettings[sKey] == null)
                    throw new ConfigurationErrorsException(string.Format("Failed to find the AppSettings Key named '{0}' in app/web.config.", sKey));

                return ConfigurationManager.AppSettings[sKey].ToString();
            }
            catch (Exception ex)
            {
                //bubble error.
                throw new Exception("ConfigurationHandler::GetAppSettingsValueByKey:Error occured.", ex);
            }
        }

        #endregion

        #region Class Properties

        

        /// <summary>
        /// Represents the base endpoint for the Stack Exchange API url.
        /// </summary>
        public string StackApiUrl { get; set; }


        
        /// <summary>
        /// If true then the HTTPS protocol will be used, otherwise the HTTP protocol will be used.
        /// </summary>
        public bool StackApiUseHttps { get; set; }

        /// <summary>
        /// Determines what version of the Stack Exchange API will be used.
        /// </summary>
        public string StackApiVersion { get; set; }

        /// <summary>
        /// The application API key. Can be <code>null</code> for anonymous requests.
        /// </summary>
        public string StackApiAccessKey { get; set; }



        #endregion
    }
}
