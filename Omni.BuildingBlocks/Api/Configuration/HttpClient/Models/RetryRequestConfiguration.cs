using System.Collections.Generic;

namespace Omni.BuildingBlocks.Api.Configuration.HttpClient.Models
{
    public class RetryRequestConfiguration
    {
        public IEnumerable<int> IntervalsMs { get; set; }

        public IEnumerable<string> HttpStatusCodes { get; set; }
    }
}