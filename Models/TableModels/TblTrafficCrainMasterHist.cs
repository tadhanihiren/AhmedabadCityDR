using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblTrafficCrainMaster_HIST")]
    public partial class TblTrafficCrainMasterHist
    {
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
    }
}