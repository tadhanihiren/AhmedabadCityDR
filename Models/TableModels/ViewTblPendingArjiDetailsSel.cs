using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblPendingArjiDetailsSel
    {
        public int PendingArjiDetailId { get; set; }

        [Column("Under_10Days")]
        public int? Under10days { get; set; }

        [Column("Above_10Days")]
        public int? Above10days { get; set; }

        [Column("Above_OneMonth")]
        public int? AboveOneMonth { get; set; }

        [Column("Above_TwoMonth")]
        public int? AboveTwoMonth { get; set; }

        [Column("Above_ThreeMonth")]
        public int? AboveThreeMonth { get; set; }

        [Column("Above_SixMonth")]
        public int? AboveSixMonth { get; set; }

        [Column("Above_OneYear")]
        public int? AboveOneYear { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int PendingArjiCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}