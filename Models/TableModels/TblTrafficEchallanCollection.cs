using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficEchallanCollection")]
    public partial class TblTrafficEchallanCollection
    {
        [Key]
        public int TrafficEchallanId { get; set; }

        public int? TodaysGeneratedEchallan { get; set; }
        public int? TodaysIssuedEchallan { get; set; }
        public int? TodaysIssuedRemainEchallan { get; set; }
        public int? TodaysGeneratedEchallanAmount { get; set; }
        public long? TodaysIssuedRecoveredEchallanAmount { get; set; }
        public int? RecoverRemainEchallanAmount { get; set; }
        public int? TodaysCollection { get; set; }
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