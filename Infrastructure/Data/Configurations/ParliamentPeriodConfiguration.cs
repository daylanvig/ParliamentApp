using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParliamentApp.Models.Entities;
using System;

namespace ParliamentApp.Infrastructure.Data.Configurations
{
    public class ParliamentPeriodConfiguration : IEntityTypeConfiguration<ParliamentPeriod>
    {
        public void Configure(EntityTypeBuilder<ParliamentPeriod> builder)
        {
            builder.HasIndex(p => new
            {
                p.ParliamentNumber,
                p.SessionNumber
            }).IsUnique();
            // TODO: Find an endpoint that will provide this automatically (?)
            builder.HasData(
                new ParliamentPeriod
                {
                    Id = 1,
                    ParliamentNumber = 43,
                    SessionNumber = 2,
                    StartDate = new DateTimeOffset(2020, 9, 23, 0, 0, 0, TimeSpan.Zero),
                    EndDate = null
                },
                new ParliamentPeriod
                {
                    Id = 2,
                    ParliamentNumber = 43,
                    SessionNumber = 1,
                    StartDate = new DateTimeOffset(2019, 12, 5, 0, 0, 0, TimeSpan.Zero),
                    EndDate = new DateTimeOffset(2019, 9, 11, 0, 0, 0, TimeSpan.Zero)
                }
            );
        }
    }
}
