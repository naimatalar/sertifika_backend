using System;

namespace Labote.Api.BindingModel.RequestModel
{
    public class CreateEditProductRequestModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string Barcode { get; set; }
    }
}
