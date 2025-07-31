using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Add_relationCompany_CompanyCard11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CompanyCards_CompanyCardId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CompanyCardId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CompanyCardId",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "CompanyCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCards_CompanyId",
                table: "CompanyCards",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCards_Companies_CompanyId",
                table: "CompanyCards",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCards_Companies_CompanyId",
                table: "CompanyCards");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCards_CompanyId",
                table: "CompanyCards");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CompanyCards");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyCardId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CompanyCardId",
                table: "Documents",
                column: "CompanyCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CompanyCards_CompanyCardId",
                table: "Documents",
                column: "CompanyCardId",
                principalTable: "CompanyCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
