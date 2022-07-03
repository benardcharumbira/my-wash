using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWash.API.Migrations
{
    public partial class MakeUserIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampusTerraceLaundrySessions_User_UserId",
                table: "CampusTerraceLaundrySessions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CampusTerraceLaundrySessions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CampusTerraceLaundrySessions_User_UserId",
                table: "CampusTerraceLaundrySessions",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampusTerraceLaundrySessions_User_UserId",
                table: "CampusTerraceLaundrySessions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CampusTerraceLaundrySessions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CampusTerraceLaundrySessions_User_UserId",
                table: "CampusTerraceLaundrySessions",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
