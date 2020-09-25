using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyingAndSellingRealEstateNordic.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxData",
                columns: table => new
                {
                    TaxDataId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxData", x => x.TaxDataId);
                });

            migrationBuilder.CreateTable(
                name: "TaxSchedule",
                columns: table => new
                {
                    TaxScheduleId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScheduleType = table.Column<int>(nullable: false),
                    TaxCost = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    TaxDataId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSchedule", x => x.TaxScheduleId);
                    table.ForeignKey(
                        name: "FK_TaxSchedule_TaxData_TaxDataId",
                        column: x => x.TaxDataId,
                        principalTable: "TaxData",
                        principalColumn: "TaxDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleRange",
                columns: table => new
                {
                    ScheduleRangeId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    TaxScheduleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleRange", x => x.ScheduleRangeId);
                    table.ForeignKey(
                        name: "FK_ScheduleRange_TaxSchedule_TaxScheduleId",
                        column: x => x.TaxScheduleId,
                        principalTable: "TaxSchedule",
                        principalColumn: "TaxScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRange_TaxScheduleId",
                table: "ScheduleRange",
                column: "TaxScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxSchedule_TaxDataId",
                table: "TaxSchedule",
                column: "TaxDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleRange");

            migrationBuilder.DropTable(
                name: "TaxSchedule");

            migrationBuilder.DropTable(
                name: "TaxData");
        }
    }
}
