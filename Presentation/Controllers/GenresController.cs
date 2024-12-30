using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Domain.Interfaces;
using MvcCleanArch.Application.Services.ServiceContracts;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcCleanArch.Application.DTOs.GenreDtos;

namespace MvcCleanArch.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _genreService.GetAllGenresAsync());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var genre = await _genreService.GetGenreByIdAsync(id.Value);
            if (genre == null)
            {
                return NotFound();
            }

            return View("Details", genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGenreDto genre)
        {
            await _genreService.CreateGenreAsync(genre);
            return RedirectToAction(nameof(Index));
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _genreService.GetGenreByIdAsync(id.Value);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UpdateGenreDto genre)
        {
            await _genreService.UpdateGenreAsync(id, genre);
            return RedirectToAction(nameof(Index));
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id.Value);

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _genreService.DeleteGenreAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }


}
