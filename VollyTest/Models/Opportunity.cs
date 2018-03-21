using System;
using System.Collections;
using System.Collections.Generic;

namespace VollyTest.Models
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  Organization Organization { get; set; }
        public  Category Category { get; set; }
        public  VolunteerType VolunteerType { get; set; }            
        public  Skill SkillRequired { get; set; }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public bool VolunteersNeeded { get; set; }
        public string LogoUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool PoliceCheckRequired { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }

    public class VolunteerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}