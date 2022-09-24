using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblBandobastTypeMaster")]
    public partial class TblBandobastTypeMaster
    {
        public TblBandobastTypeMaster()
        {
            TblBandobastDetailMasters = new HashSet<TblBandobastDetailMaster>();
        }

        [Key]
        public int BandobastTypeId { get; set; }

        public string? BandobastType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [InverseProperty("BandobastType")]
        public virtual ICollection<TblBandobastDetailMaster> TblBandobastDetailMasters { get; set; }
    }
}