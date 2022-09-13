using System;
using System.Collections.Generic;

#nullable disable

namespace OrganizationSchema
{
    public partial class HrmdEmployeeCategory
    {
        public decimal EmployeeCatId { get; set; }
        public decimal? CreateUserId { get; set; }
        public decimal? UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal CatCodeId { get; set; }
        public decimal EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Ispassive { get; set; }
        public string NoteLarge { get; set; }
        public DateTime StartDate { get; set; }
        public decimal? SourceApp { get; set; }
        public decimal? SourceMId { get; set; }
        public decimal? SourceDId { get; set; }
    }
}
