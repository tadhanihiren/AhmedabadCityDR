using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficCrainMaster")]
    public partial class TblTrafficCrainMaster
    {
        public TblTrafficCrainMaster()
        {
            TblTrafficCrainWorkMasters = new HashSet<TblTrafficCrainWorkMaster>();
        }

        [Key]
        public int TrafficCrainId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? TrafficCrainCategoryId { get; set; }
        public int? TrafficCrainTypeId { get; set; }
        public string? TrafficCrainName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [InverseProperty("TrafficCrain")]
        public virtual ICollection<TblTrafficCrainWorkMaster> TblTrafficCrainWorkMasters { get; set; }
    }
}