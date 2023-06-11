using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.Infrastructure.EntityFramework;
using SIRS.RMT.Domain.Memory.Colors.Statistics;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class StatisticWordsTypeConfiguration : IEntityTypeConfiguration<StatisticColorLog>
    {
        public void Configure(EntityTypeBuilder<StatisticColorLog> builder)
        {
            _ = builder.UseActivityLog();

            _ = builder.HasOne(x => x.User)
                   .WithMany(x => x.Statistics)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            _ = builder.ToTable($"{nameof(StatisticColorLog)}s", Schemes.Statistic);
        }
    }
}