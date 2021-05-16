using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParliamentApp.Models;

namespace ParliamentApp.Infrastructure.Data.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasOne(v => v.ParliamentPeriod)
                   .WithMany(p => p.Votes)
                   .HasForeignKey(v => v.ParliamentPeriodId);

            builder.HasMany(v => v.MemberVotes)
                   .WithOne(mv => mv.Vote)
                   .HasForeignKey(mv => mv.VoteId);
        }
    }
}
