using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTraffic_TRG_AHG_Master")]
    public partial class TblTrafficTrgAhgMaster
    {
        [Key]
        [Column("Traffic_TRB_AHGId")]
        public int TrafficTrbAhgid { get; set; }

        public int? PoliceStationId { get; set; }
        public int? EmployeeId { get; set; }

        [Column("Name_GH_of_TRB")]
        public string? NameGhOfTrb { get; set; }

        [Column("Time_of_arrival_TRB")]
        public string? TimeOfArrivalTrb { get; set; }

        [Column("Point_Details")]
        public string? PointDetails { get; set; }

        [Column("Name_GH_of_AHG")]
        public string? NameGhOfAhg { get; set; }

        [Column("Time_of_arrival_AHG")]
        public string? TimeOfArrivalAhg { get; set; }

        public string? Details { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblTrafficTrgAhgMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}