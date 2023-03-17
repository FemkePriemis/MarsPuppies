using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add1to1BehaviourDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiometricsID",
                table: "Biometric");

            migrationBuilder.RenameColumn(
                name: "DogID",
                table: "Behaviour",
                newName: "EFDogId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Behaviour_Dog_EFDogId",
                table: "Behaviour");

            migrationBuilder.DropIndex(
                name: "IX_Behaviour_EFDogId",
                table: "Behaviour");

            migrationBuilder.RenameColumn(
                name: "EFDogId",
                table: "Behaviour",
                newName: "DogID");

            migrationBuilder.AddColumn<int>(
                name: "BiometricsID",
                table: "Biometric",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
