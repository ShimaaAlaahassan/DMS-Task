using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS_Task.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentTime",
                table: "PatientsAppointment");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "PatientsAppointment",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "PatientsAppointment",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "PatientsAppointment");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "PatientsAppointment");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentTime",
                table: "PatientsAppointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
