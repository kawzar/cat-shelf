using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatShelf.Services.Models;

namespace CatShelf.Web.Models
{
    public class ShelfViewModel
    {
        public IEnumerable<CatDto> Cats { get; set; }
        public bool OnlyAdoptable { get; set; }
    }
}
