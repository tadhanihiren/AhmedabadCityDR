using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficMahekamMasterSel
    {
        public int TrafficMahekamId { get; set; }
        public int? ManjurMahekam { get; set; }
        public int? HajarMahekam { get; set; }
        public int? RajaMahekam { get; set; }

        [Column("presentMekhmak")]
        public int? PresentMekhmak { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

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