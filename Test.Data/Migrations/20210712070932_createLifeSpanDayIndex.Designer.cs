﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Test.Data;

namespace Test.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210712070932_createLifeSpanDayIndex")]
    partial class createLifeSpanDayIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Test.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastActivityDate")
                        .HasColumnType("Date");

                    b.Property<int>("LifeSpanDays")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("integer")
                        .HasComputedColumnSql("\"LastActivityDate\" - \"RegistrationDate\"", true);

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("LifeSpanDays");

                    b.HasIndex("RegistrationDate");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
