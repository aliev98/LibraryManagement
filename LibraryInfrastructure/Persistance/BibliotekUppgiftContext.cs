using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryDomain;

namespace BibliotekUppgift.Data
{
    public class BibliotekUppgiftContext : DbContext
    {
        public BibliotekUppgiftContext (DbContextOptions<BibliotekUppgiftContext> options) : base(options)
        {

        }

        public DbSet <BookDetails> BookDetails { get; set; }
        public DbSet <BookCopy> bookCopies { get; set; }
        public DbSet <Author> Authors { get; set; }
        public DbSet <MemberDetails> MemberDetails { get; set; }
        public DbSet <LoanDetails> Loans { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            ConfigureBookDetails(modelBuilder);
            
            ConfigureAuthor(modelBuilder);

            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedDatabase (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity <Author>().HasData(
                new Author { Id = 1, Name = "William Shakespeare" },
                new Author { Id = 2, Name = "Villiam Skakspjut" },
                new Author { Id = 3, Name = "Robert C. Martin" }
                );

            modelBuilder.Entity <BookDetails>().HasData(
                new BookDetails { Id = 1, AuthorId = 1, Title = "Hamlet", ISBN = "1472518381", Description = "Arguably Shakespeare's greatest tragedy" },
                //       new BookDetails { Id = 4, AuthorId = 1, Title = "New book", ISBN = "1472518381", Description = "Just testing", NumberOfCopies = 1 },
                new BookDetails { Id = 2, AuthorId = 1, Title = "King Lear", ISBN = "9780141012292", Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all." },
                new BookDetails { Id = 3, AuthorId = 2, Title = "Othello", ISBN = "1853260185", Description = "An intense drama of love, deception, jealousy and destruction." }
                );

            modelBuilder.Entity <MemberDetails>().HasData(
                new MemberDetails { Id = 1, Name = "Sami", PNR = "847582-7382" }
                );

            modelBuilder.Entity <BookCopy>().HasData(
                new BookCopy { Id = 1, BookDetailsId = 1 },
                new BookCopy { Id = 2, BookDetailsId = 2 },
                new BookCopy { Id = 3, BookDetailsId = 3 }
                );

            //modelBuilder.Entity <LoanDetails>().HasData(
            //    new LoanDetails { Id = 1, LoanDate = DateTime.Parse("2020/01/01"), ReturnDate = DateTime.Parse("2020/01/01"), MemberDetailsId = 1, BookCopyId = 1 }
            //    );
        }

        private static void ConfigureAuthor (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(55);
        }

        private static void ConfigureBookDetails (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity <BookDetails>().HasKey(x => x.Id);

            modelBuilder.Entity <BookDetails>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<BookDetails>().HasMany(x => x.Copies).WithOne(x => x.BookDetails)
                .HasForeignKey (k => k.BookDetailsId);
        }
    }
}