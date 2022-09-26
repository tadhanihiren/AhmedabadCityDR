using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class AtakayatiDetailsViewModel
    {
        public int AtakayatiPagalaSummaryId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public int? Today { get; set; }
        public int? Last { get; set; }
        public int? CurrentYear { get; set; }
        public int? LastYear { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? CY_LY { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? SubCategoryName { get; set; }
        public int? SubCategoryId { get; set; }
    }
}
