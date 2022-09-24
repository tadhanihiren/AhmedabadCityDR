using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tbldetainMaster")]
    public partial class TbldetainMaster
    {
        [Key]
        public int DetainId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }

        [Column("psnccount")]
        public int? Psnccount { get; set; }

        [Column("tsnccount")]
        public int? Tsnccount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TbldetainMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SubCategoryId")]
        [InverseProperty("TbldetainMasters")]
        public virtual TblSubCategoryMaster? SubCategory { get; set; }
    }
}