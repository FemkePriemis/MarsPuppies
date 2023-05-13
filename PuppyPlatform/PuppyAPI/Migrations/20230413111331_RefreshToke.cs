using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    AccessGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.AccessGUID);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "Users",
                        principalColumn: "UserGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserGUID",
                table: "RefreshTokens",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");
        }
    }
}
