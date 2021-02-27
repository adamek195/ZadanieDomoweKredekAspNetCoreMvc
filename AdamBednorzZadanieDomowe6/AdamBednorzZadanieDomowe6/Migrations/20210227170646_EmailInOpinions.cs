using Microsoft.EntityFrameworkCore.Migrations;

namespace AdamBednorzZadanieDomowe6.Migrations
{
    public partial class EmailInOpinions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Opinions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Opinions");
        }
    }
}
