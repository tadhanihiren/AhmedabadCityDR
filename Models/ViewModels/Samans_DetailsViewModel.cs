namespace AhmedabadCityDR.Models.ViewModels
{
    public class Samans_DetailsViewModel
    {
        public int Samans_id { get; set; }
        public int? PoliceStationId { get; set; }
        public int? Today_old_pending { get; set; }
        public int? Today_new { get; set; }
        public int? Today_total { get; set; }
        public int? Today_complete { get; set; }
        public int? Today_non_complete { get; set; }
        public int? Today_transfer { get; set; }
        public int? Today_pending { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? CategoryId { get; set; }
        public string? ZoneName { get; set; }
        public string? DivisionName { get; set; }
        public string? ShortName { get; set; }
        public string? CategoryName { get; set; }
        public int? DivisionId { get; set; }
        public int? ZoneId { get; set; }
        public string? EnglishName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
