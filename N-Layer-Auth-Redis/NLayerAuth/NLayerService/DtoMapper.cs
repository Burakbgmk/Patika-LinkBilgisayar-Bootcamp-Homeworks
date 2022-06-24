using AutoMapper;
using NLayerCore.DTOs;
using NLayerCore.Models;

namespace NLayerService
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductFeatureDto, ProductFeature>().ReverseMap();
        }
    }
}