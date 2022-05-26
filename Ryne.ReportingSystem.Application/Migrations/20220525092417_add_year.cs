using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ryne.ReportingSystem.Application.Migrations
{
    public partial class add_year : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductionYear",
                table: "Defectoscopes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionYear",
                table: "Defectoscopes");
        }
    }
}
