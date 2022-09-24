using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewReportspart15crime
    {
        [Column("total")]
        public int? Total { get; set; }

        public string? PoliceStationName { get; set; }
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int PoliceStationId { get; set; }
    }
}