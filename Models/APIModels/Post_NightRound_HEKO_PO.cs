namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_NightRound_HEKO_PO
    {
        public int NightRoundHekoPoid { get; set; }
        public int? PoliceStationId { get; set; }
        public int? TotalOfMotarcycle { get; set; }
        public int? MaofNumber { get; set; }
        public int? NightRoundHekoPonumber { get; set; }
        public int? DefectNumber { get; set; }
        public int? NotavailabelNumber { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

    }
}
