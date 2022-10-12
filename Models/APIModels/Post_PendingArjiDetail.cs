namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_PendingArjiDetail
    {
        public int PendingArjiDetailId { get; set; }
        public int? Under10Days { get; set; }
        public int? Above10Days { get; set; }
        public int? AboveOneMonth { get; set; }
        public int? AboveTwoMonth { get; set; }
        public int? AboveThreeMonth { get; set; }
        public int? AboveSixMonth { get; set; }
        public int? AboveOneYear { get; set; }
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
