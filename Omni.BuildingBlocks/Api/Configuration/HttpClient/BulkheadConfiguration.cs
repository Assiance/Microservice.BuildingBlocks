﻿namespace Omni.BuildingBlocks.Api.Configuration.HttpClient
{
    public class BulkheadConfiguration
    {
        public int MaxParallelization { get; set; }

        public int MaxQueuingActions { get; set; }
    }
}