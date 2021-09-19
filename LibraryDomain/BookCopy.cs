using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryDomain
{
    public class BookCopy
    {
        public int Id { get; set; }
        public int BookDetailsId { get; set; }
        public BookDetails BookDetails { get; set; }
        //public int? LoanId { get; set; }
        //public List<LoanDetails> Loans { get; set; }
    }

}