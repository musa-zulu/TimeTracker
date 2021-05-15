﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTracker.Persistence;

namespace TimeTracker.Persistence.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TimeTracker.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TimeSheetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("TotalBillableHours")
                        .HasColumnType("float");

                    b.Property<double>("TotalHours")
                        .HasColumnType("float");

                    b.HasKey("ProjectId");

                    b.HasIndex("TimeSheetId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeTracker.Domain.Entities.TimeSheet", b =>
                {
                    b.Property<Guid>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Submitted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TimeSheetId");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("TimeTracker.Domain.Entities.TimeSlot", b =>
                {
                    b.Property<Guid>("TimeSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DayDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HoursCaptured")
                        .HasColumnType("float");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("TimeSlotId");

                    b.HasIndex("ProjectId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("TimeTracker.Domain.Entities.Project", b =>
                {
                    b.HasOne("TimeTracker.Domain.Entities.TimeSheet", null)
                        .WithMany("Projects")
                        .HasForeignKey("TimeSheetId");
                });

            modelBuilder.Entity("TimeTracker.Domain.Entities.TimeSlot", b =>
                {
                    b.HasOne("TimeTracker.Domain.Entities.Project", "Project")
                        .WithMany("TimeSlots")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TimeTracker.Domain.Entities.Project", b =>
                {
                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("TimeTracker.Domain.Entities.TimeSheet", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}