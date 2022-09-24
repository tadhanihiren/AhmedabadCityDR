using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblpendingjanvajogMaster_HIST")]
    public partial class TblpendingjanvajogMasterHist
    {
        public int PendingJanvaJog { get; set; }
        public int? PoliceStationId { get; set; }
        public int? OneMonthUnder { get; set; }
        public int? OneMonthAbove { get; set; }
        public int? TwoMonthAbove { get; set; }
        public int? ThreeMonthAbove { get; set; }
        public int? SixMonthAbove { get; set; }
        public int? OneYearAndAbove { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}