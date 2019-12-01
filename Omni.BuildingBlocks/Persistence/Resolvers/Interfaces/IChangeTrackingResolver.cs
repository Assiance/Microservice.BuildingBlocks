using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Omni.BuildingBlocks.Persistence.Resolvers.Interfaces
{
    public interface IChangeTrackingResolver
    {
        void Resolve(EntityEntry entry);
    }
}
