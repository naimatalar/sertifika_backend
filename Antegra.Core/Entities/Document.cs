using Labote.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labote.Core.Entities
{
    public class Document:BaseEntity
    {
        public string  Name { get; set; }
        public string Description { get; set; }
        public string DocumentNo { get; set; }
        public string Type { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public Enums.DocumentType  DocumentType { get; set; }
        public bool Statu { get; set; }
        public Product Product { get; set; }
        public Guid? ProductId { get; set; }
        public Company Company { get; set; }
        public Guid? CompanyId { get; set; }
        public Person Person { get; set; }
        public Guid? PersonId { get; set; }
        public virtual ICollection<DocumentFile> DocumentFiles { get; set; }
    }
}
