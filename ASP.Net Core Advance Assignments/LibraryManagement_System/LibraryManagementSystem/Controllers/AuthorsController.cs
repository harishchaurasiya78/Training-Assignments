using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IGenericRepository<Author> _authorRepo;
        public AuthorsController(IGenericRepository<Author> authorRepo) => _authorRepo = authorRepo;

        public async Task<IActionResult> Index() => View(await _authorRepo.GetAllAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Author model)
        {
            if (!ModelState.IsValid) return View(model);
            await _authorRepo.InsertAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author model)
        {
            if (!ModelState.IsValid) return View(model);
            _authorRepo.Update(model);
            await _authorRepo.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
