using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataProject.Data;
using System.Net.Mime;

namespace DataProject.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class OffencesController : ControllerBase
    {
        private readonly DataProjectDbContext _context;

        public OffencesController(DataProjectDbContext context)
        {
            _context = context;
        }

        // GET: api/Offences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offence>>> GetOffences()
        {
            return await _context.Offences.ToListAsync();
        }

        // GET: api/Offences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offence>> GetOffence(int id)
        {
            var offence = await _context.Offences.FindAsync(id);

            if (offence == null)
            {
                return NotFound();
            }

            return offence;
        }

        // PUT: api/Offences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffence(int id, Offence offence)
        {
            if (id != offence.OffencesId)
            {
                return BadRequest();
            }

            _context.Entry(offence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffenceExists(id))
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

        // POST: api/Offences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offence>> PostOffence(Offence offence)
        {
            _context.Offences.Add(offence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffence", new { id = offence.OffencesId }, offence);
        }

        // DELETE: api/Offences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffence(int id)
        {
            var offence = await _context.Offences.FindAsync(id);
            if (offence == null)
            {
                return NotFound();
            }

            _context.Offences.Remove(offence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OffenceExists(int id)
        {
            return _context.Offences.Any(e => e.OffencesId == id);
        }
    }
}
