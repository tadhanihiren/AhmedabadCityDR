using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblkacheriMaster")]
    public partial class TblkacheriMaster
    {
        public TblkacheriMaster()
        {
            TblAdminWisePendingApplicationMasters = new HashSet<TblAdminWisePendingApplicationMaster>();
        }

        [Key]
        public int KacheriId { get; set; }

        public string? KacheriName { get; set; }

        [InverseProperty("Kacheri")]
        public virtual ICollection<TblAdminWisePendingApplicationMaster> TblAdminWisePendingApplicationMasters { get; set; }
    }
}