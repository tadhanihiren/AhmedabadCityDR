using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblCriminalCountInformationSel
    {
        public int CriminalCountId { get; set; }
        public int? CurrentMonthCrime { get; set; }
        public int? LastMonthCrime { get; set; }
        public int? CurrentYearCrime { get; set; }
        public int? LastYearCrime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
    }
}