using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenderCoordCore.Context;
using SenderCoordCore.Models;

namespace SenderCoordCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordsController : ControllerBase
    {
        private readonly CoordsContext _context;

        public CoordsController(CoordsContext context)
        {
            _context = context;
        }

        // GET: api/Coords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coords>>> GetCoords()
        {
            return await _context.Coords.ToListAsync();
        }

        // GET: api/Coords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coords>> GetCoords(Guid id)
        {
            var coords = await _context.Coords.FindAsync(id);

            if (coords == null)
            {
                return NotFound();
            }

            return coords;
        }

        // PUT: api/Coords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoords(Guid id, Coords coords)
        {
            if (id != coords.CooRecordId)
            {
                return BadRequest();
            }

            _context.Entry(coords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordsExists(id))
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

        // POST: api/Coords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coords>> PostCoords(Coords coords)
        {
            _context.Coords.Add(coords);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoordsExists(coords.CooRecordId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoords", new { id = coords.CooRecordId }, coords);
        }

        // DELETE: api/Coords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coords>> DeleteCoords(Guid id)
        {
            var coords = await _context.Coords.FindAsync(id);
            if (coords == null)
            {
                return NotFound();
            }

            _context.Coords.Remove(coords);
            await _context.SaveChangesAsync();

            return coords;
        }

        private bool CoordsExists(Guid id)
        {
            return _context.Coords.Any(e => e.CooRecordId == id);
        }
    }
}
