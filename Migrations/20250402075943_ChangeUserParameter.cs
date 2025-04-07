using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "AbsenceBalance",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByHRManagerId",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "AspNetUsers",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddedByHRManagerId",
                table: "AspNetUsers",
                column: "AddedByHRManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AddedByHRManagerId",
                table: "AspNetUsers",
                column: "AddedByHRManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AddedByHRManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddedByHRManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AbsenceBalance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddedByHRManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Lastname");
        }
    }
}
