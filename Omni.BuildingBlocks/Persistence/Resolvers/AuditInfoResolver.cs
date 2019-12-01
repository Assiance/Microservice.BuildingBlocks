using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Omni.BuildingBlocks.Persistence.Resolvers.Interfaces;
using Omni.BuildingBlocks.Shared.UserProvider;

namespace Omni.BuildingBlocks.Persistence.Resolvers
{
    public class AuditInfoResolver : IAuditInfoResolver
    {
        private readonly ICurrentUserService _currentUserService;

        public AuditInfoResolver(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public void Resolve(EntityEntry entry)
        {
            if (entry.Entity is IAuditInfo audit)
            {
                var nickname = _currentUserService.GetCurrentUser().Nickname;
                var now = DateTime.UtcNow;
                var user = !string.IsNullOrEmpty(nickname) ? nickname : "SYSTEM";

                switch (entry.State)
                {
                    case EntityState.Added:
                        audit.CreatedDate = now;
                        audit.CreatedBy = user;
                        break;

                    case EntityState.Modified:
                        audit.ModifiedDate = now;
                        audit.ModifiedBy = user;
                        break;
                }
            }
        }
    }
}
