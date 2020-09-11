using System.Collections.Generic;
using CatShelf.Data.Models;
using CatShelf.Services.Models;

namespace CatShelf.Services.Interfaces
{
    public interface ICatService
    {
        void AddCat(Cat cat);
        void UpdateCat(Cat cat);
        IEnumerable<CatDto> GetAllCats();
        IEnumerable<CatDto> GetAdoptableCats();
        CatDto GetCatById(int id);
    }
}
