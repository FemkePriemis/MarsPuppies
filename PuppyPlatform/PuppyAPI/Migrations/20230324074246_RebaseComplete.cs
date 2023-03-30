using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyAPI.Migrations
{
    /// <inheritdoc />
    public partial class RebaseComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Behaviour",
                columns: table => new
                {
                    BehaviourGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnusualBehaviour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behaviour", x => x.BehaviourGUID);
                });

            migrationBuilder.CreateTable(
                name: "Biometric",
                columns: table => new
                {
                    BiometricGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeartrateThreshold = table.Column<int>(type: "int", nullable: false),
                    TemperatureThreshold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometric", x => x.BiometricGUID);
                });

            migrationBuilder.CreateTable(
                name: "HealthStates",
                columns: table => new
                {
                    HealthstateGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Healthstate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStates", x => x.HealthstateGUID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleGUID);
                });

            migrationBuilder.CreateTable(
                name: "HealthStatus",
                columns: table => new
                {
                    HealthstatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthstateGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatus", x => x.HealthstatusGUID);
                    table.ForeignKey(
                        name: "FK_HealthStatus_HealthStates_HealthstateGUID",
                        column: x => x.HealthstateGUID,
                        principalTable: "HealthStates",
                        principalColumn: "HealthstateGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserGUID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleGUID",
                        column: x => x.RoleGUID,
                        principalTable: "Roles",
                        principalColumn: "RoleGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    HealthstatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BiometricsGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BehaviourGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.DogGUID);
                    table.ForeignKey(
                        name: "FK_Dog_Behaviour_BehaviourGUID",
                        column: x => x.BehaviourGUID,
                        principalTable: "Behaviour",
                        principalColumn: "BehaviourGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dog_Biometric_BiometricsGUID",
                        column: x => x.BiometricsGUID,
                        principalTable: "Biometric",
                        principalColumn: "BiometricGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dog_HealthStatus_HealthstatusGUID",
                        column: x => x.HealthstatusGUID,
                        principalTable: "HealthStatus",
                        principalColumn: "HealthstatusGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityGrade",
                columns: table => new
                {
                    GradeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGrade", x => x.GradeGUID);
                    table.ForeignKey(
                        name: "FK_ActivityGrade_Dog_DogGUID",
                        column: x => x.DogGUID,
                        principalTable: "Dog",
                        principalColumn: "DogGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heartrate",
                columns: table => new
                {
                    HeartrateGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeartrateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heartrate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heartrate", x => x.HeartrateGUID);
                    table.ForeignKey(
                        name: "FK_Heartrate_Dog_DogGUID",
                        column: x => x.DogGUID,
                        principalTable: "Dog",
                        principalColumn: "DogGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Illness",
                columns: table => new
                {
                    IllnessGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Illness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IllnessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illness", x => x.IllnessGUID);
                    table.ForeignKey(
                        name: "FK_Illness_Dog_DogGUID",
                        column: x => x.DogGUID,
                        principalTable: "Dog",
                        principalColumn: "DogGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Injury",
                columns: table => new
                {
                    InjuryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Injury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injury", x => x.InjuryGUID);
                    table.ForeignKey(
                        name: "FK_Injury_Dog_DogGUID",
                        column: x => x.DogGUID,
                        principalTable: "Dog",
                        principalColumn: "DogGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    MedicationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedicationGUID);
                    table.ForeignKey(
                        name: "FK_Medication_Dog_DogGUID",
                        column: x => x.DogGUID,
                        principalTable: "Dog",
                        principalColumn: "DogGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    DogrelationsGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => x.DogrelationsGUID);
                    table.ForeignKey(
                        name: "FK_Relation_Dog_DogGUID",
                        column: x => x.DogGUID,
                        principalTable: "Dog",
                        principalColumn: "DogGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relation_Users_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "Users",
                        principalColumn: "UserGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    TemperatureGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemperatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.TemperatureGUID);
                    table.ForeignKey(
                        name: "FK_Temperature_Dog_DogGUID",
                        column: x => x.DogGUID,
                        principalTable: "Dog",
                        principalColumn: "DogGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityGrade_DogGUID",
                table: "ActivityGrade",
                column: "DogGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Dog_BehaviourGUID",
                table: "Dog",
                column: "BehaviourGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Dog_BiometricsGUID",
                table: "Dog",
                column: "BiometricsGUID");


            migrationBuilder.CreateIndex(
                name: "IX_Heartrate_DogGUID",
                table: "Heartrate",
                column: "DogGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Illness_DogGUID",
                table: "Illness",
                column: "DogGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Injury_DogGUID",
                table: "Injury",
                column: "DogGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_DogGUID",
                table: "Medication",
                column: "DogGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_DogGUID",
                table: "Relation",
                column: "DogGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_UserGUID",
                table: "Relation",
                column: "UserGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_DogGUID",
                table: "Temperature",
                column: "DogGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleGUID",
                table: "Users",
                column: "RoleGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityGrade");

            migrationBuilder.DropTable(
                name: "Heartrate");

            migrationBuilder.DropTable(
                name: "Illness");

            migrationBuilder.DropTable(
                name: "Injury");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dog");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Behaviour");

            migrationBuilder.DropTable(
                name: "Biometric");

            migrationBuilder.DropTable(
                name: "HealthStatus");

            migrationBuilder.DropTable(
                name: "HealthStates");
        }
    }
}
