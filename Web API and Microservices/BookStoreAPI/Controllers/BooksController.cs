using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Data;
using BookStoreAPI.Models;
using BookStoreAPI.DTOs;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.Name,
                    PublicationYear = b.PublicationYear,
                    ISBN = b.ISBN,
                    Price = b.Price
                })
                .ToListAsync();

            return books;
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Where(b => b.Id == id)
                .Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.Name,
                    PublicationYear = b.PublicationYear,
                    ISBN = b.ISBN,
                    Price = b.Price
                })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(CreateBookDTO createBookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if author exists
            var author = await _context.Authors.FindAsync(createBookDTO.AuthorId);
            if (author == null)
            {
                return BadRequest("Author not found");
            }

            var book = new Book
            {
                Title = createBookDTO.Title,
                AuthorId = createBookDTO.AuthorId,
                PublicationYear = createBookDTO.PublicationYear,
                ISBN = createBookDTO.ISBN,
                Price = createBookDTO.Price
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var bookDTO = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                AuthorName = author.Name,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN,
                Price = book.Price
            };

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, bookDTO);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, CreateBookDTO createBookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // Check if author exists
            var author = await _context.Authors.FindAsync(createBookDTO.AuthorId);
            if (author == null)
            {
                return BadRequest("Author not found");
            }

            book.Title = createBookDTO.Title;
            book.AuthorId = createBookDTO.AuthorId;
            book.PublicationYear = createBookDTO.PublicationYear;
            book.ISBN = createBookDTO.ISBN;
            book.Price = createBookDTO.Price;

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}