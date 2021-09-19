using LibraryDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekUppgift.Models
{
    public class LoanIndexVm
    {
        public bool ReturnedOrNot { get; set; } = false;
        public IList<LoanDetails> loans { get; set; } = new List <LoanDetails>();
        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int avgift { get; set; }

    }
}
