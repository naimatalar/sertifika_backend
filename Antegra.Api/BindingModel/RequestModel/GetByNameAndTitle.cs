using Labote.Core.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.BindingModel.RequestModel
{
    public class GetByNameAndTitle:BasePaginationRequestModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
