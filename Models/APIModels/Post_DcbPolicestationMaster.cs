namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_DcbPolicestationMaster
    {
        public int DCBId { get; set; }
        public string? ShortDetails { get; set; }
        public string? Operation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
