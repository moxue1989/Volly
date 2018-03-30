using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VollyTest.Models;
using VollyTest.Models.ViewModels;

namespace VollyTest.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Search")]
    [EnableCors("MyPolicy")]
    public class SearchApiController : Controller
    {
        private readonly VollyModel _context;

        public SearchApiController(VollyModel context)
        {
            _context = context;
        }

        public Search SearchRequest()
        {
            return new Search
            {
                CategoryIDs = new List<int>
                {
                    1,2,3
                },
                SkillIDs = new List<int>()
                {
                    1,2,3
                }, 
                Weekdays = new List<int>()
                {
                    0,6
                }
            };
        }

        [HttpPost]
        public IEnumerable<Opportunity> SearchOpportunities([FromBody] Search search)
        {
            return _context.Opportunities
                .Where(opp => search.SkillIDs.Contains(opp.SkillRequired.Id) &&
                 search.CategoryIDs.Contains(opp.Category.Id) && 
                 search.Weekdays.Contains((int)opp.DateTime.DayOfWeek))
                .Include(o => o.Category)
                .Include(o => o.Organization)
                .Include(o => o.SkillRequired)
                .Include(o => o.VolunteerType)
                .ToList();
        }

    }
}