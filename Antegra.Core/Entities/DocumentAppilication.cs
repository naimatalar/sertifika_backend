using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labote.Core.Constants.Enums;

namespace Labote.Core.Entities
{
    public class DocumentAppilication : BaseEntity
    {
        public Document Document { get; set; }
        public Guid DocumentId { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Posta { get; set; }
        public string Phone { get; set; }
        public string Interviewer { get; set; }
        public NagativeMeetStatus? NagativeMeetStatus { get; set; } = null;
        public DocumentApplicationMeetStatus DocumentApplicationMeetStatus { get; set; } = DocumentApplicationMeetStatus.NotMeet;
        public string Notes { get; set; }

    }
}
