using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewReport19Sel
    {
        [Column("TOTAL")]
        public int? Total { get; set; }

        public string? PoliceStationName { get; set; }
        public int? CurrentYearMissingChildId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? Gender { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? GenderId { get; set; }
        public int ZoneId { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}