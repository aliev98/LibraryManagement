using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDomain
{
    public class BookDetails
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }

        public int NumberOfCopies { get => Copies.Count; }
        public ICollection <BookCopy> Copies { get; set; } = new List <BookCopy>();
    }
}