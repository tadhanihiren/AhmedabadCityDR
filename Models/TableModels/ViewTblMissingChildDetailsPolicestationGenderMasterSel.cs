using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblMissingChildDetailsPolicestationGenderMasterSel
    {
        public int MissingChildId { get; set; }
        public string? PoliceStationName { get; set; }
        public int GenderId { get; set; }
        public string? Gender { get; set; }
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

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? MissingPersonName { get; set; }
        public string? MissingReson { get; set; }
        public int? PoliceStationId { get; set; }
    }
}