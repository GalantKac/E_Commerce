using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<TProduct> GetProductByIdAsync(int id);
        Task<IReadOnlyList<TProduct>> GetProductsAsync();
        Task<IReadOnlyList<TProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<TProductType>> GetProductTypesAsync();
    }
}
