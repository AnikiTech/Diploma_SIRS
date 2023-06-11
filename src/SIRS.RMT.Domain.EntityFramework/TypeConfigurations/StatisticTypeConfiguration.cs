using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.Infrastructure.EntityFramework;
using SIRS.RMT.Domain.Memory.Word.Statistics;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class StatisticTypeConfiguration : IEntityTypeConfiguration<StatisticWordsLog>
    {
        public void Configure(EntityTypeBuilder<StatisticWordsLog> builder)
        {
            _ = builder.UseActivityLog();

            _ = builder.HasOne(x => x.User)
                   .WithMany(x => x.StatisticsWords)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            _ = builder.ToTable($"{nameof(StatisticWordsLog)}s", Schemes.Statistic);
        }
    }
}