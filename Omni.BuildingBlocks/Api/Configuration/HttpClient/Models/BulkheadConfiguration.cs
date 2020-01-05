namespace Omni.BuildingBlocks.Api.Configuration.HttpClient.Models
{
    public class BulkheadConfiguration
    {
        public int MaxParallelization { get; set; }

        public int MaxQueuingActions { get; set; }
    }
}