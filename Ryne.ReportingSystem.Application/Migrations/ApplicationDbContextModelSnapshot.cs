﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ryne.ReportingSystem.Application;

#nullable disable

namespace Ryne.ReportingSystem.Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Defectoscope", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ProductionYear")
                        .HasColumnType("bigint");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeOfDefectoscopeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("TypeOfDefectoscopeId");

                    b.ToTable("Defectoscopes", (string)null);
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Engineer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Engineers", (string)null);
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Repair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCalibration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfLastRepair")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfReceipt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRelease")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DefectoscopeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EngineerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeOfRepair")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DefectoscopeId");

                    b.HasIndex("EngineerID");

                    b.ToTable("Repairs", (string)null);
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.TypeOfDefectoscope", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfDefectoscopes");
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Defectoscope", b =>
                {
                    b.HasOne("Ryne.ReportingSystem.Entity.Organization", "Organization")
                        .WithMany("Defectoscopes")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ryne.ReportingSystem.Entity.TypeOfDefectoscope", "TypeOfDefectoscope")
                        .WithMany("Defectoscopes")
                        .HasForeignKey("TypeOfDefectoscopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("TypeOfDefectoscope");
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Repair", b =>
                {
                    b.HasOne("Ryne.ReportingSystem.Entity.Defectoscope", "Defectoscope")
                        .WithMany("Repairs")
                        .HasForeignKey("DefectoscopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ryne.ReportingSystem.Entity.Engineer", "Engineer")
                        .WithMany("Repairs")
                        .HasForeignKey("EngineerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defectoscope");

                    b.Navigation("Engineer");
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Defectoscope", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Engineer", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.Organization", b =>
                {
                    b.Navigation("Defectoscopes");
                });

            modelBuilder.Entity("Ryne.ReportingSystem.Entity.TypeOfDefectoscope", b =>
                {
                    b.Navigation("Defectoscopes");
                });
#pragma warning restore 612, 618
        }
    }
}
