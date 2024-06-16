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
    internal class FieldItemConfiguration : EntityConfiguration<FieldItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<FieldItem> builder)
        {
            builder.Property(x => x.FieldId)
                .IsRequired();

            builder.Property(x => x.Value)
                .HasMaxLength(80)
                .IsRequired();

            builder.HasOne(x => x.Field)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.FieldId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
