using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryDomain
{
    public class LoanDetails
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        //Member stuff

        [Display (Name = "Choose member")]
        public int MemberDetailsId { get; set; } 
        public virtual MemberDetails MemberDetails { get; set; }

        //Book stuff

        [Display (Name = "ID of the book that gets loaned")]
        public int BookCopyId { get; set; }
        public virtual BookCopy BookCopy { get; set; } 

    }
}
