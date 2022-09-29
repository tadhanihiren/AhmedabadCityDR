namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_MCRDetails
    {
        public int McrId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? MCRCardNo { get; set; }
        public string? NameOfISM { get; set; }
        public string? LatestMobileNo { get; set; }
        public string? LatestAddressOfISM { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
