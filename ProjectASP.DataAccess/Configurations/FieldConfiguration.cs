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
    internal class FieldConfiguration : NamedEntityConfiguration<Field>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Field> builder)
        {
            builder.Property(x => x.IsRequired)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.IsReadOnly)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasMaxLength(80)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(y => y.Fields)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Field)
                .HasForeignKey(x => x.FieldId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
