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
    internal class PackageConfiguration : NamedEntityConfiguration<Package>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Package> builder)
        {
            //builder.HasMany(x => x.Pages)
            //    .WithOne(x => x.Packages)
            //    .HasForeignKey(x => x.PackageId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
