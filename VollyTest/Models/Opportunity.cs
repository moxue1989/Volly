using System;
using System.Collections;
using System.Collections.Generic;

namespace VollyTest.Models
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Organization Organization { get; set; }
        public Category Category { get; set; }
        public VolunteerType VolunteerType { get; set; }
        public Skill SkillRequired { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class Application
    {
        public int Id { get; set; }
        public Opportunity Opportunity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool PoliceRecord { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + "\n" +
                   "Email: " + Email + "\n" +
                   "Message: " + Message;

        }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string WebsiteLink { get; set; }
        public string DonateLink { get; set; }
        public string MissionStatement { get; set; }
        public string FullDescription { get; set; }
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