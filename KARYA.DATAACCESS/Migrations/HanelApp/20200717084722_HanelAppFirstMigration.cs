using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KARYA.DATAACCESS.Migrations.HanelApp
{
    public partial class HanelAppFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(nullable: false),
                    BudgetType = table.Column<short>(nullable: false),
                    BranchCode = table.Column<string>(maxLength: 20, nullable: false),
                    ProjectCode = table.Column<string>(maxLength: 20, nullable: false),
                    BudgetMainCode = table.Column<string>(maxLength: 20, nullable: false),
                    BudgetSubCode = table.Column<string>(maxLength: 20, nullable: false),
                    BudgetTaxMultiplier = table.Column<double>(nullable: false),
                    Description1 = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true),
                    Description3 = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(nullable: false),
                    BudgetId = table.Column<int>(nullable: false),
                    PeriodDate = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    UnitCode = table.Column<string>(maxLength: 10, nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_BudgetId",
                table: "BudgetDetail",
                column: "BudgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetDetail");

            migrationBuilder.DropTable(
                name: "Budget");
        }
    }
}
