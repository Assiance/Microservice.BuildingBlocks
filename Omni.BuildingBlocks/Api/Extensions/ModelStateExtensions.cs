using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Omni.BuildingBlocks.Api.Extensions
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<string> ToFormattedErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
        }
    }
}
