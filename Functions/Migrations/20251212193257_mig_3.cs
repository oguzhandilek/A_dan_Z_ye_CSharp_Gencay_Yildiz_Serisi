using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Functions.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"create function tvf_bestSellingStaff(@totalOrderPrice int)
                                    returns table
                                    as
                                    Return
                                    select top 1 p.Name
                                    ,Count(*) OrderCount
                                    ,Sum(o.Price) TotalOrderPrice
                                    from Persons p
                                    left join Orders o
                                    on p.Id=o.PersonId
                                    group by p.Name
                                    having SUm(o.Price)<@totalOrderPrice
                                    order by OrderCount desc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop function tvf_bestSellingStaff");
        }
    }
}
