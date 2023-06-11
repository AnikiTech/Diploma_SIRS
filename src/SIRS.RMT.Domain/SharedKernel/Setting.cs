using SIRS.Infrastructure.Domain.Base.Audit;

namespace SIRS.RMT.Domain.SharedKernel
{
    public sealed class Setting : SirsUserLoggableEntity<User>
    {
        public GlobalThemeColors GlobalThemeColor { get; set; }
        public PrimaryColors PrimaryColors { get; set; }
    }
}