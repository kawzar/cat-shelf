using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatShelf.Data.Providers;
using CatShelf.Data.Repositories.Interfaces;
using CatShelf.Services.Implementation;
using CatShelf.Services.Interfaces;
using CatShelf.Services.Utils;
using CatShelf.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CatShelf.Tests
{
    [TestClass]
    public class CatServiceTests
    {
        private readonly Mock<ICatRepository> repositoryMock = new Mock<ICatRepository>();
        private readonly Mock<IDateProvider> dateProviderMock = new Mock<IDateProvider>();
        private ICatService catService;

        [TestInitialize]
        public void Initialize()
        {
            catService = new CatService(repositoryMock.Object, dateProviderMock.Object);
            dateProviderMock.Setup(x => x.GetCurrentDate()).Returns(new DateTime(2020, 8, 30));
        }

        [TestMethod]
        public void GetAllCats_ShouldReturnAllCats()
        {
            // Arrange
            var listMock = CatMocks.GetCatList();
            var expected = listMock.Select(x => Mapper.CatDtoFromDataModel(x, Constants.CatService.ADOPTION_TRESHOLD_DAYS, dateProviderMock.Object));
            repositoryMock.Setup(x => x.GetAllCats()).Returns(listMock);

            // Act
            var result = catService.GetAllCats();

            // Assert
            CollectionAssert.AreEqual(expected.Select(x => x.Id).ToList(), result.Select(x => x.Id).ToList());
        }
    }
}
