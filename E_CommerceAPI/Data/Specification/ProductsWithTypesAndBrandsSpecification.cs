using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<TProduct>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecificationParams productParams)
            // add criteria
            : base(p => 
            (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search)) && // search product by name
            (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) && // searach product by  brand id
            (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)) // search product by type id
        {
            AddInclude(item => item.ProductType);
            AddInclude(item => item.ProductBrand);
            AddOrderByAsc(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize); //set item on one page

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderByAsc(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderByAsc(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(item => item.Id == id)
        {
            AddInclude(item => item.ProductType);
            AddInclude(item => item.ProductBrand);
        }
    }
}
