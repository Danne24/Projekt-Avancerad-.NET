﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt___Avancerad_.NET.Model;

namespace Projekt___Avancerad_.NET.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20220422002413_Initial start")]
    partial class Initialstart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeAge")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            EmployeeAge = 25,
                            EmployeeFirstName = "Daniel",
                            EmployeeGender = "Male",
                            EmployeeLastName = "Gyrén",
                            ProjectID = 2
                        },
                        new
                        {
                            EmployeeID = 2,
                            EmployeeAge = 35,
                            EmployeeFirstName = "Anas",
                            EmployeeGender = "Male",
                            EmployeeLastName = "Q",
                            ProjectID = 1
                        },
                        new
                        {
                            EmployeeID = 3,
                            EmployeeAge = 37,
                            EmployeeFirstName = "Tobias",
                            EmployeeGender = "Male",
                            EmployeeLastName = "Q",
                            ProjectID = 1
                        },
                        new
                        {
                            EmployeeID = 4,
                            EmployeeAge = 60,
                            EmployeeFirstName = "Reidar",
                            EmployeeGender = "Male",
                            EmployeeLastName = "R",
                            ProjectID = 3
                        },
                        new
                        {
                            EmployeeID = 5,
                            EmployeeAge = 40,
                            EmployeeFirstName = "Rebecca",
                            EmployeeGender = "Female",
                            EmployeeLastName = "Anderson",
                            ProjectID = 2
                        },
                        new
                        {
                            EmployeeID = 6,
                            EmployeeAge = 30,
                            EmployeeFirstName = "Sofia",
                            EmployeeGender = "Female",
                            EmployeeLastName = "Eriksson",
                            ProjectID = 2
                        });
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectID = 1,
                            ProjectName = "Software project"
                        },
                        new
                        {
                            ProjectID = 2,
                            ProjectName = "Movie project"
                        },
                        new
                        {
                            ProjectID = 3,
                            ProjectName = "Video game project"
                        });
                });

            modelBuilder.Entity("Models.TimReport", b =>
                {
                    b.Property<int>("TimReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TimReportWeek")
                        .HasColumnType("int");

                    b.Property<double>("TimReportWorkingHours")
                        .HasColumnType("float");

                    b.HasKey("TimReportID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("TimReports");

                    b.HasData(
                        new
                        {
                            TimReportID = 1,
                            EmployeeID = 1,
                            TimReportWeek = 1,
                            TimReportWorkingHours = 35.0
                        },
                        new
                        {
                            TimReportID = 2,
                            EmployeeID = 2,
                            TimReportWeek = 1,
                            TimReportWorkingHours = 25.0
                        },
                        new
                        {
                            TimReportID = 3,
                            EmployeeID = 3,
                            TimReportWeek = 1,
                            TimReportWorkingHours = 25.0
                        },
                        new
                        {
                            TimReportID = 4,
                            EmployeeID = 4,
                            TimReportWeek = 1,
                            TimReportWorkingHours = 40.0
                        },
                        new
                        {
                            TimReportID = 5,
                            EmployeeID = 5,
                            TimReportWeek = 1,
                            TimReportWorkingHours = 25.0
                        },
                        new
                        {
                            TimReportID = 6,
                            EmployeeID = 6,
                            TimReportWeek = 1,
                            TimReportWorkingHours = 30.0
                        });
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.HasOne("Models.Project", "Project")
                        .WithMany("Employee")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.TimReport", b =>
                {
                    b.HasOne("Models.Employee", "Employee")
                        .WithMany("TimReport")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
