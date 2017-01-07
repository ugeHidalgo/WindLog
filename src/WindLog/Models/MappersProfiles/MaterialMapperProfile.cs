using AutoMapper;
using WindLog.ViewModels;

namespace WindLog.Models.MappersProfiles
{
    public class MaterialMapperProfile : Profile
    {
        public MaterialMapperProfile()
        {
            CreateMap<Material, MaterialViewModel>()
                .ForMember(
                    matViewModel => matViewModel.DateCreated,
                    mat => mat.MapFrom(model => model.Created))
                .ForMember(
                    matViewModel => matViewModel.DatePurchased,
                    mat => mat.MapFrom(model => model.Purchase))
                .ReverseMap();            
        }
    }
}
