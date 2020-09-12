using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatShelf.Data.Models;
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

        [TestMethod]
        public void GetCatById_ShouldReturnCorrectCat()
        {
            // Arrange
            var cat = CatMocks.GetCatList().First();
            repositoryMock.Setup(x => x.GetCatById(cat.Id)).Returns(cat);
            var expected = Mapper.CatDtoFromDataModel(cat, Constants.CatService.ADOPTION_TRESHOLD_DAYS, dateProviderMock.Object);

            // Act
            var result = catService.GetCatById(cat.Id);

            // Result
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void GetAdoptableCats_ShouldReturnOnlyAdoptableCats()
        {
            // Arrange
            repositoryMock.Setup(x => x.GetAllCats()).Returns(CatMocks.GetCatList());

            // Act
            var result = catService.GetAdoptableCats();

            // Assert
            Assert.IsTrue(result.All(x => x.CanBeAdopted));
        }

        [TestMethod]
        public void AddCat_ShouldCallAddCatOnRepo()
        {
            // Arrange
            repositoryMock.Setup(x => x.AddCat(It.IsAny<Cat>())).Verifiable();

            // Act
            catService.AddCat(new Cat());

            // Assert
            repositoryMock.Verify(x => x.AddCat(It.IsAny<Cat>()), Times.Once);
            //Assert.IsTrue(true); ==> NO HACER ESTO, PORQUE MUERE UN GATITO BEBE
        }
    }
}
