﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SD_Company.Models;

namespace SD_Company.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SD_Company.Models.Department", b =>
                {
                    b.Property<int>("DeptNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("DeptNo");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SD_Company.Models.Employee", b =>
                {
                    b.Property<int>("EmpNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("EmpNo");

                    b.HasIndex("DeptNo");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SD_Company.Models.Project", b =>
                {
                    b.Property<int>("ProjectNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProjectNo");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SD_Company.Models.Works_on", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int");

                    b.Property<int>("ProjectNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Enter_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("EmpNo", "ProjectNo");

                    b.HasIndex("ProjectNo");

                    b.ToTable("Works_on");
                });

            modelBuilder.Entity("SD_Company.Models.Employee", b =>
                {
                    b.HasOne("SD_Company.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptNo");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SD_Company.Models.Works_on", b =>
                {
                    b.HasOne("SD_Company.Models.Employee", "Employee")
                        .WithMany("Works_Ons")
                        .HasForeignKey("EmpNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SD_Company.Models.Project", "Project")
                        .WithMany("Works_Ons")
                        .HasForeignKey("ProjectNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SD_Company.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("SD_Company.Models.Employee", b =>
                {
                    b.Navigation("Works_Ons");
                });

            modelBuilder.Entity("SD_Company.Models.Project", b =>
                {
                    b.Navigation("Works_Ons");
                });
#pragma warning restore 612, 618
        }
    }
}