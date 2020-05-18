using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<TProduct>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
            // jesli nie sa puste i sa rowne criteria doda te wartosci wywolujac knstruktor base specification,  ten zapis jest criteria do specyfikacji
            : base(p => (!brandId.HasValue || p.ProductBrandId == brandId) && (!typeId.HasValue || p.ProductTypeId == typeId))
        {
            AddInclude(item => item.ProductType);
            AddInclude(item => item.ProductBrand);
            AddOrderByAsc(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
