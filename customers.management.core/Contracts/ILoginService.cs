using System.Collections.Generic;
using System.Security.Claims;
using customers.management.core.dto;

namespace customers.management.core.Contracts
{
    public interface ILoginService
    {
        ClaimsIdentity Authorize(UserDetails userDetails);

        List<Claim> GetCurrentUserIdentity();

        bool IsCurrentUserAdmin();

    }
}
