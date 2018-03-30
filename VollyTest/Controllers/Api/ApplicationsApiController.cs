using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VollyTest.Models;

namespace VollyTest.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Applications")]
    [EnableCors("MyPolicy")]
    public class ApplicationsApiController : Controller
    {
        private readonly VollyModel _context;

        public ApplicationsApiController(VollyModel context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public IEnumerable<Application> GetApplications()
        {
            return _context.Applications
                .Include(o => o.Opportunity);
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplications([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applications = await _context.Applications
                .Include(o => o.Opportunity)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (applications == null)
            {
                return NotFound();
            }

            return Ok(applications);
        }

        // POST: api/Applications
        [HttpPost]
        public async Task<IActionResult> PostApplications([FromBody] Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Opportunity opportunity = _context.Opportunities
                .Find(application.Opportunity.Id);

            application.Opportunity = opportunity;

            string email = "alicelam22@gmail.com";

            EmailSender.SendEmail(email, "Application For: " + opportunity.Name, application.ToString());

            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplications", new { id = application.Id }, application);
        }
    }
}