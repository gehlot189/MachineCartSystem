using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MachineCartSystem.Entity.Migrations
{
    public partial class MachineCartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "UserDetail",
                schema: "Core",
                columns: table => new
                {
                    UserDetaildId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 500, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 500, nullable: true),
                    LastName = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserDeta__06F8BA23998FF343", x => x.UserDetaildId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetail",
                schema: "Core");
        }
    }
}
