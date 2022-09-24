using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficCategoryItmassterBlank
    {
        public string? TrafficCategoryName { get; set; }

        [Column("TrafficPlaceITFineId")]
        public int? TrafficPlaceItfineId { get; set; }

        public int? TrafficCategoryId { get; set; }
        public int? TrafficInterceptSubCategoryId { get; set; }
        public int? WheelerTypeId { get; set; }

        [Column("INTER_TF_Name")]
        [StringLength(10)]
        public string? InterTfName { get; set; }

        [Column("RS50")]
        public int? Rs50 { get; set; }

        [Column("RS100")]
        public int? Rs100 { get; set; }

        [Column("RS200")]
        public int? Rs200 { get; set; }

        [Column("RS300")]
        public int? Rs300 { get; set; }

        [Column("RS500")]
        public int? Rs500 { get; set; }

        [Column("RS1000")]
        public int? Rs1000 { get; set; }

        [Column("EPCO_188_GP_131")]
        public int? Epco188Gp131 { get; set; }

        [Column("EPCO_279")]
        public int? Epco279 { get; set; }

        [Column("MVACT_207")]
        public int? Mvact207 { get; set; }

        public int? Total { get; set; }
        public int? Amount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}