using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VollyTest.Models;
using VollyTest.Models.ViewModels;

namespace VollyTest.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Opportunities")]
    [EnableCors("MyPolicy")]
    public class OpportunitiesApiController : Controller
    {
        private readonly VollyModel _context;

        public OpportunitiesApiController(VollyModel context)
        {
            _context = context;
        }

        // GET: api/Opportunities
        [HttpGet]
        public IEnumerable<Opportunity> GetOpportunities()
        {
            return _context.Opportunities
                .Include(o => o.Category)
                .Include(o => o.Organization)
                .Include(o => o.SkillRequired)
                .Include(o => o.VolunteerType);
        }

        [HttpGet]
        [Route("/api/Opportunities/Post")]
        public OpportunityView GetOpportunityView()
        {
            return new OpportunityView()
            {
                Name = "Opportunity",
                Description = "description of this opportunity",
                CategoryId = 1,
                DateTime = DateTime.Now,
                OrganizationId = 2,
                SkillRequiredId = 3,
                VolunteerTypeId = 4
            };
        }

        // GET: api/Opportunities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOpportunity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opportunity = await _context.Opportunities
                .Include(o => o.Category)
                .Include(o => o.Organization)
                .Include(o => o.SkillRequired)
                .Include(o => o.VolunteerType)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (opportunity == null)
            {
                return NotFound();
            }

            return Ok(opportunity);
        }

        // PUT: api/Opportunities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpportunity([FromRoute] int id, [FromBody] Opportunity opportunity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opportunity.Id)
            {
                return BadRequest();
            }

            _context.Entry(opportunity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpportunityExists(id))
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

        // POST: api/Opportunities
        [HttpPost]
        public async Task<IActionResult> PostOpportunity([FromBody] OpportunityView opportunityView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Opportunity newOpportunity = new Opportunity
            {
                Name = opportunityView.Name,
                Description = opportunityView.Description,
                SkillRequired = _context.Skills.Find(opportunityView.SkillRequiredId),
                Category = _context.Categories.Find(opportunityView.CategoryId),
                Organization = _context.Organizations.Find(opportunityView.OrganizationId),
                VolunteerType = _context.VolunteerTypes.Find(opportunityView.VolunteerTypeId),
                DateTime = opportunityView.DateTime
            };

            _context.Opportunities.Add(newOpportunity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpportunity", new { id = newOpportunity.Id }, newOpportunity);
        }

        // DELETE: api/Opportunities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpportunity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opportunity = await _context.Opportunities.SingleOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            _context.Opportunities.Remove(opportunity);
            await _context.SaveChangesAsync();

            return Ok(opportunity);
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunities.Any(e => e.Id == id);
        }
    }
}