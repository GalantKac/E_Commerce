using ProductLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<TProduct>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParams productParams)
          : base(p => (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) && (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {
        }
    }
}
