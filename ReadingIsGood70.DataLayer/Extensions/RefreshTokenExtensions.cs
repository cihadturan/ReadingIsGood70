using System;
using ReadingIsGood70.EntityLayer.Database.Auth;

namespace ReadingIsGood70.DataLayer.Extensions
{
    public static class RefreshTokenExtensions
    {
        public static bool IsExpired(this RefreshToken refreshToken)
        {
            return refreshToken.Rejected || refreshToken.ExpiresAt < DateTime.UtcNow;
        }
    }
}