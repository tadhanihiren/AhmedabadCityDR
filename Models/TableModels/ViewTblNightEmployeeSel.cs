using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblNightEmployeeSel
    {
        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public int NightEmployeeId { get; set; }
        public string? GoingTime { get; set; }
        public string? ReturnTime { get; set; }
        public string? Remarks { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int ZoneId { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}