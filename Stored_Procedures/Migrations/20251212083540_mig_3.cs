using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stored_Procedures.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"create proc usp_bestSellingStaff
                                as
                                	declare @name nvarchar(max),@count int
                                select top 1 @name= p.[Name], @count=count(*) from Persons p
                                 join Orders o 
                                on p.Id=o.PersonId
                                group by p.[Name]
                                order by COUNT(*) desc
                                return @count");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop proc usp_bestSellingStaff");
        }
    }
}
