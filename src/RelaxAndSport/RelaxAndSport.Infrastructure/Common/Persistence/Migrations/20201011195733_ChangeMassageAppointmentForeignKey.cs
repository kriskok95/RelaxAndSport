using Microsoft.EntityFrameworkCore.Migrations;

namespace RelaxAndSport.Infrastructure.Common.Persistence.Migrations
{
    public partial class ChangeMassageAppointmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MassageAppointments_MassagesSchedules_MassageAppointmentId",
                table: "MassageAppointments");

            migrationBuilder.DropIndex(
                name: "IX_MassageAppointments_MassageAppointmentId",
                table: "MassageAppointments");

            migrationBuilder.DropColumn(
                name: "MassageAppointmentId",
                table: "MassageAppointments");

            migrationBuilder.AddColumn<int>(
                name: "MassagesScheduleId",
                table: "MassageAppointments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MassageAppointments_MassagesScheduleId",
                table: "MassageAppointments",
                column: "MassagesScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MassageAppointments_MassagesSchedules_MassagesScheduleId",
                table: "MassageAppointments",
                column: "MassagesScheduleId",
                principalTable: "MassagesSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MassageAppointments_MassagesSchedules_MassagesScheduleId",
                table: "MassageAppointments");

            migrationBuilder.DropIndex(
                name: "IX_MassageAppointments_MassagesScheduleId",
                table: "MassageAppointments");

            migrationBuilder.DropColumn(
                name: "MassagesScheduleId",
                table: "MassageAppointments");

            migrationBuilder.AddColumn<int>(
                name: "MassageAppointmentId",
                table: "MassageAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MassageAppointments_MassageAppointmentId",
                table: "MassageAppointments",
                column: "MassageAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MassageAppointments_MassagesSchedules_MassageAppointmentId",
                table: "MassageAppointments",
                column: "MassageAppointmentId",
                principalTable: "MassagesSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
