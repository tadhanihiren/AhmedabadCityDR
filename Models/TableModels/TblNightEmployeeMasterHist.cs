using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblNightEmployeeMaster_HIST")]
    public partial class TblNightEmployeeMasterHist
    {
        public int NightEmployeeId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? DesignationId { get; set; }
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
    }
}