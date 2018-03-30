using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VollyTest.Models;

namespace VollyTest.Controllers.Mvc
{
    public class VolunteerTypesController : Controller
    {
        private readonly VollyModel _context;

        public VolunteerTypesController(VollyModel context)
        {
            _context = context;
        }

        // GET: VolunteerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VolunteerTypes.ToListAsync());
        }

        // GET: VolunteerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerType = await _context.VolunteerTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (volunteerType == null)
            {
                return NotFound();
            }

            return View(volunteerType);
        }

        // GET: VolunteerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VolunteerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VolunteerType volunteerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volunteerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volunteerType);
        }

        // GET: VolunteerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerType = await _context.VolunteerTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (volunteerType == null)
            {
                return NotFound();
            }
            return View(volunteerType);
        }

        // POST: VolunteerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VolunteerType volunteerType)
        {
            if (id != volunteerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteerTypeExists(volunteerType.Id))
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
            return View(volunteerType);
        }

        // GET: VolunteerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteerType = await _context.VolunteerTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (volunteerType == null)
            {
                return NotFound();
            }

            return View(volunteerType);
        }

        // POST: VolunteerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteerType = await _context.VolunteerTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.VolunteerTypes.Remove(volunteerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteerTypeExists(int id)
        {
            return _context.VolunteerTypes.Any(e => e.Id == id);
        }
    }
}
