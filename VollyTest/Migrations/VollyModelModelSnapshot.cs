﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VollyTest.Models;

namespace VollyTest.Migrations
{
    [DbContext(typeof(VollyModel))]
    partial class VollyModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VollyTest.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<string>("Name");

                    b.Property<int?>("OpportunityId");

                    b.Property<bool>("PoliceRecord");

                    b.HasKey("Id");

                    b.HasIndex("OpportunityId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("VollyTest.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VollyTest.Models.Opportunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("OrganizationId");

                    b.Property<int?>("SkillRequiredId");

                    b.Property<int?>("VolunteerTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("SkillRequiredId");

                    b.HasIndex("VolunteerTypeId");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("VollyTest.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ContactEmail");

                    b.Property<string>("DonateLink");

                    b.Property<string>("FullDescription");

                    b.Property<string>("MissionStatement");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("WebsiteLink");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("VollyTest.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("VollyTest.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VollyTest.Models.VolunteerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("VolunteerTypes");
                });

            modelBuilder.Entity("VollyTest.Models.Application", b =>
                {
                    b.HasOne("VollyTest.Models.Opportunity", "Opportunity")
                        .WithMany()
                        .HasForeignKey("OpportunityId");
                });

            modelBuilder.Entity("VollyTest.Models.Opportunity", b =>
                {
                    b.HasOne("VollyTest.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("VollyTest.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("VollyTest.Models.Skill", "SkillRequired")
                        .WithMany()
                        .HasForeignKey("SkillRequiredId");

                    b.HasOne("VollyTest.Models.VolunteerType", "VolunteerType")
                        .WithMany()
                        .HasForeignKey("VolunteerTypeId");
                });

            modelBuilder.Entity("VollyTest.Models.Skill", b =>
                {
                    b.HasOne("VollyTest.Models.User")
                        .WithMany("Skills")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
