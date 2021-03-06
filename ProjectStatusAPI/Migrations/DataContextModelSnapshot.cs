﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectStatusAPI.Storage;

namespace ProjectStatusAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProjectStatusAPI.Data.Projects.ProjectDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectStatusAPI.Data.TimeSeries.TimeSeriesDataPointDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("ProjectDtoId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectDtoId");

                    b.ToTable("DataPoints");
                });

            modelBuilder.Entity("ProjectStatusAPI.Data.TimeSeries.TimeSeriesDataPointDto", b =>
                {
                    b.HasOne("ProjectStatusAPI.Data.Projects.ProjectDto", "ProjectDto")
                        .WithMany("DataPoints")
                        .HasForeignKey("ProjectDtoId");

                    b.Navigation("ProjectDto");
                });

            modelBuilder.Entity("ProjectStatusAPI.Data.Projects.ProjectDto", b =>
                {
                    b.Navigation("DataPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
