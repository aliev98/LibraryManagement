using LibraryDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Interfaces
{
   public interface IMemberService
   {
        IList <MemberDetails> GetAllMembers();
        void AddMember(MemberDetails aMember);
        bool doesMemberExist(int id);
   }
}
