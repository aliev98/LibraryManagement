using BibliotekUppgift.Data;
using LibraryApplication.Interfaces;
using LibraryDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInfrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BibliotekUppgiftContext context;

        public AuthorService (BibliotekUppgiftContext context)
        {
            this.context = context;
        }

        public void AddAuthor (Author anAuthor)
        {
            this.context.Add(anAuthor);

            this.context.SaveChanges();
      //      throw new NotImplementedException();
        }

        public IList <Author> GetAllAuthors()
        {
            // Here we are NOT using .Include() so the authors books will NOT be loaded, read more about loading related data at https://docs.microsoft.com/en-us/ef/core/querying/related-data
            return context.Authors.OrderBy (x => x.Id).ToList();
        }

        public Author GetAuthor (int id)
        {
            return context.Authors.Find(id);
        }

        public void RemoveAuthor (int id)
        {
            throw new NotImplementedException();
        }
    }
}
