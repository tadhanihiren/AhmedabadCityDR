using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblSectorMaster")]
    public partial class TblSectorMaster
    {
        public TblSectorMaster()
        {
            TblEmployeeMasterBackups = new HashSet<TblEmployeeMasterBackup>();
            TblEmployeeMasters = new HashSet<TblEmployeeMaster>();
            TblLoginMasterMobiles = new HashSet<TblLoginMasterMobile>();
            TblNightRounds = new HashSet<TblNightRound>();
        }

        [Key]
        public int SectorId { get; set; }

        public int? CityId { get; set; }
        public string? SectorName { get; set; }

        [ForeignKey("CityId")]
        [InverseProperty("TblSectorMasters")]
        public virtual TblCityMaster? City { get; set; }

        [InverseProperty("Sector")]
        public virtual ICollection<TblEmployeeMasterBackup> TblEmployeeMasterBackups { get; set; }

        [InverseProperty("Sector")]
        public virtual ICollection<TblEmployeeMaster> TblEmployeeMasters { get; set; }

        [InverseProperty("Sector")]
        public virtual ICollection<TblLoginMasterMobile> TblLoginMasterMobiles { get; set; }

        [InverseProperty("Sector")]
        public virtual ICollection<TblNightRound> TblNightRounds { get; set; }
    }
}