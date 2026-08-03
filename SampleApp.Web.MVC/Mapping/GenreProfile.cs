using AutoMapper;
using SampleApp.Core.Projections.Genres;
using SampleApp.Web.ViewModels.Genres;

namespace SampleApp.Web.MVC.Mapping
{
    public class GenreProfile : Profile
    {
        public GenreProfile() 
        { 
            this.CreateMap<GenreGeneralInfoProjection, GenreViewModel>();
        }
    }
}
