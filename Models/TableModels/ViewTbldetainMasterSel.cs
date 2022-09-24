using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTbldetainMasterSel
    {
        public int DetainId { get; set; }
        public int SubCategoryId { get; set; }

        [Column("psnccount")]
        public int? Psnccount { get; set; }

        [Column("tsnccount")]
        public int? Tsnccount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? SubCategoryName { get; set; }
    }
}