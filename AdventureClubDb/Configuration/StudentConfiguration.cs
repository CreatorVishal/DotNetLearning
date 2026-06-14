using AdventureClubDb.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureClubDb.Configuration
{
    public class StudentConfiguration
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(100);
        }
    }
}
