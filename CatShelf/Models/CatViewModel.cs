using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatShelf.Web.Models
{
    public class CatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public bool CanBeAdopted { get; set; }
    }
}
