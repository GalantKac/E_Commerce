using E_CommerceAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DB_E_CommerceContext _context;

        public ProductRepository(DB_E_CommerceContext context)
        {
            _context = context;
        }

        public async Task<TProduct> GetProductByIdAsync(int id)
        {
            TProduct tProduct = await _context.TProduct.Include(item => item.ProductType).Include(item => item.ProductBrand).FirstOrDefaultAsync(item => item.Id == id);

            if (tProduct == null)
                return null;

            return tProduct;
        }

        public async Task<IReadOnlyList<TProduct>> GetProductsAsync()
        {
            return await _context.TProduct.Include(item => item.ProductType).Include(item => item.ProductBrand).ToListAsync();
        }
        public async Task<IReadOnlyList<TProductBrand>> GetProductBrandsAsync()
        {
            return await _context.TProductBrand.ToListAsync();
        }

        public async Task<IReadOnlyList<TProductType>> GetProductTypesAsync()
        {
            return await _context.TProductType.ToListAsync();
        }

        private bool TProductExists(int id)
        {
            return _context.TProduct.Any(e => e.Id == id);
        }
    }
}
