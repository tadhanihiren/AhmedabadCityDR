namespace AhmedabadCityDR.Models.APIModels
{
    //treref
    public class Post_ProhibitionRaidCase
    {
        public int ProhibitionRaidCaseId { get; set; }
        public string? IPACT { get; set; }
        public string? Gubatata { get; set; }
        public string? CrimePlace { get; set; }
        public string? RaidTimeCriminalName { get; set; }
        public string? RaidingPartyEmployeeName { get; set; }
        public string? InvestigationOfficerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationNumber { get; set; }
    }
}
