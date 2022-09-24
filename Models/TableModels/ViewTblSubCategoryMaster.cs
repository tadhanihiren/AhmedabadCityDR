using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblSubCategoryMaster
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }

        [Column("IPC")]
        public string? Ipc { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}