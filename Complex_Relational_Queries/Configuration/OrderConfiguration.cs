using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Complex_Relational_Queries.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o=> o.Id);
        builder
            .HasData(new Order[]
            {
                new Order { Id = 1,PersonId = 1,Description="..."}, 
                new Order { Id = 2,PersonId = 1,Description="..."}, 
                new Order { Id = 3,PersonId = 2,Description="..."}, 
                new Order { Id = 4,PersonId = 2,Description="..."}, 
                new Order { Id = 5,PersonId = 2,Description="..."}, 
                new Order { Id = 6,PersonId = 3,Description="..."}, 
                new Order { Id = 7,PersonId = 4,Description="..."}, 
                new Order { Id = 8,PersonId = 4,Description="..."}, 
                new Order { Id = 9,PersonId = 3,Description="..."}, 
                new Order { Id = 10,PersonId = 3,Description="..."}, 
            });
    }
}
