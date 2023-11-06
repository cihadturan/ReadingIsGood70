using ReadingIsGood70.Utils.Jwt;

namespace ReadingIsGood70.BusinessLayer.ResponseModels.Auth
{
    public class RefreshLoginResponse
    {
        public JwtResponse Token { get; set; }
    }
}