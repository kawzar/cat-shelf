using System;
using System.Collections.Generic;
using System.Text;
using CatShelf.Data.Models;
using CatShelf.Data.Providers;
using CatShelf.Services.Models;

namespace CatShelf.Services.Utils
{
    public static class Mapper
    {
        public static CatDto CatDtoFromDataModel(Cat dataModel, int adoptionThresholdDays, IDateProvider dateProvider)
        {
            DateTime readyToAdoptDate = dateProvider.GetCurrentDate().AddDays(-adoptionThresholdDays);
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
