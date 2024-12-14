using AutoMapper;
using vShop.Apps.Application.DTOs;
using vShop.Domain.Entities;

namespace vShop.Apps.Application.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
