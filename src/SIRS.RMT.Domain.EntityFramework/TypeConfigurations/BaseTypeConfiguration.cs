using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.RMT.Domain.SharedKernel;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class BaseTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            _ = builder.ToTable($"{nameof(User)}s");
        }
    }
}