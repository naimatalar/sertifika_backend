using System;
using System.Collections.Generic;

#nullable disable

namespace OrganizationSchema
{
    public partial class HrmdWorkplace
    {
        public decimal WpId { get; set; }
        public decimal? CreateUserId { get; set; }
        public decimal? UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public decimal? BankBranchId { get; set; }
        public bool? Bonus1 { get; set; }
        public bool? Bonus10 { get; set; }
        public bool? Bonus11 { get; set; }
        public bool? Bonus12 { get; set; }
        public bool? Bonus2 { get; set; }
        public bool? Bonus3 { get; set; }
        public bool? Bonus4 { get; set; }
        public bool? Bonus5 { get; set; }
        public bool? Bonus6 { get; set; }
        public bool? Bonus7 { get; set; }
        public bool? Bonus8 { get; set; }
        public bool? Bonus9 { get; set; }
        public decimal? CityId { get; set; }
        public decimal? CountryId { get; set; }
        public decimal CoId { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Fax { get; set; }
        public decimal? LockMonth { get; set; }
        public decimal? LockYear { get; set; }
        public string MobileTel { get; set; }
        public decimal? RegionId { get; set; }
        public string RiscClass { get; set; }
        public string RiscFactor { get; set; }
        public decimal? SectorId { get; set; }
        public string TaxNo { get; set; }
        public decimal? TaxOfficeId { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public decimal? TownId { get; set; }
        public string WebSite { get; set; }
        public string WpCode { get; set; }
        public string WpDesc { get; set; }
        public string WpTitle { get; set; }
        public string ZipCode { get; set; }
        public decimal? BranchId { get; set; }
        public decimal? StatuteCountry { get; set; }
        public decimal? KvskRatio { get; set; }
        public byte[] Image1 { get; set; }
        public decimal? CurRateTypeId { get; set; }
        public decimal? AzbSckPrmMId { get; set; }
        public decimal? DeclarationBranchType { get; set; }
        public decimal? DeclarationOwnership { get; set; }
        public string WpAddressNo { get; set; }
        public string GibWorkplaceNo { get; set; }
        public string SocialNo { get; set; }
        public string TsmCode { get; set; }
        public bool? IsFastPayroll { get; set; }
        public string WorkInstitutionNo { get; set; }
        public DateTime? WorkInstitutionDate { get; set; }
        public bool? IsPassive { get; set; }
        public string NaceCode { get; set; }
        public string ArgeProjeNos { get; set; }
        public string GibWorkplaceName { get; set; }
    }
}
