using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Core.BindingModels.response
{
  
    public class DocumentApplicateResourceDataset
    {
        public string label { get; set; }
        public List<int> data { get; set; } = new List<int>();
        public List<string> backgroundColor { get; set; }=new List<string>();
        public List<string> borderColor { get; set; }=new List<string>();
        public int borderWidth { get; set; }
    }

    public class DocumentApplicateResource
    {
        public List<string> labels { get; set; } = new List<string>();
        public List<DocumentApplicateResourceDataset> datasets { get; set; } = new List<DocumentApplicateResourceDataset>();
    }


}
