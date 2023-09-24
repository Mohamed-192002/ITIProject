﻿// <auto-generated />
using ITIProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITIProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230924142123_AddTables_V1")]
    partial class AddTables_V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITIProject.Models.Emp_Project", b =>
                {
                    b.Property<int>("EMP_Id")
                        .HasColumnType("int");

                    b.Property<int>("Project_Id")
                        .HasColumnType("int");

                    b.Property<double>("WorkingHours")
                        .HasColumnType("float");

                    b.HasKey("EMP_Id", "Project_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Emp_Projects");
                });

            modelBuilder.Entity("ITIProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Office_id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Office_id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ITIProject.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("ITIProject.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ITIProject.Models.Emp_Project", b =>
                {
                    b.HasOne("ITIProject.Models.Employee", "employees")
                        .WithMany("Emp_Projects")
                        .HasForeignKey("EMP_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITIProject.Models.Project", "Projects")
                        .WithMany("Emp_Projects")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("ITIProject.Models.Employee", b =>
                {
                    b.HasOne("ITIProject.Models.Office", "office")
                        .WithMany("employees")
                        .HasForeignKey("Office_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("office");
                });

            modelBuilder.Entity("ITIProject.Models.Employee", b =>
                {
                    b.Navigation("Emp_Projects");
                });

            modelBuilder.Entity("ITIProject.Models.Office", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("ITIProject.Models.Project", b =>
                {
                    b.Navigation("Emp_Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
