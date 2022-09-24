using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficDriveCategoryMaster")]
    public partial class TblTrafficDriveCategoryMaster
    {
        public TblTrafficDriveCategoryMaster()
        {
            TblTrafficDriveMasters = new HashSet<TblTrafficDriveMaster>();
        }

        [Key]
        public int TrafficCategoryDriveId { get; set; }

        public string? TrafficCategoryDriveName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DriveDate { get; set; }

        public string? DriveGivenBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("TrafficDriveCatgeory")]
        public virtual ICollection<TblTrafficDriveMaster> TblTrafficDriveMasters { get; set; }
    }
}