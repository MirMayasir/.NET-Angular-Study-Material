using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirstApporach.Models;

namespace CodeFirstApporach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierscsController : ControllerBase
    {
        private readonly ProductContext _context;

        public SupplierscsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Supplierscs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplierscs>>> GetGetSuppliers()
        {
            return await _context.GetSuppliers.ToListAsync();
        }

        // GET: api/Supplierscs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplierscs>> GetSupplierscs(int id)
        {
            var supplierscs = await _context.GetSuppliers.FindAsync(id);

            if (supplierscs == null)
            {
                return NotFound();
            }

            return supplierscs;
        }

        // PUT: api/Supplierscs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierscs(int id, Supplierscs supplierscs)
        {
            if (id != supplierscs.Sid)
            {
                return BadRequest();
            }

            _context.Entry(supplierscs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierscsExists(id))
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

        // POST: api/Supplierscs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supplierscs>> PostSupplierscs(Supplierscs supplierscs)
        {
            _context.GetSuppliers.Add(supplierscs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplierscs", new { id = supplierscs.Sid }, supplierscs);
        }

        // DELETE: api/Supplierscs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplierscs(int id)
        {
            var supplierscs = await _context.GetSuppliers.FindAsync(id);
            if (supplierscs == null)
            {
                return NotFound();
            }

            _context.GetSuppliers.Remove(supplierscs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplierscsExists(int id)
        {
            return _context.GetSuppliers.Any(e => e.Sid == id);
        }
    }
}
