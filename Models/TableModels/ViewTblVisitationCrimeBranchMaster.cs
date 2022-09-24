using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblVisitationCrimeBranchMaster
    {
        public int VisitationId { get; set; }

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

        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}