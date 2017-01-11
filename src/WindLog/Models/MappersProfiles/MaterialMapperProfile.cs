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
                .ReverseMap()
                .ForMember(
                    mat => mat.Created,
                    matViewModel => matViewModel.MapFrom(model => model.DateCreated))
                .ForMember(
                    mat => mat.Purchase,
                    matViewModel => matViewModel.MapFrom(model => model.DatePurchased));
        }
    }
}
