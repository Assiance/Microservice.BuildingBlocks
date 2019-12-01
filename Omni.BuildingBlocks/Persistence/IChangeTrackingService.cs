using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Omni.BuildingBlocks.Persistence
{
    public interface IChangeTrackingService
    {
        Task ExecuteResolversAsync(EntityEntry entry);
    }
}
