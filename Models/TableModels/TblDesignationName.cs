using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblDesignationName")]
    public partial class TblDesignationName
    {
        public TblDesignationName()
        {
            TblEmployeeMasterBackups = new HashSet<TblEmployeeMasterBackup>();
            TblEmployeeMasters = new HashSet<TblEmployeeMaster>();
            TblLeaveApplicationMasterDesignations = new HashSet<TblLeaveApplicationMaster>();
            TblLeaveApplicationMasterInchargeDesignations = new HashSet<TblLeaveApplicationMaster>();
            TblLoginMasterMobiles = new HashSet<TblLoginMasterMobile>();
            TblNightEmployeeMasters = new HashSet<TblNightEmployeeMaster>();
        }

        [Key]
        public int DesignationId { get; set; }

        public string? DesignationName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("Designation")]
        public virtual ICollection<TblEmployeeMasterBackup> TblEmployeeMasterBackups { get; set; }

        [InverseProperty("Designation")]
        public virtual ICollection<TblEmployeeMaster> TblEmployeeMasters { get; set; }

        [InverseProperty("Designation")]
        public virtual ICollection<TblLeaveApplicationMaster> TblLeaveApplicationMasterDesignations { get; set; }

        [InverseProperty("InchargeDesignation")]
        public virtual ICollection<TblLeaveApplicationMaster> TblLeaveApplicationMasterInchargeDesignations { get; set; }

        [InverseProperty("Designation")]
        public virtual ICollection<TblLoginMasterMobile> TblLoginMasterMobiles { get; set; }

        [InverseProperty("Designation")]
        public virtual ICollection<TblNightEmployeeMaster> TblNightEmployeeMasters { get; set; }
    }
}