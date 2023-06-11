using Microsoft.EntityFrameworkCore;
using SIRS.Infrastructure.EntityFramework;
using SIRS.RMT.Config;

namespace SIRS.RMT.Domain.EntityFramework
{
    public class ReadingMemoryThinkingDbContextFactory
    {
        private readonly DbContextOptions<ReadingMemoryThinkingDbContext> dbContextOptions;
        private readonly ISirsDbContextOptions sirsDbContextOptions;

        public ReadingMemoryThinkingDbContextFactory(DbContextOptions<ReadingMemoryThinkingDbContext> options, ReadingMemoryThinkingConfiguration configuration)
        {
            dbContextOptions = options;
            sirsDbContextOptions = new SirsDbContextOptions(() => configuration.Application.Name);
        }

        public ReadingMemoryThinkingDbContext CreateAsApplication()
        {
            return new ReadingMemoryThinkingDbContext(dbContextOptions, sirsDbContextOptions);
        }
    }
}