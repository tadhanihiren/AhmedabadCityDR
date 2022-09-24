using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblPoliceStationMasterSel
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? ShortName { get; set; }
        public string? EnglishName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        public bool IsTraffic { get; set; }
    }
}