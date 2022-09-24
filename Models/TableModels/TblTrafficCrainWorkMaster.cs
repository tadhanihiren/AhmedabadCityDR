using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficCrainWorkMaster")]
    public partial class TblTrafficCrainWorkMaster
    {
        [Key]
        public int TraffiCrainWorkId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? TrafficCrainId { get; set; }
        public int? TwoWheelerToingNumber { get; set; }
        public int? TwoWheelerToingFineAmount { get; set; }
        public int? ThreeWheelerToingNumber { get; set; }
        public int? ThreeWheelerToingAmount { get; set; }
        public int? FourWheelerToingNumber { get; set; }
        public int? FourWheelerToingAmount { get; set; }
        public int? HeavyWheelerToingNumber { get; set; }
        public int? HeavyWheelerToingAmount { get; set; }
        public int? TotalToingVehicle { get; set; }
        public int? TotalToingAmount { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? PlaceFineNumber { get; set; }
        public int? PlaceFineAmount { get; set; }

        [ForeignKey("TrafficCrainId")]
        [InverseProperty("TblTrafficCrainWorkMasters")]
        public virtual TblTrafficCrainMaster? TrafficCrain { get; set; }
    }
}