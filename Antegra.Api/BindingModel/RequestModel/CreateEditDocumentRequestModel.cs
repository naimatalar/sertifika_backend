using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.BindingModel.RequestModel
{
    public class CreateEditDocumentRequestModel
    {
        public Guid? Id { get; set; }
        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DocumentNo { get; set; }
        public string Type { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public int DocumnetKind { get; set; }
        public int DocumentType { get; set; }
        public bool Statu { get; set; }
    }
}
