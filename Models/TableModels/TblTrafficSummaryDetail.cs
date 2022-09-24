using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficSummaryDetails")]
    public partial class TblTrafficSummaryDetail
    {
        [Key]
        public int TrafficSummaryId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? TrafficSummaryCategoryId { get; set; }
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

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblTrafficSummaryDetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}