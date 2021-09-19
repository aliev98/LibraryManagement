﻿// <auto-generated />
using System;
using BibliotekUppgift.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotekUppgift.Migrations
{
    [DbContext(typeof(BibliotekUppgiftContext))]
    [Migration("20200206200118_membermigration")]
    partial class membermigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryDomain.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("LibraryDomain.BookCopy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DetailsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DetailsID");

                    b.ToTable("BookCopy");
                });

            modelBuilder.Entity("LibraryDomain.BookDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorID1")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID1");

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("LibraryDomain.MemberDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pnr")
                        .HasColumnType("int");

                    b.Property<int>("loans")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("MemberDetails");
                });

            modelBuilder.Entity("LibraryDomain.BookCopy", b =>
                {
                    b.HasOne("LibraryDomain.BookDetails", "Details")
                        .WithMany("Copes")
                        .HasForeignKey("DetailsID");
                });

            modelBuilder.Entity("LibraryDomain.BookDetails", b =>
                {
                    b.HasOne("LibraryDomain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID1");
                });
#pragma warning restore 612, 618
        }
    }
}