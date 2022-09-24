using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblWardWiseDetailsPoliceStationWiseSelect
    {
        public int WardCollectionId { get; set; }
        public int? TodaySolidWateCollectionCase { get; set; }
        public int? TodayEstateDepartmentCase { get; set; }
        public int? TodayPoliceStationDepartmentCase { get; set; }
        public int? TotalCases { get; set; }
        public int? TodaySolidWateCollectionAmount { get; set; }
        public int? TodayEstateDepartmentAmount { get; set; }
        public int? TodayPoliceStationDepartmentAmount { get; set; }
        public int? TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int WardId { get; set; }
        public string? WardName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? ShortName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? ZoneName { get; set; }
    }
}