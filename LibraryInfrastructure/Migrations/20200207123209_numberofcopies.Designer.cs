﻿// <auto-generated />
using BibliotekUppgift.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotekUppgift.Migrations
{
    [DbContext(typeof(BibliotekUppgiftContext))]
    [Migration("20200207123209_numberofcopies")]
    partial class numberofcopies
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
                        .HasColumnType("nvarchar(55)")
                        .HasMaxLength(55);

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Villiam Skakspjut"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Robert C. Martin"
                        });
                });

            modelBuilder.Entity("LibraryDomain.BookCopy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookDetailsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BookDetailsID");

                    b.ToTable("BookCopy");
                });

            modelBuilder.Entity("LibraryDomain.BookDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookDetails");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 1,
                            Description = "Arguably Shakespeare's greatest tragedy",
                            ISBN = "1472518381",
                            NumberOfCopies = 0,
                            Title = "Hamlet"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 1,
                            Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.",
                            ISBN = "9780141012292",
                            NumberOfCopies = 0,
                            Title = "King Lear"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 2,
                            Description = "An intense drama of love, deception, jealousy and destruction.",
                            ISBN = "1853260185",
                            NumberOfCopies = 0,
                            Title = "Othello"
                        });
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
                        .WithMany("Copies")
                        .HasForeignKey("BookDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryDomain.BookDetails", b =>
                {
                    b.HasOne("LibraryDomain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
