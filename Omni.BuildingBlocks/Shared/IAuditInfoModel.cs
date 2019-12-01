using System;

namespace Omni.BuildingBlocks.Shared
{
    public interface IAuditInfoModel
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
