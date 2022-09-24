using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblTrafficSignalBlinkerigh_HIST")]
    public partial class TblTrafficSignalBlinkerighHist
    {
        public int TrafficSignalBlinkerighId { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("locations_blinkering_area")]
        public string? LocationsBlinkeringArea { get; set; }

        [Column("reasons")]
        public string? Reasons { get; set; }

        [Column("orders")]
        public string? Orders { get; set; }

        [Column("Blinking_time")]
        public string? BlinkingTime { get; set; }

        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}