using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblLoginMaster_Mobile")]
    public partial class TblLoginMasterMobile
    {
        [Key]
        public int LoginId { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNo { get; set; }
        public string? Name { get; set; }
        public string? DeviceId { get; set; }
        public int? RoleId { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("ForTraffic_City")]
        public int? ForTrafficCity { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMobileAccess { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? DesignationId { get; set; }
        public string? FierBaseId { get; set; }

        [ForeignKey("DesignationId")]
        [InverseProperty("TblLoginMasterMobiles")]
        public virtual TblDesignationName? Designation { get; set; }

        [ForeignKey("DivisionId")]
        [InverseProperty("TblLoginMasterMobiles")]
        public virtual TblDivisionMaster? Division { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblLoginMasterMobiles")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("TblLoginMasterMobiles")]
        public virtual TblRoleMaster? Role { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("TblLoginMasterMobiles")]
        public virtual TblSectorMaster? Sector { get; set; }

        [ForeignKey("ZoneId")]
        [InverseProperty("TblLoginMasterMobiles")]
        public virtual TblZoneMaster? Zone { get; set; }
    }
}