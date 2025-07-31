using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class Add_relationUnit_unitCard11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LifeAmount",
                table: "UnitCards",
                newName: "LiftAmount");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "UnitCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UnitCards_UnitId",
                table: "UnitCards",
                column: "UnitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitCards_Units_UnitId",
                table: "UnitCards",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitCards_Units_UnitId",
                table: "UnitCards");

            migrationBuilder.DropIndex(
                name: "IX_UnitCards_UnitId",
                table: "UnitCards");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "UnitCards");

            migrationBuilder.RenameColumn(
                name: "LiftAmount",
                table: "UnitCards",
                newName: "LifeAmount");
        }
    }
}
