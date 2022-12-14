using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblLaborInformationMaster_HITS")]
    public partial class TblLaborInformationMasterHit
    {
        public int LaborInformationId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? CheckedPlace { get; set; }
        public int? CheckedLabor { get; set; }
        public int? TotalLaborersVideography { get; set; }

        [Column("Workers_ARoll_BRollNumber")]
        public int? WorkersArollBrollNumber { get; set; }

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