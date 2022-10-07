using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmedabadCityDR.Migrations
{
    public partial class TblPoliceStationWiseVehical_add_PK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPoliceStationWiseVehical",
                table: "tblPoliceStationWiseVehical",
                column: "PoliceStationwiseVehicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPoliceStationWiseVehical",
                table: "tblPoliceStationWiseVehical");
        }
    }
}
