using LibraryDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Interfaces
{
   public interface ILoanService
   {
        void AddLoan (LoanDetails aLoan);
        int LoanDays (DateTime borrowed, DateTime? returned);
        void ReturnLoan (int id);
        IList <LoanDetails> GetAllLoans();
   }
}