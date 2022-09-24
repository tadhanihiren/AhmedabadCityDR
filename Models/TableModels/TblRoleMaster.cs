using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblRoleMaster")]
    public partial class TblRoleMaster
    {
        public TblRoleMaster()
        {
            TblEmployeeMasters = new HashSet<TblEmployeeMaster>();
            TblLoginMasterMobiles = new HashSet<TblLoginMasterMobile>();
        }

        [Key]
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<TblEmployeeMaster> TblEmployeeMasters { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<TblLoginMasterMobile> TblLoginMasterMobiles { get; set; }
    }
}