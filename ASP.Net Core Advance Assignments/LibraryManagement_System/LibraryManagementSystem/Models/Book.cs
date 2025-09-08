using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        // Navigation
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
