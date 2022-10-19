using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class CCTVViewModel
    {
        public int CctvId { get; set; }
        public string? Range { get; set; }
        public string? City_Distict { get; set; }
        public string? Cluster { get; set; }
        public string? VenderName { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? PTZ_installed { get; set; }
        public int? BLT_installed { get; set; }
        public int? DM_installed { get; set; }
        public int? Total_installed { get; set; }
        public int? PTZ_funcational { get; set; }
        public int? BLT_funcational { get; set; }
        public int? DM_funcational { get; set; }
        public int? Total_funcation { get; set; }
        public int? PTZ_not_funcational { get; set; }
        public int? BLT_not_funcational { get; set; }
        public int? DM_not_funcational { get; set; }
        public int? Total_not_funcation { get; set; }
        public string? Complaint1 { get; set; }
        public DateTime? ComplaintDate1 { get; set; }
        public string? Complaint2 { get; set; }
        public DateTime? ComplaintDate2 { get; set; }
        public string? Complaint3 { get; set; }
        public DateTime? ComplaintDate3 { get; set; }
        public int? EquipmentsId { get; set; }
        public string? type { get; set; }
        public string? NatureofComplant { get; set; }
        public string? Visited_Remark { get; set; }
        public int? StatusId { get; set; }
        public string? StatusType { get; set; }
        public DateTime? ResolveDate { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        
    }
}
