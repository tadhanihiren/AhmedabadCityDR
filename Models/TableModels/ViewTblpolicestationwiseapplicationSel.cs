using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblpolicestationwiseapplicationSel
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int PoliceStationWisePendingApplicationId { get; set; }
        public int? OneMonthUnder { get; set; }
        public int? OneMonthAbove { get; set; }
        public int? TwoMonthAbove { get; set; }
        public int? ThreeMonthAbove { get; set; }
        public int? SixMonthAbove { get; set; }
        public int? OneYearAndAbove { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int? TenDaysBelow { get; set; }
        public int? TenDaysAbove { get; set; }
        public string? KacheriName { get; set; }
        public int? KacheriId { get; set; }
    }
}