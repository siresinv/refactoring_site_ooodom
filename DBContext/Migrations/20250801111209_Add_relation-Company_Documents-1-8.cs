using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Add_relationCompany_Documents18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CompanyId",
                table: "Documents",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Companies_CompanyId",
                table: "Documents",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Companies_CompanyId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CompanyId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Documents");
        }
    }
}
