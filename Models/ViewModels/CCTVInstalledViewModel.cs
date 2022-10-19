using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class CCTVInstalledViewModel
    {
        public int InstallId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? PTZ_installed { get; set; }
        public int? BLT_installed { get; set; }
        public int? DM_installed { get; set; }
        public int? Total_installed { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
    
    }
}
