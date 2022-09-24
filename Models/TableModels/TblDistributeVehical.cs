using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblDistributeVehical")]
    public partial class TblDistributeVehical
    {
        [Key]
        [Column("Distribute_vehicalsId")]
        public int DistributeVehicalsId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? CategoryId { get; set; }
        public int? Total { get; set; }
        public int? OffRoad { get; set; }

        [Column("Form_Date")]
        public string? FormDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblDistributeVehicals")]
        public virtual TblCategoryMaster? Category { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblDistributeVehicals")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}