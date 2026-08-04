using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Core.Interfaces;
using SampleApp.Data.Models;
using SampleApp.Web.ViewModels.Artists;
using SampleApp.Web.ViewModels.Genres;
using SampleApp.Web.ViewModels.Songs;

namespace SampleApp.Web.MVC.Controllers
{
    [Route("songs")]
    public class SongsController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongsController(IArtistService artistService, IGenreService genreService, ISongService songService, IMapper mapper)
        {
            this._artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
            this._genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            this._songService = songService ?? throw new ArgumentNullException(nameof(songService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var songs = this._songService.GetAll();
            var viewModels = this._mapper.Map<IEnumerable<SongViewModel>>(songs);

            return this.View(viewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var viewModel = this.PrepareFormViewModel();

            return this.View(viewModel);
        }

        [HttpPost("create"), ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] SongCreateModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = this.PrepareFormViewModel(inputModel);
                return this.View(viewModel);
            }

            var artist = this._artistService.GetById(inputModel.Artist);

            if (artist is null) throw new InvalidOperationException("Artist not found");

            var genres = this._genreService.GetByIds(inputModel.Genres).ToArray();

            var song = this._mapper.Map<Song>(inputModel);
            song.Artist = artist;
            song.Genres = genres;

            this._songService.Create(song);

            return this.RedirectToAction(nameof(Index));  
        }

        private SongFormViewModel PrepareFormViewModel(SongCreateModel? inputModel = null)
        {
            var allArtists = this._artistService.GetAllMinified();
            var allGenres = this._genreService.GetAllMinified();

            return new SongFormViewModel
            {
                Artists = this._mapper.Map<IEnumerable<ArtistMinifiedViewModel>>(allArtists),
                Genres = this._mapper.Map<IEnumerable<GenreMinifiedViewModel>>(allGenres),
                InputModel = inputModel
            };
        }
    }
}
