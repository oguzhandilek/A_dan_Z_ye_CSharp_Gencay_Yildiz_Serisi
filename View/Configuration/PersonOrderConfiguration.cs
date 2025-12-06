using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace View.Configuration
{
    public class PersonOrderConfiguration : IEntityTypeConfiguration<PersonOrder>
    {
        public void Configure(EntityTypeBuilder<PersonOrder> builder)
        {
            builder.ToView("vm_PersonsOrdes");
            builder.HasNoKey();

        }
    }
}
