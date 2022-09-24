using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewAdminCheckMaster
    {
        [Column("AdminCheckID")]
        public int AdminCheckId { get; set; }

        public int? PoliceStationId { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public string? PoliceStationName { get; set; }
    }
}