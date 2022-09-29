namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_Detain
    {
        public int DetainId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? Psnccount { get; set; }
        public int? Tsnccount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PoliceStationId { get; set; }
    }
}
