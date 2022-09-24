using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    /// <summary>
    /// Contains Accused Information related data.
    /// </summary>
    [Keyless, NotMapped]
    public class AccusedInformationViewModel
    {
        public int? AccusedInformationId { get; set; }
        public int? TotalCaches { get; set; }
        public int? AvailableCaches { get; set; }
        public int? NotAvailableCachesReason { get; set; }
        public int? TotalAccused { get; set; }
        public int? ArrestedAccused { get; set; }
        public int? RemainingArrestedAccused { get; set; }
        public int? CRPCSection_7_UnderProcedure { get; set; }
        public int? CRPCSection_8_UnderProcedure { get; set; }
        public int? CRPCSection_83_UnderProcedure { get; set; }
        public int? CRPCSection_299_UnderProcedure { get; set; }
        public int? IPC_174_UnderProcedure { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ZoneId { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? ZoneName { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? AvailableCachesRemarks { get; set; }
        public string? NotAvailableCachesReasonRemarks { get; set; }
        public string? TotalAccusedRemarks { get; set; }
        public string? ArrestedAccusedRemarks { get; set; }
        public string? RemainingArrestedAccusedRemarks { get; set; }
        public string? CRPCSection_7_UnderProcedureRemarks { get; set; }
        public string? CRPCSection_8_UnderProcedureRemarks { get; set; }
        public string? CRPCSection_83_UnderProcedureRemarks { get; set; }
        public string? CRPCSection_299_UnderProcedureRemarks { get; set; }
        public string? IPC_174_UnderProcedureRemakrs { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? TodaysCaseNumber { get; set; }
    }
}