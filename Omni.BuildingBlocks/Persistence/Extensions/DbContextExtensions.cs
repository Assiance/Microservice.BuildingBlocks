using Microsoft.EntityFrameworkCore;

namespace Omni.BuildingBlocks.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static void UpdateRowVersion(this DbContext context, IVersionInfo versionInfo, byte[] newRowVersion)
        {
            context.Entry(versionInfo).Property(u => u.RowVersion).OriginalValue = newRowVersion;
        }
    }
}