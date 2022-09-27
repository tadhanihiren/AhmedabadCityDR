namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_NightRountPersonCountMaster
    {
        public int NightRoundPersonCountId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? PresentMahekam { get; set; }
        public int? NightRountPersonCount { get; set; }
        public double? Percentage { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
