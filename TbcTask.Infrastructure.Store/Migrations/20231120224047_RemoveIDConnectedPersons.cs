using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TbcTask.Infrastructure.Store.Migrations
{
    public partial class RemoveIDConnectedPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConnectedPersons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ConnectedPersons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
