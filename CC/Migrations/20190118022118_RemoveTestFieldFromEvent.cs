using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Migrations
{
    public partial class RemoveTestFieldFromEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Events",
                nullable: true);
        }
    }
}
