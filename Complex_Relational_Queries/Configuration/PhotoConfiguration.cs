using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Complex_Relational_Queries.Configuration;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasKey(p=> p.PersonId);

        builder
            .HasData(new Photo[]
            {
                new() {PersonId=1,Url="/photo1"},
                new() {PersonId=2,Url="/photo2"},
                new() {PersonId=3,Url="/photo3"},
                new() {PersonId=4,Url="/photo4"},
            });
    }
}
