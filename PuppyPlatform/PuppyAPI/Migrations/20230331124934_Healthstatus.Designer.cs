﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PuppyAPI.Database;

#nullable disable

namespace PuppyAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230331124934_Healthstatus")]
    partial class Healthstatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFBehaviour", b =>
                {
                    b.Property<Guid>("BehaviourGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UnusualBehaviour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BehaviourGUID");

                    b.ToTable("Behaviour");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFBiometric", b =>
                {
                    b.Property<Guid>("BiometricGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HeartrateThreshold")
                        .HasColumnType("int");

                    b.Property<double>("TemperatureThreshold")
                        .HasColumnType("float");

                    b.HasKey("BiometricGUID");

                    b.ToTable("Biometric");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFDog", b =>
                {
                    b.Property<Guid>("DogGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("BehaviourGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BiometricsGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HealthstatusGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("DogGUID");

                    b.HasIndex("BehaviourGUID");

                    b.HasIndex("BiometricsGUID");

                    b.HasIndex("HealthstatusGUID");

                    b.ToTable("Dog");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFDogRelations", b =>
                {
                    b.Property<Guid>("DogrelationsGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserGUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DogrelationsGUID");

                    b.HasIndex("DogGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("Relation");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFGrade", b =>
                {
                    b.Property<Guid>("GradeGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<DateTime>("GradeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeGUID");

                    b.HasIndex("DogGUID");

                    b.ToTable("ActivityGrade");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFHealthStatus", b =>
                {
                    b.Property<Guid>("HealthstatusGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Healthstate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("HealthstatusGUID");

                    b.ToTable("HealthStatus");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFHeartrate", b =>
                {
                    b.Property<Guid>("HeartrateGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Heartrate")
                        .HasColumnType("int");

                    b.Property<DateTime>("HeartrateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("HeartrateGUID");

                    b.HasIndex("DogGUID");

                    b.ToTable("Heartrate");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFIllness", b =>
                {
                    b.Property<Guid>("IllnessGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Illness")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IllnessDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IllnessGUID");

                    b.HasIndex("DogGUID");

                    b.ToTable("Illness");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFInjury", b =>
                {
                    b.Property<Guid>("InjuryGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Injury")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InjuryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InjuryGUID");

                    b.HasIndex("DogGUID");

                    b.ToTable("Injury");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFMedication", b =>
                {
                    b.Property<Guid>("MedicationGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PerscriptionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MedicationGUID");

                    b.HasIndex("DogGUID");

                    b.ToTable("Medication");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFRole", b =>
                {
                    b.Property<Guid>("RoleGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleGUID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFTemperature", b =>
                {
                    b.Property<Guid>("TemperatureGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DogGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("TemperatureDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TemperatureGUID");

                    b.HasIndex("DogGUID");

                    b.ToTable("Temperature");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFUser", b =>
                {
                    b.Property<Guid>("UserGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("RoleGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserGUID");

                    b.HasIndex("RoleGUID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFDog", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFBehaviour", "Behaviour")
                        .WithMany()
                        .HasForeignKey("BehaviourGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuppyAPI.Database.EFmodels.EFBiometric", "Biometric")
                        .WithMany()
                        .HasForeignKey("BiometricsGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuppyAPI.Database.EFmodels.EFHealthStatus", "HealthStatus")
                        .WithMany()
                        .HasForeignKey("HealthstatusGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Behaviour");

                    b.Navigation("Biometric");

                    b.Navigation("HealthStatus");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFDogRelations", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFDog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuppyAPI.Database.EFmodels.EFUser", "User")
                        .WithMany()
                        .HasForeignKey("UserGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFGrade", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFDog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFHeartrate", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFDog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFIllness", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFDog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFInjury", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFDog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFMedication", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFDog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFTemperature", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFDog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("PuppyAPI.Database.EFmodels.EFUser", b =>
                {
                    b.HasOne("PuppyAPI.Database.EFmodels.EFRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
