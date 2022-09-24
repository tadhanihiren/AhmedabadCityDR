using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblMissingChildDetails")]
    public partial class TblMissingChildDetail
    {
        [Key]
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

        [ForeignKey("GenderId")]
        [InverseProperty("TblMissingChildDetails")]
        public virtual TblGenderMaster? Gender { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblMissingChildDetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}