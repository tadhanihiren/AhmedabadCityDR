using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblAccusedInformation")]
    public partial class TblAccusedInformation
    {
        [Key]
        public int AccusedInformationId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? TotalCaches { get; set; }
        public int? AvailableCaches { get; set; }
        public string? AvailableCachesRemarks { get; set; }
        public int? NotAvailableCachesReason { get; set; }
        public string? NotAvailableCachesReasonRemarks { get; set; }
        public int? TotalAccused { get; set; }
        public string? TotalAccusedRemarks { get; set; }
        public int? ArrestedAccused { get; set; }
        public string? ArrestedAccusedRemarks { get; set; }
        public int? RemainingArrestedAccused { get; set; }
        public string? RemainingArrestedAccusedRemarks { get; set; }

        [Column("CRPCSection_7_UnderProcedure")]
        public int? Crpcsection7UnderProcedure { get; set; }

        [Column("CRPCSection_7_UnderProcedureRemarks")]
        public string? Crpcsection7UnderProcedureRemarks { get; set; }

        [Column("CRPCSection_8_UnderProcedure")]
        public int? Crpcsection8UnderProcedure { get; set; }

        [Column("CRPCSection_8_UnderProcedureRemarks")]
        public string? Crpcsection8UnderProcedureRemarks { get; set; }

        [Column("CRPCSection_83_UnderProcedure")]
        public int? Crpcsection83UnderProcedure { get; set; }

        [Column("CRPCSection_83_UnderProcedureRemarks")]
        public string? Crpcsection83UnderProcedureRemarks { get; set; }

        [Column("CRPCSection_299_UnderProcedure")]
        public int? Crpcsection299UnderProcedure { get; set; }

        [Column("CRPCSection_299_UnderProcedureRemarks")]
        public string? Crpcsection299UnderProcedureRemarks { get; set; }

        [Column("IPC_174_UnderProcedure")]
        public int? Ipc174UnderProcedure { get; set; }

        [Column("IPC_174_UnderProcedureRemakrs")]
        public string? Ipc174UnderProcedureRemakrs { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? TodaysCaseNumber { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblAccusedInformations")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}