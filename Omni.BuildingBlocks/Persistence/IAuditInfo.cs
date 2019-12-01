﻿using System;

namespace Omni.BuildingBlocks.Persistence
{
    public interface IAuditInfo
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
