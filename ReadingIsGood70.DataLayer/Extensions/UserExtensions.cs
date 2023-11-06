using System;
using ReadingIsGood70.EntityLayer.Database.Auth;
using ReadingIsGood70.EntityLayer.QueryModels;

namespace ReadingIsGood70.DataLayer.Extensions
{
    public static class UserExtensions
    {
        public static QueryUserFromLoginResponse ToQueryUserResponse(this User user, Guid clientId)
        {
            return new()
            {
                Uuid = user.Uuid,
                ClientId = clientId
            };
        }
    }
}