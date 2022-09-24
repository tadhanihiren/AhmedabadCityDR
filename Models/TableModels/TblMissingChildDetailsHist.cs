using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblMissingChildDetails_HIST")]
    public partial class TblMissingChildDetailsHist
    {
        public int MissingChildId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? MissingPersonName { get; set; }
        public string? MissingReson { get; set; }
        public int? GenderId { get; set; }
        public int? Age { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? MissingDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }

        [Column("MissingApplicationNo_Date")]
        public string? MissingApplicationNoDate { get; set; }

        [Column("PublisherName_Address")]
        public string? PublisherNameAddress { get; set; }

        [StringLength(50)]
        public string? MobileNo { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
    }
}