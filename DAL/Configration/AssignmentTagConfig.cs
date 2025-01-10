using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configration
{
    public class AssignmentTagConfig : IEntityTypeConfiguration<AssignmentTag>
    {
        public void Configure(EntityTypeBuilder<AssignmentTag> builder)
        {

                builder.HasOne(x => x.Assignment)
                        .WithMany(x => x.assignmentTags)
                        .HasForeignKey(x => x.AssignmentId);

                builder.HasOne(x => x.Tag)
                    .WithMany(x => x.assignmentTags)
                    .HasForeignKey(x => x.TagId);

                builder.Ignore(x => x.IsDeleted);
        }
    }
}

