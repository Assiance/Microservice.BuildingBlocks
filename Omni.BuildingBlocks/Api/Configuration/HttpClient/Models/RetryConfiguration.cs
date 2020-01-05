namespace Omni.BuildingBlocks.Api.Configuration.HttpClient.Models
{
    public class RetryConfiguration
    {
        public RetryRequestConfiguration Read { get; set; }

        public RetryRequestConfiguration Write { get; set; }
    }
}