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
    public class CopiesService : ICopiesService
    {
        private readonly BibliotekUppgiftContext context;  

        public CopiesService (BibliotekUppgiftContext context)
        {
            this.context = context;
        }

        public IList <BookCopy> GetAllCopies (int id)
        {
            return context.bookCopies.Include (x => x.BookDetails).Where(x => x.BookDetailsId == id).OrderBy(x => x.BookDetails).ToList();
        }

        public int GetAvailableCopy (int bookDetailsID)
        {

            var BookCopies = context.bookCopies.Include (x => x.BookDetails).Where(x => x.BookDetailsId == bookDetailsID).ToList();

            var nonAvailablebookCopies = context.Loans.Where (x => x.ReturnDate == null).Select(x => x.BookCopyId).ToList();

            var availableCopy = BookCopies.Where (x => !nonAvailablebookCopies.Contains(x.Id)).FirstOrDefault();

            return availableCopy.Id;

           // throw new NotImplementedException();
        }
    }
}