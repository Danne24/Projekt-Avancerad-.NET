using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt___Avancerad_.NET.Model
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimReport> TimReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 1, EmployeeFirstName = "Daniel", EmployeeLastName = "Gyrén", EmployeeGender = "Male", EmployeeAge = 25, ProjectID = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 2, EmployeeFirstName = "Anas", EmployeeLastName = "Q", EmployeeGender = "Male", EmployeeAge = 35, ProjectID = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 3, EmployeeFirstName = "Tobias", EmployeeLastName = "Q", EmployeeGender = "Male", EmployeeAge = 37, ProjectID = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 4, EmployeeFirstName = "Reidar", EmployeeLastName = "R", EmployeeGender = "Male", EmployeeAge = 60, ProjectID = 3 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 5, EmployeeFirstName = "Rebecca", EmployeeLastName = "Anderson", EmployeeGender = "Female", EmployeeAge = 40, ProjectID = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 6, EmployeeFirstName = "Sofia", EmployeeLastName = "Eriksson", EmployeeGender = "Female", EmployeeAge = 30, ProjectID = 2 });

            modelBuilder.Entity<Project>().HasData(new Project { ProjectID = 1, ProjectName = "Software project" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectID = 2, ProjectName = "Movie project" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectID = 3, ProjectName = "Video game project" });

            modelBuilder.Entity<TimReport>().HasData(new TimReport { TimReportID = 1, TimReportWeek = 1, TimReportWorkingHours = 35, EmployeeID = 1 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { TimReportID = 2, TimReportWeek = 1, TimReportWorkingHours = 25, EmployeeID = 2 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { TimReportID = 3, TimReportWeek = 1, TimReportWorkingHours = 25, EmployeeID = 3 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { TimReportID = 4, TimReportWeek = 1, TimReportWorkingHours = 40, EmployeeID = 4 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { TimReportID = 5, TimReportWeek = 1, TimReportWorkingHours = 25, EmployeeID = 5 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { TimReportID = 6, TimReportWeek = 1, TimReportWorkingHours = 30, EmployeeID = 6 });
        }
    }
}
