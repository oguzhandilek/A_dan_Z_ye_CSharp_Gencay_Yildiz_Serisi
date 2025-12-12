using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreAdoNet.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
           .HasData(new Order[]
                  {
                new Order { Id = 1,PersonId = 1,Description="...",Price=200},
                new Order { Id = 2,PersonId = 1,Description="...",Price=210},
                new Order { Id = 3,PersonId = 2,Description="...",Price=220},
                new Order { Id = 4,PersonId = 2,Description="...",Price=230},
                new Order { Id = 5,PersonId = 2,Description="...",Price=240},
                new Order { Id = 6,PersonId = 3,Description="...",Price=250},
                new Order { Id = 7,PersonId = 4,Description="...",Price=260},
                new Order { Id = 8,PersonId = 4,Description="...",Price=270},
                new Order { Id = 9,PersonId = 3,Description="...",Price=270},
                new Order { Id = 10,PersonId = 3,Description="...",Price=280},
                  });
    }
}
