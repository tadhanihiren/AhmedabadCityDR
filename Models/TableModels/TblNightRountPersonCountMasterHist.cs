using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblNightRountPersonCountMaster_HIST")]
    public partial class TblNightRountPersonCountMasterHist
    {
        public int NightRoundPersonCountId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? PresentMahekam { get; set; }
        public int? NightRountPersonCount { get; set; }
        public double? Percentage { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
    }
}