using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblPoliceStation_VehicleChecking")]
    public partial class TblPoliceStationVehicleChecking
    {
        public int VehicleCheckingId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? Checktwowheeler { get; set; }

        [Column("dandtwowheeler")]
        public int? Dandtwowheeler { get; set; }

        public int? Checkthreewheeler { get; set; }

        [Column("dandthreewheeler")]
        public int? Dandthreewheeler { get; set; }

        public int? Checkfourwheeler { get; set; }

        [Column("dandfourwheeler")]
        public int? Dandfourwheeler { get; set; }

        [Column("detain")]
        public int? Detain { get; set; }

        public string? Remarks { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("PoliceStationId")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual TblSubCategoryMaster? SubCategory { get; set; }
    }
}