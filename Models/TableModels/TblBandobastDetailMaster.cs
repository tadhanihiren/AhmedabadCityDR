using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblBandobastDetailMaster")]
    public partial class TblBandobastDetailMaster
    {
        [Key]
        public int BandoBastId { get; set; }

        public int? PoliceStationId { get; set; }
        public string? BandoBastPlace { get; set; }
        public int? BandobastTypeId { get; set; }

        [Column("BandobastDetail_ForceNumber")]
        public string? BandobastDetailForceNumber { get; set; }

        public string? ShortDetail { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("BandobastTypeId")]
        [InverseProperty("TblBandobastDetailMasters")]
        public virtual TblBandobastTypeMaster? BandobastType { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblBandobastDetailMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}