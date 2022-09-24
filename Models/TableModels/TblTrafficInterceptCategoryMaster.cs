using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficInterceptCategoryMaster")]
    public partial class TblTrafficInterceptCategoryMaster
    {
        public TblTrafficInterceptCategoryMaster()
        {
            TblTrafficInterceptSubCategoryMasters = new HashSet<TblTrafficInterceptSubCategoryMaster>();
        }

        [Key]
        public int TrafficInterceptCategoryId { get; set; }

        public string? TrafficInterceptCategoryName { get; set; }

        [InverseProperty("TrafficInterceptCategory")]
        public virtual ICollection<TblTrafficInterceptSubCategoryMaster> TblTrafficInterceptSubCategoryMasters { get; set; }
    }
}