using System;
using System.Collections.Generic;
using System.Linq;
using CatShelf.Data.Models;
using CatShelf.Data.Repositories.Interfaces;
using CatShelf.Services.Interfaces;
using CatShelf.Services.Models;

namespace CatShelf.Services.Implementation
{
    public class CatService : ICatService
    {
        private readonly ICatRepository repository;
        private const int ADOPTION_THRESHOLD_DAYS = 45;

        public CatService(ICatRepository repository)
        {
            this.repository = repository;
        }

        public void AddCat(Cat cat)
        {
            repository.AddCat(cat);
        }

        public IEnumerable<CatDto> GetAllCats()
        {
            return repository.GetAllCats().Select(CatDtoFromDataModel);
        }

        public IEnumerable<CatDto> GetAdoptableCats()
        {
            return repository.GetAllCats().Select(CatDtoFromDataModel).Where(cat => cat.CanBeAdopted);
        }

        public CatDto GetCatById(int id)
        {
            return CatDtoFromDataModel(repository.GetCatById(id));
        }

        public void UpdateCat(Cat cat)
        {
            repository.UpdateCat(cat);
        }

        private CatDto CatDtoFromDataModel(Cat dataModel)
        {
            DateTime readyToAdoptDate = DateTime.Now.AddDays(-ADOPTION_THRESHOLD_DAYS);
            return new CatDto
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                Birthday = dataModel.Birthday,
                CanBeAdopted = dataModel.Birthday.Date >= readyToAdoptDate,
                Avatar = (CatAvatarEnum)dataModel.AvatarId
            };
        }
    }
}
