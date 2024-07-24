﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rush00.Data;

#nullable disable

namespace rush00.Data.Migrations
{
    [DbContext(typeof(HabitDbContext))]
    partial class HabitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("rush00.Models.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Motivation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TrackingDaysNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("rush00.Models.HabitCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CurrentDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HabitId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HabitId");

                    b.ToTable("HabitChecks");
                });

            modelBuilder.Entity("rush00.Models.HabitCheck", b =>
                {
                    b.HasOne("rush00.Models.Habit", null)
                        .WithMany("DaysList")
                        .HasForeignKey("HabitId");
                });

            modelBuilder.Entity("rush00.Models.Habit", b =>
                {
                    b.Navigation("DaysList");
                });
#pragma warning restore 612, 618
        }
    }
}
