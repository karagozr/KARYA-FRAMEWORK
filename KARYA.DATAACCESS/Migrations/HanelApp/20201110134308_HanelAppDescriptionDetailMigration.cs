using Microsoft.EntityFrameworkCore.Migrations;

namespace KARYA.DATAACCESS.Migrations.HanelApp
{
    public partial class HanelAppDescriptionDetailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_Budget_BudgetId",
                table: "Budget");

            migrationBuilder.DropIndex(
                name: "IX_Budget_BudgetId",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Budget");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionDetail",
                table: "Budget",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionDetail",
                table: "Budget");

            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "Budget",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budget_BudgetId",
                table: "Budget",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_Budget_BudgetId",
                table: "Budget",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
