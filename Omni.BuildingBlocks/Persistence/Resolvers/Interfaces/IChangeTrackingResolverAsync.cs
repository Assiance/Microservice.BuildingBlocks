using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Omni.BuildingBlocks.Persistence.Resolvers.Interfaces
{
    public interface IChangeTrackingResolverAsync
    {
        Task ResolveAsync(EntityEntry entry);
    }
}
