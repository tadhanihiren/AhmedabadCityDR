using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewPart15DetailsSel
    {
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? Complainer { get; set; }
        public int CrimesId { get; set; }
        public string? Accused { get; set; }
        public string? Gubatata { get; set; }
        public string? Gujatata { get; set; }
        public string? Gudatata { get; set; }
        public string? CrimePlace { get; set; }
        public string? CrimePurpose { get; set; }
        public string? PersonNameWhoFiledCrime { get; set; }
        public string? InvestigationOfficer { get; set; }
        public string? ShortDetail { get; set; }
        public string? LateComplaintReason { get; set; }
        public string? HdiitsEntry { get; set; }
        public bool Savendansil { get; set; }
        public bool BinSavendansil { get; set; }

        [Column("Complainer_AccusedCriminalHistory")]
        public string? ComplainerAccusedCriminalHistory { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? PoliceStationNumber { get; set; }
        public int CategoryId { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
    }
}