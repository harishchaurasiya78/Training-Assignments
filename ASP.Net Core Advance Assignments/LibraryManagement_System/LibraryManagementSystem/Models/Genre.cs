using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Book> Books { get; set; }
    }
}

