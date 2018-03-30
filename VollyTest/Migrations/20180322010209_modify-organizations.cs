using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VollyTest.Migrations
{
    public partial class modifyorganizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoliceCheckRequired",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "VolunteersNeeded",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Organizations",
                newName: "WebsiteLink");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Organizations",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Organizations",
                newName: "MissionStatement");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonateLink",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Organizations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DonateLink",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "WebsiteLink",
                table: "Organizations",
                newName: "ShortDescription");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Organizations",
                newName: "LogoUrl");

            migrationBuilder.RenameColumn(
                name: "MissionStatement",
                table: "Organizations",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "PoliceCheckRequired",
                table: "Organizations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VolunteersNeeded",
                table: "Organizations",
                nullable: false,
                defaultValue: false);
        }
    }
}
