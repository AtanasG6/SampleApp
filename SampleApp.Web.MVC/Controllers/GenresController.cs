using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Interfaces;
using SampleApp.Data.Models;
using SampleApp.Web.ViewModels.Genres;

namespace SampleApp.Web.MVC.Controllers
{
    [Route("genres")]
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var genres = this._genreService.GetAll();
            var viewModels = this._mapper.Map<IEnumerable<GenreViewModel>>(genres);

            return View(viewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("create"), ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] GenreInputModel inputModel)
        {
            if (!ModelState.IsValid) return View(inputModel);

            var genre = this._mapper.Map<Genre>(inputModel);
            this._genreService.Create(genre);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("delete")]
        public IActionResult Delete(Guid id)
        {
            var genre = this._genreService.GetById(id);
            if (genre is null) return this.NotFound();

            var viewModel = this._mapper.Map<GenreViewModel>(genre);
            return this.View(viewModel);
        }

        [HttpPost("delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._genreService.Delete(id);
            return this.RedirectToAction(nameof(Index));
        }

        /*// GET: Genres/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        private bool GenreExists(Guid id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }*/
    }
}
