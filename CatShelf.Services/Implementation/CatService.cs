using System;
using System.Collections.Generic;
using System.Linq;
using CatShelf.Data.Models;
using CatShelf.Data.Providers;
using CatShelf.Data.Repositories.Interfaces;
using CatShelf.Services.Interfaces;
using CatShelf.Services.Models;
using CatShelf.Services.Utils;

namespace CatShelf.Services.Implementation
{
    public class CatService : ICatService
    {
        private readonly ICatRepository repository;
        private readonly IDateProvider dateProvider;

        public CatService(ICatRepository repository, IDateProvider dateProvider)
        {
            this.repository = repository;
            this.dateProvider = dateProvider;
        }

        public void AddCat(Cat cat)
        {
            repository.AddCat(cat);
        }

        public IEnumerable<CatDto> GetAllCats()
        {
            return repository.GetAllCats().Select(cat => Mapper.CatDtoFromDataModel(cat, Constants.CatService.ADOPTION_TRESHOLD_DAYS, dateProvider));
        }

        public IEnumerable<CatDto> GetAdoptableCats()
        {
            return repository.GetAllCats().Select(cat => Mapper.CatDtoFromDataModel(cat, Constants.CatService.ADOPTION_TRESHOLD_DAYS, dateProvider)).Where(cat => cat.CanBeAdopted);
        }

        public CatDto GetCatById(int id)
        {
            return Mapper.CatDtoFromDataModel(repository.GetCatById(id), Constants.CatService.ADOPTION_TRESHOLD_DAYS, dateProvider);
        }

        public void UpdateCat(Cat cat)
        {
            repository.UpdateCat(cat);
        }
    }
}
