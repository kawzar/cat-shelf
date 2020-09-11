using System;
using System.Collections.Generic;
using System.Text;
using CatShelf.Data.Models;
using CatShelf.Services.Models;

namespace CatShelf.Tests.Mocks
{
    public static class CatMocks
    {
        public static IEnumerable<Cat> GetCatList()
        {
            return new List<Cat>
            {
                new Cat
                {
                    Id = 1,
                    AvatarId = 1,
                    Birthday = DateTime.Now.AddDays(-15),
                    Name = "Cat1"
                },
                new Cat
                {
                    Id = 2,
                    AvatarId = 2,
                    Birthday = DateTime.Now.AddDays(-90),
                    Name = "Cat2"
                }
            };
        }
    }
}
