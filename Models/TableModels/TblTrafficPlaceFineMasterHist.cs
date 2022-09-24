using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblTrafficPlaceFineMaster_HIST")]
    public partial class TblTrafficPlaceFineMasterHist
    {
        public int TrafficPlaceFineId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? TodaysCrimenumber { get; set; }
        public int? TodaysCrimeAmount { get; set; }
        public int? YesterdaysCrimeNumber { get; set; }
        public int? YesterdaysCrimeAmount { get; set; }

        [Column("Plus_Minus_T_Y_Number")]
        public int? PlusMinusTYNumber { get; set; }

        [Column("Plus_Minus_T_Y_Amount")]
        public int? PlusMinusTYAmount { get; set; }

        public int? CurrentMonthTodaysCrimeNumber { get; set; }
        public int? CurrentMonthTodaysCrimeAmount { get; set; }
        public int? PreviousMonthTodaysCrimeNumber { get; set; }
        public int? PreviousMonthTodaysCrimeAmount { get; set; }

        [Column("Plus_Minus_C_P_Number")]
        public int? PlusMinusCPNumber { get; set; }

        [Column("Plus_Minus_C_P_Amount")]
        public int? PlusMinusCPAmount { get; set; }

        public int? CurrentYearTodaysCrimeNumber { get; set; }
        public int? CurrentYearTodaysCrimeAmount { get; set; }
        public int? PreviousYearTodaysCrimeNumber { get; set; }
        public int? PreviousYearTodaysCrimeAmount { get; set; }

        [Column("Plus_Minus_CY_PY_Number")]
        public int? PlusMinusCyPyNumber { get; set; }

        [Column("Plus_Minus_CY_PY_Amount")]
        public int? PlusMinusCyPyAmount { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}