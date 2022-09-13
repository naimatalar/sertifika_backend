using System;
using System.Collections.Generic;

#nullable disable

namespace OrganizationSchema
{
    public partial class HrmdPersonnelTypeM
    {
        public decimal PersonnelTypeMId { get; set; }
        public decimal? CreateUserId { get; set; }
        public decimal? UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public string NoteLarge { get; set; }
        public string PersonnelTypeCode { get; set; }
        public DateTime StartDate { get; set; }
        public bool? Ispassive { get; set; }
        public bool? IsBenefit { get; set; }
        public bool? IsDeduction { get; set; }
        public bool? AllowMultiSalaryProll { get; set; }
    }
}
