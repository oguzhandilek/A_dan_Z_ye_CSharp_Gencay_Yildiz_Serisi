using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shadow_Property.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastUpdad",
                table: "Posts",
                newName: "lastUpdated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastUpdated",
                table: "Posts",
                newName: "lastUpdad");
        }
    }
}
