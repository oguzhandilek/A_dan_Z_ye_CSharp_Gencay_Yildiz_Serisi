using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading_Related_Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Navigation(e => e.Region).AutoInclude();
            builder.HasData(new Employee[]
            {
                new(){Id=1, RegionId=1,Name="Enver",Surname="İttihat",Salary=1000},
                new(){Id=2, RegionId=2,Name="Talat",Surname="Terakki",Salary=2000},
                new(){Id=3, RegionId=1,Name="Cemal",Surname="Perver",Salary=3000},
                new(){Id=4, RegionId=1,Name="Hamit",Surname="Saltanat",Salary=5000},
            });
        }
    }
}
