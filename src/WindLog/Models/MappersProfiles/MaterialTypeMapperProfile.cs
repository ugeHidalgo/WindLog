using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.MappersProfiles
{
    public class MaterialTypeMapperProfile : Profile
    {
        public MaterialTypeMapperProfile()
        {
            CreateMap<MaterialType, MaterialTypeViewModel>()
                .ForMember(
                    matTypeViewModel => matTypeViewModel.DateCreated,
                    matType => matType.MapFrom(model => model.Created)
                 )
                .ReverseMap();
        }
    }
}
