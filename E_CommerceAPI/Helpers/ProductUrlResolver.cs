using AutoMapper;
using E_CommerceAPI.DTOs;
using Microsoft.Extensions.Configuration;
using ProductLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Helpers
{
    public class ProductUrlResolver : IValueResolver<TProduct, ProductDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(TProduct source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PicturePath))
                return _config["ApiUrl"] + source.PicturePath;

            return null;
        }
    }
}
