namespace BookStoreAPI.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
    }

    public class AuthorWithBooksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public List<BookDTO> Books { get; set; } = new List<BookDTO>();
    }

    public class CreateAuthorDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}