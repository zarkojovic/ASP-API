using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectASP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addeduseridindealstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_UserId",
                table: "Deals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Users_UserId",
                table: "Deals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Users_UserId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_UserId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Deals");
        }
    }
}
