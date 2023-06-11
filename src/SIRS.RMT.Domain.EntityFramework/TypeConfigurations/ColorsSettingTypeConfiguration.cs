using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.RMT.Domain.Memory.Colors;
using System;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class ColorsSettingTypeConfiguration : IEntityTypeConfiguration<ColorsSetting>,
                                                    IEntityTypeConfiguration<ColorsSettingToDictionary>
    {
        public void Configure(EntityTypeBuilder<ColorsSetting> builder)
        {
            _ = builder.Property<Guid>("UserId");

            _ = builder.HasOne(x => x.User)
                   .WithOne(x => x.ColorsSetting)
                   .HasForeignKey<ColorsSetting>("UserId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            _ = builder.ToTable($"{nameof(ColorsSetting)}s", Schemes.Setting);
        }

        public void Configure(EntityTypeBuilder<ColorsSettingToDictionary> builder)
        {
            _ = builder.HasKey(t => new { BlobId = t.ColorsSettingId, t.ColorsDictionaryId });
            _ = builder.HasOne(t => t.ColorsSetting).WithMany(t => t.ColorsSettingToDictionary).HasForeignKey(x => x.ColorsSettingId).OnDelete(DeleteBehavior.Cascade);
            _ = builder.HasOne(t => t.ColorsDictionary).WithMany(x => x.ColorsSettingToDictionary).HasForeignKey(x => x.ColorsDictionaryId).OnDelete(DeleteBehavior.Cascade);

            _ = builder.ToTable("ColorsSettingToDictionaries", Schemes.Setting);
        }
    }
}