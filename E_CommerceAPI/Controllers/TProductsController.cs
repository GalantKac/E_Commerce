using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_CommerceAPI;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TProductsController : ControllerBase
    {
        #region Variables
        private readonly DB_E_CommerceContext _context;
        #endregion Variables

        #region Constructor
        public TProductsController(DB_E_CommerceContext context)
        {
            _context = context;
        }
        #endregion Constructor

        #region GET Methods
        // GET: api/TProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TProduct>>> GetTProduct()
        {
            return await _context.TProduct.ToListAsync();
        }

        // GET: api/TProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TProduct>> GetTProduct(int id)
        {
            var tProduct = await _context.TProduct.FindAsync(id);

            if (tProduct == null)
            {
                return NotFound();
            }

            return tProduct;
        }
        #endregion GET Methods

        #region PUT Methods
        // PUT: api/TProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTProduct(int id, TProduct tProduct)
        {
            if (id != tProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(tProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion PUT Methods

        #region POST Methods
        // POST: api/TProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TProduct>> PostTProduct(TProduct tProduct)
        {
            _context.TProduct.Add(tProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTProduct", new { id = tProduct.Id }, tProduct);
        }

        // DELETE: api/TProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TProduct>> DeleteTProduct(int id)
        {
            var tProduct = await _context.TProduct.FindAsync(id);
            if (tProduct == null)
            {
                return NotFound();
            }

            _context.TProduct.Remove(tProduct);
            await _context.SaveChangesAsync();

            return tProduct;
        }
        #endregion POST Methods

        private bool TProductExists(int id)
        {
            return _context.TProduct.Any(e => e.Id == id);
        }
    }
}
