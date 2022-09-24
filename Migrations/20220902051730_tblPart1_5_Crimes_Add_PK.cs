using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmedabadCityDR.Migrations
{
    public partial class tblPart1_5_Crimes_Add_PK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPart1_5_Crimes",
                table: "tblPart1_5_Crimes",
                column: "CrimesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPart1_5_Crimes",
                table: "tblPart1_5_Crimes");
        }
    }
}
