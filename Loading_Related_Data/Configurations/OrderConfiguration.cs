using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading_Related_Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData( new Order[]
            {
                new(){ Id=1,EmployeeId=1,OrderDate=new DateTime().Date },
                new(){ Id=2,EmployeeId=2,OrderDate=new DateTime().Date },
                new(){ Id=3,EmployeeId=2,OrderDate=new DateTime().Date },
                new(){ Id=4,EmployeeId=2,OrderDate=new DateTime().Date },
                new(){ Id=5,EmployeeId=3,OrderDate=new DateTime().Date },
                new(){ Id=6,EmployeeId=3,OrderDate=new DateTime().Date },
                new(){ Id=7,EmployeeId=3,OrderDate=new DateTime().Date },
                new(){ Id=8,EmployeeId=4,OrderDate=new DateTime().Date },
                new(){ Id=9,EmployeeId=1,OrderDate=new DateTime().Date },
                new(){ Id=10,EmployeeId=2,OrderDate=new DateTime().Date },
            }
                );
        }
    }
}
