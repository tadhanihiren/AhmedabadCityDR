using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblPendingArjiCategory")]
    public partial class TblPendingArjiCategory
    {
        public TblPendingArjiCategory()
        {
            TblPendingArjiDetails = new HashSet<TblPendingArjiDetail>();
        }

        [Key]
        public int PendingArjiCategoryId { get; set; }

        public string? CategoryName { get; set; }

        [InverseProperty("PendingArjiCategory")]
        public virtual ICollection<TblPendingArjiDetail> TblPendingArjiDetails { get; set; }
    }
}