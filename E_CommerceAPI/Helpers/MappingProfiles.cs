using AutoMapper;
using E_CommerceAPI.DTOs;
using ProductLibrary.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TProduct, ProductDTO>()
                .ForMember(dto => dto.ProductBrand, options => options.MapFrom(source => source.ProductBrand.Name))
                .ForMember(dto => dto.ProductType, options => options.MapFrom(source => source.ProductType.Name))
                .ForMember(dto => dto.PicturePath, options => options.MapFrom<ProductUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();

        }
    }
}
