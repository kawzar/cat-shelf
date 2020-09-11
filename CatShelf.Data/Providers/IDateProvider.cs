using System;
using System.Collections.Generic;
using System.Text;

namespace CatShelf.Data.Providers
{
    public interface IDateProvider
    {
        DateTime GetCurrentDate();
    }
}
