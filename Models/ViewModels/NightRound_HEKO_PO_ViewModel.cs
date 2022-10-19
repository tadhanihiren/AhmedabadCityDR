using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class NightRound_HEKO_PO_ViewModel
    {
        public int NightRound_HEKO_POID { get; set; }   
        public int? PoliceStationId { get; set; }
        public int? TotalOfMotarcycle { get; set; }
        public int? MaofNumber { get; set; }
        public int? NightRound_Heko_PONumber { get; set; }
        public int? DefectNumber { get; set; }
        public int? NotavailabelNumber { get; set; }
        public string? Remark { get; set; }
        public string? PoliceStationName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted
        { get; set; }

    }
}
