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
    public class AssignmentEmployeeConfig : IEntityTypeConfiguration<AssignmentEmployee>
    {
        public void Configure(EntityTypeBuilder<AssignmentEmployee> builder)
        {

            builder.HasOne(x => x.Assignment)
                .WithMany(x => x.assignmentEmployees)
                .HasForeignKey(x => x.AssignmentId);

            builder.HasOne(x => x.Employee)
            .WithMany(x => x.assignmentEmployees)
            .HasForeignKey(x => x.EmployeeId);

            builder.Ignore(x => x.IsDeleted);
        }
    }
}
