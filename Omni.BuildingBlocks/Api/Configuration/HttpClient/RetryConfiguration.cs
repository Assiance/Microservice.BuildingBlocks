namespace Omni.BuildingBlocks.Api.Configuration.HttpClient
{
    public class RetryConfiguration
    {
        public RetryRequestConfiguration Read { get; set; }

        public RetryRequestConfiguration Write { get; set; }
    }
}