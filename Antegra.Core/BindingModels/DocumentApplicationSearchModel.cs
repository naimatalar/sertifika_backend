using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Core.BindingModels
{
    public class DocumentApplicationSearchModel: BasePaginationRequestModel
    {
        public string Name { get; set; }
    }
}
