using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Add_relationUnit_unitDocument_Cocument18_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UnitDocuments_DocumentId",
                table: "UnitDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_UnitDocuments_DocumentId",
                table: "UnitDocuments",
                column: "DocumentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UnitDocuments_DocumentId",
                table: "UnitDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_UnitDocuments_DocumentId",
                table: "UnitDocuments",
                column: "DocumentId");
        }
    }
}
