namespace Omni.BuildingBlocks.Api.Configuration.HttpClient.Models
{
    public class CircuitBreakerConfiguration
    {
        public int DurationOfBreakMs { get; set; }

        public int ExceptionsAllowedBeforeBreaking { get; set; }
    }
}