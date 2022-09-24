using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblOfficeWisePendingApplicationSel
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int OfficeWisePendingApplicationId { get; set; }
        public int? TenDaysAbove { get; set; }
        public int? OneMonthAbove { get; set; }
        public int? ThreeMonthAbove { get; set; }
        public int? SixMonthAbove { get; set; }
        public int? OneYearAndAbove { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? TwoMonthAbove { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int ZoneId { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
    }
}