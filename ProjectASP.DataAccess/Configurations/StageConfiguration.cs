using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.DataAccess.Configurations
{
    internal class StageConfiguration : NamedEntityConfiguration<Stage>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Stage> builder)
        {
            builder.HasMany(x => x.Deals)
                .WithOne(x => x.Stage)
                .HasForeignKey(x => x.StageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
