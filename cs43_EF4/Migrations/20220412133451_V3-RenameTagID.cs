using Microsoft.EntityFrameworkCore.Migrations;

namespace cs43_EF4.Migrations
{
    public partial class V3RenameTagID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagIdnew",
                table: "Tags",
                newName: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "TagIdnew");
        }
    }
}
