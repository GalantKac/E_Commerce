using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dto => dto.ProductBrand, options => options.MapFrom(source => source.ProductBrand.Name))
                .ForMember(dto => dto.ProductType, options => options.MapFrom(source => source.ProductType.Name))
                .ForMember(dto => dto.PictureUrl, options => options.MapFrom<ProductUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
