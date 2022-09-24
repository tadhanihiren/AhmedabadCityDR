using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblSubCategoryCount")]
    public partial class TblSubCategoryCount
    {
        public int? RowNumber { get; set; }
        public int? SubCategoryId { get; set; }
        public int? CategoryId { get; set; }
        public string? DeviceId { get; set; }
    }
}