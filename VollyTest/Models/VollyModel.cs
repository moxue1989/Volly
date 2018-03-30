using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VollyTest.Models
{
    public class VollyModel : DbContext
    {
        public VollyModel(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<VolunteerType> VolunteerTypes { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}
