using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stored_Procedures.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"create proc usp_PersonOrders
                            as
                            Select p.[Name],Count (*) [Count] from Persons p
                            left join Orders o
                            on p.Id=o.PersonId
                            Group by p.[Name]
                            order by (p.Name)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop proc usp_PersonOrders");
        }
    }
}
