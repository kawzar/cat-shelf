using System;

namespace CatShelf.Data.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public int AvatarId { get; set; }
    }
}
