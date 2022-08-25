using Labote.Core.BindingModels;
using System;

namespace Labote.Api.BindingModel.RequestModel
{
    public class GetAllDocumentRequestModel:BasePaginationRequestModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
