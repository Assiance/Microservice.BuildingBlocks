﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Omni.BuildingBlocks.Http.CorrelationId
{
    public class CorrelationIdProvider : ICorrelationIdProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public CorrelationIdProvider(IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = loggerFactory.CreateLogger(nameof(CorrelationIdProvider));
        }

        public string EnsureCorrelationIdPresent()
        {
            _httpContextAccessor?.HttpContext?.Request?.Headers.TryGetValue(KnownHttpHeaders.CorrelationId,
                out StringValues values);
            var correlationId = values.FirstOrDefault();

            if (string.IsNullOrEmpty(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
                _logger.LogInformation(
                    $"{KnownHttpHeaders.CorrelationId} header is not set. New CorrelationId is generated {correlationId}");
            }

            return correlationId;
        }
    }
}