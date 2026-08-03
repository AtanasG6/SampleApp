using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Core.Interfaces;
using SampleApp.Web.ViewModels.Songs;

namespace SampleApp.Web.MVC.Controllers
{
    [Route("songs")]
    public class SongsController : Controller
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongsController(ISongService songService, IMapper mapper)
        {
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
    }
}
