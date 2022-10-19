namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_VehicleCheckingMaster
    {
        public int VehicleCheckingId { get; set; }
        public int? SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? Checktwowheeler { get; set; }
        public int? Dandtwowheeler { get; set; }
        public int? Checkthreewheeler { get; set; }
        public int? Dandthreewheeler { get; set; }
        public int? Checkfourwheeler { get; set; }
        public int? Dandfourwheeler { get; set; }
        public int? Detain { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
