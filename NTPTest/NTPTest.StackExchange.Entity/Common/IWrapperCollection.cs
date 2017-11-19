using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NTPTest.StackExchange.Entity.Common
{
    public interface IWrapperCollection<TEntity> where TEntity : class
    {
        /// <summary>
        /// A list of the objects returned by the API request.
        /// </summary>
        [DataMember(Name = "items")]
        List<TEntity> Items { get; set; }

        /// <summary>
        /// Whether or not <see cref="Items"/> returned by this request are the end of the pagination or not.
        /// </summary>
        [DataMember(Name = "has_more")]
        bool? HasMore { get; set; }

        /// <summary>
        /// The maximum number of API requests that can be performed in a 24 hour period.
        /// </summary>
        [DataMember(Name = "quota_max")]
        int? QuotaMax { get; set; }

        /// <summary>
        /// The remaining number of API requests that can be performed in the current 24 hour period.
        /// </summary>
        [DataMember(Name = "quota_remaining")]
        int? QuotaRemaining { get; set; }

        /// <summary>
        /// Gets the total objects that meet the request's criteria.
        /// </summary>
        [DataMember(Name = "total")]
        int? Total { get; set; }

    }
}
