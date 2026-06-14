using AdventureClubDb.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureClubDb.Configuration
{
    public class CourseConfiguration
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Title)
                   .HasMaxLength(100);
        }
    }
}
