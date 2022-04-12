using Microsoft.EntityFrameworkCore.Migrations;

namespace cs43_EF4_2.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tendaydu",
                table: "Cungcap",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Cungcap",
                newName: "Tendaydu");
        }
    }
}
