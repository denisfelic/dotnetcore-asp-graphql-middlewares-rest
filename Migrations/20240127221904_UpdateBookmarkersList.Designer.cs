﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnetcore_asp.Core.Database;

#nullable disable

namespace dotnetcore_asp.Migrations
{
    [DbContext(typeof(MyAppDbContext))]
    [Migration("20240127221904_UpdateBookmarkersList")]
    partial class UpdateBookmarkersList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("dotnetcore_asp.Core.Models.Bookmarker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookmarkerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookmarkerId");

                    b.ToTable("Bookmarkers");
                });

            modelBuilder.Entity("dotnetcore_asp.Core.Models.Bookmarker", b =>
                {
                    b.HasOne("dotnetcore_asp.Core.Models.Bookmarker", null)
                        .WithMany("Bookmarkers")
                        .HasForeignKey("BookmarkerId");
                });

            modelBuilder.Entity("dotnetcore_asp.Core.Models.Bookmarker", b =>
                {
                    b.Navigation("Bookmarkers");
                });
#pragma warning restore 612, 618
        }
    }
}
