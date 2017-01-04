using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.Mappers
{
    public class SpotMapper : Profile
    {
        public SpotMapper()
        {
            CreateMap<SpotViewModel, Spot>()
                .ForMember(
                    spot => spot.Created,
                    SpotViewModel => SpotViewModel.MapFrom(model => model.DateCreated))                
                .ReverseMap();
        }
    }
}
