namespace BookStoreAPI.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public string? ISBN { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateBookDTO
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int PublicationYear { get; set; }
        public string? ISBN { get; set; }
        public decimal Price { get; set; }
    }
}