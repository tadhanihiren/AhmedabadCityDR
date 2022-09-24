using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblVisitation_CrimeBranch")]
    public partial class TblVisitationCrimeBranch
    {
        [Key]
        public int VisitationId { get; set; }

        public int? PoliceStationId { get; set; }

        [Column("GUBATATA_CrimePlace")]
        public string? GubatataCrimePlace { get; set; }

        public string? CrimeVisitPlace { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VisitDate { get; set; }

        [Column("Visiter_OfficerName")]
        public string? VisiterOfficerName { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblVisitationCrimeBranches")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}