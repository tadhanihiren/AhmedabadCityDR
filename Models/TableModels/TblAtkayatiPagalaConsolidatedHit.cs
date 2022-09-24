using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblAtkayatiPagalaConsolidated_HITS")]
    public partial class TblAtkayatiPagalaConsolidatedHit
    {
        public int AtakayatiPagalaId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Value { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
    }
}