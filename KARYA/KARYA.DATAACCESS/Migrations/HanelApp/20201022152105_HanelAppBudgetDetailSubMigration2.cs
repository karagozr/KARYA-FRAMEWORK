using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KARYA.DATAACCESS.Migrations.HanelApp
{
    public partial class HanelAppBudgetDetailSubMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetSubDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(nullable: false),
                    BudgetId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Ocak = table.Column<decimal>(nullable: false),
                    Subat = table.Column<decimal>(nullable: false),
                    Mart = table.Column<decimal>(nullable: false),
                    Nisan = table.Column<decimal>(nullable: false),
                    Mayis = table.Column<decimal>(nullable: false),
                    Haziran = table.Column<decimal>(nullable: false),
                    Temmuz = table.Column<decimal>(nullable: false),
                    Agustos = table.Column<decimal>(nullable: false),
                    Eylul = table.Column<decimal>(nullable: false),
                    Ekim = table.Column<decimal>(nullable: false),
                    Kasim = table.Column<decimal>(nullable: false),
                    Aralik = table.Column<decimal>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetSubDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetSubDetail_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetSubDetail_BudgetId",
                table: "BudgetSubDetail",
                column: "BudgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetSubDetail");
        }
    }
}
