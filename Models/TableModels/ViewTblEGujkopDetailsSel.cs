using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblEGujkopDetailsSel
    {
        [Column("E_GujkopDetailsId")]
        public int EGujkopDetailsId { get; set; }

        [Column("PoliceStationKhate_Nondhayel_FIR")]
        public int? PoliceStationKhateNondhayelFir { get; set; }

        [Column("E_Gujkop_FIR_Entry")]
        public int? EGujkopFirEntry { get; set; }

        [Column("PoliceStationKhate_Nondhayel_Panchnamu")]
        public int? PoliceStationKhateNondhayelPanchnamu { get; set; }

        [Column("Panchnama_EGujop_Entry")]
        public int? PanchnamaEgujopEntry { get; set; }

        [Column("AtakKarel_Isam")]
        public int? AtakKarelIsam { get; set; }

        [Column("AtakKarel_Isam_EGujkop_Entry")]
        public int? AtakKarelIsamEgujkopEntry { get; set; }

        [Column("AtakKarel_Isam_Egujkop_PhotoUpload")]
        public int? AtakKarelIsamEgujkopPhotoUpload { get; set; }

        [Column("Post_Khate_Mudamal_Pavti_Fadi")]
        public int? PostKhateMudamalPavtiFadi { get; set; }

        [Column("Mudamal_Pavti_EGujkop_Entry")]
        public int? MudamalPavtiEgujkopEntry { get; set; }

        [Column("Chargesheet_ManjurKarel")]
        public int? ChargesheetManjurKarel { get; set; }

        [Column("Chargsheet_EGujkop_Entry")]
        public int? ChargsheetEgujkopEntry { get; set; }

        [Column("ServiceSheet_EGujkop_Entry")]
        public int? ServiceSheetEgujkopEntry { get; set; }

        [Column("PostKhate_Hajar_EmployeeName")]
        public int? PostKhateHajarEmployeeName { get; set; }

        [Column("Employee_healthcard_Entry")]
        public int? EmployeeHealthcardEntry { get; set; }

        [Column("Missing_Janvajog")]
        public int? MissingJanvajog { get; set; }

        [Column("Missing_Janvajog_EGujkop_Entry")]
        public int? MissingJanvajogEgujkopEntry { get; set; }

        [Column("MissingChild_FIRNumber")]
        public int? MissingChildFirnumber { get; set; }

        [Column("Missing_Janvajog_PhotoUpload")]
        public int? MissingJanvajogPhotoUpload { get; set; }

        [Column("MissingChild_PhotoUpload")]
        public int? MissingChildPhotoUpload { get; set; }

        [Column("PocketCop_MobileDevice_Number")]
        public int? PocketCopMobileDeviceNumber { get; set; }

        [Column("NumberOf_PocketCop_Device_login")]
        public int? NumberOfPocketCopDeviceLogin { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int PoliceStationId { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }

        [Column("ServiceSheet_BuckleNo_Name")]
        public string? ServiceSheetBuckleNoName { get; set; }

        [Column("Healthcard_BuckleNo_Name")]
        public string? HealthcardBuckleNoName { get; set; }

        [Column("Data_entry")]
        public int? DataEntry { get; set; }

        public string? PoliceStationName { get; set; }
    }
}