using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_CommerceAPI.Interfaces;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TProductsController : ControllerBase
    {
        #region Variables
        private readonly IProductRepository _productRepository;
        #endregion Variables

        #region Constructor
        public TProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion Constructor

        #region GET Methods
        // GET: api/TProducts
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TProduct>>> GetTProducts()
        {
           return Ok(await _productRepository.GetProductsAsync());
        }

        // GET: api/TProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TProduct>> GetTProductById(int id)
        {
           return Ok(await _productRepository.GetProductByIdAsync(id));
        }

        // GET: api/TProducts/Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<TProductBrand>>> GetProductsBrands()
        {
            return Ok(await _productRepository.GetProductBrandsAsync());
        }

        // GET: api/TProducts/Types
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<TProductBrand>>> GetProductsTypes()
        {
            return Ok(await _productRepository.GetProductTypesAsync());
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
