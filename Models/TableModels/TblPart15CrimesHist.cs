using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblPart1_5_Crimes_HIST")]
    public partial class TblPart15CrimesHist
    {
        public int CrimesId { get; set; }
        public string? PoliceStationNumber { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Complainer { get; set; } = null!;
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

        [Column(TypeName = "decimal(10, 8)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(10, 8)")]
        public decimal? Longitude { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column("IPCACT")]
        public string? Ipcact { get; set; }

        [Column("Pidhela_Kabjana_Type")]
        public string? PidhelaKabjanaType { get; set; }
    }
}