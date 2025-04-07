using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class AddBoss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AbsenceBalance",
                table: "AspNetUsers",
                newName: "StatusEmployee");

            migrationBuilder.AddColumn<string>(
                name: "BossId",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LeaveQuantityThisYear",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeaveQuantityTotal",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNumberLeave",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SickLeaveQuantity",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BossId",
                table: "AspNetUsers",
                column: "BossId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BossId",
                table: "AspNetUsers",
                column: "BossId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BossId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BossId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BossId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LeaveQuantityThisYear",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LeaveQuantityTotal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaxNumberLeave",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SickLeaveQuantity",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "StatusEmployee",
                table: "AspNetUsers",
                newName: "AbsenceBalance");
        }
    }
}
