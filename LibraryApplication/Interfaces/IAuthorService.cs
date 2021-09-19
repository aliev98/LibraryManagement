using System;
using System.Collections.Generic;
using System.Text;
using LibraryDomain;

namespace LibraryApplication.Interfaces
{
    public interface IAuthorService
    {
        IList<Author> GetAllAuthors();
        void AddAuthor(Author anAuthor);
        Author GetAuthor(int id);
        void RemoveAuthor(int id);
    }
}