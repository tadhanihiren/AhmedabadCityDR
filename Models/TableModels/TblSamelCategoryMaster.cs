using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblSamelCategoryMaster")]
    public partial class TblSamelCategoryMaster
    {
        [Key]
        public int SamelCategoryId { get; set; }

        public string? SamelCaregoryName { get; set; }
    }
}