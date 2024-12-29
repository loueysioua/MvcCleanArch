using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Infrastructure.Persistence.DbContext;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Domain.Interfaces;

namespace MvcCleanArch.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;


        public MoviesController(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;

        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _movieRepository.GetAllAsync());

        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.GetByIdAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var genres = await _genreRepository.GetAllAsync();
            ViewData["GenreId"] = new SelectList(genres, "Id", "GenreName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = Guid.NewGuid();
                await _movieRepository.AddAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            var genres = await _genreRepository.GetAllAsync();
            ViewData["GenreId"] = new SelectList(genres, "Id", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.GetByIdAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            var genres = await _genreRepository.GetAllAsync();
            ViewData["GenreId"] = new SelectList(genres, "Id", "GenreName", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,GenreId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _movieRepository.UpdateAsync(movie);

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            var genres = await _genreRepository.GetAllAsync();
            ViewData["GenreId"] = new SelectList(genres, "Id", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.GetByIdAsync(id.Value);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie != null)
            {
                await _movieRepository.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
