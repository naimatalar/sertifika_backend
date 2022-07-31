using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Labote.Core.Entities
{
    public class DocumentFile :BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public Document Document { get; set; }
        public Guid DocumentId { get; set; }
    }
}
