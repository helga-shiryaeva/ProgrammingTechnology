﻿// <auto-generated />
using System;
using AccountingSystem.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountingSystem.Api.Migrations
{
    [DbContext(typeof(AccountingSystemContext))]
    partial class AccountingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountingSystem.Api.Entity.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Departments","dbo");
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<int>("SalaryInfoId");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees","dbo");
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.SalaryInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccount");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("PaymentType");

                    b.Property<double>("Rate");

                    b.Property<double>("Salary");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Salaries","dbo");
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.TimeCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<double>("Time");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeCards","dbo");
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("DepartmentId");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasAnnotation("IsUnique", true);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users","dbo");
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.Employee", b =>
                {
                    b.HasOne("AccountingSystem.Api.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.SalaryInfo", b =>
                {
                    b.HasOne("AccountingSystem.Api.Entity.Employee", "Employee")
                        .WithOne("SalaryInfo")
                        .HasForeignKey("AccountingSystem.Api.Entity.SalaryInfo", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.TimeCard", b =>
                {
                    b.HasOne("AccountingSystem.Api.Entity.Employee", "Employee")
                        .WithMany("TimeCards")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountingSystem.Api.Entity.User", b =>
                {
                    b.HasOne("AccountingSystem.Api.Entity.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
