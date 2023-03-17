using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrectConnections2Design : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Behaviour_Dog_EFDogId",
                table: "Behaviour");

            migrationBuilder.DropIndex(
                name: "IX_Behaviour_EFDogId",
                table: "Behaviour");

            migrationBuilder.DropColumn(
                name: "EFDogId",
                table: "Behaviour");

            migrationBuilder.AlterColumn<string>(
                name: "UnusualBehaviour",
                table: "Behaviour",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnusualBehaviour",
                table: "Behaviour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EFDogId",
                table: "Behaviour",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Behaviour_EFDogId",
                table: "Behaviour",
                column: "EFDogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Behaviour_Dog_EFDogId",
                table: "Behaviour",
                column: "EFDogId",
                principalTable: "Dog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
