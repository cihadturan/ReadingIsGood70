﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ReadingIsGood70.Utils.Identity;

namespace ReadingIsGood70.BusinessLayer.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal claims)
         => Guid.Parse(claims.FindFirst(ClaimsIdentityHelper.ClaimsTypes.ClientId)?.Value ?? string.Empty);
    }
}
