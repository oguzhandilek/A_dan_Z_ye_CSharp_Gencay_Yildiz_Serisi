using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Complex_Relational_Queries.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
             .HasKey(p => p.Id);
        builder.HasMany(p => p.Orders)
            .WithOne(p => p.Person).
            HasForeignKey(p => p.PersonId);
        builder
            .HasOne(p => p.Photo)
            .WithOne(p => p.Person)
            .HasForeignKey<Photo>(p => p.PersonId);

        builder
            .HasData(new Person[]
            {
                new() { Id = 1,Name="Muhiyittin",Gender=Gender.Man },
                new() { Id = 2,Name="Sedrettin",Gender=Gender.Man },
                new() { Id = 3,Name="Mugime",Gender=Gender.Woman },
                new() { Id = 4,Name="Cucume",Gender=Gender.Woman },
            });
    }
}
