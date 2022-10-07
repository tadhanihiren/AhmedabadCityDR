namespace AhmedabadCityDR.Models.ViewModels
{
    public class PoliceStationWiseVehicalViewModel
    {
        public int PoliceStationwiseVehicalId { get; set; }
        public int? Jeeps_Total { get; set; }
        public int? Jeeps_OFFroad { get; set; }
        public DateTime? Jeeps_date { get; set; }
        public int? Mobile_total { get; set; }
        public int? Mobile_offroad { get; set; }
        public DateTime? Mobile_date { get; set; }
        public int? Cycling_total { get; set; }
        public int? Cycling_offroad { get; set; }
        public DateTime? Cycling_date { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
