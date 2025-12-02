using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Complex_Relational_Queries.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Photos_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Muhiyittin" },
                    { 2, 1, "Sedrettin" },
                    { 3, 2, "Mugime" },
                    { 4, 2, "Cucume" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Description", "PersonId" },
                values: new object[,]
                {
                    { 1, "...", 1 },
                    { 2, "...", 1 },
                    { 3, "...", 2 },
                    { 4, "...", 2 },
                    { 5, "...", 2 },
                    { 6, "...", 3 },
                    { 7, "...", 4 },
                    { 8, "...", 4 },
                    { 9, "...", 3 },
                    { 10, "...", 3 }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PersonId", "Url" },
                values: new object[,]
                {
                    { 1, "/photo1" },
                    { 2, "/photo2" },
                    { 3, "/photo3" },
                    { 4, "/photo4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
