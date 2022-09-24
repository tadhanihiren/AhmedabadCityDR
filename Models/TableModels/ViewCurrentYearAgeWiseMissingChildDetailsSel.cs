using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewCurrentYearAgeWiseMissingChildDetailsSel
    {
        public int CurrentYearAgeWiseMissingChildId { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int GenderId { get; set; }
        public string? Gender { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }

        [Column("DOB", TypeName = "datetime")]
        public DateTime? Dob { get; set; }

        public int? ActualAge { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int ZoneId { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
    }
}