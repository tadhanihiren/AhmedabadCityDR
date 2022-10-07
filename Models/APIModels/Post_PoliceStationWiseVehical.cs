namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_PoliceStationWiseVehical
    {
        public int PoliceStationwiseVehicalId { get; set; }
        public int? JeepsTotal { get; set; }
        public int? JeepsOFFroad { get; set; }
        public DateTime? JeepsDate { get; set; }
        public int? MobileTotal { get; set; }
        public int? MobileOffroad { get; set; }
        public DateTime? MobileDate { get; set; }
        public int? CyclingTotal { get; set; }
        public int? CyclingOffroad { get; set; }
        public DateTime? CyclingDate { get; set; }
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
