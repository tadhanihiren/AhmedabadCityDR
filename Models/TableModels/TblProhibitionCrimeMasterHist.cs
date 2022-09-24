using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblProhibitionCrimeMaster_HIST")]
    public partial class TblProhibitionCrimeMasterHist
    {
        public int ProhibitioncrimeId { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("pidhela")]
        public int? Pidhela { get; set; }

        [Column("kabjama")]
        public int? Kabjama { get; set; }

        public int? CrimeNumber { get; set; }

        [Column("arrestsNumber")]
        public int? ArrestsNumber { get; set; }

        [Column("issue")]
        public int? Issue { get; set; }

        [Column("mudamal_value")]
        public string? MudamalValue { get; set; }

        [Column("totalNumberCase")]
        public int? TotalNumberCase { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}