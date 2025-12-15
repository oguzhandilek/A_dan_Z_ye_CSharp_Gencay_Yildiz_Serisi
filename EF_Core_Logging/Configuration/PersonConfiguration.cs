using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Logging.Configuration
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Orders).WithOne(p => p.Person).HasForeignKey(p => p.PersonId);
            builder
                .HasData(new Person[]
                {
                new() { Id = 1,Name="Muhiyittin" },
                new() { Id = 2,Name="Sedrettin" },
                new() { Id = 3,Name="Mugime"},
                new() { Id = 4,Name="Cucume"},
                });
        }
    }
}
