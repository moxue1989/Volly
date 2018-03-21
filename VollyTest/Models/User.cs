using System.Collections.Generic;
using Newtonsoft.Json;

namespace VollyTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
  
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}