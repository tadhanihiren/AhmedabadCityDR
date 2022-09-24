using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblPart15CrimesCountsOnly
    {
        public string? CategoryName { get; set; }

        [Column("Part1_5_6_Id")]
        public int Part156Id { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int CrimesCount { get; set; }
        public string DeviceId { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public string? SubCategoryName { get; set; }
    }
}