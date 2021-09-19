using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDomain
{
   public class Author
   {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList <BookDetails> Books { get; set; } // all books from an author
   }
}
