using System;
using System.Collections.Generic;
using System.Text;
using LibraryDomain;

namespace LibraryApplication.Interfaces
{
   public interface IBookkService
   {
        void AddBook (BookDetails aBook);
        void UpdateBookDetails (BookDetails aBook);
        void UpdateBookDetails (int ID, BookDetails aBook);
        void RemoveBook(int id);
        bool doesBookExist(int id);

        void ReturnBook (int id);
        /// <summary>
        /// This function gives us all the books from the database
        /// </summary>
        /// <returns>
        /// List of books
        /// </returns>
        ICollection <BookDetails> GetAllBooks();
   }
}