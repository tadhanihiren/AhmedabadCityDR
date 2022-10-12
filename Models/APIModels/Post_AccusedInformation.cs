namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_AccusedInformation
    {
        public int AccusedInformationId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? TotalCaches { get; set; }
        public int? AvailableCaches { get; set; }
        public string? NotAvailableCachesReasonRemarks { get; set; }
        public int? TotalAccused { get; set; }
        public int? ArrestedAccused { get; set; }
        public int? RemainingArrestedAccused { get; set; }
        public int? Crpcsection7UnderProcedure { get; set; }
        public int? Crpcsection83UnderProcedure { get; set; }
        public int? Crpcsection8UnderProcedure { get; set; }
        public int? Crpcsection299UnderProcedure { get; set; }
        public int? Ipc174UnderProcedure { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

    }
}
