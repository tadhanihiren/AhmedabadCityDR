using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblAtkayatiPagalaConsolidated")]
    public partial class TblAtkayatiPagalaConsolidated
    {
        [Key]
        public long AtakayatiPagalaId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Value { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblAtkayatiPagalaConsolidateds")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}