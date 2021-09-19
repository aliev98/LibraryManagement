using BibliotekUppgift.Data;
using LibraryApplication.Interfaces;
using LibraryDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInfrastructure.Services
{
    public class BookService : IBookkService
    {
        private readonly BibliotekUppgiftContext context;

        public BookService (BibliotekUppgiftContext context)
        {
            this.context = context;
        }

        public void RemoveBook (int id)
        {
            var chosenCopy = context.bookCopies.Where (x => x.BookDetailsId == id).FirstOrDefault();

            this.context.Remove (chosenCopy);

            context.SaveChanges();
        }

        public void AddBook (BookDetails book)
        {
            this.context.Add(book);

            context.SaveChanges();
        }

        public void ReturnBook (int id)
        {
            var chosenCopy = context.bookCopies.Where (x => x.BookDetailsId == id).FirstOrDefault();

            this.context.Add (chosenCopy);

            context.SaveChanges();
        }

        public BookDetails GetBook (int id)
        { 
            return context.BookDetails.Find(id);
        }

        public bool doesBookExist (int id)
        {
            return context.bookCopies.Any (x => x.BookDetailsId == id);
        }

        public ICollection <BookDetails> GetAllBooks()
        {
            // Here we are using .Include() to eager load the author, read more about loading related data at https://docs.microsoft.com/en-us/ef/core/querying/related-data
            return context.BookDetails.Include(x => x.Author).Include(x => x.Copies).OrderBy(x => x.Title).ToList();
        }

        public List <BookDetails> AllBoksFromAuthor(int? AuthorId)
        {
            return context.BookDetails.Where(x => x.AuthorId == AuthorId).ToList();
            //var author = authorService.Where(x => x.Id == AuthorId).Include(x => x.Books).FirstOrDefaultAsync();
        }

        public void UpdateBookDetails (BookDetails book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookDetails (int id, BookDetails book)
        {
            throw new NotImplementedException();
        }
    }
}
