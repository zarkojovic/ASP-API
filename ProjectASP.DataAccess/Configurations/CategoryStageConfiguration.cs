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
    internal class CategoryStageConfiguration : IEntityTypeConfiguration<CategoryStage>
    {
        public void Configure(EntityTypeBuilder<CategoryStage> builder)
        {

            builder.HasKey(x => new { x.StageId, x.CategoryId });

        }
    }
}
