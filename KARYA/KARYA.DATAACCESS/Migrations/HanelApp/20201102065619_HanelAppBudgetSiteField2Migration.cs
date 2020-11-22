using Microsoft.EntityFrameworkCore.Migrations;

namespace KARYA.DATAACCESS.Migrations.HanelApp
{
    public partial class HanelAppBudgetSiteField2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteCode",
                table: "Budget",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteCode",
                table: "Budget");
        }
    }
}
