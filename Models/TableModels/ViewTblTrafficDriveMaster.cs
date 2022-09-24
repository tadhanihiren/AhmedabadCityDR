using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficDriveMaster
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public string? TrafficCategoryDriveName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DriveDate { get; set; }

        public string? DriveGivenBy { get; set; }
        public int TrafficDriveId { get; set; }
        public int? TrafficDriveCatgeoryId { get; set; }
        public int? Detain { get; set; }
        public int? CaseNumber { get; set; }
        public int? Amount { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int TrafficCategoryDriveId { get; set; }
    }
}