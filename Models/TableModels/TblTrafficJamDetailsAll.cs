using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficJam_Details_ALL")]
    public partial class TblTrafficJamDetailsAll
    {
        [Key]
        [Column("TrafficjamId_ALL")]
        public int TrafficjamIdAll { get; set; }

        public int? PoliceStationId { get; set; }

        [Column("Caller_50_100")]
        public string? Caller50100 { get; set; }

        public string? CallerName { get; set; }
        public string? CallerNumber { get; set; }
        public string? TrafficjamPlace { get; set; }
        public string? GotMessageTime { get; set; }

        [Column("BeatIncharge_InformationTime")]
        public string? BeatInchargeInformationTime { get; set; }

        [Column("BeatIncharge_GoingTime")]
        public string? BeatInchargeGoingTime { get; set; }

        public string? ReachedTimeToPlace { get; set; }
        public string? ReducedTrafficJam { get; set; }
        public string? ReasonforTrafficJam { get; set; }
        public string? HowmuchtimeTrafficJam { get; set; }

        [Column("PI")]
        public string? Pi { get; set; }

        [Column("PSI")]
        public string? Psi { get; set; }

        [Column("ACP_DCP")]
        public string? AcpDcp { get; set; }

        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedUserId { get; set; }
    }
}