using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IGenericRepository<Book> _bookRepo;
        private readonly IGenericRepository<Author> _authorRepo;
        private readonly IGenericRepository<Genre> _genreRepo;

        public BooksController(IGenericRepository<Book> bookRepo,
                               IGenericRepository<Author> authorRepo,
                               IGenericRepository<Genre> genreRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _genreRepo = genreRepo;
        }

        // GET: Books
             public async Task<IActionResult> Index()
        {
            var books = await _bookRepo.GetAllAsync();
            return View(books);
        }

        // GET: Books/Create (returns partial view used by AJAX)
        public async Task<IActionResult> Create()
        {
            await PopulateDropDowns();
            return PartialView("_CreateEdit", new Book());
        }

        // POST: Books/Create (AJAX)
        [HttpPost]
        public async Task<IActionResult> Create(Book model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _bookRepo.InsertAsync(model);
            return Ok(new { success = true });
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return NotFound();
            await PopulateDropDowns();
            return PartialView("_CreateEdit", book);
        }

        // POST: Books/Edit/5 (AJAX)
        [HttpPost]
        public async Task<IActionResult> Edit(Book model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _bookRepo.Update(model);
            await _bookRepo.SaveAsync();
            return Ok(new { success = true });
        }

        // POST: Books/Delete/5 (AJAX)
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookRepo.DeleteAsync(id);
            return Ok(new { success = true });
        }

        private async Task PopulateDropDowns()
        {
            var authors = await _authorRepo.GetAllAsync();
            var genres = await _genreRepo.GetAllAsync();
            ViewBag.Authors = new SelectList(authors, "AuthorId", "Name");
            ViewBag.Genres = new SelectList(genres, "GenreId", "Name");
        }
    }
}
