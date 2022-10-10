namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_PendingJanvaJog
    {
        public int PendingJanvaJog { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? OneMonthUnder { get; set; }
        public int? OneMonthAbove { get; set; }
        public int? TwoMonthAbove { get; set; }
        public int? ThreeMonthAbove { get; set; }
        public int? SixMonthAbove { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? OneYearAndAbove { get; set; }
    }
}
