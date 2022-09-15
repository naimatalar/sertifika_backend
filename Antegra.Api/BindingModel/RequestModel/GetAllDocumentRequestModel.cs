using Labote.Core.BindingModels;
using System;

namespace Labote.Api.BindingModel.RequestModel
{
    public class GetAllDocumentRequestModel:BasePaginationRequestModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DocumentNo { get; set; } = null;
        public bool? IsCertificate { get; set; } = null;
        public bool? IsReport { get; set; } = null;
        public string Name { get; set; } = null;

        public int? DocumentKind { get; set; } = null;
        public string DocumentBelongName { get; set; } = null;
    }
}
