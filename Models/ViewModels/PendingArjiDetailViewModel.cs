namespace AhmedabadCityDR.Models.ViewModels
{
    public class PendingArjiDetailViewModel
    {
        public int PendingArjiDetailId { get; set; }
        public int? Under_10Days { get; set; }
        public int? Above_10Days { get; set; }
        public int? Above_OneMonth { get; set; }
        public int? Above_TwoMonth { get; set; }
        public int? Above_ThreeMonth { get; set; }
        public int? Above_SixMonth { get; set; }
        public int? Above_OneYear { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? PendingArjiCategoryId { get; set; }
        public string? CategoryName { get; set; }
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
