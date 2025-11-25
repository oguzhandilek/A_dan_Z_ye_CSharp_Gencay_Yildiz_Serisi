using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sequence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterSequence(
                name: "EmployeeAndCustomer_Sequence",
                incrementBy: 15);

            migrationBuilder.RestartSequence(
                name: "EmployeeAndCustomer_Sequence",
                startValue: 100L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterSequence(
                name: "EmployeeAndCustomer_Sequence",
                oldIncrementBy: 15);

            migrationBuilder.RestartSequence(
                name: "EmployeeAndCustomer_Sequence",
                startValue: 1L);
        }
    }
}
