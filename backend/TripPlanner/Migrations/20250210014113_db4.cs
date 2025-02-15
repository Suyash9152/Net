using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripPlanner.Migrations
{
    /// <inheritdoc />
    public partial class db4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravelDate",
                table: "TravelPlans",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "TransportMode",
                table: "TravelPlans",
                newName: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "NumberOfPeople",
                table: "TravelPlans",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "NumberOfDays",
                table: "TravelPlans",
                newName: "Days");

            migrationBuilder.RenameColumn(
                name: "AccommodationType",
                table: "TravelPlans",
                newName: "ModeOfTransport");

            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "TravelPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "TravelPlans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Distance",
                table: "TravelPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TravelPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "TravelPlans");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "TravelPlans");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "TravelPlans");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TravelPlans");

            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "TravelPlans",
                newName: "TransportMode");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "TravelPlans",
                newName: "TravelDate");

            migrationBuilder.RenameColumn(
                name: "People",
                table: "TravelPlans",
                newName: "NumberOfPeople");

            migrationBuilder.RenameColumn(
                name: "ModeOfTransport",
                table: "TravelPlans",
                newName: "AccommodationType");

            migrationBuilder.RenameColumn(
                name: "Days",
                table: "TravelPlans",
                newName: "NumberOfDays");
        }
    }
}
