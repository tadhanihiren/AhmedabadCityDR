namespace AhmedabadCityDR.Models.ViewModels
{
    public class AutoRickshawDetailViewModel
    {
        public int AutoRickshawId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? AutoRickshawNo { get; set; }
        public string? DriverName { get; set; }
        public string? OwnerName { get; set; }
        public int? LicenseNumber { get; set; }
        public int? PermitNumber { get; set; }
        public int? DriversBaseNo { get; set; }
        public int? RCBook { get; set; }
        public int? RCBook_Detail { get; set; }
        public int? InsurancePolicy { get; set; }
        public int? CheckingOperation { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
