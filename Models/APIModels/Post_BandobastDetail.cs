namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_BandobastDetail
    {
        public int BandoBastId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? BandoBastPlace { get; set; }
        public int? BandobastTypeId { get; set; }
        public string? BandobastDetailForceNumber { get; set; }
        public string? ShortDetail { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? SectorId { get; set; }
    }
}
