using System;
using ReadingIsGood70.Utils.Jwt;

namespace ReadingIsGood70.BusinessLayer.ResponseModels.Auth
{
    public class AuthenticationResponse
    {
        public Guid ClientId { get; set; }
        public JwtResponse Token { get; set; }
    }
}