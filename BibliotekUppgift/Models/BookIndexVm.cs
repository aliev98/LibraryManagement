using LibraryDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekUppgift.Models
{
    public class BookIndexVm
    {
        public ICollection <BookDetails> books { get; set; } = new List <BookDetails>();
    }
}