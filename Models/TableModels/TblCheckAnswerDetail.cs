using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblCheckAnswerDetails")]
    public partial class TblCheckAnswerDetail
    {
        public int CheckAnswerId { get; set; }
        public int? CheckId { get; set; }
        public int? EmployeeAnswerId { get; set; }
        public int? DesignationId { get; set; }
        public string? AnswerDetails { get; set; }
        public string? Title { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}