using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryDomain;

namespace BibliotekUppgift.Models
{
    public class BookCreateVm
    {
    //    public int ID { get; set; }

        [Required]
        public string ISBN { get; set; }
        [Display(Name = "Titel")]
        [MaxLength(7)]

        public string Title { get; set; }
        [Display(Name = "Författare")]
        public SelectList AuthorList { get; set; }

       // public LibraryDomain.Author Author { get; set; }
        public int AuthorID { get; set; }

        [Display(Name ="Beskrivning på boken")]
        public string Description { get; set; }

        [Display(Name = "Antal kopior av boken")]
        public int NumberOfCopies { get; set; } = 1;

       // public int Copies { get; set; }
    }
}