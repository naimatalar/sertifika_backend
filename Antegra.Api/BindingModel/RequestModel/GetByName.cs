using Labote.Core.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.BindingModel.RequestModel
{
    public class GetByName:BasePaginationRequestModel
    {
        public string Name { get; set; }
    }
}
