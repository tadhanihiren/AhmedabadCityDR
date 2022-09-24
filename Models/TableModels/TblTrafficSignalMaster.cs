using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficSignalMaster")]
    public partial class TblTrafficSignalMaster
    {
        [Key]
        [Column("trafficSignalId")]
        public int TrafficSignalId { get; set; }

        public int? PoliceStationId { get; set; }

        [Column("signals_area")]
        public int? SignalsArea { get; set; }

        [Column("signals_progress")]
        public int? SignalsProgress { get; set; }

        [Column("signals_closed_condition")]
        public int? SignalsClosedCondition { get; set; }

        [Column("reason_closed_condition")]
        public string? ReasonClosedCondition { get; set; }

        [Column("procedures_closed")]
        public string? ProceduresClosed { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblTrafficSignalMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}