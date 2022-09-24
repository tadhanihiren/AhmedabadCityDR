using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewPoliceStationVehicalSel
    {
        public int VehicleCheckingId { get; set; }
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? Checktwowheeler { get; set; }

        [Column("dandtwowheeler")]
        public int? Dandtwowheeler { get; set; }

        public int? Checkthreewheeler { get; set; }

        [Column("dandthreewheeler")]
        public int? Dandthreewheeler { get; set; }

        public int? Checkfourwheeler { get; set; }

        [Column("dandfourwheeler")]
        public int? Dandfourwheeler { get; set; }

        [Column("detain")]
        public int? Detain { get; set; }

        public string? Remarks { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}