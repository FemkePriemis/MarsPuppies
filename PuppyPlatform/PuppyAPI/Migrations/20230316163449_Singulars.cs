using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Singulars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityGrades");

            migrationBuilder.DropTable(
                name: "Biometrics");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Injuries");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "SleepGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heartrates",
                table: "Heartrates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthStatuses",
                table: "HealthStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Behaviours",
                table: "Behaviours");

            migrationBuilder.RenameTable(
                name: "Temperatures",
                newName: "Temperature");

            migrationBuilder.RenameTable(
                name: "Relations",
                newName: "Relation");

            migrationBuilder.RenameTable(
                name: "Heartrates",
                newName: "Heartrate");

            migrationBuilder.RenameTable(
                name: "HealthStatuses",
                newName: "HealthStatus");

            migrationBuilder.RenameTable(
                name: "Dogs",
                newName: "Dog");

            migrationBuilder.RenameTable(
                name: "Behaviours",
                newName: "Behaviour");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Relation",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "BehaviourID",
                table: "Behaviour",
                newName: "DogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relation",
                table: "Relation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heartrate",
                table: "Heartrate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthStatus",
                table: "HealthStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dog",
                table: "Dog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Behaviour",
                table: "Behaviour",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActivityGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biometric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiometricsID = table.Column<int>(type: "int", nullable: false),
                    HeartrateThreshold = table.Column<int>(type: "int", nullable: false),
                    TemperatureThreshold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometric", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Illness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IllnessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Injury",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Injury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injury", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityGrade");

            migrationBuilder.DropTable(
                name: "Biometric");

            migrationBuilder.DropTable(
                name: "Illness");

            migrationBuilder.DropTable(
                name: "Injury");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relation",
                table: "Relation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heartrate",
                table: "Heartrate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthStatus",
                table: "HealthStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dog",
                table: "Dog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Behaviour",
                table: "Behaviour");

            migrationBuilder.RenameTable(
                name: "Temperature",
                newName: "Temperatures");

            migrationBuilder.RenameTable(
                name: "Relation",
                newName: "Relations");

            migrationBuilder.RenameTable(
                name: "Heartrate",
                newName: "Heartrates");

            migrationBuilder.RenameTable(
                name: "HealthStatus",
                newName: "HealthStatuses");

            migrationBuilder.RenameTable(
                name: "Dog",
                newName: "Dogs");

            migrationBuilder.RenameTable(
                name: "Behaviour",
                newName: "Behaviours");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Relations",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "DogID",
                table: "Behaviours",
                newName: "BehaviourID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heartrates",
                table: "Heartrates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthStatuses",
                table: "HealthStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Behaviours",
                table: "Behaviours",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActivityGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biometrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiometricsID = table.Column<int>(type: "int", nullable: false),
                    HeartrateThreshold = table.Column<int>(type: "int", nullable: false),
                    TemperatureThreshold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Illness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IllnessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Injuries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Injury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injuries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SleepGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepGrades", x => x.Id);
                });
        }
    }
}
