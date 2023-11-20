using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TbcTask.Infrastructure.Store.Migrations
{
    public partial class addDualForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectedPersons",
                table: "ConnectedPersons");

            migrationBuilder.DropIndex(
                name: "IX_ConnectedPersons_PhysicialPersonId",
                table: "ConnectedPersons");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ConnectedPersons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "DualValidation",
                table: "ConnectedPersons",
                columns: new[] { "PhysicialPersonId", "ConnectedPersonId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "DualValidation",
                table: "ConnectedPersons");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ConnectedPersons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectedPersons",
                table: "ConnectedPersons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPersons_PhysicialPersonId",
                table: "ConnectedPersons",
                column: "PhysicialPersonId");
        }
    }
}
