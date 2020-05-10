using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_CommerceAPI.Interfaces;
using E_CommerceAPI.Data.Specification;
using AutoMapper;
using E_CommerceAPI.DTOs;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TProductsController : ControllerBase
    {
        private readonly IGenericRepository<TProduct> _productRepository;
        private readonly IGenericRepository<TProductBrand> _productBrandRepository;
        private readonly IGenericRepository<TProductType> _productTypeRepository;
        private readonly IMapper _mapper;
        #region Variables

        #endregion Variables

        #region Constructor
        public TProductsController(IGenericRepository<TProduct> productRepository, IGenericRepository<TProductBrand> productBrandRepository, IGenericRepository<TProductType> productTypeRepository, IMapper mapper)
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
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetTProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productRepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<TProduct>, IReadOnlyList<ProductDTO>>(products));
        }

        // GET: api/TProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetTProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpecification(spec);
            return _mapper.Map<TProduct, ProductDTO>(product);
        }

        // GET: api/TProducts/Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<TProductBrand>>> GetProductsBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }

        // GET: api/TProducts/Types
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<TProductBrand>>> GetProductsTypes()
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
