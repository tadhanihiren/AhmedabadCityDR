using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficSummaryDetailsCategoryWise
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? ShortName { get; set; }
        public string? EnglishName { get; set; }
        public int TrafficSummaryId { get; set; }
        public int? TodaysCaseNumber { get; set; }
        public int? YesterdaysCaseNumber { get; set; }

        [Column("T_Y")]
        public int? TY { get; set; }

        public int? CurrentMonthTodaysNumber { get; set; }
        public int? PreviousMonthTodaysNumber { get; set; }

        [Column("CM_PM")]
        public int? CmPm { get; set; }

        public int? CurrentYearTodaysNumber { get; set; }
        public int? PreviousYearTodaysNumber { get; set; }

        [Column("CY_PY")]
        public int? CyPy { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int TrafficSummaryCategoryId { get; set; }
        public string? TrafficSummaryCategoryName { get; set; }
    }
}