﻿// <auto-generated />
using System;
using Dlbb.Track.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dlbb.Track.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230619142527_init_new")]
    partial class init_new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.GlobalActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("GlobalActivities");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.GlobalSessions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uuid");

                    b.Property<TimeOnly?>("Duration")
                        .HasColumnType("time without time zone");

                    b.Property<Guid>("GlobalActivityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("GlobalActivityId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("GlobalSessions");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uuid");

                    b.Property<TimeOnly?>("Duration")
                        .HasColumnType("time without time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.Activity", b =>
                {
                    b.HasOne("Dlbb.Track.Domain.Entities.AppUser", "AppUser")
                        .WithMany("Activities")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.GlobalSessions", b =>
                {
                    b.HasOne("Dlbb.Track.Domain.Entities.AppUser", "AppUser")
                        .WithMany("GlobalSessions")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Dlbb.Track.Domain.Entities.GlobalActivity", "GlobalActivity")
                        .WithMany("GlobalSessions")
                        .HasForeignKey("GlobalActivityId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("GlobalActivity");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.Session", b =>
                {
                    b.HasOne("Dlbb.Track.Domain.Entities.Activity", "Activity")
                        .WithMany("Sessions")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.Activity", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("GlobalSessions");
                });

            modelBuilder.Entity("Dlbb.Track.Domain.Entities.GlobalActivity", b =>
                {
                    b.Navigation("GlobalSessions");
                });
#pragma warning restore 612, 618
        }
    }
}