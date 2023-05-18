using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using festivalHue.Models;

namespace festivalHue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeatailbookticketsController : ControllerBase
    {
        private readonly HueFestivalApiContext _context;

        public DeatailbookticketsController(HueFestivalApiContext context)
        {
            _context = context;
        }

        // GET: api/Deatailbooktickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deatailbookticket>>> GetDeatailbooktickets()
        {
          if (_context.Deatailbooktickets == null)
          {
              return NotFound();
          }
            return await _context.Deatailbooktickets.ToListAsync();
        }

        // GET: api/Deatailbooktickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deatailbookticket>> GetDeatailbookticket(int id)
        {
          if (_context.Deatailbooktickets == null)
          {
              return NotFound();
          }
            var deatailbookticket = await _context.Deatailbooktickets.FindAsync(id);

            if (deatailbookticket == null)
            {
                return NotFound();
            }

            return deatailbookticket;
        }

        // PUT: api/Deatailbooktickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeatailbookticket(int id, Deatailbookticket deatailbookticket)
        {
            if (id != deatailbookticket.Idcustomer)
            {
                return BadRequest();
            }

            _context.Entry(deatailbookticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeatailbookticketExists(id))
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

        // POST: api/Deatailbooktickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deatailbookticket>> PostDeatailbookticket(Deatailbookticket deatailbookticket)
        {
          if (_context.Deatailbooktickets == null)
          {
              return Problem("Entity set 'HueFestivalApiContext.Deatailbooktickets'  is null.");
          }
            _context.Deatailbooktickets.Add(deatailbookticket);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeatailbookticketExists(deatailbookticket.Idcustomer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeatailbookticket", new { id = deatailbookticket.Idcustomer }, deatailbookticket);
        }

        // DELETE: api/Deatailbooktickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeatailbookticket(int id)
        {
            if (_context.Deatailbooktickets == null)
            {
                return NotFound();
            }
            var deatailbookticket = await _context.Deatailbooktickets.FindAsync(id);
            if (deatailbookticket == null)
            {
                return NotFound();
            }

            _context.Deatailbooktickets.Remove(deatailbookticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeatailbookticketExists(int id)
        {
            return (_context.Deatailbooktickets?.Any(e => e.Idcustomer == id)).GetValueOrDefault();
        }
    }
}
