using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblNightEmployeeMaster")]
    public partial class TblNightEmployeeMaster
    {
        [Key]
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

        [ForeignKey("DesignationId")]
        [InverseProperty("TblNightEmployeeMasters")]
        public virtual TblDesignationName? Designation { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("TblNightEmployeeMasters")]
        public virtual TblEmployeeMaster? Employee { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblNightEmployeeMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}