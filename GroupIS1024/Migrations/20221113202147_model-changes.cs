using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupIS1024.Migrations
{
    public partial class modelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Coach",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Memberstatus",
                table: "Coach",
                newName: "CoachStatus");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Coach",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Coach",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "CoachStatus",
                table: "Coach",
                newName: "Memberstatus");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Coach",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
