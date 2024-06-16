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
    internal class PackagePageConfiguration : IEntityTypeConfiguration<PackagePage>
    {
        public void Configure(EntityTypeBuilder<PackagePage> builder)
        {

            builder.HasKey(x => new { x.PageId, x.PackageId });

            //builder.HasOne(x => x.Package)
            //    .WithMany(x => x.Pages)
            //    .HasForeignKey(x => x.PackageId);

            //builder.HasOne(x => x.Page)
            //    .WithMany(x => x.Packages)
            //    .HasForeignKey(x => x.PageId);
        }
    }
}
