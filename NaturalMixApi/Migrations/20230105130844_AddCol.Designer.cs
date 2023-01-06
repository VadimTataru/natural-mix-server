﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NaturalMixApi.DB;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NaturalMixApi.Migrations
{
    [DbContext(typeof(NaturalMixDbContext))]
    [Migration("20230105130844_AddCol")]
    partial class AddCol
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NaturalMixApi.Models.ComponentItem", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<float?>("Naturalness")
                        .HasColumnType("real");

                    b.Property<string>("Origin")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("ComponentItems");
                });
#pragma warning restore 612, 618
        }
    }
}