using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficSignalBlinkRightSel
    {
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? PoliceStationName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
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