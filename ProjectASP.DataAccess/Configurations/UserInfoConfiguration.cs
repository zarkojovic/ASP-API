using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectASP.DataAccess.Configurations;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.DataAccess
{
    internal class UserInfoConfiguration : EntityConfiguration<UserInfo>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UserInfo> builder)
        {
            builder.Property(x => x.FieldId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserInfo)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Field)
                .WithMany(x => x.UserInfo)
                .HasForeignKey(x => x.FieldId);
        }
    }
}
