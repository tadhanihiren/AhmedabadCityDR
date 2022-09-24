using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblDivisionMaster")]
    public partial class TblDivisionMaster
    {
        public TblDivisionMaster()
        {
            TblEmployeeMasterBackups = new HashSet<TblEmployeeMasterBackup>();
            TblEmployeeMasters = new HashSet<TblEmployeeMaster>();
            TblLoginMasterMobiles = new HashSet<TblLoginMasterMobile>();
            TblNightRounds = new HashSet<TblNightRound>();
        }

        [Key]
        public int DivisionId { get; set; }

        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreateUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("ZoneId")]
        [InverseProperty("TblDivisionMasters")]
        public virtual TblZoneMaster? Zone { get; set; }

        [InverseProperty("Division")]
        public virtual ICollection<TblEmployeeMasterBackup> TblEmployeeMasterBackups { get; set; }

        [InverseProperty("Division")]
        public virtual ICollection<TblEmployeeMaster> TblEmployeeMasters { get; set; }

        [InverseProperty("Division")]
        public virtual ICollection<TblLoginMasterMobile> TblLoginMasterMobiles { get; set; }

        [InverseProperty("Division")]
        public virtual ICollection<TblNightRound> TblNightRounds { get; set; }
    }
}