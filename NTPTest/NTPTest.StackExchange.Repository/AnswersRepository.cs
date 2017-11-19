using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTPTest.StackExchange.Common;
using NTPTest.StackExchange.Entity;
using NTPTest.StackExchange.Repository.Common;

namespace NTPTest.StackExchange.Repository
{
    public class AnswersRepository : IRepository<AnswerEntity>, IDisposable
    {
        #region Class Declarations

        private LoggingHandler _loggingHandler;
        private ConfigurationHandler _configurationHandler;
        private bool _bDisposed;

        #endregion

        #region Class Methods

        public AnswerEntity SelectItemById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AnswerEntity> SelectItemsFiltered()
        {
            throw new NotImplementedException();
        }

        public Wrapper<AnswerEntity> ProcessResponse(string response)
        {
            throw new NotImplementedException();
        }

        public bool VerifyRequiredParameters()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool bDisposing)
        {
            // Check to see if Dispose has already been called.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Dispose managed resources.
                    _configurationHandler = null;
                    _loggingHandler = null;
                }
            }
            _bDisposed = true;
        }

        public AnswersRepository()
        {
            _configurationHandler = new ConfigurationHandler();
            _loggingHandler = new LoggingHandler();
            UrlInitialFilter = _configurationHandler.StackApiUrl;
        }

        #endregion

        #region Class Properties

        public string UrlInitialFilter { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string Site { get; set; }
        public OrderType Order { get; set; }
        public SortType Sort { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        #endregion
    }
}
