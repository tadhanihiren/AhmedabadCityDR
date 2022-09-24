using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblPoliceStationWiseVehical_HIST")]
    public partial class TblPoliceStationWiseVehicalHist
    {
        public int PoliceStationwiseVehicalId { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("Jeeps_Total")]
        public int? JeepsTotal { get; set; }

        [Column("Jeeps_OFFroad")]
        public int? JeepsOffroad { get; set; }

        [Column("Jeeps_date", TypeName = "datetime")]
        public DateTime? JeepsDate { get; set; }

        [Column("Mobile_total")]
        public int? MobileTotal { get; set; }

        [Column("Mobile_offroad")]
        public int? MobileOffroad { get; set; }

        [Column("Mobile_date", TypeName = "datetime")]
        public DateTime? MobileDate { get; set; }

        [Column("Cycling_total")]
        public int? CyclingTotal { get; set; }

        [Column("Cycling_offroad")]
        public int? CyclingOffroad { get; set; }

        [Column("Cycling_date", TypeName = "datetime")]
        public DateTime? CyclingDate { get; set; }

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