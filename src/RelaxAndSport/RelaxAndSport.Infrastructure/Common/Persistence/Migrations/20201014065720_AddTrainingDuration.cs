using Microsoft.EntityFrameworkCore.Migrations;

namespace RelaxAndSport.Infrastructure.Common.Persistence.Migrations
{
    public partial class AddTrainingDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Trainings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Trainings");
        }
    }
}
