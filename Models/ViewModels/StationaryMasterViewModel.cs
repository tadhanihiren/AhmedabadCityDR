namespace AhmedabadCityDR.Models.ViewModels
{
    public class StationaryMasterViewModel
    {
        public int StationaryId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? Telephone { get; set; }
        public string? Computer { get; set; }
        public string? Giswan_Connectivity { get; set; }
        public string? Fax_machine { get; set; }
        public string? Xerox_machine { get; set; }
        public string? Other_Stationary_Stocks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
