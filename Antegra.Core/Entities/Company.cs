using System;
using System.Collections.Generic;
using System.Text;

namespace Labote.Core.Entities
{
    public  class Company:BaseEntity
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public string IdentityNo { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
