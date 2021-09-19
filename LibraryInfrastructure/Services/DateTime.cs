using LibraryApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryInfrastructure.Services
{
    class DateTimeService: IDateTimeService
    {
        public DateTime Now { get => DateTime.Now; }
    }
}
