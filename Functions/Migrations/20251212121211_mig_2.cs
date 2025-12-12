using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Functions.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Create Function ufn_getPersonTotalOrderPrice (@PersonId int) 
                                Returns Int
                                As
                                Begin
                                Declare @totalPrice int
                                Select @totalPrice= Sum(o.Price) from Persons p
                                left join Orders o 
                                on p.Id=o.PersonId
                                where p.Id=@PersonId
                                Return @totalPrice
                                End
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"drop function ufn_getPersonTotalOrderPrice");
        }
    }
}
