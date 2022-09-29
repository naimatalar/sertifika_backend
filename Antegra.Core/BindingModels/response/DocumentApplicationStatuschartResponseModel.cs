using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Core.BindingModels.response
{
   
    public class DocumentApplicationStatuschartDataset
    {
        public string label { get; set; }
        public List<int> data { get; set; }
        public List<string> backgroundColor { get; set; }
        public int borderWidth { get; set; }
    }

    public class DocumentApplicationStatuschartResponseModel
    {
        public List<string> labels { get; set; } = new List<string>();
        public List<DocumentApplicationStatuschartDataset> datasets { get; set; } =new List<DocumentApplicationStatuschartDataset>();   
    }


}
