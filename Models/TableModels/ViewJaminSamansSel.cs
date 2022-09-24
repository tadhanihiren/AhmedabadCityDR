using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewJaminSamansSel
    {
        [Column("samans_id")]
        public int SamansId { get; set; }

        public int? PoliceStationId { get; set; }

        [Column("today_old_pending")]
        public int? TodayOldPending { get; set; }

        [Column("today_new")]
        public int? TodayNew { get; set; }

        [Column("today_total")]
        public int? TodayTotal { get; set; }

        [Column("today_complete")]
        public int? TodayComplete { get; set; }

        [Column("today_non_complete")]
        public int? TodayNonComplete { get; set; }

        [Column("today_transfer")]
        public int? TodayTransfer { get; set; }

        [Column("today_pending")]
        public int? TodayPending { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? CategoryId { get; set; }
        public string? ZoneName { get; set; }
        public string? DivisionName { get; set; }
        public string? ShortName { get; set; }
        public string? CategoryName { get; set; }
        public int? DivisionId { get; set; }
        public int? ZoneId { get; set; }
        public string? EnglishName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}