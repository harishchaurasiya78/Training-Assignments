using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = null!;

        [Range(1000, 9999)]
        public int PublicationYear { get; set; }

        [MaxLength(20)]
        public string? ISBN { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}