using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VollyTest.Models.ViewModels
{
    public class OpportunityView
    {
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public int CategoryId { get; set; }
        public int VolunteerTypeId { get; set; }
        public int SkillRequiredId { get; set; }
    }

    public class OpportunityCreate
    {
        public SelectList Organizations { get; set; }
        public SelectList Categories { get; set; }
        public SelectList VolunteerTypes { get; set; }
        public SelectList Skills { get; set; }
    }
}
