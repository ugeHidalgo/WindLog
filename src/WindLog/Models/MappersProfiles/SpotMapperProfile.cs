using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.MappersProfiles
{
    public class SpotMapperProfile : Profile
    {
        public SpotMapperProfile()
        {
            CreateMap<Spot, SpotViewModel>()
                .ForMember(
                    spotViewModel => spotViewModel.DateCreated,
                    spot => spot.MapFrom(model => model.Created))                
                .ReverseMap();
        }
    }
}
