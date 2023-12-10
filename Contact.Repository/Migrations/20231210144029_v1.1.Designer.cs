﻿// <auto-generated />
using System;
using Contact.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Contact.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231210144029_v1.1")]
    partial class v11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Contact.Repository.Entities.ContactInfo", b =>
                {
                    b.Property<int>("IdContactInfo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdContactInfo"));

                    b.Property<int>("ContactType")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdPerson")
                        .HasColumnType("integer");

                    b.HasKey("IdContactInfo");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("Contact.Repository.Entities.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPerson"));

                    b.Property<string>("Corparete")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdPerson");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Contact.Repository.Entities.ReportLookup", b =>
                {
                    b.Property<int>("IdReportLookup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdReportLookup"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Statu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdReportLookup");

                    b.ToTable("ReportLookup");
                });
#pragma warning restore 612, 618
        }
    }
}
