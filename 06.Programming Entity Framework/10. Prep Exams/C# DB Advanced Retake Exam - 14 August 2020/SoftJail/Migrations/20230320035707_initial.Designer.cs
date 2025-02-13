﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftJail.Data;

#nullable disable

namespace SoftJail.Migrations
{
    [DbContext(typeof(SoftJailDbContext))]
    [Migration("20230320035707_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SoftJail.Data.Models.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CellNumber")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("HasWindow")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrisonerId")
                        .HasColumnType("int");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PrisonerId");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Officer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Weapon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Officers");
                });

            modelBuilder.Entity("SoftJail.Data.Models.OfficerPrisoner", b =>
                {
                    b.Property<int>("OfficerId")
                        .HasColumnType("int");

                    b.Property<int>("PrisonerId")
                        .HasColumnType("int");

                    b.HasKey("OfficerId", "PrisonerId");

                    b.HasIndex("PrisonerId");

                    b.ToTable("OfficersPrisoners");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Prisoner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<decimal?>("Bail")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CellId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IncarcerationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.ToTable("Prisoners");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Cell", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Department", "Department")
                        .WithMany("Cells")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Mail", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Prisoner", "Prisoner")
                        .WithMany("Mails")
                        .HasForeignKey("PrisonerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prisoner");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Officer", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SoftJail.Data.Models.OfficerPrisoner", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Officer", "Officer")
                        .WithMany("OfficerPrisoners")
                        .HasForeignKey("OfficerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoftJail.Data.Models.Prisoner", "Prisoner")
                        .WithMany("PrisonerOfficers")
                        .HasForeignKey("PrisonerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Officer");

                    b.Navigation("Prisoner");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Prisoner", b =>
                {
                    b.HasOne("SoftJail.Data.Models.Cell", "Cell")
                        .WithMany("Prisoners")
                        .HasForeignKey("CellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cell");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Cell", b =>
                {
                    b.Navigation("Prisoners");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Department", b =>
                {
                    b.Navigation("Cells");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Officer", b =>
                {
                    b.Navigation("OfficerPrisoners");
                });

            modelBuilder.Entity("SoftJail.Data.Models.Prisoner", b =>
                {
                    b.Navigation("Mails");

                    b.Navigation("PrisonerOfficers");
                });
#pragma warning restore 612, 618
        }
    }
}
