using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblDivisionMaster
    {
        public string? ZoneName { get; set; }
        public int ZoneId { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreateUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}