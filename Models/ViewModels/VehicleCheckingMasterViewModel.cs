namespace AhmedabadCityDR.Models.ViewModels
{
    public class VehicleCheckingMasterViewModel
    {
        public int VehicleCheckingId { get; set; }
        public int? SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? Checktwowheeler { get; set; }
        public int? dandtwowheeler { get; set; }
        public int? Checkthreewheeler { get; set; }
        public int? dandthreewheeler { get; set; }
        public int? Checkfourwheeler { get; set; }
        public int? dandfourwheeler { get; set; }
        public int? detain { get; set; }
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
