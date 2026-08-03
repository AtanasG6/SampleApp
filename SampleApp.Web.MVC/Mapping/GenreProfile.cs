using AutoMapper;
using SampleApp.Core.Projections.Genres;
using SampleApp.Data.Models;
using SampleApp.Web.ViewModels.Genres;

namespace SampleApp.Web.MVC.Mapping
{
    public class GenreProfile : Profile
    {
        public GenreProfile() 
        { 
            this.CreateMap<GenreGeneralInfoProjection, GenreViewModel>();
            this.CreateMap<GenreInputModel, Genre>();
        }
    }
}
