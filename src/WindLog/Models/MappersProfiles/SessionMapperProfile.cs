using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.MappersProfiles
{
    public class SessionMapperProfile : Profile
    {
        public SessionMapperProfile()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(
                    sessionViewModel => sessionViewModel.DateCreated,
                    session => session.MapFrom(model => model.Created))
                .ReverseMap();
        }
    }
}
