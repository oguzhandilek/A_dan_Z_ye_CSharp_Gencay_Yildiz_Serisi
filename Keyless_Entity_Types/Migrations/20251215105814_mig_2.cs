using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keyless_Entity_Types.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"create view vw_PersonOrderCount
as
select p.Name, count(*) [Count] from Persons p
left join [Orders] o 
on p.Id=o.PersonId
group by p.[Name]
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop view vw_PersonOrderCount");
        }
    }
}
