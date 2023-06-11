using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.RMT.Domain.Memory.Word;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class WordsDictionaryTypeConfiguration : IEntityTypeConfiguration<WordsDictionary>
    {
        public void Configure(EntityTypeBuilder<WordsDictionary> builder)
        {
            _ = builder.Property(x => x.Word).IsRequired();

            _ = builder.ToTable("WordsDictionaries", Schemes.Dictionary);
        }
    }
}