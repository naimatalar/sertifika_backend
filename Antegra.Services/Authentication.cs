using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Labote.Services
{
    public static class Authentication
    {
        public static Guid? UserId(this IIdentity Identity)
        {
            ClaimsIdentity claimsIdentity = Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("userId");

            if (claim?.Value==null)
            {
                return null;
            }

            return Guid.Parse(claim?.Value);
        }

    }
}
