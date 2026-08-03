using AutoMapper;
using SampleApp.Core.Projections.Artists;
using SampleApp.Web.ViewModels.Artists;

namespace SampleApp.Web.MVC.Mapping
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            this.CreateMap<ArtistMinifiedProjection, ArtistMinifiedViewModel>();
        }
    }
}
