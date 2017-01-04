using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.Mappers
{
    public class MaterialMapper : Profile
    {
        public MaterialMapper()
        {
            CreateMap<MaterialViewModel, Material>()
                .ForMember(
                    mat => mat.Created,
                    MaterialViewModel => MaterialViewModel.MapFrom(model => model.DateCreated))
                .ForMember(
                    mat => mat.Purchase,
                    MaterialViewModel => MaterialViewModel.MapFrom(model => model.DatePurchased))
                .ReverseMap();            
        }
    }
}
