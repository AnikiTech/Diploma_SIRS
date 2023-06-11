using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.RMT.Domain.Memory.Colors;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class ColorsDictionaryTypeConfiguration : IEntityTypeConfiguration<ColorsDictionary>
    {
        public void Configure(EntityTypeBuilder<ColorsDictionary> builder)
        {
            _ = builder.Property(x => x.HexColor).IsRequired();

            _ = builder.ToTable("ColorsDictionaries", Schemes.Dictionary);
        }
    }
}