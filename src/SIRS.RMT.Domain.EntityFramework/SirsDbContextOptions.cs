using SIRS.Infrastructure.EntityFramework;
using System;

namespace SIRS.RMT.Domain.EntityFramework
{
    public sealed class SirsDbContextOptions : ISirsDbContextOptions
    {
        public Func<string> GetActivityLogName { get; }

        public SirsDbContextOptions(Func<string> activityLogName)
        {
            this.GetActivityLogName = activityLogName;
        }
    }
}