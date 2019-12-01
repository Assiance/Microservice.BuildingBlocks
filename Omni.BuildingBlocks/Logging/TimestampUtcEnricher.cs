using System;
using Serilog.Core;
using Serilog.Events;

namespace Omni.BuildingBlocks.Logging
{
    public class TimestampUtcEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory
                .CreateProperty("TimestampUtc", DateTimeOffset.UtcNow));
        }
    }
}