using LibraryDomain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekUppgift.Models
{
    public class LoanCreateVm
    {
        //public int ID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [Display(Name = "Choose member")]
        public SelectList MemberList { get; set; }
        [Display(Name = "Choose book")]
        public SelectList BookList { get; set; }
        public int MemberID { get; set; }
        public int BookCopyId { get; set; }

        //public virtual MemberDetails aMember { get; set; }
        public int BookDetailsID { get; set; }
        public string? ErrorMessage { get; internal set; }
        //public virtual BookCopy aLoan { get; set; }
    }
}
