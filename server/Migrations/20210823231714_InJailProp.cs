namespace LeekQuest.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class InJailProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InJail",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InJail",
                table: "AspNetUsers");
        }
    }
}
