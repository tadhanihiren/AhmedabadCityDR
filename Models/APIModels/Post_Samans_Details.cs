namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_Samans_Details
    {
        public int SamansId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? TodayOldPending { get; set; }
        public int? TodayNew { get; set; }
        public int? TodayComplete { get; set; }
        public int? TodayNonComplete { get; set; }
        public int? TodayTransfer { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
