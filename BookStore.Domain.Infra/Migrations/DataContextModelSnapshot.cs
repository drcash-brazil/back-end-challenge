﻿// <auto-generated />
using System;
using BookStore.Domain.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Domain.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookStore.Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.HasIndex("GenreId")
                        .IsUnique();

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Book", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Author", "Author")
                        .WithOne("Book")
                        .HasForeignKey("BookStore.Domain.Entities.Book", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Domain.Entities.Genre", "Genre")
                        .WithOne("Book")
                        .HasForeignKey("BookStore.Domain.Entities.Book", "GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Author", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Genre", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
