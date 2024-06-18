using Azure;
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
    internal class PageConfiguration : EntityConfiguration<Page>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Page> builder)
        {
            builder.Property(x => x.Route)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Icon)
                .IsRequired()
                .HasDefaultValue("tabler:favicon");

            builder.Property(x => x.RoleId).IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Pages)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Packages)
                .WithMany(x => x.Pages)
                .UsingEntity(x => x.ToTable("PackagePages"));

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Pages)
                .UsingEntity(x => x.ToTable("CategoryPages"));


        }
    }
}
