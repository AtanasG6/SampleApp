using AutoMapper;
using SampleApp.Core.Projections.Songs;
using SampleApp.Data.Models;
using SampleApp.Web.ViewModels.Songs;

namespace SampleApp.Web.MVC.Mapping
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            this.CreateMap<SongGeneralInfoProjection, SongViewModel>();
            this.CreateMap<SongCreateModel, Song>()
                .ForMember(x => x.Artist, conf => conf.Ignore())
                .ForMember(x => x.Genres, conf => conf.Ignore());
        }
    }
}
