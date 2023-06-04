using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ConfigurationPositions_PositionId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Products",
                newName: "ConfigurationPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PositionId",
                table: "Products",
                newName: "IX_Products_ConfigurationPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ConfigurationPositions_ConfigurationPositionId",
                table: "Products",
                column: "ConfigurationPositionId",
                principalTable: "ConfigurationPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ConfigurationPositions_ConfigurationPositionId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ConfigurationPositionId",
                table: "Products",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ConfigurationPositionId",
                table: "Products",
                newName: "IX_Products_PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ConfigurationPositions_PositionId",
                table: "Products",
                column: "PositionId",
                principalTable: "ConfigurationPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
