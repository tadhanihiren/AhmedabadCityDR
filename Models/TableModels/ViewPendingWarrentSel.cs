using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewPendingWarrentSel
    {
        public int PendingId { get; set; }
        public int? LastPending { get; set; }
        public int? NewPending { get; set; }
        public int? Budgeted { get; set; }
        public int? WithoutBudgeted { get; set; }
        public int? Transfer { get; set; }
        public int? Pending { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
    }
}