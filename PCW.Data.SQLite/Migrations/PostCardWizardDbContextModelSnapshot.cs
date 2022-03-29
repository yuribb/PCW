﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCW.Data;

#nullable disable

namespace PCW.Data.SQLite.Migrations
{
    [DbContext(typeof(PostCardDbContext))]
    partial class PostCardWizardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("PCW.Data.Entities.PostCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EntireName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PostCards");
                });

            modelBuilder.Entity("PCW.Data.Entities.PostCardTag", b =>
                {
                    b.Property<long>("PostCardId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TagId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PostCardId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostCardId", "TagId");

                    b.HasIndex("PostCardId1");

                    b.HasIndex("TagId");

                    b.ToTable("PostCardTag");
                });

            modelBuilder.Entity("PCW.Data.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PCW.Data.Entities.PostCardTag", b =>
                {
                    b.HasOne("PCW.Data.Entities.PostCard", null)
                        .WithMany("Tags")
                        .HasForeignKey("PostCardId1");

                    b.HasOne("PCW.Data.Entities.Tag", null)
                        .WithMany("PostCards")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCW.Data.Entities.PostCard", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("PCW.Data.Entities.Tag", b =>
                {
                    b.Navigation("PostCards");
                });
#pragma warning restore 612, 618
        }
    }
}