using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.Mappers
{
    public class SessionMapper : Profile
    {
        public SessionMapper()
        {
            CreateMap<SessionViewModel, Session>()
                .ForMember(
                    session => session.Created,
                    SessionViewModel => SessionViewModel.MapFrom(model => model.DateCreated))
                .ReverseMap();
        }
    }
}
