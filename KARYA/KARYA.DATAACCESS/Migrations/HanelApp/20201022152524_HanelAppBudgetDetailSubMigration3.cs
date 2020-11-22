using Microsoft.EntityFrameworkCore.Migrations;

namespace KARYA.DATAACCESS.Migrations.HanelApp
{
    public partial class HanelAppBudgetDetailSubMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enable",
                table: "BudgetSubDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "BudgetSubDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
