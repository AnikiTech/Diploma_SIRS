using Microsoft.EntityFrameworkCore;
using SIRS.Infrastructure.EntityFramework;

namespace SIRS.RMT.Domain.EntityFramework
{
    public class ReadingMemoryThinkingDbContext : SirsDbContext
    {
        public ReadingMemoryThinkingDbContext(DbContextOptions contextOptions, ISirsDbContextOptions sirsDbContextOptions) : base(contextOptions, sirsDbContextOptions)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _ = builder.HasPostgresExtension("uuid-ossp");
            base.OnModelCreating(builder);
            _ = builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}