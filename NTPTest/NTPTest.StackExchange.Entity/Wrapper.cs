using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NTPTest.StackExchange.Entity.Common;

namespace NTPTest.StackExchange.Entity
{
    [DataContract]
    public class Wrapper<TEntity> : IWrapperCollection<TEntity>, IDisposable where TEntity : class
    {
        #region Class Declarations

        #endregion

        #region Class Methods

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Class Properties

        [JsonProperty("items")]
        public List<TEntity> Items { get; set; }

        [JsonProperty("has_more")]
        public bool? HasMore { get; set; }

        [JsonProperty("quota_max")]
        public int? QuotaMax { get; set; }

        [JsonProperty("quota_remaining")]
        public int? QuotaRemaining { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        #endregion
    }
}
