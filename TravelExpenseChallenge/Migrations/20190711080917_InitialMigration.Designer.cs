﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelExpenseChallenge.Models;

namespace TravelExpenseChallenge.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190711080917_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelExpenseChallenge.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<int?>("SupervisorId");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Designation = "Software Engineer",
                            Email = "awais.i@outlook.com",
                            FirstName = "Awais",
                            IsActive = true,
                            LastName = "Ilyas",
                            PhoneNumber = "+971528565160",
                            SupervisorId = 3
                        },
                        new
                        {
                            Id = 2,
                            Designation = "IT Engineer",
                            Email = "jklein@domain.com",
                            FirstName = "Jonas",
                            IsActive = true,
                            LastName = "Klein",
                            PhoneNumber = "+12546987120",
                            SupervisorId = 4
                        },
                        new
                        {
                            Id = 3,
                            Designation = "Team Leader",
                            Email = "jsmith@domain.com",
                            FirstName = "John",
                            IsActive = true,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 4,
                            Designation = "Team Leader",
                            Email = "jdoe@domain.com",
                            FirstName = "John",
                            IsActive = true,
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 5,
                            Designation = "Finance Manager",
                            Email = "karnold@domain.com",
                            FirstName = "Kevin",
                            IsActive = true,
                            LastName = "Arnold"
                        });
                });

            modelBuilder.Entity("TravelExpenseChallenge.Models.TravelExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApprovedById");

                    b.Property<DateTime?>("ApprovedDate");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("PhotoPath");

                    b.Property<int>("Status");

                    b.Property<DateTime>("SubmittedDate");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TravelExpenses");
                });

            modelBuilder.Entity("TravelExpenseChallenge.Models.TravelExpense", b =>
                {
                    b.HasOne("TravelExpenseChallenge.Models.Employee", "ApprovedBy")
                        .WithMany()
                        .HasForeignKey("ApprovedById");

                    b.HasOne("TravelExpenseChallenge.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
