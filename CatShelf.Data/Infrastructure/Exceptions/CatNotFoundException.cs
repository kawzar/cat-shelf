using System;

namespace CatShelf.Data.Infrastructure.Exceptions
{
    public class CatNotFoundException : Exception
    {
        public CatNotFoundException()
        {
        }

        public CatNotFoundException(string message) : base(message)
        {
        }

        public CatNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
