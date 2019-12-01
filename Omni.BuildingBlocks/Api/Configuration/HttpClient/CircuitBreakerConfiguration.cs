﻿namespace Omni.BuildingBlocks.Api.Configuration.HttpClient
{
    public class CircuitBreakerConfiguration
    {
        public int DurationOfBreakMs { get; set; }

        public int ExceptionsAllowedBeforeBreaking { get; set; }
    }
}