using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficCrainMasterSel
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int TrafficCrainId { get; set; }
        public string? TrafficCrainName { get; set; }
        public int TrafficCrainTypeId { get; set; }
        public string? TrafficCrainTypeName { get; set; }
        public int TrafficCrainCategoryId { get; set; }
        public string? TrafficCrainCategoryName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
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