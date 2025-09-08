using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCoreLibraryApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}