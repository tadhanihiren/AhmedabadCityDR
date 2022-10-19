namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_CCTV
    {
        public int CctvId { get; set; }
        public string Range { get; set; }
        public string CityDistict { get; set; }
        public string Cluster { get; set; }
        public string VenderName { get; set; }
        public int PoliceStationId { get; set; }
        public int PtzInstalled { get; set; }
        public int BltInstalled { get; set; }
        public int DmInstalled { get; set; }
        public int PtzFuncational { get; set; }
        public int BltFuncational { get; set; }
        public int DmFuncational { get; set; }
        public int PtzNotFuncational { get; set; }
        public int BltNotFuncational { get; set; }
        public int DmNotFuncational { get; set; }
        public string? Complaint1 { get; set; } 
        public string? ComplaintDate1 { get; set; } 
        public string? Complaint2 { get; set; }
        public string? ComplaintDate2 { get; set; }
        public string? Complaint3 { get; set; }
        public string? ComplaintDate3 { get; set; }
        public int EquipmentsId { get; set; }
        public string? NatureofComplant { get; set; }
        public string? VisitedRemark  { get; set; }
        public int StatusId { get; set; }
        public string? ResolveDate { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
