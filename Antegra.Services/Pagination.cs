using Labote.Core.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Services
{
    public static class Pagination
    {
        public static dynamic CreatePagination(this IQueryable<dynamic> data, BasePaginationRequestModel model )
        {

             return new { List = data.Skip((model.PageNumber - 1) * (model.PageSize - 1)).Take(model.PageSize).ToList(), TotalCount = (data.Count() / model.PageSize) + 1, PageNumber = model.PageNumber };
        }
    }
}
