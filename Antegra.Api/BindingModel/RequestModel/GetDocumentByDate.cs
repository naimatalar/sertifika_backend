using System;

namespace Labote.Api.BindingModel.RequestModel
{
    public class GetDocumentByDate
    {
        public DateTime  startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
