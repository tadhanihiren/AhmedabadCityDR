namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_AtakayatiPaglaSummary
    {
        public int AtakayatiPagalaSummaryId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? Todays { get; set; }
        public int? Last { get; set; }
        public int? CurrentMonth { get; set; }
        public int? LastMonth { get; set; }
        public int? CurrentYear { get; set; }
        public string? LastYear { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}