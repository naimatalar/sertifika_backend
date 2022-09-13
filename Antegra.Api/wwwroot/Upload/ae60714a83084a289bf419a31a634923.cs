using System;
using System.Collections.Generic;

#nullable disable

namespace OrganizationSchema
{
    public partial class HrmdEmployeeTitle
    {
        public decimal EmpTitleId { get; set; }
        public decimal? CreateUserId { get; set; }
        public decimal? UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal ChangeReasonId { get; set; }
        public decimal EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public string NoteLarge { get; set; }
        public DateTime StartDate { get; set; }
        public decimal TitleId { get; set; }
        public decimal? SourceApp { get; set; }
        public decimal? SourceMId { get; set; }
        public decimal? SourceDId { get; set; }
        public decimal? TitleClassId { get; set; }
    }
}
