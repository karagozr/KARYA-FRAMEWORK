using Microsoft.EntityFrameworkCore.Migrations;

namespace KARYA.DATAACCESS.Migrations.HanelApp
{
    public partial class HanelBudgetUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "BudgetMonth",
                table: "BudgetDetail",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "BudgetYear",
                table: "BudgetDetail",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "BudgetYear",
                table: "Budget",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetMonth",
                table: "BudgetDetail");

            migrationBuilder.DropColumn(
                name: "BudgetYear",
                table: "BudgetDetail");

            migrationBuilder.DropColumn(
                name: "BudgetYear",
                table: "Budget");
        }
    }
}
