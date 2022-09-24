using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblNightRountPersonCountMaster")]
    public partial class TblNightRountPersonCountMaster
    {
        [Key]
        public int NightRoundPersonCountId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? PresentMahekam { get; set; }
        public int? NightRountPersonCount { get; set; }
        public double? Percentage { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblNightRountPersonCountMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}