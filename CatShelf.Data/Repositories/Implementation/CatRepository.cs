using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CatShelf.Data.Infrastructure.Exceptions;
using CatShelf.Data.Models;
using CatShelf.Data.Repositories.Interfaces;

namespace CatShelf.Data.Repositories.Implementation
{
    public class CatRepository : ICatRepository
    {
        private readonly ConcurrentDictionary<int, Cat> cats;

        public CatRepository()
        {
            cats = new ConcurrentDictionary<int, Cat>();
            cats.TryAdd(1, new Cat { Id = 1, Birthday = new DateTime(2019, 12, 17), Name = "Ursula", AvatarId = 1 });
            cats.TryAdd(2, new Cat { Id = 2, Birthday = new DateTime(2020, 3, 24), Name = "Zenobia", AvatarId = 2 });
            cats.TryAdd(3, new Cat { Id = 3, Birthday = new DateTime(2020, 8, 17), Name = "Hatty", AvatarId = 3 });
        }

        public void AddCat(Cat cat)
        {
            cat.Id = cats.Keys.Max() + 1;
            cats.TryAdd(cat.Id, cat);
        }

        public void UpdateCat(Cat cat)
        {
            Cat toUpdate;
            if (cats.TryGetValue(cat.Id, out toUpdate))
            {
                cats.TryUpdate(cat.Id, cat, toUpdate);
            }
            else
            {
                throw new CatNotFoundException("The provided cat does not exist in the database.");
            }
        }

        public IEnumerable<Cat> GetAllCats()
        {
            return cats.Values;
        }

        public Cat GetCatById(int id)
        {
            Cat result;
            if (!cats.TryGetValue(id, out result))
            {
                throw new CatNotFoundException("The provided id does not exist in the database.");
            }
            else
            {
                return result;
            }
        }
    }
}
