using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Labote.Core.Entities
{
   public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public string BarcodeNumber { get; set; }
        public string CertificaNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyAddress { get; set; }


        public virtual ICollection<Document> Documents { get; set; }

    }
}
