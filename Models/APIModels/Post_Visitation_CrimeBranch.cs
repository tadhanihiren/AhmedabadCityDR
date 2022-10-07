namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_Visitation_CrimeBranch
    {
        public int VisitationId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? GubatataCrimePlace { get; set; }
        public string? CrimeVisitPlace { get; set; }
        public DateTime? VisitDate { get; set; }
        public string? VisiterOfficerName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

    }
}
