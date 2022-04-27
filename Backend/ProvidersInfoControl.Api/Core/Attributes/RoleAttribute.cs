using Microsoft.AspNetCore.Authorization;
using ProvidersInfoControl.Domain.Enums;

namespace ProvidersInfoControl.Api.Core.Attributes;

public class RoleAttribute : AuthorizeAttribute
{
    public RoleAttribute(params UserRole[] roles)
    {
        Roles = string.Join(",", roles);
    }
}