using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<TProduct>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(item => item.ProductType);
            AddInclude(item => item.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(item => item.Id == id)
        {
            AddInclude(item => item.ProductType);
            AddInclude(item => item.ProductBrand);
        }
    }
}
