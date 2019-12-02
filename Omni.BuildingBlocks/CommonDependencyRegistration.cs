using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Omni.BuildingBlocks.DI;

namespace Omni.BuildingBlocks
{
    public static class CommonDependencyRegistration
    {
        public static IServiceCollection RegisterOmniBuildingBlockDependencies(this IServiceCollection services)
        {
            return services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly());
        }
    }
}