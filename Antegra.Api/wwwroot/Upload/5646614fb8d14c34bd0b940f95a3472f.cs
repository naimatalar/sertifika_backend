using System;
using System.Collections.Generic;

#nullable disable

namespace OrganizationSchema
{
    public partial class HrmdOrganizationD
    {
        public decimal? CreateUserId { get; set; }
        public decimal? UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal OrgHieId { get; set; }
        public decimal OrgDId { get; set; }
        public string OrgDCode { get; set; }
        public decimal? OrgDPId { get; set; }
        public decimal? OrgMId { get; set; }
        public decimal? OrgHieSourceId { get; set; }
        public string NoteLarge { get; set; }
        public string Description { get; set; }
        public bool? IsPassive { get; set; }
    }
}
