using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tbl_ProhibitionRaidCase")]
    public partial class TblProhibitionRaidCase
    {
        [Key]
        public int ProhibitionRaidCaseId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? CategoryId { get; set; }
        public string? PoliceStationNumber { get; set; }

        [Column("IPACT")]
        public string? Ipact { get; set; }

        public string? Gubatata { get; set; }
        public string? CrimePlace { get; set; }
        public string? RaidTimeCriminalName { get; set; }
        public string? RaidingPartyEmployeeName { get; set; }
        public string? InvestigationOfficerName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public string? UpdateValue { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblProhibitionRaidCases")]
        public virtual TblCategoryMaster? Category { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblProhibitionRaidCases")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}