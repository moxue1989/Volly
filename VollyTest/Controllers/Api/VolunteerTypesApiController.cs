using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VollyTest.Models;

namespace VollyTest.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/VolunteerTypes")]
    [EnableCors("MyPolicy")]
    public class VolunteerTypesApiController : Controller
    {
        private readonly VollyModel _context;

        public VolunteerTypesApiController(VollyModel context)
        {
            _context = context;
        }

        // GET: api/VolunteerTypes
        [HttpGet]
        public IEnumerable<VolunteerType> GetVolunteerTypes()
        {
            return _context.VolunteerTypes;
        }

        // GET: api/VolunteerTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVolunteerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var volunteerType = await _context.VolunteerTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (volunteerType == null)
            {
                return NotFound();
            }

            return Ok(volunteerType);
        }

        // PUT: api/VolunteerTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVolunteerType([FromRoute] int id, [FromBody] VolunteerType volunteerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != volunteerType.Id)
            {
                return BadRequest();
            }

            _context.Entry(volunteerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerTypeExists(id))
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

        // POST: api/VolunteerTypes
        [HttpPost]
        public async Task<IActionResult> PostVolunteerType([FromBody] VolunteerType volunteerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VolunteerTypes.Add(volunteerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVolunteerType", new { id = volunteerType.Id }, volunteerType);
        }

        // DELETE: api/VolunteerTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVolunteerType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var volunteerType = await _context.VolunteerTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (volunteerType == null)
            {
                return NotFound();
            }

            _context.VolunteerTypes.Remove(volunteerType);
            await _context.SaveChangesAsync();

            return Ok(volunteerType);
        }

        private bool VolunteerTypeExists(int id)
        {
            return _context.VolunteerTypes.Any(e => e.Id == id);
        }
    }
}