using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.Infrastructure.EntityFramework;
using SIRS.RMT.Domain.SharedKernel;
using System;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class SettingTypeConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            _ = builder.Property<Guid>("UserId");
            _ = builder.UseActivityLog();

            _ = builder.HasOne(x => x.User)
                   .WithOne(x => x.Setting)
                   .HasForeignKey<Setting>("UserId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            _ = builder.ToTable($"{nameof(Setting)}s", Schemes.Setting);
        }
    }
}