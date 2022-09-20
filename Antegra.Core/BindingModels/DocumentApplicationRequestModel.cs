using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Core.BindingModels
{
   public class DocumentApplicationRequestModel
    {
        public Guid DocumentId { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Posta { get; set; }
        public string Phone { get; set; }
    }
}
