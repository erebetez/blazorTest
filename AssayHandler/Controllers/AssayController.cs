using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssayHandler.Models;

namespace AssayHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssayController : ControllerBase
    {
        private readonly AssayContext _context;

        public AssayController(AssayContext context)
        {
            _context = context;
        }

        // GET: api/Assay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssayItem>>> GetAssayItem()
        {
            if (_context.AssayItem == null)
            {
                return NotFound();
            }
            return await _context.AssayItem.ToListAsync();
        }

        // GET: api/Assay/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssayItem>> GetAssayItem(string id)
        {
            if (_context.AssayItem == null)
            {
                return NotFound();
            }
            var assayItem = await _context.AssayItem.FindAsync(id);

            if (assayItem == null)
            {
                return NotFound();
            }

            return assayItem;
        }

        // PUT: api/Assay/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssayItem(string id, AssayItem assayItem)
        {
            if (id != assayItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(assayItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssayItemExists(id))
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

        // POST: api/Assay
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssayItem>> PostAssayItem(AssayItem assayItem)
        {
            if (_context.AssayItem == null)
            {
                return Problem("Entity set 'AssayContext.AssayItem'  is null.");
            }

            Console.WriteLine("assayItem");
            Console.WriteLine(assayItem.Id);

            // assayItem.RawData.Select<RawDataItem>(raw => Console.WriteLine(raw.PositionName));
            foreach (RawDataItem raw in assayItem.RawData)
            {
                Console.WriteLine(raw.PositionName);
            }

            _context.AssayItem.Add(assayItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssayItemExists(assayItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssayItem", new { id = assayItem.Id }, assayItem);
        }

        // DELETE: api/Assay/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssayItem(string id)
        {
            if (_context.AssayItem == null)
            {
                return NotFound();
            }
            var assayItem = await _context.AssayItem.FindAsync(id);
            if (assayItem == null)
            {
                return NotFound();
            }

            _context.AssayItem.Remove(assayItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssayItemExists(string id)
        {
            return (_context.AssayItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
