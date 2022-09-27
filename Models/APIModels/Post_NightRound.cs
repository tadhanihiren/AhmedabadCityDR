namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_NightRound
    {
        public int NightRoundId { get; set; }

        public string? NightRoundOfficerName { get; set; }
        public string? GoingTime { get; set; }
        public string? ReturnTime { get; set; }
        public string? NightRoundPlace { get; set; }
        public string? Remarks { get; set; }
        public int? SectorId { get; set; } = 0;
        public int? ZoneId { get; set; } = 0;
        public int? DivisionId { get; set; } = 0;
        public int? PoliceStationId { get; set; } = 0;
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsMobileAccess { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? DesignationId { get; set; }
        public string? FierBaseId { get; set; }
        public int? TempId { get; set; }
    }
}
