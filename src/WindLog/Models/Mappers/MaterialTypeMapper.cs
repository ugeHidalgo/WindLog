using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.Mappers
{
    public class MaterialTypeMapper : Profile
    {
        public MaterialTypeMapper()
        {       
            CreateMap<MaterialTypeViewModel, MaterialType>()
                .ForMember(
                    matType => matType.Created,
                    MaterialTypeViewModel => MaterialTypeViewModel.MapFrom(model => model.DateCreated))
                .ReverseMap();            
        }
    }
}
