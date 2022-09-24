using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblE_GujkopDetails")]
    public partial class TblEGujkopDetail
    {
        [Key]
        [Column("E_GujkopDetailsId")]
        public int EGujkopDetailsId { get; set; }

        public int? PoliceStationId { get; set; }

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

        [Column("ServiceSheet_BuckleNo_Name")]
        public string? ServiceSheetBuckleNoName { get; set; }

        [Column("PostKhate_Hajar_EmployeeName")]
        public int? PostKhateHajarEmployeeName { get; set; }

        [Column("Healthcard_BuckleNo_Name")]
        public string? HealthcardBuckleNoName { get; set; }

        [Column("Employee_healthcard_Entry")]
        public int? EmployeeHealthcardEntry { get; set; }

        [Column("Missing_Janvajog")]
        public int? MissingJanvajog { get; set; }

        [Column("Missing_Janvajog_EGujkop_Entry")]
        public int? MissingJanvajogEgujkopEntry { get; set; }

        [Column("Missing_Janvajog_PhotoUpload")]
        public int? MissingJanvajogPhotoUpload { get; set; }

        [Column("MissingChild_FIRNumber")]
        public int? MissingChildFirnumber { get; set; }

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

        [Column("Data_entry")]
        public int? DataEntry { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblEGujkopDetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}