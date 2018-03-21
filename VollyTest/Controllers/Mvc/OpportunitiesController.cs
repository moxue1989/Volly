using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VollyTest.Models;
using VollyTest.Models.ViewModels;

namespace VollyTest.Controllers.Mvc
{
    public class OpportunitiesController : Controller
    {
        private readonly VollyModel _context;

        public OpportunitiesController(VollyModel context)
        {
            _context = context;
        }

        // GET: Opportunities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Opportunities
                .Include(o => o.Category)
                .Include(o => o.Organization)
                .Include(o => o.SkillRequired)
                .Include(o => o.VolunteerType)
                .ToListAsync());
        }

        // GET: Opportunities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
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

            return View(opportunity);
        }

        // GET: Opportunities/Create
        public IActionResult Create()
        {
            OpportunityCreate opportunityCreate = new OpportunityCreate()
            {
                Categories = new SelectList(_context.Categories.ToList(), "Id", "Name"),
                VolunteerTypes = new SelectList(_context.VolunteerTypes.ToList(), "Id", "Name"),
                Skills = new SelectList(_context.Skills.ToList(), "Id", "Name"),
                Organizations = new SelectList(_context.Organizations.ToList(), "Id", "Name")
            };

            ViewData["create"] = opportunityCreate;
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OpportunityView opportunityView)
        {
            if (ModelState.IsValid)
            {
                Opportunity newOpportunity = new Opportunity()
                {
                    Name = opportunityView.Name,
                    SkillRequired = _context.Skills.Find(opportunityView.SkillRequiredId),
                    Category = _context.Categories.Find(opportunityView.CategoryId),
                    Organization = _context.Organizations.Find(opportunityView.OrganizationId),
                    VolunteerType = _context.VolunteerTypes.Find(opportunityView.VolunteerTypeId)
                };

                _context.Add(newOpportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opportunityView);
        }

        // GET: Opportunities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities.SingleOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }
            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Opportunity opportunity)
        {
            if (id != opportunity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(opportunity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities
                .SingleOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await _context.Opportunities.SingleOrDefaultAsync(m => m.Id == id);
            _context.Opportunities.Remove(opportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunities.Any(e => e.Id == id);
        }
    }
}
