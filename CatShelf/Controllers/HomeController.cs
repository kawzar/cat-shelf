using System.Diagnostics;
using CatShelf.Models;
using CatShelf.Services.Interfaces;
using CatShelf.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatShelf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatService catService;

        public HomeController(ICatService catService)
        {
            this.catService = catService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AllCats()
        {
            ShelfViewModel viewModel = new ShelfViewModel { Cats = catService.GetAllCats() };
            return View("Cats", viewModel);
        }

        public IActionResult AdoptableCats()
        {
            ShelfViewModel viewModel = new ShelfViewModel { Cats = catService.GetAdoptableCats(), OnlyAdoptable = true };
            return View("Cats", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
