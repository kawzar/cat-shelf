using System.Collections.Generic;
using CatShelf.Data.Models;

namespace CatShelf.Data.Repositories.Interfaces
{
    public interface ICatRepository
    {
        void AddCat(Cat cat);
        void UpdateCat(Cat cat);
        IEnumerable<Cat> GetAllCats();
        Cat GetCatById(int id);
    }
}
