using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmedabadCityDR.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_CCTVInstalled_HITS",
                columns: table => new
                {
                    InstallId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PTZ_installed = table.Column<int>(type: "int", nullable: true),
                    BLT_installed = table.Column<int>(type: "int", nullable: true),
                    DM_installed = table.Column<int>(type: "int", nullable: true),
                    Total_installed = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProhibitionRaidCase_HITS",
                columns: table => new
                {
                    ProhibitionRaidCaseId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPACT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gubatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaidTimeCriminalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaidingPartyEmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_samans_details_HITS",
                columns: table => new
                {
                    samans_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    today_old_pending = table.Column<int>(type: "int", nullable: true),
                    today_new = table.Column<int>(type: "int", nullable: true),
                    today_total = table.Column<int>(type: "int", nullable: true),
                    today_complete = table.Column<int>(type: "int", nullable: true),
                    today_non_complete = table.Column<int>(type: "int", nullable: true),
                    today_transfer = table.Column<int>(type: "int", nullable: true),
                    today_pending = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblAccusedInformation_HITS",
                columns: table => new
                {
                    AccusedInformationId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TotalCaches = table.Column<int>(type: "int", nullable: true),
                    AvailableCaches = table.Column<int>(type: "int", nullable: true),
                    AvailableCachesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotAvailableCachesReason = table.Column<int>(type: "int", nullable: true),
                    NotAvailableCachesReasonRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAccused = table.Column<int>(type: "int", nullable: true),
                    TotalAccusedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrestedAccused = table.Column<int>(type: "int", nullable: true),
                    ArrestedAccusedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingArrestedAccused = table.Column<int>(type: "int", nullable: true),
                    RemainingArrestedAccusedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_7_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_7_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_8_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_8_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_83_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_83_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_299_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_299_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC_174_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    IPC_174_UnderProcedureRemakrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    TodaysCaseNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbladhibitMaster_HITS",
                columns: table => new
                {
                    AdhiBitId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceFine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detaine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MVAct185 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC188 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPAct131 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC279 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC283 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamakuCaseFine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblAtakayatidetails_HITS",
                columns: table => new
                {
                    AtakayatiPagalaSummaryId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    Today = table.Column<int>(type: "int", nullable: true),
                    Last = table.Column<int>(type: "int", nullable: true),
                    T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentYear = table.Column<int>(type: "int", nullable: true),
                    LastYear = table.Column<int>(type: "int", nullable: true),
                    CY_LY = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblAtakayatiPagla_HITS",
                columns: table => new
                {
                    AtakayatiPagalaBackupId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CRPC107 = table.Column<int>(type: "int", nullable: true),
                    CRPC109 = table.Column<int>(type: "int", nullable: true),
                    CRPC110 = table.Column<int>(type: "int", nullable: true),
                    BPACT122C = table.Column<int>(type: "int", nullable: true),
                    BPACT124 = table.Column<int>(type: "int", nullable: true),
                    BPACT56 = table.Column<int>(type: "int", nullable: true),
                    BPACT57 = table.Column<int>(type: "int", nullable: true),
                    BPACT135_1 = table.Column<int>(type: "int", nullable: true),
                    BPACT142 = table.Column<int>(type: "int", nullable: true),
                    Prohi93 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PASA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblAtakayatiPaglaSummary_HITS",
                columns: table => new
                {
                    AtakayatiPagalaSummaryId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    IPC_GPCId = table.Column<int>(type: "int", nullable: true),
                    Todays = table.Column<int>(type: "int", nullable: true),
                    Last = table.Column<int>(type: "int", nullable: true),
                    CurrentMonth = table.Column<int>(type: "int", nullable: true),
                    LastMonth = table.Column<int>(type: "int", nullable: true),
                    CurrentYear = table.Column<int>(type: "int", nullable: true),
                    LastYear = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblAtkayatiPagalaConsolidated_backup",
                columns: table => new
                {
                    AtakayatiPagalaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAtkayatiPagalaConsolidated_backup", x => x.AtakayatiPagalaId);
                });

            migrationBuilder.CreateTable(
                name: "tblAtkayatiPagalaConsolidated_HITS",
                columns: table => new
                {
                    AtakayatiPagalaId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblAutoRickshawDetails_HITS",
                columns: table => new
                {
                    AutoRickshawId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    AutoRickshawNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<int>(type: "int", nullable: true),
                    PermitNumber = table.Column<int>(type: "int", nullable: true),
                    DriversBaseNo = table.Column<int>(type: "int", nullable: true),
                    RCBook = table.Column<int>(type: "int", nullable: true),
                    RCBook_Detail = table.Column<int>(type: "int", nullable: true),
                    InsurancePolicy = table.Column<int>(type: "int", nullable: true),
                    CheckingOperation = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblBandobastDetailMaster_HITS",
                columns: table => new
                {
                    BandoBastId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    BandoBastPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandobastTypeId = table.Column<int>(type: "int", nullable: true),
                    BandobastDetail_ForceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblBandobastTypeMaster",
                columns: table => new
                {
                    BandobastTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandobastType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBandobastTypeMaster", x => x.BandobastTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblCategoryMaster",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategoryMaster", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblCctvMaster_HITS",
                columns: table => new
                {
                    CctvId = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Distict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cluster = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PTZ_installed = table.Column<int>(type: "int", nullable: true),
                    BLT_installed = table.Column<int>(type: "int", nullable: true),
                    DM_installed = table.Column<int>(type: "int", nullable: true),
                    Total_installed = table.Column<int>(type: "int", nullable: true),
                    PTZ_funcational = table.Column<int>(type: "int", nullable: true),
                    BLT_funcational = table.Column<int>(type: "int", nullable: true),
                    DM_funcational = table.Column<int>(type: "int", nullable: true),
                    Total_funcation = table.Column<int>(type: "int", nullable: true),
                    PTZ_not_funcational = table.Column<int>(type: "int", nullable: true),
                    BLT_not_funcational = table.Column<int>(type: "int", nullable: true),
                    DM_not_funcational = table.Column<int>(type: "int", nullable: true),
                    Total_not_funcation = table.Column<int>(type: "int", nullable: true),
                    Complaint1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate1 = table.Column<DateTime>(type: "datetime", nullable: true),
                    Complaint2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate2 = table.Column<DateTime>(type: "datetime", nullable: true),
                    Complaint3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate3 = table.Column<DateTime>(type: "datetime", nullable: true),
                    EquipmentsId = table.Column<int>(type: "int", nullable: true),
                    NatureofComplant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visited_Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    ResolveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCheckAnswerDetails",
                columns: table => new
                {
                    CheckAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckId = table.Column<int>(type: "int", nullable: true),
                    EmployeeAnswerId = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    AnswerDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCheckDetails",
                columns: table => new
                {
                    CheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrimesId = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdQ = table.Column<int>(type: "int", nullable: true),
                    DesignationIdA = table.Column<int>(type: "int", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsClose = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCriminalCountInformation_HITS",
                columns: table => new
                {
                    CriminalCountId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthCrime = table.Column<int>(type: "int", nullable: true),
                    LastMonthCrime = table.Column<int>(type: "int", nullable: true),
                    CurrentYearCrime = table.Column<int>(type: "int", nullable: true),
                    LastYearCrime = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCriminalInformation_HITS",
                columns: table => new
                {
                    CriminalId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrime = table.Column<int>(type: "int", nullable: true),
                    LastCrime = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthCrime = table.Column<int>(type: "int", nullable: true),
                    LastMonthCrime = table.Column<int>(type: "int", nullable: true),
                    CurrentYearCrime = table.Column<int>(type: "int", nullable: true),
                    LastYearCrime = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCRPC41CAmendmentMater_HITS",
                columns: table => new
                {
                    CRPC41CId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Crimes_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accused_name_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cognizable_offens = table.Column<bool>(type: "bit", nullable: false),
                    victims_fingerprint = table.Column<bool>(type: "bit", nullable: false),
                    victims_fingerprint_Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPC_41C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Release_the_bail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depart_in_court = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_of_accused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCRPC41Master_HITS",
                columns: table => new
                {
                    CRPCId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: false),
                    CRPCNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccusedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccusedDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCurrentYearAgeWiseMissingChildDetails_HITS",
                columns: table => new
                {
                    CurrentYearAgeWiseMissingChildId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualAge = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCurrentYearMissingChildDetails_HITS",
                columns: table => new
                {
                    CurrentYearMissingChildId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblDCB_PolicestationMaster",
                columns: table => new
                {
                    DCBId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDCB_PolicestationMaster", x => x.DCBId);
                });

            migrationBuilder.CreateTable(
                name: "tblDCB_PolicestationMaster_HITS",
                columns: table => new
                {
                    DCBId = table.Column<int>(type: "int", nullable: false),
                    ShortDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblDesignationName",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDesignationName", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "tbldetainMaster_HITS",
                columns: table => new
                {
                    DetainId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    psnccount = table.Column<int>(type: "int", nullable: true),
                    tsnccount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblDistributeVehical_HITS",
                columns: table => new
                {
                    Distribute_vehicalsId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    OffRoad = table.Column<int>(type: "int", nullable: true),
                    Form_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblE_GujakopMaster_HITS",
                columns: table => new
                {
                    E_GujakopId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Part1to5number = table.Column<int>(type: "int", nullable: true),
                    Part1to5E_Gujakop = table.Column<int>(type: "int", nullable: true),
                    part6number = table.Column<int>(type: "int", nullable: true),
                    part6E_Gujakop = table.Column<int>(type: "int", nullable: true),
                    ProhiNumber = table.Column<int>(type: "int", nullable: true),
                    ProhiE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    a_amNumber = table.Column<int>(type: "int", nullable: true),
                    a_amE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    acciendentNumber = table.Column<int>(type: "int", nullable: true),
                    acciendentE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    janvajogNumber = table.Column<int>(type: "int", nullable: true),
                    janvajogE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeMaster_HITS",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BuckleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrtiniyukatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    todate = table.Column<DateTime>(type: "datetime", nullable: true),
                    fromdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrtiniyukatPlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsTraffic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblEquipments",
                columns: table => new
                {
                    EquipmentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEquipments", x => x.EquipmentsId);
                });

            migrationBuilder.CreateTable(
                name: "tblEquipments_HITS",
                columns: table => new
                {
                    EquipmentsId = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblForm3A_HITS",
                columns: table => new
                {
                    AkasmatId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Complainant_accused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complainant_accusedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryofPast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblGenderMaster",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenderMaster", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "tblHistoryMissingAgeWiseChild_HITS",
                columns: table => new
                {
                    HistoryMissingAgeWiseId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Missingboy = table.Column<int>(type: "int", nullable: true),
                    Missinggirl = table.Column<int>(type: "int", nullable: true),
                    MissingChildDetails = table.Column<int>(type: "int", nullable: true),
                    Returnboy = table.Column<int>(type: "int", nullable: true),
                    Returngirl = table.Column<int>(type: "int", nullable: true),
                    ReturnChildDetails = table.Column<int>(type: "int", nullable: true),
                    Missing1to5Girl = table.Column<int>(type: "int", nullable: true),
                    Missing1to5boy = table.Column<int>(type: "int", nullable: true),
                    Missing6to12Girl = table.Column<int>(type: "int", nullable: true),
                    Missing6to12boy = table.Column<int>(type: "int", nullable: true),
                    Missing13to18Girl = table.Column<int>(type: "int", nullable: true),
                    Missing13to18boy = table.Column<int>(type: "int", nullable: true),
                    return1to5Girl = table.Column<int>(type: "int", nullable: true),
                    return1to5boy = table.Column<int>(type: "int", nullable: true),
                    return6to12Girl = table.Column<int>(type: "int", nullable: true),
                    return6to12boy = table.Column<int>(type: "int", nullable: true),
                    return13to18Girl = table.Column<int>(type: "int", nullable: true),
                    return13to18boy = table.Column<int>(type: "int", nullable: true),
                    totalmissing = table.Column<int>(type: "int", nullable: true),
                    totalreturn = table.Column<int>(type: "int", nullable: true),
                    per = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblIndexPatrakMaster",
                columns: table => new
                {
                    PatrakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patrak_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    GroupNo = table.Column<int>(type: "int", nullable: true),
                    IsTraffic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIndexPatrakMaster", x => x.PatrakId);
                });

            migrationBuilder.CreateTable(
                name: "tblIPC_GPCMaster",
                columns: table => new
                {
                    IPC_GPCId = table.Column<int>(type: "int", nullable: false),
                    IPC_GPCName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIPC_GPCMaster", x => x.IPC_GPCId);
                });

            migrationBuilder.CreateTable(
                name: "tblIPC_GPCMaster_HITS",
                columns: table => new
                {
                    IPC_GPCId = table.Column<int>(type: "int", nullable: false),
                    IPC_GPCName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblkacheriMaster",
                columns: table => new
                {
                    KacheriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KacheriName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblkacheriMaster", x => x.KacheriId);
                });

            migrationBuilder.CreateTable(
                name: "tblLaborInformationMaster_HITS",
                columns: table => new
                {
                    LaborInformationId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CheckedPlace = table.Column<int>(type: "int", nullable: true),
                    CheckedLabor = table.Column<int>(type: "int", nullable: true),
                    TotalLaborersVideography = table.Column<int>(type: "int", nullable: true),
                    Workers_ARoll_BRollNumber = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveApplicationMaster_HITS",
                columns: table => new
                {
                    LeaveApplicationID = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    InchargeDesignationId = table.Column<int>(type: "int", nullable: true),
                    InchargePoliceStationId = table.Column<int>(type: "int", nullable: true),
                    InchargeEmployeeId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    InchargeSectorId = table.Column<int>(type: "int", nullable: true),
                    InchargeZoneId = table.Column<int>(type: "int", nullable: true),
                    InchargeDivisionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveTypeMaster",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeaveTypeMaster", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveTypeMaster_HITS",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblMCRDetails_HITS",
                columns: table => new
                {
                    McrId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    MCRCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfISM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestAddressOfISM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblMissingChildDetails_HIST",
                columns: table => new
                {
                    MissingChildId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    MissingPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissingReson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    MissingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MissingApplicationNo_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblMonthWiseReport_HIST",
                columns: table => new
                {
                    MonthWiseReportId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblNightEmployeeMaster_HIST",
                columns: table => new
                {
                    NightEmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    GoingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblNightRound_HEKO_POMaster_HIST",
                columns: table => new
                {
                    NightRound_HEKO_POID = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TotalOfMotarcycle = table.Column<int>(type: "int", nullable: true),
                    MaofNumber = table.Column<int>(type: "int", nullable: true),
                    NightRound_Heko_PONumber = table.Column<int>(type: "int", nullable: true),
                    DefectNumber = table.Column<int>(type: "int", nullable: true),
                    NotavailabelNumber = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblNightRound_HIST",
                columns: table => new
                {
                    NightRoundId = table.Column<int>(type: "int", nullable: false),
                    NightRoundOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    GoingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NightRoundPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblNightRountPersonCountMaster_HIST",
                columns: table => new
                {
                    NightRoundPersonCountId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PresentMahekam = table.Column<int>(type: "int", nullable: true),
                    NightRountPersonCount = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblOfiiceWisePendingApplication_HIST",
                columns: table => new
                {
                    OfficeWisePendingApplicationId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    TenDaysAbove = table.Column<int>(type: "int", nullable: true),
                    OneMonthAbove = table.Column<int>(type: "int", nullable: true),
                    TwoMonthAbove = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthAbove = table.Column<int>(type: "int", nullable: true),
                    SixMonthAbove = table.Column<int>(type: "int", nullable: true),
                    OneYearAndAbove = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblPart1_5_Crimes_HIST",
                columns: table => new
                {
                    CrimesId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    Complainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gubatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gujatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gudatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimePurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonNameWhoFiledCrime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LateComplaintReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HdiitsEntry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Savendansil = table.Column<bool>(type: "bit", nullable: false),
                    BinSavendansil = table.Column<bool>(type: "bit", nullable: false),
                    Complainer_AccusedCriminalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IPCACT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pidhela_Kabjana_Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblPendingArjiCategory",
                columns: table => new
                {
                    PendingArjiCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPendingArjiCategory", x => x.PendingArjiCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblPendingArjiDetails_HIST",
                columns: table => new
                {
                    PendingArjiDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PendingArjiCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Under_10Days = table.Column<int>(type: "int", nullable: true),
                    Above_10Days = table.Column<int>(type: "int", nullable: true),
                    Above_OneMonth = table.Column<int>(type: "int", nullable: true),
                    Above_TwoMonth = table.Column<int>(type: "int", nullable: true),
                    Above_ThreeMonth = table.Column<int>(type: "int", nullable: true),
                    Above_SixMonth = table.Column<int>(type: "int", nullable: true),
                    Above_OneYear = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblpendingjanvajogMaster_HIST",
                columns: table => new
                {
                    PendingJanvaJog = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    OneMonthUnder = table.Column<int>(type: "int", nullable: true),
                    OneMonthAbove = table.Column<int>(type: "int", nullable: true),
                    TwoMonthAbove = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthAbove = table.Column<int>(type: "int", nullable: true),
                    SixMonthAbove = table.Column<int>(type: "int", nullable: true),
                    OneYearAndAbove = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblPendingWarrant_HIST",
                columns: table => new
                {
                    PendingId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    LastPending = table.Column<int>(type: "int", nullable: true),
                    NewPending = table.Column<int>(type: "int", nullable: true),
                    Budgeted = table.Column<int>(type: "int", nullable: true),
                    WithoutBudgeted = table.Column<int>(type: "int", nullable: true),
                    Transfer = table.Column<int>(type: "int", nullable: true),
                    Pending = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblPidhela_Kabja_CategoryMaster",
                columns: table => new
                {
                    Pidhela_Kabja_CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pidhela_Kabja_CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPidhela_Kabja_CategoryMaster", x => x.Pidhela_Kabja_CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblPoliceStation_VehicleChecking_HIST",
                columns: table => new
                {
                    VehicleCheckingId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Checktwowheeler = table.Column<int>(type: "int", nullable: true),
                    dandtwowheeler = table.Column<int>(type: "int", nullable: true),
                    Checkthreewheeler = table.Column<int>(type: "int", nullable: true),
                    dandthreewheeler = table.Column<int>(type: "int", nullable: true),
                    Checkfourwheeler = table.Column<int>(type: "int", nullable: true),
                    dandfourwheeler = table.Column<int>(type: "int", nullable: true),
                    detain = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblPoliceStationMaster",
                columns: table => new
                {
                    PoliceStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    IsTraffic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPoliceStationMaster_1", x => x.PoliceStationId);
                });

            migrationBuilder.CreateTable(
                name: "tblPoliceStationWisePendingApplication_HIST",
                columns: table => new
                {
                    PoliceStationWisePendingApplicationId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    KacheriId = table.Column<int>(type: "int", nullable: true),
                    TenDaysBelow = table.Column<int>(type: "int", nullable: true),
                    TenDaysAbove = table.Column<int>(type: "int", nullable: true),
                    OneMonthUnder = table.Column<int>(type: "int", nullable: true),
                    OneMonthAbove = table.Column<int>(type: "int", nullable: true),
                    TwoMonthAbove = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthAbove = table.Column<int>(type: "int", nullable: true),
                    SixMonthAbove = table.Column<int>(type: "int", nullable: true),
                    OneYearAndAbove = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblPoliceStationWiseVehical_HIST",
                columns: table => new
                {
                    PoliceStationwiseVehicalId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Jeeps_Total = table.Column<int>(type: "int", nullable: true),
                    Jeeps_OFFroad = table.Column<int>(type: "int", nullable: true),
                    Jeeps_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Mobile_total = table.Column<int>(type: "int", nullable: true),
                    Mobile_offroad = table.Column<int>(type: "int", nullable: true),
                    Mobile_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cycling_total = table.Column<int>(type: "int", nullable: true),
                    Cycling_offroad = table.Column<int>(type: "int", nullable: true),
                    Cycling_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblProhibitionCrimeMaster_HIST",
                columns: table => new
                {
                    ProhibitioncrimeId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    pidhela = table.Column<int>(type: "int", nullable: true),
                    kabjama = table.Column<int>(type: "int", nullable: true),
                    CrimeNumber = table.Column<int>(type: "int", nullable: true),
                    arrestsNumber = table.Column<int>(type: "int", nullable: true),
                    issue = table.Column<int>(type: "int", nullable: true),
                    mudamal_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalNumberCase = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblRoleMaster",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoleMaster", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tblSamelCategoryMaster",
                columns: table => new
                {
                    SamelCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SamelCaregoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSamelCategoryMaster", x => x.SamelCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblSamelPatrakMaster_HIST",
                columns: table => new
                {
                    SamelId = table.Column<int>(type: "int", nullable: false),
                    PatrakId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SamelCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblStateMaster",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStateMaster", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "tblStationery_HIST",
                columns: table => new
                {
                    stationaryId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Computer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Giswan_Connectivity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax_machine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Xerox_machine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Other_Stationary_Stocks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblStatusMaster",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStatusMaster", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "tblSubCategoryCount",
                columns: table => new
                {
                    RowNumber = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTraffic_TRB_HomeGuard_Master_HIST",
                columns: table => new
                {
                    Traffic_TRB_HomeGuardId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TRBManjurNumber = table.Column<int>(type: "int", nullable: true),
                    TRBAttendanceMorning = table.Column<int>(type: "int", nullable: true),
                    TRBAttendanceEvening = table.Column<int>(type: "int", nullable: true),
                    HomeGuardManjurNumber = table.Column<int>(type: "int", nullable: true),
                    HomeGuardAttendanceMorning = table.Column<int>(type: "int", nullable: true),
                    HomeGuardAttendanceEvening = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTraffic_TRG_AHG_Master_HIST",
                columns: table => new
                {
                    Traffic_TRB_AHGId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Name_GH_of_TRB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time_of_arrival_TRB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_GH_of_AHG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time_of_arrival_AHG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficAccidentalDetails",
                columns: table => new
                {
                    TrafficAccidentalId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PoliceCrimeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimesDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    CrimeDeclaredDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplainerNameAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccusedNameAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Death_Injured_Personname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficAccidentalDetails", x => x.TrafficAccidentalId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficAccidentalDetails_HIST",
                columns: table => new
                {
                    TrafficAccidentalId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PoliceCrimeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimesDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    CrimeDeclaredDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplainerNameAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccusedNameAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Death_Injured_Personname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTraffiCategoryMaster",
                columns: table => new
                {
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTraffiCategoryMaster", x => x.TrafficCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficCategorySummaryMasters",
                columns: table => new
                {
                    TrafficSummaryCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficSummaryCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficCategorySummaryMasters", x => x.TrafficSummaryCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficCrainCategoryMaster",
                columns: table => new
                {
                    TrafficCrainCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCrainCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficCrainCategoryMaster", x => x.TrafficCrainCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficCrainMaster",
                columns: table => new
                {
                    TrafficCrainId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainCategoryId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainTypeId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficCrainMaster", x => x.TrafficCrainId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficCrainMaster_HIST",
                columns: table => new
                {
                    TrafficCrainId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainCategoryId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainTypeId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficCrainTypeMaster",
                columns: table => new
                {
                    TrafficCrainTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCrainTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficCrainTypeMaster", x => x.TrafficCrainTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficCrainWorkMaster_HIST",
                columns: table => new
                {
                    TraffiCrainWorkId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainId = table.Column<int>(type: "int", nullable: true),
                    TwoWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    TwoWheelerToingFineAmount = table.Column<int>(type: "int", nullable: true),
                    ThreeWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    ThreeWheelerToingAmount = table.Column<int>(type: "int", nullable: true),
                    FourWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    FourWheelerToingAmount = table.Column<int>(type: "int", nullable: true),
                    HeavyWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    HeavyWheelerToingAmount = table.Column<int>(type: "int", nullable: true),
                    TotalToingVehicle = table.Column<int>(type: "int", nullable: true),
                    TotalToingAmount = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    PlaceFineNumber = table.Column<int>(type: "int", nullable: true),
                    PlaceFineAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficDriveCategoryMaster",
                columns: table => new
                {
                    TrafficCategoryDriveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryDriveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DriveGivenBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficDriveCategoryMaster", x => x.TrafficCategoryDriveId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficDriveMaster_HIST",
                columns: table => new
                {
                    TrafficDriveId = table.Column<int>(type: "int", nullable: false),
                    TrafficDriveCatgeoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Detain = table.Column<int>(type: "int", nullable: true),
                    CaseNumber = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficEchallanCollection",
                columns: table => new
                {
                    TrafficEchallanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodaysGeneratedEchallan = table.Column<int>(type: "int", nullable: true),
                    TodaysIssuedEchallan = table.Column<int>(type: "int", nullable: true),
                    TodaysIssuedRemainEchallan = table.Column<int>(type: "int", nullable: true),
                    TodaysGeneratedEchallanAmount = table.Column<int>(type: "int", nullable: true),
                    TodaysIssuedRecoveredEchallanAmount = table.Column<long>(type: "bigint", nullable: true),
                    RecoverRemainEchallanAmount = table.Column<int>(type: "int", nullable: true),
                    TodaysCollection = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficEchallanCollection", x => x.TrafficEchallanId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficEchallanCollection_HIST",
                columns: table => new
                {
                    TrafficEchallanId = table.Column<int>(type: "int", nullable: false),
                    TodaysGeneratedEchallan = table.Column<int>(type: "int", nullable: true),
                    TodaysIssuedEchallan = table.Column<int>(type: "int", nullable: true),
                    TodaysIssuedRemainEchallan = table.Column<int>(type: "int", nullable: true),
                    TodaysGeneratedEchallanAmount = table.Column<int>(type: "int", nullable: true),
                    TodaysIssuedRecoveredEchallanAmount = table.Column<long>(type: "bigint", nullable: true),
                    RecoverRemainEchallanAmount = table.Column<int>(type: "int", nullable: true),
                    TodaysCollection = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficGhasCharaMaster",
                columns: table => new
                {
                    TrafficGhasCharaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficGhasCharaMaster", x => x.TrafficGhasCharaId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficGhasCharaMaster_HIST",
                columns: table => new
                {
                    TrafficGhasCharaId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficInterceptCategoryMaster",
                columns: table => new
                {
                    TrafficInterceptCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficInterceptCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficInterceptCategoryMaster", x => x.TrafficInterceptCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficInterceptWorkDetails",
                columns: table => new
                {
                    TrafficInterceptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficInterceptSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    TrafficInterceptOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPlaceCase = table.Column<int>(type: "int", nullable: true),
                    TotalPlaceFineAmount = table.Column<int>(type: "int", nullable: true),
                    EPCO_188_GP_131 = table.Column<int>(type: "int", nullable: true),
                    EPCO_283 = table.Column<int>(type: "int", nullable: true),
                    EPCO_279 = table.Column<int>(type: "int", nullable: true),
                    MVACT_207 = table.Column<int>(type: "int", nullable: true),
                    OtherWorkDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficInterceptWorkDetails", x => x.TrafficInterceptId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficInterceptWorkDetails_HIST",
                columns: table => new
                {
                    TrafficInterceptId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficInterceptSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    TrafficInterceptOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPlaceCase = table.Column<int>(type: "int", nullable: true),
                    TotalPlaceFineAmount = table.Column<int>(type: "int", nullable: true),
                    EPCO_188_GP_131 = table.Column<int>(type: "int", nullable: true),
                    EPCO_283 = table.Column<int>(type: "int", nullable: true),
                    EPCO_279 = table.Column<int>(type: "int", nullable: true),
                    MVACT_207 = table.Column<int>(type: "int", nullable: true),
                    OtherWorkDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficIPC_188",
                columns: table => new
                {
                    TrafficIPC_188Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficIPC_188", x => x.TrafficIPC_188Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficIPC_188_HIST",
                columns: table => new
                {
                    TrafficIPC_188Id = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficIPC_283",
                columns: table => new
                {
                    TrafficIPCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficIPC_283", x => x.TrafficIPCId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficIPC_283_HIST",
                columns: table => new
                {
                    TrafficIPCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficJam_Details_ALL",
                columns: table => new
                {
                    TrafficjamId_ALL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Caller_50_100 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrafficjamPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GotMessageTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeatIncharge_InformationTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeatIncharge_GoingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReachedTimeToPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReducedTrafficJam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonforTrafficJam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowmuchtimeTrafficJam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACP_DCP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficJam_Details_ALL", x => x.TrafficjamId_ALL);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficJam_Details_ALL_HIST",
                columns: table => new
                {
                    TrafficjamId_ALL = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Caller_50_100 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrafficjamPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GotMessageTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeatIncharge_InformationTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeatIncharge_GoingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReachedTimeToPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReducedTrafficJam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonforTrafficJam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowmuchtimeTrafficJam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACP_DCP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficMahekamMaster",
                columns: table => new
                {
                    TrafficMahekamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    ManjurMahekam = table.Column<int>(type: "int", nullable: true),
                    HajarMahekam = table.Column<int>(type: "int", nullable: true),
                    RajaMahekam = table.Column<int>(type: "int", nullable: true),
                    presentMekhmak = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficMahekamMaster", x => x.TrafficMahekamId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficMahekamMaster_HIST",
                columns: table => new
                {
                    TrafficMahekamId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    ManjurMahekam = table.Column<int>(type: "int", nullable: true),
                    HajarMahekam = table.Column<int>(type: "int", nullable: true),
                    RajaMahekam = table.Column<int>(type: "int", nullable: true),
                    presentMekhmak = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficMVACTDetails",
                columns: table => new
                {
                    TrafficMVACTId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficMVACTDetails", x => x.TrafficMVACTId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficMVACTDetails_HIST",
                columns: table => new
                {
                    TrafficMVACTId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPart1_5_Details",
                columns: table => new
                {
                    TrafficPart_1_to_5_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPart1_5_Details", x => x.TrafficPart_1_to_5_Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPart1_5_Details_HIST",
                columns: table => new
                {
                    TrafficPart_1_to_5_Id = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineDetails_HIST",
                columns: table => new
                {
                    TrafficPlaceFineId = table.Column<int>(type: "int", nullable: false),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    RS200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    PROSI = table.Column<int>(type: "int", nullable: true),
                    RTO = table.Column<int>(type: "int", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineDetails_NULL",
                columns: table => new
                {
                    TrafficPlaceFineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    Rs200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    PROSI = table.Column<int>(type: "int", nullable: true),
                    RTO = table.Column<int>(type: "int", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPlaceFineDetails_NULL", x => x.TrafficPlaceFineId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineDetailsJET_HIST",
                columns: table => new
                {
                    TrafficPlaceJetFineId = table.Column<int>(type: "int", nullable: false),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    RS200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    PROSI = table.Column<int>(type: "int", nullable: true),
                    RTO = table.Column<int>(type: "int", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineMaster_HIST",
                columns: table => new
                {
                    TrafficPlaceFineId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceITDetails_NULL",
                columns: table => new
                {
                    TrafficPlaceITFineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    TrafficInterceptSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    INTER_TF_Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    RS200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    EPCO_188_GP_131 = table.Column<int>(type: "int", nullable: true),
                    EPCO_279 = table.Column<int>(type: "int", nullable: true),
                    MVACT_207 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPlaceITDetails_NULL", x => x.TrafficPlaceITFineId);
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficSignalBlinkerigh_HIST",
                columns: table => new
                {
                    TrafficSignalBlinkerighId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    locations_blinkering_area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blinking_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficSignalMaster_HIST",
                columns: table => new
                {
                    trafficSignalId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    signals_area = table.Column<int>(type: "int", nullable: true),
                    signals_progress = table.Column<int>(type: "int", nullable: true),
                    signals_closed_condition = table.Column<int>(type: "int", nullable: true),
                    reason_closed_condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    procedures_closed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficSummaryDetails_HIST",
                columns: table => new
                {
                    TrafficSummaryId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficSummaryCategoryId = table.Column<int>(type: "int", nullable: true),
                    TodaysCaseNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCaseNumber = table.Column<int>(type: "int", nullable: true),
                    T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    CM_PM = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    CY_PY = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficTobacoMaster_HIST",
                columns: table => new
                {
                    TrafficTobacoId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblVisitation_CrimeBranch_HIST",
                columns: table => new
                {
                    VisitationId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    GUBATATA_CrimePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimeVisitPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "date", nullable: true),
                    Visiter_OfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblWardMaster",
                columns: table => new
                {
                    WardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWardMaster", x => x.WardId);
                });

            migrationBuilder.CreateTable(
                name: "tblWardWiseJetDetails_HITS",
                columns: table => new
                {
                    WardCollectionId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    TodaySolidWateCollectionCase = table.Column<int>(type: "int", nullable: true),
                    TodayEstateDepartmentCase = table.Column<int>(type: "int", nullable: true),
                    TodayPoliceStationDepartmentCase = table.Column<int>(type: "int", nullable: true),
                    TotalCases = table.Column<int>(type: "int", nullable: true),
                    TodaySolidWateCollectionAmount = table.Column<int>(type: "int", nullable: true),
                    TodayEstateDepartmentAmount = table.Column<int>(type: "int", nullable: true),
                    TodayPoliceStationDepartmentAmount = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblWheelerType",
                columns: table => new
                {
                    WheelerTypeId = table.Column<int>(type: "int", nullable: false),
                    WheelerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWheelerType", x => x.WheelerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblZoneMaster",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZoneMaster", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "tblCriminalInformation",
                columns: table => new
                {
                    CriminalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrime = table.Column<int>(type: "int", nullable: true),
                    LastCrime = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthCrime = table.Column<int>(type: "int", nullable: true),
                    LastMonthCrime = table.Column<int>(type: "int", nullable: true),
                    CurrentYearCrime = table.Column<int>(type: "int", nullable: true),
                    LastYearCrime = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCriminalInformation", x => x.CriminalId);
                    table.ForeignKey(
                        name: " FK_tblCriminalInformation_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblMonthWiseReport",
                columns: table => new
                {
                    MonthWiseReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMonthWiseReport", x => x.MonthWiseReportId);
                    table.ForeignKey(
                        name: " FK_tblMonthWiseReport_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblSubCategoryMaster",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryGname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubCategoryMaster", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: " FK_tblSubCategoryMaster_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblVehicleMaster",
                columns: table => new
                {
                    WheelerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    WheelerType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVehicleMaster", x => x.WheelerId);
                    table.ForeignKey(
                        name: " FK_tblVehicleMaster_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_CCTVInstalled",
                columns: table => new
                {
                    InstallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PTZ_installed = table.Column<int>(type: "int", nullable: true),
                    BLT_installed = table.Column<int>(type: "int", nullable: true),
                    DM_installed = table.Column<int>(type: "int", nullable: true),
                    Total_installed = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CCTVInstalled", x => x.InstallId);
                    table.ForeignKey(
                        name: " FK_tbl_CCTVInstalled_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProhibitionRaidCase",
                columns: table => new
                {
                    ProhibitionRaidCaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPACT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gubatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaidTimeCriminalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaidingPartyEmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProhibitionRaidCase", x => x.ProhibitionRaidCaseId);
                    table.ForeignKey(
                        name: " FK_tbl_ProhibitionRaidCase_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: " FK_tbl_ProhibitionRaidCase_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_samans_details",
                columns: table => new
                {
                    samans_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    today_old_pending = table.Column<int>(type: "int", nullable: true),
                    today_new = table.Column<int>(type: "int", nullable: true),
                    today_total = table.Column<int>(type: "int", nullable: true),
                    today_complete = table.Column<int>(type: "int", nullable: true),
                    today_non_complete = table.Column<int>(type: "int", nullable: true),
                    today_transfer = table.Column<int>(type: "int", nullable: true),
                    today_pending = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_samans_details", x => x.samans_id);
                    table.ForeignKey(
                        name: " FK_tbl_samans_details_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: " FK_tbl_samans_details_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblAccusedInformation",
                columns: table => new
                {
                    AccusedInformationId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TotalCaches = table.Column<int>(type: "int", nullable: true),
                    AvailableCaches = table.Column<int>(type: "int", nullable: true),
                    AvailableCachesRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotAvailableCachesReason = table.Column<int>(type: "int", nullable: true),
                    NotAvailableCachesReasonRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAccused = table.Column<int>(type: "int", nullable: true),
                    TotalAccusedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrestedAccused = table.Column<int>(type: "int", nullable: true),
                    ArrestedAccusedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingArrestedAccused = table.Column<int>(type: "int", nullable: true),
                    RemainingArrestedAccusedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_7_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_7_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_8_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_8_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_83_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_83_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPCSection_299_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    CRPCSection_299_UnderProcedureRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC_174_UnderProcedure = table.Column<int>(type: "int", nullable: true),
                    IPC_174_UnderProcedureRemakrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    TodaysCaseNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccusedInformation", x => x.AccusedInformationId);
                    table.ForeignKey(
                        name: " FK_tblAccusedInformation_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tbladhibitMaster",
                columns: table => new
                {
                    AdhiBitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceFine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detaine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MVAct185 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC188 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPAct131 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC279 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPC283 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamakuCaseFine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbladhibitMaster", x => x.AdhiBitId);
                    table.ForeignKey(
                        name: " FK_tbladhibitMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblAdminCheckMaster",
                columns: table => new
                {
                    AdminCheckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdminCheckMaster", x => x.AdminCheckID);
                    table.ForeignKey(
                        name: " FK_tblAdminCheckMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblAdminWisePendingApplicationMaster",
                columns: table => new
                {
                    AdminWisePendingApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    KacheriId = table.Column<int>(type: "int", nullable: true),
                    TotalApplication = table.Column<int>(type: "int", nullable: true),
                    bakiApplication = table.Column<int>(type: "int", nullable: true),
                    TenDaysBelow = table.Column<int>(type: "int", nullable: true),
                    TenDaysAbove = table.Column<int>(type: "int", nullable: true),
                    OneMonthUnder = table.Column<int>(type: "int", nullable: true),
                    OneMonthAbove = table.Column<int>(type: "int", nullable: true),
                    TwoMonthAbove = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthAbove = table.Column<int>(type: "int", nullable: true),
                    SixMonthAbove = table.Column<int>(type: "int", nullable: true),
                    OneYearAndAbove = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdminWisePendingApplicationMaster", x => x.AdminWisePendingApplicationId);
                    table.ForeignKey(
                        name: " FK_tblAdminWisePendingApplicationMaster_tblkacheriMaster",
                        column: x => x.KacheriId,
                        principalTable: "tblkacheriMaster",
                        principalColumn: "KacheriId");
                    table.ForeignKey(
                        name: " FK_tblAdminWisePendingApplicationMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblAtakayatiPagla",
                columns: table => new
                {
                    AtakayatiPagalaBackupId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CRPC107 = table.Column<int>(type: "int", nullable: true),
                    CRPC109 = table.Column<int>(type: "int", nullable: true),
                    CRPC110 = table.Column<int>(type: "int", nullable: true),
                    BPACT122C = table.Column<int>(type: "int", nullable: true),
                    BPACT124 = table.Column<int>(type: "int", nullable: true),
                    BPACT56 = table.Column<int>(type: "int", nullable: true),
                    BPACT57 = table.Column<int>(type: "int", nullable: true),
                    BPACT135_1 = table.Column<int>(type: "int", nullable: true),
                    BPACT142 = table.Column<int>(type: "int", nullable: true),
                    Prohi93 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PASA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAtakayatiPagla", x => x.AtakayatiPagalaBackupId);
                    table.ForeignKey(
                        name: " FK_tblAtakayatiPagla_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblAtakKarel_Esam",
                columns: table => new
                {
                    EsamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Crimes_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accused_name_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cognizable_offens = table.Column<bool>(type: "bit", nullable: false),
                    victims_fingerprint = table.Column<bool>(type: "bit", nullable: false),
                    victims_fingerprint_Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPC_41C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Release_the_bail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depart_in_court = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_of_accused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAtakKarel_Esam", x => x.EsamId);
                    table.ForeignKey(
                        name: " FK_tblAtakKarel_Esam_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblAtkayatiPagalaConsolidated",
                columns: table => new
                {
                    AtakayatiPagalaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAtkayatiPagalaConsolidated", x => x.AtakayatiPagalaId);
                    table.ForeignKey(
                        name: " FK_tblAtkayatiPagalaConsolidated_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblAutoRickshawDetails",
                columns: table => new
                {
                    AutoRickshawId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    AutoRickshawNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<int>(type: "int", nullable: true),
                    PermitNumber = table.Column<int>(type: "int", nullable: true),
                    DriversBaseNo = table.Column<int>(type: "int", nullable: true),
                    RCBook = table.Column<int>(type: "int", nullable: true),
                    RCBook_Detail = table.Column<int>(type: "int", nullable: true),
                    InsurancePolicy = table.Column<int>(type: "int", nullable: true),
                    CheckingOperation = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAutoRickshawDetails", x => x.AutoRickshawId);
                    table.ForeignKey(
                        name: " FK_tblAutoRickshawDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblBandobastDetailMaster",
                columns: table => new
                {
                    BandoBastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    BandoBastPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandobastTypeId = table.Column<int>(type: "int", nullable: true),
                    BandobastDetail_ForceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBandobastDetailMaster", x => x.BandoBastId);
                    table.ForeignKey(
                        name: " FK_tblBandobastDetailMaster_tblBandobastTypeMaster",
                        column: x => x.BandobastTypeId,
                        principalTable: "tblBandobastTypeMaster",
                        principalColumn: "BandobastTypeId");
                    table.ForeignKey(
                        name: " FK_tblBandobastDetailMaster_tblPoliceStationMaster1",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblChangeColor",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatrakId = table.Column<int>(type: "int", nullable: true),
                    PolicestationId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblChangeColor", x => x.EntryId);
                    table.ForeignKey(
                        name: " FK_tblChangeColor_tblIndexPatrakMaster",
                        column: x => x.PatrakId,
                        principalTable: "tblIndexPatrakMaster",
                        principalColumn: "PatrakId");
                    table.ForeignKey(
                        name: " FK_tblChangeColor_tblPoliceStationMaster",
                        column: x => x.PolicestationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblCriminalCountInformation",
                columns: table => new
                {
                    CriminalCountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthCrime = table.Column<int>(type: "int", nullable: true),
                    LastMonthCrime = table.Column<int>(type: "int", nullable: true),
                    CurrentYearCrime = table.Column<int>(type: "int", nullable: true),
                    LastYearCrime = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCriminalCountInformation", x => x.CriminalCountId);
                    table.ForeignKey(
                        name: " FK_tblCriminalCountInformation_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: " FK_tblCriminalCountInformation_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblCRPC41CAmendmentMater",
                columns: table => new
                {
                    CRPC41CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Crimes_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accused_name_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cognizable_offens = table.Column<bool>(type: "bit", nullable: false),
                    victims_fingerprint = table.Column<bool>(type: "bit", nullable: false),
                    victims_fingerprint_Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRPC_41C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Release_the_bail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depart_in_court = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_of_accused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    JaherTarikh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCRPC41CAmendmentMater", x => x.CRPC41CId);
                    table.ForeignKey(
                        name: " FK_tblCRPC41CAmendmentMater_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblCRPC41Master",
                columns: table => new
                {
                    CRPCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: false),
                    CRPCNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccusedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccusedDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCRPC41Master", x => x.CRPCId);
                    table.ForeignKey(
                        name: " FK_tblCRPC41Master_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblCurrentYearAgeWiseMissingChildDetails",
                columns: table => new
                {
                    CurrentYearAgeWiseMissingChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualAge = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCurrentYearAgeWiseMissingChildDetails", x => x.CurrentYearAgeWiseMissingChildId);
                    table.ForeignKey(
                        name: " FK_tblCurrentYearAgeWiseMissingChildDetails_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: " FK_tblCurrentYearAgeWiseMissingChildDetails_tblGenderMaster",
                        column: x => x.GenderId,
                        principalTable: "tblGenderMaster",
                        principalColumn: "GenderId");
                    table.ForeignKey(
                        name: " FK_tblCurrentYearAgeWiseMissingChildDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblDistributeVehical",
                columns: table => new
                {
                    Distribute_vehicalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    OffRoad = table.Column<int>(type: "int", nullable: true),
                    Form_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDistributeVehical", x => x.Distribute_vehicalsId);
                    table.ForeignKey(
                        name: " FK_tblDistributeVehical_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: " FK_tblDistributeVehical_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblE_GujakopMaster",
                columns: table => new
                {
                    E_GujakopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Part1to5number = table.Column<int>(type: "int", nullable: true),
                    Part1to5E_Gujakop = table.Column<int>(type: "int", nullable: true),
                    part6number = table.Column<int>(type: "int", nullable: true),
                    part6E_Gujakop = table.Column<int>(type: "int", nullable: true),
                    ProhiNumber = table.Column<int>(type: "int", nullable: true),
                    ProhiE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    a_amNumber = table.Column<int>(type: "int", nullable: true),
                    a_amE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    acciendentNumber = table.Column<int>(type: "int", nullable: true),
                    acciendentE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    janvajogNumber = table.Column<int>(type: "int", nullable: true),
                    janvajogE_Gujakop = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblE_GujakopMaster", x => x.E_GujakopId);
                    table.ForeignKey(
                        name: " FK_tblE_GujakopMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblE_GujkopDetails",
                columns: table => new
                {
                    E_GujkopDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationKhate_Nondhayel_FIR = table.Column<int>(type: "int", nullable: true),
                    E_Gujkop_FIR_Entry = table.Column<int>(type: "int", nullable: true),
                    PoliceStationKhate_Nondhayel_Panchnamu = table.Column<int>(type: "int", nullable: true),
                    Panchnama_EGujop_Entry = table.Column<int>(type: "int", nullable: true),
                    AtakKarel_Isam = table.Column<int>(type: "int", nullable: true),
                    AtakKarel_Isam_EGujkop_Entry = table.Column<int>(type: "int", nullable: true),
                    AtakKarel_Isam_Egujkop_PhotoUpload = table.Column<int>(type: "int", nullable: true),
                    Post_Khate_Mudamal_Pavti_Fadi = table.Column<int>(type: "int", nullable: true),
                    Mudamal_Pavti_EGujkop_Entry = table.Column<int>(type: "int", nullable: true),
                    Chargesheet_ManjurKarel = table.Column<int>(type: "int", nullable: true),
                    Chargsheet_EGujkop_Entry = table.Column<int>(type: "int", nullable: true),
                    ServiceSheet_EGujkop_Entry = table.Column<int>(type: "int", nullable: true),
                    ServiceSheet_BuckleNo_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostKhate_Hajar_EmployeeName = table.Column<int>(type: "int", nullable: true),
                    Healthcard_BuckleNo_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_healthcard_Entry = table.Column<int>(type: "int", nullable: true),
                    Missing_Janvajog = table.Column<int>(type: "int", nullable: true),
                    Missing_Janvajog_EGujkop_Entry = table.Column<int>(type: "int", nullable: true),
                    Missing_Janvajog_PhotoUpload = table.Column<int>(type: "int", nullable: true),
                    MissingChild_FIRNumber = table.Column<int>(type: "int", nullable: true),
                    MissingChild_PhotoUpload = table.Column<int>(type: "int", nullable: true),
                    PocketCop_MobileDevice_Number = table.Column<int>(type: "int", nullable: true),
                    NumberOf_PocketCop_Device_login = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    Data_entry = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblE_GujkopDetails", x => x.E_GujkopDetailsId);
                    table.ForeignKey(
                        name: " FK_tblE_GujkopDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblForm3A",
                columns: table => new
                {
                    AkasmatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Complainant_accused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complainant_accusedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryofPast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblForm3A", x => x.AkasmatId);
                    table.ForeignKey(
                        name: " FK_tblForm3A_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblHistoryMissingAgeWiseChild",
                columns: table => new
                {
                    HistoryMissingAgeWiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Missingboy = table.Column<int>(type: "int", nullable: true),
                    Missinggirl = table.Column<int>(type: "int", nullable: true),
                    MissingChildDetails = table.Column<int>(type: "int", nullable: true),
                    Returnboy = table.Column<int>(type: "int", nullable: true),
                    Returngirl = table.Column<int>(type: "int", nullable: true),
                    ReturnChildDetails = table.Column<int>(type: "int", nullable: true),
                    Missing1to5Girl = table.Column<int>(type: "int", nullable: true),
                    Missing1to5boy = table.Column<int>(type: "int", nullable: true),
                    Missing6to12Girl = table.Column<int>(type: "int", nullable: true),
                    Missing6to12boy = table.Column<int>(type: "int", nullable: true),
                    Missing13to18Girl = table.Column<int>(type: "int", nullable: true),
                    Missing13to18boy = table.Column<int>(type: "int", nullable: true),
                    return1to5Girl = table.Column<int>(type: "int", nullable: true),
                    return1to5boy = table.Column<int>(type: "int", nullable: true),
                    return6to12Girl = table.Column<int>(type: "int", nullable: true),
                    return6to12boy = table.Column<int>(type: "int", nullable: true),
                    return13to18Girl = table.Column<int>(type: "int", nullable: true),
                    return13to18boy = table.Column<int>(type: "int", nullable: true),
                    totalmissing = table.Column<int>(type: "int", nullable: true),
                    totalreturn = table.Column<int>(type: "int", nullable: true),
                    per = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHistoryMissingAgeWiseChild", x => x.HistoryMissingAgeWiseId);
                    table.ForeignKey(
                        name: " FK_tblHistoryMissingAgeWiseChild_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblhistroryOfCurrentMissing",
                columns: table => new
                {
                    histroryOfCurrentMissingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Missingboy = table.Column<int>(type: "int", nullable: true),
                    Missinggirl = table.Column<int>(type: "int", nullable: true),
                    Returnboy = table.Column<int>(type: "int", nullable: true),
                    Returngirl = table.Column<int>(type: "int", nullable: true),
                    Missingwoman = table.Column<int>(type: "int", nullable: true),
                    Missingman = table.Column<int>(type: "int", nullable: true),
                    ReturnWoman = table.Column<int>(type: "int", nullable: true),
                    Returnman = table.Column<int>(type: "int", nullable: true),
                    TotalmissingChild = table.Column<int>(type: "int", nullable: true),
                    TotalRetrunChild = table.Column<int>(type: "int", nullable: true),
                    TotalMissingPerson = table.Column<int>(type: "int", nullable: true),
                    TotalReturnPerson = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblhistroryOfCurrentMissing", x => x.histroryOfCurrentMissingId);
                    table.ForeignKey(
                        name: " FK_tblhistroryOfCurrentMissing_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblMahekamMaster",
                columns: table => new
                {
                    MahekamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    ManjurMahekam = table.Column<int>(type: "int", nullable: true),
                    HajarMahekam = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMahekamMaster", x => x.MahekamId);
                    table.ForeignKey(
                        name: " FK_tblMahekamMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblMCRDetails",
                columns: table => new
                {
                    McrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    MCRCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfISM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestAddressOfISM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMCRDetails", x => x.McrId);
                    table.ForeignKey(
                        name: " FK_tblMCRDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblMissingChildDetails",
                columns: table => new
                {
                    MissingChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    MissingPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissingReson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    MissingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MissingApplicationNo_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMissingChildDetails", x => x.MissingChildId);
                    table.ForeignKey(
                        name: " FK_tblMissingChildDetails_tblGenderMaster",
                        column: x => x.GenderId,
                        principalTable: "tblGenderMaster",
                        principalColumn: "GenderId");
                    table.ForeignKey(
                        name: " FK_tblMissingChildDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblNightRound_HEKO_POMaster",
                columns: table => new
                {
                    NightRound_HEKO_POID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TotalOfMotarcycle = table.Column<int>(type: "int", nullable: true),
                    MaofNumber = table.Column<int>(type: "int", nullable: true),
                    NightRound_Heko_PONumber = table.Column<int>(type: "int", nullable: true),
                    DefectNumber = table.Column<int>(type: "int", nullable: true),
                    NotavailabelNumber = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNightRound_HEKO_POMaster", x => x.NightRound_HEKO_POID);
                    table.ForeignKey(
                        name: " FK_tblNightRound_HEKO_POMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblNightRountPersonCountMaster",
                columns: table => new
                {
                    NightRoundPersonCountId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PresentMahekam = table.Column<int>(type: "int", nullable: true),
                    NightRountPersonCount = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNightRountPersonCountMaster", x => x.NightRoundPersonCountId);
                    table.ForeignKey(
                        name: " FK_tblNightRountPersonCountMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblOfiiceWisePendingApplication",
                columns: table => new
                {
                    OfficeWisePendingApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    TenDaysAbove = table.Column<int>(type: "int", nullable: true),
                    OneMonthAbove = table.Column<int>(type: "int", nullable: true),
                    TwoMonthAbove = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthAbove = table.Column<int>(type: "int", nullable: true),
                    SixMonthAbove = table.Column<int>(type: "int", nullable: true),
                    OneYearAndAbove = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOfiiceWisePendingApplication", x => x.OfficeWisePendingApplicationId);
                    table.ForeignKey(
                        name: " FK_tblOfiiceWisePendingApplication_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: " FK_tblOfiiceWisePendingApplication_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblPendingArjiDetails",
                columns: table => new
                {
                    PendingArjiDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PendingArjiCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Under_10Days = table.Column<int>(type: "int", nullable: true),
                    Above_10Days = table.Column<int>(type: "int", nullable: true),
                    Above_OneMonth = table.Column<int>(type: "int", nullable: true),
                    Above_TwoMonth = table.Column<int>(type: "int", nullable: true),
                    Above_ThreeMonth = table.Column<int>(type: "int", nullable: true),
                    Above_SixMonth = table.Column<int>(type: "int", nullable: true),
                    Above_OneYear = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPendingArjiDetails", x => x.PendingArjiDetailId);
                    table.ForeignKey(
                        name: " FK_tblPendingArjiDetails_tblPendingArjiCategory",
                        column: x => x.PendingArjiCategoryId,
                        principalTable: "tblPendingArjiCategory",
                        principalColumn: "PendingArjiCategoryId");
                    table.ForeignKey(
                        name: " FK_tblPendingArjiDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblpendingjanvajogMaster",
                columns: table => new
                {
                    PendingJanvaJog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    OneMonthUnder = table.Column<int>(type: "int", nullable: true),
                    OneMonthAbove = table.Column<int>(type: "int", nullable: true),
                    TwoMonthAbove = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthAbove = table.Column<int>(type: "int", nullable: true),
                    SixMonthAbove = table.Column<int>(type: "int", nullable: true),
                    OneYearAndAbove = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblpendingjanvajogMaster", x => x.PendingJanvaJog);
                    table.ForeignKey(
                        name: " FK_tblpendingjanvajogMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblPoliceStationWisePendingApplication",
                columns: table => new
                {
                    PoliceStationWisePendingApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    KacheriId = table.Column<int>(type: "int", nullable: true),
                    TenDaysBelow = table.Column<int>(type: "int", nullable: true),
                    TenDaysAbove = table.Column<int>(type: "int", nullable: true),
                    OneMonthUnder = table.Column<int>(type: "int", nullable: true),
                    OneMonthAbove = table.Column<int>(type: "int", nullable: true),
                    TwoMonthAbove = table.Column<int>(type: "int", nullable: true),
                    ThreeMonthAbove = table.Column<int>(type: "int", nullable: true),
                    SixMonthAbove = table.Column<int>(type: "int", nullable: true),
                    OneYearAndAbove = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: " FK_tblPoliceStationWisePendingApplication_tblkacheriMaster",
                        column: x => x.KacheriId,
                        principalTable: "tblkacheriMaster",
                        principalColumn: "KacheriId");
                    table.ForeignKey(
                        name: " FK_tblPoliceStationWisePendingApplication_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblPoliceStationWiseVehical",
                columns: table => new
                {
                    PoliceStationwiseVehicalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Jeeps_Total = table.Column<int>(type: "int", nullable: true),
                    Jeeps_OFFroad = table.Column<int>(type: "int", nullable: true),
                    Jeeps_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Mobile_total = table.Column<int>(type: "int", nullable: true),
                    Mobile_offroad = table.Column<int>(type: "int", nullable: true),
                    Mobile_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cycling_total = table.Column<int>(type: "int", nullable: true),
                    Cycling_offroad = table.Column<int>(type: "int", nullable: true),
                    Cycling_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: " FK_tblPoliceStationWiseVehical_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblProhibitionCrimeMaster",
                columns: table => new
                {
                    ProhibitioncrimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    pidhela = table.Column<int>(type: "int", nullable: true),
                    kabjama = table.Column<int>(type: "int", nullable: true),
                    CrimeNumber = table.Column<int>(type: "int", nullable: true),
                    arrestsNumber = table.Column<int>(type: "int", nullable: true),
                    issue = table.Column<int>(type: "int", nullable: true),
                    mudamal_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalNumberCase = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProhibitionCrimeMaster", x => x.ProhibitioncrimeId);
                    table.ForeignKey(
                        name: " FK_tblProhibitionCrimeMaster_tblPoliceStationMaster1",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblProhibitionCrimeMaster_Copy",
                columns: table => new
                {
                    ProhibitioncrimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    pidhela = table.Column<int>(type: "int", nullable: true),
                    kabjama = table.Column<int>(type: "int", nullable: true),
                    CrimeNumber = table.Column<int>(type: "int", nullable: true),
                    arrestsNumber = table.Column<int>(type: "int", nullable: true),
                    issue = table.Column<int>(type: "int", nullable: true),
                    mudamal_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalNumberCase = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProhibitionCrimeMaster_Copy", x => x.ProhibitioncrimeId);
                    table.ForeignKey(
                        name: " FK_tblProhibitionCrimeMaster_Copy_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblSamelPatrakMaster",
                columns: table => new
                {
                    SamelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatrakId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SamelCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSamelPatrakMaster", x => x.SamelId);
                    table.ForeignKey(
                        name: " FK_tblSamelPatrakMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblSamelPatrakMaster_tblSamelCategoryMaster",
                        column: x => x.PatrakId,
                        principalTable: "tblIndexPatrakMaster",
                        principalColumn: "PatrakId");
                });

            migrationBuilder.CreateTable(
                name: "tblStationery",
                columns: table => new
                {
                    stationaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Computer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Giswan_Connectivity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax_machine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Xerox_machine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Other_Stationary_Stocks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStationery", x => x.stationaryId);
                    table.ForeignKey(
                        name: " FK_tblStationery_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblTraffic_TRB_HomeGuard_Master",
                columns: table => new
                {
                    Traffic_TRB_HomeGuardId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TRBManjurNumber = table.Column<int>(type: "int", nullable: true),
                    TRBAttendanceMorning = table.Column<int>(type: "int", nullable: true),
                    TRBAttendanceEvening = table.Column<int>(type: "int", nullable: true),
                    HomeGuardManjurNumber = table.Column<int>(type: "int", nullable: true),
                    HomeGuardAttendanceMorning = table.Column<int>(type: "int", nullable: true),
                    HomeGuardAttendanceEvening = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTraffic_TRB_HomeGuard_Master", x => x.Traffic_TRB_HomeGuardId);
                    table.ForeignKey(
                        name: " FK_tblTraffic_TRB_HomeGuard_Master_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblTraffic_TRG_AHG_Master",
                columns: table => new
                {
                    Traffic_TRB_AHGId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Name_GH_of_TRB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time_of_arrival_TRB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_GH_of_AHG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time_of_arrival_AHG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTraffic_TRG_AHG_Master", x => x.Traffic_TRB_AHGId);
                    table.ForeignKey(
                        name: " FK_tblTraffic_TRG_AHG_Master_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineMaster",
                columns: table => new
                {
                    TrafficPlaceFineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPlaceFineMaster", x => x.TrafficPlaceFineId);
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficSignalBlinkerigh",
                columns: table => new
                {
                    TrafficSignalBlinkerighId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    locations_blinkering_area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blinking_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficSignalBlinkerigh", x => x.TrafficSignalBlinkerighId);
                    table.ForeignKey(
                        name: " FK_tblTrafficSignalBlinkerigh_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficSignalMaster",
                columns: table => new
                {
                    trafficSignalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    signals_area = table.Column<int>(type: "int", nullable: true),
                    signals_progress = table.Column<int>(type: "int", nullable: true),
                    signals_closed_condition = table.Column<int>(type: "int", nullable: true),
                    reason_closed_condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    procedures_closed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficSignalMaster", x => x.trafficSignalId);
                    table.ForeignKey(
                        name: " FK_tblTrafficSignalMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficSummaryDetails",
                columns: table => new
                {
                    TrafficSummaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficSummaryCategoryId = table.Column<int>(type: "int", nullable: true),
                    TodaysCaseNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCaseNumber = table.Column<int>(type: "int", nullable: true),
                    T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    CM_PM = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysNumber = table.Column<int>(type: "int", nullable: true),
                    CY_PY = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficSummaryDetails", x => x.TrafficSummaryId);
                    table.ForeignKey(
                        name: " FK_tblTrafficSummaryDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficTobacoMaster",
                columns: table => new
                {
                    TrafficTobacoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimenumber = table.Column<int>(type: "int", nullable: true),
                    TodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    YesterdaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_T_Y_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousMonthTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_C_P_Amount = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    CurrentYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeNumber = table.Column<int>(type: "int", nullable: true),
                    PreviousYearTodaysCrimeAmount = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Number = table.Column<int>(type: "int", nullable: true),
                    Plus_Minus_CY_PY_Amount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficTobacoMaster", x => x.TrafficTobacoId);
                    table.ForeignKey(
                        name: " FK_tblTrafficTobacoMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblVisitation_CrimeBranch",
                columns: table => new
                {
                    VisitationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    GUBATATA_CrimePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimeVisitPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "date", nullable: true),
                    Visiter_OfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVisitation_CrimeBranch", x => x.VisitationId);
                    table.ForeignKey(
                        name: " FK_tblVisitation_CrimeBranch_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblCityMaster",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCityMaster", x => x.CityId);
                    table.ForeignKey(
                        name: " FK_tblCityMaster_tblStateMaster",
                        column: x => x.StateId,
                        principalTable: "tblStateMaster",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "tblCctvMaster",
                columns: table => new
                {
                    CctvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Distict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cluster = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    PTZ_installed = table.Column<int>(type: "int", nullable: true),
                    BLT_installed = table.Column<int>(type: "int", nullable: true),
                    DM_installed = table.Column<int>(type: "int", nullable: true),
                    Total_installed = table.Column<int>(type: "int", nullable: true),
                    PTZ_funcational = table.Column<int>(type: "int", nullable: true),
                    BLT_funcational = table.Column<int>(type: "int", nullable: true),
                    DM_funcational = table.Column<int>(type: "int", nullable: true),
                    Total_funcation = table.Column<int>(type: "int", nullable: true),
                    PTZ_not_funcational = table.Column<int>(type: "int", nullable: true),
                    BLT_not_funcational = table.Column<int>(type: "int", nullable: true),
                    DM_not_funcational = table.Column<int>(type: "int", nullable: true),
                    Total_not_funcation = table.Column<int>(type: "int", nullable: true),
                    Complaint1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate1 = table.Column<DateTime>(type: "datetime", nullable: true),
                    Complaint2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate2 = table.Column<DateTime>(type: "datetime", nullable: true),
                    Complaint3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDate3 = table.Column<DateTime>(type: "datetime", nullable: true),
                    EquipmentsId = table.Column<int>(type: "int", nullable: true),
                    NatureofComplant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visited_Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    ResolveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCctvMaster", x => x.CctvId);
                    table.ForeignKey(
                        name: " FK_tblCctvMaster_tblEquipments",
                        column: x => x.EquipmentsId,
                        principalTable: "tblEquipments",
                        principalColumn: "EquipmentsId");
                    table.ForeignKey(
                        name: " FK_tblCctvMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblCctvMaster_tblStatusMaster",
                        column: x => x.StatusId,
                        principalTable: "tblStatusMaster",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineDetails",
                columns: table => new
                {
                    TrafficPlaceFineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    RS200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    PROSI = table.Column<int>(type: "int", nullable: true),
                    RTO = table.Column<int>(type: "int", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPlaceFineDetails", x => x.TrafficPlaceFineId);
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineDetails_tblTraffiCategoryMaster",
                        column: x => x.TrafficCategoryId,
                        principalTable: "tblTraffiCategoryMaster",
                        principalColumn: "TrafficCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficCrainWorkMaster",
                columns: table => new
                {
                    TraffiCrainWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    TrafficCrainId = table.Column<int>(type: "int", nullable: true),
                    TwoWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    TwoWheelerToingFineAmount = table.Column<int>(type: "int", nullable: true),
                    ThreeWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    ThreeWheelerToingAmount = table.Column<int>(type: "int", nullable: true),
                    FourWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    FourWheelerToingAmount = table.Column<int>(type: "int", nullable: true),
                    HeavyWheelerToingNumber = table.Column<int>(type: "int", nullable: true),
                    HeavyWheelerToingAmount = table.Column<int>(type: "int", nullable: true),
                    TotalToingVehicle = table.Column<int>(type: "int", nullable: true),
                    TotalToingAmount = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    PlaceFineNumber = table.Column<int>(type: "int", nullable: true),
                    PlaceFineAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficCrainWorkMaster", x => x.TraffiCrainWorkId);
                    table.ForeignKey(
                        name: " FK_tblTrafficCrainWorkMaster_tblTrafficCrainMaster",
                        column: x => x.TrafficCrainId,
                        principalTable: "tblTrafficCrainMaster",
                        principalColumn: "TrafficCrainId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficDriveMaster",
                columns: table => new
                {
                    TrafficDriveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficDriveCatgeoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Detain = table.Column<int>(type: "int", nullable: true),
                    CaseNumber = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficDriveMaster", x => x.TrafficDriveId);
                    table.ForeignKey(
                        name: " FK_tblTrafficDriveMaster_tblTrafficDriveCategoryMaster1",
                        column: x => x.TrafficDriveCatgeoryId,
                        principalTable: "tblTrafficDriveCategoryMaster",
                        principalColumn: "TrafficCategoryDriveId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficInterceptSubCategoryMaster",
                columns: table => new
                {
                    TrafficInterceptSubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficInterceptCategoryId = table.Column<int>(type: "int", nullable: true),
                    TrafficeInterceptSubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficInterceptSubCategoryMaster", x => x.TrafficInterceptSubCategoryId);
                    table.ForeignKey(
                        name: " FK_tblTrafficInterceptSubCategoryMaster_tblTrafficInterceptCategoryMaster",
                        column: x => x.TrafficInterceptCategoryId,
                        principalTable: "tblTrafficInterceptCategoryMaster",
                        principalColumn: "TrafficInterceptCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblWardWiseJetDetails",
                columns: table => new
                {
                    WardCollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    TodaySolidWateCollectionCase = table.Column<int>(type: "int", nullable: true),
                    TodayEstateDepartmentCase = table.Column<int>(type: "int", nullable: true),
                    TodayPoliceStationDepartmentCase = table.Column<int>(type: "int", nullable: true),
                    TotalCases = table.Column<int>(type: "int", nullable: true),
                    TodaySolidWateCollectionAmount = table.Column<int>(type: "int", nullable: true),
                    TodayEstateDepartmentAmount = table.Column<int>(type: "int", nullable: true),
                    TodayPoliceStationDepartmentAmount = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWardWiseJetDetails", x => x.WardCollectionId);
                    table.ForeignKey(
                        name: " FK_tblWardWiseJetDetails_tblWardMaster",
                        column: x => x.WardId,
                        principalTable: "tblWardMaster",
                        principalColumn: "WardId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineDetailsJET",
                columns: table => new
                {
                    TrafficPlaceJetFineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    RS200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    PROSI = table.Column<int>(type: "int", nullable: true),
                    RTO = table.Column<int>(type: "int", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPlaceFineDetailsJET", x => x.TrafficPlaceJetFineId);
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineDetailsJET_tblTraffiCategoryMaster",
                        column: x => x.TrafficCategoryId,
                        principalTable: "tblTraffiCategoryMaster",
                        principalColumn: "TrafficCategoryId");
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineDetailsJET_tblWardMaster",
                        column: x => x.WardId,
                        principalTable: "tblWardMaster",
                        principalColumn: "WardId");
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineDetailsJET_tblWheelerType",
                        column: x => x.WheelerTypeId,
                        principalTable: "tblWheelerType",
                        principalColumn: "WheelerTypeId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceFineDetailsJET_NULL",
                columns: table => new
                {
                    TrafficPlaceJETFineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    Rs200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    PROSI = table.Column<int>(type: "int", nullable: true),
                    RTO = table.Column<int>(type: "int", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPlaceFineDetailsJET_NULL", x => x.TrafficPlaceJETFineId);
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineDetailsJET_NULL_tblTraffiCategoryMaster",
                        column: x => x.TrafficCategoryId,
                        principalTable: "tblTraffiCategoryMaster",
                        principalColumn: "TrafficCategoryId");
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineDetailsJET_NULL_tblWardMaster",
                        column: x => x.WardId,
                        principalTable: "tblWardMaster",
                        principalColumn: "WardId");
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceFineDetailsJET_NULL_tblWheelerType",
                        column: x => x.WheelerTypeId,
                        principalTable: "tblWheelerType",
                        principalColumn: "WheelerTypeId");
                });

            migrationBuilder.CreateTable(
                name: "tblTrafficPlaceITDetails",
                columns: table => new
                {
                    TrafficPlaceITFineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficCategoryId = table.Column<int>(type: "int", nullable: true),
                    TrafficInterceptSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    WheelerTypeId = table.Column<int>(type: "int", nullable: true),
                    INTER_TF_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RS50 = table.Column<int>(type: "int", nullable: true),
                    RS100 = table.Column<int>(type: "int", nullable: true),
                    RS200 = table.Column<int>(type: "int", nullable: true),
                    RS300 = table.Column<int>(type: "int", nullable: true),
                    RS500 = table.Column<int>(type: "int", nullable: true),
                    RS1000 = table.Column<int>(type: "int", nullable: true),
                    EPCO_188_GP_131 = table.Column<int>(type: "int", nullable: true),
                    EPCO_279 = table.Column<int>(type: "int", nullable: true),
                    MVACT_207 = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    RS1500 = table.Column<int>(type: "int", nullable: true),
                    RS2000 = table.Column<int>(type: "int", nullable: true),
                    RS3000 = table.Column<int>(type: "int", nullable: true),
                    RS4000 = table.Column<int>(type: "int", nullable: true),
                    RS5000 = table.Column<int>(type: "int", nullable: true),
                    RS400 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrafficPlaceITDetails", x => x.TrafficPlaceITFineId);
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceITDetails_tblTraffiCategoryMaster",
                        column: x => x.TrafficCategoryId,
                        principalTable: "tblTraffiCategoryMaster",
                        principalColumn: "TrafficCategoryId");
                    table.ForeignKey(
                        name: " FK_tblTrafficPlaceITDetails_tblWheelerType",
                        column: x => x.WheelerTypeId,
                        principalTable: "tblWheelerType",
                        principalColumn: "WheelerTypeId");
                });

            migrationBuilder.CreateTable(
                name: "tblDivisionMaster",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDivisionMaster", x => x.DivisionId);
                    table.ForeignKey(
                        name: " FK_tblDivisionMaster_tblZoneMaster",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblAtakayatidetails",
                columns: table => new
                {
                    AtakayatiPagalaSummaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    Today = table.Column<int>(type: "int", nullable: true),
                    Last = table.Column<int>(type: "int", nullable: true),
                    T_Y = table.Column<int>(type: "int", nullable: true),
                    CurrentYear = table.Column<int>(type: "int", nullable: true),
                    LastYear = table.Column<int>(type: "int", nullable: true),
                    CY_LY = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAtakayatidetails", x => x.AtakayatiPagalaSummaryId);
                    table.ForeignKey(
                        name: " FK_tblAtakayatidetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblAtakayatidetails_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblAtakayatiPaglaSummary",
                columns: table => new
                {
                    AtakayatiPagalaSummaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    IPC_GPCId = table.Column<int>(type: "int", nullable: true),
                    Todays = table.Column<int>(type: "int", nullable: true),
                    Last = table.Column<int>(type: "int", nullable: true),
                    CurrentMonth = table.Column<int>(type: "int", nullable: true),
                    LastMonth = table.Column<int>(type: "int", nullable: true),
                    CurrentYear = table.Column<int>(type: "int", nullable: true),
                    LastYear = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAtakayatiPaglaSummary", x => x.AtakayatiPagalaSummaryId);
                    table.ForeignKey(
                        name: " FK_tblAtakayatiPaglaSummary_tblIPC_GPCMaster",
                        column: x => x.IPC_GPCId,
                        principalTable: "tblIPC_GPCMaster",
                        principalColumn: "IPC_GPCId");
                    table.ForeignKey(
                        name: " FK_tblAtakayatiPaglaSummary_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblAtakayatiPaglaSummary_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblCurrentYearMissingChildDetails",
                columns: table => new
                {
                    CurrentYearMissingChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCurrentYearMissingChildDetails", x => x.CurrentYearMissingChildId);
                    table.ForeignKey(
                        name: " FK_tblCurrentYearMissingChildDetails_tblGenderMaster",
                        column: x => x.GenderId,
                        principalTable: "tblGenderMaster",
                        principalColumn: "GenderId");
                    table.ForeignKey(
                        name: " FK_tblCurrentYearMissingChildDetails_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblCurrentYearMissingChildDetails_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tbldetainMaster",
                columns: table => new
                {
                    DetainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    psnccount = table.Column<int>(type: "int", nullable: true),
                    tsnccount = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbldetainMaster", x => x.DetainId);
                    table.ForeignKey(
                        name: " FK_tbldetainMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tbldetainMaster_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblForm5Master",
                columns: table => new
                {
                    AtakayatiPagalaSummaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    Today = table.Column<int>(type: "int", nullable: true),
                    Last = table.Column<int>(type: "int", nullable: true),
                    CurrentYear = table.Column<int>(type: "int", nullable: true),
                    LastYear = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblForm5Master", x => x.AtakayatiPagalaSummaryId);
                    table.ForeignKey(
                        name: " FK_tblForm5Master_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblForm5Master_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblLaborInformationMaster",
                columns: table => new
                {
                    LaborInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    CheckedPlace = table.Column<int>(type: "int", nullable: true),
                    CheckedLabor = table.Column<int>(type: "int", nullable: true),
                    TotalLaborersVideography = table.Column<int>(type: "int", nullable: true),
                    Workers_ARoll_BRollNumber = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLaborInformationMaster", x => x.LaborInformationId);
                    table.ForeignKey(
                        name: " FK_tblLaborInformationMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblLaborInformationMaster_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblPart1_5_Crimes",
                columns: table => new
                {
                    CrimesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    Complainer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gubatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gujatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gudatata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrimePurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonNameWhoFiledCrime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LateComplaintReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HdiitsEntry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Savendansil = table.Column<bool>(type: "bit", nullable: false),
                    BinSavendansil = table.Column<bool>(type: "bit", nullable: false),
                    Complainer_AccusedCriminalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IPCACT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pidhela_Kabjana_Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: " FK_tblPart1_5_Crimes_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblPart1_5_Crimes_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblPendingWarrant",
                columns: table => new
                {
                    PendingId = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    LastPending = table.Column<int>(type: "int", nullable: true),
                    NewPending = table.Column<int>(type: "int", nullable: true),
                    Budgeted = table.Column<int>(type: "int", nullable: true),
                    WithoutBudgeted = table.Column<int>(type: "int", nullable: true),
                    Transfer = table.Column<int>(type: "int", nullable: true),
                    Pending = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: " FK_tblPendingWarrant_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblPendingWarrant_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblPoliceStation_VehicleChecking",
                columns: table => new
                {
                    VehicleCheckingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    Checktwowheeler = table.Column<int>(type: "int", nullable: true),
                    dandtwowheeler = table.Column<int>(type: "int", nullable: true),
                    Checkthreewheeler = table.Column<int>(type: "int", nullable: true),
                    dandthreewheeler = table.Column<int>(type: "int", nullable: true),
                    Checkfourwheeler = table.Column<int>(type: "int", nullable: true),
                    dandfourwheeler = table.Column<int>(type: "int", nullable: true),
                    detain = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateduserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: " FK_tblPoliceStation_VehicleChecking_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblPoliceStation_VehicleChecking_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblSectorMaster",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSectorMaster", x => x.SectorId);
                    table.ForeignKey(
                        name: " FK_tblSectorMaster_tblCityMaster",
                        column: x => x.CityId,
                        principalTable: "tblCityMaster",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeMaster",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BuckleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrtiniyukatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    todate = table.Column<DateTime>(type: "datetime", nullable: true),
                    fromdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrtiniyukatPlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsTraffic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeMaster", x => x.EmployeeId);
                    table.ForeignKey(
                        name: " FK_tblEmployeeMaster_tblDesignationName",
                        column: x => x.DesignationId,
                        principalTable: "tblDesignationName",
                        principalColumn: "DesignationId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMaster_tblDivisionMaster",
                        column: x => x.DivisionId,
                        principalTable: "tblDivisionMaster",
                        principalColumn: "DivisionId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMaster_tblRoleMaster",
                        column: x => x.RoleId,
                        principalTable: "tblRoleMaster",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMaster_tblSectorMaster",
                        column: x => x.SectorId,
                        principalTable: "tblSectorMaster",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMaster_tblZoneMaster",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblLoginMaster_Mobile",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    ForTraffic_City = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsMobileAccess = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    FierBaseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLoginMaster_Mobile", x => x.LoginId);
                    table.ForeignKey(
                        name: " FK_tblLoginMaster_Mobile_tblDesignationName",
                        column: x => x.DesignationId,
                        principalTable: "tblDesignationName",
                        principalColumn: "DesignationId");
                    table.ForeignKey(
                        name: " FK_tblLoginMaster_Mobile_tblDivisionMaster",
                        column: x => x.DivisionId,
                        principalTable: "tblDivisionMaster",
                        principalColumn: "DivisionId");
                    table.ForeignKey(
                        name: " FK_tblLoginMaster_Mobile_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblLoginMaster_Mobile_tblRoleMaster",
                        column: x => x.RoleId,
                        principalTable: "tblRoleMaster",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: " FK_tblLoginMaster_Mobile_tblSectorMaster",
                        column: x => x.SectorId,
                        principalTable: "tblSectorMaster",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: " FK_tblLoginMaster_Mobile_tblZoneMaster",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblNightRound",
                columns: table => new
                {
                    NightRoundId = table.Column<int>(type: "int", nullable: false),
                    NightRoundOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    GoingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NightRoundPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNightRound", x => x.NightRoundId);
                    table.ForeignKey(
                        name: " FK_tblNightRound_tblDivisionMaster",
                        column: x => x.DivisionId,
                        principalTable: "tblDivisionMaster",
                        principalColumn: "DivisionId");
                    table.ForeignKey(
                        name: " FK_tblNightRound_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblNightRound_tblSectorMaster",
                        column: x => x.SectorId,
                        principalTable: "tblSectorMaster",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: " FK_tblNightRound_tblZoneMaster",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblPart_1_6_Counter",
                columns: table => new
                {
                    Part1_5_6_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CrimesCount = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: " FK_tblPart_1_6_Counter_tblCategoryMaster",
                        column: x => x.CategoryId,
                        principalTable: "tblCategoryMaster",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: " FK_tblPart_1_6_Counter_tblDivisionMaster",
                        column: x => x.DivisionId,
                        principalTable: "tblDivisionMaster",
                        principalColumn: "DivisionId");
                    table.ForeignKey(
                        name: " FK_tblPart_1_6_Counter_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblPart_1_6_Counter_tblSectorMaster",
                        column: x => x.SectorId,
                        principalTable: "tblSectorMaster",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: " FK_tblPart_1_6_Counter_tblSubCategoryMaster",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSubCategoryMaster",
                        principalColumn: "SubCategoryId");
                    table.ForeignKey(
                        name: " FK_tblPart_1_6_Counter_tblZoneMaster",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeMasterBackup",
                columns: table => new
                {
                    EmployeeBackupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BuckleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrtiniyukatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    todate = table.Column<DateTime>(type: "datetime", nullable: true),
                    fromdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrtiniyukatPlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsTraffic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeMasterBackup", x => x.EmployeeBackupId);
                    table.ForeignKey(
                        name: " FK_tblEmployeeMasterBackup_tblDesignationName",
                        column: x => x.DesignationId,
                        principalTable: "tblDesignationName",
                        principalColumn: "DesignationId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMasterBackup_tblDivisionMaster",
                        column: x => x.DivisionId,
                        principalTable: "tblDivisionMaster",
                        principalColumn: "DivisionId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMasterBackup_tblEmployeeMaster",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMasterBackup_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMasterBackup_tblSectorMaster",
                        column: x => x.SectorId,
                        principalTable: "tblSectorMaster",
                        principalColumn: "SectorId");
                    table.ForeignKey(
                        name: " FK_tblEmployeeMasterBackup_tblZoneMaster",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveApplicationMaster",
                columns: table => new
                {
                    LeaveApplicationID = table.Column<int>(type: "int", nullable: false),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    InchargeDesignationId = table.Column<int>(type: "int", nullable: true),
                    InchargePoliceStationId = table.Column<int>(type: "int", nullable: true),
                    InchargeEmployeeId = table.Column<int>(type: "int", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    InchargeSectorId = table.Column<int>(type: "int", nullable: true),
                    InchargeZoneId = table.Column<int>(type: "int", nullable: true),
                    InchargeDivisionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeaveApplicationMaster", x => x.LeaveApplicationID);
                    table.ForeignKey(
                        name: " FK_tblLeaveApplicationMaster_tblDesignationName",
                        column: x => x.DesignationId,
                        principalTable: "tblDesignationName",
                        principalColumn: "DesignationId");
                    table.ForeignKey(
                        name: " FK_tblLeaveApplicationMaster_tblDesignationName1",
                        column: x => x.InchargeDesignationId,
                        principalTable: "tblDesignationName",
                        principalColumn: "DesignationId");
                    table.ForeignKey(
                        name: " FK_tblLeaveApplicationMaster_tblLeaveApplicationMaster",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: " FK_tblLeaveApplicationMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                    table.ForeignKey(
                        name: " FK_tblLeaveApplicationMaster_tblPoliceStationMaster1",
                        column: x => x.InchargePoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateTable(
                name: "tblNightEmployeeMaster",
                columns: table => new
                {
                    NightEmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PoliceStationId = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    GoingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNightEmployeeMaster", x => x.NightEmployeeId);
                    table.ForeignKey(
                        name: " FK_tblNightEmployeeMaster_tblDesignationName",
                        column: x => x.DesignationId,
                        principalTable: "tblDesignationName",
                        principalColumn: "DesignationId");
                    table.ForeignKey(
                        name: " FK_tblNightEmployeeMaster_tblEmployeeMaster",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: " FK_tblNightEmployeeMaster_tblPoliceStationMaster",
                        column: x => x.PoliceStationId,
                        principalTable: "tblPoliceStationMaster",
                        principalColumn: "PoliceStationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CCTVInstalled_PoliceStationId",
                table: "tbl_CCTVInstalled",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProhibitionRaidCase_CategoryId",
                table: "tbl_ProhibitionRaidCase",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProhibitionRaidCase_PoliceStationId",
                table: "tbl_ProhibitionRaidCase",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_samans_details_CategoryId",
                table: "tbl_samans_details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_samans_details_PoliceStationId",
                table: "tbl_samans_details",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccusedInformation_PoliceStationId",
                table: "tblAccusedInformation",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbladhibitMaster_PoliceStationId",
                table: "tbladhibitMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAdminCheckMaster_PoliceStationId",
                table: "tblAdminCheckMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAdminWisePendingApplicationMaster_KacheriId",
                table: "tblAdminWisePendingApplicationMaster",
                column: "KacheriId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAdminWisePendingApplicationMaster_PoliceStationId",
                table: "tblAdminWisePendingApplicationMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtakayatidetails_PoliceStationId",
                table: "tblAtakayatidetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtakayatidetails_SubCategoryId",
                table: "tblAtakayatidetails",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtakayatiPagla_PoliceStationId",
                table: "tblAtakayatiPagla",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtakayatiPaglaSummary_IPC_GPCId",
                table: "tblAtakayatiPaglaSummary",
                column: "IPC_GPCId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtakayatiPaglaSummary_PoliceStationId",
                table: "tblAtakayatiPaglaSummary",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtakayatiPaglaSummary_SubCategoryId",
                table: "tblAtakayatiPaglaSummary",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtakKarel_Esam_PoliceStationId",
                table: "tblAtakKarel_Esam",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAtkayatiPagalaConsolidated_PoliceStationId",
                table: "tblAtkayatiPagalaConsolidated",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAutoRickshawDetails_PoliceStationId",
                table: "tblAutoRickshawDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBandobastDetailMaster_BandobastTypeId",
                table: "tblBandobastDetailMaster",
                column: "BandobastTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBandobastDetailMaster_PoliceStationId",
                table: "tblBandobastDetailMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCctvMaster_EquipmentsId",
                table: "tblCctvMaster",
                column: "EquipmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCctvMaster_PoliceStationId",
                table: "tblCctvMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCctvMaster_StatusId",
                table: "tblCctvMaster",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblChangeColor_PatrakId",
                table: "tblChangeColor",
                column: "PatrakId");

            migrationBuilder.CreateIndex(
                name: "IX_tblChangeColor_PolicestationId",
                table: "tblChangeColor",
                column: "PolicestationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCityMaster_StateId",
                table: "tblCityMaster",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCriminalCountInformation_CategoryId",
                table: "tblCriminalCountInformation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCriminalCountInformation_PoliceStationId",
                table: "tblCriminalCountInformation",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCriminalInformation_CategoryId",
                table: "tblCriminalInformation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCRPC41CAmendmentMater_PoliceStationId",
                table: "tblCRPC41CAmendmentMater",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCRPC41Master_PoliceStationId",
                table: "tblCRPC41Master",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrentYearAgeWiseMissingChildDetails_CategoryId",
                table: "tblCurrentYearAgeWiseMissingChildDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrentYearAgeWiseMissingChildDetails_GenderId",
                table: "tblCurrentYearAgeWiseMissingChildDetails",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrentYearAgeWiseMissingChildDetails_PoliceStationId",
                table: "tblCurrentYearAgeWiseMissingChildDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrentYearMissingChildDetails_GenderId",
                table: "tblCurrentYearMissingChildDetails",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrentYearMissingChildDetails_PoliceStationId",
                table: "tblCurrentYearMissingChildDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrentYearMissingChildDetails_SubCategoryId",
                table: "tblCurrentYearMissingChildDetails",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbldetainMaster_PoliceStationId",
                table: "tbldetainMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbldetainMaster_SubCategoryId",
                table: "tbldetainMaster",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDistributeVehical_CategoryId",
                table: "tblDistributeVehical",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDistributeVehical_PoliceStationId",
                table: "tblDistributeVehical",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDivisionMaster_ZoneId",
                table: "tblDivisionMaster",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblE_GujakopMaster_PoliceStationId",
                table: "tblE_GujakopMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblE_GujkopDetails_PoliceStationId",
                table: "tblE_GujkopDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_DesignationId",
                table: "tblEmployeeMaster",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_DivisionId",
                table: "tblEmployeeMaster",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_PoliceStationId",
                table: "tblEmployeeMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_RoleId",
                table: "tblEmployeeMaster",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_SectorId",
                table: "tblEmployeeMaster",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_ZoneId",
                table: "tblEmployeeMaster",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMasterBackup_DesignationId",
                table: "tblEmployeeMasterBackup",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMasterBackup_DivisionId",
                table: "tblEmployeeMasterBackup",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMasterBackup_EmployeeId",
                table: "tblEmployeeMasterBackup",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMasterBackup_PoliceStationId",
                table: "tblEmployeeMasterBackup",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMasterBackup_SectorId",
                table: "tblEmployeeMasterBackup",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMasterBackup_ZoneId",
                table: "tblEmployeeMasterBackup",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblForm3A_PoliceStationId",
                table: "tblForm3A",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblForm5Master_PoliceStationId",
                table: "tblForm5Master",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblForm5Master_SubCategoryId",
                table: "tblForm5Master",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHistoryMissingAgeWiseChild_PoliceStationId",
                table: "tblHistoryMissingAgeWiseChild",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblhistroryOfCurrentMissing_PoliceStationId",
                table: "tblhistroryOfCurrentMissing",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaborInformationMaster_PoliceStationId",
                table: "tblLaborInformationMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLaborInformationMaster_SubCategoryId",
                table: "tblLaborInformationMaster",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLeaveApplicationMaster_DesignationId",
                table: "tblLeaveApplicationMaster",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLeaveApplicationMaster_EmployeeId",
                table: "tblLeaveApplicationMaster",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLeaveApplicationMaster_InchargeDesignationId",
                table: "tblLeaveApplicationMaster",
                column: "InchargeDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLeaveApplicationMaster_InchargePoliceStationId",
                table: "tblLeaveApplicationMaster",
                column: "InchargePoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLeaveApplicationMaster_PoliceStationId",
                table: "tblLeaveApplicationMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLoginMaster_Mobile_DesignationId",
                table: "tblLoginMaster_Mobile",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLoginMaster_Mobile_DivisionId",
                table: "tblLoginMaster_Mobile",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLoginMaster_Mobile_PoliceStationId",
                table: "tblLoginMaster_Mobile",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLoginMaster_Mobile_RoleId",
                table: "tblLoginMaster_Mobile",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLoginMaster_Mobile_SectorId",
                table: "tblLoginMaster_Mobile",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLoginMaster_Mobile_ZoneId",
                table: "tblLoginMaster_Mobile",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMahekamMaster_PoliceStationId",
                table: "tblMahekamMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMCRDetails_PoliceStationId",
                table: "tblMCRDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMissingChildDetails_GenderId",
                table: "tblMissingChildDetails",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMissingChildDetails_PoliceStationId",
                table: "tblMissingChildDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMonthWiseReport_CategoryId",
                table: "tblMonthWiseReport",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightEmployeeMaster_DesignationId",
                table: "tblNightEmployeeMaster",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightEmployeeMaster_EmployeeId",
                table: "tblNightEmployeeMaster",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightEmployeeMaster_PoliceStationId",
                table: "tblNightEmployeeMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightRound_DivisionId",
                table: "tblNightRound",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightRound_PoliceStationId",
                table: "tblNightRound",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightRound_SectorId",
                table: "tblNightRound",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightRound_ZoneId",
                table: "tblNightRound",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightRound_HEKO_POMaster_PoliceStationId",
                table: "tblNightRound_HEKO_POMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNightRountPersonCountMaster_PoliceStationId",
                table: "tblNightRountPersonCountMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOfiiceWisePendingApplication_CategoryId",
                table: "tblOfiiceWisePendingApplication",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOfiiceWisePendingApplication_PoliceStationId",
                table: "tblOfiiceWisePendingApplication",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart_1_6_Counter_CategoryId",
                table: "tblPart_1_6_Counter",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart_1_6_Counter_DivisionId",
                table: "tblPart_1_6_Counter",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart_1_6_Counter_PoliceStationId",
                table: "tblPart_1_6_Counter",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart_1_6_Counter_SectorId",
                table: "tblPart_1_6_Counter",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart_1_6_Counter_SubCategoryId",
                table: "tblPart_1_6_Counter",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart_1_6_Counter_ZoneId",
                table: "tblPart_1_6_Counter",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart1_5_Crimes_PoliceStationId",
                table: "tblPart1_5_Crimes",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPart1_5_Crimes_SubCategoryId",
                table: "tblPart1_5_Crimes",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPendingArjiDetails_PendingArjiCategoryId",
                table: "tblPendingArjiDetails",
                column: "PendingArjiCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPendingArjiDetails_PoliceStationId",
                table: "tblPendingArjiDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblpendingjanvajogMaster_PoliceStationId",
                table: "tblpendingjanvajogMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPendingWarrant_PoliceStationId",
                table: "tblPendingWarrant",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPendingWarrant_SubCategoryId",
                table: "tblPendingWarrant",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPoliceStation_VehicleChecking_PoliceStationId",
                table: "tblPoliceStation_VehicleChecking",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPoliceStation_VehicleChecking_SubCategoryId",
                table: "tblPoliceStation_VehicleChecking",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPoliceStationWisePendingApplication_KacheriId",
                table: "tblPoliceStationWisePendingApplication",
                column: "KacheriId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPoliceStationWisePendingApplication_PoliceStationId",
                table: "tblPoliceStationWisePendingApplication",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPoliceStationWiseVehical_PoliceStationId",
                table: "tblPoliceStationWiseVehical",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProhibitionCrimeMaster_PoliceStationId",
                table: "tblProhibitionCrimeMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProhibitionCrimeMaster_Copy_PoliceStationId",
                table: "tblProhibitionCrimeMaster_Copy",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSamelPatrakMaster_PatrakId",
                table: "tblSamelPatrakMaster",
                column: "PatrakId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSamelPatrakMaster_PoliceStationId",
                table: "tblSamelPatrakMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSectorMaster_CityId",
                table: "tblSectorMaster",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblStationery_PoliceStationId",
                table: "tblStationery",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubCategoryMaster_CategoryId",
                table: "tblSubCategoryMaster",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraffic_TRB_HomeGuard_Master_PoliceStationId",
                table: "tblTraffic_TRB_HomeGuard_Master",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTraffic_TRG_AHG_Master_PoliceStationId",
                table: "tblTraffic_TRG_AHG_Master",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficCrainWorkMaster_TrafficCrainId",
                table: "tblTrafficCrainWorkMaster",
                column: "TrafficCrainId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficDriveMaster_TrafficDriveCatgeoryId",
                table: "tblTrafficDriveMaster",
                column: "TrafficDriveCatgeoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficInterceptSubCategoryMaster_TrafficInterceptCategoryId",
                table: "tblTrafficInterceptSubCategoryMaster",
                column: "TrafficInterceptCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineDetails_TrafficCategoryId",
                table: "tblTrafficPlaceFineDetails",
                column: "TrafficCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineDetailsJET_TrafficCategoryId",
                table: "tblTrafficPlaceFineDetailsJET",
                column: "TrafficCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineDetailsJET_WardId",
                table: "tblTrafficPlaceFineDetailsJET",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineDetailsJET_WheelerTypeId",
                table: "tblTrafficPlaceFineDetailsJET",
                column: "WheelerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineDetailsJET_NULL_TrafficCategoryId",
                table: "tblTrafficPlaceFineDetailsJET_NULL",
                column: "TrafficCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineDetailsJET_NULL_WardId",
                table: "tblTrafficPlaceFineDetailsJET_NULL",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineDetailsJET_NULL_WheelerTypeId",
                table: "tblTrafficPlaceFineDetailsJET_NULL",
                column: "WheelerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceFineMaster_PoliceStationId",
                table: "tblTrafficPlaceFineMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceITDetails_TrafficCategoryId",
                table: "tblTrafficPlaceITDetails",
                column: "TrafficCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficPlaceITDetails_WheelerTypeId",
                table: "tblTrafficPlaceITDetails",
                column: "WheelerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficSignalBlinkerigh_PoliceStationId",
                table: "tblTrafficSignalBlinkerigh",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficSignalMaster_PoliceStationId",
                table: "tblTrafficSignalMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficSummaryDetails_PoliceStationId",
                table: "tblTrafficSummaryDetails",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrafficTobacoMaster_PoliceStationId",
                table: "tblTrafficTobacoMaster",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVehicleMaster_CategoryId",
                table: "tblVehicleMaster",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVisitation_CrimeBranch_PoliceStationId",
                table: "tblVisitation_CrimeBranch",
                column: "PoliceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblWardWiseJetDetails_WardId",
                table: "tblWardWiseJetDetails",
                column: "WardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CCTVInstalled");

            migrationBuilder.DropTable(
                name: "tbl_CCTVInstalled_HITS");

            migrationBuilder.DropTable(
                name: "tbl_ProhibitionRaidCase");

            migrationBuilder.DropTable(
                name: "tbl_ProhibitionRaidCase_HITS");

            migrationBuilder.DropTable(
                name: "tbl_samans_details");

            migrationBuilder.DropTable(
                name: "tbl_samans_details_HITS");

            migrationBuilder.DropTable(
                name: "tblAccusedInformation");

            migrationBuilder.DropTable(
                name: "tblAccusedInformation_HITS");

            migrationBuilder.DropTable(
                name: "tbladhibitMaster");

            migrationBuilder.DropTable(
                name: "tbladhibitMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblAdminCheckMaster");

            migrationBuilder.DropTable(
                name: "tblAdminWisePendingApplicationMaster");

            migrationBuilder.DropTable(
                name: "tblAtakayatidetails");

            migrationBuilder.DropTable(
                name: "tblAtakayatidetails_HITS");

            migrationBuilder.DropTable(
                name: "tblAtakayatiPagla");

            migrationBuilder.DropTable(
                name: "tblAtakayatiPagla_HITS");

            migrationBuilder.DropTable(
                name: "tblAtakayatiPaglaSummary");

            migrationBuilder.DropTable(
                name: "tblAtakayatiPaglaSummary_HITS");

            migrationBuilder.DropTable(
                name: "tblAtakKarel_Esam");

            migrationBuilder.DropTable(
                name: "tblAtkayatiPagalaConsolidated");

            migrationBuilder.DropTable(
                name: "tblAtkayatiPagalaConsolidated_backup");

            migrationBuilder.DropTable(
                name: "tblAtkayatiPagalaConsolidated_HITS");

            migrationBuilder.DropTable(
                name: "tblAutoRickshawDetails");

            migrationBuilder.DropTable(
                name: "tblAutoRickshawDetails_HITS");

            migrationBuilder.DropTable(
                name: "tblBandobastDetailMaster");

            migrationBuilder.DropTable(
                name: "tblBandobastDetailMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblCctvMaster");

            migrationBuilder.DropTable(
                name: "tblCctvMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblChangeColor");

            migrationBuilder.DropTable(
                name: "tblCheckAnswerDetails");

            migrationBuilder.DropTable(
                name: "tblCheckDetails");

            migrationBuilder.DropTable(
                name: "tblCriminalCountInformation");

            migrationBuilder.DropTable(
                name: "tblCriminalCountInformation_HITS");

            migrationBuilder.DropTable(
                name: "tblCriminalInformation");

            migrationBuilder.DropTable(
                name: "tblCriminalInformation_HITS");

            migrationBuilder.DropTable(
                name: "tblCRPC41CAmendmentMater");

            migrationBuilder.DropTable(
                name: "tblCRPC41CAmendmentMater_HITS");

            migrationBuilder.DropTable(
                name: "tblCRPC41Master");

            migrationBuilder.DropTable(
                name: "tblCRPC41Master_HITS");

            migrationBuilder.DropTable(
                name: "tblCurrentYearAgeWiseMissingChildDetails");

            migrationBuilder.DropTable(
                name: "tblCurrentYearAgeWiseMissingChildDetails_HITS");

            migrationBuilder.DropTable(
                name: "tblCurrentYearMissingChildDetails");

            migrationBuilder.DropTable(
                name: "tblCurrentYearMissingChildDetails_HITS");

            migrationBuilder.DropTable(
                name: "tblDCB_PolicestationMaster");

            migrationBuilder.DropTable(
                name: "tblDCB_PolicestationMaster_HITS");

            migrationBuilder.DropTable(
                name: "tbldetainMaster");

            migrationBuilder.DropTable(
                name: "tbldetainMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblDistributeVehical");

            migrationBuilder.DropTable(
                name: "tblDistributeVehical_HITS");

            migrationBuilder.DropTable(
                name: "tblE_GujakopMaster");

            migrationBuilder.DropTable(
                name: "tblE_GujakopMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblE_GujkopDetails");

            migrationBuilder.DropTable(
                name: "tblEmployeeMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblEmployeeMasterBackup");

            migrationBuilder.DropTable(
                name: "tblEquipments_HITS");

            migrationBuilder.DropTable(
                name: "tblForm3A");

            migrationBuilder.DropTable(
                name: "tblForm3A_HITS");

            migrationBuilder.DropTable(
                name: "tblForm5Master");

            migrationBuilder.DropTable(
                name: "tblHistoryMissingAgeWiseChild");

            migrationBuilder.DropTable(
                name: "tblHistoryMissingAgeWiseChild_HITS");

            migrationBuilder.DropTable(
                name: "tblhistroryOfCurrentMissing");

            migrationBuilder.DropTable(
                name: "tblIPC_GPCMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblLaborInformationMaster");

            migrationBuilder.DropTable(
                name: "tblLaborInformationMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblLeaveApplicationMaster");

            migrationBuilder.DropTable(
                name: "tblLeaveApplicationMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblLeaveTypeMaster");

            migrationBuilder.DropTable(
                name: "tblLeaveTypeMaster_HITS");

            migrationBuilder.DropTable(
                name: "tblLoginMaster_Mobile");

            migrationBuilder.DropTable(
                name: "tblMahekamMaster");

            migrationBuilder.DropTable(
                name: "tblMCRDetails");

            migrationBuilder.DropTable(
                name: "tblMCRDetails_HITS");

            migrationBuilder.DropTable(
                name: "tblMissingChildDetails");

            migrationBuilder.DropTable(
                name: "tblMissingChildDetails_HIST");

            migrationBuilder.DropTable(
                name: "tblMonthWiseReport");

            migrationBuilder.DropTable(
                name: "tblMonthWiseReport_HIST");

            migrationBuilder.DropTable(
                name: "tblNightEmployeeMaster");

            migrationBuilder.DropTable(
                name: "tblNightEmployeeMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblNightRound");

            migrationBuilder.DropTable(
                name: "tblNightRound_HEKO_POMaster");

            migrationBuilder.DropTable(
                name: "tblNightRound_HEKO_POMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblNightRound_HIST");

            migrationBuilder.DropTable(
                name: "tblNightRountPersonCountMaster");

            migrationBuilder.DropTable(
                name: "tblNightRountPersonCountMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblOfiiceWisePendingApplication");

            migrationBuilder.DropTable(
                name: "tblOfiiceWisePendingApplication_HIST");

            migrationBuilder.DropTable(
                name: "tblPart_1_6_Counter");

            migrationBuilder.DropTable(
                name: "tblPart1_5_Crimes");

            migrationBuilder.DropTable(
                name: "tblPart1_5_Crimes_HIST");

            migrationBuilder.DropTable(
                name: "tblPendingArjiDetails");

            migrationBuilder.DropTable(
                name: "tblPendingArjiDetails_HIST");

            migrationBuilder.DropTable(
                name: "tblpendingjanvajogMaster");

            migrationBuilder.DropTable(
                name: "tblpendingjanvajogMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblPendingWarrant");

            migrationBuilder.DropTable(
                name: "tblPendingWarrant_HIST");

            migrationBuilder.DropTable(
                name: "tblPidhela_Kabja_CategoryMaster");

            migrationBuilder.DropTable(
                name: "tblPoliceStation_VehicleChecking");

            migrationBuilder.DropTable(
                name: "tblPoliceStation_VehicleChecking_HIST");

            migrationBuilder.DropTable(
                name: "tblPoliceStationWisePendingApplication");

            migrationBuilder.DropTable(
                name: "tblPoliceStationWisePendingApplication_HIST");

            migrationBuilder.DropTable(
                name: "tblPoliceStationWiseVehical");

            migrationBuilder.DropTable(
                name: "tblPoliceStationWiseVehical_HIST");

            migrationBuilder.DropTable(
                name: "tblProhibitionCrimeMaster");

            migrationBuilder.DropTable(
                name: "tblProhibitionCrimeMaster_Copy");

            migrationBuilder.DropTable(
                name: "tblProhibitionCrimeMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblSamelCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblSamelPatrakMaster");

            migrationBuilder.DropTable(
                name: "tblSamelPatrakMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblStationery");

            migrationBuilder.DropTable(
                name: "tblStationery_HIST");

            migrationBuilder.DropTable(
                name: "tblSubCategoryCount");

            migrationBuilder.DropTable(
                name: "tblTraffic_TRB_HomeGuard_Master");

            migrationBuilder.DropTable(
                name: "tblTraffic_TRB_HomeGuard_Master_HIST");

            migrationBuilder.DropTable(
                name: "tblTraffic_TRG_AHG_Master");

            migrationBuilder.DropTable(
                name: "tblTraffic_TRG_AHG_Master_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficAccidentalDetails");

            migrationBuilder.DropTable(
                name: "tblTrafficAccidentalDetails_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficCategorySummaryMasters");

            migrationBuilder.DropTable(
                name: "tblTrafficCrainCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficCrainMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficCrainTypeMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficCrainWorkMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficCrainWorkMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficDriveMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficDriveMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficEchallanCollection");

            migrationBuilder.DropTable(
                name: "tblTrafficEchallanCollection_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficGhasCharaMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficGhasCharaMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficInterceptSubCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficInterceptWorkDetails");

            migrationBuilder.DropTable(
                name: "tblTrafficInterceptWorkDetails_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficIPC_188");

            migrationBuilder.DropTable(
                name: "tblTrafficIPC_188_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficIPC_283");

            migrationBuilder.DropTable(
                name: "tblTrafficIPC_283_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficJam_Details_ALL");

            migrationBuilder.DropTable(
                name: "tblTrafficJam_Details_ALL_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficMahekamMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficMahekamMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficMVACTDetails");

            migrationBuilder.DropTable(
                name: "tblTrafficMVACTDetails_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficPart1_5_Details");

            migrationBuilder.DropTable(
                name: "tblTrafficPart1_5_Details_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineDetails");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineDetails_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineDetails_NULL");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineDetailsJET");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineDetailsJET_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineDetailsJET_NULL");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceFineMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceITDetails");

            migrationBuilder.DropTable(
                name: "tblTrafficPlaceITDetails_NULL");

            migrationBuilder.DropTable(
                name: "tblTrafficSignalBlinkerigh");

            migrationBuilder.DropTable(
                name: "tblTrafficSignalBlinkerigh_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficSignalMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficSignalMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficSummaryDetails");

            migrationBuilder.DropTable(
                name: "tblTrafficSummaryDetails_HIST");

            migrationBuilder.DropTable(
                name: "tblTrafficTobacoMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficTobacoMaster_HIST");

            migrationBuilder.DropTable(
                name: "tblVehicleMaster");

            migrationBuilder.DropTable(
                name: "tblVisitation_CrimeBranch");

            migrationBuilder.DropTable(
                name: "tblVisitation_CrimeBranch_HIST");

            migrationBuilder.DropTable(
                name: "tblWardWiseJetDetails");

            migrationBuilder.DropTable(
                name: "tblWardWiseJetDetails_HITS");

            migrationBuilder.DropTable(
                name: "tblIPC_GPCMaster");

            migrationBuilder.DropTable(
                name: "tblBandobastTypeMaster");

            migrationBuilder.DropTable(
                name: "tblEquipments");

            migrationBuilder.DropTable(
                name: "tblStatusMaster");

            migrationBuilder.DropTable(
                name: "tblGenderMaster");

            migrationBuilder.DropTable(
                name: "tblEmployeeMaster");

            migrationBuilder.DropTable(
                name: "tblPendingArjiCategory");

            migrationBuilder.DropTable(
                name: "tblSubCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblkacheriMaster");

            migrationBuilder.DropTable(
                name: "tblIndexPatrakMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficCrainMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficDriveCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblTrafficInterceptCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblTraffiCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblWheelerType");

            migrationBuilder.DropTable(
                name: "tblWardMaster");

            migrationBuilder.DropTable(
                name: "tblDesignationName");

            migrationBuilder.DropTable(
                name: "tblDivisionMaster");

            migrationBuilder.DropTable(
                name: "tblPoliceStationMaster");

            migrationBuilder.DropTable(
                name: "tblRoleMaster");

            migrationBuilder.DropTable(
                name: "tblSectorMaster");

            migrationBuilder.DropTable(
                name: "tblCategoryMaster");

            migrationBuilder.DropTable(
                name: "tblZoneMaster");

            migrationBuilder.DropTable(
                name: "tblCityMaster");

            migrationBuilder.DropTable(
                name: "tblStateMaster");
        }
    }
}