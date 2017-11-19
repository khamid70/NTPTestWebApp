using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTPTest.StackExchange.Common;
using NTPTest.StackExchange.Entity;

namespace NTPTest.StackExchange.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity SelectItemById(int id);
        List<TEntity> SelectItemsFiltered();

        Wrapper<TEntity> ProcessResponse(string response);

        bool VerifyRequiredParameters();

        string UrlInitialFilter { get; set; }
        int? Page { get; set; }
        int? PageSize { get; set; }
        string Site { get; set; }
        OrderType Order { get; set; }
        SortType Sort { get; set; }
        int? Min { get; set; }
        int? Max { get; set; }
        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }

    }
}
