using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficDriveMaster")]
    public partial class TblTrafficDriveMaster
    {
        [Key]
        public int TrafficDriveId { get; set; }

        public int? TrafficDriveCatgeoryId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? Detain { get; set; }
        public int? CaseNumber { get; set; }
        public int? Amount { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("TrafficDriveCatgeoryId")]
        [InverseProperty("TblTrafficDriveMasters")]
        public virtual TblTrafficDriveCategoryMaster? TrafficDriveCatgeory { get; set; }
    }
}