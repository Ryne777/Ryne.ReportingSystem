using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ryne.ReportingSystem.Application.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engineer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfDefectoscopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfDefectoscopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defectoscopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfDefectoscopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defectoscopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defectoscopes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Defectoscopes_TypeOfDefectoscopes_TypeOfDefectoscopeId",
                        column: x => x.TypeOfDefectoscopeId,
                        principalTable: "TypeOfDefectoscopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfReceipt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCalibration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastRepair = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfRepair = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefectoscopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Defectoscopes_DefectoscopeId",
                        column: x => x.DefectoscopeId,
                        principalTable: "Defectoscopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Engineer_EngineerID",
                        column: x => x.EngineerID,
                        principalTable: "Engineer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Defectoscopes_OrganizationId",
                table: "Defectoscopes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Defectoscopes_TypeOfDefectoscopeId",
                table: "Defectoscopes",
                column: "TypeOfDefectoscopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_DefectoscopeId",
                table: "Repairs",
                column: "DefectoscopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_EngineerID",
                table: "Repairs",
                column: "EngineerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Defectoscopes");

            migrationBuilder.DropTable(
                name: "Engineer");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "TypeOfDefectoscopes");
        }
    }
}
