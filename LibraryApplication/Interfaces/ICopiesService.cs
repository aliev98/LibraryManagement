using LibraryDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Interfaces
{
    public interface ICopiesService
    {
        public IList <BookCopy> GetAllCopies (int id);
        int GetAvailableCopy (int bookDetailsID);
    }
}
