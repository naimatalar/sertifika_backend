using Labote.Core.BindingModels;
using System;
using System.Collections.Generic;

namespace Labote.Api.BindingModel.RequestModel
{
    public class GetAllDocumentRequestModel : BasePaginationRequestModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DocumentNo { get; set; } = null;
        public bool? IsCertificate { get; set; } = null;
        public bool? IsReport { get; set; } = null;
        public string Name { get; set; } = null;

        public List<string> DocumentKind { get; set; } = new List<string>();
        public string DocumentBelongName { get; set; } = null;
    }
}
