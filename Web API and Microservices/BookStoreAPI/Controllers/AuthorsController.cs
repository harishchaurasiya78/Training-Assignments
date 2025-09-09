using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using BookStoreAPI.DTOs;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorsController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authors = await _context.Authors
                .Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Email = a.Email
                })
                .ToListAsync();

            return authors;
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            var author = await _context.Authors
                .Where(a => a.Id == id)
                .Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Email = a.Email
                })
                .FirstOrDefaultAsync();

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // GET: api/authors/5/books
        [HttpGet("{authorId}/books")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooksByAuthor(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author == null)
            {
                return NotFound("Author not found");
            }

            var books = await _context.Books
                .Where(b => b.AuthorId == authorId)
                .Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    AuthorName = author.Name,
                    PublicationYear = b.PublicationYear,
                    ISBN = b.ISBN,
                    Price = b.Price
                })
                .ToListAsync();

            return books;
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(CreateAuthorDTO createAuthorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = new Author
            {
                Name = createAuthorDTO.Name,
                Email = createAuthorDTO.Email
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            var authorDTO = new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name,
                Email = author.Email
            };

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, authorDTO);
        }

        // PUT: api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, CreateAuthorDTO createAuthorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            author.Name = createAuthorDTO.Name;
            author.Email = createAuthorDTO.Email;

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            // Check if author has books
            var hasBooks = await _context.Books.AnyAsync(b => b.AuthorId == id);
            if (hasBooks)
            {
                return BadRequest("Cannot delete author with existing books");
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}