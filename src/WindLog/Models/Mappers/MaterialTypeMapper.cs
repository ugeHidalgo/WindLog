using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.Mappers
{
    public class MaterialTypeMapper
    {
        public void InitMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<MaterialTypeViewModel, MaterialType>()
                .ForMember(
                    matType => matType.Created,
                    MaterialTypeViewModel => MaterialTypeViewModel.MapFrom(model => model.DateCreated))
                .ReverseMap();
            });
        }
    }
}
