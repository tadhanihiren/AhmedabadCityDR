using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblVehicleMaster")]
    public partial class TblVehicleMaster
    {
        [Key]
        public int WheelerId { get; set; }

        public int? CategoryId { get; set; }
        public string? WheelerType { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblVehicleMasters")]
        public virtual TblCategoryMaster? Category { get; set; }
    }
}