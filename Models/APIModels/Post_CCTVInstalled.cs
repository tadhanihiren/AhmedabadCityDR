namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_CCTVInstalled
    {
        public int InstallId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? PtzInstalled { get; set; }
        public int? BltInstalled { get; set; }
        public int? DmInstalled { get; set; }
        public int? TotalInstalled { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
