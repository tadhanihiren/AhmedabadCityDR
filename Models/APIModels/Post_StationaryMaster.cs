namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_StationaryMaster
    {
        public int StationaryId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? Telephone { get; set; }
        public string? Computer { get; set; }
        public string? GiswanConnectivity { get; set; }
        public string? FaxMachine { get; set; }
        public string? XeroxMachine { get; set; }
        public string? OtherStationaryStocks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
