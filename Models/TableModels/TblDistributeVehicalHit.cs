using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblDistributeVehical_HITS")]
    public partial class TblDistributeVehicalHit
    {
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
    }
}