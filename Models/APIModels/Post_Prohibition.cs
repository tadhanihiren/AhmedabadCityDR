namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_Prohibition
    {
        public int CrimesId { get; set; }
        public string? PoliceStationNumber { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public string? Complainer { get; set; }
        public string? Accused { get; set; }
        public string? Gubatata { get; set; }
        public string? Gujatata { get; set; }
        public string? Gudatata { get; set; }
        public string? CrimePlace { get; set; }
        public string? CrimePurpose { get; set; }
        public string? PersonNameWhoFiledCrime { get; set; }
        public string? InvestigationOfficer { get; set; }
        public string? ShortDetail { get; set; }
        public string? LateComplaintReason { get; set; }
        public string? HdiitsEntry { get; set; }
        public string? Savendansil { get; set; }
        public string? BinSavendansil { get; set; }
        public string? ComplainerAccusedCriminalHistory { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Ipcact { get; set; }
        public string? PidhelaKabjanaType { get; set; }
    }
}