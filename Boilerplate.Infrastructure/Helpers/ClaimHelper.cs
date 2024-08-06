using Boilerplate.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Boilerplate.Infrastructure.Helpers
{
    public class ClaimHelper : IClaimHelper
    {
        private readonly ClaimsIdentity _claimsIdentity;

        public ClaimHelper(IHttpContextAccessor context)
        {
            _claimsIdentity = context.HttpContext.User?.Identity as ClaimsIdentity;
        }

        public int UserId
        {
            get
            {
                var value = GetClaim(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(value))
                {
                    return int.Parse(value);
                }

                throw new Exception("Token is invalid");
            }
        }

        private string GetClaim(string claimType)
        {
            var claim = _claimsIdentity.Claims.FirstOrDefault(f => f.Type == claimType);
            if (claim != null) return claim.Value;

            return string.Empty;
        }
    }
}
