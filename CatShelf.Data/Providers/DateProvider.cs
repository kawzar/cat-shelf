using System;
using System.Collections.Generic;
using System.Text;

namespace CatShelf.Data.Providers
{
    public class DateProvider : IDateProvider
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
