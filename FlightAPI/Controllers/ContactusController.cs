using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightAPI.Models;

namespace FlightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusController : ControllerBase
    {
        private readonly FlightDatabaseContext _context;

        public ContactusController(FlightDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Contactus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactu>>> GetContactus()
        {
            return await _context.Contactus.ToListAsync();
        }

        // GET: api/Contactus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contactu>> GetContactu(string id)
        {
            var contactu = await _context.Contactus.FindAsync(id);

            if (contactu == null)
            {
                return NotFound();
            }

            return contactu;
        }

        // PUT: api/Contactus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactu(string id, Contactu contactu)
        {
            if (id != contactu.FullName)
            {
                return BadRequest();
            }

            _context.Entry(contactu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactuExists(id))
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

        // POST: api/Contactus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contactu>> PostContactu(Contactu contactu)
        {
            _context.Contactus.Add(contactu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactuExists(contactu.FullName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContactu", new { id = contactu.FullName }, contactu);
        }

        // DELETE: api/Contactus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactu(string id)
        {
            var contactu = await _context.Contactus.FindAsync(id);
            if (contactu == null)
            {
                return NotFound();
            }

            _context.Contactus.Remove(contactu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactuExists(string id)
        {
            return _context.Contactus.Any(e => e.FullName == id);
        }
    }
}
