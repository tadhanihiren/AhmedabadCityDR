using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblZoneMaster")]
    public partial class TblZoneMaster
    {
        public TblZoneMaster()
        {
            TblDivisionMasters = new HashSet<TblDivisionMaster>();
            TblEmployeeMasterBackups = new HashSet<TblEmployeeMasterBackup>();
            TblEmployeeMasters = new HashSet<TblEmployeeMaster>();
            TblLoginMasterMobiles = new HashSet<TblLoginMasterMobile>();
            TblNightRounds = new HashSet<TblNightRound>();
        }

        [Key]
        public int ZoneId { get; set; }

        public string? ZoneName { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("Zone")]
        public virtual ICollection<TblDivisionMaster> TblDivisionMasters { get; set; }

        [InverseProperty("Zone")]
        public virtual ICollection<TblEmployeeMasterBackup> TblEmployeeMasterBackups { get; set; }

        [InverseProperty("Zone")]
        public virtual ICollection<TblEmployeeMaster> TblEmployeeMasters { get; set; }

        [InverseProperty("Zone")]
        public virtual ICollection<TblLoginMasterMobile> TblLoginMasterMobiles { get; set; }

        [InverseProperty("Zone")]
        public virtual ICollection<TblNightRound> TblNightRounds { get; set; }
    }
}