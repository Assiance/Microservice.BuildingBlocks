using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Omni.BuildingBlocks.Persistence
{
    // Note: This interface was created to have a generic less way to grab all base entities. Originally used for sending all domainEvents
    public interface IBaseEntity
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }
        void AddDomainEvent(INotification eventItem);
        void RemoveDomainEvent(INotification eventItem);
        void ClearDomainEvents();
    }
}
