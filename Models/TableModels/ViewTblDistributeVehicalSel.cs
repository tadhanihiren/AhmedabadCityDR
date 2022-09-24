using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblDistributeVehicalSel
    {
        [Column("Distribute_vehicalsId")]
        public int DistributeVehicalsId { get; set; }

        public int? Total { get; set; }
        public int? OffRoad { get; set; }

        [Column("Form_Date")]
        public string? FormDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
    }
}