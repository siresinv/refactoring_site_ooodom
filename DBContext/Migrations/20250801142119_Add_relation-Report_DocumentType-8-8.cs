using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Add_relationReport_DocumentType88 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_Reports_ReportId",
                table: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "DocumentsTypeReports");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_ReportId",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "DocumentTypes");

            migrationBuilder.CreateTable(
                name: "DocumentTypeReport",
                columns: table => new
                {
                    DocumentTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeReport", x => new { x.DocumentTypesId, x.ReportsId });
                    table.ForeignKey(
                        name: "FK_DocumentTypeReport_DocumentTypes_DocumentTypesId",
                        column: x => x.DocumentTypesId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentTypeReport_Reports_ReportsId",
                        column: x => x.ReportsId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeReport_ReportsId",
                table: "DocumentTypeReport",
                column: "ReportsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentTypeReport");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "DocumentTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentsTypeReports",
                columns: table => new
                {
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsTypeReports", x => new { x.DocumentTypeId, x.ReportId });
                    table.ForeignKey(
                        name: "FK_DocumentsTypeReports_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsTypeReports_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_ReportId",
                table: "DocumentTypes",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsTypeReports_ReportId",
                table: "DocumentsTypeReports",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Reports_ReportId",
                table: "DocumentTypes",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
