using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficInterceptWorkDetailsSel
    {
        public int TrafficInterceptId { get; set; }
        public int TrafficInterceptSubCategoryId { get; set; }
        public string? TrafficeInterceptSubCategoryName { get; set; }
        public string? TrafficInterceptOfficerName { get; set; }
        public int? TotalPlaceCase { get; set; }
        public int? TotalPlaceFineAmount { get; set; }

        [Column("EPCO_188_GP_131")]
        public int? Epco188Gp131 { get; set; }

        [Column("EPCO_279")]
        public int? Epco279 { get; set; }

        [Column("MVACT_207")]
        public int? Mvact207 { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column("EPCO_283")]
        public int? Epco283 { get; set; }

        public int TrafficInterceptCategoryId { get; set; }
        public string? TrafficInterceptCategoryName { get; set; }
        public string? OtherWorkDetails { get; set; }
    }
}