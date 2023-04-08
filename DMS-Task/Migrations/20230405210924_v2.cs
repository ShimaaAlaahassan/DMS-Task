﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS_Task.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsAppointment_Secrateries_SectateryID",
                table: "PatientsAppointment");

            migrationBuilder.DropIndex(
                name: "IX_PatientsAppointment_SectateryID",
                table: "PatientsAppointment");

            migrationBuilder.DropColumn(
                name: "SectateryID",
                table: "PatientsAppointment");

            migrationBuilder.AddColumn<int>(
                name: "SecrateryId",
                table: "PatientsAppointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsAppointment_SecrateryId",
                table: "PatientsAppointment",
                column: "SecrateryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsAppointment_Secrateries_SecrateryId",
                table: "PatientsAppointment",
                column: "SecrateryId",
                principalTable: "Secrateries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsAppointment_Secrateries_SecrateryId",
                table: "PatientsAppointment");

            migrationBuilder.DropIndex(
                name: "IX_PatientsAppointment_SecrateryId",
                table: "PatientsAppointment");

            migrationBuilder.DropColumn(
                name: "SecrateryId",
                table: "PatientsAppointment");

            migrationBuilder.AddColumn<int>(
                name: "SectateryID",
                table: "PatientsAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsAppointment_SectateryID",
                table: "PatientsAppointment",
                column: "SectateryID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsAppointment_Secrateries_SectateryID",
                table: "PatientsAppointment",
                column: "SectateryID",
                principalTable: "Secrateries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
