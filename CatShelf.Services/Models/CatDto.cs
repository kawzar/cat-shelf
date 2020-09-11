using System;
using CatShelf.Data.Models;

namespace CatShelf.Services.Models
{
    public class CatDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public bool CanBeAdopted { get; set; }
        public CatAvatarEnum Avatar { get; set; }
    }
}
