using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TbcTask.Infrastructure.Store.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonConnectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonConnectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    PrivateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersons_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConnectedPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonConnectionTypeID = table.Column<int>(type: "int", nullable: false),
                    PhysicalPersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectedPersons_PersonConnectionTypes_PersonConnectionTypeID",
                        column: x => x.PersonConnectionTypeID,
                        principalTable: "PersonConnectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectedPersons_PhysicalPersons_PhysicalPersonID",
                        column: x => x.PhysicalPersonID,
                        principalTable: "PhysicalPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneTypeID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalPersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneTypes_PhoneTypeID",
                        column: x => x.PhoneTypeID,
                        principalTable: "PhoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_PhysicalPersons_PhysicalPersonID",
                        column: x => x.PhysicalPersonID,
                        principalTable: "PhysicalPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPersons_PersonConnectionTypeID",
                table: "ConnectedPersons",
                column: "PersonConnectionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPersons_PhysicalPersonID",
                table: "ConnectedPersons",
                column: "PhysicalPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneTypeID",
                table: "Phones",
                column: "PhoneTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhysicalPersonID",
                table: "Phones",
                column: "PhysicalPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersons_GenderID",
                table: "PhysicalPersons",
                column: "GenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectedPersons");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PersonConnectionTypes");

            migrationBuilder.DropTable(
                name: "PhoneTypes");

            migrationBuilder.DropTable(
                name: "PhysicalPersons");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
