using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblEmployeeMaster_HITS")]
    public partial class TblEmployeeMasterHit
    {
        public int EmployeeId { get; set; }
        public string? BuckleNo { get; set; }
        public string? EmployeName { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNumber { get; set; }
        public string? PrtiniyukatName { get; set; }

        [Column("todate", TypeName = "datetime")]
        public DateTime? Todate { get; set; }

        [Column("fromdate", TypeName = "datetime")]
        public DateTime? Fromdate { get; set; }

        [StringLength(50)]
        public string? PrtiniyukatPlace { get; set; }

        public int? DesignationId { get; set; }
        public int? RoleId { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? PoliceStationId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsTraffic { get; set; }
    }
}