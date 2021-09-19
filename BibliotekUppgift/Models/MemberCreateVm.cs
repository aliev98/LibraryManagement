using LibraryDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekUppgift.Models
{
    public class MemberCreateVm
    {
        //[Key]
        //public int ID { get; set; }

        [Required(ErrorMessage = "SSN is required")]
        [MinLength(10)]
        [MaxLength(12)]
        public string PNR { get; set; }
        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        //  [Range(0, 0)]
        //  public int loans { get; set; }
        //public IList<BookDetails> BookLoans { get; set; }
    }
}
