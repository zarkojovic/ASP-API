using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.DataAccess.Configurations
{
    internal class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(x => x.Username)
                .IsUnique();

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(x => x.Phone)
                .IsUnique();

            builder.Property(x => x.RoleId)
                .IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.CompanyId);

            builder.HasMany(x => x.UserInfo)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Notifications)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Students)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x => x.Package)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PackageId);

        }
    }
}
