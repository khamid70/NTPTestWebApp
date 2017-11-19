using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTPTest.StackExchange.Common
{
    /// <summary>
    /// Purpose: General purposes class for creating and handling Logging data.
    /// </summary
    public class LoggingHandler: IDisposable
    {
        #region Class Declarations
        
        #endregion

        #region Class Methods

        private void InitLoggingHandlerClass()
        {
            try
            {
                using (var configHandler = new ConfigurationHandler())
                {
                    EnableLogging = bool.Parse(configHandler.GetAppSettingsValueByKey("NTPTest.EnableLogging").ToLower());
                    LoggingPath = configHandler.GetAppSettingsValueByKey("NTPTest.LoggingPath");
                }
            }
            catch (Exception ex)
            {
                //bubble error.
                throw new Exception("LoggingHandler::InitLoggingHandlerClass:Error occured.", ex);
            }
        }

        public void LogEntry(string loggedText, bool bIsError = false)
        {
            if (EnableLogging)
            {
                if (bIsError)
                {
                    FileHandler.WriteFile(LoggingPath, DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.") + "Error.txt", loggedText);
                }
                else
                {
                    FileHandler.WriteFile(LoggingPath, DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.") + "Log.txt", loggedText);
                }
            }
        }

        public LoggingHandler()
        {
            InitLoggingHandlerClass();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Class Properties

        public bool EnableLogging { get; set; }
        public string LoggingPath { get; set; }

        #endregion
    }
}
