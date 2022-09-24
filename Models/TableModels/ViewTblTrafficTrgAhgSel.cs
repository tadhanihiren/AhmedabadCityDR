using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficTrgAhgSel
    {
        public int EmployeeId { get; set; }
        public string? EmployeName { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? CreatedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public bool IsDelete { get; set; }

        [Column("Traffic_TRB_AHGId")]
        public int TrafficTrbAhgid { get; set; }

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
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int? PoliceStationId { get; set; }
    }
}