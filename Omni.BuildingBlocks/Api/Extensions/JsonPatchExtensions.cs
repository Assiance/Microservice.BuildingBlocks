using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Omni.BuildingBlocks.ExceptionHandling.Exceptions;

namespace Omni.BuildingBlocks.Api.Extensions
{
    public static class JsonPatchExtensions
    {
        public static void IncludedPatchOps<T>(this JsonPatchDocument<T> patch, IEnumerable<OperationType> opTypes)
            where T : class
        {
            if (patch.Operations.Any(x => !opTypes.Contains(x.OperationType)))
            {
                var supportedOpTypes = string.Join(", ", opTypes);
                throw new BadRequestException($"Unsupported operation. Supported operations for this PATCH: {supportedOpTypes}");
            }
        }

        public static void ExcludedPatchPaths<T>(this JsonPatchDocument<T> patch, IEnumerable<string> paths)
            where T : class
        {
            if (paths.Any(x => patch.Operations.Any(p => p.path.Contains(x))))
            {
                var unSupportedPaths = string.Join(", ", paths);
                throw new BadRequestException($"Unsupported path. Unsupported path for this PATCH: {unSupportedPaths}");
            }
        }
    }
}
