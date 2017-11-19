using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NTPTest.StackExchange.Common;
using NTPTest.StackExchange.Entity;
using NTPTest.StackExchange.Repository.Common;

namespace NTPTest.StackExchange.Repository
{
    public class QuestionsRepository : IRepository<QuestionEntity>, IDisposable
    {
        #region Class Declarations

        private LoggingHandler _loggingHandler;
        private ConfigurationHandler _configurationHandler;
        private bool _bDisposed;

        #endregion

        #region Class Methods

        private string GetRequestUrlFormated()
        {
            var retunedFormatedRequest = string.Empty;

            retunedFormatedRequest += Order == OrderType.Ascending ? "order=asc" : "order=desc";

            switch (Sort)
            {
                case SortType.Creation:
                    retunedFormatedRequest += "&sort=" + Sort.ToString().ToLower();
                    break;
                case SortType.Activity:
                    retunedFormatedRequest += "&sort=" + Sort.ToString().ToLower();
                    break;
                case SortType.Hot:
                    retunedFormatedRequest += "&sort=" + Sort.ToString().ToLower();
                    break;
                case SortType.Month:
                    retunedFormatedRequest += "&sort=" + Sort.ToString().ToLower();
                    break;
                case SortType.Votes:
                    retunedFormatedRequest += "&sort=" + Sort.ToString().ToLower();
                    break;
                case SortType.Week:
                    retunedFormatedRequest += "&sort=" + Sort.ToString().ToLower();
                    break;
            }

            if (Page != null)
            {
                retunedFormatedRequest += "&page=" + Page;
            }
            if (PageSize != null)
            {
                retunedFormatedRequest += "&pagesize=" + PageSize;
            }
            if (Min != null)
            {
                retunedFormatedRequest += "&min=" + Min;
            }
            if (Max != null)
            {
                retunedFormatedRequest += "&max=" + Max;
            }

            return UrlInitialFilter + "questions?" + retunedFormatedRequest + "&site=stackoverflow";
        }

        private string RequestWebData(string url)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                var response = "";

                using (var webResponse = webRequest.GetResponse())
                using (var sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }

                return response;
            }
            catch (WebException ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("QuestionsRequest::RequestWebData::Error occured.", ex);
            }
        }

        public QuestionEntity SelectItemById(int id)
        {
            var requestUrl = UrlInitialFilter + String.Format("questions/{0}?site=stackoverflow", id);
            
            var jsonData = RequestWebData(requestUrl);
            var allData = JsonConvert.DeserializeObject<Wrapper<QuestionEntity>>(jsonData);

            return allData.Items[0];
        }

        public List<QuestionEntity> SelectItemsFiltered()
        {
            try
            {
                //Format the Request URL
                var requestUrl = GetRequestUrlFormated();

                //Send Request and Get Resulted Response Data
                var responseData = RequestWebData(requestUrl);

                //Now, deserialize returned data
                var allData = JsonConvert.DeserializeObject<Wrapper<QuestionEntity>>(responseData);

                return allData.Items;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("QuestionsRequest::SelectItemsFiltered::Error occured.", ex);
            }
        }

        public Wrapper<QuestionEntity> ProcessResponse(string response)
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

        public QuestionsRepository()
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
