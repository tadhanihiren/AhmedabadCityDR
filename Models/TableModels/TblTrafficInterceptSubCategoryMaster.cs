using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficInterceptSubCategoryMaster")]
    public partial class TblTrafficInterceptSubCategoryMaster
    {
        [Key]
        public int TrafficInterceptSubCategoryId { get; set; }

        public int? TrafficInterceptCategoryId { get; set; }
        public string? TrafficeInterceptSubCategoryName { get; set; }

        [ForeignKey("TrafficInterceptCategoryId")]
        [InverseProperty("TblTrafficInterceptSubCategoryMasters")]
        public virtual TblTrafficInterceptCategoryMaster? TrafficInterceptCategory { get; set; }
    }
}