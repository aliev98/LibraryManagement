using BibliotekUppgift.Data;
using LibraryApplication.Interfaces;
using LibraryDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInfrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly BibliotekUppgiftContext context;

        public MemberService (BibliotekUppgiftContext context)
        {
            this.context = context;
        }

        public bool doesMemberExist (int id)
        {
            return context.bookCopies.Any (x => x.BookDetailsId == id);
        }

        public void AddMember (MemberDetails aMember)
        {
            context.Add(aMember);
            context.SaveChanges();

            //throw new NotImplementedException();
        }       

        public IList <MemberDetails> GetAllMembers()
        {
            return context.MemberDetails.OrderBy (x => x.Name).ToList();
            //throw new NotImplementedException();
        }
    }
}
