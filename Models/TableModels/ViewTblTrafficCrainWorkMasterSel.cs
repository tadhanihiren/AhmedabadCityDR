using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficCrainWorkMasterSel
    {
        public int TraffiCrainWorkId { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int TrafficCrainId { get; set; }
        public string? TrafficCrainName { get; set; }
        public int? TwoWheelerToingNumber { get; set; }
        public int? TwoWheelerToingFineAmount { get; set; }
        public int? ThreeWheelerToingNumber { get; set; }
        public int? ThreeWheelerToingAmount { get; set; }
        public int? FourWheelerToingNumber { get; set; }
        public int? FourWheelerToingAmount { get; set; }
        public int? HeavyWheelerToingNumber { get; set; }
        public int? HeavyWheelerToingAmount { get; set; }
        public int? TotalToingVehicle { get; set; }
        public int? TotalToingAmount { get; set; }
        public string? Remarks { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

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
        public int? PlaceFineNumber { get; set; }
        public int? PlaceFineAmount { get; set; }
    }
}