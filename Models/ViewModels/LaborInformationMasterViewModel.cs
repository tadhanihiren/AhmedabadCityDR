namespace AhmedabadCityDR.Models.ViewModels
{
    public class LaborInformationMasterViewModel
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SubCategoryId { get; set; }
        public int? CategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int? LaborInformationId { get; set; }
        public int? CheckedPlace { get; set; }
        public int? CheckedLabor { get; set; }
        public int? TotalLaborersVideography { get; set; }
        public int? Workers_ARoll_BRollNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
    }
}
