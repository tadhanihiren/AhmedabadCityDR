using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class PoliceStationWisePendingApplicationViewModel
    {
        public int PoliceStationWisePendingApplicationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? PoliceStationId { get; set; }
        public int? KacheriId { get; set; }
        public int? TenDaysBelow { get; set; }
        public int? TenDaysAbove { get; set; }
        public int? OneMonthAbove { get; set; }
        public int? TwoMonthAbove { get; set; }
        public int? ThreeMonthAbove { get; set; }
        public int? SixMonthAbove { get; set; }
        public int? OneYearAndAbove { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string?  KacheriName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
