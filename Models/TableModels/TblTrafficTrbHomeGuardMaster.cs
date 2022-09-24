using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTraffic_TRB_HomeGuard_Master")]
    public partial class TblTrafficTrbHomeGuardMaster
    {
        [Key]
        [Column("Traffic_TRB_HomeGuardId")]
        public int TrafficTrbHomeGuardId { get; set; }

        public int? PoliceStationId { get; set; }

        [Column("TRBManjurNumber")]
        public int? TrbmanjurNumber { get; set; }

        [Column("TRBAttendanceMorning")]
        public int? TrbattendanceMorning { get; set; }

        [Column("TRBAttendanceEvening")]
        public int? TrbattendanceEvening { get; set; }

        public int? HomeGuardManjurNumber { get; set; }
        public int? HomeGuardAttendanceMorning { get; set; }
        public int? HomeGuardAttendanceEvening { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblTrafficTrbHomeGuardMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}