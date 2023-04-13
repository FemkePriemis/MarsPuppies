using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Healthstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Healthstate",
                table: "HealthStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthStatus",
                table: "HealthStatus");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "HealthStatus");

            migrationBuilder.RenameColumn(
                name: "HealthstatusGUID",
                table: "HealthStatus",
                newName: "TempId1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_EFHealthStatus_TempId1",
                table: "HealthStatus",
                column: "TempId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_EFHealthStatus_HealthstatusGUID",
                table: "Dog",
                column: "HealthstatusGUID",
                principalTable: "HealthStatus",
                principalColumn: "TempId1",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
