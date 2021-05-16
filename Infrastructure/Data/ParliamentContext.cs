using Microsoft.EntityFrameworkCore;
using ParliamentApp.Models;
using ParliamentApp.Models.Entities;
using System.Reflection;

namespace ParliamentApp.Infrastructure.Data
{
    public class ParliamentContext : DbContext
    {
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<MemberVote> MemberVotes { get; set; }
        public virtual DbSet<MemberOfParliament> MembersOfParliament { get; set; }
        public virtual DbSet<ParliamentPeriod> ParliamentPeriods { get; set; }

        public ParliamentContext(DbContextOptions<ParliamentContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // Needed to create mock
        public ParliamentContext()
        {

        }
    }
}
