namespace AhmedabadCityDR.Models.ViewModels
{
    public class NightRountPersonCountMasterViewModel
    {
        public int NightRoundPersonCountId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? PresentMahekam { get; set; }
        public int? NightRountPersonCount { get; set; }
        public double? Percentage { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
