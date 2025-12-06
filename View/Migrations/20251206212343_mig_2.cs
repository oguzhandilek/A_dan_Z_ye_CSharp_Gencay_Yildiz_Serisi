using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace View.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"create View vm_PersonsOrdes
                                as
                                select Top 100 p.[Name],Count(*) [Count] from Perssons p
                                left join Orders o on  p.Id=o.PersonId
                                Group By p.Name
                                Order by(p.Name) desc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop view vm_PersonsOrdes");
        }
    }
}
