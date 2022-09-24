using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tbl_samans_details")]
    public partial class TblSamansDetail
    {
        [Key]
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

        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblSamansDetails")]
        public virtual TblCategoryMaster? Category { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblSamansDetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}