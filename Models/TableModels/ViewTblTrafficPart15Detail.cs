using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficPart15Detail
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }

        [Column("TrafficPart_1_to_5_Id")]
        public int TrafficPart1To5Id { get; set; }

        public int? TodaysCrimenumber { get; set; }
        public int? YesterdaysCrimeNumber { get; set; }

        [Column("Plus_Minus_T_Y")]
        public int? PlusMinusTY { get; set; }

        public int? CurrentMonthTodaysCrimeNumber { get; set; }
        public int? PreviousMonthTodaysCrimeNumber { get; set; }

        [Column("Plus_Minus_C_P")]
        public int? PlusMinusCP { get; set; }

        public int? CurrentYearTodaysCrimeNumber { get; set; }
        public int? PreviousYearTodaysCrimeNumber { get; set; }

        [Column("Plus_Minus_CY_PY")]
        public int? PlusMinusCyPy { get; set; }

        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}