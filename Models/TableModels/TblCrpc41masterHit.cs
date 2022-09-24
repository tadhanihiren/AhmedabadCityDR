using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblCRPC41Master_HITS")]
    public partial class TblCrpc41masterHit
    {
        [Column("CRPCId")]
        public int Crpcid { get; set; }

        public int PoliceStationId { get; set; }

        [Column("CRPCNumber")]
        public string? Crpcnumber { get; set; }

        public string? Crime { get; set; }
        public string? AccusedName { get; set; }
        public string? VehicalDetails { get; set; }
        public string? AccusedDetails { get; set; }
        public string? ShortDetails { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}