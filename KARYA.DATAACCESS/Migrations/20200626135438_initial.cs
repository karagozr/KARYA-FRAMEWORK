using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KARYA.DATAACCESS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<int>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    UserGroupId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(maxLength: 20, nullable: true),
                    UserName = table.Column<string>(maxLength: 20, nullable: true),
                    Password = table.Column<string>(maxLength: 10, nullable: true),
                    EMail = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    UpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
            migrationBuilder.Sql("use KARYA if(not exists(select * from Users)) begin INSERT INTO Users(Enable,Code,Name,UserName,Password) Values(1,'User001','Karya','Admin','123') end ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
