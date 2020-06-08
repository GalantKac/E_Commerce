﻿using ProductLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<TProduct>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParams productParams)
          : base(p =>
            (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) && // search product by name
            (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) && // search prodcut by brand id and
            (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)) // search product by type id 
        {
        }
    }
}