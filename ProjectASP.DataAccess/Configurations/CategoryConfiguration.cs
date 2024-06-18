using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.DataAccess.Configurations
{
    internal class CategoryConfiguration : NamedEntityConfiguration<Category>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.ReadOnly)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasMany(x => x.Pages)
                .WithMany(x => x.Categories)
                .UsingEntity(x => x.ToTable("CategoryPages"));

            builder.HasMany(x => x.Stages)
                .WithMany(x => x.Categories)
                .UsingEntity(x => x.ToTable("CategoryStages"));

            builder.HasMany(x => x.Fields)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
