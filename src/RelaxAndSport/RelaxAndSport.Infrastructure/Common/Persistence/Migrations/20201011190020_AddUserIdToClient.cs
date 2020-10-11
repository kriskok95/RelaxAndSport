using Microsoft.EntityFrameworkCore.Migrations;

namespace RelaxAndSport.Infrastructure.Common.Persistence.Migrations
{
    public partial class AddUserIdToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MassageAppointments_Client_ClientId",
                table: "MassageAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingAppointments_Client_ClientId",
                table: "TrainingAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MassageAppointments_Clients_ClientId",
                table: "MassageAppointments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingAppointments_Clients_ClientId",
                table: "TrainingAppointments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MassageAppointments_Clients_ClientId",
                table: "MassageAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingAppointments_Clients_ClientId",
                table: "TrainingAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MassageAppointments_Client_ClientId",
                table: "MassageAppointments",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingAppointments_Client_ClientId",
                table: "TrainingAppointments",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
