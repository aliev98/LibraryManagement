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
    public class LoanService : ILoanService
    {
        private readonly BibliotekUppgiftContext context;
        public LoanService (BibliotekUppgiftContext _context)
        {
            context = _context;
        }
        public void AddLoan (LoanDetails aLoan)
        {
            context.Add (aLoan);

            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void ReturnLoan (int loanId)
        {
            var chosenCopy = context.Loans.Where (x => x.Id == loanId).FirstOrDefault();
            
            chosenCopy.ReturnDate = DateTime.Now;
            
            context.SaveChanges();
        }

        public int LoanDays (DateTime borrowed, DateTime? returned)
        {
            //    DateTime borrowedTime = DateTime.Parse("1212-11-11");

            int borrowedDays = 0;

            if (returned != null)
            {
                 borrowedDays = (borrowed - (DateTime)returned).Days;
            }

            else
            {
                 borrowedDays = (borrowed - DateTime.Now).Days;
            }
            
            return Math.Abs (borrowedDays);
        }

       //public void RemoveLoan (int id)
       //{
       //     //var chosenLoan = context.Loans.Where(x => x.BookCopyId == id).FirstOrDefault();
       //     //this.context.Remove(chosenLoan);

       //     //context.SaveChanges();

       //}

        public IList <LoanDetails> GetAllLoans()
        {
            return context.Loans.ToList();
        }
    }
}
