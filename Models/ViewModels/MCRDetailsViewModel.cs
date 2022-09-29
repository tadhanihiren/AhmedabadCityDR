namespace AhmedabadCityDR.Models.ViewModels
{
    public class MCRDetailsViewModel
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? McrId { get; set; }
        public string? MCRCardNo { get; set; }
        public string? NameOfISM { get; set; }
        public string? LatestMobileNo { get; set; }
        public string? LatestAddressOfISM { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
