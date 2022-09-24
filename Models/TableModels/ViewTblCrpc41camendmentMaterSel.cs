using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblCrpc41camendmentMaterSel
    {
        [Column("CRPC41CId")]
        public int Crpc41cid { get; set; }

        [Column("Crimes_date")]
        public string? CrimesDate { get; set; }

        [Column("accused_name_address")]
        public string? AccusedNameAddress { get; set; }

        public string? Dated { get; set; }

        [Column("Cognizable_offens")]
        public bool CognizableOffens { get; set; }

        [Column("victims_fingerprint")]
        public bool VictimsFingerprint { get; set; }

        [Column("victims_fingerprint_Remark")]
        public string? VictimsFingerprintRemark { get; set; }

        [Column("CRPC_41C")]
        public string? Crpc41c { get; set; }

        [Column("Designation_Name")]
        public string? DesignationName { get; set; }

        [Column("Release_the_bail")]
        public string? ReleaseTheBail { get; set; }

        [Column("Depart_in_court")]
        public string? DepartInCourt { get; set; }

        [Column("Number_of_accused")]
        public string? NumberOfAccused { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? JaherTarikh { get; set; }
        public string? Address { get; set; }
    }
}