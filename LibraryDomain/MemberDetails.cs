using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDomain
{
    public class MemberDetails
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "SSN is required")]
        [MinLength(10)]
        [MaxLength(12)]
        public string PNR { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        //  [Range(0, 0)]
        //  public int loans { get; set; }
        public IList <LoanDetails> Loans { get; set; } = new List<LoanDetails>();
    }
}