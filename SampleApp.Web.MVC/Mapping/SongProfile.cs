using AutoMapper;
using SampleApp.Core.Projections.Songs;
using SampleApp.Web.ViewModels.Songs;

namespace SampleApp.Web.MVC.Mapping
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            this.CreateMap<SongGeneralInfoProjection, SongViewModel>();
        }
    }
}
