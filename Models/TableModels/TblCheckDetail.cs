using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblCheckDetails")]
    public partial class TblCheckDetail
    {
        public int CheckId { get; set; }
        public int? CrimesId { get; set; }
        public int? EmployeeIdQ { get; set; }
        public int? DesignationIdA { get; set; }
        public string? Question { get; set; }
        public string? Title { get; set; }
        public string? Remarks { get; set; }
        public bool IsNew { get; set; }
        public bool IsActive { get; set; }
        public bool IsClose { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}