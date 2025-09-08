using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Book> Books { get; set; }
    }
}


