using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Value_Conversions.Migrations
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
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maried = table.Column<bool>(type: "bit", nullable: false),
                    Titles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Gender", "Gender2", "Maried", "Name", "Titles" },
                values: new object[,]
                {
                    { 1, "M", "Male", true, "Abdulhamit", null },
                    { 2, "M", "Male", true, "Eşref", null },
                    { 3, "M", "Male", true, "Bartu", null },
                    { 4, "F", "Female", true, "Cucume", null },
                    { 5, "F", "Female", false, "Halime", null },
                    { 6, "F", "Female", true, "Keriye", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
