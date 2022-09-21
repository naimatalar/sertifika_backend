using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Core.BindingModels
{
   public class DocumentApplicationUpdateRequestModel
    {
        public Guid Id { get; set; }
        public string Interviewer { get; set; }

        public int Status { get; set; }

        public string Notes { get; set; }
    }
}
