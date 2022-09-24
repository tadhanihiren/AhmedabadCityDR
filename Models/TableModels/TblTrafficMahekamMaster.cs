using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficMahekamMaster")]
    public partial class TblTrafficMahekamMaster
    {
        [Key]
        public int TrafficMahekamId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? ManjurMahekam { get; set; }
        public int? HajarMahekam { get; set; }
        public int? RajaMahekam { get; set; }

        [Column("presentMekhmak")]
        public int? PresentMekhmak { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}