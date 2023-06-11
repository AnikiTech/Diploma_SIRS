using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIRS.Infrastructure.EntityFramework;
using SIRS.RMT.Domain.Memory.Word;

namespace SIRS.RMT.Domain.EntityFramework.TypeConfigurations
{
    internal class ExerciseSetupTypeConfiguration : IEntityTypeConfiguration<ExerciseSetup>
    {
        public void Configure(EntityTypeBuilder<ExerciseSetup> builder)
        {
            _ = builder.UseActivityLog();

            _ = builder.HasOne(x => x.User)
                   .WithOne(x => x.ExerciseSetup)
                   .HasForeignKey<ExerciseSetup>("UserId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            _ = builder.ToTable($"{nameof(ExerciseSetup)}s", Schemes.Setting);
        }
    }
}