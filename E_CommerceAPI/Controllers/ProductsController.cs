using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_CommerceAPI.Interfaces;
using E_CommerceAPI.Data.Specification;
using AutoMapper;
using E_CommerceAPI.DTOs;
using E_CommerceAPI.Helpers;
using ProductLibrary.Entities;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;
        #region Variables

        #endregion Variables

        #region Constructor
        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }
        #endregion Constructor

        #region GET Methods
        // GET: api/TProducts
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetTProducts([FromQuery] ProductSpecificationParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _productRepository.CountAsync(countSpec);

            var products = await _productRepository.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products); // map all returned products from db 
            return Ok(new Pagination<ProductDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        // GET: api/TProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetTProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpecification(spec);
            return _mapper.Map<Product, ProductDTO>(product);
        }

        // GET: api/TProducts/Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }

        // GET: api/TProducts/Types
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }

        #endregion GET Methods

        #region PUT Methods
        //// PUT: api/TProducts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTProduct(int id, TProduct tProduct)
        //{
        //    if (id != tProduct.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tProduct).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        #endregion PUT Methods

        #region POST Methods
        // POST: api/TProducts
        //[HttpPost]
        //public async Task<ActionResult<TProduct>> PostTProduct(TProduct tProduct)
        //{
        //    _context.TProduct.Add(tProduct);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTProduct", new { id = tProduct.Id }, tProduct);
        //}
        #endregion POST Methods

        #region DELETE Methods
        // DELETE: api/TProducts/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TProduct>> DeleteTProduct(int id)
        //{
        //    var tProduct = await _context.TProduct.FindAsync(id);
        //    if (tProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TProduct.Remove(tProduct);
        //    await _context.SaveChangesAsync();

        //    return tProduct;
        //}
        #endregion DELETE Methods
    }
}
