using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Core.Entities
{
   public class UserAddress:BaseEntity
    {
        public string Name { get; set; }
        public string Addres { get; set; }
        public long Langitude { get; set; }
        public long Latitude { get; set; }
        public LaboteUser LaboteUser { get; set; }
        public Guid LaboteUserId { get; set; }
    }
}
