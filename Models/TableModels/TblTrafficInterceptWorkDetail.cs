using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficInterceptWorkDetails")]
    public partial class TblTrafficInterceptWorkDetail
    {
        [Key]
        public int TrafficInterceptId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? TrafficInterceptSubCategoryId { get; set; }
        public string? TrafficInterceptOfficerName { get; set; }
        public int? TotalPlaceCase { get; set; }
        public int? TotalPlaceFineAmount { get; set; }

        [Column("EPCO_188_GP_131")]
        public int? Epco188Gp131 { get; set; }

        [Column("EPCO_283")]
        public int? Epco283 { get; set; }

        [Column("EPCO_279")]
        public int? Epco279 { get; set; }

        [Column("MVACT_207")]
        public int? Mvact207 { get; set; }

        public string? OtherWorkDetails { get; set; }
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