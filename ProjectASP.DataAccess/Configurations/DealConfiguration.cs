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
    internal class DealConfiguration : EntityConfiguration<Deal>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Deal> builder)
        {
            builder.Property(x => x.University)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Degree)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Program)
                .HasMaxLength(60)
                .IsRequired();

            
            builder.HasOne(x => x.Stage)
                .WithMany(y => y.Deals)
                .HasForeignKey(x => x.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(y => y.Deals)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
