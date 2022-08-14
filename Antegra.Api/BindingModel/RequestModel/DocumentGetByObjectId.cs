using Labote.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labote.Api.BindingModel.RequestModel
{
    public class DocumentGetByObjectId
    {
        public Guid ObjectId { get; set; }
        public int DocumnetKind{ get; set; }
    }
}
