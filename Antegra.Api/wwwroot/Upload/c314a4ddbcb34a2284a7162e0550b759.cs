using System;
using System.Collections.Generic;

#nullable disable

namespace OrganizationSchema
{
    public partial class HrmdEmpOtherOrg
    {
        public decimal EmpOhterOrgId { get; set; }
        public decimal? CreateUserId { get; set; }
        public decimal? UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal ChangeReasonId { get; set; }
        public decimal EmployeeId { get; set; }
        public decimal OrgDId { get; set; }
        public bool? IsManagerOfOrgUnit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NoteLarge { get; set; }
        public decimal? JobId { get; set; }
        public decimal? OtherJobType { get; set; }
        public decimal? TitleId { get; set; }
    }
}
