using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblMCRDetails_HITS")]
    public partial class TblMcrdetailsHit
    {
        public int McrId { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("MCRCardNo")]
        public string? McrcardNo { get; set; }

        [Column("NameOfISM")]
        public string? NameOfIsm { get; set; }

        public string? LatestMobileNo { get; set; }

        [Column("LatestAddressOfISM")]
        public string? LatestAddressOfIsm { get; set; }

        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}