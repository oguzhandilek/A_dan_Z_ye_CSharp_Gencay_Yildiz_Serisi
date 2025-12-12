using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stored_Procedures.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"create proc [dbo].[usp_PersonOrders2]
(
	@PersonId int,
	@Name Nvarchar(max) OUTPUT
)
                            as
                            Select @Name= p.[Name]from Persons p
                            left join Orders o
                            on p.Id=o.PersonId
							where p.Id=@PersonId
                         ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop proc usp_PersonOrders2");
        }
    }
}
