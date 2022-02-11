﻿// <auto-generated />
using System;
using BasketballClub_Rest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasketballClubApi.Migrations
{
    [DbContext(typeof(BCContext))]
    partial class BCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasketballClub_Rest.Domain.Code", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Codes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = 240798
                        },
                        new
                        {
                            Id = 2,
                            Value = 897042
                        },
                        new
                        {
                            Id = 3,
                            Value = 182429
                        },
                        new
                        {
                            Id = 4,
                            Value = 292418
                        });
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Gym", b =>
                {
                    b.Property<int>("GymID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GymName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GymID");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SelectionID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("PlayerID");

                    b.HasIndex("SelectionID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Selection", b =>
                {
                    b.Property<int>("SelectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SelectionAgeID")
                        .HasColumnType("int");

                    b.Property<string>("SelectionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SelectionID");

                    b.HasIndex("SelectionAgeID");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.SelectionAge", b =>
                {
                    b.Property<int>("SelectionAgeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SelectionAgeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SelectionAgeID");

                    b.ToTable("SelectionAges");

                    b.HasData(
                        new
                        {
                            SelectionAgeID = 2,
                            SelectionAgeName = "Under 12"
                        },
                        new
                        {
                            SelectionAgeID = 3,
                            SelectionAgeName = "Under 14"
                        },
                        new
                        {
                            SelectionAgeID = 4,
                            SelectionAgeName = "Under 16"
                        },
                        new
                        {
                            SelectionAgeID = 5,
                            SelectionAgeName = "Juniors"
                        },
                        new
                        {
                            SelectionAgeID = 6,
                            SelectionAgeName = "Seniors"
                        });
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachID")
                        .HasColumnType("int");

                    b.Property<int>("GymID")
                        .HasColumnType("int");

                    b.Property<int>("SelectionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrainingEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TrainingStart")
                        .HasColumnType("datetime2");

                    b.HasKey("TrainingID");

                    b.HasIndex("CoachID");

                    b.HasIndex("GymID");

                    b.HasIndex("SelectionID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Role").HasValue("User");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Administrator", b =>
                {
                    b.HasBaseType("BasketballClub_Rest.Domain.User");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Coach", b =>
                {
                    b.HasBaseType("BasketballClub_Rest.Domain.User");

                    b.Property<int?>("SelectionID")
                        .HasColumnType("int");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasIndex("SelectionID");

                    b.HasDiscriminator().HasValue("Coach");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Player", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.Selection", "Selection")
                        .WithMany("Players")
                        .HasForeignKey("SelectionID");

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Selection", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.SelectionAge", "SelectionAge")
                        .WithMany()
                        .HasForeignKey("SelectionAgeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelectionAge");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Training", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.Coach", "Coach")
                        .WithMany("Trainings")
                        .HasForeignKey("CoachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballClub_Rest.Domain.Gym", "Gym")
                        .WithMany("Trainings")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballClub_Rest.Domain.Selection", "Selection")
                        .WithMany("Trainings")
                        .HasForeignKey("SelectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Gym");

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Coach", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.Selection", "Selection")
                        .WithMany("Coaches")
                        .HasForeignKey("SelectionID");

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Gym", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Selection", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Players");

                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Coach", b =>
                {
                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
